namespace GameFramework
{
    /// <summary>
    /// 套装数据结构
    /// </summary>
    public class TSuitItem
    {
        public byte ItemCount;

        // 套装物品数量
        public string Note;

        // 说明
        public string Name;

        // 物品名称
        public int MaxHP;

        // HP上限   //21亿血
        public int MaxMP;

        // MP上限   //21亿血
        public ushort DC;

        // 攻击力
        public ushort MaxDC;

        public ushort MC;

        // 魔法
        public ushort MaxMC;

        public ushort SC;

        // 道术
        public ushort MaxSC;

        public int AC;

        // 防御
        public int MaxAC;

        public ushort MAC;

        // 魔防
        public ushort MaxMAC;

        public byte HitPoint;

        // 准确度
        public byte SpeedPoint;

        // 敏捷度
        public sbyte HealthRecover;

        // 体力恢复
        public sbyte SpellRecover;

        // 魔法恢复
        public int RiskRate;

        // 爆率机率
        public byte btReserved;

        // 吸血(虹吸)
        public byte btReserved1;

        // 保留
        public byte btReserved2;

        // 保留
        public byte btReserved3;

        // 保留
        public int nEXPRATE;

        // 经验倍数
        public byte nPowerRate;

        // 攻击倍数
        public byte nMagicRate;

        // 魔法倍数
        public byte nSCRate;

        // 道术倍数
        public byte nACRate;

        // 防御倍数
        public byte nMACRate;

        // 魔御倍数
        public sbyte nAntiMagic;

        // 魔法躲避
        public byte nAntiPoison;

        // 毒物躲避
        public sbyte nPoisonRecover;

        // 中毒恢复
        public bool boTeleport;

        // 传送  20080824
        public bool boParalysis;

        // 麻痹
        public bool boRevival;

        // 复活
        public bool boMagicShield;

        // 护身
        public bool boUnParalysis;
    }
}