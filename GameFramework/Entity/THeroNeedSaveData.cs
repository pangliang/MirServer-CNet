namespace GameFramework
{
    /// <summary>
    /// 双英雄需要保存的数据
    /// </summary>
    public class THeroNeedSaveData
    {
        public TRecordHeader Header;

        // 文件头
        public byte btJob;

        public TUserItem[] HumItems;

        // 9格装备 衣服  武器  蜡烛 头盔 项链 手镯 手镯 戒指 戒指
        public TUserItem[] BagItems;

        // 包裹装备
        public THumMagic[] HumMagics;

        // 魔法
        // StorageItems: TStorageItems; //仓库物品
        public ushort[] wStatusTimeArr;

        public TUserItem[] HumAddItems;

        // 新增4格 护身符 腰带 鞋子 宝石
        public THumMagic[] HumNGMagics;

        // 内功技能 20081001
        public THumMagic[] HumBatterMagics;

        // 连击技能
        public ushort[] BatterMagicOrder;
    }
}