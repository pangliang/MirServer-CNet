using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DBServer;
using DBServer.Entity;
using GameFramework;
using NetFramework;

namespace DBServer
{
    /// <summary>
    /// 服务端客户端
    /// </summary>
    public class TServerClient
    {
        public uint m_dwKeepAliveTick = 0;//心跳包时间
        public string m_sReceiveText = String.Empty;//接收到的消息
        public TModuleInfo m_Module = null;//模块
        public uint m_dwCheckServerTimeMin = 0;//检查服务器最小时间
        public uint m_dwCheckServerTimeMax = 0;//检查服务器最大时间
        public uint m_dwCheckRecviceTick = 0;//检查接收包时间
        private string m_sQueryID = String.Empty;//查询帐号
        private TDefaultMessage m_DefMsg;///默认消息
        private AsyncUserToken Socket = null;//客户段
        private TFrmIDSoc FrmIDSoc = null;//会话管理

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="e"></param>
        /// <param name="FrmIDSoc"></param>
        public TServerClient(AsyncUserToken e,TFrmIDSoc FrmIDSoc)
        {
            m_dwKeepAliveTick = GameFramework.HUtil32.GetTickCount();
            m_sReceiveText = "";
            m_sQueryID = "";
            m_Module = null;
            m_dwCheckServerTimeMin = GameFramework.HUtil32.GetTickCount();
            m_dwCheckServerTimeMax = 0;
            m_dwCheckRecviceTick = GameFramework.HUtil32.GetTickCount();
            Socket = e;
            this.FrmIDSoc = FrmIDSoc;
        }

