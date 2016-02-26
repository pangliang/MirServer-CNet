using System;
using System.Windows.Forms;
using System.IO;
using GameFramework;
using System.Runtime.InteropServices;

namespace DBServer
{
    public partial class TfrmEditRcd : Form
    {
        private bool m_boOpened = false;//是否打开窗体
        public THumDataInfo m_ChrRcd = default(THumDataInfo);//角色信息
        public int m_nIdx = 0;//角色索引号

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        public TfrmEditRcd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TfrmEditRcd_Load(object sender, EventArgs e)
        {
            EditLevel.Maximum = ushort.MaxValue;
        }

        /// <summary>
        /// 打开窗体
        /// </summary>
        public unsafe void Open()
        {
            RefShow();
            fixed (sbyte* pChrName = m_ChrRcd.Data.sChrName)
            {
                this.Text = string.Format("编辑人物数据 [{0}]", HUtil32.SBytePtrToString(pChrName, 14));
            }
            PageControl.SelectedIndex = 0;
            this.ShowDialog();
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        private void RefShow()
        {
            m_boOpened = false;
            RefShowRcd();
            RefShowMagic();
            RefShowUserItem();
            RefShowStorage();
            m_boOpened = true;
        }

        /// <summary>
        /// 刷新显示角色信息
        /// </summary>
        private unsafe void RefShowRcd()
        {
            EditIdx.Text = m_nIdx.ToString();
            fixed (sbyte* buffer = m_ChrRcd.Data.sChrName)
            {
                EditChrName.Text = HUtil32.SBytePtrToString(buffer, 14);
            }
            fixed (sbyte* buffer = m_ChrRcd.Data.sAccount)
            {
                EditAccount.Text = HUtil32.SBytePtrToString(buffer, 30);
            }
            fixed (sbyte* buffer = m_ChrRcd.Data.sStoragePwd)
            {
                EditPassword.Text = HUtil32.SBytePtrToString(buffer, 7);
            }
            fixed (sbyte* buffer = m_ChrRcd.Data.sDearName)
            {
                EditDearName.Text = HUtil32.SBytePtrToString(buffer, 14);
            }
            fixed (sbyte* buffer = m_ChrRcd.Data.sMasterName)
            {
                EditMasterName.Text = HUtil32.SBytePtrToString(buffer, 14);
            }
            CheckBoxIsMaster.Checked = m_ChrRcd.Data.boMaster;
            fixed (sbyte* buffer = m_ChrRcd.Data.sCurMap)
            {
                EditCurMap.Text = HUtil32.SBytePtrToString(buffer, 16);
            }
            EditCurX.Value = m_ChrRcd.Data.wCurX;
            EditCurY.Value = m_ChrRcd.Data.wCurY;
            fixed (sbyte* buffer = m_ChrRcd.Data.sHomeMap)
            {
                EditHomeMap.Text = HUtil32.SBytePtrToString(buffer, 16);
            }
            EditHomeX.Value = m_ChrRcd.Data.wHomeX;
            EditHomeY.Value = m_ChrRcd.Data.wHomeY;
            EditLevel.Value = m_ChrRcd.Data.Abil.Level;
            EditGold.Value = m_ChrRcd.Data.nGold;
            EditGameGold.Value = m_ChrRcd.Data.nGameGold;
            EditGamePoint.Value = m_ChrRcd.Data.nGamePoint;
            EditPayPoint.Value = m_ChrRcd.Data.nPayMentPoint;
            EditCreditPoint.Value = m_ChrRcd.Data.btCreditPoint;
            EditPKPoint.Value = m_ChrRcd.Data.nPKPOINT;
            EditContribution.Value = m_ChrRcd.Data.wContribution;
            EditExpRate.Value = m_ChrRcd.Data.nEXPRATE;
            EditExpTime.Value = m_ChrRcd.Data.nExpTime;
            EditBonusPoint.Value = m_ChrRcd.Data.nBonusPoint;
            EditDC.Value = m_ChrRcd.Data.BonusAbil.DC;
            EditMC.Value = m_ChrRcd.Data.BonusAbil.MC;
            EditSC.Value = m_ChrRcd.Data.BonusAbil.SC;
            EditAC.Value = m_ChrRcd.Data.BonusAbil.AC;
            EditMAC.Value = m_ChrRcd.Data.BonusAbil.MAC;
            EditHP.Value = m_ChrRcd.Data.BonusAbil.HP;
            EditMP.Value = m_ChrRcd.Data.BonusAbil.MP;
            EditHit.Value = m_ChrRcd.Data.BonusAbil.Hit;
            EditSpeed.Value = m_ChrRcd.Data.BonusAbil.Speed;
            EditX2.Value = m_ChrRcd.Data.BonusAbil.X2;
        }

        /// <summary>
        /// 刷新显示魔法数据
        /// </summary>
        private unsafe void RefShowMagic()
        {
            int i;
            ListViewItem ListItem;
            THumMagic* pMagicInfo;
            THumMagic MagicInfo;
            ListViewMagic.Items.Clear();
            byte[] HumMagics = new byte[30 * 8];
            fixed (byte* buff = m_ChrRcd.Data.HumMagicsBuff)
            {
                HUtil32.BytePtrToByteArray(buff, 30 * 8);
            }
            for (i = 0; i < HumMagics.Length; i=i+8)
            {
                fixed(byte * buff =  &HumMagics[i])
                {
                    pMagicInfo = (THumMagic *)buff;
                }
                MagicInfo = *pMagicInfo;
                if (MagicInfo.wMagIdx == 0)
                {
                    break;
                }
                ListItem = new ListViewItem();
                ListItem.Text = i.ToString();
                ListItem.SubItems.Add((MagicInfo.wMagIdx).ToString());
                ListItem.SubItems.Add(DBShare.GetMagicName(MagicInfo.wMagIdx));
                ListItem.SubItems.Add((MagicInfo.btLevel).ToString());
                ListItem.SubItems.Add((MagicInfo.nTranPoint).ToString());
                ListItem.SubItems.Add((MagicInfo.btKey).ToString());
                ListViewMagic.Items.Add(ListItem);
            }
        }

        /// <summary>
        /// 刷新显示用户物品
        /// </summary>
        private unsafe void RefShowUserItem()
        {
            int i;
            ListViewItem ListItem;
            TUserItem UserItem;
            TUserItem* pUserItem;
            const string sItemValue = "{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-{13}";
            ListViewUserItem.Items.Clear();
            byte[] HumItems;
            fixed (byte* buff = m_ChrRcd.Data.HumItemsBuff)
            {
                HumItems = HUtil32.BytePtrToByteArray(buff, 9 * 74);
            }
            for (i = 0; i < HumItems.Length; i=i+74)
            {

                fixed (byte* buff = &HumItems[i])
                {
                    pUserItem = (TUserItem*)buff;
                }
                UserItem = *pUserItem;
                ListItem = new ListViewItem();
                ListItem.Text = (i).ToString();
                ListItem.SubItems.Add((UserItem.MakeIndex).ToString());
                ListItem.SubItems.Add((UserItem.wIndex).ToString());
                ListItem.SubItems.Add(DBShare.GetStdItemName(UserItem.wIndex));
                ListItem.SubItems.Add(string.Format("{0}/{1}",  UserItem.Dura, UserItem.DuraMax));
                ListItem.SubItems.Add(string.Format(sItemValue,  UserItem.btValue[0], UserItem.btValue[1], UserItem.btValue[2], UserItem.btValue[3], UserItem.btValue[4], UserItem.btValue[5], UserItem.btValue[6], UserItem.btValue[7], UserItem.btValue[8], UserItem.btValue[9], UserItem.btValue[10], UserItem.btValue[11], UserItem.btValue[12], UserItem.btValue[13]));
                ListViewUserItem.Items.Add(ListItem);
            }
            byte[] HumAddItems;//下面四个格子
            fixed (byte* buff = m_ChrRcd.Data.HumAddItemsBuff)
            {
                HumAddItems = HUtil32.BytePtrToByteArray(buff, 4 * 74);
            }
            for (i = 0; i < HumAddItems.Length; i+=74)
            {

                fixed (byte* buff = &HumAddItems[i])
                {
                    pUserItem = (TUserItem*)buff;
                }
                UserItem = *pUserItem;
                ListItem = new ListViewItem();
                ListItem.Text = i.ToString();
                ListItem.SubItems.Add((UserItem.MakeIndex).ToString());
                ListItem.SubItems.Add((UserItem.wIndex).ToString());
                ListItem.SubItems.Add(DBShare.GetStdItemName(UserItem.wIndex));
                ListItem.SubItems.Add(string.Format("{0}/{1}", UserItem.Dura, UserItem.DuraMax ));
                ListItem.SubItems.Add(string.Format(sItemValue,  UserItem.btValue[0], UserItem.btValue[1], UserItem.btValue[2], UserItem.btValue[3], UserItem.btValue[4], UserItem.btValue[5], UserItem.btValue[6], UserItem.btValue[7], UserItem.btValue[8], UserItem.btValue[9], UserItem.btValue[10], UserItem.btValue[11], UserItem.btValue[12], UserItem.btValue[13] ));
                ListViewUserItem.Items.Add(ListItem);
            }
        }

        /// <summary>
        /// 刷新显示仓库信息
        /// </summary>
        private unsafe void RefShowStorage()
        {
            int i;
            ListViewItem ListItem;
            TUserItem UserItem;
            TUserItem* pUserItem;
            ListViewStorage.Items.Clear();
            byte[] StorageItems;//46 * 74
            fixed (byte* buff = m_ChrRcd.Data.StorageItemsBuff)
            {
                StorageItems = HUtil32.BytePtrToByteArray(buff, 46 * 74);
            }

            for (i = 0; i <= StorageItems.Length; i+=74)
            {
                fixed (byte* buff = &StorageItems[i])
                {
                    pUserItem = (TUserItem*)buff;
                }
                UserItem = *pUserItem;
                if (UserItem.wIndex == 0)
                {
                    continue;
                }
                ListItem = new ListViewItem();
                ListItem.Text = i.ToString();
                ListItem.SubItems.Add((UserItem.MakeIndex).ToString());
                ListItem.SubItems.Add((UserItem.wIndex).ToString());
                ListItem.SubItems.Add(DBShare.GetStdItemName(UserItem.wIndex));
                ListItem.SubItems.Add(string.Format("{0}/{1}", UserItem.Dura, UserItem.DuraMax));
                ListItem.SubItems.Add(string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}/{9}/{10}/{11}/{12}/{13}", UserItem.btValue[0], UserItem.btValue[1], UserItem.btValue[2], UserItem.btValue[3], UserItem.btValue[4], UserItem.btValue[5], UserItem.btValue[6], UserItem.btValue[7], UserItem.btValue[8], UserItem.btValue[9], UserItem.btValue[10], UserItem.btValue[11], UserItem.btValue[12], UserItem.btValue[13]));
                ListViewStorage.Items.Add(ListItem);
            }
        }

        /// <summary>
        /// 到处数据按钮单击事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void ButtonExportDataClick(System.Object Sender, System.EventArgs _e1)
        {
            if (Sender == ButtonExportData)
            {
                ProcessSaveRcdToFile();
            }
            else if (Sender == ButtonImportData)
            {
                ProcessLoadRcdformFile();
            }
            else if (Sender == ButtonSaveData)
            {
                ProcessSaveRcd();
            }
        }

        /// <summary>
        /// 处理保存角色信息到文件
        /// </summary>
        private unsafe void ProcessSaveRcdToFile()
        {
            string sSaveFileName;
            FileStream nFileHandle;
            fixed (sbyte* buff = m_ChrRcd.Data.sChrName)
            {
               SaveDialog.FileName = HUtil32.SBytePtrToString(buff, m_ChrRcd.Data.ChrNameLen);
            }
            SaveDialog.InitialDirectory = ".\\";
            if (SaveDialog.ShowDialog()== System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            sSaveFileName = SaveDialog.FileName;
            if (File.Exists(sSaveFileName))
            {
                nFileHandle = File.Open(sSaveFileName,FileMode.OpenOrCreate,FileAccess.ReadWrite);
            }
            else
            {
                nFileHandle = File.Create(sSaveFileName);
            }
            if (nFileHandle == null)
            {
                MessageBox.Show("保存文件出现错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }
            //@ Unsupported function or procedure: 'FileWrite'
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter format = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            format.Serialize(nFileHandle, m_ChrRcd);
            //nFileHandle.Write(m_ChrRcd, 0, sizeof(THumDataInfo));
            //FileWrite(nFileHandle, m_ChrRcd, sizeof(THumDataInfo));
            nFileHandle.Close();
            MessageBox.Show("人物数据导出成功！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 处理导入角色信息文件
        /// </summary>
        private unsafe void ProcessLoadRcdformFile()
        {
            string sLoadFileName;
            FileStream nFileHandle;
            THumDataInfo ChrRcd;
            fixed (sbyte* buff = m_ChrRcd.Data.sChrName)
            {
                OpenDialog.FileName = HUtil32.SBytePtrToString(buff, m_ChrRcd.Data.ChrNameLen);
            }
            //OpenDialog.FileName = m_ChrRcd.Data.sChrName;
            OpenDialog.InitialDirectory = ".\\";
            if (OpenDialog.ShowDialog()== System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            sLoadFileName = OpenDialog.FileName;
            if (!File.Exists(sLoadFileName))
            {
                MessageBox.Show("指定的文件未找到！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }
            nFileHandle = File.Open(sLoadFileName, FileMode.OpenOrCreate,FileAccess.ReadWrite );
            if (nFileHandle == null)
            {
                MessageBox.Show("打开文件出现错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }
            //@ Unsupported function or procedure: 'FileRead'
            byte[] BytesChrRcd = new byte[sizeof(THumDataInfo)];
            if (nFileHandle.Read(BytesChrRcd, 0, sizeof(THumDataInfo)) != sizeof(THumDataInfo))
            {
                MessageBox.Show("读取文件出现错误！！！\r\r文件格式可能不正确", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }
            ChrRcd.Header = m_ChrRcd.Header;
            //日后解决
            //ChrRcd.Data.sChrName = m_ChrRcd.Data.sChrName;
            //ChrRcd.Data.sAccount = m_ChrRcd.Data.sAccount;
            //m_ChrRcd = ChrRcd;
            nFileHandle.Close();
            RefShow();
            MessageBox.Show("人物数据导入成功！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 处理保存角色信息
        /// </summary>
        private unsafe void ProcessSaveRcd()
        {
            int nIdx;
            bool boSaveOK;
            boSaveOK = false;
            string ChrName = string.Empty;
            try
            {
                if (DBShare.g_HumDataDB.Open())
                {
                    fixed (sbyte* buff = m_ChrRcd.Header.sName)
                    {
                        ChrName = HUtil32.SBytePtrToString(buff, m_ChrRcd.Header.NameLen);
                    }
                    //nIdx = DBShare.g_HumDataDB.Index(m_ChrRcd.Header.sName);
                    if (DBShare.g_HumDataDB.IsExist(ChrName))
                    {
                        DBShare.g_HumDataDB.Update(ChrName, ref m_ChrRcd);
                        boSaveOK = true;
                    }
                    else
                    {
                        DBShare.g_HumDataDB.Add(ref m_ChrRcd);
                        boSaveOK = true;
                    }
                }
            }
            finally
            {
                //DBShare.g_HumDataDB.Close();
            }
            if (boSaveOK)
            {
                MessageBox.Show("人物数据保存成功！！！", "提示信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("人物数据保存失败！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 编辑框变动时保存数据
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void EditPasswordChange(System.Object Sender, System.EventArgs _e1)
        {
            //if (!m_boOpened)
            //{
            //    return;
            //}
            //if (Sender == EditPassword)
            //{
            //    m_ChrRcd.Data.sStoragePwd = EditPassword.Text.Trim();
            //}
            //else if (Sender == EditDearName)
            //{
            //    m_ChrRcd.Data.sDearName = EditDearName.Text.Trim();
            //}
            //else if (Sender == EditMasterName)
            //{
            //    m_ChrRcd.Data.sMasterName = EditMasterName.Text.Trim();
            //}
            //else if (Sender == CheckBoxIsMaster)
            //{
            //    m_ChrRcd.Data.boMaster = CheckBoxIsMaster.Checked;
            //}
            //else if (Sender == EditCurMap)
            //{
            //    m_ChrRcd.Data.sCurMap = EditCurMap.Text.Trim();
            //}
            //else if (Sender == EditCurX)
            //{
            //    m_ChrRcd.Data.wCurX = EditCurX.Value;
            //}
            //else if (Sender == EditCurY)
            //{
            //    m_ChrRcd.Data.wCurY = EditCurY.Value;
            //}
            //else if (Sender == EditHomeMap)
            //{
            //    m_ChrRcd.Data.sHomeMap = EditHomeMap.Text.Trim();
            //}
            //else if (Sender == EditHomeX)
            //{
            //    m_ChrRcd.Data.wHomeX = EditHomeX.Value;
            //}
            //else if (Sender == EditCurY)
            //{
            //    m_ChrRcd.Data.wHomeY = EditHomeY.Value;
            //}
            //else if (Sender == EditLevel)
            //{
            //    m_ChrRcd.Data.Abil.Level = EditLevel.Value;
            //}
            //else if (Sender == EditGold)
            //{
            //    m_ChrRcd.Data.nGold = EditGold.Value;
            //}
            //else if (Sender == EditGameGold)
            //{
            //    m_ChrRcd.Data.nGameGold = EditGameGold.Value;
            //}
            //else if (Sender == EditGamePoint)
            //{
            //    m_ChrRcd.Data.nGamePoint = EditGamePoint.Value;
            //}
            //else if (Sender == EditPayPoint)
            //{
            //    m_ChrRcd.Data.nPayMentPoint = EditPayPoint.Value;
            //}
            //else if (Sender == EditCreditPoint)
            //{
            //    m_ChrRcd.Data.btCreditPoint = EditCreditPoint.Value;
            //}
            //else if (Sender == EditPKPoint)
            //{
            //    m_ChrRcd.Data.nPKPOINT = EditPKPoint.Value;
            //}
            //else if (Sender == EditContribution)
            //{
            //    m_ChrRcd.Data.wContribution = EditContribution.Value;
            //}
            //else if (Sender == EditExpRate)
            //{
            //    m_ChrRcd.Data.nEXPRATE = EditExpRate.Value;
            //}
            //else if (Sender == EditExpTime)
            //{
            //    m_ChrRcd.Data.nExpTime = EditExpTime.Value;
            //}
            //else if (Sender == EditBonusPoint)
            //{
            //    m_ChrRcd.Data.nBonusPoint = EditBonusPoint.Value;
            //}
        }



    } // end TfrmEditRcd

}