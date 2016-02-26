using DBServer.Entity;
using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DBServer.DataAccess;

namespace DBServer
{
    public class DBShare
    {
        public static TFileHumDB g_HumCharDB = null;
        public static TFileDB g_HumDataDB = null;
        public static string g_sHumDBFilePath = ".\\FDB\\";
        public static string g_sDataDBFilePath = ".\\FDB\\";
        public static string g_sFeedPath = ".\\FDB\\";
        public static string g_sBackupPath = ".\\FDB\\";
        public static string g_sConnectPath = ".\\Connects\\";
        public static string g_sLogPath = ".\\Log\\";
        public static int g_nServerPort = 6000;
        public static string g_sServerAddr = "0.0.0.0";
        public static int g_nGatePort = 5100;
        public static string g_sGateAddr = "0.0.0.0";
        public static int g_nIDServerPort = 5600;
        public static string g_sIDServerAddr = "127.0.0.1";
        public static string g_sServerName = "Lite";
        public static string g_sConfFileName = ".\\Dbsrc.ini";
        public static string g_sGateConfFileName = ".\\!ServerInfo.txt";
        public static string g_sServerIPConfFileNmae = ".\\!AddrTable.txt";
        public static string g_sGateIDConfFileName = ".\\SelectID.txt";
        public static bool g_boStartService = false;
        public static bool g_boRemoteClose = false;
        public static bool g_boSoftClose = false;
        public static object g_HumDB_CS = null;
        public static object g_Ranking_CS = null;
        public static string g_sMapFile = String.Empty;
        public static GameFramework.TStringList g_DenyChrNameList = null;
        public static GameFramework.TStringList g_ServerIPList = null;
        public static Hashtable g_GateIDList = null;
        public static Hashtable g_MapList = null;
        public static TRouteInfo[] g_RouteInfo = new TRouteInfo[19 + 1];
        public static GameFramework.TStringList g_ClearMakeIndex = null;
        public static bool g_boDynamicIPMode = false;
        public static List<TModuleInfo> g_ModuleList = null;
        public static uint g_dwShowModuleTick = 0;
        public static Hashtable g_HumRanking = null;
        public static Hashtable g_WarriorRanking = null;
        public static Hashtable g_WizzardRanking = null;
        public static Hashtable g_MonkRanking = null;
        public static Hashtable g_HeroRanking = null;
        public static Hashtable g_HeroWarriorRanking = null;
        public static Hashtable g_HeroWizzardRanking = null;
        public static Hashtable g_HeroMonkRanking = null;
        public static Hashtable g_MasterRanking = null;
        public static GameFramework.TStringList g_DenyRankingChrList = null;
        public static TGStringList g_MainLogMsgList = null;
        public static bool g_boShowLogMsg = true;
        public static uint g_dwShowMainLogTick = 0;
        public static int g_nRankingMinLevel = 20;
        public static int g_nRankingMaxLevel = 500;
        public static bool g_boAutoRefRanking = true;
        public static int g_nAutoRefRankingType = 0;
        public static uint g_dwAutoRefRankingTick = 0;
        public static int g_nRefRankingHour1 = 0;
        public static int g_nRefRankingHour2 = 0;
        public static int g_nRefRankingMinute1 = 5;
        public static int g_nRefRankingMinute2 = 5;
        public static DateTime g_TodayDate;
        public static bool g_boAllowAddChar = true;
        public static bool g_boAllowDelChar = true;
        public static bool g_boAllowGetBackChar = true;
        public static int g_nStoreDeleteCharDay = 7;
        public static int g_nAllowDelCharCount = 1;
        public static DateTime g_RefDate;
        public static List<string> g_MagicList = null;
        public static List<string> g_StdItemList = null;
        public static long g_dwGameCenterHandle = 0;
        public static string g_sNowStartServer = "正在启动数据库服务器...";
        public static string g_sNowStartServerOK = "数据库服务器启动完成...";
        public static int g_nWorkStatus = 0;
        public static uint g_dwWorkStatusTick = 0;
        public static int g_nCreateHumCount = 0;
        public static int g_nDeleteHumCount = 0;
        public static int g_nLoadHumCount = 0;
        public static int g_nSaveHumCount = 0;
        public static int g_nCreateHeroCount = 0;
        public static int g_nDeleteHeroCount = 0;
        public static int g_nLoadHeroCount = 0;
        public static int g_nSaveHeroCount = 0;
        public static bool g_boDenyChrName = false;
        public static bool g_boMinimize = false;
        public static bool g_boDeleteChrName = false;
        public static bool g_boRandomNumber = false;
        public static bool g_boCanRanking = true;
        public static GameFramework.TStringList g_AICharNameList = null;
        public const string g_sVersion = "程序版本: 1.00 Build 20110123";
        public const string g_sUpDateTime = "更新日期: 2011/01/23";
        public const string g_sProgram = "程序制作: ";
        public const string g_sWebSite = "程序网站: ";