        /// <summary>
        /// 心跳包
        /// </summary>
        public void SendKeepAlivePacket()
        {
            m_dwKeepAliveTick = GameFramework.HUtil32.GetTickCount();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sMsg"></param>
        private void SendSocket(string sMsg)
        {
            int n10 = HUtil32.MakeLong(HUtil32.Str_ToInt(m_sQueryID, 0) ^ 170, sMsg.Length + 6);
            string s18 = EncryptUnit.EncodeBuffer(BitConverter.GetBytes(n10), 4);
            Socket.Socket.Send(System.Text.Encoding.Default.GetBytes('#' + m_sQueryID + '/' + sMsg + s18 + '!'));
        }

        /// <summary>
        /// 处理服务器包
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufLen"></param>
        public void ProcessServerPacket(string Buffer, int BufLen)
        {
            bool bo25 = false;
            int nC = 0;
            //string sReceiveText = string.Empty;
            string sC;
            string s1C;
            string s20 = string.Empty;
            string s24 = string.Empty;
            int n14;
            int n18;
            ushort wE;
            ushort w10;
            TDefaultMessage DefMsg;
            try
            {
                m_sQueryID = "";
                m_dwKeepAliveTick = GameFramework.HUtil32.GetTickCount();
                string sReceiveText = Buffer;
                m_sReceiveText = m_sReceiveText + sReceiveText;
#if DEBUG
                DBShare.MainOutMessage("ServerClient.m_sReceiveText:"+m_sReceiveText);
#endif
                while (true)
                {
                    if (m_sReceiveText.IndexOf('!') <= 0)
                    {
                        break;
                    }
                    //获取一条数据放入s20
                    m_sReceiveText = GameFramework.HUtil32.ArrestStringEx(m_sReceiveText, "#", "!", ref s20);
                    if (s20 != "")//如果s20不为空
                    {
                        if (s20.Length > 2)//并且大于2
                        {
                            s20 = GameFramework.HUtil32.GetValidStr3(s20, ref s24, new string[] { "/" });
                            n14 = s20.Length;
                            if ((n14 >= Grobal2.DEFBLOCKSIZE) && (s24 != ""))
                            {
                                m_sQueryID = s24;
                                wE = (ushort)(GameFramework.HUtil32.Str_ToInt(s24, 0) ^ 170);
                                w10 = (ushort)n14;
                                n18 = GameFramework.HUtil32.MakeLong(wE, w10);
                                sC = EncryptUnit.EncodeBuffer(BitConverter.GetBytes(n18), 4);
                                if (HUtil32.CompareBackLStr(s20, sC))
                                {
                                    ProcessServerMsg(s20, n14);
                                    bo25 = true;
                                    m_sReceiveText = "";
                                    break;
                                }
                                else
                                {
                                    m_DefMsg = EncryptUnit.MakeDefaultMsg(Common.DBR_FAIL, 0, 0, 0, 0);
                                    SendSocket(EncryptUnit.EncodeMessage(m_DefMsg));
                                    m_sReceiveText = "";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            m_sReceiveText = "";
                            break;
                        }
                    }
                    else
                    {
                        // 防止DBS溢出攻击
                        if (nC >= 1)
                        {
                            m_sReceiveText = "";
                            break;
                        }
                        nC++;
                    }
                }
                m_dwCheckServerTimeMin = GameFramework.HUtil32.GetTickCount() - m_dwCheckRecviceTick;
                if (m_dwCheckServerTimeMin > m_dwCheckServerTimeMax)
                {
                    m_dwCheckServerTimeMax = m_dwCheckServerTimeMin;
                }
                m_dwCheckRecviceTick = GameFramework.HUtil32.GetTickCount();
                if (m_Module != null)
                {
                    m_Module.Buffer = string.Format("{0}/{1}", m_dwCheckServerTimeMin, m_dwCheckServerTimeMax);
                }
            }
            catch
            {
                DBShare.MainOutMessage("[Exception] TDBSERVER::ProcessServerPacket");
            }
        }

        /// <summary>
        /// 处理服务器消息
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="nLen"></param>
        private void ProcessServerMsg(string sMsg, int nLen)
        {
            string sDefMsg;//消息头
            string sData;
            TDefaultMessage DefMsg;
            if (nLen == Grobal2.DEFBLOCKSIZE)
            {
                sDefMsg = sMsg;
                sData = "";
            }
            else
            {
                sDefMsg = sMsg.Substring(1 - 1 ,Grobal2.DEFBLOCKSIZE);
                sData = sMsg.Substring(Grobal2.DEFBLOCKSIZE + 1 - 1 ,sMsg.Length - Grobal2.DEFBLOCKSIZE - 6);
            }
            DefMsg = EncryptUnit.DecodeMessage(sDefMsg);
            DBShare.g_nWorkStatus = DefMsg.Ident;
            switch(DefMsg.Ident)
            {
                case Common.DB_LOADHUMANRCD:
                    LoadHumanRcd(sData);
                    break;
                case Common.DB_SAVEHUMANRCD:
                    SaveHumanRcd(DefMsg.Recog, sData);
                    break;
                case Common.DB_LOADHERORCD:
                    // DB_SAVEHUMANRCDEX: begin
                    // SaveHumanRcdEx(sData, DefMsg.Recog, Socket);
                    // end;
                    // 读取英雄数据
                    LoadHeroRcd(sData);
                    break;
                case Common.DB_NEWHERORCD:
                    // 新建英雄
                    NewHeroRcd(sData);
                    break;
                case Common.DB_DELHERORCD:
                    // 删除英雄
                    DeleteHeroRcd(sData);
                    break;
                case Common.DB_SAVEHERORCD:
                    // 保存英雄数据
                    SaveHeroRcd(DefMsg.Recog, sData);
                    break;
                case Common.DB_LOADRANKING:
                    // 排行榜
                    LoadRanking(sData, DefMsg);
                    break;
                case Common.DB_SAVEMAGICLIST:
                    SaveMagicList(DefMsg.Recog, sData);
                    break;
                case Common.DB_SAVESTDITEMLIST:
                    SaveStdItemList(DefMsg.Recog, sData);
                    break;
                case Common.DB_CLOSESOCKET:
                    break;
                case Common.DB_SENDKEEPALIVE:
                    break;
                default:
                    m_DefMsg = EncryptUnit.MakeDefaultMsg(Common.DBR_FAIL, 0, 0, 0, 0,0);
                    SendSocket(EncryptUnit.EncodeMessage(m_DefMsg));
                    break;
            }
        }

        /// <summary>
        /// 保存魔法列表
        /// </summary>
        /// <param name="nMagicCount"></param>
        /// <param name="sMsg"></param>
        private void SaveMagicList(int nMagicCount, string sMsg)
        {
            //string sIdx;
            //string sData;
            //string sName;
            //int nIdx;
            //DBShare.Units.DBShare.UnLoadMagicList();
            //sData = EncryptUnit.Units.EncryptUnit.DeCodeString(sMsg);
            //while (true)
            //{
            //    if (sData == "")
            //    {
            //        break;
            //    }
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sIdx, new char[] {'/'});
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sName, new char[] {'/'});
            //    //@ Undeclared identifier(3): 'Str_ToInt'
            //    nIdx = Str_ToInt(sIdx,  -1);
            //    if ((nIdx > 0) && (sName != ""))
            //    {
            //        DBShare.Units.DBShare.g_MagicList.Add(sName, ((nIdx) as Object));
            //    // MainOutMessage(sName);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_SAVEMAGICLIST, 1, 0, 0, 0);
            //SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(m_DefMsg));
            ////@ Unsupported function or procedure: 'Format'
            //DBShare.Units.DBShare.MainOutMessage(Format("技能数据库加载完成(%d)...", new int[] {DBShare.Units.DBShare.g_MagicList.Count}));
        }

        /// <summary>
        /// 保存标准物品列表
        /// </summary>
        /// <param name="nItemCount"></param>
        /// <param name="sMsg"></param>
        private void SaveStdItemList(int nItemCount, string sMsg)
        {
            //string sData;
            //string sName;
            //DBShare.Units.DBShare.UnLoadStdItemList();
            //sData = EncryptUnit.Units.EncryptUnit.DeCodeString(sMsg);
            //while (true)
            //{
            //    if (sData == "")
            //    {
            //        break;
            //    }
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sName, new char[] {'/'});
            //    if (sName != "")
            //    {
            //        DBShare.Units.DBShare.g_StdItemList.Add(sName);
            //    // MainOutMessage(sName);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_SAVESTDITEMLIST, 1, 0, 0, 0);
            //SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(m_DefMsg));
            ////@ Unsupported function or procedure: 'Format'
            //DBShare.Units.DBShare.MainOutMessage(Format("物品数据库加载完成(%d)...", new int[] {DBShare.Units.DBShare.g_StdItemList.Count}));
        }

