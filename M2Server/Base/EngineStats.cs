using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Base
{
    /// <summary>
    /// 引擎状态
    /// </summary>
    public class EngineStats : Statistics<EngineStats>
    {
        public static void Init()
        {
            inited = true;
            StatsPostDelay = s_interval;
        }

        /// <summary>
        /// 
        /// </summary>
        public static int StatsPostDelay
        {
            get { return instance != null ? instance.StatsPostInterval : 0; }
            set
            {
                if (!inited)
                {
                    s_interval = value;
                    return;
                }

                if (instance == null)
                {
                    if (value > 0)
                    {
                        // init
                        instance = new EngineStats();
                    }
                    else
                    {
                        return;
                    }
                }
                Instance.StatsPostInterval = value;
            }
        }

        public override void GetStats(ICollection<string> list)
        {
            list.Add(string.Format("+ Uptime: {0}", HUtil32.Format(GameBase.RunTime)));
            base.GetStats(list);
        }

        public override long TotalBytesSent
        {
            get { return 0; }
        }

        public override long TotalBytesReceived
        {
            get { return 0; }
        }
    }
}
