using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csUserMngmnt
    {
        csConnection cs = new csConnection();

        public void addUser()
        {
            try
            {
                String query = "INSERT INTO "+cs.DBname()+".tbl_users(Username, Password, Fullname, LevelOfAccess, Status) " +
                    "VALUES(@uname, @pass, @fname, @access, @stat)";

                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@uname", Username);
                cmd.Parameters.AddWithValue("@pass", Password);
                cmd.Parameters.AddWithValue("@fname", Fullname);
                cmd.Parameters.AddWithValue("@access", LevelOfAccess);
                cmd.Parameters.AddWithValue("@stat", 0);
                cmd.Connection = cs.conn;
                if (cmd.ExecuteNonQuery()==1)
                {
                    Message = "Successfully Added";
                }
                else
                {
                    Message = "Failed to Add";
                }

                cmd.Dispose();
                cs.conn.Close();
            }catch(Exception e)
            {
                Message = e.Message;
            }
        }

        public void updateUser()
        {
            try
            {
                if (Status == "Enabled")
                    Status = "false";
                else
                    Status = "true";

                String query = "UPDATE " + cs.DBname() + ".tbl_users SET Username= @uname, Password =@pass, Fullname =@fname, LevelOfAccess=@access,Status=@stat " +
                    "WHERE id_users = @id";
                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@uname",Username);
                cmd.Parameters.AddWithValue("@pass",Password);
                cmd.Parameters.AddWithValue("@fname", Fullname);
                cmd.Parameters.AddWithValue("@access",LevelOfAccess);
                cmd.Parameters.AddWithValue("@stat", bool.Parse(Status));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt16(ID));
                cmd.Connection = cs.conn;

                if (cmd.ExecuteNonQuery() >= 1)
                {
                    Message = "Successfully Updated";
                }
                else
                {
                    Message = "Failed to Update";
                }
                cmd.Dispose();
                cs.conn.Close();

            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }

        public void retrieveData()
        {
            try
            {
                String query = "SELECT Username, Password, Fullname FROM tbl_users WHERE id_users = '"+ID+"'";

                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Username = rdr[0].ToString();
                    Password = rdr[1].ToString();
                    Fullname = rdr[2].ToString();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void Reset()
        {
            Message = "";
            ID = "";
            Username = "";
            Password = "";
            Fullname = "";
            LevelOfAccess = "";
            Status = "";
        }

        public string Message{ get; private set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public string Fullname{ get; set; }
        public string LevelOfAccess{ private get; set; }
        public string Status{ private get; set; }


        private static string ID;
        public void getID(String id)
        {
            ID = id;
        }

    }
}
