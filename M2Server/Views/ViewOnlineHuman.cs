/****************************************************************
 ** 文件名：ViewOnlineHuman.cs
 ** Copyright(c)2012-2020 JohnSoft
 ** 创建人：陶志强
 ** 日  期：2013-4-21
 ** 修改人：Daomi
 ** 日  期：2013-4-21 12:02 Fixed ShowHumanInfo
 ** 描  述：在线列表
 ****************************************************************/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using GameFramework;
using System.Drawing;

namespace M2Server
{
    public partial class TfrmViewOnlineHuman: Form
    {
        private List<TPlayObject> ViewList = null;//玩家列表
        private uint dwTimeOutTick = 0;//时间

        /****************************************************************
        ** 函 数 名：TfrmViewOnlineHuman
        ** 功能描述：构造函数
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        public TfrmViewOnlineHuman()
        {
            InitializeComponent();
        }

        /****************************************************************
        ** 函 数 名：TfrmViewOnlineHuman_Load
        ** 功能描述：窗体载入事件
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void TfrmViewOnlineHuman_Load(object sender, EventArgs e)
        {
            ViewList = new List<TPlayObject>();
            GridHuman.Columns.Add("序号", 80);
            GridHuman.Columns.Add("人物名称", 80);
            GridHuman.Columns.Add("性别", 80);
            GridHuman.Columns.Add("职业", 80);
            GridHuman.Columns.Add("等级", 80);
            GridHuman.Columns.Add("内功等级", 80);
            GridHuman.Columns.Add("地图", 80);
            GridHuman.Columns.Add("座标", 80);
            GridHuman.Columns.Add("登录帐号", 80);
            GridHuman.Columns.Add("登录IP", 80);
            GridHuman.Columns.Add("权限", 80);
            GridHuman.Columns.Add("所在地区", 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGameGoldName, 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGamePointName, 80);
            GridHuman.Columns.Add(M2Share.g_Config.sPayMentPointName, 80);
            GridHuman.Columns.Add("离线挂机", 80);
            GridHuman.Columns.Add("自动回复", 80);
            GridHuman.Columns.Add("未处理消息", 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGameDiaMond, 80);
            GridHuman.Columns.Add(M2Share.g_Config.sGameGird, 80);
            if (M2Share.UserEngine != null)
            {
                this.Text = string.Format(" [在线人数：{0}]", M2Share.UserEngine.PlayObjectCount);
            }
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
            Timer.Enabled = true;
        }

        /****************************************************************
        ** 函 数 名：GetOnlineList
        ** 功能描述：取在线人物列表
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void GetOnlineList()
        {
            ViewList.Clear();
            //测试数据
            //ViewList.Add(new TPlayObject() { m_sCharName ="john1"});
            //ViewList.Add(new TPlayObject() { m_sCharName = "john" });
            try {
                HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                if (M2Share.UserEngine != null)
                {
                    for (int I = 0; I < M2Share.UserEngine.m_PlayObjectList.Count; I++)
                    {
                        ViewList.Add(M2Share.UserEngine.m_PlayObjectList[I]);
                    }
                }
            } finally {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        /****************************************************************
        ** 函 数 名：RefGridSession
        ** 功能描述：刷新网格信息
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void RefGridSession()
        {
            PanelStatus.Text = "正在取得数据...";
            GridHuman.Visible = false;
            GridHuman.Items.Clear();
            int i = 1;
            foreach (TPlayObject PlayObject in ViewList)
            {
                if (PlayObject != null)
                {
                    ListViewItem lvItem = GridHuman.Items.Add(i.ToString());
                    lvItem.SubItems.Add(PlayObject.m_sCharName);
                    lvItem.SubItems.Add(HUtil32.IntToSex(PlayObject.m_btGender));
                    lvItem.SubItems.Add(HUtil32.IntToJob(PlayObject.m_btJob));
                    lvItem.SubItems.Add((PlayObject.m_Abil.Level).ToString());
                    lvItem.SubItems.Add((PlayObject.m_NGLevel).ToString());
                    lvItem.SubItems.Add(PlayObject.m_sMapName);
                    lvItem.SubItems.Add((PlayObject.m_nCurrX).ToString() + ":" + (PlayObject.m_nCurrY).ToString());
                    lvItem.SubItems.Add(PlayObject.m_sUserID);
                    lvItem.SubItems.Add(PlayObject.m_sIPaddr);
                    lvItem.SubItems.Add((PlayObject.m_btPermission).ToString());
                    lvItem.SubItems.Add(PlayObject.m_sIPLocal);
                    lvItem.SubItems.Add((PlayObject.m_nGameGold).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nGamePoint).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nPayMentPoint).ToString());
                    lvItem.SubItems.Add(HUtil32.BooleanToStr(PlayObject.m_boNotOnlineAddExp));
                    lvItem.SubItems.Add(PlayObject.m_sAutoSendMsg);
                    lvItem.SubItems.Add((PlayObject.MessageCount()).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nGAMEDIAMOND).ToString());
                    lvItem.SubItems.Add((PlayObject.m_nGAMEGIRD).ToString());
                    i++;
                }
            }
            GridHuman.Visible = true;
        }

        /****************************************************************
        ** 函 数 名：Timer_Tick
        ** 功能描述：时钟事件
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((HUtil32.GetTickCount() - dwTimeOutTick > 30000) && (ViewList.Count > 0))
            {
                RefGridSession();
                if (M2Share.UserEngine != null)
                {
                    this.Text = string.Format(" [在线人数：{0}]", M2Share.UserEngine.PlayObjectCount);
                }
                dwTimeOutTick = HUtil32.GetTickCount();
            }
        }

        /****************************************************************
        ** 函 数 名：ButtonRefGrid_Click
        ** 功能描述：刷新按钮
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void ButtonRefGrid_Click(object sender, EventArgs e)
        {
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
        }

        /****************************************************************
        ** 函 数 名：ButtonRefGrid_Click
        ** 功能描述：搜索按钮
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            TPlayObject PlayObject;
            string sHumanName = EditSearchName.Text.Trim();
            if (sHumanName == "")
            {
                MessageBox.Show("请输入一个人物名称！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int I = 0; I < ViewList.Count; I++)
            {
                PlayObject = ViewList[I];
                if (string.Compare(PlayObject.m_sCharName, sHumanName, true) == 0)
                {
                    GridHuman.Items[I].Selected = true;
                    GridHuman.Items[I].BackColor = Color.Green;
                    return;
                }
            }
            MessageBox.Show("人物没有在线！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        /****************************************************************
        ** 函 数 名：ButtonRefGrid_Click
        ** 功能描述：踢下线按钮
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void ButtonKick_Click(object sender, EventArgs e)
        {
            TPlayObject PlayObject;
            string sHumanName = EditSearchName.Text.Trim();
            if (sHumanName == "")
            {
                MessageBox.Show("请输入一个人物名称！！！", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int I = 0; I < ViewList.Count; I++)
            {
                PlayObject = ViewList[I];
                if ((PlayObject.m_sCharName.IndexOf(sHumanName) != -1))
                {
                    PlayObject.m_boEmergencyClose = true;
                    PlayObject.m_boNotOnlineAddExp = false;
                    PlayObject.m_boPlayOffLine = false;
                }
            }
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
        }

        /****************************************************************
        ** 函 数 名：ShowHumanInfo
        ** 功能描述：排序在线列表
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：Daomi 修正判断选择单元格索引越界
        ** 日    期：2013-4-21 12:02
        ****************************************************************/
        private void ShowHumanInfo()
        {
            int nSelIndex;
            string sPlayObjectName;
            TPlayObject PlayObject;
            if (GridHuman.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择一个要查看的人物！！！", "提示信息", MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }
            nSelIndex = GridHuman.SelectedItems[0].Index;
            sPlayObjectName = GridHuman.Items[nSelIndex].SubItems[1].Text;
            PlayObject = M2Share.UserEngine.GetPlayObject(sPlayObjectName);
            if (PlayObject == null)
            {
                MessageBox.Show("此人物已经不在线！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TfrmHumanInfo frmHumanInfo = new TfrmHumanInfo();
            frmHumanInfo.PlayObject = PlayObject;
            frmHumanInfo.ShowDialog(this);

        }

        /****************************************************************
        ** 函 数 名：ButtonView_Click
        ** 功能描述：人物信息按钮
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void ButtonView_Click(object sender, EventArgs e)
        {
            ShowHumanInfo();
        }

        /****************************************************************
        ** 函 数 名：GridHuman_CellDoubleClick
        ** 功能描述：网格双击事件
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void GridHuman_DoubleClick(object sender, EventArgs e)
        {
            ShowHumanInfo();
        }

        /****************************************************************
        ** 函 数 名：Button1_Click
        ** 功能描述：踢出离线挂机按钮
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void Button1_Click(object sender, EventArgs e)
        {
            int I;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                for (I = 0; I < M2Share.UserEngine.m_PlayObjectList.Count; I++)
                {
                    if (M2Share.UserEngine.m_PlayObjectList[I].m_boNotOnlineAddExp)
                    {
                        M2Share.UserEngine.m_PlayObjectList[I].m_boNotOnlineAddExp = false;
                        M2Share.UserEngine.m_PlayObjectList[I].m_boPlayOffLine = false;
                        M2Share.UserEngine.m_PlayObjectList[I].m_boKickFlag = true;
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            dwTimeOutTick = HUtil32.GetTickCount();
            GetOnlineList();
            RefGridSession();
        }

        /****************************************************************
        ** 函 数 名：GridHuman_ItemSelectionChanged
        ** 功能描述：List选项变更事件
        ** 输入参数：无
        ** 输出参数：无
        ** 返 回 值：无
        ** 创 建 人：陶志强
        ** 日    期：2013-4-21
        ** 修 改 人：
        ** 日    期：
        ****************************************************************/
        private void GridHuman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridHuman.SelectedItems.Count == 0) return;
            EditSearchName.Text = GridHuman.SelectedItems[0].SubItems[1].Text;
        }

    } 
}

