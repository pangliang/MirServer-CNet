// ================================================
// TSaveRcd.cs, 保存玩家数据结构体
// Copyright (C) 2012 Daomi
// ================================================
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class TSaveRcd  //Size 4564
    {
        private byte AccountLen;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string _sAccount;

        /// <summary>
        /// 玩家帐号
        /// </summary>
        public string sAccount
        {
            get { return _sAccount; }
            set
            {
                _sAccount = value;
                AccountLen = HUtil32.GetStrLength(value);
            }
        }

        private byte ChrNameLen;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string _sChrName;

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
        /// 会话ID
        /// </summary>
        public int nSessionID;

        /// <summary>
        /// 保存次数
        /// </summary>
        public int nReTryCount;

        /// <summary>
        /// 保存错误下次保存TICK
        /// </summary>
        public uint dwSaveTick;

        /// <summary>
        /// 玩家对象
        /// </summary>
        public int PlayObject;

        /// <summary>
        /// 玩家数据
        /// </summary>
        public THumDataInfo HumanRcd;

        /// <summary>
        /// 是否英雄
        /// </summary>
        public bool boIsHero;

        /// <summary>
        /// 职业类型
        /// </summary>
        public byte btJob;

        /// <summary>
        /// 是否是副将英雄
        /// </summary>
        public bool boisDoubleHero;

        public byte rev001;
        public byte rev002;
    }
}