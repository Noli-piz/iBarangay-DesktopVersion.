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
    public partial class frmUserMngmnt3 : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        String ID;

        public frmUserMngmnt3(String id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frmUserMngmnt3_Load(object sender, EventArgs e)
        {
            loadCombobox();
            SelectData();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text == tbRetypePassword.Text)
            {
                try
                {
                    var uri = host.IP() + "/iBar/ibar_usermanagement_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;
                        datas["Fullname"] = tbFullName.Text;
                        datas["Username"] = tbUsername.Text;
                        datas["Password"] = tbNewPass.Text == "" ? tbCurrentPass.Text : tbNewPass.Text;
                        datas["LevelOfAccess"] = cbLevelOfAccess.SelectedItem.ToString();

                        if (cbStatus.SelectedItem.ToString() == "Enabled")
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
                var uri = host.IP() + "/iBar/ibar_usermanagement_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["users"])
                    {

                        //jo["id_announcement"];
                        tbFullName.Text = jo["Fullname"].ToString();
                        tbUsername.Text = jo["Username"].ToString();
                        tbCurrentPass.Text = jo["Password"].ToString();
                        cbLevelOfAccess.Text = jo["LevelOfAccess"].ToString();

                        if (jo["Status"].ToString() == "0")
                        {
                            cbStatus.Text = "Enabled";
                        }
                        else
                        {
                            cbStatus.Text = "Disabled";
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

        private void loadCombobox()
        {
            csComboBoxValues cb = new csComboBoxValues();
            cb.RetrieveArrLevelOfAccess();
            cb.RetrieveArrUserStatus();

            cbLevelOfAccess.Items.AddRange(cb.GetArrLevelOfAccess().ToArray());
            cbStatus.Items.AddRange(cb.GetArrUserStatus().ToArray());

            cbLevelOfAccess.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;

        }
    }
}
