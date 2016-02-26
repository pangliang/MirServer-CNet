using GameFramework;
using GameFramework.Command;
using System;
using System.Runtime.InteropServices;

namespace M2Server
{
    /// <summary>
    /// 取指定玩家物品
    /// </summary>
    [GameCommand("GetUserItems", "取指定玩家物品", 10)]
    public class GetUserItemsCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void GetUserItems(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sItemName = @Params.Length > 1 ? @Params[1] : "";
            string sItemCount = @Params.Length > 2 ? @Params[2] : "";
            string sType = @Params.Length > 3 ? @Params[3] : "";

            int nItemCount;
            int nCount;
            int nType;
            TStdItem* StdItem;
            TUserItem* UserItem = null;
            if ((sHumanName == "") || (sItemName == "") || (sItemCount == "") || (sType == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 物品名称 数量 类型(0,1,2))", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            nCount = HUtil32.Str_ToInt(sItemCount, 0);
            nType = HUtil32.Str_ToInt(sType, 0);
            switch (nType)
            {
                case 0:
                    nItemCount = 0;
                    for (int I = m_PlayObject.m_UseItems.GetLowerBound(0); I <= m_PlayObject.m_UseItems.GetUpperBound(0); I++)
                    {
                        if (m_PlayObject.m_ItemList.Count >= 46)
                        {
                            break;
                        }
                        UserItem = m_PlayObject.m_UseItems[I];
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if ((StdItem != null) && ((sItemName).ToLower().CompareTo((StdItem->ToString()).ToLower()) == 0))
                        {
                            if (!m_PlayObject.IsEnoughBag())
                            {
                                break;
                            }
                            UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                            for (int i = 0; i < 22; i++)
                            {
                                UserItem->btValue[i] = 0;
                            }
                            *UserItem = *m_PlayObject.m_UseItems[I];
                            m_PlayObject.m_ItemList.Add((IntPtr)UserItem);
                            m_PlayObject.SendAddItem(UserItem);
                            m_PlayObject.m_UseItems[I]->wIndex = 0;
                            nItemCount++;
                            if (nItemCount >= nCount)
                            {
                                break;
                            }
                        }
                    }
                    m_PlayObject.SendUseitems();
                    break;

                case 1:
                    nItemCount = 0;
                    for (int I = m_PlayObject.m_ItemList.Count - 1; I >= 0; I--)
                    {
                        if (m_PlayObject.m_ItemList.Count >= 46)
                        {
                            break;
                        }
                        if (m_PlayObject.m_ItemList.Count <= 0)
                        {
                            break;
                        }
                        UserItem = (TUserItem*)m_PlayObject.m_ItemList[I];
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if ((StdItem != null) && ((sItemName).ToLower().CompareTo((StdItem->ToString()).ToLower()) == 0))
                        {
                            if (!m_PlayObject.IsEnoughBag())
                            {
                                break;
                            }
                            m_PlayObject.SendDelItems(UserItem);
                            m_PlayObject.m_ItemList.RemoveAt(I);
                            m_PlayObject.m_ItemList.Add((IntPtr)UserItem);
                            m_PlayObject.SendAddItem(UserItem);
                            nItemCount++;
                            if (nItemCount >= nCount)
                            {
                                break;
                            }
                        }
                    }
                    break;

                case 2:
                    nItemCount = 0;
                    for (int I = m_PlayObject.m_StorageItemList.Count - 1; I >= 0; I--)
                    {
                        if (m_PlayObject.m_ItemList.Count >= 46)
                        {
                            break;
                        }
                        if (m_PlayObject.m_StorageItemList.Count <= 0)
                        {
                            break;
                        }
                        UserItem = (TUserItem*)m_PlayObject.m_StorageItemList[I];
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if ((StdItem != null) && ((sItemName).ToLower().CompareTo((StdItem->ToString()).ToLower()) == 0))
                        {
                            if (!m_PlayObject.IsEnoughBag())
                            {
                                break;
                            }
                            m_PlayObject.m_StorageItemList.RemoveAt(I);
                            m_PlayObject.m_ItemList.Add((IntPtr)UserItem);
                            m_PlayObject.SendAddItem(UserItem);
                            nItemCount++;
                            if (nItemCount >= nCount)
                            {
                                break;
                            }
                        }
                    }
                    break;
            }
        }
    }
}