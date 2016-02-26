using System;

namespace GameFramework
{
    /// <summary>
    /// 引擎配置参数
    /// </summary>
    public class TGameConfig
    {
        /// <summary>
        /// 内功最高等级
        /// </summary>
        public const int MAXCHANGELEVEL = 1000;

        public string sConnectionString;
        public string sServerName;
        public string sServerIPaddr;
        public string sRegServerAddr;
        public int nRegServerPort;
        public string sRegKey;
        public string sWebSite;
        public string sBbsSite;
        public string sClientDownload;
        public string sQQ;
        public string sPhone;
        public string sBankAccount0;
        public string sBankAccount1;
        public string sBankAccount2;
        public string sBankAccount3;
        public string sBankAccount4;
        public string sBankAccount5;
        public string sBankAccount6;
        public string sBankAccount7;
        public string sBankAccount8;
        public string sBankAccount9;

        /// <summary>
        /// 服务器数
        /// </summary>
        public ushort nServerNumber;

        /// <summary>
        /// 不刷怪模式
        /// </summary>
        public bool boVentureServer;

        /// <summary>
        /// 测试模式
        /// </summary>
        public bool boTestServer;

        public bool boServiceMode;
        public bool boNonPKServer;

        /// <summary>
        /// 测试模式开始等级
        /// </summary>
        public ushort nTestLevel;

        /// <summary>
        /// 测试模式开始金币数量
        /// </summary>
        public int nTestGold;

        /// <summary>
        /// 测试模式上线人数限制(2000)
        /// </summary>
        public ushort nTestUserLimit;

        /// <summary>
        /// 网关数据传输数据块大小
        /// </summary>
        public int nSendBlock;

        /// <summary>
        /// 网关数据传输数据块大小
        /// </summary>
        public int nCheckBlock;

        public int nAvailableBlock;
        public int nGateLoad;

        /// <summary>
        /// 最高上线人数
        /// </summary>
        public int nUserFull;

        public int nZenFastStep;
        public string sGateAddr;

        /// <summary>
        /// 网关端口(65535)
        /// </summary>
        public ushort nGatePort;

        /// <summary>
        /// DBServer IP
        /// </summary>
        public string sDBAddr;

        /// <summary>
        /// DBServer端口
        /// </summary>
        public ushort nDBPort;

        /// <summary>
        ///  LoginSrv IP
        /// </summary>
        public string sIDSAddr;

        /// <summary>
        ///  LoginSrv端口
        /// </summary>
        public ushort nIDSPort;

        public string sMsgSrvAddr;
        public ushort nMsgSrvPort;
        public string sLogServerAddr;

        /// <summary>
        /// 日志程序端口
        /// </summary>
        public ushort nLogServerPort;

        public bool boDiscountForNightTime;
        public int nHalfFeeStart;
        public int nHalfFeeEnd;
        public bool boViewHackMessage;
        public bool boViewAdmissionFailure;
        public string sBaseDir;
        public string sGuildDir;
        public string sGuildFile;
        public string sVentureDir;
        public string sConLogDir;
        public string sCastleDir;
        public string sCastleFile;

        /// <summary>
        /// 排行榜路径
        /// </summary>
        public string sSortDir;

        /// <summary>
        /// 宝箱路径
        /// </summary>
        public string sBoxsDir;

        /// <summary>
        /// 宝箱文件(BoxsList.txt)
        /// </summary>
        public string sBoxsFile;

        /// <summary>
        /// 脚本文件路径
        /// </summary>
        public string sEnvirDir;

        /// <summary>
        /// 地图路径
        /// </summary>
        public string sMapDir;

        /// <summary>
        /// 游戏公告路径
        /// </summary>
        public string sNoticeDir;

        /// <summary>
        /// 游戏日志路径
        /// </summary>
        public string sLogDir;

        /// <summary>
        /// 游戏插件路径
        /// </summary>
        public string sPlugDir;

        public string sClientFile1;
        public string sClothsMan;
        public string sClothsWoman;
        public string sWoodenSword;
        public string sCandle;
        public string sBasicDrug;
        public string sGoldStone;
        public string sSilverStone;
        public string sSteelStone;
        public string sCopperStone;
        public string sBlackStone;
        public string[] sZuma;
        public string sBee;
        public string sSpider;
        /// <summary>
        /// 沃玛号角
        /// </summary>
        public string sWomaHorn;
        public string sZumaPiece;

        /// <summary>
        /// 金币
        /// </summary>
        public string sGameGoldName;

        /// <summary>
        /// 金刚石
        /// </summary>
        public string sGameDiaMond;

        /// <summary>
        /// 灵符
        /// </summary>
        public string sGameGird;

        /// <summary>
        /// 荣誉值
        /// </summary>
        public string sGameGlory;

        /// <summary>
        /// 声望值
        /// </summary>
        public string sGamePointName;

        public string sPayMentPointName;
        public int DBSocket;
        public int nHealthFillTime;
        public int nSpellFillTime;

        /// <summary>
        /// 宝宝升级杀怪基数
        /// </summary>
        public int nMonUpLvNeedKillBase;

        /// <summary>
        /// 宝宝升级杀怪倍率
        /// </summary>
        public ushort nMonUpLvRate;

        public ushort[] MonUpLvNeedKillCount;
        public byte[] SlaveColor;
        public uint[] dwNeedExps;
        public uint[] dwHeroNeedExps;

        /// <summary>
        /// 药力值
        /// </summary>
        public ushort[] dwMedicineNeedExps;

        /// <summary>
        /// 酒气护体升级经验
        /// </summary>
        public uint[] dwSkill68NeedExps;

        /// <summary>
        /// 天地结晶升级经验
        /// </summary>
        public uint[] dwExpCrystalNeedExps;

        /// <summary>
        /// 天地结晶内功升级经验
        /// </summary>
        public uint[] dwNGExpCrystalNeedExps;

        /// <summary>
        /// 半月刀法的方向
        /// </summary>
        public byte[] WideAttack;

        /// <summary>
        /// 抱月刀法的方向
        /// </summary>
        public byte[] CrsAttack;

        /// <summary>
        /// 圆月刀法的方向
        /// </summary>
        public byte[] YuanYueAttack;

        public byte[, ,] SpitMap;
        public string sHomeMap;
        public int nHomeX;
        public int nHomeY;
        public string sRedHomeMap;
        public int nRedHomeX;
        public int nRedHomeY;
        public string sRedDieHomeMap;
        public int nRedDieHomeX;
        public int nRedDieHomeY;
        public uint dwDecPkPointTime;

        /// <summary>
        /// PK减点数(2000)
        /// </summary>
        public ushort nDecPkPointCount;

        public uint dwPKFlagTime;

        /// <summary>
        /// 杀人武器被诅咒机率
        /// </summary>
        public byte nKillHumanWeaponUnlockRate;

        /// <summary>
        /// 杀人增加PK点数(2000)
        /// </summary>
        public ushort nKillHumanAddPKPoint;

        public ushort nKillHumanDecLuckPoint;
        public uint dwDecLightItemDrugTime;

        /// <summary>
        /// 安全区范围(2000)
        /// </summary>
        public ushort nSafeZoneSize;

        /// <summary>
        /// 新人出生点控制(2000)
        /// </summary>
        public ushort nStartPointSize;

        public uint dwHumanGetMsgTime;

        /// <summary>
        /// 新建行会成员上限
        /// </summary>
        public ushort nGuildMemberCount;

        /// <summary>
        /// 组队成员数量(2000)
        /// </summary>
        public ushort nGroupMembersMax;

        public string sFireBallSkill;
        public string sHealSkill;
        public string sHeavenSKill;

        // 倚天劈地
        public string sXuepozhanSKill;

        // 血魄一击（战）
        public string MeteorSKill;

        // 流星
        public byte[] ReNewNameColor;

        // ($FF,$FE,$93,$9A,$E5,$A8,$B4,$FC,$B4,$FC);
        public uint dwReNewNameColorTime;

        public bool boReNewChangeColor;
        public bool boReNewLevelClearExp;
        public TNakedAbility BonusAbilofWarr;
        public TNakedAbility BonusAbilofWizard;
        public TNakedAbility BonusAbilofTaos;
        public TNakedAbility NakedAbilofWarr;
        public TNakedAbility NakedAbilofWizard;
        public TNakedAbility NakedAbilofTaos;

        /// <summary>
        /// 武器升级最高点数(1000)
        /// </summary>
        public ushort nUpgradeWeaponMaxPoint;

        public int nUpgradeWeaponPrice;
        public uint dwUPgradeWeaponGetBackTime;

        /// <summary>
        /// 武器升级过期天数(100)
        /// </summary>
        public byte nClearExpireUpgradeWeaponDays;

        /// <summary>
        /// 武器攻击力升级成功机率(500)
        /// </summary>
        public ushort nUpgradeWeaponDCRate;

        /// <summary>
        /// 武器攻击力二点机率(500)
        /// </summary>
        public ushort nUpgradeWeaponDCTwoPointRate;

        /// <summary>
        /// 武器攻击力三点机率(500)
        /// </summary>
        public ushort nUpgradeWeaponDCThreePointRate;

        /// <summary>
        /// 武器道术升级成功机率(500)
        /// </summary>
        public ushort nUpgradeWeaponSCRate;

        /// <summary>
        /// 武器道术二点机率(100)
        /// </summary>
        public ushort nUpgradeWeaponSCTwoPointRate;

        /// <summary>
        /// 武器道术三点机率(500)
        /// </summary>
        public ushort nUpgradeWeaponSCThreePointRate;

        /// <summary>
        /// 武器魔法升级成功机率(500)
        /// </summary>
        public ushort nUpgradeWeaponMCRate;

        /// <summary>
        /// 武器魔法二点机率(100)
        /// </summary>
        public ushort nUpgradeWeaponMCTwoPointRate;

        /// <summary>
        ///  武器魔法三点机率(500)
        /// </summary>
        public ushort nUpgradeWeaponMCThreePointRate;

        /// <summary>
        /// 刷怪处理间隔
        /// </summary>
        public uint dwProcessMonstersTime;

        /// <summary>
        /// 刷怪间隔(1000)
        /// </summary>
        public uint dwRegenMonstersTime;

        /// <summary>
        /// 刷怪倍数(1000)
        /// </summary>
        public ushort nMonGenRate;

        public int nSoftVersionDate;
        public bool boCanOldClientLogon;

        /// <summary>
        /// 控制台显示人数间隔
        /// </summary>
        public uint dwConsoleShowUserCountTime;

        /// <summary>
        /// 公告显示间隔
        /// </summary>
        public uint dwShowLineNoticeTime;

        /// <summary>
        /// 公告显示颜色
        /// </summary>
        public byte nLineNoticeColor;

        /// <summary>
        /// 申请攻城天数
        /// </summary>
        public byte nStartCastleWarDays;

        /// <summary>
        /// 攻城开始时间(24H)
        /// </summary>
        public byte nStartCastlewarTime;

        public uint dwShowCastleWarEndMsgTime;
        public uint dwCastleWarTime;

        /// <summary>
        /// 禁止占领时间
        /// </summary>
        public uint dwGetCastleTime;

        /// <summary>
        /// 行会战时间
        /// </summary>
        public uint dwGuildWarTime;
        /// <summary>
        /// 建立行会金币数量
        /// </summary>
        public int nBuildGuildPrice;
        public int nGuildWarPrice;
        public int nMakeDurgPrice;

        /// <summary>
        /// 人物最大金币数
        /// </summary>
        public int nHumanMaxGold;
        /// <summary>
        /// 人物最大金币数
        /// </summary>
        public int nHumanTryModeMaxGold;

        /// <summary>
        /// 试玩等级限制(100)
        /// </summary>
        public byte nTryModeLevel;

        public bool boTryModeUseStorage;

        /// <summary>
        /// 允许喊话等级(65535)
        /// </summary>
        public ushort nCanShoutMsgLevel;

        public bool boShowMakeItemMsg;
        public bool boShutRedMsgShowGMName;

        /// <summary>
        /// 聊天信息长度(255)
        /// </summary>
        public byte nSayMsgMaxLen;

        public uint dwSayMsgTime;

        /// <summary>
        /// 发送信息数量(255)
        /// </summary>
        public byte nSayMsgCount;

        public uint dwDisableSayMsgTime;

        /// <summary>
        /// 广播信息长度(255)
        /// </summary>
        public byte nSayRedMsgMaxLen;

        public bool boShowGuildName;
        public bool boShowRankLevelName;

        /// <summary>
        /// 是否开启怪物说话
        /// </summary>
        public bool boMonSayMsg;

        /// <summary>
        /// 人物起始权限(10)
        /// </summary>
        public byte nStartPermission;

        /// <summary>
        /// 杀人增加等级
        /// </summary>
        public bool boKillHumanWinLevel;

        public bool boKilledLostLevel;
        public bool boKillHumanWinExp;
        public bool boKilledLostExp;
        public ushort nKillHumanWinLevel;
        public ushort nKilledLostLevel;
        public UInt32 nKillHumanWinExp;
        public uint nKillHumanLostExp;

        /// <summary>
        ///  PK等级(100)
        /// </summary>
        public ushort nHumanLevelDiffer;

        /// <summary>
        /// 怪物属性倍率(20000)
        /// </summary>
        public ushort nMonsterPowerRate;

        public int nItemsPowerRate;

        /// <summary>
        /// 物品属性倍率(AC、MAC二个)(2000)
        /// </summary>
        public ushort nItemsACPowerRate;

        public bool boSendOnlineCount;

        /// <summary>
        /// 广播倍率(10)
        /// </summary>
        public byte nSendOnlineCountRate;

        /// <summary>
        /// 广播间隔
        /// </summary>
        public uint dwSendOnlineTime;

        /// <summary>
        /// 保存人物数据间隔
        /// </summary>
        public uint dwSaveHumanRcdTime;

        /// <summary>
        /// 释放人物数据间隔
        /// </summary>
        public uint dwHumanFreeDelayTime;

        public uint dwMakeGhostTime;

        /// <summary>
        /// 人形怪尸体清理时间
        /// </summary>
        public uint dwMakeGhostPlayMosterTime;

