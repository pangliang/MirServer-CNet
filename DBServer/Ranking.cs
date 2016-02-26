//using System;
//using System.Windows.Forms;
//using System.IO;

//namespace Ranking
//{
//    public partial class TFrmRankingDlg : Form
//    {
//        public TFrmRankingDlg()
//        {
//            InitializeComponent();
//        }

//        // Public declarations
//        public void Open()
//        {
//            CheckBoxAutoRefRanking.Checked = DBShare.Units.DBShare.g_boAutoRefRanking;
//            EditMinLevel.Value = DBShare.Units.DBShare.g_nRankingMinLevel;
//            EditMaxLevel.Value = DBShare.Units.DBShare.g_nRankingMaxLevel;
//            EditTime.Value = DBShare.Units.DBShare.g_nRefRankingHour1;
//            EditHour.Value = DBShare.Units.DBShare.g_nRefRankingHour2;
//            EditMinute1.Value = DBShare.Units.DBShare.g_nRefRankingMinute1;
//            EditMinute2.Value = DBShare.Units.DBShare.g_nRefRankingMinute2;
//            if (DBShare.Units.DBShare.g_nAutoRefRankingType == 0)
//            {
//                RadioButton1.Checked = true;
//            }
//            if (DBShare.Units.DBShare.g_nAutoRefRankingType == 1)
//            {
//                RadioButton2.Checked = true;
//            }
//            // RadioButton2.Checked:= Boolean(g_nAutoRefRankingType);
//            ButtonSave.Enabled = false;
//            RefRanking();
//            this.ShowDialog();
//        }

//        // Private declarations
//        private void RefRanking()
//        {
//            int I;
//            ListViewItem ListItem;
//            TUserLevelRanking HumRanking;
//            THeroLevelRanking HeroRanking;
//            TUserMasterRanking MasterRanking;
//            ListViewHum.Items.Clear;
//            ListViewWarrior.Items.Clear;
//            ListViewWizzard.Items.Clear;
//            ListViewMonk.Items.Clear;
//            ListViewHero.Items.Clear;
//            ListViewHeroWarrior.Items.Clear;
//            ListViewHeroWizzard.Items.Clear;
//            ListViewHeroMonk.Items.Clear;
//            ListViewMaster.Items.Clear;
//            //@ Unsupported function or procedure: 'EnterCriticalSection'
//            EnterCriticalSection(DBShare.Units.DBShare.g_Ranking_CS);
//            try
//            {
//                for (I = 0; I < DBShare.Units.DBShare.g_HumRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HumRanking = ((TUserLevelRanking)(DBShare.Units.DBShare.g_HumRanking.Values[I]));
//                    ListItem = ListViewHum.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HumRanking.sChrName, ((HumRanking) as Object));
//                    ListItem.SubItems.Add((HumRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_WarriorRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HumRanking = ((TUserLevelRanking)(DBShare.Units.DBShare.g_WarriorRanking.Values[I]));
//                    ListItem = ListViewWarrior.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HumRanking.sChrName, ((HumRanking) as Object));
//                    ListItem.SubItems.Add((HumRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_WizzardRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HumRanking = ((TUserLevelRanking)(DBShare.Units.DBShare.g_WizzardRanking.Values[I]));
//                    ListItem = ListViewWizzard.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HumRanking.sChrName, ((HumRanking) as Object));
//                    ListItem.SubItems.Add((HumRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_MonkRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HumRanking = ((TUserLevelRanking)(DBShare.Units.DBShare.g_MonkRanking.Values[I]));
//                    ListItem = ListViewMonk.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HumRanking.sChrName, ((HumRanking) as Object));
//                    ListItem.SubItems.Add((HumRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_HeroRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HeroRanking = ((THeroLevelRanking)(DBShare.Units.DBShare.g_HeroRanking.Values[I]));
//                    ListItem = ListViewHero.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HeroRanking.sHeroName, ((HeroRanking) as Object));
//                    ListItem.SubItems.Add(HeroRanking.sChrName);
//                    ListItem.SubItems.Add((HeroRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_HeroWarriorRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HeroRanking = ((THeroLevelRanking)(DBShare.Units.DBShare.g_HeroWarriorRanking.Values[I]));
//                    ListItem = ListViewHeroWarrior.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HeroRanking.sHeroName, ((HeroRanking) as Object));
//                    ListItem.SubItems.Add(HeroRanking.sChrName);
//                    ListItem.SubItems.Add((HeroRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_HeroWizzardRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HeroRanking = ((THeroLevelRanking)(DBShare.Units.DBShare.g_HeroWizzardRanking.Values[I]));
//                    ListItem = ListViewHeroWizzard.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HeroRanking.sHeroName, ((HeroRanking) as Object));
//                    ListItem.SubItems.Add(HeroRanking.sChrName);
//                    ListItem.SubItems.Add((HeroRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_HeroMonkRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    HeroRanking = ((THeroLevelRanking)(DBShare.Units.DBShare.g_HeroMonkRanking.Values[I]));
//                    ListItem = ListViewHeroMonk.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(HeroRanking.sHeroName, ((HeroRanking) as Object));
//                    ListItem.SubItems.Add(HeroRanking.sChrName);
//                    ListItem.SubItems.Add((HeroRanking.nLevel).ToString());
//                }
//                for (I = 0; I < DBShare.Units.DBShare.g_MasterRanking.Count; I++)
//                {
//                    //@ Unsupported property or method(A): 'Values'
//                    MasterRanking = ((TUserMasterRanking)(DBShare.Units.DBShare.g_MasterRanking.Values[I]));
//                    ListItem = ListViewMaster.Items.Add();
//                    ListItem.Text = (I).ToString();
//                    //@ Unsupported property or method(A): 'AddObject'
//                    ListItem.SubItems.AddObject(MasterRanking.sChrName, ((MasterRanking) as Object));
//                    ListItem.SubItems.Add((MasterRanking.nMasterCount).ToString());
//                }
//            }
//            finally
//            {
//                //@ Unsupported function or procedure: 'LeaveCriticalSection'
//                LeaveCriticalSection(DBShare.Units.DBShare.g_Ranking_CS);
//            }
//        }

