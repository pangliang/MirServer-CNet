using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server.Command
{
    /// <summary>
    /// 查看行会战的得分数
    /// </summary>
    [GameCommand("ContestPoint", "查看行会战的得分数", 10)]
    public class ContestPointCommand : BaseCommond
    {
        [DefaultCommand]
        public void ContestPoint(TPlayObject PlayObject,string[] @Params)
        {
            string sGuildName = @Params.Length > 0 ? @Params[0] : "";
            if ((sGuildName == "") || ((sGuildName != "") && (sGuildName[0] == '?')))
            {
                PlayObject.SysMsg("查看行会战的得分数。", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(String.Format("命令格式: @{0} 行会名称", this.Attributes.Name), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TGUild Guild = GuildManager.FindGuild(sGuildName);
            if (Guild != null)
            {
                PlayObject.SysMsg(String.Format("{0} 的得分为: {1}", sGuildName, Guild.nContestPoint), TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(String.Format("行会: {0} 不存在！！！", sGuildName), TMsgColor.c_Green, TMsgType.t_Hint);
            }

        }
    }
}