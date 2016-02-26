using System;
using System.Windows.Forms;
using System.IO;
using GameFramework;

namespace M2Server
{
    public partial class TfrmGeneralConfig : Form
    {
        public static TfrmGeneralConfig frmGeneralConfig = null;
        private bool boOpened = false;
        private bool boModValued = false;
        public TfrmGeneralConfig()
        {
            InitializeComponent();
        }

        private void ModValue()
        {
            boModValued = true;
            ButtonNetWorkSave.Enabled = true;
            ButtonServerInfoSave.Enabled = true;
            ButtonShareDirSave.Enabled = true;
        }

        private void uModValue()
        {
            boModValued = false;
            ButtonNetWorkSave.Enabled = false;
            ButtonServerInfoSave.Enabled = false;
            ButtonShareDirSave.Enabled = false;
        }

        public void ButtonNetWorkSaveClick(object sender, EventArgs e)
        {
            string Gateaddr;
            string IDSAddr;
            string DBAddr;
            string LogServerAddr;
            string MsgSrvAddr;
            int GatePort;
            int IDSPort;
            int DBPort;
            int LogServerPort;
            int MsgSrvPort;
            Gateaddr = EditGateAddr.Text.Trim();
            GatePort = HUtil32.Str_ToInt(EditGatePort.Text.Trim(), -1);
            IDSAddr = EditIDSAddr.Text.Trim();
            IDSPort = HUtil32.Str_ToInt(EditIDSPort.Text.Trim(), -1);
            DBAddr = EditDBAddr.Text.Trim();
            DBPort = HUtil32.Str_ToInt(EditDBPort.Text.Trim(), -1);
            LogServerAddr = EditLogServerAddr.Text.Trim();
            LogServerPort = HUtil32.Str_ToInt(EditLogServerPort.Text.Trim(), -1);
            MsgSrvAddr = EditMsgSrvAddr.Text.Trim();
            MsgSrvPort = HUtil32.Str_ToInt(EditMsgSrvPort.Text.Trim(), -1);
            //if (!HUtil32.IsIPAddr(Gateaddr))
            //{
            //    System.Windows.Forms.MessageBox.Show("网关地址设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
            //    EditGateAddr.Focus();
            //    return;
            //}
            if ((GatePort < 0) || (GatePort > 65535))
            {
                System.Windows.Forms.MessageBox.Show("网关端口设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditGatePort.Focus();
                return;
            }
            //if (!HUtil32.IsIPAddr(IDSAddr))
            //{
            //    System.Windows.Forms.MessageBox.Show("管理服务器地址设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
            //    EditIDSAddr.Focus();
            //    return;
            //}
            if ((IDSPort < 0) || (IDSPort > 65535))
            {
                System.Windows.Forms.MessageBox.Show("管理服务器端口设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditIDSPort.Focus();
                return;
            }
            //if (!HUtil32.IsIPAddr(DBAddr))
            //{
            //    System.Windows.Forms.MessageBox.Show("数据库服务器地址设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
            //    EditDBAddr.Focus();
            //    return;
            //}
            if ((DBPort < 0) || (DBPort > 65535))
            {
                System.Windows.Forms.MessageBox.Show("数据库服务器端口设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditDBPort.Focus();
                return;
            }
            //if (!HUtil32.IsIPAddr(LogServerAddr))
            //{
            //    System.Windows.Forms.MessageBox.Show("日志服务器地址设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
            //    EditLogServerAddr.Focus();
            //    return;
            //}
            if ((LogServerPort < 0) || (LogServerPort > 65535))
            {
                System.Windows.Forms.MessageBox.Show("日志服务器端口设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditLogServerPort.Focus();
                return;
            }
            //if (!HUtil32.IsIPAddr(MsgSrvAddr))
            //{
            //    System.Windows.Forms.MessageBox.Show("游戏主服务器地址设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
            //    EditMsgSrvAddr.Focus();
            //    return;
            //}
            if ((MsgSrvPort < 0) || (MsgSrvPort > 65535))
            {
                System.Windows.Forms.MessageBox.Show("游戏主服务器端口设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditMsgSrvPort.Focus();
                return;
            }
            M2Share.g_Config.sGateAddr = Gateaddr;
            M2Share.g_Config.nGatePort = (ushort)GatePort;
            M2Share.g_Config.sIDSAddr = IDSAddr;
            M2Share.g_Config.nIDSPort = (ushort)IDSPort;
            M2Share.g_Config.sDBAddr = DBAddr;
            M2Share.g_Config.nDBPort = (ushort)DBPort;
            M2Share.g_Config.sLogServerAddr = LogServerAddr;
            M2Share.g_Config.nLogServerPort = (ushort)LogServerPort;
            M2Share.g_Config.sMsgSrvAddr = MsgSrvAddr;
            M2Share.g_Config.nMsgSrvPort = (ushort)MsgSrvPort;
            M2Share.Config.WriteString("Server", "GateAddr", M2Share.g_Config.sGateAddr);
            M2Share.Config.WriteInteger("Server", "GatePort", M2Share.g_Config.nGatePort);
            M2Share.Config.WriteString("Server", "IDSAddr", M2Share.g_Config.sIDSAddr);
            M2Share.Config.WriteInteger("Server", "IDSPort", M2Share.g_Config.nIDSPort);
            M2Share.Config.WriteString("Server", "DBAddr", M2Share.g_Config.sDBAddr);
            M2Share.Config.WriteInteger("Server", "DBPort", M2Share.g_Config.nDBPort);
            M2Share.Config.WriteString("Server", "LogServerAddr", M2Share.g_Config.sLogServerAddr);
            M2Share.Config.WriteInteger("Server", "LogServerPort", M2Share.g_Config.nLogServerPort);
            M2Share.Config.WriteString("Server", "MsgSrvAddr", M2Share.g_Config.sMsgSrvAddr);
            M2Share.Config.WriteInteger("Server", "MsgSrvPort", M2Share.g_Config.nMsgSrvPort);
            uModValue();
        }

        public void Open()
        {
            boOpened = false;
            uModValue();
            EditGateAddr.Text = M2Share.g_Config.sGateAddr;
            EditGatePort.Text = (M2Share.g_Config.nGatePort).ToString();
            EditIDSAddr.Text = M2Share.g_Config.sIDSAddr;
            EditIDSPort.Text = (M2Share.g_Config.nIDSPort).ToString();
            EditDBAddr.Text = M2Share.g_Config.sDBAddr;
            EditDBPort.Text = (M2Share.g_Config.nDBPort).ToString();
            EditLogServerAddr.Text = M2Share.g_Config.sLogServerAddr;
            EditLogServerPort.Text = (M2Share.g_Config.nLogServerPort).ToString();
            EditMsgSrvAddr.Text = M2Share.g_Config.sMsgSrvAddr;
            EditMsgSrvPort.Text = (M2Share.g_Config.nMsgSrvPort).ToString();
            EditGameName.Text = M2Share.g_Config.sServerName;
            EditServerIndex.Text = (M2Share.nServerIndex).ToString();
            EditServerNumber.Text = (M2Share.g_Config.nServerNumber).ToString();
            CheckBoxServiceMode.Checked = M2Share.g_Config.boServiceMode;
            CheckBoxTestServer.Checked = M2Share.g_Config.boTestServer;
            EditTestLevel.Text = (M2Share.g_Config.nTestLevel).ToString();
            EditTestGold.Text = (M2Share.g_Config.nTestGold).ToString();
            EditTestUserLimit.Text = (M2Share.g_Config.nTestUserLimit).ToString();
            EditUserFull.Text = (M2Share.g_Config.nUserFull).ToString();
            //CheckBoxTestServerClick(this);
            EditGuildDir.Text = M2Share.g_Config.sGuildDir;
            EditGuildFile.Text = M2Share.g_Config.sGuildFile;
            EditConLogDir.Text = M2Share.g_Config.sConLogDir;
            EditCastleDir.Text = M2Share.g_Config.sCastleDir;
            EditBoxsDir.Text = M2Share.g_Config.sBoxsDir;//宝箱目录
            EditSortDir.Text = M2Share.g_Config.sSortDir;//排行文件目录
            EditEnvirDir.Text = M2Share.g_Config.sEnvirDir;
            EditMapDir.Text = M2Share.g_Config.sMapDir;
            EditNoticeDir.Text = M2Share.g_Config.sNoticeDir;
            EditPlugDir.Text = M2Share.g_Config.sPlugDir;
            EditVentureDir.Text = M2Share.g_Config.sVentureDir;
            CheckBoxMinimize.Checked = M2Share.g_boMinimize;
            RefDlgConf();
            boOpened = true;
            PageControl.SelectedIndex = 0;
            this.ShowDialog();
        }

        public void EditValueChange(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            ModValue();
        }

        public void PageControlChanging(Object Sender, ref bool AllowChange)
        {
            if (boModValued)
            {
                if (System.Windows.Forms.MessageBox.Show("参数设置已经被修改，是否确认不保存修改的设置？", "确认信息", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    uModValue();
                }
                else
                {
                    AllowChange = false;
                }
            }
        }

        public void CheckBoxTestServerClick(object sender, EventArgs e)
        {
            bool boStatue;
            boStatue = CheckBoxTestServer.Checked;
            EditTestLevel.Enabled = boStatue;
            EditTestGold.Enabled = boStatue;
            EditTestUserLimit.Enabled = boStatue;
            // EditValueChange(Sender);
        }

        public void ButtonServerInfoSaveClick(object sender, EventArgs e)
        {
            string GameName;
            int ServerIndex;
            int ServerNumber;
            int TestLevel;
            int TestGold;
            int TestUserLimit;
            int UserFull;
            bool TestServer;
            bool ServiceMode;
            GameName = EditGameName.Text.Trim();
            ServerIndex = HUtil32.Str_ToInt(EditServerIndex.Text.Trim(), -1);
            ServerNumber = HUtil32.Str_ToInt(EditServerNumber.Text.Trim(), -1);
            ServiceMode = CheckBoxServiceMode.Checked;
            TestServer = CheckBoxTestServer.Checked;
            TestLevel = HUtil32.Str_ToInt(EditTestLevel.Text.Trim(), -1);
            TestGold = HUtil32.Str_ToInt(EditTestGold.Text.Trim(), -1);
            TestUserLimit = HUtil32.Str_ToInt(EditTestUserLimit.Text.Trim(), -1);
            UserFull = HUtil32.Str_ToInt(EditUserFull.Text.Trim(), -1);
            if (GameName == "")
            {
                System.Windows.Forms.MessageBox.Show("游戏名称设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditGameName.Focus();
                return;
            }
            if ((ServerIndex < 0) || (ServerIndex > 255))
            {
                System.Windows.Forms.MessageBox.Show("服务器号设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditServerIndex.Focus();
                return;
            }
            if ((ServerNumber < 0) || (ServerNumber > 255))
            {
                System.Windows.Forms.MessageBox.Show("服务器数设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditServerNumber.Focus();
                return;
            }
            if ((TestLevel < 0) || (TestLevel > 65535))
            {
                System.Windows.Forms.MessageBox.Show("开始等级设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditTestLevel.Focus();
                return;
            }
            if ((TestGold < 0) || (TestGold > Int32.MaxValue / 2))
            {
                System.Windows.Forms.MessageBox.Show("开始金币设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditTestGold.Focus();
                return;
            }
            if ((TestUserLimit < 0) || (TestUserLimit > 10000))
            {
                System.Windows.Forms.MessageBox.Show("测试人数设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditTestUserLimit.Focus();
                return;
            }
            if ((UserFull < 0) || (UserFull > 10000))
            {
                System.Windows.Forms.MessageBox.Show("上限人数设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditUserFull.Focus();
                return;
            }
            M2Share.g_Config.sServerName = GameName;
            M2Share.g_Config.nServerNumber = (ushort)ServerNumber;
            M2Share.g_Config.boServiceMode = ServiceMode;
            M2Share.g_Config.boTestServer = TestServer;
            M2Share.g_Config.nTestLevel = (ushort)TestLevel;
            M2Share.g_Config.nTestGold = TestGold;
            M2Share.g_Config.nTestUserLimit = (ushort)TestUserLimit;
            M2Share.g_Config.nUserFull = UserFull;
            M2Share.Config.WriteString("Server", "ServerName", M2Share.g_Config.sServerName);
            M2Share.Config.WriteInteger("Server", "ServerIndex", M2Share.nServerIndex);
            M2Share.Config.WriteInteger("Server", "ServerNumber", M2Share.g_Config.nServerNumber);
            M2Share.Config.WriteString("Server", "TestServer", HUtil32.BoolToStr(M2Share.g_Config.boTestServer));
            M2Share.Config.WriteInteger("Server", "TestLevel", M2Share.g_Config.nTestLevel);
            M2Share.Config.WriteInteger("Server", "TestGold", M2Share.g_Config.nTestGold);
            M2Share.Config.WriteInteger("Server", "TestServerUserLimit", M2Share.g_Config.nTestUserLimit);
            M2Share.Config.WriteInteger("Server", "UserFull", M2Share.g_Config.nUserFull);
            M2Share.Config.WriteBool("Server", "Minimize", M2Share.g_boMinimize);
            uModValue();
        }

        public void ButtonShareDirSaveClick(object sender, EventArgs e)
        {
            string GuildDir;
            string GuildFile;
            string VentureDir;
            string ConLogDir;
            string CastleDir;
            string BoxsDir;
            string EnvirDir;
            string MapDir;
            string NoticeDir;
            string PlugDir;
            string SortDir;
            GuildDir = EditGuildDir.Text.Trim();
            GuildFile = EditGuildFile.Text.Trim();
            VentureDir = EditVentureDir.Text.Trim();
            ConLogDir = EditConLogDir.Text.Trim();
            CastleDir = EditCastleDir.Text.Trim();
            BoxsDir = EditBoxsDir.Text.Trim();// 宝箱目录 
            SortDir = EditSortDir.Text.Trim();// 排行榜文件目录
            EnvirDir = EditEnvirDir.Text.Trim();
            MapDir = EditMapDir.Text.Trim();
            NoticeDir = EditNoticeDir.Text.Trim();
            PlugDir = EditPlugDir.Text.Trim();
            if (!Directory.Exists(GuildDir) || (GuildDir[GuildDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("行会目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditGuildDir.Focus();
                return;
            }
            if (!File.Exists(GuildFile))
            {
                System.Windows.Forms.MessageBox.Show("行会文件设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditGuildFile.Focus();
                return;
            }
            if (!Directory.Exists(VentureDir) || (VentureDir[VentureDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("Venture目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditVentureDir.Focus();
                return;
            }
            if (!Directory.Exists(ConLogDir) || (ConLogDir[ConLogDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("登录日志目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditConLogDir.Focus();
                return;
            }
            if (!Directory.Exists(CastleDir) || (CastleDir[CastleDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("城堡目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditCastleDir.Focus();
                return;
            }
            if (!Directory.Exists(EnvirDir) || (EnvirDir[EnvirDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("配置目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditEnvirDir.Focus();
                return;
            }
            if (!Directory.Exists(MapDir) || (MapDir[MapDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("地图目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditMapDir.Focus();
                return;
            }
            if (!Directory.Exists(NoticeDir) || (NoticeDir[NoticeDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("公告目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditNoticeDir.Focus();
                return;
            }
            if (!Directory.Exists(PlugDir) || (PlugDir[PlugDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("插件目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditPlugDir.Focus();
                return;
            }
            if (!Directory.Exists(BoxsDir) || (BoxsDir[BoxsDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("宝箱目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditBoxsDir.Focus();
                return;
            }
            if (!Directory.Exists(SortDir) || (SortDir[SortDir.Length] != '\\'))
            {
                System.Windows.Forms.MessageBox.Show("排行榜目录设置错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                EditSortDir.Focus();
                return;
            }
            M2Share.g_Config.sGuildDir = GuildDir;
            M2Share.g_Config.sGuildFile = GuildFile;
            M2Share.g_Config.sVentureDir = VentureDir;
            M2Share.g_Config.sConLogDir = ConLogDir;
            M2Share.g_Config.sCastleDir = CastleDir;
            M2Share.g_Config.sBoxsDir = BoxsDir;// 宝箱目录
            M2Share.g_Config.sSortDir = SortDir;// 排行文件目录
            M2Share.g_Config.sEnvirDir = EnvirDir;
            M2Share.g_Config.sMapDir = MapDir;
            M2Share.g_Config.sNoticeDir = NoticeDir;
            M2Share.g_Config.sPlugDir = PlugDir;
            M2Share.Config.WriteString("Share", "GuildDir", M2Share.g_Config.sGuildDir);
            M2Share.Config.WriteString("Share", "GuildFile", M2Share.g_Config.sGuildFile);
            M2Share.Config.WriteString("Share", "VentureDir", M2Share.g_Config.sVentureDir);
            M2Share.Config.WriteString("Share", "ConLogDir", M2Share.g_Config.sConLogDir);
            M2Share.Config.WriteString("Share", "CastleDir", M2Share.g_Config.sCastleDir);
            M2Share.Config.WriteString("Share", "BoxsDir", M2Share.g_Config.sBoxsDir);// 宝箱目录
            M2Share.Config.WriteString("Share", "SortDir", M2Share.g_Config.sSortDir);// 排行榜文件目录 
            M2Share.Config.WriteString("Share", "EnvirDir", M2Share.g_Config.sEnvirDir);
            M2Share.Config.WriteString("Share", "MapDir", M2Share.g_Config.sMapDir);
            M2Share.Config.WriteString("Share", "NoticeDir", M2Share.g_Config.sNoticeDir);
            M2Share.Config.WriteString("Share", "PlugDir", M2Share.g_Config.sPlugDir);
            uModValue();
        }

        private void RefDlgConf()
        {
            //ColorBoxHint.SelectedIndex = Application.HintColor;
        }

        public void ColorBoxHintChange(object sender, EventArgs e)
        {
            //Application.HintColor = ColorBoxHint.Selected;
        }

        public void CheckBoxMinimizeClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_boMinimize = CheckBoxMinimize.Checked;
            ModValue();
        }
    }
}
