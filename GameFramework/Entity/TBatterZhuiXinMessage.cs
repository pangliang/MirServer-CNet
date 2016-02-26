namespace GameFramework
{
    /// <summary>
    /// 连击 追心刺消息结构体
    /// </summary>
    public unsafe struct TBatterZhuiXinMessage
    {
        public TDefaultMessage* Defmsg;
        public TCharDesc desc;
        public int X;
        public int Y;
        public byte dir;
    }
}