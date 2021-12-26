using AForge.Video;
using AForge.Video.DirectShow;
using Firebase.Storage;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testing.Properties;

namespace testing
{
    public partial class frmResident_update : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        csResidents res = new csResidents();
        String path = "", strImageUrl, ID;

        public frmResident_update(string id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frmUpdateResident_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                mcboCamera.Items.Add(filterInfo.Name);
            mcboCamera.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }   

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //res.Fname = tbFname.Text;
            //res.Mname = tbMname.Text;
            //res.Lname = tbLname.Text;
            //res.Sname = tbSname.Text;
            //res.BirthPlace = rtbBirthPlace.Text;
            //res.BirthDate = dtBirthDate.Value.ToString("yyyy-MM-dd");
            //res.CivilStatus = cbCivilStatus.SelectedItem.ToString();
            //res.Gender = cbGender.SelectedItem.ToString();
            //res.Purok = cbPurok.SelectedItem.ToString();
            //res.VoterStatus = cbVoterStatus.SelectedItem.ToString();
            //res.CedulaNo = tbCedulaNo.Text;
            //res.ContactNo = tbContactNo.Text;
            //res.Email = tbEmailAddress.Text;
            //res.DateOfRegistration = dtDateOfRgstrtn.Value.ToString("yyyy-MM-dd");
            //res.HouseNoAndStreet = rbHouseNoAndStreet.Text;

            //res.UpdateData();

            //string message = res.Message;
            //MessageBox.Show(message);
            //if (message == "Successfully Updated")
            //{
            //    res.ResetData();
            //    Reset();
            //    this.Close();
            //}

