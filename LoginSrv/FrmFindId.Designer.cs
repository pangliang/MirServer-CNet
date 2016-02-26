namespace LoginSrv
{
  partial class TFrmFindUserId
    {
        public System.Windows.Forms.DataGrid IdGrid;
        public System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox EdFindId;
        public System.Windows.Forms.Button BtnFindAll;
        public System.Windows.Forms.Button Button1;
        public System.Windows.Forms.Button BtnEdit;
        public System.Windows.Forms.Button Button2;
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
            this.IdGrid = new System.Windows.Forms.DataGrid();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.EdFindId = new System.Windows.Forms.TextBox();
            this.BtnFindAll = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(267, 308);
            this.ClientSize  = new System.Drawing.Size(756, 255);
            this.Font  = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(0)));
            this.Load += new System.EventHandler(this.FormCreate);
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFindUserId";
            this.Text = "登录帐号管理";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            ((System.ComponentModel.ISupportInitialize)(this.IdGrid)).BeginInit();
            this.IdGrid.Size  = new System.Drawing.Size(756, 217);
            this.IdGrid.Location  = new System.Drawing.Point(0, 0);
            this.IdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IdGrid.DoubleClick += new System.EventHandler(this.BtnEditClick);
            this.IdGrid.Name = "IdGrid";
            this.IdGrid.Enabled = true;
//            this.IdGrid.PreferredColumnWidth = (int){64, 64, 71, 91, 89, 150, 141, 169, 170, 83, 90, 72, 76, 182, 159, 218};
            this.IdGrid.TabIndex = 0;
            this.Panel1.Size  = new System.Drawing.Size(756, 38);
            this.Panel1.Location  = new System.Drawing.Point(0, 217);
            this.Panel1.SuspendLayout();
            this.Panel1.TabIndex = 1;
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Name = "Panel1";
            this.Panel1.Enabled = true;
            this.Panel1.Text = " ";
            this.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Label1.Size  = new System.Drawing.Size(30, 12);
            this.Label1.Location  = new System.Drawing.Point(16, 12);
            this.Label1.Text = "帐号:";
            this.Label1.Enabled = true;
            this.Label1.Name = "Label1";
            this.EdFindId.Size  = new System.Drawing.Size(121, 20);
            this.EdFindId.Location  = new System.Drawing.Point(56, 8);
            this.EdFindId.TabIndex = 0;
            this.EdFindId.Enabled = true;
            this.EdFindId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EdFindIdKeyPress);
            this.EdFindId.Name = "EdFindId";
            this.BtnFindAll.Size  = new System.Drawing.Size(57, 21);
            this.BtnFindAll.Location  = new System.Drawing.Point(192, 8);
            this.BtnFindAll.Click += new System.EventHandler(this.BtnFindAllClick);
            this.BtnFindAll.TabIndex = 1;
            this.BtnFindAll.Name = "BtnFindAll";
            this.BtnFindAll.Enabled = true;
            this.BtnFindAll.Text = "搜索(&S)";
            this.BtnFindAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button1.Size  = new System.Drawing.Size(141, 21);
            this.Button1.Location  = new System.Drawing.Point(576, 10);
            this.Button1.Click += new System.EventHandler(this.Button1Click);
            this.Button1.TabIndex = 2;
            this.Button1.Name = "Button1";
            this.Button1.Enabled = true;
            this.Button1.Text = "重新服务器表";
            this.Button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEdit.Size  = new System.Drawing.Size(75, 21);
            this.BtnEdit.Location  = new System.Drawing.Point(288, 8);
            this.BtnEdit.Click += new System.EventHandler(this.BtnEditClick);
            this.BtnEdit.TabIndex = 3;
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Enabled = true;
            this.BtnEdit.Text = "编辑(&E)";
            this.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button2.Size  = new System.Drawing.Size(75, 21);
            this.Button2.Location  = new System.Drawing.Point(376, 8);
            this.Button2.Click += new System.EventHandler(this.Button2Click);
            this.Button2.TabIndex = 4;
            this.Button2.Name = "Button2";
            this.Button2.Enabled = true;
            this.Button2.Text = "新建(&N)";
            this.Button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Panel1.Controls.Add(Label1);
            this.Panel1.Controls.Add(EdFindId);
            this.Panel1.Controls.Add(BtnFindAll);
            this.Panel1.Controls.Add(Button1);
            this.Panel1.Controls.Add(BtnEdit);
            this.Panel1.Controls.Add(Button2);
            this.Panel1.ResumeLayout(false);
            this.Controls.Add(IdGrid);
            this.Controls.Add(Panel1);
            ((System.ComponentModel.ISupportInitialize)(this.IdGrid)).EndInit();
            this.ResumeLayout(false);
        }
#endregion

    }
}
