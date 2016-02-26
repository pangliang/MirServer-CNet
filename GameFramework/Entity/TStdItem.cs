// ================================================
// TUserItem.cs, 物品基本属性结构体
// Copyright (C) 2012 Daomi
// ================================================
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 物品基本属性结构体
    /// Size : 64
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TStdItem
    {
        public byte NameLen;
        /// <summary>
        /// 物品名称
        /// </summary>
        public fixed sbyte Name[14];
        /// <summary>
        /// 物品分类 
        /// 0/1/2/3：药 
        /// 5/6:武器
        /// 10/11：盔甲
        /// 15：头盔
        /// 22/23：戒指
        /// 24/26：手镯
        /// 19/20/21：项链
        /// 43:矿石
        /// </summary>
        public byte StdMode;
        public byte Shape;// 装配外观
        /// <summary>
        /// 重量
        /// </summary>
        public byte Weight;
        public byte AniCount;
        public sbyte Source;// 源动力
        public byte Reserved;// 保留
        public byte NeedIdentify;// 需要记录日志
        /// <summary>
        /// 外观，即Items.WIL中的图片索引
        /// </summary>
        public UInt16 Looks;
        /// <summary>
        /// 最大持久
        /// </summary>
        public UInt16 DuraMax;
        public UInt16 Reserved1;// 发光属性
        public int AC;// 0x1A
        public int MAC;// 0x1C
        public int DC;// 0x1E
        public int MC;// 0x20
        public int SC;// 0x22
        public int Need;// 0x24
        public int NeedLevel;// 0x25
        public int Price;// 价格
        public int Stock;

        public override string ToString()
        {
            fixed (sbyte* pb = this.Name)
            {
                return HUtil32.SBytePtrToString(pb, 0, this.NameLen);
            }
        }

        /// <summary>
        /// 构造道术值
        /// </summary>
        /// <param name="StdItem"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static int MakeSC(double Sc, double Sc2, int nItemsPowerRate)
        {
            return HUtil32.MakeLong(
                      (UInt16)HUtil32.Round(Sc * GetActualScMcDcPowerRate(nItemsPowerRate))
                    , (UInt16)HUtil32.Round(Sc2 * GetActualScMcDcPowerRate(nItemsPowerRate))
                    );
        }

        /// <summary>
        /// 构造魔法攻击值
        /// </summary>
        /// <param name="StdItem"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static int MakeMC(double Mc, double Mc2, int nItemsPowerRate)
        {
            return HUtil32.MakeLong(
                  (UInt16)HUtil32.Round(Mc * GetActualScMcDcPowerRate(nItemsPowerRate))
                , (UInt16)HUtil32.Round(Mc2 * GetActualScMcDcPowerRate(nItemsPowerRate))
                );
        }

        /// <summary>
        /// 构造物理攻击值
        /// </summary>
        /// <param name="StdItem"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static int MakeDC(double Dc, double Dc2, int nItemsPowerRate)
        {
            return HUtil32.MakeLong(
                  (UInt16)HUtil32.Round(Dc * GetActualScMcDcPowerRate(nItemsPowerRate))
                , (UInt16)HUtil32.Round(Dc2 * GetActualScMcDcPowerRate(nItemsPowerRate)));
        }

        /// <summary>
        /// 构造魔法防御值
        /// </summary>
        /// <param name="StdItem"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static int MakeMAC(double Mac, double Mac2, int nItemsACPowerRate)
        {
            return HUtil32.MakeLong(
                  (UInt16)HUtil32.Round(Mac * GetActualAcMacPowerRate(nItemsACPowerRate))
                , (UInt16)HUtil32.Round(Mac2 * GetActualAcMacPowerRate(nItemsACPowerRate))
                );
        }

        /// <summary>
        /// 构造物理防御值
        /// </summary>
        /// <param name="StdItem"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static int MakeAC(int Ac, int Ac2, int nItemsACPowerRate)
        {
            return HUtil32.MakeLong(
                  (UInt16)HUtil32.Round(Ac * GetActualAcMacPowerRate(nItemsACPowerRate))
                , (UInt16)HUtil32.Round(Ac2 * GetActualAcMacPowerRate(nItemsACPowerRate))
                );
        }

        private static int GetActualAcMacPowerRate(int nItemsACPowerRate)
        {
            return nItemsACPowerRate / 10;
        }

        private static int GetActualScMcDcPowerRate(int nItemsPowerRate)
        {
            return nItemsPowerRate / 10;
        }
    }
}