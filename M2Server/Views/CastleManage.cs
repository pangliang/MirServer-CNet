using System;
using System.Windows.Forms;
using GameFramework;

namespace M2Server
{
    public partial class TfrmCastleManage: Form
    {
        public static TfrmCastleManage frmCastleManage = null;
        public static int nCount = 0;
        public static TUserCastle CurCastle = null;
        public static bool boRefing = false;
        public static TAttackerInfo SelAttackGuildInfo = null;

        public TfrmCastleManage()
        {
            InitializeComponent();
        }

        public void Open()
        {
            nCount = 0;
            ButtonSave.Enabled = true;
            SelAttackGuildInfo = null;
            RefCastleList();
            this.ShowDialog();
        }

        private void RefCastleInfo()
        {
            //int I;
            //int II;
            //ListViewItem ListItem;
            //TObjUnit ObjUnit;
            //if (CurCastle == null)
            //{
            //    return;
            //}
            //boRefing = true;
            //if (CurCastle.m_MasterGuild == null)
            //{
            //    EditOwenGuildName.Text = "";
            //}
            //else
            //{
            //    EditOwenGuildName.Text = CurCastle.m_MasterGuild.sGuildName;
            //}
            //EditTotalGold.Value = CurCastle.m_nTotalGold;
            //EditTodayIncome.Value = CurCastle.m_nTodayIncome;
            //EditTechLevel.Value = CurCastle.m_nTechLevel;
            //EditPower.Value = CurCastle.m_nPower;
            //ListViewGuard.Items.Clear;
            //ListItem = ListViewGuard.Items.Add();
            //ListItem.Text = "0";
            //if (CurCastle.m_MainDoor.BaseObject != null)
            //{
            //    ListItem.SubItems.Add(CurCastle.m_MainDoor.BaseObject.m_sCharName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_MainDoor.BaseObject.m_nCurrX, CurCastle.m_MainDoor.BaseObject.m_nCurrY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {CurCastle.m_MainDoor.BaseObject.m_WAbil.HP, CurCastle.m_MainDoor.BaseObject.m_WAbil.MaxHP}));
            //    if (CurCastle.m_MainDoor.BaseObject.m_boDeath)
            //    {
            //        ListItem.SubItems.Add("损坏");
            //    }
            //    else
            //    {
            //        if ((CurCastle.m_DoorStatus != null))
            //        {
            //            if (CurCastle.m_DoorStatus.boOpened)
            //            {
            //                ListItem.SubItems.Add("开启");
            //            }
            //            else
            //            {
            //                ListItem.SubItems.Add("关闭");
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    ListItem.SubItems.Add(CurCastle.m_MainDoor.sName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_MainDoor.nX, CurCastle.m_MainDoor.nY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {0, 0}));
            //}
            //ListItem = ListViewGuard.Items.Add();
            //ListItem.Text = "1";
            //if (CurCastle.m_LeftWall.BaseObject != null)
            //{
            //    ListItem.SubItems.Add(CurCastle.m_LeftWall.BaseObject.m_sCharName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_LeftWall.BaseObject.m_nCurrX, CurCastle.m_LeftWall.BaseObject.m_nCurrY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {CurCastle.m_LeftWall.BaseObject.m_WAbil.HP, CurCastle.m_LeftWall.BaseObject.m_WAbil.MaxHP}));
            //    if (CurCastle.m_LeftWall.BaseObject.m_boDeath)
            //    {
            //        ListItem.SubItems.Add("损坏");
            //    }
            //}
            //else
            //{
            //    ListItem.SubItems.Add(CurCastle.m_LeftWall.sName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_LeftWall.nX, CurCastle.m_LeftWall.nY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {0, 0}));
            //}
            //ListItem = ListViewGuard.Items.Add();
            //ListItem.Text = "2";
            //if (CurCastle.m_CenterWall.BaseObject != null)
            //{
            //    ListItem.SubItems.Add(CurCastle.m_CenterWall.BaseObject.m_sCharName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_CenterWall.BaseObject.m_nCurrX, CurCastle.m_CenterWall.BaseObject.m_nCurrY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {CurCastle.m_CenterWall.BaseObject.m_WAbil.HP, CurCastle.m_CenterWall.BaseObject.m_WAbil.MaxHP}));
            //    if (CurCastle.m_CenterWall.BaseObject.m_boDeath)
            //    {
            //        ListItem.SubItems.Add("损坏");
            //    }
            //}
            //else
            //{
            //    ListItem.SubItems.Add(CurCastle.m_CenterWall.sName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_CenterWall.nX, CurCastle.m_CenterWall.nY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {0, 0}));
            //}
            //ListItem = ListViewGuard.Items.Add();
            //ListItem.Text = "3";
            //if (CurCastle.m_RightWall.BaseObject != null)
            //{
            //    ListItem.SubItems.Add(CurCastle.m_RightWall.BaseObject.m_sCharName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_RightWall.BaseObject.m_nCurrX, CurCastle.m_RightWall.BaseObject.m_nCurrY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {CurCastle.m_RightWall.BaseObject.m_WAbil.HP, CurCastle.m_RightWall.BaseObject.m_WAbil.MaxHP}));
            //    if (CurCastle.m_RightWall.BaseObject.m_boDeath)
            //    {
            //        ListItem.SubItems.Add("损坏");
            //    }
            //}
            //else
            //{
            //    ListItem.SubItems.Add(CurCastle.m_RightWall.sName);
                
