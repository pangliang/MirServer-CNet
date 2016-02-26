using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 刷怪类
    /// </summary>
    public class TMonGenInfo
    {
        public string sMapName;// 地图名
        public int nRace;
        public int nRange;// 范围
        public int nMissionGenRate;// 集中座标刷新机率 1 -100
        public uint dwStartTick;// 刷怪间隔
        public int nX;// X坐标
        public int nY;// Y坐标
        public string sMonName;// 怪物名
        public int nAreaX;
        public int nAreaY;
        public int nCount;// 怪物数量
        public uint dwZenTime;// 刷怪时间
        public uint dwStartTime;// 启动时间
        public bool boIsNGMon;// 内功怪,打死可以增加内力值
        public byte nNameColor;// 自定义名字的颜色
        public int nChangeColorType;// 0自动变色 >0改变颜色 -1不改变
        public List<TBaseObject> CertList;
        public TEnvirnoment Envir;
        /// <summary>
        /// 当前刷怪索引
        /// </summary>
        public int nCurrMonGen;
    }

    public class TMapMonGenCount
    {
        public string sMapName;// 地图名称
        public int nMonGenCount;// 刷怪数量
        public uint dwNotHumTimeTick;// 没玩家的间隔
        public int nClearCount;// 清除数量
        public bool boNotHum;// 是否有玩家
        public uint dwMakeMonGenTimeTick;// 刷怪的间隔
        public int nMonGenRate;// 刷怪倍数  10
        public uint dwRegenMonstersTime;
    }

  
}