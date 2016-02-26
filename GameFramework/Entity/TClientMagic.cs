using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TClientMagic //Size 84
    {
        public char Key;
        public byte Level;
        public byte LevelLen;//没用，占位变量
        public int CurTrain;
        public TMagic Def;
    }
}