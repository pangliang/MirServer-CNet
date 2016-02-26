using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 查看指定玩家所在IP地址
    /// </summary>
    [GameCommand("HumanLocal", "查看指定玩家所在IP地址", 10)]
    public class HumanLocalCommand : BaseCommond
    {
        [DefaultCommand]
        public void HumanLocal(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string m_sIPLocal = "";
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandHumanLocalHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }

            // GetIPLocal(PlayObject.m_sIPaddr)
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandHumanLocalMsg, sHumanName, m_sIPLocal), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}