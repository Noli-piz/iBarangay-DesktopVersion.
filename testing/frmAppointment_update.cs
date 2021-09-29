using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
    public partial class frmAppointment_update : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        String ID = "";

        public frmAppointment_update(String id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frmAppointment_update_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_appointment_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;
                    datas["Title"] = tbTitle.Text;
                    datas["Name"] = tbName.Text;
                    datas["Date"] = dtDate.Value.ToString("yyyy-MM-dd");
                    datas["EndTime"] = dtTimeEnd.Value.ToString("hh:mm:ss tt");
                    datas["StartTime"] = dtTimeStart.Value.ToString("hh:mm:ss tt");
                    datas["Details"] = rbDetails.Text;
                    datas["Status"] = cbDone.Checked ? "True" : "False";

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
                    MessageBox.Show("Update Failed " + responseFromServer);
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

                var uri = host.IP() + "/iBar/ibar_appointment_delete.php";

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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Delete Failed " + responseFromServer);
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

                var uri = host.IP() + "/iBar/ibar_appointment_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["appointment"])
                    {
                        tbTitle.Text = jo["Title"].ToString();
                        tbName.Text = jo["Name"].ToString();
                        rbDetails.Text = jo["Details"].ToString();

                        String strDate, strStartTime, strEndTime;
                        strDate = jo["Date"].ToString();
                        strEndTime = jo["EndTime"].ToString();
                        strStartTime = jo["StartTime"].ToString();

                        dtDate.Value = DateTime.ParseExact(strDate, "yyyy-MM-dd", null);
                        dtTimeEnd.Value = DateTime.ParseExact(strEndTime, "hh:mm:ss tt", null);
                        dtTimeStart.Value = DateTime.ParseExact(strStartTime, "hh:mm:ss tt", null);

                        if (jo["Status"].ToString() == "True")
                        {
                            cbDone.Checked = true;
                        }
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
    }
}
