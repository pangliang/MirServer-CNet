namespace DBServer.Entity
{
    public class TUserInfo
    {
        public int nIndex;
        public string sAccount;
        public string sUserIPaddr;
        public string sGateIPaddr;
        public string sConnID;
        public int nSessionID;
        public NetFramework.AsyncUserToken Socket;
        public string sReceiveText;//接收消息
        public bool boChrSelected;
        public bool boChrQueryed;//是否查询过角色信息
        public uint dwTick34;
        public uint dwChrTick;//角色操作时间
        public sbyte nSelGateID;// 角色网关ID
        public bool boRandomNumber;//验证码是否正确
        public string sRandomNumber;//验证码
        public uint dwRandomTick;
        public uint dwQueryDelChrTick;
        public uint dwRestoreChr;
    } // end TUserInfo
}