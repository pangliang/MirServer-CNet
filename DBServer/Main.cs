using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using DBServer.Entity;
using GameFramework;
using NetFramework;
using NetFramework.AsyncSocketServer;
using NetFramework.AsyncSocketClient;

namespace DBServer
{
    public partial class TFrmMain : Form
    {
        private System.Threading.Timer TimerMain = null;
        private System.Threading.Timer TimerStart = null;
        private System.Threading.Timer TimerClose = null;

        private IServerSocket ServerSocket = null;
        private IServerSocket SelectSocket = null;
        TFrmIDSoc FrmIDSoc = null;

        public TFrmMain()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.Initialization();
            DBShare.MainOutMessage("正在启动数据库服务器...");
            FrmIDSoc = new TFrmIDSoc(this);
            FrmIDSoc.Show();
            FrmIDSoc.Hide();
            ModuleGrid.AllowUserToAddRows = false;
            ModuleGrid.RowHeadersVisible = false;
            ModuleGrid.ReadOnly = true;
            ModuleGrid.Columns.Add("MKMC", "模块名称");
            ModuleGrid.Columns.Add("LJDZ", "连接地址");
            ModuleGrid.Columns.Add("SJTX", "数据通讯");
            ModuleGrid.Columns[0].Width = 80;
            ModuleGrid.Columns[1].Width = 468 - 80 * 2;
            ModuleGrid.Columns[2].Width = 80;
            ModuleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ModuleGrid.MultiSelect = false;
            ModuleGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModuleGrid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModuleGrid.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModuleGrid.RowTemplate.Height = 18;
            ModuleGrid.Rows.Add(5);
            //M2套接字
            ServerSocket = new IServerSocket(1000, Int16.MaxValue);
            ServerSocket.OnClientConnect += ServerSocket_OnClientConnect;
            ServerSocket.OnClientDisconnect += ServerSocket_OnClientDisconnect;
            ServerSocket.OnClientError += ServerSocket_OnClientError;
            ServerSocket.OnClientRead += ServerSocket_OnClientRead;
            ServerSocket.OnDataSendCompleted += ServerSocket_OnDataSendCompleted;
            //选择服务器套接字
            SelectSocket = new IServerSocket(1000, Int16.MaxValue);
            SelectSocket.OnClientConnect += SelectSocket_OnClientConnect;
            SelectSocket.OnClientDisconnect += SelectSocket_OnClientDisconnect;
            SelectSocket.OnClientError += SelectSocket_OnClientError;
            SelectSocket.OnClientRead += SelectSocket_OnClientRead;
            SelectSocket.OnDataSendCompleted += SelectSocket_OnDataSendCompleted;
            ServerSocket.Init();
            SelectSocket.Init();
            CheckBoxShowMainLogMsg.Checked = DBShare.g_boShowLogMsg;
            //Units.Main.RankingThread = new TRankingThread(true);
            //Units.Main.RankingThread.Resume();
            DBShare.SendGameCenterMsg(Common.SG_STARTNOW, "正在启动数据库服务器...");
            TimerMain = new System.Threading.Timer(TimerMainTimer, null, 0, 1);
            TimerStart = new System.Threading.Timer(TimerStartTimer, null, -1, -1);
            TimerClose = new System.Threading.Timer(TimerCloseTimer, null, -1, -1);
            TimerStart.Change(0, 1000);
        }

        public void SelectSocket_OnDataSendCompleted(object sender, AsyncUserToken e)
        {
            throw new NotImplementedException();
        }

        public void SelectSocket_OnClientRead(object sender, AsyncUserToken e)
        {
            byte[] data = new byte[e.BytesReceived];
            Array.Copy(e.ReceiveBuffer, e.Offset, data, 0, e.BytesReceived);
            DBShare.MainOutMessage(System.Text.Encoding.Default.GetString(data));
            (e.Tag as TSelectClient).ExecGateBuffers(System.Text.Encoding.Default.GetString(data), e.BytesReceived);
        }

