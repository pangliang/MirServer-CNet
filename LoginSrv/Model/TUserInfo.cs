using System;
using System.Net.Sockets;

namespace LoginSrv.Model
{
    public class TUserInfo
    {
        // Size 0x68 Address: 0x004686C8
        public string sAccount;

        // 0x00
        public string sUserIPaddr;

        // 0x0B
        public string sGateIPaddr;

        // 用户连接到网关，网关的连接IP
        public string sSockIndex;

        // 0x20
        public int nVersionDate;

        // 0x24
        public bool boCertificationOK;

        // 0x28
        public bool bo29;

        // 0x29
        public bool bo2A;

        // 0x2A
        public bool bo2B;

        // 0x2B
        public int nSessionID;

        // 0x2C
        public bool boPayCost;

        // 0x30
        public int nIDDay;

        // 0x34
        public int nIDHour;

        // 0x38
        public int nIPDay;

        // 0x3C
        public int nIPHour;

        // 0x40
        public DateTime dtDateTime;

        // 0x48
        public string sServerName;

        public bool boSelServer;

        // 0x50
        public bool bo51;

        // 0x51
        public Socket Socket;

        // 0x54
        public string sReceiveMsg;

        // 0x58
        public uint dwTime5C;

        // 0x5C
        public bool bo60;

        // 0x60
        public bool bo61;

        // 0x61
        public bool bo62;

        // 0x62
        public bool bo63;

        // 0x63
        public uint dwClientTick;

        public uint dwStartTick;
        public uint dwMakeAccountTick;

        // nRandomCode: Integer;
        // boRandomCode: Boolean; //0x5
        public TGateInfo Gate;
    } // end TUserInfo
}