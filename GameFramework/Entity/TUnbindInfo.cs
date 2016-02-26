using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 解包物品列表
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
    public unsafe struct TUnbindInfo
    {
        /// <summary>
        /// 物品编号
        /// </summary>
        public int nUnbindCode;

        public byte sItemNameLen;

        /// <summary>
        /// 物品名称
        /// </summary>
        public fixed sbyte sItemName[14];
    }
}