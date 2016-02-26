using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmFunctionConfig: Form
    {
        private bool boOpened = false;
        private bool boModValued = false;
        public static TfrmFunctionConfig frmFunctionConfig = null;

        public TfrmFunctionConfig()
        {
            InitializeComponent();
        }

        private void ModValue()
        {
            boModValued = true;
            ButtonPasswordLockSave.Enabled = true;
            ButtonGeneralSave.Enabled = true;
            ButtonSkillSave.Enabled = true;
            ButtonUpgradeWeaponSave.Enabled = true;
            ButtonMasterSave.Enabled = true;
            ButtonMakeMineSave.Enabled = true;
            ButtonWinLotterySave.Enabled = true;
            ButtonReNewLevelSave.Enabled = true;
            ButtonMonUpgradeSave.Enabled = true;
            ButtonSpiritMutinySave.Enabled = true;
            ButtonMonSayMsgSave.Enabled = true;
            ButtonSellOffSave.Enabled = true;
            ButtonChangeUseItemName.Enabled = true;
            ButtonSaveMakeWine.Enabled = true;
            ButtonWeaponMakeLuckSave.Enabled = true;
            ButtonExpCrystalSave.Enabled = true;
            ButtonSaveBatter.Enabled = true;
        }

        private void uModValue()
        {
            boModValued = false;
            ButtonPasswordLockSave.Enabled = false;
            ButtonGeneralSave.Enabled = false;
            ButtonSkillSave.Enabled = false;
            ButtonUpgradeWeaponSave.Enabled = false;
            ButtonMasterSave.Enabled = false;
            ButtonMakeMineSave.Enabled = false;
            ButtonWinLotterySave.Enabled = false;
            ButtonReNewLevelSave.Enabled = false;
            ButtonMonUpgradeSave.Enabled = false;
            ButtonSpiritMutinySave.Enabled = false;
            ButtonMonSayMsgSave.Enabled = false;
            ButtonSellOffSave.Enabled = false;
            ButtonChangeUseItemName.Enabled = false;
            ButtonSaveMakeWine.Enabled = false;
            ButtonWeaponMakeLuckSave.Enabled = false;
            ButtonExpCrystalSave.Enabled = false;
            ButtonSaveBatter.Enabled = false;
        }

        public void FunctionConfigControlChanging(Object Sender, ref bool AllowChange)
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

        public void Open()
        {
            int I;
            boOpened = false;
            uModValue();
            RefGeneral();
            CheckBoxHungerSystem.Checked = M2Share.g_Config.boHungerSystem;
            CheckBoxHungerDecHP.Checked = M2Share.g_Config.boHungerDecHP;
            CheckBoxHungerDecPower.Checked = M2Share.g_Config.boHungerDecPower;
            //CheckBoxHungerSystemClick(CheckBoxHungerSystem);
            CheckBoxEnablePasswordLock.Checked = M2Share.g_Config.boPasswordLockSystem;
            CheckBoxLockGetBackItem.Checked = M2Share.g_Config.boLockGetBackItemAction;
            CheckBoxLockDealItem.Checked = M2Share.g_Config.boLockDealAction;
            CheckBoxLockDropItem.Checked = M2Share.g_Config.boLockDropAction;
            CheckBoxLockWalk.Checked = M2Share.g_Config.boLockWalkAction;
            CheckBoxLockRun.Checked = M2Share.g_Config.boLockRunAction;
            CheckBoxLockHit.Checked = M2Share.g_Config.boLockHitAction;
            CheckBoxLockSpell.Checked = M2Share.g_Config.boLockSpellAction;
            CheckBoxLockCallHero.Checked = M2Share.g_Config.boLockCallHeroAction;//是否锁定召唤英雄操作
            CheckBoxLockSendMsg.Checked = M2Share.g_Config.boLockSendMsgAction;
            CheckBoxLockInObMode.Checked = M2Share.g_Config.boLockInObModeAction;
            CheckBoxLockLogin.Checked = M2Share.g_Config.boLockHumanLogin;
            CheckBoxLockUseItem.Checked = M2Share.g_Config.boLockUserItemAction;
            //CheckBoxEnablePasswordLockClick(CheckBoxEnablePasswordLock);
            //CheckBoxLockLoginClick(CheckBoxLockLogin);
            EditErrorPasswordCount.Value = M2Share.g_Config.nPasswordErrorCountLock;
            EditBoneFammName.Text = M2Share.g_Config.sBoneFamm;
            EditBoneFammCount.Value = M2Share.g_Config.nBoneFammCount;
            EdtDecUserGameGold.Value = M2Share.g_Config.nDecUserGameGold;// 每次扣多少元宝(元宝寄售)
            SpinEditMakeWineTime.Value = M2Share.g_Config.nMakeWineTime;// 酿普通酒等待时间
            SpinEditMakeWineTime1.Value = M2Share.g_Config.nMakeWineTime1;// 酿药酒等待时间
            SpinEditMakeWineRate.Value = M2Share.g_Config.nMakeWineRate;// 酿酒获得酒曲机率
            SpinEditIncAlcoholTick.Value = M2Share.g_Config.nIncAlcoholTick;// 增加酒量进度的间隔时间
            SpinEditDesDrinkTick.Value = M2Share.g_Config.nDesDrinkTick;// 减少醉酒度的间隔时间
            SpinEditMaxAlcoholValue.Value = M2Share.g_Config.nMaxAlcoholValue;// 酒量上限初始值
            SpinEditIncAlcoholValue.Value = M2Share.g_Config.nIncAlcoholValue;// 升级后增加酒量上限值
            SpinEditDesMedicineValue.Value = M2Share.g_Config.nDesMedicineValue;// 长时间不使用酒,减药力值
            SpinEditDesMedicineTick.Value = M2Share.g_Config.nDesMedicineTick;// 减药力值时间间隔
            SpinEditInFountainTime.Value = M2Share.g_Config.nInFountainTime;// 站在泉眼上的累积时间(秒)
            SpinEditMinGuildFountain.Value = M2Share.g_Config.nMinGuildFountain;// 行会酒泉蓄量少于时,不能领取
            SpinEditDecGuildFountain.Value = M2Share.g_Config.nDecGuildFountain;// 行会成员领取酒泉,蓄量减少
            // 药力值 20080623
            //            //for (I = 1; I < GridMedicineExp.RowCount; I ++ )
            //            //{
            //            //    GridMedicineExp.Cells[1, I] = (M2Share.g_Config.dwMedicineNeedExps[I]).ToString();
            //            //}
            //             // 天地结晶 20090131
            //            //for (I = 1; I < GridExpCrystalLevelExp.RowCount; I ++ )
            //            //{
            //            //   
            //            //    GridExpCrystalLevelExp.Cells[1, I] = (M2Share.g_Config.dwExpCrystalNeedExps[I]).ToString();
            //            //    GridExpCrystalLevelExp.Cells[2, I] = (M2Share.g_Config.dwNGExpCrystalNeedExps[I]).ToString();
            //            //}
            //            EditHeroCrystalExpRate.Value = M2Share.g_Config.nHeroCrystalExpRate;
            //            // 天地结晶英雄分配比例 20090202
            //            // SpinEditSellOffCount.Value := g_Config.nUserSellOffCount; //20080504 去掉拍卖功能
            //            // SpinEditSellOffTax.Value := g_Config.nUserSellOffTax;  //20080504 去掉拍卖功能
            //            SpinEditFireDelayTime.Value = M2Share.g_Config.nFireDelayTimeRate;
            //            SpinEditFirePower.Value = M2Share.g_Config.nFirePowerRate;
            //            CheckBoxFireChgMapExtinguish.Checked = M2Share.g_Config.boChangeMapFireExtinguish;
            //            SpinEditDidingPowerRate.Value = M2Share.g_Config.nDidingPowerRate;
            //            for (I = M2Share.g_Config.BoneFammArray.GetLowerBound(0); I <= M2Share.g_Config.BoneFammArray.GetUpperBound(0); I ++ )
            //            {
            //                if (M2Share.g_Config.BoneFammArray[I].nHumLevel <= 0)
            //                {
            //                    break;
            //                }
            //                //GridBoneFamm.Cells[0, I + 1] = (M2Share.g_Config.BoneFammArray[I].nHumLevel).ToString();
            //                //GridBoneFamm.Cells[1, I + 1] = M2Share.g_Config.BoneFammArray[I].sMonName;
            //                //GridBoneFamm.Cells[2, I + 1] = (M2Share.g_Config.BoneFammArray[I].nCount).ToString();
            //                //GridBoneFamm.Cells[3, I + 1] = (M2Share.g_Config.BoneFammArray[I].nLevel).ToString();
            //            }
            //            EditDogzName.Text = M2Share.g_Config.sDogz;
            //            EditDogzCount.Value = M2Share.g_Config.nDogzCount;
            //            for (I = M2Share.g_Config.DogzArray.GetLowerBound(0); I <= M2Share.g_Config.DogzArray.GetUpperBound(0); I ++ )
            //            {
            //                if (M2Share.g_Config.DogzArray[I].nHumLevel <= 0)
            //                {
            //                    break;
            //                }
            //                GridDogz.Cells[0, I + 1] = (M2Share.g_Config.DogzArray[I].nHumLevel).ToString();
            //                GridDogz.Cells[1, I + 1] = M2Share.g_Config.DogzArray[I].sMonName;
            //                GridDogz.Cells[2, I + 1] = (M2Share.g_Config.DogzArray[I].nCount).ToString();
            //                GridDogz.Cells[3, I + 1] = (M2Share.g_Config.DogzArray[I].nLevel).ToString();
            //            }
            // 月灵
            FairyNameEdt.Text = M2Share.g_Config.sFairy;
            SpinFairyEdt.Value = M2Share.g_Config.nFairyCount;
            SpinFairyDuntRateEdt.Value = M2Share.g_Config.nFairyDuntRate;
            SpinEditFairyDuntRateBelow.Value = M2Share.g_Config.nFairyDuntRateBelow;// 月灵重击次数,达到次数时按等级出重击 20090105
            SpinFairyAttackRateEdt.Value = M2Share.g_Config.nFairyAttackRate;
            Spin43KillHitRateEdt.Value = M2Share.g_Config.n43KillHitRate;// 开天斩重击几率
            Spin43KillAttackRateEdt.Value = M2Share.g_Config.n43KillAttackRate;// 开天斩重击倍数 
            SpinEditAttackRate_43.Value = M2Share.g_Config.nAttackRate_43;// 开天斩威力 
            SpinEditAttackRate_26.Value = M2Share.g_Config.nAttackRate_26;// 烈火剑法威力倍数
            SpinEditAttackRate_74.Value = M2Share.g_Config.nAttackRate_74;
            //            // 逐日剑法威力倍数 20080511
            //            for (I = M2Share.g_Config.FairyArray.GetLowerBound(0); I <= M2Share.g_Config.FairyArray.GetUpperBound(0); I ++ )
            //            {
            //                if (M2Share.g_Config.FairyArray[I].nHumLevel <= 0)
            //                {
            //                    break;
            //                }
            //                //GridFairy.Cells[0, I + 1] = (M2Share.g_Config.FairyArray[I].nHumLevel).ToString();
            //                //GridFairy.Cells[1, I + 1] = M2Share.g_Config.FairyArray[I].sMonName;
            //                //GridFairy.Cells[2, I + 1] = (M2Share.g_Config.FairyArray[I].nCount).ToString();
            //                //GridFairy.Cells[3, I + 1] = (M2Share.g_Config.FairyArray[I].nLevel).ToString();
            //            }
            RefMagicSkill();
            RefUpgradeWeapon();
            RefMakeMine();
            RefWinLottery();
            EditMasterCount.Value = M2Share.g_Config.nMasterCount;// 可收徒弟数
            EditMasterOKLevel.Value = M2Share.g_Config.nMasterOKLevel;
            EditMasterOKCreditPoint.Value = M2Share.g_Config.nMasterOKCreditPoint;
            EditMasterOKBonusPoint.Value = M2Share.g_Config.nMasterOKBonusPoint;
            CheckBoxPullPlayObject.Checked = M2Share.g_Config.boPullPlayObject;
            CheckBoxPullCrossInSafeZone.Checked = M2Share.g_Config.boPullCrossInSafeZone;
            CheckBoxPullCrossInSafeZone.Enabled = M2Share.g_Config.boPullPlayObject;
            CheckBoxPlayObjectReduceMP.Checked = M2Share.g_Config.boPlayObjectReduceMP;
            CheckBoxGroupMbAttackSlave.Checked = M2Share.g_Config.boGroupMbAttackSlave;
            CheckBoxItemName.Checked = M2Share.g_Config.boChangeUseItemNameByPlayName;
            EditItemName.Text = M2Share.g_Config.sChangeUseItemName;
            CheckBoxDedingAllowPK.Checked = M2Share.g_Config.boDedingAllowPK;
            SpinEditMakeSelfTick.Value = M2Share.g_Config.nMakeSelfTick;// 分身使用时长
            SpinEditnCopyHumanTick.Value = M2Share.g_Config.nCopyHumanTick;// 召唤分身间隔
            SpinEditKill43Sec.Value = M2Share.g_Config.nKill43UseTime;// 开天斩使用间隔
            SpinEditSkill39Sec.Value = M2Share.g_Config.nDedingUseTime;
            CheckBoxStartMapEvent.Checked = M2Share.g_Config.boStartMapEvent;// 开启地图事件触发
            EditAbilityUpTick.Value = M2Share.g_Config.nAbilityUpTick;// 无极真气使用间隔
            CheckBoxAbilityUpFixMode.Checked = M2Share.g_Config.boAbilityUpFixMode;// 无极真气使用时长模式
            if (M2Share.g_Config.boAbilityUpFixMode)
            {
                SpinEditAbilityUpFixUseTime.Enabled = true;
                SpinEditAbilityUpUseTime.Enabled = false;
            }
            else
            {
                SpinEditAbilityUpFixUseTime.Enabled = false;
                SpinEditAbilityUpUseTime.Enabled = true;
            }
            SpinEditAbilityUpFixUseTime.Value = M2Share.g_Config.nAbilityUpFixUseTime;// 无极真气使用固定时长
            SpinEditAbilityUpUseTime.Value = M2Share.g_Config.nAbilityUpUseTime;// 无极真气使用时长
            SpinEditMinDrinkValue67.Value = M2Share.g_Config.nMinDrinkValue67;// 先天元力失效酒量下限比例
            SpinEditMinDrinkValue68.Value = M2Share.g_Config.nMinDrinkValue68;// 酒气护体失效酒量下限比例
            SpinEditHPUpTick.Value = M2Share.g_Config.nHPUpTick;// 酒气护体使用间隔
            SpinEditHPUpUseTime.Value = M2Share.g_Config.nHPUpUseTime;// 酒气护体增加使用时长

            // 酒气护体升级经验 20080625
            //for (I = 1; I < GridSkill68.RowCount; I ++ )
            //{
            //    GridSkill68.Cells[1, I] = (M2Share.g_Config.dwSkill68NeedExps[I]).ToString();
            //}
            SpinEditChallengeTime.Value = M2Share.g_Config.nChallengeTime;// 挑战时间
            CheckBoxShowGuildName.Checked = M2Share.g_Config.boShowGuildName;// 人物名是否显示行会信息
            if (M2Share.g_Config.boSkill31Effect)// 魔法盾效果 T-特色效果 F-盛大效果
            {
                RadioboSkill31EffectTrue.Checked = true;
                RadioboSkill31EffectFalse.Checked = false;
            }
            else
            {
                RadioboSkill31EffectTrue.Checked = false;
                RadioboSkill31EffectFalse.Checked = true;
            }
            SpinEditSkill66Rate.Value = M2Share.g_Config.nSkill66Rate;// 四级魔法盾抵御伤害百分率
            SpinEditOrdinarySkill66Rate.Value = M2Share.g_Config.nOrdinarySkill66Rate;// 普通魔法盾抵御伤害百分率 
            SpinEditNGSkillRate.Value = M2Share.g_Config.nNGSkillRate;// 内功技能增强的攻防比率 
            SpinEditNGLevelDamage.Value = M2Share.g_Config.nNGLevelDamage;// 内功等级增加攻防的级数比率 
            SpinEditSkill69NG.Value = M2Share.g_Config.nSkill69NG;// 内力值参数 
            SpinEditSkill69NGExp.Value = M2Share.g_Config.nSkill69NGExp;// 主体内功经验参数 
            SpinEditHeroSkill69NGExp.Value = M2Share.g_Config.nHeroSkill69NGExp;// 英雄内功经验参数 
            SpinEditdwIncNHTime.Value = M2Share.g_Config.dwIncNHTime / 1000;// 增加内力值间隔 
            SpinEditDrinkIncNHExp.Value = M2Share.g_Config.nDrinkIncNHExp;// 饮酒增加内功经验 
            SpinEditHitStruckDecNH.Value = M2Share.g_Config.nHitStruckDecNH;// 内功抵御普通攻击消耗内力值 
            EditKillMonNGExpMultiple.Value = M2Share.g_Config.dwKillMonNGExpMultiple;// 杀怪内功经验倍数 
            YTPDTimeEdit.Value = M2Share.g_Config.Magic69UseTime;// 倚天劈地使用间隔  
            xuepotimeedit.Value = M2Share.g_Config.magic96usetime;// 血魄一击使用间隔
            //RefReNewLevelConf();
            //RefMonUpgrade();
            //RefSpiritMutiny();
            //RefMonSayMsg();
            //RefWeaponMakeLuck();
            //RefCopyHumConf();
            //RefBatterConf();
            // 连击配置相关
            boOpened = true;
            FunctionConfigControl.SelectedIndex = 0;
            this.ShowDialog();
        }

        public void FormCreate(object sender, EventArgs e)
        {
            //            int I;

            //            //GridExpCrystalLevelExp.Cells[0, 0] = "等级";

            //            //GridExpCrystalLevelExp.Cells[1, 0] = "经验值";

            //            //GridExpCrystalLevelExp.Cells[2, 0] = "内功经验值";

            //            //for (I = 1; I < GridExpCrystalLevelExp.RowCount; I ++ )
            //            //{

            //            //    GridExpCrystalLevelExp.Cells[0, I] = (I).ToString();
            //            //}

            //            //GridMedicineExp.Cells[0, 0] = "等级";

            //            //GridMedicineExp.Cells[1, 0] = "药力值";

            //            //for (I = 1; I < GridMedicineExp.RowCount; I ++ )
            //            //{

            //            //    GridMedicineExp.Cells[0, I] = (I).ToString();
            //            //}

            //            //GridSkill68.Cells[0, 0] = "等级";

            //            //GridSkill68.Cells[1, 0] = "经验值";

            //            //for (I = 1; I < GridSkill68.RowCount; I ++ )
            //            //{

            //            //    GridSkill68.Cells[0, I] = (I).ToString();
            //            //}

            //            //GridBoneFamm.Cells[0, 0] = "人物等级";

            //            //GridBoneFamm.Cells[1, 0] = "怪物名称";

            //            //GridBoneFamm.Cells[2, 0] = "数量";

            //            //GridBoneFamm.Cells[3, 0] = "等级";

            //            //GridDogz.Cells[0, 0] = "人物等级";

            //            //GridDogz.Cells[1, 0] = "怪物名称";

            //            //GridDogz.Cells[2, 0] = "数量";

            //            //GridDogz.Cells[3, 0] = "等级";
            //            //// 月灵

            //            //GridFairy.Cells[0, 0] = "人物等级";

            //            //GridFairy.Cells[1, 0] = "怪物名称";

            //            //GridFairy.Cells[2, 0] = "数量";

            //            //GridFairy.Cells[3, 0] = "等级";
            FunctionConfigControl.SelectedIndex = 0;
            MagicPageControl.SelectedIndex = 0;
            CheckBoxHungerDecPower.Visible = true;
        }

//        public void CheckBoxEnablePasswordLockClick(object sender, EventArgs e)
//        {
//            switch(CheckBoxEnablePasswordLock.Checked)
//            {
//                case true:
//                    CheckBoxLockGetBackItem.Enabled = true;
//                    CheckBoxLockLogin.Enabled = true;
//                    break;
//                case false:
//                    CheckBoxLockGetBackItem.Checked = false;
//                    CheckBoxLockLogin.Checked = false;
//                    CheckBoxLockGetBackItem.Enabled = false;
//                    CheckBoxLockLogin.Enabled = false;
//                    break;
//            }
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boPasswordLockSystem = CheckBoxEnablePasswordLock.Checked;
//            ModValue();
//        }

        public void CheckBoxLockGetBackItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockGetBackItemAction = CheckBoxLockGetBackItem.Checked;
            ModValue();
        }

        public void CheckBoxLockDealItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockDealAction = CheckBoxLockDealItem.Checked;
            ModValue();
        }

        public void CheckBoxLockDropItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockDropAction = CheckBoxLockDropItem.Checked;
            ModValue();
        }

        public void CheckBoxLockUseItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockUserItemAction = CheckBoxLockUseItem.Checked;
            ModValue();
        }

        public void CheckBoxLockLoginClick(object sender, EventArgs e)
        {
            switch (CheckBoxLockLogin.Checked)
            {
                case true:
                    CheckBoxLockWalk.Enabled = true;
                    CheckBoxLockRun.Enabled = true;
                    CheckBoxLockHit.Enabled = true;
                    CheckBoxLockSpell.Enabled = true;
                    CheckBoxLockInObMode.Enabled = true;
                    CheckBoxLockSendMsg.Enabled = true;
                    CheckBoxLockDealItem.Enabled = true;
                    CheckBoxLockDropItem.Enabled = true;
                    CheckBoxLockUseItem.Enabled = true;
                    CheckBoxLockCallHero.Enabled = true;
                    break;
                case false:
                    CheckBoxLockWalk.Checked = false;
                    CheckBoxLockRun.Checked = false;
                    CheckBoxLockHit.Checked = false;
                    CheckBoxLockSpell.Checked = false;
                    CheckBoxLockInObMode.Checked = false;
                    CheckBoxLockSendMsg.Checked = false;
                    CheckBoxLockDealItem.Checked = false;
                    CheckBoxLockDropItem.Checked = false;
                    CheckBoxLockUseItem.Checked = false;
                    CheckBoxLockCallHero.Checked = false;
                    CheckBoxLockWalk.Enabled = false;
                    CheckBoxLockRun.Enabled = false;
                    CheckBoxLockHit.Enabled = false;
                    CheckBoxLockSpell.Enabled = false;
                    CheckBoxLockInObMode.Enabled = false;
                    CheckBoxLockSendMsg.Enabled = false;
                    CheckBoxLockDealItem.Enabled = false;
                    CheckBoxLockDropItem.Enabled = false;
                    CheckBoxLockUseItem.Enabled = false;
                    CheckBoxLockCallHero.Enabled = false;
                    break;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockHumanLogin = CheckBoxLockLogin.Checked;
            ModValue();
        }

        public void CheckBoxLockWalkClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockWalkAction = CheckBoxLockWalk.Checked;
            ModValue();
        }

        public void CheckBoxLockRunClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockRunAction = CheckBoxLockRun.Checked;
            ModValue();
        }

        public void CheckBoxLockHitClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockHitAction = CheckBoxLockHit.Checked;
            ModValue();
        }

        public void CheckBoxLockSpellClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockSpellAction = CheckBoxLockSpell.Checked;
            ModValue();
        }

        public void CheckBoxLockSendMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockSendMsgAction = CheckBoxLockSendMsg.Checked;
            ModValue();
        }

        public void CheckBoxLockInObModeClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLockInObModeAction = CheckBoxLockInObMode.Checked;
            ModValue();
        }

        public void EditErrorPasswordCountChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nPasswordErrorCountLock = (byte)EditErrorPasswordCount.Value;
            ModValue();
        }

        public void CheckBoxErrorCountKickClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nPasswordErrorCountLock = (byte)EditErrorPasswordCount.Value;
            ModValue();
        }

        public void ButtonPasswordLockSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "PasswordLockSystem", M2Share.g_Config.boPasswordLockSystem);
            M2Share.Config.WriteBool("Setup", "PasswordLockDealAction", M2Share.g_Config.boLockDealAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockDropAction", M2Share.g_Config.boLockDropAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockGetBackItemAction", M2Share.g_Config.boLockGetBackItemAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockWalkAction", M2Share.g_Config.boLockWalkAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockRunAction", M2Share.g_Config.boLockRunAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockHitAction", M2Share.g_Config.boLockHitAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockSpellAction", M2Share.g_Config.boLockSpellAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockCallHeroAction", M2Share.g_Config.boLockCallHeroAction);// 是否锁定召唤英雄操作  20080529
            M2Share.Config.WriteBool("Setup", "PasswordLockSendMsgAction", M2Share.g_Config.boLockSendMsgAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockInObModeAction", M2Share.g_Config.boLockInObModeAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockUserItemAction", M2Share.g_Config.boLockUserItemAction);
            M2Share.Config.WriteBool("Setup", "PasswordLockHumanLogin", M2Share.g_Config.boLockHumanLogin);
            M2Share.Config.WriteInteger("Setup", "PasswordErrorCountLock", M2Share.g_Config.nPasswordErrorCountLock);
            uModValue();
        }

        private void RefGeneral()
        {
            SpinEditNPCNameColor.Value = M2Share.g_Config.btNPCNameColor;// NPC名字颜色
            EditPKFlagNameColor.Value = M2Share.g_Config.btPKFlagNameColor;
            EditPKLevel1NameColor.Value = M2Share.g_Config.btPKLevel1NameColor;
            EditPKLevel2NameColor.Value = M2Share.g_Config.btPKLevel2NameColor;
            EditAllyAndGuildNameColor.Value = M2Share.g_Config.btAllyAndGuildNameColor;
            EditWarGuildNameColor.Value = M2Share.g_Config.btWarGuildNameColor;
            EditInFreePKAreaNameColor.Value = M2Share.g_Config.btInFreePKAreaNameColor;
            SpinEditStartHPRock.Value = M2Share.g_Config.nStartHPRock;
            SpinEditStartMPRock.Value = M2Share.g_Config.nStartMPRock;
            SpinEditStartHPMPRock.Value = M2Share.g_Config.nStartHPMPRock;
            SpinEditHPRockSpell.Value = M2Share.g_Config.nHPRockSpell;
            SpinEditMPRockSpell.Value = M2Share.g_Config.nMPRockSpell;
            SpinEditHPMPRockSpell.Value = M2Share.g_Config.nHPMPRockSpell;
            SpinEditRockAddHP.Value = M2Share.g_Config.nRockAddHP;
            SpinEditRockAddMP.Value = M2Share.g_Config.nRockAddMP;
            SpinEditRockAddHPMP.Value = M2Share.g_Config.nRockAddHPMP;
            SpinEditHPRockDecDura.Value = M2Share.g_Config.nHPRockDecDura;
            SpinEditMPRockDecDura.Value = M2Share.g_Config.nMPRockDecDura;
            SpinEditHPMPRockDecDura.Value = M2Share.g_Config.nHPMPRockDecDura;
        }

        public void CheckBoxHungerSystemClick(object sender, EventArgs e)
        {
            if (CheckBoxHungerSystem.Checked)
            {
                CheckBoxHungerDecHP.Enabled = true;
                CheckBoxHungerDecPower.Enabled = true;
            }
            else
            {
                CheckBoxHungerDecHP.Checked = false;
                CheckBoxHungerDecPower.Checked = false;
                CheckBoxHungerDecHP.Enabled = false;
                CheckBoxHungerDecPower.Enabled = false;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHungerSystem = CheckBoxHungerSystem.Checked;
            ModValue();
        }

        public void CheckBoxHungerDecHPClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHungerDecHP = CheckBoxHungerDecHP.Checked;
            ModValue();
        }

        public void CheckBoxHungerDecPowerClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boHungerDecPower = CheckBoxHungerDecPower.Checked;
            ModValue();
        }

        public void ButtonGeneralSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "HungerSystem", M2Share.g_Config.boHungerSystem);
            M2Share.Config.WriteBool("Setup", "HungerDecHP", M2Share.g_Config.boHungerDecHP);
            M2Share.Config.WriteBool("Setup", "HungerDecPower", M2Share.g_Config.boHungerDecPower);
            M2Share.Config.WriteInteger("Setup", "ChallengeTime", M2Share.g_Config.nChallengeTime);// 挑战时间
            M2Share.Config.WriteInteger("Setup", "NPCNameColor", M2Share.g_Config.btNPCNameColor);// NPC名字颜色 
            M2Share.Config.WriteInteger("Setup", "PKFlagNameColor", M2Share.g_Config.btPKFlagNameColor);
            M2Share.Config.WriteInteger("Setup", "AllyAndGuildNameColor", M2Share.g_Config.btAllyAndGuildNameColor);
            M2Share.Config.WriteInteger("Setup", "WarGuildNameColor", M2Share.g_Config.btWarGuildNameColor);
            M2Share.Config.WriteInteger("Setup", "InFreePKAreaNameColor", M2Share.g_Config.btInFreePKAreaNameColor);
            M2Share.Config.WriteInteger("Setup", "PKLevel1NameColor", M2Share.g_Config.btPKLevel1NameColor);
            M2Share.Config.WriteInteger("Setup", "PKLevel2NameColor", M2Share.g_Config.btPKLevel2NameColor);
            M2Share.Config.WriteBool("Setup", "StartMapEvent", M2Share.g_Config.boStartMapEvent);
            M2Share.Config.WriteBool("Setup", "ShowGuildName", M2Share.g_Config.boShowGuildName);// 人物名是否显示行会信息
            M2Share.Config.WriteInteger("Setup", "StartHPRock", M2Share.g_Config.nStartHPRock);
            M2Share.Config.WriteInteger("Setup", "StartMPRock", M2Share.g_Config.nStartMPRock);
            M2Share.Config.WriteInteger("Setup", "StartHPMPRock", M2Share.g_Config.nStartHPMPRock);
            M2Share.Config.WriteInteger("Setup", "HPRockSpell", M2Share.g_Config.nHPRockSpell);
            M2Share.Config.WriteInteger("Setup", "MPRockSpell", M2Share.g_Config.nMPRockSpell);
            M2Share.Config.WriteInteger("Setup", "HPMPRockSpell", M2Share.g_Config.nHPMPRockSpell);
            M2Share.Config.WriteInteger("Setup", "RockAddHP", M2Share.g_Config.nRockAddHP);
            M2Share.Config.WriteInteger("Setup", "RockAddMP", M2Share.g_Config.nRockAddMP);
            M2Share.Config.WriteInteger("Setup", "RockAddHPMP", M2Share.g_Config.nRockAddHPMP);
            M2Share.Config.WriteInteger("Setup", "HPRockDecDura", M2Share.g_Config.nHPRockDecDura);
            M2Share.Config.WriteInteger("Setup", "MPRockDecDura", M2Share.g_Config.nMPRockDecDura);
            M2Share.Config.WriteInteger("Setup", "HPMPRockDecDura", M2Share.g_Config.nHPMPRockDecDura);
            uModValue();
        }

        public void EditMagicAttackRageChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMagicAttackRage = (byte)EditMagicAttackRage.Value;
            ModValue();
        }

        private void RefMagicSkill()
        {
            EditSwordLongPowerRate.Value = M2Share.g_Config.nSwordLongPowerRate;//刺杀剑法攻击力倍数
            CheckBoxLimitSwordLong.Checked = M2Share.g_Config.boLimitSwordLong;//是否禁止无限刺杀
            EditFireBoomRage.Value = M2Share.g_Config.nFireBoomRage;
            EditSnowWindRange.Value = M2Share.g_Config.nSnowWindRange;
            EditMeteorFireRainRage.Value = M2Share.g_Config.nMeteorFireRainRage;// 流星火雨攻击范围
            EditMagFireCharmTreatment.Value = M2Share.g_Config.nMagFireCharmTreatment;// 噬血术加血百分率 
            EditElecBlizzardRange.Value = M2Share.g_Config.nElecBlizzardRange;
            EditMagicAttackRage.Value = M2Share.g_Config.nMagicAttackRage;
            EditAmyOunsulPoint.Value = M2Share.g_Config.nAmyOunsulPoint;
            EditMagTurnUndeadLevel.Value = M2Share.g_Config.nMagTurnUndeadLevel;
            EditMagTammingLevel.Value = M2Share.g_Config.nMagTammingLevel;
            EditMagTammingTargetLevel.Value = M2Share.g_Config.nMagTammingTargetLevel;
            EditMagTammingHPRate.Minimum = 1;
            EditMagTammingHPRate.Maximum = 400;
            EditMagTammingHPRate.Value = M2Share.g_Config.nMagTammingHPRate;
            EditTammingCount.Value = M2Share.g_Config.nMagTammingCount;
            EditMabMabeHitRandRate.Value = M2Share.g_Config.nMabMabeHitRandRate;
            EditMabMabeHitMinLvLimit.Value = M2Share.g_Config.nMabMabeHitMinLvLimit;
            EditMabMabeHitSucessRate.Value = M2Share.g_Config.nMabMabeHitSucessRate;
            EditMabMabeHitMabeTimeRate.Value = M2Share.g_Config.nMabMabeHitMabeTimeRate;
            CheckBoxFireCrossInSafeZone.Checked = M2Share.g_Config.boDisableInSafeZoneFireCross;
            CheckBoxGroupMbAttackPlayObject.Checked = M2Share.g_Config.boGroupMbAttackPlayObject;
            SpinEditMagChangXY.Value = M2Share.g_Config.dwMagChangXYTick / 1000;// 移行换位使用间隔 
            EditProtectionDefenceTime.Value = M2Share.g_Config.nProtectionDefenceTime / 1000;// 护体神盾
            EditProtectionTick.Value = M2Share.g_Config.dwProtectionTick / 1000;
            EditProtectionRate.Value = M2Share.g_Config.nProtectionRate;
            EditProtectionOKRate.Value = M2Share.g_Config.nProtectionOKRate;// 护体神盾生效机率
            EditProtectionBadRate.Value = M2Share.g_Config.nProtectionBadRate;
            CheckRushkungBad.Checked = M2Share.g_Config.RushkungBadProtection;
            CheckErgumBad.Checked = M2Share.g_Config.ErgumBadProtection;
            CheckFirehitBad.Checked = M2Share.g_Config.FirehitBadProtection;
            CheckTwnhitBad.Checked = M2Share.g_Config.TwnhitBadProtection;
            ShowProtectionEnv.Checked = M2Share.g_Config.boShowProtectionEnv;// 显示护体神盾效果 
            AutoProtection.Checked = M2Share.g_Config.boAutoProtection;// 自动使用神盾 
            AutoCanHit.Checked = M2Share.g_Config.boAutoCanHit;// 智能锁定 
            CheckSlaveMoveMaster.Checked = M2Share.g_Config.boSlaveMoveMaster;// 宝宝是否飞到主人身边 
            SpinEditKill42Sec.Value = M2Share.g_Config.nKill42UseTime;// 龙影剑法使用间隔 
            SpinEditAttackRate_42.Value = M2Share.g_Config.nAttackRate_42;// 龙影剑法威力 
            EditMagicAttackRage_42.Value = M2Share.g_Config.nMagicAttackRage_42;// 龙影剑法范围 
        }

        public void EditBoneFammCountChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBoneFammCount = (byte)EditBoneFammCount.Value;
            ModValue();
        }

        public void EditDogzCountChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDogzCount = (byte)EditDogzCount.Value;
            ModValue();
        }

        public void CheckBoxLimitSwordLongClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boLimitSwordLong = CheckBoxLimitSwordLong.Checked;
            ModValue();
        }

        public void EditSwordLongPowerRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSwordLongPowerRate = (byte)EditSwordLongPowerRate.Value;
            ModValue();
        }

        public void EditBoneFammNameChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void EditDogzNameChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void EditFireBoomRageChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nFireBoomRage = (byte)EditFireBoomRage.Value;
            ModValue();
        }

        public void EditSnowWindRangeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSnowWindRange = (byte)EditSnowWindRange.Value;
            ModValue();
        }

        public void EditElecBlizzardRangeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nElecBlizzardRange = (byte)EditElecBlizzardRange.Value;
            // 地狱雷光攻击范围
            ModValue();
        }

        public void EditMagTurnUndeadLevelChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMagTurnUndeadLevel = (ushort)EditMagTurnUndeadLevel.Value;
            ModValue();
        }

        public void GridBoneFammSetEditText(Object Sender, int ACol, int ARow, string Value)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void EditAmyOunsulPointChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nAmyOunsulPoint = (byte)EditAmyOunsulPoint.Value;
            ModValue();
        }

        public void CheckBoxFireChgMapExtinguishClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boChangeMapFireExtinguish = CheckBoxFireChgMapExtinguish.Checked;
            ModValue();
        }

        public void CheckBoxFireCrossInSafeZoneClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDisableInSafeZoneFireCross = CheckBoxFireCrossInSafeZone.Checked;
            ModValue();
        }

        public void CheckBoxGroupMbAttackPlayObjectClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boGroupMbAttackPlayObject = CheckBoxGroupMbAttackPlayObject.Checked;
            ModValue();
        }

        public void ButtonSkillSaveClick(object sender, EventArgs e)
        {
            int I;
//            TRecallMigic[] RecallArray = new TRecallMigic[9 + 1];
//            TGridRect Rect;
//            uint dwExp;
//            int[] NeedExps;
//            //FillChar(RecallArray, sizeof(RecallArray), '\0');
//            //M2Share.g_Config.sBoneFamm = EditBoneFammName.Text.Trim();
//            //for (I = RecallArray.GetLowerBound(0); I <= RecallArray.GetUpperBound(0); I ++ )
//            //{
//            //    RecallArray[I].nHumLevel = HUtil32.Str_ToInt(GridBoneFamm.Cells[0, I + 1],  -1);
//            //    RecallArray[I].sMonName = GridBoneFamm.Cells[1, I + 1].Trim();
//            //    RecallArray[I].nCount = HUtil32.Str_ToInt(GridBoneFamm.Cells[2, I + 1],  -1);
//            //    RecallArray[I].nLevel = HUtil32.Str_ToInt(GridBoneFamm.Cells[3, I + 1],  -1);
//            //    if (GridBoneFamm.Cells[0, I + 1] == "")
//            //    {
//            //        break;
//            //    }
//            //    if ((RecallArray[I].nHumLevel <= 0))
//            //    {
//            //        MessageBox.Show("人物等级设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 0;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 0;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridBoneFamm.Selection = Rect;
//            //        return;
//            //    }
//            //    if (UserEngine.GetMonRace(RecallArray[I].sMonName) <= 0)
//            //    {
//            //        MessageBox.Show("骷髅怪物名称设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 1;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 1;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridBoneFamm.Selection = Rect;
//            //        return;
//            //    }
//            //    if (RecallArray[I].nCount <= 0)
//            //    {
//            //        MessageBox.Show("召唤数量设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 2;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 2;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridBoneFamm.Selection = Rect;
//            //        return;
//            //    }
//            //    if (RecallArray[I].nLevel < 0)
//            //    {
//            //        MessageBox.Show("召唤等级设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 3;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 3;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridBoneFamm.Selection = Rect;
//            //        return;
//            //    }
//            //}
//            //for (I = RecallArray.GetLowerBound(0); I <= RecallArray.GetUpperBound(0); I ++ )
//            //{
                
//            //    RecallArray[I].nHumLevel = HUtil32.Str_ToInt(GridDogz.Cells[0, I + 1],  -1);
                
//            //    RecallArray[I].sMonName = GridDogz.Cells[1, I + 1].Trim();
                
//            //    RecallArray[I].nCount = HUtil32.Str_ToInt(GridDogz.Cells[2, I + 1],  -1);
                
//            //    RecallArray[I].nLevel = HUtil32.Str_ToInt(GridDogz.Cells[3, I + 1],  -1);
                
//            //    if (GridDogz.Cells[0, I + 1] == "")
//            //    {
//            //        break;
//            //    }
//            //    if ((RecallArray[I].nHumLevel <= 0))
//            //    {
//            //        MessageBox.Show("人物等级设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 0;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 0;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridDogz.Selection = Rect;
//            //        return;
//            //    }
//            //    if (UserEngine.GetMonRace(RecallArray[I].sMonName) <= 0)
//            //    {
//            //        MessageBox.Show("神兽怪物名称设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 1;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 1;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridDogz.Selection = Rect;
//            //        return;
//            //    }
//            //    if (RecallArray[I].nCount <= 0)
//            //    {
//            //        MessageBox.Show("召唤数量设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 2;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 2;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridDogz.Selection = Rect;
//            //        return;
//            //    }
//            //    if (RecallArray[I].nLevel < 0)
//            //    {
//            //        MessageBox.Show("召唤等级设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//            //        Rect.Left = 3;
                    
//            //        Rect.Top = I + 1;
                    
//            //        Rect.Right = 3;
                    
//            //        Rect.Bottom = I + 1;
                    
//            //        GridDogz.Selection = Rect;
//            //        return;
//            //    }
//            //}
//            // 月灵
//            for (I = RecallArray.GetLowerBound(0); I <= RecallArray.GetUpperBound(0); I ++ )
//            {
//                //RecallArray[I].nHumLevel = HUtil32.Str_ToInt(GridFairy.Cells[0, I + 1],  -1);
//                //RecallArray[I].sMonName = GridFairy.Cells[1, I + 1].Trim();
//                //RecallArray[I].nCount = HUtil32.Str_ToInt(GridFairy.Cells[2, I + 1],  -1);
//                //RecallArray[I].nLevel = HUtil32.Str_ToInt(GridFairy.Cells[3, I + 1],  -1);
//                //if (GridFairy.Cells[0, I + 1] == "")
//                //{
//                //    break;
//                //}
//                if ((RecallArray[I].nHumLevel <= 0))
//                {
//                    MessageBox.Show("人物等级设置错误！！！", "错误信息", MessageBoxButtons.OK);
//                    Rect.Left = 0;
//                    Rect.Top = I + 1;
//                    Rect.Right = 0;
//                    Rect.Bottom = I + 1;
//                    //GridFairy.Selection = Rect;
//                    return;
//                }
//                if (UserEngine.GetMonRace(RecallArray[I].sMonName) <= 0)
//                {
//                    MessageBox.Show("月灵怪物名称设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//                    Rect.Left = 1;
                    
//                    Rect.Top = I + 1;
                    
//                    Rect.Right = 1;
                    
//                    Rect.Bottom = I + 1;
                    
//                    //GridFairy.Selection = Rect;
//                    return;
//                }
//                if (RecallArray[I].nCount <= 0)
//                {
//                    MessageBox.Show("召唤数量设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//                    Rect.Left = 2;
                    
//                    Rect.Top = I + 1;
                    
//                    Rect.Right = 2;
                    
//                    Rect.Bottom = I + 1;
                    
//                    //GridFairy.Selection = Rect;
//                    return;
//                }
//                if (RecallArray[I].nLevel < 0)
//                {
//                    MessageBox.Show("召唤等级设置错误！！！", "错误信息", MessageBoxButtons.OK);
                    
//                    Rect.Left = 3;
                    
//                    Rect.Top = I + 1;
                    
//                    Rect.Right = 3;
                    
//                    Rect.Bottom = I + 1;
                    
//                    GridFairy.Selection = Rect;
//                    return;
//                }
//            }
            
//            FillChar(M2Share.g_Config.BoneFammArray, sizeof(M2Share.g_Config.BoneFammArray), '\0');
//            for (I = M2Share.g_Config.BoneFammArray.GetLowerBound(0); I <= M2Share.g_Config.BoneFammArray.GetUpperBound(0); I ++ )
//            {
//                M2Share.Config.WriteInteger("Setup", "BoneFammHumLevel" + (I).ToString(), 0);
//                M2Share.Config.WriteString("Names", "BoneFamm" + (I).ToString(), "");
//                M2Share.Config.WriteInteger("Setup", "BoneFammCount" + (I).ToString(), 0);
//                M2Share.Config.WriteInteger("Setup", "BoneFammLevel" + (I).ToString(), 0);
//            }
//            for (I = M2Share.g_Config.BoneFammArray.GetLowerBound(0); I <= M2Share.g_Config.BoneFammArray.GetUpperBound(0); I ++ )
//            {
//                if (GridBoneFamm.Cells[0, I + 1] == "")
//                {
//                    break;
//                }
//                M2Share.g_Config.BoneFammArray[I].nHumLevel = HUtil32.Str_ToInt(GridBoneFamm.Cells[0, I + 1],  -1);
//                M2Share.g_Config.BoneFammArray[I].sMonName = GridBoneFamm.Cells[1, I + 1].Trim();
//                M2Share.g_Config.BoneFammArray[I].nCount = HUtil32.Str_ToInt(GridBoneFamm.Cells[2, I + 1],  -1);
//                M2Share.g_Config.BoneFammArray[I].nLevel = HUtil32.Str_ToInt(GridBoneFamm.Cells[3, I + 1],  -1);
//                M2Share.Config.WriteInteger("Setup", "BoneFammHumLevel" + (I).ToString(), M2Share.g_Config.BoneFammArray[I].nHumLevel);
//                M2Share.Config.WriteString("Names", "BoneFamm" + (I).ToString(), M2Share.g_Config.BoneFammArray[I].sMonName);
//                M2Share.Config.WriteInteger("Setup", "BoneFammCount" + (I).ToString(), M2Share.g_Config.BoneFammArray[I].nCount);
//                M2Share.Config.WriteInteger("Setup", "BoneFammLevel" + (I).ToString(), M2Share.g_Config.BoneFammArray[I].nLevel);
//            }
            
//            FillChar(M2Share.g_Config.DogzArray, sizeof(M2Share.g_Config.DogzArray), '\0');
//            for (I = M2Share.g_Config.DogzArray.GetLowerBound(0); I <= M2Share.g_Config.DogzArray.GetUpperBound(0); I ++ )
//            {
                
//                M2Share.Config.WriteInteger("Setup", "DogzHumLevel" + (I).ToString(), 0);
                
//                M2Share.Config.WriteString("Names", "Dogz" + (I).ToString(), "");
                
//                M2Share.Config.WriteInteger("Setup", "DogzCount" + (I).ToString(), 0);
                
//                M2Share.Config.WriteInteger("Setup", "DogzLevel" + (I).ToString(), 0);
//            }
//            for (I = M2Share.g_Config.DogzArray.GetLowerBound(0); I <= M2Share.g_Config.DogzArray.GetUpperBound(0); I ++ )
//            {
                
//                if (GridDogz.Cells[0, I + 1] == "")
//                {
//                    break;
//                }
                
//                M2Share.g_Config.DogzArray[I].nHumLevel = HUtil32.Str_ToInt(GridDogz.Cells[0, I + 1],  -1);
                
//                M2Share.g_Config.DogzArray[I].sMonName = GridDogz.Cells[1, I + 1].Trim();
                
//                M2Share.g_Config.DogzArray[I].nCount = HUtil32.Str_ToInt(GridDogz.Cells[2, I + 1],  -1);
                
//                M2Share.g_Config.DogzArray[I].nLevel = HUtil32.Str_ToInt(GridDogz.Cells[3, I + 1],  -1);
                
//                M2Share.Config.WriteInteger("Setup", "DogzHumLevel" + (I).ToString(), M2Share.g_Config.DogzArray[I].nHumLevel);
                
//                M2Share.Config.WriteString("Names", "Dogz" + (I).ToString(), M2Share.g_Config.DogzArray[I].sMonName);
                
//                M2Share.Config.WriteInteger("Setup", "DogzCount" + (I).ToString(), M2Share.g_Config.DogzArray[I].nCount);
                
//                M2Share.Config.WriteInteger("Setup", "DogzLevel" + (I).ToString(), M2Share.g_Config.DogzArray[I].nLevel);
//            }
//            // 月灵
            
//            FillChar(M2Share.g_Config.FairyArray, sizeof(M2Share.g_Config.FairyArray), '\0');
//            for (I = M2Share.g_Config.FairyArray.GetLowerBound(0); I <= M2Share.g_Config.FairyArray.GetUpperBound(0); I ++ )
//            {
                
//                M2Share.Config.WriteInteger("Setup", "FairyHumLevel" + (I).ToString(), 0);
                
//                M2Share.Config.WriteString("Names", "Fairy" + (I).ToString(), "");
                
//                M2Share.Config.WriteInteger("Setup", "FairyCount" + (I).ToString(), 0);
                
//                M2Share.Config.WriteInteger("Setup", "Fairyevel" + (I).ToString(), 0);
//            }
//            for (I = M2Share.g_Config.FairyArray.GetLowerBound(0); I <= M2Share.g_Config.FairyArray.GetUpperBound(0); I ++ )
//            {
                
//                if (GridFairy.Cells[0, I + 1] == "")
//                {
//                    break;
//                }
                
//                M2Share.g_Config.FairyArray[I].nHumLevel = HUtil32.Str_ToInt(GridFairy.Cells[0, I + 1],  -1);
                
//                M2Share.g_Config.FairyArray[I].sMonName = GridFairy.Cells[1, I + 1].Trim();
                
//                M2Share.g_Config.FairyArray[I].nCount = HUtil32.Str_ToInt(GridFairy.Cells[2, I + 1],  -1);
                
//                M2Share.g_Config.FairyArray[I].nLevel = HUtil32.Str_ToInt(GridFairy.Cells[3, I + 1],  -1);
                
//                M2Share.Config.WriteInteger("Setup", "FairyHumLevel" + (I).ToString(), M2Share.g_Config.FairyArray[I].nHumLevel);
                
//                M2Share.Config.WriteString("Names", "Fairy" + (I).ToString(), M2Share.g_Config.FairyArray[I].sMonName);
                
//                M2Share.Config.WriteInteger("Setup", "FairyCount" + (I).ToString(), M2Share.g_Config.FairyArray[I].nCount);
                
//                M2Share.Config.WriteInteger("Setup", "FairyLevel" + (I).ToString(), M2Share.g_Config.FairyArray[I].nLevel);
//            }

            
//            M2Share.Config.WriteBool("Setup", "LimitSwordLong", M2Share.g_Config.boLimitSwordLong);
            
//            M2Share.Config.WriteInteger("Setup", "SwordLongPowerRate", M2Share.g_Config.nSwordLongPowerRate);
            
//            M2Share.Config.WriteInteger("Setup", "BoneFammCount", M2Share.g_Config.nBoneFammCount);
            
//            M2Share.Config.WriteString("Names", "BoneFamm", M2Share.g_Config.sBoneFamm);
            
//            M2Share.Config.WriteInteger("Setup", "DogzCount", M2Share.g_Config.nDogzCount);
            
//            M2Share.Config.WriteString("Names", "Dogz", M2Share.g_Config.sDogz);
//            // 月灵
            
//            M2Share.Config.WriteInteger("Setup", "FairyAttackRate", M2Share.g_Config.nFairyAttackRate);
//            // 20080520
            
//            M2Share.Config.WriteInteger("Setup", "FairyCount", M2Share.g_Config.nFairyCount);
            
//            M2Share.Config.WriteString("Names", "Fairy", M2Share.g_Config.sFairy);
            
//            M2Share.Config.WriteInteger("Setup", "FairyDuntRate", M2Share.g_Config.nFairyDuntRate);
            
//            M2Share.Config.WriteInteger("Setup", "FairyDuntRateBelow", M2Share.g_Config.nFairyDuntRateBelow);
//            // 月灵重击次数,达到次数时按等级出重击 20090105
            
//            M2Share.Config.WriteInteger("Setup", "43KillHitRate", M2Share.g_Config.n43KillHitRate);
//            // 开天斩重击几率 20080213
            
//            M2Share.Config.WriteInteger("Setup", "43KillAttackRate", M2Share.g_Config.n43KillAttackRate);
//            // 开天斩重击倍数  20080213
            
//            M2Share.Config.WriteInteger("Setup", "AttackRate_43", M2Share.g_Config.nAttackRate_43);
//            // 开天斩威力  20080213
            
//            M2Share.Config.WriteInteger("Setup", "AttackRate_26", M2Share.g_Config.nAttackRate_26);
//            // 烈火剑法威力倍数 20081208
            
//            M2Share.Config.WriteInteger("Setup", "AttackRate_74", M2Share.g_Config.nAttackRate_74);
//            // 逐日剑法威力倍数 20080511
            
//            M2Share.Config.WriteInteger("Setup", "FireBoomRage", M2Share.g_Config.nFireBoomRage);
            
//            M2Share.Config.WriteInteger("Setup", "SnowWindRange", M2Share.g_Config.nSnowWindRange);
            
//            M2Share.Config.WriteInteger("Setup", "MeteorFireRainRage", M2Share.g_Config.nMeteorFireRainRage);
//            // 流星火雨攻击范围 20080510
            
//            M2Share.Config.WriteInteger("Setup", "MagFireCharmTreatment", M2Share.g_Config.nMagFireCharmTreatment);
//            // 噬血术加血百分率 20080511
            
//            M2Share.Config.WriteInteger("Setup", "ElecBlizzardRange", M2Share.g_Config.nElecBlizzardRange);
            
//            M2Share.Config.WriteInteger("Setup", "AmyOunsulPoint", M2Share.g_Config.nAmyOunsulPoint);
            
//            M2Share.Config.WriteInteger("Setup", "MagicAttackRage", M2Share.g_Config.nMagicAttackRage);
            
//            M2Share.Config.WriteInteger("Setup", "MagTurnUndeadLevel", M2Share.g_Config.nMagTurnUndeadLevel);
            
//            M2Share.Config.WriteInteger("Setup", "MagTammingLevel", M2Share.g_Config.nMagTammingLevel);
            
//            M2Share.Config.WriteInteger("Setup", "MagTammingTargetLevel", M2Share.g_Config.nMagTammingTargetLevel);
            
//            M2Share.Config.WriteInteger("Setup", "MagTammingTargetHPRate", M2Share.g_Config.nMagTammingHPRate);
            
//            M2Share.Config.WriteInteger("Setup", "MagTammingCount", M2Share.g_Config.nMagTammingCount);
            
//            M2Share.Config.WriteInteger("Setup", "MabMabeHitRandRate", M2Share.g_Config.nMabMabeHitRandRate);
            
//            M2Share.Config.WriteInteger("Setup", "MabMabeHitMinLvLimit", M2Share.g_Config.nMabMabeHitMinLvLimit);
            
//            M2Share.Config.WriteInteger("Setup", "MabMabeHitSucessRate", M2Share.g_Config.nMabMabeHitSucessRate);
            
//            M2Share.Config.WriteInteger("Setup", "MabMabeHitMabeTimeRate", M2Share.g_Config.nMabMabeHitMabeTimeRate);
            
//            M2Share.Config.WriteBool("Setup", "DisableInSafeZoneFireCross", M2Share.g_Config.boDisableInSafeZoneFireCross);
            
//            M2Share.Config.WriteBool("Setup", "GroupMbAttackPlayObject", M2Share.g_Config.boGroupMbAttackPlayObject);
            
//            M2Share.Config.WriteBool("Setup", "PullPlayObject", M2Share.g_Config.boPullPlayObject);
            
//            M2Share.Config.WriteBool("Setup", "PullCrossInSafeZone", M2Share.g_Config.boPullCrossInSafeZone);
            
//            M2Share.Config.WriteBool("Setup", "GroupMbAttackSlave", M2Share.g_Config.boGroupMbAttackSlave);
            
//            M2Share.Config.WriteBool("Setup", "DamageMP", M2Share.g_Config.boPlayObjectReduceMP);
//            // Config.WriteInteger('Setup', 'MagicValidTimeRate', g_Config.nMagDelayTimeDoubly);//未使用 20080504
//            // Config.WriteInteger('Setup', 'MagicPowerRate', g_Config.nMagPowerDoubly);//未使用 20080504
            
//            M2Share.Config.WriteInteger("Setup", "Magic43UseTime", M2Share.g_Config.nKill43UseTime);
//            // 开天斩使用间隔 20080204
            
//            M2Share.Config.WriteInteger("Setup", "MagicDedingUseTime", M2Share.g_Config.nDedingUseTime);
            
//            M2Share.Config.WriteInteger("Setup", "AbilityUpTick", M2Share.g_Config.nAbilityUpTick);
//            // 无极真气使用间隔 20080603
            
//            M2Share.Config.WriteBool("Setup", "AbilityUpFixMode", M2Share.g_Config.boAbilityUpFixMode);
//            // 无极真气使用时长模式 20081109
            
//            M2Share.Config.WriteInteger("Setup", "AbilityUpFixUseTime", M2Share.g_Config.nAbilityUpFixUseTime);
//            // 无极真气使用固定时长 20081109
            
//            M2Share.Config.WriteInteger("Setup", "AbilityUpUseTime", M2Share.g_Config.nAbilityUpUseTime);
//            // 无极真气使用时长 20080603
            
//            M2Share.Config.WriteInteger("Setup", "MinDrinkValue67", M2Share.g_Config.nMinDrinkValue67);
//            // 先天元力失效酒量下限比例 20080626
            
//            M2Share.Config.WriteInteger("Setup", "MinDrinkValue68", M2Share.g_Config.nMinDrinkValue68);
//            // 酒气护体失效酒量下限比例 20080626
            
//            M2Share.Config.WriteInteger("Setup", "HPUpTick", M2Share.g_Config.nHPUpTick);
//            // 酒气护体使用间隔 20080625
            
//            M2Share.Config.WriteInteger("Setup", "HPUpUseTime", M2Share.g_Config.nHPUpUseTime);
//            // 酒气护体增加使用时长 20080625
            
//            //for (I = 1; I < GridSkill68.RowCount; I ++ )
//            //{
//            //    dwExp = HUtil32.Str_ToInt(GridSkill68.Cells[1, I], 0);
//            //    if ((dwExp <= 0))
//            //    {
//            //        MessageBox.Show(("等级 " + (I).ToString() + " 经验值设置错误！！！" as string), "错误信息", MessageBoxButtons.OK);
//            //        GridSkill68.CurrentRowIndex = I;
//            //        GridSkill68.Focus();
//            //        return;
//            //    }
//            //    NeedExps[I] = dwExp;
//            //}
//            M2Share.g_Config.dwSkill68NeedExps = NeedExps;
//            for (I = 1; I <= 100; I ++ )
//            {
                
//                M2Share.Config.WriteString("Skill68", "Level" + (I).ToString(), (M2Share.g_Config.dwSkill68NeedExps[I]).ToString());
//            }
            
//            M2Share.Config.WriteBool("Setup", "DedingAllowPK", M2Share.g_Config.boDedingAllowPK);
            
//            M2Share.Config.WriteInteger("Setup", "FireDelayTimeRate", M2Share.g_Config.nFireDelayTimeRate);
            
//            M2Share.Config.WriteInteger("Setup", "FirePowerRate", M2Share.g_Config.nFirePowerRate);
            
//            M2Share.Config.WriteBool("Setup", "ChangeMapFireExtinguish", M2Share.g_Config.boChangeMapFireExtinguish);
            
//            M2Share.Config.WriteInteger("Setup", "DidingPowerRate", M2Share.g_Config.nDidingPowerRate);
//            // 分身术
//            if (!M2Share.g_Config.boAddMasterName)
//            {
//                if (M2Share.g_Config.sCopyHumName == "")
//                {
//                    MessageBox.Show("分身人物名称不能为空！！！", "错误信息", MessageBoxButtons.OK);
//                    return;
//                }
//            }

            M2Share.Config.WriteInteger("Setup", "MakeSelfTick", M2Share.g_Config.nMakeSelfTick);// 分身使用时长 20080404
            M2Share.Config.WriteInteger("Setup", "CopyHumanTick", M2Share.g_Config.nCopyHumanTick);// 召唤分身间隔 20080204
            M2Share.Config.WriteInteger("Setup", "CopyHumanBagCount", M2Share.g_Config.nCopyHumanBagCount);
            M2Share.Config.WriteInteger("Setup", "CopyHumNameColor", M2Share.g_Config.nCopyHumNameColor);// 分身名字颜色 20080404
            M2Share.Config.WriteInteger("Setup", "AllowCopyHumanCount", M2Share.g_Config.nAllowCopyHumanCount);
            M2Share.Config.WriteBool("Setup", "AddMasterName", M2Share.g_Config.boAddMasterName);
            M2Share.Config.WriteString("Setup", "CopyHumName", M2Share.g_Config.sCopyHumName);
            M2Share.Config.WriteInteger("Setup", "CopyHumAddHPRate", M2Share.g_Config.nCopyHumAddHPRate);
            M2Share.Config.WriteInteger("Setup", "CopyHumAddMPRate", M2Share.g_Config.nCopyHumAddMPRate);
            M2Share.Config.WriteString("Setup", "CopyHumBagItems1", M2Share.g_Config.sCopyHumBagItems1);
            M2Share.Config.WriteString("Setup", "CopyHumBagItems2", M2Share.g_Config.sCopyHumBagItems2);
            M2Share.Config.WriteString("Setup", "CopyHumBagItems3", M2Share.g_Config.sCopyHumBagItems3);
            M2Share.Config.WriteBool("Setup", "AllowGuardAttack", M2Share.g_Config.boAllowGuardAttack);
            M2Share.Config.WriteInteger("Setup", "WarrorAttackTime", M2Share.g_Config.dwWarrorAttackTime);
            M2Share.Config.WriteInteger("Setup", "WizardAttackTime", M2Share.g_Config.dwWizardAttackTime);
            M2Share.Config.WriteInteger("Setup", "TaoistAttackTime", M2Share.g_Config.dwTaoistAttackTime);
            M2Share.Config.WriteBool("Setup", "AllowReCallMobOtherHum", M2Share.g_Config.boAllowReCallMobOtherHum);
            M2Share.Config.WriteBool("Setup", "NeedLevelHighTarget", M2Share.g_Config.boNeedLevelHighTarget);
            M2Share.Config.WriteInteger("Setup", "MagChangXYTick", M2Share.g_Config.dwMagChangXYTick);// 移行换位使用间隔 
            M2Share.Config.WriteInteger("Setup", "ProtectionDefenceTime", M2Share.g_Config.nProtectionDefenceTime); // 护体神盾 
            M2Share.Config.WriteInteger("Setup", "ProtectionTick", M2Share.g_Config.dwProtectionTick);
            M2Share.Config.WriteInteger("Setup", "ProtectionRate", M2Share.g_Config.nProtectionRate);
            M2Share.Config.WriteInteger("Setup", "ProtectionOKRate", M2Share.g_Config.nProtectionOKRate);// 护体神盾生效机率
            M2Share.Config.WriteInteger("Setup", "ProtectionBadRate", M2Share.g_Config.nProtectionBadRate);
            M2Share.Config.WriteBool("Setup", "RushkungBadProtection", M2Share.g_Config.RushkungBadProtection);
            M2Share.Config.WriteBool("Setup", "ErgumBadProtection", M2Share.g_Config.ErgumBadProtection);
            M2Share.Config.WriteBool("Setup", "FirehitBadProtection", M2Share.g_Config.FirehitBadProtection);
            M2Share.Config.WriteBool("Setup", "TwnhitBadProtection", M2Share.g_Config.TwnhitBadProtection);
            M2Share.Config.WriteBool("Setup", "ShowProtectionEnv", M2Share.g_Config.boShowProtectionEnv);// 显示护体神盾效果 
            M2Share.Config.WriteBool("Setup", "AutoProtection", M2Share.g_Config.boAutoProtection);// 自动使用神盾 
            M2Share.Config.WriteBool("Setup", "AutoCanHit", M2Share.g_Config.boAutoCanHit);// 智能锁定 
            M2Share.Config.WriteBool("Setup", "SlaveMoveMaster", M2Share.g_Config.boSlaveMoveMaster);// 宝宝是否飞到主人身边 20080713
            // ------------------------------------------------------------------------------
            // 黄条气槽 20080201
            M2Share.Config.WriteInteger("Setup", "Magic42UseTime", M2Share.g_Config.nKill42UseTime);
            // 龙影剑法使用间隔 20080204
            M2Share.Config.WriteInteger("Setup", "AttackRate_42", M2Share.g_Config.nAttackRate_42);
            // 龙影剑法威力 20080213
            M2Share.Config.WriteInteger("Setup", "MagicAttackRage_42", M2Share.g_Config.nMagicAttackRage_42);
            // 龙影剑法范围 20080218
            // ------------------------------------------------------------------------------
            M2Share.Config.WriteBool("Setup", "Skill31Effect", M2Share.g_Config.boSkill31Effect);
            // 魔法盾效果 T-特色效果 F-盛大效果 20080808

            M2Share.Config.WriteInteger("Setup", "Skill66Rate", M2Share.g_Config.nSkill66Rate);
            // 四级魔法盾抵御伤害百分率 20080829

            M2Share.Config.WriteInteger("Setup", "OrdinarySkill66Rate", M2Share.g_Config.nOrdinarySkill66Rate);
            // 普通魔法盾抵御伤害百分率 20081226

            M2Share.Config.WriteInteger("Setup", "NGSkillRate", M2Share.g_Config.nNGSkillRate);
            // 内功技能增强的攻防比率 20081223

            M2Share.Config.WriteInteger("Setup", "NGLevelDamage", M2Share.g_Config.nNGLevelDamage);
            // 内功等级增加攻防的级数比率 20081223

            M2Share.Config.WriteInteger("Setup", "Skill69NG", M2Share.g_Config.nSkill69NG);
            // 内力值参数 20081001

            M2Share.Config.WriteInteger("Setup", "Skill69NGExp", M2Share.g_Config.nSkill69NGExp);
            // 主体内功经验参数 20081001

            M2Share.Config.WriteInteger("Setup", "HeroSkill69NGExp", M2Share.g_Config.nHeroSkill69NGExp);
            // 英雄内功经验参数 20081001

            M2Share.Config.WriteInteger("Setup", "dwIncNHTime", M2Share.g_Config.dwIncNHTime);
            // 增加内力值间隔 20081002

            M2Share.Config.WriteInteger("Setup", "DrinkIncNHExp", M2Share.g_Config.nDrinkIncNHExp);
            // 饮酒增加内功经验 20081003

            M2Share.Config.WriteInteger("Setup", "HitStruckDecNH", M2Share.g_Config.nHitStruckDecNH);
            // 内功抵御普通攻击消耗内力值 20081003

            M2Share.Config.WriteInteger("Exp", "KillMonNGExpMultiple", M2Share.g_Config.dwKillMonNGExpMultiple);
            // 杀怪内功经验倍数 20081215

            M2Share.Config.WriteInteger("Setup", "Magic69UseTime", M2Share.g_Config.Magic69UseTime);
            // 倚天劈地使用间隔 20100224

            M2Share.Config.WriteInteger("setup", "magic96Usetime", M2Share.g_Config.magic96usetime);
            // 血魄一击使用间隔 20100224
            uModValue();
        }

        private void RefUpgradeWeapon()
        {
            ScrollBarUpgradeWeaponDCRate.Value = M2Share.g_Config.nUpgradeWeaponDCRate;
            ScrollBarUpgradeWeaponDCTwoPointRate.Value = M2Share.g_Config.nUpgradeWeaponDCTwoPointRate;
            ScrollBarUpgradeWeaponDCThreePointRate.Value = M2Share.g_Config.nUpgradeWeaponDCThreePointRate;
            ScrollBarUpgradeWeaponMCRate.Value = M2Share.g_Config.nUpgradeWeaponMCRate;
            ScrollBarUpgradeWeaponMCTwoPointRate.Value = M2Share.g_Config.nUpgradeWeaponMCTwoPointRate;
            ScrollBarUpgradeWeaponMCThreePointRate.Value = M2Share.g_Config.nUpgradeWeaponMCThreePointRate;
            ScrollBarUpgradeWeaponSCRate.Value = M2Share.g_Config.nUpgradeWeaponSCRate;
            ScrollBarUpgradeWeaponSCTwoPointRate.Value = M2Share.g_Config.nUpgradeWeaponSCTwoPointRate;
            ScrollBarUpgradeWeaponSCThreePointRate.Value = M2Share.g_Config.nUpgradeWeaponSCThreePointRate;
            EditUpgradeWeaponMaxPoint.Value = M2Share.g_Config.nUpgradeWeaponMaxPoint;
            EditUpgradeWeaponPrice.Value = M2Share.g_Config.nUpgradeWeaponPrice;
            EditUPgradeWeaponGetBackTime.Value = M2Share.g_Config.dwUPgradeWeaponGetBackTime / 1000;
            EditClearExpireUpgradeWeaponDays.Value = M2Share.g_Config.nClearExpireUpgradeWeaponDays;
        }

        public void ScrollBarUpgradeWeaponDCRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponDCRate.Value;
            EditUpgradeWeaponDCRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponDCRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponDCTwoPointRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponDCTwoPointRate.Value;
            EditUpgradeWeaponDCTwoPointRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponDCTwoPointRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponDCThreePointRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponDCThreePointRate.Value;
            EditUpgradeWeaponDCThreePointRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponDCThreePointRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponSCRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponSCRate.Value;
            EditUpgradeWeaponSCRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponSCRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponSCTwoPointRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponSCTwoPointRate.Value;
            EditUpgradeWeaponSCTwoPointRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponSCTwoPointRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponSCThreePointRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponSCThreePointRate.Value;
            EditUpgradeWeaponSCThreePointRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponSCThreePointRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponMCRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponMCRate.Value;
            EditUpgradeWeaponMCRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponMCRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponMCTwoPointRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponMCTwoPointRate.Value;
            EditUpgradeWeaponMCTwoPointRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponMCTwoPointRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarUpgradeWeaponMCThreePointRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarUpgradeWeaponMCThreePointRate.Value;
            EditUpgradeWeaponMCThreePointRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponMCThreePointRate = (ushort)nPostion;
            ModValue();
        }

        public void EditUpgradeWeaponMaxPointChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponMaxPoint = (ushort)EditUpgradeWeaponMaxPoint.Value;
            ModValue();
        }

        public void EditUpgradeWeaponPriceChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponPrice = (int)EditUpgradeWeaponPrice.Value;
            ModValue();
        }

        public void EditUPgradeWeaponGetBackTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwUPgradeWeaponGetBackTime = (uint)EditUPgradeWeaponGetBackTime.Value * 1000;
            ModValue();
        }

        public void EditClearExpireUpgradeWeaponDaysChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nClearExpireUpgradeWeaponDays = (byte)EditClearExpireUpgradeWeaponDays.Value;
            ModValue();
        }

        public void ButtonUpgradeWeaponSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponMaxPoint", M2Share.g_Config.nUpgradeWeaponMaxPoint);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponPrice", M2Share.g_Config.nUpgradeWeaponPrice);
            M2Share.Config.WriteInteger("Setup", "ClearExpireUpgradeWeaponDays", M2Share.g_Config.nClearExpireUpgradeWeaponDays);
            M2Share.Config.WriteInteger("Setup", "UPgradeWeaponGetBackTime", M2Share.g_Config.dwUPgradeWeaponGetBackTime);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponDCRate", M2Share.g_Config.nUpgradeWeaponDCRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponDCTwoPointRate", M2Share.g_Config.nUpgradeWeaponDCTwoPointRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponDCThreePointRate", M2Share.g_Config.nUpgradeWeaponDCThreePointRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponMCRate", M2Share.g_Config.nUpgradeWeaponMCRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponMCTwoPointRate", M2Share.g_Config.nUpgradeWeaponMCTwoPointRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponMCThreePointRate", M2Share.g_Config.nUpgradeWeaponMCThreePointRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponSCRate", M2Share.g_Config.nUpgradeWeaponSCRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponSCTwoPointRate", M2Share.g_Config.nUpgradeWeaponSCTwoPointRate);
            M2Share.Config.WriteInteger("Setup", "UpgradeWeaponSCThreePointRate", M2Share.g_Config.nUpgradeWeaponSCThreePointRate);
            uModValue();
        }

        public void ButtonUpgradeWeaponDefaulfClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认恢复默认设置？", "确认信息", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            M2Share.g_Config.nUpgradeWeaponMaxPoint = 20;
            M2Share.g_Config.nUpgradeWeaponPrice = 10000;
            M2Share.g_Config.nClearExpireUpgradeWeaponDays = 8;// 60 * 60 * 1000
            M2Share.g_Config.dwUPgradeWeaponGetBackTime = 3600000;
            M2Share.g_Config.nUpgradeWeaponDCRate = 100;
            M2Share.g_Config.nUpgradeWeaponDCTwoPointRate = 30;
            M2Share.g_Config.nUpgradeWeaponDCThreePointRate = 200;
            M2Share.g_Config.nUpgradeWeaponMCRate = 100;
            M2Share.g_Config.nUpgradeWeaponMCTwoPointRate = 30;
            M2Share.g_Config.nUpgradeWeaponMCThreePointRate = 200;
            M2Share.g_Config.nUpgradeWeaponSCRate = 100;
            M2Share.g_Config.nUpgradeWeaponSCTwoPointRate = 30;
            M2Share.g_Config.nUpgradeWeaponSCThreePointRate = 200;
            RefUpgradeWeapon();
        }

        public void EditMasterOKLevelChange(Object Sender)
        {
            if (EditMasterOKLevel.Text == "")
            {
                EditMasterOKLevel.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMasterOKLevel = (ushort)EditMasterOKLevel.Value;
            ModValue();
        }

        public void EditMasterOKCreditPointChange(Object Sender)
        {
            if (EditMasterOKCreditPoint.Text == "")
            {
                EditMasterOKCreditPoint.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMasterOKCreditPoint = (byte)EditMasterOKCreditPoint.Value;
            ModValue();
        }

        public void EditMasterOKBonusPointChange(Object Sender)
        {
            if (EditMasterOKBonusPoint.Text == "")
            {
                EditMasterOKBonusPoint.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMasterOKBonusPoint = (ushort)EditMasterOKBonusPoint.Value;
            ModValue();
        }

        public void ButtonMasterSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "MasterCount", M2Share.g_Config.nMasterCount);// 可收徒弟数 20080530
            M2Share.Config.WriteInteger("Setup", "MasterOKLevel", M2Share.g_Config.nMasterOKLevel);
            M2Share.Config.WriteInteger("Setup", "MasterOKCreditPoint", M2Share.g_Config.nMasterOKCreditPoint);
            M2Share.Config.WriteInteger("Setup", "MasterOKBonusPoint", M2Share.g_Config.nMasterOKBonusPoint);
            uModValue();
        }

        public void ButtonMakeMineSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "MakeMineHitRate", M2Share.g_Config.nMakeMineHitRate);
            M2Share.Config.WriteInteger("Setup", "MakeMineRate", M2Share.g_Config.nMakeMineRate);
            M2Share.Config.WriteInteger("Setup", "StoneTypeRate", M2Share.g_Config.nStoneTypeRate);
            M2Share.Config.WriteInteger("Setup", "StoneTypeRateMin", M2Share.g_Config.nStoneTypeRateMin);
            M2Share.Config.WriteInteger("Setup", "GoldStoneMin", M2Share.g_Config.nGoldStoneMin);
            M2Share.Config.WriteInteger("Setup", "GoldStoneMax", M2Share.g_Config.nGoldStoneMax);
            M2Share.Config.WriteInteger("Setup", "SilverStoneMin", M2Share.g_Config.nSilverStoneMin);
            M2Share.Config.WriteInteger("Setup", "SilverStoneMax", M2Share.g_Config.nSilverStoneMax);
            M2Share.Config.WriteInteger("Setup", "SteelStoneMin", M2Share.g_Config.nSteelStoneMin);
            M2Share.Config.WriteInteger("Setup", "SteelStoneMax", M2Share.g_Config.nSteelStoneMax);
            M2Share.Config.WriteInteger("Setup", "BlackStoneMin", M2Share.g_Config.nBlackStoneMin);
            M2Share.Config.WriteInteger("Setup", "BlackStoneMax", M2Share.g_Config.nBlackStoneMax);
            M2Share.Config.WriteInteger("Setup", "StoneMinDura", M2Share.g_Config.nStoneMinDura);
            M2Share.Config.WriteInteger("Setup", "StoneGeneralDuraRate", M2Share.g_Config.nStoneGeneralDuraRate);
            M2Share.Config.WriteInteger("Setup", "StoneAddDuraRate", M2Share.g_Config.nStoneAddDuraRate);
            M2Share.Config.WriteInteger("Setup", "StoneAddDuraMax", M2Share.g_Config.nStoneAddDuraMax);
            uModValue();
        }

        public void ButtonMakeMineDefaultClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认恢复默认设置？", "确认信息", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            M2Share.g_Config.nMakeMineHitRate = 4;
            M2Share.g_Config.nMakeMineRate = 12;
            M2Share.g_Config.nStoneTypeRate = 120;
            M2Share.g_Config.nStoneTypeRateMin = 56;
            M2Share.g_Config.nGoldStoneMin = 1;
            M2Share.g_Config.nGoldStoneMax = 2;
            M2Share.g_Config.nSilverStoneMin = 3;
            M2Share.g_Config.nSilverStoneMax = 20;
            M2Share.g_Config.nSteelStoneMin = 21;
            M2Share.g_Config.nSteelStoneMax = 45;
            M2Share.g_Config.nBlackStoneMin = 46;
            M2Share.g_Config.nBlackStoneMax = 56;
            M2Share.g_Config.nStoneMinDura = 3000;
            M2Share.g_Config.nStoneGeneralDuraRate = 13000;
            M2Share.g_Config.nStoneAddDuraRate = 20;
            M2Share.g_Config.nStoneAddDuraMax = 10000;
            RefMakeMine();
        }

        private void RefMakeMine()
        {
            ScrollBarMakeMineHitRate.Value = M2Share.g_Config.nMakeMineHitRate;
            ScrollBarMakeMineHitRate.Minimum = 0;
            ScrollBarMakeMineHitRate.Maximum = 10;
            ScrollBarMakeMineRate.Value = M2Share.g_Config.nMakeMineRate;
            ScrollBarMakeMineRate.Minimum = 0;
            ScrollBarMakeMineRate.Maximum = 50;
            ScrollBarStoneTypeRate.Value = M2Share.g_Config.nStoneTypeRate;
            ScrollBarStoneTypeRate.Minimum = M2Share.g_Config.nStoneTypeRateMin;
            ScrollBarStoneTypeRate.Maximum = 500;
            ScrollBarGoldStoneMax.Minimum = 1;
            ScrollBarGoldStoneMax.Maximum = M2Share.g_Config.nSilverStoneMax;
            ScrollBarSilverStoneMax.Minimum = M2Share.g_Config.nGoldStoneMax;
            ScrollBarSilverStoneMax.Maximum = M2Share.g_Config.nSteelStoneMax;
            ScrollBarSteelStoneMax.Minimum = M2Share.g_Config.nSilverStoneMax;
            ScrollBarSteelStoneMax.Maximum = M2Share.g_Config.nBlackStoneMax;
            ScrollBarBlackStoneMax.Minimum = M2Share.g_Config.nSteelStoneMax;
            ScrollBarBlackStoneMax.Maximum = M2Share.g_Config.nStoneTypeRate;
            ScrollBarGoldStoneMax.Value = M2Share.g_Config.nGoldStoneMax;
            ScrollBarSilverStoneMax.Value = M2Share.g_Config.nSilverStoneMax;
            ScrollBarSteelStoneMax.Value = M2Share.g_Config.nSteelStoneMax;
            ScrollBarBlackStoneMax.Value = M2Share.g_Config.nBlackStoneMax;
            EditStoneMinDura.Value = M2Share.g_Config.nStoneMinDura / 1000;
            EditStoneGeneralDuraRate.Value = M2Share.g_Config.nStoneGeneralDuraRate / 1000;
            EditStoneAddDuraRate.Value = M2Share.g_Config.nStoneAddDuraRate;
            EditStoneAddDuraMax.Value = M2Share.g_Config.nStoneAddDuraMax / 1000;
        }

        public void ScrollBarMakeMineHitRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarMakeMineHitRate.Value;
            EditMakeMineHitRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMakeMineHitRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarMakeMineRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarMakeMineRate.Value;
            EditMakeMineRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMakeMineRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarStoneTypeRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarStoneTypeRate.Value;
            EditStoneTypeRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            ScrollBarBlackStoneMax.Maximum = nPostion;
            M2Share.g_Config.nStoneTypeRate = (ushort)nPostion;
            ModValue();
        }

        public void ScrollBarGoldStoneMaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarGoldStoneMax.Value;
            EditGoldStoneMax.Text = (M2Share.g_Config.nGoldStoneMin).ToString() + "-" + (M2Share.g_Config.nGoldStoneMax).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSilverStoneMin = Convert.ToUInt16(nPostion + 1);
            ScrollBarSilverStoneMax.Minimum = nPostion + 1;
            M2Share.g_Config.nGoldStoneMax = (ushort)nPostion;
            EditSilverStoneMax.Text = (M2Share.g_Config.nSilverStoneMin).ToString() + "-" + (M2Share.g_Config.nSilverStoneMax).ToString();
            ModValue();
        }

        public void ScrollBarSilverStoneMaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarSilverStoneMax.Value;
            EditSilverStoneMax.Text = (M2Share.g_Config.nSilverStoneMin).ToString() + "-" + (M2Share.g_Config.nSilverStoneMax).ToString();
            if (!boOpened)
            {
                return;
            }
            ScrollBarGoldStoneMax.Maximum = nPostion - 1;
            M2Share.g_Config.nSteelStoneMin = Convert.ToUInt16(nPostion + 1);
            ScrollBarSteelStoneMax.Minimum = nPostion + 1;
            M2Share.g_Config.nSilverStoneMax = (ushort)nPostion;
            EditGoldStoneMax.Text = (M2Share.g_Config.nGoldStoneMin).ToString() + "-" + (M2Share.g_Config.nGoldStoneMax).ToString();
            EditSteelStoneMax.Text = (M2Share.g_Config.nSteelStoneMin).ToString() + "-" + (M2Share.g_Config.nSteelStoneMax).ToString();
            ModValue();
        }

        public void ScrollBarSteelStoneMaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarSteelStoneMax.Value;
            EditSteelStoneMax.Text = (M2Share.g_Config.nSteelStoneMin).ToString() + "-" + (M2Share.g_Config.nSteelStoneMax).ToString();
            if (!boOpened)
            {
                return;
            }
            ScrollBarSilverStoneMax.Maximum = nPostion - 1;
            M2Share.g_Config.nBlackStoneMin = Convert.ToUInt16(nPostion + 1);
            ScrollBarBlackStoneMax.Minimum = nPostion + 1;
            M2Share.g_Config.nSteelStoneMax = (ushort)nPostion;
            EditSilverStoneMax.Text = (M2Share.g_Config.nSilverStoneMin).ToString() + "-" + (M2Share.g_Config.nSilverStoneMax).ToString();
            EditBlackStoneMax.Text = (M2Share.g_Config.nBlackStoneMin).ToString() + "-" + (M2Share.g_Config.nBlackStoneMax).ToString();
            ModValue();
        }

        public void ScrollBarBlackStoneMaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarBlackStoneMax.Value;
            EditBlackStoneMax.Text = (M2Share.g_Config.nBlackStoneMin).ToString() + "-" + (M2Share.g_Config.nBlackStoneMax).ToString();
            if (!boOpened)
            {
                return;
            }
            ScrollBarSteelStoneMax.Maximum = nPostion - 1;
            ScrollBarStoneTypeRate.Minimum = nPostion;
            M2Share.g_Config.nBlackStoneMax = (ushort)nPostion;
            EditSteelStoneMax.Text = (M2Share.g_Config.nSteelStoneMin).ToString() + "-" + (M2Share.g_Config.nSteelStoneMax).ToString();
            ModValue();
        }

        public void EditStoneMinDuraChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStoneMinDura = Convert.ToUInt16(EditStoneMinDura.Value * 1000);
            ModValue();
        }

        public void EditStoneGeneralDuraRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStoneGeneralDuraRate = Convert.ToUInt16(EditStoneGeneralDuraRate.Value * 1000);
            ModValue();
        }

        public void EditStoneAddDuraRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStoneAddDuraRate = (ushort)EditStoneAddDuraRate.Value;
            ModValue();
        }

        public void EditStoneAddDuraMaxChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nStoneAddDuraMax = Convert.ToUInt16(EditStoneAddDuraMax.Value * 1000);
            ModValue();
        }

        private void RefWinLottery()
        {
            ScrollBarWinLotteryRate.Maximum = 100000;
            ScrollBarWinLotteryRate.Value = M2Share.g_Config.nWinLotteryRate;
            ScrollBarWinLottery1Max.Maximum = M2Share.g_Config.nWinLotteryRate;
            ScrollBarWinLottery1Max.Minimum = M2Share.g_Config.nWinLottery1Min;
            ScrollBarWinLottery2Max.Maximum = M2Share.g_Config.nWinLottery1Max;
            ScrollBarWinLottery2Max.Minimum = M2Share.g_Config.nWinLottery2Min;
            ScrollBarWinLottery3Max.Maximum = M2Share.g_Config.nWinLottery2Max;
            ScrollBarWinLottery3Max.Minimum = M2Share.g_Config.nWinLottery3Min;
            ScrollBarWinLottery4Max.Maximum = M2Share.g_Config.nWinLottery3Max;
            ScrollBarWinLottery4Max.Minimum = M2Share.g_Config.nWinLottery4Min;
            ScrollBarWinLottery5Max.Maximum = M2Share.g_Config.nWinLottery4Max;
            ScrollBarWinLottery5Max.Minimum = M2Share.g_Config.nWinLottery5Min;
            ScrollBarWinLottery6Max.Maximum = M2Share.g_Config.nWinLottery5Max;
            ScrollBarWinLottery6Max.Minimum = M2Share.g_Config.nWinLottery6Min;
            ScrollBarWinLotteryRate.Minimum = M2Share.g_Config.nWinLottery1Max;
            ScrollBarWinLottery1Max.Value = M2Share.g_Config.nWinLottery1Max;
            ScrollBarWinLottery2Max.Value = M2Share.g_Config.nWinLottery2Max;
            ScrollBarWinLottery3Max.Value = M2Share.g_Config.nWinLottery3Max;
            ScrollBarWinLottery4Max.Value = M2Share.g_Config.nWinLottery4Max;
            ScrollBarWinLottery5Max.Value = M2Share.g_Config.nWinLottery5Max;
            ScrollBarWinLottery6Max.Value = M2Share.g_Config.nWinLottery6Max;
            EditWinLottery1Gold.Value = M2Share.g_Config.nWinLottery1Gold;
            EditWinLottery2Gold.Value = M2Share.g_Config.nWinLottery2Gold;
            EditWinLottery3Gold.Value = M2Share.g_Config.nWinLottery3Gold;
            EditWinLottery4Gold.Value = M2Share.g_Config.nWinLottery4Gold;
            EditWinLottery5Gold.Value = M2Share.g_Config.nWinLottery5Gold;
            EditWinLottery6Gold.Value = M2Share.g_Config.nWinLottery6Gold;
        }

        public void ButtonWinLotterySaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "WinLottery1Gold", M2Share.g_Config.nWinLottery1Gold);
            M2Share.Config.WriteInteger("Setup", "WinLottery2Gold", M2Share.g_Config.nWinLottery2Gold);
            M2Share.Config.WriteInteger("Setup", "WinLottery3Gold", M2Share.g_Config.nWinLottery3Gold);
            M2Share.Config.WriteInteger("Setup", "WinLottery4Gold", M2Share.g_Config.nWinLottery4Gold);
            M2Share.Config.WriteInteger("Setup", "WinLottery5Gold", M2Share.g_Config.nWinLottery5Gold);
            M2Share.Config.WriteInteger("Setup", "WinLottery6Gold", M2Share.g_Config.nWinLottery6Gold);
            M2Share.Config.WriteInteger("Setup", "WinLottery1Min", M2Share.g_Config.nWinLottery1Min);
            M2Share.Config.WriteInteger("Setup", "WinLottery1Max", M2Share.g_Config.nWinLottery1Max);
            M2Share.Config.WriteInteger("Setup", "WinLottery2Min", M2Share.g_Config.nWinLottery2Min);
            M2Share.Config.WriteInteger("Setup", "WinLottery2Max", M2Share.g_Config.nWinLottery2Max);
            M2Share.Config.WriteInteger("Setup", "WinLottery3Min", M2Share.g_Config.nWinLottery3Min);
            M2Share.Config.WriteInteger("Setup", "WinLottery3Max", M2Share.g_Config.nWinLottery3Max);
            M2Share.Config.WriteInteger("Setup", "WinLottery4Min", M2Share.g_Config.nWinLottery4Min);
            M2Share.Config.WriteInteger("Setup", "WinLottery4Max", M2Share.g_Config.nWinLottery4Max);
            M2Share.Config.WriteInteger("Setup", "WinLottery5Min", M2Share.g_Config.nWinLottery5Min);
            M2Share.Config.WriteInteger("Setup", "WinLottery5Max", M2Share.g_Config.nWinLottery5Max);
            M2Share.Config.WriteInteger("Setup", "WinLottery6Min", M2Share.g_Config.nWinLottery6Min);
            M2Share.Config.WriteInteger("Setup", "WinLottery6Max", M2Share.g_Config.nWinLottery6Max);
            M2Share.Config.WriteInteger("Setup", "WinLotteryRate", M2Share.g_Config.nWinLotteryRate);
            uModValue();
        }

        public void ButtonWinLotteryDefaultClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认恢复默认设置？", "确认信息", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            M2Share.g_Config.nWinLottery1Gold = 1000000;
            M2Share.g_Config.nWinLottery2Gold = 200000;
            M2Share.g_Config.nWinLottery3Gold = 100000;
            M2Share.g_Config.nWinLottery4Gold = 10000;
            M2Share.g_Config.nWinLottery5Gold = 1000;
            M2Share.g_Config.nWinLottery6Gold = 500;
            M2Share.g_Config.nWinLottery6Min = 1;
            M2Share.g_Config.nWinLottery6Max = 4999;
            M2Share.g_Config.nWinLottery5Min = 14000;
            M2Share.g_Config.nWinLottery5Max = 15999;
            M2Share.g_Config.nWinLottery4Min = 16000;
            M2Share.g_Config.nWinLottery4Max = 16149;
            M2Share.g_Config.nWinLottery3Min = 16150;
            M2Share.g_Config.nWinLottery3Max = 16169;
            M2Share.g_Config.nWinLottery2Min = 16170;
            M2Share.g_Config.nWinLottery2Max = 16179;
            M2Share.g_Config.nWinLottery1Min = 16180;
            M2Share.g_Config.nWinLottery1Max = 16185;
            M2Share.g_Config.nWinLotteryRate = 30000;
            RefWinLottery();
        }

        public void EditWinLottery1GoldChange(Object Sender)
        {
            if (EditWinLottery1Gold.Text == "")
            {
                EditWinLottery1Gold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery1Gold = (int)EditWinLottery1Gold.Value;
            ModValue();
        }

        public void EditWinLottery2GoldChange(Object Sender)
        {
            if (EditWinLottery2Gold.Text == "")
            {
                EditWinLottery2Gold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery2Gold = (int)EditWinLottery2Gold.Value;
            ModValue();
        }

        public void EditWinLottery3GoldChange(Object Sender)
        {
            if (EditWinLottery3Gold.Text == "")
            {
                EditWinLottery3Gold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery3Gold = (int)EditWinLottery3Gold.Value;
            ModValue();
        }

        public void EditWinLottery4GoldChange(Object Sender)
        {
            if (EditWinLottery4Gold.Text == "")
            {
                EditWinLottery4Gold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery4Gold = (int)EditWinLottery4Gold.Value;
            ModValue();
        }

        public void EditWinLottery5GoldChange(Object Sender)
        {
            if (EditWinLottery5Gold.Text == "")
            {
                EditWinLottery5Gold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery5Gold = (int)EditWinLottery5Gold.Value;
            ModValue();
        }

        public void EditWinLottery6GoldChange(Object Sender)
        {
            if (EditWinLottery6Gold.Text == "")
            {
                EditWinLottery6Gold.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery6Gold = (int)EditWinLottery6Gold.Value;
            ModValue();
        }

        public void ScrollBarWinLottery1MaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarWinLottery1Max.Value;
            EditWinLottery1Max.Text = (M2Share.g_Config.nWinLottery1Min).ToString() + "-" + (M2Share.g_Config.nWinLottery1Max).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery1Max = nPostion;
            ScrollBarWinLottery2Max.Maximum = nPostion - 1;
            ScrollBarWinLotteryRate.Minimum = nPostion;
            EditWinLottery1Max.Text = (M2Share.g_Config.nWinLottery1Min).ToString() + "-" + (M2Share.g_Config.nWinLottery1Max).ToString();
            ModValue();
        }

        public void ScrollBarWinLottery2MaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarWinLottery2Max.Value;
            EditWinLottery2Max.Text = (M2Share.g_Config.nWinLottery2Min).ToString() + "-" + (M2Share.g_Config.nWinLottery2Max).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery1Min = nPostion + 1;
            ScrollBarWinLottery1Max.Minimum = nPostion + 1;
            M2Share.g_Config.nWinLottery2Max = nPostion;
            EditWinLottery2Max.Text = (M2Share.g_Config.nWinLottery2Min).ToString() + "-" + (M2Share.g_Config.nWinLottery2Max).ToString();
            EditWinLottery1Max.Text = (M2Share.g_Config.nWinLottery1Min).ToString() + "-" + (M2Share.g_Config.nWinLottery1Max).ToString();
            ModValue();
        }

        public void ScrollBarWinLottery3MaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarWinLottery3Max.Value;
            EditWinLottery3Max.Text = (M2Share.g_Config.nWinLottery3Min).ToString() + "-" + (M2Share.g_Config.nWinLottery3Max).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery2Min = nPostion + 1;
            ScrollBarWinLottery2Max.Minimum = nPostion + 1;
            M2Share.g_Config.nWinLottery3Max = nPostion;
            EditWinLottery3Max.Text = (M2Share.g_Config.nWinLottery3Min).ToString() + "-" + (M2Share.g_Config.nWinLottery3Max).ToString();
            EditWinLottery2Max.Text = (M2Share.g_Config.nWinLottery2Min).ToString() + "-" + (M2Share.g_Config.nWinLottery2Max).ToString();
            ModValue();
        }

        public void ScrollBarWinLottery4MaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarWinLottery4Max.Value;
            EditWinLottery4Max.Text = (M2Share.g_Config.nWinLottery4Min).ToString() + "-" + (M2Share.g_Config.nWinLottery4Max).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery3Min = nPostion + 1;
            ScrollBarWinLottery3Max.Minimum = nPostion + 1;
            M2Share.g_Config.nWinLottery4Max = nPostion;
            EditWinLottery4Max.Text = (M2Share.g_Config.nWinLottery4Min).ToString() + "-" + (M2Share.g_Config.nWinLottery4Max).ToString();
            EditWinLottery3Max.Text = (M2Share.g_Config.nWinLottery3Min).ToString() + "-" + (M2Share.g_Config.nWinLottery3Max).ToString();
            ModValue();
        }

        public void ScrollBarWinLottery5MaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarWinLottery5Max.Value;
            EditWinLottery5Max.Text = (M2Share.g_Config.nWinLottery5Min).ToString() + "-" + (M2Share.g_Config.nWinLottery5Max).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery4Min = nPostion + 1;
            ScrollBarWinLottery4Max.Minimum = nPostion + 1;
            M2Share.g_Config.nWinLottery5Max = nPostion;
            EditWinLottery5Max.Text = (M2Share.g_Config.nWinLottery5Min).ToString() + "-" + (M2Share.g_Config.nWinLottery5Max).ToString();
            EditWinLottery4Max.Text = (M2Share.g_Config.nWinLottery4Min).ToString() + "-" + (M2Share.g_Config.nWinLottery4Max).ToString();
            ModValue();
        }

        public void ScrollBarWinLottery6MaxChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarWinLottery6Max.Value;
            EditWinLottery6Max.Text = (M2Share.g_Config.nWinLottery6Min).ToString() + "-" + (M2Share.g_Config.nWinLottery6Max).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWinLottery5Min = nPostion + 1;
            ScrollBarWinLottery5Max.Minimum = nPostion + 1;
            M2Share.g_Config.nWinLottery6Max = nPostion;
            EditWinLottery6Max.Text = (M2Share.g_Config.nWinLottery6Min).ToString() + "-" + (M2Share.g_Config.nWinLottery6Max).ToString();
            EditWinLottery5Max.Text = (M2Share.g_Config.nWinLottery5Min).ToString() + "-" + (M2Share.g_Config.nWinLottery5Max).ToString();
            ModValue();
        }

        public void ScrollBarWinLotteryRateChange(object sender, EventArgs e)
        {
            int nPostion;
            nPostion = ScrollBarWinLotteryRate.Value;
            EditWinLotteryRate.Text = (nPostion).ToString();
            if (!boOpened)
            {
                return;
            }
            ScrollBarWinLottery1Max.Maximum = nPostion;
            M2Share.g_Config.nWinLotteryRate = nPostion;
            ModValue();
        }

        private void RefReNewLevelConf()
        {
            EditReNewNameColor1.Value = M2Share.g_Config.ReNewNameColor[0];
            EditReNewNameColor2.Value = M2Share.g_Config.ReNewNameColor[1];
            EditReNewNameColor3.Value = M2Share.g_Config.ReNewNameColor[2];
            EditReNewNameColor4.Value = M2Share.g_Config.ReNewNameColor[3];
            EditReNewNameColor5.Value = M2Share.g_Config.ReNewNameColor[4];
            EditReNewNameColor6.Value = M2Share.g_Config.ReNewNameColor[5];
            EditReNewNameColor7.Value = M2Share.g_Config.ReNewNameColor[6];
            EditReNewNameColor8.Value = M2Share.g_Config.ReNewNameColor[7];
            EditReNewNameColor9.Value = M2Share.g_Config.ReNewNameColor[8];
            EditReNewNameColor10.Value = M2Share.g_Config.ReNewNameColor[9];
            EditReNewNameColorTime.Value = M2Share.g_Config.dwReNewNameColorTime / 1000;
            CheckBoxReNewChangeColor.Checked = M2Share.g_Config.boReNewChangeColor;
            CheckBoxReNewLevelClearExp.Checked = M2Share.g_Config.boReNewLevelClearExp;
        }

        public void ButtonReNewLevelSaveClick(object sender, EventArgs e)
        {
            int I;
            for (I = M2Share.g_Config.ReNewNameColor.GetLowerBound(0); I <= M2Share.g_Config.ReNewNameColor.GetUpperBound(0); I ++ )
            {
                M2Share.Config.WriteInteger("Setup", "ReNewNameColor" + (I).ToString(), M2Share.g_Config.ReNewNameColor[I]);
            }
            M2Share.Config.WriteInteger("Setup", "ReNewNameColorTime", M2Share.g_Config.dwReNewNameColorTime);
            M2Share.Config.WriteBool("Setup", "ReNewChangeColor", M2Share.g_Config.boReNewChangeColor);
            M2Share.Config.WriteBool("Setup", "ReNewLevelClearExp", M2Share.g_Config.boReNewLevelClearExp);
            uModValue();
        }

        public void EditReNewNameColor1Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor1.Value;
            LabelReNewNameColor1.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[0] = btColor;
            ModValue();
        }

        public void EditReNewNameColor2Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor2.Value;
            LabelReNewNameColor2.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[1] = btColor;
            ModValue();
        }

        public void EditReNewNameColor3Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor3.Value;
            LabelReNewNameColor3.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[2] = btColor;
            ModValue();
        }

        public void EditReNewNameColor4Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor4.Value;
            LabelReNewNameColor4.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[3] = btColor;
            ModValue();
        }

        public void EditReNewNameColor5Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor5.Value;
            LabelReNewNameColor5.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[4] = btColor;
            ModValue();
        }

        public void EditReNewNameColor6Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor6.Value;
            LabelReNewNameColor6.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[5] = btColor;
            ModValue();
        }

        public void EditReNewNameColor7Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor7.Value;
            LabelReNewNameColor7.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[6] = btColor;
            ModValue();
        }

        public void EditReNewNameColor8Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor8.Value;
            LabelReNewNameColor8.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[7] = btColor;
            ModValue();
        }

        public void EditReNewNameColor9Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor9.Value;
            LabelReNewNameColor9.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[8] = btColor;
            ModValue();
        }

        public void EditReNewNameColor10Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditReNewNameColor10.Value;
            LabelReNewNameColor10.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ReNewNameColor[9] = btColor;
            ModValue();
        }

        public void EditReNewNameColorTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwReNewNameColorTime = (uint)EditReNewNameColorTime.Value * 1000;
            ModValue();
        }

        private void RefMonUpgrade()
        {
            EditMonUpgradeColor1.Value = M2Share.g_Config.SlaveColor[0];
            EditMonUpgradeColor2.Value = M2Share.g_Config.SlaveColor[1];
            EditMonUpgradeColor3.Value = M2Share.g_Config.SlaveColor[2];
            EditMonUpgradeColor4.Value = M2Share.g_Config.SlaveColor[3];
            EditMonUpgradeColor5.Value = M2Share.g_Config.SlaveColor[4];
            EditMonUpgradeColor6.Value = M2Share.g_Config.SlaveColor[5];
            EditMonUpgradeColor7.Value = M2Share.g_Config.SlaveColor[6];
            EditMonUpgradeColor8.Value = M2Share.g_Config.SlaveColor[7];
            EditMonUpgradeColor9.Value = M2Share.g_Config.SlaveColor[8];
            EditMonUpgradeKillCount1.Value = M2Share.g_Config.MonUpLvNeedKillCount[0];
            EditMonUpgradeKillCount2.Value = M2Share.g_Config.MonUpLvNeedKillCount[1];
            EditMonUpgradeKillCount3.Value = M2Share.g_Config.MonUpLvNeedKillCount[2];
            EditMonUpgradeKillCount4.Value = M2Share.g_Config.MonUpLvNeedKillCount[3];
            EditMonUpgradeKillCount5.Value = M2Share.g_Config.MonUpLvNeedKillCount[4];
            EditMonUpgradeKillCount6.Value = M2Share.g_Config.MonUpLvNeedKillCount[5];
            EditMonUpgradeKillCount7.Value = M2Share.g_Config.MonUpLvNeedKillCount[6];
            EditMonUpLvNeedKillBase.Value = M2Share.g_Config.nMonUpLvNeedKillBase;
            EditMonUpLvRate.Value = M2Share.g_Config.nMonUpLvRate;
            CheckBoxMasterDieMutiny.Checked = M2Share.g_Config.boMasterDieMutiny;
            EditMasterDieMutinyRate.Value = M2Share.g_Config.nMasterDieMutinyRate;
            EditMasterDieMutinyPower.Value = M2Share.g_Config.nMasterDieMutinyPower;
            EditMasterDieMutinySpeed.Value = M2Share.g_Config.nMasterDieMutinySpeed;
            //CheckBoxMasterDieMutinyClick(CheckBoxMasterDieMutiny);
            CheckBoxBBMonAutoChangeColor.Checked = M2Share.g_Config.boBBMonAutoChangeColor;
            EditBBMonAutoChangeColorTime.Value = M2Share.g_Config.dwBBMonAutoChangeColorTime / 1000;
        }

        private void RefBatterConf()
        {
            SpinEdit1.Value = M2Share.g_Config.PulsePointNGLevel0;
            SpinEdit2.Value = M2Share.g_Config.PulsePointNGLevel1;
            SpinEdit3.Value = M2Share.g_Config.PulsePointNGLevel2;
            SpinEdit4.Value = M2Share.g_Config.PulsePointNGLevel3;
            SpinEdit5.Value = M2Share.g_Config.PulsePointNGLevel4;
            SpinEdit6.Value = M2Share.g_Config.PulsePointNGLevel5;
            SpinEdit7.Value = M2Share.g_Config.PulsePointNGLevel6;
            SpinEdit8.Value = M2Share.g_Config.PulsePointNGLevel7;
            SpinEdit9.Value = M2Share.g_Config.PulsePointNGLevel8;
            SpinEdit10.Value = M2Share.g_Config.PulsePointNGLevel9;
            SpinEdit11.Value = M2Share.g_Config.PulsePointNGLevel10;
            SpinEdit12.Value = M2Share.g_Config.PulsePointNGLevel11;
            SpinEdit13.Value = M2Share.g_Config.PulsePointNGLevel12;
            SpinEdit14.Value = M2Share.g_Config.PulsePointNGLevel13;
            SpinEdit15.Value = M2Share.g_Config.PulsePointNGLevel14;
            SpinEdit16.Value = M2Share.g_Config.PulsePointNGLevel15;
            SpinEdit17.Value = M2Share.g_Config.PulsePointNGLevel16;
            SpinEdit18.Value = M2Share.g_Config.PulsePointNGLevel17;
            SpinEdit19.Value = M2Share.g_Config.PulsePointNGLevel18;
            SpinEdit20.Value = M2Share.g_Config.PulsePointNGLevel19;
            SpinEdit21.Value = M2Share.g_Config.StormsHitAppearRate0;
            SpinEdit22.Value = M2Share.g_Config.StormsHitAppearRate1;
            SpinEdit23.Value = M2Share.g_Config.StormsHitAppearRate2;
            SpinEdit24.Value = M2Share.g_Config.StormsHitAppearRate3;
            SpinEdit25.Value = M2Share.g_Config.StormsHitAppearRate4;
            SpinEdit26.Value = M2Share.g_Config.StormsHitRate1;
            SpinEdit27.Value = M2Share.g_Config.StormsHitRate2;
            SpinEdit28.Value = M2Share.g_Config.StormsHitRate3;
            SpinEdit29.Value = M2Share.g_Config.StormsHitRate4;
            SpinEdit30.Value = M2Share.g_Config.StormsHitRate5;
            SpinEdit31.Value = M2Share.g_Config.UseBatterTick / 1000;
            SpinEdit32.Value = M2Share.g_Config.BatterSkillFireRange_82;
            SpinEdit33.Value = M2Share.g_Config.BatterSkillFireRange_85;
            SpinEdit34.Value = M2Share.g_Config.BatterSkillFireRange_86;
            SpinEdit35.Value = M2Share.g_Config.BatterSkillFireRange_87;
        }

        public void ButtonMonUpgradeSaveClick(object sender, EventArgs e)
        {

            int I;


            
            M2Share.Config.WriteInteger("Setup", "MonUpLvNeedKillBase", M2Share.g_Config.nMonUpLvNeedKillBase);
            
            M2Share.Config.WriteInteger("Setup", "MonUpLvRate", M2Share.g_Config.nMonUpLvRate);
            for (I = M2Share.g_Config.MonUpLvNeedKillCount.GetLowerBound(0); I <= M2Share.g_Config.MonUpLvNeedKillCount.GetUpperBound(0); I ++ )
            {
                
                M2Share.Config.WriteInteger("Setup", "MonUpLvNeedKillCount" + (I).ToString(), M2Share.g_Config.MonUpLvNeedKillCount[I]);
            }
            for (I = M2Share.g_Config.SlaveColor.GetLowerBound(0); I <= M2Share.g_Config.SlaveColor.GetUpperBound(0); I ++ )
            {
                
                M2Share.Config.WriteInteger("Setup", "SlaveColor" + (I).ToString(), M2Share.g_Config.SlaveColor[I]);
            }
            
            M2Share.Config.WriteBool("Setup", "MasterDieMutiny", M2Share.g_Config.boMasterDieMutiny);
            
            M2Share.Config.WriteInteger("Setup", "MasterDieMutinyRate", M2Share.g_Config.nMasterDieMutinyRate);
            
            M2Share.Config.WriteInteger("Setup", "MasterDieMutinyPower", M2Share.g_Config.nMasterDieMutinyPower);
            
            M2Share.Config.WriteInteger("Setup", "MasterDieMutinyPower", M2Share.g_Config.nMasterDieMutinySpeed);
            
            M2Share.Config.WriteBool("Setup", "BBMonAutoChangeColor", M2Share.g_Config.boBBMonAutoChangeColor);
            
            M2Share.Config.WriteInteger("Setup", "BBMonAutoChangeColorTime", M2Share.g_Config.dwBBMonAutoChangeColorTime);

            uModValue();
        }

        public void EditMonUpgradeColor1Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor1.Value;
            LabelMonUpgradeColor1.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[0] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor2Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor2.Value;
            LabelMonUpgradeColor2.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[1] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor3Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor3.Value;
            LabelMonUpgradeColor3.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[2] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor4Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor4.Value;
            LabelMonUpgradeColor4.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[3] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor5Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor5.Value;
            LabelMonUpgradeColor5.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[4] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor6Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor6.Value;
            LabelMonUpgradeColor6.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[5] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor7Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor7.Value;
            LabelMonUpgradeColor7.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[6] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor8Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor8.Value;
            LabelMonUpgradeColor8.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[7] = btColor;
            ModValue();
        }

        public void EditMonUpgradeColor9Change(Object Sender)
        {
            byte btColor;
            btColor = (byte)EditMonUpgradeColor9.Value;
            LabelMonUpgradeColor9.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.SlaveColor[8] = btColor;
            ModValue();
        }

        public void CheckBoxReNewChangeColorClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boReNewChangeColor = CheckBoxReNewChangeColor.Checked;
            ModValue();
        }

        public void CheckBoxReNewLevelClearExpClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boReNewLevelClearExp = CheckBoxReNewLevelClearExp.Checked;
            ModValue();
        }

        public void EditPKFlagNameColorChange(object sender, EventArgs e)
        {
            byte btColor = (byte)EditPKFlagNameColor.Value;
            LabelPKFlagNameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btPKFlagNameColor = btColor;
            ModValue();
        }

        public void EditPKLevel1NameColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditPKLevel1NameColor.Value;
            LabelPKLevel1NameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btPKLevel1NameColor = btColor;
            ModValue();
        }

        public void EditPKLevel2NameColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditPKLevel2NameColor.Value;
            LabelPKLevel2NameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btPKLevel2NameColor = btColor;
            ModValue();
        }

        public void EditAllyAndGuildNameColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditAllyAndGuildNameColor.Value;
            LabelAllyAndGuildNameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btAllyAndGuildNameColor = btColor;
            ModValue();
        }

        public void EditWarGuildNameColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditWarGuildNameColor.Value;
            LabelWarGuildNameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btWarGuildNameColor = btColor;
            ModValue();
        }

        public void EditInFreePKAreaNameColorChange(object sender, EventArgs e)
        {
            byte btColor;
            btColor = (byte)EditInFreePKAreaNameColor.Value;
            LabelInFreePKAreaNameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btInFreePKAreaNameColor = btColor;
            ModValue();
        }

        public void EditMonUpgradeKillCount1Change(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.MonUpLvNeedKillCount[0] = (ushort)EditMonUpgradeKillCount1.Value;
            ModValue();
        }

        public void EditMonUpgradeKillCount2Change(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.MonUpLvNeedKillCount[1] = (ushort)EditMonUpgradeKillCount2.Value;
            ModValue();
        }

        public void EditMonUpgradeKillCount3Change(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.MonUpLvNeedKillCount[2] = (ushort)EditMonUpgradeKillCount3.Value;
            ModValue();
        }

        public void EditMonUpgradeKillCount4Change(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.MonUpLvNeedKillCount[3] = (ushort)EditMonUpgradeKillCount4.Value;
            ModValue();
        }

        public void EditMonUpgradeKillCount5Change(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.MonUpLvNeedKillCount[4] = (ushort)EditMonUpgradeKillCount5.Value;
            ModValue();
        }

        public void EditMonUpgradeKillCount6Change(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.MonUpLvNeedKillCount[5] = (ushort)EditMonUpgradeKillCount6.Value;
            ModValue();
        }

        public void EditMonUpgradeKillCount7Change(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.MonUpLvNeedKillCount[6] = (ushort)EditMonUpgradeKillCount7.Value;
            ModValue();
        }

        public void EditMonUpLvNeedKillBaseChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMonUpLvNeedKillBase = (int)EditMonUpLvNeedKillBase.Value;
            ModValue();
        }

        public void EditMonUpLvRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMonUpLvRate = (ushort)EditMonUpLvRate.Value;
            ModValue();
        }

        public void CheckBoxMasterDieMutinyClick(object sender, EventArgs e)
        {
            if (CheckBoxMasterDieMutiny.Checked)
            {
                EditMasterDieMutinyRate.Enabled = true;
                EditMasterDieMutinyPower.Enabled = true;
                EditMasterDieMutinySpeed.Enabled = true;
            }
            else
            {
                EditMasterDieMutinyRate.Enabled = false;
                EditMasterDieMutinyPower.Enabled = false;
                EditMasterDieMutinySpeed.Enabled = false;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boMasterDieMutiny = CheckBoxMasterDieMutiny.Checked;
            ModValue();
        }

        public void EditMasterDieMutinyRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMasterDieMutinyRate = (ushort)EditMasterDieMutinyRate.Value;
            ModValue();
        }

        public void EditMasterDieMutinyPowerChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMasterDieMutinyPower = (ushort)EditMasterDieMutinyPower.Value;
            ModValue();
        }

        public void EditMasterDieMutinySpeedChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMasterDieMutinySpeed = (ushort)EditMasterDieMutinySpeed.Value;
            ModValue();
        }

        public void CheckBoxBBMonAutoChangeColorClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boBBMonAutoChangeColor = CheckBoxBBMonAutoChangeColor.Checked;
            ModValue();
        }

        public void EditBBMonAutoChangeColorTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwBBMonAutoChangeColorTime = (int)EditBBMonAutoChangeColorTime.Value * 1000;
            ModValue();
        }

        private void RefSpiritMutiny()
        {
            CheckBoxSpiritMutiny.Checked = M2Share.g_Config.boSpiritMutiny;// (60 * 1000)
            EditSpiritMutinyTime.Value = M2Share.g_Config.dwSpiritMutinyTime / 60000;
            //CheckBoxSpiritMutinyClick(CheckBoxSpiritMutiny);
        }

        public void ButtonSpiritMutinySaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "SpiritMutiny", M2Share.g_Config.boSpiritMutiny);
            M2Share.Config.WriteInteger("Setup", "SpiritMutinyTime", M2Share.g_Config.dwSpiritMutinyTime);
            uModValue();
        }

        public void CheckBoxSpiritMutinyClick(object sender, EventArgs e)
        {
            if (CheckBoxSpiritMutiny.Checked)
            {
                EditSpiritMutinyTime.Enabled = true;
            }
            else
            {
                EditSpiritMutinyTime.Enabled = false;
                EditSpiritPowerRate.Enabled = false;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boSpiritMutiny = CheckBoxSpiritMutiny.Checked;
            ModValue();
        }

        public void EditSpiritMutinyTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            // 60 * 1000
            M2Share.g_Config.dwSpiritMutinyTime = (uint)EditSpiritMutinyTime.Value * 60000;
            ModValue();
        }

        // 祈祷能量倍数,未使用
        public void EditSpiritPowerRateChange(Object Sender)
        {
            // if not boOpened then Exit;
            // g_Config.nSpiritPowerRate := EditSpiritPowerRate.Value;
            // ModValue();

        }

        public void EditMagTammingLevelChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMagTammingLevel = (ushort)EditMagTammingLevel.Value;
            ModValue();
        }

        public void EditMagTammingTargetLevelChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMagTammingTargetLevel = (ushort)EditMagTammingTargetLevel.Value;
            ModValue();
        }

        public void EditMagTammingHPRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMagTammingHPRate = (ushort)EditMagTammingHPRate.Value;
            ModValue();
        }

        public void EditTammingCountChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMagTammingCount = (byte)EditTammingCount.Value;
            ModValue();
        }

        public void EditMabMabeHitRandRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMabMabeHitRandRate = (byte)EditMabMabeHitRandRate.Value;
            ModValue();
        }

        public void EditMabMabeHitMinLvLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMabMabeHitMinLvLimit = (byte)EditMabMabeHitMinLvLimit.Value;
            ModValue();
        }

        public void EditMabMabeHitSucessRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMabMabeHitSucessRate = (byte)EditMabMabeHitSucessRate.Value;
            ModValue();
        }

        public void EditMabMabeHitMabeTimeRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMabMabeHitMabeTimeRate = (byte)EditMabMabeHitMabeTimeRate.Value;
            ModValue();
        }

        private void RefMonSayMsg()
        {
            CheckBoxMonSayMsg.Checked = M2Share.g_Config.boMonSayMsg;
        }

        public void ButtonMonSayMsgSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "MonSayMsg", M2Share.g_Config.boMonSayMsg);
            uModValue();
        }

        public void CheckBoxMonSayMsgClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boMonSayMsg = CheckBoxMonSayMsg.Checked;
            ModValue();
        }

        private void RefWeaponMakeLuck()
        {
            ScrollBarWeaponMakeUnLuckRate.Minimum = 1;
            ScrollBarWeaponMakeUnLuckRate.Maximum = 50;
            ScrollBarWeaponMakeUnLuckRate.Value = M2Share.g_Config.nWeaponMakeUnLuckRate;
            ScrollBarWeaponMakeLuckPoint1.Minimum = 1;
            ScrollBarWeaponMakeLuckPoint1.Maximum = 10;
            ScrollBarWeaponMakeLuckPoint1.Value = M2Share.g_Config.nWeaponMakeLuckPoint1;
            ScrollBarWeaponMakeLuckPoint2.Minimum = 1;
            ScrollBarWeaponMakeLuckPoint2.Maximum = 10;
            ScrollBarWeaponMakeLuckPoint2.Value = M2Share.g_Config.nWeaponMakeLuckPoint2;
            ScrollBarWeaponMakeLuckPoint3.Minimum = 1;
            ScrollBarWeaponMakeLuckPoint3.Maximum = 10;
            ScrollBarWeaponMakeLuckPoint3.Value = M2Share.g_Config.nWeaponMakeLuckPoint3;
            ScrollBarWeaponMakeLuckPoint2Rate.Minimum = 1;
            ScrollBarWeaponMakeLuckPoint2Rate.Maximum = 50;
            ScrollBarWeaponMakeLuckPoint2Rate.Value = M2Share.g_Config.nWeaponMakeLuckPoint2Rate;
            ScrollBarWeaponMakeLuckPoint3Rate.Minimum = 1;
            ScrollBarWeaponMakeLuckPoint3Rate.Maximum = 50;
            ScrollBarWeaponMakeLuckPoint3Rate.Value = M2Share.g_Config.nWeaponMakeLuckPoint3Rate;
        }

        public void ButtonWeaponMakeLuckDefaultClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认恢复默认设置？", "确认信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            M2Share.g_Config.nWeaponMakeUnLuckRate = 20;
            M2Share.g_Config.nWeaponMakeLuckPoint1 = 1;
            M2Share.g_Config.nWeaponMakeLuckPoint2 = 3;
            M2Share.g_Config.nWeaponMakeLuckPoint3 = 7;
            M2Share.g_Config.nWeaponMakeLuckPoint2Rate = 6;
            M2Share.g_Config.nWeaponMakeLuckPoint3Rate = 40;
            RefWeaponMakeLuck();
        }

        public void ButtonWeaponMakeLuckSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "WeaponMakeUnLuckRate", M2Share.g_Config.nWeaponMakeUnLuckRate);
            M2Share.Config.WriteInteger("Setup", "WeaponMakeLuckPoint1", M2Share.g_Config.nWeaponMakeLuckPoint1);
            M2Share.Config.WriteInteger("Setup", "WeaponMakeLuckPoint2", M2Share.g_Config.nWeaponMakeLuckPoint2);
            M2Share.Config.WriteInteger("Setup", "WeaponMakeLuckPoint3", M2Share.g_Config.nWeaponMakeLuckPoint3);
            M2Share.Config.WriteInteger("Setup", "WeaponMakeLuckPoint2Rate", M2Share.g_Config.nWeaponMakeLuckPoint2Rate);
            M2Share.Config.WriteInteger("Setup", "WeaponMakeLuckPoint3Rate", M2Share.g_Config.nWeaponMakeLuckPoint3Rate);
            uModValue();
        }

        public void ScrollBarWeaponMakeUnLuckRateChange(object sender, EventArgs e)
        {
            int nInteger;
            nInteger = ScrollBarWeaponMakeUnLuckRate.Value;
            EditWeaponMakeUnLuckRate.Text = (nInteger).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMakeUnLuckRate = (ushort)nInteger;
            ModValue();
        }

        public void ScrollBarWeaponMakeLuckPoint1Change(object sender, EventArgs e)
        {
            int nInteger;
            nInteger = ScrollBarWeaponMakeLuckPoint1.Value;
            EditWeaponMakeLuckPoint1.Text = (nInteger).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMakeLuckPoint1 = (ushort)nInteger;
            ModValue();
        }

        public void ScrollBarWeaponMakeLuckPoint2Change(object sender, EventArgs e)
        {
            int nInteger;
            nInteger = ScrollBarWeaponMakeLuckPoint2.Value;
            EditWeaponMakeLuckPoint2.Text = (nInteger).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMakeLuckPoint2 = (ushort)nInteger;
            ModValue();
        }

        public void ScrollBarWeaponMakeLuckPoint2RateChange(object sender, EventArgs e)
        {
            int nInteger;
            nInteger = ScrollBarWeaponMakeLuckPoint2Rate.Value;
            EditWeaponMakeLuckPoint2Rate.Text = (nInteger).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMakeLuckPoint2Rate = (ushort)nInteger;
            ModValue();
        }

        public void ScrollBarWeaponMakeLuckPoint3Change(object sender, EventArgs e)
        {
            int nInteger;
            nInteger = ScrollBarWeaponMakeLuckPoint3.Value;
            EditWeaponMakeLuckPoint3.Text = (nInteger).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMakeLuckPoint3 = (ushort)nInteger;
            ModValue();
        }

        public void ScrollBarWeaponMakeLuckPoint3RateChange(object sender, EventArgs e)
        {
            int nInteger;
            nInteger = ScrollBarWeaponMakeLuckPoint3Rate.Value;
            EditWeaponMakeLuckPoint3Rate.Text = (nInteger).ToString();
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMakeLuckPoint3Rate = (ushort)nInteger;
            ModValue();
        }

        // 每次扣多少元宝(元宝寄售)
        public void EdtDecUserGameGoldChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDecUserGameGold = (ushort)EdtDecUserGameGold.Value;
            ModValue();
        }

        // 20080504 去掉拍卖功能
        public void SpinEditSellOffCountChange(Object Sender)
        {
            // if not boOpened then Exit;
            // g_Config.nUserSellOffCount := SpinEditSellOffCount.Value;
            // ModValue();
        }

        // 20080504 去掉拍卖功能
        public void SpinEditSellOffTaxChange(Object Sender)
        {
            // if not boOpened then Exit;
            // g_Config.nUserSellOffTax := SpinEditSellOffTax.Value;
            // ModValue();

        }

        public void ButtonSellOffSaveClick(object sender, EventArgs e)
        {
            // Config.WriteInteger('Setup', 'SellOffCountLimit', g_Config.nUserSellOffCount); //20080504 去掉拍卖功能
            // Config.WriteInteger('Setup', 'SellOffRate', g_Config.nUserSellOffTax); //20080504 去掉拍卖功能
            
            M2Share.Config.WriteInteger("Setup", "DecUserGameGold", M2Share.g_Config.nDecUserGameGold);
            // 每次扣多少元宝(元宝寄售) 20080319
            uModValue();
        }

        public void CheckBoxPullPlayObjectClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boPullPlayObject = CheckBoxPullPlayObject.Checked;
            CheckBoxPullCrossInSafeZone.Enabled = CheckBoxPullPlayObject.Checked;
            ModValue();
        }

        public void CheckBoxPlayObjectReduceMPClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boPlayObjectReduceMP = CheckBoxPlayObjectReduceMP.Checked;
            ModValue();
        }

        public void CheckBoxGroupMbAttackSlaveClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boGroupMbAttackSlave = CheckBoxGroupMbAttackSlave.Checked;
            ModValue();
        }

        public void CheckBoxItemNameClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boChangeUseItemNameByPlayName = CheckBoxItemName.Checked;
            ModValue();
        }

        public void EditItemNameChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sChangeUseItemName = EditItemName.Text.Trim();
            ModValue();
        }

        public void ButtonChangeUseItemNameClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteBool("Setup", "ChangeUseItemNameByPlayName", M2Share.g_Config.boChangeUseItemNameByPlayName);
            M2Share.Config.WriteString("Setup", "ChangeUseItemName", M2Share.g_Config.sChangeUseItemName);
            uModValue();
        }

        public void SpinEditSkill39SecChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDedingUseTime = (byte)SpinEditSkill39Sec.Value;
            ModValue();
        }

        public void CheckBoxDedingAllowPKClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boDedingAllowPK = CheckBoxDedingAllowPK.Checked;
            ModValue();
        }

        public void SpinEditAllowCopyCountChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nAllowCopyHumanCount = (int)SpinEditAllowCopyCount.Value;
            ModValue();
        }

        public void EditCopyHumNameChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sCopyHumName = EditCopyHumName.Text;
            ModValue();
        }

        public void CheckBoxMasterNameClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boAddMasterName = CheckBoxMasterName.Checked;
            ModValue();
        }

        public void SpinEditPickUpItemCountChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCopyHumanBagCount = (int)SpinEditPickUpItemCount.Value;
            ModValue();
        }

        public void SpinEditEatHPItemRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCopyHumAddHPRate = (byte)SpinEditEatHPItemRate.Value;
            ModValue();
        }

        public void SpinEditEatMPItemRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCopyHumAddMPRate = (byte)SpinEditEatMPItemRate.Value;
            ModValue();
        }

        public void SpinEditFireDelayTimeClick(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nFireDelayTimeRate = (ushort)SpinEditFireDelayTime.Value;
            ModValue();
        }

        public void SpinEditFirePowerClick(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nFirePowerRate = (ushort)SpinEditFirePower.Value;
            ModValue();
        }

        public void EditBagItems1Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sCopyHumBagItems1 = EditBagItems1.Text.Trim();
            ModValue();
        }

        public void EditBagItems2Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sCopyHumBagItems2 = EditBagItems2.Text.Trim();
            ModValue();
        }

        public void EditBagItems3Change(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.sCopyHumBagItems3 = EditBagItems3.Text.Trim();
            ModValue();
        }

        public void CheckBoxAllowGuardAttackClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boAllowGuardAttack = CheckBoxAllowGuardAttack.Checked;
            ModValue();
        }

        private void RefCopyHumConf()
        {
            EditCopyHumNameColor.Value = M2Share.g_Config.nCopyHumNameColor;
            // 分身名字颜色 20080404
            SpinEditAllowCopyCount.Value = M2Share.g_Config.nAllowCopyHumanCount;
            EditCopyHumName.Text = M2Share.g_Config.sCopyHumName;
            CheckBoxMasterName.Checked = M2Share.g_Config.boAddMasterName;
            SpinEditPickUpItemCount.Value = M2Share.g_Config.nCopyHumanBagCount;
            SpinEditEatHPItemRate.Value = M2Share.g_Config.nCopyHumAddHPRate;
            SpinEditEatMPItemRate.Value = M2Share.g_Config.nCopyHumAddMPRate;
            EditBagItems1.Text = M2Share.g_Config.sCopyHumBagItems1;
            EditBagItems2.Text = M2Share.g_Config.sCopyHumBagItems2;
            EditBagItems3.Text = M2Share.g_Config.sCopyHumBagItems3;
            CheckBoxAllowGuardAttack.Checked = M2Share.g_Config.boAllowGuardAttack;
            SpinEditWarrorAttackTime.Value = M2Share.g_Config.dwWarrorAttackTime;
            SpinEditWizardAttackTime.Value = M2Share.g_Config.dwWizardAttackTime;
            SpinEditTaoistAttackTime.Value = M2Share.g_Config.dwTaoistAttackTime;
            CheckBoxAllowReCallMobOtherHum.Checked = M2Share.g_Config.boAllowReCallMobOtherHum;
            CheckBoxNeedLevelHighTarget.Checked = M2Share.g_Config.boNeedLevelHighTarget;
            CheckBoxNeedLevelHighTarget.Enabled = M2Share.g_Config.boAllowReCallMobOtherHum;
        }

        public void SpinEditWarrorAttackTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwWarrorAttackTime = (uint)SpinEditWarrorAttackTime.Value;
            ModValue();
        }

        public void SpinEditWizardAttackTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwWizardAttackTime = (uint)SpinEditWizardAttackTime.Value;
            ModValue();
        }

        public void SpinEditTaoistAttackTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwTaoistAttackTime = (uint)SpinEditTaoistAttackTime.Value;
            ModValue();
        }

        public void CheckBoxAllowReCallMobOtherHumClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boAllowReCallMobOtherHum = CheckBoxAllowReCallMobOtherHum.Checked;
            CheckBoxNeedLevelHighTarget.Enabled = M2Share.g_Config.boAllowReCallMobOtherHum;
            ModValue();
        }

        public void CheckBoxNeedLevelHighTargetClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boNeedLevelHighTarget = CheckBoxNeedLevelHighTarget.Checked;
            ModValue();
        }

        public void CheckBoxPullCrossInSafeZoneClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boPullCrossInSafeZone = CheckBoxPullCrossInSafeZone.Checked;
            ModValue();
        }

        public void CheckBoxStartMapEventClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boStartMapEvent = CheckBoxStartMapEvent.Checked;
            ModValue();
        }

        public void SpinEditDidingPowerRateClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDidingPowerRate = (ushort)SpinEditDidingPowerRate.Value;
            ModValue();
        }

        public void FairyNameEdtChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void SpinFairyEdtChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nFairyCount = (byte)SpinFairyEdt.Value;
            ModValue();
        }

        public void GridFairySetEditText(Object Sender, int ACol, int ARow, string Value)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void SpinFairyDuntRateEdtChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nFairyDuntRate = (byte)SpinFairyDuntRateEdt.Value;
            ModValue();
        }

        public void SpinFairyAttackRateEdtChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nFairyAttackRate = (ushort)SpinFairyAttackRateEdt.Value;
            ModValue();
        }

        // ------------------------------------------------------------------------------
        // 护体神盾 20080108
        public void EditProtectionDefenceTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nProtectionDefenceTime = (uint)EditProtectionDefenceTime.Value * 1000;
            ModValue();
        }

        public void EditProtectionTickChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwProtectionTick = (uint)EditProtectionTick.Value * 1000;
            ModValue();
        }

        public void EditProtectionRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nProtectionRate = (byte)EditProtectionRate.Value;
            ModValue();
        }

        public void EditProtectionBadRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nProtectionBadRate = (byte)EditProtectionBadRate.Value;
            ModValue();
        }

        public void CheckRushkungBadClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.RushkungBadProtection = CheckRushkungBad.Checked;
            ModValue();
        }

        public void CheckErgumBadClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.ErgumBadProtection = CheckErgumBad.Checked;
            ModValue();
        }

        public void CheckFirehitBadClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.FirehitBadProtection = CheckFirehitBad.Checked;
            ModValue();
        }

        public void CheckTwnhitBadClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.TwnhitBadProtection = CheckTwnhitBad.Checked;
            ModValue();
        }

