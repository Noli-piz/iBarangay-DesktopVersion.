﻿using MySql.Data.MySqlClient;
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
    public partial class frmAccountManagement : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        List<string> ID = new List<string>();

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
            data1.Columns.Add("id", "ID.");
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

        private async void loadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_accountmanagement.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["account"])
                    {

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_account"]);
                        ID.Add(jo["id_account"].ToString());
                        AL.Add(jo["Username"]);
                        AL.Add(jo["Fname"] +" "+ jo["Mname"] +" "+ jo["Lname"] +" "+ jo["Same"]);
                        AL.Add(jo["VoterStatus"]);

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
                    frmAccountMngmnt2 frm = new frmAccountMngmnt2(ID[e.RowIndex].ToString());
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
                data1.Rows.Clear();
                var uri = host.IP() + "/iBar/ibar_accountmanagement_search.php";

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
                    foreach (var jo in (JArray)((JObject)data)["account"])
                    {

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_account"]);
                        ID.Add(jo["id_account"].ToString());
                        AL.Add(jo["Username"]);
                        AL.Add(jo["Fname"] + " " + jo["Mname"] + " " + jo["Lname"] + " " + jo["Same"]);
                        AL.Add(jo["VoterStatus"]);

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

        }
    }
}
