using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmItemSet : Form
    {
        private bool boOpened = false;
        private bool boModValued = false;
        public static TfrmItemSet frmItemSet = null;

        public TfrmItemSet()
        {
            InitializeComponent();
        }

        private void ModValue()
        {
            boModValued = true;
            ButtonItemSetSave.Enabled = true;
            ButtonAddValueSave.Enabled = true;
            ButtonUnKnowItemSave.Enabled = true;
        }

        private void uModValue()
        {
            boModValued = false;
            ButtonItemSetSave.Enabled = false;
            ButtonAddValueSave.Enabled = false;
            ButtonUnKnowItemSave.Enabled = false;
        }

        public void Open()
        {
            boOpened = false;
            uModValue();
            EditItemExpRate.Value = M2Share.g_Config.nItemExpRate;
            EditItemPowerRate.Value = M2Share.g_Config.nItemPowerRate;
            EditMonRandomAddValue.Value = M2Share.g_Config.nMonRandomAddValue;
            EditMakeRandomAddValue.Value = M2Share.g_Config.nMakeRandomAddValue;
            EditPlayMonRandomAddValue.Value = M2Share.g_Config.nPlayMonRandomAddValue;// 人形身上装备极品机率
            EditWeaponDCAddValueMaxLimit.Value = M2Share.g_Config.nWeaponDCAddValueMaxLimit;
            EditWeaponDCAddValueRate.Value = M2Share.g_Config.nWeaponDCAddValueRate;
            EditWeaponMCAddValueMaxLimit.Value = M2Share.g_Config.nWeaponMCAddValueMaxLimit;
            EditWeaponMCAddValueRate.Value = M2Share.g_Config.nWeaponMCAddValueRate;
            EditWeaponSCAddValueMaxLimit.Value = M2Share.g_Config.nWeaponSCAddValueMaxLimit;
            EditWeaponSCAddValueRate.Value = M2Share.g_Config.nWeaponSCAddValueRate;
            EditWeaponDCAddRate.Value = M2Share.g_Config.nWeaponDCAddRate;
            EditWeaponSCAddRate.Value = M2Share.g_Config.nWeaponSCAddRate;
            EditWeaponMCAddRate.Value = M2Share.g_Config.nWeaponMCAddRate;
            EditDressDCAddRate.Value = M2Share.g_Config.nDressDCAddRate;
            EditDressDCAddValueMaxLimit.Value = M2Share.g_Config.nDressDCAddValueMaxLimit;
            EditDressDCAddValueRate.Value = M2Share.g_Config.nDressDCAddValueRate;
            EditDressMCAddRate.Value = M2Share.g_Config.nDressMCAddRate;
            EditDressMCAddValueMaxLimit.Value = M2Share.g_Config.nDressMCAddValueMaxLimit;
            EditDressMCAddValueRate.Value = M2Share.g_Config.nDressMCAddValueRate;
            EditDressSCAddRate.Value = M2Share.g_Config.nDressSCAddRate;
            EditDressSCAddValueMaxLimit.Value = M2Share.g_Config.nDressSCAddValueMaxLimit;
            EditDressSCAddValueRate.Value = M2Share.g_Config.nDressSCAddValueRate;
            EditDressACAddValueMaxLimit.Value = M2Share.g_Config.nDressACAddValueMaxLimit;
            EditDressACAddValueRate.Value = M2Share.g_Config.nDressACAddValueRate;
            EditDressACAddRate.Value = M2Share.g_Config.nDressACAddRate;
            EditDressMACAddValueMaxLimit.Value = M2Share.g_Config.nDressMACAddValueMaxLimit;
            EditDressMACAddValueRate.Value = M2Share.g_Config.nDressMACAddValueRate;
            EditDressMACAddRate.Value = M2Share.g_Config.nDressMACAddRate;
            EditNeckLace19DCAddRate.Value = M2Share.g_Config.nNeckLace19DCAddRate;
            EditNeckLace19DCAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace19DCAddValueMaxLimit;
            EditNeckLace19DCAddValueRate.Value = M2Share.g_Config.nNeckLace19DCAddValueRate;
            EditNeckLace19MCAddRate.Value = M2Share.g_Config.nNeckLace19MCAddRate;
            EditNeckLace19MCAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace19MCAddValueMaxLimit;
            EditNeckLace19MCAddValueRate.Value = M2Share.g_Config.nNeckLace19MCAddValueRate;
            EditNeckLace19SCAddRate.Value = M2Share.g_Config.nNeckLace19SCAddRate;
            EditNeckLace19SCAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace19SCAddValueMaxLimit;
            EditNeckLace19SCAddValueRate.Value = M2Share.g_Config.nNeckLace19SCAddValueRate;
            EditNeckLace19ACAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace19ACAddValueMaxLimit;
            EditNeckLace19ACAddValueRate.Value = M2Share.g_Config.nNeckLace19ACAddValueRate;
            EditNeckLace19ACAddRate.Value = M2Share.g_Config.nNeckLace19ACAddRate;
            EditNeckLace19MACAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace19MACAddValueMaxLimit;
            EditNeckLace19MACAddValueRate.Value = M2Share.g_Config.nNeckLace19MACAddValueRate;
            EditNeckLace19MACAddRate.Value = M2Share.g_Config.nNeckLace19MACAddRate;
            EditNeckLace202124DCAddRate.Value = M2Share.g_Config.nNeckLace202124DCAddRate;
            EditNeckLace202124DCAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace202124DCAddValueMaxLimit;
            EditNeckLace202124DCAddValueRate.Value = M2Share.g_Config.nNeckLace202124DCAddValueRate;
            EditNeckLace202124MCAddRate.Value = M2Share.g_Config.nNeckLace202124MCAddRate;
            EditNeckLace202124MCAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace202124MCAddValueMaxLimit;
            EditNeckLace202124MCAddValueRate.Value = M2Share.g_Config.nNeckLace202124MCAddValueRate;
            EditNeckLace202124SCAddRate.Value = M2Share.g_Config.nNeckLace202124SCAddRate;
            EditNeckLace202124SCAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace202124SCAddValueMaxLimit;
            EditNeckLace202124SCAddValueRate.Value = M2Share.g_Config.nNeckLace202124SCAddValueRate;
            EditNeckLace202124ACAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace202124ACAddValueMaxLimit;
            EditNeckLace202124ACAddValueRate.Value = M2Share.g_Config.nNeckLace202124ACAddValueRate;
            EditNeckLace202124ACAddRate.Value = M2Share.g_Config.nNeckLace202124ACAddRate;
            EditNeckLace202124MACAddValueMaxLimit.Value = M2Share.g_Config.nNeckLace202124MACAddValueMaxLimit;
            EditNeckLace202124MACAddValueRate.Value = M2Share.g_Config.nNeckLace202124MACAddValueRate;
            EditNeckLace202124MACAddRate.Value = M2Share.g_Config.nNeckLace202124MACAddRate;
            EditArmRing26DCAddRate.Value = M2Share.g_Config.nArmRing26DCAddRate;
            EditArmRing26DCAddValueMaxLimit.Value = M2Share.g_Config.nArmRing26DCAddValueMaxLimit;
            EditArmRing26DCAddValueRate.Value = M2Share.g_Config.nArmRing26DCAddValueRate;
            EditArmRing26MCAddRate.Value = M2Share.g_Config.nArmRing26MCAddRate;
            EditArmRing26MCAddValueMaxLimit.Value = M2Share.g_Config.nArmRing26MCAddValueMaxLimit;
            EditArmRing26MCAddValueRate.Value = M2Share.g_Config.nArmRing26MCAddValueRate;
            EditArmRing26SCAddRate.Value = M2Share.g_Config.nArmRing26SCAddRate;
            EditArmRing26SCAddValueMaxLimit.Value = M2Share.g_Config.nArmRing26SCAddValueMaxLimit;
            EditArmRing26SCAddValueRate.Value = M2Share.g_Config.nArmRing26SCAddValueRate;
            EditArmRing26ACAddValueMaxLimit.Value = M2Share.g_Config.nArmRing26ACAddValueMaxLimit;
            EditArmRing26ACAddValueRate.Value = M2Share.g_Config.nArmRing26ACAddValueRate;
            EditArmRing26ACAddRate.Value = M2Share.g_Config.nArmRing26ACAddRate;
            EditArmRing26MACAddValueMaxLimit.Value = M2Share.g_Config.nArmRing26MACAddValueMaxLimit;
            EditArmRing26MACAddValueRate.Value = M2Share.g_Config.nArmRing26MACAddValueRate;
            EditArmRing26MACAddRate.Value = M2Share.g_Config.nArmRing26MACAddRate;
            EditRing22DCAddRate.Value = M2Share.g_Config.nRing22DCAddRate;
            EditRing22DCAddValueMaxLimit.Value = M2Share.g_Config.nRing22DCAddValueMaxLimit;
            EditRing22DCAddValueRate.Value = M2Share.g_Config.nRing22DCAddValueRate;
            EditRing22MCAddRate.Value = M2Share.g_Config.nRing22MCAddRate;
            EditRing22MCAddValueMaxLimit.Value = M2Share.g_Config.nRing22MCAddValueMaxLimit;
            EditRing22MCAddValueRate.Value = M2Share.g_Config.nRing22MCAddValueRate;
            EditRing22SCAddRate.Value = M2Share.g_Config.nRing22SCAddRate;
            EditRing22SCAddValueMaxLimit.Value = M2Share.g_Config.nRing22SCAddValueMaxLimit;
            EditRing22SCAddValueRate.Value = M2Share.g_Config.nRing22SCAddValueRate;
            EditRing23DCAddRate.Value = M2Share.g_Config.nRing23DCAddRate;
            EditRing23DCAddValueMaxLimit.Value = M2Share.g_Config.nRing23DCAddValueMaxLimit;
            EditRing23DCAddValueRate.Value = M2Share.g_Config.nRing23DCAddValueRate;
            EditRing23MCAddRate.Value = M2Share.g_Config.nRing23MCAddRate;
            EditRing23MCAddValueMaxLimit.Value = M2Share.g_Config.nRing23MCAddValueMaxLimit;
            EditRing23MCAddValueRate.Value = M2Share.g_Config.nRing23MCAddValueRate;
            EditRing23SCAddRate.Value = M2Share.g_Config.nRing23SCAddRate;
            EditRing23SCAddValueMaxLimit.Value = M2Share.g_Config.nRing23SCAddValueMaxLimit;
            EditRing23SCAddValueRate.Value = M2Share.g_Config.nRing23SCAddValueRate;
            EditRing23ACAddValueMaxLimit.Value = M2Share.g_Config.nRing23ACAddValueMaxLimit;
            EditRing23ACAddValueRate.Value = M2Share.g_Config.nRing23ACAddValueRate;
            EditRing23ACAddRate.Value = M2Share.g_Config.nRing23ACAddRate;
            EditRing23MACAddValueMaxLimit.Value = M2Share.g_Config.nRing23MACAddValueMaxLimit;
            EditRing23MACAddValueRate.Value = M2Share.g_Config.nRing23MACAddValueRate;
            EditRing23MACAddRate.Value = M2Share.g_Config.nRing23MACAddRate;
            EditBootsDCAddValueMaxLimit.Value = M2Share.g_Config.nBootsDCAddValueMaxLimit;// 极品鞋子加攻最高点
            EditBootsDCAddValueRate.Value = M2Share.g_Config.nBootsDCAddValueRate;
            EditBootsDCAddRate.Value = M2Share.g_Config.nBootsDCAddRate;// 道术
            EditBootsSCAddValueMaxLimit.Value = M2Share.g_Config.nBootsSCAddValueMaxLimit;
            EditBootsSCAddValueRate.Value = M2Share.g_Config.nBootsSCAddValueRate;
            EditBootsSCAddRate.Value = M2Share.g_Config.nBootsSCAddRate;// 魔法
            EditBootsMCAddValueMaxLimit.Value = M2Share.g_Config.nBootsMCAddValueMaxLimit;
            EditBootsMCAddValueRate.Value = M2Share.g_Config.nBootsMCAddValueRate;
            EditBootsMCAddRate.Value = M2Share.g_Config.nBootsMCAddRate;// 防御
            EditBootsACAddValueMaxLimit.Value = M2Share.g_Config.nBootsACAddValueMaxLimit;
            EditBootsACAddValueRate.Value = M2Share.g_Config.nBootsACAddValueRate;
            EditBootsACAddRate.Value = M2Share.g_Config.nBootsACAddRate;// 魔御
            EditBootsMACAddValueMaxLimit.Value = M2Share.g_Config.nBootsMACAddValueMaxLimit;
            EditBootsMACAddValueRate.Value = M2Share.g_Config.nBootsMACAddValueRate;
            EditBootsMACAddRate.Value = M2Share.g_Config.nBootsMACAddRate;
            EditHelMetDCAddRate.Value = M2Share.g_Config.nHelMetDCAddRate;
            EditHelMetDCAddValueMaxLimit.Value = M2Share.g_Config.nHelMetDCAddValueMaxLimit;
            EditHelMetDCAddValueRate.Value = M2Share.g_Config.nHelMetDCAddValueRate;
            EditHelMetMCAddRate.Value = M2Share.g_Config.nHelMetMCAddRate;
            EditHelMetMCAddValueMaxLimit.Value = M2Share.g_Config.nHelMetMCAddValueMaxLimit;
            EditHelMetMCAddValueRate.Value = M2Share.g_Config.nHelMetMCAddValueRate;
            EditHelMetSCAddRate.Value = M2Share.g_Config.nHelMetSCAddRate;
            EditHelMetSCAddValueMaxLimit.Value = M2Share.g_Config.nHelMetSCAddValueMaxLimit;
            EditHelMetSCAddValueRate.Value = M2Share.g_Config.nHelMetSCAddValueRate;
            EditHelMetACAddValueMaxLimit.Value = M2Share.g_Config.nHelMetACAddValueMaxLimit;
            EditHelMetACAddValueRate.Value = M2Share.g_Config.nHelMetACAddValueRate;
            EditHelMetACAddRate.Value = M2Share.g_Config.nHelMetACAddRate;
            EditHelMetMACAddValueMaxLimit.Value = M2Share.g_Config.nHelMetMACAddValueMaxLimit;
            EditHelMetMACAddValueRate.Value = M2Share.g_Config.nHelMetMACAddValueRate;
            EditHelMetMACAddRate.Value = M2Share.g_Config.nHelMetMACAddRate;
            switch (M2Share.g_Config.nIsUseZhuLi)
            {
                case 0:// 斗笠可带选项
                    RadioHumHeroUse.Checked = true;
                    break;
                case 1:
                    RadioHumUse.Checked = true;
                    break;
                case 2:
                    RadioHeroUse.Checked = true;
                    break;
            }
            CheckBoxUnKnowHum.Checked = M2Share.g_Config.boUnKnowHum;// 带上斗笠是否显示神秘人
            EditGuildRecallTime.Value = M2Share.g_Config.nGuildRecallTime;
            RefUnknowItem();
            RefShapeItem();
            boOpened = true;
            PageControl.SelectedIndex = 0;
            AddValuePageControl.SelectedIndex = 0;
            ItemSetPageControl.SelectedIndex = 0;
            this.ShowDialog();
        }

        public void ButtonItemSetSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "ItemPowerRate", M2Share.g_Config.nItemPowerRate);
            M2Share.Config.WriteInteger("Setup", "ItemExpRate", M2Share.g_Config.nItemExpRate);
            M2Share.Config.WriteInteger("Setup", "GuildRecallTime", M2Share.g_Config.nGuildRecallTime);
            M2Share.Config.WriteInteger("Setup", "GroupRecallTime", M2Share.g_Config.nGroupRecallTime);
            M2Share.Config.WriteInteger("Setup", "GroupRecallTime", M2Share.g_Config.nAttackPosionRate);
            M2Share.Config.WriteInteger("Setup", "AttackPosionRate", M2Share.g_Config.nAttackPosionRate);
            M2Share.Config.WriteInteger("Setup", "AttackPosionTime", M2Share.g_Config.nAttackPosionTime);
            M2Share.Config.WriteBool("Setup", "UserMoveCanDupObj", M2Share.g_Config.boUserMoveCanDupObj);
            M2Share.Config.WriteBool("Setup", "UserMoveCanOnItem", M2Share.g_Config.boUserMoveCanOnItem);
            M2Share.Config.WriteInteger("Setup", "UserMoveTime", M2Share.g_Config.dwUserMoveTime);
            M2Share.Config.WriteInteger("Setup", "IsUseZhuLi", M2Share.g_Config.nIsUseZhuLi);// 斗笠可带选项 
            M2Share.Config.WriteBool("Setup", "UnKnowHum", M2Share.g_Config.boUnKnowHum);// 带上斗笠是否显示神秘人 
            uModValue();
        }

        public void EditItemExpRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nItemExpRate = (ushort)EditItemExpRate.Value;
            ModValue();
        }

        public void EditItemPowerRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nItemPowerRate = (ushort)EditItemPowerRate.Value;
            ModValue();
        }

        public void ButtonAddValueSaveClick(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "MonRandomAddValue", M2Share.g_Config.nMonRandomAddValue);
            M2Share.Config.WriteInteger("Setup", "MakeRandomAddValue", M2Share.g_Config.nMakeRandomAddValue);
            M2Share.Config.WriteInteger("Setup", "PlayMonRandomAddValue", M2Share.g_Config.nPlayMonRandomAddValue);// 人形身上装备极品机率
            M2Share.Config.WriteInteger("Setup", "WeaponDCAddValueMaxLimit", M2Share.g_Config.nWeaponDCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "WeaponDCAddValueRate", M2Share.g_Config.nWeaponDCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "WeaponMCAddValueMaxLimit", M2Share.g_Config.nWeaponMCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "WeaponMCAddValueRate", M2Share.g_Config.nWeaponMCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "WeaponSCAddValueMaxLimit", M2Share.g_Config.nWeaponSCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "WeaponSCAddValueRate", M2Share.g_Config.nWeaponSCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "WeaponDCAddRate", M2Share.g_Config.nWeaponDCAddRate);
            M2Share.Config.WriteInteger("Setup", "WeaponSCAddRate", M2Share.g_Config.nWeaponSCAddRate);
            M2Share.Config.WriteInteger("Setup", "WeaponMCAddRate", M2Share.g_Config.nWeaponMCAddRate);
            M2Share.Config.WriteInteger("Setup", "DressDCAddRate", M2Share.g_Config.nDressDCAddRate);
            M2Share.Config.WriteInteger("Setup", "DressDCAddValueMaxLimit", M2Share.g_Config.nDressDCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "DressDCAddValueRate", M2Share.g_Config.nDressDCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "DressMCAddRate", M2Share.g_Config.nDressMCAddRate);
            M2Share.Config.WriteInteger("Setup", "DressMCAddValueMaxLimit", M2Share.g_Config.nDressMCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "DressMCAddValueRate", M2Share.g_Config.nDressMCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "DressSCAddRate", M2Share.g_Config.nDressSCAddRate);
            M2Share.Config.WriteInteger("Setup", "DressSCAddValueMaxLimit", M2Share.g_Config.nDressSCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "DressSCAddValueRate", M2Share.g_Config.nDressSCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "DressACAddValueMaxLimit", M2Share.g_Config.nDressACAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "DressACAddValueRate", M2Share.g_Config.nDressACAddValueRate);
            M2Share.Config.WriteInteger("Setup", "DressACAddRate", M2Share.g_Config.nDressACAddRate);
            M2Share.Config.WriteInteger("Setup", "DressMACAddValueMaxLimit", M2Share.g_Config.nDressMACAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "DressMACAddValueRate", M2Share.g_Config.nDressMACAddValueRate);
            M2Share.Config.WriteInteger("Setup", "DressMACAddRate", M2Share.g_Config.nDressMACAddRate);
            M2Share.Config.WriteInteger("Setup", "NeckLace19DCAddRate", M2Share.g_Config.nNeckLace19DCAddRate);
            M2Share.Config.WriteInteger("Setup", "NeckLace19DCAddValueMaxLimit", M2Share.g_Config.nNeckLace19DCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "NeckLace19DCAddValueRate", M2Share.g_Config.nNeckLace19DCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "NeckLace19MCAddRate", M2Share.g_Config.nNeckLace19MCAddRate);
            M2Share.Config.WriteInteger("Setup", "NeckLace19MCAddValueMaxLimit", M2Share.g_Config.nNeckLace19MCAddValueMaxLimit);
            M2Share.Config.WriteInteger("Setup", "NeckLace19MCAddValueRate", M2Share.g_Config.nNeckLace19MCAddValueRate);
            M2Share.Config.WriteInteger("Setup", "NeckLace19SCAddRate", M2Share.g_Config.nNeckLace19SCAddRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace19SCAddValueMaxLimit", M2Share.g_Config.nNeckLace19SCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace19SCAddValueRate", M2Share.g_Config.nNeckLace19SCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace19ACAddValueMaxLimit", M2Share.g_Config.nNeckLace19ACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace19ACAddValueRate", M2Share.g_Config.nNeckLace19ACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace19ACAddRate", M2Share.g_Config.nNeckLace19ACAddRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace19MACAddValueMaxLimit", M2Share.g_Config.nNeckLace19MACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace19MACAddValueRate", M2Share.g_Config.nNeckLace19MACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace19MACAddRate", M2Share.g_Config.nNeckLace19MACAddRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124DCAddRate", M2Share.g_Config.nNeckLace202124DCAddRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124DCAddValueMaxLimit", M2Share.g_Config.nNeckLace202124DCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124DCAddValueRate", M2Share.g_Config.nNeckLace202124DCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124MCAddRate", M2Share.g_Config.nNeckLace202124MCAddRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124MCAddValueMaxLimit", M2Share.g_Config.nNeckLace202124MCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124MCAddValueRate", M2Share.g_Config.nNeckLace202124MCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124SCAddRate", M2Share.g_Config.nNeckLace202124SCAddRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124SCAddValueMaxLimit", M2Share.g_Config.nNeckLace202124SCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124SCAddValueRate", M2Share.g_Config.nNeckLace202124SCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124ACAddValueMaxLimit", M2Share.g_Config.nNeckLace202124ACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124ACAddValueRate", M2Share.g_Config.nNeckLace202124ACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124ACAddRate", M2Share.g_Config.nNeckLace202124ACAddRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124MACAddValueMaxLimit", M2Share.g_Config.nNeckLace202124MACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124MACAddValueRate", M2Share.g_Config.nNeckLace202124MACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "NeckLace202124MACAddRate", M2Share.g_Config.nNeckLace202124MACAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring22DCAddValueMaxLimit", M2Share.g_Config.nRing22DCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring22DCAddValueRate", M2Share.g_Config.nRing22DCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring22DCAddRate", M2Share.g_Config.nRing22DCAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring22MCAddValueMaxLimit", M2Share.g_Config.nRing22MCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring22MCAddValueRate", M2Share.g_Config.nRing22MCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring22MCAddRate", M2Share.g_Config.nRing22MCAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring22SCAddValueMaxLimit", M2Share.g_Config.nRing22SCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring22SCAddValueRate", M2Share.g_Config.nRing22SCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring22SCAddRate", M2Share.g_Config.nRing22SCAddRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26DCAddRate", M2Share.g_Config.nArmRing26DCAddRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26DCAddValueMaxLimit", M2Share.g_Config.nArmRing26DCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "ArmRing26DCAddValueRate", M2Share.g_Config.nArmRing26DCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26MCAddRate", M2Share.g_Config.nArmRing26MCAddRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26MCAddValueMaxLimit", M2Share.g_Config.nArmRing26MCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "ArmRing26MCAddValueRate", M2Share.g_Config.nArmRing26MCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26SCAddRate", M2Share.g_Config.nArmRing26SCAddRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26SCAddValueMaxLimit", M2Share.g_Config.nArmRing26SCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "ArmRing26SCAddValueRate", M2Share.g_Config.nArmRing26SCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26ACAddValueMaxLimit", M2Share.g_Config.nArmRing26ACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "ArmRing26ACAddValueRate", M2Share.g_Config.nArmRing26ACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26ACAddRate", M2Share.g_Config.nArmRing26ACAddRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26MACAddValueMaxLimit", M2Share.g_Config.nArmRing26MACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "ArmRing26MACAddValueRate", M2Share.g_Config.nArmRing26MACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "ArmRing26MACAddRate", M2Share.g_Config.nArmRing26MACAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring23DCAddRate", M2Share.g_Config.nRing23DCAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring23DCAddValueMaxLimit", M2Share.g_Config.nRing23DCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring23DCAddValueRate", M2Share.g_Config.nRing23DCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring23MCAddRate", M2Share.g_Config.nRing23MCAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring23MCAddValueMaxLimit", M2Share.g_Config.nRing23MCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring23MCAddValueRate", M2Share.g_Config.nRing23MCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring23SCAddRate", M2Share.g_Config.nRing23SCAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring23SCAddValueMaxLimit", M2Share.g_Config.nRing23SCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring23SCAddValueRate", M2Share.g_Config.nRing23SCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring23ACAddValueMaxLimit", M2Share.g_Config.nRing23ACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring23ACAddValueRate", M2Share.g_Config.nRing23ACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring23ACAddRate", M2Share.g_Config.nRing23ACAddRate);

            M2Share.Config.WriteInteger("Setup", "Ring23MACAddValueMaxLimit", M2Share.g_Config.nRing23MACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "Ring23MACAddValueRate", M2Share.g_Config.nRing23MACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "Ring23MACAddRate", M2Share.g_Config.nRing23MACAddRate);

            M2Share.Config.WriteInteger("Setup", "BootsDCAddValueMaxLimit", M2Share.g_Config.nBootsDCAddValueMaxLimit);// 极品鞋子加攻最高点

            M2Share.Config.WriteInteger("Setup", "BootsDCAddValueRate", M2Share.g_Config.nBootsDCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "BootsDCAddRate", M2Share.g_Config.nBootsDCAddRate);// 极品鞋子加道术

            M2Share.Config.WriteInteger("Setup", "BootsSCAddValueMaxLimit", M2Share.g_Config.nBootsSCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "BootsSCAddValueRate", M2Share.g_Config.nBootsSCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "BootsSCAddRate", M2Share.g_Config.nBootsSCAddRate);// 极品鞋子加魔法

            M2Share.Config.WriteInteger("Setup", "BootsMCAddValueMaxLimit", M2Share.g_Config.nBootsMCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "BootsMCAddValueRate", M2Share.g_Config.nBootsMCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "BootsMCAddRate", M2Share.g_Config.nBootsMCAddRate);// 极品鞋子加防御

            M2Share.Config.WriteInteger("Setup", "BootsACAddValueMaxLimit", M2Share.g_Config.nBootsACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "BootsACAddValueRate", M2Share.g_Config.nBootsACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "BootsACAddRate", M2Share.g_Config.nBootsACAddRate);// 极品鞋子加魔御

            M2Share.Config.WriteInteger("Setup", "BootsMACAddValueMaxLimit", M2Share.g_Config.nBootsMACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "BootsMACAddValueRate", M2Share.g_Config.nBootsMACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "BootsMACAddRate", M2Share.g_Config.nBootsMACAddRate);

            M2Share.Config.WriteInteger("Setup", "HelMetDCAddRate", M2Share.g_Config.nHelMetDCAddRate);

            M2Share.Config.WriteInteger("Setup", "HelMetDCAddValueMaxLimit", M2Share.g_Config.nHelMetDCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "HelMetDCAddValueRate", M2Share.g_Config.nHelMetDCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "HelMetMCAddRate", M2Share.g_Config.nHelMetMCAddRate);

            M2Share.Config.WriteInteger("Setup", "HelMetMCAddValueMaxLimit", M2Share.g_Config.nHelMetMCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "HelMetMCAddValueRate", M2Share.g_Config.nHelMetMCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "HelMetSCAddRate", M2Share.g_Config.nHelMetSCAddRate);

            M2Share.Config.WriteInteger("Setup", "HelMetSCAddValueMaxLimit", M2Share.g_Config.nHelMetSCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "HelMetSCAddValueRate", M2Share.g_Config.nHelMetSCAddValueRate);

            M2Share.Config.WriteInteger("Setup", "HelMetACAddValueMaxLimit", M2Share.g_Config.nHelMetACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "HelMetACAddValueRate", M2Share.g_Config.nHelMetACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "HelMetACAddRate", M2Share.g_Config.nHelMetACAddRate);

            M2Share.Config.WriteInteger("Setup", "HelMetMACAddValueMaxLimit", M2Share.g_Config.nHelMetMACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "HelMetMACAddValueRate", M2Share.g_Config.nHelMetMACAddValueRate);

            M2Share.Config.WriteInteger("Setup", "HelMetMACAddRate", M2Share.g_Config.nHelMetMACAddRate);
            uModValue();
        }

        public void EditMonRandomAddValueChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMonRandomAddValue = (byte)EditMonRandomAddValue.Value;
            ModValue();
        }

        public void EditMakeRandomAddValueChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMakeRandomAddValue = (byte)EditMakeRandomAddValue.Value;
            ModValue();
        }

        public void EditWeaponDCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponDCAddValueMaxLimit = (byte)EditWeaponDCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditWeaponDCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponDCAddValueRate = (byte)EditWeaponDCAddValueRate.Value;
            ModValue();
        }

        public void EditWeaponMCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMCAddValueMaxLimit = (byte)EditWeaponMCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditWeaponMCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMCAddValueRate = (byte)EditWeaponMCAddValueRate.Value;
            ModValue();
        }

        public void EditWeaponSCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponSCAddValueMaxLimit = (byte)EditWeaponSCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditWeaponSCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponSCAddValueRate = (byte)EditWeaponSCAddValueRate.Value;
            ModValue();
        }

        public void EditDressDCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressDCAddValueMaxLimit = (byte)EditDressDCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditDressDCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressDCAddValueRate = (byte)EditDressDCAddValueRate.Value;
            ModValue();
        }

        public void EditDressMCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressMCAddValueMaxLimit = (byte)EditDressMCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditDressMCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressMCAddValueRate = (byte)EditDressMCAddValueRate.Value;
            ModValue();
        }

        public void EditDressSCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressSCAddValueMaxLimit = (byte)EditDressSCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditDressSCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressSCAddValueRate = (byte)EditDressSCAddValueRate.Value;
            ModValue();
        }

        public void EditDressDCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressDCAddRate = (byte)EditDressDCAddRate.Value;
            ModValue();
        }

        public void EditDressMCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressMCAddRate = (byte)EditDressMCAddRate.Value;
            ModValue();
        }

        public void EditDressSCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressSCAddRate = (byte)EditDressSCAddRate.Value;
            ModValue();
        }

        public void EditNeckLace19DCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19DCAddValueMaxLimit = (byte)EditNeckLace19DCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace19DCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19DCAddValueRate = (byte)EditNeckLace19DCAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace19MCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19MCAddValueMaxLimit = (byte)EditNeckLace19MCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace19MCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19MCAddValueRate = (byte)EditNeckLace19MCAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace19SCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19SCAddValueMaxLimit = (byte)EditNeckLace19SCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace19SCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19SCAddValueRate = (byte)EditNeckLace19SCAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace19DCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19DCAddRate = (byte)EditNeckLace19DCAddRate.Value;
            ModValue();
        }

        public void EditNeckLace19MCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19MCAddRate = (byte)EditNeckLace19MCAddRate.Value;
            ModValue();
        }

        public void EditNeckLace19SCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19SCAddRate = (byte)EditNeckLace19SCAddRate.Value;
            ModValue();
        }

        public void EditNeckLace202124DCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124DCAddValueMaxLimit = (byte)EditNeckLace202124DCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace202124DCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124DCAddValueRate = (byte)EditNeckLace202124DCAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace202124MCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124MCAddValueMaxLimit = (byte)EditNeckLace202124MCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace202124MCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124MCAddValueRate = (byte)EditNeckLace202124MCAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace202124SCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124SCAddValueMaxLimit = (byte)EditNeckLace202124SCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace202124SCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124SCAddValueRate = (byte)EditNeckLace202124SCAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace202124DCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124DCAddRate = (byte)EditNeckLace202124DCAddRate.Value;
            ModValue();
        }

        public void EditNeckLace202124MCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124MCAddRate = (byte)EditNeckLace202124MCAddRate.Value;
            ModValue();
        }

        public void EditNeckLace202124SCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124SCAddRate = (byte)EditNeckLace202124SCAddRate.Value;
            ModValue();
        }

        public void EditArmRing26DCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26DCAddValueMaxLimit = (byte)EditArmRing26DCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditArmRing26DCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26DCAddValueRate = (byte)EditArmRing26DCAddValueRate.Value;
            ModValue();
        }

        public void EditArmRing26MCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26MCAddValueMaxLimit = (byte)EditArmRing26MCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditArmRing26MCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26MCAddValueRate = (byte)EditArmRing26MCAddValueRate.Value;
            ModValue();
        }

        public void EditArmRing26SCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26SCAddValueMaxLimit = (byte)EditArmRing26SCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditArmRing26SCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26SCAddValueRate = (byte)EditArmRing26SCAddValueRate.Value;
            ModValue();
        }

        public void EditArmRing26DCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26DCAddRate = (byte)EditArmRing26DCAddRate.Value;
            ModValue();
        }

        public void EditArmRing26MCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26MCAddRate = (byte)EditArmRing26MCAddRate.Value;
            ModValue();
        }

        public void EditArmRing26SCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26SCAddRate = (byte)EditArmRing26SCAddRate.Value;
            ModValue();
        }

        public void EditRing22DCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22DCAddValueMaxLimit = (byte)EditRing22DCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing22DCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22DCAddValueRate = (byte)EditRing22DCAddValueRate.Value;
            ModValue();
        }

        public void EditRing22MCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22MCAddValueMaxLimit = (byte)EditRing22MCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing22MCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22MCAddValueRate = (byte)EditRing22MCAddValueRate.Value;
            ModValue();
        }

        public void EditRing22SCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22SCAddValueMaxLimit = (byte)EditRing22SCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing22SCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22SCAddValueRate = (byte)EditRing22SCAddValueRate.Value;
            ModValue();
        }

        public void EditRing22DCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22DCAddRate = (byte)EditRing22DCAddRate.Value;
            ModValue();
        }

        public void EditRing22MCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22MCAddRate = (byte)EditRing22MCAddRate.Value;
            ModValue();
        }

        public void EditRing22SCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing22SCAddRate = (byte)EditRing22SCAddRate.Value;
            ModValue();
        }

        public void EditRing23DCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23DCAddValueMaxLimit = (byte)EditRing23DCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing23DCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23DCAddValueRate = (byte)EditRing23DCAddValueRate.Value;
            ModValue();
        }

        public void EditRing23MCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23MCAddValueMaxLimit = (byte)EditRing23MCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing23MCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23MCAddValueRate = (byte)EditRing23MCAddValueRate.Value;
            ModValue();
        }

        public void EditRing23SCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23SCAddValueMaxLimit = (byte)EditRing23SCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing23SCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23SCAddValueRate = (byte)EditRing23SCAddValueRate.Value;
            ModValue();
        }

        public void EditRing23DCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23DCAddRate = (byte)EditRing23DCAddRate.Value;
            ModValue();
        }

        public void EditRing23MCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23MCAddRate = (byte)EditRing23MCAddRate.Value;
            ModValue();
        }

        public void EditRing23SCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23SCAddRate = (byte)EditRing23SCAddRate.Value;
            ModValue();
        }

        public void EditHelMetDCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetDCAddValueMaxLimit = (byte)EditHelMetDCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditHelMetDCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetDCAddValueRate = (byte)EditHelMetDCAddValueRate.Value;
            ModValue();
        }

        public void EditHelMetMCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetMCAddValueMaxLimit = (byte)EditHelMetMCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditHelMetMCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetMCAddValueRate = (byte)EditHelMetMCAddValueRate.Value;
            ModValue();
        }

        public void EditHelMetSCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetSCAddValueMaxLimit = (byte)EditHelMetSCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditHelMetSCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetSCAddValueRate = (byte)EditHelMetSCAddValueRate.Value;
            ModValue();
        }

        public void EditHelMetDCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetDCAddRate = (byte)EditHelMetDCAddRate.Value;
            ModValue();
        }

        public void EditHelMetMCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetMCAddRate = (byte)EditHelMetMCAddRate.Value;
            ModValue();
        }

        public void EditHelMetSCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetSCAddRate = (byte)EditHelMetSCAddRate.Value;
            ModValue();
        }

        public void EditGuildRecallTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nGuildRecallTime = (byte)EditGuildRecallTime.Value;
            ModValue();
        }

        public void ButtonUnKnowItemSaveClick(object sender, EventArgs e)
        {

            M2Share.Config.WriteInteger("Setup", "UnknowRingACAddRate", M2Share.g_Config.nUnknowRingACAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowRingACAddValueMaxLimit", M2Share.g_Config.nUnknowRingACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowRingMACAddRate", M2Share.g_Config.nUnknowRingMACAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowRingMACAddValueMaxLimit", M2Share.g_Config.nUnknowRingMACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowRingDCAddRate", M2Share.g_Config.nUnknowRingDCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowRingDCAddValueMaxLimit", M2Share.g_Config.nUnknowRingDCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowRingMCAddRate", M2Share.g_Config.nUnknowRingMCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowRingMCAddValueMaxLimit", M2Share.g_Config.nUnknowRingMCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowRingSCAddRate", M2Share.g_Config.nUnknowRingSCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowRingSCAddValueMaxLimit", M2Share.g_Config.nUnknowRingSCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceACAddRate", M2Share.g_Config.nUnknowNecklaceACAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceACAddValueMaxLimit", M2Share.g_Config.nUnknowNecklaceACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceMACAddRate", M2Share.g_Config.nUnknowNecklaceMACAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceMACAddValueMaxLimit", M2Share.g_Config.nUnknowNecklaceMACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceDCAddRate", M2Share.g_Config.nUnknowNecklaceDCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceDCAddValueMaxLimit", M2Share.g_Config.nUnknowNecklaceDCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceMCAddRate", M2Share.g_Config.nUnknowNecklaceMCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceMCAddValueMaxLimit", M2Share.g_Config.nUnknowNecklaceMCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceSCAddRate", M2Share.g_Config.nUnknowNecklaceSCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowNecklaceSCAddValueMaxLimit", M2Share.g_Config.nUnknowNecklaceSCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetACAddRate", M2Share.g_Config.nUnknowHelMetACAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetACAddValueMaxLimit", M2Share.g_Config.nUnknowHelMetACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetMACAddRate", M2Share.g_Config.nUnknowHelMetMACAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetMACAddValueMaxLimit", M2Share.g_Config.nUnknowHelMetMACAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetDCAddRate", M2Share.g_Config.nUnknowHelMetDCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetDCAddValueMaxLimit", M2Share.g_Config.nUnknowHelMetDCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetMCAddRate", M2Share.g_Config.nUnknowHelMetMCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetMCAddValueMaxLimit", M2Share.g_Config.nUnknowHelMetMCAddValueMaxLimit);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetSCAddRate", M2Share.g_Config.nUnknowHelMetSCAddRate);

            M2Share.Config.WriteInteger("Setup", "UnknowHelMetSCAddValueMaxLimit", M2Share.g_Config.nUnknowHelMetSCAddValueMaxLimit);
            uModValue();
        }

        private void RefUnknowItem()
        {
            EditUnknowRingDCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowRingDCAddValueMaxLimit;
            EditUnknowRingDCAddRate.Value = M2Share.g_Config.nUnknowRingDCAddRate;
            EditUnknowRingMCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowRingMCAddValueMaxLimit;
            EditUnknowRingMCAddRate.Value = M2Share.g_Config.nUnknowRingMCAddRate;
            EditUnknowRingSCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowRingSCAddValueMaxLimit;
            EditUnknowRingSCAddRate.Value = M2Share.g_Config.nUnknowRingSCAddRate;
            EditUnknowRingACAddValueMaxLimit.Value = M2Share.g_Config.nUnknowRingACAddValueMaxLimit;
            EditUnknowRingACAddRate.Value = M2Share.g_Config.nUnknowRingACAddRate;
            EditUnknowRingMACAddValueMaxLimit.Value = M2Share.g_Config.nUnknowRingMACAddValueMaxLimit;
            EditUnknowRingMACAddRate.Value = M2Share.g_Config.nUnknowRingMACAddRate;
            EditUnknowNecklaceDCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowNecklaceDCAddValueMaxLimit;
            EditUnknowNecklaceDCAddRate.Value = M2Share.g_Config.nUnknowNecklaceDCAddRate;
            EditUnknowNecklaceMCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowNecklaceMCAddValueMaxLimit;
            EditUnknowNecklaceMCAddRate.Value = M2Share.g_Config.nUnknowNecklaceMCAddRate;
            EditUnknowNecklaceSCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowNecklaceSCAddValueMaxLimit;
            EditUnknowNecklaceSCAddRate.Value = M2Share.g_Config.nUnknowNecklaceSCAddRate;
            EditUnknowNecklaceACAddValueMaxLimit.Value = M2Share.g_Config.nUnknowNecklaceACAddValueMaxLimit;
            EditUnknowNecklaceACAddRate.Value = M2Share.g_Config.nUnknowNecklaceACAddRate;
            EditUnknowNecklaceMACAddValueMaxLimit.Value = M2Share.g_Config.nUnknowNecklaceMACAddValueMaxLimit;
            EditUnknowNecklaceMACAddRate.Value = M2Share.g_Config.nUnknowNecklaceMACAddRate;
            EditUnknowHelMetDCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowHelMetDCAddValueMaxLimit;
            EditUnknowHelMetDCAddRate.Value = M2Share.g_Config.nUnknowHelMetDCAddRate;
            EditUnknowHelMetMCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowHelMetMCAddValueMaxLimit;
            EditUnknowHelMetMCAddRate.Value = M2Share.g_Config.nUnknowHelMetMCAddRate;
            EditUnknowHelMetSCAddValueMaxLimit.Value = M2Share.g_Config.nUnknowHelMetSCAddValueMaxLimit;
            EditUnknowHelMetSCAddRate.Value = M2Share.g_Config.nUnknowHelMetSCAddRate;
            EditUnknowHelMetACAddValueMaxLimit.Value = M2Share.g_Config.nUnknowHelMetACAddValueMaxLimit;
            EditUnknowHelMetACAddRate.Value = M2Share.g_Config.nUnknowHelMetACAddRate;
            EditUnknowHelMetMACAddValueMaxLimit.Value = M2Share.g_Config.nUnknowHelMetMACAddValueMaxLimit;
            EditUnknowHelMetMACAddRate.Value = M2Share.g_Config.nUnknowHelMetMACAddRate;
        }

        public void EditUnknowRingDCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingDCAddValueMaxLimit = (byte)EditUnknowRingDCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowRingDCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingDCAddRate = (byte)EditUnknowRingDCAddRate.Value;
            ModValue();
        }

        public void EditUnknowRingMCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingMCAddValueMaxLimit = (byte)EditUnknowRingMCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowRingMCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingMCAddRate = (byte)EditUnknowRingMCAddRate.Value;
            ModValue();
        }

        public void EditUnknowRingSCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingSCAddValueMaxLimit = (byte)EditUnknowRingSCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowRingSCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingSCAddRate = (byte)EditUnknowRingSCAddRate.Value;
            ModValue();
        }

        public void EditUnknowRingACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingACAddValueMaxLimit = (byte)EditUnknowRingACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowRingACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingACAddRate = (byte)EditUnknowRingACAddRate.Value;
            ModValue();
        }

        public void EditUnknowRingMACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingMACAddValueMaxLimit = (byte)EditUnknowRingMACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowRingMACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowRingMACAddRate = (byte)EditUnknowRingMACAddRate.Value;
            ModValue();
        }

        public void EditUnknowNecklaceDCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceDCAddValueMaxLimit = (byte)EditUnknowNecklaceDCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowNecklaceDCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceDCAddRate = (byte)EditUnknowNecklaceDCAddRate.Value;
            ModValue();
        }

        public void EditUnknowNecklaceMCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceMCAddValueMaxLimit = (byte)EditUnknowNecklaceMCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowNecklaceMCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceMCAddRate = (byte)EditUnknowNecklaceMCAddRate.Value;
            ModValue();
        }

        public void EditUnknowNecklaceSCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceSCAddValueMaxLimit = (byte)EditUnknowNecklaceSCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowNecklaceSCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceSCAddRate = (byte)EditUnknowNecklaceSCAddRate.Value;
            ModValue();
        }

        public void EditUnknowNecklaceACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceACAddValueMaxLimit = (byte)EditUnknowNecklaceACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowNecklaceACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceACAddRate = (byte)EditUnknowNecklaceACAddRate.Value;
            ModValue();
        }

        public void EditUnknowNecklaceMACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceMACAddValueMaxLimit = (byte)EditUnknowNecklaceMACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowNecklaceMACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowNecklaceMACAddRate = (byte)EditUnknowNecklaceMACAddRate.Value;
            ModValue();
        }

        public void EditUnknowHelMetDCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetDCAddValueMaxLimit = (byte)EditUnknowHelMetDCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowHelMetDCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetDCAddRate = (byte)EditUnknowHelMetDCAddRate.Value;
            ModValue();
        }

        public void EditUnknowHelMetMCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetMCAddValueMaxLimit = (byte)EditUnknowHelMetMCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowHelMetMCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetMCAddRate = (byte)EditUnknowHelMetMCAddRate.Value;
            ModValue();
        }

        public void EditUnknowHelMetSCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetSCAddValueMaxLimit = (byte)EditUnknowHelMetSCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowHelMetSCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetSCAddRate = (byte)EditUnknowHelMetSCAddRate.Value;
            ModValue();
        }

        public void EditUnknowHelMetACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetACAddValueMaxLimit = (byte)EditUnknowHelMetACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowHelMetACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetACAddRate = (byte)EditUnknowHelMetACAddRate.Value;
            ModValue();
        }

        public void EditUnknowHelMetMACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetMACAddValueMaxLimit = (byte)EditUnknowHelMetMACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditUnknowHelMetMACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nUnknowHelMetMACAddRate = (byte)EditUnknowHelMetMACAddRate.Value;
            ModValue();
        }

        private void RefShapeItem()
        {
            EditAttackPosionRate.Value = M2Share.g_Config.nAttackPosionRate;
            EditAttackPosionTime.Value = M2Share.g_Config.nAttackPosionTime;
            CheckBoxUserMoveCanDupObj.Checked = M2Share.g_Config.boUserMoveCanDupObj;
            CheckBoxUserMoveCanOnItem.Checked = M2Share.g_Config.boUserMoveCanOnItem;
            EditUserMoveTime.Value = M2Share.g_Config.dwUserMoveTime;
        }

        public void EditAttackPosionRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nAttackPosionRate = (byte)EditAttackPosionRate.Value;
            ModValue();
        }

        public void EditAttackPosionTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nAttackPosionTime = (byte)EditAttackPosionTime.Value;
            ModValue();
        }

        public void CheckBoxUserMoveCanDupObjClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boUserMoveCanDupObj = CheckBoxUserMoveCanDupObj.Checked;
            ModValue();
        }

        public void CheckBoxUserMoveCanOnItemClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boUserMoveCanOnItem = CheckBoxUserMoveCanOnItem.Checked;
            ModValue();
        }

        public void EditUserMoveTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwUserMoveTime = (byte)EditUserMoveTime.Value;
            ModValue();
        }

        // 斗笠可带选项 20080417
        public void RadioHumHeroUseClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            if (RadioHumHeroUse.Checked)
            {
                M2Share.g_Config.nIsUseZhuLi = 0;
            }
            if (RadioHumUse.Checked)
            {
                M2Share.g_Config.nIsUseZhuLi = 1;
            }
            if (RadioHeroUse.Checked)
            {
                M2Share.g_Config.nIsUseZhuLi = 2;
            }
            ModValue();
        }

        // 带上斗笠是否显示神秘人 20080424
        public void CheckBoxUnKnowHumClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boUnKnowHum = CheckBoxUnKnowHum.Checked;
            ModValue();
        }

        // 20080503 极品鞋子加攻最高点
        public void EditBootsDCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsDCAddValueMaxLimit = (byte)EditBootsDCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditBootsDCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsDCAddValueRate = (byte)EditBootsDCAddValueRate.Value;
            ModValue();
        }

        public void EditBootsDCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsDCAddRate = (byte)EditBootsDCAddRate.Value;
            ModValue();
        }

        public void EditBootsSCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsSCAddValueMaxLimit = (byte)EditBootsSCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditBootsSCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsSCAddValueRate = (byte)EditBootsSCAddValueRate.Value;
            ModValue();
        }

        public void EditBootsSCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsSCAddRate = (byte)EditBootsSCAddRate.Value;
            ModValue();
        }

        public void EditBootsMCAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsMCAddValueMaxLimit = (byte)EditBootsMCAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditBootsMCAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsMCAddValueRate = (byte)EditBootsMCAddValueRate.Value;
            ModValue();
        }

        public void EditBootsMCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsMCAddRate = (byte)EditBootsMCAddRate.Value;
            ModValue();
        }

        public void EditBootsACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsACAddValueMaxLimit = (byte)EditBootsACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditBootsACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsACAddValueRate = (byte)EditBootsACAddValueRate.Value;
            ModValue();
        }

        public void EditBootsACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsACAddRate = (byte)EditBootsACAddRate.Value;
            ModValue();
        }

        public void EditBootsMACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsMACAddValueMaxLimit = (byte)EditBootsMACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditBootsMACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsMACAddValueRate = (byte)EditBootsMACAddValueRate.Value;
            ModValue();
        }

        public void EditBootsMACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nBootsMACAddRate = (byte)EditBootsMACAddRate.Value;
            ModValue();
        }

        public void EditHelMetACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetACAddValueMaxLimit = (byte)EditHelMetACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditHelMetACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetACAddValueRate = (byte)EditHelMetACAddValueRate.Value;
            ModValue();
        }

        public void EditHelMetACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetACAddRate = (byte)EditHelMetACAddRate.Value;
            ModValue();
        }

        public void EditHelMetMACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetMACAddValueMaxLimit = (byte)EditHelMetMACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditHelMetMACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetMACAddValueRate = (byte)EditHelMetMACAddValueRate.Value;
            ModValue();
        }

        public void EditHelMetMACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nHelMetMACAddRate = (byte)EditHelMetMACAddRate.Value;
            ModValue();
        }

        public void EditRing23ACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23ACAddValueMaxLimit = (byte)EditRing23ACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing23ACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23ACAddValueRate = (byte)EditRing23ACAddValueRate.Value;
            ModValue();
        }

        public void EditRing23ACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23ACAddRate = (byte)EditRing23ACAddRate.Value;
            ModValue();
        }

        public void EditRing23MACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23MACAddValueMaxLimit = (byte)EditRing23MACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditRing23MACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23MACAddValueRate = (byte)EditRing23MACAddValueRate.Value;
            ModValue();
        }

        public void EditRing23MACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nRing23MACAddRate = (byte)EditRing23MACAddRate.Value;
            ModValue();
        }

        public void EditNeckLace19ACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19ACAddValueMaxLimit = (byte)EditNeckLace19ACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace19ACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19ACAddValueRate = (byte)EditNeckLace19ACAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace19ACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19ACAddRate = (byte)EditNeckLace19ACAddRate.Value;
            ModValue();
        }

        public void EditNeckLace19MACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19MACAddValueMaxLimit = (byte)EditNeckLace19MACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace19MACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19MACAddValueRate = (byte)EditNeckLace19MACAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace19MACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace19MACAddRate = (byte)EditNeckLace19MACAddRate.Value;
            ModValue();
        }

        public void EditArmRing26ACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26ACAddValueMaxLimit = (byte)EditArmRing26ACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditArmRing26ACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26ACAddValueRate = (byte)EditArmRing26ACAddValueRate.Value;
            ModValue();
        }

        public void EditArmRing26ACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26ACAddRate = (byte)EditArmRing26ACAddRate.Value;
            ModValue();
        }

        public void EditArmRing26MACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26MACAddValueMaxLimit = (byte)EditArmRing26MACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditArmRing26MACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26MACAddValueRate = (byte)EditArmRing26MACAddValueRate.Value;
            ModValue();
        }

        public void EditArmRing26MACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nArmRing26MACAddRate = (byte)EditArmRing26MACAddRate.Value;
            ModValue();
        }

        public void EditNeckLace202124ACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124ACAddValueMaxLimit = (byte)EditNeckLace202124ACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace202124ACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124ACAddValueRate = (byte)EditNeckLace202124ACAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace202124ACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124ACAddRate = (byte)EditNeckLace202124ACAddRate.Value;
            ModValue();
        }

        public void EditNeckLace202124MACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124MACAddValueMaxLimit = (byte)EditNeckLace202124MACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditNeckLace202124MACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124MACAddValueRate = (byte)EditNeckLace202124MACAddValueRate.Value;
            ModValue();
        }

        public void EditNeckLace202124MACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nNeckLace202124MACAddRate = (byte)EditNeckLace202124MACAddRate.Value;
            ModValue();
        }

        public void EditDressACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressACAddValueMaxLimit = (byte)EditDressACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditDressACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressACAddValueRate = (byte)EditDressACAddValueRate.Value;
            ModValue();
        }

        public void EditDressACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressACAddRate = (byte)EditDressACAddRate.Value;
            ModValue();
        }

        public void EditDressMACAddValueMaxLimitChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressMACAddValueMaxLimit = (byte)EditDressMACAddValueMaxLimit.Value;
            ModValue();
        }

        public void EditDressMACAddValueRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressMACAddValueRate = (byte)EditDressMACAddValueRate.Value;
            ModValue();
        }

        public void EditDressMACAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nDressMACAddRate = (byte)EditDressMACAddRate.Value;
            ModValue();
        }

        public void EditWeaponDCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponDCAddRate = (byte)EditWeaponDCAddRate.Value;
            ModValue();
        }

        public void EditWeaponSCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponSCAddRate = (byte)EditWeaponSCAddRate.Value;
            ModValue();
        }

        public void EditWeaponMCAddRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nWeaponMCAddRate = (byte)EditWeaponMCAddRate.Value;
            ModValue();
        }

        // 人形身上装备极品机率 20080716
        public void EditPlayMonRandomAddValueChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nPlayMonRandomAddValue = (byte)EditPlayMonRandomAddValue.Value;
            ModValue();
        }
    }
}

