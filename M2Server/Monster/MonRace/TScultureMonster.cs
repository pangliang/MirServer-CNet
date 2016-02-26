using GameFramework;
using System;
using System.Collections.Generic;

namespace M2Server.Monster
{
    public class TScultureMonster : TMonster
    {
        public TScultureMonster()
            : base()
        {
            base.m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            base.m_nViewRange = 7;
            base.m_boStoneMode = true;
            base.m_nCharStatusEx = Grobal2.STATE_STONE_MODE;
        }

        private void MeltStone()
        {
            m_nCharStatusEx = 0;
            m_nCharStatus = GetCharStatus();
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            m_boStoneMode = false;
        }

        private void MeltStoneAll()
        {
            List<TBaseObject> BaseObjectList;
            TBaseObject BaseObject;
            MeltStone();

            BaseObjectList = GetMapBaseObjects(m_PEnvir, m_nCurrX, m_nCurrY, 7);
            for (int I = 0; I < BaseObjectList.Count; I++)
            {
                BaseObject = BaseObjectList[I];
                if (BaseObject.m_boStoneMode)
                {
                    if (BaseObject is TScultureMonster)
                    {
                        ((BaseObject) as TScultureMonster).MeltStone();
                    }
                }
            }
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boGhost && !m_boDeath && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && ((HUtil32.GetTickCount() - m_dwWalkTick) >= m_nWalkSpeed))
                {
                    if (m_boStoneMode)
                    {
                        nCode = 1;
                        if (m_VisibleActors.Count > 0)
                        {
                            nCode = 2;
                            for (int I = 0; I < m_VisibleActors.Count; I++)
                            {
                                nCode = 3;
                                BaseObject = m_VisibleActors[I].BaseObject;
                                nCode = 4;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                nCode = 5;
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                nCode = 6;
                                if (IsProperTarget(BaseObject))
                                {
                                    nCode = 7;
                                    if (!BaseObject.m_boHideMode || m_boCoolEye)
                                    {
                                        nCode = 8;
                                        if ((Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - BaseObject.m_nCurrY) <= 2))
                                        {
                                            nCode = 9;
                                            MeltStoneAll();
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
                            nCode = 10;
                            m_dwSearchEnemyTick = HUtil32.GetTickCount();
                            SearchTarget();
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TScultureMonster.Run Code:" + (nCode).ToString());
            }
        }
    }
}