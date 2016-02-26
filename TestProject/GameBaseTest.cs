using M2Server.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    public class GameBaseTest:GameBase
    {
        public void test()
        {
            Console.WriteLine(GameBase.StartTime);
            Console.WriteLine(new DateTime(GameBase.RunTime.Ticks));
        }
    }
}
