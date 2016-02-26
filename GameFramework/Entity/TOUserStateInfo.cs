using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TOUserStateInfo // Size 522
    {
        public int feature;
        public byte UserNameLen;
        public fixed sbyte UserName[15];
        public byte GuilidNameLen;
        public fixed sbyte GuildName[14];
        public byte GuildRankNameLen;
        public fixed sbyte GuildRankName[16];
        public UInt16 NAMECOLOR;

        // 引用时需要指针转换 (TOClientItem*)UseItemsBuff
        public fixed sbyte UseItemsBuff[9 * 52];// DELPHI中0..8,9是人物身上有多少格子 52 为 SizeOf(TOClientItem) 的大小
    }
}