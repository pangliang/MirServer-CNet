using System;

namespace GameFramework
{
    /// <summary>
    /// 角色数据
    /// </summary>
    public class THumInfo //Size 72
    {
        public TRecordHeader Header;
        public string[] sChrName;

        // 0x14  //角色名称   44
        public string[] sAccount;

        // 账号
        public bool boDeleted;

        // 是否删除
        public byte bt1;

        // 未使用
        public DateTime dModDate;

        // 操作日期
        public byte btCount;

        // 操作计次
        public bool boSelected;

        // 是否是选择的人物
        public byte[] n6;
    }
}