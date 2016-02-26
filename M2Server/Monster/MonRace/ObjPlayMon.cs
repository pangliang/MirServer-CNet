using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using GameFramework;
using GameFramework.Enum;

namespace M2Server
{
    /// <summary>
    /// 人形怪物 分身
    /// </summary>
    public class TPlayMonster: TBaseObject
    {
        public uint m_dwThinkTick = 0;
        public bool m_boDupMode = false;// 人物重叠了
        public int m_nTargetX = 0;
        public int m_nTargetY = 0;
        public bool m_boRunAwayMode = false;
        public uint m_dwRunAwayStart = 0;
        public uint m_dwRunAwayTime = 0;
        public bool m_boCanPickUpItem = false;
        public uint m_dwPickUpItemTick = 0;
        public ushort m_wHitMode = 0;
        public uint m_dwAutoAvoidTick = 0;// 自动躲避间隔
        public bool m_boAutoAvoid = false;// 是否躲避
        public bool m_boDoSpellMagic = false;// 是否可以使用魔法
        public uint m_dwDoSpellMagicTick = 0;// 使用魔法间隔
        public bool m_boGotoTargetXY = false;// 是否走向目标
        public uint m_SkillShieldTick = 0;// 魔法盾使用间隔
        public uint m_Skill_75_Tick = 0;// 护体神盾使用间隔 
        public uint m_SkillBigHealling = 0;// 群体治疗术使用间隔
        public uint m_SkillDejiwonho = 0;// 神圣战甲术使用间隔
        public uint m_dwCheckDoSpellMagic = 0;
        public int m_nDieDropUseItemRate = 0;// 死亡掉装备几率
        public bool m_boDropUseItem = false;// 是否掉装备
        public bool m_boButchUseItem = false;// 是否允许挖取身上装备
        public int m_nButchRate = 0;// 挖取身上装备机率
        public byte m_nButchChargeClass = 0;// 挖取身上装备收费模式(0金币，1元宝，2金刚石，3灵符)
        public int m_nButchChargeCount = 0;// 挖取身上装备每次收费点数
        public uint m_nButchItemTime = 0;// 挖物品间隔时间
        public ArrayList m_ButchItemList = null;// 人形怪挖物品列表
        public bool boIntoTrigger = false;// 人形怪挖是否进入触发
        public bool boIsDieEvent = false;// 清理人形尸体,是否显示升天龙效果(人物升级效果)
        public uint m_dwActionTick = 0;// 动作间隔
        public ushort wSkill_05 = 0;// 魔法盾
        public ushort wSkill_66 = 0;// 四级魔法盾
        public ushort wSkill_01 = 0;// 雷电术
        public ushort wSkill_02 = 0;// 地狱雷光
        public ushort wSkill_03 = 0;// 冰咆哮
        public ushort wSKILL_58 = 0;// 流星火雨
        public ushort wSKILL_36 = 0;// 火焰冰
        public ushort wSKILL_45 = 0;// 灭天火
        public ushort wSkill_04 = 0;// 火龙焰
        public ushort wSkill_06 = 0;// 施毒术
        public ushort wSkill_07 = 0;// 灵魂火符
        public ushort wSKILL_59 = 0;// 噬血术
        public ushort wSkill_14 = 0;// 幽灵盾
        public ushort wSkill_73 = 0;// 道力盾
        public ushort wSkill_50 = 0;// 无极真气
        public ushort wSkill_08 = 0;// 神圣战甲术
        public ushort wSkill_09 = 0;// 群体治疗术
        public ushort wSkill_10 = 0;// 群体施毒术
        public ushort wSkill_48 = 0;// 气功波
        public ushort wSkill_51 = 0;// 飓风破
        public ushort wSkill_11 = 0;// 烈火剑法
        public ushort wSkill_12 = 0;// 刺杀剑法
        public ushort wSkill_13 = 0;// 半月弯刀
        public ushort wSkill_27 = 0;// 野蛮冲撞
        public ushort wSKILL_40 = 0;// 抱月刀法
        public ushort wSKILL_42 = 0;// 开天斩
        public ushort wSKILL_43 = 0;// 龙影剑法
        public ushort wSKILL_74 = 0;// 逐日剑法
        public ushort wSkill_75 = 0;// 护体神盾
        public uint m_nSkill_5Tick = 0;// 无极真气使用间隔
        public uint m_nSkill_48Tick = 0;// 气功波使用间隔
        public uint dwRockAddHPTick = 0;// 魔血石类HP 使用间隔
        public uint dwRockAddMPTick = 0;// 魔血石类MP 使用间隔
        public uint m_dwDoMotaeboTick = 0;// 野蛮冲撞间隔
        public int m_nSelectMagic = 0;// 魔法
        /// <summary>
        /// 守护模式
        /// </summary>
        public bool m_boProtectStatus = false;
        public int m_nProtectTargetX = 0;
        public int m_nProtectTargetY = 0;// 守护坐标
        public bool m_boProtectOK = false;// 到达守护坐标
        public int m_nGotoProtectXYCount = 0;

        public TPlayMonster() : base()
        {
            m_boDupMode = false;
            m_nSkill_5Tick = HUtil32.GetTickCount();// 无极真气使用间隔
            m_nSkill_48Tick = HUtil32.GetTickCount();// 气功波使用间隔
            m_dwThinkTick = HUtil32.GetTickCount();
            this.m_nViewRange = 10;
            this.m_nRunTime = 250;
            this.m_dwSearchTick = HUtil32.GetTickCount();
            this.m_btRaceServer = Grobal2.RC_PLAYMOSTER;
            this.m_nCopyHumanLevel = 2;
            m_nTargetX =  -1;
            this.dwTick3F4 = HUtil32.GetTickCount();
            this.m_dwHitTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_dwWalkTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_nWalkSpeed = 500;
            this.m_nWalkStep = 10;
            this.m_dwWalkWait = 0;
            this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
            m_boRunAwayMode = false;
            m_dwRunAwayStart = HUtil32.GetTickCount();
            m_dwRunAwayTime = 0;
            m_boCanPickUpItem = true;
            m_dwPickUpItemTick = HUtil32.GetTickCount();
            m_dwAutoAvoidTick = HUtil32.GetTickCount();// 自动躲避间隔
            m_boAutoAvoid = false;// 是否躲避
            m_boDoSpellMagic = true;// 是否使用魔法
            m_boGotoTargetXY = true;// 是否走向目标
            this.m_nNextHitTime = 300;
            m_dwDoSpellMagicTick = HUtil32.GetTickCount();// 使用魔法间隔
            m_SkillShieldTick = HUtil32.GetTickCount();// 魔法盾使用魔法间隔
            m_Skill_75_Tick = HUtil32.GetTickCount();// 护体神盾使用魔法间隔
            m_SkillBigHealling = HUtil32.GetTickCount();// 群体治疗术使用间隔
            m_SkillDejiwonho = HUtil32.GetTickCount();// 神圣战甲术使用间隔
            m_dwCheckDoSpellMagic = HUtil32.GetTickCount();
            m_nDieDropUseItemRate = 100;
            m_nButchItemTime = HUtil32.GetTickCount();// 挖物品间隔时间
            m_ButchItemList = new ArrayList();// 人形怪挖物品列表
            m_dwDoMotaeboTick = HUtil32.GetTickCount();// 野蛮冲撞使用间隔
            m_boProtectStatus = false;// 守护模式
            m_boProtectOK = true;// 到达守护坐标
            m_nGotoProtectXYCount = 0;// 是向守护坐标的累计数
        }
        
        ~TPlayMonster()
        {
            int I;
            if (m_ButchItemList.Count > 0)
            {
                for (I = 0; I < m_ButchItemList.Count; I ++ )// 人形怪挖物品列表
                {
                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                    {
                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                    }
                }
            }
            m_ButchItemList = null;
        }

        public void InitializeMonster()
        {
            AddItemsFromConfig();
            switch (this.m_btJob)
            {
                case 0:
                    wSkill_11 = (ushort)CheckUserMagic(MagicConst.SKILL_FIRESWORD);// 烈火剑法
                    wSkill_12 = (ushort)CheckUserMagic(MagicConst.SKILL_ERGUM);// 刺杀剑法
                    wSkill_13 = (ushort)CheckUserMagic(MagicConst.SKILL_BANWOL);// 半月弯刀
                    wSkill_27 = (ushort)CheckUserMagic(MagicConst.SKILL_MOOTEBO);// 野蛮冲撞
                    wSKILL_40 = (ushort)CheckUserMagic(MagicConst.SKILL_40);// 抱月刀法
                    wSKILL_42 = (ushort)CheckUserMagic(MagicConst.SKILL_42);// 开天斩
                    wSKILL_43 = (ushort)CheckUserMagic(MagicConst.SKILL_43);// 龙影剑法
                    wSKILL_74 = (ushort)CheckUserMagic(MagicConst.SKILL_74);// 逐日剑法
                    wSkill_75 = (ushort)CheckUserMagic(MagicConst.SKILL_75);
                    break;
                case 1:// 护体神盾
                    wSkill_01 = (ushort)CheckUserMagic(MagicConst.SKILL_LIGHTENING);// 雷电术
                    wSkill_02 = (ushort)CheckUserMagic(MagicConst.SKILL_LIGHTFLOWER);// 地狱雷光
                    wSkill_03 = (ushort)CheckUserMagic(MagicConst.SKILL_SNOWWIND);// 冰咆哮
                    wSkill_04 = (ushort)CheckUserMagic(MagicConst.SKILL_47);// 火龙焰
                    wSkill_05 = (ushort)CheckUserMagic(MagicConst.SKILL_SHIELD);// 魔法盾
                    wSkill_66 = (ushort)CheckUserMagic(MagicConst.SKILL_66);// 四级魔法盾
                    wSKILL_58 = (ushort)CheckUserMagic(MagicConst.SKILL_58);// 流星火雨
                    wSKILL_36 = (ushort)CheckUserMagic(MagicConst.SKILL_MABE);// 火焰冰
                    wSKILL_45 = (ushort)CheckUserMagic(MagicConst.SKILL_45);// 灭天火
                    wSkill_75 = (ushort)CheckUserMagic(MagicConst.SKILL_75);// 护体神盾
                    if ((wSkill_01 == 0) && (wSkill_02 == 0) && (wSkill_03 == 0) && (wSkill_04 == 0))
                    {
                        m_boDoSpellMagic = false;
                    }
                    break;
                case 2:
                    wSkill_06 = (ushort)CheckUserMagic(MagicConst.SKILL_AMYOUNSUL);// 施毒术
                    wSkill_07 = (ushort)CheckUserMagic(MagicConst.SKILL_FIRECHARM);// 灵魂火符
                    wSKILL_59 = (ushort)CheckUserMagic(MagicConst.SKILL_59);// 噬血术
                    wSkill_14 = (ushort)CheckUserMagic(MagicConst.SKILL_HANGMAJINBUB);// 幽灵盾
                    wSkill_73 = (ushort)CheckUserMagic(MagicConst.SKILL_73);// 道力盾
                    wSkill_50 = (ushort)CheckUserMagic(MagicConst.SKILL_50);// 无极真气
                    wSkill_08 = (ushort)CheckUserMagic(MagicConst.SKILL_DEJIWONHO);// 神圣战甲术
                    wSkill_09 = (ushort)CheckUserMagic(MagicConst.SKILL_BIGHEALLING);// 群体治疗术
                    wSkill_10 = (ushort)CheckUserMagic(MagicConst.SKILL_GROUPAMYOUNSUL);// 群体施毒术
                    wSkill_75 = (ushort)CheckUserMagic(MagicConst.SKILL_75);// 护体神盾
                    wSkill_48 = (ushort)CheckUserMagic(MagicConst.SKILL_48);// 气功波
                    wSkill_51 = (ushort)CheckUserMagic(MagicConst.SKILL_51);// 飓风破
                    if ((wSkill_06 == 0) && (wSkill_07 == 0) && (wSkill_10 == 0))
                    {
                        m_boDoSpellMagic = false;
                    }
                    break;
            }
        }

