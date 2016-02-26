using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 剔除面对面玩家下线
    /// </summary>
    [GameCommand("Kill", "剔除面对面玩家下线", 10)]
    public class KillCommand : BaseCommond
    {
        [DefaultCommand]
        public void Kill(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            TBaseObject BaseObject;
            if (sHumanName != "")
            {
                BaseObject = UserEngine.GetPlayObject(sHumanName);
                if (BaseObject == null)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
            }
            else
            {
                BaseObject = PlayObject.GetPoseCreate();
                if (BaseObject == null)
                {
                    PlayObject.SysMsg("命令使用方法不正确，必须与角色面对面站好！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
            }
            BaseObject.Die();
        }
    }
}