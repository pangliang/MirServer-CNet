using GameFramework;
using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmHeroConfig : Form
    {
        public static TfrmHeroConfig frmHeroConfig = null;

        private bool boOpened = false;
        private bool boModValued = false;
        public TfrmHeroConfig()
        {
            InitializeComponent();
        }

        private void ModValue()
        {
            boModValued = true;
            ButtonHeroExpSave.Enabled = true;
            ButtonHeroDieSave.Enabled = true;
            ButtonHeroAttackSave.Enabled = true;
            ButtonHeroSkillSave.Enabled = true;
            OtherHeroSetSavebtn.Enabled = true;
        }

        private void uModValue()
        {
            boModValued = false;
            ButtonHeroExpSave.Enabled = false;
            ButtonHeroDieSave.Enabled = false;
            ButtonHeroAttackSave.Enabled = false;
            ButtonHeroSkillSave.Enabled = false;
            OtherHeroSetSavebtn.Enabled = false;
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
            //LevelExpScheme = ((ComboBoxLevelExp.Items.Objects[ComboBoxLevelExp.SelectedIndex]) as TLevelExpScheme);
            switch (LevelExpScheme)
            {
                case TLevelExpScheme.s_OldLevelExp:
                    M2Share.g_Config.dwHeroNeedExps = M2Share.g_dwOldNeedExps;
                    break;
                case TLevelExpScheme.s_StdLevelExp:
                    M2Share.g_Config.dwHeroNeedExps = M2Share.g_dwOldNeedExps;
                    dwOneLevelExp = Convert.ToUInt32(4000000000 / M2Share.g_Config.dwHeroNeedExps.GetUpperBound(0));
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
                        M2Share.g_Config.dwHeroNeedExps[26 + I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_2Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 2;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_5Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 5;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_8Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 8;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_10Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 10;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_20Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 20;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_30Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 30;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_40Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 40;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_50Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 50;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_60Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 60;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_70Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 70;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_80Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 80;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_90Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 90;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_100Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 100;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_150Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 150;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_200Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 200;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_250Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 250;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
                case TLevelExpScheme.s_300Mult:
                    for (I = 1; I <= M2Share.MAXCHANGELEVEL; I++)
                    {
                        dwExp = M2Share.g_Config.dwHeroNeedExps[I] / 300;
                        if (dwExp == 0)
                        {
                            dwExp = 1;
                        }
                        M2Share.g_Config.dwHeroNeedExps[I] = dwExp;
                    }
                    break;
            }
            //for (I = 1; I < GridLevelExp.RowCount; I++)
            //{
            //    GridLevelExp.Cells[1, I] = (M2Share.g_Config.dwHeroNeedExps[I]).ToString();
            //}
            ModValue();
        }

        // Public declarations
        public void Open()
        {
            int I;
            string s01;
            boOpened = false;
            PageControl.SelectedIndex = 0;
            uModValue();

            //for (I = 1; I < GridLevelExp.RowCount; I++)
            //{
            //    GridLevelExp.Cells[1, I] = (M2Share.g_Config.dwHeroNeedExps[I]).ToString();
            //}

            GroupBoxLevelExp.Text = string.Format("升级经验(最高有效等级{0})", M2Share.MAXUPLEVEL);
            EditStartLevel.Value = M2Share.g_Config.nHeroStartLevel;
            EditDrinkHeroStartLevel.Value = M2Share.g_Config.nDrinkHeroStartLevel;// 卧龙英雄开始等级 
            EditKillMonExpRate.Value = M2Share.g_Config.nHeroKillMonExpRate;
            EditNoEditKillMonExpRate.Value = M2Share.g_Config.nHeroNoKillMonExpRate;//  非杀怪分配经验比例
            ComboBoxBagItemCount.Items.Clear();
            EditHeroRecallTick.Value = M2Share.g_Config.nRecallHeroTime / 1000;// 召唤英雄间隔 
            EditMakeGhostHeroTime.Value = M2Share.g_Config.nMakeGhostHeroTime / 1000;// 英雄尸体清理时间 
            SpinEditHeroHPRate.Value = M2Share.g_Config.nHeroHPRate;// 英雄HP为人物的倍数 
            EditDeathDecLoyal.Value = M2Share.g_Config.nDeathDecLoyal;// 死亡减少忠城度 
            EditPKDecLoyal.Value = M2Share.g_Config.nPKDecLoyal;// PK值减少忠诚度 
            EditGuildIncLoyal.Value = M2Share.g_Config.nGuildIncLoyal;// 行会战增加忠诚度 
            EditLevelOrderIncLoyal.Value = M2Share.g_Config.nLevelOrderIncLoyal;// 人物等级排名上升增加忠诚度 
            EditLevelOrderDecLoyal.Value = M2Share.g_Config.nLevelOrderDecLoyal;// 人物等级排名下降减少忠诚度 
            EditWinExp.Value = M2Share.g_Config.nWinExp;// 获得经验 
            EditExpAddLoyal.Value = M2Share.g_Config.nExpAddLoyal;// 经验加忠诚 
            EditGotoLV4.Value = M2Share.g_Config.nGotoLV4;// 四级触发 
            EditPowerLv4.Value = M2Share.g_Config.nPowerLV4;// 四级技能杀伤力增加值 
            // EditHeroRunIntervalTime.Value := g_Config.dwHeroRunIntervalTime;//战英雄跑步间隔 
            // EditHeroRunIntervalTime1.Value := g_Config.dwHeroRunIntervalTime1;//法英雄跑步间隔 
            // EditHeroRunIntervalTime2.Value := g_Config.dwHeroRunIntervalTime2;//道英雄跑步间隔 
            EditHeroWalkIntervalTime.Value = M2Share.g_Config.dwHeroWalkIntervalTime;// 英雄走路间隔 
            EditHeroTurnIntervalTime.Value = M2Share.g_Config.dwHeroTurnIntervalTime;// 英雄转向间隔 
            EditHeroMagicHitIntervalTime.Value = M2Share.g_Config.dwHeroMagicHitIntervalTime;// 英雄魔法间隔 
            if (!M2Share.g_Config.btHeroSkillMode)// 英雄施毒术使用模式 
            {
                RadioHeroSkillMode.Checked = true;
                RadioHeroSkillModeAll.Checked = false;
            }
            else
            {
                RadioHeroSkillMode.Checked = false;
                RadioHeroSkillModeAll.Checked = true;
            }
            if (!M2Share.g_Config.btHeroSkillMode50) // 英雄无极真气使用模式
            {
                RadioHeroSkillMode50.Checked = true;
                RadioHeroSkillMode50All.Checked = false;
            }
            else
            {
                RadioHeroSkillMode50.Checked = false;
                RadioHeroSkillMode50All.Checked = true;
            }
            if (!M2Share.g_Config.btHeroSkillMode46) // 英雄分身术使用模式
            {
                RadioHeroSkillMode46.Checked = true;
                RadioHeroSkillMode46All.Checked = false;
            }
            else
            {
                RadioHeroSkillMode46.Checked = false;
                RadioHeroSkillMode46All.Checked = true;
            }
            if (!M2Share.g_Config.btHeroSkillMode43) // 英雄开天斩重击模式
            {
                RadioHeroSkillMode43.Checked = true;
                RadioHeroSkillMode43All.Checked = false;
            }
            else
            {
                RadioHeroSkillMode43.Checked = false;
                RadioHeroSkillMode43All.Checked = true;
            }
            if (!M2Share.g_Config.btHeroSkillMode_63)// 噬魂沼泽使用绿毒模式
            {
                RadioHeroSkillMode_63.Checked = true;
                RadioHeroSkillMode_63ALL.Checked = false;
            }
            else
            {
                RadioHeroSkillMode_63.Checked = false;
                RadioHeroSkillMode_63ALL.Checked = true;
            }
            for (I = M2Share.g_Config.nHeroBagItemCount.GetLowerBound(0); I <= M2Share.g_Config.nHeroBagItemCount.GetUpperBound(0); I++)
            {
                switch (I)
                {
                    case 0:
                        s01 = "10格";
                        break;
                    case 1:
                        s01 = "20格";
                        break;
                    case 2:
                        s01 = "30格";
                        break;
                    case 3:
                        s01 = "35格";
                        break;
                    case 4:
                        s01 = "40格";
                        break;
                }

               // ComboBoxBagItemCount.Items.AddObject(s01, ((M2Share.g_Config.nHeroBagItemCount[I]) as Object));
            }
            SpinEditWarrorAttackTime.Value = M2Share.g_Config.dwHeroWarrorAttackTime;
            SpinEditWizardAttackTime.Value = M2Share.g_Config.dwHeroWizardAttackTime;
            SpinEditTaoistAttackTime.Value = M2Share.g_Config.dwHeroTaoistAttackTime;
            CheckBoxKillByMonstDropUseItem.Checked = M2Share.g_Config.boHeroKillByMonstDropUseItem;
            CheckBoxKillByHumanDropUseItem.Checked = M2Share.g_Config.boHeroKillByHumanDropUseItem;
            CheckBoxDieScatterBag.Checked = M2Share.g_Config.boHeroDieScatterBag;
            CheckBoxDieRedScatterBagAll.Checked = M2Share.g_Config.boHeroDieRedScatterBagAll;
            CheckBoxHeroDieExp.Checked = M2Share.g_Config.boHeroDieExp;// 英雄死亡掉经验 
            CheckBoxHeroNoTargetCall.Checked = M2Share.g_Config.boHeroNoTargetCall;// 英雄无目标下可召唤宝宝 
            CheckBoxHeroAutoProtectionDefence.Checked = M2Share.g_Config.boHeroAutoProtectionDefence;// 英雄无目标下自动开启护体神盾 
            if (M2Share.g_Config.boHeroDieExp)
            {
                SpinEditHeroDieExpRate.Enabled = true;
            }
            else
            {
                SpinEditHeroDieExpRate.Enabled = false;
            }
            SpinEditHeroDieExpRate.Value = M2Share.g_Config.nHeroDieExpRate;// 英雄死亡掉经验比率
            ScrollBarDieDropUseItemRate.Minimum = 1;
            ScrollBarDieDropUseItemRate.Maximum = 200;
            ScrollBarDieDropUseItemRate.Value = M2Share.g_Config.nHeroDieDropUseItemRate;
            ScrollBarDieRedDropUseItemRate.Minimum = 1;
            ScrollBarDieRedDropUseItemRate.Maximum = 200;
            ScrollBarDieRedDropUseItemRate.Value = M2Share.g_Config.nHeroDieRedDropUseItemRate;
            ScrollBarDieScatterBagRate.Minimum = 1;
            ScrollBarDieScatterBagRate.Maximum = 200;
            ScrollBarDieScatterBagRate.Value = M2Share.g_Config.nHeroDieScatterBagRate;
            SpinEditEatHPItemRate.Value = M2Share.g_Config.nHeroAddHPRate;
            SpinEditEatMPItemRate.Value = M2Share.g_Config.nHeroAddMPRate;
            SpinEditEatItemTick.Value = M2Share.g_Config.nHeroAddHPMPTick;// 英雄吃普通药速度 
            SpinEditEatHPItemRate1.Value = M2Share.g_Config.nHeroAddHPRate1;
            SpinEditEatMPItemRate1.Value = M2Share.g_Config.nHeroAddMPRate1;
            SpinEditEatItemTick1.Value = M2Share.g_Config.nHeroAddHPMPTick1;// 吃特殊药速度 
            ComboBoxBagItemCount.SelectedIndex = -1;
            ComboBoxBagItemCount.Text = "选择包裹数";
            SpinEditNeedLevel.Value = 1;
            SpinEditNeedLevel.Enabled = false;
            EditMaxFirDragonPoint.Value = M2Share.g_Config.nMaxFirDragonPoint;
            EditAddFirDragonPoint.Value = M2Share.g_Config.nAddFirDragonPoint;
            EditDecFirDragonPoint.Value = M2Share.g_Config.nDecFirDragonPoint;
            SpinEditIncDragonPointTick.Value = M2Share.g_Config.nIncDragonPointTick;// 加怒气时间间隔 
            SpinEditHeroSkill46MaxHP_0.Value = M2Share.g_Config.nHeroSkill46MaxHP_0;// 英雄召唤分身HP的比率 
            SpinEditHeroSkill46MaxHP_1.Value = M2Share.g_Config.nHeroSkill46MaxHP_1;// 1级 英雄召唤分身HP的比率 
            SpinEditHeroSkill46MaxHP_2.Value = M2Share.g_Config.nHeroSkill46MaxHP_2;// 2级 英雄召唤分身HP的比率 
            SpinEditHeroSkill46MaxHP_3.Value = M2Share.g_Config.nHeroSkill46MaxHP_3;// 3级 英雄召唤分身HP的比率 
            SpinEditHeroMakeSelfTick.Value = M2Share.g_Config.nHeroMakeSelfTick;// 英雄分身延长使用时间 
            SpinEditDecDragonHitPoint.Value = M2Share.g_Config.nDecDragonHitPoint;// 饮酒减少合击伤害 
            EditDecDragonRate.Value = M2Share.g_Config.nDecDragonRate;// 合击对人物的伤害比例 
            EditHeroAttackRate_60.Value = M2Share.g_Config.nHeroAttackRate_60;// 破魂斩威力 
            EditHeroAttackRange_60.Value = M2Share.g_Config.nHeroAttackRange_60;// 破魂斩 攻击范围 
            EditHeroAttackRate_61.Value = M2Share.g_Config.nHeroAttackRate_61;// 劈星斩威力 
            EditHeroAttackRate_62.Value = M2Share.g_Config.nHeroAttackRate_62;// 雷霆一击威力 
            EditHeroAttackRate_63.Value = M2Share.g_Config.nHeroAttackRate_63;// 噬魂沼泽威力 
            EditHeroAttackRange_63.Value = M2Share.g_Config.nHeroAttackRange_63;// 噬魂沼泽 攻击范围 
            EditHeroAttackRate_64.Value = M2Share.g_Config.nHeroAttackRate_64;// 末日审判威力 
            EditHeroAttackRate_65.Value = M2Share.g_Config.nHeroAttackRate_65;// 火龙气焰威力 
            EditHeroAttackRange_64.Value = M2Share.g_Config.nHeroAttackRange_64;// 末日审判  攻击范围 
            EditHeroAttackRange_65.Value = M2Share.g_Config.nHeroAttackRange_65;// 火龙气焰 攻击范围 
            EditHeroNameColor.Value = M2Share.g_Config.nHeroNameColor;// 英雄名字颜色 
            EdtHeroName.Text = M2Share.g_Config.sHeroName;// 英雄名字 
            EditHeroNameSuffix.Text = M2Share.g_Config.sHeroNameSuffix;// 英雄名后缀  
            CheckNameSuffix.Checked = M2Share.g_Config.boNameSuffix;// 是否显示后缀  
            CheckBoxHeroProtect.Checked = M2Share.g_Config.boNoSafeProtect;// 禁止安全区守护 
            CheckBoxHeroRestNoFollow.Checked = M2Share.g_Config.boRestNoFollow;// 英雄休息不跟随主人切换地图 
            CheckBoxHeroAttackTarget.Checked = M2Share.g_Config.boHeroAttackTarget;// 道法22前是否物理攻击 
            CheckBoxHeroAttackTao.Checked = M2Share.g_Config.boHeroAttackTao;// 道22后是否物理攻击 
            SpinEditDecGlod1.Value = M2Share.g_Config.Strength1DecGold;
            SpinEditDecGameGird1.Value = M2Share.g_Config.Strength1DecGameGird;
            SpinEditExp1.Value = M2Share.g_Config.Strength1Exp;
            SpinEditDecGlod2.Value = M2Share.g_Config.Strength2DecGold;
            SpinEditDecGameGird2.Value = M2Share.g_Config.Strength2DecGameGird;
            SpinEditExp2.Value = M2Share.g_Config.Strength2Exp;
            SpinEditDecGlod3.Value = M2Share.g_Config.Strength3DecGold;
            SpinEditDecGameGird3.Value = M2Share.g_Config.Strength3DecGameGird;
            SpinEditExp3.Value = M2Share.g_Config.Strength3Exp;
            SpinEditRecallDeputyHero.Value = M2Share.g_Config.RecallDeputyHeroTime / 1000;
            boOpened = true;
            this.ShowDialog();
        }

        public void FormCreate(object sender, EventArgs e)
        {
            //int I;
            //GridLevelExp.PreferredColumnWidth[0] = 30;
            //GridLevelExp.PreferredColumnWidth[1] = 100;
            //GridLevelExp.Cells[0, 0] = "等级";
            //GridLevelExp.Cells[1, 0] = "经验值";
            //for (I = 1; I < GridLevelExp.RowCount; I ++ )
            //{

            //    GridLevelExp.Cells[0, I] = (I).ToString();
            //}
            //ComboBoxLevelExp.Items.Add("原始经验值", ((TLevelExpScheme.s_OldLevelExp) as Object));
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
        }

        public void ButtonHeroExpSaveClick(object sender, EventArgs e)
        {
            int I;
            uint dwExp;
            uint[] NeedExps;
            //for (I = 1; I < GridLevelExp.RowCount; I ++ )
            //{
            //    dwExp = HUtil32.Str_ToInt(GridLevelExp.Cells[1, I], 0);
            //    // or (dwExp > High(LongWord))
            //    if ((dwExp <= 0))
            //    {
            //        // 20080522
            //        System.Windows.Forms.MessageBox.Show(("等级 " + (I).ToString() + " 升级经验设置错误！！！" as string), "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
            //        GridLevelExp.CurrentRowIndex = I;
            //        GridLevelExp.Focus();
            //        return;
            //    }
            //    NeedExps[I] = dwExp;
            //}
            //M2Share.g_Config.dwHeroNeedExps = NeedExps;
            for (I = 1; I <= 1000; I++)
            {
                M2Share.Config.WriteString("HeroExp", "Level" + (I).ToString(), (M2Share.g_Config.dwHeroNeedExps[I]).ToString());
            }
            M2Share.Config.WriteInteger("HeroSetup", "StartLevel", M2Share.g_Config.nHeroStartLevel);
            M2Share.Config.WriteInteger("HeroSetup", "DrinkHeroStartLevel", M2Share.g_Config.nDrinkHeroStartLevel);// 卧龙英雄开始等级
            M2Share.Config.WriteInteger("HeroSetup", "KillMonExpRate", M2Share.g_Config.nHeroKillMonExpRate);
            M2Share.Config.WriteInteger("HeroSetup", "NoKillMonExpRate", M2Share.g_Config.nHeroNoKillMonExpRate);// 非杀怪分配经验比例
            for (I = M2Share.g_Config.nHeroBagItemCount.GetLowerBound(0); I <= M2Share.g_Config.nHeroBagItemCount.GetUpperBound(0); I++)
            {
                M2Share.Config.WriteInteger("HeroSetup", "BagItemCount" + (I).ToString(), M2Share.g_Config.nHeroBagItemCount[I]);
            }
            M2Share.Config.WriteInteger("HeroSetup", "WarrorAttackTime", M2Share.g_Config.dwHeroWarrorAttackTime);
            M2Share.Config.WriteInteger("HeroSetup", "WizardAttackTime", M2Share.g_Config.dwHeroWizardAttackTime);
            M2Share.Config.WriteInteger("HeroSetup", "TaoistAttackTime", M2Share.g_Config.dwHeroTaoistAttackTime);
            M2Share.Config.WriteInteger("HeroSetup", "HeroAddHPRate", M2Share.g_Config.nHeroAddHPRate);
            M2Share.Config.WriteInteger("HeroSetup", "HeroAddMPRate", M2Share.g_Config.nHeroAddMPRate);
            M2Share.Config.WriteInteger("HeroSetup", "HeroAddHPMPTick", M2Share.g_Config.nHeroAddHPMPTick);// 英雄吃普通药速度 
            M2Share.Config.WriteInteger("HeroSetup", "HeroAddHPRate1", M2Share.g_Config.nHeroAddHPRate1);
            M2Share.Config.WriteInteger("HeroSetup", "HeroAddMPRate1", M2Share.g_Config.nHeroAddMPRate1);
            M2Share.Config.WriteInteger("HeroSetup", "HeroAddHPMPTick1", M2Share.g_Config.nHeroAddHPMPTick1);// 吃特殊药速度 
            M2Share.Config.WriteInteger("HeroSetup", "RecallHeroTime", M2Share.g_Config.nRecallHeroTime);// 召唤英雄间隔 
            M2Share.Config.WriteInteger("HeroSetup", "HeroHPRate", M2Share.g_Config.nHeroHPRate);// 英雄HP为人物的倍数
            M2Share.Config.WriteInteger("HeroSetup", "DeathDecLoyal", M2Share.g_Config.nDeathDecLoyal);// 死亡减少忠城度 
            M2Share.Config.WriteInteger("HeroSetup", "PKDecLoyal", M2Share.g_Config.nPKDecLoyal);// PK值减少忠诚度 
            M2Share.Config.WriteInteger("HeroSetup", "GuildIncLoyal", M2Share.g_Config.nGuildIncLoyal);// 行会战增加忠诚度 
            M2Share.Config.WriteInteger("HeroSetup", "LevelOrderIncLoyal", M2Share.g_Config.nLevelOrderIncLoyal);// 人物等级排名上升增加忠诚度 
            M2Share.Config.WriteInteger("HeroSetup", "LevelOrderDecLoyal", M2Share.g_Config.nLevelOrderDecLoyal);// 人物等级排名下降减少忠诚度 
            M2Share.Config.WriteInteger("HeroSetup", "WinExp", M2Share.g_Config.nWinExp);// 获得经验 
            M2Share.Config.WriteInteger("HeroSetup", "ExpAddLoyal", M2Share.g_Config.nExpAddLoyal);// 经验加忠诚 
            M2Share.Config.WriteInteger("HeroSetup", "GotoLV4", M2Share.g_Config.nGotoLV4);// 四级触发 
            M2Share.Config.WriteInteger("HeroSetup", "PowerLV4", M2Share.g_Config.nPowerLV4);// 四级技能杀伤力增加值 
            // Config.WriteInteger('HeroSetup', 'HeroRunIntervalTime', g_Config.dwHeroRunIntervalTime); //战英雄跑步间隔 20080213
            // Config.WriteInteger('HeroSetup', 'HeroRunIntervalTime1', g_Config.dwHeroRunIntervalTime1); //法英雄跑步间隔 20080217
            // Config.WriteInteger('HeroSetup', 'HeroRunIntervalTime2', g_Config.dwHeroRunIntervalTime2); //道英雄跑步间隔 20080217
            M2Share.Config.WriteInteger("HeroSetup", "HeroWalkIntervalTime", M2Share.g_Config.dwHeroWalkIntervalTime);// 英雄走路间隔 20080213
            M2Share.Config.WriteInteger("HeroSetup", "HeroTurnIntervalTime", M2Share.g_Config.dwHeroTurnIntervalTime);// 英雄转向间隔 20080213
            M2Share.Config.WriteInteger("HeroSetup", "HeroMagicHitIntervalTime", M2Share.g_Config.dwHeroMagicHitIntervalTime);// 英雄魔法间隔 20080524
            M2Share.Config.WriteInteger("HeroSetup", "nHeroNameColor", M2Share.g_Config.nHeroNameColor);// 英雄名字颜色 20080315
            M2Share.Config.WriteString("HeroSetup", "sHeroName", M2Share.g_Config.sHeroName);// 英雄名字 20080315
            M2Share.Config.WriteString("HeroSetup", "sHeroNameSuffix", M2Share.g_Config.sHeroNameSuffix);// 英雄名后缀  20080315
            M2Share.Config.WriteBool("HeroSetup", "boNameSuffix", M2Share.g_Config.boNameSuffix);// 是否显示后缀  20080315
            M2Share.Config.WriteBool("HeroSetup", "boNoSafeProtect", M2Share.g_Config.boNoSafeProtect);// 禁止安全区守护 20080603
            M2Share.Config.WriteBool("HeroSetup", "boRestNoFollow", M2Share.g_Config.boRestNoFollow);// 英雄休息不跟随主人切换地图 20081209
            M2Share.Config.WriteBool("HeroSetup", "boHeroAttackTarget", M2Share.g_Config.boHeroAttackTarget);// 道法22前是否物理攻击 20081218
            M2Share.Config.WriteBool("HeroSetup", "boHeroAttackTao", M2Share.g_Config.boHeroAttackTao);// 道22后是否物理攻击 20090108
            uModValue();
        }

        public void EditStartLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroStartLevel = (ushort)EditStartLevel.Value;
            ModValue();
        }

        public void EditKillMonExpRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroKillMonExpRate = (byte)EditKillMonExpRate.Value;
            ModValue();
        }

        public void ComboBoxBagItemCountChange(object sender, EventArgs e)
        {
            SpinEditNeedLevel.Value = (decimal)ComboBoxBagItemCount.Items[ComboBoxBagItemCount.SelectedIndex];
            SpinEditNeedLevel.Enabled = true;
        }

        public void SpinEditNeedLevelChange_RefBagcount()
        {
            int I;
            for (I = 0; I < ComboBoxBagItemCount.Items.Count; I++)
            {
                // M2Share.g_Config.nHeroBagItemCount[I] = ((int)ComboBoxBagItemCount.Items[I]);
            }
        }

        public void SpinEditNeedLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ComboBoxBagItemCount.Items[ComboBoxBagItemCount.SelectedIndex] = SpinEditNeedLevel.Value;
            SpinEditNeedLevelChange_RefBagcount();
            ModValue();
        }

        public void SpinEditWarrorAttackTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
              M2Share.g_Config.dwHeroWarrorAttackTime = (uint)SpinEditWarrorAttackTime.Value;
            ModValue();
        }

        public void SpinEditWizardAttackTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwHeroWizardAttackTime = (uint)SpinEditWizardAttackTime.Value;
            ModValue();
        }

        public void SpinEditTaoistAttackTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwHeroTaoistAttackTime = (uint)SpinEditTaoistAttackTime.Value;
            ModValue();
        }

        public void ButtonHeroDieSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("HeroSetup", "KillByMonstDropUseItem", M2Share.g_Config.boHeroKillByMonstDropUseItem);
            M2Share.Config.WriteBool("HeroSetup", "KillByHumanDropUseItem", M2Share.g_Config.boHeroKillByHumanDropUseItem);
            M2Share.Config.WriteBool("HeroSetup", "DieScatterBag", M2Share.g_Config.boHeroDieScatterBag);
            M2Share.Config.WriteBool("HeroSetup", "DieRedScatterBagAll", M2Share.g_Config.boHeroDieRedScatterBagAll);
            M2Share.Config.WriteInteger("HeroSetup", "DieDropUseItemRate", M2Share.g_Config.nHeroDieDropUseItemRate);
            M2Share.Config.WriteInteger("HeroSetup", "DieRedDropUseItemRate", M2Share.g_Config.nHeroDieRedDropUseItemRate);
            M2Share.Config.WriteInteger("HeroSetup", "DieScatterBagRate", M2Share.g_Config.nHeroDieScatterBagRate);
            M2Share.Config.WriteInteger("HeroSetup", "MakeGhostHeroTime", M2Share.g_Config.nMakeGhostHeroTime);// 英雄尸体清理时间 20080418
            M2Share.Config.WriteBool("HeroSetup", "HeroDieExp", M2Share.g_Config.boHeroDieExp);// 英雄死亡掉经验 20080605
            M2Share.Config.WriteInteger("HeroSetup", "HeroDieExpRate", M2Share.g_Config.nHeroDieExpRate);// 英雄死亡掉经验比率 20080605
            uModValue();
        }

        public void CheckBoxKillByMonstDropUseItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroKillByMonstDropUseItem = CheckBoxKillByMonstDropUseItem.Checked;
            ModValue();
        }

        public void CheckBoxKillByHumanDropUseItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroKillByHumanDropUseItem = CheckBoxKillByHumanDropUseItem.Checked;
            ModValue();
        }

        public void CheckBoxDieScatterBagClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroDieScatterBag = CheckBoxDieScatterBag.Checked;
            ModValue();
        }

        public void CheckBoxDieRedScatterBagAllClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroDieRedScatterBagAll = CheckBoxDieRedScatterBagAll.Checked;
            ModValue();
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
            M2Share.g_Config.nHeroDieDropUseItemRate = (ushort)nPostion;
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
            M2Share.g_Config.nHeroDieRedDropUseItemRate = (byte)nPostion;
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
            M2Share.g_Config.nHeroDieScatterBagRate = (ushort)nPostion;
            ModValue();
        }

        public void SpinEditEatHPItemRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAddHPRate = (byte)SpinEditEatHPItemRate.Value;
            ModValue();
        }

        public void SpinEditEatMPItemRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAddMPRate = (byte)SpinEditEatMPItemRate.Value;
            ModValue();
        }

        public void ButtonHeroAttackSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("HeroSetup", "MaxFirDragonPoint", M2Share.g_Config.nMaxFirDragonPoint);
            M2Share.Config.WriteInteger("HeroSetup", "AddFirDragonPoint", M2Share.g_Config.nAddFirDragonPoint);
            M2Share.Config.WriteInteger("HeroSetup", "DecFirDragonPoint", M2Share.g_Config.nDecFirDragonPoint);
            M2Share.Config.WriteInteger("HeroSetup", "IncDragonPointTick", M2Share.g_Config.nIncDragonPointTick);// 加怒气时间间隔 20080606
            M2Share.Config.WriteInteger("HeroSetup", "DecDragonHitPoint", M2Share.g_Config.nDecDragonHitPoint);// 饮酒减少合击伤害 20080626
            M2Share.Config.WriteInteger("HeroSetup", "DecDragonRate", M2Share.g_Config.nDecDragonRate);// 合击对人物的伤害比例 20080803
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRate_60", M2Share.g_Config.nHeroAttackRate_60);// 破魂斩威力 20080131
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRange_60", M2Share.g_Config.nHeroAttackRange_60);// 破魂斩攻击范围 20080406
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRate_61", M2Share.g_Config.nHeroAttackRate_61);// 劈星斩威力 20080131
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRate_62", M2Share.g_Config.nHeroAttackRate_62);// 雷霆一击威力 20080131
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRate_63", M2Share.g_Config.nHeroAttackRate_63);// 噬魂沼泽威力 20080131
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRange_63", M2Share.g_Config.nHeroAttackRange_63);// 噬魂沼泽 攻击范围 20080131
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRate_64", M2Share.g_Config.nHeroAttackRate_64);// 末日审判威力 20080131
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRange_64", M2Share.g_Config.nHeroAttackRange_64);// 末日审判  攻击范围 20081216
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRate_65", M2Share.g_Config.nHeroAttackRate_65);// 火龙气焰威力 20080131
            M2Share.Config.WriteInteger("HeroSetup", "HeroAttackRange_65", M2Share.g_Config.nHeroAttackRange_65);// 火龙气焰 攻击范围 20080131
            M2Share.Config.WriteBool("HeroSetup", "HeroSkillMode_63", M2Share.g_Config.btHeroSkillMode_63);// 噬魂沼泽使用绿毒模式 20080911
            uModValue();
        }

        public void EditMaxFirDragonPointChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMaxFirDragonPoint = (ushort)EditMaxFirDragonPoint.Value;
            ModValue();
        }

        public void EditAddFirDragonPointChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nAddFirDragonPoint = (ushort)EditAddFirDragonPoint.Value;
            ModValue();
        }

        public void EditDecFirDragonPointChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDecFirDragonPoint = (ushort)EditDecFirDragonPoint.Value;
            ModValue();
        }

        // 破魂斩合击攻击威力 20080131
        public void EditHeroAttackRate_60Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRate_60 = (ushort)EditHeroAttackRate_60.Value;
            ModValue();
        }

        // 召唤英雄间隔 20071201
        public void EditHeroRecallTickChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRecallHeroTime = (uint)EditHeroRecallTick.Value * 1000;
            ModValue();
        }

        // 死亡减少忠城度 20080110
        public void EditDeathDecLoyalChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDeathDecLoyal = (ushort)EditDeathDecLoyal.Value;
            ModValue();
        }

        // PK值减少忠诚度 20080214
        public void EditPKDecLoyalChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nPKDecLoyal = (ushort)EditPKDecLoyal.Value;
            ModValue();
        }

        // 行会战增加忠诚度 20080214
        public void EditGuildIncLoyalChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nGuildIncLoyal = (ushort)EditGuildIncLoyal.Value;
            ModValue();
        }

        // 人物等级排名上升增加忠诚度 20080214
        public void EditLevelOrderIncLoyalChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nLevelOrderIncLoyal = (ushort)EditLevelOrderIncLoyal.Value;
            ModValue();
        }

        // 人物等级排名下降减少忠诚度 20080214
        public void EditLevelOrderDecLoyalChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nLevelOrderDecLoyal = (ushort)EditLevelOrderDecLoyal.Value;
            ModValue();
        }

        // 获得经验  20080110
        public void EditWinExpChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinExp = (int)EditWinExp.Value;
            ModValue();
        }

        // 经验加忠诚  20080110
        public void EditExpAddLoyalChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nExpAddLoyal = (ushort)EditExpAddLoyal.Value;
            ModValue();
        }

        // 四级触发   20080110
        public void EditGotoLV4Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nGotoLV4 = (ushort)EditGotoLV4.Value;
            ModValue();
        }

        // 四级技能杀伤力增加值 20080112
        public void EditPowerLv4Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nPowerLV4 = (byte)EditPowerLv4.Value;
            ModValue();
        }

        // 战英雄跑步间隔 20080213
        public void EditHeroRunIntervalTimeChange(object sender, EventArgs e)
        {
            // if not boOpened then Exit;
            // g_Config.dwHeroRunIntervalTime := EditHeroRunIntervalTime.Value;
            // ModValue();

        }

        // 法英雄跑步间隔 20080217
        public void EditHeroRunIntervalTime1Change(object sender, EventArgs e)
        {
            // if not boOpened then Exit;
            // g_Config.dwHeroRunIntervalTime1 := EditHeroRunIntervalTime1.Value;
            // ModValue();

        }

        // 道英雄跑步间隔 20080217
        public void EditHeroRunIntervalTime2Change(object sender, EventArgs e)
        {
            // if not boOpened then Exit;
            // g_Config.dwHeroRunIntervalTime2 := EditHeroRunIntervalTime2.Value;
            // ModValue();
        }

        // 英雄走路间隔 20080213
        public void EditHeroWalkIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwHeroWalkIntervalTime = (uint)EditHeroWalkIntervalTime.Value;
            ModValue();
        }

        // 英雄转向间隔 20080213
        public void EditHeroTurnIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwHeroTurnIntervalTime = (uint)EditHeroTurnIntervalTime.Value;
            ModValue();
        }

        // 劈星斩威力 20080131
        public void EditHeroAttackRate_61Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRate_61 = (ushort)EditHeroAttackRate_61.Value;
            ModValue();
        }

        // 雷霆一击威力 20080131
        public void EditHeroAttackRate_62Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRate_62 = (ushort)EditHeroAttackRate_62.Value;
            ModValue();
        }

        // 噬魂沼泽威力 20080131
        public void EditHeroAttackRate_63Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRate_63 = (ushort)EditHeroAttackRate_63.Value;
            ModValue();
        }

        // 末日审判威力 20080131
        public void EditHeroAttackRate_64Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRate_64 = (ushort)EditHeroAttackRate_64.Value;
            ModValue();
        }

        // 火龙气焰威力 20080131
        public void EditHeroAttackRate_65Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRate_65 = (ushort)EditHeroAttackRate_65.Value;
            ModValue();
        }

        // 火龙气焰 攻击范围 20080131
        public void EditHeroAttackRange_65Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRange_65 = (byte)EditHeroAttackRange_65.Value;
            ModValue();
        }

        // 噬魂沼泽 攻击范围 20080131
        public void EditHeroAttackRange_63Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRange_63 = (byte)EditHeroAttackRange_63.Value;
            ModValue();
        }

        // 英雄名字颜色 20080315
        public void EditHeroNameColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditHeroNameColor.Value;
            LabelHeroNameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroNameColor = btColor;
            ModValue();
        }

        // 是否显示后缀  20080315
        public void CheckNameSuffixClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boNameSuffix = CheckNameSuffix.Checked;
            ModValue();
        }

        // 英雄名字 20080315
        public void EdtHeroNameChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sHeroName = EdtHeroName.Text;
            ModValue();
        }

        // 英雄名后缀  20080315
        public void EditHeroNameSuffixChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sHeroNameSuffix = EditHeroNameSuffix.Text;
            ModValue();
        }

        // 破魂斩 攻击范围 20080406
        public void EditHeroAttackRange_60Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRange_60 = (byte)EditHeroAttackRange_60.Value;
            ModValue();
        }

        // 英雄尸体清理时间 20080418
        public void EditMakeGhostHeroTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMakeGhostHeroTime = (uint)EditMakeGhostHeroTime.Value * 1000;
            ModValue();
        }

        public void EditDrinkHeroStartLevelChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDrinkHeroStartLevel = (ushort)EditDrinkHeroStartLevel.Value;
            ModValue();
        }

        public void EditHeroMagicHitIntervalTimeChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwHeroMagicHitIntervalTime = (uint)EditHeroMagicHitIntervalTime.Value;
            ModValue();
        }

        // 英雄吃普通药速度 
        public void SpinEditEatItemTickChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAddHPMPTick = (uint)SpinEditEatItemTick.Value;
            ModValue();
        }

        // 禁止安全区守护 
        public void CheckBoxHeroProtectClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boNoSafeProtect = CheckBoxHeroProtect.Checked;
            ModValue();
        }

        public void ButtonHeroSkillSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_0", M2Share.g_Config.nHeroSkill46MaxHP_0);// 英雄召唤分身HP的比率 
            M2Share.Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_1", M2Share.g_Config.nHeroSkill46MaxHP_1);// 1级 英雄召唤分身HP的比率 
            M2Share.Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_2", M2Share.g_Config.nHeroSkill46MaxHP_2);// 2级 英雄召唤分身HP的比率 
            M2Share.Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_3", M2Share.g_Config.nHeroSkill46MaxHP_3);// 3级 英雄召唤分身HP的比率 
            M2Share.Config.WriteInteger("HeroSetup", "HeroMakeSelfTick", M2Share.g_Config.nHeroMakeSelfTick);// 英雄分身延长使用时间 
            M2Share.Config.WriteBool("HeroSetup", "HeroSkillMode", M2Share.g_Config.btHeroSkillMode);// 英雄施毒术使用模式 
            M2Share.Config.WriteBool("HeroSetup", "HeroNoTargetCall", M2Share.g_Config.boHeroNoTargetCall);// 英雄无目标下可召唤宝宝 
            M2Share.Config.WriteBool("HeroSetup", "HeroAutoProtectionDefence", M2Share.g_Config.boHeroAutoProtectionDefence);// 英雄无目标下自动开启护体神盾 
            M2Share.Config.WriteBool("HeroSetup", "HeroSkillMode50", M2Share.g_Config.btHeroSkillMode50);// 英雄无极真气使用模式 
            M2Share.Config.WriteBool("HeroSetup", "HeroSkillMode46", M2Share.g_Config.btHeroSkillMode46);// 英雄分身术模式 
            M2Share.Config.WriteBool("HeroSetup", "HeroSkillMode43", M2Share.g_Config.btHeroSkillMode43);// 英雄开天斩重击模式 
            uModValue();
        }

        public void RadioHeroSkillModeClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode = false;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode = true;
            }
            ModValue();
        }

        public void RadioHeroSkillModeAllClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillModeAll.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode = true;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode = false;
            }
            ModValue();
        }

        public void CheckBoxHeroDieExpClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroDieExp = CheckBoxHeroDieExp.Checked;
            if (M2Share.g_Config.boHeroDieExp)
            {
                SpinEditHeroDieExpRate.Enabled = true;
            }
            else
            {
                SpinEditHeroDieExpRate.Enabled = false;
            }
            ModValue();
        }

        public void SpinEditHeroDieExpRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroDieExpRate = (byte)SpinEditHeroDieExpRate.Value;
            ModValue();
        }

        public void SpinEditIncDragonPointTickChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nIncDragonPointTick = (uint)SpinEditIncDragonPointTick.Value;
            ModValue();
        }

        // 英雄无目标下可召唤宝宝 20080615
        public void CheckBoxHeroNoTargetCallClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroNoTargetCall = CheckBoxHeroNoTargetCall.Checked;
            ModValue();
        }

        // 饮酒减少合击伤害 20080626
        public void SpinEditDecDragonHitPointChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDecDragonHitPoint = (byte)SpinEditDecDragonHitPoint.Value;
            ModValue();
        }

        // 20080708
        public void GridLevelExpSetEditText(object sender, EventArgs e, int ACol, int ARow, string Value)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        // 英雄无目标下自动开启护体神盾 20080715
        public void CheckBoxHeroAutoProtectionDefenceClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroAutoProtectionDefence = CheckBoxHeroAutoProtectionDefence.Checked;
            ModValue();
        }

        public void EditNoEditKillMonExpRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroNoKillMonExpRate = (byte)EditNoEditKillMonExpRate.Value;
            ModValue();
        }

        public void EditDecDragonRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDecDragonRate = (byte)EditDecDragonRate.Value;
            ModValue();
        }

        public void RadioHeroSkillMode50Click(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode50.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode50 = false;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode50 = true;
            }
            ModValue();
        }

        public void RadioHeroSkillMode50AllClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode50All.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode50 = true;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode50 = false;
            }
            ModValue();
        }

        // 英雄召唤分身HP的比率 20080907
        public void SpinEditHeroSkill46MaxHP_0Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroSkill46MaxHP_0 = (byte)SpinEditHeroSkill46MaxHP_0.Value;
            ModValue();
        }

        public void SpinEditEatItemTick1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAddHPMPTick1 = (byte)SpinEditEatItemTick1.Value;
            ModValue();
        }

        public void SpinEditEatHPItemRate1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAddHPRate1 = (byte)SpinEditEatHPItemRate1.Value;
            ModValue();
        }

        public void SpinEditEatMPItemRate1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAddMPRate1 = (byte)SpinEditEatMPItemRate1.Value;
            ModValue();
        }

        public void RadioHeroSkillMode_63Click(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode_63.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode_63 = false;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode_63 = true;
            }
            ModValue();
        }

        public void RadioHeroSkillMode_63ALLClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode_63ALL.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode_63 = true;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode_63 = false;
            }
            ModValue();
        }

        public void RadioHeroSkillMode46Click(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode46.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode46 = false;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode46 = true;
            }
            ModValue();
        }

        public void RadioHeroSkillMode46AllClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode46All.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode46 = true;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode46 = false;
            }
            ModValue();
        }

        // 英雄休息不跟随主人切换地图 20081209
        public void CheckBoxHeroRestNoFollowClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boRestNoFollow = CheckBoxHeroRestNoFollow.Checked;
            ModValue();
        }

        // 末日审判  攻击范围 20081216
        public void EditHeroAttackRange_64Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroAttackRange_64 = (byte)EditHeroAttackRange_64.Value;
            ModValue();
        }

        public void SpinEditHeroMakeSelfTickChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroMakeSelfTick = (byte)SpinEditHeroMakeSelfTick.Value;
            ModValue();
        }

        // 1级 英雄召唤分身HP的比率 20081217
        public void SpinEditHeroSkill46MaxHP_1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroSkill46MaxHP_1 = (byte)SpinEditHeroSkill46MaxHP_1.Value;
            ModValue();
        }

        // 2级 英雄召唤分身HP的比率 20081217
        public void SpinEditHeroSkill46MaxHP_2Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroSkill46MaxHP_2 = (byte)SpinEditHeroSkill46MaxHP_2.Value;
            ModValue();
        }

        // 3级 英雄召唤分身HP的比率 20081217
        public void SpinEditHeroSkill46MaxHP_3Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroSkill46MaxHP_3 = (byte)SpinEditHeroSkill46MaxHP_3.Value;
            ModValue();
        }

        // 道法22前是否物理攻击
        public void CheckBoxHeroAttackTargetClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroAttackTarget = CheckBoxHeroAttackTarget.Checked;
            ModValue();
        }

        /// <summary>
        /// 英雄HP为人物的倍数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpinEditHeroHPRateChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHeroHPRate = (byte)SpinEditHeroHPRate.Value;
            ModValue();
        }

        public void RadioHeroSkillMode43Click(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode43.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode43 = false;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode43 = true;
            }
            ModValue();
        }

        public void RadioHeroSkillMode43AllClick(object sender, EventArgs e)
        {
            bool boFalg;
            if (!boOpened)
            {
                return;
            }
            boFalg = RadioHeroSkillMode43All.Checked;
            if (boFalg)
            {
                M2Share.g_Config.btHeroSkillMode43 = true;
            }
            else
            {
                M2Share.g_Config.btHeroSkillMode43 = false;
            }
            ModValue();
        }

        // 道22后是否物理攻击
        public void CheckBoxHeroAttackTaoClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHeroAttackTao = CheckBoxHeroAttackTao.Checked;
            ModValue();
        }

        public void SpinEditDecGlod1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength1DecGold = (byte)SpinEditDecGlod1.Value;
            ModValue();
        }

        public void SpinEditDecGlod2Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength2DecGold = (byte)SpinEditDecGlod2.Value;
            ModValue();
        }

        public void SpinEditDecGlod3Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength3DecGold = (byte)SpinEditDecGlod3.Value;
            ModValue();
        }

        public void SpinEditDecGameGird1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength1DecGameGird = (byte)SpinEditDecGameGird1.Value;
            ModValue();
        }

        public void SpinEditDecGameGird2Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength2DecGameGird = (byte)SpinEditDecGameGird2.Value;
            ModValue();
        }

        public void SpinEditDecGameGird3Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength3DecGameGird = (byte)SpinEditDecGameGird3.Value;
            ModValue();
        }

        public void SpinEditExp1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength1Exp = (byte)SpinEditExp1.Value;
            ModValue();
        }

        public void SpinEditExp2Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength2Exp = (byte)SpinEditExp2.Value;
            ModValue();
        }

        public void SpinEditExp3Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.Strength3Exp = (byte)SpinEditExp3.Value;
            ModValue();
        }

        public void SpinEditRecallHeroChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRecallHeroTime = (byte)SpinEditRecallHero.Value;
            ModValue();
        }

        public void SpinEditRecallDeputyHeroChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.RecallDeputyHeroTime = (byte)SpinEditRecallDeputyHero.Value * 1000;
            ModValue();
        }

        public void OtherHeroSetSavebtnClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("HeroSetup", "Strength1DecGold", M2Share.g_Config.Strength1DecGold);
            M2Share.Config.WriteInteger("HeroSetup", "Strength1DecGameGird", M2Share.g_Config.Strength1DecGameGird);
            M2Share.Config.WriteInteger("HeroSetup", "Strength1Exp", M2Share.g_Config.Strength1Exp);
            M2Share.Config.WriteInteger("HeroSetup", "Strength2DecGold", M2Share.g_Config.Strength2DecGold);
            M2Share.Config.WriteInteger("HeroSetup", "Strength2DecGameGird", M2Share.g_Config.Strength2DecGameGird);
            M2Share.Config.WriteInteger("HeroSetup", "Strength2Exp", M2Share.g_Config.Strength2Exp);
            M2Share.Config.WriteInteger("HeroSetup", "Strength3DecGold", M2Share.g_Config.Strength3DecGold);
            M2Share.Config.WriteInteger("HeroSetup", "Strength3DecGameGird", M2Share.g_Config.Strength3DecGameGird);
            M2Share.Config.WriteInteger("HeroSetup", "Strength3Exp", M2Share.g_Config.Strength3Exp);
            M2Share.Config.WriteInteger("HeroSetup", "RecallHeroTime", M2Share.g_Config.nRecallHeroTime);
            M2Share.Config.WriteInteger("HeroSetup", "RecallDeputyHeroTime", M2Share.g_Config.RecallDeputyHeroTime);
            uModValue();
        }

    }

    public enum TLevelHeroExpScheme
    {
        s_OldLevelExp,
        s_StdLevelExp,
        s_2Mult,
        s_5Mult,
        s_8Mult,
        s_10Mult,
        s_20Mult,
        s_30Mult,
        s_40Mult,
        s_50Mult,
        s_60Mult,
        s_70Mult,
        s_80Mult,
        s_90Mult,
        s_100Mult,
        s_150Mult,
        s_200Mult,
        s_250Mult,
        s_300Mult
    }
}