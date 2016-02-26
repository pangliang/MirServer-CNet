using GameFramework;
using System;
using System.Collections.Generic;

namespace M2Server
{
    public class TMapManager
    {
        /// <summary>
        /// 游戏地图地图列表
        /// </summary>
        public List<TEnvirnoment> m_MapList = null;
        /// <summary>
        /// 当前地图NPC数量
        /// </summary>
        public int m_nNpcCount = 0;
        /// <summary>
        /// 当前地图玩家数量
        /// </summary>
        public int m_nHumCount = 0;
        /// <summary>
        /// 当前地图怪物数量
        /// </summary>
        public int m_nMonCount = 0;
        /// <summary>
        /// 当前地图物品数量
        /// </summary>
        public int m_nItemCount = 0;

        /// <summary>
        /// 创建地图安全区
        /// </summary>
        public void MakeSafePkZone()
        {
            int nX;
            int nY;
            TSafeEvent SafeEvent;
            int nMinX;
            int nMaxX;
            int nMinY;
            int nMaxY;
            int I;
            TStartPoint StartPoint;
            TEnvirnoment Envir;
            lock (M2Share.g_StartPointList)
            {
                if (M2Share.g_StartPointList.Count > 0)
                {
                    for (I = 0; I < M2Share.g_StartPointList.Count; I++)
                    {
                        StartPoint = M2Share.g_StartPointList[I];
                        if ((StartPoint != null) && (StartPoint.m_nType > 0))
                        {
                            Envir = FindMap(StartPoint.m_sMapName);
                            if (Envir != null)
                            {
                                nMinX = StartPoint.m_nCurrX - StartPoint.m_nRange;
                                nMaxX = StartPoint.m_nCurrX + StartPoint.m_nRange;
                                nMinY = StartPoint.m_nCurrY - StartPoint.m_nRange;
                                nMaxY = StartPoint.m_nCurrY + StartPoint.m_nRange;
                                for (nX = nMinX; nX <= nMaxX; nX++)
                                {
                                    for (nY = nMinY; nY <= nMaxY; nY++)
                                    {
                                        if (((nX < nMaxX) && (nY == nMinY)) || ((nY < nMaxY) && (nX == nMinX)) || (nX == nMaxX) || (nY == nMaxY))
                                        {
                                            SafeEvent = new TSafeEvent(Envir, nX, nY, StartPoint.m_nType);
                                            M2Share.g_EventManager.AddEvent(SafeEvent);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public TEnvirnoment AddMapInfo(string sMapName, string sMainMapName, string sMapDesc, int nServerNumber, TMapFlag MapFlag, Object QuestNPC)
        {
            TEnvirnoment result;
            TEnvirnoment Envir;
            int nStd = 0;
            List<string> TempList;
            string sTemp;
            result = null;
            Envir = new TEnvirnoment();
            Envir.sMapName = sMapName;
            Envir.sMainMapName = sMainMapName;
            Envir.sMapDesc = sMapDesc;
            if (sMainMapName != "")
            {
                Envir.m_boMainMap = true;
            }
            Envir.nServerIndex = nServerNumber;
            Envir.m_boSAFE = MapFlag.boSAFE;
            Envir.m_boFightZone = MapFlag.boFIGHT;
            Envir.m_boFight2Zone = MapFlag.boFIGHT2;// PK掉装备地图
            Envir.m_boFight3Zone = MapFlag.boFIGHT3;
            Envir.m_boFight4Zone = MapFlag.boFIGHT4;// 挑战地图
            Envir.m_boDARK = MapFlag.boDARK;
            Envir.m_boDAY = MapFlag.boDAY;
            Envir.m_boQUIZ = MapFlag.boQUIZ;
            Envir.m_boNORECONNECT = MapFlag.boNORECONNECT;
            Envir.m_boNEEDHOLE = MapFlag.boNEEDHOLE;
            Envir.m_boNORECALL = MapFlag.boNORECALL;
            Envir.m_boNOGUILDRECALL = MapFlag.boNOGUILDRECALL;
            Envir.m_boNODEARRECALL = MapFlag.boNODEARRECALL;
            Envir.m_boNOMASTERRECALL = MapFlag.boNOMASTERRECALL;
            Envir.m_boNORANDOMMOVE = MapFlag.boNORANDOMMOVE;
            Envir.m_boNODRUG = MapFlag.boNODRUG;
            Envir.m_boMINE = MapFlag.boMINE;
            Envir.m_boNOPOSITIONMOVE = MapFlag.boNOPOSITIONMOVE;
            Envir.m_boNoManNoMon = MapFlag.boNoManNoMon;// 无人不刷怪
            Envir.m_boRUNHUMAN = MapFlag.boRUNHUMAN;// 可以穿人
            Envir.m_boRUNMON = MapFlag.boRUNMON;// 可以穿怪
            Envir.m_boDECHP = MapFlag.boDECHP;// 自动减HP值
            Envir.m_boINCHP = MapFlag.boINCHP;// 自动加HP值
            Envir.m_boDecGameGold = MapFlag.boDECGAMEGOLD;// 自动减游戏币
            Envir.m_boDECGAMEPOINT = MapFlag.boDECGAMEPOINT;// 自动减游戏点
            Envir.m_boIncGameGold = MapFlag.boINCGAMEGOLD;// 自动加游戏币
            Envir.m_boINCGAMEPOINT = MapFlag.boINCGAMEPOINT;// 自动加游戏点
            Envir.m_boNEEDLEVELTIME = MapFlag.boNEEDLEVELTIME;// 雪域地图传送,判断等级
            Envir.m_nNEEDLEVELPOINT = MapFlag.nNEEDLEVELPOINT;// 进雪域地图最低等级
            Envir.m_boNOCALLHERO = MapFlag.boNoCALLHERO;// 禁止召唤英雄 
            Envir.m_boNOHEROPROTECT = MapFlag.boNOHEROPROTECT;// 禁止英雄守护 
            Envir.m_boNODROPITEM = MapFlag.boNODROPITEM;// 禁止死亡掉物品 
            Envir.m_boKILLFUNC = MapFlag.boKILLFUNC;// 地图杀人触发 
            Envir.m_nKILLFUNC = MapFlag.nKILLFUNC;// 地图杀人触发 
            Envir.m_boMISSION = MapFlag.boMISSION;// 不允许使用任何物品和技能 
            Envir.m_boMUSIC = MapFlag.boMUSIC;// 音乐
            Envir.m_boEXPRATE = MapFlag.boEXPRATE;// 杀怪经验倍数
            Envir.m_boPKWINLEVEL = MapFlag.boPKWINLEVEL;// PK得等级
            Envir.m_boPKWINEXP = MapFlag.boPKWINEXP;// PK得经验
            Envir.m_boPKLOSTLEVEL = MapFlag.boPKLOSTLEVEL;
            Envir.m_boPKLOSTEXP = MapFlag.boPKLOSTEXP;
            Envir.m_nPKWINLEVEL = MapFlag.nPKWINLEVEL;// PK得等级数
            Envir.m_nPKWINEXP = MapFlag.nPKWINEXP;// PK得经验数
            Envir.m_nPKLOSTLEVEL = MapFlag.nPKLOSTLEVEL;
            Envir.m_nPKLOSTEXP = MapFlag.nPKLOSTEXP;
            Envir.m_nPKWINEXP = MapFlag.nPKWINEXP;// PK得经验数
            Envir.m_nDECHPTIME = MapFlag.nDECHPTIME;// 减HP间隔时间
            Envir.m_nDECHPPOINT = MapFlag.nDECHPPOINT;// 一次减点数
            Envir.m_nINCHPTIME = MapFlag.nINCHPTIME;// 加HP间隔时间
            Envir.m_nINCHPPOINT = MapFlag.nINCHPPOINT;// 一次加点数
            Envir.m_nDECGAMEGOLDTIME = MapFlag.nDECGAMEGOLDTIME;// 减游戏币间隔时间
            Envir.m_nDecGameGold = (int)MapFlag.nDECGAMEGOLD;// 一次减数量
            Envir.m_nINCGAMEGOLDTIME = MapFlag.nINCGAMEGOLDTIME;// 减游戏币间隔时间
            Envir.m_nIncGameGold = MapFlag.nINCGAMEGOLD;// 一次减数量
            Envir.m_nINCGAMEPOINTTIME = MapFlag.nINCGAMEPOINTTIME;// 加游戏点间隔时间
            Envir.m_nINCGAMEPOINT = MapFlag.nINCGAMEPOINT;// 一次减数量
            Envir.m_nDECGAMEPOINTTIME = MapFlag.nDECGAMEPOINTTIME;// 减游戏点间隔时间
            Envir.m_nDECGAMEPOINT = MapFlag.nDECGAMEPOINT;// 一次减数量
            Envir.m_nMUSICID = MapFlag.nMUSICID;// 音乐ID
            Envir.m_nEXPRATE = MapFlag.nEXPRATE;// 经验倍率
            Envir.m_sMUSICName = MapFlag.sMUSICName;
            Envir.sNoReconnectMap = MapFlag.sReConnectMap;
            Envir.QuestNPC = QuestNPC;
            Envir.nNEEDSETONFlag = MapFlag.nNEEDSETONFlag;
            Envir.nNeedONOFF = MapFlag.nNeedONOFF;
            Envir.m_boUnAllowStdItems = MapFlag.boUnAllowStdItems;
            Envir.m_boUnAllowMagics = MapFlag.boNOTALLOWUSEMAGIC;
            Envir.m_boFIGHTPK = MapFlag.boFIGHTPK;// PK可以爆装备不红名
            Envir.nThunder = MapFlag.nThunder;
            Envir.nLava = MapFlag.nLava;
            if ((Envir.nThunder != 0) || (Envir.nLava != 0))
            {
                M2Share.UserEngine.EffectList.Add(Envir);
            }
            unsafe
            {
                if ((Envir.m_boUnAllowStdItems) && (MapFlag.sUnAllowStdItemsText != ""))
                {
                    TempList = new List<string>();
                    fixed (char* Content = MapFlag.sUnAllowStdItemsText.Trim().ToCharArray())
                    {
                        HUtil32.ExtractStrings(new char[] { '|', '\\', '/' }, new char[] { }, Content, TempList);
                    }
                    if (TempList.Count > 0)
                    {
                        for (int I = 0; I < TempList.Count; I++)
                        {
                            nStd = M2Share.UserEngine.GetStdItemIdx(TempList[I].Trim());
                            if (nStd >= 0)
                            {
                                Envir.m_UnAllowStdItemsList.Add(new UnAllowItem()
                                {
                                    Idx = nStd,
                                    ItemName = TempList[I].Trim()
                                });
                            }
                        }
                    }
                    Dispose(TempList);
                }
                if ((Envir.m_boUnAllowMagics) && (MapFlag.sUnAllowMagicText != ""))
                {
                    TempList = new List<string>();
                    fixed (char* Content = MapFlag.sUnAllowMagicText.Trim().ToCharArray())
                    {
                        HUtil32.ExtractStrings(new char[] { '|', '\\', '/' }, new char[] { }, Content, TempList);
                    }
                    if (TempList.Count > 0)
                    {
                        for (int I = 0; I < TempList.Count; I++)
                        {
                            sTemp = TempList[I].Trim();
                            if (sTemp != "")
                            {
                                Envir.m_UnAllowMagicList.Add(new UnAllowMagic()
                                {
                                    Idx = nStd,
                                    MagicName = TempList[I].Trim()
                                });
                            }
                        }
                    }
                    Dispose(TempList);
                }
            }
            if (M2Share.MiniMapList.Count > 0)
            {
                foreach (var item in M2Share.MiniMapList)
                {
                    if (string.Compare(item.sMapNO, Envir.sMapName, true) == 0)
                    {
                        Envir.nMinMap = item.nIdx;
                        break;
                    }
                }
            }
            if (sMainMapName != "")
            {
                if (Envir.LoadMapData(M2Share.g_Config.sMapDir + sMainMapName + ".map"))
                {
                    result = Envir;
                    m_MapList.Add(Envir);
                }
                else
                {
                    M2Share.MainOutMessage("地图文件 " + M2Share.g_Config.sMapDir + sMainMapName + ".map" + " 未找到！！！");
                }
            }
            else
            {
                if (Envir.LoadMapData(M2Share.g_Config.sMapDir + sMapName + ".map"))
                {
                    result = Envir;
                    m_MapList.Add(Envir);
                }
                else
                {
                    M2Share.MainOutMessage("地图文件 " + M2Share.g_Config.sMapDir + sMapName + ".map" + " 未找到！！！");
                }
            }
            return result;
        }

        /// <summary>
        /// 增加地图连接点
        /// </summary>
        /// <param name="sSMapNO"></param>
        /// <param name="nSMapX"></param>
        /// <param name="nSMapY"></param>
        /// <param name="sDMapNO"></param>
        /// <param name="nDMapX"></param>
        /// <param name="nDMapY"></param>
        /// <returns></returns>
        public bool AddMapRoute(string sSMapNO, int nSMapX, int nSMapY, string sDMapNO, int nDMapX, int nDMapY)
        {
            bool result;
            TGateObj GateObj;
            TEnvirnoment SEnvir;
            TEnvirnoment DEnvir;
            result = false;
            SEnvir = FindMap(sSMapNO);
            DEnvir = FindMap(sDMapNO);
            if ((SEnvir != null) && (DEnvir != null))
            {
                GateObj = new TGateObj();
                GateObj.boFlag = false;
                GateObj.DEnvir = DEnvir;
                GateObj.nDMapX = nDMapX;
                GateObj.nDMapY = nDMapY;
                SEnvir.AddToMap(nSMapX, nSMapY, Grobal2.OS_GATEOBJECT, GateObj);
                result = true;
            }
            return result;
        }


        public TMapManager()
        {
            m_MapList = new List<TEnvirnoment>();
        }

        ~TMapManager()
        {
            for (int I = 0; I < this.m_MapList.Count; I++)
            {
                Dispose(this.m_MapList[I]);
            }
        }


        /// <summary>
        /// 获取地图编号
        /// </summary>
        /// <param name="Envir"></param>
        /// <returns></returns>
        public string GetMainMap(TEnvirnoment Envir)
        {
            return Envir.m_boMainMap ? Envir.sMainMapName : Envir.sMapName;
        }

        /// <summary>
        /// 查找地图
        /// </summary>
        /// <param name="sMapName"></param>
        /// <returns></returns>
        public TEnvirnoment FindMap(string sMapName)
        {
            TEnvirnoment c = this.m_MapList.Find(Map =>
            {
                return Map.sMapName == sMapName.ToUpper();
            });
            return c;
        }

        /// <summary>
        /// 获取地图信息
        /// </summary>
        /// <param name="nServerIdx"></param>
        /// <param name="sMapName"></param>
        /// <returns></returns>
        public TEnvirnoment GetMapInfo(int nServerIdx, string sMapName)
        {
            return this.m_MapList.Find(m =>
            {
                return (string.Compare(m.sMapName, sMapName, true) == 0) && (m.nServerIndex == nServerIdx);
            });
        }

        /// <summary>
        /// 获取地图所在服务器编号
        /// </summary>
        /// <param name="sMapName"></param>
        /// <returns></returns>
        public int GetMapOfServerIndex(string sMapName)
        {
            int result = 0;
            TEnvirnoment Envir;
            lock (this.m_MapList)
                try
                {
                    if (this.m_MapList.Count > 0)
                    {
                        foreach (var item in this.m_MapList)
                        {
                            Envir = item;
                            if (string.Compare(Envir.sMapName, sMapName, true) == 0)
                            {
                                result = Envir.nServerIndex;
                                break;
                            }
                        }
                    }
                }
                finally
                {

                }
            return result;
        }

        /// <summary>
        /// 加载地图门
        /// </summary>
        public void LoadMapDoor()
        {
            if (this.m_MapList.Count > 0)
            {
                foreach (var item in this.m_MapList)
                {
                    item.AddDoorToMap();
                }
            }
        }

        public void ProcessMapDoor()
        {
        }

        public void ReSetMinMap()
        {
            TEnvirnoment Envirnoment;
            if (this.m_MapList.Count > 0)
            {
                foreach (var item in this.m_MapList)
                {
                    Envirnoment = item;
                    if (M2Share.MiniMapList.Count > 0)
                    {
                        foreach (var items in M2Share.MiniMapList)
                        {
                            if (string.Compare(items.sMapNO, Envirnoment.sMapName, true) == 0)
                            {
                                Envirnoment.nMinMap = items.nIdx;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Run()
        {
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}