            //    ListItem.SubItems.Add(string.Format("%d:%d", new int[] {CurCastle.m_RightWall.nX, CurCastle.m_RightWall.nY}));
                
            //    ListItem.SubItems.Add(string.Format("%d/%d", new int[] {0, 0}));
            //}
            //for (I = CurCastle.m_Archer.GetLowerBound(0); I <= CurCastle.m_Archer.GetUpperBound(0); I ++ )
            //{
            //    ObjUnit = CurCastle.m_Archer[I];
            //    ListItem = ListViewGuard.Items.Add();
            //    ListItem.Text = (I + 4).ToString();
            //    if (ObjUnit.BaseObject != null)
            //    {
            //        ListItem.SubItems.Add(ObjUnit.BaseObject.m_sCharName);
                    
            //        ListItem.SubItems.Add(string.Format("%d:%d", new int[] {ObjUnit.BaseObject.m_nCurrX, ObjUnit.BaseObject.m_nCurrY}));
                    
            //        ListItem.SubItems.Add(string.Format("%d/%d", new int[] {ObjUnit.BaseObject.m_WAbil.HP, ObjUnit.BaseObject.m_WAbil.MaxHP}));
            //    }
            //    else
            //    {
            //        ListItem.SubItems.Add(ObjUnit.sName);
                    
            //        ListItem.SubItems.Add(string.Format("%d:%d", new int[] {ObjUnit.nX, ObjUnit.nY}));
                    
            //        ListItem.SubItems.Add(string.Format("%d/%d", new int[] {0, 0}));
            //    }
            //}
            //I = 5 + CurCastle.m_Archer.GetUpperBound(0);
            //// 20081201
            //for (II = CurCastle.m_Guard.GetLowerBound(0); II <= CurCastle.m_Guard.GetUpperBound(0); II ++ )
            //{
            //    ObjUnit = CurCastle.m_Guard[II];
            //    ListItem = ListViewGuard.Items.Add();
            //    ListItem.Text = (II + I).ToString();
            //    // 20081201 修改
            //    if (ObjUnit.BaseObject != null)
            //    {
            //        ListItem.SubItems.Add(ObjUnit.BaseObject.m_sCharName);
                    
            //        ListItem.SubItems.Add(string.Format("%d:%d", new int[] {ObjUnit.BaseObject.m_nCurrX, ObjUnit.BaseObject.m_nCurrY}));
                    
            //        ListItem.SubItems.Add(string.Format("%d/%d", new int[] {ObjUnit.BaseObject.m_WAbil.HP, ObjUnit.BaseObject.m_WAbil.MaxHP}));
            //    }
            //    else
            //    {
            //        ListItem.SubItems.Add(ObjUnit.sName);
                    
            //        ListItem.SubItems.Add(string.Format("%d:%d", new int[] {ObjUnit.nX, ObjUnit.nY}));
                    
            //        ListItem.SubItems.Add(string.Format("%d/%d", new int[] {0, 0}));
            //    }
            //}
            //EditCastleName.Text = CurCastle.m_sName;
            //if (CurCastle.m_MasterGuild != null)
            //{
            //    EditCastleOfGuild.Text = CurCastle.m_MasterGuild.sGuildName;
            //}
            //else
            //{
            //    EditCastleOfGuild.Text = "";
            //}
            //EditPalace.Text = CurCastle.m_sPalaceMap;
            //EditHomeMap.Text = CurCastle.m_sHomeMap;
            //SpinEditNomeX.Value = CurCastle.m_nHomeX;
            //SpinEditNomeY.Value = CurCastle.m_nHomeY;
            //EditTunnelMap.Text = CurCastle.m_sSecretMap;
            //RefCastleAttackSabukWall();
            //boRefing = false;
        }

