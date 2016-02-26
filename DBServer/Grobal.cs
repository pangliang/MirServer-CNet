
namespace DBServer
{
    public class Grobal2
    {
        //    public static TServerConfig g_ServerConfig =
        //{0, false, false, false, true, 100, false, false, false, false, 10000, 10000, 10000, 30000, 10000, 65535} ;
        public const int HEROVERSION = 1;

        // 编译开关 0=企业版 1=英雄版
        // ALLFUNCTION = 1;
        public const int CLIENT_VERSION_NUMBER = 120090701;

        // 版本号
        // ==============================================================================
        public const int ACCOUNTLEN = 30;

        public const int MAXPATHLEN = 255;
        public const int DIRPATHLEN = 80;
        public const int MAPNAMELEN = 16;
        public const int ACTORNAMELEN = 14;
        public const int DEFBLOCKSIZE = 16;
        public const int BUFFERSIZE = 12000;

        // 缓冲区大小
        public const int DATA_BUFSIZE2 = 16348;

        // 8192;
        public const int DATA_BUFSIZE = 8192;

        // 8192;
        public const int GROUPMAX = 11;

        public const int BAGGOLD = 5000000;
        public const int BODYLUCKUNIT = 10;
        public const int MAX_STATUS_ATTRIBUTE = 12;
        public const int DR_UP = 0;
        public const int DR_UPRIGHT = 1;
        public const int DR_RIGHT = 2;
        public const int DR_DOWNRIGHT = 3;
        public const int DR_DOWN = 4;
        public const int DR_DOWNLEFT = 5;
        public const int DR_LEFT = 6;
        public const int DR_UPLEFT = 7;
        public const int AT_FIRE = 1;

        // 火
        public const int AT_ICE = 2;

        // 冰
        public const int AT_LIGHT = 3;

        // 电
        public const int AT_WIND = 4;

        // 风
        public const int AT_HOLY = 5;

        // 神圣
        public const int AT_DARK = 6;

        // 暗黑
        public const int AT_PHANTOM = 7;

        // 幻影
        public const int U_DRESS = 0;

        // 衣服
        public const int U_WEAPON = 1;

        // 装备武器
        public const int U_RIGHTHAND = 2;

        // 右手
        public const int U_NECKLACE = 3;

        // 项链
        public const int U_HELMET = 4;

        // 头盔
        public const int U_ARMRINGL = 5;

        // 左手手镯
        public const int U_ARMRINGR = 6;

        // 右手手镯
        public const int U_RINGL = 7;

        // 左手戒指
        public const int U_RINGR = 8;

        // 右手戒指
        public const int U_BUJUK = 9;

        // 符
        public const int U_BELT = 10;

        // 腰带
        public const int U_BOOTS = 11;

        // 鞋
        public const int U_CHARM = 12;

        public const int POISON_DECHEALTH = 0;
        public const int POISON_DAMAGEARMOR = 1;
        public const int POISON_LOCKSPELL = 2;
        public const int POISON_DONTMOVE = 4;
        public const int POISON_STONE = 5;
        public const int STATE_TRANSPARENT = 8;
        public const int STATE_DEFENCEUP = 9;
        public const int STATE_MAGDEFENCEUP = 10;
        public const int STATE_BUBBLEDEFENCEUP = 11;
        public const int USERMODE_PLAYGAME = 1;
        public const int USERMODE_LOGIN = 2;
        public const int USERMODE_LOGOFF = 3;
        public const int USERMODE_NOTICE = 4;
        public const int RUNGATEMAX = 20;
        public const uint RUNGATECODE = 0xAA55AA55;

        // RUNGATECODE = $AA9AAA9A; BLUE
        public const int OS_MOVINGOBJECT = 1;

        public const int OS_ITEMOBJECT = 2;
        public const int OS_EVENTOBJECT = 3;
        public const int OS_GATEOBJECT = 4;
        public const int OS_SWITCHOBJECT = 5;
        public const int OS_MAPEVENT = 6;
        public const int OS_DOOR = 7;
        public const int OS_ROON = 8;
        public const int OS_OBJECTGATE = 9;
        public const int RC_PLAYOBJECT = 0;
        public const int RC_DUMMOBJECT = 1;

        // 假人
        public const int RC_MOONOBJECT = 60;

        // 月灵
        public const int RC_HEROOBJECT = 66;

        // 英雄
        public const int RC_GUARD = 11;

        // 大刀守卫
        public const int RC_PEACENPC = 15;

        public const int RC_ANIMAL = 50;
        public const int RC_MONSTER = 80;
        public const int RC_NPC = 10;
        public const int RC_ARCHERGUARD = 112;
        public const int RC_PLAYMOSTER = 150;

        // 人形怪物
        public const int RCC_USERHUMAN = RC_PLAYOBJECT;

        public const int RCC_GUARD = RC_GUARD;
        public const int RCC_MERCHANT = RC_ANIMAL;
        public const int ISM_WHISPER = 1234;
        public const int CM_QUERYCHR = 100;

        // 查询角色
        public const int CM_NEWCHR = 101;

        // 创建角色
        public const int CM_DELCHR = 102;

        // 删除角色
        public const int CM_SELCHR = 103;

        // 选择角色
        public const int CM_SELECTSERVER = 104;

        // 选择服务器
        public const int CM_QUERYDELCHR = 105;

        // 查询删除角色
        public const int CM_RESTORECHR = 106;

        // 恢复角色
        public const int CM_QUERYSERVERNAME = 107;

        // 查询服务器列表
        public const int CM_QUERYRANDOMCODE = 108;

        // 查询验证码
        public const int CM_SENDRANDOMCODE = 109;

        // 验证验证码
        public const int SM_RUSH = 6;

        public const int SM_RUSHKUNG = 7;
        public const int SM_FIREHIT = 8;

        // 烈火
        public const int SM_BACKSTEP = 9;

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

        public const int SM_LONGHIT = 19;

        // 刺杀
        public const int SM_DIGUP = 20;

        public const int SM_DIGDOWN = 21;
        public const int SM_FLYAXE = 22;
        public const int SM_LIGHTING = 23;

