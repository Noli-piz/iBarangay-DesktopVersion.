using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Specialized;

namespace testing
{
    public partial class vwrBrgyClearance : Form
    {

        csHostConfiguration host = new csHostConfiguration();
        String ID, Purpose;
        DTofficials ds = new DTofficials();


        public vwrBrgyClearance(String id, String purpose)
        {
            InitializeComponent();
            ID = id;
            Purpose = purpose;
        }

        private void vwrBrgyClearance_Load(object sender, EventArgs e)
        {
            LoadOfficials();
            SelectData();
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;

        }

        static TextObject txtResidentName, txtResidentAge, txtResidentStatus, txtResidentPurpose;

        private async void SelectData()
        {
            try
            {


/*                txtResidentName = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strResidentName"];
                txtResidentAge = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strAge"];
                txtResidentStatus = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strResidentStatus"];
                txtResidentPurpose = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strResidentPurpose"];*/

                var uri = host.IP() + "/iBar/ibar_issuance_specific.php";

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

                    int i = 0;
                    foreach (var jo in (JArray)((JObject)data)["issuance"])
                    {

                        String localURL = @"D:\TempImage\temp.png";
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFileAsync(new Uri(jo["Image"].ToString()), localURL);
                        }

                        ds.Resident.Rows.Add( i, jo["FullName"].ToString(), jo["Age"].ToString(), jo["CivilStatus"].ToString(), Purpose, localURL);
                        i++;
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

        private async void DownloadImage(String url)
        {
            var request = WebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {


                //Image img = new Bitmap(stream);
                //return img.GetThumbnailImage(200, 200, null, new IntPtr());
            }
        }

        private async void LoadOfficials()
        {

            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_official.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {

                    int i=0;
                    foreach (var jo in (JArray)((JObject)data)["official"])
                    {
                        ds.Data.Rows.Add(jo["Fname"].ToString(), jo["Position1"].ToString(), jo["Position2"].ToString(), i);
                        i++;
                    }

                    //TextObject txtChairman = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strBarangayChairman"];
                    //txtChairman.Text =Cname; 

                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load("C:\\Users\\Lenovo\\source\\repos\\testing\\testing\\rptBrgyClearance.rpt");
                    //MessageBox.Show(Application.StartupPath);
                    //cryRpt.Load("\\testing\\testing\\rptBrgyClearance.rpt");
                    cryRpt.SetDataSource(ds);

                    crystalReportViewer1.ReportSource = cryRpt;
                    crystalReportViewer1.Refresh();

                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
