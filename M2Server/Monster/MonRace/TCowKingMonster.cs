using GameFramework;
using System;

namespace M2Server.Monster
{
    public class TCowKingMonster : TATMonster
    {
        public uint dw558 = 0;
        public bool bo55C = false;
        public bool bo55D = false;
        public int n560 = 0;
        public uint dw564 = 0;
        public uint dw568 = 0;
        public uint dw56C = 0;
        public int dw570 = 0;

        public TCowKingMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 500);
            dw558 = HUtil32.GetTickCount();
            bo2BF = true;
            n560 = 0;
            bo55C = false;
            bo55D = false;
        }

        ~TCowKingMonster()
        {

        }

        public override void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            TAbility WAbil = m_WAbil;
            int nPower = GetAttackPower(HUtil32.LoWord(WAbil.DC), ((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)));
            HitMagAttackTarget(TargeTBaseObject, nPower / 2, nPower / 2, true);
        }

        public override void Initialize()
        {
            dw56C = m_nNextHitTime;
            dw570 = m_nWalkSpeed;
            base.Initialize();
        }

        public override void Run()
        {
            int n8 = 0;
            int nC = 0;
            int n10;
            try
            {
                if (!m_boDeath && !m_boGhost && ((HUtil32.GetTickCount() - dw558) > 30000)) // 30 * 1000
                {
                    dw558 = HUtil32.GetTickCount();
                    if ((m_TargetCret != null) && (sub_4C3538() >= 5))
                    {
                        m_TargetCret.GetBackPosition(ref n8, ref  nC);
                        if (m_PEnvir.CanWalk(n8, nC, false))
                        {
                            SpaceMove(m_PEnvir.sMapName, n8, nC, 0);
                            return;
                        }
                        MapRandomMove(m_PEnvir.sMapName, 0);
                        return;
                    }
                    n10 = n560;
                    n560 = 7 - m_WAbil.HP / (m_WAbil.MaxHP / 7);
                    if ((n560 >= 2) && (n560 != n10))
                    {
                        bo55C = true;
                        dw564 = HUtil32.GetTickCount();
                    }
                    if (bo55C)
                    {
                        if ((HUtil32.GetTickCount() - dw564) < 8000)
                        {
                            m_nNextHitTime = 10000;
                        }
                        else
                        {
                            bo55C = false;
                            bo55D = true;
                            dw568 = HUtil32.GetTickCount();
                        }
                    }
                    if (bo55D)
                    {
                        if ((HUtil32.GetTickCount() - dw568) < 8000)
                        {
                            m_nNextHitTime = 500;
                            m_nWalkSpeed = 400;
                        }
                        else
                        {
                            bo55D = false;
                            m_nNextHitTime = dw56C;
                            m_nWalkSpeed = dw570;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCowKingMonster.Run");
            }
            base.Run();
        }
    }
}
