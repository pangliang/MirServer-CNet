using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 移动到某地图XY坐标处
    /// </summary>
    [GameCommand("PositionMove", "移动到某地图XY坐标处", 10)]
    public class PositionMoveCommand : BaseCommond
    {
        [DefaultCommand]
        public void PositionMove(TPlayObject PlayObject,string[] @Params)
        {
            try
            {
                string sMapName = @Params.Length > 0 ? @Params[0] : "";
                string sX = @Params.Length > 1 ? @Params[1] : "";
                string sY = @Params.Length > 2 ? @Params[2] : "";
                TEnvirnoment Envir = null;
                if ((sMapName == "") || (sX == "") || (sY == "") || ((sMapName != "") && (sMapName[1] == '?')))
                {
                    PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandPositionMoveHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if ((PlayObject.m_btPermission >= this.Attributes.nPermissionMin) || M2Share.CanMoveMap(sMapName))
                {
                    Envir = M2Share.g_MapManager.FindMap(sMapName);
                    if (Envir != null)
                    {
                        int nX = HUtil32.Str_ToInt(sX, 0);
                        int nY = HUtil32.Str_ToInt(sY, 0);
                        if (Envir.CanWalk(nX, nY, true))
                        {
                            PlayObject.SpaceMove(sMapName, nX, nY, 0);
                        }
                        else
                        {
                            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandPositionMoveCanotMoveToMap, sMapName, sX, sY), TMsgColor.c_Green, TMsgType.t_Hint);
                        }
                    }
                }
                else
                {
                    PlayObject.SysMsg(String.Format(GameMsgDef.g_sTheMapDisableMove, sMapName, Envir.sMapDesc), TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage("[Exceptioin] TPlayObject.CmdPositionMove");
                M2Share.MainOutMessage(E.Message);
            }
        }
    }
}