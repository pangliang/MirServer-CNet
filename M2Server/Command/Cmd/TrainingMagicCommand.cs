using GameFramework;
using GameFramework.Command;
using System;
using System.Runtime.InteropServices;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家技能
    /// </summary>
    [GameCommand("TrainingMagic", "调整指定玩家技能", 10)]
    public class TrainingMagicCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void TrainingMagic(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sSkillName = @Params.Length > 1 ? @Params[1] : "";
            int nLevel = @Params.Length > 2 ? Convert.ToInt32(@Params[2]) : 0;
            string HeroStr = @Params.Length > 3 ? @Params[3] : "";

            TMagic* Magic;
            TUserMagic* UserMagic = null;
            TPlayObject m_PlayObject;
            THeroObject HeroObject;
            if (((sHumanName != "") && (sHumanName[0] == '?')) || (sHumanName == "") || (sSkillName == "") || (nLevel < 0) || !(nLevel >= 0 && nLevel <= 3))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称  技能名称 修炼等级(0-3) hero", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (("HERO").ToLower().CompareTo((HeroStr).ToLower()) == 0)
            {
                HeroObject = ((THeroObject)(UserEngine.GetHeroObject(sHumanName)));
                if (HeroObject == null)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, new string[] { sHumanName }), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                Magic = UserEngine.FindHeroMagic(sSkillName);
                if (Magic == null)
                {
                    PlayObject.SysMsg(string.Format("{0} 技能名称不正确！！！", sSkillName), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (HeroObject.IsTrainingSkill(Magic->wMagicId))
                {
                    PlayObject.SysMsg(string.Format("{0} 技能已修炼过了！！！", sSkillName), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if ((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "内功") && (!HeroObject.m_boTrainingNG)) // 没有内功心法,则不能学内功技能
                {
                    PlayObject.SysMsg(string.Format("(英雄) %s 没学过内功心法,不能学习此 %s 技能！！！", new string[] { HeroObject.m_sCharName, sSkillName }), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));
                UserMagic->MagicInfo = *Magic;
                UserMagic->wMagIdx = Magic->wMagicId;
                UserMagic->btLevel = (byte)nLevel;
                UserMagic->btKey = 0;
                UserMagic->nTranPoint = 0;
                HeroObject.m_MagicList.Add((IntPtr)UserMagic);
                HeroObject.SendAddMagic(UserMagic);
                HeroObject.RecalcAbilitys();
                HeroObject.CompareSuitItem(false);// 套装
                PlayObject.SysMsg(string.Format("{0} 的 {1} 技能修炼成功！！！", HeroObject.m_sCharName, sSkillName), TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                m_PlayObject = UserEngine.GetPlayObject(sHumanName);
                if (m_PlayObject == null)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                Magic = UserEngine.FindMagic(sSkillName);
                if (Magic == null)
                {
                    PlayObject.SysMsg(string.Format("%s 技能名称不正确！！！", sSkillName), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                if (m_PlayObject.IsTrainingSkill(Magic->wMagicId))
                {
                    PlayObject.SysMsg(string.Format("%s 技能已修炼过了！！！", sSkillName), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                // 没有内功心法,则不能学内功技能
                if ((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "内功") && (!PlayObject.m_boTrainingNG))
                {
                    PlayObject.SysMsg(string.Format("玩家%s 没学过内功心法,不能学习此 %s 技能！！！", sHumanName, sSkillName), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                UserMagic = (TUserMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic));
                UserMagic->MagicInfo = *Magic;
                UserMagic->wMagIdx = Magic->wMagicId;
                UserMagic->btLevel = (byte)nLevel;
                UserMagic->btKey = 0;
                UserMagic->nTranPoint = 0;
                m_PlayObject.m_MagicList.Add((IntPtr)UserMagic);
                m_PlayObject.SendAddMagic(UserMagic);
                m_PlayObject.RecalcAbilitys();
                m_PlayObject.CompareSuitItem(false);// 套装
                PlayObject.SysMsg(string.Format("{0} 的 {1} 技能修炼成功！！！", sHumanName, sSkillName), TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}