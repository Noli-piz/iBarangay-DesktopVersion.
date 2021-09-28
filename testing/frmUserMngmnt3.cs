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
    public partial class frmUserMngmnt3 : Form
    {

        public frmUserMngmnt3()
        {
            InitializeComponent();
        }

        private void frmUserMngmnt3_Load(object sender, EventArgs e)
        {
            loadCombobox();
            loadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text == tbRetypePassword.Text)
            {
                csUserMngmnt man = new csUserMngmnt();
                man.Fullname = tbFullName.Text;
                man.Username = tbUsername.Text;
                man.Password = tbNewPass.Text == "" ? tbCurrentPass.Text : tbNewPass.Text;
                man.LevelOfAccess = cbLevelOfAccess.SelectedItem.ToString();
                man.Status = cbStatus.SelectedItem.ToString();
                man.updateUser();

                MessageBox.Show(man.Message);
                man.Reset();

                this.Close();
            }
            else
            {
                MessageBox.Show("New Password is not equal to Re-type Password");
            }
        }

        private void loadData()
        {
            csUserMngmnt man = new csUserMngmnt();
            man.retrieveData();
            tbFullName.Text = man.Fullname;
            tbUsername.Text = man.Username;
            tbCurrentPass.Text = man.Password;
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
