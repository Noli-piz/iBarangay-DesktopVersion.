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
    public partial class frmBlotterRec : Form
    {
        private csBlotter blot = new csBlotter();
        public frmBlotterRec()
        {
            InitializeComponent();
        }
        private void frmBlotterRec_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            RetrieveData();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("no", "No.");
            dataGridView1.Columns.Add("com", "Compliant");
            dataGridView1.Columns.Add("ass", "Assailant");
            dataGridView1.Columns.Add("det", "Detail");
            dataGridView1.Columns.Add("cstatus", "Case Status");
            dataGridView1.Columns.Add("date", "Date");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View/Edit";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
        }

        List<string> ID = new List<string>();
        private void RetrieveData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT b.id_blotter, b.Compliant, (SELECT GROUP_CONCAT(CONCAT_WS(' ',Fname,Mname,Lname,Sname)) FROM tbl_residentinfo WHERE id_resident " +
                    "IN (SELECT id_resident FROM tbl_assailantresident WHERE id_assailant_resident = b.id_assailant_resident AND Deleted =0)) AS Assailant1, " +
                    "(SELECT GROUP_CONCAT(Name,' ') FROM tbl_assailantnonresident WHERE id_assailant_nonresident = b.id_assailant_nonresident AND Deleted =0) AS Assailant2 , " +
                    " b.Details, b.Status , DATE_FORMAT(b.Date, '%Y-%m-%d') , b.Time  FROM tbl_blotterinfo AS b";

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
                    AL.Add(rdr[2].ToString() +" "+ rdr[3].ToString());
                    AL.Add(rdr[4].ToString());
                    AL.Add(rdr[5].ToString());
                    AL.Add(rdr[6].ToString());
                    dataGridView1.Rows.Add(AL.ToArray());
                    count++;
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                if (e.ColumnIndex == 6)
                {
                    blot.GetID(ID[e.RowIndex].ToString());

                    frmBlotterRec2Update frm = new frmBlotterRec2Update();
                    frm.ShowDialog(this);

                    dataGridView1.Rows.Clear();
                    RetrieveData();
                }
            }catch(ArgumentOutOfRangeException ex)
            {
                
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBlotterRec2 frm = new frmBlotterRec2();
            frm.ShowDialog(this);

            dataGridView1.Rows.Clear();
            RetrieveData();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
        }
    }
}
