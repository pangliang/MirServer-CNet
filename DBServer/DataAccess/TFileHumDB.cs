using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using GameFramework;
using DBServer.Entity;
using System.Collections;

namespace DBServer.DataAccess
{
    public class TFileHumDB
    {
        private Mir2Entities objMir2Entities = null;
        private ObjectSet<HumInfo> HumInfoSet = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TFileHumDB()
        {
            objMir2Entities = new Mir2Entities();
            HumInfoSet = objMir2Entities.HumInfo;
            HumDB.boHumDBReady = true;
        }

        /// <summary>
        /// 通过角色名获取基本信息
        /// </summary>
        /// <param name="sChrName"></param>
        /// <param name="ChrNameList"></param>
        /// <returns></returns>
        public IQueryable<HumInfo> FuzzyFindObjectByChrName(string sChrName)
        {
            var FindHumList = from Hum in HumInfoSet
                              where Hum.sChrName.IndexOf(sChrName) >= 0
                              select Hum;
            if (FindHumList.Count<HumInfo>() > 0)
            {
                return FindHumList;
            }
            return null;
        }

        /// <summary>
        /// 荣国角色名查找角色
        /// </summary>
        /// <param name="sChrName"></param>
        /// <returns></returns>
        public HumInfo FindObjectByChrName(string sChrName)
        {
            var FindHumList = from Hum in HumInfoSet
                              where Hum.sChrName == sChrName
                              select Hum;
            if (FindHumList.Count<HumInfo>() > 0)
            {
                return FindHumList.First<HumInfo>();
            }
            return null;
        }

        /// <summary>
        /// 通过帐号名获取角色数量
        /// </summary>
        /// <param name="sAccount"></param>
        /// <returns></returns>
        public int ChrCountOfAccount(string sAccount)
        {
            return 0;
        }

        /// <summary>
        /// 通过名称删除角色
        /// </summary>
        /// <param name="sName"></param>
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
                HumInfoSet.DeleteObject(HumObjject);
                objMir2Entities.SaveChanges();
                return true;
            }
        }

        #region 非托管
        public unsafe bool Add(THumInfo HumRecord)
        {
            try
            {
                HumInfo objHumInfo = new HumInfo();
                objHumInfo.boDeleted = HumRecord.Header.boDeleted;
                objHumInfo.boIsHero = HumRecord.Header.boIsHero;
                objHumInfo.bt2 = HumRecord.Header.bt2;
                objHumInfo.dCreateDate = HumRecord.Header.dCreateDate;
                objHumInfo.sName = HumRecord.Header.sName;
                //objHumInfo.sName = HUtil32.SBytePtrToString(HumRecord.Header.sName, 15);
                objHumInfo.boDeleted1 = HumRecord.boDeleted;
                objHumInfo.boIsHero1 = HumRecord.boIsHero;
                objHumInfo.boSelected = HumRecord.boSelected;
                objHumInfo.btCount = HumRecord.btCount;
                objHumInfo.dModDate = HumRecord.dModDate.ToOADate();
                objHumInfo.n6 = HUtil32.BytePtrToByteArray(HumRecord.n6, 6);
                objHumInfo.sAccount = HumRecord.sAccount;
                //objHumInfo.sAccount = HUtil32.SBytePtrToString(HumRecord.sAccount, 30);
                objHumInfo.sChrName = HumRecord.sChrName;
                //objHumInfo.sChrName = HUtil32.SBytePtrToString(HumRecord.sChrName, 14);
                objHumInfo.nSelectID = HumRecord.Header.nSelectID;
                HumInfoSet.AddObject(objHumInfo);
                objMir2Entities.SaveChanges();
            }
            catch (Exception ex)
            {
                DBShare.MainOutMessage(ex.Message);
                return false;
            }
            return true;
        }

        public unsafe bool Update(string sName, THumInfo HumDBRecord)
        {
            HumInfo objHumInfo = FindObjectByChrName(sName);
            objHumInfo.boDeleted = HumDBRecord.Header.boDeleted;
            objHumInfo.boIsHero = HumDBRecord.Header.boIsHero;
            objHumInfo.bt2 = HumDBRecord.Header.bt2;
            objHumInfo.dCreateDate = HumDBRecord.Header.dCreateDate;
            objHumInfo.sName = HumDBRecord.Header.sName;
            //objHumInfo.sName = HUtil32.SBytePtrToString(HumDBRecord.Header.sName, 15);
            objHumInfo.boDeleted1 = HumDBRecord.boDeleted;
            objHumInfo.boIsHero1 = HumDBRecord.boIsHero;
            objHumInfo.boSelected = HumDBRecord.boSelected;
            objHumInfo.btCount = HumDBRecord.btCount;
            objHumInfo.dModDate = HumDBRecord.dModDate.ToOADate();
            objHumInfo.n6 = HUtil32.BytePtrToByteArray(HumDBRecord.n6, 6);
            objHumInfo.sAccount = HumDBRecord.sAccount;
            //objHumInfo.sAccount = HUtil32.SBytePtrToString(HumDBRecord.sAccount, 30);
            objHumInfo.sChrName = HumDBRecord.sChrName;
            //objHumInfo.sChrName = HUtil32.SBytePtrToString(HumDBRecord.sChrName, 14);
            return true;
        }

        public unsafe int FindByAccount(string sAccount, ref ArrayList ChrNameList)
        {
            var FindHumList = from Hum in HumInfoSet
                              where Hum.sAccount == sAccount
                              select Hum;
            if (FindHumList.Count<HumInfo>() > 0)
            {
                foreach (HumInfo item in FindHumList)
                {
                    THumInfo HumRecord = default(THumInfo);
                    HumRecord.Header.boDeleted = item.boDeleted.Value;
                    HumRecord.Header.boIsHero = item.boIsHero.Value;
                    HumRecord.Header.bt2 = item.bt2.Value;
                    HumRecord.Header.dCreateDate = item.dCreateDate.Value;
                    HumRecord.Header.nSelectID = item.nSelectID.Value;
                    HumRecord.Header.sName = item.sName;
                    //HUtil32.StringToSBytePtr(item.sName, HumRecord.Header.sName, 0);
                    HumRecord.Header.NameLen = 15;
                    HumRecord.boDeleted = item.boDeleted1.Value;
                    HumRecord.boIsHero = item.boIsHero1.Value;
                    HumRecord.boSelected = item.boSelected.Value;
                    HumRecord.btCount = item.btCount.Value;
                    HumRecord.dModDate = DateTime.FromOADate(item.dModDate.Value);
                    HUtil32.ByteArrayToBytePtr(HumRecord.n6, 6, item.n6);
                    HumRecord.sAccount = item.sAccount;
                    //HUtil32.StringToSBytePtr(item.sAccount, HumRecord.sAccount, 0);
                    HumRecord.AccountLen = 30;
                    HumRecord.sChrName = item.sChrName;
                    //HUtil32.StringToSBytePtr(item.sChrName, HumRecord.sChrName, 0);
                    HumRecord.ChrNameLen = 14;
                    ChrNameList.Add(HumRecord);
                }
                return FindHumList.Count<HumInfo>();
            }
            ChrNameList = null;
            return -1;
        }

        #endregion
    }
}
