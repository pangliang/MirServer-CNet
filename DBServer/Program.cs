using System;
using System.Windows.Forms;

namespace DBServer
{
    public class DBServer
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TFrmMain());
        }
    }
}