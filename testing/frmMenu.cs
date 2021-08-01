using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing.Form_Issue_Certificate;

namespace testing
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void ClearPanel()
        {
            this.panel1.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmResidentRec frm = new frmResidentRec() { Dock = DockStyle.Fill, TopLevel= false , TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmBlotterRec frm = new frmBlotterRec() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            btnClearance(sender, e);
        }

        private void btnClearance(object sender, EventArgs e)
        {
            ClearPanel();

            Label lblclearance = new Label();
            lblclearance.Text = "Clearance";
            lblclearance.AutoSize = true;
            lblclearance.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            lblclearance.Location = new System.Drawing.Point(10, 10);
            lblclearance.Click += new EventHandler(btnClearance);
            panel1.Controls.Add(lblclearance);

            Label lblindigency = new Label();
            lblindigency.Text = "Indigency";
            lblindigency.AutoSize = true;
            lblindigency.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            lblindigency.Click += new EventHandler(btnIndigency);
            lblindigency.Location = new System.Drawing.Point(180, 10);
            panel1.Controls.Add(lblindigency);
            
            
            frmIssueBrgyClearance frm = new frmIssueBrgyClearance() { Location = new System.Drawing.Point(0, 40), TopLevel = false, TopMost = false };
            this.panel1.Controls.Add(frm);
            frm.Show();

        }
        private void btnIndigency(object sender, EventArgs e)
        {
            ClearPanel();

            Label lblclearance = new Label();
            lblclearance.Text = "Clearance";
            lblclearance.AutoSize = true;
            lblclearance.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            lblclearance.Location = new System.Drawing.Point(10, 10);
            lblclearance.Click += new EventHandler(btnClearance);
            panel1.Controls.Add(lblclearance);

            Label lblindigency = new Label();
            lblindigency.Text = "Indigency";
            lblindigency.AutoSize = true;
            lblindigency.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            lblindigency.Click += new EventHandler(btnIndigency);
            lblindigency.Location = new System.Drawing.Point(180, 10);
            panel1.Controls.Add(lblindigency);

            frmIssueBrgyIndigency frm = new frmIssueBrgyIndigency() { Location = new System.Drawing.Point(0, 40), TopLevel = false, TopMost = false };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmAppointment frm = new frmAppointment() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmBrgyOfficialList frm = new frmBrgyOfficialList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
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
    }
}
