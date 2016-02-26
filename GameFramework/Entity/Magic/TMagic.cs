using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// // 技能类
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TMagic //Size 76
    {
        /// <summary>
        /// 技能ID
        /// </summary>
        public UInt16 wMagicId;
        /// <summary>
        /// 技能名称占位符
        /// </summary>
        public byte MagicNameLen;
        /// <summary>
        /// 技能名称
        /// </summary>
        public fixed sbyte sMagicName[12];
        /// <summary>
        /// 动作效果
        /// </summary>
        public byte btEffectType;
        /// <summary>
        /// 魔法效果
        /// </summary>
        public byte btEffect;
        /// <summary>
        /// 未使用
        /// </summary>
        public byte bt11;
        /// <summary>
        /// 魔法消耗
        /// </summary>
        public UInt16 wSpell;
        /// <summary>
        /// 基本威力
        /// </summary>
        public UInt16 wPower;
        /// <summary>
        /// 技能等级
        /// </summary>
        public fixed byte TrainLevel[4];
        /// <summary>
        ///  未使用 20080531
        /// </summary>
        public UInt16 w02;
        /// <summary>
        /// 各技能等级最高修炼点
        /// </summary>
        public fixed int MaxTrain[4];
        /// <summary>
        /// 修炼等级
        /// </summary>
        public byte btTrainLv;
        /// <summary>
        /// 职业 0-战 1-法 2-道 3-刺客
        /// </summary>
        public byte btJob;
        /// <summary>
        ///  未使用
        /// </summary>
        public UInt16 wMagicIdx;
        /// <summary>
        /// 技能延时
        /// </summary>
        public uint dwDelayTime;
        /// <summary>
        /// 升级魔法
        /// </summary>
        public byte btDefSpell;
        /// <summary>
        /// 升级威力
        /// </summary>
        public byte btDefPower;
        /// <summary>
        /// 最大威力
        /// </summary>
        public UInt16 wMaxPower;
        /// <summary>
        /// 升级最大威力
        /// </summary>
        public byte btDefMaxPower;
        /// <summary>
        /// 技能描述占位符
        /// </summary>
        public byte DescrLen;
        /// <summary>
        /// 技能描述
        /// </summary>
        public fixed sbyte sDescr[18];
    }
}