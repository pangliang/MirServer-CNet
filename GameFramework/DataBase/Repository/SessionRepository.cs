using GameFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Repository
{
    /// <summary>
    /// 数据库会话处理
    /// </summary>
    public abstract class SessionRepository
    {
        private DbSession session;

        public SessionRepository(string connectionName)
        {
            session = new DbSession(GetDbProvider(connectionName));
        }

        /// <summary>
        /// 检测数据库是否能连接上
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns></returns>
        public Boolean CheckConnect(string connectionString)
        {
            try
            {
                GetSession(connectionString).CreateConnection().Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DbSession GetDbSession()
        {
            return session;
        }

        /// <summary>
        /// 获取驱动类型
        /// </summary>
        /// <returns></returns>
        public abstract ProviderType GetProviderType();

        /// <summary>
        /// 创建连接会话，指定链接字符串
        /// </summary>
        /// <returns></returns>
        private DbSession GetSession(string connectionString)
        {
            DbProvider dbProvider = ProviderFactory.CreateDbProvider(GetProviderType(), connectionString);
            return new DbSession(dbProvider);
        }

        /// <summary>
        /// 获取驱动
        /// </summary>
        /// <returns></returns>
        private DbProvider GetDbProvider(string connectionName)
        {
            return ProviderFactory.CreateDbProvider(connectionName, GetProviderType());
        }

        /// <summary>
        /// 获取驱动
        /// </summary>
        /// <returns></returns>
        private DbProvider GetDbProviderFromConnectionString(string connectionString)
        {
            return ProviderFactory.CreateDbProvider(GetProviderType(), connectionString);
        }


    }

}
