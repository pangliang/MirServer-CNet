#region -   版   权   信   息  -
//======================================================
//
//      创 建 人：没有蛀牙
//      创建时间：2013/04/12 20:46:58
//      功    能：物品属性结构体
//      修改纪录：
// 
//======================================================
#endregion
using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TUserItem
    {
        public int MakeIndex;
        public UInt16 wIndex;// 物品id
        public UInt16 Dura;// 当前持久值
        public UInt16 DuraMax;// 最大持久值 由于Delphi不是Packed，所以+1
        // (戒指)          0 AC2 防御  1 MAC2 魔御 2 DC2 攻击 3 MC2 魔法 4 SC2 道术 6 佩带需求 7 佩带级别 8 Reserved 9-13 暂不知道 14 持久
        // (武器)          0 DC2 1 MC2 2 SC2 3 幸运 4 诅咒 5 准确 6 攻击速度 7 强度 8-9 暂不知道 10 需开封 11-13 暂不知道 14 持久
        // (衣服,靴子,腰带)0 防御 1 魔御 2 攻击 3 魔法 4 道术 5-13 无效果 14 持久
        // (头盔)          0 防御 1 魔御 2 攻击 3 魔法 4 道术 5 佩带需求 6 佩带级别 7-13 无效果 14 持久
        // (项链,手镯)     0 AC2 1 MAC2 2 DC2 3 MC2 4 SC2 6 佩带需求 7 佩带级别 8 Reserved 9-13 暂不知道 14 持久
        // 酒              0 品质 1 酒精度 2 药力值
        // 酿酒材料        0 品质
        public fixed byte btValue[22];

        public override string ToString()
        {
            fixed (byte* pb = this.btValue)
            {
                return "(" + this.MakeIndex + ")[" + pb[0] + "/" + pb[1] + "/" + pb[2] + "/" + pb[3] + "/" + pb[4] + "/" + pb[5] + "/"
                    + pb[6] + "/" + pb[7] + "/" + pb[8] + "/" + pb[14] + "/#" + pb[15] + "/" + pb[16] + "/" + pb[17] + "/" + pb[18] + "/" + pb[19];
            }
        }
    }
}