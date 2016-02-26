using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public class TPlayRobotObject
    {
        public string m_sCharName = String.Empty;
        public string m_sScriptFileName = String.Empty;
        public List<TAutoRunInfo> m_AutoRunList = null;
        private bool m_boRunOnWeek = false;

        public TPlayRobotObject()
        {
            m_AutoRunList = new List<TAutoRunInfo>();
            m_boRunOnWeek = false;
        }

        ~TPlayRobotObject()
        {
            ClearScript();
        }

        // ===========================人物个人机器人=====================================
        private void AutoRun(TAutoRunInfo AutoRunInfo, Object PlayObject)
        {
            if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > AutoRunInfo.dwRunTimeLen)
            {
                switch(AutoRunInfo.nRunCmd)
                {
                    case SDK.nRONPCLABLEJMP:
                        switch(AutoRunInfo.nMoethod)
                        {
                            case SDK.nRODAY:// 24 * 60 * 60 * 1000
                                if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 86400000 * ((uint)AutoRunInfo.nParam1))
                                {
                                    AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                    M2Share.g_RobotNPC.GotoLable(((TPlayObject)(PlayObject)), AutoRunInfo.sParam2, false);
                                }
                                break;
                            case SDK.nROHOUR:// 60 * 60 * 1000
                                if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 3600000 * ((uint)AutoRunInfo.nParam1))
                                {
                                    AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                    M2Share.g_RobotNPC.GotoLable(((TPlayObject)(PlayObject)), AutoRunInfo.sParam2, false);
                                }
                                break;
                            case SDK.nROMIN:// 60 * 1000
                                if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 60000 * ((uint)AutoRunInfo.nParam1))
                                {

                                    AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                    M2Share.g_RobotNPC.GotoLable(((TPlayObject)(PlayObject)), AutoRunInfo.sParam2, false);
                                }
                                break;
                            case SDK.nROSEC:
                                if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 1000 * ((uint)AutoRunInfo.nParam1))
                                {
                                    AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                    M2Share.g_RobotNPC.GotoLable(((TPlayObject)(PlayObject)), AutoRunInfo.sParam2, false);
                                }
                                break;
                            case SDK.nRUNONWEEK:
                                AutoRunOfOnWeek(AutoRunInfo, PlayObject);
                                break;
                            case SDK.nRUNONDAY:
                                AutoRunOfOnDay(AutoRunInfo, PlayObject);
                                break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 星期几运行
        /// </summary>
        /// <param name="AutoRunInfo"></param>
        /// <param name="PlayObject"></param>
        private void AutoRunOfOnDay(TAutoRunInfo AutoRunInfo, Object PlayObject)
        {
            string sMIN = string.Empty;
            string sHOUR = string.Empty;
            string sLineText = string.Empty;
            string sLabel = string.Empty;
            sLineText = AutoRunInfo.sParam1;
            sLineText = HUtil32.GetValidStr3(sLineText, ref sHOUR, new string[] { ":" });
            sLineText = HUtil32.GetValidStr3(sLineText, ref sMIN, new string[] { ":" });
            int nHOUR = HUtil32.Str_ToInt(sHOUR, -1);
            int nMIN = HUtil32.Str_ToInt(sMIN, -1);
            sLabel = AutoRunInfo.sParam2;
            int wHour = DateTime.Now.Hour;
            int wMin = DateTime.Now.Minute;
            int wSec = DateTime.Now.Second;
            int wMSec = DateTime.Now.Millisecond;
            if ((nHOUR >= 0 && nHOUR <= 24) && (nMIN >= 0 && nMIN <= 60))
            {
                if ((wHour == nHOUR))
                {
                    if ((wMin == nMIN))
                    {
                        if (!AutoRunInfo.boStatus)
                        {
                            M2Share.g_RobotNPC.GotoLable(((TPlayObject)(PlayObject)), AutoRunInfo.sParam2, false);
                            AutoRunInfo.boStatus = true;
                        }
                    }
                    else
                    {
                        AutoRunInfo.boStatus = false;
                    }
                }
            }
        }

        private void AutoRunOfOnWeek(TAutoRunInfo AutoRunInfo, Object PlayObject)
        {
            int nMIN;
            int nHOUR;
            int nWeek;
            DayOfWeek wWeek;
            int wHour;
            int wMin;
            int wSec;
            int wMSec;
            string sMIN = string.Empty;
            string sHOUR = string.Empty;
            string sWeek = string.Empty;
            string sLineText = string.Empty;
            string sLabel = string.Empty;
            sLineText = AutoRunInfo.sParam1;
            sLineText = HUtil32.GetValidStr3(sLineText, ref sWeek, new string[] {":"});
            sLineText = HUtil32.GetValidStr3(sLineText, ref sHOUR, new string[] {":"});
            sLineText = HUtil32.GetValidStr3(sLineText, ref sMIN, new string[] {":"});
            nWeek = HUtil32.Str_ToInt(sWeek,  -1);
            nHOUR = HUtil32.Str_ToInt(sHOUR,  -1);
            nMIN = HUtil32.Str_ToInt(sMIN,  -1);
            sLabel = AutoRunInfo.sParam2;
            wHour = DateTime.Now.Hour;
            wMin = DateTime.Now.Minute;
            wSec = DateTime.Now.Second;
            wMSec = DateTime.Now.Millisecond;
            wWeek = DateTime.Now.DayOfWeek;
            if ((nWeek >= 1 && nWeek<= 7) && (nHOUR >= 0 && nHOUR<= 24) && (nMIN >= 0 && nMIN<= 60))
            {
                if ((wWeek.Equals(nWeek)) && (wHour == nHOUR))
                {
                    if ((wMin == nMIN))
                    {
                        if (!AutoRunInfo.boStatus)
                        {
                            M2Share.g_RobotNPC.GotoLable(((TPlayObject)(PlayObject)), AutoRunInfo.sParam2, false);
                            AutoRunInfo.boStatus = true;
                        }
                    }
                    else
                    {
                        AutoRunInfo.boStatus = false;
                    }
                }
            }
        }

        private void ClearScript()
        {
            if (m_AutoRunList.Count > 0)
            {
                for (int I = 0; I < m_AutoRunList.Count; I ++ )
                {
                    if (m_AutoRunList[I] != null)
                    {
                        //Dispose(((TAutoRunInfo)(m_AutoRunList[I])));
                    }
                }
            }
            m_AutoRunList.Clear();
        }

        // 是否已执行操作；
        public void LoadScript()
        {
            TStringList LoadList;
            string sFileName=string.Empty;
            string sLineText=string.Empty;
            string sActionType=string.Empty;
            string sRunCmd=string.Empty;
            string sMoethod=string.Empty;
            string sParam1=string.Empty;
            string sParam2=string.Empty;
            string sParam3=string.Empty;
            string sParam4=string.Empty;
            TAutoRunInfo AutoRunInfo;
            sFileName = M2Share.g_Config.sEnvirDir + "Robot_def\\" + m_sScriptFileName + ".txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count > 0)
                {
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        sLineText = LoadList[I];
                        if ((sLineText != "") && (sLineText[0] != ';'))
                        {
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sActionType, new string[] {" ", "/", "\09"});
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sRunCmd, new string[] {" ", "/", "\09"});
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sMoethod, new string[] {" ", "/", "\09"});
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sParam1, new string[] {" ", "/", "\09"});
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sParam2, new string[] {" ", "/", "\09"});
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sParam3, new string[] {" ", "/", "\09"});
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sParam4, new string[] {" ", "/", "\09"});
                            if (string.Compare(sActionType, SDK.sROAUTORUN, true) == 0)
                            {
                                if (string.Compare(sRunCmd, SDK.sRONPCLABLEJMP, true) == 0)
                                {
                                    AutoRunInfo = new TAutoRunInfo();
                                    AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                    AutoRunInfo.dwRunTimeLen = 0;
                                    AutoRunInfo.boStatus = false;
                                    AutoRunInfo.nRunCmd = SDK.nRONPCLABLEJMP;
                                    if (string.Compare(sMoethod, SDK.sRODAY, true) == 0)
                                    {
                                        AutoRunInfo.nMoethod = SDK.nRODAY;
                                    }
                                    if (string.Compare(sMoethod, SDK.sROHOUR, true) == 0)
                                    {
                                        AutoRunInfo.nMoethod = SDK.nROHOUR;
                                    }
                                    if (string.Compare(sMoethod, SDK.sROMIN, true) == 0)
                                    {
                                        AutoRunInfo.nMoethod = SDK.nROMIN;
                                    }
                                    if (string.Compare(sMoethod, SDK.sROSEC, true) == 0)
                                    {
                                        AutoRunInfo.nMoethod = SDK.nROSEC;
                                    }
                                    if (string.Compare(sMoethod, SDK.sRUNONWEEK, true) == 0)
                                    {
                                        AutoRunInfo.nMoethod = SDK.nRUNONWEEK;
                                    }
                                    if (string.Compare(sMoethod, SDK.sRUNONDAY, true) == 0)
                                    {
                                        AutoRunInfo.nMoethod = SDK.nRUNONDAY;
                                    }
                                    AutoRunInfo.sParam1 = sParam1;
                                    AutoRunInfo.sParam2 = sParam2;
                                    AutoRunInfo.sParam3 = sParam3;
                                    AutoRunInfo.sParam4 = sParam4;
                                    AutoRunInfo.nParam1 = HUtil32.Str_ToInt(sParam1, 1);
                                    m_AutoRunList.Add(AutoRunInfo);
                                }
                            }
                        }
                    }
                }
               // Dispose(LoadList);
            }
        }

        public void ReloadScript()
        {
            ClearScript();
            LoadScript();
        }

        /// <summary>
        /// 运行机器人
        /// </summary>
        /// <param name="PlayObject"></param>
        public void Run(Object PlayObject)
        {
            foreach (var AutoRunInfo in m_AutoRunList)
            {
                if (AutoRunInfo != null)
                {
                    AutoRun(AutoRunInfo, PlayObject);
                }
            }
        }

    }
}

