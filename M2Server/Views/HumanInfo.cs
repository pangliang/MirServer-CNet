/****************************************************************
 ** 文件名：HumanInfo.cs
 ** Copyright(c)2012-2020 JohnSoft
 ** 创建人：陶志强
 ** 日  期：2013-4-22
 ** 修改人：
 ** 日  期：
 ** 描  述：在线列表 详细信息
 ****************************************************************/
using System;
using System.Windows.Forms;
using GameFramework;
using System.Text;

namespace M2Server
{
    public partial class TfrmHumanInfo: Form
    {
        public static bool boRefHuman = false;//实时监控
        public TPlayObject PlayObject = null;//当前玩家

        /****************************************************************
        ** 函 数 名：TfrmHumanInfo
        ** 功能描述：构造函数
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-22
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public TfrmHumanInfo()
        {
            InitializeComponent();
        }

        /****************************************************************
        ** 函 数 名：TfrmHumanInfo_Load
        ** 功能描述：窗体载入
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-22
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void TfrmHumanInfo_Load(object sender, EventArgs e)
        {
            GridUserItem.Columns.Add("装备位置");
            GridUserItem.Columns.Add("装备名称");
            GridUserItem.Columns.Add("系列号");
            GridUserItem.Columns.Add("持久");
            GridUserItem.Columns.Add("攻");
            GridUserItem.Columns.Add("魔");
            GridUserItem.Columns.Add("道");
            GridUserItem.Columns.Add("防");
            GridUserItem.Columns.Add("魔防");
            GridUserItem.Columns.Add("附加属性");
            GridUserItem.Items.Add("衣服");
            GridUserItem.Items.Add("武器");
            GridUserItem.Items.Add("照明物");
            GridUserItem.Items.Add("项链");
            GridUserItem.Items.Add("头盔");
            GridUserItem.Items.Add("左手镯");
            GridUserItem.Items.Add("右手镯");
            GridUserItem.Items.Add("左戒指");
            GridUserItem.Items.Add("右戒指");
            GridUserItem.Items.Add("物品");
            GridUserItem.Items.Add("腰带");
            GridUserItem.Items.Add("鞋子");
            GridUserItem.Items.Add("宝石");
            foreach (ListViewItem lvItem in GridUserItem.Items)
            {
                for (int i = 1; i <= 9; i++)
                {
                    lvItem.SubItems.Add("");
                }
            }

            GridBagItem.Columns.Add("序号");
            GridBagItem.Columns.Add("装备名称");
            GridBagItem.Columns.Add("系列号");
            GridBagItem.Columns.Add("持久");
            GridBagItem.Columns.Add("攻");
            GridBagItem.Columns.Add("魔");
            GridBagItem.Columns.Add("道");
            GridBagItem.Columns.Add("防");
            GridBagItem.Columns.Add("魔防");
            GridBagItem.Columns.Add("附加属性");

            GridStorageItem.Columns.Add("序号");
            GridStorageItem.Columns.Add("装备名称");
            GridStorageItem.Columns.Add("系列号");
            GridStorageItem.Columns.Add("持久");
            GridStorageItem.Columns.Add("攻");
            GridStorageItem.Columns.Add("魔");
            GridStorageItem.Columns.Add("道");
            GridStorageItem.Columns.Add("防");
            GridStorageItem.Columns.Add("魔防");
            GridStorageItem.Columns.Add("附加属性");

            GridHeroUserItem.Columns.Add("装备位置");
            GridHeroUserItem.Columns.Add("装备名称");
            GridHeroUserItem.Columns.Add("系列号");
            GridHeroUserItem.Columns.Add("持久");
            GridHeroUserItem.Columns.Add("攻");
            GridHeroUserItem.Columns.Add("魔");
            GridHeroUserItem.Columns.Add("道");
            GridHeroUserItem.Columns.Add("防");
            GridHeroUserItem.Columns.Add("魔防");
            GridHeroUserItem.Columns.Add("附加属性");
            GridHeroUserItem.Items.Add("衣服");
            GridHeroUserItem.Items.Add("武器");
            GridHeroUserItem.Items.Add("照明物");
            GridHeroUserItem.Items.Add("项链");
            GridHeroUserItem.Items.Add("头盔");
            GridHeroUserItem.Items.Add("左手镯");
            GridHeroUserItem.Items.Add("右手镯");
            GridHeroUserItem.Items.Add("左戒指");
            GridHeroUserItem.Items.Add("右戒指");
            GridHeroUserItem.Items.Add("物品");
            GridHeroUserItem.Items.Add("腰带");
            GridHeroUserItem.Items.Add("鞋子");
            GridHeroUserItem.Items.Add("宝石");
            foreach (ListViewItem lvItem in GridHeroUserItem.Items)
            {
                for (int i = 1; i <= 9; i++)
                {
                    lvItem.SubItems.Add("");
                }
            }

            GridHeroBagItem.Columns.Add("序号");
            GridHeroBagItem.Columns.Add("装备名称");
            GridHeroBagItem.Columns.Add("系列号");
            GridHeroBagItem.Columns.Add("持久");
            GridHeroBagItem.Columns.Add("攻");
            GridHeroBagItem.Columns.Add("魔");
            GridHeroBagItem.Columns.Add("道");
            GridHeroBagItem.Columns.Add("防");
            GridHeroBagItem.Columns.Add("魔防");
            GridHeroBagItem.Columns.Add("附加属性");

            PageControl1.SelectedIndex = 0;
            //PageControl1.TabPages[6].TabVisible = true;
            //PageControl1.TabPages[7].TabVisible = true;
            //PageControl1.TabPages[8].TabVisible = true;
            //PageControl1.TabPages[6].TabVisible = false;
            //PageControl1.TabPages[7].TabVisible = false;
            //PageControl1.TabPages[8].TabVisible = false;

            PageControl1.SelectedTab = TabSheet1;
            // 20080901 增加
            RefHumanInfo();
            ButtonKick.Enabled = true;
            Timer.Enabled = true;
            CheckBoxMonitor.Checked = false;
        }

        /****************************************************************
        ** 函 数 名：RefHumanInfo
        ** 功能描述：刷新表格
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-22
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private unsafe void RefHumanInfo()
        {
            int i;
            int nTotleUsePoint;
            TStdItem StdItem;
            TStdItem *Item;
            TUserItem* UserItem;
            if ((PlayObject == null))
            {
                return;
            }
            if (PlayObject.m_boNotOnlineAddExp)
            {
                EditSayMsg.Enabled = true;
            }
            else
            {
                EditSayMsg.Enabled = false;
            }
            EditSayMsg.Text = PlayObject.m_sAutoSendMsg;
            EditName.Text = PlayObject.m_sCharName;
            EditMap.Text = PlayObject.m_sMapName + "(" + PlayObject.m_PEnvir.sMapDesc + ")";
            EditXY.Text = (PlayObject.m_nCurrX).ToString() + ":" + (PlayObject.m_nCurrY).ToString();
            EditAccount.Text = PlayObject.m_sUserID;
            EditIPaddr.Text = PlayObject.m_sIPaddr;
            EditLogonTime.Text = (PlayObject.m_dLogonTime).ToString();
            EditLogonLong.Text = ((HUtil32.GetTickCount() - PlayObject.m_dwLogonTick) / 60000).ToString() + " 分钟";//登陆时间(分)// (60 * 1000)
            EditLevel.Value = PlayObject.m_Abil.Level;
            EditGold.Value = PlayObject.m_nGold;
            EditPKPoint.Value = PlayObject.m_nPkPoint;
            EditExp.Value = PlayObject.m_Abil.Exp;
            EditMaxExp.Value = PlayObject.m_Abil.MaxExp;
            if (PlayObject.m_boTrainingNG)
            {
                EditNGLevel.Enabled = true;
                EditExpSkill69.Enabled = true;
                EditNGLevel.Value = PlayObject.m_NGLevel;
                // 20081005 内功等级
                EditExpSkill69.Value = PlayObject.m_ExpSkill69;
            // 20081005 内功心法当前经验
            }
            
            
            EditAC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.AC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.AC)).ToString();
            // 防御
            
            
            EditMAC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.MAC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.MAC)).ToString();
            // 魔防
            
            
            EditDC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.DC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.DC)).ToString();
            // 攻击力
            
            
            EditMC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.MC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.MC)).ToString();
            // 魔法
            
            
            EditSC.Text = (HUtil32.LoWord(PlayObject.m_WAbil.SC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.SC)).ToString();
            // 道术
            EditHP.Text = (PlayObject.m_WAbil.HP).ToString() + "/" + (PlayObject.m_WAbil.MaxHP).ToString();
            EditMP.Text = (PlayObject.m_WAbil.MP).ToString() + "/" + (PlayObject.m_WAbil.MaxMP).ToString();
            EditGameGold.Value = PlayObject.m_nGameGold;
            EditGameDiaMond.Value = PlayObject.m_nGAMEDIAMOND;
            // 金刚石
            EditGameGird.Value = PlayObject.m_nGAMEGIRD;
            // 灵符
            EditGamePoint.Value = PlayObject.m_nGamePoint;
            EditCreditPoint.Value = PlayObject.m_btCreditPoint;
            EditBonusPoint.Value = PlayObject.m_nBonusPoint;
            nTotleUsePoint = PlayObject.m_BonusAbil.DC + PlayObject.m_BonusAbil.MC + PlayObject.m_BonusAbil.SC + PlayObject.m_BonusAbil.AC + PlayObject.m_BonusAbil.MAC + PlayObject.m_BonusAbil.HP + PlayObject.m_BonusAbil.MP + PlayObject.m_BonusAbil.Hit + PlayObject.m_BonusAbil.Speed + PlayObject.m_BonusAbil.X2;
            EditEditBonusPointUsed.Value = nTotleUsePoint;
            CheckBoxGameMaster.Checked = PlayObject.m_boAdminMode;
            CheckBoxSuperMan.Checked = PlayObject.m_boSuperMan;
            CheckBoxObserver.Checked = PlayObject.m_boObMode;
            if (PlayObject.m_boDeath)
            {
                EditHumanStatus.Text = "死亡";
            }
            else if (PlayObject.m_boGhost)
            {
                EditHumanStatus.Text = "下线";
                PlayObject = null;
            }
            else
            {
                EditHumanStatus.Text = "在线";
            }

            //身上物品
            for (i = PlayObject.m_UseItems.GetLowerBound(0); i <= PlayObject.m_UseItems.GetUpperBound(0); i ++ )
            {
                UserItem = PlayObject.m_UseItems[i];
                if (UserItem->wIndex == 0) continue;
                StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem.Name == null)
                {
                    GridUserItem.Items[i].SubItems[1].Text="";
                    GridUserItem.Items[i].SubItems[2].Text="";
                    GridUserItem.Items[i].SubItems[3].Text="";
                    GridUserItem.Items[i].SubItems[4].Text="";
                    GridUserItem.Items[i].SubItems[5].Text="";
                    GridUserItem.Items[i].SubItems[6].Text="";
                    GridUserItem.Items[i].SubItems[7].Text="";
                    GridUserItem.Items[i].SubItems[8].Text="";
                    GridUserItem.Items[i].SubItems[9].Text="";
                    continue;
                }
                Item = &StdItem;
                M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                GridUserItem.Items[i].SubItems[1].Text = (HUtil32.SBytePtrToString(Item->Name, (int)Item->NameLen));
                GridUserItem.Items[i].SubItems[2].Text = (UserItem->MakeIndex.ToString());
                GridUserItem.Items[i].SubItems[3].Text = (string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                GridUserItem.Items[i].SubItems[4].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                GridUserItem.Items[i].SubItems[5].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                GridUserItem.Items[i].SubItems[6].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                GridUserItem.Items[i].SubItems[7].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                GridUserItem.Items[i].SubItems[8].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                GridUserItem.Items[i].SubItems[9].Text = (string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
            }

            //背包
            i = 0;
            GridBagItem.Items.Clear();
            foreach(IntPtr pItem in PlayObject.m_ItemList)
            {
                UserItem = (TUserItem*)pItem;
                StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem.Name == null)
                {
                    GridBagItem.Items[i].SubItems[1].Text = "";
                    GridBagItem.Items[i].SubItems[2].Text = "";
                    GridBagItem.Items[i].SubItems[3].Text = "";
                    GridBagItem.Items[i].SubItems[4].Text = "";
                    GridBagItem.Items[i].SubItems[5].Text = "";
                    GridBagItem.Items[i].SubItems[6].Text = "";
                    GridBagItem.Items[i].SubItems[7].Text = "";
                    GridBagItem.Items[i].SubItems[8].Text = "";
                    GridBagItem.Items[i].SubItems[9].Text = "";
                    continue;
                }
                Item = &StdItem;
                M2Share.ItemUnit.GetItemAddValue(UserItem,Item);
                ListViewItem lvItem = GridBagItem.Items.Add(i.ToString());
                lvItem.SubItems.Add(HUtil32.SBytePtrToString(Item->Name,Item->NameLen));
                lvItem.SubItems.Add(UserItem->MakeIndex.ToString());
                lvItem.SubItems.Add(string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                i++;
            }

            //仓库
            i = 0;
            GridStorageItem.Items.Clear();
            foreach (IntPtr pItem in PlayObject.m_StorageItemList)
            {
                UserItem = (TUserItem*)pItem;
                StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem.Name == null)
                {
                    GridStorageItem.Items[i].SubItems[1].Text = "";
                    GridStorageItem.Items[i].SubItems[2].Text = "";
                    GridStorageItem.Items[i].SubItems[3].Text = "";
                    GridStorageItem.Items[i].SubItems[4].Text = "";
                    GridStorageItem.Items[i].SubItems[5].Text = "";
                    GridStorageItem.Items[i].SubItems[6].Text = "";
                    GridStorageItem.Items[i].SubItems[7].Text = "";
                    GridStorageItem.Items[i].SubItems[8].Text = "";
                    GridStorageItem.Items[i].SubItems[9].Text = "";
                    continue;
                }
                Item = &StdItem;
                M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                ListViewItem lvItem = GridStorageItem.Items.Add(i.ToString());
                lvItem.SubItems.Add(HUtil32.SBytePtrToString(Item->Name, Item->NameLen));
                lvItem.SubItems.Add(UserItem->MakeIndex.ToString());
                lvItem.SubItems.Add(string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                lvItem.SubItems.Add(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                i++;
            }

//#if HEROVERSION = 1 //判断是否为英雄版本的M2

            try 
            {
                if (PlayObject.m_MyHero == null)
                {
                    return;
                }
                EditHeroName.Text = PlayObject.m_MyHero.m_sCharName;
                EditHeroMap.Text = PlayObject.m_MyHero.m_sMapName + "(" + PlayObject.m_PEnvir.sMapDesc + ")";
                EditHeroXY.Text = (PlayObject.m_MyHero.m_nCurrX).ToString() + ":" + (PlayObject.m_MyHero.m_nCurrY).ToString();
                EditHeroLevel.Value = PlayObject.m_MyHero.m_Abil.Level;
                EditHeroPKPoint.Value = PlayObject.m_MyHero.m_nPkPoint;
                EditHeroExp.Value = PlayObject.m_MyHero.m_Abil.Exp;
                EditHeroMaxExp.Value = PlayObject.m_MyHero.m_Abil.MaxExp;
                EditHeroLoyal.Value = ((THeroObject)(PlayObject.m_MyHero)).m_nLoyal;
                // 英雄的忠诚度(20080110)
                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
                {
                    EditHeroNGLevel.Enabled = true;
                    EditHeroExpSkill69.Enabled = true;
                    EditHeroNGLevel.Value = ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel;
                    // 20081005 内功等级
                    EditHeroExpSkill69.Value = ((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69;
                // 20081005 内功心法当前经验
                }


                //身上物品
                for (i = PlayObject.m_MyHero.m_UseItems.GetLowerBound(0); i <= PlayObject.m_UseItems.GetUpperBound(0); i++)
                {
                    UserItem = PlayObject.m_UseItems[i];
                    if (UserItem->wIndex == 0) continue;
                    StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem.Name == null)
                    {
                        GridHeroUserItem.Items[i].SubItems[1].Text = "";
                        GridHeroUserItem.Items[i].SubItems[2].Text = "";
                        GridHeroUserItem.Items[i].SubItems[3].Text = "";
                        GridHeroUserItem.Items[i].SubItems[4].Text = "";
                        GridHeroUserItem.Items[i].SubItems[5].Text = "";
                        GridHeroUserItem.Items[i].SubItems[6].Text = "";
                        GridHeroUserItem.Items[i].SubItems[7].Text = "";
                        GridHeroUserItem.Items[i].SubItems[8].Text = "";
                        GridHeroUserItem.Items[i].SubItems[9].Text = "";
                        continue;
                    }
                    Item = &StdItem;
                    M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                    GridHeroUserItem.Items[i].SubItems[1].Text = (HUtil32.SBytePtrToString(Item->Name, (int)Item->NameLen));
                    GridHeroUserItem.Items[i].SubItems[2].Text = (UserItem->MakeIndex.ToString());
                    GridHeroUserItem.Items[i].SubItems[3].Text = (string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                    GridHeroUserItem.Items[i].SubItems[4].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                    GridHeroUserItem.Items[i].SubItems[5].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                    GridHeroUserItem.Items[i].SubItems[6].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                    GridHeroUserItem.Items[i].SubItems[7].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                    GridHeroUserItem.Items[i].SubItems[8].Text = (string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                    GridHeroUserItem.Items[i].SubItems[9].Text = (string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                }

                //背包
                i = 0;
                GridHeroBagItem.Items.Clear();
                foreach (IntPtr pItem in PlayObject.m_MyHero.m_ItemList)
                {
                    UserItem = (TUserItem*)pItem;
                    StdItem = *M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem.Name == null)
                    {
                        GridHeroBagItem.Items[i].SubItems[1].Text = "";
                        GridHeroBagItem.Items[i].SubItems[2].Text = "";
                        GridHeroBagItem.Items[i].SubItems[3].Text = "";
                        GridHeroBagItem.Items[i].SubItems[4].Text = "";
                        GridHeroBagItem.Items[i].SubItems[5].Text = "";
                        GridHeroBagItem.Items[i].SubItems[6].Text = "";
                        GridHeroBagItem.Items[i].SubItems[7].Text = "";
                        GridHeroBagItem.Items[i].SubItems[8].Text = "";
                        GridHeroBagItem.Items[i].SubItems[9].Text = "";
                        continue;
                    }
                    Item = &StdItem;
                    M2Share.ItemUnit.GetItemAddValue(UserItem, Item);
                    ListViewItem lvItem = GridHeroBagItem.Items.Add(i.ToString());
                    lvItem.SubItems.Add(HUtil32.SBytePtrToString(Item->Name, Item->NameLen));
                    lvItem.SubItems.Add(UserItem->MakeIndex.ToString());
                    lvItem.SubItems.Add(string.Format("{0}/{1}", UserItem->Dura, UserItem->DuraMax));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->DC), HUtil32.HiWord(Item->DC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MC), HUtil32.HiWord(Item->MC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->SC), HUtil32.HiWord(Item->SC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->AC), HUtil32.HiWord(Item->AC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}", HUtil32.LoWord(Item->MAC), HUtil32.HiWord(Item->MAC)));
                    lvItem.SubItems.Add(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]));
                    i++;
                }
            }
            catch {
            }


        }

        /****************************************************************
        ** 函 数 名：Timer_Tick
        ** 功能描述：实时时钟
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-22
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (PlayObject == null)
            {
                return;
            }
            if (PlayObject.m_boGhost)
            {
                EditHumanStatus.Text = "下线";
                PlayObject = null;
                return;
            }
            if (boRefHuman)
            {
                RefHumanInfo();
            }
        }

        /****************************************************************
        ** 函 数 名：CheckBoxMonitor_CheckedChanged
        ** 功能描述：实时监控
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-22
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void CheckBoxMonitor_CheckedChanged(object sender, EventArgs e)
        {
            boRefHuman = CheckBoxMonitor.Checked;
            ButtonSave.Enabled = !boRefHuman;
        }

        /****************************************************************
        ** 函 数 名：ButtonKick_Click
        ** 功能描述：踢下线按钮
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-22
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void ButtonKick_Click(object sender, EventArgs e)
        {
            if (PlayObject == null)
            {
                return;
            }
            PlayObject.m_boEmergencyClose = true;
            PlayObject.m_boNotOnlineAddExp = false;
            PlayObject.m_boPlayOffLine = false;
            ButtonKick.Enabled = false;
        }

        /****************************************************************
        ** 函 数 名：ButtonSave_Click
        ** 功能描述：修改数据按钮
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-22
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            int nLevel;
            int nGold;
            int nPKPOINT;
            int nGameGold;
            int nGameDiaMond;
            // 20071226 金刚石
            int nGameGird;
            // 20071226 灵符
            int nLoyal;
            // 英雄的忠诚度(20080109)
            int nGamePoint;
            int nCreditPoint;
            int nBonusPoint;
            bool boGameMaster;
            bool boObServer;
            bool boSuperman;
            string sAutoSendMsg;
            if (PlayObject == null)
            {
                return;
            }
            sAutoSendMsg = EditSayMsg.Text.Trim();
            nLevel = (int)EditLevel.Value;
            nGold = (int)EditGold.Value;
            nPKPOINT = (int)EditPKPoint.Value;
            nGameGold = (int)EditGameGold.Value;
            nGameDiaMond = (int)EditGameDiaMond.Value;
            // 20071226 金刚石
            nGameGird = (int)EditGameGird.Value;
            // 20071226 灵符
            nLoyal = (int)EditHeroLoyal.Value;
            // 英雄的忠诚度(20080109)
            nGamePoint = (int)EditGamePoint.Value;
            nCreditPoint = (int)EditCreditPoint.Value;
            nBonusPoint = (int)EditBonusPoint.Value;
            boGameMaster = CheckBoxGameMaster.Checked;
            boObServer = CheckBoxObserver.Checked;
            boSuperman = CheckBoxSuperMan.Checked;

            // (*or (nCreditPoint > High(Integer{Byte}))*)
            // 20080118
            if ((nLevel < 0) || (nLevel > ushort.MaxValue) || (nGold < 0) || (nGold > 200000000) || (nPKPOINT < 0) || (nPKPOINT > 2000000) || (nCreditPoint < 0) || (nBonusPoint < 0) || (nBonusPoint > 20000000) || (nLoyal > 10000))
            {
                MessageBox.Show("输入数据不正确！！！", "错误信息",System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }
            PlayObject.m_sAutoSendMsg = sAutoSendMsg;
            if (PlayObject.m_Abil.Level != nLevel)
            {
                // 等级调整记录日志 20081102
                M2Share.AddGameDataLog("17" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString() + "\09" + PlayObject.m_sCharName + "\09" + (PlayObject.m_Abil.Level).ToString() + "\09" + "0" + "\09" + "调整(" + (nLevel).ToString() + ")" + "\09" + "在线人物窗口");
            }
            PlayObject.m_Abil.Level = (ushort)nLevel;
            PlayObject.m_nGold = nGold;
            PlayObject.m_nPkPoint = nPKPOINT;
            PlayObject.m_nGameGold = nGameGold;
            PlayObject.m_nGAMEDIAMOND = nGameDiaMond;
            // 20071226 金刚石
            PlayObject.m_nGAMEGIRD = nGameGird;
            // 20071226 灵符
            PlayObject.m_nGamePoint = (ushort)nGamePoint;
            PlayObject.m_btCreditPoint = nCreditPoint;
            PlayObject.m_nBonusPoint = nBonusPoint;
            PlayObject.m_boAdminMode = boGameMaster;
            PlayObject.m_boObMode = boObServer;
            PlayObject.m_boSuperMan = boSuperman;
            if (PlayObject.m_boTrainingNG)
            {
                PlayObject.m_NGLevel = (byte)EditNGLevel.Value;
                // 20081005 内功等级
                PlayObject.m_ExpSkill69 = (uint)EditExpSkill69.Value;
                // 20081005 内功心法当前经验
                PlayObject.SendNGData();
            // 发送内功数据 20081005
            }
            PlayObject.GoldChanged();
            PlayObject.GameGoldChanged();
            // 20080211
            PlayObject.HasLevelUp(1);
            //#if HEROVERSION = 1
            if (PlayObject.m_MyHero != null)
            {
                nLevel = (int)EditHeroLevel.Value;
                nPKPOINT = (int)EditHeroPKPoint.Value;
                if (PlayObject.m_MyHero.m_Abil.Level != nLevel)
                {
                    // 等级调整记录日志 20081102
                    M2Share.AddGameDataLog("17" + "\09" + PlayObject.m_MyHero.m_sMapName + "\09" + (PlayObject.m_MyHero.m_nCurrX).ToString() + "\09" + (PlayObject.m_MyHero.m_nCurrY).ToString() + "\09" + PlayObject.m_MyHero.m_sCharName + "\09" + (PlayObject.m_MyHero.m_Abil.Level).ToString() + "\09" + "0" + "\09" + "调整(" + (nLevel).ToString() + ")" + "\09" + "在线人物窗口");
                }
                PlayObject.m_MyHero.m_Abil.Level = (ushort)nLevel;
                PlayObject.m_MyHero.m_nPkPoint = nPKPOINT;
                ((THeroObject)(PlayObject.m_MyHero)).m_nLoyal = nLoyal;
                // 英雄的忠诚度(20080110)
                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
                {
                    ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel = (byte)EditHeroNGLevel.Value;
                    // 20081005 内功等级
                    ((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69 = (uint)EditHeroExpSkill69.Value;
                    // 20081005 内功心法当前经验
                    PlayObject.m_MyHero.SendNGData();
                // 发送内功数据 20081005
                }
                PlayObject.m_MyHero.HasLevelUp(1);
            }
            MessageBox.Show("人物数据已保存。", "提示信息",System.Windows.Forms.MessageBoxButtons.OK);
        }



    } 
}