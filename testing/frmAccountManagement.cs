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
    public partial class frmAccountManagement : Form
    {
        csAccountMngmnt mngmnt = new csAccountMngmnt();

        public frmAccountManagement()
        {
            InitializeComponent();
        }

        private void frmAccountManagement_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            loadData();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();
            data1.Visible = false;

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("uname", "Username");
            data1.Columns.Add("fname", "Fullname");
            data1.Columns.Add("vstat", "Voter Status");
            data1.Columns.Add("vstat", "Account Status");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View/Edit";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        List<string> ID = new List<string>();
        private void loadData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT a.id_account, a.Username, r.Fname, r.Mname, r.Lname ,r.Sname, r.VoterStatus, a.Status FROM tbl_account AS a INNER JOIN tbl_residentinfo AS r ON r.id_resident = a.id_resident";

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
                    AL.Add(rdr[1].ToString());
                    AL.Add(rdr[2].ToString() +" "+ rdr[3].ToString() + " " + rdr[4].ToString() + " " + rdr[5].ToString());
                    AL.Add(rdr[6].ToString());

                    if (rdr[7].ToString() == "False")
                        AL.Add("Enabled");
                    else
                        AL.Add("Disabled");

                    data1.Rows.Add(AL.ToArray());
                    count++;
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();


                data1.AutoResizeColumns();
                data1.AutoResizeRows();

                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                data1.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    mngmnt.getID(ID[e.RowIndex].ToString());
                    frmAccountMngmnt2 frm = new frmAccountMngmnt2();
                    frm.ShowDialog(this);

                    mnpltDataGrid();
                    loadData();
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
