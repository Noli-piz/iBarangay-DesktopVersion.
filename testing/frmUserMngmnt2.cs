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
    public partial class frmUserMngmnt2 : Form
    {
        csHostConfiguration host = new csHostConfiguration();

        public frmUserMngmnt2()
        {
            InitializeComponent();
        }

        private void frmUserMngment2_Load(object sender, EventArgs e)
        {
            loadCombobox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           if (tbPassword.Text == tbRetypePassword.Text)
            {
                try
                {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_usermanagement_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["Fullname"] = tbFullName.Text;
                        datas["Username"] = tbUsername.Text;
                        datas["Password"] = tbPassword.Text;
                        datas["LevelOfAccess"] = cbLevelOfAccess.SelectedItem.ToString();

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed " + responseFromServer);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHide1_Click(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbPassword.PasswordChar.ToString() == "*")
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
            tbRetypePassword.PasswordChar = tbRetypePassword.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbRetypePassword.PasswordChar.ToString() == "*")
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
