using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TNakedAbility // Size 20
    {
        public UInt16 DC;
        public UInt16 MC;
        public UInt16 SC;
        public UInt16 AC;
        public UInt16 MAC;
        public int HP;
        public int MP;
        public UInt16 Hit;
        public UInt16 Speed;
        public UInt16 X2;
    }
}