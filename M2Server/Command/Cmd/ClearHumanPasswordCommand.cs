using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 清楚指定玩家仓库密码
    /// </summary>
    [GameCommand("ClearHumanPassword", "清楚指定玩家仓库密码", 10)]
    public class ClearHumanPasswordCommand : BaseCommond
    {
        [DefaultCommand]
        public void ClearHumanPassword(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? Convert.ToInt32(@Params[0]) : 0;
            string sHumanName = @Params.Length > 1 ? @Params[1] : "";
            if ((PlayObject.m_btPermission < nPermission))
            {
                return;
            }
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[0] == '?')))
            {
                PlayObject.SysMsg("清除玩家的仓库密码！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(String.Format("命令格式: @{0} 人物名称", this.Attributes.Name), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (PlayObject == null)
            {
                return;
            }
            PlayObject.m_boPasswordLocked = false;
            PlayObject.m_boUnLockStoragePwd = false;
            PlayObject.m_sStoragePwd = "";
            PlayObject.SysMsg("你的保护密码已被清除！！！", TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(String.Format("{0}的保护密码已被清除！！！", sHumanName), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}