//        // -----------------------------------------------------------------------------
//        // 龙影剑法使用间隔 20080204
//        public void SpinEditKill42SecChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            // 20080619 注释
//            M2Share.g_Config.nKill42UseTime = SpinEditKill42Sec.Value;
//            ModValue();
//        }

//        // 黄条气槽 20080201
//        public void EditDecDragonPointChange(Object Sender)
//        {
//        }

//        // 龙影剑法威力 20080213
//        public void SpinEditAttackRate_2Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nAttackRate_42 = SpinEditAttackRate_42.Value;
//            ModValue();
//        }

//        // 龙影剑法范围 20080218
//        public void EditMagicAttackRage_42Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMagicAttackRage_42 = EditMagicAttackRage_42.Value;
//            ModValue();
//        }

//        // -----------------------------------------------------------------------------
//        // 开天斩使用间隔 20080204
//        public void SpinEditKill43SecChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nKill43UseTime = SpinEditKill43Sec.Value;
//            ModValue();
//        }

//        // 分身使用时长 20080404
//        public void SpinEditMakeSelfTickChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMakeSelfTick = SpinEditMakeSelfTick.Value;
//            ModValue();
//        }

//        // 召唤分身间隔 20080204
//        public void SpinEditnCopyHumanTickChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nCopyHumanTick = SpinEditnCopyHumanTick.Value;
//            ModValue();
//        }

