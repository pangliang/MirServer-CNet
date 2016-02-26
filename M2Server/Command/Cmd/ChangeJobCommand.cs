using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家职业
    /// </summary>
    [GameCommand("ChangeJob", "调整指定玩家职业", 10)]
    public class ChangeJobCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeJob(TPlayObject PlayObject,string[] @Params)
        {
            TPlayObject m_PlayObject;
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sJobName = @Params.Length > 1 ? @Params[1] : "";
            if ((sHumanName == "") || (sJobName == ""))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandChangeJobHelpMsg),
                    TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                if (string.Compare(sJobName, "Warr", true) == 0)
                {
                    m_PlayObject.m_btJob = 0;
                }
                if (string.Compare(sJobName, "Wizard", true) == 0)
                {
                    m_PlayObject.m_btJob = 1;
                }
                if (string.Compare(sJobName, "Taos", true) == 0)
                {
                    m_PlayObject.m_btJob = 2;
                }
                m_PlayObject.HasLevelUp(1);
                m_PlayObject.SysMsg(GameMsgDef.g_sGameCommandChangeJobHumanMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandChangeJobMsg, sHumanName), TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}