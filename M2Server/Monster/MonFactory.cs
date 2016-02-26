using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace M2Server
{
    /// <summary>
    /// 怪物抽象工厂
    /// </summary>
    public abstract class MonFactory
    {
        /// <summary>
        /// 创建怪物
        /// </summary>
        /// <param name="MonName"></param>
        public abstract TBaseObject CreateMonster(string MonName, Type type);
    }

    public class MonsterFactory : MonFactory
    {
        public override TBaseObject CreateMonster(string MonName, Type type)
        {
            return (TBaseObject)Activator.CreateInstance(type); 
        }
    }
}