        public uint dwClearDropOnFloorItemTime;
        public uint dwFloorItemCanPickUpTime;

        /// <summary>
        /// 是否启用密码保护系统
        /// </summary>
        public bool boPasswordLockSystem;

        /// <summary>
        /// 是否锁定交易操作
        /// </summary>
        public bool boLockDealAction;

        /// <summary>
        /// 是否锁定扔物品操作
        /// </summary>
        public bool boLockDropAction;

        /// <summary>
        /// 是否锁定取仓库操作
        /// </summary>
        public bool boLockGetBackItemAction;

        /// <summary>
        /// 是否锁定人登录操作
        /// </summary>
        public bool boLockHumanLogin;

        /// <summary>
        /// 是否锁定走操作
        /// </summary>
        public bool boLockWalkAction;

        /// <summary>
        /// 是否锁定跑操作
        /// </summary>
        public bool boLockRunAction;

        /// <summary>
        /// 是否锁定攻击操作
        /// </summary>
        public bool boLockHitAction;

        /// <summary>
        /// 是否锁定魔法操作
        /// </summary>
        public bool boLockSpellAction;

        /// <summary>
        /// 是否锁定召唤英雄操作
        /// </summary>
        public bool boLockCallHeroAction;

        /// <summary>
        /// 是否锁定发信息操作
        /// </summary>
        public bool boLockSendMsgAction;

        /// <summary>
        /// 是否锁定使用物品操作
        /// </summary>
        public bool boLockUserItemAction;

        /// <summary>
        /// 锁定时进入隐身状态
        /// </summary>
        public bool boLockInObModeAction;

        /// <summary>
        /// 输入密码错误超过 指定次数则锁定密码(10)
        /// </summary>
        public byte nPasswordErrorCountLock;

        /// <summary>
        /// 输入密码错误超过限制则踢下线
        /// </summary>
        public bool boPasswordErrorKick;

        public byte nSendRefMsgRange;
        public bool boDecLampDura;
        public bool boHungerSystem;
        public bool boHungerDecHP;
        public bool boHungerDecPower;
        public bool boDiableHumanRun;

        /// <summary>
        /// 是否可穿人物
        /// </summary>
        public bool boRUNHUMAN;

        /// <summary>
        /// 是否可穿怪
        /// </summary>
        public bool boRUNMON;

        /// <summary>
        /// 是否可穿NPC
        /// </summary>
        public bool boRunNpc;

        /// <summary>
        /// 是否可穿守卫
        /// </summary>
        public bool boRunGuard;

        public bool boWarDisHumRun;

        /// <summary>
        /// 魔法盾效果 T-特色效果 F-盛大效果
        /// </summary>
        public bool boSkill31Effect;

        /// <summary>
        /// 四级魔法盾抵御伤害百分率
        /// </summary>
        public byte nSkill66Rate;

        /// <summary>
        /// 普通魔法盾抵御伤害百分率
        /// </summary>
        public byte nOrdinarySkill66Rate;

        /// <summary>
        /// 内力值参数
        /// </summary>
        public byte nSkill69NG;

        /// <summary>
        /// 主体内功经验参数
        /// </summary>
        public uint nSkill69NGExp;

        /// <summary>
        /// 英雄内功经验参数
        /// </summary>
        public uint nHeroSkill69NGExp;

        /// <summary>
        /// 增加内力值间隔
        /// </summary>
        public uint dwIncNHTime;

        /// <summary>
        /// 饮酒增加内功经验
        /// </summary>
        public UInt32 nDrinkIncNHExp;

        /// <summary>
        /// 内功抵御普通攻击消耗内力值
        /// </summary>
        public ushort nHitStruckDecNH;

        /// <summary>
        /// 管理员可以穿一切
        /// </summary>
        public bool boGMRunAll;

        /// <summary>
        /// 安全区是否穿
        /// </summary>
        public bool boSafeAreaLimited;

        public uint dwTryDealTime;
        public uint dwDealOKTime;
        public bool boCanNotGetBackDeal;
        public bool boDisableDeal;

        /// <summary>
        /// 可收徒弟数
        /// </summary>
        public byte nMasterCount;

        /// <summary>
        /// 出师等级(65535)
        /// </summary>
        public ushort nMasterOKLevel;

        /// <summary>
        /// 出师后师傅得的声望点(100)
        /// </summary>
        public byte nMasterOKCreditPoint;

        /// <summary>
        /// 徒弟出师后，师父得到的分配点数(1000)
        /// </summary>
        public ushort nMasterOKBonusPoint;

        public bool boPKLevelProtect;

        /// <summary>
        /// PK保护等级
        /// </summary>
        public ushort nPKProtectLevel;

        /// <summary>
        /// 红名PK保护等级
        /// </summary>
        public ushort nRedPKProtectLevel;

        /// <summary>
        /// 攻击翻倍倍率(60000)
        /// </summary>
        public ushort nItemPowerRate;

        /// <summary>
        /// 经验翻倍倍率(60000)
        /// </summary>
        public ushort nItemExpRate;

        public ushort nScriptGotoCountLimit;

        /// <summary>
        /// 前景  听到
        /// </summary>
        public byte btHearMsgFColor;

        /// <summary>
        /// 背景  听到
        /// </summary>
        public byte btHearMsgBColor;

        /// <summary>
        /// 前景  悄悄话
        /// </summary>
        public byte btWhisperMsgFColor;

        /// <summary>
        /// 背景  悄悄话
        /// </summary>
        public byte btWhisperMsgBColor;

        /// <summary>
        /// 前景  GM悄悄话
        /// </summary>
        public byte btGMWhisperMsgFColor;

        /// <summary>
        /// 背景  GM悄悄话
        /// </summary>
        public byte btGMWhisperMsgBColor;

        /// <summary>
        /// 前景  哭
        /// </summary>
        public byte btCryMsgFColor;

        /// <summary>
        /// 背景  哭
        /// </summary>
        public byte btCryMsgBColor;

        /// <summary>
        /// 前景
        /// </summary>
        public byte btGreenMsgFColor;

        /// <summary>
        /// 背景
        /// </summary>
        public byte btGreenMsgBColor;

        /// <summary>
        /// 前景
        /// </summary>
        public byte btBlueMsgFColor;

        /// <summary>
        /// 背景
        /// </summary>
        public byte btBlueMsgBColor;

        /// <summary>
        /// 前景  千里传音
        /// </summary>
        public byte btSayMsgFColor;

        /// <summary>
        /// 背景 千里传音
        /// </summary>
        public byte btSayeMsgBColor;

        /// <summary>
        /// 前景
        /// </summary>
        public byte btRedMsgFColor;

        /// <summary>
        /// 背景
        /// </summary>
        public byte btRedMsgBColor;

        /// <summary>
        /// 前景
        /// </summary>
        public byte btGuildMsgFColor;

        /// <summary>
        /// 背景
        /// </summary>
        public byte btGuildMsgBColor;

        /// <summary>
        /// 前景
        /// </summary>
        public byte btGroupMsgFColor;

        /// <summary>
        /// 背景
        /// </summary>
        public byte btGroupMsgBColor;

        /// <summary>
        /// 前景
        /// </summary>
        public byte btCustMsgFColor;

        /// <summary>
        /// 背景
        /// </summary>
        public byte btCustMsgBColor;

        /// <summary>
        /// 怪物掉极品的几率
        /// </summary>
        public byte nMonRandomAddValue;

        /// <summary>
        /// 制造物品出现极品的几率
        /// </summary>
        public byte nMakeRandomAddValue;

        /// <summary>
        /// 人形身上装备极品机率
        /// </summary>
        public byte nPlayMonRandomAddValue;

        public byte nWeaponDCAddValueMaxLimit;
        public byte nWeaponDCAddValueRate;
        public byte nWeaponMCAddValueMaxLimit;
        public byte nWeaponMCAddValueRate;
        public byte nWeaponSCAddValueMaxLimit;
        public byte nWeaponSCAddValueRate;
        public byte nWeaponDCAddRate;
        public byte nWeaponSCAddRate;
        public byte nWeaponMCAddRate;
        public byte nDressDCAddRate;
        public byte nDressDCAddValueMaxLimit;
        public byte nDressDCAddValueRate;
        public byte nDressMCAddRate;
        public byte nDressMCAddValueMaxLimit;
        public byte nDressMCAddValueRate;
        public byte nDressSCAddRate;
        public byte nDressSCAddValueMaxLimit;
        public byte nDressSCAddValueRate;
        public byte nDressACAddValueMaxLimit;
        public byte nDressACAddValueRate;
        public byte nDressACAddRate;
        public byte nDressMACAddValueMaxLimit;
        public byte nDressMACAddValueRate;
        public byte nDressMACAddRate;
        public byte nNeckLace202124DCAddRate;
        public byte nNeckLace202124DCAddValueMaxLimit;
        public byte nNeckLace202124DCAddValueRate;
        public byte nNeckLace202124MCAddRate;
        public byte nNeckLace202124MCAddValueMaxLimit;
        public byte nNeckLace202124MCAddValueRate;
        public byte nNeckLace202124SCAddRate;
        public byte nNeckLace202124SCAddValueMaxLimit;
        public byte nNeckLace202124SCAddValueRate;
        public byte nNeckLace202124ACAddValueMaxLimit;
        public byte nNeckLace202124ACAddValueRate;
        public byte nNeckLace202124ACAddRate;
        public byte nNeckLace202124MACAddValueMaxLimit;
        public byte nNeckLace202124MACAddValueRate;
        public byte nNeckLace202124MACAddRate;
        public byte nNeckLace19DCAddRate;
        public byte nNeckLace19DCAddValueMaxLimit;
        public byte nNeckLace19DCAddValueRate;
        public byte nNeckLace19MCAddRate;
        public byte nNeckLace19MCAddValueMaxLimit;
        public byte nNeckLace19MCAddValueRate;
        public byte nNeckLace19SCAddRate;
        public byte nNeckLace19SCAddValueMaxLimit;
        public byte nNeckLace19SCAddValueRate;
        public byte nNeckLace19ACAddValueMaxLimit;
        public byte nNeckLace19ACAddValueRate;
        public byte nNeckLace19ACAddRate;
        public byte nNeckLace19MACAddValueMaxLimit;
        public byte nNeckLace19MACAddValueRate;
        public byte nNeckLace19MACAddRate;
        public byte nArmRing26DCAddRate;
        public byte nArmRing26DCAddValueMaxLimit;
        public byte nArmRing26DCAddValueRate;
        public byte nArmRing26MCAddRate;
        public byte nArmRing26MCAddValueMaxLimit;
        public byte nArmRing26MCAddValueRate;
        public byte nArmRing26SCAddRate;
        public byte nArmRing26SCAddValueMaxLimit;
        public byte nArmRing26SCAddValueRate;
        public byte nArmRing26ACAddValueMaxLimit;
        public byte nArmRing26ACAddValueRate;
        public byte nArmRing26ACAddRate;
        public byte nArmRing26MACAddValueMaxLimit;
        public byte nArmRing26MACAddValueRate;
        public byte nArmRing26MACAddRate;
        public byte nRing22DCAddRate;
        public byte nRing22DCAddValueMaxLimit;
        public byte nRing22DCAddValueRate;
        public byte nRing22MCAddRate;
        public byte nRing22MCAddValueMaxLimit;
        public byte nRing22MCAddValueRate;
        public byte nRing22SCAddRate;
        public byte nRing22SCAddValueMaxLimit;
        public byte nRing22SCAddValueRate;
        public byte nRing23DCAddRate;
        public byte nRing23DCAddValueMaxLimit;
        public byte nRing23DCAddValueRate;
        public byte nRing23MCAddRate;
        public byte nRing23MCAddValueMaxLimit;
        public byte nRing23MCAddValueRate;
        public byte nRing23SCAddRate;
        public byte nRing23SCAddValueMaxLimit;
        public byte nRing23SCAddValueRate;
        public byte nRing23ACAddValueMaxLimit;
        public byte nRing23ACAddValueRate;
        public byte nRing23ACAddRate;
        public byte nRing23MACAddValueMaxLimit;
        public byte nRing23MACAddValueRate;
        public byte nRing23MACAddRate;
        public byte nBootsDCAddValueMaxLimit;

        // 极品鞋子加攻最高点
        public byte nBootsDCAddValueRate;

        public byte nBootsDCAddRate;
        public byte nBootsSCAddValueMaxLimit;
        public byte nBootsSCAddValueRate;
        public byte nBootsSCAddRate;
        public byte nBootsMCAddValueMaxLimit;
        public byte nBootsMCAddValueRate;
        public byte nBootsMCAddRate;
        public byte nBootsACAddValueMaxLimit;
        public byte nBootsACAddValueRate;
        public byte nBootsACAddRate;
        public byte nBootsMACAddValueMaxLimit;
        public byte nBootsMACAddValueRate;
        public byte nBootsMACAddRate;
        public byte nHelMetDCAddRate;
        public byte nHelMetDCAddValueMaxLimit;
        public byte nHelMetDCAddValueRate;
        public byte nHelMetMCAddRate;
        public byte nHelMetMCAddValueMaxLimit;
        public byte nHelMetMCAddValueRate;
        public byte nHelMetSCAddRate;
        public byte nHelMetSCAddValueMaxLimit;
        public byte nHelMetSCAddValueRate;
        public byte nHelMetACAddValueMaxLimit;
        public byte nHelMetACAddValueRate;
        public byte nHelMetACAddRate;
        public byte nHelMetMACAddValueMaxLimit;
        public byte nHelMetMACAddValueRate;
        public byte nHelMetMACAddRate;
        public byte nUnknowHelMetACAddRate;
        public byte nUnknowHelMetACAddValueMaxLimit;
        public byte nUnknowHelMetMACAddRate;
        public byte nUnknowHelMetMACAddValueMaxLimit;
        public byte nUnknowHelMetDCAddRate;
        public byte nUnknowHelMetDCAddValueMaxLimit;
        public byte nUnknowHelMetMCAddRate;
        public byte nUnknowHelMetMCAddValueMaxLimit;
        public byte nUnknowHelMetSCAddRate;
        public byte nUnknowHelMetSCAddValueMaxLimit;
        public byte nUnknowRingACAddRate;
        public byte nUnknowRingACAddValueMaxLimit;
        public byte nUnknowRingMACAddRate;
        public byte nUnknowRingMACAddValueMaxLimit;
        public byte nUnknowRingDCAddRate;
        public byte nUnknowRingDCAddValueMaxLimit;
        public byte nUnknowRingMCAddRate;
        public byte nUnknowRingMCAddValueMaxLimit;
        public byte nUnknowRingSCAddRate;
        public byte nUnknowRingSCAddValueMaxLimit;
        public byte nUnknowNecklaceACAddRate;
        public byte nUnknowNecklaceACAddValueMaxLimit;
        public byte nUnknowNecklaceMACAddRate;
        public byte nUnknowNecklaceMACAddValueMaxLimit;
        public byte nUnknowNecklaceDCAddRate;
        public byte nUnknowNecklaceDCAddValueMaxLimit;
        public byte nUnknowNecklaceMCAddRate;
        public byte nUnknowNecklaceMCAddValueMaxLimit;
        public byte nUnknowNecklaceSCAddRate;
        public byte nUnknowNecklaceSCAddValueMaxLimit;
        public int nMonOneDropGoldCount;

