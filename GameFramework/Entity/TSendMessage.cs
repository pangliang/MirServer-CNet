using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class TSendMessage //Size 40
    {
        public UInt16 IdentLen;
        public UInt16 wIdent;
        public int wParam;
        public int nParam1;
        public int nParam2;
        public int nParam3;
        public int BaseObject;
        public uint dwAddTime;
        public uint dwDeliveryTime;
        public bool boLateDelivery;
        private byte[] rboLateDelivery;//Size 3
        public IntPtr Buff;
    }
}