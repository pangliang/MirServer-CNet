using LoginSrv.Model;
using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TfrmGrobalSession : Form
    {
        public static TfrmGrobalSession frmGrobalSession = null;

        public TfrmGrobalSession()
        {
            InitializeComponent();
        }

        // TfrmGrobalSession
        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            //GridSession.Cells[0, 0] = "序号";
            //GridSession.Cells[1, 0] = "登录帐号";
            //GridSession.Cells[2, 0] = "登录地址";
            //GridSession.Cells[3, 0] = "服务器名";
            //GridSession.Cells[4, 0] = "会话ID";
            //GridSession.Cells[5, 0] = "是否充值";
        }

        public void Open()
        {
            RefGridSession();
            this.ShowDialog();
        }

        private void RefGridSession()
        {
            int I;
            TConnInfo ConnInfo;
            TConfig Config;
            Config = LSShare.g_Config;
            PanelStatus.Text = "正在取得数据...";
            GridSession.Visible = false;

            //GridSession.Cells[0, 1] = "";
            //GridSession.Cells[1, 1] = "";
            //GridSession.Cells[2, 1] = "";
            //GridSession.Cells[3, 1] = "";
            //GridSession.Cells[4, 1] = "";
            //GridSession.Cells[5, 1] = "";
            //Config.SessionList.__Lock();
            try
            {
                if (Config.SessionList.Count <= 0)
                {
                    //GridSession.RowCount = 2;
                    // GridSession.FixedRows = 1;
                }
                else
                {
                    //GridSession.RowCount = Config.SessionList.Count + 1;
                }
                for (I = 0; I < Config.SessionList.Count; I++)
                {
                    ConnInfo = Config.SessionList[I];

                    //GridSession.Cells[0, I + 1] = (I).ToString();
                    //GridSession.Cells[1, I + 1] = ConnInfo.sAccount;
                    //GridSession.Cells[2, I + 1] = ConnInfo.sIPaddr;
                    //GridSession.Cells[3, I + 1] = ConnInfo.sServerName;
                    //GridSession.Cells[4, I + 1] = (ConnInfo.nSessionID).ToString();
                    //GridSession.Cells[5, I + 1] = HUtil32.BoolToStr(ConnInfo.boPayCost);
                }
            }
            finally
            {
                //Config.SessionList.UnLock();
            }
            GridSession.Visible = true;
        }
    }
}