namespace M2Server
{
  partial class TfrmMonsterConfig
    {
        private System.Windows.Forms.TabControl PageControl1;
        private System.Windows.Forms.TabPage TabSheet1;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox GroupBox8;
        private System.Windows.Forms.Label Label23;
        private System.Windows.Forms.NumericUpDown EditMonOneDropGoldCount;
        private System.Windows.Forms.CheckBox CheckBoxDropGoldToPlayBag;
        private System.Windows.Forms.Button ButtonGeneralSave;
        private System.Windows.Forms.TabPage TabSheet2;
        private System.Windows.Forms.TabControl PageControl2;
        private System.ComponentModel.Container components = null;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(this.GetType());
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PageControl1 = new System.Windows.Forms.TabControl();
            this.TabSheet1 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.EditMonOneDropGoldCount = new System.Windows.Forms.NumericUpDown();
            this.CheckBoxDropGoldToPlayBag = new System.Windows.Forms.CheckBox();
            this.ButtonGeneralSave = new System.Windows.Forms.Button();
            this.TabSheet2 = new System.Windows.Forms.TabPage();
            this.PageControl2 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(656, 275);
            this.ClientSize  = new System.Drawing.Size(616, 320);
            this.Font  = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(134)));
            //this.Closed += new System.EventHandler(this.FormClose);
            this.Name = "frmMonsterConfig";
            this.Text = "怪物设置";
          //  this.Load += new System.EventHandler(this.FormCreate);
            this.AutoScroll = true;
           // this.BackColor = clBtnFace;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.PageControl1.Size  = new System.Drawing.Size(616, 320);
            this.PageControl1.Location  = new System.Drawing.Point(0, 0);
            this.PageControl1.SuspendLayout();
            this.PageControl1.SelectedTab = TabSheet1;
            this.PageControl1.TabIndex = 0;
            this.PageControl1.Enabled = true;
            this.PageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageControl1.Name = "PageControl1";
            this.TabSheet1.Size  = new System.Drawing.Size(0, 0);
            this.TabSheet1.Location  = new System.Drawing.Point(0, 0);
            this.TabSheet1.SuspendLayout();
            this.TabSheet1.Text = "基本参数";
            this.TabSheet1.Enabled = true;
            this.TabSheet1.Name = "TabSheet1";
            this.GroupBox1.Size  = new System.Drawing.Size(577, 257);
            this.GroupBox1.Location  = new System.Drawing.Point(8, 8);
            this.GroupBox1.SuspendLayout();
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.Enabled = true;
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox8.Size  = new System.Drawing.Size(153, 73);
            this.GroupBox8.Location  = new System.Drawing.Point(8, 16);
            this.GroupBox8.SuspendLayout();
            this.GroupBox8.Text = "爆物品设置";
            this.GroupBox8.TabIndex = 0;
            this.GroupBox8.Enabled = true;
            this.GroupBox8.Name = "GroupBox8";
            this.Label23.Size  = new System.Drawing.Size(42, 12);
            this.Label23.Location  = new System.Drawing.Point(11, 24);
            this.Label23.Text = "金币堆:";
            this.Label23.Enabled = true;
            this.Label23.Name = "Label23";
            ((System.ComponentModel.ISupportInitialize)(this.EditMonOneDropGoldCount)).BeginInit();
            this.EditMonOneDropGoldCount.Size  = new System.Drawing.Size(77, 21);
            this.EditMonOneDropGoldCount.Location  = new System.Drawing.Point(60, 20);
            this.EditMonOneDropGoldCount.Value = 10;
            this.EditMonOneDropGoldCount.TabIndex = 0;
            this.EditMonOneDropGoldCount.Name = "EditMonOneDropGoldCount";
            this.EditMonOneDropGoldCount.Enabled = true;
            this.CheckBoxDropGoldToPlayBag.Size  = new System.Drawing.Size(137, 17);
            this.CheckBoxDropGoldToPlayBag.Location  = new System.Drawing.Point(8, 48);
            this.CheckBoxDropGoldToPlayBag.Text = "金币直接入背包";
            this.CheckBoxDropGoldToPlayBag.TabIndex = 1;
            this.CheckBoxDropGoldToPlayBag.Enabled = true;
           // this.CheckBoxDropGoldToPlayBag.Click += new System.EventHandler(this.CheckBoxDropGoldToPlayBagClick);
            this.CheckBoxDropGoldToPlayBag.Name = "CheckBoxDropGoldToPlayBag";
            this.ButtonGeneralSave.Size  = new System.Drawing.Size(65, 25);
            this.ButtonGeneralSave.Location  = new System.Drawing.Point(504, 221);
           // this.ButtonGeneralSave.Click += new System.EventHandler(this.ButtonGeneralSaveClick);
            this.ButtonGeneralSave.TabIndex = 1;
            this.ButtonGeneralSave.Name = "ButtonGeneralSave";
            this.ButtonGeneralSave.Enabled = true;
            this.ButtonGeneralSave.Text = "保存(&S)";
           // this.ButtonGeneralSave.BackColor = clBtnFace;
            this.TabSheet2.Size  = new System.Drawing.Size(0, 0);
            this.TabSheet2.Location  = new System.Drawing.Point(0, 0);
            this.TabSheet2.SuspendLayout();
            this.TabSheet2.Text = "怪物类型";
            this.TabSheet2.ImageIndex = 1;
            this.TabSheet2.Enabled = true;
            this.TabSheet2.Name = "TabSheet2";
            this.PageControl2.Size  = new System.Drawing.Size(608, 256);
            this.PageControl2.Location  = new System.Drawing.Point(0, 0);
            this.PageControl2.TabIndex = 0;
            this.PageControl2.Multiline = true;
            this.PageControl2.Enabled = true;
            this.PageControl2.Name = "PageControl2";
            this.GroupBox8.Controls.Add(Label23);
            this.GroupBox8.Controls.Add(EditMonOneDropGoldCount);
            this.GroupBox8.Controls.Add(CheckBoxDropGoldToPlayBag);
            ((System.ComponentModel.ISupportInitialize)(this.EditMonOneDropGoldCount)).EndInit();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox1.Controls.Add(GroupBox8);
            this.GroupBox1.Controls.Add(ButtonGeneralSave);
            this.GroupBox1.ResumeLayout(false);
            this.TabSheet1.Controls.Add(GroupBox1);
            this.TabSheet1.ResumeLayout(false);
            this.TabSheet2.Controls.Add(PageControl2);
            this.TabSheet2.ResumeLayout(false);
            this.PageControl1.Controls.Add(TabSheet1);
            this.PageControl1.Controls.Add(TabSheet2);
            this.PageControl1.ResumeLayout(false);
            this.Controls.Add(PageControl1);
            this.ResumeLayout(false);
        }
#endregion

    }
}
