using GameFramework;

namespace M2Server.Monster
{
    public class TElfMonster : TMonster
    {
        public bool boIsFirst = false;

        public void AppearNow()
        {
            // 神兽
            boIsFirst = false;
            m_boFixedHideMode = false;
            RecalcAbilitys();
            m_dwWalkTick = m_dwWalkTick + 800;
        }

        public TElfMonster()
            : base()
        {
            m_nViewRange = 6;
            m_boFixedHideMode = true;
            m_boNoAttackMode = true;
            boIsFirst = true;
        }


        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            ResetElfMon();
        }

        private void ResetElfMon()
        {
            m_nWalkSpeed = 500 - m_btSlaveMakeLevel * 50;
            m_dwWalkTick = HUtil32.GetTickCount() + 2000;
        }

        public override void Run()
        {
            bool boChangeFace;
            TBaseObject ElfMon;
            byte nCode;
            nCode = 0;
            try
            {
                if (boIsFirst)
                {
                    nCode = 1;
                    boIsFirst = false;
                    m_boFixedHideMode = false;
                    nCode = 2;
                    SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                    nCode = 3;
                    ResetElfMon();
                }
                nCode = 4;
                if (m_boDeath)
                {
                    // 2 * 1000
                    if ((HUtil32.GetTickCount() - m_dwDeathTick > 2000))
                    {
                        MakeGhost();
                    }
                }
                else
                {
                    nCode = 6;
                    boChangeFace = false;
                    if (m_TargetCret != null)
                    {
                        boChangeFace = true;
                    }
                    if ((m_Master != null))
                    {
                        if (((m_Master.m_TargetCret != null) || (m_Master.m_LastHiter != null)))
                        {
                            boChangeFace = true;
                        }
                    }
                    nCode = 7;
                    if (boChangeFace)
                    {
                        nCode = 8;
                        ElfMon = this.MakeClone(m_sCharName + '1', this);
                        nCode = 9;
                        if (ElfMon != null)
                        {
                            nCode = 10;
                            ElfMon.m_boAutoChangeColor = m_boAutoChangeColor;
                            nCode = 11;
                            if (ElfMon is TElfWarriorMonster)
                            {
                                ((ElfMon) as TElfWarriorMonster).AppearNow();
                            }
                            nCode = 12;
                            m_Master = null;
                            KickException();
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TElfMonster.Run Code:" + (nCode).ToString());
                KickException();
            }
        }
    }

}
