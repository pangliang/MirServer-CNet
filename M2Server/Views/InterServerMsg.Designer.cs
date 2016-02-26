namespace M2Server
{
  partial class TFrmSrvMsg
    {
        //public TServerSocket MsgServer;
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
            //this.MsgServer = new TServerSocket();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(636, 261);
            this.ClientSize  = new System.Drawing.Size(193, 120);
            this.Font  = new System.Drawing.Font("ËÎÌו", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(134)));
            this.AutoScroll = true;
            this.Name = "FrmSrvMsg";
            this.Text = "FrmSrvMsg";
            //this.BackColor = clBtnFace;
            this.ResumeLayout(false);
        }
#endregion

    }
}
