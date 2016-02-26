using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TFrmAttackSabukWall: Form
    {
        public static TFrmAttackSabukWall FrmAttackSabukWall = null;
        public static int nStute = 0;
        public static string m_sGuildName = String.Empty;
        public static DateTime m_AttackDate;

        public TFrmAttackSabukWall()
        {
            InitializeComponent();
        }

        //// Private declarations
        //private void LoadGuildList()
        //{
        //    int I;
        //    TGUild Guild;
        //    ListBoxGuild.Items.Clear();
        //    if (M2Share.g_GuildManager.GuildList.Count > 0)
        //    {
        //        for (I = 0; I < M2Share.g_GuildManager.GuildList.Count; I ++ )
        //        {
        //            Guild = ((TGUild)(M2Share.g_GuildManager.GuildList[I]));
        //            ListBoxGuild.Items.AddObject(Guild.sGuildName, ((Guild) as Object));
        //        }
        //    }
        //}

        //// Public declarations
        //public void Open()
        //{
        //    switch(Units.AttackSabukWallConfig.nStute)
        //    {
        //        case 0:
        //            EditGuildName.Text = "";
                    
        //            RzDateTimeEditAttackDate.Date = DateTime.Today;
        //            break;
        //        case 1:
        //            EditGuildName.Text = Units.AttackSabukWallConfig.m_sGuildName;
                    
        //            RzDateTimeEditAttackDate.Date = Units.AttackSabukWallConfig.m_AttackDate;
        //            break;
        //    }
        //    LoadGuildList();
        //    this.ShowDialog();
        //}

        //public void ButtonOKClick(object sender, EventArgs e)
        //{
        //    string sGuildName;
        //    DateTime AttackDate;
        //    int I;
        //    ButtonOK.Enabled = false;
        //    sGuildName = EditGuildName.Text.Trim();
            
        //    AttackDate = RzDateTimeEditAttackDate.Date;
        //    switch(Units.AttackSabukWallConfig.nStute)
        //    {
        //        case 0:
        //            if (CheckBoxAll.Checked)
        //            {
        //                if (CastleManage.Units.CastleManage.CurCastle == null)
        //                {
        //                    return;
        //                }
        //                // nCount := -1;
        //                // frmCastleManage.ListViewAttackSabukWall.Items.Clear;
        //                // for i := 0 to CurCastle.m_AttackWarList.Count - 1 do begin
        //                // DisPose(pTAttackerInfo(CurCastle.m_AttackWarList.Items[i]));
        //                // end;
        //                // CurCastle.m_AttackWarList.Clear;
        //                if (ListBoxGuild.Items.Count > 0)
        //                {
        //                    // 20080630
        //                    for (I = 0; I < ListBoxGuild.Items.Count; I ++ )
        //                    {
                                
        //                        if (!CastleManage.Units.CastleManage.frmCastleManage.IsAttackSabukWallOfGuild(ListBoxGuild.Items.Strings[I], AttackDate))
        //                        {
                                    
        //                            CastleManage.Units.CastleManage.frmCastleManage.AddAttackSabukWallOfGuild(ListBoxGuild.Items.Strings[I], AttackDate);
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (!CastleManage.Units.CastleManage.frmCastleManage.IsAttackSabukWallOfGuild(sGuildName, AttackDate))
        //                {
        //                    if (!CastleManage.Units.CastleManage.frmCastleManage.AddAttackSabukWallOfGuild(sGuildName, AttackDate))
        //                    {
        //                        return;
        //                    }
        //                }
        //            }
        //            break;
        //        case 1:
        //            if (CheckBoxAll.Checked)
        //            {
        //                if (CastleManage.Units.CastleManage.CurCastle == null)
        //                {
        //                    return;
        //                }
        //                // nCount := -1;
        //                // frmCastleManage.ListViewAttackSabukWall.Items.Clear;
        //                // for i := 0 to CurCastle.m_AttackWarList.Count - 1 do begin
        //                // DisPose(pTAttackerInfo(CurCastle.m_AttackWarList.Items[i]));
        //                // end;
        //                // CurCastle.m_AttackWarList.Clear;
        //                if (ListBoxGuild.Items.Count > 0)
        //                {
        //                    // 20080630
        //                    for (I = 0; I < ListBoxGuild.Items.Count; I ++ )
        //                    {
                                
        //                        if (!CastleManage.Units.CastleManage.frmCastleManage.IsAttackSabukWallOfGuild(ListBoxGuild.Items.Strings[I], AttackDate))
        //                        {
                                    
        //                            CastleManage.Units.CastleManage.frmCastleManage.AddAttackSabukWallOfGuild(ListBoxGuild.Items.Strings[I], AttackDate);
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (!CastleManage.Units.CastleManage.frmCastleManage.ChgAttackSabukWallOfGuild(sGuildName, AttackDate))
        //                {
        //                    return;
        //                }
        //            }
        //            break;
        //    }
        //    this.Close();
        //}

        //public void ListBoxGuildClick(object sender, EventArgs e)
        //{
        //    try {
                
        //        EditGuildName.Text = ListBoxGuild.Items.Strings[ListBoxGuild.SelectedIndex];
        //    }
        //    catch {
        //    }
        //}

        //public void CheckBoxAllClick(object sender, EventArgs e)
        //{
        //    EditGuildName.Enabled = !CheckBoxAll.Checked;
        //}

    } // end TFrmAttackSabukWall

}
