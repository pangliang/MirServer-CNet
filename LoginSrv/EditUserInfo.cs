using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TFrmUserInfoEdit : Form
    {
        public static TFrmUserInfoEdit FrmUserInfoEdit = null;

        public TFrmUserInfoEdit()
        {
            InitializeComponent();
        }

        public void CkFullEditClick(System.Object Sender, System.EventArgs _e1)
        {
            bool bo05;
            bo05 = CkFullEdit.Checked;
            EdUserName.Enabled = bo05;
            EdSSNo.Enabled = bo05;
            EdBirthDay.Enabled = bo05;
            EdQuiz.Enabled = bo05;
            EdAnswer.Enabled = bo05;
            EdQuiz2.Enabled = bo05;
            EdAnswer2.Enabled = bo05;
            EdPhone.Enabled = bo05;
            EdMobilePhone.Enabled = bo05;
            EdMemo1.Enabled = bo05;
            EdMemo2.Enabled = bo05;
            EdEMail.Enabled = bo05;
        }

        // 00466B10
        public bool sub_466B10(bool boNew, ref TAccountDBRecord DBRecord)
        {
            bool result;
            result = false;
            if (!boNew)
            {
                CkFullEdit.Enabled = true;
                CkFullEdit.Checked = false;

                //CkFullEditClick(this);
                EdId.Enabled = false;
            }
            else
            {
                CkFullEdit.Enabled = false;
                CkFullEdit.Checked = true;

                //CkFullEditClick(this);
                EdId.Enabled = true;
            }
            EdId.Text = DBRecord.UserEntry.sAccount;
            EdPasswd.Text = DBRecord.UserEntry.sPassword;
            EdUserName.Text = DBRecord.UserEntry.sUserName;
            EdSSNo.Text = DBRecord.UserEntry.sSSNo;
            EdBirthDay.Text = DBRecord.UserEntryAdd.sBirthDay;
            EdQuiz.Text = DBRecord.UserEntry.sQuiz;
            EdAnswer.Text = DBRecord.UserEntry.sAnswer;
            EdQuiz2.Text = DBRecord.UserEntryAdd.sQuiz2;
            EdAnswer2.Text = DBRecord.UserEntryAdd.sAnswer2;
            EdPhone.Text = DBRecord.UserEntry.sPhone;
            EdMobilePhone.Text = DBRecord.UserEntryAdd.sMobilePhone;
            EdMemo1.Text = DBRecord.UserEntryAdd.sMemo;
            EdMemo2.Text = DBRecord.UserEntryAdd.sMemo2;
            EdEMail.Text = DBRecord.UserEntry.sEMail;
            if (this.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return result;
            }
            if (boNew)
            {
                DBRecord.UserEntry.sAccount = EdId.Text.Trim();
            }
            DBRecord.UserEntry.sPassword = EdPasswd.Text.Trim();
            DBRecord.UserEntry.sUserName = EdUserName.Text.Trim();
            DBRecord.UserEntry.sSSNo = EdSSNo.Text.Trim();
            DBRecord.UserEntryAdd.sBirthDay = EdBirthDay.Text.Trim();
            DBRecord.UserEntry.sQuiz = EdQuiz.Text.Trim();
            DBRecord.UserEntry.sAnswer = EdAnswer.Text.Trim();
            DBRecord.UserEntryAdd.sQuiz2 = EdQuiz2.Text.Trim();
            DBRecord.UserEntryAdd.sAnswer2 = EdAnswer2.Text.Trim();
            DBRecord.UserEntry.sPhone = EdPhone.Text.Trim();
            DBRecord.UserEntryAdd.sMobilePhone = EdMobilePhone.Text.Trim();
            DBRecord.UserEntryAdd.sMemo = EdMemo1.Text.Trim();
            DBRecord.UserEntryAdd.sMemo2 = EdMemo2.Text.Trim();
            DBRecord.UserEntry.sEMail = EdEMail.Text.Trim();
            result = true;
            return result;
        }

        public bool sub_466AEC(ref TAccountDBRecord DBRecord)
        {
            bool result;
            result = sub_466B10(false, ref DBRecord);
            return result;
        }
    } // end TFrmUserInfoEdit
}