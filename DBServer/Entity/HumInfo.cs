using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBServer.Entity
{
    public class HumInfo
    {
        public string Guid;
        public string sAccount;
        public bool boIsHero;
        public bool boSelected;
        public int nSelectID;
        public bool boDeleted;
        public DateTime dCreateDate;
        public DateTime dModDate;
        public int btCount;
        public HumDataInfo HumData;
    }
}
