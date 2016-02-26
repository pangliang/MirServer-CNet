using GameFramework;
using M2Server.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace M2Server
{
    public class TFrontEngine : GameBase
    {
        public object m_UserCriticalSection = null;
        public IList<TLoadDBInfo> m_LoadRcdList = null;
        public IList<TSaveRcd> m_SaveRcdList = null;
        public IList<TGoldChangeInfo> m_ChangeGoldList = null;
        private IList<TLoadDBInfo> m_LoadRcdTempList = null;
        private IList<TSaveRcd> m_SaveRcdTempList = null;
        private Task FrontEngine;

        public TFrontEngine(bool CreateSuspended)
        {
            m_UserCriticalSection = new object();
            m_LoadRcdList = new List<TLoadDBInfo>();
            m_SaveRcdList = new List<TSaveRcd>();
            m_ChangeGoldList = new List<TGoldChangeInfo>();
            m_LoadRcdTempList = new List<TLoadDBInfo>();
            m_SaveRcdTempList = new List<TSaveRcd>();
            FrontEngine = new Task(Execute);
            FrontEngine.Start();
        }

        ~TFrontEngine()
        {
            Dispose(m_LoadRcdList);
            Dispose(m_SaveRcdList);
            Dispose(m_ChangeGoldList);
            Dispose(m_LoadRcdTempList);
            Dispose(m_SaveRcdTempList);
            Dispose(m_LoadRcdList);
            Dispose(m_UserCriticalSection);
        }

        public void Execute()
        {
            while (!FrontEngine.IsCanceled)
            {
                try
                {
                    Run();
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TFrontEngine::Execute");
                }
                Thread.Sleep(1);
            }
        }

        private void GetGameTime()
        {
            int Hour;
            int Min;
            int Sec;
            int MSec;
            Hour = DateTime.Now.Hour;
            Min = DateTime.Now.Minute;
            Sec = DateTime.Now.Second;
            MSec = DateTime.Now.Millisecond;
            switch (Hour)
            {
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    M2Share.g_nGameTime = 1;
                    break;

                case 11:
                case 23:
                    M2Share.g_nGameTime = 2;
                    break;

                case 4:
                case 15:
                    M2Share.g_nGameTime = 0;
                    break;

                case 0:
                case 1:
                case 2:
                case 3:
                case 12:
                case 13:
                case 14:
                    M2Share.g_nGameTime = 3;
                    break;
            }
        }

        /// <summary>
        /// 是否空闲
        /// </summary>
        /// <returns></returns>
        public bool IsIdle()
        {
            bool result = false;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                if (m_SaveRcdList.Count == 0)
                {
                    result = true;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
            return result;
        }

        public int SaveListCount()
        {
            int result = 0;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                result = m_SaveRcdList.Count;
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 处理游戏数据
        /// </summary>
        private void ProcessGameDate()
        {
            IList<TLoadDBInfo> TempList;
            IList<TGoldChangeInfo> ChangeGoldList;
            TLoadDBInfo LoadDBInfo;
            TSaveRcd SaveRcd;
            TGoldChangeInfo GoldChangeInfo;
            bool boReTryLoadDB = true;
            bool boSaveRcd;
            byte nCode = 0;
            const string sExceptionMsg = "{异常} TFrontEngine::ProcessGameDate Code:{0}";
            const string sSaveExceptionMsg = "数据库服务器出现异常，请重新启动数据库服务器(DBServer.exe)！！！";
            try
            {
                ChangeGoldList = null;
                nCode = 17;
                if (M2Share.g_nSaveRcdErrorCount >= 10)
                {
                    nCode = 18;
                    if (HUtil32.GetTickCount() - M2Share.g_dwShowSaveRcdErrorTick > 5000)//修改秒触发
                    {
                        nCode = 19;
                        M2Share.g_dwShowSaveRcdErrorTick = HUtil32.GetTickCount();
                        M2Share.MainOutMessage(sSaveExceptionMsg);
                    }
                }
                HUtil32.EnterCriticalSection(m_UserCriticalSection);
                try
                {
                    nCode = 20;
                    if (m_SaveRcdList.Count > 0)
                    {
                        nCode = 21;
                        for (int I = 0; I < m_SaveRcdList.Count; I++)
                        {
                            m_SaveRcdTempList.Add(m_SaveRcdList[I]);
                        }
                    }
                    nCode = 1;
                    TempList = m_LoadRcdTempList;
                    nCode = 2;
                    m_LoadRcdTempList = m_LoadRcdList;
                    nCode = 3;
                    m_LoadRcdList = TempList;
                    nCode = 4;
                    if (m_ChangeGoldList.Count > 0)
                    {
                        nCode = 22;
                        ChangeGoldList = new List<TGoldChangeInfo>();
                        nCode = 23;
                        for (int I = 0; I < m_ChangeGoldList.Count; I++)
                        {
                            if (m_ChangeGoldList[I] != null)
                            {
                                ChangeGoldList.Add(m_ChangeGoldList[I]);
                            }
                        }
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(m_UserCriticalSection);
                }
                if (m_SaveRcdTempList.Count > 0)
                {
                    for (int I = 0; I < m_SaveRcdTempList.Count; I++)
                    {
                        SaveRcd = m_SaveRcdTempList[I];
                        if ((!RunDB.DBSocketConnected()) || (M2Share.g_nSaveRcdErrorCount >= 10))// DBSERVER关闭 不保存
                        {
                            if ((SaveRcd.PlayObject != 0) && (!SaveRcd.boIsHero))
                            {
                                GetObject<TPlayObject>(SaveRcd.PlayObject).m_boRcdSaved = true;
                            }
                            HUtil32.EnterCriticalSection(m_UserCriticalSection);
                            try
                            {
                                for (int II = m_SaveRcdList.Count - 1; II >= 0; II--)
                                {
                                    if (m_SaveRcdList.Count <= 0)
                                    {
                                        break;
                                    }
                                    if (m_SaveRcdList[II] == SaveRcd)
                                    {
                                        m_SaveRcdList.RemoveAt(II);
                                        nCode = 5;
                                        SaveRcd = null;
                                        nCode = 6;
                                        break;
                                    }
                                }
                            }
                            finally
                            {
                                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
                            }
                        }
                        else
                        {
                            boSaveRcd = false;
                            if (SaveRcd.nReTryCount == 0)
                            {
                                boSaveRcd = true;
                            }
                            else if ((SaveRcd.nReTryCount < 50) && (HUtil32.GetTickCount() - SaveRcd.dwSaveTick > 5000))// 保存错误等待5秒后在保存
                            {
                                boSaveRcd = true;
                            }
                            else if (SaveRcd.nReTryCount >= 50) // 失败50次后不在保存
                            {
                                if ((SaveRcd.PlayObject != 0) && (!SaveRcd.boIsHero))
                                {
                                    GetObject<TPlayObject>(SaveRcd.PlayObject).m_boRcdSaved = true;
                                }
                                HUtil32.EnterCriticalSection(m_UserCriticalSection);
                                try
                                {
                                    for (int II = m_SaveRcdList.Count - 1; II >= 0; II--)
                                    {
                                        if (m_SaveRcdList.Count <= 0)
                                        {
                                            break;
                                        }
                                        if (m_SaveRcdList[II] == SaveRcd)
                                        {
                                            m_SaveRcdList.RemoveAt(II);
                                            nCode = 7;
                                            SaveRcd = null;
                                            nCode = 8;
                                            break;
                                        }
                                    }
                                }
                                finally
                                {
                                    HUtil32.LeaveCriticalSection(m_UserCriticalSection);
                                }
                            }
                            if (boSaveRcd)// 保存人物 英雄 双英雄数据
                            {
                                if (RunDB.SaveHumRcdToDB(SaveRcd))
                                {
                                    if ((SaveRcd.PlayObject != 0) && (!SaveRcd.boIsHero))
                                    {
                                        GetObject<TPlayObject>(SaveRcd.PlayObject).m_boRcdSaved = true;
                                    }
                                    HUtil32.EnterCriticalSection(m_UserCriticalSection);
                                    try
                                    {
                                        for (int II = m_SaveRcdList.Count - 1; II >= 0; II--)
                                        {
                                            if (m_SaveRcdList.Count <= 0)
                                            {
                                                break;
                                            }
                                            if (m_SaveRcdList[II] == SaveRcd)
                                            {
                                                m_SaveRcdList.RemoveAt(II);
                                                nCode = 9;
                                                SaveRcd = null;
                                                nCode = 10;
                                                break;
                                            }
                                        }
                                    }
                                    finally
                                    {
                                        HUtil32.LeaveCriticalSection(m_UserCriticalSection);
                                    }
                                }
                                else
                                {
                                    SaveRcd.nReTryCount++;// 保存失败
                                    SaveRcd.dwSaveTick = HUtil32.GetTickCount();
                                }
                            }
                        }
                    }
                    m_SaveRcdTempList.Clear();
                    nCode = 11;
                }
                if (m_LoadRcdTempList.Count > 0)
                {
                    nCode = 17;
                    for (int I = 0; I < m_LoadRcdTempList.Count; I++)
                    {
                        nCode = 18;
                        LoadDBInfo = m_LoadRcdTempList[I];
                        nCode = 19;
                        if ((!LoadHumFromDB(LoadDBInfo, ref boReTryLoadDB)) && (!LoadDBInfo.boIsHero))// 加载人物 英雄 双英雄数据
                        {
                            M2Share.RunSocket.CloseUser(LoadDBInfo.nGateIdx, LoadDBInfo.nSocket);
                        }
                        if (!boReTryLoadDB)
                        {
                            Dispose(LoadDBInfo);
                            LoadDBInfo = null;
                        }
                        else
                        {
                            // 如果读取人物数据失败(数据还没有保存),则重新加入队列
                            HUtil32.EnterCriticalSection(m_UserCriticalSection);
                            try
                            {
                                m_LoadRcdList.Add(LoadDBInfo);
                            }
                            finally
                            {
                                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
                            }
                        }
                    }
                }
                m_LoadRcdTempList.Clear();
                nCode = 12;
                if (ChangeGoldList != null)
                {
                    nCode = 121;
                    try
                    {
                        if (ChangeGoldList.Count > 0)
                        {
                            nCode = 122;
                            for (int I = 0; I < ChangeGoldList.Count; I++)
                            {
                                nCode = 123;
                                GoldChangeInfo = ChangeGoldList[I];
                                nCode = 125;
                                if (GoldChangeInfo != null)
                                {
                                    nCode = 126;
                                    ChangeUserGoldInDB(GoldChangeInfo);
                                    nCode = 13;
                                    Dispose(GoldChangeInfo);
                                    nCode = 14;
                                }
                            }
                        }
                    }
                    finally
                    {
                        nCode = 15;
                        Dispose(ChangeGoldList);
                        ChangeGoldList = null;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCode));
            }
        }

        /// <summary>
        /// 服务器是否满员
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            bool result = false;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                if (m_SaveRcdList.Count >= 2000)
                {
                    result = true;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// btLoadType 0-召唤 1-新建 2-删除 3-查询数据 4-召唤副将英雄 5-新建副将英雄 6-删除副将英雄
        /// </summary>
        /// <param name="sCharName"></param>
        /// <param name="sMsg"></param>
        /// <param name="PlayObject"></param>
        /// <param name="btLoadType"></param>
        public void AddToLoadHeroRcdList(string sCharName, string sMsg, TPlayObject PlayObject, byte btLoadType)
        {
            TLoadDBInfo LoadRcdInfo = new TLoadDBInfo();
            PlayObject.m_boWaitHeroDate = true;
            LoadRcdInfo.sAccount = PlayObject.m_sUserID;
            LoadRcdInfo.sCharName = sCharName;
            LoadRcdInfo.sIPaddr = PlayObject.m_sIPaddr;
            LoadRcdInfo.boClinetFlag = PlayObject.m_boClientFlag;
            LoadRcdInfo.nSessionID = PlayObject.m_nSessionID;
            LoadRcdInfo.nSoftVersionDate = PlayObject.m_nSoftVersionDate;
            LoadRcdInfo.nPayMent = PlayObject.m_nPayMent;
            LoadRcdInfo.nPayMode = PlayObject.m_nPayMode;
            LoadRcdInfo.nSocket = PlayObject.m_nSocket;
            LoadRcdInfo.nGSocketIdx = PlayObject.m_nGSocketIdx;
            LoadRcdInfo.nGateIdx = PlayObject.m_nGateIdx;
            LoadRcdInfo.dwNewUserTick = HUtil32.GetTickCount();
            LoadRcdInfo.PlayObject = PlayObject;
            LoadRcdInfo.nReLoadCount = 0;
            LoadRcdInfo.boIsHero = true;
            LoadRcdInfo.btLoadDBType = btLoadType;
            LoadRcdInfo.sMsg = sMsg;
            LoadRcdInfo.btJob = PlayObject.m_btDeputyHeroJob;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                m_LoadRcdList.Add(LoadRcdInfo);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
        }

        /// <summary>
        /// 添加到加载角色队列里面
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sChrName"></param>
        /// <param name="sIPaddr"></param>
        /// <param name="boFlag"></param>
        /// <param name="nSessionID"></param>
        /// <param name="nPayMent"></param>
        /// <param name="nPayMode"></param>
        /// <param name="nSoftVersionDate"></param>
        /// <param name="nSocket"></param>
        /// <param name="nGSocketIdx"></param>
        /// <param name="nGateIdx"></param>
        public void AddToLoadRcdList(string sAccount, string sChrName, string sIPaddr, bool boFlag, int nSessionID, int nPayMent, int nPayMode, int nSoftVersionDate, int nSocket, int nGSocketIdx, int nGateIdx)
        {
            TLoadDBInfo LoadRcdInfo = new TLoadDBInfo();
            LoadRcdInfo.sAccount = sAccount;
            LoadRcdInfo.sCharName = sChrName;
            LoadRcdInfo.sIPaddr = sIPaddr;
            LoadRcdInfo.boClinetFlag = boFlag;
            LoadRcdInfo.nSessionID = nSessionID;
            LoadRcdInfo.nSoftVersionDate = nSoftVersionDate;
            LoadRcdInfo.nPayMent = nPayMent;
            LoadRcdInfo.nPayMode = nPayMode;
            LoadRcdInfo.nSocket = nSocket;
            LoadRcdInfo.nGSocketIdx = nGSocketIdx;
            LoadRcdInfo.nGateIdx = nGateIdx;
            LoadRcdInfo.dwNewUserTick = HUtil32.GetTickCount();
            LoadRcdInfo.PlayObject = null;
            LoadRcdInfo.nReLoadCount = 0;
            LoadRcdInfo.boIsHero = false;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                m_LoadRcdList.Add(LoadRcdInfo);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
        }

        /// <summary>
        /// 取玩家数据
        /// </summary>
        /// <param name="LoadUser"></param>
        /// <param name="boReTry"></param>
        /// <returns></returns>
        private unsafe bool LoadHumFromDB(TLoadDBInfo LoadUser, ref bool boReTry)
        {
            bool result = false;
            THumDataInfo HumanRcd;
            TUserOpenInfo UserOpenInfo;
            int nOpenStatus;
            boReTry = false;
            if ((!LoadUser.boIsHero) || ((LoadUser.boIsHero) && (LoadUser.btLoadDBType == 0)))
            {
                if (InSaveRcdList(LoadUser.sAccount, LoadUser.sCharName))
                {
                    boReTry = true;// 反回TRUE,则重新加入队列
                    return result;
                }
            }
            if (!LoadUser.boIsHero)
            {
                if ((UserEngine.GetPlayObjectEx(LoadUser.sAccount, LoadUser.sCharName) != null))
                {
                    UserEngine.KickPlayObjectEx(LoadUser.sAccount, LoadUser.sCharName);
                    boReTry = true;// 反回TRUE,则重新加入队列
                    return result;
                }
            }
            if (!LoadUser.boIsHero)
            {
                HumanRcd = new THumDataInfo();
                if (!RunDB.LoadHumRcdFromDB(LoadUser.sAccount, LoadUser.sCharName, LoadUser.sIPaddr, &HumanRcd, LoadUser.nSessionID))
                {
                    M2Share.RunSocket.SendOutConnectMsg(LoadUser.nGateIdx, LoadUser.nSocket, LoadUser.nGSocketIdx); // 强迫用户下线
                }
                else
                {
                    UserOpenInfo = new TUserOpenInfo();
                    UserOpenInfo.sAccount = LoadUser.sAccount;
                    UserOpenInfo.sChrName = LoadUser.sCharName;
                    UserOpenInfo.LoadUser = LoadUser;
                    UserOpenInfo.HumanRcd = HumanRcd;
                    UserEngine.AddUserOpenInfo(UserOpenInfo);
                    result = true;
                }
            }
            else
            {
                nOpenStatus = -1;
                HumanRcd = new THumDataInfo();
                switch (LoadUser.btLoadDBType)
                {
                    case 0:
                        if (RunDB.LoadHeroRcdFromDB(LoadUser.sAccount, LoadUser.sCharName, LoadUser.sIPaddr, &HumanRcd, LoadUser.nSessionID))
                        {
                            nOpenStatus = 1;
                        }
                        break;

                    case 1:
                        nOpenStatus = RunDB.NewHeroRcd(LoadUser.sCharName, LoadUser.sMsg);
                        break;

                    case 2:
                        if (RunDB.DelHeroRcd(LoadUser.sAccount, LoadUser.sCharName, LoadUser.sIPaddr, LoadUser.nSessionID))
                        {
                            nOpenStatus = 1;
                        }
                        break;

                    case 3:
                        LoadUser.sMsg = RunDB.QueryHeroRcdFromDB(LoadUser.sAccount, LoadUser.sCharName, LoadUser.sIPaddr, LoadUser.sMsg, LoadUser.nSessionID);
                        break;

                    case 4:
                        if (RunDB.LoadDoubleHeroRcdFromDB(LoadUser.sAccount, LoadUser.sCharName, LoadUser.sIPaddr, LoadUser.btJob, &HumanRcd, LoadUser.nSessionID))
                        {
                            nOpenStatus = 1;
                        }
                        break;

                    case 5:
                        nOpenStatus = RunDB.AssessDoubleHeroRcd(LoadUser.sCharName, LoadUser.sMsg, 0);
                        break;

                    case 6:
                        break;

                    case 7:
                        LoadUser.sMsg = RunDB.QueryHeroRcdFromDB(LoadUser.sAccount, LoadUser.sCharName, LoadUser.sIPaddr, LoadUser.sMsg, LoadUser.nSessionID);
                        break;

                    default:
                        nOpenStatus = 0;
                        break;
                }
                UserOpenInfo = new TUserOpenInfo();
                UserOpenInfo.sAccount = LoadUser.sAccount;
                UserOpenInfo.sChrName = LoadUser.sCharName;
                UserOpenInfo.LoadUser = LoadUser;
                UserOpenInfo.HumanRcd = HumanRcd;
                UserOpenInfo.nOpenStatus = nOpenStatus;
                UserEngine.AddUserOpenInfo(UserOpenInfo);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 检查是否存在列表里，如不存在，则增加，存在则退出
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sChrName"></param>
        /// <returns></returns>
        public bool InSaveRcdList(string sAccount, string sChrName)
        {
            bool result = false;
            TSaveRcd SaveRcd;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                if (m_SaveRcdList.Count > 0)
                {
                    for (int I = 0; I < m_SaveRcdList.Count; I++)
                    {
                        SaveRcd = m_SaveRcdList[I];
                        if (string.Compare(SaveRcd.sAccount, sAccount, true) == 0 && string.Compare(SaveRcd.sChrName, sChrName, true) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
            return result;
        }

        public void AddChangeGoldList(string sGameMasterName, string sGetGoldUserName, int nGold)
        {
            TGoldChangeInfo GoldInfo;
            GoldInfo = new TGoldChangeInfo();
            GoldInfo.sGameMasterName = sGameMasterName;
            GoldInfo.sGetGoldUser = sGetGoldUserName;
            GoldInfo.nGold = nGold;
            m_ChangeGoldList.Add(GoldInfo);
        }

        public TSaveRcd GetSaveRcd(string sAccount, string sCharName)
        {
            TSaveRcd result = null;
            TSaveRcd SaveRcd;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                if (m_SaveRcdList.Count > 0)
                {
                    for (int I = 0; I < m_SaveRcdList.Count; I++)
                    {
                        SaveRcd = m_SaveRcdList[I];
                        if (SaveRcd.sAccount == sAccount && SaveRcd.sChrName == sCharName)
                        {
                            result = SaveRcd;
                            break;
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 更新角色是否存在列表里
        /// </summary>
        /// <param name="SaveRcd"></param>
        /// <returns></returns>
        public bool UpDataSaveRcdList(TSaveRcd SaveRcd)
        {
            bool result = false;
            TSaveRcd HumanRcd;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                for (int I = m_SaveRcdList.Count - 1; I >= 0; I--)
                {
                    if (m_SaveRcdList.Count <= 0)
                    {
                        break;
                    }
                    HumanRcd = m_SaveRcdList[I];
                    if (HumanRcd != null)
                    {
                        if (HumanRcd.sAccount == SaveRcd.sAccount && HumanRcd.sChrName == SaveRcd.sChrName)
                        {
                            HumanRcd.HumanRcd = SaveRcd.HumanRcd;
                            result = true;
                            return result;
                        }
                    }
                }
                m_SaveRcdList.Add(SaveRcd);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
            return result;
        }

        public void DeleteHuman(int nGateIndex, int nSocket)
        {
            TLoadDBInfo LoadRcdInfo = null;
            HUtil32.EnterCriticalSection(m_UserCriticalSection);
            try
            {
                for (int I = m_LoadRcdList.Count - 1; I >= 0; I--)
                {
                    if (m_LoadRcdList.Count <= 0)
                    {
                        break;
                    }
                    LoadRcdInfo = m_LoadRcdList[I];
                    if ((LoadRcdInfo.nGateIdx == nGateIndex) && (LoadRcdInfo.nSocket == nSocket))
                    {
                        m_LoadRcdList.RemoveAt(I);
                        Dispose(LoadRcdInfo);
                        break;
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_UserCriticalSection);
            }
        }

        private unsafe bool ChangeUserGoldInDB(TGoldChangeInfo GoldChangeInfo)
        {
            bool result = false;
            THumDataInfo HumanRcd = new THumDataInfo();
            byte nCode = 0;
            try
            {
                if (GoldChangeInfo != null)
                {
                    nCode = 4;
                    if (RunDB.LoadHumRcdFromDB("1", GoldChangeInfo.sGetGoldUser, "1", &HumanRcd, 1))
                    {
                        nCode = 1;
                        if (((HumanRcd.Data.nGold + GoldChangeInfo.nGold) > 0) && ((HumanRcd.Data.nGold + GoldChangeInfo.nGold) < 2000000000))
                        {
                            HumanRcd.Data.nGold += GoldChangeInfo.nGold;
                            nCode = 2;
                            if (RunDB.SaveHumRcdToDB(new TSaveRcd()
                            {
                                sAccount = "1",
                                sChrName = GoldChangeInfo.sGetGoldUser,
                                nSessionID = 1,
                                boIsHero = false,
                                boisDoubleHero = false,
                                btJob = 0,
                                HumanRcd = HumanRcd
                            }))
                            {
                                nCode = 3;
                                UserEngine.sub_4AE514(GoldChangeInfo);
                                result = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFrontEngine.ChangeUserGoldInDB Code:" + nCode);
            }
            return result;
        }

        private void Run()
        {
            try
            {
                ProcessGameDate();
                GetGameTime();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFrontEngine.Run");
            }
        }

        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}