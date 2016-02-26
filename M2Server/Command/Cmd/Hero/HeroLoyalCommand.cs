using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command
{
    /// <summary>
    /// 调整指定玩家英雄忠诚度
    /// </summary>
    [GameCommand("HeroLoyal", "调整指定玩家英雄忠诚度", 10)]
    public class HeroLoyalCommand : BaseCommond
    {
        [DefaultCommand]
        public void HeroLoyal(TPlayObject PlayObject,string[] @Params)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            int nHeroLoyal = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;


            if ((sHumanName == "") || (nHeroLoyal < 0) || (nHeroLoyal > 10000) || ((sHumanName != "") && (sHumanName[0] == '?')))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, base.Attributes.Name, GameMsgDef.g_sGameCommandHeroLoyalHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            TBaseObject m_PlayObject = UserEngine.GetHeroObject(sHumanName);
            if (m_PlayObject != null)
            {
                ((THeroObject)(m_PlayObject)).m_nLoyal = nHeroLoyal;
                PlayObject.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROABILITY, ((THeroObject)(m_PlayObject)).m_btGender, 0, ((THeroObject)(m_PlayObject)).m_btJob, ((THeroObject)(m_PlayObject)).m_nLoyal, 0);
                //替换上面一句
                //SendSocket(this.m_DefMsg, EncryptUnit.EncodeBuffer(((THeroObject)(PlayObject)).m_WAbil, sizeof(TAbility)));
                PlayObject.SysMsg("[英雄忠诚度调整] " + sHumanName + " -> (" + (((THeroObject)(m_PlayObject)).m_nLoyal / 100).ToString() + "%)", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                if (GameConfig.boShowMakeItemMsg)
                {
                    M2Share.MainOutMessage("[英雄忠诚度调整] " + sHumanName + " -> (" + (((THeroObject)(m_PlayObject)).m_nLoyal).ToString() + ")");
                }
            }
            else
            {
                PlayObject.SysMsg("英雄" + sHumanName + "现在不在线。", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}
