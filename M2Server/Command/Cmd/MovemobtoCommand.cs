using GameFramework;
using GameFramework.Command;
using System.Collections.Generic;

namespace M2Server.Command
{
    /// <summary>
    /// 将指定坐标的怪物移动到新坐标，名称为ALL则移动该坐标所有怪物
    /// MOVEMOBTO 怪物名称 原地图 原X 原Y 新地图 新X 新Y
    /// </summary>
    [GameCommand("Movemobto", "将指定坐标的怪物移动到新坐标，名称为ALL则移动该坐标所有怪物", 10)]
    public class MovemobtoCommand : BaseCommond
    {
        [DefaultCommand]
        public void Movemobto(TPlayObject PlayObject,string[] @Params)
        {
            string sMonName = @Params.Length > 0 ? @Params[0] : "";
            string OleMap = @Params.Length > 1 ? @Params[1] : "";
            string NewMap = @Params.Length > 2 ? @Params[2] : "";
            int nX = @Params.Length > 3 ? int.Parse(@Params[3]) : 0;
            int nY = @Params.Length > 4 ?  int.Parse(@Params[4]) : 0;
            int OnX = @Params.Length > 5 ?  int.Parse(@Params[5]) : 0;
            int OnY = @Params.Length > 6 ? int.Parse(@Params[6]) : 0;
            bool boMoveAll;
            TEnvirnoment SrcEnvir;
            TEnvirnoment DenEnvir;
            List<TBaseObject> MonList;
            TBaseObject MoveMon;
            if ((sMonName == "") || (OleMap == "") || (NewMap == "") || ((sMonName != "") && (sMonName[0] == '?')))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, base.Attributes.Name, GameMsgDef.g_sGameCommandMOVEMOBTOHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            boMoveAll = false;
            if (sMonName == "ALL")
            {
                boMoveAll = true;
            }
            if (nX < 0)
            {
                nX = 0;
            }
            if (nY < 0)
            {
                nY = 0;
            }
            if (OnX < 0)
            {
                OnX = 0;
            }
            if (OnY < 0)
            {
                OnY = 0;
            }
            SrcEnvir = M2Share.g_MapManager.FindMap(OleMap);// 原地图
            DenEnvir = M2Share.g_MapManager.FindMap(NewMap);// 新地图
            if ((SrcEnvir == null) || (DenEnvir == null))
            {
                return;
            }
            MonList = new List<TBaseObject>();
            if (!boMoveAll)// 指定名称的怪移动
            {
                UserEngine.GetMapRangeMonster(SrcEnvir, OnX, OnY, 10, MonList);// 查指定XY范围内的怪
                if (MonList.Count > 0)
                {
                    for (int I = 0; I < MonList.Count; I++)
                    {
                        MoveMon = MonList[I];
                        if (MoveMon != PlayObject)
                        {
                            if ((MoveMon.m_sCharName).ToLower().CompareTo((sMonName).ToLower()) == 0) // 是否是指定名称的怪
                            {
                                MoveMon.SpaceMove(NewMap, nX, nY, 0);
                            }
                        }
                    }
                }
            }
            else   // 所有怪移动
            {
                UserEngine.GetMapRangeMonster(SrcEnvir, OnX, OnY, 1000, MonList);// 查指定XY范围内的怪
                for (int I = 0; I < MonList.Count; I++)
                {
                    MoveMon = MonList[I];
                    if (MoveMon != PlayObject)
                    {
                        MoveMon.SpaceMove(NewMap, nX, nY, 0);
                    }
                }
            }
            PlayObject.Dispose(MonList);
        }
    }
}