//namespace DBServer
//{
//    partial class TFrmIDHum
//    {
//        public System.Windows.Forms.Label Label3;
//        public System.Windows.Forms.Label Label4;
//        public System.Windows.Forms.Label Label5;
//        public System.Windows.Forms.Button BtnCreateChr;
//        public System.Windows.Forms.Button BtnEraseChr;
//        public System.Windows.Forms.Button BtnChrNameSearch;
//        public System.Windows.Forms.Button BtnSelAll;
//        public System.Windows.Forms.Button BtnDeleteChr;
//        public System.Windows.Forms.Button BtnRevival;
//        public System.Windows.Forms.Button SpeedButton1;
//        public System.Windows.Forms.Label Label2;
//        public System.Windows.Forms.Button BtnDeleteChrAllInfo;
//        public System.Windows.Forms.Button BtnChrIndex;
//        public System.Windows.Forms.Label LabelCount;
//        public System.Windows.Forms.Button BtnEditData;
//        public System.Windows.Forms.TextBox EdChrName;
//        public System.Windows.Forms.DataGridView IdGrid;
//        public System.Windows.Forms.DataGridView ChrGrid;
//        public System.Windows.Forms.CheckBox CbShowDelChr;
//        public System.Windows.Forms.TextBox EdUserId;
//        private System.Windows.Forms.ToolTip toolTip1 = null;

