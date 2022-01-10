using CrystalDecisions.CrystalReports.Engine;
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
    public partial class vwrMiscellaneousServices : Form
    {

        csHostConfiguration host = new csHostConfiguration();
        DTReport ds = new DTReport();
        String SDate = "", EDate = "", ProcessBy="", Status="", DeliveryOpt="";

        public vwrMiscellaneousServices(string SDate, string EDate, string ProcessBy, string Status, string DeliveryOpt)
        {
            InitializeComponent();

            this.SDate = SDate;
            this.EDate = EDate;
            this.ProcessBy = ProcessBy;
            this.Status = Status;
            this.DeliveryOpt = DeliveryOpt;
        }

        private void vwrMiscellaneousServices_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_reportmiscellaneous.php";


                string responseFromServer;
                using (var wb = new WebClient())
                {
                    string date1 = SDate;
                    string date2 = EDate;

                    var datas = new NameValueCollection();
                    datas["Date1"] = date1.ToString();
                    datas["Date2"] = date2.ToString();
                    datas["ProcessBy"] = ProcessBy;
                    datas["Status"] = Status;
                    datas["DeliveryOpt"] = DeliveryOpt;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }


                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
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

                        ds.dataMiscellaneousReport.Rows.Add(
                            id,
                            fullname,
                            username,
                            fname,
                            mname,
                            lname,
                            sname,
                            itemname,
                            quantity,
                            purpose,
                            status,
                            dor,
                            deadline,
                            note,
                            options,
                            dateprocessed
                            );
                    }


                    ReportDocument cryRpt = new ReportDocument();
                    //cryRpt.Load(Application.StartupPath + "\\rptRequestReport.rpt");
                    cryRpt.Load("C:\\Users\\Lenovo\\source\\repos\\testing\\testing\\rptMiscellaneousServicesReports.rpt");
                    cryRpt.SetDataSource(ds);

                    crystalReportViewer1.ReportSource = cryRpt;
                    crystalReportViewer1.Refresh();


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
