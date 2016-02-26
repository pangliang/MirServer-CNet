using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    /// <summary>
    /// MsSql数据库驱动
    /// </summary>
    public class MsSql : MsSqlProvider
    {
        public MsSql(string connectionString)
            : base(connectionString)
        {
        }

        protected internal override bool SupportBatch
        {
            get { throw new NotImplementedException(); }
        }

        protected override string RowAutoID
        {
            get { throw new NotImplementedException(); }
        }

        protected override DbParameter CreateParameter(string parameterName, object val)
        {
            throw new NotImplementedException();
        }
    }
}