//        // 开天斩重击几率 20080213
//        public void Spin43KillHitRateEdtChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.n43KillHitRate = Spin43KillHitRateEdt.Value;
//            ModValue();
//        }

//        // 开天斩重击倍数  20080213
//        public void Spin43KillAttackRateEdtChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.n43KillAttackRate = Spin43KillAttackRateEdt.Value;
//            ModValue();
//        }

//        // 开天斩威力 20080213
//        public void SpinEditAttackRate_43Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nAttackRate_43 = SpinEditAttackRate_43.Value;
//            ModValue();
//        }

//        // 显示护体神盾效果 20080328
//        public void ShowProtectionEnvClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boShowProtectionEnv = ShowProtectionEnv.Checked;
//            ModValue();
//        }

//        // 自动使用神盾 20080328
//        public void AutoProtectionClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boAutoProtection = AutoProtection.Checked;
//            ModValue();
//        }

//        // 分身名字颜色 20080404
//        public void EditCopyHumNameColorChange(Object Sender)
//        {
//            byte btColor;
//            btColor = EditCopyHumNameColor.Value;
//            LabelCopyHumNameColor.BackColor = M2Share.GetRGB(btColor);
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nCopyHumNameColor = btColor;
//            ModValue();
//        }

//        // 智能锁定 20080418
//        public void AutoCanHitClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boAutoCanHit = AutoCanHit.Checked;
//            ModValue();
//        }

//        public void EditMeteorFireRainRageChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMeteorFireRainRage = EditMeteorFireRainRage.Value;
//            ModValue();
//        }

//        // 噬血术加血百分率 20080511
//        public void EditMagFireCharmTreatmentChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMagFireCharmTreatment = EditMagFireCharmTreatment.Value;
//            ModValue();
//        }

//        public void SpinEditAttackRate_74Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nAttackRate_74 = SpinEditAttackRate_74.Value;
//            ModValue();
//        }

//        public void CheckBoxLockCallHeroClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boLockCallHeroAction = CheckBoxLockCallHero.Checked;
//            ModValue();
//        }

//        // 可收徒弟数 20080530
//        public void EditMasterCountChange(Object Sender)
//        {
//            if (EditMasterCount.Text == "")
//            {
//                EditMasterCount.Text = "1";
//                return;
//            }
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMasterCount = EditMasterCount.Value;
//            ModValue();
//        }

//        // 无极真气使用间隔 20080603
//        public void EditAbilityUpTickChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nAbilityUpTick = EditAbilityUpTick.Value;
//            ModValue();
//        }

//        // 无极真气使用时长 20080603
//        public void SpinEditAbilityUpUseTimeChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nAbilityUpUseTime = SpinEditAbilityUpUseTime.Value;
//            ModValue();
//        }

