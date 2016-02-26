using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 剔除指定玩家下线
    /// </summary>
    [GameCommand("KickHuman", "剔除指定玩家下线", 10)]
    public class KickHumanCommand : BaseCommond
    {
        [DefaultCommand]
        public void KickHuman(TPlayObject PlayObject,string[] @Params)
        {
            string sHumName = @Params.Length > 0 ? @Params[0] : "";
            if (sHumName == "")
            {
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumName);
            if (m_PlayObject != null)
            {
                m_PlayObject.m_boKickFlag = true;
                m_PlayObject.m_boEmergencyClose = true;
                m_PlayObject.m_boPlayOffLine = false;
                m_PlayObject.m_boNotOnlineAddExp = false;
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}