        // 免蜡开关
        public const int SM_WIDEHIT = 24;

        public const int SM_CRSHIT = 25;
        public const int SM_TWINHIT = 26;

        // SM_27 = 27;
        // SM_28 = 28;
        // SM_29 = 29;
        // SM_30 = 30;
        // SM_31 = 31;
        // SM_32 = 32;
        //
        // SM_40 = 40;
        // SM_41 = 41;
        // SM_42 = 42;
        // SM_43 = 43;
        // SM_44 = 44;
        // SM_45 = 45;
        public const int SM_40 = 35;

        public const int SM_41 = 36;
        public const int SM_42 = 37;
        public const int SM_43 = 38;
        public const int SM_44 = 39;
        public const int SM_60HIT = 60;
        public const int SM_61HIT = 61;
        public const int SM_62HIT = 62;
        public const int SM_63HIT = 63;
        public const int SM_64HIT = 64;
        public const int SM_65HIT = 65;
        public const int SM_66HIT = 66;
        public const int SM_67HIT = 67;
        public const int SM_68HIT = 68;
        public const int SM_69HIT = 69;
        public const int SM_70HIT = 70;
        public const int SM_PKHIT = SM_66HIT;
        public const int SM_KTHIT = SM_67HIT;
        public const int SM_ZRJFHIT = SM_68HIT;

        // 逐日剑法
        public const int SM_SUPERFIREHIT = SM_70HIT;

        // 4级烈火
        public const int SM_100HIT = 300;

        // 三绝杀
        public const int SM_101HIT = 301;

        // 追心刺
        public const int SM_102HIT = 302;

        // 断岳斩
        public const int SM_103HIT = 303;

        // 横扫千军
        public const int SM_ALIVE = 27;

        // 复活
        public const int SM_MOVEFAIL = 28;

        public const int SM_HIDE = 29;
        public const int SM_DISAPPEAR = 30;
        public const int SM_STRUCK = 31;

        // 弯腰
        public const int SM_DEATH = 32;

        // 死亡
        public const int SM_SKELETON = 33;

        // 尸体
        public const int SM_NOWDEATH = 34;

        // 秒杀
        public const int SM_ACTION_MIN = SM_RUSH;

        public const int SM_ACTION_MAX = SM_WIDEHIT;
        public const int SM_ACTION2_MIN = 65072;
        public const int SM_ACTION2_MAX = 65073;
        public const int SM_HEAR = 40;

        // 回话
        public const int SM_FEATURECHANGED = 41;

        public const int SM_USERNAME = 42;
        public const int SM_WINEXP = 44;

        // 获取经验
        public const int SM_LEVELUP = 45;

        // 升级
        public const int SM_DAYCHANGING = 46;

        // 太阳月亮
        public const int SM_LOGON = 50;

        // 登陆
        public const int SM_NEWMAP = 51;

        // 新地图
        public const int SM_ABILITY = 52;

        // 打开属性对话框
        public const int SM_HEALTHSPELLCHANGED = 53;

        // 治愈术增加血
        public const int SM_MAPDESCRIPTION = 54;

        // 地图描述
        public const int SM_SPELL2 = 117;

        public const int SM_SYSMESSAGE = 100;

        // 系统消息
        public const int SM_GROUPMESSAGE = 101;

        public const int SM_CRY = 102;

        // 喊话
        public const int SM_WHISPER = 103;

        // 私聊
        public const int SM_GUILDMESSAGE = 104;

        // 行会消息
        public const int SM_MOVEMESSAGE = 105;

        public const int SM_ADDITEM = 200;
        public const int SM_BAGITEMS = 201;
        public const int SM_DELITEM = 202;
        public const int SM_UPDATEITEM = 203;
        public const int SM_UPDATEITEM2 = 204;
        public const int SM_ADDMAGIC = 210;
        public const int SM_SENDMYMAGIC = 211;
        public const int SM_DELMAGIC = 212;
        public const int SM_CERTIFICATION_FAIL = 501;
        public const int SM_ID_NOTFOUND = 502;
        public const int SM_PASSWD_FAIL = 503;

        // 验证失败
        public const int SM_NEWID_SUCCESS = 504;

        // 建立帐号成功
        public const int SM_NEWID_FAIL = 505;

        // 建立帐号失败
        public const int SM_CHGPASSWD_SUCCESS = 506;

        // 修改密码成功
        public const int SM_CHGPASSWD_FAIL = 507;

        // 修改密码失败
        public const int SM_GETBACKPASSWD_SUCCESS = 508;

        // 密码找回成功
        public const int SM_GETBACKPASSWD_FAIL = 509;

        // 密码找回失败
        public const int SM_QUERYCHR = 520;

        // 查询角色信息
        public const int SM_NEWCHR_SUCCESS = 521;

        // 新建角色成功
        public const int SM_NEWCHR_FAIL = 522;

        // 新建角色失败
        public const int SM_DELCHR_SUCCESS = 523;

        // 删除角色成功
        public const int SM_DELCHR_FAIL = 524;

        // 删除角色失败
        public const int SM_STARTPLAY = 525;

        // 开始游戏成功
        public const int SM_STARTFAIL = 526;

        // SM_USERFULL  开始游戏失败
        public const int SM_QUERYCHR_FAIL = 527;

        // 查询角色失败
        public const int SM_OUTOFCONNECTION = 528;

        // 超过最大连接 ,强迫用户下线
        public const int SM_PASSOK_SELECTSERVER = 529;

        public const int SM_SELECTSERVER_OK = 530;

        // 选择服务器
        public const int SM_NEEDUPDATE_ACCOUNT = 531;

        public const int SM_UPDATEID_SUCCESS = 532;
        public const int SM_UPDATEID_FAIL = 533;
        public const int SM_FINDDELCHR = 534;
        public const int SM_FINDDELCHR_SUCCESS = 535;
        public const int SM_FINDDELCHR_FAIL = 536;
        public const int SM_SERVERNAME = 537;

        // 服务器列表
        public const int SM_SENDRANDOMCODE = 538;

        // 发送验证码
        public const int SM_DROPITEM_SUCCESS = 600;

