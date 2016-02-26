using System;
using System.Windows.Forms;
using System.Collections;
using GameFramework;

namespace M2Server
{
    public partial class TfrmSysManager : Form
    {
        public static TfrmSysManager frmSysManager = null;

        private System.Threading.Timer AutoTime = null;

        /// <summary>
        /// 是否正在刷新数据
        /// </summary>
        private bool IsRefLoadData = false;

        private ListViewItem ListItem;
        private TEnvirnoment Envirnoment;

        public TfrmSysManager()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void RefListViewSession()
        {
            if (!IsRefLoadData)
            {
                this.Text = "正在取得数据...";
                ListView.Items.Clear();
                IsRefLoadData = true;//正在刷新
                foreach (var item in M2Share.g_MapManager.m_MapList)
                {
                    Envirnoment = item;
                    ListItem = new ListViewItem();
                    ListItem.Text = Envirnoment.sMapName;
                    ListItem.SubItems.Add(Envirnoment.sMapDesc);
                    ListItem.SubItems.Add(Envirnoment.m_nHumCount.ToString());
                    ListItem.SubItems.Add(Envirnoment.MonCount.ToString());
                    ListItem.SubItems.Add(Envirnoment.m_nNpcCount.ToString());
                    ListItem.SubItems.Add(Envirnoment.m_nItemCount.ToString());
                    ListItem.SubItems.Add(HUtil32.BooleanToStr(Envirnoment.m_boRUNHUMAN));
                    ListItem.SubItems.Add(HUtil32.BooleanToStr(Envirnoment.m_boRUNMON));
                    ListView.Items.Add(ListItem);
                }
                IsRefLoadData = false;
                this.Text = "系统管理";
            }
            RefStatus();
        }

        public void RefStatus()
        {
            StatusBar.Panels.Clear();
            StatusBar.Panels.Add(new StatusBarPanel() { Text = "地图总数：" + (M2Share.g_MapManager.m_MapList.Count).ToString() });
            StatusBar.Panels.Add(new StatusBarPanel() { Text = "人物总数：" + (M2Share.g_MapManager.m_nHumCount).ToString() });
            StatusBar.Panels.Add(new StatusBarPanel() { Text = "怪物总数：" + (M2Share.g_MapManager.m_nMonCount).ToString() });
            StatusBar.Panels.Add(new StatusBarPanel() { Text = "NPC总数 ：" + (M2Share.g_MapManager.m_nNpcCount).ToString() });
            StatusBar.Panels.Add(new StatusBarPanel() { Text = "物品总数：" + (M2Share.g_MapManager.m_nItemCount).ToString() });
        }

        public void Open()
        {
            RefListViewSession();
            PopupMenu_AutoRef.Checked = true;
            if (PopupMenu_AutoRef.Checked)
            {
                AutoTime = new System.Threading.Timer(TimerTimer, null, 0, 5000);
            }
            this.ShowDialog();
        }

        public void PopupMenu_RefClick(System.Object Sender, System.EventArgs _e1)
        {
            RefListViewSession();
        }

        public void PopupMenu_ShowHumClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void PopupMenu_AutoRefClick(System.Object Sender, System.EventArgs _e1)
        {
            PopupMenu_AutoRef.Checked = !PopupMenu_AutoRef.Checked;
            if (!PopupMenu_AutoRef.Checked)
            {
                AutoTime.Dispose();
            }
            else
            {
                AutoTime = new System.Threading.Timer(TimerTimer, null, 0, 5000);
            }
        }

        public void TimerTimer(object obj)
        {
            if (!IsRefLoadData)
            {
                IsRefLoadData = true;
                foreach (ListViewItem item in ListView.Items)
                {
                    ListItem = item;
                    Envirnoment = M2Share.g_MapManager.FindMap((ListItem.SubItems[0].Text));
                    if (HUtil32.Str_ToInt(ListItem.SubItems[2].Text, 0) != Envirnoment.m_nHumCount)
                    {
                        ListItem.SubItems[2].Text = (Envirnoment.m_nHumCount).ToString();
                    }
                    if (HUtil32.Str_ToInt(ListItem.SubItems[3].Text, 0) != Envirnoment.m_nMonCount)
                    {
                        ListItem.SubItems[3].Text = (Envirnoment.m_nMonCount).ToString();
                    }
                    if (HUtil32.Str_ToInt(ListItem.SubItems[4].Text, 0) != Envirnoment.m_nNpcCount)
                    {
                        ListItem.SubItems[4].Text = (Envirnoment.m_nNpcCount).ToString();
                    }
                    if (HUtil32.Str_ToInt(ListItem.SubItems[5].Text, 0) != Envirnoment.m_nItemCount)
                    {
                        ListItem.SubItems[5].Text = (Envirnoment.m_nItemCount).ToString();
                    }
                    if (ListItem.SubItems[6].Text != HUtil32.BooleanToStr(Envirnoment.m_boRUNHUMAN))
                    {
                        ListItem.SubItems[6].Text = HUtil32.BooleanToStr(Envirnoment.m_boRUNHUMAN);
                    }
                    if (ListItem.SubItems[7].Text != HUtil32.BooleanToStr(Envirnoment.m_boRUNMON))
                    {
                        ListItem.SubItems[7].Text = HUtil32.BooleanToStr(Envirnoment.m_boRUNMON);
                    }
                }
                IsRefLoadData = false;
            }
            RefStatus();
        }

