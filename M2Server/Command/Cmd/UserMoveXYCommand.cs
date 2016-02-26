using GameFramework;
using GameFramework.Command;
using GameFramework.Enum;
using System;

namespace M2Server
{
    /// <summary>
    /// 移动地图指定座标(需要戴传送装备)
    /// </summary>
    [GameCommand("UserMoveXY", "移动地图指定座标(需要戴传送装备)", 10)]
    public class UserMoveXYCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void UserMoveXY(TPlayObject PlayObject,string[] @Params)
        {
            string sX = @Params.Length > 0 ? @Params[0] : "";
            string sY = @Params.Length > 1 ? @Params[1] : "";
            int nX, nY = 0;
            if (PlayObject.m_boTeleport)// 传送戒指
            {
                nX = HUtil32.Str_ToInt(sX, -1);
                nY = HUtil32.Str_ToInt(sY, -1);
                if (!PlayObject.m_PEnvir.m_boNOPOSITIONMOVE)
                {
                    if (PlayObject.m_PEnvir.CanWalkOfItem(nX, nY, GameConfig.boUserMoveCanDupObj, GameConfig.boUserMoveCanOnItem))
                    {
                        if ((HUtil32.GetTickCount() - PlayObject.m_dwTeleportTick) > GameConfig.dwUserMoveTime * 1000)// 10000
                        {
                            PlayObject.m_dwTeleportTick = HUtil32.GetTickCount();
                            if ((PlayObject.m_UseItems[TPosition.U_BUJUK]->wIndex > 0) && (PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura > 0))
                            {
                                if (PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura > 100)// 增加传送符功能
                                {
                                    PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura -= 100;
                                }
                                else
                                {
                                    PlayObject.SendDelItems(PlayObject.m_UseItems[TPosition.U_BUJUK]);  // 如果使用完，则删除物品
                                    PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura = 0;
                                    PlayObject.m_UseItems[TPosition.U_BUJUK]->wIndex = 0;
                                }
                                PlayObject.SendMsg(PlayObject, Grobal2.RM_DURACHANGE, TPosition.U_BUJUK, PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura, PlayObject.m_UseItems[TPosition.U_BUJUK]->DuraMax, 0, "");
                                PlayObject.SendRefMsg(Grobal2.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
                                if ((nX < 0) || (nY < 0))
                                {
                                    PlayObject.RandomMove();
                                }
                                else
                                {
                                    PlayObject.SpaceMove(PlayObject.m_sMapName, nX, nY, 0);
                                }
                                return;
                            }
                            PlayObject.SendRefMsg(Grobal2.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
                            if ((nX < 0) || (nY < 0))
                            {
                               PlayObject. RandomMove();
                            }
                            else
                            {
                                PlayObject.SpaceMove(PlayObject.m_sMapName, nX, nY, 0);
                            }
                        }
                        else
                        {
                            PlayObject.SysMsg(GameConfig.dwUserMoveTime - (HUtil32.GetTickCount() - PlayObject.m_dwTeleportTick) / 1000 + "秒之后才可以再使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandPositionMoveCanotMoveToMap, PlayObject.m_sMapName, sX, sY), TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("此地图禁止使用此命令！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg("您现在还无法使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}