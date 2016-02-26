using GameFramework.DataBase;
using System;
using System.Data;
using System.Reflection;

namespace LoginSrv
{
    public class IDDB
    {
        private GameFramework.DataBase.IDataBaseClient dbClient = null;
        private static IDDB _IDDB = null;
        private static readonly string typeName = SqlType.MSSQL;

        public static IDDB GetInstance()
        {
            if (_IDDB == null)
            {
                _IDDB = new IDDB(typeName);
            }
            return _IDDB;
        }

        private IDDB(string typeName)
        {
            object[] args = new object[] { "server=(local);uid=sa;pwd=7956214;database=LegendMir2;" };
            dbClient = (IDataBaseClient)Assembly.Load("GameFramework").CreateInstance(typeName, true, BindingFlags.CreateInstance, null, args, null, null);
        }

        public bool Open()
        {
            DataSet dsCustom = dbClient.GetData("Select 1 Test");
            if (dsCustom.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool AccountExists(string sAccount)
        {
            DataSet dsCustom = dbClient.GetData(string.Format("Select * from Account WHERE FLD_LOGINID = '{0}'", sAccount));
            if (dsCustom.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool AddAccount(TAccountDBRecord DBRecord)
        {
            if (this.AccountExists(DBRecord.UserEntry.sAccount))
            {
                return false;
            }
            DateTime dtNow = DateTime.Now;
            IDataParameter[] SqlParams = {
                                         new System.Data.SqlClient.SqlParameter("@FLD_LOGINID",DBRecord.UserEntry.sAccount),
                                         new System.Data.SqlClient.SqlParameter("@FLD_PASSWORD",DBRecord.UserEntry.sPassword),
                                         new System.Data.SqlClient.SqlParameter("@FLD_USERNAME",DBRecord.UserEntry.sUserName),
                                         new System.Data.SqlClient.SqlParameter("@FLD_SSNO",DBRecord.UserEntry.sSSNo),
                                         new System.Data.SqlClient.SqlParameter("@FLD_BIRTHDAY",DBRecord.UserEntryAdd.sBirthDay),
                                         new System.Data.SqlClient.SqlParameter("@FLD_PHONE",DBRecord.UserEntry.sPhone),
                                         new System.Data.SqlClient.SqlParameter("@FLD_MOBILEPHONE",DBRecord.UserEntryAdd.sMobilePhone),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ADDRESS1",DBRecord.UserEntryAdd.sMemo),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ADDRESS2",DBRecord.UserEntryAdd.sMemo2),
                                         new System.Data.SqlClient.SqlParameter("@FLD_EMAIL",DBRecord.UserEntry.sEMail),
                                         new System.Data.SqlClient.SqlParameter("@FLD_QUIZ1",DBRecord.UserEntry.sQuiz),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ANSWER1",DBRecord.UserEntry.sAnswer),
                                         new System.Data.SqlClient.SqlParameter("@FLD_QUIZ2",DBRecord.UserEntryAdd.sQuiz2),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ANSWER2",DBRecord.UserEntryAdd.sAnswer2),
                                         new System.Data.SqlClient.SqlParameter("@FLD_CREATEDATE",dtNow),
                                         new System.Data.SqlClient.SqlParameter("@FLD_UPDATEDATE",dtNow),
                                         new System.Data.SqlClient.SqlParameter("@FLD_DELETED",0),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ACTIONTICK",0),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ERRORCOUNT",0)
                                         };
            DataSet dsCustome = new DataSet();
            if (dbClient.ExecuteProcedure("CreateAccount", SqlParams, ref dsCustome) >= 0)
            {
                return true;
            }
            return false;
        }

        public bool GetAccount(string LoginID, ref TAccountDBRecord DBRecord)
        {
            DataSet dsCustome = dbClient.GetData(string.Format("SELECT * FROM Account WHERE FLD_LOGINID = '{0}'", LoginID));
            if (dsCustome.Tables[0].Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                DBRecord.UserEntry.sAccount = dsCustome.Tables[0].Rows[0]["FLD_LOGINID"].ToString().Trim();
                DBRecord.UserEntry.sAnswer = dsCustome.Tables[0].Rows[0]["FLD_ANSWER1"].ToString().Trim();
                DBRecord.UserEntry.sEMail = dsCustome.Tables[0].Rows[0]["FLD_EMAIL"].ToString().Trim();
                DBRecord.UserEntry.sPassword = dsCustome.Tables[0].Rows[0]["FLD_PASSWORD"].ToString().Trim();
                DBRecord.UserEntry.sPhone = dsCustome.Tables[0].Rows[0]["FLD_PHONE"].ToString().Trim();
                DBRecord.UserEntry.sQuiz = dsCustome.Tables[0].Rows[0]["FLD_QUIZ1"].ToString().Trim();
                DBRecord.UserEntry.sSSNo = dsCustome.Tables[0].Rows[0]["FLD_SSNO"].ToString().Trim();
                DBRecord.UserEntry.sUserName = dsCustome.Tables[0].Rows[0]["FLD_USERNAME"].ToString().Trim();
                DBRecord.UserEntryAdd.sAnswer2 = dsCustome.Tables[0].Rows[0]["FLD_ANSWER2"].ToString().Trim();
                DBRecord.UserEntryAdd.sBirthDay = dsCustome.Tables[0].Rows[0]["FLD_BIRTHDAY"].ToString().Trim();
                DBRecord.UserEntryAdd.sMemo = dsCustome.Tables[0].Rows[0]["FLD_ADDRESS1"].ToString().Trim();
                DBRecord.UserEntryAdd.sMemo2 = dsCustome.Tables[0].Rows[0]["FLD_ADDRESS2"].ToString().Trim();
                DBRecord.UserEntryAdd.sMobilePhone = dsCustome.Tables[0].Rows[0]["FLD_MOBILEPHONE"].ToString().Trim();
                DBRecord.UserEntryAdd.sQuiz2 = dsCustome.Tables[0].Rows[0]["FLD_QUIZ2"].ToString().Trim();
                DBRecord.Header.CreateDate = (DateTime)dsCustome.Tables[0].Rows[0]["FLD_CREATEDATE"];
                DBRecord.Header.UpdateDate = (DateTime)dsCustome.Tables[0].Rows[0]["FLD_UPDATEDATE"];
                DBRecord.Header.boDeleted = (Convert.ToInt32(dsCustome.Tables[0].Rows[0]["FLD_DELETED"].ToString())) >= 1 ? true : false;
                DBRecord.dwActionTick = (uint)((int)dsCustome.Tables[0].Rows[0]["FLD_ACTIONTICK"]);
                DBRecord.nErrorCount = (int)dsCustome.Tables[0].Rows[0]["FLD_ERRORCOUNT"];

                return true;
            }
        }

        public bool UpdateAccount(string LoginID, TAccountDBRecord DBRecord)
        {
            if (!this.AccountExists(DBRecord.UserEntry.sAccount))
            {
                return false;
            }
            string strCreateDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DBRecord.Header.CreateDate);
            string strUpdateDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            IDataParameter[] SqlParams = {
                                         new System.Data.SqlClient.SqlParameter("@FLD_LOGINID",DBRecord.UserEntry.sAccount),
                                         new System.Data.SqlClient.SqlParameter("@FLD_PASSWORD",DBRecord.UserEntry.sPassword),
                                         new System.Data.SqlClient.SqlParameter("@FLD_USERNAME",DBRecord.UserEntry.sUserName),
                                         new System.Data.SqlClient.SqlParameter("@FLD_SSNO",DBRecord.UserEntry.sSSNo),
                                         new System.Data.SqlClient.SqlParameter("@FLD_BIRTHDAY",DBRecord.UserEntryAdd.sBirthDay),
                                         new System.Data.SqlClient.SqlParameter("@FLD_PHONE",DBRecord.UserEntry.sPhone),
                                         new System.Data.SqlClient.SqlParameter("@FLD_MOBILEPHONE",DBRecord.UserEntryAdd.sMobilePhone),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ADDRESS1",DBRecord.UserEntryAdd.sMemo),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ADDRESS2",DBRecord.UserEntryAdd.sMemo2),
                                         new System.Data.SqlClient.SqlParameter("@FLD_EMAIL",DBRecord.UserEntry.sEMail),
                                         new System.Data.SqlClient.SqlParameter("@FLD_QUIZ1",DBRecord.UserEntry.sQuiz),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ANSWER1",DBRecord.UserEntry.sAnswer),
                                         new System.Data.SqlClient.SqlParameter("@FLD_QUIZ2",DBRecord.UserEntryAdd.sQuiz2),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ANSWER2",DBRecord.UserEntryAdd.sAnswer2),
                                         new System.Data.SqlClient.SqlParameter("@FLD_CREATEDATE",strCreateDate),
                                         new System.Data.SqlClient.SqlParameter("@FLD_UPDATEDATE",strUpdateDate),
                                         new System.Data.SqlClient.SqlParameter("@FLD_DELETED",DBRecord.Header.boDeleted?1:0),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ACTIONTICK",(int)DBRecord.dwActionTick),
                                         new System.Data.SqlClient.SqlParameter("@FLD_ERRORCOUNT",DBRecord.nErrorCount)
                                         };
            DataSet dsCustome = new DataSet();
            if (dbClient.ExecuteProcedure("UpdateAccount", SqlParams, ref dsCustome) >= 0)
            {
                return true;
            }
            return false;
        }

        public void Close()
        {
        }
    }
}