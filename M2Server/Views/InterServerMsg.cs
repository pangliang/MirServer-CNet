using NetFramework;
using NetFramework.AsyncSocketServer;
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TFrmSrvMsg : Form
    {
        private TServerMsgInfo[] SrvArray = new TServerMsgInfo[9];
        public IServerSocket MsgServer;

        public TFrmSrvMsg()
        {
            InitializeComponent();
        }

        public void StartMsgServer()
        {
            try
            {
                MsgServer = new IServerSocket(20, Int16.MaxValue);
                MsgServer.Init();
                MsgServer.Start(M2Share.g_Config.sMsgSrvAddr, M2Share.g_Config.nMsgSrvPort);
            }
            catch
            {
                M2Share.MainOutMessage("{“Ï≥£} TFrmSrvMsg::StartMsgServer");
            }
        }

        private void SendSocket(Socket Socket, string sMsg)
        {
            byte[] data;
            if (Socket.Connected)
            {
                data = System.Text.Encoding.Default.GetBytes("(" + sMsg + ")");
                Socket.Send(data);
            }
        }

        public void SendSocketMsg(string sMsg)
        {
            TServerMsgInfo ServerMsgInfo;
            for (int I = SrvArray.GetLowerBound(0); I <= SrvArray.GetUpperBound(0); I++)
            {
                ServerMsgInfo = SrvArray[I];
                if (ServerMsgInfo == null)
                {
                    continue;
                }
                if (ServerMsgInfo.Socket != null)
                {
                    SendSocket(ServerMsgInfo.Socket, sMsg);
                }
            }
        }

        public void SocketServer_SessionConnected(object sender, DSCClientConnectedEventArgs e)
        {
            TServerMsgInfo ServerMsgInfo;
            for (int I = SrvArray.GetLowerBound(0); I <= SrvArray.GetUpperBound(0); I++)
            {
                ServerMsgInfo = SrvArray[I];
                if (ServerMsgInfo.Socket == null)
                {
                    ServerMsgInfo.Socket = e.socket;
                    ServerMsgInfo.s2E0 = "";

                    //e.SessionBaseInfo.ID = I;
                    //Socket.nIndex = I;
                }
            }
        }

        public void SocketServer_SessionDisconnected(object sender, DSCClientConnectedEventArgs e)
        {
            TServerMsgInfo ServerMsgInfo;
            for (int I = SrvArray.GetLowerBound(0); I <= SrvArray.GetUpperBound(0); I++)
            {
                ServerMsgInfo = SrvArray[I];
                if (ServerMsgInfo.Socket == e.socket)
                {
                    ServerMsgInfo.Socket = null;
                    ServerMsgInfo.s2E0 = "";
                }
            }
        }

        public void SocketServer_DatagramReceived(object sender, DSCClientDataInEventArgs e)
        {
            //int nC = e.Client.ID.ID;
            //if (nC >= SrvArray.GetLowerBound(0))
            //{
            //    if ((nC <= SrvArray.GetUpperBound(0)) && (SrvArray[nC].Socket == e.Client.ClientSocket))
            //    {
            //        SrvArray[nC].s2E0 = SrvArray[nC].s2E0 + HUtil32.ByteAryToString(e.Client.Datagram, 0, e.Client.Datagram.Length);
            //    }
            //}
        }

        public void MsgServerClientError(object sender, DSCClientConnectedEventArgs e)
        {
            e.socket.Close();
        }
    }

    public class TServerMsgInfo
    {
        public TServerMsgInfo()
        {
            this.Socket = null;
            this.s2E0 = "";
        }

        public Socket Socket = null;
        public string s2E0;
    }
}