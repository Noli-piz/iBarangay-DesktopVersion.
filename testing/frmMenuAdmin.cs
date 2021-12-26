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
    public partial class frmMenuAdmin : Form
    {
        public frmMenuAdmin()
        {
            InitializeComponent();
        }

        private void frmMenuAdmin_Load(object sender, EventArgs e)
        {
            csUser user = new csUser();
            lblUsername.Text = user.username();
            lblName.Text = user.name();

            btnHome_Click(sender, e);
        }
        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmAnnouncement frm = new frmAnnouncement() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnBarangay_Click(object sender, EventArgs e)
        {
            ClearPanel();
            
            frmOfficials frm = new frmOfficials() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmUserMngmnt frm = new frmUserMngmnt() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmAccountManagement frm = new frmAccountManagement() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnGReports_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmReports frm = new frmReports() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmMaintenance frm = new frmMaintenance() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you to logout?", "Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Closed += (s, args) => this.Close();
                frm.Show();
            }
        }

        private void ClearPanel()
        {
            this.panel1.Controls.Clear();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmHomeAdmin frm = new frmHomeAdmin() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
            this.Hide();
        }
    }
}
