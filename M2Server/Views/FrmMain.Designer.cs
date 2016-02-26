namespace M2Server
{
  partial class TFrmMain
    {
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label Lbcheck;
        private System.Windows.Forms.Timer SaveVariableTimer;
        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem MENU_CONTROL;
        private System.Windows.Forms.MenuItem MENU_CONTROL_CLEARLOGMSG;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_ITEMDB;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_MAGICDB;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_MONSTERDB;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_MONSTERSAY;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_DISABLEMAKE;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_STARTPOINT;
        private System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_CONF;
        private System.Windows.Forms.MenuItem QFunctionNPC;
        private System.Windows.Forms.MenuItem QManageNPC;
        private System.Windows.Forms.MenuItem RobotManageNPC;
        private System.Windows.Forms.MenuItem MonItems;
        private System.Windows.Forms.MenuItem N2;
        private System.Windows.Forms.MenuItem N3;
        private System.Windows.Forms.MenuItem N5;
        private System.Windows.Forms.MenuItem N6;
        private System.Windows.Forms.MenuItem NPC1;
        private System.Windows.Forms.MenuItem NPC2;
        private System.Windows.Forms.MenuItem N7;
        private System.Windows.Forms.MenuItem S1;
        private System.Windows.Forms.MenuItem N4;
        private System.Windows.Forms.MenuItem mapconfig;
        private System.Windows.Forms.MenuItem monster;
        private System.Windows.Forms.MenuItem MENU_CONTROL_GATE;
        private System.Windows.Forms.MenuItem MENU_CONTROL_GATE_OPEN;
        private System.Windows.Forms.MenuItem MENU_CONTROL_GATE_CLOSE;
        private System.Windows.Forms.MenuItem MENU_CONTROL_EXIT;
        private System.Windows.Forms.MenuItem MENU_VIEW;
        private System.Windows.Forms.MenuItem MENU_VIEW_ONLINEHUMAN;
        private System.Windows.Forms.MenuItem MENU_VIEW_SESSION;
        private System.Windows.Forms.MenuItem MENU_VIEW_LEVEL;
        private System.Windows.Forms.MenuItem MENU_VIEW_LIST;
        private System.Windows.Forms.MenuItem N1;
        private System.Windows.Forms.MenuItem MENU_VIEW_KERNELINFO;
        private System.Windows.Forms.MenuItem MENU_OPTION;
        private System.Windows.Forms.MenuItem MENU_OPTION_GENERAL;
        private System.Windows.Forms.MenuItem MENU_OPTION_GAME;
        private System.Windows.Forms.MenuItem MENU_OPTION_ITEMFUNC;
        private System.Windows.Forms.MenuItem MENU_OPTION_FUNCTION;
        private System.Windows.Forms.MenuItem G1;
        private System.Windows.Forms.MenuItem MENU_OPTION_MONSTER;
        private System.Windows.Forms.MenuItem MENU_OPTION_SERVERCONFIG;
        private System.Windows.Forms.MenuItem MENU_OPTION_HERO;
        private System.Windows.Forms.MenuItem MENU_MANAGE;
        private System.Windows.Forms.MenuItem MENU_MANAGE_ONLINEMSG;
        private System.Windows.Forms.MenuItem MENU_MANAGE_CASTLE;
        private System.Windows.Forms.MenuItem G2;
        private System.Windows.Forms.MenuItem MENU_TOOLS;
        private System.Windows.Forms.MenuItem MENU_TOOLS_MERCHANT;
        private System.Windows.Forms.MenuItem MENU_TOOLS_NPC;
        private System.Windows.Forms.MenuItem MENU_TOOLS_MONGEN;
        private System.Windows.Forms.MenuItem MENU_TOOLS_IPSEARCH;
        private System.Windows.Forms.MenuItem MENU_HELP;
        private System.Windows.Forms.MenuItem MENU_HELP_ABOUT;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFrmMain));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Panel = new System.Windows.Forms.Panel();
            this.Lbcheck = new System.Windows.Forms.Label();
            this.SaveVariableTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.MENU_CONTROL = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_CLEARLOGMSG = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_ITEMDB = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_MAGICDB = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_MONSTERDB = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_MONSTERSAY = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_DISABLEMAKE = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_STARTPOINT = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_CONF = new System.Windows.Forms.MenuItem();
            this.QFunctionNPC = new System.Windows.Forms.MenuItem();
            this.QManageNPC = new System.Windows.Forms.MenuItem();
            this.RobotManageNPC = new System.Windows.Forms.MenuItem();
            this.MonItems = new System.Windows.Forms.MenuItem();
            this.N2 = new System.Windows.Forms.MenuItem();
            this.N3 = new System.Windows.Forms.MenuItem();
            this.N5 = new System.Windows.Forms.MenuItem();
            this.N6 = new System.Windows.Forms.MenuItem();
            this.NPC1 = new System.Windows.Forms.MenuItem();
            this.NPC2 = new System.Windows.Forms.MenuItem();
            this.N7 = new System.Windows.Forms.MenuItem();
            this.S1 = new System.Windows.Forms.MenuItem();
            this.N4 = new System.Windows.Forms.MenuItem();
            this.mapconfig = new System.Windows.Forms.MenuItem();
            this.monster = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_GATE = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_GATE_OPEN = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_GATE_CLOSE = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_EXIT = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_ONLINEHUMAN = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_SESSION = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_LEVEL = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_LIST = new System.Windows.Forms.MenuItem();
            this.N1 = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_KERNELINFO = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_GENERAL = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_GAME = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_ITEMFUNC = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_FUNCTION = new System.Windows.Forms.MenuItem();
            this.G1 = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_MONSTER = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_SERVERCONFIG = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_HERO = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE_ONLINEMSG = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE_CASTLE = new System.Windows.Forms.MenuItem();
            this.G2 = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE_SYS = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_MERCHANT = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_NPC = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_MONGEN = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_IPSEARCH = new System.Windows.Forms.MenuItem();
            this.MENU_HELP = new System.Windows.Forms.MenuItem();
            this.MENU_HELP_ABOUT = new System.Windows.Forms.MenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label20 = new System.Windows.Forms.Label();
            this.LbRunTime = new System.Windows.Forms.Label();
            this.LbUserCount = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.LbRunSocketTime = new System.Windows.Forms.Label();
            this.MemStatus = new System.Windows.Forms.Label();
            this.GateListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemoLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ErrorMemoLog = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Panel.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.Lbcheck);
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(200, 100);
            this.Panel.TabIndex = 0;
            // 
            // Lbcheck
            // 
            this.Lbcheck.Location = new System.Drawing.Point(48, 64);
            this.Lbcheck.Name = "Lbcheck";
            this.Lbcheck.Size = new System.Drawing.Size(6, 12);
            this.Lbcheck.TabIndex = 4;
            this.Lbcheck.Visible = false;
            // 
            // SaveVariableTimer
            // 
            this.SaveVariableTimer.Interval = 30000;
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL,
            this.MENU_VIEW,
            this.MENU_OPTION,
            this.MENU_MANAGE,
            this.MENU_TOOLS,
            this.MENU_HELP});
            // 
            // MENU_CONTROL
            // 
            this.MENU_CONTROL.Index = 0;
            this.MENU_CONTROL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL_CLEARLOGMSG,
            this.MENU_CONTROL_RELOAD,
            this.MENU_CONTROL_GATE,
            this.MENU_CONTROL_EXIT});
            this.MENU_CONTROL.Text = "控制(&C)";
            this.MENU_CONTROL.Click += new System.EventHandler(this.MENU_CONTROLClick);
            // 
            // MENU_CONTROL_CLEARLOGMSG
            // 
            this.MENU_CONTROL_CLEARLOGMSG.Index = 0;
            this.MENU_CONTROL_CLEARLOGMSG.Text = "清除日志(&C)";
            this.MENU_CONTROL_CLEARLOGMSG.Click += new System.EventHandler(this.MENU_CONTROL_CLEARLOGMSGClick);
            // 
            // MENU_CONTROL_RELOAD
            // 
            this.MENU_CONTROL_RELOAD.Index = 1;
            this.MENU_CONTROL_RELOAD.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL_RELOAD_ITEMDB,
            this.MENU_CONTROL_RELOAD_MAGICDB,
            this.MENU_CONTROL_RELOAD_MONSTERDB,
            this.MENU_CONTROL_RELOAD_MONSTERSAY,
            this.MENU_CONTROL_RELOAD_DISABLEMAKE,
            this.MENU_CONTROL_RELOAD_STARTPOINT,
            this.MENU_CONTROL_RELOAD_CONF,
            this.QFunctionNPC,
            this.QManageNPC,
            this.RobotManageNPC,
            this.MonItems,
            this.N2,
            this.N3,
            this.N5,
            this.N6,
            this.NPC1,
            this.NPC2,
            this.N7,
            this.S1,
            this.N4,
            this.mapconfig,
            this.monster});
            this.MENU_CONTROL_RELOAD.Text = "重新加载(&R)";
            // 
            // MENU_CONTROL_RELOAD_ITEMDB
            // 
            this.MENU_CONTROL_RELOAD_ITEMDB.Index = 0;
            this.MENU_CONTROL_RELOAD_ITEMDB.Text = "物品数据库(&I)";
            this.MENU_CONTROL_RELOAD_ITEMDB.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_ITEMDBClick);
            // 
            // MENU_CONTROL_RELOAD_MAGICDB
            // 
            this.MENU_CONTROL_RELOAD_MAGICDB.Index = 1;
            this.MENU_CONTROL_RELOAD_MAGICDB.Text = "技能数据库(&S)";
            this.MENU_CONTROL_RELOAD_MAGICDB.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_MAGICDBClick);
            // 
            // MENU_CONTROL_RELOAD_MONSTERDB
            // 
            this.MENU_CONTROL_RELOAD_MONSTERDB.Index = 2;
            this.MENU_CONTROL_RELOAD_MONSTERDB.Text = "怪物数据库(&M)";
            this.MENU_CONTROL_RELOAD_MONSTERDB.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_MONSTERDBClick);
            // 
            // MENU_CONTROL_RELOAD_MONSTERSAY
            // 
            this.MENU_CONTROL_RELOAD_MONSTERSAY.Index = 3;
            this.MENU_CONTROL_RELOAD_MONSTERSAY.Text = "怪物说话设置(&M)";
            this.MENU_CONTROL_RELOAD_MONSTERSAY.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_MONSTERSAYClick);
            // 
            // MENU_CONTROL_RELOAD_DISABLEMAKE
            // 
            this.MENU_CONTROL_RELOAD_DISABLEMAKE.Index = 4;
            this.MENU_CONTROL_RELOAD_DISABLEMAKE.Text = "数据列表(&D)";
            this.MENU_CONTROL_RELOAD_DISABLEMAKE.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_DISABLEMAKEClick);
            // 
            // MENU_CONTROL_RELOAD_STARTPOINT
            // 
            this.MENU_CONTROL_RELOAD_STARTPOINT.Index = 5;
            this.MENU_CONTROL_RELOAD_STARTPOINT.Text = "地图安全区(&S)";
            this.MENU_CONTROL_RELOAD_STARTPOINT.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_STARTPOINTClick);
            // 
            // MENU_CONTROL_RELOAD_CONF
            // 
            this.MENU_CONTROL_RELOAD_CONF.Index = 6;
            this.MENU_CONTROL_RELOAD_CONF.Text = "参数设置(&C)";
            this.MENU_CONTROL_RELOAD_CONF.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_CONFClick);
            // 
            // QFunctionNPC
            // 
            this.QFunctionNPC.Index = 7;
            this.QFunctionNPC.Text = "QFunction 脚本(&Q)";
            this.QFunctionNPC.Click += new System.EventHandler(this.QFunctionNPCClick);
            // 
            // QManageNPC
            // 
            this.QManageNPC.Index = 8;
            this.QManageNPC.Text = "登陆脚本(&L)";
            this.QManageNPC.Click += new System.EventHandler(this.QManageNPCClick);
            // 
            // RobotManageNPC
            // 
            this.RobotManageNPC.Index = 9;
            this.RobotManageNPC.Text = "机器人脚本(&R)";
            this.RobotManageNPC.Click += new System.EventHandler(this.RobotManageNPCClick);
            // 
            // MonItems
            // 
            this.MonItems.Index = 10;
            this.MonItems.Text = "怪物爆率(&M)";
            this.MonItems.Click += new System.EventHandler(this.MonItemsClick);
            // 
            // N2
            // 
            this.N2.Index = 11;
            this.N2.Text = "-";
            // 
            // N3
            // 
            this.N3.Index = 12;
            this.N3.Text = "宝箱配置";
            this.N3.Click += new System.EventHandler(this.N3Click);
            // 
            // N5
            // 
            this.N5.Index = 13;
            this.N5.Text = "怪物刷新配置";
            this.N5.Click += new System.EventHandler(this.N5Click);
            // 
            // N6
            // 
            this.N6.Index = 14;
            this.N6.Text = "公告提示信息";
            this.N6.Click += new System.EventHandler(this.N6Click);
            // 
            // NPC1
            // 
            this.NPC1.Index = 15;
            this.NPC1.Text = "交易NPC配置";
            this.NPC1.Click += new System.EventHandler(this.NPC1Click);
            // 
            // NPC2
            // 
            this.NPC2.Index = 16;
            this.NPC2.Text = "管理NPC配置";
            this.NPC2.Click += new System.EventHandler(this.NPC2Click);
            // 
            // N7
            // 
            this.N7.Index = 17;
            this.N7.Text = "淬炼配置";
            this.N7.Click += new System.EventHandler(this.N7Click);
            // 
            // S1
            // 
            this.S1.Index = 18;
            this.S1.Text = "初始化沙城配置(&S)";
            this.S1.Click += new System.EventHandler(this.S1Click);
            // 
            // N4
            // 
            this.N4.Index = 19;
            this.N4.Text = "商铺配置";
            this.N4.Click += new System.EventHandler(this.N4Click);
            // 
            // mapconfig
            // 
            this.mapconfig.Index = 20;
            this.mapconfig.Text = "地图配置";
            this.mapconfig.Click += new System.EventHandler(this.mapconfigClick);
            // 
            // monster
            // 
            this.monster.Index = 21;
            this.monster.Text = "刷怪配置";
            this.monster.Click += new System.EventHandler(this.monsterClick);
            // 
            // MENU_CONTROL_GATE
            // 
            this.MENU_CONTROL_GATE.Index = 2;
            this.MENU_CONTROL_GATE.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL_GATE_OPEN,
            this.MENU_CONTROL_GATE_CLOSE});
            this.MENU_CONTROL_GATE.Text = "游戏网关(&G)";
            // 
            // MENU_CONTROL_GATE_OPEN
            // 
            this.MENU_CONTROL_GATE_OPEN.Index = 0;
            this.MENU_CONTROL_GATE_OPEN.Text = "打开(&O)";
            this.MENU_CONTROL_GATE_OPEN.Click += new System.EventHandler(this.MENU_CONTROL_GATE_OPENClick);
            // 
            // MENU_CONTROL_GATE_CLOSE
            // 
            this.MENU_CONTROL_GATE_CLOSE.Index = 1;
            this.MENU_CONTROL_GATE_CLOSE.Text = "关闭(&C)";
            this.MENU_CONTROL_GATE_CLOSE.Click += new System.EventHandler(this.MENU_CONTROL_GATE_CLOSEClick);
            // 
            // MENU_CONTROL_EXIT
            // 
            this.MENU_CONTROL_EXIT.Index = 3;
            this.MENU_CONTROL_EXIT.Text = "退出(&X)";
            this.MENU_CONTROL_EXIT.Click += new System.EventHandler(this.MENU_CONTROL_EXITClick);
            // 
            // MENU_VIEW
            // 
            this.MENU_VIEW.Index = 1;
            this.MENU_VIEW.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_VIEW_ONLINEHUMAN,
            this.MENU_VIEW_SESSION,
            this.MENU_VIEW_LEVEL,
            this.MENU_VIEW_LIST,
            this.N1,
            this.MENU_VIEW_KERNELINFO});
            this.MENU_VIEW.Text = "查看(&V)";
            // 
            // MENU_VIEW_ONLINEHUMAN
            // 
            this.MENU_VIEW_ONLINEHUMAN.Index = 0;
            this.MENU_VIEW_ONLINEHUMAN.Text = "在线人物(&O)";
            this.MENU_VIEW_ONLINEHUMAN.Click += new System.EventHandler(this.MENU_VIEW_ONLINEHUMANClick);
            // 
            // MENU_VIEW_SESSION
            // 
            this.MENU_VIEW_SESSION.Index = 1;
            this.MENU_VIEW_SESSION.Text = "全局会话(&S)";
            this.MENU_VIEW_SESSION.Click += new System.EventHandler(this.MENU_VIEW_SESSIONClick);
            // 
            // MENU_VIEW_LEVEL
            // 
            this.MENU_VIEW_LEVEL.Index = 2;
            this.MENU_VIEW_LEVEL.Text = "等级属性(&L)";
            this.MENU_VIEW_LEVEL.Click += new System.EventHandler(this.MENU_VIEW_LEVELClick);
            // 
            // MENU_VIEW_LIST
            // 
            this.MENU_VIEW_LIST.Index = 3;
            this.MENU_VIEW_LIST.Text = "列表信息一(&L)";
            this.MENU_VIEW_LIST.Click += new System.EventHandler(this.MENU_VIEW_LISTClick);
            // 
            // N1
            // 
            this.N1.Index = 4;
            this.N1.Text = "列表信息二(&L)";
            this.N1.Click += new System.EventHandler(this.N1Click);
            // 
            // MENU_VIEW_KERNELINFO
            // 
            this.MENU_VIEW_KERNELINFO.Index = 5;
            this.MENU_VIEW_KERNELINFO.Text = "内核数据(&K)";
            this.MENU_VIEW_KERNELINFO.Click += new System.EventHandler(this.MENU_VIEW_KERNELINFOClick);
            // 
            // MENU_OPTION
            // 
            this.MENU_OPTION.Index = 2;
            this.MENU_OPTION.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_OPTION_GENERAL,
            this.MENU_OPTION_GAME,
            this.MENU_OPTION_ITEMFUNC,
            this.MENU_OPTION_FUNCTION,
            this.G1,
            this.MENU_OPTION_MONSTER,
            this.MENU_OPTION_SERVERCONFIG,
            this.MENU_OPTION_HERO});
            this.MENU_OPTION.Text = "选项(&P)";
            // 
            // MENU_OPTION_GENERAL
            // 
            this.MENU_OPTION_GENERAL.Index = 0;
            this.MENU_OPTION_GENERAL.Text = "基本设置(&G)";
            this.MENU_OPTION_GENERAL.Click += new System.EventHandler(this.MENU_OPTION_GENERALClick);
            // 
            // MENU_OPTION_GAME
            // 
            this.MENU_OPTION_GAME.Index = 1;
            this.MENU_OPTION_GAME.Text = "参数设置(&O)";
            this.MENU_OPTION_GAME.Click += new System.EventHandler(this.MENU_OPTION_GAMEClick);
            // 
            // MENU_OPTION_ITEMFUNC
            // 
            this.MENU_OPTION_ITEMFUNC.Index = 2;
            this.MENU_OPTION_ITEMFUNC.Text = "物品装备(&I)";
            this.MENU_OPTION_ITEMFUNC.Click += new System.EventHandler(this.MENU_OPTION_ITEMFUNCClick);
            // 
            // MENU_OPTION_FUNCTION
            // 
            this.MENU_OPTION_FUNCTION.Index = 3;
            this.MENU_OPTION_FUNCTION.Text = "功能设置(&F)";
            this.MENU_OPTION_FUNCTION.Click += new System.EventHandler(this.MENU_OPTION_FUNCTIONClick);
            // 
            // G1
            // 
            this.G1.Index = 4;
            this.G1.Text = "游戏命令(&C)";
            this.G1.Click += new System.EventHandler(this.G1Click);
            // 
            // MENU_OPTION_MONSTER
            // 
            this.MENU_OPTION_MONSTER.Index = 5;
            this.MENU_OPTION_MONSTER.Text = "怪物设置(&M)";
            this.MENU_OPTION_MONSTER.Click += new System.EventHandler(this.MENU_OPTION_MONSTERClick);
            // 
            // MENU_OPTION_SERVERCONFIG
            // 
            this.MENU_OPTION_SERVERCONFIG.Index = 6;
            this.MENU_OPTION_SERVERCONFIG.Text = "性能参数(&P)";
            this.MENU_OPTION_SERVERCONFIG.Click += new System.EventHandler(this.MENU_OPTION_SERVERCONFIGClick);
            // 
            // MENU_OPTION_HERO
            // 
            this.MENU_OPTION_HERO.Index = 7;
            this.MENU_OPTION_HERO.Text = "英雄设置(&H)";
            this.MENU_OPTION_HERO.Click += new System.EventHandler(this.MENU_OPTION_HEROClick);
            // 
            // MENU_MANAGE
            // 
            this.MENU_MANAGE.Index = 3;
            this.MENU_MANAGE.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_MANAGE_ONLINEMSG,
            this.MENU_MANAGE_CASTLE,
            this.G2,
            this.MENU_MANAGE_SYS});
            this.MENU_MANAGE.Text = "管理(&M)";
            // 
            // MENU_MANAGE_ONLINEMSG
            // 
            this.MENU_MANAGE_ONLINEMSG.Index = 0;
            this.MENU_MANAGE_ONLINEMSG.Text = "在线消息(&S)";
            this.MENU_MANAGE_ONLINEMSG.Click += new System.EventHandler(this.MENU_MANAGE_ONLINEMSGClick);
            // 
            // MENU_MANAGE_CASTLE
            // 
            this.MENU_MANAGE_CASTLE.Index = 1;
            this.MENU_MANAGE_CASTLE.Text = "城堡管理(&C)";
            this.MENU_MANAGE_CASTLE.Click += new System.EventHandler(this.MENU_MANAGE_CASTLEClick);
            // 
            // G2
            // 
            this.G2.Index = 2;
            this.G2.Text = "行会管理 (&G)";
            this.G2.Click += new System.EventHandler(this.G2Click);
            // 
            // MENU_MANAGE_SYS
            // 
            this.MENU_MANAGE_SYS.Index = 3;
            this.MENU_MANAGE_SYS.Text = "系统管理(&S)";
            this.MENU_MANAGE_SYS.Click += new System.EventHandler(this.MENU_MANAGE_SYS_Click);
            // 
            // MENU_TOOLS
            // 
            this.MENU_TOOLS.Index = 4;
            this.MENU_TOOLS.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_TOOLS_MERCHANT,
            this.MENU_TOOLS_NPC,
            this.MENU_TOOLS_MONGEN,
            this.MENU_TOOLS_IPSEARCH});
            this.MENU_TOOLS.Text = "工具(&T)";
            // 
            // MENU_TOOLS_MERCHANT
            // 
            this.MENU_TOOLS_MERCHANT.Index = 0;
            this.MENU_TOOLS_MERCHANT.Text = "交易NPC配置(&M)";
            this.MENU_TOOLS_MERCHANT.Click += new System.EventHandler(this.MENU_TOOLS_MERCHANTClick);
            // 
            // MENU_TOOLS_NPC
            // 
            this.MENU_TOOLS_NPC.Index = 1;
            this.MENU_TOOLS_NPC.Text = "管理NPC配置(&N)";
            this.MENU_TOOLS_NPC.Visible = false;
            // 
            // MENU_TOOLS_MONGEN
            // 
            this.MENU_TOOLS_MONGEN.Index = 2;
            this.MENU_TOOLS_MONGEN.Text = "刷怪配置(&G)";
            this.MENU_TOOLS_MONGEN.Click += new System.EventHandler(this.MENU_TOOLS_MONGENClick);
            // 
            // MENU_TOOLS_IPSEARCH
            // 
            this.MENU_TOOLS_IPSEARCH.Index = 3;
            this.MENU_TOOLS_IPSEARCH.Text = "地区查询(&S)";
            this.MENU_TOOLS_IPSEARCH.Click += new System.EventHandler(this.MENU_TOOLS_IPSEARCHClick);
            // 
            // MENU_HELP
            // 
            this.MENU_HELP.Index = 5;
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
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Panel1.Controls.Add(this.Label20);
            this.Panel1.Controls.Add(this.LbRunTime);
            this.Panel1.Controls.Add(this.LbUserCount);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.LbRunSocketTime);
            this.Panel1.Controls.Add(this.MemStatus);
            this.Panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(4, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(495, 324);
            this.Panel1.TabIndex = 2;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(3, 29);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(0, 12);
            this.Label20.TabIndex = 15;
            // 
            // LbRunTime
            // 
            this.LbRunTime.Location = new System.Drawing.Point(339, 31);
            this.LbRunTime.Name = "LbRunTime";
            this.LbRunTime.Size = new System.Drawing.Size(96, 12);
            this.LbRunTime.TabIndex = 8;
            this.LbRunTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LbUserCount
            // 
            this.LbUserCount.Location = new System.Drawing.Point(339, 5);
            this.LbUserCount.Name = "LbUserCount";
            this.LbUserCount.Size = new System.Drawing.Size(96, 12);
            this.LbUserCount.TabIndex = 9;
            this.LbUserCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(3, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(235, 12);
            this.Label1.TabIndex = 10;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(3, 18);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(235, 12);
            this.Label2.TabIndex = 11;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(3, 44);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(235, 12);
            this.Label5.TabIndex = 12;
            // 
            // LbRunSocketTime
            // 
            this.LbRunSocketTime.Location = new System.Drawing.Point(339, 18);
            this.LbRunSocketTime.Name = "LbRunSocketTime";
            this.LbRunSocketTime.Size = new System.Drawing.Size(96, 12);
            this.LbRunSocketTime.TabIndex = 13;
            this.LbRunSocketTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MemStatus
            // 
            this.MemStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemStatus.ForeColor = System.Drawing.Color.Blue;
            this.MemStatus.Location = new System.Drawing.Point(3, 312);
            this.MemStatus.Name = "MemStatus";
            this.MemStatus.Size = new System.Drawing.Size(489, 12);
            this.MemStatus.TabIndex = 14;
            this.MemStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GateListView
            // 
            this.GateListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.GateListView.AllowColumnReorder = true;
            this.GateListView.AutoArrange = false;
            this.GateListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.GateListView.FullRowSelect = true;
            this.GateListView.GridLines = true;
            this.GateListView.HideSelection = false;
            this.GateListView.Location = new System.Drawing.Point(1, 1);
            this.GateListView.MultiSelect = false;
            this.GateListView.Name = "GateListView";
            this.GateListView.Scrollable = false;
            this.GateListView.Size = new System.Drawing.Size(500, 322);
            this.GateListView.TabIndex = 4;
            this.GateListView.UseCompatibleStateImageBehavior = false;
            this.GateListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "网关";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "网关地址";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "队列数据";
            this.columnHeader3.Width = 66;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "发送数据";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "剩余数据";
            this.columnHeader5.Width = 72;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "平均流量";
            this.columnHeader6.Width = 72;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "最高人数";
            this.columnHeader7.Width = 76;
            // 
            // MemoLog
            // 
            this.MemoLog.AutoWordSelection = true;
            this.MemoLog.BackColor = System.Drawing.Color.Black;
            this.MemoLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MemoLog.DetectUrls = false;
            this.MemoLog.ForeColor = System.Drawing.Color.Lime;
            this.MemoLog.HideSelection = false;
            this.MemoLog.Location = new System.Drawing.Point(-2, 5);
            this.MemoLog.Name = "MemoLog";
            this.MemoLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.MemoLog.Size = new System.Drawing.Size(506, 329);
            this.MemoLog.TabIndex = 5;
            this.MemoLog.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(4, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(510, 344);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MemoLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日志信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ErrorMemoLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(502, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "错误信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ErrorMemoLog
            // 
            this.ErrorMemoLog.AutoWordSelection = true;
            this.ErrorMemoLog.BackColor = System.Drawing.Color.Black;
            this.ErrorMemoLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorMemoLog.DetectUrls = false;
            this.ErrorMemoLog.ForeColor = System.Drawing.Color.Lime;
            this.ErrorMemoLog.HideSelection = false;
            this.ErrorMemoLog.Location = new System.Drawing.Point(-2, 5);
            this.ErrorMemoLog.Name = "ErrorMemoLog";
            this.ErrorMemoLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ErrorMemoLog.Size = new System.Drawing.Size(506, 329);
            this.ErrorMemoLog.TabIndex = 6;
            this.ErrorMemoLog.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(502, 318);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "异常信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.AutoWordSelection = true;
            this.richTextBox2.BackColor = System.Drawing.Color.Black;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.DetectUrls = false;
            this.richTextBox2.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox2.HideSelection = false;
            this.richTextBox2.Location = new System.Drawing.Point(-2, 5);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox2.Size = new System.Drawing.Size(506, 329);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.GateListView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(502, 318);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "网关信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.Panel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(502, 318);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "系统信息";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(502, 318);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "状态信息";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // TFrmMain
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(518, 345);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(292, 174);
            this.MaximizeBox = false;
            this.Menu = this.MainMenu;
            this.Name = "TFrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCreate);
            this.Panel.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.ListView GateListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.RichTextBox MemoLog;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.MenuItem MENU_MANAGE_SYS;
        private System.Windows.Forms.Label Label20;
        private System.Windows.Forms.Label LbRunTime;
        private System.Windows.Forms.Label LbUserCount;
        private System.Windows.Forms.Label LbRunSocketTime;
        private System.Windows.Forms.Label MemStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox ErrorMemoLog;
        private System.Windows.Forms.RichTextBox richTextBox2;

    }
}
