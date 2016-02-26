using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameFramework;
using M2Server.Monster;

namespace M2Server
{
    public class TMonster : TAnimalObject
    {
        public uint m_dwThinkTick = 0;
        public bool m_boDupMode = false;

        public TMonster()
            : base()
        {
            m_boDupMode = false;
            m_dwThinkTick = HUtil32.GetTickCount();
            m_nViewRange = 6;
            m_nRunTime = 250;
            m_dwSearchTime = Convert.ToUInt32(3000 + HUtil32.Random(2000));
            m_dwSearchTick = HUtil32.GetTickCount();
            m_btRaceServer = 80;
            m_boAddToMaped = false;// 地图是否计数
        }

        public override bool Operate(TProcessMessage ProcessMsg)
        {
            return base.Operate(ProcessMsg);
        }

        public TBaseObject MakeClone(string sMonName, TBaseObject OldMon)
        {
            TBaseObject result = null;
            TBaseObject ElfMon;
            try
            {
                ElfMon = UserEngine.RegenMonsterByName(m_PEnvir.sMapName, m_nCurrX, m_nCurrY, sMonName);
                if ((ElfMon != null) && (OldMon != null))
                {
                    ElfMon.m_Master = OldMon.m_Master;
                    ElfMon.m_dwMasterRoyaltyTick = OldMon.m_dwMasterRoyaltyTick;
                    ElfMon.m_dwMasterRoyaltyTime = OldMon.m_dwMasterRoyaltyTime;// 怪物叛变计时
                    ElfMon.m_btSlaveMakeLevel = OldMon.m_btSlaveMakeLevel;
                    ElfMon.m_btSlaveExpLevel = OldMon.m_btSlaveExpLevel;
                    ElfMon.RecalcAbilitys();
                    ElfMon.RefNameColor();
                    if (OldMon.m_Master != null)
                    {
                        OldMon.m_Master.m_SlaveList.Add(ElfMon);
                    }
                    ElfMon.m_WAbil = OldMon.m_WAbil;
                    ElfMon.m_wStatusTimeArr = OldMon.m_wStatusTimeArr;
                    ElfMon.m_TargetCret = OldMon.m_TargetCret;
                    ElfMon.m_dwTargetFocusTick = OldMon.m_dwTargetFocusTick;
                    ElfMon.m_LastHiter = OldMon.m_LastHiter;
                    ElfMon.m_LastHiterTick = OldMon.m_LastHiterTick;
                    ElfMon.m_btDirection = OldMon.m_btDirection;
                    result = ElfMon;
                }
            }
            catch
            {
            }
            return result;
        }

        private bool Think()
        {
            bool result = false;
            int nOldX;
            int nOldY;
            if ((HUtil32.GetTickCount() - m_dwThinkTick) > 3000)
            {
                m_dwThinkTick = HUtil32.GetTickCount();
                if (m_PEnvir.GetXYObjCount(m_nCurrX, m_nCurrY) >= 2)
                {
                    m_boDupMode = true;
                }
                if (!IsProperTarget(m_TargetCret))
                {
                    m_TargetCret = null;
                }
            }
            if (m_boDupMode)
            {
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                WalkTo((byte)HUtil32.Random(8), false);
                if ((nOldX != m_nCurrX) || (nOldY != m_nCurrY))
                {
                    m_boDupMode = false;
                    result = true;
                }
            }
            return result;
        }

