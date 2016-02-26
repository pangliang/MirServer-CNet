/*****************************************************
** 文 件 名：InputBox.cs
** Copyright (c) 2011-2013 JohnSoft
** 文件编号：
** 创 建 人：陶志强
** 日    期：2011年8月23日
** 修 改 人：
** 日    期：
** 描    述：
********************************************************/
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class InputBox : Component
    {
        private static frmInputBox frm = null;
        public InputBox()
        {
            InitializeComponent();
            
        }

        public static string FileName
        {
            get { return frm.strFileName; }
        }

        public InputBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public static DialogResult Show(string strTitle, string strPrompt, string strDefaultValue)
        {
            if (frm == null)
            {
                frm = new frmInputBox();
            }
            frm.setInputBoxOption(strTitle, strPrompt, strDefaultValue);
            return frm.ShowDialog();
        }

        ~InputBox()
        {
            frm.Close();
            frm.Dispose();
        }
    }
}
