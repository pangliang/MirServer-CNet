using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    interface IDbTrans : IDbProcess
    {
        #region Process操作

        DbBatch BeginBatch();
        DbBatch BeginBatch(int batchSize);

        #endregion
 
    }
}
