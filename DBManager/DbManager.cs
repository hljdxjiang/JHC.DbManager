using System.Collections;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace JHC.DbManager
{
    public class DbManager
    {
        public DbManager()
        {
        }

        private SortedList  list=new SortedList();

        private static DbManager _instance;
        public static DbManager Instance{
            get {
                if (_instance == null) {
                    lock (typeof(DbManager)) {
                        if (_instance == null) {
                            _instance = new DbManager();
                        }
                    }
                }
                return _instance;
            }
        }
        public bool Init(string path) {
            var b = false;
            var config = new ConfigurationBuilder().AddJsonFile(path)
                .Build();
  
            var dbline = config.GetSection("dbManager").GetChildren();
            var sub = dbline.GetEnumerator();
            foreach (IConfigurationSection i in dbline) {
                System.Console.WriteLine(i.Value);
                string id = i.GetSection("id").Value;
                System.Console.WriteLine("id is "+id);
                string dbtype = i.GetSection("dbtype").Value;
                string ip = i.GetSection("ip").Value;
                string port = i.GetSection("port").Value;
                string instance = i.GetSection("instance").Value;
                string uname = i.GetSection("uname").Value;
                string passwd = i.GetSection("passwd").Value;
                IDbConnection conn = null;
                string connString = "";
                if (dbtype.ToLower() == "mysql")
                {
                    connString = "server=" + ip + ";userid=" + uname + ";pwd=" + passwd + ";port=" + port + ";database=" + instance + ";SslMode=none";
                    conn = new MySqlConnection(connString);
                    System.Console.WriteLine(connString);
                }
                else if (dbtype.ToLower() == "oracle")
                {
                    connString = "User ID=" + uname + ";Password=" + passwd + ";Data Source=" + ip + ":" + port + "/" + instance;
                    conn = new OracleConnection(connString);
                }
                if (conn != null)
                {
                    System.Console.WriteLine("conn is not null");
                    if (!list.ContainsKey(id))
                    {
                        list.Add(id, conn);
                    }
                }
            }
            return b;
        }

        public IDbConnection GetDbControl(string id) {
            if (list.ContainsKey(id))
            {
                System.Console.WriteLine("GetDbControl conn is not null");
                return (IDbConnection)list[id];
            }
            return null;
        }
    }
}
