using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家技能等级
    /// </summary>
    [GameCommand("TrainingSkill", "调整指定玩家技能等级", 10)]
    public class TrainingSkillCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void TrainingSkill(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sSkillName = @Params.Length > 1 ? @Params[1] : "";
            int nLevel = @Params.Length > 2 ? int.Parse(@Params[2]) : 0;
            TUserMagic* UserMagic;
            if ((sHumanName == "") || (sSkillName == "") || (nLevel <= 0))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称  技能名称 修炼等级(0-3)", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            nLevel = HUtil32._MIN(3, nLevel);
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format("{0}不在线，或在其它服务器上！！", sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            for (int I = 0; I < m_PlayObject.m_MagicList.Count; I++)
            {
                UserMagic = (TUserMagic*)m_PlayObject.m_MagicList[I];
                if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, 0, UserMagic->MagicInfo.DescrLen)).ToLower().CompareTo((sSkillName).ToLower()) == 0)
                {
                    UserMagic->btLevel = (byte)nLevel;
                    m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_MAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "");
                    m_PlayObject.SysMsg(String.Format("{0}的修改炼等级为{1}", sSkillName, nLevel), TMsgColor.c_Green, TMsgType.t_Hint);
                    PlayObject.SysMsg(String.Format("{0}的技能{1}修炼等级为{2}", sHumanName, sSkillName, nLevel), TMsgColor.c_Green, TMsgType.t_Hint);
                    break;
                }
            }
        }
    }
}