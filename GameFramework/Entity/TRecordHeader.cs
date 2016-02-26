using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TRecordHeader //Size 28
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool boDeleted;
        /// <summary>
        /// ID
        /// </summary>
        public byte nSelectID;
        /// <summary>
        /// 是否英雄
        /// </summary>
        public bool boIsHero;
        /// <summary>
        /// 职业
        /// </summary>
        public byte btJob;
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public Double dCreateDate;
        public byte NameLen;
        public fixed sbyte sName[15];
    }
}