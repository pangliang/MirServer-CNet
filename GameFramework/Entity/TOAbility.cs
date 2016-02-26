using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TOAbility  //50
    {
        public UInt16 Level;  // 等级
        public UInt16 AC;
        public UInt16 MAC;
        public UInt16 DC;
        public UInt16 MC;
        public UInt16 SC;
        public int HP; // 21亿血
        public int MP;// 21亿魔法
        public int MaxHP;// 21亿血
        public int MaxMP; // 21亿魔法
        public UInt16 NG; // 当前内力值
        public UInt16 MaxNG; // 内力值上限
        public Int32 Exp;// 当前经验
        public Int32 MaxExp; // 升级经验
        public UInt16 Weight;// 最大重量
        public UInt16 MaxWeight;// 最大重量
        public int WearWeight;
        public int MaxWearWeight; // 最大负重
        public int HandWeight;
        public int MaxHandWeight;
    }
}