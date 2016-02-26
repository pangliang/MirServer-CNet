namespace GameFramework
{
    public class TSwitchDataInfo
    {
        public string sChrName;
        public string sMAP;
        public ushort wX;
        public ushort wY;
        public TAbility Abil;
        public int nCode;
        public bool boC70;// 未使用
        public bool boBanShout;
        public bool boHearWhisper;
        public bool boBanGuildChat;
        public bool boAdminMode;
        public bool boObMode;
        public string[] BlockWhisperArr;
        public TSlaveInfo[] SlaveArr;
        public ushort[] StatusValue;
        public uint[] StatusTimeOut;
    }
}