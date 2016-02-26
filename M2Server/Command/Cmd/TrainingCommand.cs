using GameFramework.Command;

namespace M2Server
{
    [GameCommand("Training", "", 10)]
    public class TrainingCommand : BaseCommond
    {
        [DefaultCommand]
        public void Training(TPlayObject PlayObject,string[] @Params)
        {
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
        }
    }
}