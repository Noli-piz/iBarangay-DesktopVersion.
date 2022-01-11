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
            
            IntiallizedProcessedBy();
            IntiallizedStatusRequest();
            IntiallizedStatusDelivery();
            LoadCombobox();
        }

        private void load()
        {
            string reports = cbReports.SelectedItem.ToString();
            if (reports == "Issuance Reports")
            {
                lblStatus.Visible = false;
                cbStatus.Visible = false;

                lblDeliveryOpt.Visible = false;
                cbDeliveryOpt.Visible = false;

                loadData("0");
            }
            else if (reports == "Request Reports")
            {
                cbStatus.Items.Clear();
                IntiallizedStatusRequest();
                lblStatus.Visible = true;
                cbStatus.Visible = true;

                lblDeliveryOpt.Visible = true;
                cbDeliveryOpt.Visible = true;

                loadData2("0", "0", "0");
            }
            else if (reports == "Appointment Reports")
            {
                lblStatus.Visible = false;
                cbStatus.Visible = false;

                lblDeliveryOpt.Visible = false;
                cbDeliveryOpt.Visible = false;
                loadData3("0");
            }
            else if (reports == "Miscellaneous Services Reports")
            {
                cbStatus.Items.Clear();
                IntiallizedStatusServices();
                lblStatus.Visible = true;
                cbStatus.Visible = true;

                lblDeliveryOpt.Visible = true;
                cbDeliveryOpt.Visible = true;
                loadData4("0", "0", "0");
            }
            else
            {
                loadData("0");
            }
        }

        private async void loadData(string ProcessedBy)
        {
            try
            {
                cbStatus.Hide();

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
                    datas["ProcessBy"] = ProcessedBy;

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

        private async void loadData2(string ProcessedBy, string Status, string DeliveryOptionParameter)
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
                    datas["ProcessBy"] = ProcessedBy;
                    datas["Status"] = Status;
                    datas["DeliveryOpt"] = DeliveryOptionParameter;


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

        private async void loadData3(string ProcessBy)
        {
            try
            {

                ID.Clear();
                data1.Rows.Clear();
                data1.Columns.Clear();

                data1.Columns.Add("", "No.");
                data1.Columns.Add("id", "ID.");
                data1.Columns.Add("", "Processed By");
                data1.Columns.Add("", "Title");
                data1.Columns.Add("", "Name");
                data1.Columns.Add("", "Start Date");
                data1.Columns.Add("", "End Date");
                data1.Columns.Add("", "Details");
                data1.Columns.Add("", "Action Taken");
                data1.Columns.Add("", "Date Processed");
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
                    datas["ProcessBy"] = ProcessBy;

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

        private async void loadData4(string ProcessBy, string Status, string DeliveryOptionParameter)
        {
            try
            {
                ID.Clear();
                data1.Rows.Clear();
                data1.Columns.Clear();

                data1.Columns.Add("", "No.");
                data1.Columns.Add("id", "ID.");
                data1.Columns.Add("", "Processed By");
                data1.Columns.Add("", "Processed To");
                data1.Columns.Add("", "ItemName");
                data1.Columns.Add("", "Quantity");
                data1.Columns.Add("", "Purpose");
                data1.Columns.Add("", "Delivery Opt.");
                data1.Columns.Add("", "Status");
                data1.Columns.Add("", "Date Processed");

                data1.Columns["id"].Visible = false;


                var uri = host.IP() + "/iBar/ibar_reportmiscellaneous.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    string date1 = dtStart.Value.ToString("yyyy-MM-dd");
                    string date2 = dtEnd.Value.ToString("yyyy-MM-dd");

                    var datas = new NameValueCollection();
                    datas["Date1"] = date1.ToString();
                    datas["Date2"] = date2.ToString();
                    datas["ProcessBy"] = ProcessBy;
                    datas["Status"] = Status;
                    datas["DeliveryOpt"] = DeliveryOptionParameter;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["servicereport"])
                    {
                        string id = jo["id_misservicesreports"].ToString();
                        string fullname = jo["Fullname"].ToString();
                        string username = jo["Username"].ToString();
                        string fname = jo["Fname"].ToString();
                        string mname = jo["Mname"].ToString();
                        string lname = jo["Lname"].ToString();
                        string sname = jo["Sname"].ToString();
                        string itemname = jo["ItemName"].ToString();
                        string quantity = jo["Quantity"].ToString();
                        string purpose = jo["Purpose"].ToString();
                        string status = jo["Status"].ToString();
                        string dor = jo["DateOfRequest"].ToString();
                        string deadline = jo["Deadline"].ToString();
                        string note = jo["Note"].ToString();
                        string options = jo["Options"].ToString();
                        string dateprocessed = jo["DateProcessed"].ToString();


                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(id);
                        AL.Add(fullname);
                        AL.Add(fname +" "+ mname +" "+ lname +" "+ sname);
                        AL.Add(itemname);
                        AL.Add(quantity);
                        AL.Add(purpose);
                        AL.Add(options);
                        AL.Add(status);
                        AL.Add(dateprocessed);


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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string date1 = dtStart.Value.ToString("yyyy-MM-dd");
            string date2 = dtEnd.Value.ToString("yyyy-MM-dd");
            string stat = cbStatus.SelectedItem.ToString();
            string processby = cbProcessBy.SelectedValue.ToString();
            string delivery = cbDeliveryOpt.SelectedValue.ToString();

            string reports = cbReports.SelectedItem.ToString();
            if (reports == "Issuance Reports")
            {
                vwrIssuanceReports frm = new vwrIssuanceReports(date1, date2, processby, delivery);
                frm.ShowDialog(this);
            }
            else if (reports == "Request Reports")
            {
                vwrRequestReports frm = new vwrRequestReports(date1, date2, processby, stat);
                frm.ShowDialog(this);
            }
            else if (reports == "Appointment Reports")
            {
                vwrAppointmentReport frm = new vwrAppointmentReport(date1, date2);
                frm.ShowDialog(this);
            }
            else if (reports == "Miscellaneous Services Reports")
            {
                vwrMiscellaneousServices frm = new vwrMiscellaneousServices(date1, date2, processby, stat, delivery);
                frm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Not Available");
            }

           
        }

        private async void IntiallizedProcessedBy()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_usermanagement.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    cbProcessBy.ValueMember = "Id";
                    cbProcessBy.DisplayMember = "Fullname";

                    List<ProcessedBy> items = new List<ProcessedBy>();
                    items.Add(new ProcessedBy { Id = (string)"0", Fullname = (string)"All"});

                    foreach (var jo in (JArray)((JObject)data)["users"])
                    {
                        items.Add(new ProcessedBy { Id = (string)jo["id_users"], Fullname = (string)jo["Fullname"] });
                    }

                    cbProcessBy.DataSource = items;
                }
                else if (success == "0")
                {
                    //MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void IntiallizedStatusRequest()
        {
            try
            {
                csComboBoxValues cbValues = new csComboBoxValues();
                cbValues.RetrieveStatus();

                cbStatus.Items.Add("All");
                cbStatus.Items.AddRange(cbValues.GetArrStatus().ToArray());
                cbStatus.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void IntiallizedStatusServices()
        {
            try
            {
                csComboBoxValues cbValues = new csComboBoxValues();
                cbValues.RetrieveArrStatusService();

                cbStatus.Items.Add("All");
                cbStatus.Items.AddRange(cbValues.GetArrStatusService().ToArray());
                cbStatus.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private async void IntiallizedStatusDelivery()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_deliveryoptions.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    cbDeliveryOpt.ValueMember = "Id";
                    cbDeliveryOpt.DisplayMember = "Options";

                    List<DeliveryOptions> items = new List<DeliveryOptions>();
                    items.Add(new DeliveryOptions { Id = (string)"0", Options = (string)"All" });

                    foreach (var jo in (JArray)((JObject)data)["deliveryoptions"])
                    {
                        items.Add(new DeliveryOptions { Id = (string)jo["id_deliveryoption"], Options = (string)jo["Options"] });
                    }

                    cbDeliveryOpt.DataSource = items;
                }
                else if (success == "0")
                {
                    //MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            string reports = cbReports.SelectedItem.ToString();
            string stat = cbStatus.SelectedItem.ToString();
            string processby = cbProcessBy.SelectedValue.ToString();
            string deliveryoptions = cbDeliveryOpt.SelectedValue.ToString();

            if (reports == "Issuance Reports")
            {
                loadData(processby);

            }
            else if (reports == "Request Reports")
            {
                loadData2(processby, stat, deliveryoptions);
            }
            else if (reports == "Appointment Reports")
            {
                loadData3(processby);
            }
            else if (reports == "Miscellaneous Services Reports")
            {
                loadData4(processby , stat, deliveryoptions);
            }
            else
            {
                loadData(processby);
            }
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            //btnFilter_Click(null, null);
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            //btnFilter_Click(null, null);

        }

        private void cbProcessBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnFilter_Click(null, null);

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           // btnFilter_Click(null, null);

        }

        private void cbDeliveryOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnFilter_Click(null, null);

        }
    }

    public class ProcessedBy
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
    }

    public class DeliveryOptions
    {
        public string Id { get; set; }
        public string Options { get; set; }
    }
}