        /// <summary>
        /// 载入角色记录
        /// </summary>
        /// <param name="sMsg"></param>
        private unsafe void LoadHumanRcd(string sMsg)
        {
            string sHumName;
            string sAccount;
            string sIPaddr;
            int nSessionID;
            int nCheckCode;
            THumDataInfo HumanRCD;
            bool boFoundSession = false ;
            TLoadHuman* pLoadHuman;
            pLoadHuman = (TLoadHuman * )Marshal.AllocHGlobal(sizeof(TLoadHuman));
            EncryptUnit.DecodeBuffer(sMsg, pLoadHuman, sizeof(TLoadHuman));
            sAccount = HUtil32.SBytePtrToString(pLoadHuman->sAccount,0,30).TrimEnd('\0');
            sHumName = HUtil32.SBytePtrToString(pLoadHuman->sChrName, 0, 14).TrimEnd('\0');
            sIPaddr = HUtil32.SBytePtrToString(pLoadHuman->sUserAddr, 0, 15).TrimEnd('\0');
            nSessionID = pLoadHuman->nSessionID;
            nCheckCode = -1;
            if ((sAccount != "") && (sHumName != ""))
            {
                if ((FrmIDSoc.CheckSessionLoadRcd(sAccount, sIPaddr, nSessionID, ref boFoundSession)))
                {
                    nCheckCode = 1;
                }
                else
                {
                    if (boFoundSession)
                    {
                        DBShare.MainOutMessage("[非法重复请求] " + "帐号: " + sAccount + " IP: " + sIPaddr + " 标识: " + (nSessionID).ToString());
                    }
                    else
                    {
                        DBShare.MainOutMessage("[非法请求] " + "帐号: " + sAccount + " IP: " + sIPaddr + " 标识: " + (nSessionID).ToString());
                    }
                    // nCheckCode:= 1; //测试用，正常去掉
                }
            }
            if (nCheckCode == 1)
            {
                try
                {
                    HumanRCD = DBShare.g_HumDataDB.Get(sHumName);
                    if (HumanRCD.Header.NameLen > 0)
                    {
                        if (HumanRCD.Header.NameLen < 0)
                        {
                            nCheckCode = -2;
                        }
                    }
                    else
                    {
                        nCheckCode = -3;
                    }
                }catch
                {
                    nCheckCode = -4;
                }
            }
            if (nCheckCode == 1)
            {
                DBShare.g_nLoadHumCount++;
                m_DefMsg = EncryptUnit.MakeDefaultMsg(Common.DBR_LOADHUMANRCD, 1, 0, 0, 1);
                SendSocket(EncryptUnit.EncodeMessage(m_DefMsg) + EncryptUnit.EncodeString(sHumName) + '/' + EncryptUnit.EncodeBuffer(&HumanRCD, sizeof(THumDataInfo)));
            }
            else
            {
                m_DefMsg = EncryptUnit.MakeDefaultMsg(Common.DBR_LOADHUMANRCD, nCheckCode, 0, 0, 0);
                SendSocket(EncryptUnit.EncodeMessage(m_DefMsg));
            }
        }

