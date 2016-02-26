using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 重新加载机器人脚本
    /// </summary>
    [GameCommand("ReloadRobot", "重新加载机器人脚本", 10)]
    public class ReloadRobotCommand : BaseCommond
    {
        public void ReloadRobot(TPlayObject PlayObject,string[] @Params)
        {
            M2Share.RobotManage.ReLoadRobot();
            PlayObject.SysMsg("重新加载机器人配置完成...", TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}