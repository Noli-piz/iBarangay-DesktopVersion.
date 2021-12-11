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
    public partial class frmReports : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        List<string> ID = new List<string>();

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void load()
        {
            string reports = cbReports.SelectedItem.ToString();
            if (reports == "Issuance Reports")
            {
                loadData();

            }
            else if (reports == "Request Reports")
            {
                loadData2();
            }
            else if (reports == "Appointment Reports")
            {
                loadData3();
            }
            else
            {
                loadData();
            }
        }

        private async void loadData()
        {
            try
            {
                ID.Clear();
                data1.Rows.Clear();
                data1.Columns.Clear();

                data1.Columns.Add("no", "No.");
                data1.Columns.Add("id", "ID.");
                data1.Columns.Add("sbjct", "Processed By");
                data1.Columns.Add("dtls", "Processed For");
                data1.Columns.Add("date", "Types");
                data1.Columns.Add("lvl", "Purpose");
                data1.Columns.Add("lvl", "Date");

                data1.Columns["id"].Visible = false;

                var uri = host.IP() + "/iBar/ibar_reportissuance.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    string date1 = dtStart.Value.ToString("yyyy-MM-dd");
                    string date2 = dtEnd.Value.ToString("yyyy-MM-dd");

                    var datas = new NameValueCollection();
                    datas["Date1"] = date1.ToString();
                    datas["Date2"] = date2.ToString();

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["issuancereport"])
                    {
                        ID.Add(jo["id_issuancereports"].ToString());

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_issuancereports"]);
                        AL.Add(jo["Fullname"]);
                        AL.Add(jo["Fname"] +" "+ jo["Mname"] + " " + jo["Lname"] + " " + jo["Sname"]);
                        AL.Add(jo["Types"]);
                        AL.Add(jo["Purpose"]);
                        AL.Add(jo["Date"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                }

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private async void loadData2()
        {
            try
            {

                ID.Clear();
                data1.Rows.Clear();
                data1.Columns.Clear();

                data1.Columns.Add("no", "No.");
                data1.Columns.Add("id", "ID.");
                data1.Columns.Add("", "Processed By");
                data1.Columns.Add("", "Username");
                data1.Columns.Add("", "Processed For");
                data1.Columns.Add("", "Purpose");
                data1.Columns.Add("", "Requested Date");
                data1.Columns.Add("", "Status");
                data1.Columns.Add("", "Delivery Opt.");
                data1.Columns.Add("", "Date");

                data1.Columns["id"].Visible = false;


                var uri = host.IP() + "/iBar/ibar_reportrequest.php";


                string responseFromServer;
                using (var wb = new WebClient())
                {
                    string date1 = dtStart.Value.ToString("yyyy-MM-dd");
                    string date2 = dtEnd.Value.ToString("yyyy-MM-dd");

                    var datas = new NameValueCollection();
                    datas["Date1"] = date1.ToString();
                    datas["Date2"] = date2.ToString();

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["requestreport"])
                    {
                        ID.Add(jo["id_requestsreports"].ToString());

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_requestsreports"]);
                        AL.Add(jo["Fullname"]);
                        AL.Add(jo["Username"]);
                        AL.Add(jo["Fname"] + " " + jo["Mname"] + " " + jo["Lname"] + " " + jo["Sname"]);
                        AL.Add(jo["Purpose"]);
                        AL.Add(jo["DateOfRequest"]);
                        AL.Add(jo["Status"]);
                        AL.Add(jo["Options"]);
                        AL.Add(jo["Date"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                }

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void loadData3()
        {
            try
            {

                ID.Clear();
                data1.Rows.Clear();
                data1.Columns.Clear();

                data1.Columns.Add("", "No.");
                data1.Columns.Add("id", "ID.");
                data1.Columns.Add("", "Fullname");
                data1.Columns.Add("", "Title");
                data1.Columns.Add("", "Name");
                data1.Columns.Add("", "Start Date");
                data1.Columns.Add("", "End Date");
                data1.Columns.Add("", "Details");
                data1.Columns.Add("", "Action Taken");
                data1.Columns.Add("", "Modified Date");
                data1.Columns["id"].Visible = false;


                var uri = host.IP() + "/iBar/ibar_reportappointment.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    string date1 = dtStart.Value.ToString("yyyy-MM-dd");
                    string date2 = dtEnd.Value.ToString("yyyy-MM-dd");

                    var datas = new NameValueCollection();
                    datas["Date1"] = date1.ToString();
                    datas["Date2"] = date2.ToString();

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["appointmentreport"])
                    {
                        ID.Add(jo["id_appointmentreports"].ToString());

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_appointmentreports"]);
                        AL.Add(jo["Fullname"]);
                        AL.Add(jo["Title"]);
                        AL.Add(jo["Name"]);
                        AL.Add(jo["StartTime"]);
                        AL.Add(jo["EndTime"]);
                        AL.Add(jo["Details"]);
                        AL.Add(jo["Status"]);
                        AL.Add(jo["Date"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }

                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                }

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCombobox()
        {
            csComboBoxValues cb = new csComboBoxValues();
            cb.RetrieveArrReports();
            cbReports.Items.AddRange(cb.GetArrReports().ToArray());
            cbReports.SelectedIndex = 0;
        }

        private void cbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            load();
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            load();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            load();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string date1 = dtStart.Value.ToString("yyyy-MM-dd");
            string date2 = dtEnd.Value.ToString("yyyy-MM-dd");

            string reports = cbReports.SelectedItem.ToString();
            if (reports == "Issuance Reports")
            {
                vwrIssuanceReports frm = new vwrIssuanceReports(date1, date2);
                frm.ShowDialog(this);
            }
            else if (reports == "Request Reports")
            {
                vwrRequestReports frm = new vwrRequestReports(date1, date2);
                frm.ShowDialog(this);
            }
            else if (reports == "Appointment Reports")
            {
                vwrAppointmentReport frm = new vwrAppointmentReport(date1, date2);
                frm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Not Available");
            }
        }
    }
}
