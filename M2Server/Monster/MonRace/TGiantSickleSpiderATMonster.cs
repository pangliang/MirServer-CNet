using GameFramework;
using M2Server.Monster;
using System.Collections.Generic;
using System.IO;

namespace M2Server.Mon
{
    /// <summary>
    /// 巨镰蜘蛛
    /// </summary>
    public class TGiantSickleSpiderATMonster : TATMonster
    {
        /// <summary>
        /// 是否可探索
        /// </summary>
        public bool m_boExploration = false;
        /// <summary>
        /// 探索收费模式(0金币，1元宝，2金刚石，3灵符)
        /// </summary>
        public byte m_nButchChargeClass = 0;
        /// <summary>
        /// 探索每次收费点数
        /// </summary>
        public int m_nButchChargeCount = 0;
        /// <summary>
        /// 是否进入触发
        /// </summary>
        public bool boIntoTrigger = false;
        /// <summary>
        /// 可探索物品列表
        /// </summary>
        public List<TMonItemInfo> m_ButchItemList = null;

        public TGiantSickleSpiderATMonster()
            : base()
        {
            m_boExploration = false;// 是否可探索
            m_ButchItemList = new List<TMonItemInfo>();//可探索物品列表 
        }

        ~TGiantSickleSpiderATMonster()
        {
            if (m_ButchItemList.Count > 0)// 可探索物品列表
            {
                for (int I = 0; I < m_ButchItemList.Count; I++)
                {
                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                    {
                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                    }
                }
            }
            m_ButchItemList = null;
        }

        public override void Die()
        {
            if (m_boExploration)
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, ""); // 可探索,则发消息让客户端提示
            }
            base.Die();
        }

        // 显示名字,重载此方法,使人物进入地图后,可以看到死了怪身上有"可探索"字样
        public override string GetShowName()
        {
            string result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)
            {
                // 可探索,则发消息让客户端提示
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            return result;
        }

        public void AddItemsFromConfig()
        {
            TStringList LoadList;
            TMonItemInfo MonItem;
            string s28;
            string s2C;
            string s30 = string.Empty;
            int n18;
            int n1C;
            int n20;
            IniFile ItemIni;
            // ---------------------------读取怪物配置----------------------------------
            string sFileName = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + ".txt";
            if (File.Exists(sFileName))
            {
                ItemIni = new IniFile(sFileName);
                if (ItemIni != null)
                {
                    m_nButchChargeClass = ItemIni.ReadInteger("Info", "ButchChargeClass", (byte)3);// 收费模式(0金币，1元宝，2金刚石，3灵符)
                    m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// 挖每次收费点数
                    boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 怪挖是否进入触发
                    // ---------------------------读取探索物品----------------------------------
                    sFileName = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + "-Item.txt";
                    if (File.Exists(sFileName))
                    {
                        if (m_ButchItemList != null)
                        {
                            if (m_ButchItemList.Count > 0)
                            {
                                for (int I = 0; I < m_ButchItemList.Count; I++)
                                {
                                    if (m_ButchItemList[I] != null)
                                    {
                                        Dispose(m_ButchItemList[I]);
                                    }
                                }
                            }
                            m_ButchItemList.Clear();
                        }
                        LoadList = new TStringList();
                        LoadList.LoadFromFile(sFileName);
                        if (LoadList.Count > 0)
                        {
                            for (int I = 0; I < LoadList.Count; I++)
                            {
                                s28 = LoadList[I];
                                if ((s28 != "") && (s28[0] != ';'))
                                {
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n18 = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n1C = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    if (s30 != "")
                                    {
                                        if (s30[0] == '\"')
                                        {
                                            HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                                        }
                                    }
                                    s2C = s30;
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    n20 = HUtil32.Str_ToInt(s30, 1);
                                    if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                                    {
                                        MonItem = new TMonItemInfo();
                                        MonItem.SelPoint = n18 - 1;
                                        MonItem.MaxPoint = n1C;
                                        MonItem.ItemName = s2C;
                                        MonItem.Count = n20;
                                        if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint) // 计算机率 1/10 随机10<=1 即为所得的物品
                                        {
                                            m_ButchItemList.Add(MonItem);
                                        }
                                    }
                                }
                            }
                        }
                        if (m_ButchItemList.Count > 0)
                        {
                            m_boExploration = true; // 是否可探索
                        }
                        Dispose(LoadList);
                    }
                    Dispose(ItemIni);
                }
            }
        }
    }
}
