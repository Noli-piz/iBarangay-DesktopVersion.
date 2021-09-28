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
    public partial class frmIssuance : Form
    {
        public frmIssuance()
        {
            InitializeComponent();
        }

        private void frmIssuance_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            LoadData();
        }

        List<string> ID = new List<string>();
        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("fullname", "Full Name");
            data1.Columns.Add("bday", "Birthdate");
            data1.Columns.Add("gen", "Gender");
            data1.Columns.Add("vstatus", "Voter Status");
            data1.Columns.Add("blotter", "Blotter Case");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Text = "Barangay Clearance";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Text = "Good Moral";
            btn2.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn2);
            data1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void LoadData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT id_resident, Fname, Mname, Lname, Sname, Birthdate, Gender, VoterStatus, " +
                    "(SELECT COUNT(id_assailant_resident) FROM tbl_assailantresident WHERE id_resident = res.id_resident AND Deleted = 0) AS Blotter " +
                    "FROM tbl_residentinfo AS res";

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
            if (e.ColumnIndex == 6)
            {
                vwrBrgyClearance vwr = new vwrBrgyClearance();
                vwr.ShowDialog(this);
            }else if (e.ColumnIndex == 7)
            {
                vwrBrgyClearance vwr = new vwrBrgyClearance();
                vwr.ShowDialog(this);
            }
        }
    }
}
