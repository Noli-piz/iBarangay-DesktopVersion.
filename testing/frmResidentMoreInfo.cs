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
    public partial class frmResidentMoreInfo : Form
    {
        string strFileDownloadUrl = "", strFormerAddress = "", strVoterRegistrationPlace = "";
        public frmResidentMoreInfo(string strFileDownloadUrl, string strFormerAddress, string strVoterRegistrationPlace)
        {
            InitializeComponent();

            this.strFileDownloadUrl = strFileDownloadUrl;
            this.strFormerAddress = strFormerAddress;
            this.strVoterRegistrationPlace = strVoterRegistrationPlace;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmResidentMoreInfo_Load(object sender, EventArgs e)
        {
            if (strFormerAddress != "" && strFormerAddress != null) {
                lblYesNo.Text = "NO";
            }
            else 
            {
                lblYesNo.Text = "YES";
                btnDownloadFile.Visible = false;
            }

            lblFormerComplete.Text = strFormerAddress;
            lblPlaceofReg.Text = strVoterRegistrationPlace;

        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to download this? You will redirected to your default browser.", "Download File", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(strFileDownloadUrl);
                }
            }
            catch
            {

            }
        }
    }
}
