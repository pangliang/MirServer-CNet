using GameFramework;
using GameFramework.Command;
using System;
using System.Collections;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家游戏币
    /// </summary>
    [GameCommand("GameGold", "调整指定玩家游戏币", 10)]
    public class GameGoldCommand : BaseCommond
    {
        [DefaultCommand]
        public void GameGold(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sCtr = @Params.Length > 1 ? @Params[1] : "";
            int nGold = @Params.Length > 2 ? int.Parse(@Params[2]) : 0;
            char Ctr = '1';
            if ((sCtr != ""))
            {
                Ctr = sCtr[0];
            }
            if ((sHumanName == "") || !(new ArrayList(new char[] { '=', '+', '-' }).Contains(Ctr)) || (nGold < 0) || (nGold > 200000000) || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandGameGoldHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            switch (sCtr[0])
            {
                case '=':
                    m_PlayObject.m_nGameGold = nGold;
                    break;

                case '+':
                    m_PlayObject.m_nGameGold += nGold;
                    break;

                case '-':
                    m_PlayObject.m_nGameGold -= nGold;
                    break;
            }
            if (M2Share.g_boGameLogGameGold)
            {
                M2Share.AddGameDataLog(String.Format(GameMsgDef.g_sGameLogMsg1, M2Share.LOG_GAMEGOLD, m_PlayObject.m_sMapName, m_PlayObject.m_nCurrX, m_PlayObject.m_nCurrY,
                    m_PlayObject.m_sCharName, M2Share.g_Config.sGameGoldName, nGold, sCtr[1], PlayObject.m_sCharName));
            }
            PlayObject.GameGoldChanged();
            m_PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandGameGoldHumanMsg, M2Share.g_Config.sGameGoldName, nGold, m_PlayObject.m_nGameGold,
                M2Share.g_Config.sGameGoldName), TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandGameGoldGMMsg, sHumanName, M2Share.g_Config.sGameGoldName, nGold, m_PlayObject.m_nGameGold,
                M2Share.g_Config.sGameGoldName), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}