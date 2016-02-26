using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NetFramework.AsyncSocketClient;
using GameFramework.DataBase;
using System.Threading;

namespace TestProject
{
    abstract class Program
    {
        unsafe static void Main(string[] args)
        {
            GameBaseTest g1 = new GameBaseTest();
            int n1 = g1.Parse(g1.GameConfig);
            Console.WriteLine(n1);
            Console.ReadKey();
            return;
            GameBaseTest g = new GameBaseTest();
            g.test();
            Thread.Sleep(1000);
            g = new GameBaseTest();
            g.test();
            Console.ReadKey();
            return;
            Console.Write(int.MaxValue);
            Console.ReadKey();
            return;

            int sasdasdasdasd = sizeof(TUnbindInfo);//4491
            int asdasd = Marshal.SizeOf(typeof(THumDataInfo));
           

            Console.ReadLine();


            DbSession dbsession = new DbSession("MyTest");


            TDefaultMessage hun = new TDefaultMessage();
            int HumSize = Marshal.SizeOf(hun);



            TStdItem a = new TStdItem();
            MyRefTest(a);

           // Console.WriteLine(a.Name);

            IClientScoket socket = new IClientScoket();
            socket.OnConnected += socket_OnConnected;
            socket.ReceivedDatagram += socket_ReceivedDatagram;
            socket.Connect("127.0.0.1", 6000);

            TDefaultMessage DefMsg = EncryptUnit.MakeDefaultMsg(1000, 0, 0, 0, 0, 0);


            TLoadHuman sLoadHuman = new TLoadHuman();
            int aaaaaaaaaaaa = Marshal.SizeOf(sLoadHuman);
            sLoadHuman.sAccount = "123123";
            sLoadHuman.sChrName = "啊啊啊啊";
            sLoadHuman.sUserAddr = "127.0.0.1";
            sLoadHuman.nSessionID = 15;
            byte[] sdata = StructToBytes(sLoadHuman);

           // string sDBMsg = EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeBuffer<TLoadHuman>(sLoadHuman);
          //  socket.Send(SendDBSockMsg(0, sDBMsg));

            Console.WriteLine("ok");
            Console.ReadKey();


            //TStdItem a = new TStdItem();
            // MyRefTest(a);
            // Console.WriteLine(a.Name);

            TUnbindInfo abc = new TUnbindInfo();
            int MySize = Marshal.SizeOf(abc);

            HUtil32._MIN(Int32.MaxValue, 14 + (int)Math.Floor(1 / (double)6 + 2.5 * 1));

            Math.Round(Math.Round((double)50 / 100,1), 1);

            decimal aaaaaaaaa = Round((decimal)Round((decimal)50.0 / 100, 1) * 368, 2);

 


            //string strss=  EncryptUnit.EncodeBuffer(StructToBytes(a, Marshal.SizeOf(typeof(Struct1))), Marshal.SizeOf(typeof(Struct1)));

            Class1 b = new Class1();
            b.Id = 1;
            b.Name = "张三";

            string strbb = EncryptUnit.EncodeBuffer(ObjectToBytes(b),8);

            b.Name = "张三";
            //string a = "你好吗";
             
            //sbyte[] by = new sbyte[StringToSBytePtr(a, null, 1) + 1];
            //fixed (sbyte* pb = by)
            //{
            //    StringToSBytePtr(a, pb, 1);
            //    string b = SBytePtrToString(pb, 1, by.Length - 1);
            //    Console.WriteLine(b);
            //}

            //int nLen = StringToIntPtrPlusLen(a, (IntPtr)0, 0);
            //byte[] byy = new byte[nLen + 1];
            //fixed (byte* pb = byy)
            //{
            //    StringToIntPtrPlusLen(a, (IntPtr)pb, 1);
            //    string b = IntPtrPlusLenToString((IntPtr)pb, 1);
            //    Console.WriteLine(b);
            //}








            Test t = new Test();
            t.Main();

           // THumDataInfo* HumanRcd = (THumDataInfo*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(THumDataInfo)));

            //byte[] data=new byte[sizeof(THumDataInfo)];
            //fixed (byte* pb = data)
            //{
            //    *(THumDataInfo*)pb = *HumanRcd;
            //}

            TProcessMessage msg = new TProcessMessage();



            int aaaaaaaaaaa = Marshal.SizeOf(typeof(TProcessMessage));

       

            var arrayDouble = Enumerable.Range(1, 1024)
                                     .Select(i => (int)i)
                                     .ToArray();

            fixed (int* p = arrayDouble)
            {
                var array2 = ToByte<int>(p, 1);

                //Assert.AreEqual(arrayDouble, array2);
            }

          




            int[,] arr4 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };


