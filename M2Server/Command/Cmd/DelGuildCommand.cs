using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 删除指定行会名称
    /// </summary>
    [GameCommand("DelGuild", "删除指定行会名称", 10)]
    public class DelGuildCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelGuild(TPlayObject PlayObject,string[] @Params)
        {
            string sGuildName = @Params.Length > 0 ? @Params[0] : "";

            if (M2Share.nServerIndex != 0)
            {
                PlayObject.SysMsg("只能在主服务器上才可以使用此命令删除行会！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (sGuildName == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 行会名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (GuildManager.DelGuild(sGuildName))
            {
                // UserEngine.SendServerGroupMsg(SS_206, nServerIndex, sGuildName);
            }
            else
            {
                PlayObject.SysMsg("没找到" + sGuildName + "这个行会！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}