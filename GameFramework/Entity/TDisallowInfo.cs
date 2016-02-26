namespace GameFramework
{
    /// <summary>
    /// 禁止物品规则
    /// </summary>
    public class TDisallowInfo
    {
        public bool boDrop;

        // 丢弃
        public bool boDeal;

        // 交易
        public bool boStorage;

        // 存仓
        public bool boRepair;

        // 修理
        public bool boDropHint;

        // 掉落提示
        public bool boOpenBoxsHint;

        // 宝箱提示
        public bool boNoDropItem;

        // 永不爆出
        public bool boButchHint;

        // 挖取提示
        public bool boHeroUse;

        // 禁止英雄使用
        public bool boPickUpItem;

        // 禁止捡起(除GM外)
        public bool boDieDropItems;
    }
}