namespace GameFramework
{
    /// <summary>
    /// 地图信息
    /// </summary>
    public class TMapInfo
    {
        public string sName;
        public string sMapNO;
        public int nL;

        // 0x10
        public int nServerIndex;

        // 0x24
        public int nNEEDONOFFFlag;

        // 0x28
        public bool boNEEDONOFFFlag;

        // 0x2C
        public string sShowName;

        // 0x4C
        public string sReConnectMap;

        // 0x50
        public bool boSAFE;

        // 0x51
        public bool boDARK;

        // 0x52
        public bool boFIGHT;

        // 0x53
        public bool boFIGHT3;

        // 0x54
        public bool boDAY;

        // 0x55
        public bool boQUIZ;

        // 0x56
        public bool boNORECONNECT;

        // 0x57
        public bool boNEEDHOLE;

        // 0x58
        public bool boNORECALL;

        // 0x59
        public bool boNORANDOMMOVE;

        // 0x5A
        public bool boNODRUG;

        // 0x5B
        public bool boMINE;

        // 0x5C
        public bool boNOPOSITIONMOVE;
    }
}