using GameFramework;
using GameFramework.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server
{
    /// <summary>
    /// 全局变量脚本处理
    /// </summary>
    public class GrobalVarScript
    {
        /// <summary>
        /// 全局变量消息处理列表
        /// </summary>
        private static Dictionary<int, TProcessGrobalMessage> FProcessGrobalMessage;

        private delegate void TProcessGrobalMessage(TPlayObject PlayObject, string sVariable, ref string sMsg);

        /// <summary>
        /// 初始化全局变量脚本处理列表
        /// </summary>
        public GrobalVarScript()
        {
            FProcessGrobalMessage = new Dictionary<int, TProcessGrobalMessage>();
            //FProcessGrobalMessage[SctiptDef.nVAR_SERVERNAME] = GetServerName;
            //FProcessGrobalMessage[SctiptDef.nVAR_SERVERIP] = GetServerIp;
            //FProcessGrobalMessage[SctiptDef.nVAR_WEBSITE] = GetWebSite;
            //FProcessGrobalMessage[SctiptDef.nVAR_BBSSITE] = GetBbsWeiSite;
            //FProcessGrobalMessage[SctiptDef.nVAR_CLIENTDOWNLOAD] = GetCilentDownLoad;
            //FProcessGrobalMessage[SctiptDef.nVAR_QQ] = GetQQ;
            //FProcessGrobalMessage[SctiptDef.nVAR_PHONE] = GetPhone;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT0] = GetBankAccount0;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT1] = GetBankAccount1;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT2] = GetBankAccount2;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT3] = GetBankAccount3;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT4] = GetBankAccount4;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT5] = GetBankAccount5;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT6] = GetBankAccount6;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT7] = GetBankAccount7;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT8] = GetBankAccount8;
            //FProcessGrobalMessage[SctiptDef.nVAR_BANKACCOUNT9] = GetBankAccount9;
            //FProcessGrobalMessage[SctiptDef.nVAR_GAMEGOLDNAME] = GetGameGoldName;
            //FProcessGrobalMessage[SctiptDef.nVAR_GAMEPOINTNAME] = GetPointName;
            //FProcessGrobalMessage[SctiptDef.nVAR_USERCOUNT] = GetUserCount;
            //FProcessGrobalMessage[SctiptDef.nVAR_DATETIME] = GetDateTime;
            //FProcessGrobalMessage[SctiptDef.nVAR_USERNAME] = GetUserName;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAPNAME] = GetMapName;
            //FProcessGrobalMessage[SctiptDef.nVAR_GUILDNAME] = GetGuilidName;
            //FProcessGrobalMessage[SctiptDef.nVAR_RANKNAME] = GetGuilidRankName;
            //FProcessGrobalMessage[SctiptDef.nVAR_LEVEL] = GetLevel;
            //FProcessGrobalMessage[SctiptDef.nVAR_HP] = GetHP;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXHP] = GetMaxHP;
            //FProcessGrobalMessage[SctiptDef.nVAR_MP] = GetMP;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXMP] = GetMaxHP;
            //FProcessGrobalMessage[SctiptDef.nVAR_AC] = GetAc;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXAC] = GetMaxAc;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAC] = GetMac;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXMAC] = GetMaxMac;
            //FProcessGrobalMessage[SctiptDef.nVAR_DC] = GetDC;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXDC] = GetMaxDC;
            //FProcessGrobalMessage[SctiptDef.nVAR_MC] = GetMc;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXMC] = GetMaxMc;
            //FProcessGrobalMessage[SctiptDef.nVAR_SC] = GetSc;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXSC] = GetMaxSc;
            //FProcessGrobalMessage[SctiptDef.nVAR_EXP] = GetExp;
            //FProcessGrobalMessage[SctiptDef.nVAR_MAXEXP] = GetMaxExp;
            //FProcessGrobalMessage[SctiptDef.nVAR_PKPOINT] = GetPkPoint;
            //FProcessGrobalMessage[SctiptDef.nVAR_CREDITPOINT] = GetCreditPoint;
            //FProcessGrobalMessage[SctiptDef.nVAR_GOLDCOUNT] = GetGoldCount;
            //FProcessGrobalMessage[SctiptDef.nVAR_GAMEGOLD] = GetGameGold;
            //FProcessGrobalMessage[SctiptDef.nVAR_GAMEPOINT] = GetGamePoint;
            //FProcessGrobalMessage[SctiptDef.nVAR_LOGINTIME] = GetLoginTime;
            //FProcessGrobalMessage[SctiptDef.nVAR_LOGINLONG] = GetLoginTime;

            //FProcessGrobalMessage[SctiptDef.nVAR_DRESS] = GetDress;
            //FProcessGrobalMessage[SctiptDef.nVAR_WEAPON] = GetWeapon;
            //FProcessGrobalMessage[SctiptDef.nVAR_RIGHTHAND] = GetRightHand;
            //FProcessGrobalMessage[SctiptDef.nVAR_HELMET] = GetHelmet;
            //FProcessGrobalMessage[SctiptDef.nVAR_NECKLACE] = GetNecklace;
            //FProcessGrobalMessage[SctiptDef.nVAR_RING_R] = GetRing_R;
            //FProcessGrobalMessage[SctiptDef.nVAR_RING_L] = GetRing_L;
            //FProcessGrobalMessage[SctiptDef.nVAR_ARMRING_R] = GetArmring_R;
            //FProcessGrobalMessage[SctiptDef.nVAR_ARMRING_L] = GetArmring_L;
            //FProcessGrobalMessage[SctiptDef.nVAR_BUJUK] = GetBujuk;
            //FProcessGrobalMessage[SctiptDef.nVAR_BELT] = GetBelt;
            //FProcessGrobalMessage[SctiptDef.nVAR_BOOTS] = GetBoots;
            //FProcessGrobalMessage[SctiptDef.nVAR_CHARM] = GetChrm;

            //FProcessGrobalMessage[SctiptDef.nVAR_IPADDR] = GetIpAddr;
            //FProcessGrobalMessage[SctiptDef.nVAR_IPLOCAL] = GetIpLocal;
            //FProcessGrobalMessage[SctiptDef.nVAR_GUILDBUILDPOINT] = GetGuildBuildPoint;
            //FProcessGrobalMessage[SctiptDef.nVAR_GUILDAURAEPOINT] = GetGuildAuraePoint;
            //FProcessGrobalMessage[SctiptDef.nVAR_GUILDSTABILITYPOINT] = GetGuildStabilityPoint;
            //FProcessGrobalMessage[SctiptDef.nVAR_GUILDFLOURISHPOINT] = GetGuildFlourishPoint;
            //FProcessGrobalMessage[SctiptDef.nVAR_REQUESTCASTLEWARITEM] = GetRequestCastlewarItem;
            //FProcessGrobalMessage[SctiptDef.nVAR_REQUESTCASTLEWARDAY] = GetRequestCastleWarday;
            //FProcessGrobalMessage[SctiptDef.nVAR_REQUESTBUILDGUILDITEM] = GetRequestBuildGuildItem;
            //FProcessGrobalMessage[SctiptDef.nVAR_OWNERGUILD] = GetOwnerGuild;
            //FProcessGrobalMessage[SctiptDef.nVAR_CASTLENAME] = GetCastleName;
            //FProcessGrobalMessage[SctiptDef.nVAR_LORD] = GetLord;
            //FProcessGrobalMessage[SctiptDef.nVAR_GUILDWARFEE] = GetGuildWarfee;
            //FProcessGrobalMessage[SctiptDef.nVAR_BUILDGUILDFEE] = GetBuildGuildfee;
            //FProcessGrobalMessage[SctiptDef.nVAR_CASTLEWARDATE] = GetCastleWarDate;
            //FProcessGrobalMessage[SctiptDef.nVAR_LISTOFWAR] = GetListofWar;
            //FProcessGrobalMessage[SctiptDef.nVAR_CASTLECHANGEDATE] = GetCastleChangeDate;
            //FProcessGrobalMessage[SctiptDef.nVAR_CASTLEWARLASTDATE] = GetCastlewarLastDate;
            //FProcessGrobalMessage[SctiptDef.nVAR_CASTLEGETDAYS] = GetCastlegetDays;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_DATE] = GetCmdDate;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_ALLOWMSG] = GetCmdAllowmsg;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_LETSHOUT] = GetCmdletshout;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_LETTRADE] = GetCmdLettrade;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_LETGUILD] = GetCmdLetGuild;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_ENDGUILD] = GetCmdEndGuild;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_BANGUILDCHAT] = GetCmdBanGuildChat;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_AUTHALLY] = GetCmdAuthally;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_AUTH] = GetCmdAuth;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_AUTHCANCEL] = GetCmdAythCcancel;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_USERMOVE] = GetCmdUserMove;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_SEARCHING] = GetCmdSearching;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_ALLOWGROUPCALL] = GetCmdAllowGroupCall;
            //FProcessGrobalMessage[SctiptDef.nVAR_CMD_GROUPRECALLL] = GetCmdGroupCall;
        }

        /// <summary>
        /// 处理脚本
        /// </summary>
        /// <param name="nIdx"></param>
        public static void Hand(TPlayObject PlayObject, int nIdx, string sVariable, ref string sMsg)
        {
            if (FProcessGrobalMessage.ContainsKey(nIdx))
            {
                if (nIdx < FProcessGrobalMessage.Count())
                {
                    FProcessGrobalMessage[nIdx](PlayObject, sVariable, ref sMsg);
                }
                else
                {
                    M2Share.MainOutMessage(string.Format("未知全局变量编号:{0}", nIdx));
                }
            }
        }

        /// <summary>
        /// 取在线人数
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetUserCount(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), Convert.ToString(M2Share.UserEngine.PlayObjectCount));
        }

        /// <summary>
        /// 取服务器名称
        /// </summary>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetServerName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), M2Share.g_Config.sServerName);
        }

        /// <summary>
        /// 取网站地址
        /// </summary>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetWebSite(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), M2Share.g_Config.sWebSite);
        }

        /// <summary>
        /// 取服务器时间
        /// </summary>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetDateTime(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), DateTime.Now.ToString("dddddd,dddd,hh:mm:nn"));
        }

        /// <summary>
        /// 取玩家名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetUserName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PlayObject.m_sCharName);
        }

        /// <summary>
        /// 取行会名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGuilidName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            if (PlayObject.m_MyGuild != null)
            {
                sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), PlayObject.m_MyGuild.sGuildName);
            }
            else
            {
                sMsg = "无";
            }
        }

        /// <summary>
        /// 取玩行会封号名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGuilidRankName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PlayObject.m_sGuildRankName);
        }

        /// <summary>
        /// 查看申请攻城战役行会列表
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetListofWar(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            if (PlayObject.m_Castle != null)
            {
                sMsg = PlayObject.m_Castle.GetAttackWarList();
            }
            else
            {
                sMsg = "????";
            }
            if (sMsg != "")
            {
                sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sMsg);
            }
            else
            {
                sMsg = "现在没有行会申请攻城战\\ \\<返回/@main>";
            }
            return;
        }

        /// <summary>
        /// 取沙巴克行会攻城列表
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCastleWarDate(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            if (PlayObject.m_Castle == null)
            {
                PlayObject.m_Castle = M2Share.g_CastleManager.GetCastle(0);
            }
            if (PlayObject.m_Castle != null)
            {
                if (!PlayObject.m_Castle.m_boUnderWar)
                {
                    sMsg = PlayObject.m_Castle.GetWarDate();
                    if (sMsg != "")
                    {
                        sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sMsg);
                    }
                    else
                    {
                        sMsg = "暂时没有行会攻城！！！\\ \\<返回/@main>";
                    }
                }
                else
                {
                    sMsg = "现正在攻城中！！！\\ \\<返回/@main>";
                }
            }
            else
            {
                sMsg = "????";
            }
        }

        /// <summary>
        /// 取记忆石名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetTargetName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_TargetCret != null)
            {
                sText = PlayObject.m_TargetCret.m_sCharName;
            }
            else
            {
                sText = "";
            }
            sMsg = CombineStr(sMsg, string.Format("<{}>", sVariable), sText);
        }

        /// <summary>
        /// 取记忆石地图名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetTagMapName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //string sText = string.Empty;
            //string s1C = sVariable[sVariable.Length].ToString();
            //Copy(sVariable, Length(sVariable) - 1, 1);
            //long n18 = HUtil32.Str_ToInt(s1C, -1);
            //TRememberItem RememberItem = M2Share.GetRememberItem(PlayObject.m_nRememberItemIndex, n18);
            //if (RememberItem != null)
            //{
            //    if (RememberItem.sMapName != "")
            //    {
            //        TEnvirnoment Envir = M2Share.g_MapManager.FindMap(RememberItem.sMapName);
            //        if (Envir != null)
            //        {
            //            sText = Envir.sMapDesc;
            //        }
            //        else
            //        {
            //            sText = "???";
            //        }
            //    }
            //    else
            //    {
            //        sText = "未记忆";
            //    }
            //}
            //else
            //{
            //    sText = "未记忆";
            //}
            //sMsg = CombineStr(sMsg, "<$TAGMAPNAME" + n18 + '>', sText);
        }

        /// <summary>
        /// 取记忆石X坐标
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetTagX(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            string s1C = sVariable[sVariable.Length].ToString();
            long n18 = HUtil32.Str_ToInt(s1C, -1);
            //TRememberItem RememberItem = M2Share.GetRememberItem(PlayObject.m_nRememberItemIndex, n18);
            //if (RememberItem != null)
            //{
            //    if (RememberItem.sMapName != "")
            //    {
            //        sText = (RememberItem.nCurrX).ToString();
            //    }
            //    else
            //    {
            //        sText = "未记忆";
            //    }
            //}
            //else
            //{
            //    sText = "未记忆";
            //}
            sMsg = CombineStr(sMsg, "<$TAGX" + n18 + '>', sText);
        }

        /// <summary>
        /// 取记忆石Y坐标
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetTagY(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            string s1C = sVariable[sVariable.Length].ToString();
            long n18 = HUtil32.Str_ToInt(s1C, -1);
            //TRememberItem RememberItem = M2Share.GetRememberItem(PlayObject.m_nRememberItemIndex, n18);
            //if (RememberItem != null)
            //{
            //    if (RememberItem.sMapName != "")
            //    {
            //        sText = (RememberItem.nCurrX).ToString();
            //    }
            //    else
            //    {
            //        sText = "未记忆";
            //    }
            //}
            //else
            //{
            //    sText = "未记忆";
            //}
            sMsg = CombineStr(sMsg, "<$TAGY" + n18 + '>', sText);
        }

        /// <summary>
        /// 取交易对像
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetDealGoldPlay(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            var PoseHuman = PlayObject.GetPoseCreate();
            if ((PoseHuman != null) && (PoseHuman.GetPoseCreate() == PlayObject) && (PoseHuman.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
            {
                sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PoseHuman.m_sCharName);
            }
            else
            {
                sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), "????");
            }
        }

        /// <summary>
        /// 取服务器运行时间
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetServerRunTime(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            uint nSecond = HUtil32.GetTickCount() - M2Share.g_dwStartTick / 1000;
            uint wHour = nSecond / 3600;
            uint wMinute = (nSecond / 60) % 60;
            uint wSecond = nSecond % 60;
            string sText = String.Format("{0}:{1}:{2}", wHour, wMinute, wSecond);
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取服务器运行天数
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMacrunTime(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>"), Convert.ToString(HUtil32.GetTickCount() / (24 * 60 * 60 * 1000)));
        }

        /// <summary>
        /// 取最高等级人物信息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHighLevelInfo(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (M2Share.UserEngine.GetPlayObject(M2Share.g_HighLevelHuman) != null)
            {
                sText = M2Share.g_HighLevelHuman.GetMyInfo();
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 最高PK点数人物信息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHighPkInfo(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (M2Share.UserEngine.GetPlayObject(M2Share.g_HighPKPointHuman) != null)
            {
                sText = M2Share.g_HighPKPointHuman.GetMyInfo();
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<0>"), sText);
        }

        /// <summary>
        /// 最高攻击力人物信息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHighDcInfo(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (M2Share.UserEngine.GetPlayObject(M2Share.g_HighDCHuman) != null)
            {
                sText = M2Share.g_HighDCHuman.GetMyInfo();
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 最高魔法力人物信息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHighMcInfo(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (M2Share.UserEngine.GetPlayObject(M2Share.g_HighMCHuman) != null)
            {
                sText = M2Share.g_HighMCHuman.GetMyInfo();
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 最高道术人物信息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHighScInfo(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (M2Share.UserEngine.GetPlayObject(M2Share.g_HighSCHuman) != null)
            {
                sText = M2Share.g_HighSCHuman.GetMyInfo();
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 最高最长在线时间人物信息
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHighOlineInfo(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (M2Share.UserEngine.GetPlayObject(M2Share.g_HighOnlineHuman) != null)
            {
                sText = M2Share.g_HighOnlineHuman.GetMyInfo();
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 取玩家登录时长
        /// </summary>
        internal void GetLoginLong(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = ((HUtil32.GetTickCount() - PlayObject.m_dwLogonTick) / 60000).ToString() + "分钟";
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 取玩家登录时间
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetLoginTime(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), Convert.ToString(PlayObject.m_dLogonTime));
        }

        /// <summary>
        /// 取行会建筑度
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGuildBuildPoint(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_MyGuild == null)
            {
                sText = "无";
            }
            else
            {
                sText = (PlayObject.m_MyGuild.nBuildPoint).ToString();
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 行会人气度
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGuildAuraePoint(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_MyGuild == null)
            {
                sText = "无";
            }
            else
            {
                sText = (PlayObject.m_MyGuild.nAurae).ToString();
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取行会安定度
        /// </summary>
        internal void GetGuildStabilityPoint(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_MyGuild == null)
            {
                sText = "无";
            }
            else
            {
                sText = (PlayObject.m_MyGuild.nStability).ToString();
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取行会繁荣度
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGuildFlourishPoint(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_MyGuild == null)
            {
                sText = "无";
            }
            else
            {
                sText = (PlayObject.m_MyGuild.nFlourishing).ToString();
            }
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 行会最高限制人数
        /// </summary>
        internal void GetGuildMembermaxLimit(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_MyGuild == null)
            {
                sText = "???";
            }
            else
            {
                //sText = (PlayObject.m_MyGuild.m_nMemberMaxLimit).ToString();
            }
            sMsg = CombineStr(sMsg, string.Format("<0>", sVariable), sText);
        }

        /// <summary>
        /// 取攻城需要的物品
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetRequestCastlewarItem(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), M2Share.g_Config.sZumaPiece);
        }

        /// <summary>
        /// 取城保所属行会
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetOwnerGuild(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_Castle != null)
            {
                sText = PlayObject.m_Castle.m_sOwnGuild;
                if (sText == "")
                {
                    sText = "游戏管理";
                }
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取城堡名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCastleName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_Castle != null)
            {
                sText = PlayObject.m_Castle.m_sName;
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>"), sText);

        }

        /// <summary>
        /// 城堡所属行会的老大
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetLord(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_Castle != null)
            {
                if (PlayObject.m_Castle.m_MasterGuild != null)
                {
                    sText = PlayObject.m_Castle.m_MasterGuild.GetChiefName();
                }
                else
                {
                    sText = "管理员";
                }
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取沙巴克占领日期
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCastleChangeDate(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_Castle != null)
            {
                sText = Convert.ToString(PlayObject.m_Castle.m_ChangeDate);
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 最好一次攻城战役日期
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCastlewarLastDate(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_Castle != null)
            {
                sText = Convert.ToString(PlayObject.m_Castle.m_WarDate);
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>"), sText);
        }

        /// <summary>
        /// 沙巴克占领天数
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCastlegetDays(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = string.Empty;
            if (PlayObject.m_Castle != null)
            {
                sText = (HUtil32.GetDayCount(DateTime.Now, PlayObject.m_Castle.m_ChangeDate)).ToString();
            }
            else
            {
                sText = "????";
            }
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取挖取物品名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetButchItemName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //if (PlayObject.m_sButchItem == "")
            //{
            //    sMsg = "????";
            //}
            //else
            //{
            //    sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PlayObject.m_sButchItem);
            //}
        }

        /// <summary>
        /// 取宝箱名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBoxName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //if (PlayObject.m_SuperItemBox == null)
            //{
            //    sMsg = "????";
            //}
            //else
            //{
            //    sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PlayObject.m_SuperItemBox.sOpenBoxName);
            //}
        }

        /// <summary>
        /// 取宝箱物品名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBoxItemName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //if (PlayObject.m_SuperItemBox == null)
            //{
            //    sMsg = "????";
            //}
            //else
            //{
            //    sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PlayObject.m_SuperItemBox.sItemName);
            //}
        }

        /// <summary>
        /// 取地图名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMapName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PlayObject.m_PEnvir.sMapDesc);
        }

        /// <summary>
        /// 取地图文件名
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMapFileName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), PlayObject.m_PEnvir.sMapName);
        }

        /// <summary>
        /// 取当前对象等级
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetLevel(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_Abil.Level).ToString();
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取当前对象血量
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHP(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = Convert.ToString(PlayObject.m_WAbil.HP);
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取当前对象最大血量
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxHP(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.MaxHP).ToString();
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取当前对象魔法值
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMP(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.MP).ToString();
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取当前对象最大魔法值
        /// </summary>
        internal void GetMaxMP(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.MaxMP).ToString();
            sMsg = CombineStr(sMsg, string.Format("<{0}>", sVariable), sText);
        }

        /// <summary>
        /// 取当前对象攻击力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetDC(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.LoWord(PlayObject.m_WAbil.DC)).ToString();
            sMsg = CombineStr(sMsg, "<$DC>", sText);
        }

        /// <summary>
        /// 取当前对象最大攻击力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxDC(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.HiWord(PlayObject.m_WAbil.DC)).ToString();
            sMsg = CombineStr(sMsg, "<$MAXDC>", sText);
        }

        /// <summary>
        /// 取当前对象魔法防御
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMac(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.LoWord(PlayObject.m_WAbil.MAC)).ToString();
            sMsg = CombineStr(sMsg, "<$MAC>", sText);
        }

        /// <summary>
        /// 取当前对象魔法力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMc(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.LoWord(PlayObject.m_WAbil.MC)).ToString();
            sMsg = CombineStr(sMsg, "<$MC>", sText);
        }

        /// <summary>
        /// 取当前对象最大魔法力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxMc(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.HiWord(PlayObject.m_WAbil.MC)).ToString();
            sMsg = CombineStr(sMsg, "<$MAXMC>", sText);
        }

        /// <summary>
        /// 取当前对象道术力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetSc(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.LoWord(PlayObject.m_WAbil.SC)).ToString();
            sMsg = CombineStr(sMsg, "<$SC>", sText);
        }

        /// <summary>
        /// 取当前对象最大道术力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxSc(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.HiWord(PlayObject.m_WAbil.SC)).ToString();
            sMsg = CombineStr(sMsg, "<$MAXSC>", sText);
        }

        /// <summary>
        /// 取当前对象经验值
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetExp(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_Abil.Exp).ToString();
            sMsg = CombineStr(sMsg, "<$EXP>", sText);
        }

        /// <summary>
        /// 最当前对象最大经验值
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxExp(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_Abil.MaxExp).ToString();
            sMsg = CombineStr(sMsg, "<$MAXEXP>", sText);
        }

        /// <summary>
        /// 取当前最新最大魔法防御力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxMac(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.HiWord(PlayObject.m_WAbil.MAC)).ToString();
            sMsg = CombineStr(sMsg, "<$MAXMAC>", sText);
        }

        /// <summary>
        /// 取当前对象最大防御值
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxAc(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (HUtil32.HiWord(PlayObject.m_WAbil.AC)).ToString();
            sMsg = CombineStr(sMsg, "<$MAXAC>", sText);
        }

        /// <summary>
        /// 取当前对象负重力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHw(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.HandWeight).ToString();
            sMsg = CombineStr(sMsg, "<$HW>", sText);
        }

        /// <summary>
        /// 取当前对象防御
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetAc(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
           string sText = (HUtil32.LoWord(PlayObject.m_WAbil.AC)).ToString();
            sMsg = CombineStr(sMsg, "<$AC>", sText);
        }

        /// <summary>
        /// 取当前对象最大负重力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxHw(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.MaxHandWeight).ToString();
            sMsg = CombineStr(sMsg, "<$MAXHW>", sText);
        }

        /// <summary>
        /// 取当前对象腕力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetWW(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.WearWeight).ToString();
            sMsg = CombineStr(sMsg, "<$WW>", sText);
        }

        /// <summary>
        /// 取当前对象最大腕力
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxWW(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.MaxWearWeight).ToString();
            sMsg = CombineStr(sMsg, "<$MAXWW>", sText);
        }

        /// <summary>
        /// 取当前对象包裹重量
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBw(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.Weight).ToString();
            sMsg = CombineStr(sMsg, "<$BW>", sText);
        }

        /// <summary>
        /// 取当前对象包裹最大重量
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMaxBw(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_WAbil.MaxWeight).ToString();
            sMsg = CombineStr(sMsg, "<$MAXBW>", sText);
        }

        /// <summary>
        /// 取当前对象怪物经验值
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetMonExp(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "";
            //string sText = (PlayObject.m_nGetMonExp).ToString();
            //sMsg = CombineStr(sMsg, "<$MONEXP>", sText);
        }

        /// <summary>
        /// 取当前对象PK点
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetPkPoint(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_nPkPoint).ToString();
            sMsg = CombineStr(sMsg, "<$PKPOINT>", sText);
        }

        /// <summary>
        /// 取当前对象金币数量
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGoldCount(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_nGold).ToString() + '/' + (PlayObject.m_nGoldMax).ToString();
            sMsg = CombineStr(sMsg, "<$GOLDCOUNT>", sText);
        }

        /// <summary>
        /// 取当前对象金币数量
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGameGold(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_nGameGold).ToString();
            sMsg = CombineStr(sMsg, "<$GAMEGOLD>", sText);
        }

        /// <summary>
        /// 取当前对象声望点
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGamePoint(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_nGamePoint).ToString();
            sMsg = CombineStr(sMsg, "<$GAMEPOINT>", sText);
        }

        /// <summary>
        /// 当前对象声望点数
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCreditPoint(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_btCreditPoint).ToString();
            sMsg = CombineStr(sMsg, "<$CREDITPOINT>", sText);
        }

        /// <summary>
        /// 取金币名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGameGoldName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$GAMEGOLDNAME>", M2Share.g_Config.sGameGoldName);
        }

        /// <summary>
        /// 取当前对象饥饿程度
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetHunGer(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.GetMyStatus()).ToString();
            sMsg = CombineStr(sMsg, "<$HUNGER>", sText);
        }

        /// <summary>
        /// 取当前对象所在地图X坐标
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCurrX(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_nCurrX).ToString();
            sMsg = CombineStr(sMsg, "<$CURRX>", sText);
        }

        /// <summary>
        /// 取当前对象所在地图X坐标
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCurrY(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = (PlayObject.m_nCurrY).ToString();
            sMsg = CombineStr(sMsg, "<$CURRX>", sText);
        }

        /// <summary>
        /// 取声望点名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetPointName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$GAMEPOINTNAME>", M2Share.g_Config.sGamePointName);
        }

        /// <summary>
        /// 取当前对象所在IP地址
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetIpAddr(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$IPADDR>", PlayObject.m_sIPaddr);
        }

        /// <summary>
        /// 取当前对象所在区域
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetIpLocal(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = PlayObject.m_sIPLocal;

            // GetIPLocal(PlayObject.m_sIPaddr);
            sMsg = CombineStr(sMsg, "<$IPLOCAL>", sText);
        }

        /// <summary>
        /// 行会战金币数
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetGuildWarfee(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$GUILDWARFEE>", (M2Share.g_Config.nGuildWarPrice).ToString());
        }
        
        /// <summary>
        /// 建立行会所需的金币数
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBuildGuildfee(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BUILDGUILDFEE>", (M2Share.g_Config.nBuildGuildPrice).ToString());
        }

        /// <summary>
        /// 允许建立行会的物品名字
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetRequestBuildGuildItem(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$REQUESTBUILDGUILDITEM>", M2Share.g_Config.sWomaHorn);
        }
        
        /// <summary>
        /// 多少天后攻城
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetRequestCastleWarday(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$REQUESTCASTLEWARDAY>", M2Share.g_Config.sZumaPiece);
        }

        /// <summary>
        /// 取日期命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdDate(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_DATE>", M2Share.g_GameCommand.Data.sCmd);
        }

        /// <summary>
        /// 查看接收所有消息命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdAllowmsg(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_ALLOWMSG>", M2Share.g_GameCommand.ALLOWMSG.sCmd);
        }

        /// <summary>
        /// 查看允许群聊命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdletshout(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_LETSHOUT>", M2Share.g_GameCommand.LETSHOUT.sCmd);
        }

        /// <summary>
        /// 查看允许交易命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdLettrade(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_LETTRADE>", M2Share.g_GameCommand.LETTRADE.sCmd);
        }

        /// <summary>
        /// 查看允许加入门派命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdLetGuild(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_LETGUILD>", M2Share.g_GameCommand.LETGUILD.sCmd);
        }

        /// <summary>
        /// 查看退出门派命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdEndGuild(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_ENDGUILD>", M2Share.g_GameCommand.ENDGUILD.sCmd);
        }

        /// <summary>
        /// 查看允许行会聊天命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdBanGuildChat(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_BANGUILDCHAT>", M2Share.g_GameCommand.BANGUILDCHAT.sCmd);
        }

        /// <summary>
        /// 查看允许行会联盟命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdAuthally(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_AUTHALLY>", M2Share.g_GameCommand.AUTHALLY.sCmd);
        }

        /// <summary>
        /// 查看行会联盟命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdAuth(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_AUTH>", M2Share.g_GameCommand.AUTH.sCmd);
        }

        /// <summary>
        /// 查看取消行会联盟命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdAythCcancel(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_AUTHCANCEL>", M2Share.g_GameCommand.AUTHCANCEL.sCmd);
        }

        /// <summary>
        /// 查看传送戒指命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdUserMove(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_USERMOVE>", M2Share.g_GameCommand.USERMOVE.sCmd);
        }

        /// <summary>
        /// 查看探测项链命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdSearching(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_SEARCHING>", M2Share.g_GameCommand.SEARCHING.sCmd);
        }

        /// <summary>
        /// 查看组队传送命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdGroupCall(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_GROUPRECALLL>", M2Share.g_GameCommand.GROUPRECALLL.sCmd);
        }

        /// <summary>
        /// 查看允许组队传送命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdAllowGroupCall(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_ALLOWGROUPCALL>", M2Share.g_GameCommand.ALLOWGROUPCALL.sCmd);
        }

        /// <summary>
        /// 查看更改仓库密码命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdStorageChgPassword(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_STORAGECHGPASSWORD>", M2Share.g_GameCommand.CHGPASSWORD.sCmd);
        }

        /// <summary>
        /// 为仓库设定一个4-7位数长的仓库密码命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdStorageSetPassword(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_STORAGESETPASSWORD>", M2Share.g_GameCommand.SETPASSWORD.sCmd);
        }

        /// <summary>
        /// 可将仓库锁定命令
        /// </summary>
        internal void GetCmdStorageLock(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_STORAGELOCK>", M2Share.g_GameCommand.__Lock.sCmd);
        }

        /// <summary>
        /// 开启仓库命令
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCmdStorageUnlock(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CMD_STORAGEUNLOCK>", M2Share.g_GameCommand.UNLOCKSTORAGE.sCmd);
        }

        /// <summary>
        /// 取当前对象武器名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetWeapon(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_WEAPON]->wIndex);
            sMsg = CombineStr(sMsg, "<$WEAPON>", sText);
        }

        /// <summary>
        /// 取当前对象衣服名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetDress(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_DRESS]->wIndex);
            sMsg = CombineStr(sMsg, "<$DRESS>", sText);
        }

        /// <summary>
        /// 取当前对象蜡烛名称(勋章)
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetRightHand(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_RIGHTHAND]->wIndex);
            sMsg = CombineStr(sMsg, "<$RIGHTHAND>", sText);
        }

        /// <summary>
        /// 取当前对象头盔名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetHelmet(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_HELMET]->wIndex);
            sMsg = CombineStr(sMsg, "<$HELMET>", sText);
        }

        /// <summary>
        /// 取当前对象项链名称
        /// </summary>
        internal unsafe void GetNecklace(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_NECKLACE]->wIndex);
            sMsg = CombineStr(sMsg, "<$NECKLACE>", sText);
        }

        /// <summary>
        /// 取当前对象右戒指名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetRing_R(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_RINGR]->wIndex);
            sMsg = CombineStr(sMsg, "<$RING_R>", sText);
        }

        /// <summary>
        /// 取当前对象左戒指名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetRing_L(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_RINGL]->wIndex);
            sMsg = CombineStr(sMsg, "<$RING_L>", sText);
        }

        /// <summary>
        /// 取当前对象右手镯名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetArmring_R(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_ARMRINGR]->wIndex);
            sMsg = CombineStr(sMsg, "<$ARMRING_R>", sText);
        }

        /// <summary>
        /// 取当前对象左手镯名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetArmring_L(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
            sMsg = CombineStr(sMsg, "<$ARMRING_L>", sText);
        }

        /// <summary>
        /// 取当前对象护身符名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetBujuk(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_BUJUK]->wIndex);
            sMsg = CombineStr(sMsg, "<$BUJUK>", sText);
        }

        /// <summary>
        /// 取当前对象腰带名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetBelt(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_BELT]->wIndex);
            sMsg = CombineStr(sMsg, "<$BELT>", sText);
        }

        /// <summary>
        /// 取当前对象鞋子名称 
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetBoots(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_BOOTS]->wIndex);
            sMsg = CombineStr(sMsg, "<$BOOTS>", sText);
        }

        /// <summary>
        /// 取当前对象宝石名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal unsafe void GetChrm(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            string sText = M2Share.UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_CHARM]->wIndex);
            sMsg = CombineStr(sMsg, "<$CHARM>", sText);
        }

        /// <summary>
        /// 取客服QQ
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetQQ(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$QQ>", M2Share.g_Config.sQQ);
        }

        /// <summary>
        /// 取客服手机号码
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetPhone(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$PHONE>", M2Share.g_Config.sPhone);
        }

        /// <summary>
        /// 取服务器IP
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetServerIp(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$SERVERIP>", M2Share.g_Config.sServerIPaddr);
        }

        /// <summary>
        /// 取论坛地址
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBbsWeiSite(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BBSSITE>", M2Share.g_Config.sBbsSite);
        }

        /// <summary>
        /// 取客户端下载地址
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetCilentDownLoad(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$CLIENTDOWNLOAD>", M2Share.g_Config.sClientDownload);
        }

        /// <summary>
        /// 取掉落物品名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetScatterItemName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //string sText = PlayObject.m_sScatterItemName;
            //sMsg = CombineStr(sMsg, "<$SCATTERITEMNAME>", sText);
        }

        /// <summary>
        /// 取物品掉落拥有者名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetScatterItemownerName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //string sText = PlayObject.m_sScatterItemOwnerName;
            //sMsg = CombineStr(sMsg, "<$SCATTERITEMOWNERNAME>", sText);
        }

        /// <summary>
        /// 取暴物品所在地图文件名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetScatterItemMapName(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //string sText = PlayObject.m_sScatterItemMapName;
            //sMsg = CombineStr(sMsg, "<$SCATTERITEMMAPNAME>", sText);
        }

        /// <summary>
        /// 取物品掉落地图名称
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetScatterItemMapDesc(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //string sText = PlayObject.m_sScatterItemMapDesc;
            //sMsg = CombineStr(sMsg, "<$SCATTERITEMMAPDESC>", sText);
        }

        /// <summary>
        /// 取物品掉落所在地图X坐标
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetScatterItemX(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //string sText = (PlayObject.m_nScatterItemX).ToString();
            //sMsg = CombineStr(sMsg, "<$SCATTERITEMX>", sText);
        }

        /// <summary>
        /// 取物品掉落所在地图Y坐标
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetScatterItemY(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = "????";
            //string sText = (PlayObject.m_nScatterItemY).ToString();
            //sMsg = CombineStr(sMsg, "<$SCATTERITEMX>", sText);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount0(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount0);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount1(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount1);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount2(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount2);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount3(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount3);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount4(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount4);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount5(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount5);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount6(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount6);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount7(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount7);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount8(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount8);
        }

        /// <summary>
        /// 取银行帐号
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sVariable"></param>
        /// <param name="sMsg"></param>
        internal void GetBankAccount9(TPlayObject PlayObject, string sVariable, ref string sMsg)
        {
            sMsg = CombineStr(sMsg, "<$BANKACCOUNT0>", M2Share.g_Config.sBankAccount9);
        }

        /// <summary>
        /// 合并字符串
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="sStr"></param>
        /// <param name="sText"></param>
        /// <returns></returns>
        internal string CombineStr(string sMsg, string sStr, string sText)
        {
            string result;
            string s14;
            string s18;
            int n10 = sMsg.IndexOf(sStr);
            if (n10 > -1)
            {
                s14 = sMsg.Substring(1 - 1, n10);
                s18 = sMsg.Substring(sStr.Length + n10, sMsg.Length - (sStr.Length + n10));
                result = s14 + sText + s18;
            }
            else
            {
                result = sMsg;
            }
            return result;
        }
    }
}