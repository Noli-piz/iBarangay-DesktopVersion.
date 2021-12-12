using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using System.Net;
using testing.Properties;
using System.Collections.Specialized;

namespace testing
{
    public partial class tabAlertLevel : Form
    {
        private csHostConfiguration host = new csHostConfiguration();
        private string path, strImageUrl="", ID="";
        public tabAlertLevel()
        {
            InitializeComponent();
        }

        private void tabAlertLevel_Load(object sender, EventArgs e)
        {
            mnpltDataGridAlert();
            loadDataAlert();
        }


        private void mnpltDataGridAlert()
        {
            mtrData1.Rows.Clear();
            mtrData1.Columns.Clear();

            mtrData1.Columns.Add("no", "No.");
            mtrData1.Columns.Add("id", "ID.");
            mtrData1.Columns.Add("lvl", "Level Name");
            mtrData1.Columns.Add("img", "Image Location");

            //DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            //btn1.HeaderText = "Action";
            //btn1.Name = "btnGenerate";
            //btn1.Text = "View/Edit";
            //btn1.UseColumnTextForButtonValue = true;
            //mtrData1.Columns.Add(btn1);

            DataGridViewImageColumn btn = new DataGridViewImageColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Image = Properties.Resources.edit_icon;
            mtrData1.Columns.Add(btn);

            mtrData1.Columns["id"].Visible = false;
        }

        private async void loadDataAlert()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_alertlevel.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["level"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_alertlevel"]);
                        AL.Add(jo["LevelName"]);
                        AL.Add(jo["ImageLocation"]);
                        mtrData1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (strImageUrl != "" && tbName.Text != "")
                {

                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_alertlevel_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["LevelName"] = tbName.Text;
                        datas["ImageLocation"] = strImageUrl ;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                        tbName.Text = "";
                        strImageUrl = ""; 
                        pictureBox1.Image = Properties.Resources.upload__1_;


                    }
                    else
                    {
                        MessageBox.Show("Insert Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid input or image.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mtrData1.Rows.Clear();
                loadDataAlert();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID !="") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_alertlevel_delete.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Delete Successfully");
                        ID = "";
                        tbName.Text = "";
                        strImageUrl = "";
                        pictureBox1.Image = Properties.Resources.upload__1_;


                    }
                    else
                    {
                        MessageBox.Show(responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mtrData1.Rows.Clear();
                loadDataAlert();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID !="" && tbName.Text != "") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_alertlevel_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;
                        datas["LevelName"] = tbName.Text;
                        datas["ImageLocation"] = strImageUrl;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        ID = "";
                        tbName.Text = "";
                        strImageUrl = "";
                        pictureBox1.Image = Properties.Resources.upload__1_;

                    }
                    else
                    {
                        MessageBox.Show("Update Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mtrData1.Rows.Clear();
                loadDataAlert();
            }
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image files | *.jpg; *.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                UploadImage();
            }
            ofd.Dispose();
        }

        private void mtrData1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    DataGridViewRow row = mtrData1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    LoadSpecific(identifier);



                    mtrData1.Rows.Clear();
                    loadDataAlert();
                }
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void LoadSpecific(String id)
        {
            ID = id;
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_alertlevel_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["alert"])
                    {
                        tbName.Text = jo["LevelName"].ToString();
                        strImageUrl = jo["ImageLocation"].ToString();
                        DownloadImage();
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
                DownloadImage();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "Upload Failed");
            }
        }

        private async void DownloadImage()
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
            catch (Exception ex)
            {
                Image img = Resources.noimg;
                pictureBox1.Image = img.GetThumbnailImage(200, 200, null, new IntPtr());
            }
            finally
            {
                lblProgress.Text = "";
            }
        }

    }
}
