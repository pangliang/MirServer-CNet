using GameFramework;
/*
 * 名称：TGuildManager
 * 创建人：John
 * 创建时间：2012-3-6 9:30:56
 * 描述: 行会管理类
 *********************************************
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public class TGuildManager
    {
        /// <summary>
        /// 游戏行会列表
        /// </summary>
        public IList<TGUild> GuildList = null;

        /// <summary>
        /// 新建行会
        /// </summary>
        /// <param name="sGuildName"></param>
        /// <param name="sChief"></param>
        /// <returns></returns>
        public bool AddGuild(string sGuildName, string sChief)
        {
            bool result = false;
            TGUild Guild;
            if (M2Share.CheckGuildName(sGuildName) && (FindGuild(sGuildName) == null))
            {
                Guild = new TGUild(sGuildName);
                Guild.SetGuildInfo(sChief);
                Guild.m_nGuildMemberCount = M2Share.g_Config.nGuildMemberCount;// 行会成员上限
                GuildList.Add(Guild);
                SaveGuildList();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 删除行会
        /// </summary>
        /// <param name="sGuildName"></param>
        /// <returns></returns>
        public bool DelGuild(string sGuildName)
        {
            bool result = false;
            TGUild Guild;
            for (int I = 0; I < GuildList.Count; I++)
            {
                if (GuildList.Count <= 0)
                {
                    break;
                }
                Guild = GuildList[I];
                if ((Guild.sGuildName).ToLower().CompareTo((sGuildName).ToLower()) == 0)
                {
                    if (Guild.m_RankList.Count > 1)
                    {
                        break;
                    }
                    Guild.BackupGuildFile();
                    GuildList.RemoveAt(I);
                    SaveGuildList();
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void ClearGuildInf()
        {
            int I;
            if (GuildList.Count > 0)
            {
                for (I = 0; I < GuildList.Count; I++)
                {
                    Dispose(GuildList[I]);
                }
            }
            GuildList.Clear();
        }

        public TGuildManager()
        {
            GuildList = new List<TGUild>();
        }

        ~TGuildManager()
        {
            Dispose(GuildList);
        }

        /// <summary>
        /// 查找行会
        /// </summary>
        /// <param name="sGuildName"></param>
        /// <returns></returns>
        public TGUild FindGuild(string sGuildName)
        {
            TGUild result = null;
            if (GuildList.Count > 0)
            {
                for (int I = 0; I < GuildList.Count; I++)
                {
                    if (GuildList[I].sGuildName == sGuildName)
                    {
                        result = GuildList[I];
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 加载游戏行会
        /// </summary>
        public void LoadGuildInfo()
        {
            TStringList LoadList;
            TGUild Guild;
            string sGuildName;
            if (File.Exists(M2Share.g_Config.sGuildFile))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(M2Share.g_Config.sGuildFile);
                if (LoadList.Count > 0)
                {
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        sGuildName = LoadList[I].Trim();
                        if (sGuildName != "")
                        {
                            Guild = new TGUild(sGuildName);
                            GuildList.Add(Guild);
                        }
                    }
                }
                Dispose(LoadList);
                for (int I = GuildList.Count - 1; I >= 0; I--)
                {
                    if (GuildList.Count <= 0)
                    {
                        break;
                    }
                    Guild = GuildList[I];
                    if (!Guild.LoadGuild())
                    {
                        M2Share.MainOutMessage(Guild.sGuildName + " 读取出错！！！");
                        Dispose(Guild);
                        GuildList.RemoveAt(I);
                        SaveGuildList();
                    }
                }
                M2Share.OutInfoMessage("已读取 [" + GuildList.Count + "] 个行会信息...");
            }
            else
            {
                M2Share.MainOutMessage("行会信息文件未找到！！！");
            }
        }

        // 取玩家所属的行会
        public TGUild MemberOfGuild(string sName)
        {
            TGUild result = null;
            if (GuildList.Count > 0)
            {
                for (int I = 0; I < GuildList.Count; I++)
                {
                    if (GuildList[I].IsMember(sName))
                    {
                        result = GuildList[I];
                        break;
                    }
                }
            }
            return result;
        }

        public void SaveGuildList()
        {
            TStringList SaveList;
            if (M2Share.nServerIndex != 0)
            {
                return;
            }
            SaveList = new TStringList();
            if (GuildList.Count > 0)
            {
                for (int I = 0; I < GuildList.Count; I++)
                {
                    // SaveList.Add(((GuildList[I]) as TGUild).sGuildName);
                }
            }
            try
            {
                SaveList.SaveToFile(M2Share.g_Config.sGuildFile);
            }
            catch
            {
                M2Share.MainOutMessage("行会信息保存失败！！！");
            }
            SaveList.Dispose();
            Dispose(SaveList);
        }

        public void Run()
        {
            TGUild Guild;
            bool boChanged;
            TWarGuild WarGuild;
            try
            {
                if (GuildList.Count > 0)
                {
                    for (int I = 0; I < GuildList.Count; I++)
                    {
                        Guild = GuildList[I];
                        boChanged = false;
                        for (int II = Guild.GuildWarList.Count - 1; II >= 0; II--)
                        {
                            if (Guild.GuildWarList.Count <= 0)
                            {
                                break;
                            }
                            WarGuild = Guild.GuildWarList[II];
                            if ((HUtil32.GetTickCount() - WarGuild.dwWarTick) > WarGuild.dwWarTime)
                            {
                                Guild.sub_499B4C(((WarGuild.Guild) as TGUild));
                                Guild.GuildWarList.RemoveAt(II);
                                Dispose(WarGuild);
                                boChanged = true;
                            }
                        }
                        if (boChanged)
                        {
                            Guild.UpdateGuildFile();
                        }
                        Guild.CheckSaveGuildFile();
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGuildManager.Run");
            }
        }

        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}