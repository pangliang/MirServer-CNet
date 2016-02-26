using GameFramework;
using System.Collections;
using System.IO;
using System.Threading;

namespace LoginSrv
{
    public class TThreadParseList
    {
        private TStringList AccountLoadList = null;
        private TStringList IPaddrLoadList = null;
        private SortedList AccountCostList = null;
        private SortedList IPaddrCostList = null;
        private bool bo40 = false;
        public Thread th = null;

        public TThreadParseList(bool CreateSuspended)
        {
            AccountLoadList = new TStringList();
            IPaddrLoadList = new TStringList();
            AccountCostList = new SortedList();
            IPaddrCostList = new SortedList();
            bo40 = false;
            th = new Thread(Execute);
            th.IsBackground = true;

            //th.Suspend();
        }

        public void Execute()
        {
            int I;
            uint dwTick2C;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            int nC;
            int n10;
            int n14;
            TConfig Config;
            Config = LSShare.g_Config;
            dwTick2C = 0;
            while (true)
            {
                if ((HUtil32.GetTickCount() - dwTick2C) > 5 * 60 * 1000)
                {
                    dwTick2C = HUtil32.GetTickCount();
                    try
                    {
                        if (File.Exists(Config.sFeedIDList))
                        {
                            AccountLoadList.Clear();
                            AccountLoadList.LoadFromFile(Config.sFeedIDList);
                            if (AccountLoadList.Count > 0)
                            {
                                AccountCostList.Clear();
                                for (I = 0; I < AccountLoadList.Count; I++)
                                {
                                    s18 = AccountLoadList[I].Trim();
                                    s18 = HUtil32.GetValidStr3(s18, ref s1C, new string[] { " ", "\t" });
                                    s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });
                                    s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });
                                    n10 = HUtil32.Str_ToInt(s24, 0);
                                    n14 = HUtil32.Str_ToInt(s28, 0);
                                    nC = HUtil32.MakeLong(HUtil32._MAX(n14, 0), HUtil32._MAX(n10, 0));
                                    AccountCostList.Add(s1C, nC);
                                    if (!bo40)
                                    {
                                        if ((I % 100) == 0)
                                        {
                                            Thread.Sleep(1);
                                        }
                                    }
                                }
                            }

                            //LoadAccountCostList(Config, AccountCostList);
                        }
                    }
                    catch
                    {
                        LSShare.MainOutMessage("Exception] loading on IDStrList.");
                    }
                    try
                    {
                        if (File.Exists(Config.sFeedIPList))
                        {
                            IPaddrLoadList.Clear();
                            IPaddrLoadList.LoadFromFile(Config.sFeedIPList);
                            if (IPaddrLoadList.Count > 0)
                            {
                                IPaddrCostList.Clear();
                                for (I = 0; I < IPaddrLoadList.Count; I++)
                                {
                                    s18 = IPaddrLoadList[I].Trim();
                                    s18 = HUtil32.GetValidStr3(s18, ref s1C, new string[] { " ", "\t" });
                                    s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });
                                    s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });
                                    n10 = HUtil32.Str_ToInt(s24, 0);
                                    n14 = HUtil32.Str_ToInt(s28, 0);

                                    //@ Unsupported function or procedure: 'MakeLong'
                                    nC = HUtil32.MakeLong(HUtil32._MAX(n14, 0), HUtil32._MAX(n10, 0));
                                    IPaddrCostList.Add(s1C, nC);
                                    if (!bo40)
                                    {
                                        if ((I % 100) == 0)
                                        {
                                            Thread.Sleep(1);
                                        }
                                    }
                                }
                            }

                            //LoadIPaddrCostList(Config, IPaddrCostList);
                        }
                    }
                    catch
                    {
                        LSShare.MainOutMessage("Exception] loading on IPStrList.");
                    }
                }
                Thread.Sleep(10);

                //@ Unsupported property or method(C): 'Terminated'
                //if (this.Terminated)
                //{
                //    break;
                //}
            }
        }
    } // end TThreadParseList
}