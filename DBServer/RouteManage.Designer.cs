namespace RouteManage
{
    partial class TfrmRouteManage
    {
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.ListView ListViewRoute;
        public System.Windows.Forms.ColumnHeader _column_155;
        public System.Windows.Forms.ColumnHeader _column_156;
        public System.Windows.Forms.ColumnHeader _column_157;
        public System.Windows.Forms.ColumnHeader _column_158;
        public System.Windows.Forms.Button ButtonEdit;
        public System.Windows.Forms.Button ButtonDelete;
        public System.Windows.Forms.Button ButtonOK;
        public System.Windows.Forms.Button ButtonAddRoute;
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
            this.ListViewRoute = new System.Windows.Forms.ListView();
            this._column_155 = new System.Windows.Forms.ColumnHeader();
            this._column_156 = new System.Windows.Forms.ColumnHeader();
            this._column_157 = new System.Windows.Forms.ColumnHeader();
            this._column_158 = new System.Windows.Forms.ColumnHeader();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonAddRoute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Location = new System.Drawing.Point(971, 177);
            this.ClientSize = new System.Drawing.Size(481, 223);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRouteManage";
            this.Text = "网关路由配置";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.GroupBox1.Size = new System.Drawing.Size(465, 209);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.SuspendLayout();
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.Text = "网关路由表";
            this.GroupBox1.Enabled = true;
            this.GroupBox1.Name = "GroupBox1";
            this.ListViewRoute.Size = new System.Drawing.Size(449, 153);
            this.ListViewRoute.Location = new System.Drawing.Point(8, 16);
            this.ListViewRoute.View = System.Windows.Forms.View.Details;
            this.ListViewRoute.Enabled = true;
            this.ListViewRoute.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.ListViewRoute.TabIndex = 0;
            this.ListViewRoute.FullRowSelect = true;
            this.ListViewRoute.GridLines = true;
            this.ListViewRoute.Name = "ListViewRoute";
            this._column_155.Text = "序号";
            this._column_155.Name = "_column_155";
            this._column_156.Text = "角色网关";
            this._column_156.Name = "_column_156";
            this._column_157.Text = "网关数量";
            this._column_157.Name = "_column_157";
            this._column_158.Text = "游戏网关";
            this._column_158.Name = "_column_158";
            this.ListViewRoute.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { 
                        _column_155,
                        _column_156,
                        _column_157,
                        _column_158
                        });
            this.ButtonEdit.Size = new System.Drawing.Size(73, 25);
            this.ButtonEdit.Location = new System.Drawing.Point(88, 176);
            this.ButtonEdit.Text = "编辑(&E)";
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.ButtonEdit.TabIndex = 1;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Enabled = true;
            this.ButtonEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolTip1.SetToolTip(this.ButtonEdit, "修改选定的网关路由");
            this.ButtonDelete.Size = new System.Drawing.Size(73, 25);
            this.ButtonDelete.Location = new System.Drawing.Point(168, 176);
            this.ButtonDelete.Text = "删除(&D)";
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.ButtonDelete.TabIndex = 2;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Enabled = true;
            this.ButtonDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolTip1.SetToolTip(this.ButtonDelete, "删除选定的网关路由");
            this.ButtonOK.Size = new System.Drawing.Size(73, 25);
            this.ButtonOK.Location = new System.Drawing.Point(384, 176);
            this.ButtonOK.Text = "确定(&O)";
            this.ButtonOK.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Enabled = true;
            this.ButtonOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolTip1.SetToolTip(this.ButtonOK, "保存网关路由设置退出");
            this.ButtonAddRoute.Size = new System.Drawing.Size(73, 25);
            this.ButtonAddRoute.Location = new System.Drawing.Point(8, 176);
            this.ButtonAddRoute.Text = "增加(&A)";
            this.ButtonAddRoute.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.ButtonAddRoute.TabIndex = 4;
            this.ButtonAddRoute.Name = "ButtonAddRoute";
            this.ButtonAddRoute.Enabled = true;
            this.ButtonAddRoute.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolTip1.SetToolTip(this.ButtonAddRoute, "修改选定的网关路由");
            this.GroupBox1.Controls.Add(ListViewRoute);
            this.GroupBox1.Controls.Add(ButtonEdit);
            this.GroupBox1.Controls.Add(ButtonDelete);
            this.GroupBox1.Controls.Add(ButtonOK);
            this.GroupBox1.Controls.Add(ButtonAddRoute);
            this.GroupBox1.ResumeLayout(false);
            this.Controls.Add(GroupBox1);
            this.ResumeLayout(false);
        }
        #endregion

    }
}
