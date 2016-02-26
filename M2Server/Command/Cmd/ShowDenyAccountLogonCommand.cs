using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 查看禁止登陆帐号
    /// </summary>
    [GameCommand("ShowDenyAccountLogon", "查看禁止登陆帐号", 10)]
    public class ShowDenyAccountLogonCommand : BaseCommond
    {
        [DefaultCommand]
        public void ShowDenyAccountLogon(TPlayObject PlayObject,string[] @Params)
        {
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            M2Share.g_DenyAccountList.__Lock();
            try
            {
                if (M2Share.g_DenyAccountList.Count <= 0)
                {
                    PlayObject.SysMsg("禁止登录帐号列表为空。", TMsgColor.c_Green, TMsgType.t_Hint);
                    return;
                }
                for (int I = 0; I < M2Share.g_DenyAccountList.Count; I++)
                {
                    PlayObject.SysMsg(M2Share.g_DenyAccountList[I], TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            finally
            {
                M2Share.g_DenyAccountList.UnLock();
            }
        }
    }
}