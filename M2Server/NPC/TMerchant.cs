/*
 * 名称：TMerchant
 * 创建人：John
 * 创建时间：2012-3-6 9:35:54
 * 描述:
 *********************************************
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GameFramework;
using GameFramework.Enum;
using M2Server.ScriptSystem;

namespace M2Server
{
    public class TMerchant : TNormNpc
    {
        public string m_sScript = string.Empty;
        /// <summary>
        /// 物品价格倍率 默认为 100%
        /// </summary>
        public int m_nPriceRate = 0;
        /// <summary>
        /// 是否属于城堡
        /// </summary>
        public bool m_boCastle = false;
        public uint dwRefillGoodsTick = 0;
        public uint dwClearExpreUpgradeTick = 0;
        /// <summary>
        /// NPC买卖物品类型列表，脚本中前面的 +1 +30 之类的
        /// </summary>
        public ArrayList m_ItemTypeList = null;
        /// <summary>
        /// 刷新商品列表
        /// </summary>
        public List<TGoods> m_RefillGoodsList = null;
        /// <summary>
        /// 商品类别列表
        /// </summary>
        public List<List<IntPtr>> m_GoodsList = null;
        /// <summary>
        /// 物品价格列表
        /// </summary>
        public IList<IntPtr> m_ItemPriceList = null;
        /// <summary>
        /// 武器升级列表
        /// </summary>
        public IList<IntPtr> m_UpgradeWeaponList = null;
        /// <summary>
        /// 是否可以移动
        /// </summary>
        public bool m_boCanMove = false;
        /// <summary>
        /// 移动时间
        /// </summary>
        public uint m_dwMoveTime = 0;
        /// <summary>
        /// 移动间隔
        /// </summary>
        public uint m_dwMoveTick = 0;
        /// <summary>
        /// 是否可买卖
        /// </summary>
        public bool m_boBuy = false;
        /// <summary>
        /// NPC是否接收 玩家卖物品
        /// </summary>
        public bool m_boSell = false;
        public bool m_boMakeDrug = false;
        public bool m_boPrices = false;
        public bool m_boStorage = false;
        /// <summary>
        /// 可以仓库取回物品
        /// </summary>
        public bool m_boGetback = false;
        public bool m_boBigStorage = false;
        public bool m_boBigGetBack = false;
        public bool m_boUserLevelOrder = false;
        public bool m_boWarrorLevelOrder = false;
        public bool m_boWizardLevelOrder = false;
        public bool m_boTaoistLevelOrder = false;
        public bool m_boMasterCountOrder = false;
        public bool m_boGetNextPage = false;
        public bool m_boGetPreviousPage = false;
        /// <summary>
        /// 英雄相关NPC
        /// </summary>
        public bool m_boHero = false;
        /// <summary>
        /// 酒馆英雄相关NPC 
        /// </summary>
        public bool m_boBuHero = false;
        /// <summary>
        ///  酿酒NPC
        /// </summary>
        public bool m_boPlayMakeWine = false;
        /// <summary>
        /// 玩家向NPC请酒,斗酒 
        /// </summary>
        public bool m_boPlayDrink = false;
        /// <summary>
        /// NPC 元宝寄售属性
        /// </summary>
        public bool m_boYBDeal = false;
        public bool m_boUpgradenow = false;
        public bool m_boGetBackupgnow = false;
        public bool m_boRepair = false;
        public bool m_boS_repair = false;
        public bool m_boSendmsg = false;
        public bool m_boGetMarry = false;
        public bool m_boGetMaster = false;
        public bool m_boUseItemName = false;
        public bool m_boofflinemsg = false;
        public bool m_boDealGold = false;

        /// <summary>
        /// 增加物品价格
        /// </summary>
        /// <param name="nIndex"></param>
        /// <param name="nPrice"></param>
        private unsafe void AddItemPrice(int nIndex, int nPrice)
        {
            TItemPrice* ItemPrice = null;
            try
            {
                ItemPrice = (TItemPrice*)Marshal.AllocHGlobal(sizeof(TItemPrice));
                ItemPrice->wIndex = (ushort)nIndex;
                ItemPrice->nPrice = nPrice;
                m_ItemPriceList.Add((IntPtr)ItemPrice);
                //LocalDB.GetInstance().SaveGoodPriceRecord(this, m_sScript + "-" + this.m_sMapName);
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.AddItemPrice");
            }
        }

        /// <summary>
        /// 检查物品价格
        /// </summary>
        /// <param name="nIndex"></param>
        public unsafe void CheckItemPrice(int nIndex)
        {
            int I;
            TItemPrice* ItemPrice;
            int n10;
            TStdItem* StdItem;
            try
            {
                if (m_ItemPriceList.Count > 0)
                {
                    for (I = 0; I < m_ItemPriceList.Count; I++)
                    {
                        ItemPrice = (TItemPrice*)m_ItemPriceList[I];
                        if (ItemPrice == null)
                        {
                            continue;
                        }
                        if (ItemPrice->wIndex == nIndex)
                        {
                            n10 = ItemPrice->nPrice;
                            if (HUtil32.Round(n10 * 1.1) > n10)
                            {
                                n10 = (int)HUtil32.Round(n10 * 1.1);
                            }
                            else
                            {
                                n10++;
                            }
                            return;
                        }
                    }
                }
                StdItem = UserEngine.GetStdItem(nIndex);
                if (StdItem != null)
                {
                    AddItemPrice(nIndex, (int)HUtil32.Round(StdItem->Price * 1.1)); // 物品价格为DB库的1.1倍
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.CheckItemPrice");
            }
        }

        private unsafe List<IntPtr> GetRefillList(int nIndex)
        {
            List<IntPtr> result = null;
            List<IntPtr> List = null;
            try
            {
                if (nIndex <= 0)
                {
                    return result;
                }
                if (m_GoodsList.Count > 0)
                {
                    for (int I = 0; I < m_GoodsList.Count; I++)
                    {
                        List = m_GoodsList[I];
                        if (List == null)
                        {
                            continue;
                        }
                        if (List.Count > 0)
                        {
                            if (((TUserItem*)(List[0]))->wIndex == nIndex)
                            {
                                result = List;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.GetRefillList");
            }
            return result;
        }

        public unsafe void RefillGoods_RefillItems(ref List<IntPtr> List, string sItemName, int nInt)
        {
            TUserItem* UserItem = null;
            if (List == null)
            {
                List = new List<IntPtr>();
                m_GoodsList.Add(List);
            }
            if (nInt <= 0)
            {
                nInt = 1;
            }
            for (int I = 0; I < nInt; I++)
            {
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (UserEngine.CopyToUserItemFromName(sItemName, UserItem))
                {
                    List.Insert(0, (IntPtr)UserItem);
                }
                else
                {
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                }
            }
        }

        public unsafe void RefillGoods_DelReFillItem(ref List<IntPtr> List, int nInt)
        {
            for (int I = List.Count - 1; I >= 0; I--)
            {
                if (nInt <= 0)
                {
                    break;
                }
                if (List.Count <= 0)
                {
                    break;
                }
                if ((TUserItem*)List[I] != null)
                {
                    Marshal.FreeHGlobal((IntPtr)List[I]);
                }
                List.RemoveAt(I);
                nInt -= 1;
            }
        }

        /// <summary>
        /// 刷新NPC出售物品列表
        /// </summary>
        public unsafe void RefillGoods()
        {
            TGoods Goods = null;
            int nIndex;
            int nRefillCount;
            List<IntPtr> RefillList;
            List<IntPtr> RefillList20 = null;
            bool bo21;
            byte nCode;
            const string sExceptionMsg = "{异常} TMerchant::RefillGoods {0}/{1}:{2} [{3}] Code:{4}";
            nCode = 0;
            try
            {
                if (m_RefillGoodsList.Count > 0)
                {
                    for (int I = 0; I < m_RefillGoodsList.Count; I++)
                    {
                        nCode = 1;
                        Goods = m_RefillGoodsList[I];
                        if (Goods == null)
                        {
                            continue;
                        }
                        if ((HUtil32.GetTickCount() - Goods.dwRefillTick) > Goods.dwRefillTime * 60000) // 60 * 1000
                        {
                            nCode = 2;
                            Goods.dwRefillTick = HUtil32.GetTickCount();
                            nIndex = UserEngine.GetStdItemIdx(Goods.sItemName);
                            nCode = 3;
                            if (nIndex >= 0)
                            {
                                nCode = 4;
                                RefillList = GetRefillList(nIndex);
                                nRefillCount = 0;
                                if (RefillList != null)
                                {
                                    nRefillCount = RefillList.Count;
                                }
                                if (Goods.nCount > nRefillCount)
                                {
                                    nCode = 5;
                                    CheckItemPrice(nIndex);
                                    nCode = 6;
                                    RefillGoods_RefillItems(ref RefillList, Goods.sItemName, Goods.nCount - nRefillCount);
                                    nCode = 7;
                                    //LocalDB.GetInstance().SaveGoodRecord(this, m_sScript + "-" + this.m_sMapName);
                                    //nCode = 8;
                                    //LocalDB.GetInstance().SaveGoodPriceRecord(this, m_sScript + "-" + this.m_sMapName);
                                }
                                nCode = 9;
                                if (Goods.nCount < nRefillCount)
                                {
                                    nCode = 10;
                                    RefillGoods_DelReFillItem(ref RefillList, nRefillCount - Goods.nCount);
                                    nCode = 11;
                                    //LocalDB.GetInstance().SaveGoodRecord(this, m_sScript + "-" + this.m_sMapName);
                                    //nCode = 12;
                                    //LocalDB.GetInstance().SaveGoodPriceRecord(this, m_sScript + "-" + this.m_sMapName);
                                }
                            }
                        }
                    }
                }
                nCode = 13;
                if (m_GoodsList.Count > 0)
                {
                    for (int I = 0; I < m_GoodsList.Count; I++)
                    {
                        nCode = 14;
                        RefillList20 = m_GoodsList[I];
                        if (RefillList20 == null)
                        {
                            continue;
                        }
                        nCode = 15;
                        if (RefillList20.Count > 1000)
                        {
                            bo21 = false;
                            if (m_RefillGoodsList.Count > 0)
                            {
                                nCode = 16;
                                for (int II = 0; II < m_RefillGoodsList.Count; II++)
                                {
                                    nCode = 17;
                                    Goods = m_RefillGoodsList[II];
                                    if (Goods == null)
                                    {
                                        continue;
                                    }
                                    nCode = 18;
                                    nIndex = UserEngine.GetStdItemIdx(Goods.sItemName);
                                    nCode = 19;
                                    if ((TItemPrice*)RefillList20[0] != null)
                                    {
                                        nCode = 20;
                                        if (((TItemPrice*)RefillList20[0])->wIndex == nIndex)
                                        {
                                            bo21 = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!bo21)
                            {
                                nCode = 21;
                                RefillGoods_DelReFillItem(ref RefillList20, RefillList20.Count - 1000);
                            }
                            else
                            {
                                nCode = 22;
                                RefillGoods_DelReFillItem(ref RefillList20, RefillList20.Count - 5000);
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, this.m_sCharName, this.m_nCurrX, this.m_nCurrY, E.Message, nCode));
            }
        }

        /// <summary>
        /// 检查物品类型
        /// </summary>
        /// <param name="nStdMode"></param>
        /// <returns></returns>
        public bool CheckItemType(int nStdMode)
        {
            bool result = false;
            try
            {
                if (m_ItemTypeList.Count > 0)
                {
                    for (int I = 0; I < m_ItemTypeList.Count; I++)
                    {
                        if (((int)m_ItemTypeList[I]) == nStdMode)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.CheckItemType");
            }
            return result;
        }

        /// <summary>
        /// 取物品价格
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public unsafe int GetItemPrice(int nIndex)
        {
            int result = -1;
            TItemPrice* ItemPrice;
            TStdItem* StdItem;
            try
            {
                if (m_ItemPriceList.Count > 0)
                {
                    for (int I = 0; I < m_ItemPriceList.Count; I++)
                    {
                        ItemPrice = (TItemPrice*)m_ItemPriceList[I];
                        if (ItemPrice == null)
                        {
                            continue;
                        }
                        if (ItemPrice->wIndex == nIndex)
                        {
                            result = ItemPrice->nPrice;
                            break;
                        }
                    }
                }
                if (result < 0)
                {
                    StdItem = UserEngine.GetStdItem(nIndex);
                    if (StdItem != null)
                    {
                        if (CheckItemType(StdItem->StdMode))
                        {
                            result = StdItem->Price;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.GetItemPrice");
            }
            return result;
        }

        // 保存升级武器列表
        private void SaveUpgradingList()
        {
            try
            {
                // LocalDB.FrmDB.SaveUpgradeWeaponRecord(m_sScript + "-" + this.m_sMapName, m_UpgradeWeaponList);
            }
            catch
            {
                M2Share.MainOutMessage("保存升级列表失败 - " + this.m_sCharName);
            }
        }

        public unsafe void UpgradeWapon_sub_4A0218(TPlayObject User, ref byte btDc, ref byte btSc, ref byte btMc, ref byte btDura)
        {
            int I;
            int II;
            ArrayList DuraList;
            TUserItem* UserItem;
            TStdItem* StdItem;
            TStdItem* StdItem80;
            TStringList DelItemList;
            int nDc;
            int nSc;
            int nMc;
            int nDcMin;
            int nDcMax;
            int nScMin;
            int nScMax;
            int nMcMin;
            int nMcMax;
            int nDura;
            int nItemCount;
            nDcMin = 0;
            nDcMax = 0;
            nScMin = 0;
            nScMax = 0;
            nMcMin = 0;
            nMcMax = 0;
            nDura = 0;
            nItemCount = 0;
            DelItemList = null;
            DuraList = new ArrayList();
            if (User.m_ItemList.Count > 0)
            {
                for (I = User.m_ItemList.Count - 1; I >= 0; I--)
                {
                    UserItem = (TUserItem*)User.m_ItemList[I];
                    if (UserEngine.GetStdItemName(UserItem->wIndex) == M2Share.g_Config.sBlackStone)
                    {
                        DuraList.Add((HUtil32.Round(UserItem->Dura / 1.0E3) as object));
                        if (DelItemList == null)
                        {
                            DelItemList = new TStringList();
                        }
                        //DelItemList.Add(M2Share.g_Config.sBlackStone, ((UserItem->MakeIndex) as Object));
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        User.m_ItemList.RemoveAt(I);
                    }
                    else
                    {
                        if (M2Share.IsUseItem(UserItem->wIndex))
                        {
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            if (StdItem != null)
                            {
                                StdItem80 = StdItem;
                                ItemUnit.GetItemAddValue(UserItem, StdItem80);
                                nDc = 0;
                                nSc = 0;
                                nMc = 0;
                                switch (StdItem80->StdMode)
                                {
                                    case 19:
                                    case 20:
                                    case 21:
                                        nDc = HUtil32.HiWord(StdItem80->DC) + HUtil32.LoWord(StdItem80->DC);
                                        nSc = HUtil32.HiWord(StdItem80->SC) + HUtil32.LoWord(StdItem80->SC);
                                        nMc = HUtil32.HiWord(StdItem80->MC) + HUtil32.LoWord(StdItem80->MC);
                                        break;
                                    case 22:
                                    case 23:
                                        nDc = HUtil32.HiWord(StdItem80->DC) + HUtil32.LoWord(StdItem80->DC);
                                        nSc = HUtil32.HiWord(StdItem80->SC) + HUtil32.LoWord(StdItem80->SC);
                                        nMc = HUtil32.HiWord(StdItem80->MC) + HUtil32.LoWord(StdItem80->MC);
                                        break;
                                    case 24:
                                    case 26:
                                        nDc = HUtil32.HiWord(StdItem80->DC) + HUtil32.LoWord(StdItem80->DC) + 1;
                                        nSc = HUtil32.HiWord(StdItem80->SC) + HUtil32.LoWord(StdItem80->SC) + 1;
                                        nMc = HUtil32.HiWord(StdItem80->MC) + HUtil32.LoWord(StdItem80->MC) + 1;
                                        break;
                                }
                                if (nDcMin < nDc)
                                {
                                    nDcMax = nDcMin;
                                    nDcMin = nDc;
                                }
                                else
                                {
                                    if (nDcMax < nDc)
                                    {
                                        nDcMax = nDc;
                                    }
                                }
                                if (nScMin < nSc)
                                {
                                    nScMax = nScMin;
                                    nScMin = nSc;
                                }
                                else
                                {
                                    if (nScMax < nSc)
                                    {
                                        nScMax = nSc;
                                    }
                                }
                                if (nMcMin < nMc)
                                {
                                    nMcMax = nMcMin;
                                    nMcMin = nMc;
                                }
                                else
                                {
                                    if (nMcMax < nMc)
                                    {
                                        nMcMax = nMc;
                                    }
                                }
                                if (DelItemList == null)
                                {
                                    DelItemList = new TStringList();
                                }
                                //DelItemList.Add(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), ((UserItem->MakeIndex) as Object));
                                if (StdItem->NeedIdentify == 1)
                                {
                                    M2Share.AddGameDataLog("26" + "\09" + User.m_sMapName + "\09" + (User.m_nCurrX).ToString()
                                    + "\09" + (User.m_nCurrY).ToString() + "\09" + User.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" 
                                        + UserItem->MakeIndex + "\09" + "(" + HUtil32.LoWord(StdItem->DC) + "/" 
                                        + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC) 
                                        + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + HUtil32.LoWord(StdItem->SC) 
                                        + "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" + HUtil32.LoWord(StdItem->AC) 
                                        + "/" + HUtil32.HiWord(StdItem->AC) + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString()
                                        + "/" + HUtil32.HiWord(StdItem->MAC) + ")" + UserItem->btValue[0] 
                                        + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/"
                                        + (UserItem->btValue[3]).ToString() + "/" + (UserItem->btValue[4]).ToString() + "/" 
                                        + UserItem->btValue[5] + "/" + (UserItem->btValue[6]).ToString() + "/" 
                                        + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" 
                                        + (UserItem->btValue[14]).ToString() + "\09" + this.m_sCharName);
                                }
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                User.m_ItemList.RemoveAt(I);
                            }
                        }
                    }
                }
            }
            for (I = 0; I < DuraList.Count; I++)
            {
                if (DuraList.Count <= 0)
                {
                    break;
                }
                for (II = DuraList.Count - 1; II > I; II--)
                {
                    if (((int)DuraList[II]) > ((int)DuraList[II - 1]))
                    {
                        //DuraList.Exchange(II, II - 1);
                    }
                }
            }
            if (DuraList.Count > 0)
            {
                for (I = 0; I < DuraList.Count; I++)
                {
                    nDura = nDura + ((int)DuraList[I]);
                    nItemCount++;
                    if (nItemCount >= 5)
                    {
                        break;
                    }
                }
            }
            btDura = (byte)HUtil32.Round(HUtil32._MIN(5, nItemCount) + HUtil32._MIN(5, nItemCount) * ((nDura / nItemCount) / 5.0));
            btDc = Convert.ToByte(nDcMin / 5 + nDcMax / 3);
            btSc = Convert.ToByte(nScMin / 5 + nScMax / 3);
            btMc = Convert.ToByte(nMcMin / 5 + nMcMax / 3);
            if (DelItemList != null)
            {
                User.SendMsg(this, Grobal2.RM_SENDDELITEMLIST, 0, Parse(DelItemList), 0, 0, "");
            }
            if (DuraList != null)
            {
                Dispose(DuraList);
            }
        }

        /// <summary>
        /// 升级武器
        /// </summary>
        /// <param name="User"></param>
        private unsafe void UpgradeWapon(TPlayObject User)
        {
            bool bo0D;
            TUpgradeInfo* UpgradeInfo;
            TStdItem* StdItem;
            try
            {
                bo0D = false;
                if (m_UpgradeWeaponList.Count > 0)
                {
                    for (int I = 0; I < m_UpgradeWeaponList.Count; I++)
                    {
                        UpgradeInfo = (TUpgradeInfo*)m_UpgradeWeaponList[I];
                        if (HUtil32.SBytePtrToString(UpgradeInfo->sUserName, 0, UpgradeInfo->UserNameLen) == User.m_sCharName)
                        {
                            this.GotoLable(User, FunctionDef.sUPGRADEING, false);
                            return;
                        }
                    }
                }
                if ((User.m_UseItems[TPosition.U_WEAPON]->wIndex != 0) && (User.m_nGold >= M2Share.g_Config.nUpgradeWeaponPrice) && (User.CheckItems(M2Share.g_Config.sBlackStone) != null))
                {
                    User.DecGold(M2Share.g_Config.nUpgradeWeaponPrice);
                    if (m_boCastle || M2Share.g_Config.boGetAllNpcTax)
                    {
                        if (this.m_Castle != null)
                        {
                            this.m_Castle.IncRateGold(M2Share.g_Config.nUpgradeWeaponPrice);
                        }
                        else if (M2Share.g_Config.boGetAllNpcTax)
                        {
                            M2Share.g_CastleManager.IncRateGold(M2Share.g_Config.nUpgradeWeaponPrice);
                        }
                    }
                    User.GoldChanged();
                    UpgradeInfo = (TUpgradeInfo*)Marshal.AllocHGlobal(sizeof(TUpgradeInfo));
                    HUtil32.StrToSByteArry(User.m_sCharName, UpgradeInfo->sUserName, 14, ref UpgradeInfo->UserNameLen);
                    *UpgradeInfo->UserItem = *User.m_UseItems[TPosition.U_WEAPON];
                    StdItem = UserEngine.GetStdItem(User.m_UseItems[TPosition.U_WEAPON]->wIndex);
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("25" + "\09" + User.m_sMapName + "\09" + (User.m_nCurrX).ToString() + "\09" + (User.m_nCurrY).ToString()
                            + "\09" + User.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + (User.m_UseItems[TPosition.U_WEAPON]->MakeIndex).ToString() + "\09"
                            + "(" + HUtil32.LoWord(StdItem->DC) + "/" + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC)
                            + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + HUtil32.LoWord(StdItem->SC) + "/" + HUtil32.HiWord(StdItem->SC) +
                            ")" + "(" + HUtil32.LoWord(StdItem->AC) + "/" + HUtil32.HiWord(StdItem->AC) + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString()
                            + "/" + HUtil32.HiWord(StdItem->MAC) + ")" + (User.m_UseItems[TPosition.U_WEAPON]->btValue[0]).ToString() + "/"
                            + (User.m_UseItems[TPosition.U_WEAPON]->btValue[1]).ToString() + "/" + (User.m_UseItems[TPosition.U_WEAPON]->btValue[2]).ToString() + "/"
                            + (User.m_UseItems[TPosition.U_WEAPON]->btValue[3]).ToString() + "/" + (User.m_UseItems[TPosition.U_WEAPON]->btValue[4]).ToString() + "/"
                            + (User.m_UseItems[TPosition.U_WEAPON]->btValue[5]).ToString() + "/" + (User.m_UseItems[TPosition.U_WEAPON]->btValue[6]).ToString() + "/"
                            + (User.m_UseItems[TPosition.U_WEAPON]->btValue[7]).ToString() + "/" + (User.m_UseItems[TPosition.U_WEAPON]->btValue[8]).ToString() + "/"
                            + (User.m_UseItems[TPosition.U_WEAPON]->btValue[14]).ToString() + "\09" + (User.m_UseItems[TPosition.U_WEAPON]->Dura).ToString() + "/"
                            + (User.m_UseItems[TPosition.U_WEAPON]->DuraMax).ToString());
                    }
                    User.ClearCopyItem(0, User.m_UseItems[TPosition.U_WEAPON]->wIndex, User.m_UseItems[TPosition.U_WEAPON]->MakeIndex); // 清理包裹和仓库复制物品
                    User.SendDelItems(User.m_UseItems[TPosition.U_WEAPON]);
                    User.m_UseItems[TPosition.U_WEAPON]->wIndex = 0;
                    User.RecalcAbilitys();
                    User.CompareSuitItem(false); //套装
                    User.FeatureChanged();
                    User.SendMsg(User, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                    UpgradeWapon_sub_4A0218(User, ref UpgradeInfo->btDc, ref UpgradeInfo->btSc, ref UpgradeInfo->btMc, ref UpgradeInfo->btDura);
                    UpgradeInfo->dtTime = DateTime.Now;
                    UpgradeInfo->dwGetBackTick = (ushort)HUtil32.GetTickCount();
                    m_UpgradeWeaponList.Add((IntPtr)UpgradeInfo);
                    SaveUpgradingList();// 保存武器升级列表
                    bo0D = true;
                }
                if (bo0D)
                {
                    this.GotoLable(User, FunctionDef.sUPGRADEOK, false);
                }
                else
                {
                    this.GotoLable(User, FunctionDef.sUPGRADEFAIL, false);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.UpgradeWapon");
            }
        }

        /// <summary>
        /// 取回升级武器
        /// </summary>
        /// <param name="User"></param>
        private unsafe void GetBackupgWeapon(TPlayObject User)
        {
            TUpgradeInfo* UpgradeInfo;
            int n10;
            int n18;
            int n1C;
            int n90;
            TUserItem* UserItem;
            TStdItem* StdItem;
            try
            {
                n18 = 0;
                UpgradeInfo = null;
                if (!User.IsEnoughBag()) // 背包已经满
                {
                    this.GotoLable(User, FunctionDef.sGETBACKUPGFULL, false);
                    return;
                }
                for (int I = m_UpgradeWeaponList.Count - 1; I >= 0; I--)
                {
                    if (m_UpgradeWeaponList.Count <= 0)
                    {
                        break;
                    }
                    UpgradeInfo = (TUpgradeInfo*)m_UpgradeWeaponList[I];
                    if (HUtil32.SBytePtrToString(UpgradeInfo->sUserName, 0, UpgradeInfo->UserNameLen) == User.m_sCharName)
                    {
                        n18 = 1;
                        if (((HUtil32.GetTickCount() - (UpgradeInfo->dwGetBackTick) > M2Share.g_Config.dwUPgradeWeaponGetBackTime) || (User.m_btPermission >= 4)))
                        {
                            UpgradeInfo = (TUpgradeInfo*)m_UpgradeWeaponList[I];
                            m_UpgradeWeaponList.RemoveAt(I);
                            SaveUpgradingList();// 保存武器升级列表
                            n18 = 2;
                            break;
                        }
                    }
                }
                if ((UpgradeInfo != null) && (n18 == 2))
                {
                    if (HUtil32.rangeInDefined(UpgradeInfo->btDura, 0, 8))
                    {
                        if (UpgradeInfo->UserItem->DuraMax > 3000)
                        {
                            UpgradeInfo->UserItem->DuraMax -= 3000;
                        }
                        else
                        {
                            UpgradeInfo->UserItem->DuraMax = Convert.ToUInt16(UpgradeInfo->UserItem->DuraMax >> 1);
                        }
                        if (UpgradeInfo->UserItem->Dura > UpgradeInfo->UserItem->DuraMax)
                        {
                            UpgradeInfo->UserItem->Dura = UpgradeInfo->UserItem->DuraMax;
                        }
                    }
                    if (HUtil32.rangeInDefined(UpgradeInfo->btDura, 9, 15))
                    {
                        if (HUtil32.Random(UpgradeInfo->btDura) < 6)
                        {
                            if (UpgradeInfo->UserItem->DuraMax > 1000)
                            {
                                UpgradeInfo->UserItem->DuraMax -= 1000;
                            }
                            if (UpgradeInfo->UserItem->Dura > UpgradeInfo->UserItem->DuraMax)
                            {
                                UpgradeInfo->UserItem->Dura = UpgradeInfo->UserItem->DuraMax;
                            }
                        }
                    }
                    if (HUtil32.rangeInDefined(UpgradeInfo->btDura, 18, 255))
                    {
                        if (HUtil32.rangeInDefined(HUtil32.Random(UpgradeInfo->btDura - 18), 1, 4))
                        {
                            UpgradeInfo->UserItem->DuraMax += 1000;
                        }
                        if (HUtil32.rangeInDefined(HUtil32.Random(UpgradeInfo->btDura - 18), 5, 7))
                        {
                            UpgradeInfo->UserItem->DuraMax += 2000;
                        }
                        if (HUtil32.rangeInDefined(HUtil32.Random(UpgradeInfo->btDura - 18), 8, 255))
                        {
                            UpgradeInfo->UserItem->DuraMax += 4000;
                        }
                    }
                    if ((UpgradeInfo->btDc == UpgradeInfo->btMc) && (UpgradeInfo->btMc == UpgradeInfo->btSc))
                    {
                        n1C = HUtil32.Random(3);
                    }
                    else
                    {
                        n1C = -1;
                    }
                    if (((UpgradeInfo->btDc >= UpgradeInfo->btMc) && (UpgradeInfo->btDc >= UpgradeInfo->btSc)) || (n1C == 0))
                    {
                        n90 = HUtil32._MIN(11, UpgradeInfo->btDc);
                        n10 = HUtil32._MIN(85, n90 << 3 - n90 + 10 + UpgradeInfo->UserItem->btValue[3] - UpgradeInfo->UserItem->btValue[4] + User.m_nBodyLuckLevel);
                        if (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponDCRate) < n10)
                        {
                            UpgradeInfo->UserItem->btValue[10] = 10;
                            if ((n10 > 63) && (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponDCTwoPointRate) == 0))
                            {
                                UpgradeInfo->UserItem->btValue[10] = 11;
                            }
                            if ((n10 > 79) && (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponDCThreePointRate) == 0))
                            {
                                UpgradeInfo->UserItem->btValue[10] = 12;
                            }
                        }
                        else
                        {
                            UpgradeInfo->UserItem->btValue[10] = 1; // 等于1武器破碎
                        }
                    }
                    if (((UpgradeInfo->btMc >= UpgradeInfo->btDc) && (UpgradeInfo->btMc >= UpgradeInfo->btSc)) || (n1C == 1))
                    {
                        n90 = HUtil32._MIN(11, UpgradeInfo->btMc);
                        n10 = HUtil32._MIN(85, n90 << 3 - n90 + 10 + UpgradeInfo->UserItem->btValue[3] - UpgradeInfo->UserItem->btValue[4] + User.m_nBodyLuckLevel);
                        if (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponMCRate) < n10)
                        {
                            UpgradeInfo->UserItem->btValue[10] = 20;
                            if ((n10 > 63) && (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponMCTwoPointRate) == 0))
                            {
                                UpgradeInfo->UserItem->btValue[10] = 21;
                            }
                            if ((n10 > 79) && (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponMCThreePointRate) == 0))
                            {
                                UpgradeInfo->UserItem->btValue[10] = 22;
                            }
                        }
                        else
                        {
                            UpgradeInfo->UserItem->btValue[10] = 1; // 等于1武器破碎
                        }
                    }
                    if (((UpgradeInfo->btSc >= UpgradeInfo->btMc) && (UpgradeInfo->btSc >= UpgradeInfo->btDc)) || (n1C == 2))
                    {
                        n90 = HUtil32._MIN(11, UpgradeInfo->btMc);
                        n10 = HUtil32._MIN(85, n90 << 3 - n90 + 10 + UpgradeInfo->UserItem->btValue[3] - UpgradeInfo->UserItem->btValue[4] + User.m_nBodyLuckLevel);
                        if (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponSCRate) < n10)
                        {
                            UpgradeInfo->UserItem->btValue[10] = 30;
                            if ((n10 > 63) && (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponSCTwoPointRate) == 0))
                            {
                                UpgradeInfo->UserItem->btValue[10] = 31;
                            }
                            if ((n10 > 79) && (HUtil32.Random(M2Share.g_Config.nUpgradeWeaponSCThreePointRate) == 0))
                            {
                                UpgradeInfo->UserItem->btValue[10] = 32;
                            }
                        }
                        else
                        {
                            UpgradeInfo->UserItem->btValue[10] = 1;   // 等于1武器破碎
                        }
                    }
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    for (int i = 0; i < 22; i++)
                    {
                        UserItem->btValue[i] = 0;
                    }
                    UserItem = UpgradeInfo->UserItem;
                    UserItem->btValue[9] = Convert.ToByte(HUtil32._MIN(255, UserItem->btValue[9] + 1));  // 累积升级次数
                    Marshal.FreeHGlobal((IntPtr)UpgradeInfo);
                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("24" + "\09" + User.m_sMapName + "\09" + (User.m_nCurrX).ToString() + "\09" + (User.m_nCurrY).ToString() + "\09" + User.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen)
                            + "\09" + UserItem->MakeIndex + "\09" + "(" + HUtil32.LoWord(StdItem->DC) + "/" + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC) 
                            + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + HUtil32.LoWord(StdItem->SC) + "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" + HUtil32.LoWord(StdItem->AC) 
                            + "/" + HUtil32.HiWord(StdItem->AC) + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + HUtil32.HiWord(StdItem->MAC) + ")" + UserItem->btValue[0] 
                            + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString() + "/" + (UserItem->btValue[4]).ToString() 
                            + "/" + UserItem->btValue[5] + "/" + (UserItem->btValue[6]).ToString() + "/" + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() 
                            + "/" + (UserItem->btValue[14]).ToString() + "\09" + (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                    }
                    User.ClearCopyItem(0, UserItem->wIndex, UserItem->MakeIndex); // 清理包裹和仓库复制物品
                    User.AddItemToBag(UserItem);
                    User.SendAddItem(UserItem);
                }
                switch (n18)
                {
                    case 0:
                        this.GotoLable(User, FunctionDef.sGETBACKUPGFAIL, false);
                        break;
                    case 1:
                        this.GotoLable(User, FunctionDef.sGETBACKUPGING, false);
                        break;
                    case 2:
                        this.GotoLable(User, FunctionDef.sGETBACKUPGOK, false);
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.GetBackupgWeapon");
            }
        }

        /// <summary>
        /// 取用户价格
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="nPrice"></param>
        /// <returns></returns>
        public int GetUserPrice(TPlayObject PlayObject, int nPrice)
        {
            int result;
            int n14;
            if (m_boCastle)// 80%
            {
                if ((this.m_Castle != null) && this.m_Castle.IsMasterGuild(PlayObject.m_MyGuild)) // 100
                {
                    n14 = HUtil32._MAX(60, (int)HUtil32.Round((double)m_nPriceRate * (M2Share.g_Config.nCastleMemberPriceRate / 100)));
                    result = (int)HUtil32.Round((double)nPrice / 100 * n14);
                }
                else
                {
                    result = (int)HUtil32.Round((double)nPrice / 100 * m_nPriceRate);
                }
            }
            else
            {
                result = (int)HUtil32.Round((double)nPrice / 100 * m_nPriceRate);
            }
            return result;
        }

        public void UserSelect_SuperRepairItem(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_SENDUSERSREPAIR, 0, Parse(this), 0, 0, "");
        }

        /// <summary>
        /// NPC买物品
        /// </summary>
        /// <param name="User"></param>
        /// <param name="nInt"></param>
        public unsafe void UserSelect_BuyItem(TPlayObject User, int nInt)
        {
            int n10 = 0;
            int nStock;
            int nPrice;
            sbyte nSubMenu;
            string sSENDMSG = "";
            string sName = string.Empty;
            TUserItem* UserItem = null;
            TStdItem* StdItem = null;
            List<IntPtr> GoodList;
            if (m_GoodsList.Count > 0)
            {
                for (int I = 0; I < m_GoodsList.Count; I++)
                {
                    GoodList = GetObject<List<IntPtr>>(Parse(m_GoodsList[I]));
                    if (GoodList == null)
                    {
                        continue;
                    }
                    UserItem = (TUserItem*)GoodList[0];
                    if (UserItem == null)
                    {
                        continue;
                    }
                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem != null)
                    {
                        sName = "";// 取自定义物品名称
                        if (UserItem->btValue[13] == 1)
                        {
                            sName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                        }
                        if (sName == "")
                        {
                            sName = HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen);
                        }
                        nPrice = GetUserPrice(User, GetItemPrice(UserItem->wIndex));
                        if (nPrice <= 0)// 过滤价格为0的物品
                        {
                            continue;
                        }
                        nStock = GoodList.Count;
                        if ((StdItem->StdMode <= 4) || (StdItem->StdMode == 42) || (StdItem->StdMode == 31))
                        {
                            nSubMenu = 0;
                        }
                        else
                        {
                            nSubMenu = 1;
                        }
                        sSENDMSG = sSENDMSG + sName + "/" + nSubMenu + "/" + nPrice + "/" + nStock + "/";
                        n10++;
                    }
                }
            }
            User.SendMsg(this, Grobal2.RM_SENDGOODSLIST, 0, Parse(this), n10, 0, sSENDMSG);
        }

        // 接受歌曲
        public void UserSelect_RemoteMsg(TPlayObject User, string sLabel, string sMsg)
        {
            string sSENDMSG;
            TPlayObject TargetObject;
            sMsg = sMsg.Trim();
            if (sMsg != "")
            {
                TargetObject = UserEngine.GetPlayObject(sMsg);
                if (TargetObject != null)
                {
                    if (TargetObject.m_boRemoteMsg)
                    {
                        sLabel = sLabel.Substring(2 - 1, sLabel.Length - 1);
                        sSENDMSG = "您的好友 " + User.m_sCharName + " 给您发送音乐\\ \\<播放歌曲/" + sLabel + ">\\";
                        this.SendMsgToUser(TargetObject, sSENDMSG);
                    }
                    else
                    {
                        User.SysMsg(sMsg + "您的好友 " + TargetObject.m_sCharName + " 拒绝接受歌曲！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    // '  没有在线！！！'
                    User.SysMsg(sMsg + GameMsgDef.g_sUserNotOnLine, TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
        }

        // 挂机留言
        public void UserSelect_AutoGetExp(TPlayObject User, string sMsg)
        {
            User.m_sAutoSendMsg = sMsg;
        }

        public void UserSelect_DealGold(TPlayObject User, string sMsg)
        {
            TPlayObject PoseHuman;
            int nGameGold = HUtil32.Str_ToInt(sMsg, -1);
            if (User.m_nDealGoldPose != 1)
            {
                this.GotoLable(User, "@dealgoldPlayError", false);
                return;
            }
            User.m_nDealGoldPose = 2;
            if (nGameGold <= 0)
            {
                this.GotoLable(User, "@dealgoldInputFail", false);
            }
            else
            {
                if (User.m_nGameGold >= nGameGold)
                {
                    PoseHuman = ((TPlayObject)(User.GetPoseCreate()));
                    if ((PoseHuman != null) && (((TPlayObject)(PoseHuman.GetPoseCreate())) == User) && (PoseHuman.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        PoseHuman.m_nGameGold += nGameGold;
                        User.m_nGameGold -= nGameGold;
                        PoseHuman.GameGoldChanged();
                        User.GameGoldChanged();
                        if (M2Share.g_boGameLogGameGold)
                        {
                            M2Share.AddGameDataLog(string.Format(GameMsgDef.g_sGameLogMsg1, M2Share.LOG_GAMEGOLD, PoseHuman.m_sMapName, PoseHuman.m_nCurrX,
                                PoseHuman.m_nCurrY, PoseHuman.m_sCharName, M2Share.g_Config.sGameGoldName, PoseHuman.m_nGameGold, "转账" + "(" + (nGameGold).ToString() + ")"
                                , User.m_sCharName));
                        }
                        this.SendMsgToUser(User, "转帐成功：" + '\n' + "转出" + M2Share.g_Config.sGameGoldName + "：" + (nGameGold).ToString() + "\09" + "当前" + M2Share.g_Config.sGameGoldName + "：" + (User.m_nGameGold).ToString());
                        this.SendMsgToUser(PoseHuman, "转帐成功：" + '\n' + "增加" + M2Share.g_Config.sGameGoldName + "：" + (nGameGold).ToString() + "\09" + "当前" + M2Share.g_Config.sGameGoldName + "：" + (PoseHuman.m_nGameGold).ToString());
                    }
                    else
                    {
                        this.GotoLable(User, "@dealgoldpost", false);
                    }
                }
                else
                {
                    this.GotoLable(User, "@dealgoldFail", false);
                }
            }
        }

        public void UserSelect_SellItem(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_SENDUSERSELL, 0, Parse(this), 0, 0, "");
        }

        public void UserSelect_SellSellItem(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_SENDUSERSELLOFFITEM, 0, Parse(this), 0, 0, "");
        }

        public void UserSelect_RepairItem(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_SENDUSERREPAIR, 0, Parse(this), 0, 0, "");
        }

        public unsafe void UserSelect_MakeDurg(TPlayObject User)
        {
            List<IntPtr> List14 = null;
            TUserItem* UserItem = null;
            TStdItem* StdItem = null;
            string sSENDMSG = "";
            if (m_GoodsList.Count > 0)
            {
                for (int I = 0; I < m_GoodsList.Count; I++)
                {
                    List14 = (List<IntPtr>)m_GoodsList[I];
                    if (List14.Count <= 0)
                    {
                        continue;// 增加，防止在制药物品列表为空时出错
                    }
                    UserItem = (TUserItem*)List14[0];
                    if (UserItem == null)
                    {
                        continue;
                    }
                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem != null)
                    {
                        sSENDMSG = sSENDMSG + StdItem->ToString() + "/" + 0
                            + "/" + M2Share.g_Config.nMakeDurgPrice + "/" + 1 + "/";
                    }
                }
            }
            if (sSENDMSG != "")
            {
                User.SendMsg(this, Grobal2.RM_USERMAKEDRUGITEMLIST, 0, Parse(this), 0, 0, sSENDMSG);
            }
        }

        public void UserSelect_ItemPrices(TPlayObject User)
        {
        }

        public void UserSelect_Storage(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_USERSTORAGEITEM, 0, Parse(this), 0, 0, "");
        }

        public void UserSelect_GetBack(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_USERGETBACKITEM, 0, Parse(this), 0, 0, "");
        }

        public void UserSelect_BigStorage(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_USERSTORAGEITEM, 0, Parse(this), 0, 0, "");
        }

        public void UserSelect_BigGetBack(TPlayObject User)
        {
            User.m_nBigStoragePage = 0;
            User.SendMsg(this, Grobal2.RM_USERBIGGETBACKITEM, User.m_nBigStoragePage, Parse(this), 0, 0, "");
        }

        public void UserSelect_GetPreviousPage(TPlayObject User)
        {
            if (User.m_nBigStoragePage > 0)
            {
                User.m_nBigStoragePage -= 1;
            }
            else
            {
                User.m_nBigStoragePage = 0;
            }
            User.SendMsg(this, Grobal2.RM_USERBIGGETBACKITEM, User.m_nBigStoragePage, Parse(this), 0, 0, "");
        }

        public void UserSelect_GetNextPage(TPlayObject User)
        {
            User.m_nBigStoragePage++;
            User.SendMsg(this, Grobal2.RM_USERBIGGETBACKITEM, User.m_nBigStoragePage, Parse(this), 0, 0, "");
        }

        public void UserSelect_UserLevelOrder(TPlayObject User)
        {
            User.m_nSelPlayOrderType = 0;
            User.m_nPlayOrderPage = 0;
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        public void UserSelect_WarrorLevelOrder(TPlayObject User)
        {
            User.m_nSelPlayOrderType = 1;
            User.m_nPlayOrderPage = 0;
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        public void UserSelect_WizardLevelOrder(TPlayObject User)
        {
            User.m_nSelPlayOrderType = 2;
            User.m_nPlayOrderPage = 0;
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        public void UserSelect_TaoistLevelOrder(TPlayObject User)
        {
            User.m_nSelPlayOrderType = 3;
            User.m_nPlayOrderPage = 0;
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        public void UserSelect_MasterCountOrder(TPlayObject User)
        {
            User.m_nSelPlayOrderType = 4;
            User.m_nPlayOrderPage = 0;
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        public void UserSelect_LevelOrderHomePage(TPlayObject User)
        {
            User.m_nPlayOrderPage = 0;
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        public void UserSelect_LevelOrderPreviousPage(TPlayObject User)
        {
            if (User.m_nPlayOrderPage > 0)
            {
                User.m_nPlayOrderPage -= 1;
            }
            else
            {
                User.m_nPlayOrderPage = 0;
            }
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        public void UserSelect_LevelOrderNextPage(TPlayObject User)
        {
            TStringList PlayObjectList = M2Share.GetPlayObjectOrderList(User.m_nSelPlayOrderType);
            if (PlayObjectList != null)
            {
                if (M2Share.GetPageCount(PlayObjectList.Count) > User.m_nPlayOrderPage)
                {
                    User.m_nPlayOrderPage++;
                }
                User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
            }
        }

        public void UserSelect_LevelOrderLastPage(TPlayObject User)
        {
            TStringList PlayObjectList = M2Share.GetPlayObjectOrderList(User.m_nSelPlayOrderType);
            if (PlayObjectList != null)
            {
                User.m_nPlayOrderPage = M2Share.GetPageCount(PlayObjectList.Count);
                User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
            }
        }

        public void UserSelect_MyLevelOrder(TPlayObject User)
        {
            User.m_boGetMyLevelOrder = true;
            User.SendDelayMsg(this, Grobal2.RM_USERLEVELORDER, 0, 0, 0, 0, "", 100);
        }

        /// <summary>
        /// 创建英雄(白日门)
        /// </summary>
        /// <param name="User"></param>
        /// <param name="sLabel"></param>
        /// <param name="sMsg"></param>
        public void UserSelect_MakeHeroName(TPlayObject User, string sLabel, string sMsg)
        {
            string sGotoLabel;
            if (User.m_boWaitHeroDate)
            {
                return;
            }
            if ((User.m_boHasHero) || (User.m_sHeroCharName != ""))
            {
                this.GotoLable(User, "@HaveHero", false);
            }
            else
            {
                if ((sMsg.Length > 0) && (sMsg.Length < 15))
                {
                    if (!M2Share.IsFilterMsg(ref sMsg))// 文字过滤
                    {
                        User.m_sTempHeroCharName = "";
                        this.GotoLable(User, "@HeroNameFilter", false);
                        return;
                    }
                    User.m_sTempHeroCharName = sMsg.Trim();
                    sGotoLabel = sLabel.Substring(2 - 1, sLabel.Length - 1);
                    this.GotoLable(User, sGotoLabel, false);// 跳转到创建英雄标签
                }
                else
                {
                    User.m_sHeroCharName = "";
                    this.GotoLable(User, "@HeroNameFilter", false);
                }
            }
        }

        /// <summary>
        /// 创建英雄（卧龙）
        /// </summary>
        /// <param name="User"></param>
        /// <param name="sLabel"></param>
        /// <param name="sMsg"></param>
        public void UserSelect_MakeBuHeroName(TPlayObject User, string sLabel, string sMsg)
        {
            string sGotoLabel;
            if (User.m_boWaitHeroDate)
            {
                return;
            }
            if ((User.m_boHasHeroTwo) || (User.m_sHeroCharName != ""))
            {
                this.GotoLable(User, "@HaveHero", false);
            }
            else
            {
                if ((sMsg.Length > 0) && (sMsg.Length < 15))
                {
                    if (!M2Share.IsFilterMsg(ref sMsg)) // 文字过滤
                    {
                        User.m_sTempHeroCharName = "";
                        this.GotoLable(User, "@HeroNameFilter", false);
                        return;
                    }
                    User.m_sTempHeroCharName = sMsg;
                    sGotoLabel = sLabel;
                    this.GotoLable(User, sGotoLabel, false);// 跳转到创建英雄标签
                }
                else
                {
                    User.m_sHeroCharName = "";
                    this.GotoLable(User, "@HeroNameFilter", false);
                }
            }
        }
        
        /// <summary>
        /// 请酒,斗酒
        /// </summary>
        /// <param name="User"></param>
        public void UserSelect_PlayDrink(TPlayObject User)
        {
            User.SendMsg(this, Grobal2.RM_SENDUSERPLAYDRINK, 0, Parse(this), 0, 0, "");
        }

        /// <summary>
        /// 打开出售物品窗口
        /// </summary>
        /// <param name="User"></param>
        public void UserSelect_OpenDealOffForm(TPlayObject User)
        {
            if (User.bo_YBDEAL)
            {
                if (!User.SellOffInTime(0))
                {
                    User.SendMsg(this, Grobal2.RM_SENDDEALOFFFORM, 0, Parse(this), 0, 0, "");
                    User.GetBackSellOffItems();
                }
                else
                {
                    User.SendMsg(this, Grobal2.RM_MERCHANTSAY, 0, 0, 0, 0, this.m_sCharName + "/您还有元宝服务正在进行！！\\ \\<返回/@main>");
                }
            }
            else
            {
                User.SendMsg(this, Grobal2.RM_MERCHANTSAY, 0, 0, 0, 0, this.m_sCharName + "/您未开通元宝服务,请先开通元宝服务！！\\ \\<返回/@main>");
            }
        }

        public void UserSelect_PlugOfPlayObjectUserSelect(TPlayObject PlayObject, string pszLabel, string pszData)
        {
            string sLabel;
            string sData;
            int nData;
            int nData1;
            int nLength;
            try
            {
                if (HUtil32.CompareLStr(pszLabel, "@@InPutString", 13))
                {
                    nLength = (pszLabel).ToLower().CompareTo(("@@InPutString").ToLower());
                    if (nLength > 0)
                    {
                        sLabel = pszLabel.Substring("@@InPutString".Length + 1 - 1, nLength);
                        sData = pszData;
                        if (M2Share.IsFilterMsg(ref sData))// 过滤信息
                        {
                            nData = HUtil32.Str_ToInt(sLabel, 0);
                            if ((nData > 99) || (nData < 0))
                            {
                                nData = 0;
                            }
                            PlayObject.m_sString[nData] = sData;
                            this.GotoLable(PlayObject, "@InPutString" + (nData).ToString(), false);
                        }
                        else
                        {
                            this.GotoLable(PlayObject, "@MsgFilter", false);
                        }
                        return;
                    }
                }
                else if (HUtil32.CompareLStr(pszLabel, "@@InPutInteger", 14))
                {
                    nLength = (pszLabel).ToLower().CompareTo(("@@InPutInteger").ToLower());
                    if (nLength > 0)
                    {
                        sLabel = pszLabel.Substring("@@InPutInteger".Length + 1 - 1, nLength);
                        nData = HUtil32.Str_ToInt(pszData, -1);
                        nData1 = HUtil32.Str_ToInt(sLabel, 0);
                        if ((nData1 > 99) || (nData1 < 0))
                        {
                            nData1 = 0;
                        }
                        PlayObject.m_nInteger[nData1] = nData;
                        this.GotoLable(PlayObject, "@InPutInteger" + sLabel, false);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} PlugOfPlayObjectUserSelect");
            }
        }

        public override void UserSelect(TPlayObject PlayObject, string sData)
        {
            string sLabel = string.Empty;
            string s18;
            string sMsg;
            bool boCanJmp;
            string sChangeUseItemName;
            int nCode;
            const string sExceptionMsg = "{异常} TMerchant::UserSelect... Data: %s Code:%d";
            base.UserSelect(PlayObject, sData);
            if (this.GetType().Name != "TMerchant")// 如果类名不是 TMerchant 则不执行以下处理函数
            {
                return;
            }
            nCode = 39;
            try
            {
                if (!m_boCastle || !((this.m_Castle != null) && m_Castle.m_boUnderWar) && (PlayObject != null))
                {
                    nCode = 40;
                    if (!PlayObject.m_boDeath && (sData != "") && (sData[0] == '@'))
                    {
                        nCode = 41;
                        sMsg = HUtil32.GetValidStr3(sData, ref sLabel, new string[] { "\r" });
                        s18 = "";
                        PlayObject.m_sScriptLable = sData;
                        nCode = 42;
                        boCanJmp = PlayObject.LableIsCanJmp(sLabel);
                        nCode = 43;
                        if ((sLabel).ToLower().CompareTo((FunctionDef.sSL_SENDMSG).ToLower()) == 0)
                        {
                            nCode = 1;
                            if (sMsg == "")
                            {
                                return;
                            }
                        }
                        if (HUtil32.CompareLStr(sLabel, FunctionDef.sUSEITEMNAME, 13)) // 检测装备
                        {
                            nCode = 2;
                            if (sMsg != "")
                            {
                                if (M2Share.g_Config.boChangeUseItemNameByPlayName)
                                {
                                    sChangeUseItemName = PlayObject.m_sCharName + "的" + sMsg;
                                }
                                else
                                {
                                    sChangeUseItemName = M2Share.g_Config.sChangeUseItemName + sMsg;
                                }
                                if (sChangeUseItemName.Length > 14)
                                {
                                    this.SendMsgToUser(PlayObject, "[失败] 名称太长！！！");
                                    return;
                                }
                            }
                        }
                        nCode = 44;
                        if (PlayObject == null)
                        {
                            return;
                        }
                        nCode = 47;
                        if (PlayObject.m_boGhost)
                        {
                            return;
                        }
                        nCode = 45;
                        this.GotoLable(PlayObject, sLabel, !boCanJmp);
                        nCode = 46;
                        if (!boCanJmp)
                        {
                            return;
                        }
                        s18 = HUtil32.mSubString(s18, 0, FunctionDef.sRMST.Length);
                        if ((sLabel).ToLower().CompareTo((FunctionDef.sSL_SENDMSG).ToLower()) == 0)
                        {
                            nCode = 3;
                            if (m_boSendmsg)
                            {
                                SendCustemMsg(PlayObject, sMsg);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sSUPERREPAIR).ToLower()) == 0)
                        {
                            nCode = 4;
                            if (m_boS_repair)
                            {
                                UserSelect_SuperRepairItem(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sBUY).ToLower()) == 0)
                        {
                            nCode = 5;
                            if (m_boBuy)
                            {
                                UserSelect_BuyItem(PlayObject, 0);
                            }
                        }
                        else if ((s18).ToLower().CompareTo((FunctionDef.sRMST).ToLower()) == 0)
                        {
                            // 接受歌曲
                            nCode = 6;
                            if (m_boofflinemsg)
                            {
                                UserSelect_RemoteMsg(PlayObject, sLabel, sMsg);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sofflinemsg).ToLower()) == 0)
                        {
                            // 离线挂机
                            nCode = 7;
                            if (m_boofflinemsg)
                            {
                                UserSelect_AutoGetExp(PlayObject, sMsg);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sdealgold).ToLower()) == 0)
                        {
                            nCode = 8;
                            if (m_boDealGold)
                            {
                                UserSelect_DealGold(PlayObject, sMsg);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sSELL).ToLower()) == 0) // 玩家向NPC卖物品
                        {
                            nCode = 9;
                            if (m_boSell)
                            {
                                UserSelect_SellItem(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sREPAIR).ToLower()) == 0)
                        {
                            nCode = 10;
                            if (m_boRepair)
                            {
                                UserSelect_RepairItem(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sMAKEDURG).ToLower()) == 0)
                        {
                            nCode = 11;
                            if (m_boMakeDrug)
                            {
                                UserSelect_MakeDurg(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sPRICES).ToLower()) == 0)
                        {
                            nCode = 12;
                            if (m_boPrices)
                            {
                                UserSelect_ItemPrices(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sSTORAGE).ToLower()) == 0)
                        {
                            nCode = 13;
                            if (m_boStorage)
                            {
                                UserSelect_Storage(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sGETBACK).ToLower()) == 0)
                        {
                            nCode = 14;
                            if (m_boGetback)
                            {
                                UserSelect_GetBack(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sBIGSTORAGE).ToLower()) == 0)
                        {
                            nCode = 15;
                            if (m_boBigStorage)
                            {
                                UserSelect_BigStorage(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sBIGGETBACK).ToLower()) == 0)
                        {
                            nCode = 16;
                            if (m_boBigGetBack)
                            {
                                UserSelect_BigGetBack(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sGETPREVIOUSPAGE).ToLower()) == 0)
                        {
                            nCode = 17;
                            if (m_boBigGetBack)
                            {
                                UserSelect_GetPreviousPage(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sGETNEXTPAGE).ToLower()) == 0)
                        {
                            nCode = 18;
                            if (m_boBigGetBack)
                            {
                                UserSelect_GetNextPage(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sUserLevelOrder).ToLower()) == 0)
                        {
                            nCode = 19;
                            if (m_boUserLevelOrder)
                            {
                                UserSelect_UserLevelOrder(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sWarrorLevelOrder).ToLower()) == 0)
                        {
                            nCode = 20;
                            if (m_boWarrorLevelOrder)
                            {
                                UserSelect_WarrorLevelOrder(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sWizardLevelOrder).ToLower()) == 0)
                        {
                            nCode = 21;
                            if (m_boWizardLevelOrder)
                            {
                                UserSelect_WizardLevelOrder(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sTaoistLevelOrder).ToLower()) == 0)
                        {
                            nCode = 22;
                            if (m_boTaoistLevelOrder)
                            {
                                UserSelect_TaoistLevelOrder(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sMasterCountOrder).ToLower()) == 0)
                        {
                            nCode = 23;
                            if (m_boMasterCountOrder)
                            {
                                UserSelect_MasterCountOrder(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sLevelOrderHomePage).ToLower()) == 0)
                        {
                            nCode = 24;
                            UserSelect_LevelOrderHomePage(PlayObject);
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sLevelOrderPreviousPage).ToLower()) == 0)
                        {
                            nCode = 25;
                            UserSelect_LevelOrderPreviousPage(PlayObject);
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sLevelOrderNextPage).ToLower()) == 0)
                        {
                            nCode = 26;
                            UserSelect_LevelOrderNextPage(PlayObject);
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sLevelOrderLastPage).ToLower()) == 0)
                        {
                            nCode = 27;
                            UserSelect_LevelOrderLastPage(PlayObject);
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sMyLevelOrder).ToLower()) == 0)
                        {
                            nCode = 28;
                            UserSelect_MyLevelOrder(PlayObject);
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sDealYBme).ToLower()) == 0)// 元宝寄售:出售物品
                        {
                            nCode = 29;
                            if (m_boYBDeal)
                            {
                                UserSelect_OpenDealOffForm(PlayObject); // 打开出售物品窗口
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sLyCreateHero).ToLower()) == 0)
                        {
                            nCode = 30;
                            if (m_boHero)
                            {
                                UserSelect_MakeHeroName(PlayObject, sLabel, sMsg);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sBuHero).ToLower()) == 0)
                        {
                            // 酒馆英雄NPC
                            nCode = 39;
                            if (m_boBuHero)
                            {
                                UserSelect_MakeBuHeroName(PlayObject, sLabel, sMsg);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sPlayDrink).ToLower()) == 0)
                        {
                            // 玩家向NPC请酒,斗酒
                            nCode = 40;
                            if (m_boPlayDrink)
                            {
                                UserSelect_PlayDrink(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sUPGRADENOW).ToLower()) == 0)
                        {
                            nCode = 31;
                            if (m_boUpgradenow)
                            {
                                UpgradeWapon(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sGETBACKUPGNOW).ToLower()) == 0)
                        {
                            nCode = 32;
                            if (m_boGetBackupgnow)
                            {
                                GetBackupgWeapon(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sGETMARRY).ToLower()) == 0)
                        {
                            nCode = 33;
                            if (m_boGetMarry)
                            {
                                GetBackupgWeapon(PlayObject);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sGETMASTER).ToLower()) == 0)
                        {
                            nCode = 34;
                            if (m_boGetMaster)
                            {
                                GetBackupgWeapon(PlayObject);
                            }
                        }
                        else if (HUtil32.CompareLStr(sLabel, FunctionDef.sUSEITEMNAME, 13))
                        {
                            nCode = 35;
                            if (m_boUseItemName)
                            {
                                ChangeUseItemName(PlayObject, sLabel, sMsg);
                            }
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sEXIT).ToLower()) == 0)
                        {
                            nCode = 36;
                            PlayObject.SendMsg(this, Grobal2.RM_MERCHANTDLGCLOSE, 0, Parse(this), 0, 0, "");
                        }
                        else if ((sLabel).ToLower().CompareTo((FunctionDef.sBACK).ToLower()) == 0)
                        {
                            nCode = 37;
                            if (PlayObject.m_sScriptGoBackLable == "")
                            {
                                PlayObject.m_sScriptGoBackLable = FunctionDef.sMAIN;
                            }
                            this.GotoLable(PlayObject, PlayObject.m_sScriptGoBackLable, false);
                        }
                        else
                        {
                            nCode = 38;
                            UserSelect_PlugOfPlayObjectUserSelect(PlayObject, sLabel, sMsg);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, sData, nCode));
            }
        }

        public override void Run()
        {
            int nCheckCode = 0;
            const string sExceptionMsg1 = "{异常} TMerchant::Run... Code = {0}";
            const string sExceptionMsg2 = "{异常} TMerchant::Run -> Move Code = {1}";
            try
            {
                if ((HUtil32.GetTickCount() - dwRefillGoodsTick) > 30000)
                {
                    dwRefillGoodsTick = HUtil32.GetTickCount();
                    RefillGoods();// 刷新NPC出售物品列表
                }
                nCheckCode = 1;
                if ((HUtil32.GetTickCount() - dwClearExpreUpgradeTick) > 600000)  // 10 * 60 * 1000
                {
                    dwClearExpreUpgradeTick = HUtil32.GetTickCount();
                    ClearExpreUpgradeListData();
                }
                nCheckCode = 2;
                if (HUtil32.Random(50) == 0)
                {
                    this.TurnTo(HUtil32.Random(8));
                }
                else
                {
                    if (HUtil32.Random(50) == 0)
                    {
                        this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                    }
                }
                nCheckCode = 3;
                if (m_boCastle && (this.m_Castle != null) && this.m_Castle.m_boUnderWar)
                {
                    if (!this.m_boFixedHideMode)
                    {
                        this.SendRefMsg(Grobal2.RM_DISAPPEAR, 0, 0, 0, 0, "");
                        this.m_boFixedHideMode = true;
                    }
                }
                else
                {
                    if (this.m_boFixedHideMode)
                    {
                        this.m_boFixedHideMode = false;
                        this.SendRefMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY, 0, "");
                    }
                }
                nCheckCode = 4;
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg1, nCheckCode));
            }
            try
            {
                if (m_boCanMove && (HUtil32.GetTickCount() - m_dwMoveTick > m_dwMoveTime * 1000))// NPC移动
                {
                    m_dwMoveTick = HUtil32.GetTickCount();
                    this.SendRefMsg(Grobal2.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
                    this.MapRandomMove(this.m_sMapName, 0);
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg2, nCheckCode));
            }
            base.Run();
        }

        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            return base.Operate(ProcessMsg);
        }

        public void LoadNPCData()
        {
            string sFile;
            try
            {
                sFile = m_sScript + "-" + this.m_sMapName;
                LoadUpgradeList();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.LoadNPCData");
            }
        }

        public void SaveNPCData()
        {
            string sFile;
            try
            {
                sFile = m_sScript + "-" + this.m_sMapName;
                //LocalDB.GetInstance().SaveGoodRecord(this, sFile);
                //LocalDB.GetInstance().SaveGoodPriceRecord(this, sFile);
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.SaveNPCData");
            }
        }

        public TMerchant()
            : base()
        {
            this.m_btRaceImg = Grobal2.RCC_MERCHANT;// 角色外观
            this.m_wAppr = 0;
            m_nPriceRate = 100;
            m_boCastle = false;
            m_ItemTypeList = new ArrayList();
            m_RefillGoodsList = new List<TGoods>();
            m_GoodsList = new List<List<IntPtr>>();
            m_ItemPriceList = new List<IntPtr>();
            m_UpgradeWeaponList = new List<IntPtr>();
            dwRefillGoodsTick = HUtil32.GetTickCount();
            dwClearExpreUpgradeTick = HUtil32.GetTickCount();
            m_boBuy = false;
            m_boSell = false;
            m_boMakeDrug = false;
            m_boPrices = false;
            m_boStorage = false;
            m_boGetback = false;
            m_boBigStorage = false;
            m_boBigGetBack = false;
            m_boGetNextPage = false;
            m_boGetPreviousPage = false;
            m_boHero = false;
            m_boBuHero = false;
            m_boPlayMakeWine = false;// 酿酒NPC
            m_boUserLevelOrder = false;
            m_boWarrorLevelOrder = false;
            m_boWizardLevelOrder = false;
            m_boTaoistLevelOrder = false;
            m_boMasterCountOrder = false;
            m_boUpgradenow = false;
            m_boGetBackupgnow = false;
            m_boRepair = false;
            m_boS_repair = false;
            m_boGetMarry = false;
            m_boGetMaster = false;
            m_boUseItemName = false;
            m_boofflinemsg = false;
            m_boDealGold = false;
            m_dwMoveTick = HUtil32.GetTickCount();
        }

        unsafe ~TMerchant()
        {
            int I;
            int II;
            List<IntPtr> List = null;
            byte nCode;
            nCode = 0;
            try
            {
                nCode = 1;
                Dispose(m_ItemTypeList);
                nCode = 2;
                if (m_RefillGoodsList.Count > 0)
                {
                    for (I = 0; I < m_RefillGoodsList.Count; I++)
                    {
                        if (m_RefillGoodsList[I] != null)
                        {
                            Dispose(m_RefillGoodsList[I]);
                        }
                    }
                }
                Dispose(m_RefillGoodsList);
                nCode = 3;
                if (m_GoodsList.Count > 0)
                {
                    for (I = 0; I < m_GoodsList.Count; I++)
                    {
                        List = m_GoodsList[I];
                        if (List.Count > 0)
                        {
                            for (II = 0; II < List.Count; II++)
                            {
                                if (((TUserItem*)(List[II])) != null)
                                {
                                    Dispose(List[II]);
                                }
                            }
                        }
                        Dispose(List);
                    }
                }
                Dispose(m_GoodsList);
                nCode = 4;
                if (m_ItemPriceList.Count > 0)
                {
                    for (I = 0; I < m_ItemPriceList.Count; I++)
                    {
                        if (m_ItemPriceList[I] != null)
                        {
                            Dispose(m_ItemPriceList[I]);
                        }
                    }
                }
                Dispose(m_ItemPriceList);
                nCode = 5;
                if (m_UpgradeWeaponList.Count > 0)
                {
                    for (I = 0; I < m_UpgradeWeaponList.Count; I++)
                    {
                        if (m_UpgradeWeaponList[I] != null)
                        {
                            Dispose(m_UpgradeWeaponList[I]);
                        }
                    }
                }
                Dispose(m_UpgradeWeaponList);
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.Destroy Code:" + (nCode).ToString());
            }
        }

        private unsafe void ClearExpreUpgradeListData()
        {
            TUpgradeInfo* UpgradeInfo;
            try
            {
                for (int I = m_UpgradeWeaponList.Count - 1; I >= 0; I--)
                {
                    if (m_UpgradeWeaponList.Count <= 0)
                    {
                        break;
                    }
                    UpgradeInfo = (TUpgradeInfo*)m_UpgradeWeaponList[I];
                    if (UpgradeInfo == null)
                    {
                        continue;
                    }
                    //if (((int)HUtil32.Round(DateTime.Now - UpgradeInfo.dtTime.ToOADate())) >= M2Share.g_Config.nClearExpireUpgradeWeaponDays)
                    //{
                    //    Dispose(UpgradeInfo);
                    //    m_UpgradeWeaponList.RemoveAt(I);
                    //}
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClearExpreUpgradeListData");
            }
        }

        /// <summary>
        /// 加载交易NPC脚本
        /// </summary>
        new public void LoadNpcScript()
        {
            string SC;
            try
            {
                m_ItemTypeList.Clear();
                this.m_sPath = M2Share.sMarket_Def;
                SC = m_sScript + "-" + this.m_sMapName;
                M2Share.ScriptEngine.LoadScriptFile(this, M2Share.sMarket_Def, SC, true);
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.LoadNpcScript");
            }
        }

        public override void Click(TPlayObject PlayObject)
        {
            try
            {
                if ((!this.m_boGhost))
                {
                    if (PlayObject != null)
                    {
                        if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            base.Click(PlayObject);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.Click");
            }
        }

        public unsafe override void GetVariableText(TPlayObject PlayObject, ref string sMsg, string sVariable)
        {
            string sText;
            base.GetVariableText(PlayObject, ref sMsg, sVariable);
            try
            {
                if (sVariable == "$PRICERATE")
                {
                    sText = (m_nPriceRate).ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$PRICERATE>", sText);
                }
                if (sVariable == "$UPGRADEWEAPONFEE")
                {
                    sText = (M2Share.g_Config.nUpgradeWeaponPrice).ToString();
                    sMsg = this.sub_49ADB8(sMsg, "<$UPGRADEWEAPONFEE>", sText);
                }
                if (sVariable == "$USERWEAPON")
                {
                    if (PlayObject.m_UseItems[TPosition.U_WEAPON]->wIndex != 0)
                    {
                        sText = UserEngine.GetStdItemName(PlayObject.m_UseItems[TPosition.U_WEAPON]->wIndex);
                    }
                    else
                    {
                        sText = "无";
                    }
                    sMsg = this.sub_49ADB8(sMsg, "<$USERWEAPON>", sText);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.GetVariableText");
            }
        }

        /// <summary>
        /// 取使用物品的价格
        /// </summary>
        /// <param name="UserItem"></param>
        /// <returns></returns>
        public unsafe int GetUserItemPrice(TUserItem* UserItem)
        {
            int result = 0;
            int n10;
            TStdItem* StdItem;
            double n20;
            int nC;
            int n14;
            try
            {
                n10 = GetItemPrice(UserItem->wIndex);
                if (n10 > 0)
                {
                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                    if ((StdItem != null))
                    {
                        if ((StdItem->StdMode > 4) && (StdItem->DuraMax > 0) && (UserItem->DuraMax > 0))
                        {
                            if (StdItem->StdMode == 40)// 肉
                            {
                                if (UserItem->Dura <= UserItem->DuraMax)
                                {
                                    n20 = (n10 / 2.0 / UserItem->DuraMax * (UserItem->DuraMax - UserItem->Dura));
                                     n10 = HUtil32._MAX(2, (int)HUtil32.Round(n10 - n20));
                                }
                                else
                                {
                                     n10 = n10 + (int)HUtil32.Round((double)n10 / UserItem->DuraMax * 2.0 * (UserItem->DuraMax - UserItem->Dura));
                                }
                            }
                            if ((StdItem->StdMode == 43))  // 矿石
                            {
                                if (UserItem->DuraMax < 10000)
                                {
                                    UserItem->DuraMax = 10000; // 修改，修正当前持久大于最大持久时，价格比小纯度的矿石还低
                                }
                                n20 = (n10 / 2.0 / UserItem->DuraMax * (UserItem->DuraMax - UserItem->Dura));
                                n10 = HUtil32._MAX(2, (int)HUtil32.Round(n10 - n20));
                            }
                            if (StdItem->StdMode > 4)
                            {
                                n14 = 0;
                                nC = 0;
                                while (true)
                                {
                                    if ((StdItem->StdMode == 5) || (StdItem->StdMode == 6))
                                    {
                                        if ((nC != 4) || (nC != 9))
                                        {
                                            if (nC == 6)
                                            {
                                                if (UserItem->btValue[nC] > 10)
                                                {
                                                    n14 = n14 + (UserItem->btValue[nC] - 10) * 2;
                                                }
                                            }
                                            else
                                            {
                                                n14 = n14 + UserItem->btValue[nC];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        n14 += UserItem->btValue[nC];
                                    }
                                    nC++;
                                    if (nC >= 8)
                                    {
                                        break;
                                    }
                                }
                                if (n14 > 0)
                                {
                                    n10 = n10 / 5 * n14;
                                }
                                n10 = (int)HUtil32.Round((double)n10 / StdItem->DuraMax * UserItem->DuraMax);
                                n20 = (n10 / 2.0 / UserItem->DuraMax * (UserItem->DuraMax - UserItem->Dura));
                                n10 = HUtil32._MAX(2, (int)HUtil32.Round(n10 - n20));
                            }
                        }
                    }
                }
                result = n10;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.GetUserItemPrice");
            }
            return result;
        }

        /// <summary>
        /// 客户端购买物品
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sItemName"></param>
        /// <param name="nInt"></param>
        public unsafe void ClientBuyItem(TPlayObject PlayObject, string sItemName, int nInt)
        {
            bool bo29;
            IList<IntPtr> m_GoogList = null;
            TUserItem* UserItem;
            TStdItem* StdItem;
            int n1C;
            int nPrice;
            string sUserItemName;
            try
            {
                bo29 = false;
                n1C = 1;
                if (m_GoodsList.Count > 0)
                {
                    for (int I = 0; I < m_GoodsList.Count; I++)
                    {
                        if (bo29)
                        {
                            break;
                        }
                        m_GoogList = GetObject<List<IntPtr>>(Parse(m_GoodsList[I]));
                        if (m_GoogList == null)
                        {
                            continue;
                        }
                        if (m_GoogList.Count <= 0)
                        {
                            continue;
                        }
                        UserItem = (TUserItem*)m_GoogList[0];
                        if (this.CheckIsOKItem(UserItem, 0))// 检查变态物品
                        {
                            break;
                        }
                        sUserItemName = ""; // 取自定义物品名称
                        if (UserItem->btValue[13] == 1)
                        {
                            sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                        }
                        if (sUserItemName == "")
                        {
                            sUserItemName = UserEngine.GetStdItemName(UserItem->wIndex);
                        }
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if (StdItem != null)
                        {
                            if (UserItem->btValue[12] == 1)// 物品发光
                            {
                                StdItem->Reserved1 = 1;
                            }
                            else
                            {
                                StdItem->Reserved1 = 0;
                            }
                            if (PlayObject.IsAddWeightAvailable(StdItem->Weight))
                            {
                                if (sUserItemName == sItemName)
                                {
                                    if (m_GoogList.Count > 0)
                                    {
                                        for (int II = 0; II < m_GoogList.Count; II++)
                                        {
                                            if (m_GoogList.Count <= 0)
                                            {
                                                break;
                                            }
                                            UserItem = (TUserItem*)m_GoogList[II];
                                            if ((StdItem->StdMode <= 4) || (StdItem->StdMode == 42) || (StdItem->StdMode == 31) || (UserItem->MakeIndex == nInt))
                                            {
                                                nPrice = GetUserPrice(PlayObject, GetUserItemPrice(UserItem));
                                                if ((PlayObject.m_nGold >= nPrice) && (nPrice > 0))
                                                {
                                                    PlayObject.ClearCopyItem(0, UserItem->wIndex, UserItem->MakeIndex); // 清理包裹和仓库复制物品
                                                    if (PlayObject.AddItemToBag(UserItem))
                                                    {
                                                        PlayObject.m_nGold -= nPrice;
                                                        if (m_boCastle || M2Share.g_Config.boGetAllNpcTax)
                                                        {
                                                            if (this.m_Castle != null)
                                                            {
                                                                this.m_Castle.IncRateGold(nPrice);
                                                            }
                                                            else if (M2Share.g_Config.boGetAllNpcTax)
                                                            {
                                                                M2Share.g_CastleManager.IncRateGold(M2Share.g_Config.nUpgradeWeaponPrice);
                                                            }
                                                        }
                                                        if ((StdItem->StdMode == 2) && (StdItem->AniCount == 21))
                                                        {
                                                            UserItem->Dura = 0;// 魔令包和祝福罐,则把当前持久设置为0
                                                        }
                                                        if ((StdItem->StdMode == 51) && (StdItem->Shape == 0))
                                                        {
                                                            UserItem->Dura = 0; // 聚灵珠,则把当前持久设置为0
                                                        }
                                                        PlayObject.SendAddItem(UserItem);
                                                        if (StdItem->NeedIdentify == 1)
                                                        {
                                                            M2Share.AddGameDataLog("9" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString()
                                                                + "\09" + PlayObject.m_sCharName + "\09" + StdItem->ToString() + "\09" + UserItem->MakeIndex + "\09" + "(" + HUtil32.LoWord(StdItem->DC)
                                                                + "/" + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC) + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "("
                                                                + HUtil32.LoWord(StdItem->SC) + "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" + HUtil32.LoWord(StdItem->AC) + "/" + HUtil32.HiWord(StdItem->AC)
                                                                + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + HUtil32.HiWord(StdItem->MAC) + ")" + UserItem->btValue[0] + "/"
                                                                + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString() + "/" + (UserItem->btValue[4]).ToString()
                                                                + "/" + UserItem->btValue[5] + "/" + (UserItem->btValue[6]).ToString() + "/" + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString()
                                                                + "/" + (UserItem->btValue[14]).ToString() + "\09" + this.m_sCharName);
                                                        }
                                                        m_GoogList.RemoveAt(II);
                                                        if (m_GoogList.Count <= 0)
                                                        {
                                                            Dispose(m_GoogList);
                                                            m_GoodsList.RemoveAt(I);
                                                        }
                                                        n1C = 0;
                                                    }
                                                    else
                                                    {
                                                        n1C = 2;
                                                    }
                                                }
                                                else
                                                {
                                                    n1C = 3;
                                                }
                                                bo29 = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                n1C = 2;
                            }
                        }
                    }
                }
                if (n1C == 0)
                {
                    PlayObject.SendMsg(this, Grobal2.RM_BUYITEM_SUCCESS, 0, PlayObject.m_nGold, nInt, 0, "");
                    PlayObject.GoldChanged();// 更新客户端金币
                }
                else
                {
                    PlayObject.SendMsg(this, Grobal2.RM_BUYITEM_FAIL, 0, n1C, 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClientBuyItem");
            }
        }

        /// <summary>
        /// 客户端获取商品详情列表
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sItemName"></param>
        /// <param name="nInt"></param>
        public unsafe void ClientGetDetailGoodsList(TPlayObject PlayObject, string sItemName, int nInt)
        {
            int n18;
            IList<IntPtr> m_GoogList;
            TUserItem* UserItem;
            TStdItem* StdItem;
            TClientItem* ClientItem = null;
            TOClientItem* OClientItem = null;
            string s1C = string.Empty;
            byte nCode = 0;
            try
            {
                nCode = 0;
                if (PlayObject.m_nSoftVersionDateEx == 0)
                {
                    n18 = 0;
                    if (m_GoodsList.Count > 0)
                    {
                        for (int I = 0; I < m_GoodsList.Count; I++)
                        {
                            m_GoogList = GetObject<List<IntPtr>>(Parse(m_GoodsList[I]));
                            if (m_GoogList == null)
                            {
                                continue;
                            }
                            if (m_GoogList.Count <= 0)
                            {
                                continue;
                            }
                            nCode = 1;
                            UserItem = (TUserItem*)m_GoogList[0];
                            if (UserItem == null)
                            {
                                continue;
                            }
                            nCode = 2;
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            if ((StdItem != null) && ((HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen)).ToLower().CompareTo((sItemName).ToLower()) == 0))
                            {
                                if ((m_GoogList.Count - 1) < nInt)
                                {
                                    nInt = HUtil32._MAX(0, m_GoogList.Count - 10);
                                }
                                nCode = 3;
                                for (int II = m_GoogList.Count - 1; II >= 0; II--)
                                {
                                    if (m_GoogList.Count <= 0)
                                    {
                                        break;
                                    }
                                    UserItem = (TUserItem*)m_GoogList[II];
                                    nCode = 4;
                                    if (UserItem != null)
                                    {
                                        nCode = 5;
                                        M2Share.CopyStdItemToOStdItem(StdItem, &OClientItem->s);
                                        nCode = 6;
                                        OClientItem->Dura = UserItem->Dura;
                                        OClientItem->DuraMax = (ushort)GetUserPrice(PlayObject, GetUserItemPrice(UserItem));
                                        OClientItem->MakeIndex = UserItem->MakeIndex;
                                        byte[] data = new byte[sizeof(TOClientItem)];
                                        fixed (byte* pb = data)
                                        {
                                            *(TOClientItem*)pb = *OClientItem;
                                        }
                                        s1C = s1C + EncryptUnit.EncodeBuffer(data, sizeof(TOClientItem)) + "/";
                                        n18++;
                                        if (n18 >= 10)
                                        {
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    nCode = 7;
                    PlayObject.SendMsg(this, Grobal2.RM_SENDDETAILGOODSLIST, 0, Parse(this), n18, nInt, s1C);
                }
                else
                {
                    nCode = 8;
                    n18 = 0;
                    if (m_GoodsList.Count > 0)
                    {
                        for (int I = 0; I < m_GoodsList.Count; I++)
                        {
                            m_GoogList = GetObject<List<IntPtr>>(Parse(m_GoodsList[I]));
                            if (m_GoogList == null)
                            {
                                continue;
                            }
                            if (m_GoogList.Count <= 0)
                            {
                                continue;
                            }
                            nCode = 9;
                            UserItem = (TUserItem*)m_GoogList[0];
                            if (UserItem == null)
                            {
                                continue;
                            }
                            nCode = 10;
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            if ((StdItem != null) && (HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) == sItemName))
                            {
                                if ((m_GoogList.Count - 1) < nInt)
                                {
                                    nInt = HUtil32._MAX(0, m_GoogList.Count - 10);
                                }
                                nCode = 11;
                                for (int II = m_GoogList.Count - 1; II >= 0; II--)
                                {
                                    if (m_GoogList.Count <= 0)
                                    {
                                        break;
                                    }
                                    UserItem = (TUserItem*)m_GoogList[II];
                                    nCode = 12;
                                    if (this.CheckIsOKItem(UserItem, 0))  // 检查变态物品
                                    {
                                        continue;
                                    }
                                    nCode = 13;
                                    if (UserItem != null)
                                    {
                                        nCode = 14;
                                        ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));//By Dr.Kevin修正此处没有申请内存
                                        ClientItem->s = *StdItem;
                                        ClientItem->Dura = UserItem->Dura;
                                        ClientItem->DuraMax = (ushort)GetUserPrice(PlayObject, GetUserItemPrice(UserItem));
                                        ClientItem->MakeIndex = UserItem->MakeIndex;
                                        byte[] data = new byte[sizeof(TClientItem)];
                                        fixed (byte* pb = data)
                                        {
                                            *(TClientItem*)pb = *ClientItem;
                                        }
                                        s1C = s1C + EncryptUnit.EncodeBuffer(data, sizeof(TClientItem)) + "/";
                                        n18++;
                                        if (n18 >= 10)
                                        {
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    nCode = 15;
                    PlayObject.SendMsg(this, Grobal2.RM_SENDDETAILGOODSLIST, 0, Parse(this), n18, nInt, s1C);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClientGetDetailGoodsList Code:" + nCode);
            }
        }

        /// <summary>
        /// 客户端查询物品卖出价格
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="UserItem"></param>
        public unsafe void ClientQuerySellPrice(TPlayObject PlayObject, TUserItem* UserItem)
        {
            int nC;
            try
            {
                nC = GetSellItemPrice(GetUserItemPrice(UserItem));
                if ((nC >= 0))
                {
                    PlayObject.SendMsg(this, Grobal2.RM_SENDBUYPRICE, 0, nC, 0, 0, "");
                }
                else
                {
                    PlayObject.SendMsg(this, Grobal2.RM_SENDBUYPRICE, 0, 0, 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClientQuerySellPrice");
            }
        }

        /// <summary>
        /// 取出售物品的价格
        /// </summary>
        /// <param name="nPrice"></param>
        /// <returns></returns>
        private int GetSellItemPrice(int nPrice)
        {
            return (int)HUtil32.Round(nPrice / 2.0);
        }

        public unsafe bool ClientSellItem_sub_4A1C84(TUserItem* UserItem)
        {
            bool result = false;
            TStdItem* StdItem;
            result = true;
            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
            if ((StdItem != null) && ((StdItem->StdMode == 25) || (StdItem->StdMode == 30)))
            {
                if (UserItem->Dura < 4000)
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 客户端出售物品
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="UserItem"></param>
        /// <returns></returns>
        public unsafe bool ClientSellItem(TPlayObject PlayObject, TUserItem* UserItem)
        {
            bool result = false;
            int nPrice;
            TStdItem* StdItem;
            try
            {
                result = false;
                nPrice = GetSellItemPrice(GetUserItemPrice(UserItem));
                if ((nPrice > 0) && ClientSellItem_sub_4A1C84(UserItem))
                {
                    if (PlayObject.IncGold(nPrice))
                    {
                        if (m_boCastle || M2Share.g_Config.boGetAllNpcTax)
                        {
                            if (this.m_Castle != null)
                            {
                                this.m_Castle.IncRateGold(nPrice);
                            }
                            else if (M2Share.g_Config.boGetAllNpcTax)
                            {
                                M2Share.g_CastleManager.IncRateGold(M2Share.g_Config.nUpgradeWeaponPrice);
                            }
                        }
                        PlayObject.SendMsg(this, Grobal2.RM_USERSELLITEM_OK, 0, PlayObject.m_nGold, 0, 0, "");
                        PlayObject.GoldChanged();// 更新客户端金币
                        AddItemToGoodsList(UserItem);
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if (StdItem->NeedIdentify == 1)
                        {
                            M2Share.AddGameDataLog("10" + "\09" + PlayObject.m_sMapName + "\09" + PlayObject.m_nCurrX + "\09" + PlayObject.m_nCurrY
                                + "\09" + PlayObject.m_sCharName + "\09" + StdItem->ToString() + "\09" + UserItem->MakeIndex
                                + "\09" + "(" + HUtil32.LoWord(StdItem->DC) + "/" + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC)
                                + "/" + HUtil32.HiWord(StdItem->MC) + ")" + "(" + HUtil32.LoWord(StdItem->SC) + "/" + HUtil32.HiWord(StdItem->SC) + ")"
                                + "(" + HUtil32.LoWord(StdItem->AC) + "/" + HUtil32.HiWord(StdItem->AC) + ")" + "(" + HUtil32.LoWord(StdItem->MAC) + "/"
                                + HUtil32.HiWord(StdItem->MAC) + ")" + UserItem->btValue[0] + "/" + UserItem->btValue[1] + "/" + UserItem->btValue[2] + "/" + UserItem->btValue[3] + "/" + UserItem->btValue[4] + "/"
                                + UserItem->btValue[5] + "/" + UserItem->btValue[6] + "/" + UserItem->btValue[7] + "/" + UserItem->btValue[8] + "/" + UserItem->btValue[14] + "\09" + this.m_sCharName);
                        }
                        result = true;
                    }
                    else
                    {
                        PlayObject.SendMsg(this, Grobal2.RM_USERSELLITEM_FAIL, 0, 0, 0, 0, "");
                    }
                }
                else
                {
                    PlayObject.SendMsg(this, Grobal2.RM_USERSELLITEM_FAIL, 0, 0, 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClientSellItem");
            }
            return result;
        }

        /// <summary>
        /// 增加物品到销售表中
        /// </summary>
        /// <param name="UserItem"></param>
        /// <returns></returns>
        private unsafe bool AddItemToGoodsList(TUserItem* UserItem)
        {
            bool result = false;
            List<IntPtr> ItemList;
            try
            {
                result = false;
                if ((UserItem->Dura <= 0) || this.CheckIsOKItem(UserItem, 0)) // 检查变态物品 
                {
                    return result;
                }
                ItemList = GetRefillList(UserItem->wIndex);
                if (ItemList == null)
                {
                    ItemList = new List<IntPtr>();
                    m_GoodsList.Add(ItemList);
                }
                ItemList.Insert(0, (IntPtr)UserItem);
                result = true;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.AddItemToGoodsList");
            }
            return result;
        }

        public unsafe bool ClientMakeDrugItem_sub_4A28FC(TPlayObject PlayObject, string sItemName)
        {
            bool result = false;
            int I;
            int II = 0;
            int n1C = 0;
            TStringList List10;
            string s20;
            TStringList List28;
            TUserItem* UserItem;
            result = false;
            List10 = M2Share.GetMakeItemInfo(sItemName);
            if (List10 == null)
            {
                return result;
            }
            result = true;
            if (List10.Count > 0)
            {
                for (I = 0; I < List10.Count; I++)
                {
                    s20 = List10[I];
                    //n1C = ((int)List10.Values[I]);
                    if (PlayObject.m_ItemList.Count > 0)
                    {
                        for (II = 0; II < PlayObject.m_ItemList.Count; II++)
                        {
                            if (UserEngine.GetStdItemName(((TUserItem*)PlayObject.m_ItemList[II])->wIndex) == s20)
                            {
                                n1C -= 1;
                            }
                        }
                    }
                    if (n1C > 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            if (result)
            {
                List28 = null;
                if (List10.Count > 0)
                {
                    for (I = 0; I < List10.Count; I++)
                    {
                        s20 = List10[I];
                        //n1C = ((int)List10[I]);
                        if (PlayObject.m_ItemList.Count > 0)
                        {
                            for (II = PlayObject.m_ItemList.Count - 1; II >= 0; II--)
                            {
                                if (n1C <= 0)
                                {
                                    break;
                                }
                                if (PlayObject.m_ItemList.Count <= 0)
                                {
                                    break;
                                }
                                UserItem = (TUserItem*)PlayObject.m_ItemList[II];
                                if (UserItem == null)
                                {
                                    continue;
                                }
                                if (UserEngine.GetStdItemName(UserItem->wIndex) == s20)
                                {
                                    if (List28 == null)
                                    {
                                        List28 = new TStringList();
                                    }
                                    //List28.Add(s20, ((UserItem->MakeIndex) as Object));
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                    PlayObject.m_ItemList.RemoveAt(II);
                                    n1C -= 1;
                                }
                            }
                        }
                    }
                }
                if (List28 != null)
                {
                    PlayObject.SendMsg(this, Grobal2.RM_SENDDELITEMLIST, 0, Parse(List28), 0, 0, "");
                }
            }
            return result;
        }

        /// <summary>
        /// 客户端取制造的药品,制造毒药(其它物品)
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="sItemName"></param>
        public unsafe void ClientMakeDrugItem(TPlayObject PlayObject, string sItemName)
        {
            ArrayList List1C = null;
            TUserItem* MakeItem = null;
            TUserItem* UserItem = null;
            TStdItem* StdItem;
            int n14;
            try
            {
                n14 = 1;
                if (m_GoodsList.Count > 0)
                {
                    for (int I = 0; I < m_GoodsList.Count; I++)
                    {
                        //List1C = ((m_GoodsList[I]) as ArrayList);
                        if (List1C == null)
                        {
                            continue;
                        }
                        if (List1C.Count <= 0)
                        {
                            continue;
                        }
                        //MakeItem = List1C[0];
                        if (MakeItem == null)
                        {
                            continue;
                        }
                        StdItem = UserEngine.GetStdItem(MakeItem->wIndex);
                        if ((StdItem != null) && (StdItem->ToString() == sItemName))
                        {
                            if (PlayObject.m_nGold >= M2Share.g_Config.nMakeDurgPrice)
                            {
                                if (ClientMakeDrugItem_sub_4A28FC(PlayObject, sItemName))
                                {
                                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                    UserEngine.CopyToUserItemFromName(sItemName, UserItem);
                                    PlayObject.ClearCopyItem(0, UserItem->wIndex, UserItem->MakeIndex);// 清理包裹和仓库复制物品
                                    if (PlayObject.AddItemToBag(UserItem))
                                    {
                                        PlayObject.m_nGold -= M2Share.g_Config.nMakeDurgPrice;
                                        PlayObject.SendAddItem(UserItem);
                                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                        if (StdItem->NeedIdentify == 1)
                                        {
                                            M2Share.AddGameDataLog("2" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString() + "\09"
                                                + PlayObject.m_sCharName + "\09" + StdItem->ToString() + "\09" + UserItem->MakeIndex + "\09" + "(" + HUtil32.LoWord(StdItem->DC) + "/"
                                                + HUtil32.HiWord(StdItem->DC) + ")" + "(" + HUtil32.LoWord(StdItem->MC) + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + HUtil32.LoWord(StdItem->SC)
                                                + "/" + HUtil32.HiWord(StdItem->SC) + ")" + "(" + HUtil32.LoWord(StdItem->AC) + "/" + HUtil32.HiWord(StdItem->AC) + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString()
                                                + "/" + HUtil32.HiWord(StdItem->MAC) + ")" + UserItem->btValue[0] + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString()
                                                + "/" + (UserItem->btValue[3]).ToString() + "/" + (UserItem->btValue[4]).ToString() + "/" + UserItem->btValue[5] + "/" + (UserItem->btValue[6]).ToString()
                                                + "/" + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString() + "\09" + this.m_sCharName);
                                        }
                                        n14 = 0;
                                        break;
                                    }
                                    else
                                    {
                                        Marshal.FreeHGlobal((IntPtr)UserItem);
                                        n14 = 2;
                                    }
                                }
                                else
                                {
                                    n14 = 4;
                                }
                            }
                            else
                            {
                                n14 = 3;
                            }
                        }
                    }
                }
                if (n14 == 0)
                {
                    PlayObject.SendMsg(this, Grobal2.RM_MAKEDRUG_SUCCESS, 0, PlayObject.m_nGold, 0, 0, "");
                }
                else
                {
                    PlayObject.SendMsg(this, Grobal2.RM_MAKEDRUG_FAIL, 0, n14, 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClientMakeDrugItem");
            }
        }

        /// <summary>
        /// 客户查询修复所需成本
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="UserItem"></param>
        public unsafe void ClientQueryRepairCost(TPlayObject PlayObject, TUserItem* UserItem)
        {
            int nPrice;
            int nRepairPrice = 0;
            try
            {
                nPrice = GetUserPrice(PlayObject, GetUserItemPrice(UserItem));
                if ((nPrice > 0) && (UserItem->DuraMax > UserItem->Dura))
                {
                    if (UserItem->DuraMax > 0)
                    {
                        nRepairPrice = Convert.ToInt32(HUtil32.Round((double)nPrice / 3 / UserItem->DuraMax * (UserItem->DuraMax - UserItem->Dura)));
                    }
                    else
                    {
                        nRepairPrice = nPrice;
                    }
                    if ((PlayObject.m_sScriptLable == FunctionDef.sSUPERREPAIR))
                    {
                        if (m_boS_repair)
                        {
                            nRepairPrice = nRepairPrice * M2Share.g_Config.nSuperRepairPriceRate;
                        }
                        else
                        {
                            nRepairPrice = -1;
                        }
                    }
                    else
                    {
                        if (!m_boRepair)
                        {
                            nRepairPrice = -1;
                        }
                    }
                    PlayObject.SendMsg(this, Grobal2.RM_SENDREPAIRCOST, 0, nRepairPrice, 0, 0, "");
                }
                else
                {
                    PlayObject.SendMsg(this, Grobal2.RM_SENDREPAIRCOST, 0, -1, 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClientQueryRepairCost");
            }
        }

        /// <summary>
        /// 修理物品
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="UserItem"></param>
        /// <returns></returns>
        public unsafe bool ClientRepairItem(TPlayObject PlayObject, TUserItem* UserItem)
        {
            bool result = false;
            int nPrice;
            int nRepairPrice = 0;
            TStdItem* StdItem;
            bool boCanRepair;
            try
            {
                result = false;
                boCanRepair = true;
                if ((PlayObject.m_sScriptLable == FunctionDef.sSUPERREPAIR) && !m_boS_repair)
                {
                    boCanRepair = false;
                }
                if ((PlayObject.m_sScriptLable != FunctionDef.sSUPERREPAIR) && !m_boRepair)
                {
                    boCanRepair = false;
                }
                if (PlayObject.m_sScriptLable == "@fail_s_repair")
                {
                    this.SendMsgToUser(PlayObject, "对不起, 我不能修复这个物品\\ \\ \\<Main/@main>");
                    PlayObject.SendMsg(this, Grobal2.RM_USERREPAIRITEM_FAIL, 0, 0, 0, 0, "");
                    return result;
                }
                nPrice = GetUserPrice(PlayObject, GetUserItemPrice(UserItem));
                if (PlayObject.m_sScriptLable == FunctionDef.sSUPERREPAIR)
                {
                    nPrice = nPrice * M2Share.g_Config.nSuperRepairPriceRate;// 3
                }
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem != null)
                {
                    if (boCanRepair && (nPrice > 0) && (UserItem->DuraMax > UserItem->Dura) && (StdItem->StdMode != 43))
                    {
                        if (UserItem->DuraMax > 0)
                        {
                            nRepairPrice = Convert.ToInt32(HUtil32.Round((double)nPrice / 3 / UserItem->DuraMax * (UserItem->DuraMax - UserItem->Dura)));
                        }
                        else
                        {
                            nRepairPrice = nPrice;
                        }
                        if (PlayObject.DecGold(nRepairPrice))
                        {
                            if (m_boCastle || M2Share.g_Config.boGetAllNpcTax)
                            {
                                if (this.m_Castle != null)
                                {
                                    this.m_Castle.IncRateGold(nRepairPrice);
                                }
                                else if (M2Share.g_Config.boGetAllNpcTax)
                                {
                                    M2Share.g_CastleManager.IncRateGold(M2Share.g_Config.nUpgradeWeaponPrice);
                                }
                            }
                            if (PlayObject.m_sScriptLable == FunctionDef.sSUPERREPAIR)
                            {
                                UserItem->Dura = UserItem->DuraMax;
                                PlayObject.SendMsg(this, Grobal2.RM_USERREPAIRITEM_OK, 0, PlayObject.m_nGold, UserItem->Dura, UserItem->DuraMax, "");
                                PlayObject.GoldChanged();// 更新客户端金币
                                this.GotoLable(PlayObject, FunctionDef.sSUPERREPAIROK, false);
                            }
                            else
                            {
                                // 30
                                UserItem->DuraMax -= Convert.ToUInt16((UserItem->DuraMax - UserItem->Dura) / M2Share.g_Config.nRepairItemDecDura);
                                UserItem->Dura = UserItem->DuraMax;
                                PlayObject.SendMsg(this, Grobal2.RM_USERREPAIRITEM_OK, 0, PlayObject.m_nGold, UserItem->Dura, UserItem->DuraMax, "");
                                PlayObject.GoldChanged();// 更新客户端金币
                                this.GotoLable(PlayObject, FunctionDef.sREPAIROK, false);
                            }
                            result = true;
                        }
                        else
                        {
                            PlayObject.SendMsg(this, Grobal2.RM_USERREPAIRITEM_FAIL, 0, 0, 0, 0, "");
                        }
                    }
                    else
                    {
                        PlayObject.SendMsg(this, Grobal2.RM_USERREPAIRITEM_FAIL, 0, 0, 0, 0, "");
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ClientRepairItem");
            }
            return result;
        }

        public override void ClearScript()
        {
            m_boBuy = false;
            m_boSell = false;
            m_boMakeDrug = false;
            m_boPrices = false;
            m_boStorage = false;
            m_boGetback = false;
            m_boBigStorage = false;
            m_boBigGetBack = false;
            m_boGetNextPage = false;
            m_boGetPreviousPage = false;
            m_boHero = false;
            m_boBuHero = false;
            m_boPlayMakeWine = false;// 酿酒NPC
            m_boUserLevelOrder = false;
            m_boWarrorLevelOrder = false;
            m_boWizardLevelOrder = false;
            m_boTaoistLevelOrder = false;
            m_boMasterCountOrder = false;
            m_boUpgradenow = false;
            m_boGetBackupgnow = false;
            m_boRepair = false;
            m_boS_repair = false;
            m_boGetMarry = false;
            m_boGetMaster = false;
            m_boUseItemName = false;
            m_boofflinemsg = false;
            m_boDealGold = false;
            base.ClearScript();
        }
        
        /// <summary>
        /// 加载物品升级列表
        /// </summary>
        public void LoadUpgradeList()
        {
            try
            {
                if (m_UpgradeWeaponList.Count > 0)
                {
                    for (int I = 0; I < m_UpgradeWeaponList.Count; I++)
                    {
                        if (m_UpgradeWeaponList[I] != null)
                        {
                            Dispose(m_UpgradeWeaponList[I]);
                        }
                    }
                }
                m_UpgradeWeaponList.Clear();
                //LocalDB.FrmDB.LoadUpgradeWeaponRecord(m_sScript + "-" + this.m_sMapName, m_UpgradeWeaponList);
            }
            catch
            {
                M2Share.MainOutMessage("读取武器升级列表失败 - " + this.m_sCharName);
            }
        }

        public override void SendCustemMsg(TPlayObject PlayObject, string sMsg)
        {
            base.SendCustemMsg(PlayObject, sMsg);
        }

        /// <summary>
        /// 清除临时文件，包括交易库存，价格表
        /// </summary>
        public unsafe void ClearData()
        {
            TUserItem* UserItem;
            IList<IntPtr> ItemList;
            TItemPrice* ItemPrice;
            const string sExceptionMsg = "{异常} TMerchant::ClearData";
            try
            {
                if (m_GoodsList.Count > 0)
                {
                    for (int I = 0; I < m_GoodsList.Count; I++)
                    {
                        ItemList = (List<IntPtr>)m_GoodsList[I];
                        if (ItemList == null)
                        {
                            continue;
                        }
                        if (ItemList.Count > 0)
                        {
                            for (int II = 0; II < ItemList.Count; II++)
                            {
                                UserItem = (TUserItem*)ItemList[II];
                                if (UserItem != null)
                                {
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                }
                            }
                        }
                        Dispose(ItemList);
                        ItemList = null;
                    }
                }
                m_GoodsList.Clear();
                if (m_ItemPriceList.Count > 0)
                {
                    for (int I = 0; I < m_ItemPriceList.Count; I++)
                    {
                        ItemPrice = (TItemPrice*)m_ItemPriceList[I];
                        if (ItemPrice != null)
                        {
                            Marshal.FreeHGlobal((IntPtr)ItemPrice);
                        }
                    }
                }
                m_ItemPriceList.Clear();
                SaveNPCData();
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        private unsafe void ChangeUseItemName(TPlayObject PlayObject, string sLabel, string sItemName)
        {
            string sWhere;
            byte btWhere;
            TUserItem* UserItem;
            string sMsg;
            string sChangeUseItemName;
            try
            {
                if (!PlayObject.m_boChangeItemNameFlag)
                {
                    return;
                }
                PlayObject.m_boChangeItemNameFlag = false;
                sWhere = sLabel.Substring(14 - 1, sLabel.Length - 13);
                btWhere = (byte)HUtil32.Str_ToInt(sWhere, -1);
                if (btWhere >= m_UseItems.GetLowerBound(0) && btWhere <= m_UseItems.GetUpperBound(0))
                {
                    UserItem = PlayObject.m_UseItems[btWhere];
                    if (UserItem->wIndex == 0)
                    {
                        sMsg = string.Format(GameMsgDef.g_sYourUseItemIsNul, M2Share.GetUseItemName(btWhere));
                        PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(PlayObject), 0, 0, sMsg);
                        return;
                    }
                    if (UserItem->btValue[13] == 1)
                    {
                        ItemUnit.DelCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                    }
                    if (sItemName != "")
                    {
                        if (M2Share.g_Config.boChangeUseItemNameByPlayName)
                        {
                            sChangeUseItemName = PlayObject.m_sCharName + "的" + sItemName;
                        }
                        else
                        {
                            sChangeUseItemName = M2Share.g_Config.sChangeUseItemName + sItemName;
                        }
                        ItemUnit.AddCustomItemName(UserItem->MakeIndex, UserItem->wIndex, sChangeUseItemName);
                        UserItem->btValue[13] = 1;
                    }
                    else
                    {
                        ItemUnit.DelCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                        UserItem->btValue[13] = 0;
                    }
                    ItemUnit.SaveCustomItemName();
                    PlayObject.SendMsg(PlayObject, Grobal2.RM_SENDUSEITEMS, 0, 0, 0, 0, "");
                    PlayObject.SendMsg(this, Grobal2.RM_MENU_OK, 0, Parse(PlayObject), 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMerchant.ChangeUseItemName");
            }
        }

    }
}
