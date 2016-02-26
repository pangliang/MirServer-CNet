using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家能量值
    /// </summary>
    [GameCommand("Hunger", "调整指定玩家能量值", 10)]
    public class HungerCommand : BaseCommond
    {
        [DefaultCommand]
        public void Hunger(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            int nHungerPoint = @Params.Length > 1 ? Convert.ToInt32(@Params[1]) : -1;
            TPlayObject m_PlayObject;
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            if ((sHumanName == "") || (nHungerPoint < 0))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 能量值", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                m_PlayObject.m_nHungerStatus = nHungerPoint;
                m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_MYSTATUS, 0, 0, 0, 0, "");
                m_PlayObject.RefMyStatus();
                PlayObject.SysMsg(sHumanName + " 的能量值已改变。", TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(sHumanName + "没有在线！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}