//        // Clean up any resources being used.
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                if (components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
//            this.Label3 = new System.Windows.Forms.Label();
//            this.Label4 = new System.Windows.Forms.Label();
//            this.Label5 = new System.Windows.Forms.Label();
//            this.BtnCreateChr = new System.Windows.Forms.Button();
//            this.BtnEraseChr = new System.Windows.Forms.Button();
//            this.BtnChrNameSearch = new System.Windows.Forms.Button();
//            this.BtnSelAll = new System.Windows.Forms.Button();
//            this.BtnDeleteChr = new System.Windows.Forms.Button();
//            this.BtnRevival = new System.Windows.Forms.Button();
//            this.SpeedButton1 = new System.Windows.Forms.Button();
//            this.Label2 = new System.Windows.Forms.Label();
//            this.BtnDeleteChrAllInfo = new System.Windows.Forms.Button();
//            this.BtnChrIndex = new System.Windows.Forms.Button();
//            this.LabelCount = new System.Windows.Forms.Label();
//            this.BtnEditData = new System.Windows.Forms.Button();
//            this.EdChrName = new System.Windows.Forms.TextBox();
//            this.IdGrid = new System.Windows.Forms.DataGridView();
//            this.ChrGrid = new System.Windows.Forms.DataGridView();
//            this.CbShowDelChr = new System.Windows.Forms.CheckBox();
//            this.EdUserId = new System.Windows.Forms.TextBox();
//            ((System.ComponentModel.ISupportInitialize)(this.IdGrid)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.ChrGrid)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // Label3
//            // 
//            this.Label3.Location = new System.Drawing.Point(216, 12);
//            this.Label3.Name = "Label3";
//            this.Label3.Size = new System.Drawing.Size(54, 12);
//            this.Label3.TabIndex = 0;
//            this.Label3.Text = "人物名称:";
//            // 
//            // Label4
//            // 
//            this.Label4.Location = new System.Drawing.Point(8, 40);
//            this.Label4.Name = "Label4";
//            this.Label4.Size = new System.Drawing.Size(70, 12);
//            this.Label4.TabIndex = 1;
//            this.Label4.Text = "帐号列表:";
//            this.Label4.Visible = false;
//            // 
//            // Label5
//            // 
//            this.Label5.Location = new System.Drawing.Point(8, 136);
//            this.Label5.Name = "Label5";
//            this.Label5.Size = new System.Drawing.Size(70, 12);
//            this.Label5.TabIndex = 2;
//            this.Label5.Text = "人物列表:";
//            // 
//            // BtnCreateChr
//            // 
//            this.BtnCreateChr.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnCreateChr.Location = new System.Drawing.Point(8, 328);
//            this.BtnCreateChr.Name = "BtnCreateChr";
//            this.BtnCreateChr.Size = new System.Drawing.Size(81, 25);
//            this.BtnCreateChr.TabIndex = 3;
//            this.BtnCreateChr.Text = "创建人物(&C)";
//            this.BtnCreateChr.UseVisualStyleBackColor = false;
//            this.BtnCreateChr.Click += new System.EventHandler(this.BtnCreateChrClick);
//            // 
//            // BtnEraseChr
//            // 
//            this.BtnEraseChr.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnEraseChr.Location = new System.Drawing.Point(96, 328);
//            this.BtnEraseChr.Name = "BtnEraseChr";
//            this.BtnEraseChr.Size = new System.Drawing.Size(81, 25);
//            this.BtnEraseChr.TabIndex = 4;
//            this.BtnEraseChr.Text = "删除人物(&D)";
//            this.BtnEraseChr.UseVisualStyleBackColor = false;
//            this.BtnEraseChr.Click += new System.EventHandler(this.BtnEraseChrClick);
//            // 
//            // BtnChrNameSearch
//            // 
//            this.BtnChrNameSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnChrNameSearch.Location = new System.Drawing.Point(400, 8);
//            this.BtnChrNameSearch.Name = "BtnChrNameSearch";
//            this.BtnChrNameSearch.Size = new System.Drawing.Size(57, 25);
//            this.BtnChrNameSearch.TabIndex = 5;
//            this.BtnChrNameSearch.Text = "查找(&F)";
//            this.BtnChrNameSearch.UseVisualStyleBackColor = false;
//            this.BtnChrNameSearch.Click += new System.EventHandler(this.BtnChrNameSearchClick);
//            // 
//            // BtnSelAll
//            // 
//            this.BtnSelAll.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnSelAll.Location = new System.Drawing.Point(464, 8);
//            this.BtnSelAll.Name = "BtnSelAll";
//            this.BtnSelAll.Size = new System.Drawing.Size(81, 25);
//            this.BtnSelAll.TabIndex = 6;
//            this.BtnSelAll.Text = "模糊查找(S)";
//            this.BtnSelAll.UseVisualStyleBackColor = false;
//            this.BtnSelAll.Click += new System.EventHandler(this.BtnSelAllClick);
//            // 
//            // BtnDeleteChr
//            // 
//            this.BtnDeleteChr.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnDeleteChr.Location = new System.Drawing.Point(184, 328);
//            this.BtnDeleteChr.Name = "BtnDeleteChr";
//            this.BtnDeleteChr.Size = new System.Drawing.Size(81, 25);
//            this.BtnDeleteChr.TabIndex = 7;
//            this.BtnDeleteChr.Text = "禁用人物(&D)";
//            this.BtnDeleteChr.UseVisualStyleBackColor = false;
//            this.BtnDeleteChr.Click += new System.EventHandler(this.BtnDeleteChrClick);
//            // 
//            // BtnRevival
//            // 
//            this.BtnRevival.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnRevival.Location = new System.Drawing.Point(272, 328);
//            this.BtnRevival.Name = "BtnRevival";
//            this.BtnRevival.Size = new System.Drawing.Size(81, 25);
//            this.BtnRevival.TabIndex = 8;
//            this.BtnRevival.Text = "启用人物(&U)";
//            this.BtnRevival.UseVisualStyleBackColor = false;
//            this.BtnRevival.Click += new System.EventHandler(this.BtnRevivalClick);
//            // 
//            // SpeedButton1
//            // 
//            this.SpeedButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.SpeedButton1.Location = new System.Drawing.Point(8, 360);
//            this.SpeedButton1.Name = "SpeedButton1";
//            this.SpeedButton1.Size = new System.Drawing.Size(281, 25);
//            this.SpeedButton1.TabIndex = 9;
//            this.SpeedButton1.Text = "人物数据管理(&M)";
//            this.SpeedButton1.UseVisualStyleBackColor = false;
//            this.SpeedButton1.Click += new System.EventHandler(this.SpeedButton1Click);
//            // 
//            // Label2
//            // 
//            this.Label2.Location = new System.Drawing.Point(8, 12);
//            this.Label2.Name = "Label2";
//            this.Label2.Size = new System.Drawing.Size(54, 12);
//            this.Label2.TabIndex = 10;
//            this.Label2.Text = "登录帐号:";
//            // 
//            // BtnDeleteChrAllInfo
//            // 
//            this.BtnDeleteChrAllInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnDeleteChrAllInfo.Location = new System.Drawing.Point(296, 360);
//            this.BtnDeleteChrAllInfo.Name = "BtnDeleteChrAllInfo";
//            this.BtnDeleteChrAllInfo.Size = new System.Drawing.Size(281, 25);
//            this.BtnDeleteChrAllInfo.TabIndex = 11;
//            this.BtnDeleteChrAllInfo.Text = "删除人物及数据(&R)";
//            this.BtnDeleteChrAllInfo.UseVisualStyleBackColor = false;
//            this.BtnDeleteChrAllInfo.Click += new System.EventHandler(this.BtnDeleteChrAllInfoClick);
//            // 
//            // BtnChrIndex
//            // 
//            this.BtnChrIndex.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnChrIndex.Location = new System.Drawing.Point(360, 328);
//            this.BtnChrIndex.Name = "BtnChrIndex";
//            this.BtnChrIndex.Size = new System.Drawing.Size(97, 25);
//            this.BtnChrIndex.TabIndex = 12;
//            this.BtnChrIndex.Text = "禁用索引号(N)";
//            this.BtnChrIndex.UseVisualStyleBackColor = false;
//            this.BtnChrIndex.Click += new System.EventHandler(this.BtnChrIndexClick);
//            // 
//            // LabelCount
//            // 
//            this.LabelCount.Location = new System.Drawing.Point(72, 136);
//            this.LabelCount.Name = "LabelCount";
//            this.LabelCount.Size = new System.Drawing.Size(6, 12);
//            this.LabelCount.TabIndex = 13;
//            // 
//            // BtnEditData
//            // 
//            this.BtnEditData.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.BtnEditData.Location = new System.Drawing.Point(464, 328);
//            this.BtnEditData.Name = "BtnEditData";
//            this.BtnEditData.Size = new System.Drawing.Size(97, 25);
//            this.BtnEditData.TabIndex = 14;
//            this.BtnEditData.Text = "编辑数据(&E)";
//            this.BtnEditData.UseVisualStyleBackColor = false;
//            this.BtnEditData.Click += new System.EventHandler(this.BtnEditDataClick);
//            // 
//            // EdChrName
//            // 
//            this.EdChrName.Location = new System.Drawing.Point(280, 8);
//            this.EdChrName.Name = "EdChrName";
//            this.EdChrName.Size = new System.Drawing.Size(113, 21);
//            this.EdChrName.TabIndex = 0;
//            this.EdChrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EdChrNameKeyPress);
//            // 
//            // IdGrid
//            // 
//            this.IdGrid.Location = new System.Drawing.Point(8, 56);
//            this.IdGrid.Name = "IdGrid";
//            this.IdGrid.RowTemplate.Height = 23;
//            this.IdGrid.Size = new System.Drawing.Size(609, 73);
//            this.IdGrid.TabIndex = 1;
//            this.IdGrid.Visible = false;
//            // 
//            // ChrGrid
//            // 
//            this.ChrGrid.Location = new System.Drawing.Point(8, 152);
//            this.ChrGrid.Name = "ChrGrid";
//            this.ChrGrid.Size = new System.Drawing.Size(609, 169);
//            this.ChrGrid.TabIndex = 2;
//            this.ChrGrid.Click += new System.EventHandler(this.ChrGridClick);
//            this.ChrGrid.DoubleClick += new System.EventHandler(this.ChrGridDblClick);
//            // 
//            // CbShowDelChr
//            // 
//            this.CbShowDelChr.Checked = true;
//            this.CbShowDelChr.CheckState = System.Windows.Forms.CheckState.Checked;
//            this.CbShowDelChr.Location = new System.Drawing.Point(283, 35);
//            this.CbShowDelChr.Name = "CbShowDelChr";
//            this.CbShowDelChr.Size = new System.Drawing.Size(110, 17);
//            this.CbShowDelChr.TabIndex = 3;
//            this.CbShowDelChr.Text = "显示已禁用人物";
//            // 
//            // EdUserId
//            // 
//            this.EdUserId.Location = new System.Drawing.Point(68, 8);
//            this.EdUserId.Name = "EdUserId";
//            this.EdUserId.Size = new System.Drawing.Size(133, 21);
//            this.EdUserId.TabIndex = 4;
//            this.EdUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EdUserId_KeyPress);
//            // 
//            // TFrmIDHum
//            // 
//            this.AutoScroll = true;
//            this.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.ClientSize = new System.Drawing.Size(625, 391);
//            this.Controls.Add(this.Label3);
//            this.Controls.Add(this.Label4);
//            this.Controls.Add(this.Label5);
//            this.Controls.Add(this.BtnCreateChr);
//            this.Controls.Add(this.BtnEraseChr);
//            this.Controls.Add(this.BtnChrNameSearch);
//            this.Controls.Add(this.BtnSelAll);
//            this.Controls.Add(this.BtnDeleteChr);
//            this.Controls.Add(this.BtnRevival);
//            this.Controls.Add(this.SpeedButton1);
//            this.Controls.Add(this.Label2);
//            this.Controls.Add(this.BtnDeleteChrAllInfo);
//            this.Controls.Add(this.BtnChrIndex);
//            this.Controls.Add(this.LabelCount);
//            this.Controls.Add(this.BtnEditData);
//            this.Controls.Add(this.EdChrName);
//            this.Controls.Add(this.IdGrid);
//            this.Controls.Add(this.ChrGrid);
//            this.Controls.Add(this.CbShowDelChr);
//            this.Controls.Add(this.EdUserId);
//            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Location = new System.Drawing.Point(807, 370);
//            this.Name = "TFrmIDHum";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "人物管理";
//            this.Load += new System.EventHandler(this.TFrmIDHum_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.IdGrid)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.ChrGrid)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }
//        #endregion

//        private System.ComponentModel.IContainer components;

//    }
//}
