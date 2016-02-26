//************************************************
//创建人：Dr.Kevin
//创建时间：2012-09-08
//修改时间：2012-10-03
//修改描述：
//功能作用：
//************************************************
using System;
using GameFramework;

namespace M2Server
{
    /// <summary>
    /// 大刀卫士
    /// </summary>
    public class TSuperGuard: TNormNpc
    {
        public bool AttackTarget()
        {
            bool result = false;
            int nOldX;
            int nOldY;
            byte btOldDir;
            ushort wHitMode;
            if (this.m_TargetCret.m_PEnvir == this.m_PEnvir)
            {
                if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                    this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                    nOldX = this.m_nCurrX;
                    nOldY = this.m_nCurrY;
                    btOldDir = this.m_btDirection;
                    this.m_TargetCret.GetBackPosition(ref this.m_nCurrX, ref this.m_nCurrY);
                    this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                    this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                    wHitMode = 0;
                    this._Attack(ref wHitMode, this.m_TargetCret);
                    this.m_TargetCret.SetLastHiter(this);
                    this.m_TargetCret.m_ExpHitter = null;
                    this.m_nCurrX = nOldX;
                    this.m_nCurrY = nOldY;
                    this.m_btDirection = btOldDir;
                    this.TurnTo(this.m_btDirection);
                    this.BreakHolySeizeMode();
                }
                result = true;
            }
            else
            {
                this.DelTargetCreat();
            }
            return result;
        }

        public TSuperGuard() : base()
        {
            this.m_btRaceServer = 11;
            this.m_nViewRange = 7;
            this.m_nLight = 4;
        }
        

        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            return base.Operate(ProcessMsg);
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            if (this.m_Master != null)
            {
                this.m_Master = null;// 不允许召唤为宝宝
            }
            if ((0 - this.m_dwHitTick) > this.m_nNextHitTime)
            {
                if (this.m_VisibleActors.Count > 0)
                {
                    for (int I = 0; I < this.m_VisibleActors.Count; I ++ )
                    {
                        BaseObject = this.m_VisibleActors[I].BaseObject;
                        if ((BaseObject == null) || (BaseObject.m_boDeath))
                        {
                            continue;
                        }
                        if ((BaseObject.m_nCopyHumanLevel == 2) && (!M2Share.g_Config.boAllowGuardAttack) || (BaseObject.m_nCopyHumanLevel == 3)) // 不攻击分身
                        {
                            continue;
                        }
                        if ((BaseObject.m_btRaceServer == 112)) // 大刀不砍安全区内弓箭手
                        {
                            continue;
                        }
                        if ((BaseObject.PKLevel() >= 2) || ((BaseObject.m_btRaceServer >= Grobal2.RC_MONSTER) && (!BaseObject.m_boMission)))
                        {
                            this.SetTargetCreat(BaseObject);
                            break;
                        }
                    }
                }
            }
            if (this.m_TargetCret != null)
            {
                AttackTarget();
            }
            base.Run();
        }
    }
}

