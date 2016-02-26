using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 从禁言列表中删除指定玩家
    /// </summary>
    [GameCommand("EnableSendMsg", "从禁言列表中删除指定玩家", 10)]
    public class EnableSendMsgCommand : BaseCommond
    {
        [DefaultCommand]
        public void EnableSendMsg(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";

            TPlayObject m_PlayObject;
            if (sHumanName == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            for (int I = M2Share.g_DisableSendMsgList.Count - 1; I >= 0; I--)
            {
                if (M2Share.g_DisableSendMsgList.Count <= 0)
                {
                    break;
                }
                if ((sHumanName).ToLower().CompareTo((M2Share.g_DisableSendMsgList[I]).ToLower()) == 0)
                {
                    m_PlayObject = UserEngine.GetPlayObject(sHumanName);
                    if (m_PlayObject != null)
                    {
                        m_PlayObject.m_boFilterSendMsg = false;
                    }
                    M2Share.g_DisableSendMsgList.RemoveAt(I);
                    M2Share.SaveDisableSendMsgList();
                    PlayObject.SysMsg(sHumanName + " 已从禁言列表中删除。", TMsgColor.c_Green, TMsgType.t_Hint);
                    return;
                }
            }
            PlayObject.SysMsg(sHumanName + " 没有被禁言！！！", TMsgColor.c_Red, TMsgType.t_Hint);
        }
    }
}