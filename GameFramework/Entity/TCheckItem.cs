namespace GameFramework
{
    public class TCheckItem
    {
        public string szItemName;
        public bool boCanDrop;
        public bool boCanDeal;
        public bool boCanStorage;
        public bool boCanRepair;
        public bool boCanDropHint;
        public bool boCanOpenBoxsHint;
        public bool boCanNoDropItem;
        public bool boCanButchHint;
        public bool boCanHeroUse;

        // 禁止英雄使用
        public bool boPickUpItem;

        // 禁止捡起(除GM外)
        public bool boDieDropItems;
    }
}