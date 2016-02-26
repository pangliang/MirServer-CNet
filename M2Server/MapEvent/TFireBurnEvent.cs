using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using GameFramework;

namespace M2Server
{
    /// <summary>
    /// 火墙
    /// </summary>
    public class TFireBurnEvent : TEvent
    {
        public uint m_dwRunTick = 0;
        public byte m_nType = 0;
        /// <summary>
        /// 内功技能之前的威力值
        /// </summary>
        public int nTwoPwr = 0;
        /// <summary>
        /// 学习过内功技能
        /// </summary>
        public bool boReadSkill = false;

        public TFireBurnEvent(TBaseObject Creat, int nX, int nY, int nType, uint nTime, int nDamage)
            : base(Creat.m_PEnvir, nX, nY, nType, nTime, true)
        {
            this.m_nDamage = nDamage;
            this.m_OwnBaseObject = Creat;
            m_nType = (byte)nType;
            nTwoPwr = 0;
            boReadSkill = false;
        }

        ~TFireBurnEvent() { }

        public unsafe override void Run()
        {
            IList<TPlayObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            int nSePwr;
            int nPwr;
            if ((HUtil32.GetTickCount() - m_dwRunTick) > 3000)
            {
                m_dwRunTick = HUtil32.GetTickCount();
                BaseObjectList = new List<TPlayObject>();
                try
                {
                    if (this.m_Envir != null)
                    {
                        this.m_Envir.GeTBaseObjects(this.m_nX, this.m_nY, true, BaseObjectList);
                        if (BaseObjectList.Count > 0)
                        {
                            for (int I = 0; I < BaseObjectList.Count; I++)
                            {
                                TargeTBaseObject = BaseObjectList[I];
                                nSePwr = this.m_nDamage;
                                if ((TargeTBaseObject != null) && (this.m_OwnBaseObject != null))
                                {
                                    if ((!this.m_OwnBaseObject.m_boRobotObject))
                                    {
                                        if ((this.m_OwnBaseObject.IsProperTarget(TargeTBaseObject)))
                                        {
                                            if ((m_nType == Grobal2.ET_FIRE)) // 英雄火墙
                                            {
                                                if ((this.m_OwnBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                                {
                                                    this.m_OwnBaseObject.m_ExpHitter = TargeTBaseObject;
                                                }
                                                if (((this.m_OwnBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                    || (this.m_OwnBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)) && boReadSkill)
                                                {
                                                    nPwr = 0;
                                                    if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                    {
                                                        nPwr = M2Share.MagicManager.GetNGPow(TargeTBaseObject, ((TPlayObject)(TargeTBaseObject)).m_MagicSkill_213, nTwoPwr);// 静之火墙
                                                    }
                                                    else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                    {
                                                        nPwr = M2Share.MagicManager.GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_213, nTwoPwr);// 静之火墙
                                                    }
                                                    nSePwr = nSePwr - nPwr;
                                                    if (nSePwr < 0)
                                                    {
                                                        nSePwr = 0;
                                                    }
                                                }
                                            }
                                            TargeTBaseObject.SendMsg(this.m_OwnBaseObject, Grobal2.RM_MAGSTRUCK_MINE, 0, nSePwr, 0, 0, "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Dispose(BaseObjectList);
                }
            }
            base.Run();
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}
