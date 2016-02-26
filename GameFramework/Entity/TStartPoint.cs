namespace GameFramework
{
    public class TStartPoint
    {
        // 安全区回城点 增加光环效果
        public string m_sMapName;

        public int m_nCurrX;

        // 座标X(4字节)
        public int m_nCurrY;

        // 座标Y(4字节)
        public bool m_boNotAllowSay;

        public int m_nRange;
        public int m_nType;

        // 类型
        public int m_nPkZone;

        public int m_nPkFire;
        public byte m_btShape;
    }
}