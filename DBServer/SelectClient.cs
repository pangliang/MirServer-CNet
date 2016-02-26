using System;
using System.Collections;
using System.Windows.Forms;
using DBServer.Entity;
using GameFramework;
using NetFramework;
using NetFramework.AsyncSocketServer;
using NetFramework.AsyncSocketClient;

namespace DBServer
{
    /// <summary>
    /// 选择服务端
    /// </summary>
    public class TSelectClient
    {
        public uint m_dwKeepAliveTick = 0;//心跳时间
        public string m_sReceiveText = String.Empty;//接受消息
        public string m_sGateaddr = String.Empty;//网关地址
        public uint m_dwTick10 = 0;//未知
        public int m_nGateID = 0;//网关ID
        public TModuleInfo m_Module = null;//模块
        public uint m_dwCheckServerTimeMin = 0;//检查服务器时间最小值
        public uint m_dwCheckServerTimeMax = 0;//检查服务器时间最大值
        public uint m_dwCheckRecviceTick = 0;//检测接收时间
        public TSelectChar SelectCharList = null;//选择角色列表
        public AsyncUserToken Socket = null;//Socket,传入
        private TFrmIDSoc FrmIDSoc = null;//会话管理,传入

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Socket"></param>
        /// <param name="FrmIDSoc"></param>
        public TSelectClient(AsyncUserToken Socket, TFrmIDSoc FrmIDSoc)
        {
            this.Socket = Socket;
            this.FrmIDSoc = FrmIDSoc;
            SelectCharList = new TSelectChar();
        }

        /// <summary>
        /// 心跳包
        /// </summary>
        public void SendKeepAlivePacket()
        {
            this.SendText("%++$");
            m_dwKeepAliveTick = GameFramework.HUtil32.GetTickCount();
            m_dwCheckServerTimeMin = GameFramework.HUtil32.GetTickCount() - m_dwCheckRecviceTick;
            if (m_dwCheckServerTimeMin > m_dwCheckServerTimeMax)
            {
                m_dwCheckServerTimeMax = m_dwCheckServerTimeMin;
            }
            m_dwCheckRecviceTick = GameFramework.HUtil32.GetTickCount();
            if (m_Module != null)//设置模块缓冲
            {
                m_Module.Buffer =string.Format("{0}/{1}", m_dwCheckServerTimeMin, m_dwCheckServerTimeMax);
            }
        }

        /// <summary>
        /// 发送提出用户包 无引用
        /// </summary>
        /// <param name="SocketHandle"></param>
        /// <param name="nKickType"></param>
        public void SendKickUser(string SocketHandle, int nKickType)
        {
            switch (nKickType)
            {
                case 0:
                    this.SendText("%+-" + SocketHandle + '$');
                    break;
                case 1:
                    this.SendText("%+T" + SocketHandle + '$');
                    break;
                case 2:
                    this.SendText("%+B" + SocketHandle + '$');
                    break;
            }
        }

        /// <summary>
        /// 向用户发送包
        /// </summary>
        /// <param name="sSessionID"></param>
        /// <param name="sSendMsg"></param>
        public void SendUserSocket(string sSessionID, string sSendMsg)
        {
            this.SendText('%' + sSessionID + "/#" + sSendMsg + "!$");
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="SendMsg"></param>
        public void SendText(string SendMsg)
        { 
            Socket.Socket.Send(System.Text.Encoding.Default.GetBytes(SendMsg));
        }

        /// <summary>
        /// 踢下线
        /// </summary>
        /// <param name="sSessionID"></param>
        public void OutOfConnect(string sSessionID)
        {
            TDefaultMessage Msg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_OUTOFCONNECTION, 0, 0, 0, 0);
            SendUserSocket(sSessionID, EncryptUnit.EncodeMessage(Msg));
        }

        /// <summary>
        /// 执行网关缓冲
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufLen"></param>
        public void ExecGateBuffers(string sReceiveText, int BufLen)
        {
            string sSecond =string.Empty;
            string sFirst=string.Empty;
            char s19;
            int nError = 0;//错误代码
            int I;
            TUserInfo UserInfo;
            int nErrPacketCount = 0;
            try
            {
                nError = 2;
                m_sReceiveText = m_sReceiveText + sReceiveText;
                nError = 3;
                while (true)
                {
                    if (m_sReceiveText.IndexOf('$') <= 0) break;
                    nError = 4;
                    m_sReceiveText = GameFramework.HUtil32.ArrestStringEx(m_sReceiveText, "%", "$",ref sFirst);
                    nError = 5;
                    if (sFirst != "")
                    {
                        s19 = sFirst[0];
                        nError = 6;
                        sFirst = sFirst.Substring(1, sFirst.Length - 1);
                        nError = 7;
                        switch (s19)
                        {
                            case '-'://心跳包
                                nError = 8;
                                SendKeepAlivePacket();
                                break;
                            case 'D'://处理包
                                nError = 9;
                                sFirst = GameFramework.HUtil32.GetValidStr3(sFirst,ref sSecond, new string[] { "/" });
                                for (I = 0; I < SelectCharList.OnLineCount; I++)
                                {
                                    UserInfo = SelectCharList.GetOnLineItem(I);//遍历用户
                                    if (UserInfo != null)
                                    {
                                        if (UserInfo.sConnID == sSecond)
                                        {
                                            UserInfo.sReceiveText = UserInfo.sReceiveText + sFirst;//包交给用户
                                            if (sFirst.IndexOf('!') < 1)
                                            {
                                                continue;
                                            }
                                            nError = 10;
                                            ProcessUserMsg(UserInfo);
                                            break;
                                        }
                                    }
                                }
                                break;
                            case 'N'://新用户
                                nError = 11;
                                sFirst = GameFramework.HUtil32.GetValidStr3(sFirst,ref sSecond, new string[] { "/" });
                                OpenUser(sSecond, sFirst);
                                break;
                            case 'C'://关闭用户
                                nError = 12;
                                CloseUser(sFirst);
                                break;
                            default:
                                if (nErrPacketCount >= 1)
                                {
                                    m_sReceiveText = "";
                                    break;
                                }
                                nErrPacketCount++;
                                break;
                        }
                    }
                    else
                    {
                        m_sReceiveText = "";
                        break;
                    }
                }
            }
            catch
            {
                DBShare.MainOutMessage("[Exception] TDBSERVER::ExecBuffers:" + (nError).ToString());
            }
        }

