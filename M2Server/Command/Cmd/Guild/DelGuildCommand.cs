using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command
{
    /// <summary>
    /// 删除指定行会
    /// </summary>
    [GameCommand("DelGuild", "删除指定行会", 10)]
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
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + base.Attributes.Name + " 行会名称", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (GuildManager.DelGuild(sGuildName))
            {
                UserEngine.SendServerGroupMsg(Grobal2.SS_206, M2Share.nServerIndex, sGuildName);
            }
            else
            {
                PlayObject.SysMsg("没找到" + sGuildName + "这个行会！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}
