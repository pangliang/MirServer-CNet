using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 人物技能
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct THumMagic
    {
        public UInt16 wMagIdx;

        // 技能ID
        public byte btLevel;

        // 等级
        public byte btKey;

        // 技能快捷键
        public int nTranPoint;
    }
}