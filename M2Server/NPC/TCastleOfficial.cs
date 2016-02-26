/*
 * 名称：TCastleOfficial
 * 创建人：John
 * 创建时间：2012-3-6 9:36:48
 * 描述:沙巴克城堡NPC功能实现类
 *********************************************
*/
using GameFramework;
using M2Server.ScriptSystem;

namespace M2Server
{
    /// <summary>
    /// 沙城NPC单元类
    /// </summary>
    public class TCastleOfficial : TMerchant
    {
        public override void Click(TPlayObject PlayObject)
        {
            try
            {
                if (this.m_Castle == null)
                {
                    PlayObject.SysMsg("NPC不属于城堡！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (this.m_Castle.IsMasterGuild(PlayObject.m_MyGuild) || (PlayObject.m_btPermission >= 3))
                {
                    base.Click(PlayObject);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCastleOfficial.Click");
            }
        }

        public override void GetVariableText(TPlayObject PlayObject, ref string sMsg, string sVariable)
        {
            string sText;
            TCastleDoor CastleDoor;
            try
            {
                base.GetVariableText(PlayObject, ref sMsg, sVariable);
                if (this.m_Castle == null)
                {
                    sMsg = "????";
                    return;
                }
                if (sVariable == "$CASTLEGOLD")
                {
                    sText = this.m_Castle.m_nTotalGold.ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$CASTLEGOLD>", sText);
                }
                else if (sVariable == "$TODAYINCOME")
                {
                    sText = this.m_Castle.m_nTodayIncome.ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$TODAYINCOME>", sText);
                }
                else if (sVariable == "$CASTLEDOORSTATE")
                {
                    CastleDoor = ((TCastleDoor)this.m_Castle.m_MainDoor.BaseObject);
                    if (CastleDoor.m_boDeath)
                    {
                        sText = "损坏";
                    }
                    else if (CastleDoor.m_boOpened)
                    {
                        sText = "开启";
                    }
                    else
                    {
                        sText = "关闭";
                    }
                    sMsg = this.sub_49ADB8(sMsg, "<$CASTLEDOORSTATE>", sText);
                }
                else if (sVariable == "$REPAIRDOORGOLD")
                {
                    sText = (M2Share.g_Config.nRepairDoorPrice).ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$REPAIRDOORGOLD>", sText);
                }
                else if (sVariable == "$REPAIRWALLGOLD")
                {
                    sText = (M2Share.g_Config.nRepairWallPrice).ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$REPAIRWALLGOLD>", sText);
                }
                else if (sVariable == "$GUARDFEE")
                {
                    sText = (M2Share.g_Config.nHireGuardPrice).ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$GUARDFEE>", sText);
                }
                else if (sVariable == "$ARCHERFEE")
                {
                    sText = (M2Share.g_Config.nHireArcherPrice).ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$ARCHERFEE>", sText);
                }
                else if (sVariable == "$GUARDRULE")
                {
                    sText = "无效";
                    sMsg = this.sub_49ADB8(sMsg, "<$GUARDRULE>", sText);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCastleOfficial.GetVariableText");
            }
        }

        public override void UserSelect(TPlayObject PlayObject, string sData)
        {
            string s18;
            string s20;
            string sMsg = string.Empty;
            string sLabel = string.Empty;
            bool boCanJmp;
            const string sExceptionMsg = "{异常} TCastleManager::UserSelect... ";
            base.UserSelect(PlayObject, sData);
            try
            {
                if (this.m_Castle == null)
                {
                    PlayObject.SysMsg("NPC不属于城堡！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if ((sData != "") && (sData[0] == '@'))
                {
                    sMsg = HUtil32.GetValidStr3(sData, ref sLabel, new string[] { "\r" });
                    s18 = "";
                    PlayObject.m_sScriptLable = sData;
                    if (this.m_Castle.IsMasterGuild(PlayObject.m_MyGuild))
                    {
                        boCanJmp = PlayObject.LableIsCanJmp(sLabel);
                        if (string.Compare(sLabel, FunctionDef.sSL_SENDMSG, true) == 0)
                        {
                            if (sMsg == "")
                            {
                                return;
                            }
                        }
                        this.GotoLable(PlayObject, sLabel, !boCanJmp);
                        // GotoLable(PlayObject,sLabel,not PlayObject.LableIsCanJmp(sLabel));
                        if (!boCanJmp)
                        {
                            return;
                        }
                        if (string.Compare(sLabel, FunctionDef.sSL_SENDMSG, true) == 0)
                        {
                            SendCustemMsg(PlayObject, sMsg);
                            PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, s18);
                        }
                        else if (string.Compare(sLabel, FunctionDef.sCASTLENAME, true) == 0)
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                sMsg = sMsg.Trim();
                                if (sMsg != "")
                                {
                                    this.m_Castle.m_sName = sMsg;
                                    this.m_Castle.Save();
                                    this.m_Castle.m_MasterGuild.RefMemberName();
                                    s18 = "城堡名称更改成功...";
                                }
                                else
                                {
                                    s18 = "城堡名称更改失败！！！";
                                }
                                PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, s18);
                            }
                        }
                        else if (string.Compare(sLabel, FunctionDef.sWITHDRAWAL, true) == 0)
                        {
                            switch (this.m_Castle.WithDrawalGolds(PlayObject, HUtil32.Str_ToInt(sMsg, 0)))
                            {
                                case -4:// 取回金币
                                    s18 = "输入的金币数不正确！！！";
                                    break;
                                case -3:
                                    s18 = "您无法携带更多的东西了。";
                                    break;
                                case -2:
                                    s18 = "该城内没有这么多金币.";
                                    break;
                                case -1:
                                    s18 = "只有行会 " + this.m_Castle.m_sOwnGuild + " 的掌门人才能使用！！！";
                                    break;
                                case 1:
                                    this.GotoLable(PlayObject, FunctionDef.sMAIN, false);
                                    break;
                            }
                            PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, s18);
                        }
                        else if (string.Compare(sLabel, FunctionDef.sRECEIPTS, true) == 0)
                        {
                            switch (this.m_Castle.ReceiptGolds(PlayObject, HUtil32.Str_ToInt(sMsg, 0)))// 沙巴克存资金
                            {
                                case -4:
                                    s18 = "输入的金币数不正确！！！";
                                    break;
                                case -3:
                                    s18 = "您已经达到在城内存放货物的限制了。";
                                    break;
                                case -2:
                                    s18 = "您没有那么多金币.";
                                    break;
                                case -1:
                                    s18 = "只有行会 " + this.m_Castle.m_sOwnGuild + " 的掌门人才能使用！！！";
                                    break;
                                case 1:
                                    this.GotoLable(PlayObject, FunctionDef.sMAIN, false);
                                    break;
                            }
                            PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, s18);
                        }
                        else if (string.Compare(sLabel, FunctionDef.sOPENMAINDOOR, true) == 0)// 打开城门
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                this.m_Castle.MainDoorControl(false);
                            }
                        }
                        else if (string.Compare(sLabel, FunctionDef.sCLOSEMAINDOOR, true) == 0)// 关闭城门
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                this.m_Castle.MainDoorControl(true);
                            }
                        }
                        else if (string.Compare(sLabel, FunctionDef.sREPAIRDOORNOW, true) == 0)// 马上修复城门
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                RepairDoor(PlayObject);
                                this.GotoLable(PlayObject, FunctionDef.sMAIN, false);
                            }
                        }
                        else if (string.Compare(sLabel, FunctionDef.sREPAIRWALLNOW1, true) == 0)// 修城墙一
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                RepairWallNow(1, PlayObject);
                                this.GotoLable(PlayObject, FunctionDef.sMAIN, false);
                            }
                        }
                        else if (string.Compare(sLabel, FunctionDef.sREPAIRWALLNOW2, true) == 0) // 修城墙二
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                RepairWallNow(2, PlayObject);
                                this.GotoLable(PlayObject, FunctionDef.sMAIN, false);
                            }
                        }
                        else if (string.Compare(sLabel, FunctionDef.sREPAIRWALLNOW3, true) == 0) // 修城墙三
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                RepairWallNow(3, PlayObject);
                                this.GotoLable(PlayObject, FunctionDef.sMAIN, false);
                            }
                        }
                        else if (HUtil32.CompareLStr(sLabel, FunctionDef.sHIREGUARDNOW, 13))
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                s20 = sLabel.Substring(FunctionDef.sHIREGUARDNOW.Length + 1 - 1, sLabel.Length);
                                HireGuard(s20, PlayObject);
                                PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, "");
                                // GotoLable(PlayObject,sHIREGUARDOK,False);
                            }
                        }
                        else if (HUtil32.CompareLStr(sLabel, FunctionDef.sHIREARCHERNOW, 14))
                        {
                            if (PlayObject.IsGuildMaster())
                            {
                                s20 = sLabel.Substring(FunctionDef.sHIREARCHERNOW.Length + 1 - 1, sLabel.Length);
                                HireArcher(s20, PlayObject);
                                PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, "");
                            }
                        }
                        else if (string.Compare(sLabel, FunctionDef.sEXIT, true) == 0)
                        {
                            PlayObject.SendMsg(this, Grobal2.RM_MERCHANTDLGCLOSE, 0, Parse(this), 0, 0, "");
                        }
                        else if (string.Compare(sLabel, FunctionDef.sBACK, true) == 0)
                        {
                            if (PlayObject.m_sScriptGoBackLable == "")
                            {
                                PlayObject.m_sScriptGoBackLable = FunctionDef.sMAIN;
                            }
                            this.GotoLable(PlayObject, PlayObject.m_sScriptGoBackLable, false);
                        }
                    }
                }
                else
                {
                    s18 = "您没有权利使用";
                    PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(this), 0, 0, s18);
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        private void HireGuard(string sIndex, TPlayObject PlayObject)
        {
            int n10;
            TObjUnit ObjUnit;
            try
            {
                if (this.m_Castle == null)
                {
                    PlayObject.SysMsg("NPC不属于城堡！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (this.m_Castle.m_nTotalGold >= M2Share.g_Config.nHireGuardPrice)
                {
                    n10 = HUtil32.Str_ToInt(sIndex, 0) - 1;
                    if (n10 <= Castle.MAXCALSTEGUARD)
                    {
                        if (this.m_Castle.m_Guard[n10].BaseObject == null)
                        {
                            if (!this.m_Castle.m_boUnderWar)
                            {
                                ObjUnit = this.m_Castle.m_Guard[n10];
                                ObjUnit.BaseObject = UserEngine.RegenMonsterByName(this.m_Castle.m_sMapName, ObjUnit.nX, ObjUnit.nY, ObjUnit.sName);
                                if (ObjUnit.BaseObject != null)
                                {
                                    this.m_Castle.m_nTotalGold -= M2Share.g_Config.nHireGuardPrice;
                                    ObjUnit.BaseObject.m_Castle = ((TUserCastle)(this.m_Castle));
                                    ((TGuardUnit)(ObjUnit.BaseObject)).m_nX550 = ObjUnit.nX;
                                    ((TGuardUnit)(ObjUnit.BaseObject)).m_nY554 = ObjUnit.nY;
                                    ((TGuardUnit)(ObjUnit.BaseObject)).m_nDirection = 3;
                                    PlayObject.SysMsg("雇佣成功.", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                            else
                            {
                                PlayObject.SysMsg("现在无法雇佣！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                            }
                        }
                        else
                        {
                            PlayObject.SysMsg("早已雇佣！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        PlayObject.SysMsg("指令错误！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("城内资金不足！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCastleOfficial.HireGuard");
            }
        }

        private void HireArcher(string sIndex, TPlayObject PlayObject)
        {
            int n10;
            TObjUnit ObjUnit;
            try
            {
                if (this.m_Castle == null)
                {
                    PlayObject.SysMsg("NPC不属于城堡！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (this.m_Castle.m_nTotalGold >= M2Share.g_Config.nHireArcherPrice)
                {
                    n10 = HUtil32.Str_ToInt(sIndex, 0) - 1;
                    if (n10 <= Castle.MAXCASTLEARCHER)
                    {
                        if (this.m_Castle.m_Archer[n10].BaseObject == null)
                        {
                            if (!this.m_Castle.m_boUnderWar)
                            {
                                ObjUnit = this.m_Castle.m_Archer[n10];
                                ObjUnit.BaseObject = UserEngine.RegenMonsterByName(((TUserCastle)(this.m_Castle)).m_sMapName, ObjUnit.nX, ObjUnit.nY, ObjUnit.sName);
                                if (ObjUnit.BaseObject != null)
                                {
                                    this.m_Castle.m_nTotalGold -= M2Share.g_Config.nHireArcherPrice;
                                    ObjUnit.BaseObject.m_Castle = ((TUserCastle)(this.m_Castle));
                                    ((TGuardUnit)(ObjUnit.BaseObject)).m_nX550 = ObjUnit.nX;
                                    ((TGuardUnit)(ObjUnit.BaseObject)).m_nY554 = ObjUnit.nY;
                                    ((TGuardUnit)(ObjUnit.BaseObject)).m_nDirection = 3;
                                    PlayObject.SysMsg("雇佣成功.", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                            else
                            {
                                PlayObject.SysMsg("现在无法雇佣！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                            }
                        }
                        else
                        {
                            PlayObject.SysMsg("早已雇佣！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        PlayObject.SysMsg("指令错误！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("城内资金不足！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCastleOfficial.HireArcher");
            }
        }

        /// <summary>
        /// 修复城门
        /// </summary>
        /// <param name="PlayObject"></param>
        private void RepairDoor(TPlayObject PlayObject)
        {
            try
            {
                if (this.m_Castle == null)
                {
                    PlayObject.SysMsg("NPC不属于城堡！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (this.m_Castle.m_nTotalGold >= M2Share.g_Config.nRepairDoorPrice)
                {
                    if (this.m_Castle.RepairDoor())
                    {
                       this.m_Castle.m_nTotalGold -= M2Share.g_Config.nRepairDoorPrice;
                        PlayObject.SysMsg("修理成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                    else
                    {
                        PlayObject.SysMsg("城门不需要修理！！！", TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("城内资金不足！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildOfficial.RepairDoor");
            }
        }

        private void RepairWallNow(int nWallIndex, TPlayObject PlayObject)
        {
            try
            {
                if (this.m_Castle == null)
                {
                    PlayObject.SysMsg("NPC不属于城堡！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (this.m_Castle.m_nTotalGold >= M2Share.g_Config.nRepairWallPrice)
                {
                    if (this.m_Castle.RepairWall(nWallIndex))
                    {
                        this.m_Castle.m_nTotalGold -= M2Share.g_Config.nRepairWallPrice;
                        PlayObject.SysMsg("修理成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                    else
                    {
                        PlayObject.SysMsg("城门不需要修理！！！", TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("城内资金不足！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildOfficial.RepairWallNow");
            }
        }

        public TCastleOfficial()
            : base()
        {
        }

        /// <summary>
        /// 发送城主的话
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sMsg"></param>
        public override void SendCustemMsg(TPlayObject PlayObject, string sMsg)
        {
            try
            {
                if (!M2Share.g_Config.boSubkMasterSendMsg)
                {
                    PlayObject.SysMsg(GameMsgDef.g_sSubkMasterMsgCanNotUseNowMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (PlayObject.m_boSendMsgFlag)
                {
                    PlayObject.m_boSendMsgFlag = false;
                    UserEngine.SendBroadCastMsg(PlayObject.m_sCharName + ": " + sMsg, TMsgType.t_Castle);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildOfficial.SendCustemMsg");
            }
        }
    }
}
