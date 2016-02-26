using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 设定怪物集中点
    /// </summary>
    [GameCommand("MobPlace", "设定怪物集中点", 10)]
    public class MobPlaceCommand : BaseCommond
    {
        [DefaultCommand]
        public void MobPlace(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            string sX = @Params.Length > 0 ? @Params[0] : "";
            string sY = @Params.Length > 1 ? @Params[1] : "";
            string sMonName = @Params.Length > 2 ? @Params[2] : "";
            string sCount = @Params.Length > 3 ? @Params[3] : "";
            string sNGMon = @Params.Length > 4 ? @Params[4] : "";
            int nCount = HUtil32._MIN(500, HUtil32.Str_ToInt(sCount, 0));
            int nX = HUtil32.Str_ToInt(sX, 0);
            int nY = HUtil32.Str_ToInt(sY, 0);
            TEnvirnoment MEnvir;
            TBaseObject mon = null;
            bool boIsNGMon;
            byte nCode;
            nCode = 0;
            try
            {
                nCount = HUtil32._MIN(500, HUtil32.Str_ToInt(sCount, 0));
                nX = HUtil32.Str_ToInt(sX, 0);
                nY = HUtil32.Str_ToInt(sY, 0);
                boIsNGMon = HUtil32.Str_ToInt(sNGMon, 0) != 0;
                if ((nX <= 0) || (nY <= 0) || (sMonName == "") || (nCount <= 0))
                {
                    if (M2Share.g_Config.boGMShowFailMsg)
                    {
                        PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " X  Y 怪物名称 怪物数量 内功怪(0/1)", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    return;
                }
                nCode = 1;
                MEnvir = M2Share.g_MapManager.FindMap(M2Share.g_sMissionMap);
                if (!M2Share.g_boMission || (MEnvir == null))
                {
                    PlayObject.SysMsg("还没有设定怪物集中点！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    PlayObject.SysMsg("请先用命令" + M2Share.g_GameCommand.Mission.sCmd + "设置怪物的集中点。", TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                nCode = 2;
                for (int I = 0; I < nCount; I++)
                {
                    nCode = 3;
                    mon = UserEngine.RegenMonsterByName(M2Share.g_sMissionMap, nX, nY, sMonName);
                    nCode = 4;
                    if (mon != null)
                    {
                        nCode = 5;
                        mon.m_boIsNGMonster = boIsNGMon;
                        mon.m_boMission = true;
                        mon.m_nMissionX = M2Share.g_nMissionX;
                        mon.m_nMissionY = M2Share.g_nMissionY;
                    }
                    else
                    {
                        break;
                    }
                }
                nCode = 6;
                if (mon.m_btRaceServer != 136)
                {
                    PlayObject.SysMsg((nCount).ToString() + " 只 " + sMonName + " 已正在往地图 " + M2Share.g_sMissionMap + " " +
                        M2Share.g_nMissionX + ":" + M2Share.g_nMissionY + " 集中。", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TPlayObject.CmdMobPlace Code:" + (nCode).ToString());
            }
        }
    }
}