using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 客户端配置结构体
    /// Size = 20
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TClientConf
    {
        /// <summary>
        /// 是否穿人
        /// </summary>
        public bool boRUNHUMAN;

        /// <summary>
        /// 是否穿怪
        /// </summary>
        public bool boRUNMON;

        /// <summary>
        /// 是否穿NPC
        /// </summary>
        public bool boRunNpc;

        /// <summary>
        /// 不受限制？
        /// </summary>
        public bool boWarRunAll;

        /// <summary>
        /// 死亡颜色
        /// </summary>
        public byte btDieColor;

        public byte btDieColorLen;//无用,占位字节

        /// <summary>
        /// 魔法攻击间隔
        /// </summary>
        public UInt16 wSpellTime;

        /// <summary>
        /// 物理攻击间隔
        /// </summary>
        public UInt16 wHitIime;

        /// <summary>
        /// 物品闪烁间隔
        /// </summary>
        public UInt16 wItemFlashTime;

        /// <summary>
        /// 装备速度
        /// </summary>
        public byte btItemSpeed;

        public bool boParalyCanRun;
        public bool boParalyCanWalk;

        /// <summary>
        /// 麻痹攻击
        /// </summary>
        public bool boParalyCanHit;

        public bool boParalyCanSpell;

        /// <summary>
        /// 是否显示职业等级
        /// </summary>
        public bool boShowJobLevel;

        public bool boDuraAlert;

        /// <summary>
        /// 魔法盾效果 T-特色效果 F-盛大效果
        /// </summary>
        public bool boSkill31Effect;
    }
}