        /// <summary>
        /// 挖矿命中率(500)
        /// </summary>
        public ushort nMakeMineHitRate;

        /// <summary>
        /// 挖矿机率(500)
        /// </summary>
        public ushort nMakeMineRate;

        /// <summary>
        /// 矿石因子(500)
        /// </summary>
        public ushort nStoneTypeRate;

        public ushort nStoneTypeRateMin;
        public ushort nGoldStoneMin;

        /// <summary>
        /// 金矿率(500)
        /// </summary>
        public ushort nGoldStoneMax;

        public ushort nSilverStoneMin;

        /// <summary>
        /// 银矿率(500)
        /// </summary>
        public ushort nSilverStoneMax;

        public ushort nSteelStoneMin;

        /// <summary>
        /// 铁矿率(500)
        /// </summary>
        public ushort nSteelStoneMax;

        public ushort nBlackStoneMin;

        /// <summary>
        /// 黑铁矿率(500)
        /// </summary>
        public ushort nBlackStoneMax;

        /// <summary>
        /// 矿石最小品质(1000)
        /// </summary>
        public ushort nStoneMinDura;

        /// <summary>
        /// 普通品质范围(1000)
        /// </summary>
        public ushort nStoneGeneralDuraRate;

        /// <summary>
        /// 高品质机率(1000)
        /// </summary>
        public ushort nStoneAddDuraRate;

        /// <summary>
        /// 高品质范围(1000)
        /// </summary>
        public ushort nStoneAddDuraMax;

        public int nWinLottery6Min;
        public int nWinLottery6Max;
        public int nWinLottery5Min;
        public int nWinLottery5Max;
        public int nWinLottery4Min;
        public int nWinLottery4Max;
        public int nWinLottery3Min;
        public int nWinLottery3Max;
        public int nWinLottery2Min;
        public int nWinLottery2Max;
        public int nWinLottery1Min;
        public int nWinLottery1Max;
        public int nWinLottery1Gold;
        public int nWinLottery2Gold;
        public int nWinLottery3Gold;
        public int nWinLottery4Gold;
        public int nWinLottery5Gold;
        public int nWinLottery6Gold;
        public int nWinLotteryRate;
        public int nWinLotteryCount;
        public int nNoWinLotteryCount;
        public int nWinLotteryLevel1;
        public int nWinLotteryLevel2;
        public int nWinLotteryLevel3;
        public int nWinLotteryLevel4;
        public int nWinLotteryLevel5;
        public int nWinLotteryLevel6;

        /// <summary>
        /// G 变量可保存
        /// </summary>
        public int[] GlobalVal;

        /// <summary>
        /// 不可保存的变量
        /// </summary>
        public int[] GlobaDyMval;

        /// <summary>
        /// A 变量可保存
        /// </summary>
        public string[] GlobalAVal;

        /// <summary>
        /// 制造物品最后一个的制造ID号
        /// </summary>
        public int nItemNumber;

        public int nItemNumberEx;

        /// <summary>
        /// 传行传送间隔
        /// </summary>
        public ushort nGuildRecallTime;

        public ushort nGroupRecallTime;
        public bool boControlDropItem;
        public bool boInSafeDisableDrop;
        public int nCanDropGold;
        public int nCanDropPrice;
        public bool boSendCustemMsg;
        public bool boSubkMasterSendMsg;

        /// <summary>
        /// 特修价格倍数(100)
        /// </summary>
        public byte nSuperRepairPriceRate;

        /// <summary>
        /// 普通修理掉持久数(持久上限减下限再除以此数为减的数值)(100)
        /// </summary>
        public byte nRepairItemDecDura;

        public bool boDieScatterBag;
        public ushort nDieScatterBagRate;
        public bool boDieRedScatterBagAll;
        public ushort nDieDropUseItemRate;
        public byte nDieRedDropUseItemRate;
        public bool boDieDropGold;
        public bool boKillByHumanDropUseItem;
        public bool boKillByMonstDropUseItem;
        public bool boKickExpireHuman;
        public ushort nGuildRankNameLen;

        /// <summary>
        /// 行会成员上限
        /// </summary>
        public ushort nGuildMemberMaxLimit;

        public ushort nGuildNameLen;

        /// <summary>
        /// 麻痹成功机率(100)
        /// </summary>
        public byte nAttackPosionRate;

        /// <summary>
        /// 麻痹时间(100)
        /// </summary>
        public byte nAttackPosionTime;

        /// <summary>
        /// 复活间隔时间
        /// </summary>
        public uint dwRevivalTime;

        public bool boUserMoveCanDupObj;
        public bool boUserMoveCanOnItem;

        /// <summary>
        /// 传送使用间隔(100)
        /// </summary>
        public byte dwUserMoveTime;

        public uint dwPKDieLostExpRate;
        public int nPKDieLostLevelRate;

        /// <summary>
        /// 挑战时间
        /// </summary>
        public ushort nChallengeTime;

        /// <summary>
        /// NPC名字颜色
        /// </summary>
        public byte btNPCNameColor;

        public byte btPKFlagNameColor;

        /// <summary>
        /// 红名状态 名字的颜色
        /// </summary>
        public byte btPKLevel1NameColor;

        public byte btPKLevel2NameColor;
        public byte btAllyAndGuildNameColor;
        public byte btWarGuildNameColor;
        public byte btInFreePKAreaNameColor;
        public bool boSpiritMutiny;

        /// <summary>
        /// 祈祷生效时长
        /// </summary>
        public uint dwSpiritMutinyTime;

        public bool boMasterDieMutiny;
        public ushort nMasterDieMutinyRate;
        public ushort nMasterDieMutinyPower;
        public ushort nMasterDieMutinySpeed;
        public bool boBBMonAutoChangeColor;
        public int dwBBMonAutoChangeColorTime;
        public bool boOldClientShowHiLevel;
        public bool boShowScriptActionMsg;
        public bool boThreadRun;
        public bool boShowExceptionMsg;
        public bool boShowPreFixMsg;

        /// <summary>
        /// GM命令错误是否提示
        /// </summary>
        public bool boGMShowFailMsg;

        /// <summary>
        /// 记录人物私聊，行会聊天信息
        /// </summary>
        public bool boRecordClientMsg;

        /// <summary>
        /// 魔法攻击有效距离(20)
        /// </summary>
        public byte nMagicAttackRage;

        public string sBoneFamm;

        /// <summary>
        /// 召唤骷髅数量(255)
        /// </summary>
        public byte nBoneFammCount;

        /// <summary>
        /// 神兽名称
        /// </summary>
        public string sDogz;

        /// <summary>
        /// 召唤神兽数量(255)
        /// </summary>
        public byte nDogzCount;

        /// <summary>
        /// 月灵名称
        /// </summary>
        public string sFairy;

        /// <summary>
        /// 月灵数量(255)
        /// </summary>
        public byte nFairyCount;

        /// <summary>
        /// 圣兽名称
        /// </summary>
        public string SacRed;

        /// <summary>
        /// 圣兽数量(255)
        /// </summary>
        public byte SacredCount;

        /// <summary>
        /// 月灵重击几率(100),等级高于目标的几率
        /// </summary>
        public byte nFairyDuntRate;

        /// <summary>
        /// 月灵重击次数,达到次数时按等级出重击
        /// </summary>
        public byte nFairyDuntRateBelow;

        /// <summary>
        /// 月灵重击倍数(10)
        /// </summary>
        public ushort nFairyAttackRate;

        /// <summary>
        /// 开天斩重击几率(100)
        /// </summary>
        public byte n43KillHitRate;

        /// <summary>
        /// 开天斩重击倍数(10)
        /// </summary>
        public byte n43KillAttackRate;

        /// <summary>
        /// 开天斩威力(10000)
        /// </summary>
        public ushort nAttackRate_43;

        /// <summary>
        /// 烈火剑法威力倍数
        /// </summary>
        public ushort nAttackRate_26;

        /// <summary>
        /// 逐日剑法威力倍数
        /// </summary>
        public ushort nAttackRate_74;

        /// <summary>
        /// 施毒术中毒减的点数
        /// </summary>
        public byte nAmyOunsulPoint;

        /// <summary>
        /// 禁止安全区使用火墙
        /// </summary>
        public bool boDisableInSafeZoneFireCross;

        /// <summary>
        /// 狮子吼是否对人物有效
        /// </summary>
        public bool boGroupMbAttackPlayObject;

        public uint dwPosionDecHealthTime;

        /// <summary>
        /// 中红毒着持久及减防量（实际大小为 12 / 10）
        /// </summary>
        public ushort nPosionDamagarmor;

        /// <summary>
        /// 禁止无限刺杀
        /// </summary>
        public bool boLimitSwordLong;

        /// <summary>
        /// 刺杀攻击力倍数
        /// </summary>
        public ushort nSwordLongPowerRate;

        /// <summary>
        /// 爆裂火焰攻击范围
        /// </summary>
        public byte nFireBoomRage;

        /// <summary>
        /// 冰咆哮攻击范围
        /// </summary>
        public byte nSnowWindRange;

        /// <summary>
        /// 流星火雨攻击范围
        /// </summary>
        public byte nMeteorFireRainRage;

        /// <summary>
        /// 噬血术加血百分率
        /// </summary>
        public byte nMagFireCharmTreatment;

        /// <summary>
        /// 英雄名字颜色
        /// </summary>
        public byte nHeroNameColor;

        /// <summary>
        /// 英雄名字
        /// </summary>
        public string sHeroName;

        /// <summary>
        /// 英雄名后缀
        /// </summary>
        public string sHeroNameSuffix;

        /// <summary>
        /// 是否显示后缀
        /// </summary>
        public bool boNameSuffix;

        /// <summary>
        /// 禁止安全区守护
        /// </summary>
        public bool boNoSafeProtect;

        /// <summary>
        /// 道法22前是否物理攻击
        /// </summary>
        public bool boHeroAttackTarget;

        /// <summary>
        /// 道22后是否物理攻击
        /// </summary>
        public bool boHeroAttackTao;

        /// <summary>
        /// 英雄休息不跟随主人切换地图
        /// </summary>
        public bool boRestNoFollow;

        /// <summary>
        /// 地狱雷光攻击范围
        /// </summary>
        public byte nElecBlizzardRange;

        /// <summary>
        /// 破魂斩 攻击范围
        /// </summary>
        public byte nHeroAttackRange_60;

        /// <summary>
        /// 噬魂沼泽 攻击范围
        /// </summary>
        public byte nHeroAttackRange_63;

        /// <summary>
        /// 末日审判 攻击范围
        /// </summary>
        public byte nHeroAttackRange_64;

        /// <summary>
        /// 火龙气焰 攻击范围
        /// </summary>
        public byte nHeroAttackRange_65;

        /// <summary>
        /// 圣言怪物等级限制
        /// </summary>
        public ushort nMagTurnUndeadLevel;

        /// <summary>
        /// 诱惑之光怪物等级限制
        /// </summary>
        public ushort nMagTammingLevel;

        /// <summary>
        /// 诱惑怪物相差等级机率，此数字越小机率越大
        /// </summary>
        public ushort nMagTammingTargetLevel;

        /// <summary>
        /// 成功机率=怪物最高HP 除以 此倍率，此倍率越大诱惑机率越高
        /// </summary>
        public ushort nMagTammingHPRate;

        /// <summary>
        /// 诱惑数量
        /// </summary>
        public ushort nMagTammingCount;

        /// <summary>
        /// 火焰冰角色等级相差机率
        /// </summary>
        public byte nMabMabeHitRandRate;

        /// <summary>
        /// 火焰冰角色等级相差限制
        /// </summary>
        public byte nMabMabeHitMinLvLimit;

        /// <summary>
        /// 麻痹命中机率
        /// </summary>
        public byte nMabMabeHitSucessRate;

        /// <summary>
        /// 麻痹时间参数倍率
        /// </summary>
        public byte nMabMabeHitMabeTimeRate;

        public string sCASTLENAME;
        public string sCastleHomeMap;
        public int nCastleHomeX;
        public int nCastleHomeY;
        public int nCastleWarRangeX;
        public int nCastleWarRangeY;

        /// <summary>
        /// 税收率(1000)
        /// </summary>
        public ushort nCastleTaxRate;

        public bool boGetAllNpcTax;
        public int nHireGuardPrice;
        public int nHireArcherPrice;
        public int nCastleGoldMax;
        public int nCastleOneDayGold;
        public int nRepairDoorPrice;
        public int nRepairWallPrice;

        /// <summary>
        /// 折扣率(200)
        /// </summary>
        public byte nCastleMemberPriceRate;

        public byte nMaxHitMsgCount;
        public byte nMaxSpellMsgCount;
        public byte nMaxRunMsgCount;
        public byte nMaxWalkMsgCount;
        public byte nMaxTurnMsgCount;
        public byte nMaxSitDonwMsgCount;
        public byte nMaxDigUpMsgCount;
        public bool boSpellSendUpdateMsg;
        public bool boActionSendActionMsg;
        public bool boKickOverSpeed;
        public byte btSpeedControlMode;
        public byte nOverSpeedKickCount;
        public uint dwDropOverSpeed;

