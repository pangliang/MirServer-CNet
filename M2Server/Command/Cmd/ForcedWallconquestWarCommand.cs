using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 开始攻城战役
    /// </summary>
    [GameCommand("ForcedWallconquestWar", "开始攻城战役", 10)]
    public class ForcedWallconquestWarCommand : BaseCommond
    {
        [DefaultCommand]
        public void ForcedWallconquestWar(TPlayObject PlayObject,string[] @Params)
        {
            string sCASTLENAME = @Params.Length > 0 ? @Params[0] : "";
            string s20;
            TGUild Guild = null;
            if (sCASTLENAME == "")
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + base.Attributes.Name + " 城堡名称", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            TUserCastle Castle = M2Share.g_CastleManager.Find(sCASTLENAME);
            if (Castle != null)
            {
                Castle.m_boUnderWar = !Castle.m_boUnderWar;// 设置为可以攻城
                if (Castle.m_boUnderWar) // 正在攻城
                {
                    if (GuildManager.GuildList.Count > 0)  // 增加所有行会为攻城行会
                    {
                        for (int I = 0; I < GuildManager.GuildList.Count; I++)
                        {
                            Guild = GuildManager.GuildList[I];
                            Castle.m_AttackGuildList.Add(Guild);
                        }
                    }
                    Castle.m_boShowOverMsg = false;
                    Castle.m_WarDate = DateTime.Now;
                    Castle.m_dwStartCastleWarTick = HUtil32.GetTickCount();
                    Castle.StartWallconquestWar();
                    UserEngine.SendServerGroupMsg(Grobal2.SS_212, M2Share.nServerIndex, "");
                    s20 = "[" + Castle.m_sName + " 攻城战已经开始]";
                    UserEngine.SendBroadCastMsg(s20, TMsgType.t_System);
                    UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.nServerIndex, s20);
                    Castle.MainDoorControl(true);
                }
                else
                {
                    Castle.StopWallconquestWar();
                }
            }
            else
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandSbkGoldCastleNotFoundMsg, sCASTLENAME), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}