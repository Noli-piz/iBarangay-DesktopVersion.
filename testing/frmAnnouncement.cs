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
            LoadCombobox();

        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();
            data1.Visible = false;

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("sbjct", "Subject");
            data1.Columns.Add("dtls", "Details");
            data1.Columns.Add("date", "Date");
            data1.Columns.Add("lvl", "Level");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View/Edit";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);

            data1.Columns["ID"].Visible = false;
        }

        List<string> ID = new List<string>();
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
                        ID.Add(jo["id_announcement"].ToString());

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_announcement"]);
                        AL.Add(jo["Subject"]);
                        AL.Add(jo["Details"]);
                        AL.Add(jo["Date"]);
                        AL.Add(jo["Level"]);
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

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    frmAnnouncement2 frm = new frmAnnouncement2(identifier);
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

        private void LoadCombobox()
        {
            csComboBoxValues cb = new csComboBoxValues();
            cb.RetrieveArrLevel();
            cbLevel.Items.AddRange(cb.GetArrLevel().ToArray());
            cbLevel.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbSubject.Text != "" && rbDetails.Text !="") {
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

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                        SendNotif(tbSubject.Text ,  rbDetails.Text);
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill-up Subject or Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mnpltDataGrid();
                loadData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSubject.Text = "";
            rbDetails.Text = "";
        }

        private void SendNotif(string sub, string det)
        {
            try
            {
                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions()
                    {

                        Credential = GoogleCredential.FromFile("private_key.json")

                        // Put in debug folder
                        //Credential = GoogleCredential.FromFile("private_key.json")
                    });
                }
                var topic = "ibarangay";
                var message = new FirebaseAdmin.Messaging.Message()
                {
                    //Data = new Dictionary<string, string>()
                    //{
                    //    { "myData", "1337" },
                    //},
                    //Token = "eKrRrmcSQiumMk-1oy7dox:APA91bG_Od6P5rlBMP6GyIK3WUZNwbuW18nYBxx4dJDLW5zLwLg4x4_2bDwzkQA5dscFOnYZaQ7dAOFplFfuZhIfa7y9bOb9UktLIQx7RC29EDbzlNn3DFWkoVEbUdxkUaeY3UNrTePX",

                    Notification = new Notification()
                    {
                        Title = "Announcement!",
                        Body ="Subject: "+ sub +" \nDetails: "+ det
                    },
                    Topic = topic
                };

                // Send a message to the device corresponding to the provided
                // registration token.
                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                // Response is a message ID string.
                MessageBox.Show("Sending Announcement to Residents....");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(checkEm("thisismenolidgmail.com").ToString());
        }

        private bool checkEm(String email)
        {
            try
            {

                var add = new System.Net.Mail.MailAddress(email);
                return add.Address == email;

            }
            catch (Exception es)
            {
                return false;
            }
        }
    }
}
