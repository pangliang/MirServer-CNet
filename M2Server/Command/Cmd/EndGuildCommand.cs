using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 退出行会
    /// </summary>
    [GameCommand("EndGuild", "退出行会", 10)]
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
                        // UserEngine.SendServerGroupMsg(SS_207, nServerIndex, TGUild(m_MyGuild).sGuildName);
                        PlayObject.m_MyGuild = null;
                        PlayObject.RefRankInfo(0, "");
                        PlayObject.RefShowName();
                        PlayObject.SysMsg("你已经退出行会。", TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("行会掌门人不能这样退出行会！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg("你都没加入行会！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}