        public virtual bool AttackTarget()
        {
            bool result;
            byte bt06 = 0;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (m_TargetCret != null)
                {
                    nCode = 1;
                    if ((m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) //判断攻击目标是不是英雄
                        && (m_TargetCret.m_Abil.Level <= 22) && (((THeroObject)(m_TargetCret)).m_btStatus == 1))// 英雄22级前,跟随时不打
                    {
                        nCode = 2;
                        DelTargetCreat();
                        return result;
                    }
                    nCode = 3;
                    if (GetAttackDir(m_TargetCret, ref  bt06))
                    {
                        nCode = 4;
                        if ((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
                        {
                            m_dwHitTick = HUtil32.GetTickCount();
                            m_dwTargetFocusTick = HUtil32.GetTickCount();
                            nCode = 5;
                            this.Attack(m_TargetCret, bt06);
                            nCode = 6;
                            m_TargetCret.SetLastHiter(this);
                            nCode = 7;
                            BreakHolySeizeMode();
                        }
                        result = true;
                    }
                    else
                    {
                        nCode = 8;
                        if (m_TargetCret.m_PEnvir == m_PEnvir)
                        {
                            nCode = 9;
                            if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                            {
                                nCode = 10;
                                SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                            }
                        }
                        else
                        {
                            nCode = 11;
                            DelTargetCreat();
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMonster.AttackTarget Code:" + nCode);
            }
            return result;
        }

        public override void Run()
        {
            int nX = 0;
            int nY = 0;
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boGhost && !m_boDeath && !m_boFixedHideMode && !m_boStoneMode && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCode = 1;
                    if (Think())
                    {
                        base.Run();
                        return;
                    }
                    nCode = 2;
                    if (m_boWalkWaitLocked)
                    {
                        if ((HUtil32.GetTickCount() - m_dwWalkWaitTick) > m_dwWalkWait)
                        {
                            m_boWalkWaitLocked = false;
                        }
                    }
                    nCode = 3;
                    if (!m_boWalkWaitLocked && ((HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed))
                    {
                        m_dwWalkTick = HUtil32.GetTickCount();
                        m_nWalkCount++;
                        if (m_nWalkCount > m_nWalkStep)
                        {
                            m_nWalkCount = 0;
                            m_boWalkWaitLocked = true;
                            m_dwWalkWaitTick = HUtil32.GetTickCount();
                        }
                        nCode = 4;
                        if (!m_boRunAwayMode)
                        {
                            if (!m_boNoAttackMode)
                            {
                                if (m_TargetCret != null)
                                {
                                    nCode = 5;
                                    if (AttackTarget())
                                    {
                                        nCode = 51;
                                        base.Run();
                                        return;
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
                            nCode = 6;
                            if (m_Master != null)
                            {
                                if (m_TargetCret == null)
                                {
                                    nCode = 7;
                                    if (!m_Master.m_boGhost)
                                    {
                                        m_Master.GetBackPosition(ref nX, ref nY);
                                        if ((Math.Abs(m_nTargetX - nX) > 1) || (Math.Abs(m_nTargetY - nY) > 1))
                                        {
                                            m_nTargetX = nX;
                                            m_nTargetY = nY;
                                            if ((Math.Abs(m_nCurrX - nX) <= 2) && (Math.Abs(m_nCurrY - nY) <= 2))
                                            {
                                                nCode = 8;
                                                if (m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                                {
                                                    m_nTargetX = m_nCurrX;
                                                    m_nTargetY = m_nCurrY;
                                                }
                                            }
                                        }
                                    }
                                }
                                nCode = 9;
                                if (m_Master != null)
                                {
                                    if (!m_Master.m_boGhost)
                                    {
                                        if ((!m_Master.m_boSlaveRelax) && ((m_PEnvir != m_Master.m_PEnvir) || (Math.Abs(m_nCurrX - m_Master.m_nCurrX) > 20)
                                            || (Math.Abs(m_nCurrY - m_Master.m_nCurrY) > 20)))
                                        {
                                            nCode = 10;
                                            SpaceMove(m_Master.m_PEnvir.sMapName, m_nTargetX, m_nTargetY, 1);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            nCode = 11;
                            if ((m_dwRunAwayTime > 0) && ((HUtil32.GetTickCount() - m_dwRunAwayStart) > m_dwRunAwayTime))
                            {
                                m_boRunAwayMode = false;
                                m_dwRunAwayTime = 0;
                            }
                        }
                        nCode = 12;
                        if ((m_Master != null))
                        {
                            if (m_Master.m_boSlaveRelax)
                            {
                                base.Run();
                                return;
                            }
                        }
                        if (m_nTargetX != -1)
                        {
                            nCode = 13;
                            this.GotoTargetXY();
                        }
                        else
                        {
                            nCode = 14;
                            if (m_TargetCret == null)
                            {
                                Wondering();
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMonster.Run Code:" + nCode);
            }
        }
    }
}
