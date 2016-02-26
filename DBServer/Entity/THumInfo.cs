using GameFramework;
using System;
using System.Runtime.InteropServices;

namespace DBServer.Entity
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct THumInfo
    {
        // Size 72
        public TRecordHeader Header;

        public byte ChrNameLen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        private string _sChrName;
        public string sChrName
        {
            get { return _sChrName; }
            set { _sChrName = value;
            ChrNameLen = HUtil32.GetStrLength(value);
            }
        }
        // 0x14  //角色名称   44

        public byte AccountLen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        private string _sAccount;
        public string sAccount
        {
            get { return _sAccount; }
            set {
                _sAccount = value;
                AccountLen = HUtil32.GetStrLength(value);
            }
        }
        //public fixed sbyte sAccount[30];
        // 账号
        public bool boDeleted;

        // 是否删除
        public bool boIsHero;

        public DateTime dModDate;
        public byte btCount;

        // 操作计次
        public bool boSelected;

        // 是否选择
        public fixed byte n6[6];

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public Double dCreateDate;

    } // end THumInfo
}