//        public void ButtonRefRankingClick(System.Object Sender, System.EventArgs _e1)
//        {
//            ButtonRefRanking.Enabled = false;
//            //@ Unsupported function or procedure: 'GetTickCount'
//            DBShare.Units.DBShare.g_dwAutoRefRankingTick = GetTickCount;
//            // FrmMain.RefRanking;
//            RefRanking();
//            ButtonRefRanking.Enabled = true;
//        }

//        public void ButtonSaveClick(System.Object Sender, System.EventArgs _e1)
//        {
//            FileStream Conf;
//            int LoadInteger;
//            Conf = new FileStream(DBShare.Units.DBShare.g_sConfFileName);
//            if (Conf != null)
//            {
//                //@ Unsupported property or method(A): 'WriteBool'
//                Conf.WriteBool("Setup", "AutoRefRanking", DBShare.Units.DBShare.g_boAutoRefRanking);
//                //@ Unsupported property or method(A): 'WriteInteger'
//                Conf.WriteInteger("Setup", "RankingMinLevel", DBShare.Units.DBShare.g_nRankingMinLevel);
//                //@ Unsupported property or method(A): 'WriteInteger'
//                Conf.WriteInteger("Setup", "RankingMaxLevel", DBShare.Units.DBShare.g_nRankingMaxLevel);
//                //@ Unsupported property or method(A): 'WriteInteger'
//                Conf.WriteInteger("Setup", "RefRankingHour1", DBShare.Units.DBShare.g_nRefRankingHour1);
//                //@ Unsupported property or method(A): 'WriteInteger'
//                Conf.WriteInteger("Setup", "RefRankingHour2", DBShare.Units.DBShare.g_nRefRankingHour2);
//                //@ Unsupported property or method(A): 'WriteInteger'
//                Conf.WriteInteger("Setup", "RefRankingMinute1", DBShare.Units.DBShare.g_nRefRankingMinute1);
//                //@ Unsupported property or method(A): 'WriteInteger'
//                Conf.WriteInteger("Setup", "RefRankingMinute2", DBShare.Units.DBShare.g_nRefRankingMinute2);
//                //@ Unsupported property or method(A): 'WriteInteger'
//                Conf.WriteInteger("Setup", "AutoRefRankingType", DBShare.Units.DBShare.g_nAutoRefRankingType);
//            }
//            //@ Unsupported property or method(C): 'Free'
//            Conf.Free;
//            ButtonSave.Enabled = false;
//        }

//        public void CheckBoxAutoRefRankingClick(System.Object Sender, System.EventArgs _e1)
//        {
//            DBShare.Units.DBShare.g_boAutoRefRanking = CheckBoxAutoRefRanking.Checked;
//            ButtonSave.Enabled = true;
//        }

//        public void EditMinLevelChange(Object Sender)
//        {
//            DBShare.Units.DBShare.g_nRankingMinLevel = EditMinLevel.Value;
//            ButtonSave.Enabled = true;
//        }

//        public void EditMaxLevelChange(Object Sender)
//        {
//            DBShare.Units.DBShare.g_nRankingMaxLevel = EditMaxLevel.Value;
//            ButtonSave.Enabled = true;
//        }

//        public void EditTimeChange(Object Sender)
//        {
//            DBShare.Units.DBShare.g_nRefRankingHour1 = EditTime.Value;
//            ButtonSave.Enabled = true;
//        }

//        public void EditHourChange(Object Sender)
//        {
//            DBShare.Units.DBShare.g_nRefRankingHour2 = EditHour.Value;
//            ButtonSave.Enabled = true;
//        }

//        public void EditMinute1Change(Object Sender)
//        {
//            DBShare.Units.DBShare.g_nRefRankingMinute1 = EditMinute1.Value;
//            ButtonSave.Enabled = true;
//        }

//        public void EditMinute2Change(Object Sender)
//        {
//            DBShare.Units.DBShare.g_nRefRankingMinute2 = EditMinute2.Value;
//            ButtonSave.Enabled = true;
//        }

//        public void RadioButton1Click(System.Object Sender, System.EventArgs _e1)
//        {
//            if (RadioButton1.Checked)
//            {
//                DBShare.Units.DBShare.g_nAutoRefRankingType = 0;
//            }
//            else
//            {
//                DBShare.Units.DBShare.g_nAutoRefRankingType = 1;
//            }
//            ButtonSave.Enabled = true;
//        }

//        public void FormCreate(System.Object Sender, System.EventArgs _e1)
//        {
//            PageControl1.SelectedIndex = 0;
//            PageControl2.SelectedIndex = 0;
//        }

//    } // end TFrmRankingDlg

//}

//namespace Ranking.Units
//{
//    public class Ranking
//    {
//        public static TFrmRankingDlg FrmRankingDlg = null;
//    } // end Ranking

//}