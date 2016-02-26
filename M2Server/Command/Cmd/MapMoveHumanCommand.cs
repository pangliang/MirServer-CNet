using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 将指定地图所有玩家随机移动
    /// </summary>
    [GameCommand("MapMoveHuman", "将指定地图所有玩家随机移动", 10)]
    public class MapMoveHumanCommand : BaseCommond
    {
        [DefaultCommand]
        public void MapMoveHuman(TPlayObject PlayObject,string[] @Params)
        {
            string sSrcMap = @Params.Length > 0 ? @Params[0] : "";
            string sDenMap = @Params.Length > 1 ? @Params[1] : "";
            List<TPlayObject> HumanList;
            TPlayObject MoveHuman;
            if ((sDenMap == "") || (sSrcMap == "") || ((sSrcMap != "") && (sSrcMap[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandMapMoveHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TEnvirnoment SrcEnvir = M2Share.g_MapManager.FindMap(sSrcMap);
            TEnvirnoment DenEnvir = M2Share.g_MapManager.FindMap(sDenMap);
            if ((SrcEnvir == null))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMapMoveMapNotFound, sSrcMap), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((DenEnvir == null))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMapMoveMapNotFound, sDenMap), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            HumanList = new List<TPlayObject>();
            UserEngine.GetMapRageHuman(SrcEnvir, SrcEnvir.m_nWidth / 2, SrcEnvir.m_nHeight / 2, 1000, HumanList);
            for (int I = 0; I < HumanList.Count; I++)
            {
                MoveHuman = HumanList[I];
                if (MoveHuman != PlayObject)
                {
                    MoveHuman.MapRandomMove(sDenMap, 0);
                }
            }
            HUtil32.Dispose(HumanList);
        }
    }
}