            //byte[, ,] arr = new byte[8,4,4]
            //{
            //    {
            //        {1,2},{1,2}
            //    },
            //    {
            //        {1,2},{1,2}
            //    }
            //};

            byte[, ,] arr = new byte[,,]
			{
				{
					{1,2},{1,2}
				},
				{
					{21,22},{21,22}
				},
				{
					{31,32},{31,32}
				}
				
			};


            string sText = "G73";
            int nValNo = 0;
            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);

            byte[] buff = System.Text.Encoding.GetEncoding("gb2312").GetBytes("我是测试字符串"); ;
            string str2 = string.Empty;
            for (int i = 0; i < 14; i++)
            {
                str2 += String.Format("{0:X2}", buff[i]) + ",";
            }

            string aa = System.Text.Encoding.GetEncoding("gb2312").GetString(buff);

            Console.WriteLine(str2);
            Console.WriteLine(aa);


            //Console.WriteLine(sizeof(TStdItem));

            //Console.WriteLine(Marshal, sizeof(PTDealOffInfo));

            string str = string.Empty;
            string FColor = string.Empty;
            string BColor = string.Empty;
            string nTime = string.Empty;
            string sMsg = "{180,251} 3 战斗区域";
            sMsg = HUtil32.ArrestStringEx(sMsg, "{", "}", ref str);
            str = HUtil32.GetValidStrCap(str, ref FColor, new string[] { "," });
            str = HUtil32.GetValidStrCap(str, ref BColor, new string[] { "," });
            str = HUtil32.GetValidStrCap(str, ref nTime, new string[] { "," });


            Console.WriteLine(MakeWord((byte)255, (byte)56));

            //m_CanJmpScriptLableList = new List<string>();
            //string msg = @"欢迎，我能为你做点什么？\ \<买/@buy>  物品\<卖/@sell>  物品\<特修毒符/@s_repair>\<询问/@questionprize> 物品详细情况 \<离 开/@exit>\";

            //GetScriptLabel(msg);

            //Console.WriteLine(sizeof(TClientMagic));

            //Console.WriteLine(Marshal.SizeOf(typeof(TClientMagic)));

            //int ccc = sizeof(TClientMagic);

            //@@rmst

            //strLen = sLabel.Substring(0, sLabel.Length - 1);

            //s18 = sLabel.Substring(strLen.Length + 1, sLabel.Length - strLen.Length);

            //Console.WriteLine(m_CanJmpScriptLableList.Count);

            //string aaaa= sub_49ADB8("<$USERNAME>加入游戏,<$SERVERNAME>又多了一份力量!", "<$USERNAME>", "1234");

            //aaaa = sub_49ADB8(aaaa, "<$SERVERNAME>", "12345");

  

