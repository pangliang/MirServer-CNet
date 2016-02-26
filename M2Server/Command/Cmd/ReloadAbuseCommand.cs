using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("ReloadAbuse", "无用", 10)]
    public class ReloadAbuseCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReloadAbuse(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sParam1 = @Params.Length > 1 ? @Params[1] : "";
            if (((sParam1 != "") && (sParam1[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
        }
    }
}