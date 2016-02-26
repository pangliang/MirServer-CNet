using System.Runtime.InteropServices;

namespace DBServer.Entity
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TDisabledChar
    {
        public fixed sbyte sChrName[14];
        public int wLevel;
        public byte btJob;
        public byte btSex;
    } // end TDisabledChar
}