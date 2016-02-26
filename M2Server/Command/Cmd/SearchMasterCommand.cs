using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 查询师徒当前所在位置
    /// </summary>
    [GameCommand("SearchMaster", "查询师徒当前所在位置", 100)]
    public class SearchMasterCommand : BaseCommond
    {
        [DefaultCommand]
        public void SearchMaster(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            string sParam = @Params.Length > 0 ? @Params[0] : "";
            TPlayObject Human;
            if ((sParam != "") && (sParam[0] == '?'))
            {
                PlayObject.SysMsg("此命令用于查询师徒当前所在位置。", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_sMasterName == "")
            {
                PlayObject.SysMsg(GameMsgDef.g_sYouAreNotMasterMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_boMaster)
            {
                if (PlayObject.m_MasterList.Count <= 0)
                {
                    PlayObject.SysMsg(GameMsgDef.g_sYourMasterListNotOnlineMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                PlayObject.SysMsg(GameMsgDef.g_sYourMasterListNowLocateMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                for (int I = 0; I < PlayObject.m_MasterList.Count; I++)
                {
                    Human = PlayObject.m_MasterList[I];
                    PlayObject.SysMsg(Human.m_sCharName + " " + Human.m_PEnvir.sMapDesc + "(" + Human.m_nCurrX + ":" + Human.m_nCurrY + ")", TMsgColor.c_Green, TMsgType.t_Hint);
                    Human.SysMsg(GameMsgDef.g_sYourMasterSearchLocateMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                    Human.SysMsg(PlayObject.m_sCharName + " " + PlayObject.m_PEnvir.sMapDesc + "(" + PlayObject.m_nCurrX + ":" + PlayObject.m_nCurrY + ")", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            else
            {
                if (PlayObject.m_MasterHuman == null)
                {
                    PlayObject.SysMsg(GameMsgDef.g_sYourMasterNotOnlineMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                PlayObject.SysMsg(GameMsgDef.g_sYourMasterNowLocateMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(PlayObject.m_MasterHuman.m_sCharName + " " + PlayObject.m_MasterHuman.m_PEnvir.sMapDesc + "(" + PlayObject.m_MasterHuman.m_nCurrX + ":"
                    + PlayObject.m_MasterHuman.m_nCurrY + ")", TMsgColor.c_Green, TMsgType.t_Hint);
                PlayObject.m_MasterHuman.SysMsg(GameMsgDef.g_sYourMasterListSearchLocateMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                PlayObject.m_MasterHuman.SysMsg(PlayObject.m_sCharName + " " + PlayObject.m_PEnvir.sMapDesc + "(" + PlayObject.m_nCurrX + ":" + PlayObject.m_nCurrY + ")", 
                    TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}