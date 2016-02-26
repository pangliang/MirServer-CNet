using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 监听指定玩家私聊信息
    /// </summary>
    [GameCommand("ViewWhisper", "监听指定玩家私聊信息", 10)]
    public class ViewWhisperCommand : BaseCommond
    {
        [DefaultCommand]
        public void ViewWhisper(TPlayObject PlayObject,string[] @Params)
        {
            string sCharName = @Params.Length > 0 ? @Params[0] : "";
            string sParam2 = @Params.Length > 1 ? @Params[1] : "";
            if ((string.IsNullOrEmpty(sCharName)) && (sCharName[1] == '?'))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandViewWhisperHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sCharName);
            if (m_PlayObject != null)
            {
                if (m_PlayObject.m_GetWhisperHuman == PlayObject)
                {
                    m_PlayObject.m_GetWhisperHuman = null;
                    PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandViewWhisperMsg1, sCharName), TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    m_PlayObject.m_GetWhisperHuman = PlayObject;
                    PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandViewWhisperMsg2, sCharName), TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}