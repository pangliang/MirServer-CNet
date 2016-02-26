using GameFramework;
using System;
using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TFrmBasicSet : Form
    {
        public TFrmBasicSet()
        {
            InitializeComponent();
        }

        // Private declarations
        private void LockSaveButtonEnabled()
        {
            ButtonSave.Enabled = false;
        }

        private void UnLockSaveButtonEnabled()
        {
            ButtonSave.Enabled = true;
        }

        // Public declarations
        public void OpenBasicSet()
        {
            //Units.BasicSet.Config = LSShare.g_Config;
            //CheckBoxTestServer.Checked =Config.boTestServer;
            //CheckBoxEnableMakingID.Checked =Config.boEnableMakingID;
            //CheckBoxEnableGetbackPassword.Checked =Config.boEnableGetbackPassword;
            //CheckBoxAutoClear.Checked =Config.boAutoClearID;
            //SpinEditAutoClearTime.Value =Config.dwAutoClearTime;
            //CheckBoxAutoUnLockAccount.Checked =Config.boUnLockAccount;
            //SpinEditUnLockAccountTime.Value =Config.dwUnLockAccountTime;
            //EditGateAddr.Text =Config.sGateAddr;
            //EditGatePort.Text = (Units.BasicSet.Config.nGatePort).ToString();
            //EditServerAddr.Text =Config.sServerAddr;
            //EditServerPort.Text = (Units.BasicSet.Config.nServerPort).ToString();
            //EditMonAddr.Text =Config.sMonAddr;
            //EditMonPort.Text = (Units.BasicSet.Config.nMonPort).ToString();
            //CheckBoxDynamicIPMode.Checked =Config.boDynamicIPMode;
            //CheckBoxMinimize.Checked =Config.boMinimize;
            // CheckBoxRandomCode.Checked := Config.boRandomCode;
            LockSaveButtonEnabled();
            this.ShowDialog();
        }

        public void CheckBoxTestServerClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.boTestServer = CheckBoxTestServer.Checked;
            UnLockSaveButtonEnabled();
        }

        public void CheckBoxEnableMakingIDClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.boEnableMakingID = CheckBoxEnableMakingID.Checked;
            UnLockSaveButtonEnabled();
        }

        public void CheckBoxEnableGetbackPasswordClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.boEnableGetbackPassword = CheckBoxEnableGetbackPassword.Checked;
            UnLockSaveButtonEnabled();
        }

        public void CheckBoxAutoClearClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.boAutoClearID = CheckBoxAutoClear.Checked;
            UnLockSaveButtonEnabled();
        }

        public void SpinEditAutoClearTimeChange(Object Sender)
        {
            Config = LSShare.g_Config;
            Config.dwAutoClearTime = (uint)SpinEditAutoClearTime.Value;
            UnLockSaveButtonEnabled();
        }

        public void CheckBoxAutoUnLockAccountClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.boUnLockAccount = CheckBoxAutoUnLockAccount.Checked;
            UnLockSaveButtonEnabled();
        }

        public void SpinEditUnLockAccountTimeChange(Object Sender)
        {
            Config = LSShare.g_Config;
            Config.dwUnLockAccountTime = (uint)SpinEditUnLockAccountTime.Value;
            UnLockSaveButtonEnabled();
        }

        public void ButtonRestoreBasicClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            CheckBoxTestServer.Checked = true;
            CheckBoxEnableMakingID.Checked = true;
            CheckBoxEnableGetbackPassword.Checked = true;
            CheckBoxAutoClear.Checked = true;
            SpinEditAutoClearTime.Value = 1;
            CheckBoxAutoUnLockAccount.Checked = false;
            SpinEditUnLockAccountTime.Value = 10;
        }

        public void EditGateAddrChange(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.sGateAddr = EditGateAddr.Text.Trim();
            UnLockSaveButtonEnabled();
        }

        public void EditGatePortChange(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.nGatePort = HUtil32.Str_ToInt(EditGatePort.Text.Trim(), 5500);
            UnLockSaveButtonEnabled();
        }

        public void EditMonAddrChange(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.sMonAddr = EditMonAddr.Text.Trim();
            UnLockSaveButtonEnabled();
        }

        public void EditMonPortChange(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.nMonPort = HUtil32.Str_ToInt(EditMonPort.Text.Trim(), 3000);
            UnLockSaveButtonEnabled();
        }

        public void EditServerAddrChange(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.sServerAddr = EditServerAddr.Text.Trim();
            UnLockSaveButtonEnabled();
        }

        public void EditServerPortChange(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.nServerPort = HUtil32.Str_ToInt(EditServerPort.Text.Trim(), 5600);
            UnLockSaveButtonEnabled();
        }

        public void CheckBoxDynamicIPModeClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.boDynamicIPMode = CheckBoxDynamicIPMode.Checked;
            UnLockSaveButtonEnabled();
        }

        public void ButtonRestoreNetClick(System.Object Sender, System.EventArgs _e1)
        {
            EditGateAddr.Text = "0.0.0.0";
            EditGatePort.Text = "5500";
            EditServerAddr.Text = "0.0.0.0";
            EditServerPort.Text = "5600";
            EditMonAddr.Text = "0.0.0.0";
            EditMonPort.Text = "3000";
            CheckBoxDynamicIPMode.Checked = false;
        }

        public void ButtonSaveClick(System.Object Sender, System.EventArgs _e1)
        {
            //WriteConfig(Units.BasicSet.Config);
            LockSaveButtonEnabled();
        }

        public void ButtonCloseClick(System.Object Sender, System.EventArgs _e1)
        {
            this.Close();
        }

        public void CheckBoxMinimizeClick(System.Object Sender, System.EventArgs _e1)
        {
            Config = LSShare.g_Config;
            Config.boMinimize = CheckBoxMinimize.Checked;
            UnLockSaveButtonEnabled();
        }

        public static TFrmBasicSet FrmBasicSet = null;
        public static TConfig Config = null;

        public void WriteConfig_WriteConfigString(string sSection, string sIdent, string sDefault)
        {
            //@ Unsupported property or method(A): 'WriteString'
            Config.IniConf.WriteString(sSection, sIdent, sDefault);
        }

        public void WriteConfig_WriteConfigInteger(string sSection, string sIdent, int nDefault)
        {
            //@ Unsupported property or method(A): 'WriteInteger'
            Config.IniConf.WriteInteger(sSection, sIdent, nDefault);
        }

        public void WriteConfig_WriteConfigBoolean(string sSection, string sIdent, bool boDefault)
        {
            //@ Unsupported property or method(A): 'WriteBool'
            Config.IniConf.WriteBool(sSection, sIdent, boDefault);
        }

        public static void WriteConfig(TConfig Config)
        {
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

            //WriteConfig_WriteConfigString(sSectionServer, sIdentDBServer, Config.sDBServer);
            //WriteConfig_WriteConfigString(sSectionServer, sIdentFeeServer, Config.sFeeServer);
            //WriteConfig_WriteConfigString(sSectionServer, sIdentLogServer, Config.sLogServer);
            //WriteConfig_WriteConfigString(sSectionServer, sIdentGateAddr, Config.sGateAddr);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentGatePort, Config.nGatePort);
            //WriteConfig_WriteConfigString(sSectionServer, sIdentServerAddr, Config.sServerAddr);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentServerPort, Config.nServerPort);
            //WriteConfig_WriteConfigString(sSectionServer, sIdentMonAddr, Config.sMonAddr);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentMonPort, Config.nMonPort);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentDBSPort, Config.nDBSPort);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentFeePort, Config.nFeePort);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentLogPort, Config.nLogPort);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentReadyServers, Config.nReadyServers);
            //WriteConfig_WriteConfigBoolean(sSectionServer, sIdentTestServer, Config.boEnableMakingID);
            //WriteConfig_WriteConfigBoolean(sSectionServer, sIdentEnableGetbackPassword, Config.boEnableGetbackPassword);
            //WriteConfig_WriteConfigBoolean(sSectionServer, sIdentAutoClearID, Config.boAutoClearID);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentAutoClearTime, Config.dwAutoClearTime);
            //WriteConfig_WriteConfigBoolean(sSectionServer, sIdentUnLockAccount, Config.boUnLockAccount);
            //WriteConfig_WriteConfigInteger(sSectionServer, sIdentUnLockAccountTime, Config.dwUnLockAccountTime);
            //WriteConfig_WriteConfigBoolean(sSectionServer, sIdentDynamicIPMode, Config.boDynamicIPMode);
            //WriteConfig_WriteConfigBoolean(sSectionServer, sIdentMinimize, Config.boMinimize);
            //// WriteConfigBoolean(sSectionServer, sIdentRandomCode, Config.boRandomCode);
            //WriteConfig_WriteConfigString(sSectionDB, sIdentIdDir, Config.sIdDir);
            //WriteConfig_WriteConfigString(sSectionDB, sIdentWebLogDir, Config.sWebLogDir);
            //WriteConfig_WriteConfigString(sSectionDB, sIdentCountLogDir, Config.sCountLogDir);
            //WriteConfig_WriteConfigString(sSectionDB, sIdentFeedIDList, Config.sFeedIDList);
            //WriteConfig_WriteConfigString(sSectionDB, sIdentFeedIPList, Config.sFeedIPList);
        }
    }
}