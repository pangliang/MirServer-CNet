using GameFramework;
using NetFramework.AsyncSocketClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public unsafe static bool GetDBSockMsg(byte[] da, int nQueryID, ref int nIdent, ref int nRecog, ref string sStr, uint dwTimeOut, bool boLoadRcd, string sName)
        {
            bool result;
            bool boLoadDBOK;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string sCheckFlag = string.Empty;
            string sDefMsg;
            string s38;
            int nLen;
            int nCheckCode;
            TDefaultMessage DefMsg;
            boLoadDBOK = false;
            result = false;
            byte nCode = 0;
            const int DEFBLOCKSIZE = 32;
            while (true)
            {

                s24 = "";

                try
                {
                    fixed (byte* pb = da)
                    {
                        s24 = HUtil32.SBytePtrToString((sbyte*)pb, 0, da.Length);
                    }

                    s24 = System.Text.Encoding.Default.GetString(da);
                }
                finally
                {

                }
                if (s24 != "")
                {
                    s28 = "";
                    s24 = HUtil32.ArrestStringEx(s24, "#", "!", ref s28);
                    if (s28 != "")
                    {
                        s28 = HUtil32.GetValidStr3(s28, ref s2C, new string[] { "/" });
                        nLen = s28.Length;
                        if ((nLen >= sizeof(TDefaultMessage)) && (HUtil32.Str_ToInt(s2C, 0) == nQueryID))
                        {
                            nCheckCode = HUtil32.MakeLong(HUtil32.Str_ToInt(s2C, 0) ^ 170, nLen);
                            byte[] data = new byte[sizeof(int)];
                            fixed (byte* by = data)
                            {
                                *(int*)by = nCheckCode;
                            }
                            sCheckFlag = EncryptUnit.EncodeBuffer(data, data.Length);
                            if (HUtil32.CompareBackLStr(s28, sCheckFlag, sCheckFlag.Length))
                            {
                                if (nLen == DEFBLOCKSIZE)
                                {
                                    sDefMsg = s28;
                                    s38 = "";
                                }
                                else
                                {
                                    sDefMsg = s28.Substring(0, DEFBLOCKSIZE);
                                    s38 = s28.Substring(DEFBLOCKSIZE + 1 - 1, s28.Length - DEFBLOCKSIZE - 6);
                                }
                                DefMsg = EncryptUnit.DecodeMessage(sDefMsg);
                                nIdent = DefMsg.Ident;
                                nRecog = DefMsg.Recog;
                                sStr = s38;
                                boLoadDBOK = true;
                                result = true;
                                break;
                            }
                        }
                        else
                        {
                            if ((nLen < Marshal.SizeOf(typeof(TDefaultMessage))))
                            {
                                nCode = 2;
                            }
                            if ((HUtil32.Str_ToInt(s2C, 0) != nQueryID))
                            {
                                nCode = 4;
                            }
                            break;
                        }
                    }
                    else
                    {
                        nCode = 3;
                        break;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
            if (!boLoadDBOK)
            {
                if (boLoadRcd)
                {
                    //M2Share.MainOutMessage(sLoadDBTimeOut + sName + " Code:" + (nCode).ToString());
                }
                else
                {
                    //M2Share.MainOutMessage(sSaveDBTimeOut + sName + " Code:" + (nCode).ToString());
                }
            }
            else
            {

            }
            return result;
        }

        static unsafe void socket_ReceivedDatagram(object sender, NetFramework.DSCClientDataInEventArgs e)
        {
            var HumanRcd = new THumDataInfo();
            int a = 0, b = 0;
            string c = string.Empty;
            GetDBSockMsg(e.Data, 0, ref a, ref b, ref c, 0, true, "");
            string sDBMsg = string.Empty;
            c = HUtil32.GetValidStr3(c, ref sDBMsg, new string[] { "/" });

            int DataSize = Marshal.SizeOf(HumanRcd);


            MyTestInfo testinfo = new MyTestInfo();
            EncryptUnit.DecodeBuffer(c, ref HumanRcd);

            //TUserItem* bbbbbbbb= (TUserItem*)testinfo.UserItem;
        }

        static void socket_OnConnected(object sender, NetFramework.DSCClientConnectedEventArgs e)
        {
            Console.WriteLine("链接成功");
        }

        public unsafe static byte[] SendDBSockMsg(int nQueryID, string sMsg)
        {
            string sSENDMSG;
            int nCheckCode;
            string sCheckStr = string.Empty;
            nCheckCode = HUtil32.MakeLong(nQueryID ^ 170, sMsg.Length + 6);
            byte[] by = new byte[sizeof(int)];
            fixed (byte* pb = by)
            {
                *(int*)pb = nCheckCode;
            }
            sCheckStr = EncryptUnit.EncodeBuffer(by, by.Length);
            sSENDMSG = "#" + nQueryID + "/" + sMsg + sCheckStr + "!";

            byte[] data = System.Text.Encoding.Default.GetBytes(sSENDMSG);
            return HUtil32.StrToByte(sSENDMSG);
        }

        private unsafe void button1_Click(object sender, EventArgs e)
        {
            var saasdasdasdasd = "天魔神甲".Length;
           var sdasdsad=  HUtil32.GetStrLength("天魔神甲");

            IClientScoket socket = new IClientScoket();
            socket.OnConnected += socket_OnConnected;

            socket.Connect("127.0.0.1", 6000);
            socket.ReceivedDatagram += socket_ReceivedDatagram;
            TLoadHuman sLoadHuman = new TLoadHuman();
            sLoadHuman.sAccount = "123123";
            sLoadHuman.sChrName = "阿斯顿23";
            sLoadHuman.sUserAddr = "127.0.0.1";
            sLoadHuman.nSessionID = 15;

            string sDBMsg = EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(1000, 0, 0, 0, 0, 0)) + EncryptUnit.EncodeBuffer<TLoadHuman>(sLoadHuman);
            socket.Send(SendDBSockMsg(0, sDBMsg));
        }
    }
}
