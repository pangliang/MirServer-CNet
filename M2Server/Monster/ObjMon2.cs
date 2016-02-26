using System;
using System.Collections;
using GameFramework;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 食人花
    /// </summary>
    public class TStickMonster : TAnimalObject
    {
        public bool bo550 = false;
        public int n554 = 0;
        public int n558 = 0;

        public TStickMonster()
            : base()
        {
            bo550 = false;
            this.m_nViewRange = 7;
            this.m_nRunTime = 250;
            this.m_dwSearchTime = (uint)HUtil32.Random(1500) + 2500;
            this.m_dwSearchTick = HUtil32.GetTickCount();
            this.m_btRaceServer = 85;
            n554 = 4;
            n558 = 4;
            this.m_boFixedHideMode = true;
            this.m_boStickMode = true;
            this.m_boAnimal = true;//是否是动物
        }

        public virtual bool AttackTarget()
        {
            bool result;
            byte btDir = 0;
            result = false;
            if (this.m_TargetCret == null)
            {
                return result;
            }
            if (this.GetAttackDir(this.m_TargetCret, ref btDir))
            {
                if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                    this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                    this.Attack(this.m_TargetCret, btDir);
                }
                result = true;
                return result;
            }
            if (this.m_TargetCret.m_PEnvir == this.m_PEnvir)
            {
                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 11))
                {
                    this.SetTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                }
            }
            else
            {
                this.DelTargetCreat();
            }
            return result;
        }

        public virtual void sub_FFE9()
        {
            this.m_boFixedHideMode = false;
            this.SendRefMsg(Grobal2.RM_DIGUP, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
        }

        public virtual void VisbleActors()
        {
            const string sExceptionMsg = "{异常} TStickMonster::VisbleActors Dispose";
            this.SendRefMsg(Grobal2.RM_DIGDOWN, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
            try
            {
                if (this.m_VisibleActors.Count > 0)
                {
                    for (int I = 0; I < this.m_VisibleActors.Count; I++)
                    {
                        Dispose((this.m_VisibleActors[I]));
                    }
                }
                this.m_VisibleActors.Clear();
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            this.m_boFixedHideMode = true;
        }

        public virtual void sub_FFEA()
        {
            TBaseObject BaseObject;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject == null)
                    {
                        continue;
                    }
                    if (BaseObject.m_boDeath)
                    {
                        continue;
                    }
                    if (this.IsProperTarget(BaseObject))
                    {
                        if (!BaseObject.m_boHideMode || this.m_boCoolEye)
                        {
                            if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) < n554) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) < n554))
                            {
                                sub_FFE9();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            return base.Operate(ProcessMsg);
        }

        public override void Run()
        {
            bool bo05;
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (this.m_boFixedHideMode)
                        {
                            sub_FFEA();
                        }
                        else
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
                            {
                                this.SearchTarget();
                            }
                            bo05 = false;
                            if (this.m_TargetCret != null)
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > n558) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > n558))
                                {
                                    bo05 = true;
                                }
                            }
                            else
                            {
                                bo05 = true;
                            }
                            if (bo05)
                            {
                                VisbleActors();
                            }
                            else
                            {
                                if (AttackTarget())
                                {
                                    base.Run();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TStickMonster.Run");
            }
            base.Run();
        }
    }

    public class TBeeQueen : TAnimalObject
    {
        // 没有此类怪
        public ArrayList BBList = null;
        public TBeeQueen()
            : base()
        {
            this.m_nViewRange = 9;
            this.m_nRunTime = 250;
            this.m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 2500);
            this.m_dwSearchTick = HUtil32.GetTickCount();
            this.m_boStickMode = true;
            BBList = new ArrayList();
        }

        ~TBeeQueen()
        {
            Dispose(BBList);
        }

        private void MakeChildBee()
        {
            if (BBList.Count >= 15)
            {
                return;
            }
            this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
            this.SendDelayMsg(this, Grobal2.RM_ZEN_BEE, 0, 0, 0, 0, "", 500);
        }

        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = true;
            TBaseObject BB;
            try
            {
                if (ProcessMsg.wIdent == Grobal2.RM_ZEN_BEE)
                {
                    BB = UserEngine.RegenMonsterByName(this.m_PEnvir.sMapName, this.m_nCurrX, this.m_nCurrY, M2Share.g_Config.sBee);
                    if (BB != null)
                    {
                        BB.SetTargetCreat(this.m_TargetCret);
                        BBList.Add(BB);
                    }
                }
                result = base.Operate(ProcessMsg);
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TBeeQueen.Operate");
            }
            return result;
        }

        public override void Run()
        {
            TBaseObject BB;
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) // 5
                {
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) >= this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if ((HUtil32.GetTickCount() - this.m_dwHitTick) >= this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            this.SearchTarget();
                            if (this.m_TargetCret != null)
                            {
                                MakeChildBee();
                            }
                        }
                        for (int I = BBList.Count - 1; I >= 0; I--)
                        {
                            if (BBList.Count <= 0)
                            {
                                break;
                            }
                            BB = ((TBaseObject)(BBList[I]));
                            if ((BB != null))
                            {
                                if ((BB.m_boDeath) || (BB.m_boGhost))
                                {
                                    BBList.RemoveAt(I);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TBeeQueen.Run");
            }
            base.Run();
        }
    }

    /// <summary>
    /// 触龙神
    /// </summary>
    public class TCentipedeKingMonster : TStickMonster
    {
        // 触龙神  不能动的怪物，目标走近，从地上冒出，攻击目标，目标走后，会自己回到地下
        public uint m_dwAttickTick = 0;
        public TCentipedeKingMonster()
            : base()
        {
            this.m_nViewRange = 6;
            this.n554 = 4;
            this.n558 = 6;
            this.m_boAnimal = false;

            m_dwAttickTick = HUtil32.GetTickCount();
        }

        private bool sub_4A5B0C()
        {
            bool result;
            TBaseObject BaseObject;
            result = false;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject == null)
                    {
                        continue;
                    }
                    if (BaseObject.m_boDeath)
                    {
                        continue;
                    }
                    if (this.IsProperTarget(BaseObject))
                    {
                        if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) <= this.m_nViewRange) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) <= this.m_nViewRange))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public override bool AttackTarget()
        {
            bool result;
            TAbility WAbil;
            int nPower;
            TBaseObject BaseObject;
            result = false;
            if (!sub_4A5B0C())
            {
                return result;
            }
            if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
            {
                this.m_dwHitTick = HUtil32.GetTickCount();
                this.SendAttackMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY);
                WAbil = this.m_WAbil;
                nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                if (this.m_VisibleActors.Count > 0)
                {
                    for (int I = 0; I < this.m_VisibleActors.Count; I++)
                    {
                        BaseObject = this.m_VisibleActors[I].BaseObject;
                        if (BaseObject == null)
                        {
                            continue;
                        }
                        if (BaseObject.m_boDeath)
                        {
                            continue;
                        }
                        if (this.IsProperTarget(BaseObject))
                        {
                            if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) < this.m_nViewRange) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) < this.m_nViewRange))
                            {
                                this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                this.SendDelayMsg(this, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(BaseObject.m_nCurrX, BaseObject.m_nCurrY), 2, 0, "", 600);
                                if (HUtil32.Random(4) == 0)
                                {
                                    if (HUtil32.Random(3) != 0)
                                    {
                                        BaseObject.MakePosion(Grobal2.POISON_DECHEALTH, 60, 3);
                                    }
                                    else
                                    {
                                        BaseObject.MakePosion(Grobal2.POISON_STONE, 5, 0);
                                    }
                                    this.m_TargetCret = BaseObject;
                                }
                            }
                        }
                    }
                }
            }
            result = true;
            return result;
        }

        public  override void sub_FFE9()
        {
            base.sub_FFE9();
            this.m_WAbil.HP = this.m_WAbil.MaxHP;
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (this.m_boFixedHideMode)
                        {
                            if ((HUtil32.GetTickCount() - m_dwAttickTick) > 10000)
                            {
                                if (this.m_VisibleActors.Count > 0)
                                {
                                    for (int I = 0; I < this.m_VisibleActors.Count; I++)
                                    {
                                        BaseObject = this.m_VisibleActors[I].BaseObject;
                                        if (BaseObject == null)
                                        {
                                            continue;
                                        }
                                        if (BaseObject.m_boDeath)
                                        {
                                            continue;
                                        }
                                        if (this.IsProperTarget(BaseObject))
                                        {
                                            if (!BaseObject.m_boHideMode || this.m_boCoolEye)
                                            {
                                                if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) < this.n554) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) < this.n554))
                                                {
                                                    sub_FFE9();
                                                    m_dwAttickTick = HUtil32.GetTickCount();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if ((HUtil32.GetTickCount() - m_dwAttickTick) > 3000)
                            {
                                if (AttackTarget())
                                {
                                    base.Run();
                                    return;
                                }
                                if ((HUtil32.GetTickCount() - m_dwAttickTick) > 10000)
                                {
                                    this.VisbleActors();
                                    m_dwAttickTick = HUtil32.GetTickCount();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCentipedeKingMonster.Run");
            }
            base.Run();
        }
    }

    public class TBigHeartMonster : TAnimalObject
    {
        public TBigHeartMonster()
            : base()
        {
            this.m_nViewRange = 16;
            this.m_boAnimal = false;
        }

        public virtual bool AttackTarget()
        {
            bool result;
            TBaseObject BaseObject;
            int nPower;
            TAbility WAbil;
            result = false;
            if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
            {
                this.m_dwHitTick = HUtil32.GetTickCount();
                this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                WAbil = this.m_WAbil;
                nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                if (this.m_VisibleActors.Count > 0)
                {
                    for (int I = 0; I < this.m_VisibleActors.Count; I++)
                    {
                        BaseObject = this.m_VisibleActors[I].BaseObject;
                        if (BaseObject == null)
                        {
                            continue;
                        }
                        if (BaseObject.m_boDeath)
                        {
                            continue;
                        }
                        if (this.IsProperTarget(BaseObject))
                        {
                            if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) <= this.m_nViewRange) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) <= this.m_nViewRange))
                            {
                                this.SendDelayMsg(this, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(BaseObject.m_nCurrX, BaseObject.m_nCurrY), 1, 0, "", 200);
                                this.SendRefMsg(Grobal2.RM_10205, 0, BaseObject.m_nCurrX, BaseObject.m_nCurrY, 1, "");
                            }
                        }
                    }
                }
                result = true;
            }
            return result;
        }

        public override void Run()
        {
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (this.m_VisibleActors != null)
                    {
                        if (this.m_VisibleActors.Count > 0)
                        {
                            AttackTarget();
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TBigHeartMonster.Run");
            }
        }
    }

    public class TSpiderHouseMonster : TAnimalObject
    {
        // 属于可以 怪生怪的 怪
        public ArrayList BBList = null;
        public TSpiderHouseMonster()
            : base()
        {
            this.m_nViewRange = 9;
            this.m_nRunTime = 250;
            this.m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 2500);
            this.m_dwSearchTick = 0;
            this.m_boStickMode = true;
            BBList = new ArrayList();
        }

        ~TSpiderHouseMonster()
        {
            Dispose(BBList);
        }

        private void GenBB()
        {
            if (BBList.Count < 15)
            {
                this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                this.SendDelayMsg(this, Grobal2.RM_ZEN_BEE, 0, 0, 0, 0, "", 500);
            }
        }

        public override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            TBaseObject BB;
            int n08;
            int n0C;
            try
            {
                if (ProcessMsg.wIdent == Grobal2.RM_ZEN_BEE)
                {
                    n08 = this.m_nCurrX;
                    n0C = this.m_nCurrY + 1;
                    if (this.m_PEnvir.CanWalk(n08, n0C, true))
                    {
                        BB = UserEngine.RegenMonsterByName(this.m_PEnvir.sMapName, n08, n0C, M2Share.g_Config.sSpider);
                        if (BB != null)
                        {
                            BB.SetTargetCreat(this.m_TargetCret);
                            BBList.Add(BB);
                        }
                    }
                }
                result = base.Operate(ProcessMsg);
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSpiderHouseMonster.Operate");
            }
            return result;
        }

        public override void Run()
        {
            TBaseObject BB;
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))// 5
                {
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) >= this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if ((HUtil32.GetTickCount() - this.m_dwHitTick) >= this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            this.SearchTarget();
                            if (this.m_TargetCret != null)
                            {
                                GenBB();
                            }
                        }
                        for (int I = BBList.Count - 1; I >= 0; I--)
                        {
                            if (BBList.Count <= 0)
                            {
                                break;
                            }
                            BB = ((TBaseObject)(BBList[I]));
                            if (BB != null)
                            {
                                if (BB.m_boDeath || (BB.m_boGhost))
                                {
                                    BBList.RemoveAt(I);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSpiderHouseMonster.Run");
            }
            base.Run();
        }

    }

    /// <summary>
    /// 幻影蜘蛛
    /// </summary>
    public class TExplosionSpider : TMonster
    {
        public uint dw558 = 0;

        public TExplosionSpider()
            : base()
        {
            this.m_nViewRange = 5;
            this.m_nRunTime = 250;
            this.m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 2500);
            this.m_dwSearchTick = 0;
            dw558 = HUtil32.GetTickCount();
        }

        private void sub_4A65C4()
        {
            TAbility WAbil;
            int nPower;
            int n10;
            TBaseObject BaseObject;
            this.m_WAbil.HP = 0;
            WAbil = this.m_WAbil;
            nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject == null)
                    {
                        continue;
                    }
                    if (BaseObject.m_boDeath)
                    {
                        continue;
                    }
                    if (this.IsProperTarget(BaseObject))
                    {
                        if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) <= 1) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) <= 1))
                        {
                            n10 = 0;
                            n10 += BaseObject.GetHitStruckDamage(this, nPower / 2);
                            n10 += BaseObject.GetMagStruckDamage(this, nPower / 2);
                            if (n10 > 0)
                            {
                                BaseObject.StruckDamage(n10);
                                BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, n10, BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, Parse(this), "", 700);
                            }
                        }
                    }
                }
            }
        }

        public override bool AttackTarget()
        {
            bool result = false;
            byte btDir = 0;
            if (this.m_TargetCret == null)
            {
                return result;
            }
            if (this.GetAttackDir(this.m_TargetCret, ref btDir))
            {
                if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                    this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                    sub_4A65C4();
                }
                result = true;
            }
            else
            {
                if (this.m_TargetCret.m_PEnvir == this.m_PEnvir)
                {
                    if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 11) &&
                        (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 11))
                    {
                        this.SetTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    this.DelTargetCreat();
                }
            }
            return result;
        }

        public override void Run()
        {
            try
            {
                if (!this.m_boDeath && !this.m_boGhost)
                {
                    if ((HUtil32.GetTickCount() - dw558) > 60000)// 60 * 1000
                    {
                        dw558 = HUtil32.GetTickCount();
                        sub_4A65C4();
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TExplosionSpider.Run");
            }
            base.Run();
        }
    }

    /// <summary>
    /// 守卫
    /// </summary>
    public class TGuardUnit : TAnimalObject
    {
        public uint dw54C = 0;
        public int m_nX550 = 0;
        public int m_nY554 = 0;
        public int m_nDirection = 0;

        public override void Struck(TBaseObject hiter)
        {
            base.Struck(hiter);
            if (this.m_Castle != null)
            {
                this.bo2B0 = true;
                this.m_dw2B4Tick = HUtil32.GetTickCount();
            }
        }

        /// <summary>
        /// 是适当的目标
        /// 即可以攻击的目标
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public override bool IsProperTarget(TBaseObject BaseObject)
        {
            bool result;
            result = false;
            if (this.m_Castle != null)
            {
                if (this.m_LastHiter == BaseObject)
                {
                    result = true;
                }
                if ((BaseObject != null) && (BaseObject.bo2B0))
                {
                    if ((HUtil32.GetTickCount() - BaseObject.m_dw2B4Tick) < 120000) // 2 * 60 * 1000
                    {
                        result = true;
                    }
                    else
                    {
                        BaseObject.bo2B0 = false;
                    }
                    if (BaseObject.m_Castle != null)
                    {
                        BaseObject.bo2B0 = false;
                        result = false;
                    }
                }
                if (this.m_Castle.m_boUnderWar)
                {
                    result = true;
                }
                if (this.m_Castle.m_MasterGuild != null)
                {
                    if (BaseObject.m_Master == null)
                    {
                        if (this.m_Castle.m_MasterGuild == BaseObject.m_MyGuild
                            || this.m_Castle.m_MasterGuild.IsAllyGuild(BaseObject.m_MyGuild))
                        {
                            if (this.m_LastHiter != BaseObject)
                            {
                                result = false;
                            }
                        }
                    }
                    else
                    {
                        if (this.m_Castle.m_MasterGuild == BaseObject.m_Master.m_MyGuild
                            || this.m_Castle.m_MasterGuild.IsAllyGuild(BaseObject.m_Master.m_MyGuild))
                        {
                            if ((this.m_LastHiter != BaseObject.m_Master) && (this.m_LastHiter != BaseObject))
                            {
                                result = false;
                            }
                        }
                    }
                }
                if ((BaseObject != null) && BaseObject.m_boAdminMode || BaseObject.m_boStoneMode
                    || ((BaseObject.m_btRaceServer >= 10) && (BaseObject.m_btRaceServer < 50)) || (BaseObject == this)
                    || (BaseObject.m_Castle == this.m_Castle))
                {
                    result = false;
                }
                return result;
            }
            if (this.m_LastHiter == BaseObject)
            {
                result = true;
            }
            if ((BaseObject.m_TargetCret != null) && (BaseObject.m_TargetCret.m_btRaceServer == 112))
            {
                result = true;
            }
            if ((BaseObject != null) && (BaseObject.PKLevel() >= 2)) // 红名人物
            {
                result = true;
            }
            if ((BaseObject != null) && BaseObject.m_boAdminMode || BaseObject.m_boStoneMode || (BaseObject == this))
            {
                result = false;
            }
            return result;
        }
    }

    /// <summary>
    /// 弓箭手
    /// </summary>
    public class TArcherGuard : TGuardUnit
    {
        public TArcherGuard()
            : base()
        {
            this.m_nViewRange = 12;// 可视范围
            this.m_boWantRefMsg = true;
            this.m_Castle = null;// 城堡
            this.m_nDirection = -1;// 方向
            this.m_btRaceServer = 112;// 怪类型
        }

        private void sub_4A6B30(TBaseObject TargeTBaseObject)
        {
            int nPower;
            TAbility WAbil;
            if (TargeTBaseObject != null)
            {
                this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
                WAbil = this.m_WAbil;
                nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                if (nPower > 0)
                {
                    nPower = TargeTBaseObject.GetHitStruckDamage(this, nPower);
                }
                if (nPower > 0)
                {
                    TargeTBaseObject.SetLastHiter(this);
                    TargeTBaseObject.m_ExpHitter = null;
                    TargeTBaseObject.StruckDamage(nPower);
                    TargeTBaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nPower, TargeTBaseObject.m_WAbil.HP, TargeTBaseObject.m_WAbil.MaxHP, Parse(this), "", 
                        (uint)HUtil32._MAX(Math.Abs(this.m_nCurrX - TargeTBaseObject.m_nCurrX), Math.Abs(this.m_nCurrY - TargeTBaseObject.m_nCurrY)) * 50 + 600);
                }
                this.SendRefMsg(Grobal2.RM_FLYAXE, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, Parse(TargeTBaseObject), "");
            }
        }

        public override void Run()
        {
            int I;
            int nAbs;
            int nRage;
            TBaseObject BaseObject;
            TBaseObject TargeTBaseObject;// 搜索怪的范围
            try
            {
                nRage = 13;
                TargeTBaseObject = null;
                if (!this.m_boDeath && !this.m_boGhost && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) >= this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (this.m_VisibleActors.Count > 0)
                        {
                            for (I = 0; I < this.m_VisibleActors.Count; I++)
                            {
                                BaseObject = this.m_VisibleActors[I].BaseObject;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                if (this.IsProperTarget(BaseObject))
                                {
                                    nAbs = Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY);
                                    if (nAbs < nRage)
                                    {
                                        nRage = nAbs;
                                        TargeTBaseObject = BaseObject;
                                    }
                                }
                            }
                        }
                        if (TargeTBaseObject != null)
                        {
                            this.SetTargetCreat(TargeTBaseObject);
                        }
                        else
                        {
                            this.DelTargetCreat();
                        }
                    }
                    if (this.m_TargetCret != null)
                    {
                        if ((HUtil32.GetTickCount() - this.m_dwHitTick) >= this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            sub_4A6B30(this.m_TargetCret);
                        }
                    }
                    else
                    {
                        if ((this.m_nDirection >= 0) && (this.m_btDirection != this.m_nDirection))
                        {
                            this.TurnTo(this.m_nDirection);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TArcherGuard.Run");
            }
            base.Run();
        }
    }

    /// <summary>
    /// 类似弓箭手的怪,只打怪物
    /// </summary>
    public class TArcherGuardMon : TGuardUnit
    {
        public TArcherGuardMon()
            : base()
        {
            this.m_boWantRefMsg = true;
            this.m_Castle = null;// 城堡
            this.m_nDirection = -1;// 方向
            this.m_btRaceServer = 135;// 怪类型
            this.m_dwSearchTime = (uint)HUtil32.Random(1500) + 1500;// 搜索目标的时间
        }

        private void sub_4A6B30(TBaseObject TargeTBaseObject)
        {
            int nPower;
            TAbility WAbil;
            bool spell;
            if (TargeTBaseObject != null)
            {
                spell = false;

                if (HUtil32.rangeInDefined(TargeTBaseObject.m_btRaceServer, 11, 65) || HUtil32.rangeInDefined(TargeTBaseObject.m_btRaceServer, 67, 99))
                {
                    spell = true;
                }
                else if (HUtil32.rangeInDefined(TargeTBaseObject.m_btRaceServer, 101, 107) || HUtil32.rangeInDefined(TargeTBaseObject.m_btRaceServer, 110, 111))
                {
                    spell = true;
                }
                else if (HUtil32.rangeInDefined(TargeTBaseObject.m_btRaceServer, 115, 120))
                {
                    spell = true;
                }
                switch (TargeTBaseObject.m_btRaceServer)
                {
                    case 136:
                    case 150:
                        spell = true;
                        break;
                }
                if (spell)
                {
                    this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
                    WAbil = this.m_WAbil;
                    nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                    if (nPower > 0)
                    {
                        nPower = TargeTBaseObject.GetHitStruckDamage(this, nPower);
                    }
                    if (nPower > 0)
                    {
                        TargeTBaseObject.SetLastHiter(this);
                        TargeTBaseObject.m_ExpHitter = null;
                        TargeTBaseObject.StruckDamage(nPower);
                        TargeTBaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nPower, TargeTBaseObject.m_WAbil.HP, TargeTBaseObject.m_WAbil.MaxHP, Parse(this),
                            "", (uint)HUtil32._MAX(Math.Abs(this.m_nCurrX - TargeTBaseObject.m_nCurrX), Math.Abs(this.m_nCurrY - TargeTBaseObject.m_nCurrY)) * 50 + 600);
                    }
                    this.SendRefMsg(Grobal2.RM_FLYAXE, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                }
            }
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            TBaseObject TargeTBaseObject;
            bool spell;
            try
            {
                spell = false;
                TargeTBaseObject = null;
                if ((this.m_Master == null) || ((this.m_Master.m_sMapName).ToLower().CompareTo((this.m_sMapName).ToLower()) != 0))
                {
                    this.m_boDeath = true;// 主人不存在或与主人不在同一地图将自动消失
                }
                if (!this.m_boDeath && !this.m_boGhost && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) >= this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (this.m_TargetCret == null)
                        {
                            if (this.m_VisibleActors.Count > 0)
                            {
                                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                                {
                                    BaseObject = this.m_VisibleActors[I].BaseObject;
                                    if (BaseObject == null)
                                    {
                                        continue;
                                    }
                                    if (BaseObject.m_boDeath)
                                    {
                                        continue;
                                    }
                                    if (HUtil32.rangeInDefined(BaseObject.m_btRaceServer, 11, 65) || HUtil32.rangeInDefined(BaseObject.m_btRaceServer, 67, 99))
                                    {
                                        spell = true;
                                    }
                                    else if (HUtil32.rangeInDefined(BaseObject.m_btRaceServer, 101, 107) || HUtil32.rangeInDefined(BaseObject.m_btRaceServer, 110, 111))
                                    {
                                        spell = true;
                                    }
                                    else if (HUtil32.rangeInDefined(BaseObject.m_btRaceServer, 115, 120))
                                    {
                                        spell = true;
                                    }
                                    switch (BaseObject.m_btRaceServer)
                                    {
                                        case 136:
                                        case 150:
                                            spell = true;// 在可视范围,则攻击怪物目标
                                            break;
                                    }
                                    if (spell) // 怪的可视范围
                                    {
                                        if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) <= this.m_btCoolEye) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) <= this.m_btCoolEye))
                                        {
                                            TargeTBaseObject = BaseObject;// 设置为攻击目标
                                            this.SetTargetCreat(TargeTBaseObject);
                                            if (this.m_TargetCret != null)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (TargeTBaseObject != null)
                        {
                            this.SetTargetCreat(TargeTBaseObject);
                        }
                        else
                        {
                            this.DelTargetCreat();
                        }
                    }
                    if (this.m_TargetCret != null)
                    {
                        if ((HUtil32.GetTickCount() - this.m_dwHitTick) >= this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            sub_4A6B30(this.m_TargetCret);
                        }
                    }
                    else
                    {
                        if ((this.m_nDirection >= 0) && (this.m_btDirection != this.m_nDirection))
                        {
                            this.TurnTo(this.m_nDirection);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TArcherGuardMon.Run");
            }
            base.Run();
        }
    }

    public class TArcherGuardMon1 : TAnimalObject
    {
        // 136怪,不会攻击,不会移动
        public int m_NewCurrX = 0;
        public int m_NewCurrY = 0;
        public bool m_boWalk = false;

        public TArcherGuardMon1()
            : base()
        {
            this.m_Castle = null;// 城堡
            this.m_btRaceServer = 136;// 怪类型
            m_boWalk = false;
        }

        private bool WalkToTargetXY(int nTargetX, int nTargetY)
        {
            bool result = false;
            int nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            if ((nTargetX != this.m_nCurrX) || (nTargetY != this.m_nCurrY))
            {
                n10 = nTargetX;
                n14 = nTargetY;

                this.dwTick3F4 = HUtil32.GetTickCount();
                nOldX = this.m_nCurrX;
                nOldY = this.m_nCurrY;
                nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, n10, n14);
                byte by = 0;
                this.WalkTo((byte)by, false);
                if ((nTargetX == this.m_nCurrX) && (nTargetY == this.m_nCurrY))
                {
                    result = true;
                }
                if (!result)
                {
                    n20 = HUtil32.Random(3);
                    for (int I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                    {
                        if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                        {
                            if (n20 != 0)
                            {
                                nDir++;
                            }
                            if ((nDir > Grobal2.DR_UPLEFT))
                            {
                                nDir = Grobal2.DR_UP;
                            }
                            this.WalkTo(by, false);
                            if ((nTargetX == this.m_nCurrX) && (nTargetY == this.m_nCurrY))
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public override void Run()
        {
            try
            {
                if (!this.m_boDeath && !this.m_boGhost && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed) && m_boWalk)// 走动
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (WalkToTargetXY(m_NewCurrX, m_NewCurrY))
                        {
                            this.MakeGhost();//到指定XY后,直接清除怪物
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TArcherGuardMon1.Run");
            }
            base.Run();
        }
    }

    public class TArcherPolice : TArcherGuard
    {
        public TArcherPolice()
            : base()
        {
            this.m_btRaceServer = 20;
        }
    }

    /// <summary>
    /// 沙巴克城门
    /// </summary>
    public class TCastleDoor : TGuardUnit
    {
        public uint dw55C = 0;
        public uint dw560 = 0;
        /// <summary>
        /// 是否打开
        /// </summary>
        public bool m_boOpened = false;
        public bool bo565n = false;
        public bool bo566n = false;
        public bool bo567n = false;

        public TCastleDoor()
            : base()
        {
            this.m_boAnimal = false;
            this.m_boStickMode = true;
            this.m_boOpened = false;
            this.m_btAntiPoison = 200;
        }

        private void SetMapXYFlag(int nFlag)
        {
            bool bo06;
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX, this.m_nCurrY - 2, true);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX + 1, this.m_nCurrY - 1, true);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX + 1, this.m_nCurrY - 2, true);
            if (nFlag == 1)
            {
                bo06 = false;
            }
            else
            {
                bo06 = true;
            }
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX, this.m_nCurrY, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX, this.m_nCurrY - 1, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX, this.m_nCurrY - 2, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX + 1, this.m_nCurrY - 1, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX + 1, this.m_nCurrY - 2, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX - 1, this.m_nCurrY, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX - 2, this.m_nCurrY, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX - 1, this.m_nCurrY - 1, bo06);
            this.m_PEnvir.SetMapXYFlag(this.m_nCurrX - 1, this.m_nCurrY + 1, bo06);
            if (nFlag == 0)
            {
                this.m_PEnvir.SetMapXYFlag(this.m_nCurrX, this.m_nCurrY - 2, false);
                this.m_PEnvir.SetMapXYFlag(this.m_nCurrX + 1, this.m_nCurrY - 1, false);
                this.m_PEnvir.SetMapXYFlag(this.m_nCurrX + 1, this.m_nCurrY - 2, false);
            }
        }

        public void Open()
        {
            if (this.m_boDeath)
            {
                return;
            }
            this.m_btDirection = 7;
            this.SendRefMsg(Grobal2.RM_DIGUP, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
            m_boOpened = true;
            this.m_boStoneMode = true;
            SetMapXYFlag(0);
            this.bo2B9 = false;
        }

        public  void Close()
        {
            if (this.m_boDeath)
            {
                return;
            }
            this.m_btDirection = (byte)(3 - HUtil32.Round(this.m_WAbil.HP / this.m_WAbil.MaxHP * 3.0));
            if ((this.m_btDirection - 3) >= 0)
            {
                this.m_btDirection = 0;
            }
            this.SendRefMsg(Grobal2.RM_DIGDOWN, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
            m_boOpened = false;
            this.m_boStoneMode = false;
            SetMapXYFlag(1);
            this.bo2B9 = true;
        }

        public override void Die()
        {
            base.Die();
            dw560 = HUtil32.GetTickCount();
            SetMapXYFlag(2);
        }

        public  override void Run()
        {
            int n08;
            try
            {
                if (this.m_boDeath && (this.m_Castle != null))
                {

                    this.m_dwDeathTick = HUtil32.GetTickCount();
                }
                else
                {
                    this.m_nHealthTick = 0;
                }
                if (!m_boOpened)
                {
                    n08 = (byte)(3 - HUtil32.Round(this.m_WAbil.HP / this.m_WAbil.MaxHP * 3.0));
                    if ((this.m_btDirection != n08) && (n08 < 3))
                    {
                        this.m_btDirection = (byte)n08;
                        this.SendRefMsg(Grobal2.RM_TURN, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCastleDoor.Run");
            }
            base.Run();
        }

        public  void RefStatus()
        {
            int n08;
            n08 = (byte)(3 - HUtil32.Round(this.m_WAbil.HP / this.m_WAbil.MaxHP * 3.0));
            if ((n08 - 3) >= 0)
            {
                n08 = 0;
            }
            this.m_btDirection = (byte)n08;
            this.SendRefMsg(Grobal2.RM_ALIVE, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
        }

        public override void Initialize()
        {
            base.Initialize();
        }
    }

    /// <summary>
    /// 沙巴克城墙
    /// </summary>
    public class TWallStructure : TGuardUnit
    {
        public int n55C = 0;
        public uint dw560 = 0;
        public bool boSetMapFlaged = false;

        public TWallStructure()
            : base()
        {
            this.m_boAnimal = false;
            this.m_boStickMode = true;// 不能冲撞模式(即敌人不能使用野蛮冲撞技能攻击)
            this.boSetMapFlaged = false;
            this.m_btAntiPoison = 200;// 中毒躲避
        }

        public override void Initialize()
        {
            this.m_btDirection = 0;
            base.Initialize();
        }

        public  void RefStatus()
        {
            int n08;
            if (this.m_WAbil.HP > 0)
            {
                n08 = (byte)(3 - HUtil32.Round(this.m_WAbil.HP / this.m_WAbil.MaxHP * 3.0));
            }
            else
            {
                n08 = 4;
            }
            if (n08 >= 5)
            {
                n08 = 0;
            }
            this.m_btDirection = (byte)n08;
            this.SendRefMsg(Grobal2.RM_ALIVE, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
        }

        public override void Die()
        {
            base.Die();
            dw560 = HUtil32.GetTickCount();
        }

        public  override void Run()
        {
            int n08;
            try
            {
                if (this.m_boDeath)
                {
                    this.m_dwDeathTick = HUtil32.GetTickCount();
                    if (boSetMapFlaged)
                    {
                        this.m_PEnvir.SetMapXYFlag(this.m_nCurrX, this.m_nCurrY, true);
                        boSetMapFlaged = false;
                    }
                }
                else
                {
                    this.m_nHealthTick = 0;
                    if (!boSetMapFlaged)
                    {
                        this.m_PEnvir.SetMapXYFlag(this.m_nCurrX, this.m_nCurrY, false);
                        boSetMapFlaged = true;
                    }
                }
                if (this.m_WAbil.HP > 0)
                {
                    n08 = (byte)(3 - HUtil32.Round(this.m_WAbil.HP / this.m_WAbil.MaxHP * 3.0));
                }
                else
                {
                    n08 = 4;
                }
                if ((this.m_btDirection != n08) && (n08 < 5))
                {
                    this.m_btDirection = (byte)n08;
                    this.SendRefMsg(Grobal2.RM_DIGUP, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TWallStructure.Run");
            }
            base.Run();
        }
    }

    public class TSoccerBall : TAnimalObject
    {
        // 飞火流星
        public int n548 = 0;
        public int n550 = 0;

        public TSoccerBall()
            : base()
        {
            this.m_boAnimal = false;
            this.m_boSuperMan = true;
            n550 = 0;
            this.m_nTargetX = -1;
        }

        public override void Run()
        {
            int n08 = 0;
            int n0C = 0;
            bool bo0D = true;
            try
            {
                if (n550 > 0)
                {
                    if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 1, ref n08, ref n0C))
                    {
                        if (this.m_PEnvir.CanWalk(n08, n0C, bo0D))
                        {
                            switch (this.m_btDirection)
                            {
                                case 0:
                                    this.m_btDirection = 4;
                                    break;
                                case 1:
                                    this.m_btDirection = 7;
                                    break;
                                case 2:
                                    this.m_btDirection = 6;
                                    break;
                                case 3:
                                    this.m_btDirection = 5;
                                    break;
                                case 4:
                                    this.m_btDirection = 0;
                                    break;
                                case 5:
                                    this.m_btDirection = 3;
                                    break;
                                case 6:
                                    this.m_btDirection = 2;
                                    break;
                                case 7:
                                    this.m_btDirection = 1;
                                    break;
                            }
                            this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, n550, ref this.m_nTargetX, ref this.m_nTargetY);
                        }
                    }
                }
                else
                {
                    this.m_nTargetX = -1;
                }
                if (this.m_nTargetX != -1)
                {
                    this.GotoTargetXY();
                    if ((this.m_nTargetX == this.m_nCurrX) && (this.m_nTargetY == this.m_nCurrY))
                    {
                        n550 = 0;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSoccerBall.Run");
            }
            base.Run();
        }

        public override void Struck(TBaseObject hiter)
        {
            if (hiter == null)
            {
                return;
            }
            this.m_btDirection = hiter.m_btDirection;
            n550 = HUtil32.Random(4) + (n550 + 4);
            n550 = HUtil32._MIN(20, n550);
            this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, n550, ref this.m_nTargetX, ref this.m_nTargetY);
        }
    }

}