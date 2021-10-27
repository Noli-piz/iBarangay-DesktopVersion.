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
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Specialized;

namespace testing
{
    public partial class frmResident : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        List<string> ID = new List<string>();

        public frmResident()
        {
            InitializeComponent();
        }


        private void frmResidentInfo_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            //RetrieveData();
            LoadData();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("fullname", "Full Name");
            data1.Columns.Add("bday", "Birthdate");
            data1.Columns.Add("gender", "Gender");
            data1.Columns.Add("cstatus", "Civil Stat");
            data1.Columns.Add("vstatus", "Voter Stat");


            //DataGridViewImageColumn btn = new DataGridViewImageColumn();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            //btn.Image = Properties.Resources.edit1;
            btn.Text = "Edit";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        private async void LoadData()
        {
            try
            {

                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_resident.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();

                List<int> colorInt = new List<int>();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["resident"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_resident"]);
                        ID.Add(jo["id_resident"].ToString());
                        AL.Add(jo["Fname"] +" "+ jo["Mname"] +" "+ jo["Lname"] +" "+ jo["Sname"]);
                        AL.Add(jo["Birthdate"]);
                        AL.Add(jo["Gender"]);
                        AL.Add(jo["CivilStatus"]);
                        AL.Add(jo["VoterStatus"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }


                    for (int x = 0; x < data1.Rows.Count; x++)
                    {
                        if (colorInt.Contains(x))
                        {
                            data1.Rows[x - 1].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        }
                    }


                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
                
                data1.Columns["ID"].Visible = false;

                data1.AutoResizeColumns();
                data1.AutoResizeRows();

                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                data1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void RetrieveData()
        {
        try{
                

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
                    data1.Rows.Add(AL.ToArray());
                    count++;
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    csResidents res = new csResidents();
                    res.GetID(identifier);

                    frmResident_update frm = new frmResident_update();
                    frm.ShowDialog(this);

                    ID.Clear();
                    data1.Rows.Clear();
                    LoadData();
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cbCategory.SelectedItem) != "")
                {
                    data1.Rows.Clear();
                    var uri = host.IP() + "/iBar/ibar_resident_search.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = tbSearch.Text;
                        datas["Category"] = cbCategory.SelectedItem.ToString();

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    ArrayList AL = new ArrayList();
                    var data = JsonConvert.DeserializeObject(responseFromServer);
                    string success = JObject.Parse(responseFromServer)["success"].ToString();
                    if (success == "1")
                    {
                        int i = 1;
                        foreach (var jo in (JArray)((JObject)data)["resident"])
                        {

                            AL = new ArrayList();
                            AL.Add(i.ToString());
                            AL.Add(jo["id_resident"]);
                            ID.Add(jo["id_resident"].ToString());
                            AL.Add(jo["Fname"] + " " + jo["Mname"] + " " + jo["Lname"] + " " + jo["Sname"]);
                            AL.Add(jo["Birthdate"]);
                            AL.Add(jo["Gender"]);
                            AL.Add(jo["CivilStatus"]);
                            AL.Add(jo["VoterStatus"]);
                            data1.Rows.Add(AL.ToArray());
                            i++;
                        }
                    }
                    else if (success == "0")
                    {
                        MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                        LoadData();
                    }

                    data1.AutoResizeColumns();
                    data1.AutoResizeRows();

                    data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    data1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    data1.Visible = true;
                }
                else{
                    MessageBox.Show("No Category Selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Connect to the Internet!" + ex.Message);
            }
        }        
        
        private void button3_Click(object sender, EventArgs e)
        {
            frmResident_insert frm = new frmResident_insert();
            frm.ShowDialog(this);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }
    }
}
