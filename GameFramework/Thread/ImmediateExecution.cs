using System;
using System.Threading;

namespace GameFramework.Thrend
{
    /// <summary>
    /// 计划立即执行任务
    /// </summary>
    public struct ImmediateExecution : ISchedule
    {
        public DateTime ExecutionTime
        {
            get { return DateTime.Now; }
            set { }
        }

        public long DueTime
        {
            get { return 0; }
        }

        public long Period
        {
            get { return Timeout.Infinite; }
        }
    }

    /// <summary>
    /// 计划在某一未来的时间执行一个操作一次，如果这个时间比现在的时间小，就变成了立即执行的方式
    /// </summary>
    public struct ScheduleExecutionOnce : ISchedule
    {
        private DateTime schedule;

        public DateTime ExecutionTime
        {
            get { return schedule; }
            set { schedule = value; }
        }

        /// <summary>
        /// 得到该计划还有多久才能运行
        /// </summary>
        public long DueTime
        {
            get
            {
                long ms = (schedule.Ticks - DateTime.Now.Ticks) / 10000;
                if (ms < 0)
                {
                    ms = 0;
                }
                return ms;
            }
        }

        public long Period
        {
            get { return Timeout.Infinite; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="schedule">计划开始执行的时间</param>
        public ScheduleExecutionOnce(DateTime time)
        {
            schedule = time;
        }
    }

    /// <summary>
    /// 周期性的执行计划
    /// </summary>
    public struct CycExecution : ISchedule
    {
        private DateTime schedule;
        private TimeSpan period;

        public DateTime ExecutionTime
        {
            get { return schedule; }
            set { schedule = value; }
        }

        public long DueTime
        {
            get
            {
                long ms = (schedule.Ticks - DateTime.Now.Ticks) / 10000;
                if (ms < 0)
                {
                    ms = 0;
                }
                return ms;
            }
        }

        public long Period
        {
            get { return period.Ticks / 10000; }
        }

        /// <summary>
        /// 构造函数,马上开始运行
        /// </summary>
        /// <param name="period">周期时间</param>
        public CycExecution(TimeSpan period)
        {
            this.schedule = DateTime.Now;
            this.period = period;
        }

        /// <summary>
        /// 构造函数，在一个将来时间开始运行
        /// </summary>
        /// <param name="shedule">计划执行的时间</param>
        /// <param name="period">周期时间</param>
        public CycExecution(DateTime shedule, TimeSpan period)
        {
            this.schedule = shedule;
            this.period = period;
        }
    }
}