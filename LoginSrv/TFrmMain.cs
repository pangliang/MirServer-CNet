using AsyncSockets.AsyncSocketServer;
using GameFramework;
using LoginSrv.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoginSrv
{
    public partial class TFrmMain : Form
    {
        private List<string> SList_0344 = null;
        private TThreadParseList ParseList = null;
        public TFrmMasSoc FrmMasSoc = null;
        public TFrmMonSoc FrmMonSoc = null;
        public TFrmGateSetting FrmGateSetting = null;
        public AsyncServer GSocket = null;
        public System.Threading.Timer StateTimer = null;
        public System.Threading.Timer StartTimer = null;
        public System.Threading.Timer MonitorTimer = null;
        public System.Threading.Timer CountLogTimer = null;
        public System.Threading.Timer ExecTimer = null;
        public bool boExecTimerEnabled = false;
        public static bool Colsed = false;

        public void LoadAddrTable(TConfig Config)
        {
            TStringList LoadList;
            string sFileName;
            int nRouteIdx;
            int nSelGateIdx;
            string sLineText = string.Empty;
            string sTitle = string.Empty;
            string sServerName = string.Empty;
            string sGate = string.Empty;
            string sRemote = string.Empty;
            string sPublic = string.Empty;
            string sGatePort = string.Empty;
            Config.ServerNameList.Clear();
            for (int I = Config.GateRoute.GetLowerBound(0); I <= Config.GateRoute.GetUpperBound(0); I++)
            {
                Config.GateRoute[I].sServerName = "";
                Config.GateRoute[I].sTitle = "";
                Config.GateRoute[I].sRemoteAddr = "";
                Config.GateRoute[I].sPublicAddr = "";
                Config.GateRoute[I].nSelIdx = 0;
                for (int II = Config.GateRoute[I].Gate.GetLowerBound(0); II <= Config.GateRoute[I].Gate.GetUpperBound(0); II++)
                {
                    Config.GateRoute[I].Gate[II].sIPaddr = "";
                    Config.GateRoute[I].Gate[II].nPort = 0;
                    Config.GateRoute[I].Gate[II].boEnable = false;
                }
            }
            sFileName = ".\\!addrtable.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                LoadList.LoadFromFile(sFileName);
                nRouteIdx = 0;
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[1] != ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sServerName, new string[] { " " });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sTitle, new string[] { " " });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sRemote, new string[] { " " });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sPublic, new string[] { " " });
                        sLineText = sLineText.Trim();
                        if ((sTitle != "") && (sRemote != "") && (sPublic != "") && (nRouteIdx < LSShare.MAXGATEROUTE))
                        {
                            Config.GateRoute[nRouteIdx].sServerName = sServerName;
                            Config.GateRoute[nRouteIdx].sTitle = sTitle;
                            Config.GateRoute[nRouteIdx].sRemoteAddr = sRemote;
                            Config.GateRoute[nRouteIdx].sPublicAddr = sPublic;
                            nSelGateIdx = 0;
                            while ((sLineText != ""))
                            {
                                if (nSelGateIdx > 9)
                                {
                                    break;
                                }
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sGate, new string[] { " " });
                                if (sGate != "")
                                {
                                    if (sGate[1] == '*')
                                    {
                                        sGate = sGate.Substring(2 - 1, sGate.Length - 1);
                                        Config.GateRoute[nRouteIdx].Gate[nSelGateIdx].boEnable = false;
                                    }
                                    else
                                    {
                                        Config.GateRoute[nRouteIdx].Gate[nSelGateIdx].boEnable = true;
                                    }
                                    sGatePort = HUtil32.GetValidStr3(sGate, ref sGate, new string[] { ":" });
                                    Config.GateRoute[nRouteIdx].Gate[nSelGateIdx].sIPaddr = sGate;
                                    Config.GateRoute[nRouteIdx].Gate[nSelGateIdx].nPort = HUtil32.Str_ToInt(sGatePort, 0);
                                    Config.GateRoute[nRouteIdx].nSelIdx = 0;
                                    nSelGateIdx++;
                                }
                                sLineText = sLineText.Trim();
                            }
                            nRouteIdx++;
                        }
                    }
                }
                Config.nRouteCount = nRouteIdx;
            }
            GenServerNameList(Config);
        }

        public bool IsPayMent(TConfig Config, string sIPaddr, string sAccount)
        {
            bool result = false;
            lock (LSShare.CS_DB)
            {
                if ((Config.AccountCostList.IndexOfKey(sAccount) >= 0) || (Config.IPaddrCostList.IndexOfKey(sIPaddr) >= 0))
                {
                    result = true;
                }
            }
            return result;
        }

        public void CloseUser(TConfig Config, string sAccount, int nSessionID)
        {
            TConnInfo ConnInfo;
            int I;

            //Config.SessionList.__Lock();
            try
            {
                for (I = Config.SessionList.Count - 1; I >= 0; I--)
                {
                    ConnInfo = Config.SessionList[I];
                    if ((ConnInfo.sAccount == sAccount) || (ConnInfo.nSessionID == nSessionID))
                    {
                        FrmMasSoc.SendServerMsg(Common.SS_CLOSESESSION, ConnInfo.sServerName, ConnInfo.sAccount + '/' + (ConnInfo.nSessionID).ToString());

                        //Dispose(ConnInfo);
                        Config.SessionList.RemoveAt(I);
                    }
                }
            }
            finally
            {
                //Config.SessionList.UnLock();
            }
        }

        public void ProcessGate(TConfig Config)
        {
            int I;
            int II;
            TGateInfo GateInfo;
            TUserInfo UserInfo;
            HUtil32.EnterCriticalSection(Config.GateCriticalSection);
            try
            {
                Config.dwProcessGateTick = HUtil32.GetTickCount();
                I = 0;
                while (true)
                {
                    if (Config.GateList.Count <= I)
                    {
                        break;
                    }
                    GateInfo = Config.GateList[I];
                    if (GateInfo.sReceiveMsg != "")
                    {
                        DecodeGateData(Config, GateInfo);
                        Config.sGateIPaddr = GateInfo.sIPaddr;
                        II = 0;
                        while (true)
                        {
                            if (GateInfo.UserList.Count <= II)
                            {
                                break;
                            }
                            UserInfo = GateInfo.UserList[II];
                            if (UserInfo.sReceiveMsg != "")
                            {
                                DecodeUserData(Config, UserInfo);
                            }
                            II++;
                        }
                    }
                    I++;
                }
                if (Config.dwProcessGateTime < Config.dwProcessGateTick)
                {
                    Config.dwProcessGateTime = HUtil32.GetTickCount() - Config.dwProcessGateTick;
                }
                if (Config.dwProcessGateTime > 100)
                {
                    Config.dwProcessGateTime -= 100;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(Config.GateCriticalSection);
            }
        }

        public void SendIPToGate(string sUserIPaddr)
        {
            TConfig Config = LSShare.g_Config;
            for (int I = 0; I < Config.GateList.Count; I++)
            {
                TGateInfo GateInfo = Config.GateList[I];
                SendGateAddIPToGate(GateInfo.Socket, sUserIPaddr);
            }
        }

        public void DecodeGateData(TConfig Config, TGateInfo GateInfo)
        {
            int nCount;
            string sMsg = string.Empty;
            string sSockIndex = string.Empty;
            string sData;
            char Code;
            try
            {
                nCount = 0;
                while (true)
                {
                    if (HUtil32.TagCount(GateInfo.sReceiveMsg, '$') <= 0)
                    {
                        break;
                    }
                    GateInfo.sReceiveMsg = HUtil32.ArrestStringEx(GateInfo.sReceiveMsg, "%", "$", ref sMsg);
                    if (sMsg != "")
                    {
                        Code = sMsg[0];
                        sMsg = sMsg.Substring(2 - 1, sMsg.Length - 1);
                        switch (Code)
                        {
                            case '-':
                                SendKeepAlivePacket(GateInfo.Socket);
                                GateInfo.dwKeepAliveTick = HUtil32.GetTickCount();
                                break;

                            case 'D':
                                sData = HUtil32.GetValidStr3(sMsg, ref sSockIndex, new string[] { "/" });
                                ReceiveSendUser(Config, sSockIndex, GateInfo, sData);
                                break;

                            case 'N':
                                sData = HUtil32.GetValidStr3(sMsg, ref sSockIndex, new string[] { "/" });
                                ReceiveOpenUser(Config, sSockIndex, sData, GateInfo);
                                break;

                            case 'C':
                                sSockIndex = sMsg;
                                ReceiveCloseUser(Config, sSockIndex, GateInfo);
                                break;
                        }
                    }
                    else
                    {
                        if (nCount >= 1)
                        {
                            GateInfo.sReceiveMsg = "";
                        }
                        nCount++;
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("[Exception] TFrmMain.DecodeGateData");
            }
        }

        public void SendKeepAlivePacket(Socket Socket)
        {
            if (Socket.Connected)
            {
                Socket.Send(Encoding.Default.GetBytes("%++$"));
            }
        }

        public void ReceiveCloseUser(TConfig Config, string sSockIndex, TGateInfo GateInfo)
        {
            TUserInfo UserInfo;
            TSockaddr IPaddr;
            int I;
            int II;
            int nIPaddr;
            ArrayList IPList;
            const string sCloseMsg = "Close: {0}";
            for (I = 0; I < GateInfo.UserList.Count; I++)
            {
                UserInfo = GateInfo.UserList[I];
                if (UserInfo.sSockIndex == sSockIndex)
                {
                    if (Config.boShowDetailMsg)
                    {
                        LSShare.MainOutMessage(string.Format(sCloseMsg, new string[] { UserInfo.sUserIPaddr }));
                    }
                    if (!UserInfo.boSelServer)
                    {
                        SessionDel(Config, UserInfo.nSessionID);
                    }
                    GateInfo.UserList.RemoveAt(I);
                    break;
                }
            }
        }

        public void ReceiveOpenUser(TConfig Config, string sSockIndex, string sIPaddr, TGateInfo GateInfo)
        {
            TUserInfo UserInfo;
            int I;
            string sGateIPaddr;
            string sUserIPaddr = string.Empty;
            const string sOpenMsg = "Open: {0}/{1}";
            sGateIPaddr = HUtil32.GetValidStr3(sIPaddr, ref sUserIPaddr, new string[] { "/" });
            try
            {
                for (I = 0; I < GateInfo.UserList.Count; I++)
                {
                    UserInfo = GateInfo.UserList[I];
                    if (UserInfo.sSockIndex == sSockIndex)
                    {
                        UserInfo.sUserIPaddr = sUserIPaddr;
                        UserInfo.sGateIPaddr = sGateIPaddr;
                        UserInfo.sAccount = "";
                        UserInfo.nSessionID = 0;
                        UserInfo.sReceiveMsg = "";
                        UserInfo.dwTime5C = HUtil32.GetTickCount();
                        UserInfo.dwClientTick = HUtil32.GetTickCount();
                        UserInfo.dwStartTick = HUtil32.GetTickCount();
                        return;
                    }
                }
                UserInfo = new TUserInfo();
                UserInfo.sAccount = "";
                UserInfo.sServerName = "";
                UserInfo.boSelServer = false;
                UserInfo.sUserIPaddr = sUserIPaddr;
                UserInfo.sGateIPaddr = sGateIPaddr;
                UserInfo.sSockIndex = sSockIndex;
                UserInfo.nVersionDate = 0;
                UserInfo.boCertificationOK = false;
                UserInfo.nSessionID = 0;
                UserInfo.bo51 = false;
                UserInfo.Socket = GateInfo.Socket;
                UserInfo.sReceiveMsg = "";
                UserInfo.dwTime5C = HUtil32.GetTickCount();
                UserInfo.dwClientTick = HUtil32.GetTickCount();
                UserInfo.dwStartTick = HUtil32.GetTickCount();
                UserInfo.dwMakeAccountTick = HUtil32.GetTickCount();
                UserInfo.bo60 = false;
                UserInfo.Gate = GateInfo;
                GateInfo.UserList.Add(UserInfo);
                if (Config.boShowDetailMsg)
                {
                    LSShare.MainOutMessage(string.Format(sOpenMsg, new string[] { sUserIPaddr, sGateIPaddr }));
                }
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMain.ReceiveOpenUser");
            }
        }

        public void ReceiveSendUser(TConfig Config, string sSockIndex, TGateInfo GateInfo, string sData)
        {
            TUserInfo UserInfo;
            int I;
            try
            {
                for (I = 0; I < GateInfo.UserList.Count; I++)
                {
                    UserInfo = GateInfo.UserList[I];
                    if (UserInfo.sSockIndex == sSockIndex)
                    {
                        if (UserInfo.sReceiveMsg.Length < 4069)
                        {
                            UserInfo.sReceiveMsg = UserInfo.sReceiveMsg + sData;
                        }
                        break;
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMain.ReceiveSendUser");
            }
        }

        public void SessionClearKick(TConfig Config)
        {
            int I;
            TConnInfo ConnInfo;
            lock (objSessionList)
            {
                //Config.SessionList.__Lock();
                try
                {
                    for (I = Config.SessionList.Count - 1; I >= 0; I--)
                    {
                        ConnInfo = Config.SessionList[I];
                        if (ConnInfo.boKicked && ((HUtil32.GetTickCount() - ConnInfo.dwKickTick) > 5 * 1000))
                        {
                            //Dispose(ConnInfo);
                            Config.SessionList.RemoveAt(I);
                        }
                    }
                }
                finally
                {
                    //Config.SessionList.UnLock();
                }
            }
        }

        public void DecodeUserData(TConfig Config, TUserInfo UserInfo)
        {
            string sMsg = string.Empty;
            int nCount;
            nCount = 0;
            try
            {
                // if UserInfo = nil then nErrCode:=1;
                while (true)
                {
                    if (HUtil32.TagCount(UserInfo.sReceiveMsg, '!') <= 0)
                    {
                        break;
                    }
                    UserInfo.sReceiveMsg = HUtil32.ArrestStringEx(UserInfo.sReceiveMsg, "#", "!", ref sMsg);
                    if (sMsg != "")
                    {
                        if (sMsg.Length >= Grobal2.DEFBLOCKSIZE + 1)
                        {
                            sMsg = sMsg.Substring(2 - 1, sMsg.Length - 1);
                            ProcessUserMsg(Config, UserInfo, sMsg);
                        }
                    }
                    else
                    {
                        if (nCount >= 1)
                        {
                            UserInfo.sReceiveMsg = "";
                        }
                        nCount++;
                    }
                    if (UserInfo.sReceiveMsg == "")
                    {
                        break;
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("[Exception] TFrmMain.DecodeUserData ");
            }
        }

        private static object objSessionList = new object();

        public void SessionDel(TConfig Config, int nSessionID)
        {
            TConnInfo ConnInfo;
            int I;

            //Config.SessionList.__Lock();
            lock (objSessionList)
            {
                try
                {
                    for (I = 0; I < Config.SessionList.Count; I++)
                    {
                        ConnInfo = Config.SessionList[I];
                        if (ConnInfo.nSessionID == nSessionID)
                        {
                            //@ Unsupported function or procedure: 'Dispose'
                            //Dispose(ConnInfo);
                            Config.SessionList.RemoveAt(I);
                            break;
                        }
                    }
                }
                finally
                {
                    //Config.SessionList.UnLock();
                }
            }
        }

        public void ProcessUserMsg(TConfig Config, TUserInfo UserInfo, string sMsg)
        {
            string sDefMsg;
            string sData = string.Empty;
            TDefaultMessage DefMsg = default(TDefaultMessage);
            try
            {
                sDefMsg = sMsg.Substring(1 - 1, Grobal2.DEFBLOCKSIZE);
                sData = sMsg.Substring(Grobal2.DEFBLOCKSIZE + 1 - 1, sMsg.Length - Grobal2.DEFBLOCKSIZE);
                DefMsg = EncryptUnit.DecodeMessage(sDefMsg);
                switch (DefMsg.Ident)
                {
                    case Grobal2.CM_QUERYSERVERNAME:// 查询服务器列表
                        if (!UserInfo.boSelServer)
                        {
                            AccountQueryServerName(Config, UserInfo);
                        }
                        break;

                    case Grobal2.CM_SELECTSERVER:
                        if (!UserInfo.boSelServer)
                        {
                            AccountSelectServer(Config, UserInfo, sData);
                        }
                        break;

                    case Grobal2.CM_PROTOCOL:
                        AccountCheckProtocol(UserInfo, DefMsg.Recog);
                        break;

                    case Grobal2.CM_IDPASSWORD:
                        if ((UserInfo.sAccount == "") && UserInfo.boSelServer)
                        {
                            AccountLogin(Config, UserInfo, sData);
                        }
                        else
                        {
                            KickUser(Config, UserInfo, 0);
                        }
                        break;

                    case Grobal2.CM_ADDNEWUSER:
                        if (Config.boEnableMakingID)
                        {
                            if ((HUtil32.GetTickCount() - UserInfo.dwClientTick) > 5000)
                            {
                                UserInfo.dwClientTick = HUtil32.GetTickCount();
                                AccountCreate(Config, DefMsg, UserInfo, sData);
                            }
                            else
                            {
                                if (CheckBoxAttack.Checked)
                                {
                                    KickUser(Config, UserInfo, 2);
                                }
                                LSShare.MainOutMessage("[超速操作] 创建帐号 " + '/' + UserInfo.sUserIPaddr);
                            }
                        }
                        break;

                    case Grobal2.CM_CHANGEPASSWORD:
                        if (UserInfo.sAccount == "")
                        {
                            if ((HUtil32.GetTickCount() - UserInfo.dwClientTick) > 5000)
                            {
                                UserInfo.dwClientTick = HUtil32.GetTickCount();
                                AccountChangePassword(Config, UserInfo, sData);
                            }
                            else
                            {
                                if (CheckBoxAttack.Checked)
                                {
                                    KickUser(Config, UserInfo, 1);
                                }
                                LSShare.MainOutMessage("[超速操作] 修改密码 " + '/' + UserInfo.sUserIPaddr);
                            }
                        }
                        else
                        {
                            UserInfo.sAccount = "";
                        }
                        break;

                    case Grobal2.CM_UPDATEUSER:
                        if ((HUtil32.GetTickCount() - UserInfo.dwClientTick) > 5000)
                        {
                            UserInfo.dwClientTick = HUtil32.GetTickCount();
                            AccountUpdateUserInfo(Config, UserInfo, sData);
                        }
                        else
                        {
                            if (CheckBoxAttack.Checked)
                            {
                                KickUser(Config, UserInfo, 1);
                            }
                            LSShare.MainOutMessage("[超速操作] 更新帐号 " + '/' + UserInfo.sUserIPaddr);
                        }
                        break;

                    case Grobal2.CM_GETBACKPASSWORD:
                        if (Config.boEnableGetbackPassword)
                        {
                            if ((HUtil32.GetTickCount() - UserInfo.dwClientTick) > 5000)
                            {
                                UserInfo.dwClientTick = HUtil32.GetTickCount();
                                AccountGetBackPassword(UserInfo, sData);
                            }
                            else
                            {
                                if (CheckBoxAttack.Checked)
                                {
                                    KickUser(Config, UserInfo, 1);
                                }
                                LSShare.MainOutMessage("[超速操作] 找回密码 " + '/' + UserInfo.sUserIPaddr);
                            }
                        }
                        break;
                }
            }
            catch
            {
                LSShare.MainOutMessage("[Exception] TFrmMain.ProcessUserMsg " + "wIdent: " + (DefMsg.Ident).ToString() + " sData: " + sData);
            }
        }

        public unsafe void AccountCreate(TConfig Config, TDefaultMessage Msg, TUserInfo UserInfo, string sData)
        {
            TUserEntry UserEntry = default(TUserEntry);
            TUserEntryAdd UserAddEntry = default(TUserEntryAdd);
            TAccountDBRecord DBRecord = default(TAccountDBRecord);
            int nLen;
            string sUserEntryMsg;
            string sUserAddEntryMsg;
            int nErrCode;
            TDefaultMessage DefMsg;
            bool bo21;
            int n10;
            const string sAddNewuserFail = "[新建帐号失败] {0}/{1}";
            const string sLogFlag = "new";
            try
            {
                nErrCode = 1;
                nErrCode = -1;
                nLen = LSShare.GetCodeMsgSize(Marshal.SizeOf(typeof(TUserEntryData)) * 4 / 3);//232
                bo21 = false;
                sUserEntryMsg = sData.Substring(0, nLen - 1);
                sUserAddEntryMsg = sData.Substring(nLen, sData.Length - nLen - 1);
                if ((sUserEntryMsg != "") && (sUserAddEntryMsg != ""))
                {
                    TUserEntryData* pUserEntry = (TUserEntryData*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TUserEntryData)));
                    EncryptUnit.DecodeBuffer(sUserEntryMsg, pUserEntry, Marshal.SizeOf(typeof(TUserEntryData)));
                    UserEntry.sAccount = pUserEntry->ToString(pUserEntry->sAccount, pUserEntry->AccoutLen);
                    UserEntry.sAnswer = pUserEntry->ToString(pUserEntry->sAnswer, pUserEntry->AnswerLen);
                    UserEntry.sEMail = pUserEntry->ToString(pUserEntry->sEMail, pUserEntry->EMailLen);
                    UserEntry.sPassword = pUserEntry->ToString(pUserEntry->sPassword, pUserEntry->PasswordLen);
                    UserEntry.sPhone = pUserEntry->ToString(pUserEntry->sPhone, pUserEntry->PhoneLen);
                    UserEntry.sQuiz = pUserEntry->ToString(pUserEntry->sQuiz, pUserEntry->QuizLen);
                    UserEntry.sSSNo = pUserEntry->ToString(pUserEntry->sSSNo, pUserEntry->SSNoLen);
                    UserEntry.sUserName = pUserEntry->ToString(pUserEntry->sUserName, pUserEntry->UserNameLen);
                    TUserEntryAddData* pUserAddEntry = (TUserEntryAddData*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TUserEntryAddData)));
                    EncryptUnit.DecodeBuffer(sUserAddEntryMsg, pUserAddEntry, Marshal.SizeOf(typeof(TUserEntryAddData)));
                    UserAddEntry.sAnswer2 = pUserAddEntry->ToString(pUserAddEntry->sAnswer2, pUserAddEntry->Answer2Len);
                    UserAddEntry.sBirthDay = pUserAddEntry->ToString(pUserAddEntry->sBirthDay, pUserAddEntry->BirthDayLen);
                    UserAddEntry.sMemo = pUserAddEntry->ToString(pUserAddEntry->sMemo, pUserAddEntry->MemoLen);
                    UserAddEntry.sMemo2 = pUserAddEntry->ToString(pUserAddEntry->sMemo2, pUserAddEntry->Memo2Len);
                    UserAddEntry.sMobilePhone = pUserAddEntry->ToString(pUserAddEntry->sMobilePhone, pUserAddEntry->MobilePhoneLen);
                    UserAddEntry.sQuiz2 = pUserAddEntry->ToString(pUserAddEntry->sQuiz2, pUserAddEntry->Quiz2Len);
                    if (LSShare.CheckAccountName(UserEntry.sAccount))
                    {
                        bo21 = true;
                    }
                    if ((UserEntry.sAccount.Length < 4) || (UserEntry.sPassword.Length < 4))
                    {
                        bo21 = false;
                        nErrCode = -2;
                    }
                    if (bo21)
                    {
                        try
                        {
                            if (IDDB.GetInstance().Open())
                            {
                                if (!IDDB.GetInstance().AccountExists(UserEntry.sAccount))
                                {
                                    DBRecord.UserEntry = UserEntry;
                                    DBRecord.UserEntryAdd = UserAddEntry;
                                    if (UserEntry.sAccount != "")
                                    {
                                        if (IDDB.GetInstance().AddAccount(DBRecord))
                                        {
                                            //Config.MakeAccountList.__Lock();
                                            //lock (Config.MakeAccountList)
                                            {
                                                try
                                                {
                                                    if (Config.MakeAccountList.ContainsKey(UserEntry.sAccount))
                                                    {
                                                        Config.MakeAccountList.Add(UserEntry.sAccount, ((UserInfo.dwClientTick) as Object));
                                                    }
                                                }
                                                finally
                                                {
                                                    //Config.MakeAccountList.UnLock();
                                                }
                                            }
                                            nErrCode = 1;
                                        }
                                    }
                                }
                                else
                                {
                                    nErrCode = 0;
                                }
                            }
                        }
                        finally
                        {
                            IDDB.GetInstance().Close();
                        }
                    }
                    else
                    {
                        LSShare.MainOutMessage(string.Format(sAddNewuserFail, new string[] { UserEntry.sAccount, UserAddEntry.sQuiz2 }));
                    }
                }
                if (nErrCode == 1)
                {
                    WriteLogMsg(Config, sLogFlag, ref UserEntry, ref UserAddEntry);
                    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_NEWID_SUCCESS, 0, 0, 0, 0);
                }
                else
                {
                    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_NEWID_FAIL, nErrCode, 0, 0, 0);
                }
                SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "_" + ex.StackTrace);
                LSShare.MainOutMessage("TFrmMain.AddNewUser");
            }
        }

        public void AccountChangePassword(TConfig Config, TUserInfo UserInfo, string sData)
        {
            string sMsg = string.Empty;
            string sLoginID = string.Empty;
            string sOldPassword = string.Empty;
            string sNewPassword = string.Empty;
            TDefaultMessage DefMsg;
            int nCode;
            int n10;
            TAccountDBRecord DBRecord = default(TAccountDBRecord);
            const string sChgMsg = "chg";
            try
            {
                sMsg = EncryptUnit.DeCodeString(sData);
                sMsg = HUtil32.GetValidStr3(sMsg, ref sLoginID, new string[] { "\t" });
                sNewPassword = HUtil32.GetValidStr3(sMsg, ref sOldPassword, new string[] { "\t" });
                nCode = 0;
                try
                {
                    if (IDDB.GetInstance().Open() && (sNewPassword.Length > 3))
                    {
                        if ((IDDB.GetInstance().AccountExists(sLoginID)) && (IDDB.GetInstance().GetAccount(sLoginID, ref DBRecord)))
                        {
                            if ((DBRecord.nErrorCount < 5) || ((HUtil32.GetTickCount() - DBRecord.dwActionTick) > 180000))
                            {
                                if (DBRecord.UserEntry.sPassword == sOldPassword)
                                {
                                    DBRecord.nErrorCount = 0;
                                    DBRecord.UserEntry.sPassword = sNewPassword;
                                    nCode = 1;
                                }
                                else
                                {
                                    DBRecord.nErrorCount++;
                                    DBRecord.dwActionTick = HUtil32.GetTickCount();
                                    nCode = -1;
                                }
                                IDDB.GetInstance().UpdateAccount(sLoginID, DBRecord);
                            }
                            else
                            {
                                nCode = -2;
                                if (HUtil32.GetTickCount() < DBRecord.dwActionTick)
                                {
                                    DBRecord.dwActionTick = HUtil32.GetTickCount();
                                    IDDB.GetInstance().UpdateAccount(sLoginID, DBRecord);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    IDDB.GetInstance().Close();
                }
                if (nCode == 1)
                {
                    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_CHGPASSWD_SUCCESS, 0, 0, 0, 0);
                    WriteLogMsg(Config, sChgMsg, ref DBRecord.UserEntry, ref DBRecord.UserEntryAdd);
                }
                else
                {
                    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_CHGPASSWD_FAIL, nCode, 0, 0, 0);
                }
                SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMain.ChangePassword");
            }
        }

        public void AccountCheckProtocol(TUserInfo UserInfo, int nDate)
        {
            TDefaultMessage DefMsg;

            // MainOutMessage(IntToStr(nVersionDate));
            if (nDate < LSShare.nVersionDate)
            {
                DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_CERTIFICATION_FAIL, 0, 0, 0, 0);
            }
            else
            {
                DefMsg = EncryptUnit.MakeDefaultMsg(Common.SM_CERTIFICATION_SUCCESS, 0, 0, 0, 0);
                UserInfo.nVersionDate = nDate;
                UserInfo.boCertificationOK = true;
            }
            SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
        }

        public bool KickUser(TConfig Config, TUserInfo UserInfo, int nKickType)
        {
            bool result;
            int I;
            int II;
            TGateInfo GateInfo;
            TUserInfo User;
            const string sKickMsg = "Kick: {0}";
            result = false;
            if (Config.boShowDetailMsg)
            {
                LSShare.MainOutMessage(string.Format(sKickMsg, new string[] { UserInfo.sUserIPaddr }));
            }
            switch (nKickType)
            {
                case 0:
                    SendGateKickMsg(UserInfo.Socket, UserInfo.sSockIndex);
                    break;

                case 1:
                    SendGateAddTempBlockList(UserInfo.Socket, UserInfo.sSockIndex);
                    break;

                case 2:
                    SendGateAddBlockList(UserInfo.Socket, UserInfo.sSockIndex);
                    break;
            }
            result = true;
            return result;
        }

        public uint GetMakeAccountTick(DateTime CreateDate)
        {
            uint result;
            long nInt64 = 0;
            int wYear;
            int wMonth;
            int wDay;
            int wNYear;
            int wNMonth;
            int wNDay;
            try
            {
                wYear = DateTime.Now.Year;
                wMonth = DateTime.Now.Month;
                wDay = DateTime.Now.Day;
                wNYear = CreateDate.Year;
                wNMonth = CreateDate.Month;
                wNDay = CreateDate.Day;
                if ((wYear == wNYear) && (wMonth == wNMonth) && (wDay == wNDay))
                {
                    //nInt64 = SecondsBetween(DateTime.Now, CreateDate);
                    result = ((uint)nInt64 * 1000);
                }
                else
                {
                    result = 60 * 1000 * 60;
                }
            }
            catch
            {
                result = 60 * 1000 * 60;
            }
            return result;
        }

        public unsafe void AccountLogin(TConfig Config, TUserInfo UserInfo, string sData)
        {
            string sLoginID = string.Empty;
            string sPassword = string.Empty;
            int nCode;
            bool boNeedUpdate;
            TDefaultMessage DefMsg;
            TUserEntry UserEntry = default(TUserEntry);
            int nIDCost;
            int nIPCost;
            int nIDCostIndex;
            int nIPCostIndex;
            TAccountDBRecord DBRecord = default(TAccountDBRecord);

            //bool boPayCost;
            int nPayMode;

            //string sServerName;
            string sSelGateIP = string.Empty;
            int nSelGatePort = 0;
            try
            {
                sPassword = HUtil32.GetValidStr3(EncryptUnit.DeCodeString(sData), ref sLoginID, new string[] { "/" });
                nCode = 0;
                boNeedUpdate = false;
                try
                {
                    if (IDDB.GetInstance().Open())
                    {
                        if ((IDDB.GetInstance().AccountExists(sLoginID)) && (IDDB.GetInstance().GetAccount(sLoginID, ref DBRecord)))
                        {
                            // 自动解除锁定账号
                            if ((Config.boUnLockAccount) && (DBRecord.nErrorCount >= 5) && ((HUtil32.GetTickCount() - DBRecord.dwActionTick) >= Config.dwUnLockAccountTime * 60 * 1000))
                            {
                                DBRecord.nErrorCount = 0;
                                DBRecord.dwActionTick = 0;
                                DBRecord.dwActionTick = HUtil32.GetTickCount() - 70000;
                            }
                            if ((DBRecord.nErrorCount < 5) || ((HUtil32.GetTickCount() - DBRecord.dwActionTick) > 60000))
                            {
                                if (DBRecord.UserEntry.sPassword == sPassword)
                                {
                                    DBRecord.nErrorCount = 0;
                                    if ((DBRecord.UserEntry.sUserName == "") || (DBRecord.UserEntryAdd.sQuiz2 == ""))
                                    {
                                        UserEntry = DBRecord.UserEntry;
                                        boNeedUpdate = true;
                                    }

                                    //DBRecord.Header.CreateDate = UserInfo.dtDateTime;
                                    nCode = 1;
                                }
                                else
                                {
                                    DBRecord.nErrorCount++;
                                    DBRecord.dwActionTick = HUtil32.GetTickCount();
                                    nCode = -1;
                                }
                                IDDB.GetInstance().UpdateAccount(sLoginID, DBRecord);
                            }
                            else
                            {
                                nCode = -2;
                                DBRecord.dwActionTick = HUtil32.GetTickCount();
                                IDDB.GetInstance().UpdateAccount(sLoginID, DBRecord);
                            }
                        }
                    }
                }
                finally
                {
                    IDDB.GetInstance().Close();
                }
                if ((nCode == 1) && IsLogin(Config, sLoginID))
                {
                    SessionKick(Config, sLoginID);
                    nCode = -3;
                }
                if (boNeedUpdate)
                {
                    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_NEEDUPDATE_ACCOUNT, 0, 0, 0, 0);

                    TUserEntryData* pUserEntry = (TUserEntryData*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TUserEntryData)));

                    HUtil32.StrToSByteArry(UserEntry.sAccount, pUserEntry->sAccount, (byte)12, ref pUserEntry->AccoutLen);

                    HUtil32.StringToSBytePtr(UserEntry.sAccount, pUserEntry->sAccount, UserEntry.sAccount.Length);
                    pUserEntry->AccoutLen = (byte)UserEntry.sAccount.Length;
                    HUtil32.StringToSBytePtr(UserEntry.sUserName, pUserEntry->sUserName, UserEntry.sUserName.Length);
                    pUserEntry->UserNameLen = (byte)UserEntry.sUserName.Length;
                    HUtil32.StringToSBytePtr(UserEntry.sPassword, pUserEntry->sPassword, UserEntry.sPassword.Length);
                    pUserEntry->PasswordLen = (byte)UserEntry.sPassword.Length;
                    HUtil32.StringToSBytePtr(UserEntry.sAnswer, pUserEntry->sAnswer, UserEntry.sAnswer.Length);
                    pUserEntry->AnswerLen = (byte)UserEntry.sAnswer.Length;
                    HUtil32.StringToSBytePtr(UserEntry.sEMail, pUserEntry->sEMail, UserEntry.sEMail.Length);
                    pUserEntry->EMailLen = (byte)UserEntry.sEMail.Length;
                    HUtil32.StringToSBytePtr(UserEntry.sPhone, pUserEntry->sPhone, UserEntry.sPhone.Length);
                    pUserEntry->PhoneLen = (byte)UserEntry.sPhone.Length;
                    HUtil32.StringToSBytePtr(UserEntry.sQuiz, pUserEntry->sQuiz, UserEntry.sQuiz.Length);
                    pUserEntry->QuizLen = (byte)UserEntry.sQuiz.Length;
                    HUtil32.StringToSBytePtr(UserEntry.sSSNo, pUserEntry->sSSNo, UserEntry.sSSNo.Length);
                    pUserEntry->SSNoLen = (byte)UserEntry.sSSNo.Length;

                    SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeBuffer(pUserEntry, Marshal.SizeOf(typeof(TUserEntryData))));
                }
                if (nCode == 1)
                {
                    UserInfo.sAccount = sLoginID;
                    UserInfo.nSessionID = LSShare.GetSessionID();
                    try
                    {
                        //LSShare.CS_DB.Enter;
                        nIDCostIndex = Config.AccountCostList.IndexOfKey(UserInfo.sAccount);
                        nIPCostIndex = Config.IPaddrCostList.IndexOfKey(UserInfo.sUserIPaddr);
                        nIDCost = 0;
                        nIPCost = 0;

                        //boPayCost = false;
                        if (nIDCostIndex >= 0)
                        {
                            nIDCost = ((int)Config.AccountCostList[UserInfo.sAccount]);
                        }
                        if (nIPCostIndex >= 0)
                        {
                            nIPCost = ((int)Config.IPaddrCostList[UserInfo.sUserIPaddr]);

                            //boPayCost = true;
                        }
                    }
                    finally
                    {
                        // LSShare.CS_DB.Leave;
                    }
                    if ((nIDCost >= 0) || (nIPCost >= 0))
                    {
                        UserInfo.boPayCost = true;
                    }
                    else
                    {
                        UserInfo.boPayCost = false;
                    }
                    UserInfo.nIDDay = HUtil32.LoWord(nIDCost);
                    UserInfo.nIDHour = HUtil32.HiWord(nIDCost);
                    UserInfo.nIPDay = HUtil32.LoWord(nIPCost);
                    UserInfo.nIPHour = HUtil32.HiWord(nIPCost);
                    GetSelGateInfo(Config, UserInfo.sServerName, Config.sGateIPaddr, ref sSelGateIP, ref nSelGatePort);
                    if ((sSelGateIP != "") && (nSelGatePort > 0))
                    {
                        UserInfo.boPayCost = false;
                        nPayMode = 5;
                        if (UserInfo.nIDHour > 0)
                        {
                            nPayMode = 2;
                        }
                        if (UserInfo.nIPHour > 0)
                        {
                            nPayMode = 4;
                        }
                        if (UserInfo.nIPDay > 0)
                        {
                            nPayMode = 3;
                        }
                        if (UserInfo.nIDDay > 0)
                        {
                            nPayMode = 1;
                        }
                        if (!UserInfo.boPayCost)
                        {
                            DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_PASSOK_SELECTSERVER, 0, 0, 0, 0);
                        }
                        else
                        {
                            DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_PASSOK_SELECTSERVER, nIDCost, HUtil32.LoWord(nIPCost), HUtil32.HiWord(nIPCost), 0);
                        }
                        SessionAdd(Config, UserInfo.sAccount, UserInfo.sUserIPaddr, UserInfo.sServerName, UserInfo.nSessionID, UserInfo.boPayCost, false);
                        FrmMasSoc.SendServerMsg(Common.SS_OPENSESSION, UserInfo.sServerName, UserInfo.sAccount + '/' + (UserInfo.nSessionID).ToString() + '/' + ((Convert.ToInt32(UserInfo.boPayCost))).ToString() + '/' + (nPayMode).ToString() + '/' + UserInfo.sUserIPaddr + '/' + (UserInfo.dwMakeAccountTick).ToString());
                        SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeString(sSelGateIP + '/' + (nSelGatePort).ToString() + '/' + (UserInfo.nSessionID).ToString()));
                    }
                    else
                    {
                    }
                }
                else
                {
                    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_PASSWD_FAIL, nCode, 0, 0, 0);
                    SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                LSShare.MainOutMessage("TFrmMain.LoginUser");
            }
        }

        public void GetSelGateInfo(TConfig Config, string sServerName, string sIPaddr, ref string sSelGateIP, ref int nSelGatePort)
        {
            int I;
            int nGateIdx;
            int nGateCount;
            int nSelIdx;
            bool boSelected;
            try
            {
                sSelGateIP = "";
                nSelGatePort = 0;
                for (I = 0; I < Config.nRouteCount; I++)
                {
                    if (Config.boDynamicIPMode || ((Config.GateRoute[I].sServerName == sServerName) && (Config.GateRoute[I].sPublicAddr == sIPaddr)))
                    {
                        nGateCount = 0;
                        nGateIdx = 0;
                        while (true)
                        {
                            if ((Config.GateRoute[I].Gate[nGateIdx].sIPaddr != "") && (Config.GateRoute[I].Gate[nGateIdx].boEnable))
                            {
                                nGateCount++;
                            }
                            nGateIdx++;
                            if (nGateIdx >= 10)
                            {
                                break;
                            }
                        }
                        if (nGateCount <= 0)
                        {
                            break;
                        }

                        // 如果没有相关网关IP设置，则跳出
                        nSelIdx = Config.GateRoute[I].nSelIdx;
                        boSelected = false;
                        for (nGateIdx = nSelIdx + 1; nGateIdx <= 9; nGateIdx++)
                        {
                            if ((Config.GateRoute[I].Gate[nGateIdx].sIPaddr != "") && (Config.GateRoute[I].Gate[nGateIdx].boEnable))
                            {
                                Config.GateRoute[I].nSelIdx = nGateIdx;
                                boSelected = true;
                                break;
                            }
                        }
                        if (!boSelected)
                        {
                            for (nGateIdx = 0; nGateIdx < nSelIdx; nGateIdx++)
                            {
                                if ((Config.GateRoute[I].Gate[nGateIdx].sIPaddr != "") && (Config.GateRoute[I].Gate[nGateIdx].boEnable))
                                {
                                    Config.GateRoute[I].nSelIdx = nGateIdx;
                                    break;
                                }
                            }
                        }
                        nSelIdx = Config.GateRoute[I].nSelIdx;
                        sSelGateIP = Config.GateRoute[I].Gate[nSelIdx].sIPaddr;
                        nSelGatePort = Config.GateRoute[I].Gate[nSelIdx].nPort;
                        break;
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMain.GetSelGateInfo");
            }
        }

        public string GetServerListInfo()
        {
            string result = string.Empty;
            string sServerInfo = string.Empty;
            int I;
            string sServerName;
            TConfig Config;
            Config = LSShare.g_Config;
            try
            {
                for (I = 0; I < Config.ServerNameList.Count; I++)
                {
                    sServerName = Config.ServerNameList[I];
                    if (sServerName != "")
                    {
                        sServerInfo = sServerInfo + sServerName + '/' + (FrmMasSoc.ServerStatus(sServerName)).ToString() + '/';
                    }
                }
                result = sServerInfo;
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMain.GetServerListInfo");
            }
            return result;
        }

        /// <summary>
        /// 查询服务器列表
        /// </summary>
        /// <param name="Config"></param>
        /// <param name="UserInfo"></param>
        public void AccountQueryServerName(TConfig Config, TUserInfo UserInfo)
        {
            string sServerName;
            TDefaultMessage DefMsg;
            if ((UserInfo.sAccount == ""))
            {
                UserInfo.boSelServer = false;
                DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_SERVERNAME, 0, 0, 0, Config.ServerNameList.Count);
                sServerName = GetServerListInfo();
                SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeString(sServerName));
            }
        }

        public void AccountSelectServer(TConfig Config, TUserInfo UserInfo, string sData)
        {
            string sServerName;
            TDefaultMessage DefMsg;
            bool boPayCost;
            int nPayMode;
            string sSelGateIP = string.Empty;
            int nSelGatePort = 0;
            int nIndex;
            const string sSelServerMsg = "Server: %s/%s-%s:%d";
            sServerName = EncryptUnit.DeCodeString(sData, true);
            if ((UserInfo.sAccount == "") && (sServerName != "") && (!IsLogin(Config, UserInfo.nSessionID)))
            {
                GetSelGateInfo(Config, sServerName, Config.sGateIPaddr, ref sSelGateIP, ref nSelGatePort);
                if ((sSelGateIP != "") && (nSelGatePort > 0))
                {
                    if (Config.boDynamicIPMode)
                    {
                        sSelGateIP = UserInfo.sGateIPaddr;// 增加支动态IP
                    }
                    UserInfo.sServerName = sServerName;
                    UserInfo.boSelServer = true;
                    boPayCost = false;
                    UserInfo.boPayCost = false;
                    nPayMode = 5;
                    if (UserInfo.nIDHour > 0)
                    {
                        nPayMode = 2;
                    }
                    if (UserInfo.nIPHour > 0)
                    {
                        nPayMode = 4;
                    }
                    if (UserInfo.nIPDay > 0)
                    {
                        nPayMode = 3;
                    }
                    if (UserInfo.nIDDay > 0)
                    {
                        nPayMode = 1;
                    }
                    if (FrmMasSoc.IsNotUserFull(sServerName))
                    {
                        UserInfo.dwMakeAccountTick = UserInfo.dwClientTick - 1000 * 6;
                        nIndex = Config.MakeAccountList.IndexOfKey(UserInfo.sAccount);
                        if (nIndex >= 0)
                        {
                            HUtil32.EnterCriticalSection(Config.MakeAccountList);
                            try
                            {
                                UserInfo.dwMakeAccountTick = ((uint)Config.MakeAccountList[nIndex]);
                                Config.MakeAccountList.Remove(nIndex);
                            }
                            finally
                            {
                                HUtil32.LeaveCriticalSection(Config.MakeAccountList);
                            }
                        }
                        DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_SELECTSERVER_OK, UserInfo.nSessionID, 0, 0, 0);
                        SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
                    }
                    else
                    {
                        UserInfo.boSelServer = false;
                        SessionDel(Config, UserInfo.nSessionID);
                        DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_STARTFAIL, 0, 0, 0, 0);
                        SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
                    }
                }
            }
        }

        public void AccountUpdateUserInfo(TConfig Config, TUserInfo UserInfo, string sData)
        {
            TUserEntry UserEntry;
            TUserEntryAdd UserAddEntry;
            TAccountDBRecord DBRecord;
            int nLen;
            string sUserEntryMsg;
            string sUserAddEntryMsg;
            int nCode;
            TDefaultMessage DefMsg;
            int n10;

            //try
            //{
            //    FillChar(UserEntry, sizeof(TUserEntry), '\0');
            //    FillChar(UserAddEntry, sizeof(TUserEntryAdd), '\0');
            //    nLen = LSShare.GetCodeMsgSize(sizeof(TUserEntry) * 4 / 3);
            //    sUserEntryMsg = sData.Substring(1 - 1, nLen);
            //    sUserAddEntryMsg = sData.Substring(nLen + 1 - 1, sData.Length - nLen);
            //    EncryptUnit.DecodeBuffer(sUserEntryMsg, UserEntry, sizeof(TUserEntry));
            //    EncryptUnit.DecodeBuffer(sUserAddEntryMsg, UserAddEntry, sizeof(TUserEntryAdd));
            //    nCode = -1;
            //    if ((UserInfo.sAccount == UserEntry.sAccount) && LSShare.CheckAccountName(UserEntry.sAccount))
            //    {
            //        try
            //        {
            //            if (IDDB.Units.IDDB.AccountDB.Open())
            //            {
            //                n10 = IDDB.Units.IDDB.AccountDB.Index(UserEntry.sAccount);
            //                if ((n10 >= 0))
            //                {
            //                    if ((IDDB.Units.IDDB.AccountDB.Get(n10, ref DBRecord) >= 0))
            //                    {
            //                        DBRecord.UserEntry = UserEntry;
            //                        DBRecord.UserEntryAdd = UserAddEntry;
            //                        IDDB.Units.IDDB.AccountDB.Update(n10, ref DBRecord);
            //                        nCode = 1;
            //                    }
            //                }
            //                else
            //                {
            //                    nCode = 0;
            //                }
            //            }
            //        }
            //        finally
            //        {
            //            IDDB.Units.IDDB.AccountDB.Close();
            //        }
            //    }
            //    if (nCode == 1)
            //    {
            //        WriteLogMsg(Config, "upg", ref UserEntry, ref UserAddEntry);
            //        DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_UPDATEID_SUCCESS, 0, 0, 0, 0);
            //    }
            //    else
            //    {
            //        DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_UPDATEID_FAIL, nCode, 0, 0, 0);
            //    }
            //    SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
            //}
            //catch
            //{
            //    LSShare.MainOutMessage("TFrmMain.UpdateUserInfo");
            //}
        }

        public void AccountGetBackPassword(TUserInfo UserInfo, string sData)
        {
            string sMsg = string.Empty;
            string sAccount = string.Empty;
            string sQuest1 = string.Empty;
            string sAnswer1 = string.Empty;
            string sQuest2 = string.Empty;
            string sAnswer2 = string.Empty;
            string sPassword = string.Empty;
            string sBirthDay = string.Empty;
            int nCode;
            int nIndex;
            TDefaultMessage DefMsg;
            TAccountDBRecord DBRecord;
            sMsg = EncryptUnit.DeCodeString(sData);
            sMsg = HUtil32.GetValidStr3(sMsg, ref sAccount, new string[] { "\t" });
            sMsg = HUtil32.GetValidStr3(sMsg, ref sQuest1, new string[] { "\t" });
            sMsg = HUtil32.GetValidStr3(sMsg, ref sAnswer1, new string[] { "\t" });
            sMsg = HUtil32.GetValidStr3(sMsg, ref sQuest2, new string[] { "\t" });
            sMsg = HUtil32.GetValidStr3(sMsg, ref sAnswer2, new string[] { "\t" });
            sMsg = HUtil32.GetValidStr3(sMsg, ref sBirthDay, new string[] { "\t" });
            nCode = 0;

            //try
            //{
            //    if ((sAccount != "") && IDDB.AccountDB.Open())
            //    {
            //        nIndex = IDDB.AccountDB.Index(sAccount);
            //        if ((nIndex >= 0) && (IDDB.AccountDB.Get(nIndex, ref DBRecord) >= 0))
            //        {
            //            if ((DBRecord.nErrorCount < 5) || ((HUtil32.GetTickCount() - DBRecord.dwActionTick) > 180000))
            //            {
            //                nCode = -1;
            //                if ((DBRecord.UserEntry.sQuiz == sQuest1))
            //                {
            //                    nCode = -3;
            //                    if (DBRecord.UserEntry.sAnswer == sAnswer1)
            //                    {
            //                        if (DBRecord.UserEntryAdd.sBirthDay == sBirthDay)
            //                        {
            //                            nCode = 1;
            //                        }
            //                    }
            //                }
            //                if (nCode != 1)
            //                {
            //                    if ((DBRecord.UserEntryAdd.sQuiz2 == sQuest2))
            //                    {
            //                        nCode = -3;
            //                        if (DBRecord.UserEntryAdd.sAnswer2 == sAnswer2)
            //                        {
            //                            if (DBRecord.UserEntryAdd.sBirthDay == sBirthDay)
            //                            {
            //                                nCode = 1;
            //                            }
            //                        }
            //                    }
            //                }
            //                if (nCode == 1)
            //                {
            //                    sPassword = DBRecord.UserEntry.sPassword;
            //                }
            //                else
            //                {
            //                    DBRecord.nErrorCount++;
            //                    DBRecord.dwActionTick = HUtil32.GetTickCount();
            //                    IDDB.Units.IDDB.AccountDB.Update(nIndex, ref DBRecord);
            //                }
            //            }
            //            else
            //            {
            //                nCode = -2;
            //                if (HUtil32.GetTickCount() < DBRecord.dwActionTick)
            //                {
            //                    DBRecord.dwActionTick = HUtil32.GetTickCount();
            //                    IDDB.Units.IDDB.AccountDB.Update(nIndex, ref DBRecord);
            //                }
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    IDDB.Units.IDDB.AccountDB.Close();
            //}
            //if (nCode == 1)
            //{
            //    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_GETBACKPASSWD_SUCCESS, 0, 0, 0, 0);
            //    SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeString(sPassword));
            //}
            //else
            //{
            //    DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_GETBACKPASSWD_FAIL, nCode, 0, 0, 0);
            //    SendGateMsg(UserInfo.Socket, UserInfo.sSockIndex, EncryptUnit.EncodeMessage(DefMsg));
            //}
        }

        public void SendGateMsg(Socket Socket, string sSockIndex, string sMsg)
        {
            string sSendMsg;
            if ((Socket != null) && Socket.Connected)
            {
                sSendMsg = '%' + sSockIndex + "/#" + sMsg + "!$";
                Socket.Send(Encoding.Default.GetBytes(sSendMsg));
            }
        }

        public bool IsLogin(TConfig Config, int nSessionID)
        {
            bool result;
            TConnInfo ConnInfo;
            int I;
            result = false;

            //Config.SessionList.__Lock();
            try
            {
                for (I = 0; I < Config.SessionList.Count; I++)
                {
                    ConnInfo = Config.SessionList[I];
                    if ((ConnInfo.nSessionID == nSessionID))
                    {
                        result = true;
                        break;
                    }
                }
            }
            finally
            {
                //Config.SessionList.UnLock();
            }
            return result;
        }

        public bool IsLogin(TConfig Config, string sLoginID)
        {
            bool result;
            TConnInfo ConnInfo;
            int I;
            result = false;

            //Config.SessionList.__Lock();
            try
            {
                for (I = 0; I < Config.SessionList.Count; I++)
                {
                    ConnInfo = Config.SessionList[I];
                    if ((ConnInfo.sAccount == sLoginID))
                    {
                        result = true;
                        break;
                    }
                }
            }
            finally
            {
                //Config.SessionList.UnLock();
            }
            return result;
        }

        public void SessionKick(TConfig Config, string sLoginID)
        {
            TConnInfo ConnInfo;
            int I;

            //Config.SessionList.__Lock();
            try
            {
                for (I = 0; I < Config.SessionList.Count; I++)
                {
                    ConnInfo = Config.SessionList[I];
                    if ((ConnInfo.sAccount == sLoginID) && !ConnInfo.boKicked)
                    {
                        FrmMasSoc.SendServerMsg(Common.SS_CLOSESESSION, ConnInfo.sServerName, ConnInfo.sAccount + '/' + (ConnInfo.nSessionID).ToString());

                        //@ Unsupported function or procedure: 'HUtil32.GetTickCount()'
                        ConnInfo.dwKickTick = HUtil32.GetTickCount();
                        ConnInfo.boKicked = true;
                    }
                    Config.SessionList[I] = ConnInfo;
                }
            }
            finally
            {
                //Config.SessionList.UnLock();
            }
        }

        public void SessionAdd(TConfig Config, string sAccount, string sIPaddr, string sServerName, int nSessionID, bool boPayCost, bool bo11)
        {
            TConnInfo ConnInfo;
            ConnInfo = new TConnInfo();
            ConnInfo.sAccount = sAccount;
            ConnInfo.sIPaddr = sIPaddr;
            ConnInfo.sServerName = sServerName;
            ConnInfo.nSessionID = nSessionID;
            ConnInfo.boPayCost = boPayCost;
            ConnInfo.bo11 = bo11;
            ConnInfo.dwKickTick = HUtil32.GetTickCount();
            ConnInfo.dwStartTick = HUtil32.GetTickCount();
            ConnInfo.boKicked = false;

            //Config.SessionList.__Lock();
            try
            {
                Config.SessionList.Add(ConnInfo);
            }
            finally
            {
                //    Config.SessionList.UnLock();
            }
        }

        public void SendGateKickMsg(Socket Socket, string sSockIndex)
        {
            string sSendMsg;
            if ((Socket != null) && Socket.Connected)
            {
                sSendMsg = "%+-" + sSockIndex + '$';
                Socket.Send(Encoding.Default.GetBytes(sSendMsg));
            }
        }

        public void SendGateAddBlockList(Socket Socket, string sSockIndex)
        {
            string sSendMsg;
            if ((Socket != null) && Socket.Connected)
            {
                sSendMsg = "%+B" + sSockIndex + '$';
                Socket.Send(Encoding.Default.GetBytes(sSendMsg));
            }
        }

        public void SendGateAddTempBlockList(Socket Socket, string sSockIndex)
        {
            string sSendMsg;
            if ((Socket != null) && Socket.Connected)
            {
                sSendMsg = "%+T" + sSockIndex + '$';
                Socket.Send(Encoding.Default.GetBytes(sSendMsg));
            }
        }

        public void SendGateAddIPToGate(Socket Socket, string sUserIPaddr)
        {
            string sSendMsg;
            if ((Socket != null) && Socket.Connected)
            {
                sSendMsg = "%+M" + sUserIPaddr + '$';
                Socket.Send(Encoding.Default.GetBytes(sSendMsg));
            }
        }

        public void SessionUpdate(TConfig Config, int nSessionID, string sServerName, bool boPayCost)
        {
            TConnInfo ConnInfo;
            int I;

            //Config.SessionList.__Lock();
            try
            {
                for (I = 0; I < Config.SessionList.Count; I++)
                {
                    ConnInfo = Config.SessionList[I];
                    if ((ConnInfo.nSessionID == nSessionID))
                    {
                        ConnInfo.sServerName = sServerName;
                        ConnInfo.bo11 = boPayCost;
                        break;
                    }
                }
            }
            finally
            {
                //Config.SessionList.UnLock();
            }
        }

        public void GenServerNameList(TConfig Config)
        {
            int I;
            int II;
            bool boD;
            try
            {
                Config.ServerNameList.Clear();
                for (I = 0; I < Config.nRouteCount; I++)
                {
                    boD = true;
                    for (II = 0; II < Config.ServerNameList.Count; II++)
                    {
                        if (Config.ServerNameList[II] == Config.GateRoute[I].sServerName)
                        {
                            boD = false;
                        }
                    }
                    if (boD)
                    {
                        Config.ServerNameList.Add(Config.GateRoute[I].sServerName);
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMain.GenServerNameList");
            }
        }

        public void SessionClearNoPayMent(TConfig Config)
        {
            int I;
            TConnInfo ConnInfo;

            //Config.SessionList.__Lock();
            lock (objSessionList)
            {
                try
                {
                    for (I = Config.SessionList.Count - 1; I >= 0; I--)
                    {
                        ConnInfo = Config.SessionList[I];
                        if (!ConnInfo.boKicked && !Config.boTestServer && !ConnInfo.bo11)
                        {
                            //@ Unsupported function or procedure: 'HUtil32.GetTickCount()'
                            if ((HUtil32.GetTickCount() - ConnInfo.dwStartTick) > 60 * 60 * 1000)
                            {
                                //@ Unsupported function or procedure: 'HUtil32.GetTickCount()'
                                ConnInfo.dwStartTick = HUtil32.GetTickCount();
                                if (!IsPayMent(Config, ConnInfo.sIPaddr, ConnInfo.sAccount))
                                {
                                    FrmMasSoc.SendServerMsg(Common.SS_KICKUSER, ConnInfo.sServerName, ConnInfo.sAccount + '/' + (ConnInfo.nSessionID).ToString());

                                    //@ Unsupported function or procedure: 'Dispose'
                                    //Dispose(ConnInfo);
                                    Config.SessionList.RemoveAt(I);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    //Config.SessionList.UnLock();
                }
            }
        }

        public void LoadIPaddrCostList(TConfig Config, SortedList QuickList)
        {
            try
            {
                lock (LSShare.CS_DB)
                {
                    Config.IPaddrCostList.Clear();
                    Config.IPaddrCostList.Add("", QuickList);
                }
            }
            finally
            {
                //LSShare.CS_DB.Leave;
            }
        }

        public void LoadAccountCostList(TConfig Config, SortedList QuickList)
        {
            try
            {
                //@ Unsupported property or method(C): 'Enter'
                //LSShare.CS_DB.Enter;
                lock (LSShare.CS_DB)
                {
                    Config.AccountCostList.Clear();
                    Config.AccountCostList.Add("", QuickList);
                }
            }
            finally
            {
                //@ Unsupported property or method(C): 'Leave'
                //LSShare.CS_DB.Leave;
            }
        }

        public void SaveContLogMsg(TConfig Config, string sLogMsg)
        {
            //ushort Year;
            //ushort Month;
            //ushort Day;
            //ushort Hour;
            //ushort Min;
            //ushort Sec;
            //ushort MSec;
            //string sLogDir;
            //string sLogFileName;
            //System.IO.Stream LogFile;
            //if (sLogMsg == "")
            //{
            //    return;
            //}
            //Year = DateTime.Today.Year;
            //Month = DateTime.Today.Month;
            //Day = DateTime.Today.Day;
            //Hour = DateTime.Now.Hour;
            //Min = DateTime.Now.Minute;
            //Sec = DateTime.Now.Second;
            //MSec = DateTime.Now.Millisecond;
            //if (!Directory.Exists(Config.sCountLogDir))
            //{
            //    Directory.CreateDirectory(Config.sCountLogDir);
            //}
            //sLogDir = Config.sCountLogDir + (Year).ToString() + '-' + HUtil32.IntToStr2(Month);
            //if (!Directory.Exists(sLogDir))
            //{
            //    //@ Undeclared identifier(3): 'CreateDirectory'
            //    CreateDirectory((sLogDir as string), null);
            //}
            //sLogFileName = sLogDir + '\\' + (Year).ToString() + '-' + HUtil32.IntToStr2(Month) + '-' + HUtil32.IntToStr2(Day) + ".txt";
            //LogFile = new FileInfo(sLogFileName);
            //if (!File.Exists(sLogFileName))
            //{
            //    StreamWriter _W_0 = LogFile.CreateText();
            //}
            //else
            //{
            //    _W_0 = LogFile.AppendText();
            //}
            //sLogMsg = sLogMsg + "\t" + DateTime.Now.ToString();
            //_W_0.WriteLine(sLogMsg);
            //_W_0.Close();
        }

        public void WriteLogMsg(TConfig Config, string sType, ref TUserEntry UserEntry, ref TUserEntryAdd UserAddEntry)
        {
            //ushort Year;
            //ushort Month;
            //ushort Day;
            //string sLogDir;
            //string sLogFileName;
            //System.IO.Stream LogFile;
            //string sLogFormat;
            //string sLogMsg;
            //Year = DateTime.Today.Year;
            //Month = DateTime.Today.Month;
            //Day = DateTime.Today.Day;
            //if (!Directory.Exists(Config.sChrLogDir))
            //{
            //    Directory.CreateDirectory(Config.sChrLogDir);
            //}
            //sLogDir = Config.sChrLogDir + (Year).ToString() + '-' + HUtil32.IntToStr2(Month);
            //if (!Directory.Exists(sLogDir))
            //{
            //    //@ Undeclared identifier(3): 'CreateDirectory'
            //    CreateDirectory((sLogDir as string), null);
            //}
            //sLogFileName = sLogDir + "\\Id_" + HUtil32.IntToStr2(Day) + ".log";
            //LogFile = new FileInfo(sLogFileName);
            //if (!File.Exists(sLogFileName))
            //{
            //    _W_0 = LogFile.CreateText();
            //}
            //else
            //{
            //    _W_0 = LogFile.AppendText();
            //}
            //sLogFormat = "*%s*\t%s\t\"%s\"\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t[%s]";
            //sLogMsg = Format(sLogFormat, new string[] { sType, UserEntry.sAccount, UserEntry.sPassword, UserEntry.sUserName, UserEntry.sSSNo, UserEntry.sQuiz, UserEntry.sAnswer, UserEntry.sEMail, UserAddEntry.sQuiz2, UserAddEntry.sAnswer2, UserAddEntry.sBirthDay, UserAddEntry.sMobilePhone, DateTime.Now.ToString() });
            //_W_0.WriteLine(sLogMsg);
            //_W_0.Close();
        }

        public void StartService(TConfig Config)
        {
            LoadConfig loadConfig = new LoadConfig(Config);

            // 载入配置
        }

        public TFrmMain()
        {
            InitializeComponent();

            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void OpenRouteConfig()
        {
            FrmGateSetting = new TFrmGateSetting();
            FrmGateSetting.Show();
        }

        public void MENU_OPTION_ROUTEClick(System.Object Sender, System.EventArgs _e1)
        {
            OpenRouteConfig();
        }

        public void MENU_VIEW_SESSIONClick(System.Object Sender, System.EventArgs _e1)
        {
            TfrmGrobalSession frmGrobalSession = new TfrmGrobalSession();
            frmGrobalSession.ShowDialog();
        }

        public void CbViewLogClick(System.Object Sender, System.EventArgs _e1)
        {
            TConfig Config;
            Config = LSShare.g_Config;
            Config.boShowDetailMsg = CbViewLog.Checked;
        }

        public void FormDestroy(Object Sender)
        {
            int I;
            int II;
            TGateInfo GateInfo;
            TUserInfo UserInfo;
            TConfig Config;
            ArrayList IPList;
            Config = LSShare.g_Config;
            for (I = 0; I < Config.GateList.Count; I++)
            {
                GateInfo = Config.GateList[I];
                for (II = 0; II < GateInfo.UserList.Count; II++)
                {
                    UserInfo = GateInfo.UserList[I];
                    this.Dispose(UserInfo);
                }

                //GateInfo.UserList.Free;
                this.Dispose(GateInfo);
            }

            //Config.GateList.Free;
            // for I := 0 to Config.MakeAccountList.Count - 1 do begin
            // Dispose(pTMakeAccount(Config.MakeAccountList.Objects[I]));
            // end;
            //Config.MakeAccountList.Free;
            //Config.SessionList.Free;
            //Config.ServerNameList.Free;
            //SList_0344.Free;
            //LSShare.StringList_0.Free;
            //LSShare.CS_DB.Free;
        }

        public void ExecTimerTimer(object obj)
        {
            TConfig Config;
            TConnInfo ConnInfo;
            Config = LSShare.g_Config;
            if (LSShare.bo470D20 && !LSShare.g_boDataDBReady)
            {
                return;
            }
            LSShare.bo470D20 = true;
            try
            {
                ProcessGate(Config);
            }
            finally
            {
                LSShare.bo470D20 = false;
            }
        }

        public void Memo1DblClick(System.Object Sender, System.EventArgs _e1)
        {
            OpenRouteConfig();
        }

        public void StateTimer_Timer(object obj)
        {
            int I;
            TConfig Config;
            Config = LSShare.g_Config;
            this.Invoke((MethodInvoker)delegate
            {
                Label1.Text = (Config.dwProcessGateTime).ToString();

                //CkLogin.Checked = GSocket.NumConnectedSockets;
                CkLogin.Text = "连接 (" + GSocket.NumConnectedSockets.ToString() + ')';
                LbMasCount.Text = (LSShare.nOnlineCountMin).ToString() + '/' + (LSShare.nOnlineCountMax).ToString();
                if (Memo1.Lines.Length > 200)
                {
                    Memo1.Clear();
                }
            });

            HUtil32.EnterCriticalSection(LSShare.g_OutMessageCS);
            try
            {
                for (I = 0; I < LSShare.g_MainMsgList.Count; I++)
                {
                    // 从缓存里加到memo里
                    this.Invoke((MethodInvoker)delegate { Memo1.AppendText(LSShare.g_MainMsgList[I] + Environment.NewLine); });
                }
                LSShare.g_MainMsgList.Clear();

                // 清除缓存
            }
            finally
            {
                HUtil32.LeaveCriticalSection(LSShare.g_OutMessageCS);
            }
            I = 0;

            //while (true)
            //{
            //    if (LSShare.StringList_0.Count <= I)
            //    {
            //        break;
            //    }
            //    if (HUtil32.GetTickCount() - ((uint)LSShare.StringList_0.Values[I]) > 60000)
            //    {
            //        LSShare.StringList_0.Remove(I);
            //        continue;
            //    }
            //    I++;
            //}
            SessionClearKick(Config);
            SessionClearNoPayMent(Config);
        }

        public void StartTimerTimer(object obj)
        {
            TConfig Config;
            Config = LSShare.g_Config;
            LSShare.SendGameCenterMsg(Common.SG_STARTNOW, "正在启动登录服务器...");
            this.Invoke((MethodInvoker)delegate { Memo1.AppendText("1) 正在启动服务器..." + Environment.NewLine); });
            this.Invoke((MethodInvoker)delegate { Memo1.AppendText("2) 正在等待服务器连接..." + Environment.NewLine); });

            //启动线程
            ParseList.th.Start();
            while (true)
            {
                Application.DoEvents();
                if (FrmMasSoc.CheckReadyServers())
                {
                    break;
                }
                Thread.Sleep(1);
            }
            GSocket.Init();
            GSocket.Start(new IPEndPoint(IPAddress.Parse(Config.sGateAddr), Config.nGatePort));
            this.Invoke((MethodInvoker)delegate { Memo1.AppendText("3) 服务器启动完成..." + Environment.NewLine); });
            ExecTimer = new System.Threading.Timer(new TimerCallback(ExecTimerTimer), null, 0, 1);
            boExecTimerEnabled = true;
            LSShare.SendGameCenterMsg(Common.SG_STARTOK, "登录服务器启动完成...");
            StartTimer.Dispose();
        }

        public void SpeedButton1Click(System.Object Sender, System.EventArgs _e1)
        {
            TFrmFindUserId FrmFindUserId = new TFrmFindUserId();
            FrmFindUserId.Show();
        }

        public void MENU_CONTROL_EXITClick(System.Object Sender, System.EventArgs _e1)
        {
            this.Close();
        }

        // Note: the original parameters are Object Sender, ref bool CanClose
        public void FormCloseQuery(System.Object Sender, System.ComponentModel.CancelEventArgs _e1)
        {
        }

        public void BtnViewClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void CountLogTimerTimer(object obj)
        {
            //string sLogMsg;
            //TConfig Config;
            //const string sFormatMsg = "{0}/{1}";
            //Config = LSShare.g_Config;
            ////@ Unsupported function or procedure: 'Format'
            //sLogMsg = string.Format(sFormatMsg, new int[] { LSShare.nOnlineCountMin, LSShare.nOnlineCountMax });
            //SaveContLogMsg(Config, sLogMsg);
            //LSShare.nOnlineCountMax = 0;
        }

        public void BtnShowServerUsersClick(System.Object Sender, System.EventArgs _e1)
        {
            int I;
            for (I = 0; I < TFrmMasSoc.nUserLimit; I++)
            {
                LSShare.MainOutMessage(TFrmMasSoc.UserLimit[I].sServerName + ' ' + (TFrmMasSoc.UserLimit[I].nLimitCountMin).ToString() + '/' + (TFrmMasSoc.UserLimit[I].nLimitCountMax).ToString());
            }
        }

        public delegate void RefMonitorGridDelegate();

        public void RefMonitorGrid()
        {
            MonitorGrid.BeginUpdate();
            int I;
            int nCol;
            string sServerName;
            List<TMsgServerInfo> ServerList;
            TMsgServerInfo MsgServer;
            try
            {
                ServerList = FrmMasSoc.m_ServerList;
                MonitorGrid.Items.Clear();
                int nIndex = 1;
                if ((ServerList.Count / 2) < 2)
                {
                    ListViewItem lvi = MonitorGrid.Items.Add(nIndex++.ToString());
                    foreach (ColumnHeader ch in MonitorGrid.Columns)
                    {
                        lvi.SubItems.Add("-");
                    }
                    ListViewItem lvi1 = MonitorGrid.Items.Add(nIndex++.ToString());
                    foreach (ColumnHeader ch in MonitorGrid.Columns)
                    {
                        lvi1.SubItems.Add("-");
                    }
                }
                else
                {
                    int RowCount = ((ServerList.Count / 2) + 1) + (ServerList.Count % 2);
                    for (int i = 0; i < RowCount; i++)
                    {
                        ListViewItem lvi = MonitorGrid.Items.Add(nIndex++.ToString());
                        foreach (ColumnHeader ch in MonitorGrid.Columns)
                        {
                            lvi.SubItems.Add("-");
                        }
                    }
                }
                for (I = 0; I < ServerList.Count; I++)
                {
                    nCol = (I % 2) * 3;
                    MsgServer = ServerList[I];
                    sServerName = MsgServer.sServerName;
                    if (sServerName != "")
                    {
                        if (MsgServer.nServerIndex == 99)
                        {
                            MonitorGrid.Items[(I % 2)].SubItems[1].Text = sServerName + " [DB]";
                        }
                        else
                        {
                            MonitorGrid.Items[(I % 2)].SubItems[1].Text = sServerName + ' ' + (MsgServer.nServerIndex).ToString();
                        }
                        MonitorGrid.Items[(I % 2)].SubItems[2].Text = MsgServer.sIPaddr;
                        MonitorGrid.Items[(I % 2)].SubItems[4].Text = (MsgServer.nOnlineCount).ToString();
                        if ((HUtil32.GetTickCount() - MsgServer.dwKeepAliveTick) < 30000)
                        {
                            MonitorGrid.Items[(I % 2)].SubItems[3].Text = "正常";
                        }
                        else
                        {
                            MonitorGrid.Items[(I % 2)].SubItems[3].Text = "超时";
                        }
                    }
                    else
                    {
                        MonitorGrid.Items[(I % 2)].SubItems[0].Text = "-";
                        MonitorGrid.Items[(I % 2)].SubItems.Add("-");
                        MonitorGrid.Items[(I % 2)].SubItems.Add("-");
                    }
                }
            }
            catch
            {
                LSShare.MainOutMessage("TFrmMain.MonitorTimerTimer ：异步刷新界面错误");
            }
            MonitorGrid.EndUpdate();
        }

        public void MonitorTimerTimer(object obj)
        {
            MonitorGrid.BeginInvoke(new RefMonitorGridDelegate(RefMonitorGrid));
        }

        public void SpeedButton2Click(System.Object Sender, System.EventArgs _e1)
        {
            if (Memo1.Height == LSShare.nMemoHeigh)
            {
                Memo1.Height = LSShare.nMemoHeigh * 3;
            }
            else
            {
                Memo1.Height = LSShare.nMemoHeigh;
            }
        }

        public void Panel2DblClick(System.Object Sender, System.EventArgs _e1)
        {
            LSShare.MainOutMessage(GetServerListInfo());
        }

        public void GameCenterGetUserAccount(string sData)
        {
        }

        public void GameCenterChangeAccountInfo(string sData)
        {
        }

        public void MENU_OPTION_GENERALClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void MENU_HELP_ABOUTClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void N1Click(System.Object Sender, System.EventArgs _e1)
        {
            TConfig Config;
            int I;
            int II;
            Config = LSShare.g_Config;
            Config.ServerNameList.Clear();
            for (I = Config.GateRoute.GetLowerBound(0); I <= Config.GateRoute.GetUpperBound(0); I++)
            {
                Config.GateRoute[I].sServerName = "";
                Config.GateRoute[I].sTitle = "";
                Config.GateRoute[I].sRemoteAddr = "";
                Config.GateRoute[I].sPublicAddr = "";
                Config.GateRoute[I].nSelIdx = 0;
                for (II = Config.GateRoute[I].Gate.GetLowerBound(0); II <= Config.GateRoute[I].Gate.GetUpperBound(0); II++)
                {
                    Config.GateRoute[I].Gate[II].sIPaddr = "";
                    Config.GateRoute[I].Gate[II].nPort = 0;
                    Config.GateRoute[I].Gate[II].boEnable = false;
                }
            }
            LoadAddrTable(Config);
            LSShare.MainOutMessage("加载路由列表完成...");
        }

        public void C1Click(System.Object Sender, System.EventArgs _e1)
        {
            int I;
            for (I = LSShare.ServerAddr.GetLowerBound(0); I <= LSShare.ServerAddr.GetUpperBound(0); I++)
            {
                LSShare.ServerAddr[I] = "";
            }
            FrmMasSoc.LoadServerAddr();
            for (I = TFrmMasSoc.UserLimit.GetLowerBound(0); I <= TFrmMasSoc.UserLimit.GetUpperBound(0); I++)
            {
                TFrmMasSoc.UserLimit[I].sServerName = "";
                TFrmMasSoc.UserLimit[I].sName = "";
                TFrmMasSoc.UserLimit[I].nLimitCountMin = 3000;
                TFrmMasSoc.UserLimit[I].nLimitCountMax = 0;
            }
            FrmMasSoc.LoadUserLimit();
            LSShare.MainOutMessage("加载配制文件完成...");
        }

        public void ApplicationEvents1Exception(Object Sender, Exception e)
        {
            LSShare.MainOutMessage(e.Message);
        }

        private void TFrmMain_Load(object sender, EventArgs e)
        {
            GSocket = new AsyncServer(1000, Int16.MaxValue);
            GSocket.OnClientConnect += new EventHandler<AsyncSockets.AsyncUserToken>(GSocket_OnClientConnect);
            GSocket.OnClientDisconnect += new EventHandler<AsyncSockets.AsyncUserToken>(GSocket_OnClientDisconnect);
            GSocket.OnClientRead += new EventHandler<AsyncSockets.AsyncUserToken>(GSocket_OnClientRead);
            GSocket.OnClientError += new EventHandler<AsyncSockets.AsyncSocketErrorEventArgs>(GSocket_OnClientError);
            int nX;
            int nY;
            TConfig Config;

            // 指针
            Config = LSShare.g_Config;

            // 指向配置结构
            //LSShare.g_dwGameCenterHandle = HUtil32.Str_ToInt(Environment.GetCommandLineArgs()[0], 0);
            //// 游戏中心句柄
            //nX = HUtil32.Str_ToInt(Environment.GetCommandLineArgs()[1], -1);
            //nY = HUtil32.Str_ToInt(Environment.GetCommandLineArgs()[2], -1);
            //if ((nX >= 0) || (nY >= 0))
            //{
            //    this.Left = nX;
            //    this.Top = nY;
            //}
            Config.GateCriticalSection = new object();
            Config.boRemoteClose = false;

            //向游戏中心发送消息
            LSShare.SendGameCenterMsg(Common.SG_FORMHANDLE, (this.Handle).ToString());

            // 发送主窗口句柄
            Config = LSShare.g_Config;
            StartService(Config);
            FrmMasSoc = new TFrmMasSoc();
            FrmMasSoc.FrmMain = this;
            FrmMasSoc.Show();
            FrmMasSoc.Hide();
            FrmMonSoc = new TFrmMonSoc();
            FrmMonSoc.FrmMasSoc = FrmMasSoc;
            FrmMonSoc.Show();
            FrmMonSoc.Hide();

            // 开启服务
            //g_MainMsgList:=TStringList.Create;
            LSShare.CS_DB = new object();
            LSShare.StringList_0 = new List<string>();
            LSShare.nSessionIdx = 1;
            LSShare.n47328C = 1;
            LSShare.nMemoHeigh = Memo1.Height;
            Config.GateList = new List<TGateInfo>();
            Config.SessionList = new List<TConnInfo>();
            Config.ServerNameList = new List<string>();
            SList_0344 = new List<string>();
            Config.AccountCostList = new SortedList();
            Config.MakeAccountList = new SortedList();
            Config.IPaddrCostList = new SortedList();

            //启动一个线程
            ParseList = new TThreadParseList(true);

            int I;
            int II;
            Config = LSShare.g_Config;
            Config.ServerNameList.Clear();
            Config.GateRoute = new TGateRoute[60];
            for (I = Config.GateRoute.GetLowerBound(0); I <= Config.GateRoute.GetUpperBound(0); I++)
            {
                Config.GateRoute[I].sServerName = "";
                Config.GateRoute[I].sTitle = "";
                Config.GateRoute[I].sRemoteAddr = "";
                Config.GateRoute[I].sPublicAddr = "";
                Config.GateRoute[I].nSelIdx = 0;
                Config.GateRoute[I].Gate = new TGateNet[10];
                for (II = Config.GateRoute[I].Gate.GetLowerBound(0); II <= Config.GateRoute[I].Gate.GetUpperBound(0); II++)
                {
                    Config.GateRoute[I].Gate[II].sIPaddr = "";
                    Config.GateRoute[I].Gate[II].nPort = 0;
                    Config.GateRoute[I].Gate[II].boEnable = false;
                }
            }
            LoadAddrTable(Config);

            //MonitorGrid.Items.Add(
            //MonitorGrid.Cells[0, 0] = "服务器名";
            //MonitorGrid.Cells[1, 0] = "用户数";
            //MonitorGrid.Cells[2, 0] = "状态";
            //MonitorGrid.Cells[3, 0] = "服务器名";
            //MonitorGrid.Cells[4, 0] = "用户数";
            //MonitorGrid.Cells[5, 0] = "状态";

            LSShare.g_OutMessageCS = new object();
            MonitorTimer = new System.Threading.Timer(new TimerCallback(MonitorTimerTimer), null, 1000, 1000);
            CountLogTimer = new System.Threading.Timer(new TimerCallback(CountLogTimerTimer), null, 1000, 300000);
            StateTimer = new System.Threading.Timer(new TimerCallback(StateTimer_Timer), null, 1000, 1000);
            StartTimer = new System.Threading.Timer(new TimerCallback(StartTimerTimer), null, 100, 100);
        }

        private void GSocket_OnClientError(object sender, AsyncSockets.AsyncSocketErrorEventArgs e)
        {
            LSShare.MainOutMessage(e.exception.Message);
        }

        private void GSocket_OnClientRead(object sender, AsyncSockets.AsyncUserToken e)
        {
            int I;
            TGateInfo GateInfo;
            TConfig Config;
            Config = LSShare.g_Config;
            HUtil32.EnterCriticalSection(Config.GateCriticalSection);
            try
            {
                for (I = 0; I < Config.GateList.Count; I++)
                {
                    GateInfo = Config.GateList[I];
                    if (Config.GateList[I].Socket == e.Socket)
                    {
                        //收信
                        byte[] data = new byte[e.BytesReceived];
                        Array.Copy(e.ReceiveBuffer, e.Offset, data, 0, e.BytesReceived);
                        int nMsgLen = e.BytesReceived;

                        GateInfo.sReceiveMsg = GateInfo.sReceiveMsg + Encoding.Default.GetString(data);
                        LSShare.MainOutMessage(GateInfo.sReceiveMsg);

                        //MessageBox.Show(Config.GateList[I].sReceiveMsg);
                        //Config.GateList[I] = GateInfo;
                        break;
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(Config.GateCriticalSection);
            }
        }

        private void GSocket_OnClientDisconnect(object sender, AsyncSockets.AsyncUserToken e)
        {
            int I;
            int II;
            TGateInfo GateInfo;
            TUserInfo UserInfo;
            TConfig Config;
            Config = LSShare.g_Config;
            HUtil32.EnterCriticalSection(Config.GateCriticalSection);
            try
            {
                for (I = 0; I < Config.GateList.Count; I++)
                {
                    GateInfo = Config.GateList[I];
                    if (GateInfo.Socket == e.Socket)
                    {
                        for (II = 0; II < GateInfo.UserList.Count; II++)
                        {
                            UserInfo = GateInfo.UserList[II];
                            if (Config.boShowDetailMsg)
                            {
                                LSShare.MainOutMessage("Close: " + UserInfo.sUserIPaddr);
                            }
                            this.Dispose(UserInfo);
                        }
                        this.Dispose(GateInfo);
                        Config.GateList.RemoveAt(I);
                        break;
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(Config.GateCriticalSection);
            }
        }

        private void GSocket_OnClientConnect(object sender, AsyncSockets.AsyncUserToken e)
        {
            TGateInfo GateInfo;
            TConfig Config;
            Config = LSShare.g_Config;
            if (!boExecTimerEnabled)
            {
                e.Socket.Disconnect(true);
                return;
            }
            GateInfo = new TGateInfo();
            GateInfo.Socket = e.Socket;

            //只取IP
            GateInfo.sIPaddr = LSShare.GetGatePublicAddr(Config, e.Socket.RemoteEndPoint.ToString().Split(':')[0]);
            GateInfo.sReceiveMsg = "";
            GateInfo.UserList = new List<TUserInfo>();
            GateInfo.dwKeepAliveTick = HUtil32.GetTickCount();

            //HUtil32.EnterCriticalSection(Config.GateCriticalSection);
            try
            {
                Config.GateList.Add(GateInfo);
            }
            finally
            {
                //    HUtil32.LeaveCriticalSection(Config.GateCriticalSection);
            }
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }

        private void TFrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            TConfig Config;
            const string sExitMsg = "是否确认停止登录服务器 ?";
            const string sExitTitle = "确认信息";
            Config = LSShare.g_Config;
            if (Config.boRemoteClose)
            {
                return;
            }
            if (MessageBox.Show(sExitMsg, sExitTitle, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
                Colsed = true;
                FrmMasSoc.Close();
                FrmMasSoc.Dispose();
                FrmMonSoc.Close();
                FrmMonSoc.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void TFrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            TConfig Config;
            Config = LSShare.g_Config;
            FAccountView.TFrmAccountView FrmAccountView = new FAccountView.TFrmAccountView();
            lock (LSShare.CS_DB)
            {
                try
                {
                    object[] obj = new object[Config.AccountCostList.Values.Count];
                    Config.AccountCostList.Values.CopyTo(obj, 0);
                    FrmAccountView.ListBox1.Items.AddRange(obj);

                    obj = new object[Config.IPaddrCostList.Values.Count];
                    Config.IPaddrCostList.Values.CopyTo(obj, 0);
                    FrmAccountView.ListBox2.Items.AddRange(obj);
                }
                finally
                {
                }
            }
            FrmAccountView.Top = this.Top;
            FrmAccountView.Left = this.Left;
            FrmAccountView.ShowDialog();
        }
    } // end TFrmMain
}