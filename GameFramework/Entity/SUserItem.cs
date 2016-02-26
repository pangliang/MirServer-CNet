using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GameFramework.Entity
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct SUserItem
    {
        public int MakeIndex;

        /// <summary>
        /// 物品id
        /// </summary>
        public UInt16 wIndex;

        /// <summary>
        /// 当前持久值
        /// </summary>
        public UInt16 Dura;

        /// <summary>
        /// 最大持久值
        /// </summary>
        public UInt16 DuraMax;

        /// <summary>
        /// (戒指)          0 AC2 防御  1 MAC2 魔御 2 DC2 攻击 3 MC2 魔法 4 SC2 道术 6 佩带需求 7 佩带级别 8 Reserved 9-13 暂不知道 14 持久
        /// (武器)          0 DC2 1 MC2 2 SC2 3 幸运 4 诅咒 5 准确 6 攻击速度 7 强度 8-9 暂不知道 10 需开封 11-13 暂不知道 14 持久
        /// (衣服,靴子,腰带)0 防御 1 魔御 2 攻击 3 魔法 4 道术 5-13 无效果 14 持久
        /// (头盔)          0 防御 1 魔御 2 攻击 3 魔法 4 道术 5 佩带需求 6 佩带级别 7-13 无效果 14 持久
        /// (项链,手镯)     0 AC2 1 MAC2 2 DC2 3 MC2 4 SC2 6 佩带需求 7 佩带级别 8 Reserved 9-13 暂不知道 14 持久
        /// 酒              0 品质 1 酒精度 2 药力值
        /// 酿酒材料        0 品质
        /// </summary>
        public fixed sbyte btValue[22];
    }
}
