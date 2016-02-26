using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmActionSpeed: Form
    {
        public static TfrmActionSpeed frmActionSpeed = null;
        private bool boOpened = false;
        private bool boModValued = false;

        public TfrmActionSpeed()
        {
            InitializeComponent();
        }

        //// TfrmActionSpeed
        //private void ModValue()
        //{
        //    boModValued = true;
        //    ButtonSave.Enabled = true;
        //}

        //private void uModValue()
        //{
        //    boModValued = false;
        //    ButtonSave.Enabled = false;
        //}

        //public void Open()
        //{
        //    boOpened = false;
        //    uModValue();
        //    RefSpeedConfig();
        //    boOpened = true;
        //    this.ShowDialog();
        //}

        //public void ButtonCloseClick(object sender, EventArgs e)
        //{
        //    const string sExitMsg = "设置已被修改是否不保存设置退出？";
        //    const string sExitMsgTitle = "确认信息";
        //    if (!boModValued)
        //    {
        //        this.Close();
        //        return;
        //    }
        //    if ((MessageBox.Show((sExitMsg as string), (sExitMsgTitle as string),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes))
        //    {
        //        this.Close();
        //    }
        //}

        //private void RefSpeedConfig()
        //{
        //    EditActionIntervalTime.Value = M2Share.g_Config.dwActionIntervalTime;
        //    EditRunLongHitIntervalTime.Value = M2Share.g_Config.dwRunLongHitIntervalTime;
        //    EditRunHitIntervalTime.Value = M2Share.g_Config.dwRunHitIntervalTime;
        //    EditWalkHitIntervalTime.Value = M2Share.g_Config.dwWalkHitIntervalTime;
        //    EditRunMagicIntervalTime.Value = M2Share.g_Config.dwRunMagicIntervalTime;
        //    CheckBoxControlActionInterval.Checked = M2Share.g_Config.boControlActionInterval;
        //    CheckBoxControlRunLongHit.Checked = M2Share.g_Config.boControlRunLongHit;
        //    CheckBoxControlRunHit.Checked = M2Share.g_Config.boControlRunHit;
        //    CheckBoxControlWalkHit.Checked = M2Share.g_Config.boControlWalkHit;
        //    CheckBoxControlRunMagic.Checked = M2Share.g_Config.boControlRunMagic;
        //}

        //public void ButtonDefaultClick(object sender, EventArgs e)
        //{
        //    const string sExitMsg = "是否确认恢复默认设置？";
        //    const string sExitMsgTitle = "确认信息";
        //    if (System.Windows.Forms.MessageBox.Show((sExitMsg as string), (sExitMsgTitle as string), System.Windows.Forms.MessageBoxButtons.YesNo + System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        //    {
        //        return;
        //    }
        //    boOpened = false;
        //    ModValue();
        //    M2Share.g_Config.dwActionIntervalTime = 400;
        //    M2Share.g_Config.dwRunLongHitIntervalTime = 800;
        //    M2Share.g_Config.dwRunHitIntervalTime = 800;
        //    M2Share.g_Config.dwWalkHitIntervalTime = 800;
        //    M2Share.g_Config.dwRunMagicIntervalTime = 900;
        //    M2Share.g_Config.boControlActionInterval = true;
        //    M2Share.g_Config.boControlRunLongHit = true;
        //    M2Share.g_Config.boControlRunHit = true;
        //    M2Share.g_Config.boControlWalkHit = true;
        //    M2Share.g_Config.boControlRunMagic = true;
        //    RefSpeedConfig();
        //    boOpened = true;
        //}

        //private void SaveConfig()
        //{
            
        //    M2Share.Config.WriteBool("Setup", "ControlActionInterval", M2Share.g_Config.boControlActionInterval);
            
        //    M2Share.Config.WriteBool("Setup", "ControlWalkHit", M2Share.g_Config.boControlWalkHit);
            
        //    M2Share.Config.WriteBool("Setup", "ControlRunLongHit", M2Share.g_Config.boControlRunLongHit);
            
        //    M2Share.Config.WriteBool("Setup", "ControlRunHit", M2Share.g_Config.boControlRunHit);
            
        //    M2Share.Config.WriteBool("Setup", "ControlRunMagic", M2Share.g_Config.boControlRunMagic);
            
        //    M2Share.Config.WriteInteger("Setup", "ActionIntervalTime", M2Share.g_Config.dwActionIntervalTime);
            
        //    M2Share.Config.WriteInteger("Setup", "RunLongHitIntervalTime", M2Share.g_Config.dwRunLongHitIntervalTime);
            
        //    M2Share.Config.WriteInteger("Setup", "RunHitIntervalTime", M2Share.g_Config.dwRunHitIntervalTime);
            
        //    M2Share.Config.WriteInteger("Setup", "WalkHitIntervalTime", M2Share.g_Config.dwWalkHitIntervalTime);
            
        //    M2Share.Config.WriteInteger("Setup", "RunMagicIntervalTime", M2Share.g_Config.dwRunMagicIntervalTime);
        //}

        //public void ButtonSaveClick(object sender, EventArgs e)
        //{
        //    SaveConfig();
        //    uModValue();
        //}

        //public void CheckBoxIncremengClick(object sender, EventArgs e)
        //{
        //    int nIncrement;
        //    if (CheckBoxIncremeng.Checked)
        //    {
        //        nIncrement = 1;
        //    }
        //    else
        //    {
        //        nIncrement = 10;
        //    }
        //    EditActionIntervalTime.Increment = nIncrement;
        //    EditRunLongHitIntervalTime.Increment = nIncrement;
        //    EditRunHitIntervalTime.Increment = nIncrement;
        //    EditWalkHitIntervalTime.Increment = nIncrement;
        //}

        //public void CheckBoxControlActionIntervalClick(object sender, EventArgs e)
        //{
        //    bool boStatus;
        //    boStatus = CheckBoxControlActionInterval.Checked;
        //    EditActionIntervalTime.Enabled = boStatus;
        //    CheckBoxControlRunLongHit.Enabled = boStatus;
        //    CheckBoxControlRunHit.Enabled = boStatus;
        //    CheckBoxControlWalkHit.Enabled = boStatus;
        //    CheckBoxControlRunMagic.Enabled = boStatus;
        //    CheckBoxControlRunLongHitClick(Sender);
        //    CheckBoxControlRunHitClick(Sender);
        //    CheckBoxControlWalkHitClick(Sender);
        //    CheckBoxControlRunMagicClick(Sender);
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.boControlActionInterval = boStatus;
        //    ModValue();
        //}

        //public void EditActionIntervalTimeChange(Object Sender)
        //{
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.dwActionIntervalTime = EditActionIntervalTime.Value;
        //    ModValue();
        //}

        //public void CheckBoxControlRunLongHitClick(object sender, EventArgs e)
        //{
        //    bool boStatus;
        //    boStatus = CheckBoxControlRunLongHit.Checked && CheckBoxControlRunLongHit.Enabled;
        //    EditRunLongHitIntervalTime.Enabled = boStatus;
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.boControlRunLongHit = boStatus;
        //    ModValue();
        //}

        //public void EditRunLongHitIntervalTimeChange(Object Sender)
        //{
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.dwRunLongHitIntervalTime = EditRunLongHitIntervalTime.Value;
        //    ModValue();
        //}

        //public void CheckBoxControlRunHitClick(object sender, EventArgs e)
        //{
        //    bool boStatus;
        //    boStatus = CheckBoxControlRunHit.Checked && CheckBoxControlRunHit.Enabled;
        //    EditRunHitIntervalTime.Enabled = boStatus;
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.boControlRunHit = boStatus;
        //    ModValue();
        //}

        //public void EditRunHitIntervalTimeChange(Object Sender)
        //{
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.dwRunHitIntervalTime = EditRunHitIntervalTime.Value;
        //    ModValue();
        //}

        //public void CheckBoxControlWalkHitClick(object sender, EventArgs e)
        //{
        //    bool boStatus;
        //    boStatus = CheckBoxControlWalkHit.Checked && CheckBoxControlWalkHit.Enabled;
        //    EditWalkHitIntervalTime.Enabled = boStatus;
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.boControlWalkHit = boStatus;
        //    ModValue();
        //}

        //public void EditWalkHitIntervalTimeChange(Object Sender)
        //{
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.dwWalkHitIntervalTime = EditWalkHitIntervalTime.Value;
        //    ModValue();
        //}

        //public void CheckBoxControlRunMagicClick(object sender, EventArgs e)
        //{
        //    bool boStatus;
        //    boStatus = CheckBoxControlRunMagic.Checked && CheckBoxControlRunMagic.Enabled;
        //    EditRunMagicIntervalTime.Enabled = boStatus;
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.boControlRunMagic = boStatus;
        //    ModValue();
        //}

        //public void EditRunMagicIntervalTimeChange(Object Sender)
        //{
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.dwRunMagicIntervalTime = EditRunMagicIntervalTime.Value;
        //    ModValue();
        //}

    } // end TfrmActionSpeed

}