        private void RefCastleList()
        {
            //int I;
            //TUserCastle UserCastle;
            //ListViewItem ListItem;
            //M2Share.g_CastleManager.__Lock();
            //try {
            //    if (M2Share.g_CastleManager.m_CastleList.Count > 0)
            //    {
            //        // 20080630
            //        for (I = 0; I < M2Share.g_CastleManager.m_CastleList.Count; I ++ )
            //        {
            //            UserCastle = ((TUserCastle)(M2Share.g_CastleManager.m_CastleList[I]));
            //            ListItem = ListViewCastle.Items.Add();
            //            ListItem.Text = (I).ToString();
                        
            //            ListItem.SubItems.AddObject(UserCastle.m_sConfigDir, UserCastle);
            //            ListItem.SubItems.Add(UserCastle.m_sName);
            //        }
            //    }
            //} finally {
            //    M2Share.g_CastleManager.UnLock();
            //}
        }

        private void RefCastleAttackSabukWall()
        {
            int I;
            ListViewItem ListItem;
            TAttackerInfo AttackerInfo;
            nCount = 0;
            ListViewAttackSabukWall.Items.Clear();
            //ListViewAttackSabukWall.Items.BeginUpdate;
            //try {
            //    if (CurCastle.m_AttackWarList.Count > 0)
            //    {
            //        // 20080630
            //        for (I = 0; I < CurCastle.m_AttackWarList.Count; I ++ )
            //        {
            //            AttackerInfo = ((TAttackerInfo)(CurCastle.m_AttackWarList[I]));
            //            ListItem = ListViewAttackSabukWall.Items.Add();
            //            if (AttackerInfo != null)
            //            {
            //                ListItem.Text = (nCount).ToString();
                            
            //                ListItem.SubItems.AddObject(AttackerInfo.sGuildName, ((AttackerInfo) as Object));
            //                ListItem.SubItems.Add((AttackerInfo.AttackDate).ToString());
            //                nCount ++;
            //            }
            //        }
            //    }
            //} finally {
            //    ListViewAttackSabukWall.Items.EndUpdate;
            //}
        }

        public void ListViewCastleClick(object sender, EventArgs e)
        {
            //ListViewItem ListItem;
            
            //ListItem = ListViewCastle.Selected;
            //if (ListItem == null)
            //{
            //    return;
            //}
            
            //CurCastle = ((TUserCastle)(ListItem.SubItems.Objects[0]));
            //RefCastleInfo();
            //if (CurCastle != null)
            //{
            //    if (CurCastle.m_boUnderWar)
            //    {
            //        Button2.Text = "关闭攻城";
            //    }
            //    else
            //    {
            //        Button2.Text = "开始攻城";
            //    }
            //    Button2.Enabled = true;
            //}
        }

        public void ButtonRefreshClick(object sender, EventArgs e)
        {
            RefCastleInfo();
        }

        public TGUild InListOfGuildName(string sGuildName)
        {
            TGUild result;
            int I;
            TGUild Guild;
            result = null;
            if (M2Share.g_GuildManager.GuildList.Count > 0)
            {
                for (I = 0; I < M2Share.g_GuildManager.GuildList.Count; I ++ )
                {
                    Guild = M2Share.g_GuildManager.GuildList[I];
                    if ((sGuildName).ToLower().CompareTo((Guild.sGuildName).ToLower()) == 0)
                    {
                        result = Guild;
                        break;
                    }
                }
            }
            return result;
        }

        public bool AddAttackSabukWallOfGuild(string sGuildName, DateTime AttackSabukWall)
        {
            bool result;
            TAttackerInfo AttackerInfo;
            TGUild Guild;
            ListViewItem ListItem;
            result = false;
            Guild = InListOfGuildName(sGuildName);
            if (Guild == null)
            {
                System.Windows.Forms.MessageBox.Show("输入的行会名不存在！！！", "提示信息", MessageBoxButtons.OK);
                return result;
            }
            if (CurCastle == null)
            {
                return result;
            }
            AttackerInfo = new TAttackerInfo();
            AttackerInfo.AttackDate = AttackSabukWall;
            AttackerInfo.sGuildName = sGuildName;
            AttackerInfo.Guild = Guild;
            CurCastle.m_AttackWarList.Add(AttackerInfo);
            
            //ListViewAttackSabukWall.Items.BeginUpdate;
            //try {
            //    ListItem = ListViewAttackSabukWall.Items.Add();
            //    nCount ++;
            //    ListItem.Text = (nCount).ToString();
                
            //    ListItem.SubItems.AddObject(AttackerInfo.sGuildName, ((AttackerInfo) as Object));
            //    ListItem.SubItems.Add((AttackerInfo.AttackDate).ToString());
            //    CurCastle.Save();
            //    result = true;
            //} finally {
                
            //    ListViewAttackSabukWall.Items.EndUpdate;
            //}
            return result;
        }

