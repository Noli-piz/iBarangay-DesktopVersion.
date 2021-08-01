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

namespace testing
{
    public partial class frmResidentRec : Form
    {
        DataTable dt = new DataTable(); 

        public frmResidentRec()
        {
            InitializeComponent();
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "YO2vBBOCiAVlj8Tvzc2an6PfAbIJVb51HXhQhBz8",
            BasePath = "https://ibarangay-23725-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseClient client;

        private void frmResidentInfo_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem in the internet.");
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                FirebaseResponse res = client.Get(@"ResidentList");
                Dictionary<string, csResidents> data = JsonConvert.DeserializeObject<Dictionary<string, csResidents>>(res.Body.ToString());
                PopulateDataGrid(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Connect to the Internet!");
            }
        }

        List<string> Keylist = new List<string>();
        private async void PopulateDataGrid(Dictionary<string,csResidents > record)
        {
            Keylist.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("no", "No.");
            dataGridView1.Columns.Add("fname", "Full Name");
            dataGridView1.Columns.Add("mname", "Middle Name");
            dataGridView1.Columns.Add("lname", "Last Name");

            int i = 1;
            foreach ( var item in record)
            {
                Keylist.Add(item.Key);
                dataGridView1.Rows.Add(i, item.Value.Fname, item.Value.Mname, item.Value.Lname, item.Value.Sname);
                i++;
            }

            //dataGridView1.ColumnCount = 3;
            //dataGridView1.Columns[0].Name = "Name";
            //dataGridView1.Columns[1].Name = "Address";
            //dataGridView1.Columns[2].Name = "Voter Status";

            //ArrayList list = new ArrayList();
            //list.Add("Pizarro, Noli M.");
            //list.Add("Santiago Street");
            //list.Add("No");
            //dataGridView1.Rows.Add(list.ToArray());

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "Edit";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
        }


        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    MessageBox.Show(Keylist[e.RowIndex].ToString());
                }
            }catch(Exception ex){
                MessageBox.Show("This column can't be ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddNewResident frm = new frmAddNewResident();
            frm.ShowDialog(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = client.Get(@"ResidentList");
                Dictionary<string, csResidents> data = JsonConvert.DeserializeObject<Dictionary<string, csResidents>>(res.Body.ToString());
                FilterPopulateDataGrid(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Connect to the Internet!");
            }
        }

        private async void FilterPopulateDataGrid(Dictionary<string, csResidents> record)
        {
            Keylist.Clear();
            String Keyword = tbSearch.Text.Trim();
            String Category = "";

            if (cbCategory.SelectedIndex >= 0)
                Category = cbCategory.SelectedItem.ToString().Trim();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("no", "No.");
            dataGridView1.Columns.Add("fname", "Full Name");
            dataGridView1.Columns.Add("mname", "Middle Name");
            dataGridView1.Columns.Add("lname", "Last Name");

            int i = 1;
            foreach (var item in record)
            {
                Keylist.Add(item.Key);

                if (Category == "Fname" && Keyword == item.Value.Fname){
                    dataGridView1.Rows.Add(i, item.Value.Fname, item.Value.Mname, item.Value.Lname, item.Value.Sname);
                    i++;
                }else if (Category == "Mname" && Keyword == item.Value.Mname){
                    dataGridView1.Rows.Add(i, item.Value.Fname, item.Value.Mname, item.Value.Lname, item.Value.Sname);
                    i++;
                }else if (Category == "Lname" && Keyword == item.Value.Lname){
                    dataGridView1.Rows.Add(i, item.Value.Fname, item.Value.Mname, item.Value.Lname, item.Value.Sname);
                    i++;
                }else if (Category == "VoterStatus" && Keyword == item.Value.VoterStatus){
                    dataGridView1.Rows.Add(i, item.Value.Fname, item.Value.Mname, item.Value.Lname, item.Value.Sname);
                    i++;
                }else if (Category == "CivilStatus" && Keyword == item.Value.CivilStatus){
                    dataGridView1.Rows.Add(i, item.Value.Fname, item.Value.Mname, item.Value.Lname, item.Value.Sname);
                    i++;
                }else if (Category == "" && (Keyword == item.Value.Fname || Keyword == item.Value.Mname || Keyword == item.Value.Lname || Keyword == item.Value.VoterStatus || Keyword == item.Value.CivilStatus)){
                    dataGridView1.Rows.Add(i, item.Value.Fname, item.Value.Mname, item.Value.Lname, item.Value.Sname);
                    i++;
                }
            }


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "Edit";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
            
            
            if (i == 1)
            {
                MessageBox.Show("No result.");
                LoadData();
            }

        }
    }
}
