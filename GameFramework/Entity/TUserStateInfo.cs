namespace GameFramework
{
    public unsafe struct TUserStateInfo
    {
        public int feature;
        public byte UserNameLen;
        public fixed sbyte UserName[14];
        public int NameColor;
        public byte GuildNameLen;
        public fixed sbyte GuildName[14];
        public byte GuildRankNameLen;
        public fixed sbyte GuildRankName[16];
        public fixed sbyte UseItemsBuff[14 * 72];
    }
}