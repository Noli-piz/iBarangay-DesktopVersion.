﻿using Newtonsoft.Json;
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
    public partial class frmAppoint_update : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private string content = "";

        public frmAppoint_update(string content)
        {
            InitializeComponent();
            this.content = content;
        }

        private void frmAppoint_update_Load(object sender, EventArgs e)
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
                    datas["content"] = content;
                    datas["Title"] = tbTitle.Text;
                    datas["Name"] = tbName.Text;
                    datas["Details"] = rbDetails.Text;
                    datas["Date"] = dtStartDate.Value.ToString("yyyy-MM-dd");
                    datas["StartTime"] = dtStartDate.Value.ToString("yyyy-MM-dd ") + dtStartTime.Value.ToString("HH:mm tt");
                    datas["EndTime"] = dtEndDate.Value.ToString("yyyy-MM-dd ") + dtEndTime.Value.ToString("HH:mm tt");
                    datas["Status"] = cbDone.Checked ? "True" : "False";

                    csUser user = new csUser();
                    datas["UserID"] = user.strID();

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
                    datas["content"] = content;

                    csUser user = new csUser();
                    datas["UserID"] = user.strID();

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
                    datas["ID"] = content;

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

                        String strStartTime, strEndTime;
                        strEndTime = jo["EndTime"].ToString();
                        strStartTime = jo["StartTime"].ToString();

                        dtStartTime.Value = DateTime.ParseExact(strStartTime, "yyyy-MM-dd HH:mm tt", null);
                        dtEndTime.Value = DateTime.ParseExact(strEndTime, "yyyy-MM-dd HH:mm tt", null);

                        dtStartDate.Value = DateTime.ParseExact(strStartTime, "yyyy-MM-dd HH:mm tt", null);
                        dtEndDate.Value = DateTime.ParseExact(strEndTime, "yyyy-MM-dd HH:mm tt", null);

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
