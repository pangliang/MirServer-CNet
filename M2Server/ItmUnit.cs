using System;
using System.Collections.Generic;
using System.IO;
using GameFramework;

namespace M2Server
{
    public class TItemUnit
    {
        public IList<TItemName> m_ItemNameList = null;

        public TItemUnit()
        {
            m_ItemNameList = new List<TItemName>();
        }

        ~TItemUnit()
        {
            if (m_ItemNameList.Count > 0)
            {
                for (int I = 0; I < m_ItemNameList.Count; I++)
                {
                    if (m_ItemNameList[I] != null)
                    {
                        Dispose(m_ItemNameList[I]);
                    }
                }
            }
            Dispose(m_ItemNameList);
        }

        private int GetRandomRange(int nCount, int nRate)
        {
            int result = 0;
            for (int I = 0; I < nCount; I++)
            {
                if (HUtil32.Random(nRate) == 0)
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// 随机升级武器
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void RandomUpgradeWeapon(TUserItem* UserItem)
        {
            int n10;
            int n14;
            int nC = GetRandomRange(M2Share.g_Config.nWeaponDCAddValueMaxLimit, M2Share.g_Config.nWeaponDCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nWeaponDCAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[0] > M2Share.g_Config.nWeaponDCAddValueMaxLimit)//限制上限
                {
                    UserItem->btValue[0] = M2Share.g_Config.nWeaponDCAddValueMaxLimit;
                }
            }
            nC = GetRandomRange(12, 15);
            if (HUtil32.Random(15) == 0)
            {
                n14 = (nC + 1) / 3;
                if (n14 > 0)
                {
                    if (HUtil32.Random(3) != 0)
                    {
                        UserItem->btValue[6] = Convert.ToByte(n14);
                    }
                    else
                    {
                        UserItem->btValue[6] = Convert.ToByte(n14 + 10);
                    }
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nWeaponMCAddValueMaxLimit, M2Share.g_Config.nWeaponMCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nWeaponMCAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[1] > M2Share.g_Config.nWeaponMCAddValueMaxLimit)//限制上限
                {
                    UserItem->btValue[1] = M2Share.g_Config.nWeaponMCAddValueMaxLimit;
                }
            
            }
            nC = GetRandomRange(M2Share.g_Config.nWeaponSCAddValueMaxLimit, M2Share.g_Config.nWeaponSCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nWeaponSCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nWeaponSCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nWeaponSCAddValueMaxLimit;
                }
            
            }
            nC = GetRandomRange(12, 15);
            if (HUtil32.Random(15) == 0)
            {
                UserItem->btValue[5] = Convert.ToByte(nC / 2 + 1);
            }
            nC = GetRandomRange(12, 12);
            if (HUtil32.Random(3) < 2)
            {
                n10 = (nC + 1) * 2000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
            nC = GetRandomRange(12, 15);
            if (HUtil32.Random(10) == 0)
            {
                UserItem->btValue[7] = Convert.ToByte(nC / 2 + 1);
            }
        }

        public unsafe void RandomUpgradeDress(TUserItem* UserItem)
        {
            int n10;
            int nC = GetRandomRange(M2Share.g_Config.nDressACAddValueMaxLimit, M2Share.g_Config.nDressACAddValueRate);
            if (null == UserItem->btValue)
            {
                return;
            }
            if (HUtil32.Random(M2Share.g_Config.nDressACAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[0] > M2Share.g_Config.nDressACAddValueMaxLimit)//限制上限
                {
                    UserItem->btValue[0] = M2Share.g_Config.nDressACAddValueMaxLimit;
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nDressMACAddValueMaxLimit, M2Share.g_Config.nDressMACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nDressMACAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[1] > M2Share.g_Config.nDressMACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nDressMACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nDressDCAddValueMaxLimit, M2Share.g_Config.nDressDCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nDressDCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nDressDCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nDressDCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nDressMCAddValueMaxLimit, M2Share.g_Config.nDressMCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nDressMCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[3] > M2Share.g_Config.nDressMCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nDressMCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nDressSCAddValueMaxLimit, M2Share.g_Config.nDressSCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nDressSCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[4] > M2Share.g_Config.nDressSCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nDressSCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(6, 10);
            if (HUtil32.Random(8) < 6)
            {
                n10 = (nC + 1) * 2000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        public unsafe void RandomUpgrade202124(TUserItem* UserItem)
        {
            int nC;
            int n10;
            nC = GetRandomRange(M2Share.g_Config.nNeckLace202124ACAddValueMaxLimit, M2Share.g_Config.nNeckLace202124ACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace202124ACAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[0] > M2Share.g_Config.nNeckLace202124ACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nNeckLace202124ACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace202124MACAddValueMaxLimit, M2Share.g_Config.nNeckLace202124MACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace202124MACAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[1] > M2Share.g_Config.nNeckLace202124MACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nNeckLace202124MACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace202124DCAddValueMaxLimit, M2Share.g_Config.nNeckLace202124DCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace202124DCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nNeckLace202124DCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nNeckLace202124DCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace202124MCAddValueMaxLimit, M2Share.g_Config.nNeckLace202124MCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace202124MCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[3] > M2Share.g_Config.nNeckLace202124MCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nNeckLace202124MCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace202124SCAddValueMaxLimit, M2Share.g_Config.nNeckLace202124SCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace202124SCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[4] > M2Share.g_Config.nNeckLace202124SCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nNeckLace202124SCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(6, 12);
            if (HUtil32.Random(20) < 15)
            {
                n10 = (nC + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        public unsafe  void RandomUpgrade26(TUserItem* UserItem)
        {
            int nC;
            int n10;
            nC = GetRandomRange(M2Share.g_Config.nArmRing26ACAddValueMaxLimit, M2Share.g_Config.nArmRing26ACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nArmRing26ACAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[0] > M2Share.g_Config.nArmRing26ACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nArmRing26ACAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nArmRing26MACAddValueMaxLimit, M2Share.g_Config.nArmRing26MACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nArmRing26MACAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[1] > M2Share.g_Config.nArmRing26MACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nArmRing26MACAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nArmRing26DCAddValueMaxLimit, M2Share.g_Config.nArmRing26DCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nArmRing26DCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nArmRing26DCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nArmRing26DCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nArmRing26MCAddValueMaxLimit, M2Share.g_Config.nArmRing26MCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nArmRing26MCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[3] > M2Share.g_Config.nArmRing26MCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nArmRing26MCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nArmRing26SCAddValueMaxLimit, M2Share.g_Config.nArmRing26SCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nArmRing26SCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[4] > M2Share.g_Config.nArmRing26SCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nArmRing26SCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(6, 12);
            if (HUtil32.Random(20) < 15)
            {
                n10 = (nC + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        /// <summary>
        /// 随机升级-分类19物品(幸运类项链)
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void RandomUpgrade19(TUserItem* UserItem)
        {
            int nC;
            int n10;
            nC = GetRandomRange(M2Share.g_Config.nNeckLace19ACAddValueMaxLimit, M2Share.g_Config.nNeckLace19ACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace19ACAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[0] > M2Share.g_Config.nNeckLace19ACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nNeckLace19ACAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace19MACAddValueMaxLimit, M2Share.g_Config.nNeckLace19MACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace19MACAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[1] > M2Share.g_Config.nNeckLace19MACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nNeckLace19MACAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace19DCAddValueMaxLimit, M2Share.g_Config.nNeckLace19DCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace19DCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nNeckLace19DCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nNeckLace19DCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace19MCAddValueMaxLimit, M2Share.g_Config.nNeckLace19MCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace19MCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[3] > M2Share.g_Config.nNeckLace19MCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nNeckLace19MCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nNeckLace19SCAddValueMaxLimit, M2Share.g_Config.nNeckLace19SCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nNeckLace19SCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[4] > M2Share.g_Config.nNeckLace19SCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nNeckLace19SCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(6, 10);
            if (HUtil32.Random(4) < 3)
            {
                n10 = (nC + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        public unsafe void RandomUpgrade22(TUserItem* UserItem)
        {
            int nC;
            int n10;
            nC = GetRandomRange(M2Share.g_Config.nRing22DCAddValueMaxLimit, M2Share.g_Config.nRing22DCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing22DCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nRing22DCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nRing22DCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nRing22MCAddValueMaxLimit, M2Share.g_Config.nRing22MCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing22MCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[3] > M2Share.g_Config.nRing22MCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nRing22MCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nRing22SCAddValueMaxLimit, M2Share.g_Config.nRing22SCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing22SCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[4] > M2Share.g_Config.nRing22SCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nRing22SCAddValueMaxLimit;//限制上线
                }
            }
            nC = GetRandomRange(6, 12);
            if (HUtil32.Random(4) < 3)
            {
                n10 = (nC + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        public unsafe void RandomUpgrade23(TUserItem* UserItem)
        {
            int nC;
            int n10;
            nC = GetRandomRange(M2Share.g_Config.nRing23ACAddValueMaxLimit, M2Share.g_Config.nRing23ACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing23ACAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[0] > M2Share.g_Config.nRing23ACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nRing23ACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nRing23MACAddValueMaxLimit, M2Share.g_Config.nRing23MACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing23MACAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[1] > M2Share.g_Config.nRing23MACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nRing23MACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nRing23DCAddValueMaxLimit, M2Share.g_Config.nRing23DCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing23DCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nRing23DCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nRing23DCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nRing23MCAddValueMaxLimit, M2Share.g_Config.nRing23MCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing23MCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[3] > M2Share.g_Config.nRing23MCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nRing23MCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nRing23SCAddValueMaxLimit, M2Share.g_Config.nRing23SCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nRing23SCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[4] > M2Share.g_Config.nRing23SCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nRing23SCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(6, 12);
            if (HUtil32.Random(4) < 3)
            {
                n10 = (nC + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        /// <summary>
        /// 头盔,斗笠 极品属性
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void RandomUpgradeHelMet(TUserItem* UserItem)
        {
            int nC;
            int n10;
            nC = GetRandomRange(M2Share.g_Config.nHelMetACAddValueMaxLimit, M2Share.g_Config.nHelMetACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nHelMetACAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[0] > M2Share.g_Config.nHelMetACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nHelMetACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nHelMetMACAddValueMaxLimit, M2Share.g_Config.nHelMetMACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nHelMetMACAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[1] > M2Share.g_Config.nHelMetMACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nHelMetMACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nHelMetDCAddValueMaxLimit, M2Share.g_Config.nHelMetDCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nHelMetDCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[2] > M2Share.g_Config.nHelMetDCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nHelMetDCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nHelMetMCAddValueMaxLimit, M2Share.g_Config.nHelMetMCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nHelMetMCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[3] > M2Share.g_Config.nHelMetMCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nHelMetMCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nHelMetSCAddValueMaxLimit, M2Share.g_Config.nHelMetSCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nHelMetSCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);
                if (UserItem->btValue[4] > M2Share.g_Config.nHelMetSCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nHelMetSCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(6, 12);
            if (HUtil32.Random(4) < 3)
            {
                n10 = (nC + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        /// <summary>
        /// 鞋子腰带极品
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void RandomUpgradeBoots(TUserItem* UserItem)
        {
            int nC;
            int n10;
            nC = GetRandomRange(M2Share.g_Config.nBootsACAddValueMaxLimit, M2Share.g_Config.nBootsACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nBootsACAddRate) == 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nC + 1);// 防御
                if (UserItem->btValue[0] > M2Share.g_Config.nBootsACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nBootsACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nBootsMACAddValueMaxLimit, M2Share.g_Config.nBootsMACAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nBootsMACAddRate) == 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nC + 1);// 魔御
                if (UserItem->btValue[1] > M2Share.g_Config.nBootsMACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nBootsMACAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nBootsDCAddValueMaxLimit, M2Share.g_Config.nBootsDCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nBootsDCAddRate) == 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nC + 1);// 攻击力
                if (UserItem->btValue[2] > M2Share.g_Config.nBootsDCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nBootsDCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nBootsMCAddValueMaxLimit, M2Share.g_Config.nBootsMCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nBootsMCAddRate) == 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nC + 1);// 魔法
                if (UserItem->btValue[3] > M2Share.g_Config.nBootsMCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nBootsMCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(M2Share.g_Config.nBootsSCAddValueMaxLimit, M2Share.g_Config.nBootsSCAddValueRate);
            if (HUtil32.Random(M2Share.g_Config.nBootsSCAddRate) == 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nC + 1);// 道术
                if (UserItem->btValue[4] > M2Share.g_Config.nBootsSCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nBootsSCAddValueMaxLimit;//限制上限
                }
            }
            nC = GetRandomRange(6, 12);
            if (HUtil32.Random(4) < 3)
            {
                n10 = (nC + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + n10);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + n10);
            }
        }

        /// <summary>
        /// 神秘头盔
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void UnknowHelmet(TUserItem* UserItem)
        {
            int nC;
            int n14;
            int nRandPoint = GetRandomRange(M2Share.g_Config.nUnknowHelMetACAddValueMaxLimit, M2Share.g_Config.nUnknowHelMetACAddRate);
            if (nRandPoint > 0)
            {
                UserItem->btValue[0] = Convert.ToByte(nRandPoint);
                if (UserItem->btValue[0] > M2Share.g_Config.nUnknowHelMetACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nUnknowHelMetACAddValueMaxLimit;//限制上限
                }
            }
            n14 = nRandPoint;
            nRandPoint = GetRandomRange(M2Share.g_Config.nUnknowHelMetMACAddValueMaxLimit, M2Share.g_Config.nUnknowHelMetMACAddRate);
            if (nRandPoint > 0)
            {
                UserItem->btValue[1] = Convert.ToByte(nRandPoint);
                if (UserItem->btValue[1] > M2Share.g_Config.nUnknowHelMetMACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nUnknowHelMetMACAddValueMaxLimit;//限制上限
                }
            }
            n14 += nRandPoint;
            nRandPoint = GetRandomRange(M2Share.g_Config.nUnknowHelMetDCAddValueMaxLimit, M2Share.g_Config.nUnknowHelMetDCAddRate);
            if (nRandPoint > 0)
            {
                UserItem->btValue[2] = Convert.ToByte(nRandPoint);
                if (UserItem->btValue[2] > M2Share.g_Config.nUnknowHelMetDCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nUnknowHelMetDCAddValueMaxLimit;//限制上限
                }
            }
            n14 += nRandPoint;
            nRandPoint = GetRandomRange(M2Share.g_Config.nUnknowHelMetMCAddValueMaxLimit, M2Share.g_Config.nUnknowHelMetMCAddRate);
            if (nRandPoint > 0)
            {
                UserItem->btValue[3] = Convert.ToByte(nRandPoint);
                if (UserItem->btValue[3] > M2Share.g_Config.nUnknowHelMetMCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nUnknowHelMetMCAddValueMaxLimit;//限制上限
                }
            }
            n14 += nRandPoint;
            nRandPoint = GetRandomRange(M2Share.g_Config.nUnknowHelMetSCAddValueMaxLimit, M2Share.g_Config.nUnknowHelMetSCAddRate);
            if (nRandPoint > 0)
            {
                UserItem->btValue[4] = Convert.ToByte(nRandPoint);
                if (UserItem->btValue[4] > M2Share.g_Config.nUnknowHelMetSCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nUnknowHelMetSCAddValueMaxLimit;//限制上限
                }
            }
            n14 += nRandPoint;
            nRandPoint = GetRandomRange(6, 30);
            if (nRandPoint > 0)
            {
                nC = (nRandPoint + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + nC);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + nC);
            }
            if (HUtil32.Random(30) == 0)
            {
                UserItem->btValue[7] = 1;
            }
            UserItem->btValue[8] = 1;
            if (n14 >= 3)
            {
                if (UserItem->btValue[0] >= 5)
                {
                    UserItem->btValue[5] = 1;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[0] * 3 + 25);
                    return;
                }
                if (UserItem->btValue[2] >= 2)
                {
                    UserItem->btValue[5] = 1;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[2] * 4 + 35);
                    return;
                }
                if (UserItem->btValue[3] >= 2)
                {
                    UserItem->btValue[5] = 2;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[3] * 2 + 18);
                    return;
                }
                if (UserItem->btValue[4] >= 2)
                {
                    UserItem->btValue[5] = 3;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[4] * 2 + 18);
                    return;
                }
                UserItem->btValue[6] = Convert.ToByte(n14 * 2 + 18);
            }
        }

        /// <summary>
        /// 神秘戒指
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void UnknowRing(TUserItem* UserItem)
        {
            
            int nC;
            int n10;
            int n14;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowRingACAddValueMaxLimit, M2Share.g_Config.nUnknowRingACAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[0] = Convert.ToByte(n10);
                if (UserItem->btValue[0] > M2Share.g_Config.nUnknowRingACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nUnknowRingACAddValueMaxLimit;//限制上限
                }
            }
            n14 = n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowRingMACAddValueMaxLimit, M2Share.g_Config.nUnknowRingMACAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[1] = Convert.ToByte(n10);
                if (UserItem->btValue[1] > M2Share.g_Config.nUnknowRingMACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nUnknowRingMACAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowRingDCAddValueMaxLimit, M2Share.g_Config.nUnknowRingDCAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[2] = Convert.ToByte(n10);
                if (UserItem->btValue[2] > M2Share.g_Config.nUnknowRingDCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nUnknowRingDCAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowRingMCAddValueMaxLimit, M2Share.g_Config.nUnknowRingMCAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[3] = Convert.ToByte(n10);
                if (UserItem->btValue[3] > M2Share.g_Config.nUnknowRingMCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nUnknowRingMCAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowRingSCAddValueMaxLimit, M2Share.g_Config.nUnknowRingSCAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[4] = Convert.ToByte(n10);
                if (UserItem->btValue[4] > M2Share.g_Config.nUnknowRingSCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nUnknowRingSCAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(6, 30);
            if (n10 > 0)
            {
                nC = (n10 + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + nC);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + nC);
            }
            if (HUtil32.Random(30) == 0)
            {
                UserItem->btValue[7] = 1;
            }
            UserItem->btValue[8] = 1;
            if (n14 >= 3)
            {
                if (UserItem->btValue[2] >= 3)
                {
                    UserItem->btValue[5] = 1;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[2] * 3 + 25);
                    return;
                }
                if (UserItem->btValue[3] >= 3)
                {
                    UserItem->btValue[5] = 2;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[3] * 2 + 18);
                    return;
                }
                if (UserItem->btValue[4] >= 3)
                {
                    UserItem->btValue[5] = 3;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[4] * 2 + 18);
                    return;
                }
                UserItem->btValue[6] = Convert.ToByte(n14 * 2 + 18);
            }
        }

        /// <summary>
        /// 神秘腰带
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void UnknowNecklace(TUserItem* UserItem)
        {
            int nC;
            int n10;
            int n14;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowNecklaceACAddValueMaxLimit, M2Share.g_Config.nUnknowNecklaceACAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[0] = Convert.ToByte(n10);
                if (UserItem->btValue[0] > M2Share.g_Config.nUnknowNecklaceACAddValueMaxLimit)
                {
                    UserItem->btValue[0] = M2Share.g_Config.nUnknowNecklaceACAddValueMaxLimit;//限制上限
                }
            }
            n14 = n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowNecklaceMACAddValueMaxLimit, M2Share.g_Config.nUnknowNecklaceMACAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[1] = Convert.ToByte(n10);
                if (UserItem->btValue[1] > M2Share.g_Config.nUnknowNecklaceMACAddValueMaxLimit)
                {
                    UserItem->btValue[1] = M2Share.g_Config.nUnknowNecklaceMACAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowNecklaceDCAddValueMaxLimit, M2Share.g_Config.nUnknowNecklaceDCAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[2] = Convert.ToByte(n10);
                if (UserItem->btValue[2] > M2Share.g_Config.nUnknowNecklaceDCAddValueMaxLimit)
                {
                    UserItem->btValue[2] = M2Share.g_Config.nUnknowNecklaceDCAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowNecklaceMCAddValueMaxLimit, M2Share.g_Config.nUnknowNecklaceMCAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[3] = Convert.ToByte(n10);
                if (UserItem->btValue[3] > M2Share.g_Config.nUnknowNecklaceMCAddValueMaxLimit)
                {
                    UserItem->btValue[3] = M2Share.g_Config.nUnknowNecklaceMCAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(M2Share.g_Config.nUnknowNecklaceSCAddValueMaxLimit, M2Share.g_Config.nUnknowNecklaceSCAddRate);
            if (n10 > 0)
            {
                UserItem->btValue[4] = Convert.ToByte(n10);
                if (UserItem->btValue[4] > M2Share.g_Config.nUnknowNecklaceSCAddValueMaxLimit)
                {
                    UserItem->btValue[4] = M2Share.g_Config.nUnknowNecklaceSCAddValueMaxLimit;//限制上限
                }
            }
            n14 += n10;
            n10 = GetRandomRange(6, 30);
            if (n10 > 0)
            {
                nC = (n10 + 1) * 1000;
                UserItem->DuraMax = (ushort)HUtil32._MIN(65000, UserItem->DuraMax + nC);
                UserItem->Dura = (ushort)HUtil32._MIN(65000, UserItem->Dura + nC);
            }
            if (HUtil32.Random(30) == 0)
            {
                UserItem->btValue[7] = 1;
            }
            UserItem->btValue[8] = 1;
            if (n14 >= 2)
            {
                if (UserItem->btValue[0] >= 3)
                {
                    UserItem->btValue[5] = 1;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[0] * 3 + 25);
                    return;
                }
                if (UserItem->btValue[2] >= 2)
                {
                    UserItem->btValue[5] = 1;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[2] * 3 + 30);
                    return;
                }
                if (UserItem->btValue[3] >= 2)
                {
                    UserItem->btValue[5] = 2;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[3] * 2 + 20);
                    return;
                }
                if (UserItem->btValue[4] >= 2)
                {
                    UserItem->btValue[5] = 3;
                    UserItem->btValue[6] = Convert.ToByte(UserItem->btValue[4] * 2 + 20);
                    return;
                }
                UserItem->btValue[6] = Convert.ToByte(n14 * 2 + 18);
            }
        }

        /// <summary>
        /// 取物品的附属属性
        /// </summary>
        /// <param name="UserItem"></param>
        /// <param name="StdItem"></param>
        public unsafe void GetItemAddValue(TUserItem* UserItem, TStdItem* StdItem)
        {
            switch (StdItem->StdMode)
            {
                case 5:
                case 6:
                    StdItem->DC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->DC), HUtil32.HiWord(StdItem->DC) + UserItem->btValue[0]);
                    StdItem->MC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->MC), HUtil32.HiWord(StdItem->MC) + UserItem->btValue[1]);
                    StdItem->SC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->SC), HUtil32.HiWord(StdItem->SC) + UserItem->btValue[2]);
                    StdItem->AC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->AC) + UserItem->btValue[3], HUtil32.HiWord(StdItem->AC) + UserItem->btValue[5]);
                    StdItem->MAC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->MAC) + UserItem->btValue[4], HUtil32.HiWord(StdItem->MAC) + UserItem->btValue[6]);
                    if (((byte)UserItem->btValue[7] - 1) < 10) // 神圣
                    {
                        StdItem->Source = (sbyte)UserItem->btValue[7];
                    }
                    if (UserItem->btValue[10] != 0)
                    {
                        StdItem->Reserved = Convert.ToByte(StdItem->Reserved | 1);
                    }
                    break;
                case 10:
                case 11:
                    StdItem->AC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->AC), HUtil32.HiWord(StdItem->AC) + UserItem->btValue[0]);
                    StdItem->MAC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->MAC), HUtil32.HiWord(StdItem->MAC) + UserItem->btValue[1]);
                    StdItem->DC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->DC), HUtil32.HiWord(StdItem->DC) + UserItem->btValue[2]);
                    StdItem->MC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->MC), HUtil32.HiWord(StdItem->MC) + UserItem->btValue[3]);
                    StdItem->SC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->SC), HUtil32.HiWord(StdItem->SC) + UserItem->btValue[4]);
                    break;
                case 15:
                case 16:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 26:
                case 51:
                case 52:
                case 53:
                case 54:
                case 62:
                case 63:
                case 64:
                case 30: // 加入勋章分类
                    StdItem->AC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->AC), HUtil32.HiWord(StdItem->AC) + UserItem->btValue[0]);
                    StdItem->MAC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->MAC), HUtil32.HiWord(StdItem->MAC) + UserItem->btValue[1]);
                    StdItem->DC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->DC), HUtil32.HiWord(StdItem->DC) + UserItem->btValue[2]);
                    StdItem->MC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->MC), HUtil32.HiWord(StdItem->MC) + UserItem->btValue[3]);
                    StdItem->SC = HUtil32.MakeLong(HUtil32.LoWord(StdItem->SC), HUtil32.HiWord(StdItem->SC) + UserItem->btValue[4]);
                    if (UserItem->btValue[5] > 0)
                    {
                        StdItem->Need = UserItem->btValue[5];
                    }
                    if (UserItem->btValue[6] > 0)
                    {
                        StdItem->NeedLevel = UserItem->btValue[6];
                    }
                    break;
            }
            if ((UserItem->btValue[20] > 0) || (StdItem->Source > 0))
            {
                switch (StdItem->StdMode) // 吸伤属性
                {
                    case 15:
                    case 16:
                    case 19:
                    case 21:
                    case 20:
                    case 22:
                    case 23:
                    case 24:
                    case 26:
                    case 30:
                    case 52:
                    case 54:
                    case 62:
                    case 64:
                        // 头盔,项链,戒指,手镯,鞋子,腰带,勋章
                        // 140
                        if (StdItem->Shape == 188)
                        {
                            StdItem->Source = Convert.ToSByte(StdItem->Source + UserItem->btValue[20]);
                            if (StdItem->Source > 100)
                            {
                                StdItem->Source = 100;
                            }
                            StdItem->Reserved = Convert.ToByte(StdItem->Reserved + UserItem->btValue[9]);
                            if (StdItem->Reserved > 5)
                            {
                                StdItem->Reserved = 5;// 吸伤装备等级
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 取自定义物品名称
        /// </summary>
        /// <param name="nMakeIndex"></param>
        /// <param name="nItemIndex"></param>
        /// <returns></returns>
        public string GetCustomItemName(int nMakeIndex, int nItemIndex)
        {
            string result;
            TItemName ItemName;
            result = "";
            lock (m_ItemNameList)
            try {
                for (int I = 0; I < m_ItemNameList.Count; I ++ )
                {
                    ItemName = m_ItemNameList[I];
                    if ((ItemName.nMakeIndex == nMakeIndex) && (ItemName.nItemIndex == nItemIndex))
                    {
                        result = ItemName.sItemName;
                        break;
                    }
                }
            } finally {
               
            }
            return result;
        }

        public bool AddCustomItemName(int nMakeIndex, int nItemIndex, string sItemName)
        {
            bool result;
            int I;
            TItemName ItemName;
            result = false;
            lock (m_ItemNameList)
            try {
                for (I = 0; I < m_ItemNameList.Count; I ++ )
                {
                    ItemName = m_ItemNameList[I];
                    if ((ItemName.nMakeIndex == nMakeIndex) && (ItemName.nItemIndex == nItemIndex))
                    {
                        return result;
                    }
                }
                ItemName = new TItemName();
                ItemName.nMakeIndex = nMakeIndex;
                ItemName.nItemIndex = nItemIndex;
                ItemName.sItemName = sItemName;
                m_ItemNameList.Add(ItemName);
                result = true;
            } finally {
               
            }
            return result;
        }

        public bool DelCustomItemName(int nMakeIndex, int nItemIndex)
        {
            bool result;
            TItemName ItemName;
            result = false;
            lock (m_ItemNameList)
                try
                {
                    for (int I = m_ItemNameList.Count - 1; I >= 0; I--)
                    {
                        if (m_ItemNameList.Count <= 0)
                        {
                            break;
                        }
                        ItemName = m_ItemNameList[I];
                        if ((ItemName.nMakeIndex == nMakeIndex) && (ItemName.nItemIndex == nItemIndex))
                        {

                            Dispose(ItemName);
                            m_ItemNameList.RemoveAt(I);
                            result = true;
                            return result;
                        }
                    }
                }
                finally
                {

                }
            return result;
        }

        public bool LoadCustomItemName()
        {
            bool result;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            string sMakeIndex = string.Empty;
            string sItemIndex = string.Empty;
            int nMakeIndex = 0;
            int nItemIndex = 0;
            string sItemName = string.Empty;
            TItemName ItemName;
            result = false;
            sFileName = M2Share.g_Config.sEnvirDir + "ItemNameList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                lock (m_ItemNameList)
                try {
                    if (m_ItemNameList.Count > 0)
                    {
                        m_ItemNameList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (int I = 0; I < LoadList.Count; I ++ )
                    {
                        sLineText = LoadList[I].Trim();
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] {" ", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] {" ", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] {" ", "\09"});
                        nMakeIndex = HUtil32.Str_ToInt(sMakeIndex,  -1);
                        nItemIndex = HUtil32.Str_ToInt(sItemIndex,  -1);
                        if ((nMakeIndex >= 0) && (nItemIndex >= 0))
                        {
                            ItemName = new TItemName();
                            ItemName.nMakeIndex = nMakeIndex;
                            ItemName.nItemIndex = nItemIndex;
                            ItemName.sItemName = sItemName;
                            m_ItemNameList.Add(ItemName);
                        }
                    }
                    result = true;
                } finally {
                   
                }
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public bool SaveCustomItemName()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemName ItemName;
            sFileName = M2Share.g_Config.sEnvirDir + "ItemNameList.txt";
            SaveList = new TStringList();
            lock (m_ItemNameList)
            try {
                if (m_ItemNameList.Count > 0)
                {
                    for (I = 0; I < m_ItemNameList.Count; I ++ )
                    {
                        ItemName = m_ItemNameList[I];
                        //SaveList.Add((ItemName.nMakeIndex).ToString() + "\09" + (ItemName.nItemIndex).ToString() + "\09" + ItemName.sItemName);
                    }
                }
            } finally {
               
            }
            SaveList.SaveToFile(sFileName);
            Dispose(SaveList);
            SaveList.Dispose();
            result = true;
            return result;
        }

        public void Dispose(object obj) {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    } 
}

