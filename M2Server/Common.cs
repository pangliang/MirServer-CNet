using System.Collections.Generic;

namespace M2Server
{  
    public class Common
    {
        public static List<string> g_GameMonModule = null;
        public static List<string> g_GameMonProcess = null;
        public static List<string> g_GameMonTitle = null;
        public static bool m_boClientSocketConnect = false;
        public static bool m_BoSearchFinish = false;
        public static byte code = 1;
        public static bool g_boGatePassWord = false;// 服务器模块之间(与启动器之间的消息)
        public const int SG_CHECKCODEADDR = 1006;
        public const int GS_QUIT = 2000;// 关闭
        public const int SG_FORMHANDLE = 1000;// 服务器HANLD
        public const int SG_STARTNOW = 1001;// 正在启动服务器...
        public const int SG_STARTOK = 1002;// 服务器启动完成...
        public const int SS_LOGINCOST = 103;
        public const int SS_OPENSESSION = 1000;
        public const int SS_CLOSESESSION = 1010;
        public const int SS_SOFTOUTSESSION = 1020;
        public const int SS_SERVERINFO = 1030;
        public const int SS_KEEPALIVE = 1040;
        public const int SS_KICKUSER = 1110;
        public const int SS_SERVERLOAD = 1130;
        public const int SM_CERTIFICATION_SUCCESS = 502;
        public const int GS_USERACCOUNT = 2001;
        public const int GS_CHANGEACCOUNTINFO = 2002;
        public const int SG_USERACCOUNT = 1003;
        public const int SG_USERACCOUNTNOTFOUND = 1004;// 没有找到账号
        public const int SG_USERACCOUNTCHANGESTATUS = 1005;// 账号更新成功
        public const int WM_SENDPROCMSG = 11111;
        public const int CM_GETGAMELIST = 2000;
        public const int SM_SENDGAMELIST = 5000;
        public const int UNKNOWMSG = 1007;
        // DBServer消息
        public const int DB_LOADHUMANRCD = 1000;// 读取人物数据消息
        public const int DB_LOADHERORCD = 1001;
        // 读取英雄数据消息
        public const int DB_QUERYHERORCD = 1002;
        // 查询英雄数据
        public const int DB_NEWHERORCD = 1003;
        // 新建英雄
        public const int DB_DELHERORCD = 1004;
        // 删除英雄
        public const int DB_ASSESSDOUBLEHERORCD = 1005;
        // 鉴定双英雄（完毕）
        public const int DB_DELDOUBLEHERORCD = 1006;
        // 删除双英雄数据
        public const int DB_SAVEDOUBLEHERORCD = 1007;
        // 保存双英雄数据
        public const int DB_LOADDOUBLEHERORCD = 1008;
        // 读取双英雄数据
        public const int DB_SAVEHUMANRCD = 1010;
        // 保存人物消息
        public const int DB_SAVEHERORCD = 1011;
        // 保存英雄消息
        public const int DB_SAVEHUMANRCDEX = 1020;
        // DBServer接收
        public const int DBR_LOADHUMANRCD = 1100;
        // DBServer反回读取数据消息
        public const int DBR_SAVEHUMANRCD = 1101;
        // DBServer反回保存数据消息
        public const int DBR_FAIL = 1102;
        // DBServer反回数据读取或保存失败消息
        public const int DBR_LOADHERORCD = 1107;
        // DBServer反回读取英雄数据消息
        public const int DBR_SAVEHERORCD = 1108;
        // DBServer反回保存英雄数据消息
        public const int DBR_LOADDOUBLEHERORCD = 1109;
        // DBServer反回读取双英雄数据消息
        public const int DBR_SAVEDOUBLEHERORCD = 1110;
        // DBServer反回保存双英雄数据消息
        // RunGate.exe与M2的通讯消息
        public const int GM_OPEN = 1;
        public const int GM_CLOSE = 2;
        public const int GM_CHECKSERVER = 3;
        public const int GM_CHECKCLIENT = 4;
        public const int GM_DATA = 5;
        public const int GM_SERVERUSERINDEX = 6;
        public const int GM_RECEIVE_OK = 7;
        public const int GM_TEST = 20;
        public const int GM_KickConn = 21;// 踢Rungate.exe对应的连接
        // /////////////////////////授权相关/////////////////////////////////////////////
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
    }
}