        public void SelectSocket_OnClientError(object sender, AsyncSocketErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SelectSocket_OnClientDisconnect(object sender, AsyncUserToken e)
        {
            DBShare.MainOutMessage("Sel断开: " + e.EndPoint.ToString());
        }

        public void SelectSocket_OnClientConnect(object sender, AsyncUserToken e)
        {
            DBShare.MainOutMessage("Sel连接: " + e.EndPoint.ToString());
            TSelectClient ClentSocket = new TSelectClient(e, FrmIDSoc);
            e.Tag = ClentSocket;
        }

        public void ServerSocket_OnDataSendCompleted(object sender, AsyncUserToken e)
        {
            throw new NotImplementedException();
        }

        public void ServerSocket_OnClientRead(object sender, AsyncUserToken e)
        {
            byte[] data = new byte[e.BytesReceived];
            Array.Copy(e.ReceiveBuffer, e.Offset, data, 0, e.BytesReceived);
            (((object[])e.Tag)[0] as ServerClient.TServerClient).ProcessServerPacket(System.Text.Encoding.Unicode.GetString(data), e.BytesReceived);
        }

        public void ServerSocket_OnClientError(object sender, AsyncSocketErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ServerSocket_OnClientDisconnect(object sender, AsyncUserToken e)
        {
            DBShare.MainOutMessage("断开连接: " + e.EndPoint.ToString());
        }

        public void ServerSocket_OnClientConnect(object sender, AsyncUserToken e)
        {
            string sRemoteAddress;
            TModuleInfo ModuleInfo = new TModuleInfo();
            sRemoteAddress = e.EndPoint.Address.ToString();
            DBShare.MainOutMessage("M2连接: " + e.EndPoint.ToString());
            if ((!DBShare.CheckServerIP(sRemoteAddress)))
            {
                DBShare.MainOutMessage("非法服务器连接: " + sRemoteAddress);
                e.Socket.Close();
                return;
            }
            if (!(THumDB.boDataDBReady && THumDB.boHumDBReady && DBShare.g_boStartService))
            {
                e.Socket.Close();
            }
            else
            {
                ModuleInfo.Module = e;
                ModuleInfo.ModuleName = "游戏中心";
                ModuleInfo.Address = string.Format("{0}:{1} → {2}:{3}", sRemoteAddress, e.EndPoint.Port, sRemoteAddress, 6000);// Format("%s:%d → %s:%d", new object[] {sRemoteAddress, Socket.RemotePort, sRemoteAddress, ServerSocket.Port});
                ModuleInfo.Buffer = "0/0";
                ModuleInfo = DBShare.AddModule(ModuleInfo);
            }
            TServerClient ClentSocket = new TServerClient(e, FrmIDSoc);
            e.Tag = new object[] { ClentSocket, ModuleInfo };
        }

        /// <summary>
        /// 向Main窗口显示日志
        /// </summary>
        private void ShowMainLogMsg()
        {
            if ((GameFramework.HUtil32.GetTickCount() - DBShare.g_dwShowMainLogTick) > 20)
            {
                DBShare.g_dwShowMainLogTick = GameFramework.HUtil32.GetTickCount();
                List<string> TempLogList = new List<string>();
                try
                {
                    //移动到临时变量存储
                    DBShare.g_MainLogMsgList.__Lock();
                    try
                    {
                        for (int I = 0; I < DBShare.g_MainLogMsgList.Count; I++)
                        {
                            TempLogList.Add(DBShare.g_MainLogMsgList[I]);
                        }
                        DBShare.g_MainLogMsgList.Clear();
                    }
                    finally
                    {
                        DBShare.g_MainLogMsgList.UnLock();
                    }
                    for (int I = 0; I < TempLogList.Count; I++)
                    {
                        MemoLog.Invoke((MethodInvoker)delegate() { MemoLog.AppendText(TempLogList[I] + Environment.NewLine); });
                    }
                }
                finally
                {
                }
            }
        }

        /// <summary>
        /// 显示窗体上网格信息
        /// </summary>
        private void ShowModule()
        {
            int I;
            TModuleInfo ModuleInfo;
            try
            {
                if ((GameFramework.HUtil32.GetTickCount() - DBShare.g_dwShowModuleTick) > 2000)
                {
                    DBShare.g_dwShowModuleTick = GameFramework.HUtil32.GetTickCount();
                    ModuleGrid.RowCount = HUtil32._MAX(DBShare.g_ModuleList.Count + 1, 5);
                    for (I = 0; I < ModuleGrid.RowCount; I++)
                    {
                        if (I < DBShare.g_ModuleList.Count)
                        {
                            ModuleInfo = DBShare.g_ModuleList[I];
                            ModuleGrid.Invoke((MethodInvoker)delegate()
                            {
                                ModuleGrid.Rows[I].Cells[0].Value = ModuleInfo.ModuleName;
                                ModuleGrid.Rows[I].Cells[1].Value = ModuleInfo.Address;
                                ModuleGrid.Rows[I].Cells[2].Value = ModuleInfo.Buffer;
                            });
                        }
                        else
                        {
                            ModuleGrid.Invoke((MethodInvoker)delegate()
                            {
                                ModuleGrid.Rows[I].Cells[0].Value = "";
                                ModuleGrid.Rows[I].Cells[1].Value = "";
                                ModuleGrid.Rows[I].Cells[2].Value = "";
                            });
                        }
                    }
                }
            }
            catch
            {
                DBShare.MainOutMessage("[Exception] ShowModule");
            }
        }

        /// <summary>
        /// 显示工作状态
        /// </summary>
        private void ShowWorkStatus()
        {
            switch (DBShare.g_nWorkStatus)
            {
                case Common.DB_LOADHUMANRCD:
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "读取人物数据";
                    });
                    break;

                case Common.DB_SAVEHUMANRCD:
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "保存人物数据";
                    });
                    break;

