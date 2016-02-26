using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整当前玩家等级
    /// </summary>
    [GameCommand("ChangeLevel", "调整当前玩家等级", 10)]
    public class ChangeLevelCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeLevel(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            string sParam1 = @Params.Length > 0 ? @Params[0] : "";
            int nOLevel;
            int nLevel;
            if (((sParam1 != "") && (sParam1[0] == '?')))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            nLevel = HUtil32.Str_ToInt(sParam1, 1);
            nOLevel = PlayObject.m_Abil.Level;
            PlayObject.m_Abil.Level = (ushort)HUtil32._MIN(M2Share.MAXUPLEVEL, nLevel);
            PlayObject.HasLevelUp(1);// 等级调整记录日志
            M2Share.AddGameDataLog("17" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString()
                + "\09" + PlayObject.m_sCharName + "\09" + (PlayObject.m_Abil.Level).ToString() + "\09" + "0" + "\09" + "=(" + (nLevel).ToString() + ")" + "\09" + "0");
            if (GameConfig.boShowMakeItemMsg)
            {
                M2Share.MainOutMessage(string.Format(GameMsgDef.g_sGameCommandLevelConsoleMsg, PlayObject.m_sCharName, nOLevel, PlayObject.m_Abil.Level));
            }
        }
    }
}