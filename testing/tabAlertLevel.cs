using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace testing
{
    public partial class tabAlertLevel : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        public tabAlertLevel()
        {
            InitializeComponent();
        }

        private void tabAlertLevel_Load(object sender, EventArgs e)
        {
            mnpltDataGridAlert();
            loadDataAlert();
        }


        private void mnpltDataGridAlert()
        {
            mtrData1.Rows.Clear();
            mtrData1.Columns.Clear();

            mtrData1.Columns.Add("no", "No.");
            mtrData1.Columns.Add("id", "ID.");
            mtrData1.Columns.Add("lvl", "Level Name");
            mtrData1.Columns.Add("img", "Image Location");

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Action";
            btn1.Name = "btnGenerate";
            btn1.Text = "View/Edit";
            btn1.UseColumnTextForButtonValue = true;
            mtrData1.Columns.Add(btn1);
        }

        private async void loadDataAlert()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_alertlevel.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["level"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_alertlevel"]);
                        AL.Add(jo["LevelName"]);
                        AL.Add(jo["ImageLocation"]);
                        mtrData1.Rows.Add(AL.ToArray());
                        i++;
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