        /// <summary>
        /// 处理用户消息
        /// </summary>
        /// <param name="UserInfo"></param>
        private void ProcessUserMsg(TUserInfo UserInfo)
        {
            string s10 = string.Empty;
            int nC;
            nC = 0;
            while (true)
            {
                if (UserInfo.sReceiveText.IndexOf('!') <= 0)
                {
                    break;
                }
                UserInfo.sReceiveText = GameFramework.HUtil32.ArrestStringEx(UserInfo.sReceiveText, "#", "!", ref s10);
                if (s10 != "")
                {
                    s10 = s10.Substring(1, s10.Length - 1);
                    if (s10.Length >= Grobal2.DEFBLOCKSIZE)
                    {
                        DeCodeUserMsg(s10, UserInfo);
                    }
                    // else Inc(n4ADC20);
                }
                else
                {
                    // Inc(n4ADC1C);
                    if (nC >= 1)
                    {
                        UserInfo.sReceiveText = "";
                    }
                    nC++;
                }
            }
        }

        /// <summary>
        /// 解码用户消息
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="UserInfo"></param>
        private void DeCodeUserMsg(string sData, TUserInfo UserInfo)
        {
            string sDefMsg = sData.Substring(0, Grobal2.DEFBLOCKSIZE);
            string s18 = sData.Substring(Grobal2.DEFBLOCKSIZE, sData.Length - Grobal2.DEFBLOCKSIZE);
            TDefaultMessage Msg = EncryptUnit.DecodeMessage(sDefMsg);
            try
            {
                switch (Msg.Ident)
                {
                    case Grobal2.CM_QUERYRANDOMCODE://查询验证码
                        if (((GameFramework.HUtil32.GetTickCount() - UserInfo.dwRandomTick) > 200))
                        {
                            UserInfo.dwRandomTick = GameFramework.HUtil32.GetTickCount();
                            SendRandomCodeMap(UserInfo, Msg.Param);
                        }
                        else
                        {
                            DBShare.MainOutMessage("[端口攻击] _QUERYRANDOMCODE " + UserInfo.sAccount + '/' + UserInfo.sUserIPaddr);
                        }
                        break;
                    case Grobal2.CM_SENDRANDOMCODE://发送验证码
                        // 检测验证码
                        s18 = EncryptUnit.DeCodeString(s18);
                        if ((!DBShare.g_boRandomNumber) || ((s18).ToLower().CompareTo((UserInfo.sRandomNumber).ToLower()) == 0))
                        {
                            UserInfo.boRandomNumber = true;
                            FrmIDSoc.SetSessionRandomCodeOK(UserInfo.sAccount, UserInfo.sUserIPaddr, UserInfo.nSessionID, true);
                        }
                        else
                        {
                            OutOfConnect(UserInfo.sConnID);
                        }
                        break;
                    case Grobal2.CM_QUERYCHR://查询角色
                        if (!UserInfo.boChrQueryed || ((GameFramework.HUtil32.GetTickCount() - UserInfo.dwChrTick) > 200))
                        {
                            UserInfo.dwChrTick = GameFramework.HUtil32.GetTickCount();
                            if (QueryChr(s18, UserInfo))
                            {
                                UserInfo.boChrQueryed = true;
                            }
                        }
                        else
                        {
                            DBShare.MainOutMessage("[端口攻击] _QUERYCHR " + UserInfo.sAccount + '/' + UserInfo.sUserIPaddr);
                        }
                        break;
                    case Grobal2.CM_NEWCHR://新建角色
                        if ((GameFramework.HUtil32.GetTickCount() - UserInfo.dwChrTick) > 1000)
                        {
                            UserInfo.dwChrTick = GameFramework.HUtil32.GetTickCount();
                            if ((UserInfo.sAccount != "") && FrmIDSoc.CheckSession(UserInfo.sAccount, UserInfo.sUserIPaddr, UserInfo.nSessionID))
                            {
                                NewChr(s18, UserInfo);
                                UserInfo.boChrQueryed = false;
                            }
                            else
                            {
                                OutOfConnect(UserInfo.sConnID);
                            }
                        }
                        else
                        {
                            DBShare.MainOutMessage("[端口攻击] _NEWCHR " + UserInfo.sAccount + '/' + UserInfo.sUserIPaddr);
                        }
                        break;
                    case Grobal2.CM_DELCHR://删除角色
                        if ((GameFramework.HUtil32.GetTickCount() - UserInfo.dwChrTick) > 1000)
                        {
                            UserInfo.dwChrTick = GameFramework.HUtil32.GetTickCount();
                            if ((UserInfo.sAccount != "") && FrmIDSoc.CheckSession(UserInfo.sAccount, UserInfo.sUserIPaddr, UserInfo.nSessionID))
                            {
                                DelChr(s18, UserInfo);
                                UserInfo.boChrQueryed = false;
                            }
                            else
                            {
                                OutOfConnect(UserInfo.sConnID);
                            }
                        }
                        else
                        {
                            DBShare.MainOutMessage("[端口攻击] _DELCHR " + UserInfo.sAccount + '/' + UserInfo.sUserIPaddr);
                        }
                        break;
                    case Grobal2.CM_SELCHR://选择角色
                        if (!UserInfo.boChrQueryed)
                        {
                            if ((UserInfo.sAccount != "") && FrmIDSoc.CheckSession(UserInfo.sAccount, UserInfo.sUserIPaddr, UserInfo.nSessionID) && ((!DBShare.g_boRandomNumber) || FrmIDSoc.GetSessionRandomCodeOK(UserInfo.sAccount, UserInfo.sUserIPaddr, UserInfo.nSessionID)))
                            {
                                if (SelectChr(s18, UserInfo))
                                {
                                    UserInfo.boChrSelected = true;
                                }
                            }
                            else
                            {
                                OutOfConnect(UserInfo.sConnID);
                            }
                        }
                        else
                        {
                            DBShare.MainOutMessage("[端口攻击] _SELCHR " + UserInfo.sAccount + '/' + UserInfo.sUserIPaddr);
                        }
                        break;
                    case Grobal2.CM_QUERYDELCHR:// 查询删除的人物
                        if (((GameFramework.HUtil32.GetTickCount() - UserInfo.dwQueryDelChrTick) > 200))
                        {
                            UserInfo.dwChrTick = GameFramework.HUtil32.GetTickCount();
                            if (QueryDisabledChr(s18, UserInfo))
                            {
                                // UserInfo.boChrQueryed := True;
                            }
                        }
                        else
                        {
                            DBShare.MainOutMessage("[端口攻击] _QUERYDELCHR " + UserInfo.sAccount + '/' + UserInfo.sUserIPaddr);
                        }
                        break;
                    case Grobal2.CM_RESTORECHR:
                        // 找回人物
                        if (((GameFramework.HUtil32.GetTickCount() - UserInfo.dwRestoreChr) > 200))
                        {
                            UserInfo.dwChrTick = GameFramework.HUtil32.GetTickCount();
                            RestoreChr(s18, UserInfo);
                        }
                        else
                        {
                            DBShare.MainOutMessage("[端口攻击] _RESTORECHR " + UserInfo.sAccount + '/' + UserInfo.sUserIPaddr);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                DBShare.MainOutMessage("[Exception] TDBSERVER::DeCodeUserMsg:" + (Msg.Ident).ToString());
            }
        }


        /// <summary>
        /// 打开用户
        /// </summary>
        /// <param name="sID"></param>
        /// <param name="sIP"></param>
        private void OpenUser(string sID, string sIP)
        {
            TUserInfo UserInfo;
            string sUserIPaddr =string.Empty;//用户IP
            string sGateIPaddr = string.Empty;//网关IP
            sGateIPaddr = GameFramework.HUtil32.GetValidStr3(sIP, ref sUserIPaddr, new string[] { "/" });
            for (int I = 0; I < SelectCharList.OnLineCount; I++)
            {
                UserInfo = SelectCharList.GetOnLineItem(I);
                if ((UserInfo != null) && (UserInfo.sConnID == sID))
                {
                    return;//如果用户存在 结束方法
                }
            }
            int nIndex = SelectCharList.Add();
            if (nIndex >= 0)
            {
                SelectCharList.Initialize(nIndex);
                UserInfo = SelectCharList.GetOnLineItem(nIndex);
                UserInfo.nIndex = nIndex;
                UserInfo.sUserIPaddr = sUserIPaddr;
                UserInfo.sGateIPaddr = sGateIPaddr;
                UserInfo.sConnID = sID;
                UserInfo.Socket = this.Socket;
                UserInfo.nSelGateID = (sbyte)m_nGateID;
            }
        }

        /// <summary>
        /// 关闭用户
        /// </summary>
        /// <param name="sID"></param>
        private void CloseUser(string sID)
        {
            int I;
            TUserInfo UserInfo;
            for (I = 0; I < SelectCharList.OnLineCount; I++)
            {
                UserInfo = SelectCharList.GetOnLineItem(I);
                if ((UserInfo != null) && (UserInfo.sConnID == sID))
                {
                    if (!FrmIDSoc.GetGlobaSessionStatus(UserInfo.nSessionID))
                    {
                        FrmIDSoc.SendSocketMsg(Common.SS_SOFTOUTSESSION, UserInfo.sAccount + '/' + (UserInfo.nSessionID).ToString());
                        FrmIDSoc.CloseSession(UserInfo.sAccount, UserInfo.nSessionID);
                    }
                    SelectCharList.Finalize(UserInfo.nIndex);
                    break;
                }
            }
        }

        /// <summary>
        /// 发送随机码
        /// </summary>
        /// <param name="UserInfo"></param>
        /// <param name="BitCount"></param>
        private void SendRandomCodeMap(TUserInfo UserInfo, int BitCount)
        {
            byte[] B64 = { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
            string Key = "   ";
            if (DBShare.g_boRandomNumber)
            {
                char[] P = Key.ToCharArray();
                for (int I = 0; I < 3; I++)
                {
                    P[I] = (char)(B64[(new System.Random(61)).Next()]);
                }
                UserInfo.sRandomNumber = Key;
                SendUserSocket(UserInfo.sConnID, EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Grobal2.SM_SENDRANDOMCODE, 0, 0, 0, 0)) + EncryptUnit.EncodeString(Key));
            }
            else
            {
                SendUserSocket(UserInfo.sConnID, EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Grobal2.SM_SENDRANDOMCODE, 1, 0, 0, 0)));
            }
        }

