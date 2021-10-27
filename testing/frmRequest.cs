using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmRequest : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        List<string> ID = new List<string>();

        public frmRequest()
        {
            InitializeComponent();
        }

        private void frmRequest_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            loadData();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("", "No.");
            data1.Columns.Add("id", "ID");
            data1.Columns.Add("resid", "ResID.");
            data1.Columns.Add("", "Full Name");
            data1.Columns.Add("", "Birthdate");
            data1.Columns.Add("", "Gender");
            data1.Columns.Add("", "Voter Status");
            data1.Columns.Add("", "Blotter Case");
            data1.Columns.Add("", "Type of Certificate");
            data1.Columns.Add("", "Requested Date");
            data1.Columns.Add("", "Request Status");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        private async void loadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_request.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["request"])
                    {

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_request"]);
                        AL.Add(jo["id_resident"].ToString());
                        AL.Add(jo["Fname"] +" " + jo["Mname"] +" "+ jo["Lname"]+" "+ jo["Sname"]);
                        AL.Add(jo["Birthdate"]);
                        AL.Add(jo["Gender"]);
                        AL.Add(jo["VoterStatus"]);
                        AL.Add(jo["Blotter"]);
                        AL.Add(jo["Types"]);
                        AL.Add(jo["DateOfRequest"]);
                        AL.Add(jo["Status"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }

                data1.Columns["ID"].Visible = false;
                data1.Columns["resid"].Visible = false;

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 11)
                {

                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();
                    String resID = row.Cells[2].Value.ToString();

                    frmRequest2 frm = new frmRequest2(identifier, resID);
                    frm.ShowDialog(this);

                    ID.Clear();
                    data1.Rows.Clear();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cbCategory.SelectedItem) != "")
                {
                    data1.Rows.Clear();
                    var uri = host.IP() + "/iBar/ibar_request_search.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = tbSearch.Text;
                        datas["Category"] = cbCategory.SelectedItem.ToString();

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    Result(responseFromServer);
                }
                else
                {
                    MessageBox.Show("No Category Selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                data1.Rows.Clear();
                var uri = host.IP() + "/iBar/ibar_request_sort.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Category"] = cbStatus.SelectedItem.ToString();

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                Result(responseFromServer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private async void Result(String responseFromServer)
        {
            try
            {

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["request"])
                    {

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_request"]);
                        AL.Add(jo["id_resident"].ToString());
                        AL.Add(jo["Fname"] + " " + jo["Mname"] + " " + jo["Lname"] + " " + jo["Sname"]);
                        AL.Add(jo["Birthdate"]);
                        AL.Add(jo["Gender"]);
                        AL.Add(jo["VoterStatus"]);
                        AL.Add(jo["Blotter"]);
                        AL.Add(jo["Types"]);
                        AL.Add(jo["DateOfRequest"]);
                        AL.Add(jo["Status"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                    loadData();
                }

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            ID.Clear();
            data1.Rows.Clear();
            loadData();
        }

        
    }
}
