using GameFramework;
using System;

namespace M2Server.Mon
{
    /// <summary>
    /// 雪域五毒魔:寒冰掌，治疗术
    /// </summary>
    public class TSnowyWuDu : TMonster
    {
        public TSnowyWuDu()
            : base()
        {
            this.m_nViewRange = 8;
        }

        /// <summary>
        /// 寒冰掌,治疗术 攻击
        /// </summary>
        /// <returns></returns>
        public  override bool AttackTarget()
        {
            bool result = false;
            int nPower;
            int nDir;
            int push;
            if (this.m_TargetCret == null)
            {
                return result;
            }
            if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
            {
                this.m_dwHitTick = HUtil32.GetTickCount();
                if (!this.m_TargetCret.m_boDeath)
                {
                    if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 5))
                    {
                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                        if ((this.m_WAbil.HP < HUtil32.Round(this.m_WAbil.MaxHP * 0.6)) && (HUtil32.Random(2) == 0))
                        {
                            // 使用治疗术
                            this.SendRefMsg(Grobal2.RM_FAIRYATTACKRATE, 1, this.m_nCurrX, this.m_nCurrY, 0, "");// 治愈术
                            this.SendDelayMsg(this, Grobal2.RM_MAGHEALING, 0, 50, 0, 0, "", 800);// 发消息给客户端，显示治愈术效果
                            result = true;
                            return result;
                        }
                        else
                        {
                            // 寒冰掌
                            nPower = this.GetAttackPower(HUtil32.LoWord(this.m_WAbil.DC), ((short)HUtil32.HiWord(this.m_WAbil.DC) - HUtil32.LoWord(this.m_WAbil.DC)));
                            this.SendDelayMsg(this, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY), 2, 0, "", 600);
                            if ((!this.m_TargetCret.m_boStickMode) && (HUtil32.Random(2) == 0))
                            {
                                push = HUtil32.Random(3) - 1;
                                if (push > 0)
                                {
                                    nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                    this.SendDelayMsg(this, Grobal2.RM_DELAYPUSHED, nDir, HUtil32.MakeLong(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY), push, 0, "", 600);
                                }
                            }
                            // 发消息给客户端，显示寒冰掌效果
                            this.SendRefMsg(Grobal2.RM_LIGHTING, 1, this.m_nCurrX, this.m_nCurrY, 0, "");
                            result = true;
                            return result;
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
            byte nCode;
            nCode = 0;
            try
            {
                if (!this.m_boDeath && !this.m_boGhost && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 1000) && (this.m_TargetCret == null))
                    {
                        nCode = 1;
                        this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        this.SearchTarget();// 搜索可攻击目标
                    }
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        nCode = 2;
                        if (!this.m_boNoAttackMode)
                        {
                            if (this.m_TargetCret != null)
                            {
                                nCode = 3;
                                if (AttackTarget())
                                {
                                    base.Run();
                                    return;
                                }
                                nCode = 4;
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) > 5) || (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) > 5)) && (this.m_TargetCret != null))
                                {
                                    // 目标离远了,走向目标
                                    nCode = 5;
                                    if (!this.m_TargetCret.m_boDeath && !this.m_TargetCret.m_boGhost)
                                    {
                                        nCode = 6;
                                        this.m_nTargetX = this.m_TargetCret.m_nCurrX;
                                        this.m_nTargetY = this.m_TargetCret.m_nCurrY;
                                        nCode = 7;
                                        this.GotoTargetXY();
                                        base.Run();
                                        return;
                                    }
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
                        nCode = 8;
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
                M2Share.MainOutMessage("{异常} TSnowyWuDu.Run Code:" + nCode);
            }
            base.Run();
        }
    }
}
