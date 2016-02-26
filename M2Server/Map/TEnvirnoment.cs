using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace M2Server
{
    public class TEnvirnoment
    {
        /// <summary>
        /// 地图上怪物的数量
        /// </summary>
        public int m_nMonCount = 0;
        /// <summary>
        /// 地图上人物的数量
        /// </summary>
        public int m_nHumCount = 0;
        /// <summary>
        /// 地图上NPC数量
        /// </summary>
        public int m_nNpcCount = 0;
        /// <summary>
        /// 地图上物品数量
        /// </summary>
        public int m_nItemCount = 0;
        /// <summary>
        /// 怪物数量
        /// </summary>
        public int MonCount
        {
            get
            {
                return m_nMonCount;
            }
        }
        /// <summary>
        /// 人物数量
        /// </summary>
        public int HumCount
        {
            get
            {
                return m_nHumCount;
            }
        }
        /// <summary>
        /// 地图ID
        /// </summary>
        public string sMapName = String.Empty;
        /// <summary>
        /// 地图名称
        /// </summary>
        public string sMapDesc = String.Empty;
        /// <summary>
        /// 地图名称(重复利用地图名称)
        /// </summary>
        public string sMainMapName = String.Empty;
        /// <summary>
        /// 是否是重复地图
        /// </summary>
        public bool m_boMainMap = false;
        /// <summary>
        /// 路径图存储数组
        /// </summary>
        public TMapCellinfo[] MapCellInfoArray;
        /// <summary>
        /// 小地图数量
        /// </summary>
        public int nMinMap = 0;
        /// <summary>
        /// 服务器编号
        /// </summary>
        public int nServerIndex = 0;
        /// <summary>
        /// 进入本地图所需等级
        /// </summary>
        public int nRequestLevel = 0;
        /// <summary>
        /// 地图宽度
        /// </summary>
        public int m_nWidth = 0;
        /// <summary>
        /// 地图高度
        /// </summary>
        public int m_nHeight = 0;
        public bool m_boDARK = false;
        public bool m_boDAY = false;
        public bool m_boDarkness = false;
        public bool m_boDayLight = false;
        /// <summary>
        /// 门列表
        /// </summary>
        public IList<TDoorInfo> m_DoorList = null;
        public bool bo2C = false;
        /// <summary>
        /// 是否安全区
        /// </summary>
        public bool m_boSAFE = false;
        /// <summary>
        /// 是否PK地图
        /// </summary>
        public bool m_boFightZone = false;
        /// <summary>
        ///  PK是否掉装备地图
        /// </summary>
        public bool m_boFight2Zone = false;
        /// <summary>
        /// 行会战争地图
        /// </summary>
        public bool m_boFight3Zone = false;
        /// <summary>
        /// 挑战地图
        /// </summary>
        public bool m_boFight4Zone = false;
        public bool m_boQUIZ = false;
        public bool m_boNORECONNECT = false;
        /// <summary>
        /// 进入需要洞（僵尸从地下钻出来的洞）
        /// </summary>
        public bool m_boNEEDHOLE = false;
        public bool m_boNORECALL = false;
        public bool m_boNOGUILDRECALL = false;
        public bool m_boNODEARRECALL = false;
        public bool m_boNOMASTERRECALL = false;
        public bool m_boNORANDOMMOVE = false;
        public bool m_boNODRUG = false;
        /// <summary>
        /// 是否可以挖矿
        /// </summary>
        public bool m_boMINE = false;
        public bool m_boNOPOSITIONMOVE = false;
        public string sNoReconnectMap = String.Empty;
        public Object QuestNPC = null;
        public int nNEEDSETONFlag = 0;
        public int nNeedONOFF = 0;
        public IList<TMapQuestInfo> m_QuestList = null;
        /// <summary>
        /// 无人不刷怪
        /// </summary>
        public bool m_boNoManNoMon = false;
        /// <summary>
        /// 可以穿人
        /// </summary>
        public bool m_boRUNHUMAN = false;
        /// <summary>
        /// 可以穿怪
        /// </summary>
        public bool m_boRUNMON = false;
        /// <summary>
        ///  自动加HP值
        /// </summary>
        public bool m_boINCHP = false;
        /// <summary>
        /// 自动减游戏币
        /// </summary>
        public bool m_boIncGameGold = false;
        /// <summary>
        /// 自动加点
        /// </summary>
        public bool m_boINCGAMEPOINT = false;
        /// <summary>
        /// 自动减游戏点
        /// </summary>
        public bool m_boDECGAMEPOINT = false;
        /// <summary>
        /// 雪域地图传送,判断等级
        /// </summary>
        public bool m_boNEEDLEVELTIME = false;
        /// <summary>
        /// 进雪域地图最低等级
        /// </summary>
        public int m_nNEEDLEVELPOINT = 0;
        /// <summary>
        /// 禁止召唤英雄
        /// </summary>
        public bool m_boNOCALLHERO = false;
        /// <summary>
        /// 禁止英雄守护
        /// </summary>
        public bool m_boNOHEROPROTECT = false;
        /// <summary>
        /// 禁止死亡掉物品
        /// </summary>
        public bool m_boNODROPITEM = false;
        /// <summary>
        /// 地图杀人触发
        /// </summary>
        public bool m_boKILLFUNC = false;
        /// <summary>
        /// 地图杀人触发
        /// </summary>
        public int m_nKILLFUNC = 0;
        /// <summary>
        /// 不允许使用任何物品和技能
        /// </summary>
        public bool m_boMISSION = false;
        /// <summary>
        /// 自动减HP值
        /// </summary>
        public bool m_boDECHP = false;
        /// <summary>
        /// 自动减游戏币
        /// </summary>
        public bool m_boDecGameGold = false;
        /// <summary>
        /// 音乐
        /// </summary>
        public bool m_boMUSIC = false;
        /// <summary>
        /// 杀怪经验倍数
        /// </summary>
        public bool m_boEXPRATE = false;
        /// <summary>
        /// PK得等级
        /// </summary>
        public bool m_boPKWINLEVEL = false;
        /// <summary>
        /// PK得经验
        /// </summary>
        public bool m_boPKWINEXP = false;
        /// <summary>
        /// PK丢等级
        /// </summary>
        public bool m_boPKLOSTLEVEL = false;
        /// <summary>
        /// PK丢经验
        /// </summary>
        public bool m_boPKLOSTEXP = false;
        /// <summary>
        /// PK得等级数
        /// </summary>
        public int m_nPKWINLEVEL = 0;
        /// <summary>
        /// PK丢等级
        /// </summary>
        public int m_nPKLOSTLEVEL = 0;
        /// <summary>
        ///  PK得经验数
        /// </summary>
        public uint m_nPKWINEXP = 0;
        /// <summary>
        ///  PK丢经验
        /// </summary>
        public uint m_nPKLOSTEXP = 0;
        /// <summary>
        /// 减HP间隔时间
        /// </summary>
        public int m_nDECHPTIME = 0;
        /// <summary>
        /// 一次减点数
        /// </summary>
        public int m_nDECHPPOINT = 0;
        /// <summary>
        /// 加HP间隔时间
        /// </summary>
        public int m_nINCHPTIME = 0;
        /// <summary>
        /// 一次加点数
        /// </summary>
        public int m_nINCHPPOINT = 0;
        /// <summary>
        /// 减游戏币间隔时间
        /// </summary>
        public int m_nDECGAMEGOLDTIME = 0;
        /// <summary>
        /// 一次减数量
        /// </summary>
        public int m_nDecGameGold = 0;
        /// <summary>
        /// 加游戏币间隔时间
        /// </summary>
        public int m_nINCGAMEGOLDTIME = 0;
        /// <summary>
        /// 一次加数量
        /// </summary>
        public int m_nIncGameGold = 0;
        /// <summary>
        /// 加游戏币间隔时间
        /// </summary>
        public int m_nINCGAMEPOINTTIME = 0;
        /// <summary>
        /// 一次加数量
        /// </summary>
        public int m_nINCGAMEPOINT = 0;
        /// <summary>
        /// 减游戏币间隔时间
        /// </summary>
        public int m_nDECGAMEPOINTTIME = 0;
        /// <summary>
        /// 一次减数量
        /// </summary>
        public int m_nDECGAMEPOINT = 0;
        /// <summary>
        /// 音乐ID
        /// </summary>
        public int m_nMUSICID = 0;
        /// <summary>
        /// 音乐名称
        /// </summary>
        public string m_sMUSICName = String.Empty;
        /// <summary>
        /// 经验倍率
        /// </summary>
        public int m_nEXPRATE = 0;
        /// <summary>
        /// 是否不允许使用物品
        /// </summary>
        public bool m_boUnAllowStdItems = false;
        /// <summary>
        /// 不允许使用物品列表
        /// </summary>
        public List<UnAllowItem> m_UnAllowStdItemsList = null;
        /// <summary>
        /// 是否不允许使用魔法
        /// </summary>
        public bool m_boUnAllowMagics = false;
        /// <summary>
        /// 不允许使用魔法列表
        /// </summary>
        public List<UnAllowMagic> m_UnAllowMagicList = null;
        /// <summary>
        /// PK可以爆装备不红名
        /// </summary>
        public bool m_boFIGHTPK = false;
        /// <summary>
        /// 雷电 地图参数
        /// </summary>
        public int nThunder = 0;
        public int nLava = 0;

        public TEnvirnoment()
        {
            MapCellInfoArray = null;
            sMapName = "";
            sMainMapName = "";
            m_boMainMap = false;
            nServerIndex = 0;
            nMinMap = 0;
            m_nWidth = 0;
            m_nHeight = 0;
            m_boDARK = false;
            m_boDAY = false;
            m_nMonCount = 0;
            m_nHumCount = 0;
            m_DoorList = new List<TDoorInfo>();
            m_QuestList = new List<TMapQuestInfo>();
            m_UnAllowStdItemsList = new List<UnAllowItem>();
            m_UnAllowMagicList = new List<UnAllowMagic>();
        }

        ~TEnvirnoment()
        {
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TDoorInfo DoorInfo;
            for (int nX = 0; nX < m_nWidth; nX++)
            {
                for (int nY = 0; nY < m_nHeight; nY++)
                {
                    if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                    {
                        if (MapCellInfo.ObjList.Count > 0)
                        {
                            for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                            {
                                OSObject = MapCellInfo.ObjList[I];
                                if (OSObject != null)
                                {
                                    switch (OSObject.btType)
                                    {
                                        case Grobal2.OS_ITEMOBJECT:
                                            if (((TMapItem)(OSObject.CellObj)) != null)
                                            {
                                                Dispose(((TMapItem)(OSObject.CellObj)));
                                            }
                                            break;
                                        case Grobal2.OS_GATEOBJECT:
                                            if (((TGateObj)(OSObject.CellObj)) != null)
                                            {
                                                Dispose(((TGateObj)(OSObject.CellObj)));
                                            }
                                            break;
                                        case Grobal2.OS_EVENTOBJECT:
                                            Dispose(OSObject.CellObj);
                                            break;
                                    }
                                    Dispose(OSObject);
                                }
                            }
                        }
                        MapCellInfo.ObjList = null;
                        UpdateMapCellInfo(nX, nY, MapCellInfo);
                    }
                }
            }
            if (m_DoorList.Count > 0)
            {
                for (int I = 0; I < m_DoorList.Count; I++)
                {
                    DoorInfo = m_DoorList[I];
                    if (DoorInfo != null)
                    {
                        if (DoorInfo.Status != null)
                        {
                            DoorInfo.Status.nRefCount -= 1;
                            if (DoorInfo.Status.nRefCount <= 0)
                            {
                                Dispose(DoorInfo.Status);
                            }
                        }
                        Dispose(DoorInfo);
                    }
                }
            }
            Dispose(m_DoorList);
            if (m_QuestList.Count > 0)
            {
                for (int I = 0; I < m_QuestList.Count; I++)
                {
                    if (m_QuestList[I] != null)
                    {
                        Dispose(m_QuestList[I]);
                    }
                }
            }
            Dispose(m_QuestList);
            if ((MapCellInfoArray as object) != null)
            {
                Dispose(MapCellInfoArray);
                MapCellInfoArray = null;
            }
            Dispose(m_UnAllowStdItemsList);
            Dispose(m_UnAllowMagicList);
        }

        /// <summary>
        /// 加载地图
        /// </summary>
        /// <param name="sMapFile"></param>
        /// <returns></returns>
        public bool LoadMapData(string sMapFile)
        {
            bool result = false;
            TMapHeader Header;
            int nMapSize;
            int n24;
            int nW;
            int nH;
            byte[] bytData = null;
            byte[] buff = null;
            int buffIndex;
            int Point;
            TDoorInfo Door = null;
            TMapCellinfo MapCellInfo;
            string sX = string.Empty;
            string sY = string.Empty;
            TMapUnitInfo MapBuffer;
            bool boNewMap;//是否新地图
            bool boENMap;
            string sMapVer;
            if (File.Exists(sMapFile))
            {
                try
                {
                    using (FileStream fileStream = new FileStream(sMapFile, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader binReader = new BinaryReader(fileStream))
                        {
                            int muiSize;
                            Header = new TMapHeader();
                            bytData = new byte[Marshal.SizeOf(Header)];
                            binReader.Read(bytData, 0, bytData.Length);
                            Header = (TMapHeader)HUtil32.rawDeserialize(bytData, Header.GetType());
                            m_nWidth = Header.wWidth;
                            m_nHeight = Header.wHeight;
                            Initialize(m_nWidth, m_nHeight);
                            MapBuffer = new TMapUnitInfo();
                            muiSize = Marshal.SizeOf(MapBuffer);
                            nMapSize = m_nWidth * muiSize * m_nHeight;
                            buff = new byte[nMapSize];
                            binReader.Read(buff, 0, nMapSize);
                            buffIndex = 0;
                            for (nW = 0; nW < m_nWidth; nW++)
                            {
                                n24 = nW * m_nHeight;
                                for (nH = 0; nH < m_nHeight; nH++)
                                {
                                    // wBkImg High
                                    if ((buff[buffIndex + 1] & 0x80) != 0)
                                    {
                                        // MapCellInfo = MapCellArray[n24 + nH];
                                        // MapCellInfo.chFlag = 1;
                                        UpdateMapCellFlag(n24, nH, 1);
                                    }
                                    // wFrImg High
                                    if ((buff[buffIndex + 5] & 0x80) != 0)
                                    {
                                        // MapCellInfo = MapCellArray[n24 + nH];
                                        //MapCellInfo.chFlag = 2;
                                        UpdateMapCellFlag(n24, nH, 2);
                                    }
                                    // btDoorIndex
                                    if ((buff[buffIndex + 6] & 0x80) != 0)
                                    {
                                        Point = (buff[buffIndex + 6] & 0x7F);
                                        if (Point > 0)
                                        {
                                            Door = new TDoorInfo();
                                            Door.nX = nW;
                                            Door.nY = nH;
                                            Door.n08 = Point;
                                            Door.Status = null;
                                            if (m_DoorList.Count > 0)
                                            {
                                                for (int I = 0; I < m_DoorList.Count; I++)
                                                {
                                                    if (Math.Abs(m_DoorList[I].nX - Door.nX) <= 10)
                                                    {
                                                        if (Math.Abs(m_DoorList[I].nY - Door.nY) <= 10)
                                                        {
                                                            if (m_DoorList[I].n08 == Point)
                                                            {
                                                                Door.Status = m_DoorList[I].Status;
                                                                Door.Status.nRefCount++;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (Door.Status == null)
                                            {
                                                Door.Status = new TDoorStatus();
                                                Door.Status.boOpened = false;//是否打开
                                                Door.Status.bo01 = false;
                                                Door.Status.n04 = 0;
                                                Door.Status.dwOpenTick = 0;
                                                Door.Status.nRefCount = 1;
                                            }
                                            m_DoorList.Add(Door);
                                        }
                                    }
                                    buffIndex += muiSize;
                                }
                            }
                        }
                        Dispose(MapBuffer);
                    }
                    result = true;
                }
                catch { }
            }
            return result;
        }

        /// <summary>
        /// 初始化路径图存储数组
        /// </summary>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        private void Initialize(int nWidth, int nHeight)
        {

            if ((nWidth <= 1) || (nHeight <= 1))
            {
                return;
            }
            InitializeWidthAndHeight(nWidth, nHeight);
            CleanMapCellInfoArray();
            PopulateMapCellInfoArray();

        }

        private void PopulateMapCellInfoArray()
        {

            MapCellInfoArray = new TMapCellinfo[m_nWidth * m_nHeight];
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            for (int nW = 0; nW < m_nWidth; nW++)
            {
                for (int nH = 0; nH < m_nHeight; nH++)
                {
                    MapCellInfoArray[nW * m_nHeight + nH] = MapCellInfo;
                }
            }
        }

        private void InitializeWidthAndHeight(int nWidth, int nHeight)
        {
            m_nWidth = nWidth;
            m_nHeight = nHeight;
        }

        private void CleanMapCellInfoArray()
        {
            TMapCellinfo MapCellInfo;
            if (MapCellInfoArray == null)
            {
                return;
            }
            for (int nW = 0; nW < m_nWidth; nW++)
            {
                for (int nH = 0; nH < m_nHeight; nH++)
                {
                    MapCellInfo = MapCellInfoArray[nW * m_nHeight + nH];
                    if (MapCellInfo.ObjList != null)
                    {
                        MapCellInfo.ObjList = null;
                    }
                }
            }
            Dispose(MapCellInfoArray);
            MapCellInfoArray = null;

        }

        public object AddToMap(int nX, int nY, byte btType, object pRemoveObject)
        {
            object result = null;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TMapItem MapItem;
            int nGoldCount;
            bool bo1E;

            byte nCode;
            const string sExceptionMsg = "{异常} TEnvirnoment::AddToMap Code:";

            nCode = 0;
            try
            {
                bo1E = false;
                MapCellInfo = new TMapCellinfo();
                if (!CanGetMapCellInfo(nX, nY, ref MapCellInfo) || (MapCellInfo.chFlag != 0))
                {
                    return result;
                }

                if (MapCellInfo.ObjList == null)
                {
                    MapCellInfo.ObjList = new List<TOSObject>();
                }
                else
                {
                    if (btType == Grobal2.OS_ITEMOBJECT)
                    {
                        //金币名
                        if (((TMapItem)(pRemoveObject)).Name == M2Share.sSTRING_GOLDNAME)
                        {
                            if (MapCellInfo.ObjList.Count > 0)
                            {
                                for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                                {
                                    OSObject = MapCellInfo.ObjList[I];
                                    if ((OSObject != null) && (OSObject.btType == Grobal2.OS_ITEMOBJECT))
                                    {
                                        MapItem = (TMapItem)MapCellInfo.ObjList[I].CellObj;
                                        if (MapItem.Name == M2Share.sSTRING_GOLDNAME)
                                        {
                                            nGoldCount = MapItem.Count + ((TMapItem)(pRemoveObject)).Count;
                                            if (nGoldCount <= 2000)
                                            {
                                                result = SetMapItem(MapItem, nGoldCount);
                                                OSObject.dwAddTime = HUtil32.GetTickCount();
                                                bo1E = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (!bo1E && (MapCellInfo.ObjList.Count >= 5))
                        {
                            result = null;
                            bo1E = true;
                        }
                    }
                    if (btType == Grobal2.OS_EVENTOBJECT)
                    {
                    }
                }

                if (!bo1E)
                {
                    OSObject = MakeOSObjectByTypeAndObject(btType, pRemoveObject);
                    MapCellInfo.ObjList.Add(OSObject);
                    UpdateMapCellInfo(nX, nY, MapCellInfo);
                    SetHumCountOrMonCount(btType, pRemoveObject);
                    SetDelFromMaped(btType, pRemoveObject);
                    result = (pRemoveObject as object);                    
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            return result;
        }

        private void SetDelFromMaped(byte btType, object pRemoveObject)
        {
            TBaseObject baseObject = pRemoveObject as TBaseObject;
            if ((btType == Grobal2.OS_MOVINGOBJECT) && (!baseObject.m_boAddToMaped))
            {
                baseObject.m_boDelFormMaped = false;
            }
        }

        private void SetHumCountOrMonCount(byte btType, object pRemoveObject)
        {
            TBaseObject baseObject = pRemoveObject as TBaseObject;
            if ((btType != Grobal2.OS_MOVINGOBJECT) || (baseObject.m_boAddToMaped))
            {
                return;
            }

            if (baseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                m_nHumCount++;
            }
            if (baseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
            {
                m_nMonCount++;
            }
        }

        private static TOSObject MakeOSObjectByTypeAndObject(byte btType, object pRemoveObject)
        {
            TOSObject OSObject;
            OSObject = new TOSObject();
            OSObject.btType = btType;
            OSObject.CellObj = pRemoveObject;
            OSObject.dwAddTime = HUtil32.GetTickCount();
            return OSObject;
        }

        private static TMapItem SetMapItem(TMapItem MapItem, int nGoldCount)
        {
            MapItem.Count = nGoldCount;
            MapItem.Looks = M2Share.GetGoldShape(nGoldCount);
            MapItem.AniCount = 0;
            MapItem.Reserved = 0;
            return MapItem;
        }

        /// <summary>
        /// 地图是否允许使用物品
        /// </summary>
        /// <param name="sItemName"></param>
        /// <returns></returns>
        public bool AllowStdItems(string sItemName)
        {
            bool result = true;
            try
            {
                if (!m_boUnAllowStdItems || (m_UnAllowStdItemsList == null))
                {
                    return result;
                }
                if (m_UnAllowStdItemsList.Count > 0)
                {
                    for (int I = 0; I < m_UnAllowStdItemsList.Count; I++)
                    {
                        if ((m_UnAllowStdItemsList[I].ItemName).ToLower().CompareTo((sItemName).ToLower()) == 0)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TEnvirnoment.AllowStdItems Code:0");
            }
            return result;
        }

        /// <summary>
        /// 地图是否允许使用物品
        /// </summary>
        /// <param name="nItemIdx"></param>
        /// <returns></returns>
        public bool AllowStdItems(int nItemIdx)
        {
            bool result = true;
            try
            {
                if (!m_boUnAllowStdItems || (m_UnAllowStdItemsList == null))
                {
                    return result;
                }
                if (m_UnAllowStdItemsList.Count > 0)
                {
                    for (int I = 0; I < m_UnAllowStdItemsList.Count; I++)
                    {
                        if (m_UnAllowStdItemsList[I].Idx == nItemIdx)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TEnvirnoment.AllowStdItems Code:1");
            }
            return result;
        }

        /// <summary>
        /// 是否允许使用魔法
        /// </summary>
        /// <param name="sMagName"></param>
        /// <returns></returns>
        public bool AllowMagics(string sMagName)
        {
            bool result = true;
            if (!m_boUnAllowMagics)
            {
                return result;
            }
            if (m_UnAllowMagicList.Count > 0)
            {
                for (int I = 0; I < m_UnAllowMagicList.Count; I++)
                {
                    if ((m_UnAllowMagicList[I].MagicName).ToLower().CompareTo((sMagName).ToLower()) == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 是否允许使用魔法
        /// </summary>
        /// <param name="nMagIdx"></param>
        /// <returns></returns>
        public bool AllowMagics(int nMagIdx)
        {
            bool result = true;
            if (!m_boUnAllowMagics)
            {
                return result;
            }
            if (m_UnAllowMagicList.Count > 0)
            {
                for (int I = 0; I < m_UnAllowMagicList.Count; I++)
                {
                    if (m_UnAllowMagicList[I].Idx == nMagIdx)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 增加门到地图上
        /// </summary>
        public void AddDoorToMap()
        {
            if (m_DoorList.Count > 0)
            {
                foreach (var Door in this.m_DoorList)
                {
                    AddToMap(Door.nX, Door.nY, Grobal2.OS_DOOR, Door);
                }
            }
        }

        /// <summary>
        /// 修改地图标识
        /// </summary>
        /// <param name="n24"></param>
        /// <param name="nH"></param>
        /// <param name="chFlag"></param>
        public void UpdateMapCellFlag(int n24, int nH, byte chFlag)
        {
            try
            {
                if (MapCellInfoArray != null)
                {
                    MapCellInfoArray[n24 + nH].chFlag = chFlag;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 更新地图路径数组信息
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="MapCellInfo"></param>
        public void UpdateMapCellInfo(int nX, int nY, TMapCellinfo MapCellInfo)
        {
            try
            {
                if (MapCellInfoArray == null)
                {
                    return;
                }
                if ((nX >= 0) && (nX < m_nWidth) && (nY >= 0) && (nY < m_nHeight))
                {
                    MapCellInfoArray[nX * m_nHeight + nY] = MapCellInfo;
                }
            }
            catch
            {
            }
        }



        public TMapCellinfo GetMapCellInfo(int nX, int nY)
        {
            TMapCellinfo MapCellInfo = new TMapCellinfo();

            if (MapCellInfoArray == null)
            {
                //return MapCellInfo;
            }
            try
            {
                if ((nX >= 0) && (nX < m_nWidth) && (nY >= 0) && (nY < m_nHeight))
                {
                    MapCellInfo = MapCellInfoArray[nX * m_nHeight + nY];
                }
            }
            catch
            {
            }
            return MapCellInfo;
        }
        /// <summary>
        /// 取地图路径数组信息
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="MapCellInfo"></param>
        /// <returns></returns>
        public bool CanGetMapCellInfo(int nX, int nY, ref TMapCellinfo MapCellInfo)
        {
            bool result = false;
            try
            {
                if (MapCellInfoArray == null)
                {
                    return result;
                }
                if ((nX >= 0) && (nX < m_nWidth) && (nY >= 0) && (nY < m_nHeight))
                {
                    MapCellInfo = MapCellInfoArray[nX * m_nHeight + nY];
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch
            {
            }
            return result;
        }

        public int MoveToMovingObject(int nCX, int nCY, TBaseObject Cert, int nX, int nY, bool boFlag)
        {
            int result = 0;
            TMapCellinfo MapCellInfo;
            TBaseObject BaseObject;
            TOSObject OSObject = null;
            bool bo1A = true;
            byte nCode = 0;
            try
            {
                MapCellInfo = new TMapCellinfo();
                if (!boFlag && CanGetMapCellInfo(nX, nY, ref MapCellInfo))
                {
                    if (MapCellInfo.chFlag == 0)
                    {
                        if (MapCellInfo.ObjList != null)
                        {
                            if (MapCellInfo.ObjList.Count > 0)
                            {
                                for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                                {
                                    if (MapCellInfo.ObjList[I] != null)
                                    {
                                        if (MapCellInfo.ObjList[I].btType == Grobal2.OS_MOVINGOBJECT)
                                        {
                                            BaseObject = (TBaseObject)MapCellInfo.ObjList[I].CellObj;
                                            if (BaseObject != null)
                                            {
                                                // 检测移动地点是否有人物
                                                if (!BaseObject.m_boGhost && BaseObject.bo2B9 && !BaseObject.m_boDeath && !BaseObject.m_boFixedHideMode
                                                    && !BaseObject.m_boObMode)
                                                {
                                                    bo1A = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        result = -1;
                        bo1A = false;
                    }
                }
                if (bo1A)
                {
                    if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.chFlag != 0))
                    {
                        result = -1;
                    }
                    else
                    {
                        if (CanGetMapCellInfo(nCX, nCY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                        {
                            int I = 0;
                            nCode = 1;
                            while (true)
                            {
                                if (MapCellInfo.ObjList.Count <= I)
                                {
                                    break;
                                }
                                OSObject = MapCellInfo.ObjList[I];
                                if ((OSObject != null))
                                {
                                    if ((OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                    {
                                        if ((OSObject.CellObj) == ((TBaseObject)(Cert)))
                                        {
                                            nCode = 5;
                                            MapCellInfo.ObjList.RemoveAt(I);
                                            nCode = 6;
                                            if ((OSObject != null))
                                            {
                                                Dispose(OSObject);
                                            }
                                            nCode = 7;
                                            if (MapCellInfo.ObjList.Count > 0)
                                            {
                                                continue;
                                            }
                                            nCode = 8;
                                            if (MapCellInfo.ObjList != null)
                                            {
                                                MapCellInfo.ObjList = null;
                                                UpdateMapCellInfo(nCX, nCY, MapCellInfo);
                                            }
                                            break;
                                        }
                                    }
                                }
                                I++;
                            }
                        }
                        if (CanGetMapCellInfo(nX, nY, ref MapCellInfo))
                        {
                            nCode = 9;
                            if ((MapCellInfo.ObjList == null))
                            {
                                MapCellInfo.ObjList = new List<TOSObject>();
                            }
                            nCode = 10;
                            try
                            {
                                OSObject = new TOSObject();
                                OSObject.btType = Grobal2.OS_MOVINGOBJECT;
                                OSObject.CellObj = Cert;
                                OSObject.dwAddTime = HUtil32.GetTickCount();
                                nCode = 11;
                                MapCellInfo.ObjList.Add(OSObject);
                                UpdateMapCellInfo(nX, nY, MapCellInfo);
                            }
                            catch
                            {
                                Dispose(OSObject);
                            }
                            result = 1;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TEnvirnoment::MoveToMovingObject Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// 检查地图指定座标是否可以移动
        /// boFlag  如果为TRUE 则忽略座标上是否有角色
        /// 返回值 True 为可以移动，False 为不可以移动
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="boFlag"></param>
        /// <returns></returns>
        public bool CanWalk(int nX, int nY, bool boFlag)
        {
            bool result = false;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            if (!CanGetMapCellInfo(nX, nY, ref MapCellInfo) || (MapCellInfo.chFlag != 0))
            {
                return result;
            }

            result = true;
            if (boFlag || (MapCellInfo.ObjList == null))
            {
                return result;
            }

            if (MapCellInfo.ObjList.Count <= 0)
            {
                return result;
            }

            for (int i = 0; i < MapCellInfo.ObjList.Count; i++)
            {
                OSObject = MapCellInfo.ObjList[i];
                if ((OSObject == null) || (OSObject.btType != Grobal2.OS_MOVINGOBJECT))
                {
                    continue;
                }

                BaseObject = (TBaseObject)OSObject.CellObj;
                if (BaseObject == null)
                {
                    continue;
                }

                if (!BaseObject.m_boGhost && BaseObject.bo2B9 && !BaseObject.m_boDeath && !BaseObject.m_boFixedHideMode && !BaseObject.m_boObMode)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 检查地图指定座标是否可以移动
        /// boFlag  如果为TRUE 则忽略座标上是否有角色
        /// 返回值 True 为可以移动，False 为不可以移动
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="boFlag"></param>
        /// <param name="boItem"></param>
        /// <returns></returns>
        public bool CanWalkOfItem(int nX, int nY, bool boFlag, bool boItem)
        {
            bool result = true;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.chFlag == 0))
            {
                if ((MapCellInfo.ObjList != null))
                {
                    if (MapCellInfo.ObjList.Count > 0)
                    {
                        for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                        {
                            OSObject = MapCellInfo.ObjList[I];
                            if (!boFlag && (OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                            {
                                BaseObject = (TBaseObject)OSObject.CellObj;
                                if (BaseObject != null)
                                {
                                    if (!BaseObject.m_boGhost && BaseObject.bo2B9 && !BaseObject.m_boDeath && !BaseObject.m_boFixedHideMode && !BaseObject.m_boObMode)
                                    {
                                        result = false;
                                        break;
                                    }
                                }
                            }
                            if (!boItem && (OSObject.btType == Grobal2.OS_ITEMOBJECT))
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool CanWalkEx(int nX, int nY, bool boFlag)
        {
            bool result = false;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            TUserCastle Castle;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.chFlag == 0))
            {
                result = true;
                if (!boFlag && (MapCellInfo.ObjList != null))
                {
                    if (MapCellInfo.ObjList.Count > 0)
                    {
                        for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                        {
                            OSObject = MapCellInfo.ObjList[I];
                            if (OSObject != null)
                            {
                                if (OSObject.btType == Grobal2.OS_MOVINGOBJECT)
                                {
                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                    if (BaseObject != null)
                                    {
                                        Castle = M2Share.g_CastleManager.InCastleWarArea(BaseObject);
                                        if (M2Share.g_Config.boWarDisHumRun && (Castle != null) && (Castle.m_boUnderWar))
                                        {
                                        }
                                        else
                                        {
                                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                if (M2Share.g_Config.boRUNHUMAN || m_boRUNHUMAN)
                                                {
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                if (BaseObject.m_btRaceServer == Grobal2.RC_NPC)
                                                {
                                                    if (M2Share.g_Config.boRunNpc)
                                                    {
                                                        continue;
                                                    }
                                                }
                                                else
                                                {
                                                    if (new ArrayList(new object[] { Grobal2.RC_GUARD, Grobal2.RC_ARCHERGUARD }).Contains(BaseObject.m_btRaceServer))
                                                    {
                                                        if (M2Share.g_Config.boRunGuard)
                                                        {
                                                            continue;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (BaseObject.m_btRaceServer != 55) // 不允许穿过练功师
                                                        {
                                                            if (M2Share.g_Config.boRUNMON || m_boRUNMON)
                                                            {
                                                                continue;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (!BaseObject.m_boGhost && BaseObject.bo2B9 && !BaseObject.m_boDeath && !BaseObject.m_boFixedHideMode
                                            && !BaseObject.m_boObMode)
                                        {
                                            result = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 从地图删除指定对象
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="btType"></param>
        /// <param name="pRemoveObject"></param>
        /// <returns></returns>
        public int DeleteFromMap(int nX, int nY, byte btType, object pRemoveObject)
        {
            int result = -1;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            int n18;
            byte btRaceServer;
            const string sExceptionMsg1 = "{异常} TEnvirnoment::DeleteFromMap -> Except 1 ** {0}";
            const string sExceptionMsg2 = "{异常} TEnvirnoment::DeleteFromMap -> Except 2 ** {0}";
            try
            {
                MapCellInfo = new TMapCellinfo();
                if (CanGetMapCellInfo(nX, nY, ref MapCellInfo))
                {
                    if (MapCellInfo.ObjList != null)
                    {
                        try
                        {
                            if (MapCellInfo.ObjList != null)
                            {
                                n18 = 0;
                                while (true)
                                {
                                    if (MapCellInfo.ObjList.Count <= 0)
                                    {
                                        MapCellInfo.ObjList = null;
                                        UpdateMapCellInfo(nX, nY, MapCellInfo);
                                        break;
                                    }
                                    if (MapCellInfo.ObjList.Count <= n18)
                                    {
                                        break;
                                    }
                                    OSObject = MapCellInfo.ObjList[n18];
                                    if (OSObject != null)
                                    {
                                        if ((OSObject.btType == btType) && (OSObject.CellObj == pRemoveObject))
                                        {
                                            result = 1;
                                            Dispose(OSObject);
                                            MapCellInfo.ObjList.RemoveAt(n18);
                                            BaseObject = ((TBaseObject)(pRemoveObject));
                                            if ((btType == Grobal2.OS_MOVINGOBJECT) && (!BaseObject.m_boDelFormMaped)) // 减地图人物怪物计数
                                            {
                                                BaseObject.m_boDelFormMaped = true;
                                                BaseObject.m_boAddToMaped = false;
                                                btRaceServer = BaseObject.m_btRaceServer;
                                                if (btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                {
                                                    m_nHumCount -= 1;
                                                }
                                                if (btRaceServer >= Grobal2.RC_ANIMAL)
                                                {
                                                    m_nMonCount -= 1;
                                                }
                                            }
                                            if (MapCellInfo.ObjList.Count <= 0)
                                            {
                                                MapCellInfo.ObjList = null;
                                                UpdateMapCellInfo(nX, nY, MapCellInfo);
                                                break;
                                            }
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        MapCellInfo.ObjList.RemoveAt(n18);
                                        if (MapCellInfo.ObjList.Count > 0)
                                        {
                                            continue;
                                        }
                                        if (MapCellInfo.ObjList.Count <= 0)
                                        {
                                            MapCellInfo.ObjList = null;
                                            UpdateMapCellInfo(nX, nY, MapCellInfo);
                                            break;
                                        }
                                    }
                                    n18++;
                                }
                            }
                            else
                            {
                                result = -2;
                            }
                        }
                        catch
                        {
                            OSObject = null;
                            M2Share.MainOutMessage(string.Format(sExceptionMsg1, btType));
                        }
                    }
                    else
                    {
                        result = -3;
                    }
                }
                else
                {
                    result = 0;
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg2, btType));
            }
            return result;
        }

        public TMapItem GetItem(int nX, int nY)
        {
            TMapItem result;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            result = null;
            bo2C = false;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.chFlag == 0))
            {
                bo2C = true;
                if (MapCellInfo.ObjList != null)
                {
                    if (MapCellInfo.ObjList.Count > 0)
                    {
                        for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                        {
                            OSObject = MapCellInfo.ObjList[I];
                            if (OSObject != null)
                            {
                                if (OSObject.btType == Grobal2.OS_ITEMOBJECT)
                                {
                                    result = (TMapItem)OSObject.CellObj;
                                    return result;
                                }
                                if (OSObject.btType == Grobal2.OS_GATEOBJECT)
                                {
                                    bo2C = false;
                                }
                                if (OSObject.btType == Grobal2.OS_MOVINGOBJECT)
                                {
                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                    if (!BaseObject.m_boDeath)
                                    {
                                        bo2C = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool IsCheapStuff()
        {
            bool result;
            if (m_QuestList.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


        /// <summary>
        /// 添加矿石到地图事件
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nType"></param>
        /// <param name="__Event"></param>
        public void AddToMapMineEvent(int nX, int nY, int nType, TEvent __Event)
        {
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            bool bo19;
            bool bo1A;
            const string sExceptionMsg = "{异常} TEnvirnoment::AddToMapMineEvent ";
            try
            {
                MapCellInfo = new TMapCellinfo();
                bo19 = CanGetMapCellInfo(nX, nY, ref MapCellInfo);
                bo1A = false;
                if (bo19 && (MapCellInfo.chFlag != 0))
                {
                    if (MapCellInfo.ObjList == null)
                    {
                        MapCellInfo.ObjList = new List<TOSObject>();
                    }
                    if (!bo1A)
                    {
                        OSObject = new TOSObject();
                        OSObject.btType = (byte)nType;
                        OSObject.CellObj = __Event;
                        OSObject.dwAddTime = HUtil32.GetTickCount();
                        MapCellInfo.ObjList.Add(OSObject);
                        UpdateMapCellInfo(nX, nY, MapCellInfo);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        /// <summary>
        /// 刷新在地图上位置的时间
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="BaseObject"></param>
        public void VerifyMapTime(int nX, int nY, TBaseObject BaseObject)
        {
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            bool boVerify;
            const string sExceptionMsg = "{异常} TEnvirnoment::VerifyMapTime";
            try
            {
                boVerify = false;
                MapCellInfo = new TMapCellinfo();
                if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.ObjList != null) && (MapCellInfo.ObjList != null))
                {
                    if (MapCellInfo.ObjList.Count > 0)
                    {
                        for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                        {
                            OSObject = MapCellInfo.ObjList[I];
                            if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT) && (OSObject.CellObj == BaseObject))
                            {
                                OSObject.dwAddTime = HUtil32.GetTickCount();
                                boVerify = true;
                                break;
                            }
                        }
                    }
                }
                if (!boVerify)
                {
                    AddToMap(nX, nY, Grobal2.OS_MOVINGOBJECT, BaseObject);
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        public bool CreateQuest(int nFlag, int nValue, string s24, string s28, string s2C, bool boGrouped)
        {
            bool result;
            TMapQuestInfo MapQuest;
            TMerchant MapMerchant;
            result = false;
            if (nFlag < 0)
            {
                return result;
            }
            MapQuest = new TMapQuestInfo();
            MapQuest.nFlag = nFlag;
            if (nValue > 1)
            {
                nValue = 1;
            }
            MapQuest.nValue = nValue;
            if (s24 == "*")
            {
                s24 = "";
            }
            MapQuest.s08 = s24;
            if (s28 == "*")
            {
                s28 = "";
            }
            MapQuest.s0C = s28;
            if (s2C == "*")
            {
                s2C = "";
            }
            MapQuest.bo10 = boGrouped;
            MapMerchant = new TMerchant();
            MapMerchant.m_sMapName = "0";
            MapMerchant.m_nCurrX = 0;
            MapMerchant.m_nCurrY = 0;
            MapMerchant.m_sCharName = s2C;
            MapMerchant.m_nFlag = 0;
            MapMerchant.m_wAppr = 0;
            MapMerchant.m_sFilePath = "MapQuest_def\\";
            MapMerchant.m_boIsHide = true;
            MapMerchant.m_boIsQuest = false;
            M2Share.UserEngine.QuestNPCList.Add(MapMerchant);
            MapQuest.NPC = MapMerchant;
            m_QuestList.Add(MapQuest);
            result = true;
            return result;
        }

        public int GetXYObjCount(int nX, int nY)
        {
            int result = 0;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
            {
                if (MapCellInfo.ObjList.Count > 0)
                {
                    for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                    {
                        OSObject = MapCellInfo.ObjList[I];
                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                        {
                            BaseObject = (TBaseObject)OSObject.CellObj;
                            if (BaseObject != null)
                            {
                                if (!BaseObject.m_boGhost && BaseObject.bo2B9 && !BaseObject.m_boDeath && !BaseObject.m_boFixedHideMode && !BaseObject.m_boObMode)
                                {
                                    result++;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool GetNextPosition(int sX, int sY, int nDir, int nFlag, ref int snx, ref int sny)
        {
            bool result;
            snx = sX;
            sny = sY;
            switch (nDir)
            {
                case Grobal2.DR_UP:// 0
                    if (sny > nFlag - 1)
                    {
                        sny -= nFlag;
                    }
                    break;
                case Grobal2.DR_DOWN:// 4
                    if (sny < (m_nHeight - nFlag))
                    {
                        sny += nFlag;
                    }
                    break;
                case Grobal2.DR_LEFT:// 6
                    if (snx > nFlag - 1)
                    {
                        snx -= nFlag;
                    }
                    break;
                case Grobal2.DR_RIGHT:// 2
                    if (snx < (m_nWidth - nFlag))
                    {
                        snx += nFlag;
                    }
                    break;
                case Grobal2.DR_UPLEFT:// 7
                    if ((snx > nFlag - 1) && (sny > nFlag - 1))
                    {
                        snx -= nFlag;
                        sny -= nFlag;
                    }
                    break;
                case Grobal2.DR_UPRIGHT:// 1
                    if ((snx > nFlag - 1) && (sny < (m_nHeight - nFlag)))
                    {
                        snx += nFlag;
                        sny -= nFlag;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:// 5
                    if ((snx < (m_nWidth - nFlag)) && (sny > nFlag - 1))
                    {
                        snx -= nFlag;
                        sny += nFlag;
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:// 3
                    if ((snx < (m_nWidth - nFlag)) && (sny < (m_nHeight - nFlag)))
                    {
                        snx += nFlag;
                        sny += nFlag;
                    }
                    break;
            }
            if ((snx == sX) && (sny == sY))
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 能安全的走 判断地面上有没有火墙 
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public bool CanSafeWalk(int nX, int nY)
        {
            bool result = false;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
            {
                if (MapCellInfo.ObjList.Count > 0)
                {
                    for (int I = MapCellInfo.ObjList.Count - 1; I >= 0; I--)
                    {
                        OSObject = MapCellInfo.ObjList[I];
                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_EVENTOBJECT))
                        {
                            if (((TEvent)(OSObject.CellObj)).m_nDamage > 0)
                            {
                                result = false;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool ArroundDoorOpened(int nX, int nY)
        {
            bool result = true;
            TDoorInfo Door;
            const string sExceptionMsg = "{异常} TEnvirnoment::ArroundDoorOpened ";
            try
            {
                if (m_DoorList.Count > 0)
                {
                    foreach (var item in this.m_DoorList)
                    {
                        Door = item;
                        if ((Math.Abs(Door.nX - nX) <= 1) && ((Math.Abs(Door.nY - nY) <= 1)))
                        {
                            if (!Door.Status.boOpened)
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            return result;
        }

        public TBaseObject GetMovingObject(int nX, int nY, bool boFlag)
        {
            TBaseObject result = null;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
            {
                if (MapCellInfo.ObjList.Count > 0)
                {
                    foreach (var item in MapCellInfo.ObjList)
                    {
                        OSObject = item;
                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                        {
                            BaseObject = (TBaseObject)OSObject.CellObj;
                            if (((BaseObject != null) && (!BaseObject.m_boGhost) && (BaseObject.bo2B9)) && (!boFlag || (!BaseObject.m_boDeath)))
                            {
                                result = BaseObject;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 取地图任务NPC
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="boFlag"></param>
        /// <returns></returns>
        public Object GetQuestNPC(Object BaseObject, string sCharName, string sStr, bool boFlag)
        {
            Object result = null;
            TMapQuestInfo MapQuestFlag;
            int nFlagValue;
            bool bo1D;
            try
            {
                if (m_QuestList.Count > 0)
                {
                    foreach (var item in this.m_QuestList)
                    {
                        MapQuestFlag = item;
                        nFlagValue = ((TBaseObject)(BaseObject)).GetQuestFalgStatus(MapQuestFlag.nFlag);
                        if (nFlagValue == MapQuestFlag.nValue)
                        {
                            if ((boFlag == MapQuestFlag.bo10) || !boFlag)
                            {
                                bo1D = false;
                                if ((MapQuestFlag.s08 != "") && (MapQuestFlag.s0C != ""))
                                {
                                    if ((MapQuestFlag.s08 == sCharName) && (MapQuestFlag.s0C == sStr))
                                    {
                                        bo1D = true;
                                    }
                                }
                                if ((MapQuestFlag.s08 != "") && (MapQuestFlag.s0C == ""))
                                {
                                    if ((MapQuestFlag.s08 == sCharName) && (sStr == ""))
                                    {
                                        bo1D = true;
                                    }
                                }
                                if ((MapQuestFlag.s08 == "") && (MapQuestFlag.s0C != ""))
                                {
                                    if ((MapQuestFlag.s0C == sStr))
                                    {
                                        bo1D = true;
                                    }
                                }
                                if (bo1D)
                                {
                                    result = MapQuestFlag.NPC;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return result;
        }

        public object GetItemEx(int nX, int nY, ref int nCount)
        {
            object result;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            result = null;
            nCount = 0;
            bo2C = false;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.chFlag == 0))
            {
                bo2C = true;
                if (MapCellInfo.ObjList != null)
                {
                    if (MapCellInfo.ObjList.Count > 0)
                    {
                        foreach (var item in MapCellInfo.ObjList)
                        {
                            OSObject = item;
                            if (OSObject != null)
                            {
                                if (OSObject.btType == Grobal2.OS_ITEMOBJECT)
                                {
                                    result = OSObject.CellObj;
                                    nCount++;
                                }
                                if (OSObject.btType == Grobal2.OS_GATEOBJECT)
                                {
                                    bo2C = false;
                                }
                                if (OSObject.btType == Grobal2.OS_MOVINGOBJECT)
                                {
                                    BaseObject = ((TBaseObject)(OSObject.CellObj));
                                    if (!BaseObject.m_boDeath)
                                    {
                                        bo2C = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 取地图上的门
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public TDoorInfo GetDoor(int nX, int nY)
        {
            TDoorInfo result = null;
            TDoorInfo Door;
            if (m_DoorList.Count > 0)
            {
                foreach (var item in m_DoorList)
                {
                    Door = item;
                    if ((Door.nX == nX) && (Door.nY == nY))
                    {
                        result = Door;
                        return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 判断目标是否有效果(用于挖尸体时的判断)
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRage"></param>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public bool IsValidObject(int nX, int nY, int nRage, TBaseObject BaseObject)
        {
            bool result = false;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            for (int nXX = nX - nRage; nXX <= nX + nRage; nXX++)
            {
                for (int nYY = nY - nRage; nYY <= nY + nRage; nYY++)
                {
                    if (CanGetMapCellInfo(nXX, nYY, ref MapCellInfo))//修正挖普通怪，无法挖到
                    {
                        if ((MapCellInfo.ObjList != null))
                        {
                            if (MapCellInfo.ObjList.Count > 0)
                            {
                                foreach (var item in MapCellInfo.ObjList)
                                {
                                    OSObject = item;
                                    if ((OSObject != null))
                                    {
                                        if ((OSObject.CellObj == BaseObject))
                                        {
                                            result = true;
                                            return result;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public int GetRangeBaseObject(int nX, int nY, int nRage, bool boFlag, IList<TPlayObject> BaseObjectList)
        {
            for (int nXX = nX - nRage; nXX <= nX + nRage; nXX++)
            {
                for (int nYY = nY - nRage; nYY <= nY + nRage; nYY++)
                {
                    GeTBaseObjects(nXX, nYY, boFlag, BaseObjectList);
                }
            }
            return BaseObjectList.Count();
        }

        /// <summary>
        /// 取范围内的对像
        /// boFlag 是否包括死亡对象
        /// FALSE 包括死亡对象
        /// TRUE  不包括死亡对象
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="boFlag"></param>
        /// <param name="BaseObjectList"></param>
        /// <returns></returns>
        public int GeTBaseObjects(int nX, int nY, bool boFlag, IList<TPlayObject> BaseObjectList)
        {
            int result;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
            {
                if (MapCellInfo.ObjList.Count > 0)
                {
                    foreach (var item in MapCellInfo.ObjList)
                    {
                        OSObject = item;
                        if ((OSObject != null))
                        {
                            if ((OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                            {
                                BaseObject = (TBaseObject)OSObject.CellObj;
                                if (BaseObject != null)
                                {
                                    if (!BaseObject.m_boGhost && BaseObject.bo2B9)
                                    {
                                        if (!boFlag || !BaseObject.m_boDeath)
                                        {
                                            BaseObjectList.Add((TPlayObject)BaseObject);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            result = BaseObjectList.Count;
            return result;
        }

        /// <summary>
        /// 取指定地图范围内里的物品
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRage"></param>
        /// <param name="BaseObjectList"></param>
        /// <returns></returns>
        public int GetMapItem(int nX, int nY, int nRage, List<TMapItem> BaseObjectList)
        {
            int result;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TMapItem MapItem;
            int nXX;
            int nYY;
            for (nXX = nX - nRage; nXX <= nX + nRage; nXX++)
            {
                for (nYY = nY - nRage; nYY <= nY + nRage; nYY++)
                {
                    if (CanGetMapCellInfo(nXX, nYY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                    {
                        if (MapCellInfo.ObjList.Count > 0)
                        {
                            foreach (var item in MapCellInfo.ObjList)
                            {
                                OSObject = item;
                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_ITEMOBJECT))
                                {
                                    MapItem = (TMapItem)item.CellObj;
                                    if (MapItem.Name != "")
                                    {
                                        BaseObjectList.Add(MapItem);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            result = BaseObjectList.Count;
            return result;
        }

        /// <summary>
        /// 获取事件
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public TEvent GetEvent(int nX, int nY)
        {
            TEvent result = null;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            bo2C = false;
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
            {
                if (MapCellInfo.ObjList.Count > 0)
                {
                    foreach (var item in MapCellInfo.ObjList)
                    {
                        OSObject = item;
                        if ((OSObject != null))
                        {
                            if ((OSObject.btType == Grobal2.OS_EVENTOBJECT))
                            {
                                result = (TEvent)OSObject.CellObj;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void SetMapXYFlag(int nX, int nY, bool boFlag)
        {
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo))
            {
                if (boFlag)
                {
                    MapCellInfo.chFlag = 0;
                }
                else
                {
                    MapCellInfo.chFlag = 2;
                }
            }
        }

        public bool CanFly(int nSX, int nSY, int nDX, int nDY)
        {
            bool result;
            double r28;
            double r30;
            int n14;
            int n18;
            int n1C;
            result = true;
            r28 = (nDX - nSX) / 1.0E1;
            r30 = (nDY - nDX) / 1.0E1;
            n14 = 0;
            while (true)
            {
                n18 = (int)HUtil32.Round(nSX + r28);
                n1C = (int)HUtil32.Round(nSY + r30);
                if (!CanWalk(n18, n1C, true))
                {
                    result = false;
                    break;
                }
                n14++;
                if (n14 >= 10)
                {
                    break;
                }
            }
            return result;
        }

        public bool GetXYHuman(int nMapX, int nMapY)
        {
            bool result = false;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nMapX, nMapY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
            {
                if (MapCellInfo.ObjList.Count > 0)
                {
                    foreach (var item in MapCellInfo.ObjList)
                    {
                        OSObject = item;
                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                        {
                            BaseObject = (TBaseObject)OSObject.CellObj;
                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool sub_4B5FC8(int nX, int nY)
        {
            bool result = true;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            if (CanGetMapCellInfo(nX, nY, ref MapCellInfo) && (MapCellInfo.chFlag == 2))
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 取地图信息
        /// </summary>
        /// <returns></returns>
        public string GetEnvirInfo()
        {
            string result;
            string sMsg;
            sMsg = "地图名:{0}({1}) DAY:{2} DARK:{3} SAFE:{4} FIGHT:{5} FIGHT3:{6} QUIZ:{7} NORECONNECT:{8}({9}) MUSIC:{10}({11}) EXPRATE:{12}({13}) PKWINLEVEL:{14}({15}) ";
            sMsg = sMsg + " PKLOSTLEVEL:{16}({17}) PKWINEXP:{18}({19}) PKLOSTEXP:{20}({21}) DECHP:{22}({23}/{24}) INCHP:{25}({26}/{27})";
            sMsg = sMsg + " DECGAMEGOLD:{28}({29}/{30}) INCGAMEGOLD:{31}({32}/{33}) INCGAMEPOINT:{34}({35}/{36}) DECGAMEPOINT:{37}({38}/{39}) RUNHUMAN:{40} RUNMON:{41} NEEDHOLE:{42}";
            sMsg = sMsg + " NORECALL:{43} NOGUILDRECALL:{44} NODEARRECALL:{45} NOMASTERRECALL:{46} NODRUG:{47} MINE:{48} NOPOSITIONMOVE:{49} NOCALLHERO:{50} MISSION:{51}";
            result = string.Format(sMsg, sMapName, sMapDesc, HUtil32.BoolToCStr(m_boDAY), HUtil32.BoolToCStr(m_boDARK), HUtil32.BoolToCStr(m_boSAFE), HUtil32.BoolToCStr(m_boFightZone),
                HUtil32.BoolToCStr(m_boFight3Zone), HUtil32.BoolToCStr(m_boQUIZ), HUtil32.BoolToCStr(m_boNORECONNECT), sNoReconnectMap, HUtil32.BoolToCStr(m_boMUSIC), m_nMUSICID,
                HUtil32.BoolToCStr(m_boEXPRATE), m_nEXPRATE / 100, HUtil32.BoolToCStr(m_boPKWINLEVEL), m_nPKWINLEVEL, HUtil32.BoolToCStr(m_boPKLOSTLEVEL), m_nPKLOSTLEVEL,
                HUtil32.BoolToCStr(m_boPKWINEXP), m_nPKWINEXP, HUtil32.BoolToCStr(m_boPKLOSTEXP), m_nPKLOSTEXP, HUtil32.BoolToCStr(m_boDECHP), m_nDECHPTIME, m_nDECHPPOINT,
                HUtil32.BoolToCStr(m_boINCHP), m_nINCHPTIME, m_nINCHPPOINT, HUtil32.BoolToCStr(m_boDecGameGold), m_nDECGAMEGOLDTIME, m_nDecGameGold, HUtil32.BoolToCStr(m_boIncGameGold),
                m_nINCGAMEGOLDTIME, m_nIncGameGold, HUtil32.BoolToCStr(m_boINCGAMEPOINT), m_nINCGAMEPOINTTIME, m_nINCGAMEPOINT, HUtil32.BoolToCStr(m_boDECGAMEPOINT),
                m_nDECGAMEPOINTTIME, m_nDECGAMEPOINT, HUtil32.BoolToCStr(m_boRUNHUMAN), HUtil32.BoolToCStr(m_boRUNMON), HUtil32.BoolToCStr(m_boNEEDHOLE),
                HUtil32.BoolToCStr(m_boNORECALL), HUtil32.BoolToCStr(m_boNOGUILDRECALL), HUtil32.BoolToCStr(m_boNODEARRECALL), HUtil32.BoolToCStr(m_boNOMASTERRECALL),
                HUtil32.BoolToCStr(m_boNODRUG), HUtil32.BoolToCStr(m_boMINE), HUtil32.BoolToCStr(m_boNOPOSITIONMOVE), HUtil32.BoolToCStr(m_boNOCALLHERO),
                HUtil32.BoolToCStr(m_boMISSION));
            return result;
        }

        public void AddObject(TBaseObject ActorObject)
        {
            byte btRaceServer;
            try
            {
                switch (ActorObject.m_ObjType)
                {
                    case TObjType.t_Play:
                        btRaceServer = ActorObject.m_btRaceServer;
                        if (btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            m_nHumCount++;
                            M2Share.g_MapManager.m_nHumCount++;
                        }
                        else if ((new ArrayList(new byte[] { Grobal2.RC_NPC, Grobal2.RC_PEACENPC }).Contains(btRaceServer)))
                        {
                            m_nNpcCount++;
                            M2Share.g_MapManager.m_nNpcCount++;
                        }
                        else
                        {
                            m_nMonCount++;
                            M2Share.g_MapManager.m_nMonCount++;
                        }
                        break;
                    case TObjType.t_Item:
                        m_nItemCount++;
                        M2Share.g_MapManager.m_nItemCount++;
                        break;
                }
            }
            catch (Exception ex)
            {
                M2Share.MainOutMessage("[Exception] TEnvirnoment::AddObject");
            }
        }

        public void DelObject(TBaseObject ActorObject)
        {
            byte btRaceServer;
            try
            {
                switch (ActorObject.m_ObjType)
                {
                    case TObjType.t_Event:
                        //m_nEventCount -= 1;
                        //M2Share.g_MapManager.m_nEventCount -= 1;
                        break;
                    case TObjType.t_Gate:
                        //m_nGateCount -= 1;
                        //M2Share.g_MapManager.m_nGateCount -= 1;
                        break;
                    case TObjType.t_Item:
                        m_nItemCount -= 1;
                        M2Share.g_MapManager.m_nItemCount -= 1;
                        break;
                    case TObjType.t_Play:
                        btRaceServer = ((TPlayObject)(ActorObject)).m_btRaceServer;
                        if (btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            m_nHumCount -= 1;
                            M2Share.g_MapManager.m_nHumCount -= 1;
                        }
                        else if (btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            //m_nHeroCount -= 1;
                            //M2Share.g_MapManager.m_nHeroCount -= 1;
                        }
                        else if ((new ArrayList(new int[] { Grobal2.RC_NPC, Grobal2.RC_PEACENPC }).Contains(btRaceServer)))
                        {
                            m_nNpcCount -= 1;
                            M2Share.g_MapManager.m_nNpcCount -= 1;
                        }
                        else
                        {
                            m_nMonCount -= 1;
                            M2Share.g_MapManager.m_nMonCount -= 1;
                        }
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage("[Exception] TEnvirnoment::DelObject");
            }
        }

        public void DelObjectCount(object BaseObject)
        {
            byte btRaceServer = ((TBaseObject)(BaseObject)).m_btRaceServer;
            if (btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                m_nHumCount -= 1;
            }
            if (btRaceServer >= Grobal2.RC_ANIMAL)
            {
                m_nMonCount -= 1;
            }
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}
