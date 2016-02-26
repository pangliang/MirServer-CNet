using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace M2Server
{
    [GameCommand("ClearBagItem", "清理包裹物品",10)]
    public class ClearBagItemCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void ClearBagItem(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? Params[0] : "";
            TUserItem* UserItem;
            List<string> DelList = null;
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, "人物名称"), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            try
            {
                m_PlayObject.m_boOperationItemList = true;// 正在操作背包列表
                if (m_PlayObject.m_ItemList.Count > 0)
                {
                    for (int I = m_PlayObject.m_ItemList.Count - 1; I >= 0; I--)
                    {
                        UserItem = (TUserItem*)m_PlayObject.m_ItemList[I];
                        if (DelList == null)
                        {
                            DelList = new List<string>();
                        }
                        //DelList.Add(UserEngine.GetStdItemName(UserItem->wIndex), ((UserItem->MakeIndex) as Object));
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        m_PlayObject.m_ItemList.RemoveAt(I);
                    }
                    m_PlayObject.m_ItemList.Clear();
                }
                if (DelList != null)
                {
                    m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_SENDDELITEMLIST, 0, Parse(DelList), 0, 0, "");
                }
            }
            finally
            {
                m_PlayObject.m_boOperationItemList = false;// 正在操作背包列表
            }
        }
    }
}