namespace GameFramework
{
    public class TLoadDBInfo
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string sAccount;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string sCharName;

        /// <summary>
        /// IP地址
        /// </summary>
        public string sIPaddr;

        public string sMsg;
        public int nSessionID;

        /// <summary>
        /// 客户端版本号
        /// </summary>
        public int nSoftVersionDate;

        public int nPayMent;

        /// <summary>
        /// 玩家模式
        /// </summary>
        public int nPayMode;

        /// <summary>
        /// 端口
        /// </summary>
        public int nSocket;

        public int nGSocketIdx;
        public int nGateIdx;
        public bool boClinetFlag;
        public uint dwNewUserTick;
        public object PlayObject;
        public int nReLoadCount;

        /// <summary>
        /// 是否英雄
        /// </summary>
        public bool boIsHero;

        public byte btLoadDBType;
        public byte btJob;
    }
}