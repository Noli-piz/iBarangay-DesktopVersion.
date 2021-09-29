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
            if (tbUsername.Text == null || tbUsername.Text == "")
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
                cs.Login(tbUsername.Text, tbPassword.Text, cbUsertype.SelectedItem.ToString());

                MessageBox.Show(cs.Message);
                if (cs.Message == "Login Success")
                {
                    this.Hide();
                }
            }
        }
    }
}
