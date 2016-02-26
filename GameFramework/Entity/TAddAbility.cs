using System;
using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 人物属性
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TAddAbility//Size 40
    {
        public int wHP;// 21亿血
        public int wMP;// 21亿魔法
        public UInt16 wHitPoint;
        public UInt16 wSpeedPoint;
        public int wAC;// 防御
        public int wMAC;// 魔御
        public int wDC;
        public int wMC;
        public int wSC;
        public byte bt1DF;// 神圣
        public byte bt035;
        public UInt16 wAntiPoison;
        public UInt16 wPoisonRecover;
        public UInt16 wHealthRecover;
        public UInt16 wSpellRecover;
        public UInt16 wAntiMagic;
        public byte btLuck;// 幸运
        public byte btUnLuck;// 诅咒
        public int nHitSpeed;
        public byte btWeaponStrong;// 强度
        public UInt16 wWearWeight;
    }
}