        /// <summary>
        /// 攻击间隔
        /// </summary>
        public uint dwHitIntervalTime;

        /// <summary>
        /// 魔法间隔
        /// </summary>
        public uint dwMagicHitIntervalTime;

        /// <summary>
        /// 跑步间隔
        /// </summary>
        public uint dwRunIntervalTime;

        /// <summary>
        /// 走路间隔
        /// </summary>
        public uint dwWalkIntervalTime;

        /// <summary>
        /// 换方向间隔
        /// </summary>
        public uint dwTurnIntervalTime;

        /// <summary>
        /// 启用组合操作控制
        /// </summary>
        public bool boControlActionInterval;

        public bool boControlWalkHit;
        public bool boControlRunLongHit;
        public bool boControlRunHit;
        public bool boControlRunMagic;

        /// <summary>
        /// 组合操作间隔
        /// </summary>
        public uint dwActionIntervalTime;

        /// <summary>
        /// 跑位刺杀间隔
        /// </summary>
        public uint dwRunLongHitIntervalTime;

        /// <summary>
        /// 跑位攻击间隔
        /// </summary>
        public uint dwRunHitIntervalTime;

        /// <summary>
        /// 走位攻击间隔
        /// </summary>
        public uint dwWalkHitIntervalTime;

        /// <summary>
        /// 跑位魔法间隔
        /// </summary>
        public uint dwRunMagicIntervalTime;

        /// <summary>
        /// 不显示人物弯腰动作
        /// </summary>
        public bool boDisableStruck;

        /// <summary>
        /// 自己不显示人物弯腰动作
        /// </summary>
        public bool boDisableSelfStruck;

        /// <summary>
        /// 人物弯腰停留时间
        /// </summary>
        public uint dwStruckTime;

        /// <summary>
        /// 杀怪经验倍数
        /// </summary>
        public ushort dwKillMonExpMultiple;

        /// <summary>
        /// 杀怪内功经验倍数
        /// </summary>
        public ushort dwKillMonNGExpMultiple;

        /// <summary>
        /// 内功技能增强的攻防比率
        /// </summary>
        public ushort nNGSkillRate;

        /// <summary>
        /// 内功等级增加攻防的级数比率
        /// </summary>
        public byte nNGLevelDamage;

        public uint dwRequestVersion;
        public bool boHighLevelKillMonFixExp;

        /// <summary>
        /// 物品增加新属性
        /// </summary>
        public bool boAddUserItemNewValue;

        public string sLineNoticePreFix;
        public string sSysMsgPreFix;
        public string sGuildMsgPreFix;
        public string sGroupMsgPreFix;
        public string sHintMsgPreFix;
        public string sGMRedMsgpreFix;
        public string sMonSayMsgpreFix;
        public string sCustMsgpreFix;
        public string sCastleMsgpreFix;
        public string sGuildNotice;
        public string sGuildWar;
        public string sGuildAll;
        public string sGuildMember;
        public string sGuildMemberRank;
        public string sGuildChief;
        public bool boKickAllUser;
        public bool boTestSpeedMode;

        /// <summary>
        /// // 客户端配置信息
        /// </summary>
        public TClientConf ClientConf;

        /// <summary>
        /// 祝福油诅咒机率(500)
        /// </summary>
        public UInt16 nWeaponMakeUnLuckRate;

        /// <summary>
        /// 祝福油武器一级点数(500)
        /// </summary>
        public UInt16 nWeaponMakeLuckPoint1;

        /// <summary>
        /// 祝福油武器二级点数(500)
        /// </summary>
        public UInt16 nWeaponMakeLuckPoint2;

        /// <summary>
        /// 祝福油武器三级点数(500)
        /// </summary>
        public UInt16 nWeaponMakeLuckPoint3;

        /// <summary>
        /// 祝福油武器二级机率(500)
        /// </summary>
        public UInt16 nWeaponMakeLuckPoint2Rate;

        /// <summary>
        /// 祝福油武器三级机率(500)
        /// </summary>
        public UInt16 nWeaponMakeLuckPoint3Rate;

        public bool boCheckUserItemPlace;
        public int nClientKey;
        public UInt16 nLevelValueOfTaosHP;
        public double nLevelValueOfTaosHPRate;
        public UInt16 nLevelValueOfTaosMP;
        public UInt16 nLevelValueOfWizardHP;
        public double nLevelValueOfWizardHPRate;
        public UInt16 nLevelValueOfWarrHP;
        public double nLevelValueOfWarrHPRate;
        public sbyte nProcessMonsterInterval;

        /// <summary>
        /// 召唤骷髅
        /// </summary>
        public TRecallMigic[] BoneFammArray;

        /// <summary>
        /// 召唤神兽
        /// </summary>
        public TRecallMigic[] DogzArray;

        /// <summary>
        /// 召唤月灵
        /// </summary>
        public TRecallMigic[] FairyArray;

        /// <summary>
        /// 召唤圣兽
        /// </summary>
        public TRecallMigic[] SacredArray;

        public bool boIDSocketConnected;
        public object UserIDSection;
        public string sIDSocketRecvText;
        public int nIDSocketRecvIncLen;
        public int nIDSocketRecvMaxLen;
        public int nIDSocketRecvCount;
        public int nIDReceiveMaxTime;
        public int nIDSocketWSAErrCode;
        public int nIDSocketErrorCount;
        public int nLoadDBCount;
        public int nLoadDBErrorCount;
        public int nSaveDBCount;
        public int nDBQueryID;
        public bool boDBSocketConnected;
        public int nDBSocketRecvIncLen;
        public int nDBSocketRecvMaxLen;

        /// <summary>
        /// 保存DBSERVER发送过来的数据
        /// </summary>
        public string sDBSocketRecvText;

        public bool boDBSocketWorking;
        public int nDBSocketRecvCount;
        public int nDBReceiveMaxTime;
        public int nDBSocketWSAErrCode;
        public int nDBSocketErrorCount;
        public int nServerFile_CRCA;
        public int nClientFile1_CRC;

        /// <summary>
        /// 每次扣多少元宝(元宝寄售)
        /// </summary>
        public ushort nDecUserGameGold;

        /// <summary>
        /// 酿普通酒等待时间
        /// </summary>
        public int nMakeWineTime;

        /// <summary>
        /// 酿药酒等待时间
        /// </summary>
        public int nMakeWineTime1;

        /// <summary>
        /// 酿酒获得酒曲机率
        /// </summary>
        public byte nMakeWineRate;

        /// <summary>
        /// 增加酒量进度的间隔时间
        /// </summary>
        public int nIncAlcoholTick;

        /// <summary>
        /// 减少醉酒度的间隔时间
        /// </summary>
        public int nDesDrinkTick;

        /// <summary>
        /// 酒量上限初始值
        /// </summary>
        public ushort nMaxAlcoholValue;

        /// <summary>
        /// 升级后增加酒量上限值
        /// </summary>
        public ushort nIncAlcoholValue;

        /// <summary>
        /// 长时间不使用酒,减药力值
        /// </summary>
        public ushort nDesMedicineValue;

        /// <summary>
        /// 减药力值时间间隔
        /// </summary>
        public UInt16 nDesMedicineTick;

        /// <summary>
        /// 站在泉眼上的累积时间
        /// </summary>
        public ushort nInFountainTime;

        /// <summary>
        /// 行会酒泉蓄量少于时,不能领取
        /// </summary>
        public ushort nMinGuildFountain;

        /// <summary>
        /// 行会成员领取酒泉,蓄量减少
        /// </summary>
        public ushort nDecGuildFountain;

        /// <summary>
        /// 天地结晶英雄分配比例
        /// </summary>
        public byte nHeroCrystalExpRate;

        public bool boPullPlayObject;

        /// <summary>
        /// 打中目标，目标是否掉蓝
        /// </summary>
        public bool boPlayObjectReduceMP;

        public bool boGroupMbAttackSlave;

        /// <summary>
        /// 无限仓库物品上限
        /// </summary>
        public ushort nBigStorageLimitCount;

        /// <summary>
        /// 金币入包
        /// </summary>
        public bool boDropGoldToPlayBag;

        public bool boChangeUseItemNameByPlayName;
        public string sChangeUseItemName;

        /// <summary>
        /// 达到1000后是否使用引擎经验
        /// </summary>
        public bool boUseFixExp;

        //
        public int nBaseExp;

        public int nAddExp;

        /// <summary>
        /// 开天斩使用间隔(100)
        /// </summary>
        public byte nKill43UseTime;

        /// <summary>
        /// 彻地钉使用间隔(100)
        /// </summary>
        public byte nDedingUseTime;

        /// <summary>
        /// 无极真气使用间隔
        /// </summary>
        public byte nAbilityUpTick;

        /// <summary>
        /// 无极真气使用时长模式
        /// </summary>
        public bool boAbilityUpFixMode;

        /// <summary>
        /// 无极真气使用固定时长
        /// </summary>
        public byte nAbilityUpFixUseTime;

        /// <summary>
        /// 无极真气使用时长
        /// </summary>
        public byte nAbilityUpUseTime;

        /// <summary>
        /// 先天元力失效酒量下限比例
        /// </summary>
        public byte nMinDrinkValue67;

        /// <summary>
        /// 酒气护体失效酒量下限比例
        /// </summary>
        public byte nMinDrinkValue68;

        /// <summary>
        /// 酒气护体使用间隔
        /// </summary>
        public byte nHPUpTick;

        /// <summary>
        /// 酒气护体增加使用时长
        /// </summary>
        public byte nHPUpUseTime;

        public bool boDedingAllowPK;
        public bool boRegenMonsters;

        /// <summary>
        /// 分身使用时长
        /// </summary>
        public int nMakeSelfTick;

        /// <summary>
        /// 召唤分身的间隔
        /// </summary>
        public int nCopyHumanTick;

        /// <summary>
        /// 分身名字颜色
        /// </summary>
        public int nCopyHumanBagCount;

        public byte nCopyHumNameColor;
        public int nAllowCopyHumanCount;
        public bool boAddMasterName;
        public string sCopyHumName;

        /// <summary>
        /// 分身HP达到百分率开始吃药(100)
        /// </summary>
        public byte nCopyHumAddHPRate;

        /// <summary>
        /// 分身MP达到百分率开始吃药(100)
        /// </summary>
        public byte nCopyHumAddMPRate;

        public string sCopyHumBagItems1;
        public string sCopyHumBagItems2;
        public string sCopyHumBagItems3;
        public bool boAllowGuardAttack;
        public uint dwWarrorAttackTime;
        public uint dwWizardAttackTime;
        public uint dwTaoistAttackTime;
        public bool boAllowReCallMobOtherHum;
        public bool boNeedLevelHighTarget;

        /// <summary>
        /// 等待DBS返回消息的时间
        /// </summary>
        public uint dwGetDBSockMsgTime;

        public bool boPullCrossInSafeZone;
        public bool boHighLevelGroupFixExp;

        /// <summary>
        /// 是否开启地图事件
        /// </summary>
        public bool boStartMapEvent;

        /// <summary>
        /// 斗笠可带选项
        /// </summary>
        public sbyte nIsUseZhuLi;

        /// <summary>
        /// 带上斗笠是否显示神秘人
        /// </summary>
        public bool boUnKnowHum;

        /// <summary>
        /// 是否保存双倍经验时间
        /// </summary>
        public bool boSaveExpRate;

        /// <summary>
        /// 限制等级
        /// </summary>
        public ushort nLimitExpLevel;

        public UInt32 nLimitExpValue;
        public bool boChangeMapFireExtinguish;

        /// <summary>
        /// 火墙有效时间倍数
        /// </summary>
        public ushort nFireDelayTimeRate;

        /// <summary>
        /// 火墙威力倍数
        /// </summary>
        public ushort nFirePowerRate;

        /// <summary>
        /// 彻地钉威力倍数(10000)
        /// </summary>
        public ushort nDidingPowerRate;

        /// <summary>
        /// 卧龙英雄开始等级
        /// </summary>
        public ushort nHeroStartLevel;

        public ushort nDrinkHeroStartLevel;

        /// <summary>
        /// 英雄杀怪经验比例
        /// </summary>
        public byte nHeroKillMonExpRate;

        /// <summary>
        /// 非杀怪分配经验比例
        /// </summary>
        public byte nHeroNoKillMonExpRate;

        /// <summary>
        /// 修改英雄包裹数
        /// </summary>
        public ushort[] nHeroBagItemCount;

        /// <summary>
        /// 战士英雄的攻击速度
        /// </summary>
        public uint dwHeroWarrorAttackTime;

        /// <summary>
        /// 法师英雄的攻击速度
        /// </summary>
        public uint dwHeroWizardAttackTime;

        /// <summary>
        /// 道士英雄的攻击速度
        /// </summary>
        public uint dwHeroTaoistAttackTime;

        public bool boHeroKillByMonstDropUseItem;
        public bool boHeroKillByHumanDropUseItem;
        public bool boHeroDieScatterBag;

        /// <summary>
        /// 英雄无目标下自动开启护体神盾
        /// </summary>
        public bool boHeroAutoProtectionDefence;

        /// <summary>
        /// 英雄无目标下可召唤宝宝
        /// </summary>
        public bool boHeroNoTargetCall;

        /// <summary>
        /// 英雄死亡掉经验
        /// </summary>
        public bool boHeroDieExp;

        /// <summary>
        /// 英雄死亡掉经验比率
        /// </summary>
        public byte nHeroDieExpRate;

        public bool boHeroDieRedScatterBagAll;
        public ushort nHeroDieDropUseItemRate;
        public byte nHeroDieRedDropUseItemRate;
        public ushort nHeroDieScatterBagRate;
        public byte nHeroAddHPRate;
        public byte nHeroAddMPRate;

        /// <summary>
        /// 吃普通药速度
        /// </summary>
        public uint nHeroAddHPMPTick;

        public byte nHeroAddHPRate1;
        public byte nHeroAddMPRate1;

