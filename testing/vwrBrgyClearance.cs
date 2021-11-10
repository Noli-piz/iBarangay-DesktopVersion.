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
using System.Drawing.Printing;
using testing.Properties;
using System.IO;

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

            foreach (ToolStrip ts in crystalReportViewer1.Controls.OfType<ToolStrip>())
            {
                foreach (ToolStripButton tsb in ts.Items.OfType<ToolStripButton>())
                {
                    //hacky but should work. you can probably figure out a better method
                    if (tsb.ToolTipText.ToLower().Contains("export"))
                    {
                        //Adding a handler for our propose
                        tsb.Click += new EventHandler(printButton_Click);
                    }

                    else if (tsb.ToolTipText.ToLower().Contains("print"))
                    {
                        //Adding a handler for our propose
                        tsb.Click += new EventHandler(printButton_Click);
                    }
                }
            }

            ID = id;
            Purpose = purpose;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            try
            {
                csUser users = new csUser();
                var uri = host.IP() + "/iBar/ibar_issuancereport_insert.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["UserID"] = users.strID();
                    datas["Types"] = "Barangay Clearance";
                    datas["ResidentID"] = ID;
                    datas["Purpose"] = Purpose;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void vwrBrgyClearance_Load(object sender, EventArgs e)
        {
            LoadOfficials();
            SelectData();
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;


        }

        private async void SelectData()
        {
            try
            {

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

                        //String localURL = @"D:\TempImage\temp.png";
                        String localURL = @"C:\temp.png";
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                client.DownloadFileAsync(new Uri(jo["Image"].ToString()), localURL);
                                deletefileurl = localURL;
                            }
                            catch(Exception e)
                            {
                                MessageBox.Show("No image available for this resident.");
                            }
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

        string deletefileurl="";
        private void vwrBrgyClearance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(deletefileurl))
            {
                File.Delete(deletefileurl);
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

                    ReportDocument cryRpt = new ReportDocument();
                    //cryRpt.Load("C:\\Users\\Lenovo\\source\\repos\\testing\\testing\\rptBrgyClearance.rpt");
                    //MessageBox.Show(Application.StartupPath);
                    cryRpt.Load("rptBrgyClearance.rpt");
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

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 


    }
}
