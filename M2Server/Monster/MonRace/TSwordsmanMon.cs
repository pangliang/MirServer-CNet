using GameFramework;
using System;

namespace M2Server.Monster
{
    /// <summary>
    /// 灵魂收割者,蓝影刀客 2格内可以攻击的怪
    /// </summary>
    public class TSwordsmanMon : TATMonster
    {
        public TSwordsmanMon()
            : base()
        {
            m_nViewRange = 8;
        }

        public override bool AttackTarget()
        {
            bool result = false;
            int nPower;
            if (m_TargetCret == null)
            {
                return result;
            }
            if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2))// 2格内物理攻击
            {
                if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC)
                        - HUtil32.LoWord(m_WAbil.DC)));
                    HitMagAttackTarget(m_TargetCret, nPower / 2, nPower / 2, true);
                    result = true;
                    return result;
                }
            }
            else
            {
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
            }
            return result;
        }

        public override void Run()
        {
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCode = 1;
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        nCode = 2;
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();// 搜索可攻击目标
                    }
                    nCode = 3;
                    if ((HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed)
                    {
                        m_dwWalkTick = HUtil32.GetTickCount();
                        if (!m_boNoAttackMode)
                        {
                            nCode = 4;
                            if (m_TargetCret != null)
                            {
                                nCode = 5;
                                if (AttackTarget())
                                {
                                    base.Run();
                                    return;
                                }
                                nCode = 6;
                                if (m_TargetCret != null)
                                {
                                    nCode = 61;
                                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) > 2) ||
                                        (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) > 2))
                                    {
                                        // 目标离远了,走向目标
                                        nCode = 62;
                                        m_nTargetX = m_TargetCret.m_nCurrX;
                                        m_nTargetY = m_TargetCret.m_nCurrY;
                                        this.GotoTargetXY();
                                        base.Run();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                m_nTargetX = -1;
                                if (m_boMission)
                                {
                                    m_nTargetX = m_nMissionX;
                                    m_nTargetY = m_nMissionY;
                                }
                            }
                        }
                        nCode = 7;
                        if (m_nTargetX != -1)
                        {
                            if ((m_TargetCret != null))
                            {
                                if ((Math.Abs(m_nCurrX - m_nTargetX) > 2) || (Math.Abs(m_nCurrY - m_nTargetY) > 2))
                                {
                                    nCode = 8;
                                    this.GotoTargetXY();
                                }
                            }
                            else
                            {
                                this.GotoTargetXY();
                            }
                        }
                        else
                        {
                            nCode = 9;
                            if ((m_TargetCret == null))
                            {
                                Wondering();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSwordsmanMon.Run Code:" + nCode);
            }
            base.Run();
        }
    }
}
