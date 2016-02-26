using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GameFramework;
using GameFramework.Thrend;
using GameFramework.Enum;
using M2Server.ScriptSystem;
using M2Server.Base;

namespace M2Server
{
    public class TItemBind
    {
        // 物品绑定(绑定的玩家才能戴此物品)
        public int nMakeIdex;
        public int nItemIdx;// 物品分类
        public string sBindName;
    }

    /// <summary>
    ///  地图连接点
    /// </summary>
    public class TGateObj
    {
        public bool boFlag;
        public TEnvirnoment DEnvir;
        public int nDMapX;
        public int nDMapY;
    }

    /// <summary>
    /// 任务地图
    /// </summary>
    public class TMapQuestInfo
    {
        // 地图名称
        public string[] sMapName;
        public int nFlags;
        public int nFlag;
        public int nValue;
        public bool boFlag;
        public string[] sMonName;// 怪物名称
        public string[] sNeedItem;
        public string[] sScriptName;
        public bool boGroup;
        public string s08;
        public string s0C;
        public bool bo10;
        public TMerchant NPC;
    }

    public class TMagicEvent
    {
        public List<TBaseObject> BaseObjectList;
        public uint dwStartTick;
        public uint dwTime;
        public THolyCurtainEvent[] Events;
    }

    public struct TLevelInfo
    {
        public ushort wHP;
        public ushort wMP;
        public uint dwExp;
        public ushort wAC;
        public ushort wMaxAC;
        public ushort wACLimit;
        public ushort wMAC;
        public ushort wMaxMAC;
        public ushort wMACLimit;
        public ushort wDC;
        public ushort wMaxDC;
        public ushort wDCLimit;
        public uint dwDCExp;
        public ushort wMC;
        public ushort wMaxMC;
        public ushort wMCLimit;
        public uint dwMCExp;
        public ushort wSC;
        public ushort wMaxSC;
        public ushort wSCLimit;
        public uint dwSCExp;
    }

    public class M2Share 
    {
        /// <summary>
        /// 游戏参数配置文件
        /// </summary>
        public static IniFile Config = null;
        /// <summary>
        /// 游戏命令配置文件
        /// </summary>
        public static IniFile CommandConf = null;
        /// <summary>
        /// 提示信息配置文件
        /// </summary>
        public static IniFile StringConf = null;
        /// <summary>
        /// 全局变量配置文件
        /// </summary>
        public static IniFile GlobalConf = null;
        /// <summary>
        /// 游戏线程管理对象
        /// </summary>
        public static ThreadManage ThreadManage;
        public static int nServerIndex = 0;
        public static TRunSocket RunSocket = null;
        /// <summary>
        /// 脚本管理引擎
        /// </summary>
        public static ScriptEngine ScriptEngine;
        /// <summary>
        /// 消息输出列表
        /// </summary>
        public static Queue<string> MainLogMsgList = null;
        public static Queue<string> GameLogMsgList = null;
        public static GameDataBase GameDataBase;
        public static TStringList LogStringList = null;
        public static TStringList LogonCostLogList = null;
        public static TMapManager g_MapManager = null;// 地图管理类
        public static TItemUnit ItemUnit = null;
        public static TMagicManager MagicManager = null;
        public static TNoticeManager NoticeManager = null;
        public static TGuildManager g_GuildManager = null;// 行会管理类
        public static TEventManager g_EventManager = null;
        public static TCastleManager g_CastleManager = null;// 城堡管理类
        public static TFrontEngine FrontEngine = null;
        public static TUserEngine UserEngine = null;
        public static TFrmIDSoc FrmIDSoc = null;
        public static TFrmSrvMsg FrmSrvMsg = null;
        public static TFrmMsgClient FrmMsgClient = null;
        public static TRobotManage RobotManage = null;
        public static TStringList g_MakeItemList = null;// 制造物品列表
        public static List<TRefineItemInfo> g_RefineItemList = null;// 淬炼配置列表
        public static List<TStartPoint> g_StartPointList = null;
        public static List<TStringList> ServerTableList = null;
        public static IList<string, uint> g_DenySayMsgList = null;
        /// <summary>
        /// 小地图列表
        /// </summary>
        public static List<TMinMapInfo> MiniMapList = null;
        /// <summary>
        /// 解包物品列表
        /// </summary>
        public static List<IntPtr> g_UnbindList = null;
        /// <summary>
        /// 公告信息列表
        /// </summary>
        public static TStringList LineNoticeList = null;
        /// <summary>
        /// 自定义命令列表
        /// </summary>
        public static TStringList g_UserCmdList = null;
        public static List<TCheckItem> g_CheckItemList = null;// 禁止物品规则 
        public static List<TFilterMsg> g_MsgFilterList = null;// 消息过滤规则 
        public static List<IntPtr> g_ShopItemList = null;// 商铺物品列表 
        public static List<TQDDinfo> QuestDiaryList = null;
        public static TStringList ItemEventList = null;
        public static TStringList AbuseTextList = null;// 文字过滤列表 
        public static TStringList g_MonSayMsgList = null;// 怪物说明信息列表
        public static TStringList g_DisableMakeItemList = null;// 禁止制造物品列表
        public static TStringList g_EnableMakeItemList = null;// 制造物品列表
        public static TStringList g_DisableMoveMapList = null;// 禁止移动地图列表
        public static TStringList g_ItemNameList = null;// 物品别名列表
        public static TStringList g_DisableSendMsgList = null;// 禁止发信息名称列表
        public static List<TMonDrop> g_MonDropLimitLIst = null;// 怪物爆物品限制
        public static TStringList g_DisableTakeOffList = null;// 禁止取下物品列表
        public static List<IntPtr> BoxsList = null;// 宝箱物品列表 
        public static List<TSuitItem> SuitItemList = null;// 套装装备列表 
        public static List<IntPtr> sSellOffItemList = null;// 元宝寄售列表 
        //public static TStorage g_Storage = null;// 无限仓库
        public static string g_StorageFileName = String.Empty;
        public static uint dwSaveDataTick = 0;
        public static List<TMapEvent> g_MapEventListOfDropItem = null;// 地图触发掉物品
        public static List<TMapEvent> g_MapEventListOfPickUpItem = null;
        public static List<TMapEvent> g_MapEventListOfMine = null;
        public static List<TMapEvent> g_MapEventListOfWalk = null;
        public static List<TMapEvent> g_MapEventListOfRun = null;
        public static TStringList g_AllowPickUpItemList = null;// 分身允许捡取物品列表
        public static List<TItemEvent> g_ItemDblClickList = null;// 物品事件触发列表
        public static List<TBindItem> g_BindItemTypeList = null;
        public static List<TItemBind> g_ItemBindIPaddr = null;
        public static List<TItemBind> g_ItemBindAccount = null;
        public static List<TItemBind> g_ItemBindCharName = null;// 物品人物绑定表(对应的玩家才能戴物品)
        public static List<TItemBind> g_ItemBindDieNoDropName = null;// 人物装备死亡不爆列表
        public static TStringList g_UnMasterList = null;// 出师记录表
        public static TStringList g_UnForceMasterList = null;// 强行出师记录表
        public static TStringList g_GameLogItemNameList = null;// 游戏日志物品名
        public static bool g_boGameLogGold = false;// 是否写入日志(金币)
        public static bool g_boGameLogGameGold = false;// 是否写入日志(调整游戏币)
        public static bool g_boGameLogGameDiaMond = false;// 是否写入日志(调整金刚石) 
        public static bool g_boGameLogGameGird = false;// 是否写入日志(调整灵符) 
        public static bool g_boGameLogGameGlory = false;// 是否写入日志(调整荣誉值) 
        public static bool g_boGameLogGamePoint = false;// 是否写入日志(调整游戏点)
        public static bool g_boGameLogHumanDie = false;
        public static TStringList g_DenyIPAddrList = null;// IP过滤列表
        public static TStringList g_DenyChrNameList = null;// 角色过滤列表
        public static TStringList g_DenyAccountList = null;// 登录帐号过滤列表
        public static TStringList g_NoClearMonList = null;// 不清除怪物列表
        public static object LogMsgCriticalSection = null;//日志线程锁
        public static object ProcessMsgCriticalSection = null;
        public static object UserDBSection = null;
        public static object ProcessHumanCriticalSection = null;
        public static object HumanSortCriticalSection = null;
        public static int g_nTotalHumCount = 0;
        public static bool g_boMission = false;// 是否设置怪物集中点
        public static string g_sMissionMap = String.Empty;// 怪物集中点 地图
        public static int g_nMissionX = 0;// 怪物集中点X
        public static int g_nMissionY = 0;// 怪物集中点Y
        public static bool boStartReady = false;
        public static bool g_boExitServer = false;
        public static bool boFilterWord = false;
        public static int nRunTimeMin = 0;
        public static int nRunTimeMax = 0;
        public static int g_nBaseObjTimeMin = 0;
        public static int g_nBaseObjTimeMax = 0;
        public static uint g_nSockCountMin = 0;
        public static uint g_nSockCountMax = 0;
        public static uint g_nUsrTimeMin = 0;
        public static uint g_nUsrTimeMax = 0;
        public static uint g_nHumCountMin = 0;
        public static uint g_nHumCountMax = 0;
        public static uint g_nMonTimeMin = 0;
        public static uint g_nMonTimeMax = 0;
        public static uint g_nMonGenTime = 0;
        public static uint g_nMonGenTimeMin = 0;
        public static uint g_nMonGenTimeMax = 0;
        public static uint g_nMonProcTime = 0;
        public static uint g_nMonProcTimeMin = 0;
        public static uint g_nMonProcTimeMax = 0;
        public static uint dwUsrRotCountMin = 0;
        public static uint dwUsrRotCountMax = 0;
        public static uint g_dwUsrRotCountTick = 0;
        public static int g_nProcessHumanLoopTime = 0; //处理人物列表循环次数
        public static uint g_dwHumLimit = 30;
        public static uint g_dwMonLimit = 30;
        public static uint g_dwZenLimit = 5;
        public static uint g_dwNpcLimit = 5;
        public static uint g_dwSocLimit = 10;
        public static uint g_dwSocCheckTimeOut = 50;
        public static int nDecLimit = 20;
        public static int nShiftUsrDataNameNo = 0;
        public static string sConfig775FileName = ".\\775.txt";
        public static string sConfigFileName = ".\\!Setup.txt";
        public static string sExpConfigFileName = ".\\Exps.ini";
        public static string sCommandFileName = ".\\Command.ini";
        public static string sStringFileName = ".\\String.ini";
        public static string sGlobalFileName = ".\\Global.ini";
        public static uint g_dwStartTick = 0;// 启动间隔
        public static uint g_dwRunTick = 0;// 运行间隔
        public static int n4EBD1C = 0;
        public static int g_nGameTime = 0;
        public static string g_sMonGenInfo1 = String.Empty;
        public static string g_sMonGenInfo2 = String.Empty;
        public static TNormNpc g_ManageNPC = null;
        public static TNormNpc g_RobotNPC = null;
        public static TMerchant g_FunctionNPC = null;// 脚本触发NPC
        public static TMerchant g_BatterNPC = null;// 连击NPC
        public static IList<TDynamicVar> g_DynamicVarList = null;
        public static int nCurrentMonthly = 0;
        public static int nTotalTimeUsage = 0;
        public static int nLastMonthlyTotalUsage = 0;
        public static int nGrossTotalCnt = 0;
        public static int nGrossResetCnt = 0;
        public static int nCrackedLevel = 0;
        public static int nErrorLevel = 0;
        public static bool g_boMinimize = true;
        public static TRGBQuad[] ColorTable = new TRGBQuad[256];
        public static char g_GMRedMsgCmd = '!';
        public static int g_nGMREDMSGCMD = 6;
        public static uint g_dwSendOnlineTick = 0;
        public static TPlayObject g_HighLevelHuman = null;
        public static TPlayObject g_HighPKPointHuman = null;
        public static TPlayObject g_HighDCHuman = null;
        public static TPlayObject g_HighMCHuman = null;
        public static TPlayObject g_HighSCHuman = null;
        public static TPlayObject g_HighOnlineHuman = null;
        public static uint g_dwSpiritMutinyTick = 0;

        public static TGameConfig g_Config = new TGameConfig();
        // ===============================================================
        public static TLevelInfo[] g_LevelInfo = new TLevelInfo[MAXLEVEL + 1];
        public static uint[] g_dwOldNeedExps;
        public static uint[] g_dwHeroNeedExps;
        public static uint[] g_dwExpCrystalNeedExps;
        public static uint[] g_dwNGExpCrystalNeedExps;
        public static ushort[] g_dwMedicineExps;
        public static uint[] g_dwSkill68Exps;
        public static TGameCommand g_GameCommand = new TGameCommand();// 游戏命令方面参数

        // ===============================================================
        public static int nIPLocal = -1;
        public static int nStartModule = -1;
        public static uint dwStartTime = 0;
        public static uint dwStartTimeTick = 0;
        public static int g_nSaveRcdErrorCount = 0;
        public static uint g_dwShowSaveRcdErrorTick = 0;
        public const string g_sSellOffGoldInfo = "当前没有您的拍卖款";
        public const string g_sSellOffItemInfo = "您没有在这拍卖物品";
        /// <summary>
        /// 动作失败
        /// </summary>
        public const string sSTATUS_FAIL = "+FAIL/";
        /// <summary>
        /// 动作成功
        /// </summary>
        public const string sSTATUS_GOOD = "+GOOD/";
        public const int MAXLEVEL = ushort.MaxValue;
        public const int MAXCHANGELEVEL = 1000;
        public const int LOG_GAMEGOLD = 111;// 游戏币(日志代码)
        public const int LOG_GAMEPOINT = 112;// 游戏点(日志代码)
        public const int LOG_GameDiaMond = 113;// 金刚石(日志代码)
        public const int LOG_GameGird = 114;// 灵符(日志代码)
        public const int LOG_HeroLoyal = 115;// 英雄的忠诚度(日志代码)
        public const int LOG_GameGlory = 116;// 荣誉(日志代码)
        public const int ET_STONEMINE = 11;// 矿石
        public const string sSTRING_GOLDNAME = "金币";
        public const int SLAVEMAXLEVEL = 9;// 宝宝最大等级
        /// <summary>
        /// 可学技能数
        /// </summary>
        public const int MAXMAGIC = 30;
        /// <summary>
        /// 最高可升级等级
        /// </summary>
        public const int MAXUPLEVEL = ushort.MaxValue;
        public const int MAXHUMPOWER = ushort.MaxValue;
        public const double BODYLUCKUNIT = 5.0E3;
        public const int HAM_ALL = 0;// [攻击模式: 全体攻击]
        public const int HAM_PEACE = 1;// [攻击模式: 和平攻击]
        public const int HAM_DEAR = 2;// [攻击模式: 夫妻攻击]
        public const int HAM_MASTER = 3;// [攻击模式: 师徒攻击]
        public const int HAM_GROUP = 4;// [攻击模式: 编组攻击]
        public const int HAM_GUILD = 5;// [攻击模式: 行会攻击]
        public const int HAM_PKATTACK = 6;// [攻击模式: 红名攻击]
        public const int DEFHIT = 5;
        public const int DEFSPEED = 15;
        public const int WARR = 0;
        public const int WIZARD = 1;
        public const int TAOS = 2;
        
        public const string sNpc_def = "Npc_def\\";
        public const string sMarket_Def = "Market_Def\\";
        public const string U_DRESSNAME = "衣服";
        public const string U_WEAPONNAME = "武器";
        public const string U_RIGHTHANDNAME = "照明物";
        public const string U_NECKLACENAME = "项链";
        public const string U_HELMETNAME = "头盔";
        public const string U_ARMRINGLNAME = "左手镯";
        public const string U_ARMRINGRNAME = "右手镯";
        public const string U_RINGLNAME = "左戒指";
        public const string U_RINGRNAME = "右戒指";
        public const string U_ZHULINAME = "斗笠";// 斗笠
        public const string U_BUJUKNAME = "物品";
        public const string U_BELTNAME = "腰带";
        public const string U_BOOTSNAME = "鞋子";
        public const string U_CHARMNAME = "宝石";
        public const string StrStorm = "您的%s出现暴击, 造成了额外的伤害";

        public static int GetPageCount(int ItemCount)
        {
            int result = 0;
            if (ItemCount > 7)
            {
                result = ItemCount / 7;
                if ((ItemCount % 7) > 0)
                {
                    result++;
                }
                result -= 1;
            }
            return result;
        }

        public static TStringList GetPlayObjectOrderList(int nType)
        {
            TStringList result;
            //EnterCriticalSection(HumanSortCriticalSection);
            try
            {
                result = null;
                switch (nType)
                {
                    case 0:
                        result = UserEngine.m_PlayObjectLevelList;
                        break;
                    case 1:
                        // 人物等级排名
                        result = UserEngine.m_WarrorObjectLevelList;
                        break;
                    case 2:
                        result = UserEngine.m_WizardObjectLevelList;
                        break;
                    case 3:
                        result = UserEngine.m_TaoistObjectLevelList;
                        break;
                    case 4:
                        result = UserEngine.m_PlayObjectMasterList;
                        break;
                }
            }
            finally
            {
                // LeaveCriticalSection(HumanSortCriticalSection);
            }
            return result;
        }

        public static string GetStartTime(uint nTime)
        {
            string result;
            uint h;
            uint s;
            uint m;
            uint s1;
            if (nTime >= 3600)
            {
                h = nTime / 3600;
                s = nTime % 3600;// 剩余秒
                m = s / 60;
                s1 = s % 60;
                result = string.Format("{0}小时{1}分钟{2}秒", h, m, s1);
            }
            else
            {
                if (nTime >= 60)
                {
                    m = nTime / 60;
                    s = nTime % 60;
                    result = string.Format("{0}分钟{1}秒", m, s);
                }
                else
                {
                    result = string.Format("{0}秒", nTime);
                }
            }
            return result;
        }

