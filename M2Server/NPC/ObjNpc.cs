using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace M2Server
{

    /// <summary>
    /// 物品价格结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TItemPrice
    {
        public ushort wIndex;
        public int nPrice;
    }

    public class TSellItemPrice
    {
        public ushort wIndex;
        public int nPrice;
    }

    public class TQuestActionInfo
    {
        public int nCMDCode;
        public string sParam1 = string.Empty;
        public int nParam1;
        public string sParam2 = string.Empty;
        public int nParam2;
        public string sParam3 = string.Empty;
        public int nParam3;
        public string sParam4 = string.Empty;
        public int nParam4;
        public string sParam5 = string.Empty;
        public int nParam5;
        public string sParam6 = string.Empty;
        public int nParam6;
        public string sParam7 = string.Empty;
        public int nParam7;
    }

    public class TQuestConditionInfo
    {
        public int nCMDCode;
        public string sParam1 = string.Empty;
        public int nParam1;
        public string sParam2 = string.Empty;
        public int nParam2;
        public string sParam3 = string.Empty;
        public int nParam3;
        public string sParam4 = string.Empty;
        public int nParam4;
        public string sParam5 = string.Empty;
        public int nParam5;
        public string sParam6 = string.Empty;
        public int nParam6;
        public string sParam7 = string.Empty;
        public int nParam7;
    }

    public class TSayingProcedure
    {
        public IList<TQuestConditionInfo> ConditionList;
        public IList<TQuestActionInfo> ActionList;
        public string sSayMsg;
        public IList<TQuestActionInfo> ElseActionList;
        public string sElseSayMsg;
    }

    public class TSayingRecord
    {
        public string sLabel;
        public IList<TSayingProcedure> ProcedureList;
        public bool boExtJmp;
    }
}