        /// <summary>
        /// 吃特殊药速度
        /// </summary>
        public uint nHeroAddHPMPTick1;

        /// <summary>
        /// 龙影剑法使用间隔(100)
        /// </summary>
        public byte nKill42UseTime;

        /// <summary>
        /// 龙影剑法威力
        /// </summary>
        public ushort nAttackRate_42;

        /// <summary>
        /// 龙影剑法范围
        /// </summary>
        public byte nMagicAttackRage_42;

        /// <summary>
        /// 怒气槽最大值
        /// </summary>
        public ushort nMaxFirDragonPoint;

        /// <summary>
        /// 每次加怒气值
        /// </summary>
        public ushort nAddFirDragonPoint;

        /// <summary>
        /// 每次减怒气值
        /// </summary>
        public ushort nDecFirDragonPoint;

        /// <summary>
        /// 加怒气时间间隔
        /// </summary>
        public uint nIncDragonPointTick;

        /// <summary>
        /// 0级 英雄召唤分身HP的比率
        /// </summary>
        public byte nHeroSkill46MaxHP_0;

        /// <summary>
        /// 1级 英雄召唤分身HP的比率
        /// </summary>
        public byte nHeroSkill46MaxHP_1;

        /// <summary>
        /// 2级 英雄召唤分身HP的比率
        /// </summary>
        public byte nHeroSkill46MaxHP_2;

        /// <summary>
        /// 3级 英雄召唤分身HP的比率
        /// </summary>
        public byte nHeroSkill46MaxHP_3;

        /// <summary>
        /// 英雄分身延长使用时间
        /// </summary>
        public ushort nHeroMakeSelfTick;

        /// <summary>
        /// 饮酒减少合击伤害
        /// </summary>
        public byte nDecDragonHitPoint;

        /// <summary>
        /// 合击对人物的伤害比例
        /// </summary>
        public byte nDecDragonRate;

        /// <summary>
        /// 破魂斩威力
        /// </summary>
        public ushort nHeroAttackRate_60;

        /// <summary>
        /// 劈星斩威力
        /// </summary>
        public ushort nHeroAttackRate_61;

        /// <summary>
        /// 雷霆一击威力
        /// </summary>
        public ushort nHeroAttackRate_62;

        /// <summary>
        /// 噬魂沼泽威力
        /// </summary>
        public ushort nHeroAttackRate_63;

        /// <summary>
        /// 末日审判威力
        /// </summary>
        public ushort nHeroAttackRate_64;

        /// <summary>
        /// 火龙气焰威力
        /// </summary>
        public ushort nHeroAttackRate_65;

        /// <summary>
        /// 噬魂沼泽使用绿毒模式
        /// </summary>
        public bool btHeroSkillMode_63;

        /// <summary>
        /// 英雄尸体清理时间
        /// </summary>
        public uint nMakeGhostHeroTime;

        /// <summary>
        /// 召唤英雄间隔
        /// </summary>
        public uint nRecallHeroTime;

        public string sHeroClothsMan;
        public string sHeroClothsWoman;
        public string sHeroWoodenSword;
        public string sHeroBasicDrug;

        /// <summary>
        /// 移行换位使用间隔
        /// </summary>
        public uint dwMagChangXYTick;

        /// <summary>
        /// 护体神盾最长时间
        /// </summary>
        public uint nProtectionDefenceTime;

        /// <summary>
        /// 护体神盾使用间隔
        /// </summary>
        public uint dwProtectionTick;

        /// <summary>
        /// 护体神盾减攻击百分比
        /// </summary>
        public byte nProtectionRate;

        /// <summary>
        /// 护体神盾生效机率
        /// </summary>
        public byte nProtectionOKRate;

        /// <summary>
        /// 护体神盾被击破机率
        /// </summary>
        public byte nProtectionBadRate;

        /// <summary>
        /// 刺杀必破护体神盾
        /// </summary>
        public bool RushkungBadProtection;

        /// <summary>
        /// (破魂斩)合击必破护体神盾
        /// </summary>
        public bool ErgumBadProtection;

        /// <summary>
        /// 烈火必破护体神盾
        /// </summary>
        public bool FirehitBadProtection;

        /// <summary>
        /// 开天必破护体神盾
        /// </summary>
        public bool TwnhitBadProtection;

        /// <summary>
        /// 显示护体神盾效果
        /// </summary>
        public bool boShowProtectionEnv;

        /// <summary>
        /// 自动使用神盾
        /// </summary>
        public bool boAutoProtection;

        /// <summary>
        /// 火符智能锁定
        /// </summary>
        public bool boAutoCanHit;

        /// <summary>
        /// 宝宝是否飞到主人身边
        /// </summary>
        public bool boSlaveMoveMaster;

        /// <summary>
        /// 英雄HP为人物的倍数
        /// </summary>
        public ushort nHeroHPRate;

        /// <summary>
        /// 死亡减少忠诚度
        /// </summary>
        public ushort nDeathDecLoyal;

        /// <summary>
        /// PK值减少忠诚度
        /// </summary>
        public ushort nPKDecLoyal;

        /// <summary>
        /// 行会战增加忠诚度
        /// </summary>
        public ushort nGuildIncLoyal;

        /// <summary>
        /// 人物等级排名上升增加忠诚度
        /// </summary>
        public ushort nLevelOrderIncLoyal;

        /// <summary>
        /// 人物等级排名下降减少忠诚度
        /// </summary>
        public ushort nLevelOrderDecLoyal;

        /// <summary>
        /// 获得经验->忠诚度
        /// </summary>
        public int nWinExp;

        /// <summary>
        /// 经验加忠诚
        /// </summary>
        public ushort nExpAddLoyal;

        /// <summary>
        /// 四级触发
        /// </summary>
        public ushort nGotoLV4;

        /// <summary>
        /// 四级技能杀伤力增加值
        /// </summary>
        public byte nPowerLV4;

        /// <summary>
        /// 法英雄跑步间隔
        /// </summary>
        public uint dwHeroRunIntervalTime1;

        /// <summary>
        /// 道英雄跑步间隔
        /// </summary>
        public uint dwHeroRunIntervalTime2;

        /// <summary>
        /// 英雄走路间隔
        /// </summary>
        public uint dwHeroWalkIntervalTime;

        /// <summary>
        /// 英雄转向间隔
        /// </summary>
        public uint dwHeroTurnIntervalTime;

        /// <summary>
        /// 英雄魔法间隔
        /// </summary>
        public uint dwHeroMagicHitIntervalTime;

        /// <summary>
        /// 英雄施毒术使用模式
        /// </summary>
        public bool btHeroSkillMode;

        /// <summary>
        /// 英雄无极真气使用模式
        /// </summary>
        public bool btHeroSkillMode50;

        /// <summary>
        /// 英雄分身术模式
        /// </summary>
        public bool btHeroSkillMode46;

        /// <summary>
        /// 英雄开天斩重击模式
        /// </summary>
        public bool btHeroSkillMode43;

        // -----------------气血石相关配置----------------------------
        public ushort nStartHPRock;

        public byte nRockAddHP;
        public uint nHPRockSpell;
        public int nHPRockDecDura;
        public ushort nStartMPRock;
        public byte nRockAddMP;
        public uint nMPRockSpell;
        public int nMPRockDecDura;
        public ushort nStartHPMPRock;
        public byte nRockAddHPMP;
        public uint nHPMPRockSpell;
        public int nHPMPRockDecDura;

        /// <summary>
        /// 开启兑换灵符功能
        /// </summary>
        public bool g_boGameGird;

        /// <summary>
        /// 兑换灵符,元宝数量
        /// </summary>
        public int g_nGameGold;

        // ----连击配置相关变量-----//
        public ushort PulsePointNGLevel0;

        public ushort PulsePointNGLevel1;
        public ushort PulsePointNGLevel2;
        public ushort PulsePointNGLevel3;
        public ushort PulsePointNGLevel4;
        public ushort PulsePointNGLevel5;
        public ushort PulsePointNGLevel6;
        public ushort PulsePointNGLevel7;
        public ushort PulsePointNGLevel8;
        public ushort PulsePointNGLevel9;
        public ushort PulsePointNGLevel10;
        public ushort PulsePointNGLevel11;
        public ushort PulsePointNGLevel12;
        public ushort PulsePointNGLevel13;
        public ushort PulsePointNGLevel14;
        public ushort PulsePointNGLevel15;
        public ushort PulsePointNGLevel16;
        public ushort PulsePointNGLevel17;
        public ushort PulsePointNGLevel18;
        public ushort PulsePointNGLevel19;

        /// <summary>
        /// 断岳斩 攻击范围
        /// </summary>
        public ushort BatterSkillFireRange_82;

        /// <summary>
        /// 横扫千军 攻击范围
        /// </summary>
        public ushort BatterSkillFireRange_85;

        /// <summary>
        /// 冰天雪地 攻击范围
        /// </summary>
        public ushort BatterSkillFireRange_86;

        /// <summary>
        /// 万剑归宗 攻击范围
        /// </summary>
        public ushort BatterSkillFireRange_87;

        /// <summary>
        ///  冰天雪地  持续掉血
        /// </summary>
        public ushort BatterSkillPoinson_86;

        /// <summary>
        /// 万剑归宗  持续掉血
        /// </summary>
        public ushort BatterSkillPoinson_87;

        /// <summary>
        /// 暴击伤害倍率
        /// </summary>
        public int StormsHitRate1;

        public int StormsHitRate2;
        public int StormsHitRate3;
        public int StormsHitRate4;
        public int StormsHitRate5;
        public int StormsHitAppearRate0;

        /// <summary>
        /// 暴击几率
        /// </summary>
        public int StormsHitAppearRate1;

        public int StormsHitAppearRate2;
        public int StormsHitAppearRate3;
        public int StormsHitAppearRate4;
        public int UseBatterTick;
        public int Magic69UseTime;

        /// <summary>
        /// 血魄一击使用间隔
        /// </summary>
        public int magic96usetime;

        /// <summary>
        /// 设置是毫秒的 /1000
        /// </summary>
        public int RecallDeputyHeroTime;

        /// <summary>
        /// 副将英雄经验倍数
        /// </summary>
        public int DeputyHeroExpRate;

        public int Strength1DecGold;
        public int Strength1DecGameGird;
        public int Strength1Exp;
        public int Strength2DecGold;
        public int Strength2DecGameGird;
        public int Strength2Exp;
        public int Strength3DecGold;
        public int Strength3DecGameGird;
        public int Strength3Exp;

