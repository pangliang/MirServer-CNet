namespace M2Server
{
  partial class TfrmViewLevel
    {
        private System.Windows.Forms.GroupBox GroupBox10;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.NumericUpDown EditHumanLevel;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox ComboBoxJob;
        private System.Windows.Forms.Button ButtonClose;
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
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.EditHumanLevel = new System.Windows.Forms.NumericUpDown();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboBoxJob = new System.Windows.Forms.ComboBox();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.GridHumanInfo = new System.Windows.Forms.ListView();
            this.GroupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditHumanLevel)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox10
            // 
            this.GroupBox10.Controls.Add(this.Label4);
            this.GroupBox10.Controls.Add(this.EditHumanLevel);
            this.GroupBox10.Location = new System.Drawing.Point(8, 8);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new System.Drawing.Size(121, 49);
            this.GroupBox10.TabIndex = 0;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "人物等级";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(8, 20);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(30, 12);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "等级:";
            // 
            // EditHumanLevel
            // 
            this.EditHumanLevel.Location = new System.Drawing.Point(44, 15);
            this.EditHumanLevel.Name = "EditHumanLevel";
            this.EditHumanLevel.Size = new System.Drawing.Size(45, 21);
            this.EditHumanLevel.TabIndex = 0;
            this.EditHumanLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EditHumanLevel.ValueChanged += new System.EventHandler(this.EditHumanLevel_ValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.ComboBoxJob);
            this.GroupBox1.Location = new System.Drawing.Point(8, 64);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(121, 49);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "人物职业";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "职业:";
            // 
            // ComboBoxJob
            // 
            this.ComboBoxJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxJob.ItemHeight = 12;
            this.ComboBoxJob.Items.AddRange(new object[] {
            "武士",
            "魔法师",
            "道士"});
            this.ComboBoxJob.Location = new System.Drawing.Point(40, 16);
            this.ComboBoxJob.Name = "ComboBoxJob";
            this.ComboBoxJob.Size = new System.Drawing.Size(73, 20);
            this.ComboBoxJob.TabIndex = 0;
            this.ComboBoxJob.SelectedIndexChanged += new System.EventHandler(this.ComboBoxJobChange);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(32, 152);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(65, 25);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Text = "关闭(&C)";
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // GridHumanInfo
            // 
            this.GridHumanInfo.FullRowSelect = true;
            this.GridHumanInfo.GridLines = true;
            this.GridHumanInfo.HideSelection = false;
            this.GridHumanInfo.Location = new System.Drawing.Point(136, 8);
            this.GridHumanInfo.MultiSelect = false;
            this.GridHumanInfo.Name = "GridHumanInfo";
            this.GridHumanInfo.Size = new System.Drawing.Size(573, 257);
            this.GridHumanInfo.TabIndex = 4;
            this.GridHumanInfo.UseCompatibleStateImageBehavior = false;
            this.GridHumanInfo.View = System.Windows.Forms.View.Details;
            // 
            // TfrmViewLevel
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(732, 313);
            this.Controls.Add(this.GridHumanInfo);
            this.Controls.Add(this.GroupBox10);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.ButtonClose);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(770, 208);
            this.Name = "TfrmViewLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "人物等级属性";
            this.Load += new System.EventHandler(this.TfrmViewLevel_Load);
            this.GroupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditHumanLevel)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
#endregion

        private System.Windows.Forms.ListView GridHumanInfo;
        private System.ComponentModel.IContainer components;

    }
}
