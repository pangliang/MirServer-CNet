using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("ReloadManage", "重新加载脚本", 10)]
    public class ReloadManageCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReloadManage(TPlayObject PlayObject,string[] @Params)
        {
            string sParam = @Params.Length > 0 ? @Params[0] : "";
            if (((sParam != "") && (sParam[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (sParam == "")
            {
                if (M2Share.g_ManageNPC != null)
                {
                    M2Share.g_ManageNPC.ClearScript();
                    M2Share.g_ManageNPC.LoadNpcScript();
                    PlayObject.SysMsg("重新加载登录脚本完成...", TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    PlayObject.SysMsg("重新加载登录脚本失败...", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            else
            {
                if (M2Share.g_FunctionNPC != null)
                {
                    M2Share.g_FunctionNPC.ClearScript();
                    M2Share.g_FunctionNPC.LoadNpcScript();
                    PlayObject.SysMsg("重新加载功能脚本完成...", TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    PlayObject.SysMsg("重新加载功能脚本失败...", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
        }
    }
}