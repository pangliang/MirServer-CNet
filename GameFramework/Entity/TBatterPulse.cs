using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TBatterPulse // 经络
    {
        public byte Pulse;
        public byte PulseLevel;
    }
}