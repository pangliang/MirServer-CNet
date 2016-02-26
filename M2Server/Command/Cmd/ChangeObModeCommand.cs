using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 进入/退出隐身模式(进入模式后别人看不到自己)(支持权限分配)
    /// </summary>
    [GameCommand("ChangeObMode", "进入/退出隐身模式(进入模式后别人看不到自己)(支持权限分配)", 10)]
    public class ChangeObModeCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeObMode(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sParam1 = @Params.Length > 1 ? @Params[1] : "";
            bool boFlag = @Params.Length > 2 ? bool.Parse(@Params[2]) : false;

            if (((sParam1 != "") && (sParam1[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (boFlag)
            {
                PlayObject.SendRefMsg(Grobal2.RM_DISAPPEAR, 0, 0, 0, 0, "");// 01/21 强行发送刷新数据到客户端，解决GM登录隐身有影子问题
            }
            PlayObject.m_boObMode = boFlag;
            if (PlayObject.m_boObMode)
            {
                PlayObject.SysMsg(GameMsgDef.sObserverMode, TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(GameMsgDef.g_sReleaseObserverMode, TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}