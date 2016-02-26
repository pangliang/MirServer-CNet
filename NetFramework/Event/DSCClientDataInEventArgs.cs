using System;
using System.Net.Sockets;

namespace NetFramework
{
    public class DSCClientDataInEventArgs : EventArgs
    {
        public byte[] Data;
        public Socket socket;

        public DSCClientDataInEventArgs(Socket soc, byte[] datain)
        {
            this.socket = soc;
            this.Data = datain;
        }
    }
}