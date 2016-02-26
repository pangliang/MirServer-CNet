using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TATMonster : TMonster
    {
        public TATMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }

        public override void Run()
        {
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000) || (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null)))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();// 搜索目标
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TATMonster.Run");
            }
            base.Run();
        }
    }

   
}
