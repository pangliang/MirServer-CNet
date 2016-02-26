using GameFramework;
using GameFramework.Command;
using System;
using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// 显示你屏幕上你近处所有怪与人的详细情况
    /// </summary>
    [GameCommand("MobLevel", "显示你屏幕上你近处所有怪与人的详细情况", 10)]
    public class MobLevelCommand : BaseCommond
    {
        [DefaultCommand]
        public void MobLevel(TPlayObject PlayObject,string[] @Params)
        {
            string Param = @Params.Length > 0 ? @Params[0] : "";
            IList<TPlayObject> BaseObjectList;
            TBaseObject BaseObject;
            if (((Param != "") && (Param[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, new string[] { this.Attributes.Name, "" }), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            BaseObjectList = new List<TPlayObject>();
            PlayObject.m_PEnvir.GetRangeBaseObject(PlayObject.m_nCurrX, PlayObject.m_nCurrY, 2, true, BaseObjectList);
            for (int I = 0; I < BaseObjectList.Count; I++)
            {
                BaseObject = BaseObjectList[I];
                PlayObject.SysMsg(BaseObject.GeTBaseObjectInfo(), TMsgColor.c_Green, TMsgType.t_Hint);
            }
            HUtil32.Dispose(BaseObjectList);
        }
    }
}