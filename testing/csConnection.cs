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
        
        public csConnection()
        {
            String connection = "server=localhost;port=3306;username=root;password=;database=ibarangaydb;sslmode=none";
            String connection2 = "server=sql6.freemysqlhosting.net;port=3306;username=sql6428094;password=ZWQtrHpqH6;database=sql6428094;sslmode=none";
            conn = new MySqlConnection(connection);
        }

    }
}
