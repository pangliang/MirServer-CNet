using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 重新加载怪物爆率文件
    /// </summary>
    [GameCommand("ReloadMonItems", "重新加载怪物爆率文件", 10)]
    public class ReloadMonItemsCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReloadMonItems(TPlayObject PlayObject,string[] @Params)
        {
            TMonInfo Monster;
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            try
            {
                for (int I = 0; I < UserEngine.MonsterList.Count; I++)
                {
                    Monster = UserEngine.MonsterList[I];
                    M2Share.GameDataBase.LoadMonitems(Monster.sName, ref Monster.ItemList);
                }
                PlayObject.SysMsg("怪物爆物品列表重加载完成...", TMsgColor.c_Green, TMsgType.t_Hint);
            }
            catch
            {
                PlayObject.SysMsg("怪物爆物品列表重加载失败！！！", TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}