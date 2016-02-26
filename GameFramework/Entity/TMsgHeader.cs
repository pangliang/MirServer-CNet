using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TMsgHeader
    {
        public uint dwCode;
        public int nSocket;
        public short wGSocketIdx;
        public short wIdent;
        public int wUserListIndex;
        public int nLength;
    }
}