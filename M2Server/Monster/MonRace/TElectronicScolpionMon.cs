using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TElectronicScolpionMon : TMonster
    {
        private bool m_boUseMagic = false;

        public TElectronicScolpionMon()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_boUseMagic = false;
        }

        ~TElectronicScolpionMon()
        {

        }

        private void LightingAttack(int nDir)
        {
            TAbility WAbil;
            int nPower;
            int nDamage;
            int btGetBackHP;
            if (m_TargetCret != null)
            {
                m_btDirection = (byte)nDir;
                WAbil = m_WAbil;
                nPower = GetAttackPower(HUtil32.LoWord(WAbil.MC), ((short)HUtil32.HiWord(WAbil.MC) - HUtil32.LoWord(WAbil.MC)));
                nDamage = m_TargetCret.GetMagStruckDamage(this, nPower);
                if (nDamage > 0)
                {
                    btGetBackHP = (byte)m_WAbil.MP;
                    if (btGetBackHP != 0)
                    {
                        m_WAbil.HP += nDamage / btGetBackHP;
                    }
                    m_TargetCret.StruckDamage(nDamage);
                    m_TargetCret.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, m_TargetCret.m_WAbil.HP, m_TargetCret.m_WAbil.MaxHP, Parse(this), "", 200);
                }
                SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, Parse(m_TargetCret), "");
            }
        }

        public override void Run()
        {
            int nAttackDir;
            int nX;
            int nY;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    // 血量低于一半时开始用魔法攻击
                    if (m_WAbil.HP < m_WAbil.MaxHP / 2)
                    {
                        m_boUseMagic = true;
                    }
                    else
                    {
                        m_boUseMagic = false;
                    }
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();
                    }
                    if (m_TargetCret == null)
                    {
                        return;
                    }
                    nX = Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX);
                    nY = Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY);
                    if ((nX <= 2) && (nY <= 2))
                    {
                        if (m_boUseMagic || ((nX == 2) || (nY == 2)))
                        {
                            if (((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime))
                            {
                                m_dwHitTick = HUtil32.GetTickCount();
                                nAttackDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                                LightingAttack(nAttackDir);
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TElectronicScolpionMon.Run");
            }
            base.Run();
        }

    }

}
