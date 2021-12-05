﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing.Form_Issue_Certificate;

namespace testing
{
    public partial class frmMenu : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(

            int nLeft,
            int nTop,
            int nRight,
            int nBottom,
            int nWidthEllipse,
            int nHeightEllipse

            );

        public frmMenu()
        {
            InitializeComponent();
            csUser user = new csUser();
            lblUsername.Text = user.username();
            lblName.Text = user.name();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            //RoundImage();
            btnHome_Click(sender, e);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmHome frm = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearPanel();

            frmResident frm = new frmResident() { Dock = DockStyle.Fill, TopLevel= false , TopMost = true };
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
            ClearPanel();
            frmIssuance frm = new frmIssuance() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();

        }



        private void btnRequest_Click(object sender, EventArgs e)
        {
            ClearPanel();
            frmRequest frm = new frmRequest() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnMisService_Click(object sender, EventArgs e)
        {
            ClearPanel();
            frmMisService frm = new frmMisService() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            ClearPanel();
            frmAppoint frm = new frmAppoint() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }

        
        private void button8_Click(object sender, EventArgs e)
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



        private void RoundImage()
        {
            pictureBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0,0,pictureBox2.Width, pictureBox2.Height,90,90));
        }



    }
}
