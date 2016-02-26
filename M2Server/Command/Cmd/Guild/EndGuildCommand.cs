using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command.Cmd
{
    /// <summary>
    /// 退出行会
    /// </summary>
    [GameCommand("EndGuild", "退出行会", 0)]
    public class EndGuildCommand : BaseCommond
    {
        [DefaultCommand]
        public void EndGuild(TPlayObject PlayObject,string[] @Params)
        {
            if ((PlayObject.m_MyGuild != null))
            {
                if ((PlayObject.m_nGuildRankNo > 1))
                {
                    if (PlayObject.m_MyGuild.IsMember(PlayObject.m_sCharName) && PlayObject.m_MyGuild.DelMember(PlayObject.m_sCharName))
                    {
                        UserEngine.SendServerGroupMsg(Grobal2.SS_207, M2Share.nServerIndex, PlayObject.m_MyGuild.sGuildName);
                        PlayObject.m_MyGuild = null;
                        PlayObject.RefRankInfo(0, "");
                        PlayObject.RefShowName();
                        PlayObject.SysMsg(string.Format("您已离开{0}行会。", PlayObject.m_MyGuild.sGuildName), TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("行会掌门人不能这样退出行会！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg("您都没加入行会！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}