        /// <summary>
        /// 查询被禁用人物
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        private unsafe bool QueryDisabledChr(string sData, TUserInfo UserInfo)
        {
            bool result = false;
            //string sAccount;
            //string sChrName;
            //string sSessionID;
            //int nSessionID;
            //int nChrCount;
            //ArrayList ChrList;
            //int I;
            //int nIndex;
            //THumDataInfo ChrRecord;
            //THumInfo HumRecord;
            ////pTQuickID QuickID;
            //string s40;
            //TDisabledChar DisabledChar;
            //sAccount = EncryptUnit.DeCodeString(sData);
            //nChrCount = 0;
            //s40 = "";
            //// ChrList := TStringList.Create;
            //try
            //{
            //    if (DBShare.g_HumCharDB.Open() && (DBShare.g_HumCharDB.FindByAccount(sAccount, ref ChrList) >= 0))
            //    {
            //        try
            //        {
            //            if (DBShare.g_HumDataDB.OpenEx())
            //            {
            //                for (I = 0; I < ChrList.Count; I++)
            //                {
            //                    //@ Undeclared identifier(3): 'pTQuickID'
            //                    QuickID = pTQuickID(ChrList[I]);
            //                    //@ Unsupported property or method(C): 'boIsHero'
            //                    if (QuickID.boIsHero)
            //                    {
            //                        continue;
            //                    }
            //                    if (nChrCount >= 10)
            //                    {
            //                        break;
            //                    }
            //                    // FrmDBSrv.MemoLog.Lines.Add('UserInfo.nSelGateID: '+IntToStr(UserInfo.nSelGateID)+' QuickID.nIndex: '+IntToStr(QuickID.nIndex));
            //                    // 如果选择ID不对,则跳过
            //                    // if QuickID.nIndex <> UserInfo.nSelGateID then Continue;
            //                    //@ Unsupported property or method(C): 'nIndex'
            //                    if (DBShare.g_HumCharDB.GetBy(QuickID.nIndex, HumRecord) && HumRecord.boDeleted)
            //                    {
            //                        //@ Unsupported property or method(C): 'sChrName'
            //                        sChrName = QuickID.sChrName;
            //                        nIndex = DBShare.g_HumDataDB.Index(sChrName);
            //                        if (nIndex < 0)
            //                        {
            //                            continue;
            //                        }
            //                        if (DBShare.g_HumDataDB.Get(nIndex, ChrRecord) >= 0)
            //                        {
            //                            DisabledChar.sChrName = sChrName;
            //                            DisabledChar.wLevel = ChrRecord.Data.Abil.Level;
            //                            DisabledChar.btJob = ChrRecord.Data.btJob;
            //                            DisabledChar.btSex = ChrRecord.Data.btSex;
            //                            s40 = s40 + EncryptUnit.EncodeBuffer(DisabledChar, sizeof(TDisabledChar)) + '/';
            //                            nChrCount++;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        finally
            //        {
            //            DBShare.g_HumDataDB.Close();
            //        }
            //    }
            //}
            //finally
            //{
            //    DBShare.g_HumCharDB.Close();
            //}
            //// ChrList.Free;
            //if (s40 != "")
            //{
            //    SendUserSocket(UserInfo.sConnID, EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Grobal2.SM_FINDDELCHR, nChrCount, 0, 1, 0)) + s40);
            //}
            return result;
        }

