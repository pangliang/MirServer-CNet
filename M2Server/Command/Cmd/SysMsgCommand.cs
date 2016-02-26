using GameFramework;
using GameFramework.Command;
using GameFramework.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Command.Cmd
{
    [GameCommand("SysMsg", "千里传音", 0)]
    public class SysMsgCommand:BaseCommond
    {
        [DefaultCommand]
        public unsafe void SysMsg(TPlayObject PlayObject,string[] @Params)
        {
            string Text = @Params.Length > 0 ? @Params[0] : "";

            TStdItem* AmuletStdItem;
            TPlayObject PlayObjectA;
            if (Text == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 发布信息", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            M2Share.IsFilterMsg(ref Text);// 文字过滤
            if (PlayObject.m_UseItems[TPosition.U_CHARM]->wIndex > 0)
            {
                AmuletStdItem = UserEngine.GetStdItem(PlayObject.m_UseItems[TPosition.U_CHARM]->wIndex);
                if ((AmuletStdItem != null) && (AmuletStdItem->StdMode == 7) && (AmuletStdItem->Shape == 0)) // 物品是千里传音
                {
                    if (PlayObject.m_UseItems[TPosition.U_CHARM]->Dura >= 1000)
                    {
                        PlayObject.m_UseItems[TPosition.U_CHARM]->Dura -= 1000;
                        PlayObject.SendMsg(PlayObject, Grobal2.RM_DURACHANGE, TPosition.U_CHARM, PlayObject.m_UseItems[TPosition.U_CHARM]->Dura, PlayObject.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");// 减少持久数
                        try
                        {
                            //千里传音 的字的颜色
                            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                            for (int I = 0; I < UserEngine.m_PlayObjectList.Count; I++)
                            {
                                PlayObjectA = UserEngine.m_PlayObjectList[I];
                                if (PlayObjectA != null)
                                {
                                    if (!PlayObjectA.m_boGhost)
                                    {
                                        PlayObjectA.SysMsg(PlayObject.m_sCharName + ":" + Text, TMsgColor.c_Fuchsia, TMsgType.t_Say);
                                    }
                                }
                            }
                        }
                        finally
                        {
                            HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
                        }
                        if (PlayObject.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                        {
                            PlayObject.SendDelItems(PlayObject.m_UseItems[TPosition.U_CHARM]);// 如果使用完，则删除物品
                            PlayObject.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                            PlayObject.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                        }
                    }
                    else
                    {
                        PlayObject.SendDelItems(PlayObject.m_UseItems[TPosition.U_CHARM]); // 如果使用完，则删除物品
                        PlayObject.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                        PlayObject.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                    }
                }
            }
            else
            {
                PlayObject.SysMsg("没有千里传音,或没有穿上装备栏里。", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}
