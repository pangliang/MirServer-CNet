namespace M2Server
{
  partial class TFrmIDSoc
    {
        //public TClientSocket IDSocket;
      private System.Windows.Forms.Timer Timer1;
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
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Interval = 30000;
            // 
            // TFrmIDSoc
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(187, 122);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Location = new System.Drawing.Point(837, 334);
            this.Name = "TFrmIDSoc";
            this.Text = "FrmIDSoc";
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