        public void PopupMenu_ShowMonClick(System.Object Sender, System.EventArgs _e1)
        {
            ListItem = ListView.SelectedItems[ListView.SelectedItems.Count - 1];
            if (ListItem != null)
            {
                Envirnoment = M2Share.g_MapManager.FindMap(ListItem.SubItems[0].Text);
                TfrmConfigMonGen frmConfigMonGen = new TfrmConfigMonGen();
                frmConfigMonGen.Top = this.Top + 20;
                frmConfigMonGen.Left = this.Left;
                frmConfigMonGen.Open(Envirnoment);
            }
        }

        public void PopupMenu_ShowNpcClick(System.Object Sender, System.EventArgs _e1)
        {
            ListItem = ListView.SelectedItems[ListView.SelectedItems.Count - 1];
            if (ListItem != null)
            {
                Envirnoment = M2Share.g_MapManager.FindMap(ListItem.SubItems[0].Text);
                TfrmConfigMerchant frmConfigMerchant = new TfrmConfigMerchant();
                frmConfigMerchant.Top = this.Top + 20;
                frmConfigMerchant.Left = this.Left;
                frmConfigMerchant.Open(Envirnoment);
            }
        }

        public void PopupMenu_ShowItemClick(System.Object Sender, System.EventArgs _e1)
        {
            ListItem = ListView.SelectedItems[ListView.SelectedItems.Count - 1];
            if (ListItem != null)
            {
                Envirnoment = M2Share.g_MapManager.FindMap(ListItem.SubItems[0].Text);
                //TfrmConfigItem frmConfigItem = new TfrmConfigItem();
                //frmConfigItem.Top = this.Top + 20;
                //frmConfigItem.Left = this.Left;
                //frmConfigItem.Open(Envirnoment);
            }
        }

        public void ListViewClick(System.Object Sender, System.EventArgs _e1)
        {
            ListItem = ListView.SelectedItems[ListView.SelectedItems.Count - 1];
            if (ListItem != null)
            {
                Envirnoment = M2Share.g_MapManager.FindMap(ListItem.SubItems[0].Text);
               // PopupMenu_MonGen.Checked = Envirnoment.m_boMonGen;
                PopupMenu_RunHum.Checked = Envirnoment.m_boRUNHUMAN;
                PopupMenu_RunMon.Checked = Envirnoment.m_boRUNMON;
               // PopupMenu_Horser.Checked = Envirnoment.m_boHorse;
            }
        }

        public void PopupMenu_MonGenClick(System.Object Sender, System.EventArgs _e1)
        {
            ListItem = ListView.SelectedItems[ListView.SelectedItems.Count - 1];
            if (ListItem != null)
            {
                Envirnoment = M2Share.g_MapManager.FindMap(ListItem.SubItems[0].Text);
                if (Sender == PopupMenu_MonGen)
                {
                    PopupMenu_MonGen.Checked = !PopupMenu_MonGen.Checked;
                   // Envirnoment.m_boMonGen = PopupMenu_MonGen.Checked;
                }
                else if (Sender == PopupMenu_RunHum)
                {
                    PopupMenu_RunHum.Checked = !PopupMenu_RunHum.Checked;
                    Envirnoment.m_boRUNHUMAN = PopupMenu_RunHum.Checked;
                }
                else if (Sender == PopupMenu_RunMon)
                {
                    PopupMenu_RunMon.Checked = !PopupMenu_RunMon.Checked;
                    Envirnoment.m_boRUNMON = PopupMenu_RunMon.Checked;
                }
                else if (Sender == PopupMenu_Horser)
                {
                    PopupMenu_Horser.Checked = !PopupMenu_Horser.Checked;
                    //Envirnoment.m_boHorse = PopupMenu_Horser.Checked;
                }
            }
        }

        public void PopupMenu_ClearMonClick(System.Object Sender, System.EventArgs _e1)
        {
            //int I;
            //TActorObject ActorObject;
            //ArrayList MonList;
            //ListItem = ListView.SelectedItems[ListView.SelectedItems.Count - 1];
            //if (ListItem != null)
            //{
            //    Envirnoment = M2Share.g_MapManager.FindMap(ListItem.SubItems[0].Text);
            //    if (Envirnoment != null)
            //    {
            //        MonList = new ArrayList();
            //        UserEngine.GetMapMonster(Envirnoment, MonList);
            //        for (I = 0; I < MonList.Count; I++)
            //        {
            //            ActorObject = ((TActorObject)(MonList[I]));
            //            if (ActorObject.m_Master != null)
            //            {
            //                continue;
            //            }
            //            if (M2Share.GetNoClearMonList(ActorObject.m_sCharName))
            //            {
            //                continue;
            //            }
            //            ActorObject.m_boNoItem = true;
            //            ActorObject.MakeGhost();
            //        }
            //    }
            //}
        }

        protected override void OnClosed(EventArgs e)
        {
            if (AutoTime != null)
            {
                AutoTime.Dispose();
            }
            base.OnClosed(e);
        }
    }
}