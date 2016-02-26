using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command
{
    [GameCommand("ClearItemMap", "清除指定地图范围物品", 10)]
    public class ClearItemMapCommand : BaseCommond
    {
        [DefaultCommand]
        public void ClearItemMap(TPlayObject PlayObject,string[] @Params)
        {
            string sMap = @Params.Length > 0 ? @Params[0] : "";
            string sItemName = @Params.Length > 1 ? @Params[1] : "";
            int nX = @Params.Length > 2 ? Convert.ToInt32(@Params[2]) : 0;
            int nY = @Params.Length > 3 ? Convert.ToInt32(@Params[3]) : 0;
            int nRange = @Params.Length > 4 ? Convert.ToInt32(@Params[4]) : 0;
            bool boClearAll;
            TEnvirnoment Envir;
            TMapItem MapItem;
            List<TMapItem> ItemList;
            if ((sMap == "") || (sItemName == "") || (nX < 0) || (nY < 0) || (nRange < 0) || ((sItemName != "") && (sItemName[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandCLEARITEMMAPHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            boClearAll = false;
            if (sItemName == "ALL")
            {
                boClearAll = true;
            }
            Envir = M2Share.g_MapManager.FindMap(sMap);// 查找地图
            if (Envir != null)
            {
                ItemList = new List<TMapItem>();
                Envir.GetMapItem(nX, nY, nRange, ItemList);// 取地图上指定范围的物品
                if (!boClearAll)// /清除指定物品
                {
                    if (ItemList.Count > 0)
                    {
                        for (int I = 0; I < ItemList.Count; I++)
                        {
                            MapItem = ItemList[I];
                            if (((MapItem.Name).ToLower().CompareTo((sItemName).ToLower()) == 0))
                            {
                                for (int nXX = nX - nRange; nXX <= nX + nRange; nXX++)
                                {
                                    for (int nYY = nY - nRange; nYY <= nY + nRange; nYY++)
                                    {
                                        Envir.DeleteFromMap(nXX, nYY, Grobal2.OS_ITEMOBJECT, MapItem);
                                        if (MapItem == null)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    // 清除全部物品
                    if (ItemList.Count > 0)
                    {
                        for (int I = 0; I < ItemList.Count; I++)
                        {
                            MapItem = ItemList[I];
                            for (int nXX = nX - nRange; nXX <= nX + nRange; nXX++)
                            {
                                for (int nYY = nY - nRange; nYY <= nY + nRange; nYY++)
                                {
                                    Envir.DeleteFromMap(nXX, nYY, Grobal2.OS_ITEMOBJECT, MapItem);
                                    if (MapItem == null)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                ItemList = null;
            }
        }
    }
}