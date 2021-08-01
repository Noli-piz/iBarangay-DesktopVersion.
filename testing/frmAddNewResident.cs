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
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using Newtonsoft.Json;

namespace testing
{
    public partial class frmAddNewResident : Form
    {
        csResidents res;

        public frmAddNewResident()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            res.Fname = tbFname.Text.ToString();
            res.Mname = "";
            res.Lname = "";
            res.Sname = "";
            res.BirthDate = "";
            res.BirthPlace = "";
            res.CivilStatus = "";
            res.Gender = "";
            res.Purok = "";
            res.VoterStatus = "";
            res.CedulaNo = "";
            res.PhoneNo = "";
            res.EmailAddress = "";
        }
    }
}
