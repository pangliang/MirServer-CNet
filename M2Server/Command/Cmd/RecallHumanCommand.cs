using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 将指定人物召唤到身边(支持权限分配)
    /// </summary>
    [GameCommand("RecallHuman", "将指定人物召唤到身边(支持权限分配)", 10)]
    public class RecallHumanCommand : BaseCommond
    {
        [DefaultCommand]
        public void RecallHuman(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandRecallHelpMsg),
                    TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.RecallHuman(sHumanName);
        }
    }
}