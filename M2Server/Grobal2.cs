using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace M2Server
{
    /// <summary>
    /// 全局(服务器和客户端通用)消息,数据结构,函数等
    /// </summary>
    public class Grobal2
    {
        public const int MAPNAMELEN = 16;
        public const int ACTORNAMELEN = 14;
        public const int DEFBLOCKSIZE = 32;
        /// <summary>
        /// 组队最高人数
        /// </summary>
        public const int GROUPMAX = 11;
        /// <summary>
        /// 最高幸运值
        /// </summary>
        public const int BODYLUCKUNIT = 10;
        /// <summary>
        /// 传奇中人物只有8个方向,但是打符,锲蛾飞行,神鹰都有16方向
        /// </summary>
        public const int MAX_STATUS_ATTRIBUTE = 12;
        /// <summary>
        /// 北
        /// </summary>
        public const byte DR_UP = 0;
        /// <summary>
        /// 东北向
        /// </summary>
        public const byte DR_UPRIGHT = 1;
        /// <summary>
        /// 东
        /// </summary>
        public const byte DR_RIGHT = 2;
        /// <summary>
        /// 东南向
        /// </summary>
        public const byte DR_DOWNRIGHT = 3;
        /// <summary>
        /// 南
        /// </summary>
        public const byte DR_DOWN = 4;
        /// <summary>
        /// 西南向
        /// </summary>
        public const byte DR_DOWNLEFT = 5;
        /// <summary>
        /// 西
        /// </summary>
        public const byte DR_LEFT = 6;
        /// <summary>
        /// 西北向
        /// </summary>
        public const byte DR_UPLEFT = 7;
        /// <summary>
        /// 修补火龙之心
        /// </summary>
        public const int X_RepairFir = 20;
        /// <summary>
        /// 中毒类型：绿毒
        /// </summary>
        public const int POISON_DECHEALTH = 0;
        /// <summary>
        /// 中毒类型：红毒
        /// </summary>
        public const int POISON_DAMAGEARMOR = 1;
        /// <summary>
        /// 不能攻击
        /// </summary>
        public const int POISON_LOCKSPELL = 2;
        /// <summary>
        /// 不能移动
        /// </summary>
        public const int POISON_DONTMOVE = 4;
        /// <summary>
        /// 中毒类型:麻痹
        /// </summary>
        public const int POISON_STONE = 5;
        /// <summary>
        /// 被石化
        /// </summary>
        public const int STATE_STONE_MODE = 1;
        /// <summary>
        /// 不能跑动(中蛛网)
        /// </summary>
        public const int STATE_LOCKRUN = 3;
        /// <summary>
        /// 护体神盾
        /// </summary>
        public const int STATE_ProtectionDEFENCE = 7;
        /// <summary>
        /// 隐身
        /// </summary>
        public const int STATE_TRANSPARENT = 8;
        /// <summary>
        /// 神圣战甲术(防御力)
        /// </summary>
        public const int STATE_DEFENCEUP = 9;
        /// <summary>
        /// 幽灵盾  魔御力
         /// </summary>
        public const int STATE_MAGDEFENCEUP = 10;
        /// <summary>
        /// 魔法盾
        /// </summary>
        public const int STATE_BUBBLEDEFENCEUP = 11;

        public const int USERMODE_PLAYGAME = 1;
        public const int USERMODE_LOGIN = 2;
        public const int USERMODE_LOGOFF = 3;
        public const int USERMODE_NOTICE = 4;
        public const int RUNGATEMAX = 20;
        public const uint RUNGATECODE = 0xAA55AA55;
        public const int OS_MOVINGOBJECT = 1;
        /// <summary>
        /// 物品对象
        /// </summary>
        public const int OS_ITEMOBJECT = 2;
        /// <summary>
        /// 事件对象
        /// </summary>
        public const int OS_EVENTOBJECT = 3;
        public const int OS_GATEOBJECT = 4;
        public const int OS_SWITCHOBJECT = 5;
        public const int OS_MAPEVENT = 6;
        public const int OS_DOOR = 7;
        public const int OS_ROON = 8;
        /// <summary>
        /// 人物
        /// </summary>
        public const int RC_PLAYOBJECT = 0;
        /// <summary>
        /// 人形怪物
        /// </summary>
        public const int RC_PLAYMOSTER = 150;
        /// <summary>
        /// 英雄
        /// </summary>
        public const int RC_HEROOBJECT = 66;
        /// <summary>
        /// 大刀守卫
        /// </summary>
        public const int RC_GUARD = 12;
        public const int RC_PEACENPC = 15;
        public const int RC_ANIMAL = 50;
        public const int RC_MONSTER = 80;
        /// <summary>
        /// NPC
        /// </summary>
        public const int RC_NPC = 10;
        /// <summary>
        /// 弓箭手
        /// </summary>
        public const int RC_ARCHERGUARD = 112;
        public const int RCC_USERHUMAN = RC_PLAYOBJECT;
        public const int RCC_GUARD = RC_GUARD;
        public const int RCC_MERCHANT = RC_ANIMAL;
        public const int ISM_WHISPER = 1234;
        public const int CM_QUERYCHR = 100;
        // 登录成功,客户端显出左右角色的那一瞬
        public const int CM_NEWCHR = 101;
        // 创建角色
        public const int CM_DELCHR = 102;
        // 删除角色
        public const int CM_SELCHR = 103;
        // 选择角色
        public const int CM_SELECTSERVER = 104;
        // 服务器,注意不是选区,盛大一区往往有(至多8个??group.dat中是这么写的)不止一个的服务器
        public const int CM_QUERYDELCHR = 105;
        // 查询删除过的角色信息 20080706
        public const int CM_RESDELCHR = 106;
        // 恢复删除的角色 20080706
        public const int SM_RUSH = 6;
        // 跑动中改变方向
        public const int SM_RUSHKUNG = 7;
        // 野蛮冲撞
        public const int SM_FIREHIT = 8;
        // 烈火
        public const int SM_4FIREHIT = 58;
        // 4级烈火 20080112
        public const int SM_BACKSTEP = 9;
        // 后退,野蛮效果? //半兽统领公箭手攻击玩家的后退??axemon.pas中procedure   TDualAxeOma.Run
        public const int SM_TURN = 10;
        // 转向
        public const int SM_WALK = 11;
        // 走
        public const int SM_SITDOWN = 12;
        public const int SM_RUN = 13;
        // 跑
        public const int SM_HIT = 14;
        // 砍
        public const int SM_HEAVYHIT = 15;
        public const int SM_BIGHIT = 16;
        public const int SM_SPELL = 17;
        // 使用魔法
        public const int SM_POWERHIT = 18;
        // 攻杀
        public const int SM_LONGHIT = 19;
        // 刺杀
        public const int SM_DIGUP = 20;
        // 挖是一"起"一"坐",这里是挖动作的"起"
        public const int SM_DIGDOWN = 21;
        // 挖动作的"坐"
        public const int SM_FLYAXE = 22;
        // 飞斧,半兽统领的攻击方式?
        public const int SM_LIGHTING = 23;
        // 免蜡开关
        public const int SM_WIDEHIT = 24;
        // 半月
        public const int SM_CRSHIT = 25;
        // 抱月刀
        public const int SM_TWINHIT = 26;
        // 开天斩重击
        public const int SM_QTWINHIT = 59;
        // 开天斩轻击
        public const int SM_CIDHIT = 57;
        // 龙影剑法
        public const int SM_SANJUEHIT = 60;
        // 三绝杀
        public const int SM_ZHUIXINHIT = 61;
        // 追心刺
        public const int SM_DUANYUEHIT = 62;
        // 断岳斩
        public const int SM_HENGSAOHIT = 63;
        // 横扫千军
        public const int SM_YTPDHIT = 64;
        // 倚天劈地
        public const int SM_XPYJHIT = 65;
        // 血魄一击
        public const int SM_4LONGHIT = 66;
        // 四级刺杀
        public const int SM_YUANYUEHIT = 67;
        // 圆月弯刀
        public const int SM_ALIVE = 27;
        // 复活??复活戒指
        public const int SM_MOVEFAIL = 28;
        // 移动失败,走动或跑动
        public const int SM_HIDE = 29;
        // 隐身?
        public const int SM_DISAPPEAR = 30;
        // 地上物品消失
        public const int SM_STRUCK = 31;
        // 受攻击
        public const int SM_DEATH = 32;
        // 正常死亡
        public const int SM_SKELETON = 33;
        // 尸体
        public const int SM_NOWDEATH = 34;
        // 秒杀?
        public const int SM_ACTION_MIN = SM_RUSH;
        public const int SM_ACTION_MAX = SM_WIDEHIT;
        public const int SM_ACTION2_MIN = 65072;
        public const int SM_ACTION2_MAX = 65073;
        public const int SM_HEAR = 40;
        // 有人回你的话
        public const int SM_FEATURECHANGED = 41;
        public const int SM_USERNAME = 42;
        public const int SM_WINEXP = 44;
        // 获得经验
        public const int SM_LEVELUP = 45;
        // 升级,左上角出现墨绿的升级字样
        public const int SM_DAYCHANGING = 46;
        // 传奇界面右下角的太阳星星月亮
        public const int SM_LOGON = 50;
        // logon
        public const int SM_NEWMAP = 51;
        // 新地图??
        public const int SM_ABILITY = 52;
        // 打开属性对话框,F11
        public const int SM_HEALTHSPELLCHANGED = 53;
        // 治愈术使你的体力增加
        public const int SM_MAPDESCRIPTION = 54;
        // 地图描述,行会战地图?攻城区域?安全区域?
        public const int SM_SPELL2 = 117;
        // 对话消息
        public const int SM_MOVEMESSAGE = 99;
        public const int SM_SYSMESSAGE = 100;
        // 系统消息,盛大一般红字,私服蓝字
        public const int SM_GROUPMESSAGE = 101;
        // 组内聊天!!
        public const int SM_CRY = 102;
        // 喊话
        public const int SM_WHISPER = 103;
        // 私聊
        public const int SM_GUILDMESSAGE = 104;
        // 行会聊天!~
        public const int SM_ADDITEM = 200;
        public const int SM_BAGITEMS = 201;
        public const int SM_DELITEM = 202;
        public const int SM_UPDATEITEM = 203;
        public const int SM_ADDMAGIC = 210;
        public const int SM_SENDMYMAGIC = 211;
        public const int SM_DELMAGIC = 212;
        public const int SM_BACKSTEPEX = 250;
        // 服务器端发送的命令 SM:server msg,服务端向客户端发送的消息
        // 登录、新帐号、新角色、查询角色等
        public const int SM_CERTIFICATION_FAIL = 501;
        public const int SM_ID_NOTFOUND = 502;
        public const int SM_PASSWD_FAIL = 503;
        // 验证失败,"服务器验证失败,需要重新登录"??
        public const int SM_NEWID_SUCCESS = 504;
        // 创建新账号成功
        public const int SM_NEWID_FAIL = 505;
        // 创建新账号失败
        public const int SM_CHGPASSWD_SUCCESS = 506;
        // 修改密码成功
        public const int SM_CHGPASSWD_FAIL = 507;
        // 修改密码失败
        public const int SM_GETBACKPASSWD_SUCCESS = 508;
        // 密码找回成功
        public const int SM_GETBACKPASSWD_FAIL = 509;
        // 密码找回失败
        public const int SM_QUERYCHR = 520;
        // 返回角色信息到客户端
        public const int SM_NEWCHR_SUCCESS = 521;
        // 新建角色成功
        public const int SM_NEWCHR_FAIL = 522;
        // 新建角色失败
        public const int SM_DELCHR_SUCCESS = 523;
        // 删除角色成功
        public const int SM_DELCHR_FAIL = 524;
        // 删除角色失败
        public const int SM_STARTPLAY = 525;
        // 开始进入游戏世界(点了健康游戏忠告后进入游戏画面)
        public const int SM_STARTFAIL = 526;
        // //开始失败,玩传奇深有体会,有时选择角色,点健康游戏忠告后黑屏
        public const int SM_QUERYCHR_FAIL = 527;
        // 返回角色信息到客户端失败
        public const int SM_OUTOFCONNECTION = 528;
        // 超过最大连接数,强迫用户下线
        public const int SM_PASSOK_SELECTSERVER = 529;
        // 密码验证完成且密码正确,开始选服
        public const int SM_SELECTSERVER_OK = 530;
        // 选服成功
        public const int SM_NEEDUPDATE_ACCOUNT = 531;
        // 需要更新,注册后的ID会发生什么变化?私服中的普通ID经过充值??或者由普通ID变为会员ID,GM?
        public const int SM_UPDATEID_SUCCESS = 532;
        // 更新成功
        public const int SM_UPDATEID_FAIL = 533;
        // 更新失败
        public const int SM_QUERYDELCHR = 534;
        // 返回删除过的角色 20080706
        public const int SM_QUERYDELCHR_FAIL = 535;
        // 返回删除过的角色失败 20080706
        public const int SM_RESDELCHR_SUCCESS = 536;
        // 恢复删除角色成功 20080706
        public const int SM_RESDELCHR_FAIL = 537;
        // 恢复删除角色失败 20080706
        public const int SM_NOCANRESDELCHR = 538;
        // 禁止恢复删除角色,即不可查看 200800706
        public const int SM_DROPITEM_SUCCESS = 600;
        public const int SM_DROPITEM_FAIL = 601;
        public const int SM_ITEMSHOW = 610;
        public const int SM_ITEMHIDE = 611;
        // SM_DOOROPEN           = 612;
        public const int SM_OPENDOOR_OK = 612;
        // 通过过门点成功
        public const int SM_OPENDOOR_LOCK = 613;
        // 发现过门口是封锁的,以前盛大秘密通道去赤月的门要5分钟开一次
        public const int SM_CLOSEDOOR = 614;
        // 用户过门,门自行关闭
        public const int SM_TAKEON_OK = 615;
        public const int SM_TAKEON_FAIL = 616;
        public const int SM_TAKEOFF_OK = 619;
        public const int SM_TAKEOFF_FAIL = 620;
        public const int SM_SENDUSEITEMS = 621;
        public const int SM_WEIGHTCHANGED = 622;
        public const int SM_CLEAROBJECTS = 633;
        public const int SM_CHANGEMAP = 634;
        // 地图改变,进入新地图
        public const int SM_EAT_OK = 635;
        public const int SM_EAT_FAIL = 636;
        public const int SM_BUTCH = 637;
        // 野蛮?
        public const int SM_MAGICFIRE = 638;
        // 地狱火,火墙??
        public const int SM_MAGICFIRE_FAIL = 639;
        public const int SM_MAGIC_LVEXP = 640;
        public const int SM_DURACHANGE = 642;
        public const int SM_MERCHANTSAY = 643;
        public const int SM_MERCHANTDLGCLOSE = 644;
        public const int SM_SENDGOODSLIST = 645;
        public const int SM_SENDUSERSELL = 646;
        public const int SM_SENDBUYPRICE = 647;
        public const int SM_USERSELLITEM_OK = 648;
        public const int SM_USERSELLITEM_FAIL = 649;
        public const int SM_BUYITEM_SUCCESS = 650;
        // ?
        public const int SM_BUYITEM_FAIL = 651;
        // ?
        public const int SM_SENDDETAILGOODSLIST = 652;
        public const int SM_GOLDCHANGED = 653;
        public const int SM_CHANGELIGHT = 654;
        // 负重改变
        public const int SM_LAMPCHANGEDURA = 655;
        // 蜡烛持久改变
        public const int SM_CHANGENAMECOLOR = 656;
        // 名字颜色改变,白名,灰名,红名,黄名
        public const int SM_CHARSTATUSCHANGED = 657;
        public const int SM_SENDNOTICE = 658;
        // 发送健康游戏忠告(公告)
        public const int SM_GROUPMODECHANGED = 659;
        // 组队模式改变
        public const int SM_CREATEGROUP_OK = 660;
        public const int SM_CREATEGROUP_FAIL = 661;
        public const int SM_GROUPADDMEM_OK = 662;
        public const int SM_GROUPDELMEM_OK = 663;
        public const int SM_GROUPADDMEM_FAIL = 664;
        public const int SM_GROUPDELMEM_FAIL = 665;
        public const int SM_GROUPCANCEL = 666;
        public const int SM_GROUPMEMBERS = 667;
        public const int SM_SENDUSERREPAIR = 668;
        public const int SM_USERREPAIRITEM_OK = 669;
        public const int SM_USERREPAIRITEM_FAIL = 670;
        public const int SM_SENDREPAIRCOST = 671;
        public const int SM_DEALMENU = 673;
        public const int SM_DEALTRY_FAIL = 674;
        public const int SM_DEALADDITEM_OK = 675;
        public const int SM_DEALADDITEM_FAIL = 676;
        public const int SM_DEALDELITEM_OK = 677;
        /// <summary>
        /// 交易失败
        /// </summary>
        public const int SM_DEALDELITEM_FAIL = 678;
        public const int SM_DEALCANCEL = 681;
        public const int SM_DEALREMOTEADDITEM = 682;
        public const int SM_DEALREMOTEDELITEM = 683;
        public const int SM_DEALCHGGOLD_OK = 684;
        public const int SM_DEALCHGGOLD_FAIL = 685;
        public const int SM_DEALREMOTECHGGOLD = 686;
        public const int SM_DEALSUCCESS = 687;
        public const int SM_SENDUSERSTORAGEITEM = 700;
        /// <summary>
        /// 存储物品成功
        /// </summary>
        public const int SM_STORAGE_OK = 701;
        /// <summary>
        /// 仓库物品满
        /// </summary>
        public const int SM_STORAGE_FULL = 702;
        /// <summary>
        /// 存储物品失败
        /// </summary>
        public const int SM_STORAGE_FAIL = 703;
        public const int SM_SAVEITEMLIST = 704;
        public const int SM_TAKEBACKSTORAGEITEM_OK = 705;
        public const int SM_TAKEBACKSTORAGEITEM_FAIL = 706;
        public const int SM_TAKEBACKSTORAGEITEM_FULLBAG = 707;
        public const int SM_AREASTATE = 708;
        // 周围状态
        public const int SM_MYSTATUS = 766;
        // 我的状态,最近一次下线状态,如是否被毒,挂了就强制回城
        public const int SM_DELITEMS = 709;
        public const int SM_READMINIMAP_OK = 710;
        public const int SM_READMINIMAP_FAIL = 711;
        public const int SM_SENDUSERMAKEDRUGITEMLIST = 712;
        public const int SM_MAKEDRUG_SUCCESS = 713;
        // 714
        // 716
        public const int SM_MAKEDRUG_FAIL = 65036;
        public const int SM_CHANGEGUILDNAME = 750;
        public const int SM_SENDUSERSTATE = 751;
        public const int SM_SUBABILITY = 752;
        // 打开输助属性对话框
        public const int SM_OPENGUILDDLG = 753;
        public const int SM_OPENGUILDDLG_FAIL = 754;
        public const int SM_SENDGUILDMEMBERLIST = 756;
        public const int SM_GUILDADDMEMBER_OK = 757;
        public const int SM_GUILDADDMEMBER_FAIL = 758;
        public const int SM_GUILDDELMEMBER_OK = 759;
        public const int SM_GUILDDELMEMBER_FAIL = 760;
        public const int SM_GUILDRANKUPDATE_FAIL = 761;
        public const int SM_BUILDGUILD_OK = 762;
        public const int SM_BUILDGUILD_FAIL = 763;
        public const int SM_DONATE_OK = 764;
        public const int SM_DONATE_FAIL = 765;
        public const int SM_MENU_OK = 767;
        // ?
        public const int SM_GUILDMAKEALLY_OK = 768;
        public const int SM_GUILDMAKEALLY_FAIL = 769;
        public const int SM_GUILDBREAKALLY_OK = 770;
        // ?
        public const int SM_GUILDBREAKALLY_FAIL = 771;
        // ?
        public const int SM_DLGMSG = 772;
        // Jacky
        public const int SM_SPACEMOVE_HIDE = 800;
        // 道士走一下隐身
        public const int SM_SPACEMOVE_SHOW = 801;
        // 道士走一下由隐身变为现身
        public const int SM_RECONNECT = 802;
        // 与服务器重连
        public const int SM_GHOST = 803;
        // 尸体清除,虹魔教主死的效果?
        public const int SM_SHOWEVENT = 804;
        // 显示事件
        public const int SM_HIDEEVENT = 805;
        // 隐藏事件
        public const int SM_SPACEMOVE_HIDE2 = 806;
        public const int SM_SPACEMOVE_SHOW2 = 807;
        public const int SM_TIMECHECK_MSG = 810;
        // 时钟检测,以免客户端作弊
        public const int SM_ADJUST_BONUS = 811;
        // ?
        // ----SM_消息 从6000开始添加----//
        public const int SM_OPENPULSE_OK = 6000;
        public const int SM_OPENPULSE_FAIL = 6001;
        public const int SM_RUSHPULSE_OK = 6002;
        public const int SM_RUSHPULSE_FAIL = 6003;
        public const int SM_PULSECHANGED = 6004;
        public const int SM_BATTERORDER = 6005;
        public const int SM_CANUSEBATTER = 6006;
        public const int SM_BATTERUSEFINALLY = 6007;
        public const int SM_BATTERSTART = 6008;
        public const int SM_OPENPULS = 6009;
        // 打开经络
        public const int SM_HEROBATTERORDER = 6010;
        public const int SM_HEROPULSECHANGED = 6011;
        public const int SM_BATTERBACKSTEP = 6012;
        public const int SM_STORMSRATE = 6013;
        public const int SM_STORMSRATECHANGED = 6014;
        public const int SM_HEROSTORMSRATECHANGED = 6015;
        public const int SM_OPENPULSENEEDLEV = 6016;
        public const int SM_HEROATTECTMODE = 6017;
        public const int SM_GETASSESSHEROINFO = 6018;
        public const int SM_QUERYASSESSHERO = 6019;
        public const int SM_SHOWASSESSDLG = 6020;
        public const int SM_ISDEHERO = 6021;
        public const int SM_OPENTRAININGDLG = 6022;
        public const int SM_OPENHEALTH = 1100;
        public const int SM_CLOSEHEALTH = 1101;
        public const int SM_BREAKWEAPON = 1102;
        // 武器破碎
        public const int SM_INSTANCEHEALGUAGE = 1103;
        // 实时治愈
        public const int SM_CHANGEFACE = 1104;
        // 变脸,发型改变?
        public const int SM_VERSION_FAIL = 1106;
        // 客户端版本验证失败
        public const int SM_ITEMUPDATE = 1500;
        public const int SM_MONSTERSAY = 1501;
        public const int SM_EXCHGTAKEON_OK = 65023;
        public const int SM_EXCHGTAKEON_FAIL = 65024;
        public const int SM_TEST = 65037;
        public const int SM_TESTHERO = 65038;
        public const int SM_THROW = 65069;
        public const int RM_DELITEMS = 9000;
        // Jacky
        public const int RM_TURN = 10001;
        public const int RM_WALK = 10002;
        public const int RM_RUN = 10003;
        public const int RM_HIT = 10004;
        public const int RM_SPELL = 10007;
        public const int RM_SPELL2 = 10008;
        public const int RM_POWERHIT = 10009;
        public const int RM_LONGHIT = 10011;
        public const int RM_WIDEHIT = 10012;
        public const int RM_PUSH = 10013;
        public const int RM_FIREHIT = 10014;
        // 烈火
        public const int RM_4FIREHIT = 10016;
        // 4级烈火 20080112
        public const int RM_RUSH = 10015;
        public const int RM_STRUCK = 10020;
        // 受物理打击
        public const int RM_DEATH = 10021;
        public const int RM_DISAPPEAR = 10022;
        public const int RM_MAGSTRUCK = 10025;
        public const int RM_MAGHEALING = 10026;
        public const int RM_STRUCK_MAG = 10027;
        // 受魔法打击
        public const int RM_MAGSTRUCK_MINE = 10028;
        public const int RM_INSTANCEHEALGUAGE = 10029;
        // jacky
        public const int RM_HEAR = 10030;
        // 公聊
        public const int RM_WHISPER = 10031;
        public const int RM_CRY = 10032;
        public const int RM_RIDE = 10033;
        public const int RM_WINEXP = 10044;
        public const int RM_USERNAME = 10043;
        public const int RM_LEVELUP = 10045;
        public const int RM_CHANGENAMECOLOR = 10046;
        public const int RM_PUSHEX = 10047;
        public const int RM_LOGON = 10050;
        public const int RM_ABILITY = 10051;
        public const int RM_HEALTHSPELLCHANGED = 10052;
        public const int RM_DAYCHANGING = 10053;
        public const int RM_MOVEMESSAGE = 10099;
        // 滚动公告   清清 2007.11.13
        public const int RM_SYSMESSAGE = 10100;
        public const int RM_GROUPMESSAGE = 10102;
        public const int RM_SYSMESSAGE2 = 10103;
        public const int RM_GUILDMESSAGE = 10104;
        public const int RM_SYSMESSAGE3 = 10105;
        /// <summary>
        /// 显示物品
        /// </summary>
        public const int RM_ITEMSHOW = 10110;
        /// <summary>
        /// 隐藏物品
        /// </summary>
        public const int RM_ITEMHIDE = 10111;
        public const int RM_DOOROPEN = 10112;
        public const int RM_DOORCLOSE = 10113;
        public const int RM_SENDUSEITEMS = 10114;
        // 发送使用的物品
        public const int RM_WEIGHTCHANGED = 10115;
        public const int RM_FEATURECHANGED = 10116;
        public const int RM_CLEAROBJECTS = 10117;
        public const int RM_CHANGEMAP = 10118;
        public const int RM_BUTCH = 10119;
        // 挖
        public const int RM_MAGICFIRE = 10120;
        public const int RM_SENDMYMAGIC = 10122;
        // 发送使用的魔法
        public const int RM_MAGIC_LVEXP = 10123;
        public const int RM_SKELETON = 10024;
        public const int RM_DURACHANGE = 10125;
        /// <summary>
        /// 持久改变
        /// </summary>
        public const int RM_MERCHANTSAY = 10126;
        /// <summary>
        /// 金币改变
        /// </summary>
        public const int RM_GOLDCHANGED = 10136;
        public const int RM_CHANGELIGHT = 10137;
        public const int RM_CHARSTATUSCHANGED = 10139;
        public const int RM_DELAYMAGIC = 10154;
        public const int RM_DIGUP = 10200;
        public const int RM_DIGDOWN = 10201;
        public const int RM_FLYAXE = 10202;
        public const int RM_LIGHTING = 10204;
        public const int RM_SUBABILITY = 10302;
        /// <summary>
        /// 群体隐身
        /// </summary>
        public const int RM_TRANSPARENT = 10308;
        public const int RM_SPACEMOVE_SHOW = 10331;
        public const int RM_RECONNECTION = 11332;
        public const int RM_SPACEMOVE_SHOW2 = 10332;
        // 隐藏烟花
        public const int RM_HIDEEVENT = 10333;
        // 显示烟花
        public const int RM_SHOWEVENT = 10334;
        public const int RM_ZEN_BEE = 10337;
        public const int RM_OPENHEALTH = 10410;
        public const int RM_CLOSEHEALTH = 10411;
        public const int RM_DOOPENHEALTH = 10412;
        public const int RM_CHANGEFACE = 10415;
        public const int RM_ITEMUPDATE = 11000;
        public const int RM_MONSTERSAY = 11001;
        public const int RM_MAKESLAVE = 11002;
        public const int RM_MONMOVE = 21004;
        public const int SS_200 = 200;
        public const int SS_201 = 201;
        public const int SS_202 = 202;
        public const int SS_WHISPER = 203;
        public const int SS_204 = 204;
        public const int SS_205 = 205;
        public const int SS_206 = 206;
        public const int SS_207 = 207;
        public const int SS_208 = 208;
        public const int SS_209 = 219;
        public const int SS_210 = 210;
        public const int SS_211 = 211;
        public const int SS_212 = 212;
        public const int SS_213 = 213;
        public const int SS_214 = 214;
        public const int RM_10205 = 10205;
        public const int RM_10101 = 10101;
        public const int RM_ALIVE = 10153;
        // 复活
        public const int RM_CHANGEGUILDNAME = 10301;
        public const int RM_10414 = 10414;
        public const int RM_POISON = 10300;
        /// <summary>
        /// 不死系
        /// </summary>
        public const int LA_UNDEAD = 1;
        public const int RM_DELAYPUSHED = 10555;
        public const int CM_GETBACKPASSWORD = 2010;
        // 密码找回
        public const int CM_SPELL = 3017;
        // 施魔法
        public const int CM_QUERYUSERNAME = 80;
        // 进入游戏,服务器返回角色名到客户端
        public const int CM_DROPITEM = 1000;
        // 从包裹里扔出物品到地图,此时人物如果在安全区可能会提示安全区不允许扔东西
        public const int CM_PICKUP = 1001;
        // 捡东西
        public const int CM_TAKEONITEM = 1003;
        // 装配装备到身上的装备位置
        public const int CM_TAKEOFFITEM = 1004;
        // 从身上某个装备位置取下某个装备
        public const int CM_EAT = 1006;
        // 吃药
        public const int CM_BUTCH = 1007;
        // 挖
        public const int CM_MAGICKEYCHANGE = 1008;
        // 魔法快捷键改变
        public const int CM_HEROMAGICKEYCHANGE = 1046;
        // 英雄魔法开关设置 20080606
        public const int CM_1005 = 1005;
        // 与商店NPC交易相关
        public const int CM_CLICKNPC = 1010;
        // 用户点击了某个NPC进行交互
        public const int CM_MERCHANTDLGSELECT = 1011;
        // 商品选择,大类
        public const int CM_MERCHANTQUERYSELLPRICE = 1012;
        // 返回价格,标准价格,我们知道商店用户卖入的有些东西掉持久或有特殊
        public const int CM_USERSELLITEM = 1013;
        // 用户卖东西
        public const int CM_USERBUYITEM = 1014;
        // 用户买入东西
        public const int CM_USERGETDETAILITEM = 1015;
        // 取得商品清单,比如点击"蛇眼戒指"大类,会出现一列蛇眼戒指供你选择
        public const int CM_DROPGOLD = 1016;
        // 用户放下金钱到地上
        public const int CM_LOGINNOTICEOK = 1018;
        // 健康游戏忠告点了确实,进入游戏
        public const int CM_GROUPMODE = 1019;
        // 关组还是开组
        public const int CM_CREATEGROUP = 1020;
        // 新建组队
        public const int CM_ADDGROUPMEMBER = 1021;
        // 组内添人
        public const int CM_DELGROUPMEMBER = 1022;
        // 组内删人
        public const int CM_USERREPAIRITEM = 1023;
        // 用户修理东西
        public const int CM_MERCHANTQUERYREPAIRCOST = 1024;
        // 客户端向NPC取得修理费用
        public const int CM_DEALTRY = 1025;
        // 开始交易,交易开始
        public const int CM_DEALADDITEM = 1026;
        // 加东东到交易物品栏上
        public const int CM_DEALDELITEM = 1027;
        // 从交易物品栏上撤回东东???好像不允许哦
        public const int CM_DEALCANCEL = 1028;
        // 取消交易
        public const int CM_DEALCHGGOLD = 1029;
        // 本来交易栏上金钱为0,,如有金钱交易,交易双方都会有这个消息
        public const int CM_DEALEND = 1030;
        // 交易成功,完成交易
        public const int CM_USERSTORAGEITEM = 1031;
        // 用户寄存东西
        public const int CM_USERTAKEBACKSTORAGEITEM = 1032;
        // 用户向保管员取回东西
        public const int CM_WANTMINIMAP = 1033;
        // 用户点击了"小地图"按钮
        public const int CM_USERMAKEDRUGITEM = 1034;
        // 用户制造毒药(其它物品)
        public const int CM_OPENGUILDDLG = 1035;
        // 用户点击了"行会"按钮
        public const int CM_GUILDHOME = 1036;
        // 点击"行会主页"
        public const int CM_GUILDMEMBERLIST = 1037;
        // 点击"成员列表"
        public const int CM_GUILDADDMEMBER = 1038;
        // 增加成员
        public const int CM_GUILDDELMEMBER = 1039;
        // 踢人出行会
        public const int CM_GUILDUPDATENOTICE = 1040;
        // 修改行会公告
        public const int CM_GUILDUPDATERANKINFO = 1041;
        // 更新联盟信息(取消或建立联盟)
        public const int CM_ADJUST_BONUS = 1043;
        // 用户得到奖励??私服中比较明显,小号升级时会得出金钱声望等,不是很确定,//求经过测试的高手的验证
        public const int CM_SPEEDHACKUSER = 10430;
        // 用户加速作弊检测
        public const int CM_PASSWORD = 1105;
        public const int CM_CHGPASSWORD = 1221;
        // ?
        public const int CM_SETPASSWORD = 1222;
        // ?
        public const int CM_HORSERUN = 3009;
        public const int CM_THROW = 3005;
        // 抛符
        // 动作命令1
        public const int CM_TURN = 3010;
        // 转身(方向改变)
        public const int CM_WALK = 3011;
        // 走
        public const int CM_SITDOWN = 3012;
        // 挖(蹲下)
        public const int CM_RUN = 3013;
        // 跑

        /// <summary>
        /// 普通物理近身攻击
        /// </summary>
        public const int CM_HIT = 3014;
        // 
        public const int CM_HEAVYHIT = 3015;
        // 跳起来打的动作
        public const int CM_BIGHIT = 3016;
        public const int CM_POWERHIT = 3018;
        // 攻杀
        public const int CM_LONGHIT = 3019;
        // 刺杀
        public const int CM_4LONGHIT = 3066;
        // 4级刺杀
        public const int CM_YUANYUEHIT = 3067;
        // 圆月弯刀
        public const int CM_WIDEHIT = 3024;
        // 半月
        public const int CM_FIREHIT = 3025;
        // 烈火攻击
        public const int CM_4FIREHIT = 3031;
        // 4级烈火攻击
        public const int CM_CRSHIT = 3036;
        // 抱月刀
        public const int CM_TWNHIT = 3037;
        // 开天斩重击
        public const int CM_QTWINHIT = 3041;
        // 开天斩轻击
        public const int CM_CIDHIT = 3040;
        // 龙影剑法
        public const int CM_TWINHIT = CM_TWNHIT;
        public const int CM_PHHIT = 3038;
        // 破魂斩
        public const int CM_DAILY = 3042;
        // 逐日剑法 20080511
        public const int CM_SANJUEHIT = 3060;
        // 三绝杀
        public const int CM_ZHUIXINHIT = 3061;
        // 追心刺
        public const int CM_DUANYUEHIT = 3062;
        // 断岳斩
        public const int CM_HENGSAOHIT = 3063;
        // 横扫千军
        public const int CM_YTPDHIT = 3064;
        // 倚天劈地
        public const int CM_XPYJHIT = 3065;
        // 血魄一击
        public const int RM_SANJUEHIT = 10060;
        // 三绝杀
        public const int RM_ZHUIXINHIT = 10061;
        // 追心刺  人刚刚开始的动作
        public const int RM_DUANYUEHIT = 10062;
        // 断岳斩
        public const int RM_HENGSAOHIT = 10063;
        // 横扫千军
        public const int RM_ZHUIXIN_OK = 10064;
        // 追心刺  冲撞过去的动作
        public const int RM_YTPDHIT = 10065;
        // 倚天劈地
        public const int RM_XPYJHIT = 10066;
        // 血魄一击
        // --RM_消息 添加处 36000起步--//
        public const int RM_OPENPULSE_OK = 36000;
        public const int RM_OPENPULSE_FAIL = 36001;
        public const int RM_RUSHPULSE_OK = 36002;
        public const int RM_RUSHPULSE_FAIL = 36003;
        public const int RM_PULSECHANGED = 36004;
        public const int RM_BATTERORDER = 36005;
        public const int RM_BATTERUSEFINALLY = 36006;
        public const int RM_HEROBATTERORDER = 36007;
        public const int RM_HEROPULSECHANGED = 36008;
        public const int RM_STORMSRATE = 36009;
        public const int RM_STORMSRATECHANGED = 36010;
        public const int RM_HEROSTORMSRATECHANGED = 36011;
        public const int RM_OPENPULSENEEDLEV = 36012;
        // 双英雄 相关
        // RM_GETDOUBLEHEROINFO     = 36013;
        public const int RM_HEROATTECTMODE = 36014;
        public const int RM_GETASSESSHEROINFO = 36015;
        public const int RM_QUERYASSESSHERO = 36016;
        public const int RM_SHOWASSESSDLG = 36017;
        public const int RM_ISDEHERO = 36018;
        public const int RM_OPENTRAININGDLG = 36019;
        // 新技能和四级技能相关
        public const int RM_4LONGHIT = 36020;
        public const int RM_YUANYUEHIT = 36021;
        public const int CM_SAY = 3030;
        // 角色发言
        public const int CM_40HIT = 3026;
        public const int CM_41HIT = 3027;
        public const int CM_42HIT = 3029;
        public const int CM_43HIT = 3028;
        public const int CM_USEBATTER = 3080;
        // 使用连击
        public const int RM_10401 = 10401;
        /// <summary>
        /// 菜单
        /// </summary>
        public const int RM_MENU_OK = 10309;
        /// <summary>
        /// 关闭NPC对话框
        /// </summary>
        public const int RM_MERCHANTDLGCLOSE = 10127;
        public const int RM_SENDDELITEMLIST = 10148;
        // 发送删除项目的名单
        public const int RM_SENDUSERSREPAIR = 10141;
        // 发送用户修理
        public const int RM_SENDGOODSLIST = 10128;
        // 发送商品名单
        public const int RM_SENDUSERSELL = 10129;
        // 发送用户出售
        public const int RM_SENDUSERREPAIR = 11139;
        // 发送用户修理
        public const int RM_USERMAKEDRUGITEMLIST = 10149;
        // 用户做药品项目的名单
        public const int RM_USERSTORAGEITEM = 10146;
        // 用户仓库项目
        public const int RM_USERGETBACKITEM = 10147;
        // 用户获得回的仓库项目
        public const int RM_SPACEMOVE_FIRE2 = 11330;
        // 空间移动
        public const int RM_SPACEMOVE_FIRE = 11331;
        // 空间移动
        public const int RM_BUYITEM_SUCCESS = 10133;
        // 购买项目成功
        public const int RM_BUYITEM_FAIL = 10134;
        // 购买项目失败
        public const int RM_SENDDETAILGOODSLIST = 10135;
        // 发送详细的商品名单
        public const int RM_SENDBUYPRICE = 10130;
        // 发送购买价格
        public const int RM_USERSELLITEM_OK = 10131;
        // 用户出售成功
        public const int RM_USERSELLITEM_FAIL = 10132;
        // 用户出售失败
        public const int RM_MAKEDRUG_SUCCESS = 10150;
        // 做药成功
        public const int RM_MAKEDRUG_FAIL = 10151;
        // 做药失败
        public const int RM_SENDREPAIRCOST = 10142;
        // 发送修理成本
        public const int RM_USERREPAIRITEM_OK = 10143;
        // 用户修理项目成功
        public const int RM_USERREPAIRITEM_FAIL = 10144;
        // 用户修理项目失败
        public const int MAXBAGITEM = 46;
        // 人物背包最大数量
        public const int MAXHEROBAGITEM = 40;
        // 英雄包裹最大数量
        public const int RM_10155 = 10155;
        public const int RM_PLAYDICE = 10500;
        public const int RM_ADJUST_BONUS = 10400;
        /// <summary>
        /// 行会建立成功
        /// </summary>
        public const int RM_BUILDGUILD_OK = 10303;
        /// <summary>
        /// 行会建立失败
        /// </summary>
        public const int RM_BUILDGUILD_FAIL = 10304;
        public const int RM_DONATE_OK = 10305;
        public const int RM_GAMEGOLDCHANGED = 10666;
        public const int STATE_OPENHEATH = 1;
        public const int POISON_68 = 68;
        public const int RM_MYSTATUS = 10777;
        public const int CM_QUERYUSERSTATE = 82;
        // 查询用户状态(用户登录进去,实际上是客户端向服务器索取查询最近一次,退出服务器前的状态的过程,
        // 服务器自动把用户最近一次下线以让游戏继续的一些信息返回到客户端)
        public const int CM_QUERYBAGITEMS = 81;
        // 查询包裹物品
        public const int CM_QUERYUSERSET = 49999;
        public const int CM_OPENDOOR = 1002;
        // 开门,人物走到地图的某个过门点时
        public const int CM_SOFTCLOSE = 1009;
        // 退出传奇(游戏程序,可能是游戏中大退,也可能时选人时退出)
        public const int CM_1017 = 1017;
        public const int CM_1042 = 1042;
        public const int CM_GUILDALLY = 1044;
        public const int CM_GUILDBREAKALLY = 1045;
        public const int RM_HORSERUN = 11000;
        public const int RM_HEAVYHIT = 10005;
        public const int RM_BIGHIT = 10006;
        public const int RM_MOVEFAIL = 10010;
        public const int RM_CRSHIT = 11014;
        public const int RM_RUSHKUNG = 11015;
        public const int RM_41 = 41;
        public const int RM_42 = 42;
        public const int RM_43 = 43;
        public const int RM_44 = 56;
        public const int RM_MAGICFIREFAIL = 10121;
        public const int RM_LAMPCHANGEDURA = 10138;
        public const int RM_GROUPCANCEL = 10140;
        public const int RM_DONATE_FAIL = 10306;
        public const int RM_BREAKWEAPON = 10413;
        public const int RM_PASSWORD = 10416;
        public const int RM_PASSWORDSTATUS = 10601;
        public const int SM_40 = 35;
        public const int SM_41 = 36;
        public const int SM_42 = 37;
        public const int SM_43 = 38;
        public const int SM_44 = 39;
        // 龙影剑法
        public const int SM_HORSERUN = 5;
        public const int SM_716 = 716;
        public const int SM_PASSWORD = 3030;
        public const int SM_PLAYDICE = 1200;
        public const int SM_PASSWORDSTATUS = 20001;
        public const int SM_GAMEGOLDNAME = 55;
        // 向客户端发送游戏币,游戏点,金刚石,灵符数量
        public const int SM_SERVERCONFIG = 20002;
        public const int SM_GETREGINFO = 20003;
        public const int ET_DIGOUTZOMBI = 1;
        public const int ET_PILESTONES = 3;
        public const int ET_HOLYCURTAIN = 4;
        public const int ET_FIRE = 5;
        public const int ET_SCULPEICE = 6;
        // 6种烟花
        public const int ET_FIREFLOWER_1 = 7;
        // 一心一意
        public const int ET_FIREFLOWER_2 = 8;
        // 心心相印
        public const int ET_FIREFLOWER_3 = 9;
        public const int ET_FIREFLOWER_4 = 10;
        public const int ET_FIREFLOWER_5 = 11;
        public const int ET_FIREFLOWER_6 = 12;
        public const int ET_FIREFLOWER_7 = 13;
        public const int ET_FIREFLOWER_8 = 14;
        /// <summary>
        /// 喷泉效果
        /// </summary>
        public const int ET_FOUNTAIN = 15;
        /// <summary>
        /// 人型庄主死亡动画效果
        /// </summary>
        public const int ET_DIEEVENT = 16;
        /// <summary>
        /// 守护兽小火圈效果
        /// </summary>
        public const int ET_FIREDRAGON = 17;
        /// <summary>
        /// 打开商铺
        /// </summary>
        public const int CM_OPENSHOP = 9000;
        /// <summary>
        /// 发送商铺物品列表
        /// </summary>
        public const int SM_SENGSHOPITEMS = 9001;
        /// <summary>
        /// 购买商铺物品
        /// </summary>
        public const int CM_BUYSHOPITEM = 9002;
        /// <summary>
        /// 购买商铺物品成功
        /// </summary>
        public const int SM_BUYSHOPITEM_SUCCESS = 9003;
        /// <summary>
        /// 购买商铺物品失败
        /// </summary>
        public const int SM_BUYSHOPITEM_FAIL = 9004;
        /// <summary>
        /// 奇珍类型
        /// </summary>
        public const int SM_SENGSHOPSPECIALLYITEMS = 9005;
        /// <summary>
        /// 赠送
        /// </summary>
        public const int CM_BUYSHOPITEMGIVE = 9006;
        
        public const int SM_BUYSHOPITEMGIVE_FAIL = 9007;
        public const int SM_BUYSHOPITEMGIVE_SUCCESS = 9008;
        public const int RM_OPENSHOPSpecially = 30000;
        public const int RM_OPENSHOP = 30001;
        public const int RM_BUYSHOPITEM_FAIL = 30003;
        // 商铺购买物品失败
        public const int RM_BUYSHOPITEMGIVE_FAIL = 30004;
        public const int RM_BUYSHOPITEMGIVE_SUCCESS = 30005;
        // ==============================================================================
        public const int CM_QUERYUSERLEVELSORT = 3500;
        // 用户等级排行
        public const int RM_QUERYUSERLEVELSORT = 35000;
        public const int SM_QUERYUSERLEVELSORT = 2500;
        // ==============================新增物品寄售系统(拍卖)==========================
        public const int RM_SENDSELLOFFGOODSLIST = 21008;
        // 拍卖
        public const int SM_SENDSELLOFFGOODSLIST = 20008;
        // 拍卖
        public const int RM_SENDUSERSELLOFFITEM = 21005;
        // 寄售物品
        public const int SM_SENDUSERSELLOFFITEM = 20005;
        // 寄售物品
        public const int RM_SENDSELLOFFITEMLIST = 22009;
        // 查询得到的寄售物品
        public const int CM_SENDSELLOFFITEMLIST = 20009;
        // 查询得到的寄售物品
        public const int RM_SENDBUYSELLOFFITEM_OK = 21010;
        // 购买寄售物品成功
        public const int SM_SENDBUYSELLOFFITEM_OK = 20010;
        // 购买寄售物品成功
        public const int RM_SENDBUYSELLOFFITEM_FAIL = 21011;
        // 购买寄售物品失败
        public const int SM_SENDBUYSELLOFFITEM_FAIL = 20011;
        // 购买寄售物品失败
        public const int RM_SENDBUYSELLOFFITEM = 41005;
        // 购买选择寄售物品
        public const int CM_SENDBUYSELLOFFITEM = 4005;
        // 购买选择寄售物品
        public const int RM_SENDQUERYSELLOFFITEM = 41006;
        // 查询选择寄售物品
        public const int CM_SENDQUERYSELLOFFITEM = 4006;
        // 查询选择寄售物品
        public const int RM_SENDSELLOFFITEM = 41004;
        // 接受寄售物品
        public const int CM_SENDSELLOFFITEM = 4004;
        // 接受寄售物品
        public const int RM_SENDUSERSELLOFFITEM_FAIL = 2007;
        // R = -3  寄售物品失败
        public const int RM_SENDUSERSELLOFFITEM_OK = 2006;
        // 寄售物品成功
        public const int SM_SENDUSERSELLOFFITEM_FAIL = 20007;
        // R = -3  寄售物品失败
        public const int SM_SENDUSERSELLOFFITEM_OK = 20006;
        // 寄售物品成功
        // ==============================元宝寄售系统(20080316)==========================
        public const int RM_SENDDEALOFFFORM = 23000;
        // 打开出售物品窗口
        public const int SM_SENDDEALOFFFORM = 23001;
        // 打开出售物品窗口
        public const int CM_SELLOFFADDITEM = 23002;
        // 客户端往出售物品窗口里加物品
        public const int SM_SELLOFFADDITEM_OK = 23003;
        // 客户端往出售物品窗口里加物品 成功
        public const int RM_SELLOFFADDITEM_OK = 23004;
        public const int SM_SellOffADDITEM_FAIL = 23005;
        // 客户端往出售物品窗口里加物品 失败
        public const int RM_SellOffADDITEM_FAIL = 23006;
        public const int CM_SELLOFFDELITEM = 23007;
        // 客户端删除出售物品窗里的物品
        public const int SM_SELLOFFDELITEM_OK = 23008;
        // 客户端删除出售物品窗里的物品 成功
        public const int RM_SELLOFFDELITEM_OK = 23009;
        public const int SM_SELLOFFDELITEM_FAIL = 23010;
        // 客户端删除出售物品窗里的物品 失败
        public const int RM_SELLOFFDELITEM_FAIL = 23011;
        /// <summary>
        /// 客户端取消元宝寄售
        /// </summary>
        public const int CM_SELLOFFCANCEL = 23012;
        /// <summary>
        /// 元宝寄售取消出售
        /// </summary>
        public const int RM_SELLOFFCANCEL = 23013;
        /// <summary>
        /// 元宝寄售取消出售
        /// </summary>
        public const int SM_SellOffCANCEL = 23014;
        /// <summary>
        /// 客户端元宝寄售结束
        /// </summary>
        public const int CM_SELLOFFEND = 23015;
        /// <summary>
        /// 客户端元宝寄售结束 成功
        /// </summary>
        public const int SM_SELLOFFEND_OK = 23016;
        /// <summary>
        /// 客户端元宝寄售结束 成功
        /// </summary>
        public const int RM_SELLOFFEND_OK = 23017;
        /// <summary>
        /// 客户端元宝寄售结束 失败
        /// </summary>
        public const int SM_SELLOFFEND_FAIL = 23018;
        /// <summary>
        /// 客户端元宝寄售结束 失败
        /// </summary>
        public const int RM_SELLOFFEND_FAIL = 23019;
        public const int RM_QUERYYBSELL = 23020;
        // 查询正在出售的物品
        public const int SM_QUERYYBSELL = 23021;
        // 查询正在出售的物品
        public const int RM_QUERYYBDEAL = 23022;
        // 查询可以的购买物品
        public const int SM_QUERYYBDEAL = 23023;
        // 查询可以的购买物品
        public const int CM_CANCELSELLOFFITEMING = 23024;
        // 取消正在寄售的物品 20080318(出售人)
        // SM_CANCELSELLOFFITEMING_OK =23018;//取消正在寄售的物品 成功
        public const int CM_SELLOFFBUYCANCEL = 23025;
        // 取消寄售 物品购买 20080318(购买人)
        public const int CM_SELLOFFBUY = 23026;
        // 确定购买寄售物品 20080318
        public const int SM_SELLOFFBUY_OK = 23027;
        /// <summary>
        /// 购买成功
        /// </summary>
        public const int RM_SELLOFFBUY_OK = 23028;
        // ==============================================================================
        // 英雄
        // //////////////////////////////////////////////////////////////////////////////
        public const int CM_RECALLHERO = 5000;
        // 召唤英雄
        public const int SM_RECALLHERO = 5001;
        public const int CM_HEROLOGOUT = 5002;
        // 英雄退出
        public const int SM_HEROLOGOUT = 5003;
        public const int SM_CREATEHERO = 5004;
        // 创建英雄
        public const int SM_HERODEATH = 5005;
        // 创建死亡
        public const int CM_HEROCHGSTATUS = 5006;
        // 改变英雄状态
        public const int CM_HEROATTACKTARGET = 5007;
        // 英雄锁定目标
        public const int CM_HEROPROTECT = 5008;
        // 守护目标
        public const int CM_HEROTAKEONITEM = 5009;
        // 打开物品栏
        public const int CM_HEROTAKEOFFITEM = 5010;
        // 关闭物品栏
        public const int CM_TAKEOFFITEMHEROBAG = 5011;
        // 装备脱下到英雄包裹
        public const int CM_TAKEOFFITEMTOMASTERBAG = 5012;
        // 装备脱下到主人包裹
        public const int CM_SENDITEMTOMASTERBAG = 5013;
        // 主人包裹到英雄包裹
        public const int CM_SENDITEMTOHEROBAG = 5014;
        // 英雄包裹到主人包裹
        public const int SM_HEROTAKEON_OK = 5015;
        public const int SM_HEROTAKEON_FAIL = 5016;
        public const int SM_HEROTAKEOFF_OK = 5017;
        public const int SM_HEROTAKEOFF_FAIL = 5018;
        public const int SM_TAKEOFFTOHEROBAG_OK = 5019;
        public const int SM_TAKEOFFTOHEROBAG_FAIL = 5020;
        public const int SM_TAKEOFFTOMASTERBAG_OK = 5021;
        public const int SM_TAKEOFFTOMASTERBAG_FAIL = 5022;
        public const int CM_HEROTAKEONITEMFORMMASTERBAG = 5023;
        // 从主人包裹穿装备到英雄包裹
        public const int CM_TAKEONITEMFORMHEROBAG = 5024;
        // 从英雄包裹穿装备到主人包裹
        public const int SM_SENDITEMTOMASTERBAG_OK = 5025;
        // 主人包裹到英雄包裹成功
        public const int SM_SENDITEMTOMASTERBAG_FAIL = 5026;
        // 主人包裹到英雄包裹失败
        public const int SM_SENDITEMTOHEROBAG_OK = 5027;
        // 英雄包裹到主人包裹
        public const int SM_SENDITEMTOHEROBAG_FAIL = 5028;
        // 英雄包裹到主人包裹
        public const int CM_QUERYHEROBAGCOUNT = 5029;
        // 查看英雄包裹容量
        public const int SM_QUERYHEROBAGCOUNT = 5030;
        // 查看英雄包裹容量
        public const int CM_QUERYHEROBAGITEMS = 5031;
        // 查看英雄包裹
        public const int SM_SENDHEROUSEITEMS = 5032;
        // 发送英雄身上装备
        public const int SM_HEROBAGITEMS = 5033;
        // 接收英雄物品
        public const int SM_HEROADDITEM = 5034;
        // 英雄包裹添加物品
        public const int SM_HERODELITEM = 5035;
        // 英雄包裹删除物品
        public const int SM_HEROUPDATEITEM = 5036;
        // 英雄包裹更新物品
        public const int SM_HEROADDMAGIC = 5037;
        // 添加英雄魔法
        public const int SM_HEROSENDMYMAGIC = 5038;
        // 发送英雄的魔法
        public const int SM_HERODELMAGIC = 5039;
        // 删除英雄魔法
        public const int SM_HEROABILITY = 5040;
        // 英雄属性1
        public const int SM_HEROSUBABILITY = 5041;
        // 英雄属性2
        public const int SM_HEROWEIGHTCHANGED = 5042;
        public const int CM_HEROEAT = 5043;
        // 吃东西
        public const int SM_HEROEAT_OK = 5044;
        // 吃东西成功
        public const int SM_HEROEAT_FAIL = 5045;
        // 吃东西失败
        public const int SM_HEROMAGIC_LVEXP = 5046;
        // 魔法等级
        public const int SM_HERODURACHANGE = 5047;
        // 英雄持久改变
        public const int SM_HEROWINEXP = 5048;
        // 英雄增加经验
        public const int SM_HEROLEVELUP = 5049;
        // 英雄升级
        public const int SM_HEROCHANGEITEM = 5050;
        // 好象没用上？
        public const int SM_HERODELITEMS = 5051;
        // 删除英雄物品
        public const int CM_HERODROPITEM = 5052;
        // 英雄往地上扔物品
        public const int SM_HERODROPITEM_SUCCESS = 5053;
        // 英雄扔物品成功
        public const int SM_HERODROPITEM_FAIL = 5054;
        // 英雄扔物品失败
        public const int CM_HEROGOTETHERUSESPELL = 5055;
        // 使用合击
        public const int SM_GOTETHERUSESPELL = 5056;
        // 使用合击
        public const int SM_FIRDRAGONPOINT = 5057;
        // 英雄怒气值
        public const int CM_REPAIRFIRDRAGON = 5058;
        // 修补火龙之心
        public const int SM_REPAIRFIRDRAGON_OK = 5059;
        // 修补火龙之心成功
        public const int SM_REPAIRFIRDRAGON_FAIL = 5060;
        // 修补火龙之心失败
        // ---------------------------------------------------
        // 祝福罐.魔令包功能 20080102
        public const int CM_REPAIRDRAGON = 5061;
        // 祝福罐.魔令包功能
        public const int SM_REPAIRDRAGON_OK = 5062;
        // 修补祝福罐.魔令包成功
        public const int SM_REPAIRDRAGON_FAIL = 5063;
        // 修补祝福罐.魔令包失败
        // ----------------------------------------------------
        // ----CM_消息 从26000开始添加----//
        // -------连击 经脉----- /
        public const int CM_OPENPULSE = 26000;
        public const int CM_RUSHPULSE = 26001;
        public const int CM_QUERYOPENPULSE = 26002;
        public const int CM_SETBATTERORDER = 26003;
        public const int CM_SETHEROBATTERORDER = 26004;
        public const int CM_QUERYHEROOPENPULSE = 26005;
        public const int CM_RUSHHEROPULSE = 26006;
        public const int CM_CHANGEHEROATTECTMODE = 26007;
        // 改变副将英雄攻击模式
        public const int CM_QUERYASSESSHERO = 26008;
        public const int CM_ASSESSMENTHERO = 26009;
        public const int CM_TRAININGHERO = 26010;
        public const int RM_RECALLHERO = 19999;
        // 召唤英雄
        public const int RM_HEROWEIGHTCHANGED = 20000;
        public const int RM_SENDHEROUSEITEMS = 20001;
        public const int RM_SENDHEROMYMAGIC = 20002;
        public const int RM_HEROMAGIC_LVEXP = 20003;
        public const int RM_QUERYHEROBAGCOUNT = 20004;
        public const int RM_HEROABILITY = 20005;
        public const int RM_HERODURACHANGE = 20006;
        public const int RM_HERODEATH = 20007;
        public const int RM_HEROLEVELUP = 20008;
        public const int RM_HEROWINEXP = 20009;
        // RM_HEROLOGOUT = 20010;
        public const int RM_CREATEHERO = 20011;
        public const int RM_MAKEGHOSTHERO = 20012;
        public const int RM_HEROSUBABILITY = 20013;
        public const int RM_GOTETHERUSESPELL = 20014;
        // 使用合击
        public const int RM_FIRDRAGONPOINT = 20015;
        // 发送英雄怒气值
        public const int RM_CHANGETURN = 20016;
        // -----------------------------------月灵重击
        public const int RM_FAIRYATTACKRATE = 20017;
        public const int SM_FAIRYATTACKRATE = 20018;
        // -----------------------------------
        public const int SM_SERVERUNBIND = 20019;
        public const int RM_DESTROYHERO = 20020;
        // 英雄销毁
        public const int SM_DESTROYHERO = 20021;
        // 英雄销毁
        public const int ET_PROTECTION_STRUCK = 20022;
        // 护体受攻击  20080108
        public const int ET_PROTECTION_PIP = 20023;
        // 护体被破
        public const int SM_MYSHOW = 20024;
        // 显示自身动画
        public const int RM_MYSHOW = 20025;
        public const int RM_OPENBOXS = 20026;
        // 打开宝箱 20080115
        public const int SM_OPENBOXS = 5064;
        // 打开宝箱 20080115
        public const int CM_OPENBOXS = 20027;
        // 打开宝箱 20080115 清清加
        public const int CM_MOVEBOXS = 20028;
        // 转动宝箱 20080117
        public const int RM_MOVEBOXS = 20029;
        // 转动宝箱 20080117
        public const int SM_MOVEBOXS = 20030;
        // 转动宝箱 20080117
        public const int CM_GETBOXS = 20031;
        // 客户端取得宝箱物品 20080118
        public const int SM_GETBOXS = 20032;
        public const int RM_GETBOXS = 20033;
        public const int SM_OPENBOOKS = 20034;
        // 打开卧龙NPC 20080119
        public const int RM_OPENBOOKS = 20035;
        public const int RM_DRAGONPOINT = 20036;
        // 发送黄条气值 20080201
        public const int SM_DRAGONPOINT = 20037;
        public const int ET_OBJECTLEVELUP = 20038;
        // 人物升级动画显示 20080222
        public const int RM_CHANGEATTATCKMODE = 20039;
        // 改变攻击模式 20080228
        public const int SM_CHANGEATTATCKMODE = 20040;
        // 改变攻击模式 20080228
        public const int CM_EXCHANGEGAMEGIRD = 20042;
        // 商铺兑换灵符  20080302
        public const int SM_EXCHANGEGAMEGIRD_FAIL = 20043;
        // 商铺购买物品失败
        public const int SM_EXCHANGEGAMEGIRD_SUCCESS = 20044;
        public const int RM_EXCHANGEGAMEGIRD_FAIL = 20045;
        public const int RM_EXCHANGEGAMEGIRD_SUCCESS = 20046;
        public const int RM_OPENDRAGONBOXS = 20047;
        // 卧龙开宝箱 20080306
        public const int SM_OPENDRAGONBOXS = 20048;
        // 卧龙开宝箱 20080306
        // SM_OPENBOXS_OK = 20047; //打开宝箱成功 20080306
        public const int RM_OPENBOXS_FAIL = 20049;
        // 打开宝箱失败 20080306
        public const int SM_OPENBOXS_FAIL = 20050;
        // 打开宝箱失败 20080306
        public const int RM_EXPTIMEITEMS = 20051;
        // 聚灵珠 发送时间改变消息 20080306
        public const int SM_EXPTIMEITEMS = 20052;
        // 聚灵珠 发送时间改变消息 20080306
        public const int ET_OBJECTBUTCHMON = 20053;
        // 人物挖尸体得到物品显示 20080325
        public const int ET_DRINKDECDRAGON = 20054;
        // 喝酒抵御合击，显示自身效果 20090105
        // SM_CLOSEDRAGONPOINT = 20055;  //关闭龙影黄条 20080329
        // ---------------------------粹练系统------------------------------------------
        public const int RM_QUERYREFINEITEM = 20056;
        // 打开粹练框口
        public const int SM_QUERYREFINEITEM = 20057;
        // 打开粹练框口
        public const int CM_REFINEITEM = 20058;
        // 客户端发送粹练物品 20080507
        public const int SM_UPDATERYREFINEITEM = 20059;
        // 更新粹练物品 20080507
        public const int CM_REPAIRFINEITEM = 20060;
        // 修补火云石 20080507 20080507
        public const int SM_REPAIRFINEITEM_OK = 20061;
        // 修补火云石成功  20080507
        public const int SM_REPAIRFINEITEM_FAIL = 20062;
        // 修补火云石失败  20080507
        // -----------------------------------------------------------------------------
        public const int RM_DAILY = 20063;
        // 逐日剑法 20080511
        public const int SM_DAILY = 20064;
        // 逐日剑法 20080511
        public const int RM_GLORY = 20065;
        // 发送到客户端 荣誉值 20080511
        public const int SM_GLORY = 20066;
        // 发送到客户端 荣誉值 20080511
        public const int RM_GETHEROINFO = 20067;
        public const int SM_GETHEROINFO = 20068;
        // 获得英雄数据
        public const int CM_SELGETHERO = 20069;
        // 取出英雄
        public const int RM_SENDUSERPLAYDRINK = 20070;
        // 出现请酒对话框 20080515
        public const int SM_SENDUSERPLAYDRINK = 20071;
        // 出现请酒对话框 20080515
        public const int CM_USERPLAYDRINKITEM = 20072;
        // 请酒框放上物品发送到M2
        public const int SM_USERPLAYDRINK_OK = 20073;
        // 请酒成功  20080515
        public const int SM_USERPLAYDRINK_FAIL = 20074;
        // 请酒失败 20080515
        public const int RM_PLAYDRINKSAY = 20075;
        public const int SM_PLAYDRINKSAY = 20076;
        public const int CM_PlAYDRINKDLGSELECT = 20077;
        // 商品选择,大类
        public const int RM_OPENPLAYDRINK = 20078;
        // 打开窗口
        public const int SM_OPENPLAYDRINK = 20079;
        // 打开窗口
        public const int CM_PlAYDRINKGAME = 20080;
        // 发送猜拳码数 20080517
        public const int RM_PlayDrinkToDrink = 20081;
        // 发送到客户端谁赢谁输
        public const int SM_PlayDrinkToDrink = 20082;
        public const int CM_DrinkUpdateValue = 20083;
        // 发送喝酒
        public const int RM_DrinkUpdateValue = 20084;
        // 返回喝酒
        public const int SM_DrinkUpdateValue = 20085;
        // 返回喝酒
        public const int RM_CLOSEDRINK = 20086;
        // 关闭斗酒，请酒窗口
        public const int SM_CLOSEDRINK = 20087;
        // 关闭斗酒，请酒窗口
        public const int CM_USERPLAYDRINK = 20088;
        // 客户端发送请酒物品
        public const int SM_USERPLAYDRINKITEM_OK = 20089;
        // 请酒物品成功
        public const int SM_USERPLAYDRINKITEM_FAIL = 20090;
        // 请酒物品失败
        public const int RM_Browser = 20091;
        // 连接指定网站
        public const int SM_Browser = 20092;
        public const int RM_PIXINGHIT = 20093;
        // 劈星斩效果 20080611
        public const int SM_PIXINGHIT = 20094;
        public const int RM_LEITINGHIT = 20095;
        // 雷霆一击效果 20080611
        public const int SM_LEITINGHIT = 20096;
        public const int CM_CHECKNUM = 20097;
        // 检测验证码 20080612
        public const int SM_CHECKNUM_OK = 20098;
        public const int CM_CHANGECHECKNUM = 20099;
        public const int RM_AUTOGOTOXY = 20100;
        // 自动寻路
        public const int SM_AUTOGOTOXY = 20101;
        // -----------------------酿酒系统---------------------------------------------
        public const int RM_OPENMAKEWINE = 20102;
        // 打开酿酒窗口
        public const int SM_OPENMAKEWINE = 20103;
        // 打开酿酒窗口
        public const int CM_BEGINMAKEWINE = 20104;
        // 开始酿酒(即把材料全放上窗口)
        public const int RM_MAKEWINE_OK = 20105;
        // 酿酒成功
        public const int SM_MAKEWINE_OK = 20106;
        // 酿酒成功
        public const int RM_MAKEWINE_FAIL = 20107;
        // 酿酒失败
        public const int SM_MAKEWINE_FAIL = 20108;
        // 酿酒失败
        public const int RM_NPCWALK = 20109;
        // 酿酒NPC走动
        public const int SM_NPCWALK = 20110;
        // 酿酒NPC走动
        public const int RM_MAGIC68SKILLEXP = 20111;
        // 酒气护体技能经验
        public const int SM_MAGIC68SKILLEXP = 20112;
        // 酒气护体技能经验
        // ------------------------挑战系统--------------------------------------------
        public const int SM_CHALLENGE_FAIL = 20113;
        // 挑战失败
        public const int SM_CHALLENGEMENU = 20114;
        // 打开挑战抵押物品窗口
        public const int CM_CHALLENGETRY = 20115;
        // 玩家点挑战
        public const int CM_CHALLENGEADDITEM = 20116;
        // 玩家把物品放到挑战框中
        public const int SM_CHALLENGEADDITEM_OK = 20117;
        // 玩家增加抵押物品成功
        public const int SM_CHALLENGEADDITEM_FAIL = 20118;
        // 玩家增加抵押物品失败
        public const int SM_CHALLENGEREMOTEADDITEM = 20119;
        // 发送增加抵押的物品后,给客户端显示
        public const int CM_CHALLENGEDELITEM = 20120;
        // 玩家从挑战框中取回物品
        public const int SM_CHALLENGEDELITEM_OK = 20121;
        // 玩家删除抵押物品成功
        public const int SM_CHALLENGEDELITEM_FAIL = 20122;
        // 玩家删除抵押物品失败
        public const int SM_CHALLENGEREMOTEDELITEM = 20123;
        // 发送删除抵押的物品后,给客户端显示
        public const int CM_CHALLENGECANCEL = 20124;
        // 玩家取消挑战
        public const int SM_CHALLENGECANCEL = 20125;
        // 玩家取消挑战
        public const int CM_CHALLENGECHGGOLD = 20126;
        // 客户端把金币放到挑战框中
        public const int SM_CHALLENCHGGOLD_FAIL = 20127;
        // 客户端把金币放到挑战框中失败
        public const int SM_CHALLENCHGGOLD_OK = 20128;
        // 客户端把金币放到挑战框中成功
        public const int SM_CHALLENREMOTECHGGOLD = 20129;
        // 客户端把金币放到挑战框中,给客户端显示
        public const int CM_CHALLENGECHGDIAMOND = 20130;
        // 客户端把金刚石放到挑战框中
        public const int SM_CHALLENCHGDIAMOND_FAIL = 20131;
        // 客户端把金刚石放到挑战框中失败
        public const int SM_CHALLENCHGDIAMOND_OK = 20132;
        // 客户端把金刚石放到挑战框中成功
        public const int SM_CHALLENREMOTECHGDIAMOND = 20133;
        // 客户端把金刚石放到挑战框中,给客户端显示
        public const int CM_CHALLENGEEND = 20134;
        // 挑战抵押物品结束
        public const int SM_CLOSECHALLENGE = 20135;
        // 关闭挑战抵押物品窗口
        // ----------------------------------------------------------------------------
        public const int RM_PLAYMAKEWINEABILITY = 20136;
        // 酒2相关属性 20080804
        public const int SM_PLAYMAKEWINEABILITY = 20137;
        // 酒2相关属性 20080804
        public const int RM_HEROMAKEWINEABILITY = 20138;
        // 酒2相关属性 20080804
        public const int SM_HEROMAKEWINEABILITY = 20139;
        // 酒2相关属性 20080804
        public const int RM_CANEXPLORATION = 20140;
        // 可探索 20080810
        public const int SM_CANEXPLORATION = 20141;
        // 可探索 20080810
        // ----------------------------------------------------------------------------
        public const int SM_SENDLOGINKEY = 20142;
        // 网关给客户端或登陆器发送登陆器封包码 20080901
        public const int SM_GATEPASS_FAIL = 20143;
        // 和网关的密码错误
        public const int RM_HEROMAGIC68SKILLEXP = 20144;
        // 英雄酒气护体技能经验  20080925
        public const int SM_HEROMAGIC68SKILLEXP = 20145;
        // 英雄酒气护体技能经验  20080925
        public const int RM_USERBIGSTORAGEITEM = 20146;
        // 用户无限仓库项目
        public const int RM_USERBIGGETBACKITEM = 20147;
        // 用户获得回的无限仓库项目
        public const int RM_USERLEVELORDER = 20148;
        // 用户等级命令
        public const int RM_HEROAUTOOPENDEFENCE = 20149;
        // 英雄内挂自动持续开盾 20080930
        public const int SM_HEROAUTOOPENDEFENCE = 20150;
        // 英雄内挂自动持续开盾 20080930
        public const int CM_HEROAUTOOPENDEFENCE = 20151;
        // 英雄内挂自动持续开盾 20080930
        public const int RM_MAGIC69SKILLEXP = 20152;
        // 内功心法经验
        public const int SM_MAGIC69SKILLEXP = 20153;
        // 内功心法经验
        public const int RM_HEROMAGIC69SKILLEXP = 20154;
        // 英雄内功心法经验  20080930
        public const int SM_HEROMAGIC69SKILLEXP = 20155;
        // 英雄内功心法经验  20080930
        public const int RM_MAGIC69SKILLNH = 20156;
        // 内力值(黄条) 20081002
        public const int SM_MAGIC69SKILLNH = 20157;
        // 内力值(黄条) 20081002
        public const int RM_WINNHEXP = 20158;
        // 取得内功经验 20081007
        public const int SM_WINNHEXP = 20159;
        // 取得内功经验 20081007
        public const int RM_HEROWINNHEXP = 20160;
        // 英雄取得内功经验 20081007
        public const int SM_HEROWINNHEXP = 20161;
        // 英雄取得内功经验 20081007
        public const int SM_SHOWSIGHICON = 20162;
        // 显示感叹号图标 20090126
        public const int RM_HIDESIGHICON = 20163;
        // 隐藏感叹号图标 20090126
        public const int SM_HIDESIGHICON = 20164;
        // 隐藏感叹号图标 20090126
        public const int CM_CLICKSIGHICON = 20165;
        // 点击感叹号图标 20090126
        public const int SM_UPDATETIME = 20166;
        // 统一与客户端的倒计时 20090129
        public const int RM_OPENEXPCRYSTAL = 20167;
        // 显示天地结晶图标 20090201
        public const int SM_OPENEXPCRYSTAL = 20168;
        // 显示天地结晶图标 20090201
        public const int SM_SENDCRYSTALNGEXP = 20169;
        // 发送天地结晶的内功经验 20090201
        public const int SM_SENDCRYSTALEXP = 20170;
        // 发送天地结晶的内功经验 20090201
        public const int SM_SENDCRYSTALLEVEL = 20171;
        // 发送天地结晶的等级 20090202
        public const int CM_CLICKCRYSTALEXPTOP = 20172;
        // 点击天地结晶获得经验 20090202
        public const int SM_ZHUIXIN_OK = 20172;
        // 追心刺
        // //////////////////////////////////////////////////////////////////////////////
        public const int UNITX = 48;
        public const int UNITY = 32;
        public const int HALFX = 24;
        public const int HALFY = 16;
        // MAXBAGITEM = 46; //用户背包最大数量
        // MAXMAGIC = 30{20}; //原来54; 200081227 注释
        public const int MAXSTORAGEITEM = 50;
        public const int LOGICALMAPUNIT = 40;
    }

 

    public class TOSObject
    {
        public byte btType;
        public object CellObj;
        public uint dwAddTime;
        public bool boObjectDisPose;
    }

    public class TLoadDoubleHero
    {
        public string sAccount;
        public string sChrName;
        public string sUserAddr;
        public byte btJob;
        public int nSessionID;
    }

    public struct TShortMessage
    {
        public ushort Ident;
        public ushort wMsg;
    } 

    public struct TQuestInfo
    {
        public ushort wFlag;
        public byte btValue;
        public int nRandRage;
    }

    /// <summary>
    /// 小地图配置信息
    /// </summary>
    public class TMinMapInfo
    {
        public int nIdx;
        public string sMapNO;
    }

    public class TScript
    {
        public bool boQuest;
        public TQuestInfo[] QuestInfo;
        public int nQuest;
        public IList<TSayingRecord> RecordList;
    }

    public class TItemName
    {
        public int nItemIndex;
        public int nMakeIndex;
        public string sItemName;
    }

    public class TIPAddr
    {
        public string dIPaddr;
        public string sIPaddr;
    }

    /// <summary>
    /// 管理员表
    /// </summary>
    public class TAdminInfo
    {
        public int nLv;
        public string sChrName;
        public string sIPaddr;
    } 

    /// <summary>
    /// 徒弟数量排行
    /// </summary>
    public class TMasterList
    {
        // 排名   
        public int ID;
        public string sChrName;
    }

    public class TVisibleMapEvent
    {
        public TEvent MapEvent;
        public int nVisibleFlag;
        public int nX;
        public int nY;
    }

    public class TVisibleBaseObject
    {
        public TBaseObject BaseObject;
        public int nVisibleFlag;
    }

    public class TObjectFeature
    {
        public byte btGender;
        public byte btWear;
        public byte btHair;
        public byte btWeapon;
    }
   
    public class TSellOffHeader
    {
        public int nItemCount;
    }


    public struct TStormsRate
    {
        public int nStormsRate;
        public int nMagicID;
    }

    public class TIdxRecord
    {
        public string[] sChrName;
        public int nIndex;
    }

    public class TGoldChangeInfo
    {
        public string sGameMasterName;
        public string sGetGoldUser;
        public int nGold;
    }

    public class TGateInfo
    {
        public TGateInfo()
        {
            this.Socket = null;
            this.boUsed = false;
            this.sAddr = string.Empty;
            this.n520 = -1;
            this.UserList = null;
            this.nUserCount = -1;
            //this.Buffer = IntPtr.Zero ;
            this.nBuffLen = -1;
            this.BufferList = null;
            this.boSendKeepAlive = false;
            this.nSendChecked = -1;
            this.nSendBlockCount = -1;
            this.dwTime544 = 0;
            this.nSendMsgCount = -1;
            this.nSendRemainCount = -1;
            this.dwSendTick = 0;
            this.nSendMsgBytes = 0;
            this.nSendedMsgCount = 0;
            this.nSendCount = 0;
            this.dwSendCheckTick = 0;
        }

        public Socket Socket;
        public bool boUsed;
        public string sAddr;
        public int nPort;
        public int n520;
        public IList<TGateUserInfo> UserList;
        public int nUserCount;// 连接人数
        public IntPtr Buffer;
        public int nBuffLen;
        public IList<IntPtr> BufferList;
        /// <summary>
        /// 连接是否断开
        /// </summary>
        public bool boSendKeepAlive;
        public int nSendChecked;
        public int nSendBlockCount;
        public uint dwTime544;
        public int nSendMsgCount;
        public int nSendRemainCount;
        public uint dwSendTick;
        public int nSendMsgBytes;
        public int nSendBytesCount;
        public int nSendedMsgCount;
        public int nSendCount;
        public uint dwSendCheckTick;

        public static void InitGateList(ref TGateInfo[] g_GateArr)
        {
            for (int i = 0; i < g_GateArr.Length; i++)
            {
                g_GateArr[i] = new TGateInfo();
                InitValueForGate(g_GateArr[i]);
            }
        }

        private static void InitValueForGate(TGateInfo Gate)
        {
            Gate.Socket = null;
            Gate.boUsed = false;
             Gate.boSendKeepAlive = false;
            Gate.nSendMsgCount = 0;
            Gate.nSendRemainCount = 0;
            Gate.dwSendTick = HUtil32.GetTickCount();
            Gate.nSendMsgBytes = 0;
            Gate.nSendedMsgCount = 0;
        }
    }

    public class TItemEvent
    {
        public string m_sItemName;
        public int m_nMakeIndex;
        public string m_sMapName;
        public int m_nCurrX;
        public int m_nCurrY;
    }

    public class TRecordDeletedHeader
    {
        public bool boDeleted;
        public byte bt1;
        public byte bt2;
        public byte bt3;
        public DateTime CreateDate;
        public DateTime LastLoginDate;
        public int n14;
        public int nNextDeletedIdx;
    }


    public class TUserLevelSort
    {
        // 人物等级排行
        public int nIndex;
        public ushort wLevel;
        public string[] sChrName;
    } 

    public class THeroLevelSort
    {
        // 英雄等级排行
        public int nIndex;
        public ushort wLevel;
        public string sChrName;
        public string sHeroName;
    } 

    public class TUserMasterSort
    {
        // 徒弟数量排行
        public int nIndex;
        public int nMasterCount;
        public string sChrName;
    } 

    public class TFilterMsg
    {
        // 消息过滤
        public string sFilterMsg;
        public string sNewMsg;
    } // end TFilterMsg

    // 记路标石
    public class TagMapInfo
    {
        
        public string TagMapName;
        public int TagX;
        public int TagY;
    } 
}


