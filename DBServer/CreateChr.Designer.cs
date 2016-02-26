namespace DBServer
{
  partial class TFrmCreateChr
    {
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.TextBox EdUserId;
        public System.Windows.Forms.TextBox EdChrName;
        public System.Windows.Forms.Button BitBtnOK;
        public System.Windows.Forms.Button BitBtnCancel;
        public System.Windows.Forms.TextBox EditSelectID;
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.EdUserId = new System.Windows.Forms.TextBox();
            this.EdChrName = new System.Windows.Forms.TextBox();
            this.BitBtnOK = new System.Windows.Forms.Button();
            this.BitBtnCancel = new System.Windows.Forms.Button();
            this.EditSelectID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(967, 489);
            this.ClientSize  = new System.Drawing.Size(250, 130);
            this.Font  = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(0)));
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCreateChr";
            this.Text = "创建新人物";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Label1.Size  = new System.Drawing.Size(54, 12);
            this.Label1.Location  = new System.Drawing.Point(18, 18);
            this.Label1.Text = "登录帐号:";
            this.Label1.Enabled = true;
            this.Label1.Name = "Label1";
            this.Label2.Size  = new System.Drawing.Size(54, 12);
            this.Label2.Location  = new System.Drawing.Point(18, 42);
            this.Label2.Text = "人物名称:";
            this.Label2.Enabled = true;
            this.Label2.Name = "Label2";
            this.Label3.Size  = new System.Drawing.Size(42, 12);
            this.Label3.Location  = new System.Drawing.Point(18, 66);
            this.Label3.Text = "选择ID:";
            this.Label3.Enabled = true;
            this.Label3.Name = "Label3";
            this.EdUserId.Size  = new System.Drawing.Size(149, 20);
            this.EdUserId.Location  = new System.Drawing.Point(80, 14);
            this.EdUserId.TabIndex = 0;
            this.EdUserId.Enabled = true;
            this.EdUserId.Name = "EdUserId";
            this.EdChrName.Size  = new System.Drawing.Size(149, 20);
            this.EdChrName.Location  = new System.Drawing.Point(80, 37);
            this.EdChrName.TabIndex = 1;
            this.EdChrName.Enabled = true;
            this.EdChrName.Name = "EdChrName";
            this.BitBtnOK.Size  = new System.Drawing.Size(93, 31);
            this.BitBtnOK.Location  = new System.Drawing.Point(23, 90);
            this.BitBtnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BitBtnOK.Text = "确定(&O)";
            this.BitBtnOK.TabIndex = 2;
            this.BitBtnOK.Enabled = true;
            this.BitBtnOK.Name = "BitBtnOK";
            this.BitBtnCancel.Size  = new System.Drawing.Size(92, 31);
            this.BitBtnCancel.Location  = new System.Drawing.Point(137, 90);
            this.BitBtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BitBtnCancel.Text = "取消(&C)";
            this.BitBtnCancel.TabIndex = 3;
            this.BitBtnCancel.Enabled = true;
            this.BitBtnCancel.Name = "BitBtnCancel";
            this.EditSelectID.Size  = new System.Drawing.Size(149, 20);
            this.EditSelectID.Location  = new System.Drawing.Point(80, 61);
            this.EditSelectID.TabIndex = 4;
            this.EditSelectID.Text = "0";
            this.EditSelectID.Enabled = true;
            this.EditSelectID.Name = "EditSelectID";
            this.Controls.Add(Label1);
            this.Controls.Add(Label2);
            this.Controls.Add(Label3);
            this.Controls.Add(EdUserId);
            this.Controls.Add(EdChrName);
            this.Controls.Add(BitBtnOK);
            this.Controls.Add(BitBtnCancel);
            this.Controls.Add(EditSelectID);
            this.ResumeLayout(false);
        }
#endregion

    }
}
