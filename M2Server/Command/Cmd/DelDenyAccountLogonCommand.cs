using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("DelDenyAccountLogon", "", 10)]
    public class DelDenyAccountLogonCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelDenyAccountLogon(TPlayObject PlayObject,string[] @Params)
        {
            string sAccount = @Params.Length > 0 ? @Params[0] : "";
            string sFixDeny = @Params.Length > 1 ? @Params[1] : "";
            if (sAccount == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 登录帐号", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            bool boDelete = false;
            M2Share.g_DenyAccountList.__Lock();
            try
            {
                for (int I = 0; I < M2Share.g_DenyAccountList.Count; I++)
                {
                    if ((sAccount).ToLower().CompareTo((M2Share.g_DenyAccountList[I]).ToLower()) == 0)
                    {
                        //if (((int)M2Share.g_DenyAccountList[I]) != 0)
                        //{
                        //    M2Share.SaveDenyAccountList();
                        //}
                        M2Share.g_DenyAccountList.RemoveAt(I);
                        PlayObject.SysMsg(sAccount + "已从禁止登录帐号列表中删除。", TMsgColor.c_Green, TMsgType.t_Hint);
                        boDelete = true;
                        break;
                    }
                }
            }
            finally
            {
                M2Share.g_DenyAccountList.UnLock();
            }
            if (!boDelete)
            {
                PlayObject.SysMsg(sAccount + "没有被禁止登录。", TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}