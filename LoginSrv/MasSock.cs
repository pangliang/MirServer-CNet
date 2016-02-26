using AsyncSockets.AsyncSocketServer;
using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TFrmMasSoc : Form
    {
        public List<TMsgServerInfo> m_ServerList = null;
        public static TFrmMasSoc FrmMasSoc = null;
        public static int nUserLimit = 0;
        public static TLimitServerUserInfo[] UserLimit = new TLimitServerUserInfo[LSShare.MAXGATEROUTE - 1 + 1];
        public AsyncServer MSocket = null;

        //主窗体
        private TFrmMain _FrmMain = null;

        public TFrmMain FrmMain
        {
            get { return _FrmMain; }
            set { _FrmMain = value; }
        }

        public TFrmMasSoc()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            TConfig Config;
            Config = LSShare.g_Config;
            m_ServerList = new List<TMsgServerInfo>();
            MSocket = new AsyncServer(200, Int16.MaxValue);
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(Config.sServerAddr), Config.nServerPort);
            MSocket.OnClientConnect += new EventHandler<AsyncSockets.AsyncUserToken>(MSocket_OnClientConnect);
            MSocket.OnClientDisconnect += new EventHandler<AsyncSockets.AsyncUserToken>(MSocket_OnClientDisconnect);
            MSocket.OnClientError += new EventHandler<AsyncSockets.AsyncSocketErrorEventArgs>(MSocket_OnClientError);
            MSocket.OnClientRead += new EventHandler<AsyncSockets.AsyncUserToken>(MSocket_OnClientRead);
            MSocket.Init();
            MSocket.Start(IpEnd);
            LoadServerAddr();
            LoadUserLimit();
        }

        public readonly object objRead = new object();

        private void MSocket_OnClientRead(object sender, AsyncSockets.AsyncUserToken e)
        {
            int I;
            TMsgServerInfo MsgServer;
            string sReviceMsg = string.Empty;
            string sMsg = string.Empty;
            string sCode = string.Empty;
            string sAccount = string.Empty;
            string sServerName = string.Empty;
            string sIndex = string.Empty;
            string sOnlineCount = string.Empty;
            int nCode;
            TConfig Config;
            Config = LSShare.g_Config;
            if (TFrmMain.Colsed) return;
            HUtil32.EnterCriticalSection(objRead);
            try
            {
                for (I = 0; I < m_ServerList.Count; I++)
                {
                    MsgServer = m_ServerList[I];
                    if (MsgServer.Socket == e)
                    {
                        //string ReceiveText = Encoding.Default.GetString(e.ReceiveBuffer, 0, e.BytesReceived);
                        //if (ReceiveText[0] == '\0') ReceiveText = "";
                        byte[] data = new byte[e.BytesReceived];
                        Array.Copy(e.ReceiveBuffer, e.Offset, data, 0, e.BytesReceived);
                        string ReceiveText = Encoding.Default.GetString(data);

                        sReviceMsg = MsgServer.sReceiveMsg + ReceiveText;
                        while ((sReviceMsg.IndexOf(')') > 0))
                        {
                            sReviceMsg = HUtil32.ArrestStringEx(sReviceMsg, "(", ")", ref sMsg);
                            if (sMsg == "")
                            {
                                break;
                            }
                            sMsg = HUtil32.GetValidStr3(sMsg, ref sCode, new string[] { "/" });
                            nCode = HUtil32.Str_ToInt(sCode, -1);
                            switch (nCode)
                            {
                                case Common.SS_SOFTOUTSESSION:
                                    sMsg = HUtil32.GetValidStr3(sMsg, ref sAccount, new string[] { "/" });
                                    FrmMain.CloseUser(Config, sAccount, HUtil32.Str_ToInt(sMsg, 0));
                                    break;

                                case Common.SS_SERVERINFO:
                                    sMsg = HUtil32.GetValidStr3(sMsg, ref sServerName, new string[] { "/" });
                                    sMsg = HUtil32.GetValidStr3(sMsg, ref sIndex, new string[] { "/" });
                                    sMsg = HUtil32.GetValidStr3(sMsg, ref sOnlineCount, new string[] { "/" });
                                    MsgServer.sServerName = sServerName;
                                    MsgServer.nServerIndex = HUtil32.Str_ToInt(sIndex, 0);
                                    MsgServer.nOnlineCount = HUtil32.Str_ToInt(sOnlineCount, 0);
                                    MsgServer.dwKeepAliveTick = HUtil32.GetTickCount();
                                    MsgServer.sIPaddr = e.EndPoint.Address.ToString() + ":" + e.EndPoint.Port.ToString();
                                    SortServerList(I);
                                    LSShare.nOnlineCountMin = GetOnlineHumCount();
                                    if (LSShare.nOnlineCountMin > LSShare.nOnlineCountMax)
                                    {
                                        LSShare.nOnlineCountMax = LSShare.nOnlineCountMin;
                                    }
                                    SendServerMsgA(Common.SS_KEEPALIVE, (LSShare.nOnlineCountMin).ToString());
                                    RefServerLimit(sServerName);
                                    break;

                                case Common.UNKNOWMSG:
                                    SendServerMsgA(Common.UNKNOWMSG, sMsg);
                                    break;

                                case Common.SS_ADDIPTOGATE:
                                    FrmMain.SendIPToGate(sMsg);
                                    break;
                            }
                        }
                    }

                    MsgServer.sReceiveMsg = sReviceMsg;

                    //MessageBox.Show(m_ServerList[I].sReceiveMsg);
                    //m_ServerList[I] = MsgServer;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(objRead);
            }
        }

        private void MSocket_OnClientError(object sender, AsyncSockets.AsyncSocketErrorEventArgs e)
        {
        }

        private void MSocket_OnClientDisconnect(object sender, AsyncSockets.AsyncUserToken e)
        {
            int I;
            TMsgServerInfo MsgServer;
            for (I = 0; I < m_ServerList.Count; I++)
            {
                MsgServer = m_ServerList[I];
                if (MsgServer.Socket == e)
                {
                    Dispose(m_ServerList[I]);
                    m_ServerList.RemoveAt(I);
                    break;
                }
            }
        }

        private void MSocket_OnClientConnect(object sender, AsyncSockets.AsyncUserToken e)
        {
            int I;
            string sRemoteAddr;
            bool boAllowed;
            TMsgServerInfo MsgServer;
            if (TFrmMain.Colsed) return;
            sRemoteAddr = e.EndPoint.Address.ToString();// Socket.RemoteAddress;
            boAllowed = false;
            for (I = LSShare.ServerAddr.GetLowerBound(0); I <= LSShare.ServerAddr.GetUpperBound(0); I++)
            {
                if (sRemoteAddr == LSShare.ServerAddr[I])
                {
                    boAllowed = true;
                    break;
                }
            }
            if (boAllowed)
            {
                MsgServer = new TMsgServerInfo();
                MsgServer.sServerName = "";
                MsgServer.sReceiveMsg = "";
                MsgServer.Socket = e;
                MsgServer.sIPaddr = e.EndPoint.Address.ToString() + ":" + e.EndPoint.Port;
                m_ServerList.Add(MsgServer);
            }
            else
            {
                LSShare.MainOutMessage("非法地址连接:" + sRemoteAddr);
                e.Socket.Close();
            }
        }

        private void RefServerLimit(string sServerName)
        {
            int I;
            int nCount;
            TMsgServerInfo MsgServer;
            try
            {
                nCount = 0;
                for (I = 0; I < m_ServerList.Count; I++)
                {
                    MsgServer = m_ServerList[I];
                    if ((MsgServer.nServerIndex != 99) && (MsgServer.sServerName == sServerName))
                    {
                        nCount += MsgServer.nOnlineCount;
                    }
                }
                for (I = UserLimit.GetLowerBound(0); I <= UserLimit.GetUpperBound(0); I++)
                {
                    if ((UserLimit[I].sServerName).ToLower().CompareTo((sServerName).ToLower()) == 0)
                    {
                        UserLimit[I].nLimitCountMin = nCount;
                        break;
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMasSoc.RefServerLimit");
            }
        }

        public bool IsNotUserFull(string sServerName)
        {
            bool result;
            int I;
            result = true;
            for (I = UserLimit.GetLowerBound(0); I <= UserLimit.GetUpperBound(0); I++)
            {
                if ((UserLimit[I].sServerName).ToLower().CompareTo((sServerName).ToLower()) == 0)
                {
                    if (UserLimit[I].nLimitCountMin > UserLimit[I].nLimitCountMax)
                    {
                        result = false;
                    }
                    break;
                }
            }
            return result;
        }

        private void SortServerList(int nIndex)
        {
            int nC;
            int n10;
            int n14;
            TMsgServerInfo MsgServerSort;
            TMsgServerInfo MsgServer;
            int nNewIndex;
            try
            {
                if (m_ServerList.Count <= nIndex)
                {
                    return;
                }
                MsgServerSort = m_ServerList[nIndex];
                m_ServerList.RemoveAt(nIndex);
                for (nC = 0; nC < m_ServerList.Count; nC++)
                {
                    MsgServer = m_ServerList[nC];
                    if (MsgServer.sServerName == MsgServerSort.sServerName)
                    {
                        if (MsgServer.nServerIndex < MsgServerSort.nServerIndex)
                        {
                            m_ServerList.Insert(nC, MsgServerSort);
                            return;
                        }
                        else
                        {
                            nNewIndex = nC + 1;
                            if (nNewIndex < m_ServerList.Count)
                            {
                                // Jacky 增加
                                for (n10 = nNewIndex; n10 < m_ServerList.Count; n10++)
                                {
                                    MsgServer = m_ServerList[n10];
                                    if (MsgServer.sServerName == MsgServerSort.sServerName)
                                    {
                                        if (MsgServer.nServerIndex < MsgServerSort.nServerIndex)
                                        {
                                            m_ServerList.Insert(n10, MsgServerSort);
                                            for (n14 = n10 + 1; n14 < m_ServerList.Count; n14++)
                                            {
                                                MsgServer = m_ServerList[n14];
                                                if ((MsgServer.sServerName == MsgServerSort.sServerName) && (MsgServer.nServerIndex == MsgServerSort.nServerIndex))
                                                {
                                                    m_ServerList.RemoveAt(n14);
                                                    return;
                                                }
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            nNewIndex = n10 + 1;
                                        }
                                    }
                                }
                                m_ServerList.Insert(nNewIndex, MsgServerSort);
                                return;
                            }
                        }
                    }
                }
                m_ServerList.Add(MsgServerSort);
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMasSoc.SortServerList");
            }
        }

        public void SendServerMsg(ushort wIdent, string sServerName, string sMsg)
        {
            int I;
            TMsgServerInfo MsgServer;
            string sSendMsg;
            string s18;
            const string sFormatMsg = "({0}/{1})";
            try
            {
                s18 = LimitName(sServerName);
                sSendMsg = string.Format(sFormatMsg, new string[] { wIdent.ToString(), sMsg });
                for (I = 0; I < m_ServerList.Count; I++)
                {
                    MsgServer = m_ServerList[I];
                    if (MsgServer.Socket.Socket.Connected)
                    {
                        if ((s18 == "") || (MsgServer.sServerName == "") || ((MsgServer.sServerName).ToLower().CompareTo((s18).ToLower()) == 0) || (MsgServer.nServerIndex == 99))
                        {
                            MsgServer.Socket.Socket.Send(Encoding.Default.GetBytes(sSendMsg));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                LSShare.MainOutMessage("TFrmMasSoc.SendServerMsg");
            }
        }

        public void LoadServerAddr()
        {
            string sFileName;
            TStringList LoadList;
            int I;
            int nServerIdx;
            string sLineText;
            sFileName = ".\\!ServerAddr.txt";
            nServerIdx = 0;
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText != "") && (sLineText[I] != ';'))
                    {
                        if (HUtil32.TagCount(sLineText, '.') == 3)
                        {
                            LSShare.ServerAddr[nServerIdx] = sLineText;
                            nServerIdx++;
                            if (nServerIdx >= LSShare.MAXGATEROUTE - 1)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public int GetOnlineHumCount()
        {
            int result = 0;
            int I;
            int nCount;
            TMsgServerInfo MsgServer;
            try
            {
                nCount = 0;
                for (I = 0; I < m_ServerList.Count; I++)
                {
                    MsgServer = m_ServerList[I];
                    if (MsgServer.nServerIndex != 99)
                    {
                        nCount += MsgServer.nOnlineCount;
                    }
                }
                result = nCount;
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMasSoc.GetOnlineHumCount");
            }
            return result;
        }

        public bool CheckReadyServers()
        {
            bool result;
            TConfig Config;
            Config = LSShare.g_Config;
            result = false;
            if (m_ServerList.Count >= Config.nReadyServers)
            {
                result = true;
            }
            return result;
        }

        public void SendServerMsgA(ushort wIdent, string sMsg)
        {
            int I;
            string sSendMsg;
            TMsgServerInfo MsgServer;
            const string sFormatMsg = "({0}/{1}/{2})";
            try
            {
                sSendMsg = string.Format(sFormatMsg, new string[] { wIdent.ToString(), sMsg, "游戏中心" });
                for (I = 0; I < m_ServerList.Count; I++)
                {
                    MsgServer = m_ServerList[I];
                    if (MsgServer.Socket.Socket.Connected)
                    {
                        MsgServer.Socket.Socket.Send(Encoding.Default.GetBytes(sSendMsg));
                    }
                }
            }
            catch (Exception e)
            {
                LSShare.MainOutMessage("TFrmMasSoc.SendServerMsgA");
                LSShare.MainOutMessage(e.Message);
            }
        }

        private string LimitName(string sServerName)
        {
            string result = string.Empty;
            int I;
            try
            {
                result = "";
                for (I = UserLimit.GetLowerBound(0); I <= UserLimit.GetUpperBound(0); I++)
                {
                    if ((UserLimit[I].sServerName).ToLower().CompareTo((sServerName).ToLower()) == 0)
                    {
                        result = UserLimit[I].sName;
                        break;
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMasSoc.LimitName");
            }
            return result;
        }

        public void LoadUserLimit()
        {
            TStringList LoadList;
            string sFileName = string.Empty;
            int I;
            int nC;
            string sLineText = string.Empty;
            string sServerName = string.Empty;
            string s10 = string.Empty;
            string s14 = string.Empty;
            nC = 0;
            sFileName = ".\\!UserLimit.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sServerName, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref s10, new string[] { " ", "\t" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref s14, new string[] { " ", "\t" });
                    if (sServerName != "")
                    {
                        UserLimit[nC].sServerName = sServerName;
                        UserLimit[nC].sName = s10;
                        UserLimit[nC].nLimitCountMax = HUtil32.Str_ToInt(s14, 3000);
                        UserLimit[nC].nLimitCountMin = 0;
                        nC++;
                    }
                }
                nUserLimit = nC;
            }
            else
            {
                MessageBox.Show("[Critical Failure] file not found. .\\!UserLimit.txt");
            }
        }

        public int ServerStatus(string sServerName)
        {
            int result = 0;
            int I;
            int nStatus = 0;
            TMsgServerInfo MsgServer;
            bool boServerOnLine;
            try
            {
                result = 0;
                boServerOnLine = false;
                for (I = 0; I < m_ServerList.Count; I++)
                {
                    MsgServer = m_ServerList[I];
                    if ((MsgServer.nServerIndex != 99) && (MsgServer.sServerName == sServerName))
                    {
                        boServerOnLine = true;
                    }
                }
                if (!boServerOnLine)
                {
                    return result;
                }
                for (I = UserLimit.GetLowerBound(0); I <= UserLimit.GetUpperBound(0); I++)
                {
                    if (UserLimit[I].sServerName == sServerName)
                    {
                        if (UserLimit[I].nLimitCountMin <= UserLimit[I].nLimitCountMax / 2)
                        {
                            nStatus = 1;

                            // 空闲
                            break;
                        }
                        if (UserLimit[I].nLimitCountMin <= UserLimit[I].nLimitCountMax - (UserLimit[I].nLimitCountMax / 5))
                        {
                            nStatus = 2;

                            // 良好
                            break;
                        }
                        if (UserLimit[I].nLimitCountMin < UserLimit[I].nLimitCountMax)
                        {
                            nStatus = 3;

                            // 繁忙
                            break;
                        }
                        if (UserLimit[I].nLimitCountMin >= UserLimit[I].nLimitCountMax)
                        {
                            nStatus = 4;

                            // 满员
                            break;
                        }
                    }
                }
                result = nStatus;
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMasSoc.ServerStatus");
            }
            return result;
        }

        private void TFrmMasSoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            MSocket.Shutdown();
        }

        protected void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    } // end TFrmMasSoc

    public class TMsgServerInfo
    {
        public string sReceiveMsg;
        public AsyncSockets.AsyncUserToken Socket;
        public string sServerName;

        // 0x08
        public int nServerIndex;

        // 0x0C
        public int nOnlineCount;

        // 0x10
        public uint dwKeepAliveTick;

        // 0x14
        public string sIPaddr;
    } // end TMsgServerInfo

    public struct TLimitServerUserInfo
    {
        public string sServerName;
        public string sName;
        public int nLimitCountMin;
        public int nLimitCountMax;
    } // end TLimitServerUserInfo
}