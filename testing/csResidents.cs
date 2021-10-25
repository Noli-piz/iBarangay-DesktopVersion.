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

        csConnection cs = new csConnection();

        public void InsertData()
        {
            try {

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
                String query = "UPDATE "+cs.DBname()+".tbl_residentinfo " +
                               "SET Fname=@fname, Mname=@mname, Lname=@lname, Sname=@sname, Birthplace=@bplace, Birthdate=@bday, CivilStatus=@cstatus, Gender=@gender, " +
                               "id_purok=(SELECT id_purok FROM tbl_purok WHERE Name =@purok ), VoterStatus=@vstatus, CedulaNo=@cedno, ContactNo=@conno, Email=@email, " +
                               "DateOfRegistration=@dor, Image=@img " +
                               "WHERE id_resident =@id";
                
                
                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@fname",Fname);
                cmd.Parameters.AddWithValue("@mname",Mname);
                cmd.Parameters.AddWithValue("@lname",Lname);
                cmd.Parameters.AddWithValue("@sname",Sname);
                cmd.Parameters.AddWithValue("@bday",BirthDate);
                cmd.Parameters.AddWithValue("@bplace",BirthPlace);
                cmd.Parameters.AddWithValue("@cstatus",CivilStatus);
                cmd.Parameters.AddWithValue("@gender",Gender);
                cmd.Parameters.AddWithValue("@purok",Purok);
                cmd.Parameters.AddWithValue("@vstatus",VoterStatus);
                cmd.Parameters.AddWithValue("@cedno",CedulaNo);
                cmd.Parameters.AddWithValue("@conno",ContactNo);
                cmd.Parameters.AddWithValue("@email",Email);
                cmd.Parameters.AddWithValue("@dor",DateOfRegistration);
                cmd.Parameters.AddWithValue("@img",Image);
                cmd.Parameters.AddWithValue("@id",strID);
                cmd.Connection = cs.conn;

                if (cmd.ExecuteNonQuery() == 1)
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
                String query = "SELECT *,(SELECT Name FROM tbl_purok WHERE id_purok = r.id_purok)  FROM tbl_residentinfo AS r WHERE id_resident='" + strID+"'";
                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Fname = rdr[1].ToString();
                    Mname = rdr[2].ToString();
                    Lname = rdr[3].ToString();
                    Sname = rdr[4].ToString();
                    BirthPlace = rdr[5].ToString();
                    BirthDate = rdr[6].ToString();
                    CivilStatus = rdr[7].ToString();
                    Gender = rdr[8].ToString();
                    //Sname = rdr[9].ToString();
                    VoterStatus = rdr[10].ToString();
                    DateOfRegistration = rdr[11].ToString();
                    ContactNo = rdr[12].ToString();
                    CedulaNo = rdr[13].ToString();
                    Email = rdr[14].ToString();
                    Image = rdr[15].ToString();
                    Purok = rdr[16].ToString();
                }

                cmd.Dispose();
                cs.conn.Close();
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }
        public void ResetData()
        {
            strID = "";
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

        public static string strID;

        public void GetID(String id)
        {
            strID = id;
        }

    }
}
