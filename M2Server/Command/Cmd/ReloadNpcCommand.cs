using GameFramework;
using GameFramework.Command;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 重新加载当前12格范围内NPC
    /// </summary>
    [GameCommand("ReloadNpc", "重新加载当前9格范围内NPC", 10)]
    public class ReloadNpcCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReloadNpc(TPlayObject PlayObject,string[] @Params)
        {
            string sParam = string.Empty;
            if (@Params != null)
            {
                sParam = @Params.Length > 0 ? @Params[0] : "";
            }
            List<TMerchant> TmpMerList = null;
            List<TNormNpc> TmpNorList = null;
            TMerchant Merchant;
            TNormNpc NPC;
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            if (("all").ToLower().CompareTo((sParam).ToLower()) == 0)
            {
                LocalDB.GetInstance().ReLoadMerchants();
                UserEngine.ReloadMerchantList();
                PlayObject.SysMsg("交易NPC重新加载完成！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                UserEngine.ReloadNpcList();
                PlayObject.SysMsg("管理NPC重新加载完成！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TmpMerList = new List<TMerchant>();
            try
            {
                if (UserEngine.GetMerchantList(PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 9, TmpMerList) > 0)
                {
                    for (int I = 0; I < TmpMerList.Count; I++)
                    {
                        Merchant = TmpMerList[I];
                        Merchant.ClearScript();
                        Merchant.LoadNpcScript();
                        PlayObject.SysMsg(Merchant.m_sCharName + "重新加载成功...", TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("附近未发现任何交易NPC！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                TmpNorList = new List<TNormNpc>();
                if (UserEngine.GetNpcList(PlayObject.m_PEnvir, PlayObject.m_nCurrX, PlayObject.m_nCurrY, 9, TmpNorList) > 0)
                {
                    for (int I = 0; I < TmpNorList.Count; I++)
                    {
                        NPC = TmpNorList[I];
                        NPC.ClearScript();
                        NPC.LoadNpcScript();
                        PlayObject.SysMsg(NPC.m_sCharName + "重新加载成功...", TMsgColor.c_Green, TMsgType.t_Hint);
                    }
                }
                else
                {
                    PlayObject.SysMsg("附近未发现任何管理NPC！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            finally
            {
                HUtil32.Dispose(TmpMerList);
                HUtil32.Dispose(TmpNorList);
            }
        }
    }
}