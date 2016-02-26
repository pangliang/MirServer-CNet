using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command
{
    /// <summary>
    /// 重新加载指定行会
    /// </summary>
    [GameCommand("EndGuild", "重新加载指定行会", 10)]
    public class ReloadGuildCommand : BaseCommond
    {
        public void ReloadGuild(TPlayObject PlayObject,string[] @Params)
        {
            string sParam1 = @Params.Length > 0 ? @Params[0] : "";
            if ((sParam1 == "") || ((sParam1 != "") && (sParam1[0] == '?')))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, Attributes.Name, GameMsgDef.g_sGameCommandReloadGuildHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (M2Share.nServerIndex != 0)
            {
                PlayObject.SysMsg(GameMsgDef.g_sGameCommandReloadGuildOnMasterserver, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TGUild Guild = GuildManager.FindGuild(sParam1);
            if (Guild == null)
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandReloadGuildNotFoundGuildMsg, sParam1), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            Guild.LoadGuild();
            PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandReloadGuildSuccessMsg, sParam1), TMsgColor.c_Red, TMsgType.t_Hint);
            UserEngine.SendServerGroupMsg(Grobal2.SS_207, M2Share.nServerIndex, sParam1);
        }
    }
}