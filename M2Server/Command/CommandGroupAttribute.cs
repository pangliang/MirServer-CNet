using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandGroupAttribute : Attribute
    {
        /// <summary>
        /// 命令名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 命令帮助说明
        /// </summary>
        public string Help { get; private set; }

        /// <summary>
        /// 命令权限
        /// </summary>
        public byte MinUserLevel { get; private set; }

        public CommandGroupAttribute(string name, string help, byte minUserLevel = 0)
        {
            this.Name = name.ToLower();
            this.Help = help;
            this.MinUserLevel = minUserLevel;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        /// <summary>
        /// 命令名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 命令帮助说明
        /// </summary>
        public string Help { get; private set; }

        /// <summary>
        /// 命令权限
        /// </summary>
        public byte MinUserLevel { get; private set; }

        public CommandAttribute(string command, string help, byte minUserLevel = 0)
        {
            this.Name = command.ToLower();
            this.Help = help;
            this.MinUserLevel = minUserLevel;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class DefaultCommand : CommandAttribute
    {
        public DefaultCommand(byte minUserLevel = 0)
            : base("", "", minUserLevel)
        {
        }
    }
}
