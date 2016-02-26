using System;
using System.Runtime;
using System.Windows.Forms;

namespace M2Server
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (GCSettings.IsServerGC)
            {
                GCSettings.LatencyMode = GCLatencyMode.Batch;
            }
            else
            {
                GCSettings.LatencyMode = GCLatencyMode.Interactive;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TFrmMain());
        }
    }
}