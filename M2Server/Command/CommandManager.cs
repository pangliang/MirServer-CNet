using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace M2Server
{
    public static class CommandManager
    {
        public static readonly Dictionary<GameCommandAttribute, BaseCommond> CommandGroups = new Dictionary<GameCommandAttribute, BaseCommond>();

        static CommandManager()
        {
            RegisterCommandGroups();
        }

        /// <summary>
        /// 注册游戏命令
        /// </summary>
        private static void RegisterCommandGroups()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!type.IsSubclassOf(typeof(BaseCommond))) continue;//只有继承BaseCommond，才能添加到命令对象中

                var attributes = (GameCommandAttribute[])type.GetCustomAttributes(typeof(GameCommandAttribute), true);
                if (attributes.Length == 0) continue;

                var groupAttribute = attributes[0];
                if (CommandGroups.ContainsKey(groupAttribute))
                {
                    M2Share.MainOutMessage(String.Format("游戏命令重复: {0}", groupAttribute.Name));
                }
                var commandGroup = (BaseCommond)Activator.CreateInstance(type);
                commandGroup.Register(groupAttribute);
                CommandGroups.Add(groupAttribute, commandGroup);
            }
        }

        /// <summary>
        /// 更新游戏命令
        /// </summary>
        /// <param name="OldCmd"></param>
        /// <param name="sCmd"></param>
        public static void UpdataRegisterCommandGroups(GameCommandAttribute OldCmd, string sCmd)
        {
            if (CommandGroups.ContainsKey(OldCmd))
            {
                foreach (var pair in CommandGroups)
                {
                    if (pair.Key.Name != "make") continue;
                    pair.Key.Name = "item";
                }

                //var commandGroup = (CommandGroup)Activator.CreateInstance(typeof(MakeItmeCommand));
                //commandGroup.Register(NewCmd);
                //CommandGroups.Add(NewCmd, commandGroup);
                //CommandGroups.Remove(OldCmd);
            }
        }

        /// <summary>
        /// 执行游戏命令
        /// </summary>
        /// <param name="line">命令字符串</param>
        /// <param name="invokerClient">命令对象</param>
        /// <returns><see cref="bool"/></returns>
        public static void ExecCmd(string line, TPlayObject PlayObject)
        {
            string output = string.Empty;
            string command;
            string parameters;
            bool found = false;

            if (PlayObject == null)
                throw new ArgumentException("PlayObject");

            if (!ExtractCommandAndParameters(line, out command, out parameters))
                return;

            foreach (var pair in CommandGroups)
            {
                if (pair.Key.Name != command) continue;
                output = pair.Value.Handle(parameters, PlayObject);
                found = true;
                break;
            }

            if (found == false)//修正命令错误提示
            {
                //if (PlayObject != null)
                //{
                //    PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, command, GameMsgDef.g_sGamecommandMakeHelpMsg),
                //        TMsgColor.c_Red, TMsgType.t_Hint);
                //}
                output = string.Format("未知命令: {0} {1}", command, parameters);
            }

            //把返回结果给玩家
            if (output != "" && output != null)
            {
                PlayObject.SysMsg(output, TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }

        /// <summary>
        /// 构造游戏命令
        /// </summary>
        /// <param name="line">字符串</param>
        /// <param name="command">返回 命令名称</param>
        /// <param name="parameters">返回 命令参数</param>
        /// <returns>解析是否成功</returns>
        internal static bool ExtractCommandAndParameters(string line, out string command, out string parameters)
        {
            line = line.Trim();
            command = string.Empty;
            parameters = string.Empty;

            if (line == string.Empty)
                return false;

            if (line[0] != '@') // 检查命令首字母是否为指定的字符串
                return false;

            line = line.Substring(1);
            command = line.Split(' ')[0].ToLower(); // 取命令
            parameters = String.Empty;
            if (line.Contains(' ')) parameters = line.Substring(line.IndexOf(' ') + 1).Trim(); // 取命令参数

            return true;
        }

        [GameCommand("commands", "列出可用的命令")]
        public class CommandsCommandGroup : BaseCommond
        {
            public override string Fallback(string[] parameters = null, TPlayObject PlayObject = null)
            {
                var output = "Available commands: ";
                foreach (var pair in CommandGroups)
                {
                    if (PlayObject != null && pair.Key.nPermissionMin > PlayObject.m_btPermission) continue;
                    output += pair.Key.Name + ", ";
                }

                output = output.Substring(0, output.Length - 2) + ".";
                return output + "\nType 'help <command>' to get help.";
            }
        }

        [GameCommand("help", "帮助命令")]
        public class HelpCommandGroup : BaseCommond
        {
            public override string Fallback(string[] parameters = null, TPlayObject PlayObject = null)
            {
                return "usage: help <command>";
            }

            public override string Handle(string parameters, TPlayObject PlayObject = null)
            {
                if (parameters == string.Empty)
                    return this.Fallback();

                string output = string.Empty;
                bool found = false;
                var @params = parameters.Split(' ');
                var group = @params[0];
                var command = @params.Count() > 1 ? @params[1] : string.Empty;

                foreach (var pair in CommandGroups)
                {
                    if (group != pair.Key.Name)
                        continue;

                    if (command == string.Empty)
                        return pair.Key.Help;

                    output = pair.Value.GetHelp(command);
                    found = true;
                }

                if (!found)
                    output = string.Format("Unknown command: {0} {1}", group, command);

                return output;
            }
        }
    }
}