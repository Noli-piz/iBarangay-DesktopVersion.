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
    public partial class frmUserMngmnt : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        List<string> ID = new List<string>();


        public frmUserMngmnt()
        {
            InitializeComponent();
        }
        private void frmUserMngmnt_Load(object sender, EventArgs e)
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
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("uname", "Username");
            data1.Columns.Add("fname", "Fullname");
            data1.Columns.Add("access", "Level of Access");
            data1.Columns.Add("stat", "User Status");

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

        private async void loadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_usermanagement.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["users"])
                    {

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_users"]);
                        ID.Add(jo["id_users"].ToString());
                        AL.Add(jo["Username"]);
                        AL.Add(jo["Fullname"]);
                        AL.Add(jo["LevelOfAccess"]);

                        if (jo["Status"].ToString() == "0")
                            AL.Add("Enabled");
                        else
                            AL.Add("Disabled");
                        
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                if (e.ColumnIndex == 6)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    frmUserMngmnt3 frm = new frmUserMngmnt3(identifier);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUserMngmnt2 frm = new frmUserMngmnt2();
            frm.ShowDialog(this);

            ID.Clear();
            data1.Rows.Clear();
            loadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                data1.Rows.Clear();
                var uri = host.IP() + "/iBar/ibar_usermanagement_search.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = tbSearch.Text;
                    datas["Category"] = cbCategory.SelectedItem.ToString(); ;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["users"])
                    {

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_users"]);
                        ID.Add(jo["id_users"].ToString());
                        AL.Add(jo["Username"]);
                        AL.Add(jo["Fullname"]);
                        AL.Add(jo["LevelOfAccess"]);

                        if (jo["Status"].ToString() == "0")
                            AL.Add("Enabled");
                        else
                            AL.Add("Disabled");

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
                MessageBox.Show("Please Connect to the Internet!" + ex.Message);
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
