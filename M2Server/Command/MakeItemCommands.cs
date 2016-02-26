using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using System.Runtime.InteropServices;

namespace M2Server
{
    /// <summary>
    /// 制造物品命令
    /// </summary>
    public class MakeItemCommands
    {
        unsafe public void ExecCmd(TPlayObject Play, TGameCmd Cmd, string sItemName, int nCount)
        {
            TUserItem* UserItem = null;
            TStdItem* StdItem;
            if ((Play.m_btPermission < Cmd.nPermissionMin))
            {
                Play.SysMsg(TMsgConst.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sItemName == ""))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    Play.SysMsg(string.Format(TMsgConst.g_sGameCommandParamUnKnow, Cmd.sCmd, TMsgConst.g_sGamecommandMakeHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
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
            if ((Play.m_btPermission < Cmd.nPermissionMax))
            {
                if (!M2Share.CanMakeItem(sItemName))
                {
                    Play.SysMsg(TMsgConst.g_sGamecommandMakeItemNameOrPerMissionNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (M2Share.g_CastleManager.InCastleWarArea(Play) != null) // 攻城区域，禁止使用此功能
                {
                    Play.SysMsg(TMsgConst.g_sGamecommandMakeInCastleWarRange, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (!Play.InSafeZone())
                {
                    Play.SysMsg(TMsgConst.g_sGamecommandMakeInSafeZoneRange, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                nCount = 1;
            }
            for (int I = 0; I < nCount; I++)
            {
                if (Play.m_ItemList.Count >= Grobal2.MAXBAGITEM)
                {
                    return;
                }
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (M2Share.UserEngine.CopyToUserItemFromName(sItemName, UserItem))
                {
                    StdItem = M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                    if ((StdItem->Price >= 15000) && !M2Share.g_Config.boTestServer && (Play.m_btPermission < 5))
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        UserItem = null;
                    }
                    else
                    {
                        if (HUtil32.Random(M2Share.g_Config.nMakeRandomAddValue) == 0)
                        {
                            M2Share.UserEngine.RandomUpgradeItem(UserItem);
                        }
                    }
                    if (Play.m_btPermission >= Cmd.nPermissionMax)
                    {
                        UserItem->MakeIndex = M2Share.GetItemNumberEx();// 制造的物品另行取得物品ID
                    }
                    Play.m_ItemList.Add((IntPtr)UserItem);
                    Play.SendAddItem(UserItem);
                    if ((Play.m_btPermission >= 6))
                    {
                        M2Share.MainOutMessage("[制造物品] " + Play.m_sCharName + " " + sItemName + "(" + (UserItem->MakeIndex).ToString() + ")");
                    }
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("5" + "\09" + Play.m_sMapName + "\09" + (Play.m_nCurrX).ToString() + "\09" + (Play.m_nCurrY).ToString()
                            + "\09" + Play.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + (UserItem->MakeIndex).ToString() + "\09" + "(" +
                            (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString()
                            + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC))
                            .ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")" + (UserItem->btValue[0]).ToString()
                            + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString()
                            + "/" + (UserItem->btValue[4]).ToString() + "/" + (UserItem->btValue[5]).ToString() + "/" + (UserItem->btValue[6]).ToString()
                            + "/" + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString()
                            + "\09" + Play.m_sCharName);
                    }
                }
                else
                {
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    UserItem = null;
                    Play.SysMsg(string.Format(TMsgConst.g_sGamecommandMakeItemNameNotFound, sItemName), TMsgColor.c_Red, TMsgType.t_Hint);
                    break;
                }
            }
        }
    }
}