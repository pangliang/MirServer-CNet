using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SocketTest
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class MyTestInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public TUserItem[] UserItem;
    }
}