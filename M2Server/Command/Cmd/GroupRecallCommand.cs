using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 组队传送
    /// </summary>
    [GameCommand(" GroupRecall", "组队传送", 10)]
    public class GroupRecallCommand : BaseCommond
    {
        [DefaultCommand]
        public void GroupRecall(TPlayObject PlayObject,string[] @Params)
        {
            uint dwValue;
            TPlayObject m_PlayObject;
            if (PlayObject.m_boRecallSuite || (PlayObject.m_btPermission >= 6))
            {
                if (!PlayObject.m_PEnvir.m_boNORECALL)
                {
                    dwValue = (HUtil32.GetTickCount() - PlayObject.m_dwGroupRcallTick) / 1000;
                    PlayObject.m_dwGroupRcallTick = PlayObject.m_dwGroupRcallTick + dwValue * 1000;
                    if (PlayObject.m_btPermission >= 6)
                    {
                        PlayObject.m_wGroupRcallTime = 0;
                    }
                    if (PlayObject.m_wGroupRcallTime > dwValue)
                    {
                        PlayObject.m_wGroupRcallTime -= dwValue;
                    }
                    else
                    {
                        PlayObject.m_wGroupRcallTime = 0;
                    }
                    if (PlayObject.m_wGroupRcallTime == 0)
                    {
                        if (PlayObject.m_GroupOwner == PlayObject)
                        {
                            for (int I = 1; I < PlayObject.m_GroupMembers.Count; I++)
                            {
                                m_PlayObject = ((PlayObject.m_GroupMembers[I]) as TPlayObject);
                                if (m_PlayObject.m_boAllowGroupReCall)
                                {
                                    if (m_PlayObject.m_PEnvir.m_boNORECALL)
                                    {
                                        PlayObject.SysMsg(String.Format("{0} 所在的地图不允许传送。", m_PlayObject.m_sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
                                    }
                                    else
                                    {
                                        PlayObject.RecallHuman(m_PlayObject.m_sCharName);
                                    }
                                }
                                else
                                {
                                    PlayObject.SysMsg(String.Format("{0} 不允许天地合一！！！", m_PlayObject.m_sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
                                }
                            }
                            PlayObject.m_dwGroupRcallTick = HUtil32.GetTickCount();
                            PlayObject.m_wGroupRcallTime = M2Share.g_Config.nGroupRecallTime;
                        }
                    }
                    else
                    {
                        PlayObject.SysMsg(String.Format("{0} 秒之后才可以再使用此功能！！！", PlayObject.m_wGroupRcallTime), TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("此地图禁止使用此命令！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg("您现在还无法使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}