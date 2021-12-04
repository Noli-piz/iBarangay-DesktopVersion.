using FirebaseAdmin;
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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmAccountMngmnt2 : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        String ID, resUsername="";

        public frmAccountMngmnt2(String id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frmAccountMngmnt2_Load(object sender, EventArgs e)
        {
            loadComboBox();
            SelectData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbNPassword.Text == tbRPassword.Text)
            {
                try
                {
                    var uri = host.IP() + "/iBar/ibar_accountmanagement_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;
                        datas["Username"] = tbUsername.Text;
                        datas["Password"] = tbNPassword.Text == "" ? tbCPassword.Text : tbNPassword.Text;
                        datas["Valid"] = cbValid.SelectedItem.ToString();

                        if (cbAccountStat.SelectedItem.ToString() == "Enabled")
                        {
                            datas["Status"] = "0";
                        }
                        else
                        {
                            datas["Status"] = "1";
                        }

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed " + responseFromServer);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("New Password is not equal to Re-type Password");
            }

        }

        private async void SelectData()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_accountmanagement_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["account"])
                    {
                        lblName.Text = jo["Fname"].ToString() +" "+ jo["Mname"].ToString() + " " + jo["Lname"].ToString() +" "+ jo["Sname"].ToString();
                        lblGender.Text = jo["Gender"].ToString();
                        lblBirthDate.Text = jo["Birthdate"].ToString();
                        lblBirthplace.Text = jo["Birthplace"].ToString();
                        lblVstat.Text = jo["VoterStatus"].ToString()== "Yes" ? "Registered" : "Not Registered";
                        lblCedula.Text = jo["CedulaNo"].ToString();
                        lblContact.Text = jo["ContactNo"].ToString();
                        lblCivilstat.Text = jo["CivilStatus"].ToString();
                        lblDoR.Text = jo["DateOfRegistration"].ToString();

                        tbUsername.Text = jo["Username"].ToString();
                        resUsername = jo["Username"].ToString();
                        tbCPassword.Text = jo["Password"].ToString();
                        cbAccountStat.Text = jo["Status"].ToString() == "0"? "Enabled" : "Disabled";
                        cbValid.Text = jo["Valid"].ToString() == "0" ? "Not Validated" : "Validated";
                        DownloadImage3(jo["Image"].ToString());

                        string valid = jo["img_idcloseup"].ToString();
                        if ( valid != "0")
                        {
                            DownloadImage(jo["img_idcloseup"].ToString());
                            DownloadImage2(jo["img_facewithid"].ToString());
                        }
                        
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

        //Send Notification
        private void btnPush_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
            SendNotif(resUsername, cbValid.SelectedItem.ToString(), rbMessage.Text);
        }
        private void SendNotif(string username, string Stat, string Message)
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
                var message = new FirebaseAdmin.Messaging.Message()
                {
                    Notification = new Notification()
                    {
                        Title = "Verification Info.",
                        Body = "Status: " + Stat +"\nInformation: " + Message
                    },
                    Topic = topic
                };

                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                MessageBox.Show("Pushing Notification to Resident....");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //
        private async void DownloadImage(String url)
        {
            var request = WebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {

                Image img = new Bitmap(stream);
                pbImage1.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
            }
        }

        private async void DownloadImage2(String url)
        {
            var request = WebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {

                Image img = new Bitmap(stream);
                pbImage2.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
            }
        }

        private async void DownloadImage3(String url)
        {
            try
            {
                var request = WebRequest.Create(url);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {

                    Image img = new Bitmap(stream);
                    pbProfile.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
                }
            }
            catch (WebException e)
            {
                MessageBox.Show("Please check your Internet. Images may not load properly.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void loadComboBox()
        {
            csComboBoxValues cb = new csComboBoxValues();
            cb.RetrieveArrUserStatus();

            cbAccountStat.Items.AddRange(cb.GetArrUserStatus().ToArray());
            cbAccountStat.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide1_Click(object sender, EventArgs e)
        {
            tbCPassword.PasswordChar = tbCPassword.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbCPassword.PasswordChar.ToString() == "*")
            {
                btnHide1.Image = Properties.Resources.sharp_visibility_off_black_18dp;
            }
            else
            {
                btnHide1.Image = Properties.Resources.sharp_visibility_black_18dp;
            }
        }

        private void btnHide2_Click(object sender, EventArgs e)
        {
            tbNPassword.PasswordChar = tbNPassword.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbNPassword.PasswordChar.ToString() == "*")
            {
                btnHide2.Image = Properties.Resources.sharp_visibility_off_black_18dp;
            }
            else
            {
                btnHide2.Image = Properties.Resources.sharp_visibility_black_18dp;
            }
        }


        private void btnHide3_Click(object sender, EventArgs e)
        {
            tbRPassword.PasswordChar = tbRPassword.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbRPassword.PasswordChar.ToString() == "*")
            {
                btnHide3.Image = Properties.Resources.sharp_visibility_off_black_18dp;
            }
            else
            {
                btnHide3.Image = Properties.Resources.sharp_visibility_black_18dp;
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
