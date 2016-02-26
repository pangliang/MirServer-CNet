using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    interface IDbProvider : ILogable
    {
        #region 参数操作

        /// <summary>
        /// 给命令添加参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="plist"></param>
        /// <returns></returns>
        void AddParameter(DbCommand cmd, DbParameter[] parameters);

        /// <summary>
        /// 给命令添加参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="plist"></param>
        /// <returns></returns>
        void AddParameter(DbCommand cmd, SQLParameter[] parameters);

        void AddInputParameter(DbCommand cmd, string parameterName, DbType dbType, object value);
        void AddOutputParameter(DbCommand cmd, string parameterName, DbType dbType, int size);
        void AddInputOutputParameter(DbCommand cmd, string parameterName, DbType dbType, object value, int size);
        void AddReturnValueParameter(DbCommand cmd, string parameterName, DbType dbType);
        DbParameter GetParameter(DbCommand cmd, string parameterName);


        /// <summary>
        /// 创建DbConnection
        /// </summary>
        /// <returns></returns>
        DbConnection CreateConnection();

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <returns></returns>
        DbParameter CreateParameter();

        #endregion

        int ExecuteNonQuery(DbCommand cmd, DbTrans trans);
        IDataReader ExecuteReader(DbCommand cmd, DbTrans trans);
        DataTable ExecuteDataTable(DbCommand cmd, DbTrans trans);
        object ExecuteScalar(DbCommand cmd, DbTrans trans);
    }
}
