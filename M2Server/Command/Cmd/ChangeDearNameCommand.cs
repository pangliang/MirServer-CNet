using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家配偶名称
    /// </summary>
    [GameCommand("ChangeDearName", "调整指定玩家配偶名称", 10)]
    public class ChangeDearNameCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeDearName(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sDearName = @Params.Length > 1 ? @Params[1] : "";
            if ((sHumanName == "") || (sDearName == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 配偶名称(如果为 无 则清除)", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                if ((sDearName).ToLower().CompareTo(("无").ToLower()) == 0)
                {
                    m_PlayObject.m_sDearName = "";
                    m_PlayObject.RefShowName();
                    PlayObject.SysMsg(sHumanName + " 的配偶名清除成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    m_PlayObject.m_sDearName = sDearName;
                    m_PlayObject.RefShowName();
                    PlayObject.SysMsg(sHumanName + " 的配偶名更改成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}