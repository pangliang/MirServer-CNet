using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TElfWarriorMonster : TSpitSpider
    {
        public int n55C = 0;
        public bool boIsFirst = false;
        public uint dwDigDownTick = 0;

        public void AppearNow()
        {
            boIsFirst = false;
            m_boFixedHideMode = false;
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            RecalcAbilitys();
            m_dwWalkTick = m_dwWalkTick + 800;
            dwDigDownTick = HUtil32.GetTickCount();
        }

        public TElfWarriorMonster()
            : base()
        {
            m_nViewRange = 6;
            m_boFixedHideMode = true;
            boIsFirst = true;
            this.m_boUsePoison = false;
        }

        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            ResetElfMon();
        }

        private void ResetElfMon()
        {
            m_nNextHitTime = Convert.ToUInt32(1500 - m_btSlaveMakeLevel * 100);
            m_nWalkSpeed = 500 - m_btSlaveMakeLevel * 50;
            m_dwWalkTick = HUtil32.GetTickCount() + 2000;
        }

        public override void Run()
        {
            bool boChangeFace;
            TBaseObject ElfMon;
            string ElfName;
            byte nCode = 0;
            try
            {
                ElfMon = null;
                nCode = 1;
                if (boIsFirst)
                {
                    nCode = 2;
                    boIsFirst = false;
                    m_boFixedHideMode = false;
                    nCode = 3;
                    SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                    ResetElfMon();
                }
                nCode = 4;
                if (m_boDeath)
                {
                    if ((HUtil32.GetTickCount() - m_dwDeathTick > 2000))// 2 * 1000
                    {
                        nCode = 5;
                        MakeGhost();
                    }
                }
                else
                {
                    nCode = 6;
                    boChangeFace = true;
                    if (m_TargetCret != null)
                    {
                        boChangeFace = false;
                    }
                    nCode = 7;
                    if ((m_Master != null))
                    {
                        if (((m_Master.m_TargetCret != null) || (m_Master.m_LastHiter != null)))
                        {
                            boChangeFace = false;
                        }
                    }
                    nCode = 8;
                    if (boChangeFace)
                    {
                        if ((HUtil32.GetTickCount() - dwDigDownTick) > 60000)// 6 * 10 * 1000
                        {
                            nCode = 9;
                            ElfName = m_sCharName;
                            if (ElfName[ElfName.Length] == '1')
                            {
                                ElfName = ElfName.Substring(1 - 1, ElfName.Length - 1);
                                nCode = 10;
                                ElfMon = this.MakeClone(ElfName, this);
                            }
                            if (ElfMon != null)
                            {
                                nCode = 11;
                                SendRefMsg(Grobal2.RM_DIGDOWN, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                                SendRefMsg(Grobal2.RM_CHANGEFACE, 0, Parse(this), Parse(ElfMon), 0, "");
                                nCode = 12;
                                ElfMon.m_boAutoChangeColor = m_boAutoChangeColor;
                                if (ElfMon is TElfMonster)
                                {
                                    ((ElfMon) as TElfMonster).AppearNow();
                                }
                                nCode = 13;
                                m_Master = null;
                                KickException();
                            }
                        }
                    }
                    else
                    {
                        dwDigDownTick = HUtil32.GetTickCount();
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TElfWarriorMonster.Run Code:" + nCode);
                KickException();
            }
        }
    }
}
