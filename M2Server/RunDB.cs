using System;
using System.Runtime.InteropServices;
using GameFramework;

namespace M2Server
{
    public class RunDB
    {
        public static bool DBSocketConnected()
        {
            return TFrmMain.DBSocket.IsConnected;
        }

        /// <summary>
        /// 获取DBSERBER发送过来的消息
        /// </summary>
        /// <param name="nQueryID"></param>
        /// <param name="nIdent"></param>
        /// <param name="nRecog"></param>
        /// <param name="sStr"></param>
        /// <param name="dwTimeOut"></param>
        /// <param name="boLoadRcd"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        public unsafe static bool GetDBSockMsg(int nQueryID, ref int nIdent, ref int nRecog, ref string sStr, uint dwTimeOut, bool boLoadRcd, string sName)
        {
            bool result;
            bool boLoadDBOK;
            uint dwTimeOutTick;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string sCheckFlag = string.Empty;
            string sDefMsg;
            string s38;
            int nLen;
            int nCheckCode;
            TDefaultMessage DefMsg;
            byte nCode;
            const string sLoadDBTimeOut = "[RunDB] 读取人物数据超时...";
            const string sSaveDBTimeOut = "[RunDB] 保存人物数据超时...";
            boLoadDBOK = false;
            result = false;
            dwTimeOutTick = HUtil32.GetTickCount();
            nCode = 0;
            while (true)
            {
                if ((HUtil32.GetTickCount() - dwTimeOutTick) > dwTimeOut)//dwTimeOut--等待消息的时间
                {
                    nCode = 1;
                    break;
                }
                s24 = "";
                HUtil32.EnterCriticalSection(M2Share.UserDBSection);
                try
                {
                    if (M2Share.g_Config.sDBSocketRecvText.IndexOf("!") > 0)
                    {
                        s24 = M2Share.g_Config.sDBSocketRecvText;
                        M2Share.g_Config.sDBSocketRecvText = "";
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(M2Share.UserDBSection);
                }
                if (s24 != "")
                {
                    s28 = "";
                    s24 = HUtil32.ArrestStringEx(s24, "#", "!", ref s28);
                    if (s28 != "")
                    {
                        s28 = HUtil32.GetValidStr3(s28, ref s2C, new string[] { "/" });
                        nLen = s28.Length;
                        if ((nLen >= sizeof(TDefaultMessage)) && (HUtil32.Str_ToInt(s2C, 0) == nQueryID))
                        {
                            nCheckCode = HUtil32.MakeLong(HUtil32.Str_ToInt(s2C, 0) ^ 170, nLen);
                            byte[] data = new byte[sizeof(int)];
                            fixed (byte* by = data) {
                                *(int*)by = nCheckCode;
                            }
                            sCheckFlag = EncryptUnit.EncodeBuffer(data, data.Length);
                            if (HUtil32.CompareBackLStr(s28, sCheckFlag, sCheckFlag.Length))
                            {
                                if (nLen == Grobal2.DEFBLOCKSIZE)
                                {
                                    sDefMsg = s28;
                                    s38 = "";
                                }
                                else
                                {
                                    sDefMsg = s28.Substring(0, Grobal2.DEFBLOCKSIZE);
                                    s38 = s28.Substring(Grobal2.DEFBLOCKSIZE + 1 - 1, s28.Length - Grobal2.DEFBLOCKSIZE - 6);
                                }
                                DefMsg = EncryptUnit.DecodeMessage(sDefMsg);
                                nIdent = DefMsg.Ident;
                                nRecog = DefMsg.Recog;
                                sStr = s38;
                                boLoadDBOK = true;
                                result = true;
                                break;
                            }
                        }
                        else
                        {
                            if ((nLen < Marshal.SizeOf(typeof(TDefaultMessage))))
                            {
                                nCode = 2;
                            }
                            if ((HUtil32.Str_ToInt(s2C, 0) != nQueryID))
                            {
                                nCode = 4;
                            }
                            M2Share.g_Config.nLoadDBErrorCount++;
                            break;
                        }
                    }
                    else
                    {
                        nCode = 3;
                        M2Share.g_Config.nLoadDBErrorCount++;
                        break;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
            if (!boLoadDBOK)
            {
                M2Share.g_nSaveRcdErrorCount++;
                if (boLoadRcd)
                {
                    M2Share.MainOutMessage(sLoadDBTimeOut + sName + " Code:" + nCode);
                }
                else
                {
                    M2Share.MainOutMessage(sSaveDBTimeOut + sName + " Code:" + nCode);
                }
            }
            else
            {
                M2Share.g_nSaveRcdErrorCount = 0;
            }
            M2Share.g_Config.boDBSocketWorking = false;
            return result;
        }

        // 加入函数名 以方便查错
        public static bool MakeHumRcdFromLocal(ref THumDataInfo HumanRcd)
        {
            bool result;
            HumanRcd = new THumDataInfo();
            HumanRcd.Data.Abil.Level = 30;
            result = true;
            return result;
        }

        /// <summary>
        /// 查询英雄数据(酒2，取回英雄窗口显示英雄信息)
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="sHumanRcdStr"></param>
        /// <param name="nCertCode"></param>
        /// <returns></returns>
        public static string QueryHeroRcd(string sAccount, string sCharName, string sStr, string sHumanRcdStr, int nCertCode)
        {
            string result;
            TDefaultMessage DefMsg;
            TLoadHuman LoadHuman;
            int nQueryID = 0;
            int nIdent = 0;
            int nRecog = 0;
            string sDBMsg = string.Empty;
            nQueryID = GetQueryID(M2Share.g_Config);
            //DefMsg = EDcode.Units.EDcode.MakeDefaultMsg(Common.DB_QUERYHERORCD, 0, 0, 0, 0, 0);
            LoadHuman = new TLoadHuman();
            //LoadHuman.sAccount = sAccount;
            //LoadHuman.sChrName = sCharName;
            //LoadHuman.sUserAddr = sStr;
            LoadHuman.nSessionID = nCertCode;
            //sDBMsg = EDcode.Units.EDcode.EncodeMessage(DefMsg) + EDcode.Units.EDcode.EncryptUnit.EncodeBuffer(LoadHuman, sizeof(TLoadHuman));
            SendDBSockMsg(nQueryID, sDBMsg);
            if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sHumanRcdStr, M2Share.g_Config.dwGetDBSockMsgTime, true, "QueryHeroRcd(" + sAccount + "/" + sCharName + ")"))
            {
                result = "";
                if (nIdent == Common.DB_QUERYHERORCD)
                {
                    result = sHumanRcdStr;
                }
                else
                {
                    result = "";
                }
            }
            else
            {
                result = "";
            }
            return result;
        }

        /// <summary>
        /// 查询DB库中英雄相关数据(酒馆)
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="sHumanRcdStr"></param>
        /// <param name="nCertCode"></param>
        /// <returns></returns>
        public static string QueryHeroRcdFromDB(string sAccount, string sCharName, string sStr, string sHumanRcdStr, int nCertCode)
        {
            string result;
            // IP
            result = "";
            sHumanRcdStr = QueryHeroRcd(sAccount, sCharName, sStr, sHumanRcdStr, nCertCode);
            if (sHumanRcdStr != "")
            {
                result = sHumanRcdStr;
            }
            M2Share.g_Config.nLoadDBCount++;
            return result;
        }

        /// <summary>
        /// 从DB库中读出人物数据
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="HumanRcd"></param>
        /// <param name="nCertCode"></param>
        /// <returns></returns>
        public unsafe static bool LoadHumRcdFromDB(string sAccount, string sCharName, string sStr, THumDataInfo* HumanRcd, int nCertCode)
        {
            bool result = false;
            if (LoadRcd(sAccount, sCharName, sStr, nCertCode, HumanRcd))
            {
                string sName = HUtil32.SBytePtrToString(HumanRcd->Data.sChrName, HumanRcd->Data.ChrNameLen);
                string sDataAccount = HUtil32.SBytePtrToString(HumanRcd->Data.sAccount, 0, HumanRcd->Data.AccountLen);
                if (string.Compare(sName, sCharName, true) == 0 && sDataAccount == "" || sDataAccount == sAccount)
                {
                    result = true;
                }
            }
            M2Share.g_Config.nLoadDBCount++;
            return result;
        }

        /// <summary>
        /// 从DB库中读出英雄数据
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="HumanRcd"></param>
        /// <param name="nCertCode"></param>
        /// <returns></returns>
        public unsafe static bool LoadHeroRcdFromDB(string sAccount, string sCharName, string sStr, THumDataInfo* HumanRcd, int nCertCode)
        {
            bool result = false;
            if (LoadHeroRcd(sAccount, sCharName, sStr, nCertCode, HumanRcd))
            {
                string sName = HUtil32.SBytePtrToString(HumanRcd->Data.sChrName, 0, HumanRcd->Data.ChrNameLen);
                string sDataAccount = HUtil32.SBytePtrToString(HumanRcd->Data.sAccount, 0, HumanRcd->Data.AccountLen);
                if (string.Compare(sName, sCharName, true) == 0 && sDataAccount == "" || sDataAccount == sAccount)
                {
                    result = true;
                }
            }
            M2Share.g_Config.nLoadDBCount++;
            return result;
        }

        /// <summary>
        /// 保存人物数据
        /// </summary>
        /// <param name="sAccount">账号</param>
        /// <param name="sCharName">人物名称</param>
        /// <param name="nSessionID">会话ID</param>
        /// <param name="boIsHero">是否英雄</param>
        /// <param name="BoisDoubleHero"></param>
        /// <param name="btJob"></param>
        /// <param name="HumanRcd"></param>
        /// <returns></returns>
        public static bool SaveHumRcdToDB(TSaveRcd SaveHumRcd)
        {
            bool result;
            if (SaveHumRcd.boIsHero)
            {
                if (SaveHumRcd.boisDoubleHero)
                {
                    result = SaveDoubleHeroRcd(SaveHumRcd.sAccount, SaveHumRcd.sChrName, SaveHumRcd.nSessionID, SaveHumRcd.btJob, SaveHumRcd.HumanRcd);
                }
                else
                {
                    result = SaveHeroRcd(SaveHumRcd.sAccount, SaveHumRcd.sChrName, SaveHumRcd.nSessionID, SaveHumRcd.HumanRcd);  // 保存英雄数据
                }
            }
            else
            {
                result = SaveRcd(SaveHumRcd.sAccount, SaveHumRcd.sChrName, SaveHumRcd.nSessionID, SaveHumRcd.HumanRcd);// 保存人物数据
                M2Share.g_Config.nSaveDBCount++;
            }
            return result;
        }

        public unsafe static bool LoadDoubleHeroRcdFromDB(string sAccount, string sCharName, string sStr, byte btJob, THumDataInfo* HumanRcd, int nCertCode)
        {
            bool result;
            result = false;

            //FillChar(HumanRcd, sizeof(THumDataInfo), '\0');
            //if (LoadDoubleHeroRcd(sAccount, sCharName, sStr, nCertCode, btJob, ref HumanRcd))
            //{
            //    if ((HumanRcd.Data.sChrName == sCharName) && ((HumanRcd.Data.sAccount == "") || (HumanRcd.Data.sAccount == sAccount)))
            //    {
            //        result = true;
            //    }
            //}
            M2Share.g_Config.nLoadDBCount++;
            return result;
        }

        /// <summary>
        /// 保存人物数据
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="nSessionID"></param>
        /// <param name="HumanRcd"></param>
        /// <returns></returns>
        public unsafe static bool SaveRcd(string sAccount, string sCharName, int nSessionID, THumDataInfo HumanRcd)
        {
            bool result = false;
            int nQueryID = GetQueryID(M2Share.g_Config);
            int nIdent = 0;
            int nRecog = 0;
            string sStr = string.Empty;
            SendDBSockMsg(nQueryID, EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Common.DB_SAVEHUMANRCD, nSessionID, 0, 0, 0, 0)) + EncryptUnit.EncodeString(sAccount) + "/"
                + EncryptUnit.EncodeString(sCharName) + "/" + EncryptUnit.EncodeBuffer(&HumanRcd, sizeof(THumDataInfo)));
            if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sStr, M2Share.g_Config.dwGetDBSockMsgTime, false, "SaveRcd(" + sAccount + "/" + sCharName + ")"))
            {
                if ((nIdent == Common.DBR_SAVEHUMANRCD) && (nRecog == 1))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 保存英雄数据
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="nSessionID"></param>
        /// <param name="HumanRcd"></param>
        /// <returns></returns>
        public unsafe static bool SaveHeroRcd(string sAccount, string sCharName, int nSessionID, THumDataInfo HumanRcd)
        {
            bool result = false;
            int nQueryID = 0;
            int nIdent = 0;
            int nRecog = 0;
            string sStr = string.Empty;
            nQueryID = GetQueryID(M2Share.g_Config);
            result = false;
            SendDBSockMsg(nQueryID, EncryptUnit.EncodeMessage(EncryptUnit.MakeDefaultMsg(Common.DB_SAVEHERORCD, nSessionID, 0, 0, 0, 0)) + EncryptUnit.EncodeString(sAccount) + "/"
                + EncryptUnit.EncodeString(sCharName) + "/" + EncryptUnit.EncodeBuffer(&HumanRcd, sizeof(THumDataInfo)));
            if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sStr, M2Share.g_Config.dwGetDBSockMsgTime, false, "SaveHeroRcd(" + sAccount + "/" + sCharName + ")"))
            {
                if ((nIdent == Common.DB_SAVEHERORCD) && (nRecog == 1))
                {
                    result = true;
                }
            }
            return result;
        }

        public  static bool SaveDoubleHeroRcd(string sAccount, string sCharName, int nSessionID, byte btJob, THumDataInfo HumanRcd)
        {
            bool result;
            int nQueryID = 0;
            int nIdent = 0;
            int nRecog = 0;
            string sStr = string.Empty;
            nQueryID = GetQueryID(M2Share.g_Config);
            result = false;
            //SendDBSockMsg(nQueryID, EDcode.Units.EDcode.EncodeMessage(EDcode.Units.EDcode.MakeDefaultMsg(Common.DB_SAVEDOUBLEHERORCD, nSessionID, 0, 0, 0, 0)) + EDcode.Units.EDcode.EncodeString(sAccount) + "/" + EDcode.Units.EDcode.EncodeString(sCharName) + "/" + EDcode.Units.EDcode.EncodeString((btJob).ToString()) + "/" + EDcode.Units.EDcode.EncryptUnit.EncodeBuffer(HumanRcd, sizeof(THumDataInfo)));
            //if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sStr, M2Share.g_Config.dwGetDBSockMsgTime, false, "SaveHeroRcd(" + sAccount + "/" + sCharName + ")"))
            //{
            //    if ((nIdent == Common.DB_SAVEDOUBLEHERORCD) && (nRecog == 1))
            //    {
            //        result = true;
            //    }
            //}
            return result;
        }

        /// <summary>
        /// 加载人物数据
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="nCertCode"></param>
        /// <param name="HumanRcd"></param>
        /// <returns></returns>
        public unsafe static bool LoadRcd(string sAccount, string sCharName, string sStr, int nCertCode, THumDataInfo* HumanRcd)
        {
            bool result;
            TDefaultMessage DefMsg;
            int nQueryID = 0;
            int nIdent = 0;
            int nRecog = 0;
            string sHumanRcdStr = string.Empty;
            string sDBMsg = string.Empty;
            string sDBCharName = string.Empty;
            nQueryID = GetQueryID(M2Share.g_Config);
            DefMsg = EncryptUnit.MakeDefaultMsg(Common.DB_LOADHUMANRCD, 0, 0, 0, 0, 0);
            TLoadHuman LoadHuman = new TLoadHuman();
            LoadHuman.sAccount = sAccount;
            LoadHuman.sChrName = sCharName;
            LoadHuman.sUserAddr = sStr;
            LoadHuman.nSessionID = nCertCode;
            byte[] data = HUtil32.StructToBytes(LoadHuman);
            //"sAccount/sCharName/sStr/nCertCode"; 可以消除LoadHuman
            //sDBMsg = EncryptUnit.EncodeMessage(DefMsg) + sAccount
            sDBMsg = EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeBuffer(data, Marshal.SizeOf(LoadHuman));
            SendDBSockMsg(nQueryID, sDBMsg);//发送消息给DBSERVER,请求加载人物数据
            if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sHumanRcdStr, M2Share.g_Config.dwGetDBSockMsgTime, true, "LoadRcd(" + sAccount + "/" + sCharName + ")"))
            {
                result = false;
                if (nIdent == Common.DBR_LOADHUMANRCD)
                {
                    if (nRecog == 1)
                    {
                        sHumanRcdStr = HUtil32.GetValidStr3(sHumanRcdStr, ref sDBMsg, new string[] { "/" });
                        sDBCharName = EncryptUnit.DeCodeString(sDBMsg, true);
                        sDBCharName = sDBCharName.Replace("\0", "");
                        if (sDBCharName == sCharName)
                        {
                            int DataSize = sizeof(THumDataInfo);
                            if (HUtil32.GetCodeMsgSize(DataSize * 4 / 3) == sHumanRcdStr.Length)
                            {
                                EncryptUnit.DecodeBuffer(sHumanRcdStr, HumanRcd, sizeof(THumDataInfo));
                                result = true;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 加载英雄数据
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="nCertCode"></param>
        /// <param name="HumanRcd"></param>
        /// <returns></returns>
        public unsafe static bool LoadHeroRcd(string sAccount, string sCharName, string sStr, int nCertCode, THumDataInfo* HumanRcd)
        {
            bool result;
            TDefaultMessage DefMsg;
            int nQueryID = 0;
            int nIdent = 0;
            int nRecog = 0;
            string sHumanRcdStr = string.Empty;
            string sDBMsg = string.Empty;
            string sDBCharName;
            nQueryID = GetQueryID(M2Share.g_Config);
            DefMsg = EncryptUnit.MakeDefaultMsg(Common.DB_LOADHERORCD, 0, 0, 0, 0, 0);
            TLoadHuman LoadHuman = new TLoadHuman();
            LoadHuman.sAccount = sAccount;
            LoadHuman.sChrName = sCharName;
            LoadHuman.sUserAddr = sStr;
            LoadHuman.nSessionID = nCertCode;
            byte[] data = HUtil32.StructToBytes(LoadHuman);
            sDBMsg = EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeBuffer(data, Marshal.SizeOf(LoadHuman));
            SendDBSockMsg(nQueryID, sDBMsg);
            if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sHumanRcdStr, M2Share.g_Config.dwGetDBSockMsgTime, true, "LoadHeroRcd(" + sAccount + "/" + sCharName + ")"))
            {
                result = false;
                if (nIdent == Common.DB_LOADHERORCD)
                {
                    if (nRecog == 1)
                    {
                        sHumanRcdStr = HUtil32.GetValidStr3(sHumanRcdStr, ref sDBMsg, new string[] { "/" });
                        sDBCharName = EncryptUnit.DeCodeString(sDBMsg);
                        if (sDBCharName == sCharName)
                        {
                            if (HUtil32.GetCodeMsgSize(sizeof(THumDataInfo) * 4 / 3) == sHumanRcdStr.Length)
                            {
                                EncryptUnit.DecodeBuffer(sHumanRcdStr, HumanRcd, sizeof(THumDataInfo));
                                result = true;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static bool LoadDoubleHeroRcd(string sAccount, string sCharName, string sStr, int nCertCode, byte btJob, ref THumDataInfo HumanRcd)
        {
            bool result = false;
            TDefaultMessage DefMsg;
            TLoadDoubleHero LoadDoubleHero = null;
            int nQueryID;
            int nIdent;
            int nRecog;
            string sHumanRcdStr;
            string sDBMsg;
            string sDBCharName;
            nQueryID = GetQueryID(M2Share.g_Config);
            //DefMsg = EDcode.Units.EDcode.MakeDefaultMsg(Common.DB_LOADDOUBLEHERORCD, 0, 0, 0, 0, 0);
            LoadDoubleHero.sAccount = sAccount;
            LoadDoubleHero.sChrName = sCharName;
            LoadDoubleHero.sUserAddr = sStr;
            LoadDoubleHero.btJob = btJob;
            LoadDoubleHero.nSessionID = nCertCode;
            //sDBMsg = EDcode.Units.EDcode.EncodeMessage(DefMsg) + EDcode.Units.EDcode.EncryptUnit.EncodeBuffer(LoadDoubleHero, sizeof(TLoadDoubleHero));
            // SendDBSockMsg(nQueryID, sDBMsg);
            //if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sHumanRcdStr, M2Share.g_Config.dwGetDBSockMsgTime, true, "LoadHeroRcd(" + sAccount + "/" + sCharName + ")"))
            //{
            //    result = false;
            //    if (nIdent == Common.DB_LOADDOUBLEHERORCD)
            //    {
            //        if (nRecog == 1)
            //        {
            //            sHumanRcdStr = HUtil32.GetValidStr3(sHumanRcdStr, ref sDBMsg, new string[] { "/" });
            //            sDBCharName = EDcode.Units.EDcode.DeCodeString(sDBMsg);
            //            if (sDBCharName == sCharName)
            //            {
            //                if (HUtil32.GetCodeMsgSize(sizeof(THumDataInfo) * 4 / 3) == sHumanRcdStr.Length)
            //                {
            //                    EDcode.Units.EDcode.DecodeBuffer(sHumanRcdStr, HumanRcd, sizeof(THumDataInfo));
            //                    result = true;
            //                }
            //            }
            //            else
            //            {
            //                result = false;
            //            }
            //        }
            //        else
            //        {
            //            result = false;
            //        }
            //    }
            //    else
            //    {
            //        result = false;
            //    }
            //}
            //else
            //{
            //    result = false;
            //}
            return result;
        }

        /// <summary>
        /// 新建英雄数据
        /// </summary>
        /// <param name="sChrName"></param>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public static int NewHeroRcd(string sChrName, string sMsg)
        {
            int result = 0;
            TDefaultMessage DefMsg;
            int nQueryID;
            int nIdent = 0;
            int nRecog = 0;
            string sHumanRcdStr = string.Empty;
            string sDBMsg;
            string sDBCharName;
            nQueryID = GetQueryID(M2Share.g_Config);
            DefMsg = EncryptUnit.MakeDefaultMsg(Common.DB_NEWHERORCD, 0, 0, 0, 0, 0);
            sDBMsg = EncryptUnit.EncodeMessage(DefMsg) + EncryptUnit.EncodeString(sMsg);
            SendDBSockMsg(nQueryID, sDBMsg);
            if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sHumanRcdStr, M2Share.g_Config.dwGetDBSockMsgTime, true, "NewHeroRcd(" + sChrName + ")"))
            {
                result = -1;
                if (nIdent == Common.DB_NEWHERORCD)
                {
                    sDBCharName = EncryptUnit.DeCodeString(sHumanRcdStr);
                    if (sDBCharName == sChrName)
                    {
                        result = nRecog;
                    }
                    else
                    {
                        result = -1;
                    }
                }
                else
                {
                    result = -1;
                }
            }
            else
            {
                result = -1;
            }
            return result;
        }

        public static int AssessDoubleHeroRcd(string sChrName, string sMsg, byte btJob)
        {
            int result = 0;
            TDefaultMessage DefMsg;
            int nQueryID;
            int nIdent;
            int nRecog;
            string sHumanRcdStr;
            string sDBMsg;
            string sDBCharName;
            nQueryID = GetQueryID(M2Share.g_Config);
            //DefMsg = EDcode.Units.EDcode.MakeDefaultMsg(Common.DB_ASSESSDOUBLEHERORCD, 0, 0, 0, 0, 0);
            //sDBMsg = EDcode.Units.EDcode.EncodeMessage(DefMsg) + EDcode.Units.EDcode.EncodeString(sMsg);
            //SendDBSockMsg(nQueryID, sDBMsg);
            //if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sHumanRcdStr, M2Share.g_Config.dwGetDBSockMsgTime, true, "NewHeroRcd(" + sChrName + ")"))
            //{
            //    result =  -1;
            //    if (nIdent == Common.DB_ASSESSDOUBLEHERORCD)
            //    {
            //        sDBCharName = EDcode.Units.EDcode.DeCodeString(sHumanRcdStr);
            //        if (sDBCharName == sChrName)
            //        {
            //            result = nRecog;
            //        }
            //        else
            //        {
            //            result =  -1;
            //        }
            //    }
            //    else
            //    {
            //        result =  -1;
            //    }
            //}
            //else
            //{
            //    result =  -1;
            //}
            return result;
        }

        /// <summary>
        /// 删除英雄
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sCharName"></param>
        /// <param name="sStr"></param>
        /// <param name="nCertCode"></param>
        /// <returns></returns>
        public static bool DelHeroRcd(string sAccount, string sCharName, string sStr, int nCertCode)
        {
            bool result = false;
            TDefaultMessage DefMsg;
            TLoadHuman LoadHuman;
            int nQueryID;
            int nIdent;
            int nRecog;
            string sHumanRcdStr;
            string sDBMsg;
            string sDBCharName;
            nQueryID = GetQueryID(M2Share.g_Config);
            //DefMsg = EDcode.Units.EDcode.MakeDefaultMsg(Common.DB_DELHERORCD, 0, 0, 0, 0, 0);
            //LoadHuman.sAccount = sAccount;
            //LoadHuman.sChrName = sCharName;
            //LoadHuman.sUserAddr = sStr;
            //LoadHuman.nSessionID = nCertCode;
            //sDBMsg = EDcode.Units.EDcode.EncodeMessage(DefMsg) + EDcode.Units.EDcode.EncryptUnit.EncodeBuffer(LoadHuman, sizeof(TLoadHuman));
            // n4EBB68 := 100;//20080728 注释
            //SendDBSockMsg(nQueryID, sDBMsg);
            //if (GetDBSockMsg(nQueryID, ref nIdent, ref nRecog, ref sHumanRcdStr, M2Share.g_Config.dwGetDBSockMsgTime, true, "DelHeroRcd(" + sAccount + "/" + sCharName + ")"))
            //{
            //    result = false;
            //    if (nIdent == Common.DB_DELHERORCD)
            //    {
            //        if (nRecog == 1)
            //        {
            //            //sDBCharName = EDcode.Units.EDcode.DeCodeString(sHumanRcdStr);
            //            if (sDBCharName == sCharName)
            //            {
            //                result = true;
            //            }
            //            else
            //            {
            //                result = false;
            //            }
            //        }
            //        else
            //        {
            //            result = false;
            //        }
            //    }
            //    else
            //    {
            //        result = false;
            //    }
            //}
            //else
            //{
            //    result = false;
            //}
            return result;
        }

        /// <summary>
        /// 发信息给DBServer
        /// </summary>
        /// <param name="nQueryID"></param>
        /// <param name="sMsg"></param>
        public unsafe static void SendDBSockMsg(int nQueryID, string sMsg)
        {
            string sSENDMSG;
            int nCheckCode;
            string sCheckStr = string.Empty;
            if (!DBSocketConnected())
            {
                return;
            }
            HUtil32.EnterCriticalSection(M2Share.UserDBSection);
            try
            {
                M2Share.g_Config.sDBSocketRecvText = "";
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.UserDBSection);
            }
            nCheckCode = HUtil32.MakeLong(nQueryID ^ 170, sMsg.Length + 6);
            byte[] by = new byte[sizeof(int)];
            fixed (byte* pb = by)
            {
                *(int*)pb = nCheckCode;
            }
            sCheckStr = EncryptUnit.EncodeBuffer(by, by.Length);
            sSENDMSG = "#" + nQueryID + "/" + sMsg + sCheckStr + "!";
            M2Share.g_Config.boDBSocketWorking = true;
            byte[] data = System.Text.Encoding.Default.GetBytes(sSENDMSG);
            TFrmMain.DBSocket.Send(HUtil32.StrToByte(sSENDMSG));
        }

        public static int GetQueryID(TGameConfig Config)
        {
            int result;
            Config.nDBQueryID++;
            if (Config.nDBQueryID > Int16.MaxValue - 1)
            {
                Config.nDBQueryID = 1;
            }
            result = Config.nDBQueryID;
            return result;
        }
    }
}
