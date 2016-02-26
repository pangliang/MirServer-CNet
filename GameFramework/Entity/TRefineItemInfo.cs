namespace GameFramework
{
    /// <summary>
    ///  淬炼数据结构  Size 36
    /// </summary>
    public unsafe struct TRefineItemInfo
    {
        public string sItemName;// 物品名称
        public byte nRefineRate;// 淬炼成功率
        public byte nReductionRate;// 失败还原率
        public bool boDisappear;// 火云石是否消失 0-减少1持久,1-消失
        public byte nNeedRate;// 极品机率
        public fixed sbyte TAttributeBuff[14 * 2];
    }
}