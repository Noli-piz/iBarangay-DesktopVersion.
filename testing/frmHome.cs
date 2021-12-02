using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace testing
{
    public partial class frmHome : Form
    {
        private csHostConfiguration host = new csHostConfiguration();
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
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
                        lblTotalMale.Text = jo["Male"].ToString();
                        lblTotalFemale.Text = jo["Female"].ToString();
                        lblActiveCases.Text = jo["Active"].ToString();
                        lblRegisteredVoter.Text = jo["Register"].ToString();
                        lblTotalPending.Text = jo["Request"].ToString();
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
