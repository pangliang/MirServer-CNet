using GameFramework;
using System;

namespace M2Server.Mon
{
    /// <summary>
    /// 恶魔蝙蝠
    /// </summary>
    public class TDevilBat : TMonster
    {
        public TDevilBat()
            : base()
        {
            this.m_boAnimal = false;// 不是动物,即不能挖
            this.m_boStickMode = true;// 不能冲撞,气功，抗拒
            this.m_btAntiPoison = 200;// 中毒躲避
            this.m_nViewRange = 11;
        }

        public  override bool AttackTarget()
        {
            bool result = false;
            byte bt06 = 0;
            if (this.GetAttackDir(this.m_TargetCret, ref bt06))
            {
                if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                    this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                    this.Attack(this.m_TargetCret, bt06);
                    this.m_WAbil.HP = 0;// 死亡
                }
                result = true;
            }
            else
            {
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
            return result;
        }

        public override void Run()
        {
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 1000) && (this.m_TargetCret == null))
                    {
                        this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        this.SearchTarget();// 搜索可攻击目标
                    }
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (!this.m_boNoAttackMode)
                        {
                            if (this.m_TargetCret != null)
                            {
                                if (AttackTarget())
                                {
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
                        if (this.m_nTargetX != -1)
                        {
                            this.GotoTargetXY();
                        }
                        else
                        {
                            if (this.m_TargetCret == null)
                            {
                                this.Wondering();
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TDevilBat.Run");
            }
        }
    }
}
