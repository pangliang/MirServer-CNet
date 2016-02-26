using System;
using System.Collections.Generic;
using System.Linq;

namespace GameFramework
{
    public static class StringExtension
    {
        /// <summary>
        /// 字符串转Byte数组
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static byte[] ToByte(this string Source)
        {
            return HUtil32.StrToByte(Source);
        }

        /// <summary>
        /// 字符串转Sbyte*
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="TagStr"></param>
        /// <param name="Size"></param>
        /// <param name="TagLen"></param>
        public unsafe static void StrToSbyte(this string Source, sbyte* TagStr, byte Size, ref byte TagLen)
        {
            HUtil32.StrToSByteArry(Source, TagStr, Size, ref TagLen);
        }

        /// <summary>
        /// 为物品结构中物品名称转Sbyte的方法
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="StdItem"></param>
        //public unsafe static void StrToStdItem(this object Source, TStdItem* StdItem)
        //{
        //    HUtil32.StrToSByteArry(Convert.ToString(Source), StdItem->Name, 14, ref StdItem->NameLen);
        //}

        ///// <summary>
        ///// 为魔法结构中物品名称转Sbyte的方法
        ///// </summary>
        ///// <param name="Source"></param>
        ///// <param name="Magic"></param>
        //public unsafe static void StrToMagic(this object Source, TMagic* Magic)
        //{
        //    HUtil32.StrToSByteArry(Convert.ToString(Source), Magic->SMagicName, 12, ref Magic->MagicNameLen);
        //}

        public static string[] ToStringArrT<T>(IEnumerable<T> collection, Func<T, object> converter)
        {
            var strArr = new string[collection.Count()];
            var colEnum = collection.GetEnumerator();
            var i = 0;
            while (colEnum.MoveNext())
            {
                var cur = colEnum.Current;
                if (!Equals(cur, default(T)))
                {
                    strArr[i++] = (converter != null ? converter(cur) : cur).ToString();
                }
            }
            return strArr;
        }

        public static string[] ToStringArrT<T>(IEnumerable<T> collection)
        {
            return ToStringArrT(collection, null);
        }

        /// <summary>
        /// Returns the string representation of an IEnumerable (all elements, joined by comma)
        /// </summary>
        /// <param name="conj">The conjunction to be used between each elements of the collection</param>
        public static string ToString<T>(this IEnumerable<T> collection, string conj)
        {
            string vals;
            if (collection != null)
            {
                vals = string.Join(conj, ToStringArrT(collection));
            }
            else
                vals = "(null)";

            return vals;
        }
    }
}