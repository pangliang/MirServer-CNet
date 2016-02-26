using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command.Cmd
{
    /// <summary>
    /// 调整指定英雄等级
    /// </summary>
    [GameCommand("HeroLevel", "调整指定英雄等级", 10)]
    public class HeroLevelCommand : BaseCommond
    {
        [DefaultCommand]
        public void HeroLevel(TPlayObject PlayObject,string[] @Params)
        {
            string sHeroName = @Params.Length > 0 ? @Params[0] : "";
            int nLevel = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;

            int nOLevel;
            if (sHeroName == "")
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + base.Attributes.Name + " 英雄名称 等级", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            TBaseObject m_PlayObject = UserEngine.GetHeroObject(sHeroName);
            if (m_PlayObject != null)
            {
                nOLevel = m_PlayObject.m_Abil.Level;
                //PlayObject.m_Abil.Level = HUtil32._MAX(1, HUtil32._MIN(M2Share.MAXUPLEVEL, nLevel));
                m_PlayObject.HasLevelUp(1);
                // 等级调整记录日志
                M2Share.AddGameDataLog("17" + "\09" + m_PlayObject.m_sMapName + "\09" + (m_PlayObject.m_nCurrX).ToString() + "\09" + (m_PlayObject.m_nCurrY).ToString() + "\09"
                    + m_PlayObject.m_sCharName + "\09" + (m_PlayObject.m_Abil.Level).ToString() + "\09" + m_PlayObject.m_sCharName + "\09" + "+(" + (nLevel).ToString() + ")" + "\09" + "(英雄)");
                PlayObject.SysMsg("英雄 " + sHeroName + " 等级调整完成。", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                if (GameConfig.boShowMakeItemMsg)
                {
                    M2Share.MainOutMessage("[英雄等级调整] " + sHeroName + "(" + (nOLevel).ToString() + " -> " + (m_PlayObject.m_Abil.Level).ToString() + ")");
                }
            }
            else
            {
                PlayObject.SysMsg("英雄" + sHeroName + "现在不在线。", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}