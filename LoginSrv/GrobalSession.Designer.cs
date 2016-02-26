namespace LoginSrv
{
  partial class TfrmGrobalSession
    {
        public System.Windows.Forms.Button ButtonRefGrid;
        public System.Windows.Forms.Panel PanelStatus;
        public System.Windows.Forms.DataGrid GridSession;
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
            this.ButtonRefGrid = new System.Windows.Forms.Button();
            this.PanelStatus = new System.Windows.Forms.Panel();
            this.GridSession = new System.Windows.Forms.DataGrid();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(1032, 424);
            this.ClientSize  = new System.Drawing.Size(405, 208);
            this.Font  = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(1)));
            this.Load += new System.EventHandler(this.FormCreate);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGrobalSession";
            this.Text = "查看全局会话";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonRefGrid.Size  = new System.Drawing.Size(73, 25);
            this.ButtonRefGrid.Location  = new System.Drawing.Point(320, 176);
            this.ButtonRefGrid.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonRefGrid.Text = "刷新(&R)";
            this.ButtonRefGrid.TabIndex = 0;
            this.ButtonRefGrid.Enabled = true;
            this.ButtonRefGrid.Name = "ButtonRefGrid";
            this.PanelStatus.Size  = new System.Drawing.Size(393, 161);
            this.PanelStatus.Location  = new System.Drawing.Point(4, 8);
            this.PanelStatus.SuspendLayout();
            this.PanelStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PanelStatus.TabIndex = 1;
            this.PanelStatus.Enabled = true;
            this.PanelStatus.Name = "PanelStatus";
            ((System.ComponentModel.ISupportInitialize)(this.GridSession)).BeginInit();
            this.GridSession.Size  = new System.Drawing.Size(393, 161);
            this.GridSession.Location  = new System.Drawing.Point(0, 0);
            this.GridSession.Name = "GridSession";
            this.GridSession.Enabled = true;
//            this.GridSession.PreferredColumnWidth = (int){34, 83, 86, 56, 44, 58};
            this.GridSession.TabIndex = 0;
            this.PanelStatus.Controls.Add(GridSession);
            ((System.ComponentModel.ISupportInitialize)(this.GridSession)).EndInit();
            this.PanelStatus.ResumeLayout(false);
            this.Controls.Add(ButtonRefGrid);
            this.Controls.Add(PanelStatus);
            this.ResumeLayout(false);
        }
#endregion

    }
}
