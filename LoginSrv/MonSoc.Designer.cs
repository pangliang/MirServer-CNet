namespace LoginSrv
{
  partial class TFrmMonSoc
    {
        //public TServerSocket MonSocket;
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
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(260, 103);
            this.ClientSize  = new System.Drawing.Size(210, 163);
            this.Font  = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(1)));
            this.Load += new System.EventHandler(this.FormCreate);
            this.AutoScroll = true;
            this.Name = "FrmMonSoc";
            this.Text = "FrmMonSoc";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ResumeLayout(false);
        }
#endregion

    }
}
