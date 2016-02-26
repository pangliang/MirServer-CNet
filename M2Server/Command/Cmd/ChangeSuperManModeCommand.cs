using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整当前玩家进入无敌模式
    /// </summary>
    [GameCommand("ChangeSuperManMode", "调整当前玩家进入无敌模式", 10)]
    public class ChangeSuperManModeCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeSuperManMode(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sParam1 = @Params.Length > 1 ? @Params[1] : "";
            bool boFlag = @Params.Length > 2 ? bool.Parse(@Params[2]) : false;

            if ((PlayObject.m_btPermission < nPermission))
            {
                PlayObject.SysMsg(GameMsgDef.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (((sParam1 != "") && (sParam1[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.m_boSuperMan = boFlag;
            if (PlayObject.m_boSuperMan)
            {
                PlayObject.SysMsg(GameMsgDef.sSupermanMode, TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(GameMsgDef.sReleaseSupermanMode, TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}