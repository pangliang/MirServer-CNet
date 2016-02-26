using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 制造物品
    /// </summary>
    [GameCommand("SmakeItem", "制造物品", 10)]
    public class SmakeItemCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void SmakeItem(TPlayObject PlayObject,string[] @Params)
        {
            int nWhere = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            int nValueType = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;
            int nValue = @Params.Length > 2 ? int.Parse(@Params[2]) : 0;
            string sShowMsg;
            TStdItem* StdItem;
            if ((nWhere >= 0 && nWhere <= 12) && (nValueType >= 0 && nValueType <= 15) && (nValue >= 0 && nValue <= 255))
            {
                if (PlayObject.m_UseItems[nWhere]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(PlayObject.m_UseItems[nWhere]->wIndex);
                    if (StdItem == null)
                    {
                        return;
                    }
                    if (nValueType > 13)
                    {
                        nValue = HUtil32._MIN(65, nValue);
                        if (nValueType == 14)
                        {
                            PlayObject.m_UseItems[nWhere]->Dura = (ushort)(nValue * 1000);
                        }
                        if (nValueType == 15)
                        {
                            PlayObject.m_UseItems[nWhere]->DuraMax = (ushort)(nValue * 1000);
                        }
                    }
                    else
                    {
                        PlayObject.m_UseItems[nWhere]->btValue[nValueType] = (byte)nValue;
                    }
                    PlayObject.RecalcAbilitys();
                    PlayObject.SendUpdateItem(PlayObject.m_UseItems[nWhere]);
                    sShowMsg = (PlayObject.m_UseItems[nWhere]->wIndex).ToString() + '-' + (PlayObject.m_UseItems[nWhere]->MakeIndex).ToString() + ' ' + (PlayObject.m_UseItems[nWhere]->Dura).ToString() + '/'
                        + (PlayObject.m_UseItems[nWhere]->DuraMax).ToString() + ' ' + (PlayObject.m_UseItems[nWhere]->btValue[0]).ToString() + '/'
                        + (PlayObject.m_UseItems[nWhere]->btValue[1]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[2]).ToString() + '/'
                        + (PlayObject.m_UseItems[nWhere]->btValue[3]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[4]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[5]).ToString()
                        + '/' + (PlayObject.m_UseItems[nWhere]->btValue[6]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[7]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[8]).ToString()
                        + '/' + (PlayObject.m_UseItems[nWhere]->btValue[9]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[10]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[11]).ToString()
                        + '/' + (PlayObject.m_UseItems[nWhere]->btValue[12]).ToString() + '/' + (PlayObject.m_UseItems[nWhere]->btValue[13]).ToString();
                    PlayObject.SysMsg(sShowMsg, TMsgColor.c_Blue, TMsgType.t_Hint);
                    if (GameConfig.boShowMakeItemMsg)
                    {
                        M2Share.MainOutMessage("[物品调整] " + PlayObject.m_sCharName + '(' + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + " -> " + sShowMsg + ')');
                    }
                }
                else
                {
                    PlayObject.SysMsg(GameMsgDef.g_sGamecommandSuperMakeHelpMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
        }
    }
}