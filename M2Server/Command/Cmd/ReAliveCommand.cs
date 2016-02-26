using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 复活指定玩家
    /// </summary>
    [GameCommand("ReAlive", "复活指定玩家", 10)]
    public class ReAliveCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReAlive(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            if (sHumanName == "")
            {
                PlayObject.SysMsg("命令格式不正确", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            m_PlayObject.ReAlive();
            m_PlayObject.m_WAbil.HP = m_PlayObject.m_WAbil.MaxHP;
            m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandReAliveMsg, sHumanName), TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(sHumanName + " 已获重生。", TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}