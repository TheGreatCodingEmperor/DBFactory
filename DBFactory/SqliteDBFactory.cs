using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Text;

namespace DBFactory
{
    class SqliteDBFactory : DBAbstractFactory,ISerializable
    {
        private string drivertype { get; set; }
        public SqliteDBFactory() { this.drivertype = null; }
        public override IDbConnection CreateConnection(string connstr)
        {
            if (connstr == null || connstr.Length == 0)
            {
                return null;
            }
            return new SQLiteConnection(connstr);
        }
        public override IDbCommand CreateCommand(IDbConnection con, string cmd)
        {
            if (con == null || cmd == null || cmd.Length == 0)
            {
                return null;
            }
            if(con is SQLiteConnection)
            {
                return new SQLiteCommand(cmd, (SQLiteConnection)con);
            }
            return null;
        }
        public override IDbDataAdapter CreateDbAdapter(IDbCommand cmd)
        {
            if(cmd == null) { return null; }
            if(cmd is SQLiteCommand)
            {
                return new SQLiteDataAdapter((SQLiteCommand)cmd);   
            }
            return null;
        }
        public override IDataReader CreateDataReader(IDbCommand cmd)
        {
            if (cmd == null) { return null; }
            if(cmd is SQLiteCommand)
            {
                return (SQLiteDataReader)cmd.ExecuteReader();
            }
            return null;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        protected SqliteDBFactory(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
