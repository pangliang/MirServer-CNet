using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家游戏币
    /// </summary>
    [GameCommand("DelGameGold", "调整指定玩家游戏币", 10)]
    public class DelGameGoldCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelGameGold(TPlayObject PlayObject,string[] @Params)
        {
            TPlayObject m_PlayObject;
            string sHumName = @Params.Length > 0 ? @Params[0] : "";//玩家名称
            int nPoint = @Params.Length > 1 ? Convert.ToInt32(@Params[1]) : 0;//数量
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            if ((sHumName == "") || (nPoint <= 0))
            {
                return;
            }
            m_PlayObject = UserEngine.GetPlayObject(sHumName);
            if (m_PlayObject != null)
            {
                if (m_PlayObject.m_nGameGold > nPoint)
                {
                    m_PlayObject.m_nGameGold -= nPoint;
                }
                else
                {
                    nPoint = m_PlayObject.m_nGameGold;
                    m_PlayObject.m_nGameGold = 0;
                }
                m_PlayObject.GoldChanged();
                PlayObject.SysMsg(sHumName + "的游戏点已减少" + nPoint + '.', TMsgColor.c_Green, TMsgType.t_Hint);
                m_PlayObject.SysMsg("游戏点已减少" + nPoint + '.', TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}