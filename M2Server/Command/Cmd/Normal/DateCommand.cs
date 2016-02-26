using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("Date","查询当前时间",0)]
    public class DateCommand:BaseCommond
    {
        [DefaultCommand]
        public void Date(TPlayObject PlayObject,string[] @Params)
        {
            PlayObject.SysMsg(GameMsgDef.g_sNowCurrDateTime + string.Format("{0:yyyy-MM-dd hh:mm:nn}", DateTime.Now), TMsgColor.c_Blue, TMsgType.t_Hint);
        }
    }
}
