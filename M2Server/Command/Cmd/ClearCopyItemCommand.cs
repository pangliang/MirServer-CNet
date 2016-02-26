using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command.Cmd
{
    [GameCommand(" ClearCopyItem", "清除复制物品", 10)]
    public class ClearCopyItemCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void ClearCopyItem(string[] @Params, TPlayObject PlayObjec)
        {
            string sName = @Params.Length > 0 ? @Params[0] : "";

            TPlayObject PlayObjectA;
            TUserItem* UserItem;
            TUserItem* UserItem1;
            string s14;
            if ((PlayObjec.m_btPermission < this.Attributes.nPermissionMin))
            {
                PlayObjec.SysMsg(GameMsgDef.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sName == ""))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObjec.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            PlayObjectA = UserEngine.GetPlayObject(sName);
            if (PlayObjectA == null)
            {
                PlayObjec.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, new string[] { sName }), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            for (int I = PlayObjectA.m_ItemList.Count - 1; I >= 0; I--)
            {
                if (PlayObjectA.m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)PlayObjectA.m_ItemList[I];
                s14 = UserEngine.GetStdItemName(UserItem->wIndex);
                for (int II = I - 1; II >= 0; II--)
                {
                    UserItem1 = (TUserItem*)PlayObjectA.m_ItemList[II];
                    if ((UserEngine.GetStdItemName(UserItem1->wIndex) == s14) && (UserItem->MakeIndex == UserItem1->MakeIndex))
                    {
                        PlayObjec.m_ItemList.RemoveAt(II);
                        break;
                    }
                }
            }
            for (int I = PlayObjectA.m_StorageItemList.Count - 1; I >= 0; I--)
            {
                if (PlayObjectA.m_StorageItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)PlayObjectA.m_StorageItemList[I];
                s14 = UserEngine.GetStdItemName(UserItem->wIndex);
                for (int II = I - 1; II >= 0; II--)
                {
                    UserItem1 = (TUserItem*)PlayObjectA.m_StorageItemList[II];
                    if ((UserEngine.GetStdItemName(UserItem1->wIndex) == s14) && (UserItem->MakeIndex == UserItem1->MakeIndex))
                    {
                        PlayObjec.m_StorageItemList.RemoveAt(II);
                        break;
                    }
                }
            }
        }
    }
}
