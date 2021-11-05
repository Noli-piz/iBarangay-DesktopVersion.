﻿using FirebaseAdmin;
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
        private String ID = "", ResID, ResUsername="";

        public frmRequest2(String id, String ResID)
        {
            InitializeComponent();
            ID = id;
            this.ResID = ResID;
        }

        private void frmRequest2_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            SelectData();
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

                        //jo["id_announcement"];
                        lblDocument.Text = jo["Types"].ToString();
                        lblDate.Text = jo["DateOfRequest"].ToString();
                        rbPurpose.Text = jo["Purpose"].ToString();
                        lblCurrentStatus.Text = jo["Status"].ToString();
                        lblDeliveryOption.Text = jo["Options"].ToString();
                        cbStatus.Text = jo["Status"].ToString();
                        ResUsername = jo["Username"].ToString();
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

                        csUser user = new csUser();
                        datas["UserID"] = user.strID();

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        SendNotif(ResUsername, Convert.ToString(cbStatus.SelectedItem));
                    }
                    else
                    {
                        MessageBox.Show("Update Failed " + responseFromServer);
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
                vwrBrgyClearance vwr = new vwrBrgyClearance(ResID, rbPurpose.Text);
                vwr.ShowDialog(this);


            }
            else if(lblDocument.Text == "Good Moral")
            {

            }
            else if ( lblDocument.Text == "Indigency" )
            {

            }
            else
            {
                MessageBox.Show("Not available");
            }
        }


        //Sending Notification
        private void SendNotif(string username,string Stat)
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
                var message = new FirebaseAdmin.Messaging.Message()
                {
                    //Data = new Dictionary<string, string>()
                    //{
                    //    { "myData", "1337" },
                    //},
                    //Token = "eKrRrmcSQiumMk-1oy7dox:APA91bG_Od6P5rlBMP6GyIK3WUZNwbuW18nYBxx4dJDLW5zLwLg4x4_2bDwzkQA5dscFOnYZaQ7dAOFplFfuZhIfa7y9bOb9UktLIQx7RC29EDbzlNn3DFWkoVEbUdxkUaeY3UNrTePX",

                    Notification = new Notification()
                    {
                        Title = "Your Request",
                        Body = "Status: " + Stat
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
