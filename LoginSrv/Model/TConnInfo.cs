namespace LoginSrv.Model
{
    public struct TConnInfo
    {
        // Size
        public string sAccount;

        public string sIPaddr;
        public string sServerName;
        public int nSessionID;
        public bool boPayCost;
        public bool bo11;
        public uint dwKickTick;
        public uint dwStartTick;
        public bool boKicked;
        public int nLockCount;
    } // end TConnInfo
}