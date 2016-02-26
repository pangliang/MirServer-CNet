using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TLightingZombi : TMonster
    {
        public TLightingZombi()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }

        ~TLightingZombi()
        {

        }

        private void LightingAttack(int nDir)
        {
            int nSX = 0;
            int nSY = 0;
            int nTX = 0;
            int nTY = 0;
            int nPwr;
            TAbility WAbil;
            m_btDirection = (byte)nDir;
            SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, Parse(m_TargetCret), "");
            if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, nDir, 1, ref nSX, ref nSY))
            {
                m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, nDir, 9, ref nTX, ref nTY);
                WAbil = m_WAbil;
                nPwr = HUtil32.Random((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1 + HUtil32.LoWord(WAbil.DC);
                MagPassThroughMagic(nSX, nSY, nTX, nTY, nDir, nPwr, nPwr, true, 0);
            }
            BreakHolySeizeMode();
        }

        public override void Run()
        {
            int nAttackDir;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && ((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000))
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();
                    }
                    if (((HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed) && (m_TargetCret != null) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 4))
                    {
                        if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 2)
                            && (HUtil32.Random(3) != 0))
                        {
                            base.Run();
                            return;
                        }
                        GetBackPosition(ref m_nTargetX, ref  m_nTargetY);
                    }
                    if ((m_TargetCret != null))
                    {
                        if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) < 6) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) < 6) && ((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime))
                        {
                            m_dwHitTick = HUtil32.GetTickCount();
                            nAttackDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                            LightingAttack(nAttackDir);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TLightingZombi.Run");
            }
            base.Run();
        }
    }
}
