using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace GameFramework
{
    public class HUtil32
    {
        /// <summary>
        /// 取系统启动以来运行的毫秒数
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern uint GetTickCount();

        /// <summary>
        /// 清空指针归零
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="size"></param>
        [DllImport("Kernel32.dll", EntryPoint = "RtlZeroMemory", SetLastError = false)]
        public unsafe static extern void ZeroMemory(void* dest, int size);

        /// <summary>
        /// 结构体转byte数组
        /// </summary>
        /// <param name=”structObj”>要转换的结构体</param>
        /// <returns>转换后的byte数组</returns>
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

        /// <summary>
        /// byte数组转结构体
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="type">结构体类型</param>
        /// <returns>转换后的结构体</returns>
        public static object BytesToStuct(byte[] bytes, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }

        /// <summary>
        /// 进入临界区
        /// </summary>
        /// <param name="obj"></param>
        public static void EnterCriticalSection(object obj)
        {
            Monitor.Enter(obj);
        }

        /// <summary>
        /// 离开临界区
        /// </summary>
        /// <param name="obj"></param>
        public static void LeaveCriticalSection(object obj)
        {
            Monitor.Exit(obj);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] rawSerialize(object obj)
        {
            int rawsize = Marshal.SizeOf(obj);
            byte[] rawdatas;
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            try
            {
                Marshal.StructureToPtr(obj, buffer, false);
                rawdatas = new byte[rawsize];
                Marshal.Copy(buffer, rawdatas, 0, rawsize);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
            return rawdatas;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="rawdatas"></param>
        /// <param name="retType"></param>
        /// <returns></returns>
        public static object rawDeserialize(byte[] rawdatas, Type retType)
        {
            object retobj = Activator.CreateInstance(retType);
            int rawsize = Marshal.SizeOf(retType);
            if (rawsize > rawdatas.Length)
                return retobj;
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            try
            {
                Marshal.Copy(rawdatas, 0, buffer, rawsize);
                retobj = Marshal.PtrToStructure(buffer, retType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
            return retobj;
        }

        public static int MakeLong(uint lowPart, uint highPart)
        {
            return (int)((lowPart) | (uint)((short)highPart << 16));
        }

        public static int MakeLong(ushort lowPart, int highPart)
        {
            return (int)((lowPart) | (uint)((short)highPart << 16));
        }

        public static int MakeLong(int lowPart, int highPart)
        {
            return (int)(((ushort)lowPart) | (uint)((short)highPart << 16));
        }

        public static int MakeLong(short lowPart, int highPart)
        {
            return (int)(((ushort)lowPart) | (uint)((short)highPart << 16));
        }

        public static int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }

        public static int MakeLong(short lowPart, ushort highPart)
        {
            return (int)(((ushort)lowPart) | (uint)((short)highPart << 16));
        }

        public static int MakeLong(short lowPart, uint highPart)
        {
            return (int)(((ushort)lowPart) | (uint)((short)highPart << 16));
        }

        public static ushort MakeWord(byte bLow, byte bHigh)
        {
            return (ushort)(bLow | (bHigh << 8));
        }

        public static short HiWord(int dword)
        {
            return (short)(dword >> 16);
        }

        public static long HiWord(long dword)
        {
            return dword >> 16;
        }

        public static short LoWord(int dword)
        {
            return (short)dword;
        }

        public static uint High(uint Maxuint)
        {
            return uint.MaxValue;
        }

        public const int MAXDEFCOLOR = 16;
        public const int MAXLISTMARKER = 3;
        public const int MAXPREDEFINE = 3;

        public unsafe static string StrPas(byte* Buff)
        {
            int nLen = 0;
            byte* pb = Buff;
            while (*pb++ != 0)
            {
                nLen++;
            }

            string ret = new string('\0', nLen);
            StringBuilder sb = new StringBuilder(ret);
            pb = Buff;
            for (int i = 0; i < nLen; i++)
            {
                sb[i] = (char)(*pb++);
            }

            return sb.ToString();
        }

        public unsafe static T IntToObject<T>(int Ptr)
        {
            byte[] by = new byte[4];
            fixed (byte* pb = by)
            {
                *(int*)pb = Ptr;
            }
            TObjectPack op = (TObjectPack)rawDeserialize(by, typeof(TObjectPack));
            return (T)op.Play;
        }

        public unsafe static int ObjectToInt(object po)
        {
            TObjectPack pop = new TObjectPack();
            pop.Play = po;

            byte[] by = rawSerialize(pop);
            int ret = 0;
            fixed (byte* pb = by)
            {
                ret = *(int*)pb;
            }

            return ret;
        }

        public struct TObjectPack
        {
            public object Play;
        }

        /// <summary>
        /// 数字转字节
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte IntToByte(int s)
        {
            byte[] data = BitConverter.GetBytes(s);
            return (byte)BitConverter.ToInt32(data, 0);
        }

        public static byte[] StrToByte(string s)
        {
            return System.Text.Encoding.Default.GetBytes(s);
        }

        /// <summary>
        /// 取指定字符串长度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte GetStrLength(string s)
        {
            return (byte)System.Text.Encoding.Default.GetBytes(s).Length;
        }

        /// <summary>
        /// 数组转数字
        /// </summary>
        /// <param name="sou"></param>
        /// <returns></returns>
        unsafe static public int ArrayToInt(byte[] sou)
        {
            int PlayLen = 0;
            byte[] data = new byte[sou.Length];
            fixed (byte* pb = data)
            {
                PlayLen = *(int*)pb;
            }
            return PlayLen;
        }

        /// <summary>
        /// 数字转数组
        /// </summary>
        /// <param name="sou">序列化的长度</param>
        /// <param name="len">序列化的数组</param>
        /// <returns></returns>
        unsafe static public byte[] IntToArrat(int sou, byte[] by)
        {
            byte[] data = by;
            fixed (byte* pb = data)
            {
                *(int*)pb = sou;
            }
            return data;
        }

        unsafe static public void IntPtrToIntPtr(IntPtr Src, int SrcIndex, IntPtr Dest, int DestIndex, int nLen)
        {
            byte* pSrc = (byte*)Src + SrcIndex;
            byte* pDest = (byte*)Dest + DestIndex;
            if (pDest > pSrc)
            {
                pDest = pDest + (nLen - 1);
                pSrc = pSrc + (nLen - 1);
                for (int i = 0; i < nLen; i++)
                    *pDest-- = *pSrc--;
            }
            else
            {
                for (int i = 0; i < nLen; i++)
                    *pDest++ = *pSrc++;
            }
        }

        unsafe static public byte[] BytePtrToByteArray(byte* pb, int pbSize)
        {
            byte[] ret = new byte[pbSize];
            for (int i = 0; i < pbSize; i++)
            {
                ret[i] = pb[i];
            }
            return ret;
        }

        unsafe static public int ByteArrayToBytePtr(byte* pb, int pbSize, byte[] ByteAry)
        {
            int nLen;
            if (ByteAry.Length > pbSize)
            {
                for (int i = 0; i < pbSize; i++)
                    pb[i] = ByteAry[i];

                nLen = pbSize;
            }
            else
            {
                for (int i = 0; i < ByteAry.Length; i++)
                {
                    pb[i] = ByteAry[i];
                }

                nLen = ByteAry.Length;
            }
            return nLen;
        }

        unsafe static public ushort[] ushortPrtToushortArray(ushort* pb, int pbSize)
        {
            ushort[] ret = new ushort[pbSize];
            for (int i = 0; i < pbSize; i++)
            {
                ret[i] = pb[i];
            }
            return ret;
        }

        unsafe static public int UShortArrayToUShortPtr(ushort* pb, int pbSize, ushort[] ByteAry)
        {
            int nLen;
            if (ByteAry.Length > pbSize)
            {
                for (int i = 0; i < pbSize; i++)
                    pb[i] = ByteAry[i];

                nLen = pbSize;
            }
            else
            {
                for (int i = 0; i < ByteAry.Length; i++)
                {
                    pb[i] = ByteAry[i];
                }

                nLen = ByteAry.Length;
            }
            return nLen;
        }

        public static int Random()
        {
            RandomNumberHelper NumberHelper = RandomNumberHelper.GetInstance();
            return NumberHelper.Random();
        }

        public static int Random(int Seed)
        {
            RandomNumberHelper NumberHelper = RandomNumberHelper.GetInstance();
            return NumberHelper.Random(Seed);
        }

        public static int Random(int minNum, int maxNum)
        {
            RandomNumberHelper NumberHelper = RandomNumberHelper.GetInstance();
            return NumberHelper.Random(minNum, maxNum);
        }

        public static string BoolToIntStr(bool boBoolean)
        {
            string result = "";

            //result = ((int)boBoolean).ToString();
            return result;
        }

        public static string BoolToCStr(bool boBoolean)
        {
            string result = string.Empty;
            result = BooleanToStr(boBoolean);
            return result;
        }

        public static int GetDayCount(DateTime MaxDate, DateTime MinDate)
        {
            int result;
            int Day;
            Day = Convert.ToInt32(Convert.ToInt64(MaxDate) - Convert.ToInt64(MinDate));
            if (Day > 0)
            {
                result = Day;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public static int GetCodeMsgSize(double x)
        {
            int result;
            if (Convert.ToInt32(x) < x)
            {
                result = Convert.ToInt32(x) + 1;
            }
            else
            {
                result = Convert.ToInt32(x);
            }
            return result;
        }

        public static string IntToSex(byte btSex)
        {
            string result;
            switch (btSex)
            {
                case 0:
                    result = "男";
                    break;

                case 1:
                    result = "女";
                    break;

                default:
                    result = "未知";
                    break;
            }
            return result;
        }

        public static string IntToJob(byte btJob)
        {
            string result;
            switch (btJob)
            {
                case 0:
                    result = "战士";
                    break;

                case 1:
                    result = "法师";
                    break;

                case 2:
                    result = "道士";
                    break;

                default:
                    result = "未知";
                    break;
            }
            return result;
        }

        public static string CaptureString(string Source, ref string rdstr)
        {
            string result;
            int st;
            int et;
            int C;
            int Len;
            int I;
            if (Source == "")
            {
                rdstr = "";
                result = "";
                return result;
            }
            C = 1;

            // et := 0;
            Len = Source.Length;
            while (Source[C] == ' ')
            {
                if (C < Len)
                {
                    C++;
                }
                else
                {
                    break;
                }
            }
            if ((Source[C] == '\'') && (C < Len))
            {
                st = C + 1;
                et = Len;
                for (I = C + 1; I <= Len; I++)
                {
                    if (Source[I] == '\'')
                    {
                        et = I - 1;
                        break;
                    }
                }
            }
            else
            {
                st = C;
                et = Len;
                for (I = C; I <= Len; I++)
                {
                    if (Source[I] == ' ')
                    {
                        et = I - 1;
                        break;
                    }
                }
            }
            rdstr = Source.Substring(st - 1, (et - st + 1));
            if (Len >= (et + 2))
            {
                result = Source.Substring(et + 2 - 1, Len - (et + 1));
            }
            else
            {
                result = "";
            }
            return result;
        }

        public static int CountUglyWhiteChar(string sptr)
        {
            int result;
            int Cnt;
            int Killw;
            Killw = 0;
            for (Cnt = (sptr.Length - 1); Cnt >= 0; Cnt--)
            {
                if (sptr[Cnt] == ' ')
                {
                    Killw++;

                    // sPtr[Cnt] := #0;
                }
                else
                {
                    break;
                }
            }
            result = Killw;
            return result;
        }

        public static int GetSpaceCount(string Str)
        {
            int result;
            int Cnt;
            int Len;
            int SpaceCount;
            SpaceCount = 0;
            Len = Str.Length;
            for (Cnt = 1; Cnt <= Len; Cnt++)
            {
                if (Str[Cnt] == ' ')
                {
                    SpaceCount = SpaceCount + 1;
                }
            }
            result = SpaceCount;
            return result;
        }

        public static string RemoveSpace(string Str)
        {
            string result;
            int I;
            result = "";
            for (I = 1; I <= Str.Length; I++)
            {
                if (Str[I] != ' ')
                {
                    result = result + Str[I];
                }
            }
            return result;
        }

        public static int KillFirstSpace(ref string Str)
        {
            int result;
            int Cnt;
            int Len;
            result = 0;
            Len = Str.Length;
            for (Cnt = 1; Cnt <= Len; Cnt++)
            {
                if (Str[Cnt] != ' ')
                {
                    Str = Str.Substring(Cnt - 1, Len - Cnt + 1);
                    result = Cnt - 1;
                    break;
                }
            }
            return result;
        }

        public static void KillGabageSpace(ref string Str)
        {
            int Cnt;
            int Len;
            Len = Str.Length;
            for (Cnt = Len; Cnt >= 1; Cnt--)
            {
                if (Str[Cnt] != ' ')
                {
                    Str = Str.Substring(1 - 1, Cnt);
                    KillFirstSpace(ref Str);
                    break;
                }
            }
        }

        public static int HexToInt(string Str)
        {
            int result;
            char digit;
            int Count;
            int I;
            int cur;
            int Val;
            Val = 0;
            Count = Str.Length;
            for (I = 1; I <= Count; I++)
            {
                digit = Str[I];
                if ((digit >= '0') && (digit <= '9'))
                {
                    cur = (int)(digit) - (int)('0');
                }
                else if ((digit >= 'A') && (digit <= 'F'))
                {
                    cur = (int)(digit) - (int)('A') + 10;
                }
                else if ((digit >= 'a') && (digit <= 'f'))
                {
                    cur = (int)(digit) - (int)('a') + 10;
                }
                else
                {
                    cur = 0;
                }
                Val = Val + (cur << (4 * (Count - I)));
            }
            result = Val;

            // Result := (Val and $0000FF00) or ((Val shl 16) and $00FF0000) or ((Val shr 16) and $000000FF);

            return result;
        }

        public static string Format_Tostr(string Str, object[] Args)
        {
            string result;
            result = Str;
            try
            {
                result = string.Format(Str, Args);
            }
            catch
            {
            }
            return result;
        }

        public static byte Str_ToByte(string Str, int Def)
        {
            byte result;
            result = (byte)Def;
            if (Str != "")
            {
                if (((((ushort)Str[0]) >= (ushort)'0') && (((ushort)Str[0]) <= (ushort)'9')) || (Str[0] == '+') || (Str[0] == '-'))
                {
                    try
                    {
                        result = Convert.ToByte(Str);
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }

        public static int Str_ToInt(string Str, int Def)
        {
            int result = Def;
            if (Str != "")
            {
                if (((((ushort)Str[0]) >= (ushort)'0') && (((ushort)Str[0]) <= (ushort)'9')) || (Str[0] == '+') || (Str[0] == '-'))
                {
                    try
                    {
                        result = Convert.ToInt32(Str);
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }

        public static DateTime Str_ToDate(string Str)
        {
            DateTime result;
            if (Str.Trim() == "")
            {
                result = DateTime.Today;
            }
            else
            {
                result = Convert.ToDateTime(Str);
            }
            return result;
        }

        public static DateTime Str_ToTime(string Str)
        {
            DateTime result;
            if (Str.Trim() == "")
            {
                result = DateTime.Now;
            }
            else
            {
                result = Convert.ToDateTime(Str);
            }
            return result;
        }

        public static double Str_ToFloat(string Str)
        {
            double result;
            if (Str != "")
            {
                try
                {
                    result = Convert.ToSingle(Str);
                    return result;
                }
                catch
                {
                }
            }
            result = 0;
            return result;
        }

        public static string ExtractFileNameOnly(string fname)
        {
            string result;
            int extpos;
            string ext;
            string fn;
            ext = Path.GetExtension(fname);
            fn = Path.GetFileName(fname);
            if (ext != "")
            {
                extpos = fn.IndexOf(ext);
                result = fn.Substring(1 - 1, extpos - 1);
            }
            else
            {
                result = fn;
            }
            return result;
        }

        public static string FloatToString(double F)
        {
            string result;
            result = FloatToStrFixFmt(F, 5, 2);
            return result;
        }

        public static string FloatToStrFixFmt(double fVal, int prec, int digit)
        {
            string result;
            int Cnt;
            int Dest;
            int Len;
            int I;
            int j;
            string fstr;
            char[] buf = new char[255 + 1];
            Cnt = 0;
            Dest = 0;

            fstr = Convert.ToString(fVal);
            Len = fstr.Length;
            for (I = 1; I <= Len; I++)
            {
                if (fstr[I] == '.')
                {
                    buf[Dest] = '.';
                    Dest++;
                    Cnt = 0;
                    for (j = I + 1; j <= Len; j++)
                    {
                        if (Cnt < digit)
                        {
                            buf[Dest] = fstr[j];
                            Dest++;
                        }
                        else
                        {
                            goto end_conv;
                        }
                        Cnt++;
                    }
                    goto end_conv;
                }
                if (Cnt < prec)
                {
                    buf[Dest] = fstr[I];
                    Dest++;
                }
                Cnt++;
            }
        end_conv:
            buf[Dest] = (char)0;
            result = buf.ToString();
            return result;
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

        public static string GetValidStrCap(string Str, ref string Dest, string[] Divider)
        {
            string result;
            Str = Str.TrimStart();
            if (Str != "")
            {
                if (Str[0] == '\"')
                {
                    result = CaptureString(Str, ref Dest);
                }
                else
                {
                    result = GetValidStr3(Str, ref Dest, Divider);
                }
            }
            else
            {
                result = "";
                Dest = "";
            }
            return result;
        }

        public static bool IsStringNumber(string Str)
        {
            bool result;
            int I;
            result = true;
            for (I = 0; I <= Str.Length - 1; I++)
            {
                if ((((byte)Str[I]) < (byte)'0') || (((byte)Str[I]) > (byte)'9'))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool IsVarNumber(string Str)
        {
            return (CompareLStr(Str, "HUMAN", 5)) || (CompareLStr(Str, "GUILD", 5)) || (CompareLStr(Str, "GLOBAL", 6));
        }

        // 截取字符串
        // 例 ArrestStringEx('[1234]','[',']',str)    str=1234
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

        public static bool CompareLStr(string Src, string targ, int compn)
        {
            bool result;
            int I;
            result = false;
            if (compn <= 0)
            {
                return result;
            }
            if (Src.Length < compn)
            {
                return result;
            }
            if (targ.Length < compn)
            {
                return result;
            }
            result = true;
            for (I = 0; I <= compn - 1; I++)
            {
                if (Char.ToUpper(Src[I]) != Char.ToUpper(targ[I]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool CompareBackLStr(string Src, string targ, int compn)
        {
            bool result = false;
            int slen;
            int tLen;
            if (compn <= 0)
            {
                return result;
            }
            if (Src.Length < compn)
            {
                return result;
            }
            if (targ.Length < compn)
            {
                return result;
            }
            slen = Src.Length;
            tLen = targ.Length;
            result = true;
            for (int I = 0; I < compn; I++)
            {
                if (Char.ToUpper(Src[slen - (I + 1)]) != Char.ToUpper(targ[tLen - (I + 1)]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool IsEnglish(char Ch)
        {
            bool result;
            result = false;
            if (((Ch >= 'A') && (Ch <= 'Z')) || ((Ch >= 'a') && (Ch <= 'z')))
            {
                result = true;
            }
            return result;
        }

        public static bool IsEngNumeric(char Ch)
        {
            bool result;
            result = false;
            if (IsEnglish(Ch) || ((Ch >= '0') && (Ch <= '9')))
            {
                result = true;
            }
            return result;
        }

        public static bool IsFloatNumeric(string Str)
        {
            bool result;
            if (Str.Trim() == "")
            {
                result = false;
                return result;
            }
            try
            {
                Convert.ToSingle(Str);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static string ReplaceChar(string Src, char srcchr, char repchr)
        {
            string result;
            int Len;
            if (Src != "")
            {
                Len = Src.Length;
                for (int I = 0; I < Len; I++)
                {
                    if (Src[I] == srcchr)
                    {
                        // Src[I] = repchr;
                    }
                }
            }
            result = Src;
            return result;
        }

        public static int TagCount(string Source, char Tag)
        {
            int result;
            int I;
            int tCount;
            tCount = 0;
            for (I = 0; I <= Source.Length - 1; I++)
            {
                if (Source[I] == Tag)
                {
                    tCount++;
                }
            }
            result = tCount;
            return result;
        }

        public static string TakeOffTag(string Src, char Tag, ref string rstr)
        {
            string result;
            int n2;
            n2 = Src.Substring(2 - 1, Src.Length).IndexOf(Tag);
            rstr = Src.Substring(2 - 1, n2 - 1);
            result = Src.Substring(n2 + 2 - 1, Src.Length - n2);
            return result;
        }

        public static string BoolToStr(bool boo)
        {
            string result;
            if (boo)
            {
                result = "TRUE";
            }
            else
            {
                result = "FALSE";
            }
            return result;
        }

        public static string BooleanToStr(bool boo)
        {
            string result;
            if (boo)
            {
                result = "是";
            }
            else
            {
                result = "否";
            }
            return result;
        }

        public static int _MIN(int n1, int n2)
        {
            int result;
            if (n1 < n2)
            {
                result = n1;
            }
            else
            {
                result = n2;
            }
            return result;
        }

        public static int _MIN(uint n1, int n2)
        {
            int result;
            if (n1 < n2)
            {
                result = (int)n1;
            }
            else
            {
                result = n2;
            }
            return result;
        }

        public static int _MAX(int n1, int n2)
        {
            int result;
            if (n1 > n2)
            {
                result = n1;
            }
            else
            {
                result = n2;
            }
            return result;
        }

        public static int _MAX(int n1, double n2)
        {
            int result;
            if (n1 > n2)
            {
                result = n1;
            }
            else
            {
                result = (int)n2;
            }
            return result;
        }

        public static int _MAX(int n1, uint n2)
        {
            int result;
            if (n1 > n2)
            {
                result = n1;
            }
            else
            {
                result = (int)n2;
            }
            return result;
        }

        /// <summary>
        /// 字符串转sbyte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public unsafe static sbyte StringToSbyte(string str)
        {
            byte[] bMsg = HUtil32.StringToByteAry(str);
            IntPtr Buff = Marshal.AllocHGlobal(bMsg.Length + sizeof(int));
            *(int*)Buff = bMsg.Length;
            Marshal.Copy(bMsg, 0, (IntPtr)((byte*)Buff + sizeof(int)), bMsg.Length);
            return (sbyte)Buff;
        }

        // 思路：对于含有高字节不为0的，说明字符串包含汉字，用Encoding.Default.GetBytes
        //     这样会导致服务端string结构发生变化，但是不影响网络传输的数据
        // 对于高字节为0的，仅处理低字节
        // retby 为 null 表示仅计算长度并返回
        public unsafe static int StringToBytePtr(string str, byte* retby, int StartIndex)
        {
            bool bDecode = false;
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
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

        /// <summary>
        /// 字符串转Sbyte
        /// </summary>
        /// <param name="str"></param>
        /// <param name="psb"></param>
        /// <param name="sbSize"></param>
        /// <param name="sbLen"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        public unsafe static void StrToSByteArry(string str, sbyte* psb, byte sbSize, ref byte sbLen)
        {
            sbyte[] sbAry = StringToSByteAry(str);
            if (sbAry.Length > sbSize)
            {
                for (int i = 0; i < sbSize; i++)
                {
                    *psb++ = sbAry[i];
                }
                sbLen = sbSize;
            }
            else
            {
                for (int i = 0; i < sbAry.Length; i++)
                {
                    *psb++ = sbAry[i];
                }
                sbLen = (byte)sbAry.Length;
            }
        }

        /// <summary>
        /// SByte转string
        /// </summary>
        /// <param name="by"></param>
        /// <param name="StartIndex"></param>
        /// <param name="Len"></param>
        /// <returns></returns>
        public unsafe static string SBytePtrToString(sbyte* by, int StartIndex, int Len)
        {
            return BytePtrToString((byte*)by, StartIndex, Len);
        }

        /// <summary>
        /// SByte转String
        /// </summary>
        /// <param name="by"></param>
        /// <param name="Len"></param>
        /// <returns></returns>
        public unsafe static string SBytePtrToString(sbyte* by, int Len)
        {
            return Marshal.PtrToStringAnsi((IntPtr)by, Len);
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

        public static int MakeHumanFeature(byte btRaceImg, byte btDress, byte btWeapon, byte btHair)
        {
            return MakeLong(MakeWord(btRaceImg, btWeapon), MakeWord(btHair, btDress));
        }

        public static int MakeMonsterFeature(byte btRaceImg, byte btWeapon, ushort wAppr)
        {
            return MakeLong(MakeWord(btRaceImg, btWeapon), wAppr);
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

        /// <summary>
        /// 判断数据是否在范围之内
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool rangeInDefined(int values, int min, int max)
        {
            return Math.Max(min, values) == Math.Min(values, max);
        }

        /// <summary>
        /// 将时间转换为指定格式
        /// </summary>
        /// <param name="Format"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string FormatDateTime(string Format, DateTime time)
        {
            return time.ToString(Format);
        }

        public static unsafe int ExtractStrings(char[] Separators, char[] WhiteSpace, char* Content, List<string> Strings)
        {
            int Result = 0;
            char* Head, Tail;
            bool EOS, InQuote;
            char QuoteChar;
            string Item;

            if ((Content == null) || (*Content == '\0') || (Strings == null))
                return Result;
            Tail = Content;
            InQuote = false;
            QuoteChar = '\0';
            do
            {
                while (*Tail == '\xD' || *Tail == '\xA' || WhiteSpace.Contains(*Tail))
                    Tail++;
                Head = Tail;
                while (true)
                {
                    while ((InQuote && !(*Tail == QuoteChar || *Tail == '\0')) ||
                        !(Separators.Contains(*Tail) || *Tail == '\0' || *Tail == '\xD' || *Tail == '\xA' || *Tail == '\'' || *Tail == '\"'))
                    {
                        Tail++;
                    }
                    if (*Tail == '\'' || *Tail == '\"')
                    {
                        if ((QuoteChar != '\0') && (QuoteChar == *Tail))
                            QuoteChar = '\0';
                        else if (QuoteChar == '\0')
                            QuoteChar = *Tail;
                        InQuote = QuoteChar != '\0';
                        Tail++;
                    }
                    else
                        break;
                }
                EOS = (*Tail == '\0');
                if (Head != Tail && *Head != '\0')
                {
                    if (Strings != null)
                    {
                        Item = new string(Head, 0, (int)(Tail - Head));
                        Strings.Add(Item);
                    }
                    Result++;
                }
                Tail++;
            } while (!EOS);

            return Result;
        }

        public static double Round(double sourceNum)
        {
            return Round(sourceNum, 2);
        }

        /// <summary>
        /// 自写四舍五入法
        /// </summary>
        /// <param name="sourceNum">要进行处理的数据</param>
        /// <param name="toRemainIndex">保留的小数位数</param>
        /// <returns>四舍五入后的结果</returns>
        public static double Round(double sourceNum, int toRemainIndex)
        {
            double result = sourceNum;
            string sourceString = sourceNum.ToString();

            //没有小数点,则返回原数据+"."+"保留小数位数个0"
            if (!sourceString.Contains("."))
            {
                result = Convert.ToDouble(sourceString + "." + CreateZeros(toRemainIndex));
                return result;
            }

            //小数点的位数没有超过要保留的位数,则返回原数据+"保留小数位数 - 已有的小数位"个0
            if ((sourceString.Length - sourceString.IndexOf(".") - 1) <= toRemainIndex)
            {
                result = Convert.ToDouble(sourceString + CreateZeros(toRemainIndex - (sourceString.Length - sourceString.IndexOf(".") - 1)));
                return result;
            }
            string beforeAbandon_String = string.Empty;
            beforeAbandon_String = sourceString.Substring(0, sourceString.IndexOf(".") + toRemainIndex + 1);

            //取得如3.1415926保小数点后4位(原始的,还没开始取舍)，中的3.1415
            double beforeAbandon_Decial = Convert.ToDouble(beforeAbandon_String);

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

                #endregion 四舍五入算法说明

                string toAddAfterPoint = "0." + CreateZeros(toRemainIndex - 1) + "1";
                result = beforeAbandon_Decial + Convert.ToDouble(toAddAfterPoint);
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

        public static void Dispose(object obj)
        {
            if (obj != null)
            {
                GC.KeepAlive(obj);
                GC.ReRegisterForFinalize(obj);
            }
        }

        /// <summary>
        /// 判断是否为IP地址
        /// </summary>
        /// <param name="sIPaddr"></param>
        /// <returns></returns>
        public static bool IsIPAddr(string sIPaddr)
        {
            bool bResult = false;
            try
            {
                System.Net.IPAddress.Parse(sIPaddr);
                bResult = true;
            }catch
            {
                bResult = false;
            }
            return bResult;
        }

        public static string Format(TimeSpan time)
        {
            return string.Format("{0}{1:00}h {2:00}m {3:00}s", time.TotalDays > 0 ? (int)time.TotalDays + "d " : "",
                                 time.Hours, time.Minutes, time.Seconds);
        }

        public static string FormatBytes(double num)
        {
            string numPrefix = "B";

            if (num >= 1024.0)
            {
                num /= 1024.0; numPrefix = "kb";
            }
            if (num >= 1024.0)
            {
                num /= 1024.0; numPrefix = "MB";
            }
            if (num >= 1024.0)
            {
                num /= 1024.0; numPrefix = "GB";
            }

            return string.Format("{0,6:f}{1}", num, numPrefix);
        }
    }
}