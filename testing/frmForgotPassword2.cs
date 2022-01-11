using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmForgotPassword2 : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private csApiKey api = new csApiKey();
        string Email = "", randomNumber="";
        private randomnumClass csrandomNum;

        public frmForgotPassword2(string Email)
        {
            InitializeComponent();
            this.Email = Email;

        }

        private void frmForgotPassword2_Load(object sender, EventArgs e)
        {
            lblEmail.Text = Email;
            LoadApiKey();
        }

        #region
        private void code1_TextChanged(object sender, EventArgs e)
        {
            if (code1.Text.Length > 0)
            {
                code2.Focus();
            }
        }

        private void code2_TextChanged(object sender, EventArgs e)
        {
            if (code2.Text.Length > 0)
            {
                code3.Focus();
            }
        }

        private void code3_TextChanged(object sender, EventArgs e)
        {
            if (code3.Text.Length > 0)
            {
                code4.Focus();
            }
        }

        private void code4_TextChanged(object sender, EventArgs e)
        {
            if (code4.Text.Length > 0)
            {
                code5.Focus();
            }
        }

        private void code5_TextChanged(object sender, EventArgs e)
        {
            if (code5.Text.Length > 0)
            {
                code6.Focus();
            }
        }
        #endregion
        #region
        private void code1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void code4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void code5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void code6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            string code = code1.Text + code2.Text + code3.Text + code4.Text + code5.Text + code6.Text;

            if (code.Length < 6)
            {
                MessageBox.Show("Please fill up all fields.");
            }
            else if (code == randomNumber)
            {
                frmForgotPassword3 frm = new frmForgotPassword3(Email);
                frm.Closed += (s, args) => this.Close();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Verification Code is not equal.");
            }
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

        private void code6_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblResendCode_Click(object sender, EventArgs e)
        {
            csrandomNum = new randomnumClass();
            randomNumber = csrandomNum.randomNum();
            SendEmailAsync(randomNumber);


            lblResendCode.Enabled = false;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(count_down);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private int duration = 240;

        private void count_down(object sender, EventArgs e)
        {

            if (duration == 0)
            {
                timer1.Stop();
                lblResendCode.Enabled = true;
                lblResendCode.Text="Resend Code?";
                duration = 240;
            }
            else if (duration > 0)
            {
                duration--;
                lblResendCode.Text = "Resend OTP in " + duration.ToString() +" second(s).";
            }
        }

        public async void SendEmailAsync(string randomNumber)
        {
            try
            {
                csApiKey ApiKey = new csApiKey();
                ApiKey.loadKeys();

                var client = new SendGridClient(ApiKey.getSendGridKey());
                var msg = new SendGridMessage()
                {

                    From = new EmailAddress(ApiKey.getSendGridEmail(), "iBarangay<no-reply>"),
                    Subject = "Verification Code",
                    PlainTextContent = "Your verification code is: " + randomNumber,
                    HtmlContent = "<p>Your verification code is: <strong> " + randomNumber + "</strong></p>"
                };

                msg.AddTo(new EmailAddress(Email, "ibarangay-user"));
                var response = await client.SendEmailAsync(msg);
                Console.WriteLine("Send Email ERROR: " + response.StatusCode + "");
            }
            catch
            {

            }
        }

    }


    public class randomnumClass
    {
        private static string randNum = "";
        public randomnumClass()
        {
            reset();
            //for (int i = 0; i < 6; i++)
            //{
            //randNum += new Random().Next(1, 9).ToString();
            randNum = new Random().Next(1, 999999).ToString("000000");
            //}
        }

        public string randomNum()
        {
            return randNum;
        }

        public void reset()
        {
            randNum = "";
        }
    }
}
