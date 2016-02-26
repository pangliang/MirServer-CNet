using GameFramework;
using GameFramework.Command;
using M2Server.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command.Cmd.Server
{
    /// <summary>
    /// 查看当前服务器状态
    /// </summary>
    [GameCommand("ServerStatus", "查看当前服务器状态", 10)]
    public class ServerStatusCommand : BaseCommond
    {
        [DefaultCommand]
        public void ServerStatus(TPlayObject PlayObject,string[] @Params)
        {
            foreach (var line in EngineStats.Instance.GetFullStats())
            {
                PlayObject.SysMsg(line, TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}