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
        String ID;

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

                        //jo["id_announcement"];
                        lblName.Text = jo["Fname"].ToString() +" "+ jo["Mname"].ToString() + " " + jo["Lname"].ToString() +" "+ jo["Sname"].ToString();
                        tbUsername.Text = jo["Username"].ToString();
                        tbCPassword.Text = jo["Password"].ToString();
                        cbAccountStat.Text = jo["Status"].ToString() == "0"? "Enabled" : "Disabled";

                        if (jo["Valid"].ToString() != "0")
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

        }

        private void btnHide2_Click(object sender, EventArgs e)
        {
            tbNPassword.PasswordChar = tbNPassword.PasswordChar.ToString() == "*" ? '\0' : '*';
        }

        private void btnHide3_Click(object sender, EventArgs e)
        {
            tbRPassword.PasswordChar = tbRPassword.PasswordChar.ToString() == "*" ? '\0' : '*';

        }
    }
}
