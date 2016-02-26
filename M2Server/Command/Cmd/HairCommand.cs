using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("Hair", "改变头发", 10)]
    public class HairCommand : BaseCommond
    {
        [DefaultCommand]
        public void Hair(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            int nHair = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;
            if ((sHumanName == "") || (nHair < 0))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 类型值", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                m_PlayObject.m_btHair = (byte)nHair;
                m_PlayObject.FeatureChanged();
                PlayObject.SysMsg(sHumanName + " 的头发已改变。", TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}