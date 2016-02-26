using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 拒绝发言
    /// </summary>
    [GameCommand("PrvMsg", "拒绝发言", 10)]
    public class PrvMsgCommand : BaseCommond
    {
        [DefaultCommand]
        public void PrvMsg(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sHumanName = @Params.Length > 1 ? @Params[1] : "";
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandPrvMsgHelpMsg),
                    TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            for (int I = PlayObject.m_BlockWhisperList.Count - 1; I >= 0; I--)
            {
                if (PlayObject.m_BlockWhisperList.Count <= 0)
                {
                    break;
                }
                if ((PlayObject.m_BlockWhisperList[I]).ToLower().CompareTo((sHumanName).ToLower()) == 0)
                {
                    PlayObject.m_BlockWhisperList.RemoveAt(I);
                    PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandPrvMsgUnLimitMsg, sHumanName), TMsgColor.c_Green, TMsgType.t_Hint);
                    return;
                }
            }
            PlayObject.m_BlockWhisperList.Add(sHumanName);
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandPrvMsgLimitMsg, sHumanName), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}