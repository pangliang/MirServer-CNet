using System;
using System.Windows.Forms;


namespace DBServer
{
    public partial class TfrmTestSelGate : Form
    {
        public TfrmTestSelGate()
        {
            InitializeComponent();
        }

        public void ButtonTestClick(System.Object Sender, System.EventArgs _e1)
        {
            string sSelGateIPaddr;
            string sGameGateIPaddr;
            int nGameGatePort = 0;
            sSelGateIPaddr = EditSelGate.Text.Trim();
            sGameGateIPaddr = DBShare.GateRouteIP(sSelGateIPaddr, ref nGameGatePort);
            if (sGameGateIPaddr == "")
            {
                EditGameGate.Text = "无此网关设置";
                return;
            }
            EditGameGate.Text = string.Format("{0}:{1}", sGameGateIPaddr, nGameGatePort);
        }

        public void Button1Click(System.Object Sender, System.EventArgs _e1)
        {
            //RouteManage.Units.RouteManage.frmRouteManage.Open();
        }

    } // end TfrmTestSelGate

}
