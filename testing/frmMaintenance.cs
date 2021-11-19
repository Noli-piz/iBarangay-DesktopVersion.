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
            tabAlertLevel frm = new tabAlertLevel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabAlertLevel.Controls.Add(frm);
            frm.Show();

            tabCertificates frm2 = new tabCertificates() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabCertificate.Controls.Add(frm2);
            frm2.Show();

            tabCivilStatus frm3 = new tabCivilStatus() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabCivilStatus.Controls.Add(frm3);
            frm3.Show();

            tabDeliveryOptions frm4 = new tabDeliveryOptions() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabdeliveryoption.Controls.Add(frm4);
            frm4.Show();

            tabGender frm5 = new tabGender() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabGender.Controls.Add(frm5);
            frm5.Show();

            tabItems frm6 = new tabItems() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabItems.Controls.Add(frm6);
            frm6.Show();

            tabPurok frm7 = new tabPurok() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.tabPurok.Controls.Add(frm7);
            frm7.Show();
        }
    }
}
