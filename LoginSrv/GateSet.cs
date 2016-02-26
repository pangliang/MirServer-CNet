using GameFramework;
using System;
using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TFrmGateSetting : Form
    {
        private TextBox[] EdGate = new TextBox[10];
        private CheckBox[] CkGate = new CheckBox[10];
        public static TFrmGateSetting FrmGateSetting = null;

        public TFrmGateSetting()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            EdGate[0] = EdGate1;
            EdGate[1] = EdGate2;
            EdGate[2] = EdGate3;
            EdGate[3] = EdGate4;
            EdGate[4] = EdGate5;
            EdGate[5] = EdGate6;
            EdGate[6] = EdGate7;
            EdGate[7] = EdGate8;
            EdGate[8] = EdGate9;
            EdGate[9] = EdGate10;
            CkGate[0] = CkGate1;
            CkGate[1] = CkGate2;
            CkGate[2] = CkGate3;
            CkGate[3] = CkGate4;
            CkGate[4] = CkGate5;
            CkGate[5] = CkGate6;
            CkGate[6] = CkGate7;
            CkGate[7] = CkGate8;
            CkGate[8] = CkGate9;
            CkGate[9] = CkGate10;
        }

        public void FormDestroy(Object Sender)
        {
        }

        // 00464EEC
        public void CbGateListChange(System.Object Sender, System.EventArgs _e1)
        {
            int I;
            int nGateIdx;
            int nSelTitlIdx;
            int nSelRouteIdx;
            int nSelServerIdx;
            string sTitle;
            string sServerName;
            TConfig Config;
            Config = LSShare.g_Config;
            nSelServerIdx = CbServerList.SelectedIndex;
            if (nSelServerIdx < 0)
            {
                return;
            }
            sServerName = CbServerList.Items[nSelServerIdx].ToString();
            nSelTitlIdx = CbGateList.SelectedIndex;
            if (nSelTitlIdx < 0)
            {
                return;
            }
            sTitle = CbGateList.Items[nSelTitlIdx].ToString();
            EdTitle.Text = sTitle;
            nSelRouteIdx = -1;
            for (I = Config.GateRoute.GetLowerBound(0); I <= Config.GateRoute.GetUpperBound(0); I++)
            {
                if (Config.GateRoute[I].sTitle == sTitle)
                {
                    nSelRouteIdx = I;
                    break;
                }
            }
            if (nSelRouteIdx < 0)
            {
                return;
            }
            EdPrivateAddr.Text = Config.GateRoute[nSelRouteIdx].sRemoteAddr;
            EdPublicAddr.Text = Config.GateRoute[nSelRouteIdx].sPublicAddr;
            nGateIdx = 0;
            while (true)
            {
                if (Config.GateRoute[nSelRouteIdx].Gate[nGateIdx].sIPaddr != "")
                {
                    EdGate[nGateIdx].Text = Config.GateRoute[nSelRouteIdx].Gate[nGateIdx].sIPaddr + ':' + (Config.GateRoute[nSelRouteIdx].Gate[nGateIdx].nPort).ToString();
                }
                else
                {
                    EdGate[nGateIdx].Text = "";
                }
                CkGate[nGateIdx].Checked = Config.GateRoute[nSelRouteIdx].Gate[nGateIdx].boEnable;
                nGateIdx++;
                if (nGateIdx >= 10)
                {
                    break;
                }
            }
        }

        // 00465118
        public void BtnOkClick(System.Object Sender, System.EventArgs _e1)
        {
            //int nGateIdx;
            //int nTitleIdx;
            //int nRouteIdx;
            //string sTitle;
            //string sIPaddr;
            //string sPort;
            //string sGateAddr;
            //TConfig Config;
            //Config = LSShare.g_Config;
            //nTitleIdx = CbGateList.SelectedIndex;
            //if (nTitleIdx < 0)
            //{
            //    return;
            //}
            //nGateIdx = 0;
            //while (true)
            //{
            //    sGateAddr = EdGate[nGateIdx].Text.Trim();
            //    if (sGateAddr != "")
            //    {
            //        sPort = HUtil32.GetValidStr3(sGateAddr, ref sIPaddr, new char[] {':'});
            //    }
            //    if ((sIPaddr == "") || (HUtil32.Str_ToInt(sPort, 0) == 0))
            //    {
            //        Console.Beep();
            //        return;
            //    }
            //    nGateIdx ++;
            //    if (nGateIdx >= 10)
            //    {
            //        break;
            //    }
            //}
            ////@ Unsupported property or method(A): 'Strings'
            //sTitle = CbGateList.Items.Strings[nTitleIdx];
            //nRouteIdx =  -1;
            //nGateIdx = 0;
            //while (true)
            //{
            //    if (Config.GateRoute[nGateIdx].sTitle == sTitle)
            //    {
            //        nRouteIdx = nGateIdx;
            //        break;
            //    }
            //    nGateIdx ++;
            //    if (nGateIdx >= LSShare.MAXGATEROUTE - 1)
            //    {
            //        break;
            //    }
            //}
            //if (nRouteIdx < 0)
            //{
            //    return;
            //}
            //Config.GateRoute[nRouteIdx].sRemoteAddr = EdPrivateAddr.Text;
            //Config.GateRoute[nRouteIdx].sPublicAddr = EdPublicAddr.Text;
            //nGateIdx = 0;
            //while (true)
            //{
            //    sPort = HUtil32.GetValidStr3(EdGate[nGateIdx].Text.Trim(), ref sIPaddr, new char[] {':'});
            //    if (sIPaddr != "")
            //    {
            //        Config.GateRoute[nRouteIdx].Gate[nGateIdx].sIPaddr = sIPaddr;
            //        Config.GateRoute[nRouteIdx].Gate[nGateIdx].nPort = HUtil32.Str_ToInt(sPort, 0);
            //        Config.GateRoute[nRouteIdx].Gate[nGateIdx].boEnable = CkGate[nGateIdx].Checked;
            //    }
            //    else
            //    {
            //        Config.GateRoute[nRouteIdx].Gate[nGateIdx].sIPaddr = "";
            //        Config.GateRoute[nRouteIdx].Gate[nGateIdx].nPort = 0;
            //        Config.GateRoute[nRouteIdx].Gate[nGateIdx].boEnable = false;
            //    }
            //    nGateIdx ++;
            //    if (nGateIdx >= 10)
            //    {
            //        break;
            //    }
            //}
            //LSShare.SaveGateConfig(Config);
        }

        // 004653B8
        public void BtnChangeTitleClick(System.Object Sender, System.EventArgs _e1)
        {
            int nTitleIdx;
            string sTitle;
            string sEdTitle;
            TConfig Config;
            Config = LSShare.g_Config;
            nTitleIdx = CbGateList.SelectedIndex;
            if (nTitleIdx < 0)
            {
                return;
            }
            sEdTitle = EdTitle.Text.Trim();
            sTitle = HUtil32.ReplaceChar(sEdTitle, ' ', '_');

            //@ Unsupported property or method(A): 'Strings'
            CbGateList.Items[nTitleIdx] = sTitle;
            Config.GateRoute[nTitleIdx].sTitle = sTitle;
            CbGateList.SelectedIndex = nTitleIdx;
        }

        public void CbServerListChange(System.Object Sender, System.EventArgs _e1)
        {
            int I;
            int nSelIdx;
            string sServerName;
            TConfig Config;
            Config = LSShare.g_Config;
            nSelIdx = CbServerList.SelectedIndex;
            if (nSelIdx < 0)
            {
                return;
            }

            //sServerName = CbServerList.Items.Strings[nSelIdx];
            //CbGateList.Clear;
            //for (I = 0; I < Config.nRouteCount; I ++ )
            //{
            //    if (Config.GateRoute[I].sServerName == sServerName)
            //    {
            //        CbGateList.Items.Add(Config.GateRoute[I].sTitle);
            //    }
            //}
            //CbGateList.SelectedIndex = 0;
            //CbGateListChange(this);
        }

        private void RefRouteList()
        {
            int I;
            int II;
            bool boAdded;
            TConfig Config;
            Config = LSShare.g_Config;
            if (Config.nRouteCount <= 0)
            {
                return;
            }
            CbServerList.Items.Clear();
            for (I = 0; I < Config.nRouteCount; I++)
            {
                boAdded = true;
                for (II = 0; II < CbServerList.Items.Count; II++)
                {
                    if (Config.GateRoute[I].sServerName == CbServerList.Items[II])
                    {
                        boAdded = false;
                    }
                }
                if (boAdded)
                {
                    CbServerList.Items.Add(Config.GateRoute[I].sServerName);
                }
            }
            CbServerList.SelectedIndex = 0;

            //CbServerListChange(this);
        }

        public bool Open()
        {
            bool result;
            RefRouteList();
            result = false;
            if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                result = true;
            }
            return result;
        }
    }
}