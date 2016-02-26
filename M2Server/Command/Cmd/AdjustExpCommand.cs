using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 暂时不清楚干啥的
    /// </summary>
    [GameCommand("AdjustExp", "", 10)]
    public class AdjustExpCommand : BaseCommond
    {
        [DefaultCommand]
        public void AdjustExp(TPlayObject PlayObject,string[] @Params)
        {
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
        }
    }
}