namespace M2Server
{
  partial class TfrmViewOnlineHuman
    {
      private System.Windows.Forms.Panel PanelStatus;
      private System.Windows.Forms.Panel Panel1;
      private System.Windows.Forms.Button ButtonRefGrid;
        private System.Windows.Forms.TextBox EditSearchName;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.Button ButtonView;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Timer Timer;
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
            this.PanelStatus = new System.Windows.Forms.Panel();
            this.GridHuman = new System.Windows.Forms.ListView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.EditSearchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonRefGrid = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonView = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.ButtonKick = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.PanelStatus.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelStatus
            // 
            this.PanelStatus.Controls.Add(this.GridHuman);
            this.PanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelStatus.Location = new System.Drawing.Point(0, 0);
            this.PanelStatus.Name = "PanelStatus";
            this.PanelStatus.Size = new System.Drawing.Size(826, 396);
            this.PanelStatus.TabIndex = 0;
            this.PanelStatus.Text = "正在读取数据...";
            // 
            // GridHuman
            // 
            this.GridHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridHuman.FullRowSelect = true;
            this.GridHuman.GridLines = true;
            this.GridHuman.HideSelection = false;
            this.GridHuman.Location = new System.Drawing.Point(0, 0);
            this.GridHuman.MultiSelect = false;
            this.GridHuman.Name = "GridHuman";
            this.GridHuman.Size = new System.Drawing.Size(826, 396);
            this.GridHuman.TabIndex = 1;
            this.GridHuman.UseCompatibleStateImageBehavior = false;
            this.GridHuman.View = System.Windows.Forms.View.Details;
            this.GridHuman.SelectedIndexChanged += new System.EventHandler(this.GridHuman_SelectedIndexChanged);
            this.GridHuman.DoubleClick += new System.EventHandler(this.GridHuman_DoubleClick);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.EditSearchName);
            this.Panel1.Controls.Add(this.label1);
            this.Panel1.Controls.Add(this.ButtonRefGrid);
            this.Panel1.Controls.Add(this.ButtonSearch);
            this.Panel1.Controls.Add(this.ButtonView);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Controls.Add(this.ButtonKick);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 396);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(826, 56);
            this.Panel1.TabIndex = 1;
            // 
            // EditSearchName
            // 
            this.EditSearchName.Location = new System.Drawing.Point(159, 20);
            this.EditSearchName.Name = "EditSearchName";
            this.EditSearchName.Size = new System.Drawing.Size(242, 21);
            this.EditSearchName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "角色名称：";
            // 
            // ButtonRefGrid
            // 
            this.ButtonRefGrid.Location = new System.Drawing.Point(8, 15);
            this.ButtonRefGrid.Name = "ButtonRefGrid";
            this.ButtonRefGrid.Size = new System.Drawing.Size(73, 25);
            this.ButtonRefGrid.TabIndex = 0;
            this.ButtonRefGrid.Text = "刷新(&R)";
            this.ButtonRefGrid.Click += new System.EventHandler(this.ButtonRefGrid_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(416, 15);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(73, 25);
            this.ButtonSearch.TabIndex = 3;
            this.ButtonSearch.Text = "搜索(&S)";
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // ButtonView
            // 
            this.ButtonView.Location = new System.Drawing.Point(576, 15);
            this.ButtonView.Name = "ButtonView";
            this.ButtonView.Size = new System.Drawing.Size(81, 25);
            this.ButtonView.TabIndex = 4;
            this.ButtonView.Text = "人物信息(&H)";
            this.ButtonView.Click += new System.EventHandler(this.ButtonView_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(663, 16);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(137, 25);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "踢除离线挂机人物(&K)";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ButtonKick
            // 
            this.ButtonKick.Location = new System.Drawing.Point(495, 15);
            this.ButtonKick.Name = "ButtonKick";
            this.ButtonKick.Size = new System.Drawing.Size(73, 25);
            this.ButtonKick.TabIndex = 6;
            this.ButtonKick.Text = "踢下线(&K)";
            this.ButtonKick.Click += new System.EventHandler(this.ButtonKick_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TfrmViewOnlineHuman
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(826, 452);
            this.Controls.Add(this.PanelStatus);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(235, 281);
            this.Name = "TfrmViewOnlineHuman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在线人物";
            this.Load += new System.EventHandler(this.TfrmViewOnlineHuman_Load);
            this.PanelStatus.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView GridHuman;
        private System.Windows.Forms.Button ButtonKick;

    }
}
