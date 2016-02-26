using System;

namespace GameFramework
{
    /// <summary>
    /// 全局会话类
    /// </summary>
    public class TGlobaSessionInfo
    {
        public string sAccount;
        // 登录账号
        public string sIPaddr;
        // IP地址
        public int nSessionID;
        // 会话ID
        public int n24;
        public bool bo28;
        public bool boLoadRcd;
        // 是否读取
        public bool boStartPlay;
        // 是否开始游戏
        public uint dwAddTick;
        // 加入列表的时间
        public DateTime dAddDate;
    }
}