using System;
using System.Windows.Forms;
using DBServer;
using DBServer.Entity;
namespace RouteManage
{
    public partial class TfrmRouteManage : Form
    {
        TfrmRouteEdit frmRouteEdit = new TfrmRouteEdit();

        public TfrmRouteManage()
        {
            InitializeComponent();
        }

        // TfrmRouteManage
        public void Open()
        {
            RefShowRoute();
            this.ShowDialog();
        }

        private void RefShowRoute()
        {
            int i;
            int ii;
            ListViewItem ListItem;
            TRouteInfo RouteInfo;
            string sGameGate;
            ListViewRoute.Items.Clear();
            ButtonEdit.Enabled = false;
            ButtonDelete.Enabled = false;
            for (i = DBShare.g_RouteInfo.GetLowerBound(0); i <= DBShare.g_RouteInfo.GetUpperBound(0); i++)
            {
                RouteInfo = DBShare.g_RouteInfo[i];
                if (RouteInfo.nGateCount == 0)
                {
                    break;
                }
                sGameGate = "";
                ListItem = new ListViewItem();
                ListItem.Tag = RouteInfo;
                ListItem.Text = i.ToString();
                ListItem.SubItems.Add(RouteInfo.sSelGateIP);
                ListItem.SubItems.Add((RouteInfo.nGateCount).ToString());
                for (ii = 0; ii < RouteInfo.nGateCount; ii++)
                {
                    sGameGate = string.Format("{0} {1}:{2} ", sGameGate, RouteInfo.sGameGateIP[ii], RouteInfo.nGameGatePort[ii] );
                }
                ListItem.SubItems.Add(sGameGate);
                ListViewRoute.Items.Add(ListItem);
            }
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void ButtonDeleteClick(System.Object Sender, System.EventArgs _e1)
        {
            if (Sender == ButtonDelete)
            {
                ProcessListViewDelete();
            }
            else if (Sender == ListViewRoute)
            {
                ProcessListViewSelect();
            }
            else if (Sender == ButtonAddRoute)
            {
                ProcessAddRoute();
            }
            else if (Sender == ButtonEdit)
            {
                ProcessEditRoute();
            }
        }

        private void ProcessListViewSelect()
        {
            ListViewItem ListItem = ListViewRoute.SelectedItems.Count == 0 ? null : ListViewRoute.SelectedItems[0];
            if (ListItem == null)
            {
                return;
            }
            ButtonEdit.Enabled = true;
            ButtonDelete.Enabled = true;
        }

        private void ProcessListViewDelete()
        {
            int ii;
            TRouteInfo RouteInfo;
            ListViewItem ListItem = ListViewRoute.SelectedItems.Count == 0 ? null : ListViewRoute.SelectedItems[0];
            if (ListItem == null)
            {
                return;
            }
            RouteInfo =(TRouteInfo) ListItem.Tag;
            RouteInfo.nGateCount = 0;
            RouteInfo.sSelGateIP = "";
            for (ii = 0; ii <= RouteInfo.sGameGateIP.Count; ii++)
            {
                RouteInfo.sGameGateIP[ii] = "";
                RouteInfo.nGameGatePort[ii] = 0;
            }
            RefShowRoute();
        }

        private void ProcessAddRoute()
        {
            ListViewItem ListItem;
            TRouteInfo RouteInfo;
            int nNulIdx;
            TRouteInfo AddRoute;
            nNulIdx = ListViewRoute.Items.Count;
            if (nNulIdx >= 20)
            {
                MessageBox.Show("路由条数已经达到指定数量,不能再增加路由！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            RouteInfo = DBShare.g_RouteInfo[nNulIdx];
            frmRouteEdit.m_RouteInfo = RouteInfo;
            frmRouteEdit.Text = "增加网关路由";
            AddRoute = frmRouteEdit.Open();
            if (AddRoute.nGateCount >= 1)
            {
                RouteInfo = AddRoute;
            }
            RefShowRoute();
        }

        private void ProcessEditRoute()
        {
            TRouteInfo RouteInfo;
            TRouteInfo EditRoute;
            ListViewItem ListItem = ListViewRoute.SelectedItems.Count == 0 ? null : ListViewRoute.SelectedItems[0];
            if (ListItem == null)
            {
                return;
            }
            RouteInfo = (TRouteInfo)ListItem.Tag;
            frmRouteEdit.m_RouteInfo = RouteInfo;
            frmRouteEdit.Text = "增加网关路由";
            EditRoute = frmRouteEdit.Open();
            if (EditRoute.nGateCount >= 1)
            {
                RouteInfo = EditRoute;
            }
            RefShowRoute();
        }

    } // end TfrmRouteManage

}
