using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct THumDataInfo // Size 4515
    {
        public TRecordHeader Header;
        public THumData Data;
    }
}