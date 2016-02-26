using GameFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.Repository
{
    public class SqlServer2005Repository : SessionRepository
    {
        public SqlServer2005Repository(string connectionName)
            : base(connectionName)
        { }

        public override ProviderType GetProviderType()
        {
            return ProviderType.SqlServer9;
        }
    }
}
