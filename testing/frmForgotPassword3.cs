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
    public partial class frmForgotPassword3 : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        string Email="";

        public frmForgotPassword3( string Email)
        {
            InitializeComponent();
            this.Email = Email;
        }

        private void frmForgotPassword3_Load(object sender, EventArgs e)
        {

        }


        private void UpdatePassword()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_forgotpass_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Email"] = Email;
                    datas["Password"] = tbNewPass.Text;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Operation Success")
                {
                    MessageBox.Show("Update Successfully");

                    frmLogin frm = new frmLogin();
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Update Failed ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text != tbConfirmPass.Text)
            {
                MessageBox.Show("Password and Confirm Password is not equal.");
            }
            else if (tbNewPass.Text == "")
            {
                MessageBox.Show("Password is required.");
            }
            else if (tbConfirmPass.Text == "")
            {
                MessageBox.Show("Confirm Password is required.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset your password?", "Password", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdatePassword();
                }
            }
        }

        private void btnHide2_Click(object sender, EventArgs e)
        {
            tbNewPass.PasswordChar = tbNewPass.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbNewPass.PasswordChar.ToString() == "*")
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
            tbConfirmPass.PasswordChar = tbConfirmPass.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbConfirmPass.PasswordChar.ToString() == "*")
            {
                btnHide2.Image = Properties.Resources.sharp_visibility_off_black_18dp;
            }
            else
            {
                btnHide2.Image = Properties.Resources.sharp_visibility_black_18dp;
            }
        }
    }
}
