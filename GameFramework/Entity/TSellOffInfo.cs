using System;

namespace GameFramework
{
    /// <summary>
    /// 拍卖数据结构
    /// </summary>
    public class TSellOffInfo
    {
        // Size 59
        public string[] sCharName;

        // 拍卖人
        public DateTime dSellDateTime;

        // 拍卖时间
        public int nSellGold;

        // 金额
        public int N;

        public TUserItem UseItems;

        // 物品
        public int n1;
    } // end TSellOffInfo
}