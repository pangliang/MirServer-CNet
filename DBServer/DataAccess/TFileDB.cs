using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using GameFramework;

namespace DBServer.DataAccess
{
    public class TFileDB
    {
        private Mir2Entities objMir2Entities = null;//数据库实体
        private ObjectSet<HumDataInfo> HumDataInfoSet = null;//数据时实体集
        private static TFileDB Instance = null;//保持全局唯一

        /// <summary>
        /// 构造函数
        /// </summary>
        private TFileDB()
        {
            objMir2Entities = new Mir2Entities();
            HumDataInfoSet = objMir2Entities.HumDataInfo;
            HumDB.boDataDBReady = true;
        }

        /// <summary>
        /// 单例模式 获取实例
        /// </summary>
        /// <returns></returns>
        public static TFileDB GetInstance()
        {
            if (Instance == null)
            {
                Instance = new TFileDB();
            }
            return Instance;
        }

        /// <summary>
        /// 通过角色名称判断角色是否存在
        /// </summary>
        /// <param name="sHumanName"></param>
        /// <returns></returns>
        public bool IsExist(string sChrName)
        {
            var ResultHumDataInfo = from Hum in HumDataInfoSet
                                    where Hum.sName == sChrName
                                    select Hum;
            var nCount = ResultHumDataInfo.Count<HumDataInfo>();
            if (nCount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="HumanRCD"></param>
        /// <returns></returns>
        public bool Add(HumDataInfo HumanRCD)
        {
            HumDataInfoSet.AddObject(HumanRCD);
            objMir2Entities.SaveChanges();
            return true;
        }

        /// <summary>
        /// 通过角色名称删除角色
        /// </summary>
        /// <param name="sChrName"></param>
        /// <returns></returns>
        public bool Delete(string sChrName)
        {
            var HumObjject = FindObjectByChrName(sChrName);
            if (HumObjject == null)
            {
                return false;
            }
            else
            {
                HumDataInfoSet.DeleteObject(HumObjject);
                return true;
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="HumanRCD"></param>
        /// <returns></returns>
        public bool Update(HumDataInfo HumanRCD)
        {
            objMir2Entities.SaveChanges();
            return true;
        }

        /// <summary>
        /// 通过名称获取角色
        /// </summary>
        /// <param name="sChrName"></param>
        /// <returns></returns>
        public HumDataInfo FindObjectByChrName(string sChrName)
        {
            var FindHumList = from Hum in HumDataInfoSet
                              where Hum.sChrName == sChrName
                              select Hum;
            if (FindHumList.Count<HumDataInfo>() > 0)
            {
                return FindHumList.First<HumDataInfo>();
            }
            return null;
        }

        /// <summary>
        /// 模糊查找角色
        /// </summary>
        /// <param name="sChrName"></param>
        /// <returns></returns>
        public IQueryable<HumDataInfo> FuzzyFindObjectByChrName(string sChrName)
        {
            var FindHumList = from Hum in HumDataInfoSet
                              where Hum.sChrName.IndexOf(sChrName)>=0
                              select Hum;
            if (FindHumList.Count<HumDataInfo>() > 0)
            {
                return FindHumList;
            }
            return null;
        }
         
        #region 非托管
//
//        public unsafe bool Add(ref THumDataInfo HumanRCD)
//        {
//            HumDataInfo objHumDataInfo = new HumDataInfo();
//            objHumDataInfo.boDeleted = HumanRCD.Header.boDeleted;
//            objHumDataInfo.boIsHero = HumanRCD.Header.boIsHero;
//            objHumDataInfo.dCreateDate = HumanRCD.Header.dCreateDate;
//            objHumDataInfo.nSelectID = HumanRCD.Header.nSelectID;
//            fixed (sbyte* sName = HumanRCD.Header.sName)
//            {
//                objHumDataInfo.sName = GameFramework.HUtil32.SBytePtrToString(sName, HumanRCD.Header.NameLen);
//            }
//            objHumDataInfo.AC = HumanRCD.Data.Abil.AC;
//            objHumDataInfo.DC = HumanRCD.Data.Abil.DC;
//            objHumDataInfo.DC = HumanRCD.Data.Abil.DC;
//            objHumDataInfo.HandWeight = HumanRCD.Data.Abil.HandWeight;
//            objHumDataInfo.HP = HumanRCD.Data.Abil.HP;
//            objHumDataInfo.Level = HumanRCD.Data.Abil.Level;
//            objHumDataInfo.MAC = HumanRCD.Data.Abil.MAC;
//            objHumDataInfo.Exp = (int)HumanRCD.Data.Abil.Exp;
//            objHumDataInfo.MaxExp = (int)HumanRCD.Data.Abil.MaxExp;
//            objHumDataInfo.MaxHandWeight = HumanRCD.Data.Abil.MaxHandWeight;
//            objHumDataInfo.MaxHP = HumanRCD.Data.Abil.MaxHP;
//            objHumDataInfo.MaxMP = HumanRCD.Data.Abil.MaxMP;
//            objHumDataInfo.MaxWearWeight = HumanRCD.Data.Abil.MaxWearWeight;
//            objHumDataInfo.MaxWeight = HumanRCD.Data.Abil.MaxWeight;
//            objHumDataInfo.MC = HumanRCD.Data.Abil.MC;
//            objHumDataInfo.MP = HumanRCD.Data.Abil.MP;
//            objHumDataInfo.SC = HumanRCD.Data.Abil.SC;
//            objHumDataInfo.WearWeight = HumanRCD.Data.Abil.WearWeight;
//            objHumDataInfo.Weight = HumanRCD.Data.Abil.Weight;
//            byte[] BagItemsBuff = new byte[46 * 32];
//
//            fixed (byte* buff = HumanRCD.Data.BagItemsBuff)
//            {
//                BagItemsBuff = HUtil32.BytePtrToByteArray(buff, 46 * 32);
//            }
//            objHumDataInfo.BagItemsBuff = BagItemsBuff;
//            objHumDataInfo.boAllowGroupReCall = HumanRCD.Data.boAllowGroupReCall;
//            objHumDataInfo.boAllowGuildReCall = HumanRCD.Data.boAllowGuildReCall;
//            objHumDataInfo.boHasHero = HumanRCD.Data.boHasHero;
//            objHumDataInfo.boIsHero = HumanRCD.Data.boIsHero; //多余一次
//            objHumDataInfo.boLockLogon = HumanRCD.Data.boLockLogon;
//            objHumDataInfo.boMaster = HumanRCD.Data.boMaster;
//            objHumDataInfo.btAllowGroup = HumanRCD.Data.btAllowGroup;
//            objHumDataInfo.btAttatckMode = HumanRCD.Data.btAttatckMode;
//            objHumDataInfo.btCreditPoint = HumanRCD.Data.btCreditPoint;
//            objHumDataInfo.btDir = HumanRCD.Data.btDir;
//            objHumDataInfo.btDivorce = HumanRCD.Data.btDivorce;
//            objHumDataInfo.btEF = HumanRCD.Data.btEF;
//            objHumDataInfo.btF9 = HumanRCD.Data.btF9;
//            objHumDataInfo.btFightZoneDieCount = HumanRCD.Data.btFightZoneDieCount;
//            objHumDataInfo.btHair = HumanRCD.Data.btHair;
//            objHumDataInfo.btIncHealing = HumanRCD.Data.btIncHealing;
//            objHumDataInfo.btIncHealth = HumanRCD.Data.btIncHealth;
//            objHumDataInfo.btIncSpell = HumanRCD.Data.btIncSpell;
//            objHumDataInfo.btJob = HumanRCD.Data.btJob;
//            objHumDataInfo.btLastOutStatus = HumanRCD.Data.btLastOutStatus;
//            objHumDataInfo.btMarryCount = HumanRCD.Data.btMarryCount;
//            objHumDataInfo.btReLevel = HumanRCD.Data.btReLevel;
//            objHumDataInfo.btSex = HumanRCD.Data.btSex;
//            objHumDataInfo.btStatus = HumanRCD.Data.btStatus;
//            objHumDataInfo.dBodyLuck = HumanRCD.Data.dBodyLuck;
//            fixed (sbyte* buff = HumanRCD.Data.sHeroChrName)
//            {
//                objHumDataInfo.sHeroChrName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.HeroChrNameLen);
//            }
//            byte[] HumAddItemsBuff = new byte[5 * 32];
//            fixed (byte* buff = HumanRCD.Data.HumAddItemsBuff)
//            {
//                HumAddItemsBuff = HUtil32.BytePtrToByteArray(buff, 5 * 32);
//            }
//            objHumDataInfo.HumAddItemsBuff = HumAddItemsBuff;
//            byte[] HumItemsBuff = new byte[9 * 32];
//            fixed (byte* buff = HumanRCD.Data.HumItemsBuff)
//            {
//                HumItemsBuff = HUtil32.BytePtrToByteArray(buff, 9 * 32);
//            }
//            objHumDataInfo.HumItemsBuff = HumItemsBuff;
//            byte[] HumMagicsBuff = new byte[30 * 8];
//            fixed (byte* buff = HumanRCD.Data.HumMagicsBuff)
//            {
//                HumMagicsBuff = HUtil32.BytePtrToByteArray(buff, 30 * 8);
//            }
//            objHumDataInfo.HumMagicsBuff = HumMagicsBuff;
//            objHumDataInfo.nBonusPoint = HumanRCD.Data.nBonusPoint;
//            objHumDataInfo.nEXPRATE = HumanRCD.Data.nEXPRATE;
//            objHumDataInfo.nExpTime = HumanRCD.Data.nExpTime;
//            objHumDataInfo.nGameGird = HumanRCD.Data.nGameGird;
//            objHumDataInfo.nGameGold = HumanRCD.Data.nGameGold;
//            objHumDataInfo.nGamePoint = HumanRCD.Data.nGamePoint;
//            objHumDataInfo.nGold = HumanRCD.Data.nGold;
//            objHumDataInfo.nHungerStatus = HumanRCD.Data.nHungerStatus;
//            objHumDataInfo.nPayMentPoint = HumanRCD.Data.nPayMentPoint;
//            objHumDataInfo.nPKPOINT = HumanRCD.Data.nPKPOINT;
//            fixed (byte* buff = HumanRCD.Data.QuestFlag)
//            {
//                objHumDataInfo.QuestFlag = GameFramework.HUtil32.BytePtrToByteArray(buff, 128);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sAccount)
//            {
//                objHumDataInfo.sAccount = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.AccountLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sChrName)
//            {
//                objHumDataInfo.sChrName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.ChrNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sCurMap)
//            {
//                objHumDataInfo.sCurMap = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.CurMapLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sDearName)
//            {
//                objHumDataInfo.sDearName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.DearNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sHeroChrName)
//            {
//                objHumDataInfo.sHeroChrName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.HeroChrNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sHomeMap)
//            {
//                objHumDataInfo.sHomeMap = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.HomeMapLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sMasterName)
//            {
//                objHumDataInfo.sMasterName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.MasterNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sStoragePwd)
//            {
//                objHumDataInfo.sStoragePwd = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.MasterNameLen);
//            }
//            fixed (byte* buff = HumanRCD.Data.StorageItemsBuff)
//            {
//                objHumDataInfo.StorageItemsBuff = GameFramework.HUtil32.BytePtrToByteArray(buff, 46 * 74);
//            }
//            objHumDataInfo.wContribution = HumanRCD.Data.wContribution;
//            objHumDataInfo.wCurX = HumanRCD.Data.wCurX;
//            objHumDataInfo.wCurY = HumanRCD.Data.wCurY;
//            objHumDataInfo.wGroupRcallTime = HumanRCD.Data.wGroupRcallTime;
//            objHumDataInfo.wHomeX = HumanRCD.Data.wHomeX;
//            objHumDataInfo.wHomeY = HumanRCD.Data.wHomeY;
//            objHumDataInfo.wMasterCount = HumanRCD.Data.wMasterCount;
//            byte[] wStatusTimeArr = new byte[24];
//            fixed (ushort* pStatusTimeArr = HumanRCD.Data.wStatusTimeArr)
//            {
//                byte* buff = (byte*)pStatusTimeArr;
//                wStatusTimeArr = HUtil32.BytePtrToByteArray(buff, 24);
//            }
//            objHumDataInfo.wStatusTimeArr = wStatusTimeArr;
//            HumDataInfoSet.AddObject(objHumDataInfo);
//            objMir2Entities.SaveChanges();
//            return true;
//        }
//
//        public unsafe THumDataInfo Get(string sChrName)
//        {
//            THumDataInfo HumanRCD = default(THumDataInfo);
//            HumDataInfo objHumDataInfo = FindObjectByChrName(sChrName);
//            if (objHumDataInfo != null)
//            {
//                HumanRCD.Header.boDeleted = objHumDataInfo.boDeleted.Value;
//                HumanRCD.Header.boIsHero = objHumDataInfo.boIsHero.Value;
//                HumanRCD.Header.dCreateDate = objHumDataInfo.dCreateDate.Value;
//                HumanRCD.Header.nSelectID = objHumDataInfo.nSelectID.Value;
//                objHumDataInfo.sName.StrToSbyte(HumanRCD.Header.sName, 15, ref HumanRCD.Header.NameLen);
//                HumanRCD.Data.Abil.AC = (ushort)objHumDataInfo.AC.Value;
//                HumanRCD.Data.Abil.DC = (ushort)objHumDataInfo.DC.Value;
//                HumanRCD.Data.Abil.DC = (ushort)objHumDataInfo.DC.Value;
//                HumanRCD.Data.Abil.HandWeight = (byte)objHumDataInfo.HandWeight.Value;
//                HumanRCD.Data.Abil.HP = objHumDataInfo.HP.Value;
//                HumanRCD.Data.Abil.Level = objHumDataInfo.Level.Value;
//                HumanRCD.Data.Abil.Exp = (uint)objHumDataInfo.Exp.Value;
//                HumanRCD.Data.Abil.MAC = (ushort)objHumDataInfo.MAC.Value;
//                HumanRCD.Data.Abil.MaxExp = (uint)objHumDataInfo.MaxExp.Value;
//                HumanRCD.Data.Abil.MaxHandWeight = (byte)objHumDataInfo.MaxHandWeight.Value;
//                HumanRCD.Data.Abil.MaxHP = objHumDataInfo.MaxHP.Value;
//                HumanRCD.Data.Abil.MaxMP = objHumDataInfo.MaxMP.Value;
//                HumanRCD.Data.Abil.MaxWearWeight = (byte)objHumDataInfo.MaxWearWeight.Value;
//                HumanRCD.Data.Abil.MaxWeight = (ushort)objHumDataInfo.MaxWeight.Value;
//                HumanRCD.Data.Abil.MC = (ushort)objHumDataInfo.MC.Value;
//                HumanRCD.Data.Abil.MP = (ushort)objHumDataInfo.MP.Value;
//                HumanRCD.Data.Abil.SC = (ushort)objHumDataInfo.SC.Value;
//                HumanRCD.Data.Abil.WearWeight = (byte)objHumDataInfo.WearWeight.Value;
//                HumanRCD.Data.Abil.Weight = (ushort)objHumDataInfo.Weight.Value;
//                HUtil32.ByteArrayToBytePtr(HumanRCD.Data.BagItemsBuff, 46 * 32, objHumDataInfo.BagItemsBuff);
//                HumanRCD.Data.boAllowGroupReCall = objHumDataInfo.boAllowGroupReCall.Value;
//                HumanRCD.Data.boAllowGuildReCall = objHumDataInfo.boAllowGuildReCall.Value;
//                HumanRCD.Data.boHasHero = objHumDataInfo.boHasHero.Value;
//                HumanRCD.Data.boIsHero = objHumDataInfo.boIsHero.Value; //多余一次
//                HumanRCD.Data.boLockLogon = objHumDataInfo.boLockLogon.Value;
//                HumanRCD.Data.boMaster = objHumDataInfo.boMaster.Value;
//                HumanRCD.Data.btAllowGroup = objHumDataInfo.btAllowGroup.Value;
//                HumanRCD.Data.btAttatckMode = objHumDataInfo.btAttatckMode.Value;
//                HumanRCD.Data.btCreditPoint = objHumDataInfo.btCreditPoint.Value;
//                HumanRCD.Data.btDir = objHumDataInfo.btDir.Value;
//                HumanRCD.Data.btDivorce = objHumDataInfo.btDivorce.Value;
//                HumanRCD.Data.btEF = objHumDataInfo.btEF.Value;
//                HumanRCD.Data.btF9 = objHumDataInfo.btF9.Value;
//                HumanRCD.Data.btFightZoneDieCount = objHumDataInfo.btFightZoneDieCount.Value;
//                HumanRCD.Data.btHair = objHumDataInfo.btHair.Value;
//                HumanRCD.Data.btIncHealing = objHumDataInfo.btIncHealing.Value;
//                HumanRCD.Data.btIncHealth = objHumDataInfo.btIncHealth.Value;
//                HumanRCD.Data.btIncSpell = objHumDataInfo.btIncSpell.Value;
//                HumanRCD.Data.btJob = objHumDataInfo.btJob.Value;
//                HumanRCD.Data.btLastOutStatus = objHumDataInfo.btLastOutStatus.Value;
//                HumanRCD.Data.btMarryCount = objHumDataInfo.btMarryCount.Value;
//                HumanRCD.Data.btReLevel = objHumDataInfo.btReLevel.Value;
//                HumanRCD.Data.btSex = objHumDataInfo.btSex.Value;
//                HumanRCD.Data.btStatus = objHumDataInfo.btStatus.Value;
//                HumanRCD.Data.dBodyLuck = objHumDataInfo.dBodyLuck.Value;
//                objHumDataInfo.sHeroChrName.StrToSbyte(HumanRCD.Data.sHeroChrName, 14, ref HumanRCD.Data.HeroChrNameLen);
//                HUtil32.ByteArrayToBytePtr(HumanRCD.Data.HumAddItemsBuff, 5 * 32, objHumDataInfo.HumAddItemsBuff);
//                HUtil32.ByteArrayToBytePtr(HumanRCD.Data.HumItemsBuff, 9 * 32, objHumDataInfo.HumItemsBuff);
//                HUtil32.ByteArrayToBytePtr(HumanRCD.Data.HumMagicsBuff, 30 * 8, objHumDataInfo.HumMagicsBuff);
//                HumanRCD.Data.nBonusPoint = objHumDataInfo.nBonusPoint.Value;
//                HumanRCD.Data.nEXPRATE = objHumDataInfo.nEXPRATE.Value;
//                HumanRCD.Data.nExpTime = objHumDataInfo.nExpTime.Value;
//                HumanRCD.Data.nGameGird = objHumDataInfo.nGameGird.Value;
//                HumanRCD.Data.nGameGold = objHumDataInfo.nGameGold.Value;
//                HumanRCD.Data.nGamePoint = objHumDataInfo.nGamePoint.Value;
//                HumanRCD.Data.nGold = objHumDataInfo.nGold.Value;
//                HumanRCD.Data.nHungerStatus = objHumDataInfo.nHungerStatus.Value;
//                HumanRCD.Data.nPayMentPoint = objHumDataInfo.nPayMentPoint.Value;
//                HumanRCD.Data.nPKPOINT = objHumDataInfo.nPKPOINT.Value;
//                HUtil32.ByteArrayToBytePtr(HumanRCD.Data.QuestFlag, 128, objHumDataInfo.QuestFlag);
//                objHumDataInfo.sAccount.StrToSbyte(HumanRCD.Data.sAccount, 30, ref HumanRCD.Data.AccountLen);
//                objHumDataInfo.sChrName.StrToSbyte(HumanRCD.Data.sChrName, 14, ref HumanRCD.Data.ChrNameLen);
//                objHumDataInfo.sCurMap.StrToSbyte(HumanRCD.Data.sCurMap, 16, ref HumanRCD.Data.CurMapLen);
//                objHumDataInfo.sDearName.StrToSbyte(HumanRCD.Data.sDearName, 14, ref HumanRCD.Data.DearNameLen);
//                objHumDataInfo.sHeroChrName.StrToSbyte(HumanRCD.Data.sHeroChrName, 14, ref HumanRCD.Data.HeroChrNameLen);
//                objHumDataInfo.sHomeMap.StrToSbyte(HumanRCD.Data.sHomeMap, 16, ref HumanRCD.Data.HomeMapLen);
//                objHumDataInfo.sMasterName.StrToSbyte(HumanRCD.Data.sMasterName, 14, ref HumanRCD.Data.MasterNameLen);
//                objHumDataInfo.sStoragePwd.StrToSbyte(HumanRCD.Data.sStoragePwd, 7, ref HumanRCD.Data.StoragePwdLen);
//                HUtil32.ByteArrayToBytePtr(HumanRCD.Data.StorageItemsBuff, 46 * 74, objHumDataInfo.StorageItemsBuff);
//                HumanRCD.Data.wContribution = (ushort)objHumDataInfo.wContribution.Value;
//                HumanRCD.Data.wCurX = (ushort)objHumDataInfo.wCurX.Value;
//                HumanRCD.Data.wCurY = (ushort)objHumDataInfo.wCurY.Value;
//                HumanRCD.Data.wGroupRcallTime = (ushort)objHumDataInfo.wGroupRcallTime.Value;
//                HumanRCD.Data.wHomeX = (ushort)objHumDataInfo.wHomeX.Value;
//                HumanRCD.Data.wHomeY = (ushort)objHumDataInfo.wHomeY.Value;
//                HumanRCD.Data.wMasterCount = (ushort)objHumDataInfo.wMasterCount.Value;
//                HUtil32.ByteArrayToBytePtr((byte*)HumanRCD.Data.wStatusTimeArr, 24, objHumDataInfo.wStatusTimeArr);
//            }
//            return HumanRCD;
//        }
//
//        public unsafe bool Update(string sChrName, ref THumDataInfo HumanRCD)
//        {
//            HumDataInfo objHumDataInfo = FindObjectByChrName(sChrName);
//            objHumDataInfo.boDeleted = HumanRCD.Header.boDeleted;
//            objHumDataInfo.boIsHero = HumanRCD.Header.boIsHero;
//            objHumDataInfo.dCreateDate = HumanRCD.Header.dCreateDate;
//            objHumDataInfo.nSelectID = HumanRCD.Header.nSelectID;
//            fixed (sbyte* sName = HumanRCD.Header.sName)
//            {
//                objHumDataInfo.sName = GameFramework.HUtil32.SBytePtrToString(sName, HumanRCD.Header.NameLen);
//            }
//            objHumDataInfo.AC = HumanRCD.Data.Abil.AC;
//            objHumDataInfo.DC = HumanRCD.Data.Abil.DC;
//            objHumDataInfo.DC = HumanRCD.Data.Abil.DC;
//            objHumDataInfo.HandWeight = HumanRCD.Data.Abil.HandWeight;
//            objHumDataInfo.HP = HumanRCD.Data.Abil.HP;
//            objHumDataInfo.Level = HumanRCD.Data.Abil.Level;
//            objHumDataInfo.MAC = HumanRCD.Data.Abil.MAC;
//            objHumDataInfo.Exp = (int)HumanRCD.Data.Abil.Exp;
//            objHumDataInfo.MaxExp = (int)HumanRCD.Data.Abil.MaxExp;
//            objHumDataInfo.MaxHandWeight = HumanRCD.Data.Abil.MaxHandWeight;
//            objHumDataInfo.MaxHP = HumanRCD.Data.Abil.MaxHP;
//            objHumDataInfo.MaxMP = HumanRCD.Data.Abil.MaxMP;
//            objHumDataInfo.MaxWearWeight = HumanRCD.Data.Abil.MaxWearWeight;
//            objHumDataInfo.MaxWeight = HumanRCD.Data.Abil.MaxWeight;
//            objHumDataInfo.MC = HumanRCD.Data.Abil.MC;
//            objHumDataInfo.MP = HumanRCD.Data.Abil.MP;
//            objHumDataInfo.SC = HumanRCD.Data.Abil.SC;
//            objHumDataInfo.WearWeight = HumanRCD.Data.Abil.WearWeight;
//            objHumDataInfo.Weight = HumanRCD.Data.Abil.Weight;
//            fixed (byte* buff = HumanRCD.Data.BagItemsBuff)
//            {
//                objHumDataInfo.BagItemsBuff = HUtil32.BytePtrToByteArray(buff, 46 * 32);
//            }
//            objHumDataInfo.boAllowGroupReCall = HumanRCD.Data.boAllowGroupReCall;
//            objHumDataInfo.boAllowGuildReCall = HumanRCD.Data.boAllowGuildReCall;
//            objHumDataInfo.boHasHero = HumanRCD.Data.boHasHero;
//            objHumDataInfo.boIsHero = HumanRCD.Data.boIsHero; //多余一次
//            objHumDataInfo.boLockLogon = HumanRCD.Data.boLockLogon;
//            objHumDataInfo.boMaster = HumanRCD.Data.boMaster;
//            objHumDataInfo.btAllowGroup = HumanRCD.Data.btAllowGroup;
//            objHumDataInfo.btAttatckMode = HumanRCD.Data.btAttatckMode;
//            objHumDataInfo.btCreditPoint = HumanRCD.Data.btCreditPoint;
//            objHumDataInfo.btDir = HumanRCD.Data.btDir;
//            objHumDataInfo.btDivorce = HumanRCD.Data.btDivorce;
//            objHumDataInfo.btEF = HumanRCD.Data.btEF;
//            objHumDataInfo.btF9 = HumanRCD.Data.btF9;
//            objHumDataInfo.btFightZoneDieCount = HumanRCD.Data.btFightZoneDieCount;
//            objHumDataInfo.btHair = HumanRCD.Data.btHair;
//            objHumDataInfo.btIncHealing = HumanRCD.Data.btIncHealing;
//            objHumDataInfo.btIncHealth = HumanRCD.Data.btIncHealth;
//            objHumDataInfo.btIncSpell = HumanRCD.Data.btIncSpell;
//            objHumDataInfo.btJob = HumanRCD.Data.btJob;
//            objHumDataInfo.btLastOutStatus = HumanRCD.Data.btLastOutStatus;
//            objHumDataInfo.btMarryCount = HumanRCD.Data.btMarryCount;
//            objHumDataInfo.btReLevel = HumanRCD.Data.btReLevel;
//            objHumDataInfo.btSex = HumanRCD.Data.btSex;
//            objHumDataInfo.btStatus = HumanRCD.Data.btStatus;
//            objHumDataInfo.dBodyLuck = HumanRCD.Data.dBodyLuck;
//            fixed (sbyte* buff = HumanRCD.Data.sHeroChrName)
//            {
//                objHumDataInfo.sHeroChrName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.HeroChrNameLen);
//            }
//            fixed (byte* buff = HumanRCD.Data.HumAddItemsBuff)
//            {
//                objHumDataInfo.HumAddItemsBuff = HUtil32.BytePtrToByteArray(buff, 5 * 32);
//            }
//            fixed (byte* buff = HumanRCD.Data.HumItemsBuff)
//            {
//                objHumDataInfo.HumItemsBuff = HUtil32.BytePtrToByteArray(buff, 9 * 32);
//            }
//            fixed (byte* buff = HumanRCD.Data.HumMagicsBuff)
//            {
//                objHumDataInfo.HumMagicsBuff = HUtil32.BytePtrToByteArray(buff, 30 * 8);
//            }
//            objHumDataInfo.nBonusPoint = HumanRCD.Data.nBonusPoint;
//            objHumDataInfo.nEXPRATE = HumanRCD.Data.nEXPRATE;
//            objHumDataInfo.nExpTime = HumanRCD.Data.nExpTime;
//            objHumDataInfo.nGameGird = HumanRCD.Data.nGameGird;
//            objHumDataInfo.nGameGold = HumanRCD.Data.nGameGold;
//            objHumDataInfo.nGamePoint = HumanRCD.Data.nGamePoint;
//            objHumDataInfo.nGold = HumanRCD.Data.nGold;
//            objHumDataInfo.nHungerStatus = HumanRCD.Data.nHungerStatus;
//            objHumDataInfo.nPayMentPoint = HumanRCD.Data.nPayMentPoint;
//            objHumDataInfo.nPKPOINT = HumanRCD.Data.nPKPOINT;
//            fixed (byte* buff = HumanRCD.Data.QuestFlag)
//            {
//                objHumDataInfo.QuestFlag = GameFramework.HUtil32.BytePtrToByteArray(buff, 128);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sAccount)
//            {
//                objHumDataInfo.sAccount = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.AccountLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sChrName)
//            {
//                objHumDataInfo.sChrName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.ChrNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sCurMap)
//            {
//                objHumDataInfo.sCurMap = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.CurMapLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sDearName)
//            {
//                objHumDataInfo.sDearName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.DearNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sHeroChrName)
//            {
//                objHumDataInfo.sHeroChrName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.HeroChrNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sHomeMap)
//            {
//                objHumDataInfo.sHomeMap = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.HomeMapLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sMasterName)
//            {
//                objHumDataInfo.sMasterName = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.MasterNameLen);
//            }
//            fixed (sbyte* buff = HumanRCD.Data.sStoragePwd)
//            {
//                objHumDataInfo.sStoragePwd = GameFramework.HUtil32.SBytePtrToString(buff, HumanRCD.Data.MasterNameLen);
//            }
//            fixed (byte* buff = HumanRCD.Data.StorageItemsBuff)
//            {
//                objHumDataInfo.StorageItemsBuff = GameFramework.HUtil32.BytePtrToByteArray(buff, 46 * 74);
//            }
//            objHumDataInfo.wContribution = HumanRCD.Data.wContribution;
//            objHumDataInfo.wCurX = HumanRCD.Data.wCurX;
//            objHumDataInfo.wCurY = HumanRCD.Data.wCurY;
//            objHumDataInfo.wGroupRcallTime = HumanRCD.Data.wGroupRcallTime;
//            objHumDataInfo.wHomeX = HumanRCD.Data.wHomeX;
//            objHumDataInfo.wHomeY = HumanRCD.Data.wHomeY;
//            objHumDataInfo.wMasterCount = HumanRCD.Data.wMasterCount;
//            fixed (ushort* pStatusTimeArr = HumanRCD.Data.wStatusTimeArr)
//            {
//                objHumDataInfo.wStatusTimeArr = HUtil32.BytePtrToByteArray((byte*)pStatusTimeArr, 24);
//            }
//            return true;
//        }
//
        #endregion

        public int Count()
        {
            return HumDataInfoSet.Count<HumDataInfo>();
        }

        ~TFileDB()
        {
            objMir2Entities.Dispose();
        }
    }
}
