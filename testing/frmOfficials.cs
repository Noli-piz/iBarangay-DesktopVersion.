using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace testing
{
    public partial class frmOfficials : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        List<string> ID = new List<string>();


        public frmOfficials()
        {
            InitializeComponent();
        }

        private void frmOfficials_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            LoadData();
        }

        private void mnpltDataGrid()
        {
            //ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("fname", "Fullname");
            data1.Columns.Add("dtls", "Position 1");
            data1.Columns.Add("date", "Position 2");

            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "Action";
            //btn.Name = "btnGenerate";
            //btn.Text = "View/Edit";
            //btn.UseColumnTextForButtonValue = true;
            //data1.Columns.Add(btn);

            DataGridViewImageColumn btn = new DataGridViewImageColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Image = Properties.Resources.edit_icon;
            data1.Columns.Add(btn);

            data1.Columns["ID"].Visible = false;

        }

        private async void LoadData()
        {
            try 
            {
                
                HttpClient client = new HttpClient();
                var uri = host.IP() +"/iBar/ibar_official.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["official"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_officials"]);
                        ID.Add(jo["id_officials"].ToString());
                        AL.Add(jo["Fname"]);
                        AL.Add(jo["Position1"]);
                        AL.Add(jo["Position2"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
                


                data1.AutoResizeColumns();
                data1.AutoResizeRows();

                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmOfficials_insert frm = new frmOfficials_insert();
            frm.ShowDialog(this);

            data1.Rows.Clear();
            LoadData();
        }

        private void data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    frmOfficials_update frm = new frmOfficials_update(identifier);
                    frm.ShowDialog(this);

                    ID.Clear();
                    data1.Rows.Clear();
                    LoadData();
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
