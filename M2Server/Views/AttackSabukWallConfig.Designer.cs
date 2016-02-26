namespace M2Server
{
  partial class TFrmAttackSabukWall
    {
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ListBox ListBoxGuild;
        private System.Windows.Forms.TextBox EditGuildName;
        //public TRzDateTimeEdit RzDateTimeEditAttackDate;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.CheckBox CheckBoxAll;
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ListBoxGuild = new System.Windows.Forms.ListBox();
            this.EditGuildName = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.CheckBoxAll = new System.Windows.Forms.CheckBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 308);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "行会名称：";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 332);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 12);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "攻城时间：";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ListBoxGuild);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(281, 289);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "行会列表";
            // 
            // ListBoxGuild
            // 
            this.ListBoxGuild.ItemHeight = 12;
            this.ListBoxGuild.Location = new System.Drawing.Point(8, 16);
            this.ListBoxGuild.Name = "ListBoxGuild";
            this.ListBoxGuild.Size = new System.Drawing.Size(265, 256);
            this.ListBoxGuild.TabIndex = 0;
            // 
            // EditGuildName
            // 
            this.EditGuildName.Location = new System.Drawing.Point(64, 304);
            this.EditGuildName.Name = "EditGuildName";
            this.EditGuildName.Size = new System.Drawing.Size(137, 21);
            this.EditGuildName.TabIndex = 1;
            this.EditGuildName.Text = "EditGuildName";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(208, 328);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 25);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "确定(&O)";
            // 
            // CheckBoxAll
            // 
            this.CheckBoxAll.Location = new System.Drawing.Point(216, 304);
            this.CheckBoxAll.Name = "CheckBoxAll";
            this.CheckBoxAll.Size = new System.Drawing.Size(73, 17);
            this.CheckBoxAll.TabIndex = 4;
            this.CheckBoxAll.Text = "所有行会";
            // 
            // TFrmAttackSabukWall
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(295, 360);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.EditGuildName);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.CheckBoxAll);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(513, 235);
            this.MaximizeBox = false;
            this.Name = "TFrmAttackSabukWall";
            this.Text = "FrmAttackSabukWall";
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
