using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace testing
{
    class csConnection
    {

        public MySqlConnection conn;
        public MySqlCommand command;
        private string newDBname = "sql6439916", oldDBname = "ibarangaydb";

        public csConnection()
        {
            String connection = "server=localhost;port=3306;username=root;password=;database=ibarangaydb;sslmode=none";
            String connection2 = "server=sql6.freemysqlhosting.net;port=3306;username=sql6439916;password=pU3V3LZ6vd;database=sql6439916;sslmode=none";
            conn = new MySqlConnection(connection2);
        }

        public string DBname()
        {
            return newDBname;
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
