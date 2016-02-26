using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    interface IDbProcess
    {

    }

    interface IDbBatch : IDbProcess
    {
        /// <summary>
        /// 执行批处理操作
        /// </summary>
        int Process();

        /// <summary>
        /// 执行批处理操作
        /// </summary>
        /// <param name="errors">输出的错误</param>
        /// <returns></returns>
        int Process(out IList<Exception> errors);
    }
}