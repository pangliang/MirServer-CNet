using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameFramework.DataBase
{
    /// <summary>
    /// 批处理
    /// </summary>
    public class DbBatch : IDbBatch
    {
        private bool useBatch = false;
        private int batchSize;
        private DbProvider dbProvider;
        private DbTrans dbTrans;
        private List<DbCommand> commandList = new List<DbCommand>();

        internal DbBatch(DbProvider dbProvider, DbTrans dbTran, int batchSize)
        {
            this.dbProvider = dbProvider;
            this.batchSize = batchSize > 0 ? batchSize : 1;
            this.dbTrans = dbTran;
            this.useBatch = true;
        }

        internal DbBatch(DbProvider dbProvider, DbTrans dbTran)
        {
            this.dbProvider = dbProvider;
            this.dbTrans = dbTran;
            this.useBatch = false;
        }

        #region Trans操作

        /// <summary>
        /// 执行批处理操作
        /// </summary>
        /// <returns></returns>
        public int Process()
        {
            IList<Exception> errors;
            return Process(out errors);
        }

        /// <summary>
        /// 执行批处理操作
        /// </summary>
        /// <param name="errors">输出的错误</param>
        /// <returns></returns>
        public int Process(out IList<Exception> errors)
        {
            //实例化errors
            errors = new List<Exception>();
            int rowCount = 0;

            if (commandList.Count == 0)
            {
                //如果命令列表为空，则直接返回
                return rowCount;
            }

            //Access不能进行多任务处理
            if (!dbProvider.SupportBatch)
            {
                foreach (DbCommand cmd in commandList)
                {
                    try
                    {
                        //执行成功，则马上退出
                        rowCount += dbProvider.ExecuteNonQuery(cmd, dbTrans);
                    }
                    catch (DbException ex)
                    {
                        errors.Add(new Exception(ex.Message, ex));
                    }

                    //执行一次休眠一下
                    Thread.Sleep(10);
                }
            }
            else
            {
                int size = Convert.ToInt32(Math.Ceiling(commandList.Count * 1.0 / batchSize));
                for (int index = 0; index < size; index++)
                {
                    DbCommand mergeCommand = dbProvider.CreateSqlCommand("init");
                    List<DbCommand> cmdList = new List<DbCommand>();
                    int getSize = batchSize;
                    if ((index + 1) * batchSize > commandList.Count)
                    {
                        getSize = commandList.Count - index * batchSize;
                    }
                    cmdList.AddRange(commandList.GetRange(index * batchSize, getSize));
                    StringBuilder sb = new StringBuilder();

                    int pIndex = 0;
                    foreach (DbCommand cmd in cmdList)
                    {
                        string cmdText = cmd.CommandText;
                        foreach (DbParameter p in cmd.Parameters)
                        {
                            DbParameter newp = (DbParameter)((ICloneable)p).Clone();
                            mergeCommand.Parameters.Add(newp);
                        }
                        sb.Append(cmdText);
                        sb.Append(";\n");

                        pIndex++;
                    }

                    mergeCommand.CommandText = sb.ToString();

                    try
                    {
                        //执行成功，则马上退出
                        rowCount += dbProvider.ExecuteNonQuery(mergeCommand, dbTrans);
                    }
                    catch (DbException ex)
                    {
                        errors.Add(new Exception(ex.Message, ex));
                    }

                    //执行一次休眠一下
                    Thread.Sleep(10);
                }
            }

            //结束处理,清除命令列表
            commandList.Clear();

            return rowCount;
        }
        #endregion

        #region 操作
        public IDataReader ExecuteReader(string strSql)
        {
            var queryCommand = dbProvider.CreateSqlCommand(strSql);
            return dbProvider.ExecuteReader(queryCommand, dbTrans);
        }
        #endregion
    }
}
