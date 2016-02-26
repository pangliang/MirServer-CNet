using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TDefaultMessage //Size 24
    {
        public int Recog;
        public UInt16 Ident;
        public UInt16 IdentLen;//占位符 此次不需要用用到
        public uint Param;
        public uint Tag;
        public uint Series;
        public int nSessionID;
    }
}