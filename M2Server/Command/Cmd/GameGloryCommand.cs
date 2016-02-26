using GameFramework;
using GameFramework.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command.Cmd
{
    /// <summary>
    /// 调整指定玩家荣誉值
    /// </summary>
    [GameCommand("GameGlory", "调整指定玩家荣誉值", 10)]
    public class GameGloryCommand : BaseCommond
    {
        [DefaultCommand]
        public void GameGlory(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sCtr = @Params.Length > 1 ? @Params[1] : "";
            byte nGameGlory = @Params.Length > 2 ? Convert.ToByte(@Params[2]) : (byte)0;

            char Ctr = '1';
            if ((sCtr != ""))
            {
                Ctr = sCtr[0];
            }
            if ((sHumanName == "") || !(new ArrayList(new string[] { "=", "+", "-" }).Contains(Ctr)) || (nGameGlory < 0) || (nGameGlory > 255) || ((sHumanName != "") && (sHumanName[0] == '?')))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, base.Attributes.Name, GameMsgDef.g_sGameCommandGameGloryHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, new string[] { sHumanName }), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            switch (sCtr[0])
            {
                case '=':
                    m_PlayObject.m_btGameGlory = nGameGlory;
                    break;
                case '+':
                    m_PlayObject.m_btGameGlory += nGameGlory;
                    break;
                case '-':
                    m_PlayObject.m_btGameGlory -= nGameGlory;
                    break;
            }
            if (M2Share.g_boGameLogGameGlory)
            {
                M2Share.AddGameDataLog(string.Format(GameMsgDef.g_sGameLogMsg1, M2Share.LOG_GameGlory, m_PlayObject.m_sMapName, m_PlayObject.m_nCurrX, m_PlayObject.m_nCurrY, m_PlayObject.m_sCharName, GameConfig.sGameGlory, m_PlayObject.m_btGameGlory, sCtr[1] + "(" + (nGameGlory).ToString() + ")", m_PlayObject.m_sCharName));
            }
            m_PlayObject.GameGloryChanged();
            m_PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandGameGirdHumanMsg, GameConfig.sGameGlory, nGameGlory, m_PlayObject.m_btGameGlory, GameConfig.sGameGlory), TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandGameGirdGMMsg, sHumanName, GameConfig.sGameGlory, nGameGlory, m_PlayObject.m_btGameGlory, GameConfig.sGameGlory), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}