//        // 移行换位使用间隔 20080616
//        public void SpinEditMagChangXYChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.dwMagChangXYTick = SpinEditMagChangXY.Value * 1000;
//            ModValue();
//        }

//        // 酿酒等待时间 20080621
//        public void SpinEditMakeWineTimeChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMakeWineTime = SpinEditMakeWineTime.Value;
//            ModValue();
//        }

//        // 酿药酒等待时间 20080621
//        public void SpinEditMakeWineTime1Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMakeWineTime1 = SpinEditMakeWineTime1.Value;
//            ModValue();
//        }

//        // 酿酒获得酒曲机率 20080621
//        public void SpinEditMakeWineRateChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMakeWineRate = SpinEditMakeWineRate.Value;
//            ModValue();
//        }

//        public void ButtonSaveMakeWineClick(object sender, EventArgs e)
//        {
//            int I;
//            uint dwExp;
//            ushort[] NeedExps;
            
//            for (I = 1; I < GridMedicineExp.RowCount; I ++ )
//            {
                
//                dwExp = HUtil32.Str_ToInt(GridMedicineExp.Cells[1, I], 0);
//                if ((dwExp <= 0))
//                {
//                    // 20080522
//                    MessageBox.Show(("等级 " + (I).ToString() + " 药力值设置错误！！！" as string), "错误信息", MessageBoxButtons.OK);
//                    GridMedicineExp.CurrentRowIndex = I;
//                    GridMedicineExp.Focus();
//                    return;
//                }
//                NeedExps[I] = dwExp;
//            }
//            M2Share.g_Config.dwMedicineNeedExps = NeedExps;
//            for (I = 1; I <= 1000; I ++ )
//            {
                
