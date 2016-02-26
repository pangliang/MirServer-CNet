using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整服务器最高上线人数
    /// </summary>
    [GameCommand("ChangeUserFull", "调整服务器最高上线人数", 10)]
    public class ChangeUserFullCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeUserFull(TPlayObject PlayObject,string[] @Params)
        {
            string sUserCount = @Params.Length > 0 ? @Params[0] : "";
            int nCount;
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            nCount = HUtil32.Str_ToInt(sUserCount, -1);
            if ((sUserCount == "") || (nCount < 1) || ((sUserCount != "") && (sUserCount[0] == '?')))
            {
                PlayObject.SysMsg("设置服务器最高上线人数。", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人数", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            M2Share.g_Config.nUserFull = nCount;
            PlayObject.SysMsg(String.Format("服务器上线人数限制: %d", nCount), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}