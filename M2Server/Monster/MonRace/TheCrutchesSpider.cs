using GameFramework;
using System;
using System.Collections;
using System.IO;

namespace M2Server.Monster
{
    /// <summary>
    /// 金杖蜘蛛:自我治疗(群疗),冰咆哮
    /// </summary>
    public class TheCrutchesSpider : TMonster
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
        public ArrayList m_ButchItemList = null;

        public TheCrutchesSpider()
            : base()
        {
            m_boExploration = false;
            m_ButchItemList = new ArrayList();
        }

        ~TheCrutchesSpider()
        {
            if (m_ButchItemList.Count > 0)  // 可探索物品列表
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
            if (m_boExploration)// 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            base.Die();
        }

        // 显示名字
        public override string GetShowName()
        {
            string result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");// 可探索,则发消息让客户端提示
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
                                        MonItem.Count = n20; ;
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
                            m_boExploration = true;// 是否可探索
                        }
                        //LoadList.Free;
                    }
                    //ItemIni.Free;
                }
            }
        }

        public override void Run()
        {
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();// 搜索可攻击目标
                    }
                    if ((m_TargetCret != null))
                    {
                        // 走路间隔
                        if ((HUtil32.GetTickCount() - m_dwWalkTick > m_nWalkSpeed) && (!m_TargetCret.m_boDeath))
                        {
                            // 目标不为空
                            if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5))
                            {
                                if ((m_WAbil.HP < HUtil32.Round(Convert.ToDouble(m_WAbil.MaxHP))) && (HUtil32.Random(4) == 0))// 使用群体治疗术
                                {
                                    if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
                                    {
                                        m_dwHitTick = HUtil32.GetTickCount();
                                        M2Share.MagicManager.MagBigHealing(this, 50, m_nCurrX, m_nCurrY);// 群体治疗术
                                        SendRefMsg(Grobal2.RM_FAIRYATTACKRATE, 1, m_nCurrX, m_nCurrY, Parse(this), "");
                                    }
                                }
                                AttackTarget();
                            }
                            else
                            {
                                this.GotoTargetXY();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TheCrutchesSpider.Run");
            }
            base.Run();
        }

        // 远距离使用冰咆哮 5*5范围
        public override bool AttackTarget()
        {
            bool result = false;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
            {
                m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5))
                {
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    m_btDirection = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    M2Share.MagicManager.MagBigExplosion(this, GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))),
                        m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY, M2Share.g_Config.nSnowWindRange, MagicConst.SKILL_SNOWWIND);
                    SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, Parse(m_TargetCret), "");
                    result = true;
                    return result;
                }
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }
    }

}