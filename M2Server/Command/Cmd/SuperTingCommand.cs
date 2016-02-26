using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 随机传送一个指定玩家和他身边的人
    /// </summary>
    [GameCommand("SuperTing", "随机传送一个指定玩家和他身边的人", 10)]
    public class SuperTingCommand : BaseCommond
    {
        [DefaultCommand]
        public void SuperTing(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sRange = @Params.Length > 1 ? @Params[1] : "";
            TPlayObject m_PlayObject;
            TPlayObject MoveHuman;
            List<TPlayObject> HumanList;
            if ((sRange == "") || (sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandSuperTingHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            int nRange = HUtil32._MAX(10, HUtil32.Str_ToInt(sRange, 2));
            m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                HumanList = new List<TPlayObject>();
                UserEngine.GetMapRageHuman(m_PlayObject.m_PEnvir, m_PlayObject.m_nCurrX, m_PlayObject.m_nCurrY, nRange, HumanList);
                for (int I = 0; I < HumanList.Count; I++)
                {
                    MoveHuman = HumanList[I];
                    if (MoveHuman != PlayObject)
                    {
                        MoveHuman.MapRandomMove(MoveHuman.m_sHomeMap, 0);
                    }
                }
                HUtil32.Dispose(HumanList);
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}