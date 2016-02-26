using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmMonsterConfig: Form
    {
        public static TfrmMonsterConfig frmMonsterConfig = null;
        //private bool boOpened = false;
        //private bool boModValued = false;
        //public TfrmMonsterConfig()
        //{
        //    InitializeComponent();
        //}

        //// TfrmMonsterConfig
        //private void ModValue()
        //{
        //    boModValued = true;
        //    ButtonGeneralSave.Enabled = true;
        //}

        //private void uModValue()
        //{
        //    boModValued = false;
        //    ButtonGeneralSave.Enabled = false;
        //}

        //public void FormCreate(object sender, EventArgs e)
        //{
           
        //}

        //public void Open()
        //{
        //    boOpened = false;
        //    uModValue();
        //    RefGeneralInfo();
        //    boOpened = true;
        //    PageControl1.SelectedIndex = 0;
        //    this.ShowDialog();
        //}

        //private void RefGeneralInfo()
        //{
        //    EditMonOneDropGoldCount.Value = M2Share.g_Config.nMonOneDropGoldCount;
        //    CheckBoxDropGoldToPlayBag.Checked = M2Share.g_Config.boDropGoldToPlayBag;
        //}

        //public void ButtonGeneralSaveClick(object sender, EventArgs e)
        //{
            
        //    M2Share.Config.WriteInteger("Setup", "MonOneDropGoldCount", M2Share.g_Config.nMonOneDropGoldCount);
            
        //    M2Share.Config.WriteBool("Setup", "DropGoldToPlayBag", M2Share.g_Config.boDropGoldToPlayBag);
        //    uModValue();
        //}

        //public void EditMonOneDropGoldCountChange(Object Sender)
        //{
        //    if (EditMonOneDropGoldCount.Text == "")
        //    {
        //        EditMonOneDropGoldCount.Text = "0";
        //        return;
        //    }
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.nMonOneDropGoldCount = EditMonOneDropGoldCount.Value;
        //    ModValue();
        //}

        //public void CheckBoxDropGoldToPlayBagClick(object sender, EventArgs e)
        //{
        //    if (!boOpened)
        //    {
        //        return;
        //    }
        //    M2Share.g_Config.boDropGoldToPlayBag = CheckBoxDropGoldToPlayBag.Checked;
        //    ModValue();
        //}

        //public void FormDestroy(Object Sender)
        //{
        //    Units.MonsterConfig.frmMonsterConfig = null;
        //}

        //// Note: the original parameters are Object Sender, ref TCloseAction Action
        //public void FormClose(object sender, EventArgs e)
        //{
            
        //    Action = caFree;
        //}

    } // end TfrmMonsterConfig

}
