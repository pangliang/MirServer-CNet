using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBServer
{
    //public class TRankingThread: Thread
    //{
    //    // ------------------------------------------------------------------------------
    //    //Constructor  Create( CreateSuspended)
    //    public TRankingThread(bool CreateSuspended) : base(CreateSuspended)
    //    {
    //    }
    //    //@ Destructor  Destroy()
    //    ~TRankingThread()
    //    {
    //        // base.Destroy();
    //    }
    //    public override void Execute()
    //    {
    //        const string sExceptionMsg = "[Exception] TRankingThread::Execute";
    //        //@ Unsupported property or method(C): 'Terminated'
    //        while (!this.Terminated)
    //        {
    //            try {
    //                Run();
    //            }
    //            catch {
    //                DBShare.MainOutMessage(sExceptionMsg);
    //            }
    //            this.Sleep(1);
    //        }
    //    }

    //    private void RefRanking()
    //    {
    //        int I;
    //        int nIndex;
    //        THumDataInfo ChrRecord;
    //        THumInfo HumRecord;
    //        TUserLevelRanking HumRanking;
    //        THeroLevelRanking HeroRanking;
    //        TUserMasterRanking MasterRanking;
    //        List<string> HumRankingList;
    //        List<string> WarriorRankingList;
    //        List<string> WizzardRankingList;
    //        List<string> MonkRankingList;
    //        List<string> HeroRankingList;
    //        List<string> HeroWarriorRankingList;
    //        List<string> HeroWizzardRankingList;
    //        List<string> HeroMonkRankingList;
    //        List<string> MasterRankingList;
    //        List<string> QuickList;
    //        if (DBShare.g_boStartService && (!DBShare.g_boRemoteClose) && (!DBShare.g_boSoftClose))
    //        {
    //            HumRankingList = new List<string>();
    //            WarriorRankingList = new List<string>();
    //            WizzardRankingList = new List<string>();
    //            MonkRankingList = new List<string>();
    //            HeroRankingList = new List<string>();
    //            HeroWarriorRankingList = new List<string>();
    //            HeroWizzardRankingList = new List<string>();
    //            HeroMonkRankingList = new List<string>();
    //            MasterRankingList = new List<string>();
    //            QuickList = new List<string>();
    //            QuickList.Add(DBShare.g_HumCharDB.m_QuickList);
    //            try {
    //                try {
    //                    if (DBShare.g_HumCharDB.OpenX())
    //                    {
    //                        for (I = 0; I < QuickList.Count; I ++ )
    //                        {
    //                            if (!DBShare.g_boStartService || DBShare.g_boRemoteClose || DBShare.g_boSoftClose)
    //                            {
    //                                break;
    //                            }
    //                            if ((DBShare.g_HumCharDB.GetX(I, HumRecord) >= 0) && (!HumRecord.boDeleted))
    //                            {
    //                                try {
    //                                    if (DBShare.g_HumDataDB.OpenX())
    //                                    {
    //                                        nIndex = DBShare.g_HumDataDB.Index(QuickList[I]);
    //                                        if ((nIndex >= 0) && (DBShare.g_HumDataDB.GetX(nIndex, ChrRecord) >= 0) && (!ChrRecord.Header.boDeleted) && (ChrRecord.Data.Abil.Level >= DBShare.g_nRankingMinLevel) && (ChrRecord.Data.Abil.Level <= DBShare.g_nRankingMaxLevel))
    //                                        {
    //                                            if (ChrRecord.Header.boIsHero)
    //                                            {
    //                                                HeroRanking = new THeroLevelRanking();
    //                                                HeroRanking.nLevel = ChrRecord.Data.Abil.Level;
    //                                                HeroRanking.sChrName = ChrRecord.Data.sMasterName;
    //                                                HeroRanking.sHeroName = ChrRecord.Data.sChrName;
    //                                                HeroRankingList.Add((HeroRanking.nLevel).ToString(), ((HeroRanking) as Object));
    //                                                switch(ChrRecord.Data.btJob)
    //                                                {
    //                                                    case 0:
    //                                                        HeroWarriorRankingList.Add((HeroRanking.nLevel).ToString(), ((HeroRanking) as Object));
    //                                                        break;
    //                                                    case 1:
    //                                                        HeroWizzardRankingList.Add((HeroRanking.nLevel).ToString(), ((HeroRanking) as Object));
    //                                                        break;
    //                                                    case 2:
    //                                                        HeroMonkRankingList.Add((HeroRanking.nLevel).ToString(), ((HeroRanking) as Object));
    //                                                        break;
    //                                                }
    //                                            }
    //                                            else
    //                                            {
    //                                                HumRanking = new TUserLevelRanking();
    //                                                HumRanking.nLevel = ChrRecord.Data.Abil.Level;
    //                                                HumRanking.sChrName = ChrRecord.Data.sChrName;
    //                                                HumRankingList.Add((HumRanking.nLevel).ToString(), ((HumRanking) as Object));
    //                                                switch(ChrRecord.Data.btJob)
    //                                                {
    //                                                    case 0:
    //                                                        WarriorRankingList.Add((HumRanking.nLevel).ToString(), ((HumRanking) as Object));
    //                                                        break;
    //                                                    case 1:
    //                                                        WizzardRankingList.Add((HumRanking.nLevel).ToString(), ((HumRanking) as Object));
    //                                                        break;
    //                                                    case 2:
    //                                                        MonkRankingList.Add((HumRanking.nLevel).ToString(), ((HumRanking) as Object));
    //                                                        break;
    //                                                }
    //                                                if (ChrRecord.Data.wMasterCount > 0)
    //                                                {
    //                                                    MasterRanking = new TUserMasterRanking();
    //                                                    MasterRanking.nMasterCount = ChrRecord.Data.wMasterCount;
    //                                                    MasterRanking.sChrName = ChrRecord.Data.sChrName;
    //                                                    MasterRankingList.Add((MasterRanking.nMasterCount).ToString(), ((MasterRanking) as Object));
    //                                                }
    //                                            }
    //                                        }
    //                                    }
    //                                } finally {
    //                                    DBShare.g_HumDataDB.CloseX();
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //                catch {
    //                    DBShare.MainOutMessage("[Exception] RefRanking0");
    //                }
    //            } finally {
    //                DBShare.g_HumCharDB.CloseX();
    //            }
    //            //@ Unsupported function or procedure: 'EnterCriticalSection'
    //            EnterCriticalSection(DBShare.g_Ranking_CS);
    //            try {
    //                try {
    //                    for (I = 0; I < DBShare.g_HumRanking.Count; I ++ )
    //                    {
    //                        //@ Unsupported property or method(A): 'Values'
    //                        //@ Unsupported function or procedure: 'Dispose'
    //                        Dispose(((TUserLevelRanking)(DBShare.g_HumRanking.Values[I])));
    //                    }
    //                }
    //                catch {
    //                    DBShare.MainOutMessage("[Exception] RefRanking1");
    //                }
    //                //
    //                // for I := 0 to g_WarriorRanking.Count - 1 do begin
    //                // Dispose(pTUserLevelRanking(g_WarriorRanking.Objects[I]));
    //                // end;
    //                // for I := 0 to g_WizzardRanking.Count - 1 do begin
    //                // Dispose(pTUserLevelRanking(g_WizzardRanking.Objects[I]));
    //                // end;
    //                // for I := 0 to g_MonkRanking.Count - 1 do begin
    //                // Dispose(pTUserLevelRanking(g_MonkRanking.Objects[I]));
    //                // end;
    //                //
    //                try {
    //                    for (I = 0; I < DBShare.g_HeroRanking.Count; I ++ )
    //                    {
    //                        //@ Unsupported property or method(A): 'Values'
    //                        //@ Unsupported function or procedure: 'Dispose'
    //                        Dispose(((THeroLevelRanking)(DBShare.g_HeroRanking.Values[I])));
    //                    }
    //                }
    //                catch {
    //                    DBShare.MainOutMessage("[Exception] RefRanking2");
    //                }
    //                //
    //                // for I := 0 to g_HeroWarriorRanking.Count - 1 do begin
    //                // Dispose(pTHeroLevelRanking(g_HeroWarriorRanking.Objects[I]));
    //                // end;
    //                // for I := 0 to g_HeroWizzardRanking.Count - 1 do begin
    //                // Dispose(pTHeroLevelRanking(g_HeroWizzardRanking.Objects[I]));
    //                // end;
    //                // for I := 0 to g_HeroMonkRanking.Count - 1 do begin
    //                // Dispose(pTHeroLevelRanking(g_HeroMonkRanking.Objects[I]));
    //                // end;
    //                //
    //                try {
    //                    for (I = 0; I < DBShare.g_MasterRanking.Count; I ++ )
    //                    {
    //                        //@ Unsupported property or method(A): 'Values'
    //                        //@ Unsupported function or procedure: 'Dispose'
    //                        Dispose(((TUserMasterRanking)(DBShare.g_MasterRanking.Values[I])));
    //                    }
    //                }
    //                catch {
    //                    DBShare.MainOutMessage("[Exception] RefRanking3");
    //                }
    //                try {
    //                    DBShare.g_HumRanking.Clear();
    //                    DBShare.g_WarriorRanking.Clear();
    //                    DBShare.g_WizzardRanking.Clear();
    //                    DBShare.g_MonkRanking.Clear();
    //                    DBShare.g_HeroRanking.Clear();
    //                    DBShare.g_HeroWarriorRanking.Clear();
    //                    DBShare.g_HeroWizzardRanking.Clear();
    //                    DBShare.g_HeroMonkRanking.Clear();
    //                    DBShare.g_MasterRanking.Clear();
    //                    DBShare.g_HumRanking.Add(HumRankingList);
    //                    DBShare.g_WarriorRanking.Add(WarriorRankingList);
    //                    DBShare.g_WizzardRanking.Add(WizzardRankingList);
    //                    DBShare.g_MonkRanking.Add(MonkRankingList);
    //                    DBShare.g_HeroRanking.Add(HeroRankingList);
    //                    DBShare.g_HeroWarriorRanking.Add(HeroWarriorRankingList);
    //                    DBShare.g_HeroWizzardRanking.Add(HeroWizzardRankingList);
    //                    DBShare.g_HeroMonkRanking.Add(HeroMonkRankingList);
    //                    DBShare.g_MasterRanking.Add(MasterRankingList);
    //                    if (DBShare.g_HumRanking.Count > 0)
    //                    {
    //                        DBShare.g_HumRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_WarriorRanking.Count > 0)
    //                    {
    //                        DBShare.g_WarriorRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_WizzardRanking.Count > 0)
    //                    {
    //                        DBShare.g_WizzardRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_MonkRanking.Count > 0)
    //                    {
    //                        DBShare.g_MonkRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_HeroRanking.Count > 0)
    //                    {
    //                        DBShare.g_HeroRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_HeroWarriorRanking.Count > 0)
    //                    {
    //                        DBShare.g_HeroWarriorRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_HeroWizzardRanking.Count > 0)
    //                    {
    //                        DBShare.g_HeroWizzardRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_HeroMonkRanking.Count > 0)
    //                    {
    //                        DBShare.g_HeroMonkRanking.NumberSort(true);
    //                    }
    //                    if (DBShare.g_MasterRanking.Count > 0)
    //                    {
    //                        DBShare.g_MasterRanking.NumberSort(true);
    //                    }
    //                }
    //                catch {
    //                    DBShare.MainOutMessage("[Exception] RefRanking4");
    //                }
    //            } finally {
    //                //@ Unsupported function or procedure: 'LeaveCriticalSection'
    //                LeaveCriticalSection(DBShare.g_Ranking_CS);
    //            }
    //            //@ Unsupported property or method(C): 'Free'
    //            QuickList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            HumRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            WarriorRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            WizzardRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            MonkRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            HeroRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            HeroWarriorRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            HeroWizzardRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            HeroMonkRankingList.Free;
    //            //@ Unsupported property or method(C): 'Free'
    //            MasterRankingList.Free;
    //        }
    //    }

    //    private void Run()
    //    {
    //        ushort Hour;
    //        ushort Min;
    //        ushort Sec;
    //        ushort MSec;
    //        uint dwTime;
    //        if (DBShare.g_boCanRanking && DBShare.g_boAutoRefRanking && DBShare.g_boStartService && (!DBShare.g_boRemoteClose) && (!DBShare.g_boSoftClose))
    //        {
    //            switch(DBShare.g_nAutoRefRankingType)
    //            {
    //                case 0:
    //                    if (DBShare.g_TodayDate != DateTime.Today)
    //                    {
    //                        Hour = DateTime.Now.Hour;
    //                        Min = DateTime.Now.Minute;
    //                        Sec = DateTime.Now.Second;
    //                        MSec = DateTime.Now.Millisecond;
    //                        if ((Hour == DBShare.g_nRefRankingHour1) && (Min == DBShare.g_nRefRankingMinute1))
    //                        {
    //                            DBShare.g_TodayDate = DateTime.Today;
    //                            RefRanking();
    //                        }
    //                    }
    //                    break;
    //                case 1:
    //                    dwTime = DBShare.g_nRefRankingHour2 * 60 * 60 * 1000 + DBShare.g_nRefRankingMinute2 * 60 * 1000;
    //                    //@ Unsupported function or procedure: 'GetTickCount'
    //                    if (GetTickCount - DBShare.g_dwAutoRefRankingTick > dwTime)
    //                    {
    //                        //@ Unsupported function or procedure: 'GetTickCount'
    //                        DBShare.g_dwAutoRefRankingTick = GetTickCount;
    //                        RefRanking();
    //                    }
    //                    break;
    //            }
    //        }
    //    }

    //} // end TRankingThread
}

//namespace Main.Units
//{
//    public class Main
//    {
//        public static TFrmMain FrmMain = null;
//        public static TRankingThread RankingThread = null;
//    } // end Main

//}
//}
