using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace testing
{
    class csResidents
    {        
        public void InsertData()
        {
            try {

                csConnection cs = new csConnection();

                String table, query, value, finalquery;

                table = "(Fname, Mname, Lname, Sname, Birthplace, Birthdate, CivilStatus, Gender, id_purok, VoterStatus, DateOfRegistration, ContactNo, CedulaNo, Email, Image)";
                query = "(SELECT id_purok FROM tbl_purok WHERE Name = '" + Purok +"')";
                value = Fname + "','" + Mname + "','" + Lname +"','"+ Sname +"','"+ BirthPlace +"','"+ BirthDate + "','" + CivilStatus +"','"+ Gender +"',"+ query +",'"+ VoterStatus + "','" + DateOfRegistration +"','"+ ContactNo + "','" + CedulaNo + "','" + Email + "','" + Image;
                finalquery = "INSERT INTO "+ cs.DBname() +".tbl_residentinfo" + table + " VALUES('" + value + "');";


                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand(finalquery, cs.conn);
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
            }
            catch (Exception e) {
                Message = e.Message;
            }
        }

        public void UpdateData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "UPDATE ibarangaydb.tbl_residentinfo " +
                               "SET columename1='', " +
                               "WHERE id_resident =";
                
                
                cs.conn.Open();
                MySqlCommand command = new MySqlCommand(query, cs.conn);
                if (command.ExecuteNonQuery() == 1)
                {
                    Message = "Successfully Updated";
                }
                else
                {
                    Message = "Failed to Update";
                }

            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }

        public void ResetData()
        {
            Message = "";
            Fname = "";
            Mname = "";
            Lname = "";
            Sname = "";
            BirthDate = "";
            BirthPlace = "";
            CivilStatus = "";
            Gender = "";
            Purok = "";
            VoterStatus = "";
            CedulaNo = "";
            ContactNo = "";
            Email = "";
            DateOfRegistration = "";
            Image = "";
        }

        public string Message { get; set; }

        public string Fname { get; set; }

        public string Mname { get; set; }

        public string Lname { get; set; }

        public string Sname { get; set; }

        public string BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string CivilStatus { get; set; }

        public string Gender { get; set; }

        public string Purok { get; set; }

        public string VoterStatus { get; set; }

        public string CedulaNo { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }

        public string DateOfRegistration { get; set; }

        public string Image { get; set; }

    }
}
