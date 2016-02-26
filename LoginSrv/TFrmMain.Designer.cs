namespace LoginSrv
{
  partial class TFrmMain
    {
        public System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.Button BtnDump;
        public System.Windows.Forms.Panel Panel2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Button SpeedButton1;
        public System.Windows.Forms.Label LbMasCount;
        public System.Windows.Forms.Button BtnView;
        public System.Windows.Forms.Button BtnShowServerUsers;
        public System.Windows.Forms.Button SpeedButton2;
        public System.Windows.Forms.CheckBox CkLogin;
        public System.Windows.Forms.CheckBox CbViewLog;
        public System.Windows.Forms.CheckBox CheckBoxAttack;
        public System.Windows.Forms.TextBox Memo1;
        public System.Windows.Forms.MainMenu MainMenu;
        public System.Windows.Forms.MenuItem MENU_CONTROL;
        public System.Windows.Forms.MenuItem N1;
        public System.Windows.Forms.MenuItem C1;
        public System.Windows.Forms.MenuItem MENU_CONTROL_EXIT;
        public System.Windows.Forms.MenuItem MENU_VIEW;
        public System.Windows.Forms.MenuItem MENU_VIEW_SESSION;
        public System.Windows.Forms.MenuItem MENU_OPTION;
        public System.Windows.Forms.MenuItem MENU_OPTION_GENERAL;
        public System.Windows.Forms.MenuItem MENU_OPTION_ROUTE;
        public System.Windows.Forms.MenuItem MENU_TOOLS;
        public System.Windows.Forms.MenuItem MENU_HELP;
        public System.Windows.Forms.MenuItem MENU_HELP_ABOUT;
        //public TApplicationEvents ApplicationEvents1;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.MonitorGrid = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnDump = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.SpeedButton1 = new System.Windows.Forms.Button();
            this.LbMasCount = new System.Windows.Forms.Label();
            this.BtnView = new System.Windows.Forms.Button();
            this.BtnShowServerUsers = new System.Windows.Forms.Button();
            this.SpeedButton2 = new System.Windows.Forms.Button();
            this.CkLogin = new System.Windows.Forms.CheckBox();
            this.CbViewLog = new System.Windows.Forms.CheckBox();
            this.CheckBoxAttack = new System.Windows.Forms.CheckBox();
            this.Memo1 = new System.Windows.Forms.TextBox();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.MENU_CONTROL = new System.Windows.Forms.MenuItem();
            this.N1 = new System.Windows.Forms.MenuItem();
            this.C1 = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_EXIT = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_SESSION = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_GENERAL = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_ROUTE = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS = new System.Windows.Forms.MenuItem();
            this.MENU_HELP = new System.Windows.Forms.MenuItem();
            this.MENU_HELP_ABOUT = new System.Windows.Forms.MenuItem();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Teal;
            this.Panel1.Controls.Add(this.MonitorGrid);
            this.Panel1.Controls.Add(this.BtnDump);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 101);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(473, 233);
            this.Panel1.TabIndex = 0;
            this.Panel1.Text = " ";
            // 
            // MonitorGrid
            // 
            this.MonitorGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MonitorGrid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.MonitorGrid.FullRowSelect = true;
            this.MonitorGrid.Location = new System.Drawing.Point(2, 46);
            this.MonitorGrid.Name = "MonitorGrid";
            this.MonitorGrid.Size = new System.Drawing.Size(464, 182);
            this.MonitorGrid.TabIndex = 2;
            this.MonitorGrid.UseCompatibleStateImageBehavior = false;
            this.MonitorGrid.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "服务器";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP";
            this.columnHeader3.Width = 112;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "状态";
            this.columnHeader4.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "在线人数";
            this.columnHeader5.Width = 88;
            // 
            // BtnDump
            // 
            this.BtnDump.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDump.Location = new System.Drawing.Point(568, 2);
            this.BtnDump.Name = "BtnDump";
            this.BtnDump.Size = new System.Drawing.Size(57, 17);
            this.BtnDump.TabIndex = 0;
            this.BtnDump.Text = "Dump";
            this.BtnDump.UseVisualStyleBackColor = false;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Teal;
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Controls.Add(this.SpeedButton1);
            this.Panel2.Controls.Add(this.LbMasCount);
            this.Panel2.Controls.Add(this.BtnView);
            this.Panel2.Controls.Add(this.BtnShowServerUsers);
            this.Panel2.Controls.Add(this.SpeedButton2);
            this.Panel2.Controls.Add(this.CkLogin);
            this.Panel2.Controls.Add(this.CbViewLog);
            this.Panel2.Controls.Add(this.CheckBoxAttack);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(473, 45);
            this.Panel2.TabIndex = 1;
            this.Panel2.Text = " ";
            this.Panel2.DoubleClick += new System.EventHandler(this.Panel2DblClick);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(12, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "00";
            // 
            // SpeedButton1
            // 
            this.SpeedButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SpeedButton1.Location = new System.Drawing.Point(242, 5);
            this.SpeedButton1.Name = "SpeedButton1";
            this.SpeedButton1.Size = new System.Drawing.Size(65, 30);
            this.SpeedButton1.TabIndex = 1;
            this.SpeedButton1.Text = "帐号管理";
            this.SpeedButton1.UseVisualStyleBackColor = false;
            this.SpeedButton1.Click += new System.EventHandler(this.SpeedButton1Click);
            // 
            // LbMasCount
            // 
            this.LbMasCount.Location = new System.Drawing.Point(170, 5);
            this.LbMasCount.Name = "LbMasCount";
            this.LbMasCount.Size = new System.Drawing.Size(59, 12);
            this.LbMasCount.TabIndex = 2;
            this.LbMasCount.Text = "LbMasCount";
            // 
            // BtnView
            // 
            this.BtnView.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnView.Location = new System.Drawing.Point(317, 5);
            this.BtnView.Name = "BtnView";
            this.BtnView.Size = new System.Drawing.Size(67, 30);
            this.BtnView.TabIndex = 3;
            this.BtnView.Text = "充值记录";
            this.BtnView.UseVisualStyleBackColor = false;
            this.BtnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // BtnShowServerUsers
            // 
            this.BtnShowServerUsers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnShowServerUsers.Location = new System.Drawing.Point(395, 5);
            this.BtnShowServerUsers.Name = "BtnShowServerUsers";
            this.BtnShowServerUsers.Size = new System.Drawing.Size(71, 30);
            this.BtnShowServerUsers.TabIndex = 4;
            this.BtnShowServerUsers.Text = "人数限制";
            this.BtnShowServerUsers.UseVisualStyleBackColor = false;
            this.BtnShowServerUsers.Click += new System.EventHandler(this.BtnShowServerUsersClick);
            // 
            // SpeedButton2
            // 
            this.SpeedButton2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SpeedButton2.Location = new System.Drawing.Point(61, 1);
            this.SpeedButton2.Name = "SpeedButton2";
            this.SpeedButton2.Size = new System.Drawing.Size(23, 17);
            this.SpeedButton2.TabIndex = 5;
            this.SpeedButton2.Text = "#";
            this.SpeedButton2.UseVisualStyleBackColor = false;
            this.SpeedButton2.Click += new System.EventHandler(this.SpeedButton2Click);
            // 
            // CkLogin
            // 
            this.CkLogin.Enabled = false;
            this.CkLogin.Location = new System.Drawing.Point(8, 1);
            this.CkLogin.Name = "CkLogin";
            this.CkLogin.Size = new System.Drawing.Size(65, 17);
            this.CkLogin.TabIndex = 0;
            this.CkLogin.Text = "连接 (0)";
            // 
            // CbViewLog
            // 
            this.CbViewLog.Location = new System.Drawing.Point(98, 3);
            this.CbViewLog.Name = "CbViewLog";
            this.CbViewLog.Size = new System.Drawing.Size(73, 17);
            this.CbViewLog.TabIndex = 1;
            this.CbViewLog.Text = "显示信息";
            this.CbViewLog.Click += new System.EventHandler(this.CbViewLogClick);
            // 
            // CheckBoxAttack
            // 
            this.CheckBoxAttack.Checked = true;
            this.CheckBoxAttack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAttack.Location = new System.Drawing.Point(98, 26);
            this.CheckBoxAttack.Name = "CheckBoxAttack";
            this.CheckBoxAttack.Size = new System.Drawing.Size(97, 17);
            this.CheckBoxAttack.TabIndex = 2;
            this.CheckBoxAttack.Text = "防攻击保护";
            // 
            // Memo1
            // 
            this.Memo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Memo1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Memo1.Location = new System.Drawing.Point(0, 0);
            this.Memo1.Multiline = true;
            this.Memo1.Name = "Memo1";
            this.Memo1.Size = new System.Drawing.Size(473, 101);
            this.Memo1.TabIndex = 1;
            this.Memo1.DoubleClick += new System.EventHandler(this.Memo1DblClick);
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL,
            this.MENU_VIEW,
            this.MENU_OPTION,
            this.MENU_TOOLS,
            this.MENU_HELP});
            // 
            // MENU_CONTROL
            // 
            this.MENU_CONTROL.Index = 0;
            this.MENU_CONTROL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.N1,
            this.C1,
            this.MENU_CONTROL_EXIT});
            this.MENU_CONTROL.Text = "控制(&C)";
            // 
            // N1
            // 
            this.N1.Index = 0;
            this.N1.Text = "重新加载路由列表(&R)";
            this.N1.Click += new System.EventHandler(this.N1Click);
            // 
            // C1
            // 
            this.C1.Index = 1;
            this.C1.Text = "重新加载配制(&C)";
            this.C1.Click += new System.EventHandler(this.C1Click);
            // 
            // MENU_CONTROL_EXIT
            // 
            this.MENU_CONTROL_EXIT.Index = 2;
            this.MENU_CONTROL_EXIT.Text = "退出(&X)";
            this.MENU_CONTROL_EXIT.Click += new System.EventHandler(this.MENU_CONTROL_EXITClick);
            // 
            // MENU_VIEW
            // 
            this.MENU_VIEW.Index = 1;
            this.MENU_VIEW.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_VIEW_SESSION});
            this.MENU_VIEW.Text = "查看(&V)";
            // 
            // MENU_VIEW_SESSION
            // 
            this.MENU_VIEW_SESSION.Index = 0;
            this.MENU_VIEW_SESSION.Text = "全局会话(&G)";
            this.MENU_VIEW_SESSION.Click += new System.EventHandler(this.MENU_VIEW_SESSIONClick);
            // 
            // MENU_OPTION
            // 
            this.MENU_OPTION.Index = 2;
            this.MENU_OPTION.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_OPTION_GENERAL,
            this.MENU_OPTION_ROUTE});
            this.MENU_OPTION.Text = "选项(&O)";
            // 
            // MENU_OPTION_GENERAL
            // 
            this.MENU_OPTION_GENERAL.Index = 0;
            this.MENU_OPTION_GENERAL.Text = "基本设置(&G)";
            this.MENU_OPTION_GENERAL.Click += new System.EventHandler(this.MENU_OPTION_GENERALClick);
            // 
            // MENU_OPTION_ROUTE
            // 
            this.MENU_OPTION_ROUTE.Index = 1;
            this.MENU_OPTION_ROUTE.Text = "网关设置(&R)";
            this.MENU_OPTION_ROUTE.Click += new System.EventHandler(this.MENU_OPTION_ROUTEClick);
            // 
            // MENU_TOOLS
            // 
            this.MENU_TOOLS.Index = 3;
            this.MENU_TOOLS.Text = "工具(&T)";
            // 
            // MENU_HELP
            // 
            this.MENU_HELP.Index = 4;
            this.MENU_HELP.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_HELP_ABOUT});
            this.MENU_HELP.Text = "帮助(&H)";
            // 
            // MENU_HELP_ABOUT
            // 
            this.MENU_HELP_ABOUT.Index = 0;
            this.MENU_HELP_ABOUT.Text = "关于(&A)";
            this.MENU_HELP_ABOUT.Click += new System.EventHandler(this.MENU_HELP_ABOUTClick);
            // 
            // TFrmMain
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(473, 334);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Memo1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(847, 185);
            this.Menu = this.MainMenu;
            this.Name = "TFrmMain";
            this.Text = "帐号登录服务器";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormCloseQuery);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TFrmMain_FormClosed);
            this.Load += new System.EventHandler(this.TFrmMain_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ListView MonitorGrid;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;

    }
}
