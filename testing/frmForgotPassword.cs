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
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmForgotPassword : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        csApiKey api = new csApiKey();
        public frmForgotPassword()
        {
            InitializeComponent();
        }
        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            LoadApiKey();
        }

        private async void LoadApiKey()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_getapikey.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["info"])
                    {
                        api.setSendGridKey(jo["ApiKey"].ToString());
                        api.loadKeys();
                    }
                }
                else if (success == "0")
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == null || tbEmail.Text == "")
            {
                MessageBox.Show("Email is Empty!");
            }
            else
            {
                if (CheckEmailFormat(tbEmail.Text))
                {
                    CheckEmailDatabase();
                }
                else
                {
                    MessageBox.Show("Invalid Email.");
                }
            }
        }

        private void CheckEmailDatabase()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_forgotpass.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Email"] = tbEmail.Text;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Email is Exist")
                {
                    frmForgotPassword2 frm = new frmForgotPassword2(tbEmail.Text);
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(responseFromServer);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private bool CheckEmailFormat(String email)
        {

            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                && Regex.IsMatch(email, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
        }


    }
}