        public const int SM_DROPITEM_FAIL = 601;
        public const int SM_ITEMSHOW = 610;
        public const int SM_ITEMHIDE = 611;

        // SM_DOOROPEN           = 612;
        public const int SM_OPENDOOR_OK = 612;

        // 通过门
        public const int SM_OPENDOOR_LOCK = 613;

        // 通过门锁 以前盛大秘密通道去赤月的门要5分钟开一次
        public const int SM_CLOSEDOOR = 614;

        // 关门
        public const int SM_TAKEON_OK = 615;

        public const int SM_TAKEON_FAIL = 616;
        public const int SM_TAKEOFF_OK = 619;
        public const int SM_TAKEOFF_FAIL = 620;
        public const int SM_SENDUSEITEMS = 621;
        public const int SM_WEIGHTCHANGED = 622;
        public const int SM_CLEAROBJECTS = 633;
        public const int SM_CHANGEMAP = 634;

        // 改变地图
        public const int SM_EAT_OK = 635;

        public const int SM_EAT_FAIL = 636;
        public const int SM_BUTCH = 637;
        public const int SM_MAGICFIRE = 638;
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

        // 负重持久
        public const int SM_LAMPCHANGEDURA = 655;

        // 蜡烛持久改变
        public const int SM_CHANGENAMECOLOR = 656;

        // 名字颜色改变
        public const int SM_CHARSTATUSCHANGED = 657;

        public const int SM_SENDNOTICE = 658;

        // 发送游戏公告
        public const int SM_GROUPMODECHANGED = 659;

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
        public const int SM_DEALDELITEM_FAIL = 678;
        public const int SM_DEALCANCEL = 681;
        public const int SM_DEALREMOTEADDITEM = 682;
        public const int SM_DEALREMOTEDELITEM = 683;
        public const int SM_DEALCHGGOLD_OK = 684;
        public const int SM_DEALCHGGOLD_FAIL = 685;
        public const int SM_DEALREMOTECHGGOLD = 686;
        public const int SM_DEALSUCCESS = 687;
        public const int SM_SENDUSERSTORAGEITEM = 700;
        public const int SM_STORAGE_OK = 701;
        public const int SM_STORAGE_FULL = 702;
        public const int SM_STORAGE_FAIL = 703;
        public const int SM_SAVEITEMLIST = 704;
        public const int SM_TAKEBACKSTORAGEITEM_OK = 705;
        public const int SM_TAKEBACKSTORAGEITEM_FAIL = 706;
        public const int SM_TAKEBACKSTORAGEITEM_FULLBAG = 707;
        public const int SM_AREASTATE = 708;

        // 周围状态
        public const int SM_MYSTATUS = 766;

        // 我的状态
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

        // 打开辅助属性对话框
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

        public const int SM_SPACEMOVE_SHOW = 801;
        public const int SM_RECONNECT = 802;

        // 与服务器重新连接
        public const int SM_GHOST = 803;

        public const int SM_SHOWEVENT = 804;
        public const int SM_HIDEEVENT = 805;
        public const int SM_SPACEMOVE_HIDE2 = 806;
        public const int SM_SPACEMOVE_SHOW2 = 807;
        public const int SM_TIMECHECK_MSG = 810;

        // 时钟检测以免客户端作弊
        public const int SM_ADJUST_BONUS = 811;

        // ?
        public const int SM_OPENHEALTH = 1100;

        public const int SM_CLOSEHEALTH = 1101;
        public const int SM_BREAKWEAPON = 1102;

        // 武器破碎
        public const int SM_INSTANCEHEALGUAGE = 1103;

        // 实时治愈
        public const int SM_CHANGEFACE = 1104;

        public const int SM_VERSION_FAIL = 1106;

        // 验证版本失败
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
        public const int RM_RUSH = 10015;
        public const int RM_STRUCK = 10020;
        public const int RM_DEATH = 10021;
        public const int RM_DISAPPEAR = 10022;
        public const int RM_MAGSTRUCK = 10025;
        public const int RM_MAGHEALING = 10026;
        public const int RM_STRUCK_MAG = 10027;
        public const int RM_MAGSTRUCK_MINE = 10028;
        public const int RM_INSTANCEHEALGUAGE = 10029;

        // jacky
        public const int RM_HEAR = 10030;

        public const int RM_WHISPER = 10031;
        public const int RM_CRY = 10032;
        public const int RM_RIDE = 10033;
        public const int RM_WINEXP = 10044;
        public const int RM_USERNAME = 10043;
        public const int RM_LEVELUP = 10045;
        public const int RM_CHANGENAMECOLOR = 10046;
        public const int RM_LOGON = 10050;
        public const int RM_ABILITY = 10051;
        public const int RM_HEALTHSPELLCHANGED = 10052;
        public const int RM_DAYCHANGING = 10053;
        public const int RM_SYSMESSAGE = 10100;
        public const int RM_GROUPMESSAGE = 10102;

        // 组队聊天
        public const int RM_SYSMESSAGE2 = 10103;

        public const int RM_GUILDMESSAGE = 10104;

        // 行会聊天
        public const int RM_SYSMESSAGE3 = 10105;

        // Jacky
        public const int RM_DELAYMESSAGE = 10106;

        public const int RM_DELETEDELAYMESSAGE = 10107;
        public const int RM_CENTERMESSAGE = 10108;
        public const int RM_ITEMSHOW = 10110;
        public const int RM_ITEMHIDE = 10111;
        public const int RM_DOOROPEN = 10112;
        public const int RM_DOORCLOSE = 10113;
        public const int RM_SENDUSEITEMS = 10114;
        public const int RM_WEIGHTCHANGED = 10115;
        public const int RM_MOVEMESSAGE = 10240;
        public const int RM_FEATURECHANGED = 10116;
        public const int RM_CLEAROBJECTS = 10117;
        public const int RM_CHANGEMAP = 10118;
        public const int RM_BUTCH = 10119;
        public const int RM_MAGICFIRE = 10120;
        public const int RM_SENDMYMAGIC = 10122;
        public const int RM_MAGIC_LVEXP = 10123;
        public const int RM_SKELETON = 10024;
        public const int RM_DURACHANGE = 10125;
        public const int RM_MERCHANTSAY = 10126;
        public const int RM_GOLDCHANGED = 10136;
        public const int RM_CHANGELIGHT = 10137;
        public const int RM_CHARSTATUSCHANGED = 10139;
        public const int RM_DELAYMAGIC = 10154;
        public const int RM_DIGUP = 10200;
        public const int RM_DIGDOWN = 10201;
        public const int RM_FLYAXE = 10202;
        public const int RM_LIGHTING = 10204;
        public const int RM_SUBABILITY = 10302;
        public const int RM_TRANSPARENT = 10308;
        public const int RM_SPACEMOVE_SHOW = 10331;
        public const int RM_RECONNECTION = 11332;
        public const int RM_SPACEMOVE_SHOW2 = 10332;

