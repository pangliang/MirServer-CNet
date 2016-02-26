using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整安全去光环
    /// MOBFIREBURN  3 329 329 3 60 0
    /// </summary>
    [GameCommand("MobFireBurn", "调整安全去光环", 10)]
    public class MobFireBurnCommand : BaseCommond
    {
        [DefaultCommand]
        public void MobFireBurn(TPlayObject PlayObject,string[] @Params)
        {
            string sMAP = @Params.Length > 0 ? @Params[0] : "";//地图号
            string sX = @Params.Length > 1 ? @Params[1] : "";//坐标X
            string sY = @Params.Length > 2 ? @Params[2] : "";//坐标Y
            string sType = @Params.Length > 3 ? @Params[3] : "";//光环效果
            string sTime = @Params.Length > 4 ? @Params[4] : "";//持续时间
            string sPoint = @Params.Length > 5 ? @Params[5] : "";//未知
            if ((sMAP == "") || ((sMAP != "") && (sMAP[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMobFireBurnHelpMsg, this.Attributes.Name, sMAP, sX,
                    sY, sType, sTime, sPoint), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            int nX = HUtil32.Str_ToInt(sX, -1);
            int nY = HUtil32.Str_ToInt(sY, -1);
            int nType = HUtil32.Str_ToInt(sType, -1);
            uint nTime = (uint)HUtil32.Str_ToInt(sTime, -1);
            int nPoint = HUtil32.Str_ToInt(sPoint, -1);
            if (nPoint < 0)
            {
                nPoint = 1;
            }
            if ((sMAP == "") || (nX < 0) || (nY < 0) || (nType < 0) || (nTime < 0) || (nPoint < 0))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMobFireBurnHelpMsg, this.Attributes.Name, sMAP, sX, sY,
                    sType, sTime, sPoint), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMAP);
            if (Envir != null)
            {
                TEnvirnoment OldEnvir = PlayObject.m_PEnvir;
                PlayObject.m_PEnvir = Envir;
                TFireBurnEvent FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY, nType, nTime * 1000, nPoint);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
                PlayObject.m_PEnvir = OldEnvir;
                return;
            }
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandMobFireBurnMapNotFountMsg, this.Attributes.Name, sMAP), TMsgColor.c_Red, TMsgType.t_Hint);
        }
    }
}