using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBServer.Entity
{
        public struct TScriptConfig
        {
            public string[] sPlugName;

            // 'MakeGM脚本扩展插件';
            public string[] sLoadPlugSucced;

            // '加载MakeGM脚本扩展插件成功...';
            public string[] sLoadPlugFail;

            // '加载MakeGM脚本扩展插件失败...';
            public string[] sUnLoadPlug;

            // '卸载MakeGM扩展扩展插件成功...';
            public string[] sLabelMsg;

            public string[] sPassWord;
            public int nOwnerNumber;

            // QQ号码
            public int nUserNumber;

            // QQ号码
            public int nVersion;

            public int nSize;
            public uint nCrc;
            public bool boShareMode;
            public DateTime nBeginDate;
            public DateTime nEndDate;
            public string[] sSerialNumber;
        } // end TScriptConfig
}
