using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TSpitSpider : TATMonster
    {
        public bool m_boUsePoison = false;

        public TSpitSpider()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_boAnimal = true;
            m_boUsePoison = true;
        }

        private void SpitAttack(byte btDir)
        {
            TAbility WAbil;
            int nC;
            int n10;
            int n14;
            int n18;
            int n1C;
            TBaseObject BaseObject;
            this.m_btDirection = btDir;
            WAbil = this.m_WAbil;
            n1C = HUtil32.Random((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1 + HUtil32.LoWord(WAbil.DC);
            if (n1C <= 0)
            {
                return;
            }
            SendRefMsg(Grobal2.RM_HIT, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            nC = 0;
            while ((nC < 5))
            {
                n10 = 0;
                while ((n10 < 5))
                {
                    if (M2Share.g_Config.SpitMap[btDir, nC, n10] == 1)
                    {
                        n14 = m_nCurrX - 2 + n10;
                        n18 = m_nCurrY - 2 + nC;
                        BaseObject = m_PEnvir.GetMovingObject(n14, n18, true);
                        if ((BaseObject != null) && (BaseObject != this) && (IsProperTarget(BaseObject))
                            && (HUtil32.Random(BaseObject.m_btSpeedPoint) < m_btHitPoint))
                        {
                            n1C = BaseObject.GetMagStruckDamage(this, n1C);
                            if (n1C > 0)
                            {
                                BaseObject.StruckDamage(n1C);
                                BaseObject.SetLastHiter(this);
                                BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, n1C, m_WAbil.HP, m_WAbil.MaxHP, Parse(this), "", 300);
                                if (m_boUsePoison)
                                {
                                    if (HUtil32.Random(m_btAntiPoison + 20) == 0)
                                    {
                                        BaseObject.MakePosion(Grobal2.POISON_DECHEALTH, 30, 1);
                                    }
                                }
                            }
                        }
                    }
                    n10++;
                }
                nC++;
            }
        }

        public override bool AttackTarget()
        {
            bool result = false;
            byte btDir = 0;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (TargetInSpitRange(m_TargetCret, ref btDir))
            {
                if ((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    SpitAttack(btDir);
                    BreakHolySeizeMode();
                }
                result = true;
                return result;
            }
            if (m_TargetCret.m_PEnvir == m_PEnvir)
            {
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                {
                    SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                }
            }
            else
            {
                DelTargetCreat();
            }
            return result;
        }
    }
}