        // ?
        public const int RM_HIDEEVENT = 10333;

        public const int RM_SHOWEVENT = 10334;
        public const int RM_ZEN_BEE = 10337;
        public const int RM_OPENHEALTH = 10410;
        public const int RM_CLOSEHEALTH = 10411;
        public const int RM_DOOPENHEALTH = 10412;
        public const int RM_CHANGEFACE = 10415;
        public const int RM_ITEMUPDATE = 11000;
        public const int RM_MONSTERSAY = 11001;
        public const int RM_MAKESLAVE = 11002;
        public const int RM_SUPERFIREHIT = 11003;
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
        public const int SS_215 = 215;
        public const int SS_216 = 216;
        public const int RM_10205 = 10205;
        public const int RM_10206 = 10206;
        public const int RM_10101 = 10101;
        public const int RM_ALIVE = 10153;
        public const int RM_CHANGEGUILDNAME = 10301;
        public const int RM_10414 = 10414;
        public const int RM_POISON = 10300;
        public const int LA_UNDEAD = 1;

        // 未知;
        public const int RM_DELAYPUSHED = 10555;

        public const int CM_GETBACKPASSWORD = 2010;

        // 密码找回
        public const int CM_SPELL = 3017;

        // 施魔法
        public const int CM_QUERYUSERNAME = 80;

        public const int CM_DROPITEM = 1000;

        // 扔松溪
        public const int CM_PICKUP = 1001;

        // 捡东西
        public const int CM_TAKEONITEM = 1003;

        // 装备物品
        public const int CM_TAKEOFFITEM = 1004;

        // 卸载装备
        public const int CM_EAT = 1006;

        // 吃药
        public const int CM_BUTCH = 1007;

        public const int CM_MAGICKEYCHANGE = 1008;
        public const int CM_1005 = 1005;
        public const int CM_CLICKNPC = 1010;

        // 点击npc
        public const int CM_MERCHANTDLGSELECT = 1011;

        // 商品选择
        public const int CM_MERCHANTQUERYSELLPRICE = 1012;

        // 返回价格
        public const int CM_USERSELLITEM = 1013;

        // 买麦西
        public const int CM_USERBUYITEM = 1014;

        // 买东西
        public const int CM_USERGETDETAILITEM = 1015;

        public const int CM_DROPGOLD = 1016;

        // 扔掉钱币
        public const int CM_LOGINNOTICEOK = 1018;

        // 健康游戏公告
        public const int CM_GROUPMODE = 1019;

        public const int CM_CREATEGROUP = 1020;
        public const int CM_ADDGROUPMEMBER = 1021;
        public const int CM_DELGROUPMEMBER = 1022;
        public const int CM_USERREPAIRITEM = 1023;

        // 修理物品
        public const int CM_MERCHANTQUERYREPAIRCOST = 1024;

        // 获取修理费用
        public const int CM_DEALTRY = 1025;

        // 开始交易
        public const int CM_DEALADDITEM = 1026;

        // 交易增加物品
        public const int CM_DEALDELITEM = 1027;

        // 交易减少物品
        public const int CM_DEALCANCEL = 1028;

        // 取消交易
        public const int CM_DEALCHGGOLD = 1029;

        // 交易金钱
        public const int CM_DEALEND = 1030;

        // 交易完成
        public const int CM_USERSTORAGEITEM = 1031;

        // 寄存物品
        public const int CM_USERTAKEBACKSTORAGEITEM = 1032;

        // 取回物品
        public const int CM_WANTMINIMAP = 1033;

        public const int CM_USERMAKEDRUGITEM = 1034;

        // 制造毒品
        public const int CM_OPENGUILDDLG = 1035;

        // 行会
        public const int CM_GUILDHOME = 1036;

        // 行会主页
        public const int CM_GUILDMEMBERLIST = 1037;

        // 成员猎豹
        public const int CM_GUILDADDMEMBER = 1038;

        // 添加成员
        public const int CM_GUILDDELMEMBER = 1039;

        // 删除成员
        public const int CM_GUILDUPDATENOTICE = 1040;

        // 修改公告
        public const int CM_GUILDUPDATERANKINFO = 1041;

        // 更新联盟信息
        public const int CM_ADJUST_BONUS = 1043;

        public const int CM_SPEEDHACKUSER = 10430;

        // ??
        public const int CM_PASSWORD = 1105;

        public const int CM_CHGPASSWORD = 1221;

        // ?
        public const int CM_SETPASSWORD = 1222;

        // ?
        public const int CM_HORSERUN = 3009;

        public const int CM_THROW = 3005;

        // 抛符
        public const int CM_TURN = 3010;

        // 转身
        public const int CM_WALK = 3011;

        // 走
        public const int CM_SITDOWN = 3012;

        // 挖
        public const int CM_RUN = 3013;

        // 跑
        public const int CM_HIT = 3014;

        // 普通物理近身攻击
        public const int CM_HEAVYHIT = 3015;

        public const int CM_BIGHIT = 3016;
        public const int CM_POWERHIT = 3018;

        // 攻杀
        public const int CM_LONGHIT = 3019;

        // 刺杀
        public const int CM_WIDEHIT = 3024;

        // 半月
        public const int CM_FIREHIT = 3025;

        // 烈火
        public const int CM_CRSHIT = 3036;

        // 抱月刀
        public const int CM_TWNHIT = 3037;

