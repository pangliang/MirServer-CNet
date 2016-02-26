using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TCowMonster : TATMonster
    {
        public TCowMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }
    }
}
