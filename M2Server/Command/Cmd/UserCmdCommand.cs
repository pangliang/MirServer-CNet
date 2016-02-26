using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 自定义命令
    /// </summary>
    [GameCommand("UserCmd", "自定义命令", 10)]
    public class UserCmdCommand : BaseCommond
    {
        [DefaultCommand]
        public void UserCmd(TPlayObject PlayObject,string[] @Params) //by john 2013.4.24
        {
            string sLable = @Params.Length > 1 ? @Params[0] : "";
            //if (M2Share.g_FunctionNPC != null)
            //{
            //    PlayObject.m_nScriptGotoCount = 0;
            //    M2Share.g_FunctionNPC.GotoLable(PlayObject,sLable, false);
            //}

            byte Flag;
            Flag = 0;
            if (PlayObject.m_nUserCmdNPC == M2Share.g_FunctionNPC)
            {
                M2Share.g_FunctionNPC.GotoLable(PlayObject, sLable, false);
                Flag = 8;
            }
            else if (PlayObject.m_nUserCmdNPC == M2Share.g_BatterNPC)
            {
                M2Share.g_BatterNPC.GotoLable(PlayObject, sLable, false);
                Flag = 8;
            }
            if (Flag != 8)
            {
                M2Share.g_FunctionNPC.GotoLable(PlayObject, sLable, false);// 执行默认脚本  修复不能执行自定义脚本问题
            }
            PlayObject.m_nUserCmdNPC = null;
        }
    }
}