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
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace testing
{
    public partial class frmResidentRec : Form
    {
        DataTable dt = new DataTable(); 

        public frmResidentRec()
        {
            InitializeComponent();
        }


        private void frmResidentInfo_Load(object sender, EventArgs e)
        {
            RetrieveData();
        }


        List<string> ID = new List<string>();
        private void RetrieveData()
        {
        try{
                ID.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("no", "No.");
                dataGridView1.Columns.Add("fullname", "Full Name");
                dataGridView1.Columns.Add("bday", "Birthdate");
                dataGridView1.Columns.Add("gender", "Gender");
                dataGridView1.Columns.Add("cstatus", "Civil Status");
                dataGridView1.Columns.Add("vstatus", "Voter Status");

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Action";
                btn.Name = "btnGenerate";
                btn.Text = "Edit";
                btn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btn);

                csConnection cs = new csConnection();
                String query = "SELECT * FROM tbl_residentinfo";
                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                ArrayList AL = new ArrayList();
                int count =1;
                while (rdr.Read())
                {
                    ID.Add(rdr[0].ToString());

                    AL = new ArrayList();
                    AL.Add(count.ToString());
                    AL.Add(rdr[1].ToString() +" "+ rdr[2].ToString() +" "+ rdr[3].ToString() +" "+ rdr[4].ToString());
                    AL.Add(rdr[6].ToString());
                    AL.Add(rdr[8].ToString());
                    AL.Add(rdr[7].ToString());
                    AL.Add(rdr[10].ToString());
                    //AL.Add(rdr[4].ToString());
                    //AL.Add(rdr[5].ToString());
                    //AL.Add(rdr[6].ToString());
                    dataGridView1.Rows.Add(AL.ToArray());
                    count++;
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    csResidents res = new csResidents();
                    res.GetID(ID[e.RowIndex].ToString());

                    frmUpdateResident frm = new frmUpdateResident();
                    frm.ShowDialog(this);

                    RetrieveData();
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Connect to the Internet!");
            }
        }        
        
        private void button3_Click(object sender, EventArgs e)
        {
            frmAddNewResident frm = new frmAddNewResident();
            frm.ShowDialog(this);
        }
    }
}
