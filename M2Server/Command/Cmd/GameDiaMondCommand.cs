using GameFramework;
using GameFramework.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command
{
    /// <summary>
    /// 调整当前玩家金刚石数量
    /// </summary>
    [GameCommand("GameDiaMond", "调整当前玩家金刚石数量", 10)]
    public class GameDiaMondCommand : BaseCommond
    {
        [DefaultCommand]
        public void GameDiaMond(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sCtr = @Params.Length > 1 ? @Params[1] : "";
            int nGameDiaMond = @Params.Length > 2 ? byte.Parse(@Params[2]) : (byte)0;
            char Ctr = '1';
            if ((sCtr != ""))
            {
                Ctr = sCtr[1];
            }
            if ((sHumanName == "") || !(new ArrayList(new string[] { "=", "+", "-" }).Contains(Ctr)) || (nGameDiaMond < 0) || (nGameDiaMond > 200000000) || ((sHumanName != "") && (sHumanName[0] == '?')))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, base.Attributes.Name, GameMsgDef.g_sGameCommandGameDiaMondHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            switch (sCtr[1])
            {
                case '=':
                    m_PlayObject.m_nGAMEDIAMOND = nGameDiaMond;
                    break;
                case '+':
                    m_PlayObject.m_nGAMEDIAMOND += nGameDiaMond;
                    break;
                case '-':
                    m_PlayObject.m_nGAMEDIAMOND -= nGameDiaMond;
                    break;
            }
            if (M2Share.g_boGameLogGameDiaMond)
            {
                M2Share.AddGameDataLog(string.Format(GameMsgDef.g_sGameLogMsg1, M2Share.LOG_GameDiaMond, m_PlayObject.m_sMapName,
                    m_PlayObject.m_nCurrX, m_PlayObject.m_nCurrY, m_PlayObject.m_sCharName, GameConfig.sGameDiaMond,
                    m_PlayObject.m_nGAMEDIAMOND, sCtr[1] + "(" + (nGameDiaMond).ToString() + ")", m_PlayObject.m_sCharName));
            }
            m_PlayObject.GameGoldChanged();
            m_PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandGameDiaMondHumanMsg, GameConfig.sGameDiaMond, nGameDiaMond, m_PlayObject.m_nGAMEDIAMOND, GameConfig.sGameDiaMond), TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandGameDiaMondGMMsg, sHumanName, GameConfig.sGameDiaMond, nGameDiaMond, m_PlayObject.m_nGAMEDIAMOND, GameConfig.sGameDiaMond), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}
