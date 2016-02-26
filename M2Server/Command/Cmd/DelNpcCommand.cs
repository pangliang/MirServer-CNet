using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 删除对面面NPC
    /// </summary>
    [GameCommand("DelNpc", "删除对面面NPC", 10)]
    public class DelNpcCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelNpc(TPlayObject PlayObject,string[] @Params)
        {
            if (@Params == null)
            {
                return;
            }
            int nPermission = @Params.Length > 0 ? int.Parse(@Params[0]) : 0;
            string sParam1 = @Params.Length > 1 ? @Params[1] : "";
            TBaseObject BaseObject;
            const string sDelOK = "删除NPC成功...";
            if (((sParam1 != "") && (sParam1[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, new string[] { this.Attributes.Name, "" }), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            BaseObject = PlayObject.GetPoseCreate();
            if (BaseObject != null)
            {
                for (int I = 0; I < UserEngine.m_MerchantList.Count; I++)
                {
                    if (((UserEngine.m_MerchantList[I]) as TBaseObject) == BaseObject)
                    {
                        BaseObject.m_boGhost = true;

                        BaseObject.m_dwGhostTick = HUtil32.GetTickCount();
                        BaseObject.SendRefMsg(Grobal2.RM_DISAPPEAR, 0, 0, 0, 0, "");
                        PlayObject.SysMsg(sDelOK, TMsgColor.c_Red, TMsgType.t_Hint);
                        return;
                    }
                }
                for (int I = 0; I < UserEngine.QuestNPCList.Count; I++)
                {
                    if (((UserEngine.QuestNPCList[I]) as TBaseObject) == BaseObject)
                    {
                        BaseObject.m_boGhost = true;

                        BaseObject.m_dwGhostTick = HUtil32.GetTickCount();
                        BaseObject.SendRefMsg(Grobal2.RM_DISAPPEAR, 0, 0, 0, 0, "");
                        PlayObject.SysMsg(sDelOK, TMsgColor.c_Red, TMsgType.t_Hint);
                        return;
                    }
                }
            }
            PlayObject.SysMsg(GameMsgDef.g_sGameCommandDelNpcMsg, TMsgColor.c_Red, TMsgType.t_Hint);
        }
    }
}