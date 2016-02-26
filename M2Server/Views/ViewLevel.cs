using GameFramework;
using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmViewLevel : Form
    {
        private TPlayObject PlayObject = null;

        public TfrmViewLevel()
        {
            InitializeComponent();
        }

        public void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ComboBoxJobChange(object sender, EventArgs e)
        {
            PlayObject.m_btJob = (byte)ComboBoxJob.SelectedIndex;
            RefView();
        }

        private void TfrmViewLevel_Load(object sender, EventArgs e)
        {
            GridHumanInfo.Columns.Add("属性");
            GridHumanInfo.Columns.Add("数值");
            GridHumanInfo.Columns.Add("经验值");
            GridHumanInfo.Columns.Add("防御");
            GridHumanInfo.Columns.Add("魔防");
            GridHumanInfo.Columns.Add("攻击力");
            GridHumanInfo.Columns.Add("魔法");
            GridHumanInfo.Columns.Add("道术");
            GridHumanInfo.Columns.Add("生命值");
            GridHumanInfo.Columns.Add("魔法值");
            GridHumanInfo.Columns.Add("背包");
            GridHumanInfo.Columns.Add("负重");
            GridHumanInfo.Columns.Add("腕力");
            PlayObject = new TPlayObject();
            PlayObject.m_Abil.Level = 1;
            PlayObject.m_btJob = 0;
            PlayObject.m_sMapName = "0";
            PlayObject.m_PEnvir = M2Share.g_MapManager.FindMap("0");
            PlayObject.m_nCurrX = 330;
            PlayObject.m_nCurrY = 266;
            EditHumanLevel.Value = 1;
            ComboBoxJob.SelectedIndex = 0;
            RefView();
        }

        private void RefView()
        {
            GridHumanInfo.Items.Clear();
            RecalcHuman();
            ListViewItem lvItem = GridHumanInfo.Items.Add(PlayObject.m_Abil.MaxExp.ToString());
            lvItem.SubItems.Add((HUtil32.LoWord(PlayObject.m_WAbil.AC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.AC)).ToString());
            lvItem.SubItems.Add((HUtil32.LoWord(PlayObject.m_WAbil.MAC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.MAC)).ToString());
            lvItem.SubItems.Add((HUtil32.LoWord(PlayObject.m_WAbil.DC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.DC)).ToString());
            lvItem.SubItems.Add((HUtil32.LoWord(PlayObject.m_WAbil.MC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.MC)).ToString());
            lvItem.SubItems.Add((HUtil32.LoWord(PlayObject.m_WAbil.SC)).ToString() + "/" + (HUtil32.HiWord(PlayObject.m_WAbil.SC)).ToString());
            lvItem.SubItems.Add((PlayObject.m_WAbil.HP).ToString() + "/" + (PlayObject.m_WAbil.MaxHP).ToString());
            lvItem.SubItems.Add((PlayObject.m_WAbil.MP).ToString() + "/" + (PlayObject.m_WAbil.MaxMP).ToString());
            lvItem.SubItems.Add((PlayObject.m_WAbil.Weight).ToString() + "/" + (PlayObject.m_WAbil.MaxWeight).ToString());
            lvItem.SubItems.Add((PlayObject.m_WAbil.WearWeight).ToString() + "/" + (PlayObject.m_WAbil.MaxWearWeight).ToString());
            lvItem.SubItems.Add((PlayObject.m_WAbil.HandWeight).ToString() + "/" + (PlayObject.m_WAbil.MaxHandWeight).ToString());
        }

        private void RecalcHuman()
        {
            PlayObject.RecalcLevelAbilitys();
            PlayObject.RecalcAbilitys();
            PlayObject.CompareSuitItem(false);
            // 套装与身上装备对比 20080729
            PlayObject.HasLevelUp(0);
        }

        private void EditHumanLevel_ValueChanged(object sender, EventArgs e)
        {
            if (EditHumanLevel.Value < 1)
            {
                EditHumanLevel.Value = 1;
            }
            PlayObject.m_Abil.Level = (ushort)EditHumanLevel.Value;
            RefView();
        }


    }
}