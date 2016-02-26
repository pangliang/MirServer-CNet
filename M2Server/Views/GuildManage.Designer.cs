namespace M2Server
{
  partial class TfrmGuildManage
    {
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ListView ListViewGuild;
        private System.Windows.Forms.ColumnHeader _column_353;
        private System.Windows.Forms.ColumnHeader _column_354;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.TabControl PageControl1;
        private System.Windows.Forms.TabPage TabSheet1;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TextBox EditGuildName;
        private System.Windows.Forms.NumericUpDown EditBuildPoint;
        private System.Windows.Forms.NumericUpDown EditAurae;
        private System.Windows.Forms.NumericUpDown EditStability;
        private System.Windows.Forms.NumericUpDown EditFlourishing;
        private System.Windows.Forms.NumericUpDown EditChiefItemCount;
        private System.Windows.Forms.NumericUpDown EditGuildFountain;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.NumericUpDown SpinEditGuildMemberCount;
        private System.Windows.Forms.GroupBox GroupBox4;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.NumericUpDown EditGuildMemberCount;
        private System.Windows.Forms.Button Button2;
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
            this.EditGuildMemberCount = new System.Windows.Forms.NumericUpDown();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ListViewGuild = new System.Windows.Forms.ListView();
            this._column_353 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_354 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.PageControl1 = new System.Windows.Forms.TabControl();
            this.TabSheet1 = new System.Windows.Forms.TabPage();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.EditGuildName = new System.Windows.Forms.TextBox();
            this.EditBuildPoint = new System.Windows.Forms.NumericUpDown();
            this.EditAurae = new System.Windows.Forms.NumericUpDown();
            this.EditStability = new System.Windows.Forms.NumericUpDown();
            this.EditFlourishing = new System.Windows.Forms.NumericUpDown();
            this.EditChiefItemCount = new System.Windows.Forms.NumericUpDown();
            this.EditGuildFountain = new System.Windows.Forms.NumericUpDown();
            this.Button1 = new System.Windows.Forms.Button();
            this.SpinEditGuildMemberCount = new System.Windows.Forms.NumericUpDown();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EditGuildMemberCount)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.PageControl1.SuspendLayout();
            this.TabSheet1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditBuildPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditAurae)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditStability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditFlourishing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditChiefItemCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditGuildFountain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditGuildMemberCount)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditGuildMemberCount
            // 
            this.EditGuildMemberCount.Location = new System.Drawing.Point(125, 12);
            this.EditGuildMemberCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.EditGuildMemberCount.Name = "EditGuildMemberCount";
            this.EditGuildMemberCount.Size = new System.Drawing.Size(60, 21);
            this.EditGuildMemberCount.TabIndex = 0;
            this.toolTip1.SetToolTip(this.EditGuildMemberCount, "新建行会，最大的成员数量，建议在200-300之间");
            this.EditGuildMemberCount.Click += new System.EventHandler(this.EditGuildMemberCountClick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ListViewGuild);
            this.GroupBox1.Location = new System.Drawing.Point(3, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(191, 304);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "行会列表";
            // 
            // ListViewGuild
            // 
            this.ListViewGuild.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._column_353,
            this._column_354});
            this.ListViewGuild.FullRowSelect = true;
            this.ListViewGuild.GridLines = true;
            this.ListViewGuild.Location = new System.Drawing.Point(6, 16);
            this.ListViewGuild.Name = "ListViewGuild";
            this.ListViewGuild.Size = new System.Drawing.Size(177, 281);
            this.ListViewGuild.TabIndex = 0;
            this.ListViewGuild.UseCompatibleStateImageBehavior = false;
            this.ListViewGuild.View = System.Windows.Forms.View.Details;
            this.ListViewGuild.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListViewGuild_ItemSelectionChanged);
            this.ListViewGuild.Click += new System.EventHandler(this.ListViewGuildClick);
            // 
            // _column_353
            // 
            this._column_353.Name = "_column_353";
            this._column_353.Text = "序号";
            this._column_353.Width = 38;
            // 
            // _column_354
            // 
            this._column_354.Name = "_column_354";
            this._column_354.Text = "行会名称";
            this._column_354.Width = 135;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.PageControl1);
            this.GroupBox2.Location = new System.Drawing.Point(198, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(289, 261);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "行会信息";
            // 
            // PageControl1
            // 
            this.PageControl1.Controls.Add(this.TabSheet1);
            this.PageControl1.Location = new System.Drawing.Point(8, 14);
            this.PageControl1.Name = "PageControl1";
            this.PageControl1.SelectedIndex = 0;
            this.PageControl1.Size = new System.Drawing.Size(275, 241);
            this.PageControl1.TabIndex = 0;
            // 
            // TabSheet1
            // 
            this.TabSheet1.Controls.Add(this.GroupBox3);
            this.TabSheet1.Location = new System.Drawing.Point(4, 22);
            this.TabSheet1.Name = "TabSheet1";
            this.TabSheet1.Size = new System.Drawing.Size(267, 215);
            this.TabSheet1.TabIndex = 0;
            this.TabSheet1.Text = "基本情况";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.Label9);
            this.GroupBox3.Controls.Add(this.EditGuildName);
            this.GroupBox3.Controls.Add(this.EditBuildPoint);
            this.GroupBox3.Controls.Add(this.EditAurae);
            this.GroupBox3.Controls.Add(this.EditStability);
            this.GroupBox3.Controls.Add(this.EditFlourishing);
            this.GroupBox3.Controls.Add(this.EditChiefItemCount);
            this.GroupBox3.Controls.Add(this.EditGuildFountain);
            this.GroupBox3.Controls.Add(this.Button1);
            this.GroupBox3.Controls.Add(this.SpinEditGuildMemberCount);
            this.GroupBox3.Location = new System.Drawing.Point(4, 0);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(260, 210);
            this.GroupBox3.TabIndex = 0;
            this.GroupBox3.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 12);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "行会名称:";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(54, 12);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "建 筑 度:";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(8, 68);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(54, 12);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "人 气 度:";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(8, 92);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(54, 12);
            this.Label7.TabIndex = 3;
            this.Label7.Text = "安 定 度:";
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(8, 116);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(54, 12);
            this.Label8.TabIndex = 4;
            this.Label8.Text = "繁 荣 度:";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(8, 140);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(54, 12);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "装 备 数:";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(8, 164);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(54, 12);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "行会泉水:";
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(8, 188);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(54, 12);
            this.Label9.TabIndex = 7;
            this.Label9.Text = "成员上限:";
            // 
            // EditGuildName
            // 
            this.EditGuildName.Enabled = false;
            this.EditGuildName.Location = new System.Drawing.Point(64, 16);
            this.EditGuildName.Name = "EditGuildName";
            this.EditGuildName.ReadOnly = true;
            this.EditGuildName.Size = new System.Drawing.Size(169, 21);
            this.EditGuildName.TabIndex = 0;
            // 
            // EditBuildPoint
            // 
            this.EditBuildPoint.Location = new System.Drawing.Point(64, 40);
            this.EditBuildPoint.Name = "EditBuildPoint";
            this.EditBuildPoint.Size = new System.Drawing.Size(81, 21);
            this.EditBuildPoint.TabIndex = 1;
            this.EditBuildPoint.Click += new System.EventHandler(this.EditBuildPointClick);
            // 
            // EditAurae
            // 
            this.EditAurae.Location = new System.Drawing.Point(64, 64);
            this.EditAurae.Name = "EditAurae";
            this.EditAurae.Size = new System.Drawing.Size(81, 21);
            this.EditAurae.TabIndex = 2;
            this.EditAurae.Click += new System.EventHandler(this.EditBuildPointClick);
            // 
            // EditStability
            // 
            this.EditStability.Location = new System.Drawing.Point(64, 88);
            this.EditStability.Name = "EditStability";
            this.EditStability.Size = new System.Drawing.Size(81, 21);
            this.EditStability.TabIndex = 3;
            this.EditStability.Click += new System.EventHandler(this.EditBuildPointClick);
            // 
            // EditFlourishing
            // 
            this.EditFlourishing.Location = new System.Drawing.Point(64, 112);
            this.EditFlourishing.Name = "EditFlourishing";
            this.EditFlourishing.Size = new System.Drawing.Size(81, 21);
            this.EditFlourishing.TabIndex = 4;
            this.EditFlourishing.Click += new System.EventHandler(this.EditBuildPointClick);
            // 
            // EditChiefItemCount
            // 
            this.EditChiefItemCount.Location = new System.Drawing.Point(64, 136);
            this.EditChiefItemCount.Name = "EditChiefItemCount";
            this.EditChiefItemCount.Size = new System.Drawing.Size(81, 21);
            this.EditChiefItemCount.TabIndex = 5;
            this.EditChiefItemCount.Click += new System.EventHandler(this.EditBuildPointClick);
            // 
            // EditGuildFountain
            // 
            this.EditGuildFountain.Location = new System.Drawing.Point(64, 160);
            this.EditGuildFountain.Name = "EditGuildFountain";
            this.EditGuildFountain.Size = new System.Drawing.Size(81, 21);
            this.EditGuildFountain.TabIndex = 6;
            this.EditGuildFountain.Click += new System.EventHandler(this.EditBuildPointClick);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button1.Enabled = false;
            this.Button1.Location = new System.Drawing.Point(168, 160);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 25);
            this.Button1.TabIndex = 7;
            this.Button1.Text = "保存(&S)";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // SpinEditGuildMemberCount
            // 
            this.SpinEditGuildMemberCount.Location = new System.Drawing.Point(64, 184);
            this.SpinEditGuildMemberCount.Name = "SpinEditGuildMemberCount";
            this.SpinEditGuildMemberCount.Size = new System.Drawing.Size(81, 21);
            this.SpinEditGuildMemberCount.TabIndex = 8;
            this.SpinEditGuildMemberCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpinEditGuildMemberCount.Click += new System.EventHandler(this.EditBuildPointClick);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Label6);
            this.GroupBox4.Controls.Add(this.EditGuildMemberCount);
            this.GroupBox4.Controls.Add(this.Button2);
            this.GroupBox4.Location = new System.Drawing.Point(200, 267);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(287, 41);
            this.GroupBox4.TabIndex = 2;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "行会设置";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(18, 18);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(102, 12);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "新建行会成员上限:";
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button2.Enabled = false;
            this.Button2.Location = new System.Drawing.Point(200, 10);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 25);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "保存";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // TfrmGuildManage
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(492, 312);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox4);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(364, 247);
            this.Name = "TfrmGuildManage";
            this.Text = "行会管理";
            ((System.ComponentModel.ISupportInitialize)(this.EditGuildMemberCount)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.PageControl1.ResumeLayout(false);
            this.TabSheet1.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditBuildPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditAurae)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditStability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditFlourishing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditChiefItemCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditGuildFountain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditGuildMemberCount)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