        // 狂风斩
        public const int CM_TWINHIT = CM_TWNHIT;

        public const int CM_PHHIT = 3038;

        // 破魂斩
        public const int CM_26HIT = 3026;

        public const int CM_27HIT = 3027;
        public const int CM_28HIT = 3028;
        public const int CM_29HIT = 3029;
        public const int CM_40HIT = 3040;
        public const int CM_41HIT = 3041;
        public const int CM_42HIT = 3042;
        public const int CM_43HIT = 3043;
        public const int CM_60HIT = 3060;
        public const int CM_61HIT = 3061;
        public const int CM_62HIT = 3062;
        public const int CM_63HIT = 3063;
        public const int CM_64HIT = 3064;
        public const int CM_65HIT = 3065;
        public const int CM_PKHIT = 3066;
        public const int CM_KTHIT = 3067;
        public const int CM_ZRJFHIT = 3068;

        // 逐日剑法
        public const int CM_100HIT = 3300;

        // 三绝杀
        public const int CM_101HIT = 3301;

        // 追心刺
        public const int CM_102HIT = 3302;

        // 断岳斩
        public const int CM_103HIT = 3303;

        // 横扫千军
        public const int CM_SAY = 3030;

        // 角色发言
        public const int RM_10401 = 10401;

        public const int STATE_STONE_MODE = 1;
        public const int RM_MENU_OK = 10309;
        public const int RM_MERCHANTDLGCLOSE = 10127;
        public const int RM_SENDDELITEMLIST = 10148;
        public const int RM_SENDUSERSREPAIR = 10141;
        public const int RM_SENDGOODSLIST = 10128;
        public const int RM_SENDUSERSELL = 10129;
        public const int RM_SENDUSERREPAIR = 11139;
        public const int RM_USERMAKEDRUGITEMLIST = 10149;
        public const int RM_USERSTORAGEITEM = 10146;
        public const int RM_USERGETBACKITEM = 10147;
        public const int RM_USERBIGSTORAGEITEM = 20146;
        public const int RM_USERBIGGETBACKITEM = 20147;
        public const int RM_USERLEVELORDER = 20148;
        public const int RM_SPACEMOVE_FIRE2 = 11330;
        public const int RM_SPACEMOVE_FIRE = 11331;
        public const int RM_BUYITEM_SUCCESS = 10133;
        public const int RM_BUYITEM_FAIL = 10134;
        public const int RM_SENDDETAILGOODSLIST = 10135;
        public const int RM_SENDBUYPRICE = 10130;
        public const int RM_USERSELLITEM_OK = 10131;
        public const int RM_USERSELLITEM_FAIL = 10132;
        public const int RM_MAKEDRUG_SUCCESS = 10150;
        public const int RM_MAKEDRUG_FAIL = 10151;
        public const int RM_SENDREPAIRCOST = 10142;
        public const int RM_USERREPAIRITEM_OK = 10143;
        public const int RM_USERREPAIRITEM_FAIL = 10144;
        public const int MAXBAGITEM = 46;
        public const int MAXHEROBAGITEM = 40;

        // 英雄包裹
        public const int RM_10155 = 10155;

        public const int RM_PLAYDICE = 10500;
        public const int RM_ADJUST_BONUS = 10400;
        public const int RM_BUILDGUILD_OK = 10303;
        public const int RM_BUILDGUILD_FAIL = 10304;
        public const int RM_DONATE_OK = 10305;
        public const int RM_GAMEGOLDCHANGED = 10666;
        public const int STATE_OPENHEATH = 1;
        public const int POISON_68 = 68;
        public const int RM_MYSTATUS = 10777;
        public const int CM_QUERYUSERSTATE = 82;

        // 查询用户状态
        public const int CM_QUERYBAGITEMS = 81;

        // 查询角色物品
        public const int CM_QUERYUSERSET = 49999;

        public const int CM_OPENDOOR = 1002;

        // 开门
        public const int CM_SOFTCLOSE = 1009;

        // 客户端发送的命令 退出 打退或者小退
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
        public const int RM_44 = 44;
        public const int RM_60 = 60;
        public const int RM_61 = 61;
        public const int RM_62 = 62;
        public const int RM_ZRJF = 77;
        public const int RM_100HIT = 20100;
        public const int RM_101HIT = 20101;
        public const int RM_102HIT = 20102;
        public const int RM_103HIT = 20103;

        // RM_101HITA = 20104;
        public const int RM_MAGICFIREFAIL = 10121;

        public const int RM_LAMPCHANGEDURA = 10138;
        public const int RM_GROUPCANCEL = 10140;
        public const int RM_DONATE_FAIL = 10306;
        public const int RM_BREAKWEAPON = 10413;
        public const int RM_PASSWORD = 10416;
        public const int RM_PASSWORDSTATUS = 10601;
        public const int SM_HORSERUN = 5;
        public const int SM_716 = 716;
        public const int SM_717 = 717;
        public const int SM_PASSWORD = 3030;
        public const int SM_PLAYDICE = 1200;
        public const int SM_PASSWORDSTATUS = 20001;
        public const int SM_GAMEGOLDNAME = 55;

        // 游戏币名称
        public const int SM_SERVERCONFIG = 20002;

        public const int SM_GETREGINFO = 20003;
        public const int ET_DIGOUTZOMBI = 1;
        public const int ET_PILESTONES = 3;
        public const int ET_HOLYCURTAIN = 4;
        public const int ET_FIRE = 5;
        public const int ET_SCULPEICE = 6;

        // 6种烟花
        public const int ET_FIREFLOWER_1 = 7;

        public const int ET_FIREFLOWER_2 = 8;
        public const int ET_FIREFLOWER_3 = 9;
        public const int ET_FIREFLOWER_4 = 10;
        public const int ET_FIREFLOWER_5 = 11;
        public const int ET_FIREFLOWER_6 = 12;
        public const int ET_FIREFLOWER_7 = 13;
        public const int ET_FIREFLOWER_8 = 14;
        public const int ET_MAGICLOCK = 15;
        public const int ET_MAPMAGIC = 16;

        // 5种空间门
        public const int ET_SPACEDOOR_1 = 17;

