using System;
using System.Windows.Forms;

namespace M2Server
{
    // 行会管理
    public partial class TfrmGuildManage : Form
    {
        public static TfrmGuildManage frmGuildManage = null;
        public static TGUild CurGuild = null;
        public static bool boRefing = false;

        public TfrmGuildManage()
        {
            InitializeComponent();
        }

        private void RefGuildList()
        {
            TGUild Guild;
            ListViewItem ListItem;
            if (M2Share.g_GuildManager.GuildList.Count > 0)
            {
                for (int I = 0; I < M2Share.g_GuildManager.GuildList.Count; I++)
                {
                    Guild = M2Share.g_GuildManager.GuildList[I];
                    ListItem = new ListViewItem();
                    ListItem.Text = (I).ToString();
                    ListItem.SubItems.Add(Guild.sGuildName);
                    ListViewGuild.Items.Add(ListItem);
                }
            }
        }

        public void Open()
        {
            EditGuildMemberCount.Value = M2Share.g_Config.nGuildMemberCount;
            RefGuildList();
            this.ShowDialog();
        }

        private void RefGuildInfo()
        {
            if (CurGuild == null)
            {
                return;
            }
            boRefing = true;
            EditGuildName.Text = CurGuild.sGuildName;
            EditBuildPoint.Value = CurGuild.nBuildPoint;// 建筑度
            EditAurae.Value = CurGuild.nAurae;// 人气度
            EditStability.Value = CurGuild.nStability;// 安定度
            EditFlourishing.Value = CurGuild.nFlourishing;// 繁荣度
            EditChiefItemCount.Value = CurGuild.nChiefItemCount;// 行会领取装备数量
            EditGuildFountain.Value = CurGuild.m_nGuildFountain;// 行会泉水仓库
            SpinEditGuildMemberCount.Value = CurGuild.m_nGuildMemberCount;// 行会成员数量
            boRefing = false;
        }

        public void ListViewGuildClick(object sender, EventArgs e)
        {
            ListViewItem ListItem;
            //ListItem = ListViewGuild.Selected;
            //if (ListItem == null)
            //{
            //    return;
            //}
            // CurGuild = ((TGUild)(ListItem.SubItems.Objects[0]));
            RefGuildInfo();
        }

        public void Button1Click(object sender, EventArgs e)
        {
            try
            {
                if (CurGuild == null)
                {
                    return;
                }
                if (EditGuildName.Text != "")
                {
                    if ((CurGuild.sGuildName).ToLower().CompareTo((EditGuildName.Text).ToLower()) == 0)
                    {
                        CurGuild.nBuildPoint = (int)EditBuildPoint.Value;// 建筑度
                        CurGuild.nAurae = (int)EditAurae.Value;// 人气度
                        CurGuild.nStability = (int)EditStability.Value;// 安定度
                        CurGuild.nFlourishing = (int)EditFlourishing.Value;// 繁荣度
                        CurGuild.nChiefItemCount = (int)EditChiefItemCount.Value;// 行会领取装备数量
                        CurGuild.m_nGuildFountain = (int)EditGuildFountain.Value;// 行会泉水仓库
                        CurGuild.m_nGuildMemberCount = (ushort)SpinEditGuildMemberCount.Value;// 行会成员数量
                        CurGuild.SaveGuildInfoFile();
                    }
                }
                Button1.Enabled = false;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TfrmGuildManage.Button1Click");
            }
        }

        public void EditBuildPointClick(object sender, EventArgs e)
        {
            Button1.Enabled = true;
        }

        public void EditGuildMemberCountChange(Object Sender)
        {
            M2Share.g_Config.nGuildMemberCount = (ushort)EditGuildMemberCount.Value;
        }

        public void Button2Click(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "GuildMemberCount", M2Share.g_Config.nGuildMemberCount);// 新建行会成员上限
            Button2.Enabled = false;
        }

        public void EditGuildMemberCountClick(object sender, EventArgs e)
        {
            Button2.Enabled = true;
        }

        private void ListViewGuild_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ListViewGuild.SelectedItems.Count > 0)
            {
                EditGuildName.Text = e.Item.SubItems[1].Text;
            }
        }
    }
}