        public static void UnLoadMagicList()
        {
            g_MagicList.Clear();
        }

        public static void UnLoadStdItemList()
        {
            g_StdItemList.Clear();
        }

        public static string GetStdItemName(int nPosition)
        {
            string result = "";
            if ((nPosition - 1 >= 0) && (nPosition < g_StdItemList.Count))
            {
                result = g_StdItemList[nPosition - 1];
            }
            return result;
        }

        public static string GetMagicName(ushort wMagicId)
        {
            string result;
            int I;
            TMagic Magic;
            result = "";
            for (I = 0; I < g_MagicList.Count; I++)
            {
                //@ Unsupported property or method(A): 'Values'
                //if (((int)g_MagicList[I]) == wMagicId)
                //{
                //    result = g_MagicList[I];
                //    break;
                //}
                // Magic := g_MagicList.Items[I];
                // if Magic <> nil then begin
                // if Magic.wMagicId = wMagicId then begin
                // Result := Magic.sMagicName;
                // break;
                // end;
                // end;
            }
            return result;
        }

        public static TModuleInfo AddModule(TModuleInfo ModuleInfo)
        {
            TModuleInfo result;
            int I;
            TModuleInfo Module;
            result = null;
            for (I = 0; I < g_ModuleList.Count; I++)
            {
                if (((g_ModuleList[I]) as TModuleInfo).Module == ModuleInfo.Module)
                {
                    result = ((g_ModuleList[I]) as TModuleInfo);
                    return result;
                }
            }
            Module = new TModuleInfo();
            Module = ModuleInfo;
            g_ModuleList.Add(Module);
            result = Module;
            return result;
        }

        public static void RemoveModule(Object Module)
        {
            int I;
            for (I = 0; I < g_ModuleList.Count; I++)
            {
                if (g_ModuleList[I].Module == Module)
                {
                    //@ Unsupported property or method(A): 'Values'
                    //@ Unsupported function or procedure: 'Dispose'
                    //Dispose(((g_ModuleList.Values[I]) as TModuleInfo));
                    g_ModuleList.RemoveAt(I);
                    break;
                }
            }
        }

        public static void UpdateModule(TModuleInfo ModuleInfo)
        {
            for (int I = 0; I < g_ModuleList.Count; I++)
            {
                if (g_ModuleList[I].Module == ModuleInfo.Module)
                {
                    g_ModuleList[I] = ModuleInfo;
                    return;
                }
            }

            //TModuleInfo Module = ModuleInfo;
            g_ModuleList.Add(ModuleInfo);
        }

        //public static List<string> GetRankingList(int nTablePage, int nPageType)
        //{
        //    List<string> result;
        //    result = null;
        //    switch(nTablePage)
        //    {
        //        case 0:
        //            switch(nPageType)
        //            {
        //                case 0:
        //                    result = g_HumRanking;
        //                    break;
        //                case 1:
        //                    result = g_WarriorRanking;
        //                    break;
        //                case 2:
        //                    result = g_WizzardRanking;
        //                    break;
        //                case 3:
        //                    result = g_MonkRanking;
        //                    break;
        //            }
        //            break;
        //        case 1:
        //            switch(nPageType)
        //            {
        //                case 0:
        //                    result = g_HeroRanking;
        //                    break;
        //                case 1:
        //                    result = g_HeroWarriorRanking;
        //                    break;
        //                case 2:
        //                    result = g_HeroWizzardRanking;
        //                    break;
        //                case 3:
        //                    result = g_HeroMonkRanking;
        //                    break;
        //            }
        //            break;
        //        case 2:
        //            result = g_MasterRanking;
        //            break;
        //    }
        //    return result;
        //}

