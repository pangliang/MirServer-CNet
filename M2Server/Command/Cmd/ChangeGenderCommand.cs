using GameFramework;
using GameFramework.Command;

namespace M2Server.Command
{
    /// <summary>
    /// 调整指定玩家性别
    /// </summary>
    [GameCommand("ChangeGender", "调整指定玩家性别", 10)]
    public class ChangeGenderCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeGender(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sSex = @Params.Length > 1 ? @Params[1] : "";
            int nSex = -1;
            if ((sSex == "Man") || (sSex == "男") || (sSex == "0"))
            {
                nSex = 0;
            }
            if ((sSex == "WoMan") || (sSex == "女") || (sSex == "1"))
            {
                nSex = 1;
            }
            if ((sHumanName == "") || (nSex == -1))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 性别(男、女)", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                if (m_PlayObject.m_btGender != nSex)
                {
                    m_PlayObject.m_btGender = (byte)nSex;
                    m_PlayObject.FeatureChanged();
                    PlayObject.SysMsg(m_PlayObject.m_sCharName + " 的性别已改变。", TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    PlayObject.SysMsg(m_PlayObject.m_sCharName + " 的性别未改变！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg(sHumanName + "没有在线！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}