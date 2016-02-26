namespace DBServer
{
  partial class TFrmMain
    {
        public System.Windows.Forms.TextBox MemoLog;
        public System.Windows.Forms.Panel Panel;
        public System.Windows.Forms.Label LabelLoadHumRcd;
        public System.Windows.Forms.Label LabelSaveHumRcd;
        public System.Windows.Forms.Label LabelLoadHeroRcd;
        public System.Windows.Forms.Label LabelSaveHeroRcd;
        public System.Windows.Forms.Label LabelCreateHero;
        public System.Windows.Forms.Label LabelCreateHum;
        public System.Windows.Forms.Label LabelDeleteHum;
        public System.Windows.Forms.Label LabelDeleteHero;
        public System.Windows.Forms.Label LabelWorkStatus;
        public System.Windows.Forms.CheckBox CheckBoxShowMainLogMsg;
        public System.Windows.Forms.DataGridView ModuleGrid;
        public System.Windows.Forms.MainMenu MainMenu;
        public System.Windows.Forms.MenuItem MENU_CONTROL;
        public System.Windows.Forms.MenuItem MENU_CONTROL_START;
        public System.Windows.Forms.MenuItem MENU_CONTROL_STOP;
        public System.Windows.Forms.MenuItem N1;
        public System.Windows.Forms.MenuItem G1;
        public System.Windows.Forms.MenuItem C1;
        public System.Windows.Forms.MenuItem MENU_CONTROL_EXIT;
        public System.Windows.Forms.MenuItem MENU_OPTION;
        public System.Windows.Forms.MenuItem MENU_OPTION_GENERAL;
        public System.Windows.Forms.MenuItem MENU_OPTION_GAMEGATE;
        public System.Windows.Forms.MenuItem MENU_MANAGE;
        public System.Windows.Forms.MenuItem MENU_MANAGE_DATA;
        public System.Windows.Forms.MenuItem MENU_RANKING;
        public System.Windows.Forms.MenuItem MENU_TEST;
        public System.Windows.Forms.MenuItem MENU_TEST_SELGATE;
        public System.Windows.Forms.MenuItem MENU_HELP;
        public System.Windows.Forms.MenuItem MENU_HELP_VERSION;
        private System.Windows.Forms.ToolTip toolTip1 = null;

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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MemoLog = new System.Windows.Forms.TextBox();
            this.Panel = new System.Windows.Forms.Panel();
            this.LabelLoadHumRcd = new System.Windows.Forms.Label();
            this.LabelSaveHumRcd = new System.Windows.Forms.Label();
            this.LabelLoadHeroRcd = new System.Windows.Forms.Label();
            this.LabelSaveHeroRcd = new System.Windows.Forms.Label();
            this.LabelCreateHero = new System.Windows.Forms.Label();
            this.LabelCreateHum = new System.Windows.Forms.Label();
            this.LabelDeleteHum = new System.Windows.Forms.Label();
            this.LabelDeleteHero = new System.Windows.Forms.Label();
            this.LabelWorkStatus = new System.Windows.Forms.Label();
            this.CheckBoxShowMainLogMsg = new System.Windows.Forms.CheckBox();
            this.ModuleGrid = new System.Windows.Forms.DataGridView();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.MENU_CONTROL = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_START = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_STOP = new System.Windows.Forms.MenuItem();
            this.N1 = new System.Windows.Forms.MenuItem();
            this.G1 = new System.Windows.Forms.MenuItem();
            this.C1 = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_EXIT = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_GENERAL = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_GAMEGATE = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE_DATA = new System.Windows.Forms.MenuItem();
            this.MENU_RANKING = new System.Windows.Forms.MenuItem();
            this.MENU_TEST = new System.Windows.Forms.MenuItem();
            this.MENU_TEST_SELGATE = new System.Windows.Forms.MenuItem();
            this.MENU_HELP = new System.Windows.Forms.MenuItem();
            this.MENU_HELP_VERSION = new System.Windows.Forms.MenuItem();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MemoLog
            // 
            this.MemoLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.MemoLog.Location = new System.Drawing.Point(0, 57);
            this.MemoLog.Multiline = true;
            this.MemoLog.Name = "MemoLog";
            this.MemoLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MemoLog.Size = new System.Drawing.Size(488, 81);
            this.MemoLog.TabIndex = 0;
            this.MemoLog.ModifiedChanged += new System.EventHandler(this.MemoLogChange);
            this.MemoLog.DoubleClick += new System.EventHandler(this.MemoLogDblClick);
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Panel.Controls.Add(this.LabelLoadHumRcd);
            this.Panel.Controls.Add(this.LabelSaveHumRcd);
            this.Panel.Controls.Add(this.LabelLoadHeroRcd);
            this.Panel.Controls.Add(this.LabelSaveHeroRcd);
            this.Panel.Controls.Add(this.LabelCreateHero);
            this.Panel.Controls.Add(this.LabelCreateHum);
            this.Panel.Controls.Add(this.LabelDeleteHum);
            this.Panel.Controls.Add(this.LabelDeleteHero);
            this.Panel.Controls.Add(this.LabelWorkStatus);
            this.Panel.Controls.Add(this.CheckBoxShowMainLogMsg);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(488, 57);
            this.Panel.TabIndex = 1;
            // 
            // LabelLoadHumRcd
            // 
            this.LabelLoadHumRcd.AutoSize = true;
            this.LabelLoadHumRcd.Location = new System.Drawing.Point(184, 8);
            this.LabelLoadHumRcd.Name = "LabelLoadHumRcd";
            this.LabelLoadHumRcd.Size = new System.Drawing.Size(77, 12);
            this.LabelLoadHumRcd.TabIndex = 0;
            this.LabelLoadHumRcd.Text = "读取人物数据";
            // 
            // LabelSaveHumRcd
            // 
            this.LabelSaveHumRcd.AutoSize = true;
            this.LabelSaveHumRcd.Location = new System.Drawing.Point(184, 32);
            this.LabelSaveHumRcd.Name = "LabelSaveHumRcd";
            this.LabelSaveHumRcd.Size = new System.Drawing.Size(77, 12);
            this.LabelSaveHumRcd.TabIndex = 1;
            this.LabelSaveHumRcd.Text = "保存人物数据";
            // 
            // LabelLoadHeroRcd
            // 
            this.LabelLoadHeroRcd.AutoSize = true;
            this.LabelLoadHeroRcd.Location = new System.Drawing.Point(296, 8);
            this.LabelLoadHeroRcd.Name = "LabelLoadHeroRcd";
            this.LabelLoadHeroRcd.Size = new System.Drawing.Size(77, 12);
            this.LabelLoadHeroRcd.TabIndex = 2;
            this.LabelLoadHeroRcd.Text = "读取英雄数据";
            // 
            // LabelSaveHeroRcd
            // 
            this.LabelSaveHeroRcd.AutoSize = true;
            this.LabelSaveHeroRcd.Location = new System.Drawing.Point(296, 32);
            this.LabelSaveHeroRcd.Name = "LabelSaveHeroRcd";
            this.LabelSaveHeroRcd.Size = new System.Drawing.Size(77, 12);
            this.LabelSaveHeroRcd.TabIndex = 3;
            this.LabelSaveHeroRcd.Text = "保存英雄数据";
            // 
            // LabelCreateHero
            // 
            this.LabelCreateHero.AutoSize = true;
            this.LabelCreateHero.Location = new System.Drawing.Point(96, 8);
            this.LabelCreateHero.Name = "LabelCreateHero";
            this.LabelCreateHero.Size = new System.Drawing.Size(53, 12);
            this.LabelCreateHero.TabIndex = 4;
            this.LabelCreateHero.Text = "创建英雄";
            // 
            // LabelCreateHum
            // 
            this.LabelCreateHum.AutoSize = true;
            this.LabelCreateHum.Location = new System.Drawing.Point(8, 8);
            this.LabelCreateHum.Name = "LabelCreateHum";
            this.LabelCreateHum.Size = new System.Drawing.Size(53, 12);
            this.LabelCreateHum.TabIndex = 5;
            this.LabelCreateHum.Text = "创建人物";
            // 
            // LabelDeleteHum
            // 
            this.LabelDeleteHum.AutoSize = true;
            this.LabelDeleteHum.Location = new System.Drawing.Point(8, 32);
            this.LabelDeleteHum.Name = "LabelDeleteHum";
            this.LabelDeleteHum.Size = new System.Drawing.Size(53, 12);
            this.LabelDeleteHum.TabIndex = 6;
            this.LabelDeleteHum.Text = "删除人物";
            // 
            // LabelDeleteHero
            // 
            this.LabelDeleteHero.AutoSize = true;
            this.LabelDeleteHero.Location = new System.Drawing.Point(96, 32);
            this.LabelDeleteHero.Name = "LabelDeleteHero";
            this.LabelDeleteHero.Size = new System.Drawing.Size(53, 12);
            this.LabelDeleteHero.TabIndex = 7;
            this.LabelDeleteHero.Text = "删除英雄";
            // 
            // LabelWorkStatus
            // 
            this.LabelWorkStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelWorkStatus.Location = new System.Drawing.Point(464, 8);
            this.LabelWorkStatus.Name = "LabelWorkStatus";
            this.LabelWorkStatus.Size = new System.Drawing.Size(6, 12);
            this.LabelWorkStatus.TabIndex = 8;
            this.LabelWorkStatus.Visible = false;
            // 
            // CheckBoxShowMainLogMsg
            // 
            this.CheckBoxShowMainLogMsg.Location = new System.Drawing.Point(413, 30);
            this.CheckBoxShowMainLogMsg.Name = "CheckBoxShowMainLogMsg";
            this.CheckBoxShowMainLogMsg.Size = new System.Drawing.Size(75, 18);
            this.CheckBoxShowMainLogMsg.TabIndex = 0;
            this.CheckBoxShowMainLogMsg.Text = "显示日记";
            this.CheckBoxShowMainLogMsg.Click += new System.EventHandler(this.CheckBoxShowMainLogMsgClick);
            // 
            // ModuleGrid
            // 
            this.ModuleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleGrid.Location = new System.Drawing.Point(0, 138);
            this.ModuleGrid.Name = "ModuleGrid";
            this.ModuleGrid.Size = new System.Drawing.Size(488, 79);
            this.ModuleGrid.TabIndex = 2;
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL,
            this.MENU_OPTION,
            this.MENU_MANAGE,
            this.MENU_TEST,
            this.MENU_HELP});
            // 
            // MENU_CONTROL
            // 
            this.MENU_CONTROL.Index = 0;
            this.MENU_CONTROL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL_START,
            this.MENU_CONTROL_STOP,
            this.N1,
            this.MENU_CONTROL_EXIT});
            this.MENU_CONTROL.Text = "控制(&C)";
            // 
            // MENU_CONTROL_START
            // 
            this.MENU_CONTROL_START.Index = 0;
            this.MENU_CONTROL_START.Text = "启动服务(&S)";
            this.MENU_CONTROL_START.Click += new System.EventHandler(this.MENU_CONTROL_STARTClick);
            // 
            // MENU_CONTROL_STOP
            // 
            this.MENU_CONTROL_STOP.Index = 1;
            this.MENU_CONTROL_STOP.Text = "停止服务(&T)";
            this.MENU_CONTROL_STOP.Click += new System.EventHandler(this.MENU_CONTROL_STOPClick);
            // 
            // N1
            // 
            this.N1.Index = 2;
            this.N1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.G1,
            this.C1});
            this.N1.Text = "重新加载";
            // 
            // G1
            // 
            this.G1.Index = 0;
            this.G1.Text = "网关设置(&G)";
            this.G1.Click += new System.EventHandler(this.G1Click);
            // 
            // C1
            // 
            this.C1.Index = 1;
            this.C1.Text = "角色过滤列表(&C)";
            this.C1.Click += new System.EventHandler(this.C1Click);
            // 
            // MENU_CONTROL_EXIT
            // 
            this.MENU_CONTROL_EXIT.Index = 3;
            this.MENU_CONTROL_EXIT.Text = "退出(&X)";
            this.MENU_CONTROL_EXIT.Click += new System.EventHandler(this.MENU_CONTROL_EXITClick);
            // 
            // MENU_OPTION
            // 
            this.MENU_OPTION.Index = 1;
            this.MENU_OPTION.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_OPTION_GENERAL,
            this.MENU_OPTION_GAMEGATE});
            this.MENU_OPTION.Text = "选项(&O)";
            // 
            // MENU_OPTION_GENERAL
            // 
            this.MENU_OPTION_GENERAL.Index = 0;
            this.MENU_OPTION_GENERAL.Text = "基本设置(&G)";
            this.MENU_OPTION_GENERAL.Click += new System.EventHandler(this.MENU_OPTION_GENERALClick);
            // 
            // MENU_OPTION_GAMEGATE
            // 
            this.MENU_OPTION_GAMEGATE.Index = 1;
            this.MENU_OPTION_GAMEGATE.Text = "网关设置(&R)";
            this.MENU_OPTION_GAMEGATE.Click += new System.EventHandler(this.MENU_OPTION_GAMEGATEClick);
            // 
            // MENU_MANAGE
            // 
            this.MENU_MANAGE.Index = 2;
            this.MENU_MANAGE.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_MANAGE_DATA,
            this.MENU_RANKING});
            this.MENU_MANAGE.Text = "管理(&M)";
            // 
            // MENU_MANAGE_DATA
            // 
            this.MENU_MANAGE_DATA.Index = 0;
            this.MENU_MANAGE_DATA.Text = "数据管理(&D)";
            this.MENU_MANAGE_DATA.Click += new System.EventHandler(this.MENU_MANAGE_DATAClick);
            // 
            // MENU_RANKING
            // 
            this.MENU_RANKING.Index = 1;
            this.MENU_RANKING.Text = "排行榜管理(&R)";
            this.MENU_RANKING.Click += new System.EventHandler(this.MENU_RANKINGClick);
            // 
            // MENU_TEST
            // 
            this.MENU_TEST.Index = 3;
            this.MENU_TEST.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_TEST_SELGATE});
            this.MENU_TEST.Text = "测试(&T)";
            // 
            // MENU_TEST_SELGATE
            // 
            this.MENU_TEST_SELGATE.Index = 0;
            this.MENU_TEST_SELGATE.Text = "选择网关(&S)";
            this.MENU_TEST_SELGATE.Click += new System.EventHandler(this.MENU_TEST_SELGATEClick);
            // 
            // MENU_HELP
            // 
            this.MENU_HELP.Index = 4;
            this.MENU_HELP.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_HELP_VERSION});
            this.MENU_HELP.Text = "帮助(&H)";
            // 
            // MENU_HELP_VERSION
            // 
            this.MENU_HELP_VERSION.Index = 0;
            this.MENU_HELP_VERSION.Text = "关于(&A)";
            this.MENU_HELP_VERSION.Click += new System.EventHandler(this.MENU_HELP_VERSIONClick);
            // 
            // TFrmMain
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(488, 217);
            this.Controls.Add(this.ModuleGrid);
            this.Controls.Add(this.MemoLog);
            this.Controls.Add(this.Panel);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(403, 381);
            this.Menu = this.MainMenu;
            this.Name = "TFrmMain";
            this.Text = "数据库服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FormCreate);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
