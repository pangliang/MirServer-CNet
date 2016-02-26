using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GameFramework
{
    public class EncryptUnit
    {
        /// <summary>
        /// 缓冲区定义
        /// </summary>
        public const int BUFFERSIZE = 10000;

        /// <summary>
        /// 加密Byte数组
        /// </summary>
        /// <param name="Buf"></param>
        /// <param name="bufsize"></param>
        /// <returns></returns>
        public unsafe static string EncodeBuffer(byte[] Buf, int bufsize)
        {
            string result;
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] TempBuf = new byte[BUFFERSIZE];
            if (bufsize < BUFFERSIZE)
            {
                Array.Copy(Buf, 0, TempBuf, 0, bufsize);
                int DestLen = Encode6BitBuf(TempBuf, EncBuf, bufsize, BUFFERSIZE);
                fixed (byte* pb = EncBuf)
                {
                    result = HUtil32.SBytePtrToString((sbyte*)pb, 0, DestLen);
                }
            }
            else
            {
                result = "";
            }
            return result;
        }

        public unsafe static string EncodeBuffer(void* src, int buffSize)
        {
            string result;
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] TempBuf = new byte[BUFFERSIZE];
            byte[] data = new byte[buffSize];
            fixed (byte* pb = data)
            {
                for (int i = 0; i < buffSize; i++)
                {
                    *(pb + i) = *((byte*)src + i);
                }
            }
            if (buffSize < BUFFERSIZE)
            {
                Array.Copy(data, 0, TempBuf, 0, buffSize);
                int DestLen = Encode6BitBuf(TempBuf, EncBuf, buffSize, BUFFERSIZE);
                fixed (byte* pb = EncBuf)
                {
                    result = HUtil32.SBytePtrToString((sbyte*)pb, 0, DestLen);
                }
            }
            else
            {
                result = "";
            }
            return result;
        }

        /// <summary>
        /// 解密Byte数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Src"></param>
        /// <param name="Buf"></param>
        /// <param name="bufsize"></param>
        /// <returns></returns>
        public unsafe static void DecodeBuffer<T>(string Src, ref T Buf)
        {
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] bSrc = System.Text.Encoding.Default.GetBytes(Src);
            Decode6BitBuf(bSrc, EncBuf, bSrc.Length, BUFFERSIZE);
            Buf = (T)HUtil32.BytesToStuct(EncBuf, Buf.GetType());
        }

        /// <summary>
        /// 解密Byte数组
        /// </summary>
        /// <param name="Src"></param>
        /// <param name="Buf"></param>
        /// <param name="bufsize"></param>
        public unsafe static void DecodeBuffer(string Src, void* Buf, int bufsize)
        {
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] bSrc = System.Text.Encoding.Default.GetBytes(Src);
            Decode6BitBuf(bSrc, EncBuf, bSrc.Length, BUFFERSIZE);
            fixed (byte* pb = EncBuf)
            {
                for (int i = 0; i < bufsize; i++)
                {
                    *((byte*)Buf + i) = *(pb + i);
                }
            }
        }

        /// <summary>
        /// 解密Byte数组
        /// </summary>
        /// <param name="Src"></param>
        /// <param name="Buf"></param>
        /// <param name="bufsize"></param>
        /// <returns></returns>
        public unsafe static string DecodeBuffer(string Src, byte[] Buf, int bufsize)
        {
            string result;
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] bSrc = System.Text.Encoding.Default.GetBytes(Src);
            int nLen = Decode6BitBuf(bSrc, EncBuf, bSrc.Length, BUFFERSIZE);
            fixed (byte* pb = EncBuf)
            {
                result = HUtil32.SBytePtrToString((sbyte*)pb, 0, nLen);
            }
            return result;
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="chinese">是否返回中文</param>
        /// <returns></returns>
        public unsafe static string DeCodeString(string str, bool chinese = false)
        {
            string result;
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] bSrc = HUtil32.StringToByteAry(str);
            int nLen = Decode6BitBuf(bSrc, EncBuf, bSrc.Length, BUFFERSIZE);
            fixed (byte* pb = EncBuf)
            {
                if (chinese)
                {
                    result = HUtil32.SBytePtrToString((sbyte*)pb, nLen);
                }
                else
                {
                    result = HUtil32.SBytePtrToString((sbyte*)pb, 0, nLen);
                }
            }
            return result;
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public unsafe static string EncodeString(string str)
        {
            string result;
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] bSrc = HUtil32.StringToByteAry(str);
            int DestLen = Encode6BitBuf(bSrc, EncBuf, bSrc.Length, BUFFERSIZE);
            fixed (byte* pb = EncBuf)
            {
                result = HUtil32.SBytePtrToString((sbyte*)pb, 0, DestLen);
            }
            return result;
        }

        /// <summary>
        /// 解密消息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public unsafe static TDefaultMessage DecodeMessage(string str)
        {
            byte[] EncBuf = new byte[BUFFERSIZE];
            TDefaultMessage Msg;
            byte[] bSrc = HUtil32.StringToByteAry(str);
            Decode6BitBuf(bSrc, EncBuf, bSrc.Length, BUFFERSIZE);
            fixed (byte* pb = EncBuf)
            {
                Msg = *(TDefaultMessage*)(pb);
            }
            return Msg;
        }

        /// <summary>
        /// 加密消息
        /// </summary>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public unsafe static string EncodeMessage(TDefaultMessage sMsg)
        {
            string result = string.Empty;
            byte[] EncBuf = new byte[BUFFERSIZE];
            byte[] TempBuf = new byte[BUFFERSIZE];
            fixed (byte* pb = TempBuf)
            {
                *(TDefaultMessage*)(pb) = sMsg;
            }
            int DestLen = Encode6BitBuf(TempBuf, EncBuf, Marshal.SizeOf(typeof(TDefaultMessage)), BUFFERSIZE);
            fixed (byte* pb = EncBuf)
            {
                result = HUtil32.SBytePtrToString((sbyte*)pb, 0, DestLen);
            }
            return result;
        }

        internal unsafe static int Encode6BitBuf(byte[] pSrc, byte[] pDest, int nSrcLen, int nDestLen)
        {
            int nRestCount;
            int nDestPos;
            byte btMade;
            byte btCh;
            byte btRest;
            nRestCount = 0;
            btRest = 0;
            nDestPos = 0;
            for (int I = 0; I < nSrcLen; I++)
            {
                if (nDestPos >= nDestLen)
                {
                    break;
                }
                btCh = ((byte)pSrc[I]);
                btMade = Convert.ToByte((byte)(btRest | (btCh >> Convert.ToByte((2 + nRestCount)))) & 0x3F);
                btRest = Convert.ToByte((byte)((btCh << (8 - (2 + nRestCount))) >> 2) & 0x3F);
                nRestCount += 2;
                if (nRestCount < 6)
                {
                    pDest[nDestPos] = Convert.ToByte(btMade + 0x3C);
                    nDestPos++;
                }
                else
                {
                    if (nDestPos < nDestLen - 1)
                    {
                        pDest[nDestPos] = Convert.ToByte(btMade + 0x3C);
                        pDest[nDestPos + 1] = Convert.ToByte(btRest + 0x3C);
                        nDestPos += 2;
                    }
                    else
                    {
                        pDest[nDestPos] = Convert.ToByte(btMade + 0x3C);
                        nDestPos++;
                    }
                    nRestCount = 0;
                    btRest = 0;
                }
            }
            if (nRestCount > 0)
            {
                pDest[nDestPos] = Convert.ToByte(btRest + 0x3C);
                nDestPos++;
            }
            pDest[nDestPos] = 0;
            return nDestPos;
        }

        internal static int Decode6BitBuf(byte[] sSource, byte[] pbuf, int nSrcLen, int nBufLen)
        {
            byte[] Masks = { 0xFC, 0xF8, 0xF0, 0xE0, 0xC0 };
            int nBitPos;
            int nMadeBit;
            int nBufPos;
            byte btCh;
            byte btTmp;
            byte btByte;
            nBitPos = 2;
            nMadeBit = 0;
            nBufPos = 0;
            btTmp = 0;
            for (int I = 0; I < nSrcLen; I++)
            {
                if (((int)sSource[I]) - 0x3C >= 0)
                {
                    btCh = Convert.ToByte(sSource[I] - 0x3C);
                }
                else
                {
                    nBufPos = 0;
                    break;
                }
                if (nBufPos >= nBufLen)
                {
                    break;
                }
                if ((nMadeBit + 6) >= 8)
                {
                    btByte = Convert.ToByte(btTmp | ((btCh & 0x3F) >> (6 - nBitPos)));
                    pbuf[nBufPos] = btByte;
                    nBufPos++;
                    nMadeBit = 0;
                    if (nBitPos < 6)
                    {
                        nBitPos += 2;
                    }
                    else
                    {
                        nBitPos = 2;
                        continue;
                    }
                }
                btTmp = Convert.ToByte((byte)(btCh << nBitPos) & Masks[nBitPos - 2]);
                nMadeBit += 8 - nBitPos;
            }
            pbuf[nBufPos] = 0;

            return nBufPos;
        }

        /// <summary>
        /// 制造通信消息
        /// </summary>
        /// <param name="wIdent"></param>
        /// <param name="nRecog"></param>
        /// <param name="wParam"></param>
        /// <param name="wTag"></param>
        /// <param name="wSeries"></param>
        /// <param name="wSessionID"></param>
        /// <returns></returns>
        public unsafe static TDefaultMessage MakeDefaultMsg(object wIdent, object nRecog, object wParam, object wTag, object wSeries, object wSessionID)
        {
            TDefaultMessage result = new TDefaultMessage();
            result.Recog = (int)nRecog;
            result.Ident = Convert.ToUInt16(wIdent);
            result.Param = Convert.ToUInt32(wParam);
            result.Tag = Convert.ToUInt32(wTag);
            result.Series = Convert.ToUInt32(wSeries);
            result.nSessionID = Convert.ToInt32(wSessionID);
            return result;
        }
    }
}