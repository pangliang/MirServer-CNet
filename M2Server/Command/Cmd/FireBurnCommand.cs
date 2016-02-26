using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("FireBurn", "", 10)]
    public class FireBurnCommand : BaseCommond
    {
        [DefaultCommand]
        public void FireBurn(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            int nInt = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            uint nTime = @Params.Length > 1 ? uint.Parse(@Params[1]) : 0;
            int nN = @Params.Length > 2 ? int.Parse(@Params[2]) : 0;

            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            if ((nInt == 0) || (nTime == 0) || (nN == 0))
            {
                PlayObject.SysMsg("命令格式: @" + M2Share.g_GameCommand.FIREBURN.sCmd + " nInt nTime nN", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TFireBurnEvent FireBurnEvent = new TFireBurnEvent(PlayObject, PlayObject.m_nCurrX, PlayObject.m_nCurrY, nInt, nTime, nN);
            M2Share.g_EventManager.AddEvent(FireBurnEvent);
        }
    }
}