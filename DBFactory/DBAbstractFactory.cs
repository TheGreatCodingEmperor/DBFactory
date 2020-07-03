using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DBFactory
{
    public abstract class DBAbstractFactory
    {
        public abstract IDbConnection CreateConnection(string connstr);
        public abstract IDbCommand CreateCommand(IDbConnection con, string cmd);
        public abstract IDbDataAdapter CreateDbAdapter(IDbCommand cmd);
        public abstract IDataReader CreateDataReader(IDbCommand cmd);
    }
}
