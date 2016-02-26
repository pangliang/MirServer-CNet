using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server
{
    public class TPileStones : TEvent
    {
        public TPileStones(TEnvirnoment Envir, int nX, int nY, int nType, uint nTime)
            : base(Envir, nX, nY, nType, nTime, true)
        {
            this.m_nEventParam = 1;
        }

        ~TPileStones()
        {
        }

        public void AddEventParam()
        {
            if (this.m_nEventParam < 5)
            {
                this.m_nEventParam++;
            }
        }
    }
}
