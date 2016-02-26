using GameFramework;
using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmViewKernelInfo : Form
    {

        public TfrmViewKernelInfo()
        {
            InitializeComponent();
        }

        private void TfrmViewKernelInfo_Load(object sender, EventArgs e)
        {
            const string sNo = "序号";
            const string sHandle = "句柄";
            const string sThreadID = "线程ID";
            const string sRunTime = "运行时间";
            const string sRunFlag = "运行状态";
            TGameConfig Config = M2Share.g_Config;
            GridThread.Columns.Add(sNo);
            GridThread.Columns.Add(sHandle);
            GridThread.Columns.Add(sThreadID);
            GridThread.Columns.Add(sRunTime);
            GridThread.Columns.Add(sRunFlag);
            Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TGameConfig Config = M2Share.g_Config;
            EditLoadHumanDBCount.Text = (M2Share.g_Config.nLoadDBCount).ToString();
            EditLoadHumanDBErrorCoun.Text = (M2Share.g_Config.nLoadDBErrorCount).ToString();
            EditSaveHumanDBCount.Text = (M2Share.g_Config.nSaveDBCount).ToString();
            EditHumanDBQueryID.Text = (M2Share.g_Config.nDBQueryID).ToString();
            EditItemNumber.Text = (M2Share.g_Config.nItemNumber).ToString();
            EditItemNumberEx.Text = (M2Share.g_Config.nItemNumberEx).ToString();
            EditWinLotteryCount.Text = (M2Share.g_Config.nWinLotteryCount).ToString();
            EditNoWinLotteryCount.Text = (M2Share.g_Config.nNoWinLotteryCount).ToString();
            EditWinLotteryLevel1.Text = (M2Share.g_Config.nWinLotteryLevel1).ToString();
            EditWinLotteryLevel2.Text = (M2Share.g_Config.nWinLotteryLevel2).ToString();
            EditWinLotteryLevel3.Text = (M2Share.g_Config.nWinLotteryLevel3).ToString();
            EditWinLotteryLevel4.Text = (M2Share.g_Config.nWinLotteryLevel4).ToString();
            EditWinLotteryLevel5.Text = (M2Share.g_Config.nWinLotteryLevel5).ToString();
            EditWinLotteryLevel6.Text = (M2Share.g_Config.nWinLotteryLevel6).ToString();
            EditGlobalVal1.Text = (M2Share.g_Config.GlobalVal[0]).ToString();
            EditGlobalVal2.Text = (M2Share.g_Config.GlobalVal[1]).ToString();
            EditGlobalVal3.Text = (M2Share.g_Config.GlobalVal[2]).ToString();
            EditGlobalVal4.Text = (M2Share.g_Config.GlobalVal[3]).ToString();
            EditGlobalVal5.Text = (M2Share.g_Config.GlobalVal[4]).ToString();
            EditGlobalVal6.Text = (M2Share.g_Config.GlobalVal[5]).ToString();
            EditGlobalVal7.Text = (M2Share.g_Config.GlobalVal[6]).ToString();
            EditGlobalVal8.Text = (M2Share.g_Config.GlobalVal[7]).ToString();
            EditGlobalVal9.Text = (M2Share.g_Config.GlobalVal[8]).ToString();
            EditGlobalVal10.Text = (M2Share.g_Config.GlobalVal[9]).ToString();

            //M2中的线程信息 目前无法实现 by john 2013.4.25
            //TThreadInfo ThreadInfo;
            //EditAllocMemSize.Text = (AllocMemSize).ToString();
            //EditAllocMemCount.Text = (AllocMemCount).ToString();
            //// GridThread.Row:=2;
            //ThreadInfo = Config.UserEngineThread;
            //GridThreadAdd(ThreadInfo, 0);
            //ThreadInfo = Config.IDSocketThread;
            //GridThreadAdd(ThreadInfo, 1);
            //ThreadInfo = Config.DBSOcketThread;
            //GridThreadAdd(ThreadInfo, 2);
        }

        //private void GridThreadAdd(TThreadInfo ThreadInfo, int Index)
        //{
        //    GridThread.Cells[0, Index + 1] = string.Format("%d", new int[] { Index });
        //    GridThread.Cells[1, Index + 1] = string.Format("%d", new int[] { ThreadInfo.hThreadHandle });
        //    GridThread.Cells[2, Index + 1] = string.Format("%d", new uint[] { ThreadInfo.dwThreadID });
        //    GridThread.Cells[3, Index + 1] = string.Format("%d/%d/%d", new int[] { GetTickCount - ThreadInfo.dwRunTick, ThreadInfo.nRunTime, ThreadInfo.nMaxRunTime });
        //    GridThread.Cells[4, Index + 1] = string.Format("%d", new int[] { ThreadInfo.nRunFlag });
        //}
    }
}
