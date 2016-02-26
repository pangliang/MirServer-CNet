using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("BindUseItem", "", 10)]
    public class BindUseItemCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void BindUseItem(string[] @Params, TPlayObject PlayObject)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sItem = @Params.Length > 1 ? @Params[1] : "";
            string sType = @Params.Length > 2 ? @Params[2] : "";
            string sLight = @Params.Length > 3 ? @Params[3] : "";

            TUserItem* UserItem = null;
            int nBind = -1;
            TItemBind ItemBind;
            int nItemIdx;
            int nMakeIdex;
            string sBindName;
            bool boFind;
            bool boLight;
            int nItem = M2Share.GetUseItemIdx(sItem);
            if ((sType).ToLower().CompareTo(("帐号").ToLower()) == 0)
            {
                nBind = 0;
            }
            if ((sType).ToLower().CompareTo(("人物").ToLower()) == 0)
            {
                nBind = 1;
            }
            if ((sType).ToLower().CompareTo(("IP").ToLower()) == 0)
            {
                nBind = 2;
            }
            boLight = sLight == "1";
            if ((nItem < 0) || (nBind < 0) || (sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandBindUseItemHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            UserItem = m_PlayObject.m_UseItems[nItem];
            if (UserItem->wIndex == 0)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandBindUseItemNoItemMsg, sHumanName, sItem), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            nItemIdx = UserItem->wIndex;
            nMakeIdex = UserItem->MakeIndex;
            switch (nBind)
            {
                case 0:
                    boFind = false;
                    sBindName = m_PlayObject.m_sUserID;
                    HUtil32.EnterCriticalSection(M2Share.g_ItemBindAccount);
                    try
                    {
                        for (int I = 0; I < M2Share.g_ItemBindAccount.Count; I++)
                        {
                            ItemBind = M2Share.g_ItemBindAccount[I];
                            if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
                            {
                                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandBindUseItemAlreadBindMsg, sHumanName, sItem), TMsgColor.c_Red, TMsgType.t_Hint);
                                boFind = true;
                                break;
                            }
                        }
                        if (!boFind)
                        {
                            ItemBind = new TItemBind();
                            ItemBind.nItemIdx = nItemIdx;
                            ItemBind.nMakeIdex = nMakeIdex;
                            ItemBind.sBindName = sBindName;
                            M2Share.g_ItemBindAccount.Insert(0, ItemBind);
                        }
                    }
                    finally
                    {
                        HUtil32.LeaveCriticalSection(M2Share.g_ItemBindAccount);
                    }
                    if (boFind)
                    {
                        return;
                    }
                    M2Share.SaveItemBindAccount();
                    PlayObject.SysMsg(String.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]，绑定到%s成功。", M2Share.GetUseItemName(nItem),
                        UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex, UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);
                    m_PlayObject.SysMsg(String.Format("你的%s[%s]已经绑定到%s[%s]上了。", M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex),
                        sType, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);
                    m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_SENDUSEITEMS, 0, 0, 0, 0, "");
                    break;

                case 1:
                    sBindName = m_PlayObject.m_sCharName;
                    boFind = false;
                    HUtil32.EnterCriticalSection(M2Share.g_ItemBindCharName);
                    try
                    {
                        for (int I = 0; I < M2Share.g_ItemBindCharName.Count; I++)
                        {
                            ItemBind = M2Share.g_ItemBindCharName[I];
                            if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
                            {
                                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandBindUseItemAlreadBindMsg, sHumanName, sItem), TMsgColor.c_Red, TMsgType.t_Hint);
                                boFind = true;
                                break;
                            }
                        }
                        if (!boFind)
                        {
                            ItemBind = new TItemBind();
                            ItemBind.nItemIdx = nItemIdx;
                            ItemBind.nMakeIdex = nMakeIdex;
                            ItemBind.sBindName = sBindName;
                            M2Share.g_ItemBindCharName.Insert(0, ItemBind);
                        }
                    }
                    finally
                    {
                        HUtil32.LeaveCriticalSection(M2Share.g_ItemBindCharName);
                    }
                    if (boFind)
                    {
                        return;
                    }
                    M2Share.SaveItemBindCharName();
                    PlayObject.SysMsg(String.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]，绑定到%s成功。", M2Share.GetUseItemName(nItem),
                        UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex, UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);
                    m_PlayObject.SysMsg(String.Format("你的%s[%s]已经绑定到%s[%s]上了。", M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex),
                        sType, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);

                    // PlayObject.SendUpdateItem(UserItem);
                    m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_SENDUSEITEMS, 0, 0, 0, 0, "");
                    break;

                case 2:
                    boFind = false;
                    sBindName = m_PlayObject.m_sIPaddr;
                    HUtil32.EnterCriticalSection(M2Share.g_ItemBindIPaddr);
                    try
                    {
                        for (int I = 0; I < M2Share.g_ItemBindIPaddr.Count; I++)
                        {
                            ItemBind = M2Share.g_ItemBindIPaddr[I];
                            if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
                            {
                                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandBindUseItemAlreadBindMsg, sHumanName, sItem), TMsgColor.c_Red, TMsgType.t_Hint);
                                boFind = true;
                                break;
                            }
                        }
                        if (!boFind)
                        {
                            ItemBind = new TItemBind();
                            ItemBind.nItemIdx = nItemIdx;
                            ItemBind.nMakeIdex = nMakeIdex;
                            ItemBind.sBindName = sBindName;
                            M2Share.g_ItemBindIPaddr.Insert(0, ItemBind);
                        }
                    }
                    finally
                    {
                        HUtil32.LeaveCriticalSection(M2Share.g_ItemBindIPaddr);
                    }
                    if (boFind)
                    {
                        return;
                    }
                    M2Share.SaveItemBindIPaddr();
                    PlayObject.SysMsg(String.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]，绑定到%s成功。", M2Share.GetUseItemName(nItem),
                        UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex, UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);
                    m_PlayObject.SysMsg(String.Format("你的%s[%s]已经绑定到%s[%s]上了。", M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex),
                        sType, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);

                    // PlayObject.SendUpdateItem(UserItem);
                    m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_SENDUSEITEMS, 0, 0, 0, 0, "");
                    break;
            }
        }
    }
}