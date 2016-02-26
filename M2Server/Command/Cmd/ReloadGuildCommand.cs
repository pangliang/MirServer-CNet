using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 重新读取行会
    /// </summary>
    [GameCommand("ReloadGuild", "重新读取行会", 10)]
    public class ReloadGuildCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReloadGuild(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sParam1 = @Params.Length > 1 ? @Params[1] : "";
            if ((sParam1 == "") || ((sParam1 != "") && (sParam1[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandReloadGuildHelpMsg),
                    TMsgColor.c_Red, TMsgType.t_Hint);
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
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandReloadGuildNotFoundGuildMsg, sParam1), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            Guild.LoadGuild();
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandReloadGuildSuccessMsg, sParam1), TMsgColor.c_Red, TMsgType.t_Hint);
            // UserEngine.SendServerGroupMsg(SS_207, nServerIndex, sParam1);
        }
    }
}