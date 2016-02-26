using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("DisableSendMsgList", "", 10)]
    public class DisableSendMsgListCommand : BaseCommond
    {
        [DefaultCommand]
        public void DisableSendMsgList(TPlayObject PlayObject,string[] @Params)
        {
            if (M2Share.g_DisableSendMsgList.Count <= 0)
            {
                PlayObject.SysMsg("禁言列表为空！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg("禁言列表:", TMsgColor.c_Blue, TMsgType.t_Hint);
            for (int I = 0; I < M2Share.g_DisableSendMsgList.Count; I++)
            {
                PlayObject.SysMsg(M2Share.g_DisableSendMsgList[I], TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}