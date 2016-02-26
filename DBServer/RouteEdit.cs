using System;
using System.Windows.Forms;
using DBServer.Entity;
using GameFramework;

namespace DBServer
{
    public partial class TfrmRouteEdit : Form
    {
        private bool m_EditOK = false;
        public TRouteInfo m_RouteInfo = null;//路由信息

        /// <summary>
        /// 构造函数
        /// </summary>
        public TfrmRouteEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开窗体
        /// </summary>
        /// <returns></returns>
        public TRouteInfo Open()
        {
            TRouteInfo result = new TRouteInfo();
            m_EditOK = false;
            RefShowRoute();
            this.ShowDialog();
            if (m_EditOK)
            {
                result = m_RouteInfo;
            }
            else
            {
                result.nGateCount = -1;
            }
            return result;
        }

        /// <summary>
        /// 刷新界面显示
        /// </summary>
        private void RefShowRoute()
        {
            EditSelGate.Text = m_RouteInfo.sSelGateIP;
            EditGateIPaddr1.Text = m_RouteInfo.sGameGateIP[0];
            EditGatePort1.Text = (m_RouteInfo.nGameGatePort[0]).ToString();
            EditGateIPaddr2.Text = m_RouteInfo.sGameGateIP[1];
            EditGatePort2.Text = (m_RouteInfo.nGameGatePort[1]).ToString();
            EditGateIPaddr3.Text = m_RouteInfo.sGameGateIP[2];
            EditGatePort3.Text = (m_RouteInfo.nGameGatePort[2]).ToString();
            EditGateIPaddr4.Text = m_RouteInfo.sGameGateIP[3];
            EditGatePort4.Text = (m_RouteInfo.nGameGatePort[3]).ToString();
            EditGateIPaddr5.Text = m_RouteInfo.sGameGateIP[4];
            EditGatePort5.Text = (m_RouteInfo.nGameGatePort[4]).ToString();
            EditGateIPaddr6.Text = m_RouteInfo.sGameGateIP[5];
            EditGatePort6.Text = (m_RouteInfo.nGameGatePort[5]).ToString();
            EditGateIPaddr7.Text = m_RouteInfo.sGameGateIP[6];
            EditGatePort7.Text = (m_RouteInfo.nGameGatePort[6]).ToString();
            EditGateIPaddr8.Text = m_RouteInfo.sGameGateIP[7];
            EditGatePort8.Text = (m_RouteInfo.nGameGatePort[7]).ToString();
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void ButtonOKClick(System.Object Sender, System.EventArgs _e1)
        {
            if (Sender == ButtonOK)
            {
                if (ProcessRouteOK())
                {
                    m_EditOK = true;
                    this.Close();
                }
            }
            else if (Sender == ButtonCancel)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 处理完毕
        /// </summary>
        /// <returns></returns>
        private bool ProcessRouteOK()
        {
            bool result;
            string sGameGateIP;
            int nGameGatePort;
            result = false;
            m_RouteInfo.sSelGateIP = EditSelGate.Text.Trim();
            if (!HUtil32.IsIPaddr(m_RouteInfo.sSelGateIP))
            {
                MessageBox.Show("角色网关输入错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Error);
                EditSelGate.Focus();
                return result;
            }
            sGameGateIP = EditGateIPaddr1.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort1.Text, 0);
            
            if (!HUtil32.IsIPaddr(sGameGateIP))
            {
                MessageBox.Show("游戏网关一输入错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Error);
                EditGateIPaddr1.Focus();
                return result;
            }
            if (nGameGatePort <= 0)
            {
                MessageBox.Show("游戏网关一输入错误！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Error);
                EditGatePort1.Focus();
                return result;
            }
            m_RouteInfo.sGameGateIP[0] = sGameGateIP;
            m_RouteInfo.nGameGatePort[0] = nGameGatePort;
            m_RouteInfo.nGateCount = 1;
            result = true;
            sGameGateIP = EditGateIPaddr2.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort2.Text, 0);
            
            if ((!HUtil32.IsIPaddr(sGameGateIP)) || (nGameGatePort <= 0))
            {
                return result;
            }
            m_RouteInfo.sGameGateIP[1] = sGameGateIP;
            m_RouteInfo.nGameGatePort[1] = nGameGatePort;
            m_RouteInfo.nGateCount = 2;
            sGameGateIP = EditGateIPaddr3.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort3.Text, 0);
            
            if ((!HUtil32.IsIPaddr(sGameGateIP)) || (nGameGatePort <= 0))
            {
                return result;
            }
            m_RouteInfo.sGameGateIP[2] = sGameGateIP;
            m_RouteInfo.nGameGatePort[2] = nGameGatePort;
            m_RouteInfo.nGateCount = 3;
            sGameGateIP = EditGateIPaddr4.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort4.Text, 0);
            
            if ((!HUtil32.IsIPaddr(m_RouteInfo.sGameGateIP[3])) || (nGameGatePort <= 0))
            {
                return result;
            }
            m_RouteInfo.sGameGateIP[3] = sGameGateIP;
            m_RouteInfo.nGameGatePort[3] = nGameGatePort;
            m_RouteInfo.nGateCount = 4;
            sGameGateIP = EditGateIPaddr5.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort5.Text, 0);
            
            if ((!HUtil32.IsIPaddr(sGameGateIP)) || (nGameGatePort <= 0))
            {
                return result;
            }
            m_RouteInfo.sGameGateIP[4] = sGameGateIP;
            m_RouteInfo.nGameGatePort[4] = nGameGatePort;
            m_RouteInfo.nGateCount = 5;
            sGameGateIP = EditGateIPaddr6.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort6.Text, 0);
            
            if ((!HUtil32.IsIPaddr(m_RouteInfo.sGameGateIP[5])) || (nGameGatePort <= 0))
            {
                return result;
            }
            m_RouteInfo.sGameGateIP[5] = sGameGateIP;
            m_RouteInfo.nGameGatePort[5] = nGameGatePort;
            m_RouteInfo.nGateCount = 6;
            sGameGateIP = EditGateIPaddr7.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort7.Text, 0);
            
            if ((!HUtil32.IsIPaddr(m_RouteInfo.sGameGateIP[6])) || (nGameGatePort <= 0))
            {
                return result;
            }
            m_RouteInfo.sGameGateIP[6] = sGameGateIP;
            m_RouteInfo.nGameGatePort[6] = nGameGatePort;
            m_RouteInfo.nGateCount = 7;
            sGameGateIP = EditGateIPaddr8.Text.Trim();
            
            nGameGatePort = HUtil32.Str_ToInt(EditGatePort8.Text, 0);
            
            if ((!HUtil32.IsIPaddr(m_RouteInfo.sGameGateIP[7])) || (nGameGatePort <= 0))
            {
                return result;
            }
            m_RouteInfo.sGameGateIP[7] = sGameGateIP;
            m_RouteInfo.nGameGatePort[7] = nGameGatePort;
            m_RouteInfo.nGateCount = 8;
            return result;
        }

    } // end TfrmRouteEdit

}
