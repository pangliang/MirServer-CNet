using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    /// <summary>
    /// Access数据库驱动
    /// </summary>
    public class Access : DbProvider
    {
        public Access(string connectionString)
            : base(connectionString, OleDbFactory.Instance, '[', ']', '@')
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

        protected override System.Data.Common.DbParameter CreateParameter(string parameterName, object val)
        {
            throw new NotImplementedException();
        }
    }
}