        public static bool CheckServerIP(string sIP)
        {
            bool result;
            int I;
            result = false;
            for (I = 0; I < g_ServerIPList.Count; I++)
            {
                if ((sIP).ToLower().CompareTo((g_ServerIPList[I]).ToLower()) == 0)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static bool LoadChrNameList(string sFileName)
        {
            bool result;
            int I;
            result = false;
            if (File.Exists(sFileName))
            {
                g_DenyChrNameList.Clear();
                g_DenyChrNameList.LoadFromFile(sFileName);
                I = 0;
                while (true)
                {
                    if (g_DenyChrNameList.Count <= I)
                    {
                        break;
                    }
                    if (g_DenyChrNameList[I].Trim() == "")
                    {
                        g_DenyChrNameList.RemoveAt(I);
                        continue;
                    }
                    I++;
                }
                result = true;
            }
            return result;
        }

        public static bool LoadAICharNameList(string sFileName)
        {
            bool result;
            int I;
            result = false;
            if (File.Exists(sFileName))
            {
                g_AICharNameList.Clear();
                g_AICharNameList.LoadFromFile(sFileName);
                I = 0;
                while (true)
                {
                    if (g_AICharNameList.Count <= I)
                    {
                        break;
                    }
                    if (g_AICharNameList[I].Trim() == "")
                    {
                        g_AICharNameList.RemoveAt(I);
                        continue;
                    }
                    I++;
                }
                result = true;
            }
            return result;
        }

        public static bool LoadClearMakeIndexList(string sFileName)
        {
            bool result;
            int I;
            int nIndex;
            string sLineText;
            result = false;
            if (File.Exists(sFileName))
            {
                //@ Unsupported property or method(A): 'LoadFromFile'
                g_ClearMakeIndex.LoadFromFile(sFileName);
                I = 0;
                while (true)
                {
                    if (g_ClearMakeIndex.Count <= I)
                    {
                        break;
                    }
                    sLineText = g_ClearMakeIndex[I];

                    //@ Undeclared identifier(3): 'Str_ToInt'
                    nIndex = GameFramework.HUtil32.Str_ToInt(sLineText, -1);
                    if (nIndex < 0)
                    {
                        g_ClearMakeIndex.RemoveAt(I);
                        continue;
                    }

                    //@ Unsupported property or method(A): 'Values'
                    g_ClearMakeIndex[I] = Convert.ToString(nIndex);
                    I++;
                }
                result = true;
            }
            return result;
        }

        public static void LoadServerInfo()
        {
            int I;
            GameFramework.TStringList LoadList;
            int nRouteIdx;
            int nGateIdx;
            int nServerIndex;
            string sLineText;
            string sSelGateIPaddr = string.Empty;
            string sGameGateIPaddr = string.Empty;
            string sGameGate;
            string sGameGatePort = string.Empty;
            string sMapName = string.Empty;
            string sMapInfo;
            string sServerIndex;
            if (!File.Exists(g_sGateConfFileName))//如果文件不存在 则生成!serverinfo.txt
            {
                LoadList = new GameFramework.TStringList();
                LoadList.Add("127.0.0.1 127.0.0.1 7200");
                try
                {
                    LoadList.SaveToFile(g_sGateConfFileName);
                }
                catch
                {
                }
            }
            if (File.Exists(g_sGateConfFileName))//如果文件存在
            {
                LoadList = new GameFramework.TStringList();
                try
                {
                    LoadList.LoadFromFile(g_sGateConfFileName);
                }
                catch
                {
                }
                nRouteIdx = 0;
                nGateIdx = 0;
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText != "") && (sLineText[1] != ';'))
                    {
                        sGameGate = GameFramework.HUtil32.GetValidStr3(sLineText, ref sSelGateIPaddr, new string[] { " ", "\09" });
                        if ((sGameGate == "") || (sSelGateIPaddr == ""))//如果为空继续
                        {
                            continue;
                        }
                        g_RouteInfo[nRouteIdx].sSelGateIP = sSelGateIPaddr.Trim();//第一个IP 选择网关IP
                        g_RouteInfo[nRouteIdx].nGateCount = 0;
                        nGateIdx = 0;
                        while ((sGameGate != ""))//如果剩下的字符串不为空  如果一直不为空
                        {
                            sGameGate = GameFramework.HUtil32.GetValidStr3(sGameGate, ref sGameGateIPaddr, new string[] { " ", "\09" });
                            sGameGate = GameFramework.HUtil32.GetValidStr3(sGameGate, ref sGameGatePort, new string[] { " ", "\09" });
                            g_RouteInfo[nRouteIdx].sGameGateIP.Add(sGameGateIPaddr.Trim());//游戏网关IP
                            g_RouteInfo[nRouteIdx].nGameGatePort.Add(GameFramework.HUtil32.Str_ToInt(sGameGatePort, 0));
                            nGateIdx++;
                        }
                        g_RouteInfo[nRouteIdx].nGateCount = nGateIdx;
                        nRouteIdx++;
                    }
                }
                LoadList.Dispose();
            }
            GameFramework.IniFile Conf = new GameFramework.IniFile(g_sConfFileName);//Dbsrc.ini
            g_sMapFile = Conf.ReadString("Setup", "MapFile", g_sMapFile);
            g_MapList.Clear();
            if (File.Exists(g_sMapFile))
            {
                LoadList = new GameFramework.TStringList();
                try
                {
                    LoadList.LoadFromFile(g_sMapFile);
                }
                catch
                {
                }
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] == '['))
                    {
                        sLineText = GameFramework.HUtil32.ArrestStringEx(sLineText, "[", "]", ref sMapName);
                        sMapInfo = GameFramework.HUtil32.GetValidStr3(sMapName, ref sMapName, new string[] { " ", "\09" });
                        sServerIndex = GameFramework.HUtil32.GetValidStr3(sMapInfo, ref sMapInfo, new string[] { " ", "\09" }).Trim();
                        nServerIndex = GameFramework.HUtil32.Str_ToInt(sServerIndex, 0);
                        g_MapList.Add(sMapName, ((nServerIndex) as Object));
                    }
                }
            }
        }

        public static void LoadGateID()
        {
            int I;
            GameFramework.TStringList LoadList;
            string sLineText;
            string sID = string.Empty;
            string sIPaddr = string.Empty;
            int nID;
            g_GateIDList.Clear();
            if (File.Exists(g_sGateIDConfFileName))
            {
                LoadList = new GameFramework.TStringList();
                LoadList.LoadFromFile(g_sGateIDConfFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText == "") || (sLineText[1] == ';'))
                    {
                        continue;
                    }
                    sLineText = GameFramework.HUtil32.GetValidStr3(sLineText, ref sID, new string[] { " ", "\09" });
                    sLineText = GameFramework.HUtil32.GetValidStr3(sLineText, ref sIPaddr, new string[] { " ", "\09" });
                    nID = GameFramework.HUtil32.Str_ToInt(sID, -1);
                    if (nID < 0)
                    {
                        continue;
                    }
                    g_GateIDList.Add(sIPaddr, ((nID) as Object));
                }
            }
        }

        public static int GetGateID(string sIPaddr)
        {
            int result;
            int I;
            result = 0;
            for (I = 0; I < g_GateIDList.Count; I++)
            {
                if (g_GateIDList[I] == sIPaddr)
                {
                    //@ Unsupported property or method(A): 'Values'
                    result = Convert.ToInt32(g_GateIDList[I]);
                    break;
                }
            }
            return result;
        }

        public static void LoadIPTable()
        {
            if (!File.Exists(g_sServerIPConfFileNmae))
            {
                g_ServerIPList.Add("127.0.0.1");
                try
                {
                    g_ServerIPList.SaveToFile(g_sServerIPConfFileNmae);
                }
                catch
                {
                }
            }
            else
            {
                g_ServerIPList.Clear();
                try
                {
                    g_ServerIPList.LoadFromFile(g_sServerIPConfFileNmae);
                }
                catch
                {
                    MainOutMessage("加载IP列表文件 " + g_sServerIPConfFileNmae + " 出错！！！");
                }
            }
        }

        public static string GateRouteIP_GetRoute(TRouteInfo RouteInfo, ref int nGatePort)
        {
            int nGateIndex;
            nGateIndex = (new System.Random()).Next(RouteInfo.nGateCount);
            string result = RouteInfo.sGameGateIP[nGateIndex];
            nGatePort = RouteInfo.nGameGatePort[nGateIndex];
            return result;
        }

        public static string GateRouteIP(string sGateIP, ref int nPort)
        {
            string result;
            int I;
            TRouteInfo RouteInfo;
            nPort = 0;
            result = "";
            for (I = g_RouteInfo.GetLowerBound(0); I <= g_RouteInfo.GetUpperBound(0); I++)
            {
                RouteInfo = g_RouteInfo[I];
                if (RouteInfo.sSelGateIP == sGateIP)
                {
                    result = GateRouteIP_GetRoute(RouteInfo, ref nPort);
                    break;
                }
            }
            return result;
        }

        public static int GetMapIndex(string sMap)
        {
            int result;
            int I;
            result = 0;
            for (I = 0; I < g_MapList.Count; I++)
            {
                if (g_MapList[I] == sMap)
                {
                    //@ Unsupported property or method(A): 'Values'
                    result = ((int)g_MapList[I]);
                    break;
                }
            }
            return result;
        }

        public static void LoadConfig()
        {
            int LoadInteger;
            GameFramework.IniFile Conf = new GameFramework.IniFile(g_sConfFileName);
            if (Conf != null)
            {
                g_sDataDBFilePath = Conf.ReadString("DB", "Dir", g_sDataDBFilePath);
                g_sHumDBFilePath = Conf.ReadString("DB", "HumDir", g_sHumDBFilePath);
                g_sFeedPath = Conf.ReadString("DB", "FeeDir", g_sFeedPath);
                g_sBackupPath = Conf.ReadString("DB", "Backup", g_sBackupPath);
                g_sConnectPath = Conf.ReadString("DB", "ConnectDir", g_sConnectPath);
                g_sLogPath = Conf.ReadString("DB", "LogDir", g_sLogPath);
                g_nServerPort = Conf.ReadInteger("Setup", "ServerPort", g_nServerPort);
                g_sServerAddr = Conf.ReadString("Setup", "ServerAddr", g_sServerAddr);
                g_nGatePort = Conf.ReadInteger("Setup", "GatePort", g_nGatePort);
                g_sGateAddr = Conf.ReadString("Setup", "GateAddr", g_sGateAddr);
                g_sIDServerAddr = Conf.ReadString("Server", "IDSAddr", g_sIDServerAddr);
                g_nIDServerPort = Conf.ReadInteger("Server", "IDSPort", g_nIDServerPort);
                g_sServerName = Conf.ReadString("Setup", "ServerName", g_sServerName);
                g_boDenyChrName = Conf.ReadBool("Setup", "DenyChrName", g_boDenyChrName);
                g_boMinimize = Conf.ReadBool("Setup", "Minimize", g_boMinimize);
                g_boDeleteChrName = Conf.ReadBool("Setup", "DeleteChrName", g_boDeleteChrName);
                g_boRandomNumber = Conf.ReadBool("Setup", "RandomNumber", g_boRandomNumber);

                // boViewHackMsg := Conf.ReadBool('Setup', 'ViewHackMsg', boViewHackMsg);
                //
                // boClearLevel1:=Conf.ReadBool('DBClear','ClearLevel1',boClearLevel1);
                // boClearLevel2:=Conf.ReadBool('DBClear','ClearLevel2',boClearLevel2);
                // boClearLevel3:=Conf.ReadBool('DBClear','ClearLevel3',boClearLevel3);
                //
                // dwInterval := Conf.ReadInteger('DBClear', 'Interval', dwInterval);
                // nLevel1 := Conf.ReadInteger('DBClear', 'Level1', nLevel1);
                // nLevel2 := Conf.ReadInteger('DBClear', 'Level2', nLevel2);
                // nLevel3 := Conf.ReadInteger('DBClear', 'Level3', nLevel3);
                // nDay1 := Conf.ReadInteger('DBClear', 'Day1', nDay1);
                // nDay2 := Conf.ReadInteger('DBClear', 'Day2', nDay2);
                // nDay3 := Conf.ReadInteger('DBClear', 'Day3', nDay3);
                // nMonth1 := Conf.ReadInteger('DBClear', 'Month1', nMonth1);
                // nMonth2 := Conf.ReadInteger('DBClear', 'Month2', nMonth2);
                // nMonth3 := Conf.ReadInteger('DBClear', 'Month3', nMonth3);
                LoadInteger = Conf.ReadInteger("Setup", "DynamicIPMode", -1);
                if (LoadInteger < 0)
                {
                    Conf.WriteBool("Setup", "DynamicIPMode", g_boDynamicIPMode);
                }
                else
                {
                    g_boDynamicIPMode = LoadInteger == 1;
                }
                g_boAutoRefRanking = Conf.ReadBool("Setup", "AutoRefRanking", g_boAutoRefRanking);
                g_nRankingMinLevel = Conf.ReadInteger("Setup", "RankingMinLevel", g_nRankingMinLevel);
                g_nRankingMaxLevel = Conf.ReadInteger("Setup", "RankingMaxLevel", g_nRankingMaxLevel);
                g_nRefRankingHour1 = Conf.ReadInteger("Setup", "RefRankingHour1", g_nRefRankingHour1);
                g_nRefRankingHour2 = Conf.ReadInteger("Setup", "RefRankingHour2", g_nRefRankingHour2);
                g_nRefRankingMinute1 = Conf.ReadInteger("Setup", "RefRankingMinute1", g_nRefRankingMinute1);
                g_nRefRankingMinute2 = Conf.ReadInteger("Setup", "RefRankingMinute2", g_nRefRankingMinute2);
                g_nAutoRefRankingType = Conf.ReadInteger("Setup", "AutoRefRankingType", g_nAutoRefRankingType);
                g_boAllowAddChar = Conf.ReadBool("Setup", "AllowAddChar", g_boAllowAddChar);
                g_boAllowDelChar = Conf.ReadBool("Setup", "AllowDelChar", g_boAllowDelChar);
                g_boAllowGetBackChar = Conf.ReadBool("Setup", "AllowGetBackChar", g_boAllowGetBackChar);
                g_nStoreDeleteCharDay = Conf.ReadInteger("Setup", "StoreDeleteCharDay", g_nStoreDeleteCharDay);
                g_nAllowDelCharCount = Conf.ReadInteger("Setup", "AllowDelCharCount", g_nAllowDelCharCount);
            }
            LoadIPTable();
            LoadGateID();
            LoadServerInfo();
            LoadChrNameList("DenyChrName.txt");
            LoadAICharNameList("AICharName.txt");
            LoadClearMakeIndexList("ClearMakeIndex.txt");
        }

        public static int GetCodeMsgSize(double X)
        {
            int result;
            if (Convert.ToInt32(X) < X)
            {
                result = Convert.ToInt32(X) + 1;
            }
            else
            {
                result = Convert.ToInt32(X);
            }
            return result;
        }

        public static bool CheckAIChrName(string sChrName)
        {
            bool result;
            int I;
            result = true;
            for (I = 0; I < g_AICharNameList.Count; I++)
            {
                if ((sChrName).ToLower().CompareTo((g_AICharNameList[I]).ToLower()) == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool CheckDenyChrName(string sChrName)
        {
            bool result;
            int I;
            result = true;
            for (I = 0; I < g_DenyChrNameList.Count; I++)
            {
                if ((sChrName).ToLower().CompareTo((g_DenyChrNameList[I]).ToLower()) == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool CheckChrName(string sChrName)
        {
            bool result;
            int I;
            char Chr;
            bool boIsTwoByte;
            char FirstChr;
            result = true;
            boIsTwoByte = false;
            FirstChr = '\0';
            for (I = 0; I < sChrName.Length; I++)
            {
                Chr = sChrName[I];
                if (boIsTwoByte)
                {
                    // if Chr < #$A1 then Result:=False; //如果小于就是非法字符
                    // if Chr < #$81 then Result:=False; //如果小于就是非法字符
                    if (!((FirstChr <= '÷') && (Chr >= '@') && (Chr <= 't')))
                    {
                        if (!((FirstChr > '÷') && (Chr >= '@') && (Chr <= '?')))
                        {
                            result = false;
                        }
                    }
                    boIsTwoByte = false;
                }
                else
                {
                    // 0045BEC0
                    // if (Chr >= #$B0) and (Chr <= #$C8) then begin
                    if ((Chr >= '?') && (Chr <= 't'))
                    {
                        boIsTwoByte = true;
                        FirstChr = Chr;
                    }
                    else
                    {
                        // 0x0045BED2
                        // #30
                        // #39
                        // #61
                        // #7A
                        // #41
                        // #5A
                        if (!((Chr >= '0') && (Chr <= '9')) && !((Chr >= 'a') && (Chr <= 'z')) && !((Chr >= 'A') && (Chr <= 'Z')))
                        {
                            result = false;
                        }
                    }
                }
                if (!result)
                {
                    break;
                }
            }
            return result;
        }

        public static bool InClearMakeIndexList(int nIndex)
        {
            bool result;
            int I;
            result = false;
            for (I = 0; I < g_ClearMakeIndex.Count; I++)
            {
                //@ Unsupported property or method(A): 'Values'
                if (nIndex == (Convert.ToInt32(g_ClearMakeIndex[I])))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static void MainOutMessage(string sMsg)
        {
            if (!g_boShowLogMsg) //判断是否显示日志消息
            {
                return;//不显示则返回
            }
            g_MainLogMsgList.__Lock();//日志列表 锁定
            try
            {
                string tMsg = '[' + (DateTime.Now).ToString() + "] " + sMsg;
                g_MainLogMsgList.Add(tMsg);
            }
            finally
            {
                g_MainLogMsgList.UnLock();//日志列表 解锁
            }
        }

        public static void SendGameCenterMsg(ushort wIdent, string sSendMsg)
        {
            //TCopyDataStruct SendData;
            //int nParam;
            ////@ Unsupported function or procedure: 'MakeLong'
            //nParam = MakeLong(((ushort)Common.TProgamType.tDBServer), wIdent);
            ////@ Unsupported property or method(C): 'cbData'
            //SendData.cbData = sSendMsg.Length + 1;
            ////@ Unsupported property or method(C): 'lpData'
            ////@ Unsupported property or method(C): 'cbData'
            ////@ Unsupported function or procedure: 'GetMem'
            //GetMem(SendData.lpData, SendData.cbData);
            ////@ Unsupported property or method(C): 'lpData'
            //SendData.lpData = (sSendMsg as string);
            ////@ Undeclared identifier(3): 'WM_COPYDATA'
            ////@ Unsupported function or procedure: 'SendMessage'
            //SendMessage(g_dwGameCenterHandle, WM_COPYDATA, nParam, (uint)SendData);
            ////@ Unsupported property or method(C): 'lpData'
            ////@ Unsupported function or procedure: 'FreeMem'
            //FreeMem(SendData.lpData);
        }

        /// <summary>
        /// 初始化DBSshare
        /// </summary>
        public static void Initialization()
        {
            //InitializeCriticalSection(g_HumDB_CS);
            g_HumDB_CS = new object();
            //InitializeCriticalSection(g_Ranking_CS)
            g_Ranking_CS = new object();
            g_MainLogMsgList = new TGStringList();
            g_DenyChrNameList = new GameFramework.TStringList();
            g_ServerIPList = new GameFramework.TStringList();
            g_GateIDList = new Hashtable();
            g_MapList = new Hashtable();
            g_ClearMakeIndex = new GameFramework.TStringList();
            g_DenyRankingChrList = new GameFramework.TStringList();
            g_AICharNameList = new GameFramework.TStringList();
            for (int i = 0; i < g_RouteInfo.Length; i++)
            {
                g_RouteInfo[i] = new TRouteInfo();
            }
            g_HumDataDB = TFileDB.GetInstance();
            g_HumCharDB = new TFileHumDB();
            g_ModuleList = new List<TModuleInfo>();
            //DBShare.g_HumRanking = new TSortStringList();
            //DBShare.g_WarriorRanking = new TSortStringList();
            //DBShare.g_WizzardRanking = new TSortStringList();
            //DBShare.g_MonkRanking = new TSortStringList();
            //DBShare.g_HeroRanking = new TSortStringList();
            //DBShare.g_HeroWarriorRanking = new TSortStringList();
            //DBShare.g_HeroWizzardRanking = new TSortStringList();
            //DBShare.g_HeroMonkRanking = new TSortStringList();
            //DBShare.g_MasterRanking = new TSortStringList();
            g_MagicList = new List<string>();
            g_StdItemList = new List<string>();
        }
    }
}