                case Common.DB_LOADHERORCD:
                    // 读取英雄数据
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "读取英雄数据";
                    });
                    break;

                case Common.DB_NEWHERORCD:
                    // 新建英雄
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "创建英雄";
                    });
                    break;

                case Common.DB_DELHERORCD:

                    // 删除英雄
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "删除英雄";
                    });

                    break;

                case Common.DB_SAVEHERORCD:

                    // 保存英雄数据
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "保存英雄数据";
                    });

                    break;

                case Common.DB_LOADRANKING:
                    // 排行榜
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Green;
                        LabelWorkStatus.Text = "读取排行榜数据";
                    });

                    break;
                default:
                    LabelWorkStatus.Invoke((MethodInvoker)delegate()
                    {
                        LabelWorkStatus.ForeColor = System.Drawing.Color.Blue;
                    });

                    break;
            }
            if (GameFramework.HUtil32.GetTickCount() - DBShare.g_dwWorkStatusTick > 1000)
            {
                DBShare.g_dwWorkStatusTick = GameFramework.HUtil32.GetTickCount();
                LabelCreateHum.Invoke((MethodInvoker)delegate()
                {
                    LabelCreateHum.Text = string.Format("创建人物:{0}", DBShare.g_nCreateHumCount);
                });
                LabelDeleteHum.Invoke((MethodInvoker)delegate()
                {
                    LabelDeleteHum.Text = string.Format("删除人物:{0}", DBShare.g_nDeleteHumCount);
                });
                LabelLoadHumRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelLoadHumRcd.Text = string.Format("读取人物数据:{0}", DBShare.g_nLoadHumCount);
                });
                LabelSaveHumRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelSaveHumRcd.Text = string.Format("保存人物数据:{0}", DBShare.g_nSaveHumCount);
                });

                LabelCreateHero.Invoke((MethodInvoker)delegate()
                {
                    LabelCreateHero.Text = string.Format("创建英雄:{0}", DBShare.g_nCreateHeroCount);
                });
                LabelDeleteHero.Invoke((MethodInvoker)delegate()
                {
                    LabelDeleteHero.Text = string.Format("删除英雄:{0}", DBShare.g_nDeleteHeroCount);
                });
                LabelLoadHeroRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelLoadHeroRcd.Text = string.Format("读取英雄数据:{0}", DBShare.g_nLoadHeroCount);
                });
                LabelSaveHeroRcd.Invoke((MethodInvoker)delegate()
                {
                    LabelSaveHeroRcd.Text = string.Format("保存英雄数据:{0}", DBShare.g_nSaveHeroCount);
                });
            }
        }

        /// <summary>
        /// 主时钟
        /// </summary>
        /// <param name="objState">状态信息</param>
        public void TimerMainTimer(object objState)
        {
            ShowMainLogMsg();
            ShowModule();
            ShowWorkStatus();
        }

        private void StartService()
        {
            try
            {
                DBShare.MainOutMessage("正在启动服务器...");
                DBShare.LoadConfig();
                ServerSocket.Start(new IPEndPoint(IPAddress.Parse("0.0.0.0"), DBShare.g_nServerPort));
                SelectSocket.Start(new IPEndPoint(IPAddress.Parse("0.0.0.0"), DBShare.g_nGatePort));
                DBShare.g_boStartService = true;
                FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.OpenConnect(); });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_START.Enabled = false; });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_STOP.Enabled = true; });
                DBShare.MainOutMessage("数据库服务器启动成功...");
                DBShare.SendGameCenterMsg(Common.SG_STARTOK, "数据库服务器启动完成...");
            }
            catch (Exception ex)
            {
                DBShare.MainOutMessage(ex.Message);
                DBShare.g_boStartService = false;
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_START.Enabled = true; });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_STOP.Enabled = false; });
                FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.CloseConnect(); });
                SelectSocket.Shutdown();
                ServerSocket.Shutdown();
            }
        }

        private void StopService()
        {
            DBShare.g_boStartService = false;
            DBShare.MainOutMessage("正在停止服务器...");
            MENU_CONTROL_START.Enabled = true;
            MENU_CONTROL_STOP.Enabled = false;
            FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.CloseConnect(); });
            SelectSocket.Shutdown();
            ServerSocket.Shutdown();
            DBShare.MainOutMessage("服务器已停止...");
        }

        public void TimerStartTimer(object objState)
        {
            TimerStart.Dispose();
            StartService();
        }

        public void MENU_OPTION_GAMEGATEClick(System.Object Sender, System.EventArgs _e1)
        {
            //RouteManage.Units.RouteManage.frmRouteManage.Open();
        }

        public void MENU_MANAGE_DATAClick(System.Object Sender, System.EventArgs _e1)
        {
            //if (HumDB.Units.HumDB.boHumDBReady && HumDB.Units.HumDB.boDataDBReady)
            //{
            //    FIDHum.Units.FIDHum.FrmIDHum.Show();
            //}
        }

        public void MENU_RANKINGClick(System.Object Sender, System.EventArgs _e1)
        {
            //Ranking.Units.Ranking.FrmRankingDlg.Top = this.Top;
            //Ranking.Units.Ranking.FrmRankingDlg.Left = this.Left;
            //Ranking.Units.Ranking.FrmRankingDlg.Open();
        }

        /// <summary>
        /// 测试选择网关
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void MENU_TEST_SELGATEClick(System.Object Sender, System.EventArgs _e1)
        {
            TfrmTestSelGate frmTestSelGate = new TfrmTestSelGate();
            frmTestSelGate.ShowDialog();
        }

        public void CheckBoxShowMainLogMsgClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.g_boShowLogMsg = CheckBoxShowMainLogMsg.Checked;
        }

        /// <summary>
        /// 启动服务菜单
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void MENU_CONTROL_STARTClick(System.Object Sender, System.EventArgs _e1)
        {
            StartService();
        }

        /// <summary>
        /// 停止服务菜单
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="_e1"></param>
        public void MENU_CONTROL_STOPClick(System.Object Sender, System.EventArgs _e1)
        {
            StopService();
        }

        public void MENU_CONTROL_EXITClick(System.Object Sender, System.EventArgs _e1)
        {
            this.Close();
        }

        public void TimerCloseTimer(object objState)
        {
            if (DBShare.g_boStartService)
            {
                DBShare.g_boStartService = false;
                DBShare.MainOutMessage("正在停止服务器...");
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_START.Enabled = true; });
                this.Invoke((MethodInvoker)delegate() { MENU_CONTROL_STOP.Enabled = false; });
                FrmIDSoc.Invoke((MethodInvoker)delegate() { FrmIDSoc.CloseConnect(); });
            }
            TimerClose.Change(-1, -1);
            SelectSocket.Shutdown();
            ServerSocket.Shutdown();
            DBShare.MainOutMessage("服务器已停止...");
        }

        
        public void MENU_HELP_VERSIONClick(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.MainOutMessage(DBShare.g_sVersion);
            DBShare.MainOutMessage(DBShare.g_sUpDateTime);
            DBShare.MainOutMessage(DBShare.g_sProgram);
            DBShare.MainOutMessage(DBShare.g_sWebSite);
        }

        public void G1Click(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.LoadGateID();
            DBShare.LoadIPTable();
            DBShare.MainOutMessage("网关设置加载完成");
        }

        public void C1Click(System.Object Sender, System.EventArgs _e1)
        {
            DBShare.LoadChrNameList("DenyChrName.txt");
            DBShare.LoadAICharNameList("AICharName.txt");
            DBShare.MainOutMessage("角色过滤列表加载完成");
        }

        public void MemoLogChange(System.Object Sender, System.EventArgs _e1)
        {
            if (MemoLog.Lines.Length > 100)
            {
                MemoLog.Clear();
            }
        }

        public void MemoLogDblClick(System.Object Sender, System.EventArgs _e1)
        {
            if (MessageBox.Show("是否确定清除日志信息！！！", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MemoLog.Clear();
            }
        }

        public void MENU_OPTION_GENERALClick(System.Object Sender, System.EventArgs _e1)
        {
            //Setting.Units.Setting.FrmSetting = new TFrmSetting(this.Owner);
            //Setting.Units.Setting.FrmSetting.Open();
            //Setting.Units.Setting.FrmSetting.Free;
        }

        private void TFrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DBShare.g_boRemoteClose || DBShare.g_boSoftClose)
            {
                //需要判断一下是否还有连接的如果有连接的就启动关闭时钟
            }
            else
            {
                if ((MessageBox.Show("是否确定退出数据库服务器？", "确认信息", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    DBShare.g_boSoftClose = true;
                        //需要判断一下是否还有连接的如果有连接的就启动关闭时钟
                        TimerClose.Change(0, 1000);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 获取选择套接字在线数
        /// </summary>
        /// <returns></returns>
        public long GetSelectCharCount()
        {
            return SelectSocket.NumConnectedSockets;
        }

    } // end TFrmMain

}