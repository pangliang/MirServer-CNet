namespace GameFramework
{
    /// <summary>
    ///  全局会话类
    /// </summary>
    public class TSessInfo
    {
        public string sAccount;
        public string sIPaddr;
        public int nSessionID;
        public int nPayMent;
        public int nPayMode;
        public int nSessionStatus;
        public uint dwStartTick;
        public uint dwActiveTick;
        public int nRefCount;
    }
}