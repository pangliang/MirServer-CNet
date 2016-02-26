using GameFramework;
using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmGameConfig : Form
    {
        public static TfrmGameConfig frmGameConfig = null;
        private bool boOpened = false;
        private bool boModValued = false;

        public TfrmGameConfig()
        {
            InitializeComponent();
        }

        public void FormCreate(object sender, EventArgs e)
        {
            //int I;
            //ComboBoxLineNoticeColor.Items.Add("红色");
            //ComboBoxLineNoticeColor.Items.Add("绿色");
            //ComboBoxLineNoticeColor.Items.Add("蓝色");
            //GridLevelExp.PreferredColumnWidth[0] = 30;
            //GridLevelExp.PreferredColumnWidth[1] = 100;

            //GridLevelExp.Cells[0, 0] = "等级";

            //GridLevelExp.Cells[1, 0] = "经验值";

            //for (I = 1; I < GridLevelExp.RowCount; I ++ )
            //{
            //    GridLevelExp.Cells[0, I] = (I).ToString();
            //}

            //ComboBoxLevelExp.AddItem("原始经验值", ((TLevelExpScheme.s_OldLevelExp) as Object));

            //ComboBoxLevelExp.AddItem("标准经验值", ((TLevelExpScheme.s_StdLevelExp) as Object));

            //ComboBoxLevelExp.AddItem("当前1/2倍经验", ((TLevelExpScheme.s_2Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/5倍经验", ((TLevelExpScheme.s_5Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/8倍经验", ((TLevelExpScheme.s_8Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/10倍经验", ((TLevelExpScheme.s_10Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/20倍经验", ((TLevelExpScheme.s_20Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/30倍经验", ((TLevelExpScheme.s_30Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/40倍经验", ((TLevelExpScheme.s_40Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/50倍经验", ((TLevelExpScheme.s_50Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/60倍经验", ((TLevelExpScheme.s_60Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/70倍经验", ((TLevelExpScheme.s_70Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/80倍经验", ((TLevelExpScheme.s_80Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/90倍经验", ((TLevelExpScheme.s_90Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/100倍经验", ((TLevelExpScheme.s_100Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/150倍经验", ((TLevelExpScheme.s_150Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/200倍经验", ((TLevelExpScheme.s_200Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/250倍经验", ((TLevelExpScheme.s_250Mult) as Object));

            //ComboBoxLevelExp.AddItem("当前1/300倍经验", ((TLevelExpScheme.s_300Mult) as Object));

            //EditSoftVersionDate.Hint = "客户端版本日期设置，此参数默认为 20020522，此版本日期必须与客户端相匹配，否则在进入游戏时将提示版本不正确";

            //EditConsoleShowUserCountTime.Hint = "程序控制台上显示当前在线人数间隔时间，此参数默认为 15分钟。";

            //EditShowLineNoticeTime.Hint = "游戏中显示公告信息的间隔时间，此参数默认为 300秒。";

            //ComboBoxLineNoticeColor.Hint = "游戏中显示公告信息的文字颜色，此参数默认为 蓝色。";

            //EditLineNoticePreFix.Hint = "游戏中显示公告信息的文字行前缀文字。";

            //EditHitIntervalTime.Hint = "游戏中人物二次攻击间隔时间，此参数默认为 900毫秒。";

            //EditMagicHitIntervalTime.Hint = "游戏中人物二次魔法攻击间隔时间，此参数默认为 800毫秒。";

            //EditRunIntervalTime.Hint = "游戏中人物二次跑动间隔时间，此参数默认为 600毫秒。";

            //EditWalkIntervalTime.Hint = "游戏中人物二次走动间隔时间，此参数默认为 600毫秒。";

            //EditTurnIntervalTime.Hint = "游戏中人物二次变方向间隔时间，此参数默认为 600毫秒。";

            //EditItemSpeedTime.Hint = "装备加速属性速度控制，数字越小控制越严，此参数默认为 50毫秒。";

            //EditStruckTime.Hint = "人物被攻击后弯腰停留时间控制，此参数默认为 100毫秒。";

            //CheckBoxDisableStruck.Hint = "人物在被攻击后是否显示弯腰动作。";

            //GridLevelExp.Hint = "修改的经验在点击保存按钮后生效。";

            //ComboBoxLevelExp.Hint = "选择的经验计划，立即生效。";

            //EditKillMonExpMultiple.Hint = "人物杀怪物所得经验值倍，此参数默认为 1，此经验值以怪物数据库里的经验值为基准。";

            //CheckBoxHighLevelKillMonFixExp.Hint = "高等级人物杀怪经验是否保持不变，此参数默认为关闭(不打钩)。";

            //EditRepairDoorPrice.Hint = "维修城门所需费用，此参数默认为 2000000金币。";

            //EditRepairWallPrice.Hint = "维修城墙所需费用，此参数默认为 500000金币。";

            //EditHireArcherPrice.Hint = "雇用弓箭手所需费用，此参数默认为 300000金币。";

            //EditHireGuardPrice.Hint = "维修守卫所需费用，此参数默认为 300000金币。";

            //EditCastleGoldMax.Hint = "城堡内最高可存金币数量，此参数默认为 10000000金币。";

            //EditCastleOneDayGold.Hint = "城堡一天内最高收入上限，此参数默认为 2000000金币。";

            //EditCastleHomeMap.Hint = "行会回城点默认所在地图号，此参数默认地图号为 3，以城堡配置文件中的参数为准";

            //EditCastleHomeX.Hint = "行会回城点默认所在地图座标X，此参数默认座标为 644，以城堡配置文件中的参数为准";

            //EditCastleHomeY.Hint = "行会回城点默认所在地图座标Y，此参数默认座标为 290，以城堡配置文件中的参数为准";

            //EditCastleName.Hint = "城堡默认的名称，以城堡配置文件中的参数为准。";

            //EditWarRangeX.Hint = "攻城区域默认座标X范围大小，此参数默认为 100，以城堡配置文件中的参数为准";

            //EditWarRangeY.Hint = "攻城区域默认座标Y范围大小，此参数默认为 100，以城堡配置文件中的参数为准";

            //CheckBoxGetAllNpcTax.Hint = "是否收取所有交易NPC的交易税，此参数默认为关闭(不打钩)。";

            //EditTaxRate.Hint = "交易税率，此参为默认为 5，也就是 0.05%。";
        }

        public void GameConfigControlChanging(object sender, EventArgs e, ref bool AllowChange)
        {
            if (boModValued)
            {
                if (MessageBox.Show("参数设置已经被修改，是否确认不保存修改的设置？", "确认信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    uModValue();
                }
                else
                {
                    AllowChange = false;
                }
            }
        }

        private void ModValue()
        {
            boModValued = true;
            ButtonGameSpeedSave.Enabled = true;
            ButtonGeneralSave.Enabled = true;
            ButtonExpSave.Enabled = true;
            ButtonCastleSave.Enabled = true;
            ButtonOptionSave0.Enabled = true;
            ButtonOptionSave.Enabled = true;
            ButtonOptionSave2.Enabled = true;
            ButtonOptionSave3.Enabled = true;
            ButtonTimeSave.Enabled = true;
            ButtonPriceSave.Enabled = true;
            ButtonMsgSave.Enabled = true;
            ButtonMsgColorSave.Enabled = true;
            ButtonHumanDieSave.Enabled = true;
            ButtonCharStatusSave.Enabled = true;
        }

        private void uModValue()
        {
            boModValued = false;
            ButtonGameSpeedSave.Enabled = false;
            ButtonGeneralSave.Enabled = false;
            ButtonExpSave.Enabled = false;
            ButtonCastleSave.Enabled = false;
            ButtonOptionSave0.Enabled = false;
            ButtonOptionSave.Enabled = false;
            ButtonOptionSave2.Enabled = false;
            ButtonOptionSave3.Enabled = false;
            ButtonTimeSave.Enabled = false;
            ButtonPriceSave.Enabled = false;
            ButtonMsgSave.Enabled = false;
            ButtonMsgColorSave.Enabled = false;
            ButtonHumanDieSave.Enabled = false;
            ButtonCharStatusSave.Enabled = false;
        }

        public void Open()
        {
            boOpened = false;
            uModValue();
            RefGameSpeedConf();
            EditKillMonExpMultiple.Value = M2Share.g_Config.dwKillMonExpMultiple;
            CheckBoxHighLevelKillMonFixExp.Checked = M2Share.g_Config.boHighLevelKillMonFixExp;
            CheckBoxHighLevelGroupFixExp.Checked = M2Share.g_Config.boHighLevelGroupFixExp;
            CheckBoxSaveExpRate.Checked = M2Share.g_Config.boSaveExpRate;//是否保存双倍经验时间
            EditRepairDoorPrice.Value = M2Share.g_Config.nRepairDoorPrice;
            EditRepairWallPrice.Value = M2Share.g_Config.nRepairWallPrice;
            EditHireArcherPrice.Value = M2Share.g_Config.nHireArcherPrice;
            EditHireGuardPrice.Value = M2Share.g_Config.nHireGuardPrice;
            EditCastleGoldMax.Value = M2Share.g_Config.nCastleGoldMax;
            EditCastleOneDayGold.Value = M2Share.g_Config.nCastleOneDayGold;
            EditCastleHomeMap.Text = M2Share.g_Config.sCastleHomeMap;
            EditCastleHomeX.Value = M2Share.g_Config.nCastleHomeX;
            EditCastleHomeY.Value = M2Share.g_Config.nCastleHomeY;
            EditCastleName.Text = M2Share.g_Config.sCASTLENAME;
            EditWarRangeX.Value = M2Share.g_Config.nCastleWarRangeX;
            EditWarRangeY.Value = M2Share.g_Config.nCastleWarRangeY;
            CheckBoxGetAllNpcTax.Checked = M2Share.g_Config.boGetAllNpcTax;
            EditTaxRate.Value = M2Share.g_Config.nCastleTaxRate;

            //for (I = 1; I < GridLevelExp.RowCount; I++)
            //{
            //    GridLevelExp.Cells[1, I] = (M2Share.g_Config.dwNeedExps[I]).ToString();
            //}
            GroupBoxLevelExp.Text = string.Format("升级经验(最高有效等级{0})", new object[] { M2Share.MAXUPLEVEL });
            CheckBoxDisHumRun.Checked = !M2Share.g_Config.boDiableHumanRun;
            CheckBoxRunHum.Checked = M2Share.g_Config.boRUNHUMAN;
            CheckBoxRunMon.Checked = M2Share.g_Config.boRUNMON;
            CheckBoxRunNpc.Checked = M2Share.g_Config.boRunNpc;
            CheckBoxRunGuard.Checked = M2Share.g_Config.boRunGuard;
            CheckBoxWarDisHumRun.Checked = M2Share.g_Config.boWarDisHumRun;
            CheckBoxGMRunAll.Checked = M2Share.g_Config.boGMRunAll;
            CheckBoxSafeArea.Checked = M2Share.g_Config.boSafeAreaLimited;

            //CheckBoxDisHumRunClick(CheckBoxDisHumRun);
            EditSafeZoneSize.Value = M2Share.g_Config.nSafeZoneSize;
            EditStartPointSize.Value = M2Share.g_Config.nStartPointSize;
            EditGroupMembersMax.Value = M2Share.g_Config.nGroupMembersMax;
            EditRedHomeMap.Text = M2Share.g_Config.sRedHomeMap;
            EditRedHomeX.Value = M2Share.g_Config.nRedHomeX;
            EditRedHomeY.Value = M2Share.g_Config.nRedHomeY;
            EditRedDieHomeMap.Text = M2Share.g_Config.sRedDieHomeMap;
            EditRedDieHomeX.Value = M2Share.g_Config.nRedDieHomeX;
            EditRedDieHomeY.Value = M2Share.g_Config.nRedDieHomeY;
            EditHomeMap.Text = M2Share.g_Config.sHomeMap;
            EditHomeX.Value = M2Share.g_Config.nHomeX;
            EditHomeY.Value = M2Share.g_Config.nHomeY;
            EditDecPkPointTime.Value = M2Share.g_Config.dwDecPkPointTime / 1000;
            EditDecPkPointCount.Value = M2Share.g_Config.nDecPkPointCount;
            EditPKFlagTime.Value = M2Share.g_Config.dwPKFlagTime / 1000;
            EditKillHumanWeaponUnlockRate.Value = M2Share.g_Config.nKillHumanWeaponUnlockRate;
            EditKillHumanAddPKPoint.Value = M2Share.g_Config.nKillHumanAddPKPoint;
            EditPosionDecHealthTime.Value = M2Share.g_Config.dwPosionDecHealthTime;
            EditPosionDamagarmor.Value = M2Share.g_Config.nPosionDamagarmor;
            CheckBoxTestServer.Checked = M2Share.g_Config.boTestServer;
            CheckBoxServiceMode.Checked = M2Share.g_Config.boServiceMode;
            CheckBoxVentureMode.Checked = M2Share.g_Config.boVentureServer;
            CheckBoxNonPKMode.Checked = M2Share.g_Config.boNonPKServer;
            EditStartPermission.Value = M2Share.g_Config.nStartPermission;
            EditTestLevel.Value = M2Share.g_Config.nTestLevel;
            EditTestGold.Value = M2Share.g_Config.nTestGold;
            EditTestUserLimit.Value = M2Share.g_Config.nTestUserLimit;
            EditUserFull.Value = M2Share.g_Config.nUserFull;

            //CheckBoxTestServerClick(CheckBoxTestServer);
            CheckBoxKillHumanWinLevel.Checked = M2Share.g_Config.boKillHumanWinLevel;
            CheckBoxKilledLostLevel.Checked = M2Share.g_Config.boKilledLostLevel;
            CheckBoxKillHumanWinExp.Checked = M2Share.g_Config.boKillHumanWinExp;
            CheckBoxKilledLostExp.Checked = M2Share.g_Config.boKilledLostExp;
            EditKillHumanWinLevel.Value = M2Share.g_Config.nKillHumanWinLevel;
            EditKilledLostLevel.Value = M2Share.g_Config.nKilledLostLevel;
            EditKillHumanWinExp.Value = M2Share.g_Config.nKillHumanWinExp;
            EditKillHumanLostExp.Value = M2Share.g_Config.nKillHumanLostExp;
            EditHumanLevelDiffer.Value = M2Share.g_Config.nHumanLevelDiffer;

            //CheckBoxKillHumanWinLevelClick(CheckBoxKillHumanWinLevel);
            //CheckBoxKilledLostLevelClick(CheckBoxKilledLostLevel);
            //CheckBoxKillHumanWinExpClick(CheckBoxKillHumanWinExp);
            //CheckBoxKilledLostExpClick(CheckBoxKilledLostExp);
            EditHumanMaxGold.Value = M2Share.g_Config.nHumanMaxGold;
            EditHumanTryModeMaxGold.Value = M2Share.g_Config.nHumanTryModeMaxGold;
            EditTryModeLevel.Value = M2Share.g_Config.nTryModeLevel;
            CheckBoxTryModeUseStorage.Checked = M2Share.g_Config.boTryModeUseStorage;
            EditSayMsgMaxLen.Value = M2Share.g_Config.nSayMsgMaxLen;
            EditSayRedMsgMaxLen.Value = M2Share.g_Config.nSayRedMsgMaxLen;
            EditCanShoutMsgLevel.Value = M2Share.g_Config.nCanShoutMsgLevel;
            CheckBoxShutRedMsgShowGMName.Checked = M2Share.g_Config.boShutRedMsgShowGMName;
            CheckBoxShowPreFixMsg.Checked = M2Share.g_Config.boShowPreFixMsg;
            CheckBoxGMShowMsg.Checked = M2Share.g_Config.boGMShowFailMsg;//GM命令错误是否提示
            CheckBoxRecordClientMsg.Checked = M2Share.g_Config.boRecordClientMsg;//记录人物私聊，行会聊天信息
            EditGMRedMsgCmd.Text = M2Share.g_GMRedMsgCmd.ToString();
            EditStartCastleWarDays.Value = M2Share.g_Config.nStartCastleWarDays;
            EditStartCastlewarTime.Value = M2Share.g_Config.nStartCastlewarTime;//(60 * 1000)
            EditShowCastleWarEndMsgTime.Value = M2Share.g_Config.dwShowCastleWarEndMsgTime / 60000;//(60 * 1000)
            EditCastleWarTime.Value = M2Share.g_Config.dwCastleWarTime / 60000;//(60 * 1000)
            EditGetCastleTime.Value = M2Share.g_Config.dwGetCastleTime / 60000;//(60 * 1000)
            EditGuildWarTime.Value = M2Share.g_Config.dwGuildWarTime / 60000;
            EditMakeGhostTime.Value = M2Share.g_Config.dwMakeGhostTime / 1000;
            EditMakeGhostPlayMosterTime.Value = M2Share.g_Config.dwMakeGhostPlayMosterTime / 1000 == 0 ? 5 : M2Share.g_Config.dwMakeGhostPlayMosterTime / 1000;//人形怪尸体清理时间
            EditClearDropOnFloorItemTime.Value = M2Share.g_Config.dwClearDropOnFloorItemTime / 1000;//(60 * 1000)
            EditSaveHumanRcdTime.Value = M2Share.g_Config.dwSaveHumanRcdTime / 60000;//(60 * 1000)
            EditHumanFreeDelayTime.Value = M2Share.g_Config.dwHumanFreeDelayTime / 60000;
            EditFloorItemCanPickUpTime.Value = M2Share.g_Config.dwFloorItemCanPickUpTime / 1000;
            EditBuildGuildPrice.Value = M2Share.g_Config.nBuildGuildPrice;
            EditGuildWarPrice.Value = M2Share.g_Config.nGuildWarPrice;
            EditMakeDurgPrice.Value = M2Share.g_Config.nMakeDurgPrice;
            EditTryDealTime.Value = M2Share.g_Config.dwTryDealTime / 1000;
            EditDealOKTime.Value = M2Share.g_Config.dwDealOKTime / 1000;
            EditCastleMemberPriceRate.Value = M2Share.g_Config.nCastleMemberPriceRate;
            EditHearMsgFColor.Value = M2Share.g_Config.btHearMsgFColor;
            EdittHearMsgBColor.Value = M2Share.g_Config.btHearMsgBColor;
            EditWhisperMsgFColor.Value = M2Share.g_Config.btWhisperMsgFColor;
            EditWhisperMsgBColor.Value = M2Share.g_Config.btWhisperMsgBColor;
            EditGMWhisperMsgFColor.Value = M2Share.g_Config.btGMWhisperMsgFColor;
            EditGMWhisperMsgBColor.Value = M2Share.g_Config.btGMWhisperMsgBColor;
            EditRedMsgFColor.Value = M2Share.g_Config.btRedMsgFColor;
            EditRedMsgBColor.Value = M2Share.g_Config.btRedMsgBColor;
            EditGreenMsgFColor.Value = M2Share.g_Config.btGreenMsgFColor;
            EditGreenMsgBColor.Value = M2Share.g_Config.btGreenMsgBColor;
            EditBlueMsgFColor.Value = M2Share.g_Config.btBlueMsgFColor;
            EditBlueMsgBColor.Value = M2Share.g_Config.btBlueMsgBColor;
            EditSayMsgFColor.Value = M2Share.g_Config.btSayMsgFColor;//前景  千里传音
            EditSayeMsgBColor.Value = M2Share.g_Config.btSayeMsgBColor;//背景 千里传音
            EditCryMsgFColor.Value = M2Share.g_Config.btCryMsgFColor;
            EditCryMsgBColor.Value = M2Share.g_Config.btCryMsgBColor;
            EditGuildMsgFColor.Value = M2Share.g_Config.btGuildMsgFColor;
            EditGuildMsgBColor.Value = M2Share.g_Config.btGuildMsgBColor;
            EditGroupMsgFColor.Value = M2Share.g_Config.btGroupMsgFColor;
            EditGroupMsgBColor.Value = M2Share.g_Config.btGroupMsgBColor;
            EditCustMsgFColor.Value = M2Share.g_Config.btCustMsgFColor;
            EditCustMsgBColor.Value = M2Share.g_Config.btCustMsgBColor;
            CheckBoxPKLevelProtect.Checked = M2Share.g_Config.boPKLevelProtect;
            EditPKProtectLevel.Value = M2Share.g_Config.nPKProtectLevel;
            EditRedPKProtectLevel.Value = M2Share.g_Config.nRedPKProtectLevel;

            //CheckBoxPKLevelProtectClick(CheckBoxPKLevelProtect);
            CheckBoxCanNotGetBackDeal.Checked = M2Share.g_Config.boCanNotGetBackDeal;
            CheckBoxDisableDeal.Checked = M2Share.g_Config.boDisableDeal;
            CheckBoxControlDropItem.Checked = M2Share.g_Config.boControlDropItem;
            CheckBoxIsSafeDisableDrop.Checked = M2Share.g_Config.boInSafeDisableDrop;
            EditCanDropPrice.Value = M2Share.g_Config.nCanDropPrice;
            EditCanDropGold.Value = M2Share.g_Config.nCanDropGold;
            EditSuperRepairPriceRate.Value = M2Share.g_Config.nSuperRepairPriceRate;
            EditRepairItemDecDura.Value = M2Share.g_Config.nRepairItemDecDura;
            CheckBoxKillByMonstDropUseItem.Checked = M2Share.g_Config.boKillByMonstDropUseItem;
            CheckBoxKillByHumanDropUseItem.Checked = M2Share.g_Config.boKillByHumanDropUseItem;
            CheckBoxDieScatterBag.Checked = M2Share.g_Config.boDieScatterBag;
            CheckBoxDieDropGold.Checked = M2Share.g_Config.boDieDropGold;
            CheckBoxDieRedScatterBagAll.Checked = M2Share.g_Config.boDieRedScatterBagAll;
            ScrollBarDieDropUseItemRate.Minimum = 1;
            ScrollBarDieDropUseItemRate.Maximum = 200;
            ScrollBarDieDropUseItemRate.Value = M2Share.g_Config.nDieDropUseItemRate;
            ScrollBarDieRedDropUseItemRate.Minimum = 1;
            ScrollBarDieRedDropUseItemRate.Maximum = 200;
            ScrollBarDieRedDropUseItemRate.Value = M2Share.g_Config.nDieRedDropUseItemRate;
            ScrollBarDieScatterBagRate.Minimum = 1;
            ScrollBarDieScatterBagRate.Maximum = 200;
            ScrollBarDieScatterBagRate.Value = M2Share.g_Config.nDieScatterBagRate;
            EditSayMsgTime.Value = M2Share.g_Config.dwSayMsgTime / 1000;
            EditSayMsgCount.Value = M2Share.g_Config.nSayMsgCount;
            EditDisableSayMsgTime.Value = M2Share.g_Config.dwDisableSayMsgTime / 1000;
            CheckBoxFixExp.Checked = M2Share.g_Config.boUseFixExp;
            SpinEditBaseExp.Value = M2Share.g_Config.nBaseExp;
            SpinEditAddExp.Value = M2Share.g_Config.nAddExp;
            SpinEditBaseExp.Enabled = !CheckBoxFixExp.Checked;
            SpinEditAddExp.Enabled = !CheckBoxFixExp.Checked;
            SpinEditLimitExpLevel.Value = M2Share.g_Config.nLimitExpLevel;
            SpinEditLimitExpValue.Value = M2Share.g_Config.nLimitExpValue;
            RefGameVarConf();
            RefCharStatusConf();
            boOpened = true;
            GameConfigControl.SelectedIndex = 0;
            this.ShowDialog();
        }

        private void RefGameSpeedConf()
        {
            EditHitIntervalTime.Value = M2Share.g_Config.dwHitIntervalTime;
            EditMagicHitIntervalTime.Value = M2Share.g_Config.dwMagicHitIntervalTime;
            EditRunIntervalTime.Value = M2Share.g_Config.dwRunIntervalTime;
            EditWalkIntervalTime.Value = M2Share.g_Config.dwWalkIntervalTime;
            EditTurnIntervalTime.Value = M2Share.g_Config.dwTurnIntervalTime;
            EditItemSpeedTime.Value = M2Share.g_Config.ClientConf.btItemSpeed;
            EditMaxHitMsgCount.Value = M2Share.g_Config.nMaxHitMsgCount;
            EditMaxSpellMsgCount.Value = M2Share.g_Config.nMaxSpellMsgCount;
            EditMaxRunMsgCount.Value = M2Share.g_Config.nMaxRunMsgCount;
            EditMaxWalkMsgCount.Value = M2Share.g_Config.nMaxWalkMsgCount;
            EditMaxTurnMsgCount.Value = M2Share.g_Config.nMaxTurnMsgCount;
            EditMaxDigUpMsgCount.Value = M2Share.g_Config.nMaxDigUpMsgCount;
            CheckBoxboKickOverSpeed.Checked = M2Share.g_Config.boKickOverSpeed;
            EditOverSpeedKickCount.Value = M2Share.g_Config.nOverSpeedKickCount;
            EditDropOverSpeed.Value = M2Share.g_Config.dwDropOverSpeed;

            //CheckBoxboKickOverSpeedClick(CheckBoxboKickOverSpeed);
            CheckBoxSpellSendUpdateMsg.Checked = M2Share.g_Config.boSpellSendUpdateMsg;
            CheckBoxActionSendActionMsg.Checked = M2Share.g_Config.boActionSendActionMsg;
            if (M2Share.g_Config.btSpeedControlMode == 0)
            {
                RadioButtonDelyMode.Checked = true;
                RadioButtonFilterMode.Checked = false;
            }
            else
            {
                RadioButtonDelyMode.Checked = false;
                RadioButtonFilterMode.Checked = true;
            }
            CheckBoxDisableStruck.Checked = M2Share.g_Config.boDisableStruck;
            CheckBoxDisableSelfStruck.Checked = M2Share.g_Config.boDisableSelfStruck;
            EditStruckTime.Value = M2Share.g_Config.dwStruckTime;
        }

        public void ButtonGameSpeedDefaultClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认恢复默认设置？", "确认信息", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            M2Share.g_Config.dwHitIntervalTime = 850;
            M2Share.g_Config.dwMagicHitIntervalTime = 1350;
            M2Share.g_Config.dwRunIntervalTime = 600;
            M2Share.g_Config.dwWalkIntervalTime = 600;
            M2Share.g_Config.dwTurnIntervalTime = 600;
            M2Share.g_Config.nMaxHitMsgCount = 1;
            M2Share.g_Config.nMaxSpellMsgCount = 1;
            M2Share.g_Config.nMaxRunMsgCount = 1;
            M2Share.g_Config.nMaxWalkMsgCount = 1;
            M2Share.g_Config.nMaxTurnMsgCount = 1;
            M2Share.g_Config.nMaxDigUpMsgCount = 1;
            M2Share.g_Config.nOverSpeedKickCount = 2;
            M2Share.g_Config.dwDropOverSpeed = 200;
            M2Share.g_Config.boKickOverSpeed = true;
            M2Share.g_Config.ClientConf.btItemSpeed = 25;
            M2Share.g_Config.boDisableStruck = false;
            M2Share.g_Config.boDisableSelfStruck = false;
            M2Share.g_Config.dwStruckTime = 300;
            M2Share.g_Config.boSpellSendUpdateMsg = true;
            M2Share.g_Config.boActionSendActionMsg = true;
            M2Share.g_Config.btSpeedControlMode = 0;
            RefGameSpeedConf();
            ModValue();
        }

        public void ButtonGameSpeedSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "HitIntervalTime", M2Share.g_Config.dwHitIntervalTime);
            M2Share.Config.WriteInteger("Setup", "MagicHitIntervalTime", M2Share.g_Config.dwMagicHitIntervalTime);
            M2Share.Config.WriteInteger("Setup", "RunIntervalTime", M2Share.g_Config.dwRunIntervalTime);
            M2Share.Config.WriteInteger("Setup", "WalkIntervalTime", M2Share.g_Config.dwWalkIntervalTime);
            M2Share.Config.WriteInteger("Setup", "TurnIntervalTime", M2Share.g_Config.dwTurnIntervalTime);
            M2Share.Config.WriteInteger("Setup", "ItemSpeedTime", M2Share.g_Config.ClientConf.btItemSpeed);
            M2Share.Config.WriteInteger("Setup", "MaxHitMsgCount", M2Share.g_Config.nMaxHitMsgCount);
            M2Share.Config.WriteInteger("Setup", "MaxSpellMsgCount", M2Share.g_Config.nMaxSpellMsgCount);
            M2Share.Config.WriteInteger("Setup", "MaxRunMsgCount", M2Share.g_Config.nMaxRunMsgCount);
            M2Share.Config.WriteInteger("Setup", "MaxWalkMsgCount", M2Share.g_Config.nMaxWalkMsgCount);
            M2Share.Config.WriteInteger("Setup", "MaxTurnMsgCount", M2Share.g_Config.nMaxTurnMsgCount);
            M2Share.Config.WriteInteger("Setup", "MaxSitDonwMsgCount", M2Share.g_Config.nMaxSitDonwMsgCount);
            M2Share.Config.WriteInteger("Setup", "MaxDigUpMsgCount", M2Share.g_Config.nMaxDigUpMsgCount);
            M2Share.Config.WriteInteger("Setup", "OverSpeedKickCount", M2Share.g_Config.nOverSpeedKickCount);
            M2Share.Config.WriteBool("Setup", "KickOverSpeed", M2Share.g_Config.boKickOverSpeed);
            M2Share.Config.WriteBool("Setup", "SpellSendUpdateMsg", M2Share.g_Config.boSpellSendUpdateMsg);
            M2Share.Config.WriteBool("Setup", "ActionSendActionMsg", M2Share.g_Config.boActionSendActionMsg);
            M2Share.Config.WriteInteger("Setup", "DropOverSpeed", M2Share.g_Config.dwDropOverSpeed);
            M2Share.Config.WriteBool("Setup", "DisableStruck", M2Share.g_Config.boDisableStruck);
            M2Share.Config.WriteBool("Setup", "DisableSelfStruck", M2Share.g_Config.boDisableSelfStruck);
            M2Share.Config.WriteInteger("Setup", "StruckTime", M2Share.g_Config.dwStruckTime);
            M2Share.Config.WriteInteger("Setup", "SpeedControlMode", M2Share.g_Config.btSpeedControlMode);
            uModValue();
        }

        public void EditHitIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwHitIntervalTime = (uint)EditHitIntervalTime.Value;
            ModValue();
        }

        public void EditMagicHitIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwMagicHitIntervalTime = (uint)EditMagicHitIntervalTime.Value;
            ModValue();
        }

        public void EditRunIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwRunIntervalTime = (uint)EditRunIntervalTime.Value;
            ModValue();
        }

        public void EditWalkIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwWalkIntervalTime = (uint)EditWalkIntervalTime.Value;
            ModValue();
        }

        public void EditTurnIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwTurnIntervalTime = (uint)EditTurnIntervalTime.Value;
            ModValue();
        }

        public void EditMaxHitMsgCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMaxHitMsgCount = (byte)EditMaxHitMsgCount.Value;
            ModValue();
        }

        public void EditMaxSpellMsgCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMaxSpellMsgCount = (byte)EditMaxSpellMsgCount.Value;
            ModValue();
        }

        public void EditMaxRunMsgCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMaxRunMsgCount = (byte)EditMaxRunMsgCount.Value;
            ModValue();
        }

        public void EditMaxWalkMsgCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMaxWalkMsgCount = (byte)EditMaxWalkMsgCount.Value;
            ModValue();
        }

        public void EditMaxTurnMsgCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMaxTurnMsgCount = (byte)EditMaxTurnMsgCount.Value;
            ModValue();
        }

        public void EditMaxDigUpMsgCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMaxDigUpMsgCount = (byte)EditMaxDigUpMsgCount.Value;
            ModValue();
        }

        public void EditOverSpeedKickCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nOverSpeedKickCount = (byte)EditOverSpeedKickCount.Value;
            ModValue();
        }

        public void EditDropOverSpeedChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwDropOverSpeed = (uint)EditDropOverSpeed.Value;
            ModValue();
        }

        public void CheckBoxSpellSendUpdateMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boSpellSendUpdateMsg = CheckBoxSpellSendUpdateMsg.Checked;
            ModValue();
        }

        public void CheckBoxActionSendActionMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boActionSendActionMsg = CheckBoxActionSendActionMsg.Checked;
            ModValue();
        }

        public void CheckBoxboKickOverSpeedClick(object sender, EventArgs e)
        {
            EditOverSpeedKickCount.Enabled = CheckBoxboKickOverSpeed.Checked;
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boKickOverSpeed = CheckBoxboKickOverSpeed.Checked;
            ModValue();
        }

        public void RadioButtonDelyModeClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioButtonDelyMode.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btSpeedControlMode = 0;
            }
            else
            {
                M2Share.g_Config.btSpeedControlMode = 1;
            }
            ModValue();
        }

        public void RadioButtonFilterModeClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioButtonFilterMode.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btSpeedControlMode = 1;
            }
            else
            {
                M2Share.g_Config.btSpeedControlMode = 0;
            }
            ModValue();
        }

        public void EditItemSpeedTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ClientConf.btItemSpeed = (byte)EditItemSpeedTime.Value;
            ModValue();
        }

        public void EditConsoleShowUserCountTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwConsoleShowUserCountTime = (uint)EditConsoleShowUserCountTime.Value * 1000;
            ModValue();
        }

        public void EditShowLineNoticeTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwShowLineNoticeTime = (uint)EditShowLineNoticeTime.Value * 1000;
            ModValue();
        }

        public void ComboBoxLineNoticeColorChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nLineNoticeColor = (byte)ComboBoxLineNoticeColor.SelectedIndex;
            ModValue();
        }

        public void EditSoftVersionDateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void EditLineNoticePreFixChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sLineNoticePreFix = EditLineNoticePreFix.Text.Trim();
            ModValue();
        }

        public void CheckBoxShowMakeItemMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boShowMakeItemMsg = CheckBoxShowMakeItemMsg.Checked;
            ModValue();
        }

        public void CbViewHackClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boViewHackMessage = CbViewHack.Checked;
            ModValue();
        }

        public void CkViewAdmfailClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boViewAdmissionFailure = CkViewAdmfail.Checked;
            ModValue();
        }

        public void CheckBoxShowExceptionMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boShowExceptionMsg = CheckBoxShowExceptionMsg.Checked;
            ModValue();
        }

        public void CheckBoxCanOldClientLogonClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boCanOldClientLogon = CheckBoxCanOldClientLogon.Checked;
            ModValue();
        }

        public void CheckBoxSendOnlineCountClick(object sender, EventArgs e)
        {
            bool boStatus;
            boStatus = CheckBoxSendOnlineCount.Checked;
            EditSendOnlineCountRate.Enabled = boStatus;
            EditSendOnlineTime.Enabled = boStatus;
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boSendOnlineCount = boStatus;
            ModValue();
        }

        public void EditSendOnlineCountRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSendOnlineCountRate = (byte)EditSendOnlineCountRate.Value;
            ModValue();
        }

        public void EditSendOnlineTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwSendOnlineTime = (uint)EditSendOnlineTime.Value * 1000;
            ModValue();
        }

        public void EditMonsterPowerRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMonsterPowerRate = (ushort)EditMonsterPowerRate.Value;
            ModValue();
        }

        public void EditEditItemsPowerRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nItemsPowerRate = (int)EditEditItemsPowerRate.Value;
            ModValue();
        }

        public void EditItemsACPowerRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nItemsACPowerRate = (ushort)EditItemsACPowerRate.Value;
            ModValue();
        }

        public void CheckBoxDisableStruckClick(object sender, EventArgs e)
        {
            EditStruckTime.Enabled = !CheckBoxDisableStruck.Checked;
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDisableStruck = CheckBoxDisableStruck.Checked;
            ModValue();
        }

        public void CheckBoxDisableSelfStruckClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDisableSelfStruck = CheckBoxDisableSelfStruck.Checked;
            ModValue();
        }

        public void EditStruckTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwStruckTime = (uint)EditStruckTime.Value;
            ModValue();
        }

        private void RefGameVarConf()
        {
            EditSoftVersionDate.Text = (M2Share.g_Config.nSoftVersionDate).ToString();
            EditConsoleShowUserCountTime.Value = M2Share.g_Config.dwConsoleShowUserCountTime / 1000;
            EditShowLineNoticeTime.Value = M2Share.g_Config.dwShowLineNoticeTime / 1000;

            //ComboBoxLineNoticeColor.SelectedIndex = HUtil32._MAX(0, HUtil32._MIN(3, M2Share.g_Config.nLineNoticeColor));
            EditLineNoticePreFix.Text = M2Share.g_Config.sLineNoticePreFix;
            CheckBoxShowMakeItemMsg.Checked = M2Share.g_Config.boShowMakeItemMsg;
            CbViewHack.Checked = M2Share.g_Config.boViewHackMessage;
            CkViewAdmfail.Checked = M2Share.g_Config.boViewAdmissionFailure;
            CheckBoxShowExceptionMsg.Checked = M2Share.g_Config.boShowExceptionMsg;
            CheckBoxSendOnlineCount.Checked = M2Share.g_Config.boSendOnlineCount;
            EditSendOnlineCountRate.Value = M2Share.g_Config.nSendOnlineCountRate;
            EditSendOnlineTime.Value = M2Share.g_Config.dwSendOnlineTime / 1000;

            //CheckBoxSendOnlineCountClick(CheckBoxSendOnlineCount);
            EditMonsterPowerRate.Value = M2Share.g_Config.nMonsterPowerRate;
            EditEditItemsPowerRate.Value = M2Share.g_Config.nItemsPowerRate;
            EditItemsACPowerRate.Value = M2Share.g_Config.nItemsACPowerRate;
            CheckBoxCanOldClientLogon.Checked = M2Share.g_Config.boCanOldClientLogon;
        }

        public void ButtonGeneralSaveClick(object sender, EventArgs e)
        {
            int SoftVersionDate = HUtil32.Str_ToInt(EditSoftVersionDate.Text.Trim(), -1);
            if ((SoftVersionDate < 0))
            {
                MessageBox.Show("客户端版号设置错误！！！", "错误信息", MessageBoxButtons.OK);
                EditSoftVersionDate.Focus();
                return;
            }
            M2Share.g_Config.nSoftVersionDate = SoftVersionDate;
            M2Share.Config.WriteInteger("Setup", "SoftVersionDate", M2Share.g_Config.nSoftVersionDate);
            M2Share.Config.WriteInteger("Setup", "ConsoleShowUserCountTime", M2Share.g_Config.dwConsoleShowUserCountTime);
            M2Share.Config.WriteInteger("Setup", "ShowLineNoticeTime", M2Share.g_Config.dwShowLineNoticeTime);
            M2Share.Config.WriteInteger("Setup", "LineNoticeColor", M2Share.g_Config.nLineNoticeColor);
            M2Share.StringConf.WriteString("String", "LineNoticePreFix", M2Share.g_Config.sLineNoticePreFix);
            M2Share.Config.WriteBool("Setup", "ShowMakeItemMsg", M2Share.g_Config.boShowMakeItemMsg);

            //M2Share.Config.WriteString("Server", "ViewHackMessage", HUtil32.BoolToStr(M2Share.g_Config.boViewHackMessage));
            //M2Share.Config.WriteString("Server", "ViewAdmissionFailure", HUtil32.BoolToStr(M2Share.g_Config.boViewAdmissionFailure));
            M2Share.Config.WriteBool("Setup", "ShowExceptionMsg", M2Share.g_Config.boShowExceptionMsg);
            M2Share.Config.WriteBool("Setup", "RecordClientMsg", M2Share.g_Config.boRecordClientMsg);

            // 记录人物私聊，行会聊天信息 20081213
            M2Share.Config.WriteBool("Setup", "SendOnlineCount", M2Share.g_Config.boSendOnlineCount);
            M2Share.Config.WriteInteger("Setup", "SendOnlineCountRate", M2Share.g_Config.nSendOnlineCountRate);
            M2Share.Config.WriteInteger("Setup", "SendOnlineTime", M2Share.g_Config.dwSendOnlineTime);
            M2Share.Config.WriteInteger("Setup", "MonsterPowerRate", M2Share.g_Config.nMonsterPowerRate);
            M2Share.Config.WriteInteger("Setup", "ItemsPowerRate", M2Share.g_Config.nItemsPowerRate);
            M2Share.Config.WriteInteger("Setup", "ItemsACPowerRate", M2Share.g_Config.nItemsACPowerRate);
            M2Share.Config.WriteBool("Setup", "CanOldClientLogon", M2Share.g_Config.boCanOldClientLogon);
            uModValue();
        }

        public void EditKillMonExpMultipleChange(object sender, EventArgs e)
        {
            if (EditKillMonExpMultiple.Text == "")
            {
                EditKillMonExpMultiple.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwKillMonExpMultiple = (ushort)EditKillMonExpMultiple.Value;
            ModValue();
        }

        public void CheckBoxHighLevelKillMonFixExpClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHighLevelKillMonFixExp = CheckBoxHighLevelKillMonFixExp.Checked;
            ModValue();
        }

        public void GridLevelExpSetEditText(object sender, EventArgs e, int ACol, int ARow, string Value)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void ComboBoxLevelExpClick(object sender, EventArgs e)
        {
            int I;
            TLevelExpScheme LevelExpScheme;
            uint dwOneLevelExp;
            uint dwExp;
            if (!boOpened)
            {
                return;
            }
            if (MessageBox.Show("升级经验计划设置的经验将立即生效，是否确认使用此经验计划？", "确认信息", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            LevelExpScheme = TLevelExpScheme.s_100Mult;

            // LevelExpScheme = ((ComboBoxLevelExp.Items[ComboBoxLevelExp.SelectedIndex]) as TLevelExpScheme);
            switch (LevelExpScheme)
            {
                case TLevelExpScheme.s_OldLevelExp:
                    M2Share.g_Config.dwNeedExps = M2Share.g_dwOldNeedExps;
                    break;

                case TLevelExpScheme.s_StdLevelExp:
                    M2Share.g_Config.dwNeedExps = M2Share.g_dwOldNeedExps;
                    dwOneLevelExp = Convert.ToUInt16(4000000000 / M2Share.g_Config.dwNeedExps.GetUpperBound(0));
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        if ((26 + I) > M2Share.MAXCHANGELEVEL)
                        {
                            break;
                        }
                        dwExp = Convert.ToUInt32(dwOneLevelExp * I);
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[26 + I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_2Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 2;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_5Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 5;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_8Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 8;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_10Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 10;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_20Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 20;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_30Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 30;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_40Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 40;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_50Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 50;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_60Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 60;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_70Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 70;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_80Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 80;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_90Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 90;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_100Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 100;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_150Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 150;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_200Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 200;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_250Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 250;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;

                case TLevelExpScheme.s_300Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwNeedExps[I] / 300;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwNeedExps[I] = dwExp;
                    }
                    break;
            }

            //for (I = 1; I < GridLevelExp.RowCount; I ++ )
            //{
            //    GridLevelExp.Cells[1, I] = (M2Share.g_Config.dwNeedExps[I]).ToString();
            //}
            ModValue();
        }

        public void ButtonExpSaveClick(object sender, EventArgs e)
        {
            int I;
            uint dwExp;
            uint[] NeedExps;

            //for (I = 1; I < GridLevelExp.RowCount; I ++ )
            //{
            //    dwExp = HUtil32.Str_ToInt(GridLevelExp.Cells[1, I], 0);
            //    if ((dwExp <= 0))
            //    {
            //        // 20080522
            //        MessageBox.Show(("等级 " + (I).ToString() + " 升级经验设置错误！！！" as string), "错误信息", MessageBoxButtons.OK + MessageBoxIcon.Error);
            //        GridLevelExp.CurrentRowIndex = I;
            //        GridLevelExp.Focus();
            //        return;
            //    }
            //    NeedExps[I] = dwExp;
            //}
            //M2Share.g_Config.dwNeedExps = NeedExps;

            M2Share.Config.WriteInteger("Exp", "KillMonExpMultiple", M2Share.g_Config.dwKillMonExpMultiple);

            M2Share.Config.WriteBool("Exp", "HighLevelKillMonFixExp", M2Share.g_Config.boHighLevelKillMonFixExp);

            M2Share.Config.WriteBool("Exp", "HighLevelGroupFixExp", M2Share.g_Config.boHighLevelGroupFixExp);

            M2Share.Config.WriteBool("Exp", "SaveExpRate", M2Share.g_Config.boSaveExpRate);

            // 是否保存双倍经验时间 20080412
            for (I = 1; I <= 1000; I++)
            {
                M2Share.Config.WriteString("Exp", "Level" + (I).ToString(), (M2Share.g_Config.dwNeedExps[I]).ToString());
            }

            M2Share.Config.WriteBool("Exp", "UseFixExp", M2Share.g_Config.boUseFixExp);

            M2Share.Config.WriteInteger("Exp", "BaseExp", M2Share.g_Config.nBaseExp);

            M2Share.Config.WriteInteger("Exp", "AddExp", M2Share.g_Config.nAddExp);

            M2Share.Config.WriteInteger("Exp", "LimitExpLevel", M2Share.g_Config.nLimitExpLevel);

            M2Share.Config.WriteInteger("Exp", "LimitExpValue", M2Share.g_Config.nLimitExpValue);
            uModValue();
        }

        public void EditRepairDoorPriceChange(object sender, EventArgs e)
        {
            if (EditRepairDoorPrice.Text == "")
            {
                EditRepairDoorPrice.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRepairDoorPrice = (int)EditRepairDoorPrice.Value;
            ModValue();
        }

        public void EditRepairWallPriceChange(object sender, EventArgs e)
        {
            if (EditRepairWallPrice.Text == "")
            {
                EditRepairWallPrice.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRepairWallPrice = (int)EditRepairWallPrice.Value;
            ModValue();
        }

        public void EditHireArcherPriceChange(object sender, EventArgs e)
        {
            if (EditHireArcherPrice.Text == "")
            {
                EditHireArcherPrice.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHireArcherPrice = (int)EditHireArcherPrice.Value;
            ModValue();
        }

        public void EditHireGuardPriceChange(object sender, EventArgs e)
        {
            if (EditHireGuardPrice.Text == "")
            {
                EditHireGuardPrice.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHireGuardPrice = (int)EditHireGuardPrice.Value;
            ModValue();
        }

        public void EditCastleGoldMaxChange(object sender, EventArgs e)
        {
            if (EditCastleGoldMax.Text == "")
            {
                EditCastleGoldMax.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleGoldMax = (int)EditCastleGoldMax.Value;
            ModValue();
        }

        public void EditCastleOneDayGoldChange(object sender, EventArgs e)
        {
            if (EditCastleOneDayGold.Text == "")
            {
                EditCastleOneDayGold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleOneDayGold = (int)EditCastleOneDayGold.Value;
            ModValue();
        }

        public void EditCastleHomeMapChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sCastleHomeMap = EditCastleHomeMap.Text.Trim();
            ModValue();
        }

        public void EditCastleHomeXChange(object sender, EventArgs e)
        {
            if (EditCastleHomeX.Text == "")
            {
                EditCastleHomeX.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleHomeX = (int)EditCastleHomeX.Value;
            ModValue();
        }

        public void EditCastleHomeYChange(object sender, EventArgs e)
        {
            if (EditCastleHomeY.Text == "")
            {
                EditCastleHomeY.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleHomeY = (int)EditCastleHomeY.Value;
            ModValue();
        }

        public void EditCastleNameChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sCASTLENAME = EditCastleName.Text.Trim();
            ModValue();
        }

        public void EditWarRangeXChange(object sender, EventArgs e)
        {
            if (EditWarRangeX.Text == "")
            {
                EditWarRangeX.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleWarRangeX = (int)EditWarRangeX.Value;
            ModValue();
        }

        public void EditWarRangeYChange(object sender, EventArgs e)
        {
            if (EditWarRangeY.Text == "")
            {
                EditWarRangeY.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleWarRangeY = (int)EditWarRangeY.Value;
            ModValue();
        }

        public void CheckBoxGetAllNpcTaxClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boGetAllNpcTax = CheckBoxGetAllNpcTax.Checked;
            ModValue();
        }

        public void EditTaxRateChange(object sender, EventArgs e)
        {
            if (EditTaxRate.Text == "")
            {
                EditTaxRate.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleTaxRate = (ushort)EditTaxRate.Value;
            ModValue();
        }

        public void EditCastleMemberPriceRateChange(object sender, EventArgs e)
        {
            if (EditCastleMemberPriceRate.Text == "")
            {
                EditCastleMemberPriceRate.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCastleMemberPriceRate = (byte)EditCastleMemberPriceRate.Value;
            ModValue();
        }

        public void ButtonCastleSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "RepairDoor", M2Share.g_Config.nRepairDoorPrice);
            M2Share.Config.WriteInteger("Setup", "RepairWall", M2Share.g_Config.nRepairWallPrice);
            M2Share.Config.WriteInteger("Setup", "HireArcher", M2Share.g_Config.nHireArcherPrice);
            M2Share.Config.WriteInteger("Setup", "HireGuard", M2Share.g_Config.nHireGuardPrice);
            M2Share.Config.WriteInteger("Setup", "CastleGoldMax", M2Share.g_Config.nCastleGoldMax);
            M2Share.Config.WriteInteger("Setup", "CastleOneDayGold", M2Share.g_Config.nCastleOneDayGold);
            M2Share.Config.WriteString("Setup", "CastleName", M2Share.g_Config.sCASTLENAME);
            M2Share.Config.WriteString("Setup", "CastleHomeMap", M2Share.g_Config.sCastleHomeMap);
            M2Share.Config.WriteInteger("Setup", "CastleHomeX", M2Share.g_Config.nCastleHomeX);
            M2Share.Config.WriteInteger("Setup", "CastleHomeY", M2Share.g_Config.nCastleHomeY);
            M2Share.Config.WriteInteger("Setup", "CastleWarRangeX", M2Share.g_Config.nCastleWarRangeX);
            M2Share.Config.WriteInteger("Setup", "CastleWarRangeY", M2Share.g_Config.nCastleWarRangeY);
            M2Share.Config.WriteInteger("Setup", "CastleTaxRate", M2Share.g_Config.nCastleTaxRate);
            M2Share.Config.WriteBool("Setup", "CastleGetAllNpcTax", M2Share.g_Config.boGetAllNpcTax);
            M2Share.Config.WriteInteger("Setup", "CastleMemberPriceRate", M2Share.g_Config.nCastleMemberPriceRate);
            uModValue();
        }

        public void CheckBoxDisHumRunClick(object sender, EventArgs e)
        {
            bool boChecked;
            boChecked = !CheckBoxDisHumRun.Checked;
            if (boChecked)
            {
                CheckBoxRunHum.Checked = false;
                CheckBoxRunHum.Enabled = false;
                CheckBoxRunMon.Checked = false;
                CheckBoxRunMon.Enabled = false;
                CheckBoxWarDisHumRun.Checked = false;
                CheckBoxWarDisHumRun.Enabled = false;
                CheckBoxRunNpc.Checked = false;
                CheckBoxRunGuard.Checked = false;
                CheckBoxRunNpc.Enabled = false;
                CheckBoxRunGuard.Enabled = false;
                CheckBoxGMRunAll.Checked = false;
                CheckBoxGMRunAll.Enabled = false;
                CheckBoxSafeArea.Checked = false;
                CheckBoxSafeArea.Enabled = false;
            }
            else
            {
                CheckBoxRunHum.Enabled = true;
                CheckBoxRunMon.Enabled = true;
                CheckBoxWarDisHumRun.Enabled = true;
                CheckBoxRunNpc.Enabled = true;
                CheckBoxRunGuard.Enabled = true;
                CheckBoxGMRunAll.Enabled = true;
                CheckBoxSafeArea.Enabled = true;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDiableHumanRun = boChecked;
            ModValue();
        }

        public void CheckBoxRunHumClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boRUNHUMAN = CheckBoxRunHum.Checked;
            ModValue();
        }

        public void CheckBoxRunMonClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boRUNMON = CheckBoxRunMon.Checked;
            ModValue();
        }

        public void CheckBoxRunNpcClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boRunNpc = CheckBoxRunNpc.Checked;
            ModValue();
        }

        public void CheckBoxRunGuardClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boRunGuard = CheckBoxRunGuard.Checked;
            ModValue();
        }

        public void CheckBoxWarDisHumRunClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boWarDisHumRun = CheckBoxWarDisHumRun.Checked;
            ModValue();
        }

        public void CheckBoxGMRunAllClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boGMRunAll = CheckBoxGMRunAll.Checked;
            ModValue();
        }

        public void EditTryDealTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwTryDealTime = (uint)EditTryDealTime.Value * 1000;
            ModValue();
        }

        public void EditDealOKTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwDealOKTime = (uint)EditDealOKTime.Value * 1000;
            ModValue();
        }

        public void CheckBoxCanNotGetBackDealClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boCanNotGetBackDeal = CheckBoxCanNotGetBackDeal.Checked;
            ModValue();
        }

        public void CheckBoxDisableDealClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDisableDeal = CheckBoxDisableDeal.Checked;
            ModValue();
        }

        public void CheckBoxControlDropItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boControlDropItem = CheckBoxControlDropItem.Checked;
            ModValue();
        }

        public void CheckBoxIsSafeDisableDropClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boInSafeDisableDrop = CheckBoxIsSafeDisableDrop.Checked;
            ModValue();
        }

        public void EditCanDropPriceChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCanDropPrice = (int)EditCanDropPrice.Value;
            ModValue();
        }

        public void EditCanDropGoldChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCanDropGold = (int)EditCanDropGold.Value;
            ModValue();
        }

        public void EditSafeZoneSizeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSafeZoneSize = (ushort)EditSafeZoneSize.Value;
            ModValue();
        }

        public void EditStartPointSizeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStartPointSize = (ushort)EditStartPointSize.Value;
            ModValue();
        }

        public void EditGroupMembersMaxChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nGroupMembersMax = (ushort)EditGroupMembersMax.Value;
            ModValue();
        }

        public void EditRedHomeXChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRedHomeX = (int)EditRedHomeX.Value;
            ModValue();
        }

        public void EditRedHomeYChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRedHomeY = (int)EditRedHomeY.Value;
            ModValue();
        }

        public void EditRedHomeMapChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void EditRedDieHomeMapChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void EditRedDieHomeXChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRedDieHomeX = (int)EditRedDieHomeX.Value;
            ModValue();
        }

        public void EditHomeMapChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void EditHomeXChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHomeX = (int)EditHomeX.Value;
            ModValue();
        }

        public void EditHomeYChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHomeY = (int)EditHomeY.Value;
            ModValue();
        }

        public void EditRedDieHomeYChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRedDieHomeY = (int)EditRedDieHomeY.Value;
            ModValue();
        }

        public void ButtonOptionSaveClick(object sender, EventArgs e)
        {
            if (EditRedHomeMap.Text == "")
            {
                MessageBox.Show("红名村地图设置错误！！！", "错误信息", MessageBoxButtons.OK);
                EditRedHomeMap.Focus();
                return;
            }
            M2Share.g_Config.sRedHomeMap = EditRedHomeMap.Text.Trim();
            if (EditRedDieHomeMap.Text == "")
            {
                MessageBox.Show("红名村地图设置错误！！！", "错误信息", MessageBoxButtons.OK);
                EditRedDieHomeMap.Focus();
                return;
            }
            M2Share.g_Config.sRedDieHomeMap = EditRedDieHomeMap.Text.Trim();
            if (EditHomeMap.Text == "")
            {
                MessageBox.Show("应急回城地图设置错误！！！", "错误信息", MessageBoxButtons.OK);
                EditHomeMap.Focus();
                return;
            }
            M2Share.g_Config.sHomeMap = EditHomeMap.Text.Trim();

            M2Share.Config.WriteInteger("Setup", "SafeZoneSize", M2Share.g_Config.nSafeZoneSize);

            M2Share.Config.WriteInteger("Setup", "StartPointSize", M2Share.g_Config.nStartPointSize);

            M2Share.Config.WriteString("Setup", "RedHomeMap", M2Share.g_Config.sRedHomeMap);

            M2Share.Config.WriteInteger("Setup", "RedHomeX", M2Share.g_Config.nRedHomeX);

            M2Share.Config.WriteInteger("Setup", "RedHomeY", M2Share.g_Config.nRedHomeY);

            M2Share.Config.WriteString("Setup", "RedDieHomeMap", M2Share.g_Config.sRedDieHomeMap);

            M2Share.Config.WriteInteger("Setup", "RedDieHomeX", M2Share.g_Config.nRedDieHomeX);

            M2Share.Config.WriteInteger("Setup", "RedDieHomeY", M2Share.g_Config.nRedDieHomeY);

            M2Share.Config.WriteString("Setup", "HomeMap", M2Share.g_Config.sHomeMap);

            M2Share.Config.WriteInteger("Setup", "HomeX", M2Share.g_Config.nHomeX);

            M2Share.Config.WriteInteger("Setup", "HomeY", M2Share.g_Config.nHomeY);

            uModValue();
        }

        public void ButtonOptionSave3Click(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "DiableHumanRun", M2Share.g_Config.boDiableHumanRun);

            M2Share.Config.WriteBool("Setup", "RunHuman", M2Share.g_Config.boRUNHUMAN);

            M2Share.Config.WriteBool("Setup", "RunMon", M2Share.g_Config.boRUNMON);

            M2Share.Config.WriteBool("Setup", "RunNpc", M2Share.g_Config.boRunNpc);

            M2Share.Config.WriteBool("Setup", "RunGuard", M2Share.g_Config.boRunGuard);

            M2Share.Config.WriteBool("Setup", "WarDisableHumanRun", M2Share.g_Config.boWarDisHumRun);

            M2Share.Config.WriteBool("Setup", "GMRunAll", M2Share.g_Config.boGMRunAll);

            M2Share.Config.WriteBool("Setup", "SafeAreaLimitedRun", M2Share.g_Config.boSafeAreaLimited);

            M2Share.Config.WriteInteger("Setup", "TryDealTime", M2Share.g_Config.dwTryDealTime);

            M2Share.Config.WriteInteger("Setup", "DealOKTime", M2Share.g_Config.dwDealOKTime);

            M2Share.Config.WriteBool("Setup", "CanNotGetBackDeal", M2Share.g_Config.boCanNotGetBackDeal);

            M2Share.Config.WriteBool("Setup", "DisableDeal", M2Share.g_Config.boDisableDeal);

            M2Share.Config.WriteBool("Setup", "ControlDropItem", M2Share.g_Config.boControlDropItem);

            M2Share.Config.WriteBool("Setup", "InSafeDisableDrop", M2Share.g_Config.boInSafeDisableDrop);

            M2Share.Config.WriteInteger("Setup", "CanDropGold", M2Share.g_Config.nCanDropGold);

            M2Share.Config.WriteInteger("Setup", "CanDropPrice", M2Share.g_Config.nCanDropPrice);

            M2Share.Config.WriteInteger("Setup", "DecLightItemDrugTime", M2Share.g_Config.dwDecLightItemDrugTime);

            M2Share.Config.WriteInteger("Setup", "PosionDecHealthTime", M2Share.g_Config.dwPosionDecHealthTime);

            M2Share.Config.WriteInteger("Setup", "PosionDamagarmor", M2Share.g_Config.nPosionDamagarmor);
            uModValue();
        }

        public void EditDecPkPointTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwDecPkPointTime = (uint)EditDecPkPointTime.Value * 1000;
            ModValue();
        }

        public void EditDecPkPointCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDecPkPointCount = (ushort)EditDecPkPointCount.Value;
            ModValue();
        }

        public void EditPKFlagTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwPKFlagTime = (uint)EditPKFlagTime.Value * 1000;
            ModValue();
        }

        public void EditKillHumanAddPKPointChange(object sender, EventArgs e)
        {
            if (EditKillHumanAddPKPoint.Text == "")
            {
                EditKillHumanAddPKPoint.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nKillHumanAddPKPoint = (ushort)EditKillHumanAddPKPoint.Value;
            ModValue();
        }

        public void EditPosionDecHealthTimeChange(object sender, EventArgs e)
        {
            if (EditPosionDecHealthTime.Text == "")
            {
                EditPosionDecHealthTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwPosionDecHealthTime = (uint)EditPosionDecHealthTime.Value;
            ModValue();
        }

        public void EditPosionDamagarmorChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nPosionDamagarmor = (ushort)EditPosionDamagarmor.Value;
            ModValue();
        }

        public void CheckBoxKillHumanWinLevelClick(object sender, EventArgs e)
        {
            bool boStatus;
            boStatus = CheckBoxKillHumanWinLevel.Checked;
            CheckBoxKilledLostLevel.Enabled = boStatus;
            EditKillHumanWinLevel.Enabled = boStatus;
            EditKilledLostLevel.Enabled = boStatus;
            if (!boStatus)
            {
                CheckBoxKilledLostLevel.Checked = false;
                if (!CheckBoxKillHumanWinExp.Checked)
                {
                    EditHumanLevelDiffer.Enabled = false;
                }
            }
            else
            {
                EditHumanLevelDiffer.Enabled = true;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boKillHumanWinLevel = boStatus;
            ModValue();
        }

        public void CheckBoxKilledLostLevelClick(object sender, EventArgs e)
        {
            bool boStatus;
            boStatus = CheckBoxKilledLostLevel.Checked;
            EditKilledLostLevel.Enabled = boStatus;
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boKilledLostLevel = boStatus;
            ModValue();
        }

        public void CheckBoxKillHumanWinExpClick(object sender, EventArgs e)
        {
            bool boStatus;
            boStatus = CheckBoxKillHumanWinExp.Checked;
            CheckBoxKilledLostExp.Enabled = boStatus;
            EditKillHumanWinExp.Enabled = boStatus;
            EditKillHumanLostExp.Enabled = boStatus;
            if (!boStatus)
            {
                CheckBoxKilledLostExp.Checked = false;
                if (!CheckBoxKillHumanWinLevel.Checked)
                {
                    EditHumanLevelDiffer.Enabled = false;
                }
            }
            else
            {
                EditHumanLevelDiffer.Enabled = true;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boKillHumanWinExp = boStatus;
            ModValue();
        }

        public void CheckBoxKilledLostExpClick(object sender, EventArgs e)
        {
            bool boStatus;
            boStatus = CheckBoxKilledLostExp.Checked;
            EditKillHumanLostExp.Enabled = boStatus;
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boKilledLostExp = boStatus;
            ModValue();
        }

        public void EditKillHumanWinLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nKillHumanWinLevel = (ushort)EditKillHumanWinLevel.Value;
            ModValue();
        }

        public void EditKilledLostLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nKilledLostLevel = (ushort)EditKilledLostLevel.Value;
            ModValue();
        }

        public void EditKillHumanWinExpChange(object sender, EventArgs e)
        {
            if (EditKillHumanWinExp.Text == "")
            {
                EditKillHumanWinExp.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nKillHumanWinExp = (ushort)EditKillHumanWinExp.Value;
            ModValue();
        }

        public void EditKillHumanLostExpChange(object sender, EventArgs e)
        {
            if (EditKillHumanLostExp.Text == "")
            {
                EditKillHumanLostExp.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nKillHumanLostExp = (uint)EditKillHumanLostExp.Value;
            ModValue();
        }

        public void EditHumanLevelDifferChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHumanLevelDiffer = (ushort)EditHumanLevelDiffer.Value;
            ModValue();
        }

        public void CheckBoxPKLevelProtectClick(object sender, EventArgs e)
        {
            bool boStatus;
            boStatus = CheckBoxPKLevelProtect.Checked;
            EditPKProtectLevel.Enabled = boStatus;
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boPKLevelProtect = boStatus;
            ModValue();
        }

        public void EditPKProtectLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nPKProtectLevel = (ushort)EditPKProtectLevel.Value;
            ModValue();
        }

        public void EditRedPKProtectLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRedPKProtectLevel = (ushort)EditRedPKProtectLevel.Value;
            ModValue();
        }

        public void ButtonOptionSave2Click(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "DecPkPointTime", M2Share.g_Config.dwDecPkPointTime);

            M2Share.Config.WriteInteger("Setup", "DecPkPointCount", M2Share.g_Config.nDecPkPointCount);

            M2Share.Config.WriteInteger("Setup", "PKFlagTime", M2Share.g_Config.dwPKFlagTime);

            M2Share.Config.WriteInteger("Setup", "KillHumanWeaponUnlockRate", M2Share.g_Config.nKillHumanWeaponUnlockRate);

            M2Share.Config.WriteInteger("Setup", "KillHumanAddPKPoint", M2Share.g_Config.nKillHumanAddPKPoint);

            M2Share.Config.WriteInteger("Setup", "KillHumanDecLuckPoint", M2Share.g_Config.nKillHumanDecLuckPoint);

            M2Share.Config.WriteBool("Setup", "KillHumanWinLevel", M2Share.g_Config.boKillHumanWinLevel);

            M2Share.Config.WriteBool("Setup", "KilledLostLevel", M2Share.g_Config.boKilledLostLevel);

            M2Share.Config.WriteInteger("Setup", "KillHumanWinLevelPoint", M2Share.g_Config.nKillHumanWinLevel);

            M2Share.Config.WriteInteger("Setup", "KilledLostLevelPoint", M2Share.g_Config.nKilledLostLevel);

            M2Share.Config.WriteBool("Setup", "KillHumanWinExp", M2Share.g_Config.boKillHumanWinExp);

            M2Share.Config.WriteBool("Setup", "KilledLostExp", M2Share.g_Config.boKilledLostExp);

            M2Share.Config.WriteInteger("Setup", "KillHumanWinExpPoint", M2Share.g_Config.nKillHumanWinExp);

            M2Share.Config.WriteInteger("Setup", "KillHumanLostExpPoint", M2Share.g_Config.nKillHumanLostExp);

            M2Share.Config.WriteInteger("Setup", "HumanLevelDiffer", M2Share.g_Config.nHumanLevelDiffer);

            M2Share.Config.WriteBool("Setup", "PKProtect", M2Share.g_Config.boPKLevelProtect);

            M2Share.Config.WriteInteger("Setup", "PKProtectLevel", M2Share.g_Config.nPKProtectLevel);

            M2Share.Config.WriteInteger("Setup", "RedPKProtectLevel", M2Share.g_Config.nRedPKProtectLevel);
            uModValue();
        }

        public void CheckBoxTestServerClick(object sender, EventArgs e)
        {
            bool boStatue;
            boStatue = CheckBoxTestServer.Checked;
            EditTestLevel.Enabled = boStatue;
            EditTestGold.Enabled = boStatue;
            EditTestUserLimit.Enabled = boStatue;
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boTestServer = boStatue;
            ModValue();
        }

        public void CheckBoxServiceModeClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boServiceMode = CheckBoxServiceMode.Checked;
            ModValue();
        }

        public void CheckBoxVentureModeClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boVentureServer = CheckBoxVentureMode.Checked;
            ModValue();
        }

        public void CheckBoxNonPKModeClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boNonPKServer = CheckBoxNonPKMode.Checked;
            ModValue();
        }

        public void EditTestLevelKeyDown(object sender, EventArgs e)
        {
            EditTestLevel.Tag = EditTestLevel.Value;
        }

        public void EditTestLevelChange(object sender, EventArgs e)
        {
            if (EditTestLevel.Text == "")
            {
                EditTestLevel.Tag = 1;
                EditTestLevel.Text = "0";
                return;
            }
            if ((EditTestLevel.Tag.ToString() == "1") && (EditTestLevel.Value != 0))
            {
                EditTestLevel.Tag = 0;
                EditTestLevel.Value = EditTestLevel.Value / 10;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nTestLevel = (ushort)EditTestLevel.Value;
            ModValue();
        }

        public void EditTestGoldChange(object sender, EventArgs e)
        {
            if (EditTestGold.Text == "")
            {
                EditTestGold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nTestGold = (int)EditTestGold.Value;
            ModValue();
        }

        public void EditTestUserLimitChange(object sender, EventArgs e)
        {
            if (EditTestUserLimit.Text == "")
            {
                EditTestUserLimit.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nTestUserLimit = (ushort)EditTestUserLimit.Value;
            ModValue();
        }

        public void EditStartPermissionChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStartPermission = (byte)EditStartPermission.Value;
            ModValue();
        }

        public void EditUserFullChange(object sender, EventArgs e)
        {
            if (EditUserFull.Text == "")
            {
                EditUserFull.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUserFull = (int)EditUserFull.Value;
            ModValue();
        }

        public void EditHumanMaxGoldChange(object sender, EventArgs e)
        {
            if (EditHumanMaxGold.Text == "")
            {
                EditHumanMaxGold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHumanMaxGold = (int)EditHumanMaxGold.Value;
            ModValue();
        }

        public void EditHumanTryModeMaxGoldChange(object sender, EventArgs e)
        {
            if (EditHumanTryModeMaxGold.Text == "")
            {
                EditHumanTryModeMaxGold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHumanTryModeMaxGold = (int)EditHumanTryModeMaxGold.Value;
            ModValue();
        }

        public void EditTryModeLevelChange(object sender, EventArgs e)
        {
            if (EditTryModeLevel.Text == "")
            {
                EditTryModeLevel.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nTryModeLevel = (byte)EditTryModeLevel.Value;
            ModValue();
        }

        public void CheckBoxTryModeUseStorageClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boTryModeUseStorage = CheckBoxTryModeUseStorage.Checked;
            ModValue();
        }

        public void ButtonOptionSave0Click(object sender, EventArgs e)
        {
            M2Share.Config.WriteString("Server", "TestServer", HUtil32.BoolToStr(M2Share.g_Config.boTestServer));

            M2Share.Config.WriteInteger("Server", "TestLevel", M2Share.g_Config.nTestLevel);

            M2Share.Config.WriteInteger("Server", "TestGold", M2Share.g_Config.nTestGold);

            M2Share.Config.WriteInteger("Server", "TestServerUserLimit", M2Share.g_Config.nTestUserLimit);

            M2Share.Config.WriteString("Server", "ServiceMode", HUtil32.BoolToStr(M2Share.g_Config.boServiceMode));

            M2Share.Config.WriteString("Server", "NonPKServer", HUtil32.BoolToStr(M2Share.g_Config.boNonPKServer));

            M2Share.Config.WriteString("Server", "VentureServer", HUtil32.BoolToStr(M2Share.g_Config.boVentureServer));

            M2Share.Config.WriteInteger("Setup", "StartPermission", M2Share.g_Config.nStartPermission);

            M2Share.Config.WriteInteger("Server", "UserFull", M2Share.g_Config.nUserFull);

            M2Share.Config.WriteInteger("Setup", "HumanMaxGold", M2Share.g_Config.nHumanMaxGold);

            M2Share.Config.WriteInteger("Setup", "HumanTryModeMaxGold", M2Share.g_Config.nHumanTryModeMaxGold);

            M2Share.Config.WriteInteger("Setup", "TryModeLevel", M2Share.g_Config.nTryModeLevel);

            M2Share.Config.WriteBool("Setup", "TryModeUseStorage", M2Share.g_Config.boTryModeUseStorage);

            M2Share.Config.WriteInteger("Setup", "GroupMembersMax", M2Share.g_Config.nGroupMembersMax);

            // Config.WriteInteger('Setup', 'LimitMinOrderLevel', g_Config.nLimitMinOrderLevel); //20080220
            uModValue();
        }

        public void EditSayMsgMaxLenChange(object sender, EventArgs e)
        {
            if (EditSayMsgMaxLen.Text == "")
            {
                EditSayMsgMaxLen.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSayMsgMaxLen = (byte)EditSayMsgMaxLen.Value;
            ModValue();
        }

        public void EditSayRedMsgMaxLenChange(object sender, EventArgs e)
        {
            if (EditSayRedMsgMaxLen.Text == "")
            {
                EditSayRedMsgMaxLen.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSayRedMsgMaxLen = (byte)EditSayRedMsgMaxLen.Value;
            ModValue();
        }

        public void EditCanShoutMsgLevelChange(object sender, EventArgs e)
        {
            if (EditCanShoutMsgLevel.Text == "")
            {
                EditCanShoutMsgLevel.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCanShoutMsgLevel = (ushort)EditCanShoutMsgLevel.Value;
            ModValue();
        }

        public void EditSayMsgTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwSayMsgTime = (uint)EditSayMsgTime.Value * 1000;
            ModValue();
        }

        public void EditSayMsgCountChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSayMsgCount = (byte)EditSayMsgCount.Value;
            ModValue();
        }

        public void EditDisableSayMsgTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwDisableSayMsgTime = (uint)EditDisableSayMsgTime.Value * 1000;
            ModValue();
        }

        public void CheckBoxShutRedMsgShowGMNameClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boShutRedMsgShowGMName = CheckBoxShutRedMsgShowGMName.Checked;
            ModValue();
        }

        public void CheckBoxShowPreFixMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boShowPreFixMsg = CheckBoxShowPreFixMsg.Checked;
            ModValue();
        }

        public void EditGMRedMsgCmdChange(object sender, EventArgs e)
        {
            string sCmd;
            if (!boOpened)
            {
                return;
            }
            sCmd = EditGMRedMsgCmd.Text;
            M2Share.g_GMRedMsgCmd = sCmd[1];
            ModValue();
        }

        public void ButtonMsgSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "SayMsgMaxLen", M2Share.g_Config.nSayMsgMaxLen);
            M2Share.Config.WriteInteger("Setup", "SayMsgTime", M2Share.g_Config.dwSayMsgTime);
            M2Share.Config.WriteInteger("Setup", "SayMsgCount", M2Share.g_Config.nSayMsgCount);
            M2Share.Config.WriteInteger("Setup", "SayRedMsgMaxLen", M2Share.g_Config.nSayRedMsgMaxLen);
            M2Share.Config.WriteBool("Setup", "ShutRedMsgShowGMName", M2Share.g_Config.boShutRedMsgShowGMName);
            M2Share.Config.WriteInteger("Setup", "CanShoutMsgLevel", M2Share.g_Config.nCanShoutMsgLevel);
            M2Share.CommandConf.WriteString("Command", "GMRedMsgCmd", M2Share.g_GMRedMsgCmd.ToString());
            M2Share.Config.WriteBool("Setup", "ShowPreFixMsg", M2Share.g_Config.boShowPreFixMsg);
            M2Share.Config.WriteBool("Setup", "GMShowFailMsg", M2Share.g_Config.boGMShowFailMsg);// GM命令错误是否提示
            uModValue();
        }

        public void EditStartCastleWarDaysChange(object sender, EventArgs e)
        {
            if (EditStartCastleWarDays.Text == "")
            {
                EditStartCastleWarDays.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStartCastleWarDays = (byte)EditStartCastleWarDays.Value;
            ModValue();
        }

        public void EditStartCastlewarTimeChange(object sender, EventArgs e)
        {
            if (EditStartCastlewarTime.Text == "")
            {
                EditStartCastlewarTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStartCastlewarTime = (byte)EditStartCastlewarTime.Value;
            ModValue();
        }

        public void EditShowCastleWarEndMsgTimeChange(object sender, EventArgs e)
        {
            if (EditShowCastleWarEndMsgTime.Text == "")
            {
                EditShowCastleWarEndMsgTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwShowCastleWarEndMsgTime = (uint)EditShowCastleWarEndMsgTime.Value * 60000;//60 * 1000
            ModValue();
        }

        public void EditCastleWarTimeChange(object sender, EventArgs e)
        {
            if (EditCastleWarTime.Text == "")
            {
                EditCastleWarTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }

            // (60 * 1000)
            M2Share.g_Config.dwCastleWarTime = (uint)EditCastleWarTime.Value * 60000;
            ModValue();
        }

        public void EditGetCastleTimeChange(object sender, EventArgs e)
        {
            if (EditGetCastleTime.Text == "")
            {
                EditGetCastleTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }

            // (60 * 1000)
            M2Share.g_Config.dwGetCastleTime = (uint)EditGetCastleTime.Value * 60000;
            ModValue();
        }

        public void EditGuildWarTimeChange(object sender, EventArgs e)
        {
            if (EditGuildWarTime.Text == "")
            {
                EditGuildWarTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }

            // (60 * 1000)
            M2Share.g_Config.dwGuildWarTime = (uint)EditGuildWarTime.Value * 60000;
            ModValue();
        }

        public void EditMakeGhostTimeChange(object sender, EventArgs e)
        {
            if (EditMakeGhostTime.Text == "")
            {
                EditMakeGhostTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwMakeGhostTime = (uint)EditMakeGhostTime.Value * 1000;
            ModValue();
        }

        public void EditClearDropOnFloorItemTimeChange(object sender, EventArgs e)
        {
            if (EditClearDropOnFloorItemTime.Text == "")
            {
                EditClearDropOnFloorItemTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwClearDropOnFloorItemTime = (uint)EditClearDropOnFloorItemTime.Value * 1000;
            ModValue();
        }

        public void EditSaveHumanRcdTimeChange(object sender, EventArgs e)
        {
            if (EditSaveHumanRcdTime.Text == "")
            {
                EditSaveHumanRcdTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }

            // (60 * 1000)
            M2Share.g_Config.dwSaveHumanRcdTime = (uint)EditSaveHumanRcdTime.Value * 60000;
            ModValue();
        }

        public void EditHumanFreeDelayTimeChange(object sender, EventArgs e)
        {
            if (EditHumanFreeDelayTime.Text == "")
            {
                EditHumanFreeDelayTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }

            // (60 * 1000)
            M2Share.g_Config.dwHumanFreeDelayTime = (uint)EditHumanFreeDelayTime.Value * 60000;
            ModValue();
        }

        public void EditFloorItemCanPickUpTimeChange(object sender, EventArgs e)
        {
            if (EditFloorItemCanPickUpTime.Text == "")
            {
                EditFloorItemCanPickUpTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwFloorItemCanPickUpTime = (uint)EditFloorItemCanPickUpTime.Value * 1000;
            ModValue();
        }

        public void ButtonTimeSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "StartCastleWarDays", M2Share.g_Config.nStartCastleWarDays);
            M2Share.Config.WriteInteger("Setup", "StartCastlewarTime", M2Share.g_Config.nStartCastlewarTime);
            M2Share.Config.WriteInteger("Setup", "ShowCastleWarEndMsgTime", M2Share.g_Config.dwShowCastleWarEndMsgTime);
            M2Share.Config.WriteInteger("Setup", "CastleWarTime", M2Share.g_Config.dwCastleWarTime);
            M2Share.Config.WriteInteger("Setup", "GetCastleTime", M2Share.g_Config.dwGetCastleTime);
            M2Share.Config.WriteInteger("Setup", "GuildWarTime", M2Share.g_Config.dwGuildWarTime);
            M2Share.Config.WriteInteger("Setup", "SaveHumanRcdTime", M2Share.g_Config.dwSaveHumanRcdTime);
            M2Share.Config.WriteInteger("Setup", "HumanFreeDelayTime", M2Share.g_Config.dwHumanFreeDelayTime);
            M2Share.Config.WriteInteger("Setup", "MakeGhostTime", M2Share.g_Config.dwMakeGhostTime);
            M2Share.Config.WriteInteger("Setup", "MakeGhostPlayMosterTime", M2Share.g_Config.dwMakeGhostPlayMosterTime);// 人形怪尸体清理时间
            M2Share.Config.WriteInteger("Setup", "ClearDropOnFloorItemTime", M2Share.g_Config.dwClearDropOnFloorItemTime);
            M2Share.Config.WriteInteger("Setup", "FloorItemCanPickUpTime", M2Share.g_Config.dwFloorItemCanPickUpTime);
            uModValue();
        }

        public void EditBuildGuildPriceChange(object sender, EventArgs e)
        {
            if (EditBuildGuildPrice.Text == "")
            {
                EditBuildGuildPrice.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBuildGuildPrice = (int)EditBuildGuildPrice.Value;
            ModValue();
        }

        public void EditGuildWarPriceChange(object sender, EventArgs e)
        {
            if (EditGuildWarPrice.Text == "")
            {
                EditGuildWarPrice.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nGuildWarPrice = (int)EditGuildWarPrice.Value;
            ModValue();
        }

        public void EditMakeDurgPriceChange(object sender, EventArgs e)
        {
            if (EditMakeDurgPrice.Text == "")
            {
                EditMakeDurgPrice.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMakeDurgPrice = (int)EditMakeDurgPrice.Value;
            ModValue();
        }

        public void EditSuperRepairPriceRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSuperRepairPriceRate = (byte)EditSuperRepairPriceRate.Value;
            ModValue();
        }

        public void EditRepairItemDecDuraChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRepairItemDecDura = (byte)EditRepairItemDecDura.Value;
            ModValue();
        }

        public void ButtonPriceSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "BuildGuild", M2Share.g_Config.nBuildGuildPrice);
            M2Share.Config.WriteInteger("Setup", "MakeDurg", M2Share.g_Config.nMakeDurgPrice);
            M2Share.Config.WriteInteger("Setup", "GuildWarFee", M2Share.g_Config.nGuildWarPrice);
            M2Share.Config.WriteInteger("Setup", "SuperRepairPriceRate", M2Share.g_Config.nSuperRepairPriceRate);
            M2Share.Config.WriteInteger("Setup", "RepairItemDecDura", M2Share.g_Config.nRepairItemDecDura);
            uModValue();
        }

        public void EditHearMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditHearMsgFColor.Value;
            LabeltHearMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btHearMsgFColor = btColor;
            ModValue();
        }

        public void EdittHearMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EdittHearMsgBColor.Value;
            LabelHearMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btHearMsgBColor = btColor;
            ModValue();
        }

        public void EditWhisperMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditWhisperMsgFColor.Value;
            LabelWhisperMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btWhisperMsgFColor = btColor;
            ModValue();
        }

        public void EditWhisperMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditWhisperMsgBColor.Value;
            LabelWhisperMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btWhisperMsgBColor = btColor;
            ModValue();
        }

        public void EditGMWhisperMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGMWhisperMsgFColor.Value;
            LabelGMWhisperMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGMWhisperMsgFColor = btColor;
            ModValue();
        }

        public void EditGMWhisperMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGMWhisperMsgBColor.Value;
            LabelGMWhisperMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGMWhisperMsgBColor = btColor;
            ModValue();
        }

        public void EditRedMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditRedMsgFColor.Value;
            LabelRedMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btRedMsgFColor = btColor;
            ModValue();
        }

        public void EditRedMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditRedMsgBColor.Value;
            LabelRedMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btRedMsgBColor = btColor;
            ModValue();
        }

        public void EditGreenMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGreenMsgFColor.Value;
            LabelGreenMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGreenMsgFColor = btColor;
            ModValue();
        }

        public void EditGreenMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGreenMsgBColor.Value;
            LabelGreenMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGreenMsgBColor = btColor;
            ModValue();
        }

        public void EditBlueMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditBlueMsgFColor.Value;
            LabelBlueMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btBlueMsgFColor = btColor;
            ModValue();
        }

        public void EditBlueMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditBlueMsgBColor.Value;
            LabelBlueMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btBlueMsgBColor = btColor;
            ModValue();
        }

        public void EditSayMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditSayMsgFColor.Value;
            LabelSayMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btSayMsgFColor = btColor;
            ModValue();
        }

        public void EditSayeMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditSayeMsgBColor.Value;
            LabelSayMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btSayeMsgBColor = btColor;
            ModValue();
        }

        public void EditCryMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditCryMsgFColor.Value;
            LabelCryMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btCryMsgFColor = btColor;
            ModValue();
        }

        public void EditCryMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditCryMsgBColor.Value;
            LabelCryMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btCryMsgBColor = btColor;
            ModValue();
        }

        public void EditGuildMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGuildMsgFColor.Value;
            LabelGuildMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGuildMsgFColor = btColor;
            ModValue();
        }

        public void EditGuildMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGuildMsgBColor.Value;
            LabelGuildMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGuildMsgBColor = btColor;
            ModValue();
        }

        public void EditGroupMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGroupMsgFColor.Value;
            LabelGroupMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGroupMsgFColor = btColor;
            ModValue();
        }

        public void EditGroupMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditGroupMsgBColor.Value;
            LabelGroupMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btGroupMsgBColor = btColor;
            ModValue();
        }

        public void EditCustMsgFColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditCustMsgFColor.Value;
            LabelCustMsgFColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btCustMsgFColor = btColor;
            ModValue();
        }

        public void EditCustMsgBColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditCustMsgBColor.Value;
            LabelCustMsgBColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btCustMsgBColor = btColor;
            ModValue();
        }

        public void ButtonMsgColorSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "HearMsgFColor", M2Share.g_Config.btHearMsgFColor);

            M2Share.Config.WriteInteger("Setup", "HearMsgBColor", M2Share.g_Config.btHearMsgBColor);

            M2Share.Config.WriteInteger("Setup", "WhisperMsgFColor", M2Share.g_Config.btWhisperMsgFColor);

            M2Share.Config.WriteInteger("Setup", "WhisperMsgBColor", M2Share.g_Config.btWhisperMsgBColor);

            M2Share.Config.WriteInteger("Setup", "GMWhisperMsgFColor", M2Share.g_Config.btGMWhisperMsgFColor);

            M2Share.Config.WriteInteger("Setup", "GMWhisperMsgBColor", M2Share.g_Config.btGMWhisperMsgBColor);

            M2Share.Config.WriteInteger("Setup", "CryMsgFColor", M2Share.g_Config.btCryMsgFColor);

            M2Share.Config.WriteInteger("Setup", "CryMsgBColor", M2Share.g_Config.btCryMsgBColor);

            M2Share.Config.WriteInteger("Setup", "GreenMsgFColor", M2Share.g_Config.btGreenMsgFColor);

            M2Share.Config.WriteInteger("Setup", "GreenMsgBColor", M2Share.g_Config.btGreenMsgBColor);

            M2Share.Config.WriteInteger("Setup", "BlueMsgFColor", M2Share.g_Config.btBlueMsgFColor);

            M2Share.Config.WriteInteger("Setup", "BlueMsgBColor", M2Share.g_Config.btBlueMsgBColor);

            M2Share.Config.WriteInteger("Setup", "SayMsgFColor", M2Share.g_Config.btSayMsgFColor);

            // 前景  千里传音 20080309

            M2Share.Config.WriteInteger("Setup", "SayeMsgBColor", M2Share.g_Config.btSayeMsgBColor);

            // 背景 千里传音 20080309

            M2Share.Config.WriteInteger("Setup", "RedMsgFColor", M2Share.g_Config.btRedMsgFColor);

            M2Share.Config.WriteInteger("Setup", "RedMsgBColor", M2Share.g_Config.btRedMsgBColor);

            M2Share.Config.WriteInteger("Setup", "GuildMsgFColor", M2Share.g_Config.btGuildMsgFColor);

            M2Share.Config.WriteInteger("Setup", "GuildMsgBColor", M2Share.g_Config.btGuildMsgBColor);

            M2Share.Config.WriteInteger("Setup", "GroupMsgFColor", M2Share.g_Config.btGroupMsgFColor);

            M2Share.Config.WriteInteger("Setup", "GroupMsgBColor", M2Share.g_Config.btGroupMsgBColor);

            M2Share.Config.WriteInteger("Setup", "CustMsgFColor", M2Share.g_Config.btCustMsgFColor);

            M2Share.Config.WriteInteger("Setup", "CustMsgBColor", M2Share.g_Config.btCustMsgBColor);

            uModValue();
        }

        public void ButtonHumanDieSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "DieScatterBag", M2Share.g_Config.boDieScatterBag);

            M2Share.Config.WriteInteger("Setup", "DieScatterBagRate", M2Share.g_Config.nDieScatterBagRate);

            M2Share.Config.WriteBool("Setup", "DieRedScatterBagAll", M2Share.g_Config.boDieRedScatterBagAll);

            M2Share.Config.WriteInteger("Setup", "DieDropUseItemRate", M2Share.g_Config.nDieDropUseItemRate);

            M2Share.Config.WriteInteger("Setup", "DieRedDropUseItemRate", M2Share.g_Config.nDieRedDropUseItemRate);

            M2Share.Config.WriteBool("Setup", "DieDropGold", M2Share.g_Config.boDieDropGold);

            M2Share.Config.WriteBool("Setup", "KillByHumanDropUseItem", M2Share.g_Config.boKillByHumanDropUseItem);

            M2Share.Config.WriteBool("Setup", "KillByMonstDropUseItem", M2Share.g_Config.boKillByMonstDropUseItem);

            uModValue();
        }

        public void ScrollBarDieDropUseItemRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarDieDropUseItemRate.Value;
            EditDieDropUseItemRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDieDropUseItemRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarDieRedDropUseItemRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarDieRedDropUseItemRate.Value;
            EditDieRedDropUseItemRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDieRedDropUseItemRate = (byte)nPostion;
            ModValue();
        }

        public void ScrollBarDieScatterBagRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarDieScatterBagRate.Value;
            EditDieScatterBagRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDieScatterBagRate = (ushort)nPostion;
            ModValue();
        }

        public void CheckBoxKillByMonstDropUseItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boKillByMonstDropUseItem = CheckBoxKillByMonstDropUseItem.Checked;
            ModValue();
        }

        public void CheckBoxKillByHumanDropUseItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boKillByHumanDropUseItem = CheckBoxKillByHumanDropUseItem.Checked;
            ModValue();
        }

        public void CheckBoxDieScatterBagClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDieScatterBag = CheckBoxDieScatterBag.Checked;
            ModValue();
        }

        public void CheckBoxDieDropGoldClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDieDropGold = CheckBoxDieDropGold.Checked;
            ModValue();
        }

        public void CheckBoxDieRedScatterBagAllClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDieRedScatterBagAll = CheckBoxDieRedScatterBagAll.Checked;
            ModValue();
        }

        private void RefCharStatusConf()
        {
            CheckBoxParalyCanRun.Checked = M2Share.g_Config.ClientConf.boParalyCanRun;
            CheckBoxParalyCanWalk.Checked = M2Share.g_Config.ClientConf.boParalyCanWalk;
            CheckBoxParalyCanHit.Checked = M2Share.g_Config.ClientConf.boParalyCanHit;
            CheckBoxParalyCanSpell.Checked = M2Share.g_Config.ClientConf.boParalyCanSpell;
        }

        public void ButtonCharStatusSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "ParalyCanRun", M2Share.g_Config.ClientConf.boParalyCanRun);
            M2Share.Config.WriteBool("Setup", "ParalyCanWalk", M2Share.g_Config.ClientConf.boParalyCanWalk);
            M2Share.Config.WriteBool("Setup", "ParalyCanHit", M2Share.g_Config.ClientConf.boParalyCanHit);
            M2Share.Config.WriteBool("Setup", "ParalyCanSpell", M2Share.g_Config.ClientConf.boParalyCanSpell);
            uModValue();
        }

        public void CheckBoxParalyCanRunClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ClientConf.boParalyCanRun = CheckBoxParalyCanRun.Checked;
            ModValue();
        }

        public void CheckBoxParalyCanWalkClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ClientConf.boParalyCanWalk = CheckBoxParalyCanWalk.Checked;
            ModValue();
        }

        public void CheckBoxParalyCanHitClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ClientConf.boParalyCanHit = CheckBoxParalyCanHit.Checked;
            ModValue();
        }

        public void CheckBoxParalyCanSpellClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ClientConf.boParalyCanSpell = CheckBoxParalyCanSpell.Checked;
            ModValue();
        }

        public void ButtonActionSpeedConfigClick(object sender, EventArgs e)
        {
            //ActionSpeedConfig.Units.ActionSpeedConfig.frmActionSpeed = new TfrmActionSpeed(this.Owner);
            //ActionSpeedConfig.Units.ActionSpeedConfig.frmActionSpeed.Top = this.Top + 20;
            //ActionSpeedConfig.Units.ActionSpeedConfig.frmActionSpeed.Left = this.Left;
            //ActionSpeedConfig.Units.ActionSpeedConfig.frmActionSpeed.Open();
            //ActionSpeedConfig.Units.ActionSpeedConfig.frmActionSpeed.Free;
        }

        public void CheckBoxSafeAreaClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boSafeAreaLimited = CheckBoxSafeArea.Checked;
            ModValue();
        }

        public void CheckBoxFixExpClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boUseFixExp = CheckBoxFixExp.Checked;
            SpinEditBaseExp.Enabled = !CheckBoxFixExp.Checked;
            SpinEditAddExp.Enabled = !CheckBoxFixExp.Checked;
            ModValue();
        }

        public void SpinEditBaseExpChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBaseExp = (int)SpinEditBaseExp.Value;
            ModValue();
        }

        public void SpinEditAddExpChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nAddExp = (int)SpinEditAddExp.Value;
            ModValue();
        }

        public void CheckBoxHighLevelGroupFixExpClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHighLevelGroupFixExp = CheckBoxHighLevelGroupFixExp.Checked;
            ModValue();
        }

        public void SpinEditLimitExpLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nLimitExpLevel = (ushort)SpinEditLimitExpLevel.Value;
            ModValue();
        }

        public void SpinEditLimitExpValueChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nLimitExpValue = (uint)SpinEditLimitExpValue.Value;
            ModValue();
        }

        // 进入排行的最低等级
        public void SpinEditLimitMinOrderLevelChange(object sender, EventArgs e)
        {
            // if not boOpened then Exit;   20080220
            // g_Config.nLimitMinOrderLevel := SpinEditLimitMinOrderLevel.Value;
            // ModValue();
        }

        public void ButtonAssistantSaveClick(object sender, EventArgs e)
        {
            // (*{$IF SoftVersion <> VERDEMO}
            // Config.WriteInteger('WgInfo', 'ClientWgInfo', g_Config.ClientConf.nClientWgInfo);
            // Config.WriteBool('WgInfo', 'ShowRedHPLable', g_Config.ClientConf.boShowRedHPLable);
            // Config.WriteBool('WgInfo', 'ShowGroupMember', g_Config.ClientConf.boShowGroupMember);
            // Config.WriteBool('WgInfo', 'ShowAllItem', g_Config.ClientConf.boShowAllItem);
            // Config.WriteBool('WgInfo', 'ShowBlueMpLable', g_Config.ClientConf.boShowBlueMpLable);
            // Config.WriteBool('WgInfo', 'ShowName', g_Config.ClientConf.boShowName);
            // Config.WriteBool('WgInfo', 'AutoPuckUpItem', g_Config.ClientConf.boAutoPuckUpItem);
            // Config.WriteBool('WgInfo', 'ShowHPNumber', g_Config.ClientConf.boShowHPNumber);
            // Config.WriteBool('WgInfo', 'ShowAllName', g_Config.ClientConf.boShowAllName);
            // Config.WriteBool('WgInfo', 'ForceNotViewFog', g_Config.ClientConf.boForceNotViewFog);
            // Config.WriteBool('WgInfo', 'ParalyCan', g_Config.ClientConf.boParalyCan);
            // Config.WriteBool('WgInfo', 'MoveSlow', g_Config.ClientConf.boMoveSlow);
            // Config.WriteBool('WgInfo', 'CanStartRun', g_Config.ClientConf.boCanStartRun);
            // Config.WriteBool('WgInfo', 'AutoMagic', g_Config.ClientConf.boAutoMagic);
            // Config.WriteBool('WgInfo', 'MoveRedShow', g_Config.ClientConf.boMoveRedShow);
            // Config.WriteBool('WgInfo', 'MagicLock', g_Config.ClientConf.boMagicLock);
            // Config.WriteInteger('WgInfo', 'MoveTime', g_Config.ClientConf.nMoveTime);
            // Config.WriteInteger('WgInfo', 'HitTime', g_Config.ClientConf.nHitTime);
            // Config.WriteInteger('WgInfo', 'SpellTime', g_Config.ClientConf.nSpellTime);
            // {$IFEND}
            // uModValue();*)
        }

        public void RadioButtonSdoAssistantClick(object sender, EventArgs e)
        {
        }

        // 是否保存双倍经验时间 20080412
        public void CheckBoxSaveExpRateClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boSaveExpRate = CheckBoxSaveExpRate.Checked;
            ModValue();
        }

        // 人形怪尸体清理时间 20080418
        public void EditMakeGhostPlayMosterTimeChange(object sender, EventArgs e)
        {
            if (EditMakeGhostPlayMosterTime.Text == "")
            {
                EditMakeGhostPlayMosterTime.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwMakeGhostPlayMosterTime = (uint)EditMakeGhostPlayMosterTime.Value * 1000;
            ModValue();
        }

        // GM命令错误是否提示 20080602
        public void CheckBoxGMShowMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boGMShowFailMsg = CheckBoxGMShowMsg.Checked;
            ModValue();
        }

        public void EditKillHumanWeaponUnlockRateChange(object sender, EventArgs e)
        {
            if (EditKillHumanWeaponUnlockRate.Text == "")
            {
                EditKillHumanWeaponUnlockRate.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nKillHumanWeaponUnlockRate = (byte)EditKillHumanWeaponUnlockRate.Value;
            ModValue();
        }

        // 记录人物私聊，行会聊天信息 20081213
        public void CheckBoxRecordClientMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boRecordClientMsg = CheckBoxRecordClientMsg.Checked;
            ModValue();
        }
    }
}