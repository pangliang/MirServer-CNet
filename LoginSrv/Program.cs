using System;
using System.Runtime;
using System.Windows.Forms;

namespace LoginSrv
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
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