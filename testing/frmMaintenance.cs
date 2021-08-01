using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace testing
{
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }
        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem in the internet.");
            }
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "YO2vBBOCiAVlj8Tvzc2an6PfAbIJVb51HXhQhBz8",
            BasePath = "https://ibarangay-23725-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        private async void btnAdd1_Click(object sender, EventArgs e)
        {
            csMaintenance res = new csMaintenance()
            {
                mtnCivilStatus = tbCivilStatus.Text
            };

            var setter = client.Push("tblCivilStatus/", res.mtnCivilStatus);
            MessageBox.Show("Data Inserted Successfully");
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            csMaintenance res = new csMaintenance()
            {
                mtnGender = tbGender.Text
            };

            var setter = client.Push("tblGender", res.mtnGender);
            MessageBox.Show("Data Inserted Successfully");
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            csMaintenance res = new csMaintenance()
            {
                mtnPurok = tbPurok.Text
            };

            var setter = client.Push("tblPurok/", res.mtnPurok);
            MessageBox.Show("Data Inserted Successfully");
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            csMaintenance res = new csMaintenance()
            {
                mtnVoterStatus = tbVoterStatus.Text
            };

            var setter = client.Push("tblVoterStatus/", res.mtnVoterStatus);
            MessageBox.Show("Data Inserted Successfully");
        }
    }
}
