using GameFramework;
using GameFramework.Command;
using System;
using System.Collections;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家声望点
    /// </summary>
    [GameCommand("CreditPoint", "调整指定玩家声望点", 10)]
    public class CreditPointCommand : BaseCommond
    {
        [DefaultCommand]
        public void CreditPoint(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sCtr = @Params.Length > 1 ? @Params[1] : "";
            int nPoint = @Params.Length > 2 ? int.Parse(@Params[2]) : 0;
            char Ctr = '1';
            int nCreditPoint;
            if ((sCtr != ""))
            {
                Ctr = sCtr[0];
            }
            if ((sHumanName == "") || !(new ArrayList(new char[] { '=', '+', '-' }).Contains(Ctr)) || (nPoint < 0) || (nPoint > Int32.MaxValue)
                || ((sHumanName != "") && (sHumanName[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandCreditPointHelpMsg),
                    TMsgColor.c_Red, TMsgType.t_Hint);
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
                    if (nPoint >= 0)
                    {
                        m_PlayObject.m_btCreditPoint = (UInt16)nPoint;
                    }
                    break;

                case '+':
                    nCreditPoint = m_PlayObject.m_btCreditPoint + nPoint;
                    if (nPoint >= 0)
                    {
                        m_PlayObject.m_btCreditPoint = (UInt16)nCreditPoint;
                    }
                    break;

                case '-':
                    nCreditPoint = m_PlayObject.m_btCreditPoint - nPoint;
                    if (nPoint >= 0)
                    {
                        m_PlayObject.m_btCreditPoint = (UInt16)nCreditPoint;
                    }
                    break;
            }
            m_PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandCreditPointHumanMsg, nPoint, m_PlayObject.m_btCreditPoint),
                TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandCreditPointGMMsg, sHumanName, nPoint, m_PlayObject.m_btCreditPoint),
                TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}