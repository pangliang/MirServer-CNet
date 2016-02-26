using System;
using System.Windows.Forms;
using GameFramework;

namespace M2Server
{
    public partial class TFrmServerValue: Form
    {
        public static TFrmServerValue FrmServerValue = null;
        private bool boOpened = false;
        private bool boModValued = false;

        public TFrmServerValue()
        {
            InitializeComponent();
        }

        private void ModValue()
        {
            boModValued = true;
            BitBtn1.Enabled = true;
        }

        private void uModValue()
        {
            boModValued = false;
            BitBtn1.Enabled = false;
        }

        public bool AdjuestServerConfig()
        {
            bool result;
            boOpened = false;
            uModValue();
            RefShow();
            boOpened = true;
            this.ShowDialog();
            result = true;
            return result;
        }

        public void BitBtn1Click(object sender, EventArgs e)
        {
            string tBool;
            M2Share.Config.WriteInteger("Server", "HumLimit", M2Share.g_dwHumLimit);
            M2Share.Config.WriteInteger("Server", "MonLimit", M2Share.g_dwMonLimit);
            M2Share.Config.WriteInteger("Server", "ZenLimit", M2Share.g_dwZenLimit);
            M2Share.Config.WriteInteger("Server", "SocLimit", M2Share.g_dwSocLimit);
            M2Share.Config.WriteInteger("Server", "DecLimit", M2Share.nDecLimit);
            M2Share.Config.WriteInteger("Server", "NpcLimit", M2Share.g_dwNpcLimit);
            M2Share.Config.WriteInteger("Server", "SendBlock", M2Share.g_Config.nSendBlock);
            M2Share.Config.WriteInteger("Server", "CheckBlock", M2Share.g_Config.nCheckBlock);
            M2Share.Config.WriteInteger("Server", "GateLoad", M2Share.g_Config.nGateLoad);
            if (M2Share.g_Config.boViewHackMessage)
            {
                tBool = "TRUE";
            }
            else
            {
                tBool = "FLASE";
            }
            M2Share.Config.WriteString("Server", "ViewHackMessage", tBool);
            if (M2Share.g_Config.boViewAdmissionFailure)
            {
                tBool = "TRUE";
            }
            else
            {
                tBool = "FLASE";
            }
            M2Share.Config.WriteString("Server", "ViewAdmissionFailure", tBool);
            M2Share.Config.WriteInteger("Setup", "GenMonRate", M2Share.g_Config.nMonGenRate);
            M2Share.Config.WriteInteger("Server", "ProcessMonstersTime", M2Share.g_Config.dwProcessMonstersTime);
            M2Share.Config.WriteInteger("Server", "RegenMonstersTime", M2Share.g_Config.dwRegenMonstersTime);
            uModValue();
        }

        public void EditZenMonRateChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nMonGenRate = (ushort)EditZenMonRate.Value;
            ModValue();
        }

        public void EditZenMonTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwRegenMonstersTime = (uint)EditZenMonTime.Value;
            ModValue();
        }

        public void EditProcessTimeChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.dwProcessMonstersTime = (uint)EditProcessTime.Value;
            ModValue();
        }

        public void ESendBlockChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nSendBlock = HUtil32._MAX(10, (int)ESendBlock.Value);
            ModValue();
        }

        public void ECheckBlockChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nCheckBlock = HUtil32._MAX(10, (int)ECheckBlock.Value);
            ModValue();
        }

        public void EGateLoadChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nGateLoad = (int)EGateLoad.Value;
            ModValue();
        }

        public void EHumChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_dwHumLimit = (uint)HUtil32._MIN(150, (int)EHum.Value);
            ModValue();
        }

        public void EMonChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_dwMonLimit = (uint)HUtil32._MIN(150, (int)EMon.Value);
            ModValue();
        }

        public void EZenChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_dwZenLimit = (uint)HUtil32._MIN(150, (int)EZen.Value);
            ModValue();
        }

        public void ESocChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_dwSocLimit = (uint)HUtil32._MIN(150, (int)ESoc.Value);
            ModValue();
        }

        public void ENpcChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_dwNpcLimit = (uint)HUtil32._MIN(150, (int)ENpc.Value);
            ModValue();
        }

        public void EAvailableBlockChange(Object Sender)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.nAvailableBlock = HUtil32._MAX(10, (int)EAvailableBlock.Value);
            ModValue();
        }

        public void CbViewHackClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boViewHackMessage = CbViewHack.Checked;
            ModValue();
        }

        public void CkViewAdmfailClick(object sender, EventArgs e)
        {
            if (!boOpened)
            {
                return;
            }
            M2Share.g_Config.boViewAdmissionFailure = CkViewAdmfail.Checked;
            ModValue();
        }

        private void RefShow()
        {
            EHum.Value = M2Share.g_dwHumLimit;
            EMon.Value = M2Share.g_dwMonLimit;
            EZen.Value = M2Share.g_dwZenLimit;
            ESoc.Value = M2Share.g_dwSocLimit;
            EDec.Value = M2Share.nDecLimit;
            ENpc.Value = M2Share.g_dwNpcLimit;
            ESendBlock.Value = M2Share.g_Config.nSendBlock;
            ECheckBlock.Value = M2Share.g_Config.nCheckBlock;
            EAvailableBlock.Value = M2Share.g_Config.nAvailableBlock;
            EGateLoad.Value = M2Share.g_Config.nGateLoad;
            CbViewHack.Checked = M2Share.g_Config.boViewHackMessage;
            CkViewAdmfail.Checked = M2Share.g_Config.boViewAdmissionFailure;
            EditZenMonRate.Value = M2Share.g_Config.nMonGenRate;
            EditZenMonTime.Value = M2Share.g_Config.dwRegenMonstersTime;
            EditProcessTime.Value = M2Share.g_Config.dwProcessMonstersTime;
        }

        public void ButtonDefaultClick(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("是否确认恢复默认设置？", "确认信息", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            M2Share.g_dwHumLimit = 30;
            M2Share.g_dwMonLimit = 10;
            M2Share.g_dwZenLimit = 5;
            M2Share.g_dwSocLimit = 10;
            M2Share.nDecLimit = 20;
            M2Share.g_dwNpcLimit = 5;
            M2Share.g_Config.nSendBlock = 1024;
            M2Share.g_Config.nCheckBlock = 9500;
            M2Share.g_Config.nAvailableBlock = 8000;
            M2Share.g_Config.nGateLoad = 0;
            M2Share.g_Config.boViewHackMessage = false;
            M2Share.g_Config.boViewAdmissionFailure = false;
            M2Share.g_Config.nMonGenRate = 10;
            M2Share.g_Config.dwRegenMonstersTime = 200;
            M2Share.g_Config.dwProcessMonstersTime = 50;
            RefShow();
        }
    } 
}