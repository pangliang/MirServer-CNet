using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Monster
{
    public class TThornDarkMonster : TDualAxeMonster
    {
        public TThornDarkMonster()
            : base()
        {
            this.m_nAttackMax = 3;
            this.m_btRaceServer = 93;
        }
    }
}
