using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("StartQuest", "", 10)]
    public class StartQuestCommand : BaseCommond
    {
        [DefaultCommand]
        public void StartQuest(TPlayObject PlayObject,string[] @Params)
        {
            string sQuestName = @Params.Length > 0 ? @Params[0] : "";
            if ((sQuestName == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 问答名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            UserEngine.SendQuestMsg(sQuestName);
        }
    }
}