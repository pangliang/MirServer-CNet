using GameFramework;
using System;

namespace M2Server.Mon
{
    /// <summary>
    /// 雪域灭天魔:灭天火，会施放红毒
    /// </summary>
    public class TSnowyFireDay : TMonster
    {
        public TSnowyFireDay()
            : base()
        {
            this.m_nViewRange = 8;
        }

        /// <summary>
        /// 使用灭天火攻击
        /// </summary>
        /// <returns></returns>
        public  override bool AttackTarget()
        {
            bool result = false;
            int nPower = -1;
            if ((this.m_TargetCret == null))
            {
                return result;
            }
            if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
            {
                this.m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 5))
                {
                    this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                    if (!this.m_TargetCret.m_boDeath)
                    {
                        if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0))// 目标红毒时间到，才重新使用施毒术
                        {
                            if (this.IsProperTarget(this.m_TargetCret))
                            {
                                if (HUtil32.Random(this.m_TargetCret.m_btAntiPoison + 7) <= 6) // 施毒
                                {
                                    nPower = this.GetAttackPower(HUtil32.LoWord(this.m_WAbil.DC), ((short)HUtil32.HiWord(this.m_WAbil.DC) - HUtil32.LoWord(this.m_WAbil.DC)));// 中毒类型：红毒
                                    this.m_TargetCret.SendDelayMsg(this, Grobal2.RM_POISON, Grobal2.POISON_DAMAGEARMOR, nPower, Parse(this), 4, "", 150);// 发消息给客户端，显示施毒效果
                                    this.SendRefMsg(Grobal2.RM_FAIRYATTACKRATE, 1, this.m_nCurrX, this.m_nCurrY, Parse(m_TargetCret), "");
                                    result = true;
                                    return result;
                                }
                            }
                        }
                        else
                        {
                            // 灭天火
                            if ((HUtil32.Random(10) >= this.m_TargetCret.m_nAntiMagic))
                            {
                                nPower = this.GetAttackPower(HUtil32.LoWord(this.m_WAbil.DC), ((short)HUtil32.HiWord(this.m_WAbil.DC) - HUtil32.LoWord(this.m_WAbil.DC)));
                                if (this.m_TargetCret.m_btLifeAttrib == Grobal2.LA_UNDEAD)// 如果为不死系
                                {
                                    nPower = (int)HUtil32.Round(nPower * 1.5); 
                                }
                                this.SendDelayMsg(this, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY), 
                                    2, Parse(m_TargetCret), "", 600);// 发消息给客户端，显示灭天火效果
                                this.SendRefMsg(Grobal2.RM_LIGHTING, 1, this.m_nCurrX, this.m_nCurrY, Parse(m_TargetCret), "");
                                if (M2Share.g_Config.boPlayObjectReduceMP)
                                {
                                    this.m_TargetCret.DamageSpell((int)Math.Abs(HUtil32.Round(nPower * 0.35)));// 击中减MP值,减35%
                                }
                                result = true;
                                return result;
                            }
                            else
                            {
                                // 物理攻击
                                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 2))
                                {
                                    nPower = this.GetAttackPower(HUtil32.LoWord(this.m_WAbil.DC), ((short)HUtil32.HiWord(this.m_WAbil.DC) - HUtil32.LoWord(this.m_WAbil.DC)));
                                    this.HitMagAttackTarget(this.m_TargetCret, nPower / 2, nPower / 2, true);
                                    result = true;
                                    return result;
                                }
                            }
                        }
                    }
                    if (this.m_TargetCret.m_PEnvir == this.m_PEnvir)
                    {
                        if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 11))
                        {
                            this.SetTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                        }
                    }
                    else
                    {
                        this.DelTargetCreat();
                    }
                }
            }
            return result;
        }

        public override void Run()
        {
            byte nCode = 0;
            try
            {
                if (!this.m_boDeath && !this.m_boGhost && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 1000) && (this.m_TargetCret == null))
                    {
                        this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        nCode = 1;
                        this.SearchTarget();// 搜索可攻击目标
                    }
                    nCode = 5;
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (!this.m_boNoAttackMode)
                        {
                            if (this.m_TargetCret != null)
                            {
                                nCode = 2;
                                if (AttackTarget())
                                {
                                    base.Run();
                                    return;
                                }
                                nCode = 3;
                                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) > 5) || (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) > 5))
                                {
                                    this.m_nTargetX = this.m_TargetCret.m_nCurrX;
                                    this.m_nTargetY = this.m_TargetCret.m_nCurrY;
                                    this.GotoTargetXY(); // 目标离远了,走向目标
                                    base.Run();
                                    return;
                                }
                            }
                            else
                            {
                                this.m_nTargetX = -1;
                                if (this.m_boMission)
                                {
                                    this.m_nTargetX = this.m_nMissionX;
                                    this.m_nTargetY = this.m_nMissionY;
                                }
                            }
                        }
                        nCode = 4;
                        if (this.m_nTargetX != -1)
                        {
                            if ((this.m_TargetCret != null))
                            {
                                if ((Math.Abs(this.m_nCurrX - this.m_nTargetX) > 1) || (Math.Abs(this.m_nCurrY - this.m_nTargetY) > 1))
                                {
                                    this.GotoTargetXY();
                                }
                            }
                            else
                            {
                                this.GotoTargetXY();
                            }
                        }
                        else
                        {
                            if ((this.m_TargetCret == null))
                            {
                                this.Wondering();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSnowyFireDay.Run Code:" + nCode);
            }
            base.Run();
        }
    }
}
