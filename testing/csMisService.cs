using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csMisService
    {
        public void retrieveData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT i.ItemName , ser.Quantity, ser.Purpose, ser.DateOfRequest, DATE_FORMAT(ser.Deadline, \" %Y %m %d\"), ser.Status, d.Options FROM tbl_misservices AS ser " +
                    "INNER JOIN tbl_items AS i ON i.id_items = ser.id_items " +
                    "INNER JOIN tbl_deliveryoption AS d ON d.id_deliveryoption = ser.id_deliveryoption " +
                    "WHERE ser.id_misservices = '"+ ID +"'";

                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ItemName = rdr[0].ToString();
                    Quantity = rdr[1].ToString();
                    Purpose = rdr[2].ToString();
                    Date = rdr[3].ToString();
                    Deadline = rdr[4].ToString();
                    Status = rdr[5].ToString();
                    deliveryOption = rdr[6].ToString();
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

        // Plus //Add Item from tbl_item because the requested is returned
        public void updateData()
        {
            try
            {
                csConnection cs = new csConnection();
                cs.conn.Open();
                MySqlCommand cmd = cs.conn.CreateCommand();
                MySqlTransaction myTrans = cs.conn.BeginTransaction();

                try
                {
                    cmd.CommandText = "UPDATE tbl_items SET Quantity = Quantity + '" + Quantity + "' WHERE ItemName= '" + ItemName + "'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "UPDATE tbl_misservices SET Status = '" + UpdatedStatus + "' WHERE id_misservices = '" + ID + "'";
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                    Message = "Successfully Updated";
                }
                catch (Exception e)
                {
                    myTrans.Rollback();
                }

                cmd.Dispose();
                cs.conn.Close();
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }

        //Minus //Reduce Item from tbl_item because the request is approved
        public void updateData2()
        {
            try
            {
                Valid();
                csConnection cs = new csConnection();
                cs.conn.Open();
                MySqlCommand cmd = cs.conn.CreateCommand();
                MySqlTransaction myTrans = cs.conn.BeginTransaction();

                try
                {
                    if (Result=="YES") {
                        cmd.CommandText = "UPDATE tbl_items SET Quantity = Quantity - '"+ Quantity +"' WHERE ItemName= '"+ ItemName +"'";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "UPDATE tbl_misservices SET Status = '"+ UpdatedStatus +"', Deadline = '"+ UpdatedDeadline +"' WHERE id_misservices = '"+ ID +"'";
                        cmd.ExecuteNonQuery();
                        myTrans.Commit();
                        Message = "Successfully Updated";
                    }
                    else
                    {
                        Message = "There is not enough item in your inventory " + cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    myTrans.Rollback();
                }

                cmd.Dispose();
                cs.conn.Close();
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }


        public void updateData3()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "UPDATE tbl_misservices SET Status = '"+UpdatedStatus+"' WHERE id_misservices ='"+ ID +"'";


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

        public void Valid()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT IF(ser.Quantity>=i.id_items, \"YES\" , \"NO\") AS cond FROM tbl_misservices AS ser INNER JOIN tbl_items AS i ON i.id_items = ser.id_items WHERE ser.id_misservices = '" + ID + "'";

                cs.conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    Result = rdr[0].ToString();
                }
            
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }
        public void Reset()
        {
            Message = "";
            ID = "";
            ItemName = "";
            Date = "";
            Purpose = "";
            Quantity = "";
            deliveryOption = "";
            Deadline = "";
            Status = "";

            UpdatedStatus = "";
            UpdatedDeadline = "";
        }

        private string Result;
        public string Message { get; private set; }
        public string ItemName { get; private set; }
        public string Date { get; private set; }
        public string Purpose { get; private set; }
        public string Quantity { get; private set; }
        public string deliveryOption { get; private set; }
        public string Deadline { get; private set; }
        public string Status { get; private set; }


        private static string ID;
        public void GetID(String Id) { ID = Id; }


        public string UpdatedStatus { get; set; }
        public string UpdatedDeadline { get; set; }

    }
}
