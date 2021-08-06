using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmMisService : Form
    {
        public frmMisService()
        {
            InitializeComponent();
        }

        private void frmMisService_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            RetrieveData();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("fullname", "Full Name");
            data1.Columns.Add("bday", "Birthdate");
            data1.Columns.Add("vstatus", "Voter Status");
            data1.Columns.Add("item", "Item");
            data1.Columns.Add("quan", "Quantity");
            data1.Columns.Add("date", "Requested Date");
            data1.Columns.Add("rstatus", "Request Status");
            data1.Columns.Add("dead", "Deadline");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        List<string> ID = new List<string>();
        private void RetrieveData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT ser.id_misservices, res.Fname, res.Mname, res.Lname, res.Sname, res.Birthdate, res.VoterStatus, i.ItemName , ser.Quantity, ser.DateOfRequest, ser.Status, ser.Deadline FROM tbl_misservices AS ser " +
                    "INNER JOIN tbl_account AS a ON a.id_account = ser.id_account " +
                    "INNER JOIN tbl_residentinfo AS res ON res.id_resident = a.id_resident " +
                    "INNER JOIN tbl_items AS i ON i.id_items = ser.id_items";

                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                ArrayList AL = new ArrayList();
                int count = 1;
                while (rdr.Read())
                {
                    ID.Add(rdr[0].ToString());

                    AL = new ArrayList();
                    AL.Add(count.ToString());
                    AL.Add(rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString());
                    AL.Add(rdr[5].ToString());
                    AL.Add(rdr[6].ToString());
                    AL.Add(rdr[7].ToString());
                    AL.Add(rdr[8].ToString());
                    AL.Add(rdr[9].ToString());
                    AL.Add(rdr[10].ToString());
                    AL.Add(rdr[11].ToString());
                    data1.Rows.Add(AL.ToArray());
                    count++;
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
            }
        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9)
                {
                    csMisService ser = new csMisService();
                    ser.GetID(ID[e.RowIndex].ToString());

                    frmMisService2 frm = new frmMisService2();
                    frm.ShowDialog(this);

                }
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
