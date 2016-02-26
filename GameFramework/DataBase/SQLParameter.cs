using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    /// <summary>
    /// SQL命令的参数
    /// </summary>
    [Serializable]
    public class SQLParameter
    {
        /// <summary>
        /// 参数名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 参数方向
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// 初始化OrmParameter
        /// </summary>
        /// <param name="pName"></param>
        public SQLParameter(string pName)
        {
            this.Name = pName;
            this.Direction = ParameterDirection.Input;
        }

        /// <summary>
        /// 初始化OrmParameter
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        public SQLParameter(string pName, object pValue)
            : this(pName)
        {
            this.Value = pValue;
        }
    }
}
