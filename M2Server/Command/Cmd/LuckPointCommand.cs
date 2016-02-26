using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 查看指定玩家幸运点
    /// </summary>
    [GameCommand("LuckPoint", "查看指定玩家幸运点", 10)]
    public class LuckPointCommand : BaseCommond
    {
        [DefaultCommand]
        public void LuckPoint(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? Convert.ToInt32(@Params[0]) : 0;
            string sHumanName = @Params.Length > 1 ? @Params[1] : "";
            string sCtr = @Params.Length > 2 ? @Params[2] : "";
            string sPoint = @Params.Length > 3 ? @Params[3] : "";
            if ((PlayObject.m_btPermission < nPermission))
            {
                PlayObject.SysMsg(GameMsgDef.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandLuckPointHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (sCtr == "")
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandLuckPointMsg, sHumanName, m_PlayObject.m_nBodyLuckLevel, m_PlayObject.m_dBodyLuck,
                    m_PlayObject.m_nLuck), TMsgColor.c_Green, TMsgType.t_Hint);
                return;
            }
            int nPoint = HUtil32.Str_ToInt(sPoint, 0); // by john 2013.4.24
            char cMethod = sCtr[0];
            switch (cMethod)
            {
                case '=':
                    PlayObject.m_nLuck = nPoint;
                    break;
                case '-':
                    if (PlayObject.m_nLuck >= nPoint)
                    {
                        PlayObject.m_nLuck -= nPoint;
                    }
                    else
                    {
                        PlayObject.m_nLuck = 0;
                    }
                    break;
                case '+':
                    PlayObject.m_nLuck += nPoint;
                    break;
            }
        }
    }
}