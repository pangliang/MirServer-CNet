using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    public partial class DbSession : IDbSession
    {
        public static DbSession Default;
        private DbProvider dbProvider;
        private DbTrans dbTrans;

        #region 初始化Session

        static DbSession()
        {
            if (Default == null)
            {
                try
                {
                    Default = new DbSession(ProviderFactory.Default);
                }
                catch { }
            }
        }

        /// <summary>
        ///  指定配制节名实例化一个Session会话
        /// </summary>
        /// <param name="connectName"></param>
        public DbSession(string connectName)
            : this(ProviderFactory.CreateDbProvider(connectName))
        { }

        /// <summary>
        /// 指定驱动实例化一个Session会话
        /// </summary>
        /// <param name="dbProvider"></param>
        public DbSession(DbProvider dbProvider)
        {
            try
            {
                InitSession(dbProvider);
            }
            catch
            {
                throw new Exception("初始化DbSession失败，请检查配置是否正确！");
            }
        }

        /// <summary>
        /// 设置指定配制节名Session会话为默认会话
        /// </summary>
        /// <param name="connectName"></param>
        public static void SetDefault(string connectName)
        {
            Default = new DbSession(connectName);
        }

        /// <summary>
        /// 设置指定驱动Session会话为默认会话
        /// </summary>
        /// <param name="dbProvider"></param>
        public static void SetDefault(DbProvider dbProvider)
        {
            Default = new DbSession(dbProvider);
        }

        #endregion

        #region 实现IDbSession

        /// <summary>
        /// 设置新的驱动
        /// </summary>
        /// <param name="connectName"></param>
        public void SetProvider(string connectName)
        {
            SetProvider(ProviderFactory.CreateDbProvider(connectName));
        }

        /// <summary>
        /// 设置新的驱动
        /// </summary>
        /// <param name="dbProvider"></param>
        public void SetProvider(DbProvider dbProvider)
        {
            InitSession(dbProvider);
        }

        /// <summary>
        /// 开始一个事务
        /// </summary>
        /// <returns></returns>
        public DbTrans BeginTrans()
        {
            return new DbTrans(dbProvider, true);
        }

        /// <summary>
        /// 开始一个事务
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public DbTrans BeginTrans(IsolationLevel isolationLevel)
        {
            return new DbTrans(dbProvider, isolationLevel);
        }

        /// <summary>
        /// 设置一个外部事务
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public DbTrans SetTransaction(DbTransaction trans)
        {
            return new DbTrans(dbProvider, trans);
        }

        /// <summary>
        /// 开始一个外部事务
        /// </summary>
        /// <returns></returns>
        public DbTransaction BeginTransaction()
        {
            return BeginTrans().Transaction;
        }

        /// <summary>
        /// 开始一个外部事务
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return BeginTrans(isolationLevel).Transaction;
        }

        /// <summary>
        /// 设置一个外部链接
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public DbTrans SetConnection(DbConnection connection)
        {
            return new DbTrans(dbProvider, connection);
        }

        /// <summary>
        /// 创建一个外部连接
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateConnection()
        {
            return dbProvider.CreateConnection();
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <returns></returns>
        public DbParameter CreateParameter()
        {
            return dbProvider.CreateParameter();
        }

        /// <summary>
        /// 解密ConnectionString
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        protected virtual string Decrypt(string connectionString)
        {
            //添加解密的方式
            return connectionString;
        }

        #region 注册Log

        /// <summary>
        /// 注册一个日志事件
        /// </summary>
        /// <param name="handler"></param>
        public void RegisterSqlLogger(LogHandler handler)
        {
            dbProvider.OnLog += handler;
        }

        /// <summary>
        /// 取消一个日志事件
        /// </summary>
        /// <param name="handler"></param>
        public void UnregisterSqlLogger(LogHandler handler)
        {
            dbProvider.OnLog -= handler;
        }

        /// <summary>
        /// 注册一个日志事件
        /// </summary>
        /// <param name="handler"></param>
        public void RegisterSqlExceptionLogger(ExceptionLogHandler handler)
        {
            dbProvider.OnExceptionLog += handler;
        }

        /// <summary>
        /// 取消一个日志事件
        /// </summary>
        /// <param name="handler"></param>
        public void UnregisterSqlExceptionLogger(ExceptionLogHandler handler)
        {
            dbProvider.OnExceptionLog -= handler;
        }

        #endregion

        #endregion

        #region 私有方法

        private void InitSession(DbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
            this.dbProvider.SetEventHandler(Decrypt);
            this.dbTrans = new DbTrans(dbProvider, false);
        }

        #endregion

        #region 公共方法
        /// <summary>
        /// 执行ExecuteReader
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Trans"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string strSql)
        {
            return dbTrans.BeginBatch(10).ExecuteReader(strSql);
        }
        #endregion

        public DbBatch BeginBatch()
        {
            throw new NotImplementedException();
        }

        public DbBatch BeginBatch(int batchSize)
        {
            throw new NotImplementedException();
        }
    }
}
