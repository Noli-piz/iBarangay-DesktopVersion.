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
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == null || tbPassword.Text == "")
            {
                MessageBox.Show("Username is Empty!");
            }
            else if (tbPassword.Text == null || tbPassword.Text == "")
            {
                MessageBox.Show("Password is Empty!");
            }
            else if (cbUsertype.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select Usertype.");
            }
            else
            {
                csLogin cs = new csLogin();
                cs.Login(tbPassword.Text, tbPassword.Text, cbUsertype.SelectedItem.ToString());

                MessageBox.Show(cs.Message);
                if (cs.Message == "Login Success")
                {
                    csUser us = new csUser();
                    us.usercredentials(tbPassword.Text);

                    if (cs.uType == "Admin")
                    {
                        frmMenuAdmin frm = new frmMenuAdmin();
                        frm.Closed += (s, args) => this.Close();
                        frm.Show();
                    }
                    else
                    {
                        frmMenu frm = new frmMenu();
                        frm.Closed += (s, args) => this.Close();
                        frm.Show();
                    }

                    this.Hide();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar.ToString() == "*" ? '\0' : '*';
            if (tbPassword.PasswordChar.ToString() == "*")
            {
                btnHide.Image = Properties.Resources.sharp_visibility_off_black_18dp;
            }
            else
            {
                btnHide.Image = Properties.Resources.sharp_visibility_black_18dp;
            }
        }
    }
}
