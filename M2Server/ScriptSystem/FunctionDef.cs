
namespace M2Server.ScriptSystem
{
    /// <summary>
    /// NPC头文件功能定义
    /// </summary>
    public class FunctionDef
    {
        /// <summary>
        /// 祝福语标识
        /// </summary>
        public const string sSL_SENDMSG = "@@sendmsg";
        /// <summary>
        /// 普通修理物品
        /// </summary>
        public const string sSUPERREPAIR = "@s_repair";
        /// <summary>
        /// 特殊修理物品
        /// </summary>
        public const string sSUPERREPAIROK = "~@s_repair";
        public const string sSUPERREPAIRFAIL = "@fail_s_repair";
        /// <summary>
        /// 修理
        /// </summary>
        public const string sREPAIR = "@repair";
        public const string sREPAIROK = "~@repair";
        /// <summary>
        /// 买物品
        /// </summary>
        public const string sBUY = "@buy";
        /// <summary>
        /// 卖物品
        /// </summary>
        public const string sSELL = "@sell";
        /// <summary>
        /// 炼药
        /// </summary>
        public const string sMAKEDURG = "@makedrug";
        public const string sPRICES = "@prices";
        /// <summary>
        /// 存仓库
        /// </summary>
        public const string sSTORAGE = "@storage";
        /// <summary>
        /// 取仓库
        /// </summary>
        public const string sGETBACK = "@getback";
        /// <summary>
        /// 存物品到无限仓库
        /// </summary>
        public const string sBIGSTORAGE = "@bigstorage";
        /// <summary>
        /// 取无限仓库物品
        /// </summary>
        public const string sBIGGETBACK = "@biggetback";
        public const string sGETPREVIOUSPAGE = "@getpreviouspage";
        public const string sGETNEXTPAGE = "@getnextpage";
        /// <summary>
        /// 升级物品
        /// </summary>
        public const string sUPGRADENOW = "@upgradenow";
        public const string sUPGRADEING = "~@upgradenow_ing";
        public const string sUPGRADEOK = "~@upgradenow_ok";
        public const string sUPGRADEFAIL = "~@upgradenow_fail";
        public const string sGETBACKUPGNOW = "@getbackupgnow";
        public const string sGETBACKUPGOK = "~@getbackupgnow_ok";
        public const string sGETBACKUPGFAIL = "~@getbackupgnow_fail";
        public const string sGETBACKUPGFULL = "~@getbackupgnow_bagfull";
        public const string sGETBACKUPGING = "~@getbackupgnow_ing";
        public const string sEXIT = "@exit";
        public const string sBACK = "@back";
        public const string sMAIN = "@main";
        public const string sFAILMAIN = "~@main";
        public const string sGETMASTER = "@@getmaster";
        public const string sGETMARRY = "@@getmarry";
        public const string sUSEITEMNAME = "@@useitemname";
        /// <summary>
        /// 接受歌曲
        /// </summary>
        public const string sRMST = "@@rmst";
        /// <summary>
        /// 挂机自动回复
        /// </summary>
        public const string sofflinemsg = "@@offlinemsg";
        /// <summary>
        /// 元宝转帐
        /// </summary>
        public const string sstartdealgold = "@startdealgold";
        public const string sdealgold = "@@dealgold";
        public const string sBUILDGUILDNOW = "@@buildguildnow";
        public const string sSCL_GUILDWAR = "@@guildwar";
        public const string sDONATE = "@@donate";
        public const string sREQUESTCASTLEWAR = "@requestcastlewarnow";
        /// <summary>
        /// 城堡改名
        /// </summary>
        public const string sCASTLENAME = "@@castlename";
        /// <summary>
        /// 沙巴克取回资金
        /// </summary>
        public const string sWITHDRAWAL = "@@withdrawal";
        /// <summary>
        /// 沙巴克存资金
        /// </summary>
        public const string sRECEIPTS = "@@receipts";
        /// <summary>
        /// 沙巴克开门
        /// </summary>
        public const string sOPENMAINDOOR = "@openmaindoor";
        /// <summary>
        /// 沙巴克关门
        /// </summary>
        public const string sCLOSEMAINDOOR = "@closemaindoor";
        /// <summary>
        /// 马上修复城门
        /// </summary>
        public const string sREPAIRDOORNOW = "@repairdoornow";
        /// <summary>
        /// 修城墙一
        /// </summary>
        public const string sREPAIRWALLNOW1 = "@repairwallnow1";
        /// <summary>
        /// 修城墙二
        /// </summary>
        public const string sREPAIRWALLNOW2 = "@repairwallnow2";
        /// <summary>
        /// 修城墙三
        /// </summary>
        public const string sREPAIRWALLNOW3 = "@repairwallnow3";
        public const string sHIREARCHERNOW = "@hirearchernow";
        public const string sHIREGUARDNOW = "@hireguardnow";
        public const string sHIREGUARDOK = "@hireguardok";
        /// <summary>
        /// 创建英雄脚本命令
        /// </summary>
        public const string sLyCreateHero = "@@LyCreateHero";
        /// <summary>
        /// 酒馆英雄NPC
        /// </summary>
        public const string sBuHero = "@@BuHero";
        /// <summary>
        ///  酿酒 标识
        /// </summary>
        public const string sPlayMakeWine = "@PlayMakeWine";
        /// <summary>
        /// 请酒,斗酒
        /// </summary>
        public const string sPlayDrink = "@PlayDrink";
        /// <summary>
        /// 元宝寄售:出售物品
        /// </summary>
        public const string sDealYBme = "@dealybme";
        /// <summary>
        /// 开通元宝寄售标识
        /// </summary>
        public const string sybdeal = "@ybdeal";
        public const string sUserLevelOrder = "@UserLevelOrder";
        public const string sWarrorLevelOrder = "@WarrorLevelOrder";
        public const string sWizardLevelOrder = "@WizardLevelOrder";
        public const string sTaoistLevelOrder = "@TaoistLevelOrder";
        public const string sMasterCountOrder = "@MasterCountOrder";
        public const string sLevelOrderHomePage = "@LevelOrderHomePage";
        public const string sLevelOrderPreviousPage = "@LevelOrderPreviousPage";
        public const string sLevelOrderNextPage = "@LevelOrderNextPage";
        public const string sLevelOrderLastPage = "@LevelOrderLastPage";
        public const string sMyLevelOrder = "@MyLevelOrder";
    }
}