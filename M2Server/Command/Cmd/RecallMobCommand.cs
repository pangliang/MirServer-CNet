using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 召唤指定怪物为宠物
    /// 格式:RECALLMOB 怪物名称 宝宝等级(最高为 7) 叛变时间(分钟) 是否自动变色（0、1）固定颜色（1-7）
    /// </summary>
    [GameCommand("RecallMob", "召唤指定怪物为宠物", 10)]
    public class RecallMobCommand : BaseCommond
    {
        [DefaultCommand]
        public void RecallMob(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            string sMonName = @Params.Length > 0 ? @Params[0] : "";
            int nCount = @Params.Length > 1 ? Convert.ToInt32(@Params[1]) : 0;
            int nLevel = @Params.Length > 2 ? Convert.ToInt32(@Params[2]) : 0;
            int nAutoChangeColor = @Params.Length > 3 ? Convert.ToInt32(@Params[3]) : 0;
            int nFixColor = @Params.Length > 4 ? Convert.ToInt32(@Params[4]) : 0;

            int n10 = 0;
            int n14 = 0;
            TBaseObject mon;
            if ((sMonName == "") || ((sMonName != "") && (sMonName[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandRecallMobHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (nLevel >= 10)
            {
                nLevel = 0;
            }
            if (nCount <= 0)
            {
                nCount = 1;
            }
            for (int I = 0; I < nCount; I++)
            {
                if (PlayObject.m_SlaveList.Count >= 20)
                {
                    break;
                }
                PlayObject.GetFrontPosition(ref n10, ref n14);
                mon = UserEngine.RegenMonsterByName(PlayObject.m_PEnvir.sMapName, n10, n14, sMonName);
                if (mon != null)
                {
                    mon.m_Master = PlayObject;
                    mon.m_dwMasterRoyaltyTick = 86400000;// 24 * 60 * 60 * 1000
                    mon.m_dwMasterRoyaltyTime = HUtil32.GetTickCount();
                    mon.m_btSlaveMakeLevel = 3;
                    mon.m_btSlaveExpLevel = (byte)nLevel;
                    if (nAutoChangeColor == 1)
                    {
                        mon.m_boAutoChangeColor = true;
                    }
                    else if (nFixColor > 0)
                    {
                        mon.m_boFixColor = true;
                        mon.m_nFixColorIdx = nFixColor - 1;
                    }
                    mon.RecalcAbilitys();
                    mon.RefNameColor();
                    PlayObject.m_SlaveList.Add(mon);
                }
            }
        }
    }
}