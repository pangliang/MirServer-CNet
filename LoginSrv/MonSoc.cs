using AsyncSockets.AsyncSocketServer;
using GameFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TFrmMonSoc : Form
    {
        public AsyncServer MonSocket = null;
        private System.Threading.Timer MonSocTimer = null;
        public TFrmMasSoc FrmMasSoc = null;
        private List<AsyncSockets.AsyncUserToken> ActiveConnections = null;

        public TFrmMonSoc()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            TConfig Config;
            Config = LSShare.g_Config;
            ActiveConnections = new List<AsyncSockets.AsyncUserToken>();
            MonSocket = new AsyncServer(200, Int16.MaxValue);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(Config.sMonAddr), Config.nMonPort);
            MonSocket.OnClientDisconnect += MonSocket_OnClientDisconnect;
            MonSocket.OnClientError += MonSocket_OnClientError;
            MonSocket.OnClientConnect += MonSocket_OnClientConnect;
            MonSocket.Init();
            MonSocket.Start(iep);
            MonSocTimer = new System.Threading.Timer(new System.Threading.TimerCallback(MonTimerTimer), null, 1000, 1000);
        }

        private void MonSocket_OnClientConnect(object sender, AsyncSockets.AsyncUserToken e)
        {
            ActiveConnections.Add(e);
        }

        private void MonSocket_OnClientDisconnect(object sender, AsyncSockets.AsyncUserToken e)
        {
            ActiveConnections.Remove(e);
        }

        private void MonSocket_OnClientError(object sender, AsyncSockets.AsyncSocketErrorEventArgs e)
        {
        }

        public void MonTimerTimer(object obj)
        {
            int I;
            int nC;
            TMsgServerInfo MsgServer;
            string sServerName;
            string sMsg;
            sMsg = "";
            nC = FrmMasSoc.m_ServerList.Count;
            for (I = 0; I < FrmMasSoc.m_ServerList.Count; I++)
            {
                MsgServer = FrmMasSoc.m_ServerList[I];
                sServerName = MsgServer.sServerName;
                if (sServerName != "")
                {
                    sMsg = sMsg + sServerName + '/' + (MsgServer.nServerIndex).ToString() + '/' + (MsgServer.nOnlineCount).ToString() + '/';
                    if ((HUtil32.GetTickCount() - MsgServer.dwKeepAliveTick) < 30000)
                    {
                        sMsg = sMsg + "Õý³£ ;";
                    }
                    else
                    {
                        sMsg = sMsg + "³¬Ê± ;";
                    }
                }
                else
                {
                    sMsg = "-/-/-/-;";
                }
            }

            foreach (AsyncSockets.AsyncUserToken e in ActiveConnections)
            {
                e.Socket.Send(Encoding.Default.GetBytes((nC).ToString() + ';' + sMsg));
            }
        }
    }
}