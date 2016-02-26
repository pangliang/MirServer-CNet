using GameFramework;
using GameFramework.Command;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 清楚指定地图怪物
    /// </summary>
    [GameCommand("ClearMapMonster", "清楚指定地图怪物", 10)]
    public class ClearMapMonsterCommand : BaseCommond
    {
        [DefaultCommand]
        public void ClearMapMonster(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            string sMapName = @Params.Length > 0 ? @Params[0] : "";
            string sMonName = @Params.Length > 1 ? @Params[1] : "";
            string sItems = @Params.Length > 2 ? @Params[2] : "";

            List<TBaseObject> MonList;
            TEnvirnoment Envir;
            int nMonCount;
            bool boKillAll;
            bool boKillAllMap;
            bool boNotItem;
            TBaseObject BaseObject;
            if ((sMapName == "") || (sMonName == "") || (sItems == ""))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 地图号(* 为所有) 怪物名称(* 为所有) 掉物品(0,1)", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            boKillAll = false;
            boKillAllMap = false;
            boNotItem = true;
            nMonCount = 0;
            Envir = null;
            if (sMonName == "*")
            {
                boKillAll = true;
            }
            if (sMapName == "*")
            {
                boKillAllMap = true;
            }
            if (sItems == "1")
            {
                boNotItem = false;
            }
            MonList = new List<TBaseObject>();
            try
            {
                for (int I = 0; I < M2Share.g_MapManager.m_MapList.Count; I++)
                {
                    Envir = ((TEnvirnoment)(M2Share.g_MapManager.m_MapList[I]));
                    if ((Envir != null))
                    {
                        if (boKillAllMap || ((Envir.sMapName).ToLower().CompareTo((sMapName).ToLower()) == 0))
                        {
                            UserEngine.GetMapMonster(Envir, MonList);
                            if (MonList.Count > 0)
                            {
                                for (int II = 0; II < MonList.Count; II++)
                                {
                                    BaseObject = MonList[II];
                                    if ((BaseObject != null))
                                    {
                                        if ((BaseObject.m_Master != null) && (BaseObject.m_btRaceServer != 135))// 除135怪外，其它宝宝不清除
                                        {
                                            if ((BaseObject.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                            {
                                                continue;
                                            }
                                        }
                                        if (boKillAll || ((sMonName).ToLower().CompareTo((BaseObject.m_sCharName).ToLower()) == 0))
                                        {
                                            BaseObject.m_boNoItem = boNotItem;
                                            BaseObject.m_WAbil.HP = 0;
                                            nMonCount++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                HUtil32.Dispose(MonList);
            }
            if (Envir == null)
            {
                PlayObject.SysMsg("输入的地图不存在！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg("已清除怪物数: " + nMonCount, TMsgColor.c_Red, TMsgType.t_Hint);
        }
    }
}