//                M2Share.Config.WriteString("MedicineExp", "Level" + (I).ToString(), (M2Share.g_Config.dwMedicineNeedExps[I]).ToString());
//            }
            
//            M2Share.Config.WriteInteger("Setup", "MinGuildFountain", M2Share.g_Config.nMinGuildFountain);
//            // 行会酒泉蓄量少于时,不能领取 20080627
            
//            M2Share.Config.WriteInteger("Setup", "DecGuildFountain", M2Share.g_Config.nDecGuildFountain);
//            // 行会成员领取酒泉,蓄量减少 20080627
            
//            M2Share.Config.WriteInteger("Setup", "InFountainTime", M2Share.g_Config.nInFountainTime);
//            // 站在泉眼上的累积时间(秒) 20080624
            
//            M2Share.Config.WriteInteger("Setup", "DesMedicineTick", M2Share.g_Config.nDesMedicineTick);
//            // //减药力值时间间隔 20080624
            
//            M2Share.Config.WriteInteger("Setup", "DesMedicineValue", M2Share.g_Config.nDesMedicineValue);
//            // 长时间不使用酒,减药力值 20080623
            
//            M2Share.Config.WriteInteger("Setup", "MakeWineTime", M2Share.g_Config.nMakeWineTime);
//            // 酿普通酒等待时间 20080621
            