        /// <summary>
        /// 恢复人物
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="UserInfo"></param>
        private void RestoreChr(string sData, TUserInfo UserInfo)
        {
            //string sAccount;
            //string sSessionID;
            //int nSessionID;
            //int nChrCount;
            //ArrayList ChrList;
            //int I;
            //int n10;
            //int nIndex;
            //THumDataInfo ChrRecord;
            //THumInfo HumRecord;
            //pTQuickID QuickID;
            //byte btSex;
            //string sChrName;
            //string sJob;
            //string sHair;
            //string sLevel;
            //string s40;
            //bool boCheck;
            ////@ Undeclared identifier(3): 'GetValidStr3'
            //sChrName = GetValidStr3(EncryptUnit.Units.EncryptUnit.DeCodeString(sData), sAccount, new char[] { '/' });
            //nChrCount = 0;
            //boCheck = false;
            //try
            //{
            //    if (DBShare.Units.DBShare.g_HumCharDB.Open() && (DBShare.Units.DBShare.g_HumCharDB.FindByAccount(sAccount, ref ChrList) >= 0))
            //    {
            //        try
            //        {
            //            if (DBShare.Units.DBShare.g_HumDataDB.OpenEx())
            //            {
            //                for (I = 0; I < ChrList.Count; I++)
            //                {
            //                    //@ Undeclared identifier(3): 'pTQuickID'
            //                    QuickID = pTQuickID(ChrList[I]);
            //                    //@ Unsupported property or method(C): 'boIsHero'
            //                    if (QuickID.boIsHero)
            //                    {
            //                        continue;
            //                    }
            //                    //@ Unsupported property or method(C): 'nIndex'
            //                    if (DBShare.Units.DBShare.g_HumCharDB.GetBy(QuickID.nIndex, HumRecord))
            //                    {
            //                        if (!HumRecord.boDeleted)
            //                        {
            //                            nChrCount++;
            //                        }
            //                        if (nChrCount >= 2)
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                if (nChrCount < 2)
            //                {
            //                    for (I = 0; I < ChrList.Count; I++)
            //                    {
            //                        //@ Undeclared identifier(3): 'pTQuickID'
            //                        QuickID = pTQuickID(ChrList[I]);
            //                        //@ Unsupported property or method(C): 'boIsHero'
            //                        if (QuickID.boIsHero)
            //                        {
            //                            continue;
            //                        }
            //                        //@ Unsupported property or method(C): 'sChrName'
            //                        if (sChrName == QuickID.sChrName)
            //                        {
            //                            //@ Unsupported property or method(C): 'nIndex'
            //                            if (DBShare.Units.DBShare.g_HumCharDB.GetBy(QuickID.nIndex, HumRecord) && HumRecord.boDeleted)
            //                            {
            //                                n10 = DBShare.Units.DBShare.g_HumCharDB.Index(sChrName);
            //                                if (n10 >= 0)
            //                                {
            //                                    if (HumRecord.sAccount == UserInfo.sAccount)
            //                                    {
            //                                        HumRecord.boDeleted = false;
            //                                        HumRecord.dModDate = DateTime.Now;
            //                                        DBShare.Units.DBShare.g_HumCharDB.Update(n10, HumRecord);
            //                                        boCheck = true;
            //                                        break;
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        finally
            //        {
            //            DBShare.Units.DBShare.g_HumDataDB.Close();
            //        }
            //    }
            //}
            //finally
            //{
            //    DBShare.Units.DBShare.g_HumCharDB.Close();
            //}
            //if (nChrCount >= 2)
            //{
            //    SendUserSocket(UserInfo.sConnID, EncryptUnit.Units.EncryptUnit.EncodeMessage(EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Grobal2.SM_FINDDELCHR_FAIL, 0, 0, 0, 0)));
            //}
            //else
            //{
            //    if (boCheck)
            //    {
            //        s40 = "";
            //        nChrCount = 0;
            //        try
            //        {
            //            if (DBShare.Units.DBShare.g_HumCharDB.Open() && (DBShare.Units.DBShare.g_HumCharDB.FindByAccount(sAccount, ref ChrList) >= 0))
            //            {
            //                try
            //                {
            //                    if (DBShare.Units.DBShare.g_HumDataDB.OpenEx())
            //                    {
            //                        for (I = 0; I < ChrList.Count; I++)
            //                        {
            //                            //@ Undeclared identifier(3): 'pTQuickID'
            //                            QuickID = pTQuickID(ChrList[I]);
            //                            //@ Unsupported property or method(C): 'boIsHero'
            //                            if (QuickID.boIsHero)
            //                            {
            //                                continue;
            //                            }
            //                            if ((nChrCount >= 2))
            //                            {
            //                                break;
            //                            }
            //                            // FrmDBSrv.MemoLog.Lines.Add('UserInfo.nSelGateID: '+IntToStr(UserInfo.nSelGateID)+' QuickID.nIndex: '+IntToStr(QuickID.nIndex));
            //                            // 如果选择ID不对,则跳过
            //                            // if QuickID.nIndex <> UserInfo.nSelGateID then Continue;
            //                            //@ Unsupported property or method(C): 'nIndex'
            //                            if (DBShare.Units.DBShare.g_HumCharDB.GetBy(QuickID.nIndex, HumRecord) && (!HumRecord.boDeleted))
            //                            {
            //                                //@ Unsupported property or method(C): 'sChrName'
            //                                sChrName = QuickID.sChrName;
            //                                nIndex = DBShare.Units.DBShare.g_HumDataDB.Index(sChrName);
            //                                if ((nIndex < 0))
            //                                {
            //                                    continue;
            //                                }
            //                                if (DBShare.Units.DBShare.g_HumDataDB.Get(nIndex, ChrRecord) >= 0)
            //                                {
            //                                    btSex = ChrRecord.Data.btSex;
            //                                    sJob = (ChrRecord.Data.btJob).ToString();
            //                                    sHair = (ChrRecord.Data.btHair).ToString();
            //                                    sLevel = (ChrRecord.Data.Abil.Level).ToString();
            //                                    if (HumRecord.boSelected)
            //                                    {
            //                                        s40 = s40 + '*';
            //                                    }
            //                                    s40 = s40 + sChrName + '/' + sJob + '/' + sHair + '/' + sLevel + '/' + (btSex).ToString() + '/';
            //                                    nChrCount++;
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //                finally
            //                {
            //                    DBShare.Units.DBShare.g_HumDataDB.Close();
            //                }
            //            }
            //        }
            //        finally
            //        {
            //            DBShare.Units.DBShare.g_HumCharDB.Close();
            //        }
            //        SendUserSocket(UserInfo.sConnID, EncryptUnit.Units.EncryptUnit.EncodeMessage(EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Grobal2.SM_QUERYCHR, nChrCount, 0, 1, 0)) + EncryptUnit.Units.EncryptUnit.EncodeString(s40));
            //        // *ChrName/sJob/sHair/sLevel/sSex/
            //    }
            //    else
            //    {
            //        SendUserSocket(UserInfo.sConnID, EncryptUnit.Units.EncryptUnit.EncodeMessage(EncryptUnit.Units.EncryptUnit.MakeDefaultMsg(Grobal2.SM_QUERYCHR_FAIL, nChrCount, 0, 1, 0)));
            //        CloseUser(UserInfo.sConnID);
            //    }
            //}
        }

