using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using GameFramework;

namespace M2Server
{
    public partial class TfrmViewList2 : Form
    {
        public static TfrmViewList2 frmViewList2 = null;

        public TfrmViewList2()
        {
            InitializeComponent();
        }

        // 判断有几个'|'号
        public static int IsChar(string str)
        {
            int result;
            int I;
            result = 0;
            for (I = 1; I <= str.Length; I++)
            {
                if ((new ArrayList(new string[] { "|" }).Contains(str[I])))
                {
                    result++;
                }
            }
            return result;
        }

        //取淬练列表物品的名称
        public static void GetBackRefineItemName(string ItmeStr, ref string sItemName, ref string sItemName1, ref string sItemName2)
        {
            string str = ItmeStr;
            if (str != "")
            {
                str = HUtil32.GetValidStr3(str, ref sItemName, new string[] { "+" });
                str = HUtil32.GetValidStr3(str, ref sItemName1, new string[] { "+" });
                str = HUtil32.GetValidStr3(str, ref sItemName2, new string[] { "+" });
            }
        }

        public bool IsRefineItemInfo_InStr(string Str, string sItemName, string sItemName1, string sItemName2)
        {
            bool result;
            result = false;
            if (Str.Length.ToString() == (sItemName + "+" + sItemName1 + "+") + sItemName2.Length.ToString())
            {
                if (Str.IndexOf(sItemName) > 0)
                {
                    Str = Str.Substring(0 - 1, Str.IndexOf(sItemName)) + Str.Substring(Str.IndexOf(sItemName) + sItemName.Length - 1, Str.Length);
                    if (Str.IndexOf(sItemName1) > 0)
                    {
                        Str = Str.Substring(0 - 1, Str.IndexOf(sItemName1)) + Str.Substring(Str.IndexOf(sItemName1) + sItemName1.Length - 1, Str.Length);
                        if (Str.IndexOf(sItemName2) > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        // 判断增加,修改的材料名称是否重复
        public bool IsRefineItemInfo(string sItemName, string sItemName1, string sItemName2)
        {
            bool result;
            int I;
            string Str;
            result = true;
            if (M2Share.g_RefineItemList.Count > 0)
            {
                for (I = 0; I < M2Share.g_RefineItemList.Count; I++)
                {
                    Str = M2Share.g_RefineItemList[I].sItemName;
                    if (IsRefineItemInfo_InStr(Str, sItemName, sItemName1, sItemName2))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void ClearEdt()
        {
            Edit2.Text = "";
            Edit1.Text = "";
            SpinEdtMaxHP.Value = 0;
            SpinEdtMaxMP.Value = 0;
            SpinEdit3.Value = 0;
            SpinEdit4.Value = 0;
            SpinEdit6.Value = 0;
            SpinEdit7.Value = 0;
            SpinEdit9.Value = 0;
            SpinEdit10.Value = 0;
            SpinEdit12.Value = 0;
            SpinEdit13.Value = 0;
            SpinEdit17.Value = 0;
            SpinEdit16.Value = 0;
            SpinEdit18.Value = 0;
            SpinEdit19.Value = 0;
            SpinEdit23.Value = 0;
            SpinEdit22.Value = 0;
            SpinEdit26.Value = 0;
            SpinEdit2.Value = 0;
            SpinEdit5.Value = 0;
            SpinEdit8.Value = 0;
            SpinEdit11.Value = 0;
            SpinEdit14.Value = 0;
            SpinEdit15.Value = 0;
            SpinEdit20.Value = 0;
            SpinEdit21.Value = 0;
            SpinEdit28.Value = 0;
            SpinEdit30.Value = 0;
            CheckBoxTeleport.Checked = false;// 传送 
            CheckBoxParalysis.Checked = false; // 麻痹
            CheckBoxRevival.Checked = false; // 复活
            CheckBoxMagicShield.Checked = false; // 护身
            CheckBoxUnParalysis.Checked = false; // 防麻痹
        }

        private void LoadSuitItem()
        {
            ListViewItem ListItem;
            int I;
            TSuitItem SuitItem;
            ListView1.Items.Clear();
            if (M2Share.SuitItemList.Count > 0)
            {
                for (I = 0; I < M2Share.SuitItemList.Count; I++)
                {
                    SuitItem = ((TSuitItem)(M2Share.SuitItemList[I]));
                    if (SuitItem != null)
                    {
                        ListItem = new ListViewItem();
                        ListItem.Text = (I).ToString();
                        ListItem.SubItems.Add(SuitItem.Note);
                        ListItem.SubItems.Add((SuitItem.ItemCount).ToString());
                        ListItem.SubItems.Add(SuitItem.Name);
                        ListItem.SubItems.Add((SuitItem.MaxHP).ToString() + "|" + (SuitItem.MaxMP).ToString() + "|" + (SuitItem.DC).ToString() + "|" + (SuitItem.MaxDC).ToString() + "|" + (SuitItem.MC).ToString() + "|" + (SuitItem.MaxMC).ToString() + "|" + (SuitItem.SC).ToString() + "|" + (SuitItem.MaxSC).ToString() + "|" + (SuitItem.AC).ToString() + "|" + (SuitItem.MaxAC).ToString() + "|" + (SuitItem.MAC).ToString() + "|" + (SuitItem.MaxMAC).ToString() + "|" + (SuitItem.HitPoint).ToString() + "|" + (SuitItem.SpeedPoint).ToString() + "|" + (SuitItem.HealthRecover).ToString() + "|" + (SuitItem.SpellRecover).ToString() + "|" + (SuitItem.RiskRate).ToString() + "|" + (SuitItem.btReserved).ToString() + "|" + (SuitItem.btReserved1).ToString() + "|" + (SuitItem.btReserved2).ToString() + "|" + (SuitItem.btReserved3).ToString() + "|" + (SuitItem.nEXPRATE).ToString() + "|" + (SuitItem.nPowerRate).ToString() + "|" + (SuitItem.nMagicRate).ToString() + "|" + (SuitItem.nSCRate).ToString() + "|" + (SuitItem.nACRate).ToString() + "|" + (SuitItem.nMACRate).ToString() + "|" + (SuitItem.nAntiMagic).ToString() + "|" + (SuitItem.nAntiPoison).ToString() + "|" + (SuitItem.nPoisonRecover).ToString());
                        ListView1.Items.Add(ListItem);
                    }
                }
            }
        }

        public void Open()
        {
            LoadSuitItem();
            LoadGlobalVal(); // 读取全局变量
            LoadGlobalAVal(); // 读取全局字符型变量
            this.ShowDialog();
        }

        //    public void ListView1Click(object sender, EventArgs e)
        //    {
        //        TSuitItem SuitItem;
        //        int nIndex;

        //        nIndex = ListView1.ItemIndex;
        //        if (nIndex < 0)
        //        {
        //            return;
        //        }
        //        if ((nIndex < 0) && (nIndex >= M2Share.SuitItemList.Count))
        //        {
        //            return;
        //        }
        //        SuitItem = ((TSuitItem)(M2Share.SuitItemList[nIndex]));
        //        Edit2.Text = SuitItem.Name;
        //        Edit1.Text = SuitItem.Note;
        //        SpinEdtMaxHP.Value = SuitItem.MaxHP;
        //        SpinEdtMaxMP.Value = SuitItem.MaxMP;
        //        SpinEdit3.Value = SuitItem.DC;
        //        SpinEdit4.Value = SuitItem.MaxDC;
        //        SpinEdit6.Value = SuitItem.MC;
        //        SpinEdit7.Value = SuitItem.MaxMC;
        //        SpinEdit9.Value = SuitItem.SC;
        //        SpinEdit10.Value = SuitItem.MaxSC;
        //        SpinEdit12.Value = SuitItem.AC;
        //        SpinEdit13.Value = SuitItem.MaxAC;
        //        SpinEdit17.Value = SuitItem.MAC;
        //        SpinEdit16.Value = SuitItem.MaxMAC;
        //        SpinEdit18.Value = SuitItem.HitPoint;
        //        SpinEdit19.Value = SuitItem.SpeedPoint;
        //        SpinEdit23.Value = SuitItem.HealthRecover;
        //        SpinEdit22.Value = SuitItem.SpellRecover;
        //        SpinEdit26.Value = SuitItem.RiskRate;
        //        SpinEdit2.Value = SuitItem.nEXPRATE;
        //        SpinEdit5.Value = SuitItem.nPowerRate;
        //        SpinEdit8.Value = SuitItem.nMagicRate;
        //        SpinEdit11.Value = SuitItem.nSCRate;
        //        SpinEdit14.Value = SuitItem.nACRate;
        //        SpinEdit15.Value = SuitItem.nMACRate;
        //        SpinEdit20.Value = SuitItem.nAntiMagic;
        //        SpinEdit21.Value = SuitItem.nAntiPoison;
        //        SpinEdit28.Value = SuitItem.nPoisonRecover;
        //        SpinEdit30.Value = SuitItem.ItemCount;
        //        SpinEdit24.Value = SuitItem.btReserved;
        //        // 吸血(虹吸)
        //        CheckBoxTeleport.Checked = SuitItem.boTeleport;
        //        // 传送  20080824
        //        CheckBoxParalysis.Checked = SuitItem.boParalysis;
        //        // 麻痹
        //        CheckBoxRevival.Checked = SuitItem.boRevival;
        //        // 复活
        //        CheckBoxMagicShield.Checked = SuitItem.boMagicShield;
        //        // 护身
        //        CheckBoxUnParalysis.Checked = SuitItem.boUnParalysis;
        //        // 防麻痹
        //        Button2.Enabled = true;
        //        Button3.Enabled = true;
        //    }

        //    public void Button1Click(object sender, EventArgs e)
        //    {
        //        TSuitItem SuitItem;
        //        if (Units.ViewList2.IsChar(Edit2.Text) <= 0)
        //        {
        //            System.Windows.Forms.MessageBox.Show("套装名字输入不正确,格式:XXX|XXX|！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
        //            Edit2.Focus();
        //            return;
        //        }
        //        SuitItem = new TSuitItem();
        //        SuitItem.ItemCount = SpinEdit30.Value;
        //        if (Edit1.Text != "")
        //        {
        //            SuitItem.Note = Edit1.Text;
        //        }
        //        else
        //        {
        //            SuitItem.Note = "????";
        //        }
        //        SuitItem.Name = Edit2.Text;
        //        SuitItem.MaxHP = SpinEdtMaxHP.Value;
        //        SuitItem.MaxMP = SpinEdtMaxMP.Value;
        //        SuitItem.DC = SpinEdit3.Value;
        //        // 攻击力
        //        SuitItem.MaxDC = SpinEdit4.Value;
        //        SuitItem.MC = SpinEdit6.Value;
        //        // 魔法
        //        SuitItem.MaxMC = SpinEdit7.Value;
        //        SuitItem.SC = SpinEdit9.Value;
        //        // 道术
        //        SuitItem.MaxSC = SpinEdit10.Value;
        //        SuitItem.AC = SpinEdit12.Value;
        //        // 防御
        //        SuitItem.MaxAC = SpinEdit13.Value;
        //        SuitItem.MAC = SpinEdit17.Value;
        //        // 魔防
        //        SuitItem.MaxMAC = SpinEdit16.Value;
        //        SuitItem.HitPoint = SpinEdit18.Value;
        //        // 精确度
        //        SuitItem.SpeedPoint = SpinEdit19.Value;
        //        // 敏捷度
        //        SuitItem.HealthRecover = SpinEdit23.Value;
        //        // 体力恢复
        //        SuitItem.SpellRecover = SpinEdit22.Value;
        //        // 魔法恢复
        //        SuitItem.RiskRate = SpinEdit26.Value;
        //        // 爆率机率
        //        SuitItem.btReserved = SpinEdit24.Value;
        //        // 吸血(虹吸)
        //        SuitItem.btReserved1 = SpinEdit25.Value;
        //        // 保留
        //        SuitItem.btReserved2 = SpinEdit27.Value;
        //        // 保留
        //        SuitItem.btReserved3 = SpinEdit29.Value;
        //        // 保留
        //        SuitItem.nEXPRATE = SpinEdit2.Value;
        //        // 经验倍数
        //        SuitItem.nPowerRate = SpinEdit5.Value;
        //        // 攻击倍数
        //        SuitItem.nMagicRate = SpinEdit8.Value;
        //        // 魔法倍数
        //        SuitItem.nSCRate = SpinEdit11.Value;
        //        // 道术倍数
        //        SuitItem.nACRate = SpinEdit14.Value;
        //        // 防御倍数
        //        SuitItem.nMACRate = SpinEdit15.Value;
        //        // 魔御倍数
        //        SuitItem.nAntiMagic = SpinEdit20.Value;
        //        // 魔法躲避
        //        SuitItem.nAntiPoison = SpinEdit21.Value;
        //        // 毒物躲避
        //        SuitItem.nPoisonRecover = SpinEdit28.Value;
        //        // 中毒恢复
        //        SuitItem.boTeleport = CheckBoxTeleport.Checked;
        //        // 传送  20080824
        //        SuitItem.boParalysis = CheckBoxParalysis.Checked;
        //        // 麻痹
        //        SuitItem.boRevival = CheckBoxRevival.Checked;
        //        // 复活
        //        SuitItem.boMagicShield = CheckBoxMagicShield.Checked;
        //        // 护身
        //        SuitItem.boUnParalysis = CheckBoxUnParalysis.Checked;
        //        // 防麻痹
        //        M2Share.SuitItemList.Add(SuitItem);
        //        LoadSuitItem();
        //        Button4.Enabled = true;
        //    }

        //    public void Button3Click(object sender, EventArgs e)
        //    {
        //        int nIndex;
        //        TSuitItem SuitItem;

        //        nIndex = ListView1.ItemIndex;
        //        if (nIndex < 0)
        //        {
        //            return;
        //        }
        //        if (Units.ViewList2.IsChar(Edit2.Text) <= 0)
        //        {
        //            System.Windows.Forms.MessageBox.Show("套装名字输入不正确,格式:XXX|XXX|！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
        //            Edit2.Focus();
        //            return;
        //        }
        //        if ((nIndex < 0) && (nIndex >= M2Share.SuitItemList.Count))
        //        {
        //            return;
        //        }
        //        SuitItem = ((TSuitItem)(M2Share.SuitItemList[nIndex]));
        //        SuitItem.ItemCount = SpinEdit30.Value;
        //        SuitItem.Note = Edit1.Text;
        //        SuitItem.Name = Edit2.Text;
        //        SuitItem.MaxHP = SpinEdtMaxHP.Value;
        //        SuitItem.MaxMP = SpinEdtMaxMP.Value;
        //        SuitItem.DC = SpinEdit3.Value;
        //        // 攻击力
        //        SuitItem.MaxDC = SpinEdit4.Value;
        //        SuitItem.MC = SpinEdit6.Value;
        //        // 魔法
        //        SuitItem.MaxMC = SpinEdit7.Value;
        //        SuitItem.SC = SpinEdit9.Value;
        //        // 道术
        //        SuitItem.MaxSC = SpinEdit10.Value;
        //        SuitItem.MaxAC = SpinEdit13.Value;
        //        // 防御
        //        SuitItem.AC = SpinEdit12.Value;
        //        SuitItem.MaxMAC = SpinEdit16.Value;
        //        // 魔防
        //        SuitItem.MAC = SpinEdit17.Value;
        //        SuitItem.HitPoint = SpinEdit18.Value;
        //        // 精确度
        //        SuitItem.SpeedPoint = SpinEdit19.Value;
        //        // 敏捷度
        //        SuitItem.HealthRecover = SpinEdit23.Value;
        //        // 体力恢复
        //        SuitItem.SpellRecover = SpinEdit22.Value;
        //        // 魔法恢复
        //        SuitItem.RiskRate = SpinEdit26.Value;
        //        // 爆率机率
        //        SuitItem.btReserved = SpinEdit24.Value;
        //        // 吸血(虹吸)
        //        SuitItem.btReserved1 = SpinEdit25.Value;
        //        // 保留
        //        SuitItem.btReserved2 = SpinEdit27.Value;
        //        // 保留
        //        SuitItem.btReserved3 = SpinEdit29.Value;
        //        // 保留
        //        SuitItem.nEXPRATE = SpinEdit2.Value;
        //        // 经验倍数
        //        SuitItem.nPowerRate = SpinEdit5.Value;
        //        // 攻击倍数
        //        SuitItem.nMagicRate = SpinEdit8.Value;
        //        // 魔法倍数
        //        SuitItem.nSCRate = SpinEdit11.Value;
        //        // 道术倍数
        //        SuitItem.nACRate = SpinEdit14.Value;
        //        // 防御倍数
        //        SuitItem.nMACRate = SpinEdit15.Value;
        //        // 魔御倍数
        //        SuitItem.nAntiMagic = SpinEdit20.Value;
        //        // 魔法躲避
        //        SuitItem.nAntiPoison = SpinEdit21.Value;
        //        // 毒物躲避
        //        SuitItem.nPoisonRecover = SpinEdit28.Value;
        //        // 中毒恢复
        //        SuitItem.boTeleport = CheckBoxTeleport.Checked;
        //        // 传送  20080824
        //        SuitItem.boParalysis = CheckBoxParalysis.Checked;
        //        // 麻痹
        //        SuitItem.boRevival = CheckBoxRevival.Checked;
        //        // 复活
        //        SuitItem.boMagicShield = CheckBoxMagicShield.Checked;
        //        // 护身
        //        SuitItem.boUnParalysis = CheckBoxUnParalysis.Checked;
        //        // 防麻痹
        //        LoadSuitItem();
        //        ClearEdt();
        //        Button4.Enabled = true;
        //        Button2.Enabled = false;
        //        Button3.Enabled = false;
        //    }

        //    public void Button2Click(object sender, EventArgs e)
        //    {
        //        int nIndex;

        //        nIndex = ListView1.ItemIndex;
        //        if (nIndex < 0)
        //        {
        //            return;
        //        }
        //        if ((nIndex < 0) && (nIndex >= M2Share.SuitItemList.Count))
        //        {
        //            return;
        //        }
        //        this.Dispose(((TSuitItem)(M2Share.SuitItemList[nIndex])));
        //        M2Share.SuitItemList.RemoveAt(nIndex);
        //        LoadSuitItem();
        //        ClearEdt();
        //        Button4.Enabled = true;
        //        Button2.Enabled = false;
        //        Button3.Enabled = false;
        //    }

        //    public void Button4Click(object sender, EventArgs e)
        //    {
        //        int I;
        //        string sFileName;
        //        List<string> SaveList;
        //        TSuitItem SuitItem;
        //        sFileName = M2Share.g_Config.sEnvirDir + "SuitItemList.txt";
        //        SaveList = new List<string>();
        //        if (M2Share.SuitItemList.Count > 0)
        //        {
        //            // 20080630
        //            for (I = 0; I < M2Share.SuitItemList.Count; I ++ )
        //            {
        //                SuitItem = ((TSuitItem)(M2Share.SuitItemList[I]));
        //                SaveList.Add((SuitItem.ItemCount).ToString() + " " + SuitItem.Note + " " + SuitItem.Name + " " + (SuitItem.MaxHP).ToString() + " " + (SuitItem.MaxMP).ToString() + " " + (SuitItem.DC).ToString() + " " + (SuitItem.MaxDC).ToString() + " " + (SuitItem.MC).ToString() + " " + (SuitItem.MaxMC).ToString() + " " + (SuitItem.SC).ToString() + " " + (SuitItem.MaxSC).ToString() + " " + (SuitItem.AC).ToString() + " " + (SuitItem.MaxAC).ToString() + " " + (SuitItem.MAC).ToString() + " " + (SuitItem.MaxMAC).ToString() + " " + (SuitItem.HitPoint).ToString() + " " + (SuitItem.SpeedPoint).ToString() + " " + (SuitItem.HealthRecover).ToString() + " " + (SuitItem.SpellRecover).ToString() + " " + (SuitItem.RiskRate).ToString() + " " + (SuitItem.btReserved).ToString() + " " + (SuitItem.btReserved1).ToString() + " " + (SuitItem.btReserved2).ToString() + " " + (SuitItem.btReserved3).ToString() + " " + (SuitItem.nEXPRATE).ToString() + " " + (SuitItem.nPowerRate).ToString() + " " + (SuitItem.nMagicRate).ToString() + " " + (SuitItem.nSCRate).ToString() + " " + (SuitItem.nACRate).ToString() + " " + (SuitItem.nMACRate).ToString() + " " + (SuitItem.nAntiMagic).ToString() + " " + (SuitItem.nAntiPoison).ToString() + " " + (SuitItem.nPoisonRecover).ToString() + " " + HUtil32.BoolToIntStr(SuitItem.boTeleport) + " " + HUtil32.BoolToIntStr(SuitItem.boParalysis) + " " + HUtil32.BoolToIntStr(SuitItem.boRevival) + " " + HUtil32.BoolToIntStr(SuitItem.boMagicShield) + " " + HUtil32.BoolToIntStr(SuitItem.boUnParalysis));
        //            }
        //        }

        //        SaveList.SaveToFile(sFileName);

        //        SaveList.Free;
        //        // 20080529
        //        Button2.Enabled = false;
        //        Button3.Enabled = false;
        //        Button4.Enabled = false;
        //        Button7.Enabled = true;
        //    }

        /// <summary>
        /// 读取全局数值变量
        /// </summary>
        private void LoadGlobalVal()
        {
            ListViewItem ListItem;
            ListView2.BeginUpdate();
            try
            {
                for (int I = M2Share.g_Config.GlobalVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalVal.GetUpperBound(0); I++)
                {
                    ListItem = new ListViewItem();
                    ListItem.Text = (I).ToString();
                    ListItem.SubItems.Add((M2Share.g_Config.GlobalVal[I]).ToString());
                    ListView2.Items.Add(ListItem);
                }
            }
            finally
            {
                ListView2.EndUpdate();
            }
        }


        // 读取全局字符型变量 
        private void LoadGlobalAVal()
        {
            ListViewItem ListItem;
            ListView3.BeginUpdate();
            try
            {
                for (int I = M2Share.g_Config.GlobalAVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalAVal.GetUpperBound(0); I++)
                {
                    ListItem = new ListViewItem();
                    ListItem.Text = (I).ToString();
                    ListItem.SubItems.Add(M2Share.g_Config.GlobalAVal[I]);
                    ListView3.Items.Add(ListItem);
                }
            }
            finally
            {
                ListView3.EndUpdate();
            }
        }

        //    public bool ListView2DblClick_IsNum(string str)
        //    {
        //        bool result;
        //        int i;
        //        for (i = 1; i <= str.Length; i ++ )
        //        {
        //            if (!(str[i] >= "0" && str[i]<= "9"))
        //            {
        //                result = false;
        //                return result;
        //            }
        //        }
        //        result = true;
        //        return result;
        //    }

        //    public void ListView2DblClick(object sender, EventArgs e)
        //    {
        //        ListViewItem ListItem;
        //        string str;

        //        ListItem = ListView2.Selected;


        //        str = InputBox("设置变量", "数值变量", ListItem.SubItems.Strings[0]);
        //        if (ListView2DblClick_IsNum(str))
        //        {

        //            ListItem.SubItems.Strings[0] = str;
        //            M2Share.g_Config.GlobalVal[ListItem.Index] = Convert.ToInt32(str);
        //        }
        //    }

        //    public void ListView3DblClick(object sender, EventArgs e)
        //    {
        //        ListViewItem ListItem;
        //        string str;

        //        ListItem = ListView3.Selected;


        //        str = InputBox("设置变量", "字符变量", ListItem.SubItems.Strings[0]);

        //        ListItem.SubItems.Strings[0] = str;
        //        M2Share.g_Config.GlobalAVal[ListItem.Index] = str;
        //    }

        //    public void Button5Click(object sender, EventArgs e)
        //    {
        //        int I;
        //        if (System.Windows.Forms.MessageBox.Show(("是否真的要清空所有数值变量的值?" as string), "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            try {
        //                for (I = M2Share.g_Config.GlobalVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalVal.GetUpperBound(0); I ++ )
        //                {
        //                    M2Share.g_Config.GlobalVal[I] = 0;

        //                    M2Share.Config.WriteInteger("Setup", "GlobalVal" + (I).ToString(), M2Share.g_Config.GlobalVal[I]);
        //                // 保存系统变量
        //                }
        //                ListView2.Items.Clear;
        //                LoadGlobalVal();
        //            }
        //            catch {
        //                M2Share.MainOutMessage("{异常} TfrmViewList2.Button5Click");
        //            }
        //        }
        //    }

        //    public void Button6Click(object sender, EventArgs e)
        //    {
        //        int I;
        //        if (System.Windows.Forms.MessageBox.Show(("是否真的要清空所有字符变量的值?" as string), "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            try {
        //                for (I = M2Share.g_Config.GlobalAVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalAVal.GetUpperBound(0); I ++ )
        //                {
        //                    M2Share.g_Config.GlobalAVal[I] = "";

        //                    M2Share.Config.WriteString("Setup", "GlobalStrVal" + (I).ToString(), M2Share.g_Config.GlobalAVal[I]);
        //                // 保存系统变量
        //                }
        //                ListView3.Items.Clear;
        //                LoadGlobalAVal();
        //            }
        //            catch {
        //                M2Share.MainOutMessage("{异常} TfrmViewList2.Button6Click");
        //            }
        //        }
        //    }

        //    public void Button7Click(object sender, EventArgs e)
        //    {
        //        LocalDB.Units.LocalDB.FrmDB.LoadSuitItemList();
        //        // 读取套装装备数据 20080506
        //        Button7.Enabled = false;
        //    }

        //    public void TabSheet3Show(Object Sender)
        //    {
        //        LoadRefineItem();
        //        // 读取粹练配置

        //    }

        //    // 读取全局字符型变量 20080426
        //    // 读取粹练配置
        //    private void LoadRefineItem()
        //    {
        //        int I;
        //        if (M2Share.g_RefineItemList.Count > 0)
        //        {

        //            RefineItemListBox.Clear;
        //            if (M2Share.g_RefineItemList.Count > 0)
        //            {
        //                // 20080630
        //                for (I = 0; I < M2Share.g_RefineItemList.Count; I ++ )
        //                {
        //                    RefineItemListBox.Items.Add(M2Share.g_RefineItemList[I]);
        //                }
        //            }
        //        }
        //    }

        //    // 读取粹练配置 20080508
        //    // 保存粹练配置
        //    private void SaveRefineItemInfo()
        //    {
        //        int I;
        //        int K;
        //        int J;
        //        ArrayList ItemList;
        //        string sFileName;
        //        string str;
        //        string str1;
        //        List<string> SaveList;
        //        TRefineItemInfo TRefineItemInfo;
        //        sFileName = M2Share.g_Config.sEnvirDir + "RefineItem.txt";
        //        SaveList = new List<string>();
        //        SaveList.Add(";配置文件");
        //        SaveList.Add(";淬炼后的物品 淬炼成功几率 失败还原几率 火云石是否消失 淬炼极品属性几率 淬炼极品属性设置");
        //        SaveList.Add(";[火云石碎片+魔龙冰晶+弩牌]");
        //        SaveList.Add(";光芒项链 60 0 0 1 2-6,2-6,0-5,0-5,4-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,");
        //        if (M2Share.g_RefineItemList.Count > 0)
        //        {
        //            // 20080630
        //            for (I = 0; I < M2Share.g_RefineItemList.Count; I ++ )
        //            {
        //                SaveList.Add("[" + M2Share.g_RefineItemList[I] + "]");

        //                ItemList = ((M2Share.g_RefineItemList.Values[I]) as ArrayList);
        //                if (ItemList.Count > 0)
        //                {
        //                    for (K = 0; K < ItemList.Count; K ++ )
        //                    {
        //                        TRefineItemInfo = ((TRefineItemInfo)(ItemList[K]));
        //                        str = TRefineItemInfo.sItemName + " " + (TRefineItemInfo.nRefineRate).ToString() + " " + (TRefineItemInfo.nReductionRate).ToString() + " " + HUtil32.BoolToStr(TRefineItemInfo.boDisappear) + " " + (TRefineItemInfo.nNeedRate).ToString();
        //                        str1 = "";
        //                        for (J = 0; J <= 13; J ++ )
        //                        {
        //                            if (str1 != "")
        //                            {
        //                                str1 = str1 + ",";
        //                            }
        //                            str1 = str1 + (TRefineItemInfo.nAttribute[J].nPoints).ToString() + "-" + (TRefineItemInfo.nAttribute[J].nDifficult).ToString();
        //                        }
        //                        str = str + " " + str1;
        //                        SaveList.Add(str);
        //                    }
        //                }
        //            }
        //        }

        //        SaveList.SaveToFile(sFileName);

        //        SaveList.Free;
        //    }

        //    public void RefineItemListBoxDblClick(object sender, EventArgs e)
        //    {
        //        string str;
        //        string str1;
        //        ArrayList ItemList;
        //        int I;
        //        int K;
        //        TRefineItemInfo TRefineItemInfo;
        //        ListViewItem ListItem;
        //        string str2;
        //        string str3;
        //        string str4;
        //        if (RefineItemListBox.SelectedIndex >= 0)
        //        {
        //            ListView4.Items.Clear;

        //            str = RefineItemListBox.Items.Strings[RefineItemListBox.SelectedIndex];
        //            // 取得材料名称:火云石+黑铁头盔+雷霆战戒
        //            Label78.Text = str;
        //            Units.ViewList2.GetBackRefineItemName(str, ref str2, ref str3, ref str4);
        //            Edit3.Text = str2;
        //            Edit4.Text = str3;
        //            Edit5.Text = str4;
        //            Button9.Enabled = true;
        //            Button10.Enabled = true;
        //            ItemList = null;
        //            // 20080522
        //            if (M2Share.g_RefineItemList.Count > 0)
        //            {
        //                // 20080630
        //                for (I = 0; I < M2Share.g_RefineItemList.Count; I ++ )
        //                {
        //                    if ((M2Share.g_RefineItemList[I]).ToLower().CompareTo((str).ToLower()) == 0)
        //                    {

        //                        ItemList = ((M2Share.g_RefineItemList.Values[I]) as ArrayList);
        //                        break;
        //                    }
        //                }
        //            }
        //            if (ItemList != null)
        //            {
        //                if (ItemList.Count > 0)
        //                {
        //                    for (I = 0; I < ItemList.Count; I ++ )
        //                    {
        //                        TRefineItemInfo = ((TRefineItemInfo)(ItemList[I]));

        //                        ListView4.Items.BeginUpdate;
        //                        try {
        //                            ListItem = ListView4.Items.Add();
        //                            ListItem.Text = TRefineItemInfo.sItemName;
        //                            ListItem.SubItems.Add((TRefineItemInfo.nRefineRate).ToString());
        //                            ListItem.SubItems.Add((TRefineItemInfo.nReductionRate).ToString());
        //                            if (TRefineItemInfo.boDisappear)
        //                            {
        //                                ListItem.SubItems.Add(0.ToString());
        //                            }
        //                            else
        //                            {
        //                                ListItem.SubItems.Add(1.ToString());
        //                            }
        //                            ListItem.SubItems.Add((TRefineItemInfo.nNeedRate).ToString());
        //                            str1 = "";
        //                            for (K = 0; K <= 13; K ++ )
        //                            {
        //                                if (str1 != "")
        //                                {
        //                                    str1 = str1 + ",";
        //                                }
        //                                str1 = str1 + (TRefineItemInfo.nAttribute[K].nPoints).ToString() + "-" + (TRefineItemInfo.nAttribute[K].nDifficult).ToString();
        //                            }
        //                            ListItem.SubItems.Add(str1);
        //                        } finally {

        //                            ListView4.Items.EndUpdate;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    // 增加粹练材料
        //    public void Button8Click(object sender, EventArgs e)
        //    {
        //        ArrayList List28;
        //        if (Units.ViewList2.IsRefineItemInfo(Edit3.Text.Trim(), Edit4.Text.Trim(), Edit5.Text.Trim()))
        //        {
        //            List28 = new ArrayList();
        //            if (List28 != null)
        //            {
        //                M2Share.g_RefineItemList.Add(Edit3.Text.Trim() + "+" + Edit4.Text.Trim() + "+" + Edit5.Text.Trim(), List28);
        //                RefineItemListBox.Items.Add(Edit3.Text.Trim() + "+" + Edit4.Text.Trim() + "+" + Edit5.Text.Trim());
        //                Button11.Enabled = true;
        //                Edit3.Text = "";
        //                Edit4.Text = "";
        //                Edit5.Text = "";
        //                Label78.Text = "";
        //            }
        //        }
        //        else
        //        {
        //            System.Windows.Forms.MessageBox.Show("此物品粹练配方已存在！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.OK);
        //        }
        //    }

        //    // 修改粹练材料
        //    public void Button9Click(object sender, EventArgs e)
        //    {
        //        if (RefineItemListBox.SelectedIndex >= 0)
        //        {
        //            if (Units.ViewList2.IsRefineItemInfo(Edit3.Text.Trim(), Edit4.Text.Trim(), Edit5.Text.Trim()))
        //            {
        //                M2Share.g_RefineItemList[RefineItemListBox.SelectedIndex] = Edit3.Text.Trim() + "+" + Edit4.Text.Trim() + "+" + Edit5.Text.Trim();
        //                Button11.Enabled = true;
        //                Button10.Enabled = false;
        //                Edit3.Text = "";
        //                Edit4.Text = "";
        //                Edit5.Text = "";
        //                Label78.Text = "";
        //                LoadRefineItem();
        //            // 读取粹练配置
        //            }
        //            else
        //            {
        //                System.Windows.Forms.MessageBox.Show("此物品粹练配方已存在！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.OK);
        //            }
        //        }
        //    }

        //    public void Button10Click(object sender, EventArgs e)
        //    {
        //        if (RefineItemListBox.SelectedIndex >= 0)
        //        {
        //            M2Share.g_RefineItemList.Remove(RefineItemListBox.SelectedIndex);
        //            Button9.Enabled = false;
        //            Button11.Enabled = true;
        //            Edit3.Text = "";
        //            Edit4.Text = "";
        //            Edit5.Text = "";
        //            Label78.Text = "";

        //            RefineItemListBox.DeleteSelected;
        //        }
        //    }

        //    public void Button11Click(object sender, EventArgs e)
        //    {
        //        SaveRefineItemInfo();
        //        Button9.Enabled = false;
        //        Button10.Enabled = false;
        //        Button11.Enabled = false;
        //        Edit3.Text = "";
        //        Edit4.Text = "";
        //        Edit5.Text = "";
        //        Label78.Text = "";
        //    }

        //    public void ListView4Click(object sender, EventArgs e)
        //    {
        //        ListViewItem ListItem;
        //        string s18;
        //        string n1;
        //        string n11;
        //        string n2;
        //        string n22;
        //        string n3;
        //        string n33;
        //        string n4;
        //        string n44;
        //        string n5;
        //        string n55;
        //        string n6;
        //        string n66;
        //        string n7;
        //        string n77;
        //        string n8;
        //        string n88;
        //        string n9;
        //        string n99;
        //        string nA;
        //        string nAA;
        //        string nB;
        //        string nBB;
        //        string nC;
        //        string nCC;
        //        string nD;
        //        string nDD;
        //        string nE;
        //        string nEE;

        //        if (ListView4.ItemIndex >= 0)
        //        {

        //            ListItem = ListView4.Items[ListView4.ItemIndex];
        //            Edit6.Text = ListItem.Text;

        //            SpinEdit1.Value = HUtil32.Str_ToInt(ListItem.SubItems.Strings[0], 0);

        //            SpinEdit31.Value = HUtil32.Str_ToInt(ListItem.SubItems.Strings[1], 0);

        //            SpinEdit32.Value = HUtil32.Str_ToInt(ListItem.SubItems.Strings[2], 0);

        //            SpinEdit33.Value = HUtil32.Str_ToInt(ListItem.SubItems.Strings[3], 0);

        //            s18 = ListItem.SubItems.Strings[4];
        //            s18 = HUtil32.GetValidStr3(s18, ref n1, new string[] {"-", ",", "\09"});
        //            // 各属性值及难度
        //            s18 = HUtil32.GetValidStr3(s18, ref n11, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n2, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n22, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n3, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n33, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n4, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n44, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n5, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n55, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n6, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n66, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n7, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n77, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n8, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n88, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n9, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref n99, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nA, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nAA, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nB, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nBB, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nC, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nCC, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nD, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nDD, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nE, new string[] {"-", ",", "\09"});
        //            s18 = HUtil32.GetValidStr3(s18, ref nEE, new string[] {"-", ",", "\09"});
        //            SpinEdit34.Value = HUtil32.Str_ToInt(n1.Trim(), 0);
        //            SpinEdit35.Value = HUtil32.Str_ToInt(n11.Trim(), 0);
        //            SpinEdit36.Value = HUtil32.Str_ToInt(n2.Trim(), 0);
        //            SpinEdit49.Value = HUtil32.Str_ToInt(n22.Trim(), 0);
        //            SpinEdit37.Value = HUtil32.Str_ToInt(n3.Trim(), 0);
        //            SpinEdit50.Value = HUtil32.Str_ToInt(n33.Trim(), 0);
        //            SpinEdit38.Value = HUtil32.Str_ToInt(n4.Trim(), 0);
        //            SpinEdit51.Value = HUtil32.Str_ToInt(n44.Trim(), 0);
        //            SpinEdit40.Value = HUtil32.Str_ToInt(n5.Trim(), 0);
        //            SpinEdit52.Value = HUtil32.Str_ToInt(n55.Trim(), 0);
        //            SpinEdit41.Value = HUtil32.Str_ToInt(n6.Trim(), 0);
        //            SpinEdit53.Value = HUtil32.Str_ToInt(n66.Trim(), 0);
        //            SpinEdit42.Value = HUtil32.Str_ToInt(n7.Trim(), 0);
        //            SpinEdit54.Value = HUtil32.Str_ToInt(n77.Trim(), 0);
        //            SpinEdit39.Value = HUtil32.Str_ToInt(n8.Trim(), 0);
        //            SpinEdit55.Value = HUtil32.Str_ToInt(n88.Trim(), 0);
        //            SpinEdit43.Value = HUtil32.Str_ToInt(n9.Trim(), 0);
        //            SpinEdit56.Value = HUtil32.Str_ToInt(n99.Trim(), 0);
        //            SpinEdit44.Value = HUtil32.Str_ToInt(nA.Trim(), 0);
        //            SpinEdit57.Value = HUtil32.Str_ToInt(nAA.Trim(), 0);
        //            SpinEdit45.Value = HUtil32.Str_ToInt(nB.Trim(), 0);
        //            SpinEdit58.Value = HUtil32.Str_ToInt(nBB.Trim(), 0);
        //            SpinEdit46.Value = HUtil32.Str_ToInt(nC.Trim(), 0);
        //            SpinEdit59.Value = HUtil32.Str_ToInt(nCC.Trim(), 0);
        //            SpinEdit47.Value = HUtil32.Str_ToInt(nD.Trim(), 0);
        //            SpinEdit60.Value = HUtil32.Str_ToInt(nDD.Trim(), 0);
        //            SpinEdit48.Value = HUtil32.Str_ToInt(nE.Trim(), 0);
        //            SpinEdit61.Value = HUtil32.Str_ToInt(nEE.Trim(), 0);
        //            Button13.Enabled = true;
        //            Button14.Enabled = true;
        //        }
        //    }

        //    private void ClearEdt1()
        //    {
        //        Edit6.Text = "";
        //        SpinEdit1.Value = 0;
        //        SpinEdit31.Value = 0;
        //        SpinEdit32.Value = 0;
        //        SpinEdit33.Value = 0;
        //        SpinEdit34.Value = 0;
        //        SpinEdit35.Value = 0;
        //        SpinEdit36.Value = 0;
        //        SpinEdit49.Value = 0;
        //        SpinEdit37.Value = 0;
        //        SpinEdit50.Value = 0;
        //        SpinEdit38.Value = 0;
        //        SpinEdit51.Value = 0;
        //        SpinEdit40.Value = 0;
        //        SpinEdit52.Value = 0;
        //        SpinEdit41.Value = 0;
        //        SpinEdit53.Value = 0;
        //        SpinEdit42.Value = 0;
        //        SpinEdit54.Value = 0;
        //        SpinEdit39.Value = 0;
        //        SpinEdit55.Value = 0;
        //        SpinEdit43.Value = 0;
        //        SpinEdit56.Value = 0;
        //        SpinEdit44.Value = 0;
        //        SpinEdit57.Value = 0;
        //        SpinEdit45.Value = 0;
        //        SpinEdit58.Value = 0;
        //        SpinEdit46.Value = 0;
        //        SpinEdit59.Value = 0;
        //        SpinEdit47.Value = 0;
        //        SpinEdit60.Value = 0;
        //        SpinEdit48.Value = 0;
        //        SpinEdit61.Value = 0;
        //    }

        //    public void Button12Click(object sender, EventArgs e)
        //    {
        //        int I;
        //        int k;
        //        ArrayList ItemList;
        //        string sItemName;
        //        string sItemName1;
        //        string sItemName2;
        //        TRefineItemInfo TRefineItemInfo;
        //        bool boAdd;
        //        string str1;
        //        ListViewItem ListItem;
        //        if (Label78.Text != "")
        //        {
        //            boAdd = true;
        //            Units.ViewList2.GetBackRefineItemName(Label78.Text, ref sItemName, ref sItemName1, ref sItemName2);
        //            ItemList = M2Share.GetRefineItemInfo(sItemName, sItemName1, sItemName2);
        //            if (ItemList.Count > 0)
        //            {
        //                // 20080630
        //                for (I = 0; I < ItemList.Count; I ++ )
        //                {
        //                    TRefineItemInfo = ((TRefineItemInfo)(ItemList[I]));
        //                    if ((Edit6.Text.Trim()).ToLower().CompareTo((TRefineItemInfo.sItemName).ToLower()) == 0)
        //                    {
        //                        boAdd = false;
        //                        // 不能存在同名物品
        //                        break;
        //                    }
        //                }
        //            }
        //            if (boAdd)
        //            {
        //                TRefineItemInfo = new TRefineItemInfo();
        //                TRefineItemInfo.sItemName = Edit6.Text.Trim();
        //                TRefineItemInfo.nRefineRate = SpinEdit1.Value;
        //                TRefineItemInfo.nReductionRate = SpinEdit31.Value;
        //                TRefineItemInfo.boDisappear = SpinEdit32.Value == 0;
        //                // 0-减持久 1-消失
        //                TRefineItemInfo.nNeedRate = SpinEdit33.Value;
        //                TRefineItemInfo.nAttribute[0].nPoints = SpinEdit34.Value;
        //                TRefineItemInfo.nAttribute[0].nDifficult = SpinEdit35.Value;
        //                TRefineItemInfo.nAttribute[1].nPoints = SpinEdit36.Value;
        //                TRefineItemInfo.nAttribute[1].nDifficult = SpinEdit49.Value;
        //                TRefineItemInfo.nAttribute[2].nPoints = SpinEdit37.Value;
        //                TRefineItemInfo.nAttribute[2].nDifficult = SpinEdit50.Value;
        //                TRefineItemInfo.nAttribute[3].nPoints = SpinEdit38.Value;
        //                TRefineItemInfo.nAttribute[3].nDifficult = SpinEdit51.Value;
        //                TRefineItemInfo.nAttribute[4].nPoints = SpinEdit40.Value;
        //                TRefineItemInfo.nAttribute[4].nDifficult = SpinEdit52.Value;
        //                TRefineItemInfo.nAttribute[5].nPoints = SpinEdit41.Value;
        //                TRefineItemInfo.nAttribute[5].nDifficult = SpinEdit53.Value;
        //                TRefineItemInfo.nAttribute[6].nPoints = SpinEdit42.Value;
        //                TRefineItemInfo.nAttribute[6].nDifficult = SpinEdit54.Value;
        //                TRefineItemInfo.nAttribute[7].nPoints = SpinEdit39.Value;
        //                TRefineItemInfo.nAttribute[7].nDifficult = SpinEdit55.Value;
        //                TRefineItemInfo.nAttribute[8].nPoints = SpinEdit43.Value;
        //                TRefineItemInfo.nAttribute[8].nDifficult = SpinEdit56.Value;
        //                TRefineItemInfo.nAttribute[9].nPoints = SpinEdit44.Value;
        //                TRefineItemInfo.nAttribute[9].nDifficult = SpinEdit57.Value;
        //                TRefineItemInfo.nAttribute[10].nPoints = SpinEdit45.Value;
        //                TRefineItemInfo.nAttribute[10].nDifficult = SpinEdit58.Value;
        //                TRefineItemInfo.nAttribute[11].nPoints = SpinEdit46.Value;
        //                TRefineItemInfo.nAttribute[11].nDifficult = SpinEdit59.Value;
        //                TRefineItemInfo.nAttribute[12].nPoints = SpinEdit47.Value;
        //                TRefineItemInfo.nAttribute[12].nDifficult = SpinEdit60.Value;
        //                TRefineItemInfo.nAttribute[13].nPoints = SpinEdit48.Value;
        //                TRefineItemInfo.nAttribute[13].nDifficult = SpinEdit61.Value;
        //                ItemList.Add(TRefineItemInfo);

        //                ListView4.Items.BeginUpdate;
        //                try {
        //                    ListItem = ListView4.Items.Add();
        //                    ListItem.Text = TRefineItemInfo.sItemName;
        //                    ListItem.SubItems.Add((TRefineItemInfo.nRefineRate).ToString());
        //                    ListItem.SubItems.Add((TRefineItemInfo.nReductionRate).ToString());
        //                    if (TRefineItemInfo.boDisappear)
        //                    {
        //                        ListItem.SubItems.Add(0.ToString());
        //                    }
        //                    else
        //                    {
        //                        ListItem.SubItems.Add(1.ToString());
        //                    }
        //                    ListItem.SubItems.Add((TRefineItemInfo.nNeedRate).ToString());
        //                    str1 = "";
        //                    for (k = 0; k <= 13; k ++ )
        //                    {
        //                        if (str1 != "")
        //                        {
        //                            str1 = str1 + ",";
        //                        }
        //                        str1 = str1 + (TRefineItemInfo.nAttribute[k].nPoints).ToString() + "-" + (TRefineItemInfo.nAttribute[k].nDifficult).ToString();
        //                    }
        //                    ListItem.SubItems.Add(str1);
        //                } finally {

        //                    ListView4.Items.EndUpdate;
        //                }
        //                Button13.Enabled = false;
        //                Button14.Enabled = false;
        //                Button15.Enabled = true;
        //                ClearEdt1();
        //            }
        //            else
        //            {
        //                System.Windows.Forms.MessageBox.Show("该配方已存在此物品,不能再重复增加！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.OK);
        //            }
        //        }
        //        else
        //        {
        //            System.Windows.Forms.MessageBox.Show("请从粹练材料列表中选择要增加物品的配方名！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.OK);
        //        }
        //    }

        //    public void Button13Click(object sender, EventArgs e)
        //    {
        //        int I;
        //        int K;
        //        ArrayList ItemList;
        //        string sItemName;
        //        string sItemName1;
        //        string sItemName2;
        //        TRefineItemInfo TRefineItemInfo;
        //        string str;
        //        string str1;
        //        ListViewItem ListItem;

        //        if (ListView4.ItemIndex >= 0)
        //        {
        //            if (Label78.Text != "")
        //            {


        //                str = ListView4.Items[ListView4.ItemIndex].Caption;
        //                // 物品名称
        //                if ((str != ""))
        //                {
        //                    Units.ViewList2.GetBackRefineItemName(Label78.Text, ref sItemName, ref sItemName1, ref sItemName2);
        //                    ItemList = M2Share.GetRefineItemInfo(sItemName, sItemName1, sItemName2);
        //                    if (ItemList.Count > 0)
        //                    {
        //                        for (I = 0; I < ItemList.Count; I ++ )
        //                        {
        //                            TRefineItemInfo = ((TRefineItemInfo)(ItemList[I]));
        //                            if ((str).ToLower().CompareTo((TRefineItemInfo.sItemName).ToLower()) == 0)
        //                            {
        //                                TRefineItemInfo.nRefineRate = SpinEdit1.Value;
        //                                TRefineItemInfo.nReductionRate = SpinEdit31.Value;
        //                                TRefineItemInfo.boDisappear = SpinEdit32.Value == 0;
        //                                // 0-减持久 1-消失
        //                                TRefineItemInfo.nNeedRate = SpinEdit33.Value;
        //                                TRefineItemInfo.nAttribute[0].nPoints = SpinEdit34.Value;
        //                                TRefineItemInfo.nAttribute[0].nDifficult = SpinEdit35.Value;
        //                                TRefineItemInfo.nAttribute[1].nPoints = SpinEdit36.Value;
        //                                TRefineItemInfo.nAttribute[1].nDifficult = SpinEdit49.Value;
        //                                TRefineItemInfo.nAttribute[2].nPoints = SpinEdit37.Value;
        //                                TRefineItemInfo.nAttribute[2].nDifficult = SpinEdit50.Value;
        //                                TRefineItemInfo.nAttribute[3].nPoints = SpinEdit38.Value;
        //                                TRefineItemInfo.nAttribute[3].nDifficult = SpinEdit51.Value;
        //                                TRefineItemInfo.nAttribute[4].nPoints = SpinEdit40.Value;
        //                                TRefineItemInfo.nAttribute[4].nDifficult = SpinEdit52.Value;
        //                                TRefineItemInfo.nAttribute[5].nPoints = SpinEdit41.Value;
        //                                TRefineItemInfo.nAttribute[5].nDifficult = SpinEdit53.Value;
        //                                TRefineItemInfo.nAttribute[6].nPoints = SpinEdit42.Value;
        //                                TRefineItemInfo.nAttribute[6].nDifficult = SpinEdit54.Value;
        //                                TRefineItemInfo.nAttribute[7].nPoints = SpinEdit39.Value;
        //                                TRefineItemInfo.nAttribute[7].nDifficult = SpinEdit55.Value;
        //                                TRefineItemInfo.nAttribute[8].nPoints = SpinEdit43.Value;
        //                                TRefineItemInfo.nAttribute[8].nDifficult = SpinEdit56.Value;
        //                                TRefineItemInfo.nAttribute[9].nPoints = SpinEdit44.Value;
        //                                TRefineItemInfo.nAttribute[9].nDifficult = SpinEdit57.Value;
        //                                TRefineItemInfo.nAttribute[10].nPoints = SpinEdit45.Value;
        //                                TRefineItemInfo.nAttribute[10].nDifficult = SpinEdit58.Value;
        //                                TRefineItemInfo.nAttribute[11].nPoints = SpinEdit46.Value;
        //                                TRefineItemInfo.nAttribute[11].nDifficult = SpinEdit59.Value;
        //                                TRefineItemInfo.nAttribute[12].nPoints = SpinEdit47.Value;
        //                                TRefineItemInfo.nAttribute[12].nDifficult = SpinEdit60.Value;
        //                                TRefineItemInfo.nAttribute[13].nPoints = SpinEdit48.Value;
        //                                TRefineItemInfo.nAttribute[13].nDifficult = SpinEdit61.Value;

        //                                ListItem = ListView4.Items[ListView4.ItemIndex];
        //                                ListItem.Text = TRefineItemInfo.sItemName;

        //                                ListItem.SubItems.Strings[0] = (TRefineItemInfo.nRefineRate).ToString();

        //                                ListItem.SubItems.Strings[1] = (TRefineItemInfo.nReductionRate).ToString();

        //                                ListItem.SubItems.Strings[2] = (SpinEdit32.Value).ToString();

        //                                ListItem.SubItems.Strings[3] = (TRefineItemInfo.nNeedRate).ToString();
        //                                str1 = "";
        //                                for (K = 0; K <= 13; K ++ )
        //                                {
        //                                    if (str1 != "")
        //                                    {
        //                                        str1 = str1 + ",";
        //                                    }
        //                                    str1 = str1 + (TRefineItemInfo.nAttribute[K].nPoints).ToString() + "-" + (TRefineItemInfo.nAttribute[K].nDifficult).ToString();
        //                                }

        //                                ListItem.SubItems.Strings[4] = str1;
        //                                Button13.Enabled = false;
        //                                Button14.Enabled = false;
        //                                Button15.Enabled = true;
        //                                ClearEdt1();
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                System.Windows.Forms.MessageBox.Show("请从粹练材料列表中选择要修改物品的配方名！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.OK);
        //            }
        //        }
        //    }

        //    public void Button14Click(object sender, EventArgs e)
        //    {
        //        int I;
        //        ArrayList ItemList;
        //        string sItemName;
        //        string sItemName1;
        //        string sItemName2;
        //        TRefineItemInfo TRefineItemInfo;
        //        string str;

        //        if (ListView4.ItemIndex >= 0)
        //        {
        //            if (Label78.Text != "")
        //            {


        //                str = ListView4.Items[ListView4.ItemIndex].Caption;
        //                // 物品名称

        //                ListView4.Items.BeginUpdate;
        //                try {

        //                    ListView4.DeleteSelected;
        //                } finally {

        //                    ListView4.Items.EndUpdate;
        //                }
        //                if (str != "")
        //                {
        //                    Units.ViewList2.GetBackRefineItemName(Label78.Text, ref sItemName, ref sItemName1, ref sItemName2);
        //                    ItemList = M2Share.GetRefineItemInfo(sItemName, sItemName1, sItemName2);
        //                    if (ItemList.Count > 0)
        //                    {
        //                        for (I = 0; I < ItemList.Count; I ++ )
        //                        {
        //                            TRefineItemInfo = ((TRefineItemInfo)(ItemList[I]));
        //                            if ((str).ToLower().CompareTo((TRefineItemInfo.sItemName).ToLower()) == 0)
        //                            {
        //                                ItemList.RemoveAt(I);
        //                                Button13.Enabled = false;
        //                                Button14.Enabled = false;
        //                                Button15.Enabled = true;
        //                                ClearEdt1();
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                System.Windows.Forms.MessageBox.Show("请从粹练材料列表中选择要删除物品的配方名！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question + System.Windows.Forms.MessageBoxButtons.OK);
        //            }
        //        }
        //    }

        //    public void Button15Click(object sender, EventArgs e)
        //    {
        //        SaveRefineItemInfo();
        //        Button13.Enabled = false;
        //        Button14.Enabled = false;
        //        Button15.Enabled = false;
        //    }

        //    // 保存粹练配置
        //    // ------------------------自定义命令---------------------------------
        //    private bool InCommandListOfName(string sCommandName)
        //    {
        //        bool result;
        //        int I;
        //        result = false;
        //        if (ListBoxUserCommand.Items.Count > 0)
        //        {
        //            // 20080629
        //            for (I = 0; I < ListBoxUserCommand.Items.Count; I ++ )
        //            {

        //                if ((sCommandName).ToLower().CompareTo((ListBoxUserCommand.Items.Strings[I]).ToLower()) == 0)
        //                {
        //                    result = true;
        //                    break;
        //                }
        //            }
        //        }
        //        return result;
        //    }

        //    private bool InCommandListOfIndex(int nIndex)
        //    {
        //        bool result;
        //        int I;
        //        result = false;
        //        if (ListBoxUserCommand.Items.Count > 0)
        //        {
        //            // 20080629
        //            for (I = 0; I < ListBoxUserCommand.Items.Count; I ++ )
        //            {

        //                if (nIndex == ((int)ListBoxUserCommand.Items.Objects[I]))
        //                {
        //                    result = true;
        //                    break;
        //                }
        //            }
        //        }
        //        return result;
        //    }

        //    public void ButtonUserCommandAddClick(object sender, EventArgs e)
        //    {
        //        string sCommandName;
        //        int nCommandIndex;
        //        sCommandName = EditCommandName.Text.Trim();
        //        nCommandIndex = SpinEditCommandIdx.Value;
        //        if (sCommandName == "")
        //        {
        //            System.Windows.Forms.MessageBox.Show("请输入命令！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }
        //        if (InCommandListOfName(sCommandName))
        //        {
        //            System.Windows.Forms.MessageBox.Show("输入的命令已经存在，请选择其他命令！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }
        //        if (InCommandListOfIndex(nCommandIndex))
        //        {
        //            System.Windows.Forms.MessageBox.Show("输入的命令编号已经存在，请选择其他命令编号！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }

        //        ListBoxUserCommand.Items.AddObject(sCommandName, ((nCommandIndex) as Object));
        //    }

        //    public void ButtonUserCommandDelClick(object sender, EventArgs e)
        //    {
        //        if (System.Windows.Forms.MessageBox.Show("是否确认删除此命令？", "确认信息", System.Windows.Forms.MessageBoxButtons.YesNo + System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            try {

        //                ListBoxUserCommand.DeleteSelected;
        //            }
        //            catch {
        //            }
        //        }
        //    }

        //    public void ButtonUserCommandChgClick(object sender, EventArgs e)
        //    {
        //        string sCommandName;
        //        int nCommandIndex;
        //        int nItemIndex;
        //        sCommandName = EditCommandName.Text.Trim();
        //        nCommandIndex = SpinEditCommandIdx.Value;
        //        if (sCommandName == "")
        //        {
        //            System.Windows.Forms.MessageBox.Show("请输入命令！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }
        //        if (InCommandListOfName(sCommandName))
        //        {
        //            System.Windows.Forms.MessageBox.Show("你要修改的命令已经存在，请选择其他命令！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }
        //        if (InCommandListOfIndex(nCommandIndex))
        //        {
        //            System.Windows.Forms.MessageBox.Show("你要修改的命令编号已经存在，请选择其他命令编号！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }
        //        nItemIndex = ListBoxUserCommand.SelectedIndex;
        //        try {

        //            ListBoxUserCommand.Items.Strings[nItemIndex] = sCommandName;

        //            ListBoxUserCommand.Items.Objects[nItemIndex] = ((nCommandIndex) as Object);
        //            System.Windows.Forms.MessageBox.Show("修改完成！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //        }
        //        catch {
        //            System.Windows.Forms.MessageBox.Show("修改失败！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //        }
        //    }

        //    public void ButtonUserCommandSaveClick(object sender, EventArgs e)
        //    {
        //        string sFileName;
        //        int I;
        //        string sCommandName;
        //        int nCommandIndex;
        //        List<string> SaveList;
        //        ButtonUserCommandSave.Enabled = false;
        //        sFileName = ".\\UserCmd.txt";
        //        SaveList = new List<string>();
        //        SaveList.Add(";引擎插件配置文件");
        //        SaveList.Add(";命令名称\09对应编号");
        //        if (ListBoxUserCommand.Items.Count > 0)
        //        {
        //            // 20080629
        //            for (I = 0; I < ListBoxUserCommand.Items.Count; I ++ )
        //            {

        //                sCommandName = ListBoxUserCommand.Items.Strings[I];

        //                nCommandIndex = ((int)ListBoxUserCommand.Items.Objects[I]);
        //                SaveList.Add(sCommandName + "\09" + (nCommandIndex).ToString());
        //            }
        //        }

        //        SaveList.SaveToFile(sFileName);

        //        SaveList.Free;
        //        System.Windows.Forms.MessageBox.Show("保存完成！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //        ButtonUserCommandSave.Enabled = true;
        //    }

        //    public void ButtonLoadUserCommandListClick(object sender, EventArgs e)
        //    {
        //        ButtonLoadUserCommandList.Enabled = false;
        //        M2Share.LoadUserCmdList();
        //        ListBoxUserCommand.Items.Clear();

        //        ListBoxUserCommand.Items.AddStrings(M2Share.g_UserCmdList);
        //        System.Windows.Forms.MessageBox.Show("重新加载自定义命令列表完成！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //        ButtonLoadUserCommandList.Enabled = true;
        //    }

        //    public void TabSheet5Show(Object Sender)
        //    {
        //        ListBoxUserCommand.Items.Clear();

        //        ListBoxUserCommand.Items.AddStrings(M2Share.g_UserCmdList);
        //    }

        //    public void ListBoxUserCommandClick(object sender, EventArgs e)
        //    {
        //        try {

        //            EditCommandName.Text = ListBoxUserCommand.Items.Strings[ListBoxUserCommand.SelectedIndex];

        //            SpinEditCommandIdx.Value = ((int)ListBoxUserCommand.Items.Objects[ListBoxUserCommand.SelectedIndex]);
        //            ButtonUserCommandDel.Enabled = true;
        //            ButtonUserCommandChg.Enabled = true;
        //        }
        //        catch {
        //            EditCommandName.Text = "";
        //            SpinEditCommandIdx.Value = 0;
        //            ButtonUserCommandDel.Enabled = false;
        //            ButtonUserCommandChg.Enabled = false;
        //        }
        //    }

        //    // -------------------------禁止物品设置------------------------------
        //    private void DisallowSelAll(bool SelAll)
        //    {
        //        if (SelAll)
        //        {
        //            CheckBoxDisallowDrop.Checked = true;
        //            CheckBoxDisallowDeal.Checked = true;
        //            CheckBoxDisallowStorage.Checked = true;
        //            CheckBoxDisallowRepair.Checked = true;
        //            CheckBoxDisallowDropHint.Checked = true;
        //            CheckBoxDisallowOpenBoxsHint.Checked = true;
        //            CheckBoxDisallowNoDropItem.Checked = true;
        //            CheckBoxDisallowButchHint.Checked = true;
        //            CheckBoxDisallowHeroUse.Checked = true;
        //            CheckBoxDisallowPickUpItem.Checked = true;
        //            CheckBoxDieDropItems.Checked = true;
        //        }
        //        else
        //        {
        //            CheckBoxDisallowDrop.Checked = false;
        //            CheckBoxDisallowDeal.Checked = false;
        //            CheckBoxDisallowStorage.Checked = false;
        //            CheckBoxDisallowRepair.Checked = false;
        //            CheckBoxDisallowDropHint.Checked = false;
        //            CheckBoxDisallowOpenBoxsHint.Checked = false;
        //            CheckBoxDisallowNoDropItem.Checked = false;
        //            CheckBoxDisallowButchHint.Checked = false;
        //            CheckBoxDisallowHeroUse.Checked = false;
        //            CheckBoxDisallowPickUpItem.Checked = false;
        //            CheckBoxDieDropItems.Checked = false;
        //        }
        //    }

        //    private void RefLoadDisallowStdItems()
        //    {
        //        int I;
        //        TCheckItem CheckItem;
        //        string sItemName;
        //        TDisallowInfo DisallowInfo;
        //        try {
        //            if (ListBoxDisallow.Items.Count > 0)
        //            {
        //                for (I = 0; I < ListBoxDisallow.Items.Count; I ++ )
        //                {

        //                    this.Dispose(((TDisallowInfo)(ListBoxDisallow.Items.objects[I])));
        //                }
        //                ListBoxDisallow.Items.Clear();
        //            }
        //            if (M2Share.g_CheckItemList.Count > 0)
        //            {
        //                // 20080629
        //                for (I = 0; I < M2Share.g_CheckItemList.Count; I ++ )
        //                {
        //                    CheckItem = ((TCheckItem)(M2Share.g_CheckItemList[I]));
        //                    sItemName = CheckItem.szItemName;
        //                    DisallowInfo = new TDisallowInfo();
        //                    DisallowInfo.boDrop = CheckItem.boCanDrop;
        //                    DisallowInfo.boDeal = CheckItem.boCanDeal;
        //                    DisallowInfo.boStorage = CheckItem.boCanStorage;
        //                    DisallowInfo.boRepair = CheckItem.boCanRepair;
        //                    DisallowInfo.boDropHint = CheckItem.boCanDropHint;
        //                    DisallowInfo.boOpenBoxsHint = CheckItem.boCanOpenBoxsHint;
        //                    DisallowInfo.boNoDropItem = CheckItem.boCanNoDropItem;
        //                    DisallowInfo.boButchHint = CheckItem.boCanButchHint;
        //                    DisallowInfo.boHeroUse = CheckItem.boCanHeroUse;
        //                    DisallowInfo.boPickUpItem = CheckItem.boPickUpItem;
        //                    // 禁止捡起(除GM外) 20080611
        //                    DisallowInfo.boDieDropItems = CheckItem.boDieDropItems;
        //                    // 死亡掉落 20080614

        //                    ListBoxDisallow.AddItem(sItemName, ((DisallowInfo) as Object));
        //                }
        //            }
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.RefLoadDisallowStdItems");
        //        }
        //    }

        //    public void BtnDisallowSelAllClick(object sender, EventArgs e)
        //    {
        //        DisallowSelAll(true);
        //    }

        //    public void BtnDisallowCancelAllClick(object sender, EventArgs e)
        //    {
        //        DisallowSelAll(false);
        //    }

        //    public void ListBoxitemListClick(object sender, EventArgs e)
        //    {
        //        try {

        //            EditItemName.Text = ListBoxitemList.Items.Strings[ListBoxitemList.SelectedIndex];
        //            DisallowSelAll(false);
        //            BtnDisallowAdd.Enabled = true;
        //            BtnDisallowDel.Enabled = false;
        //            BtnDisallowChg.Enabled = false;
        //        }
        //        catch {
        //            EditItemName.Text = "";
        //            BtnDisallowAdd.Enabled = false;
        //        }
        //    }

        //    // Note: the original parameters are Object Sender, ref ushort Key, Keys Shift
        //    public void ListBoxitemListKeyDown(System.Object Sender, System.Windows.Forms.KeyEventArgs _e1)
        //    {
        //        string s;
        //        int I;
        //        if (Key == (ushort)"F")
        //        {
        //            if (new ArrayList(Shift).Contains(System.Windows.Forms.Keys.Control))
        //            {

        //                s = inputBox("查找物品", "请输入要查找的物品名字:", "");
        //                if (ListBoxitemList.Items.Count > 0)
        //                {
        //                    // 20080629
        //                    for (I = 0; I < ListBoxitemList.Items.Count; I ++ )
        //                    {

        //                        if ((ListBoxitemList.Items.Strings[I]).ToLower().CompareTo((s).ToLower()) == 0)
        //                        {
        //                            ListBoxitemList.SelectedIndex = I;
        //                            return;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    public void BtnDisallowAddClick(object sender, EventArgs e)
        //    {
        //        TDisallowInfo DisallowInfo;
        //        string sItemName;
        //        int I;
        //        try {
        //            sItemName = EditItemName.Text.Trim();
        //            if (ListBoxDisallow.Items.Count > 0)
        //            {
        //                // 20080629
        //                for (I = 0; I < ListBoxDisallow.Items.Count; I ++ )
        //                {

        //                    if ((ListBoxDisallow.Items.Strings[I]).ToLower().CompareTo((sItemName).ToLower()) == 0)
        //                    {
        //                        System.Windows.Forms.MessageBox.Show("此物品已在列表中！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
        //                        return;
        //                    }
        //                }
        //            }
        //            DisallowInfo = new TDisallowInfo();
        //            DisallowInfo.boDrop = CheckBoxDisallowDrop.Checked;
        //            // 禁止丢弃
        //            DisallowInfo.boDeal = CheckBoxDisallowDeal.Checked;
        //            // 禁止交易
        //            DisallowInfo.boStorage = CheckBoxDisallowStorage.Checked;
        //            // 禁止存仓
        //            DisallowInfo.boRepair = CheckBoxDisallowRepair.Checked;
        //            // 禁止修理
        //            DisallowInfo.boDropHint = CheckBoxDisallowDropHint.Checked;
        //            // 掉落提示
        //            DisallowInfo.boOpenBoxsHint = CheckBoxDisallowOpenBoxsHint.Checked;
        //            // 宝箱提示
        //            DisallowInfo.boNoDropItem = CheckBoxDisallowNoDropItem.Checked;
        //            // 永不爆出
        //            DisallowInfo.boButchHint = CheckBoxDisallowButchHint.Checked;
        //            // 挖取提示
        //            DisallowInfo.boHeroUse = CheckBoxDisallowHeroUse.Checked;
        //            // 禁止英雄使用
        //            DisallowInfo.boPickUpItem = CheckBoxDisallowPickUpItem.Checked;
        //            // 禁止捡起(除GM外) 20080611
        //            DisallowInfo.boDieDropItems = CheckBoxDieDropItems.Checked;
        //            // 死亡掉落 20080614

        //            ListBoxDisallow.AddItem(sItemName, ((DisallowInfo) as Object));
        //            BtnDisallowSave.Enabled = true;
        //        // Dispose(DisallowInfo);
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.BtnDisallowAddClick");
        //        }
        //    }

        //    public void BtnDisallowDelClick(object sender, EventArgs e)
        //    {
        //        try {

        //            ListBoxDisallow.DeleteSelected;
        //            BtnDisallowSave.Enabled = true;
        //        }
        //        catch {
        //            BtnDisallowSave.Enabled = false;
        //        }
        //    }

        //    public void BtnDisallowAddAllClick(object sender, EventArgs e)
        //    {
        //        TDisallowInfo DisallowInfo;
        //        int I;
        //        try {
        //            ListBoxDisallow.Items.Clear();
        //            if (ListBoxitemList.Items.Count > 0)
        //            {
        //                // 20080629
        //                for (I = 0; I < ListBoxitemList.Items.Count; I ++ )
        //                {
        //                    DisallowInfo = new TDisallowInfo();
        //                    DisallowInfo.boDrop = CheckBoxDisallowDrop.Checked;
        //                    // 禁止丢弃
        //                    DisallowInfo.boDeal = CheckBoxDisallowDeal.Checked;
        //                    // 禁止交易
        //                    DisallowInfo.boStorage = CheckBoxDisallowStorage.Checked;
        //                    // 禁止存仓
        //                    DisallowInfo.boRepair = CheckBoxDisallowRepair.Checked;
        //                    // 禁止修理
        //                    DisallowInfo.boDropHint = CheckBoxDisallowDropHint.Checked;
        //                    // 掉落提示
        //                    DisallowInfo.boOpenBoxsHint = CheckBoxDisallowOpenBoxsHint.Checked;
        //                    // 宝箱提示
        //                    DisallowInfo.boNoDropItem = CheckBoxDisallowNoDropItem.Checked;
        //                    // 永不爆出
        //                    DisallowInfo.boButchHint = CheckBoxDisallowButchHint.Checked;
        //                    // 挖取提示
        //                    DisallowInfo.boHeroUse = CheckBoxDisallowHeroUse.Checked;
        //                    // 禁止英雄使用
        //                    DisallowInfo.boPickUpItem = CheckBoxDisallowPickUpItem.Checked;
        //                    // 禁止捡起(除GM外) 20080611
        //                    DisallowInfo.boDieDropItems = CheckBoxDieDropItems.Checked;
        //                    // 死亡掉落 20080614

        //                    ListBoxDisallow.AddItem(ListBoxitemList.Items[I], ((DisallowInfo) as Object));
        //                }
        //            }
        //            BtnDisallowSave.Enabled = true;
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.BtnDisallowAddAllClick");
        //        }
        //    }

        //    public void BtnDisallowDelAllClick(object sender, EventArgs e)
        //    {
        //        ListBoxDisallow.Items.Clear();
        //        BtnDisallowSave.Enabled = true;
        //    }

        //    public void BtnDisallowChgClick(object sender, EventArgs e)
        //    {
        //        TDisallowInfo DisallowInfo;
        //        int nItemIndex;
        //        try {
        //            nItemIndex = ListBoxDisallow.SelectedIndex;
        //            DisallowInfo = new TDisallowInfo();
        //            DisallowInfo.boDrop = CheckBoxDisallowDrop.Checked;
        //            // 禁止丢弃
        //            DisallowInfo.boDeal = CheckBoxDisallowDeal.Checked;
        //            // 禁止交易
        //            DisallowInfo.boStorage = CheckBoxDisallowStorage.Checked;
        //            // 禁止存仓
        //            DisallowInfo.boRepair = CheckBoxDisallowRepair.Checked;
        //            // 禁止修理
        //            DisallowInfo.boDropHint = CheckBoxDisallowDropHint.Checked;
        //            // 掉落提示
        //            DisallowInfo.boOpenBoxsHint = CheckBoxDisallowOpenBoxsHint.Checked;
        //            // 宝箱提示
        //            DisallowInfo.boNoDropItem = CheckBoxDisallowNoDropItem.Checked;
        //            // 永不爆出
        //            DisallowInfo.boButchHint = CheckBoxDisallowButchHint.Checked;
        //            // 挖取提示
        //            DisallowInfo.boHeroUse = CheckBoxDisallowHeroUse.Checked;
        //            // 禁止英雄使用
        //            DisallowInfo.boPickUpItem = CheckBoxDisallowPickUpItem.Checked;
        //            // 禁止捡起(除GM外) 20080611
        //            DisallowInfo.boDieDropItems = CheckBoxDieDropItems.Checked;
        //            // 死亡掉落 20080614

        //            ListBoxDisallow.Items.Objects[nItemIndex] = ((DisallowInfo) as Object);
        //            BtnDisallowSave.Enabled = true;
        //            BtnDisallowChg.Enabled = false;
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.BtnDisallowChgClick");
        //        }
        //    }

        //    public void BtnDisallowSaveClick(object sender, EventArgs e)
        //    {
        //        int I;
        //        List<string> SaveList;
        //        string sFileName;
        //        string sLineText;
        //        string sItemName;
        //        string sCanDrop;
        //        string sCanDeal;
        //        string sCanStorage;
        //        string sCanRepair;
        //        string sCanDropHint;
        //        // 是否掉落提示
        //        string sCanOpenBoxsHint;
        //        // 是否开宝箱提示
        //        string sCanNoDropItem;
        //        // 是否永不暴出
        //        string sCanButchHint;
        //        // 是否挖取提示
        //        string sCanHeroUse;
        //        // 是否禁止英雄使用
        //        string sCanPickUpItem;
        //        // 是否禁止捡起(除GM外) 20080611
        //        string sCanDieDropItems;
        //        // 死亡掉落 20080614
        //        try {
        //            BtnDisallowSave.Enabled = false;
        //            sFileName = ".\\CheckItemList.txt";
        //            SaveList = new List<string>();
        //            SaveList.Add(";引擎插件禁止物品配置文件");
        //            SaveList.Add(";物品名称\09丢弃\09交易\09存仓\09修理\09掉落提示\09开宝箱提示\09永不暴出\09挖取提示");
        //            if (ListBoxDisallow.Items.Count > 0)
        //            {
        //                // 20080629
        //                for (I = 0; I < ListBoxDisallow.Items.Count; I ++ )
        //                {

        //                    sItemName = ListBoxDisallow.Items.Strings[I];

        //                    sCanDrop = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boDrop);

        //                    sCanDeal = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boDeal);

        //                    sCanStorage = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boStorage);

        //                    sCanRepair = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boRepair);

        //                    sCanDropHint = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boDropHint);

        //                    sCanOpenBoxsHint = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boOpenBoxsHint);

        //                    sCanNoDropItem = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boNoDropItem);

        //                    sCanButchHint = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boButchHint);

        //                    sCanHeroUse = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boHeroUse);

        //                    sCanPickUpItem = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boPickUpItem);
        //                    // 是否禁止捡起(除GM外) 20080611

        //                    sCanDieDropItems = HUtil32.BoolToIntStr(((TDisallowInfo)(ListBoxDisallow.Items.Objects[I])).boDieDropItems);
        //                    // 死亡掉落 20080614
        //                    // sCanDrop := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDrop));
        //                    // sCanDeal := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDeal));
        //                    // sCanStorage := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boStorage));
        //                    // sCanRepair := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boRepair));
        //                    // sCanDropHint := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDropHint));
        //                    // sCanOpenBoxsHint := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boOpenBoxsHint));
        //                    // sCanNoDropItem := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boNoDropItem));
        //                    // sCanButchHint := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boButchHint));
        //                    // sCanHeroUse := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boHeroUse));
        //                    // sCanPickUpItem := Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boPickUpItem));//是否禁止捡起(除GM外) 20080611
        //                    // sCanDieDropItems:= Inttostr(Integer(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDieDropItems));//死亡掉落 20080614
        //                    // sCanDrop := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDrop);
        //                    // sCanDeal := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDeal);
        //                    // sCanStorage := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boStorage);
        //                    // sCanRepair := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boRepair);
        //                    // sCanDropHint := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDropHint);
        //                    // sCanOpenBoxsHint := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boOpenBoxsHint);
        //                    // sCanNoDropItem := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boNoDropItem);
        //                    // sCanButchHint := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boButchHint);
        //                    // sCanHeroUse := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boHeroUse);
        //                    // sCanPickUpItem := BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boPickUpItem);//是否禁止捡起(除GM外) 20080611
        //                    // sCanDieDropItems:= BoolToStr(pTDisallowInfo(ListBoxDisallow.Items.Objects[I]).boDieDropItems);//死亡掉落 20080614
        //                    sLineText = sItemName + "\09" + sCanDrop + "\09" + sCanDeal + "\09" + sCanStorage + "\09" + sCanRepair + "\09" + sCanDropHint + "\09" + sCanOpenBoxsHint + "\09" + sCanNoDropItem + "\09" + sCanButchHint + "\09" + sCanHeroUse + "\09" + sCanPickUpItem + "\09" + sCanDieDropItems;
        //                    SaveList.Add(sLineText);
        //                }
        //            }

        //            SaveList.SaveToFile(sFileName);

        //            SaveList.Free;
        //            if (System.Windows.Forms.MessageBox.Show("此设置必须重新加载物品配置才能生效，是否重新加载？", "确认信息", System.Windows.Forms.MessageBoxButtons.YesNo + System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        //            {
        //                M2Share.LoadCheckItemList();
        //                RefLoadDisallowStdItems();
        //            }
        //            else
        //            {
        //                BtnDisallowSave.Enabled = true;
        //                return;
        //            }
        //            BtnDisallowSave.Enabled = false;
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.BtnDisallowSaveClick");
        //        }
        //    }

        //    public void TabSheet6Show(Object Sender)
        //    {
        //        int I;
        //        TStdItem StdItem;
        //        ListBoxitemList.Items.Clear();
        //        if (UserEngine.StdItemList != null)
        //        {
        //            if (UserEngine.StdItemList.Count > 0)
        //            {
        //                // 20080629
        //                for (I = 0; I < UserEngine.StdItemList.Count; I ++ )
        //                {
        //                    StdItem = ((TStdItem)(UserEngine.StdItemList[I]));
        //                    // ListBoxitemList.Items.AddObject(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), TObject(StdItem));
        //                    ListBoxitemList.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
        //                }
        //            }
        //        }
        //        RefLoadDisallowStdItems();
        //    }

        //    public void ListBoxDisallowClick(object sender, EventArgs e)
        //    {
        //        try {

        //            EditItemName.Text = ListBoxDisallow.Items.Strings[ListBoxDisallow.SelectedIndex];

        //            CheckBoxDisallowDrop.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boDrop;

        //            CheckBoxDisallowDeal.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boDeal;

        //            CheckBoxDisallowStorage.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boStorage;

        //            CheckBoxDisallowRepair.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boRepair;

        //            CheckBoxDisallowDropHint.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boDropHint;

        //            CheckBoxDisallowOpenBoxsHint.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boOpenBoxsHint;

        //            CheckBoxDisallowNoDropItem.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boNoDropItem;

        //            CheckBoxDisallowButchHint.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boButchHint;

        //            CheckBoxDisallowHeroUse.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boHeroUse;

        //            CheckBoxDisallowPickUpItem.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boPickUpItem;
        //            // 禁止捡起(除GM外) 20080611

        //            CheckBoxDieDropItems.Checked = ((TDisallowInfo)(ListBoxDisallow.Items.Objects[ListBoxDisallow.SelectedIndex])).boDieDropItems;
        //            // 死亡掉落 20080614
        //            BtnDisallowChg.Enabled = true;
        //            BtnDisallowDel.Enabled = true;
        //            BtnDisallowAdd.Enabled = false;
        //        }
        //        catch {
        //            EditItemName.Text = "";
        //            CheckBoxDisallowDrop.Checked = false;
        //            CheckBoxDisallowDeal.Checked = false;
        //            CheckBoxDisallowStorage.Checked = false;
        //            CheckBoxDisallowRepair.Checked = false;
        //            CheckBoxDisallowDropHint.Checked = false;
        //            CheckBoxDisallowOpenBoxsHint.Checked = false;
        //            CheckBoxDisallowNoDropItem.Checked = false;
        //            CheckBoxDisallowButchHint.Checked = false;
        //            CheckBoxDisallowHeroUse.Checked = false;
        //            CheckBoxDisallowPickUpItem.Checked = false;
        //        }
        //    }

        //    public void CheckBoxDisallowNoDropItemClick(object sender, EventArgs e)
        //    {
        //        CheckBoxDieDropItems.Checked = false;
        //    }

        //    public void CheckBoxDieDropItemsClick(object sender, EventArgs e)
        //    {
        //        CheckBoxDisallowNoDropItem.Checked = false;
        //    }

        //    public void FormShow(Object Sender)
        //    {
        //        PageControl1.SelectedIndex = 0;
        //    }

        //    // Note: the original parameters are Object Sender, ref bool CanClose
        //    public void FormCloseQuery(System.Object Sender, System.ComponentModel.CancelEventArgs _e1)
        //    {
        //        int I;
        //        try {
        //            if (ListBoxDisallow.Items.Count > 0)
        //            {
        //                for (I = 0; I < ListBoxDisallow.Items.Count; I ++ )
        //                {

        //                    this.Dispose(((TDisallowInfo)(ListBoxDisallow.Items.objects[I])));
        //                }
        //            }
        //        }
        //        catch {
        //        }
        //    }

        //    // --------------------------消息过滤------------------
        //    private bool InFilterMsgList(string sFilterMsg)
        //    {
        //        bool result;
        //        int I;
        //        ListViewItem ListItem;
        //        result = false;
        //        try {

        //            ListViewMsgFilter.Items.BeginUpdate;
        //            try {
        //                if (ListViewMsgFilter.Items.Count > 0)
        //                {
        //                    // 20080629
        //                    for (I = 0; I < ListViewMsgFilter.Items.Count; I ++ )
        //                    {
        //                        ListItem = ListViewMsgFilter.Items[I];
        //                        if ((sFilterMsg).ToLower().CompareTo((ListItem.Text).ToLower()) == 0)
        //                        {
        //                            result = true;
        //                            break;
        //                        }
        //                    }
        //                }
        //            } finally {

        //                ListViewMsgFilter.Items.EndUpdate;
        //            }
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.InFilterMsgList");
        //        }
        //        return result;
        //    }

        //    private void RefLoadMsgFilterList()
        //    {
        //        int I;
        //        ListViewItem ListItem;
        //        TFilterMsg FilterMsg;
        //        ListViewMsgFilter.Items.Clear();
        //        try {
        //            if (GameMsgDef.g_MsgFilterList.Count > 0)
        //            {
        //                // 20080629
        //                for (I = 0; I < GameMsgDef.g_MsgFilterList.Count; I ++ )
        //                {
        //                    ListItem = ListViewMsgFilter.Items.Add();
        //                    FilterMsg = GameMsgDef.g_MsgFilterList[I];
        //                    ListItem.Text = FilterMsg.sFilterMsg;
        //                    ListItem.SubItems.Add(FilterMsg.sNewMsg);
        //                }
        //            }
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.RefLoadMsgFilterList");
        //        }
        //    }

        //    public void ListViewMsgFilterClick(object sender, EventArgs e)
        //    {
        //        ListViewItem ListItem;
        //        int nItemIndex;
        //        try {

        //            nItemIndex = ListViewMsgFilter.ItemIndex;
        //            ListItem = ListViewMsgFilter.Items[nItemIndex];
        //            EditFilterMsg.Text = ListItem.Text;

        //            EditNewMsg.Text = ListItem.SubItems.Strings[0];
        //            ButtonMsgFilterDel.Enabled = true;
        //            ButtonMsgFilterChg.Enabled = true;
        //        }
        //        catch {
        //            EditFilterMsg.Text = "";
        //            EditNewMsg.Text = "";
        //            ButtonMsgFilterDel.Enabled = false;
        //            ButtonMsgFilterChg.Enabled = false;
        //        }
        //    }

        //    public void ButtonMsgFilterAddClick(object sender, EventArgs e)
        //    {
        //        string sFilterMsg;
        //        string sNewMsg;
        //        ListViewItem ListItem;
        //        sFilterMsg = EditFilterMsg.Text.Trim();
        //        sNewMsg = EditNewMsg.Text.Trim();
        //        if (sFilterMsg == "")
        //        {
        //            System.Windows.Forms.MessageBox.Show("请输入过滤消息！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }
        //        if (InFilterMsgList(sFilterMsg))
        //        {
        //            System.Windows.Forms.MessageBox.Show("你输入的过滤消息已经存在！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }

        //        ListViewMsgFilter.Items.BeginUpdate;
        //        try {
        //            ListItem = ListViewMsgFilter.Items.Add();
        //            ListItem.Text = sFilterMsg;
        //            ListItem.SubItems.Add(sNewMsg);
        //            EditFilterMsg.Text = "";
        //            EditNewMsg.Text = "";
        //        } finally {

        //            ListViewMsgFilter.Items.EndUpdate;
        //        }
        //    }

        //    public void ButtonMsgFilterDelClick(object sender, EventArgs e)
        //    {
        //        try {

        //            ListViewMsgFilter.DeleteSelected;
        //        }
        //        catch {
        //        }
        //    }

        //    public void ButtonMsgFilterChgClick(object sender, EventArgs e)
        //    {
        //        string sFilterMsg;
        //        string sNewMsg;
        //        ListViewItem ListItem;
        //        sFilterMsg = EditFilterMsg.Text.Trim();
        //        sNewMsg = EditNewMsg.Text.Trim();
        //        if (sFilterMsg == "")
        //        {
        //            System.Windows.Forms.MessageBox.Show("请输入过滤消息！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }
        //        if (InFilterMsgList(sFilterMsg))
        //        {
        //            System.Windows.Forms.MessageBox.Show("你输入的过滤消息已经存在！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            return;
        //        }

        //        ListViewMsgFilter.Items.BeginUpdate;
        //        try {

        //            ListItem = ListViewMsgFilter.Items[ListViewMsgFilter.ItemIndex];
        //            ListItem.Text = sFilterMsg;

        //            ListItem.SubItems.Strings[0] = sNewMsg;
        //            EditFilterMsg.Text = "";
        //            EditNewMsg.Text = "";
        //        } finally {

        //            ListViewMsgFilter.Items.EndUpdate;
        //        }
        //    }

        //    public void ButtonMsgFilterSaveClick(object sender, EventArgs e)
        //    {
        //        int I;
        //        ListViewItem ListItem;
        //        List<string> SaveList;
        //        string sFilterMsg;
        //        string sNewMsg;
        //        string sFileName;
        //        try {
        //            ButtonMsgFilterSave.Enabled = false;
        //            sFileName = ".\\MsgFilterList.txt";
        //            SaveList = new List<string>();
        //            SaveList.Add(";引擎插件消息过滤配置文件");
        //            SaveList.Add(";过滤消息\09替换消息");

        //            ListViewMsgFilter.Items.BeginUpdate;
        //            try {
        //                if (ListViewMsgFilter.Items.Count > 0)
        //                {
        //                    // 20080629
        //                    for (I = 0; I < ListViewMsgFilter.Items.Count; I ++ )
        //                    {
        //                        ListItem = ListViewMsgFilter.Items[I];
        //                        sFilterMsg = ListItem.Text;

        //                        sNewMsg = ListItem.SubItems.Strings[0];
        //                        SaveList.Add(sFilterMsg + "\09" + sNewMsg);
        //                    }
        //                }
        //            } finally {

        //                ListViewMsgFilter.Items.EndUpdate;
        //            }

        //            SaveList.SaveToFile(sFileName);

        //            SaveList.Free;
        //            System.Windows.Forms.MessageBox.Show("保存完成！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            ButtonMsgFilterSave.Enabled = true;
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.ButtonMsgFilterSaveClick");
        //        }
        //    }

        //    public void ButtonLoadMsgFilterListClick(object sender, EventArgs e)
        //    {
        //        ButtonLoadMsgFilterList.Enabled = false;
        //        M2Share.LoadMsgFilterList();
        //        RefLoadMsgFilterList();
        //        System.Windows.Forms.MessageBox.Show("重新加载消息过滤列表完成！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //        ButtonLoadMsgFilterList.Enabled = true;
        //    }

        //    public void TabSheet7Show(Object Sender)
        //    {
        //        RefLoadMsgFilterList();
        //    }

        //    // -----------------------------商铺设置-----------------------------------
        //    private bool InListViewItemList(string sItemName)
        //    {
        //        bool result;
        //        int I;
        //        ListViewItem ListItem;
        //        result = false;

        //        ListViewItemList.Items.BeginUpdate;
        //        try {
        //            for (I = 0; I < ListViewItemList.Items.Count; I ++ )
        //            {
        //                ListItem = ListViewItemList.Items[I];
        //                if ((sItemName).ToLower().CompareTo((ListItem.Text).ToLower()) == 0)
        //                {
        //                    result = true;
        //                    break;
        //                }
        //            }
        //        } finally {

        //            ListViewItemList.Items.EndUpdate;
        //        }
        //        return result;
        //    }

        //    private void RefLoadShopItemList()
        //    {
        //        int I;
        //        ListViewItem ListItem;
        //        TShopInfo ShopInfo;
        //        try {
        //            ListViewItemList.Items.Clear;
        //            if (M2Share.g_ShopItemList != null)
        //            {
        //                if (M2Share.g_ShopItemList.Count > 0)
        //                {
        //                    // 20080629
        //                    for (I = 0; I < M2Share.g_ShopItemList.Count; I ++ )
        //                    {
        //                        ShopInfo = ((TShopInfo)(M2Share.g_ShopItemList[I]));

        //                        ListViewItemList.Items.BeginUpdate;
        //                        try {
        //                            ListItem = ListViewItemList.Items.Add();
        //                            ListItem.Text = ShopInfo.HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen);
        //                            ListItem.SubItems.Add(ShopInfo.Idx);
        //                            ListItem.SubItems.Add((ShopInfo.StdItem.Price / 100).ToString());
        //                            ListItem.SubItems.Add(ShopInfo.ImgBegin);
        //                            ListItem.SubItems.Add(ShopInfo.Imgend);
        //                            ListItem.SubItems.Add((ShopInfo.StdItem.NeedLevel).ToString());
        //                            // 购买的数量
        //                            ListItem.SubItems.Add(ShopInfo.Introduce1);
        //                            ListItem.SubItems.Add(ShopInfo.sIntroduce);
        //                        } finally {

        //                            ListViewItemList.Items.EndUpdate;
        //                        }
        //                    }
        //                // for
        //                }
        //                CheckBoxBuyGameGird.Checked = M2Share.g_Config.g_boGameGird;
        //                // 20080808
        //                SpinEditGameGird.Value = M2Share.g_Config.g_nGameGold;
        //            // 20080808
        //            }
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.RefLoadShopItemList");
        //        }
        //    }

        //    public void ListViewItemListClick(object sender, EventArgs e)
        //    {
        //        int nItemIndex;
        //        ListViewItem ListItem;
        //        try {

        //            nItemIndex = ListViewItemList.ItemIndex;
        //            ListItem = ListViewItemList.Items[nItemIndex];
        //            EditShopItemName.Text = ListItem.Text;

        //            SpinEditPrice.Value = HUtil32.Str_ToInt(ListItem.SubItems.Strings[1], 0);

        //            SpinEditShopItemCount.Value = HUtil32.Str_ToInt(ListItem.SubItems.Strings[4], 1);
        //            // 购买的数量

        //            EditShopImgBegin.Text = ListItem.SubItems.Strings[2];

        //            EditShopImgEnd.Text = ListItem.SubItems.Strings[3];

        //            EditShopItemIntroduce.Text = ListItem.SubItems.Strings[5];

        //            ShopTypeBoBox.SelectedIndex = HUtil32.Str_ToInt(ListItem.SubItems.Strings[0], 0);

        //            Memo1.Text = ListItem.SubItems.Strings[6];
        //            ButtonChgShopItem.Enabled = true;
        //            ButtonDelShopItem.Enabled = true;
        //        }
        //        catch {
        //            ButtonChgShopItem.Enabled = false;
        //            ButtonDelShopItem.Enabled = false;
        //        }
        //    }

        //    public void ListBoxItemListShopClick(object sender, EventArgs e)
        //    {
        //        try {

        //            EditShopItemName.Text = ListBoxItemListShop.Items.Strings[ListBoxItemListShop.SelectedIndex];
        //            ButtonAddShopItem.Enabled = true;
        //            ButtonChgShopItem.Enabled = false;
        //            ButtonDelShopItem.Enabled = false;
        //            EditShopItemIntroduce.Text = "";
        //            Memo1.Text = "";
        //        }
        //        catch {
        //            ButtonAddShopItem.Enabled = false;
        //        }
        //    }

        //    // Note: the original parameters are Object Sender, ref ushort Key, Keys Shift
        //    public void ListBoxItemListShopKeyDown(System.Object Sender, System.Windows.Forms.KeyEventArgs _e1)
        //    {
        //        string s;
        //        int I;
        //        if (Key == (ushort)"F")
        //        {
        //            if (new ArrayList(Shift).Contains(System.Windows.Forms.Keys.Control))
        //            {

        //                s = inputBox("查找物品", "请输入要查找的物品名字:", "");
        //                for (I = 0; I < ListBoxItemListShop.Items.Count; I ++ )
        //                {

        //                    if ((ListBoxItemListShop.Items.Strings[I]).ToLower().CompareTo((s).ToLower()) == 0)
        //                    {
        //                        ListBoxItemListShop.SelectedIndex = I;
        //                        return;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    public void CheckBoxBuyGameGirdClick(object sender, EventArgs e)
        //    {
        //        M2Share.g_Config.g_boGameGird = CheckBoxBuyGameGird.Checked;
        //        ButtonSaveShopItemList.Enabled = true;
        //    }

        //    public void SpinEditGameGirdChange(Object Sender)
        //    {
        //        M2Share.g_Config.g_nGameGold = SpinEditGameGird.Value;
        //        ButtonSaveShopItemList.Enabled = true;
        //    }

        //    public void ButtonDelShopItemClick(object sender, EventArgs e)
        //    {

        //        ListViewItemList.Items.BeginUpdate;
        //        try {

        //            ListViewItemList.DeleteSelected;
        //            ButtonSaveShopItemList.Enabled = true;
        //        // 20080320
        //        } finally {

        //            ListViewItemList.Items.EndUpdate;
        //        }
        //    }

        //    public void ButtonChgShopItemClick(object sender, EventArgs e)
        //    {
        //        int nItemIndex;
        //        ListViewItem ListItem;
        //        try {

        //            nItemIndex = ListViewItemList.ItemIndex;
        //            ListItem = ListViewItemList.Items[nItemIndex];

        //            ListItem.SubItems.Strings[0] = (ShopTypeBoBox.SelectedIndex).ToString();

        //            ListItem.SubItems.Strings[1] = (SpinEditPrice.Value).ToString();

        //            ListItem.SubItems.Strings[2] = EditShopImgBegin.Text.Trim();

        //            ListItem.SubItems.Strings[3] = EditShopImgEnd.Text.Trim();

        //            ListItem.SubItems.Strings[4] = (SpinEditShopItemCount.Value).ToString();

        //            ListItem.SubItems.Strings[5] = EditShopItemIntroduce.Text.Trim();

        //            ListItem.SubItems.Strings[6] = Memo1.Text.Trim();
        //            ButtonSaveShopItemList.Enabled = true;
        //        }
        //        catch {
        //        }
        //    }

        //    public void ButtonAddShopItemClick(object sender, EventArgs e)
        //    {
        //        ListViewItem ListItem;
        //        string sItemName;
        //        try {
        //            sItemName = EditShopItemName.Text.Trim();
        //            if (sItemName == "")
        //            {
        //                System.Windows.Forms.MessageBox.Show("请选择你要添加的商品！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //                return;
        //            }
        //            if (Memo1.Text == "")
        //            {
        //                System.Windows.Forms.MessageBox.Show("请输入商品描述！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //                Memo1.Focus();
        //                return;
        //            }
        //            if (InListViewItemList(sItemName))
        //            {
        //                System.Windows.Forms.MessageBox.Show("你要添加的商品已经存在，请选择其他商品！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //                return;
        //            }

        //            ListViewItemList.Items.BeginUpdate;
        //            try {
        //                ListItem = ListViewItemList.Items.Add();
        //                ListItem.SubItems.Add((ShopTypeBoBox.SelectedIndex).ToString());
        //                ListItem.Text = sItemName;
        //                ListItem.SubItems.Add((SpinEditPrice.Value).ToString());
        //                ListItem.SubItems.Add(EditShopImgBegin.Text.Trim());
        //                ListItem.SubItems.Add(EditShopImgEnd.Text.Trim());
        //                ListItem.SubItems.Add((SpinEditShopItemCount.Value).ToString());
        //                ListItem.SubItems.Add(EditShopItemIntroduce.Text.Trim());
        //                ListItem.SubItems.Add(Memo1.Text.Trim());
        //                ButtonSaveShopItemList.Enabled = true;
        //            } finally {

        //                ListViewItemList.Items.EndUpdate;
        //            }
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} TfrmViewList2.ButtonAddShopItemClick");
        //        }
        //    }

        //    public void ButtonSaveShopItemListClick(object sender, EventArgs e)
        //    {
        //        int I;
        //        ListViewItem ListItem;
        //        List<string> SaveList;
        //        string sIdx;
        //        string sImgBegin;
        //        string sImgEnd;
        //        string sIntroduce;
        //        string sLineText;
        //        string sFileName;
        //        string sItemName;
        //        string sPrice;
        //        string sMemo;
        //        string sCount;
        //        try {
        //            sFileName = ".\\BuyItemList.txt";
        //            SaveList = new List<string>();
        //            SaveList.Add(";引擎插件商铺配置文件");
        //            SaveList.Add(";商品分类\09商品名称\09出售价格\09图片开始\09图片结束\09简单介绍\09商品描述");

        //            ListViewItemList.Items.BeginUpdate;
        //            try {
        //                for (I = 0; I < ListViewItemList.Items.Count; I ++ )
        //                {
        //                    ListItem = ListViewItemList.Items[I];

        //                    sIdx = ListItem.SubItems.Strings[0];
        //                    sItemName = ListItem.Text;

        //                    sPrice = ListItem.SubItems.Strings[1];

        //                    sImgBegin = ListItem.SubItems.Strings[2];

        //                    sImgEnd = ListItem.SubItems.Strings[3];

        //                    sCount = ListItem.SubItems.Strings[4];

        //                    sIntroduce = ListItem.SubItems.Strings[5];

        //                    sMemo = ListItem.SubItems.Strings[6];
        //                    sLineText = sIdx + "\09" + sItemName + "\09" + sPrice + "\09" + sImgBegin + "\09" + sImgEnd + "\09" + sIntroduce + "\09" + sMemo + "\09" + sCount;
        //                    SaveList.Add(sLineText);
        //                }
        //            } finally {

        //                ListViewItemList.Items.EndUpdate;
        //            }

        //            SaveList.SaveToFile(sFileName);

        //            SaveList.Free;
        //            System.Windows.Forms.MessageBox.Show("保存完成！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //            ButtonSaveShopItemList.Enabled = false;
        //            // ******************************************************************************
        //            // 以下为灵符兑换保存代码

        //            M2Share.Config.WriteBool("Shop", "ShopBuyGameGird", M2Share.g_Config.g_boGameGird);

        //            M2Share.Config.WriteInteger("Shop", "GameGold", M2Share.g_Config.g_nGameGold);
        //        // ******************************************************************************
        //        }
        //        catch {
        //            M2Share.MainOutMessage("{异常} PlugOfShop.ButtonSaveShopItemListClick");
        //        }
        //    }

        //    public void ButtonLoadShopItemListClick(object sender, EventArgs e)
        //    {
        //        ButtonLoadShopItemList.Enabled = false;
        //        M2Share.LoadShopItemList();
        //        RefLoadShopItemList();
        //        System.Windows.Forms.MessageBox.Show("重新加载商列表完成！！！", "提示信息", System.Windows.Forms.MessageBoxIcon.Question);
        //        ButtonLoadShopItemList.Enabled = true;
        //    }

        //    public void TabSheet8Show(Object Sender)
        //    {
        //        int I;
        //        TStdItem StdItem;
        //        ButtonChgShopItem.Enabled = false;
        //        ButtonDelShopItem.Enabled = false;
        //        ButtonAddShopItem.Enabled = false;
        //        ListBoxItemListShop.Items.Clear();
        //        if (UserEngine.StdItemList != null)
        //        {
        //            if (UserEngine.StdItemList.Count > 0)
        //            {
        //                // 20080629
        //                for (I = 0; I < UserEngine.StdItemList.Count; I ++ )
        //                {
        //                    StdItem = ((TStdItem)(UserEngine.StdItemList[I]));
        //                    ListBoxItemListShop.Items.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen));
        //                }
        //            }
        //        }
        //        RefLoadShopItemList();
        //    }

        //    // Note: the original parameters are Object Sender, ref TCloseAction Action
        //    public void FormClose(object sender, EventArgs e)
        //    {

        //        Action = caFree;
        //    }

        //    public void FormDestroy(Object Sender)
        //    {
        //        Units.ViewList2.frmViewList2 = null;
        //    }

    }
}