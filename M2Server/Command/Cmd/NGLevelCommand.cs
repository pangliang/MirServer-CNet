using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server
{
    [GameCommand("NGLevel", "", 10)]
    public class NGLevelCommand:BaseCommond
    {
        [DefaultCommand]
        public void NGLevel(TPlayObject PlayObject,string[] @Params)
        {
            //string sHumanName, int nLevel)
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            int nLevel = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;

            TPlayObject PlayObjectA;
            TBaseObject HeroObject;
            int nOLevel;
            if ((PlayObject.m_btPermission < this.Attributes.nPermissionMin))
            {
                PlayObject.SysMsg(GameMsgDef.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sHumanName == "") || (nLevel < 0) || (nLevel > 255))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 内功等级(1-255)", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            PlayObjectA = UserEngine.GetPlayObject(sHumanName);
            if (PlayObjectA != null)
            {
                if (PlayObjectA.m_boTrainingNG)
                {
                    nOLevel = PlayObjectA.m_NGLevel;
                    PlayObjectA.m_NGLevel = (byte)HUtil32._MAX(1, HUtil32._MIN(255, nLevel));
                    PlayObjectA.SendNGData();// 发送内功数据
                    PlayObjectA.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, "");// 人物升级动画 
                    PlayObject.NGLevelUpFunc();// 内功升级触发
                    // 等级调整记录日志
                    M2Share.AddGameDataLog("17" + "\09" + PlayObjectA.m_sMapName + "\09" + (PlayObjectA.m_nCurrX).ToString() + "\09" +
                        (PlayObjectA.m_nCurrY).ToString() + "\09" + PlayObjectA.m_sCharName + "\09" + (PlayObjectA.m_NGLevel).ToString() + "\09" + "内功" + "\09" + "=("
                        + (nLevel).ToString() + ")" + "\09" + PlayObject.m_sCharName + "(GM)");
                    PlayObject.SysMsg(sHumanName + " 内功等级调整完成。", TMsgColor.c_Green, TMsgType.t_Hint);
                    if (GameConfig.boShowMakeItemMsg)
                    {
                        M2Share.MainOutMessage("[内功等级调整] " + PlayObject.m_sCharName + "(" + PlayObjectA.m_sCharName + " " + (nOLevel).ToString() + " -> " +
                            (PlayObjectA.m_NGLevel).ToString() + ")");
                    }
                }
                else
                {
                    PlayObject.SysMsg(PlayObjectA.m_sCharName + " 还未学习内功心法!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            else
            {
                HeroObject = UserEngine.GetHeroObject(sHumanName);// 查找英雄
                if (HeroObject != null)
                {
                    if (((THeroObject)(HeroObject)).m_boTrainingNG)
                    {
                        nOLevel = ((THeroObject)(HeroObject)).m_NGLevel;
                        ((THeroObject)(HeroObject)).m_NGLevel = (byte)HUtil32._MAX(1, HUtil32._MIN(255, nLevel));
                        HeroObject.SendNGData();// 发送内功数据
                        HeroObject.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, "");// 人物升级动画 
                        ((THeroObject)(HeroObject)).NGLevelUpFunc();// 内功升级触发
                        // 等级调整记录日志
                        M2Share.AddGameDataLog("17" + "\09" + HeroObject.m_sMapName + "\09" + (HeroObject.m_nCurrX).ToString() + "\09" + (HeroObject.m_nCurrY).ToString()
                            + "\09" + HeroObject.m_sCharName + "\09" + (((THeroObject)(HeroObject)).m_NGLevel).ToString() + "\09" + "英雄内功" + "\09" + "=(" + (nLevel).ToString() + ")"
                            + "\09" + PlayObject.m_sCharName + "(GM)");
                        PlayObject.SysMsg(sHumanName + " 内功等级调整完成。", TMsgColor.c_Green, TMsgType.t_Hint);
                        if (GameConfig.boShowMakeItemMsg)
                        {
                            M2Share.MainOutMessage("[内功等级调整] " + PlayObject.m_sCharName + "(" + HeroObject.m_sCharName + " " + (nOLevel).ToString() + " -> "
                                + (((THeroObject)(HeroObject)).m_NGLevel).ToString() + ")");
                        }
                    }
                    else
                    {
                        PlayObject.SysMsg(HeroObject.m_sCharName + " 还未学习内功心法!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, new string[] { sHumanName }), TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
        }
    }
}
