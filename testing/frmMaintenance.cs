using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmMaintenance : Form
    {
        csHostConfiguration host = new csHostConfiguration();

        public frmMaintenance()
        {
            InitializeComponent();
        }
        private void frmMaintenance_Load(object sender, EventArgs e)
        {

        }

        private void btnAlertLevels_Click(object sender, EventArgs e)
        {
            ClearPanel();

            tabAlertLevel frm = new tabAlertLevel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnCertificate_Click(object sender, EventArgs e)
        {
            ClearPanel();

            tabCertificates frm = new tabCertificates() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnCivilStatus_Click(object sender, EventArgs e)
        {
            ClearPanel();

            tabCivilStatus frm = new tabCivilStatus() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnDeliveryOpt_Click(object sender, EventArgs e)
        {
            ClearPanel();

            tabDeliveryOptions frm = new tabDeliveryOptions() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnGender_Click(object sender, EventArgs e)
        {
            ClearPanel();

            tabGender frm = new tabGender() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            ClearPanel();

            tabItems frm = new tabItems() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnPurok_Click(object sender, EventArgs e)
        {
            ClearPanel();

            tabPurok frm = new tabPurok() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void ClearPanel()
        {
            this.panel1.Controls.Clear();
        }
    }
}
