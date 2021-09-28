using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            else
            {
                Login();
            }
        }

        private void Login()
        {
            csLogin log = new csLogin();
            log.Login(tbUsername.Text, tbPassword.Text);
            MessageBox.Show(log.Message);

            if (log.GetReady() == log.GetUtype1())
            {
                log.Reset();
                this.Hide();
                var frm = new frmMenuAdmin();
                frm.Closed += (s, args) => this.Close();
                frm.Show();
            }
            else if (log.GetReady() == log.GetUtype2())
            {
                log.Reset();
                this.Hide();
                var frm = new frmMenu();
                frm.Closed += (s, args) => this.Close();
                frm.Show();
            }
            else { }
        }
    }
}
