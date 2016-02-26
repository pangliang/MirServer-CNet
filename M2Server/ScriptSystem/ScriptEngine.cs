using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace M2Server.ScriptSystem
{
    public class ScriptEngine
    {
        public TScriptBase ScriptManage;
        public ScriptEngine()
        { ScriptManage = new TScriptBase(); }

        public int LoadNpcScript(TNormNpc NPC, string sPatch, string sScritpName)
        {
            int result;
            if (sPatch == "")
            {
                sPatch = M2Share.sNpc_def;
            }
            result = LoadScriptFile(NPC, sPatch, sScritpName, false);
            return result;
        }

        public bool LoadScriptFile_LoadCallScript(string sFileName, string sLabel, ref TStringList List)
        {
            bool result = false;
            TStringList LoadStrList;
            bool bo1D;
            string s18;
            if (File.Exists(sFileName))
            {
                LoadStrList = new TStringList();
                LoadStrList.LoadFromFile(sFileName);
                sLabel = "[" + sLabel + "]";
                bo1D = false;
                if (LoadStrList.Count > 0)
                {
                    for (int I = 0; I < LoadStrList.Count; I++)
                    {
                        s18 = LoadStrList[I].Trim();
                        if (s18 != "")
                        {
                            if (!bo1D)
                            {
                                if ((s18[0] == '[') && string.Compare(s18, sLabel, true) == 0)
                                {
                                    bo1D = true;
                                    List.Add(s18);
                                }
                            }
                            else
                            {
                                if (s18[0] != '{')
                                {
                                    if (s18[0] == '}')
                                    {
                                        result = true;
                                        break;
                                    }
                                    else
                                    {
                                        List.Add(s18);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void LoadScriptFile_LoadScriptcall(ref TStringList LoadList)
        {
            string s14;
            string s18;
            string s1C = string.Empty;
            string s20;
            string s34;
            for (int I = 0; I < LoadList.Count; I++)
            {
                s14 = LoadList[I].Trim();
                if ((s14 != "") && (s14[0] == '#'))
                {
                    if (HUtil32.CompareLStr(s14, "#CALL", 5))
                    {
                        s14 = HUtil32.ArrestStringEx(s14, "[", "]", ref s1C);
                        s20 = s1C.Trim();
                        s18 = s14.Trim();
                        if (s20[0] == '\\')
                        {
                            s20 = s20.Substring(1, s20.Length - 1);
                        }
                        if (s20[1] == '\\')
                        {
                            s20 = s20.Substring(2, s20.Length - 2);
                        }
                        s34 = M2Share.g_Config.sEnvirDir + "QuestDiary\\" + s20;
                        if (LoadScriptFile_LoadCallScript(s34, s18, ref LoadList))
                        {
                            LoadList[I] = "#ACT";
                            LoadList.InsertText(I + 1, "goto " + s18);
                        }
                        else
                        {
                            M2Share.MainOutMessage("脚本错误, 加载失败: " + s20 + "  " + s18);
                        }
                    }
                }
            }
        }

        public string LoadScriptFile_LoadDefineInfo(ref TStringList LoadList, ref IList<TDefineInfo> List)
        {
            string result = string.Empty;
            string s14 = string.Empty;
            string s28 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            TDefineInfo DefineInfo;
            TStringList LoadStrList;
            for (int I = 0; I < LoadList.Count; I++)
            {
                s14 = LoadList[I].Trim();
                if ((s14 != "") && (s14[0] == '#'))
                {
                    if (HUtil32.CompareLStr(s14, "#SETHOME", 8))
                    {
                        result = HUtil32.GetValidStr3(s14, ref s1C, new string[] { " ", "\t" }).Trim();
                        LoadList[I] = "";
                    }
                    if (HUtil32.CompareLStr(s14, "#DEFINE", 7))
                    {
                        s14 = HUtil32.GetValidStr3(s14, ref s1C, new string[] { " ", "\t" });
                        s14 = HUtil32.GetValidStr3(s14, ref s20, new string[] { " ", "\t" });
                        s14 = HUtil32.GetValidStr3(s14, ref s24, new string[] { " ", "\t" });
                        DefineInfo = new TDefineInfo();
                        DefineInfo.sName = s20.ToUpper();
                        DefineInfo.sText = s24;
                        List.Add(DefineInfo);
                        LoadList[I] = "";
                    }
                    if (HUtil32.CompareLStr(s14, "#INCLUDE", 8))
                    {
                        s28 = HUtil32.GetValidStr3(s14, ref s1C, new string[] { " ", "\t" }).Trim();
                        s28 = M2Share.g_Config.sEnvirDir + "Defines\\" + s28;
                        if (File.Exists(s28))
                        {
                            LoadStrList = new TStringList();
                            LoadStrList.LoadFromFile(s28);
                            result = LoadScriptFile_LoadDefineInfo(ref LoadStrList, ref List);
                        }
                        else
                        {
                            M2Share.MainOutMessage("脚本错误, 加载失败: " + s28);
                        }
                        LoadList[I] = "";
                    }
                }
            }
            return result;
        }

        public TScript LoadScriptFile_MakeNewScript(ref int nQuestIdx, ref TNormNpc NPC)
        {
            TScript result;
            TScript ScriptInfo;
            ScriptInfo = new TScript();
            ScriptInfo.boQuest = false;
            ScriptInfo.QuestInfo = new TQuestInfo[10];
            //FillChar(ScriptInfo.QuestInfo, sizeof(TQuestInfo) * 10, '\0');
            nQuestIdx = 0;
            ScriptInfo.RecordList = new List<TSayingRecord>();
            NPC.m_ScriptList.Add(ScriptInfo);
            result = ScriptInfo;
            return result;
        }

        /// <summary>
        /// 加载NPC条件检查脚本
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="QuestConditionInfo"></param>
        /// <returns></returns>
        public bool LoadScriptFile_QuestCondition(string sText, ref TQuestConditionInfo QuestConditionInfo)
        {
            bool result = false;
            string sCmd = string.Empty;
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            string sParam4 = string.Empty;
            string sParam5 = string.Empty;
            string sParam6 = string.Empty;
            string sParam7 = string.Empty;
            Dictionary<string, int> ScriptDictionary;
            int nCMDCode;
            int aaaa;
            sText = HUtil32.GetValidStrCap(sText, ref sCmd, new string[] { " ", "\t" });
            aaaa = sCmd.IndexOf(".");
            if (aaaa >= 0)
            {
                sParam7 = sCmd.Substring(0, aaaa - 1);
                sParam6 = "88";
                sCmd = sCmd.Substring(aaaa + 1, sCmd.Length - aaaa - 1);
            }
            sText = HUtil32.GetValidStrCap(sText, ref sParam1, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam2, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam3, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam4, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam5, new string[] { " ", "\t" });
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam6, new string[] { " ", "\t" });
            }
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam7, new string[] { " ", "\t" });
            }
            sCmd = sCmd.ToUpper();
            nCMDCode = 0;
            if (sCmd == ScriptDef.sCHECK)
            {
                nCMDCode = ScriptDef.nCHECK;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
                goto L001;
            }
            if (sCmd == ScriptDef.sCHECKOPEN)
            {
                nCMDCode = ScriptDef.nCHECKOPEN;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
                goto L001;
            }
            if (sCmd == ScriptDef.sCHECKUNIT)
            {
                nCMDCode = ScriptDef.nCHECKUNIT;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
                goto L001;
            }
            if (M2Share.ScriptEngine.ScriptManage.ScriptDictionary.TryGetValue(sCmd, out nCMDCode))
            {
                goto L001;
            }
        L001:
            if (nCMDCode > 0)
            {
                QuestConditionInfo.nCMDCode = nCMDCode;
                if ((sParam1 != "") && (sParam1[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam1, "\"", "\"", ref sParam1);
                }
                if ((sParam2 != "") && (sParam2[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam2, "\"", "\"", ref sParam2);
                }
                if ((sParam3 != "") && (sParam3[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam3, "\"", "\"", ref sParam3);
                }
                if ((sParam4 != "") && (sParam4[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam4, "\"", "\"", ref sParam4);
                }
                if ((sParam5 != "") && (sParam5[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam5, "\"", "\"", ref sParam5);
                }
                if ((sParam6 != "") && (sParam6[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam6, "\"", "\"", ref sParam6);
                }
                if ((sParam7 != "") && (sParam7[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam7, "\"", "\"", ref sParam7);
                }
                QuestConditionInfo.sParam1 = sParam1;
                QuestConditionInfo.sParam2 = sParam2;
                QuestConditionInfo.sParam3 = sParam3;
                QuestConditionInfo.sParam4 = sParam4;
                QuestConditionInfo.sParam5 = sParam5;
                QuestConditionInfo.sParam6 = sParam6;
                QuestConditionInfo.sParam7 = sParam7;
                if (HUtil32.IsStringNumber(sParam1))
                {
                    QuestConditionInfo.nParam1 = HUtil32.Str_ToInt(sParam1, 0);
                }
                if (HUtil32.IsStringNumber(sParam2))
                {
                    QuestConditionInfo.nParam2 = HUtil32.Str_ToInt(sParam2, 0);
                }
                if (HUtil32.IsStringNumber(sParam3))
                {
                    QuestConditionInfo.nParam3 = HUtil32.Str_ToInt(sParam3, 0);
                }
                if (HUtil32.IsStringNumber(sParam4))
                {
                    QuestConditionInfo.nParam4 = HUtil32.Str_ToInt(sParam4, 0);
                }
                if (HUtil32.IsStringNumber(sParam5))
                {
                    QuestConditionInfo.nParam5 = HUtil32.Str_ToInt(sParam5, 0);
                }
                if (HUtil32.IsStringNumber(sParam6))
                {
                    QuestConditionInfo.nParam6 = HUtil32.Str_ToInt(sParam6, 0);
                }
                if (HUtil32.IsStringNumber(sParam7))
                {
                    QuestConditionInfo.nParam7 = HUtil32.Str_ToInt(sParam7, 0);
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 加载NPC条件处理脚本
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="QuestActionInfo"></param>
        /// <returns></returns>
        public bool LoadScriptFile_QuestAction(string sText, ref TQuestActionInfo QuestActionInfo)
        {
            bool result;
            string sCmd = string.Empty;
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            string sParam4 = string.Empty;
            string sParam5 = string.Empty;
            string sParam6 = string.Empty;
            string sParam7 = string.Empty;
            int nCMDCode;
            int bbbb;
            result = false;
            sText = HUtil32.GetValidStrCap(sText, ref sCmd, new string[] { " ", "\t" });
            bbbb = sCmd.IndexOf(".");
            if (bbbb > 0)
            {
                sParam7 = sCmd.Substring(0, bbbb - 1);
                sParam6 = "88";
                sCmd = sCmd.Substring(bbbb + 1, sCmd.Length - bbbb - 1);
            }
            sText = HUtil32.GetValidStrCap(sText, ref sParam1, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam2, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam3, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam4, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam5, new string[] { " ", "\t" });
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam6, new string[] { " ", "\t" });
            }
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam7, new string[] { " ", "\t" });
            }
            sCmd = sCmd.ToUpper();
            nCMDCode = 0;
            if (sCmd == ScriptDef.sSET)
            {
                nCMDCode = ScriptDef.nSET;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == ScriptDef.sRESET)
            {
                nCMDCode = ScriptDef.nRESET;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == ScriptDef.sSETOPEN)
            {
                nCMDCode = ScriptDef.nSETOPEN;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == ScriptDef.sSETUNIT)
            {
                nCMDCode = ScriptDef.nSETUNIT;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == ScriptDef.sRESETUNIT)
            {
                nCMDCode = ScriptDef.nRESETUNIT;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (M2Share.ScriptEngine.ScriptManage.ScriptDictionary.TryGetValue(sCmd, out nCMDCode))
            {
                goto L001;
            }
            if (sCmd == ScriptDef.sTAKE)
            {
                nCMDCode = ScriptDef.nTAKE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GIVE)
            {
                nCMDCode = ScriptDef.nSC_GIVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sCLOSE)
            {
                nCMDCode = ScriptDef.nCLOSE;
                goto L001;
            }
            if (sCmd == ScriptDef.sBREAK)
            {
                nCMDCode = ScriptDef.nBREAK;
                goto L001;
            }
            if (sCmd == ScriptDef.sGOTO)
            {
                nCMDCode = ScriptDef.nGOTO;
                goto L001;
            }
            if (sCmd == ScriptDef.sADDNAMELIST)
            {
                nCMDCode = ScriptDef.nADDNAMELIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sDELNAMELIST)
            {
                nCMDCode = ScriptDef.nDELNAMELIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sADDGUILDLIST)
            {
                nCMDCode = ScriptDef.nADDGUILDLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sDELGUILDLIST)
            {
                nCMDCode = ScriptDef.nDELGUILDLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sADDACCOUNTLIST)
            {
                nCMDCode = ScriptDef.nADDACCOUNTLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sDELACCOUNTLIST)
            {
                nCMDCode = ScriptDef.nDELACCOUNTLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sADDIPLIST)
            {
                nCMDCode = ScriptDef.nADDIPLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sDELIPLIST)
            {
                nCMDCode = ScriptDef.nDELIPLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sSENDMSG)
            {
                nCMDCode = ScriptDef.nSENDMSG;
                goto L001;
            }
            if (sCmd == ScriptDef.sCREATEFILE)// 创建文本文件
            {
                nCMDCode = ScriptDef.nCREATEFILE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSENDTOPMSG) // 顶端滚动公告
            {
                nCMDCode = ScriptDef.nSENDTOPMSG;
                goto L001;
            }
            if (sCmd == ScriptDef.sSENDCENTERMSG)  // 屏幕居中显示公告
            {
                nCMDCode = ScriptDef.nSENDCENTERMSG;
                goto L001;
            }
            if (sCmd == ScriptDef.sSENDEDITTOPMSG)// 聊天框顶端公告
            {
                nCMDCode = ScriptDef.nSENDEDITTOPMSG;
                goto L001;
            }
            if (sCmd == ScriptDef.sOPENBOOKS)// 卧龙命令
            {
                nCMDCode = ScriptDef.nOPENBOOKS;
                goto L001;
            }
            if (sCmd == ScriptDef.sOPENBOOK)// 卧龙命令
            {
                nCMDCode = ScriptDef.nOPENBOOKS;
                goto L001;
            }
            if (sCmd == ScriptDef.sOPENYBDEAL) // 开通元宝交易
            {
                nCMDCode = ScriptDef.nOPENYBDEAL;
                goto L001;
            }
            if (sCmd == ScriptDef.sQUERYYBSELL) // 查询正在元宝寄售出售的物品
            {
                nCMDCode = ScriptDef.nQUERYYBSELL;
                goto L001;
            }
            if (sCmd == ScriptDef.sQUERYYBDEAL)// 查询可以的购买物品
            {
                nCMDCode = ScriptDef.nQUERYYBDEAL;
                goto L001;
            }
            if (sCmd == ScriptDef.sTHROUGHHUM)// 改变穿人模式
            {
                nCMDCode = ScriptDef.nTHROUGHHUM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sSetOnTimer)  // 个人定时器(启动)
            {
                nCMDCode = ScriptDef.nSetOnTimer;
                goto L001;
            }
            if (sCmd == ScriptDef.sSetScTimer)// 个人定时器(启动)
            {
                nCMDCode = ScriptDef.nSetOnTimer;
                goto L001;
            }
            if (sCmd == ScriptDef.sSETOFFTIMER)// 停止定时器
            {
                nCMDCode = ScriptDef.nSETOFFTIMER;
                goto L001;
            }
            if (sCmd == ScriptDef.sKILLSCTIMER) // 停止定时器
            {
                nCMDCode = ScriptDef.nSETOFFTIMER;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sGETSORTNAME) // 取指定排行榜指定排名的玩家名字
            {

                nCMDCode = ScriptDef.nGETSORTNAME;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sWEBBROWSER) // 连接指定网站网址
            {
                nCMDCode = ScriptDef.nWEBBROWSER;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sADDATTACKSABUKALL)// 设置所有行会攻城
            {
                nCMDCode = ScriptDef.nADDATTACKSABUKALL;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sKICKALLPLAY)// 踢除服务器所有人物
            {
                nCMDCode = ScriptDef.nKICKALLPLAY;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sREPAIRALL)// 修理全身装备
            {
                nCMDCode = ScriptDef.nREPAIRALL;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sAUTOGOTOXY)// 自动寻路
            {
                nCMDCode = ScriptDef.nAUTOGOTOXY;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sCHANGESKILL)// 修改魔法ID
            {
                nCMDCode = ScriptDef.nCHANGESKILL;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sOPENMAKEWINE)  // 打开酿酒窗口 
            {
                nCMDCode = ScriptDef.nOPENMAKEWINE;
                goto L001;
            }
            if (sCmd == ScriptDef.sGETGOODMAKEWINE) // 取回酿好的酒 
            {
                nCMDCode = ScriptDef.nGETGOODMAKEWINE;
                goto L001;
            }
            if (sCmd == ScriptDef.sDECMAKEWINETIME)// 减少酿酒的时间 
            {
                nCMDCode = ScriptDef.nDECMAKEWINETIME;
                goto L001;
            }
            if (sCmd == ScriptDef.sREADSKILLNG)  // 学习内功
            {
                nCMDCode = ScriptDef.nREADSKILLNG;
                goto L001;
            }
            if (sCmd == ScriptDef.sMAKEWINENPCMOVE) // 酿酒NPC的走动
            {
                nCMDCode = ScriptDef.nMAKEWINENPCMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sFOUNTAIN) // 设置泉水喷发
            {
                nCMDCode = ScriptDef.nFOUNTAIN;
                goto L001;
            }
            if (sCmd == ScriptDef.sSETGUILDFOUNTAIN) // 开启/关闭行会泉水仓库
            {
                nCMDCode = ScriptDef.nSETGUILDFOUNTAIN;
                goto L001;
            }
            if (sCmd == ScriptDef.sGIVEGUILDFOUNTAIN)  // 领取行会酒水
            {
                nCMDCode = ScriptDef.nGIVEGUILDFOUNTAIN;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sCHALLENGMAPMOVE) // 挑战地图移动
            {
                nCMDCode = ScriptDef.nCHALLENGMAPMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sGETCHALLENGEBAKITEM) // 没有挑战地图可移动,则退回抵押的物品
            {
                nCMDCode = ScriptDef.nGETCHALLENGEBAKITEM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sHEROLOGOUT)// 英雄下线
            {
                nCMDCode = ScriptDef.nHEROLOGOUT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSETITEMSLIGHT) // 装备发光设置
            {
                nCMDCode = ScriptDef.nSETITEMSLIGHT;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sQUERYREFINEITEM)// 打开粹练窗口
            {
                nCMDCode = ScriptDef.nQUERYREFINEITEM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sGOHOME) // 移动到回城点 
            {
                nCMDCode = ScriptDef.nGOHOME;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sTHROWITEM)  // 将指定物品刷新到指定地图坐标范围内 
            {
                nCMDCode = ScriptDef.nTHROWITEM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sOPENDRAGONBOX)// 打开粹练窗口 
            {
                nCMDCode = ScriptDef.nOPENDRAGONBOX;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sCLEARCODELIST) // 删除指定文本里的编码 
            {
                nCMDCode = ScriptDef.nCLEARCODELIST;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sGETRANDOMNAME) // 随机取文件名称
            {
                nCMDCode = ScriptDef.nGETRANDOMNAME;
                goto L001;
            }
            if (sCmd == ScriptDef.sREADRANDOMSTR) // 随机取文件名称 
            {
                nCMDCode = ScriptDef.nGETRANDOMNAME;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sHCall) // 通过脚本命令让别人执行QManage.txt中的脚本 
            {
                nCMDCode = ScriptDef.nHCall;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sINCASTLEWARAY)  // 检测人物是否在攻城期间的范围内，在则BB叛变 
            {
                nCMDCode = ScriptDef.nINCASTLEWARAY;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sGIVESTATEITEM) // 给予带绑定状态装备 
            {
                nCMDCode = ScriptDef.nGIVESTATEITEM;
                goto L001;
            }
            if (sCmd == ScriptDef.sSETITEMSTATE) // 设置装备绑定状态
            {
                nCMDCode = ScriptDef.nSETITEMSTATE;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sPKPOINT)
            {
                nCMDCode = ScriptDef.nPKPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_RECALLMOB)
            {
                nCMDCode = ScriptDef.nSC_RECALLMOB;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sSC_RECALLMOBEX)// 新增召出的宝宝命令
            {
                nCMDCode = ScriptDef.nSC_RECALLMOBEX;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sSC_MOVEMOBTO)  // 将指定坐标的怪物移动到新坐标 
            {
                nCMDCode = ScriptDef.nSC_MOVEMOBTO;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sSC_CLEARITEMMAP) // 清除地图物品 
            {

                nCMDCode = ScriptDef.nSC_CLEARITEMMAP;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARMAPITEM)// 清除地图物品 
            {
                nCMDCode = ScriptDef.nSC_CLEARITEMMAP;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sKICK)
            {
                nCMDCode = ScriptDef.nKICK;
                goto L001;
            }
            if (sCmd == ScriptDef.sTAKEW)
            {
                nCMDCode = ScriptDef.nTAKEW;
                goto L001;
            }
            if (sCmd == ScriptDef.sTIMERECALL)
            {
                nCMDCode = ScriptDef.nTIMERECALL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_PARAM1)
            {
                nCMDCode = ScriptDef.nSC_PARAM1;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_PARAM2)
            {
                nCMDCode = ScriptDef.nSC_PARAM2;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_PARAM3)
            {
                nCMDCode = ScriptDef.nSC_PARAM3;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_PARAM4)
            {
                nCMDCode = ScriptDef.nSC_PARAM4;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_EXEACTION)
            {
                nCMDCode = ScriptDef.nSC_EXEACTION;
                goto L001;
            }
            if (sCmd == ScriptDef.sMAPMOVE)
            {
                nCMDCode = ScriptDef.nMAPMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sMAP)
            {
                nCMDCode = ScriptDef.nMAP;
                goto L001;
            }
            if (sCmd == ScriptDef.sTAKECHECKITEM)
            {
                nCMDCode = ScriptDef.nTAKECHECKITEM;
                goto L001;
            }
            if (sCmd == ScriptDef.sMONGEN)
            {
                nCMDCode = ScriptDef.nMONGEN;
                goto L001;
            }
            if (sCmd == ScriptDef.sMONCLEAR)
            {
                nCMDCode = ScriptDef.nMONCLEAR;
                goto L001;
            }
            if (sCmd == ScriptDef.sMOV)
            {
                nCMDCode = ScriptDef.nMOV;
                goto L001;
            }
            if (sCmd == ScriptDef.sINC)
            {
                nCMDCode = ScriptDef.nINC;
                goto L001;
            }
            if (sCmd == ScriptDef.sDEC)
            {
                nCMDCode = ScriptDef.nDEC;
                goto L001;
            }
            if (sCmd == ScriptDef.sSUM)
            {
                nCMDCode = ScriptDef.nSUM;
                goto L001;
            }
            // -------------------------------------------------------
            // 变量运算
            if (sCmd == ScriptDef.sSC_DIV) // 除法
            {
                nCMDCode = ScriptDef.nSC_DIV;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MUL)  // 乘法
            {
                nCMDCode = ScriptDef.nSC_MUL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_PERCENT) // 百分比
            {
                nCMDCode = ScriptDef.nSC_PERCENT;
                goto L001;
            }
            // --------------------------------------------------------
            if (sCmd == ScriptDef.sBREAKTIMERECALL)
            {
                nCMDCode = ScriptDef.nBREAKTIMERECALL;
                goto L001;
            }
            if (sCmd == ScriptDef.sMOVR)
            {
                nCMDCode = ScriptDef.nMOVR;
                goto L001;
            }
            if (sCmd == ScriptDef.sEXCHANGEMAP)
            {
                nCMDCode = ScriptDef.nEXCHANGEMAP;
                goto L001;
            }
            if (sCmd == ScriptDef.sRECALLMAP)
            {
                nCMDCode = ScriptDef.nRECALLMAP;
                goto L001;
            }
            if (sCmd == ScriptDef.sADDBATCH)
            {
                nCMDCode = ScriptDef.nADDBATCH;
                goto L001;
            }
            if (sCmd == ScriptDef.sBATCHDELAY)
            {
                nCMDCode = ScriptDef.nBATCHDELAY;
                goto L001;
            }
            if (sCmd == ScriptDef.sBATCHMOVE)
            {
                nCMDCode = ScriptDef.nBATCHMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sPLAYDICE)
            {
                nCMDCode = ScriptDef.nPLAYDICE;
                goto L001;
            }
            if (sCmd == ScriptDef.sGOQUEST)
            {
                nCMDCode = ScriptDef.nGOQUEST;
                goto L001;
            }
            if (sCmd == ScriptDef.sENDQUEST)
            {
                nCMDCode = ScriptDef.nENDQUEST;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_HAIRSTYLE)
            {
                nCMDCode = ScriptDef.nSC_HAIRSTYLE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGELEVEL)
            {
                nCMDCode = ScriptDef.nSC_CHANGELEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MARRY)
            {
                nCMDCode = ScriptDef.nSC_MARRY;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_UNMARRY)
            {
                nCMDCode = ScriptDef.nSC_UNMARRY;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GETMARRY)
            {
                nCMDCode = ScriptDef.nSC_GETMARRY;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GETMASTER)
            {
                nCMDCode = ScriptDef.nSC_GETMASTER;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARSKILL)
            {
                nCMDCode = ScriptDef.nSC_CLEARSKILL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELNOJOBSKILL)
            {
                nCMDCode = ScriptDef.nSC_DELNOJOBSKILL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELSKILL)
            {
                nCMDCode = ScriptDef.nSC_DELSKILL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_ADDSKILL)
            {
                nCMDCode = ScriptDef.nSC_ADDSKILL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_ADDGUILDMEMBER)// 添加行会成员
            {
                nCMDCode = ScriptDef.nSC_ADDGUILDMEMBER;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELGUILDMEMBER)// 删除行会成员（删除掌门无效）
            {
                nCMDCode = ScriptDef.nSC_DELGUILDMEMBER;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SKILLLEVEL)
            {
                nCMDCode = ScriptDef.nSC_SKILLLEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_HEROSKILLLEVEL)// 调整英雄技能等级
            {
                nCMDCode = ScriptDef.nSC_HEROSKILLLEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEPKPOINT)
            {
                nCMDCode = ScriptDef.nSC_CHANGEPKPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEEXP) // 调整角色经验
            {
                nCMDCode = ScriptDef.nSC_CHANGEEXP;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGENGEXP) // 调整角色内功经验
            {
                nCMDCode = ScriptDef.nSC_CHANGENGEXP;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGENGLEVEL) // 调整角色内功等级
            {
                nCMDCode = ScriptDef.nSC_CHANGENGLEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SENDTIMEMSG)// 时间到触发QF段(客户端显示信息) 
            {
                nCMDCode = ScriptDef.nSC_SENDTIMEMSG;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SENDMSGWINDOWS)// 时间到触发QF段 
            {
                nCMDCode = ScriptDef.nSC_SENDMSGWINDOWS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLOSEMSGWINDOWS)// 关闭客户端'!'图标的显示 
            {
                nCMDCode = ScriptDef.nSC_CLOSEMSGWINDOWS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GETGROUPCOUNT)// 取组队成员数 
            {
                nCMDCode = ScriptDef.nSC_GETGROUPCOUNT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OPENEXPCRYSTAL)// 客户端显示天地结晶
            {
                nCMDCode = ScriptDef.nSC_OPENEXPCRYSTAL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLOSEEXPCRYSTAL)// 客户端关闭天地结晶图标
            {
                nCMDCode = ScriptDef.nSC_CLOSEEXPCRYSTAL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GETEXPTOCRYSTAL)// 取提天地结晶中的经验(只提取可提取的经验) 
            {
                nCMDCode = ScriptDef.nSC_GETEXPTOCRYSTAL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEJOB)
            {
                nCMDCode = ScriptDef.nSC_CHANGEJOB;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MISSION)
            {
                nCMDCode = ScriptDef.nSC_MISSION;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MOBPLACE)
            {
                nCMDCode = ScriptDef.nSC_MOBPLACE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SETMEMBERTYPE)
            {
                nCMDCode = ScriptDef.nSC_SETMEMBERTYPE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SETMEMBERLEVEL)
            {
                nCMDCode = ScriptDef.nSC_SETMEMBERLEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GAMEGOLD)// 调整游戏币的命令
            {
                nCMDCode = ScriptDef.nSC_GAMEGOLD;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GAMEDIAMOND)// 调整金刚石数量 
            {
                nCMDCode = ScriptDef.nSC_GAMEDIAMOND;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GAMEGIRD)// 调整灵符数量 
            {
                nCMDCode = ScriptDef.nSC_GAMEGIRD;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GAMEGLORY)// 调整荣誉值 
            {
                nCMDCode = ScriptDef.nSC_GAMEGLORY;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHEROLOYAL)// 调整英雄的忠诚度 
            {
                nCMDCode = ScriptDef.nSC_CHANGEHEROLOYAL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHUMABILITY) // 调整人物属性 
            {
                nCMDCode = ScriptDef.nSC_CHANGEHUMABILITY;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHEROTRANPOINT)// 调整英雄技能升级点数 
            {
                nCMDCode = ScriptDef.nSC_CHANGEHEROTRANPOINT;
                goto L001;
            }
            // --------------------酒馆系统------------------------------------------------
            if (sCmd == ScriptDef.sSC_SAVEHERO) // 寄放英雄 
            {
                nCMDCode = ScriptDef.nSC_SAVEHERO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GETHERO) // 取回英雄 
            {
                nCMDCode = ScriptDef.nSC_GETHERO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLOSEDRINK)// 关闭斗酒窗口 
            {
                nCMDCode = ScriptDef.nSC_CLOSEDRINK;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_PLAYDRINKMSG)// 斗酒窗口说话信息 
            {
                nCMDCode = ScriptDef.nSC_PLAYDRINKMSG;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OPENPLAYDRINK)// 指定人物喝酒
            {
                nCMDCode = ScriptDef.nSC_OPENPLAYDRINK;
                goto L001;
            }
            // ----------------------------------------------------------------------------
            if (sCmd == ScriptDef.sSC_GAMEPOINT)
            {
                nCMDCode = ScriptDef.nSC_GAMEPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_PKZONE)
            {
                nCMDCode = ScriptDef.nSC_PKZONE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_RESTBONUSPOINT)
            {
                nCMDCode = ScriptDef.nSC_RESTBONUSPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_TAKECASTLEGOLD)
            {
                nCMDCode = ScriptDef.nSC_TAKECASTLEGOLD;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_HUMANHP)
            {
                nCMDCode = ScriptDef.nSC_HUMANHP;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_HUMANMP)
            {
                nCMDCode = ScriptDef.nSC_HUMANMP;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_BUILDPOINT)
            {
                nCMDCode = ScriptDef.nSC_BUILDPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_AURAEPOINT)
            {
                nCMDCode = ScriptDef.nSC_AURAEPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_STABILITYPOINT)
            {
                nCMDCode = ScriptDef.nSC_STABILITYPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_FLOURISHPOINT)
            {
                nCMDCode = ScriptDef.nSC_FLOURISHPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OPENMAGICBOX)
            {
                nCMDCode = ScriptDef.nSC_OPENMAGICBOX;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OPENBOX)  //开宝箱
            {
                nCMDCode = ScriptDef.nSC_OPENMAGICBOX;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SETRANKLEVELNAME)
            {
                nCMDCode = ScriptDef.nSC_SETRANKLEVELNAME;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GMEXECUTE)
            {
                nCMDCode = ScriptDef.nSC_GMEXECUTE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GUILDCHIEFITEMCOUNT)
            {
                nCMDCode = ScriptDef.nSC_GUILDCHIEFITEMCOUNT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MOBFIREBURN)
            {
                nCMDCode = ScriptDef.nSC_MOBFIREBURN;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MESSAGEBOX)
            {
                nCMDCode = ScriptDef.nSC_MESSAGEBOX;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SETSCRIPTFLAG)
            {
                nCMDCode = ScriptDef.nSC_SETSCRIPTFLAG;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SETAUTOGETEXP)
            {
                nCMDCode = ScriptDef.nSC_SETAUTOGETEXP;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_VAR)
            {
                nCMDCode = ScriptDef.nSC_VAR;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_LOADVAR)
            {
                nCMDCode = ScriptDef.nSC_LOADVAR;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SAVEVAR)
            {
                nCMDCode = ScriptDef.nSC_SAVEVAR;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CALCVAR)
            {
                nCMDCode = ScriptDef.nSC_CALCVAR;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_AUTOADDGAMEGOLD)
            {
                nCMDCode = ScriptDef.nSC_AUTOADDGAMEGOLD;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_AUTOSUBGAMEGOLD)
            {
                nCMDCode = ScriptDef.nSC_AUTOSUBGAMEGOLD;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARNAMELIST)
            {
                nCMDCode = ScriptDef.nSC_CLEARNAMELIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGENAMECOLOR)
            {
                nCMDCode = ScriptDef.nSC_CHANGENAMECOLOR;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARPASSWORD)
            {
                nCMDCode = ScriptDef.nSC_CLEARPASSWORD;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_RENEWLEVEL)
            {
                nCMDCode = ScriptDef.nSC_RENEWLEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_KILLMONEXPRATE)
            {
                nCMDCode = ScriptDef.nSC_KILLMONEXPRATE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_POWERRATE)
            {
                nCMDCode = ScriptDef.nSC_POWERRATE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEMODE)
            {
                nCMDCode = ScriptDef.nSC_CHANGEMODE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEPERMISSION)
            {
                nCMDCode = ScriptDef.nSC_CHANGEPERMISSION;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_KILL)
            {
                nCMDCode = ScriptDef.nSC_KILL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_KICK)
            {
                nCMDCode = ScriptDef.nSC_KICK;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_BONUSPOINT)
            {
                nCMDCode = ScriptDef.nSC_BONUSPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_RESTRENEWLEVEL)
            {
                nCMDCode = ScriptDef.nSC_RESTRENEWLEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELMARRY)
            {
                nCMDCode = ScriptDef.nSC_DELMARRY;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELMASTER)
            {
                nCMDCode = ScriptDef.nSC_DELMASTER;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MASTER)
            {
                nCMDCode = ScriptDef.nSC_MASTER;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_UNMASTER)
            {
                nCMDCode = ScriptDef.nSC_UNMASTER;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CREDITPOINT)
            {
                nCMDCode = ScriptDef.nSC_CREDITPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEGUILDMEMBERCOUNT)// 调整行会成员上限
            {
                nCMDCode = ScriptDef.nSC_CHANGEGUILDMEMBERCOUNT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEGUILDFOUNTAIN)// 调整行会酒泉
            {
                nCMDCode = ScriptDef.nSC_CHANGEGUILDFOUNTAIN;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_TAGMAPINFO) // 记路标石
            {
                nCMDCode = ScriptDef.nSC_TAGMAPINFO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_TAGMAPMOVE) // 移动到记路标石记录的XY
            {
                nCMDCode = ScriptDef.nSC_TAGMAPMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARNEEDITEMS)
            {
                nCMDCode = ScriptDef.nSC_CLEARNEEDITEMS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARMAKEITEMS)
            {
                nCMDCode = ScriptDef.nSC_CLEARMAEKITEMS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SETSENDMSGFLAG)
            {
                nCMDCode = ScriptDef.nSC_SETSENDMSGFLAG;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_UPGRADEITEMS)
            {
                nCMDCode = ScriptDef.nSC_UPGRADEITEMS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_UPGRADEITEMSEX)
            {
                nCMDCode = ScriptDef.nSC_UPGRADEITEMSEX;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GIVEMINE) // 给矿石 
            {
                nCMDCode = ScriptDef.nSC_GIVEMINE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_MONGENEX)
            {
                nCMDCode = ScriptDef.nSC_MONGENEX;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARMAPMON)
            {
                nCMDCode = ScriptDef.nSC_CLEARMAPMON;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_SETMAPMODE)
            {
                nCMDCode = ScriptDef.nSC_SETMAPMODE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_KILLSLAVE)
            {
                nCMDCode = ScriptDef.nSC_KILLSLAVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEGENDER)
            {
                nCMDCode = ScriptDef.nSC_CHANGEGENDER;
                goto L001;
            }
            if (sCmd == ScriptDef.sOFFLINEPLAY)
            {
                nCMDCode = ScriptDef.nOFFLINEPLAY;
                goto L001;
            }
            if (sCmd == ScriptDef.sKICKOFFLINE)
            {
                nCMDCode = ScriptDef.nKICKOFFLINE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSTARTTAKEGOLD)
            {
                nCMDCode = ScriptDef.nSTARTTAKEGOLD;
                goto L001;
            }
            if (sCmd == ScriptDef.sDELAYGOTO)
            {
                nCMDCode = ScriptDef.nDELAYGOTO;
                goto L001;
            }
            if (sCmd == ScriptDef.sDELAYCALL)
            {
                nCMDCode = ScriptDef.nDELAYGOTO;//加对blue延时脚本支持
                goto L001;
            }
            if (sCmd == ScriptDef.sCLEARDELAYGOTO)
            {
                nCMDCode = ScriptDef.nCLEARDELAYGOTO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_ADDUSERDATE)
            {
                nCMDCode = ScriptDef.nSC_ADDUSERDATE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELUSERDATE)
            {
                nCMDCode = ScriptDef.nSC_DELUSERDATE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_ANSIREPLACETEXT)
            {
                nCMDCode = ScriptDef.nSC_ANSIREPLACETEXT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_ENCODETEXT)
            {
                nCMDCode = ScriptDef.nSC_ENCODETEXT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_ADDTEXTLIST)
            {
                nCMDCode = ScriptDef.nSC_ADDTEXTLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELTEXTLIST)
            {
                nCMDCode = ScriptDef.nSC_DELTEXTLIST;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GROUPMOVE)
            {
                nCMDCode = ScriptDef.nSC_GROUPMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GROUPMAPMOVE)
            {
                nCMDCode = ScriptDef.nSC_GROUPMAPMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_RECALLHUMAN)
            {
                nCMDCode = ScriptDef.nSC_RECALLHUMAN;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_REGOTO)
            {
                nCMDCode = ScriptDef.nSC_REGOTO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_INTTOSTR)
            {
                nCMDCode = ScriptDef.nSC_INTTOSTR;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_STRTOINT)
            {
                nCMDCode = ScriptDef.nSC_STRTOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GUILDMOVE)
            {
                nCMDCode = ScriptDef.nSC_GUILDMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GUILDMAPMOVE)
            {
                nCMDCode = ScriptDef.nSC_GUILDMAPMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_RANDOMMOVE)
            {
                nCMDCode = ScriptDef.nSC_RANDOMMOVE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_USEBONUSPOINT)
            {
                nCMDCode = ScriptDef.nSC_USEBONUSPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_BONUSABIL)
            {
                nCMDCode = ScriptDef.nSC_USEBONUSPOINT;//增加变量支持
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_REPAIRITEM)
            {
                nCMDCode = ScriptDef.nSC_REPAIRITEM;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_TAKEONITEM)
            {
                nCMDCode = ScriptDef.nSC_TAKEONITEM;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_TAKEOFFITEM)
            {
                nCMDCode = ScriptDef.nSC_TAKEOFFITEM;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CREATEHERO)
            {
                nCMDCode = ScriptDef.nSC_CREATEHERO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_DELETEHERO)
            {
                nCMDCode = ScriptDef.nSC_DELETEHERO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHEROLEVEL)
            {
                nCMDCode = ScriptDef.nSC_CHANGEHEROLEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHEROJOB)
            {
                nCMDCode = ScriptDef.nSC_CHANGEHEROJOB;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLEARHEROSKILL)
            {
                nCMDCode = ScriptDef.nSC_CLEARHEROSKILL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHEROPKPOINT)
            {
                nCMDCode = ScriptDef.nSC_CHANGEHEROPKPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHEROEXP)
            {
                nCMDCode = ScriptDef.nSC_CHANGEHEROEXP;
                goto L001;
            }
            // --------------------连击相关--------------------------------//
            if (sCmd == ScriptDef.sSC_OPENMAKEKIMNEEDLE)
            {
                nCMDCode = ScriptDef.nSC_OPENMAKEKIMNEEDLE; // 客户端显示锻练金针窗口
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_TAKEKIMNEEDLE)
            {
                nCMDCode = ScriptDef.nSC_TAKEKIMNEEDLE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_GIVEKIMNEEDLE)
            {
                nCMDCode = ScriptDef.nSC_GIVEKIMNEEDLE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OPENPULSE)
            {
                nCMDCode = ScriptDef.nSC_OPENPULSE;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEPULSELEVEL)
            {
                nCMDCode = ScriptDef.nSC_CHANGEPULSELEVEL;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGHEARMSGCOLOR)
            {
                nCMDCode = ScriptDef.nSC_CHANGHEARMSGCOLOR;// 未实现
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OPENCATTLEGAS)
            {
                nCMDCode = ScriptDef.nSC_OPENCATTLEGAS;// 未实现
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OPENHEROPULS)
            {
                nCMDCode = ScriptDef.nSC_OPENHEROPULS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGEHEROPULSEXP)
            {
                nCMDCode = ScriptDef.nSC_CHANGEHEROPULSEXP;
                goto L001;
            }
            // --------------------富贵兽相关------------------------------------------------
            if (sCmd == ScriptDef.sSC_OPENCATTLEGAS)
            {
                nCMDCode = ScriptDef.nSC_OPENCATTLEGAS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CLOSECATTLEGAS)
            {
                nCMDCode = ScriptDef.nSC_CLOSECATTLEGAS;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_CHANGECATTLEGASEXP)
            {
                nCMDCode = ScriptDef.nSC_CHANGECATTLEGASEXP;
                goto L001;
            }
            // ------------------------------------------------------------------------------
            if (sCmd == ScriptDef.sSC_TAKEITMECOUNTDURA)
            {
                nCMDCode = ScriptDef.nSC_TAKEITMECOUNTDURA;
                goto L001;
            }
            // -------双英雄相关--------------------//
            if (sCmd == ScriptDef.sSC_ASSESSMENTHERO)
            {
                nCMDCode = ScriptDef.nSC_ASSESSMENTHERO;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_OpenHeroAutoPractice)
            {
                nCMDCode = ScriptDef.nSC_OpenHeroAutoPractice;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_StopHeroAutoPractice)
            {
                nCMDCode = ScriptDef.nSC_StopHeroAutoPractice;
                goto L001;
            }
            // -----------------------------------------------
            if (sCmd == ScriptDef.sSC_CHANGETRANPOINT)
            {
                // 技能名 操作符(+ - =) 数值
                nCMDCode = ScriptDef.nSC_CHANGETRANPOINT;
                goto L001;
            }
            if (sCmd == ScriptDef.sSC_NPCGIVEITEM)
            {
                nCMDCode = ScriptDef.nSC_NPCGIVEITEM;
                goto L001;
            }
        L001:
            if (nCMDCode > 0)
            {
                QuestActionInfo.nCMDCode = nCMDCode;
                if ((sParam1 != "") && (sParam1[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam1, "\"", "\"", ref sParam1);
                }
                if ((sParam2 != "") && (sParam2[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam2, "\"", "\"", ref sParam2);
                }
                if ((sParam3 != "") && (sParam3[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam3, "\"", "\"", ref sParam3);
                }
                if ((sParam4 != "") && (sParam4[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam4, "\"", "\"", ref sParam4);
                }
                if ((sParam5 != "") && (sParam5[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam5, "\"", "\"", ref sParam5);
                }
                if ((sParam6 != "") && (sParam6[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam6, "\"", "\"", ref sParam6);
                }
                if ((sParam7 != "") && (sParam7[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam7, "\"", "\"", ref sParam7);
                }
                QuestActionInfo.sParam1 = sParam1;
                QuestActionInfo.sParam2 = sParam2;
                QuestActionInfo.sParam3 = sParam3;
                QuestActionInfo.sParam4 = sParam4;
                QuestActionInfo.sParam5 = sParam5;
                QuestActionInfo.sParam6 = sParam6;
                QuestActionInfo.sParam7 = sParam7;
                if (HUtil32.IsStringNumber(sParam1))
                {
                    QuestActionInfo.nParam1 = HUtil32.Str_ToInt(sParam1, 0);
                }
                if (HUtil32.IsStringNumber(sParam2))
                {
                    QuestActionInfo.nParam2 = HUtil32.Str_ToInt(sParam2, 1);
                }
                if (HUtil32.IsStringNumber(sParam3))
                {
                    QuestActionInfo.nParam3 = HUtil32.Str_ToInt(sParam3, 1);
                }
                if (HUtil32.IsStringNumber(sParam4))
                {
                    QuestActionInfo.nParam4 = HUtil32.Str_ToInt(sParam4, 0);
                }
                if (HUtil32.IsStringNumber(sParam5))
                {
                    QuestActionInfo.nParam5 = HUtil32.Str_ToInt(sParam5, 0);
                }
                if (HUtil32.IsStringNumber(sParam6))
                {
                    QuestActionInfo.nParam6 = HUtil32.Str_ToInt(sParam6, 0);
                }
                if (HUtil32.IsStringNumber(sParam7))
                {
                    QuestActionInfo.nParam7 = HUtil32.Str_ToInt(sParam7, 0);
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 读取脚本文件
        /// </summary>
        /// <param name="NPC"></param>
        /// <param name="sPatch"></param>
        /// <param name="sScritpName"></param>
        /// <param name="boFlag"></param>
        /// <returns></returns>
        public int LoadScriptFile(TNormNpc NPC, string sPatch, string sScritpName, bool boFlag)
        {
            int result;
            int nQuestIdx;
            int I; int n1C; int n20; int n24; int nItemType;
            int nPriceRate; int n6C; int n70;
            string s30 = string.Empty; string s34 = string.Empty; string s38 = string.Empty;
            string s3C = string.Empty; string s40 = string.Empty; string s44 = string.Empty;
            string s48 = string.Empty; string s4C = string.Empty; string s50 = string.Empty;
            TStringList LoadList;
            IList<TDefineInfo> DefineList;
            string s54 = string.Empty; string s58 = string.Empty; string s5C = string.Empty; string s74 = string.Empty;
            TDefineInfo DefineInfo;
            bool bo8D;
            TScript Script;
            TSayingRecord SayingRecord;
            TSayingProcedure SayingProcedure = null;
            TQuestConditionInfo QuestConditionInfo;
            TQuestActionInfo QuestActionInfo;
            TGoods Goods;
            result = -1;
            n6C = 0;
            n70 = 0;
            bo8D = false;
            string sScritpFileName = M2Share.g_Config.sEnvirDir + sPatch + sScritpName + ".txt";
            if (File.Exists(sScritpFileName))
            {
                LoadList = new TStringList();
                try
                {
                    LoadList.LoadFromFile(sScritpFileName);
                }
                catch
                {
                    return result;
                }
                I = 0;
                while (true)
                {
                    LoadScriptFile_LoadScriptcall(ref LoadList);
                    I++;
                    if (I >= 10)
                    {
                        break;
                    }
                }
                DefineList = new List<TDefineInfo>();
                s54 = LoadScriptFile_LoadDefineInfo(ref LoadList, ref DefineList);
                DefineInfo = new TDefineInfo();
                DefineInfo.sName = "@HOME";
                if (s54 == "")
                {
                    s54 = "@main";
                }
                DefineInfo.sText = s54;
                DefineList.Add(DefineInfo);
                // 常量处理
                for (I = 0; I < LoadList.Count; I++)
                {
                    s34 = LoadList[I].Trim();
                    if ((s34 != ""))
                    {
                        if ((s34[0] == '['))
                        {
                            bo8D = false;
                        }
                        else
                        {
                            if ((s34[0] == '#') && (HUtil32.CompareLStr(s34, "#IF", 3) || HUtil32.CompareLStr(s34, "#ACT", 4) || HUtil32.CompareLStr(s34, "#ELSEACT", 8)))
                            {
                                bo8D = true;
                            }
                            else
                            {
                                if (bo8D)
                                {
                                    // 将Define 好的常量换成指定值
                                    for (n20 = 0; n20 < DefineList.Count; n20++)
                                    {
                                        DefineInfo = DefineList[n20];
                                        n1C = 0;
                                        while (true)
                                        {
                                            n24 = s34.ToUpper().IndexOf(DefineInfo.sName);
                                            if (n24 <= 0)
                                            {
                                                break;
                                            }
                                            s58 = s34.Substring(1 - 1, n24 - 1);
                                            s5C = s34.Substring(DefineInfo.sName.Length + n24 - 1, 256);
                                            s34 = s58 + DefineInfo.sText + s5C;
                                            LoadList[I] = s34;
                                            n1C++;
                                            if (n1C >= 10)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // 常量处理
                // 释放常量定义内容
                if (DefineList.Count > 0)
                {
                    for (I = 0; I < DefineList.Count; I++)
                    {
                        if ((DefineList[I]) != null)
                        {
                            Dispose(DefineList[I]);
                        }
                    }
                }
                Dispose(DefineList);// 释放常量定义内容
                Script = null;
                SayingRecord = null;
                nQuestIdx = 0;
                for (I = 0; I < LoadList.Count; I++)
                {
                    s34 = LoadList[I].Trim();
                    if ((s34 == "") || (s34[0] == ';') || (s34[0] == '/'))
                    {
                        continue;
                    }
                    if ((n6C == 0) && boFlag)
                    {
                        if (s34[0] == '%')   // 物品价格倍率
                        {
                            s34 = s34.Substring(2 - 1, s34.Length - 1);
                            nPriceRate = HUtil32.Str_ToInt(s34, -1);
                            if (nPriceRate >= 55)
                            {
                                ((TMerchant)(NPC)).m_nPriceRate = nPriceRate;
                            }
                            continue;
                        }
                        // 物品交易类型
                        if (s34[0] == '+')
                        {
                            s34 = s34.Substring(2 - 1, s34.Length - 1);
                            nItemType = HUtil32.Str_ToInt(s34, -1);
                            if (nItemType >= 0)
                            {
                                ((TMerchant)(NPC)).m_ItemTypeList.Add(nItemType);
                            }
                            continue;
                        }
                        // 增加处理NPC可执行命令设置
                        if (s34[0] == '(')
                        {
                            HUtil32.ArrestStringEx(s34, "(", ")", ref s34);
                            if (s34 != "")
                            {
                                while ((s34 != ""))
                                {
                                    s34 = HUtil32.GetValidStr3(s34, ref s30, new string[] { " ", ",", "\t" });
                                    if (string.Compare(s30, FunctionDef.sBUY, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBuy = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sSELL, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boSell = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sMAKEDURG, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boMakeDrug = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sPRICES, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boPrices = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sSTORAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boStorage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sGETBACK, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetback = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sUPGRADENOW, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boUpgradenow = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sGETBACKUPGNOW, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetBackupgnow = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sREPAIR, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boRepair = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sSUPERREPAIR, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boS_repair = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sSL_SENDMSG, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boSendmsg = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sUSEITEMNAME, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boUseItemName = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sofflinemsg, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boofflinemsg = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sdealgold, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boDealGold = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sBIGSTORAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBigStorage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sBIGGETBACK, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBigGetBack = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sGETPREVIOUSPAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetPreviousPage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sGETNEXTPAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetNextPage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sUserLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boUserLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sWarrorLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boWarrorLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sWizardLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boWizardLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sTaoistLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boTaoistLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sMasterCountOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boMasterCountOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sLyCreateHero, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boHero = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sBuHero, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBuHero = true; // 酒馆英雄NPC
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sPlayMakeWine, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boPlayMakeWine = true;// 酿酒NPC
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sPlayDrink, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boPlayDrink = true;// 请酒,斗酒NPC
                                        continue;
                                    }
                                    if (string.Compare(s30, FunctionDef.sybdeal, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boYBDeal = true;// 元宝寄售NPC属性
                                        continue;
                                    }
                                }
                            }
                            continue;
                        }
                    }
                    if (s34[0] == '{')
                    {
                        if (HUtil32.CompareLStr(s34, "{Quest", 6))
                        {
                            s38 = HUtil32.GetValidStr3(s34, ref s3C, new string[] { " ", "}", "\t" });
                            HUtil32.GetValidStr3(s38, ref s3C, new string[] { " ", "}", "\t" });
                            n70 = HUtil32.Str_ToInt(s3C, 0);
                            Script = LoadScriptFile_MakeNewScript(ref nQuestIdx, ref NPC);
                            Script.nQuest = n70;
                            n70++;
                        }
                        if (HUtil32.CompareLStr(s34, "{~Quest", 7))
                        {
                            continue;
                        }
                    }
                    if ((n6C == 1) && (Script != null) && (s34[0] == '#'))
                    {
                        s38 = HUtil32.GetValidStr3(s34, ref s3C, new string[] { "=", " ", "\t" });
                        Script.boQuest = true;
                        if (HUtil32.CompareLStr(s34, "#IF", 3))
                        {
                            HUtil32.ArrestStringEx(s34, "[", "]", ref s40);
                            Script.QuestInfo[nQuestIdx].wFlag = (ushort)HUtil32.Str_ToInt(s40, 0);
                            HUtil32.GetValidStr3(s38, ref s44, new string[] { "=", " ", "\t" });
                            n24 = HUtil32.Str_ToInt(s44, 0);
                            if (n24 != 0)
                            {
                                n24 = 1;
                            }
                            Script.QuestInfo[nQuestIdx].btValue = (byte)n24;
                        }
                        if (HUtil32.CompareLStr(s34, "#RAND", 5))
                        {
                            Script.QuestInfo[nQuestIdx].nRandRage = HUtil32.Str_ToInt(s44, 0);
                        }
                        continue;
                    }
                    if (s34[0] == '[')
                    {
                        n6C = 10;
                        if (Script == null)
                        {
                            Script = LoadScriptFile_MakeNewScript(ref nQuestIdx, ref NPC);
                            Script.nQuest = n70;
                        }
                        if (string.Compare(s34, "[goods]", true) == 0)
                        {
                            n6C = 20;
                            continue;
                        }
                        s34 = HUtil32.ArrestStringEx(s34, "[", "]", ref s74);
                        SayingRecord = new TSayingRecord();
                        SayingRecord.ProcedureList = new List<TSayingProcedure>();
                        SayingRecord.sLabel = s74;
                        s34 = HUtil32.GetValidStrCap(s34, ref s74, new string[] { " ", "\t" });
                        if (string.Compare(s74, "TRUE", true) == 0)
                        {
                            SayingRecord.boExtJmp = true;
                        }
                        else
                        {
                            SayingRecord.boExtJmp = false;
                        }
                        SayingProcedure = new TSayingProcedure();
                        SayingRecord.ProcedureList.Add(SayingProcedure);
                        SayingProcedure.ConditionList = new List<TQuestConditionInfo>();
                        SayingProcedure.ActionList = new List<TQuestActionInfo>();
                        SayingProcedure.sSayMsg = "";
                        SayingProcedure.ElseActionList = new List<TQuestActionInfo>();
                        SayingProcedure.sElseSayMsg = "";
                        Script.RecordList.Add(SayingRecord);
                        continue;
                    }
                    if ((Script != null) && (SayingRecord != null))
                    {
                        if ((n6C >= 10) && (n6C < 20) && (s34[0] == '#'))
                        {
                            if (string.Compare(s34, "#IF", true) == 0)
                            {
                                if ((SayingProcedure.ConditionList.Count > 0) || (SayingProcedure.sSayMsg != ""))
                                {
                                    SayingProcedure = new TSayingProcedure();
                                    SayingRecord.ProcedureList.Add(SayingProcedure);
                                    SayingProcedure.ConditionList = new List<TQuestConditionInfo>();
                                    SayingProcedure.ActionList = new List<TQuestActionInfo>();
                                    SayingProcedure.sSayMsg = "";
                                    SayingProcedure.ElseActionList = new List<TQuestActionInfo>();
                                    SayingProcedure.sElseSayMsg = "";
                                }
                                n6C = 11;
                            }
                            if (string.Compare(s34, "#ACT", true) == 0)
                            {
                                n6C = 12;
                            }
                            if (string.Compare(s34, "#SAY", true) == 0)
                            {
                                n6C = 10;
                            }
                            if (string.Compare(s34, "#ELSEACT", true) == 0)
                            {
                                n6C = 13;
                            }
                            if (string.Compare(s34, "#ELSESAY", true) == 0)
                            {
                                n6C = 14;
                            }
                            continue;
                        }
                        if ((n6C == 10) && (SayingProcedure != null))
                        {
                            SayingProcedure.sSayMsg = SayingProcedure.sSayMsg + s34;
                        }
                        if ((n6C == 11))
                        {
                            QuestConditionInfo = new TQuestConditionInfo();
                            if (LoadScriptFile_QuestCondition(s34.Trim(), ref QuestConditionInfo))
                            {
                                SayingProcedure.ConditionList.Add(QuestConditionInfo);
                            }
                            else
                            {
                                Dispose(QuestConditionInfo);
                                M2Share.MainOutMessage("脚本错误1: " + s34 + " 第:" + (I).ToString() + " 行: " + sScritpFileName);
                            }
                        }
                        if ((n6C == 12))
                        {
                            QuestActionInfo = new TQuestActionInfo();
                            if (LoadScriptFile_QuestAction(s34.Trim(), ref QuestActionInfo))
                            {
                                SayingProcedure.ActionList.Add(QuestActionInfo);
                            }
                            else
                            {
                                Dispose(QuestActionInfo);
                                M2Share.MainOutMessage("脚本错误2: " + s34 + " 第:" + (I).ToString() + " 行: " + sScritpFileName);
                            }
                        }
                        if ((n6C == 13))
                        {
                            QuestActionInfo = new TQuestActionInfo();
                            if (LoadScriptFile_QuestAction(s34.Trim(), ref QuestActionInfo))
                            {
                                SayingProcedure.ElseActionList.Add(QuestActionInfo);
                            }
                            else
                            {
                                Dispose(QuestActionInfo);
                                M2Share.MainOutMessage("脚本错误3: " + s34 + " 第:" + (I).ToString() + " 行: " + sScritpFileName);
                            }
                        }
                        if ((n6C == 14))
                        {
                            SayingProcedure.sElseSayMsg = SayingProcedure.sElseSayMsg + s34;
                        }
                    }
                    if ((n6C == 20) && boFlag)
                    {
                        s34 = HUtil32.GetValidStrCap(s34, ref s48, new string[] { " ", "\t" });
                        s34 = HUtil32.GetValidStrCap(s34, ref s4C, new string[] { " ", "\t" });
                        s34 = HUtil32.GetValidStrCap(s34, ref s50, new string[] { " ", "\t" });
                        if ((s48 != "") && (s50 != ""))
                        {
                            Goods = new TGoods();
                            if ((s48 != "") && (s48[0] == '\''))
                            {
                                HUtil32.ArrestStringEx(s48, "\"", "\"", ref s48);
                            }
                            Goods.sItemName = s48;
                            Goods.nCount = HUtil32.Str_ToInt(s4C, 0);
                            Goods.dwRefillTime = (uint)HUtil32.Str_ToInt(s50, 0);
                            Goods.dwRefillTick = 0;
                            ((TMerchant)(NPC)).m_RefillGoodsList.Add(Goods);
                        }
                    }
                }
            }
            else
            {
                M2Share.MainOutMessage("脚本文件未找到: " + sScritpFileName);
            }

            result = 1;
            return result;
        }

        public void Dispose(object obj)
        {
            if (obj != null)
            {
                GC.KeepAlive(obj);
                GC.ReRegisterForFinalize(obj);
            }
        }
    }
}
