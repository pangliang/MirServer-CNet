using System.Runtime.InteropServices;

namespace GameFramework
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class TGoods
    {
        public byte ItemNameLen;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        private string _sItemName;

        /// <summary>
        /// 物品名称
        /// </summary>
        public string sItemName
        {
            get { return _sItemName; }
            set
            {
                _sItemName = value;
                ItemNameLen = HUtil32.GetStrLength(value);
            }
        }

        public int nCount;
        public uint dwRefillTime;
        public uint dwRefillTick;
    }
}