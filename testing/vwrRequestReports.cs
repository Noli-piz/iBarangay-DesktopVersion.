using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class vwrRequestReports : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        DTReport ds = new DTReport();
        String SDate = "", EDate = "", ProcessBy="", Status="";

        public vwrRequestReports(string SDate, string EDate, string ProcessBy, string Status)
        {
            InitializeComponent();

            this.SDate = SDate;
            this.EDate = EDate;
            this.ProcessBy = ProcessBy;
            this.Status = Status;
        }

        private void vwrRequestReports_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            try
            {

                var uri = host.IP() + "/iBar/ibar_reportrequest.php";


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

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["requestreport"])
                    {

                        string id = jo["id_requestsreports"].ToString();
                        string fullname = jo["Fullname"].ToString();
                        string username = jo["Username"].ToString();
                        string fname = jo["Fname"].ToString();
                        string mname = jo["Mname"].ToString();
                        string lname = jo["Lname"].ToString();
                        string sname = jo["Sname"].ToString();
                        string purpose = jo["Purpose"].ToString();
                        string dor = jo["DateOfRequest"].ToString();
                        string status = jo["Status"].ToString();
                        string opt = jo["Options"].ToString();
                        string date = jo["Date"].ToString();

                        ds.dataRequestReport.Rows.Add(
                            id, 
                            fullname,
                            username,
                            fname,
                            mname,
                            lname,
                            sname,
                            purpose,
                            dor,
                            status,
                            opt,
                            date
                            );
                    }


                    ReportDocument cryRpt = new ReportDocument();
                    //cryRpt.Load(Application.StartupPath + "\\rptRequestReport.rpt");
                    cryRpt.Load("C:\\Users\\Lenovo\\source\\repos\\testing\\testing\\rptRequestReport.rpt");
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
