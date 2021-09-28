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
    public partial class frmAccountMngmnt2 : Form
    {
        csAccountMngmnt acc = new csAccountMngmnt();

        public frmAccountMngmnt2()
        {
            InitializeComponent();
        }

        private void frmAccountMngmnt2_Load(object sender, EventArgs e)
        {
            loadData();
            loadComboBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbNPassword.Text == tbRPassword.Text)
            {
                acc.Password = tbNPassword.Text == ""? tbCPassword.Text : tbNPassword.Text  ;
                acc.Status = cbAccountStat.SelectedItem.ToString();
                acc.Username = tbUsername.Text;
                acc.updateAccount();

                MessageBox.Show(acc.Message);
            }
            else
            {
                MessageBox.Show("New Password is not equal to Re-type Password");
            }

        }

        private void loadData()
        {
            acc.retrieveData();
            tbUsername.Text = acc.Username;
            tbCPassword.Text = acc.Password;
            lblName.Text = acc.Fullname;
        }

        private void loadComboBox()
        {
            csComboBoxValues cb = new csComboBoxValues();
            cb.RetrieveArrUserStatus();

            cbAccountStat.Items.AddRange(cb.GetArrUserStatus().ToArray());
            cbAccountStat.SelectedIndex = 0;
        }
    }
}
