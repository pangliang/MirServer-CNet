
#region -   版   权   信   息  -
//======================================================
//
//      创 建 人：没有蛀牙
//      创建时间：2013/04/12 20:49:56
//      功    能：玩家技能结构
//      修改纪录：
// 
//======================================================
#endregion

using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 玩家技能结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TUserMagic
    {
        public TMagic MagicInfo;

        /// <summary>
        /// 技能ID
        /// </summary>
        public ushort wMagIdx;

        /// <summary>
        /// 等级
        /// </summary>
        public byte btLevel;

        /// <summary>
        ///  技能快捷键
        /// </summary>
        public byte btKey;

        /// <summary>
        /// 技能升级所需点数
        /// </summary>
        public int nTranPoint;
    }
}