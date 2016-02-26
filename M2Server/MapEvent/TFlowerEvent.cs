using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server
{
    public class TFlowerEvent : TEvent
    {
        public TFlowerEvent(TEnvirnoment Envir, int nX, int nY, int nType, uint nTime)
            : base(Envir, nX, nY, nType, nTime, true)
        {
        }
        ~TFlowerEvent()
        {
        }
        public override void Run()
        {
            base.Run();
        }
    }
}
