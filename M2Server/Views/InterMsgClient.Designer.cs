namespace M2Server
{
  partial class TFrmMsgClient
    {
        //public TClientSocket MsgClient;
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
            //this.MsgClient = new TClientSocket();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(702, 499);
            this.ClientSize  = new System.Drawing.Size(170, 96);
            this.Font  = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(1)));
            this.AutoScroll = true;
            this.Name = "FrmMsgClient";
            this.Text = "FrmMsgClient";
            //this.BackColor = clBtnFace;
            this.ResumeLayout(false);
        }
#endregion

    }
}
