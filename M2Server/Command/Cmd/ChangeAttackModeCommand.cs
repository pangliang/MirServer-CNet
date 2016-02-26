using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 调整当前玩家攻击模式
    /// </summary>
    [GameCommand("ChangeAttackMode", "调整当前玩家攻击模式", 10)]
    public class ChangeAttackModeCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeAttackMode(TPlayObject PlayObject,string[] @Params)
        {
            int nMode = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            if ((nMode >= 0) && (nMode <= 4))
            {
                PlayObject.m_btAttatckMode = (byte)nMode;
            }
            else
            {
                if (PlayObject.m_btAttatckMode < M2Share.HAM_PKATTACK)
                {
                    PlayObject.m_btAttatckMode++;
                }
                else
                {
                    PlayObject.m_btAttatckMode = M2Share.HAM_ALL;
                }
            }
            PlayObject.SendAttatckMode();
            if (PlayObject.m_MyHero != null)
            {
                PlayObject.m_MyHero.m_btAttatckMode = PlayObject.m_btAttatckMode;
            }
        }
    }
}