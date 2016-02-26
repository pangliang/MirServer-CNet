//namespace DBServer
//{
//    partial class TFrmFDBViewer
//    {

//        public System.Windows.Forms.TabControl TabbedNotebook1;
//        public System.Windows.Forms.TabPage Unnamed_0;
//        public System.Windows.Forms.DataGridView HumanGrid;
//        public System.Windows.Forms.TabPage Unnamed_1;
//        public System.Windows.Forms.DataGridView UserItemGrid;
//        public System.Windows.Forms.TabPage Unnamed_2;
//        public System.Windows.Forms.DataGridView BagItemGrid;
//        public System.Windows.Forms.TabPage Unnamed_3;
//        public System.Windows.Forms.DataGridView SaveItemGrid;
//        public System.Windows.Forms.TabPage Unnamed_4;
//        public System.Windows.Forms.DataGridView UseMagicGrid;
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
//            this.TabbedNotebook1 = new System.Windows.Forms.TabControl();
//            this.Unnamed_0 = new System.Windows.Forms.TabPage();
//            this.HumanGrid = new System.Windows.Forms.DataGridView();
//            this.Unnamed_1 = new System.Windows.Forms.TabPage();
//            this.UserItemGrid = new System.Windows.Forms.DataGridView();
//            this.Unnamed_2 = new System.Windows.Forms.TabPage();
//            this.BagItemGrid = new System.Windows.Forms.DataGridView();
//            this.Unnamed_3 = new System.Windows.Forms.TabPage();
//            this.SaveItemGrid = new System.Windows.Forms.DataGridView();
//            this.Unnamed_4 = new System.Windows.Forms.TabPage();
//            this.UseMagicGrid = new System.Windows.Forms.DataGridView();
//            this.TabbedNotebook1.SuspendLayout();
//            this.Unnamed_0.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.HumanGrid)).BeginInit();
//            this.Unnamed_1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.UserItemGrid)).BeginInit();
//            this.Unnamed_2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.BagItemGrid)).BeginInit();
//            this.Unnamed_3.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.SaveItemGrid)).BeginInit();
//            this.Unnamed_4.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.UseMagicGrid)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // TabbedNotebook1
//            // 
//            this.TabbedNotebook1.Controls.Add(this.Unnamed_0);
//            this.TabbedNotebook1.Controls.Add(this.Unnamed_1);
//            this.TabbedNotebook1.Controls.Add(this.Unnamed_2);
//            this.TabbedNotebook1.Controls.Add(this.Unnamed_3);
//            this.TabbedNotebook1.Controls.Add(this.Unnamed_4);
//            this.TabbedNotebook1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.TabbedNotebook1.Location = new System.Drawing.Point(0, 0);
//            this.TabbedNotebook1.Name = "TabbedNotebook1";
//            this.TabbedNotebook1.SelectedIndex = 0;
//            this.TabbedNotebook1.Size = new System.Drawing.Size(913, 231);
//            this.TabbedNotebook1.TabIndex = 0;
//            // 
//            // Unnamed_0
//            // 
//            this.Unnamed_0.Controls.Add(this.HumanGrid);
//            this.Unnamed_0.Location = new System.Drawing.Point(4, 22);
//            this.Unnamed_0.Name = "Unnamed_0";
//            this.Unnamed_0.Size = new System.Drawing.Size(905, 205);
//            this.Unnamed_0.TabIndex = 0;
//            this.Unnamed_0.Text = "人物信息";
//            // 
//            // HumanGrid
//            // 
//            this.HumanGrid.DataMember = "";
//            this.HumanGrid.Dock = System.Windows.Forms.DockStyle.Fill;
//            //this.HumanGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
//            this.HumanGrid.Location = new System.Drawing.Point(0, 0);
//            this.HumanGrid.Name = "HumanGrid";
//            this.HumanGrid.Size = new System.Drawing.Size(905, 205);
//            this.HumanGrid.TabIndex = 0;
//            // 
//            // Unnamed_1
//            // 
//            this.Unnamed_1.Controls.Add(this.UserItemGrid);
//            this.Unnamed_1.Location = new System.Drawing.Point(4, 22);
//            this.Unnamed_1.Name = "Unnamed_1";
//            this.Unnamed_1.Size = new System.Drawing.Size(905, 205);
//            this.Unnamed_1.TabIndex = 1;
//            this.Unnamed_1.Text = "身上装备";
//            // 
//            // UserItemGrid
//            // 
//            this.UserItemGrid.DataMember = "";
//            this.UserItemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
//            //this.UserItemGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
//            this.UserItemGrid.Location = new System.Drawing.Point(0, 0);
//            this.UserItemGrid.Name = "UserItemGrid";
//            this.UserItemGrid.Size = new System.Drawing.Size(905, 205);
//            this.UserItemGrid.TabIndex = 0;
//            // 
//            // Unnamed_2
//            // 
//            this.Unnamed_2.Controls.Add(this.BagItemGrid);
//            this.Unnamed_2.Location = new System.Drawing.Point(4, 22);
//            this.Unnamed_2.Name = "Unnamed_2";
//            this.Unnamed_2.Size = new System.Drawing.Size(905, 205);
//            this.Unnamed_2.TabIndex = 2;
//            this.Unnamed_2.Text = "背包物品";
//            // 
//            // BagItemGrid
//            // 
//            this.BagItemGrid.DataMember = "";
//            this.BagItemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
//            //this.BagItemGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
//            this.BagItemGrid.Location = new System.Drawing.Point(0, 0);
//            this.BagItemGrid.Name = "BagItemGrid";
//            this.BagItemGrid.Size = new System.Drawing.Size(905, 205);
//            this.BagItemGrid.TabIndex = 0;
//            // 
//            // Unnamed_3
//            // 
//            this.Unnamed_3.Controls.Add(this.SaveItemGrid);
//            this.Unnamed_3.Location = new System.Drawing.Point(4, 22);
//            this.Unnamed_3.Name = "Unnamed_3";
//            this.Unnamed_3.Size = new System.Drawing.Size(905, 205);
//            this.Unnamed_3.TabIndex = 3;
//            this.Unnamed_3.Text = "仓库物品";
//            // 
//            // SaveItemGrid
//            // 
//            this.SaveItemGrid.DataMember = "";
//            this.SaveItemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
//            //this.SaveItemGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
//            this.SaveItemGrid.Location = new System.Drawing.Point(0, 0);
//            this.SaveItemGrid.Name = "SaveItemGrid";
//            this.SaveItemGrid.Size = new System.Drawing.Size(905, 205);
//            this.SaveItemGrid.TabIndex = 0;
//            // 
//            // Unnamed_4
//            // 
//            this.Unnamed_4.Controls.Add(this.UseMagicGrid);
//            this.Unnamed_4.Location = new System.Drawing.Point(4, 22);
//            this.Unnamed_4.Name = "Unnamed_4";
//            this.Unnamed_4.Size = new System.Drawing.Size(905, 205);
//            this.Unnamed_4.TabIndex = 4;
//            this.Unnamed_4.Text = "人物技能";
//            // 
//            // UseMagicGrid
//            // 
//            this.UseMagicGrid.DataMember = "";
//            this.UseMagicGrid.Dock = System.Windows.Forms.DockStyle.Fill;
//            //this.UseMagicGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
//            this.UseMagicGrid.Location = new System.Drawing.Point(0, 0);
//            this.UseMagicGrid.Name = "UseMagicGrid";
//            this.UseMagicGrid.Size = new System.Drawing.Size(905, 205);
//            this.UseMagicGrid.TabIndex = 0;
//            // 
//            // TFrmFDBViewer
//            // 
//            this.AutoScroll = true;
//            this.BackColor = System.Drawing.SystemColors.ButtonFace;
//            this.ClientSize = new System.Drawing.Size(913, 231);
//            this.Controls.Add(this.TabbedNotebook1);
//            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Location = new System.Drawing.Point(1116, 543);
//            this.Name = "TFrmFDBViewer";
//            this.Text = "查看人物数据";
//            this.Load += new System.EventHandler(this.FormCreate);
//            this.TabbedNotebook1.ResumeLayout(false);
//            this.Unnamed_0.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.HumanGrid)).EndInit();
//            this.Unnamed_1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.UserItemGrid)).EndInit();
//            this.Unnamed_2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.BagItemGrid)).EndInit();
//            this.Unnamed_3.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.SaveItemGrid)).EndInit();
//            this.Unnamed_4.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.UseMagicGrid)).EndInit();
//            this.ResumeLayout(false);

//        }
//        #endregion

//        private System.ComponentModel.IContainer components;

//    }
//}
