using System;
using System.Runtime.InteropServices;

namespace DBServer.Entity
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TDBHeader
    {
        // Size 124
        public fixed sbyte sDesc[35];

        // 0x00    36
        public int n24;

        // 0x24
        public int n28;

        // 0x28
        public int n2C;

        // 0x2C
        public int n30;

        // 0x30
        public int n34;

        // 0x34
        public int n38;

        // 0x38
        public int n3C;

        // 0x3C
        public int n40;

        // 0x40
        public int n44;

        // 0x44
        public int n48;

        // 0x48
        public int n4C;

        // 0x4C
        public int n50;

        // 0x50
        public int n54;

        // 0x54
        public int n58;

        // 0x58
        public int nLastIndex;

        // 0x5C
        public DateTime dLastDate;

        // 0x60
        public int nHumCount;

        // 0x68
        public int n6C;

        // 0x6C
        public int n70;

        // 0x70
        public DateTime dUpdateDate;
    } // end TDBHeader
}