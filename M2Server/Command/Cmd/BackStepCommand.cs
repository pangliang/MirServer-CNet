using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 推开范围内对象
    /// </summary>
    [GameCommand("BackStep", "推开范围内对象", 10)]
    public class BackStepCommand : BaseCommond
    {
        [DefaultCommand]
        public void BackStep(TPlayObject PlayObject,string[] @Params)
        {
            int nType = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            int nCount = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            nType = HUtil32._MIN(nType, 8);
            if (nType == 0)
            {
                PlayObject.CharPushed(PlayObject.GetBackDir(PlayObject.m_btDirection), nCount);
            }
            else
            {
                PlayObject.CharPushed((byte)HUtil32.Random(nType), nCount);
            }
        }
    }
}