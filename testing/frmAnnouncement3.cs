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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmAnnouncement3 : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private string ID ;

        public frmAnnouncement3(string id)
        {
            InitializeComponent();
            ID = id;
        }

        private void frm_Announcement3_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            SelectData();

        }
        private void mnpltDataGrid()
        {
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("sbjct", "Subject");
            data1.Columns.Add("dtls", "Details");
            data1.Columns.Add("date", "Date");
            data1.Columns.Add("lvl", "Level");
            data1.Columns.Add("sent", "Sent To");
            data1.Columns.Add("actn", "Action");
            data1.Columns.Add("fllnm", "Processed By");
            data1.Columns.Add("dtmdfd", "Date Modified");

            data1.Columns["ID"].Visible = false;
        }

        private async void SelectData()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_announcement_history.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }


                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["announcement"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_announcementreports"]);
                        AL.Add(jo["Subject"]);
                        AL.Add(jo["Details"]);
                        AL.Add(jo["Date"]);
                        AL.Add(jo["Level"]);
                        AL.Add(jo["SendTo"]);
                        AL.Add(jo["Action"]);
                        AL.Add(jo["Fullname"]);
                        AL.Add(jo["DateModified"]);
                        data1.Rows.Add(AL.ToArray());
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
    }
}
