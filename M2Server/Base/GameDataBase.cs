using GameFramework;
using GameFramework.DataBase;
using GameFramework.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

namespace M2Server.Base
{
    public class GameDataBase : GameBase
    {
        /// <summary>
        /// 数据库会话管理
        /// </summary>
        private DbSession DBsession;

        public GameDataBase()
        {
            InitGameData();
        }

        /// <summary>
        /// 初始化游戏数据库
        /// </summary>
        private void InitGameData()
        {
            try
            {
                var obj = (SqlServer2005Repository)Activator.CreateInstance(typeof(SqlServer2005Repository), "Mir2");
                DBsession = obj.GetDbSession();
            }
            catch
            {
                MainOutMessage("初始化数据库失败...");
            }
        }

        /// <summary>
        /// 加载物品数据
        /// </summary>
        /// <returns></returns>
        internal unsafe int LoadItemsDB()
        {
            int result = -1;
            int Idx;
            TStdItem* StdItem;
            IDataReader dr = null;
            const string sSQLString = "SELECT IDX,NAME,STDMODE,SHAPE,WEIGHT,ANICOUNT,SOURCE,RESERVED,LOOKS,DURAMAX,AC,AC2,MAC,MAC2,DC,DC2,MC,MC2,SC,SC2,NEED,NEEDLEVEL,PRICE,STOCK FROM TBL_STDITEMS";
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                try
                {
                    foreach (var item in UserEngine.StdItemList)
                    {
                        if (item != null)
                        {
                            Dispose(item);
                        }
                    }
                    UserEngine.StdItemList.Clear();
                    try
                    {
                        dr = DBsession.ExecuteReader(sSQLString);
                    }
                    catch
                    {
                        MainOutMessage("链接数据库发生异常...");
                    }
                    finally
                    {
                        result = -2;
                    }
                    if (dr == null) //2013.04.16 Fixed dr为空时Read报错
                    {
                        return result;
                    }
                    while (dr.Read())
                    {
                        Idx = dr.GetInt32("Idx");// 序号
                        StdItem = (TStdItem*)Marshal.AllocHGlobal(sizeof(TStdItem));
                        HUtil32.ZeroMemory(StdItem, sizeof(TStdItem));
                        HUtil32.StrToSByteArry(dr.GetString("Name"), StdItem->Name, 14, ref StdItem->NameLen);
                        StdItem->StdMode = dr.GetByte("StdMode");// 分类号
                        StdItem->Shape = dr.GetByte("Shape");// 装备外观
                        StdItem->Weight = dr.GetByte("Weight");// 重量
                        StdItem->AniCount = HUtil32.IntToByte(dr.GetInt32("AniCount"));// 保留
                        StdItem->Source = dr.GetSByte("Source");
                        StdItem->Reserved = HUtil32.IntToByte(dr.GetInt32("Reserved"));// 保留
                        StdItem->Looks = dr.GetUInt16("Looks");// 物品外观
                        StdItem->DuraMax = dr.GetUInt16("DuraMax");// 持久力
                        StdItem->Reserved1 = 0;
                        StdItem->AC = TStdItem.MakeAC(dr.GetInt32("Ac"), dr.GetInt32("Ac2"), GameConfig.nItemsACPowerRate);//物理防御
                        StdItem->MAC = TStdItem.MakeMAC(dr.GetInt32("Mac"), dr.GetInt32("Mac2"), GameConfig.nItemsACPowerRate);//魔法防御
                        StdItem->DC = TStdItem.MakeDC(dr.GetInt32("Dc"), dr.GetInt32("Dc2"), GameConfig.nItemsPowerRate);//物理攻击
                        StdItem->MC = TStdItem.MakeMC(dr.GetInt32("Mc"), dr.GetInt32("Mc2"), GameConfig.nItemsPowerRate);//魔法攻击
                        StdItem->SC = TStdItem.MakeSC(dr.GetInt32("Sc"), dr.GetInt32("Sc2"), GameConfig.nItemsPowerRate);//道术
                        StdItem->Need = dr.GetInt32("Need");// 附加条件
                        StdItem->NeedLevel = dr.GetInt32("NeedLevel");// 需要等级
                        StdItem->Price = dr.GetInt32("Price");// 价格
                        StdItem->Stock = dr.GetInt32("Stock");// 库存
                        StdItem->NeedIdentify = M2Share.GetGameLogItemNameList(dr.GetString("Name"));
                        if (UserEngine.StdItemList.Count == Idx)
                        {
                            UserEngine.StdItemList.Add((IntPtr)StdItem);
                            result = 1;
                        }
                        else
                        {
                            MainOutMessage(string.Format("加载物品[Idx:{0} Name:{1}]数据失败！！！", Idx, dr.GetString("Name")));
                            result = -100;
                            return result;
                        }
                    }
                    M2Share.g_boGameLogGold = M2Share.GetGameLogItemNameList(M2Share.sSTRING_GOLDNAME) == 1;
                    M2Share.g_boGameLogHumanDie = M2Share.GetGameLogItemNameList(GameMsgDef.g_sHumanDieEvent) == 1;
                    M2Share.g_boGameLogGameGold = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameGoldName) == 1;
                    M2Share.g_boGameLogGameDiaMond = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameDiaMond) == 1;// 是否写入日志(调整金刚石)
                    M2Share.g_boGameLogGameGird = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameGird) == 1;// 是否写入日志(调整灵符)
                    M2Share.g_boGameLogGameGlory = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameGlory) == 1;// 是否写入日志(调整荣誉值)
                    M2Share.g_boGameLogGamePoint = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGamePointName) == 1;
                }
                finally
                {
                    if (dr != null)
                    {
                        dr.Close();
                        dr.Dispose();
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }

            return result;
        }

        /// <summary>
        /// 加载魔法数据
        /// </summary>
        /// <returns></returns>
        internal unsafe int LoadMagicDB()
        {
            int result = -1;
            TMagic* Magic = null;
            TMagic* OldMagic = null;
            IList<IntPtr> OldMagicList;
            IDataReader dr = null;
            const string sSQLString = "SELECT MAGID,MAGNAME,EFFECTTYPE,EFFECT,SPELL,POWER,MAXPOWER,JOB,NEEDL1,NEEDL2,NEEDL3,L1TRAIN,L2TRAIN,L3TRAIN,DELAY,DEFSPELL,DEFPOWER,DEFMAXPOWER,DESCR FROM TBL_MAGIC";
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                UserEngine.SwitchMagicList();
                foreach (var item in UserEngine.m_MagicList)
                {
                    if (item != null)
                    {
                        Marshal.FreeHGlobal(item);
                    }
                }
                UserEngine.m_MagicList.Clear();
                try
                {
                    dr = DBsession.ExecuteReader(sSQLString);
                }
                catch
                {
                    MainOutMessage("链接数据库发生异常...");
                }
                finally
                {
                    result = -2;
                }
                if (dr == null) //2013.04.16 Fixed dr为空时Read报错
                {
                    return result;
                }
                while (dr.Read())
                {
                    try
                    {
                        Magic = (TMagic*)Marshal.AllocHGlobal(sizeof(TMagic));
                        HUtil32.ZeroMemory(Magic, sizeof(TMagic));
                        Magic->wMagicId = dr.GetUInt16("MagId");
                        HUtil32.StrToSByteArry(dr.GetString("MagName"), Magic->sMagicName, 12, ref Magic->MagicNameLen);
                        Magic->btEffectType = dr.GetByte("EffectType");
                        Magic->btEffect = dr.GetByte("Effect");
                        Magic->wSpell = dr.GetUInt16("Spell");
                        Magic->wPower = dr.GetUInt16("Power");
                        Magic->wMaxPower = dr.GetUInt16("MaxPower");
                        Magic->btJob = dr.GetByte("Job");
                        Magic->TrainLevel[0] = dr.GetByte("NeedL1");
                        Magic->TrainLevel[1] = dr.GetByte("NeedL2");
                        Magic->TrainLevel[2] = dr.GetByte("NeedL3");
                        Magic->TrainLevel[3] = dr.GetByte("NeedL3");
                        Magic->MaxTrain[0] = dr.GetByte("L1Train");
                        Magic->MaxTrain[1] = dr.GetInt32("L2Train");
                        Magic->MaxTrain[2] = dr.GetInt32("L3Train");
                        Magic->MaxTrain[3] = dr.GetInt32("L2Train");
                        Magic->btTrainLv = 3;
                        Magic->dwDelayTime = dr.GetUInt32("Delay");
                        Magic->btDefSpell = dr.GetByte("DefSpell");
                        Magic->btDefPower = dr.GetByte("DefPower");
                        Magic->btDefMaxPower = dr.GetByte("DefMaxPower");
                        HUtil32.StrToSByteArry(dr.GetString("Descr"), Magic->sDescr, 18, ref Magic->DescrLen);
                        if (Magic->wMagicId > 0)
                        {
                            UserEngine.m_MagicList.Add((IntPtr)Magic);
                        }
                        else
                        {
                            Marshal.FreeHGlobal((IntPtr)Magic);
                        }
                    }
                    catch
                    {
                        result = -100;
                    }
                    result = 1;
                }

                if (UserEngine.OldMagicList.Count > 0)
                {
                    OldMagicList = UserEngine.OldMagicList;
                    if (OldMagicList.Count > 0)
                    {
                        for (int I = 0; I < OldMagicList.Count; I++)
                        {
                            OldMagic = (TMagic*)OldMagicList[I];
                            if (OldMagic->wMagicId >= 100)
                            {
                                Magic->wMagicId = OldMagic->wMagicId;
                                HUtil32.StrToSByteArry(HUtil32.SBytePtrToString(OldMagic->sMagicName, 0, OldMagic->MagicNameLen),
                                    Magic->sMagicName, 12, ref Magic->MagicNameLen);
                                Magic->btEffectType = OldMagic->btEffectType;
                                Magic->btEffect = OldMagic->btEffect;
                                Magic->wSpell = OldMagic->wSpell;
                                Magic->wPower = OldMagic->wPower;
                                Magic->TrainLevel[0] = OldMagic->TrainLevel[0];
                                Magic->TrainLevel[1] = OldMagic->TrainLevel[1];
                                Magic->TrainLevel[2] = OldMagic->TrainLevel[2];
                                Magic->TrainLevel[3] = OldMagic->TrainLevel[3];
                                Magic->MaxTrain[0] = OldMagic->MaxTrain[0];
                                Magic->MaxTrain[1] = OldMagic->MaxTrain[1];
                                Magic->MaxTrain[2] = OldMagic->MaxTrain[2];
                                Magic->MaxTrain[3] = OldMagic->MaxTrain[3];
                                Magic->btTrainLv = OldMagic->btTrainLv;
                                Magic->btJob = OldMagic->btJob;
                                Magic->dwDelayTime = OldMagic->dwDelayTime;
                                Magic->btDefSpell = OldMagic->btDefSpell;
                                Magic->btDefPower = OldMagic->btDefPower;
                                Magic->wMaxPower = OldMagic->wMaxPower;
                                Magic->btDefMaxPower = OldMagic->btDefMaxPower;
                                HUtil32.StrToSByteArry(HUtil32.SBytePtrToString(OldMagic->sDescr, 0, Magic->DescrLen), Magic->sDescr, 18, ref Magic->DescrLen);
                                UserEngine.m_MagicList.Add((IntPtr)Magic);
                            }
                        }
                    }
                    UserEngine.m_boStartLoadMagic = false;
                }
                UserEngine.m_boStartLoadMagic = false;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 加载怪物数据
        /// </summary>
        /// <returns></returns>
        internal int LoadMonsterDB()
        {
            int result = 0;
            TMonInfo Monster;
            IDataReader dr = null;
            const string sSQLString = "SELECT NAME,RACE,RACEIMG,APPR,LVL,UNDEAD,COOLEYE,EXP,HP,MP,AC,MAC,DC,DCMAX,MC,SC,SPEED,HIT,WALK_SPD,WALKSTEP,WALKWAIT,ATTACK_SPD FROM TBL_MONSTER";
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                if (UserEngine.MonsterList.Count > 0)
                {
                    for (int I = 0; I < UserEngine.MonsterList.Count; I++)
                    {
                        if (UserEngine.MonsterList[I] != null)
                        {
                            Dispose(UserEngine.MonsterList[I]);
                        }
                    }
                    UserEngine.MonsterList.Clear();
                }
                try
                {
                    dr = DBsession.ExecuteReader(sSQLString);
                }
                catch
                {
                    MainOutMessage("链接数据库发生异常...");
                }
                finally
                {
                    result = -1;
                }
                if (dr == null) //2013.04.16 Fixed dr为空时Read报错
                {
                    return result;
                }
                while (dr.Read())
                {
                    Monster = new TMonInfo();
                    Monster.ItemList = new List<TMonItem>();
                    Monster.sName = dr.GetString("NAME");
                    Monster.btRace = dr.GetByte("Race");
                    Monster.btRaceImg = dr.GetByte("RaceImg");
                    Monster.wAppr = dr.GetUInt16("Appr");
                    Monster.wLevel = dr.GetUInt16("Lvl");
                    Monster.btLifeAttrib = dr.GetByte("Undead");// 不死系 1-不死系
                    Monster.wCoolEye = dr.GetUInt16("CoolEye");
                    Monster.dwExp = dr.GetUInt32("Exp");// 城门或城墙的状态跟HP值有关，如果HP异常，将导致城墙显示不了
                    if ((Monster.btRace == 110) || (Monster.btRace == 111))// 如果为城墙或城门由HP不加倍
                    {
                        Monster.wHP = dr.GetUInt16("HP");
                    }
                    else
                    {
                        Monster.wHP = (ushort)HUtil32.Round((double)dr.GetInt32("HP") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    }
                    Monster.wMP = (ushort)HUtil32.Round((double)dr.GetUInt16("MP") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wAC = (ushort)HUtil32.Round((double)dr.GetUInt16("AC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wMAC = (ushort)HUtil32.Round((double)dr.GetUInt16("MAC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wDC = (ushort)HUtil32.Round((double)dr.GetUInt16("DC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wMaxDC = (ushort)HUtil32.Round((double)dr.GetUInt16("DCMAX") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wMC = (ushort)HUtil32.Round((double)dr.GetUInt16("MC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wSC = (ushort)HUtil32.Round((double)dr.GetUInt16("SC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wSpeed = dr.GetUInt16("SPEED");
                    Monster.wHitPoint = dr.GetUInt16("HIT");
                    Monster.wWalkSpeed = (ushort)HUtil32._MAX(200, dr.GetUInt16("WALK_SPD"));
                    Monster.wWalkStep = (ushort)HUtil32._MAX(1, dr.GetUInt16("WalkStep"));
                    Monster.wWalkWait = dr.GetUInt16("WalkWait");
                    Monster.wAttackSpeed = dr.GetUInt16("ATTACK_SPD");
                    if (Monster.wWalkSpeed < 200)
                    {
                        Monster.wWalkSpeed = 200;
                    }
                    if (Monster.wAttackSpeed < 200)
                    {
                        Monster.wAttackSpeed = 200;
                    }
                    Monster.ItemList = null;
                    LoadMonitems(Monster.sName, ref Monster.ItemList);
                    UserEngine.MonsterList.Add(Monster);
                    result = 1;
                }
            }
            finally
            {
                dr.Close();
                dr.Dispose();
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 读取怪物爆率文件
        /// </summary>
        /// <param name="MonName">怪物名称</param>
        /// <param name="ItemList">物品列表</param>
        /// <returns></returns>
        internal int LoadMonitems(string MonName, ref IList<TMonItem> ItemList)
        {
            int result = 0;
            TStringList LoadList;
            TMonItem MonItem;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            int n18;
            int n1C;
            int n20;
            string sFileName = M2Share.g_Config.sEnvirDir + "MonItems\\" + MonName + ".txt";
            if (File.Exists(sFileName))
            {
                if (ItemList != null)
                {
                    if (ItemList.Count > 0)
                    {
                        for (int I = 0; I < ItemList.Count; I++)
                        {
                            if (ItemList[I] != null)
                            {
                                Dispose(ItemList[I]);
                            }
                        }
                    }
                    ItemList.Clear();
                }
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    s28 = LoadList[I];
                    if ((s28 != "") && (s28[0] != ';'))
                    {
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\t" });
                        n18 = HUtil32.Str_ToInt(s30, -1);
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\t" });
                        n1C = HUtil32.Str_ToInt(s30, -1);
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\t" });
                        if (s30 != "")
                        {
                            if (s30[0] == '\'')
                            {
                                HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                            }
                        }
                        s2C = s30;
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\t" });
                        n20 = HUtil32.Str_ToInt(s30, 1);
                        if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                        {
                            if (ItemList == null)
                            {
                                ItemList = new List<TMonItem>();
                            }
                            MonItem = new TMonItem();
                            MonItem.n00 = n18 - 1;
                            MonItem.n04 = n1C;
                            MonItem.sMonName = s2C;
                            MonItem.n18 = n20;
                            ItemList.Add(MonItem);
                            result++;
                        }
                    }
                }
            }
            return result;
        }

        public void Dispose(object obj)
        {
            if (obj != null)
            {
                GC.KeepAlive(obj);
                GC.ReRegisterForFinalize(obj);
            }
        }
    }
}