        public const int ET_SPACEDOOR_2 = 18;
        public const int ET_SPACEDOOR_3 = 19;
        public const int ET_SPACEDOOR_4 = 20;
        public const int ET_SPACEDOOR_5 = 21;
        public const int ET_SPACEDOOR_6 = 22;
        public const int CM_PROTOCOL = 2000;
        public const int CM_IDPASSWORD = 2001;

        // 发送帐号密码
        public const int CM_ADDNEWUSER = 2002;

        // 新建用户
        public const int CM_CHANGEPASSWORD = 2003;

        // 修改密码
        public const int CM_UPDATEUSER = 2004;

        public const int CM_RANDOMCODE = 2006;

        // 随机代码
        public const int SM_RANDOMCODE = 2007;

        public const int CM_3037 = 3037;
        public const int SM_NEEDPASSWORD = 8003;
        public const int CM_POWERBLOCK = 0;

        // 商铺相关
        public const int CM_OPENSHOP = 9000;

        public const int CM_BUYSHOPITEM = 9002;
        public const int SM_BUYSHOPITEM_SUCCESS = 9003;
        public const int SM_BUYSHOPITEM_FAIL = 9004;
        public const int SM_SENGSHOPITEMS = 9001;

        // SERIES 7 每页的数量    wParam 总页数
        // ==============================================================================
        public const int CM_QUERYUSERLEVELSORT = 3500;

        // 用户等级排行
        public const int RM_QUERYUSERLEVELSORT = 35000;

        public const int SM_QUERYUSERLEVELSORT = 2500;

        // ==============================新增物品寄售系统==============================
        public const int CM_SENDSELLOFFGOODSLIST = 20008;

        // 查询寄售物品
        public const int CM_SENDSEARCHSELLITEM = 20012;

        // 指定物品名查询寄售物品
        public const int CM_SENDGETSELLITEMGOLD = 20013;

        // 指定物品名查询寄售物品
        public const int RM_SENDSELLOFFGOODSLIST = 21008;

        public const int SM_SENDSELLOFFGOODSLIST = 20008;
        public const int RM_SENDUSERSELLOFFITEM = 21005;
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
        public const int RM_SENDSERVERCONFIG = 30011;

        public const int RM_GETSELBOXITEMNUM = 30012;
        public const int SM_USERCASTLE = 5100;

        // 沙行会信息
        public const int CM_ONHORSE = 5059;

        public const int SM_SHOWITEMBOX = 5061;
        public const int CM_OPENITEMBOX = 5062;
        public const int SM_OPENITEMBOX_OK = 5063;
        public const int SM_OPENITEMBOX_FAIL = 5064;
        public const int CM_GETSELBOXITEMNUM = 5065;
        public const int SM_GETSELBOXITEMNUM = 5066;
        public const int CM_GETSELBOXITEM = 5067;
        public const int RM_OPENBOOK = 30013;
        public const int SM_OPENBOOK = 5068;
        public const int RM_OPENITEMBOX = 30014;
        public const int CM_SENDCHANGEITEM = 5069;
        public const int SM_SENDCHANGEITEM_FAIL = 5070;
        public const int SM_SENDCHANGEITEM_OK = 5071;
        public const int SM_SENDCHANGEITEM = 5072;
        public const int RM_SENDCHANGEITEM = 30015;
        public const int RM_SENDCHANGEITEM_OK = 30016;
        public const int RM_SENDCHANGEITEM_FAIL = 30017;
        public const int CM_SENDUPGRADEITEM = 5073;
        public const int SM_SENDUPGRADEITEM_FAIL = 5074;
        public const int SM_SENDUPGRADEITEM_OK = 5075;
        public const int CM_DUELTRY = 4078;
        public const int CM_DUELADDITEM = 4079;
        public const int CM_DUELDELITEM = 4080;
        public const int CM_DUELCANCEL = 4081;
        public const int CM_DUELCHGGOLD = 4082;
        public const int CM_DUELEND = 4083;
        public const int SM_DUELTRY_FAIL = 4084;
        public const int SM_DUELMENU = 4085;
        public const int SM_DUELCANCEL = 4086;
        public const int SM_DUELADDITEM_OK = 4087;
        public const int SM_DUELADDITEM_FAIL = 4088;
        public const int SM_DUELDELITEM_OK = 4089;
        public const int SM_DUELDELITEM_FAIL = 4090;
        public const int SM_DUELREMOTEADDITEM = 4091;
        public const int SM_DUELREMOTEDELITEM = 4092;
        public const int SM_DUELCHGGOLD_OK = 4093;
        public const int SM_DUELCHGGOLD_FAIL = 4094;
        public const int SM_DUELREMOTECHGGOLD = 4095;
        public const int SM_DUELSUCCESS = 4096;
        public const int CM_GETREGINFO_OK = 4097;
        public const int CM_HEROATTACK = 5097;

        // 英雄挂机
        public const int CM_GETBACKITEMBOX = 5098;

        // 取回宝箱
        public const int SM_GETBACKITEMBOX_OK = 5099;

        // 取回宝箱成功
        public const int SM_GETBACKITEMBOX_FAIL = 5100;

        // 取回宝箱失败
        public const int RM_QUERYBAGITEMS = 5101;

        public const int RM_QUERYHEROBAGITEMS = 5102;
        public const int RM_SAVEITEMLIST = 5103;
        public const int SM_STATE_BUBBLEDEFENCEUP = 5104;

        // 护体神盾
        public const int RM_STATE_BUBBLEDEFENCEUP = 5105;

        // 护体神盾
        public const int CM_GETREGINFO = 5106;

        public const int RM_SENDREGINFO = 5107;
        public const int SM_SENDOPENHOMEPAGE = 5108;
        public const int RM_SENDOPENHOMEPAGE = 5109;
        public const int CM_SENDFINDITEMINFO = 5110;
        public const int SM_SENDFINDITEMINFO_OK = 5111;
        public const int SM_SENDFINDITEMINFO_FAIL = 5112;
        public const int SM_SENDSNOW = 5113;
        public const int SM_SENDSTORE = 5114;

        // 摆摊状态
        public const int CM_STARTSTORE = 5115;

