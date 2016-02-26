using System;

namespace GameFramework
{
    /// <summary>
    /// 客户端元宝寄售数据结构
    /// </summary>
    public unsafe struct TClientDealOffInfo
    {
        public byte DealCharNameLen;
        public fixed sbyte sDealCharName[14];// 寄售人
        public byte BuyCharNameLen;
        public fixed sbyte sBuyCharName[14];// 购买人
        public DateTime dSellDateTime;// 寄售时间
        public int nSellGold;// 交易的元宝数
        public fixed byte UseItemsBuff[9 * 72];// 物品
        public byte N;
    }
}