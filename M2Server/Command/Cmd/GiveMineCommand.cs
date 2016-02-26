using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace M2Server.Command
{
    /// <summary>
    /// 给指定纯度的矿石
    /// 命令格式:GIVEMINE 矿名称 数量 纯度
    /// 如纯度不填,则随机给纯度
    /// </summary>
    [GameCommand("GiveMine", "给指定纯度的矿石", 10)]
    public class GiveMineCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void GiveMine(TPlayObject PlayObject,string[] @Params)
        {
            string sMINEName = @Params.Length > 0 ? @Params[0] : "";
            int nMineCount = @Params.Length > 0 ? int.Parse(@Params[1]) : 0;
            int nDura = @Params.Length > 0 ? int.Parse(@Params[2]) : 0;
            TUserItem* UserItem = null;
            TStdItem* StdItem;
            if ((sMINEName == "") || ((sMINEName != "") && (sMINEName[0] == '?')) || (nMineCount <= 0))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandGIVEMINEHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (nDura <= 0)// 如纯度不填,则随机给纯度
            {
                nDura = HUtil32.Random(18) + 3;
            }
            for (int I = 0; I < nMineCount; I++)
            {
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (UserEngine.CopyToUserItemFromName(sMINEName, UserItem))
                {
                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                    if ((StdItem != null) && (StdItem->StdMode == 43))
                    {
                        if (PlayObject.IsAddWeightAvailable(StdItem->Weight * nMineCount))
                        {
                            UserItem->Dura = Convert.ToUInt16(Convert.ToInt16(nDura * 1000));
                            if (UserItem->Dura > UserItem->DuraMax)
                            {
                                UserItem->Dura = UserItem->DuraMax;
                            }
                            PlayObject.m_ItemList.Add((IntPtr)UserItem);
                            PlayObject.SendAddItem(UserItem);
                            if (StdItem->NeedIdentify == 1)
                            {
                                M2Share.AddGameDataLog("5" + "\09" + PlayObject.m_sMapName + "\09" + PlayObject.m_nCurrX + "\09" + PlayObject.m_nCurrY + "\09" +
                                    PlayObject.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + UserItem->MakeIndex + "\09" + UserItem->Dura + "/" + UserItem->DuraMax + "\09" + PlayObject.m_sCharName);
                            }
                        }
                    }
                }
                else
                {
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    break;
                }
            }
        }
    }
}