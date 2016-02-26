using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家权限
    /// </summary>
    [GameCommand("SetPermission", "调整指定玩家权限", 10)]
    public class SetPermissionCommand : BaseCommond
    {
        [DefaultCommand]
        public void SetPermission(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sPermission = @Params.Length > 1 ? @Params[1] : "";
            int nPerission = HUtil32.Str_ToInt(sPermission, 0);
            const string sOutFormatMsg = "[权限调整] {0} [{1} {2} -> {3}]";
            if ((sHumanName == "") || !(nPerission >= 0 && nPerission <= 10))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 权限等级(0 - 10)", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (M2Share.g_Config.boShowMakeItemMsg)
            {
                M2Share.MainOutMessage(String.Format(sOutFormatMsg, PlayObject.m_sCharName, m_PlayObject.m_sCharName, m_PlayObject.m_btPermission, nPerission));
            }
            m_PlayObject.m_btPermission = (byte)nPerission;
            PlayObject.SysMsg(sHumanName + " 当前权限为: " + m_PlayObject.m_btPermission, TMsgColor.c_Red, TMsgType.t_Hint);
        }
    }
}