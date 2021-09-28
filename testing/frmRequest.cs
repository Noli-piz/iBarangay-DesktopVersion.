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
    public partial class frmRequest : Form
    {
        public frmRequest()
        {
            InitializeComponent();
        }

        private void frmRequest_Load(object sender, EventArgs e)
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
            data1.Columns.Add("gender", "Gender");
            data1.Columns.Add("vstatus", "Voter Status");
            data1.Columns.Add("blotter", "Blotter Case");
            data1.Columns.Add("cert", "Type of Certificate");
            data1.Columns.Add("date", "Requested Date");
            data1.Columns.Add("rstatus", "Request Status");

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
                String query = "SELECT req.id_request ,res.Fname, res.Mname, res.Lname, res.Sname ,res.Birthdate ,res.Gender, res.VoterStatus, (SELECT COUNT(id_assailant_resident) FROM tbl_assailantresident WHERE id_resident =res.id_resident AND Deleted =0) AS Blotter ,cer.Types , req.DateOfRequest, req.Status " +
                    "FROM tbl_request AS req " +
                    "INNER JOIN tbl_account AS a ON a.id_account = req.id_account " +
                    "INNER JOIN tbl_residentinfo AS res ON res.id_resident = a.id_resident " +
                    "INNER JOIN tbl_certificate AS cer ON cer.id_certificate = req.id_certificate";

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
                MessageBox.Show(ex.Message );
            }
        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9)
                {
                    csRequest req = new csRequest();
                    req.GetID(ID[e.RowIndex].ToString());

                    frmRequest2 frm = new frmRequest2();
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
