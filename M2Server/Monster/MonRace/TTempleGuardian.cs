using GameFramework;
using System.Collections;
using System.IO;

namespace M2Server.Monster
{
    /// <summary>
    /// 圣殿卫士
    /// </summary>
    public class TTempleGuardian : TScultureMonster
    {
        public bool m_boExploration = false;// 是否可探索
        public byte m_nButchChargeClass = 0;// 探索收费模式(0金币，1元宝，2金刚石，3灵符)
        public int m_nButchChargeCount = 0;// 探索每次收费点数
        public bool boIntoTrigger = false;// 是否进入触发
        public ArrayList m_ButchItemList = null;

        public TTempleGuardian()
            : base()
        {
            m_boExploration = false;// 是否可探索
            m_ButchItemList = new ArrayList();// 可探索物品列表
        }

        ~TTempleGuardian()
        {
            int I;
            if (m_ButchItemList.Count > 0) // 可探索物品列表
            {
                for (I = 0; I < m_ButchItemList.Count; I++)
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
            if (m_boExploration)// 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            base.Die();
        }

        // 显示名字
        public override string GetShowName()
        {
            string result;
            result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)// 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            return result;
        }

        public void AddItemsFromConfig()
        {
            int I;
            string s24;
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
            s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + ".txt";
            if (File.Exists(s24))
            {
                ItemIni = new IniFile(s24);
                if (ItemIni != null)
                {
                    m_nButchChargeClass = (byte)ItemIni.ReadInteger("Info", "ButchChargeClass", 3);// 收费模式(0金币，1元宝，2金刚石，3灵符)
                    m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// 挖每次收费点数
                    boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 怪挖是否进入触发
                    // ---------------------------读取探索物品----------------------------------
                    s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + "-Item.txt";
                    if (File.Exists(s24))
                    {
                        if (m_ButchItemList != null)
                        {
                            if (m_ButchItemList.Count > 0)
                            {
                                for (I = 0; I < m_ButchItemList.Count; I++)
                                {
                                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                                    {
                                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                                    }
                                }
                            }
                            m_ButchItemList.Clear();
                        }
                        LoadList = new TStringList();
                        try
                        {
                            LoadList.LoadFromFile(s24);
                            if (LoadList.Count > 0)
                            {
                                for (I = 0; I < LoadList.Count; I++)
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
                                            if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)
                                            {
                                                // 计算机率 1/10 随机10<=1 即为所得的物品
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
                        }
                        finally
                        {
                            //LoadList.Free;
                        }
                    }
                    //ItemIni.Free;
                }
            }
        }

        // 读取可探索物品
        public override void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            TAbility WAbil;
            int nPower;
            WAbil = m_WAbil;
            nPower = GetAttackPower(HUtil32.LoWord(WAbil.DC), ((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)));
            HitMagAttackTarget(TargeTBaseObject, nPower / 2, nPower / 2, true);
        }
    }
}