        public unsafe static void CopyStdItemToOStdItem(TStdItem* StdItem, TOStdItem* OStdItem)
        {
            HUtil32.StrToSByteArry(StdItem->ToString(), OStdItem->Name, 14, ref OStdItem->NameLen);
            OStdItem->StdMode = StdItem->StdMode;
            OStdItem->Shape = StdItem->Shape;
            OStdItem->Weight = StdItem->Weight;
            OStdItem->AniCount = StdItem->AniCount;
            OStdItem->Source = StdItem->Source;
            OStdItem->Reserved = StdItem->Reserved;
            OStdItem->NeedIdentify = StdItem->NeedIdentify;
            OStdItem->Looks = StdItem->Looks;
            OStdItem->DuraMax = (ushort)StdItem->DuraMax;
            OStdItem->AC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->AC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->AC)));
            OStdItem->MAC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->MAC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->MAC)));
            OStdItem->DC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->DC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->DC)));
            OStdItem->MC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->MC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->MC)));
            OStdItem->SC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->SC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->SC)));
            OStdItem->Need = (byte)StdItem->Need;
            OStdItem->NeedLevel = (byte)StdItem->NeedLevel;
            OStdItem->Price = StdItem->Price;
        }

        /// <summary>
        /// 读取公告内容
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static bool LoadLineNotice(string FileName)
        {
            bool result = false;
            int I;
            string sText;
            if (File.Exists(FileName))
            {
                LineNoticeList.LoadFromFile(FileName);
                I = 0;
                while (true)
                {
                    if (LineNoticeList.Count <= I)
                    {
                        break;
                    }
                    sText = LineNoticeList[I].Trim();
                    if (sText == "")
                    {
                        LineNoticeList.RemoveAt(I);
                        continue;
                    }
                    LineNoticeList[I] = sText;
                    I++;
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 加载自定义命令
        /// </summary>
        public static void LoadUserCmdList()
        {
            string sFileName;
            TStringList LoadList;
            string sLineText = string.Empty;
            string sUserCmd = string.Empty;
            string sCmdNo = string.Empty;
            int nCmdNo = 0;
            sFileName = ".\\UserCmd.txt";
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件配置文件");
                LoadList.Add(";命令名称\09对应编号");
                LoadList.SaveToFile(sFileName);
                return;
            }
            g_UserCmdList.Clear();
            LoadList = new TStringList();
            LoadList.LoadFromFile(sFileName);
            for (int I = 0; I < LoadList.Count; I++)
            {
                sLineText = LoadList[I];
                if ((sLineText != "") && (sLineText[0] != ';'))
                {
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sUserCmd, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCmdNo, new string[] { " ", "\09" });
                    nCmdNo = HUtil32.Str_ToInt(sCmdNo, -1);
                    if ((sUserCmd != "") && (nCmdNo >= 0))
                    {
                        // g_UserCmdList.Add(sUserCmd, ((nCmdNo) as Object));
                    }
                }
            }
        }

        /// <summary>
        /// 加载禁止物品规则
        /// </summary>
        public static void LoadCheckItemList()
        {
            string sFileName;
            TStringList LoadList;
            string sLineText;
            string sItemName = string.Empty;// 物品名称
            string sCanDrop = string.Empty;// 能否丢弃
            string sCanDeal = string.Empty;// 能否交易
            string sCanStorage = string.Empty;// 能否存仓
            string sCanRepair = string.Empty;// 能否修理
            string sCanDropHint = string.Empty;// 是否掉落提示
            string sCanOpenBoxsHint = string.Empty;// 是否开宝箱提示
            string sCanNoDropItem = string.Empty;// 是否永不暴出
            string sCanButchHint = string.Empty;// 是否挖取提示
            string sCanHeroUse = string.Empty;// 是否禁止英雄使用
            string sCanPickUpItem = string.Empty;// 禁止捡起(除GM外)
            string sCanDieDropItems = string.Empty;// 死亡掉落
            TCheckItem CheckItem;
            sFileName = ".\\CheckItemList.txt";
            if (g_CheckItemList.Count > 0)// 禁止物品规则
            {
                for (int I = 0; I < g_CheckItemList.Count; I++)
                {
                    if (g_CheckItemList[I] != null)
                    {
                        Dispose(g_CheckItemList[I]);
                    }
                }
            }
            g_CheckItemList.Clear();
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件禁止物品配置文件");
                LoadList.Add(";物品名称\09丢弃\09交易\09存仓\09修理\09掉落提示\09开宝箱提示\09永不暴出\09挖取提示");
                LoadList.SaveToFile(sFileName);
                return;
            }
            LoadList = new TStringList();
            LoadList.LoadFromFile(sFileName);
            for (int I = 0; I < LoadList.Count; I++)
            {
                sLineText = LoadList[I];
                if ((sLineText != "") && (sLineText[0] != ';'))
                {
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDrop, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDeal, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanStorage, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanRepair, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDropHint, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanOpenBoxsHint, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanNoDropItem, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanButchHint, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanHeroUse, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanPickUpItem, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDieDropItems, new string[] { " ", "\09" });
                    if ((sItemName != ""))
                    {
                        CheckItem = new TCheckItem();
                        CheckItem.szItemName = sItemName;
                        CheckItem.boCanDrop = sCanDrop != "0";
                        CheckItem.boCanDeal = sCanDeal != "0";
                        CheckItem.boCanStorage = sCanStorage != "0";
                        CheckItem.boCanRepair = sCanRepair != "0";
                        CheckItem.boCanDropHint = sCanDropHint != "0";
                        CheckItem.boCanOpenBoxsHint = sCanOpenBoxsHint != "0";
                        CheckItem.boCanNoDropItem = sCanNoDropItem != "0";
                        CheckItem.boCanButchHint = sCanButchHint != "0";
                        CheckItem.boCanHeroUse = sCanHeroUse != "0";
                        CheckItem.boPickUpItem = sCanPickUpItem != "0";
                        CheckItem.boDieDropItems = sCanDieDropItems != "0";// 死亡掉落
                        g_CheckItemList.Add(CheckItem);
                    }
                }
            }
        }

        /// <summary>
        /// 加载消息过滤
        /// </summary>
        public static void LoadMsgFilterList()
        {
            string sFileName = string.Empty;
            TStringList LoadList;
            string sLineText = string.Empty;
            string sFilterMsg = string.Empty;
            string sNewMsg = string.Empty;
            TFilterMsg FilterMsg;
            sFileName = ".\\MsgFilterList.txt";
            if (g_MsgFilterList.Count > 0)
            {
                for (int I = 0; I < g_MsgFilterList.Count; I++)
                {
                    if (g_MsgFilterList[I] != null)
                    {
                        Dispose(g_MsgFilterList[I]);
                    }
                }
            }
            g_MsgFilterList.Clear();
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件消息过滤配置文件");
                LoadList.Add(";过滤消息\09替换消息");
                LoadList.SaveToFile(sFileName);
                return;
            }
            LoadList = new TStringList();
            try
            {
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sFilterMsg, new string[] { " ", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sNewMsg, new string[] { " ", "\09" });
                        if ((sFilterMsg != ""))
                        {
                            FilterMsg = new TFilterMsg();
                            FilterMsg.sFilterMsg = sFilterMsg;
                            FilterMsg.sNewMsg = sNewMsg;
                            g_MsgFilterList.Add(FilterMsg);
                        }
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// 检查文字是否在消息过滤列表里面
        /// </summary>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public static bool IsFilterMsg(ref string sMsg)
        {
            bool result = false;
            TFilterMsg FilterMsg;
            if (g_MsgFilterList == null)
            {
                result = true;
                return result;
            }
            if (g_MsgFilterList.Count > 0)
            {
                for (int I = 0; I < g_MsgFilterList.Count; I++)
                {
                    FilterMsg = g_MsgFilterList[I];
                    if ((FilterMsg.sFilterMsg != "") && ((sMsg.IndexOf(FilterMsg.sFilterMsg) != -1)))
                    {
                        if (FilterMsg.sNewMsg == "")
                        {
                            sMsg = "";
                        }
                        else
                        {
                            sMsg = sMsg.Replace(FilterMsg.sFilterMsg, FilterMsg.sNewMsg);
                        }
                        result = true;
                        break;
                    }
                }
            }
            result = true;
            return result;
        }

        /// <summary>
        /// 加载商铺配置
        /// 商品分类  商品名称  出售价格  图片开始  图片结束  简单介绍  商品描述
        /// </summary>
        public unsafe static void LoadShopItemList()
        {
            int nPrice;
            int nCount;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sItemName = string.Empty;
            string sPrice = string.Empty;
            string sIntroduce = string.Empty;
            string sIdx = string.Empty;
            string sImgBegin = string.Empty;
            string sImgend = string.Empty;
            string sIntroduce1 = string.Empty;
            string sCount = string.Empty;
            TStringList LoadList;
            TStdItem* StdItem;
            TShopInfo ShopInfo;
            sFileName = ".\\BuyItemList.txt";
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件商铺配置文件");
                LoadList.Add(";商品分类\09商品名称\09出售价格\09图片开始\09图片结束\09简单介绍\09商品描述");
                LoadList.SaveToFile(sFileName);
                return;
            }
            if (g_ShopItemList.Count > 0)
            {
                for (int I = 0; I < g_ShopItemList.Count; I++)
                {
                    if (g_ShopItemList[I] != null)
                    {
                        Dispose(g_ShopItemList[I]);
                    }
                }
            }
            g_ShopItemList.Clear();
            LoadList = new TStringList();
            try
            {
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sIdx, new string[] { " ", "\t" });// 商品分类
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "\t" });// 商品名称
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sPrice, new string[] { " ", "\t" });// 出售价格
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sImgBegin, new string[] { " ", "\t" });// 图片开始
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sImgend, new string[] { " ", "\t" });// 图片结束
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sIntroduce1, new string[] { " ", "\t" });// 简单介绍
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sIntroduce, new string[] { " ", "\t" });// 商品描述
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sCount, new string[] { " ", "\t" });// 数量
                        nPrice = HUtil32.Str_ToInt(sPrice, -1);
                        nCount = HUtil32.Str_ToInt(sCount, 1);
                        if ((sItemName != "") && (nPrice >= 0) && (sIntroduce != "") && (sIdx != ""))
                        {
                            StdItem = UserEngine.GetStdItem(sItemName);
                            if (StdItem != null)
                            {
                                ShopInfo = new TShopInfo();
                                ShopInfo.Idx = Convert.ToInt32(sIdx);
                                //ShopInfo->ImgBegin = Convert.ToInt32(sImgBegin);
                                //ShopInfo->Imgend = Convert.ToInt32(sImgend);
                                //ShopInfo->Introduce1 = Convert.ToInt32(sIntroduce1);
                                //ShopInfo->StdItem = StdItem;
                                //ShopInfo->StdItem.Price = nPrice * 100;// 价格
                                //ShopInfo->StdItem.NeedLevel = nCount;// 数量
                                //FillChar(ShopInfo.sIntroduce, sizeof(ShopInfo.sIntroduce), 0);
                                //Move(sIntroduce[0], ShopInfo.sIntroduce, sIntroduce.Length);
                                //g_ShopItemList.Add((IntPtr)ShopInfo);
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }

        public static bool GetMultiServerAddrPort(int btServerIndex, ref string sIPaddr, ref int nPort)
        {
            bool result;
            result = false;
            // ServerTableList
            return result;
        }

        /// <summary>
        /// 添加游戏日志到控制台输出队列(错误信息)
        /// </summary>
        /// <param name="Msg"></param>
        public static void MainOutMessage(string Msg)
        {
            if (!g_Config.boShowExceptionMsg)
            {
                if ((Msg.Length > 2) && ((Msg[0] == '{') || (Msg[0] == 'A')))
                {
                    return;
                }
            }
            HUtil32.EnterCriticalSection(LogMsgCriticalSection);
            try
            {
                MainLogMsgList.Enqueue(Msg);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
            }
        }

        /// <summary>
        /// 添加游戏日志到控制台输出队列(日志信息)
        /// </summary>
        /// <param name="Msg"></param>
        public static void OutInfoMessage(string Msg)
        {
            if (!g_Config.boShowExceptionMsg)
            {
                if ((Msg.Length > 2) && ((Msg[0] == '{') || (Msg[0] == 'A')))
                {
                    return;
                }
            }
            HUtil32.EnterCriticalSection(LogMsgCriticalSection);
            try
            {
                GameLogMsgList.Enqueue(string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Msg));
            }
            finally
            {
                HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
            }
        }

        /// <summary>
        /// 添加游戏日志到控制台输出队列(日常信息)
        /// </summary>
        /// <param name="Msg"></param>
        public static void OutErroeMessage(string Msg)
        {
            if (!g_Config.boShowExceptionMsg)
            {
                if ((Msg.Length > 2) && ((Msg[0] == '{') || (Msg[0] == 'A')))
                {
                    return;
                }
            }
            HUtil32.EnterCriticalSection(LogMsgCriticalSection);
            try
            {
                MainLogMsgList.Enqueue(Msg);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
            }
        }

        public static int GetExVersionNO(int nVersionDate, ref int nOldVerstionDate)
        {
            int result;
            result = 0;
            nOldVerstionDate = 0;
            if (nVersionDate > 900000000)
            {
                while ((nVersionDate > 900000000))
                {
                    nVersionDate -= 900000000;
                    result += 900000000;
                }
            }
            nOldVerstionDate = nVersionDate;
            return result;
        }

        public static byte GetNextDirection(int sX, int sY, int dx, int dy)
        {
            byte result;
            int flagx;
            int flagy;
            result = Grobal2.DR_DOWN;
            if (sX < dx)
            {
                flagx = 1;
            }
            else if (sX == dx)
            {
                flagx = 0;
            }
            else
            {
                flagx = -1;
            }
            if (Math.Abs(sY - dy) > 2)
            {
                if ((sX >= dx - 1) && (sX <= dx + 1))
                {
                    flagx = 0;
                }
            }
            if (sY < dy)
            {
                flagy = 1;
            }
            else if (sY == dy)
            {
                flagy = 0;
            }
            else
            {
                flagy = -1;
            }
            if (Math.Abs(sX - dx) > 2)
            {
                if ((sY > dy - 1) && (sY <= dy + 1))
                {
                    flagy = 0;
                }
            }
            if ((flagx == 0) && (flagy == -1))
            {
                result = Grobal2.DR_UP;
            }
            if ((flagx == 1) && (flagy == -1))
            {
                result = Grobal2.DR_UPRIGHT;
            }
            if ((flagx == 1) && (flagy == 0))
            {
                result = Grobal2.DR_RIGHT;
            }
            if ((flagx == 1) && (flagy == 1))
            {
                result = Grobal2.DR_DOWNRIGHT;
            }
            if ((flagx == 0) && (flagy == 1))
            {
                result = Grobal2.DR_DOWN;
            }
            if ((flagx == -1) && (flagy == 1))
            {
                result = Grobal2.DR_DOWNLEFT;
            }
            if ((flagx == -1) && (flagy == 0))
            {
                result = Grobal2.DR_LEFT;
            }
            if ((flagx == -1) && (flagy == -1))
            {
                result = Grobal2.DR_UPLEFT;
            }
            return result;
        }

        // 检查是否可以穿上装备
        public unsafe static bool CheckUserItems(int nIdx, TStdItem* StdItem)
        {
            bool result = false;
            switch (nIdx)
            {
                case TPosition.U_DRESS:
                    if ((StdItem->StdMode == 10) || (StdItem->StdMode == 11))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_WEAPON:
                    if ((StdItem->StdMode == 5) || (StdItem->StdMode == 6))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_RIGHTHAND:
                    if ((StdItem->StdMode == 29) || (StdItem->StdMode == 30) || (StdItem->StdMode == 28))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_NECKLACE:
                    if ((StdItem->StdMode == 19) || (StdItem->StdMode == 20) || (StdItem->StdMode == 21))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_HELMET:
                    if (StdItem->StdMode == 15)
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_ZHULI:// 斗笠
                    if (StdItem->StdMode == 16)
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_ARMRINGL:
                    if ((StdItem->StdMode == 24) || (StdItem->StdMode == 25) || (StdItem->StdMode == 26))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_ARMRINGR:
                    if ((StdItem->StdMode == 24) || (StdItem->StdMode == 26))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_RINGL:
                case TPosition.U_RINGR:
                    if ((StdItem->StdMode == 22) || (StdItem->StdMode == 23))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_BUJUK:
                    if ((StdItem->StdMode == 25) || ((StdItem->StdMode == 2) && (StdItem->AniCount == 21)))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_BELT:
                    if ((StdItem->StdMode == 54) || (StdItem->StdMode == 64))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_BOOTS:
                    if ((StdItem->StdMode == 52) || (StdItem->StdMode == 62))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_CHARM:
                    if ((StdItem->StdMode == 53) || (StdItem->StdMode == 63) || (StdItem->StdMode == 7))
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }

        public static DateTime AddDateTimeOfDay(DateTime DateTime, int nDay)
        {
            DateTime result;
            int Year;
            int Month;
            int Day;
            if (nDay > 0)
            {
                nDay -= 1;
                Year = DateTime.Year;
                Month = DateTime.Month;
                Day = DateTime.Day;
                while (true)
                {
                    //if (MonthDays[false][Month] >= (Day + nDay))
                    //{
                    //    break;
                    //}
                    //nDay = (Day + nDay) - MonthDays[false][Month] - 1;
                    Day = 1;
                    if (Month <= 11)
                    {
                        Month++;
                        continue;
                    }
                    Month = 1;
                    if (Year == 99)
                    {
                        Year = 2000;
                        continue;
                    }
                    Year++;
                }
                // while
                // TryEncodeDate(Year,Month,Day,Result);
                Day += nDay;
                result = new DateTime(Year, Month, Day);
            }
            else
            {
                result = DateTime;
            }
            return result;
        }

        /// <summary>
        /// 金币在地上显示的外形ID
        /// </summary>
        /// <param name="nGold"></param>
        /// <returns></returns>
        public static ushort GetGoldShape(long nGold)
        {
            ushort result = 112;
            if (nGold >= 30)
            {
                result = 113;
            }
            if (nGold >= 70)
            {
                result = 114;
            }
            if (nGold >= 300)
            {
                result = 115;
            }
            if (nGold >= 1000)
            {
                result = 116;
            }
            return result;
        }

        public static ushort GetRandomLook(int nBaseLook, int nRage)
        {
            return Convert.ToUInt16(nBaseLook + HUtil32.Random(nRage));
        }

        /// <summary>
        /// 检查行会名称
        /// </summary>
        /// <param name="sGuildName"></param>
        /// <returns></returns>
        public static bool CheckGuildName(string sGuildName)
        {
            bool result = true;
            if (sGuildName.Length > g_Config.nGuildNameLen)
            {
                result = false;
                return result;
            }
            for (int I = 1; I <= sGuildName.Length; I++)
            {
                if ((sGuildName[I] < '0') || (sGuildName[I] == '/') || (sGuildName[I] == '\\') || (sGuildName[I] == ':') || (sGuildName[I] == '*') || (sGuildName[I] == ' ') ||
                    (sGuildName[I] == '\'') || (sGuildName[I] == '\'') || (sGuildName[I] == '<') || (sGuildName[I] == '|') || (sGuildName[I] == '?') || (sGuildName[I] == '>'))
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 取物品制造ID
        /// </summary>
        /// <returns></returns>
        public static int GetItemNumber()
        {
            int result;
            g_Config.nItemNumber++;
            if (g_Config.nItemNumber > (Int32.MaxValue / 2 - 1))
            {
                g_Config.nItemNumber = 1;
            }
            result = g_Config.nItemNumber;
            return result;
        }

        public static int GetItemNumberEx()
        {
            int result;
            g_Config.nItemNumberEx++;
            if (g_Config.nItemNumberEx < Int32.MaxValue / 2)
            {
                g_Config.nItemNumberEx = Int32.MaxValue / 2;
            }
            if (g_Config.nItemNumberEx > (Int32.MaxValue - 1))
            {
                g_Config.nItemNumberEx = Int32.MaxValue / 2;
            }
            result = g_Config.nItemNumberEx;
            return result;
        }

        /// <summary>
        /// 过滤客户端显示的名字,去除数字及-符号
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public static string FilterShowName(string sName)
        {
            string result = string.Empty;
            string SC = string.Empty;
            bool bo11 = false;
            if (sName == null)
            {
                return null;
            }
            for (int I = 0; I <= sName.Length - 1; I++)
            {
                if (((sName[I] >= '0') && (sName[I] <= '9')) || (sName[I] == '-'))
                {
                    result = sName.Substring(0, I);
                    SC = sName.Substring(I + 1, sName.Length - I - 1);
                    bo11 = true;
                    break;
                }
            }
            if (!bo11)
            {
                result = sName;
            }
            return result;
        }

        public static byte sub_4B2F80(int nDir, int nRage)
        {
            return Convert.ToByte((nDir + nRage) % 8);
        }

        /// <summary>
        /// 取服务器全局变量
        /// </summary>
        /// <param name="sText"></param>
        /// <returns></returns>
        public static int GetValNameNo(string sText)
        {
            int result = -1;
            int nValNo;
            string sNo;
            if (sText == null || sText.Length > 4)
            {
                return result;
            }
            if (sText.Length >= 2)
            {
                sNo = sText.Substring(2 - 1, sText.Length - 1);
                if (HUtil32.IsStringNumber(sNo))
                {
                    if (Char.ToUpper(sText[0]) == 'P')  // 0..99
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);//  扩展为0-99
                            if (nValNo < 100)
                            {
                                result = nValNo;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'G')// OK 100..199 800..1199
                    {
                        if (sText.Length == 4)// 扩展为0-499
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 4 - 1), -1);
                            if ((nValNo < 500) && (nValNo > 99))
                            {
                                result = nValNo + 700;
                            }
                        }
                        else
                        {
                            if (sText.Length == 3)
                            {
                                nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                                if (nValNo < 100)
                                {
                                    result = nValNo + 100;
                                }
                            }
                            else
                            {
                                nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                                if (nValNo < 10)
                                {
                                    result = nValNo + 100;
                                }
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'M')// 300..399
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 300;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 300;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'I')
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, sText.Length - (2 - 1)), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 400;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 400;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'D')  // 200..299
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);  // 20080125  扩展为0-99
                            if (nValNo < 100)
                            {
                                result = nValNo + 200;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 200;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'N') // 500..599
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 500;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 500;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'S') // 600..699
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 600;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 600;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'A')  // 700..799 1200..1599
                    {
                        if (sText.Length == 4)  // 扩展为0-999
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 4 - 1), -1);
                            if ((nValNo < 500) && (nValNo > 99))
                            {
                                result = nValNo + 1100;
                            }
                        }
                        else
                        {
                            if (sText.Length == 3)
                            {
                                nValNo = HUtil32.Str_ToInt(sText.Substring(1, sText.Length - (2 - 1)), -1);
                                if (nValNo < 100)
                                {
                                    result = nValNo + 700;
                                }
                            }
                            else
                            {
                                nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                                if (nValNo < 10)
                                {
                                    result = nValNo + 700;
                                }
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'T') // 新增加变量,0-999
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 3), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 700;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 700;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 是可以使用的物品
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public unsafe static bool IsUseItem(int nIndex)
        {
            bool result;
            TStdItem* StdItem = UserEngine.GetStdItem(nIndex);
            if (new ArrayList(new int[] { 19, 20, 21, 22, 23, 24, 26 }).Contains(StdItem->StdMode))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static TStringList GetMakeItemInfo(string sItemName)
        {
            TStringList result = null;
            if (g_MakeItemList.Count > 0)
            {
                for (int I = 0; I < g_MakeItemList.Count; I++)
                {
                    //if (g_MakeItemList[I] == sItemName)
                    //{
                    //    result = ((g_MakeItemList[I]) as TStringList);
                    //    break;
                    //}
                }
            }
            return result;
        }

        public bool GetRefineItemInfo_InStr(string Str, string sItemName, string sItemName1, string sItemName2)
        {
            bool result;
            result = false;
            //if (Str.Length == sItemName + "+" + sItemName1 + "+" + sItemName2.Length)
            //{
            //    if (Str.IndexOf(sItemName) > 0)
            //    {
            //        Str = Str.Substring(0 - 1, Str.IndexOf(sItemName)) + Str.Substring(Str.IndexOf(sItemName) + sItemName.Length - 1, Str.Length);
            //        if (Str.IndexOf(sItemName1) > 0)
            //        {
            //            Str = Str.Substring(0 - 1, Str.IndexOf(sItemName1)) + Str.Substring(Str.IndexOf(sItemName1) + sItemName1.Length - 1, Str.Length);
            //            if (Str.IndexOf(sItemName2) > 0)
            //            {
            //                result = true;
            //            }
            //        }
            //    }
            //}
            return result;
        }

        // 取淬炼后的物品列表
        public static ArrayList GetRefineItemInfo(string sItemName, string sItemName1, string sItemName2)
        {
            ArrayList result;
            int I;
            string Str;
            result = null;
            if (g_RefineItemList.Count > 0)
            {
                for (I = 0; I < g_RefineItemList.Count; I++)
                {
                    Str = g_RefineItemList[I].sItemName;
                    //if (GetRefineItemInfo_InStr(Str, sItemName, sItemName1, sItemName2))
                    //{
                    //    result = ((g_RefineItemList[I]) as ArrayList);
                    //    break;
                    //}
                }
            }
            return result;
        }

        // 增加游戏日志
        public static void AddGameDataLog(string sMsg)
        {
            try
            {
                HUtil32.EnterCriticalSection(LogMsgCriticalSection);
                try
                {
                    //LogStringList.Add(sMsg);
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
                }
            }
            catch
            {
                MainOutMessage("{异常} AddGameDataLog");
            }
        }

        public static void AddLogonCostLog(string sMsg)
        {
            HUtil32.EnterCriticalSection(LogMsgCriticalSection);
            try
            {
                //LogonCostLogList.Add(sMsg);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
            }
        }

        public static void TrimStringList(TStringList sList)
        {
            int n8;
            string SC;
            n8 = 0;
            while (true)
            {
                if ((sList.Count) <= n8)
                {
                    break;
                }
                SC = sList[n8].Trim();
                if (SC == "")
                {
                    sList.RemoveAt(n8);
                    continue;
                }
                n8++;
            }
        }

        // 是否能制造物品
        public static bool CanMakeItem(string sItemName)
        {
            bool result;
            int I;
            result = false;
            //g_DisableMakeItemList.__Lock();
            //try
            //{
            //    if (g_DisableMakeItemList.Count > 0)
            //    {
            //        for (I = 0; I < g_DisableMakeItemList.Count; I++)
            //        {
            //            if ((g_DisableMakeItemList[I]).ToLower().CompareTo((sItemName).ToLower()) == 0)
            //            {
            //                result = false;
            //                return result;
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    g_DisableMakeItemList.UnLock();
            //}
            //g_EnableMakeItemList.__Lock();
            //try
            //{
            //    if (g_EnableMakeItemList.Count > 0)
            //    {
            //        for (I = 0; I < g_EnableMakeItemList.Count; I++)
            //        {
            //            if ((g_EnableMakeItemList[I]).ToLower().CompareTo((sItemName).ToLower()) == 0)
            //            {
            //                result = true;
            //                break;
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    g_EnableMakeItemList.UnLock();
            //}
            return result;
        }

        /// <summary>
        /// 获取安全区配置信息
        /// </summary>
        /// <param name="nIndex"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public static string GetStartPointInfo(int nIndex, ref int nX, ref int nY)
        {
            string result = "";
            TStartPoint StartPoint;
            nX = 0;
            nY = 0;
            if ((nIndex >= 0) && (nIndex < g_StartPointList.Count))
            {
                StartPoint = g_StartPointList[nIndex];
                if (StartPoint != null)
                {
                    nX = StartPoint.m_nCurrX;
                    nY = StartPoint.m_nCurrY;
                    result = StartPoint.m_sMapName;
                }
            }
            return result;
        }

        /// <summary>
        /// 是否可以移动的地图
        /// </summary>
        /// <param name="sMapName"></param>
        /// <returns></returns>
        public static bool CanMoveMap(string sMapName)
        {
            bool result;
            int I;
            result = true;
            //g_DisableMoveMapList.__Lock();
            //try
            //{
            //    if (g_DisableMoveMapList.Count > 0)
            //    {
            //        for (I = 0; I < g_DisableMoveMapList.Count; I++)
            //        {
            //            if ((g_DisableMoveMapList[I]).ToLower().CompareTo((sMapName).ToLower()) == 0)
            //            {
            //                result = false;
            //                break;
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    g_DisableMoveMapList.UnLock();
            //}
            return result;
        }

        public static bool LoadItemBindIPaddr()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            string sMakeIndex;
            string sItemIndex;
            string sBindName;
            int nMakeIndex;
            int nItemIndex;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindIPaddr.txt";
            LoadList = new TStringList();
            //if (File.Exists(sFileName))
            //{
            //    g_ItemBindIPaddr.__Lock();
            //    try
            //    {
            //        if (g_ItemBindIPaddr.Count > 0)
            //        {
            //            for (I = 0; I < g_ItemBindIPaddr.Count; I++)
            //            {
            //                if (((g_ItemBindIPaddr[I]) as TItemBind) != null)
            //                {
            //                    Dispose(((g_ItemBindIPaddr[I]) as TItemBind));
            //                }
            //            }
            //            g_ItemBindIPaddr.Clear();
            //        }
            //        LoadList.LoadFromFile(sFileName);
            //        if (LoadList.Count > 0)
            //        {
            //            for (I = 0; I < LoadList.Count; I++)
            //            {
            //                sLineText = LoadList[I].Trim();
            //                if (sLineText[0] == ";")
            //                {
            //                    continue;
            //                }
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
            //                nMakeIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sMakeIndex, -1);
            //                nItemIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sItemIndex, -1);
            //                if ((nMakeIndex > 0) && (nItemIndex > 0) && (sBindName != ""))
            //                {
            //                    ItemBind = new TItemBind();
            //                    ItemBind.nMakeIdex = nMakeIndex;
            //                    ItemBind.nItemIdx = nItemIndex;
            //                    ItemBind.sBindName = sBindName;
            //                    g_ItemBindIPaddr.Add(ItemBind);
            //                }
            //            }
            //            // for
            //        }
            //    }
            //    finally
            //    {
            //        g_ItemBindIPaddr.UnLock();
            //    }
            //    result = true;
            //}
            //else
            //{
            //    LoadList.SaveToFile(sFileName);
            //}
            return result;
        }

        public static bool SaveItemBindIPaddr()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindIPaddr.txt";
            SaveList = new TStringList();
            //g_ItemBindIPaddr.__Lock();
            //try
            //{
            //    if (g_ItemBindIPaddr.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemBindIPaddr.Count; I++)
            //        {
            //            //ItemBind = g_ItemBindIPaddr[I];
            //            SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + (ItemBind.nMakeIdex).ToString() + "\09" + ItemBind.sBindName);
            //        }
            //    }
            //}
            //finally
            //{
            //    g_ItemBindIPaddr.UnLock();
            //}
            SaveList.SaveToFile(sFileName);
            result = true;
            return result;
        }

        public static bool LoadItemBindAccount()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            string sMakeIndex;
            string sItemIndex;
            string sBindName;
            int nMakeIndex;
            int nItemIndex;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindAccount.txt";
            LoadList = new TStringList();
            //if (File.Exists(sFileName))
            //{
            //    g_ItemBindAccount.__Lock();
            //    try
            //    {
            //        if (g_ItemBindAccount.Count > 0)
            //        {
            //            for (I = 0; I < g_ItemBindAccount.Count; I++)
            //            {
            //                if (((g_ItemBindAccount[I]) as TItemBind) != null)
            //                {
            //                    Dispose(((g_ItemBindAccount[I]) as TItemBind));
            //                }
            //            }
            //            g_ItemBindAccount.Clear();
            //        }
            //        LoadList.LoadFromFile(sFileName);
            //        if (LoadList.Count > 0)
            //        {
            //            for (I = 0; I < LoadList.Count; I++)
            //            {
            //                sLineText = LoadList[I].Trim();
            //                if (sLineText[0] == ";")
            //                {
            //                    continue;
            //                }
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
            //                nMakeIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sMakeIndex, -1);
            //                nItemIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sItemIndex, -1);
            //                if ((nMakeIndex > 0) && (nItemIndex > 0) && (sBindName != ""))
            //                {
            //                    ItemBind = new TItemBind();
            //                    ItemBind.nMakeIdex = nMakeIndex;
            //                    ItemBind.nItemIdx = nItemIndex;
            //                    ItemBind.sBindName = sBindName;
            //                    g_ItemBindAccount.Add(ItemBind);
            //                }
            //            }
            //            // for
            //        }
            //    }
            //    finally
            //    {
            //        g_ItemBindAccount.UnLock();
            //    }
            //    result = true;
            //}
            //else
            //{
            //    LoadList.SaveToFile(sFileName);
            //}
            return result;
        }

        public static bool SaveItemBindAccount()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindAccount.txt";
            SaveList = new TStringList();
            //g_ItemBindAccount.__Lock();
            //try
            //{
            //    if (g_ItemBindAccount.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemBindAccount.Count; I++)
            //        {
            //            ItemBind = g_ItemBindAccount[I];
            //            SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + (ItemBind.nMakeIdex).ToString() + "\09" + ItemBind.sBindName);
            //        }
            //    }
            //}
            //finally
            //{
            //    g_ItemBindAccount.UnLock();
            //}
            SaveList.SaveToFile(sFileName);
            result = true;
            return result;
        }

        public static bool LoadItemDblClickList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            string sMakeIndex;
            string sItemName;
            string sMapName;
            string sX;
            string sY;
            int nMakeIndex;
            int nCurrX;
            int nCurrY;
            TItemEvent ItemEvent;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemDblClickList.txt";
            LoadList = new TStringList();
            //if (g_ItemDblClickList != null)
            //{
            //    if (g_ItemDblClickList.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemDblClickList.Count; I++)
            //        {
            //            if (((TItemEvent)(g_ItemDblClickList[I])) != null)
            //            {
            //                Dispose(((TItemEvent)(g_ItemDblClickList[I])));
            //            }
            //        }
            //    }
            //}
            //g_ItemDblClickList = new TGList();
            //if (File.Exists(sFileName))
            //{
            //    g_ItemDblClickList.__Lock();
            //    try
            //    {
            //        LoadList.LoadFromFile(sFileName);
            //        if (LoadList.Count > 0)
            //        {
            //            for (I = 0; I < LoadList.Count; I++)
            //            {
            //                sLineText = LoadList[I].Trim();
            //                if ((sLineText == "") || (sLineText[0] == ';'))
            //                {
            //                    continue;
            //                }
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMapName, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sX, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sY, new string[] { " ", ",", "\09" });
            //                nMakeIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sMakeIndex, -1);
            //                nCurrX = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sX, -1);
            //                nCurrY = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sY, -1);
            //                if ((nMakeIndex > 0) && (sMapName != "") && (nCurrX >= 0) && (nCurrY >= 0))
            //                {
            //                    ItemEvent = new TItemEvent();
            //                    ItemEvent.m_sItemName = sItemName;
            //                    ItemEvent.m_nMakeIndex = nMakeIndex;
            //                    ItemEvent.m_sMapName = sMapName;
            //                    ItemEvent.m_nCurrX = nCurrX;
            //                    ItemEvent.m_nCurrY = nCurrY;
            //                    g_ItemDblClickList.Add(ItemEvent);
            //                }
            //            }
            //            // for
            //        }
            //    }
            //    finally
            //    {
            //        g_ItemDblClickList.UnLock();
            //    }
            //    result = true;
            //}
            //else
            //{
            //    LoadList.SaveToFile(sFileName);
            //}
            return result;
        }

        // 加载物品事件触发列表
        public static bool SaveItemDblClickList()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemEvent ItemEvent;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemDblClickList.txt";
            SaveList = new TStringList();
            //g_ItemDblClickList.__Lock();
            //try
            //{
            //    if (g_ItemDblClickList.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemDblClickList.Count; I++)
            //        {
            //            ItemEvent = g_ItemDblClickList[I];
            //            SaveList.Add(ItemEvent.m_sItemName + "\09" + (ItemEvent.m_nMakeIndex).ToString() + "\09" + ItemEvent.m_sMapName + "\09" + (ItemEvent.m_nCurrX).ToString() + "\09" + (ItemEvent.m_nCurrY).ToString());
            //        }
            //    }
            //}
            //finally
            //{
            //    g_ItemBindCharName.UnLock();
            //}
            SaveList.SaveToFile(sFileName); ;
            result = true;
            return result;
        }

        public static bool LoadItemBindCharName()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText = string.Empty;
            string sMakeIndex = string.Empty;
            string sItemIndex = string.Empty;
            string sBindName = string.Empty;
            int nMakeIndex;
            int nItemIndex;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindChrName.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                //g_ItemBindCharName.__Lock();
                try
                {
                    if (g_ItemBindCharName.Count > 0)
                    {
                        for (I = 0; I < g_ItemBindCharName.Count; I++)
                        {
                            if (g_ItemBindCharName[I] != null)
                            {
                                Dispose(g_ItemBindCharName[I]);
                            }
                        }
                        g_ItemBindCharName.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I].Trim();
                            if (sLineText[0] == ';')
                            {
                                continue;
                            }
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
                            nMakeIndex = HUtil32.Str_ToInt(sMakeIndex, -1);
                            nItemIndex = HUtil32.Str_ToInt(sItemIndex, -1);
                            if ((nMakeIndex > 0) && (nItemIndex > 0) && (sBindName != ""))
                            {
                                ItemBind = new TItemBind();
                                ItemBind.nMakeIdex = nMakeIndex;
                                ItemBind.nItemIdx = nItemIndex;
                                ItemBind.sBindName = sBindName;
                                g_ItemBindCharName.Add(ItemBind);
                            }
                        }
                    }
                }
                finally
                {
                    //g_ItemBindCharName.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool SaveItemBindCharName()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindChrName.txt";
            SaveList = new TStringList();
            //g_ItemBindCharName.__Lock();
            try
            {
                if (g_ItemBindCharName.Count > 0)
                {
                    for (I = 0; I < g_ItemBindCharName.Count; I++)
                    {
                        ItemBind = g_ItemBindCharName[I];
                        SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + (ItemBind.nMakeIdex).ToString() + "\09" + ItemBind.sBindName);
                    }
                }
            }
            finally
            {
                // g_ItemBindCharName.UnLock();
            }
            SaveList.SaveToFile(sFileName);
            SaveList.Dispose();
            Dispose(SaveList);
            result = true;
            return result;
        }

        /// <summary>
        /// 读取人物装备死亡不爆列表
        /// </summary>
        /// <returns></returns>
        public static bool LoadItemBindDieNoDropName()
        {
            bool result = false;
            int nItemIndex;
            string sLineText = string.Empty;
            string sItemIndex = string.Empty;
            string sBindName = string.Empty;
            TItemBind ItemBind;
            TStringList LoadList = new TStringList();
            string sFileName = g_Config.sEnvirDir + "ItemBindDieNoDropName.txt";
            if (File.Exists(sFileName))
            {
                HUtil32.EnterCriticalSection(g_ItemBindDieNoDropName);
                try
                {
                    if (g_ItemBindDieNoDropName.Count > 0)
                    {
                        for (int I = 0; I < g_ItemBindDieNoDropName.Count; I++)
                        {
                            if (g_ItemBindDieNoDropName[I] != null)
                            {
                                Dispose(g_ItemBindDieNoDropName[I]);
                            }
                        }
                        g_ItemBindDieNoDropName.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (int I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I].Trim();
                            if (sLineText[0] == ';')
                            {
                                continue;
                            }
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
                            nItemIndex = HUtil32.Str_ToInt(sItemIndex, -1);
                            if ((nItemIndex > 0) && (sBindName != ""))
                            {
                                ItemBind = new TItemBind();
                                ItemBind.nMakeIdex = 0;
                                ItemBind.nItemIdx = nItemIndex;
                                ItemBind.sBindName = sBindName;
                                g_ItemBindDieNoDropName.Add(ItemBind);
                            }
                        }
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(g_ItemBindDieNoDropName);
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        // 保存人物装备死亡不爆列表
        public static bool SaveItemBindDieNoDropName()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind = null;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindDieNoDropName.txt";
            SaveList = new TStringList();
            //g_ItemBindDieNoDropName.__Lock();
            try
            {
                if (g_ItemBindDieNoDropName.Count > 0)
                {
                    for (I = 0; I < g_ItemBindDieNoDropName.Count; I++)
                    {
                        //ItemBind = g_ItemBindDieNoDropName[I];
                        SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + ItemBind.sBindName);
                    }
                }
            }
            finally
            {
                //  g_ItemBindDieNoDropName.UnLock();
            }
            SaveList.SaveToFile(sFileName);
            Dispose(SaveList);
            result = true;
            return result;
        }

        public static bool LoadDisableMakeItem()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableMakeItem.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                //g_DisableMakeItemList.__Lock();
                try
                {
                    if (g_DisableMakeItemList.Count > 0)
                    {
                        g_DisableMakeItemList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_DisableMakeItemList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                    // g_DisableMakeItemList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            //Dispose(LoadList);
            return result;
        }
        public static bool SaveDisableMakeItem()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "DisableMakeItem.txt";
            // g_DisableMakeItemList.__Lock();
            try
            {
                g_DisableMakeItemList.SaveToFile(sFileName);
            }
            finally
            {
                //  g_DisableMakeItemList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool SaveAdminList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            string sPermission = string.Empty;
            int nPermission;
            TAdminInfo AdminInfo;
            sFileName = g_Config.sEnvirDir + "AdminList.txt";
            SaveList = new TStringList();
            //UserEngine.m_AdminList.__Lock();
            try
            {
                if (UserEngine.m_AdminList.Count > 0)
                {
                    for (I = 0; I < UserEngine.m_AdminList.Count; I++)
                    {
                        AdminInfo = UserEngine.m_AdminList[I];
                        nPermission = AdminInfo.nLv;
                        if (nPermission == 10)
                        {
                            sPermission = "*";
                        }
                        if (nPermission == 9)
                        {
                            sPermission = "1";
                        }
                        if (nPermission == 8)
                        {
                            sPermission = "2";
                        }
                        if (nPermission == 7)
                        {
                            sPermission = "3";
                        }
                        if (nPermission == 6)
                        {
                            sPermission = "4";
                        }
                        if (nPermission == 5)
                        {
                            sPermission = "5";
                        }
                        if (nPermission == 4)
                        {
                            sPermission = "6";
                        }
                        if (nPermission == 3)
                        {
                            sPermission = "7";
                        }
                        if (nPermission == 2)
                        {
                            sPermission = "8";
                        }
                        if (nPermission == 1)
                        {
                            sPermission = "9";
                        }
                        SaveList.Add(sPermission + "\09" + AdminInfo.sChrName + "\09" + AdminInfo.sIPaddr);
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                //UserEngine.m_AdminList.UnLock();
            }
            SaveList.Dispose();
            Dispose(SaveList);
            result = true;
            return result;
        }

        public static bool LoadUnMasterList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "UnMaster.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                // g_UnMasterList.__Lock();
                try
                {
                    if (g_UnMasterList.Count > 0)
                    {
                        g_UnMasterList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            // g_UnMasterList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                    // g_UnMasterList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            LoadList.Dispose();
            Dispose(LoadList);
            //Dispose(LoadList);
            return result;
        }

        public static bool SaveUnMasterList()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "UnMaster.txt";
            // g_UnMasterList.__Lock();
            try
            {
                g_UnMasterList.SaveToFile(sFileName);
            }
            finally
            {
                // g_UnMasterList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadUnForceMasterList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "UnForceMaster.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                //g_UnForceMasterList.__Lock();
                try
                {
                    if (g_UnForceMasterList.Count > 0)
                    {
                        g_UnForceMasterList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_UnForceMasterList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                    // g_UnForceMasterList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            // Dispose(LoadList);
            return result;
        }

        public static bool SaveUnForceMasterList()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "UnForceMaster.txt";
            //g_UnForceMasterList.__Lock();
            try
            {
                g_UnForceMasterList.SaveToFile(sFileName);
            }
            finally
            {
                //  g_UnForceMasterList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadEnableMakeItem()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "EnableMakeItem.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_EnableMakeItemList.__Lock();
                try
                {
                    if (g_EnableMakeItemList.Count > 0)
                    {
                        g_EnableMakeItemList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_EnableMakeItemList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                    g_EnableMakeItemList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public bool SaveEnableMakeItem()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "EnableMakeItem.txt";
            // g_EnableMakeItemList.__Lock();
            try
            {
                g_EnableMakeItemList.SaveToFile(sFileName);
            }
            finally
            {
                // g_EnableMakeItemList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadDisableMoveMap()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableMoveMap.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                // g_DisableMoveMapList.__Lock();
                try
                {
                    if (g_DisableMoveMapList.Count > 0)
                    {
                        g_DisableMoveMapList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_DisableMoveMapList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                    // g_DisableMoveMapList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            //Dispose(LoadList);
            return result;
        }

        public static bool SaveDisableMoveMap()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "DisableMoveMap.txt";
            // g_DisableMoveMapList.__Lock();
            try
            {
                g_DisableMoveMapList.SaveToFile(sFileName);
            }
            finally
            {
                //g_DisableMoveMapList.UnLock();
            }
            result = true;
            return result;
        }

        public unsafe bool LoadBindItemTypeFromUnbindList_AddBindItemType(string sItemName, int nShape)
        {
            bool result;
            TBindItem BindItem;
            int I;
            TStdItem* StdItem;
            result = false;
            if (UserEngine.StdItemList.Count > 0)
            {
                for (I = 0; I < UserEngine.StdItemList.Count; I++)
                {
                    StdItem = (TStdItem*)UserEngine.StdItemList[I];
                    if ((StdItem->ToString()).ToLower().CompareTo((sItemName).ToLower()) == 0)
                    {
                        if (StdItem->StdMode == 0)
                        {
                            if ((StdItem->Shape == 0) && (StdItem->AC > 0) && (StdItem->MAC == 0))
                            {
                                // 红药
                                BindItem = new TBindItem();
                                BindItem.sUnbindItemName = StdItem->ToString();
                                BindItem.nStdMode = 31;
                                BindItem.nShape = nShape;
                                BindItem.btItemType = 0;
                                g_BindItemTypeList.Add(BindItem);
                                result = true;
                                break;
                            }
                            else if ((StdItem->Shape == 0) && (StdItem->AC == 0) && (StdItem->MAC > 0))
                            {
                                BindItem = new TBindItem();
                                BindItem.sUnbindItemName = StdItem->ToString();
                                BindItem.nStdMode = 31;
                                BindItem.nShape = nShape;
                                BindItem.btItemType = 1;
                                g_BindItemTypeList.Add(BindItem);
                                result = true;
                                break;
                            }
                            else if ((StdItem->Shape == 1) && (StdItem->AC > 0) && (StdItem->MAC > 0))
                            {
                                BindItem = new TBindItem();
                                BindItem.sUnbindItemName = StdItem->ToString();
                                BindItem.nStdMode = 31;
                                BindItem.nShape = nShape;
                                BindItem.btItemType = 2;
                                g_BindItemTypeList.Add(BindItem);
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 查找指定解包分类能解出的物品名称 
        public static void LoadBindItemTypeFromUnbindList()
        {
            int I;
            string sItemName;
            int nShape;
            //if (UserEngine != null)
            //{
            //    g_BindItemTypeList = new TGList();
            //    if (g_UnbindList.Count > 0)
            //    {
            //        for (I = 0; I < g_UnbindList.Count; I++)
            //        {
            //            sItemName = g_UnbindList[I];
            //            nShape = ((int)g_UnbindList[I]);
            //            LoadBindItemTypeFromUnbindList_AddBindItemType(sItemName, nShape);
            //        }
            //    }
            //}
        }

        public static int GetBindItemType(int nShape)
        {
            int result;
            TBindItem BindItem;
            int I;
            result = -1;
            if (g_BindItemTypeList != null)
            {
                if (g_BindItemTypeList.Count > 0)
                {
                    for (I = 0; I < g_BindItemTypeList.Count; I++)
                    {
                        BindItem = g_BindItemTypeList[I];
                        if (BindItem.nShape == nShape)
                        {
                            result = BindItem.btItemType;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // 查找指定解包分类能解出的物品名称 
        public static string GetBindItemName(int nShape)
        {
            string result;
            TBindItem BindItem;
            int I;
            result = "";
            if (g_BindItemTypeList != null)
            {
                if (g_BindItemTypeList.Count > 0)
                {
                    for (I = 0; I < g_BindItemTypeList.Count; I++)
                    {
                        BindItem = g_BindItemTypeList[I];
                        if (BindItem.nShape == nShape)
                        {
                            result = BindItem.sUnbindItemName;
                            break;
                        }
                    }
                }
            }
            return result;
        }
        public static void LoadAllowPickUpItemList()
        {
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            sFileName = g_Config.sEnvirDir + "AllowPickUpItemList.txt";
            if (g_AllowPickUpItemList != null)
            {
                g_AllowPickUpItemList = null;
            }
            g_AllowPickUpItemList = new TStringList();
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count > 0)
                {
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        sLineText = LoadList[I].Trim();
                        if ((sLineText != "") && (sLineText[0] != ';'))
                        {
                            //g_AllowPickUpItemList.Add(sLineText);
                        }
                    }
                }
                Dispose(LoadList);
            }
            else
            {
                //g_AllowPickUpItemList.Add(";允许分身捡取物品列表");
                g_AllowPickUpItemList.SaveToFile(sFileName);
            }
        }
        public static bool IsAllowPickUpItem(string sItemName)
        {
            bool result;
            int I;
            result = false;
            if (g_AllowPickUpItemList != null)
            {
                g_AllowPickUpItemList.__Lock();
                try
                {
                    if (g_AllowPickUpItemList.Count > 0)
                    {
                        for (I = 0; I < g_AllowPickUpItemList.Count; I++)
                        {
                            if ((sItemName).ToLower().CompareTo((g_AllowPickUpItemList[I]).ToLower()) == 0)
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
                finally
                {
                    g_AllowPickUpItemList.UnLock();
                }
            }
            return result;
        }

        public static int GetUseItemIdx(string sName)
        {
            int result = -1;
            if (string.Compare(sName, U_DRESSNAME, true) == 0)
            {
                result = 0;
            }
            if (string.Compare(sName, U_WEAPONNAME, true) == 0)
            {
                result = 1;
            }
            if (string.Compare(sName, U_RIGHTHANDNAME, true) == 0)
            {
                result = 2;
            }
            if (string.Compare(sName, U_NECKLACENAME, true) == 0)
            {
                result = 3;
            }
            if (string.Compare(sName, U_HELMETNAME, true) == 0)
            {
                result = 4;
            }
            if (string.Compare(sName, U_ARMRINGLNAME, true) == 0)
            {
                result = 5;
            }
            if (string.Compare(sName, U_ARMRINGRNAME, true) == 0)
            {
                result = 6;
            }
            if (string.Compare(sName, U_RINGLNAME, true) == 0)
            {
                result = 7;
            }
            if (string.Compare(sName, U_RINGRNAME, true) == 0)
            {
                result = 8;
            }
            if (string.Compare(sName, U_BUJUKNAME, true) == 0)
            {
                result = 9;
            }
            if (string.Compare(sName, U_BELTNAME, true) == 0)
            {
                result = 10;
            }
            if (string.Compare(sName, U_BOOTSNAME, true) == 0)
            {
                result = 11;
            }
            if (string.Compare(sName, U_CHARMNAME, true) == 0)
            {
                result = 12;
            }
            if (string.Compare(sName, U_ZHULINAME, true) == 0)
            {
                result = 13;
            }
            return result;
        }

        // 保存物品事件触发列表
        public static string GetUseItemName(int nIndex)
        {
            string result = string.Empty;
            switch (nIndex)
            {
                case 0:
                    result = U_DRESSNAME;
                    break;
                case 1:
                    result = U_WEAPONNAME;
                    break;
                case 2:
                    result = U_RIGHTHANDNAME;
                    break;
                case 3:
                    result = U_NECKLACENAME;
                    break;
                case 4:
                    result = U_HELMETNAME;
                    break;
                case 5:
                    result = U_ARMRINGLNAME;
                    break;
                case 6:
                    result = U_ARMRINGRNAME;
                    break;
                case 7:
                    result = U_RINGLNAME;
                    break;
                case 8:
                    result = U_RINGRNAME;
                    break;
                case 9:
                    result = U_BUJUKNAME;
                    break;
                case 10:
                    result = U_BELTNAME;
                    break;
                case 11:
                    result = U_BOOTSNAME;
                    break;
                case 12:
                    result = U_CHARMNAME;
                    break;
                case 13:
                    result = U_ZHULINAME;
                    break;
            }
            return result;
        }

        public static bool LoadDisableSendMsgList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableSendMsgList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                if (g_DisableSendMsgList.Count > 0)
                {
                    g_DisableSendMsgList.Clear();
                }
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count > 0)
                {
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_DisableSendMsgList.Add(LoadList[I].Trim());
                    }
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool LoadMonDropLimitList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sLineText;
            string sFileName;
            string sItemName = string.Empty;
            string sItemCount = string.Empty;
            int nItemCount;
            TMonDrop MonDrop;
            result = false;
            sFileName = g_Config.sEnvirDir + "MonDropLimitList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                if (g_MonDropLimitLIst.Count > 0)
                {
                    g_MonDropLimitLIst.Clear();
                }
                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText == "") || (sLineText[0] == ';'))
                    {
                        continue;
                    }
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "/", ",", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sItemCount, new string[] { " ", "/", ",", "\09" });
                    nItemCount = HUtil32.Str_ToInt(sItemCount, -1);
                    if ((sItemName != "") && (nItemCount >= 0))
                    {
                        MonDrop = new TMonDrop();
                        MonDrop.sItemName = sItemName;
                        MonDrop.nDropCount = 0;
                        MonDrop.nNoDropCount = 0;
                        MonDrop.nCountLimit = nItemCount;
                        //g_MonDropLimitLIst.Add(sItemName, ((MonDrop) as Object));
                    }
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool SaveMonDropLimitList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            TMonDrop MonDrop;
            sFileName = g_Config.sEnvirDir + "MonDropLimitList.txt";
            LoadList = new TStringList();
            if (g_MonDropLimitLIst.Count > 0)
            {
                for (I = 0; I < g_MonDropLimitLIst.Count; I++)
                {
                    // MonDrop = ((TMonDrop)(g_MonDropLimitLIst[I]));
                    // sLineText = MonDrop.sItemName + "\09" + (MonDrop.nCountLimit).ToString();
                    // LoadList.Add(sLineText);
                }
            }
            LoadList.SaveToFile(sFileName);
            Dispose(LoadList);
            result = true;
            return result;
        }

        public static bool LoadDisableTakeOffList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sLineText;
            string sFileName;
            string sItemName = string.Empty;
            string sItemIdx = string.Empty;
            int nItemIdx;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableTakeOffList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                LoadList.LoadFromFile(sFileName);
                g_DisableTakeOffList.__Lock();
                try
                {
                    if (g_DisableTakeOffList.Count > 0)
                    {
                        g_DisableTakeOffList.Clear();
                    }
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        sLineText = LoadList[I].Trim();
                        if ((sLineText == "") || (sLineText[0] == ';'))
                        {
                            continue;
                        }
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIdx, new string[] { " ", "/", ",", "\09" });
                        nItemIdx = HUtil32.Str_ToInt(sItemIdx, -1);
                        if ((sItemName != "") && (nItemIdx >= 0))
                        {
                            //g_DisableTakeOffList.Add(sItemName, ((nItemIdx) as Object));
                        }
                    }
                }
                finally
                {
                    g_DisableTakeOffList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool SaveDisableTakeOffList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            sFileName = g_Config.sEnvirDir + "DisableTakeOffList.txt";
            LoadList = new TStringList();
            g_DisableTakeOffList.__Lock();
            try
            {
                if (g_DisableTakeOffList.Count > 0)
                {
                    for (I = 0; I < g_DisableTakeOffList.Count; I++)
                    {
                        //sLineText = g_DisableTakeOffList[I] + "\09" + (((int)g_DisableTakeOffList[I])).ToString();
                        //LoadList.Add(sLineText);
                    }
                }
            }
            finally
            {
                g_DisableTakeOffList.UnLock();
            }
            LoadList.SaveToFile(sFileName);
            Dispose(LoadList);
            result = true;
            return result;
        }

        public static bool InDisableTakeOffList(int nItemIdx)
        {
            bool result;
            int I;
            result = false;
            g_DisableTakeOffList.__Lock();
            try
            {
                if (g_DisableTakeOffList.Count > 0)
                {
                    for (I = 0; I < g_DisableTakeOffList.Count; I++)
                    {
                        //if (((int)g_DisableTakeOffList[I]) == nItemIdx - 1)
                        //{
                        //    result = true;
                        //    break;
                        //}
                    }
                }
            }
            finally
            {
                g_DisableTakeOffList.UnLock();
            }
            return result;
        }

        public static bool SaveDisableSendMsgList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "DisableSendMsgList.txt";
            LoadList = new TStringList();
            if (g_DisableSendMsgList.Count > 0)
            {
                for (I = 0; I < g_DisableSendMsgList.Count; I++)
                {
                    //LoadList.Add(g_DisableSendMsgList[I]);
                }
            }
            LoadList.SaveToFile(sFileName);
            Dispose(LoadList);
            result = true;
            return result;
        }

        public static bool GetDisableSendMsgList(string sHumanName)
        {
            bool result = false;
            if (g_DisableSendMsgList.Count > 0)
            {
                for (int I = 0; I < g_DisableSendMsgList.Count; I++)
                {
                    if ((sHumanName).ToLower().CompareTo((g_DisableSendMsgList[I]).ToLower()) == 0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool LoadGameLogItemNameList()
        {
            bool result = false;
            TStringList LoadList;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "GameLogItemNameList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_GameLogItemNameList.__Lock();
                try
                {
                    g_GameLogItemNameList.Clear();
                    LoadList.LoadFromFile(sFileName);
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        //g_GameLogItemNameList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_GameLogItemNameList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static byte GetGameLogItemNameList(string sItemName)
        {
            byte result= 0;
            g_GameLogItemNameList.__Lock();
            try
            {
                if (g_GameLogItemNameList.Count > 0)
                {
                    for (int I = 0; I < g_GameLogItemNameList.Count; I++)
                    {
                        if ((sItemName).ToLower().CompareTo((g_GameLogItemNameList[I]).ToLower()) == 0)
                        {
                            result = 1;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_GameLogItemNameList.UnLock();
            }
            return result;
        }

        public bool SaveGameLogItemNameList()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "GameLogItemNameList.txt";
            g_GameLogItemNameList.__Lock();
            try
            {
                g_GameLogItemNameList.SaveToFile(sFileName);
            }
            finally
            {
                g_GameLogItemNameList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadDenyIPAddrList()
        {
            bool result = false;
            TStringList LoadList;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "DenyIPAddrList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_DenyIPAddrList.__Lock();
                try
                {
                    if (g_DenyIPAddrList.Count > 0)
                    {
                        g_DenyIPAddrList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        //g_DenyIPAddrList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_DenyIPAddrList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetDenyIPaddrList(string sIPaddr)
        {
            bool result = false;
            g_DenyIPAddrList.__Lock();
            try
            {
                if (g_DenyIPAddrList.Count > 0)
                {
                    for (int I = 0; I < g_DenyIPAddrList.Count; I++)
                    {
                        if ((sIPaddr).ToLower().CompareTo((g_DenyIPAddrList[I]).ToLower()) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_DenyIPAddrList.UnLock();
            }
            return result;
        }

        public static bool SaveDenyIPAddrList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "DenyIPAddrList.txt";
            SaveList = new TStringList();
            g_DenyIPAddrList.__Lock();
            try
            {
                if (g_DenyIPAddrList.Count > 0)
                {
                    for (I = 0; I < g_DenyIPAddrList.Count; I++)
                    {
                        //if (((int)g_DenyIPAddrList[I]) != 0)
                        //{
                        //    SaveList.Add(g_DenyIPAddrList[I]);
                        //}
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_DenyIPAddrList.UnLock();
            }
            SaveList.Dispose();

            //SaveList.Free;
            result = true;
            return result;
        }

        // 读取禁止登录人物列表
        public static bool LoadDenyChrNameList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DenyChrNameList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_DenyChrNameList.__Lock();
                try
                {
                    if (g_DenyChrNameList.Count > 0)
                    {
                        g_DenyChrNameList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_DenyChrNameList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_DenyChrNameList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetDenyChrNameList(string sChrName)
        {
            bool result;
            int I;
            result = false;
            g_DenyChrNameList.__Lock();
            try
            {
                if (g_DenyChrNameList.Count > 0)
                {
                    for (I = 0; I < g_DenyChrNameList.Count; I++)
                    {
                        if ((sChrName).ToLower().CompareTo((g_DenyChrNameList[I]).ToLower()) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_DenyChrNameList.UnLock();
            }
            return result;
        }

        // 保存禁止登录人物列表
        public static bool SaveDenyChrNameList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "DenyChrNameList.txt";
            SaveList = new TStringList();
            g_DenyChrNameList.__Lock();
            try
            {
                if (g_DenyChrNameList.Count > 0)
                {
                    for (I = 0; I < g_DenyChrNameList.Count; I++)
                    {
                        //if (((int)g_DenyChrNameList[I]) != 0)
                        //{
                        //    SaveList.Add(g_DenyChrNameList[I]);
                        //}
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_DenyChrNameList.UnLock();
            }
            SaveList.Dispose();
            //SaveList.Free;
            result = true;
            return result;
        }

        public static bool LoadDenyAccountList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DenyAccountList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_DenyAccountList.__Lock();
                try
                {
                    if (g_DenyAccountList.Count > 0)
                    {
                        g_DenyAccountList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_DenyAccountList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_DenyAccountList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetDenyAccountList(string sAccount)
        {
            bool result;
            int I;
            result = false;
            g_DenyAccountList.__Lock();
            try
            {
                if (g_DenyAccountList.Count > 0)
                {
                    for (I = 0; I < g_DenyAccountList.Count; I++)
                    {
                        if ((sAccount).ToLower().CompareTo((g_DenyAccountList[I]).ToLower()) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_DenyAccountList.UnLock();
            }
            return result;
        }

        public static bool SaveDenyAccountList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "DenyAccountList.txt";
            SaveList = new TStringList();
            g_DenyAccountList.__Lock();
            try
            {
                if (g_DenyAccountList.Count > 0)
                {
                    // 20080629
                    for (I = 0; I < g_DenyAccountList.Count; I++)
                    {
                        //if (((int)g_DenyAccountList.Values[I]) != 0)
                        //{
                        //    SaveList.Add(g_DenyAccountList[I]);
                        //}
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_DenyAccountList.UnLock();
            }
            SaveList.Dispose();
            //SaveList.Free;
            result = true;
            return result;
        }

        public static bool LoadNoClearMonList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "NoClearMonList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_NoClearMonList.__Lock();
                try
                {
                    if (g_NoClearMonList.Count > 0)
                    {
                        g_NoClearMonList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_NoClearMonList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_NoClearMonList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetNoClearMonList(string sMonName)
        {
            bool result;
            int I;
            result = false;
            g_NoClearMonList.__Lock();
            try
            {
                for (I = 0; I < g_NoClearMonList.Count; I++)
                {
                    if ((sMonName).ToLower().CompareTo((g_NoClearMonList[I]).ToLower()) == 0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            finally
            {
                g_NoClearMonList.UnLock();
            }
            return result;
        }

        public static bool SaveNoClearMonList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "NoClearMonList.txt";
            SaveList = new TStringList();
            g_NoClearMonList.__Lock();
            try
            {
                if (g_NoClearMonList.Count > 0)
                {
                    for (I = 0; I < g_NoClearMonList.Count; I++)
                    {
                        //SaveList.Add(g_NoClearMonList[I]);
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_NoClearMonList.UnLock();
            }
            SaveList.Dispose();
            //SaveList.Free;
            result = true;
            return result;
        }

        public static bool LoadMonSayMsg()
        {
            bool result;
            int I;
            int II;
            string sStatus = string.Empty;
            string sRate = string.Empty;
            string sColor = string.Empty;
            string sMonName = string.Empty;
            string sSayMsg = string.Empty;
            int nStatus;
            int nRate;
            int nColor;
            TStringList LoadList;
            string sLineText;
            TMonSayMsg MonSayMsg;
            string sFileName;
            ArrayList MonSayList;
            bool boSearch;
            result = false;
            sFileName = g_Config.sEnvirDir + "MonSayMsg.txt";
            if (File.Exists(sFileName))
            {
                if (g_MonSayMsgList.Count > 0)
                {
                    g_MonSayMsgList.Clear();
                }
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText != "") && (sLineText[0] < ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sStatus, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sRate, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sColor, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sMonName, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sSayMsg, new string[] { " ", "/", ",", "\09" });
                        if ((sStatus != "") && (sRate != "") && (sColor != "") && (sMonName != "") && (sSayMsg != ""))
                        {
                            nStatus = HUtil32.Str_ToInt(sStatus, -1);
                            nRate = HUtil32.Str_ToInt(sRate, -1);
                            nColor = HUtil32.Str_ToInt(sColor, -1);
                            if ((nStatus >= 0) && (nRate >= 0) && (nColor >= 0))
                            {
                                MonSayMsg = new TMonSayMsg();
                                switch (nStatus)
                                {
                                    case 0:
                                        MonSayMsg.State = TMonStatus.s_KillHuman;
                                        break;
                                    case 1:
                                        MonSayMsg.State = TMonStatus.s_UnderFire;
                                        break;
                                    case 2:
                                        MonSayMsg.State = TMonStatus.s_Die;
                                        break;
                                    case 3:
                                        MonSayMsg.State = TMonStatus.s_MonGen;
                                        break;
                                    default:
                                        MonSayMsg.State = TMonStatus.s_UnderFire;
                                        break;
                                }
                                switch (nColor)
                                {
                                    case 0:
                                        MonSayMsg.Color = TMsgColor.c_Red;
                                        break;
                                    case 1:
                                        MonSayMsg.Color = TMsgColor.c_Green;
                                        break;
                                    case 2:
                                        MonSayMsg.Color = TMsgColor.c_Blue;
                                        break;
                                    case 3:
                                        MonSayMsg.Color = TMsgColor.c_White;
                                        break;
                                    default:
                                        MonSayMsg.Color = TMsgColor.c_White;
                                        break;
                                }
                                MonSayMsg.nRate = nRate;
                                MonSayMsg.sSayMsg = sSayMsg;
                                boSearch = false;
                                if (g_MonSayMsgList.Count > 0)
                                {
                                    for (II = 0; II < g_MonSayMsgList.Count; II++)
                                    {
                                        if ((g_MonSayMsgList[II]).ToLower().CompareTo((sMonName).ToLower()) == 0)
                                        {
                                            //((g_MonSayMsgList[II]) as ArrayList).Add(MonSayMsg);
                                            boSearch = true;
                                            break;
                                        }
                                    }
                                }
                                if (!boSearch)
                                {
                                    MonSayList = new ArrayList();
                                    MonSayList.Add(MonSayMsg);
                                    //g_MonSayMsgList.Add(sMonName, ((MonSayList) as Object));
                                }
                            }
                        }
                    }
                }
                LoadList.Dispose();
                //Dispose(LoadList);
                result = true;
            }
            return result;
        }

        public static void StartFixExp()
        {
            int I;
            g_dwOldNeedExps = new uint[MAXCHANGELEVEL];
            g_dwHeroNeedExps = new uint[MAXCHANGELEVEL];
            g_dwMedicineExps = new ushort[50];
            g_dwSkill68Exps = new uint[110];
            g_dwExpCrystalNeedExps = new uint[5];
            g_dwNGExpCrystalNeedExps = new uint[5];
            g_dwOldNeedExps[0] = 100;
            g_dwOldNeedExps[2] = 200;
            g_dwOldNeedExps[3] = 300;
            g_dwOldNeedExps[4] = 400;
            g_dwOldNeedExps[5] = 600;
            g_dwOldNeedExps[6] = 900;
            g_dwOldNeedExps[7] = 1200;
            g_dwOldNeedExps[8] = 1700;
            g_dwOldNeedExps[9] = 2500;
            g_dwOldNeedExps[10] = 6000;
            g_dwOldNeedExps[11] = 8000;
            g_dwOldNeedExps[12] = 10000;
            g_dwOldNeedExps[13] = 15000;
            g_dwOldNeedExps[14] = 30000;
            g_dwOldNeedExps[15] = 40000;
            g_dwOldNeedExps[16] = 50000;
            g_dwOldNeedExps[17] = 70000;
            g_dwOldNeedExps[18] = 10000;
            g_dwOldNeedExps[19] = 120000;
            g_dwOldNeedExps[20] = 140000;
            g_dwOldNeedExps[21] = 250000;
            g_dwOldNeedExps[22] = 300000;
            g_dwOldNeedExps[23] = 350000;
            g_dwOldNeedExps[24] = 400000;
            g_dwOldNeedExps[25] = 500000;
            g_dwOldNeedExps[26] = 700000;
            g_dwOldNeedExps[27] = 1000000;
            g_dwOldNeedExps[28] = 1400000;
            g_dwOldNeedExps[29] = 1800000;
            g_dwOldNeedExps[30] = 2000000;
            g_dwOldNeedExps[31] = 2400000;
            g_dwOldNeedExps[32] = 2800000;
            g_dwOldNeedExps[33] = 3200000;
            g_dwOldNeedExps[34] = 3600000;
            g_dwOldNeedExps[35] = 4000000;
            g_dwOldNeedExps[36] = 4800000;
            g_dwOldNeedExps[37] = 5600000;
            g_dwOldNeedExps[38] = 8200000;
            g_dwOldNeedExps[39] = 9000000;
            g_dwOldNeedExps[40] = 12000000;
            g_dwOldNeedExps[41] = 16000000;
            g_dwOldNeedExps[42] = 30000000;
            g_dwOldNeedExps[43] = 50000000;
            g_dwOldNeedExps[44] = 80000000;
            g_dwOldNeedExps[45] = 120000000;
            g_dwOldNeedExps[46] = 480000000;
            g_dwOldNeedExps[47] = 1000000000;
            g_dwOldNeedExps[48] = 1500000000;
            g_dwOldNeedExps[49] = 1800000000;
            for (I = 50; I <= g_dwOldNeedExps.GetUpperBound(0); I++)
            {
                g_dwOldNeedExps[I] = 2000000000;
            }
            g_dwHeroNeedExps[0] = 50;
            g_dwHeroNeedExps[2] = 100;
            g_dwHeroNeedExps[3] = 150;
            g_dwHeroNeedExps[4] = 200;
            g_dwHeroNeedExps[5] = 300;
            g_dwHeroNeedExps[6] = 450;
            g_dwHeroNeedExps[7] = 600;
            g_dwHeroNeedExps[8] = 800;
            g_dwHeroNeedExps[9] = 1200;
            g_dwHeroNeedExps[10] = 3000;
            g_dwHeroNeedExps[11] = 4000;
            g_dwHeroNeedExps[12] = 5000;
            g_dwHeroNeedExps[13] = 7500;
            g_dwHeroNeedExps[14] = 15000;
            g_dwHeroNeedExps[15] = 20000;
            g_dwHeroNeedExps[16] = 25000;
            g_dwHeroNeedExps[17] = 35000;
            g_dwHeroNeedExps[18] = 50000;
            g_dwHeroNeedExps[19] = 60000;
            g_dwHeroNeedExps[20] = 70000;
            g_dwHeroNeedExps[21] = 100000;
            g_dwHeroNeedExps[22] = 150000;
            g_dwHeroNeedExps[23] = 160000;
            g_dwHeroNeedExps[24] = 200000;
            g_dwHeroNeedExps[25] = 250000;
            g_dwHeroNeedExps[26] = 350000;
            g_dwHeroNeedExps[27] = 500000;
            g_dwHeroNeedExps[28] = 700000;
            g_dwHeroNeedExps[29] = 800000;
            g_dwHeroNeedExps[30] = 1000000;
            g_dwHeroNeedExps[31] = 1200000;
            g_dwHeroNeedExps[32] = 1400000;
            g_dwHeroNeedExps[33] = 1600000;
            g_dwHeroNeedExps[34] = 1800000;
            g_dwHeroNeedExps[35] = 2000000;
            g_dwHeroNeedExps[36] = 2400000;
            g_dwHeroNeedExps[37] = 2800000;
            g_dwHeroNeedExps[38] = 4000000;
            g_dwHeroNeedExps[39] = 4500000;
            g_dwHeroNeedExps[40] = 6000000;
            g_dwHeroNeedExps[41] = 8000000;
            g_dwHeroNeedExps[42] = 15000000;
            g_dwHeroNeedExps[43] = 25000000;
            g_dwHeroNeedExps[44] = 40000000;
            g_dwHeroNeedExps[45] = 60000000;
            g_dwHeroNeedExps[46] = 240000000;
            g_dwHeroNeedExps[47] = 500000000;
            g_dwHeroNeedExps[48] = 800000000;
            g_dwHeroNeedExps[49] = 900000000;
            for (I = 50; I <= g_dwHeroNeedExps.GetUpperBound(0); I++)
            {
                g_dwHeroNeedExps[I] = 1000000000;
            }
            g_dwMedicineExps[0] = 48;
            g_dwMedicineExps[2] = 142;
            g_dwMedicineExps[3] = 232;
            g_dwMedicineExps[4] = 318;
            g_dwMedicineExps[5] = 400;
            g_dwMedicineExps[6] = 478;
            g_dwMedicineExps[7] = 556;
            g_dwMedicineExps[8] = 634;
            g_dwMedicineExps[9] = 712;
            g_dwMedicineExps[10] = 790;
            g_dwMedicineExps[11] = 868;
            g_dwMedicineExps[12] = 946;
            g_dwMedicineExps[13] = 1024;
            g_dwMedicineExps[14] = 1102;
            g_dwMedicineExps[15] = 1180;
            g_dwMedicineExps[16] = 1258;
            g_dwMedicineExps[17] = 1336;
            g_dwMedicineExps[18] = 1414;
            g_dwMedicineExps[19] = 1492;
            g_dwMedicineExps[20] = 1570;
            g_dwMedicineExps[21] = 1648;
            g_dwMedicineExps[22] = 1726;
            g_dwMedicineExps[23] = 1804;
            g_dwMedicineExps[24] = 1882;
            g_dwMedicineExps[25] = 1960;
            g_dwMedicineExps[26] = 2038;
            g_dwMedicineExps[27] = 2116;
            g_dwMedicineExps[28] = 2194;
            g_dwMedicineExps[29] = 2272;
            g_dwMedicineExps[30] = 2350;
            g_dwMedicineExps[31] = 2428;
            g_dwMedicineExps[32] = 2506;
            g_dwMedicineExps[33] = 2584;
            g_dwMedicineExps[34] = 2662;
            g_dwMedicineExps[35] = 2740;
            g_dwMedicineExps[36] = 2818;
            g_dwMedicineExps[37] = 2896;
            g_dwMedicineExps[38] = 2974;
            g_dwMedicineExps[39] = 3052;
            g_dwMedicineExps[40] = 3130;
            g_dwMedicineExps[41] = 3208;
            g_dwMedicineExps[42] = 3286;
            g_dwMedicineExps[43] = 3364;
            g_dwMedicineExps[44] = 3442;
            g_dwMedicineExps[45] = 3520;
            g_dwMedicineExps[46] = 3598;
            g_dwMedicineExps[47] = 3676;
            g_dwMedicineExps[48] = 3754;
            g_dwMedicineExps[49] = 3832;
            for (I = 50; I <= g_dwMedicineExps.GetUpperBound(0); I++)
            {
                g_dwMedicineExps[I] = 3910;
            }
            g_dwSkill68Exps[0] = 3333000;
            g_dwSkill68Exps[2] = 3816000;
            g_dwSkill68Exps[3] = 4329000;
            g_dwSkill68Exps[4] = 4872000;
            g_dwSkill68Exps[5] = 5445000;
            g_dwSkill68Exps[6] = 6048000;
            g_dwSkill68Exps[7] = 6681000;
            g_dwSkill68Exps[8] = 7344000;
            g_dwSkill68Exps[9] = 8037000;
            g_dwSkill68Exps[10] = 8760000;
            g_dwSkill68Exps[11] = 9513000;
            g_dwSkill68Exps[12] = 10296000;
            g_dwSkill68Exps[13] = 11109000;
            g_dwSkill68Exps[14] = 11952000;
            g_dwSkill68Exps[15] = 12825000;
            g_dwSkill68Exps[16] = 13728000;
            g_dwSkill68Exps[17] = 14661000;
            g_dwSkill68Exps[18] = 15624000;
            g_dwSkill68Exps[19] = 16617000;
            g_dwSkill68Exps[20] = 17640000;
            g_dwSkill68Exps[21] = 18693000;
            g_dwSkill68Exps[22] = 19776000;
            g_dwSkill68Exps[23] = 20889000;
            g_dwSkill68Exps[24] = 22032000;
            g_dwSkill68Exps[25] = 23205000;
            g_dwSkill68Exps[26] = 24408000;
            g_dwSkill68Exps[27] = 25641000;
            g_dwSkill68Exps[28] = 26904000;
            g_dwSkill68Exps[29] = 28197000;
            g_dwSkill68Exps[30] = 29520000;
            g_dwSkill68Exps[31] = 30873000;
            g_dwSkill68Exps[32] = 32256000;
            g_dwSkill68Exps[33] = 33669000;
            g_dwSkill68Exps[34] = 35112000;
            g_dwSkill68Exps[35] = 36585000;
            g_dwSkill68Exps[36] = 38088000;
            g_dwSkill68Exps[37] = 39621000;
            g_dwSkill68Exps[38] = 41184000;
            g_dwSkill68Exps[39] = 42777000;
            g_dwSkill68Exps[40] = 44400000;
            g_dwSkill68Exps[41] = 46053000;
            g_dwSkill68Exps[42] = 47736000;
            g_dwSkill68Exps[43] = 49449000;
            g_dwSkill68Exps[44] = 51192000;
            g_dwSkill68Exps[45] = 52965000;
            g_dwSkill68Exps[46] = 54768000;
            g_dwSkill68Exps[47] = 56601000;
            g_dwSkill68Exps[48] = 58464000;
            g_dwSkill68Exps[49] = 60357000;
            g_dwSkill68Exps[50] = 62280000;
            g_dwSkill68Exps[51] = 64233000;
            g_dwSkill68Exps[52] = 66216000;
            g_dwSkill68Exps[53] = 68229000;
            g_dwSkill68Exps[54] = 70272000;
            g_dwSkill68Exps[55] = 72345000;
            g_dwSkill68Exps[56] = 74448000;
            g_dwSkill68Exps[57] = 76581000;
            g_dwSkill68Exps[58] = 78744000;
            g_dwSkill68Exps[59] = 80937000;
            g_dwSkill68Exps[60] = 83160000;
            g_dwSkill68Exps[61] = 85413000;
            g_dwSkill68Exps[62] = 87696000;
            g_dwSkill68Exps[63] = 90009000;
            g_dwSkill68Exps[64] = 92352000;
            g_dwSkill68Exps[65] = 94725000;
            g_dwSkill68Exps[66] = 97128000;
            g_dwSkill68Exps[67] = 99561000;
            g_dwSkill68Exps[68] = 102024000;
            g_dwSkill68Exps[69] = 104517000;
            g_dwSkill68Exps[70] = 107040000;
            g_dwSkill68Exps[71] = 109593000;
            g_dwSkill68Exps[72] = 112176000;
            g_dwSkill68Exps[73] = 114789000;
            g_dwSkill68Exps[74] = 117432000;
            g_dwSkill68Exps[75] = 120105000;
            g_dwSkill68Exps[76] = 122808000;
            g_dwSkill68Exps[77] = 125541000;
            g_dwSkill68Exps[78] = 128304000;
            g_dwSkill68Exps[79] = 131097000;
            g_dwSkill68Exps[80] = 133920000;
            g_dwSkill68Exps[81] = 136773000;
            g_dwSkill68Exps[82] = 139656000;
            g_dwSkill68Exps[83] = 142569000;
            g_dwSkill68Exps[84] = 145512000;
            g_dwSkill68Exps[85] = 148485000;
            g_dwSkill68Exps[86] = 151488000;
            g_dwSkill68Exps[87] = 154521000;
            g_dwSkill68Exps[88] = 157584000;
            g_dwSkill68Exps[89] = 160677000;
            g_dwSkill68Exps[90] = 163800000;
            g_dwSkill68Exps[91] = 166953000;
            g_dwSkill68Exps[92] = 170136000;
            g_dwSkill68Exps[93] = 173349000;
            g_dwSkill68Exps[94] = 176592000;
            g_dwSkill68Exps[95] = 179865000;
            g_dwSkill68Exps[96] = 183168000;
            g_dwSkill68Exps[97] = 186501000;
            g_dwSkill68Exps[98] = 189864000;
            g_dwSkill68Exps[99] = 193257000;
            g_dwSkill68Exps[100] = 203257000;
            g_dwExpCrystalNeedExps[0] = 300000;
            // 天地结晶升级经验
            g_dwExpCrystalNeedExps[2] = 700000;
            g_dwExpCrystalNeedExps[3] = 1200000;
            g_dwExpCrystalNeedExps[4] = 1800000;
            g_dwNGExpCrystalNeedExps[0] = 100000;
            // 天地结晶内功升级经验
            g_dwNGExpCrystalNeedExps[2] = 240000;
            g_dwNGExpCrystalNeedExps[3] = 400000;
            g_dwNGExpCrystalNeedExps[4] = 580000;
        }

        public static void LoadExp()
        {
            int I;
            int LoadInteger;
            int LoadInteger1;
            string LoadString;

            LoadInteger = Config.ReadInteger("Exp", "KillMonExpMultiple", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "KillMonExpMultiple", g_Config.dwKillMonExpMultiple);
            }
            else
            {
                g_Config.dwKillMonExpMultiple = Config.ReadInteger("Exp", "KillMonExpMultiple", g_Config.dwKillMonExpMultiple);
            }
            // 杀怪内功经验倍数
            LoadInteger = Config.ReadInteger("Exp", "KillMonNGExpMultiple", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "KillMonNGExpMultiple", g_Config.dwKillMonNGExpMultiple);
            }
            else
            {
                g_Config.dwKillMonNGExpMultiple = Config.ReadInteger("Exp", "KillMonNGExpMultiple", g_Config.dwKillMonNGExpMultiple);
            }
            LoadInteger = Config.ReadInteger("Exp", "HighLevelKillMonFixExp", -1);
            if (LoadInteger < 0)
            {
                Config.WriteBool("Exp", "HighLevelKillMonFixExp", g_Config.boHighLevelKillMonFixExp);
            }
            else
            {
                g_Config.boHighLevelKillMonFixExp = Config.ReadBool("Exp", "HighLevelKillMonFixExp", g_Config.boHighLevelKillMonFixExp);
            }
            for (I = 0; I <= MAXCHANGELEVEL - 1; I++)
            {
                LoadString = Config.ReadString("Exp", "Level" + I, "");
                LoadInteger1 = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger1 == 0)
                {
                    Config.WriteString("Exp", "Level" + I, g_dwOldNeedExps[I].ToString());
                    g_Config.dwNeedExps[I] = g_dwOldNeedExps[I];
                }
                else
                {
                    if ((LoadInteger1 > 0))
                    {
                        g_Config.dwNeedExps[I] = (uint)LoadInteger1;
                    }
                    else
                    {
                        g_Config.dwNeedExps[I] = g_dwOldNeedExps[I];
                    }
                }
            }
            for (I = 0; I <= MAXCHANGELEVEL - 1; I++)
            {
                LoadString = Config.ReadString("HeroExp", "Level" + I, "");
                LoadInteger1 = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger1 == 0)
                {
                    Config.WriteString("HeroExp", "Level" + I, (g_dwHeroNeedExps[I]).ToString());
                    g_Config.dwHeroNeedExps[I] = g_dwHeroNeedExps[I];
                }
                else
                {
                    if ((LoadInteger1 > 0))
                    {
                        g_Config.dwHeroNeedExps[I] = (uint)LoadInteger1;
                    }
                    else
                    {
                        g_Config.dwHeroNeedExps[I] = g_dwHeroNeedExps[I];
                    }
                }
            }
            // ----------------------------------------------------------------------------
            // 药力值
            for (I = 0; I <= 50 - 1; I++)
            {
                LoadString = Config.ReadString("MedicineExp", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("MedicineExp", "Level" + I, (g_dwMedicineExps[I]).ToString());
                    g_Config.dwMedicineNeedExps[I] = g_dwMedicineExps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwMedicineNeedExps[I] = (ushort)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwMedicineNeedExps[I] = g_dwMedicineExps[I];
                    }
                }
            }
            // ----------------------------------------------------------------------------
            // 酒气护体
            for (I = 0; I <= 100 - 1; I++)
            {
                LoadString = Config.ReadString("Skill68", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("Skill68", "Level" + I, (int)g_dwSkill68Exps[I]);
                    g_Config.dwSkill68NeedExps[I] = g_dwSkill68Exps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwSkill68NeedExps[I] = (uint)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwSkill68NeedExps[I] = g_dwSkill68Exps[I];
                    }
                }
            }
            // 天地结晶经验
            for (I = 0; I <= 4; I++)
            {
                LoadString = Config.ReadString("ExpCrystal", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("ExpCrystal", "Level" + I, (int)g_dwExpCrystalNeedExps[I]);
                    g_Config.dwExpCrystalNeedExps[I] = g_dwExpCrystalNeedExps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwExpCrystalNeedExps[I] = (uint)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwExpCrystalNeedExps[I] = g_dwExpCrystalNeedExps[I];
                    }
                }
            }
            // 天地结晶内功经验
            for (I = 0; I <= 4; I++)
            {
                LoadString = Config.ReadString("NGExpCrystal", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("NGExpCrystal", "Level" + I, (int)g_dwNGExpCrystalNeedExps[I]);
                    g_Config.dwNGExpCrystalNeedExps[I] = g_dwNGExpCrystalNeedExps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwNGExpCrystalNeedExps[I] = (uint)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwNGExpCrystalNeedExps[I] = g_dwNGExpCrystalNeedExps[I];
                    }
                }
            }
            // ----------------------------------------------------------------------------
            if (Config.ReadInteger("Exp", "UseFixExp", -1) < 0)
            {
                Config.WriteBool("Exp", "UseFixExp", g_Config.boUseFixExp);
            }
            g_Config.boUseFixExp = Config.ReadBool("Setup", "UseFixExp", g_Config.boUseFixExp);
            LoadInteger = Config.ReadInteger("Exp", "BaseExp", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "BaseExp", g_Config.nBaseExp);
            }
            else
            {
                g_Config.nBaseExp = LoadInteger;
            }
            LoadInteger = Config.ReadInteger("Setup", "AddExp", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "AddExp", g_Config.nAddExp);
            }
            else
            {
                g_Config.nAddExp = LoadInteger;
            }
        }

        /// <summary>
        /// 加载游戏命令
        /// </summary>
        public static void LoadGameCommand()
        {
            string LoadString;
            int nLoadInteger;

            IniFile.SyncIniString(CommandConf, "Command", "Date", "", ref g_GameCommand.Data.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Date", ref g_GameCommand.Data.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "PrvMsg", "", ref  g_GameCommand.PRVMSG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "PrvMsg", ref g_GameCommand.PRVMSG.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "AllowMsg", "", ref g_GameCommand.ALLOWMSG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AllowMsg", ref g_GameCommand.ALLOWMSG.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "LetShout", "", ref g_GameCommand.LETSHOUT.sCmd);
            g_GameCommand.BANGMMSG.sCmd = "禁止喊话";
            IniFile.SyncIniString(CommandConf, "Command", "LetTrade", "", ref g_GameCommand.LETTRADE.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "LetGuild", "", ref g_GameCommand.LETGUILD.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "EndGuild", "", ref g_GameCommand.ENDGUILD.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "BanGuildChat", "", ref  g_GameCommand.BANGUILDCHAT.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "AuthAlly", "", ref  g_GameCommand.AUTHALLY.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "Auth", "", ref g_GameCommand.AUTH.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "AuthCancel", "", ref  g_GameCommand.AUTHCANCEL.sCmd);

            // 未使用 20080823
            // LoadString := CommandConf.ReadString('Command', 'ViewDiary', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ViewDiary', g_GameCommand.DIARY.sCmd)
            // else g_GameCommand.DIARY.sCmd := LoadString;

            IniFile.SyncIniString(CommandConf, "Command", "UserMove", "", ref  g_GameCommand.USERMOVE.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "Searching", "", ref  g_GameCommand.SEARCHING.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "AllowGroupCall", "", ref  g_GameCommand.ALLOWGROUPCALL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "GroupCall", "", ref   g_GameCommand.GROUPRECALLL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "AllowGuildReCall", "", ref    g_GameCommand.ALLOWGUILDRECALL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "GuildReCall", "", ref    g_GameCommand.GUILDRECALLL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "StorageUnLock", "", ref   g_GameCommand.UNLOCKSTORAGE.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "PasswordUnLock", "", ref   g_GameCommand.UnLock.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "StorageLock", "", ref   g_GameCommand.__Lock.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "StorageSetPassword", "", ref   g_GameCommand.SETPASSWORD.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "PasswordLock", "", ref   g_GameCommand.PASSWORDLOCK.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "StorageChgPassword", "", ref   g_GameCommand.CHGPASSWORD.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "StorageClearPassword", "", ref   g_GameCommand.CLRPASSWORD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "StorageClearPassword", ref  g_GameCommand.CLRPASSWORD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "StorageUserClearPassword", "", ref  g_GameCommand.UNPASSWORD.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "MemberFunc", "", ref  g_GameCommand.MEMBERFUNCTION.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "MemberFuncEx", "", ref  g_GameCommand.MEMBERFUNCTIONEX.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "Dear", "", ref  g_GameCommand.DEAR.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "Master", "", ref   g_GameCommand.MASTER.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "DearRecall", "", ref   g_GameCommand.DEARRECALL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "MasterRecall", "", ref    g_GameCommand.MASTERECALL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "AllowDearRecall", "", ref    g_GameCommand.ALLOWDEARRCALL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "AllowMasterRecall", "", ref    g_GameCommand.ALLOWMASTERRECALL.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "AttackMode", "", ref     g_GameCommand.ATTACKMODE.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "Rest", "", ref     g_GameCommand.REST.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "TakeOnHorse", "", ref     g_GameCommand.TAKEONHORSE.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "TakeOffHorse", "", ref     g_GameCommand.TAKEOFHORSE.sCmd);
            IniFile.SyncIniString(CommandConf, "Command", "HumanLocal", "", ref     g_GameCommand.HUMANLOCAL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "HumanLocal", ref  g_GameCommand.HUMANLOCAL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Move", "", ref     g_GameCommand.Move.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MoveMin", ref  g_GameCommand.Move.nPermissionMin);
            IniFile.SyncIniInt(CommandConf, "Permission", "MoveMax", ref  g_GameCommand.Move.nPermissionMax);
            IniFile.SyncIniString(CommandConf, "Command", "PositionMove", "", ref     g_GameCommand.POSITIONMOVE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "PositionMoveMin", ref  g_GameCommand.POSITIONMOVE.nPermissionMin);
            IniFile.SyncIniInt(CommandConf, "Permission", "PositionMoveMax", ref  g_GameCommand.POSITIONMOVE.nPermissionMax);
            IniFile.SyncIniString(CommandConf, "Command", "Info", "", ref     g_GameCommand.INFO.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Info", ref  g_GameCommand.INFO.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "MobLevel", "", ref     g_GameCommand.MOBLEVEL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MobLevel", ref  g_GameCommand.MOBLEVEL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "MobCount", "", ref     g_GameCommand.MOBCOUNT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MobCount", ref  g_GameCommand.MOBCOUNT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "HumanCount", "", ref     g_GameCommand.HUMANCOUNT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "HumanCount", ref  g_GameCommand.HUMANCOUNT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Map", "", ref     g_GameCommand.Map.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Map", ref  g_GameCommand.Map.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Kick", "", ref     g_GameCommand.KICK.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Kick", ref  g_GameCommand.KICK.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Ting", "", ref     g_GameCommand.TING.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Ting", ref  g_GameCommand.TING.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SuperTing", "", ref     g_GameCommand.SUPERTING.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SuperTing", ref  g_GameCommand.SUPERTING.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "MapMove", "", ref     g_GameCommand.MAPMOVE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MapMove", ref  g_GameCommand.MAPMOVE.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Shutup", "", ref     g_GameCommand.SHUTUP.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Shutup", ref  g_GameCommand.SHUTUP.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReleaseShutup", "", ref     g_GameCommand.RELEASESHUTUP.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReleaseShutup", ref  g_GameCommand.RELEASESHUTUP.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ShutupList", "", ref     g_GameCommand.SHUTUPLIST.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ShutupList", ref  g_GameCommand.SHUTUPLIST.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "GameMaster", "", ref     g_GameCommand.GAMEMASTER.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "GameMaster", ref  g_GameCommand.GAMEMASTER.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ObServer", "", ref     g_GameCommand.OBSERVER.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ObServer", ref  g_GameCommand.OBSERVER.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SuperMan", "", ref     g_GameCommand.SUEPRMAN.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SuperMan", ref  g_GameCommand.SUEPRMAN.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Level", "", ref     g_GameCommand.Level.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Level", ref  g_GameCommand.Level.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SabukWallGold", "", ref     g_GameCommand.SABUKWALLGOLD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SabukWallGold", ref  g_GameCommand.SABUKWALLGOLD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Recall", "", ref     g_GameCommand.RECALL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Recall", ref  g_GameCommand.RECALL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReGoto", "", ref     g_GameCommand.REGOTO.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReGoto", ref g_GameCommand.REGOTO.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Flag", "", ref g_GameCommand.SHOWFLAG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Flag", ref  g_GameCommand.SHOWFLAG.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'ShowOpen', ''); //20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ShowOpen', g_GameCommand.SHOWOPEN.sCmd)
            // else g_GameCommand.SHOWOPEN.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ShowOpen', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ShowOpen', g_GameCommand.SHOWOPEN.nPermissionMin)
            // else g_GameCommand.SHOWOPEN.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ShowUnit', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ShowUnit', g_GameCommand.SHOWUNIT.sCmd)
            // else g_GameCommand.SHOWUNIT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ShowUnit', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ShowUnit', g_GameCommand.SHOWUNIT.nPermissionMin)
            // else g_GameCommand.SHOWUNIT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'Attack', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Attack', g_GameCommand.Attack.sCmd)
            // else g_GameCommand.Attack.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Attack', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Attack', g_GameCommand.Attack.nPermissionMin)
            // else g_GameCommand.Attack.nPermissionMin := nLoadInteger;

            IniFile.SyncIniString(CommandConf, "Command", "Mob", "", ref  g_GameCommand.MOB.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Mob", ref g_GameCommand.MOB.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "MobNpc", "", ref  g_GameCommand.MOBNPC.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MobNpc", ref g_GameCommand.MOBNPC.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelNpc", "", ref  g_GameCommand.DELNPC.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelNpc", ref g_GameCommand.DELNPC.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "NpcScript", "", ref  g_GameCommand.NPCSCRIPT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "NpcScript", ref g_GameCommand.NPCSCRIPT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "RecallMob", "", ref  g_GameCommand.RECALLMOB.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "RecallMob", ref g_GameCommand.RECALLMOB.nPermissionMin);
            // ------------------------------------------------------------------------------
            // 20080122 召唤宝宝
            IniFile.SyncIniString(CommandConf, "Command", "RECALLMOBEX", "", ref  g_GameCommand.RECALLMOBEX.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "RECALLMOBEX", ref g_GameCommand.RECALLMOBEX.nPermissionMin);
            // ------------------------------------------------------------------------------
            // 20080403 给指定纯度的矿石
            IniFile.SyncIniString(CommandConf, "Command", "GIVEMINE", "", ref  g_GameCommand.GIVEMINE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "GIVEMINE", ref g_GameCommand.GIVEMINE.nPermissionMin);

            // ------------------------------------------------------------------------------
            // 20080123 将指定坐标的怪物移动到新坐标
            IniFile.SyncIniString(CommandConf, "Command", "MOVEMOBTO", "", ref  g_GameCommand.MOVEMOBTO.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MOVEMOBTO", ref g_GameCommand.MOVEMOBTO.nPermissionMin);

            // ------------------------------------------------------------------------------
            // 20080124 清除地图物品

            IniFile.SyncIniString(CommandConf, "Command", "CLEARITEMMAP", "", ref  g_GameCommand.CLEARITEMMAP.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "CLEARITEMMAP", ref g_GameCommand.CLEARITEMMAP.nPermissionMin);

            // ------------------------------------------------------------------------------
            IniFile.SyncIniString(CommandConf, "Command", "LuckPoint", "", ref  g_GameCommand.LUCKYPOINT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "LuckPoint", ref g_GameCommand.LUCKYPOINT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "LotteryTicket", "", ref  g_GameCommand.LOTTERYTICKET.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "LotteryTicket", ref g_GameCommand.LOTTERYTICKET.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadGuild", "", ref  g_GameCommand.RELOADGUILD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadGuild", ref g_GameCommand.RELOADGUILD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadLineNotice", "", ref  g_GameCommand.RELOADLINENOTICE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadLineNotice", ref g_GameCommand.RELOADLINENOTICE.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadAbuse", "", ref  g_GameCommand.RELOADABUSE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadAbuse", ref g_GameCommand.RELOADABUSE.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "BackStep", "", ref  g_GameCommand.BACKSTEP.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "BackStep", ref g_GameCommand.BACKSTEP.nPermissionMin);
            // LoadString := CommandConf.ReadString('Command', 'Ball', ''); //20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Ball', g_GameCommand.BALL.sCmd)
            // else g_GameCommand.BALL.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Ball', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Ball', g_GameCommand.BALL.nPermissionMin)
            // else g_GameCommand.BALL.nPermissionMin := nLoadInteger;

            IniFile.SyncIniString(CommandConf, "Command", "FreePenalty", "", ref g_GameCommand.FREEPENALTY.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "FreePenalty", ref g_GameCommand.FREEPENALTY.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "PkPoint", "", ref g_GameCommand.PKPOINT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "PkPoint", ref g_GameCommand.PKPOINT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "IncPkPoint", "", ref g_GameCommand.IncPkPoint.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "IncPkPoint", ref g_GameCommand.IncPkPoint.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'ChangeLuck', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ChangeLuck', g_GameCommand.CHANGELUCK.sCmd)
            // else g_GameCommand.CHANGELUCK.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ChangeLuck', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ChangeLuck', g_GameCommand.CHANGELUCK.nPermissionMin)
            // else g_GameCommand.CHANGELUCK.nPermissionMin := nLoadInteger;

            IniFile.SyncIniString(CommandConf, "Command", "Hunger", "", ref g_GameCommand.HUNGER.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Hunger", ref g_GameCommand.HUNGER.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Hair", "", ref g_GameCommand.HAIR.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Hair", ref g_GameCommand.HAIR.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Training", "", ref g_GameCommand.TRAINING.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Training", ref g_GameCommand.TRAINING.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DeleteSkill", "", ref g_GameCommand.DELETESKILL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DeleteSkill", ref g_GameCommand.DELETESKILL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ChangeJob", "", ref g_GameCommand.CHANGEJOB.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeJob", ref g_GameCommand.CHANGEJOB.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ChangeGender", "", ref g_GameCommand.CHANGEGENDER.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeGender", ref g_GameCommand.CHANGEGENDER.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'NameColor', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'NameColor', g_GameCommand.NAMECOLOR.sCmd)
            // else g_GameCommand.NAMECOLOR.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'NameColor', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'NameColor', g_GameCommand.NAMECOLOR.nPermissionMin)
            // else g_GameCommand.NAMECOLOR.nPermissionMin := nLoadInteger;
            IniFile.SyncIniString(CommandConf, "Command", "Mission", "", ref g_GameCommand.Mission.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Mission", ref g_GameCommand.Mission.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "MobPlace", "", ref g_GameCommand.MobPlace.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MobPlace", ref g_GameCommand.MobPlace.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'Transparecy', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Transparecy', g_GameCommand.TRANSPARECY.sCmd)
            // else g_GameCommand.TRANSPARECY.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Transparecy', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Transparecy', g_GameCommand.TRANSPARECY.nPermissionMin)
            // else g_GameCommand.TRANSPARECY.nPermissionMin := nLoadInteger;
            IniFile.SyncIniString(CommandConf, "Command", "DeleteItem", "", ref g_GameCommand.DELETEITEM.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DeleteItem", ref g_GameCommand.DELETEITEM.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'Level0', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Level0', g_GameCommand.LEVEL0.sCmd)
            // else g_GameCommand.LEVEL0.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Level0', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Level0', g_GameCommand.LEVEL0.nPermissionMin)
            // else g_GameCommand.LEVEL0.nPermissionMin := nLoadInteger;
            IniFile.SyncIniString(CommandConf, "Command", "ClearMission", "", ref g_GameCommand.CLEARMISSION.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ClearMission", ref g_GameCommand.CLEARMISSION.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SetFlag", "", ref g_GameCommand.SETFLAG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SetFlag", ref g_GameCommand.SETFLAG.nPermissionMin);


            // LoadString := CommandConf.ReadString('Command', 'SetOpen', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'SetOpen', g_GameCommand.SETOPEN.sCmd)
            // else g_GameCommand.SETOPEN.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'SetOpen', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'SetOpen', g_GameCommand.SETOPEN.nPermissionMin)
            // else g_GameCommand.SETOPEN.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'SetUnit', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'SetUnit', g_GameCommand.SETUNIT.sCmd)
            // else g_GameCommand.SETUNIT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'SetUnit', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'SetUnit', g_GameCommand.SETUNIT.nPermissionMin)
            // else g_GameCommand.SETUNIT.nPermissionMin := nLoadInteger;
            IniFile.SyncIniString(CommandConf, "Command", "ReConnection", "", ref g_GameCommand.RECONNECTION.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReConnection", ref g_GameCommand.RECONNECTION.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DisableFilter", "", ref g_GameCommand.DISABLEFILTER.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DisableFilter", ref g_GameCommand.DISABLEFILTER.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ChangeUserFull", "", ref g_GameCommand.CHGUSERFULL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeUserFull", ref g_GameCommand.CHGUSERFULL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ChangeZenFastStep", "", ref g_GameCommand.CHGZENFASTSTEP.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeZenFastStep", ref g_GameCommand.CHGZENFASTSTEP.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ContestPoint", "", ref g_GameCommand.CONTESTPOINT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ContestPoint", ref g_GameCommand.CONTESTPOINT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "StartContest", "", ref g_GameCommand.STARTCONTEST.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "StartContest", ref g_GameCommand.STARTCONTEST.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "EndContest", "", ref g_GameCommand.ENDCONTEST.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "EndContest", ref g_GameCommand.ENDCONTEST.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Announcement", "", ref g_GameCommand.ANNOUNCEMENT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Announcement", ref g_GameCommand.ANNOUNCEMENT.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'OXQuizRoom', ''); //20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'OXQuizRoom', g_GameCommand.OXQUIZROOM.sCmd)
            // else g_GameCommand.OXQUIZROOM.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'OXQuizRoom', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'OXQuizRoom', g_GameCommand.OXQUIZROOM.nPermissionMin)
            // else g_GameCommand.OXQUIZROOM.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'Gsa', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Gsa', g_GameCommand.GSA.sCmd)
            // else g_GameCommand.GSA.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Gsa', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Gsa', g_GameCommand.GSA.nPermissionMin)
            // else g_GameCommand.GSA.nPermissionMin := nLoadInteger;

            IniFile.SyncIniString(CommandConf, "Command", "ChangeItemName", "", ref g_GameCommand.CHANGEITEMNAME.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeItemName", ref g_GameCommand.CHANGEITEMNAME.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DisableSendMsg", "", ref g_GameCommand.DISABLESENDMSG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DisableSendMsg", ref g_GameCommand.DISABLESENDMSG.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "EnableSendMsg", "", ref g_GameCommand.ENABLESENDMSG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "EnableSendMsg", ref g_GameCommand.ENABLESENDMSG.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DisableSendMsgList", "", ref g_GameCommand.DISABLESENDMSGLIST.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DisableSendMsgList", ref g_GameCommand.DISABLESENDMSGLIST.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Kill", "", ref g_GameCommand.KILL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Kill", ref g_GameCommand.KILL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Make", "", ref g_GameCommand.MAKE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MakeMin", ref g_GameCommand.MAKE.nPermissionMin);
            IniFile.SyncIniInt(CommandConf, "Permission", "MakeMax", ref g_GameCommand.MAKE.nPermissionMax);
            IniFile.SyncIniString(CommandConf, "Command", "SuperMake", "", ref g_GameCommand.SMAKE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SuperMake", ref g_GameCommand.SMAKE.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "BonusPoint", "", ref g_GameCommand.BonusPoint.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "BonusPoint", ref g_GameCommand.BonusPoint.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelBonuPoint", "", ref g_GameCommand.DELBONUSPOINT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelBonuPoint", ref g_GameCommand.DELBONUSPOINT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "RestBonuPoint", "", ref g_GameCommand.RESTBONUSPOINT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "RestBonuPoint", ref g_GameCommand.RESTBONUSPOINT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "FireBurn", "", ref g_GameCommand.FIREBURN.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "FireBurn", ref g_GameCommand.FIREBURN.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "TestStatus", "", ref g_GameCommand.TESTSTATUS.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "TestStatus", ref g_GameCommand.TESTSTATUS.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelGold", "", ref g_GameCommand.DELGOLD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelGold", ref g_GameCommand.DELGOLD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "AddGold", "", ref g_GameCommand.ADDGOLD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AddGold", ref g_GameCommand.ADDGOLD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelGameGold", "", ref g_GameCommand.DELGAMEGOLD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelGameGold", ref g_GameCommand.DELGAMEGOLD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "AddGamePoint", "", ref g_GameCommand.ADDGAMEGOLD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AddGameGold", ref g_GameCommand.ADDGAMEGOLD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "GameGold", "", ref g_GameCommand.GAMEGOLD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "GameGold", ref g_GameCommand.GAMEGOLD.nPermissionMin);
            // 20071226 add
            IniFile.SyncIniString(CommandConf, "Command", "GAMEDIAMOND", "", ref g_GameCommand.GAMEDIAMOND.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "GAMEDIAMOND", ref g_GameCommand.GAMEDIAMOND.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "GAMEGIRD", "", ref g_GameCommand.GAMEGIRD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "GAMEGIRD", ref g_GameCommand.GAMEGIRD.nPermissionMin);
            // 20071226 end
            // ------------------------------------------------------------------------------
            // 调整人物的荣誉值 20080511
            IniFile.SyncIniString(CommandConf, "Command", "GAMEGLORY", "", ref g_GameCommand.GAMEGLORY.sCmd);

            // ------------------------------------------------------------------------------
            // 调整英雄的忠诚度 20080109
            IniFile.SyncIniString(CommandConf, "Command", "HEROLOYAL", "", ref g_GameCommand.HEROLOYAL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "HEROLOYAL", ref g_GameCommand.HEROLOYAL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "GamePoint", "", ref g_GameCommand.GAMEPOINT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "GamePoint", ref g_GameCommand.GAMEPOINT.nPermissionMin);

            // ------------------------------------------------------------------------------
            IniFile.SyncIniString(CommandConf, "Command", "CreditPoint", "", ref g_GameCommand.CREDITPOINT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "CreditPoint", ref g_GameCommand.CREDITPOINT.nPermissionMin);
            // LoadString := CommandConf.ReadString('Command', 'TestGoldChange', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'TestGoldChange', g_GameCommand.TESTGOLDCHANGE.sCmd)
            // else g_GameCommand.TESTGOLDCHANGE.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'TestGoldChange', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'TestGoldChange', g_GameCommand.TESTGOLDCHANGE.nPermissionMin)
            // else g_GameCommand.TESTGOLDCHANGE.nPermissionMin := nLoadInteger;
            IniFile.SyncIniString(CommandConf, "Command", "RefineWeapon", "", ref g_GameCommand.REFINEWEAPON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "RefineWeapon", ref g_GameCommand.REFINEWEAPON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadAdmin", "", ref g_GameCommand.RELOADADMIN.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadAdmin", ref g_GameCommand.RELOADADMIN.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadNpc", "", ref g_GameCommand.ReLoadNpc.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadNpc", ref g_GameCommand.ReLoadNpc.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadManage", "", ref g_GameCommand.RELOADMANAGE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadManage", ref g_GameCommand.RELOADMANAGE.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadRobotManage", "", ref g_GameCommand.RELOADROBOTMANAGE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadRobotManage", ref g_GameCommand.RELOADROBOTMANAGE.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadRobot", "", ref g_GameCommand.RELOADROBOT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadRobot", ref g_GameCommand.RELOADROBOT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadMonitems", "", ref g_GameCommand.RELOADMONITEMS.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadMonitems", ref g_GameCommand.RELOADMONITEMS.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadItemDB", "", ref g_GameCommand.RELOADITEMDB.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadItemDB", ref g_GameCommand.RELOADITEMDB.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadMagicDB", "", ref g_GameCommand.RELOADMAGICDB.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadMagicDB", ref g_GameCommand.RELOADMAGICDB.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReloadMonsterDB", "", ref g_GameCommand.RELOADMONSTERDB.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReloadMonsterDB", ref g_GameCommand.RELOADMONSTERDB.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReAlive", "", ref g_GameCommand.ReAlive.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReAlive", ref g_GameCommand.ReAlive.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SysMsg", "", ref g_GameCommand.SysMsg.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SysMsg", ref g_GameCommand.SysMsg.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "HEROLEVEL", "", ref g_GameCommand.HEROLEVEL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "HEROLEVEL", ref g_GameCommand.HEROLEVEL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "AdjuestTLevel", "", ref g_GameCommand.ADJUESTLEVEL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AdjuestTLevel", ref g_GameCommand.ADJUESTLEVEL.nPermissionMin);
            // 调整英雄等级 20071227 end
            // 调整人物内功等级 20081221
            IniFile.SyncIniString(CommandConf, "Command", "NGLevel", "", ref g_GameCommand.NGLEVEL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "NGLEVEL", ref g_GameCommand.NGLEVEL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "AdjuestExp", "", ref g_GameCommand.ADJUESTEXP.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AdjuestExp", ref g_GameCommand.ADJUESTEXP.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "AddGuild", "", ref g_GameCommand.AddGuild.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AddGuild", ref g_GameCommand.AddGuild.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelGuild", "", ref g_GameCommand.DELGUILD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelGuild", ref g_GameCommand.DELGUILD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ChangeSabukLord", "", ref g_GameCommand.CHANGESABUKLORD.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeSabukLord", ref g_GameCommand.CHANGESABUKLORD.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ForcedWallConQuestWar", "", ref g_GameCommand.FORCEDWALLCONQUESTWAR.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ForcedWallConQuestWar", ref g_GameCommand.FORCEDWALLCONQUESTWAR.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'AddToItemEvent', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'AddToItemEvent', g_GameCommand.ADDTOITEMEVENT.sCmd)
            // else g_GameCommand.ADDTOITEMEVENT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'AddToItemEvent', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'AddToItemEvent', g_GameCommand.ADDTOITEMEVENT.nPermissionMin)
            // else g_GameCommand.ADDTOITEMEVENT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'AddToItemEventAspieces', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'AddToItemEventAspieces', g_GameCommand.ADDTOITEMEVENTASPIECES.sCmd)
            // else g_GameCommand.ADDTOITEMEVENTASPIECES.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'AddToItemEventAspieces', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'AddToItemEventAspieces', g_GameCommand.ADDTOITEMEVENTASPIECES.nPermissionMin)
            // else g_GameCommand.ADDTOITEMEVENTASPIECES.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ItemEventList', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ItemEventList', g_GameCommand.ItemEventList.sCmd)
            // else g_GameCommand.ItemEventList.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ItemEventList', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ItemEventList', g_GameCommand.ItemEventList.nPermissionMin)
            // else g_GameCommand.ItemEventList.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'StartIngGiftNO', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'StartIngGiftNO', g_GameCommand.STARTINGGIFTNO.sCmd)
            // else g_GameCommand.STARTINGGIFTNO.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'StartIngGiftNO', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'StartIngGiftNO', g_GameCommand.STARTINGGIFTNO.nPermissionMin)
            // else g_GameCommand.STARTINGGIFTNO.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'DeleteAllItemEvent', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'DeleteAllItemEvent', g_GameCommand.DELETEALLITEMEVENT.sCmd)
            // else g_GameCommand.DELETEALLITEMEVENT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'DeleteAllItemEvent', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'DeleteAllItemEvent', g_GameCommand.DELETEALLITEMEVENT.nPermissionMin)
            // else g_GameCommand.DELETEALLITEMEVENT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'StartItemEvent', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'StartItemEvent', g_GameCommand.STARTITEMEVENT.sCmd)
            // else g_GameCommand.STARTITEMEVENT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'StartItemEvent', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'StartItemEvent', g_GameCommand.STARTITEMEVENT.nPermissionMin)
            // else g_GameCommand.STARTITEMEVENT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ItemEventTerm', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ItemEventTerm', g_GameCommand.ITEMEVENTTERM.sCmd)
            // else g_GameCommand.ITEMEVENTTERM.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ItemEventTerm', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ItemEventTerm', g_GameCommand.ITEMEVENTTERM.nPermissionMin)
            // else g_GameCommand.ITEMEVENTTERM.nPermissionMin := nLoadInteger;

            IniFile.SyncIniString(CommandConf, "Command", "AdjuestTestLevel", "", ref g_GameCommand.ADJUESTTESTLEVEL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AdjuestTestLevel", ref g_GameCommand.ADJUESTTESTLEVEL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "OpTraining", "", ref g_GameCommand.TRAININGSKILL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "OpTraining", ref g_GameCommand.TRAININGSKILL.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'OpDeleteSkill', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'OpDeleteSkill', g_GameCommand.OPDELETESKILL.sCmd)
            // else g_GameCommand.OPDELETESKILL.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'OpDeleteSkill', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'OpDeleteSkill', g_GameCommand.OPDELETESKILL.nPermissionMin)
            // else g_GameCommand.OPDELETESKILL.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ChangeWeaponDura', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ChangeWeaponDura', g_GameCommand.CHANGEWEAPONDURA.sCmd)
            // else g_GameCommand.CHANGEWEAPONDURA.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ChangeWeaponDura', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ChangeWeaponDura', g_GameCommand.CHANGEWEAPONDURA.nPermissionMin)
            // else g_GameCommand.CHANGEWEAPONDURA.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ReloadGuildAll', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ReloadGuildAll', g_GameCommand.RELOADGUILDALL.sCmd)
            // else g_GameCommand.RELOADGUILDALL.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ReloadGuildAll', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ReloadGuildAll', g_GameCommand.RELOADGUILDALL.nPermissionMin)
            // else g_GameCommand.RELOADGUILDALL.nPermissionMin := nLoadInteger;
            IniFile.SyncIniString(CommandConf, "Command", "Who", "", ref g_GameCommand.WHO.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Who", ref g_GameCommand.WHO.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "Total", "", ref g_GameCommand.TOTAL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "Total", ref g_GameCommand.TOTAL.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'TestGa', '');//20081014 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'TestGa', g_GameCommand.TESTGA.sCmd)
            // else g_GameCommand.TESTGA.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'TestGa', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'TestGa', g_GameCommand.TESTGA.nPermissionMin)
            // else g_GameCommand.TESTGA.nPermissionMin := nLoadInteger;

            IniFile.SyncIniString(CommandConf, "Command", "MapInfo", "", ref g_GameCommand.MAPINFO.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "MapInfo", ref g_GameCommand.MAPINFO.nPermissionMin);

            // LoadString := CommandConf.ReadString('Command', 'SbkDoor', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'SbkDoor', g_GameCommand.SBKDOOR.sCmd)
            // else g_GameCommand.SBKDOOR.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'SbkDoor', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'SbkDoor', g_GameCommand.SBKDOOR.nPermissionMin)
            // else g_GameCommand.SBKDOOR.nPermissionMin := nLoadInteger;
            IniFile.SyncIniString(CommandConf, "Command", "ChangeDearName", "", ref g_GameCommand.CHANGEDEARNAME.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeDearName", ref g_GameCommand.CHANGEDEARNAME.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ChangeMasterName", "", ref g_GameCommand.CHANGEMASTERNAME.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ChangeMasterName", ref g_GameCommand.CHANGEMASTERNAME.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "StartQuest", "", ref g_GameCommand.STARTQUEST.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "StartQuest", ref g_GameCommand.STARTQUEST.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SetPermission", "", ref g_GameCommand.SETPERMISSION.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SetPermission", ref g_GameCommand.SETPERMISSION.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ClearMon", "", ref g_GameCommand.CLEARMON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ClearMon", ref g_GameCommand.CLEARMON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ReNewLevel", "", ref g_GameCommand.RENEWLEVEL.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ReNewLevel", ref g_GameCommand.RENEWLEVEL.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DenyIPaddrLogon", "", ref g_GameCommand.DENYIPLOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DenyIPaddrLogon", ref g_GameCommand.DENYIPLOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DenyAccountLogon", "", ref g_GameCommand.DENYACCOUNTLOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DenyAccountLogon", ref g_GameCommand.DENYACCOUNTLOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DenyCharNameLogon", "", ref g_GameCommand.DENYCHARNAMELOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DenyCharNameLogon", ref g_GameCommand.DENYCHARNAMELOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelDenyIPLogon", "", ref g_GameCommand.DELDENYIPLOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelDenyIPLogon", ref g_GameCommand.DELDENYIPLOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelDenyAccountLogon", "", ref g_GameCommand.DELDENYACCOUNTLOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelDenyAccountLogon", ref g_GameCommand.DELDENYACCOUNTLOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "DelDenyCharNameLogon", "", ref g_GameCommand.DELDENYCHARNAMELOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "DelDenyCharNameLogon", ref g_GameCommand.DELDENYCHARNAMELOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ShowDenyIPLogon", "", ref g_GameCommand.SHOWDENYIPLOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ShowDenyIPLogon", ref g_GameCommand.SHOWDENYIPLOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ShowDenyAccountLogon", "", ref g_GameCommand.SHOWDENYACCOUNTLOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ShowDenyAccountLogon", ref g_GameCommand.SHOWDENYACCOUNTLOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ShowDenyCharNameLogon", "", ref g_GameCommand.SHOWDENYCHARNAMELOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ShowDenyCharNameLogon", ref g_GameCommand.SHOWDENYCHARNAMELOGON.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ViewWhisper", "", ref g_GameCommand.VIEWWHISPER.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ViewWhisper", ref g_GameCommand.VIEWWHISPER.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SpiritStart", "", ref g_GameCommand.SPIRIT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SpiritStart", ref g_GameCommand.SPIRIT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SpiritStop", "", ref g_GameCommand.SPIRITSTOP.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SpiritStop", ref g_GameCommand.SPIRITSTOP.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SetMapMode", "", ref g_GameCommand.SetMapMode.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SetMapMode", ref g_GameCommand.SetMapMode.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ShoweMapMode", "", ref g_GameCommand.SHOWMAPMODE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ShoweMapMode", ref g_GameCommand.SHOWMAPMODE.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ClearBag", "", ref g_GameCommand.CLEARBAG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ClearBag", ref g_GameCommand.CLEARBAG.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "RemoteMsg", "", ref g_GameCommand.REMTEMSG.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "RemoteMsg", ref g_GameCommand.REMTEMSG.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "ColorSay", "", ref g_GameCommand.COLORSAY.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "ColorSay", ref g_GameCommand.COLORSAY.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SETCOLORSAY", "", ref g_GameCommand.SETCOLORSAY.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SETCOLORSAY", ref g_GameCommand.SETCOLORSAY.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "AllowReAlive", "", ref g_GameCommand.AllowReAlive.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "AllowReAlive", ref g_GameCommand.AllowReAlive.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "USERITEM", "", ref g_GameCommand.UserItem.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "USERITEM", ref g_GameCommand.UserItem.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SIGNMOVE", "", ref g_GameCommand.SIGNMOVE.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SIGNMOVE", ref g_GameCommand.SIGNMOVE.nPermissionMin);
            // 20080816 清理指定玩家复制品
            IniFile.SyncIniString(CommandConf, "Command", "CLEARCOPYITEM", "", ref g_GameCommand.CLEARCOPYITEM.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "CLEARCOPYITEM", ref g_GameCommand.CLEARCOPYITEM.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "SHOWEFFECT", "", ref g_GameCommand.SHOWEFFECT.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "SHOWEFFECT", ref g_GameCommand.SHOWEFFECT.nPermissionMin);
            IniFile.SyncIniString(CommandConf, "Command", "LockLogin", "", ref g_GameCommand.LOCKLOGON.sCmd);
            IniFile.SyncIniInt(CommandConf, "Permission", "LockLogin", ref g_GameCommand.LOCKLOGON.nPermissionMin);

            LoadString = CommandConf.ReadString("Command", "GMRedMsgCmd", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GMRedMsgCmd", g_GMRedMsgCmd.ToString());
            }
            else
            {
                g_GMRedMsgCmd = LoadString[0];
            }

            IniFile.SyncIniInt(CommandConf, "Permission", "GMRedMsgCmd", ref g_nGMREDMSGCMD);

        }

        /// <summary>
        /// 加载游戏文字提示信息
        /// </summary>
        public static void LoadString()
        {
            //整体逻辑：
            //如果文件信息中的配置为空，那么就启用GameMsgDef中的预定义消息，如果文件中的配置信息不为空，那么就把GameMsgDef中的信息用配置文件来重置。
            IniFile.SyncIniString(StringConf, "String", "CrsHitOn", "", ref GameMsgDef.sCrsHitOn);
            IniFile.SyncIniString(StringConf, "String", "CrsHitOff", "", ref GameMsgDef.sCrsHitOff);
            IniFile.SyncIniString(StringConf, "String", "TwinSkillSummoned2", "", ref GameMsgDef.sSkill43On);
            IniFile.SyncIniString(StringConf, "String", "TwinSkillsFail2", "", ref GameMsgDef.sSkill43Off);
            IniFile.SyncIniString(StringConf, "String", "KTZSpiritsSummoned", "", ref GameMsgDef.sSkill42On);
            IniFile.SyncIniString(StringConf, "String", "KTZSpiritsGone", "", ref GameMsgDef.sSkill42Off);

            IniFile.SyncIniString(StringConf, "String", "ClientSoftVersionError", "", ref GameMsgDef.sClientSoftVersionError);
            IniFile.SyncIniString(StringConf, "String", "DownLoadNewClientSoft", "", ref GameMsgDef.sDownLoadNewClientSoft);
            IniFile.SyncIniString(StringConf, "String", "ForceDisConnect", "", ref GameMsgDef.sForceDisConnect);
            IniFile.SyncIniString(StringConf, "String", "ClientSoftVersionTooOld", "", ref GameMsgDef.sClientSoftVersionTooOld);
            IniFile.SyncIniString(StringConf, "String", "DownLoadAndUseNewClient", "", ref GameMsgDef.sDownLoadAndUseNewClient);
            IniFile.SyncIniString(StringConf, "String", "OnlineUserFull", "", ref GameMsgDef.sOnlineUserFull);
            IniFile.SyncIniString(StringConf, "String", "YouNowIsTryPlayMode", "", ref GameMsgDef.sYouNowIsTryPlayMode);
            IniFile.SyncIniString(StringConf, "String", "NowIsFreePlayMode", "", ref GameMsgDef.g_sNowIsFreePlayMode);
            IniFile.SyncIniString(StringConf, "String", "AttackModeOfDear", "", ref GameMsgDef.sAttackModeOfDear);
            IniFile.SyncIniString(StringConf, "String", "AttackModeOfMaster", "", ref GameMsgDef.sAttackModeOfMaster);
            IniFile.SyncIniString(StringConf, "String", "AttackModeOfAll", "", ref GameMsgDef.sAttackModeOfAll);
            IniFile.SyncIniString(StringConf, "String", "AttackModeOfPeaceful", "", ref GameMsgDef.sAttackModeOfPeaceful);
            IniFile.SyncIniString(StringConf, "String", "AttackModeOfGroup", "", ref GameMsgDef.sAttackModeOfGroup);
            IniFile.SyncIniString(StringConf, "String", "AttackModeOfGuild", "", ref GameMsgDef.sAttackModeOfGuild);
            IniFile.SyncIniString(StringConf, "String", "AttackModeOfRedWhite", "", ref GameMsgDef.sAttackModeOfRedWhite);
            IniFile.SyncIniString(StringConf, "String", "StartChangeAttackModeHelp", "", ref GameMsgDef.sStartChangeAttackModeHelp);
            IniFile.SyncIniString(StringConf, "String", "StartNoticeMsg", "", ref GameMsgDef.sStartNoticeMsg);
            IniFile.SyncIniString(StringConf, "String", "ThrustingOn", "", ref GameMsgDef.sThrustingOn);
            IniFile.SyncIniString(StringConf, "String", "ThrustingOff", "", ref GameMsgDef.sThrustingOff);
            IniFile.SyncIniString(StringConf, "String", "HalfMoonOn", "", ref GameMsgDef.sHalfMoonOn);
            IniFile.SyncIniString(StringConf, "String", "HalfMoonOff", "", ref GameMsgDef.sHalfMoonOff);
            IniFile.SyncIniString(StringConf, "String", "FireSpiritsSummoned", "", ref GameMsgDef.sFireSpiritsSummoned);
            IniFile.SyncIniString(StringConf, "String", "FireSpiritsFail", "", ref GameMsgDef.sFireSpiritsFail);
            IniFile.SyncIniString(StringConf, "String", "SpiritsGone", "", ref GameMsgDef.sSpiritsGone);
            IniFile.SyncIniString(StringConf, "String", "DailySkillSummoned", "", ref GameMsgDef.sDailySkillSummoned);
            IniFile.SyncIniString(StringConf, "String", "DailySkillFail", "", ref GameMsgDef.sDailySkillFail);
            IniFile.SyncIniString(StringConf, "String", "DailySpiritsGone", "", ref GameMsgDef.sDailySpiritsGone);
            IniFile.SyncIniString(StringConf, "String", "MateDoTooweak", "", ref GameMsgDef.sMateDoTooweak);
            IniFile.SyncIniString(StringConf, "String", "TheWeaponBroke", "", ref GameMsgDef.g_sTheWeaponBroke);
            IniFile.SyncIniString(StringConf, "String", "TheWeaponRefineSuccessfull", "", ref GameMsgDef.sTheWeaponRefineSuccessfull);
            IniFile.SyncIniString(StringConf, "String", "YouPoisoned", "", ref GameMsgDef.sYouPoisoned);
            IniFile.SyncIniString(StringConf, "String", "YouPoisonedSpider", "", ref GameMsgDef.sYouPoisonedSpider);
            IniFile.SyncIniString(StringConf, "String", "GetSellOffGlod", "", ref GameMsgDef.sGetSellOffGlod);
            IniFile.SyncIniString(StringConf, "String", "ButchEnoughBagHintMsg", "", ref GameMsgDef.sButchEnoughBagHintMsg);
            IniFile.SyncIniString(StringConf, "String", "HumLevelOrderDropMsg", "", ref GameMsgDef.sHumLevelOrderDropMsg);
            IniFile.SyncIniString(StringConf, "String", "RefineItemSuccess", "", ref GameMsgDef.sRefineItemSuccessMsg);
            IniFile.SyncIniString(StringConf, "String", "RefineItemFail", "", ref GameMsgDef.sRefineItemFailMsg);
            IniFile.SyncIniString(StringConf, "String", "RefineItemError", "", ref GameMsgDef.sRefineItemErrorMsg);
            IniFile.SyncIniString(StringConf, "String", "NeedLevelToXYErrorMsg", "", ref GameMsgDef.sNEEDLEVELToXYErrorMsg);
            IniFile.SyncIniString(StringConf, "String", "PetRest", "", ref GameMsgDef.sPetRest);
            IniFile.SyncIniString(StringConf, "String", "PetAttack", "", ref GameMsgDef.sPetAttack);
            IniFile.SyncIniString(StringConf, "String", "WearNotOfWoMan", "", ref GameMsgDef.sWearNotOfWoMan);
            IniFile.SyncIniString(StringConf, "String", "WearNotOfMan", "", ref GameMsgDef.sWearNotOfMan);
            IniFile.SyncIniString(StringConf, "String", "HandWeightNot", "", ref GameMsgDef.sHandWeightNot);
            IniFile.SyncIniString(StringConf, "String", "WearWeightNot", "", ref GameMsgDef.sWearWeightNot);
            IniFile.SyncIniString(StringConf, "String", "ItemIsNotThisAccount", "", ref GameMsgDef.g_sItemIsNotThisAccount);
            IniFile.SyncIniString(StringConf, "String", "ItemIsNotThisIPaddr", "", ref GameMsgDef.g_sItemIsNotThisIPaddr);
            IniFile.SyncIniString(StringConf, "String", "ItemIsNotThisCharName", "", ref GameMsgDef.g_sItemIsNotThisCharName);
            IniFile.SyncIniString(StringConf, "String", "LevelNot", "", ref GameMsgDef.g_sLevelNot);
            IniFile.SyncIniString(StringConf, "String", "JobOrLevelNot", "", ref GameMsgDef.g_sJobOrLevelNot);
            IniFile.SyncIniString(StringConf, "String", "JobOrDCNot", "", ref GameMsgDef.g_sJobOrDCNot);
            IniFile.SyncIniString(StringConf, "String", "JobOrMCNot", "", ref GameMsgDef.g_sJobOrMCNot);
            IniFile.SyncIniString(StringConf, "String", "JobOrSCNot", "", ref GameMsgDef.g_sJobOrSCNot);
            IniFile.SyncIniString(StringConf, "String", "DCNot", "", ref GameMsgDef.g_sDCNot);
            IniFile.SyncIniString(StringConf, "String", "MCNot", "", ref GameMsgDef.g_sMCNot);
            IniFile.SyncIniString(StringConf, "String", "SCNot", "", ref GameMsgDef.g_sSCNot);
            IniFile.SyncIniString(StringConf, "String", "CreditPointNot", "", ref GameMsgDef.g_sCreditPointNot);
            IniFile.SyncIniString(StringConf, "String", "ReNewLevelNot", "", ref GameMsgDef.g_sReNewLevelNot);
            IniFile.SyncIniString(StringConf, "String", "GuildNot", "", ref GameMsgDef.g_sGuildNot);
            IniFile.SyncIniString(StringConf, "String", "GuildMasterNot", "", ref GameMsgDef.g_sGuildMasterNot);
            IniFile.SyncIniString(StringConf, "String", "SabukHumanNot", "", ref GameMsgDef.g_sSabukHumanNot);
            IniFile.SyncIniString(StringConf, "String", "SabukMasterManNot", "", ref GameMsgDef.g_sSabukMasterManNot);
            IniFile.SyncIniString(StringConf, "String", "MemberNot", "", ref GameMsgDef.g_sMemberNot);
            IniFile.SyncIniString(StringConf, "String", "MemberTypeNot", "", ref GameMsgDef.g_sMemberTypeNot);
            IniFile.SyncIniString(StringConf, "String", "CanottWearIt", "", ref GameMsgDef.g_sCanottWearIt);
            IniFile.SyncIniString(StringConf, "String", "CanotUseDrugOnThisMap", "", ref GameMsgDef.sCanotUseDrugOnThisMap);
            IniFile.SyncIniString(StringConf, "String", "GameMasterMode", "", ref GameMsgDef.sGameMasterMode);
            IniFile.SyncIniString(StringConf, "String", "ReleaseGameMasterMode", "", ref GameMsgDef.sReleaseGameMasterMode);
            IniFile.SyncIniString(StringConf, "String", "ObserverMode", "", ref GameMsgDef.sObserverMode);
            IniFile.SyncIniString(StringConf, "String", "ReleaseObserverMode", "", ref GameMsgDef.g_sReleaseObserverMode);
            IniFile.SyncIniString(StringConf, "String", "SupermanMode", "", ref GameMsgDef.sSupermanMode);
            IniFile.SyncIniString(StringConf, "String", "ReleaseSupermanMode", "", ref GameMsgDef.sReleaseSupermanMode);
            IniFile.SyncIniString(StringConf, "String", "YouFoundNothing", "", ref GameMsgDef.sYouFoundNothing);
            IniFile.SyncIniString(StringConf, "String", "LineNoticePreFix", "", ref g_Config.sLineNoticePreFix);
            IniFile.SyncIniString(StringConf, "String", "SysMsgPreFix", "", ref g_Config.sSysMsgPreFix);
            IniFile.SyncIniString(StringConf, "String", "GuildMsgPreFix", "", ref g_Config.sGuildMsgPreFix);
            IniFile.SyncIniString(StringConf, "String", "GroupMsgPreFix", "", ref g_Config.sGroupMsgPreFix);
            IniFile.SyncIniString(StringConf, "String", "HintMsgPreFix", "", ref g_Config.sHintMsgPreFix);
            IniFile.SyncIniString(StringConf, "String", "GMRedMsgpreFix", "", ref g_Config.sGMRedMsgpreFix);
            IniFile.SyncIniString(StringConf, "String", "MonSayMsgpreFix", "", ref g_Config.sMonSayMsgpreFix);
            IniFile.SyncIniString(StringConf, "String", "CustMsgpreFix", "", ref g_Config.sCustMsgpreFix);
            IniFile.SyncIniString(StringConf, "String", "CastleMsgpreFix", "", ref g_Config.sCastleMsgpreFix);
            IniFile.SyncIniString(StringConf, "String", "NoPasswordLockSystemMsg", "", ref GameMsgDef.g_sNoPasswordLockSystemMsg);
            IniFile.SyncIniString(StringConf, "String", "AlreadySetPassword", "", ref GameMsgDef.g_sAlreadySetPasswordMsg);
            IniFile.SyncIniString(StringConf, "String", "ReSetPassword", "", ref GameMsgDef.g_sReSetPasswordMsg);
            IniFile.SyncIniString(StringConf, "String", "PasswordOverLong", "", ref GameMsgDef.g_sPasswordOverLongMsg);
            IniFile.SyncIniString(StringConf, "String", "ReSetPasswordOK", "", ref GameMsgDef.g_sReSetPasswordOKMsg);
            IniFile.SyncIniString(StringConf, "String", "ReSetPasswordNotMatch", "", ref GameMsgDef.g_sReSetPasswordNotMatchMsg);
            IniFile.SyncIniString(StringConf, "String", "PleaseInputUnLockPassword", "", ref GameMsgDef.g_sPleaseInputUnLockPasswordMsg);
            IniFile.SyncIniString(StringConf, "String", "StorageUnLockOK", "", ref GameMsgDef.g_sStorageUnLockOKMsg);
            IniFile.SyncIniString(StringConf, "String", "StorageAlreadyUnLock", "", ref GameMsgDef.g_sStorageAlreadyUnLockMsg);
            IniFile.SyncIniString(StringConf, "String", "StorageNoPassword", "", ref GameMsgDef.g_sStorageNoPasswordMsg);
            IniFile.SyncIniString(StringConf, "String", "UnLockPasswordFail", "", ref GameMsgDef.g_sUnLockPasswordFailMsg);
            IniFile.SyncIniString(StringConf, "String", "LockStorageSuccess", "", ref GameMsgDef.g_sLockStorageSuccessMsg);
            IniFile.SyncIniString(StringConf, "String", "StoragePasswordClearMsg", "", ref GameMsgDef.g_sStoragePasswordClearMsg);
            IniFile.SyncIniString(StringConf, "String", "PleaseUnloadStoragePasswordMsg", "", ref GameMsgDef.g_sPleaseUnloadStoragePasswordMsg);
            IniFile.SyncIniString(StringConf, "String", "StorageAlreadyLock", "", ref GameMsgDef.g_sStorageAlreadyLockMsg);
            IniFile.SyncIniString(StringConf, "String", "StoragePasswordLocked", "", ref GameMsgDef.g_sStoragePasswordLockedMsg);
            IniFile.SyncIniString(StringConf, "String", "StorageSetPassword", "", ref GameMsgDef.g_sSetPasswordMsg);
            IniFile.SyncIniString(StringConf, "String", "PleaseInputOldPassword", "", ref GameMsgDef.g_sPleaseInputOldPasswordMsg);
            IniFile.SyncIniString(StringConf, "String", "PasswordIsClearMsg", "", ref GameMsgDef.g_sOldPasswordIsClearMsg);
            IniFile.SyncIniString(StringConf, "String", "NoPasswordSet", "", ref GameMsgDef.g_sNoPasswordSetMsg);
            IniFile.SyncIniString(StringConf, "String", "OldPasswordIncorrect", "", ref GameMsgDef.g_sOldPasswordIncorrectMsg);
            IniFile.SyncIniString(StringConf, "String", "StorageIsLocked", "", ref GameMsgDef.g_sStorageIsLockedMsg);
            IniFile.SyncIniString(StringConf, "String", "PleaseTryDealLaterMsg", "", ref GameMsgDef.g_sPleaseTryDealLaterMsg);
            IniFile.SyncIniString(StringConf, "String", "DealItemsDenyGetBackMsg", "", ref GameMsgDef.g_sDealItemsDenyGetBackMsg);
            IniFile.SyncIniString(StringConf, "String", "DisableDealItemsMsg", "", ref GameMsgDef.g_sDisableDealItemsMsg);
            IniFile.SyncIniString(StringConf, "String", "CanotTryDealMsg", "", ref GameMsgDef.g_sCanotTryDealMsg);
            IniFile.SyncIniString(StringConf, "String", "DealActionCancelMsg", "", ref GameMsgDef.g_sDealActionCancelMsg);
            IniFile.SyncIniString(StringConf, "String", "PoseDisableDealMsg", "", ref GameMsgDef.g_sPoseDisableDealMsg);
            IniFile.SyncIniString(StringConf, "String", "DealSuccessMsg", "", ref GameMsgDef.g_sDealSuccessMsg);
            IniFile.SyncIniString(StringConf, "String", "DealOKTooFast", "", ref GameMsgDef.g_sDealOKTooFast);
            IniFile.SyncIniString(StringConf, "String", "YourBagSizeTooSmall", "", ref GameMsgDef.g_sYourBagSizeTooSmall);
            IniFile.SyncIniString(StringConf, "String", "DealHumanBagSizeTooSmall", "", ref GameMsgDef.g_sDealHumanBagSizeTooSmall);
            IniFile.SyncIniString(StringConf, "String", "YourGoldLargeThenLimit", "", ref GameMsgDef.g_sYourGoldLargeThenLimit);
            IniFile.SyncIniString(StringConf, "String", "DealHumanGoldLargeThenLimit", "", ref GameMsgDef.g_sDealHumanGoldLargeThenLimit);
            IniFile.SyncIniString(StringConf, "String", "YouDealOKMsg", "", ref GameMsgDef.g_sYouDealOKMsg);
            IniFile.SyncIniString(StringConf, "String", "PoseDealOKMsg", "", ref GameMsgDef.g_sPoseDealOKMsg);
            IniFile.SyncIniString(StringConf, "String", "KickClientUserMsg", "", ref GameMsgDef.g_sKickClientUserMsg);
            IniFile.SyncIniString(StringConf, "String", "ActionIsLockedMsg", "", ref GameMsgDef.g_sActionIsLockedMsg);
            IniFile.SyncIniString(StringConf, "String", "PasswordNotSetMsg", "", ref GameMsgDef.g_sPasswordNotSetMsg);
            IniFile.SyncIniString(StringConf, "String", "CallHeroTime", "", ref GameMsgDef.g_sRecallHeroHint);
            IniFile.SyncIniString(StringConf, "String", "NotHero", "", ref GameMsgDef.g_sNotHero);
            IniFile.SyncIniString(StringConf, "String", "OpenShieldMsg", "", ref GameMsgDef.g_sOpenShieldMsg);
            IniFile.SyncIniString(StringConf, "String", "OpenShieldTickMsg", "", ref GameMsgDef.g_sOpenShieldTickMsg);
            IniFile.SyncIniString(StringConf, "String", "ButchItemHintMsg", "", ref GameMsgDef.g_sButchItemHintMsg);
            IniFile.SyncIniString(StringConf, "String", "BoxsItemHintMsg", "", ref GameMsgDef.g_sBoxsItemHintMsg);
            IniFile.SyncIniString(StringConf, "String", "ItmeDropHintMsg", "", ref GameMsgDef.g_sItmeDropHintMsg);
            IniFile.SyncIniString(StringConf, "String", "JiujinOverHintMsg", "", ref GameMsgDef.g_sJiujinOverHintMsg);
            IniFile.SyncIniString(StringConf, "String", "UpAlcoholHintMsg", "", ref GameMsgDef.g_sUpAlcoholHintMsg);
            #region 挑战提示
            IniFile.SyncIniString(StringConf, "String", "ChallengeWinMsg", "", ref GameMsgDef.g_sChallengeWinMsg);
            IniFile.SyncIniString(StringConf, "String", "ChallengeLoseMsg", "", ref GameMsgDef.g_sChallengeLoseMsg);
            IniFile.SyncIniString(StringConf, "String", "PleaseTryChallengeLaterMsg", "", ref GameMsgDef.g_sPleaseTryChallengeLaterMsg);
            IniFile.SyncIniString(StringConf, "String", "ChallengeActionCancelMsg", "", ref GameMsgDef.g_sChallengeActionCancelMsg);
            IniFile.SyncIniString(StringConf, "String", "ChallengeItemsDenyGetBackMsg", "", ref GameMsgDef.g_sChallengeItemsDenyGetBackMsg);
            IniFile.SyncIniString(StringConf, "String", "ChallengeOKTooFast", "", ref GameMsgDef.g_sChallengeOKTooFast);
            IniFile.SyncIniString(StringConf, "String", "ChallengeYourBagSizeTooSmall", "", ref GameMsgDef.g_sChallengeYourBagSizeTooSmall);
            IniFile.SyncIniString(StringConf, "String", "ChallengeYourGoldLargeThenLimit", "", ref GameMsgDef.g_sChallengeYourGoldLargeThenLimit);
            IniFile.SyncIniString(StringConf, "String", "ChallengeHumanBagSizeTooSmall", "", ref GameMsgDef.g_sChallengeHumanBagSizeTooSmall);
            IniFile.SyncIniString(StringConf, "String", "ChallengeHumanGoldLargeThenLimit", "", ref GameMsgDef.g_sChallengeHumanGoldLargeThenLimit);
            IniFile.SyncIniString(StringConf, "String", "YouChallengeOKMsg", "", ref GameMsgDef.g_sYouChallengeOKMsg);
            IniFile.SyncIniString(StringConf, "String", "PoseChallengeOKMsg", "", ref GameMsgDef.g_sPoseChallengeOKMsg);
            IniFile.SyncIniString(StringConf, "String", "ChallengeTimeOverMsg", "", ref GameMsgDef.g_sChallengeTimeOverMsg);
            #endregion
            IniFile.SyncIniString(StringConf, "String", "PickUpItemHintMsg", "", ref GameMsgDef.g_sPickUpItemHintMsg);
            IniFile.SyncIniString(StringConf, "String", "ShieldTimeDisappearMsg", "", ref GameMsgDef.g_sShieldTimeDisappearMsg);
            IniFile.SyncIniString(StringConf, "String", "OpenShieldOKMsg", "", ref GameMsgDef.g_sOpenShieldOKMsg);
            IniFile.SyncIniString(StringConf, "String", "HeroHit", "", ref GameMsgDef.g_sHeroLoginMsg);
            IniFile.SyncIniString(StringConf, "String", "HeroProtect", "", ref GameMsgDef.g_sHeroProtect);
            IniFile.SyncIniString(StringConf, "String", "HeroNotProtect", "", ref GameMsgDef.g_sHeroNotProtect);
            IniFile.SyncIniString(StringConf, "String", "HeroClose", "", ref GameMsgDef.g_sHeroClose);
            IniFile.SyncIniString(StringConf, "String", "HeroRest", "", ref GameMsgDef.g_sHeroRest);
            IniFile.SyncIniString(StringConf, "String", "HeroAttack", "", ref GameMsgDef.g_sHeroAttack);
            IniFile.SyncIniString(StringConf, "String", "HeroFollow", "", ref GameMsgDef.g_sHeroFollow);
            IniFile.SyncIniString(StringConf, "String", "NotPasswordProtectMode", "", ref GameMsgDef.g_sNotPasswordProtectMode);
            IniFile.SyncIniString(StringConf, "String", "CanotDropGoldMsg", "", ref GameMsgDef.g_sCanotDropGoldMsg);
            IniFile.SyncIniString(StringConf, "String", "CanotDropInSafeZoneMsg", "", ref GameMsgDef.g_sCanotDropInSafeZoneMsg);
            IniFile.SyncIniString(StringConf, "String", "CanotDropItemMsg", "", ref GameMsgDef.g_sCanotDropItemMsg);
            IniFile.SyncIniString(StringConf, "String", "CanotUseItemMsg", "", ref GameMsgDef.g_sCanotUseItemMsg);
            IniFile.SyncIniString(StringConf, "String", "StartMarryManMsg", "", ref GameMsgDef.g_sStartMarryManMsg);
            IniFile.SyncIniString(StringConf, "String", "StartMarryWoManMsg", "", ref GameMsgDef.g_sStartMarryWoManMsg);
            IniFile.SyncIniString(StringConf, "String", "StartMarryManAskQuestionMsg", "", ref GameMsgDef.g_sStartMarryManAskQuestionMsg);
            IniFile.SyncIniString(StringConf, "String", "StartMarryWoManAskQuestionMsg", "", ref GameMsgDef.g_sStartMarryWoManAskQuestionMsg);
            IniFile.SyncIniString(StringConf, "String", "MarryManAnswerQuestionMsg", "", ref GameMsgDef.g_sMarryManAnswerQuestionMsg);
            IniFile.SyncIniString(StringConf, "String", "MarryManAskQuestionMsg", "", ref GameMsgDef.g_sMarryManAskQuestionMsg);
            IniFile.SyncIniString(StringConf, "String", "MarryWoManAnswerQuestionMsg", "", ref GameMsgDef.g_sMarryWoManAnswerQuestionMsg);
            IniFile.SyncIniString(StringConf, "String", "MarryWoManGetMarryMsg", "", ref GameMsgDef.g_sMarryWoManGetMarryMsg);
            IniFile.SyncIniString(StringConf, "String", "MarryWoManDenyMsg", "", ref GameMsgDef.g_sMarryWoManDenyMsg);
            IniFile.SyncIniString(StringConf, "String", "MarryWoManCancelMsg", "", ref GameMsgDef.g_sMarryWoManCancelMsg);
            IniFile.SyncIniString(StringConf, "String", "ForceUnMarryManLoginMsg", "", ref GameMsgDef.g_sfUnMarryManLoginMsg);
            IniFile.SyncIniString(StringConf, "String", "ForceUnMarryWoManLoginMsg", "", ref GameMsgDef.g_sfUnMarryWoManLoginMsg);
            IniFile.SyncIniString(StringConf, "String", "ManLoginDearOnlineSelfMsg", "", ref GameMsgDef.g_sManLoginDearOnlineSelfMsg);
            IniFile.SyncIniString(StringConf, "String", "ManLoginDearOnlineDearMsg", "", ref GameMsgDef.g_sManLoginDearOnlineDearMsg);
            IniFile.SyncIniString(StringConf, "String", "WoManLoginDearOnlineSelfMsg", "", ref GameMsgDef.g_sWoManLoginDearOnlineSelfMsg);
            IniFile.SyncIniString(StringConf, "String", "WoManLoginDearOnlineDearMsg", "", ref GameMsgDef.g_sWoManLoginDearOnlineDearMsg);
            IniFile.SyncIniString(StringConf, "String", "ManLoginDearNotOnlineMsg", "", ref GameMsgDef.g_sManLoginDearNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "WoManLoginDearNotOnlineMsg", "", ref GameMsgDef.g_sWoManLoginDearNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "ManLongOutDearOnlineMsg", "", ref GameMsgDef.g_sManLongOutDearOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "WoManLongOutDearOnlineMsg", "", ref GameMsgDef.g_sWoManLongOutDearOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "YouAreNotMarryedMsg", "", ref GameMsgDef.g_sYouAreNotMarryedMsg);
            IniFile.SyncIniString(StringConf, "String", "YourWifeNotOnlineMsg", "", ref GameMsgDef.g_sYourWifeNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "YourHusbandNotOnlineMsg", "", ref GameMsgDef.g_sYourHusbandNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "YourWifeNowLocateMsg", "", ref GameMsgDef.g_sYourWifeNowLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "YourHusbandSearchLocateMsg", "", ref GameMsgDef.g_sYourHusbandSearchLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "YourHusbandNowLocateMsg", "", ref GameMsgDef.g_sYourHusbandNowLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "YourWifeSearchLocateMsg", "", ref GameMsgDef.g_sYourWifeSearchLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "FUnMasterLoginMsg", "", ref GameMsgDef.g_sfUnMasterLoginMsg);
            IniFile.SyncIniString(StringConf, "String", "UnMasterListLoginMsg", "", ref GameMsgDef.g_sfUnMasterListLoginMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterListOnlineSelfMsg", "", ref GameMsgDef.g_sMasterListOnlineSelfMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterListOnlineMasterMsg", "", ref GameMsgDef.g_sMasterListOnlineMasterMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterOnlineSelfMsg", "", ref GameMsgDef.g_sMasterOnlineSelfMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterOnlineMasterListMsg", "", ref GameMsgDef.g_sMasterOnlineMasterListMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterLongOutMasterListOnlineMsg", "", ref GameMsgDef.g_sMasterLongOutMasterListOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterListLongOutMasterOnlineMsg", "", ref GameMsgDef.g_sMasterListLongOutMasterOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterListNotOnlineMsg", "", ref GameMsgDef.g_sMasterListNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "MasterNotOnlineMsg", "", ref GameMsgDef.g_sMasterNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "YouAreNotMasterMsg", "", ref GameMsgDef.g_sYouAreNotMasterMsg);
            IniFile.SyncIniString(StringConf, "String", "YourMasterNotOnlineMsg", "", ref GameMsgDef.g_sYourMasterNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "YourMasterListNotOnlineMsg", "", ref GameMsgDef.g_sYourMasterListNotOnlineMsg);
            IniFile.SyncIniString(StringConf, "String", "YourMasterNowLocateMsg", "", ref GameMsgDef.g_sYourMasterNowLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "YourMasterListSearchLocateMsg", "", ref GameMsgDef.g_sYourMasterListSearchLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "YourMasterListNowLocateMsg", "", ref GameMsgDef.g_sYourMasterListNowLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "YourMasterSearchLocateMsg", "", ref GameMsgDef.g_sYourMasterSearchLocateMsg);
            IniFile.SyncIniString(StringConf, "String", "YourMasterListUnMasterOKMsg", "", ref GameMsgDef.g_sYourMasterListUnMasterOKMsg);
            IniFile.SyncIniString(StringConf, "String", "YouAreUnMasterOKMsg", "", ref GameMsgDef.g_sYouAreUnMasterOKMsg);
            IniFile.SyncIniString(StringConf, "String", "UnMasterLoginMsg", "", ref GameMsgDef.g_sUnMasterLoginMsg);
            IniFile.SyncIniString(StringConf, "String", "NPCSayUnMasterOKMsg", "", ref GameMsgDef.g_sNPCSayUnMasterOKMsg);
            IniFile.SyncIniString(StringConf, "String", "NPCSayForceUnMasterMsg", "", ref GameMsgDef.g_sNPCSayForceUnMasterMsg);
            IniFile.SyncIniString(StringConf, "String", "MyInfo", "", ref GameMsgDef.g_sMyInfo);
            IniFile.SyncIniString(StringConf, "String", "OpenedDealMsg", "", ref GameMsgDef.g_sOpenedDealMsg);
            IniFile.SyncIniString(StringConf, "String", "SendCustMsgCanNotUseNowMsg", "", ref GameMsgDef.g_sSendCustMsgCanNotUseNowMsg);
            IniFile.SyncIniString(StringConf, "String", "SubkMasterMsgCanNotUseNowMsg", "", ref GameMsgDef.g_sSubkMasterMsgCanNotUseNowMsg);
            IniFile.SyncIniString(StringConf, "String", "SendOnlineCountMsg", "", ref GameMsgDef.g_sSendOnlineCountMsg);
            IniFile.SyncIniString(StringConf, "String", "WeaponRepairSuccess", "", ref GameMsgDef.g_sWeaponRepairSuccess);
            IniFile.SyncIniString(StringConf, "String", "DefenceUpTime", "", ref GameMsgDef.g_sDefenceUpTime);
            IniFile.SyncIniString(StringConf, "String", "MagDefenceUpTime", "", ref GameMsgDef.g_sMagDefenceUpTime);
            IniFile.SyncIniString(StringConf, "String", "DefenceUpTimeOver", "", ref GameMsgDef.g_sDefenceUpTimeOver);
            IniFile.SyncIniString(StringConf, "String", "MagDefenceUpTimeOver", "", ref GameMsgDef.g_sMagDefenceUpTimeOver);
            #region 彩票提示
            IniFile.SyncIniString(StringConf, "String", "WinLottery1Msg", "", ref GameMsgDef.g_sWinLottery1Msg);
            IniFile.SyncIniString(StringConf, "String", "WinLottery2Msg", "", ref GameMsgDef.g_sWinLottery2Msg);
            IniFile.SyncIniString(StringConf, "String", "WinLottery3Msg", "", ref GameMsgDef.g_sWinLottery3Msg);
            IniFile.SyncIniString(StringConf, "String", "WinLottery4Msg", "", ref GameMsgDef.g_sWinLottery4Msg);
            IniFile.SyncIniString(StringConf, "String", "WinLottery5Msg", "", ref GameMsgDef.g_sWinLottery5Msg);
            IniFile.SyncIniString(StringConf, "String", "WinLottery6Msg", "", ref GameMsgDef.g_sWinLottery6Msg);
            IniFile.SyncIniString(StringConf, "String", "NotWinLotteryMsg", "", ref GameMsgDef.g_sNotWinLotteryMsg);
            #endregion
            IniFile.SyncIniString(StringConf, "String", "WeaptonMakeLuck", "", ref GameMsgDef.g_sWeaptonMakeLuck);
            IniFile.SyncIniString(StringConf, "String", "WeaptonNotMakeLuck", "", ref GameMsgDef.g_sWeaptonNotMakeLuck);
            IniFile.SyncIniString(StringConf, "String", "TheWeaponIsCursed", "", ref GameMsgDef.g_sTheWeaponIsCursed);
            IniFile.SyncIniString(StringConf, "String", "CanotTakeOffItem", "", ref GameMsgDef.g_sCanotTakeOffItem);
            IniFile.SyncIniString(StringConf, "String", "JoinGroupMsg", "", ref GameMsgDef.g_sJoinGroup);
            IniFile.SyncIniString(StringConf, "String", "TryModeCanotUseStorage", "", ref GameMsgDef.g_sTryModeCanotUseStorage);
            IniFile.SyncIniString(StringConf, "String", "CanotGetItemsMsg", "", ref GameMsgDef.g_sCanotGetItems);
            #region 夫妻、师徒传送允许与否提示
            IniFile.SyncIniString(StringConf, "String", "EnableDearRecall", "", ref GameMsgDef.g_sEnableDearRecall);
            IniFile.SyncIniString(StringConf, "String", "DisableDearRecall", "", ref GameMsgDef.g_sDisableDearRecall);
            IniFile.SyncIniString(StringConf, "String", "EnableMasterRecall", "", ref GameMsgDef.g_sEnableMasterRecall);
            IniFile.SyncIniString(StringConf, "String", "DisableMasterRecall", "", ref GameMsgDef.g_sDisableMasterRecall);
            #endregion
            IniFile.SyncIniString(StringConf, "String", "NowCurrDateTime", "", ref GameMsgDef.g_sNowCurrDateTime);
            IniFile.SyncIniString(StringConf, "String", "EnableAllowRebirth", "", ref GameMsgDef.g_sEnableAllowRebirth);
            IniFile.SyncIniString(StringConf, "String", "DisableAllowRebirth", "", ref GameMsgDef.g_sDisableAllowRebirth);
            IniFile.SyncIniString(StringConf, "String", "EnableHearWhisper", "", ref GameMsgDef.g_sEnableHearWhisper);
            IniFile.SyncIniString(StringConf, "String", "DisableHearWhisper", "", ref GameMsgDef.g_sDisableHearWhisper);
            IniFile.SyncIniString(StringConf, "String", "EnableShoutMsg", "", ref GameMsgDef.g_sEnableShoutMsg);
            IniFile.SyncIniString(StringConf, "String", "DisableShoutMsg", "", ref GameMsgDef.g_sDisableShoutMsg);
            IniFile.SyncIniString(StringConf, "String", "EnableDealMsg", "", ref GameMsgDef.g_sEnableDealMsg);
            IniFile.SyncIniString(StringConf, "String", "DisableDealMsg", "", ref GameMsgDef.g_sDisableDealMsg);
            IniFile.SyncIniString(StringConf, "String", "EnableGuildChat", "", ref GameMsgDef.g_sEnableGuildChat);
            IniFile.SyncIniString(StringConf, "String", "DisableGuildChat", "", ref GameMsgDef.g_sDisableGuildChat);
            IniFile.SyncIniString(StringConf, "String", "EnableJoinGuild", "", ref GameMsgDef.g_sEnableJoinGuild);
            IniFile.SyncIniString(StringConf, "String", "DisableJoinGuild", "", ref GameMsgDef.g_sDisableJoinGuild);
            IniFile.SyncIniString(StringConf, "String", "EnableAuthAllyGuild", "", ref GameMsgDef.g_sEnableAuthAllyGuild);
            IniFile.SyncIniString(StringConf, "String", "DisableAuthAllyGuild", "", ref GameMsgDef.g_sDisableAuthAllyGuild);
            IniFile.SyncIniString(StringConf, "String", "EnableGroupRecall", "", ref GameMsgDef.g_sEnableGroupRecall);
            IniFile.SyncIniString(StringConf, "String", "DisableGroupRecall", "", ref GameMsgDef.g_sDisableGroupRecall);
            IniFile.SyncIniString(StringConf, "String", "EnableGuildRecall", "", ref GameMsgDef.g_sEnableGuildRecall);
            IniFile.SyncIniString(StringConf, "String", "DisableGuildRecall", "", ref GameMsgDef.g_sDisableGuildRecall);
            IniFile.SyncIniString(StringConf, "String", "PleaseInputPassword", "", ref GameMsgDef.g_sPleaseInputPassword);
            IniFile.SyncIniString(StringConf, "String", "TheMapDisableMove", "", ref GameMsgDef.g_sTheMapDisableMove);
            IniFile.SyncIniString(StringConf, "String", "TheMapNotFound", "", ref GameMsgDef.g_sTheMapNotFound);
            IniFile.SyncIniString(StringConf, "String", "YourIPaddrDenyLogon", "", ref GameMsgDef.g_sYourIPaddrDenyLogon);
            IniFile.SyncIniString(StringConf, "String", "YourAccountDenyLogon", "", ref GameMsgDef.g_sYourAccountDenyLogon);
            IniFile.SyncIniString(StringConf, "String", "YourCharNameDenyLogon", "", ref GameMsgDef.g_sYourCharNameDenyLogon);
            IniFile.SyncIniString(StringConf, "String", "CanotPickUpItem", "", ref GameMsgDef.g_sCanotPickUpItem);
            IniFile.SyncIniString(StringConf, "String", "CanotSendmsg", "", ref GameMsgDef.g_sCanotSendmsg);
            IniFile.SyncIniString(StringConf, "String", "UserDenyWhisperMsg", "", ref GameMsgDef.g_sUserDenyWhisperMsg);
            IniFile.SyncIniString(StringConf, "String", "UserNotOnLine", "", ref GameMsgDef.g_sUserNotOnLine);
            IniFile.SyncIniString(StringConf, "String", "RevivalRecoverMsg", "", ref GameMsgDef.g_sRevivalRecoverMsg);
            IniFile.SyncIniString(StringConf, "String", "ClientVersionTooOld", "", ref GameMsgDef.g_sClientVersionTooOld);
            IniFile.SyncIniString(StringConf, "String", "CastleGuildName", "", ref GameMsgDef.g_sCastleGuildName);
            IniFile.SyncIniString(StringConf, "String", "NoCastleGuildName", "", ref GameMsgDef.g_sNoCastleGuildName);
            IniFile.SyncIniString(StringConf, "String", "WarrReNewName", "", ref GameMsgDef.g_sWarrReNewName);
            IniFile.SyncIniString(StringConf, "String", "WizardReNewName", "", ref GameMsgDef.g_sWizardReNewName);
            IniFile.SyncIniString(StringConf, "String", "TaosReNewName", "", ref GameMsgDef.g_sTaosReNewName);
            IniFile.SyncIniString(StringConf, "String", "RankLevelName", "", ref GameMsgDef.g_sRankLevelName);
            IniFile.SyncIniString(StringConf, "String", "ManDearName", "", ref GameMsgDef.g_sManDearName);
            IniFile.SyncIniString(StringConf, "String", "WoManDearName", "", ref GameMsgDef.g_sWoManDearName);
            IniFile.SyncIniString(StringConf, "String", "MasterName", "", ref GameMsgDef.g_sMasterName);
            IniFile.SyncIniString(StringConf, "String", "NoMasterName", "", ref GameMsgDef.g_sNoMasterName);
            IniFile.SyncIniString(StringConf, "String", "HumanShowName", "", ref GameMsgDef.g_sHumanShowName);
            IniFile.SyncIniString(StringConf, "String", "ChangePermissionMsg", "", ref GameMsgDef.g_sChangePermissionMsg);
            IniFile.SyncIniString(StringConf, "String", "ChangeKillMonExpRateMsg", "", ref GameMsgDef.g_sChangeKillMonExpRateMsg);
            IniFile.SyncIniString(StringConf, "String", "ChangePowerRateMsg", "", ref GameMsgDef.g_sChangePowerRateMsg);
            IniFile.SyncIniString(StringConf, "String", "ChangeMemberLevelMsg", "", ref GameMsgDef.g_sChangeMemberLevelMsg);
            IniFile.SyncIniString(StringConf, "String", "ChangeMemberTypeMsg", "", ref GameMsgDef.g_sChangeMemberTypeMsg);
            IniFile.SyncIniString(StringConf, "String", "ScriptChangeHumanHPMsg", "", ref GameMsgDef.g_sScriptChangeHumanHPMsg);
            IniFile.SyncIniString(StringConf, "String", "ScriptChangeHumanMPMsg", "", ref GameMsgDef.g_sScriptChangeHumanMPMsg);
            IniFile.SyncIniString(StringConf, "String", "YouCanotDisableSayMsg", "", ref GameMsgDef.g_sDisableSayMsg);
            IniFile.SyncIniString(StringConf, "String", "OnlineCountMsg", "", ref GameMsgDef.g_sOnlineCountMsg);
            IniFile.SyncIniString(StringConf, "String", "TotalOnlineCountMsg", "", ref GameMsgDef.g_sTotalOnlineCountMsg);
            IniFile.SyncIniString(StringConf, "String", "YouNeedLevelSendMsg", "", ref GameMsgDef.g_sYouNeedLevelMsg);
            IniFile.SyncIniString(StringConf, "String", "ThisMapDisableSendCyCyMsg", "", ref GameMsgDef.g_sThisMapDisableSendCyCyMsg);
            IniFile.SyncIniString(StringConf, "String", "YouCanSendCyCyLaterMsg", "", ref GameMsgDef.g_sYouCanSendCyCyLaterMsg);
            IniFile.SyncIniString(StringConf, "String", "YouIsDisableSendMsg", "", ref GameMsgDef.g_sYouIsDisableSendMsg);
            IniFile.SyncIniString(StringConf, "String", "YouMurderedMsg", "", ref GameMsgDef.g_sYouMurderedMsg);
            IniFile.SyncIniString(StringConf, "String", "YouKilledByMsg", "", ref GameMsgDef.g_sYouKilledByMsg);
            IniFile.SyncIniString(StringConf, "String", "YouProtectedByLawOfDefense", "", ref GameMsgDef.g_sYouProtectedByLawOfDefense);
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public static void LoadConfig()
        {
            int I;
            int nLoadInteger;
            double nLoadFloat;
            string sLoadString;
            StartFixExp();
            LoadString();
            LoadGameCommand();
            LoadExp();
            LoadVarGlobal();
            // ============================================================================
            IniFile.SyncIniString(StringConf, "Guild", "GuildNotice", "", ref g_Config.sGuildNotice);
            IniFile.SyncIniString(StringConf, "Guild", "GuildWar", "", ref g_Config.sGuildWar);
            IniFile.SyncIniString(StringConf, "Guild", "GuildAll", "", ref g_Config.sGuildAll);
            IniFile.SyncIniString(StringConf, "Guild", "GuildMember", "", ref g_Config.sGuildMember);
            IniFile.SyncIniString(StringConf, "Guild", "GuildMemberRank", "", ref g_Config.sGuildMemberRank);
            IniFile.SyncIniString(StringConf, "Guild", "GuildChief", "", ref g_Config.sGuildChief);
            IniFile.SyncIniString(Config, "Server", "ConnectionString", "", ref g_Config.sConnectionString);
            IniFile.SyncIniInt(Config, "Server", "ServerIndex", ref nServerIndex);
            IniFile.SyncIniString(Config, "Server", "ServerName", "", ref g_Config.sServerName);
            IniFile.SyncIniString(StringConf, "Server", "ServerIP", "", ref g_Config.sServerIPaddr);
            IniFile.SyncIniBool(Config, "Server", "Minimize", ref g_boMinimize);
            IniFile.SyncIniString(StringConf, "Server", "WebSite", "", ref g_Config.sWebSite);
            IniFile.SyncIniString(StringConf, "Server", "BbsSite", "", ref g_Config.sBbsSite);
            IniFile.SyncIniString(StringConf, "Server", "ClientDownload", "", ref g_Config.sClientDownload);
            IniFile.SyncIniString(StringConf, "Server", "QQ", "", ref g_Config.sQQ);
            IniFile.SyncIniString(StringConf, "Server", "Phone", "", ref g_Config.sPhone);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount0", "", ref g_Config.sBankAccount0);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount1", "", ref g_Config.sBankAccount1);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount2", "", ref g_Config.sBankAccount2);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount3", "", ref g_Config.sBankAccount3);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount4", "", ref g_Config.sBankAccount4);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount5", "", ref g_Config.sBankAccount5);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount6", "", ref g_Config.sBankAccount6);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount7", "", ref g_Config.sBankAccount7);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount8", "", ref g_Config.sBankAccount8);
            IniFile.SyncIniString(StringConf, "Server", "BankAccount9", "", ref g_Config.sBankAccount9);
            IniFile.SyncIniUshort(Config, "Server", "ServerNumber", ref g_Config.nServerNumber);


            if (Config.ReadString("Server", "VentureServer", "") == "")
            {
                Config.WriteString("Server", "VentureServer", HUtil32.BoolToStr(g_Config.boVentureServer));
            }
            g_Config.boVentureServer = (Config.ReadString("Server", "VentureServer", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;

            if (Config.ReadString("Server", "TestServer", "") == "")
            {
                Config.WriteString("Server", "TestServer", HUtil32.BoolToStr(g_Config.boTestServer));
            }
            g_Config.boTestServer = (Config.ReadString("Server", "TestServer", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;

            IniFile.SyncIniUshort(Config, "Server", "TestLevel", ref  g_Config.nTestLevel);
            IniFile.SyncIniInt(Config, "Server", "TestGold", ref   g_Config.nTestGold);
            IniFile.SyncIniUshort(Config, "Server", "TestServerUserLimit", ref  g_Config.nTestUserLimit);

            if (Config.ReadString("Server", "ServiceMode", "") == "")
            {
                Config.WriteString("Server", "ServiceMode", HUtil32.BoolToStr(g_Config.boServiceMode));
            }
            g_Config.boServiceMode = (Config.ReadString("Server", "ServiceMode", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;

            if (Config.ReadString("Server", "NonPKServer", "") == "")
            {
                Config.WriteString("Server", "NonPKServer", HUtil32.BoolToStr(g_Config.boNonPKServer));
            }
            g_Config.boNonPKServer = (Config.ReadString("Server", "NonPKServer", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadString("Server", "ViewHackMessage", "") == "")
            {
                Config.WriteString("Server", "ViewHackMessage", HUtil32.BoolToStr(g_Config.boViewHackMessage));
            }
            g_Config.boViewHackMessage = (Config.ReadString("Server", "ViewHackMessage", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadString("Server", "ViewAdmissionFailure", "") == "")
            {
                Config.WriteString("Server", "ViewAdmissionFailure", HUtil32.BoolToStr(g_Config.boViewAdmissionFailure));
            }
            g_Config.boViewAdmissionFailure = (Config.ReadString("Server", "ViewAdmissionFailure", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;

            //IniFile.SyncIniString(Config, "Server", "DBName", "", ref sDBName);
            IniFile.SyncIniString(Config, "Server", "GateAddr", "", ref g_Config.sGateAddr);
            IniFile.SyncIniUshort(Config, "Server", "GatePort", ref  g_Config.nGatePort);
            IniFile.SyncIniString(Config, "Server", "DBAddr", "", ref g_Config.sDBAddr);
            IniFile.SyncIniUshort(Config, "Server", "DBPort", ref g_Config.nDBPort);
            IniFile.SyncIniString(Config, "Server", "IDSAddr", "", ref g_Config.sIDSAddr);
            IniFile.SyncIniUshort(Config, "Server", "IDSPort", ref g_Config.nIDSPort);
            IniFile.SyncIniString(Config, "Server", "MsgSrvAddr", "", ref g_Config.sMsgSrvAddr);
            IniFile.SyncIniUshort(Config, "Server", "MsgSrvPort", ref g_Config.nMsgSrvPort);
            IniFile.SyncIniString(Config, "Server", "LogServerAddr", "", ref g_Config.sLogServerAddr);
            IniFile.SyncIniUshort(Config, "Server", "LogServerPort", ref g_Config.nLogServerPort);
            if (Config.ReadString("Server", "DiscountForNightTime", "") == "")
            {
                Config.WriteString("Server", "DiscountForNightTime", HUtil32.BoolToStr(g_Config.boDiscountForNightTime));
            }
            g_Config.boDiscountForNightTime = (Config.ReadString("Server", "DiscountForNightTime", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;

            IniFile.SyncIniInt(Config, "Server", "HalfFeeStart", ref g_Config.nHalfFeeStart);
            IniFile.SyncIniInt(Config, "Server", "HalfFeeEnd", ref g_Config.nHalfFeeEnd);
            IniFile.SyncIniUint(Config, "Server", "HumLimit", ref  g_dwHumLimit);
            IniFile.SyncIniUint(Config, "Server", "MonLimit", ref  g_dwMonLimit);
            IniFile.SyncIniUint(Config, "Server", "ZenLimit", ref  g_dwZenLimit);
            IniFile.SyncIniUint(Config, "Server", "NpcLimit", ref  g_dwNpcLimit);
            IniFile.SyncIniUint(Config, "Server", "SocLimit", ref  g_dwSocLimit);
            IniFile.SyncIniInt(Config, "Server", "DecLimit", ref nDecLimit);
            IniFile.SyncIniInt(Config, "Server", "SendBlock", ref  g_Config.nSendBlock);
            IniFile.SyncIniInt(Config, "Server", "CheckBlock", ref  g_Config.nCheckBlock);
            IniFile.SyncIniUint(Config, "Server", "SocCheckTimeOut", ref g_dwSocCheckTimeOut);
            IniFile.SyncIniInt(Config, "Server", "AvailableBlock", ref  g_Config.nAvailableBlock);
            IniFile.SyncIniInt(Config, "Server", "GateLoad", ref  g_Config.nGateLoad);
            IniFile.SyncIniInt(Config, "Server", "UserFull", ref  g_Config.nUserFull);
            IniFile.SyncIniInt(Config, "Server", "ZenFastStep", ref  g_Config.nZenFastStep);
            IniFile.SyncIniUint(Config, "Server", "ProcessMonstersTime", ref g_Config.dwProcessMonstersTime);
            IniFile.SyncIniUint(Config, "Server", "RegenMonstersTime", ref g_Config.dwRegenMonstersTime);
            IniFile.SyncIniUint(Config, "Server", "HumanGetMsgTimeLimit", ref g_Config.dwHumanGetMsgTime);
            // ============================================================================
            // 目录设置
            IniFile.SyncIniString(Config, "Share", "BaseDir", "", ref  g_Config.sBaseDir);
            IniFile.SyncIniString(Config, "Share", "GuildDir", "", ref  g_Config.sGuildDir);
            IniFile.SyncIniString(Config, "Share", "GuildFile", "", ref  g_Config.sGuildFile);
            IniFile.SyncIniString(Config, "Share", "VentureDir", "", ref  g_Config.sVentureDir);
            IniFile.SyncIniString(Config, "Share", "ConLogDir", "", ref  g_Config.sConLogDir);
            IniFile.SyncIniString(Config, "Share", "CastleDir", "", ref  g_Config.sCastleDir);
            // 沙巴克文件
            IniFile.SyncIniString(Config, "Share", "CastleFile", "", ref  g_Config.sCastleFile);
            // 排行榜路径 20080220
            IniFile.SyncIniString(Config, "Share", "SortDir", "", ref  g_Config.sSortDir);
            // ------------------------------------------------------------------------------
            // 宝箱路径,文件 20080114
            IniFile.SyncIniString(Config, "Share", "BoxsDir", "", ref  g_Config.sBoxsDir);
            IniFile.SyncIniString(Config, "Share", "BoxsFile", "", ref  g_Config.sBoxsFile);
            // ------------------------------------------------------------------------------
            IniFile.SyncIniString(Config, "Share", "EnvirDir", "", ref  g_Config.sEnvirDir);
            IniFile.SyncIniString(Config, "Share", "MapDir", "", ref  g_Config.sMapDir);
            IniFile.SyncIniString(Config, "Share", "NoticeDir", "", ref  g_Config.sNoticeDir);
            IniFile.SyncIniString(Config, "Share", "LogDir", "", ref  g_Config.sLogDir);
            IniFile.SyncIniString(Config, "Share", "PlugDir", "", ref  g_Config.sPlugDir);
            // ============================================================================
            // 名称设置
            IniFile.SyncIniString(Config, "Names", "HealSkill", "", ref  g_Config.sHealSkill);
            IniFile.SyncIniString(Config, "Names", "FireBallSkill", "", ref  g_Config.sFireBallSkill);
            IniFile.SyncIniString(Config, "Names", "HeavenSKill", "", ref  g_Config.sHeavenSKill);
            IniFile.SyncIniString(Config, "Names", "MeteorSKill", "", ref  g_Config.MeteorSKill);
            IniFile.SyncIniString(Config, "Names", "ClothsMan", "", ref  g_Config.sClothsMan);
            IniFile.SyncIniString(Config, "Names", "ClothsWoman", "", ref  g_Config.sClothsWoman);
            IniFile.SyncIniString(Config, "Names", "WoodenSword", "", ref  g_Config.sWoodenSword);
            IniFile.SyncIniString(Config, "Names", "Candle", "", ref  g_Config.sCandle);
            IniFile.SyncIniString(Config, "Names", "BasicDrug", "", ref  g_Config.sBasicDrug);
            IniFile.SyncIniString(Config, "Names", "GoldStone", "", ref  g_Config.sGoldStone);
            IniFile.SyncIniString(Config, "Names", "SilverStone", "", ref  g_Config.sSilverStone);
            IniFile.SyncIniString(Config, "Names", "SteelStone", "", ref  g_Config.sSteelStone);
            IniFile.SyncIniString(Config, "Names", "CopperStone", "", ref  g_Config.sCopperStone);
            IniFile.SyncIniString(Config, "Names", "BlackStone", "", ref  g_Config.sBlackStone);
            IniFile.SyncIniString(Config, "Names", "Zuma1", "", ref  g_Config.sZuma[0]);
            IniFile.SyncIniString(Config, "Names", "Zuma2", "", ref  g_Config.sZuma[1]);
            IniFile.SyncIniString(Config, "Names", "Zuma3", "", ref  g_Config.sZuma[2]);
            IniFile.SyncIniString(Config, "Names", "Zuma4", "", ref  g_Config.sZuma[3]);
            IniFile.SyncIniString(Config, "Names", "Bee", "", ref  g_Config.sBee);
            IniFile.SyncIniString(Config, "Names", "Spider", "", ref  g_Config.sSpider);
            IniFile.SyncIniString(Config, "Names", "WomaHorn", "", ref  g_Config.sWomaHorn);
            IniFile.SyncIniString(Config, "Names", "ZumaPiece", "", ref  g_Config.sZumaPiece);
            IniFile.SyncIniString(Config, "Names", "Dogz", "", ref  g_Config.sDogz);

            // 月灵
            IniFile.SyncIniString(Config, "Names", "Fairy", "", ref  g_Config.sFairy);
            IniFile.SyncIniString(Config, "Names", "BoneFamm", "", ref  g_Config.sBoneFamm);
            IniFile.SyncIniString(Config, "Names", "GameGold", "", ref  g_Config.sGameGoldName);
            // 金刚石
            IniFile.SyncIniString(Config, "Names", "GameDiaMond", "", ref  g_Config.sGameDiaMond);
            // 灵符
            IniFile.SyncIniString(Config, "Names", "GameGird", "", ref  g_Config.sGameGird);
            // 荣誉
            IniFile.SyncIniString(Config, "Names", "GameGlory", "", ref  g_Config.sGameGlory);
            IniFile.SyncIniString(Config, "Names", "GamePoint", "", ref  g_Config.sGamePointName);
            IniFile.SyncIniString(Config, "Names", "PayMentPointName", "", ref  g_Config.sPayMentPointName);
            // ============================================================================
            // 游戏设置
            IniFile.SyncIniInt(Config, "Setup", "ItemNumber", ref  g_Config.nItemNumber);
            IniFile.SyncIniInt(Config, "Setup", "ItemNumberEx", ref  g_Config.nItemNumberEx);
            IniFile.SyncIniString(Config, "Setup", "ClientFile1", "", ref  g_Config.sClientFile1);
            IniFile.SyncIniInt(Config, "Setup", "MonUpLvNeedKillBase", ref  g_Config.nMonUpLvNeedKillBase);
            IniFile.SyncIniUshort(Config, "Setup", "MonUpLvRate", ref g_Config.nMonUpLvRate);

            for (I = g_Config.MonUpLvNeedKillCount.GetLowerBound(0); I <= g_Config.MonUpLvNeedKillCount.GetUpperBound(0); I++)
            {
                IniFile.SyncIniUshort(Config, "Setup", "MonUpLvNeedKillCount" + I, ref g_Config.MonUpLvNeedKillCount[I]);
            }
            for (I = g_Config.SlaveColor.GetLowerBound(0); I <= g_Config.SlaveColor.GetUpperBound(0); I++)
            {
                IniFile.SyncIniByte(Config, "Setup", "SlaveColor" + I, ref g_Config.SlaveColor[I]);
            }

            IniFile.SyncIniString(Config, "Setup", "HomeMap", "", ref  g_Config.sHomeMap);
            IniFile.SyncIniInt(Config, "Setup", "HomeX", ref g_Config.nHomeX);
            IniFile.SyncIniInt(Config, "Setup", "HomeY", ref g_Config.nHomeY);
            IniFile.SyncIniString(Config, "Setup", "RedHomeMap", "", ref  g_Config.sRedHomeMap);
            IniFile.SyncIniInt(Config, "Setup", "RedHomeX", ref g_Config.nRedHomeX);
            IniFile.SyncIniInt(Config, "Setup", "RedHomeY", ref g_Config.nRedHomeY);
            IniFile.SyncIniString(Config, "Setup", "RedDieHomeMap", "", ref g_Config.sRedDieHomeMap);
            IniFile.SyncIniInt(Config, "Setup", "RedDieHomeX", ref g_Config.nRedDieHomeX);
            IniFile.SyncIniInt(Config, "Setup", "RedDieHomeY", ref g_Config.nRedDieHomeY);
            IniFile.SyncIniInt(Config, "Setup", "HealthFillTime", ref g_Config.nHealthFillTime);
            IniFile.SyncIniInt(Config, "Setup", "SpellFillTime", ref g_Config.nSpellFillTime);
            IniFile.SyncIniUint(Config, "Setup", "DecPkPointTime", ref g_Config.dwDecPkPointTime);
            IniFile.SyncIniUshort(Config, "Setup", "DecPkPointCount", ref g_Config.nDecPkPointCount);
            IniFile.SyncIniUint(Config, "Setup", "PKFlagTime", ref g_Config.dwPKFlagTime);
            // 杀人武器被诅咒机率
            IniFile.SyncIniByte(Config, "Setup", "KillHumanWeaponUnlockRate", ref g_Config.nKillHumanWeaponUnlockRate);
            IniFile.SyncIniUshort(Config, "Setup", "KillHumanAddPKPoint", ref g_Config.nKillHumanAddPKPoint);
            IniFile.SyncIniUshort(Config, "Setup", "KillHumanDecLuckPoint", ref g_Config.nKillHumanDecLuckPoint);
            IniFile.SyncIniUint(Config, "Setup", "DecLightItemDrugTime", ref g_Config.dwDecLightItemDrugTime);
            IniFile.SyncIniUshort(Config, "Setup", "SafeZoneSize", ref g_Config.nSafeZoneSize);
            IniFile.SyncIniUshort(Config, "Setup", "StartPointSize", ref g_Config.nStartPointSize);

            for (I = g_Config.ReNewNameColor.GetLowerBound(0); I <= g_Config.ReNewNameColor.GetUpperBound(0); I++)
            {
                IniFile.SyncIniByte(Config, "Setup", "ReNewNameColor" + I, ref g_Config.ReNewNameColor[I]);
            }

            IniFile.SyncIniUint(Config, "Setup", "ReNewNameColorTime", ref g_Config.dwReNewNameColorTime);
            IniFile.SyncIniBool(Config, "Setup", "ReNewChangeColor", ref g_Config.boReNewChangeColor);
            IniFile.SyncIniBool(Config, "Setup", "ReNewLevelClearExp", ref g_Config.boReNewLevelClearExp);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrDC", ref g_Config.BonusAbilofWarr.DC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrMC", ref g_Config.BonusAbilofWarr.MC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrSC", ref g_Config.BonusAbilofWarr.SC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrAC", ref g_Config.BonusAbilofWarr.AC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrMAC", ref g_Config.BonusAbilofWarr.MAC);
            IniFile.SyncIniInt(Config, "Setup", "BonusAbilofWarrHP", ref g_Config.BonusAbilofWarr.HP);
            IniFile.SyncIniInt(Config, "Setup", "BonusAbilofWarrMP", ref g_Config.BonusAbilofWarr.MP);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrHit", ref g_Config.BonusAbilofWarr.Hit);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrSpeed", ref g_Config.BonusAbilofWarr.Speed);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWarrX2", ref g_Config.BonusAbilofWarr.X2);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardDC", ref g_Config.BonusAbilofWizard.DC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardMC", ref g_Config.BonusAbilofWizard.MC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardSC", ref g_Config.BonusAbilofWizard.SC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardAC", ref g_Config.BonusAbilofWizard.AC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardMAC", ref g_Config.BonusAbilofWizard.MAC);
            IniFile.SyncIniInt(Config, "Setup", "BonusAbilofWizardHP", ref g_Config.BonusAbilofWizard.HP);
            IniFile.SyncIniInt(Config, "Setup", "BonusAbilofWizardMP", ref g_Config.BonusAbilofWizard.MP);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardHit", ref g_Config.BonusAbilofWizard.Hit);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardSpeed", ref g_Config.BonusAbilofWizard.Speed);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofWizardX2", ref g_Config.BonusAbilofWizard.X2);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosDC", ref g_Config.BonusAbilofTaos.DC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosMC", ref g_Config.BonusAbilofTaos.MC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosSC", ref g_Config.BonusAbilofTaos.SC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosAC", ref g_Config.BonusAbilofTaos.AC);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosMAC", ref g_Config.BonusAbilofTaos.MAC);
            IniFile.SyncIniInt(Config, "Setup", "BonusAbilofTaosHP", ref g_Config.BonusAbilofTaos.HP);
            IniFile.SyncIniInt(Config, "Setup", "BonusAbilofTaosMP", ref g_Config.BonusAbilofTaos.MP);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosHit", ref g_Config.BonusAbilofTaos.Hit);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosSpeed", ref g_Config.BonusAbilofTaos.Speed);
            IniFile.SyncIniUshort(Config, "Setup", "BonusAbilofTaosX2", ref g_Config.BonusAbilofTaos.X2);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrDC", ref g_Config.NakedAbilofWarr.DC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrMC", ref g_Config.NakedAbilofWarr.MC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrSC", ref g_Config.NakedAbilofWarr.SC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrAC", ref g_Config.NakedAbilofWarr.AC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrMAC", ref g_Config.NakedAbilofWarr.MAC);
            IniFile.SyncIniInt(Config, "Setup", "NakedAbilofWarrHP", ref g_Config.NakedAbilofWarr.HP);
            IniFile.SyncIniInt(Config, "Setup", "NakedAbilofWarrMP", ref g_Config.NakedAbilofWarr.MP);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrHit", ref g_Config.NakedAbilofWarr.Hit);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrSpeed", ref g_Config.NakedAbilofWarr.Speed);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWarrX2", ref g_Config.NakedAbilofWarr.X2);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardDC", ref g_Config.NakedAbilofWizard.DC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardMC", ref g_Config.NakedAbilofWizard.MC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardSC", ref g_Config.NakedAbilofWizard.SC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardAC", ref g_Config.NakedAbilofWizard.AC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardMAC", ref g_Config.NakedAbilofWizard.MAC);
            IniFile.SyncIniInt(Config, "Setup", "NakedAbilofWizardHP", ref g_Config.NakedAbilofWizard.HP);
            IniFile.SyncIniInt(Config, "Setup", "NakedAbilofWizardMP", ref g_Config.NakedAbilofWizard.MP);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardHit", ref g_Config.NakedAbilofWizard.Hit);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardSpeed", ref g_Config.NakedAbilofWizard.Speed);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofWizardX2", ref g_Config.NakedAbilofWizard.X2);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosDC", ref g_Config.NakedAbilofTaos.DC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosMC", ref g_Config.NakedAbilofTaos.MC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosSC", ref g_Config.NakedAbilofTaos.SC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosAC", ref g_Config.NakedAbilofTaos.AC);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosMAC", ref g_Config.NakedAbilofTaos.MAC);
            IniFile.SyncIniInt(Config, "Setup", "NakedAbilofTaosHP", ref g_Config.NakedAbilofTaos.HP);
            IniFile.SyncIniInt(Config, "Setup", "NakedAbilofTaosMP", ref g_Config.NakedAbilofTaos.MP);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosHit", ref g_Config.NakedAbilofTaos.Hit);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosSpeed", ref g_Config.NakedAbilofTaos.Speed);
            IniFile.SyncIniUshort(Config, "Setup", "NakedAbilofTaosX2", ref g_Config.NakedAbilofTaos.X2);
            // 新建行会成员上限 20090115
            IniFile.SyncIniUshort(Config, "Setup", "GuildMemberCount", ref g_Config.nGuildMemberCount);
            IniFile.SyncIniUshort(Config, "Setup", "GroupMembersMax", ref g_Config.nGroupMembersMax);
            IniFile.SyncIniUint(Config, "Setup", "UPgradeWeaponGetBackTime", ref g_Config.dwUPgradeWeaponGetBackTime);
            IniFile.SyncIniByte(Config, "Setup", "ClearExpireUpgradeWeaponDays", ref g_Config.nClearExpireUpgradeWeaponDays);
            IniFile.SyncIniInt(Config, "Setup", "UpgradeWeaponPrice", ref g_Config.nUpgradeWeaponPrice);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponMaxPoint", ref g_Config.nUpgradeWeaponMaxPoint);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponDCRate", ref g_Config.nUpgradeWeaponDCRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponDCTwoPointRate", ref g_Config.nUpgradeWeaponDCTwoPointRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponDCThreePointRate", ref g_Config.nUpgradeWeaponDCThreePointRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponMCRate", ref g_Config.nUpgradeWeaponMCRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponMCTwoPointRate", ref g_Config.nUpgradeWeaponMCTwoPointRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponMCThreePointRate", ref g_Config.nUpgradeWeaponMCThreePointRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponSCRate", ref g_Config.nUpgradeWeaponSCRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponSCTwoPointRate", ref g_Config.nUpgradeWeaponSCTwoPointRate);
            IniFile.SyncIniUshort(Config, "Setup", "UpgradeWeaponSCThreePointRate", ref g_Config.nUpgradeWeaponSCThreePointRate);
            IniFile.SyncIniInt(Config, "Setup", "BuildGuild", ref g_Config.nBuildGuildPrice);
            IniFile.SyncIniInt(Config, "Setup", "MakeDurg", ref g_Config.nMakeDurgPrice);
            IniFile.SyncIniInt(Config, "Setup", "MakeDurg", ref g_Config.nMakeDurgPrice);
            IniFile.SyncIniInt(Config, "Setup", "GuildWarFee", ref g_Config.nGuildWarPrice);
            IniFile.SyncIniInt(Config, "Setup", "HireGuard", ref g_Config.nHireGuardPrice);
            IniFile.SyncIniInt(Config, "Setup", "HireArcher", ref g_Config.nHireArcherPrice);
            IniFile.SyncIniInt(Config, "Setup", "RepairDoor", ref g_Config.nRepairDoorPrice);
            IniFile.SyncIniInt(Config, "Setup", "RepairWall", ref g_Config.nRepairWallPrice);
            IniFile.SyncIniByte(Config, "Setup", "CastleMemberPriceRate", ref g_Config.nCastleMemberPriceRate);
            IniFile.SyncIniInt(Config, "Setup", "CastleGoldMax", ref g_Config.nCastleGoldMax);
            IniFile.SyncIniInt(Config, "Setup", "CastleOneDayGold", ref g_Config.nCastleOneDayGold);
            IniFile.SyncIniString(Config, "Setup", "CastleName", "", ref g_Config.sCASTLENAME);
            IniFile.SyncIniString(Config, "Setup", "CastleHomeMap", "", ref g_Config.sCastleHomeMap);
            IniFile.SyncIniInt(Config, "Setup", "CastleHomeX", ref g_Config.nCastleHomeX);
            IniFile.SyncIniInt(Config, "Setup", "CastleHomeY", ref g_Config.nCastleHomeY);
            IniFile.SyncIniInt(Config, "Setup", "CastleWarRangeX", ref g_Config.nCastleWarRangeX);
            IniFile.SyncIniInt(Config, "Setup", "CastleWarRangeY", ref g_Config.nCastleWarRangeY);
            IniFile.SyncIniUshort(Config, "Setup", "CastleTaxRate", ref g_Config.nCastleTaxRate);
            IniFile.SyncIniBool(Config, "Setup", "CastleGetAllNpcTax", ref g_Config.boGetAllNpcTax);
            IniFile.SyncIniUshort(Config, "Setup", "GenMonRate", ref g_Config.nMonGenRate);
            IniFile.SyncIniInt(Config, "Setup", "HumanMaxGold", ref g_Config.nHumanMaxGold);
            IniFile.SyncIniInt(Config, "Setup", "HumanTryModeMaxGold", ref g_Config.nHumanTryModeMaxGold);
            IniFile.SyncIniByte(Config, "Setup", "TryModeLevel", ref g_Config.nTryModeLevel);
            IniFile.SyncIniBool(Config, "Setup", "TryModeUseStorage", ref g_Config.boTryModeUseStorage);
            IniFile.SyncIniBool(Config, "Setup", "ShutRedMsgShowGMName", ref g_Config.boShutRedMsgShowGMName);
            IniFile.SyncIniBool(Config, "Setup", "ShowMakeItemMsg", ref g_Config.boShowMakeItemMsg);

            // 人物名是否显示行会信息
            IniFile.SyncIniBool(Config, "Setup", "ShowGuildName", ref g_Config.boShowGuildName);
            IniFile.SyncIniBool(Config, "Setup", "ShowRankLevelName", ref g_Config.boShowRankLevelName);
            IniFile.SyncIniBool(Config, "Setup", "MonSayMsg", ref g_Config.boMonSayMsg);
            IniFile.SyncIniByte(Config, "Setup", "SayMsgMaxLen", ref g_Config.nSayMsgMaxLen);
            IniFile.SyncIniUint(Config, "Setup", "SayMsgTime", ref g_Config.dwSayMsgTime);
            IniFile.SyncIniByte(Config, "Setup", "SayMsgCount", ref g_Config.nSayMsgCount);
            IniFile.SyncIniUint(Config, "Setup", "DisableSayMsgTime", ref g_Config.dwDisableSayMsgTime);
            IniFile.SyncIniByte(Config, "Setup", "SayRedMsgMaxLen", ref g_Config.nSayRedMsgMaxLen);
            IniFile.SyncIniUshort(Config, "Setup", "CanShoutMsgLevel", ref g_Config.nCanShoutMsgLevel);
            IniFile.SyncIniByte(Config, "Setup", "StartPermission", ref g_Config.nStartPermission);
            IniFile.SyncIniByte(Config, "Setup", "SendRefMsgRange", ref g_Config.nSendRefMsgRange);
            IniFile.SyncIniBool(Config, "Setup", "DecLampDura", ref g_Config.boDecLampDura);
            IniFile.SyncIniBool(Config, "Setup", "HungerSystem", ref g_Config.boHungerSystem);
            IniFile.SyncIniBool(Config, "Setup", "HungerDecHP", ref g_Config.boHungerDecHP);
            IniFile.SyncIniBool(Config, "Setup", "HungerDecPower", ref g_Config.boHungerDecPower);
            IniFile.SyncIniBool(Config, "Setup", "DiableHumanRun", ref g_Config.boDiableHumanRun);
            IniFile.SyncIniBool(Config, "Setup", "RunHuman", ref g_Config.boRUNHUMAN);
            IniFile.SyncIniBool(Config, "Setup", "RunMon", ref g_Config.boRUNMON);
            IniFile.SyncIniBool(Config, "Setup", "RunNpc", ref g_Config.boRunNpc);
            IniFile.SyncIniBool(Config, "Setup", "RunGuard", ref g_Config.boRunGuard);
            IniFile.SyncIniBool(Config, "Setup", "WarDisableHumanRun", ref g_Config.boWarDisHumRun);

            // 魔法盾效果 T-特色效果 F-盛大效果 20080808
            IniFile.SyncIniBool(Config, "Setup", "Skill31Effect", ref g_Config.boSkill31Effect);
            // 四级魔法盾抵御伤害百分率 20080829
            IniFile.SyncIniByte(Config, "Setup", "Skill66Rate", ref g_Config.nSkill66Rate);

            // 普通魔法盾抵御伤害百分率 20081226
            IniFile.SyncIniByte(Config, "Setup", "OrdinarySkill66Rate", ref g_Config.nOrdinarySkill66Rate);
            if (g_Config.nOrdinarySkill66Rate > 20)
            {
                g_Config.nOrdinarySkill66Rate = 20;
            }
            // 内功技能增强的攻防比率 
            IniFile.SyncIniUshort(Config, "Setup", "NGSkillRate", ref g_Config.nNGSkillRate);
            // 内功等级增加攻防的级数比率 
            IniFile.SyncIniByte(Config, "Setup", "NGLevelDamage", ref g_Config.nNGLevelDamage);
            // 内力值参数 
            IniFile.SyncIniByte(Config, "Setup", "Skill69NG", ref g_Config.nSkill69NG);
            // 主体内功经验参数 20081001
            IniFile.SyncIniUint(Config, "Setup", "Skill69NGExp", ref g_Config.nSkill69NGExp);
            // 英雄内功经验参数 20081001
            IniFile.SyncIniUint(Config, "Setup", "HeroSkill69NGExp", ref g_Config.nHeroSkill69NGExp);
            // 增加内力值间隔 20081002
            IniFile.SyncIniUint(Config, "Setup", "dwIncNHTime", ref g_Config.dwIncNHTime);
            // 饮酒增加内功经验 20081003
            IniFile.SyncIniUint(Config, "Setup", "DrinkIncNHExp", ref g_Config.nDrinkIncNHExp);
            // 内功抵御普通攻击消耗内力值 20081003
            IniFile.SyncIniUshort(Config, "Setup", "HitStruckDecNH", ref g_Config.nHitStruckDecNH);
            IniFile.SyncIniBool(Config, "Setup", "GMRunAll", ref g_Config.boGMRunAll);
            IniFile.SyncIniBool(Config, "Setup", "SafeAreaLimitedRun", ref g_Config.boSafeAreaLimited);
            IniFile.SyncIniByte(Config, "Setup", "BoneFammCount", ref g_Config.nBoneFammCount);

            for (I = g_Config.BoneFammArray.GetLowerBound(0); I <= g_Config.BoneFammArray.GetUpperBound(0); I++)
            {
                IniFile.SyncIniInt(Config, "Setup", "BoneFammHumLevel" + I, ref g_Config.BoneFammArray[I].nHumLevel);

                if (Config.ReadString("Names", "BoneFamm" + I, "") == "")
                {
                    Config.WriteString("Names", "BoneFamm" + I, g_Config.BoneFammArray[I].sMonName == null ? "" : g_Config.BoneFammArray[I].sMonName);
                }
                g_Config.BoneFammArray[I].sMonName = Config.ReadString("Names", "BoneFamm" + I, g_Config.BoneFammArray[I].sMonName);

                IniFile.SyncIniInt(Config, "Setup", "BoneFammCount" + I, ref g_Config.BoneFammArray[I].nCount);
                IniFile.SyncIniInt(Config, "Setup", "BoneFammLevel" + I, ref g_Config.BoneFammArray[I].nLevel);
            }
            IniFile.SyncIniByte(Config, "Setup", "DogzCount", ref g_Config.nDogzCount);

            for (I = g_Config.DogzArray.GetLowerBound(0); I <= g_Config.DogzArray.GetUpperBound(0); I++)
            {
                IniFile.SyncIniInt(Config, "Setup", "DogzHumLevel" + I, ref g_Config.DogzArray[I].nHumLevel);

                if (Config.ReadString("Names", "Dogz" + I, "") == "")
                {
                    Config.WriteString("Names", "Dogz" + I, g_Config.DogzArray[I].sMonName == null ? "" : g_Config.DogzArray[I].sMonName);
                }
                g_Config.DogzArray[I].sMonName = Config.ReadString("Names", "Dogz" + I, g_Config.DogzArray[I].sMonName);

                IniFile.SyncIniInt(Config, "Setup", "DogzCount" + I, ref g_Config.DogzArray[I].nCount);
                IniFile.SyncIniInt(Config, "Setup", "DogzLevel" + I, ref g_Config.DogzArray[I].nLevel);

            }
            // 月灵
            IniFile.SyncIniByte(Config, "Setup", "FairyCount", ref g_Config.nFairyCount);
            IniFile.SyncIniByte(Config, "Setup", "FairyDuntRate", ref g_Config.nFairyDuntRate);
            // 月灵重击次数,达到次数时按等级出重击 
            IniFile.SyncIniByte(Config, "Setup", "FairyDuntRateBelow", ref g_Config.nFairyDuntRateBelow);
            IniFile.SyncIniUshort(Config, "Setup", "FairyAttackRate", ref g_Config.nFairyAttackRate);

            // 开天斩重击几率 20080213
            IniFile.SyncIniByte(Config, "Setup", "43KillHitRate", ref g_Config.n43KillHitRate);
            // 开天斩重击倍数  20080213
            IniFile.SyncIniByte(Config, "Setup", "43KillAttackRate", ref g_Config.n43KillAttackRate);
            // 开天斩威力 20080213
            IniFile.SyncIniUshort(Config, "Setup", "AttackRate_43", ref g_Config.nAttackRate_43);
            // 烈火剑法威力倍数 20081208
            IniFile.SyncIniUshort(Config, "Setup", "AttackRate_26", ref g_Config.nAttackRate_26);
            // 逐日剑法威力倍数 20080511
            IniFile.SyncIniUshort(Config, "Setup", "AttackRate_74", ref g_Config.nAttackRate_74);

            for (I = g_Config.FairyArray.GetLowerBound(0); I <= g_Config.FairyArray.GetUpperBound(0); I++)
            {
                IniFile.SyncIniInt(Config, "Setup", "FairyHumLevel" + I, ref g_Config.FairyArray[I].nHumLevel);

                if (Config.ReadString("Names", "Fairy" + I, "") == "")
                {
                    Config.WriteString("Names", "Fairy" + I, g_Config.FairyArray[I].sMonName == null ? "" : g_Config.FairyArray[I].sMonName);
                }
                g_Config.FairyArray[I].sMonName = Config.ReadString("Names", "Fairy" + I, g_Config.FairyArray[I].sMonName);
                IniFile.SyncIniInt(Config, "Setup", "FairyCount" + I, ref g_Config.FairyArray[I].nCount);
                IniFile.SyncIniInt(Config, "Setup", "FairyLevel" + I, ref g_Config.FairyArray[I].nLevel);
            }
            IniFile.SyncIniUint(Config, "Setup", "TryDealTime", ref g_Config.dwTryDealTime);
            IniFile.SyncIniUint(Config, "Setup", "DealOKTime", ref g_Config.dwDealOKTime);
            IniFile.SyncIniBool(Config, "Setup", "CanNotGetBackDeal", ref g_Config.boCanNotGetBackDeal);
            IniFile.SyncIniBool(Config, "Setup", "DisableDeal", ref g_Config.boDisableDeal);
            // 可收徒弟数
            IniFile.SyncIniByte(Config, "Setup", "MasterCount", ref g_Config.nMasterCount);
            IniFile.SyncIniUshort(Config, "Setup", "MasterOKLevel", ref g_Config.nMasterOKLevel);
            IniFile.SyncIniByte(Config, "Setup", "MasterOKCreditPoint", ref g_Config.nMasterOKCreditPoint);
            IniFile.SyncIniUshort(Config, "Setup", "MasterOKBonusPoint", ref g_Config.nMasterOKBonusPoint);
            IniFile.SyncIniBool(Config, "Setup", "PKProtect", ref g_Config.boPKLevelProtect);
            IniFile.SyncIniUshort(Config, "Setup", "PKProtectLevel", ref g_Config.nPKProtectLevel);
            IniFile.SyncIniUshort(Config, "Setup", "RedPKProtectLevel", ref g_Config.nRedPKProtectLevel);
            IniFile.SyncIniUshort(Config, "Setup", "ItemPowerRate", ref g_Config.nItemPowerRate);
            IniFile.SyncIniUshort(Config, "Setup", "ItemExpRate", ref g_Config.nItemExpRate);
            IniFile.SyncIniUshort(Config, "Setup", "ScriptGotoCountLimit", ref g_Config.nScriptGotoCountLimit);
            IniFile.SyncIniByte(Config, "Setup", "HearMsgFColor", ref g_Config.btHearMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "HearMsgBColor", ref g_Config.btHearMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "WhisperMsgFColor", ref g_Config.btWhisperMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "WhisperMsgBColor", ref g_Config.btWhisperMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "GMWhisperMsgFColor", ref g_Config.btGMWhisperMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "GMWhisperMsgBColor", ref g_Config.btGMWhisperMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "CryMsgFColor", ref g_Config.btCryMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "CryMsgBColor", ref g_Config.btCryMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "GreenMsgFColor", ref g_Config.btGreenMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "GreenMsgBColor", ref g_Config.btGreenMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "BlueMsgFColor", ref g_Config.btBlueMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "BlueMsgBColor", ref g_Config.btBlueMsgBColor);
            // 千里传音
            IniFile.SyncIniByte(Config, "Setup", "SayMsgFColor", ref g_Config.btSayMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "SayeMsgBColor", ref g_Config.btSayeMsgBColor);
            // ---
            IniFile.SyncIniByte(Config, "Setup", "RedMsgFColor", ref g_Config.btRedMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "RedMsgBColor", ref g_Config.btRedMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "GuildMsgFColor", ref g_Config.btGuildMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "GuildMsgBColor", ref g_Config.btGuildMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "GroupMsgFColor", ref g_Config.btGroupMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "GroupMsgBColor", ref g_Config.btGroupMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "CustMsgFColor", ref g_Config.btCustMsgFColor);
            IniFile.SyncIniByte(Config, "Setup", "CustMsgBColor", ref g_Config.btCustMsgBColor);
            IniFile.SyncIniByte(Config, "Setup", "MonRandomAddValue", ref g_Config.nMonRandomAddValue);
            // 人形身上装备极品机率
            IniFile.SyncIniByte(Config, "Setup", "MakeRandomAddValue", ref g_Config.nMakeRandomAddValue);
            // -------------气血石配置------------------------------
            IniFile.SyncIniUshort(Config, "Setup", "StartHPRock", ref g_Config.nStartHPRock);
            IniFile.SyncIniByte(Config, "Setup", "RockAddHP", ref g_Config.nRockAddHP);
            IniFile.SyncIniUint(Config, "Setup", "HPRockSpell", ref g_Config.nHPRockSpell);
            IniFile.SyncIniInt(Config, "Setup", "HPRockDecDura", ref g_Config.nHPRockDecDura);
            IniFile.SyncIniUshort(Config, "Setup", "StartMPRock", ref g_Config.nStartMPRock);
            IniFile.SyncIniByte(Config, "Setup", "RockAddMP", ref g_Config.nRockAddMP);
            IniFile.SyncIniUint(Config, "Setup", "MPRockSpell", ref g_Config.nMPRockSpell);
            IniFile.SyncIniInt(Config, "Setup", "MPRockDecDura", ref g_Config.nMPRockDecDura);
            IniFile.SyncIniUshort(Config, "Setup", "StartHPMPRock", ref g_Config.nStartHPMPRock);
            IniFile.SyncIniByte(Config, "Setup", "RockAddHPMP", ref g_Config.nRockAddHPMP);
            IniFile.SyncIniUint(Config, "Setup", "HPMPRockSpell", ref g_Config.nHPMPRockSpell);
            IniFile.SyncIniInt(Config, "Setup", "HPMPRockDecDura", ref g_Config.nHPMPRockDecDura);
            // ---------------------------------------------
            IniFile.SyncIniByte(Config, "Setup", "WeaponDCAddValueMaxLimit", ref g_Config.nWeaponDCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "WeaponDCAddValueRate", ref g_Config.nWeaponDCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "WeaponMCAddValueMaxLimit", ref g_Config.nWeaponMCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "WeaponMCAddValueRate", ref g_Config.nWeaponMCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "WeaponSCAddValueMaxLimit", ref g_Config.nWeaponSCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "WeaponSCAddValueRate", ref g_Config.nWeaponSCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "WeaponDCAddRate", ref g_Config.nWeaponDCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "WeaponSCAddRate", ref g_Config.nWeaponSCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "WeaponMCAddRate", ref g_Config.nWeaponMCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "DressDCAddValueMaxLimit", ref g_Config.nDressDCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "DressDCAddValueRate", ref g_Config.nDressDCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "DressDCAddRate", ref g_Config.nDressDCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "DressMCAddValueMaxLimit", ref g_Config.nDressMCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "DressMCAddValueRate", ref g_Config.nDressMCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "DressMCAddRate", ref g_Config.nDressMCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "DressSCAddValueMaxLimit", ref g_Config.nDressSCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "DressSCAddValueRate", ref g_Config.nDressSCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "DressSCAddRate", ref g_Config.nDressSCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "DressACAddValueMaxLimit", ref g_Config.nDressACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "DressACAddValueRate", ref g_Config.nDressACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "DressACAddRate", ref g_Config.nDressACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "DressMACAddValueMaxLimit", ref g_Config.nDressMACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "DressMACAddValueRate", ref g_Config.nDressMACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "DressMACAddRate", ref g_Config.nDressMACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19DCAddValueMaxLimit", ref g_Config.nNeckLace19DCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19DCAddValueRate", ref g_Config.nNeckLace19DCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19DCAddRate", ref g_Config.nNeckLace19DCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19MCAddValueMaxLimit", ref g_Config.nNeckLace19MCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19MCAddValueRate", ref g_Config.nNeckLace19MCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19MCAddRate", ref g_Config.nNeckLace19MCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19SCAddValueMaxLimit", ref g_Config.nNeckLace19SCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19SCAddValueRate", ref g_Config.nNeckLace19SCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19SCAddRate", ref g_Config.nNeckLace19SCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19ACAddValueMaxLimit", ref g_Config.nNeckLace19ACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19ACAddValueRate", ref g_Config.nNeckLace19ACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19ACAddRate", ref g_Config.nNeckLace19ACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19MACAddValueMaxLimit", ref g_Config.nNeckLace19MACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19MACAddValueRate", ref g_Config.nNeckLace19MACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace19MACAddRate", ref g_Config.nNeckLace19MACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124DCAddValueMaxLimit", ref g_Config.nNeckLace202124DCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124DCAddValueRate", ref g_Config.nNeckLace202124DCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124DCAddRate", ref g_Config.nNeckLace202124DCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124MCAddValueMaxLimit", ref g_Config.nNeckLace202124MCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124MCAddValueRate", ref g_Config.nNeckLace202124MCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124MCAddRate", ref g_Config.nNeckLace202124MCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124SCAddValueMaxLimit", ref g_Config.nNeckLace202124SCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124SCAddValueRate", ref g_Config.nNeckLace202124SCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124SCAddRate", ref g_Config.nNeckLace202124SCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124ACAddValueMaxLimit", ref g_Config.nNeckLace202124ACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124ACAddValueRate", ref g_Config.nNeckLace202124ACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124ACAddRate", ref g_Config.nNeckLace202124ACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124MACAddValueMaxLimit", ref g_Config.nNeckLace202124MACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124MACAddValueRate", ref g_Config.nNeckLace202124MACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "NeckLace202124MACAddRate", ref g_Config.nNeckLace202124MACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26DCAddValueMaxLimit", ref g_Config.nArmRing26DCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26DCAddValueRate", ref g_Config.nArmRing26DCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26DCAddRate", ref g_Config.nArmRing26DCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26MCAddValueMaxLimit", ref g_Config.nArmRing26MCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26MCAddValueRate", ref g_Config.nArmRing26MCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26MCAddRate", ref g_Config.nArmRing26MCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26SCAddValueMaxLimit", ref g_Config.nArmRing26SCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26SCAddValueRate", ref g_Config.nArmRing26SCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26SCAddRate", ref g_Config.nArmRing26SCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26ACAddValueMaxLimit", ref g_Config.nArmRing26ACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26ACAddValueRate", ref g_Config.nArmRing26ACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26ACAddRate", ref g_Config.nArmRing26ACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26MACAddValueMaxLimit", ref g_Config.nArmRing26MACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26MACAddValueRate", ref g_Config.nArmRing26MACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "ArmRing26MACAddRate", ref g_Config.nArmRing26MACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring22DCAddValueMaxLimit", ref g_Config.nRing22DCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring22DCAddValueRate", ref g_Config.nRing22DCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring22DCAddRate", ref g_Config.nRing22DCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring22MCAddValueMaxLimit", ref g_Config.nRing22MCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring22MCAddValueRate", ref g_Config.nRing22MCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring22MCAddRate", ref g_Config.nRing22MCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring22SCAddValueMaxLimit", ref g_Config.nRing22SCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring22SCAddValueRate", ref g_Config.nRing22SCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring22SCAddRate", ref g_Config.nRing22SCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23DCAddValueMaxLimit", ref g_Config.nRing23DCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring23DCAddValueRate", ref g_Config.nRing23DCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23DCAddRate", ref g_Config.nRing23DCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23MCAddValueMaxLimit", ref g_Config.nRing23MCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring23MCAddValueRate", ref g_Config.nRing23MCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23MCAddRate", ref g_Config.nRing23MCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23SCAddValueMaxLimit", ref g_Config.nRing23SCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring23SCAddValueRate", ref g_Config.nRing23SCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23SCAddRate", ref g_Config.nRing23SCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23ACAddValueMaxLimit", ref g_Config.nRing23ACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring23ACAddValueRate", ref g_Config.nRing23ACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23ACAddRate", ref g_Config.nRing23ACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23MACAddValueMaxLimit", ref g_Config.nRing23MACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "Ring23MACAddValueRate", ref g_Config.nRing23MACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "Ring23MACAddRate", ref g_Config.nRing23MACAddRate);
            // ------------------------------------------------------------------------------
            // 20080503 极品鞋子加攻最高点
            IniFile.SyncIniByte(Config, "Setup", "BootsDCAddValueMaxLimit", ref g_Config.nBootsDCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "BootsDCAddValueRate", ref g_Config.nBootsDCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "BootsDCAddRate", ref g_Config.nBootsDCAddRate);
            // 道术
            IniFile.SyncIniByte(Config, "Setup", "BootsSCAddValueMaxLimit", ref g_Config.nBootsSCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "BootsSCAddValueRate", ref g_Config.nBootsSCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "BootsSCAddRate", ref g_Config.nBootsSCAddRate);
            // 魔法
            IniFile.SyncIniByte(Config, "Setup", "BootsMCAddValueMaxLimit", ref g_Config.nBootsMCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "BootsMCAddValueRate", ref g_Config.nBootsMCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "BootsMCAddRate", ref g_Config.nBootsMCAddRate);
            // 防御
            IniFile.SyncIniByte(Config, "Setup", "BootsACAddValueMaxLimit", ref g_Config.nBootsACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "BootsACAddValueRate", ref g_Config.nBootsACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "BootsACAddRate", ref g_Config.nBootsACAddRate);
            // 魔御
            IniFile.SyncIniByte(Config, "Setup", "BootsMACAddValueMaxLimit", ref g_Config.nBootsMACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "BootsMACAddValueRate", ref g_Config.nBootsMACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "BootsMACAddRate", ref g_Config.nBootsMACAddRate);
            // ------------------------------------------------------------------------------
            IniFile.SyncIniByte(Config, "Setup", "HelMetDCAddValueMaxLimit", ref g_Config.nHelMetDCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "HelMetDCAddValueRate", ref g_Config.nHelMetDCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetDCAddRate", ref g_Config.nHelMetDCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetMCAddValueMaxLimit", ref g_Config.nHelMetMCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "HelMetMCAddValueRate", ref g_Config.nHelMetMCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetMCAddRate", ref g_Config.nHelMetMCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetSCAddValueMaxLimit", ref g_Config.nHelMetSCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "HelMetSCAddValueRate", ref g_Config.nHelMetSCAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetSCAddRate", ref g_Config.nHelMetSCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetACAddValueMaxLimit", ref g_Config.nHelMetACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "HelMetACAddValueRate", ref g_Config.nHelMetACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetACAddRate", ref g_Config.nHelMetACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetMACAddValueMaxLimit", ref g_Config.nHelMetMACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "HelMetMACAddValueRate", ref g_Config.nHelMetMACAddValueRate);
            IniFile.SyncIniByte(Config, "Setup", "HelMetMACAddRate", ref g_Config.nHelMetMACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetACAddRate", ref g_Config.nUnknowHelMetACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetACAddValueMaxLimit", ref g_Config.nUnknowHelMetACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetMACAddRate", ref g_Config.nUnknowHelMetMACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetMACAddValueMaxLimit", ref g_Config.nUnknowHelMetMACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetDCAddRate", ref g_Config.nUnknowHelMetDCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetDCAddValueMaxLimit", ref g_Config.nUnknowHelMetDCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetMCAddRate", ref g_Config.nUnknowHelMetMCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetMCAddValueMaxLimit", ref g_Config.nUnknowHelMetMCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetSCAddRate", ref g_Config.nUnknowHelMetSCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowHelMetSCAddValueMaxLimit", ref g_Config.nUnknowHelMetSCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceACAddRate", ref g_Config.nUnknowNecklaceACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceACAddValueMaxLimit", ref g_Config.nUnknowNecklaceACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceMACAddRate", ref g_Config.nUnknowNecklaceMACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceMACAddValueMaxLimit", ref g_Config.nUnknowNecklaceMACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceDCAddRate", ref g_Config.nUnknowNecklaceDCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceDCAddValueMaxLimit", ref g_Config.nUnknowNecklaceDCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceMCAddRate", ref g_Config.nUnknowNecklaceMCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceMCAddValueMaxLimit", ref g_Config.nUnknowNecklaceMCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceSCAddRate", ref g_Config.nUnknowNecklaceSCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowNecklaceSCAddValueMaxLimit", ref g_Config.nUnknowNecklaceSCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingACAddRate", ref g_Config.nUnknowRingACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingACAddValueMaxLimit", ref g_Config.nUnknowRingACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingMACAddRate", ref g_Config.nUnknowRingMACAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingMACAddValueMaxLimit", ref g_Config.nUnknowRingMACAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingDCAddRate", ref g_Config.nUnknowRingDCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingDCAddValueMaxLimit", ref g_Config.nUnknowRingDCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingMCAddRate", ref g_Config.nUnknowRingMCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingMCAddValueMaxLimit", ref g_Config.nUnknowRingMCAddValueMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingSCAddRate", ref g_Config.nUnknowRingSCAddRate);
            IniFile.SyncIniByte(Config, "Setup", "UnknowRingSCAddValueMaxLimit", ref g_Config.nUnknowRingSCAddValueMaxLimit);
            IniFile.SyncIniInt(Config, "Setup", "MonOneDropGoldCount", ref g_Config.nMonOneDropGoldCount);
            IniFile.SyncIniUshort(Config, "Setup", "MakeMineHitRate", ref g_Config.nMakeMineHitRate);
            IniFile.SyncIniUshort(Config, "Setup", "MakeMineRate", ref g_Config.nMakeMineRate);
            IniFile.SyncIniUshort(Config, "Setup", "StoneTypeRate", ref g_Config.nStoneTypeRate);
            IniFile.SyncIniUshort(Config, "Setup", "StoneTypeRateMin", ref g_Config.nStoneTypeRateMin);
            IniFile.SyncIniUshort(Config, "Setup", "GoldStoneMin", ref g_Config.nGoldStoneMin);
            IniFile.SyncIniUshort(Config, "Setup", "GoldStoneMax", ref g_Config.nGoldStoneMax);
            IniFile.SyncIniUshort(Config, "Setup", "SilverStoneMin", ref g_Config.nSilverStoneMin);
            IniFile.SyncIniUshort(Config, "Setup", "SilverStoneMax", ref g_Config.nSilverStoneMax);
            IniFile.SyncIniUshort(Config, "Setup", "SteelStoneMin", ref g_Config.nSteelStoneMin);
            IniFile.SyncIniUshort(Config, "Setup", "SteelStoneMax", ref g_Config.nSteelStoneMax);
            IniFile.SyncIniUshort(Config, "Setup", "BlackStoneMin", ref g_Config.nBlackStoneMin);
            IniFile.SyncIniUshort(Config, "Setup", "BlackStoneMax", ref g_Config.nBlackStoneMax);
            IniFile.SyncIniUshort(Config, "Setup", "StoneMinDura", ref g_Config.nStoneMinDura);
            IniFile.SyncIniUshort(Config, "Setup", "StoneGeneralDuraRate", ref g_Config.nStoneGeneralDuraRate);
            IniFile.SyncIniUshort(Config, "Setup", "StoneAddDuraRate", ref g_Config.nStoneAddDuraRate);
            IniFile.SyncIniUshort(Config, "Setup", "StoneAddDuraMax", ref g_Config.nStoneAddDuraMax);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery1Min", ref g_Config.nWinLottery1Min);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery1Max", ref g_Config.nWinLottery1Max);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery2Min", ref g_Config.nWinLottery2Min);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery2Max", ref g_Config.nWinLottery2Max);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery3Min", ref g_Config.nWinLottery3Min);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery3Max", ref g_Config.nWinLottery3Max);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery4Min", ref g_Config.nWinLottery4Min);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery4Max", ref g_Config.nWinLottery4Max);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery5Min", ref g_Config.nWinLottery5Min);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery5Min", ref g_Config.nWinLottery5Max);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery6Min", ref g_Config.nWinLottery6Min);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery6Max", ref g_Config.nWinLottery6Max);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryRate", ref g_Config.nWinLotteryRate);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery1Gold", ref g_Config.nWinLottery1Gold);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery2Gold", ref g_Config.nWinLottery2Gold);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery3Gold", ref g_Config.nWinLottery3Gold);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery4Gold", ref g_Config.nWinLottery4Gold);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery5Gold", ref g_Config.nWinLottery5Gold);
            IniFile.SyncIniInt(Config, "Setup", "WinLottery6Gold", ref g_Config.nWinLottery6Gold);
            IniFile.SyncIniUshort(Config, "Setup", "GuildRecallTime", ref g_Config.nGuildRecallTime);
            IniFile.SyncIniUshort(Config, "Setup", "GroupRecallTime", ref g_Config.nGroupRecallTime);
            IniFile.SyncIniBool(Config, "Setup", "ControlDropItem", ref g_Config.boControlDropItem);
            IniFile.SyncIniBool(Config, "Setup", "InSafeDisableDrop", ref g_Config.boInSafeDisableDrop);
            IniFile.SyncIniInt(Config, "Setup", "CanDropGold", ref g_Config.nCanDropGold);
            IniFile.SyncIniInt(Config, "Setup", "CanDropPrice", ref g_Config.nCanDropPrice);
            IniFile.SyncIniBool(Config, "Setup", "SendCustemMsg", ref g_Config.boSendCustemMsg);
            IniFile.SyncIniBool(Config, "Setup", "SubkMasterSendMsg", ref g_Config.boSubkMasterSendMsg);
            IniFile.SyncIniByte(Config, "Setup", "SuperRepairPriceRate", ref g_Config.nSuperRepairPriceRate);
            IniFile.SyncIniByte(Config, "Setup", "RepairItemDecDura", ref g_Config.nRepairItemDecDura);
            IniFile.SyncIniBool(Config, "Setup", "DieScatterBag", ref g_Config.boDieScatterBag);
            IniFile.SyncIniUshort(Config, "Setup", "DieScatterBagRate", ref g_Config.nDieScatterBagRate);
            IniFile.SyncIniBool(Config, "Setup", "DieRedScatterBagAll", ref g_Config.boDieRedScatterBagAll);
            IniFile.SyncIniUshort(Config, "Setup", "DieDropUseItemRate", ref g_Config.nDieDropUseItemRate);
            IniFile.SyncIniByte(Config, "Setup", "DieRedDropUseItemRate", ref g_Config.nDieRedDropUseItemRate);
            IniFile.SyncIniBool(Config, "Setup", "DieDropGold", ref g_Config.boDieDropGold);
            IniFile.SyncIniBool(Config, "Setup", "KillByHumanDropUseItem", ref g_Config.boKillByHumanDropUseItem);
            IniFile.SyncIniBool(Config, "Setup", "KillByMonstDropUseItem", ref g_Config.boKillByMonstDropUseItem);
            IniFile.SyncIniBool(Config, "Setup", "KickExpireHuman", ref g_Config.boKickExpireHuman);
            IniFile.SyncIniUshort(Config, "Setup", "GuildRankNameLen", ref g_Config.nGuildRankNameLen);
            IniFile.SyncIniUshort(Config, "Setup", "GuildNameLen", ref g_Config.nGuildNameLen);
            IniFile.SyncIniUshort(Config, "Setup", "GuildMemberMaxLimit", ref g_Config.nGuildMemberMaxLimit);
            IniFile.SyncIniByte(Config, "Setup", "AttackPosionRate", ref g_Config.nAttackPosionRate);
            IniFile.SyncIniByte(Config, "Setup", "AttackPosionTime", ref g_Config.nAttackPosionTime);
            IniFile.SyncIniUint(Config, "Setup", "RevivalTime", ref g_Config.dwRevivalTime);
            IniFile.SyncIniBool(Config, "Setup", "UserMoveCanDupObj", ref g_Config.boUserMoveCanDupObj);
            IniFile.SyncIniBool(Config, "Setup", "UserMoveCanOnItem", ref g_Config.boUserMoveCanOnItem);
            IniFile.SyncIniByte(Config, "Setup", "UserMoveTime", ref g_Config.dwUserMoveTime);
            IniFile.SyncIniUint(Config, "Setup", "PKDieLostExpRate", ref g_Config.dwPKDieLostExpRate);
            IniFile.SyncIniInt(Config, "Setup", "PKDieLostLevelRate", ref g_Config.nPKDieLostLevelRate);
            IniFile.SyncIniUshort(Config, "Setup", "ChallengeTime", ref g_Config.nChallengeTime);
            IniFile.SyncIniByte(Config, "Setup", "NPCNameColor", ref g_Config.btNPCNameColor);
            IniFile.SyncIniByte(Config, "Setup", "PKFlagNameColor", ref g_Config.btPKFlagNameColor);
            IniFile.SyncIniByte(Config, "Setup", "AllyAndGuildNameColor", ref g_Config.btAllyAndGuildNameColor);
            IniFile.SyncIniByte(Config, "Setup", "WarGuildNameColor", ref g_Config.btWarGuildNameColor);
            IniFile.SyncIniByte(Config, "Setup", "InFreePKAreaNameColor", ref g_Config.btInFreePKAreaNameColor);
            IniFile.SyncIniByte(Config, "Setup", "PKLevel1NameColor", ref g_Config.btPKLevel1NameColor);
            IniFile.SyncIniByte(Config, "Setup", "PKLevel2NameColor", ref g_Config.btPKLevel2NameColor);
            IniFile.SyncIniBool(Config, "Setup", "SpiritMutiny", ref g_Config.boSpiritMutiny);
            IniFile.SyncIniUint(Config, "Setup", "SpiritMutinyTime", ref g_Config.dwSpiritMutinyTime);
            IniFile.SyncIniBool(Config, "Setup", "MasterDieMutiny", ref g_Config.boMasterDieMutiny);
            IniFile.SyncIniUshort(Config, "Setup", "MasterDieMutinyRate", ref g_Config.nMasterDieMutinyRate);
            IniFile.SyncIniUshort(Config, "Setup", "MasterDieMutinyPower", ref g_Config.nMasterDieMutinyPower);
            IniFile.SyncIniUshort(Config, "Setup", "MasterDieMutinySpeed", ref g_Config.nMasterDieMutinySpeed);
            IniFile.SyncIniBool(Config, "Setup", "BBMonAutoChangeColor", ref g_Config.boBBMonAutoChangeColor);
            IniFile.SyncIniInt(Config, "Setup", "BBMonAutoChangeColorTime", ref g_Config.dwBBMonAutoChangeColorTime);
            IniFile.SyncIniBool(Config, "Setup", "OldClientShowHiLevel", ref g_Config.boOldClientShowHiLevel);
            IniFile.SyncIniBool(Config, "Setup", "ShowScriptActionMsg", ref g_Config.boShowScriptActionMsg);
            IniFile.SyncIniBool(Config, "Setup", "ThreadRun", ref g_Config.boThreadRun);
            IniFile.SyncIniByte(Config, "Setup", "DeathColorEffect", ref g_Config.ClientConf.btDieColor);
            IniFile.SyncIniBool(Config, "Setup", "ParalyCanRun", ref g_Config.ClientConf.boParalyCanRun);
            IniFile.SyncIniBool(Config, "Setup", "ParalyCanWalk", ref g_Config.ClientConf.boParalyCanWalk);
            IniFile.SyncIniBool(Config, "Setup", "ParalyCanHit", ref g_Config.ClientConf.boParalyCanHit);
            IniFile.SyncIniBool(Config, "Setup", "ParalyCanSpell", ref g_Config.ClientConf.boParalyCanSpell);
            IniFile.SyncIniBool(Config, "Setup", "ShowExceptionMsg", ref g_Config.boShowExceptionMsg);
            IniFile.SyncIniBool(Config, "Setup", "ShowPreFixMsg", ref g_Config.boShowPreFixMsg);
            // GM命令错误是否提示 20080602
            IniFile.SyncIniBool(Config, "Setup", "GMShowFailMsg", ref g_Config.boGMShowFailMsg);
            // 记录人物私聊，行会聊天信息 20081213
            IniFile.SyncIniBool(Config, "Setup", "RecordClientMsg", ref g_Config.boRecordClientMsg);
            IniFile.SyncIniUshort(Config, "Setup", "MagTurnUndeadLevel", ref g_Config.nMagTurnUndeadLevel);
            IniFile.SyncIniUshort(Config, "Setup", "MagTammingLevel", ref g_Config.nMagTammingLevel);
            IniFile.SyncIniUshort(Config, "Setup", "MagTammingTargetLevel", ref g_Config.nMagTammingTargetLevel);
            IniFile.SyncIniUshort(Config, "Setup", "MagTammingTargetHPRate", ref g_Config.nMagTammingHPRate);
            IniFile.SyncIniUshort(Config, "Setup", "MagTammingCount", ref g_Config.nMagTammingCount);
            IniFile.SyncIniByte(Config, "Setup", "MabMabeHitRandRate", ref g_Config.nMabMabeHitRandRate);
            IniFile.SyncIniByte(Config, "Setup", "MabMabeHitMinLvLimit", ref g_Config.nMabMabeHitMinLvLimit);
            IniFile.SyncIniByte(Config, "Setup", "MabMabeHitSucessRate", ref g_Config.nMabMabeHitSucessRate);
            IniFile.SyncIniByte(Config, "Setup", "MabMabeHitMabeTimeRate", ref g_Config.nMabMabeHitMabeTimeRate);
            IniFile.SyncIniByte(Config, "Setup", "MagicAttackRage", ref g_Config.nMagicAttackRage);
            IniFile.SyncIniByte(Config, "Setup", "AmyOunsulPoint", ref g_Config.nAmyOunsulPoint);
            IniFile.SyncIniBool(Config, "Setup", "DisableInSafeZoneFireCross", ref g_Config.boDisableInSafeZoneFireCross);
            IniFile.SyncIniBool(Config, "Setup", "GroupMbAttackPlayObject", ref g_Config.boGroupMbAttackPlayObject);
            IniFile.SyncIniUint(Config, "Setup", "PosionDecHealthTime", ref g_Config.dwPosionDecHealthTime);
            IniFile.SyncIniUshort(Config, "Setup", "PosionDamagarmor", ref g_Config.nPosionDamagarmor);
            IniFile.SyncIniBool(Config, "Setup", "LimitSwordLong", ref g_Config.boLimitSwordLong);
            IniFile.SyncIniUshort(Config, "Setup", "SwordLongPowerRate", ref g_Config.nSwordLongPowerRate);
            IniFile.SyncIniByte(Config, "Setup", "FireBoomRage", ref g_Config.nFireBoomRage);
            IniFile.SyncIniByte(Config, "Setup", "SnowWindRange", ref g_Config.nSnowWindRange);
            // 流星火雨攻击范围 20080510
            IniFile.SyncIniByte(Config, "Setup", "MeteorFireRainRage", ref g_Config.nMeteorFireRainRage);
            // 噬血术加血百分率 20080511
            IniFile.SyncIniByte(Config, "Setup", "MagFireCharmTreatment", ref g_Config.nMagFireCharmTreatment);
            IniFile.SyncIniByte(Config, "Setup", "ElecBlizzardRange", ref g_Config.nElecBlizzardRange);
            IniFile.SyncIniUshort(Config, "Setup", "HumanLevelDiffer", ref g_Config.nHumanLevelDiffer);
            IniFile.SyncIniBool(Config, "Setup", "KillHumanWinLevel", ref g_Config.boKillHumanWinLevel);
            IniFile.SyncIniBool(Config, "Setup", "KilledLostLevel", ref g_Config.boKilledLostLevel);
            IniFile.SyncIniUshort(Config, "Setup", "KillHumanWinLevelPoint", ref g_Config.nKillHumanWinLevel);
            IniFile.SyncIniUshort(Config, "Setup", "KilledLostLevelPoint", ref g_Config.nKilledLostLevel);
            IniFile.SyncIniBool(Config, "Setup", "KillHumanWinExp", ref g_Config.boKillHumanWinExp);
            IniFile.SyncIniBool(Config, "Setup", "KilledLostExp", ref g_Config.boKilledLostExp);
            IniFile.SyncIniUint(Config, "Setup", "KillHumanWinExpPoint", ref g_Config.nKillHumanWinExp);
            IniFile.SyncIniUint(Config, "Setup", "KillHumanLostExpPoint", ref g_Config.nKillHumanLostExp);
            IniFile.SyncIniUshort(Config, "Setup", "MonsterPowerRate", ref g_Config.nMonsterPowerRate);
            IniFile.SyncIniInt(Config, "Setup", "ItemsPowerRate", ref g_Config.nItemsPowerRate);
            IniFile.SyncIniUshort(Config, "Setup", "ItemsACPowerRate", ref g_Config.nItemsACPowerRate);
            IniFile.SyncIniBool(Config, "Setup", "SendOnlineCount", ref g_Config.boSendOnlineCount);
            IniFile.SyncIniByte(Config, "Setup", "SendOnlineCountRate", ref g_Config.nSendOnlineCountRate);
            IniFile.SyncIniUint(Config, "Setup", "SendOnlineTime", ref g_Config.dwSendOnlineTime);
            IniFile.SyncIniUint(Config, "Setup", "SaveHumanRcdTime", ref g_Config.dwSaveHumanRcdTime);
            IniFile.SyncIniUint(Config, "Setup", "HumanFreeDelayTime", ref g_Config.dwHumanFreeDelayTime);
            // 尸体清理时间
            IniFile.SyncIniUint(Config, "Setup", "MakeGhostTime", ref g_Config.dwMakeGhostTime);
            // 人形怪尸体清理时间 20080418
            IniFile.SyncIniUint(Config, "Setup", "MakeGhostPlayMosterTime", ref g_Config.dwMakeGhostPlayMosterTime);
            IniFile.SyncIniUint(Config, "Setup", "ClearDropOnFloorItemTime", ref g_Config.dwClearDropOnFloorItemTime);
            IniFile.SyncIniUint(Config, "Setup", "FloorItemCanPickUpTime", ref g_Config.dwFloorItemCanPickUpTime);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockSystem", ref g_Config.boPasswordLockSystem);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockDealAction", ref g_Config.boLockDealAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockDropAction", ref g_Config.boLockDropAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockGetBackItemAction", ref g_Config.boLockGetBackItemAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockHumanLogin", ref g_Config.boLockHumanLogin);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockWalkAction", ref g_Config.boLockWalkAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockRunAction", ref g_Config.boLockRunAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockHitAction", ref g_Config.boLockHitAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockSpellAction", ref g_Config.boLockSpellAction);

            // 是否锁定召唤英雄操作  20080529
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockCallHeroAction", ref g_Config.boLockCallHeroAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockSendMsgAction", ref g_Config.boLockSendMsgAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockUserItemAction", ref g_Config.boLockUserItemAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordLockInObModeAction", ref g_Config.boLockInObModeAction);
            IniFile.SyncIniBool(Config, "Setup", "PasswordErrorKick", ref g_Config.boPasswordErrorKick);
            IniFile.SyncIniByte(Config, "Setup", "PasswordErrorCountLock", ref g_Config.nPasswordErrorCountLock);
            IniFile.SyncIniInt(Config, "Setup", "SoftVersionDate", ref g_Config.nSoftVersionDate);
            IniFile.SyncIniBool(Config, "Setup", "CanOldClientLogon", ref g_Config.boCanOldClientLogon);
            IniFile.SyncIniUint(Config, "Setup", "ConsoleShowUserCountTime", ref g_Config.dwConsoleShowUserCountTime);
            IniFile.SyncIniUint(Config, "Setup", "ShowLineNoticeTime", ref g_Config.dwShowLineNoticeTime);
            IniFile.SyncIniByte(Config, "Setup", "LineNoticeColor", ref g_Config.nLineNoticeColor);
            IniFile.SyncIniByte(Config, "Setup", "ItemSpeedTime", ref g_Config.ClientConf.btItemSpeed);
            IniFile.SyncIniByte(Config, "Setup", "MaxHitMsgCount", ref g_Config.nMaxHitMsgCount);
            IniFile.SyncIniByte(Config, "Setup", "MaxSpellMsgCount", ref g_Config.nMaxSpellMsgCount);
            IniFile.SyncIniByte(Config, "Setup", "MaxRunMsgCount", ref g_Config.nMaxRunMsgCount);
            IniFile.SyncIniByte(Config, "Setup", "MaxWalkMsgCount", ref g_Config.nMaxWalkMsgCount);
            IniFile.SyncIniByte(Config, "Setup", "MaxTurnMsgCount", ref g_Config.nMaxTurnMsgCount);
            IniFile.SyncIniByte(Config, "Setup", "MaxSitDonwMsgCount", ref g_Config.nMaxSitDonwMsgCount);
            IniFile.SyncIniByte(Config, "Setup", "MaxDigUpMsgCount", ref g_Config.nMaxDigUpMsgCount);
            IniFile.SyncIniBool(Config, "Setup", "SpellSendUpdateMsg", ref g_Config.boSpellSendUpdateMsg);
            IniFile.SyncIniBool(Config, "Setup", "ActionSendActionMsg", ref g_Config.boActionSendActionMsg);
            IniFile.SyncIniByte(Config, "Setup", "OverSpeedKickCount", ref g_Config.nOverSpeedKickCount);
            IniFile.SyncIniUint(Config, "Setup", "DropOverSpeed", ref g_Config.dwDropOverSpeed);
            IniFile.SyncIniBool(Config, "Setup", "KickOverSpeed", ref g_Config.boKickOverSpeed);
            IniFile.SyncIniByte(Config, "Setup", "SpeedControlMode", ref g_Config.btSpeedControlMode);
            IniFile.SyncIniUint(Config, "Setup", "HitIntervalTime", ref g_Config.dwHitIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "MagicHitIntervalTime", ref g_Config.dwMagicHitIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "RunIntervalTime", ref g_Config.dwRunIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "WalkIntervalTime", ref g_Config.dwWalkIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "TurnIntervalTime", ref g_Config.dwTurnIntervalTime);
            IniFile.SyncIniBool(Config, "Setup", "ControlActionInterval", ref g_Config.boControlActionInterval);
            IniFile.SyncIniBool(Config, "Setup", "ControlWalkHit", ref g_Config.boControlWalkHit);
            IniFile.SyncIniBool(Config, "Setup", "ControlRunLongHit", ref g_Config.boControlRunLongHit);
            IniFile.SyncIniBool(Config, "Setup", "ControlRunHit", ref g_Config.boControlRunHit);
            IniFile.SyncIniBool(Config, "Setup", "ControlRunMagic", ref g_Config.boControlRunMagic);
            IniFile.SyncIniUint(Config, "Setup", "ActionIntervalTime", ref g_Config.dwActionIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "RunLongHitIntervalTime", ref g_Config.dwRunLongHitIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "RunHitIntervalTime", ref g_Config.dwRunHitIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "WalkHitIntervalTime", ref g_Config.dwWalkHitIntervalTime);
            IniFile.SyncIniUint(Config, "Setup", "RunMagicIntervalTime", ref g_Config.dwRunMagicIntervalTime);
            IniFile.SyncIniBool(Config, "Setup", "DisableStruck", ref g_Config.boDisableStruck);
            IniFile.SyncIniBool(Config, "Setup", "DisableSelfStruck", ref g_Config.boDisableSelfStruck);
            IniFile.SyncIniUint(Config, "Setup", "StruckTime", ref g_Config.dwStruckTime);
            IniFile.SyncIniBool(Config, "Setup", "AddUserItemNewValue", ref g_Config.boAddUserItemNewValue);
            IniFile.SyncIniBool(Config, "Setup", "TestSpeedMode", ref g_Config.boTestSpeedMode);
            IniFile.SyncIniUshort(Config, "Setup", "WeaponMakeUnLuckRate", ref g_Config.nWeaponMakeUnLuckRate);
            IniFile.SyncIniUshort(Config, "Setup", "WeaponMakeLuckPoint1", ref g_Config.nWeaponMakeLuckPoint1);
            IniFile.SyncIniUshort(Config, "Setup", "WeaponMakeLuckPoint2", ref g_Config.nWeaponMakeLuckPoint2);
            IniFile.SyncIniUshort(Config, "Setup", "WeaponMakeLuckPoint3", ref g_Config.nWeaponMakeLuckPoint3);
            IniFile.SyncIniUshort(Config, "Setup", "WeaponMakeLuckPoint2Rate", ref g_Config.nWeaponMakeLuckPoint2Rate);
            IniFile.SyncIniUshort(Config, "Setup", "WeaponMakeLuckPoint3Rate", ref g_Config.nWeaponMakeLuckPoint3Rate);
            IniFile.SyncIniBool(Config, "Setup", "CheckUserItemPlace", ref g_Config.boCheckUserItemPlace);
            IniFile.SyncIniUshort(Config, "Setup", "LevelValueOfTaosHP", ref g_Config.nLevelValueOfTaosHP);
            IniFile.SyncIniDouble(Config, "Setup", "LevelValueOfTaosHPRate", ref g_Config.nLevelValueOfTaosHPRate);
            IniFile.SyncIniUshort(Config, "Setup", "LevelValueOfTaosMP", ref g_Config.nLevelValueOfTaosMP);
            IniFile.SyncIniUshort(Config, "Setup", "LevelValueOfWizardHP", ref g_Config.nLevelValueOfWizardHP);
            IniFile.SyncIniDouble(Config, "Setup", "LevelValueOfWizardHPRate", ref g_Config.nLevelValueOfWizardHPRate);
            IniFile.SyncIniUshort(Config, "Setup", "LevelValueOfWarrHP", ref g_Config.nLevelValueOfWarrHP);
            IniFile.SyncIniDouble(Config, "Setup", "LevelValueOfWarrHPRate", ref g_Config.nLevelValueOfWarrHPRate);
            IniFile.SyncIniSbyte(Config, "Setup", "ProcessMonsterInterval", ref g_Config.nProcessMonsterInterval);
            IniFile.SyncIniByte(Config, "Setup", "StartCastleWarDays", ref g_Config.nStartCastleWarDays);
            IniFile.SyncIniByte(Config, "Setup", "StartCastlewarTime", ref g_Config.nStartCastlewarTime);
            IniFile.SyncIniUint(Config, "Setup", "ShowCastleWarEndMsgTime", ref g_Config.dwShowCastleWarEndMsgTime);
            IniFile.SyncIniUint(Config, "Setup", "CastleWarTime", ref g_Config.dwCastleWarTime);
            IniFile.SyncIniUint(Config, "Setup", "GetCastleTime", ref g_Config.dwGetCastleTime);
            IniFile.SyncIniUint(Config, "Setup", "GuildWarTime", ref g_Config.dwGuildWarTime);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryCount", ref g_Config.nWinLotteryCount);
            IniFile.SyncIniInt(Config, "Setup", "NoWinLotteryCount", ref g_Config.nNoWinLotteryCount);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryLevel1", ref g_Config.nWinLotteryLevel1);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryLevel2", ref g_Config.nWinLotteryLevel2);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryLevel3", ref g_Config.nWinLotteryLevel3);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryLevel4", ref g_Config.nWinLotteryLevel4);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryLevel5", ref g_Config.nWinLotteryLevel5);
            IniFile.SyncIniInt(Config, "Setup", "WinLotteryLevel6", ref g_Config.nWinLotteryLevel6);
            IniFile.SyncIniUshort(Config, "Setup", "DecUserGameGold", ref g_Config.nDecUserGameGold);
            IniFile.SyncIniInt(Config, "Setup", "MakeWineTime", ref g_Config.nMakeWineTime);
            IniFile.SyncIniInt(Config, "Setup", "MakeWineTime1", ref g_Config.nMakeWineTime1);
            // 酿酒获得酒曲机率 20080621
            IniFile.SyncIniByte(Config, "Setup", "MakeWineRate", ref g_Config.nMakeWineRate);
            // 增加酒量进度的间隔时间 20080623
            IniFile.SyncIniInt(Config, "Setup", "IncAlcoholTick", ref g_Config.nIncAlcoholTick);
            // 减少醉酒度的间隔时间 20080623
            IniFile.SyncIniInt(Config, "Setup", "DesDrinkTick", ref g_Config.nDesDrinkTick);
            // 酒量上限初始值 20080623
            IniFile.SyncIniUshort(Config, "Setup", "MaxAlcoholValue", ref g_Config.nMaxAlcoholValue);
            // 升级后增加酒量上限值 20080623
            IniFile.SyncIniUshort(Config, "Setup", "IncAlcoholValue", ref g_Config.nIncAlcoholValue);
            // 长时间不使用酒,减药力值 20080623
            IniFile.SyncIniUshort(Config, "Setup", "DesMedicineValue", ref g_Config.nDesMedicineValue);
            // 减药力值时间间隔 20080624
            IniFile.SyncIniUshort(Config, "Setup", "DesMedicineTick", ref g_Config.nDesMedicineTick);
            // 站在泉眼上的累积时间(秒) 20080624
            IniFile.SyncIniUshort(Config, "Setup", "InFountainTime", ref g_Config.nInFountainTime);
            // 行会酒泉蓄量少于时,不能领取 20080627
            IniFile.SyncIniUshort(Config, "Setup", "MinGuildFountain", ref g_Config.nMinGuildFountain);
            // 行会成员领取酒泉,蓄量减少 20080627
            IniFile.SyncIniUshort(Config, "Setup", "DecGuildFountain", ref g_Config.nDecGuildFountain);
            // 天地结晶英雄分配比例 20090202
            IniFile.SyncIniByte(Config, "Setup", "HeroCrystalExpRate", ref g_Config.nHeroCrystalExpRate);
            IniFile.SyncIniBool(Config, "Setup", "PullPlayObject", ref g_Config.boPullPlayObject);
            IniFile.SyncIniBool(Config, "Setup", "GroupMbAttackPlayObject", ref g_Config.boGroupMbAttackPlayObject);
            IniFile.SyncIniBool(Config, "Setup", "DamageMP", ref g_Config.boPlayObjectReduceMP);
            IniFile.SyncIniBool(Config, "Setup", "GroupMbAttackSlave", ref g_Config.boGroupMbAttackSlave);
            IniFile.SyncIniUshort(Config, "Setup", "BigStorageLimitCount", ref g_Config.nBigStorageLimitCount);
            IniFile.SyncIniBool(Config, "Setup", "DropGoldToPlayBag", ref g_Config.boDropGoldToPlayBag);
            IniFile.SyncIniBool(Config, "Setup", "ChangeUseItemNameByPlayName", ref g_Config.boChangeUseItemNameByPlayName);
            IniFile.SyncIniString(Config, "Setup", "ChangeUseItemName", "", ref g_Config.sChangeUseItemName);
            // 开天斩使用间隔
            IniFile.SyncIniByte(Config, "Setup", "Magic43UseTime", ref g_Config.nKill43UseTime);
            IniFile.SyncIniByte(Config, "Setup", "MagicDedingUseTime", ref g_Config.nDedingUseTime);
            // 无极真气使用间隔 20080603
            IniFile.SyncIniByte(Config, "Setup", "AbilityUpTick", ref g_Config.nAbilityUpTick);
            // 无极真气使用时长模式 20081109
            IniFile.SyncIniBool(Config, "Setup", "AbilityUpFixMode", ref g_Config.boAbilityUpFixMode);
            // 无极真气使用固定时长 20081109
            IniFile.SyncIniByte(Config, "Setup", "AbilityUpFixUseTime", ref g_Config.nAbilityUpFixUseTime);
            // 无极真气使用时长 20080603
            IniFile.SyncIniByte(Config, "Setup", "AbilityUpUseTime", ref g_Config.nAbilityUpUseTime);
            // 先天元力失效酒量下限比例 20080626
            IniFile.SyncIniByte(Config, "Setup", "MinDrinkValue67", ref g_Config.nMinDrinkValue67);
            // 酒气护体失效酒量下限比例 20080626
            IniFile.SyncIniByte(Config, "Setup", "MinDrinkValue68", ref g_Config.nMinDrinkValue68);
            // 酒气护体使用间隔 20080625
            IniFile.SyncIniByte(Config, "Setup", "HPUpTick", ref g_Config.nHPUpTick);
            // 酒气护体增加使用时长 20080625
            IniFile.SyncIniByte(Config, "Setup", "HPUpUseTime", ref g_Config.nHPUpUseTime);
            IniFile.SyncIniBool(Config, "Setup", "DedingAllowPK", ref g_Config.boDedingAllowPK);
            // 分身术设置
            IniFile.SyncIniInt(Config, "Setup", "MakeSelfTick", ref g_Config.nMakeSelfTick);
            IniFile.SyncIniInt(Config, "Setup", "CopyHumanTick", ref g_Config.nCopyHumanTick);
            IniFile.SyncIniInt(Config, "Setup", "CopyHumanBagCount", ref g_Config.nCopyHumanBagCount);
            // 分身名字颜色 20080404
            IniFile.SyncIniByte(Config, "Setup", "CopyHumNameColor", ref g_Config.nCopyHumNameColor);
            IniFile.SyncIniInt(Config, "Setup", "AllowCopyHumanCount", ref g_Config.nAllowCopyHumanCount);
            IniFile.SyncIniBool(Config, "Setup", "AddMasterName", ref g_Config.boAddMasterName);
            IniFile.SyncIniString(Config, "Setup", "CopyHumName", "", ref g_Config.sCopyHumName);
            IniFile.SyncIniByte(Config, "Setup", "CopyHumAddHPRate", ref g_Config.nCopyHumAddHPRate);
            IniFile.SyncIniByte(Config, "Setup", "CopyHumAddMPRate", ref g_Config.nCopyHumAddMPRate);
            IniFile.SyncIniString(Config, "Setup", "CopyHumBagItems1", "", ref g_Config.sCopyHumBagItems1);
            IniFile.SyncIniString(Config, "Setup", "CopyHumBagItems2", "", ref g_Config.sCopyHumBagItems2);
            IniFile.SyncIniString(Config, "Setup", "CopyHumBagItems3", "", ref g_Config.sCopyHumBagItems3);
            IniFile.SyncIniBool(Config, "Setup", "AllowGuardAttack", ref g_Config.boAllowGuardAttack);
            IniFile.SyncIniUint(Config, "Setup", "WarrorAttackTime", ref g_Config.dwWarrorAttackTime);
            IniFile.SyncIniUint(Config, "Setup", "WizardAttackTime", ref g_Config.dwWizardAttackTime);
            IniFile.SyncIniUint(Config, "Setup", "TaoistAttackTime", ref g_Config.dwTaoistAttackTime);
            IniFile.SyncIniBool(Config, "Setup", "AllowReCallMobOtherHum", ref g_Config.boAllowReCallMobOtherHum);
            IniFile.SyncIniBool(Config, "Setup", "NeedLevelHighTarget", ref g_Config.boNeedLevelHighTarget);
            // /////////////////数据读取和保存等待时间 //////////////////////////////////////
            IniFile.SyncIniUint(Config, "Setup", "GetDBSockMsgTime", ref g_Config.dwGetDBSockMsgTime);
            // /////////////////数据读取和保存等待时间 //////////////////////////////////////
            IniFile.SyncIniBool(Config, "Setup", "PullCrossInSafeZone", ref g_Config.boPullCrossInSafeZone);
            IniFile.SyncIniBool(Config, "Exp", "HighLevelGroupFixExp", ref g_Config.boHighLevelGroupFixExp);
            IniFile.SyncIniBool(Config, "Setup", "StartMapEvent", ref g_Config.boStartMapEvent);
            // 斗笠可带选项 20080417
            IniFile.SyncIniSbyte(Config, "Setup", "IsUseZhuLi", ref g_Config.nIsUseZhuLi);
            // 带上斗笠是否显示神秘人 20080424
            IniFile.SyncIniBool(Config, "Setup", "UnKnowHum", ref g_Config.boUnKnowHum);
            // 是否保存双倍经验时间 20080412
            IniFile.SyncIniBool(Config, "Exp", "SaveExpRate", ref g_Config.boSaveExpRate);
            IniFile.SyncIniUshort(Config, "Exp", "LimitExpLevel", ref g_Config.nLimitExpLevel);
            IniFile.SyncIniUint(Config, "Exp", "LimitExpValue", ref g_Config.nLimitExpValue);
            IniFile.SyncIniUshort(Config, "Setup", "FireDelayTimeRate", ref g_Config.nFireDelayTimeRate);
            IniFile.SyncIniUshort(Config, "Setup", "FirePowerRate", ref g_Config.nFirePowerRate);
            IniFile.SyncIniBool(Config, "Setup", "ChangeMapFireExtinguish", ref g_Config.boChangeMapFireExtinguish);
            IniFile.SyncIniUshort(Config, "Setup", "DidingPowerRate", ref g_Config.nDidingPowerRate);

            // ------------------------------------------------------------------------------
            // 移行换位使用间隔 20080616
            IniFile.SyncIniUint(Config, "Setup", "MagChangXYTick", ref g_Config.dwMagChangXYTick);
            // 护体神盾相关设置参数 20080108
            IniFile.SyncIniUint(Config, "Setup", "ProtectionDefenceTime", ref g_Config.nProtectionDefenceTime);
            IniFile.SyncIniUint(Config, "Setup", "ProtectionTick", ref g_Config.dwProtectionTick);
            IniFile.SyncIniByte(Config, "Setup", "ProtectionRate", ref g_Config.nProtectionRate);
            // 护体神盾生效机率 20080929
            IniFile.SyncIniByte(Config, "Setup", "ProtectionOKRate", ref g_Config.nProtectionOKRate);
            IniFile.SyncIniByte(Config, "Setup", "ProtectionBadRate", ref g_Config.nProtectionBadRate);
            IniFile.SyncIniBool(Config, "Setup", "RushkungBadProtection", ref g_Config.RushkungBadProtection);
            IniFile.SyncIniBool(Config, "Setup", "ErgumBadProtection", ref g_Config.ErgumBadProtection);
            IniFile.SyncIniBool(Config, "Setup", "FirehitBadProtection", ref g_Config.FirehitBadProtection);
            IniFile.SyncIniBool(Config, "Setup", "TwnhitBadProtection", ref g_Config.TwnhitBadProtection);
            // 显示护体神盾效果 20080328
            IniFile.SyncIniBool(Config, "Setup", "ShowProtectionEnv", ref g_Config.boShowProtectionEnv);
            // 自动使用神盾 20080328
            IniFile.SyncIniBool(Config, "Setup", "AutoProtection", ref g_Config.boAutoProtection);
            // 智能锁定 20080418
            IniFile.SyncIniBool(Config, "Setup", "AutoCanHit", ref g_Config.boAutoCanHit);
            // 宝宝是否飞到主人身边 20080713
            IniFile.SyncIniBool(Config, "Setup", "SlaveMoveMaster", ref g_Config.boSlaveMoveMaster);
            // ------------------------------------------------------------------------------
            // 龙影剑法使用间隔 20080204
            IniFile.SyncIniByte(Config, "Setup", "Magic42UseTime", ref g_Config.nKill42UseTime);
            // 龙影剑法威力 20080213
            IniFile.SyncIniUshort(Config, "Setup", "AttackRate_42", ref g_Config.nAttackRate_42);
            // 龙影剑法范围 20080218
            IniFile.SyncIniByte(Config, "Setup", "MagicAttackRage_42", ref g_Config.nMagicAttackRage_42);
            // ------------------------------------------------------------------------------
            // 英雄尸体清理时间 20080418
            IniFile.SyncIniUint(Config, "HeroSetup", "MakeGhostHeroTime", ref g_Config.nMakeGhostHeroTime);
            // 召唤英雄间隔 20071201 begin
            IniFile.SyncIniUint(Config, "HeroSetup", "RecallHeroTime", ref g_Config.nRecallHeroTime);
            // 召唤英雄间隔 20071201 end
            // ------------------------------------------------------------------------------
            // 英雄HP为人物的倍数 20081219
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroHPRate", ref g_Config.nHeroHPRate);
            // 死亡减少忠诚度 20080110
            IniFile.SyncIniUshort(Config, "HeroSetup", "DeathDecLoyal", ref g_Config.nDeathDecLoyal);
            // PK值减少忠诚度 20080214
            IniFile.SyncIniUshort(Config, "HeroSetup", "PKDecLoyal", ref g_Config.nPKDecLoyal);
            // 行会战增加忠诚度 20080214
            IniFile.SyncIniUshort(Config, "HeroSetup", "GuildIncLoyal", ref g_Config.nGuildIncLoyal);
            // 人物等级排名上升增加忠诚度 20080214
            IniFile.SyncIniUshort(Config, "HeroSetup", "LevelOrderIncLoyal", ref g_Config.nLevelOrderIncLoyal);
            // 人物等级排名下降减少忠诚度 20080214
            IniFile.SyncIniUshort(Config, "HeroSetup", "LevelOrderDecLoyal", ref g_Config.nLevelOrderDecLoyal);
            // 获得经验->忠诚度 20080110
            IniFile.SyncIniInt(Config, "HeroSetup", "WinExp", ref g_Config.nWinExp);
            // 经验加忠诚 20080110
            IniFile.SyncIniUshort(Config, "HeroSetup", "ExpAddLoyal", ref g_Config.nExpAddLoyal);
            // 四级触发 20080110
            IniFile.SyncIniUshort(Config, "HeroSetup", "GotoLV4", ref g_Config.nGotoLV4);
            // 四级技能杀伤力增加值 20080112
            IniFile.SyncIniByte(Config, "HeroSetup", "PowerLV4", ref g_Config.nPowerLV4);
            IniFile.SyncIniUint(Config, "HeroSetup", "HeroWalkIntervalTime", ref g_Config.dwHeroWalkIntervalTime);
            // 英雄转向间隔 20080213
            IniFile.SyncIniUint(Config, "HeroSetup", "HeroTurnIntervalTime", ref g_Config.dwHeroTurnIntervalTime);
            // 英雄魔法间隔 20080524
            IniFile.SyncIniUint(Config, "HeroSetup", "HeroMagicHitIntervalTime", ref g_Config.dwHeroMagicHitIntervalTime);
            // 英雄施毒术使用模式 20080604
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroSkillMode", ref g_Config.btHeroSkillMode);
            // 英雄无极真气使用模式 20080827
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroSkillMode50", ref g_Config.btHeroSkillMode50);
            // 英雄分身术模式 20081029
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroSkillMode46", ref g_Config.btHeroSkillMode46);
            // 英雄开天斩重击模式 20081221
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroSkillMode43", ref g_Config.btHeroSkillMode43);
            // 噬魂沼泽使用绿毒模式 20080911
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroSkillMode_63", ref g_Config.btHeroSkillMode_63);
            // ------------------------------------------------------------------------------
            IniFile.SyncIniUshort(Config, "HeroSetup", "StartLevel", ref g_Config.nHeroStartLevel);
            IniFile.SyncIniUshort(Config, "HeroSetup", "DrinkHeroStartLevel", ref g_Config.nDrinkHeroStartLevel);
            IniFile.SyncIniByte(Config, "HeroSetup", "KillMonExpRate", ref g_Config.nHeroKillMonExpRate);
            IniFile.SyncIniByte(Config, "HeroSetup", "NoKillMonExpRate", ref g_Config.nHeroNoKillMonExpRate);
            for (I = g_Config.nHeroBagItemCount.GetLowerBound(0); I <= g_Config.nHeroBagItemCount.GetUpperBound(0); I++)
            {
                IniFile.SyncIniUshort(Config, "HeroSetup", "BagItemCount" + I, ref g_Config.nHeroBagItemCount[I]);
            }
            IniFile.SyncIniUint(Config, "HeroSetup", "WarrorAttackTime", ref  g_Config.dwHeroWarrorAttackTime);
            IniFile.SyncIniUint(Config, "HeroSetup", "WizardAttackTime", ref  g_Config.dwHeroWizardAttackTime);
            IniFile.SyncIniUint(Config, "HeroSetup", "TaoistAttackTime", ref  g_Config.dwHeroTaoistAttackTime);
            IniFile.SyncIniBool(Config, "HeroSetup", "KillByMonstDropUseItem", ref g_Config.boHeroKillByMonstDropUseItem);
            IniFile.SyncIniBool(Config, "HeroSetup", "KillByHumanDropUseItem", ref g_Config.boHeroKillByHumanDropUseItem);
            IniFile.SyncIniBool(Config, "HeroSetup", "DieScatterBag", ref g_Config.boHeroDieScatterBag);
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroAutoProtectionDefence", ref g_Config.boHeroAutoProtectionDefence);
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroNoTargetCall", ref g_Config.boHeroNoTargetCall);
            IniFile.SyncIniBool(Config, "HeroSetup", "HeroDieExp", ref g_Config.boHeroDieExp);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroDieExpRate", ref g_Config.nHeroDieExpRate);
            IniFile.SyncIniBool(Config, "HeroSetup", "DieRedScatterBagAll", ref g_Config.boHeroDieRedScatterBagAll);
            IniFile.SyncIniUshort(Config, "HeroSetup", "DieDropUseItemRate", ref g_Config.nHeroDieDropUseItemRate);
            IniFile.SyncIniByte(Config, "HeroSetup", "DieRedDropUseItemRate", ref g_Config.nHeroDieRedDropUseItemRate);
            IniFile.SyncIniUshort(Config, "HeroSetup", "DieScatterBagRate", ref g_Config.nHeroDieScatterBagRate);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAddHPRate", ref g_Config.nHeroAddHPRate);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAddMPRate", ref g_Config.nHeroAddMPRate);
            IniFile.SyncIniUint(Config, "HeroSetup", "HeroAddHPMPTick", ref g_Config.nHeroAddHPMPTick);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAddHPRate1", ref g_Config.nHeroAddHPRate1);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAddMPRate1", ref g_Config.nHeroAddMPRate1);
            IniFile.SyncIniUint(Config, "HeroSetup", "HeroAddHPMPTick1", ref g_Config.nHeroAddHPMPTick1);
            IniFile.SyncIniUshort(Config, "HeroSetup", "MaxFirDragonPoint", ref g_Config.nMaxFirDragonPoint);
            IniFile.SyncIniUshort(Config, "HeroSetup", "AddFirDragonPoint", ref g_Config.nAddFirDragonPoint);
            IniFile.SyncIniUshort(Config, "HeroSetup", "DecFirDragonPoint", ref g_Config.nDecFirDragonPoint);
            IniFile.SyncIniUint(Config, "HeroSetup", "IncDragonPointTick", ref g_Config.nIncDragonPointTick);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroSkill46MaxHP_0", ref g_Config.nHeroSkill46MaxHP_0);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroSkill46MaxHP_1", ref g_Config.nHeroSkill46MaxHP_1);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroSkill46MaxHP_2", ref g_Config.nHeroSkill46MaxHP_2);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroSkill46MaxHP_3", ref g_Config.nHeroSkill46MaxHP_3);
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroMakeSelfTick", ref g_Config.nHeroMakeSelfTick);
            IniFile.SyncIniByte(Config, "HeroSetup", "DecDragonHitPoint", ref g_Config.nDecDragonHitPoint);
            IniFile.SyncIniByte(Config, "HeroSetup", "DecDragonRate", ref g_Config.nDecDragonRate);
            IniFile.SyncIniByte(Config, "HeroSetup", "nHeroNameColor", ref g_Config.nHeroNameColor);
            IniFile.SyncIniString(Config, "HeroSetup", "sHeroName", "", ref g_Config.sHeroName);
            IniFile.SyncIniString(Config, "HeroSetup", "sHeroNameSuffix", "", ref g_Config.sHeroNameSuffix);
            IniFile.SyncIniBool(Config, "HeroSetup", "boNameSuffix", ref g_Config.boNameSuffix);
            IniFile.SyncIniBool(Config, "HeroSetup", "boNoSafeProtect", ref g_Config.boNoSafeProtect);
            IniFile.SyncIniBool(Config, "HeroSetup", "boHeroAttackTarget", ref g_Config.boHeroAttackTarget);
           IniFile.SyncIniBool(Config, "HeroSetup", "boHeroAttackTao", ref g_Config.boHeroAttackTao);
            IniFile.SyncIniBool(Config, "HeroSetup", "boRestNoFollow", ref g_Config.boRestNoFollow);
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroAttackRate_60", ref  g_Config.nHeroAttackRate_60);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAttackRange_60", ref  g_Config.nHeroAttackRange_60);
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroAttackRate_61", ref  g_Config.nHeroAttackRate_61);
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroAttackRate_62", ref  g_Config.nHeroAttackRate_62);
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroAttackRate_63", ref  g_Config.nHeroAttackRate_63);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAttackRange_63", ref  g_Config.nHeroAttackRange_63);
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroAttackRate_64", ref  g_Config.nHeroAttackRate_64);
            IniFile.SyncIniUshort(Config, "HeroSetup", "HeroAttackRate_65", ref  g_Config.nHeroAttackRate_65);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAttackRange_64", ref g_Config.nHeroAttackRange_64);
            IniFile.SyncIniByte(Config, "HeroSetup", "HeroAttackRange_65", ref g_Config.nHeroAttackRange_65);
            IniFile.SyncIniString(Config, "HeroNames", "ClothsMan", "", ref g_Config.sHeroClothsMan);
            IniFile.SyncIniString(Config, "HeroNames", "ClothsWoman", "", ref g_Config.sClothsWoman);
            IniFile.SyncIniString(Config, "HeroNames", "WoodenSword", "", ref g_Config.sHeroWoodenSword);
            IniFile.SyncIniString(Config, "HeroNames", "BasicDrug", "", ref g_Config.sHeroBasicDrug);
            IniFile.SyncIniBool(Config, "Shop", "ShopBuyGameGird", ref g_Config.g_boGameGird);
            IniFile.SyncIniInt(Config, "Shop", "GameGold", ref g_Config.g_nGameGold);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel0", ref g_Config.PulsePointNGLevel0);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel1", ref g_Config.PulsePointNGLevel1);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel2", ref g_Config.PulsePointNGLevel2);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel3", ref g_Config.PulsePointNGLevel3);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel4", ref g_Config.PulsePointNGLevel4);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel5", ref g_Config.PulsePointNGLevel5);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel6", ref g_Config.PulsePointNGLevel6);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel7", ref g_Config.PulsePointNGLevel7);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel8", ref g_Config.PulsePointNGLevel8);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel9", ref g_Config.PulsePointNGLevel9);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel10", ref g_Config.PulsePointNGLevel10);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel11", ref g_Config.PulsePointNGLevel11);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel12", ref g_Config.PulsePointNGLevel12);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel13", ref g_Config.PulsePointNGLevel13);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel14", ref g_Config.PulsePointNGLevel14);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel15", ref g_Config.PulsePointNGLevel15);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel16", ref g_Config.PulsePointNGLevel16);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel17", ref g_Config.PulsePointNGLevel17);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel18", ref g_Config.PulsePointNGLevel18);
            IniFile.SyncIniUshort(Config, "Setup", "PulsePointNGLevel19", ref g_Config.PulsePointNGLevel19);
            IniFile.SyncIniUshort(Config, "Setup", "BatterSkillFireRange_82", ref g_Config.BatterSkillFireRange_82);
            IniFile.SyncIniUshort(Config, "Setup", "BatterSkillFireRange_85", ref g_Config.BatterSkillFireRange_85);
            IniFile.SyncIniUshort(Config, "Setup", "BatterSkillFireRange_86", ref g_Config.BatterSkillFireRange_86);
            IniFile.SyncIniUshort(Config, "Setup", "BatterSkillFireRange_87", ref g_Config.BatterSkillFireRange_87);
            IniFile.SyncIniUshort(Config, "Setup", "BatterSkillPoinson_86", ref g_Config.BatterSkillPoinson_86);
            IniFile.SyncIniUshort(Config, "Setup", "BatterSkillPoinson_87", ref g_Config.BatterSkillPoinson_87);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitRate1", ref g_Config.StormsHitRate1);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitRate2", ref g_Config.StormsHitRate2);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitRate3", ref g_Config.StormsHitRate3);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitRate4", ref g_Config.StormsHitRate4);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitRate5", ref g_Config.StormsHitRate5);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitAppearRate0", ref g_Config.StormsHitAppearRate0);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitAppearRate1", ref g_Config.StormsHitAppearRate1);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitAppearRate2", ref g_Config.StormsHitAppearRate2);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitAppearRate3", ref g_Config.StormsHitAppearRate3);
            IniFile.SyncIniInt(Config, "Setup", "StormsHitAppearRate4", ref g_Config.StormsHitAppearRate4);
            IniFile.SyncIniInt(Config, "Setup", "UseBatterTick", ref g_Config.UseBatterTick);
            IniFile.SyncIniInt(Config, "Setup", "Magic69UseTime", ref g_Config.Magic69UseTime);
            // -------------------英雄其他设置 包括双英雄设置--------------//
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength1DecGold", ref g_Config.Strength1DecGold);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength1DecGameGird", ref g_Config.Strength1DecGameGird);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength1Exp", ref g_Config.Strength1Exp);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength2DecGold", ref g_Config.Strength2DecGold);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength2DecGameGird", ref g_Config.Strength2DecGameGird);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength2Exp", ref g_Config.Strength2Exp);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength3DecGold", ref g_Config.Strength3DecGold);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength3DecGameGird", ref g_Config.Strength3DecGameGird);
            IniFile.SyncIniInt(Config, "HeroSetup", "Strength3Exp", ref g_Config.Strength3Exp);
            IniFile.SyncIniInt(Config, "HeroSetup", "RecallDeputyHeroTime", ref g_Config.RecallDeputyHeroTime);
            IniFile.SyncIniString(Config, "Setup", "Sacred", "", ref g_Config.SacRed);
            IniFile.SyncIniByte(Config, "Setup", "SacredCount", ref  g_Config.SacredCount);
        }

        /// <summary>
        /// 加载游戏变量配置
        /// </summary>
        internal static void LoadVarGlobal()
        {
            for (int i = g_Config.GlobalVal.GetLowerBound(0); i <= g_Config.GlobalVal.GetUpperBound(0); i++)
            {
                IniFile.SyncIniInt(GlobalConf, "Integer", "GlobalVal" + i, ref g_Config.GlobalVal[i]);
            }

            string sLoadString = string.Empty;
            for (int i = g_Config.GlobalAVal.GetLowerBound(0); i <= g_Config.GlobalAVal.GetUpperBound(0); i++)
            {
                sLoadString = GlobalConf.ReadString("String", "GlobalStrVal" + i, "");
                if (sLoadString == "")
                {
                    GlobalConf.WriteString("String", "GlobalStrVal" + i, "");
                }
                g_Config.GlobalAVal[i] = sLoadString;
            }
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="c256"></param>
        /// <returns></returns>
        public static Color GetRGB(byte c256)
        {
            return Color.FromArgb(ColorTable[c256].rgbRed, ColorTable[c256].rgbGreen, ColorTable[c256].rgbBlue);
        }

        /// <summary>
        /// 查询IP地址
        /// </summary>
        /// <param name="sIPaddr"></param>
        /// <returns></returns>
        public static string GetIPLocal(string sIPaddr)
        {
            string result = string.Empty;
            try
            {
                string sQqwryPath = Environment.CurrentDirectory + @"\qqwry.dat";
                if (File.Exists(sQqwryPath))
                {
                    IPScaner objIPScaner = new IPScaner();
                    objIPScaner.DataPath = sQqwryPath;
                    objIPScaner.IP = sIPaddr;
                    result = objIPScaner.IPLocation() + objIPScaner.ErrMsg;
                }
                else
                {
                    result = "请下载纯真IP数据库qqwry.dat文件放入M2目录下!";
                }
                return result;
            }
            catch
            {
                result = "未知！！！";
            }
            return result;
        }

        // sIPaddr 为当前IP
        // dIPaddr 为要比较的IP
        // * 号为通配符
        public static bool CompareIPaddr(string sIPaddr, string dIPaddr)
        {
            bool result;
            int nPos;
            result = false;
            if ((sIPaddr == "") || (dIPaddr == ""))
            {
                return result;
            }
            if ((dIPaddr[0] == '*'))
            {
                result = true;
                return result;
            }
            nPos = dIPaddr.IndexOf("*");
            if (nPos > 0)
            {
                result = HUtil32.CompareLStr(sIPaddr, dIPaddr, nPos - 1);
            }
            else
            {
                result = (sIPaddr).ToLower().CompareTo((dIPaddr).ToLower()) == 0;
            }
            return result;
        }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void Init()
        {
            Config = new IniFile(sConfigFileName);
            CommandConf = new IniFile(sCommandFileName);
            StringConf = new IniFile(sStringFileName);
            GlobalConf = new IniFile(sGlobalFileName);
            ScriptEngine = new ScriptEngine();
            for (int i = 0; i < 256; i++)
            {
                ColorTable[i].rgbRed = ColorHelper.ColorArray[i * 4 + 2];
                ColorTable[i].rgbGreen = ColorHelper.ColorArray[i * 4 + 1];
                ColorTable[i].rgbBlue = ColorHelper.ColorArray[i * 4];
                ColorTable[i].rgbReserved = ColorHelper.ColorArray[i * 4 + 3];
            }
        }

        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public static void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}