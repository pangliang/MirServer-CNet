using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 宝箱数据结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TBoxsInfo
    {
        public int SBoxsID;// 箱子文件
        public int nItemNum;// 物品数量
        public int nItemType;// 物品类型
        public bool OpenBox;// 是否开启多次(1为开启)
        public int nGold;// 起始金币
        public uint nGameGold;// 起始元宝(游戏币)
        public int nIncGold;// 累增金币
        public int nIncGameGold;// 累增元宝(游戏币)
        public int nEffectiveGold;// 有效金币数
        public uint nEffectiveGameGold;// 有效元宝(游戏币)数
        public int nUses;// 最多允许使用转盘次数
        public TClientItem* StdItem;
    }
}