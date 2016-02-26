namespace M2Server
{
  partial class TfrmViewSession
    {
        private System.Windows.Forms.Button ButtonRefGrid;
        private System.Windows.Forms.Panel PanelStatus;
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
            this.ButtonRefGrid = new System.Windows.Forms.Button();
            this.PanelStatus = new System.Windows.Forms.Panel();
            this.GridSession = new System.Windows.Forms.ListView();
            this.PanelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonRefGrid
            // 
            this.ButtonRefGrid.Location = new System.Drawing.Point(328, 144);
            this.ButtonRefGrid.Name = "ButtonRefGrid";
            this.ButtonRefGrid.Size = new System.Drawing.Size(73, 25);
            this.ButtonRefGrid.TabIndex = 0;
            this.ButtonRefGrid.Text = "刷新(&R)";
            this.ButtonRefGrid.Click += new System.EventHandler(this.ButtonRefGrid_Click);
            // 
            // PanelStatus
            // 
            this.PanelStatus.Controls.Add(this.GridSession);
            this.PanelStatus.Location = new System.Drawing.Point(8, 8);
            this.PanelStatus.Name = "PanelStatus";
            this.PanelStatus.Size = new System.Drawing.Size(393, 129);
            this.PanelStatus.TabIndex = 1;
            // 
            // GridSession
            // 
            this.GridSession.Location = new System.Drawing.Point(0, 0);
            this.GridSession.Name = "GridSession";
            this.GridSession.Size = new System.Drawing.Size(390, 126);
            this.GridSession.TabIndex = 2;
            this.GridSession.UseCompatibleStateImageBehavior = false;
            // 
            // TfrmViewSession
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(418, 209);
            this.Controls.Add(this.ButtonRefGrid);
            this.Controls.Add(this.PanelStatus);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(606, 529);
            this.Name = "TfrmViewSession";
            this.Text = "查看全局会话";
            this.Load += new System.EventHandler(this.TfrmViewSession_Load);
            this.PanelStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ListView GridSession;

    }
}
