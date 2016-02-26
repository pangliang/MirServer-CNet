using System;
using System.Windows.Forms;
using System.IO;

namespace DBServer
{
    public partial class TFrmSetting : Form
    {
        public TFrmSetting()
        {
            InitializeComponent();
        }

        // Public declarations
        public void Open()
        {
            // CheckBoxAttack.Checked := boAttack;
            CheckBoxDenyChrName.Checked = DBShare.g_boDenyChrName;
            CheckBoxMinimize.Checked = DBShare.g_boMinimize;
            CheckBoxDeleteChrName.Checked = DBShare.g_boDeleteChrName;
            CheckBoxRandomNumber.Checked = DBShare.g_boRandomNumber;
            ButtonOK.Enabled = false;
            this.ShowDialog();
        }

        public void CheckBoxAttackClick(System.Object Sender, System.EventArgs _e1)
        {
            // boAttack := CheckBoxAttack.Checked;
            // ButtonOK.Enabled := True;

        }

        public void CheckBoxDeleteChrNameClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.g_boDeleteChrName = CheckBoxDeleteChrName.Checked;
            ButtonOK.Enabled = true;
        }

        public void CheckBoxDenyChrNameClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.g_boDenyChrName = CheckBoxDenyChrName.Checked;
            ButtonOK.Enabled = true;
        }

        public void ButtonOKClick(System.Object Sender, System.EventArgs _e1)
        {
            GameFramework.IniFile Conf;
            Conf = new GameFramework.IniFile(DBShare.g_sConfFileName);
            if (Conf != null)
            {
                // Conf.WriteBool('Setup', 'Attack', boAttack);
                Conf.WriteBool("Setup", "DenyChrName", DBShare.g_boDenyChrName);
                Conf.WriteBool("Setup", "Minimize", DBShare.g_boMinimize);
                Conf.WriteBool("Setup", "DeleteChrName", DBShare.g_boDeleteChrName);
                Conf.WriteBool("Setup", "RandomNumber", DBShare.g_boRandomNumber);
                ButtonOK.Enabled = false;
            }
        }

        public void CheckBoxMinimizeClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.g_boMinimize = CheckBoxMinimize.Checked;
            ButtonOK.Enabled = true;
        }

        public void CheckBoxRandomNumberClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.g_boRandomNumber = CheckBoxRandomNumber.Checked;
            ButtonOK.Enabled = true;
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            CheckBoxRandomNumber.Enabled = true;
        }

    } // end TFrmSetting

}
