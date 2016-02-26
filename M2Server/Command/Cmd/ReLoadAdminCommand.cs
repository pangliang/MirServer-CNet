using GameFramework;
using GameFramework.Command;

namespace M2Server.Command
{
    [GameCommand("ReLoadAdmin", "重新加载管理员列表", 10)]
    public class ReLoadAdminCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReLoadAdmin(TPlayObject PlayObject,string[] @Params)
        {
            if (PlayObject.m_btPermission < 6)
            {
                return;
            }
            LocalDB.GetInstance().LoadAdminList();
            UserEngine.SendServerGroupMsg(213, M2Share.nServerIndex, "");
            PlayObject.SysMsg("管理员列表重新加载成功...", TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}