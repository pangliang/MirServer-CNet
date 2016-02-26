// ------------------------------------------------------------------------------
// 单元名称: ObjHero.pas
// 
// 单元作者: Mars
// 创建日期: 2007-02-12 20:30:00
// 
// 功能介绍: 实现英雄功能单元
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using GameFramework;
using GameFramework.Enum;

namespace M2Server
{
    public class THeroObject : TBaseObject
    {
        public uint m_dwDoMotaeboTick = 0;// 野蛮冲撞间隔 
        public uint m_dwThinkTick = 0;
        public bool m_boDupMode = false;// 人物重叠了
        public int m_nTargetX = 0;// 目标坐标X
        public int m_nTargetY = 0;// 目标坐标Y
        public bool m_boRunAwayMode = false;// 运行远离模式
        public uint m_dwRunAwayStart = 0;
        public uint m_dwRunAwayTime = 0;
        public uint m_dwPickUpItemTick = 0;// 捡起物品间隔
        public TMapItem m_SelMapItem = null;
        public ushort m_wHitMode = 0;// 攻击方式
        public ushort m_wBatterHitMode = 0;
        public byte m_btOldDir = 0;
        public uint m_dwActionTick = 0;// 动作间隔
        public ushort m_wOldIdent = 0;
        public byte m_btMentHero = 0;
        public uint m_dwTurnIntervalTime = 0;// 转动间隔时间
        public uint m_dwMagicHitIntervalTime = 0;// 魔法打击间隔时间
        /// <summary>
        /// 跑间隔时间
        /// </summary>
        public uint m_dwRunIntervalTime = 0;
        /// <summary>
        /// 走间隔时间
        /// </summary>
        public uint m_dwWalkIntervalTime = 0;
        public uint m_dwActionIntervalTime = 0;// 动作间隔时间
        public uint m_dwRunLongHitIntervalTime = 0;// 运行长攻间隔时间
        public uint m_dwWalkHitIntervalTime = 0;// 走动攻击间隔时间
        public uint m_dwRunHitIntervalTime = 0;// 跑攻击间隔时间
        public uint m_dwRunMagicIntervalTime = 0;// 跑魔法间隔时间
        public int m_nDieDropUseItemRate = 0;// 死亡掉装备几率
        /// <summary>
        /// 魔法使用间隔
        /// </summary>
        public uint[] m_SkillUseTick = new uint[80];
        /// <summary>
        /// 包裹容量
        /// </summary>
        public int m_nItemBagCount = 0;
        /// <summary>
        /// 状态 0-攻击 1-跟随 2-休息
        /// </summary>
        public byte m_btStatus = 0;
        /// <summary>
        /// 是否是守护状态
        /// </summary>
        public bool m_boProtectStatus = false;
        /// <summary>
        /// 到达守护坐标
        /// </summary>
        public bool m_boProtectOK = false; 
        /// <summary>
        /// 是否锁定目标
        /// </summary>
        public bool m_boTarget = false;
        public int m_nProtectTargetX = 0;
        public int m_nProtectTargetY = 0;// 守护坐标
        /// <summary>
        /// 自动躲避间隔
        /// </summary>
        public uint m_dwAutoAvoidTick = 0;
        /// <summary>
        /// 是否需要躲避
        /// </summary>
        public bool m_boIsNeedAvoid = false;
        public uint m_dwEatItemNoHintTick = 0;// 英雄没药提示时间间隔 
        public uint m_dwEatItemTick = 0;// 吃普通药间隔
        public uint m_dwEatItemTick1 = 0;// 吃特殊药间隔
        public uint m_dwSearchIsPickUpItemTick = 0;// 搜索可捡起的物品间隔
        public uint m_dwSearchIsPickUpItemTime = 0;// 搜索可捡起的物品时间
        public bool m_boCanDrop = false;// 是否允许拿下
        public bool m_boCanUseItem = false;// 是否允许使用物品
        public bool m_boCanWalk = false;// 是否允许走
        public bool m_boCanRun = false;// 是否允许跑
        public bool m_boCanHit = false;// 是否允许打击
        public bool m_boCanSpell = false;// 是否允许魔法
        public bool m_boCanSendMsg = false;// 是否允许发送信息
        public byte m_btReLevel = 0;// 转生等级
        public int m_btCreditPoint = 0;// 声望点 
        public int m_nMemberType = 0;// 会员类型
        public int m_nMemberLevel = 0;// 会员等级
        public int m_nKillMonExpRate = 0;// 杀怪经验百分率(此数除以 100 为真正倍数)
        public int m_nOldKillMonExpRate = 0;// 没使用套装前杀怪经验倍数 
        public uint m_dwMagicAttackInterval = 0;// 魔法攻击间隔时间(Dword)
        public uint m_dwMagicAttackTick = 0;// 魔法攻击时间(Dword)
        public uint m_dwMagicAttackCount = 0;// 魔法攻击计数(Dword) 
        public uint m_dwSearchMagic = 0;// 搜索魔法间隔  没有使用
        public int m_nSelectMagic = 0;// 查询魔法
        public bool m_boIsUseMagic = false;// 是否可以使用的魔法(True才可能躲避)
        public bool m_boIsUseAttackMagic = false;// 是否可以使用的攻击魔法
        public byte m_btLastDirection = 0;// 最后的方向
        public ushort m_wLastHP = 0;// 最后的HP值
        public int m_nPickUpItemPosition = 0;// 可捡起物品的位置
        public int m_nFirDragonPoint = 0;// 英雄怒气值
        public uint m_dwAddFirDragonTick = 0;// 增加英雄怒气值的间隔
        public bool m_boStartUseSpell = false;// 是否开始使用合击
        public bool m_boDecDragonPoint = false;// 开始减怒气
        public uint m_dwStartUseSpellTick = 0;// 使用合击的间隔
        public bool m_boNewHuman = false;// 是否为新人物
        public int m_nLoyal = 0;// 英雄的忠诚度
        public uint m_dwCheckNoHintTick = 0;// 英雄没毒符提示时间间隔  
        public byte n_AmuletIndx = 0;// 绿红毒标识 
        public byte n_HeroTpye = 0;// 英雄类型 0-白日门英雄 1-卧龙英雄 
        public uint m_dwDedingUseTick = 0;// 地钉使用间隔 
        public bool boCallLogOut = false;// 是否被召唤回去 
        public uint m_dwAddAlcoholTick = 0;// 增加酒量进度的间隔  
        public uint m_dwDecWineDrinkValueTick = 0;// 减少醉酒度的间隔  
        public byte n_DrinkWineQuality = 0;// 饮酒时酒的品质 
        public byte n_DrinkWineAlcohol = 0;// 饮酒时酒的度数 
        public bool n_DrinkWineDrunk = false;// 喝酒醉了 
        public ushort dw_UseMedicineTime = 0;// 使用药酒时间,计算长时间没使用药酒 
        public ushort n_MedicineLevel = 0;// 药力值等级 
        public uint dwRockAddHPTick = 0;// 魔血石类HP 使用间隔 
        public uint dwRockAddMPTick = 0;// 魔血石类MP 使用间隔 
        public uint m_Exp68 = 0;// 酒气护体当前经验 
        public uint m_MaxExp68 = 0;// 酒气护体升级经验 
        public bool boAutoOpenDefence = false;// 自动开启魔法盾 
        public bool m_boTrainingNG = false;// 是否学习过内功 
        public byte m_NGLevel = 0;// 内功等级 
        public uint m_ExpSkill69 = 0;// 内功心法当前经验 
        public uint m_MaxExpSkill69 = 0;// 内功心法升级经验 
        public uint m_Skill69NH = 0;// 当前内力值 
        public uint m_Skill69MaxNH = 0;// 最大内力值 
        public uint m_dwIncNHTick = 0;// 增加内力值计时 
        public uint m_dwIncAddNHTick = 0;// 增加内力恢复速度 %  
        public uint m_dwIncAddNHPoint = 0;// 内力恢复速度加几点  
        public bool m_boisOpenPuls = false;// 是否打开英雄经络
        public int m_nPulseExp = 0;// 英雄经络经验
        public unsafe TUserMagic* m_Magic46Skill = null;// 分身术 
        public unsafe TUserMagic* m_MagicSkill_200 = null;// 怒之攻杀
        public unsafe TUserMagic* m_MagicSkill_201 = null;// 静之攻杀
        public unsafe TUserMagic* m_MagicSkill_202 = null;// 怒之半月
        public unsafe TUserMagic* m_MagicSkill_203 = null;// 静之半月
        public unsafe TUserMagic* m_MagicSkill_204 = null;// 怒之烈火
        public unsafe TUserMagic* m_MagicSkill_205 = null;// 静之烈火
        public unsafe TUserMagic* m_MagicSkill_206 = null;// 怒之逐日
        public unsafe TUserMagic* m_MagicSkill_207 = null;// 静之逐日
        public unsafe TUserMagic* m_MagicSkill_208 = null;// 怒之火球
        public unsafe TUserMagic* m_MagicSkill_209 = null;// 静之火球
        public unsafe TUserMagic* m_MagicSkill_210 = null;// 怒之大火球
        public unsafe TUserMagic* m_MagicSkill_211 = null;// 静之大火球
        public unsafe TUserMagic* m_MagicSkill_212 = null;// 怒之火墙
        public unsafe TUserMagic* m_MagicSkill_213 = null;// 静之火墙
        public unsafe TUserMagic* m_MagicSkill_214 = null;// 怒之地狱火
        public unsafe TUserMagic* m_MagicSkill_215 = null;// 静之地狱火
        public unsafe TUserMagic* m_MagicSkill_216 = null;// 怒之疾光电影
        public unsafe TUserMagic* m_MagicSkill_217 = null;// 静之疾光电影
        public unsafe TUserMagic* m_MagicSkill_218 = null;// 怒之爆裂火焰
        public unsafe TUserMagic* m_MagicSkill_219 = null;// 静之爆裂火焰
        public unsafe TUserMagic* m_MagicSkill_220 = null;// 怒之冰咆哮
        public unsafe TUserMagic* m_MagicSkill_221 = null;// 静之冰咆哮
        public unsafe TUserMagic* m_MagicSkill_222 = null;// 怒之雷电
        public unsafe TUserMagic* m_MagicSkill_223 = null;// 静之雷电
        public unsafe TUserMagic* m_MagicSkill_224 = null;// 怒之地狱雷光
        public unsafe TUserMagic* m_MagicSkill_225 = null;// 静之地狱雷光
        public unsafe TUserMagic* m_MagicSkill_226 = null;// 怒之寒冰掌
        public unsafe TUserMagic* m_MagicSkill_227 = null;// 静之寒冰掌
        public unsafe TUserMagic* m_MagicSkill_228 = null;// 怒之灭天火
        public unsafe TUserMagic* m_MagicSkill_229 = null;// 静之灭天火
        public unsafe TUserMagic* m_MagicSkill_230 = null;// 怒之火符
        public unsafe TUserMagic* m_MagicSkill_231 = null;// 静之火符
        public unsafe TUserMagic* m_MagicSkill_232 = null;// 怒之噬血
        public unsafe TUserMagic* m_MagicSkill_233 = null;// 静之噬血
        public unsafe TUserMagic* m_MagicSkill_234 = null;// 怒之流星火雨
        public unsafe TUserMagic* m_MagicSkill_235 = null;// 静之流星火雨
        public unsafe TUserMagic* m_MagicSkill_236 = null;// 怒之内功剑法
        public unsafe TUserMagic* m_MagicSkill_237 = null;// 静之内功剑法
        public uint m_GetExp = 0;// 英雄取得的经验,$HeroGetExp变量使用
        public ushort m_AvoidHp = 0;// 躲闪血量
        public bool m_boCrazyProtection = false;

        public THeroObject()
            : base()
        {
            m_dwIncAddNHTick = 0;
            m_dwIncAddNHPoint = 0;
            boCallLogOut = false;
            this.m_btRaceServer = Grobal2.RC_HEROOBJECT;
            m_boDupMode = false;
            m_dwThinkTick = HUtil32.GetTickCount();
            this.m_nViewRange = 12;
            this.m_nRunTime = 250;
            this.m_dwSearchTick = HUtil32.GetTickCount();
            this.m_nCopyHumanLevel = 3;
            m_nTargetX = -1;
            this.dwTick3F4 = HUtil32.GetTickCount();// 6
            this.m_btNameColor = GameConfig.nHeroNameColor;// 名字的颜色 
            this.m_boFixedHideMode = true;
            m_dwMagicHitIntervalTime = GameConfig.dwMagicHitIntervalTime;
            m_dwRunIntervalTime = HUtil32.GetTickCount();
            m_dwWalkIntervalTime = GameConfig.dwHeroWalkIntervalTime;// 英雄走路间隔 
            m_dwTurnIntervalTime = GameConfig.dwHeroTurnIntervalTime;// 英雄换方向间隔
            m_dwActionIntervalTime = GameConfig.dwActionIntervalTime;// 组合操作间隔
            m_dwRunLongHitIntervalTime = GameConfig.dwRunLongHitIntervalTime;// 组合操作间隔
            m_dwRunHitIntervalTime = GameConfig.dwRunHitIntervalTime;// 组合操作间隔
            m_dwWalkHitIntervalTime = GameConfig.dwWalkHitIntervalTime;// 组合操作间隔
            m_dwRunMagicIntervalTime = GameConfig.dwRunMagicIntervalTime;// 跑位魔法间隔
            this.m_dwHitTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_dwWalkTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_nWalkSpeed = 350;// 原为300
            this.m_nWalkStep = 10;
            this.m_dwWalkWait = 0;
            this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
            m_boRunAwayMode = false;
            m_dwRunAwayStart = HUtil32.GetTickCount();
            m_dwRunAwayTime = 0;
            m_dwPickUpItemTick = HUtil32.GetTickCount();
            m_dwAutoAvoidTick = HUtil32.GetTickCount();
            m_dwEatItemTick = HUtil32.GetTickCount();
            m_dwEatItemTick1 = HUtil32.GetTickCount();
            m_dwEatItemNoHintTick = HUtil32.GetTickCount();
            m_boIsNeedAvoid = false;
            m_SelMapItem = null;
            this.m_nNextHitTime = 300;// 下次攻击时间
            m_nDieDropUseItemRate = 100;
            m_nItemBagCount = 10;
            m_btStatus = 0;// 状态 默认为攻击
            m_boProtectStatus = false;// 是否是守护状态
            m_boProtectOK = false;// 到达守护坐标
            m_boTarget = false;// 是否锁定目标
            m_nProtectTargetX = -1;// 守护坐标
            m_nProtectTargetY = -1;// 守护坐标
            m_boCanDrop = true;// 是否允许扔物品
            m_boCanUseItem = true;// 是否允许使用物品
            m_boCanWalk = true;
            m_boCanRun = true;
            m_boCanHit = true;
            m_boCanSpell = true;
            m_boCanSendMsg = true;
            m_btReLevel = 0;
            m_btCreditPoint = 0;
            m_nMemberType = 0;
            m_nMemberLevel = 0;
            m_nKillMonExpRate = 100;
            m_nOldKillMonExpRate = m_nKillMonExpRate;
            m_boIsUseMagic = false;// 是否能躲避
            m_boIsUseAttackMagic = false;
            m_nSelectMagic = 0;
            m_nPickUpItemPosition = 0;
            m_nFirDragonPoint = 0;// 怒气不用初始化,
            m_dwAddFirDragonTick = HUtil32.GetTickCount();
            m_btLastDirection = this.m_btDirection;
            m_wLastHP = 0;
            m_boStartUseSpell = false;
            m_boDecDragonPoint = false;// 开始减怒气
            m_dwSearchMagic = HUtil32.GetTickCount();
            m_boNewHuman = false;
            m_nLoyal = 0;// 英雄的忠诚度
            n_AmuletIndx = 0;
            m_dwDedingUseTick = 0;// 地钉使用间隔
            m_dwAddAlcoholTick = HUtil32.GetTickCount();// 增加酒量进度的间隔 
            m_dwDecWineDrinkValueTick = HUtil32.GetTickCount();// 减少醉酒度的间隔 
            n_DrinkWineQuality = 0;// 饮酒时酒的品质
            n_DrinkWineAlcohol = 0;// 饮酒时酒的度数
            n_DrinkWineDrunk = false;// 喝酒醉了
            dw_UseMedicineTime = 0;// 使用药酒时间,计算长时间没使用药酒 
            n_MedicineLevel = 0;// 药力值等级 
            m_Exp68 = 0;// 酒气护体当前经验
            m_MaxExp68 = 0;// 酒气护体升级经验
            boAutoOpenDefence = false;// 自动开启魔法盾
            m_boTrainingNG = false;// 是否学习过内功
            m_NGLevel = 1;// 内功等级
            m_ExpSkill69 = 0;// 内功心法当前经验
            m_MaxExpSkill69 = 0;// 内功心法升级经验
            m_Skill69NH = 0;// 当前内力值
            m_Skill69MaxNH = 0;// 最大内力值
            m_dwIncNHTick = HUtil32.GetTickCount();// 增加内力值计时
            //m_Magic46Skill = null;// 分身术
            //m_MagicSkill_200 = null;// 怒之攻杀
            //m_MagicSkill_201 = null;// 静之攻杀
            //m_MagicSkill_202 = null;// 怒之半月
            //m_MagicSkill_203 = null;// 静之半月
            //m_MagicSkill_204 = null;// 怒之烈火
            //m_MagicSkill_205 = null;// 静之烈火
            //m_MagicSkill_206 = null;// 怒之逐日
            //m_MagicSkill_207 = null;// 静之逐日
            //m_MagicSkill_208 = null;// 怒之火球
            //m_MagicSkill_209 = null;// 静之火球
            //m_MagicSkill_210 = null;// 怒之大火球
            //m_MagicSkill_211 = null;// 静之大火球
            //m_MagicSkill_212 = null;// 怒之火墙
            //m_MagicSkill_213 = null;// 静之火墙
            //m_MagicSkill_214 = null;// 怒之地狱火
            //m_MagicSkill_215 = null;// 静之地狱火
            //m_MagicSkill_216 = null;// 怒之疾光电影
            //m_MagicSkill_217 = null;// 静之疾光电影
            //m_MagicSkill_218 = null;// 怒之爆裂火焰
            //m_MagicSkill_219 = null;// 静之爆裂火焰
            //m_MagicSkill_220 = null;// 怒之冰咆哮
            //m_MagicSkill_221 = null;// 静之冰咆哮
            //m_MagicSkill_222 = null;// 怒之雷电
            //m_MagicSkill_223 = null;// 静之雷电
            //m_MagicSkill_224 = null;// 怒之地狱雷光
            //m_MagicSkill_225 = null;// 静之地狱雷光
            //m_MagicSkill_226 = null;// 怒之寒冰掌
            //m_MagicSkill_227 = null;// 静之寒冰掌
            //m_MagicSkill_228 = null;// 怒之灭天火
            //m_MagicSkill_229 = null;// 静之灭天火
            //m_MagicSkill_230 = null;// 怒之火符
            //m_MagicSkill_231 = null;// 静之火符
            //m_MagicSkill_232 = null;// 怒之噬血
            //m_MagicSkill_233 = null;// 静之噬血
            //m_MagicSkill_234 = null;// 怒之流星火雨
            //m_MagicSkill_235 = null;// 静之流星火雨
            //m_MagicSkill_236 = null;// 怒之内功剑法
            //m_MagicSkill_237 = null;// 静之内功剑法
            m_GetExp = 0;// 人物取得的经验,$GetExp变量使用 
            m_AvoidHp = 0;// 躲闪血量
            m_boCrazyProtection = false;// 怪物狂化保护
        }

