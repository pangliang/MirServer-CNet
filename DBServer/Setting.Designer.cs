namespace DBServer
{
    partial class TFrmSetting
    {
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.CheckBox CheckBoxAttack;
        public System.Windows.Forms.CheckBox CheckBoxDenyChrName;
        public System.Windows.Forms.CheckBox CheckBoxMinimize;
        public System.Windows.Forms.CheckBox CheckBoxDeleteChrName;
        public System.Windows.Forms.CheckBox CheckBoxRandomNumber;
        public System.Windows.Forms.CheckBox CheckBox1;
        public System.Windows.Forms.Button ButtonOK;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(this.GetType());
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBoxAttack = new System.Windows.Forms.CheckBox();
            this.CheckBoxDenyChrName = new System.Windows.Forms.CheckBox();
            this.CheckBoxMinimize = new System.Windows.Forms.CheckBox();
            this.CheckBoxDeleteChrName = new System.Windows.Forms.CheckBox();
            this.CheckBoxRandomNumber = new System.Windows.Forms.CheckBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Location = new System.Drawing.Point(539, 382);
            this.ClientSize = new System.Drawing.Size(322, 153);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Load += new System.EventHandler(this.FormCreate);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSetting";
            this.Text = "基本设置";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupBox1.Size = new System.Drawing.Size(305, 105);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.SuspendLayout();
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.Text = "基本设置";
            this.GroupBox1.Enabled = true;
            this.GroupBox1.Name = "GroupBox1";
            this.CheckBoxAttack.Size = new System.Drawing.Size(89, 17);
            this.CheckBoxAttack.Location = new System.Drawing.Point(168, 64);
            this.CheckBoxAttack.TabIndex = 0;
            this.CheckBoxAttack.Visible = false;
            this.CheckBoxAttack.Click += new System.EventHandler(this.CheckBoxAttackClick);
            this.CheckBoxAttack.Text = "防攻击保护";
            this.CheckBoxAttack.Name = "CheckBoxAttack";
            this.CheckBoxAttack.Enabled = false;
            this.CheckBoxDenyChrName.Size = new System.Drawing.Size(145, 17);
            this.CheckBoxDenyChrName.Location = new System.Drawing.Point(16, 40);
            this.CheckBoxDenyChrName.TabIndex = 1;
            this.CheckBoxDenyChrName.Text = "允许特殊字符创建人物";
            this.CheckBoxDenyChrName.Enabled = true;
            this.CheckBoxDenyChrName.Click += new System.EventHandler(this.CheckBoxDenyChrNameClick);
            this.CheckBoxDenyChrName.Name = "CheckBoxDenyChrName";
            this.CheckBoxMinimize.Size = new System.Drawing.Size(137, 17);
            this.CheckBoxMinimize.Location = new System.Drawing.Point(16, 64);
            this.CheckBoxMinimize.TabIndex = 2;
            this.CheckBoxMinimize.Text = "启动成功后最小化";
            this.CheckBoxMinimize.Enabled = true;
            this.CheckBoxMinimize.Click += new System.EventHandler(this.CheckBoxMinimizeClick);
            this.CheckBoxMinimize.Name = "CheckBoxMinimize";
            this.CheckBoxDeleteChrName.Size = new System.Drawing.Size(100, 17);
            this.CheckBoxDeleteChrName.Location = new System.Drawing.Point(165, 17);
            this.CheckBoxDeleteChrName.TabIndex = 3;
            this.CheckBoxDeleteChrName.Text = "允许删除人物";
            this.CheckBoxDeleteChrName.Enabled = true;
            this.CheckBoxDeleteChrName.Click += new System.EventHandler(this.CheckBoxDeleteChrNameClick);
            this.CheckBoxDeleteChrName.Name = "CheckBoxDeleteChrName";
            this.CheckBoxRandomNumber.Size = new System.Drawing.Size(108, 17);
            this.CheckBoxRandomNumber.Location = new System.Drawing.Point(165, 41);
            this.CheckBoxRandomNumber.TabIndex = 4;
            this.CheckBoxRandomNumber.Text = "开启验证码功能";
            this.CheckBoxRandomNumber.Enabled = true;
            this.CheckBoxRandomNumber.Click += new System.EventHandler(this.CheckBoxRandomNumberClick);
            this.CheckBoxRandomNumber.Name = "CheckBoxRandomNumber";
            this.CheckBox1.Size = new System.Drawing.Size(81, 17);
            this.CheckBox1.Location = new System.Drawing.Point(16, 16);
            this.CheckBox1.TabIndex = 5;
            this.CheckBox1.Visible = false;
            this.CheckBox1.Click += new System.EventHandler(this.CheckBoxDenyChrNameClick);
            this.CheckBox1.Text = "开启排行榜";
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Enabled = true;
            this.ButtonOK.Size = new System.Drawing.Size(75, 25);
            this.ButtonOK.Location = new System.Drawing.Point(240, 120);
            this.ButtonOK.Text = "确定(&O)";
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOKClick);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Enabled = true;
            this.ButtonOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupBox1.Controls.Add(CheckBoxAttack);
            this.GroupBox1.Controls.Add(CheckBoxDenyChrName);
            this.GroupBox1.Controls.Add(CheckBoxMinimize);
            this.GroupBox1.Controls.Add(CheckBoxDeleteChrName);
            this.GroupBox1.Controls.Add(CheckBoxRandomNumber);
            this.GroupBox1.Controls.Add(CheckBox1);
            this.GroupBox1.ResumeLayout(false);
            this.Controls.Add(GroupBox1);
            this.Controls.Add(ButtonOK);
            this.ResumeLayout(false);
        }
        #endregion

    }
}
