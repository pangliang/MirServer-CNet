namespace LoginSrv
{
    public class Common
    {
        public const int CHECKCRACK = 1;

        // 检测破解
        public const int g_nUpDateVersion = 20110123;

        // 712
        // 服务器模块之间
        public const int SG_CHECKCODEADDR = 1006;

        public const int GS_QUIT = 2000;

        // 关闭
        public const int SG_FORMHANDLE = 1000;

        // 服务器HANLD
        public const int SG_STARTNOW = 1001;

        // 正在启动服务器...
        public const int SG_STARTOK = 1002;

        // 服务器启动完成...
        public const int SS_LOGINCOST = 103;

        public const int SS_OPENSESSION = 1000;
        public const int SS_CLOSESESSION = 1010;
        public const int SS_SOFTOUTSESSION = 1020;
        public const int SS_SERVERINFO = 1030;
        public const int SS_KEEPALIVE = 1040;
        public const int SS_KICKUSER = 1110;
        public const int SS_SERVERLOAD = 1130;
        public const int SS_ADDIPTOGATE = 1131;
        public const int SM_CERTIFICATION_SUCCESS = 502;
        public const int GS_USERACCOUNT = 2001;
        public const int GS_CHANGEACCOUNTINFO = 2002;
        public const int SG_USERACCOUNT = 1003;
        public const int SG_USERACCOUNTNOTFOUND = 1004;

        // 没有找到账号
        public const int SG_USERACCOUNTCHANGESTATUS = 1005;

        // 账号更新成功
        public const int GS_GETM2SERVERVERSION = 2100;

        public const int SG_GETM2SERVERVERSION = 2200;
        public const int WM_SENDPROCMSG = 11111;
        public const int CM_GETGAMELIST = 2000;
        public const int SM_SENDGAMELIST = 5000;
        public const int UNKNOWMSG = 1007;

        // ----------------------------------------------
        public const int DB_LOADHUMANRCD = 1000;

        public const int DB_SAVEHUMANRCD = 1001;
        public const int DBR_LOADHUMANRCD = 1100;
        public const int DBR_SAVEHUMANRCD = 1101;

        // DB_SAVEHUMANRCDEX = 1020;
        // -----------------------------------------------
        public const int DB_LOADHERORCD = 1002;

        public const int DB_SAVEHERORCD = 1003;
        public const int DB_NEWHERORCD = 1004;

        // 新建英雄
        public const int DB_DELHERORCD = 1005;

        // 删除英雄
        public const int DBR_LOADHERORCD = 1102;

        public const int DBR_SAVEHERORCD = 1103;
        public const int DBR_NEWHERORCD = 1104;

        // 新建英雄
        public const int DBR_DELHERORCD = 1105;

        // 删除英雄
        public const int DBR_NOTCREATEHERO = 1106;

        public const int DB_LOADRANKING = 1007;

        // 读取排行榜
        public const int DBR_LOADRANKING = 1107;

        // 读取排行榜
        public const int DB_SAVEMAGICLIST = 1108;

        // 读取魔法列表
        public const int DBR_SAVEMAGICLIST = 1109;

        // 读取魔法列表
        public const int DB_SAVESTDITEMLIST = 1110;

        // 读取物品列表
        public const int DBR_SAVESTDITEMLIST = 1111;

        // 读取物品列表
        public const int DB_SENDKEEPALIVE = 1112;

        public const int DBR_SENDKEEPALIVE = 1113;
        public const int DB_CLOSESOCKET = 5555;
        public const int DBR_CLOSESOCKET = DB_CLOSESOCKET;
        public const int DBR_FAIL = 8888;

        // For Game Gate
        public const int GM_OPEN = 1;

        public const int GM_CLOSE = 2;
        public const int GM_CHECKSERVER = 3;

        // Send check signal to Server
        public const int GM_CHECKCLIENT = 4;

        // Send check signal to Client
        public const int GM_DATA = 5;

        public const int GM_SERVERUSERINDEX = 6;
        public const int GM_RECEIVE_OK = 7;
        public const int GM_CLOSEOUTCONNECT = 8;
        public const int GM_TEST = 20;

        // //////////////////////////////////////////////////////////////////////////////
        public const int SP_GM_LOGIN = 102;

        public const int SP_GM_GETUSER = 103;
        public const int SP_SM_GETUSER_SUCCESS = 104;
        public const int SP_SM_GETUSER_FAIL = 105;
        public const int SP_GM_ADDUSER = 106;
        public const int SP_SM_ADDUSER_SUCCESS = 107;
        public const int SP_SM_ADDUSER_FAIL = 108;
        public const int SP_GM_DELUSER = 109;
        public const int SP_SM_DELUSER_SUCCESS = 110;
        public const int SP_SM_DELUSER_FAIL = 111;
        public const int SP_GM_CHGUSER = 112;
        public const int SP_SM_CHGUSER_SUCCESS = 113;
        public const int SP_SM_CHGUSER_FAIL = 114;
        public const int SP_GM_SEARCHUSER = 115;
        public const int SP_SM_SEARCHUSER_SUCCESS = 116;
        public const int SP_SM_SEARCHUSER_FAIL = 117;
        public const int GM_LOGIN = 118;
        public const int SM_LOGIN_SUCCESS = 119;
        public const int SM_LOGIN_FAIL = 120;
        public const int GM_GETUSER = 121;
        public const int SM_GETUSER_SUCCESS = 122;
        public const int SM_GETUSER_FAIL = 123;
        public const int GM_ADDUSER = 124;
        public const int SM_ADDUSER_SUCCESS = 125;
        public const int SM_ADDUSER_FAIL = 126;
        public const int GM_DELUSER = 127;
        public const int SM_DELUSER_SUCCESS = 128;
        public const int SM_DELUSER_FAIL = 129;
        public const int GM_CHGUSER = 130;
        public const int SM_CHGUSER_SUCCESS = 131;
        public const int SM_CHGUSER_FAIL = 132;
        public const int GM_SEARCHUSER = 133;
        public const int SM_SEARCHUSER_SUCCESS = 134;
        public const int SM_SEARCHUSER_FAIL = 135;
        public const int SOFTWARE_M2SERVER_MAKEKEY = 0;
        public const int SOFTWARE_SCRIPT_MAKEKEY = 1;
        public const int SOFTWARE_M2SERVER = 2;
        public const int SOFTWARE_SCRIPT = 3;
        public const int DBSUSETHREAD = 0;
    }
}