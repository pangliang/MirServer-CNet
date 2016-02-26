#region -   版   权   信   息  -
//======================================================
//
//      创 建 人：没有蛀牙
//      创建时间：2013/04/14 17:51:43
//      功    能：游戏技能管理类
//      修改纪录：
// 
//======================================================
#endregion
using GameFramework;
using GameFramework.Enum;
using M2Server.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using M2Server.Skills;

namespace M2Server
{
    public unsafe class TMagicMessage
    {
        public TBaseObject PlayObject;
        public TUserMagic* UserMagic;
        public int nTargetX;
        public int nTargetY;
        public TBaseObject TargeTBaseObject;
    }

    public class TMagicManager : GameBase
    {
        // 气功波
        public int MagPushArround(TBaseObject PlayObject, int nPushLevel)
        {
            int result = 0;
            byte nDir;
            int levelgap;
            int push;
            TBaseObject BaseObject;
            if (PlayObject.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < PlayObject.m_VisibleActors.Count; I++)
                {
                    BaseObject = PlayObject.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if ((Math.Abs(PlayObject.m_nCurrX - BaseObject.m_nCurrX) <= 1) && (Math.Abs(PlayObject.m_nCurrY - BaseObject.m_nCurrY) <= 1))
                        {
                            if ((!BaseObject.m_boDeath) && (BaseObject != PlayObject))
                            {
                                if ((PlayObject.m_Abil.Level >= BaseObject.m_Abil.Level) && (!BaseObject.m_boStickMode))
                                {
                                    levelgap = PlayObject.m_Abil.Level - BaseObject.m_Abil.Level;
                                    if ((HUtil32.Random(20) < 6 + nPushLevel * 3 + levelgap))
                                    {
                                        if (PlayObject.IsProperTarget(BaseObject))
                                        {
                                            push = 1 + HUtil32._MAX(0, nPushLevel - 1) + HUtil32.Random(3);
                                            nDir = M2Share.GetNextDirection(PlayObject.m_nCurrX, PlayObject.m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
                                            BaseObject.CharPushed(nDir, push);
                                            result++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 群体治疗术
        public bool MagBigHealing(TBaseObject PlayObject, int nPower, int nX, int nY)
        {
            bool result;
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            result = false;
            BaseObjectList = new List<TBaseObject>();
            BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, nX, nY, 1);
            if (BaseObjectList.Count > 0)
            {
                for (int I = 0; I < BaseObjectList.Count; I++)
                {
                    BaseObject = BaseObjectList[I];
                    if (PlayObject.IsProperFriend(BaseObject))
                    {
                        if (BaseObject.m_WAbil.HP < BaseObject.m_WAbil.MaxHP)
                        {
                            BaseObject.SendDelayMsg(PlayObject, Grobal2.RM_MAGHEALING, 0, nPower, 0, 0, "", 800);
                            result = true;
                        }
                        if (PlayObject.m_boAbilSeeHealGauge)
                        {
                            PlayObject.SendMsg(BaseObject, Grobal2.RM_10414, 0, 0, 0, 0, "");
                        }
                    }
                }
            }
            return result;
        }

        public unsafe int MagMakeFireball_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeFireball_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1), 1) + (UserMagic->MagicInfo.btDefPower +
                HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        /// <summary>
        /// 火球,大火球
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="UserMagic"></param>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <param name="TargeTBaseObject"></param>
        /// <returns></returns>
        public unsafe bool MagMakeFireball(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower = 0;
            int NGSecPwr;
            if (PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject) || M2Share.g_Config.boAutoCanHit)
            {
                if (PlayObject.IsProperTarget(TargeTBaseObject))
                {
                    if ((TargeTBaseObject.m_nAntiMagic <= HUtil32.Random(10)) && (Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
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
                        PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, 0, "", 600);
                        if ((TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
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
            }
            else
            {
                TargeTBaseObject = null;
            }
            return result;
        }

        public unsafe int MagTreatment_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagTreatment_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 治愈术
        public unsafe bool MagTreatment(TBaseObject PlayObject, TUserMagic* UserMagic, ref int nTargetX, ref int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (TargeTBaseObject == null)
            {
                TargeTBaseObject = PlayObject;
                nTargetX = PlayObject.m_nCurrX;
                nTargetY = PlayObject.m_nCurrY;
            }
            if (PlayObject.IsProperFriend(TargeTBaseObject))
            {
                nPower = PlayObject.GetAttackPower(MagTreatment_GetPower(UserMagic, MagTreatment_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.SC) * 2,
                    ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) * 2 + 1) + PlayObject.m_WAbil.Level;
                if (TargeTBaseObject.m_WAbil.HP < TargeTBaseObject.m_WAbil.MaxHP)
                {
                    TargeTBaseObject.SendDelayMsg(PlayObject, Grobal2.RM_MAGHEALING, 0, nPower, 0, 0, "", 800);
                    result = true;
                }
                if (PlayObject.m_boAbilSeeHealGauge)// 心灵启示
                {
                    PlayObject.SendMsg(TargeTBaseObject, Grobal2.RM_10414, 0, 0, 0, 0, "");
                }
            }
            return result;
        }

        public unsafe int MagMakeHellFire_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeHellFire_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 地狱火
        public unsafe bool MagMakeHellFire(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            int nSccPwr = 0;
            int n1C;
            int NGSecPwr;
            int n14 = 0;
            int n18 = 0;
            n1C = M2Share.GetNextDirection(PlayObject.m_nCurrX, PlayObject.m_nCurrY, nTargetX, nTargetY);
            if (PlayObject.m_PEnvir.GetNextPosition(PlayObject.m_nCurrX, PlayObject.m_nCurrY, n1C, 1, ref n14, ref n18))
            {
                PlayObject.m_PEnvir.GetNextPosition(PlayObject.m_nCurrX, PlayObject.m_nCurrY, n1C, 5, ref nTargetX, ref nTargetY);
                nSccPwr = PlayObject.GetAttackPower(MagMakeHellFire_GetPower(UserMagic, MagMakeHellFire_MPow(UserMagic)) +
                    HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                nPower = nSccPwr;
                if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_214, nSccPwr);// 怒之地狱火
                    nPower = HUtil32._MAX(0, nSccPwr + NGSecPwr);
                }
                else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_214, nSccPwr);// 怒之地狱火
                    nPower = HUtil32._MAX(0, nSccPwr + NGSecPwr);
                }
                if (PlayObject.MagPassThroughMagic(n14, n18, nTargetX, nTargetY, n1C, nPower, nSccPwr, false, MagicConst.SKILL_FIRE) > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public unsafe int MagMakeQuickLighting_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeQuickLighting_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                 + (UserMagic->MagicInfo.btDefPower
                 + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 疾光电影
        public unsafe bool MagMakeQuickLighting(TBaseObject PlayObject, TUserMagic* UserMagic, ref int nTargetX, ref int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            int nPower = 0;
            int nSccPwr = 0;
            int n1C = 0;
            int NGSecPwr = 0;
            int n14 = 0;
            int n18 = 0;
            result = false;
            n1C = M2Share.GetNextDirection(PlayObject.m_nCurrX, PlayObject.m_nCurrY, nTargetX, nTargetY);
            if (PlayObject.m_PEnvir.GetNextPosition(PlayObject.m_nCurrX, PlayObject.m_nCurrY, n1C, 1, ref n14, ref n18))
            {
                PlayObject.m_PEnvir.GetNextPosition(PlayObject.m_nCurrX, PlayObject.m_nCurrY, n1C, 8, ref nTargetX, ref nTargetY);
                nSccPwr = PlayObject.GetAttackPower(MagMakeQuickLighting_GetPower(UserMagic, MagMakeQuickLighting_MPow(UserMagic)) +
                     HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                nPower = nSccPwr;
                if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_216, nSccPwr);// 怒之疾光电影
                    nPower = HUtil32._MAX(0, nSccPwr + NGSecPwr);
                }
                else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_216, nSccPwr);// 怒之疾光电影
                    nPower = HUtil32._MAX(0, nSccPwr + NGSecPwr);
                }
                if (PlayObject.MagPassThroughMagic(n14, n18, nTargetX, nTargetY, n1C, nPower, nSccPwr, true, MagicConst.SKILL_SHOOTLIGHTEN) > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public unsafe int MagMakeLighting_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeLighting_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                 + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 雷电术(人,英雄使用此过程,人形外)
        public unsafe bool MagMakeLighting(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower = 0;
            int NGSecPwr;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeLighting_GetPower(UserMagic, MagMakeLighting_MPow(UserMagic)) +
                         HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC))
                         + 1);
                    if (TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                    {
                        nPower = (int)HUtil32.Round(nPower * 1.5);
                    }
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        if (((TPlayObject)(PlayObject)).m_MagicSkill_222 != null)
                        {
                            NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_222, nPower);// 怒之雷电
                            if (TargeTBaseObject != null)
                            {
                                if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_223, nPower);// 静之雷电
                                }
                                else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_223, nPower);// 静之雷电
                                }
                            }
                            nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                        }
                    }
                    else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        if (((THeroObject)(PlayObject)).m_MagicSkill_222 != null)
                        {
                            NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_222, nPower);// 怒之雷电
                            if (TargeTBaseObject != null)
                            {
                                if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_223, nPower);// 静之雷电
                                }
                                else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_223, nPower);// 静之雷电
                                }
                            }
                            nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                        }
                    }
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2,
                        Parse(TargeTBaseObject), "", 600);
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

        public unsafe int MagMakeFireCharm_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeFireCharm_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                  (UserMagic->MagicInfo.btDefPower
                  + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 灵魂火符(支持四级火符)
        public unsafe bool MagMakeFireCharm(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = true;
            int nPower = 0;
            int NGSecPwr = 0;
            result = false;
            if (PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject))// 魔法能攻的目标
            {
                if (PlayObject.IsProperTarget(TargeTBaseObject))// 是否是适当的目标
                {
                    if (HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic)
                    {
                        if ((Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                        {
                            nPower = PlayObject.GetAttackPower(MagMakeFireCharm_GetPower(UserMagic, MagMakeFireCharm_MPow(UserMagic)) +
                                HUtil32.LoWord(PlayObject.m_WAbil.SC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) -
                                HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                            if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (UserMagic->btLevel == 4))
                            {
                                // 英雄判断是否是4级技能,忠诚度达到后,增加攻击力
                                if (((THeroObject)(PlayObject)).m_nLoyal >= M2Share.g_Config.nGotoLV4)
                                {
                                    nPower = nPower + M2Share.g_Config.nPowerLV4;// 攻击力比普通魔法增加
                                }
                            }
                            if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                            {
                                if (((TPlayObject)(PlayObject)).m_MagicSkill_230 != null)
                                {
                                    NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_230, nPower);// 怒之火符
                                    if (TargeTBaseObject != null)
                                    {
                                        if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_231, nPower);// 静之火符
                                        }
                                        else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_231, nPower);// 静之火符
                                        }
                                    }
                                    nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                                }
                            }
                            else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                if (((THeroObject)(PlayObject)).m_MagicSkill_230 != null)
                                {
                                    NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_230, nPower);// 怒之火符
                                    if (TargeTBaseObject != null)
                                    {
                                        if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_231, nPower);// 静之火符
                                        }
                                        else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_231, nPower);// 静之火符
                                        }
                                    }
                                    nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                                }
                            }
                            if (M2Share.g_Config.boAutoCanHit)// 智能锁定
                            {
                                PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower,
                                    HUtil32.MakeLong(TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY), 2, Parse(TargeTBaseObject), "", 600);
                            }
                            else
                            {
                                PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 600);
                            }
                            if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                result = true;
                            }
                            else if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            else
            {
                TargeTBaseObject = null;
            }
            return result;
        }

        public unsafe int MagFireCharmTreatment_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagFireCharmTreatment_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                  + (UserMagic->MagicInfo.btDefPower
                  + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 驱使护身符，对敌人造成伤害。命中后，还可吸取对方生命，为自己回复一定的血量。可以无视某些地形障碍，直击敌人的要害！
        public unsafe bool MagFireCharmTreatment(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower = 0;
            int NGSecPwr;
            if (PlayObject.IsProperTarget(TargeTBaseObject)) // 是否是适当的目标
            {
                if (HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic)
                {
                    if ((Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                    {
                        nPower = PlayObject.GetAttackPower(MagFireCharmTreatment_GetPower(UserMagic, MagFireCharmTreatment_MPow(UserMagic)) +
                            HUtil32.LoWord(PlayObject.m_WAbil.SC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                        NGSecPwr = 0;
                        if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                        {
                            if (((TPlayObject)(PlayObject)).m_MagicSkill_232 != null)
                            {
                                NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_232, nPower);// 怒之噬血
                                if (TargeTBaseObject != null)
                                {
                                    if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_233, nPower);// 静之噬血
                                    }
                                    else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_233, nPower);// 静之噬血
                                    }
                                }
                                nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                            }
                        }
                        else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                        {
                            if (((THeroObject)(PlayObject)).m_MagicSkill_232 != null)
                            {
                                NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_232, nPower);// 怒之噬血
                                if (TargeTBaseObject != null)
                                {
                                    if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_233, nPower);// 静之噬血
                                    }
                                    else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_233, nPower);// 静之噬血
                                    }
                                }
                                nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                            }
                        }
                        PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2,
                            Parse(TargeTBaseObject), "", 1000);
                        if (PlayObject.m_WAbil.HP < PlayObject.m_WAbil.MaxHP)
                        {
                            // 回复一定的HP值
                            nPower = (int)HUtil32.Round((double)nPower * M2Share.g_Config.nMagFireCharmTreatment / 100);
                            PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_MAGHEALING, 0, nPower, 0, 0, "", 800);
                            PlayObject.SendRefMsg(Grobal2.RM_MYSHOW, 11, 0, 0, 0, "");
                        }
                        if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                        {
                            result = true;
                        }
                        else if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public unsafe int MagMakeFireDay_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeFireDay_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                (UserMagic->MagicInfo.btDefPower
                + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 灭天火 支持4级技能
        public unsafe bool MagMakeFireDay(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower = 0;
            int NGSecPwr;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeFireDay_GetPower(UserMagic, MagMakeFireDay_MPow(UserMagic)) +
                        HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                    if (TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                    {
                        nPower = (int)HUtil32.Round(nPower * 1.5);
                    }
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (UserMagic->btLevel == 4))
                    {
                        if (((THeroObject)(PlayObject)).m_nLoyal >= M2Share.g_Config.nGotoLV4)
                        {
                            nPower = nPower + M2Share.g_Config.nPowerLV4;// 攻击力比普通魔法增加
                        }
                    }
                    NGSecPwr = 0;
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        if (((TPlayObject)(PlayObject)).m_MagicSkill_228 != null)
                        {
                            NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_228, nPower);// 怒之灭天火
                            if (TargeTBaseObject != null)
                            {
                                if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_229, nPower);// 静之灭天火
                                }
                                else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_229, nPower);// 静之灭天火
                                }
                            }
                            nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                        }
                    }
                    else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        if (((THeroObject)(PlayObject)).m_MagicSkill_228 != null)
                        {
                            NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_228, nPower);// 怒之灭天火
                            if (TargeTBaseObject != null)
                            {
                                if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_229, nPower);// 静之灭天火
                                }
                                else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_229, nPower);// 静之灭天火
                                }
                            }
                            nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                        }
                    }
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 600);
                    if (M2Share.g_Config.boPlayObjectReduceMP)
                    {
                        TargeTBaseObject.DamageSpell((int)Math.Abs(HUtil32.Round(nPower * 0.35)));  // 击中减MP值,减35%
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

        // 解毒术
        public unsafe bool MagMakeUnTreatment(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            if (TargeTBaseObject == null)
            {
                TargeTBaseObject = PlayObject;
            }
            if (PlayObject.IsProperFriend(TargeTBaseObject))
            {
                if (HUtil32.Random(7) - (UserMagic->btLevel + 1) < 0)
                {
                    if (TargeTBaseObject.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] != 0)
                    {
                        TargeTBaseObject.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] = 1;
                        result = true;
                    }
                    if (TargeTBaseObject.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] != 0)
                    {
                        TargeTBaseObject.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] = 1;
                        result = true;
                    }
                    if (TargeTBaseObject.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0)
                    {
                        TargeTBaseObject.m_wStatusTimeArr[Grobal2.POISON_STONE] = 1;
                        result = true;
                    }
                }
            }
            return result;
        }

        // 复活术
        public unsafe bool MagMakeLivePlayObject(TBaseObject PlayObject, TUserMagic* UserMagic, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            if (PlayObject.IsProperTargetSKILL_57(TargeTBaseObject))
            {
                if ((HUtil32.Random(10 + UserMagic->btLevel) + UserMagic->btLevel) >= 8)
                {
                    ((TPlayObject)(TargeTBaseObject)).ReAlive();
                    ((TPlayObject)(TargeTBaseObject)).m_WAbil.HP = ((TPlayObject)(TargeTBaseObject)).m_WAbil.MaxHP;
                    ((TPlayObject)(TargeTBaseObject)).SendMsg(((TPlayObject)(TargeTBaseObject)), Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                    result = true;
                }
            }
            return result;
        }

        // 擒龙手
        public unsafe bool MagMakeArrestObject(TBaseObject PlayObject, TUserMagic* UserMagic, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nX = 0;
            int nY = 0;
            if (PlayObject.IsProperTargetSKILL_55(PlayObject.m_WAbil.Level, TargeTBaseObject))
            {
                if ((HUtil32.Random(10 + UserMagic->btLevel) + UserMagic->btLevel) >= 5)
                {
                    PlayObject.GetFrontPosition(ref nX, ref nY);
                    TargeTBaseObject.SpaceMove(TargeTBaseObject.m_PEnvir.sMapName, nX, nY, 0);
                    TargeTBaseObject.SendRefMsg(Grobal2.RM_MONMOVE, 0, nX, nY, 0, "");
                    result = true;
                }
            }
            return result;
        }

        // 移行换位--未使用
        public bool MagChangePosition2(TBaseObject PlayObject, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            if (!PlayObject.m_boOnHorse)
            {
                PlayObject.SendRefMsg(Grobal2.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
                PlayObject.SpaceMove(PlayObject.m_PEnvir.sMapName, nTargetX, nTargetY, 0);
                result = true;
            }
            return result;
        }

        // 移行换位
        public bool MagChangePosition(TBaseObject PlayObject, int nTargetX, int nTargetY)
        {
            bool result = false;
            if (!PlayObject.m_boOnHorse)
            {
                if (PlayObject.m_PEnvir.CanWalk(nTargetX, nTargetY, true) && (PlayObject.m_PEnvir.GetXYObjCount(nTargetX, nTargetY) == 0))
                {
                    PlayObject.SendRefMsg(Grobal2.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
                    PlayObject.SpaceMove2(nTargetX, nTargetY, 0);
                    result = true;
                }
            }
            return result;
        }

        // 破魂斩 战+战
        public unsafe bool MagMakeSkillFire_60(TBaseObject PlayObject, TUserMagic* UserMagic, int nPower)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            TBaseObject TargeTBaseObject;
            int nPowerValue;
            try
            {
                PlayObject.GetDirectionBaseObjects(PlayObject.m_btDirection, M2Share.g_Config.nHeroAttackRange_60, BaseObjectList);// 自己方向的目标
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];// 目标
                        if (PlayObject.IsProperTarget(TargeTBaseObject))
                        {
                            if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)  // 合击不打自己的英雄
                            {
                                if ((((TPlayObject)(PlayObject)).m_MyHero != null) && (TargeTBaseObject != null))
                                {
                                    if (((TPlayObject)(PlayObject)).m_MyHero == TargeTBaseObject)
                                    {
                                        continue;
                                    }
                                }
                            }
                            if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                if (!((THeroObject)(PlayObject)).m_boTarget) // 修正英雄锁定后,不打锁定怪
                                {
                                    PlayObject.SetTargetCreat(TargeTBaseObject);
                                }
                            }
                            else
                            {
                                PlayObject.SetTargetCreat(TargeTBaseObject);
                            }
                            nPowerValue = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nHeroAttackRate_60 / 100));
                            if ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))// 目标是人或英雄则判断酒量
                            {
                                nPowerValue = (int)HUtil32.Round((double)nPowerValue * (M2Share.g_Config.nDecDragonRate / 100));// 合击对人的伤害比例
                                if (TargeTBaseObject.m_Abil.WineDrinkValue > 0)// 酒量不为0时
                                {
                                    nPowerValue = (int)HUtil32.Round((double)nPowerValue * (1 - M2Share.g_Config.nDecDragonHitPoint / 100));
                                    TargeTBaseObject.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_DRINKDECDRAGON, 0, 0, 0, "");// 喝酒抵御合击，显示自身效果
                                }
                            }
                            TargeTBaseObject.SendMsg(PlayObject, Grobal2.RM_MAGSTRUCK, 0, nPowerValue, 0, 0, ""); // 发送目标消息
                            PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect),
                                HUtil32.MakeLong(TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY), Parse(TargeTBaseObject), "");// 发送人物消息 
                            if (M2Share.g_Config.ErgumBadProtection)
                            {
                                Magic.FinancialsDefence(TargeTBaseObject);// 合击破保护神盾
                            }
                            result = true;
                        }
                    }
                }
            }
            finally
            {

            }
            return result;
        }

        public unsafe int MagMakeSkillFire_61_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_61_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                  (UserMagic->MagicInfo.btDefPower +
                  HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 劈星斩  战+道
        public unsafe bool MagMakeSkillFire_61(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            byte nCode;
            nCode = 0;
            try
            {
                nPower = 0;
                if (PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject))
                {
                    nCode = 1;
                    if (PlayObject.IsProperTarget(TargeTBaseObject))// 修改随机值
                    {
                        if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) // 合击不打自己的英雄
                        {
                            if ((((TPlayObject)(PlayObject)).m_MyHero != null) && (TargeTBaseObject != null))
                            {
                                if (((TPlayObject)(PlayObject)).m_MyHero == TargeTBaseObject)
                                {
                                    return result;
                                }
                            }
                        }
                        nCode = 2;
                        if ((HUtil32.Random(TargeTBaseObject.m_nAntiMagic + 10) <= 10) && (Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                        {
                            nCode = 3;
                            switch (PlayObject.m_btJob)
                            {
                                case 2:
                                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_61_GetPower(UserMagic, MagMakeSkillFire_61_MPow(UserMagic))
                                        + HUtil32.LoWord(PlayObject.m_WAbil.SC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) -
                                        HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1) * 2;
                                    break;
                                case 0:
                                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_61_GetPower(UserMagic, MagMakeSkillFire_61_MPow(UserMagic))
                                        + HUtil32.LoWord(PlayObject.m_WAbil.DC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.DC) -
                                        HUtil32.LoWord(PlayObject.m_WAbil.DC)) + 1) * 2;
                                    break;
                            }
                            nCode = 4;
                            nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nHeroAttackRate_61 / 100));// 劈星斩威力
                            nCode = 5;
                            if (TargeTBaseObject != null)
                            {
                                if ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))// 目标是人或英雄则判断酒量
                                {
                                    nCode = 8;
                                    nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nDecDragonRate / 100));// 合击对人的伤害比例
                                    if (TargeTBaseObject.m_Abil.WineDrinkValue > 0)// 酒量不为0时
                                    {
                                        nCode = 9;
                                        nPower = (int)HUtil32.Round((double)nPower * (1 - M2Share.g_Config.nDecDragonHitPoint / 100));
                                        TargeTBaseObject.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_DRINKDECDRAGON, 0, 0, 0, "");// 喝酒抵御合击，显示自身效果
                                    }
                                }
                            }
                            PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 500);
                            nCode = 6;
                            if (M2Share.g_Config.ErgumBadProtection)
                            {
                                Magic.FinancialsDefence(TargeTBaseObject); // 合击破保护神盾
                            }
                            nCode = 7;
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
                else
                {
                    TargeTBaseObject = null;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagMakeSkillFire_61 Code:" + (nCode).ToString());
            }
            return result;
        }

        public unsafe int MagMakeSkillFire_62_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_62_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                 (UserMagic->MagicInfo.btDefPower
                 + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 雷霆一击  战+法
        public unsafe bool MagMakeSkillFire_62(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            byte nCode;
            nPower = 0;
            nCode = 0;
            try
            {
                if (PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject))
                {
                    nCode = 1;
                    if (PlayObject.IsProperTarget(TargeTBaseObject)) // 修改随机值
                    {
                        if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)  // 合击不打自己的英雄
                        {
                            if ((((TPlayObject)(PlayObject)).m_MyHero != null) && (TargeTBaseObject != null))
                            {
                                if (((TPlayObject)(PlayObject)).m_MyHero == TargeTBaseObject)
                                {
                                    return result;
                                }
                            }
                        }
                        nCode = 2;
                        if ((HUtil32.Random(TargeTBaseObject.m_nAntiMagic + 10) <= 10) && (Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                        {
                            nCode = 3;
                            switch (PlayObject.m_btJob)
                            {
                                case 1:
                                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_62_GetPower(UserMagic, MagMakeSkillFire_62_MPow(UserMagic))
                                        + HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) -
                                        HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1) * 2;
                                    break;
                                case 0:
                                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_62_GetPower(UserMagic, MagMakeSkillFire_62_MPow(UserMagic))
                                        + HUtil32.LoWord(PlayObject.m_WAbil.DC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.DC) -
                                        HUtil32.LoWord(PlayObject.m_WAbil.DC)) + 1) * 2;
                                    break;
                            }
                            nCode = 4;
                            nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nHeroAttackRate_62 / 100));// 雷霆一击威力 20080131
                            nCode = 5;
                            if ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))  // 目标是人或英雄则判断酒量
                            {
                                nCode = 8;
                                nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nDecDragonRate / 100));// 合击对人的伤害比例
                                if (TargeTBaseObject.m_Abil.WineDrinkValue > 0)  // 酒量不为0时
                                {
                                    nCode = 9;
                                    nPower = (int)HUtil32.Round((double)nPower * (1 - M2Share.g_Config.nDecDragonHitPoint / 100));
                                    TargeTBaseObject.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_DRINKDECDRAGON, 0, 0, 0, "");// 喝酒抵御合击，显示自身效果
                                }
                            }
                            nCode = 11;
                            PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 600);
                            nCode = 12;
                            if (M2Share.g_Config.ErgumBadProtection)
                            {
                                Magic.FinancialsDefence(TargeTBaseObject);// 合击破保护神盾
                            }
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
                else
                {
                    TargeTBaseObject = null;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagMakeSkillFire_62 Code:" + (nCode).ToString());
            }
            return result;
        }

        // 噬魂沼泽 道+道
        public unsafe bool MagMakeSkillFire_63(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            int nPower = 0;
            try
            {
                if (PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject)) // 魔法是否可以打到目标
                {
                    BaseObjectList = new List<TBaseObject>();
                    try
                    {
                        BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, nTargetX, nTargetY, M2Share.g_Config.nHeroAttackRange_63);// 噬魂沼泽 攻击范围 
                        if (BaseObjectList.Count > 0)
                        {
                            for (int I = 0; I < BaseObjectList.Count; I++)
                            {
                                BaseObject = BaseObjectList[I];
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (PlayObject == BaseObject))
                                {
                                    continue;
                                }
                                if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    if ((((TPlayObject)(PlayObject)).m_MyHero != null))// 不打自己英雄
                                    {
                                        if ((((TPlayObject)(PlayObject)).m_MyHero == BaseObject))
                                        {
                                            continue;
                                        }
                                    }
                                }
                                if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (PlayObject.m_Master != null))
                                {
                                    if ((PlayObject.m_Master == BaseObject))
                                    {
                                        continue;
                                    }
                                }
                                if (PlayObject.IsProperTarget(BaseObject))
                                {
                                    if (HUtil32.Random(BaseObject.m_btAntiPoison + 7) <= 7)
                                    {
                                        result = true;
                                        nPower = PlayObject.GetAttackPower(Magic.GetPower(Magic.MPow(UserMagic), UserMagic) + HUtil32.LoWord(PlayObject.m_WAbil.SC),
                                            ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1) * 2;
                                        nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nHeroAttackRate_63 / 100));// 噬魂沼泽威力
                                        if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)) // 目标是人或英雄则判断酒量
                                        {
                                            nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nDecDragonRate / 100));// 合击对人的伤害比例
                                            if (BaseObject.m_Abil.WineDrinkValue > 0) // 酒量不为0时
                                            {
                                                nPower = (int)HUtil32.Round((double)nPower * (1 - M2Share.g_Config.nDecDragonHitPoint / 100));
                                                BaseObject.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_DRINKDECDRAGON, 0, 0, 0, "");// 喝酒抵御合击，显示自身效果
                                            }
                                        }
                                        BaseObject.SendMsg(PlayObject, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                                        if (M2Share.g_Config.btHeroSkillMode_63) // 可以中绿毒
                                        {
                                            nPower = Magic.GetPower13(50, UserMagic) + Magic.GetRPow(PlayObject.m_WAbil.SC) * 2;// 中毒时间
                                            BaseObject.SendDelayMsg(PlayObject, Grobal2.RM_POISON, Grobal2.POISON_DECHEALTH, nPower, Parse(PlayObject),
                                                (int)HUtil32.Round((double)UserMagic->btLevel / 3 * (nPower / M2Share.g_Config.nAmyOunsulPoint)), "", 1000);// 中毒类型 - 绿毒
                                            if ((TargeTBaseObject != null))
                                            {
                                                PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, 0, HUtil32.MakeLong(nTargetX, nTargetY), 3, Parse(TargeTBaseObject), "", 600);
                                            }
                                        }
                                        if (M2Share.g_Config.ErgumBadProtection && (TargeTBaseObject != null))
                                        {
                                            Magic.FinancialsDefence(TargeTBaseObject); // 合击破保护神盾
                                        }
                                        BaseObject.SetLastHiter(PlayObject);
                                        if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) // 修正英雄锁定后,不打锁定怪
                                        {
                                            if (!((THeroObject)(PlayObject)).m_boTarget)
                                            {
                                                PlayObject.SetTargetCreat(BaseObject);
                                            }
                                        }
                                        else
                                        {
                                            PlayObject.SetTargetCreat(BaseObject);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    finally
                    { }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagMakeSkillFire_63");
            }
            return result;
        }

        public unsafe int MagMakeSkillFire_64_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_64_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                 (UserMagic->MagicInfo.btDefPower
                 + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // 末日审判  道+法
        public unsafe bool MagMakeSkillFire_64(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            if (PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject))// 以目标的坐标查找受攻击的范围
            {
                if (PlayObject.m_TargetCret == null)
                {
                    return result;
                }
                BaseObjectList = new List<TBaseObject>();
                try
                {
                    BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, PlayObject.m_TargetCret.m_nCurrX, PlayObject.m_TargetCret.m_nCurrY,
                          M2Share.g_Config.nHeroAttackRange_64);// 攻击范围
                    if (BaseObjectList.Count > 0)
                    {
                        for (int I = 0; I < BaseObjectList.Count; I++)
                        {
                            BaseObject = BaseObjectList[I];
                            nPower = 0;
                            if (BaseObject != null)
                            {
                                if (PlayObject.IsProperTarget(BaseObject))
                                {
                                    if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) // 合击不打自己的英雄
                                    {
                                        if ((((TPlayObject)(PlayObject)).m_MyHero != null) && (BaseObject != null))
                                        {
                                            if (((TPlayObject)(PlayObject)).m_MyHero == BaseObject)
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                    if (BaseObject.m_Master != null)
                                    {
                                        if (BaseObject.m_Master == PlayObject)
                                        {
                                            continue;
                                        }
                                    }
                                    if ((BaseObject.m_nAntiMagic <= HUtil32.Random(10)) && (Math.Abs(BaseObject.m_nCurrX - nTargetX) <= M2Share.g_Config.nHeroAttackRange_64)
                                        && (Math.Abs(BaseObject.m_nCurrY - nTargetY) <= M2Share.g_Config.nHeroAttackRange_64))
                                    {
                                        switch (PlayObject.m_btJob)
                                        {
                                            case 1:
                                                nPower = PlayObject.GetAttackPower(MagMakeSkillFire_64_GetPower(UserMagic, MagMakeSkillFire_64_MPow(UserMagic)) +
                                                    HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1) * 2;
                                                break;
                                            case 2:
                                                nPower = PlayObject.GetAttackPower(MagMakeSkillFire_64_GetPower(UserMagic, MagMakeSkillFire_64_MPow(UserMagic)) +
                                                    HUtil32.LoWord(PlayObject.m_WAbil.SC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1) * 2;
                                                break;
                                        }
                                        nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nHeroAttackRate_64 / 100));// 末日审判威力
                                        if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))  // 目标是人或英雄则判断酒量
                                        {
                                            nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nDecDragonRate / 100));// 合击对人的伤害比例
                                            if (BaseObject.m_Abil.WineDrinkValue > 0) // 酒量不为0时
                                            {
                                                nPower = (int)HUtil32.Round((double)nPower * (1 - M2Share.g_Config.nDecDragonHitPoint / 100));
                                                BaseObject.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_DRINKDECDRAGON, 0, 0, 0, "");// 喝酒抵御合击，显示自身效果
                                            }
                                        }
                                        if ((Math.Abs(BaseObject.m_nCurrX - nTargetX) > 1) && (Math.Abs(BaseObject.m_nCurrY - nTargetY) > 1))
                                        {
                                            nPower = (int)HUtil32.Round(nPower * 0.4);
                                        }
                                        BaseObject.SendMsg(PlayObject, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                                        if (M2Share.g_Config.ErgumBadProtection)
                                        {
                                            Magic.FinancialsDefence(BaseObject); // 合击破保护神盾
                                        }
                                        result = true;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Dispose(BaseObjectList);
                    //BaseObjectList.Free;
                }
            }
            return result;
        }

        // 火龙气焰  法+法
        public bool MagMakeSkillFire_65(TBaseObject BaseObject, int nPower)
        {
            bool result;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            int nPowerValue;
            result = false;
            if (BaseObject.m_TargetCret == null) // 修改以目标的坐标查找受攻击的范围
            {
                return result;
            }
            BaseObjectList = new List<TBaseObject>();
            try
            {
                // 攻击范围
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, BaseObject.m_TargetCret.m_nCurrX, BaseObject.m_TargetCret.m_nCurrY,
                       M2Share.g_Config.nHeroAttackRange_65);// 火龙气焰 攻击范围 
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (BaseObject.IsProperTarget(TargeTBaseObject))
                        {
                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                // 合击不打自己的英雄
                                if ((((TPlayObject)(BaseObject)).m_MyHero != null) && (TargeTBaseObject != null))
                                {
                                    if (((TPlayObject)(BaseObject)).m_MyHero == TargeTBaseObject)
                                    {
                                        continue;
                                    }
                                }
                            }
                            nPowerValue = (int)HUtil32.Round((double)nPower * 2 * (M2Share.g_Config.nHeroAttackRate_65 / 100));// 火龙气焰威力
                            if ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)) // 目标是人或英雄则判断酒量
                            {
                                nPowerValue = (int)HUtil32.Round((double)nPowerValue * (M2Share.g_Config.nDecDragonRate / 100));// 合击对人的伤害比例
                                if (TargeTBaseObject.m_Abil.WineDrinkValue > 0)// 酒量不为0时
                                {
                                    nPowerValue = (int)HUtil32.Round((double)nPowerValue * (1 - M2Share.g_Config.nDecDragonHitPoint / 100));
                                    TargeTBaseObject.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_DRINKDECDRAGON, 0, 0, 0, "");// 喝酒抵御合击，显示自身效果
                                }
                            }
                            TargeTBaseObject.SendMsg(BaseObject, Grobal2.RM_MAGSTRUCK, 0, nPowerValue, 0, 0, "");
                            if (M2Share.g_Config.ErgumBadProtection)
                            {
                                Magic.FinancialsDefence(TargeTBaseObject);// 合击破保护神盾
                            }
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // 是否是战士技能
        public bool IsWarrSkill(int wMagIdx)
        {
            bool result = false;
            if (new ArrayList(new int[] { MagicConst.SKILL_ONESWORD, MagicConst.SKILL_ILKWANG, MagicConst.SKILL_YEDO, MagicConst.SKILL_ERGUM,
                MagicConst.SKILL_BANWOL, MagicConst.SKILL_FIRESWORD, MagicConst.SKILL_MOOTEBO, MagicConst.SKILL_40, MagicConst.SKILL_42, MagicConst.SKILL_43,
                MagicConst.SKILL_74 }).Contains(wMagIdx))
            {
                result = true;
            }
            return result;
        }

        public unsafe int DoSpell_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe ushort DoSpell_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return Convert.ToUInt16(HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                 (UserMagic->MagicInfo.btDefPower +
                 HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
        }

        public unsafe int DoSpell_GetPower13(TUserMagic* UserMagic, int nInt)
        {
            int result;
            double d10;
            double d18;
            d10 = nInt / 3.0;
            d18 = nInt - d10;
            result = (int)HUtil32.Round(d18 / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1) + d10 +
                (UserMagic->MagicInfo.btDefPower +
                HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
            return result;
        }

        public ushort DoSpell_GetRPow(int wInt)
        {
            ushort result = (ushort)wInt;
            if (HUtil32.HiWord(wInt) > HUtil32.LoWord(wInt))
            {
                result = Convert.ToUInt16(HUtil32.Random(Convert.ToInt32((int)HUtil32.HiWord(wInt) - (int)HUtil32.LoWord(wInt) + 1))
                    + HUtil32.LoWord(wInt));
            }
            else
            {
                result = (ushort)HUtil32.LoWord(wInt);
            }
            return result;
        }

        public unsafe void DoSpell_sub_4934B4(TBaseObject PlayObject)
        {
            if (PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura < 100)
            {
                PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura = 0;
                if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    ((TPlayObject)(PlayObject)).SendDelItems(PlayObject.m_UseItems[TPosition.U_ARMRINGL]);
                }
                else if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(PlayObject)).SendDelItems(PlayObject.m_UseItems[TPosition.U_ARMRINGL]);
                }
                PlayObject.m_UseItems[TPosition.U_ARMRINGL]->wIndex = 0;
            }
        }

        /// <summary>
        /// 使用技能
        /// </summary>
        /// <param name="PlayObject">使用对象</param>
        /// <param name="UserMagic">魔法对象</param>
        /// <param name="nTargetX">目标X</param>
        /// <param name="nTargetY">目标Y</param>
        /// <param name="TargeTBaseObject">攻击对象</param>
        /// <returns></returns>
        public unsafe bool DoSpell(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            bool boTrain;
            bool boSpellFail;
            bool boSpellFire;
            ushort nPower = 0;
            int nAmuletIdx = 0;
            int nPowerRate;
            int nDelayTime;
            int nDelayTimeRate;
            try
            {
                if (TargeTBaseObject != null)
                {
                    if ((TargeTBaseObject.m_boGhost) || (TargeTBaseObject.m_boDeath) || (TargeTBaseObject.m_WAbil.HP <= 0))
                    {
                        return result;
                    }
                }
                if (IsWarrSkill(UserMagic->wMagIdx))
                {
                    return result;
                }
                if ((Math.Abs(PlayObject.m_nCurrX - nTargetX) > M2Share.g_Config.nMagicAttackRage) || (Math.Abs(PlayObject.m_nCurrY - nTargetY) > M2Share.g_Config.nMagicAttackRage))
                {
                    return result;
                }
                if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    if (M2Share.g_FunctionNPC != null) // 人物技能触发
                    {
                        M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(PlayObject)), "@MagSelfFunc" + (UserMagic->MagicInfo.wMagicId).ToString(), false);
                    }
                    if ((PlayObject.m_btJob == 0) && (UserMagic->MagicInfo.wMagicId == 61))// 劈星斩战士效果
                    {
                        PlayObject.m_btDirection = M2Share.GetNextDirection(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
                        PlayObject.SendRefMsg(Grobal2.RM_MYSHOW, 5, 0, 0, 0, "");  // 劈星战士自身动画 
                        PlayObject.SendAttackMsg(Grobal2.RM_PIXINGHIT, PlayObject.m_btDirection, PlayObject.m_nCurrX, PlayObject.m_nCurrY);
                    }
                    else if ((PlayObject.m_btJob == 0) && (UserMagic->MagicInfo.wMagicId == 62))   // 雷霆一击战士效果
                    {
                        PlayObject.m_btDirection = M2Share.GetNextDirection(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
                        PlayObject.SendAttackMsg(Grobal2.RM_LEITINGHIT, PlayObject.m_btDirection, PlayObject.m_nCurrX, PlayObject.m_nCurrY);
                    }
                    else
                    {
                        PlayObject.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                    }
                }
                if ((TargeTBaseObject != null) && (UserMagic->MagicInfo.wMagicId != MagicConst.SKILL_57) && (UserMagic->MagicInfo.wMagicId != MagicConst.SKILL_54) &&
                    (UserMagic->MagicInfo.wMagicId < 100))
                {
                    if ((TargeTBaseObject.m_boDeath))
                    {
                        TargeTBaseObject = null;
                    }
                }
                boTrain = false;
                boSpellFail = false;
                boSpellFire = true;
                if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    if ((((TPlayObject)(PlayObject)).m_nSoftVersionDateEx == 0) && (((TPlayObject)(PlayObject)).m_dwClientTick == 0) && (UserMagic->MagicInfo.wMagicId > 40))
                    {
                        return result;
                    }
                }
                switch (UserMagic->MagicInfo.wMagicId)
                {
                    case MagicConst.SKILL_FIREBALL:
                    case MagicConst.SKILL_FIREBALL2:
                        if (MagMakeFireball(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))// 火球术 大火球
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_HEALLING:
                        if (MagTreatment(PlayObject, UserMagic, ref nTargetX, ref nTargetY, ref TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_AMYOUNSUL:
                    case MagicConst.SKILL_93:
                        if (MagLightening(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject, ref boSpellFail))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIREWIND:
                        if (MagPushArround(PlayObject, UserMagic->btLevel) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIRE:
                        if (MagMakeHellFire(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SHOOTLIGHTEN:
                        if (MagMakeQuickLighting(PlayObject, UserMagic, ref nTargetX, ref nTargetY, TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_LIGHTENING:
                    case MagicConst.SKILL_91:
                        if (MagMakeLighting(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
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
                    case MagicConst.SKILL_94:
                    case MagicConst.SKILL_57:
                    case MagicConst.SKILL_59:
                        boSpellFail = true;
                        if (Magic.CheckAmulet(PlayObject, 1, 1, ref nAmuletIdx))
                        {
                            Magic.UseAmulet(PlayObject, 1, 1, ref nAmuletIdx);
                            switch (UserMagic->MagicInfo.wMagicId)
                            {
                                case MagicConst.SKILL_FIRECHARM:
                                    if (MagMakeFireCharm(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_HANGMAJINBUB:
                                    nPower = (ushort)PlayObject.GetAttackPower(DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(PlayObject.m_WAbil.SC) * 10,
                                        ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                                    if (PlayObject.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 1) > 0)
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_DEJIWONHO:
                                    nPower = (ushort)PlayObject.GetAttackPower(DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(PlayObject.m_WAbil.SC) * 10,
                                        ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                                    if (PlayObject.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 0) > 0)
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_HOLYSHIELD:
                                    if (MagMakeHolyCurtain(PlayObject, DoSpell_GetPower13(UserMagic, 40) + DoSpell_GetRPow(PlayObject.m_WAbil.SC) * 3, nTargetX, nTargetY) > 0)
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_SKELLETON:
                                    if (MagMakeSlave(PlayObject, UserMagic))
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_CLOAK:
                                    if (MagMakePrivateTransparent(PlayObject, DoSpell_GetPower13(UserMagic, 30) + DoSpell_GetRPow(PlayObject.m_WAbil.SC) * 3))
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_BIGCLOAK:
                                    if (MagMakeGroupTransparent(PlayObject, nTargetX, nTargetY, DoSpell_GetPower13(UserMagic, 30) +
                                        DoSpell_GetRPow(PlayObject.m_WAbil.SC) * 3))
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_52:
                                    nPower = (ushort)PlayObject.GetAttackPower(DoSpell_GetPower13(UserMagic, 20) + HUtil32.LoWord(PlayObject.m_WAbil.SC) * 2,
                                        ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                                    if (PlayObject.MagMakeAbilityArea(nTargetX, nTargetY, 3, nPower) > 0)
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_57:
                                    if (MagMakeLivePlayObject(PlayObject, UserMagic, TargeTBaseObject))
                                    {
                                        boTrain = true;
                                    }
                                    break;
                                case MagicConst.SKILL_59:
                                case MagicConst.SKILL_94:
                                    if (MagFireCharmTreatment(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                                    {
                                        boTrain = true;
                                    }
                                    break;
                            }
                            boSpellFail = false;
                            DoSpell_sub_4934B4(PlayObject);
                        }
                        break;
                    case MagicConst.SKILL_TAMMING:
                        if (PlayObject.IsProperTarget(TargeTBaseObject))
                        {
                            if (MagTamming(PlayObject, TargeTBaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_SPACEMOVE:
                        PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect),
                            HUtil32.MakeLong(nTargetX, nTargetY), Parse(TargeTBaseObject), "");
                        boSpellFire = false;
                        if (MagSaceMove(PlayObject, UserMagic->btLevel))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_EARTHFIRE:
                        nPower = (ushort)PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.MC),
                            ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                        nDelayTime = DoSpell_GetPower(UserMagic, 10) + (((ushort)DoSpell_GetRPow(PlayObject.m_WAbil.MC)) >> 1);//火墙威力和时间的倍数
                        nPowerRate = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nFirePowerRate / 100));
                        nDelayTimeRate = (int)HUtil32.Round((double)nDelayTime * (M2Share.g_Config.nFireDelayTimeRate / 100));
                        if (MagMakeFireCross(PlayObject, nPowerRate, nDelayTimeRate, nTargetX, nTargetY) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIREBOOM:
                        if (MagBigExplosion(PlayObject, PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) +
                            HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1),
                            nTargetX, nTargetY, M2Share.g_Config.nFireBoomRage, MagicConst.SKILL_FIREBOOM))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_LIGHTFLOWER:
                        if (MagElecBlizzard(PlayObject, PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic))
                            + HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SHOWHP:
                        if ((TargeTBaseObject != null) && !TargeTBaseObject.m_boShowHP)
                        {
                            if (HUtil32.Random(6) <= (UserMagic->btLevel + 3))
                            {
                                TargeTBaseObject.m_dwShowHPTick = HUtil32.GetTickCount();
                                TargeTBaseObject.m_dwShowHPInterval = (uint)DoSpell_GetPower13(UserMagic, DoSpell_GetRPow(PlayObject.m_WAbil.SC) * 2 + 30) * 1000;
                                TargeTBaseObject.SendDelayMsg(TargeTBaseObject, Grobal2.RM_DOOPENHEALTH, 0, 0, 0, 0, "", 1500);
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_BIGHEALLING:
                        nPower = (ushort)PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) +
                            HUtil32.LoWord(PlayObject.m_WAbil.SC) * 2, ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) -
                            HUtil32.LoWord(PlayObject.m_WAbil.SC)) * 2 + 1);
                        if (MagBigHealing(PlayObject, nPower + PlayObject.m_WAbil.Level, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SINSU:
                        boSpellFail = true;
                        if (Magic.CheckAmulet(PlayObject, 5, 1, ref nAmuletIdx))
                        {
                            Magic.UseAmulet(PlayObject, 5, 1, ref nAmuletIdx);
                            if (MagMakeSinSuSlave(PlayObject, UserMagic))
                            {
                                boTrain = true;
                            }
                            boSpellFail = false;
                        }
                        break;
                    case MagicConst.SKILL_SACRED:
                        boSpellFail = true;
                        if (Magic.CheckAmulet(PlayObject, 5, 1, ref nAmuletIdx))
                        {
                            Magic.UseAmulet(PlayObject, 5, 1, ref nAmuletIdx);
                            if (MagMakeSacredSlave(PlayObject, UserMagic))
                            {
                                boTrain = true;
                            }
                            boSpellFire = false;
                        }
                        break;
                    case MagicConst.SKILL_SHIELD:
                    case MagicConst.SKILL_66:
                        if (PlayObject.MagBubbleDefenceUp(UserMagic->btLevel, DoSpell_GetPower(UserMagic, DoSpell_GetRPow(PlayObject.m_WAbil.MC) + 15)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_73:
                        if (PlayObject.MagBubbleDefenceUp(UserMagic->btLevel, DoSpell_GetPower(UserMagic, DoSpell_GetRPow(PlayObject.m_WAbil.SC) + 15)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_75:
                        if ((HUtil32.GetTickCount() - PlayObject.m_boProtectionTick > M2Share.g_Config.dwProtectionTick))
                        {
                            if (PlayObject.MagProtectionDefenceUp(UserMagic->btLevel))
                            {
                                boTrain = true;// '护体神盾生效'
                                PlayObject.SysMsg(GameMsgDef.g_sOpenShieldMsg, TMsgColor.c_Blue, TMsgType.t_Hint);// 提示用户;
                            }
                        }
                        else
                        {
                            PlayObject.SysMsg(string.Format(GameMsgDef.g_sOpenShieldTickMsg,
                                (M2Share.g_Config.dwProtectionTick - (HUtil32.GetTickCount() - PlayObject.m_boProtectionTick)) / 1000), TMsgColor.c_Red, TMsgType.t_Hint);
                            return result;
                        }
                        break;
                    case MagicConst.SKILL_KILLUNDEAD:
                        if (PlayObject.IsProperTarget(TargeTBaseObject))
                        {
                            if (MagTurnUndead(PlayObject, TargeTBaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_SNOWWIND:
                        if (MagBigExplosion(PlayObject, PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic))
                            + HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1),
                            nTargetX, nTargetY, M2Share.g_Config.nSnowWindRange, MagicConst.SKILL_SNOWWIND))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_UNAMYOUNSUL:
                        if (MagMakeUnTreatment(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_WINDTEBO:
                        if (MagWindTebo(PlayObject, UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_MABE:
                        nPower = (ushort)PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.MC),
                            ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                        if (MabMabe(PlayObject, TargeTBaseObject, nPower, UserMagic->btLevel, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPLIGHTENING:
                        if (MagGroupLightening(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject, ref boSpellFire))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPAMYOUNSUL:
                        if (MagGroupAmyounsul(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPDEDING:
                        if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            if (HUtil32.GetTickCount() - ((TPlayObject)(PlayObject)).m_dwDedingUseTick > M2Share.g_Config.nDedingUseTime * 1000)
                            {
                                ((TPlayObject)(PlayObject)).m_dwDedingUseTick = HUtil32.GetTickCount();
                                if (MagGroupDeDing(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                                {
                                    boTrain = true;
                                }
                            }
                        }
                        else
                        {
                            if ((TargeTBaseObject != null) && MagGroupDeDing(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_41:
                        if (MagGroupMb(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_42:
                        if (MagHbFireBall(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_43:
                        if (MagHbFireBall(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_44:
                        if (MagHbFireBall(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_45:
                        if (MagMakeFireDay(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_46:
                        if (MagMakeSelf(PlayObject, TargeTBaseObject, UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_47:
                        if (MagBigExplosion(PlayObject, PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic))
                            + HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) -
                            HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1), nTargetX, nTargetY, M2Share.g_Config.nFireBoomRage, MagicConst.SKILL_47))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_58:
                    case MagicConst.SKILL_92:
                        if (MagBigExplosion1(PlayObject, PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) +
                            HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1)
                            , nTargetX, nTargetY, M2Share.g_Config.nMeteorFireRainRage))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_48:
                        if (MagPushArround(PlayObject, UserMagic->btLevel) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_49:
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_50:
                        if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            if (((TPlayObject)(PlayObject)).AbilityUp(UserMagic))
                            {
                                boTrain = true;
                            }
                        }
                        else if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            if (((THeroObject)(PlayObject)).AbilityUp(UserMagic))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_51:
                        if (MagGroupFengPo(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_53:
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_54:
                        if (PlayObject.IsProperTargetSKILL_54(TargeTBaseObject))
                        {
                            if (MagTamming2(PlayObject, TargeTBaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_55:
                        if (MagMakeArrestObject(PlayObject, UserMagic, TargeTBaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_56:
                        if ((HUtil32.GetTickCount() - PlayObject.m_boMagChangXYTick > M2Share.g_Config.dwMagChangXYTick))
                        {
                            // 移行换位使用间隔
                            if (MagChangePosition(PlayObject, nTargetX, nTargetY))
                            {
                                PlayObject.m_boMagChangXYTick = HUtil32.GetTickCount();
                                boTrain = true;
                            }
                        }
                        else
                        {
                            PlayObject.SysMsg(string.Format(GameMsgDef.g_sOpenShieldTickMsg,
                                (M2Share.g_Config.dwMagChangXYTick - (HUtil32.GetTickCount() - PlayObject.m_boMagChangXYTick)) / 1000), TMsgColor.c_Red, TMsgType.t_Hint);
                            return result;
                        }
                        break;
                    case MagicConst.SKILL_68:
                        MagMakeHPUp(PlayObject, UserMagic);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_72:
                        if (Magic.CheckAmulet(PlayObject, 5, 1, ref nAmuletIdx))
                        {
                            Magic.UseAmulet(PlayObject, 5, 1, ref nAmuletIdx);
                            if (MagMakeFairy(PlayObject, UserMagic))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_60:
                        MagMakeSkillFire_60(PlayObject, UserMagic, PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic))
                            + HUtil32.LoWord(PlayObject.m_WAbil.DC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.DC) - HUtil32.LoWord(PlayObject.m_WAbil.DC)) + 1) * 3);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_61:
                        MagMakeSkillFire_61(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_62:
                        MagMakeSkillFire_62(PlayObject, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_63:
                        MagMakeSkillFire_63(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_64:
                        MagMakeSkillFire_64(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_65:
                        MagMakeSkillFire_65(PlayObject, PlayObject.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) +
                            HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1));
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_77:
                        MagMakeSkillFire_77(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_78:
                        MagMakeSkillFire_78(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_80:
                        MagMakeSkillFire_80(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_81:
                        MagMakeSkillFire_81(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_83:
                        MagMakeSkillFire_83(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_84:
                        MagMakeSkillFire_84(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_86:
                        MagMakeSkillFire_86(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_87:
                        MagMakeSkillFire_87(PlayObject, UserMagic, nTargetX, nTargetY, TargeTBaseObject);
                        boTrain = true;
                        break;
                }
                if (boSpellFail)
                {
                    return result;
                }
                if (boSpellFire)
                {
                    // 除4级少技能不发消息
                    if ((PlayObject.m_boUseBatter) && (HUtil32.Random(100) < GetStormsHitRate(PlayObject, UserMagic->MagicInfo.wMagicId)))
                    {
                        PlayObject.SysMsg(string.Format(M2Share.StrStorm, GetNameByMagicID(UserMagic->MagicInfo.wMagicId)), TMsgColor.c_Green, TMsgType.t_Hint);
                        PlayObject.SendRefMsg(Grobal2.RM_STORMSRATE, 0, 0, 0, 0, "");
                    }
                    // 暴击
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        try
                        {
                            switch (UserMagic->MagicInfo.wMagicId)// 除4级少技能不发消息
                            {
                                case 13:
                                    if ((UserMagic->btLevel == 4))  // 4级火符
                                    {
                                        PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, 100),
                                            HUtil32.MakeLong(nTargetX, nTargetY), Parse(TargeTBaseObject), "");
                                    }
                                    else
                                    {
                                        PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect),
                                            HUtil32.MakeLong(nTargetX, nTargetY), Parse(TargeTBaseObject), "");
                                    }
                                    break;
                                case 26:
                                    break;
                                case 45:
                                    if ((UserMagic->btLevel == 4))
                                    {
                                        PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, 101), HUtil32.MakeLong(nTargetX, nTargetY),
                                            Parse(TargeTBaseObject), "");
                                    }
                                    else
                                    {
                                        PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY),
                                            Parse(TargeTBaseObject), "");
                                    }
                                    break;
                                default:
                                    // 0..12,14..25,27..44,46..100:
                                    PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect),
                                        HUtil32.MakeLong(nTargetX, nTargetY), Parse(TargeTBaseObject), "");
                                    break;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                if ((UserMagic->btLevel < 3) && boTrain)
                {
                    if (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] <= PlayObject.m_Abil.Level)
                    {
                        PlayObject.TrainSkill(UserMagic, HUtil32.Random(3) + 1);// /增加技能的修练值
                        if (!PlayObject.CheckMagicLevelup(UserMagic))
                        {
                            if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_MAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 1000);
                            }
                            else if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                ((THeroObject)(PlayObject)).SendDelayMsg(PlayObject, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 1000);
                            }
                        }
                    }
                }
                result = true;
            }
            catch
            {

                M2Share.MainOutMessage(string.Format("{异常} TMagicManager.DoSpell MagID:{0} X:{1} Y:{2}", UserMagic->wMagIdx, nTargetX, nTargetY));
            }
            return result;
        }

        /// <summary>
        /// 隐身术
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nHTime"></param>
        /// <returns></returns>
        public bool MagMakePrivateTransparent(TBaseObject BaseObject, int nHTime)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            if (BaseObject.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] > 0)
            {
                return result;
            }
            BaseObjectList = new List<TBaseObject>();
            try
            {
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, BaseObject.m_nCurrX, BaseObject.m_nCurrY, 9);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if ((TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL) && (TargeTBaseObject.m_TargetCret == BaseObject))
                        {
                            if ((Math.Abs(TargeTBaseObject.m_nCurrX - BaseObject.m_nCurrX) > 1) || (Math.Abs(TargeTBaseObject.m_nCurrY - BaseObject.m_nCurrY) > 1) || (HUtil32.Random(2) == 0))
                            {
                                TargeTBaseObject.m_TargetCret = null;
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            BaseObject.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = (ushort)nHTime;
            BaseObject.m_nCharStatus = BaseObject.GetCharStatus();
            BaseObject.StatusChanged("");
            BaseObject.m_boHideMode = true;
            BaseObject.m_boTransparent = true;
            result = true;
            return result;
        }

        public bool MagTamming2(TBaseObject BaseObject, TBaseObject TargeTBaseObject, int nTargetX, int nTargetY, int nMagicLevel)
        {
            bool result = false;
            if ((TargeTBaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && ((HUtil32.Random(4 - nMagicLevel) == 0)))
            {
                TargeTBaseObject.m_TargetCret = null;
                if (HUtil32.Random(2) == 0)
                {
                    if (TargeTBaseObject.m_Abil.Level <= BaseObject.m_Abil.Level + 2)
                    {
                        if (HUtil32.Random(3) == 0)
                        {
                            if (HUtil32.Random((BaseObject.m_Abil.Level + 20) + (nMagicLevel * 5)) > (TargeTBaseObject.m_Abil.Level + M2Share.g_Config.nMagTammingTargetLevel))
                            {
                                if (!(TargeTBaseObject.bo2C1) && (TargeTBaseObject.m_btLifeAttrib == 0) && (TargeTBaseObject.m_Abil.Level < M2Share.g_Config.nMagTammingLevel) &&
                                    (BaseObject.m_SlaveList.Count < M2Share.g_Config.nMagTammingCount))
                                {
                                    TargeTBaseObject.m_Master = BaseObject;
                                    TargeTBaseObject.m_dwMasterRoyaltyTick = ((uint)(HUtil32.Random(BaseObject.m_Abil.Level * 2) + (nMagicLevel << 2) * 5 + 20) * 60000);// 60 * 1000
                                    TargeTBaseObject.m_dwMasterRoyaltyTime = HUtil32.GetTickCount();
                                    TargeTBaseObject.m_btSlaveMakeLevel = (byte)nMagicLevel;
                                    if (TargeTBaseObject.m_dwMasterTick == 0)
                                    {
                                        TargeTBaseObject.m_dwMasterTick = HUtil32.GetTickCount();
                                    }
                                    TargeTBaseObject.BreakHolySeizeMode();
                                    if (((uint)1500 - nMagicLevel * 200) < ((uint)TargeTBaseObject.m_nWalkSpeed))
                                    {
                                        TargeTBaseObject.m_nWalkSpeed = 1500 - nMagicLevel * 200;
                                    }
                                    if (((uint)2000 - nMagicLevel * 200) < ((uint)TargeTBaseObject.m_nNextHitTime))
                                    {
                                        TargeTBaseObject.m_nNextHitTime = Convert.ToUInt32(2000 - nMagicLevel * 200);
                                    }
                                    TargeTBaseObject.ReAlive();
                                    TargeTBaseObject.m_WAbil.HP = TargeTBaseObject.m_WAbil.MaxHP;
                                    TargeTBaseObject.SendMsg(TargeTBaseObject, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                                    TargeTBaseObject.RefShowName();
                                    BaseObject.m_SlaveList.Add(TargeTBaseObject);
                                }
                            }
                        }
                        else
                        {
                            if (!(TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD) && (HUtil32.Random(20) == 0))
                            {
                                TargeTBaseObject.OpenCrazyMode(HUtil32.Random(20) + 10);
                            }
                        }
                    }
                    else
                    {
                        if (!(TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD))
                        {
                            TargeTBaseObject.OpenCrazyMode(HUtil32.Random(20) + 10); // 变红
                        }
                    }
                }
            }
            result = true;
            return result;
        }

        public bool MagTamming(TBaseObject BaseObject, TBaseObject TargeTBaseObject, int nTargetX, int nTargetY, int nMagicLevel)
        {
            bool result = false;
            int n14;
            if ((TargeTBaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && ((HUtil32.Random(4 - nMagicLevel) == 0)))
            {
                TargeTBaseObject.m_TargetCret = null;
                if (TargeTBaseObject.m_Master == BaseObject)
                {
                    TargeTBaseObject.OpenHolySeizeMode(Convert.ToUInt32((nMagicLevel * 5 + 10) * 1000));
                    result = true;
                }
                else
                {
                    if (HUtil32.Random(2) == 0)
                    {
                        if (TargeTBaseObject.m_Abil.Level <= BaseObject.m_Abil.Level + 2)
                        {
                            if (HUtil32.Random(3) == 0)
                            {
                                if (HUtil32.Random((BaseObject.m_Abil.Level + 20) + (nMagicLevel * 5)) > (TargeTBaseObject.m_Abil.Level + M2Share.g_Config.nMagTammingTargetLevel))
                                {
                                    // 解决诱惑之光可以召唤英雄的BUG
                                    if (!(TargeTBaseObject.bo2C1) && (TargeTBaseObject.m_btLifeAttrib == 0) && (TargeTBaseObject.m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                        && (TargeTBaseObject.m_Abil.Level < M2Share.g_Config.nMagTammingLevel) && (BaseObject.m_SlaveList.Count < M2Share.g_Config.nMagTammingCount))
                                    {
                                        n14 = TargeTBaseObject.m_WAbil.MaxHP / M2Share.g_Config.nMagTammingHPRate;
                                        if (n14 <= 2)
                                        {
                                            n14 = 2;
                                        }
                                        else
                                        {
                                            n14 += n14;
                                        }
                                        if ((TargeTBaseObject.m_Master != BaseObject) && (HUtil32.Random(n14) == 0))
                                        {
                                            TargeTBaseObject.BreakCrazyMode();
                                            if (TargeTBaseObject.m_Master != null)
                                            {
                                                TargeTBaseObject.m_WAbil.HP = TargeTBaseObject.m_WAbil.HP / 10;
                                            }
                                            TargeTBaseObject.m_Master = BaseObject;
                                            TargeTBaseObject.m_dwMasterRoyaltyTick = (uint)(HUtil32.Random(BaseObject.m_Abil.Level * 2) + (nMagicLevel << 2) * 5 + 20) * 60000; // 60 * 1000
                                            TargeTBaseObject.m_dwMasterRoyaltyTime = HUtil32.GetTickCount();
                                            TargeTBaseObject.m_btSlaveMakeLevel = (byte)nMagicLevel;
                                            if (TargeTBaseObject.m_dwMasterTick == 0)
                                            {
                                                TargeTBaseObject.m_dwMasterTick = HUtil32.GetTickCount();
                                            }
                                            TargeTBaseObject.BreakHolySeizeMode();
                                            if ((1500 - nMagicLevel * 200) < (TargeTBaseObject.m_nWalkSpeed))
                                            {
                                                TargeTBaseObject.m_nWalkSpeed = 1500 - nMagicLevel * 200;
                                            }
                                            if ((2000 - nMagicLevel * 200) < (TargeTBaseObject.m_nNextHitTime))
                                            {
                                                TargeTBaseObject.m_nNextHitTime = Convert.ToUInt32(2000 - nMagicLevel * 200);
                                            }
                                            TargeTBaseObject.RefShowName();
                                            BaseObject.m_SlaveList.Add(TargeTBaseObject);
                                        }
                                        else
                                        {
                                            if (HUtil32.Random(14) == 0)
                                            {
                                                TargeTBaseObject.m_WAbil.HP = 0;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD) && (HUtil32.Random(20) == 0))
                                        {
                                            TargeTBaseObject.m_WAbil.HP = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    if (!(TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD) && (HUtil32.Random(20) == 0))
                                    {
                                        TargeTBaseObject.OpenCrazyMode(HUtil32.Random(20) + 10);
                                    }
                                }
                            }
                            else
                            {
                                if (!(TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD))
                                {
                                    TargeTBaseObject.OpenCrazyMode(HUtil32.Random(20) + 10);// 变红
                                }
                            }
                        }
                    }
                    else
                    {
                        TargeTBaseObject.OpenHolySeizeMode(Convert.ToUInt32((nMagicLevel * 5 + 10) * 1000));
                    }
                    result = true;
                }
            }
            else
            {
                if (HUtil32.Random(2) == 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool MagTurnUndead(TBaseObject BaseObject, TBaseObject TargeTBaseObject, int nTargetX, int nTargetY, int nLevel)
        {
            bool result;
            int n14;
            result = false;
            if (TargeTBaseObject.m_boSuperMan || !(TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD))
            {
                return result;
            }
            ((TAnimalObject)(TargeTBaseObject)).Struck(BaseObject);
            if (TargeTBaseObject.m_TargetCret == null)
            {
                ((TAnimalObject)(TargeTBaseObject)).m_boRunAwayMode = true;
                ((TAnimalObject)(TargeTBaseObject)).m_dwRunAwayStart = HUtil32.GetTickCount();
                ((TAnimalObject)(TargeTBaseObject)).m_dwRunAwayTime = 10000;// 10 * 1000
            }
            if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                // 修正英雄锁定后,不打锁定怪
                if (!((THeroObject)(BaseObject)).m_boTarget)
                {
                    BaseObject.SetTargetCreat(TargeTBaseObject);
                }
            }
            else
            {
                BaseObject.SetTargetCreat(TargeTBaseObject);
            }
            if ((HUtil32.Random(2) + (BaseObject.m_Abil.Level - 1)) > TargeTBaseObject.m_Abil.Level)
            {
                if (TargeTBaseObject.m_Abil.Level < M2Share.g_Config.nMagTurnUndeadLevel)
                {
                    n14 = BaseObject.m_Abil.Level - TargeTBaseObject.m_Abil.Level;
                    if (HUtil32.Random(100) < ((nLevel << 3) - nLevel + 15 + n14))
                    {
                        TargeTBaseObject.SetLastHiter(BaseObject);
                        TargeTBaseObject.m_WAbil.HP = 0;
                        result = true;
                    }
                }
            }
            return result;
        }

        public unsafe bool MagWindTebo(TBaseObject PlayObject, TUserMagic* UserMagic)
        {
            bool result;
            TBaseObject PoseBaseObject;
            result = false;
            PoseBaseObject = PlayObject.GetPoseCreate();
            if ((PoseBaseObject != null) && (PoseBaseObject != PlayObject) && (!PoseBaseObject.m_boDeath) && (!PoseBaseObject.m_boGhost) && (PlayObject.IsProperTarget(PoseBaseObject))
                && (!PoseBaseObject.m_boStickMode))
            {
                if ((Math.Abs(PlayObject.m_nCurrX - PoseBaseObject.m_nCurrX) <= 1) && (Math.Abs(PlayObject.m_nCurrY - PoseBaseObject.m_nCurrY) <= 1)
                    && (PlayObject.m_Abil.Level > PoseBaseObject.m_Abil.Level))
                {
                    if (HUtil32.Random(20) < UserMagic->btLevel * 6 + 6 + (PlayObject.m_Abil.Level - PoseBaseObject.m_Abil.Level))
                    {
                        PoseBaseObject.CharPushed(M2Share.GetNextDirection(PlayObject.m_nCurrX, PlayObject.m_nCurrY, PoseBaseObject.m_nCurrX, PoseBaseObject.m_nCurrY),
                            HUtil32._MAX(0, UserMagic->btLevel - 1) + 1);
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool MagSaceMove(TBaseObject BaseObject, int nLevel)
        {
            bool result;
            TEnvirnoment Envir;
            TPlayObject PlayObject;
            result = false;
            if (HUtil32.Random(11) < nLevel * 2 + 4)
            {
                BaseObject.SendRefMsg(Grobal2.RM_SPACEMOVE_FIRE2, 0, 0, 0, 0, "");
                if (BaseObject is TPlayObject)
                {
                    Envir = BaseObject.m_PEnvir;
                    BaseObject.MapRandomMove(BaseObject.m_sHomeMap, 1);
                    if ((Envir != BaseObject.m_PEnvir) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        PlayObject = ((TPlayObject)(BaseObject));
                        PlayObject.m_boTimeRecall = false;
                    }
                }
                result = true;
            }
            return result;
        }

        public unsafe bool MagGroupFengPo(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            int I;
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            int nPower = 0;
            result = false;
            BaseObjectList = new List<TBaseObject>();
            BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, nTargetX, nTargetY, HUtil32._MAX(1, UserMagic->btLevel));
            if (BaseObjectList.Count > 0)
            {
                for (I = 0; I < BaseObjectList.Count; I++)
                {
                    BaseObject = BaseObjectList[I];
                    if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (PlayObject == BaseObject))
                    {
                        continue;
                    }
                    if (PlayObject.IsProperTarget(BaseObject))
                    {
                        nPower = PlayObject.GetAttackPower(HUtil32.LoWord(PlayObject.m_WAbil.SC), ((short)(HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC))));
                        if (nPower > 0)
                        {
                            nPower = BaseObject.GetHitStruckDamage(PlayObject, nPower);
                        }
                        if (nPower > 0)
                        {
                            BaseObject.StruckDamage(nPower);
                            PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(BaseObject.m_nCurrX, BaseObject.m_nCurrY), 1, Parse(BaseObject), "", 200);
                        }
                        if (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                        {
                            result = true;
                        }
                    }
                }
            }
            Dispose(BaseObjectList);
            return result;
        }

        // 群体施毒术
        public unsafe bool MagGroupAmyounsul(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            int I;
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            int nPower;
            TStdItem* StdItem;
            int nAmuletIdx = 0;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                BaseObjectList = new List<TBaseObject>();
                try
                {
                    nCode = 1;
                    BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, nTargetX, nTargetY, HUtil32._MAX(1, UserMagic->btLevel));
                    nCode = 2;
                    if (BaseObjectList.Count > 0)
                    {
                        for (I = 0; I < BaseObjectList.Count; I++)
                        {
                            nCode = 3;
                            BaseObject = BaseObjectList[I];
                            nCode = 4;
                            if (BaseObject != null)
                            {
                                if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (PlayObject == BaseObject) || (BaseObject.m_btRaceServer == 128)) // 火龙魔兽不能毒
                                {
                                    continue;
                                }
                                nCode = 5;
                                if (PlayObject.IsProperTarget(BaseObject))
                                {
                                    nCode = 6;
                                    if (Magic.CheckAmulet(PlayObject, 1, 2, ref nAmuletIdx))
                                    {
                                        nCode = 7;
                                        StdItem = null;
                                        if ((nAmuletIdx == TPosition.U_ARMRINGL) || (nAmuletIdx == TPosition.U_BUJUK))
                                        {
                                            nCode = 8;
                                            if (PlayObject.m_UseItems[nAmuletIdx]->wIndex > 0)
                                            {
                                                StdItem = UserEngine.GetStdItem(PlayObject.m_UseItems[nAmuletIdx]->wIndex);
                                            }
                                            nCode = 9;
                                        }
                                        nCode = 20;
                                        if ((StdItem == null) || ((StdItem != null) && (StdItem->StdMode != 25)))
                                        {
                                            StdItem = UserEngine.GetStdItem(nAmuletIdx); // 如果装备上里没有物品,则从包裹里找
                                        }
                                        nCode = 10;
                                        if (StdItem != null)
                                        {
                                            Magic.UseAmulet(PlayObject, 1, 2, ref nAmuletIdx);
                                            nCode = 11;
                                            if (HUtil32.Random(BaseObject.m_btAntiPoison + 7) <= 6)
                                            {
                                                switch (StdItem->Shape)
                                                {
                                                    case 1:
                                                        nCode = 12;
                                                        nPower = Magic.GetPower13(40, UserMagic) + Magic.GetRPow(PlayObject.m_WAbil.SC) * 2;
                                                        nCode = 13;// 中毒类型 - 绿毒
                                                        BaseObject.SendDelayMsg(PlayObject, Grobal2.RM_POISON, Grobal2.POISON_DECHEALTH, nPower, Parse(PlayObject),
                                                            (int)HUtil32.Round((double)UserMagic->btLevel / 3 * (nPower / M2Share.g_Config.nAmyOunsulPoint)), "", 200);
                                                        break;
                                                    case 2:
                                                        nCode = 14;
                                                        nPower = Magic.GetPower13(30, UserMagic) + Magic.GetRPow(PlayObject.m_WAbil.SC) * 2;
                                                        nCode = 15;// 中毒类型 - 红毒
                                                        BaseObject.SendDelayMsg(PlayObject, Grobal2.RM_POISON, Grobal2.POISON_DAMAGEARMOR, nPower, Parse(PlayObject),
                                                            (int)HUtil32.Round((double)UserMagic->btLevel / 3 * (nPower / M2Share.g_Config.nAmyOunsulPoint)), "", 200);
                                                        break;
                                                }
                                                nCode = 16;
                                                if (BaseObject != null)
                                                {
                                                    if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                                                    {
                                                        result = true;
                                                    }
                                                    nCode = 17;
                                                    if (PlayObject != null)
                                                    {
                                                        BaseObject.SetLastHiter(PlayObject);
                                                        nCode = 18;
                                                        if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) // 修正英雄锁定后,不打锁定怪
                                                        {
                                                            nCode = 19;
                                                            if (!((THeroObject)(PlayObject)).m_boTarget)
                                                            {
                                                                PlayObject.SetTargetCreat(BaseObject);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            PlayObject.SetTargetCreat(BaseObject);
                                                        }
                                                        nCode = 20;
                                                        if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)// 修正毒英雄,英雄不攻击
                                                        {
                                                            nCode = 21;
                                                            if (!((THeroObject)(BaseObject)).m_boTarget)
                                                            {
                                                                BaseObject.SetTargetCreat(PlayObject);
                                                            }
                                                        }
                                                    }
                                                }
                                                nCode = 22;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Dispose(BaseObjectList);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagGroupAmyounsul Code:" + nCode);
            }
            return result;
        }

        public unsafe bool MagGroupDeDing(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            int nPower = 0;
            result = false;
            BaseObjectList = new List<TBaseObject>();
            BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, nTargetX, nTargetY, HUtil32._MAX(1, UserMagic->btLevel));
            if (BaseObjectList.Count > 0)
            {
                for (int I = 0; I < BaseObjectList.Count; I++)
                {
                    BaseObject = ((TBaseObject)(BaseObjectList[I]));
                    if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (PlayObject == BaseObject))
                    {
                        continue;
                    }
                    if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && !M2Share.g_Config.boDedingAllowPK)
                    {
                        continue;
                    }
                    if (PlayObject.IsProperTarget(BaseObject))
                    {
                        nPower = PlayObject.GetAttackPower(HUtil32.LoWord(PlayObject.m_WAbil.DC), ((short)(HUtil32.HiWord(PlayObject.m_WAbil.DC) - HUtil32.LoWord(PlayObject.m_WAbil.DC))));
                        if ((HUtil32.Random(BaseObject.m_btSpeedPoint) >= PlayObject.m_btHitPoint))
                        {
                            nPower = 0;
                        }
                        if (nPower > 0)
                        {
                            nPower = BaseObject.GetHitStruckDamage(PlayObject, nPower);
                        }
                        nPower = (int)HUtil32.Round((double)nPower * (M2Share.g_Config.nDidingPowerRate / 100));
                        if (nPower > 0)
                        {
                            BaseObject.StruckDamage(nPower);
                            PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(BaseObject.m_nCurrX, BaseObject.m_nCurrY), 1, Parse(BaseObject), "", 200);
                        }
                        if (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                        {
                            result = true;
                        }
                    }
                    PlayObject.SendRefMsg(Grobal2.RM_10205, 0, BaseObject.m_nCurrX, BaseObject.m_nCurrY, 1, "");
                }
            }
            Dispose(BaseObjectList);
            return result;
        }

        // 群体雷电术
        public unsafe bool MagGroupLightening(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject, ref bool boSpellFire)
        {
            bool result;
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            int nPower = 0;
            result = false;
            boSpellFire = false;
            BaseObjectList = new List<TBaseObject>();
            BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, nTargetX, nTargetY, HUtil32._MAX(1, UserMagic->btLevel));
            PlayObject.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, HUtil32.MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect),
                HUtil32.MakeLong(nTargetX, nTargetY), Parse(TargeTBaseObject), "");
            if (BaseObjectList.Count > 0)
            {
                for (int I = 0; I < BaseObjectList.Count; I++)
                {
                    BaseObject = BaseObjectList[I];
                    if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (PlayObject == BaseObject))
                    {
                        continue;
                    }
                    if (PlayObject.IsProperTarget(BaseObject))
                    {
                        if ((HUtil32.Random(10) >= BaseObject.m_nAntiMagic))
                        {
                            nPower = PlayObject.GetAttackPower(Magic.GetPower(Magic.MPow(UserMagic), UserMagic) + HUtil32.LoWord(PlayObject.m_WAbil.MC),
                                ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                            if (BaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                            {
                                nPower = (int)HUtil32.Round(nPower * 1.5);
                            }
                            PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(BaseObject.m_nCurrX, BaseObject.m_nCurrY), 2, Parse(BaseObject), "", 600);
                            if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                result = true;
                            }
                            else if (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                            {
                                result = true;
                            }
                        }
                        if ((BaseObject.m_nCurrX != nTargetX) || (BaseObject.m_nCurrY != nTargetY))
                        {
                            PlayObject.SendRefMsg(Grobal2.RM_10205, 0, BaseObject.m_nCurrX, BaseObject.m_nCurrY, 4, "");
                        }
                    }
                }
            }
            Dispose(BaseObjectList);
            return result;
        }

        public unsafe int MagLightening_GetPower13(TUserMagic* UserMagic, int nInt)
        {
            int result;
            double d10;
            double d18;
            d10 = nInt / 3.0;
            d18 = nInt - d10;
            result = (int)HUtil32.Round(d18 / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1) + d10 + (UserMagic->MagicInfo.btDefPower +
                (UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
            return result;
        }

        public ushort MagLightening_GetRPow(int wInt)
        {
            ushort result = (ushort)wInt;
            if (HUtil32.HiWord(wInt) > HUtil32.LoWord(wInt))
            {
                result = Convert.ToUInt16(HUtil32.HiWord(wInt) - HUtil32.LoWord(wInt) + 1 + HUtil32.LoWord(wInt));
            }
            else
            {
                result = (ushort)HUtil32.LoWord(wInt);
            }
            return result;
        }

        // 施毒术  如果没有目标,则 boSpellFire:=False,则不放出毒效果
        // 0级--11秒 1级--14秒 2级--17秒 3级--20秒
        // 时间=11+3*技能等级
        public unsafe bool MagLightening(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject, ref bool boSpellFire)
        {
            bool result;
            int nPower;
            TStdItem* StdItem;
            int nAmuletIdx = 0;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                boSpellFire = true;
                if (TargeTBaseObject == null)
                {
                    return result;
                }
                if (TargeTBaseObject.m_btRaceServer == 128)// 火龙魔兽不能毒
                {
                    return result;
                }
                if (PlayObject.IsProperTarget(TargeTBaseObject))
                {
                    nCode = 1;
                    if (Magic.CheckAmulet(PlayObject, 1, 2, ref nAmuletIdx))
                    {
                        nCode = 2;
                        StdItem = null;
                        nCode = 3;
                        if ((nAmuletIdx == TPosition.U_ARMRINGL) || (nAmuletIdx == TPosition.U_BUJUK))
                        {
                            nCode = 4;
                            if (PlayObject.m_UseItems[nAmuletIdx]->wIndex > 0)
                            {
                                StdItem = UserEngine.GetStdItem(PlayObject.m_UseItems[nAmuletIdx]->wIndex);
                            }
                        }
                        nCode = 5;
                        if ((StdItem == null) || ((StdItem != null) && (StdItem->StdMode != 25)))
                        {
                            StdItem = UserEngine.GetStdItem(nAmuletIdx); // 如果装备上里没有物品,则从包裹里找
                        }
                        nCode = 6;
                        if (StdItem != null)
                        {
                            nCode = 7;
                            Magic.UseAmulet(PlayObject, 1, 2, ref nAmuletIdx);
                            nCode = 8;
                            if (HUtil32.Random(TargeTBaseObject.m_btAntiPoison + 7) <= 6)
                            {
                                switch (StdItem->Shape)
                                {
                                    case 1:
                                        nCode = 9;// 40
                                        nPower = MagLightening_GetPower13(UserMagic, 20) + MagLightening_GetRPow(PlayObject.m_WAbil.SC) * 2;
                                        nCode = 10;
                                        // 中毒类型 - 绿毒
                                        TargeTBaseObject.SendDelayMsg(PlayObject, Grobal2.RM_POISON, Grobal2.POISON_DECHEALTH, nPower, Parse(PlayObject),
                                            (int)HUtil32.Round((double)UserMagic->btLevel / 3 * (nPower / M2Share.g_Config.nAmyOunsulPoint)), "", 150);
                                        break;
                                    case 2:
                                        nCode = 11;// 40
                                        nPower = MagLightening_GetPower13(UserMagic, 20) + MagLightening_GetRPow(PlayObject.m_WAbil.SC) * 2;
                                        nCode = 12;
                                        // 中毒类型 - 红毒
                                        TargeTBaseObject.SendDelayMsg(PlayObject, Grobal2.RM_POISON, Grobal2.POISON_DAMAGEARMOR, nPower,
                                            Parse(PlayObject), (int)HUtil32.Round((double)UserMagic->btLevel / 3 * (nPower / M2Share.g_Config.nAmyOunsulPoint)), "", 150);
                                        break;
                                }
                                nCode = 13;
                                if ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                                {
                                    result = true;
                                }
                            }
                            nCode = 14;
                            if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                nCode = 15;
                                if (!((THeroObject)(PlayObject)).m_boTarget)
                                {
                                    PlayObject.SetTargetCreat(TargeTBaseObject);
                                }
                            }
                            else
                            {
                                PlayObject.SetTargetCreat(TargeTBaseObject);
                            }
                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                if (!((THeroObject)(TargeTBaseObject)).m_boTarget)
                                {
                                    TargeTBaseObject.SetTargetCreat(PlayObject);
                                }
                            }
                            boSpellFire = false;// 施毒不可用
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagLightening  Code:" + nCode);
            }
            return result;
        }

        // 寒冰掌 开天斩 龙影剑法
        public unsafe bool MagHbFireBall(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower = 0;
            int NGSecPwr = 0;
            int nDir = 0;
            int levelgap = 0;
            int push = 0;
            if (!PlayObject.MagCanHitTarget(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject))
            {
                TargeTBaseObject = null;
                return result;
            }
            if (!PlayObject.IsProperTarget(TargeTBaseObject))
            {
                TargeTBaseObject = null;
                return result;
            }
            if ((TargeTBaseObject.m_nAntiMagic > HUtil32.Random(10)) || (Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) > 1) || (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) > 1))
            {
                TargeTBaseObject = null;
                return result;
            }
            nPower = PlayObject.GetAttackPower(Magic.GetPower(Magic.MPow(UserMagic), UserMagic) + HUtil32.LoWord(PlayObject.m_WAbil.MC),
                ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
            if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
            {
                if (((TPlayObject)(PlayObject)).m_MagicSkill_226 != null)
                {
                    NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_226, nPower);// 怒之寒冰掌
                    if (TargeTBaseObject != null)
                    {
                        if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_227, nPower);// 静之寒冰掌
                        }
                        else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_227, nPower);// 静之寒冰掌
                        }
                    }
                    nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                }
            }
            else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
            {
                if (((THeroObject)(PlayObject)).m_MagicSkill_226 != null)
                {
                    NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_226, nPower);// 怒之寒冰掌
                    if (TargeTBaseObject != null)
                    {
                        if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_227, nPower);// 静之寒冰掌
                        }
                        else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            NGSecPwr = NGSecPwr - GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_227, nPower);// 静之寒冰掌
                        }
                    }
                    nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                }
            }
            PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 600);
            if ((TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
            {
                result = true;
            }
            if ((PlayObject.m_Abil.Level > TargeTBaseObject.m_Abil.Level) && (!TargeTBaseObject.m_boStickMode))
            {
                levelgap = PlayObject.m_Abil.Level - TargeTBaseObject.m_Abil.Level;
                if ((HUtil32.Random(20) < 6 + UserMagic->btLevel * 3 + levelgap))
                {
                    push = HUtil32.Random(UserMagic->btLevel) - 1;
                    if (push > 0)
                    {
                        nDir = M2Share.GetNextDirection(PlayObject.m_nCurrX, PlayObject.m_nCurrY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
                        PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYPUSHED, nDir, HUtil32.MakeLong(nTargetX, nTargetY), push, Parse(TargeTBaseObject), "", 600);
                    }
                }
            }
            return result;
        }

        public int MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(TBaseObject PlayObject, int btDir, int nHTime, int nDamage)
        {
            int result;
            TFireBurnEvent FireBurnEvent;
            int I;
            int x;
            int y;
            int nTime;
            result = 0;
            nTime = 1;
            switch (btDir)
            {
                case Grobal2.DR_UP:
                    for (y = PlayObject.m_nCurrY; y >= PlayObject.m_nCurrY - 10; y--)
                    {
                        FireBurnEvent = new TFireBurnEvent(PlayObject, PlayObject.m_nCurrX, y, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
                case Grobal2.DR_UPRIGHT:
                    for (I = 0; I <= 6; I++)
                    {
                        x = PlayObject.m_nCurrX + I;
                        y = PlayObject.m_nCurrY - I;
                        FireBurnEvent = new TFireBurnEvent(PlayObject, x, y, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime * 2), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
                case Grobal2.DR_RIGHT:
                    for (x = PlayObject.m_nCurrX; x <= PlayObject.m_nCurrX + 10; x++)
                    {
                        FireBurnEvent = new TFireBurnEvent(PlayObject, x, PlayObject.m_nCurrY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    for (I = 0; I <= 6; I++)
                    {
                        x = PlayObject.m_nCurrX + I;
                        y = PlayObject.m_nCurrY + I;
                        FireBurnEvent = new TFireBurnEvent(PlayObject, x, y, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime * 2), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
                case Grobal2.DR_DOWN:
                    for (y = PlayObject.m_nCurrY; y <= PlayObject.m_nCurrY + 10; y++)
                    {
                        FireBurnEvent = new TFireBurnEvent(PlayObject, PlayObject.m_nCurrX, y, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:
                    for (I = 0; I <= 6; I++)
                    {
                        x = PlayObject.m_nCurrX - I;
                        y = PlayObject.m_nCurrY + I;
                        FireBurnEvent = new TFireBurnEvent(PlayObject, x, y, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime * 2), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
                case Grobal2.DR_LEFT:
                    for (x = PlayObject.m_nCurrX; x >= PlayObject.m_nCurrX - 10; x--)
                    {
                        FireBurnEvent = new TFireBurnEvent(PlayObject, x, PlayObject.m_nCurrY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
                case Grobal2.DR_UPLEFT:
                    for (I = 0; I <= 6; I++)
                    {
                        x = PlayObject.m_nCurrX - I;
                        y = PlayObject.m_nCurrY - I;
                        FireBurnEvent = new TFireBurnEvent(PlayObject, x, y, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * nTime * 2), nDamage);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                        nTime++;
                    }
                    break;
            }
            result = 1;
            return result;
        }

        /// <summary>
        /// 产生任意形状的火
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="nDamage"></param>
        /// <param name="nHTime"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        public int MagMakeSuperFireCross(TBaseObject PlayObject, int nDamage, int nHTime, int nX, int nY, int nCount)
        {
            int result = 0;
            switch (nCount)
            {
                case 1:
                    result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                    break;
                case 3:
                    switch (PlayObject.m_btDirection)
                    {
                        case Grobal2.DR_UP:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPRIGHT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPLEFT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_UPRIGHT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UP, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_RIGHT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_RIGHT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPRIGHT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNRIGHT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_DOWNRIGHT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_RIGHT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWN, nHTime, nDamage);
                            break;
                        case Grobal2.DR_DOWN:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNLEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNRIGHT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_DOWNLEFT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWN, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_LEFT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_LEFT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNLEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPLEFT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_UPLEFT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, PlayObject.m_btDirection, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_LEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UP, nHTime, nDamage);
                            break;
                    }
                    break;
                case 4:
                    result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UP, nHTime, nDamage);
                    result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_LEFT, nHTime, nDamage);
                    result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWN, nHTime, nDamage);
                    result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_RIGHT, nHTime, nDamage);
                    break;
                case 5:
                    switch (PlayObject.m_btDirection)
                    {
                        case Grobal2.DR_UP:
                        case Grobal2.DR_UPLEFT:
                        case Grobal2.DR_UPRIGHT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UP, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPRIGHT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPLEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_LEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_RIGHT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_LEFT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UP, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWN, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPLEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_LEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNLEFT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_RIGHT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UP, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWN, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_UPRIGHT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_RIGHT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNRIGHT, nHTime, nDamage);
                            break;
                        case Grobal2.DR_DOWN:
                        case Grobal2.DR_DOWNLEFT:
                        case Grobal2.DR_DOWNRIGHT:
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWN, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNRIGHT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_DOWNLEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_LEFT, nHTime, nDamage);
                            result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, Grobal2.DR_RIGHT, nHTime, nDamage);
                            break;
                    }
                    break;
                case 8:
                    for (int I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                    {
                        result = MagMakeSuperFireCross_MagMakeSuperFireCrossOfDir(PlayObject, I, nHTime, nDamage);
                    }
                    break;
            }
            return result;
        }

        // 火墙 2*2范围
        public unsafe int MagMakeFireCross(TBaseObject PlayObject, int nDamage, int nHTime, int nX, int nY)
        {
            int result = 0;
            TFireBurnEvent FireBurnEvent;
            int NGSecPwr;
            int nScePwr = nDamage;
            if (M2Share.g_Config.boDisableInSafeZoneFireCross && PlayObject.InSafeZone(PlayObject.m_PEnvir, nX, nY))
            {
                PlayObject.SysMsg("安全区不允许使用...", TMsgColor.c_Red, TMsgType.t_Notice);
                return result;
            }
            if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
            {
                if (((TPlayObject)(PlayObject)).m_MagicSkill_212 != null)
                {
                    NGSecPwr = GetNGPow(PlayObject, ((TPlayObject)(PlayObject)).m_MagicSkill_212, nDamage);// 怒之火墙
                    nDamage = HUtil32._MAX(0, nDamage + NGSecPwr);
                }
            }
            else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
            {
                if (((THeroObject)(PlayObject)).m_MagicSkill_212 != null)
                {
                    NGSecPwr = GetNGPow(PlayObject, ((THeroObject)(PlayObject)).m_MagicSkill_212, nDamage);// 怒之火墙
                    nDamage = HUtil32._MAX(0, nDamage + NGSecPwr);
                }
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                FireBurnEvent.nTwoPwr = nScePwr;
                if (nDamage > nScePwr)
                {
                    FireBurnEvent.boReadSkill = true; //威力有变化，则认为是学过内功技能
                }
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            result = 1;
            return result;
        }

        // 冰咆哮  爆裂火焰 火龙气焰
        public unsafe bool MagBigExplosion(TBaseObject BaseObject, int nPower, int nX, int nY, int nRage, byte nCode)
        {
            bool result = false;
            int NGSecPwr;
            int nSePwr;
            int nTwoPwr;
            TBaseObject TargeTBaseObject;
            bool boReadSkill;// 是否学过内功技能
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            try
            {
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, nX, nY, nRage);
                nTwoPwr = nPower;
                boReadSkill = false;
                if (BaseObjectList.Count > 0)
                {
                    switch (nCode)
                    {
                        case MagicConst.SKILL_FIREBOOM:
                            if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                            {
                                if (((TPlayObject)(BaseObject)).m_MagicSkill_218 != null)
                                {
                                    NGSecPwr = GetNGPow(BaseObject, ((TPlayObject)(BaseObject)).m_MagicSkill_218, nTwoPwr);// 怒之爆裂火焰
                                    nPower = nPower + NGSecPwr;
                                    boReadSkill = true;
                                }
                            }
                            else if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                if (((THeroObject)(BaseObject)).m_MagicSkill_218 != null)
                                {
                                    NGSecPwr = GetNGPow(BaseObject, ((THeroObject)(BaseObject)).m_MagicSkill_218, nTwoPwr);// 怒之爆裂火焰
                                    nPower = nPower + NGSecPwr;
                                    boReadSkill = true;
                                }
                            }
                            break;
                        case MagicConst.SKILL_SNOWWIND:
                            if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                            {
                                if (((TPlayObject)(BaseObject)).m_MagicSkill_220 != null)
                                {
                                    NGSecPwr = GetNGPow(BaseObject, ((TPlayObject)(BaseObject)).m_MagicSkill_220, nTwoPwr);// 怒之冰咆哮
                                    nPower = nPower + NGSecPwr;
                                    boReadSkill = true;
                                }
                            }
                            else if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                if (((THeroObject)(BaseObject)).m_MagicSkill_220 != null)
                                {
                                    NGSecPwr = GetNGPow(BaseObject, ((THeroObject)(BaseObject)).m_MagicSkill_220, nTwoPwr);// 怒之冰咆哮
                                    nPower = nPower + NGSecPwr;
                                    boReadSkill = true;
                                }
                            }
                            break;
                    }
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = ((TBaseObject)(BaseObjectList[I]));
                        if (BaseObject.IsProperTarget(TargeTBaseObject))
                        {
                            nSePwr = nPower;
                            if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                // 修正英雄锁定后,不打锁定怪
                                if (!((THeroObject)(BaseObject)).m_boTarget)
                                {
                                    BaseObject.SetTargetCreat(TargeTBaseObject);
                                }
                            }
                            else
                            {
                                BaseObject.SetTargetCreat(TargeTBaseObject);
                            }
                            if (boReadSkill)
                            {
                                switch (nCode)
                                {
                                    case MagicConst.SKILL_FIREBOOM:
                                        NGSecPwr = 0;
                                        if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            NGSecPwr = GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_219, nTwoPwr);// 静之爆裂火焰
                                        }
                                        else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            NGSecPwr = GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_219, nTwoPwr);// 静之爆裂火焰
                                        }
                                        nSePwr = HUtil32._MAX(0, nSePwr - NGSecPwr);
                                        break;
                                    case MagicConst.SKILL_SNOWWIND:
                                        NGSecPwr = 0;
                                        if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            NGSecPwr = GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_221, nTwoPwr);// 静之冰咆哮
                                        }
                                        else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            NGSecPwr = GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_221, nTwoPwr);// 静之冰咆哮
                                        }
                                        nSePwr = HUtil32._MAX(0, nSePwr - NGSecPwr);
                                        break;
                                }
                            }
                            TargeTBaseObject.SendMsg(BaseObject, Grobal2.RM_MAGSTRUCK, 0, nSePwr, 0, 0, "");
                            result = true;
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
                //BaseObjectList.Free;;
            }
            return result;
        }

        /// <summary>
        /// 流星火雨
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nPower"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRage"></param>
        /// <returns></returns>
        public unsafe bool MagBigExplosion1(TBaseObject BaseObject, int nPower, int nX, int nY, int nRage)
        {
            bool result;
            int NGSecPwr;
            int nSePwr;
            int nTwoPwr;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            result = false;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, nX, nY, nRage);
                nTwoPwr = nPower;
                if (BaseObjectList.Count > 0)
                {
                    if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        if (((TPlayObject)(BaseObject)).m_MagicSkill_234 != null)
                        {
                            NGSecPwr = GetNGPow(BaseObject, ((TPlayObject)(BaseObject)).m_MagicSkill_234, nTwoPwr);// 怒之流星火雨
                            nPower = nPower + NGSecPwr;
                        }
                    }
                    else if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        if (((THeroObject)(BaseObject)).m_MagicSkill_234 != null)
                        {
                            NGSecPwr = GetNGPow(BaseObject, ((THeroObject)(BaseObject)).m_MagicSkill_234, nTwoPwr);// 怒之流星火雨
                            nPower = nPower + NGSecPwr;
                        }
                    }
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (BaseObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                BaseObject.m_ExpHitter = TargeTBaseObject;// 英雄可以按范围打到目标
                            }
                            if (BaseObject.IsProperTarget(TargeTBaseObject))
                            {
                                if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    if (!((THeroObject)(BaseObject)).m_boTarget) // 修正英雄锁定后,不打锁定怪
                                    {
                                        BaseObject.SetTargetCreat(TargeTBaseObject);
                                    }
                                }
                                else
                                {
                                    BaseObject.SetTargetCreat(TargeTBaseObject);
                                }
                                NGSecPwr = 0;
                                if (nPower > nTwoPwr)
                                {
                                    if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_235, nTwoPwr);// 静之流星火雨
                                    }
                                    else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_235, nTwoPwr);// 静之流星火雨
                                    }
                                }
                                nSePwr = HUtil32._MAX(0, nPower - NGSecPwr);
                                TargeTBaseObject.SendDelayMsg(BaseObject, Grobal2.RM_MAGSTRUCK, 0, nSePwr, 0, 0, "", 1500);
                                result = true;
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        /// <summary>
        /// 地狱雷光
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nPower"></param>
        /// <returns></returns>
        public unsafe bool MagElecBlizzard(TBaseObject BaseObject, int nPower)
        {
            bool result = false;
            TBaseObject TargeTBaseObject;
            int nPowerPoint;
            int NGSecPwr;
            int nSewPwr;
            int nTwoPwr;
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            try
            {
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, BaseObject.m_nCurrX, BaseObject.m_nCurrY, M2Share.g_Config.nElecBlizzardRange);
                nTwoPwr = nPower;
                if (BaseObjectList.Count > 0)
                {
                    if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        if (((TPlayObject)(BaseObject)).m_MagicSkill_224 != null)
                        {
                            NGSecPwr = GetNGPow(BaseObject, ((TPlayObject)(BaseObject)).m_MagicSkill_224, nTwoPwr);// 怒之地狱雷光
                            nPower = nPower + NGSecPwr;
                        }
                    }
                    else if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        if (((THeroObject)(BaseObject)).m_MagicSkill_224 != null)
                        {
                            NGSecPwr = GetNGPow(BaseObject, ((THeroObject)(BaseObject)).m_MagicSkill_224, nTwoPwr);// 怒之地狱雷光
                            nPower = nPower + NGSecPwr;
                        }
                    }
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        NGSecPwr = 0;
                        if (nPower > nTwoPwr)
                        {
                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                NGSecPwr = GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_225, nTwoPwr);// 静之地狱雷光
                            }
                            else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                NGSecPwr = GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_225, nTwoPwr);// 静之地狱雷光
                            }
                        }
                        nSewPwr = HUtil32._MAX(0, nPower - NGSecPwr);
                        if (!(TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)) // 不为不死系
                        {
                            nPowerPoint = nSewPwr / 10;
                        }
                        else
                        {
                            nPowerPoint = nSewPwr;
                        }
                        if (BaseObject.IsProperTarget(TargeTBaseObject))
                        {
                            BaseObject.SetTargetCreat(TargeTBaseObject);
                            TargeTBaseObject.SendMsg(BaseObject, Grobal2.RM_MAGSTRUCK, 0, nPowerPoint, 0, 0, "");
                            result = true;
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // 困魔咒
        public int MagMakeHolyCurtain(TBaseObject BaseObject, int nPower, int nX, int nY)
        {
            int result = 0;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            TMagicEvent MagicEvent;
            THolyCurtainEvent HolyCurtainEvent;
            if (BaseObject.m_PEnvir.CanWalk(nX, nY, true))
            {
                BaseObjectList = new List<TBaseObject>();
                try
                {
                    MagicEvent = null;
                    BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, nX, nY, 1);
                    if (BaseObjectList.Count > 0)
                    {
                        for (int I = 0; I < BaseObjectList.Count; I++)
                        {
                            TargeTBaseObject = BaseObjectList[I];// 恶魔蝙蝠 不用判断等级
                            if (((TargeTBaseObject.m_btRaceServer == 127) || ((TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL) &&
                                ((HUtil32.Random(4) + (BaseObject.m_Abil.Level - 1)) > TargeTBaseObject.m_Abil.Level))) && (TargeTBaseObject.m_Master == null))
                            {
                                TargeTBaseObject.OpenHolySeizeMode((uint)nPower * 1000);
                                if (MagicEvent == null)
                                {
                                    MagicEvent = new TMagicEvent();
                                    //FillChar(MagicEvent, sizeof(TMagicEvent), '\0');
                                    MagicEvent.BaseObjectList = new List<TBaseObject>();
                                    MagicEvent.dwStartTick = HUtil32.GetTickCount();
                                    MagicEvent.dwTime = Convert.ToUInt32(nPower * 1000);
                                }
                                MagicEvent.BaseObjectList.Add(TargeTBaseObject);
                                result++;
                            }
                            else
                            {
                                result = 0;
                            }
                        }
                    }
                }
                finally
                {
                    Dispose(BaseObjectList);
                }
                if (result > 0 && MagicEvent != null)
                {
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX - 1, nY - 2, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[0] = HolyCurtainEvent;
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX + 1, nY - 2, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[1] = HolyCurtainEvent;
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX - 2, nY - 1, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[2] = HolyCurtainEvent;
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX + 2, nY - 1, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[3] = HolyCurtainEvent;
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX - 2, nY + 1, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[4] = HolyCurtainEvent;
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX + 2, nY + 1, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[5] = HolyCurtainEvent;
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX - 1, nY + 2, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[6] = HolyCurtainEvent;
                    HolyCurtainEvent = new THolyCurtainEvent(BaseObject.m_PEnvir, nX + 1, nY + 2, Grobal2.ET_HOLYCURTAIN, Convert.ToUInt32(nPower * 1000));
                    M2Share.g_EventManager.AddEvent(HolyCurtainEvent);
                    MagicEvent.Events[7] = HolyCurtainEvent;
                    UserEngine.m_MagicEventList.Add(MagicEvent);
                }
                else
                {
                    if (MagicEvent != null)
                    {
                        Dispose(MagicEvent.BaseObjectList);
                        Dispose(MagicEvent);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 群体隐身术
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nHTime"></param>
        /// <returns></returns>
        public bool MagMakeGroupTransparent(TBaseObject BaseObject, int nX, int nY, int nHTime)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            TBaseObject TargeTBaseObject;
            try
            {
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, nX, nY, 1);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (BaseObject.IsProperFriend(TargeTBaseObject))
                        {
                            if (TargeTBaseObject.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] == 0)
                            {
                                TargeTBaseObject.SendDelayMsg(TargeTBaseObject, Grobal2.RM_TRANSPARENT, 0, nHTime, 0, 0, "", 800);
                                result = true;
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseObject">魔法发起人</param>
        /// <param name="TargeTBaseObject">受攻击角色</param>
        /// <param name="nPower">魔法力大小</param>
        /// <param name="nLevel">技能修炼等级</param>
        /// <param name="nTargetX">目标座标X</param>
        /// <param name="nTargetY">目标座标Y</param>
        /// <returns></returns>
        public bool MabMabe(TBaseObject BaseObject, TBaseObject TargeTBaseObject, int nPower, int nLevel, int nTargetX, int nTargetY)
        {
            bool result = false;
            int nLv;
            if (BaseObject.MagCanHitTarget(BaseObject.m_nCurrX, BaseObject.m_nCurrY, TargeTBaseObject))
            {
                if (BaseObject.IsProperTarget(TargeTBaseObject) && (BaseObject != TargeTBaseObject))
                {
                    if ((TargeTBaseObject.m_nAntiMagic <= HUtil32.Random(10)) && (Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                    {
                        BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DELAYMAGIC, nPower / 3, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 600);
                        if ((HUtil32.Random(2) + (BaseObject.m_Abil.Level - 1)) > TargeTBaseObject.m_Abil.Level)
                        {
                            nLv = BaseObject.m_Abil.Level - TargeTBaseObject.m_Abil.Level;// 100
                            if ((HUtil32.Random(M2Share.g_Config.nMabMabeHitRandRate) < HUtil32._MAX(M2Share.g_Config.nMabMabeHitMinLvLimit, (nLevel * 8) - nLevel + 15 + nLv)))
                            {
                                if ((HUtil32.Random(M2Share.g_Config.nMabMabeHitSucessRate) < nLevel * 2 + 4))
                                {
                                    if ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                    {
                                        BaseObject.SetPKFlag(BaseObject);// 英雄灰色
                                        BaseObject.SetTargetCreat(TargeTBaseObject);
                                    }
                                    TargeTBaseObject.SetLastHiter(BaseObject);
                                    nPower = TargeTBaseObject.GetMagStruckDamage(BaseObject, nPower);
                                    BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 600);
                                    if (!TargeTBaseObject.m_boUnParalysis)
                                    {
                                        // 中毒类型 - 麻痹
                                        TargeTBaseObject.SendDelayMsg(BaseObject, Grobal2.RM_POISON, Grobal2.POISON_STONE, nPower / M2Share.g_Config.nMabMabeHitMabeTimeRate + HUtil32.Random(nLevel), Parse(BaseObject), nLevel, "", 650);
                                    }
                                    //TargeTBaseObject.SendDelayMsg(BaseObject, RM_POISON, POISON_STONE {中毒类型 - 麻痹}, nPower div g_Config.nMabMabeHitMabeTimeRate {20} + Random(nLevel), Integer(BaseObject), nLevel, '', 10);
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
        /// 召唤神兽
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe bool MagMakeSinSuSlave(TBaseObject PlayObject, TUserMagic* UserMagic)
        {
            bool result = false;
            string sMonName;
            int nMakeLevel;
            int nExpLevel;
            int nCount;
            uint dwRoyaltySec;
            TBaseObject Slave;
            byte nCode = 0;
            try
            {
                if (!PlayObject.sub_4DD704())
                {
                    nCode = 1;
                    sMonName = M2Share.g_Config.sDogz;
                    nMakeLevel = UserMagic->btLevel;
                    nExpLevel = UserMagic->btLevel;
                    nCount = M2Share.g_Config.nDogzCount;
                    dwRoyaltySec = 1728000;// 20 * 24 * 60 * 60
                    nCode = 2;
                    for (int I = M2Share.g_Config.DogzArray.GetLowerBound(0); I <= M2Share.g_Config.DogzArray.GetUpperBound(0); I++)
                    {
                        if (M2Share.g_Config.DogzArray[I].nHumLevel == 0)
                        {
                            break;
                        }
                        if (PlayObject.m_Abil.Level >= M2Share.g_Config.DogzArray[I].nHumLevel)
                        {
                            sMonName = M2Share.g_Config.DogzArray[I].sMonName;
                            nExpLevel = M2Share.g_Config.DogzArray[I].nLevel;
                            nCount = M2Share.g_Config.DogzArray[I].nCount;
                        }
                    }
                    nCode = 3;
                    if (PlayObject.MakeSlave(sMonName, nMakeLevel, nExpLevel, nCount, dwRoyaltySec) != null)// 已招出来的神兽,飞到主人身边
                    {
                        result = true;
                    }
                    else
                    {
                        nCode = 4;
                        if ((PlayObject.m_SlaveList.Count > 0) && M2Share.g_Config.boSlaveMoveMaster)
                        {
                            foreach (var SlaveObject in PlayObject.m_SlaveList)
                            {
                                nCode = 5;
                                if ((SlaveObject != null) && (!SlaveObject.m_boDeath))
                                {
                                    if (string.Compare(SlaveObject.m_sCharName, sMonName, true) == 0 || string.Compare(SlaveObject.m_sCharName, sMonName + "1", true) == 0)
                                    {
                                        nCode = 6;
                                        if (SlaveObject.m_TargetCret != null)
                                        {
                                            SlaveObject.m_TargetCret = null;// 修正召唤到身边后,还回去打原来的目标
                                        }
                                        nCode = 7;
                                        SlaveObject.SpaceMove(PlayObject.m_sMapName, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 0);//多个宝宝时,一起飞
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagMakeSinSuSlave  Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// 召唤圣兽
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe bool MagMakeSacredSlave(TBaseObject PlayObject, TUserMagic* UserMagic)
        {
            bool result;
            string sMonName;
            int nMakeLevel;
            int nExpLevel;
            int nCount;
            uint dwRoyaltySec;
            TBaseObject Slave;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (!PlayObject.sub_4DD704())
                {
                    nCode = 1;
                    sMonName = M2Share.g_Config.SacRed;
                    nMakeLevel = UserMagic->btLevel;
                    nExpLevel = UserMagic->btLevel;
                    nCount = M2Share.g_Config.SacredCount;
                    dwRoyaltySec = 1728000;// 20 * 24 * 60 * 60  //叛变时间
                    nCode = 2;
                    for (int I = M2Share.g_Config.DogzArray.GetLowerBound(0); I <= M2Share.g_Config.DogzArray.GetUpperBound(0); I++)
                    {
                        if (M2Share.g_Config.DogzArray[I].nHumLevel == 0)
                        {
                            break;
                        }
                        if (PlayObject.m_Abil.Level >= M2Share.g_Config.DogzArray[I].nHumLevel)
                        {
                            sMonName = M2Share.g_Config.DogzArray[I].sMonName;
                            nExpLevel = M2Share.g_Config.DogzArray[I].nLevel;
                            nCount = M2Share.g_Config.DogzArray[I].nCount;
                        }
                    }
                    nCode = 3;
                    if (PlayObject.MakeSlave(sMonName, nMakeLevel, nExpLevel, nCount, dwRoyaltySec) != null)  // 已招出来的圣兽,飞到主人身边
                    {
                        result = true;
                    }
                    else
                    {
                        nCode = 4;
                        if ((PlayObject.m_SlaveList.Count > 0) && M2Share.g_Config.boSlaveMoveMaster)
                        {
                            for (int I = 0; I < PlayObject.m_SlaveList.Count; I++)
                            {
                                Slave = PlayObject.m_SlaveList[I];
                                nCode = 5;
                                if ((Slave != null) && (!Slave.m_boDeath))
                                {
                                    if (string.Compare(Slave.m_sCharName, sMonName, true) == 0 || string.Compare(Slave.m_sCharName, sMonName + "1", true) == 0)
                                    {
                                        nCode = 6;
                                        if (Slave.m_TargetCret != null)
                                        {
                                            Slave.m_TargetCret = null; // 修正召唤到身边后,还回去打原来的目标
                                        }
                                        nCode = 7;
                                        Slave.SpaceMove(PlayObject.m_sMapName, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 0);//多个宝宝时,一起飞
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagMakeSinSuSlave  Code:" + nCode);
            }
            return result;
        }

        // 召唤骷髅
        public unsafe bool MagMakeSlave(TBaseObject PlayObject, TUserMagic* UserMagic)
        {
            bool result;
            string sMonName;
            int nMakeLevel;
            int nExpLevel;
            int nCount;
            uint dwRoyaltySec;
            TBaseObject Slave;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (!PlayObject.sub_4DD704())
                {
                    nCode = 1;
                    sMonName = M2Share.g_Config.sBoneFamm;
                    nMakeLevel = UserMagic->btLevel;
                    nExpLevel = UserMagic->btLevel;
                    nCount = M2Share.g_Config.nBoneFammCount;
                    dwRoyaltySec = 1728000; // 20 * 24 * 60 * 60
                    nCode = 2;
                    for (int I = M2Share.g_Config.BoneFammArray.GetLowerBound(0); I <= M2Share.g_Config.BoneFammArray.GetUpperBound(0); I++)
                    {
                        nCode = 3;
                        if (M2Share.g_Config.BoneFammArray[I].nHumLevel == 0)
                        {
                            break;
                        }
                        nCode = 4;
                        if (PlayObject.m_Abil.Level >= M2Share.g_Config.BoneFammArray[I].nHumLevel)
                        {
                            nCode = 5;
                            sMonName = M2Share.g_Config.BoneFammArray[I].sMonName;
                            nExpLevel = M2Share.g_Config.BoneFammArray[I].nLevel;
                            nCount = M2Share.g_Config.BoneFammArray[I].nCount;
                            nCode = 6;
                        }
                    }
                    nCode = 7;
                    if (PlayObject.MakeSlave(sMonName, nMakeLevel, nExpLevel, nCount, dwRoyaltySec) != null)
                    {
                        nCode = 8;
                        result = true;
                    }
                    else
                    {
                        // 已招出来的变异骷髅,飞到主人身边
                        nCode = 9;
                        if ((PlayObject.m_SlaveList.Count > 0) && M2Share.g_Config.boSlaveMoveMaster)
                        {
                            for (int I = 0; I < PlayObject.m_SlaveList.Count; I++)
                            {
                                nCode = 10;
                                Slave = ((TBaseObject)(PlayObject.m_SlaveList[I]));
                                nCode = 11;
                                if ((Slave != null) && (!Slave.m_boDeath))
                                {
                                    if (string.Compare(Slave.m_sCharName, sMonName, true) == 0)
                                    {
                                        nCode = 12;
                                        if (Slave.m_TargetCret != null)
                                        {
                                            Slave.m_TargetCret = null;// 修正召唤到身边后,还回去打原来的目标
                                        }
                                        nCode = 13;
                                        Slave.SpaceMove(PlayObject.m_sMapName, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 0);//多个宝宝时,一起飞
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagMakeSlave  Code:" + nCode);
            }
            return result;
        }

        // 召唤月灵
        public unsafe bool MagMakeFairy(TBaseObject PlayObject, TUserMagic* UserMagic)
        {
            bool result = false;
            int I;
            string sMonName;
            int nMakeLevel;
            int nExpLevel;
            int nCount;
            uint dwRoyaltySec;
            TBaseObject Slave;
            byte nCode = 0;
            try
            {
                if (!PlayObject.sub_4DD704())
                {
                    nCode = 1;
                    sMonName = M2Share.g_Config.sFairy;
                    nMakeLevel = UserMagic->btLevel;
                    nExpLevel = UserMagic->btLevel;
                    nCount = M2Share.g_Config.nFairyCount;
                    dwRoyaltySec = 1728000;// 20 * 24 * 60 * 60
                    nCode = 2;
                    for (I = M2Share.g_Config.FairyArray.GetLowerBound(0); I <= M2Share.g_Config.FairyArray.GetUpperBound(0); I++)
                    {
                        nCode = 3;
                        if (M2Share.g_Config.FairyArray[I].nHumLevel == 0)
                        {
                            break;
                        }
                        nCode = 4;
                        if (PlayObject.m_Abil.Level >= M2Share.g_Config.FairyArray[I].nHumLevel)
                        {
                            nCode = 5;
                            sMonName = M2Share.g_Config.FairyArray[I].sMonName;
                            nExpLevel = M2Share.g_Config.FairyArray[I].nLevel;
                            nCount = M2Share.g_Config.FairyArray[I].nCount;
                            nCode = 6;
                        }
                    }
                    nCode = 7;
                    if (PlayObject.MakeSlave(sMonName, nMakeLevel, nExpLevel, nCount, dwRoyaltySec) != null)// 已招出来的月灵,飞到主人身边
                    {
                        result = true;
                    }
                    else
                    {
                        nCode = 8;
                        if ((PlayObject.m_SlaveList.Count > 0) && M2Share.g_Config.boSlaveMoveMaster)
                        {
                            for (I = 0; I < PlayObject.m_SlaveList.Count; I++)
                            {
                                nCode = 9;
                                Slave = ((TBaseObject)(PlayObject.m_SlaveList[I]));
                                nCode = 10;
                                if (Slave != null && !Slave.m_boDeath)
                                {
                                    nCode = 11;
                                    if (string.Compare(Slave.m_sCharName, sMonName, true) == 0)
                                    {
                                        nCode = 12;
                                        if (Slave.m_TargetCret != null)
                                        {
                                            Slave.m_TargetCret = null;// 修正召唤到身边后,还回去打原来的目标
                                        }
                                        nCode = 13;
                                        Slave.SpaceMove(PlayObject.m_sMapName, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 0);//多个宝宝时,一起飞
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMagicManager.MagMakeFairy  Code:" + nCode);
            }
            return result;
        }

        // 召唤宝宝
        public unsafe bool MagMakeSlave_(TBaseObject PlayObject, TUserMagic* UserMagic, string sMonName, int nCount, int nHumLevel, int nMonLevel)
        {
            bool result = false;
            int nMakeLevel;
            int nExpLevel;
            uint dwRoyaltySec;
            nMakeLevel = 0;
            nExpLevel = 0;
            dwRoyaltySec = 0;
            if (!PlayObject.sub_4DD704())
            {
                nMakeLevel = UserMagic->btLevel;
                nExpLevel = UserMagic->btLevel;
                nCount = M2Share.g_Config.nBoneFammCount;
                dwRoyaltySec = 864000; // 10 * 24 * 60 * 60
                if (PlayObject.m_Abil.Level >= nHumLevel)
                {
                    nExpLevel = nMonLevel;
                }
            }
            if (PlayObject.MakeSlave(sMonName, nMakeLevel, nExpLevel, nCount, dwRoyaltySec) != null)
            {
                result = true;
            }
            return result;
        }

        // 分身术
        public unsafe bool MagMakeSelf(TBaseObject BaseObject, TBaseObject TargeTBaseObject, TUserMagic* UserMagic)
        {
            bool result = false;
            string sMonName;
            int nCount;
            uint dwRoyaltySec;
            bool boboAllowReCallMob;
            TBaseObject BaseObject01;
            if ((HUtil32.GetTickCount() - BaseObject.m_dwLatest46Tick) > (M2Share.g_Config.nCopyHumanTick * 1000)) // 分身召唤间隔
            {
                BaseObject.m_dwLatest46Tick = HUtil32.GetTickCount();
                boboAllowReCallMob = false;
                BaseObject01 = null;
                if (!BaseObject.sub_4DD704())
                {
                    if (M2Share.g_Config.boAddMasterName)
                    {
                        sMonName = BaseObject.m_sCharName + M2Share.g_Config.sCopyHumName;
                    }
                    else
                    {
                        sMonName = M2Share.g_Config.sCopyHumName;
                    }
                    nCount = M2Share.g_Config.nAllowCopyHumanCount;
                    if (BaseObject.m_btRaceServer != Grobal2.RC_HEROOBJECT)
                    {
                        // 英雄分身按技能等级增加使用时间
                        dwRoyaltySec = (uint)M2Share.g_Config.nMakeSelfTick;// 分身使用时间可以调节
                    }
                    else
                    {
                        dwRoyaltySec = Convert.ToUInt32(M2Share.g_Config.nMakeSelfTick + UserMagic->btLevel * M2Share.g_Config.nHeroMakeSelfTick);
                    }
                    if (M2Share.g_Config.boAllowReCallMobOtherHum)
                    {
                        // 召唤分身的角色是英雄
                        if ((TargeTBaseObject != null) && (!TargeTBaseObject.m_boDeath) && (BaseObject.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                        {
                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                BaseObject01 = TargeTBaseObject;
                                boboAllowReCallMob = true;
                            }
                        }
                        else
                        {
                            BaseObject01 = BaseObject;
                            boboAllowReCallMob = true;
                        }
                        if (M2Share.g_Config.boNeedLevelHighTarget && (TargeTBaseObject != null) && (BaseObject.m_Abil.Level < TargeTBaseObject.m_Abil.Level))
                        {
                            boboAllowReCallMob = false;
                        }
                    }
                    else
                    {
                        BaseObject01 = BaseObject;
                        boboAllowReCallMob = true;
                    }
                    if (boboAllowReCallMob)
                    {
                        if (((TPlayObject)BaseObject).MakeSelf(((TPlayObject)BaseObject01), sMonName, nCount, dwRoyaltySec) != null)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        // 狮子吼
        public unsafe bool MagGroupMb(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            TBaseObject BaseObject;
            ushort nTime = Convert.ToUInt16(1 * UserMagic->btLevel + 3);
            BaseObjectList = PlayObject.GetMapBaseObjects(PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, UserMagic->btLevel + 2);
            if (BaseObjectList.Count > 0)
            {
                for (int I = 0; I < BaseObjectList.Count; I++)
                {
                    BaseObject = BaseObjectList[I];
                    if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (PlayObject == BaseObject))
                    {
                        continue;
                    }
                    if (((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (BaseObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER)) && (!M2Share.g_Config.boGroupMbAttackPlayObject))
                    {
                        continue;
                    }
                    // 英雄,人形,人物无效
                    if ((BaseObject.m_Master != null) && (BaseObject.m_Master == PlayObject) && (!M2Share.g_Config.boGroupMbAttackPlayObject))
                    {
                        continue;
                    }
                    // 自已下属不能用
                    if ((BaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (BaseObject.m_Master != null) && (!M2Share.g_Config.boGroupMbAttackSlave))
                    {
                        continue;
                    }
                    if (PlayObject.IsProperTarget(BaseObject))
                    {
                        if (!BaseObject.m_boUnParalysis && (HUtil32.Random(BaseObject.m_btAntiPoison) == 0))
                        {
                            if ((BaseObject.m_Abil.Level < PlayObject.m_Abil.Level) || (HUtil32.Random(PlayObject.m_Abil.Level - BaseObject.m_Abil.Level) == 0))
                            {
                                BaseObject.MakePosion(Grobal2.POISON_STONE, nTime, 0);
                            }
                        }
                    }
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        result = true;
                    }
                    else if (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                    {
                        result = true;
                    }
                }
            }
            Dispose(BaseObjectList);
            return result;
        }

        public unsafe int MagMakeHPUp_GetSpellPoint(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wSpell + UserMagic->MagicInfo.btDefSpell;
        }

        // 酒气护体
        public unsafe bool MagMakeHPUp(TBaseObject PlayObject, TUserMagic* UserMagic)
        {
            bool result;
            int nSpellPoint;
            int n14;
            result = false;
            nSpellPoint = MagMakeHPUp_GetSpellPoint(UserMagic);
            if (nSpellPoint > 0)
            {
                if (UserMagic->btLevel > 0)
                {
                    if ((PlayObject.m_Abil.WineDrinkValue >= HUtil32.Round((double)PlayObject.m_Abil.MaxAlcohol * M2Share.g_Config.nMinDrinkValue68 / 100))) // 时间间隔
                    {
                        if ((HUtil32.GetTickCount() - PlayObject.m_dwStatusArrTimeOutTick[4] > M2Share.g_Config.nHPUpTick * 1000) && (PlayObject.m_wStatusArrValue[4] == 0))
                        {
                            if (PlayObject.m_WAbil.MP < nSpellPoint)
                            {
                                PlayObject.SysMsg("MP值不足!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                                return result;
                            }
                            PlayObject.DamageSpell(nSpellPoint);// 减MP值
                            PlayObject.HealthSpellChanged();
                            n14 = 300 + M2Share.g_Config.nHPUpUseTime;
                            PlayObject.m_dwStatusArrTimeOutTick[4] = Convert.ToUInt32(HUtil32.GetTickCount() + n14 * 1000);// 使用时间
                            PlayObject.m_wStatusArrValue[4] = UserMagic->btLevel;// 提升值
                            PlayObject.SysMsg("生命值瞬间提升, 持续" + n14 + "秒", TMsgColor.c_Green, TMsgType.t_Hint);
                            PlayObject.SysMsg("你的酒气护体已经在激活状态", TMsgColor.c_Green, TMsgType.t_Hint);
                            PlayObject.RecalcAbilitys();
                            PlayObject.CompareSuitItem(false);// 套装与身上装备对比
                            PlayObject.SendMsg(PlayObject, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                            result = true;
                        }
                        else
                        {
                            PlayObject.SysMsg(GameMsgDef.g_sOpenShieldOKMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        PlayObject.SysMsg("醉酒度不低于" + M2Share.g_Config.nMinDrinkValue68 + "%时,才能使用此技能 ", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("等级需达1级以上,才能使用此技能", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            return result;
        }

        /// <summary>
        /// 取内功技能掉内力值
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="UserMagic"></param>
        /// <param name="Power"></param>
        /// <returns></returns>
        public unsafe int GetNGPow(TBaseObject BaseObject, TUserMagic* UserMagic, int Power)
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

        public unsafe int MagMakeSkillFire_77_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_77_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower +
                  HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_77(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_77_GetPower(UserMagic, MagMakeSkillFire_77_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.MC),
                        ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 300);
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // Result := True;
                    }
                    else if (TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                    {
                        // Result := True;
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

        public unsafe int MagMakeSkillFire_78_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_78_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower +
                 HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_78(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_78_GetPower(UserMagic, MagMakeSkillFire_78_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.SC),
                        ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                    }
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 300);
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

        public unsafe int MagMakeSkillFire_80_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_80_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower +
                 HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_80(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_80_GetPower(UserMagic, MagMakeSkillFire_80_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.MC),
                        ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                    }
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 300);
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

        public unsafe int MagMakeSkillFire_81_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_81_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower +
                 HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_81(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_81_GetPower(UserMagic, MagMakeSkillFire_81_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.SC),
                        ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {

                    }
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 300);
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

        public unsafe int MagMakeSkillFire_83_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_83_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower +
                HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_83(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_83_GetPower(UserMagic, MagMakeSkillFire_83_MPow(UserMagic)) +
                        HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {

                    }
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 300);
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

        public unsafe int MagMakeSkillFire_84_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeSkillFire_84_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_84(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeSkillFire_84_GetPower(UserMagic, MagMakeSkillFire_84_MPow(UserMagic)) +
                        HUtil32.LoWord(PlayObject.m_WAbil.SC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.SC) - HUtil32.LoWord(PlayObject.m_WAbil.SC)) + 1);
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {

                    }
                    PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(nTargetX, nTargetY), 2, Parse(TargeTBaseObject), "", 300);
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

        public unsafe int MagMakeSkillFire_86_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) *
                (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_86(TBaseObject BaseObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            int nPower = 0;
            try
            {
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, nTargetX, nTargetY, 3);
                nPower = BaseObject.GetAttackPower(MagMakeSkillFire_86_GetPower(UserMagic, Magic.MPow(UserMagic)) + HUtil32.LoWord(BaseObject.m_WAbil.MC),
                    ((short)HUtil32.HiWord(BaseObject.m_WAbil.MC) - HUtil32.LoWord(BaseObject.m_WAbil.MC)) + 1);
                for (int I = 0; I < BaseObjectList.Count; I++)
                {
                    TargeTBaseObject = BaseObjectList[I];
                    if (BaseObject.IsProperTarget(TargeTBaseObject))
                    {
                        if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            // 修正英雄锁定后,不打锁定怪
                            if (!((THeroObject)(BaseObject)).m_boTarget)
                            {
                                BaseObject.SetTargetCreat(TargeTBaseObject);
                            }
                        }
                        else
                        {
                            BaseObject.SetTargetCreat(TargeTBaseObject);
                        }
                        TargeTBaseObject.SendMsg(BaseObject, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                        M2Share.MainOutMessage("2");
                        result = true;
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        public unsafe int MagMakeSkillFire_87_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) +
                (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe bool MagMakeSkillFire_87(TBaseObject BaseObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            int nPower = 0;
            try
            {
                BaseObjectList = BaseObject.GetMapBaseObjects(BaseObject.m_PEnvir, nTargetX, nTargetY, 3);
                nPower = BaseObject.GetAttackPower(MagMakeSkillFire_87_GetPower(UserMagic, Magic.MPow(UserMagic)) + HUtil32.LoWord(BaseObject.m_WAbil.SC),
                    ((short)HUtil32.HiWord(BaseObject.m_WAbil.SC) - HUtil32.LoWord(BaseObject.m_WAbil.SC)) + 1);
                for (int I = 0; I < BaseObjectList.Count; I++)
                {
                    TargeTBaseObject = BaseObjectList[I];
                    if (BaseObject.IsProperTarget(TargeTBaseObject))
                    {
                        if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)// 修正英雄锁定后,不打锁定怪
                        {
                            if (!((THeroObject)(BaseObject)).m_boTarget)
                            {
                                BaseObject.SetTargetCreat(TargeTBaseObject);
                            }
                        }
                        else
                        {
                            BaseObject.SetTargetCreat(TargeTBaseObject);
                        }
                        TargeTBaseObject.SendMsg(BaseObject, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                        result = true;
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        public int GetStormsHitRate_GetRate(int PulseLevel)
        {
            int result = -1;
            switch (PulseLevel)
            {
                case 1:
                    result = M2Share.g_Config.StormsHitAppearRate0;
                    if (HUtil32.Random(100) < result)
                    {
                        result = M2Share.g_Config.StormsHitAppearRate0;
                    }
                    else
                    {
                        result = -1;
                    }
                    break;
                case 2:
                    result = M2Share.g_Config.StormsHitAppearRate1;
                    if (HUtil32.Random(100) < result)
                    {
                        result = M2Share.g_Config.StormsHitAppearRate1;
                    }
                    else
                    {
                        result = -1;
                    }
                    break;
                case 3:
                    result = M2Share.g_Config.StormsHitAppearRate2;
                    if (HUtil32.Random(100) < result)
                    {
                        result = M2Share.g_Config.StormsHitAppearRate2;
                    }
                    else
                    {
                        result = -1;
                    }
                    break;
                case 4:
                    result = M2Share.g_Config.StormsHitAppearRate3;
                    if (HUtil32.Random(100) < result)
                    {
                        result = M2Share.g_Config.StormsHitAppearRate3;
                    }
                    else
                    {
                        result = -1;
                    }
                    break;
                case 5:
                    result = M2Share.g_Config.StormsHitAppearRate4;
                    if (HUtil32.Random(100) < result)
                    {
                        result = M2Share.g_Config.StormsHitAppearRate4;
                    }
                    else
                    {
                        result = -1;
                    }
                    break;
            }
            return result;
        }

        // 酒气护体
        public int GetStormsHitRate(TBaseObject PlayObject, int MagicID)
        {
            int result = -1;
            switch (MagicID)
            {
                // Modify the A .. B: 76 .. 78
                case 76:
                    result = GetStormsHitRate_GetRate(((TPlayObject)(PlayObject)).m_HumPulses[0].PulseLevel);
                    break;
                // Modify the A .. B: 79 .. 81
                case 79:
                    result = GetStormsHitRate_GetRate(((TPlayObject)(PlayObject)).m_HumPulses[1].PulseLevel);
                    break;
                // Modify the A .. B: 82 .. 84
                case 82:
                    result = GetStormsHitRate_GetRate(((TPlayObject)(PlayObject)).m_HumPulses[2].PulseLevel);
                    break;
                // Modify the A .. B: 85 .. 87
                case 85:
                    result = GetStormsHitRate_GetRate(((TPlayObject)(PlayObject)).m_HumPulses[3].PulseLevel);
                    break;
            }
            return result;
        }

        public string GetNameByMagicID(int MagicID)
        {
            string result = string.Empty;
            switch (MagicID)
            {
                case 76:
                    result = "三绝杀";
                    break;
                case 77:
                    result = "双龙破";
                    break;
                case 78:
                    result = "虎啸诀";
                    break;
                case 79:
                    result = "追心刺";
                    break;
                case 80:
                    result = "凤舞祭";
                    break;
                case 81:
                    result = "八卦掌";
                    break;
                case 82:
                    result = "断岳斩";
                    break;
                case 83:
                    result = "惊雷爆";
                    break;
                case 84:
                    result = "三焰咒";
                    break;
                case 85:
                    result = "横扫千军";
                    break;
                case 86:
                    result = "冰天雪地";
                    break;
                case 87:
                    result = "万剑归宗";
                    break;
            }
            return result;
        }

        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}
