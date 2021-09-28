using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csAccountMngmnt
    {
        csConnection cs = new csConnection();

        public void updateAccount()
        {
            try
            {
                if (Status == "Enabled")
                    Status = "false";
                else
                    Status = "true";

                String query = "UPDATE " + cs.DBname() + ".tbl_account SET Username= @uname, Password =@pass, Status=@stat " +
                    "WHERE id_account = @id";
                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@uname", Username);
                cmd.Parameters.AddWithValue("@pass", Password);
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
                String query = "SELECT a.Username, a.Password, r.Fname, r.Mname, r.Lname ,r.Sname " +
                    "FROM tbl_account AS a INNER JOIN tbl_residentinfo AS r ON r.id_resident = a.id_resident " +
                    "WHERE a.id_account = '"+ID+"'";

                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Username = rdr[0].ToString();
                    Password = rdr[1].ToString();
                    Fullname = rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString() +" "+ rdr[5].ToString();
                    
                }

                cmd.Dispose();
                cs.conn.Close();
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
            Status = "";
        }

        public string Message { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Status { private get; set; }


        private static string ID;
        public void getID(String id)
        {
            ID = id;
        }

    }
}