        public unsafe override void Run()
        {
            int nX = 0;
            int nY = 0;
            byte nCheckCode = 0;
            const string sExceptionMsg = "{异常} THeroObject.Run Code:{0}";
            try
            {
                if ((!this.m_boGhost) && (!this.m_boDeath) && (!this.m_boFixedHideMode) && (!this.m_boStoneMode))
                {
                    EatMedicine();// 吃药
                    if (this.m_boCanUseBatter && (!this.m_boUseBatter))
                    {
                        // 英雄检查并打开连击
                        if (this.AllowBatterHitSkill(true))
                        {
                            this.m_nBatter = 0;
                            this.m_boBatterFinally = false;
                        }
                    }
                    if (this.m_boUseBatter)
                    {
                        ClientUseBatter();
                    }
                    if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))// 没有被麻痹
                    {
                        nCheckCode = 11;
                        if (Think())
                        {
                            base.Run();
                            return;
                        }
                        nCheckCode = 12;
                        if (this.m_Master != null)
                        {
                            PlaySuperRock();// 气血石 魔血石 
                        }
                        // ------------------------------------------------------------------------------
                        // 饮酒酒量进度增加
                        if (this.m_Abil.WineDrinkValue > 0)
                        {
                            // 醉酒度大于0时才处理
                            if ((HUtil32.GetTickCount() - m_dwAddAlcoholTick + n_DrinkWineQuality * 1000 > (GameConfig.nIncAlcoholTick * 1000)) && !n_DrinkWineDrunk)
                            {
                                // 增加酒量进度
                                m_dwAddAlcoholTick = HUtil32.GetTickCount();
                                this.SendRefMsg(Grobal2.RM_MYSHOW, 8, 0, 0, 0, "");
                                // 酒量增加动画  20080623
                                this.m_Abil.Alcohol += (ushort)HUtil32._MAX(5, (n_DrinkWineAlcohol * this.m_Abil.MaxAlcohol) / 1000);
                                // 酒度数 决定增长量
                                if (this.m_Abil.Alcohol > this.m_Abil.MaxAlcohol)
                                {
                                    // 酒量升级
                                    this.m_Abil.Alcohol = Convert.ToUInt16(this.m_Abil.Alcohol - this.m_Abil.MaxAlcohol);
                                    this.m_Abil.MaxAlcohol = Convert.ToUInt16(this.m_Abil.MaxAlcohol + GameConfig.nIncAlcoholValue);
                                    if (this.m_Magic67Skill != null)
                                    {
                                        // 先天元力魔法升级
                                        this.m_Magic67Skill->nTranPoint = this.m_Abil.MaxAlcohol;
                                        if (!this.CheckMagicLevelup(this.m_Magic67Skill))
                                        {
                                            SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, this.m_Magic67Skill->MagicInfo.wMagicId, this.m_Magic67Skill->btLevel, this.m_Magic67Skill->nTranPoint, "", 1000);
                                        }
                                        if (this.m_Abil.WineDrinkValue >= Math.Abs(this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue67 / 100))
                                        {
                                            // 酒量大于或等于酒量上限的5%时才有效
                                            if (this.m_Magic67Skill->btLevel > 0)
                                            {
                                                this.m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.AC), HUtil32.HiWord(this.m_WAbil.AC) + this.m_Magic67Skill->btLevel * 2);
                                                this.m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.MAC), HUtil32.HiWord(this.m_WAbil.MAC) + this.m_Magic67Skill->btLevel * 2);
                                                SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                                            }
                                        }
                                    }
                                }
                                GetNGExp(GameConfig.nDrinkIncNHExp, 2);// 饮酒增加内功经验 
                                RecalcAbilitys();
                                this.CompareSuitItem(false);// 套装与身上装备对比 
                                SendMsg(this, Grobal2.RM_HEROMAKEWINEABILITY, 0, 0, 0, 0, "");// 酒2相关属性
                            }
                            if (HUtil32.GetTickCount() - m_dwDecWineDrinkValueTick > GameConfig.nDesDrinkTick * 1000)
                            {
                                // 减少醉酒度
                                m_dwDecWineDrinkValueTick = HUtil32.GetTickCount();
                                this.m_Abil.WineDrinkValue = (ushort)HUtil32._MAX(0, this.m_Abil.WineDrinkValue - this.m_Abil.MaxAlcohol / 100);
                                if (this.m_Abil.WineDrinkValue == 0)
                                {
                                    n_DrinkWineQuality = 0;// 饮酒时酒的品质
                                    n_DrinkWineAlcohol = 0;// 饮酒时酒的度数
                                    n_DrinkWineDrunk = false;// 喝酒醉了
                                    SysMsg("英雄 " + GameMsgDef.g_sJiujinOverHintMsg, TMsgColor.c_Green, TMsgType.t_Hint); // '酒劲终于消失了,身体也恢复平常的状态'
                                }
                                RecalcAbilitys();
                                this.CompareSuitItem(false);// 套装与身上装备对比 
                                SendMsg(this, Grobal2.RM_HEROMAKEWINEABILITY, 0, 0, 0, 0, "");// 酒2相关属性
                            }
                        }
                        if (m_boTrainingNG && (m_Skill69NH < m_Skill69MaxNH)) // 学过内功,间隔时间增加内力值
                        {
                            // 增加内力恢复速度
                            if (HUtil32.GetTickCount() - m_dwIncAddNHTick + (int)HUtil32.Round((double)GameConfig.dwIncNHTime / 100 * m_dwIncAddNHTick) > GameConfig.dwIncNHTime)
                            {
                                m_dwIncNHTick = HUtil32.GetTickCount();// 内力恢复点
                                m_Skill69NH = (ushort)HUtil32._MIN((int)m_Skill69MaxNH, Convert.ToInt32(m_Skill69NH + HUtil32._MAX(1, (int)HUtil32.Round(m_Skill69MaxNH * 0.014)) + m_dwIncAddNHPoint));
                                this.SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, m_Skill69NH, m_Skill69MaxNH, 0, "");
                            }
                        }
                        // ------------------------------------------------------------------------------
                        nCheckCode = 1;
                        if (!m_boStartUseSpell && !m_boDecDragonPoint)
                        {
                            if (m_nFirDragonPoint < GameConfig.nMaxFirDragonPoint)
                            {
                                if (HUtil32.GetTickCount() - m_dwAddFirDragonTick > GameConfig.nIncDragonPointTick) // 1000 * 3
                                {
                                    m_dwAddFirDragonTick = HUtil32.GetTickCount(); // 加怒气时间可调节
                                    if (WearFirDragon() && (this.m_UseItems[TPosition.U_BUJUK]->Dura > 0))
                                    {
                                        // 火龙之心持久
                                        if (this.m_UseItems[TPosition.U_BUJUK]->Dura >= GameConfig.nDecFirDragonPoint)
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura -= GameConfig.nDecFirDragonPoint;
                                        }
                                        else
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura = 0;
                                        }
                                        m_nFirDragonPoint += GameConfig.nAddFirDragonPoint;// 增加英雄怒气
                                        if (m_nFirDragonPoint > GameConfig.nMaxFirDragonPoint)
                                        {
                                            m_nFirDragonPoint = GameConfig.nMaxFirDragonPoint; // 修正怒气值会加超过
                                        }
                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_BUJUK, this.m_UseItems[TPosition.U_BUJUK]->Dura, this.m_UseItems[TPosition.U_BUJUK]->DuraMax, 0, "");
                                        SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (m_boDecDragonPoint && WearFirDragon()) // 减怒气
                            {
                                if (m_nFirDragonPoint > 0)
                                {
                                    if (HUtil32.GetTickCount() - m_dwAddFirDragonTick > 2000)// 1000 * 2
                                    {
                                        m_dwAddFirDragonTick = HUtil32.GetTickCount();
                                        m_nFirDragonPoint -= (GameConfig.nMaxFirDragonPoint / 10);// 减英雄怒气 
                                        if (m_nFirDragonPoint <= 0)
                                        {
                                            m_nFirDragonPoint = 0;
                                            m_boDecDragonPoint = false;// 停止减怒气
                                            m_boStartUseSpell = false;
                                        }
                                        SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");
                                    }
                                    // 职业是战,距离近了,自动放合击
                                    if ((this.m_TargetCret != null) && (!this.m_TargetCret.m_boDeath) && (this.m_Master != null))
                                    {
                                        switch (GetTogetherUseSpell())
                                        {
                                            case 60:
                                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || (GameConfig.ClientConf.boParalyCanSpell))
                                                {
                                                    //修改，直线才放破魂斩
                                                    if ((((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2))) && (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 2)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 2))))
                                                    {
                                                        m_boDecDragonPoint = false;// 停止减怒气
                                                        m_boStartUseSpell = true;// 合击技能可用
                                                        m_dwStartUseSpellTick = HUtil32.GetTickCount();
                                                    }
                                                }
                                                break;
                                            case 61:
                                            case 62:// 劈星斩,雷霆一击
                                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || (GameConfig.ClientConf.boParalyCanSpell))
                                                {
                                                    // 防麻痹
                                                    if (((this.m_btJob == 0) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 2))) || ((this.m_Master.m_btJob == 0) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) <= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) <= 2))))
                                                    {
                                                        m_boDecDragonPoint = false;// 停止减怒气
                                                        m_boStartUseSpell = true;// 合击技能可用
                                                        m_dwStartUseSpellTick = HUtil32.GetTickCount();
                                                    }
                                                }
                                                break;
                                            case 63:
                                            case 64:
                                            case 65://防麻痹
                                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || (GameConfig.ClientConf.boParalyCanSpell))
                                                {
                                                    m_boDecDragonPoint = false;// 停止减怒气
                                                    m_boStartUseSpell = true;// 合击技能可用
                                                    m_dwStartUseSpellTick = HUtil32.GetTickCount();
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            // 1000 * 3
                            if (m_boStartUseSpell && (HUtil32.GetTickCount() - m_dwStartUseSpellTick > 3000))
                            {
                                m_boStartUseSpell = false;
                                m_boDecDragonPoint = false;// 停止减怒气
                            }
                            SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");// 发送英雄怒气值
                        }
                        // 20 * 1000
                        if (this.m_boFireHitSkill && ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 20000))
                        {
                            this.m_boFireHitSkill = false;// 召唤烈火结束
                        }
                        // 20 * 1000
                        if (this.m_boDailySkill && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 20000))
                        {
                            this.m_boDailySkill = false;// 逐日剑法结束
                        }
                        nCheckCode = 2;
                        if (IsSearchTarget())
                        {
                            SearchTarget(); // 搜索目标
                        }
                        if (this.m_boWalkWaitLocked)
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwWalkWaitTick) > this.m_dwWalkWait)
                            {
                                this.m_boWalkWaitLocked = false;
                            }
                        }
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
                            if (!m_boRunAwayMode)
                            {
                                if (!this.m_boNoAttackMode)
                                {
                                    if (m_boProtectStatus) // 守护状态,距离太远,直接飞过去 
                                    {
                                        if (!m_boProtectOK)  // 没走到守护坐标
                                        {
                                            if (RunToTargetXY(m_nProtectTargetX, m_nProtectTargetY))
                                            {
                                                m_boProtectOK = true;
                                            }
                                            else if (WalkToTargetXY2(m_nProtectTargetX, m_nProtectTargetY))
                                            {
                                                m_boProtectOK = true; // 转向
                                            }
                                        }
                                    }
                                    nCheckCode = 6;
                                    if ((this.m_TargetCret != null))
                                    {
                                        if (m_boStartUseSpell)
                                        {
                                            nCheckCode = 61;
                                            m_nSelectMagic = GetTogetherUseSpell();// 判断合击魔法ID
                                            nCheckCode = 62;
                                            if ((this.m_btJob == 0) && (m_nSelectMagic == 60))
                                            {
                                                //  此消息以前是发送合击 给客户端的消息  但是没实际用处  改用于发破魂先怪物显示下被攻击动画
                                                SendMsg(this.m_TargetCret, Grobal2.RM_GOTETHERUSESPELL, m_nSelectMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 0, "");
                                            }
                                            // 使用合击
                                            m_nFirDragonPoint = 0;
                                            // SearchMagic(); //查询魔法 20080328注释
                                        }
                                        if (AttackTarget())  // 攻击 
                                        {
                                            nCheckCode = 70;
                                            m_boStartUseSpell = false;
                                            base.Run();
                                            return;
                                        }
                                        else if (IsNeedAvoid())
                                        {
                                            // 自动躲避
                                            nCheckCode = 71;
                                            m_dwActionTick = HUtil32.GetTickCount() - 10;
                                            AutoAvoid();
                                            base.Run();
                                            return;
                                        }
                                        else
                                        {
                                            if (IsNeedGotoXY())// 是否走向目标
                                            {
                                                nCheckCode = 72;
                                                m_dwActionTick = HUtil32.GetTickCount();
                                                m_nTargetX = this.m_TargetCret.m_nCurrX;
                                                m_nTargetY = this.m_TargetCret.m_nCurrY;
                                                if (IsAllowUseMagic(12) && (this.m_btJob == 0))
                                                {
                                                    GetGotoXY(this.m_TargetCret, 2);
                                                }
                                                if ((this.m_btJob > 0))
                                                {
                                                    if ((GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22)) || (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_WAbil.MaxHP < 700) && (this.m_btJob == 2) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)))
                                                    {
                                                        // 道法22前是否物理攻击
                                                        if (this.m_Master != null)
                                                        {
                                                            if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) > 6) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) > 6))
                                                            {
                                                                base.Run();
                                                                return;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        GetGotoXY(this.m_TargetCret, 3); // 道法只走向目标3格范围
                                                    }
                                                }
                                                GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                                                base.Run();
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!m_boProtectStatus)
                                        {
                                            m_nTargetX = -1;
                                        }
                                    }
                                }
                                nCheckCode = 8;
                                if (this.m_TargetCret != null)
                                {
                                    m_nTargetX = this.m_TargetCret.m_nCurrX;
                                    m_nTargetY = this.m_TargetCret.m_nCurrY;
                                }
                                nCheckCode = 81;
                                if (SearchIsPickUpItem())
                                {
                                    nCheckCode = 82;
                                    SearchPickUpItem(500);
                                    base.Run();
                                    return;
                                }
                                nCheckCode = 9;
                                if (this.m_Master != null)
                                {
                                    if (m_boProtectStatus) // 守护状态
                                    {
                                        if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 9) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 9))// 修改守护范围
                                        {
                                            m_nTargetX = m_nProtectTargetX;
                                            m_nTargetY = m_nProtectTargetY;
                                            this.m_TargetCret = null;
                                        }
                                        else
                                        {
                                            m_nTargetX = -1;
                                        }
                                    }
                                    else
                                    {
                                        if ((this.m_TargetCret == null) && !m_boProtectStatus && (m_btStatus != 2))
                                        {
                                            nCheckCode = 95;
                                            this.m_Master.GetBackPosition(ref nX, ref nY);
                                            if ((Math.Abs(m_nTargetX - nX) > 2) || (Math.Abs(m_nTargetY - nY) > 2)) // 修改2格
                                            {
                                                m_nTargetX = nX;
                                                m_nTargetY = nY;
                                                if ((Math.Abs(this.m_nCurrX - nX) <= 3) && (Math.Abs(this.m_nCurrY - nY) <= 3))
                                                {
                                                    if (this.m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                                    {
                                                        m_nTargetX = this.m_nCurrX;
                                                        m_nTargetY = this.m_nCurrY;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (this.m_Master != null)
                                    {
                                        if (!m_boProtectStatus && (m_btStatus != 2) && ((this.m_PEnvir != this.m_Master.m_PEnvir) || (Math.Abs(this.m_nCurrX - this.m_Master.m_nCurrX) > 20) || (Math.Abs(this.m_nCurrY - this.m_Master.m_nCurrY) > 20)))
                                        {
                                            nCheckCode = 96;
                                            this.SpaceMove(this.m_Master.m_PEnvir.sMapName, m_nTargetX, m_nTargetY, 1);
                                        }
                                    }
                                    if ((this.m_TargetCret != null))
                                    {
                                        // 如目标与英雄不在同个地图则删除目标
                                        if ((this.m_TargetCret.m_PEnvir != this.m_PEnvir))
                                        {
                                            DelTargetCreat();
                                        }
                                    }
                                }
                            }
                            else
                            {

                                if ((m_dwRunAwayTime > 0) && ((HUtil32.GetTickCount() - m_dwRunAwayStart) > m_dwRunAwayTime))
                                {
                                    m_boRunAwayMode = false;
                                    m_dwRunAwayTime = 0;
                                }
                            }
                            nCheckCode = 10;
                            if ((this.m_TargetCret == null) && (m_btStatus != 2))
                            {
                                if (m_nTargetX != -1)
                                {
                                    if ((Math.Abs(this.m_nCurrX - m_nTargetX) > 1) || (Math.Abs(this.m_nCurrY - m_nTargetY) > 1))
                                    {
                                        GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                                    }
                                }
                                else
                                {
                                    Wondering();
                                }
                            }
                        }
                    }
                    else
                    {
                        // 麻痹时,可以增加怒气
                        if (!m_boStartUseSpell && !m_boDecDragonPoint)
                        {
                            if (m_nFirDragonPoint < GameConfig.nMaxFirDragonPoint)
                            {
                                if (HUtil32.GetTickCount() - m_dwAddFirDragonTick > GameConfig.nIncDragonPointTick)// 1000 * 3
                                {
                                    m_dwAddFirDragonTick = HUtil32.GetTickCount();//  加怒气时间可调节
                                    if (WearFirDragon() && (this.m_UseItems[TPosition.U_BUJUK]->Dura > 0))
                                    {
                                        if (this.m_UseItems[TPosition.U_BUJUK]->Dura >= GameConfig.nDecFirDragonPoint)  // 火龙之心持久
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura -= GameConfig.nDecFirDragonPoint;
                                        }
                                        else
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura = 0;
                                        }
                                        m_nFirDragonPoint += GameConfig.nAddFirDragonPoint;// 增加英雄怒气
                                        if (m_nFirDragonPoint > GameConfig.nMaxFirDragonPoint)
                                        {
                                            m_nFirDragonPoint = GameConfig.nMaxFirDragonPoint; // 修正怒气值会加超过
                                        }
                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_BUJUK, this.m_UseItems[TPosition.U_BUJUK]->Dura, this.m_UseItems[TPosition.U_BUJUK]->DuraMax, 0, "");
                                        SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");
                                    }
                                }
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, new byte[] { nCheckCode }));
            }
        }

        public override void SysMsg(string sMsg, TMsgColor MsgColor, TMsgType MsgType)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SysMsg(sMsg, MsgColor, MsgType);
        }

        public unsafe void SendSocket(TDefaultMessage DefMsg, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            ((TPlayObject)(this.m_Master)).SendSocket(DefMsg, sMsg);
        }

        public unsafe void SendSocket(TDefaultMessage* DefMsg, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            ((TPlayObject)(this.m_Master)).SendSocket(DefMsg, sMsg);
        }

        public void SendDefMessage(ushort wIdent, int nRecog, int nParam, int nTag, int nSeries, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            ((TPlayObject)(this.m_Master)).SendDefMessage(wIdent, nRecog, (ushort)nParam, (ushort)nTag, (ushort)nSeries, sMsg);
        }

        public void SendMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int nParam1, int nParam2, int nParam3, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendMsg(BaseObject, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
        }

        public void SendUpdateMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendUpdateMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg);
        }

        public void SendDelayMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, uint dwDelay)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendDelayMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg, dwDelay);
        }

        public override void SendUpdateDelayMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, uint dwDelay)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendUpdateDelayMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg, dwDelay);
        }

        public unsafe TUserMagic* FindTogetherMagic()
        {
            return FindMagic(GetTogetherUseSpell());
        }

        // 全部修复,需要的持久值 
        // 根据职业,判断英雄可以学习哪种技能
        private int GetTogetherUseSpell()
        {
            int result;
            result = 0;
            if (this.m_Master == null)
            {
                return result;
            }
            switch (this.m_Master.m_btJob)
            {
                case 0:
                    switch (this.m_btJob)
                    {
                        case 0:
                            result = 60;
                            break;
                        case 1:
                            result = 62;
                            break;
                        case 2:
                            result = 61;
                            break;
                    }
                    break;
                case 1:
                    switch (this.m_btJob)
                    {
                        case 0:
                            result = 62;
                            break;
                        case 1:
                            result = 65;
                            break;
                        case 2:
                            result = 64;
                            break;
                    }
                    break;
                case 2:
                    switch (this.m_btJob)
                    {
                        case 0:
                            result = 61;
                            break;
                        case 1:
                            result = 64;
                            break;
                        case 2:
                            result = 63;
                            break;
                    }
                    break;
            }
            return result;
        }

        // 刷新英雄的包裹
        public unsafe void ClientQueryBagItems()
        {
            TStdItem* Item;
            string sSENDMSG;
            TClientItem* ClientItem = null;
            TStdItem* StdItem;
            TUserItem* UserItem;
            string sUserItemName;
            if (this.m_Master != null)
            {
                if (((TPlayObject)(this.m_Master)).m_boCanQueryBag || this.m_boDeath)// 是否可以刷新包裹  死亡则不能刷新包裹
                {
                    return;
                }
                ((TPlayObject)(this.m_Master)).m_boCanQueryBag = true;
                try
                {
                    sSENDMSG = "";
                    if (this.m_ItemList.Count > 0)
                    {
                        for (int I = 0; I < this.m_ItemList.Count; I++)
                        {
                            UserItem = (TUserItem*)this.m_ItemList[I];
                            if (UserItem != null)
                            {
                                Item = UserEngine.GetStdItem(UserItem->wIndex);
                                if (Item != null)
                                {
                                    StdItem = Item;
                                    ItemUnit.GetItemAddValue(UserItem, StdItem);
                                    ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                                    ClientItem->s = *StdItem;
                                    //Move(StdItem, ClientItem->s, sizeof(TStdItem));
                                    // 取自定义物品名称
                                    sUserItemName = "";
                                    if (UserItem->btValue[13] == 1)
                                    {
                                        sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                                    }
                                    if (sUserItemName != "")
                                    {
                                        // ClientItem->s->Name = sUserItemName;
                                    }
                                    if (UserItem->btValue[12] == 1)
                                    {
                                        // 物品发光
                                        ClientItem->s.Reserved1 = 1;
                                    }
                                    else
                                    {
                                        ClientItem->s.Reserved1 = 0;
                                    }
                                    if ((StdItem->StdMode == 60) && (StdItem->Shape != 0))  // 酒类,除烧酒外
                                    {
                                        if (UserItem->btValue[0] != 0)
                                        {
                                            ClientItem->s.AC = UserItem->btValue[0]; // 酒的品质
                                        }
                                        if (UserItem->btValue[1] != 0)
                                        {
                                            ClientItem->s.MAC = UserItem->btValue[1]; // 酒的酒精度
                                        }
                                    }
                                    if (StdItem->StdMode == 8)  // 酿酒材料
                                    {
                                        if (UserItem->btValue[0] != 0)
                                        {
                                            ClientItem->s.AC = UserItem->btValue[0];// 材料的品质
                                        }
                                    }
                                    ClientItem->Dura = UserItem->Dura;
                                    ClientItem->DuraMax = UserItem->DuraMax;
                                    ClientItem->MakeIndex = UserItem->MakeIndex;
                                    sSENDMSG = sSENDMSG + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                                }
                            }
                        }
                    }
                    if (sSENDMSG != "")
                    {
                        this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROBAGITEMS, Parse(this.m_Master), 0, 0, this.m_ItemList.Count, 0);
                        fixed (TDefaultMessage* msg = &this.m_DefMsg)
                        {
                            SendSocket(msg, sSENDMSG);
                        }
                    }
                    else
                    {
                        //修正自动穿装备时，包裹里还有假像物品
                        this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROBAGITEMS, Parse(this.m_Master), 0, 0, this.m_ItemList.Count, 0);
                        fixed (TDefaultMessage* msg = &this.m_DefMsg)
                        {
                            SendSocket(msg, "");
                        }
                    }
                }
                finally
                {
                    ((TPlayObject)(this.m_Master)).m_boCanQueryBag = false;
                }
            }
        }

        // 英雄吃药
        public unsafe void GetBagItemCount()
        {
            int nOldBagCount;
            nOldBagCount = m_nItemBagCount;
            for (int I = GameConfig.nHeroBagItemCount.GetUpperBound(0); I >= GameConfig.nHeroBagItemCount.GetLowerBound(0); I--)
            {
                if (this.m_Abil.Level >= GameConfig.nHeroBagItemCount[I])
                {
                    switch (I)
                    {
                        case 0:
                            m_nItemBagCount = 10;
                            break;
                        case 1:
                            m_nItemBagCount = 20;
                            break;
                        case 2:
                            m_nItemBagCount = 30;
                            break;
                        case 3:
                            m_nItemBagCount = 35;
                            break;
                        case 4:
                            m_nItemBagCount = 40;
                            break;
                    }
                    break;
                }
            }
            if (nOldBagCount != m_nItemBagCount)
            {
                SendMsg(this.m_Master, Grobal2.RM_QUERYHEROBAGCOUNT, 0, m_nItemBagCount, 0, 0, "");
            }
        }

        public override unsafe bool AddItemToBag(TUserItem* UserItem)
        {
            bool result = false;
            if (this.m_Master == null)
            {
                return result;
            }
            if (this.m_ItemList.Count < m_nItemBagCount)
            {
                this.m_ItemList.Add((IntPtr)UserItem);
                WeightChanged();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 发送使用的魔法
        /// </summary>
        public unsafe void SendUseMagic()
        {
            string sSENDMSG = "";
            TUserMagic* UserMagic = null;
            TClientMagic* ClientMagic = null;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic != null)
                    {
                        ClientMagic = (TClientMagic*)Marshal.AllocHGlobal(sizeof(TClientMagic));
                        ClientMagic->Key = (char)(UserMagic->btKey);
                        ClientMagic->Level = UserMagic->btLevel;
                        ClientMagic->CurTrain = UserMagic->nTranPoint;
                        ClientMagic->Def = UserMagic->MagicInfo;
                        sSENDMSG = sSENDMSG + EncryptUnit.EncodeBuffer(ClientMagic, sizeof(TClientMagic)) + "/";
                    }
                }
            }
            if (sSENDMSG != "")
            {
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROSENDMYMAGIC, 0, 0, 0, this.m_MagicList.Count, 0);
                fixed (TDefaultMessage* msg = &this.m_DefMsg)
                {
                    SendSocket(msg, sSENDMSG);
                }
            }
        }

        /// <summary>
        /// 发送使用的物品,即身上的装备
        /// </summary>
        public unsafe void SendUseitems()
        {
            TStdItem* Item;
            string sSENDMSG;
            TClientItem* ClientItem = null;
            TStdItem* StdItem;
            string sUserItemName;
            try
            {
                sSENDMSG = "";
                for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                {
                    if (this.m_UseItems[I]->wIndex > 0)
                    {
                        Item = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                        if (Item != null)
                        {
                            StdItem = Item;
                            ItemUnit.GetItemAddValue(this.m_UseItems[I], StdItem);
                            ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                            ClientItem->s = *StdItem;
                            // 取自定义物品名称
                            sUserItemName = "";
                            if (this.m_UseItems[I]->btValue[13] == 1)
                            {
                                sUserItemName = ItemUnit.GetCustomItemName(this.m_UseItems[I]->MakeIndex, this.m_UseItems[I]->wIndex);
                            }
                            if (this.m_UseItems[I]->btValue[12] == 1)
                            {
                                // 物品发光
                                ClientItem->s.Reserved1 = 1;
                            }
                            else
                            {
                                ClientItem->s.Reserved1 = 0;
                            }
                            if (sUserItemName != "")
                            {
                                //ClientItem->s->Name = sUserItemName;
                            }
                            ClientItem->Dura = this.m_UseItems[I]->Dura;
                            ClientItem->DuraMax = this.m_UseItems[I]->DuraMax;
                            ClientItem->MakeIndex = this.m_UseItems[I]->MakeIndex;
                            sSENDMSG = sSENDMSG + I + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                        }
                    }
                }
                if (sSENDMSG != "")
                {
                    this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_SENDHEROUSEITEMS, 0, 0, 0, 0, 0);
                    fixed (TDefaultMessage* msg = &this.m_DefMsg)
                    {
                        SendSocket(msg, sSENDMSG);
                    }
                }
                if (this.m_Master != null)
                {
                    ((TPlayObject)(this.m_Master)).IsItem_51(1);
                }
                // 发送聚灵珠的经验 
                if (WearFirDragon() && (m_nFirDragonPoint > 0))
                {
                    // 有火龙之心,且怒气大于0时发送  
                    if (m_nFirDragonPoint > GameConfig.nMaxFirDragonPoint)
                    {
                        m_nFirDragonPoint = GameConfig.nMaxFirDragonPoint;// 防止怒气调整后超过
                    }
                    SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");// 发送英雄怒气值 
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.SendUseitems");
            }
        }

        public unsafe void SendChangeItems(int nWhere1, int nWhere2, TUserItem* UserItem1, TUserItem* UserItem2)
        {
            TStdItem* StdItem1;
            TStdItem* StdItem2;
            TStdItem* StdItem80;
            TClientItem* ClientItem = null;
            string sUserItemName;
            string sSendText;
            sSendText = "";
            if (UserItem1 != null)
            {
                StdItem1 = UserEngine.GetStdItem(UserItem1->wIndex);
                if (StdItem1 != null)
                {
                    StdItem80 = StdItem1;
                    ItemUnit.GetItemAddValue(UserItem1, StdItem80);
                    ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                    ClientItem->s = *StdItem80;
                    //Move(StdItem80, ClientItem->s, sizeof(TStdItem));
                    // 取自定义物品名称
                    sUserItemName = "";
                    if (UserItem1->btValue[13] == 1)
                    {
                        sUserItemName = ItemUnit.GetCustomItemName(UserItem1->MakeIndex, UserItem1->wIndex);
                    }
                    if (sUserItemName != "")
                    {
                        //ClientItem->s->Name = sUserItemName;
                    }
                    ClientItem->MakeIndex = UserItem1->MakeIndex;
                    ClientItem->Dura = UserItem1->Dura;
                    ClientItem->DuraMax = UserItem1->DuraMax;
                    sSendText = "0/" + nWhere1 + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                }
            }
            if (UserItem2 != null)
            {
                StdItem2 = UserEngine.GetStdItem(UserItem2->wIndex);
                if (StdItem2 != null)
                {
                    StdItem2 = UserEngine.GetStdItem(UserItem2->wIndex);
                    StdItem80 = StdItem2;
                    ItemUnit.GetItemAddValue(UserItem2, StdItem80);
                    ClientItem->s = *StdItem80;
                    // 取自定义物品名称
                    sUserItemName = "";
                    if (UserItem2->btValue[13] == 1)
                    {
                        sUserItemName = ItemUnit.GetCustomItemName(UserItem2->MakeIndex, UserItem2->wIndex);
                    }
                    if (sUserItemName != "")
                    {
                        //ClientItem->s->Name = sUserItemName;
                    }
                    ClientItem->MakeIndex = UserItem2->MakeIndex;
                    ClientItem->Dura = UserItem2->Dura;
                    ClientItem->DuraMax = UserItem2->DuraMax;
                    if (sSendText == "")
                    {
                        sSendText = "1/" + nWhere2 + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                    }
                    else
                    {
                        sSendText = sSendText + "1/" + nWhere2 + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                    }
                }
            }
            if (sSendText != "")
            {
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROCHANGEITEM, Convert.ToInt32(this.m_Master), 0, 0, 0, 0);
                fixed (TDefaultMessage* msg = &this.m_DefMsg)
                {
                    SendSocket(msg, sSendText);
                }
            }
        }

        public void SendDelItemList(List<string> ItemList)
        {
            int I;
            string s10;
            s10 = "";
            if (ItemList.Count > 0)
            {
                for (I = 0; I < ItemList.Count; I++)
                {
                    //s10 = s10 + ItemList[I] + "/" + (((int)ItemList[I])).ToString() + "/";
                }
            }
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HERODELITEMS, 0, 0, 0, ItemList.Count, 0);
            //SendSocket(this.m_DefMsg, EncryptUnit.EncodeString(s10));
        }

        /// <summary>
        /// 发送删除物品
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void SendDelItems(TUserItem* UserItem)
        {
            TStdItem* StdItem;
            TStdItem* StdItem80;
            TClientItem* ClientItem = null;
            string sUserItemName;
            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
            if (StdItem != null)
            {
                StdItem80 = StdItem;
                ItemUnit.GetItemAddValue(UserItem, StdItem80);
                ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                ClientItem->s = *StdItem80;
                //Move(StdItem80, ClientItem->s, sizeof(TStdItem));
                // 取自定义物品名称
                sUserItemName = "";
                if (UserItem->btValue[13] == 1)
                {
                    sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                }
                if (sUserItemName != "")
                {
                    //ClientItem->s->Name = sUserItemName;
                }
                if (UserItem->btValue[12] == 1)
                {
                    // 物品发光
                    ClientItem->s.Reserved1 = 1;
                }
                else
                {
                    ClientItem->s.Reserved1 = 0;
                }
                ClientItem->MakeIndex = UserItem->MakeIndex;
                ClientItem->Dura = UserItem->Dura;
                ClientItem->DuraMax = UserItem->DuraMax;
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HERODELITEM, Parse(this.m_Master), 0, 0, 1, 0);
                SendSocket(this.m_DefMsg, EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)));
            }
        }

        /// <summary>
        /// 发送增加物品
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void SendAddItem(TUserItem* UserItem)
        {
            TStdItem* StdItem;
            TClientItem* ClientItem = null;
            string sUserItemName;
            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
            if (StdItem == null)
            {
                return;
            }
            ItemUnit.GetItemAddValue(UserItem, StdItem);
            ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
            ClientItem->s = *StdItem;
            //Move(StdItem, ClientItem->s, sizeof(TStdItem));
            // 取自定义物品名称
            sUserItemName = "";
            if (UserItem->btValue[13] == 1)
            {
                sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
            }
            if (sUserItemName != "")
            {
                //ClientItem->s->Name = sUserItemName;
            }
            if (UserItem->btValue[12] == 1)
            {
                // 物品发光
                ClientItem->s.Reserved1 = 1;
            }
            else
            {
                ClientItem->s.Reserved1 = 0;
            }
            ClientItem->MakeIndex = UserItem->MakeIndex;
            ClientItem->Dura = UserItem->Dura;
            ClientItem->DuraMax = UserItem->DuraMax;
            if (new ArrayList(new int[] { 15, 19, 20, 21, 22, 23, 24, 26 }).Contains(StdItem->StdMode))
            {
                if (UserItem->btValue[8] != 0)
                {
                    ClientItem->s.Shape = 130;
                }
            }
            if ((StdItem->StdMode == 60) && (StdItem->Shape != 0)) // 酒类,除烧酒外
            {
                if (UserItem->btValue[0] != 0)
                {
                    ClientItem->s.AC = UserItem->btValue[0];// 酒的品质
                }
                if (UserItem->btValue[1] != 0)
                {
                    ClientItem->s.MAC = UserItem->btValue[1];// 酒的酒精度
                }
            }
            if (StdItem->StdMode == 8) // 酿酒材料
            {
                if (UserItem->btValue[0] != 0)
                {
                    ClientItem->s.AC = UserItem->btValue[0];// 材料的品质
                }
            }
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROADDITEM, Parse(this.m_Master), 0, 0, 1, 0);
            SendSocket(this.m_DefMsg, EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)));
        }

        /// <summary>
        /// 更新物品
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void SendUpdateItem(TUserItem* UserItem)
        {
            string sUserItemName;
            TStdItem* StdItem80;
            TClientItem* ClientItem = null;
            TStdItem* StdItem = UserEngine.GetStdItem(UserItem->wIndex);
            if (StdItem != null)
            {
                StdItem80 = StdItem;
                ItemUnit.GetItemAddValue(UserItem, StdItem80);
                ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                ClientItem->s = *StdItem80;// 取自定义物品名称
                sUserItemName = "";
                if (UserItem->btValue[13] == 1)
                {
                    sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                }
                if (sUserItemName != "")
                {
                    HUtil32.StrToSByteArry(sUserItemName, ClientItem->s.Name, 14, ref ClientItem->s.NameLen);
                }
                if (UserItem->btValue[12] == 1) // 物品发光
                {
                    ClientItem->s.Reserved1 = 1;
                }
                else
                {
                    ClientItem->s.Reserved1 = 0;
                }
                if ((StdItem->StdMode == 60) && (StdItem->Shape != 0))// 酒类,除烧酒外
                {
                    if (UserItem->btValue[0] != 0) // 酒的品质
                    {
                        ClientItem->s.AC = UserItem->btValue[0];
                    }
                    if (UserItem->btValue[1] != 0)// 酒的酒精度
                    {
                        ClientItem->s.MAC = UserItem->btValue[1];
                    }
                }
                ClientItem->MakeIndex = UserItem->MakeIndex;
                ClientItem->Dura = UserItem->Dura;
                ClientItem->DuraMax = UserItem->DuraMax;
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROUPDATEITEM, Parse(this), 0, 0, 1, 0);
                byte[] data = new byte[sizeof(TClientItem)];
                fixed (byte* pb = data)
                {
                    *(TClientItem*)pb = *ClientItem;
                }
                fixed (TDefaultMessage* msg = &this.m_DefMsg)
                {
                    SendSocket(msg, EncryptUnit.EncodeBuffer(data, sizeof(TClientItem)));
                }
            }
        }

        /// <summary>
        /// 显示名字
        /// </summary>
        /// <returns></returns>
        public override string GetShowName()
        {
            string result;
            if (GameConfig.boNameSuffix) // 是否显示后缀 
            {
                result = this.m_sCharName + "\\(" + this.m_Master.m_sCharName + GameConfig.sHeroNameSuffix + ")";
            }
            else
            {
                result = this.m_sCharName + GameConfig.sHeroName;
            }
            if (GameConfig.boUnKnowHum && this.IsUsesZhuLi()) // 带上斗笠即显示神秘人
            {
                result = "神秘人";
            }
            return result;
        }

        new public unsafe void ItemDamageRevivalRing()
        {
            TStdItem* pSItem;
            int nDura;
            int tDura;
            THeroObject HeroObject;
            for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                if (this.m_UseItems[I]->wIndex > 0)
                {
                    pSItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                    if (pSItem != null)
                    {
                        if ((new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem->Shape)) || (((I == TPosition.U_WEAPON) || (I == TPosition.U_RIGHTHAND))
                            && (new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem->AniCount))))
                        {
                            nDura = this.m_UseItems[I]->Dura;
                            // 1.03
                            tDura = (int)HUtil32.Round((double)nDura / 1000);
                            nDura -= 1000;
                            if (nDura <= 0)
                            {
                                nDura = 0;
                                this.m_UseItems[I]->Dura = (ushort)nDura;
                                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    HeroObject = ((this) as THeroObject);
                                    HeroObject.SendDelItems(this.m_UseItems[I]);
                                }
                                this.m_UseItems[I]->wIndex = 0;
                                RecalcAbilitys();
                                this.CompareSuitItem(false);// 套装与身上装备对比
                            }
                            else
                            {
                                this.m_UseItems[I]->Dura = (ushort)nDura;
                            }
                            if (tDura != HUtil32.Round((double)nDura / 1000))
                            {
                                SendMsg(this, Grobal2.RM_HERODURACHANGE, I, nDura, this.m_UseItems[I]->DuraMax, 0, "");
                            }
                        }
                    }
                }
            }
        }

        public unsafe override void DoDamageWeapon(int nWeaponDamage)
        {
            int nDura;
            int nDuraPoint;
            THeroObject HeroObject;
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return;
            }
            nDura = this.m_UseItems[TPosition.U_WEAPON]->Dura;
            nDuraPoint = (int)HUtil32.Round(nDura / 1.03);
            nDura -= nWeaponDamage;
            if (nDura <= 0)
            {
                nDura = 0;
                this.m_UseItems[TPosition.U_WEAPON]->Dura = (ushort)nDura;
                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    HeroObject = ((this) as THeroObject);
                    HeroObject.SendDelItems(this.m_UseItems[TPosition.U_WEAPON]);
                }
                this.m_UseItems[TPosition.U_WEAPON]->wIndex = 0;
                SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_WEAPON, nDura, this.m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");
            }
            else
            {
                this.m_UseItems[TPosition.U_WEAPON]->Dura = (ushort)nDura;
            }
            if ((nDura / 1.03) != nDuraPoint)
            {
                SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_WEAPON, this.m_UseItems[TPosition.U_WEAPON]->Dura, this.m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");
            }
        }

        /// <summary>
        /// 受攻击,身上装备掉持久
        /// </summary>
        /// <param name="nDamage"></param>
        public unsafe override void StruckDamage(int nDamage)
        {
            int nDam;
            int nDura;
            int nOldDura;
            THeroObject HeroObject;
            TStdItem* StdItem;
            bool bo19;
            if (nDamage <= 0)
            {
                return;
            }
            nDam = HUtil32.Random(10) + 5;
            if (this.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] > 0)
            {
                nDam = (int)HUtil32.Round((double)nDam * (GameConfig.nPosionDamagarmor / 10));
                nDamage = (int)HUtil32.Round((double)nDamage * (GameConfig.nPosionDamagarmor / 10));
            }
            bo19 = false;
            if (this.m_UseItems[TPosition.U_DRESS]->wIndex > 0)
            {
                nDura = this.m_UseItems[TPosition.U_DRESS]->Dura;
                nOldDura = (int)HUtil32.Round((double)nDura / 1000);
                nDura -= nDam;
                if (nDura <= 0)
                {
                    if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                    {
                        HeroObject = ((this) as THeroObject);
                        HeroObject.SendDelItems(this.m_UseItems[TPosition.U_DRESS]);
                        this.m_UseItems[TPosition.U_DRESS]->wIndex = 0;
                        this.FeatureChanged();
                    }
                    this.m_UseItems[TPosition.U_DRESS]->wIndex = 0;
                    this.m_UseItems[TPosition.U_DRESS]->Dura = 0;
                    bo19 = true;
                }
                else
                {
                    this.m_UseItems[TPosition.U_DRESS]->Dura = (ushort)nDura;
                }
                if (nOldDura != (int)HUtil32.Round((double)nDura / 1000))
                {
                    SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_DRESS, nDura, this.m_UseItems[TPosition.U_DRESS]->DuraMax, 0, "");
                }
            }
            for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                if ((this.m_UseItems[I]->wIndex > 0) && (HUtil32.Random(8) == 0))
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                    if ((StdItem != null) && (((StdItem->StdMode == 2) && (StdItem->AniCount == 21)) || (StdItem->StdMode == 25) || (StdItem->StdMode == 7)))  // 是祝福罐,火龙之心物品则跳过
                    {
                        continue;
                    }
                    nDura = this.m_UseItems[I]->Dura;
                    nOldDura = (int)HUtil32.Round((double)nDura / 1000);
                    nDura -= nDam;
                    if (nDura <= 0)
                    {
                        if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            HeroObject = ((this) as THeroObject);
                            HeroObject.SendDelItems(this.m_UseItems[I]);
                            this.m_UseItems[I]->wIndex = 0;
                            this.FeatureChanged();
                        }
                        this.m_UseItems[I]->wIndex = 0;
                        this.m_UseItems[I]->Dura = 0;
                        bo19 = true;
                    }
                    else
                    {
                        this.m_UseItems[I]->Dura = (ushort)nDura;
                    }
                    if (nOldDura != (int)HUtil32.Round((double)nDura / 1000))
                    {
                        SendMsg(this, Grobal2.RM_HERODURACHANGE, I, nDura, this.m_UseItems[I]->DuraMax, 0, "");
                    }
                }
            }
            if (bo19)
            {
                RecalcAbilitys();
                this.CompareSuitItem(false);// 套装与身上装备对比
            }
            this.DamageHealth(nDamage);
        }

        /// <summary>
        /// 英雄扔物品
        /// </summary>
        /// <param name="sItemName"></param>
        /// <param name="nItemIdx"></param>
        /// <returns></returns>
        public unsafe bool ClientDropItem(string sItemName, int nItemIdx)
        {
            bool result;
            int I;
            int wIndex;
            int MakeIndex;
            TUserItem* UserItem;
            TStdItem* StdItem;
            string sUserItemName;
            byte nCode;
            result = false;
            nCode = 0;
            ((TPlayObject)(this.m_Master)).m_boCanQueryBag = true;// 扔物品时,不能刷新包裹
            try
            {
                try
                {
                    if (GameConfig.boInSafeDisableDrop && this.InSafeZone())
                    {
                        SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, GameMsgDef.g_sCanotDropInSafeZoneMsg);
                        return result;
                    }
                    nCode = 1;
                    if (!m_boCanDrop)
                    {
                        SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, GameMsgDef.g_sCanotDropItemMsg);
                        return result;
                    }
                    nCode = 2;
                    if (sItemName.IndexOf(" ") > 0)
                    {
                        // 折分物品名称(信件物品的名称后面加了使用次数)
                        HUtil32.GetValidStr3(sItemName, ref sItemName, new string[] { " " });
                    }
                    nCode = 3;
                    for (I = this.m_ItemList.Count - 1; I >= 0; I--)
                    {
                        if (this.m_ItemList.Count <= 0)
                        {
                            break;
                        }
                        nCode = 4;
                        UserItem = (TUserItem*)this.m_ItemList[I];
                        if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                        {
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            nCode = 5;
                            if (StdItem == null)
                            {
                                continue;
                            }
                            // 取自定义物品名称
                            sUserItemName = "";
                            if (UserItem->btValue[13] == 1)
                            {
                                sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                            }
                            if (sUserItemName == "")
                            {
                                sUserItemName = UserEngine.GetStdItemName(UserItem->wIndex);
                            }
                            if ((sUserItemName).ToLower().CompareTo((sItemName).ToLower()) == 0)
                            {
                                nCode = 6;
                                if (this.CheckItemValue(UserItem, 0))// 检查物品是否禁止扔
                                {
                                    break;
                                }
                                nCode = 7;
                                if (this.PlugOfCheckCanItem(0, StdItem->ToString(), false, 0, 0))  // 禁止物品规则(管理插件功能)
                                {
                                    break;
                                }
                                nCode = 9;
                                wIndex = UserItem->wIndex;
                                MakeIndex = UserItem->MakeIndex;
                                if (GameConfig.boControlDropItem && (StdItem->Price < GameConfig.nCanDropPrice))
                                {
                                    nCode = 10;
                                    this.m_ItemList.RemoveAt(I);
                                    ClearCopyItem(wIndex, MakeIndex);// 清理复制品
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                    UserItem = null;
                                    result = true;
                                    break;
                                }
                                nCode = 11;
                                if (((TPlayObject)(this.m_Master)).m_boHeroLogOut)
                                {
                                    return result;
                                }
                                // 英雄退出,则失败(防止刷物品)
                                if (this.DropItemDown(UserItem, 3, false, false, null, this.m_Master))
                                {
                                    nCode = 12;
                                    this.m_ItemList.RemoveAt(I);
                                    ClearCopyItem(wIndex, MakeIndex);// 清理复制品
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                    UserItem = null;
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (result)
                    {
                        WeightChanged();
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} THeroObject.ClientDropItem Code:" + nCode);
                }
            }
            finally
            {
                ((TPlayObject)(this.m_Master)).m_boCanQueryBag = false;// 扔物品时,不能刷新包裹
            }
            return result;
        }

        /// <summary>
        /// 全部修复,需要的持久值
        /// </summary>
        /// <returns></returns>
        private unsafe int RepairAllItemDura()
        {
            int result;
            int nWhere;
            TStdItem* StdItem;
            result = 0;
            for (nWhere = m_UseItems.GetLowerBound(0); nWhere <= m_UseItems.GetUpperBound(0); nWhere++)
            {
                if (this.m_UseItems[nWhere]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[nWhere]->wIndex);
                    if (StdItem != null)
                    {
                        if (((this.m_UseItems[nWhere]->DuraMax / 1000) > (this.m_UseItems[nWhere]->Dura / 1000)) && (StdItem->StdMode != 7) && (StdItem->StdMode != 25)
                            && (StdItem->StdMode != 43) && (StdItem->AniCount != 21))
                        {
                            if (this.CheckItemValue(this.m_UseItems[nWhere], 3)) // 禁止修
                            {
                                continue;
                            }
                            else if (this.PlugOfCheckCanItem(3, StdItem->ToString(), false, 0, 0)) // 禁止物品规则(管理插件功能)
                            {
                                continue;
                            }
                            result += (this.m_UseItems[nWhere]->DuraMax - this.m_UseItems[nWhere]->Dura);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 召唤强化卷,把招出的宝宝变成7级
        /// </summary>
        /// <returns></returns>
        private bool CallMobeItem()
        {
            bool result;
            TBaseObject Slave;
            result = false;
            if (this.m_SlaveList.Count == 0)
            {
                SysMsg("您没有召唤宝宝,不能使用此物品!", TMsgColor.c_Red, TMsgType.t_Hint);
                return result;
            }
            if (this.m_SlaveList.Count > 0)
            {
                for (int I = 0; I < this.m_SlaveList.Count; I++)
                {
                    Slave = this.m_SlaveList[I];
                    if (Slave.m_btRaceServer == Grobal2.RC_PLAYMOSTER)//分身不能调级
                    {
                        continue;
                    }
                    if (Slave.m_btSlaveExpLevel < 7)
                    {
                        Slave.m_btSlaveExpLevel = 7;
                        Slave.RecalcAbilitys();//改变等级,刷新属性
                        Slave.RefNameColor();
                        Slave.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, "");// 宝宝升级动画
                        result = true;
                        SysMsg("在神秘的力量影响下，你的宠物:" + Slave.m_sCharName + " 成长为7级", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 全部修复
        /// </summary>
        /// <param name="DureCount"></param>
        /// <param name="boDec"></param>
        private unsafe void RepairAllItem(int DureCount, bool boDec)
        {
            int nWhere;
            int RepCount;
            TStdItem* StdItem;
            for (nWhere = m_UseItems.GetLowerBound(0); nWhere <= m_UseItems.GetUpperBound(0); nWhere++)
            {
                if (this.m_UseItems[nWhere]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[nWhere]->wIndex);
                    if (StdItem != null)
                    {
                        if (((this.m_UseItems[nWhere]->DuraMax / 1000) > (this.m_UseItems[nWhere]->Dura / 1000)) && (StdItem->StdMode != 7) && (StdItem->StdMode != 25) && (StdItem->StdMode != 43) && (StdItem->AniCount != 21))
                        {
                            if (this.CheckItemValue(this.m_UseItems[nWhere], 3))//禁止修
                            {
                                continue;
                            }
                            else if (this.PlugOfCheckCanItem(3, StdItem->ToString(), false, 0, 0))// 禁止物品规则(管理插件功能)
                            {
                                continue;
                            }
                            if (!boDec)
                            {
                                // 修复点够,则直接修复不计算
                                if ((this.m_UseItems[nWhere]->DuraMax / 1000) - (this.m_UseItems[nWhere]->Dura / 1000) > 0)
                                {
                                    SysMsg(StdItem->ToString() + "修补成功。", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                                this.m_UseItems[nWhere]->Dura = this.m_UseItems[nWhere]->DuraMax;
                                SendMsg(this, Grobal2.RM_HERODURACHANGE, nWhere, this.m_UseItems[nWhere]->Dura, this.m_UseItems[nWhere]->DuraMax, 0, "");
                            }
                            else
                            {
                                RepCount = (this.m_UseItems[nWhere]->DuraMax / 1000) - (this.m_UseItems[nWhere]->Dura / 1000);
                                if (DureCount >= RepCount)
                                {
                                    DureCount -= RepCount;
                                    if ((this.m_UseItems[nWhere]->DuraMax / 1000) - (this.m_UseItems[nWhere]->Dura / 1000) > 0)
                                    {
                                        SysMsg(StdItem->ToString() + "修补成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    this.m_UseItems[nWhere]->Dura = this.m_UseItems[nWhere]->DuraMax;
                                    SendMsg(this, Grobal2.RM_HERODURACHANGE, nWhere, this.m_UseItems[nWhere]->Dura, this.m_UseItems[nWhere]->DuraMax, 0, "");
                                }
                                else if (DureCount > 0)
                                {
                                    DureCount = 0;
                                    this.m_UseItems[nWhere]->Dura = Convert.ToUInt16(this.m_UseItems[nWhere]->Dura + DureCount * 1000);
                                    SendMsg(this, Grobal2.RM_HERODURACHANGE, nWhere, this.m_UseItems[nWhere]->Dura, this.m_UseItems[nWhere]->DuraMax, 0, "");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public string ClientHeroUseItems_GetUnbindItemName(int nShape)
        {
            string result;
            int I;
            result = "";
            if (M2Share.g_UnbindList.Count > 0)
            {
                for (I = 0; I < M2Share.g_UnbindList.Count; I++)
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

        public unsafe bool ClientHeroUseItems_GetUnBindItems(string sItemName, int nCount)
        {
            bool result;
            int I;
            TUserItem* UserItem = null;
            result = false;
            if (nCount <= 0)
            {
                nCount = 1;
            }
            for (I = 0; I < nCount; I++)
            {
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (UserEngine.CopyToUserItemFromName(sItemName, UserItem))
                {
                    this.m_ItemList.Add((IntPtr)UserItem);
                    SendAddItem(UserItem);
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

        public unsafe bool ClientHeroUseItems_FoundUserItem(TUserItem* Item)
        {
            bool result;
            int I;
            TUserItem* UserItem;
            result = false;
            if (this.m_ItemList.Count > 0)
            {
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem == Item)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 客户端英雄包裹里使用物品
        /// </summary>
        /// <param name="nItemIdx"></param>
        /// <param name="sItemName"></param>
        public unsafe void ClientHeroUseItems(int nItemIdx, string sItemName)
        {
            int I;
            int ItemCount;
            bool boEatOK;
            bool boSendUpDate;
            TUserItem* UserItem = null;
            TStdItem* StdItem = null;
            TUserItem* UserItem34 = null;
            ((TPlayObject)(this.m_Master)).m_boCanQueryBag = true;// 使用物品时,不能刷新包裹
            try
            {
                boEatOK = false;
                boSendUpDate = false;
                StdItem = null;
                if (m_boCanUseItem)
                {
                    if (!this.m_boDeath)
                    {
                        for (I = this.m_ItemList.Count - 1; I >= 0; I--)
                        {
                            if (this.m_ItemList.Count <= 0)
                            {
                                break;
                            }
                            UserItem = (TUserItem*)this.m_ItemList[I];
                            if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                            {
                                UserItem34 = UserItem;
                                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                if (StdItem != null)
                                {
                                    if (!this.m_PEnvir.AllowStdItems(UserItem->wIndex))
                                    {
                                        SysMsg(string.Format(GameMsgDef.g_sCanotMapUseItemMsg, StdItem->ToString()), TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                        break;
                                    }
                                    if (this.PlugOfCheckCanItem(8, StdItem->ToString(), false, 0, 0))
                                    {
                                        break;
                                    }
                                    switch (StdItem->StdMode)
                                    {
                                        case 0:
                                        case 1:
                                        case 3:
                                            // 禁止物品规则(管理插件功能) 20080729
                                            // 药
                                            if (EatItems(StdItem))
                                            {
                                                if (UserItem != null)
                                                {
                                                    this.m_ItemList.RemoveAt(I);
                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                    //Dispose(UserItem);
                                                    UserItem = null;
                                                    //HUtil32.DisPoseAndNil(ref UserItem);
                                                }
                                                boEatOK = true;
                                            }
                                            break;
                                        case 2:
                                            if (StdItem->AniCount == 21)
                                            {
                                                // 祝福罐 类型的物品  20080315
                                                if (StdItem->Reserved != 56)
                                                {
                                                    if (UserItem->Dura > 0)
                                                    {
                                                        if ((this.m_ItemList.Count - 1) <= Grobal2.MAXBAGITEM)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                // 修改为1000,20071229
                                                                UserItem->Dura -= 1000;
                                                                UserItem->DuraMax -= 1000;// 减少存物品数量
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                                UserItem->DuraMax = 0;// 减少存物品数量
                                                            }
                                                            // 需要修改UnbindList.txt,加入 3 祝福油  20071229  3---为 祝福罐的外观值
                                                            ClientHeroUseItems_GetUnBindItems(ClientHeroUseItems_GetUnbindItemName(StdItem->Shape), 1);
                                                            // 给一个祝福油  20080310
                                                            if (UserItem->DuraMax == 0)
                                                            {
                                                                // 不能存取物品,则删除物品
                                                                if (UserItem != null)
                                                                {
                                                                    this.m_ItemList.RemoveAt(I);
                                                                    //Dispose(UserItem);
                                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                    UserItem = null;
                                                                    //HUtil32.DisPoseAndNil(ref UserItem);
                                                                }
                                                                boEatOK = true;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // 泉水罐
                                                    if (UserItem->Dura >= 1000)
                                                    {
                                                        if ((this.m_ItemList.Count - 1) <= Grobal2.MAXBAGITEM)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                UserItem->Dura -= 1000;
                                                                // Dec(UserItem->DuraMax, 1000);//20080324 减少存物品数量
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                                // UserItem->DuraMax:= 0;//20080324 减少存物品数量
                                                            }
                                                            // 需要修改UnbindList.txt,加入 1 泉水    1---为 泉水的外观值
                                                            ClientHeroUseItems_GetUnBindItems(ClientHeroUseItems_GetUnbindItemName(StdItem->Shape), 1);//给一个泉水 
                                                        }
                                                    }
                                                }
                                                boSendUpDate = true;
                                            }
                                            else
                                            {
                                                switch (StdItem->Shape)
                                                {
                                                    case 1:
                                                        // 召唤强化卷 20080329
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                if (CallMobeItem())
                                                                {
                                                                    // 召唤强化卷,把招出的宝宝变成7级  20080221
                                                                    UserItem->Dura -= 1000;
                                                                    boEatOK = true;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                            }
                                                        }
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            boSendUpDate = true;
                                                            boEatOK = false;
                                                        }
                                                        else
                                                        {
                                                            if (UserItem != null)
                                                            {
                                                                UserItem->wIndex = 0;
                                                                // 20081014
                                                                this.m_ItemList.RemoveAt(I);
                                                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                //Dispose(UserItem);
                                                                UserItem = null;
                                                                //HUtil32.DisPoseAndNil(ref UserItem);
                                                            }
                                                        }
                                                        break;
                                                    case 9:
                                                        // 原值为1,20071229 //修复神水
                                                        ItemCount = RepairAllItemDura();
                                                        if ((UserItem->Dura > 0) && (ItemCount > 0))
                                                        {
                                                            // 100
                                                            if (UserItem->Dura >= (ItemCount / 10))
                                                            {
                                                                // 20080325
                                                                // 100
                                                                UserItem->Dura -= Convert.ToUInt16((ItemCount / 10));
                                                                RepairAllItem(ItemCount / 1000, false);
                                                                if (UserItem->Dura < 100)
                                                                {
                                                                    UserItem->Dura = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                                RepairAllItem(ItemCount / 1000, true);
                                                            }
                                                        }
                                                        boEatOK = false;
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            boSendUpDate = true;
                                                        }
                                                        else
                                                        {
                                                            if (UserItem != null)
                                                            {
                                                                this.m_ItemList.RemoveAt(I);
                                                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                //Dispose(UserItem);
                                                                UserItem = null;
                                                                //HUtil32.DisPoseAndNil(ref UserItem);
                                                            }
                                                            boEatOK = true;
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                        case 4:
                                            // Case
                                            // 书
                                            if (ReadBook(StdItem))
                                            {
                                                if (UserItem != null)
                                                {
                                                    this.m_ItemList.RemoveAt(I);
                                                    //Dispose(UserItem);
                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                    UserItem = null;
                                                    //HUtil32.DisPoseAndNil(ref UserItem);
                                                }
                                                boEatOK = true;
                                            }
                                            break;
                                        case 31:
                                            switch (StdItem->AniCount)
                                            {
                                                // 解包物品
                                                // Modify the A .. B: 0 .. 3
                                                case 0:
                                                    if ((this.m_ItemList.Count + 6 - 1) <= m_nItemBagCount)
                                                    {
                                                        if (UserItem != null)
                                                        {
                                                            this.m_ItemList.RemoveAt(I);
                                                            Marshal.FreeHGlobal((IntPtr)UserItem);
                                                            UserItem = null;
                                                        }
                                                        ClientHeroUseItems_GetUnBindItems(ClientHeroUseItems_GetUnbindItemName(StdItem->Shape), 6);
                                                        boEatOK = true;
                                                    }
                                                    break;
                                                // 0..3
                                                // Modify the A .. B: 4 .. 255
                                                case 4:
                                                    switch (StdItem->Shape)
                                                    {
                                                        case 0:
                                                            if (ClientHeroUseItems_FoundUserItem(UserItem)) // 先查找物品，删除物品后再触发
                                                            {
                                                                if (UserItem != null)
                                                                {
                                                                    this.m_ItemList.RemoveAt(I);
                                                                    ClearCopyItem(UserItem->wIndex, UserItem->MakeIndex);// 清理复制品
                                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                    UserItem = null;
                                                                    UseStdmodeFunItem(StdItem);// 使用物品触发脚本段
                                                                }
                                                                boEatOK = true;
                                                            }
                                                            break;
                                                    }
                                                    break;
                                            }
                                            break;
                                        case 60:// 饮酒
                                            if (StdItem->Shape != 0)
                                            {
                                                // 除烧酒外,酒量值达到要求
                                                if (!n_DrinkWineDrunk)
                                                {
                                                    if (this.m_Abil.MaxAlcohol >= StdItem->Need)
                                                    {
                                                        // 酒量值达到要求
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                UserItem->Dura -= 1000;
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                            }
                                                            this.SendRefMsg(Grobal2.RM_MYSHOW, 7, 0, 0, 0, "");// 喝酒自身动画 
                                                            if (this.m_Abil.WineDrinkValue == 0)// 如果醉酒度为0,则初始时间间隔
                                                            {
                                                                m_dwDecWineDrinkValueTick = HUtil32.GetTickCount();
                                                                m_dwAddAlcoholTick = HUtil32.GetTickCount();
                                                            }
                                                            this.m_Abil.WineDrinkValue += (ushort)(UserItem->btValue[1] * this.m_Abil.MaxAlcohol / 200);// 增加醉酒度 
                                                            n_DrinkWineAlcohol = (byte)UserItem->btValue[1];// 饮酒时酒的度数 
                                                            n_DrinkWineQuality = (byte)UserItem->btValue[0];// 饮酒时酒的品质 
                                                            if (this.m_Abil.WineDrinkValue >= this.m_Abil.MaxAlcohol) // 醉酒度超过上限,即喝醉了
                                                            {
                                                                this.m_Abil.WineDrinkValue = this.m_Abil.MaxAlcohol;
                                                                n_DrinkWineDrunk = true;// 喝酒醉了 
                                                                SysMsg("(英雄)自觉头晕不已,酒虽为情所系,奈何量去甚多,暂无余力再饮!", TMsgColor.c_Red, TMsgType.t_Hint);
                                                                this.SendRefMsg(Grobal2.RM_MYSHOW, 9, 0, 0, 0, "");// 喝醉自身动画  
                                                            }
                                                            // 普通酒,品质2以上,25%机率加临时属性 20080713
                                                            if ((StdItem->AniCount == 1) && (n_DrinkWineQuality > 2) && (HUtil32.Random(4) == 0) && !n_DrinkWineDrunk)
                                                            {
                                                                switch (HUtil32.Random(2))
                                                                {
                                                                    case 0:// 增加防御力300秒
                                                                        this.DefenceUp(300);
                                                                        break;
                                                                    case 1:// 增加魔御300秒
                                                                        this.MagDefenceUp(300);
                                                                        break;
                                                                }
                                                            }
                                                            if ((StdItem->AniCount == 2) && !n_DrinkWineDrunk)
                                                            {
                                                                // 药酒可增加药力值
                                                                // 品质为4以上,药酒增加临时属性 20080626
                                                                if (n_DrinkWineQuality > 4)
                                                                {
                                                                    switch (StdItem->Shape)
                                                                    {
                                                                        case 8:
                                                                            switch (this.m_btJob)
                                                                            {
                                                                                case 0:
                                                                                    // 虎骨酒 增加攻击上限,魔法上限或道术上限2点,效果持续600秒
                                                                                    this.m_wStatusArrValue[0] = 2;// 600 * 1000
                                                                                    this.m_dwStatusArrTimeOutTick[0] = HUtil32.GetTickCount() + 600000;
                                                                                    break;
                                                                                case 1:
                                                                                    this.m_wStatusArrValue[1] = 2;// 600 * 1000
                                                                                    this.m_dwStatusArrTimeOutTick[1] = HUtil32.GetTickCount() + 600000;
                                                                                    break;
                                                                                case 2:
                                                                                    this.m_wStatusArrValue[2] = 2;// 600 * 1000
                                                                                    this.m_dwStatusArrTimeOutTick[2] = HUtil32.GetTickCount() + 600000;
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case 9:// 金箔酒  增加生命值上限100点,效果持续600秒
                                                                            this.m_wStatusArrValue[4] = 100;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[4] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                        case 10:// 活脉酒  增加敏捷2点,效果持续600秒
                                                                            this.m_wStatusArrValue[11] = 2;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[11] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                        case 11:// 玄参酒  增加防御上限4点,效果持续600秒
                                                                            this.m_wStatusTimeArr[9] = 4;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[9] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                        case 12:// 蛇胆酒  增加魔法值上限200点,效果持续600秒
                                                                            this.m_wStatusArrValue[5] = 200;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[5] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                    }
                                                                }
                                                                dw_UseMedicineTime = (ushort)GameConfig.nDesMedicineTick;// 始化使用药酒时间(12小时)
                                                                this.m_Abil.MedicineValue += (ushort)UserItem->btValue[2];// 增加药力值
                                                                if (this.m_Abil.MedicineValue >= this.m_Abil.MaxMedicineValue) // 当前药力值达到当前等级上限时
                                                                {
                                                                    this.m_Abil.MedicineValue -= this.m_Abil.MaxMedicineValue;
                                                                    switch ((n_MedicineLevel % 6))
                                                                    {
                                                                        case 0:// 增加永久属性
                                                                            switch (this.m_btJob)// 攻击/魔法/道术上限(看职业)
                                                                            {
                                                                                case 0:
                                                                                    this.m_Abil.DC = HUtil32.MakeLong(this.m_Abil.DC, this.m_Abil.DC + 1);
                                                                                    break;
                                                                                case 1:
                                                                                    this.m_Abil.MC = HUtil32.MakeLong(this.m_Abil.MC, this.m_Abil.MC + 1);
                                                                                    break;
                                                                                case 2:
                                                                                    this.m_Abil.SC = HUtil32.MakeLong(this.m_Abil.SC, this.m_Abil.SC + 1);
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case 1:// 加魔御下限
                                                                            this.m_Abil.MAC = HUtil32.MakeLong(this.m_Abil.MAC + 1, this.m_Abil.MAC);
                                                                            break;
                                                                        case 2:// 加防御下限
                                                                            this.m_Abil.AC = HUtil32.MakeLong(this.m_Abil.AC + 1, this.m_Abil.AC);
                                                                            break;
                                                                        case 3:// 攻击/魔法/道术下限(看职业)
                                                                            switch (this.m_btJob)
                                                                            {
                                                                                case 0:
                                                                                    this.m_Abil.DC = HUtil32.MakeLong(this.m_Abil.DC + 1, this.m_Abil.DC);
                                                                                    break;
                                                                                case 1:
                                                                                    this.m_Abil.MC = HUtil32.MakeLong(this.m_Abil.MC + 1, this.m_Abil.MC);
                                                                                    break;
                                                                                case 2:
                                                                                    this.m_Abil.SC = HUtil32.MakeLong(this.m_Abil.SC + 1, this.m_Abil.SC);
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case 4:// 魔御上限
                                                                            this.m_Abil.MAC = HUtil32.MakeLong(this.m_Abil.MAC, this.m_Abil.MAC + 1);
                                                                            break;
                                                                        case 5:// 防御上限
                                                                            this.m_Abil.AC = HUtil32.MakeLong(this.m_Abil.AC, this.m_Abil.AC + 1);
                                                                            break;
                                                                    }
                                                                    if (n_MedicineLevel < M2Share.MAXUPLEVEL)
                                                                    {
                                                                        n_MedicineLevel++;  // 增加等级
                                                                    }
                                                                    this.m_Abil.MaxMedicineValue = this.GetMedicineExp(n_MedicineLevel);   // 取升级后的等级对应的药力值
                                                                    SysMsg("(英雄)酒劲在周身弥漫,感觉身体状态有所改变", TMsgColor.c_Red, TMsgType.t_Hint); // 提示用户
                                                                }
                                                            }
                                                            RecalcAbilitys();
                                                            this.CompareSuitItem(false);// 套装与身上装备对比
                                                            SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                                                            boEatOK = true;
                                                        }
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            boSendUpDate = true;
                                                            boEatOK = false;
                                                        }
                                                        else
                                                        {
                                                            if (UserItem != null)
                                                            {
                                                                UserItem->wIndex = 0;
                                                                this.m_ItemList.RemoveAt(I);
                                                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SysMsg("(英雄)酒量需达到" + (StdItem->Need).ToString() + "才能饮用!", TMsgColor.c_Red, TMsgType.t_Hint);// 提示用户
                                                    }
                                                }
                                                else
                                                {
                                                    SysMsg("(英雄)自觉头晕不已,酒虽为情所系,奈何量去甚多,暂无余力再饮!", TMsgColor.c_Red, TMsgType.t_Hint);
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.m_Master != null)
                    {
                        this.m_Master.SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, Parse(this.m_Master), 0, 0, GameMsgDef.g_sCanotUseItemMsg);
                    }
                }
                if (boEatOK)
                {
                    WeightChanged();
                    SendDefMessage(Grobal2.SM_HEROEAT_OK, 0, 0, 0, 0, "");
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("11" + "\09" + this.m_sMapName + "\09" + (this.m_nCurrX).ToString() + "\09" + (this.m_nCurrY).ToString()
                            + "\09" + this.m_sCharName + "\09" + StdItem->ToString() + "\09" + (UserItem34->MakeIndex).ToString() + "\09" + "(" + HUtil32.LoWord(StdItem->DC)
                            + "/" + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC) + "/" + (HUtil32.HiWord(StdItem->MC)).ToString()
                            + ")" + "(" + HUtil32.LoWord(StdItem->SC) + "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" + HUtil32.LoWord(StdItem->AC)
                            + "/" + HUtil32.HiWord(StdItem->AC) + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + HUtil32.HiWord(StdItem->MAC) + ")"
                            + (UserItem34->btValue[0]).ToString() + "/" + (UserItem34->btValue[1]).ToString() + "/" + (UserItem34->btValue[2]).ToString() + "/" + (UserItem34->btValue[3]).ToString()
                            + "/" + (UserItem34->btValue[4]).ToString() + "/" + (UserItem34->btValue[5]).ToString() + "/" + (UserItem34->btValue[6]).ToString() + "/" + (UserItem34->btValue[7]).ToString()
                            + "/" + (UserItem34->btValue[8]).ToString() + "/" + (UserItem34->btValue[14]).ToString() + "\09" + "0");
                    }
                }
                else
                {
                    SendDefMessage(Grobal2.SM_HEROEAT_FAIL, 0, 0, 0, 0, "");
                }
                if ((UserItem != null) && boSendUpDate)
                {
                    SendUpdateItem(UserItem);
                }
            }
            finally
            {
                ((TPlayObject)(this.m_Master)).m_boCanQueryBag = false;
            }
        }

        /// <summary>
        /// 负重改变
        /// </summary>
        public unsafe override void WeightChanged()
        {
            if (this.m_Master == null)
            {
                return;
            }
            this.m_WAbil.Weight = this.RecalcBagWeight();
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                SendUpdateMsg(this.m_Master, Grobal2.RM_HEROWEIGHTCHANGED, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// 刷新属性
        /// </summary>
        public void RefMyStatus()
        {
            RecalcAbilitys();
            this.CompareSuitItem(false);  // 套装与身上装备对比
            this.m_Master.SendMsg(this.m_Master, Grobal2.RM_MYSTATUS, 0, 1, 0, 0, "");
        }

        /// <summary>
        /// 使用物品
        /// </summary>
        /// <param name="StdItem"></param>
        /// <returns></returns>
        public unsafe bool EatItems(TStdItem* StdItem)
        {
            bool result;
            bool bo06;
            result = false;
            if (this.m_PEnvir.m_boNODRUG)
            {
                SysMsg(GameMsgDef.sCanotUseDrugOnThisMap, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                return result;
            }
            switch (StdItem->StdMode)
            {
                case 0:
                    switch (StdItem->Shape)
                    {
                        case 1:// 增加内功经验物品
                            this.IncHealthSpell(StdItem->AC, StdItem->MAC);
                            result = true;
                            break;
                        case 2://英雄不能使用内功物品  
                            this.m_boUserUnLockDurg = true;
                            result = true;
                            break;
                        case 3:
                            break;
                        default:
                            if ((StdItem->AC > 0))
                            {
                                this.m_nIncHealth += StdItem->AC;
                            }
                            if ((StdItem->MAC > 0))
                            {
                                this.m_nIncSpell += StdItem->MAC;
                            }
                            result = true;
                            break;
                    }
                    break;
                case 1:
                    result = false;
                    break;
                case 3:
                    if (StdItem->Shape == 12)
                    {
                        bo06 = false;
                        if (HUtil32.LoWord(StdItem->DC) > 0)
                        {
                            this.m_wStatusArrValue[0] = (ushort)HUtil32.LoWord(StdItem->DC);
                            this.m_dwStatusArrTimeOutTick[0] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("攻击力增加" + HUtil32.HiWord(StdItem->MAC) + "秒", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.LoWord(StdItem->MC) > 0)
                        {
                            this.m_wStatusArrValue[1] = (ushort)HUtil32.LoWord(StdItem->MC);
                            this.m_dwStatusArrTimeOutTick[1] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("魔法力增加" + HUtil32.HiWord(StdItem->MAC) + "秒", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if ((StdItem->SC) > 0)
                        {
                            this.m_wStatusArrValue[2] = (ushort)HUtil32.LoWord(StdItem->SC);
                            this.m_dwStatusArrTimeOutTick[2] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("道术增加" + HUtil32.HiWord(StdItem->MAC) + "秒", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.HiWord(StdItem->AC) > 0)
                        {
                            this.m_wStatusArrValue[3] = (ushort)HUtil32.HiWord(StdItem->AC);
                            this.m_dwStatusArrTimeOutTick[3] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("攻击速度增加" + HUtil32.HiWord(StdItem->MAC) + "秒", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.LoWord(StdItem->AC) > 0)
                        {
                            this.m_wStatusArrValue[4] = (ushort)HUtil32.LoWord(StdItem->AC);
                            this.m_dwStatusArrTimeOutTick[4] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("生命值增加" + HUtil32.HiWord(StdItem->MAC) + "秒", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.LoWord(StdItem->MAC) > 0)
                        {
                            this.m_wStatusArrValue[5] = (ushort)HUtil32.LoWord(StdItem->MAC);
                            this.m_dwStatusArrTimeOutTick[5] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("魔法值增加" + HUtil32.HiWord(StdItem->MAC) + "秒", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (bo06)
                        {
                            RecalcAbilitys();
                            this.CompareSuitItem(false);// 套装与身上装备对比
                            SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                            SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
                            result = true;
                        }
                    }
                    else
                    {
                        result = EatUseItems(StdItem->Shape);
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// 学习技能
        /// </summary>
        /// <param name="StdItem"></param>
        /// <returns></returns>
        public unsafe bool ReadBook(TStdItem* StdItem)
        {
            bool result;
            TMagic* Magic;
            TUserMagic* UserMagic = null;
            int I;
            byte btOldKey;
            result = false;
            if (!(new ArrayList(new int[] { 88, 89, 91 }).Contains(StdItem->NeedLevel)))
            {
                Magic = UserEngine.FindHeroMagic(StdItem->ToString());
                if (Magic != null)
                {
                    if (!this.IsTrainingSkill(Magic->wMagicId)) // 护体神盾不限制职业
                    {
                        if (((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "英雄")
                            || (HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "内功") || (HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "连击")) &&
                            ((Magic->btJob == 99) || (Magic->btJob == this.m_btJob) || (Magic->wMagicId == 75)))
                        {
                            if ((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "内功") || (HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "连击"))// 内功技能
                            {
                                if (m_boTrainingNG)  // 学过内功心法才能学习技能
                                {
                                    if (m_NGLevel >= Magic->TrainLevel[0])// 等级达到最低要求
                                    {
                                        UserMagic->MagicInfo = *Magic;
                                        UserMagic->wMagIdx = Magic->wMagicId;
                                        UserMagic->btKey = 0;
                                        UserMagic->btLevel = 0;
                                        UserMagic->nTranPoint = 0;
                                        this.m_MagicList.Add((IntPtr)UserMagic);
                                        RecalcAbilitys();
                                        this.CompareSuitItem(false);// 套装与身上装备对比
                                        SendAddMagic(UserMagic);
                                        ((TPlayObject)(this.m_Master)).HeroAddSkillFunc(Magic->wMagicId);// 英雄学技能触发
                                        result = true;
                                        if ((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "连击"))
                                        {
                                            this.m_boCanUseBatter = true;
                                        }
                                    }
                                    else
                                    {
                                        SysMsg(string.Format("(英雄) 内功心法等级没有达到 %d,不能学习此内功技能！！！", Magic->TrainLevel[0]), TMsgColor.c_Red, TMsgType.t_Hint);
                                    }
                                }
                                else
                                {
                                    SysMsg("(英雄) 没学过内功心法,不能学习此内功技能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                                }
                            }
                            else
                            {
                                // 普通技能
                                if ((Magic->wMagicId >= 60 && Magic->wMagicId <= 65) && (Magic->wMagicId != GetTogetherUseSpell()))
                                {
                                    SysMsg("(英雄) 不能学习此合击技能！！！", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                    return result;
                                }
                                if (this.m_Abil.Level >= Magic->TrainLevel[0])
                                {
                                    if ((Magic->wMagicId == 68) && ((m_MaxExp68 != 0) || (m_Exp68 != 0))) // 是酒气护体
                                    {
                                        m_MaxExp68 = 0;
                                        m_Exp68 = 0;
                                    }
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = Magic->wMagicId;
                                    UserMagic->btKey = 0;
                                    UserMagic->btLevel = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                    RecalcAbilitys();
                                    this.CompareSuitItem(false);// 套装与身上装备对比
                                    SendAddMagic(UserMagic);
                                    ((TPlayObject)(this.m_Master)).HeroAddSkillFunc(Magic->wMagicId);// 英雄学技能触发
                                    result = true;
                                }
                            }
                        }
                        else
                        {
                            SysMsg("(英雄) 不能学习此技能！！！", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(英雄) 已经学过此技能,不能再学习！！！", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                }
            }
            else
            {
                Magic = UserEngine.FindHeroMagic(StdItem->NeedLevel);
                if (this.m_Abil.Level >= Magic->TrainLevel[0])  // 英雄书
                {
                    if ((Magic != null) && (StdItem->AC == 1))
                    {
                        for (I = this.m_MagicList.Count - 1; I >= 0; I--)
                        {
                            if (this.m_MagicList.Count <= 0)
                            {
                                break;
                            }
                            UserMagic = (TUserMagic*)this.m_MagicList[I];
                            if (UserMagic != null)
                            {
                                if (((new ArrayList(new int[] { 26, 45, 13 }).Contains(UserMagic->wMagIdx)) && (UserMagic->btLevel < 4)) || (UserMagic->wMagIdx != StdItem->NeedLevel))
                                {
                                    if (UserMagic->MagicInfo.wMagicId == StdItem->Need)
                                    {
                                        ((this) as THeroObject).SendDelMagic(UserMagic);
                                        btOldKey = UserMagic->btKey;// 保存快捷键
                                        Marshal.FreeHGlobal((IntPtr)UserMagic);
                                        //Dispose(UserMagic);
                                        this.m_MagicList.RemoveAt(I);
                                        UserMagic->MagicInfo = *Magic;
                                        UserMagic->wMagIdx = Magic->wMagicId;
                                        UserMagic->btKey = btOldKey;
                                        UserMagic->btLevel = 4;
                                        UserMagic->nTranPoint = 0;
                                        this.m_MagicList.Add((IntPtr)UserMagic);
                                        ((this) as THeroObject).SendAddMagic(UserMagic);
                                        RecalcAbilitys();
                                        this.CompareSuitItem(false);// 套装与身上装备对比
                                        ((TPlayObject)(this.m_Master)).HeroAddSkillFunc(Magic->wMagicId);// 英雄学技能触发
                                        result = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        SysMsg("(英雄) 不能学习人物的技能！！！", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                }
                else
                {
                    SysMsg("(英雄) 不能学习此技能！！！", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        /// <summary>
        /// 发送增加的魔法
        /// </summary>
        /// <param name="UserMagic"></param>
        public unsafe void SendAddMagic(TUserMagic* UserMagic)
        {
            TClientMagic* ClientMagic = (TClientMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic)); ;
            ClientMagic->Key = (char)UserMagic->btKey;
            ClientMagic->Level = UserMagic->btLevel;
            ClientMagic->CurTrain = UserMagic->nTranPoint;
            ClientMagic->Def = UserMagic->MagicInfo;
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROADDMAGIC, 0, 0, 0, 1, 0);
            byte[] data = new byte[sizeof(TClientMagic)];
            fixed (byte* pb = data)
            {
                *(TClientMagic*)pb = *ClientMagic;
            }
            fixed (TDefaultMessage* msg = &this.m_DefMsg)
            {
                SendSocket(msg, EncryptUnit.EncodeBuffer(data, sizeof(TClientMagic)));
            }
        }

        /// <summary>
        /// 发送删除魔法
        /// </summary>
        /// <param name="UserMagic"></param>
        public unsafe void SendDelMagic(TUserMagic* UserMagic)
        {
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HERODELMAGIC, UserMagic->wMagIdx, 0, 0, 1, 0);
            fixed (TDefaultMessage* msg = &this.m_DefMsg)
            {
                SendSocket(msg, "");
            }
        }

        public bool IsEnoughBag()
        {
            bool result;
            result = false;
            if (this.m_ItemList.Count < m_nItemBagCount)
            {
                result = true;
            }
            return result;
        }

        public unsafe override void MakeWeaponUnlock()
        {
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return;
            }
            if (this.m_UseItems[TPosition.U_WEAPON]->btValue[3] > 0)
            {
                this.m_UseItems[TPosition.U_WEAPON]->btValue[3] -= 1;
                SysMsg(GameMsgDef.g_sTheWeaponIsCursed, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
            }
            else
            {
                if (this.m_UseItems[TPosition.U_WEAPON]->btValue[4] < 10)
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[4]++;
                    SysMsg(GameMsgDef.g_sTheWeaponIsCursed, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                RecalcAbilitys();
                this.CompareSuitItem(false);// 套装与身上装备对比
                SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// 使用祝福油,给武器加幸运
        /// </summary>
        /// <returns></returns>
        public unsafe bool WeaptonMakeLuck()
        {
            bool result;
            TStdItem* StdItem;
            int nRand;
            bool boMakeLuck;
            result = false;
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return result;
            }
            nRand = 0;
            StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_WEAPON]->wIndex);
            if (StdItem != null)
            {
                nRand = Math.Abs((HUtil32.HiWord(StdItem->DC) - HUtil32.LoWord(StdItem->DC))) / 5;
            }
            if (HUtil32.Random(GameConfig.nWeaponMakeUnLuckRate) == 1)
            {
                MakeWeaponUnlock();
            }
            else
            {
                boMakeLuck = false;
                if (this.m_UseItems[TPosition.U_WEAPON]->btValue[4] > 0)
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[4] -= 1;// '武器被加幸运了...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                else if (this.m_UseItems[TPosition.U_WEAPON]->btValue[3] < GameConfig.nWeaponMakeLuckPoint1)
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[3]++;// '武器被加幸运了...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                else if ((this.m_UseItems[TPosition.U_WEAPON]->btValue[3] < GameConfig.nWeaponMakeLuckPoint2) && (HUtil32.Random(nRand + GameConfig.nWeaponMakeLuckPoint2Rate) == 1))
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[3]++;// '武器被加幸运了...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                else if ((this.m_UseItems[TPosition.U_WEAPON]->btValue[3] < GameConfig.nWeaponMakeLuckPoint3) && (HUtil32.Random(nRand * GameConfig.nWeaponMakeLuckPoint3Rate) == 1))
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[3]++;// '武器被加幸运了...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    RecalcAbilitys();
                    this.CompareSuitItem(false);// 套装与身上装备对比
                    SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                    SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
                }
                if (!boMakeLuck)
                {
                    SysMsg(GameMsgDef.g_sWeaptonNotMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            result = true;
            return result;
        }

        /// <summary>
        /// 修复武器
        /// </summary>
        /// <returns></returns>
        public unsafe bool RepairWeapon()
        {
            bool result;
            int nDura;
            TUserItem* UserItem = null;
            result = false;
            *UserItem = *this.m_UseItems[TPosition.U_WEAPON];
            if ((UserItem->wIndex <= 0) || (UserItem->DuraMax <= UserItem->Dura))
            {
                return result;
            }
            UserItem->DuraMax -= Convert.ToUInt16((UserItem->DuraMax - UserItem->Dura) / GameConfig.nRepairItemDecDura);
            nDura = HUtil32._MIN(5000, UserItem->DuraMax - UserItem->Dura);
            if (nDura > 0)
            {
                UserItem->Dura += (ushort)nDura;
                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    SendMsg(this.m_Master, Grobal2.RM_HERODURACHANGE, 1, UserItem->Dura, UserItem->DuraMax, 0, "");  // '武器修复成功...'
                    SysMsg(GameMsgDef.g_sWeaponRepairSuccess, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 特等品武器修复
        /// </summary>
        /// <returns></returns>
        public unsafe bool SuperRepairWeapon()
        {
            bool result = false;
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return result;
            }
            this.m_UseItems[TPosition.U_WEAPON]->Dura = this.m_UseItems[TPosition.U_WEAPON]->DuraMax;
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                SendMsg(this.m_Master, Grobal2.RM_HERODURACHANGE, 1, this.m_UseItems[TPosition.U_WEAPON]->Dura, this.m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");// '武器修复成功...'
                SysMsg(GameMsgDef.g_sWeaponRepairSuccess, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
            }
            result = true;
            return result;
        }

        /// <summary>
        /// 英雄无极真气
        /// 0级提升道术40%   1级提升60%   2级提升80%  3级提升100%  时间都是6秒
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe bool AbilityUp(TUserMagic* UserMagic)
        {
            bool result;
            int nSpellPoint;
            int n14;
            result = false;
            nSpellPoint = GetSpellPoint(UserMagic);
            if (nSpellPoint > 0)
            {
                if (this.m_WAbil.MP < nSpellPoint)
                {
                    return result;
                }
                if (GameConfig.boAbilityUpFixMode)// 无极真气使用固定时长模式
                {
                    n14 = GameConfig.nAbilityUpFixUseTime;// 无极真气使用固定时长
                }
                else
                {
                    n14 = (UserMagic->btLevel * 2) + 2 + GameConfig.nAbilityUpUseTime;
                }
                this.m_dwStatusArrTimeOutTick[2] = Convert.ToUInt32(HUtil32.GetTickCount() + n14 * 1000);
                this.m_wStatusArrValue[2] = (ushort)HUtil32.Round(HUtil32.HiWord(this.m_WAbil.SC) * (UserMagic->btLevel * 0.2 + 0.4));// 提升值
                SysMsg("(英雄) 道术瞬时提升" + this.m_wStatusArrValue[2] + "，持续 " + n14 + " 秒", TMsgColor.c_Green, TMsgType.t_Hint);
                RecalcAbilitys();
                this.CompareSuitItem(false);// 套装与身上装备对比
                SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
                result = true;
            }
            return result;
        }

        public void GainExp(uint dwExp)
        {
            WinExp(dwExp);
        }

        // 取得经验
        public unsafe void WinExp(uint dwExp)
        {
            if (this.m_Abil.Level > GameConfig.nLimitExpLevel)
            {
                dwExp = GameConfig.nLimitExpValue;
                GetExp(dwExp);
            }
            else if (dwExp > 0)
            {
                dwExp = GameConfig.dwKillMonExpMultiple * dwExp;// 系统指定杀怪经验倍数
                dwExp = (uint)HUtil32.Round((double)(m_nKillMonExpRate / 100) * dwExp);// 人物指定的杀怪经验百分率
                if (this.m_PEnvir.m_boEXPRATE) // 地图上指定杀怪经验倍数
                {
                    dwExp = (uint)HUtil32.Round((double)(this.m_PEnvir.m_nEXPRATE / 100) * dwExp);
                }
                if (this.m_boExpItem)// 物品经验倍数
                {
                    dwExp = (uint)HUtil32.Round((double)this.m_rExpItem * dwExp);
                }
                GetExp(dwExp);
            }
        }

        /// <summary>
        /// 取得内力经验 
        /// </summary>
        /// <param name="dwExp"></param>
        /// <param name="Code">0-杀怪分配 1-非杀怪分配 2-饮酒,谁喝增加谁 3-主人分配杀怪经验</param>
        public unsafe void GetNGExp(uint dwExp, byte Code)
        {
            if (m_boTrainingNG)
            {
                if (this.m_Abil.Level > GameConfig.nLimitExpLevel)
                {
                    dwExp = GameConfig.nLimitExpValue;
                }
                else if ((dwExp > 0) && (Code == 0))
                {
                    dwExp = GameConfig.dwKillMonExpMultiple * dwExp;// 系统指定杀怪经验倍数
                    dwExp = (uint)HUtil32.Round((double)(m_nKillMonExpRate / 100) * dwExp);// 人物指定的杀怪经验百分率
                    if (this.m_PEnvir.m_boEXPRATE)
                    {
                        dwExp = (uint)HUtil32.Round((double)(this.m_PEnvir.m_nEXPRATE / 100) * dwExp);// 地图上指定杀怪经验倍数
                    }
                    if (this.m_boExpItem) // 物品经验倍数
                    {
                        dwExp = (uint)HUtil32.Round((double)this.m_rExpItem * dwExp);
                    }
                }
                else if ((dwExp > 0) && (Code == 3))
                {
                    dwExp = (uint)Math.Abs(HUtil32.Round((double)dwExp * GameConfig.dwKillMonNGExpMultiple / 100)); // 杀怪内功经验倍数
                }
                if ((dwExp > 0))
                {
                    if (m_ExpSkill69 >= dwExp)
                    {
                        if ((int.MaxValue - m_ExpSkill69) < dwExp)
                        {
                            dwExp = uint.MaxValue - m_ExpSkill69;
                        }
                    }
                    else
                    {
                        if ((int.MaxValue - dwExp) < m_ExpSkill69)
                        {
                            dwExp = int.MaxValue - dwExp;
                        }
                    }
                    m_ExpSkill69 += dwExp;// 内功心法当前经验
                    if (this.m_Master != null)
                    {
                        if (!((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
                        {
                            // 只发送给非离线挂机人物
                            SendMsg(this.m_Master, Grobal2.RM_HEROWINNHEXP, 0, dwExp, 0, 0, "");
                        }
                    }
                    if (m_ExpSkill69 >= m_MaxExpSkill69)
                    {
                        m_ExpSkill69 -= m_MaxExpSkill69;
                        m_NGLevel++;
                        m_MaxExpSkill69 = this.GetSkill69Exp(m_NGLevel, ref m_Skill69MaxNH);// 取内功心法升级经验
                        m_Skill69NH = m_Skill69MaxNH;
                        this.SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, m_Skill69NH, m_Skill69MaxNH, 0, "");// 内力值让别人看到
                        this.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, "");// 人物升级动画 
                        NGLevelUpFunc();// 内功升级触发
                    }
                    this.SendNGData();
                }
            }
        }

        /// <summary>
        /// 分配给英雄经验
        /// </summary>
        /// <param name="dwExp"></param>
        public unsafe void GetExp(uint dwExp)
        {
            byte nCode = 0;
            try
            {
                if (this.m_Abil.Exp >= dwExp)
                {
                    if ((int.MaxValue - this.m_Abil.Exp) < dwExp)
                    {
                        dwExp = uint.MaxValue - this.m_Abil.Exp;
                    }
                }
                else
                {
                    if ((int.MaxValue - dwExp) < this.m_Abil.Exp)
                    {
                        dwExp = int.MaxValue - dwExp;
                    }
                }
                m_GetExp = dwExp;// 英雄取得的经验,$HeroGetExp变量使用 
                if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
                {
                    M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroGetExp", false);// 取经验触发
                }
                this.m_nWinExp += dwExp;
                nCode = 1;
                if (this.m_nWinExp >= GameConfig.nWinExp) // 累计经验,达到一定值,增加英雄的忠诚度
                {
                    nCode = 2;
                    this.m_nWinExp = 0;
                    m_nLoyal = m_nLoyal + GameConfig.nExpAddLoyal;
                    if (m_nLoyal > 10000)
                    {
                        m_nLoyal = 10000;
                    }
                    nCode = 3;
                    this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROABILITY, this.m_btGender, 0, this.m_btJob, m_nLoyal, 0);// 更新英雄的忠诚度
                    byte[] data = new byte[sizeof(TAbility)];
                    fixed (byte* pb = data)
                    {
                        *(TAbility*)pb = this.m_WAbil;
                    }
                    SendSocket(this.m_DefMsg, EncryptUnit.EncodeBuffer(data, sizeof(TAbility)));
                }
                nCode = 4;
                this.m_Abil.Exp += dwExp;
                //AddBodyLuck(dwExp * 0.002);
                nCode = 5;
                if ((this.m_Master != null))
                {
                    //只发送给非离线挂机人物
                    if (!((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
                    {
                        SendMsg(this.m_Master, Grobal2.RM_HEROWINEXP, 0, dwExp, 0, 0, "");
                    }
                }
                if (this.m_Abil.Exp >= this.m_Abil.MaxExp)
                {
                    nCode = 6;
                    this.m_Abil.Exp -= this.m_Abil.MaxExp;
                    if ((this.m_Abil.Level < M2Share.MAXUPLEVEL) && (this.m_Abil.Level < GameConfig.nLimitExpLevel))
                    {
                        this.m_Abil.Level++; //增加限制等级
                    }
                    if (this.m_Abil.Level < GameConfig.nLimitExpLevel)
                    {
                        this.HasLevelUp(this.m_Abil.Level - 1); // 增加限制等级
                    }
                    // AddBodyLuck(100);
                    nCode = 7;
                    // 英雄升级记录日志
                    M2Share.AddGameDataLog("12" + "\09" + this.m_sMapName + "\09" + (this.m_Abil.Level).ToString() + "\09" + (this.m_Abil.Exp).ToString() + "/" + (this.m_Abil.MaxExp).ToString() + "\09" + this.m_sCharName + "\09" + "0" + "\09" + "0" + "\09" + "1" + "\09" + "(英雄)");
                    nCode = 8;
                    this.IncHealthSpell(2000, 2000);
                }
                nCode = 9;
                if (this.m_Magic68Skill != null) // 学过酒气护体
                {
                    nCode = 10;
                    if (this.m_Magic68Skill->btLevel < 100)
                    {
                        m_Exp68 += dwExp;
                    }
                    nCode = 11;
                    if (m_Exp68 >= m_MaxExp68)// 超过升级经验,则升级技能
                    {
                        m_Exp68 -= m_MaxExp68;
                        if (this.m_Magic68Skill->btLevel < 100)
                        {
                            this.m_Magic68Skill->btLevel++;
                        }
                        nCode = 12;
                        m_MaxExp68 = this.GetSkill68Exp(this.m_Magic68Skill->btLevel);
                        SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, this.m_Magic68Skill->MagicInfo.wMagicId, this.m_Magic68Skill->btLevel, this.m_Magic68Skill->nTranPoint, "", 100);
                    }
                    nCode = 13;
                    if ((this != null) && (this.m_Magic68Skill->btLevel < 100))
                    {
                        SendMsg(this, Grobal2.RM_HEROMAGIC68SKILLEXP, 0, 0, 0, 0, EncryptUnit.EncodeString(m_Exp68 + "/" + m_MaxExp68));
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.GetExp Code:" + nCode);
            }
        }

        /// <summary>
        /// 跑到目标坐标
        /// </summary>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <returns></returns>
        public bool RunToTargetXY(int nTargetX, int nTargetY)
        {
            bool result = false;
            byte nDir;
            int n10;
            int n14;
            if (this.m_boTransparent && (this.m_boHideMode))
            {
                this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;//隐身,一动就显身
            }
            if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && (!GameConfig.ClientConf.boParalyCanSpell)) // 麻痹不能跑动
            {
                return result;
            }
            if (!m_boCanRun) // 禁止跑,则退出
            {
                return result;
            }
            if (HUtil32.GetTickCount() - m_dwRunIntervalTime > GameConfig.dwRunIntervalTime)
            {
                n10 = nTargetX;
                n14 = nTargetY;
                nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, n10, n14);
                if (!this.RunTo(nDir, false, nTargetX, nTargetY))
                {
                    result = WalkToTargetXY(nTargetX, nTargetY);
                    if (result)
                    {
                        this.dwTick3F4 = HUtil32.GetTickCount();
                    }
                }
                else
                {
                    if ((Math.Abs(nTargetX - this.m_nCurrX) <= 1) && (Math.Abs(nTargetY - this.m_nCurrY) <= 1))
                    {
                        result = true;
                        m_dwRunIntervalTime = HUtil32.GetTickCount();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 走向目标
        /// </summary>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <returns></returns>
        public bool WalkToTargetXY(int nTargetX, int nTargetY)
        {
            bool result;
            int I;
            byte nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            result = false;
            if (this.m_boTransparent && (this.m_boHideMode))
            {
                this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;
            }
            //隐身,一动就显身
            if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && (!GameConfig.ClientConf.boParalyCanSpell))
            {
                return result;
            }
            // 麻痹不能跑动
            if ((Math.Abs(nTargetX - this.m_nCurrX) > 1) || (Math.Abs(nTargetY - this.m_nCurrY) > 1))
            {
                if (HUtil32.GetTickCount() - this.dwTick3F4 > m_dwWalkIntervalTime)
                {
                    // 增加走间隔
                    n10 = nTargetX;
                    n14 = nTargetY;
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
                    this.WalkTo(nDir, false);
                    if ((Math.Abs(nTargetX - this.m_nCurrX) <= 1) && (Math.Abs(nTargetY - this.m_nCurrY) <= 1))
                    {
                        result = true;
                        this.dwTick3F4 = HUtil32.GetTickCount();
                    }
                    if (!result)
                    {
                        n20 = HUtil32.Random(3);
                        for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                        {
                            if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                            {
                                if (n20 != 0)
                                {
                                    nDir++;
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
                                if ((Math.Abs(nTargetX - this.m_nCurrX) <= 1) && (Math.Abs(nTargetY - this.m_nCurrY) <= 1))
                                {
                                    result = true;
                                    this.dwTick3F4 = HUtil32.GetTickCount();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 转向
        /// </summary>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <returns></returns>
        public bool WalkToTargetXY2(int nTargetX, int nTargetY)
        {
            bool result;
            int I;
            byte nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            result = false;
            if (this.m_boTransparent && (this.m_boHideMode))
            {
                this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;
            }
            //隐身,一动就显身
            if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && (!GameConfig.ClientConf.boParalyCanSpell))
            {
                return result;
            }
            // 麻痹不能跑动
            if ((nTargetX != this.m_nCurrX) || (nTargetY != this.m_nCurrY))
            {
                if (HUtil32.GetTickCount() - this.dwTick3F4 > m_dwTurnIntervalTime)
                {
                    // 增加转向间隔
                    n10 = nTargetX;
                    n14 = nTargetY;
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
                    this.WalkTo(nDir, false);
                    if ((nTargetX == this.m_nCurrX) && (nTargetY == this.m_nCurrY))
                    {
                        result = true;
                        this.dwTick3F4 = HUtil32.GetTickCount();
                    }
                    if (!result)
                    {
                        n20 = HUtil32.Random(3);
                        for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                        {
                            if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                            {
                                if (n20 != 0)
                                {
                                    nDir++;
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
                                if ((nTargetX == this.m_nCurrX) && (nTargetY == this.m_nCurrY))
                                {
                                    result = true;
                                    this.dwTick3F4 = HUtil32.GetTickCount();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool GotoTargetXY(int nTargetX, int nTargetY, int nCode)
        {
            bool result = false;
            switch (nCode)
            {
                case 0:// 正常模式
                    if ((Math.Abs(this.m_nCurrX - nTargetX) > 2) || (Math.Abs(this.m_nCurrY - nTargetY) > 2))
                    {
                        if (this.m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] == 0)  // 增加,中珠网不能跑
                        {
                            result = RunToTargetXY(nTargetX, nTargetY);
                        }
                        else
                        {
                            result = WalkToTargetXY2(nTargetX, nTargetY);// 转向
                        }
                    }
                    else
                    {
                        result = WalkToTargetXY2(nTargetX, nTargetY);// 转向
                    }
                    break;
                case 1:// 躲避模式
                    if ((Math.Abs(this.m_nCurrX - nTargetX) > 1) || (Math.Abs(this.m_nCurrY - nTargetY) > 1))
                    {
                        if (this.m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] == 0)  // 增加,中珠网不能跑
                        {
                            result = RunToTargetXY(nTargetX, nTargetY);
                        }
                        else
                        {
                            result = WalkToTargetXY2(nTargetX, nTargetY);// 转向
                        }
                    }
                    else
                    {
                        result = WalkToTargetXY2(nTargetX, nTargetY);// 转向
                    }
                    break;
            }
            return result;
        }

        public unsafe override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            try
            {
                switch (ProcessMsg.wIdent)
                {
                    case Grobal2.RM_STRUCK:// 受物理打击
                        if ((GetObject<THeroObject>(ProcessMsg.BaseObject) == this) && (GetObject<TBaseObject>(ProcessMsg.nParam3) != null))
                        {
                            if (GetObject<TBaseObject>(ProcessMsg.nParam3).m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                if ((!GetObject<TBaseObject>(ProcessMsg.nParam3).InSafeZone()) && (!this.InSafeZone()))
                                {
                                    this.SetLastHiter(GetObject<TBaseObject>(ProcessMsg.nParam3));// 设置最后打击自己的人
                                    Struck(GetObject<TBaseObject>(ProcessMsg.nParam3));
                                    this.BreakHolySeizeMode();
                                }
                            }
                            else
                            {
                                this.SetLastHiter(GetObject<TBaseObject>(ProcessMsg.nParam3));// 设置最后打击自己的人
                                Struck(GetObject<TBaseObject>(ProcessMsg.nParam3));
                                this.BreakHolySeizeMode();
                            }
                            if ((this.m_Master != null) && (GetObject<TBaseObject>(ProcessMsg.nParam3) != this.m_Master)
                                && ((GetObject<TBaseObject>(ProcessMsg.nParam3).m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                || (GetObject<TBaseObject>(ProcessMsg.nParam3).m_btRaceServer == Grobal2.RC_HEROOBJECT)))
                            {
                                // 英雄灰色
                                this.m_Master.SetPKFlag(GetObject<TBaseObject>(ProcessMsg.nParam3));
                            }
                            if (GameConfig.boMonSayMsg)
                            {
                                this.MonsterSayMsg(GetObject<TBaseObject>(ProcessMsg.nParam3), TMonStatus.s_UnderFire);
                            }
                        }
                        result = true;
                        break;
                    default:
                        result = base.Operate(ProcessMsg);
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.Operate");
            }
            return result;
        }

        /// <summary>
        /// 被击中
        /// </summary>
        /// <param name="hiter"></param>
        public unsafe virtual void Struck(TBaseObject hiter)
        {
            if (!m_boTarget)
            {
                this.m_dwStruckTick = HUtil32.GetTickCount();
                if (hiter != null)
                {
                    if ((this.m_TargetCret == null) && !m_boTarget)
                    {
                        if (this.IsProperTarget(hiter))
                        {
                            this.SetTargetCreat(hiter);// 设置为目标
                        }
                    }
                }
                if (this.m_boAnimal)
                {
                    this.m_nMeatQuality = this.m_nMeatQuality - HUtil32.Random(300);
                    if (this.m_nMeatQuality < 0)
                    {
                        this.m_nMeatQuality = 0;
                    }
                }
            }
            this.m_dwHitTick = Convert.ToUInt32(this.m_dwHitTick + ((uint)150 - HUtil32._MIN(130, this.m_Abil.Level * 4)));
        }

        /// <summary>
        /// 攻击
        /// </summary>
        /// <param name="TargeTBaseObject"></param>
        /// <param name="nDir"></param>
        public virtual void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            if (this.m_boUseBatter && (m_wBatterHitMode >= 14 && m_wBatterHitMode <= 17))
            {
                base.AttackDir(TargeTBaseObject, m_wBatterHitMode, nDir);
            }
            else
            {
                base.AttackDir(TargeTBaseObject, m_wHitMode, nDir);
            }
        }

        /// <summary>
        /// 删除目标
        /// </summary>
        public override void DelTargetCreat()
        {
            base.DelTargetCreat();
            m_nTargetX = -1;
            m_nTargetY = -1;
        }

        /// <summary>
        /// 查找目标
        /// </summary>
        public void SearchTarget()
        {
            TBaseObject BaseObject;
            TBaseObject BaseObject18;
            int nC;
            int n10;
            if ((this.m_TargetCret == null) && m_boTarget)
            {
                m_boTarget = false;
            }
            if ((this.m_TargetCret != null) && m_boTarget)
            {
                if (this.m_TargetCret.m_boDeath)
                {
                    m_boTarget = false;
                }
            }
            if ((m_btStatus == 0) && !m_boTarget)// 守护状态一样查找目标 
            {
                BaseObject18 = null;
                n10 = 15;
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = (TBaseObject)this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY);
                                if (nC < n10)
                                {
                                    n10 = nC;
                                    BaseObject18 = BaseObject;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (BaseObject18 != null)
                {
                    this.SetTargetCreat(BaseObject18);
                }
            }
        }

        public virtual void SetTargetXY(int nX, int nY)
        {
            m_nTargetX = nX;
            m_nTargetY = nY;
        }

        public virtual void Wondering()
        {
            if ((HUtil32.Random(10) == 0))
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

        /// <summary>
        /// 是不是可以使用的魔法
        /// UserMagic->btKey 0-技能开,1--技能关
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        public unsafe bool IsAllowUseMagic(ushort wMagIdx)
        {
            bool result = false;
            TUserMagic* UserMagic = CheckUserMagic(wMagIdx);
            if (UserMagic != null)
            {
                if ((GetSpellPoint(UserMagic) < this.m_WAbil.MP) && (UserMagic->btKey == 0))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 搜索魔法
        /// </summary>
        /// <returns></returns>
        private unsafe int SelectMagic()
        {
            int result;
            result = 0;
            switch (this.m_btJob)
            {
                case 0:// 战士
                    // 受攻击时才开盾
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (this.m_ExpHitter != null) && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 3000))
                    {
                        // 使用 护体神盾
                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        result = 75;
                        return result;
                    }
                    if (IsAllowUseMagic(68) && (this.m_WAbil.MP > 30) && (HUtil32.GetTickCount() - m_SkillUseTick[68] > 3000))
                    {
                        // 酒气护体
                        if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))
                            {
                                m_SkillUseTick[68] = HUtil32.GetTickCount();
                                result = 68;
                                return result;
                            }
                        }
                    }
                    // 远距离则用开天重击或是逐日剑法
                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) >= 2) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) < 5)) || ((Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) >= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) < 5)))
                    {
                        if (IsAllowUseMagic(43) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > GameConfig.nKill43UseTime * 1000))
                        {
                            this.m_bo42kill = true;
                            this.m_n42kill = 2;// 重击
                            result = 43;
                            return result;
                        }
                        if (IsAllowUseMagic(74) && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 12000))
                        {
                            // 逐日剑法
                            this.m_boDailySkill = true;
                            result = 74;
                            return result;
                        }
                    }
                    if (IsAllowUseMagic(43) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > GameConfig.nKill43UseTime * 1000)) // 开天斩 
                    {
                        this.m_bo42kill = true;
                        result = 43;
                        if ((HUtil32.Random(GameConfig.n43KillHitRate) == 0) && (GameConfig.btHeroSkillMode43 || (this.m_TargetCret.m_Abil.Level <= this.m_Abil.Level))) // 目标等级不高于自己,才使用重击
                        {
                            this.m_n42kill = 2;// 重击
                        }
                        else
                        {
                            this.m_n42kill = 1;// 轻击
                        }
                        return result;
                    }
                    // 刺杀位
                    if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2))
                    {
                        if (IsAllowUseMagic(12))// 英雄刺杀剑术
                        {
                            if (!this.m_boUseThrusting)
                            {
                                this.ThrustingOnOff(true);
                            }
                            result = 12;
                            return result;
                        }
                    }
                    // 12 * 1000
                    if (IsAllowUseMagic(74) && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 12000))// 逐日剑法
                    {
                        this.m_boDailySkill = true;
                        result = 74;
                        return result;
                    }
                    // 9 * 1000
                    if (IsAllowUseMagic(26) && ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 9000))//烈火
                    {
                        this.m_boFireHitSkill = true;
                        result = 26;
                        return result;
                    }
                    if (IsAllowUseMagic(42) && (HUtil32.GetTickCount() - this.m_dwLatest43Tick > GameConfig.nKill42UseTime * 1000)) // 龙影剑法
                    {
                        this.m_bo43kill = true;
                        result = 42;
                        return result;
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                    {
                        // PK时,使用野蛮冲撞   血低于800时使用
                        // 10 * 1000
                        if (IsAllowUseMagic(27) && ((HUtil32.GetTickCount() - m_SkillUseTick[27]) > 10000))
                        {
                            // pk时如果对方等级比自己低就每隔一段时间用一次野蛮 
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    else
                    {
                        // 打怪使用
                        // 10 * 1000
                        if (IsAllowUseMagic(27) && ((HUtil32.GetTickCount() - m_SkillUseTick[27]) > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level)
                            && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.85)))
                        {
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    if ((this.m_TargetCret.m_Master != null))
                    {
                        this.m_ExpHitter = this.m_TargetCret.m_Master;
                    }
                    // 20080924
                    if (CheckTargetXYCount1(this.m_nCurrX, this.m_nCurrY, 1) > 1)
                    {
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // 被怪物包围
                                //  PK时不用狮子吼
                                // 10 * 1000
                                if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level)
                                    && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                    && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                                {
                                    m_SkillUseTick[41] = HUtil32.GetTickCount();// 狮子吼
                                    result = 41;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))
                                {
                                    // 攻杀剑术
                                    m_SkillUseTick[7] = HUtil32.GetTickCount();
                                    this.m_boPowerHit = true;// 开启刺杀
                                    result = 7;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 10000))
                                {
                                    m_SkillUseTick[39] = HUtil32.GetTickCount();// 英雄彻地钉
                                    result = 39;
                                    return result;
                                }
                                if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0))
                                {
                                    // 英雄半月弯刀
                                    if (!this.m_boUseHalfMoon)
                                    {
                                        this.HalfMoonOnOff(true);
                                    }
                                    result = 25;
                                    return result;
                                }
                                if (IsAllowUseMagic(40))
                                {
                                    // 英雄抱月刀法
                                    if (!this.m_boCrsHitkill)
                                    {
                                        this.SkillCrsOnOff(true);
                                    }
                                    result = 40;
                                    return result;
                                }
                                if (IsAllowUseMagic(12))
                                {
                                    // 英雄刺杀剑术
                                    if (!this.m_boUseThrusting)
                                    {
                                        this.ThrustingOnOff(true);
                                    }
                                    result = 12;
                                    return result;
                                }
                                break;
                            case 1:// 10 * 1000
                                if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                                {
                                    m_SkillUseTick[41] = HUtil32.GetTickCount();// 狮子吼
                                    result = 41;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))
                                {
                                    // 攻杀剑术 20071213
                                    m_SkillUseTick[7] = HUtil32.GetTickCount();
                                    this.m_boPowerHit = true;// 开启刺杀
                                    result = 7;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 10000))
                                {
                                    m_SkillUseTick[39] = HUtil32.GetTickCount();// 英雄彻地钉
                                    result = 39;
                                    return result;
                                }
                                if (IsAllowUseMagic(40))
                                {
                                    // 英雄抱月刀法
                                    if (!this.m_boCrsHitkill)
                                    {
                                        this.SkillCrsOnOff(true);
                                    }
                                    result = 40;
                                    return result;
                                }
                                if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0))
                                {
                                    // 英雄半月弯刀
                                    if (!this.m_boUseHalfMoon)
                                    {
                                        this.HalfMoonOnOff(true);
                                    }
                                    result = 25;
                                    return result;
                                }
                                if (IsAllowUseMagic(12))
                                {
                                    // 英雄刺杀剑术
                                    if (!this.m_boUseThrusting)
                                    {
                                        this.ThrustingOnOff(true);
                                    }
                                    result = 12;
                                    return result;
                                }
                                break;
                            case 2:// 10 * 1000
                                if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                                {
                                    m_SkillUseTick[41] = HUtil32.GetTickCount();
                                    // 狮子吼
                                    result = 41;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 10000))
                                {
                                    m_SkillUseTick[39] = HUtil32.GetTickCount();
                                    // 英雄彻地钉
                                    result = 39;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))
                                {
                                    // 攻杀剑术
                                    m_SkillUseTick[7] = HUtil32.GetTickCount();
                                    this.m_boPowerHit = true;// 开启刺杀
                                    result = 7;
                                    return result;
                                }
                                if (IsAllowUseMagic(40))
                                {
                                    // 英雄抱月刀法
                                    if (!this.m_boCrsHitkill)
                                    {
                                        this.SkillCrsOnOff(true);
                                    }
                                    result = 40;
                                    return result;
                                }
                                if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0))
                                {
                                    // 英雄半月弯刀
                                    if (!this.m_boUseHalfMoon)
                                    {
                                        this.HalfMoonOnOff(true);
                                    }
                                    result = 25;
                                    return result;
                                }
                                if (IsAllowUseMagic(12))
                                {
                                    // 英雄刺杀剑术
                                    if (!this.m_boUseThrusting)
                                    {
                                        this.ThrustingOnOff(true);
                                    }
                                    result = 12;
                                    return result;
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (CheckTargetXYCount1(this.m_nCurrX, this.m_nCurrY, 1) > 1))
                        {
                            // 身边超过2个目标才使用
                            if (IsAllowUseMagic(40) && (HUtil32.GetTickCount() - m_SkillUseTick[40] > 3000))
                            {
                                // 英雄抱月刀法
                                m_SkillUseTick[40] = HUtil32.GetTickCount();
                                if (!this.m_boCrsHitkill)
                                {
                                    this.SkillCrsOnOff(true);
                                }
                                result = 40;
                                return result;
                            }
                            if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0) && (HUtil32.GetTickCount() - m_SkillUseTick[25] > 1500))
                            {
                                // 英雄半月弯刀

                                m_SkillUseTick[25] = HUtil32.GetTickCount();
                                if (!this.m_boUseHalfMoon)
                                {
                                    this.HalfMoonOnOff(true);
                                }
                                result = 25;
                                return result;
                            }
                        }
                        // 增加 少于三个怪用 刺杀剑术
                        // 10 * 1000
                        if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))  // 攻杀剑术
                        {
                            m_SkillUseTick[7] = HUtil32.GetTickCount();
                            this.m_boPowerHit = true;//开启攻杀
                            result = 7;
                            return result;
                        }
                        if (IsAllowUseMagic(12) && (HUtil32.GetTickCount() - m_SkillUseTick[12] > 1000))
                        {
                            // 英雄刺杀剑术
                            if (!this.m_boUseThrusting)
                            {
                                this.ThrustingOnOff(true);
                            }
                            m_SkillUseTick[12] = HUtil32.GetTickCount();
                            result = 12;
                            return result;
                        }
                    }
                    // 从高到低使用魔法
                    if (IsAllowUseMagic(43) && (HUtil32.GetTickCount() - this.m_dwLatest42Tick > GameConfig.nKill43UseTime * 1000))
                    {
                        // 开天斩
                        this.m_bo42kill = true;
                        result = 43;
                        if ((HUtil32.Random(GameConfig.n43KillHitRate) == 0) && (GameConfig.btHeroSkillMode43 || (this.m_TargetCret.m_Abil.Level <= this.m_Abil.Level)))
                        {
                            this.m_n42kill = 2;// 重击
                        }
                        else
                        {
                            this.m_n42kill = 1;// 轻击
                        }
                        return result;
                    }
                    else if (IsAllowUseMagic(42) && (HUtil32.GetTickCount() - this.m_dwLatest43Tick > GameConfig.nKill42UseTime * 1000))
                    {
                        // 龙影剑法
                        this.m_bo43kill = true;
                        result = 42;
                        return result;
                    }
                    else if (IsAllowUseMagic(74) && (HUtil32.GetTickCount() - this.m_dwLatestDailyTick > 12000))
                    {
                        // 逐日剑法
                        this.m_boDailySkill = true;
                        result = 74;
                        return result;
                    }
                    else if (IsAllowUseMagic(26) && (HUtil32.GetTickCount() - this.m_dwLatestFireHitTick > 9000))
                    {
                        // 烈火
                        this.m_boFireHitSkill = true;
                        result = 26;
                        return result;
                    }
                    if (IsAllowUseMagic(40) && (HUtil32.GetTickCount() - m_SkillUseTick[40] > 3000) && (CheckTargetXYCount1(this.m_nCurrX, this.m_nCurrY, 1) > 1))
                    {
                        // 英雄抱月刀法
                        if (!this.m_boCrsHitkill)
                        {
                            this.SkillCrsOnOff(true);
                        }
                        m_SkillUseTick[40] = HUtil32.GetTickCount();
                        result = 40;
                        return result;
                    }
                    if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 3000))
                    {
                        // 英雄彻地钉

                        m_SkillUseTick[39] = HUtil32.GetTickCount();
                        result = 39;
                        return result;
                    }
                    if (IsAllowUseMagic(25) && (HUtil32.GetTickCount() - m_SkillUseTick[25] > 3000) && (CheckTargetXYCount2() > 0))
                    {
                        // 英雄半月弯刀
                        if (!this.m_boUseHalfMoon)
                        {
                            this.HalfMoonOnOff(true);
                        }
                        m_SkillUseTick[25] = HUtil32.GetTickCount();
                        result = 25;
                        return result;
                    }

                    if (IsAllowUseMagic(12) && (HUtil32.GetTickCount() - m_SkillUseTick[12] > 3000))
                    {
                        // 英雄刺杀剑术
                        if (!this.m_boUseThrusting)
                        {
                            this.ThrustingOnOff(true);
                        }
                        m_SkillUseTick[12] = HUtil32.GetTickCount();
                        result = 12;
                        return result;
                    }
                    if (IsAllowUseMagic(7) && (HUtil32.GetTickCount() - m_SkillUseTick[7] > 3000))
                    {
                        // 攻杀剑术
                        this.m_boPowerHit = true;
                        m_SkillUseTick[7] = HUtil32.GetTickCount();
                        result = 7;
                        return result;
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.6)))
                    {
                        // PK时,使用野蛮冲撞

                        if (IsAllowUseMagic(27) && (HUtil32.GetTickCount() - m_SkillUseTick[27] > 3000))
                        {
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    else
                    {
                        // 打怪使用
                        if (IsAllowUseMagic(27) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.6))
                            && (HUtil32.GetTickCount() - m_SkillUseTick[27] > 3000))
                        {
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level)
                        && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3)
                        && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                    {
                        // 狮子吼
                        m_SkillUseTick[41] = HUtil32.GetTickCount();
                        result = 41;
                        return result;
                    }
                    break;
                case 1:
                    // 法师
                    // 使用 护体神盾
                    // 受攻击时才开盾
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (this.m_ExpHitter != null)
                        && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 3000))
                    {
                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        result = 75;
                        return result;
                    }
                    // 使用 魔法盾
                    if ((this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence))
                    {
                        if (IsAllowUseMagic(66))// 4级魔法盾
                        {
                            result = 66;
                            return result;
                        }
                        if (IsAllowUseMagic(31))
                        {
                            result = 31;
                            return result;
                        }
                    }
                    // 酒气护体
                    if (IsAllowUseMagic(68) && (this.m_WAbil.MP > 30) && (HUtil32.GetTickCount() - m_SkillUseTick[68] > 3000))
                    {
                        if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))
                            {
                                m_SkillUseTick[68] = HUtil32.GetTickCount();
                                result = 68;
                                return result;
                            }
                        }
                    }
                    // 分身不存在,则使用分身术
                    // 召唤分身间隔
                    if ((this.m_SlaveList.Count == 0) && IsAllowUseMagic(46) && ((HUtil32.GetTickCount() - this.m_dwLatest46Tick) > GameConfig.nCopyHumanTick * 1000)
                        && ((GameConfig.btHeroSkillMode46) || (this.m_LastHiter != null) || (this.m_ExpHitter != null)))
                    {
                        if (m_Magic46Skill != null)
                        {
                            switch (m_Magic46Skill->btLevel)
                            {
                                case 0:
                                    // 按技能等级及等级激活参数来判断是否可使用分身术
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_0 / 100))))
                                    {
                                        //受到攻击后,HP低于80%才使用分身
                                        result = 46;
                                        return result;
                                    }
                                    break;
                                case 1:
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_1 / 100))))
                                    {
                                        // 1级 英雄召唤分身HP的比率 20081217
                                        result = 46;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_2 / 100))))
                                    {
                                        // 1级 英雄召唤分身HP的比率 20081217
                                        result = 46;
                                        return result;
                                    }
                                    break;
                                case 3:
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_3 / 100))))
                                    {
                                        // 1级 英雄召唤分身HP的比率 20081217
                                        result = 46;
                                        return result;
                                    }
                                    break;
                            }
                            // case
                        }
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null))
                        && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                    {
                        // PK时,旁边有人贴身,使用抗拒火环

                        // 3 * 1000
                        if (IsAllowUseMagic(8) && ((HUtil32.GetTickCount() - m_SkillUseTick[8]) > 3000))
                        {

                            m_SkillUseTick[8] = HUtil32.GetTickCount();
                            result = 8;
                            return result;
                        }
                    }
                    else
                    {
                        // 打怪,怪级低于自己,并且有怪包围自己就用 抗拒火环

                        // 3 * 1000
                        if (IsAllowUseMagic(8) && ((HUtil32.GetTickCount() - m_SkillUseTick[8]) > 3000) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0)
                            && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                        {

                            m_SkillUseTick[8] = HUtil32.GetTickCount();
                            result = 8;
                            return result;
                        }
                    }
                    if ((m_nLoyal >= 500) && ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)))
                    {

                        if (IsAllowUseMagic(45) && (HUtil32.GetTickCount() - m_SkillUseTick[45] > 1300))
                        {
                            // 忠诚度5%时，PK时使用灭天火次数多 20080828

                            m_SkillUseTick[45] = HUtil32.GetTickCount();
                            result = 45;
                            // 英雄灭天火
                            return result;
                        }
                    }
                    else
                    {

                        // 1000 * 3
                        if (IsAllowUseMagic(45) && (HUtil32.GetTickCount() - m_SkillUseTick[45] > 3000))
                        {

                            m_SkillUseTick[45] = HUtil32.GetTickCount();
                            result = 45;
                            // 英雄灭天火
                            return result;
                        }
                    }

                    // 1000 * 5
                    if ((HUtil32.GetTickCount() - m_SkillUseTick[10] > 5000) && this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY))
                    {
                        if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null))
                            && (this.GetDirBaseObjectsCount(this.m_btDirection, 5) > 0) && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                        {
                            if (IsAllowUseMagic(10))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 10;// 英雄疾光电影 
                                return result;
                            }
                            else if (IsAllowUseMagic(9))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 9;// 地狱火
                                return result;
                            }
                        }
                        else if ((this.GetDirBaseObjectsCount(this.m_btDirection, 5) > 1) && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                        {
                            if (IsAllowUseMagic(10))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 10;// 英雄疾光电影
                                return result;
                            }
                            else if (IsAllowUseMagic(9))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 9;// 地狱火
                                return result;
                            }
                        }
                    }
                    // 1000 * 10
                    if (IsAllowUseMagic(32) && (HUtil32.GetTickCount() - m_SkillUseTick[32] > 10000) && (this.m_TargetCret.m_Abil.Level < GameConfig.nMagTurnUndeadLevel)
                        && (this.m_TargetCret.m_btLifeAttrib == Grobal2.LA_UNDEAD) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level - 1))
                    {
                        // 目标为不死系
                        m_SkillUseTick[32] = HUtil32.GetTickCount();
                        result = 32;// 圣言术
                        return result;
                    }
                    if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 2) > 1)
                    {
                        // 被怪物包围
                        // 10 * 1000
                        if (IsAllowUseMagic(22) && (HUtil32.GetTickCount() - m_SkillUseTick[22] > 10000) && (M2Share.g_EventManager.GetRangeEvent(this.m_PEnvir, this, this.m_nCurrX, this.m_nCurrY, 6, Grobal2.ET_FIRE) != 0))
                        {
                            if ((this.m_TargetCret.m_btRaceServer != 101) && (this.m_TargetCret.m_btRaceServer != 102) && (this.m_TargetCret.m_btRaceServer != 104))
                            {
                                // 除祖玛怪,才放火墙 20081217

                                m_SkillUseTick[22] = HUtil32.GetTickCount();
                                result = 22;
                                // 火墙
                                return result;
                            }
                        }
                        // 地狱雷光,只对祖玛(101,102,104)，沃玛(91,92,97)，野猪(81)系列的用   20080217
                        // 遇到祖玛的怪应该多用地狱雷光，夹杂雷电术，少用冰咆哮 20080228
                        if (new ArrayList(new int[] { 91, 92, 97, 101, 102, 104 }).Contains(this.m_TargetCret.m_btRaceServer))
                        {
                            // 1000 * 4
                            if (IsAllowUseMagic(24) && (HUtil32.GetTickCount() - m_SkillUseTick[24] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                            {
                                m_SkillUseTick[24] = HUtil32.GetTickCount();
                                result = 24;
                                // 地狱雷光
                                return result;
                            }
                            else if (IsAllowUseMagic(11))
                            {
                                result = 11;
                                // 英雄雷电术
                                return result;
                            }
                            else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 2) > 2))
                            {
                                result = 33;
                                // 英雄冰咆哮
                                return result;
                            }
                            // 1000 * 4
                            else if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                            {
                                m_SkillUseTick[58] = HUtil32.GetTickCount();
                                result = 58;// 流星火雨
                                return result;
                            }
                        }
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // 随机选择魔法
                                // 火球术,大火球,雷电术,爆裂火焰,英雄冰咆哮,流星火雨 从高到低选择
                                // 1000 * 4
                                if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                                {
                                    m_SkillUseTick[58] = HUtil32.GetTickCount();
                                    result = 58;
                                    // 流星火雨
                                    return result;
                                }
                                else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 33;
                                    // 英雄冰咆哮
                                    return result;
                                }
                                else if (IsAllowUseMagic(23) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 23;
                                    // 爆裂火焰
                                    return result;
                                }
                                else if (IsAllowUseMagic(11))
                                {
                                    result = 11;
                                    // 英雄雷电术
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;
                                    // 大火球
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;
                                    // 火球术
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    // 英雄群体雷电
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    // 火龙焰
                                    return result;
                                }
                                break;
                            case 1:
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                // 1000 * 4
                                if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                                {
                                    m_SkillUseTick[58] = HUtil32.GetTickCount();
                                    result = 58;
                                    // 流星火雨
                                    return result;
                                }
                                else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    // 火球术,大火球,地狱火,爆裂火焰,冰咆哮  从高到低选择
                                    result = 33;
                                    // 冰咆哮
                                    return result;
                                }
                                else if (IsAllowUseMagic(23) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 23;
                                    // 爆裂火焰
                                    return result;
                                }
                                else if (IsAllowUseMagic(11))
                                {
                                    result = 11;
                                    // 英雄雷电术
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;
                                    // 大火球
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;
                                    // 火球术
                                    return result;
                                }
                                break;
                            case 2:
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                // 1000 * 4
                                if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                                {
                                    m_SkillUseTick[58] = HUtil32.GetTickCount();
                                    result = 58;// 流星火雨
                                    return result;
                                }
                                else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    // 火球术,大火球,地狱火,爆裂火焰 从高到低选择
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 23;// 爆裂火焰
                                    return result;
                                }
                                else if (IsAllowUseMagic(11))
                                {
                                    result = 11;// 英雄雷电术
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;// 大火球
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;// 火球术
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                break;
                        }
                    }
                    else
                    {
                        // 只有一个怪时所用的魔法
                        // 10 * 1000
                        if (IsAllowUseMagic(22) && (HUtil32.GetTickCount() - m_SkillUseTick[22] > 10000) && (M2Share.g_EventManager.GetRangeEvent(this.m_PEnvir, this, this.m_nCurrX, this.m_nCurrY, 6, Grobal2.ET_FIRE) == 0))
                        {
                            if ((this.m_TargetCret.m_btRaceServer != 101) && (this.m_TargetCret.m_btRaceServer != 102) && (this.m_TargetCret.m_btRaceServer != 104))
                            {
                                // 除祖玛怪,才放火墙
                                m_SkillUseTick[22] = HUtil32.GetTickCount();
                                result = 22;
                                return result;
                            }
                        }
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // 随机选择魔法
                                if (IsAllowUseMagic(11))
                                {
                                    result = 11;// 雷电术
                                    return result;
                                }
                                else if (IsAllowUseMagic(33))
                                {
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23))
                                {
                                    // 火球术,大火球,地狱火,爆裂火焰 从高到低选择
                                    result = 23;// 爆裂火焰
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;// 大火球
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;// 火球术
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                break;
                            case 1:
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                if (IsAllowUseMagic(11))
                                {
                                    result = 11;
                                    // 雷电术
                                    return result;
                                }
                                else if (IsAllowUseMagic(33))
                                {
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23))
                                {
                                    result = 23;// 爆裂火焰
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;// 大火球
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;// 火球术
                                    return result;
                                }
                                break;
                            case 2:
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                if (IsAllowUseMagic(11))
                                {
                                    result = 11;// 雷电术
                                    return result;
                                }
                                else if (IsAllowUseMagic(33))
                                {
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23))
                                {
                                    result = 23;// 爆裂火焰
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;
                                    // 大火球
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;
                                    // 火球术
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                break;
                            // end;
                        }
                    }
                    // 从高到低使用魔法 20080710

                    // 1000 * 4
                    if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000))
                    {
                        // 流星火雨

                        m_SkillUseTick[58] = HUtil32.GetTickCount();
                        result = 58;
                        return result;
                    }
                    if (IsAllowUseMagic(47))
                    {
                        // 火龙焰
                        result = 47;
                        return result;
                    }
                    if (IsAllowUseMagic(45))
                    {
                        // 英雄灭天火
                        result = 45;
                        return result;
                    }
                    if (IsAllowUseMagic(37))
                    {
                        // 英雄群体雷电
                        result = 37;
                        return result;
                    }
                    if (IsAllowUseMagic(33))
                    {
                        // 英雄冰咆哮
                        result = 33;
                        return result;
                    }
                    if (IsAllowUseMagic(32) && (this.m_TargetCret.m_Abil.Level < GameConfig.nMagTurnUndeadLevel) && (this.m_TargetCret.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                        && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level - 1))
                    {
                        // 目标为不死系
                        result = 32;
                        // 圣言术 20080710
                        return result;
                    }
                    if (IsAllowUseMagic(24) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                    {
                        // 地狱雷光
                        result = 24;
                        return result;
                    }
                    if (IsAllowUseMagic(23))
                    {
                        // 爆裂火焰
                        result = 23;
                        return result;
                    }
                    if (IsAllowUseMagic(11))
                    {
                        // 英雄雷电术
                        result = 11;
                        return result;
                    }
                    if (IsAllowUseMagic(10) && this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)
                        && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) ||
                        (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                    {
                        result = 10;
                        // 英雄疾光电影
                        return result;
                    }
                    if (IsAllowUseMagic(9) && this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)
                        && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0))
                        || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) ||
                        (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                    {
                        result = 9;
                        // 地狱火
                        return result;
                    }
                    if (IsAllowUseMagic(5))
                    {
                        result = 5;
                        // 大火球
                        return result;
                    }
                    if (IsAllowUseMagic(1))
                    {
                        result = 1;
                        // 火球术
                        return result;
                    }
                    if (IsAllowUseMagic(22) && (M2Share.g_EventManager.GetRangeEvent(this.m_PEnvir, this, this.m_nCurrX, this.m_nCurrY, 6, Grobal2.ET_FIRE) != 0))
                    {
                        if ((this.m_TargetCret.m_btRaceServer != 101) && (this.m_TargetCret.m_btRaceServer != 102) && (this.m_TargetCret.m_btRaceServer != 104))
                        {
                            // 除祖玛怪,才放火墙 20081217
                            result = 22;
                            // 火墙
                            return result;
                        }
                    }
                    break;
                case 2:
                    // 道士
                    // 英雄HP值等于或少于60%时,使用治愈术 20080204 修改
                    if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)))
                    {
                        // 使用治愈术
                        // 1000 * 3
                        if (IsAllowUseMagic(2) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000))
                        {
                            // 使用治愈术
                            m_SkillUseTick[2] = HUtil32.GetTickCount();
                            result = 2;
                            return result;
                        }
                    }
                    // 主人HP值等于或少于60%时,使用群体治愈术
                    if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)))
                    {
                        if (CheckMasterXYOfDirection(this.m_Master, m_nTargetX, m_nTargetY, this.m_btDirection, 3) >= 1)
                        {
                            // 判断主人与英雄的距离
                            // 1000 * 3
                            if (IsAllowUseMagic(29) && (HUtil32.GetTickCount() - m_SkillUseTick[29] > 3000))
                            {
                                // 使用群体治愈术
                                m_SkillUseTick[29] = HUtil32.GetTickCount();
                                result = 29;
                            }
                            // 1000 * 3
                            else if (IsAllowUseMagic(2) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000))
                            {
                                // 使用治愈术
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                result = 2;
                            }
                        }
                        else
                        {
                            // 1000 * 3
                            if (IsAllowUseMagic(2) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000))
                            {
                                // 使用治愈术
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                result = 2;
                            }
                        }
                        if (result > 0)
                        {
                            return result;
                        }
                    }
                    if ((this.m_SlaveList.Count == 0) && CheckHeroAmulet(1, 5) && (HUtil32.GetTickCount() - m_SkillUseTick[17] > 1000 * 3) && (IsAllowUseMagic(72) || IsAllowUseMagic(30) || IsAllowUseMagic(17)) && (this.m_WAbil.MP > 20))
                    {
                        m_SkillUseTick[17] = HUtil32.GetTickCount();
                        // 默认,从高到低
                        if (IsAllowUseMagic(72))
                        {
                            // 召唤月灵
                            result = 72;
                        }
                        else if (IsAllowUseMagic(30))
                        {
                            // 召唤神兽
                            result = 30;
                        }
                        else if (IsAllowUseMagic(17))
                        {
                            result = 17;
                        }
                        // 召唤骷髅
                        return result;
                    }
                    // 受攻击时才开盾
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (this.m_ExpHitter != null) && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 3000))
                    {
                        // 使用 护体神盾 20080107

                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        // 20080228
                        result = 75;
                        return result;
                    }
                    if ((this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence))
                    {
                        if (IsAllowUseMagic(73))
                        {
                            // 道力盾 
                            result = 73;
                            return result;
                        }
                    }
                    // 酒气护体 
                    if (IsAllowUseMagic(68) && (this.m_WAbil.MP > 30) && (HUtil32.GetTickCount() - m_SkillUseTick[68] > 3000))
                    {
                        if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))
                            {
                                m_SkillUseTick[68] = HUtil32.GetTickCount();
                                result = 68;
                                return result;
                            }
                        }
                    }
                    if (CheckHeroAmulet(1, 1) && (this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] == 0))
                    {
                        // 被怪物包围时,才用隐身术,PK时不用 
                        if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 2) > 1) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                        {
                            if (IsAllowUseMagic(19) && (HUtil32.GetTickCount() - m_SkillUseTick[19] > 8000))
                            {
                                // 英雄群体隐身术 20081214
                                m_SkillUseTick[19] = HUtil32.GetTickCount();
                                result = 19;
                                return result;
                            }

                            else if (IsAllowUseMagic(18) && (HUtil32.GetTickCount() - m_SkillUseTick[18] > 8000))
                            {
                                // 英雄隐身术 20081214

                                m_SkillUseTick[18] = HUtil32.GetTickCount();
                                result = 18;
                                return result;
                            }
                        }
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level <= this.m_WAbil.Level))
                    {
                        // PK时,旁边有人贴身,使用气功波
                        // 3 * 1000
                        if (IsAllowUseMagic(48) && ((HUtil32.GetTickCount() - m_SkillUseTick[48]) > 3000))
                        {
                            m_SkillUseTick[48] = HUtil32.GetTickCount();
                            result = 48;
                            return result;
                        }
                    }
                    else
                    {
                        // 打怪,怪级低于自己,并且有怪包围自己就用 气功波
                        // 20090108 由3秒改到5秒
                        if (IsAllowUseMagic(48) && ((HUtil32.GetTickCount() - m_SkillUseTick[48]) > 5000) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level <= this.m_WAbil.Level))
                        {
                            m_SkillUseTick[48] = HUtil32.GetTickCount();
                            result = 48;
                            return result;
                        }
                    }

                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && (GetUserItemList(2, 1) >= 0) && ((GameConfig.btHeroSkillMode) || (this.m_TargetCret.m_Abil.HP >= 700) || ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYMOSTER)) || m_boTarget) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) < 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) < 7)) && (this.m_TargetCret.m_btRaceServer != 110) && (this.m_TargetCret.m_btRaceServer != 111) && (this.m_TargetCret.m_btRaceServer != 55) && (this.m_TargetCret.m_btRaceServer != 128))
                    {
                        // 对于血量超过800的怪用  修改距离 20080704 不毒城墙
                        n_AmuletIndx = 0;
                        switch (HUtil32.Random(2))
                        {
                            case 0:
                                // 20080413

                                if (IsAllowUseMagic(38) && (HUtil32.GetTickCount() - m_SkillUseTick[38] > 1000))
                                {

                                    m_SkillUseTick[38] = HUtil32.GetTickCount();
                                    result = 38;
                                    // 英雄群体施毒
                                    return result;
                                }

                                else if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // 英雄施毒术
                                    return result;
                                }
                                break;
                            case 1:

                                if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // 英雄施毒术
                                    return result;
                                }
                                break;
                        }
                    }
                    // 红毒
                    // 4
                    // 4
                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && (GetUserItemList(2, 2) >= 0) && ((GameConfig.btHeroSkillMode) || (this.m_TargetCret.m_Abil.HP >= 700) || ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYMOSTER)) || m_boTarget) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) < 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) < 7)) && (this.m_TargetCret.m_btRaceServer != 110) && (this.m_TargetCret.m_btRaceServer != 111) && (this.m_TargetCret.m_btRaceServer != 55) && (this.m_TargetCret.m_btRaceServer != 128))
                    {
                        // 对于血量超过100的怪用 不毒城墙
                        n_AmuletIndx = 0;
                        switch (HUtil32.Random(2))
                        {
                            case 0:
                                // 20080413

                                if (IsAllowUseMagic(38) && (HUtil32.GetTickCount() - m_SkillUseTick[38] > 1000))
                                {

                                    m_SkillUseTick[38] = HUtil32.GetTickCount();
                                    result = 38;
                                    // 英雄群体施毒
                                    return result;
                                }

                                else if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // 英雄施毒术
                                    return result;
                                }
                                break;
                            case 1:

                                if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // 英雄施毒术
                                    return result;
                                }
                                break;
                        }
                    }
                    // 无极真气 20080323

                    if (IsAllowUseMagic(50) && (HUtil32.GetTickCount() - m_SkillUseTick[50] > GameConfig.nAbilityUpTick * 1000) && (this.m_wStatusArrValue[2] == 0) && ((GameConfig.btHeroSkillMode50) || (this.m_TargetCret.m_Abil.HP >= 700) || ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYMOSTER))))
                    {
                        // 20080827

                        m_SkillUseTick[50] = HUtil32.GetTickCount();
                        result = 50;
                        return result;
                    }
                    // end;

                    if (IsAllowUseMagic(51) && (HUtil32.GetTickCount() - m_SkillUseTick[51] > 5000))
                    {
                        // 英雄飓风破 20080917

                        m_SkillUseTick[51] = HUtil32.GetTickCount();
                        result = 51;
                        return result;
                    }
                    if (CheckHeroAmulet(1, 1))
                    {
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // 使用符的魔法
                                if (IsAllowUseMagic(59))
                                {
                                    result = 59;
                                    // 英雄噬血术
                                    return result;
                                }

                                // 1000
                                if (IsAllowUseMagic(13) && (HUtil32.GetTickCount() - m_SkillUseTick[13] > 3000))
                                {
                                    // 20090106
                                    result = 13;
                                    // 英雄灵魂火符

                                    m_SkillUseTick[13] = HUtil32.GetTickCount();
                                    // 20080714
                                    return result;
                                }
                                if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                                {
                                    // 诅咒术
                                    result = 52;
                                    // 英雄诅咒术
                                    return result;
                                }
                                break;
                            case 1:
                                if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                                {
                                    // 诅咒术
                                    result = 52;
                                    return result;
                                }
                                if (IsAllowUseMagic(59))
                                {
                                    result = 59;
                                    // 英雄噬血术
                                    return result;
                                }

                                // 1000
                                if (IsAllowUseMagic(13) && (HUtil32.GetTickCount() - m_SkillUseTick[13] > 3000))
                                {
                                    // 20080401修改判断符的方法 //20090106
                                    result = 13;
                                    // 英雄灵魂火符

                                    m_SkillUseTick[13] = HUtil32.GetTickCount();
                                    // 20080714
                                    return result;
                                }
                                break;
                            case 2:
                                // 1

                                // 1000
                                if (IsAllowUseMagic(13) && (HUtil32.GetTickCount() - m_SkillUseTick[13] > 3000))
                                {
                                    // 20090106
                                    result = 13;
                                    // 英雄灵魂火符

                                    m_SkillUseTick[13] = HUtil32.GetTickCount();
                                    // 20080714
                                    return result;
                                }
                                if (IsAllowUseMagic(59))
                                {
                                    result = 59;
                                    // 英雄噬血术
                                    return result;
                                }
                                if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                                {
                                    // 诅咒术
                                    result = 52;
                                    return result;
                                }
                                break;
                            // 2
                        }
                        // case Random(3) of 道
                        // 技能从高到低选择 20080710
                        if (IsAllowUseMagic(59))
                        {
                            // 英雄噬血术
                            result = 59;
                            return result;
                        }
                        if (IsAllowUseMagic(54))
                        {
                            // 英雄骷髅咒 20080917
                            result = 54;
                            return result;
                        }
                        if (IsAllowUseMagic(53))
                        {
                            // 英雄血咒 20080917
                            result = 53;
                            return result;
                        }
                        if (IsAllowUseMagic(51))
                        {
                            // 英雄飓风破 20080917
                            result = 51;
                            return result;
                        }
                        if (IsAllowUseMagic(13))
                        {
                            // 英雄灵魂火符
                            result = 13;
                            return result;
                        }
                        if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                        {
                            // 诅咒术
                            result = 52;
                            return result;
                        }
                    }
                    break;
                // if CheckHeroAmulet(1,1) then begin//使用符的魔法
                // 道士
            }
            // case 职业

            return result;
        }

        /// <summary>
        /// 增加检查两动作的间隔
        /// </summary>
        /// <param name="wIdent"></param>
        /// <param name="dwDelayTime"></param>
        /// <returns></returns>
        private bool CheckActionStatus(ushort wIdent, ref uint dwDelayTime)
        {
            bool result;
            uint dwCheckTime;
            uint dwActionIntervalTime;
            result = false;
            dwDelayTime = 0;
            dwCheckTime = HUtil32.GetTickCount() - m_dwActionTick;// 检查二个不同操作之间所需间隔时间
            if (HUtil32.rangeInDefined(wIdent, 60, 65))// 合击不限制
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
                return result;
            }
            dwActionIntervalTime = 530;
            if (dwCheckTime >= dwActionIntervalTime)
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
            }
            else
            {
                dwDelayTime = dwActionIntervalTime - dwCheckTime;
            }
            m_wOldIdent = wIdent;
            m_btOldDir = this.m_btDirection;
            return result;
        }

        // 1 为护身符 2 为毒药
        private bool IsUseAttackMagic()
        {
            bool result;
            // 检测是否可以使用攻击魔法
            result = false;
            if (m_nSelectMagic <= 0)
            {
                return result;
            }
            switch (this.m_btJob)
            {
                case 0:
                case 1:
                    result = true;
                    break;
                case 2:
                    switch (m_nSelectMagic)
                    {
                        case MagicConst.SKILL_AMYOUNSUL:
                        case MagicConst.SKILL_GROUPAMYOUNSUL:
                            // 6 施毒术
                            // 38 群体施毒术
                            result = CheckHeroAmulet(2, 1);
                            break;
                        case MagicConst.SKILL_FIRECHARM:
                        case MagicConst.SKILL_HOLYSHIELD:
                        case MagicConst.SKILL_SKELLETON:
                        case MagicConst.SKILL_52:
                        case MagicConst.SKILL_59:
                            // 13
                            // 16
                            // 17
                            // 需要符
                            result = CheckHeroAmulet(1, 1);
                            break;
                    }
                    break;
                // case
                // 2
            }
            return result;
        }

        private unsafe bool Think()
        {
            bool result;
            int nOldX;
            int nOldY;
            int UserMagicID = 0;
            TUserMagic* UserMagic = null;
            byte nCheckCode;
            const string sExceptionMsg = "{异常} THeroObject.Think Code:%d";
            result = false;
            nCheckCode = 0;
            try
            {
                if (this.m_Master == null)
                {
                    return result;
                }
                if ((this.m_Master.m_nCurrX == this.m_nCurrX) && (this.m_Master.m_nCurrY == this.m_nCurrY))
                {
                    m_boDupMode = true;
                }
                else
                {
                    if ((HUtil32.GetTickCount() - m_dwThinkTick) > 1000)
                    {
                        m_dwThinkTick = HUtil32.GetTickCount();
                        if (this.m_PEnvir.GetXYObjCount(this.m_nCurrX, this.m_nCurrY) >= 2)
                        {
                            m_boDupMode = true;
                        }
                        nCheckCode = 13;
                        if ((this.m_TargetCret != null))
                        {
                            if ((!this.IsProperTarget(this.m_TargetCret)))
                            {
                                this.m_TargetCret = null;
                            }
                        }
                    }
                }
                nCheckCode = 1;
                if (m_boDupMode && (m_btStatus != 2) && (HUtil32.GetTickCount() - this.dwTick3F4 > m_dwWalkIntervalTime))//增加走间隔
                {
                    this.dwTick3F4 = HUtil32.GetTickCount();//增加
                    nOldX = this.m_nCurrX;
                    nOldY = this.m_nCurrY;
                    this.WalkTo((byte)HUtil32.Random(8), false);
                    if ((nOldX != this.m_nCurrX) || (nOldY != this.m_nCurrY))
                    {
                        m_boDupMode = false;
                        result = true;
                    }
                }
                nCheckCode = 2;
                if (GameConfig.boHeroAutoProtectionDefence) // 英雄无目标下自动开启护体神盾
                {
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence)
                        && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 1000 * 3))
                    {
                        // 使用护体神盾
                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        UserMagic = FindMagic(75);
                        m_boIsUseMagic = false;// 是否能躲避
                        if (UserMagic != null)
                        {
                            ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                        }
                    }
                }
                switch (this.m_btJob)
                {
                    case 0:// 战士
                        nCheckCode = 20;
                        if ((m_btStatus == 1) && (this.m_TargetCret != null))// 跟随状态被打
                        {
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 3) > 1) // 被怪物包围时使用狮子吼
                            {
                                if (IsAllowUseMagic(41) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                                {
                                    UserMagic = FindMagic(41);
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret); // 使用魔法
                                    }
                                }
                            }
                            else
                            {
                                // 野蛮
                                if (IsAllowUseMagic(27) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                                {
                                    UserMagic = FindMagic(27);
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// 使用魔法
                                    }
                                }
                            }
                            this.m_TargetCret = null;
                        }
                        break;
                    case 1:// 法师
                        nCheckCode = 21;
                        if ((m_btStatus == 1) && (this.m_TargetCret != null)) // 跟随状态被打
                        {
                            if (IsAllowUseMagic(31) && (this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence) && boAutoOpenDefence)
                            {
                                UserMagic = FindMagic(31);
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// 使用魔法盾
                                }
                            }
                            if (IsAllowUseMagic(8) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                            {
                                UserMagic = FindMagic(8);
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret); // 使用抗拒火环
                                }
                            }
                            this.m_TargetCret = null;
                        }
                        // 攻击模式,一直开启魔法盾
                        if ((m_btStatus == 0) && (IsAllowUseMagic(31) || IsAllowUseMagic(66)) && (this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0)
                            && (!this.m_boAbilMagBubbleDefence) && boAutoOpenDefence)
                        {
                            if (IsAllowUseMagic(66))
                            {
                                UserMagic = FindMagic(66);
                            }
                            else if (IsAllowUseMagic(31))
                            {
                                UserMagic = FindMagic(31);
                            }
                            m_boIsUseMagic = false;// 是否能躲避
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            if (UserMagic != null)
                            {
                                ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                            }
                        }
                        break;
                    case 2:// 道士
                        nCheckCode = 28;
                        if ((m_nLoyal > 500) && (this.m_TargetCret != null)) // 忠诚度超过5%时，PK时，不使用神圣战甲术 幽灵盾
                        {
                            if ((this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                if (IsAllowUseMagic(15) && (this.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && CheckHeroAmulet(1, 1)) // 打魔防
                                {
                                    UserMagic = FindMagic(15);
                                    m_boIsUseMagic = false;// 是否能躲避
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// 神圣战甲术
                                    }
                                }
                                nCheckCode = 29;
                                if (IsAllowUseMagic(14) && (this.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && CheckHeroAmulet(1, 1))// 给打魔防
                                {
                                    UserMagic = FindMagic(14);
                                    m_boIsUseMagic = false;// 是否能躲避
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this); // 幽灵盾
                                    }
                                }
                                nCheckCode = 29;
                                if (this.m_Master != null)
                                {
                                    if (IsAllowUseMagic(15) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && (HUtil32.GetTickCount() - m_SkillUseTick[15] > 1000 * 3) && CheckHeroAmulet(1, 1))
                                    {
                                        // 给主人打魔防
                                        m_SkillUseTick[15] = HUtil32.GetTickCount();
                                        UserMagic = FindMagic(15);
                                        m_boIsUseMagic = false;// 是否能躲避
                                        if (UserMagic != null)
                                        {
                                            ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);// 使用魔法
                                        }
                                    }
                                    nCheckCode = 26;
                                    // 1000 * 3
                                    if (IsAllowUseMagic(14) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && (HUtil32.GetTickCount() - m_SkillUseTick[14] > 3000) && CheckHeroAmulet(1, 1))
                                    {
                                        // 给主人打魔防
                                        m_SkillUseTick[14] = HUtil32.GetTickCount();
                                        UserMagic = FindMagic(14);
                                        m_boIsUseMagic = false;// 是否能躲避
                                        if (UserMagic != null)
                                        {
                                            ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master); // 使用魔法
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (IsAllowUseMagic(15) && (this.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && CheckHeroAmulet(1, 1))  // 打魔防
                            {
                                UserMagic = FindMagic(15);
                                m_boIsUseMagic = false;// 是否能躲避
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// 神圣战甲术
                                }
                            }
                            nCheckCode = 29;
                            if (IsAllowUseMagic(14) && (this.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && CheckHeroAmulet(1, 1))// 给打魔防
                            {
                                UserMagic = FindMagic(14);
                                m_boIsUseMagic = false;// 是否能躲避
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this); // 幽灵盾
                                }
                            }
                            if (this.m_Master != null)
                            {
                                if (IsAllowUseMagic(15) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) &&
                                    (HUtil32.GetTickCount() - m_SkillUseTick[15] > 1000 * 3) && CheckHeroAmulet(1, 1))
                                {
                                    // 给主人打魔防
                                    m_SkillUseTick[15] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(15);
                                    m_boIsUseMagic = false;// 是否能躲避
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master); // 使用魔法
                                    }
                                }
                                nCheckCode = 26;
                                // 1000 * 3
                                if (IsAllowUseMagic(14) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && (HUtil32.GetTickCount() - m_SkillUseTick[14] > 3000) && CheckHeroAmulet(1, 1))
                                {
                                    // 给主人打魔防
                                    m_SkillUseTick[14] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(14);
                                    m_boIsUseMagic = false;// 是否能躲避
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master); // 使用魔法
                                    }
                                }
                            }
                        }
                        nCheckCode = 27;
                        if ((m_btStatus == 1) && (this.m_TargetCret != null))
                        {
                            // 跟随状态被打
                            if (IsAllowUseMagic(48) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                            {
                                UserMagic = FindMagic(48);
                                m_boIsUseMagic = false;// 是否能躲避
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// 使用气功波
                                }
                            }
                            this.m_TargetCret = null;
                        }
                        if ((m_btStatus != 0) && (this.m_ExpHitter != null))
                        {
                            if (CheckHeroAmulet(1, 1) && (this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] == 0))
                            {
                                if (IsAllowUseMagic(19) && (HUtil32.GetTickCount() - m_SkillUseTick[19] > 8000)) // 隐身术
                                {
                                    m_SkillUseTick[19] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(19);
                                    m_boIsUseMagic = false;// 是否能躲避
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                                    }
                                }
                                else if (IsAllowUseMagic(18) && (HUtil32.GetTickCount() - m_SkillUseTick[18] > 8000))
                                {
                                    m_SkillUseTick[18] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(18);
                                    m_boIsUseMagic = false;// 是否能躲避
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                                    }
                                }
                            }
                            this.m_ExpHitter = null;
                        }
                        nCheckCode = 22;
                        // 主人HP值等于或少于60%时,使用治愈术,先加主人再加自己的血
                        if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)) && (this.m_WAbil.MP > 10) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000)
                            && (this.m_TargetCret == null))
                        {
                            if (IsAllowUseMagic(29))
                            {

                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(29);
                                m_boIsUseMagic = false;// 是否能躲避
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);// 使用魔法
                                }
                            }
                            else if (IsAllowUseMagic(2))
                            {
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(2);
                                m_boIsUseMagic = false;// 是否能躲避
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);// 使用魔法
                                }
                            }
                        }
                        nCheckCode = 23;
                        if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)) && (this.m_WAbil.MP > 10) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000) && (this.m_TargetCret == null))
                        {
                            if (IsAllowUseMagic(29))
                            {

                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(29);
                                m_boIsUseMagic = false;// 是否能躲避
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, null);// 使用魔法
                                }
                            }
                            else if (IsAllowUseMagic(2))
                            {
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(2);
                                m_boIsUseMagic = false;// 是否能躲避
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, null);// 使用魔法
                                }
                            }
                        }
                        nCheckCode = 24;
                        if ((this.m_SlaveList.Count == 0) && GameConfig.boHeroNoTargetCall && CheckHeroAmulet(1, 5) && (HUtil32.GetTickCount() - m_SkillUseTick[17] > 1000 * 3))
                        {
                            m_SkillUseTick[17] = HUtil32.GetTickCount();// 默认,从高到低
                            if (IsAllowUseMagic(72))
                            {
                                // 召唤月灵
                                UserMagicID = 72;
                            }
                            else if (IsAllowUseMagic(30))
                            {
                                // 召唤神兽
                                UserMagicID = 30;
                            }
                            else if (IsAllowUseMagic(17))
                            {
                                UserMagicID = 17;
                            }
                            // 召唤骷髅
                            if (UserMagicID > 0)
                            {
                                UserMagic = FindMagic((ushort)UserMagicID); // 修改英雄召唤神兽
                                m_boIsUseMagic = false;// 是否能躲避 20080719
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// 使用魔法
                                }
                            }
                        }
                        nCheckCode = 25;
                        // 30 * 1000
                        if (((HUtil32.GetTickCount() - m_dwCheckNoHintTick) > 30000) && !m_boIsUseAttackMagic && (m_btStatus == 0))
                        {
                            // 没毒符提示
                            m_dwCheckNoHintTick = HUtil32.GetTickCount();
                            if (IsAllowUseMagic(13) || IsAllowUseMagic(59))
                            {
                                if (!CheckHeroAmulet(1, 1))
                                {
                                    SysMsg("(英雄) 护身符已用完！", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                            if (IsAllowUseMagic(6) || IsAllowUseMagic(38))
                            {
                                if (!CheckHeroAmulet(2, 1))
                                {
                                    SysMsg("(英雄) 灰色毒药已经完！", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                                if (!CheckHeroAmulet(2, 2))
                                {
                                    SysMsg("(英雄) 黄色毒药已经完！", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                        }
                        break;
                }
                nCheckCode = 3;
                if (m_nLoyal >= GameConfig.nGotoLV4) // 英雄忠诚度达到指定值后并且相关技能(灵魂火符，烈火剑法，灭天火)满3级，自动切换到四级状态 
                {
                    switch (this.m_btJob)
                    {
                        case 0:
                            UserMagic = FindMagic(26);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 3)
                                {
                                    UserMagic->btLevel = 4;// 升级为4级技能
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                    SysMsg("由于你们亲密的关系,您的英雄已经领悟了4级烈火剑法!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                        case 1:
                            UserMagic = FindMagic(45);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 3)
                                {
                                    UserMagic->btLevel = 4;// 升级为4级技能
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                    SysMsg("由于你们亲密的关系,您的英雄已经领悟了4级灭天火!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                        case 2:
                            UserMagic = FindMagic(13);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 3)
                                {
                                    UserMagic->btLevel = 4;// 升级为4级技能
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                    SysMsg("由于你们亲密的关系,您的英雄已经领悟了4级灵魂火符!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                    }
                }
                else
                {
                    switch (this.m_btJob)
                    {
                        case 0:// 忠诚度低于触发值时,4级降为3级
                            UserMagic = FindMagic(26);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 4)
                                {
                                    UserMagic->btLevel = 3;// 4级降为3级
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                }
                            }
                            break;
                        case 1:
                            UserMagic = FindMagic(45);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 4)
                                {
                                    UserMagic->btLevel = 3;// 4级降为3级
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                }
                            }
                            break;
                        case 2:
                            UserMagic = FindMagic(13);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 4)
                                {
                                    UserMagic->btLevel = 3;// 4级降为3级
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                }
                            }
                            break;
                    }
                }
                nCheckCode = 4;
                if (SearchIsPickUpItem())
                {
                    SearchPickUpItem(500);// 捡物品
                }
                nCheckCode = 6;
                if (this.m_Master != null)
                {
                    // 增加,主人换地图,英雄马上一起走
                    // 不在同个地图时才飞
                    if (((m_btStatus < 2) || ((m_btStatus == 2) && (!GameConfig.boRestNoFollow))) && !m_boProtectStatus && (this.m_PEnvir != this.m_Master.m_PEnvir)
                        && ((Math.Abs(this.m_nCurrX - this.m_Master.m_nCurrX) > 20) || (Math.Abs(this.m_nCurrY - this.m_Master.m_nCurrY) > 20)))
                    {
                        this.SpaceMove(this.m_Master.m_PEnvir.sMapName, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, 1);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, new byte[] { nCheckCode }));
            }
            return result;
        }

        // 自动躲避
        private unsafe bool SearchIsPickUpItem()
        {
            bool result;
            TVisibleMapItem VisibleMapItem;
            TMapItem MapItem;
            int I;
            int nCurrX;
            int nCurrY;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (this.m_Master == null)
                {
                    return result;
                }
                if ((this.m_Master != null) && (this.m_Master.m_boDeath))
                {
                    return result;
                }
                if (m_btStatus == 2)
                {
                    return result;
                }
                if (this.m_TargetCret != null)
                {
                    return result;
                }
                if (m_boProtectStatus)
                {
                    return result;
                }
                nCode = 3;
                if (this.m_VisibleItems.Count == 0)
                {
                    return result;
                }
                nCode = 4;

                if (HUtil32.GetTickCount() < m_dwSearchIsPickUpItemTime)
                {
                    return result;
                }
                if ((!IsEnoughBag()))
                {
                    return result;
                }
                // 20080428 注释
                if (this.m_Master != null)
                {
                    nCurrX = this.m_Master.m_nCurrX;
                    nCurrY = this.m_Master.m_nCurrY;
                    if (m_boProtectStatus)
                    {
                        nCurrX = m_nProtectTargetX;
                        nCurrY = m_nProtectTargetY;
                    }
                    if ((Math.Abs(nCurrX - this.m_nCurrX) > 15) || (Math.Abs(nCurrY - this.m_nCurrY) > 15))
                    {
                        // 1000 * 5
                        m_dwSearchIsPickUpItemTime = HUtil32.GetTickCount() + 5000;
                        return result;
                    }
                }
                nCode = 10;
                if (this.m_VisibleItems.Count > 0)
                {
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 11;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 12;
                        if ((VisibleMapItem != null))
                        {
                            if ((VisibleMapItem.nVisibleFlag > 0))
                            {
                                MapItem = VisibleMapItem.MapItem;
                                nCode = 13;
                                if ((MapItem != null))
                                {
                                    if ((this.m_Master != null))
                                    {
                                        nCode = 14;
                                        if (MapItem.DropBaseObject != null)
                                        {
                                            nCode = 15;
                                            if ((MapItem.DropBaseObject != this.m_Master))
                                            {
                                                nCode = 16;
                                                if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(MapItem.UserItem->wIndex)))
                                                {
                                                    nCode = 17;
                                                    if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                                    {
                                                        nCode = 18;
                                                        if ((Math.Abs(VisibleMapItem.nX - this.m_nCurrX) <= 5) && (Math.Abs(VisibleMapItem.nY - this.m_nCurrY) <= 5))
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
                            }
                        }
                    }
                }
            }
            catch
            {
                // MainOutMessage('{异常} THeroObject.SearchIsPickUpItem Code:'+inttostr(nCode));
            }
            return result;
        }

        // 半月弯刀判断目标函数 20081207
        // 未使用的函数
        private bool GotoTargetXYRange()
        {
            bool result;
            int n10;
            int n14;
            int nTargetX;
            int nTargetY;
            result = true;
            nTargetX = 0;
            // 20080529
            nTargetY = 0;
            // 20080529
            n10 = Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX);
            n14 = Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY);
            if (n10 > 4)
            {
                n10 -= 5;
            }
            else
            {
                n10 = 0;
            }
            if (n14 > 4)
            {
                n14 -= 5;
            }
            else
            {
                n14 = 0;
            }
            if (this.m_TargetCret.m_nCurrX > this.m_nCurrX)
            {
                nTargetX = this.m_nCurrX + n10;
            }
            if (this.m_TargetCret.m_nCurrX < this.m_nCurrX)
            {
                nTargetX = this.m_nCurrX - n10;
            }
            if (this.m_TargetCret.m_nCurrY > this.m_nCurrY)
            {
                nTargetY = this.m_nCurrY + n14;
            }
            if (this.m_TargetCret.m_nCurrY < this.m_nCurrY)
            {
                nTargetY = this.m_nCurrY - n14;
            }
            result = GotoTargetXY(nTargetX, nTargetY, 0);
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
            result = Grobal2.DR_DOWN;// 南
            if (n10 > this.m_nCurrX)
            {
                result = Grobal2.DR_RIGHT;// 东
                if (n14 > this.m_nCurrY)
                {
                    result = Grobal2.DR_DOWNRIGHT;// 东南向
                }
                if (n14 < this.m_nCurrY)
                {
                    result = Grobal2.DR_UPRIGHT; // 东北向
                }
            }
            else
            {
                if (n10 < this.m_nCurrX)
                {
                    result = Grobal2.DR_LEFT;// 西
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNLEFT;// 西南向
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UPLEFT; // 西北向
                    }
                }
                else
                {
                    if (n14 > this.m_nCurrY)// 南
                    {
                        result = Grobal2.DR_DOWN;
                    }
                    else if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UP;  // 正北
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
                switch (nDir)
                {
                    case Grobal2.DR_UP:// 北
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
                    case Grobal2.DR_UPRIGHT:// 东北
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
                    case Grobal2.DR_RIGHT:// 东
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
                    case Grobal2.DR_DOWNRIGHT:// 东南
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
                            n01++;
                            continue;
                        }
                    case Grobal2.DR_DOWN:// 南
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
                    case Grobal2.DR_DOWNLEFT:// 西南
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
                    case Grobal2.DR_LEFT:// 西
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
                    case Grobal2.DR_UPLEFT:// 西北向
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
                    default:
                        break;
                }
            }
            return result;
        }

        public bool AutoAvoid_GetAvoidXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n10;
            int nDir = 0;
            int nX;
            int nY;
            nX = nTargetX;
            nY = nTargetY;
            result = AutoAvoid_GetGotoXY(m_btLastDirection, ref nTargetX, ref nTargetY);
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
                n10++;
            }
            m_btLastDirection = (byte)nDir;
            // m_btDirection;

            return result;
        }

        public bool AutoAvoid_GotoMasterXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int nDir;
            result = false;
            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 6) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 6)) && !m_boProtectStatus)
            {
                nTargetX = this.m_nCurrX;
                nTargetY = this.m_nCurrY;
                // nTargetX := m_Master.m_nCurrX;//20080215
                // nTargetY := m_Master.m_nCurrY;//20080215
                nDir = AutoAvoid_GetDirXY(this.m_Master.m_nCurrX, this.m_Master.m_nCurrY);
                switch (nDir)
                {
                    case Grobal2.DR_UP:
                        // m_btLastDirection := nDir;//20080402
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        break;
                    case Grobal2.DR_RIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        break;
                    case Grobal2.DR_DOWN:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        break;
                    case Grobal2.DR_LEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        break;
                }
            }
            return result;
        }

        // 使用的物品
        private bool AutoAvoid()
        {
            bool result;
            int nTargetX = 0;
            int nTargetY = 0;
            int nDir;
            result = true;
            if ((this.m_TargetCret != null) && !this.m_TargetCret.m_boDeath)
            {
                if (AutoAvoid_GotoMasterXY(ref nTargetX, ref nTargetY))
                {
                    result = GotoTargetXY(nTargetX, nTargetY, 1);
                }
                else
                {
                    nTargetX = this.m_nCurrX;
                    nTargetY = this.m_nCurrY;
                    nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                    nDir = this.GetBackDir((byte)nDir);
                    this.m_PEnvir.GetNextPosition(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, nDir, 5, ref m_nTargetX, ref m_nTargetY);
                    result = GotoTargetXY(m_nTargetX, m_nTargetY, 1);
                }
            }
            return result;
        }

        public void SearchPickUpItem_SetHideItem(TMapItem MapItem)
        {
            TVisibleMapItem VisibleMapItem;
            int I;
            for (I = 0; I < this.m_VisibleItems.Count; I++)
            {
                VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                if ((VisibleMapItem != null) && (VisibleMapItem.nVisibleFlag > 0))
                {
                    if (VisibleMapItem.MapItem == MapItem)
                    {
                        VisibleMapItem.nVisibleFlag = 0;
                        break;
                    }
                }
            }
        }

        public unsafe bool SearchPickUpItem_PickUpItem(int nX, int nY)
        {
            bool result;
            TUserItem* UserItem = null;
            TStdItem* StdItem;
            TMapItem MapItem;
            result = false;
            MapItem = this.m_PEnvir.GetItem(nX, nY);
            if (MapItem == null)
            {
                return result;
            }
            if ((MapItem.Name).ToLower().CompareTo((M2Share.sSTRING_GOLDNAME).ToLower()) == 0)
            {
                if (this.m_PEnvir.DeleteFromMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                {
                    if ((this.m_Master != null) && (!this.m_Master.m_boDeath))
                    {
                        // 捡到的钱加给主人
                        if (((TPlayObject)(this.m_Master)).IncGold(MapItem.Count))
                        {
                            //this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, nX, nY, "");
                            if (M2Share.g_boGameLogGold)
                            {
                                M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (nX).ToString() + "\09" + (nY).ToString()
                                    + "\09" + this.m_sCharName + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (MapItem.Count).ToString() + "\09"
                                    + "1" + "\09" + "0");
                            }
                            result = true;
                            this.m_Master.GoldChanged();
                            SearchPickUpItem_SetHideItem(MapItem);
                            Dispose(MapItem);
                        }
                        else
                        {
                            this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                        }
                    }
                    else
                    {
                        this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                    }
                }
                else
                {
                    this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                }
            }
            else
            {
                // 捡物品
                StdItem = UserEngine.GetStdItem(MapItem.UserItem->wIndex);
                if (StdItem != null)
                {
                    if (this.m_PEnvir.DeleteFromMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                    {
                        //FillChar(UserItem, sizeof(TUserItem), '\0');
                        // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);
                        UserItem = MapItem.UserItem;
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if ((StdItem != null) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(UserItem->wIndex)))
                        {
                            if (AddItemToBag(UserItem))
                            {
                                // this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, nX, nY, "");
                                SendAddItem(UserItem);
                                //this.m_WAbil.Weight = this.RecalcBagWeight();
                                if (StdItem->NeedIdentify == 1)
                                {
                                    M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (nX).ToString() + "\09" + (nY).ToString() + "\09" + this.m_sCharName
                                        + "\09" + StdItem->ToString() + "\09" + UserItem->MakeIndex + "\09" + "(" + HUtil32.LoWord(StdItem->DC) + "/"
                                        + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC) + "/" + (HUtil32.HiWord(StdItem->MC)).ToString()
                                        + ")" + "(" + HUtil32.LoWord(StdItem->SC) + "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" + HUtil32.LoWord(StdItem->AC) + "/"
                                        + HUtil32.HiWord(StdItem->AC) + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + HUtil32.HiWord(StdItem->MAC) + ")"
                                        + UserItem->btValue[0] + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString()
                                        + "/" + (UserItem->btValue[4]).ToString() + "/" + UserItem->btValue[5] + "/" + (UserItem->btValue[6]).ToString() + "/"
                                        + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString() + "\09"
                                        + (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                                }
                                result = true;
                                SearchPickUpItem_SetHideItem(MapItem);

                                Dispose(MapItem);
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                //Dispose(UserItem);
                                this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                            }
                        }
                        else
                        {
                            Marshal.FreeHGlobal((IntPtr)UserItem);
                            //Dispose(UserItem);
                            this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                        }
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        //Dispose(UserItem);
                        this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 英雄自动捡物品
        /// </summary>
        /// <param name="nPickUpTime">间隔</param>
        /// <returns></returns>
        private unsafe bool SearchPickUpItem(int nPickUpTime)
        {
            bool result;
            TMapItem MapItem;
            TVisibleMapItem VisibleMapItem = null;
            TVisibleMapItem SelVisibleMapItem = null;
            int I;
            bool boFound;
            int n01;
            int n02;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (HUtil32.GetTickCount() - m_dwPickUpItemTick < nPickUpTime)
                {
                    return result;
                }
                m_dwPickUpItemTick = HUtil32.GetTickCount();
                boFound = false;
                nCode = 1;
                if (m_SelMapItem != null)
                {
                    nCode = 2;
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 3;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 4;
                        if ((VisibleMapItem != null) && (VisibleMapItem.nVisibleFlag > 0))
                        {
                            if (VisibleMapItem.MapItem == m_SelMapItem)
                            {
                                nCode = 5;
                                boFound = true;
                                break;
                            }
                        }
                    }
                }
                if (!boFound)
                {
                    m_SelMapItem = null;
                }
                nCode = 6;
                if (m_SelMapItem != null)
                {
                    if (SearchPickUpItem_PickUpItem(this.m_nCurrX, this.m_nCurrY))
                    {
                        result = true;
                        return result;
                    }
                }
                n01 = 999;
                nCode = 7;
                SelVisibleMapItem = null;
                boFound = false;
                if (m_SelMapItem != null)
                {
                    nCode = 8;
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 9;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 10;
                        if ((VisibleMapItem != null) && (VisibleMapItem.nVisibleFlag > 0))
                        {
                            nCode = 11;
                            if (VisibleMapItem.MapItem == m_SelMapItem)
                            {
                                SelVisibleMapItem = VisibleMapItem;
                                boFound = true;
                                break;
                            }
                        }
                    }
                }
                if (!boFound)
                {
                    nCode = 12;
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 13;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 14;
                        if ((VisibleMapItem != null))
                        {
                            if ((VisibleMapItem.nVisibleFlag > 0))
                            {
                                MapItem = VisibleMapItem.MapItem;
                                nCode = 15;
                                if ((MapItem != null))
                                {
                                    if ((MapItem.DropBaseObject != this.m_Master))
                                    {
                                        nCode = 16;
                                        if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(MapItem.UserItem->wIndex)))
                                        {
                                            nCode = 17;
                                            if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                            {
                                                nCode = 18;
                                                if ((Math.Abs(VisibleMapItem.nX - this.m_nCurrX) <= 5) && (Math.Abs(VisibleMapItem.nY - this.m_nCurrY) <= 5))
                                                {
                                                    n02 = Math.Abs(VisibleMapItem.nX - this.m_nCurrX) + Math.Abs(VisibleMapItem.nY - this.m_nCurrY);
                                                    if (n02 < n01)
                                                    {
                                                        n01 = n02;
                                                        nCode = 19;
                                                        SelVisibleMapItem = VisibleMapItem;
                                                    }
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
                nCode = 20;
                if (SelVisibleMapItem != null)
                {
                    nCode = 21;
                    m_SelMapItem = SelVisibleMapItem.MapItem;
                    if ((this.m_nCurrX != SelVisibleMapItem.nX) || (this.m_nCurrY != SelVisibleMapItem.nY))
                    {
                        nCode = 22;
                        WalkToTargetXY2(SelVisibleMapItem.nX, VisibleMapItem.nY);
                        result = true;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.SearchPickUpItem Code:" + nCode);
            }
            return result;
        }

        private bool EatUseItems(int nShape)
        {
            bool result;
            result = false;
            switch (nShape)
            {
                case 4:
                    if (WeaptonMakeLuck())
                    {
                        result = true;
                    }
                    break;
                case 9:
                    if (RepairWeapon())
                    {
                        result = true;
                    }
                    break;
                case 10:
                    if (SuperRepairWeapon())
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }

        // 自动吃药
        public unsafe int AutoEatUseItems_FoundAddHealthItem(byte ItemType)
        {
            int result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            TUserItem* UserItem1;
            TStdItem* StdItem1;
            TStdItem* StdItem2;
            TStdItem* StdItem3;
            int II;
            int MinHP;
            int j = 0;
            int nHP;
            result = -1;
            if (this.m_ItemList.Count > 0)
            {
                // 20080628
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
                                case 0:
                                    // 红药
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->AC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 1:
                                    // 蓝药
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->MAC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 2:
                                    // 太阳水(查找特殊药品,对比HP,选择适合的药品)
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 1) && (StdItem->AC > 0) && (StdItem->MAC > 0))
                                    {
                                        MinHP = StdItem->AC;
                                        nHP = this.m_WAbil.MaxHP - this.m_WAbil.HP;
                                        // 取当前血的差值
                                        j = I;
                                        for (II = 0; II < this.m_ItemList.Count; II++)
                                        {
                                            // 循环找出+HP最适合的特殊物品
                                            UserItem1 = (TUserItem*)this.m_ItemList[II];
                                            if (UserItem1 != null)
                                            {
                                                StdItem1 = UserEngine.GetStdItem(UserItem1->wIndex);
                                                if (StdItem1 != null)
                                                {
                                                    if ((StdItem1->StdMode == 0) && (StdItem1->Shape == 1) && (StdItem1->AC > 0) && (StdItem1->MAC > 0))
                                                    {
                                                        if (Math.Abs(StdItem1->AC - nHP) < Math.Abs(MinHP - nHP))
                                                        {
                                                            MinHP = StdItem1->AC;
                                                            j = II;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        for (II = 0; II < this.m_ItemList.Count; II++)
                                        {
                                            UserItem1 = (TUserItem*)this.m_ItemList[II];
                                            if (UserItem1 != null)
                                            {
                                                StdItem1 = UserEngine.GetStdItem(UserItem1->wIndex);
                                                if (StdItem1 != null)
                                                {
                                                    if ((StdItem1->StdMode == 31) && (M2Share.GetBindItemType(StdItem1->Shape) == 2) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                                    {
                                                        StdItem3 = UserEngine.GetStdItem(M2Share.GetBindItemName(StdItem1->Shape));
                                                        // 可以解出来的物品名
                                                        if (StdItem3 != null)
                                                        {
                                                            if ((StdItem3->StdMode == 0) && (StdItem3->Shape == 1) && (StdItem3->AC > 0) && (StdItem3->MAC > 0))
                                                            {
                                                                if (Math.Abs(StdItem3->AC - nHP) < Math.Abs(MinHP - nHP))
                                                                {
                                                                    // 20080926
                                                                    MinHP = StdItem3->AC;
                                                                    j = II;
                                                                }
                                                            }
                                                        }
                                                        // if StdItem3 <> nil then begin
                                                    }
                                                }
                                            }
                                        }
                                        result = j;
                                        break;
                                    }
                                    break;
                                case 3:
                                    // 红药包
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 0) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 4:
                                    // 蓝药包
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 1) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 5:
                                    // 大补药包 智能解包
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 2) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                    {
                                        StdItem1 = UserEngine.GetStdItem(M2Share.GetBindItemName(StdItem->Shape));
                                        // 可以解出来的物品名
                                        if (StdItem1 != null)
                                        {
                                            MinHP = StdItem1->AC;
                                            nHP = this.m_WAbil.MaxHP - this.m_WAbil.HP;
                                            // 取当前血的差值
                                            j = I;
                                            for (II = 0; II < this.m_ItemList.Count; II++)
                                            {
                                                // 循环找出+HP最适合的特殊物品
                                                UserItem1 = (TUserItem*)this.m_ItemList[II];
                                                if (UserItem1 != null)
                                                {
                                                    StdItem2 = UserEngine.GetStdItem(UserItem1->wIndex);
                                                    if (StdItem2 != null)
                                                    {
                                                        if ((StdItem2->StdMode == 31) && (M2Share.GetBindItemType(StdItem2->Shape) == 2))
                                                        {
                                                            StdItem3 = UserEngine.GetStdItem(M2Share.GetBindItemName(StdItem2->Shape));
                                                            // 可以解出来的物品名
                                                            if (StdItem3 != null)
                                                            {
                                                                if ((StdItem3->StdMode == 0) && (StdItem3->Shape == 1) && (StdItem3->AC > 0) && (StdItem3->MAC > 0))
                                                                {
                                                                    if (Math.Abs(StdItem3->AC - nHP) < Math.Abs(MinHP - nHP))
                                                                    {
                                                                        // 20080926
                                                                        MinHP = StdItem3->AC;
                                                                        j = II;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        result = j;
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

        // 吃药
        private unsafe bool AutoEatUseItems(byte btItemType)
        {
            bool result;
            int nItemIdx;
            TUserItem* UserItem;
            result = false;
            if (!this.m_boDeath)
            {
                nItemIdx = AutoEatUseItems_FoundAddHealthItem(btItemType);
                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                {
                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                    SendDelItems(UserItem);
                    ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                    result = true;
                }
                else
                {
                    switch (btItemType)// 查找解包物品
                    {
                        case 0:
                            nItemIdx = AutoEatUseItems_FoundAddHealthItem(0);// 查找红药
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = true;
                                UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                SendDelItems(UserItem);
                                ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                            }
                            else
                            {
                                nItemIdx = AutoEatUseItems_FoundAddHealthItem(3);// 查找红药包
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = true;
                                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                    SendDelItems(UserItem);
                                    ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                                }
                            }
                            break;
                        case 1:
                            nItemIdx = AutoEatUseItems_FoundAddHealthItem(1);// 查找蓝药
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = true;
                                UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                SendDelItems(UserItem);
                                ClientHeroUseItems(UserItem->MakeIndex,
                                    HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                            }
                            else
                            {
                                nItemIdx = AutoEatUseItems_FoundAddHealthItem(4);// 蓝药包
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = true;
                                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                    SendDelItems(UserItem);
                                    ClientHeroUseItems(UserItem->MakeIndex,
                                        HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                                }
                            }
                            break;
                        case 2:
                            nItemIdx = AutoEatUseItems_FoundAddHealthItem(2);// 查找特殊药品,对比HP,选择适合的药品
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = true;
                                UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                SendDelItems(UserItem);
                                ClientHeroUseItems(UserItem->MakeIndex,
                                    HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                            }
                            else
                            {
                                nItemIdx = AutoEatUseItems_FoundAddHealthItem(5);// 大补药包
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = true;
                                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                    SendDelItems(UserItem);
                                    ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                                }
                            }
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 是否走向目标
        /// </summary>
        /// <returns></returns>
        public unsafe bool IsNeedGotoXY()
        {
            bool result = false;
            uint dwAttackTime = 0;
            if ((this.m_TargetCret != null) && (HUtil32.GetTickCount() - m_dwAutoAvoidTick > 1100) && (!m_boIsUseAttackMagic || (this.m_btJob == 0)))
            {
                if (this.m_btJob > 0)
                {
                    if ((m_btStatus != 2) && !m_boIsUseMagic && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 3) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 3)))
                    {
                        result = true;
                        return result;
                    }
                    if ((m_btStatus != 2) && ((GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22)) ||
                        (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_WAbil.MaxHP < 700) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                        && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (this.m_btJob == 2) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1)
                        || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))))// 道法22前是否物理攻击
                    {
                        result = true;
                        return result;
                    }
                }
                else if ((m_btStatus != 2))
                {
                    switch (m_nSelectMagic)
                    {
                        case 12:// 刺杀
                            if (IsAllowUseMagic(12) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY)))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // 防止负数出错
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
                                    {
                                        this.m_dwHitTick = HUtil32.GetTickCount();
                                        m_wHitMode = 4;// 刺杀
                                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                        Attack(this.m_TargetCret, this.m_btDirection);
                                        this.BreakHolySeizeMode();
                                        return result;
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
                            m_nSelectMagic = 0;
                            if (IsAllowUseMagic(12))
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
                        case 74:// 逐日剑法
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) ||
                                    ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) ||
                                    (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) ||
                                    ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) ||
                                    ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4))))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // 防止负数出错
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
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
                                    if (IsAllowUseMagic(12))
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
                            m_nSelectMagic = 0;
                            if (IsAllowUseMagic(12))
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
                        case 43:// 实现隔位放开天
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY) && (this.m_n42kill == 2))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4))
                                    || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4))))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // 防止负数出错
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
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
                                    if (IsAllowUseMagic(12))
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
                            m_nSelectMagic = 0;
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY) && (new ArrayList(new int[] { 1, 2 }).Contains(this.m_n42kill)))
                            {
                                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)
                                    || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)
                                    || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // 防止负数出错
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
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
                                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            m_nSelectMagic = 0;
                            if (IsAllowUseMagic(12))
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
                            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                m_nSelectMagic = 0;
                                return result;
                            }
                            break;
                        default:
                            if (IsAllowUseMagic(12))
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

        // 是否可以捡的物品
        // function IsPickUpItem(StdItem: pTStdItem): Boolean; 20080117
        // 是否需要躲避
        private unsafe bool IsNeedAvoid()
        {
            bool result;
            result = false;

            if (((HUtil32.GetTickCount() - m_dwAutoAvoidTick) > 1100) && m_boIsUseMagic)
            {
                // 血低于25%时,必定要躲 20080711
                if ((this.m_btJob > 0) && (m_btStatus != 2) && ((m_nSelectMagic == 0) || (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.25))))
                {

                    m_dwAutoAvoidTick = HUtil32.GetTickCount();
                    switch (this.m_btJob)
                    {
                        case 1:
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0)
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 2:
                            // 20090112
                            if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                // 22级砍血量的怪 20090108
                                if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                {
                                    // 20090108
                                    // 3
                                    if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            else
                            {
                                // 3
                                if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            break;
                    }
                    // if CheckTargetXYCount(m_nCurrX, m_nCurrY, 3) > 0 then begin
                    // Result := True;
                    // end;
                }
                // if (not Result) and (m_WAbil.HP <= Round(m_WAbil.MaxHP * 0.15)) then Result := True;//20080711 20090202注释
            }
            return result;
        }

        public unsafe bool EatMedicine_FoundItem(byte ItemType)
        {
            bool result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = false;
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
                                case 0:
                                    // 红药
                                    if ((StdItem->StdMode == 0) && ((StdItem->Shape == 0) || (StdItem->Shape == 1)) && (StdItem->AC > 0))
                                    {
                                        result = true;
                                        break;
                                    }
                                    if ((StdItem->StdMode == 31) && ((M2Share.GetBindItemType(StdItem->Shape) == 0) || (M2Share.GetBindItemType(StdItem->Shape) == 2)))
                                    {
                                        result = true;
                                        break;
                                    }
                                    break;
                                case 1:
                                    // 蓝药
                                    if ((StdItem->StdMode == 0) && ((StdItem->Shape == 0) || (StdItem->Shape == 1)) && (StdItem->MAC > 0))
                                    {
                                        result = true;
                                        break;
                                    }
                                    if ((StdItem->StdMode == 31) && ((M2Share.GetBindItemType(StdItem->Shape) == 1) || (M2Share.GetBindItemType(StdItem->Shape) == 2)))
                                    {
                                        result = true;
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


        /// <summary>
        /// 吃药
        /// </summary>
        private unsafe void EatMedicine()
        {
            int n01;
            bool boFound;
            byte btItemType;
            boFound = false;
            btItemType = 0;
            if (!this.m_PEnvir.m_boMISSION)//地图没有限制使用物品时,可以自动吃药
            {
                if ((HUtil32.GetTickCount() - m_dwEatItemTick) > GameConfig.nHeroAddHPMPTick)  // 英雄吃普通药间隔 
                {
                    m_dwEatItemTick = HUtil32.GetTickCount();
                    if ((this.m_nCopyHumanLevel > 0))
                    {
                        if (this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate) / 100)
                        {
                            n01 = 0;
                            while (this.m_WAbil.HP < this.m_WAbil.MaxHP) // 增加连续吃三瓶
                            {
                                if ((n01 >= 1)) // 改成一次一瓶
                                {
                                    break;
                                }
                                btItemType = 0;
                                if (AutoEatUseItems(btItemType))
                                {
                                    boFound = true;
                                }
                                if (this.m_ItemList.Count == 0)
                                {
                                    break;
                                }
                                n01++;
                            }
                        }
                        if (this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate) / 100)
                        {
                            n01 = 0;
                            while (this.m_WAbil.MP < this.m_WAbil.MaxMP) // 增加连续吃三瓶
                            {
                                if ((n01 >= 1)) // 改成一次一瓶
                                {
                                    break;
                                }
                                btItemType = 1;
                                if (AutoEatUseItems(btItemType))
                                {
                                    boFound = true;
                                }
                                if (this.m_ItemList.Count == 0)
                                {
                                    break;
                                }
                                n01++;
                            }
                        }
                    }
                }

                if ((HUtil32.GetTickCount() - m_dwEatItemTick1) > GameConfig.nHeroAddHPMPTick1)
                {
                    // 英雄吃特殊药间隔 20080910

                    m_dwEatItemTick1 = HUtil32.GetTickCount();
                    if ((this.m_nCopyHumanLevel > 0) && (this.m_ItemList.Count > 0))
                    {
                        if ((this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate1) / 100) || (this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate1) / 100))
                        {
                            btItemType = 2;
                            if (AutoEatUseItems(btItemType))
                            {
                                boFound = true;
                            }
                        }
                    }
                }
            }
            if (!boFound)
            {

                // 30 * 1000
                if ((HUtil32.GetTickCount() - m_dwEatItemNoHintTick) > 30000)
                {
                    // 20080129
                    m_dwEatItemNoHintTick = HUtil32.GetTickCount();
                    switch (btItemType)
                    {
                        case 0:
                            if ((this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate) / 100) || (this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate1) / 100))
                            {
                                if (!EatMedicine_FoundItem(btItemType))
                                {
                                    SysMsg("(英雄) 金创药已经用完！！！", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                        case 1:
                            if ((this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate) / 100) || (this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate1) / 100))
                            {
                                if (!EatMedicine_FoundItem(btItemType))
                                {
                                    SysMsg("(英雄) 魔法药已经用完！！！", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 检测指定方向和范围内坐标的怪物数量
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nDir"></param>
        /// <param name="nRange"></param>
        /// <returns></returns>
        private int CheckTargetXYCountOfDirection(int nX, int nY, int nDir, int nRange)
        {
            int result = 0;
            TBaseObject BaseObject;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                switch (nDir)
                                {
                                    case Grobal2.DR_UP:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_RIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWN:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_LEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 检测指定方向和范围内坐标的怪物数量
        // 检测指定方向和范围内,目标与英雄的距离 20080426
        private int CheckMasterXYOfDirection(TBaseObject TargeTBaseObject, int nX, int nY, int nDir, int nRange)
        {
            int result = 0;
            if (TargeTBaseObject != null)
            {
                if (!TargeTBaseObject.m_boDeath)
                {
                    switch (nDir)
                    {
                        case Grobal2.DR_UP:
                            if ((Math.Abs(nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((TargeTBaseObject.m_nCurrY - nY) >= 0 && (TargeTBaseObject.m_nCurrY - nY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_UPRIGHT:
                            if (((TargeTBaseObject.m_nCurrX - nX) >= 0 && (TargeTBaseObject.m_nCurrX - nX) <= nRange) && ((TargeTBaseObject.m_nCurrY - nY) >= 0 && (TargeTBaseObject.m_nCurrY - nY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_RIGHT:
                            if (((TargeTBaseObject.m_nCurrX - nX) >= 0 && (TargeTBaseObject.m_nCurrX - nX) <= nRange) && (Math.Abs(nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_DOWNRIGHT:
                            if (((TargeTBaseObject.m_nCurrX - nX) >= 0 && (TargeTBaseObject.m_nCurrX - nX) <= nRange) && ((nY - TargeTBaseObject.m_nCurrY) >= 0 && (nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_DOWN:
                            if ((Math.Abs(nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((nY - TargeTBaseObject.m_nCurrY) >= 0 && (nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_DOWNLEFT:
                            if (((nX - TargeTBaseObject.m_nCurrX) >= 0 && (nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((nY - TargeTBaseObject.m_nCurrY) >= 0 && (nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_LEFT:
                            if (((nX - TargeTBaseObject.m_nCurrX) >= 0 && (nX - TargeTBaseObject.m_nCurrX) <= nRange) && (Math.Abs(nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_UPLEFT:
                            if (((nX - TargeTBaseObject.m_nCurrX) >= 0 && (nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((TargeTBaseObject.m_nCurrY - nY) >= 0 && (TargeTBaseObject.m_nCurrY - nY) <= nRange))
                            {
                                result++;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 物理攻击
        /// </summary>
        /// <param name="wHitMode"></param>
        /// <returns></returns>
        private bool WarrAttackTarget(ushort wHitMode)
        {
            bool result;
            byte bt06 = 0;
            byte nCode;
            uint dwDelayTime;
            result = false;
            nCode = 0;
            try
            {
                nCode = 1;
                if (this.m_TargetCret != null)
                {
                    nCode = 2;
                    if (this.GetAttackDir(this.m_TargetCret, ref bt06))
                    {
                        nCode = 3;

                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                        nCode = 4;
                        Attack(this.m_TargetCret, bt06);
                        m_dwActionTick = HUtil32.GetTickCount();
                        nCode = 5;
                        this.BreakHolySeizeMode();
                        result = true;
                    }
                    else
                    {
                        nCode = 6;
                        if (this.m_TargetCret.m_PEnvir == this.m_PEnvir)
                        {
                            nCode = 7;
                            SetTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                        }
                        else
                        {
                            nCode = 8;
                            if (!m_boTarget)//不是锁定的目标,才能删除目标
                            {
                                DelTargetCreat();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.WarrAttackTarget Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// 战士攻击
        /// </summary>
        /// <returns></returns>
        private unsafe bool WarrorAttackTarget()
        {
            bool result;
            TUserMagic* UserMagic;
            result = false;
            if (m_btStatus != 0)
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            m_wHitMode = 0;
            if (this.m_WAbil.MP > 0)
            {
                if (!m_boStartUseSpell && ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.3)) || this.m_TargetCret.m_boCrazyMode))// 连击循序全为空时
                {
                    if (IsAllowUseMagic(12) && (this.m_nBatterOrder[0] == 0))  // 血少时或目标疯狂模式时，做隔位刺杀
                    {
                        GetGotoXY(this.m_TargetCret, 2);
                        GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                    }
                }
                if (!m_boStartUseSpell)
                {
                    SearchMagic(); // 查询魔法 
                }
                if (m_nSelectMagic > 0)
                {
                    if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 5) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 5)))
                    {
                        // 魔法不能打到怪
                        if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7))
                        {
                            this.m_TargetCret = null;
                            return result;
                        }
                    }
                    UserMagic = FindMagic(m_nSelectMagic);
                    if ((UserMagic != null))
                    {
                        if ((UserMagic->btKey == 0))// 技能打开状态才能使用 
                        {
                            switch (m_nSelectMagic)
                            {
                                // Modify the A .. B: 27, 39, 41, 60 .. 65, 68, 75
                                case 27:
                                case 39:
                                case 41:
                                case 60:
                                case 68:
                                case 75:
                                    this.m_dwHitTick = HUtil32.GetTickCount();
                                    result = ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// 战士魔法
                                    return result;
                                case 7:// 攻杀
                                    m_wHitMode = 3;
                                    break;
                                case 12:// 使用刺杀
                                    m_wHitMode = 4;
                                    break;
                                case 25:// 使用半月
                                    m_wHitMode = 5;
                                    break;
                                case 26:// 使用烈火
                                    m_wHitMode = 7;
                                    break;
                                case 40:// 抱月刀法
                                    m_wHitMode = 8;
                                    break;
                                case 43:// 开天斩  
                                    m_wHitMode = 9;
                                    break;
                                case 42:// 龙影剑法 
                                    m_wHitMode = 12;
                                    break;
                                case 74:// 逐日剑法
                                    m_wHitMode = 13;
                                    break;
                            }
                        }
                    }
                }
            }
            if (!m_boStartUseSpell)
            {
                result = WarrAttackTarget(m_wHitMode);
            }
            if (result)
            {
                this.m_dwHitTick = HUtil32.GetTickCount();
            }
            return result;
        }

        /// <summary>
        /// 法师攻击
        /// </summary>
        /// <returns></returns>
        private unsafe bool WizardAttackTarget()
        {
            bool result;
            TUserMagic* UserMagic;
            result = false;
            if (m_btStatus != 0)
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            m_wHitMode = 0;
            if (!m_boStartUseSpell)
            {
                SearchMagic();
                // 查询魔法
                if (m_nSelectMagic == 0)
                {
                    m_boIsUseMagic = true; // 是否能躲避
                }
            }
            if (m_nSelectMagic > 0)
            {
                if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))
                {
                    // 魔法不能打到怪
                    if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7))
                    {
                        m_nSelectMagic = 0;
                        this.m_TargetCret = null;
                        return result;
                    }
                    else
                    {
                        if (m_nSelectMagic != 10)
                        {
                            // 除疾光电影外
                            GetGotoXY(this.m_TargetCret, 3);
                            // 道法只走向目标3格范围
                            GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                        }
                    }
                }
                UserMagic = FindMagic((ushort)m_nSelectMagic);
                if ((UserMagic != null))
                {
                    if ((UserMagic->btKey == 0)) // 技能打开状态才能使用
                    {
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        result = ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// 使用魔法
                        return result;
                    }
                }
            }
            this.m_dwHitTick = HUtil32.GetTickCount();
            if (GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22))//法师22级前是否物理攻击
            {
                m_boIsUseMagic = false;// 是否能躲避
                result = WarrAttackTarget(m_wHitMode);
            }
            return result;
        }

        /// <summary>
        /// 道士攻击
        /// </summary>
        /// <returns></returns>
        private unsafe bool TaoistAttackTarget()
        {
            bool result;
            TUserMagic* UserMagic;
            result = false;
            if (m_btStatus != 0)
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            m_wHitMode = 0;
            if (!m_boStartUseSpell)
            {
                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)) // 22级砍血量的怪
                {
                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                    {
                        SearchMagic();// 查询魔法
                    }
                    else
                    {
                        if ((HUtil32.GetTickCount() - m_dwSearchMagic > 1300))// 查询魔法的间隔
                        {
                            SearchMagic();// 查询魔法
                            m_dwSearchMagic = HUtil32.GetTickCount();
                        }
                    }
                }
                else
                {
                    SearchMagic(); // 查询魔法
                }
                if (m_nSelectMagic == 0)
                {
                    m_boIsUseMagic = true;// 是否能躲避 
                }
            }
            if (m_nSelectMagic > 0)
            {
                if ((!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))
                {
                    // 魔法不能打到怪
                    if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7))
                    {
                        m_nSelectMagic = 0;
                        this.m_TargetCret = null;
                        return result;
                    }
                    else
                    {
                        if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                        {
                            // 22级砍血量的怪
                            if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                            {
                                GetGotoXY(this.m_TargetCret, 3);//道法只走向目标3格范围
                                GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                            }
                        }
                        else
                        {
                            GetGotoXY(this.m_TargetCret, 3);// 道法只走向目标3格范围
                            GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                        }
                    }
                }
                switch (m_nSelectMagic)
                {
                    case MagicConst.SKILL_HEALLING:// 治愈术
                        if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // 技能打开状态才能使用 
                                ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22级砍血量的怪
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;// 能躲避
                                        return result;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// 能躲避
                                    return result;
                                }
                            }
                        }
                        if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // 技能打开状态才能使用
                                ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, null);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22级砍血量的怪
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;
                                        // 能躲避
                                        return result;
                                    }
                                    else
                                    {
                                        m_nSelectMagic = 0;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// 能躲避
                                    return result;
                                }
                            }
                        }
                        break;
                    case MagicConst.SKILL_BIGHEALLING:// 群体治疗术 
                        if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // 技能打开状态才能使用
                                ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22级砍血量的怪
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;// 能躲避
                                        return result;
                                    }
                                    else
                                    {
                                        m_nSelectMagic = 0;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// 能躲避
                                    return result;
                                }
                            }
                        }
                        if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // 技能打开状态才能使用
                                ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22级砍血量的怪
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;// 能躲避
                                        return result;
                                    }
                                    else
                                    {
                                        m_nSelectMagic = 0;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// 能躲避
                                    return result;
                                }
                            }
                        }
                        break;
                    case MagicConst.SKILL_FIRECHARM:// 灵符火符,打不到目标时,移动
                        if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret))
                        {
                            GetGotoXY(this.m_TargetCret, 3);
                            GotoTargetXY(m_nTargetX, m_nTargetY, 1);
                        }
                        break;
                    case MagicConst.SKILL_AMYOUNSUL:
                    case MagicConst.SKILL_GROUPAMYOUNSUL:// 换毒
                        if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && (GetUserItemList(2, 1) >= 0))// 绿毒
                        {
                            n_AmuletIndx = 1;//  绿毒标识
                        }
                        else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && (GetUserItemList(2, 2) >= 0))// 红毒
                        {
                            n_AmuletIndx = 2;//  红毒标识
                        }
                        break;
                    case MagicConst.SKILL_CLOAK:
                    case MagicConst.SKILL_BIGCLOAK:// 集体隐身术  隐身术
                        UserMagic = FindMagic((ushort)m_nSelectMagic);
                        if ((UserMagic != null) && (UserMagic->btKey == 0))
                        {
                            // 技能打开状态才能使用
                            ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                // 22级砍血量的怪
                                if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                {
                                    m_boIsUseMagic = false;// 能躲避
                                    return result;
                                }
                                else
                                {
                                    m_nSelectMagic = 0;
                                }
                            }
                            else
                            {
                                m_boIsUseMagic = false;// 能躲避
                                return result;
                            }
                        }
                        break;
                    case MagicConst.SKILL_48:
                    case MagicConst.SKILL_SKELLETON:
                    case MagicConst.SKILL_SINSU:
                    case MagicConst.SKILL_50:
                    case MagicConst.SKILL_72:
                    case MagicConst.SKILL_73:
                    case MagicConst.SKILL_75:// 气功波时，并进行躲避
                        UserMagic = FindMagic((ushort)m_nSelectMagic);
                        if ((UserMagic != null) && (UserMagic->btKey == 0))
                        {
                            ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);
                            // 使用魔法
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                // 22级砍血量的怪
                                if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                {
                                    m_boIsUseMagic = true;// 能躲避
                                    return result;
                                }
                                else
                                {
                                    m_nSelectMagic = 0;
                                }
                            }
                            else
                            {
                                m_boIsUseMagic = true;// 能躲避
                                return result;
                            }
                        }
                        break;
                }
                UserMagic = FindMagic((ushort)m_nSelectMagic);
                if ((UserMagic != null))
                {
                    if ((UserMagic->btKey == 0)) // 技能打开状态才能使用
                    {
                        result = ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// 使用魔法
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        if ((this.m_TargetCret.m_WAbil.MaxHP >= 700) || (!GameConfig.boHeroAttackTao))
                        {
                            return result;
                        }
                    }
                }
            }
            this.m_dwHitTick = HUtil32.GetTickCount();
            if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.15)))
            {
                m_boIsUseMagic = true;
            }
            // 是否能躲避
            if ((GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22)) || ((this.m_TargetCret.m_WAbil.MaxHP < 700) && GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)))
            {
                // 道士22级前是否物理攻击  怪等级小于英雄时
                m_boIsUseMagic = false;// 是否能躲避
                result = WarrAttackTarget(m_wHitMode);
            }
            return result;
        }

        // 是否需要躲避
        private unsafe TUserMagic* CheckUserMagic(ushort wMagIdx)
        {
            TUserMagic* result;
            int I;
            result = null;
            if (this.m_MagicList.Count > 0)
            {
                for (I = 0; I < this.m_MagicList.Count; I++)
                {
                    if (((TUserMagic*)(this.m_MagicList[I]))->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = ((TUserMagic*)(this.m_MagicList[I]));
                        break;
                    }
                }
            }
            return result;
        }

        // 检查使用魔法
        private int CheckTargetXYCount(int nX, int nY, int nRange)
        {
            int result;
            TBaseObject BaseObject;
            int I;
            int nC;
            int n10;
            result = 0;
            n10 = nRange;
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = ((TBaseObject)(((TVisibleBaseObject)(this.m_VisibleActors[I])).BaseObject));
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(nX - BaseObject.m_nCurrX) + Math.Abs(nY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    result++;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 战士判断使用
        private int CheckTargetXYCount1(int nX, int nY, int nRange)
        {
            int result;
            TBaseObject BaseObject;
            int I;
            int n10;
            result = 0;
            n10 = nRange;
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = ((TBaseObject)(((TVisibleBaseObject)(this.m_VisibleActors[I])).BaseObject));
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                if ((Math.Abs(nX - BaseObject.m_nCurrX) <= n10) && (Math.Abs(nY - BaseObject.m_nCurrY) <= n10))
                                {
                                    result++;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 半月弯刀判断目标函数
        private int CheckTargetXYCount2()
        {
            int result;
            int nC;
            int n10;
            int I;
            int nX = 0;
            int nY = 0;
            TBaseObject BaseObject = null;
            result = 0;
            nC = 0;
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    n10 = (this.m_btDirection + GameConfig.WideAttack[nC]) % 8;
                    if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, n10, 1, ref nX, ref nY))
                    {
                        //BaseObject = this.m_PEnvir.GetMovingObject(nX, nY, true);
                        if (BaseObject != null)
                        {
                            if (!BaseObject.m_boDeath)
                            {
                                if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                                {
                                    result++;
                                }
                            }
                        }
                    }
                    nC++;
                    if (nC >= 3)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        // 检查物品类型
        private unsafe bool CheckItemType(int nItemType, TStdItem* StdItem, int nItemShape)
        {
            bool result;
            result = false;
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

        // 判断装备栏里是否有指定类型的物品
        private unsafe bool CheckUserItemType(int nItemType, int nItemShape)
        {
            bool result;
            TStdItem* StdItem;
            result = false;
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
            bool result;
            // 自动换毒符
            TUserItem* UserItem;
            TUserItem* AddUserItem;
            TStdItem* StdItem;
            result = false;
            if ((nIndex >= 0) && (nIndex < this.m_ItemList.Count))
            {
                UserItem = (TUserItem*)this.m_ItemList[nIndex];
                // U_BUJUK
                if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
                {
                    // U_BUJUK
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                    if (StdItem != null)
                    {
                        switch (nItemType)
                        {
                            case 1:
                                // U_BUJUK
                                if (CheckItemType(nItemType, StdItem, nItemShape) && (this.m_UseItems[TPosition.U_ARMRINGL]->Dura >= nItemShape * 100))
                                {
                                    result = true;
                                }
                                else
                                {
                                    this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                                    AddUserItem = this.m_UseItems[TPosition.U_ARMRINGL];
                                    if (AddItemToBag(AddUserItem)) // U_BUJUK
                                    {
                                        this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                                        SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, AddUserItem);
                                        Marshal.FreeHGlobal((IntPtr)UserItem);
                                        //Dispose(UserItem);
                                        result = true;
                                    }
                                    else
                                    {
                                        this.m_ItemList.Add((IntPtr)UserItem);
                                    }
                                }
                                break;
                            case 2:
                                if (CheckItemType(nItemType, StdItem, nItemShape))
                                {
                                    result = true;
                                }
                                else
                                {
                                    this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                                    AddUserItem = this.m_UseItems[TPosition.U_ARMRINGL];
                                    if (AddItemToBag(AddUserItem))
                                    {
                                        // U_BUJUK
                                        this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                                        SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, AddUserItem);
                                        Marshal.FreeHGlobal((IntPtr)UserItem);
                                        //Dispose(UserItem);
                                        result = true;
                                    }
                                    else
                                    {
                                        this.m_ItemList.Add((IntPtr)UserItem);
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                        this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                        SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, null);
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        //Dispose(UserItem);
                        result = true;
                    }
                }
                else
                {
                    this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                    this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                    SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, null);
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    //Dispose(UserItem);
                    result = true;
                }
            }
            return result;
        }

        // 检测包裹中是否有符和毒
        // nType 为指定类型 1 为护身符 2 为毒药  如为符,则 nItemShape 表示符的持久,毒时,1-绿毒,2-红毒
        private unsafe int GetUserItemList(int nItemType, int nItemShape)
        {
            int result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = -1;
            if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                if ((StdItem != null) && (StdItem->StdMode == 25))
                {
                    switch (nItemType)
                    {
                        case 1:
                            if ((StdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nItemShape))
                            {
                                result = 1;
                                return result;
                            }
                            break;
                        case 2:
                            switch (nItemShape)
                            {
                                case 1:
                                    if (StdItem->Shape == 1)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if (StdItem->Shape == 2)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
            if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                if ((StdItem != null) && (StdItem->StdMode == 25))
                {
                    switch (nItemType)
                    {
                        case 1:
                            // 符
                            if ((StdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nItemShape))
                            {
                                result = 1;
                                return result;
                            }
                            break;
                        case 2:
                            switch (nItemShape)
                            {
                                case 1:
                                    // 毒
                                    if (StdItem->Shape == 1)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if (StdItem->Shape == 2)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
            for (I = this.m_ItemList.Count - 1; I >= 0; I--)
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
                        switch (nItemType)
                        {
                            case 1:
                                if (UserItem->Dura >= nItemShape * 100)
                                {
                                    result = I;
                                    break;
                                }
                                break;
                            case 2:
                                switch (nItemShape)
                                {
                                    case 1:
                                        if (StdItem->Shape == 1)
                                        {
                                            result = I;
                                            break;
                                        }
                                        break;
                                    case 2:
                                        if (StdItem->Shape == 2)
                                        {
                                            result = I;
                                            break;
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 攻击目标
        /// </summary>
        /// <returns></returns>
        public bool AttackTarget()
        {
            bool result = false;
            uint dwAttackTime = 0;
            if (this.m_boUseBatter)
            {
                return result;
            }
            if (m_btStatus != 0)// 跟随不打怪
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            if (this.InSafeZone() && (this.m_TargetCret != null)) // 英雄进入安全区内就不打PK目标
            {
                if ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    this.m_TargetCret = null;
                    return result;
                }
            }
            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
            switch (this.m_btJob)
            {
                case 0:
                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);// 防止负数出错  +速度 
                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime) || m_boStartUseSpell)
                    {
                        m_boIsUseMagic = false;// 是否能躲避
                        result = WarrorAttackTarget();
                    }
                    break;
                case 1:
                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWizardAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);// 防止负数出错  +速度
                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime) || m_boStartUseSpell)
                    {
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        m_boIsUseMagic = false;// 是否能躲避
                        result = WizardAttackTarget();
                        return result;
                    }
                    m_nSelectMagic = 0;
                    break;
                case 2:
                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroTaoistAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);// 防止负数出错  +速度
                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime) || m_boStartUseSpell)
                    {
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        m_boIsUseMagic = false;// 是否能躲避
                        result = TaoistAttackTarget();
                        return result;
                    }
                    m_nSelectMagic = 0;
                    break;
            }
            return result;
        }

        // 检测指定方向和范围内,主人与英雄的距离
        private unsafe void SearchMagic()
        {
            TUserMagic* UserMagic;
            m_nSelectMagic = 0;
            m_nSelectMagic = SelectMagic();
            if (m_nSelectMagic > 0)
            {
                UserMagic = FindMagic((ushort)m_nSelectMagic);
                if (UserMagic != null)
                {
                    m_boIsUseAttackMagic = IsUseAttackMagic();   // 需要毒符的魔法
                }
                else
                {
                    m_boIsUseAttackMagic = false;
                }
            }
            else
            {
                m_boIsUseAttackMagic = false;
            }
        }

        private bool IsSearchTarget()
        {
            bool result = false;
            if ((this.m_TargetCret != null))
            {
                if ((this.m_TargetCret == this))
                {
                    this.m_TargetCret = null;
                }
            }
            // 8000
            if ((this.m_TargetCret == null) && ((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 400) && (m_btStatus == 0))
            {
                this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                result = true;
                return result;
            }
            return result;
        }

        // 检查物品是否为火龙之心
        public unsafe bool WearFirDragon()
        {
            bool result;
            TStdItem* StdItem;
            result = false;
            if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                if ((StdItem != null) && (StdItem->StdMode == 25) && (StdItem->Shape == 9))
                {
                    result = true;
                }
            }
            return result;
        }

        // 修补火龙之心    btType:2--主人  4--英雄
        public unsafe void RepairFirDragon(byte btType, int nItemIdx, string sItemName)
        {
            int I;
            int n14;
            TUserItem* UserItem = null;
            TStdItem* StdItem;
            string sUserItemName;
            bool boRepairOK;
            IList<IntPtr> ItemList;
            int OldDura;
            boRepairOK = false;
            ItemList = null;
            StdItem = null;
            n14 = -1;
            OldDura = 0;
            if ((this.m_Master != null) && WearFirDragon())
            {
                if (this.m_UseItems[TPosition.U_BUJUK]->Dura < this.m_UseItems[TPosition.U_BUJUK]->DuraMax)
                {
                    OldDura = this.m_UseItems[TPosition.U_BUJUK]->Dura;
                    switch (btType)
                    {
                        case 2:
                            ItemList = this.m_Master.m_ItemList;
                            break;
                        case 4:
                            ItemList = this.m_ItemList;
                            break;
                    }
                    if (ItemList != null)
                    {
                        if (ItemList.Count > 0)
                        {
                            // 20080630
                            for (I = 0; I < ItemList.Count; I++)
                            {
                                UserItem = (TUserItem*)ItemList[I];
                                if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                                {
                                    // 取自定义物品名称
                                    sUserItemName = "";
                                    if (UserItem->btValue[13] == 1)
                                    {
                                        sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                                    }
                                    if (sUserItemName == "")
                                    {
                                        sUserItemName = UserEngine.GetStdItemName(UserItem->wIndex);
                                    }
                                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                    if (StdItem != null)
                                    {
                                        if ((sUserItemName).ToLower().CompareTo((sItemName).ToLower()) == 0)
                                        {
                                            n14 = I;
                                            break;
                                        }
                                    }
                                }
                                UserItem = null;
                            }
                        }
                        if ((StdItem != null) && (UserItem != null) && (StdItem->StdMode == 42))
                        {
                            this.m_UseItems[TPosition.U_BUJUK]->Dura += UserItem->DuraMax;
                            if (this.m_UseItems[TPosition.U_BUJUK]->Dura > this.m_UseItems[TPosition.U_BUJUK]->DuraMax)
                            {
                                this.m_UseItems[TPosition.U_BUJUK]->Dura = this.m_UseItems[TPosition.U_BUJUK]->DuraMax;
                            }
                            boRepairOK = true;
                            switch (btType)
                            {
                                case 2:
                                    this.m_Master.DelBagItem(n14);
                                    break;
                                case 4:
                                    this.DelBagItem(n14);
                                    break;
                            }
                        }
                    }
                }
            }
            if (boRepairOK)
            {
                if (OldDura != this.m_UseItems[TPosition.U_BUJUK]->Dura)
                {
                    SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_BUJUK, this.m_UseItems[TPosition.U_BUJUK]->Dura, this.m_UseItems[TPosition.U_BUJUK]->DuraMax, 0, "");
                }
                SendDefMessage(Grobal2.SM_REPAIRFIRDRAGON_OK, btType, 0, 0, 0, "");
            }
            else
            {
                SendDefMessage(Grobal2.SM_REPAIRFIRDRAGON_FAIL, btType, 0, 0, 0, "");
                SysMsg("修补火龙之心失败!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                // 20071231
            }
        }

        /// <summary>
        /// 走向目标
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nCode">多少范围内2-7</param>
        /// <returns></returns>
        public bool GetGotoXY(TBaseObject BaseObject, byte nCode)
        {
            bool result = false;
            switch (nCode)
            {
                case 2:// 刺杀位
                    if ((this.m_nCurrX - 2 <= BaseObject.m_nCurrX) && (this.m_nCurrX + 2 >= BaseObject.m_nCurrX) && (this.m_nCurrY - 2 <= BaseObject.m_nCurrY) && (this.m_nCurrY + 2 >= BaseObject.m_nCurrY) && ((this.m_nCurrX != BaseObject.m_nCurrX) || (this.m_nCurrY != BaseObject.m_nCurrY)))
                    {
                        result = true;
                        if (((this.m_nCurrX - 2) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 2;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if (((this.m_nCurrX + 2) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 2;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY - 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY - 2;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY + 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY + 2;
                            return result;
                        }
                        if (((this.m_nCurrX - 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 2;
                            m_nTargetY = this.m_nCurrY - 2;
                            return result;
                        }
                        if (((this.m_nCurrX + 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 2;
                            m_nTargetY = this.m_nCurrY - 2;
                            return result;
                        }
                        if (((this.m_nCurrX - 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 2;
                            m_nTargetY = this.m_nCurrY + 2;
                            return result;
                        }
                        if (((this.m_nCurrX + 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 2;
                            m_nTargetY = this.m_nCurrY + 2;
                            return result;
                        }
                    }
                    break;
                case 3:// 3格
                    if ((this.m_nCurrX - 3 <= BaseObject.m_nCurrX) && (this.m_nCurrX + 3 >= BaseObject.m_nCurrX) && (this.m_nCurrY - 3 <= BaseObject.m_nCurrY) && (this.m_nCurrY + 3 >= BaseObject.m_nCurrY) && ((this.m_nCurrX != BaseObject.m_nCurrX) || (this.m_nCurrY != BaseObject.m_nCurrY)))
                    {
                        result = true;
                        if (((this.m_nCurrX - 3) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 3;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if (((this.m_nCurrX + 3) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 3;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY - 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY - 3;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY + 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY + 3;
                            return result;
                        }
                        if (((this.m_nCurrX - 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 3;
                            m_nTargetY = this.m_nCurrY - 3;
                            return result;
                        }
                        if (((this.m_nCurrX + 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 3;
                            m_nTargetY = this.m_nCurrY - 3;
                            return result;
                        }
                        if (((this.m_nCurrX - 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 3;
                            m_nTargetY = this.m_nCurrY + 3;
                            return result;
                        }
                        if (((this.m_nCurrX + 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 3;
                            m_nTargetY = this.m_nCurrY + 3;
                            return result;
                        }
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// 刷新英雄永久属性能
        /// </summary>
        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_CHARSTATUSCHANGED, this.m_nHitSpeed, this.m_nCharStatus, 0, 0, "");
                RecalcAdjusBonus();
            }
        }

        // 英雄死亡   修正英雄死亡  人物被攻击 英雄自动强制召唤  
        public unsafe override void Die()
        {
            int nDecExp;
            base.Die();
            try
            {
                // 死亡掉经验,经验不足,则降级
                if (GameConfig.boHeroDieExp)
                {
                    GetLevelExp(m_Abil.Level);
                    nDecExp = (int)HUtil32.Round((double)this.m_Abil.Exp * (GameConfig.nHeroDieExpRate / 100));
                    // 掉现有经验的一定比率 20090108
                    SysMsg("(英雄) 死亡，其经验值减少了 " + (nDecExp).ToString(), TMsgColor.c_Red, TMsgType.t_Hint);
                    if (this.m_Abil.Exp >= nDecExp)
                    {
                        this.m_Abil.Exp -= (uint)nDecExp;
                    }
                    else
                    {
                        this.m_Abil.Exp = 0;
                    }
                }
                // 修复诱惑之光召唤死亡后还可以再召唤英雄
                if ((this.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (this.m_Master != null) && (((TPlayObject)(this.m_Master)).m_MyHero == this))
                {
                    // 发送英雄死亡信息
                    ((TPlayObject)(this.m_Master)).m_nRecallHeroTime = HUtil32.GetTickCount();// 召唤英雄间隔 
                    m_nLoyal = HUtil32._MAX(0, m_nLoyal - GameConfig.nDeathDecLoyal);// 死亡减少忠诚度 
                    UserEngine.SaveHeroRcd(((TPlayObject)(this.m_Master)));// 保存数据  
                    ((TPlayObject)(this.m_Master)).m_MyHero = null;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 查找魔法
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        public unsafe TUserMagic* FindMagic(int wMagIdx)
        {
            TUserMagic* result = null;
            TUserMagic* UserMagic;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = UserMagic;
                        break;
                    }
                }
            }
            return result;
        }

        public unsafe int CheckTakeOnItems_GetUserItemWeitht(int nWhere)
        {
            int result;
            int I;
            int n14;
            TStdItem* StdItem;
            n14 = 0;
            for (I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                if ((nWhere == -1) || (!(I == nWhere) && !(I == 1) && !(I == 2)))
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                    if (StdItem != null)
                    {
                        n14 += StdItem->Weight;
                    }
                }
            }
            result = n14;
            return result;
        }

        /// <summary>
        /// 英雄检查穿上装备的条件
        /// </summary>
        /// <param name="nWhere"></param>
        /// <param name="StdItem"></param>
        /// <returns></returns>
        public unsafe bool CheckTakeOnItems(int nWhere, TStdItem* StdItem)
        {
            bool result = false;
            TUserCastle Castle;
            if ((StdItem->StdMode == 10) && (this.m_btGender != 0))
            {
                SysMsg("(英雄) " + GameMsgDef.sWearNotOfWoMan, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                return result;
            }
            if ((StdItem->StdMode == 11) && (this.m_btGender != 1))
            {
                SysMsg("(英雄) " + GameMsgDef.sWearNotOfMan, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                return result;
            }
            if ((nWhere == 1) || (nWhere == 2))
            {
                if (StdItem->Weight > this.m_WAbil.MaxHandWeight)
                {
                    SysMsg("(英雄) " + GameMsgDef.sHandWeightNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    return result;
                }
            }
            else
            {
                if ((StdItem->Weight + CheckTakeOnItems_GetUserItemWeitht(nWhere)) > this.m_WAbil.MaxWearWeight)
                {
                    SysMsg("(英雄) " + GameMsgDef.sWearWeightNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    return result;
                }
            }
            Castle = M2Share.g_CastleManager.IsCastleMember(this);
            switch (StdItem->Need)
            {
                case 34:
                case 0:
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 35:
                case 1:
                    if (HUtil32.HiWord(this.m_WAbil.DC) >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sDCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 10:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (this.m_Abil.Level >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sJobOrLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 11:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sJobOrDCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 12:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sJobOrMCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 13:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sJobOrSCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 36:
                case 2:

                    if (HUtil32.HiWord(this.m_WAbil.MC) >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 37:
                case 3:

                    if (HUtil32.HiWord(this.m_WAbil.SC) >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sSCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 4:
                    if (m_btReLevel >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 18:
                    // Need=18(表示穿戴需等级，装备可提高内力恢复速度) NeedLevel=50(等级条件) Stock=3(提高内力恢复速度)
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        // m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 19:
                    // Need=19(表示穿戴需攻击力，装备可提高内力恢复速度%) NeedLevel=50(攻击力条件) Stock=3(提高内力恢复速度%)
                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Price);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 20:
                    // Need=20(表示穿戴需魔法，装备可提高内力恢复速度%) NeedLevel=50(魔法条件) Stock=3(提高内力恢复速度%)


                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 21:
                    // Need=21(表示穿戴需道术，装备可提高内力恢复速度%) NeedLevel=50(道术条件) Stock=3(提高内力恢复速度%)


                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        //m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 22:
                    // Need=22(表示穿戴需等级，装备可提高内力恢复速度+点) NeedLevel=50(等级条件) Stock=3(每次可提高内力值)
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        //m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 23:
                    // Need=23(表示穿戴需攻击力，装备可提高内力恢复速度+点) NeedLevel=50(攻击力条件) Stock=3(每次可提高内力值)


                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 24:
                    // Need=24(表示穿戴需魔法，装备可提高内力恢复速度+点) NeedLevel=50(魔法条件) Stock=3(每次可提高内力值)


                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 25:
                    // Need=25(表示穿戴需道术，装备可提高内力恢复速度+点) NeedLevel=50(道术条件) Stock=3(每次可提高内力值)


                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 26:
                    // ======物品支持防爆属性设置=============//
                    // Need-(26)需等级，Stock-为防爆点 NeedLevel-所需等级
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 27:
                    // Need-(27)需攻击力，Stock-为防爆点 NeedLevel-所需攻击力


                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 28:
                    // Need-(28)需魔法，Stock-为防爆点 NeedLevel-所需魔法
                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 29:
                    // Need-(29)需道术，Stock-为防爆点 NeedLevel-所需道术
                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 30:
                    // ===========穿戴有吸血属性 Need==============//
                    // Need-(30)需等级，Stock-为吸血点 NeedLevel-所需等级  Reserved-成功机率
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 31:
                    // Need-(31)需攻击力，Stock-为吸血点 NeedLevel-所需攻击力  Reserved-成功机率
                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 32:
                    // Need-(32)需魔法，Stock-为吸血点 NeedLevel-所需魔法  Reserved-成功机率
                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 33:
                    // Need-(33)需道术，Stock-为吸血点 NeedLevel-所需道术  Reserved-成功机率
                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 40:
                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {
                        if (this.m_Abil.Level >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(英雄) " + GameMsgDef.g_sLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 41:

                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {
                        if (HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(英雄) " + GameMsgDef.g_sDCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 42:
                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {
                        if (HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(英雄) " + GameMsgDef.g_sMCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 43:

                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {


                        if (HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(英雄) " + GameMsgDef.g_sSCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 44:
                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel)) // 声望装备,不处理
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 5:
                    result = true;
                    break;
                case 6:
                    if ((this.m_MyGuild != null))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sGuildNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 60:
                    if ((this.m_MyGuild != null) && (this.m_nGuildRankNo == 1))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sGuildMasterNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 7:
                    if ((this.m_MyGuild != null) && (Castle != null))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sSabukHumanNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 70:
                    if ((this.m_MyGuild != null) && (Castle != null) && (this.m_nGuildRankNo == 1))
                    {
                        if (this.m_Abil.Level >= StdItem->NeedLevel)
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(英雄) " + GameMsgDef.g_sLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sSabukMasterManNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 8:
                    if (m_nMemberType != 0)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMemberNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 81:
                    if ((m_nMemberType == HUtil32.LoWord(StdItem->NeedLevel)) && (m_nMemberLevel >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMemberTypeNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 82:
                    if ((m_nMemberType >= HUtil32.LoWord(StdItem->NeedLevel)) && (m_nMemberLevel >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄) " + GameMsgDef.g_sMemberTypeNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// 取技能消耗的MP值(魔法值)
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe int GetSpellPoint(TUserMagic* UserMagic)
        {
            int result = (int)HUtil32.Round((double)UserMagic->MagicInfo.wSpell / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + UserMagic->MagicInfo.btDefSpell;
            return result;
        }

        public unsafe bool DoMotaebo_CanMotaebo(TBaseObject BaseObject, int nMagicLevel)
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

        // 英雄进行野蛮冲撞
        private unsafe bool DoMotaebo(byte nDir, int nMagicLevel)
        {
            bool result;
            bool bo35;
            int I;
            int n20;
            int n24;
            int n28;
            TBaseObject PoseCreate;
            TBaseObject BaseObject_30;
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
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I++)
                {
                    PoseCreate = this.GetPoseCreate();
                    if (PoseCreate != null)
                    {
                        n28 = 0;
                        if (!DoMotaebo_CanMotaebo(PoseCreate, nMagicLevel))
                        {
                            break;
                        }
                        if (nMagicLevel >= 3)
                        {
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref nX, ref nY))
                            {
                                //BaseObject_30 = this.m_PEnvir.GetMovingObject(nX, nY, true);
                                //if ((BaseObject_30 != null) && DoMotaebo_CanMotaebo(BaseObject_30))
                                //{
                                //    BaseObject_30.CharPushed(this.m_btDirection, 1);
                                //}
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
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I++)
                {
                    this.GetFrontPosition(ref nX, ref nY);
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
                this.SendRefMsg(Grobal2.RM_RUSHKUNG, this.m_btDirection, nX, nY, 0, "");// 冲撞力不够！！！
                SysMsg("(英雄) " + GameMsgDef.sMateDoTooweak, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
            }
            if (n28 > 0)
            {
                if (n24 < 0)
                {
                    n24 = 0;
                }
                n20 = HUtil32.Random(n24 * 10) + ((n24 + 1) * 3);
                n20 = this.GetHitStruckDamage(this, n20);
                StruckDamage(n20);
                this.SendRefMsg(Grobal2.RM_STRUCK, n20, this.m_WAbil.HP, this.m_WAbil.MaxHP, 0, "");
            }
            return result;
        }

        /// <summary>
        /// 英雄使用技能
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <param name="TargeTBaseObject"></param>
        /// <returns></returns>
        public unsafe bool ClientSpellXY(TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            int nSpellPoint = 0;
            int n14;
            TBaseObject BaseObject;
            uint dwCheckTime;
            uint dwDelayTime;
            bool boIsWarrSkill;
            const string sDisableMagicCross = "当前地图不允许使用：{0}";
            result = false;
            if (UserMagic == null)
            {
                return result;
            }
            this.m_nCurrBatterMagicID = 0;
            if (!this.m_boUseBatter)
            {
                if (!m_boCanSpell)
                {
                    return result;
                }
            }
            // 不可以使用魔法，但可以使用连击技
            this.m_nCurrBatterMagicID = UserMagic->wMagIdx;
            if (this.m_boDeath || ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && !GameConfig.ClientConf.boParalyCanSpell))
            {
                return result;
            }
            // 防麻
            if (this.m_PEnvir != null)
            {
                if (!this.m_PEnvir.AllowMagics(HUtil32.SBytePtrToString(UserMagic->MagicInfo.sMagicName, 0, UserMagic->MagicInfo.MagicNameLen)))
                {
                    SysMsg(string.Format(sDisableMagicCross, HUtil32.SBytePtrToString(UserMagic->MagicInfo.sMagicName, 0, UserMagic->MagicInfo.MagicNameLen)), TMsgColor.BB_Fuchsia, TMsgType.t_Notice);
                    return result;
                }
            }
            boIsWarrSkill = MagicManager.IsWarrSkill(UserMagic->wMagIdx);// 是否是战士技能
            if (!boIsWarrSkill)
            {
                dwCheckTime = HUtil32.GetTickCount() - m_dwMagicAttackTick;
                if (dwCheckTime < m_dwMagicAttackInterval)
                {
                    m_dwMagicAttackCount++;
                    dwDelayTime = m_dwMagicAttackInterval - dwCheckTime;
                    if (dwDelayTime > GameConfig.dwHeroMagicHitIntervalTime / 3)
                    {
                        if (m_dwMagicAttackCount >= 2)
                        {
                            m_dwMagicAttackTick = HUtil32.GetTickCount();
                            m_dwMagicAttackCount = 0;
                        }
                        else
                        {
                            m_dwMagicAttackCount = 0;
                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            this.m_nSpellTick -= 450;
            this.m_nSpellTick = HUtil32._MAX(0, this.m_nSpellTick);
            if (boIsWarrSkill)
            {
                m_dwMagicAttackInterval = UserMagic->MagicInfo.dwDelayTime;
            }
            else
            {
                m_dwMagicAttackInterval = UserMagic->MagicInfo.dwDelayTime + GameConfig.dwHeroMagicHitIntervalTime;
            }
            if (HUtil32.GetTickCount() - m_dwMagicAttackTick > m_dwMagicAttackInterval)// 英雄魔法间隔
            {
                m_dwMagicAttackTick = HUtil32.GetTickCount();
                switch (UserMagic->wMagIdx)
                {
                    case MagicConst.SKILL_YEDO:// 攻杀剑术
                        if (this.m_MagicPowerHitSkill != null)
                        {
                            if (this.m_boPowerHit)
                            {
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
                        break;
                    case MagicConst.SKILL_ERGUM:// 刺杀剑法
                        if (this.m_MagicErgumSkill != null)
                        {
                            if (!this.m_boUseThrusting)
                            {
                                this.ThrustingOnOff(true);
                            }
                            else
                            {
                                this.ThrustingOnOff(false);
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_BANWOL:// 半月弯刀
                        if (this.m_MagicBanwolSkill != null)
                        {
                            if (!this.m_boUseHalfMoon)
                            {
                                this.HalfMoonOnOff(true);
                            }
                            else
                            {
                                this.HalfMoonOnOff(false);
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_FIRESWORD:// 烈火剑法
                        if (this.m_MagicFireSwordSkill != null)
                        {
                            if (this.AllowFireHitSkill())
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
                        break;
                    case MagicConst.SKILL_74:
                        // //逐日剑法 20080511
                        if (this.m_Magic74Skill != null)
                        {
                            if (this.AllowDailySkill())
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
                        break;
                    case MagicConst.SKILL_MOOTEBO:
                        // 27
                        // 野蛮冲撞
                        result = true;

                        // 3 * 1000
                        if ((HUtil32.GetTickCount() - m_dwDoMotaeboTick) > 3000)
                        {

                            m_dwDoMotaeboTick = HUtil32.GetTickCount();
                            // m_btDirection := TargeTBaseObject.m_btDirection{nTargetX};//20080409 修改野蛮冲撞的方向
                            if (this.GetAttackDir(TargeTBaseObject, ref this.m_btDirection))
                            {
                                // 20080409 修改野蛮冲撞的方向
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
                                                if (!this.CheckMagicLevelup(UserMagic))
                                                {
                                                    SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 1000);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case MagicConst.SKILL_40:
                        // 双龙斩 抱月刀法
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
                        break;
                    case 43:
                        // 开天斩
                        if (this.m_Magic42Skill != null)
                        {
                            if (this.Skill42OnOff())
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
                        break;
                    case 42:
                        // 龙影剑法
                        if (this.m_Magic43Skill != null)
                        {
                            if (this.Skill43OnOff())
                            {
                                // 20080619
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
                        break;
                    default:
                        n14 = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, nTargetX, nTargetY);
                        this.m_btDirection = (byte)n14;
                        BaseObject = null;
                        switch (UserMagic->wMagIdx)
                        {
                            // 检查目标角色，与目标座标误差范围，如果在误差范围内则修正目标座标
                            // Modify the A .. B: 60 .. 65
                            case 60:
                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || GameConfig.ClientConf.boParalyCanSpell)
                                {
                                    // 麻痹不能合击
                                    if (this.CretInNearXY(TargeTBaseObject, nTargetX, nTargetY, 12))
                                    {
                                        BaseObject = TargeTBaseObject;
                                        nTargetX = BaseObject.m_nCurrX;
                                        nTargetY = BaseObject.m_nCurrY;
                                        if (this.m_Master != null)
                                        {
                                            ((TPlayObject)(this.m_Master)).DoSpell(UserMagic, nTargetX, nTargetY, BaseObject); // 合击主人攻击
                                        }
                                    }
                                }
                                else
                                {
                                    return result;
                                }
                                break;
                            default:
                                if (this.CretInNearXY(TargeTBaseObject, nTargetX, nTargetY))
                                {
                                    BaseObject = TargeTBaseObject;
                                    nTargetX = BaseObject.m_nCurrX;
                                    nTargetY = BaseObject.m_nCurrY;
                                }
                                break;
                        }
                        if (!DoSpell(UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            this.SendRefMsg(Grobal2.RM_MAGICFIREFAIL, 0, 0, 0, 0, "");// 这句引起英雄会消失
                        }
                        result = true;
                        break;
                }
                if (this.m_boUseBatter)
                {
                    this.m_boBatterFinally = true;
                }
            }
            return result;
        }

        public unsafe int GetHitMode(int MagicID)
        {
            int result = 0;
            switch (MagicID)
            {
                case 76:// 三绝杀
                    if ((this.m_MagicSkill_76 != null))
                    {
                        result = 14;
                    }
                    break;
                case 79:// 追心刺
                    if ((this.m_MagicSkill_79 != null))
                    {
                        result = 15;
                    }
                    break;
                case 82:// 断岳斩
                    if ((this.m_MagicSkill_82 != null))
                    {
                        result = 16;
                    }
                    break;
                case 85:// 横扫千军
                    if ((this.m_MagicSkill_85 != null))
                    {
                        result = 17;
                    }
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public void ClientUseBatter_ExitBatter()
        {
            this.m_boUseBatter = false;
            m_boCanSpell = true;
            m_boCanHit = true;
            m_boCanRun = true;
            m_boCanWalk = true;
        }

        public unsafe void ClientUseBatter_GetRandomOrder()
        {
            int I;
            int J;
            ArrayList List = null;
            TUserMagic* UserMagic;
            try
            {
                for (I = 0; I <= 2; I++)
                {
                    this.bOrder[I] = this.m_nBatterOrder[I];
                }
                List = new ArrayList();
                for (I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if ((UserMagic != null) && (HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, 0, UserMagic->MagicInfo.DescrLen) == "连击") && (UserMagic->MagicInfo.btJob == this.m_btJob))
                    {
                        List.Add((UserMagic->wMagIdx as object));
                    }
                }
                for (I = List.Count - 1; I >= 0; I--)
                {
                    for (J = 0; J <= 2; J++)
                    {
                        if (((int)List[I]) == this.bOrder[J])
                        {
                            List.RemoveAt(I);
                            break;
                        }
                    }
                }
                for (I = 0; I <= 2; I++)
                {
                    if (this.bOrder[I] == 2222)
                    {
                        if (List.Count > 0)
                        {
                            J = HUtil32.Random(List.Count - 1);
                            if (J >= 0)
                            {
                                this.bOrder[I] = ((ushort)List[J]);
                                List.RemoveAt(J);
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(List);
            }
        }

        /// <summary>
        /// 使用连击
        /// </summary>
        public unsafe void ClientUseBatter()
        {
            uint dwTime;
            TUserMagic* UserMagic;
            byte bt06 = 0;
            if (this.m_nBatter == 0)
            {
                ClientUseBatter_GetRandomOrder();
                this.m_nBatterSpellTick = HUtil32.GetTickCount() - 1500;
                this.m_boBatterFinally = true;
            }
            if ((HUtil32.GetTickCount() - this.m_nBatterSpellTick > 1200))
            {
                if ((this.bOrder[this.m_nBatter] == 0) || (this.m_nBatter > 2))
                {
                    ClientUseBatter_ExitBatter();
                    return;
                }
                this.m_nBatterSpellTick = HUtil32.GetTickCount();
                switch (this.m_btJob)
                {
                    case 0:
                    case 3:
                        if (this.m_TargetCret == null)
                        {
                            ClientUseBatter_ExitBatter();
                            return;
                        }
                        else
                        {
                            if (!this.GetAttackDir(this.m_TargetCret, ref bt06))
                            {
                                // ExitBatter();
                                return;
                            }
                        }
                        this.m_boBatterFinally = false;
                        this.m_nBatterUseTick = HUtil32.GetTickCount();
                        UserMagic = FindMagic(this.bOrder[this.m_nBatter]);
                        if (UserMagic != null)
                        {
                            ClientSpellXY(UserMagic, 0, 0, null);
                            m_wHitMode = (ushort)GetHitMode(UserMagic->wMagIdx);
                            if (m_wHitMode > 0)
                            {
                                Attack(this.m_TargetCret, bt06);
                            }
                            else
                            {
                                ClientUseBatter_ExitBatter();
                            }
                        }
                        else
                        {
                            ClientUseBatter_ExitBatter();
                        }
                        break;
                    case 1:
                    case 2:
                        this.m_boBatterFinally = false;
                        m_boCanWalk = false;
                        m_boCanRun = false;
                        m_boCanHit = false;
                        m_boCanSpell = false;
                        if ((this.m_TargetCret != null) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 12) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 12)))
                        {
                            UserMagic = FindMagic(this.bOrder[this.m_nBatter]);
                            ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);
                        }
                        else
                        {
                            ClientUseBatter_ExitBatter();
                            return;
                        }
                        break;
                }
                this.m_nBatter++;
            }
        }

        public unsafe int DoSpell_MPow(TUserMagic* UserMagic)
        {
            int result;
            result = UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
            return result;
        }

        public unsafe int DoSpell_GetPower(TUserMagic* UserMagic, int nPower)
        {
            int result;
            result = (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
            return result;
        }

        public unsafe int DoSpell_GetPower13(TUserMagic* UserMagic, int nInt)
        {
            int result;
            double d10;
            double d18;
            d10 = nInt / 3.0;
            d18 = nInt - d10;
            result = (int)HUtil32.Round(d18 / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1) + d10 + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
            return result;
        }

        public unsafe void DoSpell_sub_4934B4(TBaseObject PlayObject)
        {
            if (PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura < 100)
            {
                PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura = 0;
                if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((PlayObject) as THeroObject).SendDelItems(PlayObject.m_UseItems[TPosition.U_ARMRINGL]);
                }
                PlayObject.m_UseItems[TPosition.U_ARMRINGL]->wIndex = 0;
            }
        }

        public unsafe bool DoSpell(TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject BaseObject)
        {
            bool result;
            bool boTrain;
            int nSpellPoint;
            bool boSpellFail;
            bool boSpellFire;
            int nPower;
            int nAmuletIdx;
            int nPowerRate;
            int nDelayTime;
            int nDelayTimeRate;
            uint dwDelayTime = 0;
            byte nCode;
            nCode = 0;
            result = false;
            boSpellFail = false;
            boSpellFire = true;
            nSpellPoint = GetSpellPoint(UserMagic);// 需要的魔法值
            if ((nSpellPoint > 0) && (UserMagic->wMagIdx != 68)) // 如果 需要的魔法值 >0  酒气护体不在此处减HP
            {
                if (this.m_WAbil.MP < nSpellPoint)
                {
                    return result; // 如果魔法值 小于 需要的魔法值 那么退出
                }
                this.DamageSpell(nSpellPoint);// 让英雄 减少 nSpellPoint mp
                this.HealthSpellChanged();
            }
            if (m_boTrainingNG)//学过内功心法,每攻击一次减一点内力值
            {
                m_Skill69NH = Convert.ToUInt16(HUtil32._MAX(0, m_Skill69NH - GameConfig.nHitStruckDecNH));
                this.SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, m_Skill69NH, m_Skill69MaxNH, 0, "");
            }
            nCode = 1;
            try
            {
                if (BaseObject != null)
                {
                    if ((BaseObject.m_boGhost) || (BaseObject.m_boDeath) || (BaseObject.m_WAbil.HP <= 0))
                    {
                        return result;
                    }
                }
                if (MagicManager.IsWarrSkill(UserMagic->wMagIdx))
                {
                    return result;
                }
                if ((Math.Abs(this.m_nCurrX - nTargetX) > GameConfig.nMagicAttackRage) || (Math.Abs(this.m_nCurrY - nTargetY) > GameConfig.nMagicAttackRage))
                {
                    return result;
                }
                nCode = 2;
                if ((!CheckActionStatus(UserMagic->MagicInfo.wMagicId, ref dwDelayTime)))
                {
                    return result;
                }
                if ((this.m_btJob == 0) && (UserMagic->MagicInfo.wMagicId == 61))
                {
                    //劈星斩战士效果
                    nCode = 20;
                    if (BaseObject != null)
                    {
                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
                    }
                    nCode = 21;
                    this.SendRefMsg(Grobal2.RM_MYSHOW, 5, 0, 0, 0, "");// 劈星战士自身动画
                    this.SendAttackMsg(Grobal2.RM_PIXINGHIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY);
                }
                else if ((this.m_btJob == 0) && (UserMagic->MagicInfo.wMagicId == 62))//雷霆一击战士效果
                {
                    nCode = 22;
                    if (BaseObject != null)
                    {
                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
                    }
                    nCode = 23;
                    this.SendAttackMsg(Grobal2.RM_LEITINGHIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY);
                }
                else
                {
                    switch (UserMagic->MagicInfo.wMagicId)
                    {
                        case 13:// 4级技能发不同的消息
                            if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))// 4级火符
                            {
                                this.SendRefMsg(Grobal2.RM_SPELL, 100, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            else
                            {
                                this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            break;
                        case 26:
                            break;
                        case 45:
                            if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))
                            {
                                // 四级灭天火
                                this.SendRefMsg(Grobal2.RM_SPELL, 101, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            else
                            {
                                this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            break;
                        default:
                            // 0..12,14..25,27..44,46..100:
                            this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            break;
                    }
                }

                nCode = 3;
                if ((BaseObject != null) && (UserMagic->MagicInfo.wMagicId != MagicConst.SKILL_57) && (UserMagic->MagicInfo.wMagicId != MagicConst.SKILL_54) && (UserMagic->MagicInfo.wMagicId < 100))
                {
                    if ((BaseObject.m_boDeath))
                    {
                        BaseObject = null;
                    }
                }
                boTrain = false;
                boSpellFail = false;
                boSpellFire = true;
                nCode = 4;
                switch (UserMagic->MagicInfo.wMagicId)
                {
                    case MagicConst.SKILL_FIREBALL:
                    case MagicConst.SKILL_FIREBALL2:// 火球术 大火球
                        if (MagicManager.MagMakeFireball(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_HEALLING:// 治愈术
                        if (MagicManager.MagTreatment(this, UserMagic, ref nTargetX, ref nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_AMYOUNSUL:// 施毒术
                        if (MagicManager.MagLightening(this, UserMagic, nTargetX, nTargetY, BaseObject, ref boSpellFail))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIREWIND:// 抗拒火环
                        if (MagicManager.MagPushArround(this, UserMagic->btLevel) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIRE:// 地狱火
                        if (MagicManager.MagMakeHellFire(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SHOOTLIGHTEN:// 疾光电影
                        if (MagicManager.MagMakeQuickLighting(this, UserMagic, ref nTargetX, ref nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_LIGHTENING:// 雷电术
                        if (MagicManager.MagMakeLighting(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIRECHARM:
                    case MagicConst.SKILL_HANGMAJINBUB:
                    case MagicConst.SKILL_DEJIWONHO:
                    case MagicConst.SKILL_HOLYSHIELD:
                    case MagicConst.SKILL_SKELLETON:
                    case MagicConst.SKILL_CLOAK:
                    case MagicConst.SKILL_BIGCLOAK:
                    case MagicConst.SKILL_52:
                    case MagicConst.SKILL_57:
                    case MagicConst.SKILL_59:
                        boSpellFail = true;
                        //if (Magic.CheckAmulet(this, 1, 1, ref nAmuletIdx))
                        //{
                        //    Magic.UseAmulet(this, 1, 1, ref nAmuletIdx);
                        //    switch (UserMagic->MagicInfo.wMagicId)
                        //    {
                        //        case MagicConst.SKILL_FIRECHARM:
                        //            // 13
                        //            // 灵魂火符
                        //            if (MagicManager.MagMakeFireCharm(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_HANGMAJINBUB:
                        //            // 14
                        //            // 幽灵盾
                        //            nPower = this.GetAttackPower(DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                        //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 1) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_DEJIWONHO:
                        //            // 15
                        //            // 神圣战甲术
                        //            nPower = this.GetAttackPower(DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                        //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 0) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_HOLYSHIELD:
                        //            // 16
                        //            // 困魔咒
                        //            if (MagicManager.MagMakeHolyCurtain(this, DoSpell_GetPower13(UserMagic, 40) + Magic.GetRPow(this.m_WAbil.SC) * 3, nTargetX, nTargetY) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_SKELLETON:
                        //            // 17
                        //            // 召唤骷髅
                        //            if (MagicManager.MagMakeSlave(this, UserMagic))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_CLOAK:
                        //            // 18
                        //            // 隐身术
                        //            if (MagicManager.MagMakePrivateTransparent(this, DoSpell_GetPower13(UserMagic, 30) + Magic.GetRPow(this.m_WAbil.SC) * 3))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_BIGCLOAK:
                        //            // 19
                        //            // 集体隐身术
                        //            if (MagicManager.MagMakeGroupTransparent(this, nTargetX, nTargetY, DoSpell_GetPower13(UserMagic, 30) + Magic.GetRPow(this.m_WAbil.SC) * 3))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_52:
                        //            // 诅咒术
                        //            nPower = this.GetAttackPower(DoSpell_GetPower13(UserMagic, 20) + HUtil32.LoWord(this.m_WAbil.SC) * 2, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                        //            if (this.MagMakeAbilityArea(nTargetX, nTargetY, 3, nPower) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_57:
                        //            // 复活术
                        //            if (MagicManager.MagMakeLivePlayObject(this, UserMagic, BaseObject))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_59:
                        //            // 噬血术 20080511
                        //            if (MagicManager.MagFireCharmTreatment(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //    }
                        //    boSpellFail = false;
                        //    DoSpell_sub_4934B4(this);
                        //}
                        break;
                    case MagicConst.SKILL_TAMMING:
                        // 20
                        // 诱惑之光
                        if (this.IsProperTarget(BaseObject))
                        {
                            if (MagicManager.MagTamming(this, BaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_SPACEMOVE:
                        // 21
                        // 瞬息移动
                        //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                        boSpellFire = false;
                        if (MagicManager.MagSaceMove(this, UserMagic->btLevel))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_EARTHFIRE:
                        // 22
                        // 火墙
                        nPower = this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                        nDelayTime = DoSpell_GetPower(UserMagic, 10) + (((ushort)Magic.GetRPow(this.m_WAbil.MC)) >> 1);
                        nPowerRate = (int)HUtil32.Round((double)nPower * (GameConfig.nFirePowerRate / 100));
                        // 火墙威力倍数
                        nDelayTimeRate = (int)HUtil32.Round((double)nDelayTime * (GameConfig.nFireDelayTimeRate / 100));
                        // 火墙时间
                        if (MagicManager.MagMakeFireCross(this, nPowerRate, nDelayTimeRate, nTargetX, nTargetY) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIREBOOM:
                        // 23
                        // 爆裂火焰
                        if (MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nFireBoomRage, MagicConst.SKILL_FIREBOOM))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_LIGHTFLOWER:
                        // 24
                        // 地狱雷光
                        if (MagicManager.MagElecBlizzard(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SHOWHP:// 心灵启示
                        if ((BaseObject != null) && !BaseObject.m_boShowHP)
                        {
                            if (HUtil32.Random(6) <= (UserMagic->btLevel + 3))
                            {
                                BaseObject.m_dwShowHPTick = HUtil32.GetTickCount();
                                //BaseObject.m_dwShowHPInterval = DoSpell_GetPower13(UserMagic, Magic.GetRPow(this.m_WAbil.SC) * 2 + 30) * 1000;
                                BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DOOPENHEALTH, 0, 0, 0, 0, "", 1500);
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_BIGHEALLING:// 群体治疗术
                        nPower = this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.SC) * 2, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) * 2 + 1);
                        if (MagicManager.MagBigHealing(this, nPower + this.m_WAbil.Level, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SINSU:// 召唤神兽
                        boSpellFail = true;
                        //if (Magic.CheckAmulet(this, 5, 1, ref nAmuletIdx))
                        //{
                        //    Magic.UseAmulet(this, 5, 1, ref nAmuletIdx);
                        //    if (MagicManager.MagMakeSinSuSlave(this, UserMagic))
                        //    {
                        //        boTrain = true;
                        //    }
                        //    boSpellFail = false;
                        //}
                        break;
                    case MagicConst.SKILL_SHIELD:
                    case MagicConst.SKILL_66:// 魔法盾,4级魔法盾
                        if (this.MagBubbleDefenceUp(UserMagic->btLevel, (ushort)DoSpell_GetPower(UserMagic, Magic.GetRPow(this.m_WAbil.MC) + 15)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_73:// 道力盾 
                        if (this.MagBubbleDefenceUp(UserMagic->btLevel, (ushort)DoSpell_GetPower(UserMagic, Magic.GetRPow(this.m_WAbil.SC) + 15)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_75:// 护体神盾
                        if ((HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick))
                        {
                            if (this.MagProtectionDefenceUp(UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        else
                        {
                            return result;
                        }
                        break;
                    case MagicConst.SKILL_KILLUNDEAD:
                        // 32
                        // 圣言术
                        if (this.IsProperTarget(BaseObject))
                        {
                            if (MagicManager.MagTurnUndead(this, BaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_SNOWWIND:
                        // 33
                        // 冰咆哮
                        if (MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nSnowWindRange, MagicConst.SKILL_SNOWWIND))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_UNAMYOUNSUL:
                        // 34
                        // 解毒术
                        if (MagicManager.MagMakeUnTreatment(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_WINDTEBO:
                        // 35
                        if (MagicManager.MagWindTebo(this, UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_MABE:
                        // 36
                        // 火焰冰
                        nPower = this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                        if (MagicManager.MabMabe(this, BaseObject, nPower, UserMagic->btLevel, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPLIGHTENING:
                        // 37
                        // 群体雷电术
                        if (MagicManager.MagGroupLightening(this, UserMagic, nTargetX, nTargetY, BaseObject, ref boSpellFire))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPAMYOUNSUL:
                        // 38
                        // 群体施毒术
                        if (MagicManager.MagGroupAmyounsul(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPDEDING:
                        // 39
                        // 地钉
                        if (HUtil32.GetTickCount() - m_dwDedingUseTick > GameConfig.nDedingUseTime * 1000)
                        {
                            m_dwDedingUseTick = HUtil32.GetTickCount();
                            if (MagicManager.MagGroupDeDing(this, UserMagic, nTargetX, nTargetY, BaseObject))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_41:
                        // 狮子吼
                        if (MagicManager.MagGroupMb(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_42:
                        // 开天斩
                        if (MagicManager.MagHbFireBall(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_43:
                        // 龙影剑法
                        if (MagicManager.MagHbFireBall(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_44:
                        // 寒冰掌
                        if (MagicManager.MagHbFireBall(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_45:
                        // 灭天火
                        if (MagicManager.MagMakeFireDay(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_46:
                        // boSpellFire:=False;//20080113
                        // 分身术
                        if (MagicManager.MagMakeSelf(this, BaseObject, UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_47:
                        // 火龙气焰
                        // 1
                        if (MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nFireBoomRage, MagicConst.SKILL_47))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_58:
                        // 流星火雨 20080510
                        if (MagicManager.MagBigExplosion1(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nMeteorFireRainRage))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_48:
                        // 道士
                        // 气功波
                        if (MagicManager.MagPushArround(this, UserMagic->btLevel) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_49:
                        // 净化术
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_50:
                        // 无极真气
                        if (AbilityUp(UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_51:
                        // 飓风破
                        if (MagicManager.MagGroupFengPo(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_53:
                        // 血咒
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_54:
                        // 骷髅咒
                        if (this.IsProperTargetSKILL_54(BaseObject))
                        {
                            if (MagicManager.MagTamming2(this, BaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_55:
                        // 擒龙手
                        if (MagicManager.MagMakeArrestObject(this, UserMagic, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_56:
                        // 移行换位
                        if (MagicManager.MagChangePosition(this, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_68:
                        // 英雄酒气护体 20080925
                        MagMakeHPUp(UserMagic);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_72:
                        // 召唤月灵
                        //if (Magic.CheckAmulet(this, 5, 1, ref nAmuletIdx))
                        //{
                        //    Magic.UseAmulet(this, 5, 1, ref nAmuletIdx);
                        //    if (MagicManager.MagMakeFairy(this, UserMagic))
                        //    {
                        //        boTrain = true;
                        //    }
                        //}
                        break;
                    case MagicConst.SKILL_60:
                        // 破魂斩  战+战
                        nCode = 5;
                        if (MagicManager.MagMakeSkillFire_60(this, UserMagic, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.DC), ((short)HUtil32.HiWord(this.m_WAbil.DC) - HUtil32.LoWord(this.m_WAbil.DC)) + 1) * 3))
                        {
                            boTrain = true;
                        }
                        nCode = 6;
                        break;
                    case MagicConst.SKILL_61:
                        // 劈星斩  战+道
                        nCode = 7;
                        if (MagicManager.MagMakeSkillFire_61(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        nCode = 8;
                        break;
                    case MagicConst.SKILL_62:
                        // 雷霆一击  战+法
                        nCode = 9;
                        if (MagicManager.MagMakeSkillFire_62(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        // if m_btJob = 1 then boSpellFire := False;//20080611
                        nCode = 10;
                        break;
                    case MagicConst.SKILL_63:
                        // 噬魂沼泽  道+道
                        nCode = 11;
                        if (MagicManager.MagMakeSkillFire_63(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        nCode = 12;
                        break;
                    case MagicConst.SKILL_64:
                        // 末日审判  道+法
                        nCode = 13;
                        if (MagicManager.MagMakeSkillFire_64(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        nCode = 14;
                        break;
                    case MagicConst.SKILL_65:
                        // 火龙气焰  法+法
                        nCode = 15;
                        if (MagicManager.MagMakeSkillFire_65(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1)))
                        {
                            boTrain = true;
                        }
                        nCode = 16;
                        break;
                    case MagicConst.SKILL_77:
                        // 双龙破 法师
                        MagicManager.MagMakeSkillFire_77(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_78:
                        // 虎啸诀 道士
                        MagicManager.MagMakeSkillFire_78(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_80:
                        // 凤舞祭 法师
                        MagicManager.MagMakeSkillFire_80(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_81:
                        // 八卦掌 道士
                        MagicManager.MagMakeSkillFire_81(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_83:
                        // 惊雷爆 法师
                        MagicManager.MagMakeSkillFire_83(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_84:
                        // 三焰咒 道士
                        MagicManager.MagMakeSkillFire_84(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_86:
                        // 冰天雪地   法师
                        MagicManager.MagMakeSkillFire_86(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_87:
                        // 万剑归宗   道士
                        MagicManager.MagMakeSkillFire_87(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    default:
                        break;
                }
                nCode = 17;
                m_dwActionTick = HUtil32.GetTickCount();
                // 20080713
                this.m_dwHitTick = HUtil32.GetTickCount();
                // 20080713
                m_nSelectMagic = 0;
                m_boIsUseMagic = true;
                // 是否能躲避 20080714
                if (boSpellFail)
                {
                    return result;
                }
                nCode = 18;
                if (boSpellFire)
                {
                    // 20080111 除4级少技能不发消息
                    try
                    {
                        switch (UserMagic->MagicInfo.wMagicId)
                        {
                            case 13:
                                // 20080113 除4级少技能不发消息      20080227 修改
                                if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))
                                {
                                    // 4级火符 20080111
                                    // this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 100), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                else
                                {
                                    // this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                break;
                            case 26:
                                break;
                            case 45:
                                if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))
                                {
                                    // 20080227 修改
                                    //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 101), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                else
                                {
                                    //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                break;
                            default:
                                // 0..12,14..25,27..44,46..100://20080324
                                //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                break;
                        }
                        // Case
                    }
                    catch
                    {
                    }
                }
                nCode = 19;
                if ((UserMagic->btLevel < 3) && boTrain)
                {
                    // 技能加修炼点数
                    if (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] <= this.m_Abil.Level)
                    {
                        this.TrainSkill(UserMagic, HUtil32.Random(3) + 1);
                        if (!this.CheckMagicLevelup(UserMagic))
                        {
                            SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 1000);
                        }
                    }
                }
                result = true;
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage(string.Format("{异常} THeroObject.DoSpell MagID:%d X:%d Y:%d Code:%d", UserMagic->wMagIdx, nTargetX, nTargetY, nCode));
            }
            return result;
        }

        /// <summary>
        /// 创建英雄保存数据
        /// </summary>
        /// <param name="HumanRcd"></param>
        public unsafe void MakeSaveRcd(THumDataInfo* HumanRcd)
        {
            THumData* HumData;
            TUserItem* HumItems;
            TUserItem* HumAddItems;
            TUserItem* BagItems;
            THumMagic* HumMagics;
            THumMagic* HumNGMagics;
            THumMagic* HumBatterMagics;
            TUserMagic* UserMagic;
            byte nCode;
            nCode = 0;
            try
            {
                HumanRcd->Header.boIsHero = true;
                HumanRcd->Header.btJob = this.m_btJob;
                HUtil32.StrToSByteArry(this.m_sCharName, HumanRcd->Header.sName, Grobal2.ACTORNAMELEN, ref HumanRcd->Header.NameLen);
                HumData = &HumanRcd->Data;
                HumData->m_btFHeroType = m_btMentHero;
                HUtil32.StrToSByteArry(this.m_sCharName, HumData->sChrName, Grobal2.ACTORNAMELEN, ref  HumData->ChrNameLen);
                HUtil32.StrToSByteArry(this.m_sMapName, HumData->sCurMap, Grobal2.MAPNAMELEN, ref  HumData->CurMapLen);
                HumData->wCurX = (ushort)this.m_nCurrX;
                HumData->wCurY = (ushort)this.m_nCurrY;
                HumData->btDir = this.m_btDirection;
                HumData->btHair = this.m_btHair;
                HumData->btSex = this.m_btGender;
                HumData->btJob = this.m_btJob;
                HumData->nGold = m_nFirDragonPoint;// 金币数变量用来保存怒气值
                nCode = 1;
                HumData->Abil.Level = this.m_Abil.Level;
                HumData->Abil.HP = this.m_Abil.HP;
                HumData->Abil.MP = this.m_Abil.MP;
                HumData->Abil.MaxHP = this.m_Abil.MaxHP;
                HumData->Abil.MaxMP = this.m_Abil.MaxMP;
                HumData->Abil.Exp = (int)this.m_Abil.Exp;
                HumData->Abil.MaxExp = (int)this.m_Abil.MaxExp;
                HumData->Abil.Weight = this.m_Abil.Weight;
                HumData->Abil.MaxWeight = this.m_Abil.MaxWeight;
                HumData->Abil.WearWeight = (byte)this.m_Abil.WearWeight;
                HumData->Abil.MaxWearWeight = (byte)this.m_Abil.MaxWearWeight;
                HumData->Abil.HandWeight = (byte)this.m_Abil.HandWeight;
                HumData->Abil.MaxHandWeight = (byte)this.m_Abil.MaxHandWeight;
                nCode = 2;
                HumData->Abil.NG = (ushort)m_Skill69NH;// 内功当前内力值
                HumData->Abil.MaxNG = (ushort)m_Skill69MaxNH;// 内力值上限
                nCode = 3;
                HumData->n_Reserved = this.m_Abil.Alcohol;// 酒量
                HumData->n_Reserved1 = this.m_Abil.MaxAlcohol;// 酒量上限
                HumData->n_Reserved2 = this.m_Abil.WineDrinkValue;// 醉酒度
                HumData->btUnKnow2[2] = n_DrinkWineQuality;// 饮酒时酒的品质
                HumData->UnKnow[4] = (byte)n_DrinkWineAlcohol;// 饮酒时酒的度数 
                HumData->UnKnow[5] = (byte)this.m_btMagBubbleDefenceLevel;// 魔法盾等级
                nCode = 4;
                HumData->nReserved1 = this.m_Abil.MedicineValue;// 当前药力值 
                HumData->nReserved2 = this.m_Abil.MaxMedicineValue;// 药力值上限 
                HumData->boReserved3 = n_DrinkWineDrunk;// 人是否喝酒醉了 
                HumData->nReserved3 = dw_UseMedicineTime;// 使用药酒时间,计算长时间没使用药酒 
                HumData->n_Reserved3 = n_MedicineLevel;// 药力值等级 
                HumData->Abil.HP = this.m_WAbil.HP;
                HumData->Abil.MP = this.m_WAbil.MP;
                HumData->Exp68 = (int)m_Exp68; // 酒气护体当前经验
                HumData->MaxExp68 = (int)m_MaxExp68;// 酒气护体升级经验
                nCode = 5;
                HumData->UnKnow[6] = Convert.ToByte(m_boTrainingNG); // 是否学习过内功
                if (m_boTrainingNG)
                {
                    HumData->UnKnow[7] = (byte)m_NGLevel;// 内功等级
                }
                else
                {
                    HumData->UnKnow[7] = 0;
                }
                HumData->nExpSkill69 = (int)m_ExpSkill69; // 内功当前经验
                nCode = 6;
                for (int i = 0; i < this.m_wStatusTimeArr.Length; i++)
                {
                    HumData->wStatusTimeArr[i] = this.m_wStatusTimeArr[i];
                }
                nCode = 13;
                HUtil32.StrToSByteArry(this.m_sHomeMap, HumData->sHomeMap, Grobal2.MAPNAMELEN, ref HumData->HomeMapLen);
                HumData->wHomeX = (ushort)this.m_nHomeX;
                HumData->wHomeY = (ushort)this.m_nHomeY;
                HumData->nPKPOINT = this.m_nPkPoint;
                nCode = 14;
                HumData->BonusAbil = this.m_BonusAbil;//英雄永久属性
                HumData->nBonusPoint = this.m_nBonusPoint;
                HumData->btCreditPoint = m_btCreditPoint;
                HumData->btReLevel = m_btReLevel;
                HumData->nLoyal = m_nLoyal; // 英雄的忠诚度
                HumData->n_WinExp = (int)this.m_nWinExp;// 聚灵珠累计经验
                nCode = 15;
                if (this.m_Master != null)
                {
                    HUtil32.StrToSByteArry(this.m_Master.m_sCharName, HumData->sMasterName, Grobal2.ACTORNAMELEN, ref  HumData->MasterNameLen);
                }
                nCode = 7;
                HumData->btAttatckMode = this.m_btAttatckMode;
                HumData->btIncHealth = (byte)this.m_nIncHealth;
                HumData->btIncSpell = (byte)this.m_nIncSpell;
                HumData->btIncHealing = (byte)this.m_nIncHealing;
                HumData->btFightZoneDieCount = (byte)this.m_nFightZoneDieCount;
                nCode = 8;
                HumData->btEF = n_HeroTpye;// 英雄类型 0-白日门英雄 1-卧龙英雄
                HumData->dBodyLuck = this.m_dBodyLuck;
                HumData->btLastOutStatus = this.m_btLastOutStatus;//增加 退出状态 1为死亡退出
                HUtil32.ByteArrayToBytePtr(HumData->QuestFlag, 128, this.m_QuestFlag);
                HumData->boHasHero = false;
                HumData->boIsHero = true;
                HumData->btStatus = m_btStatus;// 保存英雄的状态
                nCode = 9;
                HumItems = (TUserItem*)HumanRcd->Data.BagItemsBuff;
                HumItems[TPosition.U_DRESS] = *this.m_UseItems[TPosition.U_DRESS];
                HumItems[TPosition.U_WEAPON] = *this.m_UseItems[TPosition.U_WEAPON];
                HumItems[TPosition.U_RIGHTHAND] = *this.m_UseItems[TPosition.U_RIGHTHAND];
                HumItems[TPosition.U_HELMET] = *this.m_UseItems[TPosition.U_NECKLACE];
                HumItems[TPosition.U_NECKLACE] = *this.m_UseItems[TPosition.U_HELMET];
                HumItems[TPosition.U_ARMRINGL] = *this.m_UseItems[TPosition.U_ARMRINGL];
                HumItems[TPosition.U_ARMRINGR] = *this.m_UseItems[TPosition.U_ARMRINGR];
                HumItems[TPosition.U_RINGL] = *this.m_UseItems[TPosition.U_RINGL];
                HumItems[TPosition.U_RINGR] = *this.m_UseItems[TPosition.U_RINGR];
                nCode = 10;
                HumAddItems = (TUserItem*)HumanRcd->Data.HumAddItemsBuff;
                HumAddItems[TPosition.U_BUJUK] = *this.m_UseItems[TPosition.U_BUJUK];
                HumAddItems[TPosition.U_BELT] = *this.m_UseItems[TPosition.U_BELT];
                HumAddItems[TPosition.U_BOOTS] = *this.m_UseItems[TPosition.U_BOOTS];
                HumAddItems[TPosition.U_CHARM] = *this.m_UseItems[TPosition.U_CHARM];
                HumAddItems[TPosition.U_ZHULI] = *this.m_UseItems[TPosition.U_ZHULI];//斗笠
                nCode = 11;
                BagItems = (TUserItem*)HumanRcd->Data.BagItemsBuff;
                TBatterPulse* pbtpl = (TBatterPulse*)HumData->HumPulses;// 连击人物经络
                pbtpl[0] = this.m_HumPulses[0];
                pbtpl[1] = this.m_HumPulses[1];
                pbtpl[2] = this.m_HumPulses[2];
                pbtpl[3] = this.m_HumPulses[3];
                HumData->BatterMagicOrder[0] = (ushort)this.m_nBatterOrder[0];// 连击技能循序
                HumData->BatterMagicOrder[1] = (ushort)this.m_nBatterOrder[1];// 连击技能循序
                HumData->BatterMagicOrder[2] = (ushort)this.m_nBatterOrder[2];// 连击技能循序
                HumData->m_boIsOpenPuls = m_boisOpenPuls;// 是否打开经络
                HumData->m_nPulseExp = (uint)m_nPulseExp;// 经络修炼经验
                for (int I = 0; I < this.m_ItemList.Count; I++)
                {
                    if (I >= Grobal2.MAXHEROBAGITEM)
                    {
                        break;
                    }
                    TUserItem* item = (TUserItem*)this.m_ItemList[I];
                    if (item->wIndex == 0)  //ID为0的物品则不保存
                    {
                        continue;
                    }
                    BagItems[I] = *item;
                }
                nCode = 12;
                HumMagics = (THumMagic*)HumanRcd->Data.HumMagicsBuff;
                HumNGMagics = (THumMagic*)HumanRcd->Data.HumNGMagicsBuff;// 内功技能
                HumBatterMagics = (THumMagic*)HumanRcd->Data.HumBatterMagicsBuff;// 连击技能
                if (this.m_MagicList.Count > 0)
                {
                    int J = 0;
                    int K = 0;
                    int B = 0;
                    for (int I = 0; I < this.m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)this.m_MagicList[I];
                        if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) != "内功"))
                        {
                            if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) != "连击"))
                            {
                                if (J >= M2Share.MAXMAGIC)
                                {
                                    continue;
                                }
                                HumMagics[J].wMagIdx = UserMagic->wMagIdx;
                                HumMagics[J].btLevel = UserMagic->btLevel;
                                HumMagics[J].btKey = UserMagic->btKey;
                                HumMagics[J].nTranPoint = UserMagic->nTranPoint;
                                J++;
                            }
                            else
                            {
                                if (B >= 4)
                                {
                                    continue;
                                }
                                HumBatterMagics[B].wMagIdx = UserMagic->wMagIdx;
                                HumBatterMagics[B].btLevel = UserMagic->btLevel;
                                HumBatterMagics[B].btKey = UserMagic->btKey;
                                HumBatterMagics[B].nTranPoint = UserMagic->nTranPoint;
                                B++;
                            }
                        }
                        else
                        {
                            if (K >= M2Share.MAXMAGIC)
                            {
                                continue;
                            }
                            HumNGMagics[K].wMagIdx = UserMagic->wMagIdx;
                            HumNGMagics[K].btLevel = UserMagic->btLevel;
                            HumNGMagics[K].btKey = UserMagic->btKey;
                            HumNGMagics[K].nTranPoint = UserMagic->nTranPoint;
                            K++;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.MakeSaveRcd Code:" + nCode);
            }
        }

        /// <summary>
        /// 英雄登录
        /// </summary>
        public unsafe void Login()
        {
            TUserItem* UserItem = null;
            TUserItem* UserItem1 = null;
            TStdItem* StdItem;
            TUserMagic* UserMagic = null;
            TMagic* Magic;
            int n08;
            int n09;
            string s14;
            string sItem;
            const string sExceptionMsg = "{异常} THeroObject::Login";
            for (int I = 0; I <= 3; I++)
            {
                n09 = 0;
                if (this.m_HumPulses[I].PulseLevel > 0)
                {
                    switch (this.m_btJob)
                    {
                        case 0:
                            n08 = 76 + I * 3;
                            for (int II = 0; II < this.m_MagicList.Count; II++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[II];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == n08))
                                {
                                    n09 = 1;
                                    break;
                                }
                            }
                            if (n09 != 1)
                            {
                                Magic = UserEngine.FindMagic(n08);
                                if (Magic != null)
                                {
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = (ushort)I;
                                    UserMagic->btLevel = 3;
                                    UserMagic->btKey = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                }
                            }
                            break;
                        case 1:
                            n08 = 77 + I * 3;
                            for (int II = 0; II < this.m_MagicList.Count; II++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[II];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == n08))
                                {
                                    n09 = 1;
                                    break;
                                }
                            }
                            if (n09 != 1)
                            {
                                Magic = UserEngine.FindMagic(n08);
                                if (Magic != null)
                                {
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = (ushort)I;
                                    UserMagic->btLevel = 3;
                                    UserMagic->btKey = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                }
                            }
                            break;
                        case 2:
                            n08 = 78 + I * 3;
                            for (int II = 0; II < this.m_MagicList.Count; II++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[II];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == n08))
                                {
                                    n09 = 1;
                                    break;
                                }
                            }
                            if (n09 != 1)
                            {
                                Magic = UserEngine.FindMagic(n08);
                                if (Magic != null)
                                {
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = (ushort)I;
                                    UserMagic->btLevel = 3;
                                    UserMagic->btKey = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                }
                            }
                            break;
                        case 3:
                            break;
                    }
                }
            }
            try
            {
                // 给新人增加新人物品
                if (m_boNewHuman)
                {
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    if (UserEngine.CopyToUserItemFromName(GameConfig.sHeroBasicDrug, UserItem))
                    {
                        this.m_ItemList.Add((IntPtr)UserItem);
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                    }
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    if (UserEngine.CopyToUserItemFromName(GameConfig.sHeroWoodenSword, UserItem))
                    {
                        this.m_ItemList.Add((IntPtr)UserItem);
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                    }
                    if (this.m_btGender == 0)
                    {
                        sItem = GameConfig.sHeroClothsMan;
                    }
                    else
                    {
                        sItem = GameConfig.sHeroClothsWoman;
                    }
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    if (UserEngine.CopyToUserItemFromName(sItem, UserItem))
                    {
                        this.m_ItemList.Add((IntPtr)UserItem);
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                    }
                }
                // 检查背包中的物品是否合法
                for (int I = this.m_ItemList.Count - 1; I >= 0; I--)
                {
                    if (this.m_ItemList.Count <= 0)
                    {
                        break;
                    }
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    //增加，判断制造ID是否为负数
                    if ((UserEngine.GetStdItemName(UserItem->wIndex) == "") || (UserItem->MakeIndex < 0) || this.CheckIsOKItem(UserItem, 0))  // 检查变态物品
                    {
                        //Marshal.FreeHGlobal((IntPtr)this.m_ItemList[I]);
                        Dispose((IntPtr)this.m_ItemList[I]);
                        this.m_ItemList.RemoveAt(I);
                    }
                }
                // 检查人物身上的物品是否符合使用规则
                if (GameConfig.boCheckUserItemPlace)
                {
                    for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                    {
                        if (this.m_UseItems[I]->wIndex > 0)
                        {
                            StdItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                            if (StdItem != null)
                            {
                                if (this.CheckIsOKItem(this.m_UseItems[I], 0))// 检查变态物品
                                {
                                    this.m_UseItems[I]->wIndex = 0;
                                    continue;
                                }
                                if (!M2Share.CheckUserItems(I, StdItem))
                                {
                                    //FillChar(UserItem, sizeof(TUserItem), '\0');
                                    // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);//20080820 增加
                                    *UserItem = *this.m_UseItems[I];
                                    if (!AddItemToBag(UserItem))
                                    {
                                        this.m_ItemList.Insert(0, (IntPtr)UserItem);
                                    }
                                    this.m_UseItems[I]->wIndex = 0;
                                }
                            }
                            else
                            {
                                this.m_UseItems[I]->wIndex = 0;
                            }
                        }
                    }
                }
                // 检查和整理连击
                if (this.m_MagicList.Count > 0)
                {
                    for (int I = 0; I < this.m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)this.m_MagicList[I];
                        if (UserMagic != null)
                        {
                            if (HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) == "连击")
                            {
                                this.m_boCanUseBatter = true;
                                break;
                            }
                        }
                    }
                }
                for (int I = 0; I <= 2; I++)
                {
                    n08 = this.m_nBatterOrder[I];
                    n09 = 0;
                    if ((n08 == 0) || (n08 == 2222))
                    {
                        continue;
                    }
                    if (this.m_MagicList.Count > 0)
                    {
                        for (int II = 0; II < this.m_MagicList.Count; II++)
                        {
                            UserMagic = (TUserMagic*)this.m_MagicList[II];
                            if (UserMagic != null)
                            {
                                if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) == "连击") &&
                                    (UserMagic->MagicInfo.wMagicId == n08))
                                {
                                    this.m_boCanUseBatter = true;
                                    n09 = 8;
                                    break;
                                }
                            }
                        }
                    }
                    if (n09 != 8)
                    {
                        this.m_nBatterOrder[I] = 0;
                    }
                }
                // 整理连击循序 防止卡
                // 检查背包中是否有复制品
                for (int I = this.m_ItemList.Count - 1; I >= 0; I--)
                {
                    if (this.m_ItemList.Count <= 0)
                    {
                        break;
                    }
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    s14 = UserEngine.GetStdItemName(UserItem->wIndex);
                    for (int II = I - 1; II >= 0; II--)
                    {
                        UserItem1 = (TUserItem*)this.m_ItemList[II];
                        if ((UserEngine.GetStdItemName(UserItem1->wIndex) == s14) && (UserItem->MakeIndex == UserItem1->MakeIndex))
                        {
                            this.m_ItemList.RemoveAt(II);
                            break;
                        }
                    }
                }
                for (int I = this.m_dwStatusArrTick.GetLowerBound(0); I <= this.m_dwStatusArrTick.GetUpperBound(0); I++)
                {
                    if (this.m_wStatusTimeArr[I] > 0)
                    {
                        this.m_dwStatusArrTick[I] = HUtil32.GetTickCount();
                    }
                }
                if (this.m_btLastOutStatus == 1)
                {
                    this.m_WAbil.HP = (this.m_WAbil.MaxHP / 15) + 2;// 死亡过的英雄,血要调很低
                    this.m_btLastOutStatus = 0;
                }
                // RecalcLevelAbilitys();
                // RecalcAbilitys();
                if ((M2Share.g_ManageNPC != null) && (this.m_Master != null))
                {
                    M2Share.g_ManageNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroLogin", false);
                }
                this.m_boFixedHideMode = false;
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        /// <summary>
        /// 判断道英雄毒符是否用完,提示用户
        /// 参数 nType 为指定类型 1 为护身符 2 为毒药    nCount 为持久,即数量
        /// </summary>
        /// <param name="nType"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        private unsafe bool CheckHeroAmulet(int nType, int nCount)
        {
            bool result = false;
            TUserItem* UserItem;
            TStdItem* AmuletStdItem;
            try
            {
                result = false;
                if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
                {
                    AmuletStdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                    if ((AmuletStdItem != null) && (AmuletStdItem->StdMode == 25))
                    {
                        switch (nType)
                        {
                            case 1:
                                if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                            case 2:
                                if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                        }
                    }
                }
                if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
                {
                    AmuletStdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                    if ((AmuletStdItem != null) && (AmuletStdItem->StdMode == 25))
                    {
                        switch (nType)
                        {
                            case 1:// 符
                                if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                            case 2:// 毒
                                if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                        }
                    }
                }
                // 检测人物包裹是否存在毒,护身符
                if (this.m_ItemList.Count > 0)
                {
                    for (int I = 0; I < this.m_ItemList.Count; I++) // 人物包裹不为空
                    {
                        UserItem = (TUserItem*)this.m_ItemList[I];
                        AmuletStdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if ((AmuletStdItem != null) && (AmuletStdItem->StdMode == 25))
                        {
                            switch (nType)
                            {
                                case 1:
                                    if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                    {
                                        result = true;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                    {
                                        result = true;
                                        return result;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.CheckHeroAmulet");
            }
            return result;
        }

        /// <summary>
        /// 英雄升级触发
        /// </summary>
        /// <returns></returns>
        public bool LevelUpFunc()
        {
            bool result;
            result = false;
            if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
            {
                M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroLevelUp", false);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 英雄内功升级触发
        /// </summary>
        /// <returns></returns>
        public bool NGLevelUpFunc()
        {
            bool result;
            result = false;
            if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
            {
                M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroNGLevelUp", false);
                result = true;
            }
            return result;
        }

        // 判断道英雄毒符是否用完,提示用户
        // 英雄使用物品触发 
        private unsafe bool UseStdmodeFunItem(TStdItem* StdItem)
        {
            bool result;
            result = false;
            if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
            {
                M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@StdModeFunc" + StdItem->AniCount, false);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 客户端设置魔法开关
        /// </summary>
        /// <param name="nSkillIdx"></param>
        /// <param name="nKey"></param>
        public unsafe void ChangeHeroMagicKey(int nSkillIdx, int nKey)
        {
            int I;
            TUserMagic* UserMagic;
            if (new ArrayList(new int[] { 0, 1 }).Contains(nKey))
            {
                if (this.m_MagicList.Count > 0)
                {
                    for (I = 0; I < this.m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)this.m_MagicList[I];
                        if (UserMagic->MagicInfo.wMagicId == nSkillIdx)
                        {
                            UserMagic->btKey = (byte)nKey;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 清理背包中复制品
        /// </summary>
        /// <param name="wIndex"></param>
        /// <param name="MakeIndex"></param>
        public unsafe void ClearCopyItem(int wIndex, int MakeIndex)
        {
            int I;
            TUserItem* UserItem;
            try
            {
                this.m_boOperationItemList = true; // 防止同时操作背包列表时保存

                for (I = this.m_ItemList.Count - 1; I >= 0; I--)
                {
                    if (this.m_ItemList.Count <= 0)
                    {
                        break;
                    }
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if ((UserItem->wIndex == wIndex) && (UserItem->MakeIndex == MakeIndex))
                    {
                        SendDelItems(UserItem);
                        this.m_ItemList.RemoveAt(I);
                        break;  //只找到一件则退出，提高效率
                    }
                }
                this.m_boOperationItemList = false; // 防止同时操作背包列表时保存
            }
            catch
            {
                this.m_boOperationItemList = false; // 防止同时操作背包列表时保存
                M2Share.MainOutMessage("{异常} THeroObject.ClearCopyItem");
            }
        }

        /// <summary>
        /// 气血石功能
        /// </summary>
        private unsafe void PlaySuperRock()
        {
            TStdItem* StdItem;
            int nTempDura;
            try
            {
                if ((!this.m_boDeath) && (!this.m_boGhost) && (this.m_WAbil.HP > 0))
                {
                    if ((this.m_UseItems[TPosition.U_CHARM]->wIndex > 0) && (this.m_UseItems[TPosition.U_CHARM]->Dura > 0))
                    {
                        StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_CHARM]->wIndex);
                        if ((StdItem != null))
                        {
                            if ((StdItem->Shape > 0) && this.m_PEnvir.AllowStdItems(StdItem->ToString()))
                            {
                                switch (StdItem->Shape)
                                {
                                    case 1:// 气血石
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= GameConfig.nStartHPRock)
                                        {
                                            // 改成掉点数启用
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > GameConfig.nHPRockSpell)
                                            {
                                                dwRockAddHPTick = HUtil32.GetTickCount();// 气石加HP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nHPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nHPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
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
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= GameConfig.nStartMPRock)
                                        {
                                            // 改成掉点数启用
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > GameConfig.nMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();
                                                // 气石加MP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
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
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= GameConfig.nStartHPMPRock)
                                        {
                                            //改成掉点数启用
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > GameConfig.nHPMPRockSpell)
                                            {
                                                dwRockAddHPTick = HUtil32.GetTickCount();// 气石加HP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
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
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= GameConfig.nStartHPMPRock)
                                        {
                                            // 改成掉点数启用
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > GameConfig.nHPMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();// 气石加MP间隔
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
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
            catch
            {
                M2Share.MainOutMessage("{异常} THeroObject.PlaySuperRock");
            }
        }

        public unsafe int MagMakeHPUp_GetSpellPoint(TUserMagic* UserMagic)
        {
            int result;
            result = UserMagic->MagicInfo.wSpell + UserMagic->MagicInfo.btDefSpell;
            return result;
        }

        /// <summary>
        /// 英雄酒气护体
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        private unsafe bool MagMakeHPUp(TUserMagic* UserMagic)
        {
            bool result = false;
            int nSpellPoint;
            int n14;
            result = false;
            nSpellPoint = MagMakeHPUp_GetSpellPoint(UserMagic);
            if (nSpellPoint > 0)
            {
                if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                {
                    if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))// 时间间隔
                    {
                        if (this.m_WAbil.MP < nSpellPoint)
                        {
                            SysMsg("MP值不足!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                            return result;
                        }
                        this.DamageSpell(nSpellPoint);// 减MP值
                        this.HealthSpellChanged();
                        n14 = 300 + GameConfig.nHPUpUseTime;
                        this.m_dwStatusArrTimeOutTick[4] = Convert.ToUInt32(HUtil32.GetTickCount() + n14 * 1000);// 使用时间
                        this.m_wStatusArrValue[4] = Convert.ToUInt16(UserMagic->btLevel + 1);// 提升值
                        SysMsg("(英雄)生命值瞬间提升, 持续" + n14 + "秒", TMsgColor.c_Green, TMsgType.t_Hint);
                        SysMsg("(英雄)酒气护体已经在激活状态", TMsgColor.c_Green, TMsgType.t_Hint);
                        RecalcAbilitys();
                        this.CompareSuitItem(false);// 套装与身上装备对比
                        SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                        result = true;
                    }
                    else
                    {
                        SysMsg("(英雄)" + GameMsgDef.g_sOpenShieldOKMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    SysMsg("(英雄)醉酒度不低于" + GameConfig.nMinDrinkValue68 + "%时,才能使用此技能 ", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            return result;
        }

        // 内功技能升级
        public unsafe void NGMAGIC_LVEXP(TUserMagic* UserMagic)
        {
            if ((UserMagic != null))
            {
                if ((this.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (UserMagic->btLevel < 3) && (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] <= m_NGLevel))
                {
                    this.TrainSkill(UserMagic, HUtil32.Random(3) + 1);
                    if (!this.CheckMagicLevelup(UserMagic))
                    {
                        SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 3000);
                    }
                }
            }
        }

        public void RecalcAdjusBonus_AdjustAb(byte Abil, ushort Val, ref ushort lov, ref ushort hiv)
        {
            byte Lo = 0;
            byte Hi = 0;
            int I;
            //Lo = LoByte(Abil);
            //Hi = HiByte(Abil);
            lov = 0;
            hiv = 0;
            for (I = 1; I <= Val; I++)
            {
                if (Lo + 1 < Hi)
                {
                    Lo++;
                    lov++;
                }
                else
                {
                    Hi++;
                    hiv++;
                }
            }
        }

        // 刷新英雄永久属性
        private unsafe void RecalcAdjusBonus()
        {
            TNakedAbility* BonusTick;
            TNakedAbility* NakedAbil;
            int adc;
            int amc;
            int asc;
            int aac;
            int amac;
            ushort ldc = 0;
            ushort lmc = 0;
            ushort lsc = 0;
            ushort lac = 0;
            ushort lmac = 0;
            ushort hdc = 0;
            ushort hmc = 0;
            ushort hsc = 0;
            ushort hac = 0;
            ushort hmac = 0;
            BonusTick = null;
            NakedAbil = null;
            switch (this.m_btJob)
            {
                case 0:
                    fixed (TNakedAbility* item = &GameConfig.BonusAbilofWarr)
                    {
                        BonusTick = item;
                    }
                    fixed (TNakedAbility* item = &GameConfig.NakedAbilofWarr)
                    {
                        NakedAbil = item;
                    }
                    break;
                case 1:
                    fixed (TNakedAbility* item = &GameConfig.BonusAbilofWizard)
                    {
                        BonusTick = item;
                    }
                    fixed (TNakedAbility* item = &GameConfig.NakedAbilofWizard)
                    {
                        NakedAbil = item;
                    }
                    break;
                case 2:
                    fixed (TNakedAbility* item = &GameConfig.BonusAbilofTaos)
                    {
                        BonusTick = item;
                    }
                    fixed (TNakedAbility* item = &GameConfig.NakedAbilofTaos)
                    {
                        NakedAbil = item;
                    }
                    break;
            }
            adc = this.m_BonusAbil.DC / BonusTick->DC;
            amc = this.m_BonusAbil.MC / BonusTick->MC;
            asc = this.m_BonusAbil.SC / BonusTick->SC;
            aac = this.m_BonusAbil.AC / BonusTick->AC;
            amac = this.m_BonusAbil.MAC / BonusTick->MAC;
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->DC, (ushort)adc, ref ldc, ref hdc);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->MC, (ushort)amc, ref lmc, ref hmc);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->SC, (ushort)asc, ref lsc, ref hsc);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->AC, (ushort)aac, ref lac, ref hac);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->MAC, (ushort)amac, ref lmac, ref hmac);
            this.m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.DC) + ldc, HUtil32.HiWord(this.m_WAbil.DC) + hdc);
            this.m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.MC) + lmc, HUtil32.HiWord(this.m_WAbil.MC) + hmc);
            this.m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.SC) + lsc, HUtil32.HiWord(this.m_WAbil.SC) + hsc);
            this.m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.AC) + lac, HUtil32.HiWord(this.m_WAbil.AC) + hac);
            this.m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.MAC) + lmac, HUtil32.HiWord(this.m_WAbil.MAC) + hmac);
            this.m_WAbil.MaxHP = HUtil32._MIN(Int32.MaxValue, this.m_WAbil.MaxHP + this.m_BonusAbil.HP / BonusTick->HP);
            this.m_WAbil.MaxMP = HUtil32._MIN(Int32.MaxValue, this.m_WAbil.MaxMP + this.m_BonusAbil.MP / BonusTick->MP);
        }

        // 内功技能升级
        // 检查人物装备死亡物品是否爆
        public unsafe bool CheckItemBindDieNoDrop(TUserItem* UserItem)
        {
            bool result;
            int I;
            TItemBind ItemBind;
            result = false;
            HUtil32.EnterCriticalSection(M2Share.g_ItemBindDieNoDropName);
            try
            {
                if (M2Share.g_ItemBindDieNoDropName.Count > 0)
                {
                    for (I = 0; I < M2Share.g_ItemBindDieNoDropName.Count; I++)
                    {
                        //ItemBind = M2Share.g_ItemBindDieNoDropName[I];
                        //if (ItemBind != null)
                        //{
                        //    if (ItemBind.nItemIdx == UserItem->wIndex)
                        //    {
                        //        if (((ItemBind.sBindName).ToLower().CompareTo((this.m_sCharName).ToLower()) == 0))
                        //        {
                        //            result = true;
                        //        }
                        //        return result;
                        //    }
                        //}
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.g_ItemBindDieNoDropName);
            }
            return result;
        }

        // 检查英雄包裹的物品 脚本
        public unsafe TUserItem* QuestCheckItem(string sItemName, ref int nCount, ref int nParam, ref int nDura)
        {
            TUserItem* result = null;
            int I;
            TUserItem* UserItem;
            string s1C;
            nParam = 0;
            nDura = 0;
            nCount = 0;
            if (this.m_ItemList.Count > 0)
            {
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    s1C = UserEngine.GetStdItemName(UserItem->wIndex);
                    if ((s1C).ToLower().CompareTo((sItemName).ToLower()) == 0)
                    {
                        if (UserItem->Dura > nDura)
                        {
                            nDura = UserItem->Dura;
                            result = UserItem;
                        }
                        nParam += UserItem->Dura;
                        if (result == null)
                        {
                            result = UserItem;
                        }
                        nCount++;
                    }
                }
            }
            return result;
        }

        // 检查英雄包裹内物品
        public bool DecGold(int nGold)
        {
            bool result;
            result = false;
            if (this.m_nGold >= nGold)
            {
                this.m_nGold -= nGold;
                result = true;
            }
            return result;
        }
    }
}

