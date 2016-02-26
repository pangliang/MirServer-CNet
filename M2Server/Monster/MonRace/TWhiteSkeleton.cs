using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TWhiteSkeleton : TATMonster
    {
        public bool m_boIsFirst = false;
        public TWhiteSkeleton()
            : base()
        {
            m_boIsFirst = true;
            m_boFixedHideMode = true;
            m_btRaceServer = 100;
            m_nViewRange = 6;
        }

        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            sub_4AAD54();
        }

        public override void Run()
        {
            try
            {
                if (m_boIsFirst)
                {
                    m_boIsFirst = false;
                    m_btDirection = 5;
                    m_boFixedHideMode = false;
                    SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TWhiteSkeleton.Run");
            }
            base.Run();
        }

        private void sub_4AAD54()
        {
            m_nNextHitTime = Convert.ToUInt32(3000 - m_btSlaveMakeLevel * 600);
            m_nWalkSpeed = 1200 - m_btSlaveMakeLevel * 250;
            m_dwWalkTick = HUtil32.GetTickCount() + 2000;
        }
    }
}
