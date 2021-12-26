using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmOfficials_update : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        String ID = "";

        public frmOfficials_update( String id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frmOfficials_update_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_official_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;
                    datas["Fname"] = tbFullname.Text;
                    datas["Position1"] = tbPos1.Text;
                    datas["Position2"] = tbPos2.Text;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Operation Success")
                {
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_official_delete.php";

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
                }
                else
                {
                    MessageBox.Show("Delete Failed ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private async void SelectData()
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_official_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["official"])
                    {
                        tbFullname.Text = jo["Fname"].ToString();
                        tbPos1.Text = jo["Position1"].ToString();
                        tbPos2.Text = jo["Position2"].ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
