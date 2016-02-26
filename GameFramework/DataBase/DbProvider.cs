using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    public abstract class DbProvider : IDbProvider
    {
        private DbHelper dbHelper;
        private char leftToken;
        private char rightToken;
        private char paramPrefixToken;

        protected DbProvider(string connectionString, DbProviderFactory dbFactory, char leftToken, char rightToken, char paramPrefixToken)
        {
            this.connectName = "Default";
            this.leftToken = leftToken;
            this.rightToken = rightToken;
            this.paramPrefixToken = paramPrefixToken;
            this.dbHelper = new DbHelper(connectionString, dbFactory);
        }

        internal void SetEventHandler(DecryptEventHandler decryptEvent)
        {
            this.dbHelper.SetDecryptHandler(decryptEvent);
        }

        #region 增加DbCommand参数

        private string FormatParameter(string parameterName)
        {
            if (parameterName.IndexOf(paramPrefixToken) == 0) return parameterName;
            if (parameterName.IndexOf('$') == 0) return paramPrefixToken + parameterName.TrimStart('$');
            return paramPrefixToken + parameterName;
        }

        /// <summary>
        /// 给命令添加参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        public void AddParameter(DbCommand cmd, DbParameter[] parameters)
        {
            foreach (DbParameter p in parameters)
            {
                if (p.Value == null) p.Value = DBNull.Value;
                else if (p.Value.GetType().IsEnum)
                {
                    //对枚举进行特殊处理
                    p.Value = Convert.ToInt32(p.Value);
                }

                cmd.Parameters.Add(p);
            }
        }

        /// <summary>
        /// 给命令添加参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public void AddParameter(DbCommand cmd, SQLParameter[] parameters)
        {
            if (parameters == null || parameters.Length == 0) return;

            List<DbParameter> list = new List<DbParameter>();
            foreach (SQLParameter p in parameters)
            {
                DbParameter dbParameter = CreateParameter(p.Name, p.Value);
                dbParameter.Direction = p.Direction;

                list.Add(dbParameter);
            }

            AddParameter(cmd, list.ToArray());
        }

        public void AddInputParameter(DbCommand cmd, string parameterName, DbType dbType, int size, object value)
        {
            dbHelper.AddInputParameter(cmd, parameterName, dbType, size, value);
        }

        public void AddInputParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
        {
            dbHelper.AddInputParameter(cmd, parameterName, dbType, value);
        }

        public void AddOutputParameter(DbCommand cmd, string parameterName, DbType dbType, int size)
        {
            dbHelper.AddOutputParameter(cmd, parameterName, dbType, size);
        }

        public void AddInputOutputParameter(DbCommand cmd, string parameterName, DbType dbType, object value, int size)
        {
            dbHelper.AddInputOutputParameter(cmd, parameterName, dbType, value, size);
        }

        public void AddReturnValueParameter(DbCommand cmd, string parameterName, DbType dbType)
        {
            dbHelper.AddReturnValueParameter(cmd, parameterName, dbType);
        }

        public DbParameter GetParameter(DbCommand cmd, string parameterName)
        {
            return dbHelper.GetParameter(cmd, parameterName);
        }

        #endregion

        #region 执行SQL语句

        public int ExecuteNonQuery(DbCommand cmd, DbTrans trans)
        {
            //调整DbCommand;
            PrepareCommand(cmd);

            //写日志
            WriteLog(cmd);

            try
            {
                if (trans.Connection == null && trans.Transaction == null)
                {
                    return dbHelper.ExecuteNonQuery(cmd);
                }
                return dbHelper.ExecuteNonQuery(cmd, trans);
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, cmd);

                throw ex;
            }
        }

        public IDataReader ExecuteReader(DbCommand cmd, DbTrans trans)
        {
            //调整DbCommand;
            PrepareCommand(cmd);

            //写日志
            WriteLog(cmd);

            try
            {
                IDataReader reader;
                if (trans.Connection == null && trans.Transaction == null)
                {
                    reader = dbHelper.ExecuteReader(cmd);
                }
                else
                {
                    reader = dbHelper.ExecuteReader(cmd, trans);
                }
                return reader;
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, cmd);

                throw ex;
            }
        }

        public DataSet ExecuteDataSet(DbCommand cmd, DbTrans trans)
        {
            //调整DbCommand;
            PrepareCommand(cmd);

            //写日志
            WriteLog(cmd);

            try
            {
                if (trans.Connection == null && trans.Transaction == null)
                {
                    return dbHelper.ExecuteDataSet(cmd);
                }
                return dbHelper.ExecuteDataSet(cmd, trans);
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, cmd);

                throw ex;
            }
        }

        public DataTable ExecuteDataTable(DbCommand cmd, DbTrans trans)
        {
            //调整DbCommand;
            PrepareCommand(cmd);

            //写日志
            WriteLog(cmd);

            try
            {
                if (trans.Connection == null && trans.Transaction == null)
                {
                    return dbHelper.ExecuteDataTable(cmd);
                }
                return dbHelper.ExecuteDataTable(cmd, trans);
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, cmd);

                throw ex;
            }
        }

        public object ExecuteScalar(DbCommand cmd, DbTrans trans)
        {
            //调整DbCommand;
            PrepareCommand(cmd);

            //写日志
            WriteLog(cmd);

            try
            {
                if (trans.Connection == null && trans.Transaction == null)
                {
                    return dbHelper.ExecuteScalar(cmd);
                }
                return dbHelper.ExecuteScalar(cmd, trans);
            }
            catch (Exception ex)
            {
                WriteExceptionLog(ex, cmd);

                throw ex;
            }
        }

        #endregion

        #region 创建DbConnection及DbParameter

        /// <summary>
        /// 创建DbConnection
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateConnection()
        {
            return dbHelper.CreateConnection();
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <returns></returns>
        public DbParameter CreateParameter()
        {
            return dbHelper.CreateParameter();
        }

        #endregion

        #region 公用增删改方法

        /// <summary>
        /// 返回最终排序的SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        internal protected string Serialization(string sql)
        {
            return FormatSQL(sql, leftToken, rightToken, AccessProvider);
        }

        internal DbCommand CreateSqlCommand(string cmdText)
        {
            return dbHelper.CreateSqlStringCommand(cmdText);
        }

        /// <summary>
        /// 创建SQL命令
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        internal DbCommand CreateSqlCommand(string cmdText, SQLParameter[] parameters)
        {
            DbCommand cmd = dbHelper.CreateSqlStringCommand(cmdText);
            AddParameter(cmd, parameters);

            return cmd;
        }

        /// <summary>
        /// 创建存储过程命令
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        internal DbCommand CreateProcCommand(string procName)
        {
            return dbHelper.CreateStoredProcCommand(procName);
        }

        /// <summary>
        /// 格式化命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        internal DbCommand FormatCommand(DbCommand cmd)
        {
            return PrepareCommand(cmd);
        }

        #endregion

        #region ILogable Members

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="command">The command.</param>
        private void WriteLog(DbCommand command)
        {
            if (OnLog != null)
            {
                OnLog(GetLog(command));
            }
        }

        /// <summary>
        /// Writes the exception log.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="command"></param>
        private void WriteExceptionLog(Exception ex, DbCommand command)
        {
            if (OnExceptionLog != null)
            {
                OnExceptionLog(ex, GetLog(command));
            }
        }

        /// <summary>
        /// 获取输出的日志
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual string GetLog(DbCommand command)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}\t{1}\t\r\n", command.CommandType, command.CommandText));
            if (command.Parameters != null && command.Parameters.Count > 0)
            {
                sb.Append("Parameters:\r\n");
                foreach (DbParameter p in command.Parameters)
                {
                    if (p.Size > 0)
                        sb.Append(string.Format("{0}[{2}({3})] = {1}\r\n", p.ParameterName, p.Value, p.DbType, p.Size));
                    else
                        sb.Append(string.Format("{0}[{2}] = {1}\r\n", p.ParameterName, p.Value, p.DbType));
                }
            }
            sb.Append("\r\n");

            return sb.ToString();
        }

        /// <summary>
        /// OnLog event.
        /// </summary>
        public event LogHandler OnLog;

        /// <summary>
        /// OnExceptionLog event.
        /// </summary>
        public event ExceptionLogHandler OnExceptionLog;

        #endregion

        #region 需重写的方法

        /// <summary>
        /// 格式化IdentityName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual string FormatIdentityName(string name)
        {
            return name;
        }

        /// <summary>
        /// 调整DbCommand命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        protected virtual DbCommand PrepareCommand(DbCommand cmd)
        {
            cmd.CommandText = Serialization(cmd.CommandText);
            foreach (DbParameter p in cmd.Parameters)
            {
                string oldName = p.ParameterName;
                p.ParameterName = FormatParameter(p.ParameterName);

                if (cmd.CommandType == CommandType.Text)
                {
                    if (cmd.CommandText.Contains(oldName) && !cmd.CommandText.Contains(p.ParameterName))
                    {
                        cmd.CommandText = cmd.CommandText.Replace(oldName, p.ParameterName);
                    }
                }
            }
            return cmd;
        }

        #endregion

        #region 抽像方法

        /// <summary>
        /// 是否为Access驱动
        /// </summary>
        protected virtual bool AccessProvider
        {
            get { return false; }
        }

        /// <summary>
        /// 是否使用自增列
        /// </summary>
        protected virtual bool UseAutoIncrement
        {
            get { return false; }
        }

        /// <summary>
        /// 是否支持批处理
        /// </summary>
        protected internal abstract bool SupportBatch { get; }

        /// <summary>
        /// 返回自动ID的sql语句
        /// </summary>
        protected abstract string RowAutoID { get; }

        /// <summary>
        /// 创建DbParameter
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        protected abstract DbParameter CreateParameter(string parameterName, object val);

        #endregion

        private string connectName;
        internal string ConnectName
        {
            get { return connectName; }
            set { connectName = value; }
        }

        /// <summary>
        /// 创建OrmParameter
        /// </summary>
        /// <returns></returns>
        private SQLParameter CreateOrmParameter(object value)
        {
            string pName = MakeUniqueKey(30, "$p");
            return new SQLParameter(pName, value);
        }

        /// <summary>
        /// 检测是否为非法值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckValue(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检测是否为结构数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckStruct(object value)
        {
            //当属性为结构时进行系列化
            Type type = value.GetType();
            if (type.IsValueType && !type.IsEnum && !type.IsPrimitive && !type.IsSerializable)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Makes a unique key.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        internal static string MakeUniqueKey(int length, string prefix)
        {
            int prefixLength = prefix == null ? 0 : prefix.Length;

            string chars = "1234567890abcdefghijklmnopqrstuvwxyz";

            StringBuilder sb = new StringBuilder();
            if (prefixLength > 0)
            {
                sb.Append(prefix);
                sb.Append("_");
                prefixLength++;
            }

            int dupCount = 0;
            int preIndex = 0;

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < length - prefixLength; ++i)
            {
                int index = rnd.Next(0, 35);
                if (index == preIndex)
                {
                    ++dupCount;
                }
                sb.Append(chars[index]);
                preIndex = index;
            }
            if (dupCount >= length - prefixLength - 2)
            {
                rnd = new Random(Guid.NewGuid().GetHashCode());
                return MakeUniqueKey(length, prefix);
            }

            return sb.ToString();
        }

        internal static string FormatSQL(string sql, char leftToken, char rightToken, bool isAccess)
        {
            if (sql == null) return string.Empty;

            try
            {
                if (isAccess)
                    sql = string.Format(sql, leftToken, rightToken, '(', ')');
                else
                    sql = string.Format(sql, leftToken, rightToken, ' ', ' ');
            }
            catch
            {
                if (isAccess)
                    sql = sql.Replace("{0}", leftToken.ToString()).Replace("{1}", rightToken.ToString()).Replace("{2}", '('.ToString()).Replace("{3}", ')'.ToString());
                else
                    sql = sql.Replace("{0}", leftToken.ToString()).Replace("{1}", rightToken.ToString()).Replace("{2}", ' '.ToString()).Replace("{3}", ' '.ToString());
            }

            return sql.Trim().Replace(" . ", ".")
                            .Replace(" , ", ",")
                            .Replace(" ( ", " (")
                            .Replace(" ) ", ") ")
                            .Replace("   ", " ")
                            .Replace("  ", " ");
        }

    }
}
