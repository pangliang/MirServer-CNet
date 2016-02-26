using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 显示物品信息
    /// </summary>
    [GameCommand("ShowUseItem", "显示物品信息", 10)]
    public class ShowUseItemInfoCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void ShowUseItem(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            TUserItem* UserItem = null;
            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandShowUseItemInfoHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            for (int I = m_PlayObject.m_UseItems.GetLowerBound(0); I <= m_PlayObject.m_UseItems.GetUpperBound(0); I++)
            {
                UserItem = m_PlayObject.m_UseItems[I];
                if (UserItem->wIndex == 0)
                {
                    continue;
                }
                PlayObject.SysMsg(String.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]", M2Share.GetUseItemName(I), UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex,
                    UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax), TMsgColor.c_Blue, TMsgType.t_Hint);
            }
        }
    }
}