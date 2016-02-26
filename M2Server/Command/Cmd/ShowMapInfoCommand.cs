using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("ShowMapInfo", "", 10)]
    public class ShowMapInfoCommand : BaseCommond
    {
        [DefaultCommand]
        public void ShowMapInfo(TPlayObject PlayObject,string[] @Params)
        {
            string sParam1 = @Params.Length > 0 ? @Params[0] : "";

            if (((sParam1 != "") && (sParam1[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMapInfoMsg, PlayObject.m_PEnvir.sMapName,
                PlayObject.m_PEnvir.sMapDesc), TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMapInfoSizeMsg, PlayObject.m_PEnvir.m_nWidth,
                PlayObject.m_PEnvir.m_nHeight), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}