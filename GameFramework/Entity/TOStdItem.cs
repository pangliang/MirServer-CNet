using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TOStdItem //Size 44
    {
        public byte NameLen;
        public fixed sbyte Name[14];
        public byte StdMode;
        public byte Shape;
        public byte Weight;
        public byte AniCount;
        public sbyte Source;
        public byte Reserved;
        public byte NeedIdentify;
        public UInt16 Looks;
        public UInt16 DuraMax;
        public UInt16 AC;
        public UInt16 MAC;
        public UInt16 DC;
        public UInt16 MC;
        public UInt16 SC;
        public byte Need;
        public byte NeedLevel;
        public UInt16 w26;
        public int Price;
    }
}