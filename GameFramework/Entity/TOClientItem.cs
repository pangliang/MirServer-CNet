using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TOClientItem
    {
        public TOStdItem s;
        public int MakeIndex;
        public UInt16 Dura;
        public UInt16 DuraMax;
    }
}