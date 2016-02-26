using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework.DataBase;
using System.Reflection;
using System.Data;
using GameFramework;
using DBServer.Entity;

namespace DBServer
{
    public class HumDB
    {
        public static bool boDataDBReady = false;
        public static bool boHumDBReady = false;

        private GameFramework.DataBase.IDataBaseClient dbClient = null;
        private static readonly string typeName = SqlType.MSSQL;
        private static HumDB _HumDb = null;

        public static HumDB GetInstance()
        {
            if (_HumDb == null)
            {
                _HumDb = new HumDB(typeName);
            }
            return _HumDb;
        }

        private HumDB(string typeName)
        {
            object[] args = new object[] { "server=(local);uid=sa;pwd=7956214;database=LegendMir2;" };
            dbClient = (IDataBaseClient)Assembly.Load("GameFramework").CreateInstance(typeName, true, BindingFlags.CreateInstance, null, args, null, null);
        }

        public HumDataInfo GetHumDataInfoByCharName()
        {
            return null;
        }

        public bool IsExistsAccount(string sAccount)
        {
            DataSet dsCustom = dbClient.GetData(string.Format("SELECT Account FROM Account WHERE Account ='{0}'",sAccount));
            if (dsCustom.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistsByCharName(string sCharName)
        {
            DataSet dsCustom = dbClient.GetData(string.Format("SELECT sChrName FROM Account WHERE sChrName ='{0}'", sCharName));
            if (dsCustom.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ChrCountOfAccount(string sAccount)
        {
            DataSet dsCustom = dbClient.GetData(string.Format("SELECT sChrName FROM Account WHERE sAccount ='{0}'", sAccount));
            return dsCustom.Tables[0].Rows.Count; 
        }

        public bool Add(THumInfo objHumInfo,THumDataInfo objHumDataInfo)
        {
            string sGuid = HUtil32.GetGuid();
            string sAccount = objHumInfo.sAccount;
            string sChrName = objHumInfo.sChrName;
            int boIsHero = objHumInfo.boIsHero ? 1 : 0;
            int boSelected = objHumInfo.boSelected ? 1 : 0;
            int nSelectID = objHumInfo.Header.nSelectID;
            int boDeleted = objHumInfo.boDeleted?1:0;
            DateTime dCreateDate = DateTime.FromOADate(objHumInfo.dCreateDate);
            DateTime dModDate = objHumInfo.dModDate;
            int btCount = objHumInfo.btCount;
            DataSet dsCustom = new DataSet();
            IDataParameter[] SqlParams = new IDataParameter[] { new System.Data.SqlClient.SqlParameter("@sGuid", sGuid) ,
                                                              new System.Data.SqlClient.SqlParameter("@sAccount", sAccount) ,
                                                              new System.Data.SqlClient.SqlParameter("@sChrName", sChrName) ,
                                                              new System.Data.SqlClient.SqlParameter("@boIsHero", boIsHero) ,
                                                              new System.Data.SqlClient.SqlParameter("@boSelected", boSelected) ,
                                                              new System.Data.SqlClient.SqlParameter("@nSelectID", nSelectID) ,
                                                              new System.Data.SqlClient.SqlParameter("@boDeleted", boDeleted) ,
                                                              new System.Data.SqlClient.SqlParameter("@dCreateDate", dCreateDate) ,
                                                              new System.Data.SqlClient.SqlParameter("@dModDate", dModDate) ,
                                                              new System.Data.SqlClient.SqlParameter("@btCount", btCount) ,
                                                            };
            if (!(dbClient.ExecuteProcedure("CreateHumInfo", SqlParams, ref dsCustom) > 0))
                return false;
            if (!(dbClient.ExecuteSql(string.Format("INSERT INTO HumDataInfo(Guid,btSex,btJob,btHair) VALUES('{0}',{1},{2},{3})", sGuid,
                objHumDataInfo.Data.btSex,
                objHumDataInfo.Data.btJob,
                objHumDataInfo.Data.btHair
                )) > 0))
                return false;
            return true;
        }

        public bool Del(string sCharName)
        {
            if (!(dbClient.ExecuteSql(string.Format("UPDATE HumInfo SET boDeleted = 1 , dModDate = '{1}' WHERE sCharName = '{0}'", sCharName, DateTime.Now)) > 0))
            {
                return false;
            }
            return true; ;
        }

        public Entity.HumInfo GetHumByCharName(string sCharName)
        {
            return new Entity.HumInfo();
        }

        public List<Entity.HumInfo> GetHumListByAccount(string sAccount)
        {
            List<Entity.HumInfo> objHumList = new List<Entity.HumInfo>();

            return new List<Entity.HumInfo>();
        }
    }
}
