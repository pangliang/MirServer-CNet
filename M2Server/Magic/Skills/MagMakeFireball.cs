using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Skills
{
    /// <summary>
    /// 火球,大火球
    /// </summary>
    [GameMagicd("火球,大火球","火球,大火球")]
    public unsafe class MagMakeFireball
    {
        [DefaultMagic]
        public static void MakeFireball(TBaseObject PlayObject, TMagicMessage MagicMsg, ref TBaseObject TargeTBaseObject, ref bool Result)
        {
            TUserMagic* UserMagic = MagicMsg.UserMagic;
            int nTargetY = MagicMsg.nTargetY;

            Result = false;
            int nPower = 0;
            int NGSecPwr;
            if (PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject) || M2Share.g_Config.boAutoCanHit)
            {
                if (PlayObject.IsProperTarget(TargeTBaseObject))
                {
                    if ((TargeTBaseObject.m_nAntiMagic <= HUtil32.Random(10)) && (Math.Abs(TargeTBaseObject.m_nCurrX - MagicMsg.nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                    {
                        nPower = PlayObject.GetAttackPower(MagMakeFireball_GetPower(UserMagic, MagMakeFireball_MPow(UserMagic))
                            + HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                        switch (UserMagic->MagicInfo.wMagicId)
                        {
                            case MagicConst.SKILL_FIREBALL:
                                if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                {
                                    if (((TPlayObject)(PlayObject)).m_MagicSkill_208 != null)
                                    {
                                        NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_208, nPower);// 怒之火球
                                        if (TargeTBaseObject != null)
                                        {
                                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_209, nPower);// 静之火球
                                            }
                                            else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_209, nPower);// 静之火球
                                            }
                                        }
                                        nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                                    }
                                }
                                else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                {
                                    if (((THeroObject)(PlayObject)).m_MagicSkill_208 != null)
                                    {
                                        NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_208, nPower);// 怒之火球
                                        if (TargeTBaseObject != null)
                                        {
                                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_209, nPower);// 静之火球
                                            }
                                            else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_209, nPower);// 静之火球
                                            }
                                        }
                                        nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                                    }
                                }
                                break;
                            case MagicConst.SKILL_FIREBALL2:
                                if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                {
                                    if (((TPlayObject)(PlayObject)).m_MagicSkill_210 != null)
                                    {
                                        NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_210, nPower);// 怒之大火球
                                        if (TargeTBaseObject != null)
                                        {
                                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_211, nPower);// 静之大火球
                                            }
                                            else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_211, nPower);// 静之大火球
                                            }
                                        }
                                        nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                                    }
                                }
                                else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                {
                                    if (((THeroObject)(PlayObject)).m_MagicSkill_210 != null)
                                    {
                                        NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_210, nPower);// 怒之大火球
                                        if (TargeTBaseObject != null)
                                        {
                                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_211, nPower);// 静之大火球
                                            }
                                            else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                            {
                                                NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_211, nPower);// 静之火球
                                            }
                                        }
                                        nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                                    }
                                }
                                break;
                        }
                        PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(MagicMsg.nTargetX, nTargetY), 2, 0, "", 600);
                        if ((TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                        {
                            Result = true;
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
            }
            else
            {
                TargeTBaseObject = null;
            }
        }

        /// <summary>
        /// 取内功技能掉内力值
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="UserMagic"></param>
        /// <param name="Power"></param>
        /// <returns></returns>
        public unsafe static int GetNGPow(TBaseObject BaseObject, TUserMagic* UserMagic, int Power)
        {
            int result = 0;
            int nNHPoint;
            if ((UserMagic != null) && (BaseObject != null))
            {
                if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    nNHPoint = ((TPlayObject)(BaseObject)).GetSpellPoint(UserMagic);
                    if (((TPlayObject)(BaseObject)).m_Skill69NH >= nNHPoint)
                    {
                        ((TPlayObject)(BaseObject)).m_Skill69NH = (uint)HUtil32._MAX(0, ((TPlayObject)(BaseObject)).m_Skill69NH - nNHPoint);
                        ((TPlayObject)(BaseObject)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((TPlayObject)(BaseObject)).m_Skill69NH, ((TPlayObject)(BaseObject)).m_Skill69MaxNH, 0, "");
                        result = (int)HUtil32.Round((double)Power * ((UserMagic->btLevel + 1) * (M2Share.g_Config.nNGSkillRate / 100)));// 计算攻击力
                        ((TPlayObject)(BaseObject)).NGMagic_Lvexp(UserMagic);// 内功技能升级
                    }
                }
                else if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    nNHPoint = ((THeroObject)(BaseObject)).GetSpellPoint(UserMagic);
                    if (((THeroObject)(BaseObject)).m_Skill69NH >= nNHPoint)
                    {
                        ((THeroObject)(BaseObject)).m_Skill69NH = (uint)HUtil32._MAX(0, ((THeroObject)(BaseObject)).m_Skill69NH - nNHPoint);
                        ((THeroObject)(BaseObject)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(BaseObject)).m_Skill69NH, ((THeroObject)(BaseObject)).m_Skill69MaxNH, 0, "");
                        result = (int)HUtil32.Round((double)Power * ((UserMagic->btLevel + 1) * (M2Share.g_Config.nNGSkillRate / 100)));// 计算攻击力 
                        ((THeroObject)(BaseObject)).NGMAGIC_LVEXP(UserMagic);// 内功技能升级 
                    }
                }
            }
            return result;
        }


        public static int MagMakeFireball_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public static int MagMakeFireball_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1), 1) + (UserMagic->MagicInfo.btDefPower +
                HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

    }
}