            Console.ReadKey();
        }

        public static List<string> m_CanJmpScriptLableList;

        public static byte[] StructToBytes(object structObj, int size)
        {
            //得到结构体的大小
            //int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] _bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, _bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return _bytes;
        }

        public static byte[] ObjectToBytes<T>(T obj)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    return ms.GetBuffer();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 自写四舍五入法
        /// </summary>
        /// <param name="sourceNum">要进行处理的数据</param>
        /// <param name="toRemainIndex">保留的小数位数</param>
        /// <returns>四舍五入后的结果</returns>
        /// <Author> frd  2011-11-2417:06</Author>
        public static decimal Round(decimal sourceNum, int toRemainIndex)
        {
            decimal result = sourceNum;
            string sourceString = sourceNum.ToString();
            //没有小数点,则返回原数据+"."+"保留小数位数个0"
            if (!sourceString.Contains("."))
            {
                result = Convert.ToDecimal(sourceString + "." + CreateZeros(toRemainIndex));
                return result;
            }
            //小数点的位数没有超过要保留的位数,则返回原数据+"保留小数位数 - 已有的小数位"个0
            if ((sourceString.Length - sourceString.IndexOf(".") - 1) <= toRemainIndex)
            {
                result = Convert.ToDecimal(sourceString + CreateZeros(toRemainIndex - (sourceString.Length - sourceString.IndexOf(".") - 1)));
                return result;
            }
            string beforeAbandon_String = string.Empty;
            beforeAbandon_String = sourceString.Substring(0, sourceString.IndexOf(".") + toRemainIndex + 1);
            //取得如3.1415926保小数点后4位(原始的,还没开始取舍)，中的3.1415
            decimal beforeAbandon_Decial = Convert.ToDecimal(beforeAbandon_String);

            //如果保留小数点后N位，则判断N+1位是否大于等于5，大于，则进一，否则舍弃。
            if (int.Parse(sourceString.Substring(sourceString.IndexOf(".") + toRemainIndex + 1, 1)) >= 5)
            {
                #region 四舍五入算法说明
                //进一的方法举例 3.1415926,因为5后面的是9，所以5要进一位：如下：
                // 3.1415
                //         +
                // 0.0001
                //_________
                // 3.1416
                //保留N位时：
                // 3.14.......15
                //             +
                // 0.00.......01
                //_________
                // 3.14.......16
                #endregion
                string toAddAfterPoint = "0." + CreateZeros(toRemainIndex - 1) + "1";
                result = beforeAbandon_Decial + Convert.ToDecimal(toAddAfterPoint);
            }
            else
            {
                result = beforeAbandon_Decial;
            }
            return result;
        }


        /// <summary>
        /// 补 "0"方法.
        /// </summary>
        /// <param name="zeroCounts">生成个数.</param>
        /// <returns></returns>
        /// <Author> frd  2011-11-2511:06</Author>
        private static string CreateZeros(int zeroCounts)
        {
            string Result = string.Empty;
            if (zeroCounts == 0)
            {
                Result = "";
                return Result;
            }
            for (int i = 0; i < zeroCounts; i++)
            {
                Result += "0";
            }
            return Result;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public unsafe struct TENMapHeader //Size 54
        {
            public byte TitleLen;
            public fixed sbyte Title[16];
            public UInt32 Reserved;
            public UInt16 Width;
            public UInt16 Not1;
            public UInt16 Height;
            public UInt16 Not2;
            public fixed sbyte Reserved2[25];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Ansi)]
        public unsafe struct TUnbindInfo
        {
            public int nUnbindCode;
            public byte sItemNameLen;
            public fixed sbyte sItemName[14];
        }

        public static byte[] ObjectToByteA(object obj)
        {
            MemoryStream fs = new MemoryStream();
            byte[] tmp = null;
            try
            {
                // 序列化
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
                tmp = fs.ToArray();
            }
            catch (Exception e)
            {

            }
            finally
            {
                fs.Close();
            }
            return tmp;
        }

        public static byte[] StructToBytes(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }

        public unsafe static void MyRefTest(TStdItem r)
        {
            // r.Name = "草泥马";   
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

        static unsafe void socket_ReceivedDatagram(object sender, NetFramework.DSCClientDataInEventArgs e)
        {
            var HumanRcd = new THumDataInfo();
            int a = 0, b = 0;
            string c = string.Empty;
            GetDBSockMsg(e.Data, 0, ref a, ref b, ref c, 0, true, "");
            string sDBMsg = string.Empty;
            c = HUtil32.GetValidStr3(c, ref sDBMsg, new string[] { "/" });
            int DataSize = Marshal.SizeOf(HumanRcd);
            if (HUtil32.GetCodeMsgSize(DataSize * 4 / 3) == c.Length)
            {
                EncryptUnit.DecodeBuffer<THumDataInfo>(c, ref HumanRcd);
            }
            //if (HumanRcd.Data.BagItems[0] != null)
            //{
            //    TUserItem hun = new TUserItem();
            //    int HumSize = Marshal.SizeOf(hun);
            //}
        }

        static void socket_OnConnected(object sender, NetFramework.DSCClientConnectedEventArgs e)
        {
            Console.WriteLine("链接成功");
        }

        public struct Struct1
        {
            public int Id;
            public string Name;
        }

        [Serializable]
        public class Class1
        {
            public int Id;
            public string Name;
        }

        [StructLayout(LayoutKind.Auto)]
        public struct TProcessMessage
        {
            public int wIdent;
            public int wParam;
            public int nParam1;
            public int nParam2;
            public int nParam3;
            public int BaseObject;
            public bool boLateDelivery;
            public uint dwDeliveryTime;
            public String sMsg;
        }

        public unsafe static T[] ToByte<T>(void* source, int length)
        {
            var type = typeof(T);
            var sizeInBytes = Marshal.SizeOf(typeof(T));

            T[] output = new T[length];

            if (type.IsPrimitive)
            {
                // Make sure the array won't be moved around by the GC 
                var handle = GCHandle.Alloc(output, GCHandleType.Pinned);

                var destination = (byte*)handle.AddrOfPinnedObject().ToPointer();
                var byteLength = length * sizeInBytes;

                // There are faster ways to do this, particularly by using wider types or by 
                // handling special lengths.
                for (int i = 0; i < byteLength; i++)
                    destination[i] = ((byte*)source)[i];

                handle.Free();
            }
            else if (type.IsValueType)
            {
                if (!type.IsLayoutSequential && !type.IsExplicitLayout)
                {
                    throw new InvalidOperationException(string.Format("{0} does not define a StructLayout attribute", type));
                }

                IntPtr sourcePtr = new IntPtr(source);

                for (int i = 0; i < length; i++)
                {
                    IntPtr p = new IntPtr((byte*)source + i * sizeInBytes);

                    output[i] = (T)System.Runtime.InteropServices.Marshal.PtrToStructure(p, typeof(T));
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format("{0} is not supported", type));
            }

            return output;
        }

        public static string unicode_0(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    outStr += "/u" + ((int)str[i]).ToString("x");
                }
            }
            return outStr;
        }
 

        public static int GetSize()
        {
            return 1 + 14 + 1 + 1 * 6 + 2 * 3 + 4 * 9;
        }

        public static string mSubString(string str, int StartIndex, int Count)
        {
            string ret = string.Empty;
            if (str == null)
                return ret;
            if (StartIndex >= str.Length)
                return ret;
            if (StartIndex < 0)
                StartIndex = 0;
            if (StartIndex + Count > str.Length)
                Count = str.Length - StartIndex;
            if (Count < 1)
                return ret;

            ret = str.Substring(StartIndex, Count);
            return ret;
        }

        private static ushort MakeWord(byte bLow, byte bHigh)
        {
            return (ushort)(bLow | (bHigh << 8));
        }

        public static string GetValidStr3(string Str, ref string Dest, string[] DividerAry)
        {
            char[] Div = new char[DividerAry.Length];
            int i;
            for (i = 0; i < DividerAry.Length; i++)
            {
                Div[i] = DividerAry[i][0];
            }

            string[] Ary = Str.Split(Div, 2, StringSplitOptions.RemoveEmptyEntries);
            if (Ary.Length > 0)
                Dest = Ary[0];
            else
                Dest = "";
            if (Ary.Length > 1)
                return Ary[1];
            else
                return "";
        }

        public static void GetScriptLabel(string sMsg)
        {
            string sText = string.Empty;
            string sData = string.Empty;
            string sCmdStr = string.Empty;
            string sLabel = string.Empty;
            try
            {
                m_CanJmpScriptLableList.Clear();
                while (true)
                {
                    if (sMsg == "")
                    {
                        break;
                    }
                    sMsg = GetValidStr3(sMsg, ref sText, new string[] { "\\" });
                    //if (sText == "") {
                    //    sText = sMsg;
                    //}
                    if (sText != "")
                    {
                        sData = "";
                        while ((sText.IndexOf("<") > -1) && (sText.IndexOf(">") > -1) && (sText != ""))
                        {
                            if (sText[0] != '<')
                            {
                                sText = "<" + GetValidStr3(sText, ref sData, new string[] { "<" });
                            }
                            sText = ArrestStringEx(sText, "<", ">", ref sCmdStr);
                            sLabel = GetValidStr3(sCmdStr, ref sCmdStr, new string[] { "/" });
                            if (sLabel != "")
                            {
                                m_CanJmpScriptLableList.Add(sLabel);
                            }
                        }
                    }
                }
            }
            catch
            {
                //M2Share.MainOutMessage("{异常} TPlayObject.GetScriptLabel");
            }
        }

        public static string ArrestStringEx(string Source, string SearchAfter, string ArrestBefore, ref string ArrestStr)
        {
            string result = string.Empty;
            int srclen;
            bool GoodData;
            int I;
            int n;
            ArrestStr = "";
            if (Source == "")
            {
                result = "";
                return result;
            }
            try
            {
                srclen = Source.Length;
                GoodData = false;
                if (srclen >= 2)
                {
                    if (Source[0].ToString() == SearchAfter)
                    {
                        Source = Source.Substring(2 - 1, srclen - 1);
                        srclen = Source.Length;
                        GoodData = true;
                    }
                    else
                    {
                        n = Source.IndexOf(SearchAfter) + 1;
                        if (n > 0)
                        {
                            Source = Source.Substring(n + 1 - 1, srclen - n);
                            srclen = Source.Length;
                            GoodData = true;
                        }
                    }
                }
                if (GoodData)
                {
                    n = Source.IndexOf(ArrestBefore) + 1;//By John修正  Delphi字符串是从1开始,C#为0开始,导致c#得到字符串的长度少一位
                    if (n > 0)
                    {
                        ArrestStr = Source.Substring(1 - 1, n - 1);
                        result = Source.Substring(n + 1 - 1, srclen - n);
                    }
                    else
                    {
                        result = SearchAfter + Source;
                    }
                }
                else
                {
                    for (I = 1; I <= srclen; I++)
                    {
                        if (Source[I - 1].ToString() == SearchAfter)
                        {
                            result = Source.Substring(I - 1, srclen - I + 1);
                            break;
                        }
                    }
                }
            }
            catch
            {
                ArrestStr = "";
                result = "";
            }
            return result;
        }

        public unsafe static TDefaultMessage MakeDefaultMsg(int wIdent, int nRecog, int wParam, int wTag, int wSeries, int wSessionID)
        {
            TDefaultMessage result = new TDefaultMessage();
            result.Recog = nRecog;
            result.Ident = (ushort)wIdent;
            result.Param = (uint)wParam;
            result.Tag = (uint)wTag;
            result.Series = (uint)wSeries;
            result.nSessionID = wSessionID;
            return result;
        }

        public static string sub_49ADB8(string sMsg, string sStr, string sText)
        {
            string result;
            int n10;
            string s14;
            string s18;

            n10 = sMsg.IndexOf(sStr);
            if (n10 > -1)
            {
                s14 = sMsg.Substring(1 - 1, n10);
                s18 = sMsg.Substring(sStr.Length + n10, sMsg.Length - (sStr.Length + n10));
                result = s14 + sText + s18;
            }
            else
            {
                result = sMsg;
            }
            return result;

        }

        public static int MakeLong(int w, int s) { return (int)(((ushort)w) | (uint)(s << 16)); }
        

        // 思路：对于含有高字节不为0的，说明字符串包含汉字，用Encoding.Default.GetBytes
        //     这样会导致服务端string结构发生变化，但是不影响网络传输的数据
        // 对于高字节为0的，仅处理低字节
        // retby 为 null 表示仅计算长度并返回
        public unsafe static int StringToBytePtr(string str, byte* retby, int StartIndex)
        {
            bool bDecode = false;
            for (int i = 0; i < str.Length; i++)
            {
                if ((UInt16)str[i] >> 8 != 0)
                {
                    bDecode = true;
                    break;
                }
            }

            int nLen = 0;
            if (bDecode)
            {
                nLen = Encoding.Default.GetByteCount(str);
            }
            else
            {
                nLen = str.Length;
            }
            if (retby == null)
                return nLen;


            if (bDecode)
            {
                byte[] by = Encoding.Default.GetBytes(str);
                byte* pb = retby + StartIndex;
                for (int i = 0; i < by.Length; i++)
                    *(pb++) = by[i];
            }
            else
            {

                byte* pb = retby + StartIndex;
                for (int i = 0; i < str.Length; i++)
                {
                    *(pb++) = (byte)str[i];
                }
            }

            return nLen;
        }

        public unsafe static string BytePtrToString(byte* by, int StartIndex, int Len)
        {
            string ret = new string('\0', Len);
            StringBuilder sb = new StringBuilder(ret);

            by += StartIndex;
            for (int i = 0; i < Len; i++)
            {
                sb[i] = (char)(*(by++));
            }

            return sb.ToString();
        }

        public unsafe static string ByteAryToString(byte[] by, int StartIndex, int Len)
        {
            fixed (byte* pb = by)
            {
                return BytePtrToString(pb, StartIndex, Len);
            }
        }

        public unsafe static byte[] StringToByteAry(string str)
        {
            int nLen = StringToBytePtr(str, null, 0);
            byte[] ret = new byte[nLen];
            fixed (byte* pb = ret)
            {
                StringToBytePtr(str, pb, 0);
            }

            return ret;
        }

        public unsafe static string SByteAryToString(sbyte[] by, int StartIndex, int Len)
        {
            fixed (sbyte* pb = by)
            {
                return BytePtrToString((byte*)pb, StartIndex, Len);
            }
        }

        public unsafe static sbyte[] StringToSByteAry(string str)
        {
            int nLen = StringToBytePtr(str, null, 0);
            sbyte[] ret = new sbyte[nLen];
            fixed (sbyte* pb = ret)
            {
                StringToBytePtr(str, (byte*)pb, 0);
            }

            return ret;
        }

        public unsafe static string SBytePtrToString(sbyte* by, int StartIndex, int Len)
        {
            return BytePtrToString((byte*)by, StartIndex, Len);
        }

        public unsafe static int StringToSBytePtr(string str, sbyte* retby, int StartIndex)
        {
            int nLen = StringToBytePtr(str, null, 0);
            if (retby == null)
                return nLen;

            return StringToBytePtr(str, (byte*)retby, StartIndex);
        }

        public unsafe static string IntPtrToString(IntPtr by, int StartIndex, int Len)
        {
            return BytePtrToString((byte*)by, StartIndex, Len);
        }

        public unsafe static int StringToIntPtr(string str, IntPtr retby, int StartIndex)
        {
            return StringToBytePtr(str, (byte*)retby, StartIndex);
        }

        public unsafe static string IntPtrPlusLenToString(IntPtr by, int StartIndex)
        {
            byte* pb = (byte*)by + StartIndex;
            int nLen = *(int*)pb;

            string ret = new string('\0', nLen);
            StringBuilder sb = new StringBuilder(ret);

            pb += sizeof(int);
            for (int i = 0; i < nLen; i++)
                sb[i] = (char)pb[i];

            return sb.ToString();
        }

        public unsafe static int StringToIntPtrPlusLen(string str, IntPtr retby, int StartIndex)
        {
            int nLen = StringToBytePtr(str, null, 0);
            if (retby == (IntPtr)0)
                return nLen + sizeof(int);

            byte* pb = (byte*)retby + StartIndex;
            *(int*)pb = nLen;
            pb += sizeof(int);
            StringToBytePtr(str, pb, 0);

            return nLen + sizeof(int);
        }

    }
}
