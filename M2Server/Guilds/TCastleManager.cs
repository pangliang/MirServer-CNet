using GameFramework;
using M2Server.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public class TCastleManager : GameBase
    {
        private object CriticalSection = null;
        public List<TUserCastle> m_CastleList = null;// 城堡列表

        public TCastleManager()
        {
            m_CastleList = new List<TUserCastle>();
            CriticalSection = new object();
        }

        ~TCastleManager()
        {
            TUserCastle UserCastle;
            if (m_CastleList.Count > 0)
            {
                for (int I = 0; I < m_CastleList.Count; I++)
                {
                    UserCastle = m_CastleList[I];
                    UserCastle.Save();
                    Dispose(UserCastle);
                }
            }
            Dispose(m_CastleList);
        }

        public TUserCastle Find(string sCASTLENAME)
        {
            TUserCastle result = null;
            if (m_CastleList.Count > 0)
            {
                result = m_CastleList.Find(u =>
                {
                    return u.m_sName == sCASTLENAME;
                });
            }
            return result;
        }

        // 取得角色所在座标的城堡
        public TUserCastle InCastleWarArea(TBaseObject BaseObject)
        {
            TUserCastle result = null;
            TUserCastle Castle;
            if (m_CastleList.Count > 0)
            {
                for (int I = 0; I < m_CastleList.Count; I++)
                {
                    Castle = m_CastleList[I];
                    if (Castle.InCastleWarArea(BaseObject.m_PEnvir, BaseObject.m_nCurrX, BaseObject.m_nCurrY))
                    {
                        result = Castle;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 是否在攻城战争区域
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public TUserCastle InCastleWarArea(TEnvirnoment Envir, int nX, int nY)
        {
            TUserCastle result = null;
            TUserCastle Castle;
            if (m_CastleList.Count > 0)
            {
                for (int I = 0; I < m_CastleList.Count; I++)
                {
                    Castle = m_CastleList[I];
                    if (Castle.InCastleWarArea(Envir, nX, nY))
                    {
                        result = Castle;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 初始化沙城配置
        /// </summary>
        public void Initialize()
        {
            TUserCastle Castle;
            if (m_CastleList.Count <= 0)
            {
                Castle = new TUserCastle(M2Share.g_Config.sCastleDir);
                m_CastleList.Add(Castle);
                Castle.Initialize();
                Castle.m_sConfigDir = "0";
                Castle.m_EnvirList.Add("0151");
                Castle.m_EnvirList.Add("0152");
                Castle.m_EnvirList.Add("0153");
                Castle.m_EnvirList.Add("0154");
                Castle.m_EnvirList.Add("0155");
                Castle.m_EnvirList.Add("0156");
                if (Castle.m_EnvirList.Count > 0)
                {
                    for (int I = 0; I < Castle.m_EnvirList.Count; I++)
                    {
                        Castle.m_EnvirList[I] = M2Share.g_MapManager.FindMap(Castle.m_EnvirList[I]).sMapName;
                    }
                }
                Save();
                return;
            }
            for (int I = 0; I < m_CastleList.Count; I++)
            {
                Castle = m_CastleList[I];
                Castle.Initialize();
            }
        }

        // 重载相关设置
        public void ReLoadCastle()
        {
            TUserCastle Castle;
            TObjUnit ObjUnit;
            TDoorInfo Door;
            bool boUnderWar;
            M2Share.g_Config.sGuildNotice = M2Share.StringConf.ReadString("Guild", "GuildNotice", M2Share.g_Config.sGuildNotice);
            M2Share.g_Config.sGuildWar = M2Share.StringConf.ReadString("Guild", "GuildWar", M2Share.g_Config.sGuildWar);
            M2Share.g_Config.sGuildAll = M2Share.StringConf.ReadString("Guild", "GuildAll", M2Share.g_Config.sGuildAll);
            M2Share.g_Config.sGuildMember = M2Share.StringConf.ReadString("Guild", "GuildMember", M2Share.g_Config.sGuildMember);
            M2Share.g_Config.sGuildMemberRank = M2Share.StringConf.ReadString("Guild", "GuildMemberRank", M2Share.g_Config.sGuildMemberRank);
            M2Share.g_Config.sGuildChief = M2Share.StringConf.ReadString("Guild", "GuildChief", M2Share.g_Config.sGuildChief);
            if (m_CastleList.Count <= 0)
            {
                Castle = new TUserCastle(M2Share.g_Config.sCastleDir);
                m_CastleList.Add(Castle);
                Castle.Initialize();
                Castle.m_sConfigDir = "0";
                Castle.m_EnvirList.Add("0151");
                Castle.m_EnvirList.Add("0152");
                Castle.m_EnvirList.Add("0153");
                Castle.m_EnvirList.Add("0154");
                Castle.m_EnvirList.Add("0155");
                Castle.m_EnvirList.Add("0156");
                if (Castle.m_EnvirList.Count > 0)
                {
                    for (int I = 0; I < Castle.m_EnvirList.Count; I++)
                    {
                        Castle.m_EnvirList[I] = M2Share.g_MapManager.FindMap(Castle.m_EnvirList[I]).sMapName;
                    }
                }
                Save();
                return;
            }
            for (int I = 0; I < m_CastleList.Count; I++)
            {
                Castle = m_CastleList[I];
                boUnderWar = Castle.m_boUnderWar;
                Castle.m_boUnderWar = false;// 先初始状态
                Castle.LoadConfig(true);
                Castle.LoadAttackSabukWall();
                if (M2Share.g_MapManager.GetMapOfServerIndex(Castle.m_sMapName) == M2Share.nServerIndex)
                {
                    Castle.m_MapPalace = M2Share.g_MapManager.FindMap(Castle.m_sPalaceMap);
                    if (Castle.m_MapPalace == null)
                    {

                        M2Share.MainOutMessage(string.Format("皇宫地图{0}没找到！！！", Castle.m_sPalaceMap));
                    }
                    Castle.m_MapSecret = M2Share.g_MapManager.FindMap(Castle.m_sSecretMap);
                    if (Castle.m_MapSecret == null)
                    {

                        M2Share.MainOutMessage(string.Format("密道地图{0}没找到！！！", Castle.m_sSecretMap));
                    }
                    Castle.m_MapCastle = M2Share.g_MapManager.FindMap(Castle.m_sMapName);
                    if (Castle.m_MapCastle != null)
                    {
                        if (Castle.m_MainDoor.BaseObject != null)
                        {
                            if ((!Castle.m_MainDoor.BaseObject.m_boGhost) && (!Castle.m_MainDoor.BaseObject.m_boDeath) &&
                                (!Castle.m_MainDoor.BaseObject.m_boFixedHideMode) && ((Castle.m_MainDoor.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_MainDoor.sName).ToLower()) == 0))
                            {
                                if (Castle.m_MainDoor.BaseObject.m_WAbil.HP <= 0)
                                {
                                    Castle.m_MainDoor.BaseObject.ReAlive();
                                }
                                Castle.m_MainDoor.BaseObject.m_WAbil.HP = Castle.m_MainDoor.nHP;
                                Castle.m_MainDoor.BaseObject.SendRefMsg(Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                                Castle.m_MainDoor.BaseObject.m_Castle = Castle;
                                M2Share.MainOutMessage("[城堡重载A-5] " + Castle.m_MainDoor.BaseObject.m_sCharName);
                            }
                            else
                            {
                                if (Castle.m_MainDoor.BaseObject != null)
                                {
                                    if (((Castle.m_MainDoor.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_MainDoor.sName).ToLower()) == 0))
                                    {
                                        if (!Castle.m_MainDoor.BaseObject.m_boDeath)
                                        {
                                            Castle.m_MainDoor.BaseObject.m_WAbil.HP = Castle.m_MainDoor.BaseObject.m_WAbil.MaxHP;
                                            ((TCastleDoor)(Castle.m_MainDoor.BaseObject)).RefStatus();
                                            Castle.m_MainDoor.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载A-1] " + Castle.m_MainDoor.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            Castle.m_MainDoor.BaseObject.m_WAbil.HP = Castle.m_MainDoor.BaseObject.m_WAbil.MaxHP;
                                            ((TCastleDoor)(Castle.m_MainDoor.BaseObject)).m_boOpened = boUnderWar;// 城门是否关闭
                                            Castle.m_MainDoor.BaseObject.ReAlive();
                                            Castle.m_MainDoor.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载A-2] " + Castle.m_MainDoor.BaseObject.m_sCharName);
                                        }
                                    }
                                    else
                                    {
                                        Castle.m_MainDoor.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_MainDoor.nX, Castle.m_MainDoor.nY, Castle.m_MainDoor.sName);
                                        if (Castle.m_MainDoor.BaseObject != null)
                                        {
                                            Castle.m_MainDoor.BaseObject.m_WAbil.HP = Castle.m_MainDoor.nHP;
                                            Castle.m_MainDoor.BaseObject.m_Castle = Castle;
                                            Castle.m_MainDoor.BaseObject.m_nCurrX = Castle.m_MainDoor.nX;
                                            Castle.m_MainDoor.BaseObject.m_nCurrY = Castle.m_MainDoor.nY;
                                            M2Share.MainOutMessage("[城堡重载A-3] " + Castle.m_MainDoor.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            M2Share.MainOutMessage("城堡初始化城门失败，检查怪物数据库里有没城门的设置: " + Castle.m_MainDoor.sName);
                                        }
                                    }
                                }
                                else
                                {
                                    Castle.m_MainDoor.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_MainDoor.nX, Castle.m_MainDoor.nY, Castle.m_MainDoor.sName);
                                    if (Castle.m_MainDoor.BaseObject != null)
                                    {
                                        Castle.m_MainDoor.BaseObject.m_WAbil.HP = Castle.m_MainDoor.nHP;
                                        Castle.m_MainDoor.BaseObject.m_Castle = Castle;
                                        M2Share.MainOutMessage("[城堡重载A-4] " + Castle.m_MainDoor.BaseObject.m_sCharName);
                                    }
                                    else
                                    {
                                        M2Share.MainOutMessage("城堡初始化城门失败，检查怪物数据库里有没城门的设置: " + Castle.m_MainDoor.sName);
                                    }
                                }
                            }
                            if (Castle.m_MainDoor.nStatus && (Castle.m_MainDoor.BaseObject != null))
                            {
                                ((TCastleDoor)(Castle.m_MainDoor.BaseObject)).Open();
                            }
                        }
                        else
                        {
                            M2Share.MainOutMessage("城堡初始化城门失败，检查怪物数据库里有没城门的设置: " + Castle.m_MainDoor.sName);
                        }
                        if (Castle.m_LeftWall.BaseObject != null)
                        {
                            if ((!Castle.m_LeftWall.BaseObject.m_boGhost) && (!Castle.m_LeftWall.BaseObject.m_boDeath) && (!Castle.m_LeftWall.BaseObject.m_boFixedHideMode) &&
                                ((Castle.m_LeftWall.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_LeftWall.sName).ToLower()) == 0))
                            {
                                if (Castle.m_LeftWall.BaseObject.m_WAbil.HP <= 0)
                                {
                                    Castle.m_LeftWall.BaseObject.ReAlive();
                                }
                                Castle.m_LeftWall.BaseObject.m_WAbil.HP = Castle.m_LeftWall.nHP;
                                Castle.m_LeftWall.BaseObject.SendRefMsg(Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                                Castle.m_LeftWall.BaseObject.m_Castle = Castle;
                                M2Share.MainOutMessage("[城堡重载B-5] " + Castle.m_LeftWall.BaseObject.m_sCharName);
                            }
                            else
                            {
                                if (Castle.m_LeftWall.BaseObject != null)
                                {
                                    if (((Castle.m_LeftWall.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_LeftWall.sName).ToLower()) == 0))
                                    {
                                        if (!Castle.m_LeftWall.BaseObject.m_boDeath)
                                        {
                                            Castle.m_LeftWall.BaseObject.m_WAbil.HP = Castle.m_LeftWall.BaseObject.m_WAbil.MaxHP;
                                            ((TWallStructure)(Castle.m_LeftWall.BaseObject)).RefStatus();
                                            Castle.m_LeftWall.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载B-1] " + Castle.m_LeftWall.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            Castle.m_LeftWall.BaseObject.m_WAbil.HP = Castle.m_LeftWall.BaseObject.m_WAbil.MaxHP;
                                            Castle.m_LeftWall.BaseObject.ReAlive();
                                            Castle.m_LeftWall.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载B-2] " + Castle.m_LeftWall.BaseObject.m_sCharName);
                                        }
                                    }
                                    else
                                    {
                                        Castle.m_LeftWall.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_LeftWall.nX, Castle.m_LeftWall.nY, Castle.m_LeftWall.sName);
                                        if (Castle.m_LeftWall.BaseObject != null)
                                        {
                                            Castle.m_LeftWall.BaseObject.m_WAbil.HP = Castle.m_LeftWall.nHP;
                                            Castle.m_LeftWall.BaseObject.m_Castle = Castle;
                                            Castle.m_LeftWall.BaseObject.m_nCurrX = Castle.m_LeftWall.nX;
                                            Castle.m_LeftWall.BaseObject.m_nCurrY = Castle.m_LeftWall.nY;
                                            M2Share.MainOutMessage("[城堡重载B-3] " + Castle.m_LeftWall.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            M2Share.MainOutMessage("城堡初始化左城墙失败，检查怪物数据库里有没左城墙的设置: " + Castle.m_LeftWall.sName);
                                        }
                                    }
                                }
                                else
                                {
                                    Castle.m_LeftWall.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_LeftWall.nX, Castle.m_LeftWall.nY, Castle.m_LeftWall.sName);
                                    if (Castle.m_LeftWall.BaseObject != null)
                                    {
                                        Castle.m_LeftWall.BaseObject.m_WAbil.HP = Castle.m_LeftWall.nHP;
                                        Castle.m_LeftWall.BaseObject.m_Castle = Castle;
                                        M2Share.MainOutMessage("[城堡重载B-4] " + Castle.m_LeftWall.BaseObject.m_sCharName);
                                    }
                                    else
                                    {
                                        M2Share.MainOutMessage("城堡初始化左城墙失败，检查怪物数据库里有没左城墙的设置: " + Castle.m_LeftWall.sName);
                                    }
                                }
                            }
                        }
                        else
                        {
                            M2Share.MainOutMessage("城堡初化左城墙失败，检查怪物数据库里有没左城墙的设置: " + Castle.m_LeftWall.sName);
                        }
                        if (Castle.m_CenterWall.BaseObject != null)
                        {
                            if ((!Castle.m_CenterWall.BaseObject.m_boGhost) && (!Castle.m_CenterWall.BaseObject.m_boDeath) && (!Castle.m_CenterWall.BaseObject.m_boFixedHideMode) && ((Castle.m_CenterWall.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_CenterWall.sName).ToLower()) == 0))
                            {
                                if (Castle.m_CenterWall.BaseObject.m_WAbil.HP <= 0)
                                {
                                    Castle.m_CenterWall.BaseObject.ReAlive();
                                }
                                Castle.m_CenterWall.BaseObject.m_WAbil.HP = Castle.m_CenterWall.nHP;
                                Castle.m_CenterWall.BaseObject.SendRefMsg(Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                                Castle.m_CenterWall.BaseObject.m_Castle = Castle;
                                M2Share.MainOutMessage("[城堡重载C-5] " + Castle.m_CenterWall.BaseObject.m_sCharName);
                            }
                            else
                            {
                                if (Castle.m_CenterWall.BaseObject != null)
                                {
                                    if (((Castle.m_CenterWall.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_CenterWall.sName).ToLower()) == 0))
                                    {
                                        if (!Castle.m_CenterWall.BaseObject.m_boDeath)
                                        {
                                            Castle.m_CenterWall.BaseObject.m_WAbil.HP = Castle.m_CenterWall.BaseObject.m_WAbil.MaxHP;
                                            ((TWallStructure)(Castle.m_CenterWall.BaseObject)).RefStatus();
                                            Castle.m_CenterWall.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载C-1] " + Castle.m_CenterWall.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            Castle.m_CenterWall.BaseObject.m_WAbil.HP = Castle.m_CenterWall.BaseObject.m_WAbil.MaxHP;
                                            Castle.m_CenterWall.BaseObject.ReAlive();
                                            Castle.m_CenterWall.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载C-2] " + Castle.m_CenterWall.BaseObject.m_sCharName);
                                        }
                                    }
                                    else
                                    {
                                        Castle.m_CenterWall.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_CenterWall.nX, Castle.m_CenterWall.nY, Castle.m_CenterWall.sName);
                                        if (Castle.m_CenterWall.BaseObject != null)
                                        {
                                            Castle.m_CenterWall.BaseObject.m_WAbil.HP = Castle.m_CenterWall.nHP;
                                            Castle.m_CenterWall.BaseObject.m_Castle = Castle;
                                            Castle.m_CenterWall.BaseObject.m_nCurrX = Castle.m_CenterWall.nX;
                                            Castle.m_CenterWall.BaseObject.m_nCurrY = Castle.m_CenterWall.nY;
                                            M2Share.MainOutMessage("[城堡重载C-3] " + Castle.m_CenterWall.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            M2Share.MainOutMessage("城堡初始化中城墙失败，检查怪物数据库里有没中城墙的设置: " + Castle.m_CenterWall.sName);
                                        }
                                    }
                                }
                                else
                                {
                                    Castle.m_CenterWall.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_CenterWall.nX, Castle.m_CenterWall.nY, Castle.m_CenterWall.sName);
                                    if (Castle.m_CenterWall.BaseObject != null)
                                    {
                                        Castle.m_CenterWall.BaseObject.m_WAbil.HP = Castle.m_CenterWall.nHP;
                                        Castle.m_CenterWall.BaseObject.m_Castle = Castle;
                                        M2Share.MainOutMessage("[城堡重载C-4] " + Castle.m_CenterWall.BaseObject.m_sCharName);
                                    }
                                    else
                                    {
                                        M2Share.MainOutMessage("城堡初始化中城墙失败，检查怪物数据库里有没中城墙的设置: " + Castle.m_CenterWall.sName);
                                    }
                                }
                            }
                        }
                        else
                        {
                            M2Share.MainOutMessage("城堡初始化中城墙失败，检查怪物数据库里有没中城墙的设置: " + Castle.m_CenterWall.sName);
                        }
                        if (Castle.m_RightWall.BaseObject != null)
                        {
                            if ((!Castle.m_RightWall.BaseObject.m_boGhost) && (!Castle.m_RightWall.BaseObject.m_boDeath) && (!Castle.m_RightWall.BaseObject.m_boFixedHideMode) && ((Castle.m_RightWall.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_RightWall.sName).ToLower()) == 0))
                            {
                                if (Castle.m_RightWall.BaseObject.m_WAbil.HP <= 0)
                                {
                                    Castle.m_RightWall.BaseObject.ReAlive();
                                }
                                Castle.m_RightWall.BaseObject.m_WAbil.HP = Castle.m_RightWall.nHP;
                                Castle.m_RightWall.BaseObject.SendRefMsg(Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                                Castle.m_RightWall.BaseObject.m_Castle = Castle;
                                M2Share.MainOutMessage("[城堡重载D-5] " + Castle.m_RightWall.BaseObject.m_sCharName);
                            }
                            else
                            {
                                if (Castle.m_RightWall.BaseObject != null)
                                {
                                    if (((Castle.m_RightWall.BaseObject.m_sCharName).ToLower().CompareTo((Castle.m_RightWall.sName).ToLower()) == 0))
                                    {
                                        if (!Castle.m_RightWall.BaseObject.m_boDeath)
                                        {
                                            Castle.m_RightWall.BaseObject.m_WAbil.HP = Castle.m_RightWall.BaseObject.m_WAbil.MaxHP;
                                            ((TWallStructure)(Castle.m_RightWall.BaseObject)).RefStatus();
                                            Castle.m_RightWall.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载D-1] " + Castle.m_RightWall.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            Castle.m_RightWall.BaseObject.m_WAbil.HP = Castle.m_RightWall.BaseObject.m_WAbil.MaxHP;
                                            Castle.m_RightWall.BaseObject.ReAlive();
                                            Castle.m_RightWall.BaseObject.m_Castle = Castle;
                                            M2Share.MainOutMessage("[城堡重载D-2] " + Castle.m_RightWall.BaseObject.m_sCharName);
                                        }
                                    }
                                    else
                                    {
                                        Castle.m_RightWall.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_RightWall.nX, Castle.m_RightWall.nY, Castle.m_RightWall.sName);
                                        if (Castle.m_RightWall.BaseObject != null)
                                        {
                                            Castle.m_RightWall.BaseObject.m_WAbil.HP = Castle.m_RightWall.nHP;
                                            Castle.m_RightWall.BaseObject.m_Castle = Castle;
                                            Castle.m_RightWall.BaseObject.m_nCurrX = Castle.m_RightWall.nX;
                                            Castle.m_RightWall.BaseObject.m_nCurrY = Castle.m_RightWall.nY;
                                            M2Share.MainOutMessage("[城堡重载D-3] " + Castle.m_RightWall.BaseObject.m_sCharName);
                                        }
                                        else
                                        {
                                            M2Share.MainOutMessage("城堡初始化右城墙失败，检查怪物数据库里有没右城墙的设置: " + Castle.m_RightWall.sName);
                                        }
                                    }
                                }
                                else
                                {
                                    Castle.m_RightWall.BaseObject = UserEngine.RegenMonsterByName(Castle.m_sMapName, Castle.m_RightWall.nX, Castle.m_RightWall.nY, Castle.m_RightWall.sName);
                                    if (Castle.m_RightWall.BaseObject != null)
                                    {
                                        Castle.m_RightWall.BaseObject.m_WAbil.HP = Castle.m_RightWall.nHP;
                                        Castle.m_RightWall.BaseObject.m_Castle = Castle;
                                        M2Share.MainOutMessage("[城堡重载D-4] " + Castle.m_RightWall.BaseObject.m_sCharName);
                                    }
                                    else
                                    {
                                        M2Share.MainOutMessage("城堡初始化右城墙失败，检查怪物数据库里有没右城墙的设置: " + Castle.m_RightWall.sName);
                                    }
                                }
                            }
                        }
                        else
                        {
                            M2Share.MainOutMessage("城堡初始化右城墙失败，检查怪物数据库里有没右城墙的设置: " + Castle.m_RightWall.sName);
                        }
                        for (int K = Castle.m_Archer.GetLowerBound(0); K <= Castle.m_Archer.GetUpperBound(0); K++)
                        {
                            ObjUnit = Castle.m_Archer[K];
                            if (ObjUnit.nHP <= 0)
                            {
                                continue;
                            }
                            if (ObjUnit.BaseObject != null)
                            {
                                ObjUnit.BaseObject.m_WAbil.HP = Castle.m_Archer[K].nHP;
                                ObjUnit.BaseObject.m_Castle = Castle;
                                ((TGuardUnit)(ObjUnit.BaseObject)).m_nX550 = ObjUnit.nX;
                                ((TGuardUnit)(ObjUnit.BaseObject)).m_nY554 = ObjUnit.nY;
                                ((TGuardUnit)(ObjUnit.BaseObject)).m_nDirection = 3;
                            }
                            else
                            {
                                M2Share.MainOutMessage("城堡初始化弓箭手失败，检查怪物数据库里有没弓箭手的设置: " + ObjUnit.sName);
                            }
                        }
                        for (int K = Castle.m_Guard.GetLowerBound(0); K <= Castle.m_Guard.GetUpperBound(0); K++)
                        {
                            ObjUnit = Castle.m_Guard[K];
                            if (ObjUnit.nHP <= 0)
                            {
                                continue;
                            }
                            if (ObjUnit.BaseObject != null)
                            {
                                ObjUnit.BaseObject.m_WAbil.HP = Castle.m_Guard[K].nHP;
                            }
                            else
                            {
                                M2Share.MainOutMessage("城堡初始化守卫失败(检查怪物数据库里有没守卫怪物)");
                            }
                        }
                        if (Castle.m_MapCastle.m_DoorList.Count > 0)
                        {
                            for (int K = 0; K < Castle.m_MapCastle.m_DoorList.Count; K++)
                            {
                                Door = Castle.m_MapCastle.m_DoorList[K];
                                if ((Math.Abs(Door.nX - Castle.m_nPalaceDoorX) <= 3) && (Math.Abs(Door.nY - Castle.m_nPalaceDoorY) <= 3))
                                {
                                    Castle.m_DoorStatus = Door.Status;
                                }
                            }
                        }
                    }
                    else
                    {
                        M2Share.MainOutMessage(string.Format("城堡所在地图不存在(检查地图配置文件里是否有地图{0}的设置)", Castle.m_sMapName));
                    }
                }
                Castle.m_boUnderWar = boUnderWar;
                if (Castle.m_boUnderWar)
                {
                    if (((TCastleDoor)(Castle.m_MainDoor.BaseObject)).m_boOpened)
                    {
                        ((TCastleDoor)(Castle.m_MainDoor.BaseObject)).Close();
                    }
                    if (Castle.m_LeftWall.BaseObject != null)
                    {
                        Castle.m_LeftWall.BaseObject.m_boStoneMode = false;
                    }
                    if (Castle.m_CenterWall.BaseObject != null)
                    {
                        Castle.m_CenterWall.BaseObject.m_boStoneMode = false;
                    }
                    if (Castle.m_RightWall.BaseObject != null)
                    {
                        Castle.m_RightWall.BaseObject.m_boStoneMode = false;
                    }
                }
            }
        }

        // 城堡皇宫所在地图
        public TUserCastle IsCastlePalaceEnvir(TEnvirnoment Envir)
        {
            TUserCastle result = null;
            if (m_CastleList.Count > 0)
            {
                result = m_CastleList.Find(u =>
                {
                    return u.m_MapPalace == Envir;
                });
            }
            return result;
        }


        /// <summary>
        /// 城堡所在地图
        /// </summary>
        /// <param name="Envir"></param>
        /// <returns></returns>
        public TUserCastle IsCastleEnvir(TEnvirnoment Envir)
        {
            TUserCastle result = null;
            if (m_CastleList.Count > 0)
            {
                result = m_CastleList.Find(u =>
                {
                    return u.m_MapCastle == Envir;
                });
                //for (int I = 0; I < m_CastleList.Count; I++)
                //{
                //    Castle = m_CastleList[I];
                //    if (Castle.m_MapCastle == Envir)
                //    {
                //        result = Castle;
                //        break;
                //    }
                //}
            }
            return result;
        }

        /// <summary>
        /// 是城堡成员
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public TUserCastle IsCastleMember(TBaseObject BaseObject)
        {
            TUserCastle result = null;
            TUserCastle Castle;
            if (m_CastleList.Count > 0)
            {
                for (int I = 0; I < m_CastleList.Count; I++)
                {
                    Castle = m_CastleList[I];
                    if (Castle != null)
                    {
                        if (Castle.IsMember(BaseObject))
                        {
                            result = Castle;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public void Run()
        {
            TUserCastle UserCastle;
            //__Lock();
            try
            {
                try
                {
                    if (m_CastleList.Count > 0)
                    {
                        for (int I = 0; I < m_CastleList.Count; I++)
                        {
                            UserCastle = m_CastleList[I];
                            UserCastle.Run();
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TCastleManager.Run");
                }
            }
            finally
            {
                // UnLock();
            }
        }

        public void GetCastleGoldInfo(List<string> List)
        {
            TUserCastle Castle;
            if (m_CastleList.Count > 0)
            {
                for (int I = 0; I < m_CastleList.Count; I++)
                {
                    Castle = m_CastleList[I];
                    //List.Add(HUtil32.Format_Tostr(GameMsgDef.g_sGameCommandSbkGoldShowMsg, Castle.m_sName, Castle.m_nTotalGold, Castle.m_nTodayIncome));
                }
            }
        }


        public void Save()
        {
            SaveCastleList();
            if (m_CastleList.Count > 0)
            {
                foreach (var item in m_CastleList)
                {
                    item.Save();
                }
            }
        }

        public void LoadCastleList()
        {
            TStringList LoadList;
            TUserCastle Castle;
            string sCastleDir;
            if (File.Exists(M2Share.g_Config.sCastleFile))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(M2Share.g_Config.sCastleFile);
                if (LoadList.Count > 0)
                {
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        sCastleDir = LoadList[I].Trim();
                        if (sCastleDir != "")
                        {
                            Castle = new TUserCastle(sCastleDir);
                            m_CastleList.Add(Castle);
                        }
                    }
                }
                Dispose(LoadList);
                M2Share.OutInfoMessage("已读取 [" + m_CastleList.Count + "] 个城堡信息...");
            }
            else
            {
                M2Share.MainOutMessage("城堡列表文件未找到！！！");
            }
        }

        public void SaveCastleList()
        {
            TStringList LoadList;
            try
            {
                if (!Directory.Exists(M2Share.g_Config.sCastleDir))
                {
                    Directory.CreateDirectory(M2Share.g_Config.sCastleDir);
                }
                if (m_CastleList.Count > 0)
                {
                    LoadList = new TStringList();
                    for (int I = 0; I < m_CastleList.Count; I++)
                    {
                        LoadList.Add(Convert.ToString(I));
                    }
                    LoadList.SaveToFile(M2Share.g_Config.sCastleFile);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} CastleManager.SaveCastleList..." + M2Share.g_Config.sCastleFile);
            }
        }

        public TUserCastle GetCastle(int nIndex)
        {
            TUserCastle result = null;
            if ((nIndex >= 0) && (nIndex < m_CastleList.Count))
            {
                result = m_CastleList[nIndex];
            }
            return result;
        }

        public void GetCastleNameList(List<string> List)
        {
            TUserCastle Castle;
            if (m_CastleList.Count > 0)
            {
                for (int I = 0; I < m_CastleList.Count; I++)
                {
                    Castle = m_CastleList[I];
                    List.Add(Castle.m_sName);
                }
            }
        }

        public void IncRateGold(int nGold)
        {
            TUserCastle Castle;
            //__Lock();
            try
            {
                if (m_CastleList.Count > 0)
                {
                    for (int I = 0; I < m_CastleList.Count; I++)
                    {
                        Castle = m_CastleList[I];
                        Castle.IncRateGold(nGold);
                    }
                }
            }
            finally
            {
                //UnLock();
            }
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}