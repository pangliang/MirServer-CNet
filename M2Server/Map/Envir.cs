using GameFramework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace M2Server
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TMapHeader //Size 52
    {
        public UInt16 wWidth;
        public UInt16 wHeight;
        public byte TitleLen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        private string _sTitle;
        public string sTitle
        {
            get { return _sTitle; }
            set
            {
                _sTitle = value;
                TitleLen = HUtil32.GetStrLength(value);
            }
        }
        public double UpdateDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 23)]
        public sbyte[] Reserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct TMapUnitInfo
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort wBkImg;
        [MarshalAs(UnmanagedType.U2)]
        public ushort wMidImg;
        [MarshalAs(UnmanagedType.U2)]
        public ushort wFrImg;
        [MarshalAs(UnmanagedType.U1)]
        public byte btDoorIndex;
        [MarshalAs(UnmanagedType.U1)]
        public byte btDoorOffset;
        [MarshalAs(UnmanagedType.U1)]
        public byte btAniFrame;
        [MarshalAs(UnmanagedType.U1)]
        public byte btAniTick;
        [MarshalAs(UnmanagedType.U1)]
        public byte btArea;
        [MarshalAs(UnmanagedType.U1)]
        public byte btLight;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TMapCellinfo
    {
        public byte chFlag;
        public List<TOSObject> ObjList;
    }
}

