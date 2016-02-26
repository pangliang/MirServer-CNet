using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 人物数据类 
    /// Size = 4487 
    /// 预留N个变量
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct THumData
    {
        public byte ChrNameLen;
        /// <summary>
        /// 玩家名称
        /// </summary>
        public fixed sbyte sChrName[14];
        public byte CurMapLen;
        /// <summary>
        /// 地图名称
        /// </summary>
        public fixed sbyte sCurMap[16];
        /// <summary>
        /// X坐标
        /// </summary>
        public UInt16 wCurX;
        /// <summary>
        /// Y坐标
        /// </summary>
        public UInt16 wCurY;
        /// <summary>
        /// 方向
        /// </summary>
        public byte btDir;
        /// <summary>
        /// 头发
        /// </summary>
        public byte btHair;
        /// <summary>
        /// 性别
        /// </summary>
        public byte btSex;
        /// <summary>
        /// 职业 0-战 1-法 2-道
        /// </summary>
        public byte btJob;
        /// <summary>
        /// 金币数
        /// </summary>
        public int nGold;
        /// <summary>
        /// 人物其它属性 Size 40
        /// </summary>
        public TOAbility Abil;
        /// <summary>
        /// 人物状态属性值，一般是持续多少秒 Size 24
        /// </summary>
        public fixed UInt16 wStatusTimeArr[12];
        public byte HomeMapLen;
        /// <summary>
        /// 家
        /// </summary>
        public fixed sbyte sHomeMap[16];
        /// <summary>
        /// Home X
        /// </summary>
        public UInt16 wHomeX;
        /// <summary>
        /// Home Y
        /// </summary>
        public UInt16 wHomeY;
        public byte DearNameLen;
        /// <summary>
        /// 别名(配偶)
        /// </summary>
        public fixed sbyte sDearName[14];
        public byte MasterNameLen;
        /// <summary>
        /// 师傅名字
        /// </summary>
        public fixed sbyte sMasterName[14];
        /// <summary>
        /// 是否有徒弟
        /// </summary>
        public bool boMaster;
        /// <summary>
        /// 声望点
        /// </summary>
        public int btCreditPoint;
        /// <summary>
        /// 是否结婚
        /// </summary>
        public byte btDivorce;
        /// <summary>
        /// 结婚次数
        /// </summary>
        public byte btMarryCount;
        public byte StoragePwdLen;
        /// <summary>
        /// 仓库密码
        /// </summary>
        public fixed sbyte sStoragePwd[7];
        /// <summary>
        /// 转生等级
        /// </summary>
        public byte btReLevel;
        /// <summary>
        /// 0-是否开通元宝寄售(1-开通) 1-是否寄存英雄(1-存有英雄) 2-饮酒时酒的品质
        /// </summary>
        public fixed byte btUnKnow2[3];
        /// <summary>
        /// 人物额外属性点 Size 20
        /// </summary>
        public TNakedAbility BonusAbil;
        /// <summary>
        /// 奖励点
        /// </summary>
        public int nBonusPoint;
        /// <summary>
        /// 游戏币
        /// </summary>
        public int nGameGold;
        /// <summary>
        /// 金刚石
        /// </summary>
        public int nGameDiaMond;
        /// <summary>
        /// 灵符
        /// </summary>
        public int nGameGird;
        /// <summary>
        /// 声望
        /// </summary>
        public int nGamePoint;
        /// <summary>
        /// 荣誉
        /// </summary>
        public byte btGameGlory;
        /// <summary>
        /// 充值点
        /// </summary>
        public int nPayMentPoint;
        /// <summary>
        /// 英雄的忠诚度
        /// </summary>
        public int nLoyal;
        /// <summary>
        /// PK点数
        /// </summary>
        public int nPKPOINT;
        /// <summary>
        /// 允许组队
        /// </summary>
        public byte btAllowGroup;
        public byte btF9;
        /// <summary>
        /// 攻击模式
        /// </summary>
        public byte btAttatckMode;
        /// <summary>
        /// 增加健康数
        /// </summary>
        public byte btIncHealth;
        /// <summary>
        /// 增加攻击点
        /// </summary>
        public byte btIncSpell;
        /// <summary>
        /// 增加治愈点
        /// </summary>
        public byte btIncHealing;
        /// <summary>
        /// 在行会占争地图中死亡次数
        /// </summary>
        public byte btFightZoneDieCount;
        public byte AccountLen;
        /// <summary>
        /// 登录帐号
        /// </summary>
        public fixed sbyte sAccount[10];
        /// <summary>
        /// 英雄类型 0-白日门英雄 1-卧龙英雄
        /// </summary>
        public byte btEF;
        /// <summary>
        /// 是否锁定登陆
        /// </summary>
        public bool boLockLogon;
        /// <summary>
        /// 贡献值
        /// </summary>
        public UInt16 wContribution;
        /// <summary>
        /// 饥饿状态
        /// </summary>
        public int nHungerStatus;
        /// <summary>
        /// 是否允许行会合一
        /// </summary>
        public bool boAllowGuildReCall;
        /// <summary>
        /// 队传送时间
        /// </summary>
        public UInt16 wGroupRcallTime;
        /// <summary>
        /// 幸运度
        /// </summary>
        public double dBodyLuck;
        /// <summary>
        /// 是否允许天地合一
        /// </summary>
        public bool boAllowGroupReCall;
        /// <summary>
        /// 经验倍数
        /// </summary>
        public int nEXPRATE;
        /// <summary>
        /// 经验倍数时间
        /// </summary>
        public int nExpTime;
        /// <summary>
        /// 退出状态 1为死亡退出
        /// </summary>
        public byte btLastOutStatus;
        /// <summary>
        /// 出师徒弟数
        /// </summary>
        public UInt16 wMasterCount;
        /// <summary>
        /// 是否有白日门英雄
        /// </summary>
        public bool boHasHero;
        /// <summary>
        /// 是否是英雄
        /// </summary>
        public bool boIsHero;
        /// <summary>
        /// 状态
        /// </summary>
        public byte btStatus;
        public byte HeroChrName;
        /// <summary>
        /// 英雄名称
        /// </summary>
        public fixed sbyte sHeroChrName[14];
        /// <summary>
        /// 0-3酿酒使用 4-饮酒时的度数 5-魔法盾等级 6-是否学过内功 7-内功等级
        /// </summary>
        public fixed byte UnKnow[30];
        /// <summary>
        /// 脚本变量
        /// </summary>
        public fixed byte QuestFlag[128];
        public fixed byte HumItemsBuff[9 * 32]; // 引用时需要指针转换 (TUserItem*)HumData.HumItemsBuff 9格装备 衣服  武器  蜡烛 头盔 项链 手镯 手镯 戒指 戒指
        // 引用时需要指针转换 (TUserItem*)HumData.BagItemsBuff
        public fixed byte BagItemsBuff[46 * 32];// 包裹装备 Size 1472
        // 引用时需要指针转换 (THumMagic*)HumData.HumMagicsBuff
        public fixed byte HumMagicsBuff[30 * 8];// 魔法
        // 引用时需要指针转换  (TUserItem*)HumData.StorageItemsBuff
        public fixed byte StorageItemsBuff[46 * 32];// 仓库物品
        // 引用时需要指针转换   (TUserItem*)HumData.HumAddItems
        public fixed byte HumAddItemsBuff[5 * 32];// 新增4格 护身符 腰带 鞋子 宝石
        /// <summary>
        /// 累计经验
        /// </summary>
        public int n_WinExp;
        /// <summary>
        /// 聚灵珠聚集时间
        /// </summary>
        public int n_UsesItemTick;
        /// <summary>
        /// 酿酒的时间,即还有多长时间可以取回酒
        /// </summary>
        public int nReserved;
        /// <summary>
        /// 当前药力值
        /// </summary>
        public int nReserved1;
        /// <summary>
        /// 药力值上限
        /// </summary>
        public int nReserved2;
        /// <summary>
        /// 使用药酒时间,计算长时间没使用药酒
        /// </summary>
        public int nReserved3;
        /// <summary>
        /// 当前酒量值
        /// </summary>
        public UInt16 n_Reserved;
        /// <summary>
        /// 酒量上限
        /// </summary>
        public UInt16 n_Reserved1;
        /// <summary>
        /// 当前醉酒度
        /// </summary>
        public UInt16 n_Reserved2;
        /// <summary>
        /// 药力值等级
        /// </summary>
        public UInt16 n_Reserved3;
        /// <summary>
        /// 是否请过酒 T-请过酒
        /// </summary>
        public bool boReserved;
        /// <summary>
        /// 是否有卧龙英雄
        /// </summary>
        public bool boReserved1;
        /// <summary>
        /// 是否酿酒 T-正在酿酒
        /// </summary>
        public bool boReserved2;
        /// <summary>
        /// 人是否喝酒醉了
        /// </summary>
        public bool boReserved3;
        /// <summary>
        /// 人物领取行会酒泉日期
        /// </summary>
        public int m_GiveDate;
        /// <summary>
        /// 酒气护体当前经验
        /// </summary>
        public int Exp68;
        /// <summary>
        /// 酒气护体升级经验
        /// </summary>
        public int MaxExp68;
        /// <summary>
        /// 内功当前经验
        /// </summary>
        public int nExpSkill69;
        // 内功技能 
        // 引用时需要指针转换 (THumMagic*)HumData.HumNGMagicsBuff
        public fixed byte HumNGMagicsBuff[30 * 8];// 人物经络 (TBatterPulse*)
        public fixed sbyte HumPulses[4 * 2];// 连击技能 (THumMagic *)
        public fixed sbyte HumBatterMagicsBuff[4 * 8];// 连击循序
        public fixed UInt16 BatterMagicOrder[3];
        public bool m_boIsOpenPuls;// (英雄) 是否打开经络
        public uint m_nPulseExp;// (英雄) 经络经验
        public byte MentHeroChrNameLen;
        public fixed sbyte sMentHeroChrName[14];// 副将英雄名称
        public int nMentHeroIncExp;// 副将英雄累计经验
        public byte m_btFHeroJob;
        public byte m_btFHeroType;
        public byte m_nReserved5;// 保留
        public UInt16 m_nReserved6;// 保留
        public int m_nReserved7;// 保留
        public int m_nReserved8;
    }
}