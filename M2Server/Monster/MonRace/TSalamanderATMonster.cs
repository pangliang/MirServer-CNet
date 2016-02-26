using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace M2Server.Monster
{
    /// <summary>
    /// 狂热火蜥蜴:4×4火墙攻击,施毒术
    /// </summary>
    public class TSalamanderATMonster : TATMonster
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

        public TSalamanderATMonster()
            : base()
        {
            m_boExploration = false;
            m_ButchItemList = new List<TMonItemInfo>();
        }

        ~TSalamanderATMonster()
        {
            if (m_ButchItemList.Count > 0)
            {
                for (int i = 0; i < m_ButchItemList.Count; i++)
                {
                    if (m_ButchItemList[i] != null)
                    {
                        Dispose(m_ButchItemList[i]);
                    }
                }
            }
            m_ButchItemList = null;
        }

        public override void Die()
        {
            if (m_boExploration) // 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            base.Die();
        }

        // 显示名字
        public override string GetShowName()
        {
            string result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)  // 可探索,则发消息让客户端提示
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
                    }
                }
            }
        }

        public override void Run()
        {
            int nPower;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if ((m_TargetCret != null) && (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 2))
                    {
                        m_dwHitTick = HUtil32.GetTickCount();
                        if ((HUtil32.Random(4) == 0))// 癫狂状态
                        {
                            if ((M2Share.g_EventManager.GetEvent(m_PEnvir, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY, Grobal2.ET_FIRE) == null))
                            {
                                MagMakeFireCross(this, GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))), 4, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);// 火墙
                            }
                            else if ((HUtil32.Random(4) == 0))
                            {
                                if (IsProperTarget(m_TargetCret))
                                {
                                    if (HUtil32.Random(m_TargetCret.m_btAntiPoison + 7) <= 6)// 施毒
                                    {
                                        nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));// 中毒类型 - 绿毒
                                        m_TargetCret.SendDelayMsg(this, Grobal2.RM_POISON, Grobal2.POISON_DECHEALTH, nPower, Parse(this), 4, "", 150);
                                    }
                                }
                            }
                            else
                            {
                                AttackTarget();// 物理攻击
                            }
                        }
                        else
                        {
                            if (HUtil32.Random(4) == 0)
                            {
                                if (IsProperTarget(m_TargetCret))
                                {
                                    if (HUtil32.Random(m_TargetCret.m_btAntiPoison + 7) <= 6)// 施毒
                                    {
                                        nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));// 中毒类型 - 绿毒
                                        m_TargetCret.SendDelayMsg(this, Grobal2.RM_POISON, Grobal2.POISON_DECHEALTH, nPower, Parse(this), 4, "", 150);
                                    }
                                }
                            }
                            else if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 2))
                            {
                                AttackTarget();// 物理攻击
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSalamanderATMonster.Run");
            }
            base.Run();
        }

        public override bool AttackTarget()
        {
            bool result = false;
            byte btDir = 0;
            if (m_TargetCret != null)
            {
                if (TargetInSpitRange(m_TargetCret, ref btDir))
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    this.Attack(m_TargetCret, btDir);
                    result = true;
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

        // 火墙 4*4
        private int MagMakeFireCross(TBaseObject PlayObject, int nDamage, int nHTime, int nX, int nY)
        {
            int result = 0;
            TFireBurnEvent FireBurnEvent;
            if (PlayObject.m_PEnvir.GetEvent(nX, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY - 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY - 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY + 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY + 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY) == null)
            {

                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY - 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY - 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY + 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY + 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 2, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 2, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 2, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 2, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 2, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 2, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY - 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY - 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY + 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY + 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 2, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 2, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 2, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 2, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 2, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 2, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            result = 1;
            return result;
        }
    }
}
