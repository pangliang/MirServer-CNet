using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("LotteryTicket", "", 10)]
    public class LotteryTicketCommandL : BaseCommond
    {
        [DefaultCommand]
        public void LotteryTicket(TPlayObject PlayObject,string[] @Params)
        {
            string sParam1 = @Params.Length > 0 ? @Params[0] : "";
            if ((sParam1 == "") || ((sParam1 != "") && (sParam1[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandLotteryTicketMsg, GameConfig.nWinLotteryCount,
                GameConfig.nNoWinLotteryCount, GameConfig.nWinLotteryLevel1, GameConfig.nWinLotteryLevel2,
                GameConfig.nWinLotteryLevel3, GameConfig.nWinLotteryLevel4, GameConfig.nWinLotteryLevel5,
                GameConfig.nWinLotteryLevel6), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}