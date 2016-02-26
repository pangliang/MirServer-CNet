using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家经验值
    /// </summary>
    [GameCommand("AdjuestExp", "调整指定玩家经验值", 10)]
    public class AdjuestExpCommand : BaseCommond
    {
        [DefaultCommand]
        public void AdjuestExp(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sExp = @Params.Length > 1 ? @Params[1] : "";
            uint dwExp = 0;
            uint dwOExp = 0;
            if ((sHumanName == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 经验值", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            dwExp = (uint)HUtil32.Str_ToInt(sExp, 0);
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                dwOExp = PlayObject.m_Abil.Exp;
                m_PlayObject.m_Abil.Exp = dwExp;
                m_PlayObject.HasLevelUp(m_PlayObject.m_Abil.Level - 1);
                PlayObject.SysMsg(sHumanName + " 经验调整完成。", TMsgColor.c_Green, TMsgType.t_Hint);
                if (M2Share.g_Config.boShowMakeItemMsg)
                {
                    M2Share.MainOutMessage("[经验调整] " + PlayObject.m_sCharName + '(' + m_PlayObject.m_sCharName + ' ' + dwOExp + " -> " + m_PlayObject.m_Abil.Exp + ')');
                }
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}