//            M2Share.Config.WriteInteger("Setup", "MakeWineTime1", M2Share.g_Config.nMakeWineTime1);
//            // 酿药酒等待时间 20080621
            
//            M2Share.Config.WriteInteger("Setup", "MakeWineRate", M2Share.g_Config.nMakeWineRate);
//            // 酿酒获得酒曲机率 20080621
            
//            M2Share.Config.WriteInteger("Setup", "IncAlcoholTick", M2Share.g_Config.nIncAlcoholTick);
//            // 增加酒量进度的间隔时间 20080623
            
//            M2Share.Config.WriteInteger("Setup", "DesDrinkTick", M2Share.g_Config.nDesDrinkTick);
//            // 减少醉酒度的间隔时间 20080623
            
//            M2Share.Config.WriteInteger("Setup", "MaxAlcoholValue", M2Share.g_Config.nMaxAlcoholValue);
//            // 酒量上限初始值 20080623
            
//            M2Share.Config.WriteInteger("Setup", "IncAlcoholValue", M2Share.g_Config.nIncAlcoholValue);
//            // 升级后增加酒量上限值 20080623
//            uModValue();
//        }

//        // 增加酒量进度的间隔时间 20080623
//        public void SpinEditIncAlcoholTickChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nIncAlcoholTick = SpinEditIncAlcoholTick.Value;
//            ModValue();
//        }

