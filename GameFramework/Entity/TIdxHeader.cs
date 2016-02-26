using System;

namespace GameFramework
{
    public class TIdxHeader
    {
        // Size 124
        public string[] sDesc;

        // 0x00
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
        public int n5C;

        // 0x5C
        public int n60;

        // 0x60  95
        public int n70;

        // 0x70  99
        public int nQuickCount;

        // 0x74  100
        public int nHumCount;

        // 0x78
        public int nDeleteCount;

        // 0x7C
        public int nLastIndex;

        // 0x80
        public DateTime dUpdateDate;
    }
}