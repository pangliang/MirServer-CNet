using System;
using System.Windows.Forms;
using GameFramework;
using M2Server.Base;

namespace M2Server
{
    public partial class TfrmConfigMerchant : Form
    {
        public static TfrmConfigMerchant frmConfigMerchant = null;
        public static TEnvirnoment SelEnvirnoment = null;
        private bool boOpened = false;
        private bool boModValued = false;

        public TfrmConfigMerchant()
        {
            InitializeComponent();
        }

        private void RefListViewSession()
        {
            int I;
            int n01;
            TMerchant Merchant = null;
            TNormNpc NormNpc = null;
            ListViewItem ListItem = null;
            PanelStatus.Text = "正在取得数据...";
            ListView.Visible = false;
            ListView.Items.Clear();
            n01 = 0;
            lock (M2Share.UserEngine.m_MerchantList)
            {
                try
                {
                    if (M2Share.UserEngine.m_MerchantList.Count > 0)
                    {
                        for (I = 0; I < M2Share.UserEngine.m_MerchantList.Count; I++)
                        {
                            Merchant = M2Share.UserEngine.m_MerchantList[I];
                            Merchant.ClearData();
                        }
                    }
                }
                finally { }

                try
                {
                    foreach (var item in M2Share.UserEngine.m_MerchantList)
                    {
                        Merchant = item;
                        if (Merchant.m_PEnvir != SelEnvirnoment)
                        {
                            continue;
                        }
                        n01++;
                        ListItem = new ListViewItem();
                        ListItem.Text = (n01).ToString();
                        ListItem.SubItems.Add(Merchant.m_sCharName);
                        ListItem.SubItems.Add((Merchant.m_nCurrX).ToString() + ':' + (Merchant.m_nCurrY).ToString());
                        ListItem.SubItems.Add("是");
                        ListItem.SubItems.Add("否");
                        ListItem.SubItems.Add(HUtil32.BooleanToStr(Merchant.m_boIsHide));
                        ListView.Items.Add(ListItem);
                    }
                }
                finally
                {

                }
                foreach (var item in M2Share.UserEngine.QuestNPCList)
                {
                    NormNpc = item;
                    if (NormNpc.m_PEnvir != SelEnvirnoment) //by John Add 只有管理类NPC才添加到列表
                    {
                        continue;
                    }
                    if (NormNpc.m_NpcType == TNpcType.n_Merchant)
                    {
                        continue;
                    }
                    n01++;
                    ListItem = new ListViewItem();
                    ListItem.Text = (n01).ToString();
                    ListItem.SubItems.Add(NormNpc.m_sCharName);
                    ListItem.SubItems.Add((NormNpc.m_nCurrX).ToString() + ':' + (NormNpc.m_nCurrY).ToString());
                    ListItem.SubItems.Add("否");
                    ListItem.SubItems.Add("是");
                    ListItem.SubItems.Add(HUtil32.BooleanToStr(NormNpc.m_boIsHide));
                    ListView.Items.Add(ListItem);
                }
            }
            this.Text = SelEnvirnoment.sMapDesc + " " + "NPC数:" + ListView.Items.Count;
            ListView.Visible = true;
            Dispose(ListItem);
            Dispose(Merchant);
            Dispose(NormNpc);
        }

        public void Open(TEnvirnoment Envir)
        {
            SelEnvirnoment = Envir;
            boOpened = false;
            RefListViewSession();
            boOpened = true;
            this.ShowDialog();
        }

        public void Dispose(object obj) {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }

