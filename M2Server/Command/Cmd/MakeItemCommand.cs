using GameFramework;
using GameFramework.Command;
using System;
using System.Runtime.InteropServices;

namespace M2Server
{
    /// <summary>
    /// 制造指定物品(支持权限分配，小于最大权限受允许、禁止制造列表限制)
    /// 要求权限默认等级：10
    /// </summary>
    [GameCommand("Make", "制造指定物品(支持权限分配，小于最大权限受允许、禁止制造列表限制)", 10)]
    public class MakeItemCommond : BaseCommond
    {
        [DefaultCommand]
        public unsafe void CmdMakeItem(string[] @Params, TPlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            TUserItem* UserItem;
            TStdItem* StdItem;
            string sItemName = @Params.Length > 0 ? @Params[0] : "";//物品名称
            int nCount = @Params.Length > 1 ? Convert.ToInt32(@Params[1]) : 1;//数量
            string sParam = @Params.Length > 2 ? @Params[2] : "";//可选参数（持久力）
            if ((sItemName == ""))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGamecommandMakeHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if ((nCount <= 0))
            {
                nCount = 1;
            }
            if ((nCount > 10))
            {
                nCount = 10;
            }
            if ((PlayObject.m_btPermission < this.Attributes.nPermissionMax))
            {
                if (!M2Share.CanMakeItem(sItemName))
                {
                    PlayObject.SysMsg(GameMsgDef.g_sGamecommandMakeItemNameOrPerMissionNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (M2Share.g_CastleManager.InCastleWarArea(PlayObject) != null) // 攻城区域，禁止使用此功能
                {
                    PlayObject.SysMsg(GameMsgDef.g_sGamecommandMakeInCastleWarRange, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (!PlayObject.InSafeZone())
                {
                    PlayObject.SysMsg(GameMsgDef.g_sGamecommandMakeInSafeZoneRange, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                nCount = 1;
            }
            for (int I = 0; I < nCount; I++)
            {
                if (PlayObject.m_ItemList.Count >= Grobal2.MAXBAGITEM)
                {
                    return;
                }
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (UserEngine.CopyToUserItemFromName(sItemName, UserItem))
                {
                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                    if ((StdItem->Price >= 15000) && !M2Share.g_Config.boTestServer && (PlayObject.m_btPermission < 5))
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        UserItem = null;
                    }
                    else
                    {
                        if (HUtil32.Random(M2Share.g_Config.nMakeRandomAddValue) == 0)
                        {
                            UserEngine.RandomUpgradeItem(UserItem);
                        }
                    }
                    if (PlayObject.m_btPermission >= this.Attributes.nPermissionMax)
                    {
                        UserItem->MakeIndex = M2Share.GetItemNumberEx();// 制造的物品另行取得物品ID
                    }
                    PlayObject.m_ItemList.Add((IntPtr)UserItem);
                    PlayObject.SendAddItem(UserItem);
                    if ((PlayObject.m_btPermission >= 6))
                    {
                        M2Share.MainOutMessage("[制造物品] " + PlayObject.m_sCharName + " " + sItemName + "(" + (UserItem->MakeIndex).ToString() + ")");
                    }
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("5" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString()
                            + "\09" + PlayObject.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + (UserItem->MakeIndex).ToString() + "\09" + "(" +
                            (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString()
                            + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC))
                            .ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")" + (UserItem->btValue[0]).ToString()
                            + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString()
                            + "/" + (UserItem->btValue[4]).ToString() + "/" + (UserItem->btValue[5]).ToString() + "/" + (UserItem->btValue[6]).ToString()
                            + "/" + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString()
                            + "\09" + PlayObject.m_sCharName);
                    }
                }
                else
                {
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    UserItem = null;
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGamecommandMakeItemNameNotFound, sItemName), TMsgColor.c_Red, TMsgType.t_Hint);
                    break;
                }
            }
        }
    }
}