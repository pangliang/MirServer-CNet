using GameFramework;
using LoginSrv.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LoginSrv
{
    // 文件模式
    // 数据库模式
    public struct TSockaddr
    {
        public int nIPaddr;
        public uint dwStartAttackTick;
        public int nAttackCount;
    } // end TSockaddr

    public struct TGateNet
    {
        public string sIPaddr;
        public int nPort;
        public bool boEnable;
    } // end TGateNet

    public struct TGateRoute
    {
        public string sServerName;
        public string sTitle;
        public string sRemoteAddr;
        public string sPublicAddr;
        public int nSelIdx;
        public TGateNet[] Gate;
    } // end TGateRoute

    public class TConfig
    {
        public IniFile IniConf;

        // ini文件
        public bool boRemoteClose;

        public string sDBServer;

        // 0x00475368
        public int nDBSPort;

        // 0x00475374
        public string sFeeServer;

        // 0x0047536C
        public int nFeePort;

        // 0x00475378
        public string sLogServer;

        // 0x00475370
        public int nLogPort;

        // 0x0047537C
        public string sGateAddr;

        public int nGatePort;
        public string sServerAddr;
        public int nServerPort;
        public string sMonAddr;
        public int nMonPort;
        public string sGateIPaddr;

        // 当前处理的网关连接IP地址
        public string sIdDir;

        public string sWebLogDir;
        public string sFeedIDList;
        public string sFeedIPList;
        public string sCountLogDir;
        public string sChrLogDir;
        public bool boTestServer;
        public bool boEnableMakingID;
        public bool boEnableGetbackPassword;
        public bool boAutoClearID;
        public uint dwAutoClearTime;
        public bool boUnLockAccount;
        public uint dwUnLockAccountTime;
        public bool boDynamicIPMode;
        public int nReadyServers;
        public object GateCriticalSection;
        public List<TGateInfo> GateList;
        public List<TConnInfo> SessionList;
        public List<string> ServerNameList;
        public SortedList AccountCostList;
        public SortedList IPaddrCostList;
        public SortedList MakeAccountList;
        public bool boShowDetailMsg;
        public bool boMinimize;
        public bool boRandomCode;
        public uint dwProcessGateTick;

        // 0x00475380
        public uint dwProcessGateTime;

        // 0x00475384
        public int nRouteCount;

        // 0x47328C
        public TGateRoute[] GateRoute;
    } // end TConfig

    public class LSShare
    {
        public static TConfig g_Config = new TConfig();

        //public static TConfig g_Confif = new TConfig() {
        //      false, "127.0.0.1", 16300, "127.0.0.1", 16301, "127.0.0.1", 16301, "0.0.0.0", 5500, "0.0.0.0", 5600, "0.0.0.0", 3000,
        //                                     ".\\DB\\", ".\\Share\\", ".\\FeedIDList.txt", ".\\FeedIPList.txt", ".\\CountLog\\", ".\\ChrLog\\", true, true, true, true,
        //                                     1000, false, 10, false, 0, false, true, false
        //};
        public static List<string> StringList_0 = null;

        // 0x0047538C
        public static int nOnlineCountMin = 0;

        // 0x00475390
        public static int nOnlineCountMax = 0;

        // 0x00475394
        public static int nMemoHeigh = 0;

        // 0x00475398
        public static object g_OutMessageCS = null;

        public static List<string> g_MainMsgList = new List<string>();

        // 0x0047539C
        public static object CS_DB = null;

        // 0x004753A0
        public static int n4753A4 = 0;

        // 0x004753A4
        public static int n4753A8 = 0;

        // 0x004753A8
        public static int n4753B0 = 0;

        // 0x004753B0
        public static int n47328C = 0;

        public static int nSessionIdx = 0;

        // 0x00473294
        public static int g_n472A6C = 0;

        public static int g_n472A70 = 0;
        public static int g_n472A74 = 0;
        public static bool g_boDataDBReady = false;

        // 0x00472A78
        public static bool bo470D20 = false;

        public static int nVersionDate = 20011006;
        public static string[] ServerAddr = new string[15 + 1];
        public static long g_dwGameCenterHandle = 0;
        public const string g_sVersion = "程序版本: 1.00 Build 20110123";
        public const string g_sUpDateTime = "更新日期: 2011/01/23";
        public const string g_sProgram = "程序制作: QQ:442517066";
        public const string g_sWebSite = "程序网站: http://www.MirYQ.com";
        public const int IDFILEMODE = 0;// 文件模式
        public const int IDDBMODE = 1;// 数据库模式
        public const int IDMODE = IDFILEMODE;
        public const int tLoginSrv = 1;
        public const int MAXGATEROUTE = 60;

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

        public static bool CheckAccountName(string sName)
        {
            bool result;
            int I;
            int nLen;
            result = false;
            if (sName == "")
            {
                return result;
            }
            result = true;
            nLen = sName.Length;
            I = 0;
            while (true)
            {
                if (I >= nLen)
                {
                    break;
                }
                if ((sName[I] < '0') || (sName[I] > 'z'))
                {
                    if ((sName[I] == '@') || (sName[I] == '.'))
                    {
                        I++;
                        continue;
                    }
                    result = false;
                    if ((sName[I] >= '°') && (sName[I] <= 'è'))
                    {
                        I++;
                        if (I <= nLen)
                        {
                            if ((sName[I] >= '?') && (sName[I] <= 't'))
                            {
                                result = true;
                            }
                        }
                    }
                    if (!result)
                    {
                        break;
                    }
                }
                I++;
            }
            return result;
        }

        public static int GetSessionID()
        {
            int result;
            nSessionIdx++;
            if (nSessionIdx >= Int32.MaxValue)
            {
                nSessionIdx = 2;
            }
            result = nSessionIdx;
            return result;
        }

        public static void SaveGateConfig(TConfig Config)
        {
            TStringList SaveList;
            int I;
            int n8;
            string s10;
            string sC;
            SaveList = new TStringList();
            SaveList.Add(";No space allowed");
            SaveList.Add(GenSpaceString(";Server", 15) + GenSpaceString("Title", 15) + GenSpaceString("Remote", 17) + GenSpaceString("Public", 17) + "Gate...");
            for (I = 0; I < Config.nRouteCount; I++)
            {
                sC = GenSpaceString(Config.GateRoute[I].sServerName, 15) + GenSpaceString(Config.GateRoute[I].sTitle, 15) + GenSpaceString(Config.GateRoute[I].sRemoteAddr, 17)
                    + GenSpaceString(Config.GateRoute[I].sPublicAddr, 17);
                n8 = 0;
                while (true)
                {
                    s10 = Config.GateRoute[I].Gate[n8].sIPaddr;
                    if (s10 == "")
                    {
                        break;
                    }
                    if (!Config.GateRoute[I].Gate[n8].boEnable)
                    {
                        s10 = '*' + s10;
                    }
                    s10 = s10 + ':' + (Config.GateRoute[I].Gate[n8].nPort).ToString();
                    sC = sC + GenSpaceString(s10, 17);
                    n8++;
                    if (n8 >= 10)
                    {
                        break;
                    }
                }
                SaveList.Add(sC);
            }
            SaveList.SaveToFile(".\\!addrtable.txt");

            //SaveList.Free;
        }

        public static string GetGatePublicAddr(TConfig Config, string sGateIP)
        {
            string result;
            int I;
            result = sGateIP;
            for (I = 0; I < Config.nRouteCount; I++)
            {
                if (Config.GateRoute[I].sRemoteAddr == sGateIP)
                {
                    result = Config.GateRoute[I].sPublicAddr;
                    break;
                }
            }
            return result;
        }

        public static string GenSpaceString(string sStr, int nSpaceCOunt)
        {
            string result;
            int I;
            result = sStr + ' ';
            for (I = 1; I <= nSpaceCOunt - sStr.Length; I++)
            {
                result = result + ' ';
            }
            return result;
        }

        public static void MainOutMessage(string sMsg)
        {
            //EnterCriticalSection(g_OutMessageCS);
            try
            {
                g_MainMsgList.Add(sMsg);
            }
            finally
            {
                //LeaveCriticalSection(g_OutMessageCS);
            }
        }

        public static void SendGameCenterMsg(ushort wIdent, string sSendMsg)
        {
            //TCopyDataStruct SendData;
            //int nParam;
            //nParam = MakeLong((ushort)tLoginSrv, wIdent);
            //SendData.cbData = sSendMsg.Length + 1;
            //GetMem(SendData.lpData, SendData.cbData);
            //SendData.lpData = (sSendMsg as string);
            //SendMessage(g_dwGameCenterHandle, WM_COPYDATA, nParam, (uint)SendData);
            // FreeMem(SendData.lpData);
        }

        public void initialization()
        {
            //InitializeCriticalSection(g_OutMessageCS);
            //g_MainMsgList = new object();
        }

        public void finalization()
        {
            //g_MainMsgList.Free;
            //DeleteCriticalSection(g_OutMessageCS);
        }
    }
}