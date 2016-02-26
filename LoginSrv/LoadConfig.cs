using GameFramework;

namespace LoginSrv
{
    public class LoadConfig
    {
        public void InitializeConfig(TConfig Config)
        {
            const string sConfigFile = ".\\Logsrv.ini";
            Config.IniConf = new IniFile(sConfigFile);
        }

        public LoadConfig(TConfig Config)
        {
            InitializeConfig(Config);
            const string sSectionServer = "Server";
            const string sSectionDB = "DB";
            const string sIdentDBServer = "DBServer";
            const string sIdentFeeServer = "FeeServer";
            const string sIdentLogServer = "LogServer";
            const string sIdentGateAddr = "GateAddr";
            const string sIdentGatePort = "GatePort";
            const string sIdentServerAddr = "ServerAddr";
            const string sIdentServerPort = "ServerPort";
            const string sIdentMonAddr = "MonAddr";
            const string sIdentMonPort = "MonPort";
            const string sIdentDBSPort = "DBSPort";
            const string sIdentFeePort = "FeePort";
            const string sIdentLogPort = "LogPort";
            const string sIdentReadyServers = "ReadyServers";
            const string sIdentTestServer = "TestServer";
            const string sIdentDynamicIPMode = "DynamicIPMode";
            const string sIdentIdDir = "IdDir";
            const string sIdentWebLogDir = "WebLogDir";
            const string sIdentCountLogDir = "CountLogDir";
            const string sIdentFeedIDList = "FeedIDList";
            const string sIdentFeedIPList = "FeedIPList";
            const string sIdentEnableGetbackPassword = "GetbackPassword";
            const string sIdentAutoClearID = "AutoClearID";
            const string sIdentAutoClearTime = "AutoClearTime";
            const string sIdentUnLockAccount = "UnLockAccount";
            const string sIdentUnLockAccountTime = "UnLockAccountTime";
            const string sIdentMinimize = "Minimize";
            const string sIdentRandomCode = "RandomCode";
            Config.sDBServer = LoadConfig_LoadConfigString(sSectionServer, sIdentDBServer, "");
            Config.sFeeServer = LoadConfig_LoadConfigString(sSectionServer, sIdentFeeServer, "");
            Config.sLogServer = LoadConfig_LoadConfigString(sSectionServer, sIdentLogServer, "");
            Config.sGateAddr = LoadConfig_LoadConfigString(sSectionServer, sIdentGateAddr, "");
            Config.nGatePort = LoadConfig_LoadConfigInteger(sSectionServer, sIdentGatePort, 0);
            Config.sServerAddr = LoadConfig_LoadConfigString(sSectionServer, sIdentServerAddr, "");
            Config.nServerPort = LoadConfig_LoadConfigInteger(sSectionServer, sIdentServerPort, 0);
            Config.sMonAddr = LoadConfig_LoadConfigString(sSectionServer, sIdentMonAddr, "");
            Config.nMonPort = LoadConfig_LoadConfigInteger(sSectionServer, sIdentMonPort, 0);
            Config.nDBSPort = LoadConfig_LoadConfigInteger(sSectionServer, sIdentDBSPort, 0);
            Config.nFeePort = LoadConfig_LoadConfigInteger(sSectionServer, sIdentFeePort, 0);
            Config.nLogPort = LoadConfig_LoadConfigInteger(sSectionServer, sIdentLogPort, 0);
            Config.nReadyServers = LoadConfig_LoadConfigInteger(sSectionServer, sIdentReadyServers, 0);
            Config.boEnableMakingID = LoadConfig_LoadConfigBoolean(sSectionServer, sIdentTestServer, false);
            Config.boEnableGetbackPassword = LoadConfig_LoadConfigBoolean(sSectionServer, sIdentEnableGetbackPassword, false);
            Config.boAutoClearID = LoadConfig_LoadConfigBoolean(sSectionServer, sIdentAutoClearID, false);
            Config.dwAutoClearTime = (uint)LoadConfig_LoadConfigInteger(sSectionServer, sIdentAutoClearTime, (int)Config.dwAutoClearTime);
            Config.boUnLockAccount = LoadConfig_LoadConfigBoolean(sSectionServer, sIdentUnLockAccount, false);
            Config.dwUnLockAccountTime = (uint)LoadConfig_LoadConfigInteger(sSectionServer, sIdentUnLockAccountTime, (int)Config.dwUnLockAccountTime);
            Config.boDynamicIPMode = LoadConfig_LoadConfigBoolean(sSectionServer, sIdentDynamicIPMode, false);
            Config.boMinimize = LoadConfig_LoadConfigBoolean(sSectionServer, sIdentMinimize, false);
            Config.boRandomCode = LoadConfig_LoadConfigBoolean(sSectionServer, sIdentRandomCode, false);
            Config.sIdDir = LoadConfig_LoadConfigString(sSectionDB, sIdentIdDir, "");
            Config.sWebLogDir = LoadConfig_LoadConfigString(sSectionDB, sIdentWebLogDir, "");
            Config.sCountLogDir = LoadConfig_LoadConfigString(sSectionDB, sIdentCountLogDir, "");
            Config.sFeedIDList = LoadConfig_LoadConfigString(sSectionDB, sIdentFeedIDList, "");
            Config.sFeedIPList = LoadConfig_LoadConfigString(sSectionDB, sIdentFeedIPList, "");
        }

        public string LoadConfig_LoadConfigString(string sSection, string sIdent, string sDefault)
        {
            string result;
            string sString;
            TConfig Config = LSShare.g_Config;
            sString = Config.IniConf.ReadString(sSection, sIdent, "");
            if (sString == "")
            {
                Config.IniConf.WriteString(sSection, sIdent, sDefault);
                result = sDefault;
            }
            else
            {
                result = sString;
            }
            return result;
        }

        public int LoadConfig_LoadConfigInteger(string sSection, string sIdent, int nDefault)
        {
            int result;
            int nLoadInteger;
            TConfig Config = LSShare.g_Config;
            nLoadInteger = Config.IniConf.ReadInteger(sSection, sIdent, -1);
            if (nLoadInteger < 0)
            {
                Config.IniConf.WriteInteger(sSection, sIdent, nDefault);
                result = nDefault;
            }
            else
            {
                result = nLoadInteger;
            }
            return result;
        }

        public bool LoadConfig_LoadConfigBoolean(string sSection, string sIdent, bool boDefault)
        {
            bool result;
            int nLoadInteger;
            TConfig Config = LSShare.g_Config;
            nLoadInteger = Config.IniConf.ReadInteger(sSection, sIdent, -1);
            if (nLoadInteger < 0)
            {
                Config.IniConf.WriteBool(sSection, sIdent, boDefault);
                result = boDefault;
            }
            else
            {
                result = nLoadInteger == 1;
            }
            return result;
        }
    }
}