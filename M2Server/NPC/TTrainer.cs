/*
 * 名称：TTrainer
 * 创建人：John
 * 创建时间：2012-3-6 9:36:40
 * 描述:
 *********************************************
*/
using GameFramework;

namespace M2Server
{
    /// <summary>
    /// 练功师
    /// </summary>
    public class TTrainer : TNormNpc
    {
        public uint m_dw568 = 0;
        /// <summary>
        /// 练功师受攻击时统计总破坏力
        /// </summary>
        public int n56C = 0;
        public int n570 = 0;
        
        public TTrainer()
            : base()
        {

            m_dw568 = HUtil32.GetTickCount();
            this.m_btAntiPoison = 0;
            n56C = 0;
            n570 = 0;
        }

        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            try
            {
                result = false;
                if ((ProcessMsg.wIdent == Grobal2.RM_STRUCK) || (ProcessMsg.wIdent == Grobal2.RM_MAGSTRUCK))
                {
                    if (GetObject<TTrainer>(ProcessMsg.BaseObject) == this)
                    {
                        n56C += ProcessMsg.wParam;
                        m_dw568 = HUtil32.GetTickCount();
                        n570++;
                        this.ProcessSayMsg("破坏力为 " + ProcessMsg.wParam + ",平均值为 " + (n56C / n570).ToString());
                    }
                }
                if (ProcessMsg.wIdent == Grobal2.RM_MAGSTRUCK)
                {
                    result = base.Operate(ProcessMsg);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TTrainer.Operate");
            }
            return result;
        }

        public  override void Run()
        {
            this.m_WAbil.HP = this.m_WAbil.MaxHP;
            if (n570 > 0)
            {
                if ((HUtil32.GetTickCount() - m_dw568) > 3000)// 3 * 1000
                {
                    this.ProcessSayMsg("总破坏力为  " + n56C + ",平均值为 " + n56C / n570);
                    n570 = 0;
                    n56C = 0;
                }
            }
            base.Run();
        }
    }
}
