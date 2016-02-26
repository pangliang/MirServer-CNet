namespace M2Server.ScriptSystem
{
    /// <summary>
    /// 脚本命令定义
    /// </summary>
    public class ScriptDef
    {
        public const string sCHECKOPEN = "CHECKOPEN";
        public const int nCHECKOPEN = 5;
        public const string sCHECKUNIT = "CHECKUNIT";
        public const int nCHECKUNIT = 6;// 脚本命令
        public const string sSET = "SET";
        public const int nSET = 1;
        public const string sTAKE = "TAKE";
        public const int nTAKE = 2;
        public const string sSC_GIVE = "GIVE";// 给物品
        public const int nSC_GIVE = 3;
        public const string sTAKEW = "TAKEW";
        public const int nTAKEW = 4;
        public const string sCLOSE = "CLOSE";
        public const int nCLOSE = 5;
        public const string sRESET = "RESET"; 
        public const int nRESET = 6;
        public const string sSETOPEN = "SETOPEN";// 未使用的命令
        public const int nSETOPEN = 7;
        public const string sSETUNIT = "SETUNIT";// 未使用的命令 
        public const int nSETUNIT = 8;
        public const string sRESETUNIT = "RESETUNIT";// 未使用的命令
        public const int nRESETUNIT = 9;
        public const string sBREAK = "BREAK";
        public const int nBREAK = 10;
        public const string sTIMERECALL = "TIMERECALL";
        public const int nTIMERECALL = 11;
        public const string sSC_PARAM1 = "PARAM1";
        public const int nSC_PARAM1 = 12;
        public const string sSC_PARAM2 = "PARAM2";
        public const int nSC_PARAM2 = 13;
        public const string sSC_PARAM3 = "PARAM3";
        public const int nSC_PARAM3 = 14;
        public const string sSC_PARAM4 = "PARAM4";
        public const int nSC_PARAM4 = 15;
        public const string sSC_EXEACTION = "EXEACTION";
        public const int nSC_EXEACTION = 16;
        public const string sCHECKNAMELIST = "CHECKNAMELIST";
        public const int nCHECKNAMELIST = 17;
        public const string sSC_ISGUILDMASTER = "ISGUILDMASTER";
        public const int nSC_ISGUILDMASTER = 18;
        public const string sMAPMOVE = "MAPMOVE";
        public const int nMAPMOVE = 19;
        public const string sMAP = "MAP";
        public const int nMAP = 20;
        public const string sTAKECHECKITEM = "TAKECHECKITEM";
        public const int nTAKECHECKITEM = 21;
        public const string sMONGEN = "MONGEN";
        public const int nMONGEN = 22;
        public const string sISTAKEITEM = "ISTAKEITEM";
        public const int nISTAKEITEM = 23;
        public const string sMONCLEAR = "MONCLEAR";
        public const int nMONCLEAR = 24;
        public const string sMOV = "MOV";
        public const int nMOV = 25;
        public const string sINC = "INC";
        public const int nINC = 26;
        public const string sDEC = "DEC";
        public const int nDEC = 27;
        public const string sSUM = "SUM";
        public const int nSUM = 28;
        public const string sBREAKTIMERECALL = "BREAKTIMERECALL";
        public const int nBREAKTIMERECALL = 29;
        public const string sSENDMSG = "SENDMSG";// 发送文字信息
        public const int nSENDMSG = 30;
        public const string sPKPOINT = "PKPOINT";
        public const int nPKPOINT = 32;
        public const string sCHECKHUM = "CHECKHUM";
        public const int nCHECKHUM = 33;
        public const string sSC_RECALLMOB = "RECALLMOB";
        public const int nSC_RECALLMOB = 34;
        public const string sKICK = "KICK";
        public const int nKICK = 35;
        public const string sLARGE = "LARGE";
        public const int nLARGE = 36;
        public const string sSMALL = "SMALL";
        public const int nSMALL = 37;
        public const string sCHECKPKPOINT = "CHECKPKPOINT";
        public const int nCHECKPKPOINT = 38;
        public const string sCHECKLUCKYPOINT = "CHECKLUCKYPOINT";
        public const int nCHECKLUCKYPOINT = 39;
        public const string sCHECKMONMAP = "CHECKMONMAP";
        public const int nCHECKMONMAP = 40;
        public const string sCHECKBAGGAGE = "CHECKBAGGAGE";
        public const int nCHECKBAGGAGE = 41;
        public const string sEQUAL = "EQUAL";
        public const int nEQUAL = 42;
        public const string sCHECKDURA = "CHECKDURA";
        public const int nCHECKDURA = 43;
        public const string sCHECKDURAEVA = "CHECKDURAEVA";
        public const int nCHECKDURAEVA = 44;
        public const string sDAYOFWEEK = "DAYOFWEEK";
        public const int nDAYOFWEEK = 45;
        public const string sHOUR = "HOUR";
        public const int nHOUR = 46;
        public const string sMIN = "MIN";
        public const int nMIN = 47;
        public const string sCHECK = "CHECK";
        public const int nCHECK = 48;
        public const string sRANDOM = "RANDOM";
        public const int nRANDOM = 49;
        public const string sMOVR = "MOVR";
        public const int nMOVR = 50;
        public const string sEXCHANGEMAP = "EXCHANGEMAP";
        public const int nEXCHANGEMAP = 51;
        public const string sRECALLMAP = "RECALLMAP";
        public const int nRECALLMAP = 52;
        public const string sADDBATCH = "ADDBATCH";
        public const int nADDBATCH = 53;
        public const string sBATCHDELAY = "BATCHDELAY";
        public const int nBATCHDELAY = 54;
        public const string sBATCHMOVE = "BATCHMOVE";
        public const int nBATCHMOVE = 55;
        public const string sPLAYDICE = "PLAYDICE";
        public const int nPLAYDICE = 56;
        public const string sADDNAMELIST = "ADDNAMELIST";
        public const int nADDNAMELIST = 57;
        public const string sDELNAMELIST = "DELNAMELIST";
        public const int nDELNAMELIST = 58;
        public const string sADDGUILDLIST = "ADDGUILDLIST";
        public const int nADDGUILDLIST = 59;
        public const string sDELGUILDLIST = "DELGUILDLIST";
        public const int nDELGUILDLIST = 60;
        public const string sADDACCOUNTLIST = "ADDACCOUNTLIST";
        public const int nADDACCOUNTLIST = 61;
        public const string sDELACCOUNTLIST = "DELACCOUNTLIST";
        public const int nDELACCOUNTLIST = 62;
        public const string sADDIPLIST = "ADDIPLIST";
        public const int nADDIPLIST = 63;
        public const string sDELIPLIST = "DELIPLIST";
        public const int nDELIPLIST = 64;
        public const string sSC_ISDEFENSEGUILD = "ISDEFENSEGUILD";// 是否为守城方
        public const int nSC_ISDEFENSEGUILD = 65;
        public const string sSC_ISCASTLEGUILD = "ISCASTLEGUILD";
        public const int nSC_ISCASTLEGUILD = 66;
        public const string sSC_ISATTACKGUILD = "ISATTACKGUILD";// 是否为攻城方
        public const int nSC_ISATTACKGUILD = 67;
        public const string sSC_HASGUILD = "HAVEGUILD";// 是否加入行会
        public const int nSC_HASGUILD = 68;
        public const string sSC_CHECKCASTLEDOOR = "CHECKCASTLEDOOR";// 检查城门
        public const int nSC_CHECKCASTLEDOOR = 69;
        public const string sGENDER = "GENDER";
        public const int nGENDER = 70;
        public const string sDAYTIME = "DAYTIME";
        public const int nDAYTIME = 71;
        public const string sCHECKLEVEL = "CHECKLEVEL";
        public const int nCHECKLEVEL = 72;
        public const string sSC_ISATTACKALLYGUILD = "ISATTACKALLYGUILD";// 是否为攻城方联盟行会
        public const int nSC_ISATTACKALLYGUILD = 73;
        public const string sSC_ISDEFENSEALLYGUILD = "ISDEFENSEALLYGUILD";// 是否为守城方联盟行会
        public const int nSC_ISDEFENSEALLYGUILD = 74;
        public const string sCHECKJOB = "CHECKJOB";
        public const int nCHECKJOB = 75;
        public const string sSC_ISSYSOP = "ISSYSOP";
        public const int nSC_ISSYSOP = 76;
        public const string sSC_ISADMIN = "ISADMIN";
        public const int nSC_ISADMIN = 77;
        public const string sCHECKITEM = "CHECKITEM";
        public const int nCHECKITEM = 78;
        public const string sCHECKITEMW = "CHECKITEMW";
        public const int nCHECKITEMW = 79;
        public const string sCHECKGOLD = "CHECKGOLD";
        public const int nCHECKGOLD = 80;
        public const string sCHECKBBCOUNT = "CHECKBBCOUNT";
        public const int nCHECKBBCOUNT = 81;
        public const string sSC_CHECKSERVER = "CHECKSERVER";
        public const int nSC_CHECKSERVER = 82;
        public const string sSC_CHECKGROUPCOUNT = "CHECKGROUPCOUNT";
        public const int nSC_CHECKGROUPCOUNT = 83;
        public const string sSC_REPAIRITEM = "REPAIRITEM";
        public const int nSC_REPAIRITEM = 84;
        public const string sSC_CLEARMAPITEM = "CLEARMAPITEM";// 清除地图物品 增加对blue脚本的命令支持
        public const string sSC_CLEARITEMMAP = "CLEARITEMMAP";// 清除地图物品
        public const int nSC_CLEARITEMMAP = 85;
        public const string sSC_GROUPMOVE = "GROUPMOVE";
        public const int nSC_GROUPMOVE = 86;
        public const string sSC_CLEARNAMELIST = "CLEARNAMELIST";
        public const int nSC_CLEARNAMELIST = 87;
        public const string sSC_KILLSLAVE = "KILLSLAVE";
        public const int nSC_KILLSLAVE = 88;
        public const string sSC_CHANGEGENDER = "CHANGEGENDER";
        public const int nSC_CHANGEGENDER = 89;
        public const string sCHANGESKILL = "CHANGESKILL";// 修改魔法ID
        public const int nCHANGESKILL = 90;
        public const string sCHALLENGMAPMOVE = "CHALLENGMAPMOVE";// 挑战地图移动 20080705
        public const int nCHALLENGMAPMOVE = 91;
        public const string sGETCHALLENGEBAKITEM = "GETCHALLENGEBAKITEM";// 没有挑战地图可移动,则退回抵押的物品 
        public const int nGETCHALLENGEBAKITEM = 92;
        public const string sHEROLOGOUT = "HEROLOGOUT";// 人物在线英雄下线 
        public const int nHEROLOGOUT = 93;
        public const string sSC_ADDGUILDMEMBER = "ADDGUILDMEMBER";// 添加行会成员
        public const int nSC_ADDGUILDMEMBER = 94;
        public const string sSC_DELGUILDMEMBER = "DELGUILDMEMBER";// 删除行会成员（删除掌门无效）
        public const int nSC_DELGUILDMEMBER = 95;
        public const string sSC_CHECKLISTTEXT = "CHECKLISTTEXT";// 检查文件是否包含指定文本 
        public const int nSC_CHECKLISTTEXT = 96;
        public const string sQUERYREFINEITEM = "QUERYREFINEITEM";// 打开淬炼窗口
        public const int nQUERYREFINEITEM = 97;
        public const string sGOHOME = "GOHOME";// 移动到回城点 
        public const int nGOHOME = 98;
        public const string sTHROWITEM = "THROWITEM";// 将指定物品刷新到指定地图坐标范围内
        public const int nTHROWITEM = 99;
        public const string sGOQUEST = "GOQUEST";
        public const int nGOQUEST = 100;
        public const string sENDQUEST = "ENDQUEST";
        public const int nENDQUEST = 101;
        public const string sGOTO = "GOTO";
        public const int nGOTO = 102;
        public const string sSetOnTimer = "SETONTIMER";// 个人定时器
        public const string sSetScTimer = "SETSCTIMER";// 对blue的定时器的识别
        public const int nSetOnTimer = 103;
        public const string sSETOFFTIMER = "SETOFFTIMER";// 停止定时器
        public const string sKILLSCTIMER = "KILLSCTIMER";// 对blue的定时器的识别
        public const int nSETOFFTIMER = 104;
        public const string sSC_CHECKGAMEGLORY = "CHECKGAMEGLORY";// 检查荣誉值
        public const int nSC_CHECKGAMEGLORY = 105;
        public const string sSC_HAIRSTYLE = "HAIRSTYLE";
        public const int nSC_HAIRSTYLE = 106;
        // -----------------------酒馆系统-----------------------------------------
        public const string sSC_SAVEHERO = "SAVEHERO";// 寄放英雄
        public const int nSC_SAVEHERO = 107;
        public const string sSC_GETHERO = "GETHERO";// 取回英雄
        public const int nSC_GETHERO = 108;
        public const string sSC_CLOSEDRINK = "CLOSEDRINK";// 关闭斗酒窗口
        public const int nSC_CLOSEDRINK = 109;
        public const string sSC_PLAYDRINKMSG = "PLAYDRINKMSG";// 斗酒窗口说话信息
        public const int nSC_PLAYDRINKMSG = 110;
        public const string sSC_OPENPLAYDRINK = "OPENPLAYDRINK";// 指定人物喝酒
        public const int nSC_OPENPLAYDRINK = 111;
        // -------------------------------------------------------------------------
        public const string sGETSORTNAME = "GETSORTNAME";// 取指定排行榜指定排名的玩家名字
        public const int nGETSORTNAME = 112;
        public const string sWEBBROWSER = "WEBBROWSER";// 连接指定网站网址
        public const int nWEBBROWSER = 113;
        public const string sSC_CHANGEHUMABILITY = "CHANGEHUMABILITY";// 调整人物属性
        public const int nSC_CHANGEHUMABILITY = 114;
        public const string sADDATTACKSABUKALL = "ADDATTACKSABUKALL";// 设置所有行会攻城
        public const int nADDATTACKSABUKALL = 115;
        public const string sKICKALLPLAY = "KICKALLPLAY";// 踢除服务器所有在线人物  
        public const int nKICKALLPLAY = 116;
        public const string sREPAIRALL = "REPAIRALL";// 修理全身装备 
        public const int nREPAIRALL = 117;
        public const string sAUTOGOTOXY = "AUTOGOTOXY";// 自动寻路 
        public const int nAUTOGOTOXY = 118;
        // ----------------------------酿酒系统------------------------------------------
        public const string sOPENMAKEWINE = "OPENMAKEWINE";
        // 打开酿酒窗口 20080619
        public const int nOPENMAKEWINE = 119;
        public const string sGETGOODMAKEWINE = "GETGOODMAKEWINE";
        // 取回酿好的酒 20080620
        public const int nGETGOODMAKEWINE = 120;
        public const string sDECMAKEWINETIME = "DECMAKEWINETIME";
        // 减少酿酒的时间 20080620
        public const int nDECMAKEWINETIME = 121;
        public const string sISONMAKEWINE = "ISONMAKEWINE";
        // 判断是否在酿哪种酒 20080620
        public const int nISONMAKEWINE = 122;
        public const string sMAKEWINENPCMOVE = "MAKEWINENPCMOVE";
        // 酿酒NPC的走动 20080621
        public const int nMAKEWINENPCMOVE = 123;
        public const string sFOUNTAIN = "FOUNTAIN";
        // 设置泉水喷发 20080624
        public const int nFOUNTAIN = 124;
        public const string sCHECKGUILDFOUNTAIN = "CHECKGUILDFOUNTAIN";
        // 判断是否开启行会泉水仓库 20080625
        public const int nCHECKGUILDFOUNTAIN = 125;
        public const string sSETGUILDFOUNTAIN = "SETGUILDFOUNTAIN";
        // 开启/关闭行会泉水仓库 20080625
        public const int nSETGUILDFOUNTAIN = 126;
        public const string sGIVEGUILDFOUNTAIN = "GIVEGUILDFOUNTAIN";
        // 领取行会酒水 20080625
        public const int nGIVEGUILDFOUNTAIN = 127;
        // ------------------------------------------------------------------------------
        public const string sHCall = "HCALL";
        // 通过脚本命令让别人执行QManage.txt中的脚本 20080422
        public const int nHCall = 128;
        public const string sSC_CHECKCASTLEWAR = "CHECKCASTLEWAR";
        // 检查是否在攻城期间 20080422
        public const int nSC_CHECKCASTLEWAR = 129;
        public const string sINCASTLEWARAY = "INCASTLEWARAY";
        // 检测人物是否在攻城期间的范围内，在则BB叛变 20080422
        public const int nINCASTLEWARAY = 130;
        public const string sHEROCHECKSKILL = "HEROCHECKSKILL";
        // 检查英雄技能 20080423
        public const int nHEROCHECKSKILL = 131;
        public const string sSC_CHECKSIDESLAVENAME = "CHECKSIDESLAVENAME";
        // 检查人物周围自己宝宝数量 20080425
        public const int nSC_CHECKSIDESLAVENAME = 132;
        public const string sSC_ISONMAP = "ISONMAP";
        // 检测地图命令  20080426
        public const int nSC_ISONMAP = 133;
        public const string sSC_CHANGEHEROTRANPOINT = "CHANGEHEROTRANPOINT";
        // 调整英雄技能升级点数 20080512
        public const int nSC_CHANGEHEROTRANPOINT = 134;
        public const string sCHECKACCOUNTLIST = "CHECKACCOUNTLIST";
        public const int nCHECKACCOUNTLIST = 135;
        public const string sCHECKIPLIST = "CHECKIPLIST";
        public const int nCHECKIPLIST = 136;
        public const string sSC_CHECKSKILLLEVEL = "CHECKSKILLLEVEL";
        // 检查技能等级 20080512
        public const int nSC_CHECKSKILLLEVEL = 137;
        public const string sSC_CHECKPOSEDIR = "CHECKPOSEDIR";
        public const int nSC_CHECKPOSEDIR = 138;
        public const string sSC_CHECKPOSELEVEL = "CHECKPOSELEVEL";
        public const int nSC_CHECKPOSELEVEL = 139;
        public const string sSC_CHECKPOSEGENDER = "CHECKPOSEGENDER";
        public const int nSC_CHECKPOSEGENDER = 140;
        public const string sSC_CHECKLEVELEX = "CHECKLEVELEX";
        public const int nSC_CHECKLEVELEX = 141;
        public const string sSC_CHECKBONUSPOINT = "CHECKBONUSPOINT";
        public const int nSC_CHECKBONUSPOINT = 142;
        public const string sSC_CHECKMARRY = "CHECKMARRY";
        public const int nSC_CHECKMARRY = 143;
        public const string sSC_CHECKPOSEMARRY = "CHECKPOSEMARRY";
        public const int nSC_CHECKPOSEMARRY = 144;
        public const string sSC_CHECKMARRYCOUNT = "CHECKMARRYCOUNT";
        public const int nSC_CHECKMARRYCOUNT = 145;
        public const string sSC_CHECKMASTER = "CHECKMASTER";
        public const int nSC_CHECKMASTER = 146;
        public const string sSC_HAVEMASTER = "HAVEMASTER";
        public const int nSC_HAVEMASTER = 147;
        public const string sSC_CHECKPOSEMASTER = "CHECKPOSEMASTER";
        public const int nSC_CHECKPOSEMASTER = 148;
        public const string sSC_POSEHAVEMASTER = "POSEHAVEMASTER";
        public const int nSC_POSEHAVEMASTER = 149;
        public const string sSC_CHECKISMASTER = "CHECKPOSEISMASTER";
        public const int nSC_CHECKISMASTER = 150;
        public const string sSC_CHECKPOSEISMASTER = "CHECKISMASTER";
        public const int nSC_CHECKPOSEISMASTER = 151;
        public const string sSC_CHECKNAMEIPLIST = "CHECKNAMEIPLIST";
        public const int nSC_CHECKNAMEIPLIST = 152;
        public const string sSC_CHECKACCOUNTIPLIST = "CHECKACCOUNTIPLIST";
        public const int nSC_CHECKACCOUNTIPLIST = 153;
        public const string sSC_CHECKSLAVECOUNT = "CHECKSLAVECOUNT";
        public const int nSC_CHECKSLAVECOUNT = 154;
        public const string sSC_CHECKCASTLEMASTER = "ISCASTLEMASTER";
        public const int nSC_CHECKCASTLEMASTER = 155;
        public const string sSC_ISNEWHUMAN = "ISNEWHUMAN";
        public const int nSC_ISNEWHUMAN = 156;
        public const string sSC_CHECKMEMBERTYPE = "CHECKMEMBERTYPE";
        public const int nSC_CHECKMEMBERTYPE = 157;
        public const string sSC_CHECKMEMBERLEVEL = "CHECKMEMBERLEVEL";
        public const int nSC_CHECKMEMBERLEVEL = 158;
        public const string sSC_CHECKGAMEGOLD = "CHECKGAMEGOLD";
        public const int nSC_CHECKGAMEGOLD = 159;
        public const string sSC_CHECKGAMEPOINT = "CHECKGAMEPOINT";
        public const int nSC_CHECKGAMEPOINT = 160;
        public const string sSC_CHECKNAMELISTPOSITION = "CHECKNAMELISTPOSITION";// 检查人物在列表中的位置
        public const int nSC_CHECKNAMELISTPOSITION = 161;
        public const string sSC_CHECKGUILDLIST = "CHECKGUILDLIST";
        public const int nSC_CHECKGUILDLIST = 162;
        public const string sSC_CHECKRENEWLEVEL = "CHECKRENEWLEVEL";
        public const int nSC_CHECKRENEWLEVEL = 163;
        public const string sSC_CHECKSLAVELEVEL = "CHECKSLAVELEVEL";
        public const int nSC_CHECKSLAVELEVEL = 164;
        public const string sSC_CHECKSLAVENAME = "CHECKSLAVENAME";
        public const int nSC_CHECKSLAVENAME = 165;
        public const string sSC_CHECKCREDITPOINT = "CHECKCREDITPOINT";
        public const int nSC_CHECKCREDITPOINT = 166;
        public const string sSC_CHECKOFGUILD = "CHECKOFGUILD";
        public const int nSC_CHECKOFGUILD = 167;
        public const string sSC_CHECKPAYMENT = "CHECKPAYMENT";
        public const int nSC_CHECKPAYMENT = 168;
        public const string sSC_CHECKUSEITEM = "CHECKUSEITEM";
        public const int nSC_CHECKUSEITEM = 169;
        public const string sSC_CHECKBAGSIZE = "CHECKBAGSIZE";
        public const int nSC_CHECKBAGSIZE = 170;
        public const string sSC_CHECKDC = "CHECKDC";
        public const int nSC_CHECKDC = 172;
        public const string sSC_CHECKMC = "CHECKMC";
        public const int nSC_CHECKMC = 173;
        public const string sSC_CHECKSC = "CHECKSC";
        public const int nSC_CHECKSC = 174;
        public const string sSC_CHECKHP = "CHECKHP";
        public const int nSC_CHECKHP = 175;
        public const string sSC_CHECKMP = "CHECKMP";
        public const int nSC_CHECKMP = 176;
        public const string sSC_CHECKCODELIST = "CHECKCODELIST";// 检测文本里的编码是否存在 
        public const int nSC_CHECKCODELIST = 177;
        public const string sCLEARCODELIST = "CLEARCODELIST";// 删除指定文本里的编码
        public const int nCLEARCODELIST = 178;
        public const string sSC_HEROSKILLLEVEL = "HEROSKILLLEVEL";// 调整英雄技能等级
        public const int nSC_HEROSKILLLEVEL = 179;
        public const string sSC_CHECKITEMTYPE = "CHECKITEMTYPE";
        public const int nSC_CHECKITEMTYPE = 180;
        public const string sSC_CHECKEXP = "CHECKEXP";
        public const int nSC_CHECKEXP = 181;
        public const string sSC_CHECKCASTLEGOLD = "CHECKCASTLEGOLD";
        public const int nSC_CHECKCASTLEGOLD = 182;
        public const string sSC_PASSWORDERRORCOUNT = "PASSWORDERRORCOUNT";
        public const int nSC_PASSWORDERRORCOUNT = 183;
        public const string sSC_ISLOCKPASSWORD = "ISLOCKPASSWORD";
        public const int nSC_ISLOCKPASSWORD = 184;
        public const string sSC_ISLOCKSTORAGE = "ISLOCKSTORAGE";
        public const int nSC_ISLOCKSTORAGE = 185;
        public const string sSC_CHECKBUILDPOINT = "CHECKGUILDBUILDPOINT";
        public const int nSC_CHECKBUILDPOINT = 186;
        public const string sSC_CHECKAURAEPOINT = "CHECKGUILDAURAEPOINT";
        public const int nSC_CHECKAURAEPOINT = 187;
        public const string sSC_CHECKSTABILITYPOINT = "CHECKGUILDSTABILITYPOINT";
        public const int nSC_CHECKSTABILITYPOINT = 188;
        public const string sSC_CHECKFLOURISHPOINT = "CHECKGUILDFLOURISHPOINT";
        public const int nSC_CHECKFLOURISHPOINT = 189;
        public const string sSC_CHECKCONTRIBUTION = "CHECKCONTRIBUTION";// 贡献度
        public const int nSC_CHECKCONTRIBUTION = 190;
        public const string sSC_CHECKRANGEMONCOUNT = "CHECKRANGEMONCOUNT";// 检查一个区域中有多少怪
        public const int nSC_CHECKRANGEMONCOUNT = 191;
        public const string sSC_CHECKITEMADDVALUE = "CHECKITEMADDVALUE";
        public const int nSC_CHECKITEMADDVALUE = 192;
        public const string sSC_CHECKINMAPRANGE = "CHECKINMAPRANGE";
        public const int nSC_CHECKINMAPRANGE = 193;
        public const string sSC_CASTLECHANGEDAY = "CASTLECHANGEDAY";
        public const int nSC_CASTLECHANGEDAY = 194;
        public const string sSC_CASTLEWARDAY = "CASTLEWARAY";
        public const int nSC_CASTLEWARDAY = 195;
        public const string sSC_ONLINELONGMIN = "ONLINELONGMIN";
        public const int nSC_ONLINELONGMIN = 196;
        public const string sSC_CHECKGUILDCHIEFITEMCOUNT = "CHECKGUILDCHIEFITEMCOUNT";
        public const int nSC_CHECKGUILDCHIEFITEMCOUNT = 197;
        public const string sSC_CHECKNAMEDATELIST = "CHECKNAMEDATELIST";
        public const int nSC_CHECKNAMEDATELIST = 198;
        public const string sSC_CHECKMAPHUMANCOUNT = "CHECKMAPHUMANCOUNT";
        public const int nSC_CHECKMAPHUMANCOUNT = 199;
        public const string sSC_CHECKMAPMONCOUNT = "CHECKMAPMONCOUNT";
        public const int nSC_CHECKMAPMONCOUNT = 200;
        public const string sSC_CHECKVAR = "CHECKVAR";
        public const int nSC_CHECKVAR = 201;
        public const string sSC_CHECKSERVERNAME = "CHECKSERVERNAME";
        public const int nSC_CHECKSERVERNAME = 202;
        public const string sCHECKMAPNAME = "CHECKMAPNAME";
        public const int nCHECKMAPNAME = 203;
        public const string sINSAFEZONE = "INSAFEZONE";
        public const int nINSAFEZONE = 204;
        public const string sCHECKSKILL = "CHECKSKILL";
        public const int nCHECKSKILL = 205;
        public const string sSC_CHECKUSERDATE = "CHECKUSERDATE";
        public const int nSC_CHECKUSERDATE = 206;
        public const string sSC_CHECKCONTAINSTEXT = "CHECKCONTAINSTEXT";
        public const int nSC_CHECKCONTAINSTEXT = 207;
        public const string sSC_COMPARETEXT = "COMPARETEXT";
        public const int nSC_COMPARETEXT = 208;
        public const string sSC_CHECKTEXTLIST = "CHECKTEXTLIST";
        public const int nSC_CHECKTEXTLIST = 209;
        public const string sSC_ISGROUPMASTER = "ISGROUPMASTER";
        public const int nSC_ISGROUPMASTER = 210;
        public const string sSC_CHECKCONTAINSTEXTLIST = "CHECKCONTAINSTEXTLIST";
        public const int nSC_CHECKCONTAINSTEXTLIST = 211;
        public const string sSC_CHECKONLINE = "CHECKONLINE";// 检查玩家是否在线
        public const int nSC_CHECKONLINE = 212;
        public const string sOPENDRAGONBOX = "OPENDRAGONBOX";// 打开卧龙宝藏 20080306
        public const int nOPENDRAGONBOX = 213;
        public const string sSC_ISDUPMODE = "ISDUPMODE";
        public const int nSC_ISDUPMODE = 214;
        public const string sSC_ISOFFLINEMODE = "ISOFFLINEMODE";
        public const int nSC_ISOFFLINEMODE = 215;
        public const string sSC_CHECKSTATIONTIME = "CHECKSTATIONTIME";
        public const int nSC_CHECKSTATIONTIME = 216;
        public const string sSC_CHECKSIGNMAP = "CHECKSIGNMAP";
        public const int nSC_CHECKSIGNMAP = 217;
        public const string sSC_HAVEHERO = "HAVEHERO";
        public const int nSC_HAVEHERO = 218;
        public const string sSC_CHECKHEROONLINE = "CHECKHEROONLINE";
        public const int nSC_CHECKHEROONLINE = 219;
        public const string sSC_CHECKHEROLEVEL = "CHECKHEROLEVEL";
        public const int nSC_CHECKHEROLEVEL = 220;
        public const string sSC_CHECKHEROJOB = "CHECKHEROJOB";
        public const int nSC_CHECKHEROJOB = 221;
        public const string sSC_CHECKMINE = "CHECKMINE";// 检测矿纯度  
        public const int nSC_CHECKMINE = 222;
        public const string sSC_GIVEMINE = "GIVEMINE";// 给矿石  
        public const int nSC_GIVEMINE = 223;
        public const string sSC_CHECKCURRENTDATE = "CHECKCURRENTDATE";// 检测当前日期是否小于大于等于指定的日期 
        public const int nSC_CHECKCURRENTDATE = 224;
        public const string sSC_CHECKMASTERONLINE = "CHECKMASTERONLINE";// 检测师傅(或徒弟)是否在线 
        public const int nSC_CHECKMASTERONLINE = 225;
        public const string sSC_CHECKDEARONLINE = "CHECKDEARONLINE";// 检测夫妻一方是否在线
        public const int nSC_CHECKDEARONLINE = 226;
        public const string sSC_CHECKMASTERONMAP = "CHECKMASTERONMAP";// 检测师傅(或徒弟)是否在XXX地图，支持SELF(是否同一地图) 
        public const int nSC_CHECKMASTERONMAP = 227;
        public const string sSC_CHECKDEARONMAP = "CHECKDEARONMAP";// 检测夫妻一方是否在XXX地图，支持SELF(是否同一地图) 
        public const int nSC_CHECKDEARONMAP = 228;
        public const string sSC_CHECKPOSEISPRENTICE = "CHECKPOSEISPRENTICE";// 检测对面是否为自己的徒弟
        public const int nSC_CHECKPOSEISPRENTICE = 229;
        public const string sSENDTOPMSG = "SENDTOPMSG";// 顶端滚动公告
        public const int nSENDTOPMSG = 230;
        public const string sSENDCENTERMSG = "SENDCENTERMSG";// 屏幕居中显示公告
        public const int nSENDCENTERMSG = 231;
        public const string sSENDEDITTOPMSG = "SENDEDITTOPMSG";// 聊天框顶端公告
        public const int nSENDEDITTOPMSG = 232;
        public const string sSC_CHECKHEROLOYAL = "CHECKHEROLOYAL";// 检测英雄的忠诚度 
        public const int nSC_CHECKHEROLOYAL = 233;
        public const string sSC_CHANGEHEROLOYAL = "CHANGEHEROLOYAL";// 调整英雄的忠诚度 
        public const int nSC_CHANGEHEROLOYAL = 234;
        public const string sOPENBOOK = "OPENBOOK";// 卧龙    blue翻书
        public const string sOPENBOOKS = "OPENBOOKS";// 卧龙 
        public const int nOPENBOOKS = 235;
        public const string sSC_RECALLMOBEX = "RECALLMOBEX";// 召唤宝宝
        public const int nSC_RECALLMOBEX = 236;
        public const string sSC_MOVEMOBTO = "MOVEMOBTO";// 将指定坐标的怪物移动到新坐标
        public const int nSC_MOVEMOBTO = 237;
        public const string sSC_CHECKRANGEMONCOUNTEX = "CHECKRANGEMONCOUNTEX";// 魔王岭
        public const string sSC_CHECKMAPMOBCOUNT = "CHECKMAPMOBCOUNT";// 检查地图指定坐标指定名称怪物数量
        public const int nSC_CHECKMAPMOBCOUNT = 238;
        public const string sSC_FINDMAPPATH = "FINDMAPPATH";// 设置地图的起终XY值
        public const int nSC_FINDMAPPATH = 239;
        public const string sREADRANDOMSTR = "READRANDOMSTR";
        // blue的命令随机取文本
        public const string sGETRANDOMNAME = "GETRANDOMNAME";
        // 从文件中随机取文本 20080126
        public const int nGETRANDOMNAME = 240;
        public const string sSC_DIV = "DIV";
        // 20080220 变量运算 除法
        public const int nSC_DIV = 241;
        public const string sSC_MUL = "MUL";
        // 20080220 变量运算 乘法
        public const int nSC_MUL = 242;
        public const string sSC_PERCENT = "PERCENT";
        // 20080220 变量运算 百分比
        public const int nSC_PERCENT = 243;
        public const string sTHROUGHHUM = "THROUGHHUM";
        // 改变穿人模式 20080221
        public const int nTHROUGHHUM = 245;
        public const string sSETITEMSLIGHT = "SETITEMSLIGHT";
        // 装备发光设置 20080223
        public const int nSETITEMSLIGHT = 246;
        public const string sSC_CHECKHEROPKPOINT = "CHECKHEROPKPOINT";
        // 检测英雄PK值  20080304
        public const int nSC_CHECKHEROPKPOINT = 247;
        public const string sGIVESTATEITEM = "GIVESTATEITEM";
        // 给予带绑定状态装备 20080312
        public const int nGIVESTATEITEM = 248;
        public const string sSETITEMSTATE = "SETITEMSTATE";
        // 设置装备绑定状态 20080312
        public const int nSETITEMSTATE = 249;
        public const string sCHECKITEMSTATE = "CHECKITEMSTATE";
        // 检查装备绑定状态 20080312
        public const int nCHECKITEMSTATE = 250;
        public const string sISHIGH = "ISHIGH";
        // 检测服务器最高属性人物命令 20080313
        public const int nISHIGH = 251;
        // -------------------------------------------------------------------------
        public const string sOPENYBDEAL = "OPENYBDEAL";
        // 开通元宝交易 20080316
        public const int nOPENYBDEAL = 252;
        public const string sQUERYYBSELL = "QUERYYBSELL";
        // 查询正在出售的物品 20080317
        public const int nQUERYYBSELL = 253;
        public const string sQUERYYBDEAL = "QUERYYBDEAL";
        // 查询可以的购买物品 20080317
        public const int nQUERYYBDEAL = 254;
        public const string sSC_GMEXECUTE = "GMEXECUTE";
        public const int nSC_GMEXECUTE = 255;
        public const string sSC_GUILDCHIEFITEMCOUNT = "GUILDCHIEFITEMCOUNT";
        public const int nSC_GUILDCHIEFITEMCOUNT = 256;
        public const string sSC_GAMEDIAMOND = "GAMEDIAMOND";
        // 调整金刚石数量 20071226
        public const int nSC_GAMEDIAMOND = 257;
        public const string sSC_GAMEGIRD = "GAMEGIRD";
        // 调整灵符数量 20071226
        public const int nSC_GAMEGIRD = 258;
        public const string sSC_MOBFIREBURN = "MOBFIREBURN";
        public const int nSC_MOBFIREBURN = 259;
        public const string sSC_MESSAGEBOX = "MESSAGEBOX";
        public const int nSC_MESSAGEBOX = 260;
        public const string sSC_SETSCRIPTFLAG = "SETSCRIPTFLAG";
        // 设置用于NPC输入框操作的控制标志
        public const int nSC_SETSCRIPTFLAG = 261;
        public const string sSC_SETAUTOGETEXP = "SETAUTOGETEXP";
        public const int nSC_SETAUTOGETEXP = 262;
        public const string sSC_CHANGEHEROEXP = "CHANGEHEROEXP";
        public const int nSC_CHANGEHEROEXP = 263;
        public const string sSC_VAR = "VAR";
        public const int nSC_VAR = 264;
        public const string sSC_LOADVAR = "LOADVAR";
        public const int nSC_LOADVAR = 265;
        public const string sSC_SAVEVAR = "SAVEVAR";
        public const int nSC_SAVEVAR = 266;
        public const string sSC_CALCVAR = "CALCVAR";
        // 自定义变量功能
        public const int nSC_CALCVAR = 267;
        public const string sOFFLINEPLAY = "OFFLINEPLAY";
        // 挂机脚本
        public const int nOFFLINEPLAY = 268;
        public const string sKICKOFFLINE = "KICKOFFLINE";
        public const int nKICKOFFLINE = 269;
        public const string sSTARTTAKEGOLD = "STARTTAKEGOLD";
        public const int nSTARTTAKEGOLD = 270;
        public const string sDELAYGOTO = "DELAYGOTO";
        public const string sDELAYCALL = "DELAYCALL";
        public const int nDELAYGOTO = 271;
        public const string sCLEARDELAYGOTO = "CLEARDELAYGOTO";
        public const int nCLEARDELAYGOTO = 272;
        public const string sSC_CHANGEHEROPKPOINT = "CHANGEHEROPKPOINT";
        public const int nSC_CHANGEHEROPKPOINT = 273;
        public const string sSC_ADDUSERDATE = "ADDUSERDATE";
        public const int nSC_ADDUSERDATE = 274;
        public const string sSC_DELUSERDATE = "DELUSERDATE";
        public const int nSC_DELUSERDATE = 275;
        public const string sSC_ANSIREPLACETEXT = "ANSIREPLACETEXT";
        public const int nSC_ANSIREPLACETEXT = 276;
        public const string sSC_ENCODETEXT = "ENCODETEXT";
        public const int nSC_ENCODETEXT = 277;
        public const string sSC_GAMEGLORY = "CHANGEGLORY";
        // 调整荣誉值 20080511
        public const int nSC_GAMEGLORY = 278;
        public const string sSC_ADDTEXTLIST = "ADDTEXTLIST";
        public const int nSC_ADDTEXTLIST = 279;
        public const string sSC_DELTEXTLIST = "DELTEXTLIST";
        public const int nSC_DELTEXTLIST = 280;
        public const string sSC_GROUPMAPMOVE = "GROUPMAPMOVE";
        public const int nSC_GROUPMAPMOVE = 281;
        public const string sSC_RECALLHUMAN = "RECALLHUMAN";
        public const int nSC_RECALLHUMAN = 282;
        public const string sSC_REGOTO = "REGOTO";
        public const int nSC_REGOTO = 283;
        public const string sSC_INTTOSTR = "INTTOSTR";
        public const int nSC_INTTOSTR = 284;
        public const string sSC_STRTOINT = "STRTOINT";
        public const int nSC_STRTOINT = 285;
        public const string sSC_GUILDMOVE = "GUILDMOVE";
        public const int nSC_GUILDMOVE = 286;
        public const string sSC_GUILDMAPMOVE = "GUILDMAPMOVE";
        public const int nSC_GUILDMAPMOVE = 287;
        public const string sSC_RANDOMMOVE = "RANDOMMOVE";
        public const int nSC_RANDOMMOVE = 288;
        public const string sSC_BONUSABIL = "BONUSABIL";
        // 无忧加对blue脚本的支持
        public const string sSC_USEBONUSPOINT = "USEBONUSPOINT";
        // 永久增加人物属性点
        public const int nSC_USEBONUSPOINT = 289;
        public const string sSC_TAKEONITEM = "TAKEONITEM";
        // 穿上物品
        public const int nSC_TAKEONITEM = 290;
        public const string sSC_TAKEOFFITEM = "TAKEOFFITEM";
        public const int nSC_TAKEOFFITEM = 291;
        public const string sSC_CREATEHERO = "CREATEHERO";
        public const int nSC_CREATEHERO = 292;
        public const string sSC_DELETEHERO = "DELETEHERO";
        public const int nSC_DELETEHERO = 293;
        public const string sSC_CHANGEHEROLEVEL = "CHANGEHEROLEVEL";
        public const int nSC_CHANGEHEROLEVEL = 294;
        public const string sSC_CHANGEHEROJOB = "CHANGEHEROJOB";
        public const int nSC_CHANGEHEROJOB = 295;
        public const string sSC_CLEARHEROSKILL = "CLEARHEROSKILL";
        // 清除英雄技能
        public const int nSC_CLEARHEROSKILL = 296;
        public const string sSC_CHECKGAMEDIAMOND = "CHECKGAMEDIAMOND";
        // 检查金刚石数量 20071227
        public const int nSC_CHECKGAMEDIAMOND = 297;
        public const string sSC_CHECKGAMEGIRD = "CHECKGAMEGIRD";
        // 检查灵符数量 20071227
        public const int nSC_CHECKGAMEGIRD = 298;
        public const string sSC_SETRANKLEVELNAME = "SETRANKLEVELNAME";
        public const int nSC_SETRANKLEVELNAME = 299;
        public const string sSC_CHANGELEVEL = "CHANGELEVEL";
        public const int nSC_CHANGELEVEL = 300;
        public const string sSC_MARRY = "MARRY";
        public const int nSC_MARRY = 301;
        public const string sSC_UNMARRY = "UNMARRY";
        public const int nSC_UNMARRY = 302;
        public const string sSC_GETMARRY = "GETMARRY";
        public const int nSC_GETMARRY = 303;
        public const string sSC_GETMASTER = "GETMASTER";
        public const int nSC_GETMASTER = 304;
        public const string sSC_CLEARSKILL = "CLEARSKILL";
        public const int nSC_CLEARSKILL = 305;
        public const string sSC_DELNOJOBSKILL = "DELNOJOBSKILL";
        public const int nSC_DELNOJOBSKILL = 306;
        public const string sSC_DELSKILL = "DELSKILL";
        // 删除技能
        public const int nSC_DELSKILL = 307;
        public const string sSC_ADDSKILL = "ADDSKILL";
        // 增加技能 支持英雄
        public const int nSC_ADDSKILL = 308;
        public const string sSC_SKILLLEVEL = "SKILLLEVEL";
        // 调整技能等级
        public const int nSC_SKILLLEVEL = 309;
        public const string sSC_CHANGEPKPOINT = "CHANGEPKPOINT";
        public const int nSC_CHANGEPKPOINT = 310;
        public const string sSC_CHANGEEXP = "CHANGEEXP";
        public const int nSC_CHANGEEXP = 311;
        public const string sSC_CHANGEJOB = "CHANGEJOB";
        public const int nSC_CHANGEJOB = 312;
        public const string sSC_MISSION = "MISSION";
        public const int nSC_MISSION = 313;
        public const string sSC_MOBPLACE = "MOBPLACE";
        public const int nSC_MOBPLACE = 314;
        public const string sSC_SETMEMBERTYPE = "SETMEMBERTYPE";
        public const int nSC_SETMEMBERTYPE = 315;
        public const string sSC_SETMEMBERLEVEL = "SETMEMBERLEVEL";
        public const int nSC_SETMEMBERLEVEL = 316;
        public const string sSC_GAMEGOLD = "GAMEGOLD";
        // 调整元宝数
        public const int nSC_GAMEGOLD = 317;
        public const string sSC_AUTOADDGAMEGOLD = "AUTOADDGAMEGOLD";
        public const int nSC_AUTOADDGAMEGOLD = 318;
        public const string sSC_AUTOSUBGAMEGOLD = "AUTOSUBGAMEGOLD";
        public const int nSC_AUTOSUBGAMEGOLD = 319;
        public const string sSC_CHANGENAMECOLOR = "CHANGENAMECOLOR";
        public const int nSC_CHANGENAMECOLOR = 320;
        public const string sSC_CLEARPASSWORD = "CLEARPASSWORD";
        public const int nSC_CLEARPASSWORD = 321;
        public const string sSC_RENEWLEVEL = "RENEWLEVEL";
        public const int nSC_RENEWLEVEL = 322;
        public const string sSC_KILLMONEXPRATE = "KILLMONEXPRATE";
        // 调整杀怪经验的倍数
        public const int nSC_KILLMONEXPRATE = 323;
        public const string sSC_POWERRATE = "POWERRATE";
        public const int nSC_POWERRATE = 324;
        public const string sSC_CHANGEMODE = "CHANGEMODE";
        // 改变管理模式(不检查权限)
        public const int nSC_CHANGEMODE = 325;
        public const string sSC_CHANGEPERMISSION = "CHANGEPERMISSION";
        public const int nSC_CHANGEPERMISSION = 326;
        public const string sSC_KILL = "KILL";
        public const int nSC_KILL = 327;
        public const string sSC_KICK = "KICK";
        public const int nSC_KICK = 328;
        public const string sSC_BONUSPOINT = "BONUSPOINT";
        public const int nSC_BONUSPOINT = 329;
        public const string sSC_RESTRENEWLEVEL = "RESTRENEWLEVEL";
        public const int nSC_RESTRENEWLEVEL = 330;
        public const string sSC_DELMARRY = "DELMARRY";
        public const int nSC_DELMARRY = 331;
        public const string sSC_DELMASTER = "DELMASTER";
        public const int nSC_DELMASTER = 332;
        public const string sSC_MASTER = "MASTER";
        public const int nSC_MASTER = 333;
        public const string sSC_UNMASTER = "UNMASTER";
        public const int nSC_UNMASTER = 334;
        public const string sSC_CREDITPOINT = "CREDITPOINT";
        public const int nSC_CREDITPOINT = 335;
        public const string sSC_CLEARNEEDITEMS = "CLEARNEEDITEMS";
        public const int nSC_CLEARNEEDITEMS = 336;
        public const string sSC_CLEARMAKEITEMS = "CLEARMAKEITEMS";
        public const int nSC_CLEARMAEKITEMS = 337;
        public const string sSC_SETSENDMSGFLAG = "SETSENDMSGFLAG";
        public const int nSC_SETSENDMSGFLAG = 338;
        public const string sSC_UPGRADEITEMS = "UPGRADEITEM";
        public const int nSC_UPGRADEITEMS = 339;
        public const string sSC_UPGRADEITEMSEX = "UPGRADEITEMEX";
        public const int nSC_UPGRADEITEMSEX = 340;
        public const string sSC_MONGENEX = "MONGENEX";
        public const int nSC_MONGENEX = 341;
        public const string sSC_CLEARMAPMON = "CLEARMAPMON";
        public const int nSC_CLEARMAPMON = 342;
        public const string sSC_SETMAPMODE = "SETMPAMODE";
        public const int nSC_SETMAPMODE = 343;
        public const string sSC_GAMEPOINT = "GAMEPOINT";
        public const int nSC_GAMEPOINT = 344;
        public const string sSC_PKZONE = "PKZONE";
        public const int nSC_PKZONE = 345;
        public const string sSC_RESTBONUSPOINT = "RESTBONUSPOINT";
        public const int nSC_RESTBONUSPOINT = 346;
        public const string sSC_TAKECASTLEGOLD = "TAKECASTLEGOLD";
        public const int nSC_TAKECASTLEGOLD = 347;
        public const string sSC_HUMANHP = "HUMANHP";
        public const int nSC_HUMANHP = 348;
        public const string sSC_HUMANMP = "HUMANMP";
        public const int nSC_HUMANMP = 349;
        public const string sSC_BUILDPOINT = "GUILDBUILDPOINT";
        public const int nSC_BUILDPOINT = 350;
        public const string sSC_AURAEPOINT = "GUILDAURAEPOINT";
        public const int nSC_AURAEPOINT = 351;
        public const string sSC_STABILITYPOINT = "GUILDSTABILITYPOINT";
        public const int nSC_STABILITYPOINT = 352;
        public const string sSC_FLOURISHPOINT = "GUILDFLOURISHPOINT";
        public const int nSC_FLOURISHPOINT = 353;
        public const string sSC_OPENBOX = "OPENBOX";
        // 无忧加对blue脚本开宝箱的功能
        public const string sSC_OPENMAGICBOX = "OPENITEMBOX";
        public const int nSC_OPENMAGICBOX = 354;
        public const string sSC_CHECKMAKEWINE = "CHECKMAKEWINE";
        // 检测酒品质  20080806
        public const int nSC_CHECKMAKEWINE = 356;
        // ---------------------------------------------------------
        public const string sSC_CHECKONLINEPLAYCOUNT = "CHECKONLINEPLAYCOUNT";
        public const int nSC_CHECKONLINEPLAYCOUNT = 357;
        public const string sSC_CHECKPLAYDIELVL = "CHECKPLAYDIELVL";
        public const int nSC_CHECKPLAYDIELVL = 358;
        // 杀人后检测
        public const string sSC_CHECKPLAYDIEJOB = "CHECKPLAYDIEJOB";
        public const int nSC_CHECKPLAYDIEJOB = 359;
        public const string sSC_CHECKPLAYDIESEX = "CHECKPLAYDIESEX";
        public const int nSC_CHECKPLAYDIESEX = 360;
        public const string sSC_CHECKKILLPLAYLVL = "CHECKKILLPLAYLVL";
        public const int nSC_CHECKKILLPLAYLVL = 361;
        // 死亡后检测
        public const string sSC_CHECKKILLPLAYJOB = "CHECKKILLPLAYJOB";
        public const int nSC_CHECKKILLPLAYJOB = 362;
        public const string sSC_CHECKKILLPLAYSEX = "CHECKKILLPLAYSEX";
        public const int nSC_CHECKKILLPLAYSEX = 363;
        public const string sSC_CHECKITEMLEVEL = "CHECKITEMLEVEL";
        // 检查装备升级次数 
        public const int nSC_CHECKITEMLEVEL = 364;
        public const string sCHECKITEMSNAME = "CHECKITEMSNAME";
        // 检查指定装备位置是否带有指定的物品
        public const int nCHECKITEMSNAME = 365;
        public const string sKILLBYHUM = "KILLBYHUM";
        // 检测是否被人物所杀 
        public const int nKILLBYHUM = 366;
        public const string sREADSKILLNG = "READSKILLNG";
        // NPC学习内功 
        public const int nREADSKILLNG = 367;
        public const string sSC_CHANGENGEXP = "CHANGENGEXP";
        // 调整人物内力经验点数 
        public const int nSC_CHANGENGEXP = 368;
        public const string sSC_CHANGREADNG = "CHANGREADNG";
        // 检查角色是否学过内功 
        public const int nSC_CHANGREADNG = 369;
        public const string sSC_CHANGENGLEVEL = "CHANGENGLEVEL";
        // 调整人物内力等级 
        public const int nSC_CHANGENGLEVEL = 370;
        public const string sSC_CHANGEGUILDFOUNTAIN = "CHANGEGUILDFOUNTAIN";
        // 调整行会酒泉 
        public const int nSC_CHANGEGUILDFOUNTAIN = 371;
        public const string sCHECKGUILDFOUNTAINVALUE = "CHECKGUILDFOUNTAINVALUE";
        // 检测行会酒泉数 20081017
        public const int nCHECKGUILDFOUNTAINVALUE = 372;
        public const string sSC_TAGMAPINFO = "TAGMAPINFO";
        // 记路标石 20081019
        public const int nSC_TAGMAPINFO = 373;
        public const string sSC_TAGMAPMOVE = "TAGMAPMOVE";
        // 移动到记路标石记录的地图XY 20081019
        public const int nSC_TAGMAPMOVE = 374;
        public const string sCHECKNGLEVEL = "CHECKNGLEVEL";
        // 检查角色内功等级 20081223
        public const int nCHECKNGLEVEL = 375;
        public const string sCREATEFILE = "CREATEFILE";
        // 创建文本文件 20081226
        public const int nCREATEFILE = 376;
        public const string sSC_SENDMSGWINDOWS = "SENDMSGWINDOWS";
        // 时间到解发QF段 20090124
        public const int nSC_SENDMSGWINDOWS = 377;
        public const string sSC_CHECKSTRINGLENGTH = "CHECKSTRINGLENGTH";
        // 检查字符串的长度 20090105
        public const int nSC_CHECKSTRINGLENGTH = 378;
        public const string sCHECKGUILDMEMBERCOUNT = "CHECKGUILDMEMBERCOUNT";
        // 检测行会成员上限 20090115
        public const int nCHECKGUILDMEMBERCOUNT = 379;
        public const string sSC_CHANGEGUILDMEMBERCOUNT = "CHANGEGUILDMEMBERCOUNT";
        // 调整行会成员上限 20090115
        public const int nSC_CHANGEGUILDMEMBERCOUNT = 380;
        public const string sSC_SENDTIMEMSG = "SENDTIMEMSG";
        // 时间到解发QF段(客户端显示时间) 20090124
        public const int nSC_SENDTIMEMSG = 381;
        public const string sSC_GETGROUPCOUNT = "GETGROUPCOUNT";
        // 取组队成员数 
        public const int nSC_GETGROUPCOUNT = 382;
        public const string sSC_CLOSEMSGWINDOWS = "CLOSEMSGWINDOWS";
        // 关闭客户端'!'图标的显示 
        public const int nSC_CLOSEMSGWINDOWS = 383;
        public const string sSC_OPENEXPCRYSTAL = "OPENEXPCRYSTAL";
        // 客户端显示天地结晶 20090131
        public const int nSC_OPENEXPCRYSTAL = 384;
        public const string sSC_CLOSEEXPCRYSTAL = "CLOSEEXPCRYSTAL";
        // 客户端显示天地结晶 20090131
        public const int nSC_CLOSEEXPCRYSTAL = 385;
        public const string sSC_GETEXPTOCRYSTAL = "GETEXPTOCRYSTAL";
        // 取提天地结晶中的经验(只提取可提取的经验) 20090202
        public const int nSC_GETEXPTOCRYSTAL = 386;
        // --------------------------连击相关------------------------------------------//
        public const string sSC_OPENMAKEKIMNEEDLE = "OPENMAKEKIMNEEDLE";
        // 客户端显示锻练金针窗口
        public const int nSC_OPENMAKEKIMNEEDLE = 387;
        public const string sSC_CHECKKIMNEEDLE = "CHECKKIMNEEDLE";
        // 检查包裹是否有指定叠加物品
        public const int nSC_CHECKKIMNEEDLE = 388;
        public const string sSC_TAKEKIMNEEDLE = "TAKEKIMNEEDLE";
        public const int nSC_TAKEKIMNEEDLE = 389;
        public const string sSC_GIVEKIMNEEDLE = "GIVEKIMNEEDLE";
        public const int nSC_GIVEKIMNEEDLE = 390;
        public const string sSC_CHECKHUMANPULSE = "CHECKHUMANPULSE";
        public const int nSC_CHECKHUMANPULSE = 391;
        public const string sSC_CHECKOPENPULSELEVEL = "CHECKOPENPULSELEVEL";
        public const int nSC_CHECKOPENPULSELEVEL = 392;
        public const string sSC_OPENPULSE = "OPENPULSE";
        public const int nSC_OPENPULSE = 393;
        public const string sSC_CHANGEPULSELEVEL = "CHANGEPULSELEVEL";
        public const int nSC_CHANGEPULSELEVEL = 395;
        public const string sSC_CHECKPULSELEVEL = "CHECKPULSELEVEL";
        public const int nSC_CHECKPULSELEVEL = 396;
        public const string sSC_CHANGHEARMSGCOLOR = "CHANGHEARMSGCOLOR";
        // 未实现 20091219 邱高奇
        public const int nSC_CHANGHEARMSGCOLOR = 397;
        public const string sSC_CHECKHEARMSGCOLOR = "CHECKHEARMSGCOLOR";
        public const int nSC_CHECKHEARMSGCOLOR = 398;
        // 功能：开通英雄经脉(学了内功才能使用)
        // 格式：OPENHEROPULS
        public const string sSC_OPENHEROPULS = "OPENHEROPULS";
        public const int nSC_OPENHEROPULS = 400;
        // 功能：改变英雄经络修炼点(打通一条经络后才有效)
        // 格式：CHANGEHEROPULSEXP 控制符(+,-,=) 经验值
        public const string sSC_CHANGEHEROPULSEXP = "CHANGEHEROPULSEXP";
        public const int nSC_CHANGEHEROPULSEXP = 401;
        // 功能：检查英雄是否开通经脉系统(英雄不在线，没学内功都将为F)
        // 格式：CHECKHEROOPENOPULS
        public const string sSC_CHECKHEROOPENOPULS = "CHECKHEROOPENOPULS";
        // 未实现 20091219 邱高奇
        public const int nSC_CHECKHEROOPENOPULS = 402;
        // 功能：检查英雄经络修炼点
        // 格式：CHECKHEROPULSEXP 控制符(>,<,=) 经验值
        public const string sSC_CHECKHEROPULSEXP = "CHECKHEROPULSEXP";
        public const int nSC_CHECKHEROPULSEXP = 403;
        // 功能：检查物品数量以及持久值
        // 命令格式:CHECKITMECOUNTDURA 物品名称 数量 操作符(<>=) 持久(MaxDura--物品的持久上限)
        // 注：持久是按M2上的数据，并非客户端显示的数据
        public const string sSC_CHECKITMECOUNTDURA = "CHECKITMECOUNTDURA";
        // 未实现 20091219 邱高奇
        public const int nSC_CHECKITMECOUNTDURA = 404;
        // 功能：收回指定名称物品(按数量，持久)
        // 格式：TAKEITMECOUNTDURA 物品名称 数量 操作符(<>=) 持久(MaxDura--物品的持久上限)
        public const string sSC_TAKEITMECOUNTDURA = "TAKEITMECOUNTDURA";
        // 未实现 20091219 邱高奇
        public const int nSC_TAKEITMECOUNTDURA = 405;
        // -------富贵兽相关------------//
        // 功能：客户端显示牛气管图标
        // 格式：OPENCATTLEGAS 是否清空变量
        // 说明: 参数为空时,表示清空变量,不为空时,表示不需要清变量
        public const string sSC_OPENCATTLEGAS = "OPENCATTLEGAS";
        public const int nSC_OPENCATTLEGAS = 406;
        // 功能：客户端关闭牛气管图标
        // 格式：CLOSECATTLEGAS
        public const string sSC_CLOSECATTLEGAS = "CLOSECATTLEGAS";
        public const int nSC_CLOSECATTLEGAS = 407;
        // 功能:调整人物牛气值
        // 格式:CHANGECATTLEGASEXP 控制符(=,+,-) 牛气值点数
        public const string sSC_CHANGECATTLEGASEXP = "CHANGECATTLEGASEXP";// 未实现
        public const int nSC_CHANGECATTLEGASEXP = 408;
        /// <summary>
        /// 弹出评定主副将窗口
        /// </summary>
        public const string sSC_ASSESSMENTHERO = "ASSESSMENTHERO";
        public const int nSC_ASSESSMENTHERO = 409;
        /// <summary>
        /// 检查是否评定过主副将英雄
        /// </summary>
        public const string sSC_CheckAssessMentHero = "CHECKASSESSMENTHERO";
        public const int nSC_CheckAssessMentHero = 410;
        /// <summary>
        /// 检查当前在线英雄是否为副将英雄
        /// </summary>
        public const string sSC_CheckDeputyHero = "CHECKDEPUTYHERO";
        public const int nSC_CheckDeputyHero = 411;
        /// <summary>
        /// 检查副将英雄是否正在自我修
        /// </summary>
        public const string sSC_CheckHeroAutoPractice = "CHECKHEROAUTOPRACTICE";
        public const int nSC_CheckHeroAutoPractice = 412;
        /// <summary>
        /// 打开英雄自我修炼窗口
        /// </summary>
        public const string sSC_OpenHeroAutoPractice = "OPENHEROAUTOPRACTICE";
        public const int nSC_OpenHeroAutoPractice = 413;
        /// <summary>
        /// 停止英雄自我修炼
        /// 当修炼计时达到7200秒后，执行命令则触发@StopHeroAuto脚本，以实现给玩家物品
        /// </summary>
        public const string sSC_StopHeroAutoPractice = "STOPHEROAUTOPRACTICE";
        public const int nSC_StopHeroAutoPractice = 414;
        /// <summary>
        /// 检查是否学习过护体神盾
        /// </summary>
        public const string sSC_CHECKSKILL75 = "CHECKSKILL75";
        public const int nSC_CHECKSKILL75 = 415;
        public const string sSC_CHANGETRANPOINT = "CHANGETRANPOINT";// 技能名 操作符(+ - =) 数值
        public const int nSC_CHANGETRANPOINT = 416;
        public const string sSC_NPCGIVEITEM = "NPCGIVEITEM";
        public const int nSC_NPCGIVEITEM = 417;
        /// <summary>
        /// 检测指定人物是否在指定地图范围之内
        /// </summary>
        public const string sSC_CHECKHUMINRANGE = "CHECKHUMINRANGE";
        public const int nSC_CHECKHUMINRANGE = 418;
        /// <summary>
        /// 检测当前地图中的人物是否属于同一个行会(所有人是同一行会才为真)
        /// </summary>
        public const string sSC_MAPHUMISSAMEGUILD = "MAPHUMISSAMEGUILD";
        public const int nSC_MAPHUMISSAMEGUILD = 419;
    }
}