        #region 废弃
        ///// <summary>
        ///// 新增人物数据
        ///// </summary>
        ///// <param name="sChrName"></param>
        ///// <param name="nSex"></param>
        ///// <param name="nJob"></param>
        ///// <param name="nHair"></param>
        ///// <returns></returns>
        //private unsafe bool NewChrData(string sChrName, int nSex, int nJob, int nHair)
        //{
        //    bool result;
        //    THumDataInfo ChrRecord = default(THumDataInfo);
        //    result = false;
        //    try
        //    {
        //        if ((DBShare.g_HumDataDB.FindObjectByChrName(sChrName) == null))
        //        {
        //            ChrRecord.Header.dCreateDate = DateTime.Now.ToOADate();
        //            ChrRecord.Header.boIsHero = false;
        //            ChrRecord.Header.sName = sChrName;
        //            ChrRecord.Header.boDeleted = false;
        //            ChrRecord.Data.sChrName = sChrName;
        //            ChrRecord.Data.btSex = (byte)nSex;
        //            ChrRecord.Data.btJob = (byte)nJob;
        //            ChrRecord.Data.btHair = (byte)nHair;
        //            ChrRecord.Data.boIsHero = false;
        //            ChrRecord.Data.boHasHero = false;
        //            result = DBShare.g_HumDataDB.Add(ref ChrRecord);
        //           DBShare.g_nCreateHumCount++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return result;
        //}
        #endregion

