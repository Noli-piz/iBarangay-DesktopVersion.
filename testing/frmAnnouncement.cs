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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace testing
{
    public partial class frmAnnouncement : Form
    {
        csHostConfiguration host = new csHostConfiguration();


        public frmAnnouncement()
        {
            InitializeComponent();
        }

        private void frmAnnouncement_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            loadData();
        }

        private void mnpltDataGrid()
        {
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("sbjct", "Subject");
            data1.Columns.Add("dtls", "Details");
            data1.Columns.Add("date", "Date");
            data1.Columns.Add("sendto", "Sent To");
            data1.Columns.Add("lvl", "Level");

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


            //data1.Columns["btnGenerate2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            data1.Columns["ID"].Visible = false;
        }

        private async void loadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP()  + "/iBar/ibar_announcement.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["announcement"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_announcement"]);
                        AL.Add(jo["Subject"]);
                        AL.Add(jo["Details"]);
                        AL.Add(jo["Date"]);
                        AL.Add(jo["SendTo"]);
                        AL.Add(jo["Level"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
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
                if (e.ColumnIndex == 7)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    frmAnnouncement2 frm = new frmAnnouncement2(identifier);
                    frm.ShowDialog(this);

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

        private void btnAnn_Click(object sender, EventArgs e)
        {
            frmAnnouncement_Add frm = new frmAnnouncement_Add();
            frm.ShowDialog(this);

            data1.Rows.Clear();
            loadData();
        }
    }
}
