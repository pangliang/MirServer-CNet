using GameFramework;
using GameFramework.Enum;
using M2Server.Base;
using M2Server.Mon;
using M2Server.Monster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace M2Server
{
    public class TUserEngine : GameBase
    {
        /// <summary>
        /// 加载玩家线程锁
        /// </summary>
        public object m_LoadPlaySection = null;
        public static uint g_dwEngineTick = 0;
        public static uint g_dwEngineRunTime = 0;
        /// <summary>
        /// 检查过程是否重入
        /// </summary>
        public static bool m_boHumProcess = false;
        /// <summary>
        /// 检查雷炎效果过程是否重入
        /// </summary>
        public static bool m_boProcessEffects = false;
        /// <summary>
        /// 检查游戏进程是否重入
        /// </summary>
        public static bool m_boPrcocessData = false;
        /// <summary>
        /// 怪物数量
        /// </summary>
        public int MonsterCount
        {
            get { return nMonsterCount; }
        }
        /// <summary>
        /// 在线人数
        /// </summary>
        public int OnlinePlayObject
        {
            get { return GetOnlineHumCount(); }
        }
        /// <summary>
        /// 总人数
        /// </summary>
        public int PlayObjectCount
        {
            get { return GetUserCount(); }
        }
        /// <summary>
        /// 自动挂机人数
        /// </summary>
        public int AutoAddExpPlayCount
        {
            get { return GetAutoAddExpPlayCount(); }
        }
        /// <summary>
        /// 加载人物次数
        /// </summary>
        public int LoadPlayCount
        {
            get { return GetLoadPlayCount(); }
        }
        /// <summary>
        /// 从DB读取人物数据
        /// </summary>
        public List<TUserOpenInfo> m_LoadPlayList = null;
        /// <summary>
        /// 在线角色列表
        /// </summary>
        public List<TPlayObject> m_PlayObjectList = null;
        /// <summary>
        /// 释放角色列表
        /// </summary>
        public List<TPlayObject> m_PlayObjectFreeList = null;
        /// <summary>
        /// 火龙殿中的守护兽
        /// </summary>
        public List<TBaseObject> m_MonObjectList = null;
        public List<TGoldChangeInfo> m_ChangeHumanDBGoldList = null;
        /// <summary>
        /// 显示在线人数间隔
        /// </summary>
        public uint dwShowOnlineTick = 0;
        /// <summary>
        /// 发送在线人数间隔
        /// </summary>
        public uint dwSendOnlineHumTime = 0;
        public uint dwProcessMapDoorTick = 0;
        public uint dwProcessMissionsTime = 0;
        public uint dwRegenMonstersTick = 0;
        public uint m_dwProcessLoadPlayTick = 0;
        /// <summary>
        /// 刷怪索引
        /// </summary>
        public int m_nCurrMonGen = 0;
        public int m_nMonGenListPosition = 0;
        public int m_nMonGenCertListPosition = 0;
        /// <summary>
        /// 处理人物开始索引（每次处理人物数限制）
        /// </summary>
        public int m_nProcHumIDx = 0;
        public int nMerchantPosition = 0;
        public int nNpcPosition = 0;
        /// <summary>
        /// 物品列表(即数据库中的数据)
        /// </summary>
        public List<IntPtr> StdItemList = null;
        /// <summary>
        /// 怪物列表
        /// </summary>
        public List<TMonInfo> MonsterList = null;
        /// <summary>
        /// 怪物列表(MonGen.txt文件里的设置)
        /// </summary>
        public List<TMonGenInfo> m_MonGenList = null;
        /// <summary>
        /// 魔法列表
        /// </summary>
        public List<IntPtr> m_MagicList = null;
        /// <summary>
        /// 地图怪物列表
        /// </summary>
        public List<TMapMonGenCount> m_MapMonGenCountList = null;
        /// <summary>
        /// 管理员列表
        /// </summary>
        public List<TAdminInfo> m_AdminList = null;
        /// <summary>
        /// 交易NPC列表
        /// </summary>
        public List<TMerchant> m_MerchantList = null;
        /// <summary>
        /// 任务NPC列表
        /// </summary>
        public List<TNormNpc> QuestNPCList = null;
        public List<TSwitchDataInfo> m_ChangeServerList = null;
        /// <summary>
        /// 魔法事件列表
        /// </summary>
        public List<TMagicEvent> m_MagicEventList = null;
        /// <summary>
        /// 怪物总数
        /// </summary>
        public int nMonsterCount = 0;
        /// <summary>
        /// 处理怪物总数位置，用于计算怪物总数
        /// </summary>
        public int nMonsterProcessPostion = 0;
        /// <summary>
        /// 处理怪物数，用于统计处理怪物个数
        /// </summary>
        public int nMonsterProcessCount = 0;
        public bool boItemEvent = false;
        public uint dwProcessMerchantTimeMin = 0;
        public uint dwProcessMerchantTimeMax = 0;
        public uint dwProcessNpcTimeMin = 0;
        public uint dwProcessNpcTimeMax = 0;
        public List<TPlayObject> m_NewHumanList = null;
        public ArrayList m_ListOfGateIdx = null;
        public ArrayList m_ListOfSocket = null;
        public IList<IntPtr> OldMagicList = null;
        /// <summary>
        /// 地图效果列表
        /// </summary>
        public IList<TEnvirnoment> EffectList = null;
        /// <summary>
        ///  雷炎地图(中魔法的对像)
        /// </summary>
        public IList<TPlayObject> m_TargetList = null;
        /// <summary>
        /// 限制用户数
        /// </summary>
        public int m_nLimitUserCount = 0;
        /// <summary>
        /// 限制使用天数或次数
        /// </summary>
        public int m_nLimitNumber = 0;
        /// <summary>
        /// 开始读取魔法
        /// </summary>
        public bool m_boStartLoadMagic = false;
        public uint m_dwSearchTick = 0;
        public uint m_dwGetTodyDayDateTick = 0;
        /// <summary>
        /// 今天日期
        /// </summary>
        public DateTime m_TodayDate;
        /// <summary>
        /// 人物等级排行
        /// </summary>
        public TStringList m_PlayObjectLevelList = null;
        /// <summary>
        /// 战士等级排行
        /// </summary>
        public TStringList m_WarrorObjectLevelList = null;
        /// <summary>
        /// 法师等级排行
        /// </summary>
        public TStringList m_WizardObjectLevelList = null;
        /// <summary>
        /// 道士等级排行
        /// </summary>
        public TStringList m_TaoistObjectLevelList = null;
        /// <summary>
        /// 徒弟数排行
        /// </summary>
        public TStringList m_PlayObjectMasterList = null;
        /// <summary>
        /// 英雄等级排行
        /// </summary>
        public TStringList m_HeroObjectLevelList = null;
        /// <summary>
        /// 英雄战士等级排行
        /// </summary>
        public TStringList m_WarrorHeroObjectLevelList = null;
        /// <summary>
        /// 英雄法师等级排行
        /// </summary>
        public TStringList m_WizardHeroObjectLevelList = null;
        /// <summary>
        /// 英雄道士等级排行
        /// </summary>
        public TStringList m_TaoistHeroObjectLevelList = null;
        /// <summary>
        /// 取人物等级排行的间隔
        /// </summary>
        public uint dwGetOrderTick = 0;
        /// <summary>
        /// 起始座标X
        /// </summary>
        public int m_nCurrX_136 = 0;
        /// <summary>
        /// 起始座标Y
        /// </summary>
        public int m_nCurrY_136 = 0;
        /// <summary>
        /// 起始座标X
        /// </summary>
        public int m_NewCurrX_136 = 0;
        /// <summary>
        /// 终止座标Y 
        /// </summary>
        public int m_NewCurrY_136 = 0;
        /// <summary>
        /// 是否正在读取排行文件
        /// </summary>
        public bool bo_ReadPlayLeveList = false;
        /// <summary>
        /// 消息处理列表字典
        /// </summary>
        private Dictionary<int, TProcessUserMessage> FProcessUserMessage;
        /// <summary>
        /// 消息处理委托定义
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        public delegate void TProcessUserMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg);

        public TUserEngine()
        {
            m_LoadPlaySection = new object();
            m_LoadPlayList = new List<TUserOpenInfo>();
            m_PlayObjectList = new List<TPlayObject>();
            m_PlayObjectFreeList = new List<TPlayObject>();
            m_MonObjectList = new List<TBaseObject>();
            m_ChangeHumanDBGoldList = new List<TGoldChangeInfo>();
            dwShowOnlineTick = HUtil32.GetTickCount();
            dwSendOnlineHumTime = HUtil32.GetTickCount();
            dwProcessMapDoorTick = HUtil32.GetTickCount();
            dwProcessMissionsTime = HUtil32.GetTickCount();
            dwRegenMonstersTick = HUtil32.GetTickCount();
            m_dwProcessLoadPlayTick = HUtil32.GetTickCount();
            m_nCurrMonGen = 0;
            m_nMonGenListPosition = 0;
            m_nMonGenCertListPosition = 0;
            m_nProcHumIDx = 0;
            nMerchantPosition = 0;
            nNpcPosition = 0;
            m_nLimitNumber = 1000000;
            m_nLimitUserCount = 1000000;
            StdItemList = new List<IntPtr>();
            MonsterList = new List<TMonInfo>();
            m_MonGenList = new List<TMonGenInfo>();
            m_MagicList = new List<IntPtr>();
            m_AdminList = new List<TAdminInfo>();
            m_MerchantList = new List<TMerchant>();
            QuestNPCList = new List<TNormNpc>();
            m_ChangeServerList = new List<TSwitchDataInfo>();
            m_MagicEventList = new List<TMagicEvent>();
            m_MapMonGenCountList = new List<TMapMonGenCount>();
            boItemEvent = false;
            dwProcessMerchantTimeMin = 0;
            dwProcessMerchantTimeMax = 0;
            dwProcessNpcTimeMin = 0;
            dwProcessNpcTimeMax = 0;
            m_NewHumanList = new List<TPlayObject>();
            m_ListOfGateIdx = new ArrayList();
            m_ListOfSocket = new ArrayList();
            OldMagicList = new List<IntPtr>();
            EffectList = new List<TEnvirnoment>();
            m_TargetList = new List<TPlayObject>();// 雷炎地图(中魔法的对像)
            m_boStartLoadMagic = false;
            m_dwSearchTick = HUtil32.GetTickCount();
            m_dwGetTodyDayDateTick = HUtil32.GetTickCount();
            m_TodayDate = new DateTime();
            m_PlayObjectLevelList = new TStringList();// 人物排行 等级
            m_WarrorObjectLevelList = new TStringList();// 战士等级排行
            m_WizardObjectLevelList = new TStringList();// 法师等级排行
            m_TaoistObjectLevelList = new TStringList();// 道士等级排行
            m_PlayObjectMasterList = new TStringList();// 徒弟数排行
            m_HeroObjectLevelList = new TStringList();// 英雄等级排行
            m_WarrorHeroObjectLevelList = new TStringList();// 英雄战士等级排行
            m_WizardHeroObjectLevelList = new TStringList();// 英雄法师等级排行
            m_TaoistHeroObjectLevelList = new TStringList();// 英雄道士等级排行
            bo_ReadPlayLeveList = false;// 是否正在读取排行文件
            InitProcessUserMessage();
        }

        ~TUserEngine()
        {
            int I;
            int II;
            TMonInfo MonInfo;
            TMonGenInfo MonGenInfo;
            TMagicEvent MagicEvent;
            ArrayList TmpList;
            if (m_LoadPlayList.Count > 0)
            {
                for (I = 0; I < m_LoadPlayList.Count; I++)
                {
                    if (m_LoadPlayList[I] != null)
                    {
                        Dispose(m_LoadPlayList[I]);
                    }
                }
            }
            if (m_PlayObjectList.Count > 0)
            {
                for (I = 0; I < m_PlayObjectList.Count; I++)
                {
                    Dispose(m_PlayObjectList[I]);
                }
            }
            if (m_PlayObjectFreeList.Count > 0)
            {
                for (I = 0; I < m_PlayObjectFreeList.Count; I++)
                {
                    Dispose(m_PlayObjectFreeList[I]);
                }
            }
            if (m_MonObjectList.Count > 0)// 火龙殿中的守护兽
            {
                for (I = 0; I < m_MonObjectList.Count; I++)
                {
                    Dispose(m_MonObjectList[I]);
                }
            }
            if (m_ChangeHumanDBGoldList.Count > 0)
            {
                for (I = 0; I < m_ChangeHumanDBGoldList.Count; I++)
                {
                    if (m_ChangeHumanDBGoldList[I] != null)
                    {
                        Dispose(m_ChangeHumanDBGoldList[I]);
                    }
                }
            }
            if (StdItemList.Count > 0)
            {
                for (I = 0; I < StdItemList.Count; I++)
                {
                    if (StdItemList[I] != null)
                    {
                        Dispose(StdItemList[I]);
                    }
                }
            }
            if (MonsterList.Count > 0)
            {
                for (I = 0; I < MonsterList.Count; I++)
                {
                    MonInfo = MonsterList[I];
                    if (MonInfo.ItemList != null)
                    {
                        if (MonInfo.ItemList.Count > 0)
                        {
                            for (II = 0; II < MonInfo.ItemList.Count; II++)
                            {
                                if (MonInfo.ItemList[II] != null)
                                {
                                    Dispose(MonInfo.ItemList[II]);
                                }
                            }
                        }
                    }
                    Dispose(MonInfo);
                }
            }
            unsafe
            {
                if (m_MagicList.Count > 0)
                {
                    for (I = 0; I < m_MagicList.Count; I++)
                    {
                        if (m_MagicList[I] != null)
                        {
                            Dispose(m_MagicList[I]);
                        }
                    }
                }
            }
            if (m_AdminList != null)
            {
                if (m_AdminList.Count > 0)
                {
                    for (I = 0; I < m_AdminList.Count; I++)
                    {
                        if (m_AdminList[I] != null)
                        {
                            Dispose(m_AdminList[I]);
                            m_AdminList[I] = null;
                        }
                    }
                }
            }
            if (m_MerchantList.Count > 0)
            {
                for (I = 0; I < m_MerchantList.Count; I++)
                {
                    m_MerchantList[I] = null;
                    Dispose(m_MerchantList[I]);
                }
            }
            if (QuestNPCList.Count > 0)
            {
                for (I = 0; I < QuestNPCList.Count; I++)
                {
                    Dispose(QuestNPCList[I]);
                }
            }
            if (m_ChangeServerList.Count > 0)
            {
                for (I = 0; I < m_ChangeServerList.Count; I++)
                {
                    if (m_ChangeServerList[I] != null)
                    {
                        Dispose(m_ChangeServerList[I]);
                    }
                }
            }
            if (m_MagicEventList.Count > 0)
            {
                for (I = 0; I < m_MagicEventList.Count; I++)
                {
                    MagicEvent = (M2Server.TMagicEvent)m_MagicEventList[I];
                    if (MagicEvent.BaseObjectList != null)
                    {
                    }
                    Dispose(MagicEvent);
                }
            }
            if (OldMagicList.Count > 0)
            {
                for (I = 0; I < OldMagicList.Count; I++)
                {
                    //TmpList = ((OldMagicList[I]) as ArrayList);
                    //if (TmpList.Count > 0)
                    //{
                    //for (II = 0; II < TmpList.Count; II ++ )
                    //{
                    //    if (((TMagic)(TmpList[II])) != null)
                    //    {
                    //        Dispose(((TMagic)(TmpList[II])));
                    //    }
                    //}
                    //}
                }
            }
            if (m_MapMonGenCountList.Count > 0)
            {
                for (I = 0; I < m_MapMonGenCountList.Count; I++)
                {
                    if (((m_MapMonGenCountList[I]) as TMapMonGenCount) != null)
                    {
                        Dispose(((m_MapMonGenCountList[I]) as TMapMonGenCount));
                    }
                }
            }
            // 雷电 岩浆地图
            // 雷炎地图(中魔法的对像)
            if (EffectList.Count > 0)
            {
                for (I = EffectList.Count - 1; I >= 0; I--)
                {
                    if (EffectList[I] != null)
                    {
                        Dispose(EffectList[I]);
                        EffectList.RemoveAt(I);
                    }
                }
            }
            if (m_PlayObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_PlayObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_PlayObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_PlayObjectLevelList[I])));
                    //}
                }
            }
            // 人物排行 等级
            if (m_WarrorObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_WarrorObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_WarrorObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WarrorObjectLevelList[I])));
                    //}
                }
            }
            // 战士等级排行

            if (m_WizardObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_WizardObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_WizardObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WizardObjectLevelList[I])));
                    //}
                }
            }
            // 法师等级排行

            if (m_TaoistObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_TaoistObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_TaoistObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_TaoistObjectLevelList[I])));
                    //}
                }
            }
            // 道士等级排行

            if (m_PlayObjectMasterList.Count > 0)
            {
                for (I = 0; I < m_PlayObjectMasterList.Count; I++)
                {
                    //if (((string[])(m_PlayObjectMasterList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_PlayObjectMasterList[I])));
                    //}
                }
            }
            // 徒弟数排行

            if (m_HeroObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_HeroObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_HeroObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_HeroObjectLevelList[I])));
                    //}
                }
            }
            // 英雄等级排行
            if (m_WarrorHeroObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_WarrorHeroObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_WarrorHeroObjectLevelList.Objects[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WarrorHeroObjectLevelList.Objects[I])));
                    //}
                }
            }

            // 英雄战士等级排行
            if (m_WizardHeroObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_WizardHeroObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_WizardHeroObjectLevelList.Objects[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WizardHeroObjectLevelList.Objects[I])));
                    //}
                }
            }
            // 英雄法师等级排行
            if (m_TaoistHeroObjectLevelList.Count > 0)
            {
                for (I = 0; I < m_TaoistHeroObjectLevelList.Count; I++)
                {
                    //if (((string[])(m_TaoistHeroObjectLevelList.Objects[I])) != null)
                    //{
                    //    Dispose(((string[])(m_TaoistHeroObjectLevelList.Objects[I])));
                    //}
                }
            }
            // 英雄道士等级排行
            //DeleteCriticalSection(m_LoadPlaySection);
        }

        /// <summary>
        /// 初始化消息处理进程
        /// </summary>
        internal void InitProcessUserMessage()
        {
            FProcessUserMessage = new Dictionary<int, TProcessUserMessage>();//初始化消息处理

            FProcessUserMessage[Grobal2.CM_QUERYUSERNAME] = ProcessMessage;
            FProcessUserMessage[Grobal2.CM_HEROATTACKTARGET] = ProcessMessage;
            FProcessUserMessage[Grobal2.CM_HEROPROTECT] = ProcessMessage;

            //处理 施放魔法
            FProcessUserMessage[Grobal2.CM_SPELL] = ProcessSpell;
            FProcessUserMessage[Grobal2.CM_USEBATTER] = ProcessSpell;

            //处理玩家说话消息
            FProcessUserMessage[Grobal2.CM_SAY] = ProcessUserSayMessage;

            //处理 装备掉落 装备装配等动作消息
            FProcessUserMessage[Grobal2.CM_DROPITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_HERODROPITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_TAKEONITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_TAKEOFFITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_1005] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_MERCHANTDLGSELECT] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_PlAYDRINKDLGSELECT] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_MERCHANTQUERYSELLPRICE] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERSELLITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERBUYITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERGETDETAILITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SENDSELLOFFITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SENDSELLOFFITEMLIST] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SENDQUERYSELLOFFITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SENDBUYSELLOFFITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_HEROTAKEONITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_HEROTAKEOFFITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_TAKEOFFITEMHEROBAG] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_TAKEOFFITEMTOMASTERBAG] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SENDITEMTOMASTERBAG] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SENDITEMTOHEROBAG] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_HEROTAKEONITEMFORMMASTERBAG] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_TAKEONITEMFORMHEROBAG] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_REPAIRFIRDRAGON] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_REPAIRDRAGON] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_REPAIRFINEITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CREATEGROUP] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_ADDGROUPMEMBER] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_DELGROUPMEMBER] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERREPAIRITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_MERCHANTQUERYREPAIRCOST] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_DEALTRY] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_DEALADDITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_DEALDELITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CHALLENGETRY] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CHALLENGEADDITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CHALLENGEDELITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CHALLENGECANCEL] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CHALLENGECHGGOLD] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CHALLENGECHGDIAMOND] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CHALLENGEEND] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SELLOFFADDITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SELLOFFDELITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SELLOFFCANCEL] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SELLOFFEND] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CANCELSELLOFFITEMING] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SELLOFFBUYCANCEL] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SELLOFFBUY] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_REFINEITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERSTORAGEITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERPLAYDRINKITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERTAKEBACKSTORAGEITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERMAKEDRUGITEM] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_GUILDADDMEMBER] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_GUILDDELMEMBER] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_GUILDUPDATENOTICE] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_OPENBOXS] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_MOVEBOXS] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_GETBOXS] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_SELGETHERO] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_PlAYDRINKGAME] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_BEGINMAKEWINE] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CLICKSIGHICON] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_CLICKCRYSTALEXPTOP] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_DrinkUpdateValue] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_USERPLAYDRINK] = ProcessClientMessage;
            FProcessUserMessage[Grobal2.CM_GUILDUPDATERANKINFO] = ProcessClientMessage;

            //处理密码相关消息
            FProcessUserMessage[Grobal2.CM_PASSWORD] = ProcessPassWordMessage;
            FProcessUserMessage[Grobal2.CM_CHGPASSWORD] = ProcessPassWordMessage;
            FProcessUserMessage[Grobal2.CM_SETPASSWORD] = ProcessPassWordMessage;

            //处理玩家动作 走路 攻击等
            FProcessUserMessage[Grobal2.CM_HORSERUN] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_TURN] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_WALK] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_SITDOWN] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_RUN] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_HIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_HEAVYHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_BIGHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_POWERHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_LONGHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_CRSHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_TWNHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_QTWINHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_CIDHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_WIDEHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_PHHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_DAILY] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_FIREHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_4FIREHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_SANJUEHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_ZHUIXINHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_DUANYUEHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_HENGSAOHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_4LONGHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_YUANYUEHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_YTPDHIT] = ProcessActionMessage;
            FProcessUserMessage[Grobal2.CM_XPYJHIT] = ProcessActionMessage;// 开天斩重击 开天斩轻击 龙影剑法 逐日剑法 烈火 4级烈火 倚天劈地 血魄一击

            FProcessUserMessage[Grobal2.CM_OPENSHOP] = ProcessOpenShopMessage;

            FProcessUserMessage[Grobal2.CM_BUYSHOPITEMGIVE] = ProcessUserActionByShop;
            FProcessUserMessage[Grobal2.CM_EXCHANGEGAMEGIRD] = ProcessUserActionByShop;

            FProcessUserMessage[Grobal2.CM_QUERYUSERLEVELSORT] = ProcessUserRankMessage;

            FProcessUserMessage[Grobal2.CM_HEROGOTETHERUSESPELL] = ProcessHeroSpellMesagae;

            FProcessUserMessage[Grobal2.CM_ADJUST_BONUS] = ProcessBonusMessage;
        }

        /// <summary>
        /// 查询玩家名字 英雄攻击 英雄守护等消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendMsg(PlayObject, DefMsg.Ident, 0, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, "");
        }

        /// <summary>
        /// 处理技能消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessSpell(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            if (GameConfig.boSpellSendUpdateMsg)// 使用UpdateMsg 可以防止消息队列里有多个操作
            {
                PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, HUtil32.LoWord(DefMsg.Recog), HUtil32.HiWord(DefMsg.Recog), HUtil32.MakeLong(DefMsg.Param, DefMsg.Series), "");
            }
            else
            {
                PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, HUtil32.LoWord(DefMsg.Recog), HUtil32.HiWord(DefMsg.Recog), HUtil32.MakeLong(DefMsg.Param, DefMsg.Series), "");
            }
        }

        /// <summary>
        /// 装备掉落 穿戴 取下等操作消息处理
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessClientMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            //装备脱下到英雄包裹 装备脱下到主人包裹 主人包裹到英雄包裹 英雄包裹到主人包裹 从主人包裹穿装备到英雄包裹 从英雄包裹穿装备到主人包裹 接收客户发来的:修补火龙之心
            //修补祝福罐.魔令包  修补火云石 客户端点挑战 玩家把物品放到挑战框中 玩家从挑战框中取回物品 玩家取消挑战 客户端把金币放到挑战框中
            //客户端把金刚石放到挑战框中 挑战抵押物品结束 元宝寄售系统 客户端往出售物品窗口里加物品 客户端删除出售物品窗里的物品  客户端取消元宝寄售 
            //客户端元宝寄售结束   取消正在寄售的物品 (出售人) 取消寄售 物品购买 (购买人) 确定购买寄售物品 客户端发送粹练物品 请酒框
            //CM_WANTMINIMAP, CM_GUILDHOME, 转动宝箱 取得宝箱物品 取回英雄 猜拳码数 开始酿酒(即把材料全放上窗口) 点击感叹号
            //点击天地结晶获得经验 把消息数据传给ObjBase单元
            PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, sMsg);
        }

        /// <summary>
        /// 玩家动作消息处理 （走路 挖物品等）
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessActionMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            if (GameConfig.boActionSendActionMsg)// 使用UpdateMsg 可以防止消息队列里有多个操作
            {
                PlayObject.SendActionMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, HUtil32.LoWord(DefMsg.Recog), HUtil32.HiWord(DefMsg.Recog), 0, "");
            }
            else
            {
                PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, HUtil32.LoWord(DefMsg.Recog), HUtil32.HiWord(DefMsg.Recog), 0, "");
            }
        }

        /// <summary>
        /// 处理密码相关消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessPassWordMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Param, DefMsg.Recog, DefMsg.Series, DefMsg.Tag, sMsg);
        }

        /// <summary>
        /// 处理玩家说话消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessUserSayMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            if (DefMsg.Recog > 0)
            {
                PlayObject.m_btHearMsgFColor = (byte)DefMsg.Param;
                PlayObject.m_btWhisperMsgFColor = (byte)DefMsg.Param;
            }
            else
            {
                PlayObject.m_btHearMsgFColor = GameConfig.btHearMsgFColor;
                PlayObject.m_btWhisperMsgFColor = GameConfig.btWhisperMsgFColor;
            }
            PlayObject.SendMsg(PlayObject, Grobal2.CM_SAY, 0, 0, 0, 0, sMsg);
        }

        /// <summary>
        /// 处理商铺消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessOpenShopMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, "");
        }

        /// <summary>
        /// 处理玩家对象灵符 赠送灵符消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessUserActionByShop(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, sMsg);
        }

        /// <summary>
        /// 处理玩家购买商场物品消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessUserBuyGameShopMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, sMsg);
        }

        /// <summary>
        /// 处理排行版消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessUserRankMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, 0, DefMsg.Param, DefMsg.Tag, DefMsg.Recog, "");
        }

        /// <summary>
        /// 处理英雄技能消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessHeroSpellMesagae(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, 0, 0, 0, 0, "");
        }

        /// <summary>
        /// 处理属性点消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="sMsg"></param>
        internal void ProcessBonusMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string sMsg)
        {
            PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, sMsg);
        }

        /// <summary>
        /// 处理玩家消息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="DefMsg"></param>
        /// <param name="Buff"></param>
        public unsafe void ProcessUserMessage(TPlayObject PlayObject, TDefaultMessage* DefMsg, byte* Buff)
        {
            string sMsg = "";
            const string sExceptionMsg = "{异常} TUserEngine::ProcessUserMessage..";
            if ((DefMsg == null) || (PlayObject == null))
            {
                return;
            }
            try
            {
                sMsg = Buff == null ? "" : EncryptUnit.DeCodeString(HUtil32.StrPas(Buff));//解码
                if (DefMsg->nSessionID != PlayObject.m_nSessionID)//检查客户端会话ID是否正确, DefMsg.nSessionID客户端发来的值
                {
                    return;
                }
                if (DefMsg->Ident >= 0) //发送过来到消息编号大于0，并且消息存在处理列表
                {
                    if (FProcessUserMessage.ContainsKey(DefMsg->Ident)) //如果该消息编号对应的方法存在
                    {
                        FProcessUserMessage[DefMsg->Ident](PlayObject, *DefMsg, sMsg);
                    }
                    else
                    {
                        PlayObject.SendMsg(PlayObject, DefMsg->Ident, DefMsg->Series, DefMsg->Recog, DefMsg->Param, DefMsg->Tag, sMsg);
                    }
                    if (PlayObject.m_boReadyRun)
                    {
                        // 半月// 烈火// 4级烈火// 抱月刀// 逐日剑法// 破魂斩// 开天斩重击// 开天斩轻击// 龙影剑法
                        if (DefMsg->Ident >= Grobal2.CM_TURN && DefMsg->Ident <= Grobal2.CM_YUANYUEHIT)
                        {
                            PlayObject.m_dwRunTick -= 100;
                        }
                        #region 以前代码
                        //switch (DefMsg->Ident)
                        //{
                        //    case Grobal2.CM_TURN:
                        //    case Grobal2.CM_WALK:
                        //    case Grobal2.CM_SITDOWN:
                        //    case Grobal2.CM_RUN:
                        //    case Grobal2.CM_HIT:
                        //    case Grobal2.CM_HEAVYHIT:
                        //    case Grobal2.CM_BIGHIT:
                        //    case Grobal2.CM_POWERHIT:
                        //    case Grobal2.CM_LONGHIT:
                        //    case Grobal2.CM_WIDEHIT:
                        //    case Grobal2.CM_FIREHIT:
                        //    case Grobal2.CM_4FIREHIT:
                        //    case Grobal2.CM_CRSHIT:
                        //    case Grobal2.CM_DAILY:
                        //    case Grobal2.CM_PHHIT:
                        //    case Grobal2.CM_TWNHIT:
                        //    case Grobal2.CM_QTWINHIT:
                        //    case Grobal2.CM_CIDHIT:
                        //    case Grobal2.CM_4LONGHIT:
                        //    case Grobal2.CM_YUANYUEHIT:
                        //        PlayObject.m_dwRunTick -= 100;
                        //        break;
                        //}
                        #endregion
                    }
                }
                else
                {
                    M2Share.MainOutMessage(String.Format("[异常封包]->[名字：{0}] [IP:{1}] [编号：{2}]", PlayObject.m_sCharName, PlayObject.m_sIPLocal, DefMsg->Ident));
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        public bool GetPlayObjectLevelList_IsFileInUse(string fName)
        {
            return false;
        }

        /// <summary>
        /// 读取排行榜文件
        /// </summary>
        private void GetPlayObjectLevelList()
        {
            //string sHumDBFile;
            //string sWarrHum;
            //string sWizardHum;
            //string sTaosHum;
            //string sMaster;
            //string sAllHero;
            //string sWarrHero;
            //string sWizardHero;
            //string sTaosHero;
            //TStringList LoadList;
            //int I;
            //string sLineText;
            //string sData;
            //string s_Master;
            //string CharName;
            //string HeroName;
            //byte nCode;
            //nCode = 0;
            //bo_ReadPlayLeveList = true;
            //try {
            //    EnterCriticalSection(M2Share.HumanSortCriticalSection);
            //    LoadList = new TStringList();
            //    try {
            //        EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            //        try {
            //            nCode = 1;
            //            sHumDBFile = GameConfig.sSortDir + "AllHum.DB";
            //            sWarrHum = GameConfig.sSortDir + "WarrHum.DB";
            //            sWizardHum = GameConfig.sSortDir + "WizardHum.DB";
            //            sTaosHum = GameConfig.sSortDir + "TaosHum.DB";
            //            sMaster = GameConfig.sSortDir + "Master.DB";
            //            sAllHero = GameConfig.sSortDir + "AllHero.DB";
            //            sWarrHero = GameConfig.sSortDir + "WarrHero.DB";
            //            sWizardHero = GameConfig.sSortDir + "WizardHero.DB";
            //            sTaosHero = GameConfig.sSortDir + "TaosHero.DB";
            //            nCode = 2;
            //            if (File.Exists(sHumDBFile) && (!GetPlayObjectLevelList_IsFileInUse(sHumDBFile)))
            //            {
            //                // 人物等级总排行
            //                LoadList.LoadFromFile(sHumDBFile);
            //                nCode = 3;
            //                if (m_PlayObjectLevelList.Count > 0)
            //                {
            //                    // 20080629
            //                    nCode = 4;

            //                    for (I = m_PlayObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        // 20080527 可读文件,才清空原来的排行数据
            //                        if (((string[])(m_PlayObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_PlayObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_PlayObjectLevelList.Clear();
            //                }
            //                nCode = 5;
            //                if (LoadList.Count > 0)
            //                {
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[0] != ';'))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();

            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;

            //                            m_PlayObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 6;
            //            if (File.Exists(sWarrHum) && (!GetPlayObjectLevelList_IsFileInUse(sWarrHum)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sWarrHum);
            //                nCode = 7;
            //                if (m_WarrorObjectLevelList.Count > 0)
            //                {
            //                    for (I = m_WarrorObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        // 可读文件,才清空原来的排行数据
            //                        if (((string[])(m_WarrorObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_WarrorObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_WarrorObjectLevelList.Clear();// 战士等级排行
            //                }
            //                nCode = 8;
            //                if (LoadList.Count > 0)
            //                {
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
            //                            //FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
            //                            m_WarrorObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 9;
            //            if (File.Exists(sWizardHum) && (!GetPlayObjectLevelList_IsFileInUse(sWizardHum)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sWizardHum);
            //                nCode = 10;
            //                if (m_WizardObjectLevelList.Count > 0)
            //                {
            //                    for (I = m_WizardObjectLevelList.Count - 1; I >= 0; I-- )// 可读文件,才清空原来的排行数据
            //                    {
            //                        if (((string[])(m_WizardObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_WizardObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_WizardObjectLevelList.Clear;
            //                // 法师等级排行
            //                }
            //                nCode = 11;
            //                if (LoadList.Count > 0)
            //                {
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
            //                            m_WizardObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 12;
            //            if (File.Exists(sTaosHum) && (!GetPlayObjectLevelList_IsFileInUse(sTaosHum)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sTaosHum);
            //                nCode = 13;
            //                if (m_TaoistObjectLevelList.Count > 0)
            //                {
            //                    for (I = m_TaoistObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        // 可读文件,才清空原来的排行数据
            //                        if (((string[])(m_TaoistObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_TaoistObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_TaoistObjectLevelList.Clear;// 道士等级排行
            //                
            //                }
            //                nCode = 14;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();

            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;

            //                            m_TaoistObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 15;
            //            if (File.Exists(sMaster) && (!GetPlayObjectLevelList_IsFileInUse(sMaster)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sMaster);
            //                nCode = 16;
            //                if (m_PlayObjectMasterList.Count > 0)
            //                {
            //                    // 20080629
            //                    for (I = m_PlayObjectMasterList.Count - 1; I >= 0; I-- )
            //                    {
            //                        if (((string[])(m_PlayObjectMasterList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_PlayObjectMasterList.Objects[I])));
            //                        }
            //                    }
            //                    m_PlayObjectMasterList.Clear;
            //                // 徒弟数排行
            //                }
            //                nCode = 17;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
            //                            m_PlayObjectMasterList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 18;
            //            if (File.Exists(sAllHero) && (!GetPlayObjectLevelList_IsFileInUse(sAllHero)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sAllHero);
            //                nCode = 19;
            //                if (m_HeroObjectLevelList.Count > 0)
            //                {
            //                    // 20080629
            //                    for (I = m_HeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        if (((string[])(m_HeroObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_HeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_HeroObjectLevelList.Clear;
            //                // 英雄等级排行
            //                }
            //                nCode = 20;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
            //                            m_HeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 21;
            //            if (File.Exists(sWarrHero) && (!GetPlayObjectLevelList_IsFileInUse(sWarrHero)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sWarrHero);
            //                nCode = 22;
            //                if (m_WarrorHeroObjectLevelList.Count > 0)
            //                {
            //                    // 20090114
            //                    for (I = m_WarrorHeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        if (((string[])(m_WarrorHeroObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_WarrorHeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_WarrorHeroObjectLevelList.Clear;
            //                // 英雄战士等级排行
            //                }
            //                nCode = 23;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
            //                            m_WarrorHeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 24;
            //            if (File.Exists(sWizardHero) && (!GetPlayObjectLevelList_IsFileInUse(sWizardHero)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sWizardHero);
            //                nCode = 25;
            //                if (m_WizardHeroObjectLevelList.Count > 0)
            //                {
            //                    // 20090114
            //                    for (I = m_WizardHeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        if (((string[])(m_WizardHeroObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_WizardHeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_WizardHeroObjectLevelList.Clear;
            //                // 英雄法师等级排行
            //                }
            //                nCode = 26;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
            //                            m_WizardHeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 27;
            //            if (File.Exists(sTaosHero) && (!GetPlayObjectLevelList_IsFileInUse(sTaosHero)))
            //            {
            //                LoadList.Clear();
            //                LoadList.LoadFromFile(sTaosHero);
            //                nCode = 30;
            //                if (m_TaoistHeroObjectLevelList.Count > 0)
            //                {
            //                    // 20090114
            //                    nCode = 31;
            //                    for (I = m_TaoistHeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        nCode = 32;
            //                        if (((string[])(m_TaoistHeroObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_TaoistHeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_TaoistHeroObjectLevelList.Clear;
            //                // 英雄道士等级排行
            //                }
            //                nCode = 29;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
            //                            m_TaoistHeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch {
            //            M2Share.MainOutMessage("{异常} TUserEngine::GetPlayObjectLevelList Code:" + (nCode).ToString());
            //        }
            //    } finally {
            //        Dispose(LoadList);
            //        LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            //    }
            //} finally {
            //    LeaveCriticalSection(M2Share.HumanSortCriticalSection);
            //    bo_ReadPlayLeveList = false;
            //    // 重新记时读取间隔 200808029
            //    dwGetOrderTick = HUtil32.GetTickCount();
            //}
        }

        /// <summary>
        /// 初始化NPC和怪物种族
        /// </summary>
        public void Initialize()
        {
            TMonGenInfo MonGen;
            MerchantInitialize();
            NPCinitialize();
            if (m_MonGenList.Count > 0)
            {
                foreach (var item in m_MonGenList)
                {
                    MonGen = item;
                    if (MonGen != null)
                    {
                        MonGen.nRace = GetMonRace(MonGen.sMonName);
                    }
                }
            }
        }

        public int AddMapMonGenCount(string sMapName, int nMonGenCount)
        {
            int result = -1;
            TMapMonGenCount MapMonGenCount;
            bool boFound = false;
            if (m_MapMonGenCountList.Count > 0)
            {
                foreach (var item in m_MapMonGenCountList)
                {
                    MapMonGenCount = item;
                    if (MapMonGenCount != null)
                    {
                        if (string.Compare(MapMonGenCount.sMapName, sMapName, true) == 0)
                        {
                            MapMonGenCount.nMonGenCount += nMonGenCount;
                            result = MapMonGenCount.nMonGenCount;
                            boFound = true;
                        }
                    }
                }
            }
            if (!boFound)
            {
                MapMonGenCount = new TMapMonGenCount();
                MapMonGenCount.sMapName = sMapName;
                MapMonGenCount.nMonGenCount = nMonGenCount;
                MapMonGenCount.dwNotHumTimeTick = HUtil32.GetTickCount();
                MapMonGenCount.dwMakeMonGenTimeTick = HUtil32.GetTickCount();
                MapMonGenCount.nClearCount = 0;
                MapMonGenCount.boNotHum = true;
                m_MapMonGenCountList.Add(MapMonGenCount);
                result = MapMonGenCount.nMonGenCount;
                Dispose(MapMonGenCount);
            }
            return result;
        }

        /// <summary>
        /// 取怪物的种族
        /// </summary>
        /// <param name="sMonName"></param>
        /// <returns></returns>
        public int GetMonRace(string sMonName)
        {
            int result = -1;
            TMonInfo MonInfo;
            if (MonsterList.Count > 0)
            {
                MonInfo = MonsterList.Find(delegate(TMonInfo M)
                {
                    return M.sName == sMonName;
                });
                if (MonInfo != null)
                {
                    result = MonInfo.btRace;
                }
            }
            return result;
        }

        /// <summary>
        /// 交易NPC初始化
        /// </summary>
        private void MerchantInitialize()
        {
            TMerchant Merchant;
            int MerchantCount = m_MerchantList.Count;
            lock (m_MerchantList)
            {
                try
                {
                    for (int I = m_MerchantList.Count - 1; I >= 0; I--)
                    {
                        if (m_MerchantList.Count <= 0)
                        {
                            break;
                        }
                        Merchant = m_MerchantList[I];
                        if (Merchant != null)
                        {
                            Merchant.m_PEnvir = M2Share.g_MapManager.FindMap(Merchant.m_sMapName);
                            if (Merchant.m_PEnvir != null)
                            {
                                Merchant.Initialize();
                                if (Merchant.m_boAddtoMapSuccess && (!Merchant.m_boIsHide))
                                {
                                    M2Share.MainOutMessage(string.Format("交易NPC 初始化失败...{0} {1} [{2}:{3}]", Merchant.m_sCharName,
                                        Merchant.m_sMapName, Merchant.m_nCurrX, Merchant.m_nCurrY));
                                    m_MerchantList.RemoveAt(I);
                                    Dispose(Merchant);
                                }
                                else
                                {
                                    Merchant.AddMapCount();
                                    Merchant.LoadNpcScript();
                                    Merchant.LoadNPCData();
                                }
                            }
                            else
                            {
                                M2Share.MainOutMessage(Merchant.m_sCharName + "交易NPC 初始化失败... (所在地图不存在)");
                                m_MerchantList.RemoveAt(I);
                                Dispose(Merchant);
                            }
                        }
                    }
                    M2Share.OutInfoMessage(string.Format("初始化交易NPC [{0}/{1}]", m_MerchantList.Count, MerchantCount));
                }
                finally
                {
                }
            }
        }

        /// <summary>
        /// 管理NPC初始化
        /// </summary>
        private void NPCinitialize()
        {
            TNormNpc NormNpc;
            int NormNpcCount = QuestNPCList.Count;
            for (int I = QuestNPCList.Count - 1; I >= 0; I--)
            {
                if (QuestNPCList.Count <= 0)
                {
                    break;
                }
                NormNpc = QuestNPCList[I];
                if (NormNpc != null)
                {
                    NormNpc.m_PEnvir = M2Share.g_MapManager.FindMap(NormNpc.m_sMapName);
                    if (NormNpc.m_PEnvir != null)
                    {
                        NormNpc.Initialize();
                        if (NormNpc.m_boAddtoMapSuccess && (!NormNpc.m_boIsHide))
                        {
                            M2Share.MainOutMessage(NormNpc.m_sCharName + " Npc 初始化失败... ");
                            QuestNPCList.RemoveAt(I);
                            Dispose(NormNpc);
                            NormNpc = null;
                        }
                        else
                        {
                            NormNpc.AddMapCount();
                            NormNpc.LoadNpcScript();
                        }
                    }
                    else
                    {
                        M2Share.MainOutMessage(NormNpc.m_sCharName + " Npc 初始化失败... (npc.PEnvir=nil) ");
                        QuestNPCList.RemoveAt(I);
                        Dispose(NormNpc);
                        NormNpc = null;
                    }
                }
            }
            M2Share.OutInfoMessage(string.Format("初始化管理NPC [{0}/{1}]", QuestNPCList.Count, NormNpcCount));
        }

        private int GetLoadPlayCount()
        {
            return m_LoadPlayList.Count;
        }

        /// <summary>
        /// 获取在线玩家数量
        /// </summary>
        /// <returns></returns>
        private int GetOnlineHumCount()
        {
            return m_PlayObjectList.Count;
        }

        /// <summary>
        /// 取玩家数量
        /// </summary>
        /// <returns></returns>
        private int GetUserCount()
        {
            return m_PlayObjectList.Count;
        }

        /// <summary>
        /// 取自动挂机人物数量
        /// </summary>
        /// <returns></returns>
        private int GetAutoAddExpPlayCount()
        {
            int result = 0;
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                result = m_PlayObjectList.FindAll(delegate(TPlayObject PlayObject)
                {
                    return PlayObject.m_boNotOnlineAddExp;
                }).Count();
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 帐号是否已经登录
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sChrName"></param>
        /// <returns></returns>
        public bool ProcessHumans_IsLogined(string sAccount, string sChrName)
        {
            bool result = false;
            if (M2Share.FrontEngine.InSaveRcdList(sAccount, sChrName))
            {
                result = true;
            }
            else
            {
                if (m_PlayObjectList.Count > 0)
                {
                    foreach (var item in m_PlayObjectList)
                    {
                        if (string.Compare(item.m_sUserID, sAccount, true) == 0 && string.Compare(item.m_sCharName, sChrName, true) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 制造新的人物
        /// </summary>
        /// <param name="UserOpenInfo"></param>
        /// <returns></returns>
        public TPlayObject MakeNewHuman(TUserOpenInfo UserOpenInfo)
        {
            TPlayObject result = null;
            TPlayObject PlayObject;
            TAbility Abil;
            TEnvirnoment Envir;
            int nC;
            TSwitchDataInfo SwitchDataInfo;
            TUserCastle Castle;
            try
            {
                PlayObject = new TPlayObject();
                SwitchDataInfo = null;
                if (SwitchDataInfo == null)
                {
                    unsafe
                    {
                        fixed (THumDataInfo* data = &UserOpenInfo.HumanRcd)
                        {
                            GetHumData(PlayObject, data);//取人物数据
                        }
                    }
                    PlayObject.m_btRaceServer = Grobal2.RC_PLAYOBJECT;
                    if (PlayObject.m_sHomeMap == "")
                    {
                        //ReGetMap:
                        PlayObject.m_sHomeMap = GetHomeInfo(ref PlayObject.m_nHomeX, ref PlayObject.m_nHomeY);
                        PlayObject.m_sMapName = PlayObject.m_sHomeMap;
                        PlayObject.m_nCurrX = GetRandHomeX(PlayObject);
                        PlayObject.m_nCurrY = GetRandHomeY(PlayObject);
                        if (PlayObject.m_Abil.Level >= 0)
                        {
                            Abil = PlayObject.m_Abil;
                            Abil.Level = 1;
                            Abil.AC = 0;
                            Abil.MAC = 0;
                            Abil.DC = HUtil32.MakeLong(1, 2);
                            Abil.MC = HUtil32.MakeLong(1, 2);
                            Abil.SC = HUtil32.MakeLong(1, 2);
                            Abil.MP = 15;
                            Abil.HP = 15;
                            Abil.MaxHP = 15;
                            Abil.MaxMP = 15;
                            Abil.Exp = 10;
                            Abil.MaxExp = 100;
                            Abil.Weight = 100;
                            Abil.MaxWeight = 100;
                            PlayObject.m_boNewHuman = true;
                        }
                    }
                    Envir = M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, PlayObject.m_sMapName);
                    if (Envir != null)
                    {
                        if (Envir.m_boFight3Zone)// 是否在行会战争地图死亡
                        {
                            if ((PlayObject.m_Abil.HP <= 0) && (PlayObject.m_nFightZoneDieCount < 3))
                            {
                                PlayObject.m_Abil.HP = PlayObject.m_Abil.MaxHP;
                                PlayObject.m_Abil.MP = PlayObject.m_Abil.MaxMP;
                                PlayObject.m_boDieInFight3Zone = true;
                            }
                            else
                            {
                                PlayObject.m_nFightZoneDieCount = 0;
                            }
                        }
                    }
                    PlayObject.m_MyGuild = GuildManager.MemberOfGuild(PlayObject.m_sCharName); // 取玩家所属的行会
                    Castle = M2Share.g_CastleManager.InCastleWarArea(Envir, PlayObject.m_nCurrX, PlayObject.m_nCurrY);//是否是沙巴克成员
                    if ((Envir != null) && (Castle != null) && ((Castle.m_MapPalace == Envir) || Castle.m_boUnderWar))
                    {
                        Castle = M2Share.g_CastleManager.IsCastleMember(PlayObject);
                        if (Castle == null)
                        {
                            PlayObject.m_sMapName = PlayObject.m_sHomeMap;
                            PlayObject.m_nCurrX = PlayObject.m_nHomeX - 2 + HUtil32.Random(5);
                            PlayObject.m_nCurrY = PlayObject.m_nHomeY - 2 + HUtil32.Random(5);
                        }
                        else
                        {
                            if (Castle.m_MapPalace == Envir)
                            {
                                PlayObject.m_sMapName = Castle.GetMapName();
                                PlayObject.m_nCurrX = Castle.GetHomeX();
                                PlayObject.m_nCurrY = Castle.GetHomeY();
                            }
                        }
                    }
                    if (M2Share.g_MapManager.FindMap(PlayObject.m_sMapName) == null)
                    {
                        PlayObject.m_Abil.HP = 0;
                    }
                    if (PlayObject.m_Abil.HP <= 0)
                    {
                        PlayObject.ClearStatusTime();
                        if (PlayObject.PKLevel() < 2)// 没有红名
                        {
                            Castle = M2Share.g_CastleManager.IsCastleMember(PlayObject);
                            if ((Castle != null) && Castle.m_boUnderWar)
                            {
                                PlayObject.m_sMapName = Castle.m_sHomeMap;
                                PlayObject.m_nCurrX = Castle.GetHomeX();
                                PlayObject.m_nCurrY = Castle.GetHomeY();
                            }
                            else
                            {
                                PlayObject.m_sMapName = PlayObject.m_sHomeMap;
                                PlayObject.m_nCurrX = PlayObject.m_nHomeX - 2 + HUtil32.Random(5);
                                PlayObject.m_nCurrY = PlayObject.m_nHomeY - 2 + HUtil32.Random(5);
                            }
                        }
                        else
                        {
                            PlayObject.m_sMapName = GameConfig.sRedDieHomeMap; // '3'
                            PlayObject.m_nCurrX = HUtil32.Random(13) + GameConfig.nRedDieHomeX;// 839
                            PlayObject.m_nCurrY = HUtil32.Random(13) + GameConfig.nRedDieHomeY;// 668
                        }
                        PlayObject.m_Abil.HP = 14;
                    }
                    PlayObject.AbilCopyToWAbil();
                    Envir = M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, PlayObject.m_sMapName);
                    if (Envir == null)
                    {
                        PlayObject.m_nSessionID = UserOpenInfo.LoadUser.nSessionID;
                        PlayObject.m_nSocket = UserOpenInfo.LoadUser.nSocket;
                        PlayObject.m_nGateIdx = UserOpenInfo.LoadUser.nGateIdx;
                        PlayObject.m_nGSocketIdx = UserOpenInfo.LoadUser.nGSocketIdx;
                        PlayObject.m_WAbil = PlayObject.m_Abil;
                        PlayObject.m_nServerIndex = M2Share.g_MapManager.GetMapOfServerIndex(PlayObject.m_sMapName);
                        SendSwitchData(PlayObject, PlayObject.m_nServerIndex);
                        SendChangeServer(PlayObject, PlayObject.m_nServerIndex);
                        PlayObject = null;
                        return result;
                    }
                    nC = 0;
                    while (true)
                    {
                        if (Envir.CanWalk(PlayObject.m_nCurrX, PlayObject.m_nCurrY, true))
                        {
                            break;
                        }
                        PlayObject.m_nCurrX = PlayObject.m_nCurrX - 3 + HUtil32.Random(6);
                        PlayObject.m_nCurrY = PlayObject.m_nCurrY - 3 + HUtil32.Random(6);
                        nC++;
                        if (nC >= 5)
                        {
                            break;
                        }
                    }
                    if (!Envir.CanWalk(PlayObject.m_nCurrX, PlayObject.m_nCurrY, true))
                    {
                        PlayObject.m_sMapName = GameConfig.sHomeMap;
                        Envir = M2Share.g_MapManager.FindMap(GameConfig.sHomeMap);
                        PlayObject.m_nCurrX = GameConfig.nHomeX;
                        PlayObject.m_nCurrY = GameConfig.nHomeY;
                    }
                    PlayObject.m_PEnvir = Envir;
                    if (PlayObject.m_PEnvir == null)
                    {
                        M2Share.MainOutMessage("[错误] PlayObject.PEnvir = nil");
                        //goto ReGetMap; 
                    }
                    else
                    {
                        PlayObject.m_boReadyRun = false;
                    }
                }
                else
                {
                    unsafe
                    {
                        fixed (THumDataInfo* data = &UserOpenInfo.HumanRcd)
                        {
                            GetHumData(PlayObject, data);//取人物数据
                        }
                    }
                    PlayObject.m_sMapName = SwitchDataInfo.sMAP;
                    PlayObject.m_nCurrX = SwitchDataInfo.wX;
                    PlayObject.m_nCurrY = SwitchDataInfo.wY;
                    PlayObject.m_Abil = SwitchDataInfo.Abil;
                    PlayObject.m_WAbil = SwitchDataInfo.Abil;
                    LoadSwitchData(SwitchDataInfo, ref PlayObject);
                    DelSwitchData(SwitchDataInfo);
                    Envir = M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, PlayObject.m_sMapName);
                    if (Envir != null)
                    {
                        PlayObject.m_sMapName = GameConfig.sHomeMap;
                        PlayObject.m_nCurrX = GameConfig.nHomeX;
                        PlayObject.m_nCurrY = GameConfig.nHomeY;
                    }
                    else
                    {
                        if (!Envir.CanWalk(PlayObject.m_nCurrX, PlayObject.m_nCurrY, true))
                        {
                            PlayObject.m_sMapName = GameConfig.sHomeMap;
                            Envir = M2Share.g_MapManager.FindMap(GameConfig.sHomeMap);
                            PlayObject.m_nCurrX = GameConfig.nHomeX;
                            PlayObject.m_nCurrY = GameConfig.nHomeY;
                        }
                        PlayObject.AbilCopyToWAbil();
                        PlayObject.m_PEnvir = Envir;
                        if (PlayObject.m_PEnvir == null)
                        {
                            M2Share.MainOutMessage("[错误] PlayObject.PEnvir = nil");
                            //goto ReGetMap; 
                        }
                        else
                        {
                            PlayObject.m_boReadyRun = false;
                            PlayObject.m_boLoginNoticeOK = true;
                            PlayObject.bo6AB = true;
                        }
                    }
                }
                PlayObject.m_sUserID = UserOpenInfo.LoadUser.sAccount;
                PlayObject.m_sIPaddr = UserOpenInfo.LoadUser.sIPaddr;
                PlayObject.m_sIPLocal = M2Share.GetIPLocal(PlayObject.m_sIPaddr);
                PlayObject.m_nSocket = UserOpenInfo.LoadUser.nSocket;
                PlayObject.m_nGSocketIdx = UserOpenInfo.LoadUser.nGSocketIdx;
                PlayObject.m_nGateIdx = UserOpenInfo.LoadUser.nGateIdx;
                PlayObject.m_nSessionID = UserOpenInfo.LoadUser.nSessionID;
                PlayObject.m_nPayMent = UserOpenInfo.LoadUser.nPayMent;
                PlayObject.m_nPayMode = UserOpenInfo.LoadUser.nPayMode;
                PlayObject.m_nSoftVersionDateEx = M2Share.GetExVersionNO(UserOpenInfo.LoadUser.nSoftVersionDate, ref PlayObject.m_nSoftVersionDate);
                result = PlayObject;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine::MakeNewHuman");
            }
            return result;
        }

        private void ProcessHumans()
        {
            uint dwUsrRotTime;
            uint dwCheckTime;
            uint dwCurTick;
            byte nCheck30;
            bool boCheckTimeLimit;
            int nIdx;
            TPlayObject PlayObject = null;
            TUserOpenInfo UserOpenInfo;
            TGoldChangeInfo GoldChangeInfo;
            string LineNoticeMsg;
            if (m_boHumProcess)
            {
                return;
            }
            m_boHumProcess = true;
            try
            {
                nCheck30 = 0;
                dwCheckTime = HUtil32.GetTickCount();
                if ((HUtil32.GetTickCount() - m_dwProcessLoadPlayTick) > 200)
                {
                    nCheck30 = 21;
                    m_dwProcessLoadPlayTick = HUtil32.GetTickCount();
                    try
                    {
                        HUtil32.EnterCriticalSection(m_LoadPlaySection);
                        try
                        {
                            if (m_LoadPlayList.Count > 0)
                            {
                                for (int I = 0; I < m_LoadPlayList.Count; I++)
                                {
                                    nCheck30 = 22;
                                    UserOpenInfo = m_LoadPlayList[I];
                                    if (!UserOpenInfo.LoadUser.boIsHero)
                                    {
                                        nCheck30 = 23;
                                        if (!M2Share.FrontEngine.IsFull() && !ProcessHumans_IsLogined(UserOpenInfo.sAccount, m_LoadPlayList[I].sChrName))
                                        {
                                            nCheck30 = 24;
                                            PlayObject = MakeNewHuman(UserOpenInfo);// 创建新的人物
                                            if (PlayObject != null)
                                            {
                                                nCheck30 = 25;
                                                PlayObject.AddMapCount();
                                                PlayObject.m_boClientFlag = UserOpenInfo.LoadUser.boClinetFlag;// 将客户端标志传到人物数据中
                                                //m_PlayObjectList.Add(m_LoadPlayList[I], PlayObject);
                                                m_PlayObjectList.Add(PlayObject);
                                                SendServerGroupMsg(Grobal2.SS_201, M2Share.nServerIndex, PlayObject.m_sCharName);
                                                nCheck30 = 26;
                                                m_NewHumanList.Add(PlayObject);
                                            }
                                        }
                                        else
                                        {
                                            nCheck30 = 27;
                                            KickOnlineUser(m_LoadPlayList[I].sChrName);//踢出在线人物
                                            m_ListOfGateIdx.Add((UserOpenInfo.LoadUser.nGateIdx as object));
                                            m_ListOfSocket.Add((UserOpenInfo.LoadUser.nSocket as object));
                                        }
                                    }
                                    else
                                    {
                                        nCheck30 = 28;
                                        if (UserOpenInfo.LoadUser.PlayObject != null)// 开始召唤英雄
                                        {
                                            PlayObject = GetPlayObject(((TBaseObject)(UserOpenInfo.LoadUser.PlayObject)));
                                            nCheck30 = 29;
                                            if (PlayObject != null)
                                            {
                                                switch (UserOpenInfo.LoadUser.btLoadDBType)
                                                {
                                                    case 0:// 召唤
                                                        nCheck30 = 30;
                                                        if (UserOpenInfo.nOpenStatus == 1)
                                                        {
                                                            THeroObject HeroObject = ((THeroObject)(PlayObject.m_MyHero));
                                                            unsafe
                                                            {
                                                                fixed (THumDataInfo* data = &UserOpenInfo.HumanRcd)
                                                                {
                                                                    PlayObject.m_MyHero = PlayObject.MakeHero(PlayObject, data);
                                                                }
                                                            }
                                                            if (PlayObject.m_MyHero != null)
                                                            {
                                                                nCheck30 = 31;
                                                                HeroObject.Login();// 英雄登录
                                                                PlayObject.m_MyHero.m_btAttatckMode = PlayObject.m_btAttatckMode;    // 与主人的攻击模式一致，以修正宝宝可以正常攻击目标
                                                                PlayObject.m_MyHero.SendRefMsg(Grobal2.RM_CREATEHERO, PlayObject.m_MyHero.m_btDirection,
                                                                    PlayObject.m_MyHero.m_nCurrX, PlayObject.m_MyHero.m_nCurrY, 0, "");// 刷新客户端，创建英雄信息
                                                                PlayObject.SendMsg(PlayObject, Grobal2.RM_RECALLHERO, 0, Parse(PlayObject.m_MyHero), 0, 0, "");
                                                                PlayObject.n_myHeroTpye = HeroObject.n_HeroTpye;
                                                                switch (HeroObject.m_btStatus)
                                                                {
                                                                    case 1:// 英雄的类型
                                                                        HeroObject.SysMsg(GameMsgDef.g_sHeroFollow, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 0:
                                                                        HeroObject.SysMsg(GameMsgDef.g_sHeroAttack, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 2:
                                                                        HeroObject.SysMsg(GameMsgDef.g_sHeroRest, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                }
                                                                HeroObject.SysMsg(GameMsgDef.g_sHeroLoginMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                if (HeroObject.m_boTrainingNG)// 学过内功
                                                                {
                                                                    HeroObject.m_MaxExpSkill69 = HeroObject.GetSkill69Exp(HeroObject.m_NGLevel,
                                                                        ref HeroObject.m_Skill69MaxNH);// 登录重新取内功心法升级经验
                                                                    //((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROMAGIC69SKILLEXP, 0, 0, 0, ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel, EncryptUnit.EncodeString((((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69).ToString() + "/" + (((THeroObject)(PlayObject.m_MyHero)).m_MaxExpSkill69).ToString()));
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_MAGIC69SKILLNH, 0, HeroObject.m_Skill69NH,
                                                                        HeroObject.m_Skill69MaxNH, 0, "");// 内力值让别人看到
                                                                    //((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.SM_OPENPULS, ((ushort)((THeroObject)(PlayObject.m_MyHero)).m_boisOpenPuls), 0, 0, 0, "");// 英雄经络
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROPULSECHANGED, 0, 0, 0, 0, "");// 英雄经络
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROBATTERORDER, 0, 0, 0, 1, "");// 英雄连击次序
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 1:// 新建
                                                        nCheck30 = 32;
                                                        switch (UserOpenInfo.nOpenStatus)
                                                        {
                                                            case 1:
                                                                switch (PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        PlayObject.m_boHasHero = true;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = true;
                                                                        break;
                                                                }
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@CreateHeroOK", false);
                                                                }
                                                                break;
                                                            case 2:
                                                                switch (PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        PlayObject.m_boHasHero = false;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = false;
                                                                        break;
                                                                }
                                                                PlayObject.m_sHeroCharName = "";
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@HeroNameExists", false);
                                                                }
                                                                break;
                                                            case 3:
                                                                switch (PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        PlayObject.m_boHasHero = false;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = false;
                                                                        break;
                                                                }
                                                                PlayObject.m_sHeroCharName = "";
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@HeroOverChrCount", false);
                                                                }
                                                                break;
                                                            default:
                                                                nCheck30 = 33;
                                                                switch (PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        PlayObject.m_boHasHero = false;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = false;
                                                                        break;
                                                                }
                                                                PlayObject.m_sHeroCharName = "";
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@CreateHeroFail", false);
                                                                }
                                                                break;
                                                        }
                                                        break;
                                                    case 2:// 删除英雄
                                                        nCheck30 = 34;
                                                        if (UserOpenInfo.nOpenStatus == 1)
                                                        {
                                                            switch (PlayObject.n_myHeroTpye)
                                                            {
                                                                case 0:
                                                                    PlayObject.m_boHasHero = false;
                                                                    break;
                                                                case 1:
                                                                    PlayObject.m_boHasHeroTwo = false;
                                                                    break;
                                                            }
                                                            PlayObject.m_sHeroCharName = "";
                                                            PlayObject.n_myHeroTpye = 3;// 英雄的类型
                                                            if (M2Share.g_FunctionNPC != null)
                                                            {
                                                                M2Share.g_FunctionNPC.GotoLable(PlayObject, "@DeleteHeroOK", false);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (M2Share.g_FunctionNPC != null)
                                                            {
                                                                M2Share.g_FunctionNPC.GotoLable(PlayObject, "@DeleteHeroFail", false);
                                                            }
                                                        }
                                                        break;
                                                    case 3:// 查询英雄相关数据
                                                        nCheck30 = 35;
                                                        if (UserOpenInfo.LoadUser.sMsg != "")
                                                        {
                                                            PlayObject.SendMsg(PlayObject, Grobal2.RM_GETHEROINFO, 0, 0, 0, 0, UserOpenInfo.LoadUser.sMsg);
                                                        }
                                                        break;
                                                    case 4:// 召唤  双英雄
                                                        nCheck30 = 30;
                                                        if (UserOpenInfo.nOpenStatus == 1)
                                                        {
                                                            THeroObject HeroObject = ((THeroObject)(PlayObject.m_MyHero));
                                                            unsafe
                                                            {
                                                                fixed (THumDataInfo* data = &UserOpenInfo.HumanRcd)
                                                                {
                                                                    PlayObject.m_MyHero = PlayObject.MakeHero(PlayObject, data);
                                                                }
                                                            }
                                                            if (PlayObject.m_MyHero != null)
                                                            {
                                                                nCheck30 = 31;
                                                                HeroObject.m_btMentHero = UserOpenInfo.HumanRcd.Data.m_btFHeroType;
                                                                HeroObject.Login();// 英雄登录
                                                                PlayObject.m_MyHero.m_btAttatckMode = PlayObject.m_btAttatckMode;// 与主人的攻击模式一致，以修正宝宝可以正常攻击目标
                                                                PlayObject.m_MyHero.SendRefMsg(Grobal2.RM_CREATEHERO, PlayObject.m_MyHero.m_btDirection, PlayObject.m_MyHero.m_nCurrX,
                                                                    PlayObject.m_MyHero.m_nCurrY, 0, "");// 刷新客户端，创建英雄信息
                                                                PlayObject.SendMsg(PlayObject, Grobal2.RM_RECALLHERO, 0, Parse(PlayObject.m_MyHero), 0, 0, "");
                                                                PlayObject.n_myHeroTpye = HeroObject.n_HeroTpye;
                                                                switch (((THeroObject)(PlayObject.m_MyHero)).m_btStatus)
                                                                {
                                                                    case 1://英雄的类型
                                                                        HeroObject.SysMsg(GameMsgDef.g_sHeroFollow, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 0:
                                                                        HeroObject.SysMsg(GameMsgDef.g_sHeroAttack, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 2:
                                                                        HeroObject.SysMsg(GameMsgDef.g_sHeroRest, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                }
                                                                HeroObject.SysMsg(GameMsgDef.g_sHeroLoginMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_ISDEHERO, 0, 0, 0, 1, "");// 是副将英雄
                                                                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG) // 学过内功
                                                                {
                                                                    HeroObject.m_MaxExpSkill69 =
                                                                    HeroObject.GetSkill69Exp(HeroObject.m_NGLevel, ref HeroObject.m_Skill69MaxNH);// 登录重新取内功心法升级经验
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROMAGIC69SKILLEXP, 0, 0,
                                                                        0, HeroObject.m_NGLevel, EncryptUnit.EncodeString((HeroObject.m_ExpSkill69).ToString() + "/"
                                                                        + (HeroObject.m_MaxExpSkill69).ToString()));
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_MAGIC69SKILLNH, 0, HeroObject.m_Skill69NH,
                                                                        HeroObject.m_Skill69MaxNH, 0, "");// 内力值让别人看到 
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.SM_OPENPULS,
                                                                        Convert.ToInt32(HeroObject.m_boisOpenPuls), 0, 0, 0, "");// 英雄经络
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROPULSECHANGED, 0, 0, 0, 0, "");// 英雄经络
                                                                    HeroObject.SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROBATTERORDER, 0, 0, 0, 1, "");// 英雄连击次序
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 5:// 新建  双英雄
                                                        if ((PlayObject.sName1 != "") && (PlayObject.sName2 != ""))
                                                        {
                                                            PlayObject.m_sHeroCharName = PlayObject.sName1;
                                                            PlayObject.m_sDeputyHeroCharName = PlayObject.sName2;
                                                        }
                                                        break;
                                                    case 6:
                                                        break;
                                                    case 7:// 删除  双英雄 查询  双英雄
                                                        nCheck30 = 35;
                                                        if (UserOpenInfo.LoadUser.sMsg != "")
                                                        {
                                                            PlayObject.SendMsg(PlayObject, Grobal2.RM_GETASSESSHEROINFO, 0, 0, 0, 0, UserOpenInfo.LoadUser.sMsg);
                                                        }
                                                        break;
                                                }
                                                PlayObject.m_boWaitHeroDate = false;
                                            }
                                        }
                                    }
                                    nCheck30 = 36;
                                    Dispose(m_LoadPlayList[I]);
                                }
                                nCheck30 = 37;
                                m_LoadPlayList.Clear();
                            }
                            if (m_ChangeHumanDBGoldList.Count > 0)
                            {
                                for (int I = 0; I < m_ChangeHumanDBGoldList.Count; I++)
                                {
                                    nCheck30 = 38;
                                    GoldChangeInfo = m_ChangeHumanDBGoldList[I];
                                    PlayObject = GetPlayObject(GoldChangeInfo.sGameMasterName);
                                    if (PlayObject != null)
                                    {
                                        PlayObject.GoldChange(GoldChangeInfo.sGetGoldUser, GoldChangeInfo.nGold);
                                    }
                                    nCheck30 = 39;
                                    Dispose(GoldChangeInfo);
                                }
                                nCheck30 = 40;
                                m_ChangeHumanDBGoldList.Clear();
                            }
                        }
                        finally
                        {
                            HUtil32.LeaveCriticalSection(m_LoadPlaySection);
                        }
                        nCheck30 = 41;
                        if (m_NewHumanList.Count > 0)
                        {
                            for (int I = 0; I < m_NewHumanList.Count; I++)
                            {
                                nCheck30 = 42;
                                M2Share.RunSocket.SetGateUserList(PlayObject.m_nGateIdx, PlayObject.m_nSocket, PlayObject);
                            }
                            nCheck30 = 44;
                            m_NewHumanList.Clear();
                        }
                        nCheck30 = 45;
                        if (m_ListOfGateIdx.Count > 0)
                        {
                            for (int I = 0; I < m_ListOfGateIdx.Count; I++)
                            {
                                nCheck30 = 46;
                                M2Share.RunSocket.CloseUser(((int)m_ListOfGateIdx[I]), ((int)m_ListOfSocket[I]));
                            }
                            nCheck30 = 47;
                            m_ListOfGateIdx.Clear();
                        }
                        nCheck30 = 48;
                        m_ListOfSocket.Clear();
                    }
                    catch
                    {
                        M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans -> Ready, Save, Load... Code:" + nCheck30);
                    }
                }
                try
                {
                    if (m_PlayObjectFreeList.Count > 0)
                    {
                        for (int I = 0; I < m_PlayObjectFreeList.Count; I++)
                        {
                            PlayObject = m_PlayObjectFreeList[I];
                            if ((HUtil32.GetTickCount() - PlayObject.m_dwGhostTick) > GameConfig.dwHumanFreeDelayTime)// 5 * 60 * 1000
                            {
                                try
                                {
                                    if (PlayObject != null)
                                    {
                                        Dispose(PlayObject);
                                        PlayObject = null;
                                    }
                                }
                                catch
                                {
                                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans ClosePlayer.Delete - Free");
                                }
                                m_PlayObjectFreeList.RemoveAt(I);
                                break;
                            }
                            else
                            {
                                if (PlayObject.m_boSwitchData && (PlayObject.m_boRcdSaved))
                                {
                                    if (SendSwitchData(PlayObject, PlayObject.m_nServerIndex) || (PlayObject.m_nWriteChgDataErrCount > 20))
                                    {
                                        PlayObject.m_boSwitchData = false;
                                        PlayObject.m_boSwitchDataSended = true;
                                        PlayObject.m_dwChgDataWritedTick = HUtil32.GetTickCount();
                                    }
                                    else
                                    {
                                        PlayObject.m_nWriteChgDataErrCount++;
                                    }
                                }
                                if (PlayObject.m_boSwitchDataSended && ((HUtil32.GetTickCount() - PlayObject.m_dwChgDataWritedTick) > 100))
                                {
                                    PlayObject.m_boSwitchDataSended = false;
                                    SendChangeServer(PlayObject, PlayObject.m_nServerIndex);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans ClosePlayer.Delete");
                }
                // ===================================重新获取授权===============================
                try
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchTick) > 3600000) || (m_TodayDate != DateTime.Today))  // 1000 * 60 * 60
                    {
                        m_TodayDate = DateTime.Today;
                        m_dwSearchTick = HUtil32.GetTickCount();
                        m_nLimitNumber = 1000000;
                        m_nLimitUserCount = 1000000;
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TUserEngine::GetLicense");
                }
                // --------------------------------------------------------------------------------
                boCheckTimeLimit = false;
                try
                {
                    dwCurTick = HUtil32.GetTickCount();
                    nIdx = m_nProcHumIDx;
                    while (true)
                    {
                        if (m_PlayObjectList.Count <= nIdx)
                        {
                            break;
                        }
                        PlayObject = m_PlayObjectList[nIdx];
                        if (PlayObject != null)
                        {
                            if (PlayObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT)  //不是人物则退出
                            {
                                break;
                            }
                            if ((dwCurTick - PlayObject.m_dwRunTick) > PlayObject.m_nRunTime)
                            {
                                PlayObject.m_dwRunTick = dwCurTick;
                                if (!PlayObject.m_boGhost)
                                {
                                    if (!PlayObject.m_boLoginNoticeOK)
                                    {
                                        try
                                        {
                                            PlayObject.RunNotice();// 运行游戏忠告,即将进入游戏时的提示框
                                        }
                                        catch
                                        {
                                            M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans RunNotice");
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            if (!PlayObject.m_boReadyRun)  // 是否进入游戏完成
                                            {
                                                PlayObject.m_boReadyRun = true;
                                                PlayObject.UserLogon();// 人物登录游戏
                                                if (PlayObject.m_boNotOnlineAddExp)// 人物在挂机状态
                                                {
                                                    PlayObject.m_boNotOnlineAddExp = false;
                                                    PlayObject.m_boPlayOffLine = false;// 不下线触发
                                                    if (M2Share.g_ManageNPC != null)
                                                    {
                                                        M2Share.g_ManageNPC.GotoLable(PlayObject, "@RESUME", false);// 人物在挂机状态,让人物小退
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if ((HUtil32.GetTickCount() - PlayObject.m_dwSearchTick) > PlayObject.m_dwSearchTime)
                                                {
                                                    PlayObject.m_dwSearchTick = HUtil32.GetTickCount();
                                                    nCheck30 = 10;
                                                    PlayObject.SearchViewRange();// 搜索对像
                                                    nCheck30 = 11;
                                                    PlayObject.GameTimeChanged();// 游戏时间改变
                                                }
                                            }
                                            if ((HUtil32.GetTickCount() - PlayObject.m_dwShowLineNoticeTick) > GameConfig.dwShowLineNoticeTime)
                                            {
                                                PlayObject.m_dwShowLineNoticeTick = HUtil32.GetTickCount();
                                                if (M2Share.LineNoticeList.Count > PlayObject.m_nShowLineNoticeIdx)
                                                {
                                                    LineNoticeMsg = M2Share.g_ManageNPC.GetLineVariableText(PlayObject, M2Share.LineNoticeList[PlayObject.m_nShowLineNoticeIdx]);
                                                    nCheck30 = 13;
                                                    switch (LineNoticeMsg[0])
                                                    {
                                                        case 'R':
                                                            PlayObject.SysMsg(LineNoticeMsg.Substring(2 - 1, LineNoticeMsg.Length - 1), TMsgColor.c_Red, TMsgType.t_Notice);
                                                            break;
                                                        case 'G':
                                                            PlayObject.SysMsg(LineNoticeMsg.Substring(2 - 1, LineNoticeMsg.Length - 1), TMsgColor.c_Green, TMsgType.t_Notice);
                                                            break;
                                                        case 'B':
                                                            PlayObject.SysMsg(LineNoticeMsg.Substring(2 - 1, LineNoticeMsg.Length - 1), TMsgColor.c_Blue, TMsgType.t_Notice);
                                                            break;
                                                        default:
                                                            PlayObject.SysMsg(LineNoticeMsg, ((TMsgColor)(GameConfig.nLineNoticeColor)), TMsgType.t_Notice);
                                                            break;
                                                    }
                                                }
                                                PlayObject.m_nShowLineNoticeIdx++;
                                                if ((M2Share.LineNoticeList.Count <= PlayObject.m_nShowLineNoticeIdx))
                                                {
                                                    PlayObject.m_nShowLineNoticeIdx = 0;
                                                }
                                            }
                                            nCheck30 = 14;
                                            PlayObject.Run();
                                            nCheck30 = 15;
                                            if (!M2Share.FrontEngine.IsFull() && ((HUtil32.GetTickCount() - PlayObject.m_dwSaveRcdTick) > GameConfig.dwSaveHumanRcdTime))
                                            {
                                                nCheck30 = 16;
                                                PlayObject.m_dwSaveRcdTick = HUtil32.GetTickCount();
                                                nCheck30 = 17;
                                                PlayObject.DealCancelA();
                                                nCheck30 = 18;
                                                SaveHumanRcd(PlayObject);
                                                nCheck30 = 19;
                                                SaveHeroRcd(PlayObject);// 保存英雄数据
                                            }
                                        }
                                        catch
                                        {
                                            M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans Human.Operate Code:" + nCheck30 + " Name:" + PlayObject.m_sCharName);
                                            PlayObject.KickException();// 踢除异常
                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        m_PlayObjectList.RemoveAt(nIdx);
                                        nCheck30 = 2;
                                        PlayObject.Disappear();
                                        nCheck30 = 3;
                                    }
                                    catch
                                    {
                                        M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans Human.Finalize Code:" + nCheck30);
                                    }
                                    try
                                    {
                                        nCheck30 = 4;
                                        PlayObject.DealCancelA();
                                        nCheck30 = 5;
                                        SaveHumanRcd(PlayObject);
                                        nCheck30 = 6;
                                        SaveHeroRcd(PlayObject);// 保存英雄数据
                                        AddToHumanFreeList(PlayObject);
                                        nCheck30 = 7;
                                        if ((!PlayObject.m_boReconnection))//非重新连接才关闭
                                        {
                                            M2Share.RunSocket.CloseUser(PlayObject.m_nGateIdx, PlayObject.m_nSocket);
                                        }
                                    }
                                    catch
                                    {
                                        M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans RunSocket.CloseUser Code:" + nCheck30);
                                    }
                                    SendServerGroupMsg(Grobal2.SS_202, M2Share.nServerIndex, PlayObject.m_sCharName);
                                    continue;
                                }
                            }
                            nIdx++;

                            if ((HUtil32.GetTickCount() - dwCheckTime) > M2Share.g_dwHumLimit)
                            {
                                boCheckTimeLimit = true;
                                m_nProcHumIDx = nIdx;
                                break;
                            }
                        }
                    }
                    if (!boCheckTimeLimit)
                    {
                        m_nProcHumIDx = 0;
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans");
                }
                M2Share.g_nProcessHumanLoopTime++;
                if (m_nProcHumIDx == 0)
                {
                    M2Share.g_nProcessHumanLoopTime = 0;
                    dwUsrRotTime = HUtil32.GetTickCount() - M2Share.g_dwUsrRotCountTick;
                    M2Share.dwUsrRotCountMin = dwUsrRotTime;
                    M2Share.g_dwUsrRotCountTick = HUtil32.GetTickCount();
                    if (M2Share.dwUsrRotCountMax < dwUsrRotTime)
                    {
                        M2Share.dwUsrRotCountMax = dwUsrRotTime;
                    }
                }
                M2Share.g_nHumCountMin = HUtil32.GetTickCount() - dwCheckTime;
                if (M2Share.g_nHumCountMax < M2Share.g_nHumCountMin)
                {
                    M2Share.g_nHumCountMax = M2Share.g_nHumCountMin;
                }
            }
            finally
            {
                m_boHumProcess = false;// 检查过程是否重入
            }
        }

        private void ProcessMerchants()
        {
            uint dwCurrTick;
            int I;
            TMerchant MerchantNPC;
            uint dwRunTick = HUtil32.GetTickCount();
            bool boProcessLimit = false;
            try
            {
                dwCurrTick = HUtil32.GetTickCount();
                //m_MerchantList.__Lock();
                try
                {
                    I = nMerchantPosition;
                    while (true)
                    {
                        if (m_MerchantList.Count <= I)
                        {
                            break;
                        }
                        MerchantNPC = m_MerchantList[I];
                        if (MerchantNPC != null)
                        {
                            if (!MerchantNPC.m_boGhost)
                            {
                                if ((dwCurrTick - MerchantNPC.m_dwRunTick) > MerchantNPC.m_nRunTime)
                                {
                                    if ((HUtil32.GetTickCount() - MerchantNPC.m_dwSearchTick) > MerchantNPC.m_dwSearchTime)
                                    {
                                        MerchantNPC.m_dwSearchTick = HUtil32.GetTickCount();
                                        MerchantNPC.SearchViewRange();
                                    }
                                    if ((dwCurrTick - MerchantNPC.m_dwRunTick) > MerchantNPC.m_nRunTime)
                                    {
                                        MerchantNPC.m_dwRunTick = dwCurrTick;
                                        MerchantNPC.Run();
                                    }
                                }
                            }
                            else
                            {
                                if ((HUtil32.GetTickCount() - MerchantNPC.m_dwGhostTick) > 60000)// 60 * 1000
                                {
                                    Dispose(MerchantNPC);
                                    m_MerchantList.RemoveAt(I);
                                    break;
                                }
                            }
                        }
                        if ((HUtil32.GetTickCount() - dwRunTick) > M2Share.g_dwNpcLimit)
                        {
                            nMerchantPosition = I;
                            boProcessLimit = true;
                            break;
                        }
                        I++;
                    }
                }
                finally
                {
                    //m_MerchantList.UnLock();
                }
                if (!boProcessLimit)
                {
                    nMerchantPosition = 0;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine::ProcessMerchants");
            }
            dwProcessMerchantTimeMin = HUtil32.GetTickCount() - dwRunTick;
            if (dwProcessMerchantTimeMin > dwProcessMerchantTimeMax)
            {
                dwProcessMerchantTimeMax = dwProcessMerchantTimeMin;
            }
            if (dwProcessNpcTimeMin > dwProcessNpcTimeMax)
            {
                dwProcessNpcTimeMax = dwProcessNpcTimeMin;
            }
        }

        public bool InsMonstersList(TMonGenInfo MonGen, TAnimalObject Monster)
        {
            bool result = false;
            TMonGenInfo MonGenInfo;
            if (m_MonGenList.Count > 0)
            {
                for (int I = 0; I < m_MonGenList.Count; I++)
                {
                    MonGenInfo = m_MonGenList[I];
                    if ((MonGenInfo != null) && (MonGenInfo.CertList != null) && (MonGen != null) && (MonGen == MonGenInfo))
                    {
                        if (MonGenInfo.CertList.Count > 0)
                        {
                            for (int II = 0; II < MonGenInfo.CertList.Count; II++)
                            {
                                if ((Monster != null) && (MonGenInfo.CertList[II] == Monster))
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 清除怪物
        /// </summary>
        /// <param name="sMapName">地图名称</param>
        /// <returns></returns>
        public bool ClearMonsters(string sMapName)
        {
            bool result = false;
            TEnvirnoment Envir;
            TBaseObject BaseObject;
            List<TBaseObject> MonList = new List<TBaseObject>();
            try
            {
                if (M2Share.g_MapManager.m_MapList.Count > 0)
                {
                    for (int I = 0; I < M2Share.g_MapManager.m_MapList.Count; I++)
                    {
                        Envir = M2Share.g_MapManager.m_MapList[I];
                        if ((Envir != null) && (((Envir.sMapName).ToLower().CompareTo((sMapName).ToLower()) == 0)))
                        {
                            UserEngine.GetMapMonster(Envir, MonList);
                            if (MonList.Count > 0)
                            {
                                for (int II = 0; II < MonList.Count; II++)
                                {
                                    BaseObject = MonList[II];
                                    if (BaseObject != null)
                                    {
                                        if ((BaseObject.m_btRaceServer != 110) && (BaseObject.m_btRaceServer != 111) && (BaseObject.m_btRaceServer != Grobal2.RC_GUARD)
                                            && (BaseObject.m_btRaceServer != Grobal2.RC_ARCHERGUARD) && (BaseObject.m_btRaceServer != 55))
                                        {
                                            BaseObject.m_boNoItem = true;
                                            BaseObject.m_WAbil.HP = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(MonList);
            }
            result = true;
            return result;
        }

        public uint ProcessMonsters_GetZenTime(uint dwTime)
        {
            uint result;
            double d10;
            if (dwTime < 1800000)// 30 * 60 * 1000
            {
                d10 = (PlayObjectCount - GameConfig.nUserFull) / GameConfig.nZenFastStep;
                if (d10 > 0)
                {
                    if (d10 > 6)
                    {
                        d10 = 6;
                    }
                    result = dwTime - (uint)HUtil32.Round((dwTime / 10) * d10);
                }
                else
                {
                    result = dwTime;
                }
            }
            else
            {
                result = dwTime;
            }
            return result;
        }

        /// <summary>
        /// 处理怪物刷新
        /// </summary>
        private void ProcessMonsters()
        {
            uint dwCurrentTick;
            uint dwMonProcTick;
            TMonGenInfo MonGen;
            int nGenCount;
            int nGenModCount;
            bool boProcessLimit;
            bool boRegened;
            int nProcessPosition;
            TBaseObject Monster = null;
            int tCode = 0;
            int nMakeMonsterCount;
            bool boCanCreate;
            int I = 0;
            uint dwRunTick = HUtil32.GetTickCount();
            try
            {
                tCode = 1;
                boProcessLimit = false;
                dwCurrentTick = HUtil32.GetTickCount();
                MonGen = null;
                if (((HUtil32.GetTickCount() - dwRegenMonstersTick) > GameConfig.dwRegenMonstersTime))// 刷新怪物开始,判断是否超过刷怪的间隔
                {
                    tCode = 2;
                    dwRegenMonstersTick = HUtil32.GetTickCount();
                    if (m_nCurrMonGen < m_MonGenList.Count)
                    {
                        tCode = 25;
                        MonGen = m_MonGenList[m_nCurrMonGen];// 取得当前刷怪的索引
                        tCode = 26;
                        if (MonGen != null)
                        {
                            tCode = 27;
                            if (MonGen.nCurrMonGen == 0)
                            {
                                MonGen.nCurrMonGen = m_nCurrMonGen;// 刷怪索引
                            }
                        }
                    }
                    tCode = 3;
                    if (m_nCurrMonGen < m_MonGenList.Count - 1)
                    {
                        m_nCurrMonGen++;
                    }
                    else
                    {
                        m_nCurrMonGen = 0;
                    }
                    tCode = 4;
                    if (MonGen != null)
                    {
                        if ((MonGen.sMonName != "") && (!GameConfig.boVentureServer))
                        {
                            if ((MonGen.dwStartTick == 0) || ((HUtil32.GetTickCount() - MonGen.dwStartTick) > ProcessMonsters_GetZenTime(MonGen.dwZenTime)))
                            {
                                tCode = 5;
                                nGenCount = GetGenMonCount(MonGen);
                                boRegened = true;
                                if (GameConfig.nMonGenRate <= 0)
                                {
                                    GameConfig.nMonGenRate = 10; // 防止除法错误
                                }
                                nGenModCount = HUtil32._MAX(1, HUtil32.Round((double)HUtil32._MAX(1, MonGen.nCount) / (GameConfig.nMonGenRate / 10)));
                                nMakeMonsterCount = nGenModCount - nGenCount;
                                if (nMakeMonsterCount < 0)
                                {
                                    nMakeMonsterCount = 0;
                                }
                                tCode = 6;
                                if (MonGen.Envir != null)//如果刷怪的地图不等于null
                                {
                                    tCode = 7;
                                    if (MonGen.Envir.m_boNoManNoMon)  // 没人不刷怪
                                    {
                                        if ((MonGen.Envir.HumCount > 0))//如果刷怪地图玩家大于1则刷怪
                                        {
                                            boCanCreate = true;
                                        }
                                        else
                                        {
                                            boCanCreate = false;
                                        }
                                    }
                                    else
                                    {
                                        boCanCreate = true;
                                    }
                                }
                                else
                                {
                                    boCanCreate = true;
                                }
                                tCode = 8;
                                if ((nMakeMonsterCount > 0) && boCanCreate)// 控制刷怪数量比例
                                {
                                    boRegened = RegenMonsters(MonGen, nMakeMonsterCount);// 创建怪物对象 RegenMonsters()
                                }
                                if (boRegened)
                                {
                                    MonGen.dwStartTick = HUtil32.GetTickCount();
                                }
                            }
                            M2Share.g_sMonGenInfo1 = MonGen.sMonName + "," + m_nCurrMonGen + "/" + m_MonGenList.Count;
                        }
                    }
                }
                tCode = 9;
                M2Share.g_nMonGenTime = HUtil32.GetTickCount() - dwCurrentTick;
                if (M2Share.g_nMonGenTime > M2Share.g_nMonGenTimeMin)
                {
                    M2Share.g_nMonGenTimeMin = M2Share.g_nMonGenTime;
                }
                if (M2Share.g_nMonGenTime > M2Share.g_nMonGenTimeMax)
                {
                    M2Share.g_nMonGenTimeMax = M2Share.g_nMonGenTime;
                }
                // 刷新怪物结束
                dwMonProcTick = HUtil32.GetTickCount();
                nMonsterProcessCount = 0;
                tCode = 10;
                if (m_MonGenList.Count > 0)
                {
                    for (I = m_nMonGenListPosition; I < m_MonGenList.Count; I++)
                    {
                        tCode = 11;
                        MonGen = m_MonGenList[I];
                        if (m_nMonGenCertListPosition < MonGen.CertList.Count)
                        {
                            tCode = 12;
                            nProcessPosition = m_nMonGenCertListPosition;
                        }
                        else
                        {
                            nProcessPosition = 0;
                        }
                        m_nMonGenCertListPosition = 0;
                        while (true)
                        {
                            if (nProcessPosition >= MonGen.CertList.Count)
                            {
                                break;
                            }
                            tCode = 13;
                            Monster = MonGen.CertList[nProcessPosition];//取刷怪索引
                            if (Monster != null)
                            {
                                tCode = 14;
                                if (!Monster.m_boGhost) //如果尸体被清除，则添加到地图上去
                                {
                                    tCode = 15;
                                    if ((dwCurrentTick - Monster.m_dwRunTick) > Monster.m_nRunTime)
                                    {
                                        tCode = 16;
                                        Monster.m_dwRunTick = dwRunTick;
                                        if ((dwCurrentTick - Monster.m_dwSearchTick) > Monster.m_dwSearchTime)
                                        {
                                            tCode = 17;
                                            Monster.m_dwSearchTick = HUtil32.GetTickCount();
                                            Monster.SearchViewRange();// 怪多,占CUP
                                        }
                                        if (!Monster.m_boIsVisibleActive && (Monster.m_nProcessRunCount < GameConfig.nProcessMonsterInterval))
                                        {
                                            Monster.m_nProcessRunCount++;
                                        }
                                        else
                                        {
                                            if (Monster != null)
                                            {
                                                Monster.m_nProcessRunCount = 0;
                                                tCode = 18;
                                                Monster.Run();
                                            }
                                        }
                                        nMonsterProcessCount++;
                                    }
                                    nMonsterProcessPostion++;
                                }
                                else
                                {
                                    if ((HUtil32.GetTickCount() - Monster.m_dwGhostTick) > 300000) // 5 * 60 * 1000
                                    {
                                        tCode = 19;
                                        MonGen.CertList.RemoveAt(nProcessPosition);
                                        tCode = 20;
                                        if (Monster != null)
                                        {
                                            Monster = null;
                                        }
                                        Dispose(Monster);
                                        tCode = 24;
                                        continue;
                                    }
                                }
                            }
                            nProcessPosition++;
                            if ((HUtil32.GetTickCount() - dwMonProcTick) > M2Share.g_dwMonLimit)
                            {
                                tCode = 21;
                                M2Share.g_sMonGenInfo2 = Monster.m_sCharName + "/" + I + "/" + nProcessPosition;
                                tCode = 22;
                                boProcessLimit = true;
                                m_nMonGenCertListPosition = nProcessPosition;
                                break;
                            }
                        }
                        if (boProcessLimit)
                        {
                            break;
                        }
                    }
                }
                tCode = 23;
                if (m_MonGenList.Count <= I)
                {
                    m_nMonGenListPosition = 0;
                    nMonsterCount = nMonsterProcessPostion;
                    nMonsterProcessPostion = 0;
                }
                if (!boProcessLimit)
                {
                    m_nMonGenListPosition = 0;
                }
                else
                {
                    m_nMonGenListPosition = I;
                }
                M2Share.g_nMonProcTime = HUtil32.GetTickCount() - dwMonProcTick;
                if (M2Share.g_nMonProcTime > M2Share.g_nMonProcTimeMin)
                {
                    M2Share.g_nMonProcTimeMin = M2Share.g_nMonProcTime;
                }
                if (M2Share.g_nMonProcTime > M2Share.g_nMonProcTimeMax)
                {
                    M2Share.g_nMonProcTimeMax = M2Share.g_nMonProcTime;
                }
            }
            catch
            {
                if (Monster != null)
                {
                    M2Share.MainOutMessage(string.Format("{异常} TUserEngine::ProcessMonsters {0} {1}", tCode, Monster.m_sCharName));
                    Monster.KickException();// 踢除异常
                }
                else
                {
                    M2Share.MainOutMessage(string.Format("{异常} TUserEngine::ProcessMonsters {0}", tCode));
                }
            }
            M2Share.g_nMonTimeMin = HUtil32.GetTickCount() - dwRunTick;
            if (M2Share.g_nMonTimeMax < M2Share.g_nMonTimeMin)
            {
                M2Share.g_nMonTimeMax = M2Share.g_nMonTimeMin;
            }
        }

        /// <summary>
        /// 取怪物数量
        /// </summary>
        /// <param name="MonGen"></param>
        /// <returns></returns>
        private int GetGenMonCount(TMonGenInfo MonGen)
        {
            int result;
            int nCount = 0;
            if (MonGen.CertList.Count > 0)
            {
                foreach (var BaseObject in MonGen.CertList)
                {
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath && !BaseObject.m_boGhost)
                        {
                            nCount++;
                        }
                    }
                }
            }
            result = nCount;
            return result;
        }

        private void ProcessNpcs()
        {
            uint dwCurrTick;
            TNormNpc NPC;
            bool boProcessLimit = false;
            uint dwRunTick = HUtil32.GetTickCount();
            try
            {
                dwCurrTick = HUtil32.GetTickCount();
                for (int I = nNpcPosition; I < QuestNPCList.Count; I++)
                {
                    NPC = QuestNPCList[I];
                    if (NPC != null)
                    {
                        if (!NPC.m_boGhost)
                        {
                            if ((dwCurrTick - NPC.m_dwRunTick) > NPC.m_nRunTime)
                            {
                                if ((HUtil32.GetTickCount() - NPC.m_dwSearchTick) > NPC.m_dwSearchTime)
                                {
                                    NPC.m_dwSearchTick = HUtil32.GetTickCount();
                                    NPC.SearchViewRange();
                                }
                                if ((dwCurrTick - NPC.m_dwRunTick) > NPC.m_nRunTime)
                                {
                                    NPC.m_dwRunTick = dwCurrTick;
                                    NPC.Run();
                                }
                            }
                        }
                        else
                        {
                            if ((HUtil32.GetTickCount() - NPC.m_dwGhostTick) > 60000)// 60 * 1000
                            {
                                Dispose(NPC);
                                QuestNPCList.RemoveAt(I);
                                break;
                            }
                        }
                    }
                    if ((HUtil32.GetTickCount() - dwRunTick) > M2Share.g_dwNpcLimit)
                    {
                        nNpcPosition = I;
                        boProcessLimit = true;
                        break;
                    }
                }
                if (!boProcessLimit)
                {
                    nNpcPosition = 0;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.ProcessNpcs");
            }
            dwProcessNpcTimeMin = HUtil32.GetTickCount() - dwRunTick;
            if (dwProcessNpcTimeMin > dwProcessNpcTimeMax)
            {
                dwProcessNpcTimeMax = dwProcessNpcTimeMin;
            }
        }

        /// <summary>
        /// 创建怪物对象
        /// </summary>
        /// <param name="sMAP"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="sMonName"></param>
        /// <returns></returns>
        public TBaseObject RegenMonsterByName(string sMAP, int nX, int nY, string sMonName)
        {
            TBaseObject result;
            int n18;
            TMonGenInfo MonGen;
            int nRace = GetMonRace(sMonName);
            TBaseObject BaseObject = AddBaseObject(sMAP, nX, nY, nRace, sMonName);
            if (BaseObject != null)
            {
                n18 = m_MonGenList.Count - 1;
                if (n18 < 0)
                {
                    n18 = 0;
                }
                MonGen = m_MonGenList[n18];
                if (MonGen != null)
                {
                    MonGen.CertList.Add(BaseObject);
                    BaseObject.AddMapCount();
                }
                else
                {
                    BaseObject.m_PEnvir.DeleteFromMap(BaseObject.m_nCurrX, BaseObject.m_nCurrY, Grobal2.OS_MOVINGOBJECT, BaseObject);
                    Dispose(BaseObject);
                }
            }
            result = BaseObject;
            return result;
        }

        /// <summary>
        /// 创建怪物对象
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="sMonName"></param>
        /// <returns></returns>
        public TBaseObject RegenPlayByName(TPlayObject PlayObject, int nX, int nY, string sMonName)
        {
            TBaseObject result;
            int n18;
            TMonGenInfo MonGen;
            TBaseObject BaseObject = AddPlayObject(PlayObject, nX, nY, sMonName);
            if (BaseObject != null)
            {
                n18 = m_MonGenList.Count - 1;
                if (n18 < 0)
                {
                    n18 = 0;
                }
                MonGen = m_MonGenList[n18];
                MonGen.CertList.Add(BaseObject);
                BaseObject.AddMapCount();
            }
            else
            {
                BaseObject.m_PEnvir.DeleteFromMap(BaseObject.m_nCurrX, BaseObject.m_nCurrY, Grobal2.OS_MOVINGOBJECT, BaseObject);
                Dispose(BaseObject);
            }
            result = BaseObject;
            return result;
        }

        public void AddObjectToMonList(TBaseObject BaseObject)
        {
            TMonGenInfo MonGen;
            int n18 = m_MonGenList.Count - 1;
            if (n18 < 0)
            {
                n18 = 0;
            }
            MonGen = m_MonGenList[n18];
            MonGen.CertList.Add(BaseObject);
            BaseObject.AddMapCount();
            //BaseObject.m_boAddToMaped = true;
        }

        /// <summary>
        /// 创建英雄对象
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="HumanRcd"></param>
        /// <returns></returns>
        public unsafe TBaseObject RegenMyHero(TPlayObject PlayObject, int nX, int nY, THumDataInfo* HumanRcd)
        {
            int n18;
            TBaseObject result;
            TMonGenInfo MonGen;
            TBaseObject BaseObject = AddHeroObject(PlayObject, nX, nY, HumanRcd);
            if (BaseObject != null)
            {
                n18 = m_MonGenList.Count - 1;
                if (n18 < 0)
                {
                    n18 = 0;
                }
                MonGen = m_MonGenList[n18];
                MonGen.CertList.Add(BaseObject);
                BaseObject.AddMapCount();
                //BaseObject.m_boAddToMaped = true;
            }
            result = BaseObject;
            return result;
        }

        /// <summary>
        /// 取在线人数
        /// </summary>
        public void Run_ShowOnlineCount()
        {
            int nOnlineCount;
            int nOnlineCount2;
            int nAutoAddExpPlayCount;
            nOnlineCount = PlayObjectCount;
            nAutoAddExpPlayCount = AutoAddExpPlayCount;// 挂机人物
            nOnlineCount2 = nOnlineCount - nAutoAddExpPlayCount;// 真正在线人数
            M2Share.MainOutMessage(string.Format("在线数: {0} [{1}/{2}]", nOnlineCount, nOnlineCount2, nAutoAddExpPlayCount));
        }

        public void Run()
        {
            try
            {
                if ((HUtil32.GetTickCount() - dwShowOnlineTick) > GameConfig.dwConsoleShowUserCountTime)
                {
                    dwShowOnlineTick = HUtil32.GetTickCount();
                    Run_ShowOnlineCount();// 取在线人数
                    M2Share.g_CastleManager.Save();
                }
                if ((HUtil32.GetTickCount() - dwSendOnlineHumTime) > 15000)// 10000
                {
                    dwSendOnlineHumTime = HUtil32.GetTickCount();
                    M2Share.FrmIDSoc.SendOnlineHumCountMsg(OnlinePlayObject);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine::Run");
            }
        }

        /// <summary>
        /// 根据物品Id获取详情
        /// </summary>
        /// <param name="nItemIdx"></param>
        /// <returns></returns>
        public unsafe TStdItem* GetStdItem(int nItemIdx)
        {
            TStdItem* result = null;
            nItemIdx -= 1;
            if ((nItemIdx >= 0) && (StdItemList.Count > nItemIdx))
            {
                result = (TStdItem*)StdItemList[nItemIdx];
                if (HUtil32.SBytePtrToString(result->Name, result->NameLen) == "")
                {
                    result = null;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据物品名称获取详情
        /// </summary>
        /// <param name="sItemName"></param>
        /// <returns></returns>
        public unsafe TStdItem* GetStdItem(string sItemName)
        {
            TStdItem* result = null;
            if (sItemName == "")
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                foreach (TStdItem* item in StdItemList)
                {
                    if (string.Compare(HUtil32.SBytePtrToString(item->Name, item->NameLen), sItemName, true) == 0)
                    {
                        result = item;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// (酿酒)通过材料Anicount得到对应酒的函数 
        /// </summary>
        /// <param name="Anicount"></param>
        /// <returns></returns>
        public unsafe TStdItem* GetMakeWineStdItem(int Anicount)
        {
            TStdItem* result = null;
            TStdItem* StdItem;
            if (Anicount < 0)
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                for (int I = 0; I < StdItemList.Count; I++)
                {
                    StdItem = (TStdItem*)StdItemList[I];
                    if (StdItem != null)
                    {
                        if ((StdItem->Shape == Anicount) && (StdItem->StdMode == 60))
                        {
                            result = StdItem;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 通过酒Shape得到对应酒曲的函数
        /// </summary>
        /// <param name="Shape"></param>
        /// <returns></returns>
        public unsafe TStdItem* GetMakeWineStdItem1(int Shape)
        {
            TStdItem* result = null;
            if (Shape < 0)
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                foreach (TStdItem* item in StdItemList)
                {
                    if (item != null)
                    {
                        if ((item->Shape == Shape) && (item->StdMode == 13))
                        {
                            result = item;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 通过索引取物品重量
        /// </summary>
        /// <param name="nItemIdx"></param>
        /// <returns></returns>
        public unsafe int GetStdItemWeight(int nItemIdx)
        {
            int result = 0;
            TStdItem* StdItem;
            nItemIdx -= 1;
            if ((nItemIdx >= 0) && (StdItemList.Count > nItemIdx))
            {
                StdItem = (TStdItem*)StdItemList[nItemIdx];
                if (StdItem != null)
                {
                    result = StdItem->Weight;
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// 通过索引取物品名字
        /// </summary>
        /// <param name="nItemIdx"></param>
        /// <returns></returns>
        public unsafe string GetStdItemName(int nItemIdx)
        {
            string result = "";
            nItemIdx -= 1;
            if ((nItemIdx >= 0) && (StdItemList.Count > nItemIdx))
            {
                result = HUtil32.SBytePtrToString(((TStdItem*)(StdItemList[nItemIdx]))->Name,
                    ((TStdItem*)(StdItemList[nItemIdx]))->NameLen);
            }
            return result;
        }

        // 查找其它服务器上的角色 暂时无效
        public bool FindOtherServerUser(string sName, ref int nServerIndex)
        {
            return true;
        }

        /// <summary>
        /// 黄字喊话
        /// </summary>
        /// <param name="wIdent"></param>
        /// <param name="pMap"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nWide"></param>
        /// <param name="btFColor"></param>
        /// <param name="btBColor"></param>
        /// <param name="sMsg"></param>
        public void CryCry(ushort wIdent, TEnvirnoment pMap, int nX, int nY, int nWide, byte btFColor, byte btBColor, string sMsg)
        {
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                for (int I = 0; I < m_PlayObjectList.Count; I++)
                {
                    PlayObject = m_PlayObjectList[I];// 允许群组聊天
                    if (!PlayObject.m_boGhost && (PlayObject.m_PEnvir == pMap) && (PlayObject.m_boBanShout) && (PlayObject.m_boBanGmMsg) &&
                        (Math.Abs(PlayObject.m_nCurrX - nX) < nWide) && (Math.Abs(PlayObject.m_nCurrY - nY) < nWide))
                    {
                        PlayObject.SendMsg(PlayObject, wIdent, 0, btFColor, btBColor, 0, sMsg);
                    }
                }
            }
        }

        /// <summary>
        /// 获取怪物爆率物品
        /// </summary>
        /// <param name="mon">怪物对象</param>
        /// <returns></returns>
        private unsafe int MonGetRandomItems(TBaseObject monster)
        {
            int result = 0;
            IList<TMonItemInfo> ItemList = null;
            string iname;
            TMonItemInfo MonItem;
            TUserItem* UserItem = null;
            TMonInfo Monster;
            TStdItem* StdItem;
            byte nCode = 0;
            try
            {
                if (monster == null)
                {
                    return result;
                }
                nCode = 1;
                if (MonsterList.Count > 0)
                {
                    for (int I = 0; I < MonsterList.Count; I++)
                    {
                        Monster = MonsterList[I];
                        nCode = 2;
                        if (Monster != null)
                        {
                            if ((Monster.sName).ToLower().CompareTo((monster.m_sCharName).ToLower()) == 0)
                            {
                                ItemList = new List<TMonItemInfo>();
                                if (Monster.ItemList != null)
                                {
                                    foreach (var item in Monster.ItemList)
                                    {
                                        ItemList.Add(new TMonItemInfo() { SelPoint = item.n00, MaxPoint = item.n04, ItemName = item.sMonName, Count = item.n18 });
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                nCode = 3;
                if (ItemList != null)
                {
                    if (ItemList.Count > 0)
                    {
                        for (int I = 0; I < ItemList.Count; I++)
                        {
                            MonItem = ItemList[I];
                            nCode = 4;
                            if (MonItem != null)
                            {
                                if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint) // 计算机率 1/10 随机10<=1 即为所得的物品
                                {
                                    nCode = 5;
                                    if (string.Compare(MonItem.ItemName, M2Share.sSTRING_GOLDNAME, true) == 0)// 如果是金币
                                    {
                                        monster.m_nGold = monster.m_nGold + (MonItem.Count / 2) + HUtil32.Random(MonItem.Count);
                                    }
                                    else
                                    {
                                        iname = "";
                                        if (iname == "")
                                        {
                                            iname = MonItem.ItemName;
                                        }
                                        nCode = 6;
                                        UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                        if (CopyToUserItemFromName(iname, UserItem))
                                        {
                                            UserItem->Dura = (ushort)HUtil32.Round((double)(UserItem->DuraMax / 100) * (20 + HUtil32.Random(80)));
                                            if (HUtil32.Random(GameConfig.nMonRandomAddValue) == 0)
                                            {
                                                RandomUpgradeItem(UserItem);
                                            }
                                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                            if (StdItem != null)
                                            {
                                                switch (StdItem->StdMode)
                                                {
                                                    case 2:
                                                        if (StdItem->AniCount == 21)// 是魔令包和祝福罐,则把当前持久设置为0
                                                        {
                                                            UserItem->Dura = 0;
                                                        }
                                                        break;
                                                    case 8:
                                                        switch (StdItem->Source)
                                                        {
                                                            case 0:// 是酿酒材料
                                                                UserItem->btValue[0] = Convert.ToByte(HUtil32.Random(3) + 1);
                                                                break;
                                                            case 1:// 随机给材料的品质
                                                                UserItem->btValue[0] = Convert.ToByte(HUtil32.Random(3) + 5);
                                                                break;
                                                        }
                                                        break;
                                                    case 51:
                                                        if (StdItem->Shape == 0)
                                                        {
                                                            UserItem->Dura = 0;// 聚灵珠则清空当前持久
                                                        }
                                                        break;
                                                }
                                            }
                                            nCode = 7;
                                            monster.m_ItemList.Add((IntPtr)UserItem);
                                        }
                                        else
                                        {
                                            Marshal.FreeHGlobal((IntPtr)UserItem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                result = 1;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.MonGetRandomItems Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// 随机升级物品(极品属性)
        /// </summary>
        /// <param name="Item"></param>
        public unsafe void RandomUpgradeItem(TUserItem* Item)
        {
            TStdItem* StdItem = GetStdItem(Item->wIndex);
            if (StdItem == null || null == Item->btValue)
            {
                return;
            }
            switch (StdItem->StdMode)
            {
                case 5:
                case 6:// 武器
                    ItemUnit.RandomUpgradeWeapon(Item);
                    break;
                case 10:
                case 11:// 衣服
                    ItemUnit.RandomUpgradeDress(Item);
                    break;
                case 19:// 项链(幸运型)
                    ItemUnit.RandomUpgrade19(Item);
                    break;
                case 20:
                case 21:
                case 24:// 项链(准确敏捷型、体力魔法恢复型)、手镯(特别型)
                    ItemUnit.RandomUpgrade202124(Item);
                    break;
                case 26:// 手套手镯
                    ItemUnit.RandomUpgrade26(Item);
                    break;
                case 22:// 戒指
                    ItemUnit.RandomUpgrade22(Item);
                    break;
                case 23:// 戒指(特别型)
                    ItemUnit.RandomUpgrade23(Item);
                    break;
                case 15:
                case 16:// 头盔,斗笠
                    ItemUnit.RandomUpgradeHelMet(Item);
                    break;
                case 52:
                case 54:
                case 62:
                case 64: // 鞋子，腰带
                    ItemUnit.RandomUpgradeBoots(Item);
                    break;
            }
        }

        /// <summary>
        /// 随机升级物品
        /// </summary>
        /// <param name="Item"></param>
        public unsafe void GetUnknowItemValue(TUserItem* Item)
        {
            TStdItem* StdItem = GetStdItem(Item->wIndex);
            if (StdItem == null)
            {
                return;
            }
            switch (StdItem->StdMode)
            {
                case 15:
                case 16:// 神秘头盔,斗笠
                    ItemUnit.UnknowHelmet(Item);
                    break;
                case 22:
                case 23:// 神秘戒指
                    ItemUnit.UnknowRing(Item);
                    break;
                case 24:
                case 26:// 神秘手套手镯
                    ItemUnit.UnknowNecklace(Item);
                    break;
            }
        }

        /// <summary>
        /// 复制装备到玩家包裹
        /// </summary>
        /// <param name="sItemName"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public unsafe bool CopyToUserItemFromName(string sItemName, TUserItem* Item)
        {
            bool result = false;
            TStdItem* StdItem;
            try
            {
                if (sItemName != "" && Item->btValue != null)
                {
                    if (StdItemList.Count > 0)
                    {
                        for (int I = 0; I < StdItemList.Count; I++)
                        {
                            StdItem = (TStdItem*)StdItemList[I];
                            if (StdItem != null)
                            {
                                if (string.Compare(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), sItemName, true) == 0)
                                {
                                    HUtil32.ZeroMemory(Item, sizeof(TUserItem)); //修正变态物品属逼性 By Daomi
                                    Item->wIndex = Convert.ToUInt16(I + 1);
                                    Item->MakeIndex = M2Share.GetItemNumber();
                                    Item->Dura = StdItem->DuraMax;
                                    Item->DuraMax = StdItem->DuraMax;
                                    switch (StdItem->StdMode) //是魔令包和祝福罐,则把当前持久设置为0 
                                    {
                                        case 15:
                                        case 16:
                                        case 19:
                                        case 20:
                                        case 21:
                                        case 22:
                                        case 23:
                                        case 24:
                                        case 26:
                                            if ((StdItem->Shape == 130) || (StdItem->Shape == 131) || (StdItem->Shape == 132))
                                            {
                                                UserEngine.GetUnknowItemValue(Item);
                                            }
                                            break;
                                        case 2:
                                            if (StdItem->AniCount == 21)// 是魔令包和祝福罐,则把当前持久设置为0
                                            {
                                                Item->Dura = 0;
                                            }
                                            break;
                                        case 51:
                                            if (StdItem->Shape == 0)// 是聚灵珠,则把当前持久设置为0
                                            {
                                                Item->Dura = 0;
                                            }
                                            break;
                                        case 60: // 酒类,除烧酒外
                                            if (StdItem->Shape != 0)
                                            {
                                                Item->btValue[1] = Convert.ToByte(HUtil32.Random(40) + 10);// 酒的酒精度
                                                Item->btValue[0] = Convert.ToByte(HUtil32.Random(8));// 酒的品质
                                                if (StdItem->AniCount == 2)
                                                {
                                                    Item->btValue[2] = Convert.ToByte(HUtil32.Random(4) + 1);// 药力值
                                                }
                                            }
                                            break;
                                    }
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.CopyToUserItemFromName");
            }
            return result;
        }

        public void SendServerGroupMsg(int nCode, int nServerIdx, string sMsg)
        {
            if (M2Share.nServerIndex == 0)
            {
                M2Share.FrmSrvMsg.SendSocketMsg(nCode + "/" + EncryptUnit.EncodeString(nServerIdx.ToString()) + "/" + EncryptUnit.EncodeString(sMsg));
            }
            else
            {
                M2Share.FrmMsgClient.SendSocket(nCode + "/" + EncryptUnit.EncodeString(nServerIdx.ToString()) + "/" + EncryptUnit.EncodeString(sMsg));
            }
        }

        public unsafe TBaseObject AddHeroObject(TPlayObject PlayObject, int nX, int nY, THumDataInfo* HumanRcd)
        {
            TBaseObject result = null;
            THeroObject Cert;
            int n1C;
            int n20;
            int n24;
            object p28;
            TEnvirnoment Map = M2Share.g_MapManager.FindMap(PlayObject.m_sMapName);
            if (Map == null)
            {
                return result;
            }
            Cert = new THeroObject();
            if (Cert != null)
            {
                // MonInitialize(Cert, sMonName);
                GetHeroData(Cert, HumanRcd);// 取英雄的数据
                if (Cert.m_sHomeMap == "")// 第一次召唤
                {
                    Cert.m_sHomeMap = PlayObject.m_sHomeMap;
                    Cert.m_nHomeX = PlayObject.m_nHomeX;
                    Cert.m_nHomeY = PlayObject.m_nHomeY;
                    switch (Cert.n_HeroTpye)
                    {
                        case 0:
                            Cert.m_Abil.Level = GameConfig.nHeroStartLevel;
                            break;
                        case 1:
                            Cert.m_Abil.Level = GameConfig.nDrinkHeroStartLevel;
                            break;
                    }
                    Cert.m_boNewHuman = true;
                }
                else
                {
                    Cert.m_sHomeMap = PlayObject.m_sHomeMap;
                    Cert.m_nHomeX = PlayObject.m_nHomeX;
                    Cert.m_nHomeY = PlayObject.m_nHomeY;
                    Cert.m_boNewHuman = false;
                }
                Cert.m_PEnvir = Map;
                Cert.m_sMapName = PlayObject.m_sMapName;
                Cert.m_nCurrX = nX;
                Cert.m_nCurrY = nY;
                Cert.m_btDirection = (byte)HUtil32.Random(8);
                if (Cert.m_Abil.Exp <= 0)
                {
                    Cert.m_Abil.Exp = 1;
                }
                if (Cert.m_Abil.MaxExp <= 0)
                {
                    Cert.m_Abil.MaxExp = Cert.GetLevelExp(Cert.m_Abil.Level);
                }
                Cert.GetBagItemCount();
                Cert.m_btRaceImg = PlayObject.m_btRaceImg;
                Cert.RecalcLevelAbilitys();
                Cert.RecalcAbilitys();
                if (HUtil32.Random(100) < Cert.m_btCoolEye)
                {
                    Cert.m_boCoolEye = true;
                }
                Cert.Initialize();
                if (Cert.m_boAddtoMapSuccess)
                {
                    p28 = null;
                    if (Cert.m_PEnvir.m_nWidth < 50)
                    {
                        n20 = 2;
                    }
                    else
                    {
                        n20 = 3;
                    }
                    if ((Cert.m_PEnvir.m_nHeight < 250))
                    {
                        if ((Cert.m_PEnvir.m_nHeight < 30))
                        {
                            n24 = 2;
                        }
                        else
                        {
                            n24 = 20;
                        }
                    }
                    else
                    {
                        n24 = 50;
                    }
                    n1C = 0;
                    while (true)
                    {
                        if (!Cert.m_PEnvir.CanWalk(Cert.m_nCurrX, Cert.m_nCurrY, false))
                        {
                            if ((Cert.m_PEnvir.m_nWidth - n24 - 1) > Cert.m_nCurrX)
                            {
                                Cert.m_nCurrX += n20;
                            }
                            else
                            {
                                Cert.m_nCurrX = HUtil32.Random(Cert.m_PEnvir.m_nWidth / 2) + n24;
                                if (Cert.m_PEnvir.m_nHeight - n24 - 1 > Cert.m_nCurrY)
                                {
                                    Cert.m_nCurrY += n20;
                                }
                                else
                                {
                                    Cert.m_nCurrY = HUtil32.Random(Cert.m_PEnvir.m_nHeight / 2) + n24;
                                }
                            }
                        }
                        else
                        {
                            p28 = Cert.m_PEnvir.AddToMap(Cert.m_nCurrX, Cert.m_nCurrY, Grobal2.OS_MOVINGOBJECT, Cert);
                            break;
                        }
                        n1C++;
                        if (n1C >= 31)
                        {
                            break;
                        }
                    }
                    if (p28 == null)
                    {
                        Dispose(Cert);
                        Cert = null;
                    }
                }
            }
            result = Cert;
            return result;
        }

        private unsafe TBaseObject AddPlayObject(TPlayObject PlayObject, int nX, int nY, string sMonName)
        {
            TEnvirnoment Map;
            TBaseObject Cert;
            int n1C;
            int n20;
            int n24;
            object p28;
            TUserItem* UserItem;
            TUserMagic* UserMagic = null;
            TUserMagic* MonsterMagic = null;
            TStdItem* StdItem;
            Map = M2Share.g_MapManager.FindMap(PlayObject.m_sMapName);
            if (Map == null)
            {
                return null;
            }
            Cert = new TPlayMonster();
            if (Cert != null)
            {
                Cert.m_PEnvir = Map;
                Cert.m_sMapName = PlayObject.m_sMapName;
                Cert.m_nCurrX = nX;
                Cert.m_nCurrY = nY;
                Cert.m_btDirection = (byte)HUtil32.Random(8);
                Cert.m_sCharName = sMonName;
                Cert.m_Abil = PlayObject.m_Abil;
                Cert.m_Abil.HP = Cert.m_Abil.MaxHP;
                Cert.m_Abil.MP = Cert.m_Abil.MaxMP;
                // TPlayMonster(Cert).GetAbility(PlayObject.m_Abil);
                Cert.m_WAbil = PlayObject.m_WAbil;
                Cert.m_btJob = PlayObject.m_btJob;
                Cert.m_btGender = PlayObject.m_btGender;
                Cert.m_btHair = PlayObject.m_btHair;
                Cert.m_btRaceImg = PlayObject.m_btRaceImg;
                for (int I = PlayObject.m_UseItems.GetLowerBound(0); I <= PlayObject.m_UseItems.GetUpperBound(0); I++)
                {
                    if (PlayObject.m_UseItems[I]->wIndex > 0)
                    {
                        StdItem = UserEngine.GetStdItem(PlayObject.m_UseItems[I]->wIndex);
                        if (StdItem != null)
                        {
                            UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                            if (UserEngine.CopyToUserItemFromName(StdItem->ToString(), UserItem))
                            {
                                *UserItem->btValue = (byte)PlayObject.m_UseItems[I]->btValue; // 分身可以支持极品装备
                                UserItem->Dura = PlayObject.m_UseItems[I]->Dura;// 分身的装备持久与主体的一致
                                ((TPlayMonster)(Cert)).AddItems(UserItem, I);
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                            }
                        }
                    }
                }
                if (PlayObject.m_MagicList.Count > 0)
                {
                    for (int I = 0; I < PlayObject.m_MagicList.Count; I++)  // 添加魔法
                    {
                        UserMagic = (TUserMagic*)PlayObject.m_MagicList[I];
                        if (UserMagic != null)
                        {
                            MonsterMagic->MagicInfo = UserMagic->MagicInfo;
                            MonsterMagic->wMagIdx = UserMagic->wMagIdx;
                            MonsterMagic->btLevel = UserMagic->btLevel;
                            MonsterMagic->btKey = UserMagic->btKey;
                            MonsterMagic->nTranPoint = UserMagic->nTranPoint;
                            Cert.m_MagicList.Add((IntPtr)MonsterMagic);
                        }
                    }
                }
                ((TPlayMonster)(Cert)).InitializeMonster();// 初始化
                Cert.RecalcAbilitys();
                if (HUtil32.Random(100) < Cert.m_btCoolEye)
                {
                    Cert.m_boCoolEye = true;
                }
                Cert.Initialize();
                if (Cert.m_boAddtoMapSuccess)
                {
                    p28 = null;
                    if (Cert.m_PEnvir.m_nWidth < 50)
                    {
                        n20 = 2;
                    }
                    else
                    {
                        n20 = 3;
                    }
                    if ((Cert.m_PEnvir.m_nHeight < 250))
                    {
                        if ((Cert.m_PEnvir.m_nHeight < 30))
                        {
                            n24 = 2;
                        }
                        else
                        {
                            n24 = 20;
                        }
                    }
                    else
                    {
                        n24 = 50;
                    }
                    n1C = 0;
                    while (true)
                    {
                        if (!Cert.m_PEnvir.CanWalk(Cert.m_nCurrX, Cert.m_nCurrY, false))
                        {
                            if ((Cert.m_PEnvir.m_nWidth - n24 - 1) > Cert.m_nCurrX)
                            {
                                Cert.m_nCurrX += n20;
                            }
                            else
                            {
                                Cert.m_nCurrX = HUtil32.Random(Cert.m_PEnvir.m_nWidth / 2) + n24;
                                if (Cert.m_PEnvir.m_nHeight - n24 - 1 > Cert.m_nCurrY)
                                {
                                    Cert.m_nCurrY += n20;
                                }
                                else
                                {
                                    Cert.m_nCurrY = HUtil32.Random(Cert.m_PEnvir.m_nHeight / 2) + n24;
                                }
                            }
                        }
                        else
                        {
                            p28 = Cert.m_PEnvir.AddToMap(Cert.m_nCurrX, Cert.m_nCurrY, Grobal2.OS_MOVINGOBJECT, Cert);
                            break;
                        }
                        n1C++;
                        if (n1C >= 31)
                        {
                            break;
                        }
                    }
                    if (p28 == null)
                    {
                        Dispose(Cert);
                        Cert = null;
                    }
                }
            }
            return Cert;
        }


        private TBaseObject AddBaseObject(string sMapName, int nX, int nY, int nMonRace, string sMonName)
        {
            TEnvirnoment Map;
            TBaseObject Cert = null;
            int n1C;
            int n20;
            int n24;
            object p28;
            byte nCode;
            nCode = 0;
            try
            {
                Map = M2Share.g_MapManager.FindMap(sMapName);
                nCode = 1;
                if (Map == null)
                {
                    return null;
                }
                switch (nMonRace)
                {
                    case 11:// 大刀卫士
                        Cert = new TSuperGuard();
                        break;
                    case 20:// 鸡和神鹰
                        Cert = new TArcherPolice();
                        break;
                    case 51:// 鹿，羊，守卫
                        Cert = new TMonster();
                        Cert.m_boAnimal = true;
                        Cert.m_nMeatQuality = HUtil32.Random(3500) + 3000;
                        Cert.m_nBodyLeathery = 50;
                        break;
                    case 52:
                        if (HUtil32.Random(30) == 0)
                        {
                            Cert = new TChickenDeer();
                            Cert.m_boAnimal = true;
                            Cert.m_nMeatQuality = HUtil32.Random(20000) + 10000;
                            Cert.m_nBodyLeathery = 150;
                        }
                        else
                        {
                            Cert = new TMonster();
                            Cert.m_boAnimal = true;
                            Cert.m_nMeatQuality = HUtil32.Random(8000) + 8000;
                            Cert.m_nBodyLeathery = 150;
                        }
                        break;
                    case 53:// 狼
                        Cert = new TATMonster();
                        Cert.m_boAnimal = true;
                        Cert.m_nMeatQuality = HUtil32.Random(8000) + 8000;
                        Cert.m_nBodyLeathery = 150;
                        break;
                    case 55:// 练功师
                        Cert = new TTrainer();
                        Cert.m_btRaceServer = 55;
                        break;
                    case 80:
                        Cert = new TMonster();
                        break;
                    case 81:// 可能是  Tmonster主类 初始化
                        Cert = new TATMonster();
                        break;
                    case 82:// 物理攻击类的怪物,进入范围自动攻击
                        Cert = new TSpitSpider();
                        break;
                    case 83:// 攻击的时候吐毒的怪物  2x2范围内毒液攻击-弱
                        Cert = new TSlowATMonster();
                        break;
                    case 84:// 也是物理攻击的  其中有  蛤蟆 半兽人
                        Cert = new TScorpion();
                        break;
                    case 85:// 蝎子
                        Cert = new TStickMonster();
                        break;
                    case 86:// 食人花
                        Cert = new TATMonster();
                        break;
                    case 87:// 骷髅
                        Cert = new TDualAxeMonster();
                        break;
                    case 88:// 投斧头那种怪物 (远程攻击)
                        Cert = new TATMonster();
                        break;
                    case 89:// 骷髅战士
                        Cert = new TATMonster();
                        break;
                    case 90:// 骷髅战将   骷髅精灵   跟上面的一样类
                        Cert = new TGasAttackMonster();
                        break;
                    case 91:// 洞蛆
                        Cert = new TMagCowMonster();
                        break;
                    case 92:// 火焰沃玛
                        Cert = new TCowKingMonster();
                        break;
                    case 93:// 沃玛教主  其中攻击属于魔法(遇到攻击对象在范围外时会瞬移)
                        Cert = new TThornDarkMonster();
                        break;
                    case 94:// 暗黑战士  跟投斧差不多  也是远程攻击
                        Cert = new TLightingZombi();
                        break;
                    case 95:// 电僵尸 石墓尸王   从地下冒出来的怪
                        Cert = new TDigOutZombi();
                        if (HUtil32.Random(2) == 0)
                        {
                            Cert.bo2BA = true;
                        }
                        break;
                    case 96:// 这个 有代研究
                        Cert = new TZilKinZombi();
                        if (HUtil32.Random(4) == 0)
                        {
                            Cert.bo2BA = true;// 不进入火墙
                        }
                        break;
                    case 97:
                        Cert = new TCowMonster();// 沃玛战士   沃玛勇士  那类的  物理攻击
                        if (HUtil32.Random(2) == 0)
                        {
                            Cert.bo2BA = true;
                        }
                        break;
                    case 98:
                        Cert = new TSwordsmanMon();
                        break;
                    case 100:// 灵魂收割者,蓝影刀客 2格内可以攻击的怪
                        Cert = new TWhiteSkeleton();
                        break;
                    case 101:// 变异骷髅    道士召唤的宝宝 祖玛雕像  祖玛卫士 怪物刚开始是黑的(进入范围会从石像状态激活)
                        Cert = new TScultureMonster();
                        Cert.bo2BA = true;
                        break;
                    case 102:
                        Cert = new TScultureKingMonster();
                        break;
                    case 103:// 祖玛教主
                        Cert = new TBeeQueen();
                        break;
                    case 104:// 有代分析
                        Cert = new TArcherMonster();
                        break;
                    case 105:// 祖玛弓箭手  魔龙弓箭手 那类的
                        Cert = new TGasMothMonster();
                        break;
                    case 106:// 楔蛾
                        Cert = new TGasDungMonster();
                        break;
                    case 107:// 粪虫
                        Cert = new TCentipedeKingMonster();
                        break;
                    case 108:// 触龙神  不能动的怪物？
                        Cert = new TFairyMonster();// 月灵
                        Cert.bo2BA = true; // 不进入火墙
                        break;
                    case 110:// 沙巴克的 城门
                        Cert = new TCastleDoor();
                        break;
                    case 111:
                        Cert = new TWallStructure();
                        break;
                    case 112:// 沙巴克的 左墙,中，右
                        Cert = new TArcherGuard();
                        break;
                    case 113:// 弓箭手那类的 NPC
                        Cert = new TElfMonster();
                        break;
                    case 114:// 神兽
                        Cert = new TElfWarriorMonster();
                        break;
                    case 115:// 神兽1
                        Cert = new TBigHeartMonster();
                        break;
                    case 116:// 赤月恶魔  千年树妖  从地下冒刺的  不能动的怪
                        Cert = new TSpiderHouseMonster();
                        break;
                    case 117:// 属于可以 怪生怪的 怪
                        Cert = new TExplosionSpider();
                        break;
                    case 118:// 幻影蜘蛛
                        Cert = new THighRiskSpider();
                        break;
                    case 119:// 天狼蜘蛛
                        Cert = new TBigPoisionSpider();
                        break;
                    case 120:// 花吻蜘蛛
                        Cert = new TSoccerBall();
                        break;
                    case 121:// 飞火流星   其实就是足球
                        Cert = new TGiantSickleSpiderATMonster();
                        break;
                    case 122:// 巨镰蜘蛛
                        Cert = new TSalamanderATMonster();
                        break;
                    case 123:// 狂热火蜥蜴
                        Cert = new TTempleGuardian();
                        break;
                    case 124:// 圣殿卫士
                        Cert = new TheCrutchesSpider();
                        break;
                    case 125:// 金杖蜘蛛
                        Cert = new TYanLeiWangSpider();
                        break;
                    case 126:// 雷炎蛛王
                        Cert = new TSnowyFireDay();
                        break;
                    case 127:// 雪域灭天魔 用灭天火,会施放红毒
                        Cert = new TDevilBat();
                        break;
                    case 128:// 恶魔蝙蝠 施毒术,气功波,抗拒,野蛮对它无效,只有道士捆魔咒可以捆住,只有战士刺杀的第2格能攻击到,攻击方式靠近人物自爆攻击
                        Cert = new TFireDragon();
                        break;
                    case 129:// 火龙魔兽
                        Cert = new TFireDragonGuard();
                        break;
                    case 130:// 火龙守护兽
                        Cert = new TSnowyHanbing();
                        break;
                    case 131:// 雪域寒冰魔:冰咆哮，会施放绿毒
                        Cert = new TSnowyWuDu();
                        break;
                    case 132:// 雪域五毒魔:寒冰掌,治疗术
                        Cert = new TElfMonster();
                        break;
                    case 135:// 圣兽
                        Cert = new TArcherGuardMon();
                        break;
                    case 136:// 类似弓箭手的怪,只打怪物
                        Cert = new TArcherGuardMon1();
                        break;
                    case 150:// 不会移动,不会攻击的怪 魔王岭的怪
                        Cert = new TPlayMonster();
                        break;
                    case 200:// 人形怪
                        Cert = new TElectronicScolpionMon();
                        break;
                }
                nCode = 2;
                if (Cert != null)
                {
                    nCode = 3;
                    MonInitialize(Cert, sMonName);
                    nCode = 4;
                    Cert.m_PEnvir = Map;
                    Cert.m_sMapName = sMapName;
                    Cert.m_nCurrX = nX;
                    Cert.m_nCurrY = nY;
                    Cert.m_btDirection = (byte)HUtil32.Random(8);
                    Cert.m_sCharName = sMonName;
                    Cert.m_WAbil = Cert.m_Abil;
                    nCode = 5;
                    if (HUtil32.Random(100) < Cert.m_btCoolEye)
                    {
                        Cert.m_boCoolEye = true;
                    }
                    nCode = 6;
                    MonGetRandomItems(Cert); // 取得怪物可以爆物品
                    nCode = 7;
                    Cert.Initialize();
                    nCode = 8;
                    switch (nMonRace)
                    {
                        case 108:// 保存月灵DB设置的走路速度
                            ((TFairyMonster)(Cert)).nWalkSpeed = Cert.m_nWalkSpeed;
                            break;
                        case 121:// 巨镰蜘蛛(读取可探索物品)
                            ((TGiantSickleSpiderATMonster)(Cert)).AddItemsFromConfig();
                            break;
                        case 122:// 狂热火蜥蜴(读取可探索物品)
                            ((TSalamanderATMonster)(Cert)).AddItemsFromConfig();
                            break;
                        case 123:// 圣殿卫士(读取可探索物品)
                            ((TTempleGuardian)(Cert)).AddItemsFromConfig();
                            break;
                        case 124:// 金杖蜘蛛(读取可探索物品)
                            ((TheCrutchesSpider)(Cert)).AddItemsFromConfig();
                            break;
                        case 125:// 雷炎蛛王(读取可探索物品)
                            ((TYanLeiWangSpider)(Cert)).AddItemsFromConfig();
                            break;
                        case 136:// 136怪自动走动 魔王岭怪
                            if ((m_nCurrX_136 != 0) && (m_nCurrY_136 != 0))
                            {
                                Cert.m_nCurrX = m_nCurrX_136;
                                Cert.m_nCurrY = m_nCurrY_136;
                                ((TArcherGuardMon1)(Cert)).m_NewCurrX = m_NewCurrX_136;
                                ((TArcherGuardMon1)(Cert)).m_NewCurrY = m_NewCurrY_136;
                                ((TArcherGuardMon1)(Cert)).m_boWalk = true;
                            }
                            break;
                        case 150:// 人型怪
                            Cert.m_nCopyHumanLevel = 0;
                            Cert.m_Abil.MP = Cert.m_Abil.MaxMP;
                            Cert.m_Abil.HP = Cert.m_Abil.MaxHP;// 数据库HP为0,使怪一出来就死
                            Cert.m_WAbil = Cert.m_Abil;
                            ((TPlayMonster)(Cert)).InitializeMonster();// 初始化人形怪物,读文件配置(技能,装备)
                            Cert.RecalcAbilitys();
                            break;
                    }
                    nCode = 9;
                    if (Cert.m_boAddtoMapSuccess)
                    {
                        p28 = null;
                        if (Cert.m_PEnvir.m_nWidth < 50)
                        {
                            n20 = 2;
                        }
                        else
                        {
                            n20 = 3;
                        }
                        if ((Cert.m_PEnvir.m_nHeight < 250))
                        {
                            if ((Cert.m_PEnvir.m_nHeight < 30))
                            {
                                n24 = 2;
                            }
                            else
                            {
                                n24 = 20;
                            }
                        }
                        else
                        {
                            n24 = 50;
                        }
                        n1C = 0;
                        while (true)
                        {
                            if (!Cert.m_PEnvir.CanWalk(Cert.m_nCurrX, Cert.m_nCurrY, false))
                            {
                                if ((Cert.m_PEnvir.m_nWidth - n24 - 1) > Cert.m_nCurrX)
                                {
                                    Cert.m_nCurrX += n20;
                                }
                                else
                                {
                                    Cert.m_nCurrX = HUtil32.Random(Cert.m_PEnvir.m_nWidth / 2) + n24;
                                    if (Cert.m_PEnvir.m_nHeight - n24 - 1 > Cert.m_nCurrY)
                                    {
                                        Cert.m_nCurrY += n20;
                                    }
                                    else
                                    {
                                        Cert.m_nCurrY = HUtil32.Random(Cert.m_PEnvir.m_nHeight / 2) + n24;
                                    }
                                }
                            }
                            else
                            {
                                p28 = Cert.m_PEnvir.AddToMap(Cert.m_nCurrX, Cert.m_nCurrY, Grobal2.OS_MOVINGOBJECT, Cert);
                                break;
                            }
                            n1C++;
                            if (n1C >= 31)
                            {
                                break;
                            }
                        }
                        if (p28 == null)
                        {
                            Dispose(Cert);
                        }
                        if (Cert != null)
                        {
                            Cert.m_nViewRange += 2;//怪物视觉+2
                        }
                    }
                }
                nCode = 10;
                if (Cert != null)
                {
                    if (Cert.m_btRaceServer == 150)
                    {
                        // 取守护坐标
                        ((TPlayMonster)(Cert)).m_nProtectTargetX = Cert.m_nCurrX;// 守护坐标
                        ((TPlayMonster)(Cert)).m_nProtectTargetY = Cert.m_nCurrY;// 守护坐标
                    }
                }
            }
            catch (Exception ex)
            {
                M2Share.MainOutMessage(ex.Message);
                M2Share.MainOutMessage("{异常} TUserEngine.AddBaseObject MonRace:" + nMonRace + " Code:" + nCode);
            }
            return Cert;
        }

        /// <summary>
        /// 功能:创建怪物对象
        /// 返回值：在指定时间内创建完对象，则返加TRUE，如果超过指定时间则返回FALSE
        /// </summary>
        /// <param name="MonGen"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        private bool RegenMonsters(TMonGenInfo MonGen, int nCount)
        {
            bool result = true;
            uint dwStartTick = HUtil32.GetTickCount();
            int nX;
            int nY;
            TBaseObject Cert;
            const string sExceptionMsg = "{异常} TUserEngine::RegenMonsters";
            try
            {
                if (MonGen != null)
                {
                    if (MonGen.nRace > 0)
                    {
                        if (nCount <= 0)
                        {
                            nCount = 1;
                        }
                        if (HUtil32.Random(100) < MonGen.nMissionGenRate)
                        {
                            nX = (MonGen.nX - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                            nY = (MonGen.nY - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                            for (int I = 0; I < nCount; I++)
                            {
                                Cert = AddBaseObject(MonGen.sMapName, ((nX - 10) + HUtil32.Random(20)), ((nY - 10) + HUtil32.Random(20)), MonGen.nRace, MonGen.sMonName);
                                if (Cert != null)
                                {
                                    Cert.m_nChangeColorType = MonGen.nChangeColorType;// 是否变色
                                    Cert.m_btNameColor = MonGen.nNameColor; // 自定义名字的颜色
                                    if (MonGen.nNameColor != 255)
                                    {
                                        Cert.m_boSetNameColor = true; // 自定义名字颜色
                                    }
                                    Cert.m_boIsNGMonster = MonGen.boIsNGMon;// 内功怪,打死可以增加内力值
                                    MonGen.CertList.Add(Cert);
                                    Cert.AddMapCount();
                                }
                                if ((HUtil32.GetTickCount() - dwStartTick) > M2Share.g_dwZenLimit)
                                {
                                    result = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int I = 0; I < nCount; I++)
                            {
                                nX = (MonGen.nX - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                                nY = (MonGen.nY - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                                Cert = AddBaseObject(MonGen.sMapName, nX, nY, MonGen.nRace, MonGen.sMonName);
                                if (Cert != null)
                                {
                                    Cert.m_nChangeColorType = MonGen.nChangeColorType;// 是否变色
                                    Cert.m_btNameColor = MonGen.nNameColor;// 自定义怪物名字颜色
                                    if (MonGen.nNameColor != 255)
                                    {
                                        Cert.m_boSetNameColor = true;// 自定义名字颜色
                                    }
                                    Cert.m_boIsNGMonster = MonGen.boIsNGMon;// 内功怪,打死可以增加内力值
                                    MonGen.CertList.Add(Cert);
                                    Cert.AddMapCount();
                                }
                                if ((HUtil32.GetTickCount() - dwStartTick) > M2Share.g_dwZenLimit)
                                {
                                    result = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            return result;
        }

        /// <summary>
        /// 取师傅
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public TPlayObject GetMasterObject(string sName)
        {
            TPlayObject result = null;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                for (int I = 0; I < m_PlayObjectList.Count; I++)
                {
                    PlayObject = m_PlayObjectList[I];
                    if (PlayObject != null)
                    {
                        if ((!PlayObject.m_boGhost))
                        {
                            if (!(PlayObject.m_boPasswordLocked && PlayObject.m_boObMode && PlayObject.m_boAdminMode))
                            {
                                if ((PlayObject.m_sMasterName).ToLower().CompareTo((sName).ToLower()) == 0)
                                {
                                    result = PlayObject;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 根据玩家名称取玩家对象
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public TPlayObject GetPlayObject(string sName)
        {
            return m_PlayObjectList.Find(PlayObject =>
                    {
                        return PlayObject.m_sCharName == sName && !PlayObject.m_boGhost && !PlayObject.m_boPasswordLocked
                            && PlayObject.m_boObMode && PlayObject.m_boAdminMode;
                    });
        }

        /// <summary>
        /// 根据当前对象获取玩家对象
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <returns></returns>
        public TPlayObject GetPlayObject(TBaseObject PlayObject)
        {
            return m_PlayObjectList.Find(P =>
            {
                return P == PlayObject;
            });
        }

        /// <summary>
        /// 按英雄名字查找英雄
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public TBaseObject GetHeroObject(string sName)
        {
            return m_PlayObjectList.Find(T =>
            {
                return T.m_sCharName == sName;
            });
        }

        /// <summary>
        /// 按当前对象查找英雄
        /// </summary>
        /// <param name="HeroObject"></param>
        /// <returns></returns>
        public TPlayObject GetHeroObject(TBaseObject HeroObject)
        {
            return m_PlayObjectList.Find(c =>
            {
                return c.m_MyHero == HeroObject;
            });
        }

        /// <summary>
        /// 剔除指定玩家
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sName"></param>
        public void KickPlayObjectEx(string sAccount, string sName)
        {
            TPlayObject PlayObject;
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                if (m_PlayObjectList.Count > 0)
                {
                    PlayObject = m_PlayObjectList.Find(P =>
                    {
                        return P.m_sUserID == sAccount && P.m_sCharName == sName;
                    });
                    if (PlayObject != null)
                    {
                        if (((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0) &&
                            ((PlayObject.m_sCharName).ToLower().CompareTo((sName).ToLower()) == 0))
                        {
                            PlayObject.m_boEmergencyClose = true;
                            PlayObject.m_boPlayOffLine = false;
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        public TPlayObject GetPlayObjectEx(string sAccount, string sName)
        {
            TPlayObject result = null;
            TPlayObject PlayObject;
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                if (m_PlayObjectList.Count > 0)
                {
                    PlayObject = m_PlayObjectList.Find(P =>
                    {
                        return P.m_sUserID == sAccount && P.m_sCharName == sName;
                    });
                    if (PlayObject != null)
                    {
                        if (string.Compare(PlayObject.m_sUserID, sAccount, true) == 0 && string.Compare(PlayObject.m_sCharName, sName, true) == 0)
                        {
                            result = PlayObject;
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 获取离线挂人物
        /// </summary>
        /// <param name="sAccount"></param>
        /// <returns></returns>
        public TPlayObject GetPlayObjectExOfAutoGetExp(string sAccount)
        {
            TPlayObject result = null;
            TPlayObject PlayObject;
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                if (m_PlayObjectList.Count > 0)
                {
                    PlayObject = m_PlayObjectList.Find(P =>
                    {
                        return P.m_sUserID == sAccount && P.m_boNotOnlineAddExp;
                    });
                    if (PlayObject != null)
                    {
                        if (((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0) && PlayObject.m_boNotOnlineAddExp)
                        {
                            result = PlayObject;
                        }
                    }
                    #region 以前代码
                    //for (I = 0; I < m_PlayObjectList.Count; I++)
                    //{
                    //    PlayObject = m_PlayObjectList[I];
                    //    if (PlayObject != null)
                    //    {
                    //        if (((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0) && PlayObject.m_boNotOnlineAddExp)
                    //        {
                    //            result = PlayObject;
                    //            break;
                    //        }
                    //    }
                    //}
                    #endregion
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 查找交易NPC
        /// </summary>
        /// <param name="Merchant"></param>
        /// <returns></returns>
        public TMerchant FindMerchant(int Merchant)
        {
            TMerchant result = null;
            lock (m_MerchantList)
            {
                try
                {
                    if (m_MerchantList.Count > 0)
                    {
                        //TMerchant Npc = GetObject<TMerchant>(Merchant);//By Daomi 修正点击管理类NPC出现类型转换错误，导致引擎崩溃
                        result = m_MerchantList.Find(M =>
                        {
                            return Parse(M) == Merchant;
                        });
                    }
                }
                finally
                {
                }
            }
            return result;
        }

        /// <summary>
        /// 查找管理NPC
        /// </summary>
        /// <param name="GuildOfficial"></param>
        /// <returns></returns>
        public TGuildOfficial FindNPC(int GuildOfficial)
        {
            return (TGuildOfficial)QuestNPCList.Find(N =>
              {
                  return Parse(N) == GuildOfficial;
              });
        }

        public int GetMapOfRangeHumanCount(TEnvirnoment Envir, int nX, int nY, int nRange)
        {
            int result = 0;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                for (int I = 0; I < m_PlayObjectList.Count; I++)
                {
                    PlayObject = m_PlayObjectList[I];
                    if (PlayObject != null)
                    {
                        if (!PlayObject.m_boGhost && (PlayObject.m_PEnvir == Envir))
                        {
                            if ((Math.Abs(PlayObject.m_nCurrX - nX) < nRange) && (Math.Abs(PlayObject.m_nCurrY - nY) < nRange))
                            {
                                result++;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 取人物权限
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sIPaddr"></param>
        /// <param name="btPermission"></param>
        /// <returns></returns>
        public bool GetHumPermission(string sUserName, ref string sIPaddr, ref byte btPermission)
        {
            bool result = false;
            TAdminInfo AdminInfo;
            btPermission = GameConfig.nStartPermission;
            HUtil32.EnterCriticalSection(m_AdminList);
            try
            {
                if (m_AdminList.Count > 0)
                {
                    for (int I = 0; I < m_AdminList.Count; I++)
                    {
                        AdminInfo = m_AdminList[I];
                        if (AdminInfo != null)
                        {
                            if (string.Compare(AdminInfo.sChrName, sUserName, true) == 0)
                            {
                                btPermission = (byte)AdminInfo.nLv;
                                sIPaddr = AdminInfo.sIPaddr;
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_AdminList);
            }
            return result;
        }

        public void AddUserOpenInfo(TUserOpenInfo UserOpenInfo)
        {
            HUtil32.EnterCriticalSection(m_LoadPlaySection);
            try
            {
                m_LoadPlayList.Add(UserOpenInfo);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_LoadPlaySection);
            }
        }

        /// <summary>
        /// 踢出在线人物
        /// </summary>
        /// <param name="sChrName"></param>
        private void KickOnlineUser(string sChrName)
        {
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                foreach (var item in m_PlayObjectList)
                {
                    PlayObject = item;
                    if (PlayObject != null)
                    {
                        if (string.Compare(PlayObject.m_sCharName, sChrName, true) == 0)
                        {
                            PlayObject.m_boKickFlag = true;
                            break;
                        }
                    }
                }
            }
        }

        private bool SendSwitchData(TPlayObject PlayObject, int nServerIndex)
        {
            return true;
        }

        private void SendChangeServer(TPlayObject PlayObject, int nServerIndex)
        {
            const string sMsg = "{0}/{1}";
            string sIPaddr = string.Empty;
            int nPort = 0;
            if (M2Share.GetMultiServerAddrPort(nServerIndex, ref sIPaddr, ref nPort))
            {
                PlayObject.SendDefMessage(Grobal2.SM_RECONNECT, 0, 0, 0, 0, string.Format(sMsg, sIPaddr, nPort));
            }
        }

        /// <summary>
        /// 保存人数数据
        /// </summary>
        /// <param name="PlayObject"></param>
        public void SaveHumanRcd(TPlayObject PlayObject)
        {
            TSaveRcd SaveRcd;
            byte nCode = 0;
            try
            {
                if (PlayObject != null)
                {
                    if (PlayObject.m_boOperationItemList)
                    {
                        return;
                    }
                    if (PlayObject.m_boRcdSaveding)
                    {
                        return;
                    }
                    PlayObject.m_boRcdSaveding = true;
                    try
                    {
                        nCode = 1;
                        SaveRcd = new TSaveRcd();
                        SaveRcd.sAccount = PlayObject.m_sUserID;
                        SaveRcd.sChrName = PlayObject.m_sCharName;
                        SaveRcd.nSessionID = PlayObject.m_nSessionID;
                        SaveRcd.PlayObject = Parse(PlayObject);
                        SaveRcd.nReTryCount = 0;
                        SaveRcd.dwSaveTick = HUtil32.GetTickCount();
                        SaveRcd.boIsHero = false;
                        nCode = 2;
                        unsafe
                        {
                            fixed (THumDataInfo* data = &SaveRcd.HumanRcd)
                            {
                                PlayObject.MakeSaveRcd(data);
                            }
                        }
                        nCode = 3;
                        if (M2Share.FrontEngine.UpDataSaveRcdList(SaveRcd))
                        {
                            SaveRcd = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        M2Share.MainOutMessage(ex.Message);
                    }
                    finally
                    {
                        PlayObject.m_boRcdSaveding = false;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.SaveHumanRcd Code:" + nCode);
            }
        }

        /// <summary>
        /// 保存英雄数据
        /// </summary>
        /// <param name="PlayObject"></param>
        public void SaveHeroRcd(TPlayObject PlayObject)
        {
            TSaveRcd SaveRcd;
            byte nCode = 0;
            try
            {
                if (PlayObject != null)
                {
                    nCode = 1;
                    if (PlayObject.m_boOperationItemList)
                    {
                        return;
                    }
                    nCode = 2;
                    if (PlayObject.m_MyHero != null)
                    {
                        if (PlayObject.m_boRcdSaveding)
                        {
                            return;
                        }
                        PlayObject.m_boRcdSaveding = true;
                        try
                        {
                            SaveRcd = new TSaveRcd();
                            nCode = 3;
                            SaveRcd.sAccount = PlayObject.m_sUserID;
                            SaveRcd.sChrName = PlayObject.m_MyHero.m_sCharName;
                            SaveRcd.nSessionID = PlayObject.m_nSessionID;
                            SaveRcd.PlayObject = Parse(PlayObject);
                            SaveRcd.nReTryCount = 0;
                            SaveRcd.dwSaveTick = HUtil32.GetTickCount();
                            SaveRcd.boIsHero = true;
                            if (((THeroObject)(PlayObject.m_MyHero)).m_btMentHero == 2)
                            {
                                SaveRcd.boisDoubleHero = true;//是否是副将英雄
                            }
                            nCode = 4;
                            unsafe
                            {
                                fixed (THumDataInfo* data = &SaveRcd.HumanRcd)
                                {
                                    ((THeroObject)(PlayObject.m_MyHero)).MakeSaveRcd(data);
                                }
                            }
                            nCode = 5;
                            if (M2Share.FrontEngine.UpDataSaveRcdList(SaveRcd))
                            {
                                SaveRcd = null;
                            }
                        }
                        finally
                        {
                            PlayObject.m_boRcdSaveding = false;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.SaveHeroRcd Code:" + nCode);
            }
        }

        /// <summary>
        /// 加入销毁列表
        /// </summary>
        /// <param name="PlayObject"></param>
        private void AddToHumanFreeList(TPlayObject PlayObject)
        {
            PlayObject.m_dwGhostTick = HUtil32.GetTickCount();
            m_PlayObjectFreeList.Add(PlayObject);
        }

        /// <summary>
        /// 取数据库人物的数据
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="HumanRcd"></param>
        public unsafe void GetHumData(TPlayObject PlayObject, THumDataInfo* HumanRcd)
        {
            THumData* HumData;
            TUserItem* HumItems;
            TUserItem* HumAddItems;
            TUserItem* BagItems;
            TUserItem* UserItem;
            THumMagic* HumMagics;
            THumMagic* HumNGMagics;
            TUserMagic* UserMagic = null;
            THumMagic* HumBatterMagics;
            TMagic* MagicInfo;
            TUserItem* StorageItems;
            IniFile IniFile;
            string sFileName;
            string sMap = string.Empty;
            string sX = string.Empty;
            string sY = string.Empty;
            HumData = &HumanRcd->Data;
            PlayObject.m_sCharName = HUtil32.SBytePtrToString(HumData->sChrName, HumData->ChrNameLen);
            PlayObject.m_sMapName = HUtil32.SBytePtrToString(HumData->sCurMap, HumData->CurMapLen);
            PlayObject.m_nCurrX = HumData->wCurX;
            PlayObject.m_nCurrY = HumData->wCurY;
            PlayObject.m_btDirection = HumData->btDir;
            PlayObject.m_btHair = HumData->btHair;
            PlayObject.m_btGender = HumData->btSex;
            PlayObject.m_btJob = HumData->btJob;
            PlayObject.m_nGold = HumData->nGold;
            PlayObject.m_sLastMapName = PlayObject.m_sMapName;//增加人物上次退出地图
            PlayObject.m_nLastCurrX = PlayObject.m_nCurrX;//增加人物上次退出所在座标X
            PlayObject.m_nLastCurrY = PlayObject.m_nCurrY; //增加人物上次退出所在座标Y
            PlayObject.m_Abil.Level = HumData->Abil.Level;
            PlayObject.m_Abil.HP = HumData->Abil.HP;
            PlayObject.m_Abil.MP = HumData->Abil.MP;
            PlayObject.m_Abil.MaxHP = HumData->Abil.MaxHP;
            PlayObject.m_Abil.MaxMP = HumData->Abil.MaxMP;
            PlayObject.m_Abil.Exp = (uint)HumData->Abil.Exp;
            PlayObject.m_Abil.MaxExp = (uint)HumData->Abil.MaxExp;
            PlayObject.m_Abil.Weight = HumData->Abil.Weight;
            PlayObject.m_Abil.MaxWeight = HumData->Abil.MaxWeight;
            PlayObject.m_Abil.WearWeight = (ushort)HumData->Abil.WearWeight;
            PlayObject.m_Abil.MaxWearWeight = (ushort)HumData->Abil.MaxWearWeight;
            PlayObject.m_Abil.HandWeight = (ushort)HumData->Abil.HandWeight;
            PlayObject.m_Abil.MaxHandWeight = (ushort)HumData->Abil.MaxHandWeight;
            PlayObject.m_Abil.Alcohol = HumData->n_Reserved;// 酒量
            PlayObject.m_Abil.MaxAlcohol = HumData->n_Reserved1;// 酒量上限
            if (PlayObject.m_Abil.MaxAlcohol < GameConfig.nMaxAlcoholValue)
            {
                PlayObject.m_Abil.MaxAlcohol = GameConfig.nMaxAlcoholValue; // 酒量上限小限初始值时,则修改
            }
            PlayObject.m_Abil.WineDrinkValue = HumData->n_Reserved2;// 醉酒度
            PlayObject.n_DrinkWineQuality = HumData->btUnKnow2[2];// 饮酒时酒的品质
            PlayObject.n_DrinkWineAlcohol = HumData->UnKnow[4];// 饮酒时酒的度数
            PlayObject.m_btMagBubbleDefenceLevel = HumData->UnKnow[5];// 魔法盾等级
            PlayObject.m_Abil.MedicineValue = (ushort)HumData->nReserved1;// 当前药力值
            PlayObject.m_Abil.MaxMedicineValue = (ushort)HumData->nReserved2;// 药力值上限
            PlayObject.n_DrinkWineDrunk = HumData->boReserved3;// 人是否喝酒醉了
            PlayObject.dw_UseMedicineTime = (ushort)HumData->nReserved3;// 使用药酒时间,计算长时间没使用药酒
            PlayObject.n_MedicineLevel = HumData->n_Reserved3;// 药力值等级
            if (PlayObject.n_MedicineLevel <= 0)
            {
                PlayObject.n_MedicineLevel = 1;// 如果药力值等级为0,则设置为1
            }
            if (PlayObject.m_Abil.MaxMedicineValue <= 0)
            {
                PlayObject.m_Abil.MaxMedicineValue = PlayObject.GetMedicineExp(PlayObject.n_MedicineLevel);
            }
            PlayObject.m_Exp68 = (uint)HumData->Exp68;// 酒气护体当前经验
            PlayObject.m_MaxExp68 = (uint)HumData->MaxExp68;// 酒气护体升级经验
            PlayObject.m_boTrainingNG = HumData->UnKnow[6] != 0;
            if (PlayObject.m_boTrainingNG)  // 是否学习过内功
            {
                PlayObject.m_NGLevel = HumData->UnKnow[7];// 内功等级
            }
            else
            {
                PlayObject.m_NGLevel = 0;
            }
            PlayObject.m_ExpSkill69 = (uint)HumData->nExpSkill69;// 内功当前经验
            PlayObject.m_Skill69NH = HumData->Abil.NG;// 内功当前内力值
            PlayObject.m_Skill69MaxNH = HumData->Abil.MaxNG;// 内力值上限
            if (PlayObject.m_Abil.Exp <= 0)
            {
                PlayObject.m_Abil.Exp = 1;
            }
            if (PlayObject.m_Abil.MaxExp <= 0)
            {
                PlayObject.m_Abil.MaxExp = PlayObject.GetLevelExp(PlayObject.m_Abil.Level);
            }
            PlayObject.m_wStatusTimeArr = HUtil32.ushortPrtToushortArray(HumData->wStatusTimeArr, 13);
            PlayObject.m_sHomeMap = HUtil32.SBytePtrToString(HumData->sHomeMap, 0, HumData->HomeMapLen);
            PlayObject.m_nHomeX = HumData->wHomeX;
            PlayObject.m_nHomeY = HumData->wHomeY;
            PlayObject.m_BonusAbil = HumData->BonusAbil;
            PlayObject.m_nBonusPoint = HumData->nBonusPoint;
            PlayObject.m_btCreditPoint = HumData->btCreditPoint;
            PlayObject.m_btReLevel = HumData->btReLevel;
            PlayObject.m_sMasterName = HUtil32.SBytePtrToString(HumData->sMasterName, 0, HumData->MasterNameLen);
            PlayObject.m_boMaster = HumData->boMaster;
            if (PlayObject.m_boMaster || (PlayObject.m_sMasterName != ""))
            {
                PlayObject.GetMasterNoList(); // 取师徒数据
            }
            PlayObject.m_sDearName = HUtil32.SBytePtrToString(HumData->sDearName, 0, HumData->DearNameLen);
            PlayObject.m_sStoragePwd = HUtil32.SBytePtrToString(HumData->sStoragePwd, 0, HumData->StoragePwdLen);
            if (PlayObject.m_sStoragePwd != "")
            {
                PlayObject.m_boPasswordLocked = true;
            }
            PlayObject.m_nGameGold = HumData->nGameGold;
            PlayObject.m_nGAMEDIAMOND = HumData->nGameDiaMond;// 金刚石
            PlayObject.m_nGAMEGIRD = HumData->nGameGird;// 灵符
            PlayObject.m_nKillMonExpRate = HumData->nEXPRATE;// 经验倍数
            PlayObject.m_dwKillMonExpRateTime = (ushort)HumData->nExpTime;// 经验倍数时间
            PlayObject.m_nOldKillMonExpRate = PlayObject.m_nKillMonExpRate;
            if (PlayObject.m_nKillMonExpRate <= 0)
            {
                PlayObject.m_nKillMonExpRate = 100;
            }
            PlayObject.m_nGamePoint = (ushort)HumData->nGamePoint;
            PlayObject.m_nPayMentPoint = HumData->nPayMentPoint;
            PlayObject.m_btGameGlory = HumData->btGameGlory;// 荣誉
            PlayObject.m_nPkPoint = HumData->nPKPOINT;
            if (HumData->btAllowGroup > 0)
            {
                PlayObject.m_boAllowGroup = true;
            }
            else
            {
                PlayObject.m_boAllowGroup = false;
            }
            PlayObject.btB2 = HumData->btF9;
            PlayObject.m_btAttatckMode = HumData->btAttatckMode;
            PlayObject.m_nIncHealth = HumData->btIncHealth;
            PlayObject.m_nIncSpell = HumData->btIncSpell;
            PlayObject.m_nIncHealing = HumData->btIncHealing;
            PlayObject.m_nFightZoneDieCount = HumData->btFightZoneDieCount;
            PlayObject.m_sUserID = HUtil32.SBytePtrToString(HumData->sAccount, 0, HumData->AccountLen);
            PlayObject.m_boLockLogon = HumData->boLockLogon;
            PlayObject.m_wContribution = HumData->wContribution;
            PlayObject.m_nHungerStatus = HumData->nHungerStatus;
            PlayObject.m_boAllowGuildReCall = HumData->boAllowGuildReCall;
            PlayObject.m_wGroupRcallTime = HumData->wGroupRcallTime;
            PlayObject.m_dBodyLuck = HumData->dBodyLuck;
            PlayObject.m_boAllowGroupReCall = HumData->boAllowGroupReCall;
            PlayObject.m_btLastOutStatus = HumData->btLastOutStatus; // 退出状态 1为死亡
            PlayObject.m_wMasterCount = HumData->wMasterCount;// 出师徒弟数
            PlayObject.bo_YBDEAL = HumData->btUnKnow2[0] == 1;// 是否开通元宝寄售
            PlayObject.m_nWinExp = (uint)HumData->n_WinExp;// 聚灵珠  累计经验
            PlayObject.n_UsesItemTick = HumData->n_UsesItemTick; // 聚灵珠聚集时间
            PlayObject.m_QuestFlag = HUtil32.BytePtrToByteArray(HumData->QuestFlag, 127);
            PlayObject.m_boHasHero = HumData->boHasHero;
            PlayObject.m_boHasHeroTwo = HumData->boReserved1; // 是否有卧龙英雄
            PlayObject.m_sHeroCharName = HUtil32.SBytePtrToString(HumData->sHeroChrName, 0, HumData->HeroChrName);
            PlayObject.m_sDeputyHeroCharName = HUtil32.SBytePtrToString(HumData->sMentHeroChrName, 0, HumData->MentHeroChrNameLen);// 副将英雄名字
            PlayObject.n_HeroSave = HumData->btUnKnow2[1];// 是否保存英雄 
            PlayObject.n_myHeroTpye = HumData->btEF;// 角色身上带的英雄所属的类型  
            PlayObject.m_boPlayDrink = HumData->boReserved;// 是否请过酒 T-请过酒 
            PlayObject.m_GiveGuildFountationDate = HumData->m_GiveDate;// 人物领取行会酒泉日期 
            PlayObject.m_boMakeWine = HumData->boReserved2;// 是否酿酒 
            PlayObject.m_MakeWineTime = (ushort)HumData->nReserved;// 酿酒的时间,即还有多长时间可以取回酒 
            PlayObject.n_MakeWineItmeType = HumData->UnKnow[0];// 酿酒后,应该可以得到酒的类型 
            PlayObject.n_MakeWineType = HumData->UnKnow[1];// 酿酒的类型 1-普通酒 2-药酒  
            PlayObject.n_MakeWineQuality = HumData->UnKnow[2];// 酿酒后,应该可以得到酒的品质 
            PlayObject.n_MakeWineAlcohol = HumData->UnKnow[3];// 酿酒后,应该可以得到酒的酒精度 
            HumItems = (TUserItem*)HumanRcd->Data.HumItemsBuff;
            *PlayObject.m_UseItems[TPosition.U_DRESS] = HumItems[TPosition.U_DRESS];
            *PlayObject.m_UseItems[TPosition.U_WEAPON] = HumItems[TPosition.U_WEAPON];
            *PlayObject.m_UseItems[TPosition.U_RIGHTHAND] = HumItems[TPosition.U_RIGHTHAND];
            *PlayObject.m_UseItems[TPosition.U_NECKLACE] = HumItems[TPosition.U_HELMET];
            *PlayObject.m_UseItems[TPosition.U_HELMET] = HumItems[TPosition.U_NECKLACE];
            *PlayObject.m_UseItems[TPosition.U_ARMRINGL] = HumItems[TPosition.U_ARMRINGL];
            *PlayObject.m_UseItems[TPosition.U_ARMRINGR] = HumItems[TPosition.U_ARMRINGR];
            *PlayObject.m_UseItems[TPosition.U_RINGL] = HumItems[TPosition.U_RINGL];
            *PlayObject.m_UseItems[TPosition.U_RINGR] = HumItems[TPosition.U_RINGR];
            HumAddItems = (TUserItem*)HumanRcd->Data.HumAddItemsBuff;
            *PlayObject.m_UseItems[TPosition.U_BUJUK] = HumAddItems[TPosition.U_BUJUK];
            *PlayObject.m_UseItems[TPosition.U_BELT] = HumAddItems[TPosition.U_BELT];
            *PlayObject.m_UseItems[TPosition.U_BOOTS] = HumAddItems[TPosition.U_BOOTS];
            *PlayObject.m_UseItems[TPosition.U_CHARM] = HumAddItems[TPosition.U_CHARM];
            *PlayObject.m_UseItems[TPosition.U_ZHULI] = HumAddItems[TPosition.U_ZHULI];//斗笠
            TBatterPulse* pbtpl = (TBatterPulse*)HumanRcd->Data.HumPulses; // 人物经络
            PlayObject.m_HumPulses[0] = pbtpl[0];
            PlayObject.m_HumPulses[1] = pbtpl[1];
            PlayObject.m_HumPulses[2] = pbtpl[2];
            PlayObject.m_HumPulses[3] = pbtpl[3];
            ushort* pbtplorder = (ushort*)HumanRcd->Data.BatterMagicOrder;
            PlayObject.m_nBatterOrder[0] = pbtplorder[0];// 连击循序
            PlayObject.m_nBatterOrder[1] = pbtplorder[1];// 连击循序
            PlayObject.m_nBatterOrder[2] = pbtplorder[2];// 连击循序
            BagItems = (TUserItem*)HumanRcd->Data.BagItemsBuff;
            for (int I = 0; I <= 45; I++)
            {
                if (BagItems[I].wIndex > 0)
                {
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    for (int i = 0; i < 22; i++)
                    {
                        UserItem->btValue[i] = 0;
                    }
                    *UserItem = BagItems[I];
                    PlayObject.m_ItemList.Add((IntPtr)UserItem);
                }
            }
            HumMagics = (THumMagic*)HumanRcd->Data.HumMagicsBuff;
            for (int I = 0; I <= 29; I++)
            {
                MagicInfo = UserEngine.FindMagic(HumMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));//By John 修正此处没有申请内存导致程序异常
                    UserMagic->MagicInfo = *MagicInfo;
                    UserMagic->wMagIdx = HumMagics[I].wMagIdx;
                    UserMagic->btLevel = HumMagics[I].btLevel;
                    UserMagic->btKey = HumMagics[I].btKey;
                    UserMagic->nTranPoint = HumMagics[I].nTranPoint;
                    PlayObject.m_MagicList.Add((IntPtr)UserMagic);
                }
            }
            HumNGMagics = (THumMagic*)HumanRcd->Data.HumNGMagicsBuff;// 内功技能
            for (int I = 0; I <= 29; I++)
            {
                MagicInfo = UserEngine.FindMagic(HumNGMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));//By John 修正此处没有申请内存导致程序异常
                    UserMagic->MagicInfo = *MagicInfo;
                    UserMagic->wMagIdx = HumNGMagics[I].wMagIdx;
                    UserMagic->btLevel = HumNGMagics[I].btLevel;
                    UserMagic->btKey = HumNGMagics[I].btKey;
                    UserMagic->nTranPoint = HumNGMagics[I].nTranPoint;
                    PlayObject.m_MagicList.Add((IntPtr)UserMagic);
                }
            }
            HumBatterMagics = (THumMagic*)HumanRcd->Data.HumBatterMagicsBuff;//连击技能
            for (int I = 0; I <= 3; I++)
            {
                MagicInfo = UserEngine.FindMagic(HumBatterMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));//By John 修正此处没有申请内存导致程序异常
                    UserMagic->MagicInfo = *MagicInfo;
                    UserMagic->wMagIdx = HumBatterMagics[I].wMagIdx;
                    UserMagic->btLevel = HumBatterMagics[I].btLevel;
                    UserMagic->btKey = HumBatterMagics[I].btKey;
                    UserMagic->nTranPoint = HumBatterMagics[I].nTranPoint;
                    PlayObject.m_MagicList.Add((IntPtr)UserMagic);
                }
            }
            StorageItems = (TUserItem*)HumData->StorageItemsBuff;// 仓库物品
            for (int I = 0; I <= 45; I++)
            {
                if (StorageItems[I].wIndex > 0)
                {
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    for (int i = 0; i < 22; i++)
                    {
                        UserItem->btValue[i] = 0;
                    }
                    *UserItem = StorageItems[I];
                    PlayObject.m_StorageItemList.Add((IntPtr)UserItem);
                }
            }
            //PlayObject.m_BigStorageItemList = GameMsgDef.g_Storage.GetUserBigStorageList(PlayObject.m_sCharName);
            // 获取无限仓库数据
            // 读取记路标石记录的地图及XY值
            sFileName = GameConfig.sEnvirDir + "UserData\\HumRecallPoint.txt";
            if (File.Exists(sFileName))
            {
                IniFile = new IniFile(sFileName);
                try
                {
                    for (int I = 1; I <= 6; I++)
                    {
                        sY = IniFile.ReadString(PlayObject.m_sCharName, "记录" + (I).ToString(), "");
                        sY = HUtil32.GetValidStr3(sY, ref sMap, new string[] { "," });
                        if (sMap != "")
                        {
                            sY = HUtil32.GetValidStr3(sY, ref sX, new string[] { "," });
                            PlayObject.m_TagMapInfos[I].TagMapName = sMap;
                            PlayObject.m_TagMapInfos[I].TagX = HUtil32.Str_ToInt(sX, 0);
                            PlayObject.m_TagMapInfos[I].TagY = HUtil32.Str_ToInt(sY, 0);
                        }
                    }
                }
                finally
                {
                    Dispose(IniFile);
                }
            }
        }

        /// <summary>
        /// 取英雄数据
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="HumanRcd"></param>
        public unsafe void GetHeroData(TBaseObject BaseObject, THumDataInfo* HumanRcd)
        {
            THumData* HumData;
            TUserItem* HumItems;
            TUserItem* HumAddItems;
            TUserItem* BagItems;
            TUserItem* UserItem;
            THumMagic* HumMagics;
            THumMagic* HumNGMagics;
            THumMagic* HumBatterMagics;
            TUserMagic* UserMagic = null;
            TMagic* MagicInfo;
            THeroObject HeroObject;
            HeroObject = ((THeroObject)(BaseObject));
            HumData = &HumanRcd->Data;
            HeroObject.m_sCharName = HUtil32.SBytePtrToString(HumData->sChrName, 0, HumData->ChrNameLen);
            HeroObject.m_sMapName = HUtil32.SBytePtrToString(HumData->sCurMap, 0, HumData->CurMapLen);
            HeroObject.m_nCurrX = HumData->wCurX;
            HeroObject.m_nCurrY = HumData->wCurY;
            HeroObject.m_btDirection = HumData->btDir;
            HeroObject.m_btHair = HumData->btHair;
            HeroObject.m_btGender = HumData->btSex;
            HeroObject.m_btJob = HumData->btJob;
            HeroObject.m_nFirDragonPoint = HumData->nGold;// 金币数变量用来保存怒气值
            HeroObject.m_Abil.Level = HumData->Abil.Level;
            HeroObject.m_Abil.HP = HumData->Abil.HP;
            HeroObject.m_Abil.MP = HumData->Abil.MP;
            HeroObject.m_Abil.MaxHP = HumData->Abil.MaxHP;
            HeroObject.m_Abil.MaxMP = HumData->Abil.MaxMP;
            HeroObject.m_Abil.Exp = (uint)HumData->Abil.Exp;
            HeroObject.m_Abil.MaxExp = (uint)HumData->Abil.MaxExp;
            HeroObject.m_Abil.Weight = HumData->Abil.Weight;
            HeroObject.m_Abil.MaxWeight = HumData->Abil.MaxWeight;
            HeroObject.m_Abil.WearWeight = (ushort)HumData->Abil.WearWeight;
            HeroObject.m_Abil.MaxWearWeight = (ushort)HumData->Abil.MaxWearWeight;
            HeroObject.m_Abil.HandWeight = (ushort)HumData->Abil.HandWeight;
            HeroObject.m_Abil.MaxHandWeight = (ushort)HumData->Abil.MaxHandWeight;
            HeroObject.m_Abil.Alcohol = HumData->n_Reserved;// 酒量
            HeroObject.m_Abil.MaxAlcohol = HumData->n_Reserved1;// 酒量上限
            if (HeroObject.m_Abil.MaxAlcohol < GameConfig.nMaxAlcoholValue)
            {
                HeroObject.m_Abil.MaxAlcohol = GameConfig.nMaxAlcoholValue; // 酒量上限小限初始值时,则修改
            }
            HeroObject.m_Abil.WineDrinkValue = HumData->n_Reserved2;  // 醉酒度 
            HeroObject.n_DrinkWineQuality = HumData->btUnKnow2[2];// 饮酒时酒的品质
            HeroObject.n_DrinkWineAlcohol = HumData->UnKnow[4];// 饮酒时酒的度数 
            HeroObject.m_btMagBubbleDefenceLevel = HumData->UnKnow[5];// 魔法盾等级 
            HeroObject.m_Exp68 = (uint)HumData->Exp68;// 酒气护体当前经验 
            HeroObject.m_MaxExp68 = (uint)HumData->MaxExp68; // 酒气护体升级经验 
            HeroObject.m_boTrainingNG = HumData->UnKnow[6] != 0;// 是否学习过内功 
            if (HeroObject.m_boTrainingNG)
            {
                // 内功等级 
                HeroObject.m_NGLevel = HumData->UnKnow[7];
            }
            else
            {
                HeroObject.m_NGLevel = 0;
            }
            HeroObject.m_ExpSkill69 = (uint)HumData->nExpSkill69;// 内功当前经验
            HeroObject.m_Skill69NH = HumData->Abil.NG;// 内功当前内力值
            HeroObject.m_Skill69MaxNH = HumData->Abil.MaxNG;// 内力值上限
            HeroObject.m_Abil.MedicineValue = (ushort)HumData->nReserved1;// 当前药力值
            HeroObject.m_Abil.MaxMedicineValue = (ushort)HumData->nReserved2;// 药力值上限
            HeroObject.n_DrinkWineDrunk = HumData->boReserved3;// 人是否喝酒醉了
            HeroObject.dw_UseMedicineTime = (ushort)HumData->nReserved3;// 使用药酒时间,计算长时间没使用药酒
            HeroObject.n_MedicineLevel = HumData->n_Reserved3;// 药力值等级
            if (HeroObject.n_MedicineLevel <= 0)
            {
                HeroObject.n_MedicineLevel = 1;// 如果药力值等级为0,则设置为1
            }
            if (HeroObject.m_Abil.MaxMedicineValue <= 0)
            {
                // 药力值经验为0时,取设置的经验
                HeroObject.m_Abil.MaxMedicineValue = HeroObject.GetMedicineExp(HeroObject.n_MedicineLevel);
            }
            HeroObject.m_wStatusTimeArr = HUtil32.ushortPrtToushortArray(HumData->wStatusTimeArr, 13);
            HeroObject.m_sHomeMap = HUtil32.SBytePtrToString(HumData->sHomeMap, 0, HumData->HomeMapLen);
            HeroObject.m_nHomeX = HumData->wHomeX;
            HeroObject.m_nHomeY = HumData->wHomeY;
            HeroObject.m_BonusAbil = HumData->BonusAbil;
            HeroObject.m_nBonusPoint = HumData->nBonusPoint;
            HeroObject.m_btCreditPoint = HumData->btCreditPoint;
            HeroObject.m_btReLevel = HumData->btReLevel;
            HeroObject.m_nWinExp = (uint)HumData->n_WinExp;// 英雄累计经验值
            HeroObject.m_nLoyal = HumData->nLoyal;
            if (HeroObject.m_nLoyal > 10000)
            {
                HeroObject.m_nLoyal = 10000;
            }
            HeroObject.m_btLastOutStatus = HumData->btLastOutStatus; // 退出状态 1为死亡
            HeroObject.m_nPkPoint = HumData->nPKPOINT;
            HeroObject.btB2 = HumData->btF9;
            HeroObject.m_btAttatckMode = HumData->btAttatckMode;
            HeroObject.m_nIncHealth = HumData->btIncHealth;
            HeroObject.m_nIncSpell = HumData->btIncSpell;
            HeroObject.m_nIncHealing = HumData->btIncHealing;
            HeroObject.m_nFightZoneDieCount = HumData->btFightZoneDieCount;
            HeroObject.n_HeroTpye = HumData->btEF;// 英雄类型 0-白日门英雄 1-卧龙英雄
            HeroObject.m_dBodyLuck = HumData->dBodyLuck;
            HeroObject.m_QuestFlag = HUtil32.BytePtrToByteArray(HumData->QuestFlag, 127);
            HeroObject.m_btStatus = HumData->btStatus;// 英雄的状态
            if (HeroObject.m_Abil.Level <= 22)
            {
                HeroObject.m_btStatus = 1;// 22级之前,默认跟随
            }
            HumItems = (TUserItem*)HumanRcd->Data.HumItemsBuff;
            *HeroObject.m_UseItems[TPosition.U_DRESS] = HumItems[TPosition.U_DRESS];
            *HeroObject.m_UseItems[TPosition.U_WEAPON] = HumItems[TPosition.U_WEAPON];
            *HeroObject.m_UseItems[TPosition.U_RIGHTHAND] = HumItems[TPosition.U_RIGHTHAND];
            *HeroObject.m_UseItems[TPosition.U_NECKLACE] = HumItems[TPosition.U_HELMET];
            *HeroObject.m_UseItems[TPosition.U_HELMET] = HumItems[TPosition.U_NECKLACE];
            *HeroObject.m_UseItems[TPosition.U_ARMRINGL] = HumItems[TPosition.U_ARMRINGL];
            *HeroObject.m_UseItems[TPosition.U_ARMRINGR] = HumItems[TPosition.U_ARMRINGR];
            *HeroObject.m_UseItems[TPosition.U_RINGL] = HumItems[TPosition.U_RINGL];
            *HeroObject.m_UseItems[TPosition.U_RINGR] = HumItems[TPosition.U_RINGR];
            HumAddItems = (TUserItem*)HumanRcd->Data.HumAddItemsBuff;
            *HeroObject.m_UseItems[TPosition.U_BUJUK] = HumAddItems[TPosition.U_BUJUK];
            *HeroObject.m_UseItems[TPosition.U_BELT] = HumAddItems[TPosition.U_BELT];
            *HeroObject.m_UseItems[TPosition.U_BOOTS] = HumAddItems[TPosition.U_BOOTS];
            *HeroObject.m_UseItems[TPosition.U_CHARM] = HumAddItems[TPosition.U_CHARM];
            *HeroObject.m_UseItems[TPosition.U_ZHULI] = HumAddItems[TPosition.U_ZHULI]; // 斗笠
            TBatterPulse* tbatter = (TBatterPulse*)HumanRcd->Data.HumPulses; // 英雄经络
            HeroObject.m_HumPulses[0] = tbatter[0];
            HeroObject.m_HumPulses[1] = tbatter[1];
            HeroObject.m_HumPulses[2] = tbatter[2];
            HeroObject.m_HumPulses[3] = tbatter[3];
            ushort* batterorder = (ushort*)HumanRcd->Data.BatterMagicOrder;
            HeroObject.m_nBatterOrder[0] = batterorder[0]; // 连击循序
            HeroObject.m_nBatterOrder[1] = batterorder[1];// 连击循序
            HeroObject.m_nBatterOrder[2] = batterorder[2]; // 连击循序
            HeroObject.m_boisOpenPuls = HumanRcd->Data.m_boIsOpenPuls;// (英雄) 是否打开经络
            HeroObject.m_nPulseExp = (int)HumanRcd->Data.m_nPulseExp;// (英雄) 经络修炼经验
            BagItems = (TUserItem*)HumData->BagItemsBuff;
            for (int I = 0; I <= 45; I++)
            {
                if (BagItems[I].wIndex > 0)
                {
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    for (int i = 0; i < 22; i++)
                    {
                        UserItem->btValue[i] = 0;
                    }
                    *UserItem = BagItems[I];
                    HeroObject.m_ItemList.Add((IntPtr)UserItem);
                }
            }
            HumMagics = (THumMagic*)HumanRcd->Data.HumMagicsBuff;
            for (int I = 0; I <= 29; I++)
            {
                MagicInfo = UserEngine.FindHeroMagic(HumMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));
                    UserMagic->MagicInfo = *MagicInfo;
                    UserMagic->wMagIdx = HumMagics[I].wMagIdx;
                    UserMagic->btLevel = HumMagics[I].btLevel;
                    UserMagic->btKey = HumMagics[I].btKey;// 魔法快捷键(即魔法开关)
                    UserMagic->nTranPoint = HumMagics[I].nTranPoint;
                    HeroObject.m_MagicList.Add((IntPtr)UserMagic);
                }
            }
            HumNGMagics = (THumMagic*)HumanRcd->Data.HumNGMagicsBuff;//内功技能
            for (int I = 0; I <= 29; I++)
            {
                MagicInfo = UserEngine.FindMagic(HumNGMagics[I].wMagIdx);// 内功技能
                if (MagicInfo != null)
                {
                    UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));
                    UserMagic->MagicInfo = *MagicInfo;
                    UserMagic->wMagIdx = HumNGMagics[I].wMagIdx;
                    UserMagic->btLevel = HumNGMagics[I].btLevel;
                    UserMagic->btKey = HumNGMagics[I].btKey;
                    UserMagic->nTranPoint = HumNGMagics[I].nTranPoint;
                    HeroObject.m_MagicList.Add((IntPtr)UserMagic);
                }
            }
            HumBatterMagics = (THumMagic*)HumanRcd->Data.HumBatterMagicsBuff;// 连击技能
            for (int I = 0; I <= 3; I++)
            {
                MagicInfo = UserEngine.FindHeroMagic(HumBatterMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));
                    UserMagic->MagicInfo = *MagicInfo;
                    UserMagic->wMagIdx = HumBatterMagics[I].wMagIdx;
                    UserMagic->btLevel = HumBatterMagics[I].btLevel;
                    UserMagic->btKey = HumBatterMagics[I].btKey;
                    UserMagic->nTranPoint = HumBatterMagics[I].nTranPoint;
                    HeroObject.m_MagicList.Add((IntPtr)UserMagic);
                }
            }
            HeroObject.m_btMentHero = HumanRcd->Data.m_btFHeroType;
        }

        /// <summary>
        /// 取回城数据
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        private string GetHomeInfo(ref int nX, ref int nY)
        {
            string result;
            int I;
            lock (M2Share.g_StartPointList)
            {
                try
                {
                    if (M2Share.g_StartPointList.Count > 0)
                    {
                        if (M2Share.g_StartPointList.Count > GameConfig.nStartPointSize)
                        {
                            I = HUtil32.Random(GameConfig.nStartPointSize);
                        }
                        else
                        {
                            I = 0;
                        }
                        result = M2Share.GetStartPointInfo(I, ref nX, ref nY);
                    }
                    else
                    {
                        result = GameConfig.sHomeMap;
                        nX = GameConfig.nHomeX;
                        nX = GameConfig.nHomeY;
                    }
                }
                finally { }
            }
            return result;
        }

        private int GetRandHomeX(TPlayObject PlayObject)
        {
            return HUtil32.Random(3) + (PlayObject.m_nHomeX - 2);
        }

        private int GetRandHomeY(TPlayObject PlayObject)
        {
            return HUtil32.Random(3) + (PlayObject.m_nHomeY - 2);
        }

        private void LoadSwitchData(TSwitchDataInfo SwitchData, ref TPlayObject PlayObject)
        {
            int nCount;
            TSlaveInfo SlaveInfo;
            if (SwitchData.boC70)
            {
            }
            PlayObject.m_boBanShout = SwitchData.boBanShout;
            PlayObject.m_boHearWhisper = SwitchData.boHearWhisper;
            PlayObject.m_boBanGuildChat = SwitchData.boBanGuildChat;
            PlayObject.m_boBanGuildChat = SwitchData.boBanGuildChat;
            PlayObject.m_boAdminMode = SwitchData.boAdminMode;
            PlayObject.m_boObMode = SwitchData.boObMode;
            nCount = 0;
            while (true)
            {
                if (SwitchData.BlockWhisperArr[nCount] == "")
                {
                    break;
                }
                PlayObject.m_BlockWhisperList.Add(SwitchData.BlockWhisperArr[nCount]);
                nCount++;
                if (nCount >= SwitchData.BlockWhisperArr.GetUpperBound(0))
                {
                    break;
                }
            }
            nCount = 0;
            while (true)
            {
                if (SwitchData.SlaveArr[nCount].sSalveName == "")
                {
                    break;
                }
                SlaveInfo = new TSlaveInfo();
                SlaveInfo = SwitchData.SlaveArr[nCount];
                PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_10401, 0, Convert.ToInt32(SlaveInfo), 0, 0, "", 500);
                nCount++;
                if (nCount >= 5)
                {
                    break;
                }
            }
            nCount = 0;
            while (true)
            {
                PlayObject.m_wStatusArrValue[nCount] = SwitchData.StatusValue[nCount];
                PlayObject.m_dwStatusArrTimeOutTick[nCount] = SwitchData.StatusTimeOut[nCount];
                nCount++;
                if (nCount >= 6)
                {
                    break;
                }
            }
        }

        private void DelSwitchData(TSwitchDataInfo SwitchData)
        {
            int I;
            TSwitchDataInfo SwitchDataInfo;
            I = 0;
            while (true)
            {
                if (I >= m_ChangeServerList.Count)
                {
                    break;
                }
                if (m_ChangeServerList.Count <= 0)
                {
                    break;
                }
                SwitchDataInfo = m_ChangeServerList[I];
                if ((SwitchDataInfo != null) && (SwitchDataInfo == SwitchData))
                {
                    Dispose(SwitchDataInfo);
                    m_ChangeServerList.RemoveAt(I);
                    break;
                }
                I++;
            }
        }

        /// <summary>
        /// 查找魔法
        /// </summary>
        /// <param name="nMagIdx"></param>
        /// <returns></returns>
        public unsafe TMagic* FindMagic(int nMagIdx)
        {
            TMagic* result = null;
            TMagic* Magic;
            IList<IntPtr> MagicList;
            if (m_boStartLoadMagic && OldMagicList.Count > 0)
            {
                MagicList = OldMagicList;
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        for (int I = 0; I < MagicList.Count; I++)
                        {
                            Magic = (TMagic*)MagicList[I];
                            if ((Magic != null) && ((HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "")
                            || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "内功") || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "连击")))
                            {
                                if (Magic->wMagicId == nMagIdx)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        Magic = (TMagic*)m_MagicList[I];
                        if (Magic != null && HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == ""
                        || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "内功") || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "连击"))
                        {
                            if (Magic->wMagicId == nMagIdx)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 查找英雄魔法
        /// </summary>
        /// <param name="nMagIdx"></param>
        /// <returns></returns>
        public unsafe TMagic* FindHeroMagic(int nMagIdx)
        {
            TMagic* result = null;
            TMagic* Magic;
            IList<IntPtr> MagicList = null;
            if (m_boStartLoadMagic && (OldMagicList.Count > 0))
            {
                MagicList = OldMagicList;
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        for (int I = 0; I < MagicList.Count; I++)
                        {
                            Magic = (TMagic*)MagicList[I];
                            if ((Magic != null) && ((HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "")
                                   || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "英雄") || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "连击")))
                            {
                                if (Magic->wMagicId == nMagIdx)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        Magic = (TMagic*)m_MagicList[I];
                        if ((Magic != null) && ((HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "")
                               || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "英雄") || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "连击")))
                        {
                            if (Magic->wMagicId == nMagIdx)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 怪物初始化
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="sMonName"></param>
        private void MonInitialize(TBaseObject BaseObject, string sMonName)
        {
            TMonInfo Monster;
            byte nCode = 0;
            try
            {
                if (MonsterList.Count > 0)
                {
                    nCode = 1;
                    foreach (var item in MonsterList)
                    {
                        Monster = item;
                        nCode = 2;
                        if (Monster != null)
                        {
                            nCode = 3;
                            if (string.Compare(Monster.sName, sMonName, true) == 0 && (BaseObject != null))
                            {
                                nCode = 4;
                                BaseObject.m_btRaceServer = Monster.btRace;
                                BaseObject.m_btRaceImg = Monster.btRaceImg;
                                BaseObject.m_wAppr = Monster.wAppr;
                                BaseObject.m_Abil.Level = Monster.wLevel;
                                BaseObject.m_btLifeAttrib = Monster.btLifeAttrib;// 不死系
                                BaseObject.m_btCoolEye = Monster.wCoolEye;// 可视范围
                                BaseObject.m_dwFightExp = Monster.dwExp;
                                BaseObject.m_Abil.HP = Monster.wHP;
                                BaseObject.m_Abil.MaxHP = Monster.wHP;
                                nCode = 5;
                                BaseObject.m_btMonsterWeapon = (byte)Monster.wMP;
                                //BaseObject.m_btMonsterWeapon = HUtil32.LoByte(Monster.wMP);
                                BaseObject.m_Abil.MP = 0;
                                BaseObject.m_Abil.MaxMP = Monster.wMP;
                                nCode = 6;
                                BaseObject.m_Abil.AC = HUtil32.MakeLong(Monster.wAC, Monster.wAC);
                                BaseObject.m_Abil.MAC = HUtil32.MakeLong(Monster.wMAC, Monster.wMAC);
                                BaseObject.m_Abil.DC = HUtil32.MakeLong(Monster.wDC, Monster.wMaxDC);
                                BaseObject.m_Abil.MC = HUtil32.MakeLong(Monster.wMC, Monster.wMC);
                                BaseObject.m_Abil.SC = HUtil32.MakeLong(Monster.wSC, Monster.wSC);
                                nCode = 7;
                                BaseObject.m_btSpeedPoint = (byte)HUtil32._MIN(Byte.MaxValue, Monster.wSpeed);// 由于 m_btSpeedPoint为Byte，所以需判断
                                nCode = 8;
                                BaseObject.m_btHitPoint = (byte)HUtil32._MIN(Byte.MaxValue, Monster.wHitPoint);// 由于 m_btHitPoint为Byte，所以需判断
                                nCode = 9;
                                BaseObject.m_nWalkSpeed = Monster.wWalkSpeed;// 行走速度
                                BaseObject.m_nWalkStep = Monster.wWalkStep;
                                BaseObject.m_dwWalkWait = Monster.wWalkWait;
                                BaseObject.m_nNextHitTime = Monster.wAttackSpeed;// 攻击速度
                                nCode = 10;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.MonInitialize Name:" + sMonName + " Code:" + nCode);
            }
        }

        /// <summary>
        /// 打开门
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public bool OpenDoor(TEnvirnoment Envir, int nX, int nY)
        {
            bool result = false;
            TDoorInfo Door = Envir.GetDoor(nX, nY);
            if ((Door != null) && !Door.Status.boOpened && !Door.Status.bo01)
            {
                Door.Status.boOpened = true;
                Door.Status.dwOpenTick = HUtil32.GetTickCount();
                SendDoorStatus(Envir, nX, nY, Grobal2.RM_DOOROPEN, 0, nX, nY, 0, "");
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 关闭门
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="Door"></param>
        /// <returns></returns>
        public bool CloseDoor(TEnvirnoment Envir, TDoorInfo Door)
        {
            bool result = false;
            if ((Door != null) && (Door.Status.boOpened))
            {
                Door.Status.boOpened = false;
                SendDoorStatus(Envir, Door.nX, Door.nY, Grobal2.RM_DOORCLOSE, 0, Door.nX, Door.nY, 0, "");
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 发送门的状态
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="wIdent"></param>
        /// <param name="wX"></param>
        /// <param name="nDoorX"></param>
        /// <param name="nDoorY"></param>
        /// <param name="nA"></param>
        /// <param name="sStr"></param>
        public void SendDoorStatus(TEnvirnoment Envir, int nX, int nY, ushort wIdent, ushort wX, int nDoorX, int nDoorY, int nA, string sStr)
        {
            int n10;
            int n14;
            int n1C;
            int n20;
            int n24;
            int n28;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            n1C = nX - 12;
            n24 = nX + 12;
            n20 = nY - 12;
            n28 = nY + 12;
            if (n1C < 0)
            {
                n1C = 0;
            }
            if (n20 < 0)
            {
                n20 = 0;
            }
            if (Envir != null)
            {
                for (n10 = n1C; n10 <= n24; n10++)
                {
                    for (n14 = n20; n14 <= n28; n14++)
                    {
                        if (Envir.CanGetMapCellInfo(n10, n14, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                        {
                            if (MapCellInfo.ObjList.Count > 0)
                            {
                                for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                                {
                                    OSObject = MapCellInfo.ObjList[I];
                                    if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                    {
                                        BaseObject = (TBaseObject)OSObject.CellObj;
                                        if ((BaseObject != null) && (!BaseObject.m_boGhost) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                        {
                                            BaseObject.SendMsg(BaseObject, wIdent, wX, nDoorX, nDoorY, nA, sStr);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 门处理进程
        /// </summary>
        private void ProcessMapDoor()
        {
            TEnvirnoment Envir;
            TDoorInfo Door;
            if (M2Share.g_MapManager.m_MapList.Count > 0)
            {
                foreach (var item in M2Share.g_MapManager.m_MapList)
                {
                    Envir = item;
                    if (Envir != null)
                    {
                        if (Envir.m_DoorList.Count > 0)
                        {
                            for (int II = 0; II < Envir.m_DoorList.Count; II++)
                            {
                                Door = Envir.m_DoorList[II];
                                if (Door != null)
                                {
                                    if (Door.Status.boOpened)
                                    {
                                        if ((HUtil32.GetTickCount() - Door.Status.dwOpenTick) > 5000)// 5 * 1000
                                        {
                                            CloseDoor(Envir, Door);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 闪电  地上冒岩浆
        /// </summary>
        private void ProcessEffects()
        {
            int X;
            int Y;
            TEnvirnoment Envir;
            int Amount;
            if (m_boProcessEffects)
            {
                return;
            }
            m_boProcessEffects = true;
            try
            {
                try
                {
                    if (EffectList.Count > 0)
                    {
                        foreach (var item in EffectList)
                        {
                            Envir = item;
                            if (Envir != null)
                            {
                                if ((Envir.nThunder != 0) || (Envir.nLava != 0))// 闪电,岩浆效果
                                {
                                    Amount = GetMapHuman(Envir.sMapName);// 获取地图人物数
                                    if (Amount == 0) { continue; }
                                    Amount = (Envir.m_nWidth * Envir.m_nHeight) / 3200;
                                    for (int II = 0; II <= Amount; II++)
                                    {
                                        X = HUtil32.Random(Envir.m_nWidth);
                                        Y = HUtil32.Random(Envir.m_nHeight);
                                        if (Envir.CanWalk(X, Y, true))
                                        {
                                            EffectTarget(X, Y, Envir);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TUserEngine.ProcessEffects");
                }
            }
            finally
            {
                m_boProcessEffects = false;
            }
        }

        private void EffectTarget(int x, int y, TEnvirnoment Envir)
        {
            TBaseObject Target;
            TBaseObject BaseObject;
            int Dmg;
            int magpwr;
            int i;
            TBaseObject freshbaseobject;
            byte nCode;
            Dmg = 0;
            nCode = 0;
            try
            {
                Target = FindNearbyTarget(x, y, Envir, m_TargetList);// 查找目标
                nCode = 22;
                if ((Target == null))
                {
                    return;
                }
                nCode = 1;
                if (HUtil32.Random(3) == 0)
                {
                    x = Target.m_nCurrX;
                    y = Target.m_nCurrY;
                }
                else
                {
                    Envir.GetNextPosition(Target.m_nCurrX, Target.m_nCurrY, HUtil32.Random(8), HUtil32.Random(4) + 1, ref x, ref y);// 增加
                }
                nCode = 2;
                m_TargetList.Clear();
                if ((Envir.nThunder != 0) && (Envir.nLava != 0))
                {
                    switch (HUtil32.Random(2))
                    {
                        case 0:
                            nCode = 3;
                            if (Envir.nThunder != 0)
                            {
                                nCode = 4;
                                Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 10, "");
                                nCode = 5;
                                Dmg = Envir.nThunder;
                                nCode = 6;
                                Envir.GeTBaseObjects(x, y, true, m_TargetList);
                            }
                            break;
                        case 1:
                            if (Envir.nLava != 0)
                            {
                                nCode = 7;
                                Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 11, "");
                                nCode = 8;
                                Dmg = Envir.nLava;
                                nCode = 9;
                                Envir.GetRangeBaseObject(x, y, 1, true, m_TargetList);
                            }
                            break;
                    }
                }
                else
                {
                    if (Envir.nThunder != 0)
                    {
                        nCode = 10;
                        Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 10, "");
                        nCode = 11;
                        Dmg = Envir.nThunder;
                        nCode = 12;
                        Envir.GeTBaseObjects(x, y, true, m_TargetList);
                    }
                    if (Envir.nLava != 0)
                    {
                        nCode = 13;
                        Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 11, "");
                        nCode = 14;
                        Dmg = Envir.nLava;
                        nCode = 15;
                        Envir.GetRangeBaseObject(x, y, 1, true, m_TargetList);
                    }
                }
                freshbaseobject = new TBaseObject();
                if ((m_TargetList.Count > 0))
                {
                    for (i = m_TargetList.Count - 1; i >= 0; i--)
                    {
                        nCode = 17;
                        BaseObject = ((TBaseObject)(m_TargetList[i]));
                        if ((BaseObject != null))
                        {
                            if (((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_Master != null)) && (BaseObject.m_PEnvir == Envir))
                            {
                                nCode = 18;
                                magpwr = (Dmg - (Dmg / 3)) + HUtil32.Random(Dmg / 3); //损害值
                                nCode = 19;
                                BaseObject.SendDelayMsg(freshbaseobject, Grobal2.RM_MAGSTRUCK, 0, magpwr, 1, 0, "", 600);
                            }
                            m_TargetList.RemoveAt(i);
                        }
                    }
                }
                nCode = 20;
                Dispose(freshbaseobject);
                nCode = 21;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.EffectTarget Code:" + (nCode).ToString());
            }
        }

        private TBaseObject FindNearbyTarget(int x, int y, TEnvirnoment Envir, IList<TPlayObject> xTargetList)
        {
            TBaseObject result = null;
            TBaseObject BaseObject;
            int nRage = 11;
            try
            {
                xTargetList.Clear();
                Envir.GetRangeBaseObject(x, y, nRage, true, xTargetList);  // 不包括死的对像
                if (xTargetList.Count > 0)
                {
                    for (int i = 0; i < xTargetList.Count; i++)
                    {
                        BaseObject = ((TBaseObject)(xTargetList[i]));
                        if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_Master != null))
                        {
                            result = BaseObject;
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 处理地图事件
        /// </summary>
        private void ProcessEvents()
        {
            TMagicEvent MagicEvent;
            TBaseObject BaseObject;
            for (int I = m_MagicEventList.Count - 1; I >= 0; I--)
            {
                if (m_MagicEventList.Count <= 0)
                {
                    break;
                }
                MagicEvent = m_MagicEventList[I];
                if (MagicEvent != null)
                {
                    if (MagicEvent.BaseObjectList != null)
                    {
                        for (int II = MagicEvent.BaseObjectList.Count - 1; II >= 0; II--)
                        {
                            if (MagicEvent.BaseObjectList.Count <= 0)
                            {
                                break;
                            }
                            BaseObject = MagicEvent.BaseObjectList[II];
                            if (BaseObject != null)
                            {
                                if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (!BaseObject.m_boHolySeize))
                                {
                                    MagicEvent.BaseObjectList.RemoveAt(II);
                                }
                            }
                        }
                        if ((MagicEvent.BaseObjectList.Count <= 0) || ((HUtil32.GetTickCount() - MagicEvent.dwStartTick) > MagicEvent.dwTime) ||
                            ((HUtil32.GetTickCount() - MagicEvent.dwStartTick) > 180000))
                        {
                            Dispose(MagicEvent.BaseObjectList);
                            MagicEvent.BaseObjectList = null;
                            int III = 0;
                            while (true)
                            {
                                if (MagicEvent.Events[III] != null)
                                {
                                    ((TEvent)(MagicEvent.Events[III])).Close();
                                }
                                III++;
                                if (III >= 8)
                                {
                                    break;
                                }
                            }
                            Dispose(MagicEvent);
                            m_MagicEventList.RemoveAt(I);
                        }
                    }
                }
            }
        }

        public unsafe bool AddMagic(TMagic* Magic)
        {
            bool result = false;
            TMagic* UserMagic = (TMagic*)Marshal.AllocHGlobal(sizeof(TMagic));//By Dr.Kevin修正此处没有申请内存，导致报错
            UserMagic->wMagicId = Magic->wMagicId;
            *UserMagic->sMagicName = *Magic->sMagicName;
            UserMagic->btEffectType = Magic->btEffectType;
            UserMagic->btEffect = Magic->btEffect;
            UserMagic->wSpell = Magic->wSpell;
            UserMagic->wPower = Magic->wPower;
            *UserMagic->TrainLevel = *Magic->TrainLevel;
            *UserMagic->MaxTrain = *Magic->MaxTrain;
            UserMagic->btTrainLv = Magic->btTrainLv;
            UserMagic->btJob = Magic->btJob;
            UserMagic->dwDelayTime = Magic->dwDelayTime;
            UserMagic->btDefSpell = Magic->btDefSpell;
            UserMagic->btDefPower = Magic->btDefPower;
            UserMagic->wMaxPower = Magic->wMaxPower;
            UserMagic->btDefMaxPower = Magic->btDefMaxPower;
            *UserMagic->sDescr = *Magic->sDescr;
            m_MagicList.Add((IntPtr)UserMagic);
            result = true;
            return result;
        }

        public unsafe bool DelMagic(ushort wMagicId)
        {
            bool result = false;
            TMagic* Magic;
            for (int I = m_MagicList.Count - 1; I >= 0; I--)
            {
                if (m_MagicList.Count <= 0)
                {
                    break;
                }
                Magic = (TMagic*)m_MagicList[I];
                if (Magic != null)
                {
                    if (Magic->wMagicId == wMagicId)
                    {
                        Marshal.FreeHGlobal((IntPtr)Magic);
                        m_MagicList.RemoveAt(I);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public unsafe TMagic* FindHeroMagic(string sMagicName)
        {
            TMagic* result = null;
            TMagic* Magic;
            IList<IntPtr> MagicList;
            if (m_boStartLoadMagic && (OldMagicList.Count > 0))
            {
                MagicList = OldMagicList;
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        for (int I = 0; I < MagicList.Count; I++)
                        {
                            Magic = (TMagic*)MagicList[I];
                            if ((Magic != null) && ((HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "英雄")
                                || ((HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "内功")
                                || ((HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "连击")))))
                            {
                                if (string.Compare(HUtil32.SBytePtrToString(Magic->sMagicName, Magic->MagicNameLen), sMagicName, true) == 0)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        Magic = (TMagic*)m_MagicList[I];
                        if ((Magic != null) && ((HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "英雄")
                            || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "内功")
                            || (HUtil32.SBytePtrToString(Magic->sDescr, Magic->DescrLen) == "连击")))
                        {
                            if (string.Compare(HUtil32.SBytePtrToString(Magic->sMagicName, Magic->MagicNameLen), sMagicName, true) == 0)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 根据技能名称取技能信息
        /// </summary>
        /// <param name="sMagicName"></param>
        /// <returns></returns>
        public unsafe TMagic* FindMagic(string sMagicName)
        {
            TMagic* result = null;
            TMagic* Magic;
            IList<IntPtr> MagicList;
            string MagicName,MagicDescr = string.Empty;
            if (m_boStartLoadMagic && (OldMagicList.Count > 0))
            {
                MagicList = OldMagicList;
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        for (int I = 0; I < MagicList.Count; I++)
                        {
                            Magic = (TMagic*)MagicList[I];
                            MagicName = HUtil32.SBytePtrToString(Magic->sMagicName, Magic->MagicNameLen);
                            MagicDescr = HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen);//取技能描述信息
                            if ((Magic != null) && ((MagicDescr == "") || (MagicDescr == "内功") || (MagicDescr == "连击")))
                            {
                                if (string.Compare(MagicName, sMagicName, true) == 0)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        Magic = (TMagic*)m_MagicList[I];
                        MagicName = HUtil32.SBytePtrToString(Magic->sMagicName, Magic->MagicNameLen);
                        MagicDescr = HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen);//取技能描述信息
                        if ((Magic != null) && ((MagicDescr == "") || (MagicDescr == "内功") || (MagicDescr == "连击")))
                        {
                            if (string.Compare(MagicName, sMagicName, true) == 0)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 取地图范围内有怪
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRange"></param>
        /// <param name="List"></param>
        /// <returns></returns>
        public int GetMapRangeMonster(TEnvirnoment Envir, int nX, int nY, int nRange, List<TBaseObject> List)
        {
            int result = 0;
            TMonGenInfo MonGen;
            TBaseObject BaseObject;
            if (Envir == null)
            {
                return result;
            }
            if (m_MonGenList.Count > 0)
            {
                for (int I = 0; I < m_MonGenList.Count; I++)
                {
                    MonGen = m_MonGenList[I];
                    if ((MonGen.Envir != null) && (MonGen.Envir != Envir))
                    {
                        continue;
                    }
                    if (MonGen.CertList.Count > 0)
                    {
                        for (int II = 0; II < MonGen.CertList.Count; II++)
                        {
                            BaseObject = ((TBaseObject)(MonGen.CertList[II]));
                            if (BaseObject != null)
                            {
                                if (!BaseObject.m_boDeath && !BaseObject.m_boGhost && (BaseObject.m_PEnvir == Envir) && (Math.Abs(BaseObject.m_nCurrX - nX) <= nRange)
                                    && (Math.Abs(BaseObject.m_nCurrY - nY) <= nRange))
                                {
                                    if (List != null)
                                    {
                                        List.Add(BaseObject);
                                    }
                                    result++;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 增加交易NPC
        /// </summary>
        /// <param name="Merchant"></param>
        public void AddMerchant(TMerchant Merchant)
        {
            HUtil32.EnterCriticalSection(UserEngine.m_MerchantList);
            {
                try
                {
                    UserEngine.m_MerchantList.Add(Merchant);
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(UserEngine.m_MerchantList);
                }
            }
        }

        /// <summary>
        /// 取交易NPC列表
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRange"></param>
        /// <param name="TmpList"></param>
        /// <returns></returns>
        public int GetMerchantList(TEnvirnoment Envir, int nX, int nY, int nRange, List<TMerchant> TmpList)
        {
            int result;
            TMerchant Merchant;
            lock (m_MerchantList)
            {
                try
                {
                    if (m_MerchantList.Count > 0)
                    {
                        foreach (var item in m_MerchantList)
                        {
                            Merchant = item;
                            if (Merchant != null)
                            {
                                if ((Merchant.m_PEnvir == Envir) && (Math.Abs(Merchant.m_nCurrX - nX) <= nRange) && (Math.Abs(Merchant.m_nCurrY - nY) <= nRange))
                                {
                                    TmpList.Add(Merchant);
                                }
                            }
                        }
                    }
                }
                finally
                {
                }
            }
            result = TmpList.Count;
            return result;
        }

        /// <summary>
        /// 取NPC列表
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRange"></param>
        /// <param name="TmpList"></param>
        /// <returns></returns>
        public int GetNpcList(TEnvirnoment Envir, int nX, int nY, int nRange, List<TNormNpc> TmpList)
        {
            int result;
            TNormNpc NPC;
            if (QuestNPCList.Count > 0)
            {
                foreach (var item in QuestNPCList)
                {
                    NPC = item;
                    if (NPC != null)
                    {
                        if ((NPC.m_PEnvir == Envir) && (Math.Abs(NPC.m_nCurrX - nX) <= nRange) && (Math.Abs(NPC.m_nCurrY - nY) <= nRange))
                        {
                            TmpList.Add(NPC);
                        }
                    }
                }
            }
            result = TmpList.Count;
            return result;
        }

        // 重新加载NPC列表
        public void ReloadMerchantList()
        {
            TMerchant Merchant;
            lock (m_MerchantList)
            {
                //m_MerchantList.__Lock();
                try
                {
                    if (m_MerchantList.Count > 0)
                    {
                        foreach (var item in m_MerchantList)
                        {
                            Merchant = item;
                            if (Merchant != null)
                            {
                                if (!Merchant.m_boGhost)
                                {
                                    Merchant.ClearScript();
                                    Merchant.LoadNpcScript();
                                }
                            }
                        }
                    }
                }
                finally
                {
                    //m_MerchantList.UnLock();
                }
            }
        }

        // 重读NPC脚本
        public void ReloadNpcList()
        {
            TNormNpc NPC;
            if (QuestNPCList.Count > 0)
            {
                foreach (var item in QuestNPCList)
                {
                    NPC = item;
                    if (NPC != null)
                    {
                        NPC.ClearScript();
                        NPC.LoadNpcScript();
                    }
                }
            }
        }

        /// <summary>
        /// 取地图怪物数量
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="List"></param>
        /// <returns></returns>
        public int GetMapMonster(TEnvirnoment Envir, List<TBaseObject> List)
        {
            int result = 0;
            TMonGenInfo MonGen;
            TBaseObject BaseObject;
            if (Envir == null)
            {
                return result;
            }
            if (m_MonGenList.Count > 0)
            {
                for (int i = 0; i < m_MonGenList.Count; i++)
                {
                    MonGen = m_MonGenList[i];
                    if (MonGen == null)
                    {
                        continue;
                    }
                    if (MonGen.CertList.Count > 0)
                    {
                        for (int j = 0; j < MonGen.CertList.Count; j++)
                        {
                            BaseObject = ((TBaseObject)(MonGen.CertList[j]));
                            if (BaseObject != null)
                            {
                                if ((!BaseObject.m_boDeath) && (!BaseObject.m_boGhost) && (BaseObject.m_PEnvir == Envir))
                                {
                                    if (List != null)
                                    {
                                        List.Add(BaseObject);
                                    }
                                    result++;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 检查地图指定坐标指定名称怪物数量
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRange"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int GetMapMonsterCount(TEnvirnoment Envir, int nX, int nY, int nRange, string Name)
        {
            int result;
            int nC;
            TMonGenInfo MonGen;
            TBaseObject BaseObject;
            result = 0;
            nC = nRange;
            if (Envir == null)
            {
                return result;
            }
            if (m_MonGenList.Count > 0)
            {
                for (int I = 0; I < m_MonGenList.Count; I++)
                {
                    MonGen = m_MonGenList[I];
                    if (MonGen == null)
                    {
                        continue;
                    }
                    if (MonGen.CertList.Count > 0)
                    {
                        for (int II = 0; II < MonGen.CertList.Count; II++)
                        {
                            BaseObject = ((TBaseObject)(MonGen.CertList[II]));
                            if (BaseObject != null)
                            {
                                if (!BaseObject.m_boDeath && !BaseObject.m_boGhost && (BaseObject.m_PEnvir == Envir) && ((BaseObject.m_sCharName).ToLower().CompareTo((Name).ToLower()) == 0))
                                {
                                    if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nC) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nC))
                                    {
                                        result++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 取有人才刷怪地图,刷怪索引
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="Idx"></param>
        /// <returns></returns>
        public int GetMapMonGenIdx(TEnvirnoment Envir, ref int Idx)
        {
            int result = 0;
            TMonGenInfo MonGen;
            try
            {
                if (Envir == null)
                {
                    return result;
                }
                if (Envir.MonCount == 0)
                {
                    if (m_MonGenList.Count > 0)
                    {
                        for (int I = 0; I < m_MonGenList.Count; I++)
                        {
                            MonGen = m_MonGenList[I];
                            if (MonGen == null)
                            {
                                continue;
                            }
                            if ((MonGen.Envir == Envir) && (MonGen.nCurrMonGen != 0))
                            {
                                if (result == 0)
                                {
                                    result = 1;
                                    Idx = MonGen.nCurrMonGen;
                                }
                                MonGen.dwStartTick = 0;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        public void HumanExpire(string sAccount)
        {
            TPlayObject PlayObject;
            if (!GameConfig.boKickExpireHuman)
            {
                return;
            }
            if (m_PlayObjectList.Count > 0)
            {
                PlayObject = m_PlayObjectList.Find(P =>
                {
                    return P.m_sUserID == sAccount;
                });
                if (PlayObject != null)
                {
                    if (string.Compare(PlayObject.m_sUserID, sAccount, true) == 0)
                    {
                        PlayObject.m_boExpire = true;
                    }
                }
                #region 以前代码
                //for (int I = 0; I < m_PlayObjectList.Count; I++)
                //{
                //    PlayObject = m_PlayObjectList[I];
                //    if (PlayObject != null)
                //    {
                //        if ((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0)
                //        {
                //            PlayObject.m_boExpire = true;
                //            break;
                //        }
                //    }
                //}
                #endregion
            }
        }

        /// <summary>
        /// 取地图人数
        /// </summary>
        /// <param name="sMapName"></param>
        /// <returns></returns>
        public int GetMapHuman(string sMapName)
        {
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMapName);
            if (Envir == null)
            {
                return 0;
            }
            return m_PlayObjectList.FindAll(PlayObject =>
            {
                return !PlayObject.m_boDeath && !PlayObject.m_boGhost && PlayObject.m_PEnvir == Envir;
            }).Count();
        }

        /// <summary>
        /// 取地图范围内的人物
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nRageX"></param>
        /// <param name="nRageY"></param>
        /// <param name="nRage"></param>
        /// <param name="List"></param>
        /// <returns></returns>
        public int GetMapRageHuman(TEnvirnoment Envir, int nRageX, int nRageY, int nRage, List<TPlayObject> List)
        {
            int result = 0;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                foreach (var item in m_PlayObjectList)
                {
                    PlayObject = item;
                    if (PlayObject != null)
                    {
                        if (!PlayObject.m_boDeath && !PlayObject.m_boGhost && (PlayObject.m_PEnvir == Envir) && (Math.Abs(PlayObject.m_nCurrX - nRageX) <= nRage)
                            && (Math.Abs(PlayObject.m_nCurrY - nRageY) <= nRage))
                        {
                            List.Add(PlayObject);
                            result++;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取物品编号
        /// </summary>
        /// <param name="sItemName"></param>
        /// <returns></returns>
        public unsafe int GetStdItemIdx(string sItemName)
        {
            int result = -1;
            TStdItem* StdItem;
            if (sItemName == "")
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                for (int I = 0; I < StdItemList.Count; I++)
                {
                    StdItem = (TStdItem*)StdItemList[I];
                    if (StdItem != null)
                    {
                        if (string.Compare(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), sItemName, true) == 0)
                        {
                            result = I + 1;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // 加强版文件信息发送函数(供NPC命令-SendMsg使用)
        // ==========================================
        // 向每个人物发送消息
        // 线程安全
        // ==========================================
        public void SendBroadCastMsgExt(string sMsg, TMsgType MsgType)
        {
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                m_PlayObjectList.ForEach(c => { if (!c.m_boGhost) { c.SysMsg(sMsg, TMsgColor.c_Red, MsgType); } });
                //foreach (var PlayObject in m_PlayObjectList)
                //{
                //    if (PlayObject != null)
                //    {
                //        if (!PlayObject.m_boGhost)
                //        {
                //            PlayObject.SysMsg(sMsg, TMsgColor.c_Red, MsgType);
                //        }
                //    }
                //}
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        public void SendBroadCastMsg(string sMsg, TMsgType MsgType)
        {
            foreach (var PlayObject in m_PlayObjectList)
            {
                if (PlayObject != null)
                {
                    if (!PlayObject.m_boGhost)
                    {
                        PlayObject.SysMsg(sMsg, TMsgColor.c_Red, MsgType);
                    }
                }
            }
        }

        // 加强版文件信息发送函数(供NPC命令-SendMsg使用)
        public void SendBroadCastMsg1(string sMsg, TMsgType MsgType, byte FColor, byte BColor)
        {
            foreach (var PlayObject in m_PlayObjectList)
            {
                if (PlayObject != null)
                {
                    if (!PlayObject.m_boGhost)
                    {
                        PlayObject.SysMsg1(sMsg, TMsgColor.c_Red, MsgType, FColor, BColor);
                    }
                }
            }
        }

        public void sub_4AE514(TGoldChangeInfo GoldChangeInfo)
        {
            TGoldChangeInfo GoldChange;
            if (GoldChangeInfo != null)
            {
                GoldChange = new TGoldChangeInfo();
                GoldChange = GoldChangeInfo;
                HUtil32.EnterCriticalSection(m_LoadPlaySection);
                try
                {
                    m_ChangeHumanDBGoldList.Add(GoldChange);
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(m_LoadPlaySection);
                }
            }
        }

        /// <summary>
        /// 清除怪物说话
        /// </summary>
        public void ClearMonSayMsg()
        {
            TMonGenInfo MonGen;
            TBaseObject MonBaseObject;
            if (m_MonGenList.Count > 0)
            {
                for (int I = 0; I < m_MonGenList.Count; I++)
                {
                    MonGen = m_MonGenList[I];
                    if ((MonGen != null) && (MonGen.CertList != null))
                    {
                        if (MonGen.CertList.Count > 0)
                        {
                            for (int II = 0; II < MonGen.CertList.Count; II++)
                            {
                                MonBaseObject = MonGen.CertList[II];
                                if (MonBaseObject != null)
                                {
                                    MonBaseObject.m_SayMsgList = null;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 引擎所有主要过程,CPU 内存的占用大部分这过程
        /// </summary>
        public void PrcocessData()
        {
            uint dwUsrTimeTick;
            string sMsg;
            byte nCode = 0;
            if (m_boPrcocessData)
            {
                return;
            }
            m_boPrcocessData = true;
            try
            {
                try
                {
                    dwUsrTimeTick = HUtil32.GetTickCount();
                    ProcessHumans();
                    nCode = 1;
                    if ((HUtil32.GetTickCount() - dwGetOrderTick > 150000) && !bo_ReadPlayLeveList) // 1000 * 60 * 2 每2.5分钟读取一次排行文件
                    {
                        dwGetOrderTick = HUtil32.GetTickCount();
                        nCode = 2;
                        GetPlayObjectLevelList(); // 获取人物等级排序
                    }
                    nCode = 3;
                    if (GameConfig.boSendOnlineCount && (HUtil32.GetTickCount() - M2Share.g_dwSendOnlineTick > GameConfig.dwSendOnlineTime))
                    {
                        M2Share.g_dwSendOnlineTick = HUtil32.GetTickCount();
                        nCode = 4;
                        sMsg = string.Format(GameMsgDef.g_sSendOnlineCountMsg, OnlinePlayObject * (GameConfig.nSendOnlineCountRate / 10));
                        SendBroadCastMsg(sMsg, TMsgType.t_System); //发送当前游戏在线人数到客户端
                    }
                    nCode = 5;
                    ProcessMonsters();
                    nCode = 6;
                    ProcessMerchants();
                    nCode = 7;
                    ProcessNpcs();
                    if ((HUtil32.GetTickCount() - dwProcessMissionsTime) > 1000)
                    {
                        dwProcessMissionsTime = HUtil32.GetTickCount();
                        nCode = 8;
                        ProcessEvents();
                        nCode = 9;
                        ProcessEffects();//闪电(雷炎洞魔法效果)
                    }
                    nCode = 10;
                    if ((HUtil32.GetTickCount() - dwProcessMapDoorTick) > 500)
                    {
                        dwProcessMapDoorTick = HUtil32.GetTickCount();
                        nCode = 11;
                        ProcessMapDoor();
                    }
                    nCode = 12;
                    M2Share.g_nUsrTimeMin = HUtil32.GetTickCount() - dwUsrTimeTick;
                    if (M2Share.g_nUsrTimeMax < M2Share.g_nUsrTimeMin)
                    {
                        M2Share.g_nUsrTimeMax = M2Share.g_nUsrTimeMin;
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessData Code:" + nCode);
                }
            }
            finally
            {
                m_boPrcocessData = false;
            }
        }

        private bool MapRageHuman(string sMapName, int nMapX, int nMapY, int nRage)
        {
            bool result = false;
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMapName);
            if (Envir != null)
            {
                for (int nX = nMapX - nRage; nX <= nMapX + nRage; nX++)
                {
                    for (int nY = nMapY - nRage; nY <= nMapY + nRage; nY++)
                    {
                        if (Envir.GetXYHuman(nMapX, nMapY))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        public void SendQuestMsg(string sQuestName)
        {
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                for (int I = 0; I < m_PlayObjectList.Count; I++)
                {
                    PlayObject = m_PlayObjectList[I];
                    if (PlayObject != null)
                    {
                        if (!PlayObject.m_boDeath && !PlayObject.m_boGhost)
                        {
                            M2Share.g_ManageNPC.GotoLable(PlayObject, sQuestName, false);
                        }
                    }
                }
            }
        }

        public virtual void ClearItemList()
        {
            int I;
            I = 0;
            //while (true)
            //{
            //StdItemList.Exchange(HUtil32.Random(StdItemList.Count), StdItemList.Count - 1);
            //I++;
            //if (I >= StdItemList.Count)
            //{
            //    break;
            //}
            //}
            ClearMerchantData(); // 清空交易NPC临时数据
        }

        public void SwitchMagicList()
        {
            if (m_MagicList.Count > 0)
            {
                //OldMagicList.Add(m_MagicList);
                m_MagicList = new List<IntPtr>();
            }
            m_boStartLoadMagic = true;
        }

        // 清空交易NPC数据
        public void ClearMerchantData()
        {
            TMerchant Merchant;
            lock (m_MerchantList)
            {
                try
                {
                    if (m_MerchantList.Count > 0)
                    {
                        for (int I = 0; I < m_MerchantList.Count; I++)
                        {
                            Merchant = m_MerchantList[I];
                            if (Merchant != null)
                            {
                                Merchant.ClearData();
                            }
                        }
                    }
                }
                finally
                {

                }
            }
        }

        /// <summary>
        /// 取商铺物品
        /// </summary>
        /// <param name="sItemName"></param>
        /// <returns></returns>
        public unsafe TStdItem* GetShopStdItem(string sItemName)
        {
            TStdItem* result = null;
            TShopInfo* ShopInfo;
            try
            {
                if (sItemName == "")
                {
                    return result;
                }
                if (M2Share.g_ShopItemList.Count > 0)
                {
                    for (int I = 0; I < M2Share.g_ShopItemList.Count; I++)
                    {
                        ShopInfo = (TShopInfo*)M2Share.g_ShopItemList[I];
                        if (string.Compare(HUtil32.SBytePtrToString(ShopInfo->StdItem->Name, ShopInfo->StdItem->NameLen), sItemName, true) == 0)
                        {
                            result = ShopInfo->StdItem;
                            break;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TUserEngine.GetShopStdItem");
            }
            return result;
        }

        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            if (obj != null)
            {
                GC.KeepAlive(obj);
                GC.ReRegisterForFinalize(obj);
            }
        }
    }
}