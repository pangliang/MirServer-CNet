using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Entity {
    /// <summary>
    /// 刷怪信息包装体（对应MonGen.txt内的一行数据）
    /// </summary>
    public class MonGenInfo {
        /// <summary>
        /// 怪物名称
        /// </summary>
        public string sMonName { get; set; }

        /// <summary>
        /// 所处地图编号
        /// </summary>
        public string sMapName { get; set; }

        /// <summary>
        /// 地图X坐标
        /// </summary>
        public int nX { get; set; }

        /// <summary>
        /// 地图Y坐标
        /// </summary>
        public int nY { get; set; }

        /// <summary>
        /// 刷怪范围
        /// </summary>
        public int nRange { get; set; }

        /// <summary>
        /// 刷怪数量
        /// </summary>
        public int nCount { get; set; }

        /// <summary>
        /// 刷怪时间
        /// </summary>
        public int dwZenTime { get; set; }

        private byte _colorCode = 0;
        /// <summary>
        /// 自定义名字的颜色代码（0-255）
        /// </summary>
        public byte nNameColor {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        private int _togetherRate = 0;
        /// <summary>
        /// 集中座标刷新机率[1-100]
        /// </summary>
        public int nMissionGenRate {
            get { return _togetherRate; }
            set { _togetherRate = value; }
        }

        /// <summary>
        /// 启动时间
        /// </summary>
        public uint dwStartTime { get; set; }

        /// <summary>
        /// 是否内功怪,打死可以增加内力值
        /// </summary>
        public bool boIsNGMon { get; set; }

        /// <summary>
        /// 0自动变色(0改变颜色 1不改变)
        /// </summary>
        public bool nChangeColorType { get; set; }

        /// <summary>
        /// 当前刷怪索引
        /// </summary>
        public int nCurrMonGen;
    }
}
