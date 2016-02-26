using GameFramework;
using M2Server.ScriptSystem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace M2Server.Base
{
    /// <summary>
    /// 游戏服务基本操作类
    /// </summary>
    public abstract class GameBase
    {
        /// <summary>
        /// 服务器启动时间
        /// </summary>
        public static readonly DateTime StartTime;

        /// <summary>
        /// 服务器运行时间
        /// </summary>
        public static TimeSpan RunTime
        {
            get { return DateTime.Now - StartTime; }
        }

        /// <summary>
        /// 构造函数 静态
        /// </summary>
        static GameBase()
        {
            StartTime = DateTime.Now;
        }

        /// <summary>
        /// 游戏主配置文件
        /// </summary>
        public TGameConfig GameConfig { get { return M2Share.g_Config; } }

        /// <summary>
        /// 游戏引擎主类
        /// </summary>
        public TUserEngine UserEngine { get { return M2Share.UserEngine; } }

        /// <summary>
        /// 物品属性管理类
        /// </summary>
        public TItemUnit ItemUnit { get { return M2Share.ItemUnit; } }

        /// <summary>
        /// 行会管理类
        /// </summary>
        public TGuildManager GuildManager { get { return M2Share.g_GuildManager; } }

        /// <summary>
        /// 技能管理类
        /// </summary>
        public TMagicManager MagicManager { get { return M2Share.MagicManager; } }

        /// <summary>
        /// 游戏基础数据库
        /// </summary>
        public GameDataBase GameDataBase { get { return M2Share.GameDataBase; } }


        public void LoadEngineConfig()
        { 
            
        }


        /// <summary>
        /// 取对象HashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual Int32 Parse(object obj)
        {
            return HUtil32.ObjectToInt(obj);
        }

        /// <summary>
        /// 根据HashCode取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="HaseCode"></param>
        /// <returns></returns>
        public virtual T GetObject<T>(int HaseCode)
        {
            return HUtil32.IntToObject<T>(HaseCode);
        }

        /// <summary>
        /// 向主界面输出消息
        /// </summary>
        /// <param name="sMsg"></param>
        public virtual void MainOutMessage(string sMsg)
        {
            M2Share.MainOutMessage(sMsg);
        }

    }
}