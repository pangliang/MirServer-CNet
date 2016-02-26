/*****************************************************
** 文 件 名：frmInputBox.cs
** Copyright (c) 2011-2013 JohnSoft
** 文件编号：
** 创 建 人：陶志强
** 日    期：2011年8月23日
** 修 改 人：
** 日    期：
** 描    述：
********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace M2Server
{
    /// <summary>
    /// 模块编号：
    /// 功能描述：输入信息框
    /// 创 建 人：陶志强
    /// 日    期：2011年8月23日
    /// Log 编号：
    /// 修改描述：
    /// 修 改 人：
    /// 日    期：
    /// </summary>
    public partial class frmInputBox : Form
    {
        public frmInputBox()
        {
            InitializeComponent();
            
        }

        public string strFileName = "";

        public void setInputBoxOption(string strTitle, string strPrompt, string strDefaultValue)
        {
            this.Text = strTitle;
            lblPrompt.Text = strPrompt;
            txtContent.Text = strDefaultValue;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            strFileName = txtContent.Text;
            this.Hide();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
           // this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Hide();
        }
    }
}