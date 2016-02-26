using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 在当前XY坐标创建NPC
    /// </summary>
    [GameCommand("MobNpc", "在当前XY坐标创建NPC", 10)]
    public class MobNpcCommand : BaseCommond
    {
        [DefaultCommand]
        public void MobNpc(TPlayObject PlayObject,string[] @Params)
        {
            int nAppr = 0;
            bool boIsCastle = false;
            TMerchant Merchant = null;
            int nX = 0;
            int nY = 0;
            string sParam1 = @Params.Length > 0 ? @Params[0] : "";
            string sParam2 = @Params.Length > 1 ? @Params[1] : "";
            string sParam3 = @Params.Length > 2 ? @Params[2] : "";
            string sParam4 = @Params.Length > 3 ? @Params[3] : "";
            if ((sParam1 == "") || (sParam2 == "") || ((sParam1 != "") && (sParam1[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandMobNpcHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            nAppr = HUtil32.Str_ToInt(sParam3, 0);
            boIsCastle = (HUtil32.Str_ToInt(sParam4, 0) == 1);
            if (sParam1 == "")
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " NPC名称 脚本文件名 外形(数字) 属沙城(0,1)", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            Merchant = new TMerchant();
            Merchant.m_sCharName = sParam1;
            Merchant.m_sMapName = PlayObject.m_sMapName;
            Merchant.m_PEnvir = PlayObject.m_PEnvir;
            Merchant.m_wAppr = (ushort)nAppr;
            Merchant.m_nFlag = 0;
            Merchant.m_boCastle = boIsCastle;
            Merchant.m_sScript = sParam2;
            PlayObject.GetFrontPosition(ref nX, ref nY);
            Merchant.m_nCurrX = nX;
            Merchant.m_nCurrY = nY;
            Merchant.Initialize();
            UserEngine.AddMerchant(Merchant);
        }
    }
}