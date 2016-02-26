using GameFramework.Command;

namespace M2Server
{
    [GameCommand("TestFire", "", 10)]
    public class TestFireCommand : BaseCommond
    {
        [DefaultCommand]
        public void TestFire(TPlayObject PlayObject,string[] @Params)
        {
            int nRange = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            int nType = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;
            uint nTime = @Params.Length > 2 ? uint.Parse(@Params[2]) : 0;
            int nPoint = @Params.Length > 3 ? int.Parse(@Params[3]) : 0;

            TFireBurnEvent FireBurnEvent;
            int nMinX = PlayObject.m_nCurrX - nRange;
            int nMaxX = PlayObject.m_nCurrX + nRange;
            int nMinY = PlayObject.m_nCurrY - nRange;
            int nMaxY = PlayObject.m_nCurrY + nRange;
            for (int nX = nMinX; nX <= nMaxX; nX++)
            {
                for (int nY = nMinY; nY <= nMaxY; nY++)
                {
                    if (((nX < nMaxX) && (nY == nMinY)) || ((nY < nMaxY) && (nX == nMinX)) || (nX == nMaxX) || (nY == nMaxY))
                    {
                        FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY, nType, nTime * 1000, nPoint);
                        M2Share.g_EventManager.AddEvent(FireBurnEvent);
                    }
                }
            }
        }
    }
}