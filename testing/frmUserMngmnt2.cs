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
    public partial class frmUserMngmnt2 : Form
    {
        csUserMngmnt man = new csUserMngmnt();
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
                man.Fullname = tbFullName.Text;
                man.Username = tbUsername.Text;
                man.Password = tbPassword.Text;
                man.LevelOfAccess = cbLevelOfAccess.SelectedItem.ToString();
                man.Status = cbStatus.SelectedItem.ToString();
                man.addUser();

                MessageBox.Show(man.Message);
                man.Reset();

                this.Close();
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
            man.Reset();
            this.Close();
        }
    }
}
