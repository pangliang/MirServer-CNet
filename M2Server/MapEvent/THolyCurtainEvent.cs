using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server
{
    public class THolyCurtainEvent : TEvent
    {
        public THolyCurtainEvent(TEnvirnoment Envir, int nX, int nY, int nType, uint nTime)
            : base(Envir, nX, nY, nType, nTime, true)
        {
        }

        ~THolyCurtainEvent()
        {
        }
    }
}
