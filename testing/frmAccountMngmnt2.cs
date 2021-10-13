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

                        if (jo["Status"].ToString() == "0")
                        {
                            cbAccountStat.Text = "Enabled";
                        }
                        else
                        {
                            cbAccountStat.Text = "Disabled";
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
    }
}
