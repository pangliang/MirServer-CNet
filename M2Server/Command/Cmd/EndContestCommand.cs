using GameFramework;
using GameFramework.Command;
using System;
using System.Collections;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 结束行会争霸赛
    /// </summary>
    [GameCommand("EndContest", "结束行会争霸赛", 10)]
    public class EndContestCommand : BaseCommond
    {
        [DefaultCommand]
        public void EndContest(TPlayObject PlayObject,string[] @Params)
        {
            string sParam1 = @Params.Length > 0 ? @Params[0] : "";
            List<TPlayObject> List10;
            ArrayList List14;
            TPlayObject m_PlayObject;
            TPlayObject PlayObjectA;
            bool bo19;
            string s20;
            TGUild Guild;
            if (((sParam1 != "") && (sParam1[0] == '?')))
            {
                PlayObject.SysMsg("结束行会争霸赛。", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(String.Format("命令格式: @{0}", this.Attributes.Name), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (!PlayObject.m_PEnvir.m_boFight3Zone)
            {
                PlayObject.SysMsg("此命令不能在当前地图中使用！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            List10 = new List<TPlayObject>();
            List14 = new ArrayList();
            UserEngine.GetMapRageHuman(PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 1000, List10);
            for (int I = 0; I < List10.Count; I++)
            {
                m_PlayObject = List10[I];
                if (!m_PlayObject.m_boObMode || !m_PlayObject.m_boAdminMode)
                {
                    if (m_PlayObject.m_MyGuild == null)
                    {
                        continue;
                    }
                    bo19 = false;
                    for (int II = 0; II < List14.Count; II++)
                    {
                        PlayObjectA = ((List14[II]) as TPlayObject);
                        if (m_PlayObject.m_MyGuild == PlayObjectA.m_MyGuild)
                        {
                            bo19 = true;
                        }
                    }
                    if (!bo19)
                    {
                        List14.Add(m_PlayObject.m_MyGuild);
                    }
                }
            }
            for (int I = 0; I < List14.Count; I++)
            {
                Guild = ((TGUild)(List14[I]));
                Guild.EndTeamFight();
                UserEngine.CryCry(Grobal2.RM_CRY, PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 1000, M2Share.g_Config.btCryMsgFColor,
                    M2Share.g_Config.btCryMsgBColor, String.Format(" - {0} 行会争霸赛已结束。", Guild.sGuildName));
            }
            HUtil32.Dispose(List10);
            HUtil32.Dispose(List14);
        }
    }
}