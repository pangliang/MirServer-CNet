using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server.Command
{
    /// <summary>
    /// 调整指定玩家游戏币
    /// </summary>
    [GameCommand("RECALLMOBEX", "召唤宝宝", 10)]
    public class RECALLMOBEXCommand : BaseCommond
    {
        [DefaultCommand]
        public void RECALLMOBEX(TPlayObject PlayObject,string[] @Params)
        {
            //public void CmdRECALLMOBEX(TGameCmd Cmd, string sMonName, int nNameColor, int nX, int nY) //召唤宝宝
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sMonName = @Params.Length > 1 ? @Params[1] : "";
            int nNameColor = @Params.Length > 2 ? int.Parse(@Params[2]) : 0;
            int nX = @Params.Length > 3 ? int.Parse(@Params[3]) : 0;
            int nY = @Params.Length > 4 ? int.Parse(@Params[4]) : 0;

            TBaseObject mon;
            if ((PlayObject.m_btPermission < nPermission))
            {
                PlayObject.SysMsg(GameMsgDef.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sMonName == "") || ((sMonName != "") && (sMonName[0] == '?')))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name , GameMsgDef.g_sGameCommandRecallMobExHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (nX < 0)
            {
                nX = 0;
            }
            if (nY < 0)
            {
                nY = 0;
            }
            if (nNameColor < 0)
            {
                nNameColor = 0;
            }
            if (nNameColor > 255)
            {
                nNameColor = 255;
            }
            mon = UserEngine.RegenMonsterByName(PlayObject.m_PEnvir.sMapName, nX, nY, sMonName);
            if (mon != null)
            {
                mon.m_Master = PlayObject;
                mon.m_dwMasterRoyaltyTick = 86400000;// 24 * 60 * 60 * 1000
                mon.m_dwMasterRoyaltyTime = HUtil32.GetTickCount();// 20080813 增加
                mon.m_btSlaveMakeLevel = 3;
                mon.m_btSlaveExpLevel = 1;
                mon.m_btNameColor = (byte)nNameColor;
                mon.RecalcAbilitys();
                mon.RefNameColor();
                PlayObject.m_SlaveList.Add(mon);
            }
        }
    }
}