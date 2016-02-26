using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 清除指定玩家PK值
    /// </summary>
    [GameCommand("FreePenalty", "清除指定玩家PK值", 10)]
    public class FreePenaltyCommand : BaseCommond
    {
        [DefaultCommand]
        public void FreePenalty(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";

            if (((sHumanName != "") && (sHumanName[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandFreePKHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            m_PlayObject.m_nPkPoint = 0;
            m_PlayObject.RefNameColor();
            m_PlayObject.SysMsg(GameMsgDef.g_sGameCommandFreePKHumanMsg, TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandFreePKMsg, sHumanName), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}