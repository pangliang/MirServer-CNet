using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Monster
{
    public class TDualAxeMonster : TMonster
    {
        public int m_nAttackCount = 0;
        public int m_nAttackMax = 0;

        public TDualAxeMonster()
            : base()
        {
            this.m_nViewRange = 5;
            this.m_nRunTime = 250;
            this.m_dwSearchTime = 3000;
            m_nAttackCount = 0;
            m_nAttackMax = 2;
            this.m_dwSearchTick = HUtil32.GetTickCount();
            this.m_btRaceServer = 87;
        }

        private void FlyAxeAttack(TBaseObject Target)
        {
            TAbility WAbil;
            int nDamage;
            if (this.m_PEnvir.CanFly(this.m_nCurrX, this.m_nCurrY, Target.m_nCurrX, Target.m_nCurrY))
            {
                this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, Target.m_nCurrX, Target.m_nCurrY);
                WAbil = this.m_WAbil;
                nDamage = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                if (nDamage > 0)
                {
                    nDamage = Target.GetHitStruckDamage(this, nDamage);
                }
                if (nDamage > 0)
                {
                    Target.StruckDamage(nDamage);
                    Target.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, Target.m_WAbil.HP, Target.m_WAbil.MaxHP, 0, "", (uint)HUtil32._MAX(Math.Abs(this.m_nCurrX - Target.m_nCurrX), Math.Abs(this.m_nCurrY - Target.m_nCurrY)) * 50 + 600);
                }
                this.SendRefMsg(Grobal2.RM_FLYAXE, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
            }
        }

        public override bool AttackTarget()
        {
            bool result = false;
            if (this.m_TargetCret == null)
            {
                return result;
            }
            if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
            {
                this.m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 7) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 7))
                {
                    if ((m_nAttackMax - 1) > m_nAttackCount)
                    {
                        m_nAttackCount++;
                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                        FlyAxeAttack(this.m_TargetCret);
                    }
                    else
                    {
                        if (HUtil32.Random(5) == 0)
                        {
                            m_nAttackCount = 0;
                        }
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
            }
            return result;
        }

        public override void Run()
        {
            int nAbs;
            int nRage = 9999;
            TBaseObject BaseObject;
            TBaseObject TargeTBaseObject = null;
            if (!this.m_boDeath && !this.m_boGhost && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
            {
                if ((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) >= 5000)
                {
                    this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                    if (this.m_VisibleActors.Count > 0)
                    {
                        for (int I = 0; I < this.m_VisibleActors.Count; I++)
                        {
                            BaseObject = this.m_VisibleActors[I].BaseObject;
                            if (BaseObject.m_boDeath)
                            {
                                continue;
                            }
                            if (this.IsProperTarget(BaseObject))
                            {
                                if (!BaseObject.m_boHideMode || this.m_boCoolEye)
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
                    }
                    if (TargeTBaseObject != null)
                    {
                        this.SetTargetCreat(TargeTBaseObject);
                    }
                }
                if (((0 - this.m_dwWalkTick) > this.m_nWalkSpeed) && (this.m_TargetCret != null))
                {
                    if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4))
                    {
                        if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 2))
                        {
                            if (HUtil32.Random(5) == 0)
                            {
                                this.GetBackPosition(ref this.m_nTargetX, ref this.m_nTargetY);
                            }
                        }
                        else
                        {
                            this.GetBackPosition(ref this.m_nTargetX, ref this.m_nTargetY);
                        }
                    }
                }
            }
            base.Run();
        }
    }
}