        public bool IsAttackSabukWallOfGuild(string sGuildName, DateTime AttackDate)
        {
            bool result;
            int I;
            ListViewItem ListItem;
            TAttackerInfo AttackerInfo;
            result = false;
            if (ListViewAttackSabukWall.Items.Count > 0)
            {
                //for (I = 0; I < ListViewAttackSabukWall.Items.Count; I ++ )
                //{
                //    ListItem = ListViewAttackSabukWall.Items[I];
                    
                //    AttackerInfo = ((TAttackerInfo)(ListItem.SubItems.Objects[0]));
                //    if (((sGuildName).ToLower().CompareTo((AttackerInfo.sGuildName).ToLower()) == 0) && (AttackerInfo.AttackDate == AttackDate))
                //    {
                //        result = true;
                //        break;
                //    }
                //}
            }
            return result;
        }

        public bool ChgAttackSabukWallOfGuild(string sGuildName, DateTime AttackSabukWall)
        {
            bool result;
            TAttackerInfo AttackerInfo;
            TGUild Guild;
            ListViewItem ListItem;
            int I;
            bool boFound;
            result = false;
            boFound = false;
            Guild = InListOfGuildName(sGuildName);
            if (Guild == null)
            {
                System.Windows.Forms.MessageBox.Show("输入的行会名不存在！！！", "提示信息", MessageBoxButtons.OK);
                return result;
            }
            if (CurCastle == null)
            {
                return result;
            }
            if (ListViewAttackSabukWall.Items.Count > 0)
            {
                for (I = 0; I < ListViewAttackSabukWall.Items.Count; I ++ )
                {
                    ListItem = ListViewAttackSabukWall.Items[I];
                    //AttackerInfo = ((TAttackerInfo)(ListItem.SubItems.Objects[0]));
                    //if ((sGuildName).ToLower().CompareTo((AttackerInfo.sGuildName).ToLower()) == 0)
                    //{
                    //    AttackerInfo.AttackDate = AttackSabukWall;
                    //    AttackerInfo.sGuildName = sGuildName;
                    //    ListItem.SubItems.Strings[0] = sGuildName;
                    //    ListItem.SubItems.Strings[1] = (AttackSabukWall).ToString();
                    //    CurCastle.Save();
                    //    boFound = true;
                    //    result = true;
                    //    break;
                    //}
                }
            }
            if (!boFound)
            {
                result = AddAttackSabukWallOfGuild(sGuildName, AttackSabukWall);
            }
            return result;
        }

        public void ButtonAttackAdClick(object sender, EventArgs e)
        {
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall = new TFrmAttackSabukWall(this.Owner);
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Text = "增加攻城申请";
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.nStute = 0;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Top = frmCastleManage.Top - 50;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Left = frmCastleManage.Left + 150;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Open();
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Free;
        }

        public void ButtonAttackEditClick(object sender, EventArgs e)
        {
            if (CurCastle == null)
            {
                return;
            }
            if (SelAttackGuildInfo == null)
            {
                return;
            }
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall = new TFrmAttackSabukWall(this.Owner);
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Text = "编辑攻城申请";
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.nStute = 1;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Top = frmCastleManage.Top - 50;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Left = frmCastleManage.Left + 150;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.m_sGuildName = SelAttackGuildInfo.sGuildName;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.m_AttackDate = SelAttackGuildInfo.AttackDate;
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Open();
            //AttackSabukWallConfig.Units.AttackSabukWallConfig.FrmAttackSabukWall.Free;
        }

        public void ListViewAttackSabukWallClick(object sender, EventArgs e)
        {
            //ListViewItem ListItem;
            //try {
                
            //    ListItem = ListViewAttackSabukWall.Selected;
                
            //    SelAttackGuildInfo = ((TAttackerInfo)(ListItem.SubItems.Objects[0]));
            //}
            //catch {
            //    SelAttackGuildInfo = null;
            //}
        }

        public void ButtonAttackRClick(object sender, EventArgs e)
        {
            if (CurCastle == null)
            {
                return;
            }
            RefCastleAttackSabukWall();
        }

