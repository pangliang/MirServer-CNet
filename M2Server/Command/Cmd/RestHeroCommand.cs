using GameFramework.Command;

namespace M2Server
{
    [GameCommand("RestHero", "", 10)]
    public class RestHeroCommand : BaseCommond
    {
        [DefaultCommand]
        public void RestHero(TPlayObject PlayObject,string[] @Params)
        {
            if ((PlayObject.m_MyHero != null))
            {
               // ((THeroObject)(PlayObject.m_MyHero)).RestHero();
            }
        }
    }
}