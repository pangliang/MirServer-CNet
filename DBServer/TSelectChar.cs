using DBServer.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DBServer
{
    /// <summary>
    /// 选择角色
    /// </summary>
    public class TSelectChar
    {
        private TUserInfo[] UserArray = new TUserInfo[5000];//用户数组
        private List<int> OnLineList = new List<int>();//在线列表
        private List<int> DeleteList = new List<int>();//删除列表

        /// <summary>
        /// 构造函数
        /// </summary>
        public TSelectChar()
        {
            for (int i = 0; i < UserArray.Length; i++)
            {
                UserArray[i] = new TUserInfo();
            }
            Initialize();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            TUserInfo UserInfo;
            OnLineList.Clear();
            DeleteList.Clear();
            for (int i = 0; i < Count; i++)
            {
                UserInfo = GetItem(i);
                UserInfo.nIndex = -1;
                UserInfo.sAccount = "";
                UserInfo.sUserIPaddr = "";
                UserInfo.sGateIPaddr = "";
                UserInfo.sConnID = "";
                UserInfo.nSessionID = 0;
                UserInfo.Socket = null;
                UserInfo.sReceiveText = "";
                UserInfo.dwTick34 = GameFramework.HUtil32.GetTickCount();
                UserInfo.dwChrTick = GameFramework.HUtil32.GetTickCount();
                UserInfo.boChrSelected = false;
                UserInfo.boChrQueryed = false;
                UserInfo.nSelGateID = 0;
                UserInfo.dwQueryDelChrTick = GameFramework.HUtil32.GetTickCount();
                UserInfo.dwRestoreChr = GameFramework.HUtil32.GetTickCount();
                UserInfo.dwRandomTick = 0;
                UserInfo.boRandomNumber = false;
                UserInfo.sRandomNumber = "";
            }
        }

        /// <summary>
        /// 获得项目
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        private TUserInfo GetItem(int Index)
        {
            TUserInfo result = null;
            if ((Index >= 0) && (Index < UserArray.Length))
            {
                result = UserArray[Index];
            }
            return result;
        }

        /// <summary>
        /// 获取在线的项目
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public TUserInfo GetOnLineItem(int Index)
        {
            TUserInfo result = null;
            if ((Index >= 0) && (Index < OnLineList.Count))
            {
                result = GetItem(((int)OnLineList[Index]));
            }
            return result;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            int result;
            int I;
            int nIndex;
            TUserInfo tUserInfo;
            result = -1;
            if (DeleteList.Count > 0)
            {
                nIndex = DeleteList[0];
                OnLineList.Add(nIndex);
                result = nIndex;
                DeleteList.RemoveAt(0);
            }
            else
            {
                for (I = 0; I < Count; I++)
                {
                    tUserInfo = GetItem(I);
                    if (tUserInfo.Socket == null)
                    {
                        OnLineList.Add(I);
                        result = I;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 初始化某用户
        /// </summary>
        /// <param name="Index"></param>
        public void Initialize(int Index)
        {
            TUserInfo UserInfo;
            UserInfo = GetItem(Index);
            if (UserInfo != null)
            {
                UserInfo.nIndex = -1;
                UserInfo.sAccount = "";
                UserInfo.sUserIPaddr = "";
                UserInfo.sGateIPaddr = "";
                UserInfo.sConnID = "";
                UserInfo.nSessionID = 0;
                UserInfo.Socket = null;
                UserInfo.sReceiveText = "";
                UserInfo.dwTick34 = GameFramework.HUtil32.GetTickCount();
                UserInfo.dwChrTick = GameFramework.HUtil32.GetTickCount();
                UserInfo.boChrSelected = false;
                UserInfo.boChrQueryed = false;
                UserInfo.nSelGateID = 0;
                UserInfo.dwQueryDelChrTick = GameFramework.HUtil32.GetTickCount();
                UserInfo.dwRestoreChr = GameFramework.HUtil32.GetTickCount();
                UserInfo.dwRandomTick = 0;
                UserInfo.boRandomNumber = false;
                UserInfo.sRandomNumber = "";
            }
        }

        /// <summary>
        /// 销毁用户
        /// </summary>
        /// <param name="Index"></param>
        public void Finalize(int Index)
        {
            TUserInfo UserInfo;
            UserInfo = GetItem(Index);
            if (UserInfo != null)
            {
                OnLineList.Remove(Index);
                DeleteList.Add(Index);
                UserInfo.nIndex = -1;
                UserInfo.Socket = null;
                UserInfo.sAccount = "";
                UserInfo.sUserIPaddr = "";
                UserInfo.sGateIPaddr = "";
                UserInfo.sConnID = "";
                UserInfo.sReceiveText = "";
            }
        }

        /// <summary>
        /// 获取用户数量
        /// </summary>
        public int Count
        {
            get
            {
                return UserArray.Length;
            }
        }

        /// <summary>
        /// 在线数量
        /// </summary>
        public int OnLineCount
        {
            get
            {
                return OnLineList.Count;
            }
        }
    } // end TSelectChar
}