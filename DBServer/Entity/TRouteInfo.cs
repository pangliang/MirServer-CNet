using System.Collections.Generic;

namespace DBServer.Entity
{
    public class TRouteInfo
    {
        public int nGateCount;
        public string sSelGateIP;
        public List<string> sGameGateIP = new List<string>();
        public List<int> nGameGatePort = new List<int>();
    }
}