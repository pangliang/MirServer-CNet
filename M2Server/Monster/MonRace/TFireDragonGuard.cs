using GameFramework;
using System.Collections.Generic;

namespace M2Server.Mon
{
    /// <summary>
    /// 火龙守护兽
    /// </summary>
    public class TFireDragonGuard : TAnimalObject
    {
        /// <summary>
        /// 是否发光
        /// </summary>
        public bool m_boLight = false;
        /// <summary>
        /// 发光间隔
        /// </summary>
        public uint m_dwLightTick = 0;
        /// <summary>
        /// 发光时长
        /// </summary>
        public uint m_dwLightTime = 0;
        /// <summary>
        /// 是否可以攻击，即最后一个熄灭的怪，负责攻击消息
        /// </summary>
        public bool m_boAttick = false;
        public string s_AttickXY = string.Empty;

        public TFireDragonGuard()
            : base()
        {
            this.m_boStoneMode = true;// 人物不能攻击，石像化
            this.m_boAnimal = false;// 不是动物,即不能挖
            this.m_boStickMode = true;// 不能冲撞模式(即敌人不能使用野蛮冲撞技能攻击)
            this.m_btAntiPoison = 200;// 中毒躲避
            this.m_boUnParalysis = true;// 防麻痹
            this.m_boLight = false;// 是否发光
            this.m_boAttick = false;// 是否可以攻击，即最后一个熄灭的怪，负责攻击消息
            this.s_AttickXY = "";// 攻击坐标
            this.m_dwLightTime = 2500;// 发光时长
        }

        /// <summary>
        /// 刷新属性
        /// </summary>
        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            this.m_boStoneMode = true;// 人物不能攻击，石像化
            this.m_boAnimal = false;// 不是动物,即不能挖
            this.m_boStickMode = true;// 不能冲撞模式(即敌人不能使用野蛮冲撞技能攻击)
            this.m_btAntiPoison = 200;// 中毒躲避
            this.m_boUnParalysis = true;// 防麻痹
        }

        /// <summary>
        /// 小火圈攻击
        /// </summary>
        /// <param name="nPower"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRage"></param>
        /// <returns></returns>
        private bool MagBigExplosion(int nPower, int nX, int nY, int nRage)
        {
            bool result = false;
            TBaseObject TargeTBaseObject;
            TFireBurnEvent FireBurnEvent;
            List<TBaseObject> BaseObjectList = new List<TBaseObject>();
            try
            {
                FireBurnEvent = new TFireBurnEvent(this, nX, nY, Grobal2.ET_FIREDRAGON, 4000, 0);// 客户端显示小火圈效果
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
                BaseObjectList = this.GetMapBaseObjects(this.m_PEnvir, nX, nY, nRage);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if (TargeTBaseObject.m_boDeath || (TargeTBaseObject.m_boGhost))
                            {
                                continue;
                            }
                            if (this.IsProperTarget(TargeTBaseObject))
                            {
                                this.SetTargetCreat(TargeTBaseObject);
                                TargeTBaseObject.SendMsg(this, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                                result = true;
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        public int AttackTarget_IsChar(string str)
        {
            int result;
            // 判断有几个'|'号
            int I;
            result = 0;
            if (str.Length <= 0)
            {
                return result;
            }
            for (I = 1; I <= str.Length; I++)
            {
                if ((str[I] == '|'))
                {
                    result++;
                }
            }
            return result;
        }

        public bool AttackTarget()
        {
            bool result = false;
            int nX;
            int nY;
            int nPower;
            string str;
            string Str1 = "";
            string s30 = "";
            string s2C = "";
            TAbility WAbil;
            try
            {
                if ((HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                    if (s_AttickXY.IndexOf("|") > 0) // 根据配置文件的攻击坐标，发消息显示场景
                    {
                        WAbil = this.m_WAbil;
                        nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                        str = s_AttickXY;
                        for (int I = 0; I <= AttackTarget_IsChar(s_AttickXY); I++)
                        {
                            str = HUtil32.GetValidStr3(str, ref Str1, new string[] { "|" });
                            if (Str1 != "")
                            {
                                s30 = HUtil32.GetValidStr3(Str1, ref s2C, new string[] { ",", "\09" });// X,Y
                                nX = HUtil32.Str_ToInt(s2C, 0);
                                nY = HUtil32.Str_ToInt(s30, 0);
                                MagBigExplosion(nPower, nX, nY, 1);
                            }
                        }
                    }
                    result = true;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFireDragonGuard.AttackTarget");
            }
            return result;
        }

        public override void Run()
        {
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if (m_boLight)// 发亮
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > m_dwLightTime)
                            {
                                this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                                m_dwLightTime = 2500;// 发光时长
                                m_boLight = false;
                            }
                        }
                        if (m_boAttick && !m_boLight && (s_AttickXY != ""))
                        {
                            if (AttackTarget()) // 可以攻击
                            {
                                m_boAttick = false; // 处理攻击代码
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFireDragonGuard.Run");
            }
        }
    }
}