        /// <summary>
        /// 新增人物
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="UserInfo"></param>
        private unsafe void NewChr(string sData, TUserInfo UserInfo)
        {
            //case nFailCode of
            //0: FrmDlg.DMessageDlg('[错误信息] 输入的角色名称包含非法字符！ 错误代码 = 0', [mbOk]);
            //2: FrmDlg.DMessageDlg('[错误信息] 创建角色名称已被其他人使用！ 错误代码 = 2', [mbOk]);
            //3: FrmDlg.DMessageDlg('[错误信息] 您只能创建二个游戏角色！ 错误代码 = 3', [mbOk]);
            //4: FrmDlg.DMessageDlg('[错误信息] 创建角色时出现错误！ 错误代码 = 4', [mbOk]);
            //else FrmDlg.DMessageDlg('[错误信息] 创建角色时出现未知错误！', [mbOk]);
            string sAccount = string.Empty;
            string sChrName = string.Empty;
            string sHair = string.Empty;
            string sJob = string.Empty;
            string sSex = string.Empty;
            int nCode;
            int I;
            TDefaultMessage DefMsg;
            nCode = -1;
            string Data = EncryptUnit.DeCodeString(sData);
            Data = HUtil32.GetValidStr3(Data,ref sAccount, new string[] { "/" });
            Data = HUtil32.GetValidStr3(Data, ref sChrName, new string[] { "/" });
            sChrName = sChrName.Trim();
            Data = HUtil32.GetValidStr3(Data, ref sHair, new string[] { "/" });
            Data = HUtil32.GetValidStr3(Data, ref sJob, new string[] { "/" });
            Data = HUtil32.GetValidStr3(Data, ref sSex, new string[] { "/" });
            if (Data.Trim() != "")
            {
                nCode = 0;
            }
            if (sChrName.Length < 3)
            {
                nCode = 0;
            }
            if (!DBShare.CheckDenyChrName(sChrName))
            {
                nCode = 2;
            }
            if (!DBShare.CheckAIChrName(sChrName))
            {
                nCode = 2;
            }
            if (!DBShare.CheckChrName(sChrName))
            {
                nCode = 0;
            }
            if (!DBShare.g_boDenyChrName)
            {
                for (I = 1; I <= sChrName.Length; I++)
                {
                    if ((sChrName[I] == '?') || (sChrName[I] == ' ') || (sChrName[I] == '/') || (sChrName[I] == '@') || (sChrName[I] == '?') || (sChrName[I] == '\'') || (sChrName[I] == '\"') || (sChrName[I] == '\\') || (sChrName[I] == '.') || (sChrName[I] == ',') || (sChrName[I] == ':') || (sChrName[I] == ';') || (sChrName[I] == '`') || (sChrName[I] == '~') || (sChrName[I] == '!') || (sChrName[I] == '#') || (sChrName[I] == '$') || (sChrName[I] == '%') || (sChrName[I] == '^') || (sChrName[I] == '&') || (sChrName[I] == '*') || (sChrName[I] == '(') || (sChrName[I] == ')') || (sChrName[I] == '-') || (sChrName[I] == '_') || (sChrName[I] == '+') || (sChrName[I] == '=') || (sChrName[I] == '|') || (sChrName[I] == '[') || (sChrName[I] == '{') || (sChrName[I] == ']') || (sChrName[I] == ']') || (sChrName[I] == '}'))
                    {
                        nCode = 0;
                    }
                }
            }
            if (nCode == -1)//如果角色已存在 则失败
            {
                try
                {
                    if (HumDB.GetInstance().IsExistsByCharName(sChrName))
                    {
                        nCode = 2;
                    }
                }
                finally
                {
                }
            }
            if (nCode == -1)
            {
                    if (HumDB.GetInstance().ChrCountOfAccount(sAccount) < 2)//判断角色数量是否小于2
                    {
                        THumInfo HumRecord = default(THumInfo);
                        HumRecord.Header.boIsHero = false;
                        HumRecord.Header.sName = sChrName;
                        HumRecord.Header.nSelectID = 0;
                        HumRecord.Header.boDeleted = false;
                        HumRecord.sChrName = sChrName;
                        HumRecord.sAccount = sAccount;
                        HumRecord.boDeleted = false;
                        HumRecord.boIsHero = false;
                        HumRecord.btCount = 0;
                        THumDataInfo ChrRecord = default(THumDataInfo);
                        ChrRecord.Header.dCreateDate = DateTime.Now.ToOADate();
                        ChrRecord.Header.boIsHero = false;
                        ChrRecord.Header.sName = sChrName;
                        ChrRecord.Header.boDeleted = false;
                        ChrRecord.Data.sChrName = sChrName;
                        ChrRecord.Data.btSex = (byte)HUtil32.Str_ToInt(sSex, 0);
                        ChrRecord.Data.btJob = (byte)HUtil32.Str_ToInt(sJob, 0);
                        ChrRecord.Data.btHair = (byte)HUtil32.Str_ToInt(sHair, 0);
                        ChrRecord.Data.boIsHero = false;
                        ChrRecord.Data.boHasHero = false;
                        DBShare.g_nCreateHumCount++;
                        if (HumDB.GetInstance().Add(HumRecord, ChrRecord))
                        {
                            nCode = 1;
                        }
                        else
                        {
                            nCode = 2;
                        }
                    }
                    else
                    {
                        nCode = 3;
                    }
            }
            if (nCode == 1)
            {
                DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_NEWCHR_SUCCESS, 0, 0, 0, 0);
            }
            else
            {
                DefMsg =EncryptUnit.MakeDefaultMsg(Grobal2.SM_NEWCHR_FAIL, nCode, 0, 0, 0);
            }
            SendUserSocket(UserInfo.sConnID, EncryptUnit.EncodeMessage(DefMsg));
        }

        /// <summary>
        /// 删除人物
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="UserInfo"></param>
        private void DelChr(string sData, TUserInfo UserInfo)
        {
            bool boCheck;
            if (DBShare.g_boDeleteChrName)
            {
                string sChrName = EncryptUnit.DeCodeString(sData);
                boCheck = false;
                try
                {
                    if (HumDB.GetInstance().IsExistsByCharName(sChrName))
                    {
                        HumDB.GetInstance().Del(sChrName);
                        DBShare.g_nDeleteHumCount++;
                        boCheck = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                TDefaultMessage Msg;
                if (boCheck)
                {
                    Msg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_DELCHR_SUCCESS, 0, 0, 0, 0);
                }
                else
                {
                    Msg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_DELCHR_FAIL, 0, 0, 0, 0);
                }
                string sMsg = EncryptUnit.EncodeMessage(Msg);
                SendUserSocket(UserInfo.sConnID, sMsg);
            }
        }

        /// <summary>
        /// 选择人物
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        private unsafe bool SelectChr(string sData, TUserInfo UserInfo)
        {
            bool result = false;
            string sAccount =string.Empty;
            string sChrName = string.Empty;
            ArrayList ChrList = new ArrayList();
            int I;
            int nIndex;
            int nMapIndex;
            THumInfo QuickID;
            THumDataInfo ChrRecord;
            string sCurMap;
            bool boDataOK;
            string sDefMsg;
            string sRouteMsg;
            string sRouteIP;
            int nRoutePort = 0;
            TDefaultMessage DefMsg;
            result = false;
            sChrName = HUtil32.GetValidStr3(EncryptUnit.DeCodeString(sData),ref sAccount, new string[] { "/" });
            boDataOK = false;


                    if (DBShare.g_HumCharDB.FindByAccount(sAccount, ref ChrList) >= 0)
                    {
                        for (I = 0; I < ChrList.Count; I++)
                        {
                            QuickID = (THumInfo)ChrList[I];
                            if (QuickID.ChrNameLen != 0)
                            {
                                string sTempChrName = QuickID.sChrName.TrimEnd('\0');
                                if (sTempChrName == sChrName)
                                {
                                    QuickID.boSelected = true;
                                    DBShare.g_HumCharDB.Update(sChrName, QuickID);
                                    boDataOK = true;
                                }
                                else
                                {
                                    if (QuickID.boSelected)
                                    {
                                        QuickID.boSelected = false;
                                        DBShare.g_HumCharDB.Update(sChrName, QuickID);
                                    }
                                }
                            }
                        }
                    }

            

            // try
            // if g_HumDataDB.OpenEx then begin
            // nIndex := g_HumDataDB.Index(PChar(sChrName));
            // if nIndex >= 0 then begin
            // g_HumDataDB.Get(nIndex, @ChrRecord);
            // if not ChrRecord.Header.boIsHero then begin //修正强行登陆英雄
            // //sCurMap := ChrRecord.Data.sCurMap;
            // boDataOK := True;
            // end;
            // end;
            // end;
            // finally
            // g_HumDataDB.Close;
            // end;
            // end;
            if (boDataOK)
            {
                // nMapIndex := GetMapIndex(sCurMap);
                nMapIndex = 0;
                sDefMsg = EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Grobal2.SM_STARTPLAY, 0, 0, 0, 0));

                sRouteIP = DBShare.GateRouteIP(((System.Net.IPEndPoint)Socket.Socket.RemoteEndPoint).Address.ToString(), ref nRoutePort);

                if (DBShare.g_boDynamicIPMode)
                {
                    sRouteIP = UserInfo.sGateIPaddr;
                }
                // 使用动态IP
                sRouteMsg = EncryptUnit.EncodeString(sRouteIP + '/' + (nRoutePort + nMapIndex).ToString());
                SendUserSocket(UserInfo.sConnID, sDefMsg + sRouteMsg);
                FrmIDSoc.SetGlobaSessionPlay(UserInfo.nSessionID);
                result = true;
            }
            else
            {
                SendUserSocket(UserInfo.sConnID, EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Grobal2.SM_STARTFAIL, 0, 0, 0, 0)));
            }
            return result;
        }

        /// <summary>
        /// 查询人物
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="UserInfo"></param>
        /// <returns></returns>
        private unsafe bool QueryChr(string sData, TUserInfo UserInfo)
        {
            bool result = false;
            string sAccount = string.Empty;
            string sSessionID;
            int nSessionID;
            int nChrCount;
            ArrayList ChrList = new ArrayList();
            int I;
            int nIndex;
            //THumDataInfo ChrRecord;
            THumInfo HumRecord = default(THumInfo);
            THumInfo QuickID;
            byte btSex;
            string sChrName;
            string sJob;
            string sHair;
            string sLevel;
            string sResult =string.Empty;
            result = false;
            sSessionID = HUtil32.GetValidStr3(EncryptUnit.DeCodeString(sData),ref sAccount, new string[] { "/" });
            nSessionID = HUtil32.Str_ToInt(sSessionID, -2);
            UserInfo.nSessionID = nSessionID;
            nChrCount = 0;
            if (FrmIDSoc.CheckSession(sAccount, UserInfo.sUserIPaddr, nSessionID))
            {
                FrmIDSoc.SetGlobaSessionNoPlay(nSessionID);
                UserInfo.sAccount = sAccount;
                try
                {
                    if ( (DBShare.g_HumCharDB.FindByAccount(sAccount, ref ChrList) > 0))
                    {
                        try
                        {
                                for (I = 0; I < ChrList.Count; I++)
                                {
                                    QuickID = (THumInfo)ChrList[I];
                                    if (QuickID.boIsHero)
                                    {
                                        continue;
                                    }
                                    if ((nChrCount >= 2))
                                    {
                                        break;
                                    }
                                    // 如果选择ID不对,则跳过
                                    // if QuickID.nIndex <> UserInfo.nSelGateID then Continue;
                                    if (!HumRecord.boDeleted)
                                    {
                                        sChrName = QuickID.sChrName.TrimEnd('\0');
                                        HumDataInfo ChrRecord = DBShare.g_HumDataDB.FindObjectByChrName(sChrName);
                                        if (ChrRecord != null)
                                        {
                                            btSex = ChrRecord.btSex.Value;
                                            sJob = ChrRecord.btJob.Value.ToString();
                                            sHair = ChrRecord.btHair.Value.ToString();
                                            sLevel = ChrRecord.Level.Value.ToString();
                                            if (HumRecord.boSelected)
                                            {
                                                sResult = sResult + '*';
                                            }
                                            sResult = sResult + sChrName + '/' + sJob + '/' + sHair + '/' + sLevel + '/' + (btSex).ToString() + '/';
                                            nChrCount++;
                                        }
                                    }
                                }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SendUserSocket(UserInfo.sConnID, EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Grobal2.SM_QUERYCHR, nChrCount, 0, 1, 0)) + EncryptUnit.EncodeString(sResult));
                // *ChrName/sJob/sHair/sLevel/sSex/
            }
            else
            {
                SendUserSocket(UserInfo.sConnID,EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Grobal2.SM_QUERYCHR_FAIL, nChrCount, 0, 1, 0)));
                CloseUser(UserInfo.sConnID);
            }
            return result;
        }
    }
}


