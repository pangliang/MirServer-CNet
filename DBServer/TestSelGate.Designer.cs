namespace DBServer
{
    partial class TfrmTestSelGate
    {
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox EditSelGate;
        public System.Windows.Forms.TextBox EditGameGate;
        public System.Windows.Forms.Button ButtonTest;
        public System.Windows.Forms.Button Button1;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.EditSelGate = new System.Windows.Forms.TextBox();
            this.EditGameGate = new System.Windows.Forms.TextBox();
            this.ButtonTest = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Location = new System.Drawing.Point(918, 256);
            this.ClientSize = new System.Drawing.Size(209, 120);
            this.Font = new System.Drawing.Font("ÀŒÃÂ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTestSelGate";
            this.Text = "≤‚ ‘—°‘ÒÕ¯πÿ";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupBox1.Size = new System.Drawing.Size(193, 105);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.SuspendLayout();
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.Enabled = true;
            this.GroupBox1.Name = "GroupBox1";
            this.Label1.Size = new System.Drawing.Size(54, 12);
            this.Label1.Location = new System.Drawing.Point(8, 20);
            this.Label1.Text = "Ω«…´Õ¯πÿ:";
            this.Label1.Enabled = true;
            this.Label1.Name = "Label1";
            this.Label2.Size = new System.Drawing.Size(54, 12);
            this.Label2.Location = new System.Drawing.Point(8, 44);
            this.Label2.Text = "”Œœ∑Õ¯πÿ:";
            this.Label2.Enabled = true;
            this.Label2.Name = "Label2";
            this.EditSelGate.Size = new System.Drawing.Size(113, 20);
            this.EditSelGate.Location = new System.Drawing.Point(64, 16);
            this.EditSelGate.TabIndex = 0;
            this.EditSelGate.Text = "127.0.0.1";
            this.EditSelGate.Enabled = true;
            this.EditSelGate.Name = "EditSelGate";
            this.EditGameGate.Size = new System.Drawing.Size(113, 20);
            this.EditGameGate.Location = new System.Drawing.Point(64, 40);
            this.EditGameGate.TabIndex = 1;
            this.EditGameGate.Enabled = true;
            this.EditGameGate.Name = "EditGameGate";
            this.ButtonTest.Size = new System.Drawing.Size(65, 25);
            this.ButtonTest.Location = new System.Drawing.Point(16, 72);
            this.ButtonTest.Text = "≤‚ ‘(&T)";
            this.ButtonTest.Click += new System.EventHandler(this.ButtonTestClick);
            this.ButtonTest.TabIndex = 2;
            this.ButtonTest.Name = "ButtonTest";
            this.ButtonTest.Enabled = true;
            this.ButtonTest.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button1.Size = new System.Drawing.Size(65, 25);
            this.Button1.Location = new System.Drawing.Point(112, 72);
            this.Button1.Text = "≈‰÷√(&C)";
            this.Button1.Click += new System.EventHandler(this.Button1Click);
            this.Button1.TabIndex = 3;
            this.Button1.Name = "Button1";
            this.Button1.Enabled = true;
            this.Button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupBox1.Controls.Add(Label1);
            this.GroupBox1.Controls.Add(Label2);
            this.GroupBox1.Controls.Add(EditSelGate);
            this.GroupBox1.Controls.Add(EditGameGate);
            this.GroupBox1.Controls.Add(ButtonTest);
            this.GroupBox1.Controls.Add(Button1);
            this.GroupBox1.ResumeLayout(false);
            this.Controls.Add(GroupBox1);
            this.ResumeLayout(false);
        }
        #endregion

    }
}
