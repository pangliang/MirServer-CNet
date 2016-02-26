using GameFramework;
using GameFramework.LuaBase;
using GameFramework.Thrend;
using LuaInterface;
using M2Server.Base;
using NetFramework;
using NetFramework.AsyncSocketClient;
using NetFramework.AsyncSocketServer;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace M2Server
{
    //\s*\n\s*\n 删除换行代码
    public partial class TFrmMain : Form, IDisposable
    {
        #region 变量区
        protected static Logger s_log = LogManager.GetCurrentClassLogger();
        public static IServerSocket g_GateSocket = null;
        public static IServerSocket GateSocket = null;
        public static IClientScoket DBSocket = null;
        public static uint l_dwRunTimeTick = 0;
        public static bool boSaveData = false;
        private bool boServiceStarted = false;
        private TGameConfig Config;

        private TFrmSrvMsg FrmSrvMsg = new TFrmSrvMsg();
        private TFrmMsgClient FrmMsgClient = new TFrmMsgClient();
        private LocalDB FrmDB;

        #endregion 变量区

        public TFrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 生成程序标题
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="nLen"></param>
        public void SetWindowTitle(string Msg)
        {
            this.Invoke((MethodInvoker)delegate() { this.Text = Msg; });
        }

        /// <summary>
        /// 加载文字过滤
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static bool LoadAbuseInformation(string FileName)
        {
            bool result = false;
            int I;
            string sText;
            if (File.Exists(FileName))
            {
                M2Share.AbuseTextList.Clear();
                M2Share.AbuseTextList.LoadFromFile(FileName);
                I = 0;
                while (true)
                {
                    if (M2Share.AbuseTextList.Count <= I)
                    {
                        break;
                    }
                    sText = M2Share.AbuseTextList[I].Trim();
                    if (sText == "")
                    {
                        M2Share.AbuseTextList.RemoveAt(I);
                        continue;// 继续
                    }
                    I++;
                }
                result = true;
            }
            return result;
        }

        // 读取服务器IP及端口
        public static void LoadServerTable()
        {
            int I;
            int II;
            TStringList LoadList;
            TStringList GateList;
            string sLineText = string.Empty;
            string sGateMsg = string.Empty;
            string sIPaddr = string.Empty;
            string sPort = string.Empty;
            M2Share.ServerTableList.Clear();
            if (File.Exists(".\\!servertable.txt"))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(".\\!servertable.txt");
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sGateMsg = HUtil32.GetValidStr3(sLineText, ref sGateMsg, new string[] { " ", "\09" }).Trim();
                        if (sGateMsg != "")
                        {
                            GateList = new TStringList();
                            for (II = 0; II <= 30; II++)
                            {
                                if (sGateMsg == "")
                                {
                                    break;
                                }
                                sGateMsg = HUtil32.GetValidStr3(sGateMsg, ref sIPaddr, new string[] { " ", "\09" }).Trim();
                                sGateMsg = HUtil32.GetValidStr3(sGateMsg, ref sPort, new string[] { " ", "\09" }).Trim();
                                if ((sIPaddr != "") && (sPort != ""))
                                {
                                    GateList.InsertText(HUtil32.Str_ToInt(sPort, 0), sIPaddr);
                                }
                            }
                            M2Share.ServerTableList.Add(GateList);
                            GateList = null;
                        }
                    }
                }
                LoadList.Dispose();
            }
            else
            {
                MessageBox.Show("文件!servertable.txt未找到！！！");
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="MsgList"></param>
        public static void WriteConLog(TStringList MsgList)
        {
            byte nCode = 0;
            try
            {
                if (MsgList.Count <= 0)
                {
                    return;
                }
                try
                {
                    if (MsgList.Count > 0)
                    {
                        nCode = 1;
                        for (int I = 0; I < MsgList.Count; I++)
                        {
                            s_log.Info(MsgList[I]);
                        }
                    }
                }
                finally
                {
                    nCode = 2;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} 写入ConLog目录日志出错 Code:" + nCode);
            }
        }

        public static void ProcessGameRun()
        {
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                try
                {
                    M2Share.UserEngine.PrcocessData();
                    M2Share.g_EventManager.Run();
                    M2Share.RobotManage.Run();
                    if (HUtil32.GetTickCount() - l_dwRunTimeTick > 10000)
                    {
                        l_dwRunTimeTick = HUtil32.GetTickCount();
                        M2Share.g_GuildManager.Run();
                        M2Share.g_CastleManager.Run();
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} ProcessGameRun");
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        // 保存!Setup.txt内容
        private void SaveItemNumber()
        {
            try
            {
                M2Share.Config.WriteInteger("Setup", "ItemNumber", M2Share.g_Config.nItemNumber);
                M2Share.Config.WriteInteger("Setup", "ItemNumberEx", M2Share.g_Config.nItemNumberEx);
                for (int I = M2Share.g_Config.GlobalVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalVal.GetUpperBound(0); I++) // 保存系统变量
                {
                    M2Share.Config.WriteInteger("Setup", "GlobalVal" + I, M2Share.g_Config.GlobalVal[I]);
                }
                for (int I = M2Share.g_Config.GlobalAVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalAVal.GetUpperBound(0); I++)  // 保存系统变量
                {
                    M2Share.Config.WriteString("Setup", "GlobalStrVal" + I, M2Share.g_Config.GlobalAVal[I]);
                }
                M2Share.Config.WriteInteger("Setup", "WinLotteryCount", M2Share.g_Config.nWinLotteryCount);
                M2Share.Config.WriteInteger("Setup", "NoWinLotteryCount", M2Share.g_Config.nNoWinLotteryCount);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel1", M2Share.g_Config.nWinLotteryLevel1);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel2", M2Share.g_Config.nWinLotteryLevel2);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel3", M2Share.g_Config.nWinLotteryLevel3);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel4", M2Share.g_Config.nWinLotteryLevel4);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel5", M2Share.g_Config.nWinLotteryLevel5);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel6", M2Share.g_Config.nWinLotteryLevel6);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 刷新界面数据
        /// </summary>
        /// <param name="obj"></param>
        private void RefreshData(object obj)
        {
            uint wHour;
            uint wMinute;
            uint wSecond;
            uint tSecond;
            decimal tTimeCount;
            string sSrvType;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.LogMsgCriticalSection);
                try
                {
                    if (M2Share.GameLogMsgList.Count > 0)
                    {
                        try
                        {
                            foreach (var Msg in M2Share.GameLogMsgList)
                            {
                                OutManMessage(Msg);
                            }
                            M2Share.GameLogMsgList.Clear();
                        }
                        catch
                        {
                            OutManMessage("保存日志信息出错！！！");
                        }
                    }
                    if (M2Share.MainLogMsgList.Count > 0)
                    {
                        try
                        {
                            foreach (var Msg in M2Share.MainLogMsgList)
                            {
                                OutErroeMessage(Msg);
                                s_log.Info(Msg);
                            }
                            M2Share.MainLogMsgList.Clear();
                        }
                        catch
                        {
                            OutManMessage("保存日志信息出错！！！");
                        }
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(M2Share.LogMsgCriticalSection);
                }
                tSecond = (HUtil32.GetTickCount() - M2Share.g_dwStartTick) / 1000;
                wHour = tSecond / 3600;
                wMinute = tSecond / 60 % 60;
                wSecond = tSecond % 60;
                sSrvType = "[M]";
                // HUtil32.GetTickCount()用于获取自windows启动以来经历的时间长度（毫秒）
                tTimeCount = HUtil32.GetTickCount() / (24 * 60 * 60 * 1000);
                LbRunSocketTime.Invoke((MethodInvoker)delegate()
                {
                    this.LbRunSocketTime.Text = '[' + wHour + ':' + wMinute + ':' + wSecond + sSrvType + tTimeCount + ']';
                });
                LbUserCount.Invoke((MethodInvoker)delegate()
                {
                    LbUserCount.Text = string.Format("({0}) [{1}/{2}] [{3}/{4}] [{5}/{6}]", M2Share.UserEngine.MonsterCount,
                        TRunSocket.g_nGateRecvMsgLenMin, TRunSocket.g_nGateRecvMsgLenMax, M2Share.UserEngine.OnlinePlayObject,
                        M2Share.UserEngine.PlayObjectCount, M2Share.UserEngine.LoadPlayCount, M2Share.UserEngine.m_PlayObjectFreeList.Count);
                });
                Label1.Invoke((MethodInvoker)delegate()
                {
                    Label1.Text = string.Format("Run({0}/{1}) Soc({2}/{3}) Usr({4}/{5})", M2Share.nRunTimeMin, M2Share.nRunTimeMax, M2Share.g_nSockCountMin,
                        M2Share.g_nSockCountMax, M2Share.g_nUsrTimeMin, M2Share.g_nUsrTimeMax);
                });
                Label2.Invoke((MethodInvoker)delegate()
                {
                    Label2.Text = string.Format("Hum{0}/{1} Usr{2}/{3} Mer{4}/{5} Npc{6}/{7}", M2Share.g_nHumCountMin, M2Share.g_nHumCountMax,
                        M2Share.dwUsrRotCountMin, M2Share.dwUsrRotCountMax, M2Share.UserEngine.dwProcessMerchantTimeMin,
                        M2Share.UserEngine.dwProcessMerchantTimeMax, M2Share.UserEngine.dwProcessNpcTimeMin, M2Share.UserEngine.dwProcessNpcTimeMax,
                        M2Share.g_nProcessHumanLoopTime);
                });
                Label20.Invoke((MethodInvoker)delegate()
                {
                    Label20.Text = string.Format("MonG({0}/{1}/{2}) MonP({3}/{4}/{5}) ObjRun({6}/{7})", M2Share.g_nMonGenTime, M2Share.g_nMonGenTimeMin,
                      M2Share.g_nMonGenTimeMax, M2Share.g_nMonProcTime, M2Share.g_nMonProcTimeMin, M2Share.g_nMonProcTimeMax, M2Share.g_nBaseObjTimeMin,
                      M2Share.g_nBaseObjTimeMax);
                });
                Label5.Invoke((MethodInvoker)delegate() { Label5.Text = M2Share.g_sMonGenInfo1 + '-' + M2Share.g_sMonGenInfo2 + ' '; });
                if (M2Share.dwStartTimeTick == 0)
                {
                    M2Share.dwStartTimeTick = HUtil32.GetTickCount();
                }
                M2Share.dwStartTime = (HUtil32.GetTickCount() - M2Share.dwStartTimeTick) / 1000;
                GateListView.BeginInvoke(new Action(BeginGateListView));
                M2Share.nRunTimeMax++;
                if (M2Share.g_nSockCountMax > 0) { M2Share.g_nSockCountMax -= 1; }
                if (M2Share.g_nUsrTimeMax > 0) { M2Share.g_nUsrTimeMax -= 1; }
                if (M2Share.g_nHumCountMax > 0) { M2Share.g_nHumCountMax -= 1; }
                if (M2Share.g_nMonTimeMax > 0) { M2Share.g_nMonTimeMax -= 1; }
                if (M2Share.dwUsrRotCountMax > 0) { M2Share.dwUsrRotCountMax -= 1; }
                if (M2Share.g_nMonGenTimeMin > 1) { M2Share.g_nMonGenTimeMin -= 2; }
                if (M2Share.g_nMonProcTimeMin > 1) { M2Share.g_nMonProcTimeMin -= 2; }
                if (M2Share.g_nBaseObjTimeMax > 0) { M2Share.g_nBaseObjTimeMax -= 1; }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} Timer1Timer");
            }
        }

        /// <summary>
        /// 刷新网关连接状态
        /// </summary>
        protected void BeginGateListView()
        {
            TGateInfo GateInfo;
            ListViewItem ListItem = null;
            GateListView.BeginUpdate();
            GateListView.Items.Clear();
            for (int i = TRunSocket.g_GateArr.GetLowerBound(0); i <= TRunSocket.g_GateArr.GetUpperBound(0); i++)
            {
                GateInfo = TRunSocket.g_GateArr[i];
                if (GateInfo.boUsed && (GateInfo.Socket != null))
                {
                    ListItem = new ListViewItem();
                    ListItem.Text = i.ToString();
                    ListItem.SubItems.Add(GateInfo.sAddr + ":" + GateInfo.nPort);
                    ListItem.SubItems.Add(GateInfo.nSendMsgCount.ToString());
                    ListItem.SubItems.Add(GateInfo.nSendedMsgCount.ToString());
                    ListItem.SubItems.Add(GateInfo.nSendRemainCount.ToString());
                    if (GateInfo.nSendMsgBytes < 1024)
                    {
                        ListItem.SubItems.Add(GateInfo.nSendMsgBytes + "b");
                    }
                    else
                    {
                        ListItem.SubItems.Add(GateInfo.nSendMsgBytes / 1024 + "kb");
                    }
                    if (GateInfo.UserList != null)
                    {
                        ListItem.SubItems.Add(GateInfo.nUserCount + "/" + GateInfo.UserList.Count);
                    }
                    else
                    {
                        ListItem.SubItems.Add(GateInfo.nUserCount + "/" + 0);
                    }
                    GateListView.Items.Add(ListItem);
                }
                else
                {
                    if (GateListView.Items.Count > 0)
                    {
                        GateListView.Items.RemoveByKey(i.ToString());
                    }
                }
            }
            GateListView.EndUpdate();
            ListItem = null;
            GateInfo = null;
        }

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="Sender"></param>
        private void InitEngine(object Sender)
        {
            int nCode;
            FrmDB = LocalDB.GetInstance();
            StartService();
            try
            {
                M2Share.LoadGameLogItemNameList();// 加载游戏日志物品名
                M2Share.LoadDenyIPAddrList();// 加载IP过滤列表
                M2Share.LoadDenyAccountList();// 加载登录帐号过滤列表
                M2Share.LoadDenyChrNameList();// 加载禁止登录人物列表
                M2Share.LoadNoClearMonList();// 加载不清除怪物列表
                OutManMessage("初始化数据库链接...[大约3秒,超时请检查链接字符串]");
                M2Share.GameDataBase.LoadItemsDB();
                OutManMessage(string.Format("加载物品数据库[{0}]...", M2Share.UserEngine.StdItemList.Count));
                M2Share.GameDataBase.LoadMagicDB();
                OutManMessage(string.Format("加载技能数据库[{0}]...", M2Share.UserEngine.m_MagicList.Count));
                M2Share.GameDataBase.LoadMonsterDB();
                OutManMessage(string.Format("加载怪物数据库[{0}]...", M2Share.UserEngine.MonsterList.Count));
                nCode = FrmDB.LoadMinMap();
                if (nCode < 0)
                {
                    OutManMessage("小地图数据加载失败！！！" + "代码: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("加载小地图数据成功...");
                }
                nCode = FrmDB.LoadMapInfo();
                if (nCode < 0)
                {
                    OutManMessage("地图数据加载失败！！！" + "代码: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage(string.Format("加载地图数据成功[{0}]...", M2Share.g_MapManager.m_MapList.Count));
                }
                nCode = FrmDB.LoadMonGen();
                if (nCode < 0)
                {
                    OutManMessage("加载怪物刷新配置信息失败！！！" + "代码: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage(string.Format("加载怪物刷新配置信息成功[{0}]...", M2Share.UserEngine.m_MonGenList.Count));
                }
                if (M2Share.LoadMonSayMsg())
                {
                    OutManMessage(string.Format("加载怪物说话配置信息成功[{0}]...", M2Share.g_MonSayMsgList.Count));
                }
                M2Share.LoadDisableTakeOffList();// 加载禁止取下物品列表
                M2Share.LoadMonDropLimitList();// 加载怪物爆物品限制列表
                M2Share.LoadDisableMakeItem();// 加载禁止制造物品列表
                M2Share.LoadEnableMakeItem();// 加载可制造物品列表
                M2Share.LoadDisableMoveMap();// 加载禁止移动地图列表
                M2Share.ItemUnit.LoadCustomItemName();
                M2Share.LoadDisableSendMsgList();// 加载禁止发信息名称列表
                M2Share.LoadItemBindIPaddr();// 加载捆绑IP列表
                M2Share.LoadItemBindAccount();
                M2Share.LoadItemBindCharName();
                M2Share.LoadItemBindDieNoDropName();// 读取人物装备死亡不爆列表
                M2Share.LoadUnMasterList();// 加载出师记录表
                M2Share.LoadUnForceMasterList();// 加载强行出师记录表
                M2Share.LoadItemDblClickList();// 加载允许捡取物品
                M2Share.LoadAllowPickUpItemList();// 加载无限仓库数据
                string ItemName;
                nCode = FrmDB.LoadUnbindList(out ItemName);
                if (nCode < 0)
                {
                    OutManMessage(string.Format("加载捆装物品信息失败！！！ [{0}]", ItemName));
                    return;
                }
                else
                {
                    OutManMessage("加载捆装物品信息成功...");
                }
                M2Share.LoadBindItemTypeFromUnbindList();// 加载捆装物品类型
                nCode = FrmDB.LoadMapQuest();
                if (nCode > 0)
                {
                    OutManMessage("加载任务地图信息成功...");
                }
                else
                {
                    OutManMessage("加载任务地图信息失败！！！");
                    return;
                }
                nCode = FrmDB.LoadMapEvent();
                if (nCode < 0)
                {
                    OutManMessage("加载地图触发事件信息失败！！！");
                    return;
                }
                else
                {
                    OutManMessage("加载地图触发事件信息成功...");
                }
                nCode = FrmDB.LoadQuestDiary();
                if (nCode < 0)
                {
                    OutManMessage("加载任务说明信息失败！！！");
                    return;
                }
                else
                {
                    OutManMessage("加载任务说明信息成功...");
                }
                if (LoadAbuseInformation(".\\!abuse.txt"))
                {
                    OutManMessage("加载文字过滤信息成功...");
                }
                if (M2Share.LoadLineNotice(M2Share.g_Config.sNoticeDir + "LineNotice.txt"))
                {
                    OutManMessage("加载公告提示信息成功...");
                }
                else
                {
                    OutManMessage("加载公告提示信息失败！！！");
                }
                M2Share.LoadUserCmdList();// 加载自定义命令
                M2Share.LoadCheckItemList();// 加载禁止物品规则
                M2Share.LoadMsgFilterList();// 加载消息过滤
                M2Share.LoadShopItemList();// 加载商铺配置
                FrmDB.LoadAdminList();// 加载管理员列表
                FrmDB.LoadBoxsList(); //加载宝箱配置
                OutManMessage("加载宝箱配置成功[" + M2Share.BoxsList.Count + "]...");
                FrmDB.LoadSuitItemList();// 读取套装装备数据
                OutManMessage("加载套装配置成功[" + M2Share.SuitItemList.Count + "]...");
                FrmDB.LoadSellOffItemList();// 读取元宝寄售列表
                OutManMessage("加载元宝寄售数据成功[" + M2Share.sSellOffItemList.Count + "]...");
                FrmDB.LoadRefineItem();
                OutManMessage("加载淬炼配置信息成功[" + M2Share.g_RefineItemList.Count + "]...");
                FrmDB.LoadMonFireDragonGuard();// 创建守护兽并写入列表
                if ((M2Share.nServerIndex == 0))
                {
                    FrmSrvMsg.StartMsgServer();
                }
                else
                {
                    FrmMsgClient.ConnectMsgServer();
                }
                StartEngine();
                M2Share.boStartReady = true;
                M2Share.g_dwRunTick = HUtil32.GetTickCount();
                M2Share.n4EBD1C = 0;
                M2Share.g_dwUsrRotCountTick = HUtil32.GetTickCount();
                M2Share.ThreadManage = new ThreadManage(RunEngine, new CycExecution(DateTime.Now, new TimeSpan(0, 0, 0, 0, 100)));
                M2Share.ThreadManage.Start();
                g_GateSocket = GateSocket;
                GateSocket.Init();
                GateSocket.Start(M2Share.g_Config.sGateAddr, M2Share.g_Config.nGatePort);
                M2Share.dwSaveDataTick = HUtil32.GetTickCount();
            }
            catch (Exception E)
            {
                OutManMessage("服务器启动异常！！！" + E.Message);
            }
        }

        /// <summary>
        /// 启动引擎
        /// </summary>
        private void StartEngine()
        {
            int nCode;
            try
            {
                M2Share.FrmIDSoc.Initialize();
                OutManMessage("登录服务器连接初始化完成...");
                M2Share.g_MapManager.LoadMapDoor();
                OutManMessage("加载地图环境成功...");
                OutManMessage("正在初始化矿物数据...");
                MakeStoneMines(); // 制造矿物
                OutManMessage("矿物数据初始成功...");
                nCode = FrmDB.LoadMerchant();
                if (nCode < 0)
                {
                    OutManMessage("交易NPC列表加载失败 ！！！" + "错误码: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("加载交易NPC列表成功...");
                }
                if (!M2Share.g_Config.boVentureServer)
                {
                    nCode = FrmDB.LoadGuardList();
                    if (nCode < 0)
                    {
                        OutManMessage("守卫列表加载失败 ！！！" + "错误码: " + nCode);
                    }
                    else
                    {
                        OutManMessage("加载守卫列表成功...");
                    }
                }
                nCode = FrmDB.LoadNpcs();
                if (nCode < 0)
                {
                    OutManMessage("管理NPC列表加载失败 ！！！" + "错误码: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("加载管理NPC列表成功...");
                }
                nCode = FrmDB.LoadMakeItem();
                if (nCode < 0)
                {
                    OutManMessage("炼制物品信息加载失败 ！！！" + "错误码: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("加载炼制物品信息成功...");
                }
                nCode = FrmDB.LoadStartPoint();
                if (nCode < 0)
                {
                    OutManMessage("加载回城点配置时出现错误 ！！！(错误码: " + nCode + ")");
                    return;
                }
                else
                {
                    OutManMessage("加载回城点配置成功...");
                }
                OutManMessage("人物数据引擎启动成功...");
                M2Share.UserEngine.Initialize();
                M2Share.NoticeManager.LoadingNotice();//读取公告
                M2Share.g_GuildManager.LoadGuildInfo();// 加载行会列表
                M2Share.g_CastleManager.LoadCastleList();
                OutManMessage("加载城堡列表成功...");
                M2Share.g_CastleManager.Initialize();
                OutManMessage("城堡城初始完成...");
                OutManMessage("游戏处理引擎初始化成功...");
                M2Share.g_MapManager.MakeSafePkZone();  // 制造安全区光圈
                SetWindowTitle(M2Share.g_Config.sServerName);//设置程序标题
                boSaveData = true;// 保存数据;
                SaveVariableTimer.Enabled = true;
                M2Share.ThreadManage = new ThreadManage(ConnectTimerTimer, new CycExecution(DateTime.Now, new TimeSpan(0, 0, 0, 0, 3000)));
                M2Share.ThreadManage.Start();
            }
            catch
            {
                M2Share.MainOutMessage("服务启动时出现异常错误 ！！！");
            }
        }

        /// <summary>
        /// 制造石矿
        /// </summary>
        private void MakeStoneMines()
        {
            var MapMineList = M2Share.g_MapManager.m_MapList.FindAll(p => { return p.m_boMINE; });//返回可以挖矿的地图列表

            foreach (var Envir in MapMineList)
            {
                if (Envir.m_boMINE)
                {
                    for (int nW = 0; nW < Envir.m_nWidth; nW++)
                    {
                        for (int nH = 0; nH < Envir.m_nHeight; nH++)
                        {
                            new TStoneMineEvent(Envir, nW, nH, M2Share.ET_STONEMINE);
                        }
                    }
                }
            }
        }

        public void FormCreate(object sender, EventArgs e)
        {
            GateSocket = new IServerSocket(20, Int16.MaxValue);
            GateSocket.OnClientConnect += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientConnect);
            GateSocket.OnClientDisconnect += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientDisconnect);

            //GateSocket.OnClientError += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientError);
            GateSocket.OnClientRead += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientRead);

            DBSocket = new IClientScoket();
            DBSocket.OnConnected += new DSCClientOnConnectedHandler(DBSocketConnect);
            DBSocket.ReceivedDatagram += new DSCClientOnDataInHandler(DBSocketRead);

            M2Share.ThreadManage = new ThreadManage(InitEngine, new ImmediateExecution());
            M2Share.ThreadManage.Start();
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        /// <summary>
        /// 数据库连接成功，显示远程IP及端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBSocketConnect(object sender, DSCClientConnectedEventArgs e)
        {
            M2Share.MainOutMessage("数据库服务器[" + DBSocket.Address + ':' + DBSocket.Port + "]连接成功...");
            M2Share.g_nSaveRcdErrorCount = 0;
        }

        /// <summary>
        /// 数据库连接错误
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Socket"></param>
        /// <param name="ErrorEvent"></param>
        /// <param name="ErrorCode"></param>
        private void DBSocketError(object sender, DSCClientConnectedEventArgs e)
        {
            OutManMessage("[Error]:DBSocketError");
        }

        /// <summary>
        /// 读取数据库数据,即DBserver.exe 回传的数据
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Socket"></param>
        private unsafe void DBSocketRead(object sender, DSCClientDataInEventArgs e)
        {
            string tStr = string.Empty;
            HUtil32.EnterCriticalSection(M2Share.UserDBSection);
            try
            {
                fixed (byte* pb = e.Data)
                {
                    tStr = HUtil32.SBytePtrToString((sbyte*)pb, 0, e.Data.Length);
                }
                M2Share.g_Config.sDBSocketRecvText = M2Share.g_Config.sDBSocketRecvText + tStr;// ReceiveText表示收到的文本内容
                if (!M2Share.g_Config.boDBSocketWorking)
                {
                    M2Share.g_Config.sDBSocketRecvText = "";
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.UserDBSection);
            }
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ThreadExceptionEventArgs error = e;
            if (error != null)
            {
                MessageBox.Show(string.Format("Application UnhandledException:{0};\n堆栈信息:{1}", error.Exception.Message, error.Exception.StackTrace));
            }
            else
            {
                MessageBox.Show(string.Format("Application UnhandledError:{0}", e));
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = e.ExceptionObject as Exception;
            if (error != null)
            {
                MessageBox.Show(string.Format("Application UnhandledException:{0};\n堆栈信息:{1}", error.Message, error.StackTrace));
            }
            else
            {
                MessageBox.Show(string.Format("Application UnhandledError:{0}", e));
            }
        }

        /// <summary>
        /// 拦截窗体关闭消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            const string sCloseServerYesNo = "是否确认关闭游戏服务器？";
            const string sCloseServerTitle = "确认信息";
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                if (!boServiceStarted) // 如果没有服务开始
                {
                    System.Environment.Exit(System.Environment.ExitCode);
                    return;
                }
                if (M2Share.g_boExitServer)
                {
                    M2Share.boStartReady = false;
                    return;
                }
                if (MessageBox.Show(sCloseServerYesNo, sCloseServerTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    M2Share.g_boExitServer = true;
                    CloseGateSocket();
                    M2Share.g_Config.boKickAllUser = true;
                    M2Share.ThreadManage = new ThreadManage(CloseTimerTimer, new ImmediateExecution());
                    M2Share.ThreadManage.Start();
                }
                else
                {
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void CloseTimerTimer(object sender)
        {
            // FrmDB.SaveSellOffItemList;//保存元宝寄售列表
            SetWindowTitle(string.Format("{0} [正在关闭服务器({1} {2}/{3} {4})...]", M2Share.g_Config.sServerName, "人物",
                M2Share.UserEngine.OnlinePlayObject, "数据", M2Share.FrontEngine.SaveListCount()));
            if (M2Share.UserEngine.OnlinePlayObject == 0)
            {
                if (M2Share.FrontEngine.IsIdle())
                {
                    SetWindowTitle(string.Format("{0} [服务器已关闭]", M2Share.g_Config.sServerName));
                    boSaveData = false;
                    M2Share.dwSaveDataTick = HUtil32.GetTickCount() - 600000; // 1000 * 60 * 10
                    SaveItemsData();
                    StopService();
                    M2Share.ThreadManage.Stop();
                    this.Close();
                    //Process.GetCurrentProcess().CloseMainWindow();
                }
            }
        }

        // 保存物品数据
        private void SaveItemsData()
        {
            if (HUtil32.GetTickCount() - M2Share.dwSaveDataTick > 480000) // 1000 * 60 * 8
            {
                M2Share.dwSaveDataTick = HUtil32.GetTickCount();
                if (M2Share.sSellOffItemList != null)
                {
                    FrmDB.SaveSellOffItemList();
                }

                // 保存元宝寄售数据
                //if (GameMsgDef.g_Storage != null)
                //{
                //    GameMsgDef.g_Storage.SaveToFile(GameMsgDef.g_StorageFileName);
                //}
                SaveItemNumber();
            }
        }

        private void SaveVariableTimerTimer(Object Sender)
        {
            try
            {
                SaveItemNumber();
                if (boSaveData)
                {
                    SaveItemsData();
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} SaveVariableTimerTimer");
            }
        }

        /// <summary>
        /// 客户端连接错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientError(object sender, NetFramework.AsyncUserToken e)
        {
            //M2Share.RunSocket.CloseErrGate(e.Client.ClientSocket);
        }

        /// <summary>
        /// 断开客户连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientDisconnect(object sender, NetFramework.AsyncUserToken e)
        {
            M2Share.RunSocket.CloseGate(e);
        }

        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientConnect(object sender, NetFramework.AsyncUserToken e)
        {
            M2Share.RunSocket.AddGate(e);
        }

        /// <summary>
        /// 客户端发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientRead(object sender, NetFramework.AsyncUserToken e)
        {
            M2Share.RunSocket.SocketRead(e);
        }

        private void RunEngine(object obj)
        {
            try
            {
                if (M2Share.boStartReady)
                {
                    M2Share.RunSocket.Run();
                    M2Share.FrmIDSoc.Run();
                    M2Share.UserEngine.Run();// 引擎启动
                    ProcessGameRun();
                    FrmMsgClient.Run();
                }
                M2Share.n4EBD1C++;
                if ((HUtil32.GetTickCount() - M2Share.g_dwRunTick) > 250)
                {
                    M2Share.g_dwRunTick = HUtil32.GetTickCount();
                    M2Share.nRunTimeMin = M2Share.n4EBD1C;
                    if (M2Share.nRunTimeMax > M2Share.nRunTimeMin) { M2Share.nRunTimeMax = M2Share.nRunTimeMin; }
                    M2Share.n4EBD1C = 0;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} RunTimerTimer");
            }
        }

        /// <summary>
        /// 间隔三秒，检查DBServer和LoginSrv连接是否正常
        /// </summary>
        /// <param name="Sender"></param>
        private void ConnectTimerTimer(object Sender)
        {
            try
            {
                if (boSaveData)
                {
                    if (!DBSocket.IsConnected)//检查DBServer连接是否正常
                    {
                        DBSocket.Connect(DBSocket.Address, DBSocket.Port);
                    }
                    if (!M2Share.g_Config.boIDSocketConnected) //检查LoginSrv连接是否正常
                    {
                        M2Share.FrmIDSoc.Connected();
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} ConnectTimerTimer");
            }
        }

        private void ReloadConfig(object Sender)
        {
            try
            {
                M2Share.LoadConfig();
                LoadServerTable();
            }
            finally
            {
            }
        }

        public void MemoLogChange(object sender, EventArgs e)
        {
            if (MemoLog.TextLength > 500)
            {
                MemoLog.Clear();
            }
        }

        public void MemoLogDblClick(object sender, EventArgs e)
        {
            ClearMemoLog();
        }

        public void MENU_CONTROL_EXITClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MENU_CONTROL_RELOAD_CONFClick(object sender, EventArgs e)
        {
            ReloadConfig(sender);
        }

        public void MENU_CONTROL_CLEARLOGMSGClick(object sender, EventArgs e)
        {
            ClearMemoLog();
        }

        public void SpeedButton1Click(Object Sender)
        {
            ReloadConfig(Sender);
        }

        public void MENU_CONTROL_RELOAD_ITEMDBClick(object sender, EventArgs e)
        {
            M2Share.GameDataBase.LoadItemsDB();
            M2Share.MainOutMessage("重新加载物品数据库完成...");
        }

        public void MENU_CONTROL_RELOAD_MAGICDBClick(object sender, EventArgs e)
        {
            M2Share.GameDataBase.LoadMagicDB();
            M2Share.MainOutMessage("重新加载技能数据库完成...");
        }

        public void MENU_CONTROL_RELOAD_MONSTERDBClick(object sender, EventArgs e)
        {
            M2Share.GameDataBase.LoadMonsterDB();
            M2Share.MainOutMessage("重新加载怪物数据库完成...");
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        private void StartService()
        {
            Config = M2Share.g_Config;// 初始化参数
            M2Share.nRunTimeMax = 99999;
            M2Share.g_nSockCountMax = 0;
            M2Share.g_nUsrTimeMax = 0;
            M2Share.g_nHumCountMax = 0;
            M2Share.g_nMonTimeMax = 0;
            M2Share.g_nMonGenTimeMax = 0;
            M2Share.g_nMonProcTime = 0;
            M2Share.g_nMonProcTimeMin = 0;
            M2Share.g_nMonProcTimeMax = 0;
            M2Share.dwUsrRotCountMin = 0;
            M2Share.dwUsrRotCountMax = 0;
            M2Share.g_nProcessHumanLoopTime = 0;
            M2Share.g_dwHumLimit = 30;
            M2Share.g_dwMonLimit = 30;
            M2Share.g_dwZenLimit = 5;
            M2Share.g_dwNpcLimit = 5;
            M2Share.g_dwSocLimit = 10;
            M2Share.nDecLimit = 20;
            Config.sDBSocketRecvText = "";
            Config.boDBSocketWorking = false;
            Config.nLoadDBErrorCount = 0;
            Config.nLoadDBCount = 0;
            Config.nSaveDBCount = 0;
            Config.nDBQueryID = 0;
            Config.nItemNumber = 0;
            Config.nItemNumberEx = Int32.MaxValue / 2;
            M2Share.boStartReady = false;
            M2Share.g_boExitServer = false;
            M2Share.boFilterWord = true;
            Config.nWinLotteryCount = 0;
            Config.nNoWinLotteryCount = 0;
            Config.nWinLotteryLevel1 = 0;
            Config.nWinLotteryLevel2 = 0;
            Config.nWinLotteryLevel3 = 0;
            Config.nWinLotteryLevel4 = 0;
            Config.nWinLotteryLevel5 = 0;
            Config.nWinLotteryLevel6 = 0;
            M2Share.Init();
            M2Share.LoadConfig();
            M2Share.nServerIndex = 0;
            M2Share.GameDataBase = new GameDataBase();
            M2Share.RunSocket = new TRunSocket();
            M2Share.MainLogMsgList = new Queue<string>();
            M2Share.GameLogMsgList = new Queue<string>();
            M2Share.LogStringList = new TStringList();
            M2Share.LogonCostLogList = new TStringList();
            M2Share.g_MapManager = new TMapManager();
            M2Share.ItemUnit = new TItemUnit();
            M2Share.MagicManager = new TMagicManager();
            M2Share.NoticeManager = new TNoticeManager();
            M2Share.g_GuildManager = new TGuildManager();
            M2Share.g_EventManager = new TEventManager();
            M2Share.g_CastleManager = new TCastleManager();
            M2Share.FrontEngine = new TFrontEngine(true);
            M2Share.UserEngine = new TUserEngine();
            M2Share.FrmIDSoc = new TFrmIDSoc();
            M2Share.FrmMsgClient = new TFrmMsgClient();
            M2Share.FrmSrvMsg = new TFrmSrvMsg();
            M2Share.RobotManage = new TRobotManage();
            M2Share.g_MakeItemList = new TStringList();
            M2Share.g_RefineItemList = new List<TRefineItemInfo>();// 淬炼配置列表
            M2Share.g_StartPointList = new List<TStartPoint>();
            M2Share.ServerTableList = new List<TStringList>();
            M2Share.g_DenySayMsgList = new IList<string, uint>();
            M2Share.MiniMapList = new List<TMinMapInfo>();
            M2Share.g_UnbindList = new List<IntPtr>();//解包物品列表
            M2Share.LineNoticeList = new TStringList();
            M2Share.g_UserCmdList = new TStringList();// 自定义命令列表
            M2Share.g_CheckItemList = new List<TCheckItem>();// 禁止物品规则
            M2Share.g_MsgFilterList = new List<TFilterMsg>();// 消息过滤规则
            M2Share.g_ShopItemList = new List<IntPtr>();// 商铺物品列表
            M2Share.QuestDiaryList = new List<TQDDinfo>();
            M2Share.BoxsList = new List<IntPtr>();//  宝箱
            M2Share.SuitItemList = new List<TSuitItem>();//  套装
            M2Share.sSellOffItemList = new List<IntPtr>();// 元宝寄售列表
            M2Share.ItemEventList = new TStringList();
            M2Share.AbuseTextList = new TStringList();
            M2Share.g_MonSayMsgList = new TStringList();
            M2Share.g_DisableMakeItemList = new TStringList();
            M2Share.g_EnableMakeItemList = new TStringList();
            M2Share.g_DisableMoveMapList = new TStringList();
            M2Share.g_ItemNameList = new TStringList();
            M2Share.g_DisableSendMsgList = new TStringList();
            M2Share.g_MonDropLimitLIst = new List<TMonDrop>();
            M2Share.g_DisableTakeOffList = new TStringList();
            M2Share.g_UnMasterList = new TStringList();
            M2Share.g_UnForceMasterList = new TStringList();
            M2Share.g_GameLogItemNameList = new TStringList();
            M2Share.g_DenyIPAddrList = new TStringList();
            M2Share.g_DenyChrNameList = new TStringList();
            M2Share.g_DenyAccountList = new TStringList();
            M2Share.g_NoClearMonList = new TStringList();
            M2Share.g_ItemBindIPaddr = new List<TItemBind>();
            M2Share.g_ItemBindAccount = new List<TItemBind>();
            M2Share.g_ItemBindCharName = new List<TItemBind>();// 物品人物绑定表(对应的玩家才能戴物品
            M2Share.g_ItemBindDieNoDropName = new List<TItemBind>();// 人物装备死亡不爆列表

            // GameMsgDef.g_Storage = new TStorage();
            M2Share.g_MapEventListOfDropItem = new List<TMapEvent>();
            M2Share.g_MapEventListOfPickUpItem = new List<TMapEvent>();
            M2Share.g_MapEventListOfMine = new List<TMapEvent>();
            M2Share.g_MapEventListOfWalk = new List<TMapEvent>();
            M2Share.g_MapEventListOfRun = new List<TMapEvent>();
            M2Share.LogMsgCriticalSection = new object();
            M2Share.ProcessMsgCriticalSection = new object();
            M2Share.ProcessHumanCriticalSection = new object();
            M2Share.HumanSortCriticalSection = new object();
            M2Share.g_Config.UserIDSection = new object();
            M2Share.UserDBSection = new object();
            M2Share.g_DynamicVarList = new List<TDynamicVar>();
     
            if (!Directory.Exists(M2Share.g_Config.sLogDir))
            {
                Directory.CreateDirectory(Config.sLogDir);
            }
            M2Share.nShiftUsrDataNameNo = 1;
            OutManMessage("正在读取配置信息...");
            DBSocket.Address = M2Share.g_Config.sDBAddr;
            DBSocket.Port = M2Share.g_Config.nDBPort;
            SetWindowTitle(M2Share.g_Config.sServerName);

            //LoadServerTable();
            //IdUDPClientLog.Host = M2Share.g_Config.sLogServerAddr;
            //IdUDPClientLog.Port = M2Share.g_Config.nLogServerPort;
            M2Share.g_dwStartTick = HUtil32.GetTickCount();
            boServiceStarted = true;
            M2Share.dwSaveDataTick = HUtil32.GetTickCount() + 300000;// 1000 * 60 * 5
            M2Share.g_StorageFileName = M2Share.g_Config.sEnvirDir + "\\Market_Storage\\";
            if (!Directory.Exists(M2Share.g_StorageFileName))
            {
                Directory.CreateDirectory(M2Share.g_StorageFileName);
            }
            M2Share.g_StorageFileName = M2Share.g_StorageFileName + "UserStorage.db";
            M2Share.ThreadManage = new ThreadManage(RefreshData, new CycExecution(DateTime.Now, new TimeSpan(0, 0, 0, 0, 2000)));
            M2Share.ThreadManage.Start();
            MemStatus.Invoke((MethodInvoker)delegate() { MemStatus.Text = EngineVersion.g_BuildVer; });
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        private void StopService()
        {
            int I;
            TGameConfig Config;
            try
            {
                Config = M2Share.g_Config;
                GateSocket.Shutdown();
                SaveItemNumber();// 保存系统变量
                M2Share.MainLogMsgList = null;
                M2Share.LogStringList = null;
                M2Share.LogonCostLogList = null;
                M2Share.g_EventManager = null;
                M2Share.ServerTableList = null;
                M2Share.g_DenySayMsgList = null;
                M2Share.MiniMapList = null;
                M2Share.g_UnbindList = null;
                M2Share.LineNoticeList = null;
                M2Share.g_UserCmdList = null;// 自定义命令列表
                M2Share.QuestDiaryList = null;
                M2Share.g_CheckItemList = null;// 禁止物品规则
                M2Share.g_MsgFilterList = null;// 消息过滤规则
                unsafe
                {
                    if (M2Share.g_ShopItemList.Count > 0) // 商铺物品列表
                    {
                        for (I = 0; I < M2Share.g_ShopItemList.Count; I++)
                        {
                            if (M2Share.g_ShopItemList[I] != null)
                            {
                                System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)M2Share.g_ShopItemList[I]);//by John 关闭时释放商城物品数据
                            }
                        }
                    }
                }
                M2Share.g_ShopItemList = null;
                if (M2Share.BoxsList.Count > 0)
                {
                    for (I = 0; I < M2Share.BoxsList.Count; I++)
                    {
                        if (M2Share.BoxsList[I] != null)
                        {
                            System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)M2Share.BoxsList[I]);//by John 关闭时释放非托管指针
                        }
                    }
                }
                M2Share.BoxsList = null;// 宝箱
                M2Share.SuitItemList = null; //套装 托管类GC释放
                if (M2Share.sSellOffItemList.Count > 0) // 元宝寄售列表
                {
                    for (I = 0; I < M2Share.sSellOffItemList.Count; I++)
                    {
                        if (M2Share.sSellOffItemList[I] != null)
                        {
                            System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)M2Share.sSellOffItemList[I]);//by John 关闭时释放非托管指针
                        }
                    }
                }
                M2Share.sSellOffItemList = null;// 元宝寄售列表
                M2Share.ItemEventList = null;
                M2Share.AbuseTextList = null;
                M2Share.g_HighMCHuman = null;
                M2Share.g_DisableMakeItemList = null;
                M2Share.g_EnableMakeItemList = null;
                M2Share.g_DisableMoveMapList = null;
                M2Share.g_ItemNameList = null;
                M2Share.g_DisableSendMsgList = null;
                M2Share.g_MonDropLimitLIst = null;
                M2Share.g_DisableTakeOffList = null;
                M2Share.g_UnMasterList = null;
                M2Share.g_UnForceMasterList = null;
                M2Share.g_GameLogItemNameList = null;
                M2Share.g_DenyIPAddrList = null;
                M2Share.g_DenyChrNameList = null;
                M2Share.g_DenyAccountList = null;
                M2Share.g_NoClearMonList = null;
                //GameMsgDef.g_Storage.UnLoadBigStorageList();
                //GameMsgDef.g_Storage.Free;
                M2Share.g_ItemBindIPaddr = null;//托管类
                M2Share.g_ItemBindAccount = null;//托管类
                M2Share.g_ItemBindCharName = null;//托管类
                M2Share.g_ItemBindDieNoDropName = null;
                M2Share.g_MapEventListOfDropItem = null;
                M2Share.g_MapEventListOfPickUpItem = null;
                M2Share.g_MapEventListOfMine = null;
                M2Share.g_MapEventListOfWalk = null;
                M2Share.g_MapEventListOfRun = null;
                M2Share.g_DynamicVarList = null;
                M2Share.g_BindItemTypeList = null;
                M2Share.g_AllowPickUpItemList = null;
                M2Share.g_ItemDblClickList = null;
                M2Share.g_StartPointList = null;
                M2Share.g_MakeItemList = null;
                if (M2Share.g_RefineItemList.Count > 0) //非托管
                {
                    for (I = 0; I < M2Share.g_RefineItemList.Count; I++)
                    {
                        //if (((M2Share.g_RefineItemList.Values[I]) as ArrayList).Count > 0)
                        //{
                        //    for (K = 0; K < ((M2Share.g_RefineItemList.Values[I]) as ArrayList).Count; K ++ )
                        //    {
                        //        if (((TRefineItemInfo)(((M2Share.g_RefineItemList.Values[I]) as ArrayList)[K])) != null)
                        //        {
                        //            this.Dispose(((TRefineItemInfo)(((M2Share.g_RefineItemList.Values[I]) as ArrayList)[K])));
                        //        }
                        //    }
                        //}
                        // ((M2Share.g_RefineItemList.Values[I]) as ArrayList).Free;
                    }
                }
                M2Share.g_RefineItemList = null;
                boServiceStarted = false;
            }
            catch
            {
            }
        }

        public void MENU_HELP_ABOUTClick(object sender, EventArgs e)
        {
            if (!(TfrmRegister.frmRegister != null))
            {
                TfrmRegister FrmAbout = new TfrmRegister();
                try
                {
                    FrmAbout.Icon = this.Icon;
                    FrmAbout.Open();
                }
                finally
                {
                    FrmAbout.Dispose();
                }
            }
        }

        public void MENU_OPTION_SERVERCONFIGClick(object sender, EventArgs e)
        {
            if (!(TFrmServerValue.FrmServerValue != null))
            {
                TFrmServerValue FrmServerValue = new TFrmServerValue();
                try
                {
                    FrmServerValue.Top = this.Top + 20;
                    FrmServerValue.Left = this.Left;
                    FrmServerValue.AdjuestServerConfig();
                }
                finally
                {
                    FrmServerValue.Dispose();
                }
            }
        }

        public void MENU_OPTION_GENERALClick(object sender, EventArgs e)
        {
            if (!(TfrmGeneralConfig.frmGeneralConfig != null))
            {
                TfrmGeneralConfig frmGeneralConfig = new TfrmGeneralConfig();
                try
                {
                    frmGeneralConfig.Top = this.Top + 20;
                    frmGeneralConfig.Left = this.Left;
                    frmGeneralConfig.Icon = this.Icon;
                    frmGeneralConfig.Open();
                }
                finally
                {
                    frmGeneralConfig.Dispose();
                }
            }
            this.Text = M2Share.g_Config.sServerName;
        }

        public void MENU_OPTION_GAMEClick(object sender, EventArgs e)
        {
            if (!(TfrmGameConfig.frmGameConfig != null))
            {
                TfrmGameConfig frmGameConfig = new TfrmGameConfig();
                try
                {
                    frmGameConfig.Top = this.Top + 20;
                    frmGameConfig.Left = this.Left;
                    frmGameConfig.Icon = this.Icon;
                    frmGameConfig.Open();
                }
                finally
                {
                    frmGameConfig.Dispose();
                }
            }
        }

        public void MENU_OPTION_FUNCTIONClick(object sender, EventArgs e)
        {
            if (!(TfrmFunctionConfig.frmFunctionConfig != null))
            {
                TfrmFunctionConfig frmFunctionConfig = new TfrmFunctionConfig();
                try
                {
                    frmFunctionConfig.Top = this.Top + 20;
                    frmFunctionConfig.Left = this.Left;
                    frmFunctionConfig.Icon = this.Icon;
                    frmFunctionConfig.Open();
                }
                finally
                {
                    frmFunctionConfig.Dispose();
                }
            }
        }

        public void G1Click(object sender, EventArgs e)
        {
            if (!(TfrmGameCmd.frmGameCmd != null))
            {
                TfrmGameCmd frmGameCmd = new TfrmGameCmd();
                try
                {
                    frmGameCmd.Top = this.Top + 20;
                    frmGameCmd.Left = this.Left;
                    frmGameCmd.Icon = this.Icon;
                    frmGameCmd.Open();
                }
                finally
                {
                    frmGameCmd.Dispose();
                }
            }
        }

        public void MENU_OPTION_MONSTERClick(object sender, EventArgs e)
        {
            //if (!(MonsterConfig.Units.MonsterConfig.frmMonsterConfig != null))
            //{
            //    MonsterConfig.Units.MonsterConfig.frmMonsterConfig = new TfrmMonsterConfig(this.Owner);
            //    try {
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Top = this.Top + 20;
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Left = this.Left;
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Open();
            //    } finally {
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Free;
            //    }
            //}
        }

        public void MENU_CONTROL_RELOAD_MONSTERSAYClick(object sender, EventArgs e)
        {
            M2Share.UserEngine.ClearMonSayMsg();
            M2Share.LoadMonSayMsg();
            M2Share.MainOutMessage("重新加载怪物说话配置完成...");
        }

        public void MENU_CONTROL_RELOAD_DISABLEMAKEClick(object sender, EventArgs e)
        {
            M2Share.LoadDisableTakeOffList();
            M2Share.LoadDisableMakeItem();
            M2Share.LoadEnableMakeItem();
            M2Share.LoadDisableMoveMap();
            M2Share.ItemUnit.LoadCustomItemName();
            M2Share.LoadDisableSendMsgList();
            M2Share.LoadGameLogItemNameList();
            M2Share.LoadItemBindIPaddr();
            M2Share.LoadItemBindAccount();
            M2Share.LoadItemBindCharName();
            M2Share.LoadItemBindDieNoDropName();// 读取人物装备死亡不爆列表
            M2Share.LoadUnMasterList();
            M2Share.LoadUnForceMasterList();
            M2Share.LoadDenyIPAddrList();
            M2Share.LoadDenyAccountList();
            M2Share.LoadDenyChrNameList();// 加载禁止登录人物列表
            M2Share.LoadNoClearMonList();
            FrmDB.LoadAdminList();
            M2Share.MainOutMessage("重新加载列表配置完成...");
        }

        public void MENU_CONTROL_RELOAD_STARTPOINTClick(object sender, EventArgs e)
        {
            FrmDB.LoadStartPoint();
            M2Share.MainOutMessage("重新地图安全区列表完成...");
        }

        public void MENU_CONTROL_GATE_OPENClick(object sender, EventArgs e)
        {
            //const string sGatePortOpen = "游戏网关端口({0}:{1})已打开...";
            //if (!GateSocket.Active)
            //{
            //    GateSocket.Active = true;
            //    M2Share.MainOutMessage(string.Format(sGatePortOpen, GateSocket.Address, GateSocket.Port));
            //}
        }

        public void MENU_CONTROL_GATE_CLOSEClick(object sender, EventArgs e)
        {
            CloseGateSocket();
        }

        // 清除日志
        private void CloseGateSocket()
        {
            int I;
            const string sGatePortClose = "游戏网关端口(%s:%d)已关闭...";

            //if (GateSocket.Active)
            //{
            //    if (GateSocket.Socket.ActiveConnections > 0)
            //    {
            //        for (I = 0; I < GateSocket.Socket.ActiveConnections; I ++ )
            //        {
            //            GateSocket.Socket.Connections[I].Close;
            //        }
            //    }
            //    GateSocket.Active = false;
            //    M2Share.MainOutMessage(string.Format(sGatePortClose, new object[] {GateSocket.Address, GateSocket.Port}));
            //}
        }

        public void MENU_CONTROLClick(object sender, EventArgs e)
        {
            //if (GateSocket.Active)
            //{
            //    MENU_CONTROL_GATE_OPEN.Enabled = false;
            //    MENU_CONTROL_GATE_CLOSE.Enabled = true;
            //}
            //else
            //{
            //    MENU_CONTROL_GATE_OPEN.Enabled = true;
            //    MENU_CONTROL_GATE_CLOSE.Enabled = false;
            //}
        }

        public void MENU_VIEW_GATEClick(Object Sender)
        {
            // MENU_VIEW_GATE.Checked := not MENU_VIEW_GATE.Checked;
            // GridGate.Visible := MENU_VIEW_GATE.Checked;
        }

        public void MENU_VIEW_SESSIONClick(object sender, EventArgs e)
        {
            TfrmViewSession frmViewSession = new TfrmViewSession();
            frmViewSession.ShowDialog(this);
        }

        public void MENU_VIEW_ONLINEHUMANClick(object sender, EventArgs e)
        {
            TfrmViewOnlineHuman objFrom = new TfrmViewOnlineHuman();
            objFrom.ShowDialog(this);
        }

        public void MENU_VIEW_LEVELClick(object sender, EventArgs e)
        {
            TfrmViewLevel frmViewLevel = new TfrmViewLevel();
            frmViewLevel.ShowDialog(this);
        }

        public void MENU_VIEW_LISTClick(object sender, EventArgs e)
        {
            if (!(TfrmViewList.frmViewList != null))
            {
                TfrmViewList frmViewList = new TfrmViewList();
                try
                {
                    frmViewList.Top = this.Top + 20;
                    frmViewList.Left = this.Left;
                    frmViewList.Icon = this.Icon;
                    frmViewList.Open();
                }
                finally
                {
                    frmViewList.Dispose();
                }
            }
        }

        public void MENU_MANAGE_ONLINEMSGClick(object sender, EventArgs e)
        {
            TfrmOnlineMsg frmOnlineMsg = new TfrmOnlineMsg();
            frmOnlineMsg.ShowDialog(this);
        }

        public void MENU_MANAGE_PLUGClick(object sender, EventArgs e)
        {
            //if (!(PlugInManage.Units.PlugInManage.ftmPlugInManage != null))
            //{
            //    PlugInManage.Units.PlugInManage.ftmPlugInManage = new TftmPlugInManage(this.Owner);
            //    try {
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Top = this.Top + 20;
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Left = this.Left;
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Open();
            //    } finally {
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Free;
            //    }
            //}
        }

        /// <summary>
        /// 设置程序菜单
        /// </summary>
        public virtual void SetMenu()
        {
            this.Menu = MainMenu;
        }

        public void MENU_VIEW_KERNELINFOClick(object sender, EventArgs e)
        {
            TfrmViewKernelInfo frmViewKernelInfo = new TfrmViewKernelInfo();
            frmViewKernelInfo.ShowDialog(this);
        }

        public void MENU_TOOLS_MERCHANTClick(object sender, EventArgs e)
        {
            //if (!(ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant != null))
            //{
            //    ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant = new TfrmConfigMerchant(this.Owner);
            //    try {
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Top = this.Top + 20;
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Left = this.Left;
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Open();
            //    } finally {
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Free;
            //    }
            //}
        }

        public void MENU_OPTION_ITEMFUNCClick(object sender, EventArgs e)
        {
            //if (!(ItemSet.Units.ItemSet.frmItemSet != null))
            //{
            //    ItemSet.Units.ItemSet.frmItemSet = new TfrmItemSet(this.Owner);
            //    try {
            //        ItemSet.Units.ItemSet.frmItemSet.Top = this.Top + 20;
            //        ItemSet.Units.ItemSet.frmItemSet.Left = this.Left;
            //        ItemSet.Units.ItemSet.frmItemSet.Open();
            //    } finally {
            //        ItemSet.Units.ItemSet.frmItemSet.Free;
            //    }
            //}
        }

        private void ClearMemoLog()
        {
            if (MessageBox.Show("是否确定清除日志信息！！！", "提示信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MemoLog.Clear();
            }
        }

        public void MENU_TOOLS_MONGENClick(object sender, EventArgs e)
        {
            //if (!(ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen != null))
            //{
            //    ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen = new TfrmConfigMonGen(this.Owner);
            //    try {
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Top = this.Top + 20;
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Left = this.Left;
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Open();
            //    } finally {
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Free;
            //    }
            //}
        }

        /// <summary>
        /// 查询IP所在地区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MENU_TOOLS_IPSEARCHClick(object sender, EventArgs e)
        {
            string sIPaddr = string.Empty;
            try
            {
                sIPaddr = "192.168.0.1";
                if (InputBox.Show("IP所在地区查询", "输入IP地址:", sIPaddr) == System.Windows.Forms.DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(InputBox.FileName))
                    {
                        return;
                    }
                    sIPaddr = InputBox.FileName;
                    if (!HUtil32.IsIPAddr(sIPaddr))
                    {
                        System.Windows.Forms.MessageBox.Show("输入的IP地址格式不正确！！！", "错误信息", System.Windows.Forms.MessageBoxButtons.OK);
                        return;
                    }
                    OutManMessage(string.Format("{0}:{1}", sIPaddr, M2Share.GetIPLocal(sIPaddr)));
                }
            }
            catch
            {
                OutManMessage(string.Format("{0}:{1}", sIPaddr, M2Share.GetIPLocal(sIPaddr)));
            }
        }

        public void MENU_MANAGE_CASTLEClick(object sender, EventArgs e)
        {
            //if (!(CastleManage.Units.CastleManage.frmCastleManage != null))
            //{
            //    CastleManage.Units.CastleManage.frmCastleManage = new TfrmCastleManage(this.Owner);
            //    try {
            //        CastleManage.Units.CastleManage.frmCastleManage.Top = this.Top + 20;
            //        CastleManage.Units.CastleManage.frmCastleManage.Left = this.Left;
            //        CastleManage.Units.CastleManage.frmCastleManage.Open();
            //    } finally {
            //        CastleManage.Units.CastleManage.frmCastleManage.Free;
            //    }
            //}
        }

        public void QFunctionNPCClick(object sender, EventArgs e)
        {
            if (M2Share.g_FunctionNPC != null)
            {
                M2Share.g_FunctionNPC.ClearScript();
                M2Share.g_FunctionNPC.LoadNpcScript();
                M2Share.MainOutMessage("QFunction 脚本加载完成...");
            }
        }

        public void QManageNPCClick(object sender, EventArgs e)
        {
            if (M2Share.g_ManageNPC != null)
            {
                M2Share.g_ManageNPC.ClearScript();
                M2Share.g_ManageNPC.LoadNpcScript();
                M2Share.MainOutMessage("重新加载登陆脚本完成...");
            }
        }

        public void RobotManageNPCClick(object sender, EventArgs e)
        {
            if (M2Share.g_RobotNPC != null)
            {
                M2Share.RobotManage.ReLoadRobot();
                M2Share.g_RobotNPC.ClearScript();
                M2Share.g_RobotNPC.LoadNpcScript();
                M2Share.MainOutMessage("重新加载机器人脚本完成...");
            }
        }

        public void MonItemsClick(object sender, EventArgs e)
        {
            TMonInfo Monster;
            try
            {
                if (M2Share.UserEngine.MonsterList.Count > 0)
                {
                    for (int I = 0; I < M2Share.UserEngine.MonsterList.Count; I++)
                    {
                        Monster = M2Share.UserEngine.MonsterList[I];
                        M2Share.GameDataBase.LoadMonitems(Monster.sName, ref Monster.ItemList);
                    }
                }
                M2Share.MainOutMessage("怪物爆物品列表重加载完成...");
            }
            catch
            {
                M2Share.MainOutMessage("怪物爆物品列表重加载失败！！！");
            }
        }

        public void MENU_OPTION_HEROClick(object sender, EventArgs e)
        {
            if (!(TfrmHeroConfig.frmHeroConfig != null))
            {
                TfrmHeroConfig frmHeroConfig = new TfrmHeroConfig();
                try
                {
                    frmHeroConfig.Top = this.Top;
                    frmHeroConfig.Left = this.Left;
                    frmHeroConfig.Icon = this.Icon;
                    frmHeroConfig.Open();
                }
                finally
                {
                    frmHeroConfig.Dispose();
                }
            }
        }

        public void N3Click(object sender, EventArgs e)
        {
            FrmDB.LoadBoxsList();// 重新加载宝箱列表
            M2Share.MainOutMessage("重新加载宝箱配置完成...");
        }

        public void N1Click(object sender, EventArgs e)
        {
            if (!(TfrmViewList2.frmViewList2 != null))
            {
                TfrmViewList2 frmViewList2 = new TfrmViewList2();
                try
                {
                    frmViewList2.Top = this.Top + 20;
                    frmViewList2.Left = this.Left;
                    frmViewList2.Icon = this.Icon;
                    frmViewList2.Open();
                }
                finally
                {
                    frmViewList2 = null;
                }
            }
        }

        public void N5Click(object sender, EventArgs e)
        {
            if (FrmDB.LoadMonGen() > 0)
            {
                M2Share.MainOutMessage("重新加载怪物刷新配置完成...");
            }
        }

        public void N6Click(object sender, EventArgs e)
        {
            if (M2Share.LoadLineNotice(M2Share.g_Config.sNoticeDir + "LineNotice.txt"))
            {
                M2Share.MainOutMessage("重新加载公告提示信息完成...");
            }
        }

        public void N7Click(object sender, EventArgs e)
        {
            FrmDB.LoadRefineItem();
            M2Share.MainOutMessage("重新加载淬炼配置信息完成...");
        }

        public void NPC1Click(object sender, EventArgs e)
        {
            FrmDB.ReLoadMerchants();
            M2Share.UserEngine.ReloadMerchantList();
            M2Share.MainOutMessage("重新加载交易NPC配置信息完成...");
        }

        public void NPC2Click(object sender, EventArgs e)
        {
            FrmDB.ReLoadNpc();
            M2Share.UserEngine.ReloadNpcList();
            M2Share.MainOutMessage("重新加载管理NPC配置信息完成...");
        }

        public void S1Click(object sender, EventArgs e)
        {
            M2Share.g_CastleManager.ReLoadCastle();
            M2Share.MainOutMessage("重新加载城堡配置信息完成...");
        }

        public void G2Click(object sender, EventArgs e)
        {
            if (!(TfrmGuildManage.frmGuildManage != null))
            {
                TfrmGuildManage frmGuildManage = new TfrmGuildManage();
                try
                {
                    frmGuildManage.Top = this.Top + 20;
                    frmGuildManage.Left = this.Left;
                    frmGuildManage.Icon = this.Icon;
                    frmGuildManage.Open();
                }
                finally
                {
                    frmGuildManage.Dispose();
                }
            }
        }

        public void N4Click(object sender, EventArgs e)
        {
            M2Share.LoadShopItemList();
            M2Share.MainOutMessage("重新加载商铺配置信息完成...");
        }

        public void mapconfigClick(object sender, EventArgs e)
        {
            FrmDB.LoadMapInfo();
            M2Share.MainOutMessage("重新加载地图配置信息完成...");
        }

        public void monsterClick(object sender, EventArgs e)
        {
            FrmDB.LoadMonGen();
            M2Share.MainOutMessage("重新加载刷怪配置信息完成...");
        }

        /// <summary>
        /// 输出引擎信息
        /// </summary>
        /// <param name="nMsg"></param>
        public void OutManMessage(string nMsg)
        {
            MemoLog.Invoke((MethodInvoker)delegate() { MemoLog.AppendText(nMsg + Environment.NewLine); });
        }

        internal void OutErroeMessage(string nMsg)
        {
            ErrorMemoLog.Invoke((MethodInvoker)delegate() { ErrorMemoLog.AppendText(nMsg + Environment.NewLine); });
        }

        private void MENU_MANAGE_SYS_Click(object sender, EventArgs e)
        {
            if (!(TfrmSysManager.frmSysManager != null))
            {
                TfrmSysManager frmSysManager = new TfrmSysManager();
                try
                {
                    frmSysManager.Top = this.Top + 20;
                    frmSysManager.Left = this.Left;
                    frmSysManager.Icon = this.Icon;
                    frmSysManager.Open();
                }
                finally
                {
                    frmSysManager.Dispose();
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            System.Environment.Exit(0);
            base.OnClosed(e);
        }
    }
}