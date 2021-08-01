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
            String query = "INSERT INTO tbl_residentinfo()";

            csConnection cs = new csConnection();
            cs.conn.Open();
            cs.command = new MySqlCommand("tbl_residentinfo", cs.conn);
            cs.command.CommandType = System.Data.CommandType.StoredProcedure;
            cs.command.Parameters.AddWithValue("Fname", Fname);
            cs.command.Parameters.AddWithValue("Mname", Mname);
            cs.command.Parameters.AddWithValue("Lname", Lname);
            cs.command.Parameters.AddWithValue("Sname", Sname);
            cs.command.Parameters.AddWithValue("BirthDate", BirthDate);
            cs.command.Parameters.AddWithValue("BirthPlace", BirthPlace);
            cs.command.Parameters.AddWithValue("CivilStatus", CivilStatus);
            cs.command.Parameters.AddWithValue("Gender", Gender);
            cs.command.Parameters.AddWithValue("Purok", Purok);
            cs.command.Parameters.AddWithValue("VoterStatus", VoterStatus);
            cs.command.Parameters.AddWithValue("CedulaNo", CedulaNo);
            cs.command.Parameters.AddWithValue("PhoneNo", PhoneNo);
            cs.command.Parameters.AddWithValue("EmailAddress", EmailAddress);
            cs.command.ExecuteNonQuery();
            
        }
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

        public string PhoneNo { get; set; }

        public string EmailAddress { get; set; }


    }
}
