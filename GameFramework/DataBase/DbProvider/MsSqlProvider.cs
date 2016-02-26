using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    public class MsSqlProvider : DbProvider
    {
        public MsSqlProvider(string connectionString)
            : this(connectionString, SqlClientFactory.Instance)
        {
        }

        public MsSqlProvider(string connectionString, DbProviderFactory dbFactory)
            : base(connectionString, dbFactory, '[', ']', '@')
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