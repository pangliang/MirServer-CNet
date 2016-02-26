using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GameFramework.DataBase
{
    /// <summary>
    /// 对任意类型添加文字描述
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumDescriptionAttribute : Attribute
    {
        private string _desc;

        public EnumDescriptionAttribute(string desc)
        {
            _desc = desc;
        }

        public string Description
        {
            get
            {
                return _desc;
            }
        }

        /// <summary>
        /// 获取枚举类型的描述
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static string GetDescription(object enumObj)
        {
            Type enumType = enumObj.GetType();
            if (!enumType.IsEnum)
            {
                throw new Exception("参数不是枚举类型！");
            }
            FieldInfo fieldInfo = enumType.GetField(enumObj.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0) return null;
            EnumDescriptionAttribute attrib = attribArray[0] as EnumDescriptionAttribute;
            return attrib.Description;
        }

        /// <summary>
        /// 获取枚举类型的所有描述
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string[] GetDescriptions(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new Exception("参数不是枚举类型！");
            }
            FieldInfo[] fieldInfos = enumType.GetFields();
            List<string> deslist = new List<string>();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                object[] attribArray = fieldInfo.GetCustomAttributes(false);
                if (attribArray.Length == 0) continue;
                EnumDescriptionAttribute attrib = attribArray[0] as EnumDescriptionAttribute;
                deslist.Add(attrib.Description);
            }
            return deslist.ToArray();
        }
    }

    /// <summary>
    /// 驱动类型
    /// </summary>
    public enum ProviderType
    {
        /// <summary>
        /// Access数据库
        /// </summary>
        [EnumDescription("AccessProvider")]
        Access,
        /// <summary>
        /// SqlServer2000数据库
        /// </summary>
        [EnumDescription("SqlServerProvider")]
        SqlServer,
        /// <summary>
        /// SqlServer2005数据库
        /// </summary>
        [EnumDescription("GameFramework.DataBase.MsSql")]
        SqlServer9,
        /// <summary>
        /// Oracle数据库
        /// </summary>
        [EnumDescription("OracleProvider")]
        Oracle,
        /// <summary>
        /// MySql数据库
        /// </summary>
        [EnumDescription("MySqlProvider")]
        MySql,
        /// <summary>
        /// SQLite数据库
        /// </summary>
        [EnumDescription("SQLiteProvider")]
        SQLite,
        /// <summary>
        /// FireBird数据库
        /// </summary>
        [EnumDescription("FireBirdProvider")]
        FireBird,
        /// <summary>
        /// PostgreSQL数据库
        /// </summary>
        [EnumDescription("PostgreSQLProvider")]
        PostgreSQL
    }

    /// <summary>
    /// The db provider factory.
    /// </summary>
    public sealed class ProviderFactory
    {
        #region Private Members

        private static IDictionary<string, DbProvider> providerCache = new Dictionary<string, DbProvider>();

        private ProviderFactory() { }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates the db provider.
        /// </summary>
        /// <param name="connectionString">Name of the conn STR.</param>
        /// <returns>The db provider.</returns>
        public static DbProvider CreateDbProvider(ProviderType providerType, string connectionString)
        {
            try
            {
                string[] assAndClass = EnumDescriptionAttribute.GetDescription(providerType).Split(',');
                DbProvider dbProvider;
                if (assAndClass.Length > 1)
                    dbProvider = CreateDbProvider(assAndClass[1].Trim(), assAndClass[0].Trim(), connectionString);
                else
                    dbProvider = CreateDbProvider(null, assAndClass[0].Trim(), connectionString);

                if (dbProvider != null) dbProvider.ConnectName = "Default";
                return dbProvider;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Creates the db provider.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="connectionString">The conn STR.</param>
        /// <returns>The db provider.</returns>
        public static DbProvider CreateDbProvider(string assemblyName, string className, string connectionString)
        {
            //Check.Require(!string.IsNullOrEmpty(className), "className could not be null.");

            if (connectionString.ToLower().Contains("microsoft.jet.oledb") || connectionString.ToLower().Contains(".db3"))
            {
                if (connectionString.ToLower().IndexOf("data source") < 0)
                {
                    throw new Exception("ConnectionString的格式有错误，请查证！");
                }
                string mdbPath = connectionString.Substring(connectionString.ToLower().IndexOf("data source") + "data source".Length + 1).TrimStart(' ', '=');
                if (mdbPath.ToLower().StartsWith("|datadirectory|"))
                {
                    mdbPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\App_Data" + mdbPath.Substring("|datadirectory|".Length);
                }
                else if (connectionString.StartsWith("./") || connectionString.EndsWith(".\\"))
                {
                    connectionString = connectionString.Replace("/", "\\").Replace(".\\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\");
                }
                connectionString = connectionString.Substring(0, connectionString.ToLower().IndexOf("data source")) + "Data Source=" + mdbPath;
            }

            //如果是~则表示当前目录
            if (connectionString.Contains("~/") || connectionString.Contains("~\\"))
            {
                connectionString = connectionString.Replace("/", "\\").Replace("~\\", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\");
            }

            //by default, using sqlserver db provider
            if (string.IsNullOrEmpty(className))
            {
                className = typeof(MsSqlProvider).ToString();
            }
            else if (className.ToLower().IndexOf("System.Data.SqlClient".ToLower()) >= 0 || className.ToLower().Trim() == "sql" || className.ToLower().Trim() == "sqlserver")
            {
                className = typeof(MsSqlProvider).ToString();
            }
            else if (className.ToLower().Trim() == "sql9" || className.ToLower().Trim() == "sqlserver9" || className.ToLower().Trim() == "sqlserver2005" || className.ToLower().Trim() == "sql2005")
            {
                className = typeof(MsSql).ToString();
            }

            System.Reflection.Assembly ass;
            if (string.IsNullOrEmpty(assemblyName))
                ass = typeof(DbProvider).Assembly;
            else
                ass = System.Reflection.Assembly.Load(assemblyName);

            string cacheKey = string.Format("{0}_{1}_{2}", assemblyName, className, connectionString);
            if (providerCache.ContainsKey(cacheKey))
            {
                return providerCache[cacheKey];
            }
            else
            {
                DbProvider retProvider = ass.CreateInstance(className, false, System.Reflection.BindingFlags.Default, null, new object[] { connectionString }, null, null) as DbProvider;
                if (retProvider != null) providerCache[cacheKey] = retProvider;
                return retProvider;
            }
        }

        /// <summary>
        /// Gets the default db provider.
        /// </summary>
        /// <value>The default.</value>
        public static DbProvider Default
        {
            get
            {
                try
                {
                    DbProvider dbProvider;
                    ConnectionStringSettings connStrSetting = ConfigurationManager.ConnectionStrings[ConfigurationManager.ConnectionStrings.Count - 1];
                    string[] assAndClass = connStrSetting.ProviderName.Split(',');
                    if (assAndClass.Length > 1)
                    {
                        dbProvider = CreateDbProvider(assAndClass[1].Trim(), assAndClass[0].Trim(), connStrSetting.ConnectionString);
                    }
                    else
                    {
                        dbProvider = CreateDbProvider(null, assAndClass[0].Trim(), connStrSetting.ConnectionString);
                    }
                    if (dbProvider != null) dbProvider.ConnectName = connStrSetting.Name;
                    return dbProvider;
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Creates the db provider.
        /// </summary>
        /// <param name="connectName">Name of the conn STR.</param>
        /// <returns>The db provider.</returns>
        public static DbProvider CreateDbProvider(string connectName)
        {
            try
            {
                DbProvider dbProvider;
                ConnectionStringSettings connStrSetting = ConfigurationManager.ConnectionStrings[connectName];
                string[] assAndClass = connStrSetting.ProviderName.Split(',');
                if (assAndClass.Length > 1)
                {
                    dbProvider = CreateDbProvider(assAndClass[1].Trim(), assAndClass[0].Trim(), connStrSetting.ConnectionString);
                }
                else
                {
                    dbProvider = CreateDbProvider(null, assAndClass[0].Trim(), connStrSetting.ConnectionString);
                }
                dbProvider.ConnectName = connectName;
                return dbProvider;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Creates the db provider.
        /// </summary>
        /// <param name="connStrName">Name of the conn STR.</param>
        /// <returns>The db provider.</returns>
        public static DbProvider CreateDbProvider(string connectName, ProviderType providerType)
        {
            try
            {
                ConnectionStringSettings connStrSetting = ConfigurationManager.ConnectionStrings[connectName];
                DbProvider dbProvider = CreateDbProvider(providerType, connStrSetting.ConnectionString);
                if (dbProvider != null) dbProvider.ConnectName = connStrSetting.Name;

                return dbProvider;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
