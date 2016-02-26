using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DBServer.Entity;
using GameFramework;
using NetFramework.AsyncSocketClient;

namespace DBServer
{
    public partial class TFrmIDSoc : Form
    {
        private List<TGlobaSessionInfo> GlobaSessionList = null;//全局回话列表
        private string m_sSockMsg = String.Empty;//消息列表
        public object m_Module = null;//模块
        public uint m_dwCheckServerTimeMin = 0;
        public uint m_dwCheckServerTimeMax = 0;
        public uint m_dwCheckRecviceTick = 0;
        public IClientScoket IDSocket = null;//客户端对象
        private TFrmMain frmMain = null;//主窗体
        private System.Threading.Timer ReConnectTimer = null;//重新连接时钟
        private System.Threading.Timer KeepAliveTimer = null;//心跳时钟

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frmMain"></param>
        public TFrmIDSoc(TFrmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~TFrmIDSoc()
        {
            GlobaSessionList.Clear();
            GlobaSessionList = null;
        }

        /// <summary>
        /// 窗器载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TFrmIDSoc_Load(object sender, EventArgs e)
        {
            IDSocket = new IClientScoket();
            IDSocket.OnConnected += IDSocket_OnConnected;
            IDSocket.OnDisconnected += IDSocket_OnDisconnected;
            IDSocket.OnError += IDSocket_OnError;
            IDSocket.ReceivedDatagram += IDSocket_ReceivedDatagram;

            GlobaSessionList = new List<TGlobaSessionInfo>();
            m_sSockMsg = "";
            m_Module = null;
            m_dwCheckServerTimeMin = HUtil32.GetTickCount();
            m_dwCheckServerTimeMax = 0;
            m_dwCheckRecviceTick = HUtil32.GetTickCount();

            ReConnectTimer = new System.Threading.Timer(ReConnectTimerTimer, null, -1, -1);
            KeepAliveTimer = new System.Threading.Timer(KeepAliveTimerTimer, null, -1, -1);
        }

        private void IDSocket_ReceivedDatagram(object sender, NetFramework.DSCClientDataInEventArgs e)
        {
            m_sSockMsg = m_sSockMsg + Encoding.Default.GetString(e.Data);
            if (m_sSockMsg.IndexOf(')') > 0)
            {
                ProcessSocketMsg();
            }
        }

        private void IDSocket_OnError(object sender, NetFramework.DSCClientErrorEventArgs e)
        {
            IDSocket.Disconnect();
        }

        private void IDSocket_OnConnected(object sender, NetFramework.DSCClientConnectedEventArgs e)
        {
            m_dwCheckServerTimeMin = HUtil32.GetTickCount();
            m_dwCheckServerTimeMax = 0;
            m_dwCheckRecviceTick = HUtil32.GetTickCount();
            string sRemoteAddress = e.socket.RemoteEndPoint.ToString();// e.EndPoint.ToString();
            //开启心跳包
            KeepAliveTimer.Change(0, 3000);
            TModuleInfo ModuleInfo = new TModuleInfo();
            ModuleInfo.Module = this;
            ModuleInfo.ModuleName = DBShare.g_sServerName;
            ModuleInfo.Address = string.Format("%{0}:%{1} → %{2}:%{3}", sRemoteAddress, e.socket.LocalEndPoint.AddressFamily.ToString(), sRemoteAddress, e.socket.RemoteEndPoint.AddressFamily.ToString());
            ModuleInfo.Buffer = "0/0";
            m_Module = DBShare.AddModule(ModuleInfo);
        }

        private void IDSocket_OnDisconnected(object sender, NetFramework.DSCClientConnectedEventArgs e)
        {
            m_Module = null;
            KeepAliveTimer.Dispose();
            DBShare.RemoveModule(this);
        }

        /// <summary>
        /// 重新连接时钟
        /// </summary>
        /// <param name="objState"></param>
        public void ReConnectTimerTimer(object objState)
        {
            if ((!IDSocket.IsConnected))
            {
                try
                {
                    //127.0.0.1 5600
                    IDSocket.Connect(DBShare.g_sIDServerAddr, DBShare.g_nIDServerPort);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 心跳时钟
        /// </summary>
        /// <param name="objState"></param>
        public void KeepAliveTimerTimer(object objState)
        {
            SendKeepAlivePacket();
        }

        /// <summary>
        /// 发送心跳包
        /// </summary>
        private void SendKeepAlivePacket()
        {
            if (IDSocket.IsConnected)
            {
                IDSocket.Send(Encoding.Default.GetBytes('(' + (Common.SS_SERVERINFO).ToString() + '/' + DBShare.g_sServerName + '/' + "99" + '/' + (frmMain.GetSelectCharCount()).ToString() + ')'));
            }
            // (103/翎风世界/0/0)
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        public void OpenConnect()
        {
            ReConnectTimer.Change(0, 30000);
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseConnect()
        {
            ReConnectTimer.Dispose();
            IDSocket.Disconnect();
            m_Module = null;
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        private void ProcessSocketMsg()
        {
            string sScoketText;
            string sData = string.Empty;
            string sCode = string.Empty;
            string sBody;
            int nIdent;
            int nC;
            nC = 0;
            sScoketText = m_sSockMsg;
            while ((sScoketText.IndexOf(')') > 0))
            {
                sScoketText = HUtil32.ArrestStringEx(sScoketText, "(", ")", ref sData);
                if (sData == string.Empty)
                {
                    break;
                }
                sBody = HUtil32.GetValidStr3(sData, ref sCode, new string[] { "/" });
                nIdent = HUtil32.Str_ToInt(sCode, 0);
                switch (nIdent)
                {
                    case Common.SS_OPENSESSION:// 100
                        ProcessAddSession(sBody);
                        break;
                    case Common.SS_CLOSESESSION:// 101
                        ProcessDelSession(sBody);
                        break;
                    case Common.SS_KEEPALIVE:// 104
                        ProcessGetOnlineCount(sBody);
                        break;
                    default:
                        if (nC > 0)
                        {
                            sScoketText = "";
                            break;
                        }
                        nC++;
                        break;
                }
            }
            m_sSockMsg = sScoketText;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="wIdent"></param>
        /// <param name="sMsg"></param>
        public void SendSocketMsg(ushort wIdent, string sMsg)
        {
            string sSendText = string.Format("(%{0}/%{1})", wIdent, sMsg);
            if (IDSocket.IsConnected)
            {
                IDSocket.Send(Encoding.Default.GetBytes(sSendText));
            }
        }

        /// <summary>
        /// 检查会话
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sIPaddr"></param>
        /// <param name="nSessionID"></param>
        /// <returns></returns>
        public bool CheckSession(string sAccount, string sIPaddr, int nSessionID)
        {
            bool result;
            int I;
            TGlobaSessionInfo GlobaSessionInfo = new TGlobaSessionInfo();
            result = false;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.sAccount == sAccount) && (GlobaSessionInfo.nSessionID == nSessionID))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 检查会话
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sIPaddr"></param>
        /// <param name="nSessionID"></param>
        /// <param name="boFoundSession"></param>
        /// <returns></returns>
        public bool CheckSessionLoadRcd(string sAccount, string sIPaddr, int nSessionID, ref bool boFoundSession)
        {
            bool result;
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            result = false;
            boFoundSession = false;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.sAccount == sAccount) && (GlobaSessionInfo.nSessionID == nSessionID))
                    {
                        boFoundSession = true;
                        if (!GlobaSessionInfo.boLoadRcd)
                        {
                            GlobaSessionInfo.boLoadRcd = true;
                            result = true;
                        }
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 检查回话载入英雄记录
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sIPaddr"></param>
        /// <param name="nSessionID"></param>
        /// <param name="boFoundSession"></param>
        /// <returns></returns>
        public bool CheckSessionHeroLoadRcd(string sAccount, string sIPaddr, int nSessionID, ref bool boFoundSession)
        {
            bool result;
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            result = false;
            boFoundSession = false;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.sAccount == sAccount) && (GlobaSessionInfo.nSessionID == nSessionID))
                    {
                        boFoundSession = true;
                        if (!GlobaSessionInfo.boHeroLoadRcd)
                        {
                            GlobaSessionInfo.boHeroLoadRcd = true;
                            result = true;
                        }
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 保存会话到记录
        /// </summary>
        /// <param name="sAccount"></param>
        /// <returns></returns>
        public bool SetSessionSaveRcd(string sAccount)
        {
            bool result;
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            result = false;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.sAccount == sAccount))
                    {
                        GlobaSessionInfo.boLoadRcd = false;
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 标记全局会话不在游戏中
        /// </summary>
        /// <param name="nSessionID"></param>
        public void SetGlobaSessionNoPlay(int nSessionID)
        {
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.nSessionID == nSessionID))
                    {
                        GlobaSessionInfo.boStartPlay = false;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 标记全局会话正在游戏中
        /// </summary>
        /// <param name="nSessionID"></param>
        public void SetGlobaSessionPlay(int nSessionID)
        {
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.nSessionID == nSessionID))
                    {
                        GlobaSessionInfo.boStartPlay = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 获取全局会话状态
        /// </summary>
        /// <param name="nSessionID"></param>
        /// <returns></returns>
        public bool GetGlobaSessionStatus(int nSessionID)
        {
            bool result;
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            result = false;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.nSessionID == nSessionID))
                    {
                        result = GlobaSessionInfo.boStartPlay;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 关闭会话
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="nSessionID"></param>
        public void CloseSession(string sAccount, int nSessionID)
        {
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.nSessionID == nSessionID))
                    {
                        if (GlobaSessionInfo.sAccount == sAccount)
                        {
                            GlobaSessionList.RemoveAt(I);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加会话
        /// </summary>
        /// <param name="sData"></param>
        private void ProcessAddSession(string sData)
        {
            string sAccount = string.Empty;
            string s10 = string.Empty;
            string s14 = string.Empty;
            string s18 = string.Empty;
            string sIPaddr = string.Empty;
            TGlobaSessionInfo GlobaSessionInfo;
            sData = HUtil32.GetValidStr3(sData, ref sAccount, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref s10, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref s14, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref s18, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData, ref sIPaddr, new string[] { "/" });
            GlobaSessionInfo = new TGlobaSessionInfo();
            GlobaSessionInfo.sAccount = sAccount;
            GlobaSessionInfo.sIPaddr = sIPaddr;
            GlobaSessionInfo.nSessionID = HUtil32.Str_ToInt(s10, 0);
            GlobaSessionInfo.n24 = HUtil32.Str_ToInt(s14, 0);
            GlobaSessionInfo.boStartPlay = false;
            GlobaSessionInfo.boLoadRcd = false;
            //GlobaSessionInfo.boHeroLoadRcd = false;
            GlobaSessionInfo.dwAddTick = HUtil32.GetTickCount();
            GlobaSessionInfo.dAddDate = DateTime.Now;
            //GlobaSessionInfo.boRandomCode = false;
            GlobaSessionList.Add(GlobaSessionInfo);
        }

        /// <summary>
        /// 删除会话
        /// </summary>
        /// <param name="sData"></param>
        private void ProcessDelSession(string sData)
        {
            string sAccount = string.Empty;
            int I;
            int nSessionID;
            TGlobaSessionInfo GlobaSessionInfo;
            sData = HUtil32.GetValidStr3(sData, ref sAccount, new string[] { "/" });
            nSessionID = HUtil32.Str_ToInt(sData, 0);
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.nSessionID == nSessionID) && (GlobaSessionInfo.sAccount == sAccount))
                    {
                        GlobaSessionList.RemoveAt(I);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 获得会话
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sIPaddr"></param>
        /// <returns></returns>
        public bool GetSession(string sAccount, string sIPaddr)
        {
            bool result;
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            result = false;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if (GlobaSessionInfo != null)
                {
                    if ((GlobaSessionInfo.sAccount == sAccount) && (GlobaSessionInfo.sIPaddr == sIPaddr))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取验证码成功
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sIPaddr"></param>
        /// <param name="nSessionID"></param>
        /// <returns></returns>
        public bool GetSessionRandomCodeOK(string sAccount, string sIPaddr, int nSessionID)
        {
            bool result;
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            result = false;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if ((GlobaSessionInfo.sAccount == sAccount) && (GlobaSessionInfo.nSessionID == nSessionID) && GlobaSessionInfo.boRandomCode)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 设置验证码成功
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sIPaddr"></param>
        /// <param name="nSessionID"></param>
        /// <param name="boOK"></param>
        public void SetSessionRandomCodeOK(string sAccount, string sIPaddr, int nSessionID, bool boOK)
        {
            int I;
            TGlobaSessionInfo GlobaSessionInfo;
            for (I = 0; I < GlobaSessionList.Count; I++)
            {
                GlobaSessionInfo = GlobaSessionList[I];
                if ((GlobaSessionInfo.sAccount == sAccount) && (GlobaSessionInfo.nSessionID == nSessionID))
                {
                    //GlobaSessionInfo.boRandomCode = boOK;
                    break;
                }
            }
        }

        /// <summary>
        /// 好像没什么用
        /// </summary>
        /// <param name="sData"></param>
        private void ProcessGetOnlineCount(string sData)
        {
            m_dwCheckServerTimeMin = HUtil32.GetTickCount() - m_dwCheckRecviceTick;
            if (m_dwCheckServerTimeMin > m_dwCheckServerTimeMax)
            {
                m_dwCheckServerTimeMax = m_dwCheckServerTimeMin;
            }
            m_dwCheckRecviceTick = HUtil32.GetTickCount();
            if (m_Module != null)
            {
                ((TModuleInfo)(m_Module)).Buffer = string.Format("%{0}/%{1}", m_dwCheckServerTimeMin, m_dwCheckServerTimeMax);
            }
        }
    } // end TFrmIDSoc
}