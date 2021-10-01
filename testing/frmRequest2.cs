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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmRequest2 : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private String ID = "";

        public frmRequest2(String id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frmRequest2_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            SelectData();
        }




        private async void SelectData()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_request_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["request"])
                    {

                        //jo["id_announcement"];
                        lblDocument.Text = jo["Types"].ToString();
                        lblDate.Text = jo["DateOfRequest"].ToString();
                        rbPurpose.Text = jo["Purpose"].ToString();
                        lblCurrentStatus.Text = jo["Status"].ToString();
                        lblDeliveryOption.Text = jo["Options"].ToString();
                        cbStatus.Text = jo["Status"].ToString();
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


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_request_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;
                    datas["Status"] = cbStatus.SelectedItem.ToString();

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Operation Success")
                {
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed " + responseFromServer);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        
        private void LoadComboBoxes()
        {
            csComboBoxValues cbValues = new csComboBoxValues();
            cbValues.RetrieveStatus();

            cbStatus.Items.AddRange(cbValues.GetArrStatus().ToArray());
            cbStatus.SelectedIndex = 0;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
