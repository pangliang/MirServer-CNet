namespace M2Server
{
  partial class TfrmOnlineMsg
    {
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox ComboBoxMsg;
        private System.Windows.Forms.TextBox MemoMsg;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonSend;
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
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboBoxMsg = new System.Windows.Forms.ComboBox();
            this.MemoMsg = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.dgvNoticeList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoticeList)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(4, 169);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(76, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "在线信息:";
            // 
            // ComboBoxMsg
            // 
            this.ComboBoxMsg.ItemHeight = 12;
            this.ComboBoxMsg.Location = new System.Drawing.Point(63, 165);
            this.ComboBoxMsg.Name = "ComboBoxMsg";
            this.ComboBoxMsg.Size = new System.Drawing.Size(374, 20);
            this.ComboBoxMsg.TabIndex = 0;
            this.ComboBoxMsg.TextChanged += new System.EventHandler(this.ComboBoxMsg_TextChanged);
            this.ComboBoxMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBoxMsg_KeyPress);
            // 
            // MemoMsg
            // 
            this.MemoMsg.BackColor = System.Drawing.Color.White;
            this.MemoMsg.Location = new System.Drawing.Point(3, 4);
            this.MemoMsg.Multiline = true;
            this.MemoMsg.Name = "MemoMsg";
            this.MemoMsg.ReadOnly = true;
            this.MemoMsg.Size = new System.Drawing.Size(434, 153);
            this.MemoMsg.TabIndex = 1;
            this.MemoMsg.Text = "MemoMsg";
            this.MemoMsg.TextChanged += new System.EventHandler(this.MemoMsg_TextChanged);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Enabled = false;
            this.ButtonAdd.Location = new System.Drawing.Point(367, 191);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(67, 23);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.Text = "增加(&A)";
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Enabled = false;
            this.ButtonDelete.Location = new System.Drawing.Point(293, 191);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(67, 23);
            this.ButtonDelete.TabIndex = 4;
            this.ButtonDelete.Text = "删除(&D)";
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(148, 190);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(67, 23);
            this.ButtonSend.TabIndex = 5;
            this.ButtonSend.Text = "发送(&S)";
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // dgvNoticeList
            // 
            this.dgvNoticeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoticeList.Location = new System.Drawing.Point(3, 219);
            this.dgvNoticeList.Name = "dgvNoticeList";
            this.dgvNoticeList.RowTemplate.Height = 23;
            this.dgvNoticeList.Size = new System.Drawing.Size(434, 107);
            this.dgvNoticeList.TabIndex = 6;
            this.dgvNoticeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNoticeList_CellClick);
            this.dgvNoticeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNoticeList_CellDoubleClick);
            // 
            // TfrmOnlineMsg
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(440, 332);
            this.Controls.Add(this.ComboBoxMsg);
            this.Controls.Add(this.dgvNoticeList);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.MemoMsg);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonSend);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(367, 319);
            this.MaximizeBox = false;
            this.Name = "TfrmOnlineMsg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "在线发送消息";
            this.Load += new System.EventHandler(this.TfrmOnlineMsg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoticeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridView dgvNoticeList;

    }
}
