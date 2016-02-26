using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace M2Server.Monster
{
    /// <summary>
    /// 雷炎蛛王
    /// </summary>
    public class TYanLeiWangSpider : TATMonster
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
        /// <summary>
        /// 是否喷出蜘蛛网
        /// </summary>
        public bool boIsSpiderMagic = false;
        public uint m_dwSpiderMagicTick = 0;

        public TYanLeiWangSpider()
            : base()
        {
            m_boExploration = false;// 是否可探索
            m_ButchItemList = new ArrayList();// 可探索物品列表
            boIsSpiderMagic = false;// 是否喷出蜘蛛网
        }

        ~TYanLeiWangSpider()
        {
            int I;
            if (m_ButchItemList.Count > 0)// 可探索物品列表
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
            if (m_boExploration)
            {
                // 可探索,则发消息让客户端提示
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
                    boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 挖是否进入触发
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
                            m_boExploration = true;// 是否可探索
                        }
                        // LoadList.Free;
                    }
                    // ItemIni.Free;
                }
            }
        }

        public override void Run()
        {
            int nPower = 0;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    // 走路间隔
                    if ((HUtil32.GetTickCount() - m_dwWalkTick > m_nWalkSpeed) && (m_TargetCret != null) && (!m_TargetCret.m_boDeath))
                    {
                        // 目标不为空
                        if (boIsSpiderMagic)
                        {
                            // 喷出网后,延时1100毫秒显示目标的效果
                            if (HUtil32.GetTickCount() - m_dwSpiderMagicTick > 1100)
                            {
                                boIsSpiderMagic = false;// 是否喷出蜘蛛网
                                SpiderMagicAttack(nPower / 2, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY, 3);
                                base.Run();
                                return;
                            }
                        }
                        if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2))
                        {
                            if ((HUtil32.Random(4) == 0) && (m_TargetCret.m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] == 0))
                            {
                                // 喷出蜘蛛网
                                if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
                                {
                                    m_dwHitTick = HUtil32.GetTickCount();
                                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));
                                    SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, Parse(m_TargetCret), "");
                                    m_dwSpiderMagicTick = HUtil32.GetTickCount();// 喷出蜘蛛网计时,用于延时处理目标身上的小网显示
                                    boIsSpiderMagic = true;// 是否喷出蜘蛛网
                                }
                            }
                            else
                            {
                                AttackTarget();
                            }
                        }
                        else
                        {
                            this.GotoTargetXY();
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TYanLeiWangSpider.Run");
            }
            base.Run();
        }

        // 物理攻击
        new public virtual bool AttackTarget()
        {
            bool result;
            int nPower;
            result = false;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
            {
                m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2))
                {
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));
                    HitMagAttackTarget(m_TargetCret, nPower / 2, nPower / 2, true);
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

        // 喷出蜘蛛网   被蜘蛛网包围,只能走动,不能跑动
        private void SpiderMagicAttack(int nPower, int nX, int nY, int nRage)
        {
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                BaseObjectList = GetMapBaseObjects(m_PEnvir, nX, nY, nRage);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (IsProperTarget(TargeTBaseObject))
                        {
                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                // 英雄锁定后,不打锁定怪
                                if (!((THeroObject)(TargeTBaseObject)).m_boTarget)
                                {
                                    TargeTBaseObject.SetTargetCreat(this);
                                }
                            }
                            else
                            {
                                TargeTBaseObject.SetTargetCreat(this);
                            }
                            TargeTBaseObject.SendMsg(this, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                            TargeTBaseObject.MakeSpiderMag(7);// 中蛛网，不能跑动   //改变角色状态
                        }
                    }
                }
            }
            finally
            {
                // BaseObjectList.Free;
            }
        }
    }
}
