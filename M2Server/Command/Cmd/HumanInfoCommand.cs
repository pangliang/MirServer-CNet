using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 查看指定玩家信息
    /// </summary>
    [GameCommand("HumanInfo", "查看指定玩家信息", 10)]
    public class HumanInfoCommand : BaseCommond
    {
        [DefaultCommand]
        public void HumanInfo(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandInfoHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg(PlayObject.GeTBaseObjectInfo(), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}