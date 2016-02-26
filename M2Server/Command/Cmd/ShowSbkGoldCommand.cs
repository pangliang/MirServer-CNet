using GameFramework;
using GameFramework.Command;
using System;
using System.Collections;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 显示沙巴克收入金币
    /// </summary>
    [GameCommand("ShowSbkGold", "显示沙巴克收入金币", 10)]
    public class ShowSbkGoldCommand : BaseCommond
    {
        [DefaultCommand]
        public void ShowSbkGold(TPlayObject PlayObject,string[] @Params)
        {
            string sCASTLENAME = @Params.Length > 0 ? @Params[0] : "";
            string sCtr = @Params.Length > 1 ? @Params[1] : "";
            string sGold = @Params.Length > 2 ? @Params[2] : "";

            char Ctr;
            int nGold;
            TUserCastle Castle;
            List<string> List;
            if (((sCASTLENAME != "") && (sCASTLENAME[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (sCASTLENAME == "")
            {
                List = new List<string>();
                M2Share.g_CastleManager.GetCastleGoldInfo(List);
                for (int I = 0; I < List.Count; I++)
                {
                    PlayObject.SysMsg(List[I], TMsgColor.c_Green, TMsgType.t_Hint);
                }
                HUtil32.Dispose(List);
                return;
            }
            Castle = M2Share.g_CastleManager.Find(sCASTLENAME);
            if (Castle == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandSbkGoldCastleNotFoundMsg, sCASTLENAME), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            Ctr = sCtr[1];
            nGold = HUtil32.Str_ToInt(sGold, -1);
            if (!(new ArrayList(new char[] { '=', '-', '+' }).Contains(Ctr)) || (nGold < 0) || (nGold > 100000000))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandSbkGoldHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            switch (Ctr)
            {
                case '=':
                    Castle.m_nTotalGold = nGold;
                    break;

                case '-':
                    Castle.m_nTotalGold -= 1;
                    break;

                case '+':
                    Castle.m_nTotalGold += nGold;
                    break;
            }
            if (Castle.m_nTotalGold < 0)
            {
                Castle.m_nTotalGold = 0;
            }
        }
    }
}