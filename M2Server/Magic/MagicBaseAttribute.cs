using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GameMagicdAttribute : Attribute
    {
        /// <summary>
        /// 命令名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 命令说明
        /// </summary>
        public string Help { get; set; }

        public GameMagicdAttribute(string name, string help)
        {
            this.Name = name.ToLower();
            this.Help = help;
        }
    }

    /// <summary>
    /// 游戏入口点方法必须标识为DefaultCommand
    /// 例：
    /// [DefaultCommand]
    /// public void CmdTest(){}
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DefaultMagic : GameMagicdAttribute
    {
        public DefaultMagic()
            : base("", "")
        {
        }
    }
}