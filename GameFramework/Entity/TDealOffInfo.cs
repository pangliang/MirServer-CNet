using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 元宝寄售数据结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TDealOffInfo
    {
        public byte DealCharNameLen;
        public fixed sbyte sDealCharName[14];// 寄售人
        public byte BuyCharNameLen;
        public fixed sbyte sBuyCharName[14];// 购买人
        public DateTime dSellDateTime;// 寄售时间
        public int nSellGold;// 交易的元宝数
        //(TUserItem*)UseItemsBuff
        public fixed byte UseItemsBuff[9 * 32];// 物品
        public byte N;
    }
}