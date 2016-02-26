using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;

namespace M2Server
{
    [CommandGroup("mob", "召唤怪物")]
    public class CmdMobCommand : BaseCommands
    {
        [DefaultCommand]
        public unsafe void CmdMob(TPlayObject Play, TGameCmd Cmd, string sMonName, int nCount, int nLevel, int nMonTpye)
        {
            int I;
            int nX = 0;
            int nY = 0;
            TBaseObject Monster;
            bool BoIsNGMon;
            if ((Play.m_btPermission < Cmd.nPermissionMin))
            {
                Play.SysMsg(TMsgConst.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sMonName == "") || ((sMonName != "") && (sMonName[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    Play.SysMsg(string.Format(TMsgConst.g_sGameCommandParamUnKnow, Cmd.sCmd, TMsgConst.g_sGameCommandMobHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (nCount <= 0)
            {
                nCount = 1;
            }
            if (!(nLevel >= 0 && nLevel <= 10))
            {
                nLevel = 0;
            }
            BoIsNGMon = false;
            BoIsNGMon = nMonTpye != 0;//是否内功怪
            nCount = HUtil32._MIN(64, nCount);
            Play.GetFrontPosition(ref nX, ref nY);
            for (I = 0; I < nCount; I++)
            {
                Monster = M2Share.UserEngine.RegenMonsterByName(Play.m_PEnvir.sMapName, nX, nY, sMonName);
                if (Monster != null)
                {
                    Monster.m_boIsNGMonster = BoIsNGMon;
                    Monster.m_btSlaveMakeLevel = (byte)nLevel;
                    Monster.m_btSlaveExpLevel = (byte)nLevel;
                    Monster.RecalcAbilitys();
                    Monster.RefNameColor();
                }
                else
                {
                    Play.SysMsg(TMsgConst.g_sGameCommandMobMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                    break;
                }
            }
        }
    }
}