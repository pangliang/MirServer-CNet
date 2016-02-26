using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;

namespace M2Server
{
    /// <summary>
    /// 矿石事件
    /// </summary>
    public class TStoneMineEvent : TEvent
    {
        public int m_nMineCount = 0;
        public int m_nAddStoneCount = 0;
        public uint m_dwAddStoneMineTick = 0;

        public TStoneMineEvent(TEnvirnoment Envir, int nX, int nY, int nType)
            : base(Envir, nX, nY, nType, 0, false)
        {
            this.m_Envir.AddToMapMineEvent(nX, nY, Grobal2.OS_EVENTOBJECT, this);
            this.m_boVisible = false;
            m_nMineCount = HUtil32.Random(200);
            m_dwAddStoneMineTick = HUtil32.GetTickCount();
            this.m_boActive = false;
            m_nAddStoneCount = HUtil32.Random(80);
        }

        public void AddStoneMine()
        {
            m_nMineCount = m_nAddStoneCount;
            m_dwAddStoneMineTick = HUtil32.GetTickCount();
        }
    }
}
