using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 调整当前玩家属下状态
    /// </summary>
    [GameCommand("ChangeSalveStatus", "调整当前玩家属下状态", 10)]
    public class ChangeSalveStatusCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeSalveStatus(TPlayObject PlayObject,string[] @Params)//by john 2013.4.24 无 m_MyHero 类
        {
            if (PlayObject.m_SlaveList.Count > 0)
            {
                PlayObject.m_boSlaveRelax = !PlayObject.m_boSlaveRelax;
                if (PlayObject.m_boSlaveRelax)
                {
                    PlayObject.SysMsg(GameMsgDef.sPetRest, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    PlayObject.SysMsg(GameMsgDef.sPetAttack, TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
        }
    }
}