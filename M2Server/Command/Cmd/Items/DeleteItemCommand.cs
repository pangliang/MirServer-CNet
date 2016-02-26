using GameFramework;
using GameFramework.Command;
using System;
using System.Runtime.InteropServices;

namespace M2Server
{
    /// <summary>
    /// 删除指定玩家包裹物品
    /// </summary>
    [GameCommand("DeleteItem", "删除指定玩家包裹物品", 10)]
    public class DeleteItemCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void DeleteItem(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";//玩家名称
            string sItemName = @Params.Length > 1 ? @Params[1] : "";//物品名称
            int nCount = @Params.Length > 2 ? int.Parse(@Params[2]) : 0;//数量
            int nItemCount;
            TStdItem* StdItem;
            TUserItem* UserItem;
            if ((sHumanName == "") || (sItemName == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 物品名称 数量)", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            nItemCount = 0;
            for (int I = m_PlayObject.m_ItemList.Count - 1; I >= 0; I--)
            {
                if (m_PlayObject.m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)m_PlayObject.m_ItemList[I];
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if ((StdItem != null) && ((sItemName).ToLower().CompareTo((HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen)).ToLower()) == 0))
                {
                    m_PlayObject.SendDelItems(UserItem);
                    m_PlayObject.m_ItemList.RemoveAt(I);
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    nItemCount++;
                    if (nItemCount >= nCount)
                    {
                        break;
                    }
                }
            }
        }
    }
}