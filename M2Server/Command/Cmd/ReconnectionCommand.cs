using GameFramework;
using GameFramework.Command;

namespace M2Server.Command
{
    /// <summary>
    /// 此命令用于改变客户端连接网关的
    /// </summary>
    [GameCommand("Reconnection", "此命令用于改变客户端连接网关的", 10)]
    public class ReconnectionCommand : BaseCommond
    {
        [DefaultCommand]
        public void Reconnection(TPlayObject PlayObject,string[] @Params)
        {
            string sIPaddr = @Params.Length > 0 ? @Params[0] : "";
            string sPort = @Params.Length > 1 ? @Params[1] : "";
            if ((PlayObject.m_btPermission < 10))
            {
                return;
            }
            if ((sIPaddr != "") && (sIPaddr[1] == '?'))
            {
                PlayObject.SysMsg("此命令用于改变客户端连接网关的IP及端口。", TMsgColor.c_Blue, TMsgType.t_Hint);
                return;
            }
            if ((sIPaddr == "") || (sPort == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " IP地址 端口", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sIPaddr != "") && (sPort != ""))
            {
                PlayObject.SendMsg(PlayObject, Grobal2.RM_RECONNECTION, 0, 0, 0, 0, sIPaddr + '/' + sPort);
            }
        }
    }
}