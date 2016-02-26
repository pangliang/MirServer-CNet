using System.Runtime.InteropServices;

namespace GameFramework
{
    /// <summary>
    /// 商铺结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public unsafe struct TShopInfo
    {
        public TStdItem* StdItem;
        public char sIntroduce;
        public int Idx;
        public int ImgBegin;
        public int Imgend;
        public int Introduce1;
    }
}