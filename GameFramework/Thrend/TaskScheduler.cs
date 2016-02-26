using System.Collections.Generic;

namespace GameFramework.Thrend
{
    /// <summary>
    /// 任务管理中心
    /// 使用它可以管理一个或则多个同时运行的任务
    /// </summary>
    public static class TaskScheduler
    {
        private static List<ThrendManage> taskScheduler;

        public static int Count
        {
            get { return taskScheduler.Count; }
        }

        static TaskScheduler()
        {
            taskScheduler = new List<ThrendManage>();
        }

        /// <summary>
        /// 查找任务
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ThrendManage Find(string name)
        {
            return taskScheduler.Find(task => task.Name == name);
        }

        public static IEnumerator<ThrendManage> GetEnumerator()
        {
            return taskScheduler.GetEnumerator();
        }

        /// <summary>
        /// 终止任务
        /// </summary>
        public static void TerminateAllTask()
        {
            lock (taskScheduler)
            {
                taskScheduler.ForEach(task => task.Close());
                taskScheduler.Clear();
                taskScheduler.TrimExcess();
            }
        }

        internal static void Register(ThrendManage task)
        {
            lock (taskScheduler)
            {
                taskScheduler.Add(task);
            }
        }

        internal static void Deregister(ThrendManage task)
        {
            lock (taskScheduler)
            {
                taskScheduler.Remove(task);
            }
        }
    }
}