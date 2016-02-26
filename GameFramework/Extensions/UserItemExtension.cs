using GameFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public static class UserItemExtension
    {
        public unsafe static SUserItem GetUserItem(this TUserItem UserItem)
        {
            sbyte[] data = new sbyte[22];
            for (int j = 0; j < 22; j++)
            {
                data[j] = (sbyte)UserItem.btValue[j];
            }
            fixed (sbyte* pb = data)
            {
                return new SUserItem()
                {
                    Dura = UserItem.Dura,
                    DuraMax = UserItem.DuraMax,
                    MakeIndex = UserItem.MakeIndex,
                    wIndex = UserItem.wIndex,
                    btValue = pb
                };
            }
        }
    }
}