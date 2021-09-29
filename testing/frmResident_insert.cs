﻿using System;
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
using System.IO;
using System.Threading;
using Firebase.Storage;
using MySql.Data.MySqlClient;

namespace testing
{
    public partial class frmResident_insert : Form
    {
        csResidents res = new csResidents();
        String path ="";

        public frmResident_insert()
        {
            InitializeComponent();
        }
        private void frmAddNewResident_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            res.Fname = tbFname.Text;
            res.Mname = tbMname.Text;
            res.Lname = tbLname.Text;
            res.Sname = tbSname.Text;
            res.BirthPlace = rtbBirthPlace.Text;
            res.BirthDate = dtBirthDate.Value.ToString("yyyy-MM-dd");
            res.CivilStatus = cbCivilStatus.SelectedItem.ToString();
            res.Gender = cbGender.SelectedItem.ToString();
            res.Purok = cbPurok.SelectedItem.ToString();
            res.VoterStatus = cbVoterStatus.SelectedItem.ToString();
            res.CedulaNo = tbCedulaNo.Text;
            res.ContactNo = tbContactNo.Text;
            res.Email = tbEmailAddress.Text;
            res.DateOfRegistration = dtDateOfRgstrtn.Value.ToString("yyyy-MM-dd");

            res.InsertData();

            string message = res.Message;
            MessageBox.Show(message);
            if (message== "Successfully Added")
            {
                res.ResetData();
                Reset();
            }
        }

        private void Reset()
        {
            foreach (Control field in frmResident_insert.ActiveForm.Controls)
            {
                if (field is TextBox)
                    ((TextBox)field).Clear();
                if (field is PictureBox)
                    ((PictureBox)field).Image = null;
                if (field is RichTextBox)
                    ((RichTextBox)field).Clear();
            }
        }

        private void LoadComboBoxes()
        {
            csComboBoxValues cbValues = new csComboBoxValues();
            cbValues.RetrieveGender();
            cbValues.RetrieveCivilStatus();
            cbValues.RetrievePurok();
            cbValues.RetrieveVoterStat();

            cbGender.Items.AddRange(cbValues.GetArrGender().ToArray());
            cbCivilStatus.Items.AddRange(cbValues.GetArrCivilStatus().ToArray());
            cbPurok.Items.AddRange(cbValues.GetArrPurok().ToArray());
            cbVoterStatus.Items.AddRange(cbValues.GetArrVoterStat().ToArray());

            cbGender.SelectedIndex = 0;
            cbCivilStatus.SelectedIndex = 0;
            cbPurok.SelectedIndex = 0;
            cbVoterStatus.SelectedIndex = 0;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image files(*.jpg) | *.jpg";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                UploadImage();
            }
            ofd.Dispose();
        }



        private async void UploadImage()
        {
            using (var stream = File.Open(@path, FileMode.Open)) {

                var task = new FirebaseStorage("ibarangay-23725.appspot.com")
                .Child("images")
                .Child(gnrtRandomFileName())
                .PutAsync(stream);

                task.Progress.ProgressChanged += (s, e) => lblProgress.Text = ($"Uploading: {e.Percentage} %");

                var downloadUrl = await task;
            };
            if (lblProgress.Text.Equals("Uploading: 100 %")) {
                Image img = new Bitmap(path);
                pictureBox1.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
                lblProgress.Text = "";
            }
        }

        private String gnrtRandomFileName()
        {
            String random = Guid.NewGuid().ToString();
            res.Image = random;
            return random;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
