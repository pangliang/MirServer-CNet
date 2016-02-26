namespace GameFramework
{
    public class TMapDesc
    {
        /// <summary>
        ///  地图名称
        /// </summary>
        public string MapName;

        /// <summary>
        /// X坐标
        /// </summary>
        public ushort X;

        /// <summary>
        ///  Y坐标
        /// </summary>
        public ushort Y;

        /// <summary>
        /// 地图标致名称
        /// </summary>
        public string PointName;

        /// <summary>
        /// 字体颜色
        /// </summary>
        public int FontColor;

        /// <summary>
        /// 小地图类别
        /// </summary>
        public byte MinMapType;
    }
}