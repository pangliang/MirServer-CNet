using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 刷指定怪物
    /// </summary>
    [GameCommand("Mob", "刷指定怪物", 10)]
    public class MobCommand : BaseCommond
    {
        [DefaultCommand]
        public void Mob(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            int nX = 0;
            int nY = 0;
            TBaseObject Monster = null;
            string sMonName = @Params.Length > 0 ? @Params[0] : "";//名称
            byte nCount = @Params.Length > 1 ? Convert.ToByte(@Params[1]) : (byte)1;//数量
            byte nLevel = @Params.Length > 2 ? Convert.ToByte(@Params[2]) : (byte)1;//怪物等级
            if (sMonName == "")
            {
                return;
            }
            if (nCount <= 0)
            {
                nCount = 1;
            }
            if (!(nLevel >= 0 && nLevel <= 10))
            {
                nLevel = 0;
            }
            nCount = (byte)HUtil32._MIN(64, nCount);
            PlayObject.GetFrontPosition(ref nX, ref nY);//刷在当前X，Y坐标
            for (int I = 0; I < nCount; I++)
            {
                Monster = UserEngine.RegenMonsterByName(PlayObject.m_PEnvir.sMapName, nX, nY, sMonName);
                if (Monster != null)
                {
                    Monster.m_btSlaveMakeLevel = nLevel;
                    Monster.m_btSlaveExpLevel = nLevel;
                    Monster.RecalcAbilitys();
                    Monster.RefNameColor();
                }
                else
                {
                    PlayObject.SysMsg(GameMsgDef.g_sGameCommandMobMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                    break;
                }
            }
        }
    }
}