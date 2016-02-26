using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using GameFramework;

namespace M2Server
{
    /// <summary>
    /// 在线发送消息
    /// </summary>
    public partial class TfrmOnlineMsg: Form
    {
        private TStringList StrList = null;
        private readonly string StrListFile = ".\\MsgList.txt";

        public TfrmOnlineMsg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TfrmOnlineMsg_Load(object sender, EventArgs e)
        {
            dgvNoticeList.RowHeadersVisible = false;
            dgvNoticeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNoticeList.MultiSelect = false;
            dgvNoticeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvNoticeList.AllowUserToResizeColumns = false;
            dgvNoticeList.AllowUserToResizeRows = false;
            dgvNoticeList.AllowUserToAddRows = false;
            dgvNoticeList.ReadOnly = true;
            dgvNoticeList.ColumnHeadersVisible = false;
            StrList = new TStringList();
            DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
            acCode.Name = "List";
            acCode.DataPropertyName = "List";
            acCode.HeaderText = "公告列表";
            acCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            acCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvNoticeList.Columns.Add(acCode);
            Refresh();
            MemoMsg.Clear();
        }

        /// <summary>
        /// 刷新表格
        /// </summary>
        private void Refresh()
        {
            dgvNoticeList.Rows.Clear();
            if (File.Exists(StrListFile))
            {
                StrList.LoadFromFile(StrListFile);
                for (int i = 0; i < StrList.Count; i++)
                {
                    dgvNoticeList.Rows.Add(StrList[i]);
                }
            }
            else
            {
                StrList.SaveToFile(StrListFile);
            }
        }

        /// <summary>
        /// 大于80行时清空消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemoMsg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (MemoMsg.Lines.Length > 80)
                {
                    MemoMsg.Clear();
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// 当敲回车时发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                switch ((int)e.KeyChar)
                {
                    case 13:
                        string Msg = ComboBoxMsg.Text;
                        if (Msg.Trim() != "")
                        {
                            if (ComboBoxMsg.Items.Count == 0)
                            {
                                ComboBoxMsg.Items.Add(Msg);
                            }
                            ComboBoxMsg.Items.Insert(1, Msg);
                            M2Share.UserEngine.SendBroadCastMsgExt(Msg, GameFramework.TMsgType.t_System);
                            MemoMsg.AppendText(M2Share.g_Config.sSysMsgPreFix + Msg+Environment.NewLine);
                        }
                        ComboBoxMsg.SelectedIndex = 0;
                        ComboBoxMsg.Text = "";
                        ButtonAdd.Enabled = false;
                        break;
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNoticeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    ButtonDelete.Enabled = true;
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// 双机事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNoticeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                ComboBoxMsg.Text = StrList[e.RowIndex];
                ComboBoxMsg.Focus();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNoticeList.Rows.Count == 0)
                {
                    ButtonDelete.Enabled = false;
                    return;
                }
                int n = dgvNoticeList.CurrentCell.RowIndex;
                StrList.RemoveAt(n);
                StrList.SaveToFile(StrListFile);
                Refresh();
                if (n > 0)
                {
                    dgvNoticeList.Rows[n - 1].Cells[0].Selected = true;
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            string Msg = ComboBoxMsg.Text;
            if (Msg.Trim() != "")
            {
                if (ComboBoxMsg.Items.Count == 0)
                {
                    ComboBoxMsg.Items.Add(Msg);
                }
                ComboBoxMsg.Items.Insert(0, Msg);
                M2Share.UserEngine.SendBroadCastMsgExt(Msg, GameFramework.TMsgType.t_System);
                MemoMsg.AppendText(M2Share.g_Config.sSysMsgPreFix + Msg + Environment.NewLine);
                ComboBoxMsg.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Msg = ComboBoxMsg.Text.Trim();
                if (Msg != "")
                {
                    StrList.Add(Msg);
                }
                StrList.SaveToFile(StrListFile);
                this.Refresh();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 文本变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxMsg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxMsg.Items.Count > 20)
                {
                    ComboBoxMsg.Items.RemoveAt(20);
                }
                if (ComboBoxMsg.Text.Trim() != "")
                {
                    ButtonAdd.Enabled = true;
                }
                else
                {
                    ButtonAdd.Enabled = false;
                }
            }
            finally
            {
            }
        }


    }
}