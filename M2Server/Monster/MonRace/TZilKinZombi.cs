using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TZilKinZombi : TATMonster
    {
        public uint dw558 = 0;
        public int nZilKillCount = 0;
        public uint dw560 = 0;

        public TZilKinZombi()
            : base()
        {
            m_nViewRange = 6;
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 2500);
            m_dwSearchTick = HUtil32.GetTickCount();
            m_btRaceServer = 96;
            nZilKillCount = 0;
            if (HUtil32.Random(3) == 0)
            {
                nZilKillCount = HUtil32.Random(3) + 1;
            }
        }

        public override void Die()
        {
            base.Die();
            if (nZilKillCount > 0)
            {
                dw558 = HUtil32.GetTickCount();
                dw560 = Convert.ToUInt32(HUtil32.Random(20) + 4 * 1000);
            }
            nZilKillCount -= 1;
        }

        public override void Run()
        {
            try
            {
                if (m_boDeath && !m_boGhost && (nZilKillCount >= 0) && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)
                    && (m_VisibleActors.Count > 0) && ((HUtil32.GetTickCount() - dw558) >= dw560))
                {
                    m_Abil.MaxHP = m_Abil.MaxHP >> 1;
                    m_dwFightExp = m_dwFightExp / 2;
                    m_Abil.HP = m_Abil.MaxHP;
                    m_WAbil.HP = m_Abil.MaxHP;
                    ReAlive();
                    m_dwWalkTick = HUtil32.GetTickCount() + 1000;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TZilKinZombi.Run");
            }
            base.Run();
        }
    }
}