        public TGameConfig()
        {
            sServerName = "HZHQ引擎";
            sServerIPaddr = "127.0.0.1";
            sRegServerAddr = "127.0.0.1";
            nRegServerPort = 63000;
            sRegKey = "";
            sWebSite = "http=//www.yao4f.com";
            sBbsSite = "http=//m2.yao4f.com";
            sClientDownload = "m2.yao4f.com";
            sQQ = "88888888";
            sPhone = "123456789";
            sConnectionString = "server=124.232.137.58;uid=sa;pwd=%!iSoft.So!;database=Mir2;";
            sBankAccount0 = "银行信息";
            sBankAccount1 = "银行信息";
            sBankAccount2 = "银行信息";
            sBankAccount3 = "银行信息";
            sBankAccount4 = "银行信息";
            sBankAccount5 = "银行信息";
            sBankAccount6 = "银行信息";
            sBankAccount7 = "银行信息";
            sBankAccount8 = "银行信息";
            sBankAccount9 = "银行信息";
            nServerNumber = 0;
            boVentureServer = false;
            boTestServer = true;
            boServiceMode = false;
            boNonPKServer = false;
            nTestLevel = 1;
            nTestGold = 0;
            nTestUserLimit = 1000;
            nSendBlock = 1024;
            nCheckBlock = 9500;
            nAvailableBlock = 8000;
            nGateLoad = 0;
            nUserFull = 1000;
            nZenFastStep = 300;
            sGateAddr = "127.0.0.1";
            nGatePort = 5000;
            sDBAddr = "127.0.0.1";
            nDBPort = 6000;
            sIDSAddr = "127.0.0.1";
            nIDSPort = 5600;
            sMsgSrvAddr = "127.0.0.1";
            nMsgSrvPort = 4900;
            sLogServerAddr = "127.0.0.1";
            nLogServerPort = 10000;
            boDiscountForNightTime = false;
            nHalfFeeStart = 2;
            nHalfFeeEnd = 10;
            boViewHackMessage = false;
            boViewAdmissionFailure = false;
            sBaseDir = @".\BaseDir\";
            sGuildDir = @".\GuildDir\List\";
            sGuildFile = @".\GuildDir\List.txt";
            sVentureDir = @".\VentureDir\";
            sConLogDir = @".\ConLog\";
            sCastleDir = @".\Castle\";
            sCastleFile = @".\Castle\List.txt";
            sSortDir = @".\Sort\";//排行榜路径
            sBoxsDir = @".\Envir\Boxs\"; //宝箱路径
            sBoxsFile = @".\Envir\Boxs\BoxsList.txt ";//宝箱文件
            sEnvirDir = @".\Envir\";
            sMapDir = @".\Map\";
            sNoticeDir = @".\Notice\";
            sLogDir = @".\Log\";
            sPlugDir = @".\";
            sClientFile1 = "mir.dat";//  客户端文件名
            sClothsMan = "布衣(男)";
            sClothsWoman = "布衣(女)";
            sWoodenSword = "木剑";
            sCandle = "蜡烛";
            sBasicDrug = "金创药(小量)";
            sGoldStone = "金矿";
            sSilverStone = "银矿";
            sSteelStone = "铁矿";
            sCopperStone = "铜矿";
            sBlackStone = "黑铁矿石";
            sZuma = new string[] { "祖玛卫士", "祖玛雕像", "祖玛弓箭手", "楔蛾" };
            sBee = "小角蝇";
            sSpider = "小蜘蛛";
            sWomaHorn = "沃玛号角";
            sZumaPiece = "祖玛头像";
            sGameGoldName = "元宝";
            sGameDiaMond = "金刚石";// 金刚石
            sGameGird = "灵符";// 灵符
            sGameGlory = "荣誉"; // 荣誉
            sGamePointName = "游戏点";
            sPayMentPointName = "秒卡点";
            DBSocket = 0;
            nHealthFillTime = 300;
            nSpellFillTime = 800;
            nMonUpLvNeedKillBase = 100;
            nMonUpLvRate = 16;
            MonUpLvNeedKillCount = new ushort[] { 0, 0, 50, 100, 200, 300, 600, 1200 };
            SlaveColor = new byte[] { 0xFF, 0xFE, 0x93, 0x9A, 0xE5, 0xA8, 0xB4, 0xFC, 249 };
            WideAttack = new byte[] { 7, 1, 2 };
            CrsAttack = new byte[] { 7, 1, 2, 3, 5, 6, 4 };//20090115 修正：抱月后面的目标也能打中
            YuanYueAttack = new byte[] { 7, 1, 2, 3, 5, 6, 4, 0 };
            SpitMap = new byte[,,]{
                {{0, 0, 1, 0, 0}, //DR_UP
                {0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}},
                {{0, 0, 0, 0, 1}, //DR_UPRIGHT
                {0, 0, 0, 1, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}},
                {{0, 0, 0, 0, 0}, //DR_RIGHT
                {0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}},
                {{0, 0, 0, 0, 0}, //DR_DOWNRIGHT
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0},
                {0, 0, 0, 0, 1}},
                {{0, 0, 0, 0, 0}, //DR_DOWN
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0}},
                {{0, 0, 0, 0, 0}, //DR_DOWNLEFT
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 1, 0, 0, 0},
                {1, 0, 0, 0, 0}},
                {{0, 0, 0, 0, 0}, //DR_LEFT
                {0, 0, 0, 0, 0},
                {1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}},
                {{1, 0, 0, 0, 0}, //DR_UPLEFT
                {0, 1, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0}}
                };

            sHomeMap = "0";
            nHomeX = 289;
            nHomeY = 618;
            sRedHomeMap = "3";
            nRedHomeX = 845;
            nRedHomeY = 674;
            sRedDieHomeMap = "3";
            nRedDieHomeX = 839;
            nRedDieHomeY = 668;
            dwDecPkPointTime = 120000;//2 * 60 * 1000
            nDecPkPointCount = 1;
            dwPKFlagTime = 60000;//60 * 1000
            nKillHumanWeaponUnlockRate = 5;//杀人武器被诅咒机率 20081020
            nKillHumanAddPKPoint = 100;
            nKillHumanDecLuckPoint = 500;
            dwDecLightItemDrugTime = 1000;//照明物使用间隔 20080329
            nSafeZoneSize = 10;
            nStartPointSize = 2;
            dwHumanGetMsgTime = 200;
            nGuildMemberCount = 400;//新建行会成员上限 20090115
            nGroupMembersMax = 10;
            sFireBallSkill = "火球术";
            sHealSkill = "治愈术";
            sHeavenSKill = "倚天辟地";
            sXuepozhanSKill = "血魄一击（战）";
            MeteorSKill = "流星";
            ReNewNameColor = new byte[] { 0xFF, 0xFE, 0x93, 0x9A, 0xE5, 0xA8, 0xB4, 0xFC, 0xB4, 0xFC };
            dwReNewNameColorTime = 2000;
            boReNewChangeColor = true;
            boReNewLevelClearExp = true;
            BonusAbilofWarr = new TNakedAbility { DC = 17, MC = 20, SC = 20, AC = 20, MAC = 20, HP = 1, MP = 3, Hit = 20, Speed = 35, X2 = 0 };
            BonusAbilofWizard = new TNakedAbility { DC = 17, MC = 25, SC = 30, AC = 20, MAC = 15, HP = 2, MP = 1, Hit = 25, Speed = 35, X2 = 0 };
            BonusAbilofTaos = new TNakedAbility { DC = 20, MC = 30, SC = 17, AC = 20, MAC = 15, HP = 2, MP = 1, Hit = 30, Speed = 30, X2 = 0 };
            NakedAbilofWarr = new TNakedAbility { DC = 512, MC = 2560, SC = 20, AC = 768, MAC = 1280, HP = 0, MP = 0, Hit = 0, Speed = 0, X2 = 0 };
            NakedAbilofWizard = new TNakedAbility { DC = 512, MC = 512, SC = 2560, AC = 1280, MAC = 768, HP = 0, MP = 0, Hit = 5, Speed = 0, X2 = 0 };
            NakedAbilofTaos = new TNakedAbility { DC = 20, MC = 30, SC = 17, AC = 20, MAC = 15, HP = 2, MP = 1, Hit = 30, Speed = 30, X2 = 0 };
            nUpgradeWeaponMaxPoint = 20;
            nUpgradeWeaponPrice = 10000;
            dwUPgradeWeaponGetBackTime = 3600000;//60 * 60 * 1000
            nClearExpireUpgradeWeaponDays = 8;
            nUpgradeWeaponDCRate = 100;
            nUpgradeWeaponDCTwoPointRate = 30;
            nUpgradeWeaponDCThreePointRate = 200;
            nUpgradeWeaponSCRate = 100;
            nUpgradeWeaponSCTwoPointRate = 30;
            nUpgradeWeaponSCThreePointRate = 200;
            nUpgradeWeaponMCRate = 100;
            nUpgradeWeaponMCTwoPointRate = 30;
            nUpgradeWeaponMCThreePointRate = 200;
            dwProcessMonstersTime = 10;
            dwRegenMonstersTime = 200;
            nMonGenRate = 10;
            nSoftVersionDate = 20080501;
            boCanOldClientLogon = true;//是否允许普通登录器进入
            dwConsoleShowUserCountTime = 600000;//15 * 60 * 1000
            dwShowLineNoticeTime = 300000;//5 * 60 * 1000
            nLineNoticeColor = 2;
            nStartCastleWarDays = 4;
            nStartCastlewarTime = 20;
            dwShowCastleWarEndMsgTime = 900000;//10 * 60 * 1000
            dwCastleWarTime = 10800000;//3 * 60 * 60 * 1000
            dwGetCastleTime = 600000;//10 * 60 * 1000
            dwGuildWarTime = 10800000;//3 * 60 * 60 * 1000
            nBuildGuildPrice = 1000000;
            nGuildWarPrice = 30000;
            nMakeDurgPrice = 100;
            nHumanMaxGold = 10000000;
            nHumanTryModeMaxGold = 100000;
            nTryModeLevel = 7;
            boTryModeUseStorage = false;
            nCanShoutMsgLevel = 7;
            boShowMakeItemMsg = false;
            boShutRedMsgShowGMName = false;
            nSayMsgMaxLen = 80;
            dwSayMsgTime = 3000;//3 * 1000
            nSayMsgCount = 2;
            dwDisableSayMsgTime = 60000;//60 * 1000
            nSayRedMsgMaxLen = 255;
            boShowGuildName = true;
            boShowRankLevelName = true;
            boMonSayMsg = false;
            nStartPermission = 0;
            boKillHumanWinLevel = false;
            boKilledLostLevel = false;
            boKillHumanWinExp = false;
            boKilledLostExp = false;
            nKillHumanWinLevel = 1;
            nKilledLostLevel = 1;
            nKillHumanWinExp = 100000;
            nKillHumanLostExp = 100000;
            nHumanLevelDiffer = 10;
            nMonsterPowerRate = 10;
            nItemsPowerRate = 10;
            nItemsACPowerRate = 10;
            boSendOnlineCount = true;
            nSendOnlineCountRate = 10;
            dwSendOnlineTime = 300000;//5 * 60 * 1000
            dwSaveHumanRcdTime = 600000;//10 * 60 * 1000
            dwHumanFreeDelayTime = 300000;//5 * 60 * 1000
            dwMakeGhostTime = 180000;//3 * 60 * 1000
            dwMakeGhostPlayMosterTime = 180000;// 3 * 60 * 1000  人形怪尸体清理时间
            dwClearDropOnFloorItemTime = 3600000;//60 * 60 * 1000
            dwFloorItemCanPickUpTime = 120000;//2 * 60 * 1000
            boPasswordLockSystem = false; //是否启用密码保护系统
            boLockDealAction = false; //是否锁定交易操作
            boLockDropAction = false; //是否锁定扔物品操作
            boLockGetBackItemAction = false; //是否锁定取仓库操作
            boLockHumanLogin = false; //是否锁定走操作
            boLockWalkAction = false; //是否锁定走操作
            boLockRunAction = false; //是否锁定跑操作
            boLockHitAction = false; //是否锁定攻击操作
            boLockSpellAction = false; //是否锁定魔法操作
            boLockCallHeroAction = false; //是否锁定召唤英雄操作
            boLockSendMsgAction = false; //是否锁定发信息操作
            boLockUserItemAction = false; //是否锁定使用物品操作
            boLockInObModeAction = false; //锁定时进入隐身状态
            nPasswordErrorCountLock = 3; //输入密码错误超过 指定次数则锁定密码
            boPasswordErrorKick = false; //输入密码错误超过限制则踢下线
            nSendRefMsgRange = 12;
            boDecLampDura = true;
            boHungerSystem = false;
            boHungerDecHP = false;
            boHungerDecPower = false;
            boDiableHumanRun = true;
            boRUNHUMAN = false;
            boRUNMON = false;
            boRunNpc = false;
            boRunGuard = false;
            boWarDisHumRun = false;
            boSkill31Effect = false;//魔法盾效果 T-特色效果 F-盛大效果 20080808
            nSkill66Rate = 75;//四级魔法盾抵御伤害百分率 20080829
            nOrdinarySkill66Rate = 15;//普通魔法盾抵御伤害百分率 20081226
            nSkill69NG = 10;//内力值参数 20081001
            nSkill69NGExp = 55330;//主体内功经验参数 20081001
            nHeroSkill69NGExp = 62400;//英雄内功经验参数 20081001
            dwIncNHTime = 8000;//增加内力值间隔 20081002
            nDrinkIncNHExp = 100;//饮酒增加内功经验 20081003
            nHitStruckDecNH = 1;//内功抵御普通攻击消耗内力值 20081003
            boGMRunAll = false;
            boSafeAreaLimited = false;
            dwTryDealTime = 3000;
            dwDealOKTime = 1000;
            boCanNotGetBackDeal = true;
            boDisableDeal = false;
            nMasterCount = 5;//可收徒弟数 20080530
            nMasterOKLevel = 500;
            nMasterOKCreditPoint = 0;
            nMasterOKBonusPoint = 0;
            boPKLevelProtect = false;
            nPKProtectLevel = 10;
            nRedPKProtectLevel = 10;
            nItemPowerRate = 10000;
            nItemExpRate = 10000;
            nScriptGotoCountLimit = 30;
            btHearMsgFColor = 0x00; //前景
            btHearMsgBColor = 0xFF; //背景
            btWhisperMsgFColor = 0xFC; //前景
            btWhisperMsgBColor = 0xFF; //背景
            btGMWhisperMsgFColor = 0xFF; //前景
            btGMWhisperMsgBColor = 0x38; //背景
            btCryMsgFColor = 0x0; //前景
            btCryMsgBColor = 0x97; //背景
            btGreenMsgFColor = 0xDB; //前景
            btGreenMsgBColor = 0xFF; //背景
            btBlueMsgFColor = 0xFF; //前景
            btBlueMsgBColor = 0xFC; //背景
            btSayMsgFColor = 0xFF; //前景  千里传音
            btSayeMsgBColor = 0xFC; //背景 千里传音
            btRedMsgFColor = 0xFF; //前景
            btRedMsgBColor = 0x38; //背景
            btGuildMsgFColor = 0xDB; //前景
            btGuildMsgBColor = 0xFF; //背景
            btGroupMsgFColor = 0xC4; //前景
            btGroupMsgBColor = 0xFF; //背景
            btCustMsgFColor = 0xFC; //前景
            btCustMsgBColor = 0xFF; //背景
            nMonRandomAddValue = 10;
            nMakeRandomAddValue = 10;
            nPlayMonRandomAddValue = 10;//人形身上装备极品机率
            nWeaponDCAddValueMaxLimit = 12;
            nWeaponDCAddValueRate = 15;
            nWeaponMCAddValueMaxLimit = 12;
            nWeaponMCAddValueRate = 15;
            nWeaponSCAddValueMaxLimit = 12;
            nWeaponSCAddValueRate = 15;
            nWeaponDCAddRate = 40;
            nWeaponSCAddRate = 40;
            nWeaponMCAddRate = 40;

            nDressDCAddRate = 40;
            nDressDCAddValueMaxLimit = 6;
            nDressDCAddValueRate = 20;
            nDressMCAddRate = 40;
            nDressMCAddValueMaxLimit = 6;
            nDressMCAddValueRate = 20;
            nDressSCAddRate = 40;
            nDressSCAddValueMaxLimit = 6;
            nDressSCAddValueRate = 20;
            nDressACAddValueMaxLimit = 6;
            nDressACAddValueRate = 20;
            nDressACAddRate = 40;
            nDressMACAddValueMaxLimit = 6;
            nDressMACAddValueRate = 20;
            nDressMACAddRate = 40;
            nNeckLace202124DCAddRate = 40;
            nNeckLace202124DCAddValueMaxLimit = 6;
            nNeckLace202124DCAddValueRate = 20;
            nNeckLace202124MCAddRate = 40;
            nNeckLace202124MCAddValueMaxLimit = 6;
            nNeckLace202124MCAddValueRate = 20;
            nNeckLace202124SCAddRate = 40;
            nNeckLace202124SCAddValueMaxLimit = 6;
            nNeckLace202124SCAddValueRate = 20;
            nNeckLace202124ACAddValueMaxLimit = 6;
            nNeckLace202124ACAddValueRate = 20;
            nNeckLace202124ACAddRate = 40;
            nNeckLace202124MACAddValueMaxLimit = 6;
            nNeckLace202124MACAddValueRate = 20;
            nNeckLace202124MACAddRate = 40;
            nNeckLace19DCAddRate = 30;
            nNeckLace19DCAddValueMaxLimit = 6;
            nNeckLace19DCAddValueRate = 20;
            nNeckLace19MCAddRate = 30;
            nNeckLace19MCAddValueMaxLimit = 6;
            nNeckLace19MCAddValueRate = 20;
            nNeckLace19SCAddRate = 30;
            nNeckLace19SCAddValueMaxLimit = 6;
            nNeckLace19SCAddValueRate = 20;
            nNeckLace19ACAddValueMaxLimit = 6;
            nNeckLace19ACAddValueRate = 20;
            nNeckLace19ACAddRate = 30;
            nNeckLace19MACAddValueMaxLimit = 6;
            nNeckLace19MACAddValueRate = 20;
            nNeckLace19MACAddRate = 30;
            nArmRing26DCAddRate = 30;
            nArmRing26DCAddValueMaxLimit = 6;
            nArmRing26DCAddValueRate = 20;
            nArmRing26MCAddRate = 30;
            nArmRing26MCAddValueMaxLimit = 6;
            nArmRing26MCAddValueRate = 20;
            nArmRing26SCAddRate = 30;
            nArmRing26SCAddValueMaxLimit = 6;
            nArmRing26SCAddValueRate = 20;
            nArmRing26ACAddValueMaxLimit = 6;
            nArmRing26ACAddValueRate = 20;
            nArmRing26ACAddRate = 30;
            nArmRing26MACAddValueMaxLimit = 6;
            nArmRing26MACAddValueRate = 20;
            nArmRing26MACAddRate = 30;
            nRing22DCAddRate = 30;
            nRing22DCAddValueMaxLimit = 6;
            nRing22DCAddValueRate = 20;
            nRing22MCAddRate = 30;
            nRing22MCAddValueMaxLimit = 6;
            nRing22MCAddValueRate = 20;
            nRing22SCAddRate = 30;
            nRing22SCAddValueMaxLimit = 6;
            nRing22SCAddValueRate = 20;
            nRing23DCAddRate = 30;
            nRing23DCAddValueMaxLimit = 6;
            nRing23DCAddValueRate = 20;
            nRing23MCAddRate = 30;
            nRing23MCAddValueMaxLimit = 6;
            nRing23MCAddValueRate = 20;
            nRing23SCAddRate = 30;
            nRing23SCAddValueMaxLimit = 6;
            nRing23SCAddValueRate = 20;
            nRing23ACAddValueMaxLimit = 6;
            nRing23ACAddValueRate = 20;
            nRing23ACAddRate = 30;
            nRing23MACAddValueMaxLimit = 6;
            nRing23MACAddValueRate = 20;
            nRing23MACAddRate = 30;

            nBootsDCAddValueMaxLimit = 6;//极品鞋子加攻最高点
            nBootsDCAddValueRate = 20;
            nBootsDCAddRate = 30;
            nBootsSCAddValueMaxLimit = 6;
            nBootsSCAddValueRate = 20;
            nBootsSCAddRate = 30;//魔法
            nBootsMCAddValueMaxLimit = 6;
            nBootsMCAddValueRate = 20;
            nBootsMCAddRate = 30;//防御
            nBootsACAddValueMaxLimit = 6;
            nBootsACAddValueRate = 20;
            nBootsACAddRate = 30;//魔御
            nBootsMACAddValueMaxLimit = 6;
            nBootsMACAddValueRate = 20;
            nBootsMACAddRate = 30;

            nHelMetDCAddRate = 30;
            nHelMetDCAddValueMaxLimit = 6;
            nHelMetDCAddValueRate = 20;
            nHelMetMCAddRate = 30;
            nHelMetMCAddValueMaxLimit = 6;
            nHelMetMCAddValueRate = 20;
            nHelMetSCAddRate = 30;
            nHelMetSCAddValueMaxLimit = 6;
            nHelMetSCAddValueRate = 20;
            nHelMetACAddValueMaxLimit = 6;
            nHelMetACAddValueRate = 20;
            nHelMetACAddRate = 30;
            nHelMetMACAddValueMaxLimit = 6;
            nHelMetMACAddValueRate = 20;
            nHelMetMACAddRate = 30;

            nUnknowHelMetACAddRate = 20;
            nUnknowHelMetACAddValueMaxLimit = 4;
            nUnknowHelMetMACAddRate = 20;
            nUnknowHelMetMACAddValueMaxLimit = 4;
            nUnknowHelMetDCAddRate = 30;
            nUnknowHelMetDCAddValueMaxLimit = 3;
            nUnknowHelMetMCAddRate = 30;
            nUnknowHelMetMCAddValueMaxLimit = 3;
            nUnknowHelMetSCAddRate = 30;
            nUnknowHelMetSCAddValueMaxLimit = 3;
            nUnknowRingACAddRate = 20;
            nUnknowRingACAddValueMaxLimit = 4;
            nUnknowRingMACAddRate = 20;
            nUnknowRingMACAddValueMaxLimit = 4;
            nUnknowRingDCAddRate = 20;
            nUnknowRingDCAddValueMaxLimit = 6;
            nUnknowRingMCAddRate = 20;
            nUnknowRingMCAddValueMaxLimit = 6;
            nUnknowRingSCAddRate = 20;
            nUnknowRingSCAddValueMaxLimit = 6;
            nUnknowNecklaceACAddRate = 20;
            nUnknowNecklaceACAddValueMaxLimit = 5;
            nUnknowNecklaceMACAddRate = 20;
            nUnknowNecklaceMACAddValueMaxLimit = 5;
            nUnknowNecklaceDCAddRate = 30;
            nUnknowNecklaceDCAddValueMaxLimit = 5;
            nUnknowNecklaceMCAddRate = 30;
            nUnknowNecklaceMCAddValueMaxLimit = 5;
            nUnknowNecklaceSCAddRate = 30;
            nUnknowNecklaceSCAddValueMaxLimit = 5;
            nMonOneDropGoldCount = 2000;
            nMakeMineHitRate = 4; //挖矿命中率
            nMakeMineRate = 12; //挖矿率
            nStoneTypeRate = 120;
            nStoneTypeRateMin = 56;
            nGoldStoneMin = 1;
            nGoldStoneMax = 2;
            nSilverStoneMin = 3;
            nSilverStoneMax = 20;
            nSteelStoneMin = 21;
            nSteelStoneMax = 45;
            nBlackStoneMin = 46;
            nBlackStoneMax = 56;
            nStoneMinDura = 3000;
            nStoneGeneralDuraRate = 13000;
            nStoneAddDuraRate = 20;
            nStoneAddDuraMax = 10000;
            nWinLottery6Min = 1;
            nWinLottery6Max = 4999;
            nWinLottery5Min = 14000;
            nWinLottery5Max = 15999;
            nWinLottery4Min = 16000;
            nWinLottery4Max = 16149;
            nWinLottery3Min = 16150;
            nWinLottery3Max = 16169;
            nWinLottery2Min = 16170;
            nWinLottery2Max = 16179;
            nWinLottery1Min = 16180;
            nWinLottery1Max = 16185; //16180 + 1820;
            nWinLottery1Gold = 1000000;
            nWinLottery2Gold = 200000;
            nWinLottery3Gold = 100000;
            nWinLottery4Gold = 10000;
            nWinLottery5Gold = 1000;
            nWinLottery6Gold = 500;
            nWinLotteryRate = 30000;
            nWinLotteryCount = 0;
            nNoWinLotteryCount = 0;
            nWinLotteryLevel1 = 0;
            nWinLotteryLevel2 = 0;
            nWinLotteryLevel3 = 0;
            nWinLotteryLevel4 = 0;
            nWinLotteryLevel5 = 0;
            nWinLotteryLevel6 = 0;
            nItemNumber = 0;
            nItemNumberEx = Int32.MaxValue / 2;
            nGuildRecallTime = 180;
            nGroupRecallTime = 180;
            boControlDropItem = false;
            boInSafeDisableDrop = false;
            nCanDropGold = 1000;
            nCanDropPrice = 500;
            boSendCustemMsg = true;
            boSubkMasterSendMsg = true;
            nSuperRepairPriceRate = 3; //特修价格倍数
            nRepairItemDecDura = 3; //普通修理掉持久数*100,为每次修理掉的持久值
            boDieScatterBag = true;
            nDieScatterBagRate = 3;
            boDieRedScatterBagAll = true;
            nDieDropUseItemRate = 30;
            nDieRedDropUseItemRate = 15;
            boDieDropGold = false;
            boKillByHumanDropUseItem = false;
            boKillByMonstDropUseItem = true;
            boKickExpireHuman = false;
            nGuildRankNameLen = 16;
            nGuildMemberMaxLimit = 200;
            nGuildNameLen = 16;
            nAttackPosionRate = 5;
            nAttackPosionTime = 5;
            dwRevivalTime = 60000; //60 * 1000 复活间隔时间
            boUserMoveCanDupObj = false;
            boUserMoveCanOnItem = true;
            dwUserMoveTime = 10;
            dwPKDieLostExpRate = 1000;
            nPKDieLostLevelRate = 20000;
            nChallengeTime = 300;//挑战时间 20080706
            btNPCNameColor = 0xFF;//NPC名字颜色 20081218
            btPKFlagNameColor = 0x2F;
            btPKLevel1NameColor = 0xFB;
            btPKLevel2NameColor = 0xF9;
            btAllyAndGuildNameColor = 0xB4;
            btWarGuildNameColor = 0x45;
            btInFreePKAreaNameColor = 0xDD;
            boSpiritMutiny = false;
            dwSpiritMutinyTime = 1800000;//30 * 60 * 1000
            boMasterDieMutiny = false;
            nMasterDieMutinyRate = 5;
            nMasterDieMutinyPower = 10;
            nMasterDieMutinySpeed = 5;
            boBBMonAutoChangeColor = false;
            dwBBMonAutoChangeColorTime = 3000;
            boOldClientShowHiLevel = true;
            boShowScriptActionMsg = true;
            boThreadRun = false;
            boShowExceptionMsg = false;//异常错误信息 默认关闭
            boShowPreFixMsg = true;
            boGMShowFailMsg = true;//GM命令错误是否提示
            boRecordClientMsg = false;//记录人物私聊，行会聊天信息
            nMagicAttackRage = 8; //魔法锁定范围
            BoneFammArray = new TRecallMigic[10]; //骷髅
            DogzArray = new TRecallMigic[10]; //神兽
            FairyArray = new TRecallMigic[10]; //月灵
            SacredArray = new TRecallMigic[10]; //圣兽
            sBoneFamm = "变异骷髅";
            nBoneFammCount = 1;
            sDogz = "神兽";
            nDogzCount = 1;
            sFairy = "月灵";
            nFairyCount = 1;
            SacRed = "圣兽";
            SacredCount = 1;
            nFairyDuntRate = 6;
            nFairyDuntRateBelow = 4;//月灵重击次数,达到次数时按等级出重击
            nFairyAttackRate = 2;
            n43KillHitRate = 5; //开天斩重击几率
            n43KillAttackRate = 2; //开天斩重击倍数
            nAttackRate_43 = 100;//开天斩威力
            nAttackRate_26 = 100;//烈火剑法威力倍数
            nAttackRate_74 = 100;//逐日剑法威力倍数
            nAmyOunsulPoint = 10;
            boDisableInSafeZoneFireCross = false;
            boGroupMbAttackPlayObject = true;
            dwPosionDecHealthTime = 2500;
            nPosionDamagarmor = 12; //中红毒着持久及减防量（实际大小为 12 / 10）
            boLimitSwordLong = false;
            nSwordLongPowerRate = 100;
            nFireBoomRage = 1;
            nSnowWindRange = 1;
            nMeteorFireRainRage = 3;//流星火雨攻击范围
            nMagFireCharmTreatment = 10;//噬血术加血百分率
            nHeroNameColor = 6;//英雄名字颜色
            sHeroName = "英雄";//英雄名字
            sHeroNameSuffix = "的英雄";//英雄名后缀
            boNameSuffix = false;//是否显示后缀
            boNoSafeProtect = false;//禁止安全区守护
            boHeroAttackTarget = false;//道法22前是否物理攻击
            boHeroAttackTao = false;//道22后是否物理攻击
            boRestNoFollow = false;//英雄休息不跟随主人切换地图
            nElecBlizzardRange = 2;//地狱雷光攻击范围
            nHeroAttackRange_60 = 5;//破魂斩 攻击范围
            nHeroAttackRange_63 = 3;//噬魂沼泽 攻击范围
            nHeroAttackRange_64 = 3;//末日审判 攻击范围
            nHeroAttackRange_65 = 3;//火龙气焰 攻击范围
            nMagTurnUndeadLevel = 50; //圣言怪物等级限制
            nMagTammingLevel = 50; //诱惑之光怪物等级限制
            nMagTammingTargetLevel = 10; //诱惑怪物相差等级机率，此数字越小机率越大；
            nMagTammingHPRate = 100; //成功机率=怪物最高HP 除以 此倍率，此倍率越大诱惑机率越高
            nMagTammingCount = 5;
            nMabMabeHitRandRate = 100;
            nMabMabeHitMinLvLimit = 10;
            nMabMabeHitSucessRate = 21;
            nMabMabeHitMabeTimeRate = 20;
            sCASTLENAME = "沙巴克";
            sCastleHomeMap = "3";
            nCastleHomeX = 644;
            nCastleHomeY = 290;
            nCastleWarRangeX = 100;
            nCastleWarRangeY = 100;
            nCastleTaxRate = 5;
            boGetAllNpcTax = false;
            nHireGuardPrice = 300000;
            nHireArcherPrice = 300000;
            nCastleGoldMax = 10000000;
            nCastleOneDayGold = 2000000;
            nRepairDoorPrice = 2000000;
            nRepairWallPrice = 500000;
            nCastleMemberPriceRate = 80;
            nMaxHitMsgCount = 1;
            nMaxSpellMsgCount = 1;
            nMaxRunMsgCount = 1;
            nMaxWalkMsgCount = 1;
            nMaxTurnMsgCount = 1;
            nMaxSitDonwMsgCount = 1;
            nMaxDigUpMsgCount = 2;
            boSpellSendUpdateMsg = false;
            boActionSendActionMsg = false;
            boKickOverSpeed = false;
            btSpeedControlMode = 0;
            nOverSpeedKickCount = 4;
            dwDropOverSpeed = 10;
            dwHitIntervalTime = 900; //攻击间隔
            dwMagicHitIntervalTime = 800; //魔法间隔
            dwRunIntervalTime = 100; //跑步间隔
            dwWalkIntervalTime = 100; //走路间隔
            dwTurnIntervalTime = 100; //换方向间隔
            boControlActionInterval = true;
            boControlWalkHit = true;
            boControlRunLongHit = true;
            boControlRunHit = true;
            boControlRunMagic = true;
            dwActionIntervalTime = 350; //组合操作间隔
            dwRunLongHitIntervalTime = 800; //跑位刺杀间隔
            dwRunHitIntervalTime = 800; //跑位攻击间隔
            dwWalkHitIntervalTime = 800; //走位攻击间隔
            dwRunMagicIntervalTime = 900; //跑位魔法间隔
            boDisableStruck = false; //不显示人物弯腰动作
            boDisableSelfStruck = false; //自己不显示人物弯腰动作
            dwStruckTime = 100; //人物弯腰停留时间
            dwKillMonExpMultiple = 1; //杀怪经验倍数
            dwKillMonNGExpMultiple = 40; //杀怪内功经验倍数
            nNGSkillRate = 25;//内功技能增强的攻防比率
            nNGLevelDamage = 8;//内功等级增加攻防的级数比率
            dwRequestVersion = 98;
            boHighLevelKillMonFixExp = false;
            boAddUserItemNewValue = true;
            sLineNoticePreFix = "【公告】";
            sSysMsgPreFix = "【系统】";
            sGuildMsgPreFix = "【行会】";
            sGroupMsgPreFix = "【组队】";
            sHintMsgPreFix = "【提示】";
            sGMRedMsgpreFix = "【ＧＭ】";
            sMonSayMsgpreFix = "【怪物】";
            sCustMsgpreFix = "【祝福】";
            sCastleMsgpreFix = "【城主】";
            sGuildNotice = "公告";
            sGuildWar = "敌对行会";
            sGuildAll = "联盟行会";
            sGuildMember = "行会成员";
            sGuildMemberRank = "行会成员";
            sGuildChief = "掌门人";
            boKickAllUser = false;
            boTestSpeedMode = false;
            ClientConf = new TClientConf()
            {
                boRUNHUMAN = true,
                boRUNMON = true,
                boRunNpc = true,
                boWarRunAll = true,
                btDieColor = 5,
                wSpellTime = 500,
                wHitIime = 1400,
                wItemFlashTime = 500,//5 * 100
                btItemSpeed = 25,//60
                boParalyCanRun = false,
                boParalyCanWalk = false,
                boParalyCanHit = false,
                boParalyCanSpell = false,
                boShowJobLevel = true,
                boDuraAlert = true
            };
            nWeaponMakeUnLuckRate = 20;
            nWeaponMakeLuckPoint1 = 1;
            nWeaponMakeLuckPoint2 = 3;
            nWeaponMakeLuckPoint3 = 7;
            nWeaponMakeLuckPoint2Rate = 6;
            nWeaponMakeLuckPoint3Rate = 10 + 30;
            boCheckUserItemPlace = true;
            nClientKey = 6534;
            nLevelValueOfTaosHP = 6;
            nLevelValueOfTaosHPRate = 2;
            nLevelValueOfTaosMP = 8;
            nLevelValueOfWizardHP = 15;
            nLevelValueOfWizardHPRate = 1;
            nLevelValueOfWarrHP = 4;
            nLevelValueOfWarrHPRate = 4;

            nProcessMonsterInterval = 2;

            GlobalVal = new int[500];//全局变量G
            GlobaDyMval = new int[100];//个人变量M
            GlobalAVal = new string[500];//全局变量A
            dwNeedExps = new uint[MAXCHANGELEVEL + 1];
            dwHeroNeedExps = new uint[MAXCHANGELEVEL + 1];
            dwMedicineNeedExps = new ushort[50];
            dwSkill68NeedExps = new uint[100];
            dwExpCrystalNeedExps = new uint[5];
            dwNGExpCrystalNeedExps = new uint[5];

            nDecUserGameGold = 1;//每次扣多少元宝(元宝寄售) 20080319
            nMakeWineTime = 300;//酿普通酒等待时间 20080621
            nMakeWineTime1 = 900;//酿药酒等待时间 20080621
            nMakeWineRate = 10;//酿酒获得酒曲机率 20080621
            nIncAlcoholTick = 30;//增加酒量进度的间隔时间 20080623
            nDesDrinkTick = 25;//减少醉酒度的间隔时间 20080623
            nMaxAlcoholValue = 2000;//酒量上限初始值 20080623
            nIncAlcoholValue = 10;//升级后增加酒量上限值 20080623
            nDesMedicineValue = 1;//长时间不使用酒,减药力值 20080623
            nDesMedicineTick = 43200;//减药力值时间间隔 20080624
            nInFountainTime = 10;//站在泉眼上的累积时间(秒) 20080624
            nMinGuildFountain = 50;//行会酒泉蓄量少于时,不能领取 20080627
            nDecGuildFountain = 50;//行会成员领取酒泉,蓄量减少 20080627
            nHeroCrystalExpRate = 12;//天地结晶英雄分配比例 20090202

            boPlayObjectReduceMP = true;
            boGroupMbAttackSlave = false;
            nBigStorageLimitCount = 100;
            boDropGoldToPlayBag = true;
            boChangeUseItemNameByPlayName = true;
            sChangeUseItemName = "〖改〗";
            boUseFixExp = true;
            nBaseExp = 100000000;
            nAddExp = 1000000;
            nKill43UseTime = 10;//开天斩使用间隔 20080204
            nDedingUseTime = 10;
            nAbilityUpTick = 15;//无极真气使用间隔 20080603
            boAbilityUpFixMode = false;//无极真气使用时长模式 20081109
            nAbilityUpFixUseTime = 6;//无极真气使用固定时长 20081109
            nAbilityUpUseTime = 0;//无极真气使用时长 20080603
            nMinDrinkValue67 = 5;//先天元力失效酒量下限比例 20080626
            nMinDrinkValue68 = 5;//酒气护体失效酒量下限比例 20080626
            nHPUpTick = 0;//酒气护体使用间隔 20080625
            nHPUpUseTime = 0;//酒气护体增加使用时长 20080625
            boDedingAllowPK = true;
            boRegenMonsters = true;

            nMakeSelfTick = 60;//分身使用时长 20080404
            nCopyHumanTick = 10;//召唤分身的间隔 20080204
            nCopyHumanBagCount = 40;
            nCopyHumNameColor = 6;//分身名字颜色 20080404
            nAllowCopyHumanCount = 1;
            boAddMasterName = true;
            sCopyHumName = "的分身";
            nCopyHumAddHPRate = 60;
            nCopyHumAddMPRate = 60;
            sCopyHumBagItems1 = "超级金创药,超级魔法药";
            sCopyHumBagItems2 = "超级金创药,超级魔法药";
            sCopyHumBagItems3 = "超级金创药,超级魔法药,灰色药粉(大量),黄色药粉(大量),护身符(大)";
            boAllowGuardAttack = false;
            dwWarrorAttackTime = 1200;
            dwWizardAttackTime = 1200;
            dwTaoistAttackTime = 1200;
            boAllowReCallMobOtherHum = true;
            boNeedLevelHighTarget = true;

            dwGetDBSockMsgTime = 5000;
            boPullCrossInSafeZone = true;
            boHighLevelGroupFixExp = true;
            boStartMapEvent = false;
            nIsUseZhuLi = 0;//斗笠可带选项
            boUnKnowHum = true;//带上斗笠是否显示神秘人
            boSaveExpRate = true;//是否保存双倍经验时间
            nLimitExpLevel = 1000;
            nLimitExpValue = 1;

            boChangeMapFireExtinguish = true;
            nFireDelayTimeRate = 100;
            nFirePowerRate = 100;
            nDidingPowerRate = 100;

            nHeroStartLevel = 1;
            nDrinkHeroStartLevel = 7;//卧龙英雄开始等级
            nHeroKillMonExpRate = 40;
            nHeroNoKillMonExpRate = 10;//非杀怪分配经验比例
            nHeroBagItemCount = new ushort[] { 1, 20, 30, 35, 40 };
            dwHeroWarrorAttackTime = 660;
            dwHeroWizardAttackTime = 880;
            dwHeroTaoistAttackTime = 880;

            boHeroKillByMonstDropUseItem = true;
            boHeroKillByHumanDropUseItem = false;
            boHeroDieScatterBag = true;
            boHeroAutoProtectionDefence = false;//英雄无目标下自动开启护体神盾 20080715
            boHeroNoTargetCall = false;//英雄无目标下可召唤宝宝 20080615
            boHeroDieExp = false;//英雄死亡掉经验 20080605
            nHeroDieExpRate = 10;//英雄死亡掉经验比率 20080605
            boHeroDieRedScatterBagAll = true;
            nHeroDieDropUseItemRate = 30;
            nHeroDieRedDropUseItemRate = 15;
            nHeroDieScatterBagRate = 3;
            nHeroAddHPRate = 60;
            nHeroAddMPRate = 60;
            nHeroAddHPMPTick = 2000;//吃普通药速度 20080601
            nHeroAddHPRate1 = 60;//20080910
            nHeroAddMPRate1 = 60;//20080910
            nHeroAddHPMPTick1 = 2000;//吃特殊药速度 20080910

            nKill42UseTime = 10;//龙影剑法使用间隔(100) 20080619
            nAttackRate_42 = 100;//龙影剑法威力 20080213
            nMagicAttackRage_42 = 4;//龙影剑法范围 20080218

            nMaxFirDragonPoint = 200;
            nAddFirDragonPoint = 40;
            nDecFirDragonPoint = 40;
            nIncDragonPointTick = 3000;//加怒气时间间隔 20080606
            nHeroSkill46MaxHP_0 = 70;//0级 英雄召唤分身HP的比率 20080907
            nHeroSkill46MaxHP_1 = 80;//1级 英雄召唤分身HP的比率 20081217
            nHeroSkill46MaxHP_2 = 90;//2级 英雄召唤分身HP的比率 20081217
            nHeroSkill46MaxHP_3 = 100;//3级 英雄召唤分身HP的比率 20081217
            nHeroMakeSelfTick = 10;//英雄分身延长使用时间 20081217
            nDecDragonHitPoint = 5;//饮酒减少合击伤害 20080626
            nDecDragonRate = 100;//合击对人物的伤害比例 20080803
            nHeroAttackRate_60 = 100;//破魂斩威力 20080131
            nHeroAttackRate_61 = 100;//劈星斩威力 20080131
            nHeroAttackRate_62 = 100;//雷霆一击威力 20080131
            nHeroAttackRate_63 = 100;//噬魂沼泽威力 20080131
            nHeroAttackRate_64 = 100;//末日审判威力 20080131
            nHeroAttackRate_65 = 100;//火龙气焰威力 20080131
            btHeroSkillMode_63 = true;//噬魂沼泽使用绿毒模式 20080911

            nMakeGhostHeroTime = 3000;//英雄尸体清理时间 20080418
            nRecallHeroTime = 10000;  //召唤英雄间隔 20071201

            sHeroClothsMan = "布衣(男)";
            sHeroClothsWoman = "布衣(女)";
            sHeroWoodenSword = "木剑";
            sHeroBasicDrug = "金创药(小量)";

            dwMagChangXYTick = 1000;//移行换位使用间隔 20080616
            nProtectionDefenceTime = 10000;//护体神盾最长时间 20080108
            dwProtectionTick = 10000;//护体神盾使用间隔 20080108
            nProtectionRate = 20;//护体神盾减攻击百分比 20080504
            nProtectionOKRate = 10;//护体神盾生效机率 20080929
            nProtectionBadRate = 3;//护体神盾被击破机率 20080108
            RushkungBadProtection = false;//刺杀必破护体神盾 20080108
            ErgumBadProtection = false;//刺杀必破护体神盾 20080108
            FirehitBadProtection = false;//烈火必破护体神盾 20080108
            TwnhitBadProtection = false;//开天必破护体神盾 20080108
            boShowProtectionEnv = true;//显示护体神盾效果 20080328
            boAutoProtection = false;//自动使用神盾 20080328
            boAutoCanHit = false;//火符智能锁定 20080418
            boSlaveMoveMaster = false;//宝宝是否飞到主人身边 20080713
            nHeroHPRate = 2;//英雄HP为人物的倍数 20081219
            nDeathDecLoyal = 100;//死亡减少忠诚度 20080110
            nPKDecLoyal = 100;//PK值减少忠诚度 20080214
            nGuildIncLoyal = 100;//行会战增加忠诚度 20080214
            nLevelOrderIncLoyal = 100;//人物等级排名上升增加忠诚度
            nLevelOrderDecLoyal = 100;//人物等级排名下降减少忠诚度
            nWinExp = 10000;//获得经验->忠诚度 20080110
            nExpAddLoyal = 100;//经验加忠诚 20080110
            nGotoLV4 = 30000;//四级触发 20080110
            nPowerLV4 = 10;//四级技能杀伤力增加值
            dwHeroWalkIntervalTime = 100;//英雄走路间隔
            dwHeroTurnIntervalTime = 100;//英雄转向间隔
            dwHeroMagicHitIntervalTime = 800;//英雄魔法间隔
            btHeroSkillMode = true;//英雄施毒术使用模式
            btHeroSkillMode50 = true;//英雄无极真气使用模式
            btHeroSkillMode46 = false;//英雄分身术模式
            btHeroSkillMode43 = false;//英雄开天斩重击模式

            //-----------------气血石相关配置----------------------------
            nStartHPRock = 10;
            nRockAddHP = 10;
            nHPRockSpell = 700;
            nHPRockDecDura = 100;
            nStartMPRock = 10;
            nRockAddMP = 10;
            nMPRockSpell = 700;
            nMPRockDecDura = 100;
            nStartHPMPRock = 10;
            nRockAddHPMP = 10;
            nHPMPRockSpell = 700;
            nHPMPRockDecDura = 100;
            g_boGameGird = true;//开启兑换灵符功能
            g_nGameGold = 1; //兑换灵符,元宝数量
        }
    }
}