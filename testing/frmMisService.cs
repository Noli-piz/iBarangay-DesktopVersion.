﻿using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmMisService : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private List<string> ID = new List<string>();

        public frmMisService()
        {
            InitializeComponent();
        }

        private void frmMisService_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            LoadData();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID");
            data1.Columns.Add("fullname", "Full Name");
            data1.Columns.Add("bday", "Birthdate");
            data1.Columns.Add("vstatus", "Voter Status");
            data1.Columns.Add("item", "Item");
            data1.Columns.Add("quan", "Quantity");
            data1.Columns.Add("date", "Requested Date");
            data1.Columns.Add("rstatus", "Request Status");
            data1.Columns.Add("dead", "Deadline");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        private async void LoadData()
        {
            try
            {

                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_misservice.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();

                List<int> colorInt = new List<int>();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["service"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_misservices"]);
                        ID.Add(jo["id_misservices"].ToString());
                        AL.Add(jo["Fname"] +" "+ jo["Mname"] +" "+ jo["Lname"] + " " + jo["Sname"]);
                        AL.Add(jo["Birthdate"]);
                        AL.Add(jo["VoterStatus"]);
                        AL.Add(jo["ItemName"]);
                        AL.Add(jo["Quantity"]);
                        AL.Add(jo["DateOfRequest"]);
                        AL.Add(jo["Status"]);
                        AL.Add(jo["Date"]);
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

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 10)
                {
                    csMisService ser = new csMisService();
                    ser.GetID(ID[e.RowIndex].ToString());

                    frmMisService2 frm = new frmMisService2();
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