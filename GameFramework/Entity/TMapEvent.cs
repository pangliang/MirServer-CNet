namespace GameFramework
{
    public class TMapEvent
    {
        public string m_sMapName;// 地图
        public int m_nCurrX;// X
        public int m_nCurrY;// Y
        public int m_nRange;// 范围
        public TQuestUnitStatus m_MapFlag;
        public int m_nRandomCount;// 机率(0 - 999999) 0 的机率为100% ; 数字越大，机率越低
        public TMapCondition m_Condition;// 触发条件
        public TStartScript m_StartScript;
    }
}