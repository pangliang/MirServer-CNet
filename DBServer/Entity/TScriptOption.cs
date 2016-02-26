using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBServer.Entity
{
    public struct TScriptOption
    {
        // 280
        public string[] SerialBuffer;
        public int OwnerNumber;
        public int UserNumber;
        public uint SerialNumber;
        public int Version;
        public int MakeKey;
        public int Mode;
        public DateTime BeginDate;
        public DateTime EndDate;
        public int LicDay;
        public int[] Param;
    } // end TScriptOption
}
