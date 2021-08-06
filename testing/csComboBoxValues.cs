using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace testing
{
    class csComboBoxValues
    {

        private static ArrayList ArrGender, ArrCivilStatus, ArrPurok, ArrVoterStat;

        public void RetrieveGender()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT Identities FROM tbl_gender";
                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                ArrGender = new ArrayList();
                while (rdr.Read())
                {
                    ArrGender.Add(rdr[0].ToString());
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

        public void RetrieveCivilStatus()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT Types FROM tbl_civilstatus";
                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                ArrCivilStatus = new ArrayList();
                while (rdr.Read())
                {
                    ArrCivilStatus.Add(rdr[0].ToString());
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

        public void RetrievePurok()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT Name FROM tbl_purok";
                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                ArrPurok = new ArrayList();
                while (rdr.Read())
                {
                    ArrPurok.Add(rdr[0].ToString());
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

        public void RetrieveVoterStat()
        {
            ArrVoterStat = new ArrayList()
            {
                "Yes", "No"
            };
        }

        public ArrayList GetArrGender()
        {
            return ArrGender;
        }

        public ArrayList GetArrCivilStatus()
        {
            return ArrCivilStatus;
        }

        public ArrayList GetArrPurok()
        {
            return ArrPurok;
        }

        public ArrayList GetArrVoterStat()
        {
            return ArrVoterStat;
        }



        //// For Form Request
        ///

        private static ArrayList ArrStatus;

        public void RetrieveStatus()
        {
            ArrStatus = new ArrayList()
            {
                "Pending", "Approved", "Disapproved"
            };
        }

        public ArrayList GetArrStatus()
        {
            return ArrStatus;
        }

        /// For Form Mis Service
        /// 
        private static ArrayList ArrStatusService;
        public void RetrieveArrStatusService()
        {
            ArrStatusService = new ArrayList()
            {
                "Pending", "Approved", "Disapproved", "Barrowed", "Returned" 
            };
        }

        public ArrayList GetArrStatusService()
        {
            return ArrStatusService;
        }

    }
}
