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
    public partial class vwrIssuanceReports : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        DTReport ds = new DTReport();
        String SDate ="", EDate="", ProcessBy="", DeliveryOpt="";

        public vwrIssuanceReports(String SDate, String EDate, string ProcessBy, string DeliveryOpt)
        {
            InitializeComponent();

            this.SDate = SDate;
            this.EDate = EDate;
            this.ProcessBy = ProcessBy;
            this.DeliveryOpt = DeliveryOpt;
        }

        private void vwrIssuanceReports_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            try
            {

                var uri = host.IP() + "/iBar/ibar_reportissuance.php";


                string responseFromServer;
                using (var wb = new WebClient())
                {
                    string date1 = SDate;
                    string date2 = EDate;

                    var datas = new NameValueCollection();
                    datas["Date1"] = date1.ToString();
                    datas["Date2"] = date2.ToString();
                    datas["ProcessBy"] = ProcessBy;
                    datas["DeliveryOpt"] = DeliveryOpt;


                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["issuancereport"])
                    {

                        string id = jo["id_issuancereports"].ToString();
                        string fullname = jo["Fullname"].ToString();
                        string fname = jo["Fname"].ToString();
                        string mname = jo["Mname"].ToString();
                        string lname = jo["Lname"].ToString();
                        string sname = jo["Sname"].ToString();
                        string types = jo["Types"].ToString();
                        string purpose = jo["Purpose"].ToString();
                        string date = jo["Date"].ToString();

                        ds.dataIssuanceReport.Rows.Add(
                            id,
                            fullname,
                            fname,
                            mname,
                            lname,
                            sname,
                            types,
                            purpose,
                            date
                            );
                    }


                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load("C:\\Users\\Lenovo\\source\\repos\\testing\\testing\\rptIssuanceReport.rpt");
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
