using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    public delegate string DecryptEventHandler(string connectionString);

    public sealed class DbHelper
    {
        private DecryptEventHandler decryptProxy;
        private DbProviderFactory dbFactory;
        private string dbConnectionString;

        public DbHelper(string connectionString, DbProviderFactory dbFactory)
        {
            this.dbConnectionString = connectionString;
            this.dbFactory = dbFactory;
        }

        public void SetDecryptHandler(DecryptEventHandler decryptProxy)
        {
            this.decryptProxy = decryptProxy;
        }

        #region 创建供外部调用的对象

        public DbConnection CreateConnection()
        {
            DbConnection dbconn = dbFactory.CreateConnection();
            if (decryptProxy != null)
            {
                dbConnectionString = decryptProxy(dbConnectionString);
                decryptProxy = null;
            }
            dbconn.ConnectionString = dbConnectionString;
            return dbconn;
        }

        /// <summary>
        /// 创建命令
        /// </summary>
        /// <returns></returns>
        public DbCommand CreateCommand()
        {
            return dbFactory.CreateCommand();
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <returns></returns>
        public DbParameter CreateParameter()
        {
            return dbFactory.CreateParameter();
        }

        #endregion

        public DbCommand CreateStoredProcCommand(string procName)
        {
            DbCommand dbCommand = dbFactory.CreateCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = procName;
            return dbCommand;
        }

        public DbCommand CreateSqlStringCommand(string cmdText)
        {
            DbCommand dbCommand = dbFactory.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = cmdText;
            return dbCommand;
        }

        #region 增加参数

        public void AddParameterCollection(DbCommand cmd, DbParameterCollection dbParameterCollection)
        {
            foreach (DbParameter dbParameter in dbParameterCollection)
            {
                cmd.Parameters.Add(dbParameter);
            }
        }

        public void AddInputParameter(DbCommand cmd, string parameterName, DbType dbType, int size, object value)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Size = size;
            dbParameter.Value = value;
            dbParameter.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(dbParameter);
        }

        public void AddInputParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            dbParameter.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(dbParameter);
        }

        public void AddOutputParameter(DbCommand cmd, string parameterName, DbType dbType, int size)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Size = size;
            dbParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dbParameter);
        }

        public void AddInputOutputParameter(DbCommand cmd, string parameterName, DbType dbType, object value, int size)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            dbParameter.Size = size;
            dbParameter.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(dbParameter);
        }

        public void AddReturnValueParameter(DbCommand cmd, string parameterName, DbType dbType)
        {
            DbParameter dbParameter = cmd.CreateParameter();
            dbParameter.DbType = dbType;
            dbParameter.ParameterName = parameterName;
            dbParameter.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(dbParameter);
        }

        public DbParameter GetParameter(DbCommand cmd, string parameterName)
        {
            return cmd.Parameters[parameterName];
        }

        #endregion

        #region 执行

        public DataSet ExecuteDataSet(DbCommand cmd)
        {
            cmd.Connection = CreateConnection();
            cmd.Connection.Open();
            try
            {
                using (DbDataAdapter dbDataAdapter = dbFactory.CreateDataAdapter())
                {
                    dbDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    dbDataAdapter.Fill(ds);
                    if (cmd.Connection.State != ConnectionState.Closed)
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                    }
                    return ds;
                }
            }
            catch
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                throw;
            }
        }

        public DataTable ExecuteDataTable(DbCommand cmd)
        {
            cmd.Connection = CreateConnection();
            cmd.Connection.Open();
            try
            {
                using (DbDataAdapter dbDataAdapter = dbFactory.CreateDataAdapter())
                {
                    dbDataAdapter.SelectCommand = cmd;
                    DataTable dataTable = new DataTable();
                    dbDataAdapter.Fill(dataTable);
                    if (cmd.Connection.State != ConnectionState.Closed)
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                    }
                    return dataTable;
                }
            }
            catch
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                throw;
            }
        }

        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            cmd.Connection = CreateConnection();
            cmd.CommandTimeout = 3;
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                throw;
            }
        }

        public int ExecuteNonQuery(DbCommand cmd)
        {
            cmd.Connection = CreateConnection();
            cmd.Connection.Open();
            try
            {
                int ret = cmd.ExecuteNonQuery();
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                return ret;
            }
            catch
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                throw;
            }
        }

        public object ExecuteScalar(DbCommand cmd)
        {
            cmd.Connection = CreateConnection();
            cmd.Connection.Open();
            try
            {
                object ret = cmd.ExecuteScalar();
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                if (ret == DBNull.Value) ret = null;
                return ret;
            }
            catch
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
                throw;
            }
        }

        #endregion

        #region 执行事务

        public DataSet ExecuteDataSet(DbCommand cmd, DbTrans t)
        {
            cmd.Connection = t.Connection;
            if (t.Transaction != null) cmd.Transaction = t.Transaction;
            try
            {
                using (DbDataAdapter dbDataAdapter = dbFactory.CreateDataAdapter())
                {
                    dbDataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    dbDataAdapter.Fill(ds);
                    return ds;
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable ExecuteDataTable(DbCommand cmd, DbTrans t)
        {
            cmd.Connection = t.Connection;
            if (t.Transaction != null) cmd.Transaction = t.Transaction;
            try
            {
                using (DbDataAdapter dbDataAdapter = dbFactory.CreateDataAdapter())
                {
                    dbDataAdapter.SelectCommand = cmd;
                    DataTable dataTable = new DataTable();
                    dbDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public DbDataReader ExecuteReader(DbCommand cmd, DbTrans t)
        {
            cmd.Connection = t.Connection;
            if (t.Transaction != null) cmd.Transaction = t.Transaction;
            try
            {
                DbDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                throw;
            }
        }

        public int ExecuteNonQuery(DbCommand cmd, DbTrans t)
        {
            cmd.Connection = t.Connection;
            if (t.Transaction != null) cmd.Transaction = t.Transaction;
            try
            {
                int ret = cmd.ExecuteNonQuery();
                return ret;
            }
            catch
            {
                throw;
            }
        }

        public object ExecuteScalar(DbCommand cmd, DbTrans t)
        {
            cmd.Connection = t.Connection;
            if (t.Transaction != null) cmd.Transaction = t.Transaction;
            try
            {
                object ret = cmd.ExecuteScalar();
                if (ret == DBNull.Value) ret = null;
                return ret;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
