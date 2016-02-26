using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace M2Server
{
    public class TAnimalObject : TBaseObject
    {
        public int m_nTargetX = 0;
        public int m_nTargetY = 0;
        public bool m_boRunAwayMode = false; // 运行远离模式
        public uint m_dwRunAwayStart = 0; // 运行远离间隔
        public uint m_dwRunAwayTime = 0;

        public virtual void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            base.AttackDir(TargeTBaseObject, 0, nDir);
        }

        public TAnimalObject()
            : base()
        {
            m_nTargetX = -1;
            this.dwTick3F4 = HUtil32.GetTickCount();
            this.m_btRaceServer = Grobal2.RC_ANIMAL;
            this.m_dwHitTick = HUtil32.GetTickCount() - (uint)HUtil32.Random(3000);
            this.m_dwWalkTick = HUtil32.GetTickCount() - (uint)HUtil32.Random(3000);
            this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
            m_boRunAwayMode = false;
            m_dwRunAwayStart = HUtil32.GetTickCount();
            m_dwRunAwayTime = 0;
            this.m_nCopyHumanLevel = 0;
        }

        public virtual void GotoTargetXY()
        {
            int I;
            int nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            if (((this.m_nCurrX != m_nTargetX) || (this.m_nCurrY != m_nTargetY)))
            {
                n10 = m_nTargetX;
                n14 = m_nTargetY;
                this.dwTick3F4 = HUtil32.GetTickCount();
                nDir = Grobal2.DR_DOWN;
                if (n10 > this.m_nCurrX)
                {
                    nDir = Grobal2.DR_RIGHT;
                    if (n14 > this.m_nCurrY)
                    {
                        nDir = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        nDir = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n10 < this.m_nCurrX)
                    {
                        nDir = Grobal2.DR_LEFT;
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNLEFT;
                        }
                        if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                    }
                    else
                    {
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWN;
                        }
                        else if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UP;
                        }
                    }
                }
                nOldX = this.m_nCurrX;
                nOldY = this.m_nCurrY;
                this.WalkTo((byte)nDir, false);
                n20 = HUtil32.Random(3);
                for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                {
                    if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                    {
                        if (n20 != 0)
                        {
                            nDir++;
                        }
                        else if (nDir > 0)
                        {
                            nDir -= 1;
                        }
                        else
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                        if ((nDir > Grobal2.DR_UPLEFT))
                        {
                            nDir = Grobal2.DR_UP;
                        }
                        this.WalkTo((byte)nDir, false);
                    }
                }
            }
        }

        /// <summary>
        /// 攻击怪物会执行此方法
        /// </summary>
        /// <param name="ProcessMsg"></param>
        /// <returns></returns>
        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            byte nCode = 0;
            try
            {
                if (ProcessMsg.wIdent == Grobal2.RM_STRUCK) // 打击
                {
                    nCode = 1;
                    TBaseObject BaseObject = GetObject<TBaseObject>(ProcessMsg.nParam3);
                    if ((GetObject<TBaseObject>(ProcessMsg.BaseObject) == this) &&
                        (BaseObject != null))
                    {
                        nCode = 2;
                        this.SetLastHiter(BaseObject);
                        nCode = 3;
                        this.Struck(BaseObject);
                        nCode = 4;
                        this.BreakHolySeizeMode();
                        nCode = 10;
                        if ((this.m_Master != null) && (!BaseObject.m_boDeath))
                        {
                            nCode = 9;
                            if (((BaseObject != this.m_Master)&& (((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)|| ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))))))
                            {
                                nCode = 6;
                                if (this.m_Master.m_Master != null)
                                {
                                    nCode = 7;
                                    if (this.m_Master.m_Master != BaseObject)
                                    {
                                        this.m_Master.SetPKFlag(BaseObject);
                                    }
                                }
                                else
                                {
                                    this.m_Master.SetPKFlag(BaseObject);
                                }
                            }
                        }
                        nCode = 8;
                        if (GameConfig.boMonSayMsg)
                        {
                            this.MonsterSayMsg(BaseObject, TMonStatus.s_UnderFire);
                        }
                    }
                    result = true;
                }
                else
                {
                    result = base.Operate(ProcessMsg);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TAnimalObject.Operate Code:" + nCode);
            }
            return result;
        }

        public override void Run()
        {
            base.Run();
        }

        /// <summary>
        /// 被击中
        /// </summary>
        /// <param name="hiter"></param>
        public  virtual void Struck(TBaseObject hiter)
        {
            byte btDir = 0;
            this.m_dwStruckTick = HUtil32.GetTickCount();
            if (hiter != null)
            {
                if ((this.m_TargetCret == null) || this.GetAttackDir(this.m_TargetCret, ref btDir) || (HUtil32.Random(6) == 0))
                {
                    if (this.IsProperTarget(hiter))
                    {
                        this.SetTargetCreat(hiter);
                    }
                }
            }
            if (this.m_boAnimal) // 是动物
            {
                this.m_nMeatQuality = this.m_nMeatQuality - HUtil32.Random(300);
                if (this.m_nMeatQuality < 0)
                {
                    this.m_nMeatQuality = 0;
                }
            }
            this.m_dwHitTick = Convert.ToUInt32(this.m_dwHitTick + (150 - HUtil32._MIN(130, this.m_Abil.Level * 4)));
        }

        /// <summary>
        /// 物理攻击
        /// </summary>
        /// <param name="TargeTBaseObject">目标</param>
        /// <param name="nHitPower">物理伤害值</param>
        /// <param name="nMagPower">魔法伤害值</param>
        /// <param name="boFlag"></param>
        public void HitMagAttackTarget(TBaseObject TargeTBaseObject, int nHitPower, int nMagPower, bool boFlag)
        {
            int nDamage;
            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
            IList<TPlayObject> BaseObjectList = new List<TPlayObject>();
            try
            {
                this.m_PEnvir.GeTBaseObjects(TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY, false, BaseObjectList);
                foreach (var BaseObject in BaseObjectList)
                {
                    if (this.IsProperTarget(BaseObject))
                    {
                        nDamage = 0;
                        nDamage += BaseObject.GetHitStruckDamage(this, nHitPower);
                        nDamage += BaseObject.GetMagStruckDamage(this, nMagPower);
                        if (nDamage > 0)
                        {
                            BaseObject.StruckDamage(nDamage);
                            BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, Parse(this), "", 200);
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
                BaseObjectList = null;
            }
            this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
        }

        /// <summary>
        /// 删除目标
        /// </summary>
        public override void DelTargetCreat()
        {
            base.DelTargetCreat();
            m_nTargetX = -1;
            m_nTargetY = -1;
        }

        /// <summary>
        /// 搜索目标
        /// </summary>
        public void SearchTarget()
        {
            TBaseObject BaseObject;
            TBaseObject BaseObject18 = null;
            int nC;
            int n10;
            try
            {
                n10 = 11;
                foreach (var Targetitem in this.m_VisibleActors)
                {
                    BaseObject = Targetitem.BaseObject;
                    if (BaseObject != null)
                    {
                        if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (BaseObject.m_Abil.Level <= 22)
                            && (((THeroObject)(BaseObject)).m_btStatus == 1))// 目标为英雄,且等级不超过22级,跟随状态,则不攻击英雄
                        {
                            continue;
                        }
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    n10 = nC;
                                    BaseObject18 = BaseObject;
                                    break;
                                }
                            }
                        }
                    }   
                }
                if (BaseObject18 != null)
                {
                    this.SetTargetCreat(BaseObject18);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TAnimalObject.SearchTarget");
            }
        }

        public void sub_4C959C()
        {
            int nC;
            int n10;
            TBaseObject Creat;
            TBaseObject BaseObject;
            Creat = null;
            n10 = 10;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (BaseObject.m_boDeath)
                        {
                            continue;
                        }
                        if (this.IsProperTarget(BaseObject))
                        {
                            nC = Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY);
                            if (nC < n10)
                            {
                                n10 = nC;
                                Creat = BaseObject;
                            }
                        }
                    }
                }
            }
            if (Creat != null)
            {
                this.SetTargetCreat(Creat);
            }
        }

        /// <summary>
        /// 设置攻击目标
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        public virtual void SetTargetXY(int nX, int nY)
        {
            m_nTargetX = nX;
            m_nTargetY = nY;
        }

        public virtual void Wondering()
        {
            if ((HUtil32.Random(20) == 0))
            {
                if ((HUtil32.Random(4) == 1))
                {
                    this.TurnTo(HUtil32.Random(8));
                }
                else
                {
                    this.WalkTo(this.m_btDirection, false);
                }
            }
        }
    }
}