        public virtual void GotoTargetXY(int nTargetX, int nTargetY)
        {
            int I;
            byte nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            if (((this.m_nCurrX != nTargetX) || (this.m_nCurrY != nTargetY)))
            {
                n10 = nTargetX;
                n14 = nTargetY;
                
                this.dwTick3F4 = HUtil32.GetTickCount();
                nDir = Grobal2.DR_DOWN;
                if (n10 > this.m_nCurrX)
                {
                    nDir = Grobal2.DR_RIGHT;
                    if (n14 > this.m_nCurrY)
                    {
                        nDir = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        nDir = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n10 < this.m_nCurrX)
                    {
                        nDir = Grobal2.DR_LEFT;
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNLEFT;
                        }
                        if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                    }
                    else
                    {
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWN;
                        }
                        else if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UP;
                        }
                    }
                }
                nOldX = this.m_nCurrX;
                nOldY = this.m_nCurrY;
                if ((Math.Abs(this.m_nCurrX - nTargetX) >= 3) || (Math.Abs(this.m_nCurrY - nTargetY) >= 3))
                {
                    if (!this.RunTo(nDir, false, nTargetX, nTargetY))
                    {
                        this.WalkTo(nDir, false);
                        n20 = HUtil32.Random(3);
                        for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I ++ )
                        {
                            if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                            {
                                if (n20 != 0)
                                {
                                    nDir ++;
                                }
                                else if (nDir > 0)
                                {
                                    nDir -= 1;
                                }
                                else
                                {
                                    nDir = Grobal2.DR_UPLEFT;
                                }
                                if ((nDir > Grobal2.DR_UPLEFT))
                                {
                                    nDir = Grobal2.DR_UP;
                                }
                                this.WalkTo(nDir, false);
                            }
                        }
                    }
                }
                else
                {
                    this.WalkTo(nDir, false);
                    n20 = HUtil32.Random(3);
                    for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I ++ )
                    {
                        if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                        {
                            if (n20 != 0)
                            {
                                nDir ++;
                            }
                            else if (nDir > 0)
                            {
                                nDir -= 1;
                            }
                            else
                            {
                                nDir = Grobal2.DR_UPLEFT;
                            }
                            if ((nDir > Grobal2.DR_UPLEFT))
                            {
                                nDir = Grobal2.DR_UP;
                            }
                            this.WalkTo(nDir, false);
                        }
                    }
                }
            }
        }
       
        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            try {
                result = false;
                if (ProcessMsg.wIdent == Grobal2.RM_STRUCK)
                {
                    TBaseObject TBase = GetObject<TBaseObject>(ProcessMsg.nParam3);
                    if ((TBase == this) && (TBase != null))
                    {
                        this.SetLastHiter(TBase);
                        Struck(TBase);
                        this.BreakHolySeizeMode();// 主体打自己分身不变色,打英雄分身也不变色
                        if ((this.m_Master != null) && (TBase != this.m_Master) && ((TBase.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            || (TBase.m_btRaceServer == Grobal2.RC_HEROOBJECT)))
                        {
                            if (this.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                this.m_Master.SetPKFlag(TBase);
                            }
                            if (this.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                if ((this.m_Master.m_Master != null))
                                {
                                    if (TBase != this.m_Master.m_Master)
                                    {
                                        this.m_Master.SetPKFlag(TBase);
                                    }
                                }
                                else
                                {
                                    this.m_Master.SetPKFlag(TBase);
                                }
                            }
                        }
                        if (M2Share.g_Config.boMonSayMsg)
                        {
                            this.MonsterSayMsg((TBase), TMonStatus.s_UnderFire);
                        }
                    }
                    result = true;
                }
                else
                {
                    result = base.Operate(ProcessMsg);
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TPlayMonster.Operate");
            }
            return result;
        }

        /// <summary>
        /// 被攻击
        /// </summary>
        /// <param name="hiter"></param>
        public  virtual void Struck(TBaseObject hiter)
        {
            byte btDir = 0;
            this.m_dwStruckTick = HUtil32.GetTickCount();
            if (hiter != null)
            {
                if ((this.m_TargetCret == null) || this.GetAttackDir(this.m_TargetCret, ref btDir) || (HUtil32.Random(6) == 0))
                {
                    if (this.IsProperTarget(hiter))
                    {
                        this.SetTargetCreat(hiter);
                    }
                }
            }
            if (this.m_boAnimal)//是动物
            {
                this.m_nMeatQuality = this.m_nMeatQuality - HUtil32.Random(300);
                if (this.m_nMeatQuality < 0)
                {
                    this.m_nMeatQuality = 0;
                }
            }
            this.m_dwHitTick = Convert.ToUInt32(this.m_dwHitTick + ((uint)150 - HUtil32._MIN(130, this.m_Abil.Level * 4)));
        }

        /// <summary>
        /// 攻击目标
        /// </summary>
        /// <param name="TargeTBaseObject"></param>
        /// <param name="nDir"></param>
        public virtual void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            base.AttackDir(TargeTBaseObject, m_wHitMode, nDir);
        }

        public override void DelTargetCreat()
        {
            base.DelTargetCreat();
            m_nTargetX =  -1;
            m_nTargetY =  -1;
        }

        public  void SearchTarget()
        {
            TBaseObject BaseObject;
            TBaseObject BaseObject18;
            int I;
            int nC;
            int n10;
            if (m_boProtectStatus)// 守护状态
            {
                if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 12) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 12) || !m_boProtectOK) // 增加，没有跑到守护点不查找目标
                {
                    return;
                }
            }
            BaseObject18 = null;
            n10 = 12;// 人形怪的探索范围
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I ++ )
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)  // 目标为英雄,且等级不超过22级,跟随状态,则不攻击英雄
                        {
                            if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (BaseObject.m_Abil.Level <= 22) && (((THeroObject)(BaseObject)).m_btStatus == 1))
                            {
                                continue;
                            }
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    n10 = nC;
                                    if (m_boProtectStatus)// 守护状态
                                    {
                                        if ((Math.Abs(BaseObject.m_nCurrX - m_nProtectTargetX) <= 13) || (Math.Abs(BaseObject.m_nCurrY - m_nProtectTargetY) <= 13))
                                        {
                                            BaseObject18 = BaseObject;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        BaseObject18 = BaseObject;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (BaseObject18 != null)
            {
                if (m_boProtectStatus)// 守护状态
                {
                    if ((Math.Abs(BaseObject18.m_nCurrX - m_nProtectTargetX) > 11) || (Math.Abs(BaseObject18.m_nCurrY - m_nProtectTargetY) > 11))
                    {
                        GotoTargetXY(m_nProtectTargetX, m_nProtectTargetY);
                        return;
                    }
                }
                this.SetTargetCreat(BaseObject18);
            }
        }

        /// <summary>
        /// 设置攻击目标
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        public virtual void SetTargetXY(int nX, int nY)
        {
            m_nTargetX = nX;
            m_nTargetY = nY;
        }

        public virtual void Wondering()
        {
            if ((HUtil32.Random(20) == 0))
            {
                if ((HUtil32.Random(4) == 1))
                {
                    this.TurnTo(HUtil32.Random(8));
                }
                else
                {
                    this.WalkTo(this.m_btDirection, false);
                }
            }
        }

        // 检查攻击的魔法
        private  bool CheckDoSpellMagic()
        {
            bool result;
            byte nCode;
            result = true;
            nCode = 0;
            try {
                if (this.m_btJob > 0)
                {
                    if (this.m_btJob == 1)
                    {
                        if ((wSkill_01 == 0) && (wSkill_02 == 0) && (wSkill_03 == 0) && (wSkill_04 == 0))
                        {
                            result = false;
                            return result;
                        }
                    }
                    if (this.m_btJob == 2)
                    {
                        if ((wSkill_06 == 0) && (wSkill_07 == 0) && (wSkill_10 == 0))
                        {
                            result = false;
                            return result;
                        }
                    }
                    if (this.m_WAbil.MP == 0)
                    {
                        result = false;
                        return result;
                    }
                    if (this.m_btJob == 2)
                    {
                        nCode = 1;
                        if ((wSkill_06 > 0) || (wSkill_10 > 0)) // 施毒术
                        {
                            nCode = 2;
                            if (((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1))) // 绿毒
                            {
                                nCode = 3;
                                result = CheckUserItemType(2, 1);
                                if (result)
                                {
                                    return result;
                                }
                                nCode = 4;
                                if (GetUserItemList(2, 1) < 0)
                                {
                                    result = false;
                                }
                                else
                                {
                                    result = true;
                                }
                                if (result)
                                {
                                    return result;
                                }
                            }
                            nCode = 5;
                            if (((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))  // 红毒
                            {
                                nCode = 6;
                                result = CheckUserItemType(2, 2);
                                if (result)
                                {
                                    return result;
                                }
                                nCode = 7;
                                if (GetUserItemList(2, 2) < 0)
                                {
                                    result = false;
                                }
                                else
                                {
                                    result = true;
                                }
                                if (result)
                                {
                                    return result;
                                }
                            }
                        }
                        if ((wSkill_07 > 0) || (wSKILL_59 > 0))// 灵魂火符  噬血术
                        {
                            nCode = 8;
                            result = CheckUserItemType(1, 0);
                            if (result)
                            {
                                return result;
                            }
                            nCode = 9;
                            if (GetUserItemList(1, 0) < 0)
                            {
                                result = false;
                            }
                            else
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TPlayMonster.CheckDoSpellMagic Code:" + (nCode).ToString());
            }
            return result;
        }

        private bool Think()
        {
            bool result;
            int nOldX;
            int nOldY;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if ((this.m_Master != null) && (this.m_Master.m_nCurrX == this.m_nCurrX) && (this.m_Master.m_nCurrY == this.m_nCurrY))
                {
                    m_boDupMode = true;
                }
                else if ((HUtil32.GetTickCount() - m_dwThinkTick) > 3000)// 3 * 1000
                {
                    m_dwThinkTick = HUtil32.GetTickCount();
                    nCode = 1;
                    if (this.m_PEnvir.GetXYObjCount(this.m_nCurrX, this.m_nCurrY) >= 2)
                    {
                        m_boDupMode = true;
                    }
                    if (!this.IsProperTarget(this.m_TargetCret))
                    {
                        this.m_TargetCret = null;
                    }
                }
                nCode = 2;
                if (SearchPickUpItemOK())// 捡物品
                {
                    SearchPickUpItem(500);
                }
                nCode = 3;
                EatMedicine();// 吃药
                nCode = 4;
                if ((HUtil32.GetTickCount() - m_dwCheckDoSpellMagic) > 1000)
                {
                    // 检测是否可以使用魔法
                    m_dwCheckDoSpellMagic = HUtil32.GetTickCount();
                    m_boDoSpellMagic = CheckDoSpellMagic();
                }
                nCode = 5;
                if (StartAutoAvoid() && m_boDoSpellMagic)
                {
                    AutoAvoid();
                }
                // 自动躲避
                nCode = 6;
                if (m_boDupMode)
                {
                    nOldX = this.m_nCurrX;
                    nOldY = this.m_nCurrY;
                    nCode = 7;
                    this.WalkTo((byte)HUtil32.Random(8), false);
                    if ((nOldX != this.m_nCurrX) || (nOldY != this.m_nCurrY))
                    {
                        m_boDupMode = false;
                        result = true;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TPlayMonster.Think Code:" + nCode);
            }
            return result;
        }

        // 自动躲避
        // 是否可以捡起物品
        private bool SearchPickUpItemOK()
        {
            bool result;
            TVisibleMapItem VisibleMapItem;
            TMapItem MapItem;
            int I;
            result = false;
            if ((this.m_VisibleItems.Count == 0) || (this.m_nCopyHumanLevel == 0))
            {
                return result;
            }
            if (this.m_Master == null)
            {
                return result;
            }
            if ((this.m_Master != null) && (this.m_Master.m_boDeath))
            {
                return result;
            }
            if (this.m_TargetCret != null)
            {
                if (this.m_TargetCret.m_boDeath)
                {
                    this.m_TargetCret = null;
                    result = true;
                }
            }
            // if (m_Master.m_WAbil.Weight >= m_Master.m_WAbil.MaxWeight) and (m_WAbil.Weight >= m_WAbil.MaxWeight) then Exit;
            if (this.m_TargetCret == null)
            {
                if (this.m_VisibleItems.Count > 0)
                {
                    // 20080630
                    for (I = 0; I < this.m_VisibleItems.Count; I ++ )
                    {
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        if ((VisibleMapItem != null))
                        {
                            if ((VisibleMapItem.nVisibleFlag > 0))
                            {
                                MapItem = VisibleMapItem.MapItem;
                                if ((MapItem != null))
                                {
                                    if ((MapItem.DropBaseObject != this.m_Master))
                                    {
                                        if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName))
                                        {
                                            // if (MapItem.DropBaseObject <> nil) and (TBaseObject(MapItem.DropBaseObject).m_btRaceServer = RC_PLAYOBJECT) then Continue;
                                            if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                            {
                                                result = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                // for
                }
            }
            if (result)
            {
                if ((this.m_ItemList.Count >= M2Share.g_Config.nCopyHumanBagCount) && !m_boCanPickUpItem)
                {
                    result = false;
                }
                if (m_boCanPickUpItem && (!((TPlayObject)(this.m_Master)).IsEnoughBag()) && (this.m_ItemList.Count >= M2Share.g_Config.nCopyHumanBagCount))
                {
                    result = true;
                }
            }
            return result;
        }

        // 自动躲避
        public int AutoAvoid_GetAvoidDir()
        {
            int result;
            int n10;
            int n14;
            n10 = this.m_TargetCret.m_nCurrX;
            n14 = this.m_TargetCret.m_nCurrY;
            result = Grobal2.DR_DOWN;
            if (n10 > this.m_nCurrX)
            {
                result = Grobal2.DR_LEFT;
                if (n14 > this.m_nCurrY)
                {
                    result = Grobal2.DR_DOWNLEFT;
                }
                if (n14 < this.m_nCurrY)
                {
                    result = Grobal2.DR_UPLEFT;
                }
            }
            else
            {
                if (n10 < this.m_nCurrX)
                {
                    result = Grobal2.DR_RIGHT;
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                    else if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                }
            }
            return result;
        }

        public byte AutoAvoid_GetDirXY(int nTargetX, int nTargetY)
        {
            byte result;
            int n10;
            int n14;
            n10 = nTargetX;
            n14 = nTargetY;
            result = Grobal2.DR_DOWN;
            if (n10 > this.m_nCurrX)
            {
                result = Grobal2.DR_RIGHT;
                if (n14 > this.m_nCurrY)
                {
                    result = Grobal2.DR_DOWNRIGHT;
                }
                if (n14 < this.m_nCurrY)
                {
                    result = Grobal2.DR_UPRIGHT;
                }
            }
            else
            {
                if (n10 < this.m_nCurrX)
                {
                    result = Grobal2.DR_LEFT;
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNLEFT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UPLEFT;
                    }
                }
                else
                {
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                    else if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                }
            }
            return result;
        }

        public bool AutoAvoid_GetGotoXY(int nDir, ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n01;
            result = false;
            n01 = 0;
            while (true)
            {
                switch(nDir)
                {
                    case Grobal2.DR_UP:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPRIGHT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_RIGHT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNRIGHT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY += 2;
                            n01 ++;
                            continue;
                        }
                    case Grobal2.DR_DOWN:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNLEFT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_LEFT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPLEFT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                }
            }
            return result;
        }

        public bool AutoAvoid_GetAvoidXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n10;
            int nDir;
            int nX;
            int nY;
            nX = nTargetX;
            nY = nTargetY;
            nDir = 0;
            result = AutoAvoid_GetGotoXY(this.m_btDirection, ref nTargetX, ref nTargetY);
            n10 = 0;
            while (true)
            {
                if (n10 >= 7)
                {
                    break;
                }
                if (result)
                {
                    break;
                }
                nTargetX = nX;
                nTargetY = nY;
                nDir = HUtil32.Random(7);
                result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                n10 ++;
            }
            this.m_btDirection = (byte)nDir;
            // m_btDirection;

            return result;
        }

        public bool AutoAvoid_GotoMasterXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int nDir;
            result = false;
            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 5) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 5)))
            {
                nTargetX = this.m_nCurrX;
                nTargetY = this.m_nCurrY;
                nDir = AutoAvoid_GetDirXY(this.m_Master.m_nCurrX, this.m_Master.m_nCurrY);
                this.m_btDirection = (byte)nDir;
                switch(nDir)
                {
                    case Grobal2.DR_UP:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UP;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_RIGHT;
                        }
                        break;
                    case Grobal2.DR_RIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_RIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWN;
                        }
                        break;
                    case Grobal2.DR_DOWN:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNLEFT;
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWN;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_LEFT;
                        }
                        break;
                    case Grobal2.DR_LEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNLEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_LEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UP;
                        }
                        break;
                }
            }
            return result;
        }

        // 自动吃药
        // ------------------------------------------------------------------------------
        // 更换原自动躲避的代码,应用英雄单元里的自动躲避代码进行修改
        private bool AutoAvoid()
        {
            bool result = true;
            int nTargetX = 0;
            int nTargetY = 0;
            byte nDir;
            if ((this.m_TargetCret != null) && !this.m_TargetCret.m_boDeath)
            {
                if (AutoAvoid_GotoMasterXY(ref nTargetX, ref nTargetY))
                {
                    GotoTargetXY(nTargetX, nTargetY);
                }
                else
                {
                    nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                    nDir = this.GetBackDir(nDir);
                    this.m_PEnvir.GetNextPosition(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, nDir, 5, ref m_nTargetX, ref m_nTargetY);
                    GotoTargetXY(m_nTargetX, m_nTargetY);
                }
            }
            return result;
        }

        public unsafe bool SearchPickUpItem_PickUpItem(TVisibleMapItem VisibleMapItem)
        {
            bool result;
            TUserItem* UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
            TStdItem* StdItem;
            TMapItem MapItem;
            result = false;
            MapItem = this.m_PEnvir.GetItem(VisibleMapItem.nX, VisibleMapItem.nY);
            if (MapItem == null)
            {
                return result;
            }
            if ((VisibleMapItem.sName).ToLower().CompareTo((M2Share.sSTRING_GOLDNAME).ToLower()) == 0)
            {
                // m_nCurrX, m_nCurrY
                if (this.m_PEnvir.DeleteFromMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                {
                    if ((this.m_Master != null) && (!this.m_Master.m_boDeath) && (this.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        // 捡到的钱加给主人
                        if (((TPlayObject)(this.m_Master)).IncGold(MapItem.Count))
                        {
                            //this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, VisibleMapItem.nX, VisibleMapItem.nY, "");
                            if (M2Share.g_boGameLogGold)
                            {
                                M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (VisibleMapItem.nX).ToString() + "\09" + (VisibleMapItem.nY).ToString() + "\09" + this.m_sCharName + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (MapItem.Count).ToString() + "\09" + "1" + "\09" + "0");
                            }
                            result = true;
                            this.m_Master.GoldChanged();
                            Dispose(MapItem);
                            //HUtil32.DisPoseAndNil(ref MapItem);
                        }
                        else
                        {
                            this.m_PEnvir.AddToMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                        }
                    }
                }
                return result;
            }
            else
            {
                if ((this.m_Master != null) && (!this.m_Master.m_boDeath)) // 捡物品
                {
                    // 捡到的物品加给主人
                    if (this.m_ItemList.Count < M2Share.g_Config.nCopyHumanBagCount)
                    {
                        // 捡到药品先给自己
                        StdItem = UserEngine.GetStdItem(MapItem.UserItem->wIndex);
                        if ((StdItem != null) && IsPickUpItem(StdItem))
                        {
                            if (this.m_PEnvir.DeleteFromMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                            {
                                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                for (int i = 0; i < 22; i++)
                                {
                                    UserItem->btValue[i] = 0;
                                }
                                UserItem = MapItem.UserItem;
                                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                if ((StdItem != null) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(UserItem->wIndex)))
                                {
                                    this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, Parse(MapItem), VisibleMapItem.nX, VisibleMapItem.nY, "");
                                    this.m_ItemList.Add((IntPtr)UserItem);
                                    if (StdItem->NeedIdentify == 1)
                                    {
                                        M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (VisibleMapItem.nX).ToString() + "\09" +
                                            (VisibleMapItem.nY).ToString() + "\09" + this.m_sCharName + "\09" + StdItem->ToString() + "\09" +
                                            UserItem->MakeIndex + "\09" + "(" + HUtil32.LoWord(StdItem->DC) + "/" + HUtil32.HiWord(StdItem->DC) + ")" +
                                            "(" + HUtil32.LoWord(StdItem->MC) + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + HUtil32.LoWord(StdItem->SC) +
                                            "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" + HUtil32.LoWord(StdItem->AC) + "/" + HUtil32.HiWord(StdItem->AC) + ")"
                                            + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + HUtil32.HiWord(StdItem->MAC) + ")" + UserItem->btValue[0] + "/"
                                            + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString() + "/"
                                            + (UserItem->btValue[4]).ToString() + "/" + UserItem->btValue[5] + "/" + (UserItem->btValue[6]).ToString() + "/" +
                                            (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString() + "\09" +
                                            (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                                    }
                                    result = true;
                                    Dispose(MapItem);
                                }
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                this.m_PEnvir.AddToMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                            }
                            return result;
                        }
                    }
                    if (((TPlayObject)(this.m_Master)).IsEnoughBag() && m_boCanPickUpItem)
                    {
                        // m_nCurrX, m_nCurrY
                        if (this.m_PEnvir.DeleteFromMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                        {
                            UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                            for (int i = 0; i < 22; i++)
                            {
                                UserItem->btValue[i] = 0;
                            }
                            UserItem = MapItem.UserItem;
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            if ((StdItem != null) && ((TPlayObject)(this.m_Master)).IsAddWeightAvailable(UserEngine.GetStdItemWeight(UserItem->wIndex)))
                            {
                                // m_nCurrX, m_nCurrY
                                //this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, VisibleMapItem.nX, VisibleMapItem.nY, "");
                                ((TPlayObject)(this.m_Master)).AddItemToBag(UserItem);
                                if (StdItem->NeedIdentify == 1)
                                {
                                    M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (VisibleMapItem.nX).ToString() + "\09" + (VisibleMapItem.nY).ToString() + "\09" +
                                        this.m_sCharName + " - " + this.m_Master.m_sCharName + "\09" + StdItem->ToString() + "\09" + UserItem->MakeIndex
                                        + "\09" + "(" +
                                        HUtil32.LoWord(StdItem->DC) + "/" + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC) + "/" +
                                        (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + HUtil32.LoWord(StdItem->SC) + "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" +
                                        HUtil32.LoWord(StdItem->AC) + "/" + HUtil32.HiWord(StdItem->AC) + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + HUtil32.HiWord(StdItem->MAC)
                                        + ")" + UserItem->btValue[0] + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" +
                                        (UserItem->btValue[3]).ToString() + "/" + (UserItem->btValue[4]).ToString() + "/" + UserItem->btValue[5] + "/" +
                                        (UserItem->btValue[6]).ToString() + "/" + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" +
                                        (UserItem->btValue[14]).ToString() + "\09" + (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                                }
                                result = true;
                                Dispose(MapItem);
                                //HUtil32.DisPoseAndNil(ref MapItem);
                                if (!this.m_Master.m_boDeath)
                                {
                                    if ((((TPlayObject)(this.m_Master)).m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                    {
                                        ((TPlayObject)(this.m_Master)).SendAddItem(UserItem);
                                    }
                                    else if (this.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this.m_Master)).SendAddItem(UserItem);
                                    }
                                }
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                this.m_PEnvir.AddToMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void SearchPickUpItem(uint dwSearchTime)
        {
            TMapItem MapItem;
            TVisibleMapItem VisibleMapItem;
            int I;
            byte nCode = 0;
            const string sExceptionMsg2 = "{异常} TPlayMonster::SearchItemRange 1-%d %s %s %d %d %d";
            try {
                nCode = 0;
                if (HUtil32.GetTickCount() - m_dwPickUpItemTick > dwSearchTime)
                {
                    m_dwPickUpItemTick = HUtil32.GetTickCount();
                    nCode = 1;
                    if (this.m_VisibleItems.Count > 0)
                    {
                        // 20080630
                        nCode = 2;
                        for (I = 0; I < this.m_VisibleItems.Count; I ++ )
                        {
                            VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                            nCode = 3;
                            if ((VisibleMapItem != null))
                            {
                                if ((VisibleMapItem.nVisibleFlag > 0))
                                {
                                    nCode = 4;
                                    MapItem = VisibleMapItem.MapItem;
                                    if ((MapItem != null))
                                    {
                                        if ((MapItem.DropBaseObject != this.m_Master))
                                        {
                                            nCode = 5;
                                            if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName))
                                            {
                                                nCode = 6;
                                                // if (MapItem.DropBaseObject <> nil) and (TBaseObject(MapItem.DropBaseObject).m_btRaceServer = RC_PLAYOBJECT) then Continue;
                                                // or IsOfGroup(TBaseObject(MapItem.OfBaseObject))
                                                if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                                {
                                                    // GotoTargetXY(VisibleMapItem.nX, VisibleMapItem.nY);
                                                    nCode = 7;
                                                    if (SearchPickUpItem_PickUpItem(VisibleMapItem))
                                                    {
                                                        // MainOutMessage('捡到物品');
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    // for
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TPlayMonster.SearchPickUpItem Code:" + (nCode).ToString());
            }
        }

        // 检查是否可以检起的物品
        // 是不是可以捡的药品
        private unsafe bool IsPickUpItem(TStdItem* StdItem)
        {
            bool result = false;
            if (StdItem->StdMode == 0)
            {
                if ((new ArrayList(new int[] { 0, 1, 2 }).Contains(StdItem->Shape)))
                {
                    result = true;
                }
            }
            else if (StdItem->StdMode == 31)
            {
                if (M2Share.GetBindItemType(StdItem->Shape) >= 0)
                {
                    result = true;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // 自动吃药
        public unsafe bool EatUseItems_EatItems(TStdItem* StdItem)
        {
            bool result = false;
            if (this.m_PEnvir.m_boNODRUG)
            {
                return result;
            }
            switch(StdItem->StdMode)
            {
                case 0:
                    switch(StdItem->Shape)
                    {
                        case 0:// 红药
                            if ((StdItem->AC > 0))
                            {
                                this.m_nIncHealth += StdItem->AC;
                                result = true;
                            }
                            if ((StdItem->MAC > 0))
                            {
                                
                                this.m_nIncSpell += StdItem->MAC;
                                result = true;
                            }
                            break;
                        case 1:// 蓝药
                            if ((StdItem->AC > 0) && (StdItem->MAC > 0))
                            {
                                this.IncHealthSpell(StdItem->AC, StdItem->MAC);
                                result = true;
                            }
                            break;
                    }
                    break;
            }
            return result;
        }

        public string EatUseItems_GetUnbindItemName(int nShape)
        {
            string result = string.Empty;
            if (M2Share.g_UnbindList.Count > 0)
            {
                for (int I = 0; I < M2Share.g_UnbindList.Count; I ++ )
                {
                    //if (((int)M2Share.g_UnbindList[I]) == nShape)
                    //{
                    //    result = M2Share.g_UnbindList[I];
                    //    break;
                    //}
                }
            }
            return result;
        }

        public unsafe bool EatUseItems_GetUnBindItems(string sItemName, int nCount)
        {
            bool result = false;
            TUserItem* UserItem = null;
            if (nCount <= 0)
            {
                nCount = 1;
            }
            for (int I = 0; I < nCount; I ++ )
            {
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (UserEngine.CopyToUserItemFromName(sItemName, UserItem))
                {
                    this.m_ItemList.Add((IntPtr)UserItem);
                    result = true;
                }
                else
                {
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    break;
                }
            }
            return result;
        }

        public unsafe bool EatUseItems_FoundUserItem(int nItemIdx)
        {
            bool result = false;
            TUserItem* UserItem;
            if (this.m_ItemList.Count > 0)
            {
                for (int I = 0; I < this.m_ItemList.Count; I ++ )
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem == null)
                    {
                        continue;
                    }
                    if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public unsafe int EatUseItems_FoundAddHealthItem(byte ItemType)
        {
            int result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = -1;
            if (this.m_ItemList.Count > 0)
            {
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem != null)
                    {
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if (StdItem != null)
                        {
                            switch (ItemType)
                            {
                                case 0:// 红药
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->AC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 1:// 蓝药
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->MAC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 2:// 太阳水
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 1) && (StdItem->AC > 0) && (StdItem->MAC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 3:// 红药包
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 4:// 蓝药包
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 1))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 5:// 大补药
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 2))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public unsafe bool EatUseItems_UseAddHealthItem(int nItemIdx)
        {
            bool result;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = false;
            UserItem = (TUserItem*)this.m_ItemList[nItemIdx];
            if (UserItem != null)
            {
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem != null)
                {
                    if (!this.m_PEnvir.AllowStdItems(UserItem->wIndex))
                    {
                        return result;
                    }
                    switch (StdItem->StdMode)// , 1, 2, 3
                    {
                        case 0:// 药
                            if (EatUseItems_EatItems(StdItem))
                            {
                                if (UserItem != null)
                                {
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                }
                                this.m_ItemList.RemoveAt(nItemIdx);
                                result = true;
                            }
                            break;
                        case 31:// 解包物品
                            if ((StdItem->AniCount == 0) && (M2Share.GetBindItemType(StdItem->Shape) >= 0))
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                this.m_ItemList.RemoveAt(nItemIdx);
                                EatUseItems_GetUnBindItems(EatUseItems_GetUnbindItemName(StdItem->Shape), 6);
                                result = true;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        // 道士攻击
        private bool EatUseItems(byte btItemType)
        {
            bool result;
            int nItemIdx;
            result = false;
            if (!this.m_boDeath)
            {
                nItemIdx = EatUseItems_FoundAddHealthItem(btItemType);
                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                {
                    result = EatUseItems_UseAddHealthItem(nItemIdx);
                }
                else
                {
                    switch(btItemType)
                    {
                        case 0:// 查找解包物品
                            nItemIdx = EatUseItems_FoundAddHealthItem(3);
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = EatUseItems_UseAddHealthItem(nItemIdx);
                            }
                            else
                            {
                                nItemIdx = EatUseItems_FoundAddHealthItem(2);
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = EatUseItems_UseAddHealthItem(nItemIdx);
                                }
                                else
                                {
                                    nItemIdx = EatUseItems_FoundAddHealthItem(5);
                                    if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                    {
                                        result = EatUseItems_UseAddHealthItem(nItemIdx);
                                    }
                                }
                            }
                            break;
                        case 1:
                            nItemIdx = EatUseItems_FoundAddHealthItem(4);
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = EatUseItems_UseAddHealthItem(nItemIdx);
                            }
                            else
                            {
                                nItemIdx = EatUseItems_FoundAddHealthItem(2);
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = EatUseItems_UseAddHealthItem(nItemIdx);
                                }
                                else
                                {
                                    nItemIdx = EatUseItems_FoundAddHealthItem(5);
                                    if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                    {
                                        result = EatUseItems_UseAddHealthItem(nItemIdx);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            return result;
        }

        private bool AllowGotoTargetXY()
        {
            bool result = true;
            if ((this.m_btJob == 0) || !m_boDoSpellMagic || (this.m_TargetCret == null))
            {
                return result;
            }
            result = false;
            return result;
        }

        // 烈火
        new public bool AllowFireHitSkill()
        {
            bool result;
            result = false;
            if ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 10000) // 10 * 1000
            {
                this.m_dwLatestFireHitTick = HUtil32.GetTickCount();
                this.m_boFireHitSkill = true;
                result = true;
            }
            return result;
        }

        // 逐日剑法
        public override bool AllowDailySkill()
        {
            bool result;
            result = false;
            if ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 10000) // 10 * 1000
            {
                this.m_dwLatestDailyTick = HUtil32.GetTickCount();
                this.m_boDailySkill = true;
                result = true;
            }
            return result;
        }

        // 是否需要躲避,除战士外
        private  bool StartAutoAvoid()
        {
            bool result;
            result = false;
            if (((HUtil32.GetTickCount() - m_dwAutoAvoidTick) > 3000) && m_boAutoAvoid) // 是否躲避
            {
                if (((this.m_btJob > 0) || (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.25))) && m_boDoSpellMagic && (this.m_TargetCret != null) && (!this.m_TargetCret.m_boDeath))
                {
                    m_dwAutoAvoidTick = HUtil32.GetTickCount();
                    switch(this.m_btJob)
                    {
                        case 1:
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0)
                            {
                                result = true;
                            }
                            break;
                        case 2:
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 3) > 0)
                            {
                                result = true;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        // 自动躲避状态
        // 是否走向目标 20080206
        private bool IsNeedGotoXY()
        {
            bool result;
            result = false;
            
            // 3 * 1000
            if ((this.m_TargetCret != null) && ((HUtil32.GetTickCount() - m_dwAutoAvoidTick) > 3000) && (!m_boDoSpellMagic || (this.m_btJob == 0)))
            {
                // 战士
                if (this.m_btJob > 0)
                {
                    if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                    {
                        result = true;
                    }
                }
                else
                {
                    switch(m_nSelectMagic)
                    {
                        case 12:
                            // 战 20081205
                            // 刺杀
                            m_nSelectMagic = 0;
                            if ((wSkill_12 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY)))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // 人物分身时的攻击速度

                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 4;
                                            // 刺杀
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // 为怪物时按DB设置的攻击速度
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 4;
                                            // 刺杀
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    // new
                                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 74:
                            // 12
                            // 逐日剑法
                            m_nSelectMagic = 0;
                            if ((wSKILL_74 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4))))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // 人物分身时的攻击速度
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 13;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // 为怪物时按DB设置的攻击速度
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 13;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    if ((wSkill_12 > 0))
                                    {
                                        if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                        {
                                            result = true;
                                            return result;
                                        }
                                    }
                                    else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 43:
                            // 74
                            // 实现隔位放开天
                            m_nSelectMagic = 0;
                            if ((wSKILL_42 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)) && (this.m_n42kill == 2))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 5)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 5) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 5))))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // 人物分身时的攻击速度
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {

                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // 为怪物时按DB设置的攻击速度
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    if ((wSkill_12 > 0))
                                    {
                                        if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                        {
                                            result = true;
                                            return result;
                                        }
                                    }
                                    else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSKILL_42 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY)) && (new ArrayList(new int[] {1, 2}).Contains(this.m_n42kill)))
                            {
                                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0) || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2) || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // 人物分身时的攻击速度
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // 为怪物时按DB设置的攻击速度
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 7:
                        case 25:
                        case 26:
                            // 43
                            m_nSelectMagic = 0;
                            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        default:
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 取技能消耗的MP值
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        private unsafe int GetSpellPoint(TUserMagic* UserMagic)
        {
            return (int)HUtil32.Round((double)UserMagic->MagicInfo.wSpell / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                + UserMagic->MagicInfo.btDefSpell;
        }

        /// <summary>
        /// 检查2次动作间隔
        /// </summary>
        /// <returns></returns>
        public bool DoSpellMagic_CheckActionStatus()
        {
            bool result = false;
            if (HUtil32.GetTickCount() - m_dwActionTick > 1000)
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
            }
            return result;
        }

        public unsafe int DoSpellMagic_DoSpell_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe ushort DoSpellMagic_DoSpell_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return Convert.ToUInt16(HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower
                  + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
        }

        public  int DoSpellMagic_DoSpell_GetPower13(TUserMagic UserMagic, int nInt)
        {
            int result;
            double d10;
            double d18;
            d10 = nInt / 3.0;
            d18 = nInt - d10;
            result = (int)HUtil32.Round(d18 / (UserMagic.MagicInfo.btTrainLv + 1) * (UserMagic.btLevel + 1) + d10 + (UserMagic.MagicInfo.btDefPower + HUtil32.Random(UserMagic.MagicInfo.btDefMaxPower - UserMagic.MagicInfo.btDefPower)));
            return result;
        }

        public unsafe void DoSpellMagic_DoSpell_DelUseItem()
        {
            if (this.m_UseItems[TPosition.U_BUJUK]->Dura < 100)
            {
                this.m_UseItems[TPosition.U_BUJUK]->Dura = 0;
                this.m_UseItems[TPosition.U_BUJUK]->wIndex = 0;
            }
        }

        public unsafe bool DoSpellMagic_DoSpell(TUserMagic* UserMagic, int wMagIdx, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            int nSpellPoint;
            bool boSpellFail;
            bool boSpellFire;
            int nPower = 0;
            int nAmuletIdx = 0;
            result = false;
            boSpellFail = false;
            boSpellFire = true;
            if ((Math.Abs(this.m_nCurrX - nTargetX) > M2Share.g_Config.nMagicAttackRage) || (Math.Abs(this.m_nCurrY - nTargetY) > M2Share.g_Config.nMagicAttackRage))
            {
                return result;
            }
            if (!DoSpellMagic_CheckActionStatus())
            {
                return result;
            }
            if (UserMagic->btLevel == 4)// 4级技能 灭天火,火符,魔法盾
            {
                if (wMagIdx == MagicConst.SKILL_45)
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, 101, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
                else if (wMagIdx == MagicConst.SKILL_FIRECHARM)
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, 100, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
                else if (wMagIdx == MagicConst.SKILL_66)
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
            }
            else
            {
                if (wMagIdx != MagicConst.SKILL_MOOTEBO)// 除了野蛮冲撞
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
            }
            if ((TargeTBaseObject != null) && (TargeTBaseObject.m_boDeath))
            {
                TargeTBaseObject = null;
            }
            switch(wMagIdx)
            {
                case MagicConst.SKILL_LIGHTENING:// 雷电术
                    nSpellPoint = GetSpellPoint(UserMagic);
                    if (nSpellPoint > 0)
                    {
                        if (this.m_WAbil.MP < nSpellPoint)
                        {
                            return result;
                        }
                        this.DamageSpell(nSpellPoint);
                    // HealthSpellChanged();
                    }
                    if (TargeTBaseObject != null)
                    {
                        if (this.IsProperTarget(TargeTBaseObject))
                        {
                            if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                            {
                                nPower = this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                                if (TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                                {
                                    nPower = (int)HUtil32.Round(nPower * 1.5);
                                }
                                //this.SendDelayMsg(this, Grobal2.RM_DELAYMAGIC, nPower, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                                result = true;
                            }
                            else
                            {
                                TargeTBaseObject = null;
                            }
                        }
                        else
                        {
                            TargeTBaseObject = null;
                        }
                    }
                    break;
                case MagicConst.SKILL_SHIELD:
                case MagicConst.SKILL_66:
                    // 31
                    // 66
                    // 魔法盾 四级魔法盾 20080728
                    if (this.MagBubbleDefenceUp(UserMagic->btLevel, DoSpellMagic_DoSpell_GetPower(UserMagic, Magic.GetRPow(this.m_WAbil.MC) + 15)))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_73:// 道力盾 
                    if (this.MagBubbleDefenceUp(UserMagic->btLevel, DoSpellMagic_DoSpell_GetPower(UserMagic,Magic.GetRPow(this.m_WAbil.SC) + 15)))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_75:// 护体神盾
                    if (HUtil32.GetTickCount() - this.m_boProtectionTick < M2Share.g_Config.dwProtectionTick)
                    {
                        return result;
                    }
                    // 护体神盾使用间隔 20080109
                    if (this.MagProtectionDefenceUp(UserMagic->btLevel))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_SNOWWIND:
                    // 33
                    // 冰咆哮
                    if (M2Share.MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic,DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, M2Share.g_Config.nSnowWindRange, MagicConst.SKILL_SNOWWIND))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_LIGHTFLOWER:
                    // 24
                    // 地狱雷光
                    if (M2Share.MagicManager.MagElecBlizzard(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1)))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_MOOTEBO:
                    // 27
                    // 野蛮冲撞
                    result = true;
                    boSpellFire = false;
                    if (this.GetAttackDir(TargeTBaseObject, ref this.m_btDirection))
                    {
                        // 野蛮冲撞的方向
                        nSpellPoint = GetSpellPoint(UserMagic);
                        if (this.m_WAbil.MP >= nSpellPoint)
                        {
                            if (nSpellPoint > 0)
                            {
                                this.DamageSpell(nSpellPoint);
                                this.HealthSpellChanged();
                            }
                            if (DoMotaebo(this.m_btDirection, UserMagic->btLevel))
                            {
                                if (UserMagic->btLevel < 3)
                                {
                                    if (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] < this.m_Abil.Level)
                                    {
                                        this.TrainSkill(UserMagic, HUtil32.Random(3) + 1);
                                        this.CheckMagicLevelup(UserMagic);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case MagicConst.SKILL_MABE:
                    // 火焰冰 
                    //nPower = this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + this.HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - this.HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                    if (MabMabe(this, TargeTBaseObject, nPower, UserMagic->btLevel, nTargetX, nTargetY))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_45:
                    // 灭天火 20080410
                    if (MagMakeFireDay(this, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_47:
                    // 火龙焰
                    if (M2Share.MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, M2Share.g_Config.nFireBoomRage, MagicConst.SKILL_47))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_58:
                    // 流星火雨 20080528
                    if (M2Share.MagicManager.MagBigExplosion1(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, M2Share.g_Config.nMeteorFireRainRage))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_AMYOUNSUL:
                    // 道士
                    // 6
                    // 施毒术
                    if (M2Share.MagicManager.MagLightening(this, UserMagic, nTargetX, nTargetY, TargeTBaseObject, ref boSpellFail))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_50:
                    // 无极真气 20080405
                    if (AbilityUp(UserMagic))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_51:
                    // 飓风破 20080917
                    if (M2Share.MagicManager.MagGroupFengPo(this, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_48:
                    // 气功波 20090111
                    if (M2Share.MagicManager.MagPushArround(this, UserMagic->btLevel) > 0)
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_FIRECHARM:
                case MagicConst.SKILL_HANGMAJINBUB:
                case MagicConst.SKILL_DEJIWONHO:
                case MagicConst.SKILL_59:
                    // 13
                    // 14
                    // 15
                    boSpellFail = true;
                    //if (Magic.CheckAmulet(this, 1, 1, ref nAmuletIdx))
                    //{
                    //    Magic.UseAmulet(this, 1, 1, ref nAmuletIdx);
                    //    switch(wMagIdx)
                    //    {
                    //        case MagicConst.SKILL_FIRECHARM:
                    //            // 13
                    //            // 灵魂火符
                    //            if (M2Share.MagicManager.MagMakeFireCharm(this, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //        case MagicConst.SKILL_HANGMAJINBUB:
                    //            // 幽灵盾
                    //            //nPower = this.GetAttackPower(UserMagic, DoSpellMagic_DoSpell_GetPower13(UserMagic,60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                    //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 1) > 0)
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //        case MagicConst.SKILL_DEJIWONHO:
                    //            // 神圣战甲术
                    //            //nPower = this.GetAttackPower(UserMagic, DoSpellMagic_DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                    //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 0) > 0)
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //        case MagicConst.SKILL_59:
                    //            // 噬血术 20080528
                    //            if (M2Share.MagicManager.MagFireCharmTreatment(this, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //    }
                    //    boSpellFail = false;
                    //    DoSpellMagic_DoSpell_DelUseItem();
                    //}
                    break;
                case MagicConst.SKILL_GROUPAMYOUNSUL:
                    // 38 群体施毒术
                    boSpellFail = true;
                    //if (Magic.CheckAmulet(this, 1, 2, ref nAmuletIdx))
                    //{
                    //    Magic.UseAmulet(this, 1, 2, ref nAmuletIdx);
                    //    if (M2Share.MagicManager.MagGroupAmyounsul(this, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                    //    {
                    //        result = true;
                    //    }
                    //    boSpellFail = false;
                    //    DoSpellMagic_DoSpell_DelUseItem();
                    //}
                    break;
                case MagicConst.SKILL_BIGHEALLING:
                    // 29
                    // 群体治疗术
                    nPower = this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.SC) * 2, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) * 2 + 1);
                    if (M2Share.MagicManager.MagBigHealing(this, nPower, nTargetX, nTargetY))
                    {
                        result = true;
                    }
                    break;
            }
            m_dwActionTick = HUtil32.GetTickCount();
            // 20080715
            this.m_dwHitTick = HUtil32.GetTickCount();
            // 20080715
            m_boAutoAvoid = true;
            // 是否能躲避 20080715
            if (boSpellFire)
            {
                if (UserMagic->btLevel == 4)
                {
                    // 4级技能 灭天火 火符 20080617
                    if (wMagIdx == MagicConst.SKILL_45)
                    {
                       // this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 101), MakeLong(nTargetX, nTargetY), (int)TargeTBaseObject, "");
                    }
                    else if (wMagIdx == MagicConst.SKILL_FIRECHARM)
                    {
                        //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 100), MakeLong(nTargetX, nTargetY), (int)TargeTBaseObject, "");
                    }
                }
                else
                {
                    //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), MakeLong(nTargetX, nTargetY), (int)TargeTBaseObject, "");
                }
            }
            return result;
        }

        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        private unsafe bool DoSpellMagic(ushort wMagIdx)
        {
            bool result = false;
            TBaseObject BaseObject;
            int I;
            int nSpellPoint;
            TUserMagic* UserMagic = null;
            int nNewTargetX;
            int nNewTargetY;
            try
            {
                switch (wMagIdx)
                {
                    case MagicConst.SKILL_ERGUM:// 刺杀剑法
                        if (this.m_MagicErgumSkill != null)
                        {
                            if (!this.m_boUseThrusting)
                            {
                                this.m_boUseThrusting = true;
                            }
                            else
                            {
                                this.m_boUseThrusting = false;
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_BANWOL:// 半月弯刀
                        if (this.m_MagicBanwolSkill != null)
                        {
                            if (!this.m_boUseHalfMoon)
                            {
                                this.m_boUseHalfMoon = true;
                            }
                            else
                            {
                                this.m_boUseHalfMoon = false;
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_FIRESWORD:// 烈火剑法
                        if (this.m_MagicFireSwordSkill != null)
                        {
                            if (AllowFireHitSkill())
                            {
                                nSpellPoint = GetSpellPoint(this.m_MagicFireSwordSkill);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        // HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_74:// //逐日剑法
                        if (this.m_Magic74Skill != null)
                        {
                            if (AllowDailySkill())
                            {
                                nSpellPoint = GetSpellPoint(this.m_Magic74Skill);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        // HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_42:// 开天斩
                        if (this.m_Magic42Skill != null)
                        {
                            if (this.Skill42OnOff())
                            {
                                nSpellPoint = GetSpellPoint(this.m_Magic42Skill);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_43:// 龙影剑法
                        if (this.m_Magic43Skill != null)
                        {
                            if (this.Skill43OnOff())
                            {
                                nSpellPoint = GetSpellPoint(UserMagic);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_40:// 抱月刀法
                        if (this.m_MagicCrsSkill != null)
                        {
                            if (!this.m_boCrsHitkill)
                            {
                                this.SkillCrsOnOff(true);
                            }
                            else
                            {
                                this.SkillCrsOnOff(false);
                            }
                        }
                        result = true;
                        return result;
                    default:
                        nNewTargetX = 0;
                        nNewTargetY = 0;
                        if (this.m_MagicList.Count > 0)
                        {
                            for (I = 0; I < this.m_MagicList.Count; I++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[I];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == wMagIdx))
                                {
                                    this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                    BaseObject = null;
                                    // 检查目标角色，与目标座标误差范围，如果在误差范围内则修正目标座标
                                    if (this.CretInNearXY(this.m_TargetCret, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY))
                                    {
                                        BaseObject = this.m_TargetCret;
                                        nNewTargetX = BaseObject.m_nCurrX;
                                        nNewTargetY = BaseObject.m_nCurrY;
                                    }
                                    if (new ArrayList(new int[] { MagicConst.SKILL_DEJIWONHO, MagicConst.SKILL_HANGMAJINBUB }).Contains(wMagIdx))
                                    {
                                        // 如果是 神圣战甲术,幽灵盾,则把目标设置为自己  20080610 原还注释
                                        BaseObject = this;
                                        nNewTargetX = this.m_nCurrX;
                                        nNewTargetY = this.m_nCurrY;
                                    }
                                    result = DoSpellMagic_DoSpell(UserMagic, wMagIdx, nNewTargetX, nNewTargetY, BaseObject);
                                    break;
                                }
                            }
                        }
                        break;
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 物理攻击
        /// </summary>
        /// <param name="wHitMode"></param>
        /// <returns></returns>
        private  bool WarrAttackTarget(ushort wHitMode)
        {
            bool result = false;
            byte bt06 = 0;
            if (this.m_TargetCret != null)
            {
                if ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (this.m_TargetCret.m_Abil.Level <= 22)
                    && (((THeroObject)(this.m_TargetCret)).m_btStatus == 1))// 英雄22级前,跟随时不打
                {
                    DelTargetCreat();
                    return result;
                }
                else if (m_boProtectStatus)  // 守护状态
                {
                    if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 13) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 13))
                    {
                        DelTargetCreat();
                        return result;
                    }
                }
                if (this.GetAttackDir(this.m_TargetCret, ref bt06))
                {
                    this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                    Attack(this.m_TargetCret, bt06);
                    this.BreakHolySeizeMode();
                    result = true;
                }
                else
                {
                    if ((this.m_TargetCret.m_PEnvir == this.m_PEnvir))
                    {
                        if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 12) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 12))
                        {
                            SetTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                        }
                    }
                    else
                    {
                        DelTargetCreat();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 吃药
        /// </summary>
        private  void EatMedicine()
        {
            int n01;
            if ((this.m_nCopyHumanLevel > 0) && (this.m_ItemList.Count > 0))
            {
                if (this.m_WAbil.HP < (this.m_WAbil.MaxHP * M2Share.g_Config.nCopyHumAddHPRate) / 100)
                {
                    n01 = 0;
                    while (this.m_WAbil.HP < this.m_WAbil.MaxHP)
                    {
                        if (n01 >= 2)// 增加连续吃三瓶
                        {
                            break;
                        }
                        EatUseItems(0);
                        if (this.m_ItemList.Count == 0)
                        {
                            break;
                        }
                        n01 ++;
                    }
                }
                if (this.m_WAbil.MP < (this.m_WAbil.MaxMP * M2Share.g_Config.nCopyHumAddMPRate) / 100)
                {
                    n01 = 0;
                    while (this.m_WAbil.MP < this.m_WAbil.MaxMP)
                    {
                        if (n01 >= 2)// 增加连续吃三瓶
                        {
                            break;
                        }
                        EatUseItems(1);
                        if (this.m_ItemList.Count == 0)
                        {
                            break;
                        }
                        n01 ++;
                    }
                }
                if ((this.m_ItemList.Count == 0) || (this.m_WAbil.HP < (this.m_WAbil.MaxHP * 20) / 100) || (this.m_WAbil.MP < (this.m_WAbil.MaxMP * 20) / 100))
                {
                    if (this.m_VisibleItems.Count > 0)
                    {
                        SearchPickUpItem(500);
                    }
                }
            }
        }

        // 查找魔法
        // 检测指定方向和范围内坐标的怪物数量
        private int CheckTargetXYCountOfDirection(int nX, int nY, int nDir, int nRange)
        {
            int result = 0;
            TBaseObject BaseObject;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I ++ )
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                switch(nDir)
                                {
                                    case Grobal2.DR_UP:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && (new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrY - nY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_UPRIGHT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrX - nX))) && (new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrY - nY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_RIGHT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrX - nX))) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNRIGHT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrX - nX))) && (new ArrayList(new int[] {0, nRange}).Contains((nY - BaseObject.m_nCurrY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWN:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && (new ArrayList(new int[] {0, nRange}).Contains((nY - BaseObject.m_nCurrY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNLEFT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((nX - BaseObject.m_nCurrX))) && (new ArrayList(new int[] {0, nRange}).Contains((nY - BaseObject.m_nCurrY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_LEFT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((nX - BaseObject.m_nCurrX))) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_UPLEFT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((nX - BaseObject.m_nCurrX))) && (new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrY - nY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                }
                                if (result > 2)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void WarrorAttackTarget_SelectMagic()
        {
            // 远距离则用开天重击或是逐日剑法 20081211
            // 2
            // 20090105 修改,等于或小于5
            // 2
            if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 5)) || ((Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 5)))
            {
                if ((wSKILL_42 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > M2Share.g_Config.nKill43UseTime * 1000))
                {
                    this.m_n42kill = 2;
                    // 重击
                    if (!this.m_bo42kill)
                    {
                        DoSpellMagic(MagicConst.SKILL_42);
                    }
                    // 打开开天
                    m_nSelectMagic = 43;
                    // 查询魔法 20081206
                    if (this.m_bo42kill)
                    {
                        return;
                    }
                }
                
                // 12 * 1000
                if ((wSKILL_74 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 12000))
                {
                    // 逐日剑法
                    if (!this.m_boDailySkill)
                    {
                        DoSpellMagic(MagicConst.SKILL_74);
                    }
                    // 打开逐日剑法
                    m_nSelectMagic = 74;
                    // 查询魔法 20081206
                    return;
                }
            }
            // 刺杀位 20081204
            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2))
            {
                if ((wSkill_12 > 0))
                {
                    // 刺杀剑术
                    if (!this.m_boUseThrusting)
                    {
                        DoSpellMagic(MagicConst.SKILL_ERGUM);
                    }
                    m_nSelectMagic = 12;
                    // 查询魔法 20081206
                    return;
                }
            }
            if ((wSKILL_42 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > M2Share.g_Config.nKill43UseTime * 1000))
            {
                // 开天斩  20080203
                if (HUtil32.Random(M2Share.g_Config.n43KillHitRate) == 0)
                {
                    // 增加 开天轻击 20080213
                    this.m_n42kill = 2;
                }
                else
                {
                    this.m_n42kill = 1;
                }
                if (!this.m_bo42kill)
                {
                    DoSpellMagic(MagicConst.SKILL_42);
                }
                // 打开开天
                m_nSelectMagic = 43;
                // 查询魔法 20081206
                if (this.m_bo42kill)
                {
                    return;
                }
            }
            if ((MagicConst.SKILL_43 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatest43Tick) > M2Share.g_Config.nKill42UseTime * 1000))
            {
                // 20080619 龙影剑法
                if (!this.m_bo43kill)
                {
                    DoSpellMagic(MagicConst.SKILL_43);
                }
                if (this.m_bo43kill)
                {
                    return;
                }
            }
            if (this.m_boFireHitSkill)
            {
                DoSpellMagic(MagicConst.SKILL_FIRESWORD);
            }
            // 关闭烈火
            if (this.m_boUseThrusting)
            {
                DoSpellMagic(MagicConst.SKILL_ERGUM);
            }
            // 关闭刺杀
            if (this.m_boUseHalfMoon)
            {
                DoSpellMagic(MagicConst.SKILL_BANWOL);
            }
            // 关闭半月
            if (this.m_boCrsHitkill)
            {
                DoSpellMagic(MagicConst.SKILL_40);
            }
            // 关闭刀法
            // if m_bo43kill then DoSpellMagic(SKILL_43);            //关闭龙影
            if (this.m_boDailySkill)
            {
                DoSpellMagic(MagicConst.SKILL_74);
            }
            // 关闭逐日剑法 20080528 20080619 注释
            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 2))
            {
                switch(HUtil32.Random(5))
                {
                    case 0:
                        // 目标近身时
                        if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // 打开刺杀
                            m_nSelectMagic = 12;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        break;
                    case 1:
                        // 抱月刀法
                        if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // 打开刺杀
                            m_nSelectMagic = 12;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // 抱月刀法
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        }
                        break;
                    case 2:
                        if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // 打开刺杀
                            m_nSelectMagic = 12;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // 抱月刀法
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        break;
                    case 3:
                        if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // 抱月刀法
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // 打开刺杀
                            m_nSelectMagic = 12;
                        // 查询魔法 20081206
                        }
                        break;
                    case 4:
                        if ((wSKILL_40 > 0))
                        {
                            // 抱月刀法
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // 打开刺杀
                            m_nSelectMagic = 12;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        break;
                }
            // Case Random(4) of
            }
            else
            {
                switch(HUtil32.Random(4))
                {
                    case 0:
                        // 目标不近身
                        // 5
                        // 20080619
                        if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43)    //打开龙影   20080619 注释
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        break;
                    case 1:
                        // 抱月刀法
                        if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // 抱月刀法
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        }
                        break;
                    case 2:
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43);      //打开龙影  20080619 注释
                        if ((wSKILL_40 > 0))
                        {
                            // 抱月刀法
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43)        //打开龙影  20080619 注释
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        break;
                    case 3:
                        if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // 打开半月
                            m_nSelectMagic = 25;
                        // 查询魔法 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // 抱月刀法
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // 使用烈火
                            m_nSelectMagic = 26;
                        // 查询魔法 20081206
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43)      //打开龙影   20080619 注释
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // 打开逐日剑法 20080528
                            m_nSelectMagic = 74;
                        // 查询魔法 20081206
                        }
                        break;
                }
            // Case Random(4) of
            }
        }

        // 物理攻击
        // 战士攻击 有待进一步优化
        private  bool WarrorAttackTarget()
        {
            bool result;
            result = false;
            try {
                m_wHitMode = 0;
                if (this.m_WAbil.MP > 0)
                {
                    // 20080420 增加
                    if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2)))
                    {
                        // 魔法不能打到怪 20080420
                        if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7)))
                        {
                            this.m_TargetCret = null;
                            return result;
                        }
                        else
                        {
                            GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                        }
                    }
                    
                    if ((wSkill_75 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (HUtil32.GetTickCount() - this.m_boProtectionTick > M2Share.g_Config.dwProtectionTick))
                    {
                        DoSpellMagic(wSkill_75);
                    }
                    // 护体神盾 20080405

                    if ((wSkill_27 > 0) && ((HUtil32.GetTickCount() - m_dwDoMotaeboTick) > 10000) && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.8)))
                    {
                        if (this.m_TargetCret != null)
                        {
                            if ((this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                            {
                                m_dwDoMotaeboTick = HUtil32.GetTickCount();
                                DoSpellMagic(wSkill_27);
                                // 野蛮冲撞 20081016
                                return result;
                            }
                        }
                    }
                    WarrorAttackTarget_SelectMagic();
                    // 20080405 修改
                    if (this.m_boUseThrusting)
                    {
                        // 使用刺杀
                        m_wHitMode = 4;
                    }
                    else if (this.m_boUseHalfMoon)
                    {
                        // 使用半月
                        m_wHitMode = 5;
                    }
                    else if (this.m_boCrsHitkill)
                    {
                        // 抱月弯刀 20080410
                        m_wHitMode = 8;
                    }
                    else if (this.m_bo43kill)
                    {
                        // 使用龙影剑法 20080201
                        m_wHitMode = 12;
                    }
                    else if (this.m_bo42kill)
                    {
                        // 使用开天斩 20080201
                        m_wHitMode = 9;
                    }
                    else if (this.m_boFireHitSkill)
                    {
                        // 使用烈火
                        m_wHitMode = 7;
                    }
                    else if (this.m_boDailySkill)
                    {
                        m_wHitMode = 13;
                    }
                // 使用逐日剑法 20080528
                }
                result = WarrAttackTarget(m_wHitMode);
                if (result)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                }
            }
            catch {
            }
            return result;
        }

        /// <summary>
        /// 检查使用的魔法
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        private unsafe int CheckUserMagic(int wMagIdx)
        {
            int result = 0;
            TUserMagic* UserMagic;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I ++ )
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = wMagIdx;
                        break;
                    }
                }
            }
            return result;
        }

        private unsafe ushort CheckUserMagic(ushort wMagIdx)
        {
            ushort result = 0;
            TUserMagic* UserMagic;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = wMagIdx;
                        break;
                    }
                }
            }
            return result;
        }

        // 检查使用的魔法
        // 取指定坐标范围内的目标数量
        private int CheckTargetXYCount(int nX, int nY, int nRange)
        {
            int result;
            TBaseObject BaseObject;
            int nC;
            int n10;
            result = 0;
            n10 = nRange;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I ++ )
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(nX - BaseObject.m_nCurrX) + Math.Abs(nY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    result ++;
                                    if (result > 2)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 法师攻击
        public int WizardAttackTarget_SearchDoSpell()
        {
            int result;
            result = 0;

            if ((wSkill_75 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (HUtil32.GetTickCount() - this.m_boProtectionTick > M2Share.g_Config.dwProtectionTick))
            {
                // 使用 护体神盾
                result = wSkill_75;
                return result;
            }
            if ((this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence))
            {
                // 使用 魔法盾
                if ((wSkill_66 > 0))
                {
                    result = wSkill_66;
                    return result;
                }
                else if ((wSkill_05 > 0))
                {
                    result = wSkill_05;
                    return result;
                }
            }
            if (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1)
            {
                // 取指定坐标范围内的目标数量
                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 1))
                {
                    if ((this.m_Master != null) && (wSkill_02 > 0))
                    {
                        // 人形看怪使用地狱雷光
                        if (new ArrayList(new int[] {91, 92, 97, 101, 102, 104}).Contains(this.m_TargetCret.m_btRaceServer))
                        {
                            result = wSkill_02;
                            return result;
                        }
                    }
                    if ((wSkill_02 > 0) && (this.m_Master == null))
                    {
                        result = wSkill_02;
                    }
                    else if (wSkill_03 > 0)
                    {
                        result = wSkill_03;
                    }
                    else if (wSkill_04 > 0)
                    {
                        result = wSkill_04;
                    }
                    else if (wSkill_01 > 0)
                    {
                        result = wSkill_01;
                    }
                    else if (wSKILL_45 > 0)
                    {
                        result = wSKILL_45;
                    }
                    return result;
                }
                else
                {
                    if ((wSkill_03 > 0) && (wSkill_04 > 0) && (wSKILL_45 > 0) && (wSKILL_36 > 0) && (wSKILL_58 > 0))
                    {
                        switch(HUtil32.Random(5))
                        {
                            case 0:
                                result = wSkill_03;
                                break;
                            case 1:
                                result = wSkill_04;
                                break;
                            case 2:
                                result = wSKILL_45;
                                break;
                            case 3:
                                result = wSKILL_36;
                                break;
                            case 4:
                                result = wSKILL_58;
                                break;
                        }
                        return result;
                    }
                    else
                    {
                        switch(HUtil32.Random(6))
                        {
                            case 0:
                                if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                break;
                            case 1:
                                if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                break;
                            case 2:
                                if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                break;
                            case 3:
                                if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                break;
                            case 4:
                                if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                break;
                            case 5:
                                if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                break;
                        }
                        return result;
                    }
                }
            }
            else
            {
                switch(HUtil32.Random(6))
                {
                    case 0:
                        if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        break;
                    case 1:
                        if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        break;
                    case 2:
                        if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        break;
                    case 3:
                        if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        break;
                    case 4:
                        if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        break;
                    case 5:
                        if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        break;
                }
            }
            return result;
        }

        // 战士攻击
        private bool WizardAttackTarget()
        {
            bool result;
            int nMagicID;
            byte nCode;
            result = false;
            nCode = 0;
            try {
                m_wHitMode = 0;
                if (m_boDoSpellMagic && (this.m_TargetCret != null))
                {
                    nCode = 1;
                    nMagicID = WizardAttackTarget_SearchDoSpell();
                    nCode = 5;
                    if (nMagicID == 0)
                    {
                        m_boAutoAvoid = true; // 是否能躲避
                    }
                    nCode = 6;
                    if (nMagicID > 0)
                    {
                        nCode = 2;
                        if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7) 
                            || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))// 魔法不能打到怪
                        {
                            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7)))
                            {
                                nCode = 3;
                                this.m_TargetCret = null;
                                return result;
                            }
                            else
                            {
                                GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                            }
                        }
                        nCode = 4;
                        if (!DoSpellMagic((ushort)nMagicID))
                        {
                            this.SendRefMsg(Grobal2.RM_MAGICFIREFAIL, 0, 0, 0, 0, "");
                        }
                        result = true;
                    }
                    else
                    {
                        result = WarrAttackTarget(m_wHitMode);
                    }
                }
                else
                {
                    result = WarrAttackTarget(m_wHitMode);
                }
                this.m_dwHitTick = HUtil32.GetTickCount();
            }
            catch {
                M2Share.MainOutMessage("{异常} TPlayMonster.WizardAttackTarget:" + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// 道士--检查身上是否有符或毒
        /// </summary>
        /// <param name="nItemType"></param>
        /// <param name="StdItem"></param>
        /// <param name="nItemShape"></param>
        /// <returns></returns>
        private unsafe bool CheckItemType(int nItemType, TStdItem* StdItem, int nItemShape)
        {
            bool result = false;
            switch (nItemType)
            {
                case 1:
                    if ((StdItem->StdMode == 25) && (StdItem->Shape == 5))
                    {
                        result = true;
                    }
                    break;
                case 2:
                    switch (nItemShape)
                    {
                        case 1:
                            if ((StdItem->StdMode == 25) && (StdItem->Shape == 1))
                            {
                                result = true;
                            }
                            break;
                        case 2:
                            if ((StdItem->StdMode == 25) && (StdItem->Shape == 2))
                            {
                                result = true;
                            }
                            break;
                    }
                    break;
            }
            return result;
        }

        // 判断装备里是否有指定的物品
        private unsafe bool CheckUserItemType(int nItemType, int nItemShape)
        {
            bool result = false;
            TStdItem* StdItem;
            if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                if ((StdItem != null))
                {
                    switch (nItemType)
                    {
                        case 1:
                            if (this.m_UseItems[TPosition.U_ARMRINGL]->Dura >= nItemShape * 100)
                            {
                                result = CheckItemType(nItemType, StdItem, nItemShape);
                            }
                            break;
                        case 2:
                            result = CheckItemType(nItemType, StdItem, nItemShape);
                            break;
                    }
                }
            }
            return result;
        }

        private unsafe bool UseItem(int nItemType, int nIndex, int nItemShape)
        {
            bool result = false;
            TUserItem* UserItem;
            TUserItem* AddUserItem;
            TStdItem* StdItem;
            if ((nIndex >= 0) && (nIndex < this.m_ItemList.Count))
            {
                UserItem = (TUserItem*)this.m_ItemList[nIndex];
                if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                    if (StdItem != null)
                    {
                        if (CheckItemType(nItemType, StdItem, nItemShape))
                        {
                            result = true;
                        }
                        else
                        {
                            this.m_ItemList.RemoveAt(nIndex);
                            AddUserItem = this.m_UseItems[TPosition.U_BUJUK];
                            if (this.AddItemToBag(AddUserItem))
                            {
                                this.m_UseItems[TPosition.U_BUJUK] = UserItem;
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                result = true;
                            }
                            else
                            {
                                this.m_ItemList.Add((IntPtr)UserItem);
                            }
                        }
                    }
                    else
                    {
                        this.m_ItemList.RemoveAt(nIndex);
                        this.m_UseItems[TPosition.U_BUJUK] = UserItem;
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        result = true;
                    }
                }
                else
                {
                    this.m_ItemList.RemoveAt(nIndex);
                    this.m_UseItems[TPosition.U_BUJUK] = UserItem;
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    result = true;
                }
            }
            return result;
        }

        // 检测包裹中是否有符和毒
        // nType 为指定类型 1 为护身符 2 为毒药
        private unsafe int GetUserItemList(int nItemType, int nItemShape)
        {
            int result = -1;
            TUserItem* UserItem;
            TStdItem* StdItem;
            for (int I = this.m_ItemList.Count - 1; I >= 0; I-- )
            {
                if (this.m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)this.m_ItemList[I];
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem != null)
                {
                    if (CheckItemType(nItemType, StdItem, nItemShape))
                    {
                        if (UserItem->Dura < 100)
                        {
                            this.m_ItemList.RemoveAt(I);
                            continue;
                        }
                        result = I;
                        break;
                    }
                }
            }
            return result;
        }

        public int TaoistAttackTarget_SearchDoSpell_GetMagic01()
        {
            int result;
            result = 0;
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1)))
            {
                // 绿毒
                if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
                else if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
            }
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))
            {
                // 红毒
                if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
                else if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
            }
            return result;
        }

        public int TaoistAttackTarget_SearchDoSpell_GetMagic02()
        {
            int result = 0;
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && (this.m_TargetCret.m_btRaceServer != 128) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1)))
            {
                // 绿毒
                if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
                else if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
            }
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && (this.m_TargetCret.m_btRaceServer != 128) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))
            {
                // 红毒
                if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
                else if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
            }
            return result;
        }

        public int TaoistAttackTarget_SearchDoSpell_GetMagic03()
        {
            int result = 0;
            if (CheckUserItemType(1, 0) || (GetUserItemList(1, 0) >= 0))
            {
                switch(HUtil32.Random(2))
                {
                    case 0:
                        if (wSkill_07 > 0)
                        {
                            // 灵魂火符
                            result = wSkill_07;
                        }
                        else if (wSKILL_59 > 0)
                        {
                            result = wSKILL_59;
                        }
                        break;
                    case 1:
                        // 噬血术
                        if (wSKILL_59 > 0)
                        {
                            // 噬血术
                            result = wSKILL_59;
                        }
                        else if (wSkill_07 > 0)
                        {
                            result = wSkill_07;
                        }
                        break;
                // 灵魂火符
                }
            }
            return result;
        }

        // 道士攻击
        public  int TaoistAttackTarget_SearchDoSpell()
        {
            int result = 0;
            try {
                if (this.m_TargetCret == null)
                {
                    return result;
                }
                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                {
                    if ((wSkill_08 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && (CheckUserItemType(1, 0) || (GetUserItemList(1, 0) >= 0)))
                    {
                        result = wSkill_08;// 使用神圣战甲术
                        return result;
                    }
                    if ((wSkill_14 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && (CheckUserItemType(1, 0) || (GetUserItemList(1, 0) >= 0)))
                    {
                        result = wSkill_14;// 使用幽灵盾
                        return result;
                    }
                }
                if ((wSkill_50 > 0) && (this.m_wStatusArrValue[2] == 0) && (HUtil32.GetTickCount() - m_nSkill_5Tick > 15000)) // 无极真气
                {
                    m_nSkill_5Tick = HUtil32.GetTickCount();// 无极真气使用间隔
                    result = wSkill_50;
                    return result;
                }
                if ((wSkill_75 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) 
                    && (!this.m_boProtectionDefence) && (HUtil32.GetTickCount() - this.m_boProtectionTick > M2Share.g_Config.dwProtectionTick))// 使用 护体神盾
                {
                    result = wSkill_75;
                    return result;
                }
                else if ((wSkill_73 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (wSkill_75 == 0)) // 使用 道力盾
                {
                    result = wSkill_73;
                    return result;
                }
                if (wSkill_51 > 0)
                {
                    if (HUtil32.Random(4) == 0)
                    {
                        result = wSkill_51;// 飓风破
                        return result;
                    }
                }
                if (wSkill_48 > 0)
                {
                    if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level <= this.m_WAbil.Level) 
                        && (HUtil32.GetTickCount() - m_nSkill_48Tick > 5000))// 气功波
                    {
                        m_nSkill_48Tick = HUtil32.GetTickCount();// 气功波使用间隔
                        result = wSkill_48;
                        return result;
                    }
                }
                if (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1)
                {
                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1))) // 绿毒
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic01();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))// 红毒
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic01();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic01();
                        }
                    }
                }
                else
                {
                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1)))// 绿毒
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic02();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2))) // 红毒
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic02();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic02();
                        }
                    }
                }
            }
            catch {
            }
            return result;
        }

        // 法师攻击
        private bool TaoistAttackTarget()
        {
            bool result = false;
            int nMagicID;
            int nIndex;
            byte nCode = 0;
            try {
                if (this.m_TargetCret.m_boDeath)// 防止人物死后,人形怪还在使用魔法,导致M2出错
                {
                    return result;
                }
                m_wHitMode = 0;
                nCode = 1;
                if (m_boDoSpellMagic && (this.m_TargetCret != null))
                {
                    nCode = 12;
                    nMagicID = TaoistAttackTarget_SearchDoSpell();
                    nCode = 13;
                    if (nMagicID == 0)
                    {
                        m_boAutoAvoid = true; // 是否能躲避
                    }
                    nCode = 2;
                    if (nMagicID > 0)
                    {
                        if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7)
                            || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))// 魔法不能打到怪
                        {
                            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7)))
                            {
                                nCode = 3;
                                this.m_TargetCret = null;
                                return result;
                            }
                            else
                            {
                                GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                            }
                        }
                        nCode = 4;
                        switch(nMagicID)
                        {
                            case MagicConst.SKILL_AMYOUNSUL:// 施毒
                            case MagicConst.SKILL_GROUPAMYOUNSUL:
                                if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1))) // 绿毒 
                                {
                                    nCode = 5;
                                    if (!CheckUserItemType(2, 1))// 检查装备栏的物品类型
                                    {
                                        nCode = 6;
                                        nIndex = GetUserItemList(2, 1);// 取包裹里的物品ID
                                        if (nIndex >= 0)
                                        {
                                            nCode = 7;
                                            UseItem(2, nIndex, 1);// 自动换毒
                                        }
                                    }
                                }
                                else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))// 红毒
                                {
                                    nCode = 8;
                                    if (!CheckUserItemType(2, 2)) // 检查装备栏的物品类型
                                    {
                                        nCode = 9;
                                        nIndex = GetUserItemList(2, 2);// 取包裹里的物品ID
                                        if (nIndex >= 0)
                                        {
                                            nCode = 10;
                                            UseItem(2, nIndex, 2);// 自动换毒
                                        }
                                    }
                                }
                                break;
                        }
                        nCode = 11;
                        if (!DoSpellMagic((ushort)nMagicID))
                        {
                            this.SendRefMsg(Grobal2.RM_MAGICFIREFAIL, 0, 0, 0, 0, "");
                        }
                        result = true;
                    }
                    else
                    {
                        result = WarrAttackTarget(m_wHitMode);
                    }
                }
                else
                {
                    result = WarrAttackTarget(m_wHitMode);
                }
                this.m_dwHitTick = HUtil32.GetTickCount();
            }
            catch {
                M2Share.MainOutMessage("{异常} TPlayMonster.TaoistAttackTarget Code:" + nCode);
            }
            return result;
        }

        public bool AttackTarget()
        {
            bool result = false;
            if (this.m_WAbil.MP < 100)
            {
                this.m_WAbil.MP = 100;
            }
            switch (this.m_btJob)
            {
                case 0:// 当MP少于100时,初始为100
                    if (this.m_Master != null)
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime) //  人物分身时的攻击速度
                        {
                            m_nSelectMagic = 0;// 查询魔法 
                            m_boAutoAvoid = false;// 是否能躲避
                            result = WarrorAttackTarget();
                        }
                    }
                    else
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime) // 为怪物时按DB设置的攻击速度
                        {
                            m_nSelectMagic = 0;// 查询魔法
                            m_boAutoAvoid = false;// 是否能躲避
                            result = WarrorAttackTarget();
                        }
                    }
                    break;
                case 1:
                    if (this.m_Master != null)
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWizardAttackTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// 是否能躲避
                            result = WizardAttackTarget();
                        }
                    }
                    else
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// 是否能躲避
                            result = WizardAttackTarget();
                        }
                    }
                    break;
                case 2:
                    if (this.m_Master != null)
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwTaoistAttackTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// 是否能躲避
                            result = TaoistAttackTarget();
                        }
                    }
                    else
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// 是否能躲避
                            result = TaoistAttackTarget();
                        }
                    }
                    break;
            }
            return result;
        }

        public  override void Run()
        {
            int nX = 0;
            int nY = 0;
            int nCheckCode;
            const string sExceptionMsg = "{异常} TPlayMonster.Run Code:%d";
            nCheckCode = 0;
            try
            {
                if ((!this.m_boGhost) && (!this.m_boDeath) && (!this.m_boFixedHideMode) && (!this.m_boStoneMode) && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCheckCode = 12;
                    if (Think())
                    {
                        base.Run();
                        return;
                    }
                    PlaySuperRock();// 气血石功能
                    nCheckCode = 1;
                    if (this.m_boFireHitSkill && ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 20000))// 20 * 1000
                    {
                        this.m_boFireHitSkill = false;// 关闭烈火
                    }
                    if (this.m_boDailySkill && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 20000))// 20 * 1000
                    {
                        this.m_boDailySkill = false;// 关闭逐日剑法
                    }
                    nCheckCode = 2;
                    if ((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 1100)
                    {
                        this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        if ((this.m_TargetCret == null))
                        {
                            SearchTarget(); // 搜索目标
                        }
                    }
                    nCheckCode = 3;
                    if (this.m_boWalkWaitLocked)
                    {
                        if ((HUtil32.GetTickCount() - this.m_dwWalkWaitTick) > this.m_dwWalkWait)
                        {
                            this.m_boWalkWaitLocked = false;
                        }
                    }
                    nCheckCode = 4;
                    if (!this.m_boWalkWaitLocked && ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed))
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        this.m_nWalkCount++;
                        if (this.m_nWalkCount > this.m_nWalkStep)
                        {
                            this.m_nWalkCount = 0;
                            this.m_boWalkWaitLocked = true;
                            this.m_dwWalkWaitTick = HUtil32.GetTickCount();
                        }
                        nCheckCode = 5;
                        if (!m_boRunAwayMode)
                        {
                            if (!this.m_boNoAttackMode)
                            {
                                if (m_boProtectStatus) // 守护状态,距离太远 
                                {
                                    if (!m_boProtectOK)// 没走到守护坐标
                                    {
                                        if ((this.m_TargetCret != null))
                                        {
                                            this.m_TargetCret = null;
                                        }
                                        GotoTargetXY(m_nProtectTargetX, m_nProtectTargetY);
                                        m_nGotoProtectXYCount++;
                                        if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) <= 2) && (Math.Abs(this.m_nCurrY - m_nProtectTargetY) <= 2))
                                        {
                                            m_boProtectOK = true;
                                            m_nGotoProtectXYCount = 0;// 是向守护坐标的累计数
                                        }
                                        if ((m_nGotoProtectXYCount > 20) && !m_boProtectOK)// 20次还没有走到守护坐标，则飞回坐标上
                                        {
                                            if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 13) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 13))
                                            {
                                                this.SpaceMove(this.m_PEnvir.sMapName, m_nProtectTargetX, m_nProtectTargetY, 1);// 地图移动
                                                m_boProtectOK = true;
                                                m_nGotoProtectXYCount = 0;// 是向守护坐标的累计数
                                            }
                                        }
                                    }
                                }
                                if ((this.m_TargetCret != null))
                                {
                                    if ((!this.m_TargetCret.m_boDeath) && (this.m_TargetCret.m_WAbil.HP > 0))
                                    {
                                        nCheckCode = 51;
                                        if (AttackTarget())
                                        {
                                            base.Run();
                                            return;
                                        }
                                        nCheckCode = 6;
                                        if (StartAutoAvoid() && m_boDoSpellMagic)
                                        {
                                            AutoAvoid();// 自动躲避
                                            base.Run();
                                            return;
                                        }
                                        else
                                        {
                                            nCheckCode = 61;
                                            if (IsNeedGotoXY())
                                            {
                                                nCheckCode = 62;
                                                GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                                base.Run();
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    m_nTargetX = -1;
                                    nCheckCode = 7;
                                    if (this.m_boMission)  // 如果设置了怪物结集点,则向结集点移动
                                    {
                                        m_nTargetX = this.m_nMissionX;
                                        m_nTargetY = this.m_nMissionY;
                                    }
                                }
                            }
                            nCheckCode = 8;
                            if (this.m_Master != null)
                            {
                                if (this.m_TargetCret == null)
                                {
                                    nCheckCode = 81;
                                    this.m_Master.GetBackPosition(ref nX, ref nY);
                                    if ((Math.Abs(m_nTargetX - nX) > 1) || (Math.Abs(m_nTargetY - nY) > 1))
                                    {
                                        m_nTargetX = nX;
                                        m_nTargetY = nY;
                                        if ((Math.Abs(this.m_nCurrX - nX) <= 2) && (Math.Abs(this.m_nCurrY - nY) <= 2))
                                        {
                                            if (this.m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                            {
                                                m_nTargetX = this.m_nCurrX;
                                                m_nTargetY = this.m_nCurrY;
                                            }
                                        }
                                    }
                                }
                                if ((!this.m_Master.m_boSlaveRelax) && ((this.m_PEnvir != this.m_Master.m_PEnvir) || (Math.Abs(this.m_nCurrX - this.m_Master.m_nCurrX) > 20) || (Math.Abs(this.m_nCurrY - this.m_Master.m_nCurrY) > 20)))
                                {
                                    nCheckCode = 82;
                                    this.SpaceMove(this.m_Master.m_PEnvir.sMapName, m_nTargetX, m_nTargetY, 1);// 地图移动
                                }
                            }
                            else
                            {
                                nCheckCode = 83;
                                if (m_boProtectStatus)// 守护状态
                                {
                                    if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 13) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 13))
                                    {
                                        m_nTargetX = m_nProtectTargetX;
                                        m_nTargetY = m_nProtectTargetY;
                                        this.m_TargetCret = null;
                                        m_boProtectOK = false;
                                        GotoTargetXY(m_nTargetX, m_nTargetY);
                                        if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) <= 1) && (Math.Abs(this.m_nCurrY - m_nProtectTargetY) <= 1))
                                        {
                                            m_boProtectOK = true;
                                        }
                                    }
                                    else
                                    {
                                        m_nTargetX = -1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            nCheckCode = 9;

                            if ((m_dwRunAwayTime > 0) && ((HUtil32.GetTickCount() - m_dwRunAwayStart) > m_dwRunAwayTime))
                            {
                                m_boRunAwayMode = false;
                                m_dwRunAwayTime = 0;
                            }
                        }
                        if ((this.m_Master != null) && this.m_Master.m_boSlaveRelax)
                        {
                            base.Run();
                            return;
                        }
                        if ((this.m_TargetCret == null))
                        {
                            if ((m_nTargetX != -1) && AllowGotoTargetXY())// 修正:怪围的人转圈圈,转个两三圈再砍一刀
                            {
                                nCheckCode = 10;
                                GotoTargetXY(m_nTargetX, m_nTargetY);
                            }
                            else
                            {
                                nCheckCode = 11;
                                Wondering();
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode));
            }
        }

        public unsafe bool AddItems(TUserItem* UserItem, int btWhere)
        {
            bool result = false;
            if (btWhere >= m_UseItems.GetLowerBound(0) && btWhere <= m_UseItems.GetUpperBound(0))
            {
                this.m_UseItems[btWhere] = UserItem;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 加载人形怪挖取列表
        /// </summary>
        private void LoadButchItemList()
        {
            int I;
            string s24;
            TStringList LoadList;
            TMonItemInfo MonItem;
            string s28;
            string s2C;
            string s30 = string.Empty;
            int n18;
            int n1C;
            int n20;
            s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + this.m_sCharName + "-Item.txt";
            if (File.Exists(s24))
            {
                if (m_ButchItemList != null)
                {
                    if (m_ButchItemList.Count > 0)
                    {
                        for (I = 0; I < m_ButchItemList.Count; I ++ )
                        {
                            if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                            {
                                
                                Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                            }
                        }
                    }
                    m_ButchItemList.Clear();
                }
                LoadList = new TStringList();
                LoadList.LoadFromFile(s24);
                if (LoadList.Count > 0)
                {
                    for (I = 0; I < LoadList.Count; I ++ )
                    {
                        s28 = LoadList[I];
                        if ((s28 != "") && (s28[0] != ';'))
                        {
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "/", "\09"});
                            n18 = HUtil32.Str_ToInt(s30,  -1);
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "/", "\09"});
                            n1C = HUtil32.Str_ToInt(s30,  -1);
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "\09"});
                            if (s30 != "")
                            {
                                if (s30[0] == '\'')
                                {
                                    HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                                }
                            }
                            s2C = s30;
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "\09"});
                            n20 = HUtil32.Str_ToInt(s30, 1);
                            if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                            {
                                MonItem = new TMonItemInfo();
                                MonItem.SelPoint = n18 - 1;
                                MonItem.MaxPoint = n1C;
                                MonItem.ItemName = s2C;
                                MonItem.Count = n20;
                                if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)// 计算机率 1/10 随机10<=1 即为所得的物品
                                {
                                    m_ButchItemList.Add(MonItem);
                                }
                            }
                        }
                    }
                }
                
                Dispose(LoadList);
            }
        }

        public unsafe void AddItemsFromConfig()
        {
            List<string> TempList;
            string sCopyHumBagItems = string.Empty;
            TUserItem* UserItem = null;
            string sFileName;
            IniFile ItemIni;
            string sMagic;
            string sMagicName;
            TMagic* Magic;
            TUserMagic* UserMagic = null;
            TStdItem* StdItem;
            string[] StdItemNameArray = new string[16 + 1];// 扩展到13 支持斗笠
            if (this.m_nCopyHumanLevel > 0)
            {
                switch (this.m_btJob)
                {
                    case 0:
                        sCopyHumBagItems = M2Share.g_Config.sCopyHumBagItems1.Trim();
                        break;
                    case 1:
                        sCopyHumBagItems = M2Share.g_Config.sCopyHumBagItems2.Trim();
                        break;
                    case 2:
                        sCopyHumBagItems = M2Share.g_Config.sCopyHumBagItems3.Trim();
                        break;
                }
                if (sCopyHumBagItems != "")
                {
                    TempList = new List<string>();
                    fixed (char* Content = sCopyHumBagItems.Trim().ToCharArray())
                    {
                        HUtil32.ExtractStrings(new char[] { '|', '\\', '/', ',' }, new char[] { }, Content, TempList);
                    }
                    if (TempList.Count > 0)
                    {
                        for (int I = 0; I < TempList.Count; I++)
                        {
                            UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                            if (UserEngine.CopyToUserItemFromName(TempList[I], UserItem))
                            {
                                this.m_ItemList.Add((IntPtr)UserItem);
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                            }
                        }
                    }
                    Dispose(TempList);
                }
            }
            else
            {
                sFileName = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + this.m_sCharName + ".txt";
                if (File.Exists(sFileName))
                {
                    ItemIni = new IniFile(sFileName);
                    if (ItemIni != null)
                    {
                        m_boDropUseItem = ItemIni.ReadBool("Info", "DropUseItem", false);// 是否掉装备 
                        m_nDieDropUseItemRate = ItemIni.ReadInteger("Info", "DropUseItemRate", 100);// 死亡掉装备几率
                        // m_nButchUserItemRate:= ItemIni.ReadInteger('Info','ButchUserItemRate',10);//被挖取时可以挖到身上装备的几率 
                        m_boButchUseItem = ItemIni.ReadBool("Info", "ButchUseItem", false);// 是否允许挖取身上装备
                        m_nButchRate = ItemIni.ReadInteger("Info", "ButchRate", 10);// 挖取身上装备机率 
                        m_nButchChargeClass = (byte)ItemIni.ReadInteger("Info", "ButchChargeClass", 3);// 挖取身上装备收费模式(0金币，1元宝，2金刚石，3灵符)  
                        m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// 挖取身上装备每次收费点数 
                        sCopyHumBagItems = ItemIni.ReadString("UseItems", "InitItems", "");// 附加物品 如毒等物品 
                        boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 人形怪挖是否进入触发 
                        boIsDieEvent = ItemIni.ReadBool("Info", "IsDieEvent", false);// 清理人形尸体,是否显示升天龙效果(人物升级效果) 
                        m_boProtectStatus = ItemIni.ReadBool("Info", "ProtectStatus", false);// 是否守护模式 
                        if (sCopyHumBagItems != "")
                        {
                            TempList = new List<string>();
                            try
                            {
                                fixed (char* Content = sCopyHumBagItems.Trim().ToCharArray())
                                {
                                    HUtil32.ExtractStrings(new char[] { '|', '\\', '/', ',' }, new char[] { }, Content, TempList);
                                }
                                if (TempList.Count > 0)
                                {
                                    for (int I = 0; I < TempList.Count; I++)
                                    {
                                        UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                        if (UserEngine.CopyToUserItemFromName(TempList[I], UserItem))
                                        {
                                            this.m_ItemList.Add((IntPtr)UserItem);
                                        }
                                        else
                                        {
                                            Marshal.FreeHGlobal((IntPtr)UserItem);
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                Dispose(TempList);
                            }
                        }
                        this.m_btJob = (byte)ItemIni.ReadInteger("Info", "Job", 0);// 职业
                        this.m_btGender = (byte)ItemIni.ReadInteger("Info", "Gender", 0);// 性别
                        this.m_btHair = (byte)ItemIni.ReadInteger("Info", "Hair", 0);// 头发
                        sMagic = ItemIni.ReadString("Info", "UseSkill", "");// 使用魔法
                        if (sMagic != "")
                        {
                            TempList = new List<string>();
                            fixed (char* Content = sMagic.Trim().ToCharArray())
                            {
                                HUtil32.ExtractStrings(new char[] { '|', '\\', '/',',' }, new char[] { }, Content, TempList);
                            }
                            if (TempList.Count > 0)
                            {
                                for (int I = 0; I < TempList.Count; I++)
                                {
                                    sMagicName = TempList[I].Trim();
                                    if (FindMagic(sMagicName) == null)
                                    {
                                        Magic = UserEngine.FindMagic(sMagicName);
                                        if (Magic != null)
                                        {
                                            if ((Magic->btJob == 99) || (Magic->btJob == this.m_btJob))
                                            {
                                                UserMagic->MagicInfo = *Magic;
                                                UserMagic->wMagIdx = Magic->wMagicId;
                                                if (Magic->wMagicId == 66)
                                                {
                                                    UserMagic->btLevel = 4;// 四级魔法盾
                                                }
                                                else
                                                {
                                                    UserMagic->btLevel = 3;
                                                }
                                                UserMagic->btKey = 0;
                                                UserMagic->nTranPoint = Magic->MaxTrain[3];
                                                this.m_MagicList.Add((IntPtr)UserMagic);
                                            }
                                        }
                                    }
                                }
                            }
                            Dispose(TempList);
                        }
                        //FillChar(StdItemNameArray, sizeof(StdItemNameArray), '\0');
                        StdItemNameArray[TPosition.U_DRESS] = ItemIni.ReadString("UseItems", "UseItems0", "");// '衣服';
                        StdItemNameArray[TPosition.U_WEAPON] = ItemIni.ReadString("UseItems", "UseItems1", "");// '武器';
                        StdItemNameArray[TPosition.U_RIGHTHAND] = ItemIni.ReadString("UseItems", "UseItems2", "");// '照明物';
                        StdItemNameArray[TPosition.U_NECKLACE] = ItemIni.ReadString("UseItems", "UseItems3", "");// '项链';
                        StdItemNameArray[TPosition.U_HELMET] = ItemIni.ReadString("UseItems", "UseItems4", "");// '头盔';
                        StdItemNameArray[TPosition.U_ARMRINGL] = ItemIni.ReadString("UseItems", "UseItems5", "");// '左手镯';
                        StdItemNameArray[TPosition.U_ARMRINGR] = ItemIni.ReadString("UseItems", "UseItems6", "");// '右手镯';
                        StdItemNameArray[TPosition.U_RINGL] = ItemIni.ReadString("UseItems", "UseItems7", "");// '左戒指';
                        StdItemNameArray[TPosition.U_RINGR] = ItemIni.ReadString("UseItems", "UseItems8", "");// '右戒指';
                        StdItemNameArray[TPosition.U_BUJUK] = ItemIni.ReadString("UseItems", "UseItems9", "");// '物品';
                        StdItemNameArray[TPosition.U_BELT] = ItemIni.ReadString("UseItems", "UseItems10", "");// '腰带';
                        StdItemNameArray[TPosition.U_BOOTS] = ItemIni.ReadString("UseItems", "UseItems11", "");// '鞋子';
                        StdItemNameArray[TPosition.U_CHARM] = ItemIni.ReadString("UseItems", "UseItems12", "");// '宝石';
                        StdItemNameArray[TPosition.U_ZHULI] = ItemIni.ReadString("UseItems", "UseItems13", "");// '斗笠'
                        for (int I = TPosition.U_DRESS; I <= TPosition.U_ZHULI; I++) // 斗笠
                        {
                            if (StdItemNameArray[I] != "")
                            {
                                StdItem = UserEngine.GetStdItem(StdItemNameArray[I]);
                                if (StdItem != null)
                                {
                                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                    if (UserEngine.CopyToUserItemFromName(StdItemNameArray[I], UserItem))
                                    {
                                        if (HUtil32.Random(M2Share.g_Config.nPlayMonRandomAddValue) == 0)
                                        {
                                            UserEngine.RandomUpgradeItem(UserItem);  // 人形支持极品装备
                                        }
                                        AddItems(UserItem, I);
                                    }
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                }
                            }
                        }
                        LoadButchItemList();// 加载人形怪挖取列表
                        Dispose(ItemIni);
                    }
                }
            }
        }

        /// <summary>
        /// 查找魔法
        /// </summary>
        /// <param name="sMagicName"></param>
        /// <returns></returns>
        private unsafe TUserMagic* FindMagic(string sMagicName)
        {
            TUserMagic* result;
            TUserMagic* UserMagic;
            result = null;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sMagicName, 0, UserMagic->MagicInfo.MagicNameLen)).ToLower().CompareTo((sMagicName).ToLower()) == 0)
                    {
                        result = UserMagic;
                        break;
                    }
                }
            }
            return result;
        }

        // 无极真气
        // 0级提升道术40%   1级提升60%   2级提升80%  3级提升100%  时间都是6秒
        private unsafe bool AbilityUp(TUserMagic* UserMagic)
        {
            int n14;
            bool result = false;
            int nSpellPoint = GetSpellPoint(UserMagic);
            if (nSpellPoint > 0)
            {
                if (this.m_WAbil.MP < nSpellPoint)
                {
                    return result;
                }
                n14 = (HUtil32.Random(10 + UserMagic->btLevel) + UserMagic->btLevel) * UserMagic->btLevel;
                this.m_dwStatusArrTimeOutTick[2] = Convert.ToUInt32(HUtil32.GetTickCount() + n14 * 1000);
                this.RecalcAbilitys();
                result = true;
            }
            return result;
        }

        public unsafe int MagMakeFireDay_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeFireDay_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 灭天火
        private unsafe bool MagMakeFireDay(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeFireDay_GetPower(UserMagic,MagMakeFireDay_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                    if (UserMagic->btLevel == 4)
                    {
                        nPower = nPower + M2Share.g_Config.nPowerLV4; // 4 级威力
                    }
                    if (TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                    {
                        nPower = (int)HUtil32.Round(nPower * 1.5);
                    }                    
                    //PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                    if (M2Share.g_Config.boPlayObjectReduceMP)
                    {
                        // 击中减MP值,减35%
                        //TargeTBaseObject.DamageSpell(Math.Abs(HUtil32.Round(nPower * 0.35)));
                    }
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        result = true;
                    }
                    else if (TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                    {
                        result = true;
                    }
                }
                else
                {
                    TargeTBaseObject = null;
                }
            }
            else
            {
                TargeTBaseObject = null;
            }
            return result;
        }

        // 火焰冰
        private bool MabMabe(TBaseObject BaseObject, TBaseObject TargeTBaseObject, int nPower, int nLevel, int nTargetX, int nTargetY)
        {
            bool result = false;
            int nLv;
            if (BaseObject.MagCanHitTarget(BaseObject.m_nCurrX, BaseObject.m_nCurrY, TargeTBaseObject))
            {
                if (BaseObject.IsProperTarget(TargeTBaseObject) && (BaseObject != TargeTBaseObject))
                {
                    if ((TargeTBaseObject.m_nAntiMagic <= HUtil32.Random(10)) && (Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                    {
                        //BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DELAYMAGIC, nPower / 3, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                        if ((HUtil32.Random(2) + (BaseObject.m_Abil.Level - 1)) > TargeTBaseObject.m_Abil.Level)
                        {
                            nLv = BaseObject.m_Abil.Level - TargeTBaseObject.m_Abil.Level;
                            if ((HUtil32.Random(M2Share.g_Config.nMabMabeHitRandRate) < HUtil32._MAX(M2Share.g_Config.nMabMabeHitMinLvLimit, (nLevel * 8) - nLevel + 15 + nLv)))
                            {
                                // 21
                                if ((HUtil32.Random(M2Share.g_Config.nMabMabeHitSucessRate) < nLevel * 2 + 4))
                                {
                                    if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        BaseObject.SetPKFlag(BaseObject);
                                        BaseObject.SetTargetCreat(TargeTBaseObject);
                                    }
                                    TargeTBaseObject.SetLastHiter(BaseObject);
                                    nPower = TargeTBaseObject.GetMagStruckDamage(BaseObject, nPower);
                                    //BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DELAYMAGIC, nPower, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                                    if (!TargeTBaseObject.m_boUnParalysis)
                                    {
                                        // 中毒类型 - 麻痹
                                        // 20
                                       // TargeTBaseObject.SendDelayMsg(BaseObject, Grobal2.RM_POISON, Grobal2.POISON_STONE, nPower / M2Share.g_Config.nMabMabeHitMabeTimeRate + HUtil32.Random(nLevel), (int)BaseObject, nLevel, "", 650);
                                    }
                                    result = true;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 气血石功能
        /// </summary>
        private unsafe void PlaySuperRock()
        {
            TStdItem* StdItem;
            int nTempDura = 0;
            try {
                if ((!this.m_boDeath) && (!this.m_boGhost) && (this.m_WAbil.HP > 0))
                {
                    if ((this.m_UseItems[TPosition.U_CHARM]->wIndex > 0) && (this.m_UseItems[TPosition.U_CHARM]->Dura > 0))
                    {
                        StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_CHARM]->wIndex);
                        if ((StdItem != null))
                        {
                            if ((StdItem->Shape > 0) && this.m_PEnvir.AllowStdItems(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen)))
                            {
                                switch (StdItem->Shape)
                                {
                                    case 1:// 气血石
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= M2Share.g_Config.nStartHPRock)// 改成掉点数启用
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > M2Share.g_Config.nHPRockSpell)
                                            {
                                                dwRockAddHPTick = HUtil32.GetTickCount();// 气石加HP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nHPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nHPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.HP > this.m_WAbil.MaxHP)
                                                {
                                                    this.m_WAbil.HP = this.m_WAbil.MaxHP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                    case 2:
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= M2Share.g_Config.nStartMPRock)// 改成掉点数启用
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > M2Share.g_Config.nMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();// 气石加MP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = Convert.ToUInt16(HUtil32.Round((double)nTempDura / 10));
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.MP > this.m_WAbil.MaxMP)
                                                {
                                                    this.m_WAbil.MP = this.m_WAbil.MaxMP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                    case 3:
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= M2Share.g_Config.nStartHPMPRock) // 改成掉点数启用
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > M2Share.g_Config.nHPMPRockSpell)
                                            {
                                                dwRockAddHPTick = (uint)HUtil32.Round((double)nTempDura / 10);// 气石加HP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = Convert.ToUInt16(HUtil32.Round((double)nTempDura / 10));
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.HP > this.m_WAbil.MaxHP)
                                                {
                                                    this.m_WAbil.HP = this.m_WAbil.MaxHP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        // ======================================================================
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= M2Share.g_Config.nStartHPMPRock)// 改成掉点数启用
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > M2Share.g_Config.nHPMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();// 气石加MP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.MP > this.m_WAbil.MaxMP)
                                                {
                                                    this.m_WAbil.MP = this.m_WAbil.MaxMP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TPlayMonster.PlaySuperRock");
            }
        }

        public  bool DoMotaebo_CanMotaebo(TBaseObject BaseObject, int nMagicLevel)
        {
            bool result;
            int nC;
            result = false;
            if ((this.m_Abil.Level > BaseObject.m_Abil.Level) && (!BaseObject.m_boStickMode))
            {
                nC = this.m_Abil.Level - BaseObject.m_Abil.Level;
                if (HUtil32.Random(20) < ((nMagicLevel * 4) + 6 + nC))
                {
                    if (this.IsProperTarget(BaseObject))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        // 人形进行野蛮冲撞 
        private  bool DoMotaebo(byte nDir, int nMagicLevel)
        {
            bool result;
            bool bo35;
            int I;
            int n20;
            int n24;
            int n28;
            TBaseObject PoseCreate;
            TBaseObject BaseObject_30 = null;
            TBaseObject BaseObject_34;
            int nX = 0;
            int nY = 0;
            result = false;
            bo35 = true;
            this.m_btDirection = nDir;
            BaseObject_34 = null;
            n24 = nMagicLevel + 1;
            n28 = n24;
            PoseCreate = this.GetPoseCreate();
            if (PoseCreate != null)
            {
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I ++ )
                {
                    PoseCreate = this.GetPoseCreate();
                    if (PoseCreate != null)
                    {
                        n28 = 0;
                        if (!DoMotaebo_CanMotaebo(PoseCreate,nMagicLevel))
                        {
                            break;
                        }
                        if (nMagicLevel >= 3)
                        {
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref nX, ref nY))
                            {
                                //BaseObject_30 = this.m_PEnvir.GetMovingObject(nX, nY, true);
                                if ((BaseObject_30 != null) && DoMotaebo_CanMotaebo(BaseObject_30, nMagicLevel))
                                {
                                    BaseObject_30.CharPushed(this.m_btDirection, 1);
                                }
                            }
                        }
                        BaseObject_34 = PoseCreate;
                        if (PoseCreate.CharPushed(this.m_btDirection, 1) != 1)
                        {
                            break;
                        }
                        this.GetFrontPosition(ref nX, ref nY);
                        if (this.m_PEnvir.MoveToMovingObject(this.m_nCurrX, this.m_nCurrY, this, nX, nY, false) > 0)
                        {
                            this.m_nCurrX = nX;
                            this.m_nCurrY = nY;
                            this.SendRefMsg(Grobal2.RM_RUSH, nDir, this.m_nCurrX, this.m_nCurrY, 0, "");
                            bo35 = false;
                            result = true;
                        }
                        n24 -= 1;
                    }
                }
            }
            else
            {
                bo35 = false;
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I ++ )
                {
                    this.GetFrontPosition(ref nX, ref nY);
                    // sub_004B2790
                    if (this.m_PEnvir.MoveToMovingObject(this.m_nCurrX, this.m_nCurrY, this, nX, nY, false) > 0)
                    {
                        this.m_nCurrX = nX;
                        this.m_nCurrY = nY;
                        this.SendRefMsg(Grobal2.RM_RUSH, nDir, this.m_nCurrX, this.m_nCurrY, 0, "");
                        n28 -= 1;
                    }
                    else
                    {
                        if (this.m_PEnvir.CanWalk(nX, nY, true))
                        {
                            n28 = 0;
                        }
                        else
                        {
                            bo35 = true;
                            break;
                        }
                    }
                }
            }
            if ((BaseObject_34 != null))
            {
                if (n24 < 0)
                {
                    n24 = 0;
                }
                n20 = HUtil32.Random((n24 + 1) * 10) + ((n24 + 1) * 10);
                n20 = BaseObject_34.GetHitStruckDamage(this, n20);
                BaseObject_34.StruckDamage(n20);
                BaseObject_34.SendRefMsg(Grobal2.RM_STRUCK, n20, BaseObject_34.m_WAbil.HP, BaseObject_34.m_WAbil.MaxHP, Parse(this), "");
                if (BaseObject_34.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                {
                    BaseObject_34.SendMsg(BaseObject_34, Grobal2.RM_STRUCK, n20, BaseObject_34.m_WAbil.HP, BaseObject_34.m_WAbil.MaxHP, Parse(this), "");
                }
            }
            if (bo35)
            {
                this.GetFrontPosition(ref nX, ref nY);
                this.SendRefMsg(Grobal2.RM_RUSHKUNG, this.m_btDirection, nX, nY, 0, "");
            }
            if (n28 > 0)
            {
                if (n24 < 0)
                {
                    n24 = 0;
                }
                n20 = HUtil32.Random(n24 * 10) + ((n24 + 1) * 3);
                n20 = this.GetHitStruckDamage(this, n20);
                this.StruckDamage(n20);
                this.SendRefMsg(Grobal2.RM_STRUCK, n20, this.m_WAbil.HP, this.m_WAbil.MaxHP, 0, "");
            }
            return result;
        }
    } 
}