        // 开始摆摊
        public const int CM_STOPSTORE = 5116;

        // 停止摆摊
        public const int CM_QUERYSTORE = 5117;

        // 查询摆摊
        public const int SM_DELSTOREITEM = 5118;

        // 删除摆摊物品
        public const int SM_USERSENDSTOREMSG = 5119;

        // 用户输入的信息
        public const int SM_USERSTOREITEMS = 5120;

        // 用户摆摊物品
        public const int CM_BUYSTOREITEM = 5121;

        // 购买摆摊物品
        public const int SM_SENDBUYSTOREITEM_OK = 5122;

        // 购买成功
        public const int SM_SENDBUYSTOREITEM_FAIL = 5123;

        // 购买失败
        public const int SM_SENDSTARTSTORE_OK = 5124;

        // 摆摊成功
        public const int SM_SENDSTOPSTORE_OK = 5125;

        // 停止摆摊成功
        public const int SM_SENDSTARTSTORE_FAIL = 5126;

        // 摆摊失败
        public const int RM_SENDSTORE = 5126;

        // 摆摊状态
        public const int SM_NEWSTATUS = 5127;

        public const int SM_AUTOGOTOXY = 5128;
        public const int SM_DELAYMESSAGE = 5129;
        public const int SM_DELETEDELAYMESSAGE = 5130;

        // 排行榜
        public const int CM_GETRANKING = 5131;

        public const int CM_GETMYRANKING = 5132;
        public const int SM_SENGRANKING = 5133;
        public const int SM_SENGMYRANKING_FAIL = 5134;

        // //////////////////////////////////////////////////////////////////////////////
        public const int CM_HEROLOGON = 5135;

        // 召唤英雄
        public const int CM_HEROLOGOUT = 5136;

        // 英雄退出
        public const int CM_MASTERBAGTOHEROBAG = 5137;

        // 主人包裹物品放到英雄包裹
        public const int CM_HEROBAGTOMASTERBAG = 5138;

        // 英雄包裹物品放到主人包裹
        public const int CM_HEROTAKEONITEM = 5139;

        // 英雄穿装备
        public const int CM_HEROTAKEOFFITEM = 5140;

        // 英雄脱装备
        public const int CM_HEROTAKEONITEMFROMMASTER = 5141;

        // 英雄穿装备从主人
        public const int CM_HEROTAKEOFFITEMTOMASTER = 5142;

        // 英雄脱装备到主人
        public const int CM_TAKEONITEMFROMHERO = 5143;

        // 主人穿装备从英雄包裹
        public const int CM_TAKEOFFITEMTOHERO = 5144;

        // 主人脱装备到英雄包裹
        public const int CM_HEROEAT = 5145;

        // 英雄吃药
        public const int CM_HEROTARGET = 5146;

        // 锁定//Ident: 1105 Recog: 260806992 Param: 0 Tag: 32 Series: 0   Recog= 锁定对象   Param=X  Tag=Y
        public const int CM_HERODROPITEM = 5147;

        // 英雄扔物品
        public const int CM_HEROGROUPATTACK = 5148;

        // 合击
        public const int CM_HEROMAGICKEYCHANGE = 5149;

        // BLUE_READ_656 = 656;
        // BLUE_READ_657 = 657; //Ident: 657 Recog: 759418336 Param: 0 Tag: 32 Series: 0
        public const int SM_MASTERBAGTOHEROBAG_OK = 5150;

        // 主人包裹物品放到英雄包裹成功
        public const int SM_MASTERBAGTOHEROBAG_FAIL = 5151;

        // 主人包裹物品放到英雄包裹失败
        public const int SM_HEROBAGTOMASTERBAG_OK = 5152;

        // 英雄包裹物品放到主人包裹成功
        public const int SM_HEROBAGTOMASTERBAG_FAIL = 5153;

        // 英雄包裹物品放到主人包裹失败
        public const int SM_HEROTAKEONITEMFROMMASTER_OK = 5154;

        // 英雄穿装备从主人  成功
        public const int SM_HEROTAKEONITEMFROMMASTER_FAIL = 5155;

        // 英雄穿装备从主人 失败
        public const int SM_HEROTAKEOFFITEMTOMASTER_OK = 5156;

        // 英雄脱装备到主人   成功
        public const int SM_HEROTAKEOFFITEMTOMASTER_FAIL = 5157;

        // 英雄脱装备到主人  失败
        public const int SM_TAKEONITEMFROMHERO_OK = 5158;

        // 主人穿装备从英雄包裹   成功
        public const int SM_TAKEONITEMFROMHERO_FAIL = 5159;

        // 主人穿装备从英雄包裹 失败
        public const int SM_TAKEOFFITEMTOHERO_OK = 5160;

        // 主人脱装备到英雄包裹    成功
        public const int SM_TAKEOFFITEMTOHERO_FAIL = 5161;

        // 主人脱装备到英雄包裹  失败
        public const int SM_HEROBAGCOUNT = 5162;

        // 英雄包裹数量
        public const int SM_HEROLOGOUT = 5163;

        // 获取英雄 TMessageBodyWL 产生英雄退出效果
        public const int SM_HEROLOGON = 5164;

        // 获取英雄 TMessageBodyWL 产生英雄登陆效果
        // BLUE_READ_898 = 5165; //获取英雄忠诚  10001(忠00.00%)
        // BLUE_READ_899 = 5166; //获取英雄信息
        public const int SM_HEROABILITY = 5167;

        // 获取英雄Abil
        public const int SM_HEROSUBABILITY = 5168;

        // 英雄SUBABILITY
        public const int SM_HEROBAGITEMS = 5169;

        // 获取英雄包裹     Tag:包裹物品数量 2 Series: 包裹总数量10
        public const int SM_SENDHEROUSEITEMS = 5170;

        // 获取英雄身上装备
        public const int SM_SENDMYHEROMAGIC = 5171;

        // 获取英雄魔法
        public const int SM_HEROADDITEM = 5172;

        // 英雄 Ident: 905 Recog: 738569296 Param: 0 Tag: 0 Series: 1   AddItem
        public const int SM_HERODELITEM = 5173;

