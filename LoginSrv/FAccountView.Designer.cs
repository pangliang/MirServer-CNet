namespace FAccountView
{
  partial class TFrmAccountView
    {
        public System.Windows.Forms.TextBox EdFindId;
        public System.Windows.Forms.TextBox EdFindIP;
        public System.Windows.Forms.ListBox ListBox1;
        public System.Windows.Forms.ListBox ListBox2;
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
            this.EdFindId = new System.Windows.Forms.TextBox();
            this.EdFindIP = new System.Windows.Forms.TextBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.ListBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // EdFindId
            // 
            this.EdFindId.Location = new System.Drawing.Point(8, 408);
            this.EdFindId.Name = "EdFindId";
            this.EdFindId.Size = new System.Drawing.Size(193, 21);
            this.EdFindId.TabIndex = 0;
            this.EdFindId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EdFindIdKeyPress);
            // 
            // EdFindIP
            // 
            this.EdFindIP.Location = new System.Drawing.Point(208, 408);
            this.EdFindIP.Name = "EdFindIP";
            this.EdFindIP.Size = new System.Drawing.Size(185, 21);
            this.EdFindIP.TabIndex = 1;
            this.EdFindIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EdFindIPKeyPress);
            // 
            // ListBox1
            // 
            this.ListBox1.ItemHeight = 12;
            this.ListBox1.Location = new System.Drawing.Point(8, 8);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(193, 388);
            this.ListBox1.TabIndex = 2;
            // 
            // ListBox2
            // 
            this.ListBox2.ItemHeight = 12;
            this.ListBox2.Location = new System.Drawing.Point(208, 8);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.Size = new System.Drawing.Size(193, 388);
            this.ListBox2.TabIndex = 3;
            // 
            // TFrmAccountView
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(402, 456);
            this.Controls.Add(this.ListBox2);
            this.Controls.Add(this.EdFindId);
            this.Controls.Add(this.EdFindIP);
            this.Controls.Add(this.ListBox1);
            this.Font = new System.Drawing.Font("ËÎÌå", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(538, 329);
            this.Name = "TFrmAccountView";
            this.Text = "³äÖµ¼ÇÂ¼";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
