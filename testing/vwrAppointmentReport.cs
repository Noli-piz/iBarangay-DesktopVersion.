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
    public partial class vwrAppointmentReport : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        DTReport ds = new DTReport();
        String SDate = "", EDate = "";

        public vwrAppointmentReport(String SDate, String EDate)
        {
            InitializeComponent();

            this.SDate = SDate;
            this.EDate = EDate;
        }
        private void vwrAppointmentReport_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            try
            {

                var uri = host.IP() + "/iBar/ibar_reportappointment.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    string date1 = SDate;
                    string date2 = EDate;

                    var datas = new NameValueCollection();
                    datas["Date1"] = date1.ToString();
                    datas["Date2"] = date2.ToString();

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["appointmentreport"])
                    {

                        String id = jo["id_appointmentreports"].ToString();
                        String fullname = jo["Fullname"].ToString();
                        String title = jo["Title"].ToString();
                        String name = jo["Name"].ToString();
                        String apdate = jo["apDate"].ToString();
                        String start = jo["StartTime"].ToString();
                        String end = jo["EndTime"].ToString();
                        String det = jo["Details"].ToString();
                        String status = jo["Status"].ToString();
                        String deleted = jo["Deleted"].ToString();
                        String date = jo["Date"].ToString();

                        ds.dataAppointmentReport.Rows.Add(
                            
                            id,
                            fullname,
                            title,
                            name,
                            apdate,
                            start,
                            end,
                            det,
                            status,
                            deleted,
                            date
                            );
                    }

                    ReportDocument cryRpt = new ReportDocument();
                    //cryRpt.Load(Application.StartupPath + "\\rptAppointmentReport.rpt");
                    cryRpt.Load("C:\\Users\\Lenovo\\source\\repos\\testing\\testing\\rptAppointmentReport.rpt");
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
