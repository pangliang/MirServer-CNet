using System;
using System.Windows.Forms;

namespace DBServer
{
    public partial class TFrmCreateChr : Form
    {
        public string sUserId = String.Empty;
        public string sChrName = String.Empty;
        public int nSelectID = 0;

        public TFrmCreateChr()
        {
            InitializeComponent();
        }

        public void FormShow(Object Sender)
        {
            EdUserId.Focus();
        }

        public bool IncputChrInfo()
        {
            bool result;
            sUserId = "";
            sChrName = "";
            result = GetInputInfo();
            return result;
        }

        private bool GetInputInfo()
        {
            bool result;
            result = false;
            EdUserId.Text = sUserId;
            EdChrName.Text = sChrName;
            if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sUserId = EdUserId.Text.Trim();
                sChrName = EdChrName.Text.Trim();
                nSelectID = GameFramework.HUtil32.Str_ToInt(EditSelectID.Text.Trim(), -1);
                if (nSelectID < 0)
                {
                    MessageBox.Show("选择ID输入不正确！！！", "确认信息", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    return result;
                }
                result = true;
            }
            return result;
        }
    } // end TFrmCreateChr
}