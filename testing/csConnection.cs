using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace testing
{
    class csConnection
    {
        csHostConfiguration host = new csHostConfiguration();
        public MySqlConnection conn;
        public MySqlCommand command;
        private string newDBname = "sql6439916", oldDBname = "ibarangaydb";

        public csConnection()
        {
            String connection ="";
            if (hostname == "" && user == "" && pwd == "" && db == "" ) {
                fetchCount();
                Console.WriteLine("fetch");
            }
            else
            {
                connection = "server=" + hostname + ";port=3306;username=" + user + ";password=" + pwd + ";database=" + db + ";sslmode=none";
                conn = new MySqlConnection(connection);
                Console.WriteLine("not fetch");
            }
            //String connection = "server=localhost;port=3306;username=root;password=;database=ibarangaydb;sslmode=none";
            //String connection2 = "server=sql6.freemysqlhosting.net;port=3306;username=sql6439916;password=pU3V3LZ6vd;database=sql6439916;sslmode=none";
            //conn = new MySqlConnection(connection);
        }

        public string DBname()
        {
            return db;
        }

        private static string hostname="", user = "", pwd = "", db = "";
        private async void fetchCount()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_blotter_config.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                hostname = JObject.Parse(responseBody)["host"].ToString();
                user = JObject.Parse(responseBody)["user"].ToString();
                pwd = JObject.Parse(responseBody)["pwd"].ToString();
                db = JObject.Parse(responseBody)["db"].ToString();


                String connection = "server=" + hostname + ";port=3306;username=" + user + ";password=" + pwd + ";database=" + db + ";sslmode=none";
                conn = new MySqlConnection(connection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //public void Backup()
        //{
        //    try
        //    {
        //        string constring = "server=localhost;user=root;database=bookingdb;pooling = false;convert zero datetime=True";
        //        string file = "C:\\backupBookingSql.sql";
        //        using (MySqlConnection conn = new MySqlConnection(constring))
        //        {
        //            using (MySqlCommand cmd = new MySqlCommand())
        //            {
        //                using (MySqlBackup mb = new MySqlBackup(cmd))
        //                {
        //                    cmd.Connection = conn;
        //                    conn.Open();
        //                    mb.ExportToFile(file);
        //                    conn.Close();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        Console.WriteLine(err.Message);
        //    }
        //}

        //public void Restore()
        //{
        //    string constring = "server=localhost;user=root;database=bookingdb;";
        //    string file = "C:\\backup.sql";
        //    using (MySqlConnection conn = new MySqlConnection(constring))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand())
        //        {
        //            using (MySqlBackup mb = new MySqlBackup(cmd))
        //            {
        //                cmd.Connection = conn;
        //                conn.Open();
        //                mb.ImportFromFile(file);
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

    }
}
