using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace testing
{
    class csLogin
    {
        private csConnection cs = new csConnection();
        private string uname,pass;

        public void Login(String uname, String pass)
        {
            this.uname = uname;
            this.pass = pass;
            log();
        }

        private void log()
        {
            try
            {
                cs.conn.Open();
                String query = "SELECT COUNT(*), LevelOfAccess FROM tbl_users WHERE Username = @uname AND Password= @pass AND Status = @stat";
                cs.command = new MySqlCommand();
                cs.command.CommandText = query;
                cs.command.Parameters.AddWithValue("@uname", uname);
                cs.command.Parameters.AddWithValue("@pass", pass);
                cs.command.Parameters.AddWithValue("@stat", 0);
                cs.command.Connection =cs.conn;

                MySqlDataReader rdr = cs.command.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr[0].ToString() =="1")
                    {
                        Message = "Successfully Login.";
                        ready = rdr[1].ToString();
                        //if (rdr[1].ToString() == "Admin")
                        //{
                        //    frmMenuAdmin frm = new frmMenuAdmin();
                        //    frm.Show();
                        //}
                        //else if (rdr[1].ToString() == "Employee")
                        //{
                        //    frmMenu frm = new frmMenu();
                        //    frm.Show();
                        //}
                    }
                    else
                    {
                        Message = "Username or Password is incorrect!";
                    }
                }
            }
            catch(Exception e)
            {
                Message = e.Message;
            }
        }

        public void Reset()
        {
            ready = "";
            Message = "";
        }


        private static string ready;

        public String GetReady()
        {
            return ready;
        }
        public String GetUtype1()
        {
            return "Admin";
        }
        public String GetUtype2()
        {
            return "Employee";
        }

        public string Message{ get; private set; }

    }
}
