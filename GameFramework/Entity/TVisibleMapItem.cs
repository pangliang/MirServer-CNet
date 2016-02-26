namespace GameFramework
{
    /// <summary>
    ///  可见的地图物品
    /// </summary>
    public class TVisibleMapItem
    {
        /// <summary>
        /// 物品状态 1：可见
        /// </summary>
        public int nVisibleFlag;

        /// <summary>
        /// X
        /// </summary>
        public int nX;

        /// <summary>
        /// Y
        /// </summary>
        public int nY;

        /// <summary>
        /// 物品名称
        /// </summary>
        public string sName;

        /// <summary>
        /// 物品外观编号
        /// </summary>
        public ushort wLooks;

        /// <summary>
        /// 地图物品结构
        /// </summary>
        public TMapItem MapItem;
    }
}