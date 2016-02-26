namespace LoginSrv
{
  partial class TFrmMasSoc
    {
        //        public TServerSocket MSocket;
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
            this.SuspendLayout();
            // 
            // TFrmMasSoc
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(259, 193);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Location = new System.Drawing.Point(741, 352);
            this.Name = "TFrmMasSoc";
            this.Text = "FrmMasSoc";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TFrmMasSoc_FormClosed);
            this.Load += new System.EventHandler(this.FormCreate);
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;

    }
}
