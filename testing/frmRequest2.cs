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
    public partial class frmRequest2 : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private String ID = "", idresident, idaccount, ResUsername="";

        public frmRequest2(String id, string idresident, string idaccount)
        {
            InitializeComponent();
            ID = id;
            this.idresident = idresident;
            this.idaccount = idaccount;
        }

        private void frmRequest2_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            SelectData();
            mnpltDataGrid();
            LoadData();
        }


        private async void SelectData()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_request_specific.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["request"])
                    {
                        //Resident Info
                        lblFullname.Text = jo["Fullname"].ToString();
                        lblEmail.Text = jo["Email"].ToString();
                        lblUsername.Text = jo["Username"].ToString();
                        lblContact.Text = jo["ContactNo"].ToString();
                        lblCedula.Text = jo["CedulaNo"].ToString();
                        lblVoterStatus.Text = jo["VoterStatus"].ToString();
                        lblBlotterCase.Text = jo["Blotter"].ToString();
                        lblHouseNo.Text = jo["HouseNoAndStreet"].ToString();


                        //Request Info
                        lblDocument.Text = jo["Types"].ToString();
                        lblDate.Text = jo["DateOfRequest"].ToString();
                        rbPurpose.Text = jo["Purpose"].ToString();
                        lblCurrentStatus.Text = jo["Status"].ToString();
                        lblDeliveryOption.Text = jo["Options"].ToString();
                        cbStatus.Text = jo["Status"].ToString();
                        ResUsername = jo["Username"].ToString();
                        rbNote.Text = jo["Note"].ToString();
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void mnpltDataGrid()
        {
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID");
            data1.Columns.Add("types", "Types");
            data1.Columns.Add("date", "Req Date");
            data1.Columns.Add("rstatus", "Req Stat.");
            data1.Columns.Add("dstatus", "Delivery Opt.");
            data1.Columns.Add("prps", "Purpose");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "SELECT";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        private async void LoadData()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_request_specific_data.php";
                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = idaccount;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();

                List<int> colorInt = new List<int>();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["request"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_request"]);
                        AL.Add(jo["Types"]);
                        AL.Add(jo["DateOfRequest"]);
                        AL.Add(jo["Status"]);
                        AL.Add(jo["Options"]);
                        AL.Add(jo["Purpose"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }

                }


                data1.Columns["ID"].Visible = false;
                data1.AutoResizeColumns();
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
                if (e.ColumnIndex == 7)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    ID = row.Cells[1].Value.ToString();

                    SelectData();
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


        // Submit
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cbStatus.SelectedItem) != "")
                {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_request_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;
                        datas["Status"] = cbStatus.SelectedItem.ToString();
                        datas["Note"] = rbNote.Text==""? "NONE" : rbNote.Text;


                        csUser user = new csUser();
                        datas["UserID"] = user.strID();

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        SendNotif(ResUsername, Convert.ToString(cbStatus.SelectedItem), rbNote.Text);


                        data1.Rows.Clear();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed ");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Status.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        
        //Load the comboboxes
        private void LoadComboBoxes()
        {
            csComboBoxValues cbValues = new csComboBoxValues();
            cbValues.RetrieveStatus();

            cbStatus.Items.AddRange(cbValues.GetArrStatus().ToArray());
            cbStatus.SelectedIndex = 0;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            using (frmMessageTemplates frm = new frmMessageTemplates())
            {
                frm.ShowDialog();

                string result = frm.GetMyMessage;

                if (result != "" && result != null)
                {
                    rbNote.Text = result;
                }
            }
        }



        // Cancel/ Close the current forms 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// Generating Documents
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lblDocument.Text == "Barangay Clearance")
            {
                vwrBrgyClearance vwr = new vwrBrgyClearance(idresident, rbPurpose.Text);
                vwr.ShowDialog(this);


            }
            else if(lblDocument.Text == "Good Moral")
            {
                MessageBox.Show("The Selected Document is not Available!");
            }
            else if ( lblDocument.Text == "Indigency" )
            {
                MessageBox.Show("The Selected Document is not Available!");
            }
            else
            {
                MessageBox.Show("Not available");
            }
        }


        //Sending Notification
        private void SendNotif(string username,string Stat, string Note)
        {
            try
            {
                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions()
                    {
                        // Put in debug folder
                        Credential = GoogleCredential.FromFile("private_key.json")
                    });
                }
                var topic = username;
                string body = Note == "" ? "Your request about "+ lblDocument.Text +" is " + Stat 
                    : "Your request about " + lblDocument.Text + " is " + Stat + "\nNote: " + Note;

                var message = new FirebaseAdmin.Messaging.Message()
                {
                    //Data = new Dictionary<string, string>()
                    //{
                    //    { "myData", "1337" },
                    //},
                    //Token = "eKrRrmcSQiumMk-1oy7dox:APA91bG_Od6P5rlBMP6GyIK3WUZNwbuW18nYBxx4dJDLW5zLwLg4x4_2bDwzkQA5dscFOnYZaQ7dAOFplFfuZhIfa7y9bOb9UktLIQx7RC29EDbzlNn3DFWkoVEbUdxkUaeY3UNrTePX",

                    Notification = new Notification()
                    {
                        Title = "Request",
                        Body = body
                    },
                    Topic = topic
                };

                // Send a message to the device corresponding to the provided
                // registration token.
                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                // Response is a message ID string.
                MessageBox.Show("Sending Notification to "+ username +"....");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
