using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("DelDenyCharNameLogon", "", 10)]
    public class DelDenyCharNameLogonCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelDenyCharNameLogon(TPlayObject PlayObject,string[] @Params)
        {
            string sCharName = @Params.Length > 0 ? @Params[0] : "";

            if (sCharName == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            bool boDelete = false;
            M2Share.g_DenyChrNameList.__Lock();
            try
            {
                for (int I = 0; I < M2Share.g_DenyChrNameList.Count; I++)
                {
                    if ((sCharName).ToLower().CompareTo((M2Share.g_DenyChrNameList[I]).ToLower()) == 0)
                    {
                        //if (((int)M2Share.g_DenyChrNameList[I]) != 0)
                        //{
                        //    M2Share.SaveDenyChrNameList();
                        //}
                        M2Share.g_DenyChrNameList.RemoveAt(I);
                        PlayObject.SysMsg(sCharName + "已从禁止登录人物列表中删除。", TMsgColor.c_Green, TMsgType.t_Hint);
                        boDelete = true;
                        break;
                    }
                }
            }
            finally
            {
                M2Share.g_DenyChrNameList.UnLock();
            }
            if (!boDelete)
            {
                PlayObject.SysMsg(sCharName + "没有被禁止登录。", TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}