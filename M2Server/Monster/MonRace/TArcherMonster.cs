using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Monster
{
    public class TArcherMonster : TDualAxeMonster
    {
        public TArcherMonster()
            : base()
        {
            this.m_nAttackMax = 6;
            this.m_btRaceServer = 104;
        }
    }
}
