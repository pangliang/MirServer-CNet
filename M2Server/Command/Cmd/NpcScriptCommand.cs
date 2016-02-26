using GameFramework;
using GameFramework.Command;
using System;
using System.IO;

namespace M2Server
{
    [GameCommand("NpcScript", "不知道做什么的", 10)]
    public class NpcScriptCommand : BaseCommond
    {
        [DefaultCommand]
        public void NpcScript(TPlayObject PlayObject,string[] @Params)
        {
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sParam1 = @Params.Length > 1 ? @Params[1] : "";
            string sParam2 = @Params.Length > 2 ? @Params[2] : "";
            string sParam3 = @Params.Length > 3 ? @Params[3] : "";

            TBaseObject BaseObject;
            int nNPCType;
            string sScriptFileName = string.Empty;
            TMerchant Merchant;
            TNormNpc NormNpc;
            TStringList LoadList;
            string sScriptLine;

            if ((sParam1 == "") || ((sParam1 != "") && (sParam1[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandNpcScriptHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            nNPCType = -1;
            BaseObject = PlayObject.GetPoseCreate();
            if (BaseObject != null)
            {
                for (int I = 0; I < UserEngine.m_MerchantList.Count; I++)
                {
                    if (((UserEngine.m_MerchantList[I]) as TBaseObject) == BaseObject)
                    {
                        nNPCType = 0;
                        break;
                    }
                }
                for (int I = 0; I < UserEngine.QuestNPCList.Count; I++)
                {
                    if (((UserEngine.QuestNPCList[I]) as TBaseObject) == BaseObject)
                    {
                        nNPCType = 1;
                        break;
                    }
                }
            }
            if (nNPCType < 0)
            {
                PlayObject.SysMsg("命令使用方法不正确，必须与NPC面对面，才能使用此命令！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (sParam1 == "")
            {
                if (nNPCType == 0)
                {
                    Merchant = ((TMerchant)(BaseObject));
                    sScriptFileName = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def + Merchant.m_sScript + "-" + Merchant.m_sMapName + ".txt";
                }
                if (nNPCType == 1)
                {
                    NormNpc = ((TNormNpc)(BaseObject));
                    sScriptFileName = M2Share.g_Config.sEnvirDir + M2Share.sNpc_def + NormNpc.m_sCharName + "-" + NormNpc.m_sMapName + ".txt";
                }
                if (File.Exists(sScriptFileName))
                {
                    LoadList = new TStringList();
                    try
                    {
                        LoadList.LoadFromFile(sScriptFileName);
                    }
                    catch
                    {
                        PlayObject.SysMsg("读取脚本文件错误: " + sScriptFileName, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        sScriptLine = LoadList[I].Trim();
                        sScriptLine = HUtil32.ReplaceChar(sScriptLine, ' ', ',');
                        PlayObject.SysMsg(I + "," + sScriptLine, TMsgColor.c_Blue, TMsgType.t_Hint);
                    }

                    HUtil32.Dispose(LoadList);
                }
            }
        }
    }
}