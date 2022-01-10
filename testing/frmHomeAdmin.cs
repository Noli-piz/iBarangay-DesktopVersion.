using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace testing
{
    public partial class frmHomeAdmin : Form
    {
        csHostConfiguration host = new csHostConfiguration();

        public frmHomeAdmin()
        {
            InitializeComponent();
        }

        private void frmHomeAdmin_Load(object sender, EventArgs e)
        {
            fetchCount();
        }



        private async void fetchCount()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_home_count.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["count"])
                    {
                        lblTotalResidents.Text = jo["Resident"].ToString();
                        lblActiveUsers.Text = jo["ActiveUsers"].ToString();
                        lblValidated.Text = jo["Validated"].ToString();
                        lblDisabledAccount.Text = jo["BannedAccount"].ToString();
                        lblRegisteredVoter.Text = jo["Register"].ToString();
                        lblActiveBlotter.Text = jo["Active"].ToString();
                    }
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
