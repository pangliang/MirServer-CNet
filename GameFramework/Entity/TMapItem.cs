using System;

namespace GameFramework
{
    /// <summary>
    /// 地图物品结构
    /// </summary>
    public unsafe class TMapItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 外观
        /// </summary>
        public ushort Looks;

        public byte AniCount;
        public byte Reserved;

        /// <summary>
        /// 数量
        /// </summary>
        public int Count;

        /// <summary>
        /// 物品谁可以捡起
        /// </summary>
        public Object OfBaseObject;

        /// <summary>
        /// 谁掉落的
        /// </summary>
        public Object DropBaseObject;

        public uint dwCanPickUpTick;
        public TUserItem* UserItem;
    }
}