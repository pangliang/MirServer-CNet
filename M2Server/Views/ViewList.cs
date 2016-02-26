using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmViewList: Form
    {
        public static TfrmViewList frmViewList = null;
        private bool boOpened = false;
        private bool boModValued = false;
        public TfrmViewList()
        {
            InitializeComponent();
        }
//        private void ModValue()
//        {
//            boModValued = true;
//            ButtonEnableMakeSave.Enabled = true;
//            ButtonDisableMakeSave.Enabled = true;
//            ButtonDisableMoveMapSave.Enabled = true;
//            ButtonGameLogSave.Enabled = true;
//            ButtonDisableTakeOffSave.Enabled = true;
//            ButtonNoClearMonSave.Enabled = true;
//            ButtonSellOffSave.Enabled = true;
//            ButtonPickItemSave.Enabled = true;
//        }

//        private void uModValue()
//        {
//            boModValued = false;
//            ButtonEnableMakeSave.Enabled = false;
//            ButtonDisableMakeSave.Enabled = false;
//            ButtonDisableMoveMapSave.Enabled = false;
//            ButtonGameLogSave.Enabled = false;
//            ButtonDisableTakeOffSave.Enabled = false;
//            ButtonNoClearMonSave.Enabled = false;
//            ButtonSellOffSave.Enabled = false;
//            ButtonPickItemSave.Enabled = false;
//        }

        public void Open()
        {
            //            int I;
            //            TStdItem StdItem;
            //            TEnvirnoment Envir;
            //            boOpened = false;
            //            uModValue();
            //            ListBoxDisableMakeList.Items.Clear();
            //            ListBoxEnableMakeList.Items.Clear();
            //            ListBoxItemList.Items.Clear();
            //            ListBoxitemList1.Items.Clear();
            //            ListBoxitemList4.Items.Clear();
            //            ListBoxitemList5.Items.Clear();

            //            EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            //            try {
            //                // ListBoxitemList2.Items.AddObject(g_sHumanDieEvent, TObject(nil));
            //                // ListBoxitemList2.Items.AddObject(sSTRING_GOLDNAME, TObject(nil));
            //                // ListBoxitemList2.Items.AddObject(g_Config.sGameGoldName, TObject(nil));
            //                // ListBoxitemList2.Items.AddObject(g_Config.sGamePointName, TObject(nil));
            //                // ListBoxitemList2.Items.AddObject(g_Config.sGameDiaMond, TObject(nil)); //20071226 金刚石
            //                // ListBoxitemList2.Items.AddObject(g_Config.sGameGird, TObject(nil)); //20071226 灵符
            //                ListBoxitemList2.Items.Add(GameMsgDef.g_sHumanDieEvent);
            //                ListBoxitemList2.Items.Add(M2Share.sSTRING_GOLDNAME);
            //                ListBoxitemList2.Items.Add(M2Share.g_Config.sGameGoldName);
            //                ListBoxitemList2.Items.Add(M2Share.g_Config.sGamePointName);
            //                ListBoxitemList2.Items.Add(M2Share.g_Config.sGameDiaMond);
            //                // 金刚石
            //                ListBoxitemList2.Items.Add(M2Share.g_Config.sGameGird);
            //                // 灵符
            //                ListBoxitemList2.Items.Add(M2Share.g_Config.sGameGlory);
            //                // 荣誉值 20080809
            //                if (UserEngine.StdItemList.Count > 0)
            //                {
            //                    // 20080630
            //                    for (I = 0; I < UserEngine.StdItemList.Count; I ++ )
            //                    {
            //                        StdItem = UserEngine.StdItemList[I];
            //                        // ListBoxItemList.Items.AddObject(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), TObject(StdItem));
            //                        // ListBoxitemList1.Items.AddObject(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), TObject(StdItem));
            //                        // ListBoxitemList2.Items.AddObject(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), TObject(StdItem));
            //                        // ListBoxitemList3.Items.AddObject(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), TObject(I));
            //                        // ListBoxitemList4.Items.AddObject(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), TObject(I));
            //                        // ListBoxitemList5.Items.AddObject(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), TObject(I));
            //                        ListBoxItemList.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
            //                        // 20080731 修改
            //                        ListBoxitemList1.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
            //                        ListBoxitemList2.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
            //                        ListBoxitemList3.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
            //                        ListBoxitemList4.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
            //                        ListBoxitemList5.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
            //                    }
            //                }
            //            } finally {

            //                LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            //            }

            //            if (M2Share.g_MapManager.Count > 0)
            //            {
            //                // 20080630

            //                for (I = 0; I < M2Share.g_MapManager.Count; I ++ )
            //                {

            //                    Envir = ((TEnvirnoment)(M2Share.g_MapManager.Items[I]));
            //                    ListBoxMapList.Items.Add(Envir.sMapName);
            //                }
            //            }
            //            GameMsgDef.g_EnableMakeItemList.__Lock();
            //            try {
            //                if (GameMsgDef.g_EnableMakeItemList.Count > 0)
            //                {
            //                    // 20080630
            //                    for (I = 0; I < GameMsgDef.g_EnableMakeItemList.Count; I ++ )
            //                    {
            //                        ListBoxEnableMakeList.Items.Add(GameMsgDef.g_EnableMakeItemList[I]);
            //                    }
            //                }
            //            } finally {
            //                GameMsgDef.g_EnableMakeItemList.UnLock();
            //            }
            //            M2Share.g_DisableMakeItemList.__Lock();
            //            try {
            //                if (M2Share.g_DisableMakeItemList.Count > 0)
            //                {
            //                    // 20080630
            //                    for (I = 0; I < M2Share.g_DisableMakeItemList.Count; I ++ )
            //                    {
            //                        ListBoxDisableMakeList.Items.Add(M2Share.g_DisableMakeItemList[I]);
            //                    }
            //                }
            //            } finally {
            //                M2Share.g_DisableMakeItemList.UnLock();
            //            }
            //            GameMsgDef.g_GameLogItemNameList.__Lock();
            //            try {
            //                if (GameMsgDef.g_GameLogItemNameList.Count > 0)
            //                {
            //                    // 20080630
            //                    for (I = 0; I < GameMsgDef.g_GameLogItemNameList.Count; I ++ )
            //                    {
            //                        ListBoxGameLogList.Items.Add(GameMsgDef.g_GameLogItemNameList[I]);
            //                    }
            //                }
            //            } finally {
            //                GameMsgDef.g_GameLogItemNameList.UnLock();
            //            }
            //            GameMsgDef.g_DisableTakeOffList.__Lock();
            //            try {
            //                if (GameMsgDef.g_DisableTakeOffList.Count > 0)
            //                {
            //                    // 20080630
            //                    for (I = 0; I < GameMsgDef.g_DisableTakeOffList.Count; I ++ )
            //                    {



            //                        ListBoxDisableTakeOffList.Items.AddObject((((int)GameMsgDef.g_DisableTakeOffList.Values[I])).ToString() + "  " + GameMsgDef.g_DisableTakeOffList[I], GameMsgDef.g_DisableTakeOffList.Values[I]);
            //                    }
            //                }
            //            } finally {
            //                GameMsgDef.g_DisableTakeOffList.UnLock();
            //            }
            //            // g_AllowSellOffItemList.Lock;  //20080416 去掉拍卖功能
            //            // try
            //            // for I := 0 to g_AllowSellOffItemList.Count - 1 do begin
            //            // ListBoxSellOffList.Items.Add(g_AllowSellOffItemList.Strings[I]);
            //            // end;
            //            // finally
            //            // g_AllowSellOffItemList.UnLock;
            //            // end;
            //            // 加载禁止发信息名称列表
            //            M2Share.g_DisableSendMsgList.__Lock();
            //            try {
            //                if (M2Share.g_DisableSendMsgList.Count > 0)
            //                {
            //                    // 20080630
            //                    for (I = 0; I < M2Share.g_DisableSendMsgList.Count; I ++ )
            //                    {
            //                        ListBoxDisableSendMsg.Items.Add(M2Share.g_DisableSendMsgList[I]);
            //                    }
            //                }
            //            } finally {
            //                M2Share.g_DisableSendMsgList.UnLock();
            //            }
            //            if (GameMsgDef.g_AllowPickUpItemList != null)
            //            {
            //                ListBoxAllowPickUpItem.Items.Clear();
            //                GameMsgDef.g_AllowPickUpItemList.__Lock();
            //                try {
            //                    if (GameMsgDef.g_AllowPickUpItemList.Count > 0)
            //                    {
            //                        // 20080630
            //                        for (I = 0; I < GameMsgDef.g_AllowPickUpItemList.Count; I ++ )
            //                        {
            //                            // if g_AllowPickUpItemList.Strings[i][1]<> ';' then
            //                            ListBoxAllowPickUpItem.Items.Add(GameMsgDef.g_AllowPickUpItemList[I]);
            //                        }
            //                    }
            //                } finally {
            //                    GameMsgDef.g_AllowPickUpItemList.UnLock();
            //                }
            //            }
            //            GameMsgDef.g_DisableMoveMapList.__Lock();
            //            try {
            //                if (GameMsgDef.g_DisableMoveMapList.Count > 0)
            //                {
            //                    // 20080630
            //                    for (I = 0; I < GameMsgDef.g_DisableMoveMapList.Count; I ++ )
            //                    {
            //                        ListBoxDisableMoveMap.Items.Add(GameMsgDef.g_DisableMoveMapList[I]);
            //                    }
            //                }
            //            } finally {
            //                GameMsgDef.g_DisableMoveMapList.UnLock();
            //            }
            //            RefItemBindAccount();
            //            RefItemBindCharName();
            //            RefItemBindDieNoDropName();
            //            // 刷新人物装备死亡不爆列表 20081127
            //            RefItemBindIPaddr();
            //            RefMonDropLimit();
            //            RefAdminList();
            //            RefNoClearMonList();
            //            RefItemCustomNameList();
            //            RefMsgFilterList();
            //            boOpened = true;
            //            PageControlViewList.SelectedIndex = 0;
            //            this.ShowDialog();
        }

//        public void FormCreate(object sender, EventArgs e)
//        {
            
//            GridItemBindAccount.Cells[0, 0] = "物品名称";
            
//            GridItemBindAccount.Cells[1, 0] = "物品IDX";
            
//            GridItemBindAccount.Cells[2, 0] = "物品系列号";
            
//            GridItemBindAccount.Cells[3, 0] = "绑定帐号";
            
//            GridItemBindCharName.Cells[0, 0] = "物品名称";
            
//            GridItemBindCharName.Cells[1, 0] = "物品IDX";
            
//            GridItemBindCharName.Cells[2, 0] = "物品系列号";
            
//            GridItemBindCharName.Cells[3, 0] = "绑定人物";
            
//            GridItemBindIPaddr.Cells[0, 0] = "物品名称";
            
//            GridItemBindIPaddr.Cells[1, 0] = "物品IDX";
            
//            GridItemBindIPaddr.Cells[2, 0] = "物品系列号";
            
//            GridItemBindIPaddr.Cells[3, 0] = "绑定IP";
            
//            StringGridMonDropLimit.Cells[0, 0] = "物品名称";
            
//            StringGridMonDropLimit.Cells[1, 0] = "爆数量";
            
//            StringGridMonDropLimit.Cells[2, 0] = "限制数量";
            
//            StringGridMonDropLimit.Cells[3, 0] = "未爆数量";
            
//            GridItemNameList.Cells[0, 0] = "原始名称";
            
//            GridItemNameList.Cells[1, 0] = "物品编号";
            
//            GridItemNameList.Cells[2, 0] = "自定义名称";
            
//            GridITemBindDieName.Cells[0, 0] = "物品名称";
            
//            GridITemBindDieName.Cells[1, 0] = "物品IDX";
            
//            GridITemBindDieName.Cells[2, 0] = "绑定人物";
//            TabSheetMonDrop.Visible = true;
//            ButtonEnableMakeAdd.Enabled = false;
//            ButtonEnableMakeDelete.Enabled = false;
//            ButtonDisableMakeAdd.Enabled = false;
//            ButtonDisableMakeDelete.Enabled = false;
//            ButtonDisableMoveMapAdd.Enabled = false;
//            ButtonDisableMoveMapDelete.Enabled = false;
//            ButtonGameLogAdd.Enabled = false;
//            ButtonGameLogDel.Enabled = false;
//            ButtonNoClearMonAdd.Enabled = false;
//            ButtonDisableTakeOffDel.Enabled = false;
//            ButtonDisableTakeOffAdd.Enabled = false;
//            ButtonNoClearMonDel.Enabled = false;
//            ButtonSellOffAdd.Enabled = false;
//            ButtonSellOffDel.Enabled = false;
//            ButtonPickItemAdd.Enabled = false;
//            ButtonPickItemDel.Enabled = false;
//            EditAdminIPaddr.Visible = true;
//            LabelAdminIPaddr.Visible = true;
//            EditAdminIPaddr.Visible = false;
//            LabelAdminIPaddr.Visible = false;
//        }

//        public void ListBoxItemListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxItemList.SelectedIndex >= 0)
//            {
//                ButtonEnableMakeAdd.Enabled = true;
//            }
//        }

//        public void ListBoxEnableMakeListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxEnableMakeList.SelectedIndex >= 0)
//            {
//                ButtonEnableMakeDelete.Enabled = true;
//            }
//        }

//        public void ButtonEnableMakeAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxItemList.SelectedIndex >= 0)
//            {
//                if (ListBoxEnableMakeList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxEnableMakeList.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxEnableMakeList.Items.Strings[I] == ListBoxItemList.Items.Strings[ListBoxItemList.SelectedIndex])
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
//                ListBoxEnableMakeList.Items.Add(ListBoxItemList.Items.Strings[ListBoxItemList.SelectedIndex]);
//                ModValue();
//            }
//        }

//        public void ButtonEnableMakeAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxEnableMakeList.Items.Clear();
//            if (ListBoxItemList.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxItemList.Items.Count; I ++ )
//                {
                    
//                    ListBoxEnableMakeList.Items.Add(ListBoxItemList.Items.Strings[I]);
//                }
//            }
//            ModValue();
//        }

//        public void ButtonEnableMakeDeleteAllClick(object sender, EventArgs e)
//        {
//            ListBoxEnableMakeList.Items.Clear();
//            ButtonEnableMakeDelete.Enabled = false;
//            ModValue();
//        }

//        public void ButtonEnableMakeDeleteClick(object sender, EventArgs e)
//        {
//            if (ListBoxEnableMakeList.SelectedIndex >= 0)
//            {
                
//                ListBoxEnableMakeList.Items.Delete(ListBoxEnableMakeList.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxEnableMakeList.SelectedIndex < 0)
//            {
//                ButtonEnableMakeDelete.Enabled = false;
//            }
//        }

//        public void ButtonEnableMakeSaveClick(object sender, EventArgs e)
//        {
//            int I;
//            GameMsgDef.g_EnableMakeItemList.__Lock();
//            try {
//                GameMsgDef.g_EnableMakeItemList.Clear();
//                if (ListBoxEnableMakeList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxEnableMakeList.Items.Count; I ++ )
//                    {
                        
//                        GameMsgDef.g_EnableMakeItemList.Add(ListBoxEnableMakeList.Items.Strings[I]);
//                    }
//                }
//            } finally {
//                GameMsgDef.g_EnableMakeItemList.UnLock();
//            }
//            M2Share.SaveEnableMakeItem();
//            uModValue();
//        }

//        public void ListBoxitemList1Click(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxitemList1.SelectedIndex >= 0)
//            {
//                ButtonDisableMakeAdd.Enabled = true;
//            }
//        }

//        public void ListBoxDisableMakeListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxDisableMakeList.SelectedIndex >= 0)
//            {
//                ButtonDisableMakeDelete.Enabled = true;
//            }
//        }

//        public void ButtonDisableMakeAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxitemList1.SelectedIndex >= 0)
//            {
//                if (ListBoxDisableMakeList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableMakeList.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxDisableMakeList.Items.Strings[I] == ListBoxitemList1.Items.Strings[ListBoxitemList1.SelectedIndex])
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
//                ListBoxDisableMakeList.Items.Add(ListBoxitemList1.Items.Strings[ListBoxitemList1.SelectedIndex]);
//                ModValue();
//            }
//        }

//        public void ButtonDisableMakeDeleteClick(object sender, EventArgs e)
//        {
//            if (ListBoxDisableMakeList.SelectedIndex >= 0)
//            {
                
//                ListBoxDisableMakeList.Items.Delete(ListBoxDisableMakeList.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxDisableMakeList.SelectedIndex < 0)
//            {
//                ButtonDisableMakeDelete.Enabled = false;
//            }
//        }

//        public void ButtonDisableMakeAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxDisableMakeList.Items.Clear();
//            if (ListBoxitemList1.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxitemList1.Items.Count; I ++ )
//                {
                    
//                    ListBoxDisableMakeList.Items.Add(ListBoxitemList1.Items.Strings[I]);
//                }
//            }
//            ModValue();
//        }

//        public void ButtonDisableMakeDeleteAllClick(object sender, EventArgs e)
//        {
//            ListBoxDisableMakeList.Items.Clear();
//            ButtonDisableMakeDelete.Enabled = false;
//            ModValue();
//        }

//        public void ButtonDisableMakeSaveClick(object sender, EventArgs e)
//        {
//            int I;
//            M2Share.g_DisableMakeItemList.__Lock();
//            try {
//                M2Share.g_DisableMakeItemList.Clear();
//                if (ListBoxDisableMakeList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableMakeList.Items.Count; I ++ )
//                    {
                        
//                        M2Share.g_DisableMakeItemList.Add(ListBoxDisableMakeList.Items.Strings[I]);
//                    }
//                }
//            } finally {
//                M2Share.g_DisableMakeItemList.UnLock();
//            }
//            M2Share.SaveDisableMakeItem();
//            uModValue();
//        }

//        public void ButtonDisableMoveMapAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxMapList.SelectedIndex >= 0)
//            {
//                if (ListBoxDisableMoveMap.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableMoveMap.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxDisableMoveMap.Items.Strings[I] == ListBoxMapList.Items.Strings[ListBoxMapList.SelectedIndex])
//                        {
//                            System.Windows.Forms.MessageBox.Show("此地图已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
//                ListBoxDisableMoveMap.Items.Add(ListBoxMapList.Items.Strings[ListBoxMapList.SelectedIndex]);
//                ModValue();
//            }
//        }

//        public void ButtonDisableMoveMapDeleteClick(object sender, EventArgs e)
//        {
//            if (ListBoxDisableMoveMap.SelectedIndex >= 0)
//            {
                
//                ListBoxDisableMoveMap.Items.Delete(ListBoxDisableMoveMap.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxDisableMoveMap.SelectedIndex < 0)
//            {
//                ButtonDisableMoveMapDelete.Enabled = false;
//            }
//        }

//        public void ButtonDisableMoveMapAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxDisableMoveMap.Items.Clear();
//            if (ListBoxMapList.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxMapList.Items.Count; I ++ )
//                {
                    
//                    ListBoxDisableMoveMap.Items.Add(ListBoxMapList.Items.Strings[I]);
//                }
//            }
//            ModValue();
//        }

//        public void ButtonDisableMoveMapSaveClick(object sender, EventArgs e)
//        {
//            int I;
//            GameMsgDef.g_DisableMoveMapList.__Lock();
//            try {
//                GameMsgDef.g_DisableMoveMapList.Clear();
//                if (ListBoxDisableMoveMap.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableMoveMap.Items.Count; I ++ )
//                    {
                        
//                        GameMsgDef.g_DisableMoveMapList.Add(ListBoxDisableMoveMap.Items.Strings[I]);
//                    }
//                }
//            } finally {
//                GameMsgDef.g_DisableMoveMapList.UnLock();
//            }
//            M2Share.SaveDisableMoveMap();
//            uModValue();
//        }

//        public void ButtonDisableMoveMapDeleteAllClick(object sender, EventArgs e)
//        {
//            ListBoxDisableMoveMap.Items.Clear();
//            ButtonDisableMoveMapDelete.Enabled = false;
//            ModValue();
//        }

//        public void ListBoxMapListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxMapList.SelectedIndex >= 0)
//            {
//                ButtonDisableMoveMapAdd.Enabled = true;
//            }
//        }

//        public void ListBoxDisableMoveMapClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxDisableMoveMap.SelectedIndex >= 0)
//            {
//                ButtonDisableMoveMapDelete.Enabled = true;
//            }
//        }

//        private void RefMsgFilterList()
//        {
//        }

//        private void RefMonDropLimit()
//        {
//            int I;
//            TMonDrop MonDrop;
//            M2Share.g_MonDropLimitLIst.__Lock();
//            try {
                
//                StringGridMonDropLimit.RowCount = M2Share.g_MonDropLimitLIst.Count + 1;
                
//                if (StringGridMonDropLimit.RowCount > 1)
//                {
                    
//                    StringGridMonDropLimit.FixedRows = 1;
//                }
//                if (M2Share.g_MonDropLimitLIst.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_MonDropLimitLIst.Count; I ++ )
//                    {
                        
//                        MonDrop = ((TMonDrop)(M2Share.g_MonDropLimitLIst.Values[I]));
                        
//                        StringGridMonDropLimit.Cells[0, I + 1] = MonDrop.sItemName;
                        
//                        StringGridMonDropLimit.Cells[1, I + 1] = (MonDrop.nDropCount).ToString();
                        
//                        StringGridMonDropLimit.Cells[2, I + 1] = (MonDrop.nCountLimit).ToString();
                        
//                        StringGridMonDropLimit.Cells[3, I + 1] = (MonDrop.nNoDropCount).ToString();
//                    }
//                }
//            } finally {
//                M2Share.g_MonDropLimitLIst.UnLock();
//            }
//        }

//        public void ButtonMonDropLimitRefClick(object sender, EventArgs e)
//        {
//            RefMonDropLimit();
//        }

//        public void StringGridMonDropLimitClick(object sender, EventArgs e)
//        {
//            int nItemIndex;
//            TMonDrop MonDrop;
//            nItemIndex = StringGridMonDropLimit.CurrentRowIndex - 1;
//            if (nItemIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_MonDropLimitLIst.__Lock();
//            try {
//                if (nItemIndex >= M2Share.g_MonDropLimitLIst.Count)
//                {
//                    return;
//                }
                
//                MonDrop = ((TMonDrop)(M2Share.g_MonDropLimitLIst.Values[nItemIndex]));
//                EditItemName.Text = MonDrop.sItemName;
//                EditDropCount.Value = MonDrop.nDropCount;
//                EditCountLimit.Value = MonDrop.nCountLimit;
//                EditNoDropCount.Value = MonDrop.nNoDropCount;
//            } finally {
//                M2Share.g_MonDropLimitLIst.UnLock();
//            }
//        }

//        public void EditDropCountChange(Object Sender)
//        {
//            if (EditDropCount.Text == "")
//            {
//                EditDropCount.Text = "0";
//                return;
//            }
//        }

//        public void EditCountLimitChange(Object Sender)
//        {
//            if (EditCountLimit.Text == "")
//            {
//                EditCountLimit.Text = "0";
//                return;
//            }
//        }

//        public void EditNoDropCountChange(Object Sender)
//        {
//            if (EditNoDropCount.Text == "")
//            {
//                EditNoDropCount.Text = "0";
//                return;
//            }
//        }

//        public void ButtonMonDropLimitSaveClick(object sender, EventArgs e)
//        {
//            string sItemName;
//            int nNoDropCount;
//            int nDropCount;
//            int nDropLimit;
//            int nSelIndex;
//            TMonDrop MonDrop;
//            sItemName = EditItemName.Text.Trim();
//            nDropCount = EditDropCount.Value;
//            nDropLimit = EditCountLimit.Value;
//            nNoDropCount = EditNoDropCount.Value;
//            nSelIndex = StringGridMonDropLimit.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_MonDropLimitLIst.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_MonDropLimitLIst.Count)
//                {
//                    return;
//                }
                
//                MonDrop = ((TMonDrop)(M2Share.g_MonDropLimitLIst.Values[nSelIndex]));
//                MonDrop.sItemName = sItemName;
//                MonDrop.nDropCount = nDropCount;
//                MonDrop.nNoDropCount = nNoDropCount;
//                MonDrop.nCountLimit = nDropLimit;
//            } finally {
//                M2Share.g_MonDropLimitLIst.UnLock();
//            }
//            M2Share.SaveMonDropLimitList();
//            RefMonDropLimit();
//        }

//        public void ButtonMonDropLimitAddClick(object sender, EventArgs e)
//        {
//            int I;
//            string sItemName;
//            int nNoDropCount;
//            int nDropCount;
//            int nDropLimit;
//            TMonDrop MonDrop;
//            sItemName = EditItemName.Text.Trim();
//            nDropCount = EditDropCount.Value;
//            nDropLimit = EditCountLimit.Value;
//            nNoDropCount = EditNoDropCount.Value;
//            M2Share.g_MonDropLimitLIst.__Lock();
//            try {
//                if (M2Share.g_MonDropLimitLIst.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_MonDropLimitLIst.Count; I ++ )
//                    {
                        
//                        MonDrop = ((TMonDrop)(M2Share.g_MonDropLimitLIst.Values[I]));
//                        if ((MonDrop.sItemName).ToLower().CompareTo((sItemName).ToLower()) == 0)
//                        {
//                            System.Windows.Forms.MessageBox.Show("输入的物品名已经在列表中！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
//                MonDrop = new TMonDrop();
//                MonDrop.sItemName = sItemName;
//                MonDrop.nDropCount = nDropCount;
//                MonDrop.nNoDropCount = nNoDropCount;
//                MonDrop.nCountLimit = nDropLimit;
//                M2Share.g_MonDropLimitLIst.Add(sItemName, ((MonDrop) as Object));
//            } finally {
//                M2Share.g_MonDropLimitLIst.UnLock();
//            }
//            M2Share.SaveMonDropLimitList();
//            RefMonDropLimit();
//        }

//        public void ButtonMonDropLimitDelClick(object sender, EventArgs e)
//        {
//            int nSelIndex;
//            TMonDrop MonDrop;
//            nSelIndex = StringGridMonDropLimit.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_MonDropLimitLIst.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_MonDropLimitLIst.Count)
//                {
//                    return;
//                }
                
//                MonDrop = ((TMonDrop)(M2Share.g_MonDropLimitLIst.Values[nSelIndex]));
//                this.Dispose(MonDrop);
//                M2Share.g_MonDropLimitLIst.Remove(nSelIndex);
//            } finally {
//                M2Share.g_MonDropLimitLIst.UnLock();
//            }
//            M2Share.SaveMonDropLimitList();
//            RefMonDropLimit();
//        }

//        public void ListBoxGameLogListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxGameLogList.SelectedIndex >= 0)
//            {
//                ButtonGameLogDel.Enabled = true;
//            }
//        }

//        public void ListBoxitemList2Click(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxitemList2.SelectedIndex >= 0)
//            {
//                ButtonGameLogAdd.Enabled = true;
//            }
//        }

//        public void ButtonGameLogAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxitemList2.SelectedIndex >= 0)
//            {
//                if (ListBoxGameLogList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxGameLogList.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxGameLogList.Items.Strings[I] == ListBoxitemList2.Items.Strings[ListBoxitemList2.SelectedIndex])
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
//                ListBoxGameLogList.Items.Add(ListBoxitemList2.Items.Strings[ListBoxitemList2.SelectedIndex]);
//                ModValue();
//            }
//        }

//        public void ButtonGameLogDelClick(object sender, EventArgs e)
//        {
//            if (ListBoxGameLogList.SelectedIndex >= 0)
//            {
                
//                ListBoxGameLogList.Items.Delete(ListBoxGameLogList.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxGameLogList.SelectedIndex < 0)
//            {
//                ButtonGameLogDel.Enabled = false;
//            }
//        }

//        public void ButtonGameLogAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxGameLogList.Items.Clear();
//            if (ListBoxitemList2.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxitemList2.Items.Count; I ++ )
//                {
                    
//                    ListBoxGameLogList.Items.Add(ListBoxitemList2.Items.Strings[I]);
//                }
//            }
//            ModValue();
//        }

//        public void ButtonGameLogDelAllClick(object sender, EventArgs e)
//        {
//            ListBoxGameLogList.Items.Clear();
//            ButtonGameLogDel.Enabled = false;
//            ModValue();
//        }

//        public void ButtonGameLogSaveClick(object sender, EventArgs e)
//        {
//            int I;
//            GameMsgDef.g_GameLogItemNameList.__Lock();
//            try {
//                GameMsgDef.g_GameLogItemNameList.Clear();
//                if (ListBoxGameLogList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxGameLogList.Items.Count; I ++ )
//                    {
                        
//                        GameMsgDef.g_GameLogItemNameList.Add(ListBoxGameLogList.Items.Strings[I]);
//                    }
//                }
//            } finally {
//                GameMsgDef.g_GameLogItemNameList.UnLock();
//            }
//            uModValue();
//#if SoftVersion <> VERDEMO
//            M2Share.SaveGameLogItemNameList();
//#endif
//            if (System.Windows.Forms.MessageBox.Show("此设置必须重新加载物品数据库才能生效，是否重新加载？", "确认信息", System.Windows.Forms.MessageBoxButtons.YesNo + System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
//            {
//                LocalDB.Units.LocalDB.FrmDB.LoadItemsDB();
//            }
//        }

//        public void ButtonDisableTakeOffAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxitemList3.SelectedIndex >= 0)
//            {
//                if (ListBoxDisableTakeOffList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableTakeOffList.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxDisableTakeOffList.Items.Strings[I] == ((ListBoxitemList3.SelectedIndex).ToString() + "  " + ListBoxitemList3.Items.Strings[ListBoxitemList3.SelectedIndex]))
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
                
//                ListBoxDisableTakeOffList.Items.AddObject((ListBoxitemList3.SelectedIndex).ToString() + "  " + ListBoxitemList3.Items.Strings[ListBoxitemList3.SelectedIndex], ((ListBoxitemList3.SelectedIndex) as Object));
//                ModValue();
//            }
//        }

//        public void ButtonDisableTakeOffDelClick(object sender, EventArgs e)
//        {
//            if (ListBoxDisableTakeOffList.SelectedIndex >= 0)
//            {
                
//                ListBoxDisableTakeOffList.Items.Delete(ListBoxDisableTakeOffList.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxDisableTakeOffList.SelectedIndex < 0)
//            {
//                ButtonDisableTakeOffDel.Enabled = false;
//            }
//        }

//        public void ListBoxDisableTakeOffListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxDisableTakeOffList.SelectedIndex >= 0)
//            {
//                ButtonDisableTakeOffDel.Enabled = true;
//            }
//        }

//        public void ListBoxitemList3Click(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxitemList3.SelectedIndex >= 0)
//            {
//                ButtonDisableTakeOffAdd.Enabled = true;
//            }
//        }

//        public void ButtonDisableTakeOffAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxDisableTakeOffList.Items.Clear();
//            if (ListBoxitemList3.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxitemList3.Items.Count; I ++ )
//                {
                    
                    
//                    ListBoxDisableTakeOffList.Items.AddObject((I).ToString() + "  " + ListBoxitemList3.Items.Strings[I], ((I) as Object));
//                }
//            }
//            ModValue();
//        }

//        public void ButtonDisableTakeOffDelAllClick(object sender, EventArgs e)
//        {
//            ListBoxDisableTakeOffList.Items.Clear();
//            ButtonDisableTakeOffDel.Enabled = false;
//            ModValue();
//        }

//        public void ButtonDisableTakeOffSaveClick(object sender, EventArgs e)
//        {
//            int I;
//            string sItemIdx;
//            GameMsgDef.g_DisableTakeOffList.__Lock();
//            try {
//                GameMsgDef.g_DisableTakeOffList.Clear();
//                if (ListBoxDisableTakeOffList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableTakeOffList.Items.Count; I ++ )
//                    {
                        
                        
//                        GameMsgDef.g_DisableTakeOffList.Add(HUtil32.GetValidStr3(ListBoxDisableTakeOffList.Items.Strings[I], ref sItemIdx, new string[] {" ", "/", ",", "\09"}).Trim(), ListBoxDisableTakeOffList.Items.Objects[I]);
//                    }
//                }
//            } finally {
//                GameMsgDef.g_DisableTakeOffList.UnLock();
//            }
//            M2Share.SaveDisableTakeOffList();
//            uModValue();
//        }

//        private void RefAdminList()
//        {
//            int I;
//            TAdminInfo AdminInfo;
            
//            ListBoxAdminList.Clear;
//            EditAdminName.Text = "";
//            EditAdminIPaddr.Text = "";
//            EditAdminPremission.Value = 0;
//            ButtonAdminListChange.Enabled = false;
//            ButtonAdminListDel.Enabled = false;
//            UserEngine.m_AdminList.__Lock();
//            try {
//                if (UserEngine.m_AdminList.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < UserEngine.m_AdminList.Count; I ++ )
//                    {
//                        AdminInfo = ((TAdminInfo)(UserEngine.m_AdminList[I]));
//                        ListBoxAdminList.Items.Add(AdminInfo.sChrName + " - " + (AdminInfo.nLv).ToString() + " - " + AdminInfo.sIPaddr);
//                    }
//                }
//            } finally {
//                UserEngine.m_AdminList.UnLock();
//            }
//        }

//        private void RefNoClearMonList()
//        {
//            TMonInfo MonInfo;
//            int I;
            
//            EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
//            try {
//                if (UserEngine.MonsterList.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < UserEngine.MonsterList.Count; I ++ )
//                    {
//                        MonInfo = UserEngine.MonsterList[I];
//                        // ListBoxMonList.Items.AddObject(MonInfo.sName, TObject(MonInfo));
//                        ListBoxMonList.Items.Add(MonInfo.sName);
//                    // 20080731 修改
//                    }
//                }
//            } finally {
                
//                LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
//            }
//            GameMsgDef.g_NoClearMonList.__Lock();
//            try {
//                if (GameMsgDef.g_NoClearMonList.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < GameMsgDef.g_NoClearMonList.Count; I ++ )
//                    {
//                        ListBoxNoClearMonList.Items.Add(GameMsgDef.g_NoClearMonList[I]);
//                    }
//                }
//            } finally {
//                GameMsgDef.g_NoClearMonList.UnLock();
//            }
//        }

//        public void ButtonNoClearMonAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxMonList.SelectedIndex >= 0)
//            {
//                if (ListBoxNoClearMonList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxNoClearMonList.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxNoClearMonList.Items.Strings[I] == ListBoxMonList.Items.Strings[ListBoxMonList.SelectedIndex])
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
//                ListBoxNoClearMonList.Items.Add(ListBoxMonList.Items.Strings[ListBoxMonList.SelectedIndex]);
//                ModValue();
//            }
//        }

//        public void ButtonNoClearMonDelClick(object sender, EventArgs e)
//        {
//            if (ListBoxNoClearMonList.SelectedIndex >= 0)
//            {
                
//                ListBoxNoClearMonList.Items.Delete(ListBoxNoClearMonList.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxNoClearMonList.SelectedIndex < 0)
//            {
//                ButtonNoClearMonDel.Enabled = false;
//            }
//        }

//        public void ButtonNoClearMonAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxNoClearMonList.Items.Clear();
//            if (ListBoxMonList.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxMonList.Items.Count; I ++ )
//                {
                    
//                    ListBoxNoClearMonList.Items.Add(ListBoxMonList.Items.Strings[I]);
//                }
//            }
//            ModValue();
//        }

//        public void ButtonNoClearMonDelAllClick(object sender, EventArgs e)
//        {
//            ListBoxNoClearMonList.Items.Clear();
//            ButtonNoClearMonDel.Enabled = false;
//            ModValue();
//        }

//        public void ButtonNoClearMonSaveClick(object sender, EventArgs e)
//        {
//            int I;
//            GameMsgDef.g_NoClearMonList.__Lock();
//            try {
//                GameMsgDef.g_NoClearMonList.Clear();
//                if (ListBoxNoClearMonList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxNoClearMonList.Items.Count; I ++ )
//                    {
                        
//                        GameMsgDef.g_NoClearMonList.Add(ListBoxNoClearMonList.Items.Strings[I]);
//                    }
//                }
//            } finally {
//                GameMsgDef.g_NoClearMonList.UnLock();
//            }
//            M2Share.SaveNoClearMonList();
//            uModValue();
//        }

//        public void ListBoxNoClearMonListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxNoClearMonList.SelectedIndex >= 0)
//            {
//                ButtonNoClearMonDel.Enabled = true;
//            }
//        }

//        public void ListBoxMonListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxMonList.SelectedIndex >= 0)
//            {
//                ButtonNoClearMonAdd.Enabled = true;
//            }
//        }

//        public void ButtonAdminLitsSaveClick(object sender, EventArgs e)
//        {
//            M2Share.SaveAdminList();
//            ButtonAdminLitsSave.Enabled = false;
//        }

//        public void ListBoxAdminListClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TAdminInfo AdminInfo;
//            nIndex = ListBoxAdminList.SelectedIndex;
//            UserEngine.m_AdminList.__Lock();
//            try {
//                if ((nIndex < 0) && (nIndex >= UserEngine.m_AdminList.Count))
//                {
//                    return;
//                }
//                ButtonAdminListChange.Enabled = true;
//                ButtonAdminListDel.Enabled = true;
//                AdminInfo = UserEngine.m_AdminList[nIndex];
//                EditAdminName.Text = AdminInfo.sChrName;
//                EditAdminIPaddr.Text = AdminInfo.sIPaddr;
//                EditAdminPremission.Value = AdminInfo.nLv;
//            } finally {
//                UserEngine.m_AdminList.UnLock();
//            }
//        }

//        public void ButtonAdminListAddClick(object sender, EventArgs e)
//        {
//            int I;
//            string sAdminName;
//            string sAdminIPaddr;
//            int nAdminPerMission;
//            TAdminInfo AdminInfo;
//            sAdminName = EditAdminName.Text.Trim();
//            sAdminIPaddr = EditAdminIPaddr.Text.Trim();
//            nAdminPerMission = EditAdminPremission.Value;
//            if ((nAdminPerMission < 1) || (sAdminName == "") || !(nAdminPerMission >= 0 && nAdminPerMission<= 10))
//            {
//                System.Windows.Forms.MessageBox.Show("输入不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditAdminName.Focus();
//                return;
//            }
//#if VEROWNER = WL
//            if ((sAdminIPaddr == ""))
//            {
//                System.Windows.Forms.MessageBox.Show("登录IP输入不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditAdminIPaddr.Focus();
//                return;
//            }
//#endif
//            UserEngine.m_AdminList.__Lock();
//            try {
//                if (UserEngine.m_AdminList.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < UserEngine.m_AdminList.Count; I ++ )
//                    {
//                        if ((((TAdminInfo)(UserEngine.m_AdminList[I])).sChrName).ToLower().CompareTo((sAdminName).ToLower()) == 0)
//                        {
//                            System.Windows.Forms.MessageBox.Show("输入的角色名已经在GM列表中！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
//                AdminInfo = new TAdminInfo();
//                AdminInfo.nLv = nAdminPerMission;
//                AdminInfo.sChrName = sAdminName;
//                AdminInfo.sIPaddr = sAdminIPaddr;
//                UserEngine.m_AdminList.Add(AdminInfo);
//            } finally {
//                UserEngine.m_AdminList.UnLock();
//            }
//            RefAdminList();
//            ButtonAdminLitsSave.Enabled = true;
//        }

//        public void ButtonAdminListChangeClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            string sAdminName;
//            string sAdminIPaddr;
//            int nAdminPerMission;
//            TAdminInfo AdminInfo;
//            nIndex = ListBoxAdminList.SelectedIndex;
//            if (nIndex < 0)
//            {
//                return;
//            }
//            sAdminName = EditAdminName.Text.Trim();
//            sAdminIPaddr = EditAdminIPaddr.Text.Trim();
//            nAdminPerMission = EditAdminPremission.Value;
//            if ((nAdminPerMission < 1) || (sAdminName == "") || !(nAdminPerMission >= 0 && nAdminPerMission<= 10))
//            {
//                System.Windows.Forms.MessageBox.Show("输入不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditAdminName.Focus();
//                return;
//            }
//#if VEROWNER = WL
//            if ((sAdminIPaddr == ""))
//            {
//                System.Windows.Forms.MessageBox.Show("登录IP输入不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditAdminIPaddr.Focus();
//                return;
//            }
//#endif
//            UserEngine.m_AdminList.__Lock();
//            try {
//                if ((nIndex < 0) && (nIndex >= UserEngine.m_AdminList.Count))
//                {
//                    return;
//                }
//                AdminInfo = UserEngine.m_AdminList[nIndex];
//                AdminInfo.sChrName = sAdminName;
//                AdminInfo.nLv = nAdminPerMission;
//                AdminInfo.sIPaddr = sAdminIPaddr;
//            } finally {
//                UserEngine.m_AdminList.UnLock();
//            }
//            RefAdminList();
//            ButtonAdminLitsSave.Enabled = true;
//        }

//        public void ButtonAdminListDelClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            nIndex = ListBoxAdminList.SelectedIndex;
//            if (nIndex < 0)
//            {
//                return;
//            }
//            UserEngine.m_AdminList.__Lock();
//            try {
//                if ((nIndex < 0) && (nIndex >= UserEngine.m_AdminList.Count))
//                {
//                    return;
//                }
//                this.Dispose(((TAdminInfo)(UserEngine.m_AdminList[nIndex])));
//                UserEngine.m_AdminList.RemoveAt(nIndex);
//            } finally {
//                UserEngine.m_AdminList.UnLock();
//            }
//            RefAdminList();
//            ButtonAdminLitsSave.Enabled = true;
//        }

//        private void RefItemBindAccount()
//        {
//            int I;
//            TItemBind ItemBind;
            
//            GridItemBindAccount.RowCount = 2;
            
//            GridItemBindAccount.Cells[0, 1] = "";
            
//            GridItemBindAccount.Cells[1, 1] = "";
            
//            GridItemBindAccount.Cells[2, 1] = "";
            
//            GridItemBindAccount.Cells[3, 1] = "";
//            ButtonItemBindAcountMod.Enabled = false;
//            ButtonItemBindAcountDel.Enabled = false;
//            M2Share.g_ItemBindAccount.__Lock();
//            try {
                
//                GridItemBindAccount.RowCount = M2Share.g_ItemBindAccount.Count + 1;
//                if (M2Share.g_ItemBindAccount.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_ItemBindAccount.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindAccount[I];
//                        if (ItemBind != null)
//                        {
                            
//                            GridItemBindAccount.Cells[0, I + 1] = UserEngine.GetStdItemName(ItemBind.nItemIdx);
                            
//                            GridItemBindAccount.Cells[1, I + 1] = (ItemBind.nItemIdx).ToString();
                            
//                            GridItemBindAccount.Cells[2, I + 1] = (ItemBind.nMakeIdex).ToString();
                            
//                            GridItemBindAccount.Cells[3, I + 1] = ItemBind.sBindName;
//                        }
//                    }
//                }
//            } finally {
//                M2Share.g_ItemBindAccount.UnLock();
//            }
//        }

//        public void GridItemBindAccountClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TItemBind ItemBind;
//            nIndex = GridItemBindAccount.CurrentRowIndex - 1;
//            if (nIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindAccount.__Lock();
//            try {
//                if (nIndex >= M2Share.g_ItemBindAccount.Count)
//                {
//                    return;
//                }
//                ItemBind = ((TItemBind)(M2Share.g_ItemBindAccount[nIndex]));
//                EditItemBindAccountItemName.Text = UserEngine.GetStdItemName(ItemBind.nItemIdx);
//                EditItemBindAccountItemIdx.Value = ItemBind.nItemIdx;
//                EditItemBindAccountItemMakeIdx.Value = ItemBind.nMakeIdex;
//                EditItemBindAccountName.Text = ItemBind.sBindName;
//            } finally {
//                M2Share.g_ItemBindAccount.UnLock();
//            }
//            ButtonItemBindAcountDel.Enabled = true;
//        }

//        public void EditItemBindAccountItemIdxChange(Object Sender)
//        {
//            if (EditItemBindAccountItemIdx.Text == "")
//            {
//                EditItemBindAccountItemIdx.Text = "0";
//                return;
//            }
//            EditItemBindAccountItemName.Text = UserEngine.GetStdItemName(EditItemBindAccountItemIdx.Value);
//            ButtonItemBindAcountMod.Enabled = true;
//        }

//        public void EditItemBindAccountItemMakeIdxChange(Object Sender)
//        {
//            if (EditItemBindAccountItemIdx.Text == "")
//            {
//                EditItemBindAccountItemIdx.Text = "0";
//                return;
//            }
//            ButtonItemBindAcountMod.Enabled = true;
//        }

//        public void EditItemBindAccountNameChange(object sender, EventArgs e)
//        {
//            ButtonItemBindAcountMod.Enabled = true;
//        }

//        public void ButtonItemBindAcountModClick(object sender, EventArgs e)
//        {
//            int nSelIndex;
//            int nMakeIdex;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindAccountItemIdx.Value;
//            nMakeIdex = EditItemBindAccountItemMakeIdx.Value;
//            sBindName = EditItemBindAccountName.Text.Trim();
//            nSelIndex = GridItemBindAccount.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindAccount.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindAccount.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindAccount[nSelIndex];
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.nMakeIdex = nMakeIdex;
//                ItemBind.sBindName = sBindName;
//            } finally {
//                M2Share.g_ItemBindAccount.UnLock();
//            }
//            M2Share.SaveItemBindAccount();
//            RefItemBindAccount();
//        }

//        public void ButtonItemBindAcountRefClick(object sender, EventArgs e)
//        {
//            RefItemBindAccount();
//        }

//        public void ButtonItemBindAcountAddClick(object sender, EventArgs e)
//        {
//            int I;
//            int nMakeIdex;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindAccountItemIdx.Value;
//            nMakeIdex = EditItemBindAccountItemMakeIdx.Value;
//            sBindName = EditItemBindAccountName.Text.Trim();
//            if ((nItemIdx <= 0) || (nMakeIdex < 0) || (sBindName == ""))
//            {
//                System.Windows.Forms.MessageBox.Show("输入的信息不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                return;
//            }
//            M2Share.g_ItemBindAccount.__Lock();
//            try {
//                if (M2Share.g_ItemBindAccount.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_ItemBindAccount.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindAccount[I];
//                        if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已经绑定到其他的帐号了！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
//                ItemBind = new TItemBind();
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.nMakeIdex = nMakeIdex;
//                ItemBind.sBindName = sBindName;
//                M2Share.g_ItemBindAccount.Insert(0, ItemBind);
//            } finally {
//                M2Share.g_ItemBindAccount.UnLock();
//            }
//            M2Share.SaveItemBindAccount();
//            RefItemBindAccount();
//        }

//        public void ButtonItemBindAcountDelClick(object sender, EventArgs e)
//        {
//            TItemBind ItemBind;
//            int nSelIndex;
//            nSelIndex = GridItemBindAccount.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindAccount.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindAccount.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindAccount[nSelIndex];
//                this.Dispose(ItemBind);
//                M2Share.g_ItemBindAccount.RemoveAt(nSelIndex);
//            } finally {
//                M2Share.g_ItemBindAccount.UnLock();
//            }
//            M2Share.SaveItemBindAccount();
//            RefItemBindAccount();
//        }

//        private void RefItemBindCharName()
//        {
//            int I;
//            TItemBind ItemBind;
            
//            GridItemBindCharName.RowCount = 2;
            
//            GridItemBindCharName.Cells[0, 1] = "";
            
//            GridItemBindCharName.Cells[1, 1] = "";
            
//            GridItemBindCharName.Cells[2, 1] = "";
            
//            GridItemBindCharName.Cells[3, 1] = "";
//            ButtonItemBindCharNameMod.Enabled = false;
//            ButtonItemBindCharNameDel.Enabled = false;
//            M2Share.g_ItemBindCharName.__Lock();
//            try {
                
//                GridItemBindCharName.RowCount = M2Share.g_ItemBindCharName.Count + 1;
//                if (M2Share.g_ItemBindCharName.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_ItemBindCharName.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindCharName[I];
//                        if (ItemBind != null)
//                        {
                            
//                            GridItemBindCharName.Cells[0, I + 1] = UserEngine.GetStdItemName(ItemBind.nItemIdx);
                            
//                            GridItemBindCharName.Cells[1, I + 1] = (ItemBind.nItemIdx).ToString();
                            
//                            GridItemBindCharName.Cells[2, I + 1] = (ItemBind.nMakeIdex).ToString();
                            
//                            GridItemBindCharName.Cells[3, I + 1] = ItemBind.sBindName;
//                        }
//                    }
//                }
//            } finally {
//                M2Share.g_ItemBindCharName.UnLock();
//            }
//        }

//        // 刷新人物装备死亡不爆列表 20081127
//        private void RefItemBindDieNoDropName()
//        {
//            int I;
//            TItemBind ItemBind;
            
//            GridITemBindDieName.RowCount = 2;
            
//            GridITemBindDieName.Cells[0, 1] = "";
            
//            GridITemBindDieName.Cells[1, 1] = "";
            
//            GridITemBindDieName.Cells[2, 1] = "";
//            ButtonItemBindDieNameMod.Enabled = false;
//            ButtonItemBindDieNameDel.Enabled = false;
//            M2Share.g_ItemBindDieNoDropName.__Lock();
//            try {
                
//                GridITemBindDieName.RowCount = M2Share.g_ItemBindDieNoDropName.Count + 1;
//                if (M2Share.g_ItemBindDieNoDropName.Count > 0)
//                {
//                    for (I = 0; I < M2Share.g_ItemBindDieNoDropName.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindDieNoDropName[I];
//                        if (ItemBind != null)
//                        {
                            
//                            GridITemBindDieName.Cells[0, I + 1] = UserEngine.GetStdItemName(ItemBind.nItemIdx);
                            
//                            GridITemBindDieName.Cells[1, I + 1] = (ItemBind.nItemIdx).ToString();
                            
//                            GridITemBindDieName.Cells[2, I + 1] = ItemBind.sBindName;
//                        }
//                    }
//                }
//            } finally {
//                M2Share.g_ItemBindDieNoDropName.UnLock();
//            }
//        }

//        public void GridItemBindCharNameClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TItemBind ItemBind;
//            nIndex = GridItemBindCharName.CurrentRowIndex - 1;
//            if (nIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindCharName.__Lock();
//            try {
//                if (nIndex >= M2Share.g_ItemBindCharName.Count)
//                {
//                    return;
//                }
//                ItemBind = ((TItemBind)(M2Share.g_ItemBindCharName[nIndex]));
//                EditItemBindCharNameItemName.Text = UserEngine.GetStdItemName(ItemBind.nItemIdx);
//                EditItemBindCharNameItemIdx.Value = ItemBind.nItemIdx;
//                EditItemBindCharNameItemMakeIdx.Value = ItemBind.nMakeIdex;
//                EditItemBindCharNameName.Text = ItemBind.sBindName;
//            } finally {
//                M2Share.g_ItemBindCharName.UnLock();
//            }
//            ButtonItemBindCharNameDel.Enabled = true;
//        }

//        public void EditItemBindCharNameItemIdxChange(Object Sender)
//        {
//            if (EditItemBindCharNameItemIdx.Text == "")
//            {
//                EditItemBindCharNameItemIdx.Text = "0";
//                return;
//            }
//            EditItemBindCharNameItemName.Text = UserEngine.GetStdItemName(EditItemBindCharNameItemIdx.Value);
//            ButtonItemBindCharNameMod.Enabled = true;
//        }

//        public void EditItemBindCharNameItemMakeIdxChange(Object Sender)
//        {
//            if (EditItemBindCharNameItemMakeIdx.Text == "")
//            {
//                EditItemBindCharNameItemMakeIdx.Text = "0";
//                return;
//            }
//            ButtonItemBindCharNameMod.Enabled = true;
//        }

//        public void EditItemBindCharNameNameChange(object sender, EventArgs e)
//        {
//            ButtonItemBindCharNameMod.Enabled = true;
//        }

//        public void ButtonItemBindCharNameAddClick(object sender, EventArgs e)
//        {
//            int I;
//            int nMakeIdex;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindCharNameItemIdx.Value;
//            nMakeIdex = EditItemBindCharNameItemMakeIdx.Value;
//            sBindName = EditItemBindCharNameName.Text.Trim();
//            if ((nItemIdx <= 0) || (nMakeIdex < 0) || (sBindName == ""))
//            {
//                System.Windows.Forms.MessageBox.Show("输入的信息不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                return;
//            }
//            M2Share.g_ItemBindCharName.__Lock();
//            try {
//                if (M2Share.g_ItemBindCharName.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_ItemBindCharName.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindCharName[I];
//                        if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已经绑定到其他的角色上了！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
//                ItemBind = new TItemBind();
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.nMakeIdex = nMakeIdex;
//                ItemBind.sBindName = sBindName;
//                M2Share.g_ItemBindCharName.Insert(0, ItemBind);
//            } finally {
//                M2Share.g_ItemBindCharName.UnLock();
//            }
//            M2Share.SaveItemBindCharName();
//            RefItemBindCharName();
//        }

//        public void ButtonItemBindCharNameModClick(object sender, EventArgs e)
//        {
//            int nSelIndex;
//            int nMakeIdex;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindCharNameItemIdx.Value;
//            nMakeIdex = EditItemBindCharNameItemMakeIdx.Value;
//            sBindName = EditItemBindCharNameName.Text.Trim();
//            nSelIndex = GridItemBindCharName.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindCharName.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindCharName.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindCharName[nSelIndex];
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.nMakeIdex = nMakeIdex;
//                ItemBind.sBindName = sBindName;
//            } finally {
//                M2Share.g_ItemBindCharName.UnLock();
//            }
//            M2Share.SaveItemBindCharName();
//            RefItemBindCharName();
//        }

//        public void ButtonItemBindCharNameDelClick(object sender, EventArgs e)
//        {
//            TItemBind ItemBind;
//            int nSelIndex;
//            nSelIndex = GridItemBindCharName.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindCharName.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindCharName.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindCharName[nSelIndex];
//                this.Dispose(ItemBind);
//                M2Share.g_ItemBindCharName.RemoveAt(nSelIndex);
//            } finally {
//                M2Share.g_ItemBindCharName.UnLock();
//            }
//            M2Share.SaveItemBindCharName();
//            RefItemBindCharName();
//        }

//        public void ButtonItemBindCharNameRefClick(object sender, EventArgs e)
//        {
//            RefItemBindCharName();
//        }

//        // 刷新人物装备死亡不爆列表 20081127
//        private void RefItemBindIPaddr()
//        {
//            int I;
//            TItemBind ItemBind;
            
//            GridItemBindIPaddr.RowCount = 2;
            
//            GridItemBindIPaddr.Cells[0, 1] = "";
            
//            GridItemBindIPaddr.Cells[1, 1] = "";
            
//            GridItemBindIPaddr.Cells[2, 1] = "";
            
//            GridItemBindIPaddr.Cells[3, 1] = "";
//            ButtonItemBindIPaddrMod.Enabled = false;
//            ButtonItemBindIPaddrDel.Enabled = false;
//            M2Share.g_ItemBindIPaddr.__Lock();
//            try {
                
//                GridItemBindIPaddr.RowCount = M2Share.g_ItemBindIPaddr.Count + 1;
//                if (M2Share.g_ItemBindIPaddr.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_ItemBindIPaddr.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindIPaddr[I];
//                        if (ItemBind != null)
//                        {
                            
//                            GridItemBindIPaddr.Cells[0, I + 1] = UserEngine.GetStdItemName(ItemBind.nItemIdx);
                            
//                            GridItemBindIPaddr.Cells[1, I + 1] = (ItemBind.nItemIdx).ToString();
                            
//                            GridItemBindIPaddr.Cells[2, I + 1] = (ItemBind.nMakeIdex).ToString();
                            
//                            GridItemBindIPaddr.Cells[3, I + 1] = ItemBind.sBindName;
//                        }
//                    }
//                }
//            } finally {
//                M2Share.g_ItemBindIPaddr.UnLock();
//            }
//        }

//        public void GridItemBindIPaddrClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TItemBind ItemBind;
//            nIndex = GridItemBindIPaddr.CurrentRowIndex - 1;
//            if (nIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindIPaddr.__Lock();
//            try {
//                if (nIndex >= M2Share.g_ItemBindIPaddr.Count)
//                {
//                    return;
//                }
//                ItemBind = ((TItemBind)(M2Share.g_ItemBindIPaddr[nIndex]));
//                EditItemBindIPaddrItemName.Text = UserEngine.GetStdItemName(ItemBind.nItemIdx);
//                EditItemBindIPaddrItemIdx.Value = ItemBind.nItemIdx;
//                EditItemBindIPaddrItemMakeIdx.Value = ItemBind.nMakeIdex;
//                EditItemBindIPaddrName.Text = ItemBind.sBindName;
//            } finally {
//                M2Share.g_ItemBindIPaddr.UnLock();
//            }
//            ButtonItemBindIPaddrDel.Enabled = true;
//        }

//        public void EditItemBindIPaddrItemIdxChange(Object Sender)
//        {
//            if (EditItemBindIPaddrItemIdx.Text == "")
//            {
//                EditItemBindIPaddrItemIdx.Text = "0";
//                return;
//            }
//            EditItemBindIPaddrItemName.Text = UserEngine.GetStdItemName(EditItemBindIPaddrItemIdx.Value);
//            ButtonItemBindIPaddrMod.Enabled = true;
//        }

//        public void EditItemBindIPaddrItemMakeIdxChange(Object Sender)
//        {
//            if (EditItemBindIPaddrItemMakeIdx.Text == "")
//            {
//                EditItemBindIPaddrItemMakeIdx.Text = "0";
//                return;
//            }
//            ButtonItemBindIPaddrMod.Enabled = true;
//        }

//        public void EditItemBindIPaddrNameChange(object sender, EventArgs e)
//        {
//            ButtonItemBindIPaddrMod.Enabled = true;
//        }

//        public void ButtonItemBindIPaddrAddClick(object sender, EventArgs e)
//        {
//            int I;
//            int nMakeIdex;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindIPaddrItemIdx.Value;
//            nMakeIdex = EditItemBindIPaddrItemMakeIdx.Value;
//            sBindName = EditItemBindIPaddrName.Text.Trim();
//            if (!HUtil32.IsIPAddr(sBindName))
//            {
//                System.Windows.Forms.MessageBox.Show("IP地址格式输入不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditItemBindIPaddrName.Focus();
//                return;
//            }
//            if ((nItemIdx <= 0) || (nMakeIdex < 0))
//            {
//                System.Windows.Forms.MessageBox.Show("输入的信息不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                return;
//            }
//            M2Share.g_ItemBindIPaddr.__Lock();
//            try {
//                if (M2Share.g_ItemBindIPaddr.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.g_ItemBindIPaddr.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindIPaddr[I];
//                        if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已经绑定到其他的IP地址上了！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
//                ItemBind = new TItemBind();
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.nMakeIdex = nMakeIdex;
//                ItemBind.sBindName = sBindName;
//                M2Share.g_ItemBindIPaddr.Insert(0, ItemBind);
//            } finally {
//                M2Share.g_ItemBindIPaddr.UnLock();
//            }
//            M2Share.SaveItemBindIPaddr();
//            RefItemBindIPaddr();
//        }

//        public void ButtonItemBindIPaddrModClick(object sender, EventArgs e)
//        {
//            int nSelIndex;
//            int nMakeIdex;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindIPaddrItemIdx.Value;
//            nMakeIdex = EditItemBindIPaddrItemMakeIdx.Value;
//            sBindName = EditItemBindIPaddrName.Text.Trim();
//            if (!HUtil32.IsIPAddr(sBindName))
//            {
//                System.Windows.Forms.MessageBox.Show("IP地址格式输入不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditItemBindIPaddrName.Focus();
//                return;
//            }
//            nSelIndex = GridItemBindIPaddr.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindIPaddr.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindIPaddr.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindIPaddr[nSelIndex];
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.nMakeIdex = nMakeIdex;
//                ItemBind.sBindName = sBindName;
//            } finally {
//                M2Share.g_ItemBindIPaddr.UnLock();
//            }
//            M2Share.SaveItemBindIPaddr();
//            RefItemBindIPaddr();
//        }

//        public void ButtonItemBindIPaddrDelClick(object sender, EventArgs e)
//        {
//            TItemBind ItemBind;
//            int nSelIndex;
//            nSelIndex = GridItemBindIPaddr.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindIPaddr.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindIPaddr.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindIPaddr[nSelIndex];
//                this.Dispose(ItemBind);
//                M2Share.g_ItemBindIPaddr.RemoveAt(nSelIndex);
//            } finally {
//                M2Share.g_ItemBindIPaddr.UnLock();
//            }
//            M2Share.SaveItemBindIPaddr();
//            RefItemBindIPaddr();
//        }

//        public void ButtonItemBindIPaddrRefClick(object sender, EventArgs e)
//        {
//            RefItemBindIPaddr();
//        }

//        private void RefItemCustomNameList()
//        {
//            int I;
//            TItemName ItemName;
//            // GridItemNameList.RowCount:=2;
            
//            GridItemNameList.Cells[0, 1] = "";
            
//            GridItemNameList.Cells[1, 1] = "";
            
//            GridItemNameList.Cells[2, 1] = "";
//            ButtonItemNameMod.Enabled = false;
//            ButtonItemNameDel.Enabled = false;
//            M2Share.ItemUnit.m_ItemNameList.__Lock();
//            try {
                
//                GridItemNameList.RowCount = M2Share.ItemUnit.m_ItemNameList.Count + 1;
//                if (M2Share.ItemUnit.m_ItemNameList.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.ItemUnit.m_ItemNameList.Count; I ++ )
//                    {
//                        ItemName = M2Share.ItemUnit.m_ItemNameList[I];
//                        if (ItemName != null)
//                        {
                            
//                            GridItemNameList.Cells[0, I + 1] = UserEngine.GetStdItemName(ItemName.nItemIndex);
                            
//                            GridItemNameList.Cells[1, I + 1] = (ItemName.nMakeIndex).ToString();
                            
//                            GridItemNameList.Cells[2, I + 1] = ItemName.sItemName;
//                        }
//                    }
//                }
//            } finally {
//                M2Share.ItemUnit.m_ItemNameList.UnLock();
//            }
//        }

//        public void GridItemNameListClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TItemName ItemName;
//            nIndex = GridItemNameList.CurrentRowIndex - 1;
//            if (nIndex < 0)
//            {
//                return;
//            }
//            M2Share.ItemUnit.m_ItemNameList.__Lock();
//            try {
//                if (nIndex >= M2Share.ItemUnit.m_ItemNameList.Count)
//                {
//                    return;
//                }
//                ItemName = ((TItemName)(M2Share.ItemUnit.m_ItemNameList[nIndex]));
//                EditItemNameOldName.Text = UserEngine.GetStdItemName(ItemName.nItemIndex);
//                EditItemNameIdx.Value = ItemName.nItemIndex;
//                EditItemNameMakeIndex.Value = ItemName.nMakeIndex;
//                EditItemNameNewName.Text = ItemName.sItemName;
//            } finally {
//                M2Share.ItemUnit.m_ItemNameList.UnLock();
//            }
//            ButtonItemNameDel.Enabled = true;
//        }

//        public void EditItemNameIdxChange(Object Sender)
//        {
//            EditItemNameOldName.Text = UserEngine.GetStdItemName(EditItemNameIdx.Value);
//            ButtonItemNameMod.Enabled = true;
//        }

//        public void EditItemNameMakeIndexChange(Object Sender)
//        {
//            ButtonItemNameMod.Enabled = true;
//        }

//        public void EditItemNameNewNameChange(object sender, EventArgs e)
//        {
//            ButtonItemNameMod.Enabled = true;
//        }

//        public void ButtonItemNameAddClick(object sender, EventArgs e)
//        {
//            int I;
//            int nMakeIdex;
//            int nItemIdx;
//            string sNewName;
//            TItemName ItemName;
//            nItemIdx = EditItemNameIdx.Value;
//            nMakeIdex = EditItemNameMakeIndex.Value;
//            sNewName = EditItemNameNewName.Text.Trim();
//            if ((nItemIdx <= 0) || (nMakeIdex < 0) || (sNewName == ""))
//            {
//                System.Windows.Forms.MessageBox.Show("输入的信息不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                return;
//            }
//            M2Share.ItemUnit.m_ItemNameList.__Lock();
//            try {
//                if (M2Share.ItemUnit.m_ItemNameList.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < M2Share.ItemUnit.m_ItemNameList.Count; I ++ )
//                    {
//                        ItemName = M2Share.ItemUnit.m_ItemNameList[I];
//                        if ((ItemName.nItemIndex == nItemIdx) && (ItemName.nMakeIndex == nMakeIdex))
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已经自定义过名称了！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
//                ItemName = new TItemName();
//                ItemName.nItemIndex = nItemIdx;
//                ItemName.nMakeIndex = nMakeIdex;
//                ItemName.sItemName = sNewName;
//                M2Share.ItemUnit.m_ItemNameList.Insert(0, ItemName);
//            } finally {
//                M2Share.ItemUnit.m_ItemNameList.UnLock();
//            }
//            M2Share.ItemUnit.SaveCustomItemName();
//            RefItemCustomNameList();
//        }

//        public void ButtonItemNameModClick(object sender, EventArgs e)
//        {
//            int nSelIndex;
//            int nMakeIdex;
//            int nItemIdx;
//            string sNewName;
//            TItemName ItemName;
//            nItemIdx = EditItemNameIdx.Value;
//            nMakeIdex = EditItemNameMakeIndex.Value;
//            sNewName = EditItemNameNewName.Text.Trim();
//            nSelIndex = GridItemNameList.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.ItemUnit.m_ItemNameList.__Lock();
//            try {
//                if (nSelIndex >= M2Share.ItemUnit.m_ItemNameList.Count)
//                {
//                    return;
//                }
//                ItemName = M2Share.ItemUnit.m_ItemNameList[nSelIndex];
//                ItemName.nItemIndex = nItemIdx;
//                ItemName.nMakeIndex = nMakeIdex;
//                ItemName.sItemName = sNewName;
//            } finally {
//                M2Share.ItemUnit.m_ItemNameList.UnLock();
//            }
//            M2Share.ItemUnit.SaveCustomItemName();
//            RefItemCustomNameList();
//        }

//        public void ButtonItemNameDelClick(object sender, EventArgs e)
//        {
//            TItemName ItemName;
//            int nSelIndex;
//            nSelIndex = GridItemNameList.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.ItemUnit.m_ItemNameList.__Lock();
//            try {
//                if (nSelIndex >= M2Share.ItemUnit.m_ItemNameList.Count)
//                {
//                    return;
//                }
//                ItemName = M2Share.ItemUnit.m_ItemNameList[nSelIndex];
//                this.Dispose(ItemName);
//                M2Share.ItemUnit.m_ItemNameList.RemoveAt(nSelIndex);
//            } finally {
//                M2Share.ItemUnit.m_ItemNameList.UnLock();
//            }
//            M2Share.ItemUnit.SaveCustomItemName();
//            RefItemCustomNameList();
//        }

//        public void ButtonItemNameRefClick(object sender, EventArgs e)
//        {
//            RefItemCustomNameList();
//        }

//        public void ListBoxitemList4Click(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxitemList4.SelectedIndex >= 0)
//            {
//                ButtonSellOffAdd.Enabled = true;
//            }
//        }

//        public void ButtonSellOffDelClick(object sender, EventArgs e)
//        {
//            if (ListBoxSellOffList.SelectedIndex >= 0)
//            {
                
//                ListBoxSellOffList.Items.Delete(ListBoxSellOffList.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxSellOffList.SelectedIndex < 0)
//            {
//                ButtonSellOffDel.Enabled = false;
//            }
//        }

//        public void ListBoxSellOffListClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxSellOffList.SelectedIndex >= 0)
//            {
//                ButtonSellOffDel.Enabled = true;
//            }
//        }

//        public void ButtonSellOffAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxSellOffList.Items.Clear();
//            if (ListBoxitemList4.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxitemList4.Items.Count; I ++ )
//                {
                    
//                    ListBoxSellOffList.Items.Add(ListBoxitemList4.Items.Strings[I]);
//                }
//            }
//            ModValue();
//        }

//        public void ButtonSellOffDelAllClick(object sender, EventArgs e)
//        {
//            ListBoxSellOffList.Items.Clear();
//            ButtonSellOffDelAll.Enabled = false;
//            ModValue();
//        }

//        public void ButtonSellOffSaveClick(object sender, EventArgs e)
//        {
//            // var
//            // I: Integer;
//            // sItemIdx: string;
//            // g_AllowSellOffItemList.Lock; //20080416 去掉拍卖功能
//            // try
//            // g_AllowSellOffItemList.Clear;
//            // for I := 0 to ListBoxSellOffList.Items.Count - 1 do begin
//            // g_AllowSellOffItemList.Add(Trim(ListBoxSellOffList.Items.Strings[I]));
//            // end;
//            // finally
//            // g_AllowSellOffItemList.UnLock;
//            // end;
//            // SaveAllowSellOffItemList();
//            // uModValue();

//        }

//        public void ButtonSellOffAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxitemList4.SelectedIndex >= 0)
//            {
//                if (ListBoxSellOffList.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxSellOffList.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxSellOffList.Items.Strings[I] == ListBoxitemList4.Items.Strings[ListBoxitemList4.SelectedIndex])
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
//                ListBoxSellOffList.Items.Add(ListBoxitemList4.Items.Strings[ListBoxitemList4.SelectedIndex]);
//                ModValue();
//            }
//        }

//        public void ListBoxAllowPickUpItemClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxAllowPickUpItem.SelectedIndex >= 0)
//            {
//                ButtonPickItemDel.Enabled = true;
//            }
//        }

//        public void ListBoxitemList5Click(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxitemList5.SelectedIndex >= 0)
//            {
//                ButtonPickItemAdd.Enabled = true;
//            }
//        }

//        public void ButtonPickItemAddAllClick(object sender, EventArgs e)
//        {
//            int I;
//            ListBoxAllowPickUpItem.Items.Clear();
//            if (ListBoxitemList5.Items.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < ListBoxitemList5.Items.Count; I ++ )
//                {
                    
//                    ListBoxAllowPickUpItem.Items.Add(ListBoxitemList5.Items.Strings[I]);
//                }
//            }
//            ModValue();
//        }

//        public void ButtonPickItemDelAllClick(object sender, EventArgs e)
//        {
//            ListBoxAllowPickUpItem.Items.Clear();
//            ButtonPickItemDelAll.Enabled = false;
//            ModValue();
//        }

//        public void ButtonPickItemSaveClick(object sender, EventArgs e)
//        {
//            int I;
//            // sItemIdx: string;
//            string sFileName;
//            sFileName = M2Share.g_Config.sEnvirDir + "AllowPickUpItemList.txt";
//            GameMsgDef.g_AllowPickUpItemList.__Lock();
//            try {
//                GameMsgDef.g_AllowPickUpItemList.Clear();
//                // g_AllowPickUpItemList.Add(';允许分身捡取物品列表');
//                if (ListBoxAllowPickUpItem.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxAllowPickUpItem.Items.Count; I ++ )
//                    {
                        
//                        GameMsgDef.g_AllowPickUpItemList.Add(ListBoxAllowPickUpItem.Items.Strings[I].Trim());
//                    }
//                }
//            } finally {
//                GameMsgDef.g_AllowPickUpItemList.UnLock();
//            }
//            try {
                
//                GameMsgDef.g_AllowPickUpItemList.SaveToFile(sFileName);
//            }
//            catch {
//            }
//            uModValue();
//        }

//        public void ButtonPickItemAddClick(object sender, EventArgs e)
//        {
//            int I;
//            if (ListBoxitemList5.SelectedIndex >= 0)
//            {
//                if (ListBoxAllowPickUpItem.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxAllowPickUpItem.Items.Count; I ++ )
//                    {
                        
                        
//                        if (ListBoxAllowPickUpItem.Items.Strings[I] == ListBoxitemList5.Items.Strings[ListBoxitemList5.SelectedIndex])
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
                
//                ListBoxAllowPickUpItem.Items.Add(ListBoxitemList5.Items.Strings[ListBoxitemList5.SelectedIndex]);
//                ModValue();
//            }
//        }

//        public void ButtonPickItemDelClick(object sender, EventArgs e)
//        {
//            if (ListBoxAllowPickUpItem.SelectedIndex >= 0)
//            {
                
//                ListBoxAllowPickUpItem.Items.Delete(ListBoxAllowPickUpItem.SelectedIndex);
//                ModValue();
//            }
//            if (ListBoxAllowPickUpItem.SelectedIndex < 0)
//            {
//                ButtonPickItemDel.Enabled = false;
//            }
//        }

//        // 20071112 增加 begin
//        public void ListBoxDisableSendMsgClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            if (ListBoxDisableSendMsg.SelectedIndex >= 0)
//            {
//                ListBoxDisableSendMsgDelete.Enabled = true;
//            }
//        }

//        public void ListBoxDisableSendMsgAddClick(object sender, EventArgs e)
//        {
//            int I;
//            int K;
//            string sFileName;
//            if (ListBoxDisableMoveMap.Items.Count > 0)
//            {
//                // 20080630
//                for (K = 0; K < ListBoxDisableMoveMap.Items.Count; K ++ )
//                {
                    
//                    if (ListBoxDisableSendMsg.Items.Strings[K] == DisableSendMsg_Edt.Text.Trim())
//                    {
//                        System.Windows.Forms.MessageBox.Show("此角色名称已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                        return;
//                    }
//                }
//            }
//            ListBoxDisableSendMsg.Items.Add(DisableSendMsg_Edt.Text.Trim());
//            // 保存增加的信息到文件里
//            sFileName = M2Share.g_Config.sEnvirDir + "DisableSendMsgList.txt";
//            M2Share.g_DisableSendMsgList.__Lock();
//            try {
//                M2Share.g_DisableSendMsgList.Clear();
//                if (ListBoxDisableSendMsg.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableSendMsg.Items.Count; I ++ )
//                    {
                        
//                        M2Share.g_DisableSendMsgList.Add(ListBoxDisableSendMsg.Items.Strings[I].Trim());
//                    }
//                }
//            } finally {
//                M2Share.g_DisableSendMsgList.UnLock();
//            }
//            try {
                
//                M2Share.g_DisableSendMsgList.SaveToFile(sFileName);
//            }
//            catch {
//            }
//            ListBoxDisableSendMsgAdd.Enabled = false;
//        }

//        public void DisableSendMsg_EdtChange(object sender, EventArgs e)
//        {
//            ListBoxDisableSendMsgAdd.Enabled = true;
//        }

//        public void ListBoxDisableSendMsgDeleteClick(object sender, EventArgs e)
//        {
//            int I;
//            string sFileName;
//            if (ListBoxDisableSendMsg.SelectedIndex >= 0)
//            {
                
//                ListBoxDisableSendMsg.Items.Delete(ListBoxDisableSendMsg.SelectedIndex);
//            }
//            // 保存删除的信息到文件里
//            sFileName = M2Share.g_Config.sEnvirDir + "DisableSendMsgList.txt";
//            M2Share.g_DisableSendMsgList.__Lock();
//            try {
//                M2Share.g_DisableSendMsgList.Clear();
//                if (ListBoxDisableSendMsg.Items.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < ListBoxDisableSendMsg.Items.Count; I ++ )
//                    {
                        
//                        M2Share.g_DisableSendMsgList.Add(ListBoxDisableSendMsg.Items.Strings[I].Trim());
//                    }
//                }
//            } finally {
//                M2Share.g_DisableSendMsgList.UnLock();
//            }
//            try {
                
//                M2Share.g_DisableSendMsgList.SaveToFile(sFileName);
//            }
//            catch {
//            }
//        }

//        // 20071112 增加 end
//        public void EditItemBindDieNameItemIdxChange(Object Sender)
//        {
//            if (EditItemBindDieNameItemIdx.Text == "")
//            {
//                EditItemBindDieNameItemIdx.Text = "0";
//                return;
//            }
//            EditItemBindDieNameItemName.Text = UserEngine.GetStdItemName(EditItemBindDieNameItemIdx.Value);
//            ButtonItemBindDieNameMod.Enabled = true;
//        }

//        public void GridITemBindDieNameClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TItemBind ItemBind;
//            nIndex = GridITemBindDieName.CurrentRowIndex - 1;
//            if (nIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindDieNoDropName.__Lock();
//            try {
//                if (nIndex >= M2Share.g_ItemBindDieNoDropName.Count)
//                {
//                    return;
//                }
//                ItemBind = ((TItemBind)(M2Share.g_ItemBindDieNoDropName[nIndex]));
//                EditItemBindDieNameItemName.Text = UserEngine.GetStdItemName(ItemBind.nItemIdx);
//                EditItemBindDieNameItemIdx.Value = ItemBind.nItemIdx;
//                EditItemBindDieNameName.Text = ItemBind.sBindName;
//            } finally {
//                M2Share.g_ItemBindDieNoDropName.UnLock();
//            }
//            ButtonItemBindDieNameDel.Enabled = true;
//        }

//        public void ButtonItemBindDieNameModClick(object sender, EventArgs e)
//        {
//            int nSelIndex;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindDieNameItemIdx.Value;
//            sBindName = EditItemBindDieNameName.Text.Trim();
//            nSelIndex = GridITemBindDieName.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindDieNoDropName.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindDieNoDropName.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindDieNoDropName[nSelIndex];
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.sBindName = sBindName;
//            } finally {
//                M2Share.g_ItemBindDieNoDropName.UnLock();
//            }
//            M2Share.SaveItemBindDieNoDropName();
//            // 保存人物装备死亡不爆列表 20081127
//            RefItemBindDieNoDropName();
//        }

//        public void ButtonItemBindDieNameDelClick(object sender, EventArgs e)
//        {
//            TItemBind ItemBind;
//            int nSelIndex;
//            nSelIndex = GridITemBindDieName.CurrentRowIndex - 1;
//            if (nSelIndex < 0)
//            {
//                return;
//            }
//            M2Share.g_ItemBindDieNoDropName.__Lock();
//            try {
//                if (nSelIndex >= M2Share.g_ItemBindDieNoDropName.Count)
//                {
//                    return;
//                }
//                ItemBind = M2Share.g_ItemBindDieNoDropName[nSelIndex];
//                this.Dispose(ItemBind);
//                M2Share.g_ItemBindDieNoDropName.RemoveAt(nSelIndex);
//            } finally {
//                M2Share.g_ItemBindDieNoDropName.UnLock();
//            }
//            M2Share.SaveItemBindDieNoDropName();
//            // 保存人物装备死亡不爆列表 20081127
//            RefItemBindDieNoDropName();
//        }

//        public void ButtonItemBindDieNameAddClick(object sender, EventArgs e)
//        {
//            int I;
//            int nItemIdx;
//            string sBindName;
//            TItemBind ItemBind;
//            nItemIdx = EditItemBindDieNameItemIdx.Value;
//            sBindName = EditItemBindDieNameName.Text.Trim();
//            if ((nItemIdx <= 0) || (sBindName == ""))
//            {
//                System.Windows.Forms.MessageBox.Show("输入的信息不正确！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                return;
//            }
//            M2Share.g_ItemBindDieNoDropName.__Lock();
//            try {
//                if (M2Share.g_ItemBindDieNoDropName.Count > 0)
//                {
//                    for (I = 0; I < M2Share.g_ItemBindDieNoDropName.Count; I ++ )
//                    {
//                        ItemBind = M2Share.g_ItemBindDieNoDropName[I];
//                        if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.sBindName == sBindName))
//                        {
//                            System.Windows.Forms.MessageBox.Show("此物品已经绑定到角色上了,不能重复绑定！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                            return;
//                        }
//                    }
//                }
//                ItemBind = new TItemBind();
//                ItemBind.nItemIdx = nItemIdx;
//                ItemBind.nMakeIdex = 0;
//                ItemBind.sBindName = sBindName;
//                M2Share.g_ItemBindDieNoDropName.Insert(0, ItemBind);
//            } finally {
//                M2Share.g_ItemBindDieNoDropName.UnLock();
//            }
//            M2Share.SaveItemBindDieNoDropName();
//            // 保存人物装备死亡不爆列表 20081127
//            RefItemBindDieNoDropName();
//        }

//        public void ButtonItemBindDieNameRefClick(object sender, EventArgs e)
//        {
//            RefItemBindDieNoDropName();
//        }

//        // Note: the original parameters are Object Sender, ref TCloseAction Action
//        public void FormClose(object sender, EventArgs e)
//        {
            
//            Action = caFree;
//        }

//        public void FormDestroy(Object Sender)
//        {
//            Units.ViewList.frmViewList = null;
//        }

    }
}
