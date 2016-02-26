using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 武器升级结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TUpgradeInfo
    {
        public byte UserNameLen;
        public fixed sbyte sUserName[14];// 升级物品的人物名
        public TUserItem* UserItem;
        public byte btDc;
        public byte btSc;
        public byte btMc;
        public byte btDura;
        public int n2C;
        public DateTime dtTime;
        public UInt16 dwGetBackTick;
        public int n3C;
    }
}