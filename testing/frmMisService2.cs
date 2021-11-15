﻿using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmMisService2 : Form
    {
        csMisService ser = new csMisService();
        csHostConfiguration host = new csHostConfiguration();
        string ID = "", currentDeadline = "", currentStatus, resUsername="";

        public frmMisService2(String id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void frmMisService2_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            SelectData();
            ResetList();
        }
    
        private void ResetList()
        {
            if (currentStatus == "Pending" )
            {
                cbStatus.Items.Clear();
                LoadComboBoxes();
                cbStatus.Items.Remove("Borrowed");
                cbStatus.Items.Remove("Returned");
            }
            else if (currentStatus == "Approved")
            {
                cbStatus.Items.Clear();
                LoadComboBoxes();
                cbStatus.Items.Remove("Pending");
                cbStatus.Items.Remove("Disapproved");
                cbStatus.Items.Remove("Returned");
                cbStatus.SelectedIndex = 0;

            }
            else if (currentStatus == "Disapproved")
            {
                cbStatus.Items.Clear();
                cbStatus.Items.Add("Dispproved");
                cbStatus.SelectedIndex = 0;
            }
            else if (currentStatus == "Borrowed")
            {
                cbStatus.Items.Clear();
                cbStatus.Items.Add("Borrowed");
                cbStatus.Items.Add("Returned");
                cbStatus.SelectedIndex = 0;

            }
            else
            {
                cbStatus.Items.Clear();
                cbStatus.Items.Add("Returned");
                cbStatus.SelectedIndex = 0;
            }
        }

        private async void SelectData()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_misservice_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["service"])
                    {
                        lblItem.Text = jo["ItemName"].ToString();
                        lblDate.Text = jo["DateOfRequest"].ToString();
                        rbPurpose.Text = jo["Purpose"].ToString();
                        lblCurrentStatus.Text = jo["Status"].ToString();
                        lblDeliveryOption.Text = jo["Options"].ToString();
                        lblQuantity.Text = jo["Quantity"].ToString();
                        cbStatus.Text = jo["Status"].ToString();
                        resUsername = jo["Username"].ToString();
                        rbNote.Text = jo["Note"].ToString();

                        //String vl = jo["Deadline"].ToString();
                        //if (vl == "0000-00-00")
                        //{
                        //    dtDeadline.Value = DateTime.ParseExact(jo["Deadline"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        //}
                        //else
                        //{
                        //    dtDeadline.Value = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        //}

                        currentDeadline = jo["Deadline"].ToString();
                        currentStatus = jo["Status"].ToString();
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



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //ser.UpdatedStatus = cbStatus.SelectedItem.ToString();
            //ser.UpdatedDeadline = dtDeadline.Value.Date.ToString("yyyy-mm-dd");
            //if (cbStatus.SelectedItem.ToString() == "Approved")
            //{
            //    ser.updateData2();
            //}
            //else if (cbStatus.SelectedItem.ToString() == "Returned")
            //{
            //    ser.updateData();
            //}
            //else
            //{
            //    ser.updateData3();
            //}
            //MessageBox.Show(ser.Message);


            ValidateInventory();

            if (validate == "Yes" && cbStatus.SelectedItem.ToString() == "Approved")
            {
                MessageBox.Show("Not Enough Quantity for " + message);
            }
            else if ((cbStatus.SelectedItem.ToString() == "Approved") && (currentStatus == "Approved") && (dtDeadline.Value.Date.ToString("yyyy-MM-dd") == currentDeadline) )
            {
                MessageBox.Show("Unable to Update because you never change anything.");
            }
            else if ( "Returned" == currentStatus)
            {
                MessageBox.Show("Unable to Update because the item already returned.");
            }
            else if ("Disapproved" == currentStatus)
            {
                if (cbStatus.SelectedItem.ToString() == "Borrowed")
                {
                    MessageBox.Show("Unable to Update the item to 'Borrowed' from 'Disapproved' Status.");
                }
                else if (cbStatus.SelectedItem.ToString() == "Returned")
                {
                    MessageBox.Show("Unable to Update the item to 'Returned' from 'Disapproved' Status.");
                }
                else if (cbStatus.SelectedItem.ToString() == "Approved")
                {
                    MessageBox.Show("Unable to Update the item to 'Approved' from 'Disapproved' Status.");
                }
                else
                {
                    MessageBox.Show("Unable to Update because the item already 'Disapproved'.");
                }

                // currentStatus == Approved then Update to Disapproved
            }
            else
            {

                try
                {
                    if (Convert.ToString(cbStatus.SelectedItem) != "")
                    { 
                        DateTime dateToday = DateTime.Now;

                        var uri = host.IP() + "/iBar/ibar_misservice_update.php";

                        string responseFromServer;
                        using (var wb = new WebClient())
                        {
                            var datas = new NameValueCollection();
                            datas["Quantity"] = lblQuantity.Text;
                            datas["ItemName"] = lblItem.Text;
                            datas["Category"] = cbStatus.SelectedItem.ToString();
                            datas["Status"] = cbStatus.SelectedItem.ToString();
                            datas["Deadline"] = dtDeadline.Value.Date.ToString("yyyy-MM-dd");
                            datas["Note"] = rbNote.Text=="" ? "NONE" : rbNote.Text;
                            datas["ID"] = ID;

                            var response = wb.UploadValues(uri, "POST", datas);
                            responseFromServer = Encoding.UTF8.GetString(response);
                        }

                        if (responseFromServer == "Operation Success")
                        {
                            MessageBox.Show("Update Successfully");
                            currentStatus = cbStatus.SelectedItem.ToString();
                            lblCurrentStatus.Text = cbStatus.SelectedItem.ToString();

                            ResetList();
                            SendNotif(resUsername, Convert.ToString(cbStatus.SelectedItem), rbNote.Text);
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
        }

        String validate = "", message;
        private async void ValidateInventory()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_misservice_validate.php";

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
                    foreach (var jo in (JArray)((JObject)data)["val"])
                    {

                        validate = jo["cond"].ToString();
                        message = jo["ItemName"] + "\n" + "Available: " + jo["Quantity"];
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

        private void SendNotif(string username, string Stat, string Note)
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

                var topic = username;
                string body = Note == ""? "Status: " + Stat : "Status: " + Stat + "\nNote: " + Note;

                var message = new FirebaseAdmin.Messaging.Message()
                {
                    Notification = new Notification()
                    {
                        Title = "Miscellaneous Services",
                        Body = body
                    },
                    Topic = topic
                };

                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                MessageBox.Show("Sending Notification to "+ resUsername +"....");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadComboBoxes()
        {
            csComboBoxValues cbValues = new csComboBoxValues();
            cbValues.RetrieveArrStatusService();

            cbStatus.Items.AddRange(cbValues.GetArrStatusService().ToArray());
            cbStatus.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ser.Reset();
            this.Close();
        }
    }
}
