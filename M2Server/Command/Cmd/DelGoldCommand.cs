using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家游戏币
    /// </summary>
    [GameCommand("DelGold", "调整指定玩家游戏币", 10)]
    public class DelGoldCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelGold(TPlayObject PlayObject,string[] @Params)
        {
            string sHumName = @Params.Length > 0 ? @Params[0] : "";
            int nCount = @Params.Length > 1 ? Convert.ToInt32(@Params[1]) : 0;
            if ((sHumName == "") || (nCount <= 0))
            {
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumName);
            int nServerIndex = 0;
            if ((sHumName == "") || (nCount <= 0))
            {
                return;
            }
            m_PlayObject = UserEngine.GetPlayObject(sHumName);
            if (m_PlayObject != null)
            {
                if (m_PlayObject.m_nGold > nCount)
                {
                    m_PlayObject.m_nGold -= nCount;
                }
                else
                {
                    nCount = m_PlayObject.m_nGold;
                    m_PlayObject.m_nGold = 0;
                }
                m_PlayObject.GoldChanged();
                PlayObject.SysMsg(sHumName + "的金币已减少" + (nCount).ToString() + ".", TMsgColor.c_Green, TMsgType.t_Hint);
                if (M2Share.g_boGameLogGold)
                {
                    M2Share.AddGameDataLog("13" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString() + "\09" 
                        + PlayObject.m_sCharName + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (nCount).ToString() + "\09" + "1" + "\09" + sHumName);
                }
            }
            else
            {
                if (UserEngine.FindOtherServerUser(sHumName, ref nServerIndex))
                {
                    PlayObject.SysMsg(sHumName + "现在" + (nServerIndex).ToString() + "号服务器上", TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    M2Share.FrontEngine.AddChangeGoldList(PlayObject.m_sCharName, sHumName, -nCount);
                    PlayObject.SysMsg(sHumName + "现在不在线，等其上线时金币将自动减少", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
        }
    }
}