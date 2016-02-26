using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 基本属性结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TAbility // Size 68
    {
        /// <summary>
        /// 等级
        /// </summary>
        public UInt16 Level;

        /// <summary>
        /// 防御
        /// </summary>
        public int AC;

        /// <summary>
        /// 魔防
        /// </summary>
        public int MAC;

        /// <summary>
        /// 攻击力
        /// </summary>
        public int DC;

        /// <summary>
        /// 魔法
        /// </summary>
        public int MC;

        /// <summary>
        /// 道术
        /// </summary>
        public int SC;

        /// <summary>
        /// HP
        /// </summary>
        public int HP;

        /// <summary>
        /// MP
        /// </summary>
        public int MP;

        /// <summary>
        /// 最大HP
        /// </summary>
        public int MaxHP;

        /// <summary>
        /// 最大MP
        /// </summary>
        public int MaxMP;

        /// <summary>
        /// 经验值
        /// </summary>
        public UInt32 Exp;

        /// <summary>
        /// 最大经验值
        /// </summary>
        public UInt32 MaxExp;

        /// <summary>
        /// 负重
        /// </summary>
        public UInt16 Weight;

        /// <summary>
        /// 最大负重
        /// </summary>
        public UInt16 MaxWeight;

        /// <summary>
        /// 腕力
        /// </summary>
        public UInt16 WearWeight;

        /// <summary>
        /// 最大腕力
        /// </summary>
        public UInt16 MaxWearWeight;

        public UInt16 HandWeight;
        public UInt16 MaxHandWeight;
        public UInt16 Alcohol;// 酒量
        public UInt16 MaxAlcohol;// 酒量上限
        public UInt16 WineDrinkValue;// 醉酒度
        public UInt16 MedicineValue;// 当前药力值
        public UInt16 MaxMedicineValue;
    }
}