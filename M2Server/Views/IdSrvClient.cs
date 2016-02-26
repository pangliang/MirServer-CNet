using GameFramework;
using NetFramework;
using NetFramework.AsyncSocketClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TFrmIDSoc : Form
    {
        public Socket SendMsgSocket;
        public IClientScoket IDSocket;
        private string IDSrvAddr = String.Empty;
        private int IDSrvPort = 0;
        private uint dwClearEmptySessionTick = 0;
        public IList<TSessInfo> m_SessionList = null;

        public TFrmIDSoc()
        {
            InitializeComponent();
            IniFile Conf;
            if (File.Exists(M2Share.sConfigFileName))
            {
                Conf = new IniFile(M2Share.sConfigFileName);
                if (Conf != null)
                {
                    IDSrvAddr = Conf.ReadString("Server", "IDSAddr", "127.0.0.1");
                    IDSrvPort = Conf.ReadInteger("Server", "IDSPort", 5600);
                }
            }
            else
            {
                MessageBox.Show("配置文件" + M2Share.sConfigFileName + "未找到！！！");
            }
            m_SessionList = new List<TSessInfo>();
            M2Share.g_Config.boIDSocketConnected = false;
            IDSocket = new IClientScoket();
            IDSocket.OnConnected += new DSCClientOnConnectedHandler(IDSocketConnect);
            IDSocket.ReceivedDatagram += new DSCClientOnDataInHandler(IDSocketRead);
        }

        public void IDSocketConnect(object sender, DSCClientConnectedEventArgs e)
        {
            M2Share.g_Config.boIDSocketConnected = true;
            M2Share.MainOutMessage("登录服务器[" + IDSocket.Address + ":" + IDSocket.Port + "]连接成功...");
        }

        public void IDSocketDisconnect(object sender, DSCClientConnectedEventArgs e)
        {
            if (M2Share.g_Config.boIDSocketConnected)
            {
                ClearSession();
                M2Share.g_Config.boIDSocketConnected = false;
                M2Share.MainOutMessage("登录服务器[" + IDSocket.Address + ":" + IDSocket.Port + "]断开连接...");
            }
        }

        public void IDSocketRead(object sender, DSCClientDataInEventArgs e)
        {
            HUtil32.EnterCriticalSection(M2Share.g_Config.UserIDSection);
            try
            {
                M2Share.g_Config.sIDSocketRecvText = M2Share.g_Config.sIDSocketRecvText + e.Data.ToString(e.Data.Length);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.g_Config.UserIDSection);
            }
        }

        public void Initialize()
        {
            Timer1.Enabled = true;
            Connected();
        }

        public void Connected()
        {
            IDSocket.Address = IDSrvAddr;
            IDSocket.Port = IDSrvPort;
            IDSocket.Connect(IDSrvAddr, IDSrvPort);
        }

        private void SendSocket(string sSENDMSG)
        {
            byte[] data;
            if (IDSocket != null)
            {
                data = System.Text.Encoding.Default.GetBytes(sSENDMSG);
                IDSocket.Send(sSENDMSG.ToByte());
            }
        }

        /// <summary>
        /// 发送消息给LoginSrv.exe,删除人物
        /// </summary>
        /// <param name="sUserID"></param>
        /// <param name="nID"></param>
        public void SendHumanLogOutMsg(string sUserID, int nID)
        {
            SendSocket(string.Format("({0}/{1}/{2})", Common.SS_SOFTOUTSESSION, sUserID, nID));
        }

        public void SendLogonCostMsg(string sAccount, int nTime)
        {
            SendSocket(string.Format("({0}/{1}/{2})", Common.SS_LOGINCOST, sAccount, nTime));
        }

        /// <summary>
        /// 发送在线人数到DB
        /// </summary>
        /// <param name="nCount"></param>
        public void SendOnlineHumCountMsg(int nCount)
        {
            SendSocket(string.Format("({0}/{1}/{2}/{3})", Common.SS_SERVERINFO, M2Share.g_Config.sServerName, M2Share.nServerIndex, nCount));
        }

        public void Run()
        {
            string sSocketText = string.Empty;
            string sData = string.Empty;
            string sBody = string.Empty;
            string sCode = string.Empty;
            const string sExceptionMsg = "{异常} TFrmIdSoc::DecodeSocStr";
            HUtil32.EnterCriticalSection(M2Share.g_Config.UserIDSection);
            if (M2Share.g_Config.sIDSocketRecvText != "" && M2Share.g_Config.sIDSocketRecvText != null)
            {
                try
                {
                    if (M2Share.g_Config.sIDSocketRecvText.IndexOf(")") <= 0)
                    {
                        return;
                    }
                    sSocketText = M2Share.g_Config.sIDSocketRecvText;
                    M2Share.g_Config.sIDSocketRecvText = "";
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(M2Share.g_Config.UserIDSection);
                }
            }
            else
            {
                HUtil32.LeaveCriticalSection(M2Share.g_Config.UserIDSection);
            }
            try
            {
                while (true)
                {
                    sSocketText = HUtil32.ArrestStringEx(sSocketText, "(", ")", ref sData);
                    if (sData == "")
                    {
                        break;
                    }
                    sBody = HUtil32.GetValidStr3(sData, ref sCode, new string[] { "/" });
                    switch (HUtil32.Str_ToInt(sCode, 0))
                    {
                        case Common.SS_OPENSESSION:// 100
                            GetPasswdSuccess(sBody);
                            break;

                        case Common.SS_CLOSESESSION:// 101
                            GetCancelAdmission(sBody);
                            break;

                        case Common.SS_KEEPALIVE:// 104
                            SetTotalHumanCount(sBody);
                            break;

                        case Common.UNKNOWMSG:
                            break;

                        case Common.SS_KICKUSER:// 111
                            GetCancelAdmissionA(sBody);
                            break;

                        case Common.SS_SERVERLOAD:// 113
                            GetServerLoad(sBody);
                            break;
                    }
                    if (sSocketText.IndexOf(")") <= 0)
                    {
                        break;
                    }
                }
                HUtil32.EnterCriticalSection(M2Share.g_Config.UserIDSection);
                try
                {
                    M2Share.g_Config.sIDSocketRecvText = sSocketText + M2Share.g_Config.sIDSocketRecvText;
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(M2Share.g_Config.UserIDSection);
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            if (HUtil32.GetTickCount() - dwClearEmptySessionTick > 10000)
            {
                dwClearEmptySessionTick = HUtil32.GetTickCount();
            }
        }

        private void GetPasswdSuccess(string sData)
        {
            string sAccount = string.Empty;
            string sSessionID = string.Empty;
            string sPayCost = string.Empty;
            string sIPaddr = string.Empty;
            string sPayMode = string.Empty;
            const string sExceptionMsg = "{异常} TFrmIdSoc::GetPasswdSuccess";
            try
            {
                sData = HUtil32.GetValidStr3(sData, ref sAccount, new string[] { "/" });
                sData = HUtil32.GetValidStr3(sData, ref sSessionID, new string[] { "/" });
                sData = HUtil32.GetValidStr3(sData, ref sPayCost, new string[] { "/" });// boPayCost
                sData = HUtil32.GetValidStr3(sData, ref sPayMode, new string[] { "/" });// nPayMode
                sData = HUtil32.GetValidStr3(sData, ref sIPaddr, new string[] { "/" });// sIPaddr
                NewSession(sAccount, sIPaddr, HUtil32.Str_ToInt(sSessionID, 0), HUtil32.Str_ToInt(sPayCost, 0), HUtil32.Str_ToInt(sPayMode, 0));
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        private void GetCancelAdmission(string sData)
        {
            string SC = string.Empty;
            string sSessionID;
            const string sExceptionMsg = "{异常} TFrmIdSoc::GetCancelAdmission";
            try
            {
                sSessionID = HUtil32.GetValidStr3(sData, ref SC, new string[] { "/" });
                DelSession(HUtil32.Str_ToInt(sSessionID, 0));
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        private void NewSession(string sAccount, string sIPaddr, int nSessionID, int nPayMent, int nPayMode)
        {
            TSessInfo SessInfo;
            SessInfo = new TSessInfo();
            SessInfo.sAccount = sAccount;
            SessInfo.sIPaddr = sIPaddr;
            SessInfo.nSessionID = nSessionID;
            SessInfo.nPayMent = nPayMent;
            SessInfo.nPayMode = nPayMode;
            SessInfo.nSessionStatus = 0;
            SessInfo.dwStartTick = HUtil32.GetTickCount();
            SessInfo.dwActiveTick = HUtil32.GetTickCount();
            SessInfo.nRefCount = 1;

            //m_SessionList.__Lock();
            try
            {
                m_SessionList.Add(SessInfo);
            }
            finally
            {
                // m_SessionList.UnLock();
            }
        }

        private void DelSession(int nSessionID)
        {
            string sAccount = "";
            TSessInfo SessInfo;
            const string sExceptionMsg = "{异常} FrmIdSoc::DelSession %d";
            try
            {
                //m_SessionList.__Lock();
                try
                {
                    for (int I = m_SessionList.Count - 1; I >= 0; I--)
                    {
                        SessInfo = m_SessionList[I];
                        if (SessInfo.nSessionID == nSessionID)
                        {
                            sAccount = SessInfo.sAccount;
                            m_SessionList.RemoveAt(I);
                            break;
                        }
                    }
                }
                finally
                {
                    // m_SessionList.UnLock();
                }
                if (sAccount != "")
                {
                    M2Share.RunSocket.KickUser(sAccount, nSessionID);
                }
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, 0));
            }
        }

        private void ClearSession()
        {
            //m_SessionList.__Lock();
            try
            {
                for (int I = 0; I < m_SessionList.Count; I++)
                {
                    if (m_SessionList[I] != null)
                    {
                        //this.Dispose(((TSessInfo)(m_SessionList[I])));
                    }
                }
                m_SessionList.Clear();
            }
            finally
            {
                // m_SessionList.UnLock();
            }
        }

        public TSessInfo GetAdmission(string sAccount, string sIPaddr, int nSessionID, ref int nPayMode, ref int nPayMent)
        {
            TSessInfo result;
            TSessInfo SessInfo;
            bool boFound;
            const string sGetFailMsg = "[非法登录] 全局会话验证失败[{0}/{1}/{2}]";
            boFound = false;
            result = null;
            nPayMent = 0;
            nPayMode = 0;
            lock (m_SessionList)
            {
                try
                {
                    foreach (var item in m_SessionList)
                    {
                        SessInfo = item;
                        if ((SessInfo.nSessionID == nSessionID) && (SessInfo.sAccount == sAccount))
                        {
                            switch (SessInfo.nPayMent)
                            {
                                case 2:
                                    nPayMent = 3;
                                    break;

                                case 1:
                                    nPayMent = 2;
                                    break;

                                case 0:
                                    nPayMent = 1;
                                    break;
                            }
                            result = SessInfo;
                            nPayMode = SessInfo.nPayMode;
                            boFound = true;
                            break;
                        }
                    }
                }
                finally
                {
                }
            }
            if (M2Share.g_Config.boViewAdmissionFailure && !boFound)
            {
                M2Share.MainOutMessage(string.Format(sGetFailMsg, sAccount, sIPaddr, nSessionID));
            }
            return result;
        }

        private void SetTotalHumanCount(string sData)
        {
        }

        private void GetCancelAdmissionA(string sData)
        {
            int nSessionID;
            string sSessionID;
            string sAccount = string.Empty;
            const string sExceptionMsg = "{异常} FrmIdSoc::GetCancelAdmissionA";
            try
            {
                sSessionID = HUtil32.GetValidStr3(sData, ref sAccount, new string[] { "/" });
                nSessionID = HUtil32.Str_ToInt(sSessionID, 0);
                if (!M2Share.g_Config.boTestServer)
                {
                    M2Share.UserEngine.HumanExpire(sAccount);
                    DelSession(nSessionID);
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        private void GetServerLoad(string sData)
        {
            string SC = string.Empty;
            string s10 = string.Empty;
            string s14 = string.Empty;
            string s18 = string.Empty;
            string s1C = string.Empty;
            sData = HUtil32.GetValidStr3(sData, ref SC, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref s10, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref s14, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref s18, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref s1C, new string[] { "/" });
            M2Share.nCurrentMonthly = HUtil32.Str_ToInt(SC, 0);
            M2Share.nLastMonthlyTotalUsage = HUtil32.Str_ToInt(s10, 0);
            M2Share.nTotalTimeUsage = HUtil32.Str_ToInt(s14, 0);
            M2Share.nGrossTotalCnt = HUtil32.Str_ToInt(s18, 0);
            M2Share.nGrossResetCnt = HUtil32.Str_ToInt(s1C, 0);
        }

        public void GetSessionList(ArrayList List)
        {
            try
            {
                for (int I = 0; I < m_SessionList.Count; I++)
                {
                    List.Add(m_SessionList[I]);
                }
            }
            finally
            {
            }
        }
    }
}