        /// <summary>
        /// 保存角色数据
        /// </summary>
        /// <param name="nRecog"></param>
        /// <param name="sMsg"></param>
        private unsafe void SaveHumanRcd(int nRecog, string sMsg)
        {
            string sChrName = string.Empty;
            string sUserID = string.Empty;
            string sHumanRCD = string.Empty;
            int I;
            int nIndex;
            bool bo21;
            TDefaultMessage DefMsg;
            THumDataInfo *HumanRCD;
            THumDataInfo HumDataInfo;
            sHumanRCD = HUtil32.GetValidStr3(sMsg,ref sUserID, new string[] { "/" });
            sHumanRCD = HUtil32.GetValidStr3(sHumanRCD,ref sChrName, new string[] { "/" });
            sUserID = EncryptUnit.DeCodeString(sUserID);
            sChrName = EncryptUnit.DeCodeString(sChrName);
            bo21 = false;
            HumanRCD = (THumDataInfo*)Marshal.AllocHGlobal(sizeof(THumDataInfo));
            HUtil32.ZeroMemory((IntPtr)(&HumanRCD->Data), (IntPtr)sizeof(THumData));
            int THumDataInfoLength = DBShare.GetCodeMsgSize(sizeof(THumDataInfo) * 4 / 3)+1;
            if (sHumanRCD.Length ==THumDataInfoLength)
            {
                EncryptUnit.DecodeBuffer(sHumanRCD, HumanRCD, sizeof(THumDataInfo));
            }
            else
            {
                bo21 = true;
            }
            if (!bo21)
            {
                bo21 = true;
                try
                {
                        HumDataInfo = DBShare.g_HumDataDB.Get(sChrName);
                        //nIndex = DBShare.g_HumDataDB.Index(sChrName);
                        if (HumDataInfo.Header.NameLen <= 0)
                        {
                            HumanRCD->Header.boDeleted = false;
                            HumanRCD->Header.dCreateDate = DateTime.Now.ToOADate();
                            //sChrName.StrToSbyte(HumanRCD->Header.sName, 15,ref HumanRCD->Header.NameLen);
                            HumanRCD->Header.sName = sChrName;
                            HumanRCD->Header.boIsHero = false;
                            DBShare.g_HumDataDB.Add(ref *HumanRCD);
                            //nIndex = DBShare.g_HumDataDB.Index(sChrName);
                        }
                        HumDataInfo = DBShare.g_HumDataDB.Get(sChrName);
                        if (HumDataInfo.Header.NameLen > 0)
                        {
                            HumanRCD->Header = HumDataInfo.Header;
                            DBShare.g_HumDataDB.Update(sChrName, ref *HumanRCD);
                            bo21 = false;
                            DBShare.g_nSaveHumCount++;
                        }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                FrmIDSoc.SetSessionSaveRcd(sUserID);
            }
            if (!bo21)
            {
                m_DefMsg = EncryptUnit.MakeDefaultMsg(Common.DBR_SAVEHUMANRCD, 1, 0, 0, 0);
                SendSocket(EncryptUnit.EncodeMessage(m_DefMsg));
            }
            else
            {
                m_DefMsg = EncryptUnit.MakeDefaultMsg(Common.DBR_LOADHUMANRCD, 0, 0, 0, 0);
                SendSocket(EncryptUnit.EncodeMessage(m_DefMsg));
                DBShare.MainOutMessage("SaveHumanRcd Fail,UserID:sUserID,ChrName:sChrName");
            }
        }

        /// <summary>
        /// 删除英雄数据
        /// </summary>
        /// <param name="sMsg"></param>
        private void DeleteHeroRcd(string sMsg)
        {
            string sData;
            string sAccount = string.Empty;
            string sChrName = string.Empty;
            bool boCheck;
            int n10;
            int n12;
            HumInfo HumRecord;
            THumDataInfo HumanRCD;
            n12 = 0;
            sData = EncryptUnit.DeCodeString(sMsg);
            sData = HUtil32.GetValidStr3(sData,ref sAccount, new string[] { "/" });
            sData = HUtil32.GetValidStr3(sData,ref sChrName, new string[] { "/" });
            boCheck = false;
            try
            {
                    HumRecord = DBShare.g_HumCharDB.FindObjectByChrName(sChrName);
                    if (HumRecord != null)
                    {
                        //HumRecord = DBShare.g_HumCharDB.FindObjectByChrName(sChrName);
                        if (HumRecord != null && HumRecord.boIsHero.Value)
                        {
                            if (DBShare.g_HumCharDB.Delete(sChrName))
                            {
                                n12 = 1;
                            }
                            DBShare.g_nDeleteHeroCount++;
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (n12 == 1)
            {
                try
                {
                    HumanRCD = DBShare.g_HumDataDB.Get(sChrName);
                    if (HumanRCD.Header.NameLen >0)
                    {
                        if (HumanRCD.Header.NameLen > 0 && HumanRCD.Header.boIsHero)
                        {
                            if (DBShare.g_HumDataDB.Delete(sChrName))
                            {
                                n12 = 1;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            m_DefMsg = EncryptUnit.MakeDefaultMsg(Common.DBR_DELHERORCD, n12, 0, 0, 0);
            SendSocket(EncryptUnit.EncodeMessage(m_DefMsg));
        }

        /// <summary>
        /// 新建英雄记录数据
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sChrName"></param>
        /// <param name="nSex"></param>
        /// <param name="nJob"></param>
        /// <param name="nHair"></param>
        /// <returns></returns>
        public bool NewHeroRcd_NewHeroData(string sAccount, string sChrName, int nSex, int nJob, int nHair)
        {
            return false;
            //bool result;
            //THumDataInfo ChrRecord;
            //result = false;
            //try {
            //    if (DBShare.Units.DBShare.g_HumDataDB.Open() && (DBShare.Units.DBShare.g_HumDataDB.Index(sChrName) ==  -1))
            //    {
            //        //@ Unsupported function or procedure: 'FillChar'
            //        FillChar(ChrRecord, sizeof(THumDataInfo), '\0');
            //        ChrRecord.Header.dCreateDate = DateTime.Now;
            //        ChrRecord.Header.boIsHero = true;
            //        ChrRecord.Header.sName = sChrName;
            //        ChrRecord.Header.boDeleted = false;
            //        ChrRecord.Data.sChrName = sChrName;
            //        ChrRecord.Data.sAccount = sAccount;
            //        ChrRecord.Data.btSex = nSex;
            //        ChrRecord.Data.btJob = nJob;
            //        ChrRecord.Data.btHair = nHair;
            //        ChrRecord.Data.boHasHero = false;
            //        ChrRecord.Data.boIsHero = true;
            //        result = DBShare.Units.DBShare.g_HumDataDB.Add(ChrRecord);
            //        DBShare.Units.DBShare.g_nCreateHeroCount ++;
            //    }
            //} finally {
            //    DBShare.Units.DBShare.g_HumDataDB.Close();
            //}
            //return result;
        }

        /// <summary>
        /// 新建英雄记录
        /// </summary>
        /// <param name="sMsg"></param>
        private void NewHeroRcd(string sMsg)
        {
            //string sData;
            //string sAccount;
            //string sCharName;
            //string sHeroName;
            //string sHair;
            //string sJob;
            //string sSex;
            //int nCode;
            //THumInfo HumRecord;
            //THumDataInfo HumanRCD;
            //int nIndex;
            //int I;
            //int nError;
            //nCode =  -1;
            //nError = 0;
            //try {
            //    sData = EncryptUnit.Units.EncryptUnit.DeCodeString(sMsg);
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sAccount, new char[] {'/'});
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sCharName, new char[] {'/'});
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sHeroName, new char[] {'/'});
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sHair, new char[] {'/'});
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sJob, new char[] {'/'});
            //    //@ Undeclared identifier(3): 'GetValidStr3'
            //    sData = GetValidStr3(sData, sSex, new char[] {'/'});
            //    nError = 1;
            //    if ((sAccount != "") && (sCharName != "") && (sHeroName != "") && (sHair != "") && (sJob != "") && (sSex != ""))
            //    {
            //        if (nCode ==  -1)
            //        {
            //            if (sData.Trim() != "")
            //            {
            //                nCode = 0;
            //            }
            //            sHeroName = sHeroName.Trim();
            //            if (sHeroName.Length < 3)
            //            {
            //                nCode = 0;
            //            }
            //            nError = 8;
            //            if (!DBShare.Units.DBShare.CheckDenyChrName(sHeroName))
            //            {
            //                nCode = 0;
            //            }
            //            nError = 9;
            //            if (!DBShare.Units.DBShare.CheckAIChrName(sHeroName))
            //            {
            //                nCode = 0;
            //            }
            //            nError = 10;
            //            if (!DBShare.Units.DBShare.CheckChrName(sHeroName))
            //            {
            //                nCode = 0;
            //            }
            //            nError = 11;
            //            if (!DBShare.Units.DBShare.g_boDenyChrName)
            //            {
            //                for (I = 1; I <= sHeroName.Length; I ++ )
            //                {
            //                    if ((sHeroName[I] == '?') || (sHeroName[I] == ' ') || (sHeroName[I] == '/') || (sHeroName[I] == '@') || (sHeroName[I] == '?') || (sHeroName[I] == '\'') || (sHeroName[I] == '\"') || (sHeroName[I] == '\\') || (sHeroName[I] == '.') || (sHeroName[I] == ',') || (sHeroName[I] == ':') || (sHeroName[I] == ';') || (sHeroName[I] == '`') || (sHeroName[I] == '~') || (sHeroName[I] == '!') || (sHeroName[I] == '#') || (sHeroName[I] == '$') || (sHeroName[I] == '%') || (sHeroName[I] == '^') || (sHeroName[I] == '&') || (sHeroName[I] == '*') || (sHeroName[I] == '(') || (sHeroName[I] == ')') || (sHeroName[I] == '-') || (sHeroName[I] == '_') || (sHeroName[I] == '+') || (sHeroName[I] == '=') || (sHeroName[I] == '|') || (sHeroName[I] == '[') || (sHeroName[I] == '{') || (sHeroName[I] == ']') || (sHeroName[I] == '}'))
            //                    {
            //                        nCode = 0;
            //                    }
            //                }
            //            }
            //        }
            //        nError = 12;
            //        if (nCode ==  -1)
            //        {
            //            try {
            //                DBShare.Units.DBShare.g_HumCharDB.__Lock();
            //                if (DBShare.Units.DBShare.g_HumCharDB.Index(sHeroName) >= 0)
            //                {
            //                    nCode = 2;
            //                }
            //            } finally {
            //                DBShare.Units.DBShare.g_HumCharDB.UnLock();
            //            }
            //            if (nCode ==  -1)
            //            {
            //                try {
            //                    DBShare.Units.DBShare.g_HumDataDB.__Lock();
            //                    if (DBShare.Units.DBShare.g_HumDataDB.Index(sHeroName) >= 0)
            //                    {
            //                        nCode = 2;
            //                    }
            //                } finally {
            //                    DBShare.Units.DBShare.g_HumDataDB.UnLock();
            //                }
            //            }
            //            nError = 13;
            //            if (nCode ==  -1)
            //            {
            //                nError = 14;
            //                //@ Unsupported function or procedure: 'FillChar'
            //                FillChar(HumRecord, sizeof(THumInfo), '\0');
            //                try {
            //                    if (DBShare.Units.DBShare.g_HumCharDB.Open())
            //                    {
            //                        HumRecord.Header.boDeleted = false;
            //                        HumRecord.Header.boIsHero = true;
            //                        HumRecord.Header.dCreateDate = DateTime.Now;
            //                        HumRecord.Header.sName = sHeroName;
            //                        HumRecord.Header.nSelectID = 0;
            //                        HumRecord.sChrName = sHeroName;
            //                        HumRecord.sAccount = sAccount;
            //                        HumRecord.boDeleted = false;
            //                        HumRecord.btCount = 0;
            //                        HumRecord.sChrName = sHeroName;
            //                        HumRecord.boSelected = true;
            //                        HumRecord.boIsHero = true;
            //                        if (HumRecord.sChrName != "")
            //                        {
            //                            if (!DBShare.Units.DBShare.g_HumCharDB.Add(HumRecord))
            //                            {
            //                                nCode = 4;
            //                            }
            //                        }
            //                    }
            //                } finally {
            //                    DBShare.Units.DBShare.g_HumCharDB.Close();
            //                }
            //            }
            //            nError = 15;
            //            if (nCode ==  -1)
            //            {
            //                nError = 16;
            //                //@ Undeclared identifier(3): 'Str_ToInt'
            //                //@ Undeclared identifier(3): 'Str_ToInt'
            //                //@ Undeclared identifier(3): 'Str_ToInt'
            //                if (NewHeroRcd_NewHeroData(sAccount, sHeroName, Str_ToInt(sSex, 0), Str_ToInt(sJob, 0), Str_ToInt(sHair, 0)))
            //                {
            //                    nCode = 1;
            //                }
            //                nError = 17;
            //            }
            //            else
            //            {
            //                nError = 18;
            //                try {
            //                    if (DBShare.Units.DBShare.g_HumCharDB.Open())
            //                    {
            //                        DBShare.Units.DBShare.g_HumCharDB.Delete(sHeroName);
            //                    }
            //                } finally {
            //                    DBShare.Units.DBShare.g_HumCharDB.Close();
            //                }
            //                nError = 19;
            //                nCode = 4;
            //            }
            //        }
            //    }
            //}
            //catch {
            //    DBShare.Units.DBShare.MainOutMessage("[Exception] TDBSERVER::NewHeroRcd:" + (nError).ToString());
            //}
            //m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_NEWHERORCD, nCode, 0, 0, 0);
            //SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(m_DefMsg));
        }

        /// <summary>
        /// 载入英雄记录
        /// </summary>
        /// <param name="sMsg"></param>
        private void LoadHeroRcd(string sMsg)
        {
            //string sHumName;
            //string sAccount;
            //string sIPaddr;
            //int nIndex;
            //int nSessionID;
            //int nCheckCode;
            //TDefaultMessage DefMsg;
            //THumInfo HumRecord;
            //THumDataInfo HumanRCD;
            //TLoadHuman LoadHuman;
            //bool boFoundSession;
            //EncryptUnit.Units.EncryptUnit.DecodeBuffer(sMsg, LoadHuman, sizeof(TLoadHuman));
            //sAccount = LoadHuman.sAccount;
            //sHumName = LoadHuman.sChrName;
            //sIPaddr = LoadHuman.sUserAddr;
            //nSessionID = LoadHuman.nSessionID;
            //// MainOutMessage(Format('LoadHeroRcd1 %s %s %s', [sAccount, sHumName, sIPaddr]));
            //// MainOutMessage('TServerClient.LoadHumanRcd: ' + sAccount + ' IP: ' + sIPaddr + ' 标识: ' + IntToStr(nSessionID));
            //nCheckCode =  -1;
            //if ((sAccount != "") && (sHumName != ""))
            //{
            //    nCheckCode = 1;
            //}
            //if (nCheckCode == 1)
            //{
            //    // MainOutMessage(Format('LoadHeroRcd3 %s %s %s', [sAccount, sHumName, sIPaddr]));
            //    try {
            //        if (DBShare.Units.DBShare.g_HumDataDB.Open())
            //        {
            //            nIndex = DBShare.Units.DBShare.g_HumDataDB.Index(sHumName);
            //            // MainOutMessage(Format('LoadHeroRcd4 %s %s %s', [sAccount, sHumName, sIPaddr]));
            //            if (nIndex >= 0)
            //            {
            //                // MainOutMessage(Format('LoadHeroRcd5 %s %s %s', [sAccount, sHumName, sIPaddr]));
            //                if (DBShare.Units.DBShare.g_HumDataDB.Get(nIndex, HumanRCD) < 0)
            //                {
            //                    nCheckCode =  -2;
            //                }
            //            }
            //            else
            //            {
            //                nCheckCode =  -3;
            //            }
            //        }
            //        else
            //        {
            //            nCheckCode =  -4;
            //        }
            //    } finally {
            //        DBShare.Units.DBShare.g_HumDataDB.Close();
            //    }
            //}
            //// MainOutMessage(Format('LoadHeroRcd1 %s %s %s %d', [sAccount, sHumName, sIPaddr, nCheckCode]));
            //if (nCheckCode == 1)
            //{
            //    // MainOutMessage('TServerClient.LoadHumanRcd: HumanRCD.Data.Abil.Level: ' + IntToStr(HumanRCD.Data.Abil.Level));
            //    // MainOutMessage('TServerClient.LoadHumanRcd: HumanRCD.Data.sHomeMap: ' + HumanRCD.Data.sHomeMap + ' ChrName' + HumanRCD.Data.sChrName + ' Account:' + HumanRCD.Data.sAccount + ' HumName:' + sHumName);
            //    DBShare.Units.DBShare.g_nLoadHeroCount ++;
            //    m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_LOADHERORCD, 1, 0, 0, 1);
            //    SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(m_DefMsg) + EncryptUnit.Units.EncryptUnit.EncodeString(sHumName) + '/' + EncryptUnit.Units.EncryptUnit.EncodeBuffer(HumanRCD, sizeof(THumDataInfo)));
            //}
            //else
            //{
            //    if ((nCheckCode ==  -2) || (nCheckCode ==  -3))
            //    {
            //        m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_NOTCREATEHERO, nCheckCode, 0, 0, 0);
            //    }
            //    else
            //    {
            //        m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_LOADHERORCD, nCheckCode, 0, 0, 0);
            //    }
            //    SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(m_DefMsg));
            //}
        }

        /// <summary>
        /// 保存英雄记录
        /// </summary>
        /// <param name="nRecog"></param>
        /// <param name="sMsg"></param>
        private void SaveHeroRcd(int nRecog, string sMsg)
        {
            //string sChrName;
            //string sUserID;
            //string sHumanRCD;
            //int I;
            //int nIndex;
            //bool bo21;
            //TDefaultMessage DefMsg;
            //THumDataInfo HumanRCD;
            //THumDataInfo HumDataInfo;
            ////@ Undeclared identifier(3): 'GetValidStr3'
            //sHumanRCD = GetValidStr3(sMsg, sUserID, new char[] {'/'});
            ////@ Undeclared identifier(3): 'GetValidStr3'
            //sHumanRCD = GetValidStr3(sHumanRCD, sChrName, new char[] {'/'});
            //sUserID = EncryptUnit.Units.EncryptUnit.DeCodeString(sUserID);
            //sChrName = EncryptUnit.Units.EncryptUnit.DeCodeString(sChrName);
            //bo21 = false;
            ////@ Unsupported function or procedure: 'FillChar'
            //FillChar(HumanRCD.Data, sizeof(THumData), '\0');
            //if (sHumanRCD.Length == DBShare.Units.DBShare.GetCodeMsgSize(sizeof(THumDataInfo) * 4 / 3))
            //{
            //    EncryptUnit.Units.EncryptUnit.DecodeBuffer(sHumanRCD, HumanRCD, sizeof(THumDataInfo));
            //}
            //else
            //{
            //    bo21 = true;
            //}
            //if (!bo21)
            //{
            //    bo21 = true;
            //    try {
            //        if (DBShare.Units.DBShare.g_HumDataDB.Open())
            //        {
            //            nIndex = DBShare.Units.DBShare.g_HumDataDB.Index(sChrName);
            //            if (nIndex < 0)
            //            {
            //                HumanRCD.Header.boDeleted = false;
            //                HumanRCD.Header.boIsHero = true;
            //                HumanRCD.Header.sName = sChrName;
            //                HumanRCD.Header.dCreateDate = DateTime.Now;
            //                DBShare.Units.DBShare.g_HumDataDB.Add(HumanRCD);
            //                nIndex = DBShare.Units.DBShare.g_HumDataDB.Index(sChrName);
            //            }
            //            if ((nIndex >= 0) && (DBShare.Units.DBShare.g_HumDataDB.Get(nIndex, HumDataInfo) >= 0))
            //            {
            //                HumanRCD.Header = HumDataInfo.Header;
            //                DBShare.Units.DBShare.g_HumDataDB.Update(nIndex, HumanRCD);
            //                bo21 = false;
            //                DBShare.Units.DBShare.g_nSaveHeroCount ++;
            //            }
            //        }
            //    } finally {
            //        DBShare.Units.DBShare.g_HumDataDB.Close();
            //    }
            //// FrmIDSoc.SetSessionSaveRcd(sUserID);
            //}
            //if (!bo21)
            //{
            //    m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_SAVEHERORCD, 1, 0, 0, 0);
            //    SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(m_DefMsg));
            //}
            //else
            //{
            //    m_DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_SAVEHERORCD, 0, 0, 0, 0);
            //    SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(m_DefMsg));
            //}
        }

        /// <summary>
        /// 保存英雄记录扩展
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="nRecog"></param>
        private void SaveHumanRcdEx(string sMsg, int nRecog)
        {
            //string sChrName;
            //string sUserID;
            //string sHumanRCD;
            //int I;
            //bool bo21;
            //TDefaultMessage DefMsg;
            //THumDataInfo HumanRCD;
            //// HumSession: pTHumSession;
            ////@ Undeclared identifier(3): 'GetValidStr3'
            //sHumanRCD = GetValidStr3(sMsg, sUserID, new char[] {'/'});
            ////@ Undeclared identifier(3): 'GetValidStr3'
            //sHumanRCD = GetValidStr3(sHumanRCD, sChrName, new char[] {'/'});
            //sUserID = EncryptUnit.Units.EncryptUnit.DeCodeString(sUserID);
            //sChrName = EncryptUnit.Units.EncryptUnit.DeCodeString(sChrName);
            //// for I := 0 to HumSessionList.Count - 1 do begin
            //// HumSession := HumSessionList.Items[I];
            //// if (HumSession.sChrName = sChrName) and (HumSession.nIndex = nRecog) then begin
            //// HumSession.bo24 := False;
            //// HumSession.Socket := Socket;
            //// HumSession.bo2C := True;
            //// HumSession.dwTick30 := GetTickCount();
            //// Break;
            //// end;
            //// end;
            //SaveHumanRcd(nRecog, sMsg);
        }

        /// <summary>
        /// 载入排行
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="Msg"></param>
        private void LoadRanking(string sMsg, TDefaultMessage Msg)
        {
//            int I;
//            int nIndex;
//            int nCount;
//            string sHumName;
//            string sSendText;
//            // S: string;
//            int nCheckCode;
//            TDefaultMessage DefMsg;
//            List<string> RankingList;
//            TUserLevelRanking HumRanking;
//            THeroLevelRanking HeroRanking;
//            TUserMasterRanking MasterRanking;
//            TUserLevelRanking UserLevelRanking;
//            THeroLevelRanking HeroLevelRanking;
//            TUserMasterRanking UserMasterRanking;
//            //@ Unsupported function or procedure: 'EnterCriticalSection'
//            EnterCriticalSection(DBShare.Units.DBShare.g_Ranking_CS);
//            try {
//                nCheckCode =  -1;
//                sSendText = "";
//                nIndex = 0;
//                nCount = 0;
//                RankingList = null;
//                // S := '';
//                sHumName = EncryptUnit.Units.EncryptUnit.DeCodeString(sMsg);
//                if (Msg.Param >= 0 && Msg.Param<= 2)
//                {
//                    if (Msg.Param < 2)
//                    {
//                        if (Msg.Tag >= 0 && Msg.Tag<= 4)
//                        {
//                            nCheckCode = 0;
//                            RankingList = DBShare.Units.DBShare.GetRankingList(Msg.Param, Msg.Tag);
//                            if (RankingList.Count > 0)
//                            {
//                                if (sHumName == "")
//                                {
//                                    // 为空不是查找自己
//                                    //@ Undeclared identifier(3): '_MIN'
//                                    //@ Undeclared identifier(3): '_MAX'
//                                    nIndex = _MAX(_MIN(RankingList.Count - 1, Msg.Recog), 0);
////#if HEROVERSION = 1
////                                    //@ Undeclared identifier(3): '_MIN'
////                                    nCount = _MIN(RankingList.Count - 1, nIndex + 9);
////#else
//                                    //@ Undeclared identifier(3): '_MIN'
//                                    nCount = _MIN(RankingList.Count - 1, nIndex + 7);
////#endif
//                                    if (Msg.Param == 0)
//                                    {
//                                        for (I = nIndex; I <= nCount; I ++ )
//                                        {
//                                            //@ Unsupported property or method(A): 'Values'
//                                            HumRanking = ((TUserLevelRanking)(RankingList.Values[I]));
//                                            UserLevelRanking = HumRanking;
//                                            UserLevelRanking.nIndex = I + 1;
//                                            // S:=S+HumRanking.sChrName+'/';
//                                            sSendText = sSendText + EncryptUnit.Units.EncryptUnit.EncodeBuffer(UserLevelRanking, sizeof(TUserLevelRanking)) + '/';
//                                        }
//                                    }
//                                    else
//                                    {
//                                        for (I = nIndex; I <= nCount; I ++ )
//                                        {
//                                            //@ Unsupported property or method(A): 'Values'
//                                            HeroRanking = ((THeroLevelRanking)(RankingList.Values[I]));
//                                            HeroLevelRanking = HeroRanking;
//                                            HeroLevelRanking.nIndex = I + 1;
//                                            sSendText = sSendText + EncryptUnit.Units.EncryptUnit.EncodeBuffer(HeroLevelRanking, sizeof(THeroLevelRanking)) + '/';
//                                        }
//                                    }
//                                }
//                                else
//                                {
//                                    if (Msg.Param == 0)
//                                    {
//                                        for (I = 0; I < RankingList.Count; I ++ )
//                                        {
//                                            //@ Unsupported property or method(A): 'Values'
//                                            HumRanking = ((TUserLevelRanking)(RankingList.Values[I]));
//                                            if (HumRanking.sChrName == sHumName)
//                                            {
//                                                UserLevelRanking = HumRanking;
//                                                UserLevelRanking.nIndex = I + 1;
//                                                sSendText = EncryptUnit.Units.EncryptUnit.EncodeBuffer(UserLevelRanking, sizeof(TUserLevelRanking));
//                                                // S:=S+HumRanking.sChrName+'/';
//                                                break;
//                                            }
//                                        }
//                                    }
//                                    else
//                                    {
//                                        for (I = 0; I < RankingList.Count; I ++ )
//                                        {
//                                            //@ Unsupported property or method(A): 'Values'
//                                            HeroRanking = ((THeroLevelRanking)(RankingList.Values[I]));
//                                            if (HeroRanking.sChrName == sHumName)
//                                            {
//                                                HeroLevelRanking = HeroRanking;
//                                                HeroLevelRanking.nIndex = I + 1;
//                                                sSendText = EncryptUnit.Units.EncryptUnit.EncodeBuffer(HeroLevelRanking, sizeof(THeroLevelRanking));
//                                                break;
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    else
//                    {
//                        nCheckCode = 0;
//                        RankingList = DBShare.Units.DBShare.GetRankingList(Msg.Param, Msg.Tag);
//                        if (RankingList.Count > 0)
//                        {
//                            if (sHumName == "")
//                            {
//                                // 为空不是查找自己
//                                //@ Undeclared identifier(3): '_MIN'
//                                //@ Undeclared identifier(3): '_MAX'
//                                nIndex = _MAX(_MIN(RankingList.Count - 1, Msg.Recog), 0);
////#if HEROVERSION = 1
////                                //@ Undeclared identifier(3): '_MIN'
////                                nCount = _MIN(RankingList.Count - 1, nIndex + 9);
////#else
//                                //@ Undeclared identifier(3): '_MIN'
//                                nCount = _MIN(RankingList.Count - 1, nIndex + 7);
////#endif
//                                for (I = nIndex; I <= nCount; I ++ )
//                                {
//                                    //@ Unsupported property or method(A): 'Values'
//                                    MasterRanking = ((TUserMasterRanking)(RankingList.Values[I]));
//                                    UserMasterRanking = MasterRanking;
//                                    UserMasterRanking.nIndex = I + 1;
//                                    sSendText = sSendText + EncryptUnit.Units.EncryptUnit.EncodeBuffer(UserMasterRanking, sizeof(TUserMasterRanking)) + '/';
//                                }
//                            }
//                            else
//                            {
//                                for (I = 0; I < RankingList.Count; I ++ )
//                                {
//                                    //@ Unsupported property or method(A): 'Values'
//                                    MasterRanking = ((TUserMasterRanking)(RankingList.Values[I]));
//                                    if (MasterRanking.sChrName == sHumName)
//                                    {
//                                        UserMasterRanking = MasterRanking;
//                                        UserMasterRanking.nIndex = I + 1;
//                                        sSendText = EncryptUnit.Units.EncryptUnit.EncodeBuffer(UserMasterRanking, sizeof(TUserMasterRanking));
//                                        break;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//                if (nCheckCode == 0)
//                {
//                    DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_LOADRANKING, Msg.Tag, Msg.Param, nIndex, RankingList.Count);
//                    SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(DefMsg) + sSendText);
//                }
//                else
//                {
//                    DefMsg = EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Common.DBR_LOADRANKING, Msg.Tag, Msg.Param, nIndex, 0);
//                    SendSocket(EncryptUnit.Units.EncryptUnit.EncodeMessage(DefMsg) + sSendText);
//                }
//            } finally {
//                //@ Unsupported function or procedure: 'LeaveCriticalSection'
//                LeaveCriticalSection(DBShare.Units.DBShare.g_Ranking_CS);
//            }
        }

    } // end TServerClient

}

