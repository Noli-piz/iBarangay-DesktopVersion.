using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csRequest
    {
        private static string ID;

        public void retrieveData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT c.Types, r.DateOfRequest, r.Purpose, r.Status, d.Options " +
                    "FROM tbl_request AS r " +
                    "INNER JOIN tbl_certificate AS c ON c.id_certificate = r.id_certificate " +
                    "INNER JOIN tbl_deliveryoption AS d ON d.id_deliveryoption = r.id_deliveryoption " +
                    "WHERE r.id_request = '" + ID + "'";
                
                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Docs = rdr[0].ToString();
                    Date = rdr[1].ToString();
                    Purpose = rdr[2].ToString();
                    CurrentStatus = rdr[3].ToString();
                    DeliveryOption = rdr[4].ToString();
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void updateData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "UPDATE "+ cs.DBname() +".tbl_request SET Status='"+ UpdatedStatus +"' WHERE id_request ='"+ ID +"'";
                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                if (cmd.ExecuteNonQuery()>=1)
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

        public void ResetData()
        {
            ID = "";
            Message = "";
            Docs = "";
            Date = "";
            Purpose = "";
            CurrentStatus = "";
            DeliveryOption = "";
            UpdatedStatus = "";
        }

        public void GetID(String Id) {
            ID = Id;
        } 

        public string Message { get; private set; }
        public string Docs { get; private set; }
        public string Date { get; private set; }
        public string Purpose { get; private set; }
        public string CurrentStatus { get; private set; }
        public string DeliveryOption { get; private set; }

        public string UpdatedStatus { get; set; }
    }
}
