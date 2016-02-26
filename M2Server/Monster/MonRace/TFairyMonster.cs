using GameFramework;
using System;

namespace M2Server.Monster
{
    /// <summary>
    /// 月灵
    /// </summary>
    public class TFairyMonster : TMonster
    {
        /// <summary>
        /// 自动躲避间隔
        /// </summary>
        public uint m_dwAutoAvoidTick = 0;
        /// <summary>
        /// 最后的方向
        /// </summary>
        public byte m_btLastDirection = 0;
        /// <summary>
        /// 是否可以攻击
        /// </summary>
        public bool m_boIsUseAttackMagic = false;
        /// <summary>
        /// 动作间隔
        /// </summary>
        public uint m_dwActionTick = 0;
        /// <summary>
        /// DB设置的走路速度 
        /// </summary>
        public int nWalkSpeed = 0;
        /// <summary>
        /// 是否需要躲避
        /// </summary>
        public ushort nHitCount = 0;

        /// <summary>
        ///  检查身边一定范围的怪数量 
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRange">范围大小（12格）</param>
        /// <returns></returns>
        private int CheckTargetXYCount(int nX, int nY, int nRange)
        {
            int result = 0;
            TBaseObject BaseObject;
            int nC;
            int n10 = nRange;
            if (m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < m_VisibleActors.Count; I++)
                {
                    BaseObject = m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || m_boCoolEye))
                            {
                                nC = Math.Abs(nX - BaseObject.m_nCurrX) + Math.Abs(nY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    result++;
                                    if (result > 1)// 月灵类只判断身边有一个目标接近即躲避
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public virtual bool IsNeedGotoXY()
        {
            bool result = false;// 是否走向目标
            if ((m_TargetCret != null) && !m_boIsUseAttackMagic && ((Math.Abs(m_TargetCret.m_nCurrX - m_nCurrX) > 7)
                || (Math.Abs(m_TargetCret.m_nCurrY - m_nCurrY) > 7)))
            {
                m_dwAutoAvoidTick = HUtil32.GetTickCount();
                result = true;
            }
            return result;
        }

        // 自动躲避
        private bool IsNeedAvoid()
        {
            bool result;// 是否需要躲避
            result = false;
            if ((m_TargetCret != null) && !m_boIsUseAttackMagic)
            {
                if (CheckTargetXYCount(m_nCurrX, m_nCurrY, 2) > 0)// 怪在近身二格内
                {
                    m_dwAutoAvoidTick = HUtil32.GetTickCount();
                    result = true;
                }
            }
            return result;
        }

        // 检查身边一定范围的怪数量 
        private int CheckTargetXYCountOfDirection(int nX, int nY, int nDir, int nRange)
        {
            int result = 0;
            // 检测指定方向和范围内坐标的怪物数量
            TBaseObject BaseObject;
            if (m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < m_VisibleActors.Count; I++)
                {
                    BaseObject = m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || m_boCoolEye))
                            {
                                switch (nDir)
                                {
                                    case Grobal2.DR_UP:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_RIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWN:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_LEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool WalkToTargetXY(int nTargetX, int nTargetY)
        {
            bool result;
            int I;
            int nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            result = false;
            if ((Math.Abs(nTargetX - m_nCurrX) > 1) || (Math.Abs(nTargetY - m_nCurrY) > 1))
            {
                n10 = nTargetX;
                n14 = nTargetY;
                dwTick3F4 = HUtil32.GetTickCount();
                nDir = Grobal2.DR_DOWN;
                if (n10 > m_nCurrX)
                {
                    nDir = Grobal2.DR_RIGHT;
                    if (n14 > m_nCurrY)
                    {
                        nDir = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        nDir = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n10 < m_nCurrX)
                    {
                        nDir = Grobal2.DR_LEFT;
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNLEFT;
                        }
                        if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                    }
                    else
                    {
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWN;
                        }
                        else if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UP;
                        }
                    }
                }
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                WalkTo((byte)nDir, false);
                if ((Math.Abs(nTargetX - m_nCurrX) <= 1) && (Math.Abs(nTargetY - m_nCurrY) <= 1))
                {
                    result = true;
                }
                if (!result)
                {
                    n20 = HUtil32.Random(3);
                    for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                    {
                        if ((nOldX == m_nCurrX) && (nOldY == m_nCurrY))
                        {
                            if (n20 != 0)
                            {
                                nDir++;
                            }
                            if ((nDir > Grobal2.DR_UPLEFT))
                            {
                                nDir = Grobal2.DR_UP;
                            }
                            WalkTo((byte)nDir, false);
                            if ((Math.Abs(nTargetX - m_nCurrX) <= 1) && (Math.Abs(nTargetY - m_nCurrY) <= 1))
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool WalkToTargetXY2(int nTargetX, int nTargetY)
        {
            bool result = false;
            int I;
            int nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            if ((nTargetX != m_nCurrX) || (nTargetY != m_nCurrY))
            {
                n10 = nTargetX;
                n14 = nTargetY;
                dwTick3F4 = HUtil32.GetTickCount();
                nDir = Grobal2.DR_DOWN;
                if (n10 > m_nCurrX)
                {
                    nDir = Grobal2.DR_RIGHT;
                    if (n14 > m_nCurrY)
                    {
                        nDir = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        nDir = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n10 < m_nCurrX)
                    {
                        nDir = Grobal2.DR_LEFT;
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNLEFT;
                        }
                        if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                    }
                    else
                    {
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWN;
                        }
                        else if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UP;
                        }
                    }
                }
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                WalkTo((byte)nDir, false);
                if ((nTargetX == m_nCurrX) && (nTargetY == m_nCurrY))
                {
                    result = true;
                }
                if (!result)
                {
                    n20 = HUtil32.Random(3);
                    for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                    {
                        if ((nOldX == m_nCurrX) && (nOldY == m_nCurrY))
                        {
                            if (n20 != 0)
                            {
                                nDir++;
                            }
                            else if (nDir > 0)
                            {
                                nDir -= 1;
                            }
                            else
                            {
                                nDir = Grobal2.DR_UPLEFT;
                            }
                            if ((nDir > Grobal2.DR_UPLEFT))
                            {
                                nDir = Grobal2.DR_UP;
                            }
                            WalkTo((byte)nDir, false);
                            if ((nTargetX == m_nCurrX) && (nTargetY == m_nCurrY))
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool GotoTargetXY(int nTargetX, int nTargetY)
        {
            return WalkToTargetXY(nTargetX, nTargetY);
        }

        // 自动躲避
        public int AutoAvoid_GetAvoidDir()
        {
            int result;
            int n10;
            int n14;
            n10 = m_TargetCret.m_nCurrX;
            n14 = m_TargetCret.m_nCurrY;
            result = Grobal2.DR_DOWN;
            if (n10 > m_nCurrX)
            {
                result = Grobal2.DR_LEFT;
                if (n14 > m_nCurrY)
                {
                    result = Grobal2.DR_DOWNLEFT;
                }
                if (n14 < m_nCurrY)
                {
                    result = Grobal2.DR_UPLEFT;
                }
            }
            else
            {
                if (n10 < m_nCurrX)
                {
                    result = Grobal2.DR_RIGHT;
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        result = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                    else if (n14 < m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                }
            }
            return result;
        }

        public byte AutoAvoid_GetDirXY(int nTargetX, int nTargetY)
        {
            byte result;
            int n10;
            int n14;
            n10 = nTargetX;
            n14 = nTargetY;
            result = Grobal2.DR_DOWN;
            if (n10 > m_nCurrX)
            {
                result = Grobal2.DR_RIGHT;
                if (n14 > m_nCurrY)
                {
                    result = Grobal2.DR_DOWNRIGHT;
                }

                if (n14 < m_nCurrY)
                {
                    result = Grobal2.DR_UPRIGHT;
                }
            }
            else
            {
                if (n10 < m_nCurrX)
                {
                    result = Grobal2.DR_LEFT;
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNLEFT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        result = Grobal2.DR_UPLEFT;
                    }
                }
                else
                {
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                    else if (n14 < m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                }
            }
            return result;
        }

        public bool AutoAvoid_GetGotoXY(int nDir, ref int nTargetX, ref int nTargetY)
        {
            bool result = false;
            int n01;
            n01 = 0;
            while (true)
            {
                switch (nDir)
                {
                    case Grobal2.DR_UP:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPRIGHT:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_RIGHT:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNRIGHT:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY += 2;
                            n01++;
                            continue;
                        }
                    case Grobal2.DR_DOWN:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNLEFT:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_LEFT:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPLEFT:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    default:
                        break;
                }
            }
            return result;
        }

        public bool AutoAvoid_GetAvoidXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n10;
            int nDir;
            int nX;
            int nY;
            nX = nTargetX;
            nY = nTargetY;
            result = AutoAvoid_GetGotoXY(m_btLastDirection, ref nTargetX, ref nTargetY);
            n10 = 0;
            while (true)
            {
                if (n10 >= 10)
                {
                    break;
                }
                if (result)
                {
                    break;
                }
                nTargetX = nX;
                nTargetY = nY;
                nDir = HUtil32.Random(7);
                result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                n10++;
            }
            return result;
        }

        public bool AutoAvoid_GotoMasterXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int nDir;
            result = false;
            if ((m_Master != null) && ((Math.Abs(m_Master.m_nCurrX - m_nCurrX) > 5) || (Math.Abs(m_Master.m_nCurrY - m_nCurrY) > 5)))
            {
                nTargetX = m_nCurrX;
                nTargetY = m_nCurrY;
                nDir = AutoAvoid_GetDirXY(m_Master.m_nCurrX, m_Master.m_nCurrY);
                switch (nDir)
                {
                    case Grobal2.DR_UP:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        break;
                    case Grobal2.DR_RIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        break;
                    case Grobal2.DR_DOWN:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        break;
                    case Grobal2.DR_LEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        break;
                }
            }
            return result;
        }

        // 增加检查两动作的间隔
        private bool AutoAvoid()
        {
            bool result = true;
            int nTargetX = 0;
            int nTargetY = 0;
            byte nDir;
            if ((m_TargetCret != null) && (!m_TargetCret.m_boDeath))
            {
                if (AutoAvoid_GotoMasterXY(ref nTargetX, ref nTargetY))
                {
                    result = GotoTargetXY(nTargetX, nTargetY);
                }
                else
                {
                    nTargetX = m_TargetCret.m_nCurrX;
                    nTargetY = m_TargetCret.m_nCurrY;
                    nDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, nTargetX, nTargetY);
                    nDir = GetBackDir(nDir);
                    m_PEnvir.GetNextPosition(nTargetX, nTargetY, nDir, 3, ref m_nTargetX, ref m_nTargetY);
                    result = GotoTargetXY(m_nTargetX, m_nTargetY);
                }
            }
            return result;
        }

        private void FlyAxeAttack(TBaseObject Target)
        {
            TAbility WAbil;
            int nDamage;
            // 重击几率,目标等级不高于自己,才使用重击
            if (((HUtil32.Random(M2Share.g_Config.nFairyDuntRate) == 0) && (Target.m_Abil.Level <= m_Abil.Level))
                || (nHitCount >= HUtil32._MIN((3 + M2Share.g_Config.nFairyDuntRateBelow),
                (m_btSlaveExpLevel + M2Share.g_Config.nFairyDuntRateBelow))))
            {
                // 月灵重击次数,达到次数时按等级出重击
                m_btDirection = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, Target.m_nCurrX, Target.m_nCurrY);
                WAbil = m_WAbil;// 重击倍数
                nDamage = (int)HUtil32._MAX(0, (int)HUtil32.Round((double)((HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1))
                    + HUtil32.LoWord(WAbil.DC)) * M2Share.g_Config.nFairyAttackRate / 100));
                if (nDamage > 0)
                {
                    nDamage = Target.GetHitStruckDamage(this, nDamage);
                }
                if (nDamage > 0)
                {
                    Target.StruckDamage(nDamage);
                }
                Target.SetLastHiter(this);
                Target.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, Target.m_WAbil.HP, Target.m_WAbil.MaxHP, Parse(this), "",
                    (uint)HUtil32._MAX(Math.Abs(m_nCurrX - Target.m_nCurrX), Math.Abs(m_nCurrY - Target.m_nCurrY)) * 50 + 600);
                SendRefMsg(Grobal2.RM_FAIRYATTACKRATE, 1, m_nCurrX, m_nCurrY, Parse(Target), "");
                m_dwActionTick = HUtil32.GetTickCount();
                nHitCount = 0;// 攻击计数
            }
            else
            {
                m_btDirection = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, Target.m_nCurrX, Target.m_nCurrY);
                WAbil = m_WAbil;
                nDamage = HUtil32._MAX(0, HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1)
                    + HUtil32.LoWord(WAbil.DC));
                if (nDamage > 0)
                {
                    nDamage = Target.GetHitStruckDamage(this, nDamage);
                }
                if (nDamage > 0)
                {
                    Target.StruckDamage(nDamage);
                }
                Target.SetLastHiter(this);
                Target.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, Target.m_WAbil.HP,
                    Target.m_WAbil.MaxHP, Parse(this), "", (uint)HUtil32._MAX(Math.Abs(m_nCurrX - Target.m_nCurrX), Math.Abs(m_nCurrY - Target.m_nCurrY)) * 50 + 600);
                SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, Parse(Target), "");
                m_dwActionTick = HUtil32.GetTickCount();
                nHitCount++;// 攻击计数
            }
        }

        // 增加检查两动作的间隔
        private bool CheckActionStatus()
        {
            bool result = false;
            if (HUtil32.GetTickCount() - m_dwActionTick > 1100)// 900
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
            }
            return result;
        }

        public override bool AttackTarget()
        {
            bool result;
            result = false;
            if ((m_TargetCret == null) || (m_TargetCret == m_Master))
            {
                return result;
            }
            if (!CheckActionStatus())
            {
                m_boIsUseAttackMagic = false;
                return result;
            }
            m_boIsUseAttackMagic = true;
            if ((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
            {
                m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 7) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 7))
                {
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    FlyAxeAttack(m_TargetCret);
                    m_dwHitTick = HUtil32.GetTickCount();
                    result = true;
                    return result;
                }
                else
                {
                    m_boIsUseAttackMagic = false;
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
            }
            else
            {
                m_boIsUseAttackMagic = false;
            }
            return result;
        }

        public TFairyMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_boIsUseAttackMagic = false;
            nHitCount = 0;// 轻击计数
            m_nViewRange = 8;
        }


        public override void Run()
        {
            int nX = 0;
            int nY = 0;
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCode = 1;
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        nCode = 2;
                        SearchTarget();// 搜索可攻击目标
                    }
                    nCode = 4;
                    if (((HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed))// 走路间隔
                    {
                        m_dwWalkTick = HUtil32.GetTickCount();// 走路间隔
                        if ((m_Master != null))//主人休息状态时的控制
                        {
                            if ((!m_Master.m_boSlaveRelax))
                            {
                                m_boNoAttackMode = false;
                            }
                            else
                            {
                                m_boNoAttackMode = true;
                            }
                        }
                        else
                        {
                            m_boNoAttackMode = false;
                        }
                        if (!m_boNoAttackMode)
                        {
                            nCode = 5;
                            if ((m_TargetCret != null))
                            {
                                if ((!m_TargetCret.m_boDeath)) // 目标不为空
                                {
                                    nCode = 6;
                                    if (IsNeedGotoXY())// 目标离远了,走向目标
                                    {
                                        nCode = 7;
                                        GotoTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                                        base.Run();
                                        return;
                                    }
                                    nCode = 8;
                                    if (AttackTarget())
                                    {
                                        base.Run();
                                        return;
                                    }
                                    nCode = 9;
                                    if (IsNeedAvoid()) // 月灵躲避
                                    {
                                        nCode = 10;
                                        AutoAvoid();// 自动躲避
                                        base.Run();
                                        return;
                                    }
                                }
                            }
                        }
                        nCode = 11;
                        if ((m_Master != null))
                        {
                            nCode = 12;
                            if ((!m_Master.m_boSlaveRelax)) // 离主人远后,自已走近主人
                            {
                                if (m_TargetCret == null)
                                {
                                    nCode = 13;
                                    m_Master.GetBackPosition(ref nX, ref nY);
                                    if ((Math.Abs(m_nTargetX - nX) > 1) || (Math.Abs(m_nTargetY - nY) > 1))
                                    {
                                        m_nTargetX = nX;
                                        m_nTargetY = nY;
                                        if ((Math.Abs(m_nCurrX - nX) <= 2) && (Math.Abs(m_nCurrY - nY) <= 2))
                                        {
                                            nCode = 14;
                                            if (m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                            {
                                                m_nTargetX = m_nCurrX;
                                                m_nTargetY = m_nCurrY;
                                            }
                                        }
                                    }
                                    nCode = 15;
                                    if (m_nTargetX != -1)
                                    {
                                        if ((Math.Abs(m_nCurrX - m_nTargetX) > 1) || (Math.Abs(m_nCurrY - m_nTargetY) > 1))
                                        {
                                            GotoTargetXY(m_nTargetX, m_nTargetY);
                                        }
                                    }
                                }
                            }
                            nCode = 16;
                            if ((m_Master != null))
                            {
                                // 离主人远了,直接飞到主人身边
                                if ((!m_Master.m_boSlaveRelax) && ((m_PEnvir != m_Master.m_PEnvir) || (Math.Abs(m_nCurrX - m_Master.m_nCurrX) > 20) || (Math.Abs(m_nCurrY - m_Master.m_nCurrY) > 20)))
                                {
                                    nCode = 17;
                                    SpaceMove(m_Master.m_PEnvir.sMapName, m_Master.m_nCurrX, m_Master.m_nCurrY, 1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (m_boDeath)
                    {
                        nCode = 18;
                        if ((HUtil32.GetTickCount() - m_dwDeathTick > 2000))
                        {
                            MakeGhost(); // 尸体消失
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFairyMonster.Run Code:" + nCode);
            }
            base.Run();
        }

        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            ResetElfMon();
        }

        // 月灵间隔
        private void ResetElfMon()
        {
            if (m_Master != null)
            {
                m_nWalkSpeed = HUtil32._MAX(200, nWalkSpeed - m_btSlaveMakeLevel * 50); // 走路速度 由DB设置的走路速度控制
            }
        }
    }
}