//        // 减少醉酒度的间隔时间 20080623
//        public void SpinEditDesDrinkTickChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nDesDrinkTick = SpinEditDesDrinkTick.Value;
//            ModValue();
//        }

//        // 酒量上限初始值 20080623
//        public void SpinEditMaxAlcoholValueChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMaxAlcoholValue = SpinEditMaxAlcoholValue.Value;
//            ModValue();
//        }

//        // 升级后增加酒量上限值 20080623
//        public void SpinEditIncAlcoholValueChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nIncAlcoholValue = SpinEditIncAlcoholValue.Value;
//            ModValue();
//        }

//        public void GridMedicineExpEnter(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            ModValue();
//        }

//        // 长时间不使用酒,减药力值 20080623
//        public void SpinEditDesMedicineValueChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nDesMedicineValue = SpinEditDesMedicineValue.Value;
//            ModValue();
//        }

//        // 减药力值时间间隔 20080624
//        public void SpinEditDesMedicineTickChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nDesMedicineTick = SpinEditDesMedicineTick.Value;
//            ModValue();
//        }

//        // 站在泉眼上的累积时间(秒) 20080624
//        public void SpinEditInFountainTimeChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nInFountainTime = SpinEditInFountainTime.Value;
//            ModValue();
//        }

//        // 酒气护体使用间隔 20080625
//        public void SpinEditHPUpTickChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHPUpTick = SpinEditHPUpTick.Value;
//            ModValue();
//        }

//        // 酒气护体增加使用时长 20080625
//        public void SpinEditHPUpUseTimeChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHPUpUseTime = SpinEditHPUpUseTime.Value;
//            ModValue();
//        }

//        public void GridSkill68Enter(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            ModValue();
//        }

//        // 先天元力失效酒量下限比例 20080626
//        public void SpinEditMinDrinkValue67Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMinDrinkValue67 = SpinEditMinDrinkValue67.Value;
//            ModValue();
//        }

//        // 酒气护体失效酒量下限比例 20080626
//        public void SpinEditMinDrinkValue68Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMinDrinkValue68 = SpinEditMinDrinkValue68.Value;
//            ModValue();
//        }

//        // 行会酒泉蓄量少于时,不能领取 20080627
//        public void SpinEditMinGuildFountainChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMinGuildFountain = SpinEditMinGuildFountain.Value;
//            ModValue();
//        }

//        // 行会成员领取酒泉,蓄量减少 20080627
//        public void SpinEditDecGuildFountainChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nDecGuildFountain = SpinEditDecGuildFountain.Value;
//            ModValue();
//        }

//        // 挑战时间 20080706
//        public void SpinEditChallengeTimeChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nChallengeTime = SpinEditChallengeTime.Value;
//            ModValue();
//        }

//        // 宝宝是否飞到主人身边 20080713
//        public void CheckSlaveMoveMasterClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boSlaveMoveMaster = CheckSlaveMoveMaster.Checked;
//            ModValue();
//        }

//        // 人物名是否显示行会信息  20080726
//        public void CheckBoxShowGuildNameClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boShowGuildName = CheckBoxShowGuildName.Checked;
//            ModValue();
//        }

//        // --------------------------气血石配置------------------------------
//        public void SpinEditStartHPRockChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nStartHPRock = SpinEditStartHPRock.Value;
//            ModValue();
//        }

//        public void SpinEditHPRockSpellChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHPRockSpell = SpinEditHPRockSpell.Value;
//            ModValue();
//        }

//        public void SpinEditRockAddHPChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nRockAddHP = SpinEditRockAddHP.Value;
//            ModValue();
//        }

//        public void SpinEditHPRockDecDuraChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHPRockDecDura = SpinEditHPRockDecDura.Value;
//            ModValue();
//        }

//        public void SpinEditStartMPRockChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nStartMPRock = SpinEditStartMPRock.Value;
//            ModValue();
//        }

//        public void SpinEditMPRockSpellChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMPRockSpell = SpinEditMPRockSpell.Value;
//            ModValue();
//        }

//        public void SpinEditRockAddMPChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nRockAddMP = SpinEditRockAddMP.Value;
//            ModValue();
//        }

//        public void SpinEditMPRockDecDuraChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nMPRockDecDura = SpinEditMPRockDecDura.Value;
//            ModValue();
//        }

//        public void SpinEditStartHPMPRockChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nStartHPMPRock = SpinEditStartHPMPRock.Value;
//            ModValue();
//        }

//        public void SpinEditHPMPRockSpellChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHPMPRockSpell = SpinEditHPMPRockSpell.Value;
//            ModValue();
//        }

//        public void SpinEditRockAddHPMPChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nRockAddHPMP = SpinEditRockAddHPMP.Value;
//            ModValue();
//        }

//        public void SpinEditHPMPRockDecDuraChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHPMPRockDecDura = SpinEditHPMPRockDecDura.Value;
//            ModValue();
//        }

//        public void RadioboSkill31EffectFalseClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boSkill31Effect = !RadioboSkill31EffectFalse.Checked;
//            ModValue();
//        }

//        public void RadioboSkill31EffectTrueClick(object sender, EventArgs e)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boSkill31Effect = RadioboSkill31EffectTrue.Checked;
//            ModValue();
//        }

//        public void SpinEditSkill66RateChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nSkill66Rate = SpinEditSkill66Rate.Value;
//            ModValue();
//        }

//        public void EditProtectionOKRateChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nProtectionOKRate = EditProtectionOKRate.Value;
//            ModValue();
//        }

//        public void SpinEditSkill69NGChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nSkill69NG = SpinEditSkill69NG.Value;
//            ModValue();
//        }

//        public void SpinEditSkill69NGExpChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nSkill69NGExp = SpinEditSkill69NGExp.Value;
//            ModValue();
//        }

//        public void SpinEditHeroSkill69NGExpChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHeroSkill69NGExp = SpinEditHeroSkill69NGExp.Value;
//            ModValue();
//        }

//        public void SpinEditdwIncNHTimeChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.dwIncNHTime = SpinEditdwIncNHTime.Value * 1000;
//            ModValue();
//        }

//        public void SpinEditDrinkIncNHExpChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nDrinkIncNHExp = SpinEditDrinkIncNHExp.Value;
//            ModValue();
//        }

//        public void SpinEditHitStruckDecNHChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHitStruckDecNH = SpinEditHitStruckDecNH.Value;
//            ModValue();
//        }

//        // 无极真气使用固定时长 20081109
//        public void SpinEditAbilityUpFixUseTimeChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nAbilityUpFixUseTime = SpinEditAbilityUpFixUseTime.Value;
//            ModValue();
//        }

//        public void CheckBoxAbilityUpFixModeClick(object sender, EventArgs e)
//        {
//            bool boStatus;
//            boStatus = CheckBoxAbilityUpFixMode.Checked;
//            SpinEditAbilityUpFixUseTime.Enabled = boStatus;
//            SpinEditAbilityUpUseTime.Enabled = !boStatus;
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.boAbilityUpFixMode = boStatus;
//            ModValue();
//        }

//        public void SpinEditAttackRate_26Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nAttackRate_26 = SpinEditAttackRate_26.Value;
//            ModValue();
//        }

        // 杀怪内功经验倍数
        public void EditKillMonNGExpMultipleChange(Object Sender)
        {
            if (EditKillMonNGExpMultiple.Text == "")
            {
                EditKillMonNGExpMultiple.Text = "0";
                return;
            }
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwKillMonNGExpMultiple = (ushort)EditKillMonNGExpMultiple.Value;
            ModValue();
        }

        // NPC名字颜色
        public void SpinEditNPCNameColorChange(object sender, EventArgs e)
        {
            byte btColor = (byte)SpinEditNPCNameColor.Value;
            LabelNPCNameColor.BackColor = M2Share.GetRGB(btColor);
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.btNPCNameColor = btColor;
            ModValue();
        }

        // 内功技能增强的攻防比率
        public void SpinEditNGSkillRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNGSkillRate = (ushort)SpinEditNGSkillRate.Value;
            ModValue();
        }

//        // 内功等级增加攻防的级数比率 20081223
//        public void SpinEditNGLevelDamageChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nNGLevelDamage = SpinEditNGLevelDamage.Value;
//            ModValue();
//        }

//        public void SpinEditOrdinarySkill66RateChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nOrdinarySkill66Rate = SpinEditOrdinarySkill66Rate.Value;
//            ModValue();
//        }

//        public void SpinEditFairyDuntRateBelowChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nFairyDuntRateBelow = SpinEditFairyDuntRateBelow.Value;
//            ModValue();
//        }

//        // Note: the original parameters are Object Sender, ref TCloseAction Action
//        public void FormClose(object sender, EventArgs e)
//        {
            
//            Action = caFree;
//        }

//        public void FormDestroy(Object Sender)
//        {
//            Units.FunctionConfig.frmFunctionConfig = null;
//        }

//        public void ButtonExpCrystalSaveClick(object sender, EventArgs e)
//        {
//            byte I;
//            uint dwExp;
//            uint dwExp1;
//            uint[] NeedExps;
//            uint[] NeedExps1;
            
//            for (I = 1; I < GridExpCrystalLevelExp.RowCount; I ++ )
//            {
                
//                dwExp = HUtil32.Str_ToInt(GridExpCrystalLevelExp.Cells[1, I], 0);
//                if ((dwExp <= 0))
//                {
//                    MessageBox.Show(("等级 " + (I).ToString() + " 经验值设置错误！！！" as string), "错误信息", MessageBoxButtons.OK);
//                    GridExpCrystalLevelExp.CurrentRowIndex = I;
//                    GridExpCrystalLevelExp.Focus();
//                    return;
//                }
                
//                dwExp1 = HUtil32.Str_ToInt(GridExpCrystalLevelExp.Cells[2, I], 0);
//                if ((dwExp1 <= 0))
//                {
//                    MessageBox.Show(("等级 " + (I).ToString() + " 内功经验值设置错误！！！" as string), "错误信息", MessageBoxButtons.OK);
//                    GridExpCrystalLevelExp.CurrentRowIndex = I;
//                    GridExpCrystalLevelExp.Focus();
//                    return;
//                }
//                NeedExps[I] = dwExp;
//                NeedExps1[I] = dwExp1;
//            }
//            M2Share.g_Config.dwExpCrystalNeedExps = NeedExps;
//            M2Share.g_Config.dwNGExpCrystalNeedExps = NeedExps1;
//            for (I = 1; I <= 4; I ++ )
//            {
                
//                M2Share.Config.WriteString("ExpCrystal", "Level" + (I).ToString(), (M2Share.g_Config.dwExpCrystalNeedExps[I]).ToString());
                
//                M2Share.Config.WriteString("NGExpCrystal", "Level" + (I).ToString(), (M2Share.g_Config.dwNGExpCrystalNeedExps[I]).ToString());
//            }
            
//            M2Share.Config.WriteInteger("Setup", "HeroCrystalExpRate", M2Share.g_Config.nHeroCrystalExpRate);
//            uModValue();
//        }

        public void GridExpCrystalLevelExpEnter(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

//        // 天地结晶英雄分配比例 20090202
//        public void EditHeroCrystalExpRateChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.nHeroCrystalExpRate = EditHeroCrystalExpRate.Value;
//            ModValue();
//        }

        // ----基本设置----//
        public void ButtonSaveBatterClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "StormsHitRate1", M2Share.g_Config.StormsHitRate1);
            M2Share.Config.WriteInteger("Setup", "StormsHitRate2", M2Share.g_Config.StormsHitRate2);
            M2Share.Config.WriteInteger("Setup", "StormsHitRate3", M2Share.g_Config.StormsHitRate3);
            M2Share.Config.WriteInteger("Setup", "StormsHitRate4", M2Share.g_Config.StormsHitRate4);
            M2Share.Config.WriteInteger("Setup", "StormsHitRate5", M2Share.g_Config.StormsHitRate5);
            M2Share.Config.WriteInteger("Setup", "StormsHitAppearRate0", M2Share.g_Config.StormsHitAppearRate0);
            M2Share.Config.WriteInteger("Setup", "StormsHitAppearRate1", M2Share.g_Config.StormsHitAppearRate1);
            M2Share.Config.WriteInteger("Setup", "StormsHitAppearRate2", M2Share.g_Config.StormsHitAppearRate2);
            M2Share.Config.WriteInteger("Setup", "StormsHitAppearRate3", M2Share.g_Config.StormsHitAppearRate3);
            M2Share.Config.WriteInteger("Setup", "StormsHitAppearRate4", M2Share.g_Config.StormsHitAppearRate4);
            M2Share.Config.WriteInteger("Setup", "UseBatterTick", M2Share.g_Config.UseBatterTick);// ----经络相关----//
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel0", M2Share.g_Config.PulsePointNGLevel0);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel1", M2Share.g_Config.PulsePointNGLevel1);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel2", M2Share.g_Config.PulsePointNGLevel2);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel3", M2Share.g_Config.PulsePointNGLevel3);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel4", M2Share.g_Config.PulsePointNGLevel4);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel5", M2Share.g_Config.PulsePointNGLevel5);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel6", M2Share.g_Config.PulsePointNGLevel6);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel7", M2Share.g_Config.PulsePointNGLevel7);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel8", M2Share.g_Config.PulsePointNGLevel8);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel9", M2Share.g_Config.PulsePointNGLevel9);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel10", M2Share.g_Config.PulsePointNGLevel10);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel11", M2Share.g_Config.PulsePointNGLevel11);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel12", M2Share.g_Config.PulsePointNGLevel12);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel13", M2Share.g_Config.PulsePointNGLevel13);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel14", M2Share.g_Config.PulsePointNGLevel14);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel15", M2Share.g_Config.PulsePointNGLevel15);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel16", M2Share.g_Config.PulsePointNGLevel16);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel17", M2Share.g_Config.PulsePointNGLevel17);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel18", M2Share.g_Config.PulsePointNGLevel18);
            M2Share.Config.WriteInteger("Setup", "PulsePointNGLevel19", M2Share.g_Config.PulsePointNGLevel19);// ----连击技能----//
            M2Share.Config.WriteInteger("Setup", "BatterSkillFireRange_82", M2Share.g_Config.BatterSkillFireRange_82);
            M2Share.Config.WriteInteger("Setup", "BatterSkillFireRange_85", M2Share.g_Config.BatterSkillFireRange_85);
            M2Share.Config.WriteInteger("Setup", "BatterSkillFireRange_86", M2Share.g_Config.BatterSkillFireRange_86);
            M2Share.Config.WriteInteger("Setup", "BatterSkillFireRange_87", M2Share.g_Config.BatterSkillFireRange_87);
            M2Share.Config.WriteInteger("Setup", "BatterSkillPoinson_86", M2Share.g_Config.BatterSkillPoinson_86);
            M2Share.Config.WriteInteger("Setup", "BatterSkillPoinson_87", M2Share.g_Config.BatterSkillPoinson_87);
            uModValue();
        }

//        public void SpinEdit1Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel0 = SpinEdit1.Value;
//            ModValue();
//        }

//        public void SpinEdit2Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel1 = SpinEdit2.Value;
//            ModValue();
//        }

//        public void SpinEdit3Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel2 = SpinEdit3.Value;
//            ModValue();
//        }

//        public void SpinEdit4Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel3 = SpinEdit4.Value;
//            ModValue();
//        }

//        public void SpinEdit5Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel4 = SpinEdit5.Value;
//            ModValue();
//        }

//        public void SpinEdit6Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel5 = SpinEdit6.Value;
//            ModValue();
//        }

//        public void SpinEdit7Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel6 = SpinEdit7.Value;
//            ModValue();
//        }

//        public void SpinEdit8Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel7 = SpinEdit8.Value;
//            ModValue();
//        }

//        public void SpinEdit9Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel8 = SpinEdit9.Value;
//            ModValue();
//        }

//        public void SpinEdit10Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel9 = SpinEdit10.Value;
//            ModValue();
//        }

//        public void SpinEdit11Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel10 = SpinEdit11.Value;
//            ModValue();
//        }

//        public void SpinEdit12Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel11 = SpinEdit12.Value;
//            ModValue();
//        }

//        public void SpinEdit13Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel12 = SpinEdit13.Value;
//            ModValue();
//        }

//        public void SpinEdit14Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel13 = SpinEdit14.Value;
//            ModValue();
//        }

//        public void SpinEdit15Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel14 = SpinEdit15.Value;
//            ModValue();
//        }

//        public void SpinEdit16Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel15 = SpinEdit16.Value;
//            ModValue();
//        }

//        public void SpinEdit17Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel16 = SpinEdit17.Value;
//            ModValue();
//        }

//        public void SpinEdit18Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel17 = SpinEdit18.Value;
//            ModValue();
//        }

//        public void SpinEdit19Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel18 = SpinEdit19.Value;
//            ModValue();
//        }

//        public void SpinEdit20Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.PulsePointNGLevel19 = SpinEdit20.Value;
//            ModValue();
//        }

//        public void SpinEdit21Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitAppearRate0 = SpinEdit21.Value;
//            ModValue();
//        }

//        public void SpinEdit22Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitAppearRate1 = SpinEdit22.Value;
//            ModValue();
//        }

//        public void SpinEdit23Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitAppearRate2 = SpinEdit23.Value;
//            ModValue();
//        }

//        public void SpinEdit24Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitAppearRate3 = SpinEdit24.Value;
//            ModValue();
//        }

//        public void SpinEdit25Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitAppearRate4 = SpinEdit25.Value;
//            ModValue();
//        }

//        public void SpinEdit26Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitRate1 = SpinEdit26.Value;
//            ModValue();
//        }

//        public void SpinEdit27Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitRate2 = SpinEdit27.Value;
//            ModValue();
//        }

//        public void SpinEdit28Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitRate3 = SpinEdit28.Value;
//            ModValue();
//        }

//        public void SpinEdit29Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitRate4 = SpinEdit29.Value;
//            ModValue();
//        }

//        public void SpinEdit30Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.StormsHitRate5 = SpinEdit30.Value;
//            ModValue();
//        }

//        public void SpinEdit31Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.UseBatterTick = SpinEdit31.Value * 1000;
//            ModValue();
//        }

//        public void SpinEdit33Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.BatterSkillFireRange_85 = SpinEdit33.Value;
//            ModValue();
//        }

//        public void SpinEdit34Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.BatterSkillFireRange_86 = SpinEdit34.Value;
//            ModValue();
//        }

//        public void SpinEdit35Change(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.BatterSkillFireRange_87 = SpinEdit35.Value;
//            ModValue();
//        }

//        public void YTPDTimeEditChange(Object Sender)
//        {
//            if (!boOpened)
//            {
//                return;
//            }
//            M2Share.g_Config.Magic69UseTime = YTPDTimeEdit.Value;
//            ModValue();
//        }

    }
}
