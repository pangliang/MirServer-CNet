namespace GameFramework
{
    public class TMapFlag
    {
        // 地图参数
        public bool boSAFE;

        public bool boDARK;
        public bool boFIGHT;
        public bool boFIGHT2;

        // 新PK地图，可以pk，但掉装备 20080525
        public bool boFIGHT3;

        public bool boFIGHT4;

        // 挑战地图 20080706
        public bool boDAY;

        public bool boQUIZ;
        public bool boNORECONNECT;
        public bool boMUSIC;
        public bool boEXPRATE;
        public bool boPKWINLEVEL;
        public bool boPKWINEXP;
        public bool boPKLOSTLEVEL;
        public bool boPKLOSTEXP;
        public bool boDECHP;
        public bool boINCHP;
        public bool boDECGAMEGOLD;
        public bool boDECGAMEPOINT;

        // 自动减游戏点
        public bool boINCGAMEGOLD;

        public bool boINCGAMEPOINT;

        // 自动加游戏点
        public bool boNoCALLHERO;

        // 禁止召唤英雄 20080124
        public bool boNEEDLEVELTIME;

        // 雪域地图传送,判断等级,地图时间 20081228
        public int nNEEDLEVELPOINT;

        // 进雪域地图最低等级
        public bool boMoveToHome;

        // 是否需倒计时传送到指定点(雪域) 20081230
        public string sMoveToHomeMap;

        // 传送的地图名
        public int nMoveToHomeX;

        // 传送的地图X
        public int nMoveToHomeY;

        // 传送的地图Y
        public bool boNOHEROPROTECT;

        // 禁止英雄守护 20080629
        public bool boNODROPITEM;

        // 禁止死亡掉物品 20080503
        public bool boMISSION;

        // 不允许使用任何物品和技能 20080124
        public bool boRUNHUMAN;

        public bool boRUNMON;
        public bool boNEEDHOLE;
        public bool boNORECALL;
        public bool boNOGUILDRECALL;
        public bool boNODEARRECALL;
        public bool boNOMASTERRECALL;
        public bool boNORANDOMMOVE;
        public bool boNODRUG;
        public bool boMINE;
        public bool boNOPOSITIONMOVE;
        public bool boNoManNoMon;

        // 智能刷怪,有人才重新刷怪 20080525
        public bool boKILLFUNC;

        // 地图杀人触发 20080415
        public int nKILLFUNC;

        // 地图杀人触发 20080415
        // nL: Integer;//20080815 注释
        public int nNEEDSETONFlag;

        public int nNeedONOFF;
        public int nMUSICID;
        public int nPKWINLEVEL;
        public int nEXPRATE;
        public uint nPKWINEXP;
        public int nPKLOSTLEVEL;
        public uint nPKLOSTEXP;
        public int nDECHPPOINT;
        public int nDECHPTIME;
        public int nINCHPPOINT;
        public int nINCHPTIME;
        public uint nDECGAMEGOLD;
        public int nDECGAMEGOLDTIME;
        public int nDECGAMEPOINT;
        public int nDECGAMEPOINTTIME;
        public int nINCGAMEGOLD;
        public int nINCGAMEGOLDTIME;
        public int nINCGAMEPOINT;
        public int nINCGAMEPOINTTIME;
        public string sReConnectMap;
        public string sMUSICName;
        public bool boUnAllowStdItems;
        public string sUnAllowStdItemsText;

        // 地图禁用物品
        public string sUnAllowMagicText;

        // 不允许魔法
        public bool boNOTALLOWUSEMAGIC;

        // 不允许魔法
        public bool boAutoMakeMonster;

        public bool boFIGHTPK;

        // PK可以爆装备不红名
        public int nThunder;

        // 闪电 20080327
        public int nLava;
    }
}