using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.Json.Serialization;

namespace DBFactory
{
    class Program
    {
        static dynamic ColValue(DataRow row, string col)
        {
            object[] columns = row.ItemArray;
            return row.Field<dynamic>(col);
        }
        static void Main(string[] args)
        {
            var postGre = new PostGreDBFactory();
            var connect = postGre.CreateConnection("User ID=postgres;Password=1234567;Host=192.168.99.100;Port=5432;Database=postgres;");
            try
            {
                connect.Open();
                var cmd = postGre.CreateCommand((DbConnection)connect, "select * from public.test;");
                var reader = postGre.CreateDataReader((DbCommand)cmd);

                //MySqlDataAdapter adapter = (MySqlDataAdapter)maria.CreateDbAdapter(cmd);
                DataTable ds = new DataTable();

                //adapter.Fill(ds);
                ds.Load(reader);

                var rows = ds.AsEnumerable().Select(p => p.Table).FirstOrDefault();

                Console.WriteLine(JsonConvert.SerializeObject(rows));
            }
            catch(Exception e)
            {
                e.ToString();
            }
            connect.Close();
        }
    }
}