        public void ButtonAttackDelClick(object sender, EventArgs e)
        {
            TAttackerInfo AttackerInfo;
            if (CurCastle == null)
            {
                return;
            }
            if (SelAttackGuildInfo == null)
            {
                return;
            }
            if (MessageBox.Show(("是否确认删除此行会攻城申请？" + "\n\n" + "行会名称："
                + SelAttackGuildInfo.sGuildName + '\n' + "攻城时间：" + SelAttackGuildInfo.AttackDate).ToString(), "确认信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int I = CurCastle.m_AttackWarList.Count - 1; I >= 0; I-- )
                {
                    if (CurCastle.m_AttackWarList.Count <= 0)
                    {
                        break;
                    }
                    AttackerInfo = ((TAttackerInfo)(CurCastle.m_AttackWarList[I]));
                    if (AttackerInfo == SelAttackGuildInfo)
                    {
                        CurCastle.m_AttackWarList.RemoveAt(I);
                        CurCastle.Save();
                        break;
                    }
                }
                try {
                    //ListViewAttackSabukWall.DeleteSelected;
                }
                catch {
                }
            }
        }

        public void ButtonSaveClick(object sender, EventArgs e)
        {
            if (CurCastle == null)
            {
                return;
            }
            CurCastle.m_sHomeMap = EditHomeMap.Text;
            CurCastle.m_sPalaceMap = EditPalace.Text;
            CurCastle.m_sHomeMap = EditHomeMap.Text;
            CurCastle.m_nHomeX = (int)SpinEditNomeX.Value;
            CurCastle.m_nHomeY = (int)SpinEditNomeY.Value;
            CurCastle.m_sSecretMap = EditTunnelMap.Text;
            CurCastle.Save();
            ButtonSave.Enabled = false;
        }

        public void Button1Click(object sender, EventArgs e)
        {
            TGUild Guild;
            bool boIsOK;
            try {
                boIsOK = false;
                if (CurCastle == null)
                {
                    return;
                }
                if (EditOwenGuildName.Text != "")
                {
                    if (M2Share.g_GuildManager.GuildList.Count > 0)
                    {
                        for (int I = 0; I < M2Share.g_GuildManager.GuildList.Count; I ++ )
                        {
                            Guild = M2Share.g_GuildManager.GuildList[I];
                            if ((Guild.sGuildName).ToLower().CompareTo((EditOwenGuildName.Text).ToLower()) == 0)
                            {
                                boIsOK = true;
                                CurCastle.GetCastle(Guild);// 占领城堡
                                break;
                            }
                        }
                    }
                }
                if (!boIsOK)
                {
                    MessageBox.Show("输入的行会不存在!", "提示信息", MessageBoxButtons.OK);
                }
                Button1.Enabled = false;
            }
            catch {
                M2Share.MainOutMessage("{异常} TfrmCastleManage.Button1Click");
            }
        }

        public void EditOwenGuildNameClick(object sender, EventArgs e)
        {
            Button1.Enabled = true;
        }

        public void Button2Click(object sender, EventArgs e)
        {
            string s20;
            TGUild Guild;
            int I;
            if (CurCastle == null)
            {
                Button2.Enabled = false;
                return;
            }
            CurCastle.m_boUnderWar = !CurCastle.m_boUnderWar;// 设置为攻城
            if (CurCastle.m_boUnderWar)// 正在攻城
            {
                if (M2Share.g_GuildManager.GuildList.Count > 0) // 增加所有行会为攻城行会
                {
                    for (I = 0; I < M2Share.g_GuildManager.GuildList.Count; I ++ )
                    {
                        Guild = ((TGUild)(M2Share.g_GuildManager.GuildList[I]));
                        CurCastle.m_AttackGuildList.Add(Guild);
                    }
                }
                CurCastle.m_boShowOverMsg = false;
                CurCastle.m_WarDate = DateTime.Now;
                //CurCastle.m_dwStartCastleWarTick = GetTickCount();
                CurCastle.StartWallconquestWar();
                //UserEngine.SendServerGroupMsg(Grobal2.SS_212, M2Share.nServerIndex, "");
                s20 = "[" + CurCastle.m_sName + " 攻城战已经开始]";
                M2Share.UserEngine.SendBroadCastMsg(s20, TMsgType.t_System);
                //UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.nServerIndex, s20);
                CurCastle.MainDoorControl(true);
                M2Share.MainOutMessage(s20);
                Button2.Text = "关闭攻城";
            }
            else
            {
                CurCastle.StopWallconquestWar();
                Button2.Text = "开始攻城";
            }
            Button2.Enabled = false;
        }

        public void FormClose(object sender, EventArgs e)
        {
            //Action = caFree;
        }

        public void FormDestroy(Object Sender)
        {
            frmCastleManage = null;
        }
    } 
}