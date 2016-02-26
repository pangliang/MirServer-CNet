using System;
using System.Data;

namespace GameFramework
{
    public static class DataReaderExtension
    {
        public static string GetString(this IDataReader dr, string name)
        {
            return Convert.ToString(dr[name]);
        }

        public static int GetInt32(this IDataReader dr, string name)
        {
            return Convert.ToInt32(dr[name]);
        }

        public static byte GetByte(this IDataReader dr,string name)
        {
            return Convert.ToByte(dr[name]);
        }

        public static sbyte GetSByte(this IDataReader dr, string name)
        {
            return Convert.ToSByte(dr[name]);
        }

        public static UInt16 GetUInt16(this IDataReader dr, string name)
        {
            return Convert.ToUInt16(dr[name]);
        }

        public static UInt32 GetUInt32(this IDataReader dr,string name)
        {
            return Convert.ToUInt32(dr[name]);
        }
    }
}
