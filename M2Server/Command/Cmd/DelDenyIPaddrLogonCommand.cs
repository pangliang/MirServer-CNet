using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("DelDenyIPaddrLogon", "", 10)]
    public class DelDenyIPaddrLogonCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelDenyIPaddrLogon(TPlayObject PlayObject,string[] @Params)
        {
            string sIPaddr = @Params.Length > 0 ? @Params[0] : "";

            if (sIPaddr == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " IP地址", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            bool boDelete = false;
            M2Share.g_DenyIPAddrList.__Lock();
            try
            {
                for (int I = M2Share.g_DenyIPAddrList.Count - 1; I >= 0; I--)
                {
                    if (M2Share.g_DenyIPAddrList.Count <= 0)
                    {
                        break;
                    }
                    if ((sIPaddr).ToLower().CompareTo((M2Share.g_DenyIPAddrList[I]).ToLower()) == 0)
                    {
                        //if (((int)M2Share.g_DenyIPAddrList[I]) != 0)
                        //{
                        //    M2Share.SaveDenyIPAddrList();
                        //}
                        M2Share.g_DenyIPAddrList.RemoveAt(I);
                        PlayObject.SysMsg(sIPaddr + "已从禁止登录IP列表中删除。", TMsgColor.c_Green, TMsgType.t_Hint);
                        boDelete = true;
                        break;
                    }
                }
            }
            finally
            {
                M2Share.g_DenyIPAddrList.UnLock();
            }
            if (!boDelete)
            {
                PlayObject.SysMsg(sIPaddr + "没有被禁止登录。", TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}