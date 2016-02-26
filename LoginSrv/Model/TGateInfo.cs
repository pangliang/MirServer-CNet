using System.Collections.Generic;
using System.Net.Sockets;

namespace LoginSrv.Model
{
    public class TGateInfo
    {
        public Socket Socket;
        public string sIPaddr;
        public string sReceiveMsg;
        public List<TUserInfo> UserList;
        public uint dwKeepAliveTick;
    }
}