        // 英雄 Ident: 906 Recog: 738569296 Param: 0 Tag: 0 Series: 1   delItem
        public const int SM_HEROTAKEON_OK = 5174;

        // 英雄穿装备OK Ident: 907 Recog: 742933632 Param: 0 Tag: 0 Series: 0
        public const int SM_HEROTAKEON_FAIL = 5175;

        // 英雄穿装备FAIL
        public const int SM_HEROTAKEOFF_OK = 5176;

        // 英雄脱装备OK
        public const int SM_HEROTAKEOFF_FAIL = 5177;

        // 英雄脱装备FAIL
        public const int SM_HEROEAT_OK = 5178;

        // 英雄吃药OK
        public const int SM_HEROEAT_FAIL = 5179;

        // 英雄吃药FAIL
        public const int SM_HEROADDMAGIC = 5180;

        // 英雄增加魔法
        public const int SM_HERODELMAGIC = 5181;

        // 英雄删除魔法
        public const int SM_HEROANGERVALUE = 5182;

        // 英雄怒值改变 Ident: 916 Recog: 5 Param: 2 Tag: 102 Series: 0
        public const int SM_HEROLOGON_OK = 5183;

        // 英雄登陆OK
        public const int SM_HEROLOGOUT_OK = 5184;

        // 英雄退出OK
        public const int SM_HERODURACHANGE = 5185;

        // 英雄物品持久改变
        public const int SM_HERODROPITEM_SUCCESS = 5186;

        // 英雄扔物品OK
        public const int SM_HERODROPITEM_FAIL = 5187;

        // 英雄扔物品FAIL
        public const int SM_HEROLEVELUP = 5188;

        // 英雄升级
        public const int SM_HEROWINEXP = 5189;

        // 英雄获取经验
        public const int SM_HEROWEIGHTCHANGED = 5190;

        public const int SM_HEROMAGIC_LVEXP = 5191;

        // 英雄魔法经验
        public const int SM_HEROCHANGEFACE = 5192;

        public const int SM_HEROUPDATEITEM = 5193;
        public const int SM_HERODELITEMS = 5194;
        public const int SM_HEROCHANGEITEM = 5195;
        public const int CM_REPAIRFIRDRAGON = 5196;

        // 修理火龙之心
        public const int SM_REPAIRFIRDRAGON_OK = 5197;

        // 修理火龙之心 成功
        public const int SM_REPAIRFIRDRAGON_FAIL = 5198;

        // 修理火龙之心  失败
        public const int SM_TAKEONITEM = 5199;

        public const int SM_TAKEOFFITEM = 5200;
        public const int SM_HEROTAKEONITEM = 5201;
        public const int SM_HEROTAKEOFFITEM = 5202;
        public const int CM_HEROLOGON_OK = 5203;
        public const int CM_HEROPROTECT = 5204;

        // 英雄守护
        public const int CM_DOMAINNAME = 5205;

        // 注册域名信息
        public const int SM_CENTERMESSAGE = 5206;

        public const int SM_PLAYSOUND = 5207;
        public const int SM_VIBRATION = 5208;
        public const int SM_OPENBIGDIALOGBOX = 5209;
        public const int SM_CLOSEBIGDIALOGBOX = 5210;
        public const int CM_STARTSERIESPELL = 5211;

        // 开始连击
        public const int CM_STOPSERIESPELL = 5212;

        // 开始连击
        public const int SM_STARTSERIESPELL_OK = 5213;

        // 开始连击
        public const int SM_STARTSERIESPELL_FAIL = 5214;

        // 开始连击
        public const int SM_BLASTHHIT = 5215;

        // 爆击
        public const int CM_QUERYHEROBAGITEMS = 5216;

        // 查询英雄包裹
        public const int SM_SENDCARTINFO = 5217;

        public const int SM_DELCARTINFO = 5218;
        public const int RM_HEROANGERVALUE = 30018;
        public const int RM_MAKEGHOST = 30019;
        public const int RM_CHANGETURN = 30020;
        public const int RM_USERCASTLE = 30021;
        public const int RM_SPELL3 = 30022;
        public const int RM_HEROLOGOUT = 30023;

        // 获取英雄 TMessageBodyWL 产生英雄退出效果
        public const int RM_HEROLOGON = 30024;

        // 获取英雄 TMessageBodyWL 产生英雄登陆效果
        public const int RM_HEROLOGON_OK = 30025;

        public const int RM_REFHEROLOGON = 30026;
        public const int RM_TAKEONITEM = 30027;
        public const int RM_TAKEOFFITEM = 30028;
        public const int RM_HEROTAKEONITEM = 30029;
        public const int RM_HEROTAKEOFFITEM = 30030;
        public const int RM_HEROGROUP = 30031;
        public const int RM_UNHEROGROUP = 30032;
        public const int RM_PLAYSOUND = 30033;
        public const int RM_VIBRATION = 30034;
        public const int RM_OPENBIGDIALOGBOX = 30035;
        public const int RM_CLOSEBIGDIALOGBOX = 30036;
        public const int RM_BLASTHHIT = 30037;

        // 爆击
        public const int RM_SENDCARTINFO = 30038;

        public const int RM_DELCARTINFO = 30039;
        public const int RM_HEAR2 = 30040;

        // //////////////////////////////////////////////////////////////////////////////
        public const int UNITX = 48;

        public const int UNITY = 32;
        public const int HALFX = 24;
        public const int HALFY = 16;

        // MAXBAGITEM = 46; //用户背包最大数量
        public const int MAXMAGIC = 30;

        // 原来54;
        public const int MAXSTORAGEITEM = 50;

        public const int LOGICALMAPUNIT = 40;

        // //////////////////////////////////////////////////////////////////////////////
        public const int LM_GETBLOCKIPLIST = 1000;

        public const int LM_ADDBLOCKIPLIST = 1001;
        public const int SM_BLOCKIPLIST = 1000;

        public static byte WEAPONfeature(int cfeature)
        {
            byte result;

            //@ Unsupported function or procedure: 'HiByte'
            result = GameFramework.HUtil32.HiByte((ushort)cfeature);
            return result;
        }
    } // end Grobal2
}