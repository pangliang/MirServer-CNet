using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TDigOutZombi : TMonster
    {
        public TDigOutZombi()
            : base()
        {
            m_nViewRange = 7;
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 2500);
            m_dwSearchTick = HUtil32.GetTickCount();
            m_btRaceServer = 95;
            m_boFixedHideMode = true;
        }

        private void sub_4AA8DC()
        {
            TEvent Event;
            Event = new TEvent(m_PEnvir, m_nCurrX, m_nCurrY, 1, 300000, true);// 5 * 60 * 1000
            M2Share.g_EventManager.AddEvent(Event);
            m_boFixedHideMode = false;
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, Parse(Event), "");
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            try
            {
                if (!m_boGhost && !m_boDeath && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && ((HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed))
                {
                    if (m_boFixedHideMode)
                    {
                        if (m_VisibleActors.Count > 0)
                        {
                            for (int I = 0; I < m_VisibleActors.Count; I++)
                            {
                                BaseObject = m_VisibleActors[I].BaseObject;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                if (IsProperTarget(BaseObject))
                                {
                                    if (!BaseObject.m_boHideMode || m_boCoolEye)
                                    {
                                        if ((Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 3) && (Math.Abs(m_nCurrY - BaseObject.m_nCurrY) <= 3))
                                        {
                                            sub_4AA8DC();
                                            m_dwWalkTick = HUtil32.GetTickCount() + 1000;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000) || (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null)))
                        {
                            m_dwSearchEnemyTick = HUtil32.GetTickCount();
                            SearchTarget();
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TDigOutZombi.Run");
            }
            base.Run();
        }
    }
}
