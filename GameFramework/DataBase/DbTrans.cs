using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    /// <summary>
    /// 事务处理类
    /// </summary>
    public class DbTrans : IDbTrans, IDisposable
    {
        private DbConnection dbConnection;
        private DbTransaction dbTransaction;
        private DbProvider dbProvider;
        private DbBatch dbBatch;

        internal DbConnection Connection
        {
            get { return this.dbConnection; }
        }

        internal DbTransaction Transaction
        {
            get { return this.dbTransaction; }
        }

        /// <summary>
        /// 以DbTransaction方式实例化一个事务
        /// </summary>
        /// <param name="dbProvider"></param>
        /// <param name="dbTran"></param>
        internal DbTrans(DbProvider dbProvider, DbTransaction dbTran)
        {
            this.dbConnection = dbTran.Connection;
            this.dbTransaction = dbTran;
            if (this.dbConnection.State != ConnectionState.Open)
            {
                this.dbConnection.Open();
            }
            this.dbProvider = dbProvider;
            this.dbBatch = new DbBatch(dbProvider, this);
        }

        /// <summary>
        /// 以BbConnection方式实例化一个事务
        /// </summary>
        /// <param name="dbProvider"></param>
        /// <param name="dbConnection"></param>
        internal DbTrans(DbProvider dbProvider, DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            if (this.dbConnection.State != ConnectionState.Open)
            {
                this.dbConnection.Open();
            }
            this.dbProvider = dbProvider;
            this.dbBatch = new DbBatch(dbProvider, this);
        }

        internal DbTrans(DbProvider dbProvider, bool useTrans)
        {
            if (useTrans)
            {
                this.dbConnection = dbProvider.CreateConnection();
                this.dbConnection.Open();
                this.dbTransaction = dbConnection.BeginTransaction();
            }
            this.dbProvider = dbProvider;
            this.dbBatch = new DbBatch(dbProvider, this);
        }

        internal DbTrans(DbProvider dbProvider, IsolationLevel isolationLevel)
        {
            this.dbConnection = dbProvider.CreateConnection();
            this.dbConnection.Open();
            this.dbTransaction = dbConnection.BeginTransaction(isolationLevel);
            this.dbProvider = dbProvider;
            this.dbBatch = new DbBatch(dbProvider, this);
        }

        #region Batch操作

        /// <summary>
        /// 返回一个Batch
        /// </summary>
        /// <returns></returns>
        public DbBatch BeginBatch()
        {
            return BeginBatch(10);
        }

        /// <summary>
        /// 返回一个Batch
        /// </summary>
        /// <param name="batchSize">Batch大小</param>
        /// <returns></returns>
        public DbBatch BeginBatch(int batchSize)
        {
            return new DbBatch(dbProvider, this, batchSize);
        }

        #endregion

        #region 事务操作

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            try
            {
                dbTransaction.Commit();
            }
            catch
            {
                this.Close();
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            try
            {
                dbTransaction.Rollback();
            }
            catch
            {
                this.Close();
            }
        }

        /// <summary>
        /// Dispose事务
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }

        /// <summary>
        /// 关闭事务
        /// </summary>
        public void Close()
        {
            if (dbConnection.State != ConnectionState.Closed)
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }

        #endregion


    }
}