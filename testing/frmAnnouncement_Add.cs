using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
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
    public partial class frmAnnouncement_Add : Form
    {
        csHostConfiguration host = new csHostConfiguration();

        public frmAnnouncement_Add()
        {
            InitializeComponent();
            mnpltDataGrid();
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAnnouncement("ibarangay");
        }

        private void data1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String username = row.Cells[2].Value.ToString();

                    AddAnnouncement(username);
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

        private async void AddAnnouncement(string SendTo)
        {
            try
            {
                if (tbSubject.Text != "" && rbDetails.Text != "")
                {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_announcement_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["Subject"] = tbSubject.Text;
                        datas["Details"] = rbDetails.Text;
                        datas["Date"] = dtDate.Value.ToString("yyyy-MM-dd");
                        datas["Level"] = cbLevel.SelectedItem.ToString();
                        datas["SendTo"] = SendTo == "ibarangay" ? "All" : SendTo;

                        csUser user = new csUser();
                        datas["UserID"] = user.strID();

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                        SendNotif(tbSubject.Text, rbDetails.Text, SendTo);
                        tbSubject.Text = "";
                        rbDetails.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill-up all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendNotif(string sub, string det, string topicName)
        {
            try
            {
                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions()
                    {

                        Credential = GoogleCredential.FromFile("private_key.json")
                    });
                }
                var topic = topicName ;
                var message = new FirebaseAdmin.Messaging.Message()
                {
                    Notification = new Notification()
                    {
                        Title = "Announcement!",
                        Body = "Subject: " + sub + " \nDetails: " + det
                    },
                    Topic = topic
                };

                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                MessageBox.Show("Sending Announcement....");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSubject.Text = "";
            rbDetails.Text = "";
        }

        private void frmAnnouncement_Add_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void LoadCombobox()
        {
            try
            {
                csComboBoxValues cb = new csComboBoxValues();
                cb.RetrieveArrLevel();
                cbLevel.Items.AddRange(cb.GetArrLevel().ToArray());
                cbLevel.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void mnpltDataGrid()
        {
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("uname", "Username");
            data1.Columns.Add("fname", "Fullname");

            DataGridViewImageColumn btn = new DataGridViewImageColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Image = Properties.Resources.megaphone;
            data1.Columns.Add(btn);

            data1.Columns["ID"].Visible = false;
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
                        AL.Add(jo["Username"]);
                        AL.Add(jo["Fname"] + " " + jo["Mname"] + " " + jo["Lname"] + " " + jo["Same"]);

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


        private void lblAll_Click(object sender, EventArgs e)
        {
            lblAll.ForeColor = Color.Black;
            lblSpecific.ForeColor = Color.Gray;
            panelAll.Visible = true;
            panelSpecific.Visible = false;


            btnAdd.Visible = true;
            tbSearch.Visible = false;
            lblSearch.Visible = false;
            btnSearch.Visible = false;
            data1.Visible = false;
        }
        private void lblSpecific_Click(object sender, EventArgs e)
        {
            lblSpecific.ForeColor = Color.Black;
            lblAll.ForeColor = Color.Gray;
            panelSpecific.Visible = true;
            panelAll.Visible = false;

            btnAdd.Visible = false;
            tbSearch.Visible = true;
            lblSearch.Visible = true;
            btnSearch.Visible = true;
            data1.Visible = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                data1.Rows.Clear();
                var uri = host.IP() + "/iBar/ibar_announcement_name_search.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Name"] = tbSearch.Text;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }
                Console.WriteLine(responseFromServer);
                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["announcement"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_account"]);
                        AL.Add(jo["Username"]);
                        AL.Add(jo["Fname"] + " " + jo["Mname"] + " " + jo["Lname"] + " " + jo["Same"]);

                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                    loadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