        //public void PopupMenu_RefClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    RefListViewSession();
        //}
        public void PopupMenu_LoadClick(System.Object Sender, System.EventArgs _e1)
        {
            int I;
            ListViewItem ListItem;
            TMerchant Merchant;
            for (I = 0; I < ListView.Items.Count; I++)
            {
                ListItem = ListView.Items[I];
                if (ListItem.Selected)
                {
                    //Merchant = ((TMerchant)(ListItem.SubItems[0].Text));
                    try
                    {
                        //EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                        //if ((Merchant.m_sCharName).ToLower().CompareTo(("RobotManage").ToLower()) == 0)
                        //{
                        //    M2Share.RobotManage.RELOADROBOT();
                        //}
                        //if (Merchant.m_NpcType == Grobal2.TNpcType.n_Merchant)
                        //{
                        //    Merchant.ClearScript();
                        //    Merchant.LoadNpcScript();
                        //}
                        //else
                        //{
                        //    ((TNormNpc)(Merchant)).ClearScript();
                        //    ((TNormNpc)(Merchant)).LoadNpcScript();
                        //}
                    }
                    finally
                    {
                       // LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
                    }
                    if (ListItem.SubItems.Count >= 6)
                    {
                      //  ListItem.SubItems.Delete(ListItem.SubItems.Count - 1);
                    }
                    //ListItem.SubItems.Add(Merchant.m_sCharName + " 脚本加载完成...");
                }
            }
        }
        //public void PopupMenu_ClearClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    int I;
        //    ListViewItem ListItem;
        //    TMerchant Merchant;
        //    for (I = 0; I < ListView.Items.Count; I ++ )
        //    {
        //        ListItem = ListView.Items[I];
        //        if (ListItem.Selected)
        //        {
        //            
        //            Merchant = ((TMerchant)(ListItem.SubItems.Objects[0]));
        //            if (Merchant.m_NpcType == Grobal2.TNpcType.n_Merchant)
        //            {
        //                Merchant.ClearData();
        //                if (ListItem.SubItems.Count >= 6)
        //                {
        //                    
        //                    ListItem.SubItems.Delete(ListItem.SubItems.Count - 1);
        //                }
        //                ListItem.SubItems.Add(Merchant.m_sCharName + " 数据清除完成...");
        //            }
        //        }
        //    }
        //}
        //public void PopupMenu_OpenClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    ListViewItem ListItem;
        //    TMerchant Merchant;
        //    string sScriptFile;
        //    
        //    ListItem = ListView.Selected;
        //    if (ListItem != null)
        //    {
        //        
        //        Merchant = ((TMerchant)(ListItem.SubItems.Objects[0]));
        //        if (Merchant.m_NpcType == Grobal2.TNpcType.n_Merchant)
        //        {
        //            // 'Market_Def\'
        //            sScriptFile = M2Share.g_Config.sEnvirDir + Merchant.m_sPath + Merchant.m_sScript + '-' + Merchant.m_sMapName + ".txt";
        //        }
        //        else
        //        {
        //            if (Merchant.m_boIsQuest)
        //            {
        //                sScriptFile = M2Share.g_Config.sEnvirDir + Merchant.m_sPath + Merchant.m_sCharName + '-' + Merchant.m_sMapName + ".txt";
        //            }
        //            else
        //            {
        //                sScriptFile = M2Share.g_Config.sEnvirDir + Merchant.m_sPath + Merchant.m_sCharName + ".txt";
        //            }
        //        }
        //        
        //        
        //        WinExec(("Notepad.exe " + sScriptFile as string), SW_SHOW);
        //    }
        //}
        //public void ListViewClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    ListViewItem ListItem;
        //    TMerchant Merchant;
        //    
        //    ListItem = ListView.Selected;
        //    if (ListItem != null)
        //    {
        //        
        //        Merchant = ((TMerchant)(ListItem.SubItems.Objects[0]));
        //        PopupMenu_Clear.Enabled = Merchant.m_NpcType == Grobal2.TNpcType.n_Merchant;
        //    }
        //}
        //public void ListViewDblClick(System.Object Sender, System.EventArgs _e1)
        //{
        //    ListViewItem ListItem;
        //    TMerchant Merchant;
        //    string sScriptFile;
        //    
        //    ListItem = ListView.Selected;
        //    if (ListItem != null)
        //    {
        //        
        //        Merchant = ((TMerchant)(ListItem.SubItems.Objects[0]));
        //        if (Merchant.m_NpcType == Grobal2.TNpcType.n_Merchant)
        //        {
        //            // 'Market_Def\'
        //            sScriptFile = M2Share.g_Config.sEnvirDir + Merchant.m_sPath + Merchant.m_sScript + '-' + Merchant.m_sMapName + ".txt";
        //        }
        //        else
        //        {
        //            if (Merchant.m_boIsQuest)
        //            {
        //                sScriptFile = M2Share.g_Config.sEnvirDir + Merchant.m_sPath + Merchant.m_sCharName + '-' + Merchant.m_sMapName + ".txt";
        //            }
        //            else
        //            {
        //                sScriptFile = M2Share.g_Config.sEnvirDir + Merchant.m_sPath + Merchant.m_sCharName + ".txt";
        //            }
        //        }
        //        
        //        
        //        WinExec(("Notepad.exe " + sScriptFile as string), SW_SHOW);
        //    }
        //}
    }
}
