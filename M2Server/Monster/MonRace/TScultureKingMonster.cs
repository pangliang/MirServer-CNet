using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace M2Server.Monster
{
    public class TScultureKingMonster : TMonster
    {
        public int m_nDangerLevel = 0;
        /// <summary>
        /// 下属列表
        /// </summary>
        public List<TBaseObject> m_SlaveObjectList = null;

        public TScultureKingMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_nViewRange = 8;
            m_boStoneMode = true;
            m_nCharStatusEx = Grobal2.STATE_STONE_MODE;
            m_btDirection = 5;
            m_nDangerLevel = 5;
            m_SlaveObjectList = new List<TBaseObject>();
        }

        ~TScultureKingMonster()
        {
            Dispose(m_SlaveObjectList);
        }

        private void MeltStone()
        {
            m_nCharStatusEx = 0;
            m_nCharStatus = GetCharStatus();
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            m_boStoneMode = false;
            TEvent Event = new TEvent(m_PEnvir, m_nCurrX, m_nCurrY, 6, 300000, true);// 5 * 60 * 1000
            M2Share.g_EventManager.AddEvent(Event);
        }

        /// <summary>
        /// 召唤下属
        /// </summary>
        private void CallSlave()
        {
            int n10 = 0;
            int n14 = 0;
            TBaseObject BaseObject;
            int nC = HUtil32.Random(6) + 6;
            GetFrontPosition(ref n10, ref n14);
            for (int I = 1; I <= nC; I++)
            {
                if (m_SlaveObjectList.Count >= 30)
                {
                    break;
                }
                BaseObject = UserEngine.RegenMonsterByName(m_sMapName, n10, n14, M2Share.g_Config.sZuma[HUtil32.Random(4)]);
                if (BaseObject != null)
                {
                    m_SlaveObjectList.Add(BaseObject);
                }
            }
        }

        public override void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            TAbility WAbil;
            int nPower;
            if (TargeTBaseObject != null)
            {
                WAbil = m_WAbil;
                nPower = GetAttackPower(HUtil32.LoWord(WAbil.DC), ((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)));
                HitMagAttackTarget(TargeTBaseObject, 0, nPower, true);
            }
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            try
            {
                if (!m_boGhost && !m_boDeath && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && ((HUtil32.GetTickCount() - m_dwWalkTick) >= m_nWalkSpeed))
                {
                    if (m_boStoneMode)
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
                                        if ((Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - BaseObject.m_nCurrY) <= 2))
                                        {
                                            MeltStone();
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
                            if ((m_nDangerLevel > m_WAbil.HP / m_WAbil.MaxHP * 5) && (m_nDangerLevel > 0))
                            {
                                m_nDangerLevel -= 1;
                                CallSlave();
                            }
                            if (m_WAbil.HP == m_WAbil.MaxHP)
                            {
                                m_nDangerLevel = 5;
                            }
                        }
                    }
                    foreach (var item in m_SlaveObjectList)
                    {
                        if (item != null)
                        {
                            if (item.m_boDeath || item.m_boGhost)
                            {
                                m_SlaveObjectList.Remove(item);
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TScultureKingMonster.Run");
            }
            base.Run();
        }
    }
}
