using GameFramework;
using NetFramework;
using NetFramework.AsyncSocketClient;
using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TFrmMsgClient : Form
    {
        public static TFrmMsgClient FrmMsgClient = null;
        public IClientScoket MsgClient;
        private uint dw2D4Tick = 0;
        private string sRecvMsg = String.Empty;

        public TFrmMsgClient()
        {
            InitializeComponent();
            MsgClient = new IClientScoket();
            MsgClient.ReceivedDatagram += new DSCClientOnDataInHandler(MsgClientRead);
            MsgClient.OnConnected += new DSCClientOnConnectedHandler(MsgClientConnect);
        }

        public void ConnectMsgServer()
        {
            MsgClient.Address = M2Share.g_Config.sMsgSrvAddr;
            MsgClient.Port = M2Share.g_Config.nMsgSrvPort;
            MsgClient.Connect(MsgClient.Address, MsgClient.Port);
            dw2D4Tick = HUtil32.GetTickCount();
        }

        public void Run()
        {
            if (MsgClient.IsConnected)
            {
                DecodeSocStr();
            }
            else
            {
                if (HUtil32.GetTickCount() - dw2D4Tick > 20000)// 20 * 1000
                {
                    dw2D4Tick = HUtil32.GetTickCount();
                }
            }
        }

        private void DecodeSocStr()
        {
            string sData;
            const string sExceptionMsg = "{“Ï≥£} FrmMsgClient::DecodeSocStr";
            try
            {
                if (sRecvMsg.IndexOf(")") <= 0)
                {
                    return;
                }
                sData = sRecvMsg;
                sRecvMsg = "";
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        public void SendSocket(string sMsg)
        {
            if (MsgClient.IsConnected)
            {
                MsgClient.Send(HUtil32.StrToByte("(" + sMsg + ")"));
            }
        }

        public void MsgClientConnect(object sender, DSCClientConnectedEventArgs e)
        {
            sRecvMsg = "";
        }

        public void MsgClientError(object sender, DSCClientDataInEventArgs e)
        {
            e.socket.Close();
        }

        public void MsgClientRead(object sender, DSCClientDataInEventArgs e)
        {
            sRecvMsg = sRecvMsg + HUtil32.ByteAryToString(e.Data, 0, e.Data.Length);
        }
    }
}