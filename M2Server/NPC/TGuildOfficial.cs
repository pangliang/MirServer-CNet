using GameFramework;
using M2Server.ScriptSystem;
/*
 * 名称：TGuildOfficial
 * 创建人：John
 * 创建时间：2012-3-6 9:36:26
 * 描述:
 *********************************************
*/
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 行会NPC单元类
    /// </summary>
    public class TGuildOfficial : TNormNpc
    {
        public override void Click(TPlayObject PlayObject)
        {
            base.Click(PlayObject);
        }

        public override void GetVariableText(TPlayObject PlayObject, ref string sMsg, string sVariable)
        {
            string sText;
            List<string> List;
            string sStr;
            int II;
            base.GetVariableText(PlayObject, ref sMsg, sVariable);
            try
            {
                if (sVariable == "$REQUESTCASTLELIST")
                {
                    sText = "";
                    List = new List<string>();
                    M2Share.g_CastleManager.GetCastleNameList(List);
                    if (List.Count > 0)
                    {
                        for (int I = 0; I < List.Count; I++)
                        {
                            II = I + 1;
                            if (((II / 2) * 2 == II))
                            {
                                sStr = "\\";
                            }
                            else
                            {
                                sStr = "";
                            }
                            sText = sText + string.Format("<%s/@requestcastlewarnow%d> %s", List[I], I, sStr);
                        }
                    }
                    sText = sText + "\\ \\";
                    Dispose(List);
                    sMsg = this.sub_49ADB8(sMsg, "<$REQUESTCASTLELIST>", sText);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildOfficial.GetVariableText");
            }
        }

        public override void Run()
        {
            if (HUtil32.Random(40) == 0)
            {
                this.TurnTo(HUtil32.Random(8));
            }
            else
            {
                if (HUtil32.Random(30) == 0)
                {
                    this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                }
            }
            base.Run();
        }

        public override void UserSelect(TPlayObject PlayObject, string sData)
        {
            string sMsg = string.Empty;
            string sLabel = string.Empty;
            bool boCanJmp;
            byte nCode;
            const string sExceptionMsg = "{异常} TGuildOfficial:UserSelect Code:";
            base.UserSelect(PlayObject, sData);
            nCode = 0;
            try
            {
                if ((sData != "") && (sData[0] == '@'))
                {
                    nCode = 1;
                    sMsg = HUtil32.GetValidStr3(sData, ref sLabel, new string[] { "\r" });
                    nCode = 2;
                    boCanJmp = PlayObject.LableIsCanJmp(sLabel);
                    nCode = 3;
                    this.GotoLable(PlayObject, sLabel, !boCanJmp);
                    // GotoLable(PlayObject,sLabel,not PlayObject.LableIsCanJmp(sLabel));
                    if (!boCanJmp)
                    {
                        return;
                    }
                    if ((sLabel).ToLower().CompareTo((FunctionDef.sBUILDGUILDNOW).ToLower()) == 0)
                    {
                        nCode = 4;
                        ReQuestBuildGuild(PlayObject, sMsg);
                    }
                    else if ((sLabel).ToLower().CompareTo((FunctionDef.sSCL_GUILDWAR).ToLower()) == 0)
                    {
                        nCode = 5;
                        ReQuestGuildWar(PlayObject, sMsg);
                    }
                    else if ((sLabel).ToLower().CompareTo((FunctionDef.sDONATE).ToLower()) == 0)
                    {
                        nCode = 6;
                        DoNate(PlayObject);
                    }
                    else if (HUtil32.CompareLStr(sLabel, FunctionDef.sREQUESTCASTLEWAR, 20))
                    {
                        nCode = 7;
                        ReQuestCastleWar(PlayObject, sLabel.Substring(21 - 1, sLabel.Length - 20));
                    }
                    else if ((sLabel).ToLower().CompareTo((FunctionDef.sEXIT).ToLower()) == 0)
                    {
                        nCode = 8;
                        PlayObject.SendMsg(this, Grobal2.RM_MERCHANTDLGCLOSE, 0, Parse(this), 0, 0, "");
                    }
                    else if ((sLabel).ToLower().CompareTo((FunctionDef.sBACK).ToLower()) == 0)
                    {
                        nCode = 9;
                        if (PlayObject.m_sScriptGoBackLable == "")
                        {
                            PlayObject.m_sScriptGoBackLable = FunctionDef.sMAIN;
                        }
                        this.GotoLable(PlayObject, PlayObject.m_sScriptGoBackLable, false);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg + sLabel + (nCode).ToString());
            }
        }
        
        /// <summary>
        /// 建立行会
        /// </summary>
        /// <param name="PlayObject">对象</param>
        /// <param name="sGuildName">名称</param>
        /// <returns></returns>
        private unsafe int ReQuestBuildGuild(TPlayObject PlayObject, string sGuildName)
        {
            int result = 0;
            TUserItem* UserItem = null;
            try
            {
                result = 0;
                sGuildName = sGuildName.Trim();
                if (sGuildName == "")
                {
                    result = -4;
                }
                if (PlayObject.m_MyGuild == null)
                {
                    if (PlayObject.m_nGold >= M2Share.g_Config.nBuildGuildPrice)
                    {
                        UserItem = PlayObject.CheckItems(M2Share.g_Config.sWomaHorn);//检查包裹是否有所需物品
                        if (UserItem == null)
                        {
                            result = -3;// '你没有准备好需要的全部物品。'
                        }
                    }
                    else
                    {
                        result = -2;// '缺少创建费用。'
                    }
                }
                else
                {
                    result = -1;// '您已经加入其它行会。'
                }
                if (result == 0)
                {
                    if (GuildManager.AddGuild(sGuildName, PlayObject.m_sCharName))
                    {
                        UserEngine.SendServerGroupMsg(Grobal2.SS_205, M2Share.nServerIndex, sGuildName + "/" + PlayObject.m_sCharName);
                        PlayObject.SendDelItems(UserItem);
                        PlayObject.DelBagItem(UserItem->MakeIndex, M2Share.g_Config.sWomaHorn);
                        PlayObject.DecGold(M2Share.g_Config.nBuildGuildPrice);
                        PlayObject.GoldChanged();
                        PlayObject.m_MyGuild = GuildManager.MemberOfGuild(PlayObject.m_sCharName);
                        if (PlayObject.m_MyGuild != null)
                        {
                            PlayObject.m_sGuildRankName = PlayObject.m_MyGuild.GetRankName(PlayObject, ref PlayObject.m_nGuildRankNo);
                            this.RefShowName();
                        }
                    }
                    else
                    {
                        result = -4;
                    }
                }
                if (result >= 0)
                {
                    PlayObject.SendMsg(this, Grobal2.RM_BUILDGUILD_OK, 0, 0, 0, 0, "");
                }
                else
                {
                    PlayObject.SendMsg(this, Grobal2.RM_BUILDGUILD_FAIL, 0, result, 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildOfficial.ReQuestBuildGuild");
            }
            return result;
        }

        /// <summary>
        /// 申请开启行会战
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sGuildName"></param>
        /// <returns></returns>
        private int ReQuestGuildWar(TPlayObject PlayObject, string sGuildName)
        {
            int result = 0;
            try
            {
                if (GuildManager.FindGuild(sGuildName) != null)
                {
                    if (PlayObject.m_nGold >= M2Share.g_Config.nGuildWarPrice)
                    {
                        PlayObject.DecGold(M2Share.g_Config.nGuildWarPrice);
                        PlayObject.GoldChanged();
                        PlayObject.ReQuestGuildWar(sGuildName);
                    }
                    else
                    {
                        PlayObject.SysMsg("您没有足够的金币！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("行会 " + sGuildName + " 不存在！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                result = 1;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildOfficial.ReQuestGuildWar");
            }
            return result;
        }

        private void DoNate(TPlayObject PlayObject)
        {
            PlayObject.SendMsg(this, Grobal2.RM_DONATE_OK, 0, 0, 0, 0, "");
        }

        private unsafe void ReQuestCastleWar(TPlayObject PlayObject, string sIndex)
        {
            TUserItem* UserItem;
            TUserCastle Castle;
            int nIndex;
            try
            {
                nIndex = HUtil32.Str_ToInt(sIndex, -1);
                if (nIndex < 0)
                {
                    nIndex = 0;
                }
                Castle = M2Share.g_CastleManager.GetCastle(nIndex);
                if (PlayObject.IsGuildMaster() && !Castle.IsMember(PlayObject))
                {
                    UserItem = PlayObject.CheckItems(M2Share.g_Config.sZumaPiece);
                    if (UserItem != null)
                    {
                        if (Castle.AddAttackerInfo(PlayObject.m_MyGuild, 0))
                        {
                            PlayObject.SendDelItems(UserItem);
                            PlayObject.DelBagItem(UserItem->MakeIndex, M2Share.g_Config.sZumaPiece);
                            this.GotoLable(PlayObject, "~@request_ok", false);
                        }
                        else
                        {
                            PlayObject.SysMsg("您现在无法请求攻城！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        PlayObject.SysMsg("您没有" + M2Share.g_Config.sZumaPiece + "！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("您的请求被取消！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildOfficial.ReQuestCastleWar");
            }
        }

        public TGuildOfficial()
            : base()
        {
            this.m_btRaceImg = Grobal2.RCC_MERCHANT;
            this.m_wAppr = 8;
        }

        public override void SendCustemMsg(TPlayObject PlayObject, string sMsg)
        {
            base.SendCustemMsg(PlayObject, sMsg);
        }

    }
}