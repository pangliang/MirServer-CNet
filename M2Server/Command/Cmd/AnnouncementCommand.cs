using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 查看行会争霸赛结果
    /// </summary>
    [GameCommand("Announcement", "查看行会争霸赛结果", 10)]
    public class AnnouncementCommand : BaseCommond
    {
        [DefaultCommand]
        public void Announcement(TPlayObject PlayObject,string[] @Params)
        {
            string sGuildName = @Params.Length > 0 ? @Params[0] : "";
            TGUild Guild;
            string sHumanName;
            int nPoint;
            if ((sGuildName == "") || ((sGuildName != "") && (sGuildName[0] == '?')))
            {
                PlayObject.SysMsg("查看行会争霸赛结果。", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(String.Format("命令格式: @{0} 行会名称", this.Attributes.Name), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (!PlayObject.m_PEnvir.m_boFight3Zone)
            {
                PlayObject.SysMsg("此命令不能在当前地图中使用！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            Guild = GuildManager.FindGuild(sGuildName);
            if (Guild != null)
            {
                UserEngine.CryCry(Grobal2.RM_CRY, PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 1000, M2Share.g_Config.btCryMsgFColor,
                    M2Share.g_Config.btCryMsgBColor, String.Format(" - {0} 行会争霸赛结果: ", Guild.sGuildName));
                for (int I = 0; I < Guild.TeamFightDeadList.Count; I++)
                {
                    nPoint = Parse(Guild.TeamFightDeadList[I]);
                    sHumanName = Guild.TeamFightDeadList[I];
                    UserEngine.CryCry(Grobal2.RM_CRY, PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 1000,
                        M2Share.g_Config.btCryMsgFColor, M2Share.g_Config.btCryMsgBColor, String.Format(" - {0}  : {1} 分/死亡{2}次。 ",
                        sHumanName, HUtil32.HiWord(nPoint), HUtil32.LoWord(nPoint)));
                }
            }
            UserEngine.CryCry(Grobal2.RM_CRY, PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 1000,
                M2Share.g_Config.btCryMsgFColor, M2Share.g_Config.btCryMsgBColor, String.Format(" - [{0}] : {1} 分。", Guild.sGuildName, Guild.nContestPoint));
            UserEngine.CryCry(Grobal2.RM_CRY, PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 1000,
                M2Share.g_Config.btCryMsgFColor, M2Share.g_Config.btCryMsgBColor, "------------------------------------");
        }
    }
}