            try
            {
                if (tbFname.Text != "" && tbLname.Text != "")
                {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_resident_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;
                        datas["Fname"] = tbFname.Text;
                        datas["Mname"] = tbMname.Text;
                        datas["Lname"] = tbLname.Text;
                        datas["Sname"] = tbSname.Text;
                        datas["Birthplace"] = rtbBirthPlace.Text;
                        datas["Birthdate"] = dtBirthDate.Value.ToString("yyyy-MM-dd");
                        datas["CivilStatus"] = cbCivilStatus.SelectedItem.ToString();
                        datas["Gender"] = cbGender.SelectedItem.ToString();
                        datas["id_purok"] = cbPurok.SelectedItem.ToString();
                        datas["VoterStatus"] = cbVoterStatus.SelectedItem.ToString();
                        datas["DateOfRegistration"] = dtDateOfRgstrtn.Value.ToString("yyyy-MM-dd");
                        datas["CedulaNo"] = tbCedulaNo.Text;
                        datas["ContactNo"] = tbCedulaNo.Text;
                        datas["Email"] = tbEmailAddress.Text;
                        datas["Image"] = strImageUrl;
                        datas["HouseAndStreet"] = rbHouseNoAndStreet.Text;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill-up all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private async void LoadData()
        {
            //res.retrieveData();
            //tbFname.Text = res.Fname;
            //tbMname.Text = res.Mname;
            //tbLname.Text = res.Lname;
            //tbSname.Text = res.Sname;
            //rtbBirthPlace.Text = res.BirthPlace;
            //dtBirthDate.Value = DateTime.ParseExact(res.BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //cbCivilStatus.Text = res.CivilStatus;
            //cbGender.Text = res.Gender;
            //cbPurok.Text = res.Purok;
            //cbVoterStatus.Text = res.VoterStatus;
            //rbHouseNoAndStreet.Text = res.HouseNoAndStreet;

            //tbCedulaNo.Text = res.CedulaNo;
            //tbContactNo.Text = res.ContactNo;
            //tbEmailAddress.Text = res.Email;
            //dtDateOfRgstrtn.Value = DateTime.ParseExact(res.DateOfRegistration,"yyyy-MM-dd", CultureInfo.InvariantCulture);
            ////DownloadImage();
            //DownloadImage(res.Image);


            try
            {
                var uri = host.IP() + "/iBar/ibar_resident_specific.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();

                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["resident"])
                    {
                        tbFname.Text = jo["Fname"].ToString();
                        tbMname.Text = jo["Mname"].ToString();
                        tbLname.Text = jo["Lname"].ToString();
                        tbSname.Text = jo["Sname"].ToString();
                        rtbBirthPlace.Text = jo["Birthplace"].ToString();
                        dtBirthDate.Value = DateTime.ParseExact(jo["Birthdate"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        cbCivilStatus.Text = jo["CivilStatus"].ToString();
                        cbGender.Text = jo["Gender"].ToString();
                        cbPurok.Text = jo["Purok"].ToString();
                        cbVoterStatus.Text = jo["VoterStatus"].ToString();
                        rbHouseNoAndStreet.Text = jo["HouseNoAndStreet"].ToString();

                        tbCedulaNo.Text = jo["CedulaNo"].ToString();
                        tbContactNo.Text = jo["ContactNo"].ToString();
                        tbEmailAddress.Text = jo["Email"].ToString();
                        dtDateOfRgstrtn.Value = DateTime.ParseExact(jo["DateOfRegistration"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        strImageUrl = jo["Image"].ToString();
                        DownloadImage(jo["Image"].ToString());

                    }

                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// //////////////// AZURE
        /// </summary>
        private async void UploadImage()
        {
            try
            {
                lblProgress.Visible = true;
                lblProgress.Text = "Uploading...";

                byte[] file = System.IO.File.ReadAllBytes(path);
                MemoryStream inputStream = new MemoryStream(file);


                var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=ibarangaystorage;AccountKey=SuJ5YP5ovCzjeBc9sLKwbbhrk8GIWjrSyO493EnTRLc7tpNxApS/sdsIvk+qXWOhohgVASKI6VjFgrCYGYiuEw==;EndpointSuffix=core.windows.net");
                var client = account.CreateCloudBlobClient();
                var container = client.GetContainerReference("profileimages");
                await container.CreateIfNotExistsAsync();
                var name = Guid.NewGuid().ToString();
                var blockBlob = container.GetBlockBlobReference($"{name}.png");
                await blockBlob.UploadFromStreamAsync(inputStream);
                string URL = blockBlob.Uri.OriginalString;
                strImageUrl = URL;


                MessageBox.Show("Upload Successful");
                res.Image = strImageUrl;
                DownloadImage(strImageUrl);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "Upload Failed");
            }
        }


        private async void DownloadImage(String strImageUrl)
        {
            try
            {
                lblProgress.Text = "Loading...";

                var request = WebRequest.Create(strImageUrl);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {

                    Image img = new Bitmap(stream);
                    pictureBox1.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
                }
            }
            catch (Exception e)
            {
                Image img = Resources.noimg;
                pictureBox1.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
            }
            finally
            {
                lblProgress.Text = "";
            }
        }


        /// <summary>
        /// /////////////////
        /// </summary>

        private async void UploadImageFirebase()
        {
            using (var stream = File.Open(@path, FileMode.Open))
            {

                var task = new FirebaseStorage("ibarangay-23725.appspot.com")
                .Child("images")
                .Child(gnrtRandomFileName())
                .PutAsync(stream);

                task.Progress.ProgressChanged += (s, e) => lblProgress.Text = ($"Uploading: {e.Percentage} %");
                var downloadUrl = await task;
            };
            if (lblProgress.Text.Equals("Uploading: 100 %"))
            {
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

        /// <summary>
        /// 
        /// </summary>
        private async void DownloadImageFirebase()
        {
            try
            {
                var webClient = new System.Net.WebClient();
                var storage = new FirebaseStorage("ibarangay-23725.appspot.com")
                    .Child("images")
                    .Child(res.Image)
                    .GetDownloadUrlAsync();

                var url = await storage;
                DisplayImageFirebase(url);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);

                var webClient = new System.Net.WebClient();
                var storage = new FirebaseStorage("ibarangay-23725.appspot.com")
                    .Child("images")
                    .Child("n.jpg")
                    .GetDownloadUrlAsync();

                var url = await storage;
                DisplayImageFirebase(url);
            }
        }

        private async void DisplayImageFirebase(String url)
        {
            var webClient = new System.Net.WebClient();
            var bytes = webClient.DownloadData(url);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                var image = System.Drawing.Image.FromStream(ms, true);
                pictureBox1.Image = image.GetThumbnailImage(200, 200, null, new IntPtr());
                ms.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
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

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image files(*.jpg) | *.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                UploadImage();
            }
            ofd.Dispose();
        }

        // Open Camera
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            if (btnOpenCamera.Text == "Open Cam")
            {
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[mcboCamera.SelectedIndex].MonikerString);
                videoCaptureDevice.VideoResolution = videoCaptureDevice.VideoCapabilities[2];
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();
                btnOpenCamera.Text = "Close Cam";
            }
            else
            {
                videoCaptureDevice.Stop();
                pictureBox1.Image = null;
                btnOpenCamera.Text = "Open Cam";
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
        }

        private void frmResident_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
        }

        //SaveImage
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap varBmp = new Bitmap(pictureBox1.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                varBmp.Save(@"D:\ImageProject\a.png", ImageFormat.Png);
                varBmp.Dispose();
                varBmp = null;

                path = @"D:\ImageProject\a.png";
                UploadImage();
                btnOpenCamera_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something went wrong.");
            }
        }
    }
}
