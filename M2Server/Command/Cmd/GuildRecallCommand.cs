using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 行会传送，行会掌门人可以将整个行会成员全部集中。
    /// </summary>
    [GameCommand("GuildRecall", "行会传送，行会掌门人可以将整个行会成员全部集中。", 10)]
    public class GuildRecallCommand : BaseCommond
    {
        [DefaultCommand]
        public void GuildRecall(TPlayObject PlayObject,string[] @Params)
        {
            string sParam = @Params.Length > 0 ? @Params[0] : "";
            if ((sParam != "") && (sParam[1] == '?'))
            {
                PlayObject.SysMsg("命令功能: 行会传送，行会掌门人可以将整个行会成员全部集中。", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (!PlayObject.m_boGuildMove && (PlayObject.m_btPermission < 6))
            {
                PlayObject.SysMsg("您现在还无法使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (!PlayObject.IsGuildMaster())
            {
                PlayObject.SysMsg("行会掌门人才可以使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_PEnvir.m_boNOGUILDRECALL)
            {
                PlayObject.SysMsg("本地图不允许使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TGuildRank GuildRank;
            TUserCastle m_Castle;
            m_Castle = M2Share.g_CastleManager.InCastleWarArea(PlayObject);
            if ((m_Castle != null) && m_Castle.m_boUnderWar)
            {
                PlayObject.SysMsg("攻城区域不允许使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            int nRecallCount = 0;
            int nNoRecallCount = 0;
            uint dwValue = (HUtil32.GetTickCount() - PlayObject.m_dwGroupRcallTick) / 1000;
            PlayObject.m_dwGroupRcallTick = PlayObject.m_dwGroupRcallTick + dwValue * 1000;
            if (PlayObject.m_btPermission >= 6)
            {
                PlayObject.m_wGroupRcallTime = 0;
            }
            if (PlayObject.m_wGroupRcallTime > dwValue)
            {
                PlayObject.m_wGroupRcallTime -= dwValue;
            }
            else
            {
                PlayObject.m_wGroupRcallTime = 0;
            }
            if (PlayObject.m_wGroupRcallTime > 0)
            {
                PlayObject.SysMsg(String.Format("{0} 秒之后才可以再使用此功能！！！", PlayObject.m_wGroupRcallTime), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject;
            for (int I = 0; I < PlayObject.m_MyGuild.m_RankList.Count; I++)
            {
                GuildRank = PlayObject.m_MyGuild.m_RankList[I];
                if (GuildRank == null)
                {
                    continue;
                }
                for (int II = 0; II < GuildRank.MemberList.Count; II++)
                {
                    m_PlayObject = GuildRank.MemberList[II];
                    if (m_PlayObject != null)
                    {
                        if (m_PlayObject == PlayObject)
                        {
                            // Inc(nNoRecallCount);
                            continue;
                        }
                        if (m_PlayObject.m_boAllowGuildReCall)
                        {
                            if (m_PlayObject.m_PEnvir.m_boNORECALL)
                            {
                                PlayObject.SysMsg(String.Format("{0} 所在的地图不允许传送。", m_PlayObject.m_sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
                            }
                            else
                            {
                                PlayObject.RecallHuman(m_PlayObject.m_sCharName);
                                nRecallCount++;
                            }
                        }
                        else
                        {
                            nNoRecallCount++;
                            PlayObject.SysMsg(String.Format("{0} 不允许行会合一！！！", m_PlayObject.m_sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
                        }
                    }
                }
            }
            PlayObject.SysMsg(String.Format("已传送{0}个成员，{1}个成员未被传送。", nRecallCount, nNoRecallCount), TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.m_dwGroupRcallTick = HUtil32.GetTickCount();
            PlayObject.m_wGroupRcallTime = (uint)M2Share.g_Config.nGuildRecallTime;
        }
    }
}