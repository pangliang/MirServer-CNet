using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 加载玩家数据结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class TLoadHuman
    {
        private byte AccountLen;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        private string _sAccount;

        private byte ChrNameLen;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        private string _sChrName;

        private byte UserAddrLen;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        private string _sUserAddr;

        public Int32 nSessionID;

        /// <summary>
        /// 玩家帐号
        /// </summary>
        public string sAccount
        {
            get { return _sAccount; }
            set
            {
                _sAccount = value;
                AccountLen = (byte)value.Length;
            }
        }

        /// <summary>
        /// 玩家名称
        /// </summary>
        public string sChrName
        {
            get { return _sChrName; }
            set
            {
                _sChrName = value;
                ChrNameLen = HUtil32.GetStrLength(value);
            }
        }

        /// <summary>
        /// 玩家IP地址
        /// </summary>
        public string sUserAddr
        {
            get { return _sUserAddr; }
            set
            {
                _sUserAddr = value;
                UserAddrLen = (byte)value.Length;
            }
        }
    }
}