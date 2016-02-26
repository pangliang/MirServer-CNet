using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 取指定地图玩家数量
    /// </summary>
    [GameCommand("HumanCount", "取指定地图玩家数量", 10)]
    public class HumanCountCommand : BaseCommond
    {
        [DefaultCommand]
        public void HumanCount(TPlayObject PlayObject,string[] @Params)
        {
            string sMapName = @Params.Length > 0 ? @Params[0] : "";
            if ((sMapName == "") || ((sMapName != "") && (sMapName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandHumanCountHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMapName);
            if (Envir == null)
            {
                PlayObject.SysMsg(GameMsgDef.g_sGameCommandMobCountMapNotFound, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMobCountMonsterCount, UserEngine.GetMapHuman(sMapName)), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}